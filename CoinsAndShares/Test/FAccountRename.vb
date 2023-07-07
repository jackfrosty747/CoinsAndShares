Namespace Test
    Friend Class FAccountRename
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects, renameFrom As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Icon = Icon.FromHandle(My.Resources.blue_document_rename.GetHicon)

            m_commonObjects = commonObjects

            MTxtNewAccountCode.MaxLength = CDatabase.LENGTH_ACCOUNTS_ACCOUNTCODE

            Dim cs = CCoinsAndShares.GetInstance(commonObjects)
            Dim account = cs.AllAccounts.First(Function(c) c.AccountCode.Equals(renameFrom))
            MTxtOldAccountCode.Text = account.AccountCode
            MTxtName.Text = account.AccountName
        End Sub

        Private Sub MBtnOkCancel_Click(sender As Object, e As EventArgs) Handles MBtnOk.Click, MBtnCancel.Click
            Try
                If sender Is MBtnOk Then
                    If MTxtNewAccountCode.Text.Length = 0 Then
                        Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                    End If
                    Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)
                    If cs.AllAccounts.Any(Function(c) c.AccountCode.Equals(MTxtNewAccountCode.Text, StringComparison.CurrentCultureIgnoreCase)) Then
                        Throw New Exception(My.Resources.Error_ItemAlreadyExists)
                    End If
                    Cursor = Cursors.WaitCursor
                    cs.RenameAccount(MTxtOldAccountCode.Text, MTxtNewAccountCode.Text)
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

