Imports CoinsAndShares.Accounts.MAccounts

Namespace Test
    Friend Class FAccountNew
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.wand.GetHicon)

            MTxtAccountCode.MaxLength = CDatabase.LENGTH_ACCOUNTS_ACCOUNTCODE

            CMDropdowns.AccountTypesDropdown.Setup(MCmbAccountTypeName)

        End Sub

        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles MBtnOk.Click, MBtnCancel.Click
            Try
                If sender Is MBtnOk Then
                    If MTxtAccountCode.Text.Length = 0 Then
                        Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                    End If
                    Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)
                    Dim accountType As EAccountType = GetAccountTypeFromName(MCmbAccountTypeName.Text, False)
                    cs.CreateAccount(MTxtAccountCode.Text, MTxtAccountName.Text, accountType)
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

    End Class
End Namespace