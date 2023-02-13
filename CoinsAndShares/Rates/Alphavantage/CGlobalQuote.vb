Imports Newtonsoft.Json

Namespace Rates.Alphavantage
    Friend Class CGlobalQuote
        <JsonProperty("01. symbol")>
        Public Property Symbol As String
        <JsonProperty("02. open")>
        Public Property Open As String
        <JsonProperty("03. high")>
        Public Property High As String
        <JsonProperty("04. low")>
        Public Property Low As String
        <JsonProperty("05. price")>
        Public Property Price As String
        <JsonProperty("06. volume")>
        Public Property Volume As String
        <JsonProperty("07. latest trading day")>
        Public Property Latesttradingday As String
        <JsonProperty("08. previous close")>
        Public Property Previousclose As String
        <JsonProperty("09. change")>
        Public Property Change As String
        <JsonProperty("10. change percent")>
        Public Property Changepercent As String
    End Class
End Namespace
