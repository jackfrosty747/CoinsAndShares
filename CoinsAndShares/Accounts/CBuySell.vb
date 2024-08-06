Namespace Accounts
    Friend Class CBuySell
        Friend ReadOnly Property BuySell As EBuySell
        Friend ReadOnly Property InstrumentCode As String
        Friend ReadOnly Property BuySellDate As Date
        Friend ReadOnly Property Quantity As Decimal
        Friend Property Rate As Decimal
        Friend ReadOnly Property Amount As Decimal
        Friend ReadOnly Property AccountCode As String
        Friend Sub New(buySell As EBuySell, instrumentCode As String, buySellDate As Date, quantity As Decimal, rate As Decimal,
            amount As Decimal, accountCode As String)
            Me.BuySell = buySell
            Me.InstrumentCode = instrumentCode
            Me.BuySellDate = buySellDate
            Me.Quantity = quantity
            Me.Rate = rate
            Me.Amount = amount
            Me.AccountCode = accountCode
        End Sub
    End Class
End Namespace

