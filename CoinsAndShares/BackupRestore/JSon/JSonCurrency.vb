Namespace BackupRestore.JSon
    Public Class JSonCurrency
        Public Property CurrencyCode As String
        Public Property CurrencyRate As Decimal?
        Friend Sub Fill(currencyCode As String, currencyRate As Decimal?)
            Me.CurrencyCode = currencyCode
            Me.CurrencyRate = currencyRate
        End Sub
    End Class
End Namespace
