Imports System.Globalization
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Instruments

Namespace TWRR
    Friend Class Ftwrr
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            CalculateTwrr()

            AddHandler TxtStartingBalance.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtEndBalance1.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtEndBalance2.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtEndBalance3.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtEndBalance4.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtChange1.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtChange2.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtChange3.TextChanged, AddressOf Txt_TextChanged
            AddHandler TxtChange4.TextChanged, AddressOf Txt_TextChanged

        End Sub
        Private Sub CalculateTwrr()

            Dim periods = New List(Of CTwrr.TwrrPeriod)

            Dim cashflow As Decimal
            Dim endBalance As Decimal

            If Decimal.TryParse(TxtEndBalance1.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, endBalance) AndAlso
                    Decimal.TryParse(TxtChange1.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, cashflow) Then
                periods.Add(New CTwrr.TwrrPeriod(cashflow, endBalance))
            End If

            If Decimal.TryParse(TxtEndBalance2.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, endBalance) AndAlso
                Decimal.TryParse(TxtChange2.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, cashflow) Then
                periods.Add(New CTwrr.TwrrPeriod(cashflow, endBalance))
            End If

            If Decimal.TryParse(TxtEndBalance3.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, endBalance) AndAlso
                Decimal.TryParse(TxtChange3.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, cashflow) Then
                periods.Add(New CTwrr.TwrrPeriod(cashflow, endBalance))
            End If

            If Decimal.TryParse(TxtEndBalance4.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, endBalance) AndAlso
                Decimal.TryParse(TxtChange4.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, cashflow) Then
                periods.Add(New CTwrr.TwrrPeriod(cashflow, endBalance))
            End If

            Dim twrr As Decimal = 0

            Dim startBalance As Decimal
            If Decimal.TryParse(TxtStartingBalance.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, startBalance) Then
                twrr = CTwrr.CalculateTwrr(startBalance, periods)

            End If

            LblTwrr.Text = (twrr * 100).ToString("0.00") & "%"

        End Sub

        Private Sub Txt_TextChanged(sender As Object, e As EventArgs)

            Try
                CalculateTwrr()

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try

        End Sub

        Private Class CTwrr
            Friend Class TwrrPeriod
                Public Sub New(cashflow As Decimal, endBalance As Decimal)
                    Me.Cashflow = cashflow
                    Me.EndBalance = endBalance
                End Sub

                Friend Property Cashflow As Decimal
                Friend Property EndBalance As Decimal
            End Class

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

        Private Sub BtnAccount_Click(sender As Object, e As EventArgs) Handles BtnAccount.Click
            Try
                If TxtAccount.Text.Length = 0 Then
                    Throw New Exception("Enter the account code to calculate")
                ElseIf TxtInstrument.Text.Length = 0 Then
                    Throw New Exception("Enter the instrument to calculate for")
                End If

                Dim accounts = New CAccounts(m_commonObjects)
                Dim account = accounts.GetAll.SingleOrDefault(Function(c) c.AccountCode.Equals(TxtAccount.Text, StringComparison.CurrentCultureIgnoreCase))

                If account Is Nothing Then
                    Throw New Exception("Account not found")
                End If

                Dim allTransactions = account.Transactions

                Dim instrumentTransactions = allTransactions.Where(Function(c) c.InstrumentCode.Equals(TxtInstrument.Text, StringComparison.CurrentCultureIgnoreCase))
                If Not instrumentTransactions.Any Then
                    Throw New Exception("No transactions found for this instrument in within account")
                End If

                Dim startingBalance = 0D
                Dim periods = New List(Of CTwrr.TwrrPeriod)
                Dim lastQuantity As Decimal
                Dim runningTotalQty As Decimal
                Dim runningTotalBalance As Decimal
                For Each transaction In instrumentTransactions.OrderBy(Function(c) c.TransDate)
                    Dim cashflow = transaction.Amount * transaction.Rate

                    runningTotalBalance += cashflow
                    runningTotalQty += transaction.Amount

                    If cashflow <> 0 Then
                        If startingBalance = 0 Then
                            startingBalance = transaction.Amount * transaction.Rate
                        Else
                            Dim endBalance = runningTotalQty * transaction.Rate
                            periods.Add(New CTwrr.TwrrPeriod(cashFlow, endBalance))
                        End If

                        'MsgBox($"Amount: {transaction.Amount},  Rate:  {transaction.Rate}")
                        lastQuantity = transaction.Amount
                    End If
                Next

                Dim instruments = New CInstruments(m_commonObjects)
                Dim instrument = instruments.GetAll.SingleOrDefault(Function(c) c.Code.Equals(TxtInstrument.Text, StringComparison.CurrentCultureIgnoreCase))

                ' Add end record
                periods.Add(New CTwrr.TwrrPeriod(0, lastQuantity * instrument.Rate))

                Dim twrr = CTwrr.CalculateTwrr(startingBalance, periods)

                MessageBox.Show($"TWRR: {twrr * 100:0.00}%")

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class
End Namespace
