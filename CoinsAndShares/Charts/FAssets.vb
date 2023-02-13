Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Networks
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Charts
    Friend Class FAssets
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.chart.GetHicon)

            Dim allAccounts = commonObjects.Accounts.GetAll
            Dim allInstruments = commonObjects.Instruments.GetAll

            Dim assets = GetAssets(commonObjects)

            GridHelperAssetsByAccount.LoadData(GrdAssetsByAccount, assets, commonObjects, allAccounts, allInstruments, commonObjects.Networks)
            GridHelperAccountsByAsset.LoadData(GrdAccountsByAsset, assets, commonObjects, allAccounts, allInstruments, commonObjects.Networks)

            LoadSummary()

        End Sub
        Private Sub LoadSummary()

            Dim cBankTotal As Decimal
            Try
                Dim sql = $"
                SELECT Sum({CDatabase.FIELD_TRANSACTIONS_AMOUNT})
                FROM {CDatabase.TABLE_ACCOUNTS} a JOIN {CDatabase.TABLE_TRANSACTIONS} t ON
                    a.{CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} = t.{CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE}
                WHERE a.{CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE} = {CDatabase.SqlString(EAccountType.Bank_Account.Code)};"

                Using dt = m_commonObjects.Database.GetDatatable(sql)
                    For Each dr As DataRow In dt.Rows
                        cBankTotal = CDatabase.DbToDecimal(dr(0))
                    Next
                End Using
            Catch ex As Exception
                Throw
            End Try

            Dim cTotalCrypto As Decimal
            Dim cTotalShares As Decimal
            Try
                Const GRP_AMOUNT = "gbpAmount"
                Const TOTAL_AMOUNT = "totalAmount"

                Dim sql = $"
                    SELECT {CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE}, Sum({GRP_AMOUNT}) {GRP_AMOUNT}
                    FROM (

	                    SELECT i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE},
                            (a.{TOTAL_AMOUNT} * i.{CDatabase.FIELD_INSTRUMENT_RATE}) / CASE WHEN Coalesce(c.{CDatabase.FIELD_CURRENCIES_CURRENCYRATE}, 0) <= 0 THEN 1 ELSE c.{CDatabase.FIELD_CURRENCIES_CURRENCYRATE} END {GRP_AMOUNT}

	                    FROM {CDatabase.TABLE_INSTRUMENT} i JOIN {CDatabase.TABLE_CURRENCIES} c ON
                                i.{CDatabase.FIELD_INSTRUMENT_CURRENCYCODE} = c.{CDatabase.FIELD_CURRENCIES_CURRENCYCODE} JOIN (

	                        SELECT {CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE}, Sum({CDatabase.FIELD_TRANSACTIONS_AMOUNT}) {TOTAL_AMOUNT}
	                        FROM {CDatabase.TABLE_TRANSACTIONS}
	                        GROUP BY {CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE}
	                        HAVING {CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE} IS NOT NULL AND Sum({CDatabase.FIELD_TRANSACTIONS_AMOUNT}) <> 0

                        ) a ON i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE} = a.{CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE}

                    ) b

                    GROUP BY {CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE};"

                Using dt = m_commonObjects.Database.GetDatatable(sql)
                    For Each dr As DataRow In dt.Rows
                        Dim sType = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE))
                        Select Case sType.ToUpper
                            Case EAccountType.Crypto.Code.ToUpper
                                cTotalCrypto = CDatabase.DbToDecimal(dr(GRP_AMOUNT))
                            Case EAccountType.Share_Account.Code.ToUpper
                                cTotalShares = CDatabase.DbToDecimal(dr(GRP_AMOUNT))
                        End Select
                    Next
                End Using

            Catch ex As Exception
                Throw
            End Try


            Dim sOut = $"
CRYPTO ASSETS (Current GBP value) : {RSet(cTotalCrypto.ToString("c2"), 12)}
SHARES ASSETS (Current GBP value) : {RSet(cTotalShares.ToString("c2"), 12)}
                                    {RSet("------------", 12)}
TOTAL ASSETS (Current GBP value)    {RSet((cTotalCrypto + cTotalShares).ToString("c2"), 12)}

BANK TOTAL                        : {RSet(cBankTotal.ToString("c2"), 12)}

GRAND TOTAL                       : {RSet((cTotalCrypto + cTotalShares + cBankTotal).ToString("c2"), 12)}

"

            TxtSummary.Text = sOut

        End Sub
        Private NotInheritable Class GridHelperAssetsByAccount
            Private Enum ColumnsNetwork
                NetworkId
                NetworkName ' Nothing
                NetworkValue
            End Enum
            Private Enum ColumnsAccount
                NetworkId
                AccountCode
                AccountName
                AccountValue
            End Enum
            Private Enum ColumnsInstrument
                NetworkId
                AccountCode
                InstrumentCode
                InstrumentName
                InstrumentType
                InstrumentValue
            End Enum
            Private NotInheritable Class LocalTagBits : Inherits TagBits
                Friend ReadOnly AllAccounts As IEnumerable(Of CAccount)
                Friend ReadOnly AllInstruments As IEnumerable(Of CInstrument)
                Friend ReadOnly Networks As CNetworks
                Friend Sub New(commonObjects As CCommonObjects, allAccounts As IEnumerable(Of CAccount),
                               allInstruments As IEnumerable(Of CInstrument), networks As CNetworks)
                    MyBase.New(commonObjects)
                    Me.AllAccounts = allAccounts
                    Me.AllInstruments = allInstruments
                    Me.Networks = networks
                End Sub
            End Class

            Friend Shared Sub LoadData(grid As UltraGrid, assets As IEnumerable(Of AssetRow), commonObjects As CCommonObjects,
                                       allAccounts As IEnumerable(Of CAccount), allInstruments As IEnumerable(Of CInstrument),
                                       networks As CNetworks)

                grid.Tag = New LocalTagBits(commonObjects, allAccounts, allInstruments, networks)

                Dim dtNetworks As New DataTable
                dtNetworks.Columns.Add(ColumnsNetwork.NetworkId.ToString)
                dtNetworks.Columns.Add(ColumnsNetwork.NetworkName.ToString)
                dtNetworks.Columns.Add(ColumnsNetwork.NetworkValue.ToString, GetType(Decimal))

                Dim dtAccounts As New DataTable
                dtAccounts.Columns.Add(ColumnsAccount.NetworkId.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountCode.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountName.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountValue.ToString, GetType(Decimal))

                Dim dtInstruments As New DataTable
                dtInstruments.Columns.Add(ColumnsInstrument.NetworkId.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.AccountCode.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentCode.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentName.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentType.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentValue.ToString, GetType(Decimal))

                Dim networkIdsUsed = From asset In assets
                                     Group By asset.NetworkId Into NetworkValue = Sum(asset.Value)
                                     Order By NetworkValue Descending

                ' Networks
                For Each networkId In networkIdsUsed
                    Dim drNetwork = dtNetworks.NewRow
                    drNetwork(ColumnsNetwork.NetworkId.ToString) = networkId.NetworkId
                    drNetwork(ColumnsNetwork.NetworkValue.ToString) = networkId.NetworkValue
                    dtNetworks.Rows.Add(drNetwork)

                    ' Accounts
                    Dim networkAccounts = From asset In assets
                                          Where asset.NetworkId.Equals(networkId.NetworkId, StringComparison.InvariantCultureIgnoreCase)
                                          Group By asset.AccountCode Into AccountValue = Sum(asset.Value)
                                          Order By AccountValue Descending
                    For Each networkAccount In networkAccounts
                        Dim drAccount = dtAccounts.NewRow
                        drAccount(ColumnsAccount.NetworkId.ToString) = networkId.NetworkId
                        drAccount(ColumnsAccount.AccountCode.ToString) = networkAccount.AccountCode
                        drAccount(ColumnsAccount.AccountValue.ToString) = networkAccount.AccountValue
                        dtAccounts.Rows.Add(drAccount)

                        ' Assets
                        Dim accountAssets = From asset In assets
                                            Where asset.NetworkId.Equals(networkId.NetworkId, StringComparison.InvariantCultureIgnoreCase) And
                                            asset.AccountCode.Equals(networkAccount.AccountCode, StringComparison.InvariantCultureIgnoreCase)
                                            Group By asset.InstrumentCode Into InstrumentValue = Sum(asset.Value),
                                                InstrumentTypeCode = Max(asset.InstrumentType.Code)
                                            Order By InstrumentValue Descending
                        For Each accountAsset In accountAssets
                            Dim drInstrument = dtInstruments.NewRow
                            drInstrument(ColumnsInstrument.NetworkId.ToString) = networkId.NetworkId
                            drInstrument(ColumnsInstrument.AccountCode.ToString) = networkAccount.AccountCode
                            drInstrument(ColumnsInstrument.InstrumentCode.ToString) = accountAsset.InstrumentCode
                            drInstrument(ColumnsInstrument.InstrumentType.ToString) = accountAsset.InstrumentTypeCode
                            drInstrument(ColumnsInstrument.InstrumentValue.ToString) = accountAsset.InstrumentValue
                            dtInstruments.Rows.Add(drInstrument)
                        Next
                    Next
                Next

                Dim ds = New DataSet
                ds.Tables.Add(dtNetworks)
                ds.Tables.Add(dtAccounts)
                ds.Tables.Add(dtInstruments)

                ds.Relations.Add(String.Empty, dtNetworks.Columns(ColumnsNetwork.NetworkId.ToString), dtAccounts.Columns(ColumnsAccount.NetworkId.ToString))

                ds.Relations.Add(String.Empty,
                             New DataColumn() {dtAccounts.Columns(ColumnsAccount.NetworkId.ToString), dtAccounts.Columns(ColumnsAccount.AccountCode.ToString)},
                             New DataColumn() {dtInstruments.Columns(ColumnsInstrument.NetworkId.ToString), dtInstruments.Columns(ColumnsInstrument.AccountCode.ToString)})

                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow

                grid.DataSource = ds

            End Sub

            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    If e.ReInitialize Then
                        Return
                    End If

                    If e.Row.Band.Index = 0 Then
                        e.Row.Expanded = True
                    End If

                    Select Case e.Row.Band.Index
                        Case 0 ' Network
                            Dim sNetworkId = e.Row.Cells(ColumnsNetwork.NetworkId.ToString).Text
                            Dim colour = Color.White
                            Dim all = tagBits.Networks.GetAll ' Already cached
                            Dim n = all.FirstOrDefault(Function(c) c.NetworkId.Equals(sNetworkId, StringComparison.InvariantCultureIgnoreCase))
                            If n IsNot Nothing AndAlso n.Colour.HasValue Then
                                colour = n.Colour.Value
                            End If
                            e.Row.CellAppearance.BackColor = colour
                        Case 1 ' Account
                            Dim sAccount = e.Row.Cells(ColumnsAccount.AccountCode.ToString).Text
                            If Not String.IsNullOrEmpty(sAccount) Then
                                Dim account = tagBits.AllAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(sAccount, StringComparison.InvariantCultureIgnoreCase))
                                Dim colour = Color.White
                                If account IsNot Nothing Then
                                    e.Row.Cells(ColumnsAccount.AccountName.ToString).Value = account.AccountName
                                    colour = tagBits.Networks.GetColour(account)
                                End If
                                e.Row.CellAppearance.BackColor = colour
                            End If
                        Case 2 ' Instrument
                            Dim sInstrument = e.Row.Cells(ColumnsInstrument.InstrumentCode.ToString).Text
                            If Not String.IsNullOrEmpty(sInstrument) Then
                                Dim instrument = tagBits.AllInstruments.FirstOrDefault(Function(c) c.Code.Equals(sInstrument, StringComparison.InvariantCultureIgnoreCase))
                                If instrument IsNot Nothing Then
                                    e.Row.Cells(ColumnsInstrument.InstrumentName.ToString).Value = instrument.Description
                                End If
                            End If

                            Dim instrumentType = GetInstrumentTypeFromCode(e.Row.Cells(ColumnsInstrument.InstrumentType.ToString).Text, True)
                            e.Row.CellAppearance.ForeColor = CColours.InstrumentType(instrumentType)
                    End Select
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .AllowUpdate = DefaultableBoolean.False
                        .RowSelectors = DefaultableBoolean.False
                    End With
                    ' e.Layout.AutoFitColumns = True

                    ' Networks Band
                    With e.Layout.Bands(0)
                        .ColHeadersVisible = False
                        .Override.RowSpacingBefore = 5
                        .Override.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case ColumnsNetwork.NetworkId.ToString
                                col.Header.Caption = "Network ID"
                                col.Width = 100
                            Case ColumnsNetwork.NetworkName.ToString
                                col.Header.Caption = "" ' Placeholder only
                                col.Width = 200
                            Case ColumnsNetwork.NetworkValue.ToString
                                col.Header.Caption = "Value"
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                                col.Width = 100
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                    ' Accounts
                    With e.Layout.Bands(1)
                        .ColHeadersVisible = False
                        .Override.RowSpacingBefore = 0
                        .Override.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(1).Columns
                        Select Case col.Key
                            Case ColumnsAccount.AccountCode.ToString
                                col.Header.Caption = "Account Code"
                            Case ColumnsAccount.AccountName.ToString
                                col.Header.Caption = "Name"
                            Case ColumnsAccount.AccountValue.ToString
                                col.Header.Caption = "Value"
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                    ' Instrumnents
                    With e.Layout.Bands(2)
                        .ColHeadersVisible = False
                        .Override.RowSpacingBefore = 0
                        .Override.CellAppearance.FontData.Bold = DefaultableBoolean.False
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(2).Columns
                        Select Case col.Key
                            Case ColumnsInstrument.InstrumentCode.ToString
                                col.Header.Caption = "Instrument"
                            Case ColumnsInstrument.InstrumentName.ToString
                                col.Header.Caption = "Instrument Name"
                            Case ColumnsInstrument.InstrumentValue.ToString
                                col.Header.Caption = "Value"
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
        End Class
        Private Class AssetRow
            Friend Sub New(networkId As String, accountCode As String, instrumentCode As String, instrumentType As EInstrumentType,
                           amount As Decimal, value As Decimal)
                Me.NetworkId = networkId
                Me.AccountCode = accountCode
                Me.InstrumentCode = instrumentCode
                Me.InstrumentType = instrumentType
                Me.Amount = amount
                Me.Value = value
            End Sub
            Friend ReadOnly Property NetworkId As String
            Friend ReadOnly Property AccountCode As String
            Friend ReadOnly Property InstrumentCode As String
            Friend ReadOnly Property InstrumentType As EInstrumentType
            Friend ReadOnly Property Amount As Decimal
            Friend ReadOnly Property Value As Decimal
        End Class
        Private Shared Function GetAssets(commonObjects As CCommonObjects) As IEnumerable(Of AssetRow)

            Const TOTAL_AMOUNT = "totalAmount"
            Const TOTAL_VALUE = "totalValue"

            Dim sql = $"
                SELECT a.{CDatabase.FIELD_ACCOUNTS_NETWORKID}, a.{CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE}, t.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE},
                    i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE},
                    Sum(t.{CDatabase.FIELD_TRANSACTIONS_AMOUNT}) {TOTAL_AMOUNT},
                    Sum(t.{CDatabase.FIELD_TRANSACTIONS_AMOUNT}) * Coalesce(i.{CDatabase.FIELD_INSTRUMENT_RATE}, 1) /
                        CASE WHEN Coalesce(c.{CDatabase.FIELD_CURRENCIES_CURRENCYRATE}, 0) <= 0 THEN c.{CDatabase.FIELD_CURRENCIES_CURRENCYRATE} ELSE 1 END {TOTAL_VALUE}
                FROM {CDatabase.TABLE_TRANSACTIONS} t JOIN {CDatabase.TABLE_ACCOUNTS} a ON
                    t.{CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE} = a.{CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} LEFT JOIN {CDatabase.TABLE_INSTRUMENT} i ON
                    t.{CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE} = i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE} LEFT JOIN {CDatabase.TABLE_CURRENCIES} c ON
                    i.{CDatabase.FIELD_INSTRUMENT_CURRENCYCODE} = c.{CDatabase.FIELD_CURRENCIES_CURRENCYCODE}
                GROUP BY a.{CDatabase.FIELD_ACCOUNTS_NETWORKID}, a.{CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE}, t.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE},
                    i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE}, i.{CDatabase.FIELD_INSTRUMENT_RATE}, c.{CDatabase.FIELD_CURRENCIES_CURRENCYRATE}
                HAVING Sum(t.{CDatabase.FIELD_TRANSACTIONS_AMOUNT}) <> 0;"

            Dim all As New List(Of AssetRow)

            Using dt = commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim sNetworkId = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_NETWORKID))
                    Dim sAccountCode = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE))
                    Dim sInstrumentCode = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE))

                    Dim sInstrumentType = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE))
                    Dim instrumentType = GetInstrumentTypeFromCode(sInstrumentType, True)

                    Dim rAmount = CDatabase.DbToDecimal(dr(TOTAL_AMOUNT))
                    Dim cValue = CDatabase.DbToDecimal(dr(TOTAL_VALUE))
                    Dim assetRow = New AssetRow(sNetworkId, sAccountCode, sInstrumentCode, instrumentType, rAmount, cValue)
                    all.Add(assetRow)
                Next
            End Using

            Return all

        End Function


        Private NotInheritable Class GridHelperAccountsByAsset
            Private Enum ColumnsInstrument
                InstrumentCode
                InstrumentName
                InstrumentType
                InstrumentValue
            End Enum
            Private Enum ColumnsNetwork
                InstrumentCode
                NetworkId
                NetworkName ' Nothing
                NetworkValue
            End Enum
            Private Enum ColumnsAccount
                InstrumentCode
                NetworkId
                AccountCode
                AccountName
                AccountValue
            End Enum
            Private NotInheritable Class LocalTagBits : Inherits TagBits
                Friend ReadOnly AllAccounts As IEnumerable(Of CAccount)
                Friend ReadOnly AllInstruments As IEnumerable(Of CInstrument)
                Friend ReadOnly Networks As CNetworks
                Friend Sub New(commonObjects As CCommonObjects, allAccounts As IEnumerable(Of CAccount),
                               allInstruments As IEnumerable(Of CInstrument), networks As CNetworks)
                    MyBase.New(commonObjects)
                    Me.AllAccounts = allAccounts
                    Me.AllInstruments = allInstruments
                    Me.Networks = networks
                End Sub
            End Class

            Friend Shared Sub LoadData(grid As UltraGrid, assets As IEnumerable(Of AssetRow), commonObjects As CCommonObjects,
                                       allAccounts As IEnumerable(Of CAccount), allInstruments As IEnumerable(Of CInstrument),
                                       networks As CNetworks)

                grid.Tag = New LocalTagBits(commonObjects, allAccounts, allInstruments, networks)

                Dim dtInstruments As New DataTable
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentCode.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentName.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentType.ToString)
                dtInstruments.Columns.Add(ColumnsInstrument.InstrumentValue.ToString, GetType(Decimal))

                Dim dtNetworks As New DataTable
                dtNetworks.Columns.Add(ColumnsNetwork.InstrumentCode.ToString)
                dtNetworks.Columns.Add(ColumnsNetwork.NetworkId.ToString)
                dtNetworks.Columns.Add(ColumnsNetwork.NetworkName.ToString)
                dtNetworks.Columns.Add(ColumnsNetwork.NetworkValue.ToString, GetType(Decimal))

                Dim dtAccounts As New DataTable
                dtAccounts.Columns.Add(ColumnsAccount.InstrumentCode.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.NetworkId.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountCode.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountName.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountValue.ToString, GetType(Decimal))


                Dim instruments = From asset In assets
                                  Group By asset.InstrumentCode Into InstrumentValue = Sum(asset.Value),
                                      InstrumentTypeCode = Max(asset.InstrumentType.Code)
                                  Order By InstrumentValue Descending

                ' Instruments
                For Each instrument In instruments
                    Dim drInstrument = dtInstruments.NewRow
                    drInstrument(ColumnsInstrument.InstrumentCode.ToString) = instrument.InstrumentCode
                    drInstrument(ColumnsInstrument.InstrumentValue.ToString) = instrument.InstrumentValue
                    drInstrument(ColumnsInstrument.InstrumentType.ToString) = instrument.InstrumentTypeCode
                    dtInstruments.Rows.Add(drInstrument)

                    ' Networks
                    Dim networksUsed = From asset In assets
                                       Where asset.InstrumentCode.Equals(instrument.InstrumentCode, StringComparison.InvariantCultureIgnoreCase)
                                       Group By asset.NetworkId Into NetworkValue = Sum(asset.Value)
                                       Order By NetworkValue Descending
                    For Each networkId In networksUsed
                        Dim drNetwork = dtNetworks.NewRow
                        drNetwork(ColumnsNetwork.InstrumentCode.ToString) = instrument.InstrumentCode
                        drNetwork(ColumnsNetwork.NetworkId.ToString) = networkId.NetworkId
                        drNetwork(ColumnsNetwork.NetworkValue.ToString) = networkId.NetworkValue
                        dtNetworks.Rows.Add(drNetwork)

                        ' Accounts
                        Dim accounts = From asset In assets
                                       Where asset.InstrumentCode.Equals(instrument.InstrumentCode, StringComparison.InvariantCultureIgnoreCase) And
                                           asset.NetworkId.Equals(networkId.NetworkId, StringComparison.InvariantCultureIgnoreCase)
                                       Group By asset.AccountCode Into AccountValue = Sum(asset.Value)
                                       Order By AccountValue Descending
                        For Each account In accounts
                            Dim drAccount = dtAccounts.NewRow
                            drAccount(ColumnsAccount.InstrumentCode.ToString) = instrument.InstrumentCode
                            drAccount(ColumnsAccount.NetworkId.ToString) = networkId.NetworkId
                            drAccount(ColumnsAccount.AccountCode.ToString) = account.AccountCode
                            drAccount(ColumnsAccount.AccountValue.ToString) = account.AccountValue
                            dtAccounts.Rows.Add(drAccount)
                        Next
                    Next
                Next

                Dim ds = New DataSet
                ds.Tables.Add(dtInstruments)
                ds.Tables.Add(dtNetworks)
                ds.Tables.Add(dtAccounts)

                ds.Relations.Add(String.Empty, dtInstruments.Columns(ColumnsInstrument.InstrumentCode.ToString), dtNetworks.Columns(ColumnsNetwork.InstrumentCode.ToString))

                ds.Relations.Add(String.Empty,
                             New DataColumn() {dtNetworks.Columns(ColumnsNetwork.InstrumentCode.ToString), dtNetworks.Columns(ColumnsNetwork.NetworkId.ToString)},
                             New DataColumn() {dtAccounts.Columns(ColumnsAccount.InstrumentCode.ToString), dtAccounts.Columns(ColumnsAccount.NetworkId.ToString)})

                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow

                grid.DataSource = ds
            End Sub

            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    If e.ReInitialize Then
                        Return
                    End If

                    'If e.Row.Band.Index = 0 Then
                    '    e.Row.Expanded = True
                    'End If

                    Select Case e.Row.Band.Index
                        Case 0 ' Instrument
                            Dim sInstrument = e.Row.Cells(ColumnsInstrument.InstrumentCode.ToString).Text
                            If Not String.IsNullOrEmpty(sInstrument) Then
                                Dim instrument = tagBits.AllInstruments.FirstOrDefault(Function(c) c.Code.Equals(sInstrument, StringComparison.InvariantCultureIgnoreCase))
                                If instrument IsNot Nothing Then
                                    e.Row.Cells(ColumnsInstrument.InstrumentName.ToString).Value = instrument.Description
                                End If
                            End If
                            Dim instrumentType = GetInstrumentTypeFromCode(e.Row.Cells(ColumnsInstrument.InstrumentType.ToString).Text, True)
                            e.Row.CellAppearance.ForeColor = CColours.InstrumentType(instrumentType)
                        Case 1 ' Network

                        Case 2 ' Account
                            Dim sAccount = e.Row.Cells(ColumnsAccount.AccountCode.ToString).Text
                            If Not String.IsNullOrEmpty(sAccount) Then
                                Dim account = tagBits.AllAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(sAccount, StringComparison.InvariantCultureIgnoreCase))
                                Dim colour = Color.White
                                If account IsNot Nothing Then
                                    colour = tagBits.Networks.GetColour(account)
                                End If
                                e.Row.CellAppearance.BackColor = colour
                            End If
                    End Select
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .AllowUpdate = DefaultableBoolean.False
                        .RowSelectors = DefaultableBoolean.False
                    End With
                    ' e.Layout.AutoFitColumns = True

                    ' Instrumnents
                    With e.Layout.Bands(0)
                        .ColHeadersVisible = False
                        .Override.RowSpacingBefore = 0
                        .Override.CellAppearance.FontData.Bold = DefaultableBoolean.False
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case ColumnsInstrument.InstrumentCode.ToString
                                col.Header.Caption = "Instrument"
                            Case ColumnsInstrument.InstrumentName.ToString
                                col.Header.Caption = "Instrument Name"
                            Case ColumnsInstrument.InstrumentValue.ToString
                                col.Header.Caption = "Value"
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                    ' Networks Band
                    With e.Layout.Bands(1)
                        .ColHeadersVisible = False
                        .Override.RowSpacingBefore = 5
                        .Override.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(1).Columns
                        Select Case col.Key
                            Case ColumnsNetwork.NetworkId.ToString
                                col.Header.Caption = "Network ID"
                                col.Width = 100
                            Case ColumnsNetwork.NetworkName.ToString
                                col.Header.Caption = "" ' Placeholder only
                                col.Width = 200
                            Case ColumnsNetwork.NetworkValue.ToString
                                col.Header.Caption = "Value"
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                                col.Width = 100
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                    ' Accounts
                    With e.Layout.Bands(2)
                        .ColHeadersVisible = False
                        .Override.RowSpacingBefore = 0
                        .Override.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(2).Columns
                        Select Case col.Key
                            Case ColumnsAccount.AccountCode.ToString
                                col.Header.Caption = "Account Code"
                            Case ColumnsAccount.AccountName.ToString
                                col.Header.Caption = "Name"
                            Case ColumnsAccount.AccountValue.ToString
                                col.Header.Caption = "Value"
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
        End Class

    End Class
End Namespace
