Namespace Accounts
    Friend Class FTransferFiat
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_allAccounts As IEnumerable(Of CAccount)
        Private m_fOkPressed As Boolean
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.arrow_resize.GetHicon)

            m_allAccounts = m_commonObjects.Accounts.GetAll

            m_allAccounts = m_allAccounts.OrderByDescending(Function(c) c.AccountCode.Equals("BANK", StringComparison.CurrentCultureIgnoreCase)).ThenBy(Function(c) c.AccountCode)

            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccountFrom, m_allAccounts, commonObjects)
            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccountTo, m_allAccounts, commonObjects)

            AmountTextChanged(Nothing, Nothing)
            SameDateChecked()

            DtpSendDateTime.Value = Now
            DtpReceiveDateTime.Value = Now
            ChkSameAsSendingDate.Checked = True

            AddHandler TxtAmount.TextChanged, AddressOf AmountTextChanged
            AddHandler TxtSendFee.TextChanged, AddressOf AmountTextChanged
            AddHandler TxtReceiveFee.TextChanged, AddressOf AmountTextChanged
        End Sub

        Private Sub AmountTextChanged(sender As Object, e As EventArgs)
            Dim transfer = GetTransferFromScreen(True)
            LblIntermediateAmount.Text = FormatCurrency(transfer.IntermediateAmount())
            LblReceiveCredit.Text = FormatCurrency(transfer.ReceiveCredit())
        End Sub

        Private Function GetTransferFromScreen(fSilent As Boolean) As CTransfer
            Dim cSendDebit As Decimal = GetCurrencyAmount(LblDebitAmountCaption.Text, TxtAmount.Text, fSilent)
            Dim cSendFee As Decimal = GetCurrencyAmount(LblSendingFeeLabel.Text, TxtSendFee.Text, fSilent)
            Dim cReceiveFee As Decimal = GetCurrencyAmount(TxtReceivingFeeLabel.Text, TxtReceiveFee.Text, fSilent)

            Dim receiveDate As Date
            If ChkSameAsSendingDate.Checked Then
                receiveDate = DtpSendDateTime.Value
            Else
                receiveDate = DtpReceiveDateTime.Value
            End If

            Dim transfer As New CTransfer(CmbAccountFrom.Text, CmbAccountTo.Text, cSendDebit, cSendFee, cReceiveFee,
                                          DtpSendDateTime.Value, receiveDate)
            Return transfer
        End Function

        Friend ReadOnly Property OkPressed As Boolean
            Get
                Return m_fOkPressed
            End Get
        End Property

        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Dim transfer = GetTransferFromScreen(False)
                    If String.IsNullOrEmpty(transfer.AccountCodeFrom) OrElse String.IsNullOrEmpty(transfer.AccountCodeTo) Then
                        Throw New Exception("Enter account FROM and TO")
                    End If
                    Dim all = m_commonObjects.Accounts.GetAll
                    If Not all.Where(Function(c) c.AccountCode.Equals(transfer.AccountCodeFrom, StringComparison.CurrentCultureIgnoreCase)).Any Then
                        Throw New Exception("Account FROM not valid")
                    ElseIf Not all.Where(Function(c) c.AccountCode.Equals(transfer.AccountCodeTo, StringComparison.CurrentCultureIgnoreCase)).Any Then
                        Throw New Exception("Account TO not valid")
                    ElseIf transfer.AccountCodeFrom.Equals(transfer.AccountCodeTo, StringComparison.CurrentCultureIgnoreCase) Then
                        Throw New Exception("Account FROM and TO cannot be the same")
                    End If
                    If Not MessageBox.Show($"Process transfer of {FormatCurrency(transfer.SendDebit)}?", Text,
                                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                        Return
                    End If
                    m_commonObjects.Accounts.ProcessTransfer(transfer)
                    m_fOkPressed = True
                End If

                Close()

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub DtpSendDateTime_ValueChanged(sender As Object, e As EventArgs) Handles DtpSendDateTime.ValueChanged
            Try
                If DtpSendDateTime.Value > DtpReceiveDateTime.Value Then
                    DtpReceiveDateTime.Value = DtpSendDateTime.Value
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub DtpReceiveDateTime_ValueChanged(sender As Object, e As EventArgs) Handles DtpReceiveDateTime.ValueChanged
            Try
                If DtpSendDateTime.Value > DtpReceiveDateTime.Value Then
                    DtpSendDateTime.Value = DtpReceiveDateTime.Value
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub ChkSameAsSendingDate_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSameAsSendingDate.CheckedChanged
            Try
                SameDateChecked
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Sub SameDateChecked()
            DtpReceiveDateTime.Enabled = Not ChkSameAsSendingDate.Checked
        End Sub

        Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
            Try
                Cursor = Cursors.WaitCursor
                'Dim all = m_accounts.GetAll()

                Dim cBalance As Decimal = 0
                Dim account = m_allAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(CmbAccountFrom.Text, StringComparison.InvariantCultureIgnoreCase))
                If account IsNot Nothing Then
                    Dim allInstruments = m_commonObjects.Instruments.GetAll()
                    Dim allCurrencies = m_commonObjects.Currencies.GetAll()
                    cBalance = account.GetLocalCashBalance(allInstruments, allCurrencies)
                    TxtAmount.Text = cBalance.ToString("0.00")
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
