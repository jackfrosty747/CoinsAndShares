Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab
Imports Newtonsoft.Json

Namespace Rates.Trading212
    Friend Class CTrading212 : Implements IRateProvider

        Private Const API_KEY = "1994934ZBuLAKliEQHazroAtiCCcSlsNmCJH"
        Private Const API_SECRET = "qBYJAGCtY2PoGyxLxCOfGVkJEXF_S_DyagLxLwz4AVk"

        Private Const BaseUrl As String = "https://live.trading212.com"

        Public Class InstrumentData
            Public Property ticker As String
            Public Property name As String
            Public Property currencyCode As String
            Public Property isin As String
            Public Property type As String
            Public Property workingScheduleId As Long ' Changed to Long/Integer to match data
            Public Property shortName As String
            Public Property maxOpenQuantity As Decimal
            Public Property extendedHours As Boolean
            Public Property addedOn As DateTime ' Matches the date-time format
        End Class

        Public Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes

            Dim currentPath As String = "/api/v0/equity/metadata/instruments?limit=50"

            Using client As New HttpClient()
                client.BaseAddress = New Uri(BaseUrl)

                Dim authHeaderValue As String = GetBasicAuthHeaderValue(API_KEY, API_SECRET)
                Dim parts As String() = authHeaderValue.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                If client.DefaultRequestHeaders.Contains("Authorization") Then
                    client.DefaultRequestHeaders.Remove("Authorization")
                End If
                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue(parts(0), parts(1))

                Do While Not String.IsNullOrEmpty(currentPath)
                    Try
                        Dim response As HttpResponseMessage = client.GetAsync(currentPath).Result

                        If response.IsSuccessStatusCode Then
                            Dim resultJson As String = response.Content.ReadAsStringAsync().Result
                            Dim instruments = JsonConvert.DeserializeObject(Of List(Of InstrumentData))(resultJson)
                            Dim out = New List(Of CRateType)
                            For Each instrument In instruments
                                out.Add(New CRateType(instrument.ticker, instrument.ticker, instrument.name, instrument.currencyCode, Nothing))
                            Next
                            Return out
                        Else
                            Dim errorContent As String = response.Content.ReadAsStringAsync().Result
                            Throw New Exception($"Instrument API failed with status code {response.StatusCode}: {errorContent}")
                        End If

                    Catch ex As Exception
                        ' Handle exceptions, breaking the loop if an error occurs
                        Throw New Exception($"An error occurred during pagination: {ex.Message}", ex)
                        Exit Do
                    End Try
                Loop
            End Using

            Return Nothing
        End Function


        Public Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch
            Dim all = GetAllRateTypes()
            Return all.Where(Function(c) c.Name.ToUpper.Contains(searchText.ToUpper) OrElse (c.Symbol IsNot Nothing AndAlso c.Symbol.ToUpper.Contains(searchText.ToUpper)))
        End Function

        Public Class Position
            Public Property averagePricePaid As Decimal
            Public Property createdAt As Date
            Public Property currentPrice As Decimal
            Public Property instrument As Instrument
            Public Property quantity As Decimal
            Public Property quantityAvailableForTrading As Decimal
            Public Property quantityInPies As Decimal
            Public Property walletImpact As WalletImpact
        End Class

        Public Class Instrument
            Public Property ticker As String
            Public Property name As String
            Public Property currencyCode As String
            Public Property type As String
        End Class

        Public Class WalletImpact
            Public Property pnl As Decimal
            Public Property pnlPercentage As Decimal
            Public Property pnlCurrencyCode As String
            Public Property pnlValue As Decimal
        End Class

        Public Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates
            Using client As New HttpClient()
                client.BaseAddress = New Uri(BaseUrl)

                Try
                    ' 1. Construct the Base64-encoded value
                    Dim authHeaderValue As String = GetBasicAuthHeaderValue(API_KEY, API_SECRET)
                    Dim parts As String() = authHeaderValue.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)

                    ' 2. Remove the old header to avoid the "multiple values" error
                    If client.DefaultRequestHeaders.Contains("Authorization") Then
                        client.DefaultRequestHeaders.Remove("Authorization")
                    End If

                    ' 3. Set the Authorization header
                    client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue(parts(0), parts(1))

                    Dim response As HttpResponseMessage = client.GetAsync("/api/v0/equity/positions").Result

                    If response.IsSuccessStatusCode Then
                        Dim result As String = response.Content.ReadAsStringAsync().Result
                        Dim positions = JsonConvert.DeserializeObject(Of List(Of Position))(result)

                        Dim out = New List(Of CRate)

                        For Each providerId In providerIds
                            Dim position = positions.FirstOrDefault(Function(p) p.instrument.ticker.Equals(providerId, StringComparison.OrdinalIgnoreCase))
                            If position IsNot Nothing Then
                                out.Add(New CRate(providerId, position.currentPrice))
                            End If
                        Next

                        Return out
                    Else
                        Dim errorContent As String = response.Content.ReadAsStringAsync().Result
                        Throw New Exception($"API request failed with status code {response.StatusCode}: {errorContent}")
                    End If

                Catch ex As AggregateException
                    ' When using .Result on a task that fails, the actual exception is wrapped in an AggregateException.
                    ' Check the InnerException for the real error.
                    Throw New Exception($"An error occurred (synchronous call): {ex.InnerException.Message}")
                Catch ex As Exception
                    Throw New Exception($"An exception occurred: {ex.Message}")
                End Try
            End Using
        End Function

        Public Function GetBasicAuthHeaderValue(ByVal apiKey As String, ByVal apiSecret As String) As String
            ' Combine the key and secret: "API_KEY:API_SECRET"
            Dim credentialsString As String = $"{apiKey}:{apiSecret}"

            ' Encode the string to bytes using UTF-8
            Dim credentialBytes As Byte() = Encoding.UTF8.GetBytes(credentialsString)

            ' Base64 encode the bytes
            Dim base64Credentials As String = Convert.ToBase64String(credentialBytes)

            ' Prepend "Basic " to the encoded string
            Return $"Basic {base64Credentials}"
        End Function

        Public Function GetName() As String Implements IRateProvider.GetName
            Return "Trading 212"
        End Function
    End Class

End Namespace


