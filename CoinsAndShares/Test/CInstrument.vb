Imports CoinsAndShares.Instruments

Namespace Test
    Friend Class CInstrument
        Friend ReadOnly Property InstrumentCode As String
        Friend ReadOnly Property InstrumentType As Instruments.EInstrumentType
        Friend ReadOnly Property Description As String
        Friend ReadOnly Property Rate As Decimal
        Friend ReadOnly Property ProviderLinkCode As String
        Friend ReadOnly Property RateUpdated As Date?
        Friend ReadOnly Property CurrencyCode As String
        Friend ReadOnly Property ProviderMultiplier As Decimal
        Friend ReadOnly Property Notes As String
        Friend ReadOnly Property HedgingGroupCode As String
        Friend ReadOnly Property Transactions As IEnumerable(Of CTransaction)

        Friend Sub New(instrumentCode As String, instrumentType As EInstrumentType, description As String, rate As Decimal, providerLinkCode As String, rateUpdated As Date?, currencyCode As String, providerMultiplier As Decimal, notes As String, hedgingGroupCode As String, transactions As IEnumerable(Of CTransaction))
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
            Me.Transactions = transactions
        End Sub

    End Class

End Namespace
