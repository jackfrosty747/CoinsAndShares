Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Transactions

Namespace Maintenance
    Friend Class FMaintenance
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_accounts As CAccounts
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            Icon = Icon.FromHandle(My.Resources.database.GetHicon)

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_accounts = New CAccounts(commonObjects)

            Dim allAccounts = m_accounts.GetAll

            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccount, allAccounts, commonObjects)
            CDropdowns.CTransactionTypes.SetupNamesDropdown(CmbTransType, commonObjects)

        End Sub

        Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles BtnGo.Click
            Try
                If CmbAccount.Text.Length = 0 OrElse Not m_accounts.GetAll.Any(Function(c) c.AccountCode.Equals(CmbAccount.Text)) Then
                    Throw New WarningException(My.Resources.Error_AccountCodeNotValid)
                End If

                If CmbTransType.Text.Length = 0 Then
                    Throw New WarningException(My.Resources.Error_TransactionTypeNotValid)
                End If

                Dim transactionType As ETransactionType = GetTransactionTypeFromDesc(CmbTransType.Text, False)

                Select Case transactionType
                    Case ETransactionType.Fee, ETransactionType.Mining
                    Case Else
                        Throw New WarningException($"Type {transactionType} not currently supported for merge")
                End Select

                Dim sMsg = $"Transactions will be combined, with one record per instrument per month.  Continue?"

                If MessageBox.Show(sMsg, Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor

                    Dim combiner = New CCombiner(m_commonObjects)

                    combiner.Combine(CmbAccount.Text, transactionType)

                    m_commonObjects.ClearCache()
                    m_commonObjects.RefreshForms()

                    MessageBox.Show("Combined OK", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

    End Class
End Namespace
