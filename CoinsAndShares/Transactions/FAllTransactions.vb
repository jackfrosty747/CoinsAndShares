Imports System.Globalization
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Instruments

Namespace Transactions
    Friend Class FAllTransactions : Implements IDataRefresh : Implements ITransactionsForm

        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_transactions As CTransactions
        Private ReadOnly m_accounts As CAccounts
        Private ReadOnly m_instruments As CInstruments
        Private m_allTransactions As IEnumerable(Of CTransaction)
        Private m_allAccounts As IEnumerable(Of CAccount)
        Private m_allInstruments As IEnumerable(Of CInstrument)
        Friend Sub New(commonObjects As CCommonObjects)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            m_transactions = commonObjects.Transactions
            m_accounts = commonObjects.Accounts
            m_instruments = commonObjects.Instruments

            Icon = Icon.FromHandle(My.Resources.binocular.GetHicon)

            OptInstrumentLocalCurrency.Text = GetLocalCurrencyName()

            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccount, m_accounts.GetAll, commonObjects)
            CDropdowns.CInstrumentsDropdown.SetupDropdown(CmbInstrumentCode, m_instruments.GetAll, commonObjects, Nothing)
            CDropdowns.CInstrumentTypeNames.SetupDropdown(CmbInstrumentTypeName, commonObjects)
            CDropdowns.CAccountTypeNames.SetupDropdown(CmbAccountType, m_commonObjects)
            CDropdowns.CTransactionTypes.SetupNamesDropdown(CmbType, m_commonObjects)

            AccountTypeChanged()
            InstrumentTypeChanged()
            EnableDisableDateRange()
            LoadDataToMemory()
            UpdateGrid()

            AddHandler DtpFrom.ValueChanged, AddressOf Filter_ValueChanged
            AddHandler DtpTo.ValueChanged, AddressOf Filter_ValueChanged
            AddHandler TxtDescription.TextChanged, AddressOf Filter_ValueChanged
            AddHandler CmbAccount.TextChanged, AddressOf Filter_ValueChanged
            AddHandler CmbAccountType.TextChanged, AddressOf Filter_ValueChanged
            AddHandler CmbInstrumentCode.TextChanged, AddressOf Filter_ValueChanged
            AddHandler CmbInstrumentTypeName.TextChanged, AddressOf Filter_ValueChanged
            AddHandler OptAccountAll.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler OptAccountSingle.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler OptAccountType.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler OptInstrumentAll.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler OptInstrumentLocalCurrency.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler OptInstrumentType.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler OptInstrumentSingle.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler ChkAllDates.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler CmbType.TextChanged, AddressOf Filter_ValueChanged
            AddHandler ChkTaxable.CheckedChanged, AddressOf Filter_ValueChanged
            AddHandler TxtAccountCodeNameFilter.TextChanged, AddressOf Filter_ValueChanged

            SelectChanged(0, 0, 0)
        End Sub

        Private Sub RefreshData() Implements IDataRefresh.RefreshData
            CDropdowns.CInstrumentsDropdown.SetupDropdown(CmbInstrumentCode, m_instruments.GetAll, m_commonObjects, Nothing)
            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccount, m_accounts.GetAll, m_commonObjects)
            ReloadAndFilterData()
        End Sub

        Private Sub LoadDataToMemory()
            m_allTransactions = m_transactions.GetAll()
            m_allAccounts = m_accounts.GetAll()
            m_allInstruments = m_instruments.GetAll()
        End Sub
        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Try
                Cursor = Cursors.WaitCursor
                ReloadAndFilterData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
        Private Sub ReloadAndFilterData()
            LoadDataToMemory()
            UpdateGrid()
        End Sub
        Private Sub UpdateGrid()
            Dim rowsToShow = GetMatchingRows()
            CTransactionsGridHelper.LoadData(GrdTransactions, rowsToShow, m_commonObjects, Me)

            Dim cTotalAmount = rowsToShow.Sum(Function(c) c.Amount)
            Dim cTotalSterling = rowsToShow.Sum(Function(c) c.Sterling)
            LblTotalAmount.Text = $"{cTotalAmount} = {cTotalSterling:c2}"

        End Sub

        Private Function GetMatchingRows() As IEnumerable(Of CTransaction)

            Dim rowsToShow = m_allTransactions

            If Not ChkAllDates.Checked Then
                rowsToShow = rowsToShow.Where(Function(c) c.TransDate.Date >= DtpFrom.Value.Date And c.TransDate.Date <= DtpTo.Value.Date)
            End If

            If TxtDescription.Text.Length > 0 Then
                rowsToShow = rowsToShow.Where(Function(c) c.Description.ToUpper(CultureInfo.CurrentCulture).Contains(TxtDescription.Text.ToUpper(CultureInfo.CurrentCulture)))
            End If

            If OptAccountSingle.Checked AndAlso CmbAccount.Text.Length > 0 Then
                rowsToShow = rowsToShow.Where(Function(c) c.AccountCode.Equals(CmbAccount.Text, StringComparison.CurrentCultureIgnoreCase))
            ElseIf OptAccountType.Checked AndAlso CmbAccountType.Text.Length > 0 Then
                Dim accountType = GetAccountTypeFromName(CmbAccountType.Text, True)
                Dim accountsOfDesiredType = m_allAccounts.Where(Function(c) c.AccountType = accountType)
                rowsToShow = rowsToShow.Where(Function(c) accountsOfDesiredType.Select(Function(d) d.AccountCode.ToUpper).Contains(c.AccountCode.ToUpper))
            End If

            If TxtAccountCodeNameFilter.Text.Trim.Length > 0 Then
                Dim rowsToShowSoFar = rowsToShow.ToList
                Dim matchingAccounts = m_accounts.GetAll.Where(Function(c) c.AccountCode.ToUpper.Contains(TxtAccountCodeNameFilter.Text.ToUpper.Trim) Or c.AccountName.ToUpper.Contains(TxtAccountCodeNameFilter.Text.ToUpper.Trim)).ToList
                rowsToShow = rowsToShowSoFar.Where(Function(c) matchingAccounts.Any(Function(d) d.AccountCode.Equals(c.AccountCode, StringComparison.CurrentCultureIgnoreCase)))
            End If

            If OptInstrumentLocalCurrency.Checked Then
                rowsToShow = rowsToShow.Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode))
            ElseIf OptInstrumentSingle.Checked AndAlso CmbInstrumentCode.Text.Length > 0 Then
                rowsToShow = rowsToShow.Where(Function(c) c.InstrumentCode.Equals(CmbInstrumentCode.Text, StringComparison.CurrentCultureIgnoreCase))
            ElseIf OptInstrumentType.Checked AndAlso CmbInstrumentTypeName.Text.Length > 0 Then
                Dim instrumentType = GetInstrumentTypeFromName(CmbInstrumentTypeName.Text, True)
                Dim instrumentsOfDesiredType = m_allInstruments.Where(Function(c) c.InstrumentType = instrumentType)
                rowsToShow = rowsToShow.Where(Function(c) instrumentsOfDesiredType.Select(Function(d) d.Code.ToUpper).Contains(c.InstrumentCode.ToUpper))
            End If

            ' Trans Type
            If CmbType.Text.Length > 0 Then
                Dim transactionType As ETransactionType = GetTransactionTypeFromDesc(CmbType.Text, False)
                rowsToShow = rowsToShow.Where(Function(c) c.TransactionType = transactionType)
            End If

            If ChkTaxable.CheckState <> CheckState.Indeterminate Then
                Dim accounts = m_accounts.GetAll.Where(Function(c) c.NonTaxable = (ChkTaxable.CheckState = CheckState.Unchecked))
                rowsToShow = rowsToShow.Where(Function(c) accounts.Any(Function(d) d.AccountCode.Equals(c.AccountCode, StringComparison.CurrentCultureIgnoreCase)))
            End If



            Return rowsToShow

        End Function


        Private Sub Filter_ValueChanged(sender As Object, e As EventArgs)
            Try
                UpdateGrid()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub OptAccount_CheckedChanged(sender As Object, e As EventArgs) Handles OptAccountAll.CheckedChanged,
            OptAccountType.CheckedChanged, OptAccountSingle.CheckedChanged
            Try
                AccountTypeChanged()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub AccountTypeChanged()
            PnlAccountSingle.Enabled = OptAccountSingle.Checked
            PnlAccountType.Enabled = OptAccountType.Checked
        End Sub

        Private Sub OptInstrumentAll_CheckedChanged(sender As Object, e As EventArgs) Handles OptInstrumentAll.CheckedChanged,
            OptInstrumentLocalCurrency.CheckedChanged, OptInstrumentType.CheckedChanged, OptInstrumentSingle.CheckedChanged
            Try
                InstrumentTypeChanged()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Sub InstrumentTypeChanged()
            PnlInstrumentCode.Enabled = OptInstrumentSingle.Checked
            PnlInstrumentType.Enabled = OptInstrumentType.Checked
        End Sub

        Private Sub ChkAllDates_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAllDates.CheckedChanged
            Try
                EnableDisableDateRange()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub EnableDisableDateRange()
            TlpDates.Enabled = Not ChkAllDates.Checked
        End Sub

        Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
            Try
                Dim selected = CTransactionsGridHelper.GetSelectedTransactions(GrdTransactions)
                If selected.Count <> 1 Then
                    Throw New Exception(My.Resources.Error_SelectOneItemOnly)
                End If

                Throw New NotImplementedException("Not implemented yet.  Delete and recreate transactions for now")

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
            Try
                Dim selectedRows As IEnumerable(Of CTransaction) = CTransactionsGridHelper.GetSelectedTransactions(GrdTransactions)
                If Not selectedRows.Any Then
                    Throw New Exception(My.Resources.Error_NoRowsSelected)
                End If

                Dim transactionsToDelete = m_transactions.GetAll().Where(Function(c) selectedRows.Select(Function(d) d.Batch).Contains(c.Batch))
                Dim batchesToDelete = transactionsToDelete.Select(Function(c) c.Batch).Distinct


                If MessageBox.Show($"Entire batches will be deleted.  Delete {batchesToDelete.Count} batch{IIf(batchesToDelete.Count > 1, "es", String.Empty)} ({transactionsToDelete.Count} transaction{IIf(transactionsToDelete.Count > 1, "s", vbNullString)})?",
                                   Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    m_transactions.DeleteBatches(batchesToDelete)
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
            Try
                Using sfd As New SaveFileDialog
                    sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                    If sfd.ShowDialog = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        Dim transactions = GetMatchingRows()
                        CTransactionExporter.ExportCsv(transactions, sfd.FileName)
                        MessageBox.Show($"Transactions saved to {sfd.FileName}", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub SelectChanged(transactionCount As Integer, totalAmount As Decimal, totalSterling As Decimal) Implements ITransactionsForm.SelectChanged
            Try
                LblSelected.Text = $"Count: {transactionCount} Amount: {totalAmount} = {totalSterling:c2}"
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub TxtDescription_TextChanged(sender As Object, e As EventArgs) Handles TxtDescription.TextChanged

        End Sub
    End Class
End Namespace

