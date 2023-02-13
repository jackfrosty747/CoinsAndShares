Friend Class CApp
    Shared Sub Main()
        Dim errors As New CErrors
        Try
            Using database As New CDatabase()
                Using frmMdi As New FMdi(database, errors)
                    Application.Run(frmMdi)
                End Using
            End Using
        Catch ex As Exception
            errors.Handle(ex)
        End Try
    End Sub
End Class
