Namespace Rates.MarketWatch
    Friend Class CMarketWatch : Implements IRateProvider
        Friend Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes
            Throw New NotImplementedException($"Not available from {GetName()}")
        End Function

        Friend Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch
            Throw New NotImplementedException($"Not available from {GetName()}")
        End Function

        Friend Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates

            If providerIds.Count <> 1 Then
                Throw New NotImplementedException($"Can only get one price with {GetName()} scraper")
            End If

            Dim Symbol = providerIds.First


            Dim url = "https://www.marketwatch.com/investing/stock/" & Symbol


            Dim sPrice = ""


            Dim rates As New List(Of CRate)
            Dim rate = New CRate(Symbol, CDec(sPrice))
            rates.Add(rate)
            Return rates

        End Function

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Market Watch"
        End Function

    End Class
End Namespace

