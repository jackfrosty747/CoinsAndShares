Imports Newtonsoft.Json

Namespace Rates.Alphavantage
    Friend Class CResponse
        <JsonProperty("Global Quote")>
        Public Property GlobalQuote As CGlobalQuote
#Disable Warning IDE1006 ' Naming Styles
        Public Property bestMatches As List(Of CBestMatch)
#Enable Warning IDE1006 ' Naming Styles
    End Class
End Namespace
