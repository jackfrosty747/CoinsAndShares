Imports System.ComponentModel
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Rates.Trading212.CTrading212
Imports CoinsAndShares.Transactions

Module MTransactions
    Friend Enum ETransactionType
        <Description("U")> Unknown
        <Description("T")> Transfer
        <Description("F")> Fee
        <Description("B")> Buy
        <Description("S")> Sell
        <Description("N")> Bonus
        <Description("A")> Adjustment
        <Description("M")> Mining
    End Enum
    Friend Function GetTransactionTypeFromCode(sCode As String, fSilent As Boolean) As ETransactionType
        Static dicTransactionTypes As Dictionary(Of String, ETransactionType)
        If dicTransactionTypes Is Nothing Then
            dicTransactionTypes = New Dictionary(Of String, ETransactionType)
            For Each transactionType As ETransactionType In [Enum].GetValues(GetType(ETransactionType))
                dicTransactionTypes.Add(transactionType.Code.ToUpper, transactionType)
            Next
        End If
        Dim result As ETransactionType
        If Not dicTransactionTypes.TryGetValue(sCode.ToUpper, result) Then
            If fSilent Then
                Return ETransactionType.Unknown
            Else
                Throw New Exception($"{sCode} is not a valid transaction type")
            End If
        End If
        Return result


        'For Each transactionType As ETransactionType In [Enum].GetValues(GetType(ETransactionType))
        '    If transactionType.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase) Then
        '        Return transactionType
        '    End If
        'Next
        'If fSilent Then
        '    Return ETransactionType.Unknown
        'End If
        'Throw New Exception($"{sCode} is not a valid transaction type")
    End Function
    Friend Function GetTransactionTypeFromDesc(sDesc As String, fSilent As Boolean) As ETransactionType
        For Each transactionType As ETransactionType In [Enum].GetValues(GetType(ETransactionType))
            If transactionType.ToString.Equals(sDesc, StringComparison.CurrentCultureIgnoreCase) Then
                Return transactionType
            End If
        Next
        If fSilent Then
            Return ETransactionType.Unknown
        End If
        Throw New Exception($"{sDesc} is not a valid transaction type description")
    End Function

    Friend Function GetValuesOld(commonObjects As CCommonObjects) As CCoinsAndShares

        ' 060821 - PG - Rewriting to work via total asset worth less transfer from bank.  

        Dim instruments = commonObjects.Instruments
        Dim transactions = commonObjects.Transactions
        Dim currencies = commonObjects.Currencies
        Dim accounts = commonObjects.Accounts

        Dim allTransactions = transactions.GetAll().ToList
        Dim allInstruments = instruments.GetAllDict()
        Dim allCurrencies = currencies.GetAllDict()
        Dim allAccounts = accounts.GetAll().ToList






        Dim cNetBankAffect As Decimal ' Negative
        Dim cTransfersCrypto As Decimal ' Negative
        Dim cTransfersShares As Decimal ' Negative
        'Dim cTransfersInterBank As Decimal ' Negative
        Dim cShareAccountCash As Decimal ' Positive
        Dim cCryptoAccountCash As Decimal ' Positive
        Dim cryptoAccounts = allAccounts.Where(Function(d) d.AccountType = EAccountType.Crypto)
        Dim shareAccounts = allAccounts.Where(Function(d) d.AccountType = EAccountType.Share_Account)
        'Dim bankAccounts = allAccounts.Where(Function(d) d.AccountType = EAccountType.Bank_Account)
        For Each account In allAccounts
            Dim accountTrans = allTransactions.Where(Function(c) c.AccountCode.Equals(account.AccountCode, StringComparison.CurrentCultureIgnoreCase))
            Select Case account.AccountType
                Case EAccountType.Bank_Account
                    Dim cNetTransfers = accountTrans.Where(Function(c) c.TransactionType = ETransactionType.Transfer).Sum(Function(c) c.Amount)
                    cNetBankAffect += cNetTransfers

                    Dim cFees = accountTrans.Where(Function(c) c.TransactionType = ETransactionType.Fee).Sum(Function(c) c.Amount)
                    'cNetBankAffect += cFees

                    Dim cTransfersToCryptoAccounts = accountTrans.Where(Function(c)
                                                                            Dim thisBatch = allTransactions.Where(Function(d) d.Batch = c.Batch)
                                                                            Dim destAccount = thisBatch.Where(Function(d) Not d.AccountCode.Equals(account.AccountCode, StringComparison.InvariantCultureIgnoreCase)).Max(Function(e) e.AccountCode)
                                                                            Return cryptoAccounts.Where(Function(d) d.AccountCode.Equals(destAccount, StringComparison.InvariantCultureIgnoreCase)).Any
                                                                        End Function).Sum(Function(c) c.Amount)
                    cTransfersCrypto += cTransfersToCryptoAccounts

                    Dim cTransfersToShareAccounts = accountTrans.Where(Function(c)
                                                                           Dim thisBatch = allTransactions.Where(Function(d) d.Batch = c.Batch)
                                                                           Dim destAccount = thisBatch.Where(Function(d) Not d.AccountCode.Equals(account.AccountCode, StringComparison.InvariantCultureIgnoreCase)).Max(Function(e) e.AccountCode)
                                                                           Return shareAccounts.Where(Function(d) d.AccountCode.Equals(destAccount, StringComparison.InvariantCultureIgnoreCase)).Any
                                                                       End Function).Sum(Function(c) c.Amount)
                    cTransfersShares += cTransfersToShareAccounts

                    'cTransfersInterBank += accountTrans.Where(Function(c)
                    '                                              Dim thisBatch = allTransactions.Where(Function(d) d.Batch = c.Batch)
                    '                                              Dim destAccount = thisBatch.Where(Function(d) Not d.AccountCode.Equals(account.AccountCode, StringComparison.InvariantCultureIgnoreCase)).Max(Function(e) e.AccountCode)
                    '                                              Return bankAccounts.Where(Function(d) d.AccountCode.Equals(destAccount, StringComparison.InvariantCultureIgnoreCase)).Any
                    '                                          End Function).Sum(Function(c) c.Amount)
                Case EAccountType.Share_Account
                    cShareAccountCash += accountTrans.Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode)).Sum(Function(c) c.Amount)

                Case EAccountType.Crypto
                    cCryptoAccountCash += accountTrans.Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode)).Sum(Function(c) c.Amount)
            End Select
        Next

        Dim cTotalCashBalance = cShareAccountCash + cCryptoAccountCash + cNetBankAffect

        Debug.Assert(cNetBankAffect = cTransfersCrypto + cTransfersShares)

        ' CORRECT UP TO HERE





        Dim analysis1 = CTransactions.Analyse(allTransactions, allInstruments, allCurrencies)
        Dim instrumentAnalysis1 = analysis1.InstrumentAnalysis()

        Dim cShareAssets As Decimal
        Dim cCryptoAssets As Decimal

        For Each ia In instrumentAnalysis1
            If Not String.IsNullOrEmpty(ia.InstrumentCode) Then

                Dim instrument As CInstrument = Nothing
                If Not allInstruments.TryGetValue(ia.InstrumentCode, instrument) Then
                    Throw New WarningException($"Transaction analysis contains an instrument code {ia.InstrumentCode} that is not in the instruments list")
                End If

                'Dim instrument = allInstruments.First(Function(c) c.Code.Equals(ia.InstrumentCode, StringComparison.InvariantCultureIgnoreCase))
                Select Case instrument.InstrumentType
                    Case EInstrumentType.Crypto : cCryptoAssets += ia.CurrentWorth
                    Case EInstrumentType.Share : cShareAssets += ia.CurrentWorth
                End Select
            End If
        Next



        Dim cTotalProfit = cTotalCashBalance + cShareAssets + cCryptoAssets

        Dim cCryptoProfit = cTransfersCrypto + cCryptoAssets + cCryptoAccountCash
        Dim cShareProfit = cTransfersShares + cShareAssets + cShareAccountCash

        Debug.Assert(cTotalProfit = cCryptoProfit + cShareProfit)

        Dim coinsAndShares As New CCoinsAndShares(cCryptoProfit, cShareProfit, cCryptoAssets, cShareAssets)
        Return coinsAndShares

    End Function

    Friend Function GetValues(commonObjects As CCommonObjects) As CCoinsAndShares

        ' 060821 - PG - Rewriting to work via total asset worth less transfer from bank. 
        ' Optimized with Lookup/Dictionary indexing to convert O(N^2) loops into O(1) lookups.

        Dim instruments = commonObjects.Instruments
        Dim transactions = commonObjects.Transactions
        Dim currencies = commonObjects.Currencies
        Dim accounts = commonObjects.Accounts

        Dim allTransactions = transactions.GetAll().ToList()
        Dim allInstruments = instruments.GetAllDict()
        Dim allCurrencies = currencies.GetAllDict()
        Dim allAccounts = accounts.GetAll().ToList()

        ' --- INDEXING UPFRONT (The Performance Secret) ---
        ' 1. Group transactions by AccountCode for fast O(1) lookup inside the loop
        Dim transactionsByAccount = allTransactions.ToLookup(
            Function(t) t.AccountCode,
            StringComparer.OrdinalIgnoreCase
        )

        ' 2. Group transactions by Batch to eliminate the expensive nested searches
        Dim transactionsByBatch = allTransactions.ToLookup(Function(t) t.Batch)

        ' 3. Create quick-lookup sets/dictionaries for account types
        Dim cryptoAccountCodes As New HashSet(Of String)(
            allAccounts.Where(Function(a) a.AccountType = EAccountType.Crypto).Select(Function(a) a.AccountCode),
            StringComparer.OrdinalIgnoreCase
        )
        Dim shareAccountCodes As New HashSet(Of String)(
            allAccounts.Where(Function(a) a.AccountType = EAccountType.Share_Account).Select(Function(a) a.AccountCode),
            StringComparer.OrdinalIgnoreCase
        )

        Dim cNetBankAffect As Decimal
        Dim cTransfersCrypto As Decimal
        Dim cTransfersShares As Decimal
        Dim cShareAccountCash As Decimal
        Dim cCryptoAccountCash As Decimal

        For Each account In allAccounts
            ' O(1) retrieval instead of scanning the whole list every time
            Dim accountTrans = transactionsByAccount(account.AccountCode)
            If Not accountTrans.Any() Then Continue For

            Select Case account.AccountType
                Case EAccountType.Bank_Account
                    For Each trans In accountTrans
                        If trans.TransactionType = ETransactionType.Transfer Then
                            cNetBankAffect += trans.Amount

                            ' Solve the Batch destination account bottleneck using our Lookup
                            Dim thisBatch = transactionsByBatch(trans.Batch)

                            ' Find the max destination account code that isn't the current account
                            Dim destAccount = thisBatch _
                                .Where(Function(d) Not d.AccountCode.Equals(account.AccountCode, StringComparison.OrdinalIgnoreCase)) _
                                .Max(Function(e) e.AccountCode)

                            If destAccount IsNot Nothing Then
                                ' Use O(1) HashSet lookups instead of .Where().Any() scans
                                If cryptoAccountCodes.Contains(destAccount) Then
                                    cTransfersCrypto += trans.Amount
                                ElseIf shareAccountCodes.Contains(destAccount) Then
                                    cTransfersShares += trans.Amount
                                End If
                            End If
                        End If
                    Next

                Case EAccountType.Share_Account
                    cShareAccountCash += accountTrans _
                        .Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode)) _
                        .Sum(Function(c) c.Amount)

                Case EAccountType.Crypto
                    cCryptoAccountCash += accountTrans _
                        .Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode)) _
                        .Sum(Function(c) c.Amount)
            End Select
        Next

        Dim cTotalCashBalance = cShareAccountCash + cCryptoAccountCash + cNetBankAffect
        Debug.Assert(cNetBankAffect = cTransfersCrypto + cTransfersShares)

        ' --- ASSET ANALYSIS ---
        Dim analysis1 = CTransactions.Analyse(allTransactions, allInstruments, allCurrencies)
        Dim instrumentAnalysis1 = analysis1.InstrumentAnalysis()

        Dim cShareAssets As Decimal
        Dim cCryptoAssets As Decimal

        For Each ia In instrumentAnalysis1
            If Not String.IsNullOrEmpty(ia.InstrumentCode) Then
                Dim instrument As CInstrument = Nothing
                If Not allInstruments.TryGetValue(ia.InstrumentCode, instrument) Then
                    Throw New WarningException($"Transaction analysis contains an instrument code {ia.InstrumentCode} that is not in the instruments list")
                End If

                Select Case instrument.InstrumentType
                    Case EInstrumentType.Crypto : cCryptoAssets += ia.CurrentWorth
                    Case EInstrumentType.Share : cShareAssets += ia.CurrentWorth
                End Select
            End If
        Next

        Dim cTotalProfit = cTotalCashBalance + cShareAssets + cCryptoAssets
        Dim cCryptoProfit = cTransfersCrypto + cCryptoAssets + cCryptoAccountCash
        Dim cShareProfit = cTransfersShares + cShareAssets + cShareAccountCash

        Debug.Assert(cTotalProfit = cCryptoProfit + cShareProfit)

        Return New CCoinsAndShares(cCryptoProfit, cShareProfit, cCryptoAssets, cShareAssets)

    End Function

End Module
