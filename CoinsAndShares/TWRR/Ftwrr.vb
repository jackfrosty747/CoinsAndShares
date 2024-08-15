Imports System.Globalization

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


        Private Sub BtnAccount_Click(sender As Object, e As EventArgs) Handles BtnAccount.Click
            Try
                'Dim twrr = New CTwrr(m_commonObjects)
                'Dim rate = twrr.CalculateTwrr(TxtAccount.Text, TxtInstrument.Text)
                'MessageBox.Show($"TWRR: {rate * 100:0.00}%")

                'If TxtAccount.Text.Length = 0 Then
                '    Throw New Exception("Enter the account code to calculate")
                'ElseIf TxtInstrument.Text.Length = 0 Then
                '    Throw New Exception("Enter the instrument to calculate for")
                'End If

                'Dim accounts = New CAccounts(m_commonObjects)
                'Dim account = accounts.GetAll.SingleOrDefault(Function(c) c.AccountCode.Equals(TxtAccount.Text, StringComparison.CurrentCultureIgnoreCase))

                'If account Is Nothing Then
                '    Throw New Exception("Account not found")
                'End If

                'Dim allTransactions = account.Transactions

                'Dim instrumentTransactions = allTransactions.Where(Function(c) c.InstrumentCode.Equals(TxtInstrument.Text, StringComparison.CurrentCultureIgnoreCase))
                'If Not instrumentTransactions.Any Then
                '    Throw New Exception("No transactions found for this instrument in within account")
                'End If

                'Dim periods = New List(Of CTwrr.TwrrPeriod)
                'Dim startingBalance = 0D
                'Dim runningQuantity = 0D

                'For Each transaction In instrumentTransactions.OrderBy(Function(c) c.TransDate)
                '    Dim cashFlow = Math.Round(transaction.Amount * transaction.Rate, 2)
                '    runningQuantity += transaction.Amount
                '    Dim balAtEndOfPeriod = Math.Round(runningQuantity * transaction.Rate, 2)
                '    If balAtEndOfPeriod <= 0 Then
                '        periods.Clear()
                '        startingBalance = 0
                '        runningQuantity = 0 ' Should be zero - but clear in case of rounding 
                '    Else
                '        If startingBalance = 0 Then
                '            startingBalance = cashFlow
                '        Else
                '            periods.Add(New CTwrr.TwrrPeriod(cashFlow, balAtEndOfPeriod))
                '        End If
                '    End If
                'Next

                'Dim instruments = New CInstruments(m_commonObjects)
                'Dim instrument = instruments.GetAll.SingleOrDefault(Function(c) c.Code.Equals(TxtInstrument.Text, StringComparison.CurrentCultureIgnoreCase))

                'periods.Add(New CTwrr.TwrrPeriod(0, runningQuantity * instrument.Rate))

                'Dim twrr = CTwrr.CalculateTwrr(startingBalance, periods)

                'MessageBox.Show($"TWRR: {twrr * 100:0.00}%")

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class
End Namespace
