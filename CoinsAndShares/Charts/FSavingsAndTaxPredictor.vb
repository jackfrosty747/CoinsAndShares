Imports System.ComponentModel
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Transactions
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Charts
    Friend Class FSavingsAndTaxPredictor

        Private ReadOnly m_commonObjects As CCommonObjects

        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.bank.GetHicon)

            ' Get the current date
            Dim currentDate As Date = Date.Today
            ' Calculate the tax year start date based on the current date
            Dim taxYearStart As Date
            If currentDate.Month > 4 Or (currentDate.Month = 4 And currentDate.Day >= 6) Then
                ' If the current date is on or after April 6th, use the current year's April 6th
                taxYearStart = New Date(currentDate.Year, 4, 6)
            Else
                ' If the current date is before April 6th, use the previous year's April 6th
                taxYearStart = New Date(currentDate.Year - 1, 4, 6)
            End If

            DtpTaxYearStart.Value = taxYearStart

            LoadData()

        End Sub

        Private Sub LoadData()

            Dim portionOfYearRemaining As Decimal = (DtpTaxYearStart.Value.Date.AddYears(1) - Now.Date).Days / 365D

            Dim currencies = m_commonObjects.Currencies
            Dim allCurrencies = currencies.GetAll
            Dim allInstruments = m_commonObjects.Instruments.GetAll

            Dim accountTypes = New List(Of EAccountType) From {EAccountType.Bank_Account, EAccountType.Share_Account}

            Dim interestDescription = EDescriptionPresets.Interest.ToString.Replace("_", " ")

            Dim transactions = New CTransactions(m_commonObjects)
            Dim accounts = New CAccounts(m_commonObjects)

            Dim selectedAccounts = accounts.GetAll.Where(Function(c) accountTypes.Contains(c.AccountType))

            Dim selectedAccountCodes = selectedAccounts.Select(Function(c) c.AccountCode)

            Dim all = transactions.GetAll

            ' 1. Get tax earled this tax year so far
            '
            ' Only interest records
            all = all.Where(Function(c) c.Description.Equals(interestDescription, StringComparison.CurrentCultureIgnoreCase))

            ' Only records from this tax year
            all = all.Where(Function(c) c.TransDate.Date > DtpTaxYearStart.Value.Date.AddDays(-1) AndAlso c.TransDate.Date <= Now.Date)

            ' Exclude non taxable and types we're not interested in
            all = all.Where(Function(c) selectedAccountCodes.Any(Function(d) d.Equals(c.AccountCode, StringComparison.CurrentCultureIgnoreCase)))

            all = all.ToList

            Dim allOutput As New List(Of Output)
            For Each account In selectedAccounts
                Dim accountInterest = all.Where(Function(c) c.AccountCode.Equals(account.AccountCode, StringComparison.OrdinalIgnoreCase))
                Dim earnedSoFar = accountInterest.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))
                If earnedSoFar > 0 Then
                    Dim output = New Output(account.AccountCode, account.AccountName, account.CashSavingsRate, account.NonTaxable) With {
                        .SavingsEarnedSoFar = earnedSoFar
                    }
                    allOutput.Add(output)
                End If
            Next

            ' 2. Predict tax to be earnt this tax year
            '
            ' Get cash balance for each account
            Dim cashBalances = From t In transactions.GetAll
                               Where selectedAccountCodes.Any(Function(d) d.Equals(t.AccountCode, StringComparison.CurrentCultureIgnoreCase)) And
                                   String.IsNullOrEmpty(t.InstrumentCode)
                               Group t By t.AccountCode Into Balance = Sum(t.GetLocalCurrencyBalance(allInstruments, allCurrencies))
                               Select AccountCode, Balance

            For Each a In cashBalances.Where(Function(c) c.Balance > 0)
                Dim account = selectedAccounts.First(Function(c) c.AccountCode.Equals(a.AccountCode, StringComparison.CurrentCultureIgnoreCase))
                If account.CashSavingsRate > 0 Then
                    Dim predictedInterestWholeYear = a.Balance / 100 * account.CashSavingsRate
                    Dim predictedInterest = predictedInterestWholeYear * portionOfYearRemaining
                    If predictedInterest > 0 Then
                        Dim output = allOutput.FirstOrDefault(Function(c) c.AccountCode.Equals(a.AccountCode, StringComparison.CurrentCultureIgnoreCase))
                        If output Is Nothing Then
                            output = New Output(account.AccountCode, account.AccountName, account.CashSavingsRate, account.NonTaxable)
                            allOutput.Add(output)
                        End If
                        output.CashBalance = a.Balance
                        output.PredictedInterest = predictedInterest
                    End If
                End If
            Next

            GrdHoldings.DataSource = allOutput.OrderBy(Function(c) c.AccountCode).ToList

            LblTaxable.Text = allOutput.Sum(Function(c) c.TaxableValue).ToString("c2")

            If TxtAllowance.Text.Length = 0 OrElse Not Decimal.TryParse(TxtAllowance.Text, Nothing) Then
                TxtAllowance.Text = "1000"
            End If
            Dim allowance As Decimal = Decimal.Parse(TxtAllowance.Text)

            If TxtTaxRate.Text.Length = 0 OrElse Not Decimal.TryParse(TxtTaxRate.Text, Nothing) Then
                TxtTaxRate.Text = "20"
            End If
            Dim taxRate As Decimal = Decimal.Parse(TxtTaxRate.Text)
            Dim taxableAmount = Math.Max(0D, allOutput.Sum(Function(c) c.TaxableValue) - allowance)
            Dim predictedTax = taxableAmount / 100D * taxRate

            LblToPay.Text = predictedTax.ToString("c2")

        End Sub

        Private Class Output
            Public ReadOnly Property AccountCode As String
            Public ReadOnly Property Name As String
            Public Property SavingsEarnedSoFar As Decimal
            Public Property CashBalance As Decimal
            Public ReadOnly Property InterestRate As Decimal
            Public Property PredictedInterest As Decimal
            Public Property NonTaxable As Boolean
            Public ReadOnly Property TaxableValue As Decimal
                Get
                    If NonTaxable Then
                        Return 0D
                    Else
                        Return SavingsEarnedSoFar + PredictedInterest
                    End If
                End Get
            End Property
            Friend Sub New(accountCode As String, name As String, interestRate As Decimal, nonTaxable As Boolean)
                Me.AccountCode = accountCode
                Me.Name = name
                Me.InterestRate = interestRate
                Me.NonTaxable = nonTaxable
            End Sub
        End Class

        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Cursor = Cursors.WaitCursor
            Try
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub GrdHoldings_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdHoldings.InitializeLayout
            Try
                GridDefaults(e.Layout)

                e.Layout.AutoFitColumns = True

                With e.Layout.Override
                    .AllowAddNew = AllowAddNew.No
                    .AllowDelete = DefaultableBoolean.False
                    .AllowUpdate = DefaultableBoolean.False
                    .RowSelectors = DefaultableBoolean.False
                    .CellClickAction = CellClickAction.RowSelect
                End With

                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case NameOf(Output.AccountCode)
                            col.Header.Caption = "Account Code"
                        Case NameOf(Output.Name)
                            col.Header.Caption = "Name"
                        Case NameOf(Output.InterestRate)
                            col.Header.Caption = "Cur Rate"
                            col.Format = "00.00"
                        Case NameOf(Output.CashBalance)
                            col.Header.Caption = "Balance"
                            col.Format = "c2"
                            col.CellAppearance.TextHAlign = HAlign.Right
                        Case NameOf(Output.SavingsEarnedSoFar)
                            col.Header.Caption = "So Far"
                            col.Format = "c2"
                            col.CellAppearance.TextHAlign = HAlign.Right
                        Case NameOf(Output.PredictedInterest)
                            col.Header.Caption = "Predicted"
                            col.Format = "c2"
                            col.CellAppearance.TextHAlign = HAlign.Right
                        Case NameOf(Output.TaxableValue)
                            col.Header.Caption = "Taxable"
                            col.Format = "c2"
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.CellAppearance.FontData.Bold = DefaultableBoolean.True
                            col.CellAppearance.ForeColor = Color.Red
                        Case Else
                            col.Hidden = True
                    End Select
                Next

                With e.Layout.Bands(0)
                    .Columns(NameOf(Output.TaxableValue)).Header.VisiblePosition = 0
                    .Columns(NameOf(Output.PredictedInterest)).Header.VisiblePosition = 0
                    .Columns(NameOf(Output.SavingsEarnedSoFar)).Header.VisiblePosition = 0
                    .Columns(NameOf(Output.CashBalance)).Header.VisiblePosition = 0
                    .Columns(NameOf(Output.InterestRate)).Header.VisiblePosition = 0
                    .Columns(NameOf(Output.Name)).Header.VisiblePosition = 0
                    .Columns(NameOf(Output.AccountCode)).Header.VisiblePosition = 0
                End With

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class

End Namespace
