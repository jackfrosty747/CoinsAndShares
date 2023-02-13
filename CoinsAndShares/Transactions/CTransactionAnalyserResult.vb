Namespace Transactions
    Friend Class CTransactionAnalyserResult
        Friend ReadOnly Property TransfersIn As Decimal
        Friend ReadOnly Property TransfersOut As Decimal
        Friend ReadOnly Property NetTransfers As Decimal

        Friend ReadOnly Property Fees As Decimal
        Friend ReadOnly Property Bonus As Decimal
        Friend ReadOnly Property Mining As Decimal
        Friend ReadOnly Property Adjustments As Decimal
        Friend ReadOnly Property CurrentValues As IEnumerable(Of CInstrumentBalance)
        Friend ReadOnly Property CurrentValue As Decimal
            Get
                Return CurrentValues.Sum(Function(c) c.Balance)
            End Get
        End Property

        Friend ReadOnly Property ProfitLoss As Decimal

        Friend ReadOnly Property Batches As IEnumerable(Of CBatch)
        Friend ReadOnly Property InstrumentAnalysis As IEnumerable(Of CInstrumentAnalysis)
        Friend Sub New(transfersIn As Decimal, transfersOut As Decimal, netTransfers As Decimal, fees As Decimal, mining As Decimal,
                       bonus As Decimal, adjustments As Decimal, currentValues As IEnumerable(Of CInstrumentBalance),
                       profitLoss As Decimal, batches As IEnumerable(Of CBatch), instrumentAnalysis As IEnumerable(Of CInstrumentAnalysis))
            Me.TransfersIn = transfersIn
            Me.TransfersOut = transfersOut
            Me.NetTransfers = netTransfers
            Me.Fees = fees
            Me.Mining = mining
            Me.Bonus = bonus
            Me.Adjustments = adjustments
            Me.CurrentValues = currentValues
            Me.ProfitLoss = profitLoss
            Me.Batches = batches
            Me.InstrumentAnalysis = instrumentAnalysis
        End Sub

    End Class

End Namespace
