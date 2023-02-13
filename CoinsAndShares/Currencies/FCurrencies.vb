Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid

Namespace Currencies
    Friend Class FCurrencies : Implements IDataRefresh

        Private ReadOnly m_commonObjects As CCommonObjects
        Private Property UpdatingData As Boolean
        Friend Sub New(commonObjects As CCommonObjects)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            Icon = Icon.FromHandle(My.Resources.currency.GetHicon)
            BtnUpdate.Text = $"Get Rates From {GetCurrencyRateApiToUse(m_commonObjects).GetName}"
            LoadData()
        End Sub
        Friend Sub RefreshData() Implements IDataRefresh.RefreshData
            If Not UpdatingData Then
                LoadData()
            End If
        End Sub

        Private Sub LoadData()
            GridHelper.LoadData(GrdCurrencies, m_commonObjects, m_commonObjects.Currencies.GetAll(), Me)
        End Sub
        Private NotInheritable Class GridHelper
            Private NotInheritable Class LocalTagBits : Inherits TagBits
                Friend ReadOnly Property FrmCurrencies As FCurrencies
                Friend Sub New(commonObjects As CCommonObjects, frmCurrencies As FCurrencies)
                    MyBase.New(commonObjects)
                    Me.FrmCurrencies = frmCurrencies
                End Sub
            End Class
            Enum Columns
                ISO
                Name
                Rate
                Favourite
                Hint
            End Enum
            Friend Shared Sub LoadData(grid As UltraGrid, commonObjects As CCommonObjects, all As IEnumerable(Of CCurrencyDetail), frmCurrencies As FCurrencies)
                grid.Tag = New LocalTagBits(commonObjects, frmCurrencies)
                Dim dt = GetBlankDt()
                For Each c In all.OrderByDescending(Function(d) d.Favourite).ThenBy(Function(d) d.CurrencyCode)
                    Dim dr = dt.NewRow
                    dr(Columns.ISO.ToString) = c.CurrencyCode
                    dr(Columns.Name.ToString) = c.CurrencyName
                    If c.CurrencyRate.HasValue Then
                        dr(Columns.Rate.ToString) = c.CurrencyRate.Value
                    End If
                    dr(Columns.Favourite.ToString) = c.Favourite
                    dt.Rows.Add(dr)
                Next
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                RemoveHandler grid.KeyDown, AddressOf KeyDown
                AddHandler grid.KeyDown, AddressOf KeyDown
                grid.DataSource = dt
                RemoveHandler grid.BeforeCellUpdate, AddressOf BeforeCellUpdate
                AddHandler grid.BeforeCellUpdate, AddressOf BeforeCellUpdate
                RemoveHandler grid.LostFocus, AddressOf LostFocus
                AddHandler grid.LostFocus, AddressOf LostFocus
            End Sub

            Private Shared Sub LostFocus(sender As Object, e As EventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    grid.UpdateData()
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub KeyDown(sender As Object, e As KeyEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    HandleArrowKeys(sender, e)
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    If e.Cell.Column.Key.Equals(Columns.Rate.ToString, StringComparison.CurrentCultureIgnoreCase) Then
                        Dim currencies = tagBits.CommonObjects.Currencies
                        Dim all = currencies.GetAll
                        Dim sCurrencyCode As String = e.Cell.Row.Cells(Columns.ISO.ToString).Text
                        Dim currency = all.Where(Function(c) c.CurrencyCode.Equals(sCurrencyCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                        If currency Is Nothing Then
                            Throw New Exception(My.Resources.Error_ItemNotFound)
                        End If
                        If IsDBNull(e.NewValue) Then
                            currency.CurrencyRate = Nothing
                        Else
                            currency.CurrencyRate = CType(e.NewValue, Decimal)
                        End If
                        tagBits.FrmCurrencies.UpdatingData = True
                        currencies.SaveAll(all)
                    End If
                Catch ex As Exception
                    e.Cancel = True
                    tagBits.CommonObjects.Errors.Handle(ex)
                Finally
                    tagBits.FrmCurrencies.UpdatingData = False
                End Try
            End Sub
            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    Dim fFavourite As Boolean = CBool(e.Row.Cells(Columns.Favourite.ToString).Value)
                    If fFavourite Then
                        e.Row.CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                    End If

                    Dim currency As CCurrencyDetail = GetCurrencyFromRow(e.Row)

                    Dim sHint As String = String.Empty

                    Dim rateColumnActivation As Activation
                    If currency.CurrencyCode.Equals(GetLocalCurrencyIso, StringComparison.CurrentCultureIgnoreCase) Then
                        ' Home currency
                        sHint = "Local currency"
                        rateColumnActivation = Activation.ActivateOnly
                    Else
                        rateColumnActivation = Activation.AllowEdit
                        If currency.CurrencyRate.HasValue AndAlso currency.CurrencyRate.Value > 0 Then
                            Dim r As Decimal = 1 / currency.CurrencyRate.Value
                            sHint = $"1 {currency.CurrencyCode} = {r.ToString("0.00", CultureInfo.InvariantCulture)} {GetLocalCurrencyIso()}"
                        End If
                    End If

                    e.Row.Cells(Columns.Hint.ToString).Value = sHint
                    For Each col As UltraGridColumn In e.Row.Band.Columns
                        If col.Key.Equals(Columns.Rate.ToString, StringComparison.CurrentCultureIgnoreCase) Then
                            e.Row.Cells(col.Key).Activation = rateColumnActivation
                        Else
                            e.Row.Cells(col.Key).Activation = Activation.NoEdit
                        End If
                    Next

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Function GetCurrencyFromRow(row As UltraGridRow) As CCurrencyDetail
                Dim sCurrencyCode As String = row.Cells(Columns.ISO.ToString).Text
                Dim sCurrencyName As String = row.Cells(Columns.Name.ToString).Text
                Dim currencyRate As Decimal? = Nothing
                If Not IsDBNull(row.Cells(Columns.Rate.ToString).Value) Then
                    currencyRate = CType(row.Cells(Columns.Rate.ToString).Value, Decimal)
                End If
                Dim fFavourite As Boolean = CBool(row.Cells(Columns.Favourite.ToString).Value)
                Dim currency As New CCurrencyDetail(sCurrencyCode, sCurrencyName, currencyRate, fFavourite)
                Return currency
            End Function

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .AllowAddNew = AllowAddNew.No
                        .AllowUpdate = Infragistics.Win.DefaultableBoolean.True
                        .AllowDelete = Infragistics.Win.DefaultableBoolean.False
                        .RowSelectors = Infragistics.Win.DefaultableBoolean.False
                        .HeaderClickAction = HeaderClickAction.SortMulti
                    End With
                    e.Layout.AutoFitColumns = True
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.ISO.ToString
                                col.Header.Caption = "ISO"
                                col.Width = 10
                            Case Columns.Name.ToString
                                col.Header.Caption = "Name"
                                col.Width = 20
                            Case Columns.Rate.ToString
                                col.Header.Caption = "Rate"
                                col.Width = 10
                            Case Columns.Hint.ToString
                                col.Header.Caption = String.Empty
                                col.Width = 20
                            Case Else
                                col.Hidden = True
                        End Select
                    Next
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Function GetBlankDt() As DataTable
                Dim dt As New DataTable
                dt.Columns.Add(Columns.ISO.ToString)
                dt.Columns.Add(Columns.Name.ToString)
                dt.Columns.Add(Columns.Rate.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Favourite.ToString, GetType(Boolean))
                dt.Columns.Add(Columns.Hint.ToString)
                Return dt
            End Function
        End Class

        Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
            Try
                Cursor = Cursors.WaitCursor
                m_commonObjects.Currencies.UpdateRatesFromApi(GetCurrencyRateApiToUse(m_commonObjects))
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
