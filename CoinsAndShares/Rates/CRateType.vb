Namespace Rates
    Friend Class CRateType
        Friend ReadOnly Property Id As String    ' ID is the provider's unique ID
        Friend ReadOnly Property Symbol As String
        Friend ReadOnly Property Name As String
        Friend ReadOnly Property CurrencyCode As String
        Friend ReadOnly Property Region As String
        Friend Sub New(id As String, symbol As String, name As String, currencyCode As String, region As String)
            ' ID is the provider's unique ID
            ' If symbol is not provided, just ignore it
            Me.Id = id
            Me.Symbol = symbol
            Me.Name = name
            Me.CurrencyCode = currencyCode
            Me.Region = region
        End Sub
    End Class

End Namespace
