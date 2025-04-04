Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Accounts.MAccounts
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Transactions
Imports System.Text

Namespace Charts
    Module MAssets
        Friend Function GetHodlings(commonObjects As CCommonObjects, dt As Date) As Tuple(Of String, Decimal)

            Const INSTRUMENT_CASH = "Cash"
            Const NETWORK_METALS = "METALS"
            Const NETWORK_SAVINGS = "SAVINGS"
            Const ACCOUNT_TYPE_CRYPTO As String = NameOf(EAccountType.Crypto)

            Dim transactions = New CTransactions(commonObjects).GetAll
            Dim allInstruments = New CInstruments(commonObjects).GetAll
            Dim allCurrencies = New CCurrencies(commonObjects).GetAll
            Dim allAccounts = New CAccounts(commonObjects).GetAll

            transactions = transactions.Where(Function(c) c.TransDate.Date <= dt.Date)

            Dim sb As New StringBuilder

            Dim totalAmountsByInstrument = transactions.
                GroupBy(Function(t) If(String.IsNullOrEmpty(t.InstrumentCode), INSTRUMENT_CASH, t.InstrumentCode.ToUpperInvariant())).
                Select(Function(g) New With {
                    .InstrumentCode = g.Key,
                    .TotalAmount = g.Sum(Function(t) t.Amount),
                    .AccountCodes = g.Select(Function(t) t.AccountCode).Distinct().ToList() ' Collect account codes
                }).
                Where(Function(g) g.TotalAmount <> 0). ' Filter out zero balances
                Select(Function(g)
                           Dim instrument = allInstruments.FirstOrDefault(Function(i) i.Code.ToUpperInvariant() = g.InstrumentCode)
                           Dim rate As Decimal = If(instrument?.Rate, 1) ' Default rate to 1

                           ' Get currency exchange rate
                           Dim exchangeRate As Decimal = 1
                           If instrument IsNot Nothing AndAlso Not String.IsNullOrEmpty(instrument.CurrencyCode) Then
                               Dim currency = allCurrencies.FirstOrDefault(Function(c) c.CurrencyCode.Equals(instrument.CurrencyCode, StringComparison.CurrentCultureIgnoreCase))
                               If currency IsNot Nothing AndAlso currency.CurrencyRate.HasValue AndAlso currency.CurrencyRate.Value > 0 Then
                                   exchangeRate = currency.CurrencyRate.Value
                               End If
                           End If
                           ' Calculate local currency value
                           Dim currentValue As Decimal = If(g.InstrumentCode = INSTRUMENT_CASH, g.TotalAmount, g.TotalAmount * rate / exchangeRate)

                           ' Get the NetworkId (assuming multiple accounts might be involved)
                           Dim networkIds = g.AccountCodes.
                               Select(Function(ac) allAccounts.FirstOrDefault(Function(a) a.AccountCode = ac)?.NetworkId).
                               Where(Function(nid) nid IsNot Nothing).
                               Distinct().
                               ToList()

                           ' Get AccountTypes (descriptions)
                           Dim accountTypes = g.AccountCodes.
                               Select(Function(ac) allAccounts.FirstOrDefault(Function(a) a.AccountCode = ac)?.AccountType).
                               Where(Function(nid) nid IsNot Nothing).
                               Distinct().
                               ToList()

                           ' If multiple NetworkIds exist, join them into a string; otherwise, use the single one
                           Dim networkIdDisplay As String = If(networkIds.Count > 0, String.Join(", ", networkIds), "N/A")
                           Dim accountTypeDisplay As String = If(accountTypes.Count > 0, String.Join(", ", accountTypes), "N/A")

                           Return New With {
                                .InstrumentCode = g.InstrumentCode,
                                .TotalAmount = g.TotalAmount,
                                .CurrentValue = currentValue,
                                .NetworkId = networkIdDisplay,
                                .AccountType = accountTypeDisplay
                            }
                       End Function).
                ToList()

            Dim nonCashItems = totalAmountsByInstrument.Where(Function(c) Not c.InstrumentCode.Equals(INSTRUMENT_CASH, StringComparison.CurrentCultureIgnoreCase))
            Dim metals = nonCashItems.Where(Function(c) c.NetworkId.Equals(NETWORK_METALS, StringComparison.CurrentCultureIgnoreCase))
            Dim crypto = nonCashItems.Where(Function(c) Not c.NetworkId.Equals(NETWORK_METALS, StringComparison.CurrentCultureIgnoreCase) And c.AccountType.Contains(ACCOUNT_TYPE_CRYPTO))
            Dim stock = nonCashItems.Where(Function(c) Not c.NetworkId.Equals(NETWORK_METALS, StringComparison.CurrentCultureIgnoreCase) And Not c.AccountType.Contains(ACCOUNT_TYPE_CRYPTO))

            sb.AppendLine("                                ALL ASSETS REPORT")
            sb.AppendLine("                                =================")
            sb.AppendLine("Amounts are as at the date selected.  Values are based on current instrument values")
            sb.AppendLine()
            sb.AppendLine($"METALS:                                                                  {metals.Sum(Function(c) c.CurrentValue),12:c2}")
            sb.AppendLine()
            sb.AppendLine($"CRYPTO")
            For Each item In crypto.OrderByDescending(Function(c) c.CurrentValue)
                sb.AppendLine($"  ->  Instrument: {item.InstrumentCode,-20} Amount: {item.TotalAmount,15}    Value: {item.CurrentValue,12:c2}")
            Next
            sb.AppendLine($"                                                                           ----------")
            sb.AppendLine($"                                                           CRYPTO TOTAL: {crypto.Sum(Function(c) c.CurrentValue),12:c2}")
            sb.AppendLine()
            sb.AppendLine($"SHARES")
            For Each item In stock.OrderByDescending(Function(c) c.CurrentValue)
                sb.AppendLine($"  ->  Instrument: {item.InstrumentCode,-20} Amount: {item.TotalAmount,15}    Value: {item.CurrentValue,12:c2}")
            Next
            sb.AppendLine($"                                                                           ----------")
            sb.AppendLine($"                                                           SHARES TOTAL: {stock.Sum(Function(c) c.CurrentValue),12:c2}")
            sb.AppendLine()

            Dim cashBalances = transactions.Where(Function(t) String.IsNullOrEmpty(t.InstrumentCode)).
                GroupBy(Function(t) t.AccountCode). ' Group by AccountCode
                Select(Function(g) New With {
                    .AccountCode = g.Key,
                    .TotalCashBalance = g.Sum(Function(t) t.Amount)
                }).ToList()
            Dim savings = From account In allAccounts
                          Where account.NetworkId.Equals(NETWORK_SAVINGS, StringComparison.CurrentCultureIgnoreCase)
                          Join cash In cashBalances On account.AccountCode Equals cash.AccountCode
                          Where cash.TotalCashBalance <> 0
                          Select New With {
                                .AccountCode = account.AccountCode,
                                .TotalCashBalance = cash.TotalCashBalance
                            }
            sb.AppendLine($"SAVINGS")
            For Each item In savings.OrderByDescending(Function(c) c.TotalCashBalance)
                sb.AppendLine($"  ->  Account: {item.AccountCode,-20} . . . . . . . . . . . . . .  Amount: {item.TotalCashBalance,12:c2}")
            Next
            sb.AppendLine($"                                                                           ----------")
            sb.AppendLine($"                                                          SAVINGS TOTAL: {savings.Sum(Function(c) c.TotalCashBalance),12:c2}")

            ' Add - run for specific dates to show on chart
            Dim grandTotal = metals.Sum(Function(c) c.CurrentValue) + crypto.Sum(Function(c) c.CurrentValue) +
                stock.Sum(Function(c) c.CurrentValue) + savings.Sum(Function(c) c.TotalCashBalance)
            sb.AppendLine()
            sb.AppendLine($"                                                                           ==========")
            sb.AppendLine($"GRAND TOTAL:                                                             {grandTotal,12:c2}")

            Return New Tuple(Of String, Decimal)(sb.ToString, grandTotal)

        End Function

    End Module

End Namespace

