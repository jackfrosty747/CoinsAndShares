Imports System.Net
Imports System.Text
Imports Flurl
Imports Newtonsoft.Json.Linq

Namespace Currencies.ExchangeRatesApiIo
    Friend Class CExchangeRatesApiIo : Implements ICurrencyRateApi

        Private Const BASE_URL As String = "http://api.exchangeratesapi.io"
        Private ReadOnly m_sApiKey As String

        Friend Sub New(sApiKey As String)
            m_sApiKey = sApiKey
        End Sub

        Friend Function GetName() As String Implements ICurrencyRateApi.GetName
            Return "ExchangeRatesApi.io"
        End Function

        Friend Function GetAll() As IEnumerable(Of CCurrencyBase) Implements ICurrencyRateApi.GetAll

            'Dim sUrl As String = Url.Combine(BASE_URL, "latest").
            '    SetQueryParam("access_key", m_sApiKey).
            '    SetQueryParam("base", GetLocalCurrencyIso)

            Dim sUrl As String = Url.Combine(BASE_URL, "latest").
                SetQueryParam("access_key", m_sApiKey).
                SetQueryParam("base", "EUR")
            ' 020421 - Free version only allows bse currency of EUR now

            Dim all As New List(Of CCurrencyBase)

            Using wc As New WebClient()
                Dim responseBytes As Byte() = wc.DownloadData(sUrl)
                Dim responseString As String = Encoding.Default.GetString(responseBytes)

                Dim myArray As JObject = JObject.Parse(responseString)
                Dim success = myArray.GetValue("success")
                If success Is Nothing Then
                    Return Nothing
                ElseIf success.Value(Of Boolean) = False Then
                    Dim e = myArray.GetValue("error")
                    Dim sError = "< Unable to get error description >"
                    If e IsNot Nothing Then
                        Dim t = e.Value(Of String)("type")
                        If t IsNot Nothing Then
                            sError = t
                        End If
                    End If
                    Throw New Exception($"Get exchange rates failed with error: {sError}")
                End If

                Dim rates = myArray("rates")

                Dim rLocalRate As Decimal
                For Each r In rates.Children
                    Dim p As JProperty = CType(r, JProperty)
                    Dim sCurrency As String = p.Name
                    Dim cValue As Decimal = p.Value.Value(Of Decimal)
                    If sCurrency.Equals(GetLocalCurrencyIso(), StringComparison.InvariantCultureIgnoreCase) Then
                        rLocalRate = cValue
                        Exit For
                    End If
                Next

                For Each r In rates.Children
                    Dim p As JProperty = CType(r, JProperty)
                    Dim sCurrency As String = p.Name
                    Dim cValue As Decimal = p.Value.Value(Of Decimal)
                    cValue /= rLocalRate
                    all.Add(New CCurrencyBase(sCurrency, cValue))
                Next

            End Using

            Return all

        End Function
    End Class

End Namespace
