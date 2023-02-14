Friend Class FAbout
    Friend Sub New()

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

        Dim sOut = Text

        sOut &= $"
Database: {CDatabase.GetDatabaseLocation()}
Password: {CDatabase.DATABASE_PASSWORD}
Build: {sBuild}"


        TxtOut.Text = sOut

    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Close()
    End Sub
End Class