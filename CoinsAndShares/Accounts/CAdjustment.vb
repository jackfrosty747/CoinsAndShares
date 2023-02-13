Namespace Accounts
    Friend Class CAdjustment
        Friend ReadOnly Property TransactionType As ETransactionType
        Friend ReadOnly Property AccountCode As String
        Friend ReadOnly Property TransDate As Date
        Friend ReadOnly Property BonusType As EAdjustType
        Friend ReadOnly Property InstrumentCode As String
        Friend ReadOnly Property Quantity As Decimal
        Friend ReadOnly Property Rate As Decimal
        Friend ReadOnly Property Amount As Decimal
        Friend ReadOnly Property Description As String
        Friend Sub New(transactionType As ETransactionType, accountCode As String, transDate As Date,
                       bonusType As EAdjustType, instrumentCode As String, quantity As Decimal, rate As Decimal,
                       amount As Decimal, description As String)
            Me.TransactionType = transactionType
            Me.AccountCode = accountCode
            Me.TransDate = transDate
            Me.BonusType = bonusType
            Me.InstrumentCode = instrumentCode
            Me.Quantity = quantity
            Me.Rate = rate
            Me.Amount = amount
            Me.Description = description
        End Sub
    End Class
End Namespace
