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

            LblTwrr.Text = twrr.ToString

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
                ' Example
                ' £100 investment.
                ' has risen to £110.  Then we deposit another £50, making £160.  
                ' has risen to £170.  We withdraw £10, making £160
                ' then, at end of analysis period, the value is £180.

                ' Specify £100 as starting balance.  Then we take a valuation BEFORE any cashflow, and include the cashflow to include next
                ' 0 cashflow  endbalance £110
                ' 50 cashflow endbalance 170
                ' -10 cashflow endbalance £180
                '   = 31.5%

                If startBalance = 0D Then
                    Throw New ArgumentException("Starting balance cannot be zero.")
                End If

                Dim previousEndBalance As Decimal = startBalance
                Dim product As Decimal = 1D

                For Each period In periods
                    ' Calculate the return for this period
                    Dim periodReturn As Decimal
                    ' Return is based on how the end balance grows relative to the previous period's end balance
                    periodReturn = (period.EndBalance - (previousEndBalance + period.Cashflow)) / (previousEndBalance + period.Cashflow)

                    ' Update the product of (1 + periodReturn)
                    product *= (1 + periodReturn)

                    ' Update the previousEndBalance for the next period
                    previousEndBalance = period.EndBalance
                Next

                ' TWRR is the product of (1 + return) - 1
                Return (product - 1) * 100 ' Convert to percentage
            End Function
        End Class


    End Class
End Namespace
