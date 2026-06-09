Imports System.Collections.ObjectModel
Imports System.Data.SqlServerCe
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments

Namespace Transactions
    Friend Class CTransactions
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Sub AddNewTransactions(transactions As IEnumerable(Of CTransaction))
            m_commonObjects.Database.TransactionBegin()
            Try
                AddNewTransactionsNow(transactions)
                m_commonObjects.Database.TransactionCommit()
                RefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Friend Sub AddNewTransactionsNow(transactions As IEnumerable(Of CTransaction))
            m_commonObjects.Database.TransactionEnsureActive()
            Dim accounts = m_commonObjects.Accounts
            Dim allAccountsDict = accounts.GetAllDict()
            Dim instruments = m_commonObjects.Instruments
            Dim allInstrumentsDict = instruments.GetAllDict()
            Dim lBatch As Long = GetMaxBatch() + 1
            Dim lId As Long = GetMaxId()
            For Each transaction In transactions
                lId += 1
                transaction.Id = lId
                transaction.Batch = lBatch
                SaveTransactionNow(transaction, allAccountsDict, allInstrumentsDict)
            Next
        End Sub
        Private Function GetMaxBatch() As Long
            Dim sql As String = $"
                SELECT Max({CDatabase.FIELD_TRANSACTIONS_BATCH})
                FROM {CDatabase.TABLE_TRANSACTIONS};"
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Return CDatabase.DbToLong(dr(0))
                Next
            End Using
            Return 0
        End Function

        Friend Sub UpdateExistingTransaction(transaction As CTransaction)
            m_commonObjects.Database.TransactionBegin()
            Try
                Dim accounts = m_commonObjects.Accounts
                Dim allAccountsDict = accounts.GetAllDict()

                Dim instruments = m_commonObjects.Instruments
                Dim allInstrumentsDict = instruments.GetAllDict()

                SaveTransactionNow(transaction, allAccountsDict, allInstrumentsDict)

                m_commonObjects.Database.TransactionCommit()
                RefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
            End Try
        End Sub

        Private Sub SaveTransactionNow(transaction As CTransaction, allAccountsDict As Dictionary(Of String, CAccount), allInstrumentsDict As Dictionary(Of String, CInstrument))
            m_commonObjects.Database.TransactionEnsureActive()

            'Dim accounts As New CAccounts(m_commonObjects)
            Dim account As CAccount = Nothing
            If Not allAccountsDict.TryGetValue(transaction.AccountCode, account) Then
                Throw New Exception(My.Resources.Error_AccountCodeNotValid)
            End If
            If Not String.IsNullOrEmpty(transaction.InstrumentCode) Then
                'Dim instruments = New CInstruments(m_commonObjects)
                Dim instrument As CInstrument = Nothing
                If Not allInstrumentsDict.TryGetValue(transaction.InstrumentCode, instrument) Then
                    Throw New Exception(My.Resources.Error_InstrumentCodeNotValid)
                End If
                If instrument.InstrumentType = EInstrumentType.Crypto AndAlso Not account.AccountType = EAccountType.Crypto Then
                    Throw New Exception("Can only have crypto transactions on crypto accounts")
                ElseIf instrument.InstrumentType = EInstrumentType.Share AndAlso Not account.AccountType = EAccountType.Share_Account Then
                    Throw New Exception("Can only have share transactions on share accounts")
                End If
            End If




            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_TRANSACTIONS}
                WHERE {CDatabase.FIELD_TRANSACTIONS_ID} = {transaction.Id};"

            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da As New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        Dim dr As DataRow
                        If dt.Rows.Count = 0 Then
                            dr = dt.NewRow()
                            dr(CDatabase.FIELD_TRANSACTIONS_ID) = transaction.Id
                            dt.Rows.Add(dr)
                        Else
                            dr = dt.Rows(0)
                        End If

                        dr(CDatabase.FIELD_TRANSACTIONS_TRANSDATE) = transaction.TransDate
                        dr(CDatabase.FIELD_TRANSACTIONS_TRANSTYPE) = transaction.TransactionType.Code
                        dr(CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE) = transaction.AccountCode

                        If String.IsNullOrEmpty(transaction.InstrumentCode) Then
                            dr(CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE) = DBNull.Value
                        Else
                            dr(CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE) = transaction.InstrumentCode
                        End If

                        If transaction.Rate > 0 Then
                            dr(CDatabase.FIELD_TRANSACTIONS_RATE) = transaction.Rate
                        ElseIf transaction.Rate < 0 Then
                            Throw New Exception(My.Resources.Error_RateNotValid)
                        Else
                            dr(CDatabase.FIELD_TRANSACTIONS_RATE) = DBNull.Value
                        End If

                        If String.IsNullOrEmpty(transaction.InstrumentCode) Then
                            ' Local currency amount
                            dr(CDatabase.FIELD_TRANSACTIONS_AMOUNT) = Math.Round(transaction.Amount, 2, MidpointRounding.AwayFromZero)
                        Else
                            ' Instrument
                            dr(CDatabase.FIELD_TRANSACTIONS_AMOUNT) = transaction.Amount
                        End If

                        dr(CDatabase.FIELD_TRANSACTIONS_DESCRIPTION) = transaction.Description

                        dr(CDatabase.FIELD_TRANSACTIONS_BATCH) = transaction.Batch
                        dr(CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE) = transaction.ExchangeRate

                        Using cb As New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using

        End Sub
        Private Function GetMaxId() As Long
            Dim sql As String = $"
                SELECT Max({CDatabase.FIELD_TRANSACTIONS_ID})
                FROM {CDatabase.TABLE_TRANSACTIONS};"
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Return CDatabase.DbToLong(dr(0))
                Next
            End Using
            Return 0
        End Function
        Friend Function GetAll() As IEnumerable(Of CTransaction)
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_TRANSACTIONS}
                ORDER BY {CDatabase.FIELD_TRANSACTIONS_ID};"
            Dim all = New List(Of CTransaction)
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using reader = cm.ExecuteReader
                    Dim ords = GetFieldOrdinals(reader)
                    While reader.Read
                        Dim transaction = GetTransactionFromReader(reader, ords)
                        all.Add(transaction)
                    End While
                End Using
            End Using
            Return all
        End Function

        Friend Sub DeleteBatches(batches As IEnumerable(Of Long))
            m_commonObjects.Database.TransactionBegin()
            Try
                DeleteBatchesNow(batches)
                m_commonObjects.Database.TransactionCommit()
                RefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
            End Try
        End Sub

        Friend Sub DeleteBatchesNow(batches As IEnumerable(Of Long))
            m_commonObjects.Database.TransactionEnsureActive()

            Dim sql As String = String.Empty
            For Each batch In batches
                If Not String.IsNullOrEmpty(sql) Then
                    sql &= ", "
                End If
                sql &= batch
            Next
            sql = $"
                DELETE
                FROM {CDatabase.TABLE_TRANSACTIONS}
                WHERE {CDatabase.FIELD_TRANSACTIONS_BATCH} IN ({sql});"
            m_commonObjects.Database.ExecuteQuery(sql)
        End Sub

        Private Sub RefreshForms()
            m_commonObjects.ClearCache()
            m_commonObjects.RefreshForms()
        End Sub

        Friend Shared Function Analyse(transactionsEnum As IEnumerable(Of CTransaction),
                               allInstrumentsDict As Dictionary(Of String, CInstrument),
                               allCurrenciesDict As Dictionary(Of String, CCurrencyDetail)) As CTransactionAnalyserResult

            Dim transactions = If(transactionsEnum, Enumerable.Empty(Of CTransaction)()).ToList()
            If transactions.Count = 0 Then
                Return New CTransactionAnalyserResult(0, 0, 0, 0, 0, 0, 0, New List(Of CInstrumentBalance)(), 0, New List(Of CBatch)(), New List(Of CInstrumentAnalysis)())
            End If

            ' 1. Single-pass aggregation of all transaction totals
            Dim cTransfersIn = 0D, cTransfersOut = 0D
            Dim cFees = 0D, cMining = 0D, cBonus = 0D, cAdjustments = 0D, cCurrentValue = 0D

            For Each t In transactions
                Dim localBalance = t.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict)
                cCurrentValue += localBalance

                Select Case t.TransactionType
                    Case ETransactionType.Transfer
                        Dim amount = t.Amount * CDec(If(t.Rate > 0, t.Rate, 1))
                        If t.Amount > 0 Then cTransfersIn += amount Else cTransfersOut += amount
                    Case ETransactionType.Fee
                        cFees += localBalance
                    Case ETransactionType.Mining
                        cMining += localBalance
                    Case ETransactionType.Bonus
                        cBonus += localBalance
                    Case ETransactionType.Adjustment
                        cAdjustments += localBalance
                End Select
            Next

            Dim cNetTransfers As Decimal = cTransfersIn + cTransfersOut
            Dim cProfitLoss As Decimal = cCurrentValue - cNetTransfers

            ' 2. Group instruments (Calculated once)
            Dim instrumentStats = (
                From t In transactions
                Group t By Key = If(t.InstrumentCode, "").ToUpperInvariant() Into Group
                Select InstrumentCode = Group.First().InstrumentCode,
                       TotalQuantity = Group.Sum(Function(c) c.Amount),
                       LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
            ).ToList()

            ' 3. Map Instrument Balances
            Dim currentValues As New List(Of CInstrumentBalance)(instrumentStats.Count)
            For Each b In instrumentStats
                Dim instrument As CInstrument = Nothing
                If b.InstrumentCode IsNot Nothing Then
                    allInstrumentsDict.TryGetValue(b.InstrumentCode, instrument)
                End If
                currentValues.Add(New CInstrumentBalance(instrument, b.LocalCurrencyValue))
            Next

            ' 4. Generate Batches
            Dim batchesGrouped = From trans In transactions
                                 Group trans By trans.Batch Into Group
                                 Select Batch,
                                AccountCode = Group.Max(Function(c) c.AccountCode),
                                TransType = Group.Max(Function(c) c.TransactionType),
                                InstrumentCode = Group.Max(Function(c) c.InstrumentCode),
                                MonetaryAmount = Group.Sum(Function(c) If(String.IsNullOrEmpty(c.InstrumentCode), c.Amount, 0)),
                                InstrumentAmount = Group.Sum(Function(c) If(String.IsNullOrEmpty(c.InstrumentCode), 0, c.Amount))

            Dim batches As New List(Of CBatch)
            For Each b In batchesGrouped
                batches.Add(New CBatch(b.Batch, b.AccountCode, b.TransType, b.InstrumentCode, b.MonetaryAmount, b.InstrumentAmount))
            Next

            ' 5. OPTIMIZATION: Create fast Lookups for the NetCash calculation (Removes the bottleneck)
            Dim batchesByInstrument = batches.
                Where(Function(c) Not String.IsNullOrEmpty(c.InstrumentCode) AndAlso (c.TransactionType = ETransactionType.Buy OrElse c.TransactionType = ETransactionType.Sell)).
                ToLookup(Function(c) c.InstrumentCode, Function(c) c.MonetaryAmount, StringComparer.OrdinalIgnoreCase)

            Dim emptyInstrumentCash = batches.
                Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode)).
                Sum(Function(c) c.MonetaryAmount)

            ' 6. Build Instrument Analysis using O(1) Lookups
            Dim instrumentAnalysis As New List(Of CInstrumentAnalysis)(instrumentStats.Count)
            For Each t In instrumentStats
                Dim netCash As Decimal = 0

                If String.IsNullOrEmpty(t.InstrumentCode) Then
                    netCash = emptyInstrumentCash
                Else
                    netCash = batchesByInstrument(t.InstrumentCode).Sum()
                End If

                Dim pl = netCash + t.LocalCurrencyValue
                instrumentAnalysis.Add(New CInstrumentAnalysis(t.InstrumentCode, t.TotalQuantity, t.LocalCurrencyValue, netCash, pl))
            Next

            Return New CTransactionAnalyserResult(cTransfersIn, cTransfersOut, cNetTransfers, cFees, cMining, cBonus, cAdjustments,
                                          currentValues, cProfitLoss, batches, instrumentAnalysis)

        End Function

        'Friend Shared Function AnalyseNew(transactionsEnum As IEnumerable(Of CTransaction), allInstrumentsDict As Dictionary(Of String, CInstrument),
        '                               allCurrenciesDict As Dictionary(Of String, CCurrencyDetail)) As CTransactionAnalyserResult

        '    Dim transactions = If(transactionsEnum, Enumerable.Empty(Of CTransaction)()).ToList()
        '    If transactions.Count = 0 Then
        '        Return New CTransactionAnalyserResult(0, 0, 0, 0, 0, 0, 0,
        '                                    New List(Of CInstrumentBalance)(),
        '                                    0, New List(Of CBatch)(),
        '                                    New List(Of CInstrumentAnalysis)())
        '    End If


        '    Dim cTransfersIn = 0D, cTransfersOut = 0D
        '    For Each t In transactions.Where(Function(c) c.TransactionType = ETransactionType.Transfer)
        '        Dim amount = t.Amount * CDec(IIf(t.Rate > 0, t.Rate, 1))
        '        If t.Amount > 0 Then cTransfersIn += amount Else cTransfersOut += amount
        '    Next
        '    Dim cNetTransfers As Decimal = cTransfersIn + cTransfersOut

        '    Dim cFees As Decimal = transactions.Where(Function(c)
        '                                                  Return c.TransactionType = ETransactionType.Fee
        '                                              End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '    Dim cMining As Decimal = transactions.Where(Function(c)
        '                                                    Return c.TransactionType = ETransactionType.Mining
        '                                                End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))

        '    Dim cBonus As Decimal = transactions.Where(Function(c)
        '                                                   Return c.TransactionType = ETransactionType.Bonus
        '                                               End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '    Dim cAdjustments As Decimal = transactions.Where(Function(c)
        '                                                         Return c.TransactionType = ETransactionType.Adjustment
        '                                                     End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))


        '    Dim cCurrentValue As Decimal = transactions.Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '    Dim cProfitLoss As Decimal = cCurrentValue - cNetTransfers

        '    Dim instrumentStats = From t In transactions
        '                          Group By t.InstrumentCode Into Group
        '                          Select InstrumentCode,
        '                     TotalQuantity = Group.Sum(Function(c) c.Amount),
        '                     LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))

        '    'Dim balanceByInstrument = From trans In transactions
        '    '                          Order By trans.InstrumentCode
        '    '                          Group By trans.InstrumentCode
        '    '                            Into myGroup = Group, Sum(trans.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '    '                          Order By InstrumentCode

        '    Dim currentValues As New List(Of CInstrumentBalance)
        '    For Each b In instrumentStats
        '        Dim instrument As CInstrument = Nothing
        '        If allInstrumentsDict.TryGetValue(b.InstrumentCode, instrument) Then
        '            ' found
        '        End If
        '        'If Not String.IsNullOrEmpty(b.InstrumentCode) Then
        '        ' instrument = allInstruments.Where(Function(c) c.Code.Equals(b.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
        '        'End If
        '        Dim instrumentBalance = New CInstrumentBalance(instrument, b.LocalCurrencyValue)
        '        currentValues.Add(instrumentBalance)
        '    Next

        '    Dim batchesGrouped = From trans In transactions
        '                         Group By trans.Batch Into Group
        '                         Select Batch,
        '                             BatchDate = Group.Max(Function(c) c.TransDate),
        '                             AccountCode = Group.Max(Function(c) c.AccountCode),
        '                             TransType = Group.Max(Function(c) c.TransactionType),
        '                             InstrumentCode = Group.Max(Function(c) c.InstrumentCode),
        '                             MonetaryAmount = Group.Sum(Function(c)
        '                                                            Return If(String.IsNullOrEmpty(c.InstrumentCode), c.Amount, 0)
        '                                                        End Function),
        '                             InstrumentAmount = Group.Sum(Function(c)
        '                                                              Return If(String.IsNullOrEmpty(c.InstrumentCode), 0, c.Amount)
        '                                                          End Function)


        '    Dim batches As New List(Of CBatch)
        '    For Each b In batchesGrouped
        '        batches.Add(New CBatch(b.Batch, b.AccountCode, b.TransType, b.InstrumentCode, b.MonetaryAmount, b.InstrumentAmount))
        '    Next



        '    ' Instrument Analysis
        '    Dim instrumentAnalysis As New List(Of CInstrumentAnalysis)
        '    Try
        '        'Dim totalsByInstrument = From t In Transactions
        '        '                         Group t By t.InstrumentCode Into Group
        '        '                         Select
        '        '                             InstrumentCode,
        '        '                             TotalQuantity = Group.Sum(Function(c) c.Amount),
        '        '                             LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '        For Each t In instrumentStats.ToList
        '            Dim netCash = batches.Where(Function(c)
        '                                            If String.IsNullOrEmpty(c.InstrumentCode) Then
        '                                                Return String.IsNullOrEmpty(t.InstrumentCode)
        '                                            Else
        '                                                Return c.InstrumentCode.Equals(t.InstrumentCode, StringComparison.CurrentCultureIgnoreCase) AndAlso
        '                                                                           (c.TransactionType = ETransactionType.Buy OrElse c.TransactionType = ETransactionType.Sell)
        '                                            End If
        '                                        End Function).Sum(Function(c) c.MonetaryAmount)
        '            Dim pl = netCash + t.LocalCurrencyValue
        '            instrumentAnalysis.Add(New CInstrumentAnalysis(t.InstrumentCode, t.TotalQuantity, t.LocalCurrencyValue, netCash, pl))
        '        Next
        '    Catch ex As Exception
        '        Throw
        '    End Try

        '    Return New CTransactionAnalyserResult(cTransfersIn, cTransfersOut, cNetTransfers, cFees, cMining, cBonus, cAdjustments,
        '                                          currentValues, cProfitLoss, batches, instrumentAnalysis)

        'End Function


        'Friend Shared Function AnalyseOld(transactions As IEnumerable(Of CTransaction), allInstrumentsDict As Dictionary(Of String, CInstrument),
        '                               allCurrenciesDict As Dictionary(Of String, CCurrencyDetail)) As CTransactionAnalyserResult

        '    ' Analyse the "transactions" specified.  allInstruments is just used to get the current rates

        '    Dim cTransfersIn As Decimal = transactions.Where(Function(c)
        '                                                         Return c.TransactionType = ETransactionType.Transfer And
        '                                                         c.Amount > 0
        '                                                     End Function).Sum(Function(c) c.Amount * CDec(IIf(c.Rate > 0, c.Rate, 1)))
        '    Dim cTransfersOut As Decimal = transactions.Where(Function(c)
        '                                                          Return c.TransactionType = ETransactionType.Transfer And
        '                                                         c.Amount < 0
        '                                                      End Function).Sum(Function(c) c.Amount * CDec(IIf(c.Rate > 0, c.Rate, 1)))
        '    Dim cNetTransfers As Decimal = cTransfersIn + cTransfersOut

        '    Dim cFees As Decimal = transactions.Where(Function(c)
        '                                                  Return c.TransactionType = ETransactionType.Fee
        '                                              End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '    Dim cMining As Decimal = transactions.Where(Function(c)
        '                                                    Return c.TransactionType = ETransactionType.Mining
        '                                                End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))

        '    Dim cBonus As Decimal = transactions.Where(Function(c)
        '                                                   Return c.TransactionType = ETransactionType.Bonus
        '                                               End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '    Dim cAdjustments As Decimal = transactions.Where(Function(c)
        '                                                         Return c.TransactionType = ETransactionType.Adjustment
        '                                                     End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))


        '    Dim cCurrentValue As Decimal = transactions.Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '    Dim cProfitLoss As Decimal = cCurrentValue - cNetTransfers

        '    Dim balanceByInstrument = From trans In transactions
        '                              Order By trans.InstrumentCode
        '                              Group By trans.InstrumentCode
        '                                Into myGroup = Group, Sum(trans.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '                              Order By InstrumentCode

        '    Dim currentValues As New List(Of CInstrumentBalance)
        '    For Each b In balanceByInstrument
        '        Dim instrument As CInstrument = Nothing
        '        If allInstrumentsDict.TryGetValue(b.InstrumentCode, instrument) Then
        '            ' found
        '        End If
        '        'If Not String.IsNullOrEmpty(b.InstrumentCode) Then
        '        ' instrument = allInstruments.Where(Function(c) c.Code.Equals(b.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
        '        'End If
        '        Dim instrumentBalance = New CInstrumentBalance(instrument, b.Sum)
        '        currentValues.Add(instrumentBalance)
        '    Next

        '    Dim batchesGrouped = From trans In transactions
        '                         Group By trans.Batch Into Group
        '                         Select Batch,
        '                             BatchDate = Group.Max(Function(c) c.TransDate),
        '                             AccountCode = Group.Max(Function(c) c.AccountCode),
        '                             TransType = Group.Max(Function(c) c.TransactionType),
        '                             InstrumentCode = Group.Max(Function(c) c.InstrumentCode),
        '                             MonetaryAmount = Group.Sum(Function(c)
        '                                                            Return If(String.IsNullOrEmpty(c.InstrumentCode), c.Amount, 0)
        '                                                        End Function),
        '                             InstrumentAmount = Group.Sum(Function(c)
        '                                                              Return If(String.IsNullOrEmpty(c.InstrumentCode), 0, c.Amount)
        '                                                          End Function)


        '    Dim batches As New List(Of CBatch)
        '    For Each b In batchesGrouped
        '        batches.Add(New CBatch(b.Batch, b.AccountCode, b.TransType, b.InstrumentCode, b.MonetaryAmount, b.InstrumentAmount))
        '    Next



        '    ' Instrument Analysis
        '    Dim instrumentAnalysis As New List(Of CInstrumentAnalysis)
        '    Try
        '        Dim totalsByInstrument = From t In transactions
        '                                 Group t By t.InstrumentCode Into Group
        '                                 Select
        '                                     InstrumentCode,
        '                                     TotalQuantity = Group.Sum(Function(c) c.Amount),
        '                                     LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstrumentsDict, allCurrenciesDict))
        '        For Each t In totalsByInstrument.ToList
        '            Dim netCash = batches.Where(Function(c)
        '                                            If String.IsNullOrEmpty(c.InstrumentCode) Then
        '                                                Return String.IsNullOrEmpty(t.InstrumentCode)
        '                                            Else
        '                                                Return c.InstrumentCode.Equals(t.InstrumentCode, StringComparison.CurrentCultureIgnoreCase) AndAlso
        '                                                                           (c.TransactionType = ETransactionType.Buy OrElse c.TransactionType = ETransactionType.Sell)
        '                                            End If
        '                                        End Function).Sum(Function(c) c.MonetaryAmount)










        '            Dim pl = netCash + t.LocalCurrencyValue
        '            instrumentAnalysis.Add(New CInstrumentAnalysis(t.InstrumentCode, t.TotalQuantity, t.LocalCurrencyValue, netCash, pl))
        '        Next
        '    Catch ex As Exception
        '        Throw
        '    End Try




        '    ' 










        '    Dim transactionAnalyserResult = New CTransactionAnalyserResult(cTransfersIn, cTransfersOut, cNetTransfers,
        '                                                                   cFees, cMining, cBonus, cAdjustments, currentValues, cProfitLoss, batches, instrumentAnalysis)

        '    Return transactionAnalyserResult

        'End Function

        Friend Sub ReconcileUnreconcile(ids As IEnumerable(Of Long))
            If ids Is Nothing OrElse Not ids.Any Then
                Throw New Exception("No IDs specified")
            End If
            m_commonObjects.Database.TransactionBegin()
            Try
                Dim sql = $"
                    UPDATE {CDatabase.TABLE_TRANSACTIONS}
                    SET {CDatabase.FIELD_TRANSACTIONS_RECONCILED} = CASE WHEN Coalesce({CDatabase.FIELD_TRANSACTIONS_RECONCILED}, 0) = 0 THEN 1 ELSE 0 END
                    WHERE {CDatabase.FIELD_TRANSACTIONS_ID} IN ({String.Join(", ", ids)});"
                m_commonObjects.Database.ExecuteQuery(sql)

                m_commonObjects.Database.TransactionCommit()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
    End Class

End Namespace
