Friend Class FAbout
    Private ReadOnly m_commonObjects As CCommonObjects
    Friend Sub New(commonObjects As CCommonObjects)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Icon = Icon.FromHandle(My.Resources.information.GetHicon)

        Text = "About " & Application.ProductName.ToUpper
        Dim buildDateTime = GetBuildDateTime()
        Dim sBuild = "UNKNOWN"
        If buildDateTime.HasValue Then
            sBuild = buildDateTime.Value.ToShortDateString & " " & buildDateTime.Value.ToShortTimeString
        End If

        LblName.Text = Application.ProductName.ToUpper & vbNewLine & "BUILD: " & sBuild
        LlUrl.Text = APP_URL

        Dim sOut = Text

        sOut &= $"
{Application.ProductName.ToUpper}
Build: {sBuild}
Database: {CDatabase.GetDatabaseLocation()}
Password: {CDatabase.DATABASE_PASSWORD}
"


        TxtOut.Text = sOut

    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Close()
    End Sub

    Private Sub LlUrl_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LlUrl.LinkClicked
        Try
            Dim ll = CType(sender, LinkLabel)
            Process.Start(ll.Text)
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        End Try
    End Sub
End Class