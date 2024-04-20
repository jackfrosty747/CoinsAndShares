Imports System.Globalization
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Rates
Imports CoinsAndShares.Transactions
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Instruments
    Friend Class FInstrument : Implements IDataRefresh : Implements ITransactionsForm

        Friend ReadOnly m_commonObjects As CCommonObjects
        Friend ReadOnly m_sInstrumentCode As String

        Private m_fChangesMade As Boolean

        Friend Sub New(commonObjects As CCommonObjects, sInstrumentCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_sInstrumentCode = sInstrumentCode

            Icon = Icon.FromHandle(My.Resources.block__pencil.GetHicon)

            CDropdowns.CCurrenciesDropdown.SetupDropdown(CmbCurrencyCode, commonObjects, commonObjects.Currencies.GetAll())
            CDropdowns.CHedgingGroupsGropdown.SetupDropdown(CmbHedgingGroupCode, commonObjects.Instruments.GetAll())
            CDropdowns.CRateProvidersDropdown.SetupDropdown(CmbRateProvider)

            LoadData()

            AddHandler TxtDescription.TextChanged, AddressOf ScreenUpdated
            AddHandler TxtRate.TextChanged, AddressOf ScreenUpdated
            AddHandler TxtProviderLinkCode.TextChanged, AddressOf ScreenUpdated
            AddHandler TxtNotes.TextChanged, AddressOf ScreenUpdated
            AddHandler CmbHedgingGroupCode.TextChanged, AddressOf ScreenUpdated
            AddHandler CmbRateProvider.TextChanged, AddressOf ScreenUpdated

        End Sub

        Friend Shared Sub Launch(commonObjects As CCommonObjects, sInstrumentCode As String)

            Dim frmInstrument As FInstrument = Nothing
            For Each frm As Form In commonObjects.FrmMdi.MdiChildren
                If TypeOf frm Is FInstrument Then
                    Dim fTest = CType(frm, FInstrument)
                    If fTest.InstrumentCode.Equals(sInstrumentCode, StringComparison.CurrentCultureIgnoreCase) Then
                        frmInstrument = fTest
                        Exit For
                    End If
                End If
            Next
            If frmInstrument Is Nothing Then
                frmInstrument = New FInstrument(commonObjects, sInstrumentCode) With {
                    .MdiParent = commonObjects.FrmMdi
                }
                frmInstrument.Show()
            End If
            frmInstrument.Activate()
        End Sub

        Private Sub ScreenUpdated(sender As Object, e As EventArgs)
            ChangesMade(True)
        End Sub

        Friend ReadOnly Property InstrumentCode As String
            Get
                Return m_sInstrumentCode
            End Get
        End Property

        Private Sub RefreshData() Implements IDataRefresh.RefreshData
            LoadData()
        End Sub

        Private Sub LoadData()
            Dim all = m_commonObjects.Instruments.GetAll
            Dim instrument = all.Where(Function(c) c.Code.Equals(m_sInstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If instrument Is Nothing Then
                Throw New Exception(My.Resources.Error_ItemNotFound)
            End If
            TxtInstrumentCode.Text = instrument.Code
            TxtDescription.Text = instrument.Description
            TxtInstrumentTypeName.Text = instrument.InstrumentType.ToString.Replace("_", " ")
            TxtRate.Text = instrument.Rate.ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
            Dim sUpdated As String = String.Empty
            If instrument.RateUpdated.HasValue Then
                sUpdated = $"Updated {instrument.RateUpdated.Value}"
            End If
            LblUpdated.Text = sUpdated
            TxtProviderLinkCode.Text = instrument.ProviderLinkCode
            CmbCurrencyCode.Text = instrument.CurrencyCode
            TxtNotes.Text = instrument.Notes
            CmbHedgingGroupCode.Text = instrument.HedgingGroupCode
            CmbRateProvider.Text = If(instrument.RateProvider > 0, instrument.RateProvider.ToString, String.Empty)

            Select Case instrument.ProviderMultiplier
                Case 0, 1
                    TxtProviderMultiplier.Text = String.Empty
                Case Else
                    TxtProviderMultiplier.Text = instrument.ProviderMultiplier.ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
            End Select

            LblQuantityHeld.Text = instrument.Transactions.Sum(Function(c) c.Amount).ToString(FORMAT_QUANTITY, CultureInfo.CurrentCulture)

            CTransactionsGridHelper.LoadData(GrdTransactions, instrument.Transactions, m_commonObjects, Me)
            CInstrumentHoldingsGridHelper.LoadData(GrdHoldings, instrument.Transactions, m_commonObjects, instrument.Code)
        End Sub

        Private NotInheritable Class CInstrumentHoldingsGridHelper
            Private Enum Columns
                AccountCode
                AccountName
                AccountType
                AmountHeld
                LocalCurrencyValue
            End Enum
            Friend Shared Sub LoadData(grid As UltraGrid, transactions As IEnumerable(Of CTransaction), commonObjects As CCommonObjects,
                                       sInstrumentCode As String)
                grid.Tag = New TagBits(commonObjects)
                ' Just to make sure we have been given only the transactions for one instrument
                transactions = transactions.Where(Function(c) c.InstrumentCode.Equals(sInstrumentCode, StringComparison.InvariantCultureIgnoreCase))

                Dim instruments = New CInstruments(commonObjects)
                Dim allInstruments = instruments.GetAll
                Dim currencies = commonObjects.Currencies
                Dim allCurrencies = currencies.GetAll

                Dim totalsByAccount = From t In transactions
                                      Group t By t.AccountCode Into Group
                                      Select
                                             AccountCode,
                                             TotalQuantity = Group.Sum(Function(c) c.Amount),
                                             LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))

                Dim accounts = commonObjects.Accounts
                Dim allAccounts = accounts.GetAll

                Dim dt = GetBlankDt()

                For Each a In totalsByAccount.Where(Function(c) c.TotalQuantity <> 0)
                    Dim dr = dt.NewRow
                    dr(Columns.AccountCode.ToString) = a.AccountCode

                    Dim account = allAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(a.AccountCode, StringComparison.InvariantCultureIgnoreCase))
                    If account IsNot Nothing Then
                        dr(Columns.AccountName.ToString) = account.AccountName
                        dr(Columns.AccountType.ToString) = account.AccountType.Code
                    End If

                    dr(Columns.AmountHeld.ToString) = a.TotalQuantity
                    dr(Columns.LocalCurrencyValue.ToString) = a.LocalCurrencyValue

                    dt.Rows.Add(dr)
                Next

                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                RemoveHandler grid.ClickCellButton, AddressOf ClickCellButton
                AddHandler grid.ClickCellButton, AddressOf ClickCellButton

                grid.DataSource = dt

            End Sub

            Private Shared Sub ClickCellButton(sender As Object, e As CellEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    Select Case e.Cell.Column.Key
                        Case Columns.AccountCode.ToString
                            Dim sAccountCode = e.Cell.Row.Cells(Columns.AccountCode.ToString).Text

                            Dim frmAccount As FAccount = Nothing
                            For Each frm As Form In tagBits.CommonObjects.FrmMdi.MdiChildren
                                If TypeOf frm Is FAccount Then
                                    Dim fTest = CType(frm, FAccount)
                                    If fTest.AccountCode.Equals(sAccountCode, StringComparison.CurrentCultureIgnoreCase) Then
                                        frmAccount = fTest
                                        Exit For
                                    End If
                                End If
                            Next
                            If frmAccount Is Nothing Then
                                frmAccount = New FAccount(tagBits.CommonObjects, sAccountCode) With {
                                    .MdiParent = tagBits.CommonObjects.FrmMdi
                                }
                                frmAccount.Show()
                            End If
                            frmAccount.Activate()
                    End Select

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    Dim sAccountTypeCode = e.Row.Cells(Columns.AccountType.ToString).Text

                    Dim accountType = GetAccountTypeFromCode(sAccountTypeCode, True)
                    e.Row.Cells(Columns.AccountCode.ToString).Appearance.ForeColor = CColours.AccountType(accountType)
                    e.Row.Cells(Columns.AccountName.ToString).Appearance.ForeColor = CColours.AccountType(accountType)

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
                    e.Layout.AutoFitColumns = True
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.AccountCode.ToString
                                col.Width = 100
                                col.Header.Caption = "Account Code"
                                col.Style = ColumnStyle.Button
                                col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.OnMouseEnter
                            Case Columns.AccountName.ToString
                                col.Width = 250
                                col.Header.Caption = "Name"
                            Case Columns.AmountHeld.ToString
                                col.Width = 100
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Header.Caption = "Amount Held"
                            Case Columns.LocalCurrencyValue.ToString
                                col.Width = 100
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Header.Caption = "Local Value"
                                col.Format = "c2"
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                    e.Layout.Bands(0).Summaries.Clear()
                    Dim ss = e.Layout.Bands(0).Summaries.Add(SummaryType.Sum, e.Layout.Bands(0).Columns(Columns.AmountHeld.ToString))
                    ss.Appearance.TextHAlign = HAlign.Right
                    ss.DisplayFormat = "{0:###,###,###,##0.###,###,###}"
                    ss = e.Layout.Bands(0).Summaries.Add(SummaryType.Sum, e.Layout.Bands(0).Columns(Columns.LocalCurrencyValue.ToString))
                    ss.Appearance.TextHAlign = HAlign.Right
                    ss.DisplayFormat = "{0:c2}"

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Function GetBlankDt() As DataTable
                Dim dt = New DataTable
                dt.Columns.Add(Columns.AccountCode.ToString)
                dt.Columns.Add(Columns.AccountName.ToString)
                dt.Columns.Add(Columns.AccountType.ToString)
                dt.Columns.Add(Columns.AmountHeld.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.LocalCurrencyValue.ToString, GetType(Decimal))
                Return dt
            End Function
        End Class

        Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
            Try
                If sender Is BtnSave Then
                    SaveChanges()
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Sub SaveChanges()
            Dim instrumentType As EInstrumentType = GetInstrumentTypeFromName(TxtInstrumentTypeName.Text, False)
            Dim rRate As Decimal
            If Not Decimal.TryParse(TxtRate.Text, rRate) Then
                Throw New Exception("Rate is not a valid number")
            End If
            If Not m_commonObjects.Currencies.GetAll.Where(Function(c) c.CurrencyCode.Equals(CmbCurrencyCode.Text, StringComparison.CurrentCultureIgnoreCase)).Any Then
                Throw New Exception(My.Resources.Error_CurrencyCodeNotValid)
            End If
            Dim rProviderMultiplier As Decimal
            If TxtProviderMultiplier.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtProviderMultiplier.Text, rProviderMultiplier) Then
                Throw New Exception("Provider multiplier is not valid")
            End If
            Dim iRateProvider As Integer = 0
            If CmbRateProvider.Text.Length > 0 Then
                If Not Integer.TryParse(CmbRateProvider.Text, iRateProvider) Then
                    Throw New Exception("Rate provider should be a number")
                End If
                If Not [Enum].IsDefined(GetType(ERateProvider), iRateProvider) Then
                    Throw New Exception("Rate provider code not valid")
                End If
            End If
            Dim instrument = New CInstrument(m_sInstrumentCode, instrumentType, TxtDescription.Text, rRate, Nothing,
                                             TxtProviderLinkCode.Text, CmbCurrencyCode.Text, rProviderMultiplier, TxtNotes.Text,
                                             CmbHedgingGroupCode.Text, iRateProvider)
            m_commonObjects.Instruments.Update(instrument)
            ChangesMade(False)
        End Sub
        Private Sub ChangesMade(f As Boolean)
            m_fChangesMade = f
            If m_fChangesMade Then
                BtnSave.BackColor = Color.Red
                BtnSave.ForeColor = Color.Yellow
            Else
                BtnSave.BackColor = SystemColors.ButtonFace
                BtnSave.ForeColor = SystemColors.ControlText
            End If
        End Sub
        Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
            Try
                Dim selectedRows As IEnumerable(Of CTransaction) = CTransactionsGridHelper.GetSelectedTransactions(GrdTransactions)
                If Not selectedRows.Any Then
                    Throw New Exception(My.Resources.Error_NoRowsSelected)
                End If

                Dim transactionsToDelete = m_commonObjects.Transactions.GetAll().Where(Function(c) selectedRows.Select(Function(d) d.Batch).Contains(c.Batch))
                Dim batchesToDelete = transactionsToDelete.Select(Function(c) c.Batch).Distinct


                If MessageBox.Show($"Entire batches will be deleted.  Delete {batchesToDelete.Count} batch{IIf(batchesToDelete.Count > 1, "es", String.Empty)} ({transactionsToDelete.Count} transaction{IIf(transactionsToDelete.Count > 1, "s", vbNullString)})?",
                                   Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    m_commonObjects.Transactions.DeleteBatches(batchesToDelete)
                    LoadData()
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
            Try
                Dim selected = CTransactionsGridHelper.GetSelectedTransactions(GrdTransactions)
                If selected.Count <> 1 Then
                    Throw New Exception(My.Resources.Error_SelectOneItemOnly)
                End If
                Dim frmTransactionEdit As New FTransactionEdit(m_commonObjects, selected.First)
                frmTransactionEdit.ShowDialog()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnSetLinkSymbol_Click(sender As Object, e As EventArgs) Handles BtnSelectLinkSymbol.Click
            Try
                Dim instrument = m_commonObjects.Instruments.GetAll().Where(Function(c) c.Code.Equals(m_sInstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                If instrument Is Nothing Then
                    Throw New Exception(My.Resources.Error_ItemNotFound)
                End If

                Dim rateProvider As IRateProvider = GetRateProviderToUse(instrument.InstrumentType)

                Using frmSelectProviderLinkCode As New FSelectProviderLinkCode(m_commonObjects, rateProvider, TxtDescription.Text)
                    Cursor = Cursors.WaitCursor
                    frmSelectProviderLinkCode.ShowDialog()
                    If frmSelectProviderLinkCode.OkPressed Then
                        TxtProviderLinkCode.Text = frmSelectProviderLinkCode.ProviderLinkCode
                    End If
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub FInstrument_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            Try
                If m_fChangesMade Then
                    If MessageBox.Show("Save changes?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                        SaveChanges()
                    End If
                End If
            Catch ex As Exception
                e.Cancel = True
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnGetRate_Click(sender As Object, e As EventArgs) Handles BtnGetRate.Click
            Try
                If m_fChangesMade Then
                    Throw New Exception("Save changes first")
                End If

                Cursor = Cursors.WaitCursor

                Dim i = m_commonObjects.Instruments.GetAll.Where(Function(c) c.Code.Equals(m_sInstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault

                If String.IsNullOrEmpty(i.ProviderLinkCode) Then
                    Throw New Exception("No link code entered")
                End If

                Dim rateProvider = GetRateProviderToUse(i.InstrumentType)

                Dim newRates = rateProvider.GetNewRates(New List(Of String)({i.ProviderLinkCode}))
                If newRates Is Nothing OrElse Not newRates.Any Then
                    Throw New Exception($"Failed to get rate for link code {i.ProviderLinkCode}")
                End If

                i.Rate = newRates.First.Rate
                Select Case i.ProviderMultiplier
                    Case 0, 1
                    Case Else
                        i.Rate *= i.ProviderMultiplier
                End Select

                m_commonObjects.Instruments.Update(i)

                ChangesMade(False)

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Friend Sub SelectChanged(transactionCount As Integer, totalAmount As Decimal, totalSterling As Decimal) Implements ITransactionsForm.SelectChanged
            ' Not using
        End Sub

        Private Sub GrdHoldings_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles GrdHoldings.InitializeLayout

        End Sub
    End Class
End Namespace
