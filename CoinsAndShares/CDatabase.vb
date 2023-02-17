Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data.SqlServerCe
Imports System.IO

Friend Class CDatabase : Implements IDisposable

    Private Const DB_VERSION As Integer = 25

    Friend Const DATABASE_PASSWORD = "1234"

    Private Const ERROR_TRANSACTION_IS_ACTIVE As String = "Transaction is active"
    Private Const ERROR_TRANSACTION_IS_NOT_ACTIVE As String = "Transaction is not active"

    Friend Const TABLE_ACCOUNTS As String = "tblAccounts"
    Friend Const TABLE_DBVERSION As String = "tblDbVersion"
    Friend Const TABLE_INSTRUMENT As String = "tblInstrument"
    Friend Const TABLE_TRANSACTIONS As String = "tblTransactions"
    Friend Const TABLE_CURRENCIES As String = "tblCurrencies"
    Friend Const TABLE_SETTINGS As String = "tblSettings"
    Friend Const TABLE_SNAPSHOTS As String = "tblSnapshots"
    Friend Const TABLE_ELECTRICITY As String = "tblElectricity"
    Friend Const TABLE_HEDGINGGROUPS__DEPRECATED As String = "tblHedgingGroups"
    Friend Const TABLE_LIQUIDATION As String = "tblLiquidation"
    Friend Const TABLE_NETWORKS As String = "tblNetworks"
    Friend Const TABLE_NOTES As String = "tblNotes"

    Friend Const FIELD_DBVERSION_DBVERSION As String = "dbVersion"

    Friend Const FIELD_ACCOUNTS_ACCOUNTCODE As String = "accountCode"
    Friend Const FIELD_ACCOUNTS_ACCOUNTNAME As String = "accountName"
    Friend Const FIELD_ACCOUNTS_ACCOUNTTYPE As String = "accountType"
    Friend Const FIELD_ACCOUNTS_NOTES As String = "notes"
    Friend Const FIELD_ACCOUNTS_NETWORKID As String = "networkId"
    Friend Const FIELD_ACCOUNTS_BACKGROUNDCOLOUR__DEPRECATED As String = "backgroundColour"
    Friend Const FIELD_ACCOUNTS_INCLUDEONSHORTCUTS As String = "includeOnShortcuts"

    Friend Const FIELD_CURRENCIES_CURRENCYCODE As String = "currencyCode"
    Friend Const FIELD_CURRENCIES_CURRENCYRATE As String = "currencyRate"

    Friend Const FIELD_ELECTRICITY_DATEFROM As String = "dateFrom"
    Friend Const FIELD_ELECTRICITY_DAILYRATE As String = "rate"

    Friend Const FIELD_HEDGINGGROUPS_HEDGINGGROUPCODE As String = "hedgingGroupCode"
    Friend Const FIELD_HEDGINGGROUPS_DESCRIPTION As String = "description"

    Friend Const FIELD_INSTRUMENT_INSTRUMENTCODE As String = "instrumentCode"
    Friend Const FIELD_INSTRUMENT_INSTRUMENTTYPE As String = "instrumentType"
    Friend Const FIELD_INSTRUMENT_DESCRIPTION As String = "description"
    Friend Const FIELD_INSTRUMENT_RATE As String = "rate"
    Friend Const FIELD_INSTRUMENT_RATEUPDATED As String = "rateUpdated"
    Friend Const FIELD_INSTRUMENT_PROVIDERLINKCODE As String = "providerLinkCode" ' Coingecko or whoever we use's ID for this instrument code
    Friend Const FIELD_INSTRUMENT_PROVIDERMULTIPLIER As String = "providerMultiplier" ' In case the units returned by the provider are different
    Friend Const FIELD_INSTRUMENT_CURRENCYCODE As String = "currencyCode"
    Friend Const FIELD_INSTRUMENT_NOTES As String = "notes"
    Friend Const FIELD_INSTRUMENT_HEDGINGGROUPCODE As String = "hedgingGroupCode"

    Friend Const FIELD_LIQUIDATION_ID As String = "id"
    Friend Const FIELD_LIQUIDATION_ACCOUNTCODE As String = "accountCode"
    Friend Const FIELD_LIQUIDATION_INSTRUMENTCODE As String = "instrumentCode"
    Friend Const FIELD_LIQUIDATION_RATE As String = "rate"
    Friend Const FIELD_LIQUIDATION_NOTE As String = "note"

    Friend Const FIELD_NETWORKS_NETWORKID As String = "networkId"
    Friend Const FIELD_NETWORKS_DESCRIPTION As String = "description"
    Friend Const FIELD_NETWORKS_COLOUR As String = "colour"

    Friend Const FIELD_NOTES_NOTEID As String = "id"
    Friend Const FIELD_NOTES_NOTETITLE As String = "noteTitle"
    Friend Const FIELD_NOTES_NOTEBODY As String = "noteBody"

    Friend Const FIELD_SETTINGS_ID As String = "id"
    Friend Const FIELD_SETTINGS_ALPHAVANTAGEKEY As String = "alphavantageKey"
    Friend Const FIELD_SETTINGS_RATEUPDATEWARNINGHOURS As String = "rateUpdateWarningHours"
    Friend Const FIELD_SETTINGS_EXCHANGERATESAPIKEY As String = "exchangeRatesApiKey"
    Friend Const FIELD_SETTINGS_DEFAULTBACKUPPATH As String = "defaultBackupPath"

    Friend Const FIELD_SNAPSHOTS_SNAPSHOTDATE As String = "snapshotDate"
    Friend Const FIELD_SNAPSHOTS_COINSVALUE As String = "coinsValue"
    Friend Const FIELD_SNAPSHOTS_SHARESVALUE As String = "sharesValue"

    Friend Const FIELD_TRANSACTIONS_ID As String = "id"
    Friend Const FIELD_TRANSACTIONS_TRANSDATE As String = "transDate"
    Friend Const FIELD_TRANSACTIONS_TRANSTYPE As String = "transType"
    Friend Const FIELD_TRANSACTIONS_ACCOUNTCODE As String = "accountCode"
    Friend Const FIELD_TRANSACTIONS_INSTRUMENTCODE As String = "instrumentCode"
    Friend Const FIELD_TRANSACTIONS_RATE As String = "rate"
    Friend Const FIELD_TRANSACTIONS_AMOUNT As String = "amount"
    Friend Const FIELD_TRANSACTIONS_DESCRIPTION As String = "description"
    Friend Const FIELD_TRANSACTIONS_BATCH As String = "batch"
    Friend Const FIELD_TRANSACTIONS_EXCHANGERATE As String = "exchangeRate"

    Friend Const LENGTH_ACCOUNTS_ACCOUNTCODE As Integer = 20
    Friend Const LENGTH_ACCOUNTS_ACCOUNTTYPE As Integer = 1
    Friend Const LENGTH_ACCOUNTS_NETWORKID As Integer = 20

    Friend Const LENGTH_CURRENCIES_CURRENCYCODE As Integer = 10

    Friend Const LENGTH_HEDGINGGROUPS_HEDGINGGROUPCODE As Integer = 10

    Friend Const LENGTH_INSTRUMENT_INSTRUMENTTYPE As Integer = 1
    Friend Const LENGTH_INSTRUMENT_CODE As Integer = 10
    Friend Const LENGTH_INSTRUMENT_CURRENCYCODE As Integer = 10
    Friend Const LENGTH_INSTRUMENT_HEDGINGGROUPCODE = LENGTH_HEDGINGGROUPS_HEDGINGGROUPCODE

    Friend Const LENGTH_NETWORKS_NETWORKID = LENGTH_ACCOUNTS_NETWORKID

    Friend Const LENGTH_TRANSACTIONS_TRANSTYPE As Integer = 1

    Private ReadOnly m_sConnectionString As String
    Private ReadOnly m_sqlConnection As SqlCeConnection

    Private m_sqlTransaction As SqlCeTransaction
    Private disposedValue As Boolean

    Private Enum EFieldType
        <Description("int")> Int
        <Description("nvarchar")> NVarChar
        <Description("ntext")> NText
        '<Description("decimal (11, 4)")> DecimalNormal
        <Description("decimal (20, 10)")> DecimalLong
        <Description("real")> Real
        <Description("float")> Float_
        <Description("datetime")> DateTime
        <Description("bit")> Bit
    End Enum

    Friend Shared Function GetDatabaseLocation() As String

        Dim sDatabaseFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CoinsAndShares.sdf")

        Return sDatabaseFile

    End Function

    Friend Sub New()

        Dim sDatabaseFile = GetDatabaseLocation()

        m_sConnectionString = $"Data Source={sDatabaseFile}; Password={DATABASE_PASSWORD};"

        If Not File.Exists(sDatabaseFile) Then
            Using sqlCeEngine As New SqlCeEngine(m_sConnectionString)
                sqlCeEngine.CreateDatabase()
            End Using
        End If

        m_sqlConnection = New SqlCeConnection(m_sConnectionString)
        m_sqlConnection.Open()

        TransactionBegin()
        Try
            Dim iCurrentVersion As Integer = GetDbVersion()

            If iCurrentVersion < 1 Then
                CreateTable(TABLE_DBVERSION, FIELD_DBVERSION_DBVERSION, EFieldType.Int, 0)
            End If

            If iCurrentVersion < 2 Then
                CreateTable(TABLE_INSTRUMENT, FIELD_INSTRUMENT_INSTRUMENTCODE, EFieldType.NVarChar, LENGTH_INSTRUMENT_CODE)
                AddField(FIELD_INSTRUMENT_INSTRUMENTTYPE, TABLE_INSTRUMENT, EFieldType.NVarChar, LENGTH_INSTRUMENT_INSTRUMENTTYPE)
                AddField(FIELD_INSTRUMENT_DESCRIPTION, TABLE_INSTRUMENT, EFieldType.NText, 0)
                AddField(FIELD_INSTRUMENT_RATE, TABLE_INSTRUMENT, EFieldType.DecimalLong, 0)
                AddField(FIELD_INSTRUMENT_PROVIDERLINKCODE, TABLE_INSTRUMENT, EFieldType.NText, 0)
            End If

            If iCurrentVersion < 3 Then
                CreateTable(TABLE_ACCOUNTS, FIELD_ACCOUNTS_ACCOUNTCODE, EFieldType.NVarChar, LENGTH_ACCOUNTS_ACCOUNTCODE)
                AddField(FIELD_ACCOUNTS_ACCOUNTNAME, TABLE_ACCOUNTS, EFieldType.NText, 0)
                AddField(FIELD_ACCOUNTS_ACCOUNTTYPE, TABLE_ACCOUNTS, EFieldType.NVarChar, LENGTH_ACCOUNTS_ACCOUNTTYPE)
            End If

            If iCurrentVersion < 4 Then
                CreateTable(TABLE_TRANSACTIONS, FIELD_TRANSACTIONS_ID, EFieldType.Int, 0)
                AddField(FIELD_TRANSACTIONS_TRANSDATE, TABLE_TRANSACTIONS, EFieldType.DateTime, 0)
                AddField(FIELD_TRANSACTIONS_TRANSTYPE, TABLE_TRANSACTIONS, EFieldType.NVarChar, LENGTH_TRANSACTIONS_TRANSTYPE)
                AddField(FIELD_TRANSACTIONS_ACCOUNTCODE, TABLE_TRANSACTIONS, EFieldType.NVarChar, LENGTH_ACCOUNTS_ACCOUNTCODE)
                AddRelation(TABLE_ACCOUNTS, TABLE_TRANSACTIONS, FIELD_ACCOUNTS_ACCOUNTCODE, FIELD_TRANSACTIONS_ACCOUNTCODE)
                AddIndex(TABLE_TRANSACTIONS, New Collection(Of String)({FIELD_ACCOUNTS_ACCOUNTCODE}), False)
                AddField(FIELD_TRANSACTIONS_INSTRUMENTCODE, TABLE_TRANSACTIONS, EFieldType.NVarChar, LENGTH_INSTRUMENT_CODE)
                AddRelation(TABLE_INSTRUMENT, TABLE_TRANSACTIONS, FIELD_INSTRUMENT_INSTRUMENTCODE, FIELD_TRANSACTIONS_INSTRUMENTCODE)
                AddIndex(TABLE_TRANSACTIONS, New Collection(Of String)({FIELD_INSTRUMENT_INSTRUMENTCODE}), False)
                AddField(FIELD_TRANSACTIONS_RATE, TABLE_TRANSACTIONS, EFieldType.DecimalLong, 0)
                AddField(FIELD_TRANSACTIONS_AMOUNT, TABLE_TRANSACTIONS, EFieldType.DecimalLong, 0)
                AddField(FIELD_TRANSACTIONS_DESCRIPTION, TABLE_TRANSACTIONS, EFieldType.NText, 0)
            End If

            If iCurrentVersion < 5 Then
                AddField(FIELD_TRANSACTIONS_BATCH, TABLE_TRANSACTIONS, EFieldType.Int, 0)
                AddIndex(TABLE_TRANSACTIONS, New Collection(Of String)({FIELD_TRANSACTIONS_BATCH}), False)
            End If

            If iCurrentVersion < 6 Then
                AddField(FIELD_INSTRUMENT_RATEUPDATED, TABLE_INSTRUMENT, EFieldType.DateTime, 0)
            End If

            If iCurrentVersion < 7 Then
                CreateTable(TABLE_CURRENCIES, FIELD_CURRENCIES_CURRENCYCODE, EFieldType.NVarChar, LENGTH_CURRENCIES_CURRENCYCODE)
                AddField(FIELD_CURRENCIES_CURRENCYRATE, TABLE_CURRENCIES, EFieldType.Real, 0)
            End If

            If iCurrentVersion < 8 Then
                AddField(FIELD_INSTRUMENT_CURRENCYCODE, TABLE_INSTRUMENT, EFieldType.NVarChar, LENGTH_INSTRUMENT_CURRENCYCODE)
            End If

            If iCurrentVersion < 9 Then
                AddField(FIELD_TRANSACTIONS_EXCHANGERATE, TABLE_TRANSACTIONS, EFieldType.Real, 0)
            End If

            If iCurrentVersion < 10 Then
                AddField(FIELD_INSTRUMENT_PROVIDERMULTIPLIER, TABLE_INSTRUMENT, EFieldType.DecimalLong, 0)
            End If

            If iCurrentVersion < 11 Then
                CreateTable(TABLE_SETTINGS, FIELD_SETTINGS_ID, EFieldType.Int, 0)
                AddField(FIELD_SETTINGS_ALPHAVANTAGEKEY, TABLE_SETTINGS, EFieldType.NText, 0)
            End If

            'ExecuteQuery($"drop table {TABLE_SNAPSHOTS}")
            'ExecuteQuery($"update {TABLE_DBVERSION} set {FIELD_DBVERSION_DBVERSION} = 11")

            If iCurrentVersion < 12 Then
                CreateTable(TABLE_SNAPSHOTS, FIELD_SNAPSHOTS_SNAPSHOTDATE, EFieldType.DateTime, 0)
                AddField(FIELD_SNAPSHOTS_COINSVALUE, TABLE_SNAPSHOTS, EFieldType.DecimalLong, 0)
                AddField(FIELD_SNAPSHOTS_SHARESVALUE, TABLE_SNAPSHOTS, EFieldType.DecimalLong, 0)
            End If

            If iCurrentVersion < 13 Then
                AddField(FIELD_SETTINGS_RATEUPDATEWARNINGHOURS, TABLE_SETTINGS, EFieldType.Int, 0)
            End If

            If iCurrentVersion < 14 Then
                AddField(FIELD_INSTRUMENT_NOTES, TABLE_INSTRUMENT, EFieldType.NText, 0)
                AddField(FIELD_ACCOUNTS_NOTES, TABLE_ACCOUNTS, EFieldType.NText, 0)
            End If

            If iCurrentVersion < 15 Then
                AddField(FIELD_SETTINGS_EXCHANGERATESAPIKEY, TABLE_SETTINGS, EFieldType.NText, 0)
            End If

            If iCurrentVersion < 16 Then
                AddField(FIELD_ACCOUNTS_NETWORKID, TABLE_ACCOUNTS, EFieldType.NVarChar, LENGTH_ACCOUNTS_NETWORKID)
            End If

            If iCurrentVersion < 17 Then
                CreateTable(TABLE_ELECTRICITY, FIELD_ELECTRICITY_DATEFROM, EFieldType.DateTime, 0)
                AddField(FIELD_ELECTRICITY_DAILYRATE, TABLE_ELECTRICITY, EFieldType.DecimalLong, 0)
            End If

            If iCurrentVersion < 18 Then
                ' Hedging
                CreateTable(TABLE_HEDGINGGROUPS__DEPRECATED, FIELD_HEDGINGGROUPS_HEDGINGGROUPCODE, EFieldType.NVarChar, LENGTH_HEDGINGGROUPS_HEDGINGGROUPCODE)
                AddField(FIELD_HEDGINGGROUPS_DESCRIPTION, TABLE_HEDGINGGROUPS__DEPRECATED, EFieldType.NText, 0)

                AddField(FIELD_INSTRUMENT_HEDGINGGROUPCODE, TABLE_INSTRUMENT, EFieldType.NVarChar, LENGTH_INSTRUMENT_HEDGINGGROUPCODE)
            End If

            If iCurrentVersion < 19 Then
                ExecuteQuery($"DROP TABLE {TABLE_HEDGINGGROUPS__DEPRECATED};")
            End If

            If iCurrentVersion < 20 Then
                AddField(FIELD_ACCOUNTS_BACKGROUNDCOLOUR__DEPRECATED, TABLE_ACCOUNTS, EFieldType.Int, 0)
            End If

            If iCurrentVersion < 21 Then
                AddField(FIELD_ACCOUNTS_INCLUDEONSHORTCUTS, TABLE_ACCOUNTS, EFieldType.Bit, 0)
            End If

            If iCurrentVersion < 22 Then
                CreateTable(TABLE_LIQUIDATION, FIELD_LIQUIDATION_ID, EFieldType.Int, 0)
                AddField(FIELD_LIQUIDATION_ACCOUNTCODE, TABLE_LIQUIDATION, EFieldType.NVarChar, LENGTH_ACCOUNTS_ACCOUNTCODE)
                AddField(FIELD_LIQUIDATION_INSTRUMENTCODE, TABLE_LIQUIDATION, EFieldType.NVarChar, LENGTH_INSTRUMENT_CODE)
                AddIndex(TABLE_LIQUIDATION, New List(Of String) From {FIELD_LIQUIDATION_ACCOUNTCODE, FIELD_LIQUIDATION_INSTRUMENTCODE}, True)
                AddField(FIELD_LIQUIDATION_RATE, TABLE_LIQUIDATION, EFieldType.DecimalLong, 0)
                AddField(FIELD_LIQUIDATION_NOTE, TABLE_LIQUIDATION, EFieldType.NText, 0)
            End If

            If iCurrentVersion < 23 Then
                CreateTable(TABLE_NOTES, FIELD_NOTES_NOTEID, EFieldType.Int, 0)
                AddField(FIELD_NOTES_NOTETITLE, TABLE_NOTES, EFieldType.NText, 0)
                AddField(FIELD_NOTES_NOTEBODY, TABLE_NOTES, EFieldType.NText, 0)
            End If

            If iCurrentVersion < 24 Then
                AddField(FIELD_SETTINGS_DEFAULTBACKUPPATH, TABLE_SETTINGS, EFieldType.NText, 0)
            End If

            If iCurrentVersion < 25 Then
                CreateTable(TABLE_NETWORKS, FIELD_NETWORKS_NETWORKID, EFieldType.NVarChar, LENGTH_NETWORKS_NETWORKID)
                AddField(FIELD_NETWORKS_DESCRIPTION, TABLE_NETWORKS, EFieldType.NText, 0)
                AddField(FIELD_NETWORKS_COLOUR, TABLE_NETWORKS, EFieldType.Int, 0)
            End If

            If iCurrentVersion < DB_VERSION Then
                SetDbVersion()
            End If

            TransactionCommit()
        Catch
            TransactionRollback()
            Throw
        End Try
    End Sub

    Private Sub AddRelation(sMasterTable As String, sSecondTable As String, sMasterField As String,
                            sSecondField As String)
        Dim sRelationName As String = "FK_" & sSecondTable & "_" & sMasterTable
        Dim sql As String = $"
            ALTER TABLE {sSecondTable}
            ADD CONSTRAINT {sRelationName} FOREIGN KEY ({sSecondField})
            REFERENCES {sMasterTable} ({sMasterField});"
        ExecuteQuery(sql)
    End Sub

    Friend Sub AddIndex(sTableName As String, fields As IEnumerable(Of String), fUnique As Boolean)

        Dim sIndexName As String = $"IX_{sTableName}"
        Dim sFieldList As String = String.Empty
        For Each field In fields
            sIndexName &= $"_{field}"
            If Not String.IsNullOrEmpty(sFieldList) Then
                sFieldList &= ", "
            End If
            sFieldList &= field
        Next

        Dim sql As String = $"
            CREATE {IIf(fUnique, "UNIQUE ", " ")}INDEX {sIndexName}
            ON {sTableName} (" & sFieldList & ");"

        ExecuteQuery(sql)

    End Sub

    Private Sub AddField(sFieldName As String, sTableName As String, fieldType As EFieldType, iVarCharLength As Integer)
        Dim sVarCharLength As String = String.Empty
        If fieldType = EFieldType.NVarChar Then
            sVarCharLength = $" ({iVarCharLength})"
        End If
        Dim sql As String = $"
            ALTER TABLE [{sTableName}]
            ADD [{sFieldName}] {fieldType.Code}{sVarCharLength};"
        ExecuteQuery(sql)
    End Sub

    Private Sub SetDbVersion()
        TransactionEnsureActive()
        Dim sql As String = $"DELETE FROM {TABLE_DBVERSION};"
        ExecuteQuery(sql)
        sql = $"INSERT INTO {TABLE_DBVERSION} ({FIELD_DBVERSION_DBVERSION}) VALUES ({DB_VERSION});"
        ExecuteQuery(sql)
    End Sub

    Private Function GetDbVersion() As Integer
        If Not TableExists(TABLE_DBVERSION) Then
            Return 0
        End If
        Dim sql As String = $"SELECT {FIELD_DBVERSION_DBVERSION} FROM {TABLE_DBVERSION};"
        Using dt As DataTable = GetDatatable(sql)
            For Each dr As DataRow In dt.Rows
                Return DbToInt(dr(0))
            Next
        End Using
        Return 0
    End Function

    Private Sub CreateTable(sTableName As String, sPrimaryKeyField As String, fieldType As EFieldType, iVarCharLength As Integer)
        Dim sVarCharLength As String = String.Empty
        If fieldType = EFieldType.NVarChar Then
            sVarCharLength = $" ({iVarCharLength})"
        End If
        Dim pk As String = $"Pk_{sTableName}"
        Dim sql As String = $"CREATE TABLE [{sTableName}] ([{sPrimaryKeyField}] {fieldType.Code}{sVarCharLength}, CONSTRAINT {pk} PRIMARY KEY ({sPrimaryKeyField}));"
        ExecuteQuery(sql)
    End Sub

    Private Function TableExists(sTableName As String) As Boolean
        Dim sql As String = $"Select 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = {SqlString(sTableName)}"
        Using dt = GetDatatable(sql)
            For Each dr As DataRow In dt.Rows
                Return True
            Next
        End Using
        Return False
    End Function

    Friend Function ExecuteQuery(sql As String) As Integer
        Dim sqlCommand As SqlCeCommand
        If TransactionIsActive() Then
            sqlCommand = New SqlCeCommand(sql, m_sqlConnection, m_sqlTransaction)
        Else
            sqlCommand = New SqlCeCommand(sql, m_sqlConnection)
        End If
        Dim iRet As Integer = sqlCommand.ExecuteNonQuery
        sqlCommand.Dispose()
        Return iRet
    End Function

    Friend Sub Cleardown()
        TransactionBegin()
        Try
            CleardownNow()
            TransactionCommit()
        Catch ex As Exception
            TransactionRollback()
            Throw
        End Try
    End Sub
    Friend Sub CleardownNow()
        TransactionEnsureActive()

        Dim sql As String = $"
                DELETE
                FROM {TABLE_TRANSACTIONS};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_INSTRUMENT};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_ACCOUNTS};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_CURRENCIES};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_SNAPSHOTS};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_NOTES};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_NETWORKS};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_LIQUIDATION};"
        ExecuteQuery(sql)

        sql = $"
                DELETE
                FROM {TABLE_ELECTRICITY};"
        ExecuteQuery(sql)
    End Sub


    Friend Function GetDatatable(sql As String) As DataTable
        Dim sqlCommand As SqlCeCommand = Nothing
        Try
            If TransactionIsActive() Then
                sqlCommand = New SqlCeCommand(sql, m_sqlConnection, m_sqlTransaction)
            Else
                sqlCommand = New SqlCeCommand(sql, m_sqlConnection)
            End If
            Dim dt As New DataTable
            Using da = New SqlCeDataAdapter(sqlCommand)
                da.Fill(dt)
            End Using
            Return dt
        Finally
            If sqlCommand IsNot Nothing Then
                sqlCommand.Dispose()
            End If
        End Try
    End Function
    Friend Function GetCommand(sql As String) As SqlCeCommand
        Dim cm As SqlCeCommand
        If TransactionIsActive() Then
            cm = New SqlCeCommand(sql, m_sqlConnection, m_sqlTransaction)
        Else
            cm = New SqlCeCommand(sql, m_sqlConnection)
        End If
        Return cm
    End Function

    Friend Shared Function GetConnectionString(sServerName As String, fIntegratedSecurity As Boolean, sUsername As String, sPassword As String) As String
        Dim sConnectionString As String = $"Data Source={sServerName}; "

        If fIntegratedSecurity Then
            sConnectionString &= $"Integrated Security=SSPI; "
        Else
            sConnectionString &= $"User ID={sUsername}; Password={sPassword}; "
        End If

        Return sConnectionString
    End Function

    Friend Sub TransactionBegin()
        TransactionEnsureInActive()
        m_sqlTransaction = m_sqlConnection.BeginTransaction
    End Sub
    Friend Sub TransactionCommit()
        TransactionEnsureActive()
        m_sqlTransaction.Commit()
        m_sqlTransaction = Nothing
    End Sub
    Friend Sub TransactionRollback()
        TransactionEnsureActive()
        m_sqlTransaction.Rollback()
        m_sqlTransaction = Nothing
    End Sub
    Friend Sub TransactionEnsureActive()
        If Not TransactionIsActive() Then
            Throw New DataException(ERROR_TRANSACTION_IS_NOT_ACTIVE)
        End If
    End Sub
    Private Sub TransactionEnsureInActive()
        If TransactionIsActive() Then
            Throw New DataException(ERROR_TRANSACTION_IS_ACTIVE)
        End If
    End Sub
    Private Function TransactionIsActive() As Boolean
        Return m_sqlTransaction IsNot Nothing
    End Function

    Friend Shared Function SqlString(sString As String) As String
        If String.IsNullOrEmpty(sString) Then
            Return "NULL"
        End If
        Return $"'{sString.Replace("'", "''")}'"
    End Function
    Friend Shared Function SqlDateTime(d As Date) As String
        Return $"'{d:yyyyMMdd hh:MM:ss}'"
    End Function
    Friend Shared Function SqlDate(d As Date) As String
        Return $"'{d:yyyyMMdd}'"
    End Function

    Friend Shared Function DbToString(o As Object) As String
        If o Is Nothing OrElse IsDBNull(o) Then
            Return String.Empty
        End If
        Return CType(o, String)
    End Function
    Friend Shared Function DbToSingle_(o As Object) As Single
        If o Is Nothing OrElse IsDBNull(o) Then
            Return 0
        End If
        Return CType(o, Single)
    End Function
    Friend Shared Function DbToDouble(o As Object) As Double
        If o Is Nothing OrElse IsDBNull(o) Then
            Return 0
        End If
        Return CType(o, Double)
    End Function
    Friend Shared Function DbToDecimal(o As Object) As Decimal
        If o Is Nothing OrElse IsDBNull(o) Then
            Return 0
        End If
        Return CDec(o)
    End Function
    Friend Shared Function DbToLong(o As Object) As Long
        If o Is Nothing OrElse IsDBNull(o) Then
            Return 0
        End If
        Return CLng(o)
    End Function
    Friend Shared Function DbToInt(o As Object) As Integer
        If o Is Nothing OrElse IsDBNull(o) Then
            Return 0
        End If
        Return CInt(o)
    End Function
    Friend Shared Function DbToBool(o As Object) As Boolean
        If o Is Nothing OrElse IsDBNull(o) Then
            Return False
        End If
        Return CInt(o) <> 0
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                If m_sqlTransaction IsNot Nothing Then
                    m_sqlTransaction.Dispose()
                End If
                If m_sqlConnection IsNot Nothing Then
                    m_sqlConnection.Dispose()
                End If
            End If
            disposedValue = True
        End If
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
