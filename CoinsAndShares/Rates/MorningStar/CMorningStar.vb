Imports HtmlAgilityPack

Namespace Rates.MorningStar
    Friend Class CMorningStar : Implements IRateProvider

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

            Dim Symbol = providerIds.First

            Dim url = $"https://www.morningstar.com/stocks/xnas/{Symbol}/quote"
            Dim Web = New HtmlWeb()
            Dim doc As HtmlDocument
            Try
                doc = Web.Load(url)
            Catch ex As Exception
                Throw New Exception($"Cannot download {url}.  The error was: {ex.Message}")
            End Try
            Dim navigator = doc.DocumentNode.CreateNavigator

            ' If this path breaks, use the below code to find the path of a known price
            Dim PathIsBroken = True
            If PathIsBroken Then
                FindXPath(doc, "106.80")
                Return Nothing
            End If

            ' README 
            ' When Yahoo break this, set PathIsBroken = True above.  Pick an instrument where the market is closed, so the price
            ' doesn't change, then set that price above.  Hey presto.

            'Dim result = navigator.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[3]")
            'Dim result = navigator.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[5]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/span[1]")
            'Dim result = navigator.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[5]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/fin-streamer[1]")
            Dim result = navigator.SelectSingleNode("/html[1]/body[1]/c-wiz[2]/div[1]/div[4]/div[1]/main[1]/div[2]/div[1]/div[1]/c-wiz[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/div[1]/div[1]")
            If result Is Nothing Then
                Return Nothing
            End If
            Dim sText = result.Value.Trim

            Dim sPrice As String = String.Empty
            For i = 0 To sText.Length - 1
                Dim sChar = sText.Substring(i, 1)
                If sChar = "," Then

                ElseIf IsNumeric(sChar) OrElse (sChar = "." AndAlso Not sPrice.Contains(".")) Then
                    sPrice &= sChar
                Else
                    Exit For
                End If
            Next

            Dim rates As New List(Of CRate)
            Dim rate = New CRate(Symbol, CDec(sPrice))
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
                    MsgBox("Path should be: " & n.ParentNode.XPath)
                    found = True
                End If
            Next
        End Sub

        Friend Function GetName() As String Implements IRateProvider.GetName
            Return "Morning Star"
        End Function

    End Class

End Namespace
