Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid

Namespace Test
    Friend Class FFiatTransfer
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects, preselectFromAccount As String)

            ' This call is required by the designer.
            InitializeComponent()

            m_commonObjects = commonObjects
            ' Add any initialization after the InitializeComponent() call.

            Icon = Icon.FromHandle(My.Resources.arrow_resize.GetHicon)

            DtpTransferDate.Value = Now.Date

            Dim cs = CCoinsAndShares.GetInstance(commonObjects)

            Dim all = cs.AllAccounts

            CDropdowns.AccountsDropdown.SetupDropdown(CmbAccountFrom, all, commonObjects)
            CDropdowns.AccountsDropdown.SetupDropdown(CmbAccountTo, all, commonObjects)

            CmbAccountFrom.Text = preselectFromAccount

            AccountSelected(CmbAccountFrom)
            AccountSelected(CmbAccountTo)

        End Sub

        Private Sub AccountSelected(cmb As UltraCombo)
            Dim sName = String.Empty
            Dim sBalance = String.Empty
            If cmb.Text.Length > 0 Then
                Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)
                Dim all = cs.AllAccounts
                Dim account = all.SingleOrDefault(Function(c) c.AccountCode.Equals(cmb.Text, StringComparison.CurrentCultureIgnoreCase))
                If account IsNot Nothing Then
                    sName = account.AccountName
                    sBalance = account.GetCashBalance.ToString("c2")
                End If
            End If
            Dim lblName = If(cmb Is CmbAccountTo, LblAccountNameTo, LblAccountNameFrom)
            lblName.Text = sName
            Dim lblBalance = If(cmb Is CmbAccountTo, LblBalanceTo, LblBalanceFrom)
            lblBalance.Text = sBalance
        End Sub

        Private Sub CmbAccountFrom_TextChanged(sender As Object, e As EventArgs) Handles CmbAccountFrom.TextChanged, CmbAccountTo.TextChanged
            Try
                Dim cmb = CType(sender, UltraCombo)
                AccountSelected(cmb)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
            Try
                If CmbAccountFrom.Text.Length = 0 Then
                    Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                End If

                Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)
                Dim all = cs.AllAccounts

                Dim account = all.SingleOrDefault(Function(c) c.AccountCode.Equals(CmbAccountFrom.Text, StringComparison.CurrentCulture))
                If account Is Nothing Then
                    Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                End If

                TxtAmount.Text = account.GetCashBalance.ToString("c2")

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles MBtnOk.Click, MBtnCancel.Click
            Try
                If sender Is MBtnOk Then
                    Dim amount As Decimal
                    If CmbAccountFrom.Text.Length = 0 Then
                        Throw New Exception("Select account FROM")
                    ElseIf CmbAccountTo.Text.Length = 0 Then
                        Throw New Exception("Select account TO")
                    ElseIf CmbAccountFrom.Text.Equals(CmbAccountTo.Text, StringComparison.CurrentCultureIgnoreCase) Then
                        Throw New Exception("Cannot transfer to same account")
                    ElseIf TxtAmount.Text.Length = 0 OrElse Not Decimal.TryParse(TxtAmount.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, amount) OrElse amount = 0 Then
                        Throw New Exception("Amount is not valid")
                    End If
                    Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)
                    Dim fromAccount = cs.AllAccounts.SingleOrDefault(Function(c) c.AccountCode.Equals(CmbAccountFrom.Text, StringComparison.CurrentCultureIgnoreCase))
                    If fromAccount Is Nothing Then
                        Throw New Exception("Account FROM is not valid")
                    End If
                    Dim toAccount = cs.AllAccounts.SingleOrDefault(Function(c) c.AccountCode.Equals(CmbAccountTo.Text, StringComparison.CurrentCultureIgnoreCase))
                    If toAccount Is Nothing Then
                        Throw New Exception("Account TO is not valid")
                    End If

                    If MessageBox.Show($"Transfer {amount:c2} from {fromAccount.AccountCode} to {toAccount.AccountCode}?", Text,
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
                        Return
                    End If

                    Cursor = Cursors.WaitCursor

                    cs.ProcessFiatTransfer(fromAccount.AccountCode, toAccount.AccountCode, amount, DtpTransferDate.Value)
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

    End Class
End Namespace
