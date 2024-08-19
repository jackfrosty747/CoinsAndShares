Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Instruments

Namespace TWRR
    Friend Class CTwrr

        Private ReadOnly m_commonObjects As CCommonObjects

        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub

        Friend Class TwrrPeriod
            Public Sub New(cashflow As Decimal, endBalance As Decimal)
                Me.Cashflow = cashflow
                Me.EndBalance = endBalance
            End Sub

            Friend Property Cashflow As Decimal
            Friend Property EndBalance As Decimal
        End Class

        Friend Shared Function CalculateTwrr(transactions As IEnumerable(Of Transactions.CTransaction), currentRate As Decimal,
                                             currentExchangeRate As Decimal) As Decimal

            Dim periods = New List(Of TwrrPeriod)
            Dim startingBalance = 0D
            Dim runningQuantity = 0D

            currentExchangeRate = If(currentExchangeRate = 0, 1, currentExchangeRate)

            transactions = transactions.Where(Function(c) c.TransactionType = ETransactionType.Buy Or c.TransactionType = ETransactionType.Sell)

            For Each transaction In transactions.OrderBy(Function(c) c.TransDate)
                Dim transExchRate = If(transaction.ExchangeRate = 0, 1, transaction.ExchangeRate)
                Dim cashFlow = Math.Round(transaction.Amount * transaction.Rate / transExchRate, 2)
                runningQuantity += transaction.Amount
                Dim balAtEndOfPeriod = Math.Round(runningQuantity * transaction.Rate / transExchRate, 2)
                If balAtEndOfPeriod <= 0 Then
                    periods.Clear()
                    startingBalance = 0
                    runningQuantity = 0 ' Should be zero - but clear in case of rounding 
                Else
                    If startingBalance = 0 Then
                        startingBalance = cashFlow
                    Else
                        periods.Add(New TwrrPeriod(cashFlow, balAtEndOfPeriod))
                    End If
                End If
            Next

            If startingBalance <= 0 Then
                Return 0
            End If

            periods.Add(New TwrrPeriod(0, runningQuantity * currentRate / currentExchangeRate))

            Dim twrr = CalculateTwrr(startingBalance, periods)

            Return twrr

        End Function

        'Friend Function CalculateTwrr(accountCode As String, instrumentCode As String) As Decimal

        '    If String.IsNullOrEmpty(accountCode) Then
        '        Throw New ArgumentNullException(NameOf(accountCode))
        '    ElseIf String.IsNullOrEmpty(instrumentCode) Then
        '        Throw New ArgumentNullException(NameOf(instrumentCode))
        '    End If

        '    Dim accounts = New CAccounts(m_commonObjects)
        '    Dim account = accounts.GetAll.SingleOrDefault(Function(c) c.AccountCode.Equals(accountCode, StringComparison.CurrentCultureIgnoreCase))

        '    If account Is Nothing Then
        '        Throw New Exception("Account not found")
        '    End If

        '    Dim allTransactions = account.Transactions

        '    Dim instrumentTransactions = allTransactions.Where(Function(c) c.InstrumentCode.Equals(instrumentCode, StringComparison.CurrentCultureIgnoreCase))
        '    If Not instrumentTransactions.Any Then
        '        Throw New Exception("No transactions found for this instrument in within account")
        '    End If

        '    Dim instruments = New CInstruments(m_commonObjects)
        '    Dim instrument = instruments.GetAll.SingleOrDefault(Function(c) c.Code.Equals(instrumentCode, StringComparison.CurrentCultureIgnoreCase))

        '    Return CalculateTwrr(instrumentTransactions, instrument.Rate)

        'End Function

        Friend Shared Function CalculateTwrr(startBalance As Decimal, periods As IEnumerable(Of TwrrPeriod)) As Decimal

            ' Provide the starting balance (cannot be zero)
            ' Then, for every deposit or withdrawal, provide the cashflow and balance after that cashflow.
            ' The last period will probably have no cashflow.

            ' Example
            ' £100 investment.
            ' has risen to £110.  Then we deposit another £50, making £160.  
            ' has risen to £170.  We withdraw £10, making £160
            ' then, at end of analysis period, the value is £180.

            ' Starting: 100
            ' Cashflow 50, Balance 160
            ' Cashflow -10, Balance 160
            ' Cashflow 0, Balance 180

            If startBalance = 0D Then
                Throw New ArgumentException("Starting balance cannot be zero.")
            End If

            Dim previousEndBalance As Decimal = startBalance
            Dim twrr As Decimal = 1D
            Dim hasActiveInvestment As Boolean = True

            For Each period In periods
                If previousEndBalance = 0D Then
                    ' Skip the periods where the balance is zero
                    hasActiveInvestment = False
                    ' If the investment is bought again, reset calculation from here
                    If period.EndBalance > 0D Then
                        previousEndBalance = period.EndBalance
                        hasActiveInvestment = True
                    End If
                    Continue For
                End If

                If hasActiveInvestment Then
                    Dim endBalanceBeforeCashflow = period.EndBalance - period.Cashflow
                    Dim periodReturn = endBalanceBeforeCashflow / previousEndBalance
                    twrr *= periodReturn
                    previousEndBalance = period.EndBalance
                End If
            Next

            ' If no active investment period was found, return 0 indicating no valid TWRR can be calculated
            If Not hasActiveInvestment Then
                Return 0D
            End If

            twrr -= 1D

            Return twrr

        End Function

    End Class


End Namespace
