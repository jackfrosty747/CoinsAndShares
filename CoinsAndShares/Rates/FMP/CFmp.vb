Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Namespace Rates.FMP
    Friend Class CFMP : Implements IRateProvider

        Const API_KEY = "5mn8kKFkQXhmOuZHGa4vq8OhfxbmwpZQ"

        Friend Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes

            Dim reqUrl As String = $"https://financialmodelingprep.com/api/v3/stock/list?apikey={API_KEY}"
            Dim req As HttpWebRequest = CType(WebRequest.Create(reqUrl), HttpWebRequest)
            req.Method = "GET"

            Dim res As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Dim resStream As Stream = res.GetResponseStream()
            Dim reader As New StreamReader(resStream)
            Dim responseBody As String = reader.ReadToEnd()

            res.Close()
            reader.Close()

            Dim out = New List(Of CRateType)

            Dim stockInfoList As List(Of AllStockInfo) = JsonConvert.DeserializeObject(Of List(Of AllStockInfo))(responseBody)
            For Each stockInfo In stockInfoList
                out.Add(New CRateType(stockInfo.symbol, stockInfo.symbol, stockInfo.name, String.Empty, String.Empty))
            Next

            Return out

        End Function

        Public Class AllStockInfo
            Public Property symbol As String
            Public Property exchange As String
            Public Property exchangeShortName As String
            Public Property price As String
            Public Property name As String
        End Class

        Friend Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch

            Dim all = GetAllRateTypes()

            all = all.Where(Function(c) c.Symbol.ToUpper.Contains(searchText.ToUpper) OrElse (c.Name IsNot Nothing AndAlso c.Name.ToUpper.Contains(searchText.ToUpper)))

            Return all

        End Function

        'Friend Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates

        '    Dim symbol = providerIds.First

        '    Dim reqUrl As String = $"https://financialmodelingprep.com/api/v3/quote-short/{String.Join(",", providerIds)}?apikey={API_KEY}"
        '    Dim req As HttpWebRequest = CType(WebRequest.Create(reqUrl), HttpWebRequest)
        '    req.Method = "GET"

        '    Dim res As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
        '    Dim resStream As Stream = res.GetResponseStream()
        '    Dim reader As New StreamReader(resStream)
        '    Dim responseBody As String = reader.ReadToEnd()

        '    res.Close()
        '    reader.Close()

        '    Dim stockList As List(Of StockInfo) = JsonConvert.DeserializeObject(Of List(Of StockInfo))(responseBody)

        '    Dim rates As New List(Of CRate)
        '    For Each stockListItem In stockList
        '        Dim rate = New CRate(stockListItem.Symbol, CDec(stockListItem.Price))
        '        rates.Add(rate)
        '    Next

        '    Return rates

        'End Function

        Friend Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates

            Dim reqUrl As String = $"https://financialmodelingprep.com/api/v3/stock/list?apikey={API_KEY}"
            Dim req As HttpWebRequest = CType(WebRequest.Create(reqUrl), HttpWebRequest)
            req.Method = "GET"

            Dim res As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Dim resStream As Stream = res.GetResponseStream()
            Dim reader As New StreamReader(resStream)
            Dim responseBody As String = reader.ReadToEnd()

            res.Close()
            reader.Close()

            Dim out = New List(Of CRate)

            Dim stockInfoList As List(Of AllStockInfo) = JsonConvert.DeserializeObject(Of List(Of AllStockInfo))(responseBody)

            For Each providerId In providerIds
                Dim r = stockInfoList.FirstOrDefault(Function(c) c.symbol.ToUpper.Equals(providerId, StringComparison.CurrentCultureIgnoreCase))
                If r IsNot Nothing Then
                    out.Add(New CRate(r.symbol, CDec(r.price)))
                End If
            Next

            Return out

        End Function

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Financial Modeling Prep"
        End Function


    End Class

End Namespace
