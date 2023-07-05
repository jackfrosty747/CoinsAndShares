Imports CoinsAndShares.Accounts.MAccounts

Namespace Test
    Friend Class FAccountNew
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            TxtAccountCode.MaxLength = CDatabase.LENGTH_ACCOUNTS_ACCOUNTCODE

            CDropdowns.AccountTypesDropdown.SetupDropdown(CmbAccountTypeName, commonObjects)

        End Sub

        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    If TxtAccountCode.Text.Length = 0 Then
                        Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                    End If
                    Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)
                    Dim accountType As EAccountType = GetAccountTypeFromName(CmbAccountTypeName.Text, False)
                    cs.CreateAccount(TxtAccountCode.Text, TxtAccountName.Text, accountType)
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class
End Namespace