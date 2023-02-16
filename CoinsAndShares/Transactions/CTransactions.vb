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
            Dim allAccounts = accounts.GetAll()
            Dim instruments = m_commonObjects.Instruments
            Dim allInstruments = instruments.GetAll()
            Dim lBatch As Long = GetMaxBatch() + 1
            Dim lId As Long = GetMaxId()
            For Each transaction In transactions
                lId += 1
                transaction.Id = lId
                transaction.Batch = lBatch
                SaveTransactionNow(transaction, allAccounts, allInstruments)
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
                Dim allAccounts = accounts.GetAll()
                Dim instruments = m_commonObjects.Instruments
                Dim allInstruments = instruments.GetAll()
                SaveTransactionNow(transaction, allAccounts, allInstruments)
                m_commonObjects.Database.TransactionCommit()
                RefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
            End Try
        End Sub

        Private Sub SaveTransactionNow(transaction As CTransaction, allAccounts As IEnumerable(Of CAccount), allInstruments As IEnumerable(Of CInstrument))
            m_commonObjects.Database.TransactionEnsureActive()

            'Dim accounts As New CAccounts(m_commonObjects)
            Dim account = allAccounts.Where(Function(c) c.AccountCode.Equals(transaction.AccountCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If account Is Nothing Then
                Throw New Exception(My.Resources.Error_AccountCodeNotValid)
            End If
            If Not String.IsNullOrEmpty(transaction.InstrumentCode) Then
                'Dim instruments = New CInstruments(m_commonObjects)
                Dim instrument = allInstruments.Where(Function(c) c.Code.Equals(transaction.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                If instrument Is Nothing Then
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
            Dim col As New Collection(Of CTransaction)
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim transaction = GetTransactionFromDr(dr)
                    col.Add(transaction)
                Next
            End Using
            Return col
        End Function


        Friend Shared Function GetTransactionFromDr(dr As DataRow) As CTransaction
            Dim lId As Long = CDatabase.DbToLong(dr(CDatabase.FIELD_TRANSACTIONS_ID))
            Dim transDateTime As Date = CType(dr(CDatabase.FIELD_TRANSACTIONS_TRANSDATE), Date)
            Dim sTransType As String = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_TRANSTYPE))
            Dim transactionType As ETransactionType = GetTransactionTypeFromCode(sTransType, True)
            Dim sAccountCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE))
            Dim sInstrumentCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE))
            Dim rRate As Decimal = CDatabase.DbToDecimal(dr(CDatabase.FIELD_TRANSACTIONS_RATE))
            Dim rAmount As Decimal = CDatabase.DbToDecimal(dr(CDatabase.FIELD_TRANSACTIONS_AMOUNT))
            Dim sDesc As String = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_DESCRIPTION))
            Dim lBatch As Long = CDatabase.DbToLong(dr(CDatabase.FIELD_TRANSACTIONS_BATCH))
            Dim rExchangeRate As Decimal = CDatabase.DbToDecimal(dr(CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE))
            Dim transaction As New CTransaction(lId, transDateTime, transactionType, sAccountCode,
                                                sInstrumentCode, rRate, rAmount, sDesc, lBatch, rExchangeRate)
            Return transaction
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

        Friend Shared Function Analyse(transactions As IEnumerable(Of CTransaction), allInstruments As IEnumerable(Of CInstrument),
                                       allCurrencies As IEnumerable(Of CCurrencyDetail)) As CTransactionAnalyserResult

            ' Analyse the "transactions" specified.  allInstruments is just used to get the current rates

            Dim cTransfersIn As Decimal = transactions.Where(Function(c)
                                                                 Return c.TransactionType = ETransactionType.Transfer And
                                                                 c.Amount > 0
                                                             End Function).Sum(Function(c) c.Amount * CDec(IIf(c.Rate > 0, c.Rate, 1)))
            Dim cTransfersOut As Decimal = transactions.Where(Function(c)
                                                                  Return c.TransactionType = ETransactionType.Transfer And
                                                                 c.Amount < 0
                                                              End Function).Sum(Function(c) c.Amount * CDec(IIf(c.Rate > 0, c.Rate, 1)))
            Dim cNetTransfers As Decimal = cTransfersIn + cTransfersOut

            Dim cFees As Decimal = transactions.Where(Function(c)
                                                          Return c.TransactionType = ETransactionType.Fee
                                                      End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))
            Dim cMining As Decimal = transactions.Where(Function(c)
                                                            Return c.TransactionType = ETransactionType.Mining
                                                        End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))

            Dim cBonus As Decimal = transactions.Where(Function(c)
                                                           Return c.TransactionType = ETransactionType.Bonus
                                                       End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))
            Dim cAdjustments As Decimal = transactions.Where(Function(c)
                                                                 Return c.TransactionType = ETransactionType.Adjustment
                                                             End Function).Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))


            Dim cCurrentValue As Decimal = transactions.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))
            Dim cProfitLoss As Decimal = cCurrentValue - cNetTransfers

            Dim balanceByInstrument = From trans In transactions
                                      Order By trans.InstrumentCode
                                      Group By trans.InstrumentCode
                                        Into myGroup = Group, Sum(trans.GetLocalCurrencyBalance(allInstruments, allCurrencies))
                                      Order By InstrumentCode

            Dim currentValues As New List(Of CInstrumentBalance)
            For Each b In balanceByInstrument
                Dim instrument As CInstrument = Nothing
                If Not String.IsNullOrEmpty(b.InstrumentCode) Then
                    instrument = allInstruments.Where(Function(c) c.Code.Equals(b.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                End If
                Dim instrumentBalance = New CInstrumentBalance(instrument, b.Sum)
                currentValues.Add(instrumentBalance)
            Next

            Dim batchesGrouped = From trans In transactions
                                 Group By trans.Batch Into Group
                                 Select Batch,
                                     BatchDate = Group.Max(Function(c) c.TransDate),
                                     AccountCode = Group.Max(Function(c) c.AccountCode),
                                     TransType = Group.Max(Function(c) c.TransactionType),
                                     InstrumentCode = Group.Max(Function(c) c.InstrumentCode),
                                     MonetaryAmount = Group.Sum(Function(c)
                                                                    If String.IsNullOrEmpty(c.InstrumentCode) Then
                                                                        Return c.Amount
                                                                    Else
                                                                        Return 0
                                                                    End If
                                                                End Function),
                                     InstrumentAmount = Group.Sum(Function(c)
                                                                      If String.IsNullOrEmpty(c.InstrumentCode) Then
                                                                          Return 0
                                                                      Else
                                                                          Return c.Amount
                                                                      End If
                                                                  End Function)


            Dim batches As New List(Of CBatch)
            For Each b In batchesGrouped
                batches.Add(New CBatch(b.Batch, b.AccountCode, b.TransType, b.InstrumentCode, b.MonetaryAmount, b.InstrumentAmount))
            Next



            ' Instrument Analysis
            Dim instrumentAnalysis As New List(Of CInstrumentAnalysis)
            Try
                Dim totalsByInstrument = From t In transactions
                                         Group t By t.InstrumentCode Into Group
                                         Select
                                             InstrumentCode,
                                             TotalQuantity = Group.Sum(Function(c) c.Amount),
                                             LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))
                For Each t In totalsByInstrument
                    Dim netCash = batches.Where(Function(c)
                                                    If String.IsNullOrEmpty(c.InstrumentCode) Then
                                                        Return String.IsNullOrEmpty(t.InstrumentCode)
                                                    Else
                                                        Return c.InstrumentCode.Equals(t.InstrumentCode, StringComparison.CurrentCultureIgnoreCase) AndAlso
                                                                                   (c.TransactionType = ETransactionType.Buy OrElse c.TransactionType = ETransactionType.Sell)
                                                    End If
                                                End Function).Sum(Function(c) c.MonetaryAmount)
                    Dim pl = netCash + t.LocalCurrencyValue
                    instrumentAnalysis.Add(New CInstrumentAnalysis(t.InstrumentCode, t.TotalQuantity, t.LocalCurrencyValue, netCash, pl))
                Next
            Catch ex As Exception
                Throw
            End Try




            ' 










            Dim transactionAnalyserResult = New CTransactionAnalyserResult(cTransfersIn, cTransfersOut, cNetTransfers,
                                                                           cFees, cMining, cBonus, cAdjustments, currentValues, cProfitLoss, batches, instrumentAnalysis)

            Return transactionAnalyserResult

        End Function

    End Class

End Namespace
