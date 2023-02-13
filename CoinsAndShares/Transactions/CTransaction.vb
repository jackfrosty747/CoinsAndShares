Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments

Namespace Transactions
    Friend Class CTransaction
        Friend Property Id As Long
        Friend Property TransDate As Date
        Friend ReadOnly Property TransactionType As ETransactionType
        Friend ReadOnly Property AccountCode As String
        Friend ReadOnly Property InstrumentCode As String
        Friend Property Rate As Decimal
        Friend ReadOnly Property Amount As Decimal
        Friend Property Description As String
        Friend Property Batch As Long
        Friend ReadOnly Property ExchangeRate As Decimal
        Friend Sub New(id As Long, transDate As Date, transactionType As ETransactionType, accountCode As String,
                   instrumentCode As String, rate As Decimal, amount As Decimal, description As String, batch As Long, exchangeRate As Decimal)
            Me.Id = id
            Me.TransDate = transDate
            Me.TransactionType = transactionType
            Me.AccountCode = accountCode
            Me.InstrumentCode = instrumentCode
            Me.Rate = rate
            Me.Amount = amount
            Me.Description = description
            Me.Batch = batch
            Me.ExchangeRate = exchangeRate
        End Sub
        Friend Function GetLocalCurrencyBalance(allInstruments As IEnumerable(Of CInstrument), allCurrencies As IEnumerable(Of CCurrencyDetail)) As Decimal
            Dim cLocal As Decimal
            If String.IsNullOrEmpty(InstrumentCode) Then
                cLocal = Amount
            Else
                Dim instrument = allInstruments.Where(Function(c) c.Code.Equals(InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                Dim rRate As Double = 0
                Dim rExchangeRate As Decimal = 1
                If instrument IsNot Nothing Then
                    rRate = instrument.Rate

                    If Not String.IsNullOrEmpty(instrument.CurrencyCode) Then
                        Dim currency = allCurrencies.Where(Function(c) c.CurrencyCode.Equals(instrument.CurrencyCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                        If currency IsNot Nothing AndAlso currency.CurrencyRate.HasValue AndAlso currency.CurrencyRate.Value > 0 AndAlso currency.CurrencyRate.Value <> 1 Then
                            rExchangeRate = currency.CurrencyRate.Value
                        End If
                    End If
                End If
                cLocal = CDec(rRate * Amount / rExchangeRate)
            End If

            'cLocal = Math.Round(cLocal, 2, MidpointRounding.AwayFromZero)

            ' if we round here, we end up with odd penny errors caused by adding up all transactions
            ' where we might be round more one way than the order

            Return cLocal

        End Function
        Friend Function Sterling() As Decimal
            If String.IsNullOrEmpty(InstrumentCode) Then
                Return Amount
            Else
                Return Amount * Rate
            End If
        End Function

    End Class

End Namespace
