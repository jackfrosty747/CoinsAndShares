Imports CoinsAndShares.Accounts.MAccounts
Imports Infragistics.Win.UltraWinGrid

Namespace Test
    Friend Class FAccounts
        Private ReadOnly m_commonObjects As CCommonObjects
        Public Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            LoadData()

        End Sub
        Private Sub LoadData()

            Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)

            Dim accounts = cs.AllAccounts

            GridHelper.LoadData(GrdAccounts, cs.AllAccounts, m_commonObjects)

        End Sub

        Private Class GridHelper
            Private Enum Columns
                AccountCode
                AccountName
                AccountTypeCode
                NetworkId
                AccountValue
                FreeCashBalance
                Profit
            End Enum
            Private Enum ColumnsGroup
                IsGroupBand
                AccountTypeCode
                AccountTypeDesc
            End Enum

            Friend Shared Sub LoadData(grid As UltraGrid, allAccounts As IEnumerable(Of CAccount), commonObjects As CCommonObjects)

                grid.Tag = New TagBits(commonObjects)

                Dim dtGroups = New DataTable
                dtGroups.Columns.Add(ColumnsGroup.IsGroupBand.ToString)
                dtGroups.Columns.Add(ColumnsGroup.AccountTypeCode.ToString)
                dtGroups.Columns.Add(ColumnsGroup.AccountTypeDesc.ToString)
                For Each accountType As EAccountType In [Enum].GetValues(GetType(EAccountType))
                    Dim dr = dtGroups.NewRow()
                    dr(ColumnsGroup.AccountTypeCode.ToString) = accountType.Code
                    dr(ColumnsGroup.AccountTypeDesc) = accountType.ToString.Replace("_", " ")
                    dtGroups.Rows.Add(dr)
                Next

                Dim dtAccounts = New DataTable
                dtAccounts.Columns.Add(Columns.AccountCode.ToString)
                dtAccounts.Columns.Add(Columns.AccountName.ToString)
                dtAccounts.Columns.Add(Columns.AccountTypeCode.ToString)
                dtAccounts.Columns.Add(Columns.NetworkId.ToString)
                dtAccounts.Columns.Add(Columns.AccountValue.ToString, GetType(Decimal))
                dtAccounts.Columns.Add(Columns.FreeCashBalance.ToString, GetType(Decimal))
                dtAccounts.Columns.Add(Columns.Profit.ToString, GetType(Decimal))
                For Each account In allAccounts
                    Dim dr = dtAccounts.NewRow
                    dr(Columns.AccountCode.ToString) = account.AccountCode
                    dr(Columns.AccountName.ToString) = account.AccountName
                    dr(Columns.AccountTypeCode.ToString) = account.AccountType.Code
                    dr(Columns.NetworkId.ToString) = account.NetworkId
                    dr(Columns.AccountValue.ToString) = 999
                    dr(Columns.FreeCashBalance.ToString) = account.GetCashBalance
                    dr(Columns.Profit.ToString) = account.GetPl
                    dtAccounts.Rows.Add(dr)
                Next

                Dim ds As New DataSet

                ds.Tables.Add(dtGroups)
                ds.Tables.Add(dtAccounts)
                ds.Relations.Add(String.Empty, dtGroups.Columns(ColumnsGroup.AccountTypeCode.ToString), dtAccounts.Columns(Columns.AccountTypeCode.ToString))

                grid.DataSource = ds
                For Each row As UltraGridRow In grid.Rows
                    row.ExpandAll()
                Next
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout

            End Sub

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)

                Dim grid = CType(sender, UltraGrid)
                Dim tagBits = CType(grid.Tag, TagBits)

                Try
                    GridDefaults(e.Layout)

                    With e.Layout.Override
                        .AllowUpdate = Infragistics.Win.DefaultableBoolean.False
                        .RowSelectors = Infragistics.Win.DefaultableBoolean.False
                    End With

                    'For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    '    Select Case col.Key
                    '        Case NameOf(GridRow.AccountCode)
                    '            col.Header.Caption = "Account Code"
                    '            col.Width = 100
                    '        Case NameOf(GridRow.AccountName)
                    '            col.Header.Caption = "Name"
                    '            col.Width = 250
                    '        Case NameOf(GridRow.AccountTypeDisplay)
                    '            col.Header.Caption = "Type"
                    '            col.Width = 100
                    '        Case NameOf(GridRow.FreeCashBalance)
                    '            col.Header.Caption = "Free Cash"
                    '            col.Width = 100
                    '            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    '            col.Format = "c2"
                    '        Case NameOf(GridRow.Profit)
                    '            col.Header.Caption = "P/L"
                    '            col.Width = 100
                    '            col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    '            col.Format = "c2"
                    '        Case Else
                    '            col.Hidden = True
                    '    End Select
                    'Next

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try

            End Sub
        End Class

        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Cursor = Cursors.WaitCursor
            Try
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
