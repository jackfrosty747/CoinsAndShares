Imports Newtonsoft.Json

Namespace Rates.Alphavantage
    Public Class CBestMatch
        <JsonProperty("1. symbol")>
        Public Property Symbol As String
        <JsonProperty("2. name")>
        Public Property Name As String
        <JsonProperty("3. type")>
        Public Property Type As String
        <JsonProperty("4. region")>
        Public Property Region As String
        <JsonProperty("5. marketOpen")>
        Public Property MarketOpen As String
        <JsonProperty("6. marketClose")>
        Public Property MarketClose As String
        <JsonProperty("7. timezone")>
        Public Property Timezone As String
        <JsonProperty("8. currency")>
        Public Property Currency As String
        <JsonProperty("9. matchScore")>
        Public Property MatchScore As String
    End Class

End Namespace
