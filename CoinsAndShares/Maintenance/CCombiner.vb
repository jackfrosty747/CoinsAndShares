Imports CoinsAndShares.Transactions

Namespace Maintenance
    Friend Class CCombiner
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub

        Friend Sub Combine(AccountCode As String, TransactionType As ETransactionType)

            Dim transactions = New CTransactions(m_commonObjects)
            Dim allTrans = transactions.GetAll()

            allTrans = allTrans.Where(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))
            allTrans = allTrans.Where(Function(c) c.TransactionType = TransactionType)

            Dim groups = New List(Of Grouped)

            For Each trans In allTrans
                Dim group = groups.FirstOrDefault(Function(c)
                                                      Return c.Year = trans.TransDate.Year And c.Month = trans.TransDate.Month And c.Instrument.Equals(trans.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)
                                                  End Function)
                If group Is Nothing Then
                    group = New Grouped(trans.TransDate.Year, trans.TransDate.Month, trans.InstrumentCode)
                    groups.Add(group)
                End If
                group.TotalRateAmount += trans.Amount * trans.Rate
                group.TotalAmount += trans.Amount
                group.Counter += 1
            Next

            Dim newTransactions = New List(Of CTransaction)

            For Each group In groups
                Dim dDate = New Date(group.Year, group.Month, 1)
                dDate = dDate.AddMonths(1).AddDays(-1)
                Dim rAverageRate As Decimal
                If group.TotalAmount <> 0 Then
                    rAverageRate = group.TotalRateAmount / group.TotalAmount
                End If
                Dim sDesc = $"Merged {group.Counter} transactions"

                Dim rExchangeRate As Decimal ' Not sure yet

                Dim transaction = New CTransaction(0, dDate, TransactionType, AccountCode, group.Instrument, rAverageRate,
                                                   group.TotalAmount, sDesc, 0, rExchangeRate)

                newTransactions.Add(transaction)
            Next

            m_commonObjects.Database.TransactionBegin()
            Try
                Dim sql = $"
                    DELETE
                    FROM {CDatabase.TABLE_TRANSACTIONS}
                    WHERE {CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE} = {CDatabase.SqlString(AccountCode)} AND
                        {CDatabase.FIELD_TRANSACTIONS_TRANSTYPE} = {CDatabase.SqlString(TransactionType.Code)};"
                m_commonObjects.Database.ExecuteQuery(sql)

                transactions.AddNewTransactionsNow(newTransactions)

                m_commonObjects.Database.TransactionCommit()

            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try

        End Sub

        Private Class Grouped
            Friend Sub New(year As Integer, month As Integer, instrument As String)
                Me.Year = year
                Me.Month = month
                Me.Instrument = instrument
            End Sub
            Friend ReadOnly Property Year As Integer
            Friend ReadOnly Property Month As Integer
            Friend ReadOnly Property Instrument As String
            Friend Property TotalRateAmount As Decimal
            Friend Property TotalAmount As Decimal
            Friend Property Counter As Integer
        End Class

    End Class

End Namespace
