Namespace Test
    Friend Class CTransaction
        Friend Property Id As Integer
        Friend ReadOnly Property TransactionDate As Date
        Friend ReadOnly Property TransactionType As ETransactionType
        Friend ReadOnly Property AccountCode As String
        Friend ReadOnly Property InstrumentCode As String
        Friend ReadOnly Property Rate As Decimal
        Friend ReadOnly Property Amount As Decimal
        Friend ReadOnly Property Description As String
        Friend Property Batch As Integer
        Friend ReadOnly Property ExchangeRate As Single

        Friend ReadOnly Property CurrentInstrumentRate As Decimal
        Friend ReadOnly Property CurrentExchangeRate As Single

        Friend Sub New(id As Integer, transactionDate As Date, transactionType As ETransactionType, accountCode As String,
                       instrumentCode As String, rate As Decimal, amount As Decimal, description As String, batch As Integer,
                       exchangeRate As Single, currentInstrumentRate As Decimal, currentExchangeRate As Single)
            Me.Id = id
            Me.TransactionDate = transactionDate
            Me.TransactionType = transactionType
            Me.AccountCode = accountCode
            Me.InstrumentCode = instrumentCode
            Me.Rate = rate
            Me.Amount = amount
            Me.Description = description
            Me.Batch = batch
            Me.ExchangeRate = exchangeRate

            Me.CurrentInstrumentRate = currentInstrumentRate
            Me.CurrentExchangeRate = currentExchangeRate
        End Sub

        Friend Function CashBalance() As Decimal
            Return If(String.IsNullOrEmpty(InstrumentCode), Amount, 0)
        End Function

        Friend Function Transfers() As Decimal
            Return If(TransactionType = ETransactionType.Transfer, Amount * If(Rate = 0, 1, Rate), 0)
        End Function

        Friend Function CurrentValue() As Decimal
            Return CDec(If(String.IsNullOrEmpty(InstrumentCode), Amount, CurrentInstrumentRate * Amount / If(CurrentExchangeRate > 0, CurrentExchangeRate, 1)))
        End Function

    End Class

End Namespace
