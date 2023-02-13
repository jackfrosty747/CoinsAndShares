Namespace Currencies
    Friend Class CCurrencyDetail : Inherits CCurrencyBase
        Friend ReadOnly Property CurrencyName As String
        Friend Property Favourite As Boolean
        Friend Sub New(currencyCode As String, currencyName As String, currencyRate As Decimal?, favourite As Boolean)
            MyBase.New(currencyCode, currencyRate)
            Me.CurrencyName = currencyName
            Me.Favourite = favourite
        End Sub
    End Class

End Namespace
