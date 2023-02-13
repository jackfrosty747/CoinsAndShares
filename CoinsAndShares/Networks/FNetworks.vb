Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Networks
    Friend Class FNetworks
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)
            ' This call is required by the designer.
            InitializeComponent()
            m_commonObjects = commonObjects
            ' Add any initialization after the InitializeComponent() call.
            Icon = Icon.FromHandle(My.Resources.paint_can.GetHicon)
            LoadData()
        End Sub
        Private Sub LoadData()
            Dim all = m_commonObjects.Networks.GetAll()
            GridHelper.LoadData(GrdNetworks, all, m_commonObjects)
        End Sub
        Private Sub SaveData()
            Dim all = GridHelper.GetAll(GrdNetworks)

            m_commonObjects.Networks.SaveAll(all)
        End Sub
        Private NotInheritable Class GridHelper
            Private Enum Columns
                NetworkId
                Description
                Colour
                SetColourButton
                ClearColourButton
            End Enum
            Friend Shared Sub LoadData(grid As UltraGrid, all As IEnumerable(Of CNetwork), commonObjects As CCommonObjects)
                grid.Tag = New TagBits(commonObjects)
                Dim dt = GetBlankDt()
                For Each network In all
                    Dim dr = dt.NewRow
                    dr(Columns.NetworkId.ToString) = network.NetworkId
                    dr(Columns.Description.ToString) = network.Description
                    If network.Colour.HasValue Then
                        dr(Columns.Colour.ToString) = network.Colour.Value.ToArgb
                    End If
                    dt.Rows.Add(dr)
                Next
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                RemoveHandler grid.ClickCellButton, AddressOf ClickCellButton
                AddHandler grid.ClickCellButton, AddressOf ClickCellButton
                RemoveHandler grid.KeyDown, AddressOf KeyDown
                AddHandler grid.KeyDown, AddressOf KeyDown
                grid.DataSource = dt
            End Sub

            Private Shared Sub KeyDown(sender As Object, e As KeyEventArgs)
                Dim grid = CType(sender, UltraGrid)
                Dim tagBits = CType(grid.Tag, TagBits)
                Try
                    HandleArrowKeys(sender, e)
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub ClickCellButton(sender As Object, e As CellEventArgs)
                Dim grid = CType(sender, UltraGrid)
                Dim tagBits = CType(grid.Tag, TagBits)
                Try
                    If e.Cell.Row.IsAddRow Then
                        Return
                    End If
                    Select Case e.Cell.Column.Key
                        Case Columns.ClearColourButton.ToString
                            e.Cell.Row.Cells(Columns.Colour.ToString).Value = DBNull.Value
                        Case Columns.SetColourButton.ToString
                            Using cd As New ColorDialog
                                If cd.ShowDialog = DialogResult.OK Then
                                    e.Cell.Row.Cells(Columns.Colour.ToString).Value = cd.Color.ToArgb
                                End If
                            End Using
                    End Select
                    grid.UpdateData()
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid = CType(sender, UltraGrid)
                Dim tagBits = CType(grid.Tag, TagBits)
                Try
                    Dim backColour As Color = Nothing
                    If Not IsDBNull(e.Row.Cells(Columns.Colour.ToString).Value) Then
                        Dim iColour = CInt(e.Row.Cells(Columns.Colour.ToString).Value)
                        Try
                            Dim c As Color = Color.FromArgb(iColour)
                            backColour = c
                        Catch ex As Exception
                        End Try
                    End If
                    e.Row.CellAppearance.BackColor = backColour
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid = CType(sender, UltraGrid)
                Dim tagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .AllowAddNew = AllowAddNew.TemplateOnBottom
                        .AllowDelete = DefaultableBoolean.True
                    End With
                    e.Layout.AutoFitColumns = True
                    e.Layout.Bands(0).ColHeaderLines = 2
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.NetworkId.ToString
                                col.Header.Caption = $"Network{vbNewLine}ID"
                                col.Width = 100
                                col.Case = [Case].Upper
                            Case Columns.Description.ToString
                                col.Header.Caption = $"Network{vbNewLine}Description"
                                col.Width = 200
                            Case Columns.SetColourButton.ToString
                                col.Header.Caption = $"Set{vbNewLine}Colour"
                                col.Width = 50
                                col.Style = ColumnStyle.Button
                                col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                            Case Columns.ClearColourButton.ToString
                                col.Header.Caption = $"Clear{vbNewLine}Colour"
                                col.Width = 50
                                col.Style = ColumnStyle.Button
                                col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                            Case Else
                                col.Hidden = True
                        End Select
                    Next
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Function GetBlankDt() As DataTable
                Dim dt = New DataTable
                dt.Columns.Add(Columns.NetworkId.ToString)
                dt.Columns.Add(Columns.Description.ToString)
                dt.Columns.Add(Columns.Colour.ToString, GetType(Integer))
                dt.Columns.Add(Columns.SetColourButton.ToString)
                dt.Columns.Add(Columns.ClearColourButton.ToString)
                dt.PrimaryKey = New DataColumn() {dt.Columns(Columns.NetworkId.ToString)}
                Return dt
            End Function

            Friend Shared Function GetAll(grid As UltraGrid) As IEnumerable(Of CNetwork)
                grid.UpdateData()
                Dim all As New List(Of CNetwork)
                For Each row As UltraGridRow In grid.Rows
                    Dim network = GetNetworkFromRow(row)
                    all.Add(network)
                Next
                Return all
            End Function

            Private Shared Function GetNetworkFromRow(row As UltraGridRow) As CNetwork
                Dim sNetworkId = row.Cells(Columns.NetworkId.ToString).Text
                Dim sDescription = row.Cells(Columns.Description.ToString).Text
                Dim colour As Color? = Nothing
                If Not IsDBNull(row.Cells(Columns.Colour.ToString).Value) Then
                    Try
                        Dim iColour = CDatabase.DbToInt(row.Cells(Columns.Colour.ToString).Value)
                        Dim c = Color.FromArgb(iColour)
                        colour = c
                    Catch ex As Exception
                    End Try
                End If
                Dim network = New CNetwork(sNetworkId, sDescription, colour)
                Return network
            End Function
        End Class
        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Cursor = Cursors.WaitCursor
                    SaveData
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

    End Class
End Namespace
