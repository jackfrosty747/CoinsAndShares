Namespace BackupRestore.JSon
    Public Class JSonInstrument
        Public Property InstrumentCode As String
        Public Property InstrumentType As String
        Public Property Description As String
        Public Property Rate As Decimal?
        Public Property ProviderLinkCode As String
        Public Property RateUpdated As Date?
        Public Property CurrencyCode As String
        Public Property ProviderMultiplier As Decimal?
        Public Property Notes As String
        Public Property HedgingGroupCode As String
        Friend Sub Fill(instrumentCode As String, instrumentType As String, description As String, rate As Decimal?,
                        providerLinkCode As String, rateUpdated As Date?, currencyCode As String, providerMultiplier As Decimal?,
                        notes As String, hedgingGroupCode As String)
            Me.InstrumentCode = instrumentCode
            Me.InstrumentType = instrumentType
            Me.Description = description
            Me.Rate = rate
            Me.ProviderLinkCode = providerLinkCode
            Me.RateUpdated = rateUpdated
            Me.CurrencyCode = currencyCode
            Me.ProviderMultiplier = providerMultiplier
            Me.Notes = notes
            Me.HedgingGroupCode = hedgingGroupCode
        End Sub

    End Class
End Namespace
