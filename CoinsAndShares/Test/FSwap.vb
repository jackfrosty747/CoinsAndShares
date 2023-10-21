Namespace Test
    Friend Class FSwap
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_accountCode As String
        Friend Sub New(commonObjects As CCommonObjects, accountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_accountCode = accountCode

            Dim cs = CCoinsAndShares.GetInstance(commonObjects)
            Dim account = cs.AllAccounts.Single(Function(c) c.AccountCode.Equals(accountCode, StringComparison.CurrentCultureIgnoreCase))

            If Not account.AccountType = Accounts.MAccounts.EAccountType.Crypto Then
                Throw New ArgumentOutOfRangeException("Only applicable to crypto accounts")
            End If

            MlblAccountCode.Text = account.AccountCode
            MLblName.Text = account.AccountName
        End Sub
    End Class
End Namespace
