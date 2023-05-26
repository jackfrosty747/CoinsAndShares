Namespace Test
    Friend Class CTransaction
        Public Property Id As Integer
        Public ReadOnly Property TransactionDate As Date
        Public ReadOnly Property TransactionType As ETransactionType
        Public ReadOnly Property AccountCode As String
        Public ReadOnly Property InstrumentCode As String
        Public ReadOnly Property Rate As Decimal
        Public ReadOnly Property Amount As Decimal
        Public ReadOnly Property Description As String
        Public Property Batch As Integer
        Public ReadOnly Property ExchangeRate As Single

        Public ReadOnly Property CurrentInstrumentRate As Decimal
        Public ReadOnly Property CurrentExchangeRate As Single

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
        Public ReadOnly Property Sterling() As Decimal
            Get
                Return If(String.IsNullOrEmpty(InstrumentCode), Amount, Amount * Rate)
            End Get
        End Property
        Public ReadOnly Property AmountDisplay() As String
            Get
                Return If(String.IsNullOrEmpty(InstrumentCode), FormatCurrency(Amount), Amount.ToString(FORMAT_QUANTITY))
            End Get
        End Property
    End Class

End Namespace
