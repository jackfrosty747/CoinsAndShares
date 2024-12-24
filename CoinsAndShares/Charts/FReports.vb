Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.DataVisualization.Charting
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Snapshots
Imports CoinsAndShares.Transactions

Namespace Charts
    Friend Class FReports : Implements IDataRefresh

        Const DEFAULT_GROUP_PERCENT = 2

        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_fFormLoaded As Boolean
        Friend Sub New(commonObjects As CCommonObjects)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            Icon = Icon.FromHandle(My.Resources.chart.GetHicon)
            TxtHoldingsGroupPc.Text = DEFAULT_GROUP_PERCENT.ToString
            Dim accounts = commonObjects.Accounts
            Dim accountsToShow = accounts.GetAll
            accountsToShow = accountsToShow.Where(Function(c) c.AccountType = EAccountType.Crypto Or c.AccountType = EAccountType.Share_Account)
            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccountPlPerInstrument, accountsToShow, commonObjects)
            CDropdowns.CAccountsDropdown.SetupAccountsDropdown(CmbAccountHoldings, accountsToShow, commonObjects)
            DtpPlDateFrom.Value = Now.AddMonths(-1).Date
            DtpPlDateTo.Value = Now.Date
            DtpMiningDateFrom.Value = Now.AddMonths(-1).Date
            DtpMiningDateTo.Value = Now.Date
            ChkReduceByElectricityCost.Checked = True
            EnableDisablePlDateRange()
            EnableDisableMiningDateRange()
            LoadData()
            m_fFormLoaded = True
        End Sub
        Private Sub RefreshData() Implements IDataRefresh.RefreshData
            LoadData()
        End Sub
        Private Sub LoadData()
            Dim transactions = m_commonObjects.Transactions
            Dim instruments = m_commonObjects.Instruments
            Dim currencies = m_commonObjects.Currencies
            Dim accounts = m_commonObjects.Accounts
            Dim allTransactions = transactions.GetAll()
            Dim allInstruments = instruments.GetAll()
            Dim allCurrencies = currencies.GetAll()
            Dim allAccounts = accounts.GetAll()

            LoadDataPl()
            LoadDataHoldings(allTransactions, allInstruments, allCurrencies)
            LoadDataPlPerInstrument(allTransactions, allInstruments, allCurrencies)
            LoadMining(allTransactions, allInstruments, allCurrencies)
            LoadNetworks(allTransactions, allInstruments, allCurrencies, allAccounts)
            LoadSavings(allAccounts, allInstruments, allCurrencies)

        End Sub

        Private Sub LoadSavings(allAccounts As IEnumerable(Of CAccount), allInstruments As IEnumerable(Of CInstrument), allCurrencies As IEnumerable(Of CCurrencyDetail))

            Dim accountSummaries = allAccounts.Where(Function(c) c.CashSavingsRate > 0).Select(Function(account) New With {
                .Code = account.AccountCode,
                .Name = account.AccountName,
                .Rate = account.CashSavingsRate,
                .Balance = account.GetLocalCurrencyBalance(allInstruments, allCurrencies),
                .YearlyInterest = .Balance / 100 * .Rate,
                .MonthlyInterest = .YearlyInterest / 12,
                .WeeklyInterest = .YearlyInterest / 52,
                .DailyInterest = .YearlyInterest / 365
            }).ToList()

            ' Clear previous data
            ChartSavings.Series.Clear()
            ChartSavings.ChartAreas.Clear()

            ' Add a new chart area
            Dim chartArea As New ChartArea("MainArea")
            With chartArea
                .AxisX.Title = "Accounts"
                .AxisX.Interval = 1
                .AxisX.LabelStyle.Angle = -45 ' Rotate labels for better readability
                .AxisY.Title = "Balance"
                .AxisY.LabelStyle.Format = "C2" ' Format Y-axis as currency
            End With
            ChartSavings.ChartAreas.Add(chartArea)

            ' Add a new series for the bar chart
            Dim series As New Series("Balances")
            With series
                .ChartType = SeriesChartType.Bar
                .IsValueShownAsLabel = True ' Show balance as labels on the bars
                .LabelFormat = "C2" ' Format labels as currency
            End With
            ChartSavings.Series.Add(series)

            ' Sort accountSummaries by balance in descending order
            Dim sortedSummaries = accountSummaries.OrderByDescending(Function(a) a.Balance).ToList()

            ' Add data points to the series
            For Each account In sortedSummaries
                Dim dataPoint As New DataPoint()
                dataPoint.SetValueXY($"{account.Code} ({account.Name})", account.Balance)
                dataPoint.Label = $"{account.Balance:C2}{Environment.NewLine}Rate: {account.Rate / 100:P2}{Environment.NewLine}Yearly:{account.YearlyInterest:C2} Monthly:{account.MonthlyInterest:C2} Weekly:{account.WeeklyInterest:C2} Daily:{account.DailyInterest:C2}"
                series.Points.Add(dataPoint)
            Next

            ' Calculate the weighted average rate
            Dim totalBalance = accountSummaries.Sum(Function(account) account.Balance)
            Dim weightedSum = accountSummaries.Sum(Function(account) account.Rate * account.Balance)

            ' Calculate the weighted average rate
            Dim weightedAverageRate = If(totalBalance > 0, weightedSum / totalBalance, 0)

            ' Customize appearance if needed
            ChartSavings.Titles.Clear()
            With ChartSavings.Titles.Add($"Account Balances {totalBalance:c2} (Avg Rate: {weightedAverageRate:##0.00}%)")
                .Font = New Font("Arial", 14, FontStyle.Bold)
            End With

            ' Subtitle
            With ChartSavings.Titles.Add($"Yearly:{accountSummaries.Sum(Function(c) c.YearlyInterest):C2}  Monthly:{accountSummaries.Sum(Function(c) c.MonthlyInterest):C2}  Weekly:{accountSummaries.Sum(Function(c) c.WeeklyInterest):C2}  Daily:{accountSummaries.Sum(Function(c) c.DailyInterest):C2}")
                .Font = New Font("Arial", 10, FontStyle.Italic)
                .Alignment = ContentAlignment.TopCenter  ' Align the subtitle at the center
            End With

        End Sub

        Private Sub LoadNetworks(allTransactions As IEnumerable(Of CTransaction), allInstruments As IEnumerable(Of CInstrument),
                                 allCurrencies As IEnumerable(Of CCurrencyDetail), allAccounts As IEnumerable(Of CAccount))

            Const COL1 = 35
            Const COL2 = 15
            Const COL3 = 8
            Const COL4 = 15
            Const COL5 = 15
            Const COL6 = 8

            Const UNDER = "________"

            Dim out As New StringBuilder

            out.AppendLine("NETWORK ANALYSIS")
            out.AppendLine("________________")

            Dim allNetworkIds = allAccounts.Select(Function(c) c.NetworkId.ToUpper).Distinct.Where(Function(c) Not String.IsNullOrEmpty(c))

            For Each sNetworkId In allNetworkIds.OrderBy(Function(c) c)
                ' Network header
                out.AppendLine(LSet($"    NETWORK {sNetworkId}", COL1) & RSet("TRANSFERS", COL2) & RSet("", COL3) & RSet("ASSETS", COL4) & RSet("P/L", COL5))
                out.AppendLine(LSet("", COL1) & RSet(UNDER, COL2) & RSet("", COL3) & RSet(UNDER, COL4) & RSet(UNDER, COL4))

                Dim cNetworkTransfers As Decimal = 0
                Dim cNetworkAssets As Decimal = 0
                For Each account In allAccounts.Where(Function(c) c.NetworkId.Equals(sNetworkId, StringComparison.InvariantCultureIgnoreCase)).OrderBy(Function(c) c.AccountCode)
                    Dim accountTransactions = allTransactions.Where(Function(c) c.AccountCode.Equals(account.AccountCode, StringComparison.CurrentCultureIgnoreCase)).ToList

                    Dim cAccountTransfers = accountTransactions.Where(Function(c) c.TransactionType = ETransactionType.Transfer).Sum(Function(c) c.Amount)

                    Dim sInOut = String.Empty
                    If cAccountTransfers > 0 Then
                        sInOut = " In"
                    ElseIf cAccountTransfers < 0 Then
                        sInOut = " Out"
                    End If

                    ' Calculate assets
                    Dim accountAnalysis = CTransactions.Analyse(accountTransactions, allInstruments, allCurrencies)
                    Dim cAccountAssets = accountAnalysis.CurrentValue()

                    ' AccountP/L
                    Dim cAccountPl = cAccountAssets - cAccountTransfers
                    Dim sPl = String.Empty
                    If cAccountPl > 0 Then
                        sPl = " PROFIT"
                    ElseIf cAccountPl < 0 Then
                        sPl = " LOSS"
                    End If

                    Dim sAccountName = Regex.Replace(account.AccountName, "[^\u0000-\u007F]+", String.Empty)

                    ' Account output
                    out.AppendLine(LSet($"        {account.AccountCode} ({sAccountName})", COL1) & RSet(cAccountTransfers.ToString("c2"), COL2) & LSet(sInOut, COL3) & RSet(cAccountAssets.ToString("c2"), COL4) & RSet(cAccountPl.ToString("c2"), COL5) & LSet(sPl, COL6))

                    cNetworkTransfers += cAccountTransfers
                    cNetworkAssets += cAccountAssets
                Next

                Dim cNetworkdPl = cNetworkAssets - cNetworkTransfers
                Dim sNetworkPl = String.Empty
                If cNetworkdPl > 0 Then
                    sNetworkPl = " PROFIT"
                ElseIf cNetworkdPl < 0 Then
                    sNetworkPl = " LOSS"
                End If

                ' Network footer
                out.AppendLine(LSet("", COL1) & RSet(UNDER, COL2) & RSet("", COL3) & RSet(UNDER, COL4) & RSet(UNDER, COL4))
                out.AppendLine(LSet($"    NETWORK TOTALS: {sNetworkId}", COL1) & RSet(cNetworkTransfers.ToString("c2"), COL2) & RSet("", COL3) & RSet(cNetworkAssets.ToString("c2"), COL4) & RSet(cNetworkdPl.ToString("c2"), COL5) & LSet(sNetworkPl, COL6))
                out.AppendLine()
            Next

            out.AppendLine(UNDER)
            out.AppendLine("END")

            TxtNetworks.Text = out.ToString

        End Sub

        Private Sub LoadMining(allTransactions As IEnumerable(Of CTransaction), allInstruments As IEnumerable(Of CInstrument),
                                       allCurrencies As IEnumerable(Of CCurrencyDetail))

            Const SERIES_MINING = "Mining"
            Const PART_DESCRIPTION = "Mining" ' Used to match transactions
            Const SERIES_MINING_AVERAGE = "Mining Average"


            Dim iRollingDayAvDays As Integer
            If Not Integer.TryParse(CmbMiningRollingDays.Text, iRollingDayAvDays) Then
                iRollingDayAvDays = 7
            End If



            ' First Chart
            Try
                ChartMiningByDate.Series.Clear()
                ChartMiningByDate.Titles.Clear()

                With ChartMiningByDate.Titles.Add($"Money Earned Per Day")
                    .Font = New Font(Font, FontStyle.Bold)
                End With
                With ChartMiningByDate.Titles.Add($"Including fees, and using the crypto rate at the time.  All mining transactions and fees containing {PART_DESCRIPTION} in desc.  Roll av. {iRollingDayAvDays} days")
                    .Font = New Font(Font, FontStyle.Italic)
                End With
                ChartMiningByDate.AntiAliasing = AntiAliasingStyles.All
                With ChartMiningByDate.Series.Add(SERIES_MINING)
                    .BorderWidth = 1
                    .ChartType = SeriesChartType.Line
                    .Color = Color.LightBlue
                End With
                ChartMiningByDate.Series(0).XValueType = ChartValueType.Date
                With ChartMiningByDate.Series.Add(SERIES_MINING_AVERAGE)
                    .BorderWidth = 3
                    .ChartType = SeriesChartType.Line
                    .Color = Color.DarkBlue
                End With
                ChartMiningByDate.Series(1).XValueType = ChartValueType.Date

                With ChartMiningByDate.ChartAreas(0)
                    .AxisX.Interval = 7
                    .AxisX.Title = "Week"
                    .AxisX.LabelAutoFitMaxFontSize = 8
                    .AxisX.MajorGrid.LineColor = Color.LightGray

                    Using sl As New StripLine
                        sl.BorderWidth = 2
                        sl.BorderColor = Color.DarkGray
                        sl.Interval = 1
                        sl.IntervalType = DateTimeIntervalType.Months
                        .AxisX.StripLines.Add(sl)
                    End Using

                    .AxisY.LabelStyle.Format = "c2"
                    .AxisY.LabelAutoFitMaxFontSize = 8
                    .AxisY.Title = "Earnings"
                    .AxisY.MajorGrid.LineColor = Color.LightGray
                End With

            Catch ex As Exception
                Throw
            End Try

            ' Second Chart
            Try
                ChartMiningCumulative.Series.Clear()
                ChartMiningCumulative.Titles.Clear()

                With ChartMiningCumulative.Titles.Add($"Money Earned Cumulative")
                    .Font = New Font(Font, FontStyle.Bold)
                End With
                With ChartMiningCumulative.Titles.Add($"Including fees, and using the crypto rate at the time.  All mining transactions and fees containing {PART_DESCRIPTION} in desc.")
                    .Font = New Font(Font, FontStyle.Italic)
                End With
                ChartMiningCumulative.AntiAliasing = AntiAliasingStyles.All
                With ChartMiningCumulative.Series.Add(SERIES_MINING)
                    .BorderWidth = 3
                    .ChartType = SeriesChartType.Line
                End With
                ChartMiningCumulative.Series(0).XValueType = ChartValueType.Date

                With ChartMiningCumulative.ChartAreas(0)
                    .AxisX.Interval = 7
                    .AxisX.Title = "Week"
                    .AxisX.LabelAutoFitMaxFontSize = 8
                    .AxisX.MajorGrid.LineColor = Color.LightGray

                    Using sl As New StripLine
                        sl.BorderWidth = 2
                        sl.BorderColor = Color.DarkGray
                        sl.Interval = 1
                        sl.IntervalType = DateTimeIntervalType.Months
                        .AxisX.StripLines.Add(sl)
                    End Using

                    .AxisY.LabelStyle.Format = "c2"
                    .AxisY.LabelAutoFitMaxFontSize = 8
                    .AxisY.Title = "Earnings"
                    .AxisY.MajorGrid.LineColor = Color.LightGray

                End With
            Catch ex As Exception
                Throw
            End Try





            Dim miningTrans = allTransactions.Where(Function(c) c.TransactionType = ETransactionType.Mining OrElse ContainsIgnoreCase(c.Description, PART_DESCRIPTION))
            If ChkMiningDateRange.Checked Then
                miningTrans = miningTrans.Where(Function(c) c.TransDate.Date >= DtpMiningDateFrom.Value.Date And c.TransDate.Date <= DtpMiningDateTo.Value.Date)
            End If

            miningTrans = miningTrans.ToList

            If Not miningTrans.Any Then
                Return
            End If

            Dim miningDayTotals As New List(Of MiningVal)
            Dim theDate = miningTrans.Min(Function(c) c.TransDate.Date)
            Do Until theDate.Date > Now.Date
                Dim theVal = miningTrans.Where(Function(c) c.TransDate.Date = theDate.Date).Sum(Function(c) c.Amount * c.Rate)
                miningDayTotals.Add(New MiningVal(theDate, theVal))
                theDate = theDate.AddDays(1)
            Loop


            Dim cCumValue As Decimal

            Dim electricity = m_commonObjects.Electricity
            Dim allElectricity = electricity.GetAll

            Dim cElecTotal As Decimal

            For i = 0 To miningDayTotals.Count - 1
                Dim m = miningDayTotals(i)

                Dim cMiningDayCost As Decimal = 0
                If ChkReduceByElectricityCost.Checked Then
                    Dim e = allElectricity.Where(Function(c) c.DateFrom.Date <= m.PaymentDate).OrderByDescending(Function(c) c.DateFrom).FirstOrDefault
                    If e IsNot Nothing Then
                        cMiningDayCost = e.DailyRate
                    End If
                End If
                cElecTotal += cMiningDayCost

                Dim cDayValue = m.PaymentValue - cMiningDayCost

                ChartMiningByDate.Series(SERIES_MINING).Points.AddXY(m.PaymentDate.ToOADate(), cDayValue)

                Try
                    Dim iNeighboursRequired = CInt((iRollingDayAvDays - 1) / 2)
                    If i >= iNeighboursRequired AndAlso i < miningDayTotals.Count - iNeighboursRequired Then
                        Dim rAverage As Decimal = 0
                        Dim iBlockFirst As Integer = i - iNeighboursRequired
                        For j = iBlockFirst To iBlockFirst + iRollingDayAvDays - 1
                            rAverage += miningDayTotals(j).PaymentValue
                        Next
                        rAverage /= iRollingDayAvDays
                        rAverage -= cMiningDayCost
                        ChartMiningByDate.Series(SERIES_MINING_AVERAGE).Points.AddXY(m.PaymentDate.ToOADate(), rAverage)
                    End If
                Catch ex As Exception
                    Throw
                End Try


                cCumValue += cDayValue
                Dim iPoint = ChartMiningCumulative.Series(SERIES_MINING).Points.AddXY(m.PaymentDate.ToOADate(), cCumValue)
            Next


            'For Each m In miningByDate
            '    Dim cDayValue = m.value - cMiningDailyCost

            '    ChartMiningByDate.Series(SERIES_MINING).Points.AddXY(m.Date.ToOADate(), cDayValue)

            '    cCumValue += cDayValue
            '    Dim iPoint = ChartMiningCumulative.Series(SERIES_MINING).Points.AddXY(m.Date.ToOADate(), cCumValue)
            'Next




            ' Summary per currency
            Const COL_WIDTH = 12
            Dim totalMinedPerCurrency = From trans In miningTrans
                                        Where 1 = 1
                                        Order By trans.InstrumentCode
                                        Group By trans.InstrumentCode
                                        Into myGroup = Group, totalAmount = Sum(trans.Amount)
            Dim sOut =
                "TOTALS MINED AT CURRENT VALUES" & vbNewLine &
                LSet("CURRENCY", COL_WIDTH) & RSet("MINED", COL_WIDTH) & RSet("FEES", COL_WIDTH) & RSet("TOTAL", COL_WIDTH) & RSet("ELEC", COL_WIDTH) & RSet("NET", COL_WIDTH)
            Dim cGrandTotalMined As Decimal
            Dim cGrandTotalFees As Decimal
            Dim cGrandTotal As Decimal
            For Each t In totalMinedPerCurrency
                Dim cMinedAmount = t.myGroup.Where(Function(c) c.TransactionType = ETransactionType.Mining).Sum(Function(c) c.Amount)
                Dim cFeeAmount = t.myGroup.Where(Function(c) c.TransactionType = ETransactionType.Fee).Sum(Function(c) c.Amount)
                Dim cTotalAmount = cMinedAmount + cFeeAmount

                Dim instrument = allInstruments.First(Function(c) c.Code.Equals(t.InstrumentCode, StringComparison.InvariantCulture))

                Dim cMinedValue = cMinedAmount * instrument.Rate
                Dim cFeeValue = cFeeAmount * instrument.Rate
                Dim cTotalValue = cTotalAmount * instrument.Rate

                Dim sLine = LSet("+ " & instrument.Description, COL_WIDTH) & RSet(cMinedValue.ToString("c2"), COL_WIDTH) & RSet(cFeeValue.ToString("c2"), COL_WIDTH) & RSet(cTotalValue.ToString("c2"), COL_WIDTH)
                sOut &= vbNewLine & sLine

                cGrandTotalMined += cMinedValue
                cGrandTotalFees += cFeeValue
                cGrandTotal += cTotalValue
            Next
            Dim minDateUsed = miningTrans.Min(Function(c) c.TransDate)
            Dim maxDateUsed = miningTrans.Max(Function(c) c.TransDate)
            Dim iDays = DateDiff(DateInterval.Day, minDateUsed, maxDateUsed) + 1
            'Dim cElecTotal = iDays * cMiningDailyCost
            sOut &= vbNewLine &
                LSet("", COL_WIDTH) & RSet("-------", COL_WIDTH) & RSet("-------", COL_WIDTH) & RSet("-------", COL_WIDTH) & RSet("-------", COL_WIDTH) & RSet("-------", COL_WIDTH) & vbNewLine &
                LSet("", COL_WIDTH) & RSet(cGrandTotalMined.ToString("c2"), COL_WIDTH) & RSet(cGrandTotalFees.ToString("c2"), COL_WIDTH) & RSet(cGrandTotal.ToString("c2"), COL_WIDTH) & RSet(cElecTotal.ToString("c2"), COL_WIDTH) & RSet((cGrandTotal - cElecTotal).ToString("c2"), COL_WIDTH)
            LblMiningSummary.Font = New Font("Lucida Console", 8)
            LblMiningSummary.Text = sOut
        End Sub

        Private Class MiningVal
            Public Sub New(paymentDate As Date, paymentValue As Decimal)
                Me.PaymentDate = paymentDate
                Me.PaymentValue = paymentValue
            End Sub

            Friend Property PaymentDate As Date
            Friend Property PaymentValue As Decimal
        End Class

        Private Sub LoadDataPlPerInstrument(allTransactions As IEnumerable(Of CTransaction), allInstruments As IEnumerable(Of CInstrument),
                                     allCurrencies As IEnumerable(Of CCurrencyDetail))

            Const SERIES_INSTRUMENT = "Instrument"

            ChartPlPerInstrument.Series.Clear()

            ChartPlPerInstrument.Titles.Clear()
            With ChartPlPerInstrument.Titles.Add("P & L Per Instrument")
                .Font = New Font(Font, FontStyle.Bold)
            End With
            With ChartPlPerInstrument.Titles.Add("Instruments only, not inc. dividend, fees etc")
                .Font = New Font(Font, FontStyle.Italic)
            End With
            ChartPlPerInstrument.AntiAliasing = AntiAliasingStyles.All

            With ChartPlPerInstrument.Series.Add(SERIES_INSTRUMENT)
                .BorderWidth = 3
                .ChartType = SeriesChartType.Column
                .IsValueShownAsLabel = True
                .LabelFormat = "0"
                .Font = New Font(.Font.FontFamily, 7)
                .IsVisibleInLegend = False
            End With

            With ChartPlPerInstrument.ChartAreas(0)
                .AxisX.Interval = 1
                .AxisX.Title = "Instrument"
                .AxisX.LabelAutoFitMaxFontSize = 8
                .AxisX.MajorGrid.LineColor = Color.LightGray

                .AxisY.LabelStyle.Format = "c2"
                .AxisY.LabelAutoFitMaxFontSize = 8
                .AxisY.Title = "P/L"
                .AxisY.MajorGrid.LineColor = Color.LightGray
            End With

            Dim analysis = CTransactions.Analyse(allTransactions, allInstruments, allCurrencies)
            Dim allAnalysis = analysis.InstrumentAnalysis()

            If CmbAccountPlPerInstrument.Text.Length > 0 Then
                ' We only want to see instruments that are used by the account selected
                ' Get distinct instrument codes used by that account
                Dim instrumentCodesOnly = allTransactions.Where(Function(c)
                                                                    Return Not String.IsNullOrEmpty(c.InstrumentCode) AndAlso c.AccountCode.Equals(CmbAccountPlPerInstrument.Text)
                                                                End Function).Select(Function(c) c.InstrumentCode.ToUpper).Distinct
                ' Filter analysis to show only those codes
                allAnalysis = allAnalysis.Where(Function(c) instrumentCodesOnly.Contains(c.InstrumentCode.ToUpper))
            End If

            Dim analysisOfRequiredType = allAnalysis.Where(Function(c)
                                                               Dim i = allInstruments.Where(Function(d) d.Code.Equals(c.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                                                               Return i IsNot Nothing AndAlso (
                                                                    OptPlPerInstrumentTypeAll.Checked OrElse
                                                                    (OptPlPerInstrumentCrypto.Checked AndAlso i.InstrumentType = EInstrumentType.Crypto) OrElse
                                                                    (OptPlPerInstrumentShares.Checked AndAlso i.InstrumentType = EInstrumentType.Share)
                                                                )
                                                           End Function).OrderByDescending(Function(c) c.CurrentWorth)

            '   Dim iBar As Integer
            For Each instrumentAnalysis In analysisOfRequiredType.OrderByDescending(Function(c) c.Pl)
                '  iBar += 1
                With ChartPlPerInstrument.Series(SERIES_INSTRUMENT).Points.Add(instrumentAnalysis.Pl)
                    .AxisLabel = instrumentAnalysis.InstrumentCode
                    .Color = If(instrumentAnalysis.Pl > 0, Color.Green, Color.Red)
                End With
            Next

        End Sub

        Private Sub LoadDataPl()

            Const SERIES_COINS = "Coins"
            Const SERIES_SHARES = "Shares"
            Const SERIES_TOTAL = "Total"

            ChartPl.Series.Clear()

            Dim snapshots As New CSnapshots(m_commonObjects)

            Dim all = snapshots.GetAll

            If ChkPlDateRangeEnable.Checked Then
                all = all.Where(Function(c) c.SnapshotDate.Date >= DtpPlDateFrom.Value.Date AndAlso c.SnapshotDate.Date <= DtpPlDateTo.Value.Date)
            End If

            ChartPl.Titles.Clear()
            With ChartPl.Titles.Add("Coins and Shares Profit")
                .Font = New Font(Font, FontStyle.Bold)
            End With
            With ChartPl.Titles.Add("Instruments only, not inc. dividend, fees etc")
                .Font = New Font(Font, FontStyle.Italic)
            End With
            ChartPl.AntiAliasing = AntiAliasingStyles.All

            With ChartPl.ChartAreas(0)
                .AxisX.Interval = 1
                .AxisX.IntervalType = DateTimeIntervalType.Months
                .AxisX.Title = "Snapshot Date"
                .AxisX.LabelAutoFitMaxFontSize = 8
                .AxisX.MajorGrid.LineColor = Color.LightGray

                Using sl As New StripLine
                    'sl.StripWidth = 2
                    sl.BorderWidth = 2
                    sl.BorderColor = Color.DarkGray
                    sl.Interval = 1
                    sl.IntervalType = DateTimeIntervalType.Months
                    .AxisX.StripLines.Add(sl)
                End Using

                .AxisY.LabelStyle.Format = "c2"
                .AxisY.LabelAutoFitMaxFontSize = 8
                .AxisY.Title = "P/L"
                .AxisY.MajorGrid.LineColor = Color.LightGray
            End With

            If OptPlAll.Checked Or OptPlShares.Checked Then
                With ChartPl.Series.Add(SERIES_SHARES)
                    .BorderWidth = 3
                    .ChartType = SeriesChartType.Line
                End With
            End If
            If OptPlAll.Checked Or OptPlCrypto.Checked Then
                With ChartPl.Series.Add(SERIES_COINS)
                    .BorderWidth = 3
                    .ChartType = SeriesChartType.Line
                End With
            End If
            If OptPlAll.Checked Then
                With ChartPl.Series.Add(SERIES_TOTAL)
                    .BorderWidth = 3
                    .ChartType = SeriesChartType.Line
                End With
            End If
            ChartPl.Series(0).XValueType = ChartValueType.Date


            For Each snapshot In all
                If OptPlAll.Checked Or OptPlShares.Checked Then
                    ChartPl.Series(SERIES_SHARES).Points.AddXY(snapshot.SnapshotDate.ToOADate(), snapshot.Shares)
                End If
                If OptPlAll.Checked Or OptPlCrypto.Checked Then
                    ChartPl.Series(SERIES_COINS).Points.AddXY(snapshot.SnapshotDate.ToOADate(), snapshot.Coins)
                End If
                If OptPlAll.Checked Then
                    ChartPl.Series(SERIES_TOTAL).Points.AddXY(snapshot.SnapshotDate.ToOADate(), snapshot.Coins + snapshot.Shares)
                End If
            Next

        End Sub

        Private Sub LoadDataHoldings(allTransactions As IEnumerable(Of CTransaction), allInstruments As IEnumerable(Of CInstrument),
                                     allCurrencies As IEnumerable(Of CCurrencyDetail))

            Const SERIES_HOLDINGS = "holdings"

            Dim rGroupPc As Decimal
            If Not Decimal.TryParse(TxtHoldingsGroupPc.Text, rGroupPc) OrElse rGroupPc <= 0 OrElse rGroupPc >= 100 Then
                rGroupPc = DEFAULT_GROUP_PERCENT
            End If

            ChartHoldings.Titles.Clear()
            With ChartHoldings.Titles.Add("Holdings")
                .Font = New Font(Font, FontStyle.Bold)
            End With
            ChartHoldings.AntiAliasing = AntiAliasingStyles.All

            ChartHoldings.Series.Clear()
            With ChartHoldings.Series.Add(SERIES_HOLDINGS)
                .BorderWidth = 1
                .BorderColor = Color.Gray
                .ChartType = SeriesChartType.Pie
                .Item("PieLabelStyle") = "Outside"
                .Item("CollectedThreshold") = rGroupPc.ToString
                .Item("CollectedThresholdUsePercent") = "true"
                .Item("CollectedLabel") = "Misc"
                .Item("CollectedLegendText") = "Misc"
                .LegendText = "#VALX : #VALY{c2}"
            End With

            Dim analysis = CTransactions.Analyse(allTransactions, allInstruments, allCurrencies)

            Dim allAnalysis = analysis.InstrumentAnalysis()

            If CmbAccountHoldings.Text.Length > 0 Then
                ' We only want to see instruments that are used by the account selected
                ' Get distinct instrument codes used by that account
                Dim instrumentCodesOnly = allTransactions.Where(Function(c)
                                                                    Return Not String.IsNullOrEmpty(c.InstrumentCode) AndAlso c.AccountCode.Equals(CmbAccountHoldings.Text)
                                                                End Function).Select(Function(c) c.InstrumentCode.ToUpper).Distinct
                ' Filter analysis to show only those codes
                allAnalysis = allAnalysis.Where(Function(c) instrumentCodesOnly.Contains(c.InstrumentCode.ToUpper))
            End If

            Dim analysisOfRequiredType = allAnalysis.Where(Function(c)
                                                               Dim i = allInstruments.Where(Function(d) d.Code.Equals(c.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                                                               If i Is Nothing Then
                                                                   Return False
                                                               End If
                                                               If TxtHoldingsCurrency.Text.Length > 0 Then
                                                                   Dim sInstrumentCurrency = i.CurrencyCode
                                                                   If String.IsNullOrEmpty(sInstrumentCurrency) Then
                                                                       sInstrumentCurrency = GetLocalCurrencyIso()
                                                                   End If
                                                                   If Not TxtHoldingsCurrency.Text.Equals(sInstrumentCurrency, StringComparison.CurrentCultureIgnoreCase) Then
                                                                       Return False
                                                                   End If
                                                               End If

                                                               If OptHoldingsTypeCrypto.Checked AndAlso Not i.InstrumentType = EInstrumentType.Crypto Then
                                                                   Return False
                                                               ElseIf OptHoldingsTypeShares.Checked AndAlso Not i.InstrumentType = EInstrumentType.Share Then
                                                                   Return False
                                                               End If

                                                               Return True
                                                           End Function).OrderByDescending(Function(c) c.CurrentWorth)

            Dim x = analysisOfRequiredType.Select(Function(c) c.InstrumentCode).ToArray
            Dim y = analysisOfRequiredType.Select(Function(c) c.CurrentWorth).ToArray

            ChartHoldings.Series(0).Points.DataBindXY(x, y)

            With ChartHoldings.Titles.Add($"Total Displayed: {analysisOfRequiredType.Sum(Function(c) c.CurrentWorth):c2}")
                .Font = New Font(Font, FontStyle.Italic)
            End With

        End Sub

        Private Sub OptHoldingTypeAll_CheckedChanged(sender As Object, e As EventArgs) Handles OptHoldingsTypeAll.CheckedChanged,
            OptHoldingsTypeCrypto.CheckedChanged, OptHoldingsTypeShares.CheckedChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub OptPlPerInstrumentType(sender As Object, e As EventArgs) Handles OptPlPerInstrumentTypeAll.CheckedChanged,
            OptPlPerInstrumentCrypto.CheckedChanged, OptPlPerInstrumentShares.CheckedChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub TxtHoldingsGroupPc_TextChanged(sender As Object, e As EventArgs) Handles TxtHoldingsGroupPc.TextChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub TxtHoldingsCurrency_TextChanged(sender As Object, e As EventArgs) Handles TxtHoldingsCurrency.TextChanged
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub OptPlAll_CheckedChanged(sender As Object, e As EventArgs) Handles OptPlAll.CheckedChanged,
             OptPlCrypto.CheckedChanged, OptPlShares.CheckedChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub CmbAccount_TextChanged(sender As Object, e As EventArgs) Handles CmbAccountPlPerInstrument.TextChanged, CmbAccountHoldings.TextChanged
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub DtpPlDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DtpPlDateFrom.ValueChanged, DtpPlDateTo.ValueChanged,
            DtpMiningDateFrom.ValueChanged, DtpMiningDateTo.ValueChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub ChkPlDateRangeEnable_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPlDateRangeEnable.CheckedChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                EnableDisablePlDateRange()
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub EnableDisablePlDateRange()
            DtpPlDateFrom.Enabled = ChkPlDateRangeEnable.Checked
            DtpPlDateTo.Enabled = ChkPlDateRangeEnable.Checked
        End Sub

        Private Sub ChkMiningDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMiningDateRange.CheckedChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                EnableDisableMiningDateRange()
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub EnableDisableMiningDateRange()
            DtpMiningDateFrom.Enabled = ChkMiningDateRange.Checked
            DtpMiningDateTo.Enabled = ChkMiningDateRange.Checked
        End Sub

        Private Sub ChkReduceByElectricityCost_CheckedChanged(sender As Object, e As EventArgs) Handles ChkReduceByElectricityCost.CheckedChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub CmbMiningRollingDays_TextChanged(sender As Object, e As EventArgs) Handles CmbMiningRollingDays.TextChanged
            If Not m_fFormLoaded Then
                Return
            End If
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

    End Class
End Namespace
