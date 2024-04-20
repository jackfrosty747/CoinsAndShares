Imports System.Data.SqlServerCe
Imports System.IO
Imports CoinsAndShares.BackupRestore.JSon
Imports CoinsAndShares.Electricity
Imports CoinsAndShares.Networks
Imports CoinsAndShares.Notes
Imports CoinsAndShares.Settings
Imports Newtonsoft.Json

Namespace BackupRestore
    Friend Class CBackupRestore
        Friend Shared Sub Backup(commonObjects As CCommonObjects, fileName As String)
            Dim jsonDatabase = GetJSonDatabase(commonObjects)

            Dim sOut = JsonConvert.SerializeObject(jsonDatabase, Formatting.Indented)

            File.WriteAllText(fileName, sOut)
        End Sub
        Private Shared Function GetJSonDatabase(commonObjects As CCommonObjects) As JSonDatabase

            Dim accounts = GetJsonAccounts(commonObjects.Database)
            Dim currencies = GetJsonCurrencies(commonObjects.Database)
            Dim instruments = GetJsonInstruments(commonObjects.Database)
            Dim transactions = GetJsonTransactions(commonObjects.Database)
            Dim settings = GetJsonSettings(commonObjects)
            Dim snapshots = GetJsonSnapshots(commonObjects.Database)
            Dim electricityItems = GetJsonElectricityItems(commonObjects)
            Dim noteItems = GetJsonNoteItems(commonObjects)
            Dim networksItems = GetJsonNetworksItems(commonObjects)

            Dim db As New JSonDatabase

            db.Fill(accounts, currencies, instruments, transactions, settings, snapshots, electricityItems,
                     noteItems, networksItems)

            Return db
        End Function

        Private Shared Function GetJsonSnapshots(database As CDatabase) As List(Of JSonSnapshot)
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_SNAPSHOTS}
                ORDER BY {CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE};"
            Dim snapshots As New List(Of JSonSnapshot)
            Using dt = database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim snapshotDate As Date? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE)) Then
                        snapshotDate = CType(dr(CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE), Date)
                    End If
                    Dim coinsValue = CDatabase.DbToDecimal(dr(CDatabase.FIELD_SNAPSHOTS_COINSVALUE))
                    Dim sharesValue = CDatabase.DbToDecimal(dr(CDatabase.FIELD_SNAPSHOTS_SHARESVALUE))
                    Dim jsonSnapshot As New JSonSnapshot
                    jsonSnapshot.Fill(snapshotDate, coinsValue, sharesValue)
                    snapshots.Add(jsonSnapshot)
                Next
            End Using
            Return snapshots
        End Function

        Private Shared Function GetJsonElectricityItems(commonObjects As CCommonObjects) As List(Of JSonElectricityItem)
            Dim electricity = commonObjects.Electricity
            Dim all = electricity.GetAll
            Dim out As New List(Of JSonElectricityItem)
            For Each i In all
                Dim item = New JSonElectricityItem()
                item.Fill(i.DateFrom, i.DailyRate)
                out.Add(item)
            Next
            Return out
        End Function

        Private Shared Function GetJsonNoteItems(commonObjects As CCommonObjects) As List(Of JsonNoteItem)
            Dim notes = commonObjects.Notes
            Dim all = notes.GetAll
            Dim out = New List(Of JsonNoteItem)
            For Each i In all
                Dim item = New JsonNoteItem
                item.Fill(i.Id, i.NoteTitle, i.NoteBody)
                out.Add(item)
            Next
            Return out
        End Function

        Private Shared Function GetJsonNetworksItems(commonObjects As CCommonObjects) As List(Of JsonNetworkItem)
            Dim networks = commonObjects.Networks
            Dim all = networks.GetAll
            Dim out As New List(Of JsonNetworkItem)
            For Each n In all
                Dim item = New JsonNetworkItem()
                Dim colour As Integer? = Nothing
                If n.Colour.HasValue Then
                    colour = n.Colour.Value.ToArgb
                End If
                item.Fill(n.NetworkId, n.Description, colour)
                out.Add(item)
            Next
            Return out
        End Function

        Private Shared Function GetJsonAccounts(database As CDatabase) As List(Of JSonAccount)
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_ACCOUNTS}
                ORDER BY {CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE};"
            Dim accounts As New List(Of JSonAccount)
            Using dt = database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim sAccountCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE))
                    Dim sAccountName As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME))
                    Dim sAccountType As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE))
                    Dim sNotes As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_NOTES))
                    Dim sNetworkId As String = CDatabase.DbToString(dr(CDatabase.FIELD_ACCOUNTS_NETWORKID))
                    'Dim iBackgroundColour As Integer? = Nothing
                    'If Not IsDBNull(dr(CDatabase.FIELD_ACCOUNTS_BACKGROUNDCOLOUR__DEPRECATED)) Then
                    '    iBackgroundColour = CDatabase.DbToInt(dr(CDatabase.FIELD_ACCOUNTS_BACKGROUNDCOLOUR__DEPRECATED))
                    'End If
                    Dim includeOnShortcuts = CDatabase.DbToBool(dr(CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS))

                    Dim jsonAccount As New JSonAccount
                    jsonAccount.Fill(sAccountCode, sAccountName, sAccountType, sNotes, sNetworkId, includeOnShortcuts)
                    accounts.Add(jsonAccount)
                Next
            End Using
            Return accounts
        End Function

        Private Shared Function GetJsonCurrencies(database As CDatabase) As List(Of JSonCurrency)
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_CURRENCIES}
                ORDER BY {CDatabase.FIELD_CURRENCIES_CURRENCYCODE};"
            Dim currencies As New List(Of JSonCurrency)
            Using dt = database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim sCurrencyCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_CURRENCIES_CURRENCYCODE))
                    Dim rCurrencyRate As Decimal? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_CURRENCIES_CURRENCYRATE)) Then
                        rCurrencyRate = CType(dr(CDatabase.FIELD_CURRENCIES_CURRENCYRATE), Decimal)
                    End If
                    Dim currency As New JSonCurrency
                    currency.Fill(sCurrencyCode, rCurrencyRate)
                    currencies.Add(currency)
                Next
            End Using
            Return currencies
        End Function

        Private Shared Function GetJsonInstruments(database As CDatabase) As List(Of JSonInstrument)
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_INSTRUMENT}
                ORDER BY {CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE};"
            Dim instruments As New List(Of JSonInstrument)
            Using dt = database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim sInstrumentCode = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE))
                    Dim sInstrumentType = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE))
                    Dim sDescription = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_DESCRIPTION))
                    Dim rRate As Decimal? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_INSTRUMENT_RATE)) Then
                        rRate = CType(dr(CDatabase.FIELD_INSTRUMENT_RATE), Decimal)
                    End If
                    Dim sProviderLinkCode = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE))
                    Dim dtRateUpdated As Date? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED)) Then
                        dtRateUpdated = CType(dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED), Date)
                    End If
                    Dim sCurrencyCode = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_CURRENCYCODE))
                    Dim rProviderMultiplier As Decimal? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER)) Then
                        rProviderMultiplier = CType(dr(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER), Decimal)
                    End If
                    Dim sNotes = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_NOTES))
                    Dim sHedgingGroupCode = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE))
                    Dim iRateProvider = CDatabase.DbToInt(dr(CDatabase.FIELD_INSTRUMENT_RATEPROVIDER))
                    Dim instrument As New JSonInstrument()
                    instrument.Fill(sInstrumentCode, sInstrumentType, sDescription, rRate, sProviderLinkCode,
                                    dtRateUpdated, sCurrencyCode, rProviderMultiplier, sNotes, sHedgingGroupCode, iRateProvider)

                    instruments.Add(instrument)
                Next
            End Using
            Return instruments
        End Function

        Private Shared Function GetJsonTransactions(database As CDatabase) As List(Of JSonTransaction)
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_TRANSACTIONS}
                ORDER BY {CDatabase.FIELD_TRANSACTIONS_ID};"
            Dim transactions As New List(Of JSonTransaction)
            Using dt = database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim lId = CDatabase.DbToLong(dr(CDatabase.FIELD_TRANSACTIONS_ID))
                    Dim transDate As Date? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_TRANSDATE)) Then
                        transDate = CType(dr(CDatabase.FIELD_TRANSACTIONS_TRANSDATE), Date)
                    End If
                    Dim sTransType = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_TRANSTYPE))
                    Dim sAccountCode = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE))
                    Dim sInstrumentCode = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE))
                    Dim rRate As Decimal? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_RATE)) Then
                        rRate = CType(dr(CDatabase.FIELD_TRANSACTIONS_RATE), Decimal)
                    End If
                    Dim cAmount As Decimal? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_AMOUNT)) Then
                        cAmount = CType(dr(CDatabase.FIELD_TRANSACTIONS_AMOUNT), Decimal)
                    End If
                    Dim sDescription = CDatabase.DbToString(dr(CDatabase.FIELD_TRANSACTIONS_DESCRIPTION))
                    Dim iBatch As Integer? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_BATCH)) Then
                        iBatch = CType(dr(CDatabase.FIELD_TRANSACTIONS_BATCH), Integer)
                    End If
                    Dim rExchangeRate As Decimal? = Nothing
                    If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE)) Then
                        rExchangeRate = CType(dr(CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE), Decimal)
                    End If
                    Dim transaction As New JSonTransaction
                    transaction.Fill(lId, transDate, sTransType, sAccountCode, sInstrumentCode, rRate, cAmount, sDescription, iBatch, rExchangeRate)
                    transactions.Add(transaction)
                Next
            End Using
            Return transactions
        End Function

        Private Shared Function GetJsonSettings(commonObjects As CCommonObjects) As JSonSettings
            Dim jsonSettings As New JSonSettings
            Dim s As New CSettings(commonObjects)
            jsonSettings.Fill(s.AlphavantageKey, s.RateUpdateWarningHours, s.ExchangeRatesApiKey, s.DefaultBackupPath)
            Return jsonSettings
        End Function

        Friend Shared Sub Restore(commonObjects As CCommonObjects, jsonDatabase As JSonDatabase)
            commonObjects.Database.TransactionBegin()
            Try
                RestoreNow(commonObjects, jsonDatabase)
                commonObjects.Database.TransactionCommit()
            Catch ex As Exception
                commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Shared Sub RestoreNow(commonObjects As CCommonObjects, jsonDatabase As JSonDatabase)
            commonObjects.Database.TransactionEnsureActive()
            commonObjects.Database.CleardownNow()
            ImportCurrenciesNow(commonObjects.Database, jsonDatabase.Currencies)
            ImportAccountsNow(commonObjects.Database, jsonDatabase.Accounts)
            ImportInstrumentsNow(commonObjects.Database, jsonDatabase.Instruments)
            ImportTransactionsNow(commonObjects.Database, jsonDatabase.Transactions)
            ImportSettingsNow(commonObjects, jsonDatabase.Settings)
            ImportSnapshotsNow(commonObjects.Database, jsonDatabase.Snapshots)
            ImportElectricityItemsNow(commonObjects, jsonDatabase.ElectricityItems)
            ImportNoteItemsNow(commonObjects, jsonDatabase.NoteItems)
            ImportNetworksItemsNow(commonObjects, jsonDatabase.NetworksItems)
        End Sub

        Private Shared Sub ImportElectricityItemsNow(commonObjects As CCommonObjects, electricityItems As List(Of JSonElectricityItem))
            Dim all = New List(Of CElectricityItem)
            For Each i In electricityItems
                Dim item = New CElectricityItem(i.DateFrom, i.DailyRate)
                all.Add(item)
            Next
            Dim electricity = commonObjects.Electricity
            electricity.SaveAllNow(all)
        End Sub

        Private Shared Sub ImportNoteItemsNow(commonObjects As CCommonObjects, noteItems As List(Of JsonNoteItem))
            Dim all = New List(Of CNote)
            For Each n In noteItems
                Dim item = New CNote(n.Id, n.NoteTitle, n.NoteBody)
                all.Add(item)
            Next
            Dim notes = commonObjects.Notes
            notes.SaveAllNow(all)
        End Sub


        Private Shared Sub ImportNetworksItemsNow(commonObjects As CCommonObjects, networksItems As List(Of JsonNetworkItem))
            Dim all = New List(Of CNetwork)
            For Each n In networksItems
                Dim colour As Color? = Nothing
                If n.Colour.HasValue Then
                    colour = Color.FromArgb(n.Colour.Value)
                End If
                Dim item = New CNetwork(n.NetworkId, n.Description, colour)
                all.Add(item)
            Next
            Dim networks = commonObjects.Networks
            networks.SaveAllNow(all)
        End Sub

        Private Shared Sub ImportSnapshotsNow(database As CDatabase, snapshots As List(Of JSonSnapshot))
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_SNAPSHOTS};"
            Using cm = database.GetCommand(sql)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        For Each s In snapshots.Where(Function(c) c.SnapshotDate.HasValue)
                            Dim dr = dt.NewRow
                            dr(CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE) = s.SnapshotDate.Value
                            dr(CDatabase.FIELD_SNAPSHOTS_COINSVALUE) = s.CoinsValue
                            dr(CDatabase.FIELD_SNAPSHOTS_SHARESVALUE) = s.SharesValue
                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Shared Sub ImportSettingsNow(commonObjects As CCommonObjects, jsonSettings As JSonSettings)
            Dim settings As New CSettings(commonObjects)
            Dim sAlphavantageApiKey As String = String.Empty
            Dim rateUpdateWarningHours As Integer? = Nothing
            Dim sExchangeRatesApiKey As String = String.Empty
            Dim sDefaultBackupPath = String.Empty
            If jsonSettings IsNot Nothing Then
                sAlphavantageApiKey = jsonSettings.AlphavantageApiKey
                rateUpdateWarningHours = jsonSettings.RateUpdateWarningHours
                sExchangeRatesApiKey = jsonSettings.ExchangeRatesApiKey
                sDefaultBackupPath = jsonSettings.DefaultBackupPath
            End If
            settings.SaveSettingsNow(sAlphavantageApiKey, rateUpdateWarningHours, sExchangeRatesApiKey, sDefaultBackupPath)
        End Sub

        Private Shared Sub ImportTransactionsNow(database As CDatabase, transactions As List(Of JSonTransaction))
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_TRANSACTIONS};"
            Using cm = database.GetCommand(sql)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        For Each t In transactions
                            Dim dr = dt.NewRow
                            dr(CDatabase.FIELD_TRANSACTIONS_ID) = t.Id
                            If t.TransDate.HasValue Then
                                dr(CDatabase.FIELD_TRANSACTIONS_TRANSDATE) = t.TransDate.Value
                            End If
                            If Not String.IsNullOrEmpty(t.TransType) Then
                                dr(CDatabase.FIELD_TRANSACTIONS_TRANSTYPE) = t.TransType
                            End If
                            If Not String.IsNullOrEmpty(t.AccountCode) Then
                                dr(CDatabase.FIELD_TRANSACTIONS_ACCOUNTCODE) = t.AccountCode
                            End If
                            If Not String.IsNullOrEmpty(t.InstrumentCode) Then
                                dr(CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE) = t.InstrumentCode
                            End If
                            If t.Rate.HasValue Then
                                dr(CDatabase.FIELD_TRANSACTIONS_RATE) = t.Rate.Value
                            End If
                            If t.Amount.HasValue Then
                                dr(CDatabase.FIELD_TRANSACTIONS_AMOUNT) = t.Amount.Value
                            End If
                            If Not String.IsNullOrEmpty(t.Description) Then
                                dr(CDatabase.FIELD_TRANSACTIONS_DESCRIPTION) = t.Description
                            End If
                            If t.Batch.HasValue Then
                                dr(CDatabase.FIELD_TRANSACTIONS_BATCH) = t.Batch.Value
                            End If
                            If t.ExchangeRate.HasValue Then
                                dr(CDatabase.FIELD_TRANSACTIONS_EXCHANGERATE) = t.ExchangeRate.Value
                            End If

                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Shared Sub ImportInstrumentsNow(database As CDatabase, instruments As List(Of JSonInstrument))
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_INSTRUMENT};"
            Using cm = database.GetCommand(sql)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        For Each i In instruments
                            Dim dr = dt.NewRow
                            dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE) = i.InstrumentCode
                            If Not String.IsNullOrEmpty(i.InstrumentType) Then
                                dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE) = i.InstrumentType
                            End If
                            If Not String.IsNullOrEmpty(i.Description) Then
                                dr(CDatabase.FIELD_INSTRUMENT_DESCRIPTION) = i.Description
                            End If
                            If i.Rate.HasValue Then
                                dr(CDatabase.FIELD_INSTRUMENT_RATE) = i.Rate.Value
                            End If
                            If Not String.IsNullOrEmpty(i.ProviderLinkCode) Then
                                dr(CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE) = i.ProviderLinkCode
                            End If
                            If i.RateUpdated.HasValue Then
                                dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED) = i.RateUpdated.Value
                            End If
                            If Not String.IsNullOrEmpty(i.CurrencyCode) Then
                                dr(CDatabase.FIELD_INSTRUMENT_CURRENCYCODE) = i.CurrencyCode
                            End If
                            If i.ProviderMultiplier.HasValue Then
                                dr(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER) = i.ProviderMultiplier
                            End If
                            dr(CDatabase.FIELD_INSTRUMENT_NOTES) = i.Notes
                            dr(CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE) = i.HedgingGroupCode
                            dr(CDatabase.FIELD_INSTRUMENT_RATEPROVIDER) = i.RateProvider
                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Shared Sub ImportAccountsNow(database As CDatabase, accounts As List(Of JSonAccount))
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_ACCOUNTS};"
            Using cm = database.GetCommand(sql)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        For Each a In accounts
                            Dim dr = dt.NewRow
                            dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTCODE) = a.AccountCode
                            If Not String.IsNullOrEmpty(a.AccountName) Then
                                dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTNAME) = a.AccountName
                            End If
                            If Not String.IsNullOrEmpty(a.AccountType) Then
                                dr(CDatabase.FIELD_ACCOUNTS_ACCOUNTTYPE) = a.AccountType
                            End If
                            dr(CDatabase.FIELD_ACCOUNTS_NOTES) = a.Notes
                            If Not String.IsNullOrEmpty(a.NetworkId) Then
                                dr(CDatabase.FIELD_ACCOUNTS_NETWORKID) = a.NetworkId
                            End If

                            dr(CDatabase.FIELD_ACCOUNTS_INCLUDEONSHORTCUTS) = a.IncludeOnShortcuts

                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Shared Sub ImportCurrenciesNow(database As CDatabase, currencies As List(Of JSonCurrency))
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_CURRENCIES};"
            Using cm = database.GetCommand(sql)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        For Each c In currencies
                            Dim dr = dt.NewRow
                            dr(CDatabase.FIELD_CURRENCIES_CURRENCYCODE) = c.CurrencyCode
                            If c.CurrencyRate.HasValue Then
                                dr(CDatabase.FIELD_CURRENCIES_CURRENCYRATE) = c.CurrencyRate.Value
                            End If
                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Friend Shared Function ReadFile(fileName As String) As JSonDatabase
            Dim sIn = File.ReadAllText(fileName)
            Dim jsonDatabase = JsonConvert.DeserializeObject(Of JSonDatabase)(sIn)
            Return jsonDatabase
        End Function
    End Class
End Namespace
