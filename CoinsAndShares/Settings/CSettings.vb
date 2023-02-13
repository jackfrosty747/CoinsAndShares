Imports System.Data.SqlServerCe

Namespace Settings
    Friend Class CSettings
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Property AlphavantageKey As String
        Friend Property RateUpdateWarningHours As Integer?
        Friend Property ExchangeRatesApiKey As String
        Friend Property DefaultBackupPath As String
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
            LoadSettings()
        End Sub
        Private Sub LoadSettings()
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_SETTINGS}
                WHERE {CDatabase.FIELD_SETTINGS_ID} = 1;"
            Dim sAlphavantageKey = String.Empty
            Dim sExchangeRatesApiKey = String.Empty
            Dim sDefaultBackupPath = String.Empty
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    sAlphavantageKey = CDatabase.DbToString(dr(CDatabase.FIELD_SETTINGS_ALPHAVANTAGEKEY))
                    If IsDBNull(dr(CDatabase.FIELD_SETTINGS_RATEUPDATEWARNINGHOURS)) Then
                        RateUpdateWarningHours = Nothing
                    Else
                        RateUpdateWarningHours = CDatabase.DbToInt(dr(CDatabase.FIELD_SETTINGS_RATEUPDATEWARNINGHOURS))
                    End If
                    sExchangeRatesApiKey = CDatabase.DbToString(dr(CDatabase.FIELD_SETTINGS_EXCHANGERATESAPIKEY))
                    sDefaultBackupPath = CDatabase.DbToString(dr(CDatabase.FIELD_SETTINGS_DEFAULTBACKUPPATH))
                Next
            End Using
            AlphavantageKey = sAlphavantageKey
            ExchangeRatesApiKey = sExchangeRatesApiKey
            DefaultBackupPath = sDefaultBackupPath
        End Sub
        Friend Sub SaveSettings(sAlphavantageKey As String, rateUpdateWarningHours As Integer?, sExchangeRatesApiKey As String, sDefaultBackupPath As String)
            m_commonObjects.Database.TransactionBegin()
            Try
                SaveSettingsNow(sAlphavantageKey, rateUpdateWarningHours, sExchangeRatesApiKey, sDefaultBackupPath)
                LoadSettings()
                m_commonObjects.Database.TransactionCommit()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub

        Friend Sub SaveSettingsNow(sAlphavantageKey As String, rateUpdateWarningHours As Integer?, sExchangeRatesApiKey As String, sDefaultBackupPath As String)
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_SETTINGS}
                WHERE {CDatabase.FIELD_SETTINGS_ID} = 1;"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da As New SqlCeDataAdapter(cm)
                    Using dt = New DataTable
                        da.Fill(dt)
                        Dim dr As DataRow
                        If dt.Rows.Count = 0 Then
                            dr = dt.NewRow
                            dr(CDatabase.FIELD_SETTINGS_ID) = 1
                            dt.Rows.Add(dr)
                        Else
                            dr = dt.Rows(0)
                        End If
                        dr(CDatabase.FIELD_SETTINGS_ALPHAVANTAGEKEY) = sAlphavantageKey
                        If rateUpdateWarningHours.HasValue Then
                            dr(CDatabase.FIELD_SETTINGS_RATEUPDATEWARNINGHOURS) = rateUpdateWarningHours.Value
                        Else
                            dr(CDatabase.FIELD_SETTINGS_RATEUPDATEWARNINGHOURS) = DBNull.Value
                        End If
                        dr(CDatabase.FIELD_SETTINGS_EXCHANGERATESAPIKEY) = sExchangeRatesApiKey
                        dr(CDatabase.FIELD_SETTINGS_DEFAULTBACKUPPATH) = sDefaultBackupPath
                        Using cb = New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub
    End Class
End Namespace
