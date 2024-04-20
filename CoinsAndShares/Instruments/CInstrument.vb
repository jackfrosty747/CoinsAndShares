Imports System.Collections.ObjectModel
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Transactions

Namespace Instruments
    Friend Class CInstrument
        Friend ReadOnly Property Code As String
        Friend ReadOnly Property InstrumentType As EInstrumentType
        Friend Property Description As String
        Friend Property Rate As Decimal
        Friend Property RateUpdated As Date?
        Friend ReadOnly Property ProviderLinkCode As String
        Friend ReadOnly Property ProviderMultiplier As Decimal
        Friend ReadOnly Property CurrencyCode As String
        Friend ReadOnly Property Notes As String
        Friend ReadOnly Property HedgingGroupCode As String
        Friend ReadOnly Property RateProvider As Integer
        Friend Property Transactions As Collection(Of CTransaction)
        Friend Sub New(code As String, instrumentType As EInstrumentType, description As String, rate As Decimal, rateUpdated As Date?,
                       providerLinkCode As String, currencyCode As String, providerMultiplier As Decimal, notes As String,
                       hedgingGroupCode As String, rateProvider As Integer)
            Me.Code = code
            Me.InstrumentType = instrumentType
            Me.Description = description
            Me.Rate = rate
            Me.RateUpdated = rateUpdated
            Me.ProviderLinkCode = providerLinkCode
            Me.ProviderMultiplier = providerMultiplier
            Me.CurrencyCode = currencyCode
            Me.Notes = notes
            Me.HedgingGroupCode = hedgingGroupCode
            Me.RateProvider = rateProvider
            Transactions = New Collection(Of CTransaction)
        End Sub
        Friend Function GetLocalCurrencyBalance(instruments As IEnumerable(Of CInstrument), currencies As IEnumerable(Of CCurrencyDetail)) As Decimal
            Return Transactions.Sum(Function(c) c.GetLocalCurrencyBalance(instruments, currencies))
        End Function
        Friend Function GetQuantityHeld() As Decimal
            Return Transactions.Sum(Function(c) c.Amount)
        End Function
    End Class
End Namespace
