Namespace Transactions
    Friend Class CBatch
        Friend ReadOnly Property Batch As Long
        Friend ReadOnly Property AccountCode As String
        Friend ReadOnly Property TransactionType As ETransactionType
        Friend ReadOnly Property InstrumentCode As String
        Friend ReadOnly Property MonetaryAmount As Decimal
        Friend ReadOnly Property InstrumentAmount As Decimal
        Friend Sub New(batch As Long, accountCode As String, transactionType As ETransactionType, instrumentCode As String, monetaryAmount As Decimal, instrumentAmount As Decimal)
            Me.Batch = batch
            Me.AccountCode = accountCode
            Me.TransactionType = transactionType
            Me.InstrumentCode = instrumentCode
            Me.MonetaryAmount = monetaryAmount
            Me.InstrumentAmount = instrumentAmount
        End Sub
    End Class

End Namespace
