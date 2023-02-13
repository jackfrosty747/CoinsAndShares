Namespace Rates
    Friend Interface IRateProvider
        ' Get ALL rate types available from the provider.  For Crypto providers, this means ALL possible
        ' coins.  Share accounts means all possible shares
        ' ID, Symbol, Description.  Symbol is not required
        Function GetAllRateTypes() As IEnumerable(Of CRateType)

        ' Get ALL rate types matching the search text.  This might be a filter of all the rate times 
        ' collected from above, of a request in its own right, depending on the provider.  If no search text
        ' provided, return NO RESULTS.  Has to be this way because we might not be allowed by certain
        ' providers to get everything
        Function RateTypeSearch(searchText As String) As IEnumerable(Of CRateType)

        ' Accept a list of IDs of the providers references of the rates we want, and return a list of the
        ' corresponding rates
        Function GetNewRates(providerIds As IEnumerable(Of String)) As IEnumerable(Of CRate)

        ' Return the name of the provider for use on screens, etc
        Function GetName() As String
    End Interface

End Namespace
