Imports System.Data.SqlServerCe

Namespace Snapshots
    Friend Class CSnapshots
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Function GetAll() As IEnumerable(Of CSnapshot)
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_SNAPSHOTS}
                ORDER BY {CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE};"
            Dim col As New List(Of CSnapshot)
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    If IsDBNull(dr(CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE)) Then
                        ' Ignore
                    Else
                        Dim snapshotDate = CDate(dr(CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE)).Date
                        Dim coins = Math.Round(CDatabase.DbToDecimal(dr(CDatabase.FIELD_SNAPSHOTS_COINSVALUE)), 2)
                        Dim shares = Math.Round(CDatabase.DbToDecimal(dr(CDatabase.FIELD_SNAPSHOTS_SHARESVALUE)), 2)
                        Dim snapshot As New CSnapshot(snapshotDate, coins, shares)
                        col.Add(snapshot)
                    End If
                Next
            End Using
            Return col
        End Function

        Friend Sub SaveAll(all As IEnumerable(Of CSnapshot))
            m_commonObjects.Database.TransactionBegin()
            Try
                SaveAllNow(all)
                m_commonObjects.Database.TransactionCommit()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub SaveAllNow(all As IEnumerable(Of CSnapshot))
            m_commonObjects.Database.ExecuteQuery($"DELETE FROM {CDatabase.TABLE_SNAPSHOTS};")

            Dim sql = $"SELECT * FROM {CDatabase.TABLE_SNAPSHOTS};"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da = New SqlCeDataAdapter(cm)
                    Using dt = New DataTable
                        da.Fill(dt)
                        For Each snapshot In all
                            Dim dr = dt.NewRow
                            dr(CDatabase.FIELD_SNAPSHOTS_SNAPSHOTDATE) = snapshot.SnapshotDate.Date
                            dr(CDatabase.FIELD_SNAPSHOTS_COINSVALUE) = snapshot.Coins
                            dr(CDatabase.FIELD_SNAPSHOTS_SHARESVALUE) = snapshot.Shares
                            dt.Rows.Add(dr)
                        Next
                        Using cb As New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub
    End Class
End Namespace
