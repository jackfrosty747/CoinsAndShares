Imports System.Net
Imports System.Text
Imports Flurl
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Rates.CoinGecko

    ' API
    ' https://www.coingecko.com/en/api#explore-api

    Friend Class CCoinGecko : Implements IRateProvider

        Private Const BASE_URL As String = "https://api.coingecko.com/api/v3/"

        Friend Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes
            Static allRateTypes As List(Of CRateType)
            If allRateTypes Is Nothing Then
                allRateTypes = New List(Of CRateType)
                Dim allCoinGeckoCoins = GetAllRateTypesNow()
                For Each coinGeckoCoin In allCoinGeckoCoins
                    Dim rateType As New CRateType(coinGeckoCoin.Id, coinGeckoCoin.Symbol, coinGeckoCoin.Name, String.Empty, String.Empty)
                    allRateTypes.Add(rateType)
                Next
            End If
            Return allRateTypes
        End Function

        Private Shared Function GetAllRateTypesNow() As IEnumerable(Of CCoinGeckoCoin)
            Using webClient As New WebClient()
                Dim sUrl As String = Url.Combine(BASE_URL, "coins", "list")
                Dim responseBytes As Byte() = webClient.DownloadData(sUrl)
                Dim responseString As String = Encoding.Default.GetString(responseBytes)
                Dim allCoinGeckoCoins = JsonConvert.DeserializeObject(Of List(Of CCoinGeckoCoin))(responseString)
                Return allCoinGeckoCoins
            End Using
        End Function

        Friend Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates

            Dim sLocalCurrencyIso As String = GetLocalCurrencyIso() ' GBP

            Dim sIdsToGet As String = String.Empty
            For Each providerId In providerIds
                If Not String.IsNullOrEmpty(sIdsToGet) Then
                    sIdsToGet &= ","
                End If
                sIdsToGet &= providerId
            Next

            Dim sUrl As String = Url.Combine(BASE_URL, "simple", "price").
                SetQueryParam("vs_currencies", sLocalCurrencyIso).
                SetQueryParam("ids", sIdsToGet)

            Dim rates As New List(Of CRate)

            Using wc As New WebClient()
                Dim responseBytes As Byte() = wc.DownloadData(sUrl)
                Dim responseString As String = Encoding.Default.GetString(responseBytes)

                Dim myArray As JObject = JObject.Parse(responseString)
                For Each c In myArray.Children
                    Dim sSymbol As String = CType(c, JProperty).Name
                    For Each cur In c.Children
                        For Each v In cur.Children
                            Dim p As JProperty = CType(v, JProperty)
                            Dim sCurrency As String = p.Name
                            Dim cValue As Decimal = p.Value.Value(Of Decimal)
                            If sLocalCurrencyIso.Equals(sCurrency, StringComparison.CurrentCultureIgnoreCase) Then
                                rates.Add(New CRate(sSymbol, cValue))
                            End If
                        Next
                    Next
                Next
            End Using

            Return rates

        End Function

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Coingecko"
        End Function

        Friend Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch

            ' Get ALL rate types matching the search text.  This might be a filter of all the rate times 
            ' collected from above, of a request in its own right, depending on the provider.

            Static all As List(Of CRateType)
            Static dataRead As Boolean

            If Not dataRead Then
                all = New List(Of CRateType)(GetAllRateTypes())
                dataRead = True
            End If

            Dim filtered = all.Where(Function(c)
                                         Return _
                                            searchText.Length = 0 OrElse
                                            ContainsIgnoreCase(c.Name, searchText) OrElse
                                            ContainsIgnoreCase(c.Symbol, searchText) OrElse
                                            ContainsIgnoreCase(c.Id, searchText)
                                     End Function)

            Return filtered

        End Function

    End Class

End Namespace
