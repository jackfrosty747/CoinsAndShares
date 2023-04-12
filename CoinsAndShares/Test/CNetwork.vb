Namespace Test
    Friend Class CNetwork
        Friend ReadOnly Property NetworkId As String
        Friend ReadOnly Property Description As String
        Friend ReadOnly Property Colour As Color?
        Friend Sub New(networkId As String, description As String, colour As Color?)
            Me.NetworkId = networkId
            Me.Description = description
            Me.Colour = colour
        End Sub
    End Class

End Namespace
