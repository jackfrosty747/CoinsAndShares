Namespace BackupRestore.JSon
    Public Class JsonNetworkItem
        Public Property NetworkId As String
        Public Property Description As String
        Public Property Colour As Integer?
        Public Sub Fill(networkId As String, description As String, colour As Integer?)
            Me.NetworkId = networkId
            Me.Description = description
            Me.Colour = colour
        End Sub
    End Class

End Namespace
