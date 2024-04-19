Imports HtmlAgilityPack

Namespace Rates.YahooFinance
    Friend Class CYahooFinance : Implements IRateProvider

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

            Dim symbol = providerIds.First

            Dim url = "https://finance.yahoo.com/quote/" & symbol

            ' Dim a = New YahooFinanceClient()


            'Dim result = Task.Run(Function() Yahoo.Finance.QuoteSummaryStore.DownloadAsync(symbol)).GetAwaiter().GetResult()

            'Dim price = result.AskPrice



            Return Nothing


            Dim sPrice = ""

            Dim rates As New List(Of CRate)
            Dim rate = New CRate(symbol, CDec(sPrice))
            rates.Add(rate)
            Return rates

        End Function

        Private Shared Sub FindXPath(doc As HtmlDocument, sKnownPrice As String)
            FindXPathA(doc.DocumentNode, sKnownPrice)
        End Sub

        Private Shared Sub FindXPathA(hn As HtmlNode, sKnownPrice As String)
            Static found As Boolean
            For Each n In hn.ChildNodes
                FindXPathA(n, sKnownPrice)
                If found Then Return
                If n.InnerText.Contains(sKnownPrice) Then
                    Debug.WriteLine(n.ParentNode.XPath)
                    MsgBox("Path should be: " & n.ParentNode.XPath)
                    found = True
                End If
            Next
        End Sub

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Yahoo Finance"
        End Function

    End Class

End Namespace
