Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Test
    Friend Class FAccount : Implements IDataRefresh
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend ReadOnly AccountCode As String

        Friend Sub New(commonObjects As CCommonObjects, accountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            Me.AccountCode = accountCode

            Text = $"ACCOUNT: {accountCode}"

            Icon = Icon.FromHandle(My.Resources.bank.GetHicon)

            Dim coinsAndShares = CCoinsAndShares.GetInstance(m_commonObjects)

            CDropdowns.CNetworksDropdown.SetupDropdown(CmbNetworkId, coinsAndShares.AllNetworks, m_commonObjects)

            LoadDataEntryData()
            LoadTransactionData()

            AddHandler TxtAccountName.TextChanged, AddressOf DataEntryChanged
            AddHandler CmbNetworkId.TextChanged, AddressOf DataEntryChanged
            AddHandler TxtNotes.TextChanged, AddressOf DataEntryChanged
            AddHandler ChkIncludeOnShortcuts.CheckedChanged, AddressOf DataEntryChanged

        End Sub

        Private Sub DataEntryChanged(sender As Object, e As EventArgs)
            ChangesMade(True)
        End Sub

        Private Sub ChangesMade(f As Boolean)
            If f Then
                BtnSave.BackColor = Color.Red
                BtnSave.ForeColor = Color.Yellow
            Else
                BtnSave.BackColor = SystemColors.ButtonFace
                BtnSave.ForeColor = SystemColors.ControlText
            End If
        End Sub

        Private Sub LoadDataEntryData()

            Dim coinsAndShares = CCoinsAndShares.GetInstance(m_commonObjects)

            Dim account = coinsAndShares.AllAccounts.SingleOrDefault(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))

            ForeColor = CColours.AccountType(account.AccountType)

            TxtAccountCode.Text = account.AccountCode
            TxtAccountType.Text = account.AccountType.ToString.Replace("_", " ")
            TxtAccountName.Text = account.AccountName
            CmbNetworkId.Text = account.NetworkId
            TxtNotes.Text = account.Notes
            ChkIncludeOnShortcuts.Checked = account.IncludeOnShortcuts

        End Sub

        Private Sub LoadTransactionData()
            ' Load the display data (transactions, holdings) not the editable data because that might be changed and not saved yet

            Dim coinsAndShares = CCoinsAndShares.GetInstance(m_commonObjects)
            Dim account = coinsAndShares.AllAccounts.SingleOrDefault(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))

            ' Load transactions
            GrdTransactions.DataSource = account.Transactions.OrderByDescending(Function(c) c.Id).ToList

            HoldingsGrid.LoadData(GrdHoldings, account, m_commonObjects)

            ChangesMade(False)
        End Sub

        Private Class HoldingsGrid
            Private Enum Columns
                InstrumentCode
                Description
                QuantityHeld
                CurrentValue
                Cost
                Pl
            End Enum
            Friend Shared Sub LoadData(grid As UltraGrid, account As CAccount, commonObjects As CCommonObjects)
                grid.Tag = New TagBits(commonObjects)
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                grid.DataSource = GetDatatable(account, commonObjects)
            End Sub

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override()
                        .AllowAddNew = AllowAddNew.No
                        .AllowDelete = DefaultableBoolean.False
                        .AllowUpdate = DefaultableBoolean.False
                        .RowSelectors = DefaultableBoolean.False
                        .CellClickAction = CellClickAction.RowSelect
                        .SelectTypeRow = SelectType.None
                        .HeaderClickAction = HeaderClickAction.SortMulti
                    End With
                    e.Layout.AutoFitColumns = True
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.InstrumentCode.ToString
                                col.Header.Caption = "Instrument"
                                col.Width = 50
                            Case Columns.Description.ToString
                                col.Header.Caption = "Description"
                                col.Width = 85
                            Case Columns.QuantityHeld.ToString
                                col.Header.Caption = "Qty"
                                col.Width = 50
                                col.Format = FORMAT_QUANTITY
                            Case Columns.CurrentValue.ToString
                                col.Header.Caption = "Current"
                                col.Width = 50
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                            Case Columns.Cost.ToString
                                col.Header.Caption = "Cost"
                                col.Width = 50
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                            Case Columns.Pl.ToString
                                col.Header.Caption = "P/L"
                                col.Width = 50
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

            Private Shared Function GetDatatable(account As CAccount, commonObjects As CCommonObjects) As DataTable

                Dim coinsAndShares = CCoinsAndShares.GetInstance(commonObjects)
                Dim instruments = coinsAndShares.AllInstruments
                Dim instrumentDict = instruments.ToDictionary(Function(i) i.InstrumentCode)

                Dim transactions = From t In account.Transactions
                                   Select Batch = t.Batch,
                                       ID = t.Id,
                                       InstrumentCode = t.InstrumentCode,
                                       Amount = t.Amount,
                                       CashValue = If(String.IsNullOrEmpty(t.InstrumentCode), t.Amount, 0),
                                       InstrumentAmount = If(String.IsNullOrEmpty(t.InstrumentCode), 0, t.Amount)
                                   Order By ID

                Dim totalsByBatch = From t In transactions
                                    Group t By t.Batch Into Group
                                    Select Batch,
                                        InstrumentCode = Group.Max(Function(c) c.InstrumentCode),
                                        TotalCashValue = Group.Sum(Function(c) c.CashValue),
                                        TotalInstrumentAmount = Group.Sum(Function(c) c.InstrumentAmount)

                Dim holdingsByInstrument = From t In totalsByBatch
                                           Group t By t.InstrumentCode Into Group
                                           Order By Not String.IsNullOrEmpty(InstrumentCode), Group.Sum(Function(c) c.TotalCashValue)
                                           Select InstrumentCode,
                                               TotalCashValue = Group.Sum(Function(c) c.TotalCashValue),
                                               TotalInstrumentAmount = Group.Sum(Function(c) c.TotalInstrumentAmount)


                Dim dt = New DataTable
                dt.Columns.Add(Columns.InstrumentCode.ToString)
                dt.Columns.Add(Columns.Description.ToString)
                dt.Columns.Add(Columns.QuantityHeld.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.CurrentValue.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Cost.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Pl.ToString, GetType(Decimal))

                Dim col = New DataColumn
                col.ColumnName = "HasCode"
                col.DataType = GetType(Boolean)
                col.Expression = $"{Columns.InstrumentCode} IS NULL Or {Columns.InstrumentCode} = ''"
                dt.Columns.Add(col)

                ' TODO
                ' value on  cash row is wrong
                '  also test foreign currency ones, like AAPL

                For Each i In holdingsByInstrument
                    Dim instrument As CInstrument = Nothing

                    Dim dr = dt.NewRow()
                    dr(Columns.InstrumentCode.ToString) = i.InstrumentCode
                    If instrumentDict.TryGetValue(i.InstrumentCode, instrument) Then
                        dr(Columns.Description.ToString) = instrument.Description
                        Dim cCurrentValue = Math.Round(i.TotalInstrumentAmount * instrument.Rate, 2, MidpointRounding.AwayFromZero)
                        dr(Columns.CurrentValue.ToString) = cCurrentValue
                        dr(Columns.Pl.ToString) = Math.Round(cCurrentValue + i.TotalCashValue, 2, MidpointRounding.AwayFromZero)
                    Else
                        dr(Columns.Description.ToString) = If(String.IsNullOrEmpty(i.InstrumentCode), "CASH", "Unknown")
                    End If

                        dr(Columns.QuantityHeld.ToString) = i.TotalInstrumentAmount
                    dr(Columns.Cost.ToString) = Math.Round(i.TotalCashValue, 2, MidpointRounding.AwayFromZero)
                    dt.Rows.Add(dr)
                Next

                dt.DefaultView.Sort = $"HasCode DESC, {Columns.CurrentValue} DESC"
                Return dt

            End Function
        End Class

        Public Sub RefreshData() Implements IDataRefresh.RefreshData
            ' Load the display data (transactions, holdings) not the editable data because that might be changed and not saved yet
            LoadTransactionData()
        End Sub

        Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
            Try
                Cursor = Cursors.WaitCursor

                Dim coinsAndShares = CCoinsAndShares.GetInstance(m_commonObjects)

                Dim account = coinsAndShares.AllAccounts.Single(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))

                ' Save header
                account.AccountName = TxtAccountName.Text
                account.Notes = TxtNotes.Text
                account.NetworkId = CmbNetworkId.Text
                account.IncludeOnShortcuts = ChkIncludeOnShortcuts.Checked

                coinsAndShares.UpdateAccount(account)

                ' Load the data entry part.  The rest will refresh by the save function
                LoadDataEntryData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub GrdTransactions_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdTransactions.InitializeLayout
            Try
                GridDefaults(e.Layout)
                e.Layout.Appearances.Clear()
                For Each transactionType As ETransactionType In [Enum].GetValues(GetType(ETransactionType))
                    With e.Layout.Appearances.Add(transactionType.ToString)
                        .ForeColor = CColours.TransactionType(transactionType)
                    End With
                Next
                With e.Layout.Override
                    .AllowAddNew = AllowAddNew.No
                    .AllowDelete = DefaultableBoolean.False
                    .AllowUpdate = DefaultableBoolean.False
                    .RowSelectors = DefaultableBoolean.False
                    .CellClickAction = CellClickAction.RowSelect
                    .HeaderClickAction = HeaderClickAction.SortMulti
                End With
                e.Layout.AutoFitColumns = True
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case NameOf(CTransaction.Id)
                            col.MinWidth = 45
                            col.MaxWidth = 45
                            col.Header.Caption = "ID"
                        Case NameOf(CTransaction.Batch)
                            col.MinWidth = 45
                            col.MaxWidth = 45
                            col.Header.Caption = "Batch"
                        Case NameOf(CTransaction.TransactionDate)
                            col.MinWidth = 65
                            col.MaxWidth = 65
                            col.Header.Caption = "Date"
                        Case NameOf(CTransaction.TransactionType)
                            col.Width = 100
                            col.Header.Caption = "Type"
                        Case NameOf(CTransaction.InstrumentCode)
                            col.Width = 100
                            col.Header.Caption = "Instrument"
                        Case NameOf(CTransaction.Rate)
                            col.Width = 60
                            col.Header.Caption = "Rate"
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Format = FORMAT_RATE
                        Case NameOf(CTransaction.AmountDisplay)
                            col.Width = 60
                            col.Header.Caption = "Amount"
                            col.CellAppearance.TextHAlign = HAlign.Right
                        Case NameOf(CTransaction.Sterling)
                            col.Width = 60
                            col.Header.Caption = "Sterling"
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Format = "c2"
                        Case NameOf(CTransaction.Description)
                            col.Width = 200
                            col.Header.Caption = "Description"
                        Case NameOf(CTransaction.ExchangeRate)
                            col.Header.Caption = "Xch/R"
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Width = 60
                        Case Else
                            col.Hidden = True
                    End Select
                Next
                With e.Layout.Bands(0)
                    .Columns(NameOf(CTransaction.ExchangeRate)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.Description)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.Sterling)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.AmountDisplay)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.Rate)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.InstrumentCode)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.TransactionType)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.TransactionDate)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.Batch)).Header.VisiblePosition = 0
                    .Columns(NameOf(CTransaction.Id)).Header.VisiblePosition = 0
                End With
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub GrdTransactions_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles GrdTransactions.InitializeRow
            Try
                If Not e.ReInitialize Then
                    ' Colour
                    e.Row.Appearance = e.Row.Band.Layout.Appearances(e.Row.Cells(NameOf(CTransaction.TransactionType)).Text)
                    ' Spacing
                    If e.Row.Index < CType(sender, UltraGrid).Rows.Count - 1 Then
                        Dim currentBatch = CLng(e.Row.Cells(NameOf(CTransaction.Batch)).Value)
                        Dim nextRow As UltraGridRow = CType(sender, UltraGrid).Rows(e.Row.Index + 1)
                        Dim nextBatch = CLng(nextRow.Cells(NameOf(CTransaction.Batch)).Value)
                        e.Row.RowSpacingAfter = If(currentBatch.Equals(nextBatch), 0, 2)
                    End If
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class

End Namespace
