Namespace Accounts
    Friend Class FNewAccount
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_fOkPressed As Boolean
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            m_commonObjects = commonObjects

            ' Add any initialization after the InitializeComponent() call.
            Icon = Icon.FromHandle(My.Resources._new.GetHicon)

            TxtAccountCode.MaxLength = CDatabase.LENGTH_ACCOUNTS_ACCOUNTCODE

            CDropdowns.CAccountTypeNames.SetupDropdown(CmbAccountTypeName, m_commonObjects)

        End Sub
        Friend ReadOnly Property OkPressed As Boolean
            Get
                Return m_fOkPressed
            End Get
        End Property

        Private Sub BtnOkCancel_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    CreateAccount
                    m_fOkPressed = True
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub CreateAccount()
            If TxtAccountCode.Text.Length = 0 Then
                Throw New Exception(My.Resources.Error_AccountCodeNotValid)
            End If
            Dim accountType As EAccountType = GetAccountTypeFromName(CmbAccountTypeName.Text, False)
            If m_commonObjects.Accounts.GetAll.Where(Function(c) c.AccountCode.Equals(TxtAccountCode.Text, StringComparison.CurrentCultureIgnoreCase)).Any Then
                Throw New Exception(My.Resources.Error_ItemAlreadyExists)
            End If
            m_commonObjects.Accounts.CreateNew(TxtAccountCode.Text, TxtName.Text, accountType)
        End Sub
    End Class
End Namespace
