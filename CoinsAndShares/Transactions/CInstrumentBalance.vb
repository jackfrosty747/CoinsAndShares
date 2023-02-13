Imports CoinsAndShares.Instruments

Namespace Transactions
    Friend Class CInstrumentBalance
        Friend ReadOnly Property Instrument As CInstrument
        Friend ReadOnly Property Balance As Decimal
        Friend Sub New(instrument As CInstrument, balance As Decimal)
            Me.Instrument = instrument
            Me.Balance = balance
        End Sub
    End Class
End Namespace
