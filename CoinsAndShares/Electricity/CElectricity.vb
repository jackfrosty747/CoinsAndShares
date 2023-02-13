Imports System.Data.SqlServerCe

Namespace Electricity
    Friend Class CElectricity
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_all As IEnumerable(Of CElectricityItem)
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Function GetAll() As IEnumerable(Of CElectricityItem)
            If m_all Is Nothing Then
                m_all = GetAllNow()
            End If
            Return m_all
        End Function
        Private Function GetAllNow() As IEnumerable(Of CElectricityItem)
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_ELECTRICITY}
                ORDER BY {CDatabase.FIELD_ELECTRICITY_DATEFROM};"
            Dim all = New List(Of CElectricityItem)
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim dateFrom = CDate(dr(CDatabase.FIELD_ELECTRICITY_DATEFROM))
                    Dim dailyRate = CDatabase.DbToDecimal(dr(CDatabase.FIELD_ELECTRICITY_DAILYRATE))
                    Dim electricityItem = New CElectricityItem(dateFrom, dailyRate)
                    all.Add(electricityItem)
                Next
            End Using
            Return all
        End Function
        Friend Sub SaveAll(all As IEnumerable(Of CElectricityItem))
            m_commonObjects.Database.TransactionBegin()
            Try
                SaveAllNow(all)
                m_commonObjects.Database.TransactionCommit()
                DataChanged
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub

        Private Sub DataChanged()
            m_all = Nothing
            m_commonObjects.ClearCache()
            m_commonObjects.RefreshForms()
        End Sub

        Friend Sub SaveAllNow(all As IEnumerable(Of CElectricityItem))
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql = $"
                DELETE
                FROM {CDatabase.TABLE_ELECTRICITY};"
            m_commonObjects.Database.ExecuteQuery(sql)
            sql = $"
                SELECT *
                FROM {CDatabase.TABLE_ELECTRICITY};"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt = New DataTable
                        da.Fill(dt)
                        For Each i In all
                            Dim dr = dt.NewRow()
                            dr(CDatabase.FIELD_ELECTRICITY_DATEFROM) = i.DateFrom.Date
                            dr(CDatabase.FIELD_ELECTRICITY_DAILYRATE) = i.DailyRate
                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub
    End Class

End Namespace
