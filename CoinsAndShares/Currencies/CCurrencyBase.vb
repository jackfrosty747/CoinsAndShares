Namespace Currencies
    Friend Class CCurrencyBase
        Friend ReadOnly Property CurrencyCode As String
        Friend Property CurrencyRate As Decimal?
        Friend Sub New(currencyCode As String, currencyRate As Decimal?)
            Me.CurrencyCode = currencyCode
            Me.CurrencyRate = currencyRate
        End Sub
    End Class

End Namespace
