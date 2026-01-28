Imports CoinsAndShares.Rates
Imports Infragistics.Win.UltraWinGrid

Namespace Instruments
    Friend Class FSelectProviderLinkCode
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_rateProvider As IRateProvider

        Private m_fOkPressed As Boolean
        Private m_sProviderLinkCode As String

        Friend Sub New(commonObjects As CCommonObjects, rateProvider As IRateProvider, defaultSearchTerm As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_rateProvider = rateProvider

            Icon = Icon.FromHandle(My.Resources.chain.GetHicon)

            TxtFilter.Text = defaultSearchTerm

        End Sub

        Friend ReadOnly Property OkPressed As Boolean
            Get
                Return m_fOkPressed
            End Get
        End Property
        Friend ReadOnly Property ProviderLinkCode As String
            Get
                Return m_sProviderLinkCode
            End Get
        End Property
        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Dim selectedCoins = GridHelper.GetSelectedCoins(GrdCoins)
                    If selectedCoins.Count <> 1 Then
                        Throw New Exception(My.Resources.Error_SelectOneItemOnly)
                    End If
                    m_sProviderLinkCode = selectedCoins.First.Id
                    m_fOkPressed = True
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private NotInheritable Class GridHelper
            Private NotInheritable Class LocalTagBits : Inherits TagBits
                Friend ReadOnly FrmSelectLinkSymbol As FSelectProviderLinkCode
                Friend Sub New(commonObjects As CCommonObjects, frmSelectLinkSymbol As FSelectProviderLinkCode)
                    MyBase.New(commonObjects)
                    Me.FrmSelectLinkSymbol = frmSelectLinkSymbol
                End Sub
            End Class
            Private Enum Columns
                Id
                Symbol
                Name
                CurrencyCode
                Region
            End Enum
            Friend Shared Sub LoadData(grid As UltraGrid, coins As IEnumerable(Of CRateType), commonObjects As CCommonObjects,
                                       frmSelectLinkSymbol As FSelectProviderLinkCode)
                grid.Tag = New LocalTagBits(commonObjects, frmSelectLinkSymbol)
                Dim dt As DataTable = GetBlankDt()
                For Each coin In coins
                    Dim dr = dt.NewRow
                    dr(Columns.Id.ToString) = coin.Id
                    dr(Columns.Symbol.ToString) = coin.Symbol
                    dr(Columns.Name.ToString) = coin.Name
                    dr(Columns.CurrencyCode.ToString) = coin.CurrencyCode
                    dr(Columns.Region.ToString) = coin.Region
                    dt.Rows.Add(dr)
                Next
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                RemoveHandler grid.DoubleClick, AddressOf DoubleClick
                AddHandler grid.DoubleClick, AddressOf DoubleClick
                grid.DataSource = dt
            End Sub

            Private Shared Sub DoubleClick(sender As Object, e As EventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    If WasGridRowClicked(sender) Then
                        tagBits.FrmSelectLinkSymbol.BtnOk_Click(tagBits.FrmSelectLinkSymbol.BtnOk, e)
                    End If
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                If e.ReInitialize Then Return
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try


                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .AllowDelete = Infragistics.Win.DefaultableBoolean.False
                        .AllowUpdate = Infragistics.Win.DefaultableBoolean.False
                        .SelectTypeRow = SelectType.Single
                        .CellClickAction = CellClickAction.RowSelect
                        .HeaderClickAction = HeaderClickAction.SortSingle
                        .SelectTypeCol = SelectType.None
                        .SelectTypeCell = SelectType.None
                    End With
                    e.Layout.AutoFitColumns = True
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.Id.ToString
                                col.Header.Caption = "ID"
                                col.Width = 100
                            Case Columns.Symbol.ToString
                                col.Header.Caption = "Symbol"
                                col.Width = 100
                            Case Columns.Name.ToString
                                col.Header.Caption = "Name"
                                col.Width = 210
                            Case Columns.CurrencyCode.ToString
                                col.Header.Caption = "Cur"
                                col.Width = 80
                            Case Columns.Region.ToString
                                col.Header.Caption = "Region"
                                col.Width = 120
                            Case Else
                                col.Hidden = True
                        End Select
                    Next
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Friend Shared Function GetSelectedCoins(grid As UltraGrid) As IEnumerable(Of CRateType)
                Dim coins As New List(Of CRateType)
                For Each row In grid.Selected.Rows
                    coins.Add(GetCoinFromRow(row))
                Next
                Return coins
            End Function
            Private Shared Function GetCoinFromRow(row As UltraGridRow) As CRateType
                Dim sId As String = row.Cells(Columns.Id.ToString).Text
                Dim sSymbol As String = row.Cells(Columns.Symbol.ToString).Text
                Dim sName As String = row.Cells(Columns.Name.ToString).Text
                Dim sCurrencyCode As String = row.Cells(Columns.CurrencyCode.ToString).Text
                Dim sRegion As String = row.Cells(Columns.Region.ToString).Text
                Dim rateType As New CRateType(sId, sSymbol, sName, sCurrencyCode, sRegion)
                Return rateType
            End Function
            Private Shared Function GetBlankDt() As DataTable
                Dim dt As New DataTable
                dt.Columns.Add(Columns.Id.ToString)
                dt.Columns.Add(Columns.Symbol.ToString)
                dt.Columns.Add(Columns.Name.ToString)
                dt.Columns.Add(Columns.CurrencyCode.ToString)
                dt.Columns.Add(Columns.Region.ToString)
                Return dt
            End Function
        End Class

        Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilter.KeyPress
            Try
                If e.KeyChar = Chr(13) Then
                    Cursor = Cursors.WaitCursor
                    SearchNow
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
        Private Sub SearchNow()
            Dim results = m_rateProvider.RateTypeSearch(TxtFilter.Text)
            If results Is Nothing Then
                MessageBox.Show("No results", Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
            Else
                GridHelper.LoadData(GrdCoins, results, m_commonObjects, Me)
            End If
        End Sub

        Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
            Try
                Cursor = Cursors.WaitCursor
                SearchNow()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace