Imports System.Data.SqlServerCe

Namespace Test
    Friend Class CCoinsAndShares

        Private Shared instance As CCoinsAndShares

        Private ReadOnly m_commonObjects As CCommonObjects

        Private ReadOnly m_transactionTypeLookup As Dictionary(Of String, ETransactionType)
        Private ReadOnly m_accountTypeLookup As Dictionary(Of String, Accounts.EAccountType)
        Private ReadOnly m_instrumentTypeLookup As Dictionary(Of String, Instruments.EInstrumentType)

        Private m_transactionCache As IEnumerable(Of CTransaction)
        Private m_accountsCache As IEnumerable(Of CAccount)
        Private m_instrumentsCache As IEnumerable(Of CInstrument)
        Private m_networksCache As IEnumerable(Of CNetwork)

        Private Sub New(commonObjects As CCommonObjects)

            m_commonObjects = commonObjects

            ' When calling thousands of times, this is quicker than using the enum directly
            m_transactionTypeLookup = New Dictionary(Of String, ETransactionType)
            For Each tt As ETransactionType In [Enum].GetValues(GetType(ETransactionType))
                m_transactionTypeLookup.Add(tt.Code.ToUpper, tt)
            Next

            m_accountTypeLookup = New Dictionary(Of String, Accounts.EAccountType)
            For Each act As Accounts.EAccountType In [Enum].GetValues(GetType(Accounts.EAccountType))
                m_accountTypeLookup.Add(act.Code.ToUpper, act)
            Next

            m_instrumentTypeLookup = New Dictionary(Of String, Instruments.EInstrumentType)
            For Each inst As Instruments.EInstrumentType In [Enum].GetValues(GetType(Instruments.EInstrumentType))
                m_instrumentTypeLookup.Add(inst.Code.ToUpper, inst)
            Next

        End Sub

        Friend Shared Function GetInstance(commonObjects As CCommonObjects) As CCoinsAndShares
            If instance Is Nothing Then
                instance = New CCoinsAndShares(commonObjects)
            End If
            Return instance
        End Function

        Private Sub ClearCacheAndRefreshForms()
            ClearCache()
            m_commonObjects.RefreshForms()
        End Sub

        Friend Sub ClearCache()
            m_transactionCache = Nothing
            m_accountsCache = Nothing
            m_instrumentsCache = Nothing
            m_networksCache = Nothing
        End Sub

#Region "TRANSACTIONS"
        Friend Iterator Function AllTransactions() As IEnumerable(Of CTransaction)
            If m_transactionCache Is Nothing Then
                m_transactionCache = GetAllTransactions().ToList
            End If
            For Each transaction In m_transactionCache
                Yield transaction
            Next
        End Function
        Private Iterator Function GetAllTransactions() As IEnumerable(Of CTransaction)

            Const CURRENT_INSTRUMENT_RATE = "currentInstrumentRate"
            Const CURRENT_EXCHANGE_RATE = "currentExchangeRate"

            Dim sql = $"
                SELECT 
                    t.{CDatabase.FIELD_TRANSACTIONS_ID},
                    t.{CDatabase.FIELD_TRANSACTIONS_TRANSDATE},
                    t.{CDatabase.FIELD_TRANSACTIONS_TRANSTYPE},
                    t.{CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE},
                    t.{CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE},
                    t.{CDatabase.FIELD_TRANSACTIONS_RATE},
                    t.{CDatabase.FIELD_TRANSACTIONS_AMOUNT},
                    t.{CDatabase.FIELD_TRANSACTIONS_DESCRIPTION},
                    t.{CDatabase.FIELD_TRANSACTIONS_BATCH},
                    t.{CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE},

                    i.{CDatabase.FIELD_INSTRUMENT_RATE} {CURRENT_INSTRUMENT_RATE},
                    c.{CDatabase.FIELD_CURRENCIES_CURRENCYRATE} {CURRENT_EXCHANGE_RATE}

                FROM
                    {CDatabase.TABLE_TRANSACTIONS} t LEFT JOIN {CDatabase.TABLE_INSTRUMENT} i ON
                        t.{CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE} = i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE} LEFT JOIN {CDatabase.TABLE_CURRENCIES} c ON
                        i.{CDatabase.FIELD_INSTRUMENT_CURRENCYCODE} = c.{CDatabase.FIELD_CURRENCIES_CURRENCYCODE}
                WHERE
                    1=1
                ORDER BY
                    {CDatabase.FIELD_TRANSACTIONS_ID};"

            Dim instruments = AllInstruments()

            Using cmd = m_commonObjects.Database.GetCommand(sql)
                Using dr = cmd.ExecuteReader
                    Dim iIdOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_ID)
                    Dim iTransDateOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_TRANSDATE)
                    Dim iTransTypeOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_TRANSTYPE)
                    Dim iAccountCodeOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE)
                    Dim iInstrumentCodeOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE)
                    Dim iRateOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_RATE)
                    Dim iAmountOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_AMOUNT)
                    Dim iDescriptionOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_DESCRIPTION)
                    Dim iBatchOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_BATCH)
                    Dim iExchangeRateOrdinal = dr.GetOrdinal(CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE)
                    Dim iCurrentInstrumentRateOrdinal = dr.GetOrdinal(CURRENT_INSTRUMENT_RATE)
                    Dim iCurrentExchangeRateOrdinal = dr.GetOrdinal(CURRENT_EXCHANGE_RATE)

                    While dr.Read
                        Dim id = dr.GetFieldValue(Of Integer)(iIdOrdinal)
                        Dim transDate = dr.GetFieldValue(Of Date)(iTransDateOrdinal)

                        Dim transTypeCode = If(dr.IsDBNull(iTransTypeOrdinal), String.Empty, dr.GetFieldValue(Of String)(iTransTypeOrdinal)).ToUpper
                        Dim transType As ETransactionType
                        If Not m_transactionTypeLookup.TryGetValue(transTypeCode, transType) Then
                            transType = ETransactionType.Unknown
                        End If

                        Dim accountCode = If(dr.IsDBNull(iAccountCodeOrdinal), Nothing, dr.GetFieldValue(Of String)(iAccountCodeOrdinal))

                        Dim instrumentCode = If(dr.IsDBNull(iInstrumentCodeOrdinal), String.Empty, dr.GetFieldValue(Of String)(iInstrumentCodeOrdinal))

                        Dim rate = If(dr.IsDBNull(iRateOrdinal), 0, dr.GetFieldValue(Of Decimal)(iRateOrdinal))
                        Dim amount = If(dr.IsDBNull(iAmountOrdinal), 0, dr.GetFieldValue(Of Decimal)(iAmountOrdinal))
                        Dim description = If(dr.IsDBNull(iDescriptionOrdinal), Nothing, dr.GetFieldValue(Of String)(iDescriptionOrdinal))
                        Dim batch = If(dr.IsDBNull(iBatchOrdinal), 0, dr.GetFieldValue(Of Integer)(iBatchOrdinal))
                        Dim exchangeRate = If(dr.IsDBNull(iExchangeRateOrdinal), 0, dr.GetFieldValue(Of Single)(iExchangeRateOrdinal))

                        Dim currentInstrumentRate = If(dr.IsDBNull(iCurrentInstrumentRateOrdinal), 0, dr.GetFieldValue(Of Decimal)(iCurrentInstrumentRateOrdinal))
                        Dim currentExchangeRate = If(dr.IsDBNull(iCurrentExchangeRateOrdinal), 0, dr.GetFieldValue(Of Single)(iCurrentExchangeRateOrdinal))

                        Yield New CTransaction(id, transDate, transType, accountCode, instrumentCode, rate,
                                                 amount, description, batch, exchangeRate, currentInstrumentRate, currentExchangeRate)
                    End While
                End Using
            End Using

        End Function
#End Region

#Region "ACCOUNTS"
        Friend Iterator Function AllAccounts() As IEnumerable(Of CAccount)
            If m_accountsCache Is Nothing Then
                m_accountsCache = GetAllAccounts().ToList
            End If
            For Each account In m_accountsCache
                Yield account
            Next
        End Function

        Private Iterator Function GetAllAccounts() As IEnumerable(Of CAccount)
            Dim sql = $"
                SELECT
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE},
                    {CDatabase.FIELD_ACCOUNTS_NOTES},
                    {CDatabase.FIELD_ACCOUNTS_NETWORKID},
                    {CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS},
                    {CDatabase.FIELD_ACCOUNTS_NONTAXABLE}
                FROM
                    {CDatabase.TABLE_ACCOUNTS}
                ORDER BY
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE};"

            Using cmd = m_commonObjects.Database.GetCommand(sql)
                Using dr = cmd.ExecuteReader
                    Dim iAccountCodeOrdinal = dr.GetOrdinal(CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE)
                    Dim iAccountNameOrdinal = dr.GetOrdinal(CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME)
                    Dim iAccountTypeOrdinal = dr.GetOrdinal(CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE)
                    Dim iNotesOrdinal = dr.GetOrdinal(CDatabase.FIELD_ACCOUNTS_NOTES)
                    Dim iNetworkIdOrdinal = dr.GetOrdinal(CDatabase.FIELD_ACCOUNTS_NETWORKID)
                    Dim iIncludeOnShortCutsOrdinal = dr.GetOrdinal(CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS)
                    Dim iNonTaxableOrdinal = dr.GetOrdinal(CDatabase.FIELD_ACCOUNTS_NONTAXABLE)

                    While dr.Read
                        Dim accountCode = dr.GetFieldValue(Of String)(iAccountCodeOrdinal)
                        Dim accountName = If(dr.IsDBNull(iAccountNameOrdinal), String.Empty, dr.GetString(iAccountNameOrdinal))

                        Dim accountTypeCode = If(dr.IsDBNull(iAccountTypeOrdinal), String.Empty, dr.GetFieldValue(Of String)(iAccountTypeOrdinal)).ToUpper
                        Dim accountType As Accounts.EAccountType
                        If Not m_accountTypeLookup.TryGetValue(accountTypeCode, accountType) Then
                            accountType = Accounts.EAccountType.Bank_Account
                        End If

                        Dim notes = If(dr.IsDBNull(iNotesOrdinal), String.Empty, dr.GetFieldValue(Of String)(iNotesOrdinal))
                        Dim networkId = If(dr.IsDBNull(iNetworkIdOrdinal), String.Empty, dr.GetFieldValue(Of String)(iNetworkIdOrdinal))
                        Dim includeOnShortcuts = Not dr.IsDBNull(iIncludeOnShortCutsOrdinal) AndAlso dr.GetFieldValue(Of Boolean)(iIncludeOnShortCutsOrdinal)
                        Dim nonTaxable = Not dr.IsDBNull(iNonTaxableOrdinal) AndAlso dr.GetFieldValue(Of Boolean)(iNonTaxableOrdinal)

                        Dim transactions = AllTransactions.Where(Function(c) c.AccountCode.Equals(accountCode, StringComparison.CurrentCultureIgnoreCase))

                        Yield New CAccount(accountCode, accountName, accountType, notes, networkId, includeOnShortcuts, nonTaxable, transactions)

                    End While
                End Using
            End Using

        End Function

        Friend Sub UpdateAccount(account As CAccount)
            Dim sql = $"
                SELECT {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE},
                    {CDatabase.FIELD_ACCOUNTS_NOTES},
                    {CDatabase.FIELD_ACCOUNTS_NETWORKID},
                    {CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS},
                    {CDatabase.FIELD_ACCOUNTS_NONTAXABLE}
                FROM {CDatabase.TABLE_ACCOUNTS}
                WHERE {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} = @accountCode;"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                cm.Parameters.AddWithValue("@accountCode", account.AccountCode)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt = New DataTable
                        da.Fill(dt)
                        Dim dr As DataRow
                        If dt.Rows.Count = 0 Then
                            dr = dt.NewRow()
                            dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE) = account.AccountCode
                            dt.Rows.Add(dr)
                        Else
                            dr = dt.Rows(0)
                        End If
                        dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME) = account.AccountName
                        dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE) = account.AccountType.Code
                        dr(CDatabase.FIELD_ACCOUNTS_NOTES) = account.Notes
                        dr(CDatabase.FIELD_ACCOUNTS_NETWORKID) = account.NetworkId
                        dr(CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS) = account.IncludeOnShortcuts
                        dr(CDatabase.FIELD_ACCOUNTS_NONTAXABLE) = account.NonTaxable
                        Using cb As New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
            ClearCacheAndRefreshForms()
        End Sub

        Friend Sub CreateAccount(accountCode As String, accountName As String, accountType As Accounts.EAccountType)
            If AllAccounts.Any(Function(c) c.AccountCode.Equals(accountCode, StringComparison.CurrentCultureIgnoreCase)) Then
                Throw New Exception(My.Resources.Error_ItemAlreadyExists)
            End If
            Dim account = New CAccount(accountCode, accountName, accountType, Nothing, Nothing, Nothing, Nothing, transactions:=Nothing)
            UpdateAccount(account)
        End Sub

        Friend Sub DeleteAccount(accountCode As String)
            m_commonObjects.Database.TransactionBegin()
            Try
                DeleteAccountNow(accountCode)
                m_commonObjects.Database.TransactionCommit()
                ClearCacheAndRefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub DeleteAccountNow(accountCode As String)
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql = $"DELETE FROM {CDatabase.TABLE_TRANSACTIONS} WHERE {CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE} = @code;"
            Using cmd = m_commonObjects.Database.GetCommand(sql)
                cmd.Parameters.AddWithValue("@code", accountCode)
                cmd.ExecuteNonQuery()
            End Using
            sql = $"DELETE FROM {CDatabase.TABLE_ACCOUNTS} WHERE {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} = @code;"
            Using cmd = m_commonObjects.Database.GetCommand(sql)
                cmd.Parameters.AddWithValue("@code", accountCode)
                cmd.ExecuteNonQuery()
            End Using
        End Sub

        Friend Sub RenameAccount(sFrom As String, sTo As String)
            m_commonObjects.Database.TransactionBegin()
            Try
                RenameAccountNow(sFrom, sTo)
                'm_commonObjects.Database.TransactionRollback()
                m_commonObjects.Database.TransactionCommit()
                ClearCacheAndRefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub

        Private Sub RenameAccountNow(sFrom As String, sTo As String)

            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_ACCOUNTS}
                WHERE {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE} = @Code;"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                cm.Parameters.AddWithValue("@Code", sFrom)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt = New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count = 0 Then
                            Throw New DataException($"Cannot find account FROM {sFrom}")
                        End If

                        Dim cb = New SqlCeCommandBuilder(da)

                        ' Duplicate account record
                        Dim drExisting = dt.Rows(0)
                        Dim drNew = dt.NewRow
                        For i = 0 To dt.Columns.Count - 1
                            drNew(i) = If(dt.Columns(i).ColumnName = CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE, sTo, drExisting(i))
                        Next
                        dt.Rows.Add(drNew)
                        da.Update(dt)

                        ' Move transactions across to new account
                        sql = $"
                            UPDATE {CDatabase.TABLE_TRANSACTIONS}
                            SET {CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE} = @New WHERE {CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE} = @Old;"
                        Using cmTrans = m_commonObjects.Database.GetCommand(sql)
                            cmTrans.Parameters.AddWithValue("@Old", sFrom)
                            cmTrans.Parameters.AddWithValue("@New", sTo)
                            cmTrans.ExecuteNonQuery()
                        End Using

                        sql = $"UPDATE {CDatabase.TABLE_TRANSACTIONS} SET {CDatabase.FIELD_TRANSACTIONS_DESCRIPTION} = @New WHERE {CDatabase.FIELD_TRANSACTIONS_DESCRIPTION} LIKE @Old;"
                        Using cmTrans = m_commonObjects.Database.GetCommand(sql)
                            cmTrans.Parameters.Clear()
                            cmTrans.Parameters.AddWithValue("@Old", Accounts.GetTransDescriptionTransferTo(sFrom))
                            cmTrans.Parameters.AddWithValue("@New", Accounts.GetTransDescriptionTransferTo(sTo))
                            cmTrans.ExecuteNonQuery()

                            cmTrans.Parameters.Clear()
                            cmTrans.Parameters.AddWithValue("@Old", Accounts.GetTransDescriptionFeeForSending(sFrom))
                            cmTrans.Parameters.AddWithValue("@New", Accounts.GetTransDescriptionFeeForSending(sTo))
                            cmTrans.ExecuteNonQuery()

                            cmTrans.Parameters.Clear()
                            cmTrans.Parameters.AddWithValue("@Old", Accounts.GetTransDescriptionReceiptFrom(sFrom))
                            cmTrans.Parameters.AddWithValue("@New", Accounts.GetTransDescriptionReceiptFrom(sTo))
                            cmTrans.ExecuteNonQuery()

                            cmTrans.Parameters.Clear()
                            cmTrans.Parameters.AddWithValue("@Old", Accounts.GetTransDescriptionFeeForReceiving(sFrom))
                            cmTrans.Parameters.AddWithValue("@New", Accounts.GetTransDescriptionFeeForReceiving(sTo))
                            cmTrans.ExecuteNonQuery()
                        End Using




                        ' Remove old account
                        drExisting.Delete()
                        da.Update(dt)
                    End Using
                End Using
            End Using
        End Sub

#End Region

#Region "INSTRUMENTS"
        Friend Iterator Function AllInstruments() As IEnumerable(Of CInstrument)
            If m_instrumentsCache Is Nothing Then
                m_instrumentsCache = GetAllInstruments().ToList
            End If
            For Each instrument In m_instrumentsCache
                Yield instrument
            Next
        End Function

        Private Iterator Function GetAllInstruments() As IEnumerable(Of CInstrument)
            Dim sql = $"
                SELECT
                    {CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE},
                    {CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE},
                    {CDatabase.FIELD_INSTRUMENT_DESCRIPTION},
                    {CDatabase.FIELD_INSTRUMENT_RATE},
                    {CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE},
                    {CDatabase.FIELD_INSTRUMENT_RATEUPDATED},
                    {CDatabase.FIELD_INSTRUMENT_CURRENCYCODE},
                    {CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER},
                    {CDatabase.FIELD_INSTRUMENT_NOTES},
                    {CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE}
                FROM
                    {CDatabase.TABLE_INSTRUMENT}
                ORDER BY
                    {CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE};"

            Using cmd = m_commonObjects.Database.GetCommand(sql)
                Using dr = cmd.ExecuteReader
                    Dim iInstrumentCodeOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE)
                    Dim iInstrumentTypeOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE)
                    Dim iDescriptionOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_DESCRIPTION)
                    Dim iRateOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_RATE)
                    Dim iProvideLinkCodeOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE)
                    Dim iRateUpdatedOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_RATEUPDATED)
                    Dim iCurrencyCodeOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_CURRENCYCODE)
                    Dim iProviderMultiplierOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER)
                    Dim iNotesOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_NOTES)
                    Dim iHedgingGroupCodeOrdinal = dr.GetOrdinal(CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE)

                    While dr.Read
                        Dim instrumentCode = dr.GetFieldValue(Of String)(iInstrumentCodeOrdinal)

                        Dim instrumentTypeCode = If(dr.IsDBNull(iInstrumentTypeOrdinal), String.Empty, dr.GetFieldValue(Of String)(iInstrumentTypeOrdinal))
                        Dim instrumentType As Instruments.EInstrumentType
                        If Not m_instrumentTypeLookup.TryGetValue(instrumentTypeCode, instrumentType) Then
                            instrumentType = Instruments.EInstrumentType.Crypto
                        End If

                        Dim description = If(dr.IsDBNull(iDescriptionOrdinal), String.Empty, dr.GetFieldValue(Of String)(iDescriptionOrdinal))
                        Dim rate = If(dr.IsDBNull(iRateOrdinal), 0, dr.GetFieldValue(Of Decimal)(iRateOrdinal))
                        Dim providerLinkCode = If(dr.IsDBNull(iProvideLinkCodeOrdinal), String.Empty, dr.GetFieldValue(Of String)(iProvideLinkCodeOrdinal))
                        Dim rateUpdated = If(dr.IsDBNull(iRateUpdatedOrdinal), Nothing, dr.GetFieldValue(Of Date?)(iRateUpdatedOrdinal))
                        Dim currencyCode = If(dr.IsDBNull(iCurrencyCodeOrdinal), String.Empty, dr.GetFieldValue(Of String)(iCurrencyCodeOrdinal))
                        Dim providerMultiplier = If(dr.IsDBNull(iProviderMultiplierOrdinal), 0, dr.GetFieldValue(Of Decimal)(iProviderMultiplierOrdinal))
                        Dim notes = If(dr.IsDBNull(iNotesOrdinal), String.Empty, dr.GetFieldValue(Of String)(iNotesOrdinal))
                        Dim hedgingGroupCode = If(dr.IsDBNull(iHedgingGroupCodeOrdinal), String.Empty, dr.GetFieldValue(Of String)(iHedgingGroupCodeOrdinal))

                        Dim transactions = AllTransactions.Where(Function(c) c.InstrumentCode.Equals(instrumentCode, StringComparison.CurrentCultureIgnoreCase))

                        Yield New CInstrument(instrumentCode, instrumentType, description, rate, providerLinkCode, rateUpdated,
                                                         currencyCode, providerMultiplier, notes, hedgingGroupCode, transactions)
                    End While
                End Using
            End Using

        End Function

#End Region

#Region "NETWORKS"
        Friend Iterator Function AllNetworks() As IEnumerable(Of CNetwork)
            If m_networksCache Is Nothing Then
                m_networksCache = GetAllNetworks().ToList
            End If
            For Each network In m_networksCache
                Yield network
            Next
        End Function
        Private Iterator Function GetAllNetworks() As IEnumerable(Of CNetwork)
            Dim sql = $"
                SELECT {CDatabase.FIELD_NETWORKS_NETWORKID}, {CDatabase.FIELD_NETWORKS_DESCRIPTION}, {CDatabase.FIELD_NETWORKS_COLOUR}
                FROM {CDatabase.TABLE_NETWORKS}
                ORDER BY {CDatabase.FIELD_NETWORKS_NETWORKID};"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using dr = cm.ExecuteReader
                    Dim iNetworkIdOrdinal = dr.GetOrdinal(CDatabase.FIELD_NETWORKS_NETWORKID)
                    Dim iDescriptionOrdinal = dr.GetOrdinal(CDatabase.FIELD_NETWORKS_DESCRIPTION)
                    Dim iColourOrdinal = dr.GetOrdinal(CDatabase.FIELD_NETWORKS_COLOUR)
                    While dr.Read
                        Dim networkId = dr.GetFieldValue(Of String)(iNetworkIdOrdinal)
                        Dim description = If(dr.IsDBNull(iDescriptionOrdinal), String.Empty, dr.GetFieldValue(Of String)(iDescriptionOrdinal))
                        Dim colour As Color? = Nothing
                        If Not dr.IsDBNull(iColourOrdinal) Then
                            Dim iColour = dr.GetFieldValue(Of Integer)(iColourOrdinal)
                            Try
                                Dim c = Color.FromArgb(iColour)
                                colour = c
                            Catch ignored As Exception
                            End Try
                        End If
                        Yield New CNetwork(networkId, description, colour)
                    End While
                End Using
            End Using

        End Function

#End Region

#Region "DATA"
        Friend Sub ProcessFiatTransfer(accountCodeFrom As String, accountCodeTo As String, amount As Decimal, transactionDate As Date)
            accountCodeFrom = accountCodeFrom.ToUpper
            accountCodeTo = accountCodeTo.ToUpper
            amount = Decimal.Round(amount, 2)

            Dim batch = New List(Of CTransaction) From {
                New CTransaction(0, transactionDate, ETransactionType.Transfer, accountCodeFrom, Nothing, 0, amount * -1, $"Transfer to account {accountCodeTo}", 0, 0, 0, 0),
                New CTransaction(0, transactionDate, ETransactionType.Transfer, accountCodeTo, Nothing, 0, amount, $"Transfer from account {accountCodeFrom}", 0, 0, 0, 0)
            }

            AddBatch(batch)
        End Sub

        Private Sub AddBatch(batch As List(Of CTransaction))
            m_commonObjects.Database.TransactionBegin()
            Try
                AddBatchNow(batch)
                m_commonObjects.Database.TransactionCommit()
                ClearCacheAndRefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub

        Private Sub AddBatchNow(batch As IEnumerable(Of CTransaction))
            m_commonObjects.Database.TransactionEnsureActive()
            Dim lBatch = GetMaxBatch() + 1
            Dim lId = GetMaxId()
            For Each transaction In batch
                lId += 1
                transaction.Id = lId
                transaction.Batch = lBatch
                SaveTransactionNow(transaction)
            Next
        End Sub

        Private Sub SaveTransactionNow(transaction As CTransaction)
            m_commonObjects.Database.TransactionEnsureActive()

            If transaction.Id <= 0 OrElse transaction.Batch <= 0 Then
                Throw New ArgumentOutOfRangeException("Transaction ID and Batch must be used when adding transactions")
            End If

            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_TRANSACTIONS}
                WHERE {CDatabase.FIELD_TRANSACTIONS_ID} = @id;"

            Using cm = m_commonObjects.Database.GetCommand(sql)
                cm.Parameters.AddWithValue("@id", transaction.Id)

                Using da As New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        dt.PrimaryKey = New DataColumn() {dt.Columns(CDatabase.FIELD_TRANSACTIONS_ID)}
                        Dim dr = dt.Rows.Find(transaction.Id)
                        If dt.Rows.Count = 0 Then
                            dr = dt.NewRow()
                            dr(CDatabase.FIELD_TRANSACTIONS_ID) = transaction.Id
                            dt.Rows.Add(dr)
                        End If

                        dr(CDatabase.FIELD_TRANSACTIONS_TRANSDATE) = transaction.TransactionDate
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

        Private Function GetMaxBatch() As Integer
            Dim sql = $"
                SELECT Max({CDatabase.FIELD_TRANSACTIONS_BATCH})
                FROM {CDatabase.TABLE_TRANSACTIONS};"
            Return m_commonObjects.Database.ExecuteScalar(Of Integer)(sql)
        End Function

        Private Function GetMaxId() As Integer
            Dim sql As String = $"
                SELECT Max({CDatabase.FIELD_TRANSACTIONS_ID})
                FROM {CDatabase.TABLE_TRANSACTIONS};"
            Return m_commonObjects.Database.ExecuteScalar(Of Integer)(sql)
        End Function

#End Region
    End Class

End Namespace
