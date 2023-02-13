Namespace Currencies
    Friend Interface ICurrencyRateApi
        Function GetAll() As IEnumerable(Of CCurrencyBase)
        Function GetName() As String ' Just return the name of this API provider
    End Interface
End Namespace
