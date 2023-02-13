Namespace Transactions

    Friend Class CInstrumentAnalysis
        Friend ReadOnly Property InstrumentCode As String
        Friend ReadOnly Property CurrentHolding As Decimal
        Friend ReadOnly Property CurrentWorth As Decimal
        Friend ReadOnly Property NetCash As Decimal
        Friend ReadOnly Property Pl As Decimal
        Friend Sub New(instrumentCode As String, currentHolding As Decimal, currentWorth As Decimal,
                       netCash As Decimal, pl As Decimal)
            Me.InstrumentCode = instrumentCode
            Me.CurrentHolding = currentHolding
            Me.CurrentWorth = currentWorth
            Me.NetCash = netCash
            Me.Pl = pl
        End Sub
    End Class

End Namespace
