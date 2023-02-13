Namespace Notes
    Friend Class CNotes
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_all As IEnumerable(Of CNote)
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Function GetAll() As IEnumerable(Of CNote)
            If m_all Is Nothing Then
                m_all = GetAllNow()
            End If
            Return m_all
        End Function
        Private Function GetAllNow() As IEnumerable(Of CNote)
            Dim sql = $"
                SELECT *
                FROM {CDatabase.TABLE_NOTES}
                ORDER BY {CDatabase.FIELD_NOTES_NOTEID};"
            Dim all = New List(Of CNote)
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim iId = CDatabase.DbToInt(dr(CDatabase.FIELD_NOTES_NOTEID))
                    Dim sNoteTitle = CDatabase.DbToString(dr(CDatabase.FIELD_NOTES_NOTETITLE))
                    Dim sNoteBody = CDatabase.DbToString(dr(CDatabase.FIELD_NOTES_NOTEBODY))
                    Dim note = New CNote(iId, sNoteTitle, sNoteBody)
                    all.Add(note)
                Next
            End Using
            Return all
        End Function
        Friend Sub SaveAll(all As IEnumerable(Of CNote))
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

        Friend Sub SaveAllNow(all As IEnumerable(Of CNote))
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql = $"
                DELETE
                FROM {CDatabase.TABLE_NOTES};"
            m_commonObjects.Database.ExecuteQuery(sql)
            sql = $"
                SELECT *
                FROM {CDatabase.TABLE_NOTES};"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da = New SqlServerCe.SqlCeDataAdapter(cm)
                    Using dt = New DataTable
                        da.Fill(dt)
                        For Each note In all
                            Dim dr = dt.NewRow()
                            dr(CDatabase.FIELD_NOTES_NOTEID) = note.Id
                            dr(CDatabase.FIELD_NOTES_NOTETITLE) = note.NoteTitle
                            dr(CDatabase.FIELD_NOTES_NOTEBODY) = note.NoteBody
                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlServerCe.SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub
    End Class

End Namespace
