Namespace Currencies.ExchangeRatesApiIo
    Friend Class CJsonResponse
#Disable Warning IDE1006 ' Naming Styles
        Public Property rates As List(Of Tuple(Of String, Decimal))
        Public Property base As String
        Public Property [date] As String
#Enable Warning IDE1006 ' Naming Styles
    End Class
End Namespace
