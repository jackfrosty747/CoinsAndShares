Imports System.Net
Imports System.Text
Imports System.Web
Imports CoinsAndShares.Settings
Imports Newtonsoft.Json

Namespace Rates.Alphavantage
    Friend Class CAlphavantage : Implements IRateProvider

        Private Enum EFunction
            GLOBAL_QUOTE
            SYMBOL_SEARCH
        End Enum


        Friend ReadOnly m_commonObjects As CCommonObjects

        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub

        Friend Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes
            ' Don't think this is possible
            Return New List(Of CRateType)
        End Function

        Friend Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates


            Const REQUEST_LIMIT = 5
            Dim list As New List(Of CRate)
            Dim iRequests As Integer = 0
            For Each providerId In providerIds
                Dim rate = GetRate(providerId)
                iRequests += 1
                If rate IsNot Nothing AndAlso rate.Rate > 0 Then
                    list.Add(rate)
                End If
                If iRequests = REQUEST_LIMIT Then
                    Exit For
                End If
            Next
            Return list
        End Function

        Private Function GetRate(providerId As String) As CRate

            Dim ApiKey = GetApiKey()

            Dim sUrl As String = "https://www.alphavantage.co/query" &
                $"?function={EFunction.GLOBAL_QUOTE}" &
                $"&symbol={HttpUtility.UrlEncode(providerId)}" &
                $"&apikey={HttpUtility.UrlEncode(ApiKey)}"

            Using webClient As New WebClient
                Dim responseBytes As Byte() = webClient.DownloadData(sUrl)
                Dim responseString As String = Encoding.Default.GetString(responseBytes)
                Dim response = JsonConvert.DeserializeObject(Of CResponse)(responseString)
                If response Is Nothing OrElse response.GlobalQuote Is Nothing Then
                    Return Nothing
                End If
                Dim cPrice As Decimal = CDec(response.GlobalQuote.Price)
                Return New CRate(providerId, cPrice)
            End Using

        End Function

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Alphavantage"
        End Function

        Friend Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch

            Dim ApiKey = GetApiKey()

            Dim sUrl As String = "https://www.alphavantage.co/query" &
                $"?function={EFunction.SYMBOL_SEARCH}" &
                $"&keywords={HttpUtility.UrlEncode(searchText)}" &
                $"&apikey={HttpUtility.UrlEncode(ApiKey)}"

            Using webClient As New WebClient
                Dim responseBytes As Byte() = webClient.DownloadData(sUrl)
                Dim responseString As String = Encoding.Default.GetString(responseBytes)
                Dim response = JsonConvert.DeserializeObject(Of CResponse)(responseString)
                If response Is Nothing OrElse response.bestMatches Is Nothing Then
                    Return Nothing
                End If

                Dim results As New List(Of CRateType)
                For Each bestMatch In response.bestMatches
                    Dim rateType As New CRateType(bestMatch.Symbol, bestMatch.Symbol, bestMatch.Name, bestMatch.Currency, bestMatch.Region)
                    results.Add(rateType)
                Next

                Return results
            End Using

        End Function

        Private Function GetApiKey() As String

            Dim settings As New CSettings(m_commonObjects)
            If String.IsNullOrEmpty(settings.AlphavantageKey) Then
                Throw New Exception($"Alphavantage key not set")
            End If

            Return settings.AlphavantageKey

        End Function

    End Class

End Namespace
