Imports HtmlAgilityPack

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
            Dim Web = New HtmlWeb()
            Dim doc As HtmlDocument
            Try
                doc = Web.Load(url)
            Catch ex As Exception
                Throw New Exception($"Cannot download {url}.  The error was: {ex.Message}")
            End Try

            Dim headerNodes = doc.DocumentNode.ChildNodes("html").ChildNodes("head")
            Dim priceNode = headerNodes.ChildNodes.FirstOrDefault(
                Function(c)
                    Return c.Attributes.Where(
                        Function(d)
                            Return d.Name.Equals("name", StringComparison.CurrentCultureIgnoreCase) AndAlso
                                d.Value.Equals("price", StringComparison.CurrentCultureIgnoreCase)
                        End Function).Any
                End Function)

            If priceNode Is Nothing Then
                Return Nothing
            End If

            Dim sPrice = priceNode.Attributes("content").Value

            sPrice = sPrice.Where(Function(c) Char.IsDigit(c) OrElse c = ".").ToArray()

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

