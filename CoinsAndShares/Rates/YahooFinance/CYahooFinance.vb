Imports HtmlAgilityPack
Imports YahooFinanceApi

Namespace Rates.YahooFinance
    Friend Class CYahooFinance : Implements IRateProvider

        Friend Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes
            Throw New NotImplementedException($"Not available from {GetName()}")
        End Function

        Friend Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch
            Throw New NotImplementedException($"Not available from {GetName()}")
        End Function

        Friend Function GetNewRates(tickers As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates

            If tickers Is Nothing OrElse Not tickers.Any Then
                Throw New ArgumentNullException(NameOf(tickers), "Tickers cannot be null or empty")
            End If

            ' Convert tickers to an array for easier processing
            Dim symbols As String() = tickers.ToArray()

            Dim results = Task.Run(Function()
                                       Return Yahoo.Symbols(symbols) _
                                              .Fields(Field.Symbol, Field.RegularMarketPrice) _
                                              .QueryAsync()
                                   End Function).Result

            Dim rates As New List(Of CRate)

            For Each ticker In tickers
                Dim result As Security = Nothing
                If results.TryGetValue(ticker, result) Then
                    rates.Add(New CRate(ticker, CDec(result.RegularMarketPrice)))
                End If
            Next

            Return rates

        End Function

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Yahoo Finance"
        End Function

    End Class

End Namespace
