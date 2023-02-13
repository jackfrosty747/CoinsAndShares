Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Module PublicFunctions

    Friend Const DATABASE_NAME = "CoinsAndShares"

    Friend Const FORMAT_QUANTITY As String = "#,###,###,##0.##########"
    Friend Const FORMAT_RATE As String = "#,###,###,##0.##########"

    Friend Const NICEHASH_ACCOUNT_CODE = "NICEHASH" ' Add this to a setting in future if required
    Friend Const NEXO_ACCOUNT_CODE = "NEXO" ' Add this to a setting in future if required

    Friend Enum EDescriptionPresets
        Interest
        Cashback
        Missions
        Misc_Fees
        Compensation
        Airdrop
    End Enum

    <Extension()>
    Friend Function Code(enumConstant As [Enum]) As String
        Dim fi As FieldInfo = enumConstant.GetType().GetField(enumConstant.ToString())
        Dim aattr = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        If aattr.Length > 0 Then
            Return aattr(0).Description
        Else
            Return enumConstant.ToString()
        End If
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

        If TypeOf lastElementEntered Is RowUIElement Then
            rowElement = DirectCast(lastElementEntered, RowUIElement)
        Else
            rowElement = DirectCast(lastElementEntered.GetAncestor(GetType(RowUIElement)), RowUIElement)
        End If

        If rowElement IsNot Nothing Then
            Return True
        End If

        Return False

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
        Dim ri = New RegionInfo(Threading.Thread.CurrentThread.CurrentUICulture.LCID)
        Return ri.ISOCurrencySymbol
    End Function
    Friend Function GetLocalCurrencyName() As String
        Dim ri = New RegionInfo(Threading.Thread.CurrentThread.CurrentUICulture.LCID)
        Return ri.CurrencyNativeName
    End Function

End Module
