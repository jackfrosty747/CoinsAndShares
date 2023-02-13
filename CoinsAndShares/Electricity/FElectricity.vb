Imports Infragistics.Win.UltraWinGrid

Namespace Electricity
    Friend Class FElectricity
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            Icon = Icon.FromHandle(My.Resources.control_power.GetHicon)

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            LoadData()
        End Sub
        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    m_commonObjects.FrmMdi.Cursor = Cursors.WaitCursor
                    SaveData()
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                m_commonObjects.FrmMdi.Cursor = Cursors.Default
            End Try
        End Sub
        Private Sub LoadData()
            Dim all = m_commonObjects.Electricity.GetAll
            GridHelper.LoadData(GrdElectricityItems, all, m_commonObjects)
        End Sub
        Private Sub SaveData()
            Dim electricity = m_commonObjects.Electricity
            Dim all = GridHelper.GetAll(GrdElectricityItems)
            electricity.SaveAll(all)
        End Sub
        Private NotInheritable Class GridHelper
            Private Enum Columns
                DateFrom
                DailyRate
            End Enum
            Friend Shared Sub LoadData(grid As UltraGrid, all As IEnumerable(Of CElectricityItem), commonObjects As CCommonObjects)
                grid.Tag = New TagBits(commonObjects)
                Dim dt = GetBlankDt()
                For Each i In all
                    Dim dr = dt.NewRow
                    dr(Columns.DateFrom.ToString) = i.DateFrom
                    dr(Columns.DailyRate.ToString) = i.DailyRate
                    dt.Rows.Add(dr)
                Next
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                grid.DataSource = dt
            End Sub
            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    With e.Layout.Override
                        .AllowAddNew = AllowAddNew.TemplateOnBottom
                    End With
                    e.Layout.AutoFitColumns = True
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.DateFrom.ToString
                                col.Header.Caption = "Date From"
                                col.Width = 50
                            Case Columns.DailyRate.ToString
                                col.Header.Caption = "Est Daily Cost"
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Format = "c2"
                                col.Width = 50
                            Case Else
                                col.Hidden = True
                        End Select
                    Next
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Friend Shared Function GetAll(grid As UltraGrid) As IEnumerable(Of CElectricityItem)
                grid.UpdateData()
                Dim all = New List(Of CElectricityItem)
                For Each row As UltraGridRow In grid.Rows
                    Dim dateFrom = CType(row.Cells(Columns.DateFrom.ToString).Value, Date)
                    Dim dailyRate = CDatabase.DbToDecimal(row.Cells(Columns.DailyRate.ToString).Value)
                    Dim item = New CElectricityItem(dateFrom, dailyRate)
                    all.Add(item)
                Next
                Return all
            End Function
            Private Shared Function GetBlankDt() As DataTable
                Dim dt = New DataTable
                dt.Columns.Add(Columns.DateFrom.ToString, GetType(Date))
                dt.Columns.Add(Columns.DailyRate.ToString, GetType(Decimal))
                dt.PrimaryKey = New DataColumn() {dt.Columns(Columns.DateFrom.ToString)}
                Return dt
            End Function
        End Class
    End Class
End Namespace
