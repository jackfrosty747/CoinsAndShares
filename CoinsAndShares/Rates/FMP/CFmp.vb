Imports System.IO
Imports System.Net
Imports HtmlAgilityPack
Imports Newtonsoft.Json

Namespace Rates.FMP
    Friend Class CFMP : Implements IRateProvider

        Const API_KEY = "5mn8kKFkQXhmOuZHGa4vq8OhfxbmwpZQ"

        Friend Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes
            Throw New NotImplementedException($"Not available from {GetName()}")
        End Function

        Friend Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch
            Throw New NotImplementedException($"Not available from {GetName()}")
        End Function

        Friend Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates

            Dim symbol = providerIds.First

            Dim reqUrl As String = $"https://financialmodelingprep.com/api/v3/quote-short/{String.Join(",", providerIds)}?apikey={API_KEY}"
            Dim req As HttpWebRequest = CType(WebRequest.Create(reqUrl), HttpWebRequest)
            req.Method = "GET"

            Dim res As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Dim resStream As Stream = res.GetResponseStream()
            Dim reader As New StreamReader(resStream)
            Dim responseBody As String = reader.ReadToEnd()

            Console.WriteLine(res.ToString())
            Console.WriteLine(responseBody)

            res.Close()
            reader.Close()

            Dim stockList As List(Of StockInfo) = JsonConvert.DeserializeObject(Of List(Of StockInfo))(responseBody)

            Dim rates As New List(Of CRate)

            For Each stockListItem In stockList
                Dim rate = New CRate(stockListItem.Symbol, CDec(stockListItem.Price))
                rates.Add(rate)
            Next

            Return rates

        End Function

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Financial Modeling Prep"
        End Function

        Public Class StockInfo
            Public Property Symbol As String
            Public Property Price As Double
            Public Property Volume As Integer
        End Class



    End Class

End Namespace
