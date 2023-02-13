Namespace Rates
    Friend Class CRate
        Friend ReadOnly Property ID As String
        Friend ReadOnly Property Rate As Decimal
        Friend Sub New(id As String, rate As Decimal)
            Me.ID = id
            Me.Rate = rate
        End Sub
    End Class

End Namespace
