
Imports HtmlAgilityPack

Namespace Rates.GoldPrice
    Friend Class CGoldPrice : Implements IRateProvider

        Enum Metals
            Gold
            Silver
            Platinum
            Palladium
        End Enum

        Friend Function GetAllRateTypes() As IEnumerable(Of CRateType) Implements IRateProvider.GetAllRateTypes
            Dim all = New List(Of CRateType)
            For Each metal In [Enum].GetValues(GetType(Metals))
                Dim sMetal = [Enum].GetName(GetType(Metals), metal)
                all.Add(New CRateType(sMetal, sMetal, sMetal, String.Empty, String.Empty))
            Next
            Return all
        End Function

        Friend Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType) Implements IRateProvider.RateTypeSearch
            Dim all = New List(Of CRateType)
            For Each metal In [Enum].GetValues(GetType(Metals))
                Dim sMetal = [Enum].GetName(GetType(Metals), metal)
                If sMetal.ToUpper.Contains(searchText.ToUpper) Then
                    all.Add(New CRateType(sMetal, sMetal, sMetal, String.Empty, String.Empty))
                End If
            Next
            Return all
        End Function

        Friend Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate) Implements IRateProvider.GetNewRates

            Dim Symbol = providerIds.First

            Dim url = "https://www.gold-price.co.uk/"
            Dim Web = New HtmlWeb()
            Dim doc As HtmlDocument
            Try
                doc = Web.Load(url)
            Catch ex As Exception
                Throw New Exception($"Cannot download {url}.  The error was: {ex.Message}")
            End Try
            Dim navigator = doc.DocumentNode.CreateNavigator







            '' If this path breaks, use the below code to find the path of a known price
            'Dim PathIsBroken = False
            'If PathIsBroken Then
            '    FindXPath(doc, "22.31")
            '    Return Nothing
            'End If


            Dim rates As New List(Of CRate)

            ' Find all <li> elements containing metal prices
            Dim liNodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//div[@class='visible-xs-block']//ul[@class='nav nav-pills']/li")

            If liNodes IsNot Nothing Then
                For Each liNode As HtmlNode In liNodes
                    ' Extract metal name
                    Dim metalName As String = liNode.SelectSingleNode("a").InnerText.Trim().Split(" "c).First

                    ' Extract price
                    Dim priceNode As HtmlNode = liNode.SelectSingleNode("a/span/span")
                    Dim priceText As String = If(priceNode IsNot Nothing, priceNode.InnerText.Trim().Replace("£&thinsp;", "").Replace(",", ""), "")

                    Dim metalPrice = CDec(priceText)

                    ' Add metal name and price to dictionary
                    If Not String.IsNullOrEmpty(metalName) AndAlso Not String.IsNullOrEmpty(priceText) Then
                        If providerIds.Any(Function(c) c.Equals(metalName, StringComparison.CurrentCultureIgnoreCase)) Then
                            rates.Add(New CRate(metalName, metalPrice))
                        End If
                    End If
                Next
            End If

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
            Return "Gold Price"
        End Function

    End Class

End Namespace
