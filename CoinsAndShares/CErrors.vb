Friend Class CErrors
    Friend Sub Handle(ex As Exception)
        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
End Class
