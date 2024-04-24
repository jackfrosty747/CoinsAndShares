Imports System.ComponentModel
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Instruments
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

    Friend Function GetValues(commonObjects As CCommonObjects) As CCoinsAndShares

        ' 060821 - PG - Rewriting to work via total asset worth less transfer from bank.  

        Dim instruments = commonObjects.Instruments
        Dim transactions = commonObjects.Transactions
        Dim currencies = commonObjects.Currencies
        Dim accounts = commonObjects.Accounts

        Dim allTransactions = transactions.GetAll()
        Dim allInstruments = instruments.GetAll()
        Dim allCurrencies = currencies.GetAll()
        Dim allAccounts = accounts.GetAll()






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
                Dim instrument = allInstruments.First(Function(c) c.Code.Equals(ia.InstrumentCode, StringComparison.InvariantCultureIgnoreCase))
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






        ' Return



        ' OLD BIT


        'Dim analysis = CTransactions.Analyse(allTransactions, allInstruments, allCurrencies)

        'Dim instrumentAnalysis = analysis.InstrumentAnalysis()


        'Dim shareInstrumentCodes = allInstruments.Where(Function(c) c.InstrumentType = EInstrumentType.Share).Select(Function(d) d.Code)
        'Dim cryptoInstrumentCodes = allInstruments.Where(Function(c) c.InstrumentType = EInstrumentType.Crypto).Select(Function(d) d.Code)

        'Dim shares = instrumentAnalysis.Where(Function(c)
        '                                          Return shareInstrumentCodes.Contains(c.InstrumentCode)
        '                                      End Function).Sum(Function(f) f.Pl)
        'Dim coins = instrumentAnalysis.Where(Function(c)
        '                                         Return cryptoInstrumentCodes.Contains(c.InstrumentCode)
        '                                     End Function).Sum(Function(f) f.Pl)

        'Dim coinsAndShares As New CoinsAndShares(coins, shares)
        'Return coinsAndShares
    End Function

End Module
