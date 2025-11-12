Imports System.Globalization
Imports CoinsAndShares.Transactions

Namespace Accounts
    Friend Class FAccount : Implements IDataRefresh : Implements ITransactionsForm

        Private ReadOnly m_commonObjects As CCommonObjects

        Friend ReadOnly Property AccountCode As String

        Private m_transactionsLoaded As IEnumerable(Of CTransaction)

        Friend Sub New(commonObjects As CCommonObjects, sAccountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            AccountCode = sAccountCode

            Text = $"Account: {sAccountCode}"

            Icon = Icon.FromHandle(My.Resources.bank.GetHicon)

            LblAccountValueCaption.Text = $"Account Value ({GetLocalCurrencyName()})"

            LoadData()

            LblAdjustments.ForeColor = CColours.TransactionType(ETransactionType.Adjustment)
            LblAdjustmentsCaption.ForeColor = CColours.TransactionType(ETransactionType.Adjustment)

            LblFees.ForeColor = CColours.TransactionType(ETransactionType.Fee)
            LblFeesCaption.ForeColor = CColours.TransactionType(ETransactionType.Fee)

            LblBonus.ForeColor = CColours.TransactionType(ETransactionType.Bonus)
            LblBonusCaption.ForeColor = CColours.TransactionType(ETransactionType.Bonus)
            LblMining.ForeColor = CColours.TransactionType(ETransactionType.Mining)

            LblMiningCaption.ForeColor = CColours.TransactionType(ETransactionType.Mining)

            Dim networks = commonObjects.Networks

            CDropdowns.CTransactionTypes.SetupNamesDropdown(CmbType, m_commonObjects)
            CDropdowns.CNetworksDropdown.SetupDropdown(CmbNetworkId, networks.GetAll, m_commonObjects)

            ' Add at end
            AddHandler TxtAccountName.TextChanged, AddressOf DataChanged
            AddHandler TxtNotes.TextChanged, AddressOf DataChanged
            AddHandler CmbNetworkId.TextChanged, AddressOf DataChanged
            AddHandler TxtCashSavingsRate.TextChanged, AddressOf DataChanged
            AddHandler ChkIncludeOnShortcuts.CheckedChanged, AddressOf DataChanged
            AddHandler ChkNonTaxable.CheckedChanged, AddressOf DataChanged

            SelectChanged(0, 0, 0)

        End Sub

        Private Sub DataChanged(sender As Object, e As EventArgs)
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

        Private Sub LoadData()
            Dim all = m_commonObjects.Accounts.GetAll
            Dim account = all.Where(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If account Is Nothing Then
                Throw New Exception(My.Resources.Error_ItemNotFound)
            End If
            TxtAccountCode.Text = account.AccountCode
            TxtAccountName.Text = account.AccountName
            TxtAccountType.Text = account.AccountType.ToString.Replace("_", " ")
            CmbNetworkId.Text = account.NetworkId
            TxtNotes.Text = account.Notes
            ChkIncludeOnShortcuts.Checked = account.IncludeOnShortcuts
            ChkNonTaxable.Checked = account.NonTaxable
            TxtCashSavingsRate.Text = If(account.CashSavingsRate > 0, account.CashSavingsRate.ToString("0.00"), String.Empty)

            'Dim networksInUse = all.Select(Function(c) c.NetworkId.ToUpper).Distinct.Where(Function(c) Not String.IsNullOrEmpty(c))

            Dim allInstruments = m_commonObjects.Instruments.GetAll
            Dim allCurrencies = m_commonObjects.Currencies.GetAll

            Dim analysis = CTransactions.Analyse(account.Transactions, allInstruments, allCurrencies)

            LblBalance.Text = FormatCurrency(analysis.CurrentValue)

            m_transactionsLoaded = account.Transactions

            FilterTransactions()

            CHoldingsGridHelper.LoadData(GrdHoldings, account.Transactions, m_commonObjects, analysis.Batches, allInstruments)

            LblTransfersIn.Text = FormatCurrency(analysis.TransfersIn)
            LblTransfersOut.Text = FormatCurrency(analysis.TransfersOut)
            LblNetTransfers.Text = FormatCurrency(analysis.NetTransfers)
            LblFees.Text = FormatCurrency(analysis.Fees)
            LblBonus.Text = FormatCurrency(analysis.Bonus)
            LblMining.Text = FormatCurrency(analysis.Mining)
            LblAdjustments.Text = FormatCurrency(analysis.Adjustments)
            LblAccountValue.Text = FormatCurrency(analysis.CurrentValue)
            LblProfitLoss.Text = FormatCurrency(analysis.ProfitLoss)

            Btn212.Visible = ContainsIgnoreCase(account.AccountName, TRADING212_ACCOUNT_CODE)
            BtnNexo.Visible = ContainsIgnoreCase(account.AccountName, NEXO_ACCOUNT_CODE)
            LblCustomImportSep.Visible = ContainsIgnoreCase(account.AccountName, TRADING212_ACCOUNT_CODE) OrElse ContainsIgnoreCase(account.AccountName, NEXO_ACCOUNT_CODE)
            BtnSwapCrypto.Visible = account.AccountType = EAccountType.Crypto
            LblBtnSwapCryptoSep.Visible = account.AccountType = EAccountType.Crypto

            ChangesMade(False)

        End Sub

        Private Sub FilterTransactions()

            Dim transactions = m_transactionsLoaded

            If TxtFilter.Text.Length > 0 Then
                Dim amount As Decimal? = Nothing
                Dim d As Decimal
                If Decimal.TryParse(TxtFilter.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, d) Then
                    amount = d
                End If
                Dim theDate As Date? = Nothing
                Dim dt As Date
                If Date.TryParse(TxtFilter.Text, dt) Then
                    theDate = dt
                End If
                transactions = transactions.Where(Function(c)
                                                      Return _
                                                        ContainsIgnoreCase(c.Description, TxtFilter.Text) OrElse
                                                        ContainsIgnoreCase(c.InstrumentCode, TxtFilter.Text) OrElse
                                                        ContainsIgnoreCase(c.TransactionType.ToString, TxtFilter.Text) OrElse
                                                        (amount.HasValue AndAlso c.Amount = amount.Value) OrElse
                                                        (theDate.HasValue AndAlso theDate.Value.Date = c.TransDate.Date)
                                                  End Function)
            End If

            If CmbType.Text.Length > 0 Then
                Dim transactionType As ETransactionType = GetTransactionTypeFromDesc(CmbType.Text, False)
                transactions = transactions.Where(Function(c) c.TransactionType = transactionType)
            End If

            LblTransCount.Text = $"{transactions.Count:0} transactions"
            LblAmount.Text = $"{transactions.Sum(Function(c) c.Amount)} amount"

            CTransactionsGridHelper.LoadData(GrdTransactions, transactions, m_commonObjects, Me)

        End Sub

        Private Sub SaveChanges()
            Dim existing = m_commonObjects.Accounts.GetAll.Where(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If existing Is Nothing Then
                Throw New Exception(My.Resources.Error_AccountCodeNotValid)
            End If
            Dim sNetworkId = CmbNetworkId.Text.Trim.ToUpper
            If sNetworkId.Length > CDatabase.LENGTH_ACCOUNTS_NETWORKID Then
                sNetworkId = sNetworkId.Substring(0, CDatabase.LENGTH_ACCOUNTS_NETWORKID)
            End If
            Dim cashSavingsRate As Decimal
            If TxtCashSavingsRate.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtCashSavingsRate.Text, cashSavingsRate) OrElse cashSavingsRate < 0 Then
                Throw New Exception("Savings rate not valid")
            End If
            Dim account = New CAccount(AccountCode, TxtAccountName.Text, existing.AccountType, TxtNotes.Text,
                sNetworkId, ChkIncludeOnShortcuts.Checked, ChkNonTaxable.Checked, cashSavingsRate)
            m_commonObjects.Accounts.Update(account)
        End Sub

        Private Sub BtnBuySell_Click(sender As Object, e As EventArgs) Handles BtnBuySell.Click
            Try
                Using frmBuySell As New FBuySell(m_commonObjects, AccountCode)
                    frmBuySell.ShowDialog()
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
            Try
                Dim selectedRows As IEnumerable(Of CTransaction) = CTransactionsGridHelper.GetSelectedTransactions(GrdTransactions)
                If Not selectedRows.Any Then
                    Throw New Exception(My.Resources.Error_NoRowsSelected)
                End If

                Dim transactionsToDelete = m_commonObjects.Transactions.GetAll().Where(Function(c) selectedRows.Select(Function(d) d.Batch).Contains(c.Batch))
                Dim batchesToDelete = transactionsToDelete.Select(Function(c) c.Batch).Distinct

                If MessageBox.Show($"Entire batches will be deleted.  Delete {batchesToDelete.Count} batch{IIf(batchesToDelete.Count > 1, "es", String.Empty)} ({transactionsToDelete.Count} transaction{IIf(transactionsToDelete.Count > 1, "s", vbNullString)})?", Text,
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    m_commonObjects.Transactions.DeleteBatches(batchesToDelete)
                    'LoadData()

                    'If m_frmAccountToRefresh IsNot Nothing Then
                    '    m_frmAccountToRefresh.RefreshAccounts()
                    'End If
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnBonus_Click(sender As Object, e As EventArgs) Handles BtnBonus.Click
            Try
                Cursor = Cursors.WaitCursor
                Using frmAdjust As New FAdjust(m_commonObjects, AccountCode)
                    frmAdjust.ShowDialog()
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Try
                Cursor = Cursors.WaitCursor
                m_commonObjects.ClearCache()
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub RefreshData() Implements IDataRefresh.RefreshData
            LoadData()
        End Sub

        Private Sub TxtFilter_TextChanged(sender As Object, e As EventArgs) Handles TxtFilter.TextChanged
            Try
                'LoadData()
                FilterTransactions()
                Dim txt As TextBox = CType(sender, TextBox)
                txt.BackColor = If(txt.TextLength > 0, Color.Yellow, SystemColors.Window)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub SelectChanged(transactionCount As Integer, totalAmount As Decimal, totalSterling As Decimal) Implements ITransactionsForm.SelectChanged
            Try
                LblSelected.Text = $"Tx: {transactionCount}  Amount: {totalAmount} = {totalSterling:c2}"
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnSwapCrypto_Click(sender As Object, e As EventArgs) Handles BtnSwapCrypto.Click
            Try
                Cursor = Cursors.WaitCursor
                Using frmSwapCrypto As New FSwapCrypto(m_commonObjects, AccountCode)
                    frmSwapCrypto.ShowDialog()
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
            Try
                Dim selectedRows As IEnumerable(Of CTransaction) = CTransactionsGridHelper.GetSelectedTransactions(GrdTransactions)
                If Not selectedRows.Any Then
                    Throw New Exception(My.Resources.Error_NoRowsSelected)
                ElseIf selectedRows.Count > 1 Then
                    Throw New Exception(My.Resources.Error_SelectOneItemOnly)
                End If
                Dim frmTransactionEdit As New FTransactionEdit(m_commonObjects, selectedRows.First)
                frmTransactionEdit.ShowDialog()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub CmbType_TextChanged(sender As Object, e As EventArgs) Handles CmbType.TextChanged
            Try
                Cursor = Cursors.WaitCursor
                'LoadData()
                FilterTransactions()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub ColourCheckedChanged(sender As Object, e As EventArgs)
            Try
                Dim chk As CheckBox = CType(sender, CheckBox)
                If chk.Checked Then
                    Using cd As New ColorDialog
                        cd.CustomColors = m_commonObjects.CustomColors
                        If cd.ShowDialog = DialogResult.OK Then
                            chk.BackColor = cd.Color
                        Else
                            chk.Checked = False
                        End If
                        m_commonObjects.CustomColors = cd.CustomColors
                    End Using
                Else
                    chk.BackColor = SystemColors.ButtonFace
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
            Try
                Cursor = Cursors.WaitCursor
                SaveChanges()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnNexo_Click(sender As Object, e As EventArgs) Handles BtnNexo.Click
            ' Import Interest figures from CSV from Nexo.  The primary key is the first column, "Transaction".  We will use this as the
            ' first part of the description so we don't re-import next time.  All other transfers in and out need to be done manually.
            Const COL_TRANSACTION = "Transaction"
            Const COL_TYPE = "Type"
            Const COL_INPUTCURRENCY = "Input Currency"
            Const COL_INPUTAMOUNT = "Input Amount"
            Const COL_USDEQUIVALENT = "USD Equivalent"
            Const COL_DATETIME = "Date / Time"
            Try
                Try
                    Using ofd = New OpenFileDialog()
                        ofd.Filter = "CSV Files|*.csv"
                        If ofd.ShowDialog = DialogResult.OK Then
                            m_commonObjects.FrmMdi.Cursor = Cursors.WaitCursor
                            Dim dt = CCsv.ReadCsvToDt(ofd.FileName)

                            Dim allAccounts = m_commonObjects.Accounts.GetAll
                            Dim account = allAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))
                            Dim allTrans = account.Transactions

                            Dim currencies = m_commonObjects.Currencies
                            Dim usdCurrency = currencies.GetAll.FirstOrDefault(Function(c) c.CurrencyCode = "USD")
                            If usdCurrency Is Nothing OrElse Not usdCurrency.CurrencyRate.HasValue Then
                                Throw New Exception("No currency rate exists for USD type")
                            End If

                            Dim adjustments As New List(Of CAdjustment)

                            For Each dr As DataRow In dt.Rows
                                Dim sTransId = CDatabase.DbToString(dr(COL_TRANSACTION)) ' Unique ID
                                Dim sTypeDescription = CDatabase.DbToString(dr(COL_TYPE)) ' Trans Type Description, e.g. Interest or Deposit
                                Dim sInputCurrency = CDatabase.DbToString(dr(COL_INPUTCURRENCY)) ' Instrument Code, e.g. BTC, GBP, GBPX
                                Dim sInputAmount = CDatabase.DbToString(dr(COL_INPUTAMOUNT)) ' Amount, e.g. 0.03526500
                                Dim rInputAmount As Decimal
                                If Not Decimal.TryParse(sInputAmount, rInputAmount) Then
                                    Throw New Exception($"Failed to parse {sInputAmount} into a quantity")
                                End If
                                Dim sUsdValue = CDatabase.DbToString(dr(COL_USDEQUIVALENT)) ' E.g. $3.11557866
                                Dim rUsdValue As Decimal
                                If Not Decimal.TryParse(sUsdValue, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"), rUsdValue) Then
                                    Throw New Exception($"Failed to parse {sUsdValue} into a USD value")
                                End If

                                Dim sDateTime = CDatabase.DbToString(dr(COL_DATETIME)) ' 2021-12-02 23:16:26
                                Dim dtDateTime As Date
                                If Not Date.TryParse(sDateTime, dtDateTime) Then
                                    Throw New Exception($"Failed to parse {sDateTime} into a date")
                                End If

                                Dim transactionType As ETransactionType? = Nothing
                                Select Case sTypeDescription.ToUpper
                                    Case "Interest".ToUpper, "FixedTermInterest".ToUpper
                                        transactionType = ETransactionType.Bonus
                                End Select

                                If transactionType.HasValue AndAlso rInputAmount <> 0 Then
                                    Dim rUsdRate = rUsdValue / rInputAmount
                                    ' We only have the USD rate, so we will approximate it by what the USD rate is now
                                    Dim rGbpRate = rUsdRate / usdCurrency.CurrencyRate.Value
                                    Dim cGbpAmount = rUsdValue / usdCurrency.CurrencyRate.Value

                                    Dim sDescription = $"{EDescriptionPresets.Interest} - {sTransId} - {sTypeDescription}"

                                    If Not allTrans.Any(Function(c) ContainsIgnoreCase(c.Description, sTransId)) Then
                                        Dim adjustment = New CAdjustment(transactionType.Value, AccountCode, dtDateTime, EAdjustType.Instrument,
                                                                         sInputCurrency, rInputAmount, rGbpRate, cGbpAmount, sDescription)
                                        adjustments.Add(adjustment)
                                    End If
                                End If
                            Next
                            m_commonObjects.Accounts.ProcessAdjustments(adjustments)
                        End If
                    End Using
                Catch ex As Exception
                    m_commonObjects.Errors.Handle(ex)
                Finally
                    m_commonObjects.FrmMdi.Cursor = Cursors.Default
                End Try

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub Btn212_Click(sender As Object, e As EventArgs) Handles Btn212.Click

            ' Import Interest, Dividend and Cashback and transfers from Trading 212 CSV import
            Const COL_ACTION = "Action"
            Const COL_TIME = "Time"
            Const COL_TICKER = "Ticker"
            Const COL_TOTAL = "Total"
            Const COL_MERCHANTNAME = "Merchant name"
            Const CASH_ACCOUNT = "Cash"

            Try
                Using ofd = New OpenFileDialog()
                    ofd.Filter = "CSV Files|*.csv"
                    If ofd.ShowDialog = DialogResult.OK Then
                        m_commonObjects.FrmMdi.Cursor = Cursors.WaitCursor
                        Dim dt = CCsv.ReadCsvToDt(ofd.FileName)

                        Dim allAccounts = m_commonObjects.Accounts.GetAll
                        Dim account = allAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))
                        Dim allTrans = account.Transactions

                        Dim importAfterDate As Date
                        Dim sMsg As String
                        Try
                            sMsg = $"Enter the date all dividend, cashback, interest and transfers have already been included up to (inclusive).  Only records in the CSV AFTER this date will be imported.  Watch out for partial days at start or end of file.  Stock purchase/sale must be done manually.  Transfers will be made to/from account {CASH_ACCOUNT}"
                            Dim t = allTrans.Where(Function(c) c.TransactionType = ETransactionType.Bonus Or c.TransactionType = ETransactionType.Transfer).OrderBy(Function(c) c.TransDate)
                            Dim sRet = String.Empty
                            If t.Any Then
                                sRet = t.Last.TransDate.ToShortDateString
                            End If
                            sRet = InputBox(sMsg, "Trading 212 Import", sRet)
                            If String.IsNullOrEmpty(sRet) Then
                                Return
                            ElseIf Not Date.TryParse(sRet, importAfterDate) Then
                                Throw New Exception(My.Resources.Error_NotAValidDate)
                            End If
                        Catch ex As Exception
                            Throw
                        End Try

                        m_commonObjects.FrmMdi.Cursor = Cursors.WaitCursor

                        Dim adjustments As New List(Of CAdjustment)
                        Dim transfers As New List(Of Tuple(Of Date, Decimal, String))

                        Dim warnings = New List(Of String)

                        For Each dr As DataRow In dt.Rows
                            Dim sAction = CDatabase.DbToString(dr(COL_ACTION))
                            Dim sDate = CDatabase.DbToString(dr(COL_TIME))
                            Dim sTicker = String.Empty
                            If dt.Columns.Contains(COL_TICKER) Then
                                sTicker = CDatabase.DbToString(dr(COL_TICKER))
                            End If

                            Dim sMerchantName = String.Empty
                            If dt.Columns.Contains(COL_MERCHANTNAME) Then
                                sMerchantName = CDatabase.DbToString(dr(COL_MERCHANTNAME))
                            End If

                            Dim transDate As Date
                            If Not Date.TryParse(sDate, transDate) Then
                                Throw New Exception($"{sDate} is not a valid date")
                            End If

                            transDate = transDate.Date

                            If transDate.Date > importAfterDate.Date Then

                                Dim sTotal = CDatabase.DbToString(dr(COL_TOTAL))
                                Dim cTotal As Decimal
                                If Not Decimal.TryParse(sTotal, cTotal) Then
                                    Throw New Exception($"{sTotal} is not a valid decimal amount for column {COL_TOTAL}")
                                End If

                                Dim sDescription = String.Empty

                                If ContainsIgnoreCase(sAction, "Dividend") Then
                                    sDescription = $"{sTicker} Dividend"
                                ElseIf ContainsIgnoreCase(sAction, "Interest") Then
                                    sDescription = EDescriptionPresets.Interest.ToString
                                ElseIf ContainsIgnoreCase(sAction, "Spending cashback") Then
                                    sDescription = EDescriptionPresets.Cashback.ToString
                                ElseIf ContainsIgnoreCase(sAction, "Deposit") OrElse ContainsIgnoreCase(sAction, "Card debit") Then
                                    Dim sDescriptionSuffix = String.Empty
                                    If sAction.ToUpper.Equals("Card debit", StringComparison.CurrentCultureIgnoreCase) Then
                                        sDescriptionSuffix = "Debit Card Spend"
                                        If Not String.IsNullOrEmpty(sMerchantName) Then
                                            sDescriptionSuffix &= $" - {sMerchantName}"
                                        End If
                                    End If
                                    transfers.Add(New Tuple(Of Date, Decimal, String)(transDate.Date, cTotal, sDescriptionSuffix))
                                Else
                                    warnings.Add($"{sAction} found in file; this must be added manually")
                                End If

                                If Not String.IsNullOrEmpty(sDescription) Then
                                    Dim adjustment = New CAdjustment(ETransactionType.Bonus, AccountCode, transDate, EAdjustType.Money, String.Empty,
                                                                     1, 1, cTotal, sDescription)
                                    adjustments.Add(adjustment)
                                End If
                            End If
                        Next

                        If adjustments.Count = 0 AndAlso transfers.Count = 0 Then
                            Throw New Exception("No transactions to import")
                        End If

                        sMsg = "Import complete."

                        If adjustments.Count > 0 Then
                            m_commonObjects.Accounts.ProcessAdjustments(adjustments)
                            sMsg &= $" {adjustments.Count} adjustments"
                        End If

                        If transfers.Count > 0 Then
                            For Each transfer In transfers
                                Dim t = New CTransfer(CASH_ACCOUNT, AccountCode, transfer.Item2, 0, 0, transfer.Item1.Date, transfer.Item1.Date) With {
                                    .DescriptionSuffix = transfer.Item3
                                }
                                m_commonObjects.Accounts.ProcessTransfer(t)
                            Next
                            sMsg &= $" {transfers.Count} transfers"
                        End If

                        If warnings.Count > 0 Then
                            sMsg &= vbNewLine & vbNewLine
                            For Each warning In warnings
                                sMsg &= $"{vbNewLine}{warning}"
                            Next
                        End If

                        MessageBox.Show(sMsg, Text, MessageBoxButtons.OK, If(warnings.Count > 0, MessageBoxIcon.Warning, MessageBoxIcon.Information))

                    End If
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                m_commonObjects.FrmMdi.Cursor = Cursors.Default
            End Try

        End Sub

        Private Sub BtnReconcile_Click(sender As Object, e As EventArgs) Handles BtnReconcile.Click
            Try
                Dim selectedRows As IEnumerable(Of CTransaction) = CTransactionsGridHelper.GetSelectedTransactions(GrdTransactions)
                If Not selectedRows.Any Then
                    Throw New Exception(My.Resources.Error_NoRowsSelected)
                End If
                Cursor = Cursors.WaitCursor
                Dim transactions = New CTransactions(m_commonObjects)
                transactions.ReconcileUnreconcile(selectedRows.Select(Function(c) c.Id))

                Dim firstVisibleRowId = CTransactionsGridHelper.GetFirstVisibleId(GrdTransactions)

                m_commonObjects.ClearCache()
                LoadData()

                If firstVisibleRowId.HasValue Then
                    CTransactionsGridHelper.SetFirstVisibleId(GrdTransactions, firstVisibleRowId.Value)
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class

End Namespace
