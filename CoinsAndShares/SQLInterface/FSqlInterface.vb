Namespace SQLInterface
    Friend Class FSqlInterface
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            InitializeComponent()

            Icon = Icon.FromHandle(My.Resources.database.GetHicon)

            m_commonObjects = commonObjects

            LoadTablenames()

            SplitTop.SplitterDistance = CInt(SplitTop.Width * 0.25)
            SplitWholeScreen.SplitterDistance = CInt(SplitWholeScreen.Height * 0.333)

        End Sub

        Private Sub LoadTablenames()
            Dim sql = $"
                SELECT table_name
                FROM information_schema.tables
                WHERE TABLE_TYPE <> 'VIEW';"

            Dim sOut As String = String.Empty
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim sTableName = CDatabase.DbToString(dr(0))
                    If Not String.IsNullOrEmpty(sOut) Then
                        sOut &= vbNewLine
                    End If
                    sOut &= sTableName
                Next
            End Using
            TxtTables.Text = sOut
        End Sub

        Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles BtnGo.Click
            Try
                If TxtSql.Text.ToUpper.Contains("UPDATE".ToUpper) Or TxtSql.Text.ToUpper.Contains("DELETE".ToUpper) Or
                    TxtSql.Text.ToUpper.Contains("INTO".ToUpper) Then

                    m_commonObjects.Database.ExecuteQuery(TxtSql.Text)
                    'Throw New InvalidOperationException("Cannot update database")
                End If

                If TxtSql.Text.ToUpper.Contains("SELECT".ToUpper) Then
                    GrdSql.DataSource = m_commonObjects.Database.GetDatatable(TxtSql.Text)
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub GrdSql_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdSql.InitializeLayout
            Try
                GridDefaults(e.Layout)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try

        End Sub
    End Class
End Namespace



