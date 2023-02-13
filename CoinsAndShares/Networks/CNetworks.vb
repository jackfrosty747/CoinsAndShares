Imports CoinsAndShares.Accounts

Namespace Networks
    Friend Class CNetworks
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_all As IEnumerable(Of CNetwork)
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Function GetAll() As IEnumerable(Of CNetwork)
            If m_all Is Nothing Then
                Dim sql = $"
                    SELECT *
                    FROM {CDatabase.TABLE_NETWORKS}
                    ORDER BY {CDatabase.FIELD_NETWORKS_NETWORKID};"
                Dim all = New List(Of CNetwork)
                Using dt = m_commonObjects.Database.GetDatatable(sql)
                    For Each dr As DataRow In dt.Rows
                        Dim sNetworkId = CDatabase.DbToString(dr(CDatabase.FIELD_NETWORKS_NETWORKID))
                        Dim sDescription = CDatabase.DbToString(dr(CDatabase.FIELD_NETWORKS_DESCRIPTION))
                        Dim colour As Color? = Nothing
                        If Not IsDBNull(dr(CDatabase.FIELD_NETWORKS_COLOUR)) Then
                            Dim iColour = CDatabase.DbToInt(dr(CDatabase.FIELD_NETWORKS_COLOUR))
                            Try
                                Dim c = Color.FromArgb(iColour)
                                colour = c
                            Catch ignored As Exception
                            End Try
                        End If
                        Dim network = New CNetwork(sNetworkId, sDescription, colour)
                        all.Add(network)
                    Next
                End Using
                m_all = all
            End If
            Return m_all
        End Function
        Friend Sub SaveAll(all As IEnumerable(Of CNetwork))
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

        Friend Sub SaveAllNow(all As IEnumerable(Of CNetwork))
            m_commonObjects.Database.TransactionEnsureActive()

            Dim sql = $"
                DELETE
                FROM {CDatabase.TABLE_NETWORKS};"
            m_commonObjects.Database.ExecuteQuery(sql)

            sql = $"
                SELECT *
                FROM {CDatabase.TABLE_NETWORKS}
                ORDER BY {CDatabase.FIELD_NETWORKS_NETWORKID};"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da = New SqlServerCe.SqlCeDataAdapter(cm)
                    Using dt = New DataTable
                        da.Fill(dt)
                        For Each network In all
                            Dim dr = dt.NewRow
                            dr(CDatabase.FIELD_NETWORKS_NETWORKID) = network.NetworkId.ToUpper
                            dr(CDatabase.FIELD_NETWORKS_DESCRIPTION) = network.Description
                            If network.Colour.HasValue Then
                                dr(CDatabase.FIELD_NETWORKS_COLOUR) = network.Colour.Value.ToArgb
                            End If
                            dt.Rows.Add(dr)
                        Next
                        Using cb = New SqlServerCe.SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Friend Function GetColour(account As CAccount) As Color
            Dim colour = Color.White
            If account IsNot Nothing AndAlso Not String.IsNullOrEmpty(account.NetworkId) Then
                Dim all = GetAll()
                Dim network = all.FirstOrDefault(Function(c) c.NetworkId.Equals(account.NetworkId, StringComparison.InvariantCultureIgnoreCase))
                If network IsNot Nothing AndAlso network.Colour.HasValue Then
                    colour = network.Colour.Value
                End If
            End If
            Return colour
        End Function
    End Class

End Namespace
