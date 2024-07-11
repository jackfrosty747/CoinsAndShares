Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Transactions

Namespace Accounts
    Friend Class FTransferCrypto

        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_allInstruments As IEnumerable(Of CInstrument)
        Private ReadOnly m_allAccounts As IEnumerable(Of CAccount)
        Friend Sub New(commonObjects As CCommonObjects, sDefaultFromAccount As String)

            m_commonObjects = commonObjects
            m_allInstruments = m_commonObjects.Instruments.GetAll()

            InitializeComponent()

            Icon = Icon.FromHandle(My.Resources.arrow_resize.GetHicon)

            m_allAccounts = m_commonObjects.Accounts.GetAll()

            Dim cryptoAccounts = m_allAccounts.Where(Function(c) c.AccountType = EAccountType.Crypto)

            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccountFrom, cryptoAccounts, commonObjects)
            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccountTo, cryptoAccounts, commonObjects)

            CmbAccountFrom.Text = sDefaultFromAccount

            TxtDate.Text = Now.Date.ToShortDateString

            DisplayTransferInstrument(Nothing)

            DisplaySummary()
        End Sub
        Private Class TransferInstrumentReader : Implements IInstrumentReader
            Private ReadOnly m_hostForm As FTransferCrypto
            Private ReadOnly m_commonObjects As CCommonObjects
            Friend Sub New(hostForm As FTransferCrypto, commonObjects As CCommonObjects)
                m_hostForm = hostForm
                m_commonObjects = commonObjects
            End Sub
            Friend Sub ReadInstrument(instrument As CInstrument) Implements IInstrumentReader.ReadInstrument
                Try
                    m_hostForm.DisplayTransferInstrument(instrument)
                    m_hostForm.DisplaySummary()
                Catch ex As Exception
                    m_commonObjects.Errors.Handle(ex)
                End Try
            End Sub
        End Class

        Private Sub DisplayTransferInstrument(instrument As CInstrument)
            LblInstrumentDescription.Text = If(instrument Is Nothing, "< Select Instrument To Transfer >", instrument.Description)
        End Sub


        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Dim transfer = GetTransfer(False)
                    If MessageBox.Show("Process transfer?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        ' Doing these one at a time, otherwise the batch types get mixed
                        Dim transactionBlocks = transfer.GetTransactionBlocks(m_commonObjects, False)
                        For Each transactionBlock In transactionBlocks
                            m_commonObjects.Transactions.AddNewTransactions(transactionBlock)
                        Next
                    Else
                        Return
                    End If
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub TxtTransferQuantity_TextChanged(sender As Object, e As EventArgs) Handles TxtTransferQuantity.TextChanged
            Try
                DisplaySummary()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub TxtFee_TextChanged(sender As Object, e As EventArgs)
            Try
                DisplaySummary()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub DisplaySummary()

            Dim transfer = GetTransfer(True)

            LblSendTotalFiatValue.Text = transfer.GetSendFiatValue(True).ToString("c2")

        End Sub
        Private Class Transfer
            Friend ReadOnly Property TransferDate As Date?
            Friend ReadOnly Property FromAccount As CAccount
            Friend ReadOnly Property ToAccount As CAccount
            Friend ReadOnly Property SendInstrument As CInstrument
            Friend ReadOnly Property SendAmount As Decimal

            Friend Sub New(transferDate As Date?, fromAccount As CAccount, toAccount As CAccount, sendInstrument As CInstrument,
                    sendAmount As Decimal)
                Me.TransferDate = transferDate
                Me.FromAccount = fromAccount
                Me.ToAccount = toAccount
                Me.SendInstrument = sendInstrument
                Me.SendAmount = sendAmount
            End Sub
            Friend Function GetSendFiatValue(fSilent As Boolean) As Decimal
                If SendInstrument Is Nothing Then
                    If fSilent Then
                        Return 0
                    Else
                        Throw New Exception(My.Resources.Error_InstrumentCodeNotValid)
                    End If
                End If
                If SendAmount < 0 AndAlso Not fSilent Then
                    Throw New Exception(My.Resources.Error_AmountNotValid)
                End If
                Return SendAmount * SendInstrument.Rate
            End Function
            Friend Function GetTransactionBlocks(commonObjects As CCommonObjects, fSilent As Boolean) As IEnumerable(Of IEnumerable(Of CTransaction))

                Dim dateToUse = If(TransferDate, Now.Date)

                Dim sFromAccountCode As String
                If FromAccount Is Nothing Then
                    If Not fSilent Then
                        Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                    End If
                    sFromAccountCode = String.Empty
                Else
                    sFromAccountCode = FromAccount.AccountCode
                End If

                Dim sSendInstrumentCode As String
                Dim rSendInstrumentRate As Decimal

                If SendInstrument Is Nothing Then
                    If Not fSilent Then
                        Throw New Exception(My.Resources.Error_InstrumentCodeNotValid)
                    End If
                    sSendInstrumentCode = String.Empty
                Else
                    sSendInstrumentCode = SendInstrument.Code
                    rSendInstrumentRate = SendInstrument.Rate
                End If

                Dim sToAccountCode As String
                If ToAccount Is Nothing Then
                    If Not fSilent Then
                        Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                    End If
                    sToAccountCode = String.Empty
                Else
                    sToAccountCode = ToAccount.AccountCode
                End If

                Dim sDesc = $"Transfer Crypto {sSendInstrumentCode} From {sFromAccountCode} to {sToAccountCode}"

                Dim accounts = commonObjects.Accounts

                Dim transactions As New List(Of List(Of CTransaction))

                Dim cValue = Math.Round(SendAmount * rSendInstrumentRate, 2)

                Try
                    ' Sell
                    Dim sell = New CBuySell(EBuySell.Sell, sSendInstrumentCode, dateToUse, SendAmount, rSendInstrumentRate, cValue, sFromAccountCode)
                    transactions.Add(New List(Of CTransaction)(accounts.GetBuySellTransactions(sell)))

                    ' Transfer FIAT
                    Dim transfer = New CTransfer(sFromAccountCode, sToAccountCode, cValue, 0, 0, dateToUse, dateToUse)
                    transactions.Add(New List(Of CTransaction)(CAccounts.GetTransferTransactions(transfer)))

                    ' Buy
                    Dim buy = New CBuySell(EBuySell.Buy, sSendInstrumentCode, dateToUse, SendAmount, rSendInstrumentRate, cValue, sToAccountCode)
                    transactions.Add(New List(Of CTransaction)(accounts.GetBuySellTransactions(buy)))

                Catch ex As Exception
                    If Not fSilent Then
                        Throw
                    End If
                End Try

                Return transactions
            End Function
        End Class
        Private Function GetTransfer(fSilent As Boolean) As Transfer
            Dim transferDate As Date? = Nothing
            If TxtDate.Text.Length > 0 Then
                Dim d As Date
                If Date.TryParse(TxtDate.Text, d) Then
                    transferDate = d
                End If
            End If
            If Not transferDate.HasValue AndAlso Not fSilent Then
                Throw New Exception(My.Resources.Error_NotAValidDate)
            End If

            Dim fromAccount = m_allAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(CmbAccountFrom.Text, StringComparison.CurrentCultureIgnoreCase))
            If fromAccount Is Nothing AndAlso Not fSilent Then
                Throw New Exception("Select account to send FROM")
            End If

            Dim toAccount = m_allAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(CmbAccountTo.Text, StringComparison.CurrentCultureIgnoreCase))
            If toAccount Is Nothing AndAlso Not fSilent Then
                Throw New Exception("Select account to send TO")
            End If

            If fromAccount IsNot Nothing AndAlso toAccount IsNot Nothing AndAlso fromAccount.AccountCode.Equals(toAccount.AccountCode, StringComparison.CurrentCultureIgnoreCase) AndAlso Not fSilent Then
                Throw New Exception("Cannot send to same account")
            End If

            Dim sendInstrument = m_allInstruments.FirstOrDefault(Function(c) c.Code.Equals(CmbInstrumentToTransfer.Text, StringComparison.CurrentCultureIgnoreCase))
            If sendInstrument Is Nothing AndAlso Not fSilent Then
                Throw New Exception("Select instrument to send")
            End If

            Dim cSendAmountGross As Decimal
            If Not Decimal.TryParse(TxtTransferQuantity.Text, cSendAmountGross) AndAlso Not fSilent Then
                Throw New Exception("Amount to send is not valid")
            End If

            Dim transfer As New Transfer(transferDate, fromAccount, toAccount, sendInstrument, cSendAmountGross)
            Return transfer
        End Function


        Private Sub AccountChanged(sender As Object, e As EventArgs) Handles CmbAccountFrom.TextChanged, CmbAccountTo.TextChanged
            Try
                Cursor = Cursors.WaitCursor
                DisplaySummary()
                LoadCryptos()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
        Private Sub LoadCryptos()
            Dim allCryptoInstruments = m_allInstruments.Where(Function(c) c.InstrumentType = EInstrumentType.Crypto)

            Dim account = m_allAccounts.First(Function(c) c.AccountCode.Equals(CmbAccountFrom.Text, StringComparison.InvariantCultureIgnoreCase))
            Dim allCurrencies = m_commonObjects.Currencies.GetAll
            Dim totalsByInstrument = From t In account.Transactions
                                     Group t By t.InstrumentCode Into Group
                                     Select InstrumentCode, TotalQuantity = Group.Sum(Function(c) c.Amount),
                                         LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allCryptoInstruments, allCurrencies))

            Dim allCryptoInstrumentsWithBalance = allCryptoInstruments.Where(Function(c) totalsByInstrument.Any(Function(b) b.InstrumentCode = c.Code And b.TotalQuantity > 0))

            CDropdowns.CInstrumentsDropdown.SetupDropdown(CmbInstrumentToTransfer, allCryptoInstrumentsWithBalance, m_commonObjects, New TransferInstrumentReader(Me, m_commonObjects))

        End Sub

        Private Sub BtnMax_Click(sender As Object, e As EventArgs) Handles BtnMax.Click
            Try
                Cursor = Cursors.WaitCursor
                Dim account = m_allAccounts.Where(Function(c) c.AccountCode.Equals(CmbAccountFrom.Text, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                If account Is Nothing Then
                    Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                End If
                Dim trans = account.Transactions.Where(Function(c) c.InstrumentCode.Equals(CmbInstrumentToTransfer.Text, StringComparison.CurrentCultureIgnoreCase))

                Dim cHoldings = trans.Sum(Function(c) c.Amount)
                TxtTransferQuantity.Text = cHoldings.ToString
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

    End Class
End Namespace
