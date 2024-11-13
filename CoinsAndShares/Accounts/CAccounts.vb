Imports System.Collections.ObjectModel
Imports System.Data.SqlServerCe
Imports CoinsAndShares.Transactions

Namespace Accounts
    Friend Class CAccounts
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_all As IEnumerable(Of CAccount)
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Function GetAll() As IEnumerable(Of CAccount)
            If m_all Is Nothing Then
                m_all = GetAllNow()
            End If
            Return m_all
        End Function
        Private Function GetAllNow() As IEnumerable(Of CAccount)
            Dim sql As String = $"              
                SELECT *
                FROM {CDatabase.TABLE_ACCOUNTS} a LEFT JOIN {CDatabase.TABLE_TRANSACTIONS} t ON
                    a.{CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} = t.{CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE}
                ORDER BY a.{CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE}, t.{CDatabase.FIELD_TRANSACTIONS_ID};"
            Dim accounts As New Dictionary(Of String, CAccount)
            Dim result As New List(Of CAccount)

            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim accountCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE))
                    Dim account As CAccount = Nothing

                    If Not accounts.TryGetValue(accountCode, account) Then
                        Dim accountName As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME))
                        Dim accountType As EAccountType = GetAccountTypeFromCode(CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE)), True)
                        Dim notes As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_NOTES))
                        Dim networkId As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_NETWORKID))
                        Dim includeOnShortcuts = CDatabase.DbToBool(dr(CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS))
                        Dim nonTaxable = CDatabase.DbToBool(dr(CDatabase.FIELD_ACCOUNTS_NONTAXABLE))

                        account = New CAccount(accountCode, accountName, accountType, notes, networkId, includeOnShortcuts, nonTaxable)
                        accounts.Add(accountCode, account)
                        result.Add(account)
                    End If

                    If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_ID)) Then
                        Dim transaction = CTransactions.GetTransactionFromDr(dr)
                        account.Transactions.Add(transaction)
                    End If
                Next
            End Using

            Return result
        End Function

        Friend Sub CreateNew(sCode As String, sDescription As String, accountType As EAccountType)
            m_commonObjects.Database.TransactionBegin()
            Try
                Dim all = GetAll()
                If all.Where(Function(c) c.AccountCode.Equals(sCode, StringComparison.CurrentCultureIgnoreCase)).Any Then
                    Throw New Exception(My.Resources.Error_ItemAlreadyExists)
                End If
                CreateNewNow(sCode, sDescription, accountType)
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub CreateNewNow(sCode As String, sDescription As String, accountType As EAccountType)
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql As String = $"
                INSERT INTO {CDatabase.TABLE_ACCOUNTS} (
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE}
                ) VALUES (
                    {CDatabase.SqlString(sCode)},
                    {CDatabase.SqlString(sDescription)},
                    {CDatabase.SqlString(accountType.Code)}
                );"
            m_commonObjects.Database.ExecuteQuery(sql)
        End Sub

        Friend Sub Update(account As CAccount)
            m_commonObjects.Database.TransactionBegin()
            Try
                UpdateNow(account)
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub

        Friend Sub ProcessAdjustment(adjustment As CAdjustment)
            Dim adjustments As New List(Of CAdjustment) From {adjustment}
            ProcessAdjustments(adjustments)
        End Sub
        Friend Sub ProcessAdjustments(adjustments As IEnumerable(Of CAdjustment))
            Dim transactions = m_commonObjects.Transactions

            Dim ts As New Collection(Of CTransaction)
            For Each adjustment In adjustments
                Dim rAmount As Decimal
                Dim rRate As Decimal = 0
                If String.IsNullOrEmpty(adjustment.InstrumentCode) Then
                    rAmount = Math.Round(adjustment.Amount, 2, MidpointRounding.AwayFromZero)
                Else
                    rAmount = adjustment.Quantity
                    rRate = adjustment.Rate
                End If
                ts.Add(New CTransaction(0, adjustment.TransDate, adjustment.TransactionType, adjustment.AccountCode, adjustment.InstrumentCode,
                                 rRate, rAmount, adjustment.Description, 0, 0, False))
            Next

            transactions.AddNewTransactions(ts)
        End Sub

        Private Sub UpdateNow(account As CAccount)
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_ACCOUNTS}
                WHERE {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} = {CDatabase.SqlString(account.AccountCode)};"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da As New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        If dt.Rows.Count = 0 Then
                            Throw New Exception(My.Resources.Error_ItemNotFound)
                        End If
                        Dim dr = dt.Rows(0)
                        dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME) = account.AccountName
                        dr(CDatabase.FIELD_ACCOUNTS_NOTES) = account.Notes
                        dr(CDatabase.FIELD_ACCOUNTS_NETWORKID) = account.NetworkId
                        'dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE) = account.AccountType.Code ' Don't allow change account type

                        'If account.Color__DEPRECATED.HasValue Then
                        '    dr(CDatabase.FIELD_ACCOUNTS_BACKGROUNDCOLOUR) = account.Color__DEPRECATED.Value.ToArgb
                        'Else
                        '    dr(CDatabase.FIELD_ACCOUNTS_BACKGROUNDCOLOUR) = DBNull.Value
                        'End If

                        dr(CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS) = account.IncludeOnShortcuts
                        dr(CDatabase.FIELD_ACCOUNTS_NONTAXABLE) = account.NonTaxable

                        Using cb As New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Friend Sub Delete(sAccountCode As String)
            m_commonObjects.Database.TransactionBegin()
            Try
                DeleteNow(sAccountCode)
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub DeleteNow(sAccountCode As String)
            m_commonObjects.Database.TransactionEnsureActive()

            Dim transactions = m_commonObjects.Transactions
            Dim accountTransactions = transactions.GetAll.Where(
                Function(c) c.AccountCode.Equals(sAccountCode, StringComparison.CurrentCultureIgnoreCase))

            ' Make sure entire batches are deleted.  I.e. transfers from and to are complete batches
            Dim batchesToDelete = accountTransactions.Select(Function(c) c.Batch).Distinct
            If batchesToDelete.Any Then
                transactions.DeleteBatchesNow(batchesToDelete)
            End If

            Dim sql = $"
                DELETE
                FROM {CDatabase.TABLE_ACCOUNTS}
                WHERE {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} = {CDatabase.SqlString(sAccountCode)};"
            m_commonObjects.Database.ExecuteQuery(sql)
        End Sub

        Friend Sub ProcessTransfer(transfer As CTransfer)
            Dim transactions = m_commonObjects.Transactions

            Dim allTransactions = GetTransferTransactions(transfer)

            Dim transfers = allTransactions.Where(Function(c) c.TransactionType = ETransactionType.Transfer)
            transactions.AddNewTransactions(transfers)

            Dim fees = allTransactions.Where(Function(c) Not c.TransactionType = ETransactionType.Transfer)
            For Each t In fees
                transactions.AddNewTransactions(New List(Of CTransaction) From {t})
            Next

        End Sub

        Friend Shared Function GetTransferTransactions(transfer As CTransfer) As IEnumerable(Of CTransaction)

            Dim sDescriptionSuffix = String.Empty
            If Not String.IsNullOrEmpty(transfer.DescriptionSuffix) Then
                sDescriptionSuffix &= " - " & transfer.DescriptionSuffix
            End If

            Dim ts As New Collection(Of CTransaction)
            If transfer.IntermediateAmount <> 0 Then
                ts.Add(New CTransaction(0, transfer.SendDateTime, ETransactionType.Transfer, transfer.AccountCodeFrom, String.Empty, 0, transfer.IntermediateAmount * -1, GetTransDescriptionTransferTo(transfer.AccountCodeTo) & sDescriptionSuffix, 0, 0, False))
            End If
            If transfer.SendFee <> 0 Then
                ts.Add(New CTransaction(0, transfer.SendDateTime, ETransactionType.Fee, transfer.AccountCodeFrom, String.Empty, 0, transfer.SendFee * -1, GetTransDescriptionFeeForSending(transfer.AccountCodeTo) & sDescriptionSuffix, 0, 0, False))
            End If
            If transfer.ReceiveCredit <> 0 Then
                ts.Add(New CTransaction(0, transfer.ReceiveDateTime, ETransactionType.Transfer, transfer.AccountCodeTo, String.Empty, 0, transfer.IntermediateAmount, GetTransDescriptionReceiptFrom(transfer.AccountCodeFrom) & sDescriptionSuffix, 0, 0, False))
            End If
            If transfer.ReceiveFee <> 0 Then
                ts.Add(New CTransaction(0, transfer.ReceiveDateTime, ETransactionType.Fee, transfer.AccountCodeTo, String.Empty, 0, transfer.ReceiveFee * -1, GetTransDescriptionFeeForReceiving(transfer.AccountCodeFrom) & sDescriptionSuffix, 0, 0, False))
            End If
            Return ts

        End Function

        Friend Sub ProcessBuySell(buySell As CBuySell)
            Dim transactions = m_commonObjects.Transactions
            Dim ts = GetBuySellTransactions(buySell)
            transactions.AddNewTransactions(ts)
        End Sub

        Friend Function GetBuySellTransactions(buySell As CBuySell) As IEnumerable(Of CTransaction)
            Dim transactions = m_commonObjects.Transactions

            If buySell.Quantity = 0 Then
                Throw New Exception(My.Resources.Error_QuantityNotValid)
            End If

            Dim instruments = m_commonObjects.Instruments
            Dim currencies = m_commonObjects.Currencies
            Dim rExchangeRate = instruments.GetExchangeRate(buySell.InstrumentCode, currencies)

            ' Recalculate the rate to make sure it all adds up
            buySell.Rate = buySell.Amount * rExchangeRate / buySell.Quantity

            Dim transactionType = If(buySell.BuySell = EBuySell.Buy, ETransactionType.Buy, ETransactionType.Sell)

            Dim sDesc As String = $"{buySell.BuySell} {buySell.InstrumentCode}"

            Dim iBuySellMult As Integer = 1
            If buySell.BuySell = EBuySell.Sell Then
                iBuySellMult *= -1
            End If

            Dim ts As New Collection(Of CTransaction) From {
                New CTransaction(0, buySell.BuySellDate, transactionType, buySell.AccountCode, String.Empty, 0, buySell.Amount * -1 * iBuySellMult, sDesc, 0, 0, False),
                New CTransaction(0, buySell.BuySellDate, transactionType, buySell.AccountCode, buySell.InstrumentCode, buySell.Rate, buySell.Quantity * iBuySellMult, sDesc, 0, rExchangeRate, False)
            }
            Return ts
        End Function

        Friend Sub ProcessSwap(swap As CSwap)

            Dim transactions = m_commonObjects.Transactions

            Dim ts As New List(Of CTransaction)

            Dim cSellValue = swap.FromQuantity * swap.FromRate

            Dim sell As New CBuySell(EBuySell.Sell, swap.FromInstrumentCode, swap.SwapDate, swap.FromQuantity, swap.FromRate, cSellValue, swap.AccountCode)
            transactions.AddNewTransactions(GetBuySellTransactions(sell))

            Dim toRate = cSellValue / swap.ToQuantity

            Dim buy As New CBuySell(EBuySell.Buy, swap.ToInstrumentCode, swap.SwapDate, swap.ToQuantity, swap.ToRate, cSellValue, swap.AccountCode)
            transactions.AddNewTransactions(GetBuySellTransactions(buy))

        End Sub

        Private Sub DataChanged()
            m_all = Nothing
            m_commonObjects.ClearCache()
            m_commonObjects.RefreshForms()
        End Sub

    End Class

End Namespace
