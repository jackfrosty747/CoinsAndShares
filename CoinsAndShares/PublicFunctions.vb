Imports System.ComponentModel
Imports System.Globalization
Imports System.Net
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Accounts.MAccounts
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Instruments.MInstuments
Imports CoinsAndShares.Transactions
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Module PublicFunctions

    Public Const APP_URL = "https://www.jack-frost.co.uk/coins_and_shares.php"

    Friend Const FORMAT_QUANTITY As String = "#,###,###,##0.##########"
    Friend Const FORMAT_RATE As String = "#,###,###,##0.##########"

    Friend Const TRADING212_ACCOUNT_CODE = "212" ' Add this to a setting in future if required
    Friend Const NEXO_ACCOUNT_CODE = "NEXO" ' Add this to a setting in future if required

    Friend Enum EDescriptionPresets
        Interest
        Cashback
        Missions
        Misc_Fees
        Compensation
        Airdrop
        Games
        Survey
    End Enum

    Friend Function ContainsIgnoreCase(source As String, toCheck As String) As Boolean
        Return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0
    End Function

    <Extension()>
    Friend Function Code(enumConstant As [Enum]) As String
        Dim fi As FieldInfo = enumConstant.GetType().GetField(enumConstant.ToString())
        Dim aattr = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        Return If(aattr.Length > 0, aattr(0).Description, enumConstant.ToString())
    End Function

    Friend Sub GridDefaults(ugl As UltraGridLayout)

        ' Set defaults to apply to all grid and combos/dropdowns

        ugl.ScrollStyle = ScrollStyle.Immediate
        ugl.ScrollBounds = ScrollBounds.ScrollToFill

        With ugl.Grid
            .SupportThemes = False
            .DisplayLayout.CaptionAppearance.BackColor = Color.FromArgb(230, 230, 230)
            .DisplayLayout.Bands(0).Override.HeaderAppearance.BackColor = Color.FromArgb(230, 230, 230)
        End With

    End Sub

    Friend Function WasGridRowClicked(sender As Object) As Boolean

        ' Call this in the grid click or doubleclick event with the sender
        ' passed through.  This will return whether the event was caused by
        ' clicking on a row, and not something else, like arrows buttons, 
        ' or headers, etc.

        Dim grid As UltraGridBase
        Dim lastElementEntered As UIElement
        Dim rowElement As RowUIElement

        grid = DirectCast(sender, UltraGrid)
        If grid Is Nothing Then Return False

        lastElementEntered = grid.DisplayLayout.UIElement.LastElementEntered

        rowElement = If(TypeOf lastElementEntered Is RowUIElement,
            DirectCast(lastElementEntered, RowUIElement),
            DirectCast(lastElementEntered.GetAncestor(GetType(RowUIElement)), RowUIElement))

        Return rowElement IsNot Nothing

    End Function

    Friend Sub HandleArrowKeys(oGrid As Object, e As KeyEventArgs)

        Dim grid As UltraGrid

        If TypeOf oGrid IsNot UltraGrid Then
            Throw New Exception("Woops: handleArrowKeys has been passed an object which isn't a grid")
        End If

        grid = DirectCast(oGrid, UltraGrid)

        Select Case e.KeyValue
            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right
                grid.PerformAction(UltraGridAction.ExitEditMode)
                e.Handled = True
        End Select

        Select Case e.KeyValue
            Case Keys.Up
                grid.PerformAction(UltraGridAction.AboveCell)
            Case Keys.Down
                grid.PerformAction(UltraGridAction.BelowCell)
            Case Keys.Left
                grid.PerformAction(UltraGridAction.PrevCellByTab)
            Case Keys.Right
                grid.PerformAction(UltraGridAction.NextCellByTab)
        End Select

        Select Case e.KeyValue
            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right
                grid.PerformAction(UltraGridAction.EnterEditMode)
        End Select

    End Sub

    Friend Function GetCurrencyAmount(sLabel As String, sAmount As String, fSilent As Boolean) As Decimal
        ' Convert local currency in string form to currency amount.  Remove local currency symbol and round appropriately.  Silent
        ' to return zero.  sLabel is just to show what is invalid in case of error
        Dim cAmount As Decimal = 0
        If sAmount.Length > 0 AndAlso Not Decimal.TryParse(sAmount, NumberStyles.Currency, CultureInfo.CurrentCulture, cAmount) Then
            If fSilent Then
                Return 0
            End If
            Throw New Exception(String.Format(CultureInfo.CurrentCulture, My.Resources.Error_CurrencyAmountNotValid, sLabel))
        End If
        cAmount = Math.Round(cAmount, 2, MidpointRounding.AwayFromZero)
        Return cAmount
    End Function

    Friend Function GetLocalCurrencyIso() As String
        Dim ri = New RegionInfo(CultureInfo.CurrentCulture.Name)
        Return ri.ISOCurrencySymbol
    End Function
    Friend Function GetLocalCurrencyName() As String
        Dim ri = New RegionInfo(CultureInfo.CurrentCulture.Name)
        Return ri.CurrencyNativeName
    End Function

    Friend Function GetBuildDateTime() As Date?

        Dim sBuildDateTime = My.Resources.BuildDate

        Dim lines = Split(sBuildDateTime, Environment.NewLine)

        For Each line In lines
            Dim d As Date
            Dim s = line.Trim
            If Date.TryParseExact(s, "dd/MM/yyyy HH:mm:ss.ff", CultureInfo.InvariantCulture, DateTimeStyles.None, d) Then
                Return d
            End If
        Next

        Return Nothing

    End Function

    Public Function GetSimplePublicIP() As String
        Dim client As New WebClient()
        Return client.DownloadString("https://api.ipify.org").Trim()
    End Function

    Public Function GetFieldOrdinals(reader As IDataReader) As Dictionary(Of String, Integer)
        Dim ordinals As New Dictionary(Of String, Integer)(StringComparison.OrdinalIgnoreCase)

        For i As Integer = 0 To reader.FieldCount - 1
            ordinals.Add(reader.GetName(i), i)
        Next

        Return ordinals
    End Function

    Friend Function GetTransactionFromReader(reader As IDataReader, ords As Dictionary(Of String, Integer)) As CTransaction
        Dim id = CDatabase.DbToLong(reader(ords(CDatabase.FIELD_TRANSACTIONS_ID)))
        Dim transDate = If(reader.IsDBNull(ords(CDatabase.FIELD_TRANSACTIONS_TRANSDATE)),
            Date.MinValue,
            CDate(reader(ords(CDatabase.FIELD_TRANSACTIONS_TRANSDATE))))
        Dim transType As ETransactionType = GetTransactionTypeFromCode(CDatabase.DbToString(reader(ords(CDatabase.FIELD_TRANSACTIONS_TRANSTYPE))), True)
        Dim accountCode As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE)))
        Dim instrumentCode As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE)))
        Dim rate As Decimal = CDatabase.DbToDecimal(reader(ords(CDatabase.FIELD_TRANSACTIONS_RATE)))
        Dim amount As Decimal = CDatabase.DbToDecimal(reader(ords(CDatabase.FIELD_TRANSACTIONS_AMOUNT)))
        Dim description As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_TRANSACTIONS_DESCRIPTION)))
        Dim batchId As Long = CDatabase.DbToLong(reader(ords(CDatabase.FIELD_TRANSACTIONS_BATCH)))
        Dim exchangeRate As Decimal = CDatabase.DbToDecimal(reader(ords(CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE)))
        Dim reconciled As Boolean = CDatabase.DbToBool(reader(ords(CDatabase.FIELD_TRANSACTIONS_RECONCILED)))
        Return New CTransaction(id, transDate, transType, accountCode, instrumentCode, rate, amount, description, batchId, exchangeRate, reconciled)
    End Function

    Friend Function GetInstrumentFromReader(reader As IDataReader, ords As Dictionary(Of String, Integer)) As CInstrument
        Dim sInstrumentCode As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE)))
        Dim sTypeCode As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE)))
        Dim instrumentType As EInstrumentType = GetInstrumentTypeFromCode(sTypeCode, True)
        Dim sDescription As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_INSTRUMENT_DESCRIPTION)))
        Dim rRate As Decimal = CDatabase.DbToDecimal(reader(ords(CDatabase.FIELD_INSTRUMENT_RATE)))
        Dim sProviderLinkCode As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE)))
        Dim sCurrencyCode As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_INSTRUMENT_CURRENCYCODE)))

        Dim rateUpdated As Date? = Nothing
        If Not reader.IsDBNull(ords(CDatabase.FIELD_INSTRUMENT_RATEUPDATED)) Then
            rateUpdated = CType(reader(ords(CDatabase.FIELD_INSTRUMENT_RATEUPDATED)), Date)
        End If

        Dim providerMultiplier As Decimal = CDatabase.DbToDecimal(reader(ords(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER)))
        Dim sNotes As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_INSTRUMENT_NOTES)))
        Dim sHedgingGroupCode = CDatabase.DbToString(reader(ords(CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE)))
        Dim iRateProvider = CDatabase.DbToInt(reader(ords(CDatabase.FIELD_INSTRUMENT_RATEPROVIDER)))

        Return New CInstrument(sInstrumentCode, instrumentType, sDescription, rRate, rateUpdated,
                       sProviderLinkCode, sCurrencyCode, providerMultiplier, sNotes, sHedgingGroupCode, iRateProvider)
    End Function

    Friend Function GetAccountFromReader(reader As IDataReader, ords As Dictionary(Of String, Integer)) As CAccount
        Dim accountCode As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE)))
        Dim accountName As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME)))
        Dim accountType As EAccountType = GetAccountTypeFromCode(CDatabase.DbToString(reader(ords(CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE))), True)
        Dim notes As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_ACCOUNTS_NOTES)))
        Dim networkId As String = CDatabase.DbToString(reader(ords(CDatabase.FIELD_ACCOUNTS_NETWORKID)))
        Dim includeOnShortcuts = CDatabase.DbToBool(reader(ords(CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS)))
        Dim nonTaxable = CDatabase.DbToBool(reader(ords(CDatabase.FIELD_ACCOUNTS_NONTAXABLE)))
        Dim cashSavingsRate = CDatabase.DbToDecimal(reader(ords(CDatabase.FIELD_ACCOUNTS_CASHSAVINGSRATE)))
        Return New CAccount(accountCode, accountName, accountType, notes, networkId, includeOnShortcuts, nonTaxable, cashSavingsRate)
    End Function

End Module
