﻿Namespace Test
    Friend Class CCoinsAndShares

        Private Shared instance As CCoinsAndShares

        Private Shared m_commonObjects As CCommonObjects

        Private Shared m_transactionTypeLookup As Dictionary(Of String, ETransactionType)
        Private Shared m_accountTypeLookup As Dictionary(Of String, Accounts.EAccountType)
        Private Shared m_instrumentTypeLookup As Dictionary(Of String, Instruments.EInstrumentType)

        Private Shared m_transactionCache As IEnumerable(Of CTransaction)
        Private Shared m_accountsCache As IEnumerable(Of CAccount)
        Private Shared m_instrumentsCache As IEnumerable(Of CInstrument)

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

#Region "TRANSACTIONS"
        Friend Shared Iterator Function AllTransactions() As IEnumerable(Of CTransaction)
            If m_transactionCache Is Nothing Then
                m_transactionCache = GetAllTransactions().ToList
            End If
            For Each transaction In m_transactionCache
                Yield transaction
            Next
        End Function
        Private Shared Iterator Function GetAllTransactions() As IEnumerable(Of CTransaction)

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
        Friend Shared Iterator Function AllAccounts() As IEnumerable(Of CAccount)
            If m_accountsCache Is Nothing Then
                m_accountsCache = GetAllAccounts().ToList
            End If
            For Each account In m_accountsCache
                Yield account
            Next
        End Function

        Private Shared Iterator Function GetAllAccounts() As IEnumerable(Of CAccount)
            Dim sql = $"
                SELECT
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME},
                    {CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE},
                    {CDatabase.FIELD_ACCOUNTS_NOTES},
                    {CDatabase.FIELD_ACCOUNTS_NETWORKID},
                    {CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS}
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

                        Dim transactions = AllTransactions.Where(Function(c) c.AccountCode.Equals(accountCode, StringComparison.CurrentCultureIgnoreCase))

                        Yield New CAccount(accountCode, accountName, accountType, notes, networkId, includeOnShortcuts, transactions)

                    End While
                End Using
            End Using

        End Function

#End Region

#Region "INSTRUMENTS"
        Friend Shared Iterator Function AllInstruments() As IEnumerable(Of CInstrument)
            If m_instrumentsCache Is Nothing Then
                m_instrumentsCache = GetAllInstruments().ToList
            End If
            For Each instrument In m_instrumentsCache
                Yield instrument
            Next
        End Function

        Private Shared Iterator Function GetAllInstruments() As IEnumerable(Of CInstrument)
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
    End Class

End Namespace