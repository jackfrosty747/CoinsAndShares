Imports System.Globalization
Imports CoinsAndShares.Transactions
Imports Infragistics.Win.UltraWinGrid

Namespace Snapshots
    Friend Class FSnapshots : Implements IDataChangedHandler

        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_snapshots As CSnapshots

        Friend Sub New(commonObjects As CCommonObjects)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_snapshots = New CSnapshots(commonObjects)
            Icon = Icon.FromHandle(My.Resources.camera.GetHicon)
            GridHelper.LoadData(GrdSnapshots, m_snapshots.GetAll, commonObjects, Me)
            GridHelper.ScrollLast(GrdSnapshots)
            ChangesMade(False)
        End Sub

        Private Sub ChangesMade(f As Boolean)
            If f Then
                BtnOk.BackColor = Color.Red
                BtnOk.ForeColor = Color.Yellow
            Else
                BtnOk.BackColor = SystemColors.ButtonFace
                BtnOk.ForeColor = SystemColors.ControlText
            End If
        End Sub

        Friend NotInheritable Class GridHelper
            Private Enum Columns
                SnapshotDate
                DateBar
                Coins
                DifferenceCoins
                DifferenceCoinsPc
                CoinsBar
                Shares
                DifferenceShares
                DifferenceSharesPc
                SharesBar
                Total
                DifferenceTotal
                DifferenceTotalPc
            End Enum
            Friend NotInheritable Class LocalTagBits : Inherits TagBits
                Friend ReadOnly Property HostForm As IDataChangedHandler
                Friend Sub New(commonObjects As CCommonObjects, hostForm As IDataChangedHandler)
                    MyBase.New(commonObjects)
                    Me.HostForm = hostForm
                End Sub
            End Class
            Friend Shared Sub LoadData(grid As UltraGrid, all As IEnumerable(Of CSnapshot), commonObjects As CCommonObjects, hostForm As IDataChangedHandler)
                grid.Tag = New LocalTagBits(commonObjects, hostForm)
                Dim dt = GetBlankDt()
                For Each snapshot In all.OrderBy(Function(c) c.SnapshotDate)
                    Dim dr = dt.NewRow
                    dr(Columns.SnapshotDate.ToString) = snapshot.SnapshotDate
                    dr(Columns.Coins.ToString) = snapshot.Coins
                    dr(Columns.Shares.ToString) = snapshot.Shares
                    dt.Rows.Add(dr)
                Next
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                RemoveHandler grid.KeyDown, AddressOf KeyDown
                AddHandler grid.KeyDown, AddressOf KeyDown
                RemoveHandler grid.AfterCellUpdate, AddressOf AfterCellUpdate
                AddHandler grid.AfterCellUpdate, AddressOf AfterCellUpdate
                RemoveHandler grid.AfterRowsDeleted, AddressOf AfterRowsDeleted
                AddHandler grid.AfterRowsDeleted, AddressOf AfterRowsDeleted
                grid.DataSource = dt
            End Sub
            Private Shared Sub AfterRowsDeleted(sender As Object, e As EventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    tagBits.HostForm.DataChanged()
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Sub AfterCellUpdate(sender As Object, e As CellEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    tagBits.HostForm.DataChanged()
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub KeyDown(sender As Object, e As KeyEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    HandleArrowKeys(grid, e)
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    If Not e.Row.IsAddRow Then
                        Dim thisSnapshot = GetSnapshotFromRow(e.Row)

                        e.Row.Cells(Columns.Total.ToString).Value = thisSnapshot.Total

                        Dim previousRow = e.Row.GetSibling(SiblingRow.Previous)
                        Dim diffCoins As Decimal? = Nothing
                        Dim diffCoinsPc As Decimal? = Nothing
                        Dim diffShares As Decimal? = Nothing
                        Dim diffSharesPc As Decimal? = Nothing
                        Dim diffTotal As Decimal? = Nothing
                        Dim diffTotalPc As Decimal? = Nothing
                        If previousRow IsNot Nothing Then
                            Dim previousSnapshot = GetSnapshotFromRow(previousRow)
                            diffCoins = thisSnapshot.Coins - previousSnapshot.Coins
                            If thisSnapshot.Coins <> 0 Then
                                diffCoinsPc = (thisSnapshot.Coins - previousSnapshot.Coins) / thisSnapshot.Coins
                            Else
                                diffCoinsPc = 0
                            End If

                            diffShares = thisSnapshot.Shares - previousSnapshot.Shares
                            If thisSnapshot.Shares <> 0 Then
                                diffSharesPc = (thisSnapshot.Shares - previousSnapshot.Shares) / thisSnapshot.Shares
                            Else
                                diffSharesPc = 0
                            End If

                            diffTotal = thisSnapshot.Total - previousSnapshot.Total
                            If thisSnapshot.Total <> 0 Then
                                diffTotalPc = (thisSnapshot.Total - previousSnapshot.Total) / thisSnapshot.Total
                            Else
                                diffTotalPc = 0
                            End If
                        End If

                        Dim foreColour As Color

                        If diffCoins.HasValue Then
                            e.Row.Cells(Columns.DifferenceCoins.ToString).Value = diffCoins.Value
                            If diffCoins.Value > 0 Then
                                foreColour = Color.Green
                            ElseIf diffCoins.Value = 0 Then
                                foreColour = Color.Black
                            Else
                                foreColour = Color.Red
                            End If
                            e.Row.Cells(Columns.DifferenceCoinsPc.ToString).Value = diffCoinsPc.Value
                        Else
                            e.Row.Cells(Columns.DifferenceCoins.ToString).Value = DBNull.Value
                            e.Row.Cells(Columns.DifferenceCoinsPc.ToString).Value = DBNull.Value
                        End If
                        e.Row.Cells(Columns.DifferenceCoins.ToString).Appearance.ForeColor = foreColour
                        e.Row.Cells(Columns.DifferenceCoinsPc.ToString).Appearance.ForeColor = foreColour

                        If diffShares.HasValue Then
                            e.Row.Cells(Columns.DifferenceShares.ToString).Value = diffShares.Value
                            If diffShares.Value > 0 Then
                                foreColour = Color.Green
                            ElseIf diffShares.Value = 0 Then
                                foreColour = Color.Black
                            Else
                                foreColour = Color.Red
                            End If
                            e.Row.Cells(Columns.DifferenceSharesPc.ToString).Value = diffSharesPc.Value
                        Else
                            e.Row.Cells(Columns.DifferenceShares.ToString).Value = DBNull.Value
                            e.Row.Cells(Columns.DifferenceSharesPc.ToString).Value = DBNull.Value
                        End If
                        e.Row.Cells(Columns.DifferenceShares.ToString).Appearance.ForeColor = foreColour
                        e.Row.Cells(Columns.DifferenceSharesPc.ToString).Appearance.ForeColor = foreColour

                        If diffTotal.HasValue Then
                            e.Row.Cells(Columns.DifferenceTotal.ToString).Value = diffTotal.Value
                            If diffTotal.Value > 0 Then
                                foreColour = Color.Green
                            ElseIf diffTotal.Value = 0 Then
                                foreColour = Color.Black
                            Else
                                foreColour = Color.Red
                            End If
                            e.Row.Cells(Columns.DifferenceTotalPc.ToString).Value = diffTotalPc.Value
                        Else
                            e.Row.Cells(Columns.DifferenceTotal.ToString).Value = DBNull.Value
                            e.Row.Cells(Columns.DifferenceTotalPc.ToString).Value = DBNull.Value
                        End If
                        e.Row.Cells(Columns.DifferenceTotal.ToString).Appearance.ForeColor = foreColour
                        e.Row.Cells(Columns.DifferenceTotalPc.ToString).Appearance.ForeColor = foreColour

                        e.Row.Update()
                    End If
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Const MONEY_WIDTH = 75
                Const DIFF_WIDTH = 65
                Const PC_WIDTH = 45
                Const MONEY_FORMAT = "c2"
                Const PC_FORMAT = "P"
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .AllowAddNew = AllowAddNew.TemplateOnBottom
                    End With
                    e.Layout.AutoFitColumns = True

                    Const GROUP_DATE = "left"
                    Const GROUP_COINS = "coins"
                    Const GROUP_SHARES = "shares"
                    Const GROUP_TOTAL = "total"

                    Dim grpDate = e.Layout.Bands(0).Groups.Add(GROUP_DATE, "")
                    Dim grpCoins = e.Layout.Bands(0).Groups.Add(GROUP_COINS, "Coins")
                    Dim grpShares = e.Layout.Bands(0).Groups.Add(GROUP_SHARES, "Shares")
                    Dim grpTotal = e.Layout.Bands(0).Groups.Add(GROUP_TOTAL, "Totals")

                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.SnapshotDate.ToString
                                col.Header.Caption = "Date"
                                col.Width = 80
                                col.Group = grpDate
                            Case Columns.DateBar.ToString
                                FormatBar(col, grpDate)
                            Case Columns.Coins.ToString
                                col.Header.Caption = "Coins"
                                col.Width = MONEY_WIDTH
                                col.Format = MONEY_FORMAT
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpCoins
                            Case Columns.DifferenceCoins.ToString
                                col.Header.Caption = "Diff"
                                col.Width = DIFF_WIDTH
                                col.Format = MONEY_FORMAT
                                col.CellActivation = Activation.ActivateOnly
                                col.CellAppearance.BackColor = SystemColors.Control
                                col.TabStop = False
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpCoins
                            Case Columns.DifferenceCoinsPc.ToString
                                col.Header.Caption = "%"
                                col.Width = PC_WIDTH
                                col.Format = PC_FORMAT
                                col.CellActivation = Activation.ActivateOnly
                                col.CellAppearance.BackColor = SystemColors.Control
                                col.TabStop = False
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpCoins
                            Case Columns.CoinsBar.ToString
                                FormatBar(col, grpCoins)
                            Case Columns.Shares.ToString
                                col.Header.Caption = "Shares"
                                col.Width = MONEY_WIDTH
                                col.Format = MONEY_FORMAT
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpShares
                            Case Columns.DifferenceShares.ToString
                                col.Header.Caption = "Diff"
                                col.Width = DIFF_WIDTH
                                col.Format = MONEY_FORMAT
                                col.CellActivation = Activation.ActivateOnly
                                col.CellAppearance.BackColor = SystemColors.Control
                                col.TabStop = False
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpShares
                            Case Columns.DifferenceSharesPc.ToString
                                col.Header.Caption = "%"
                                col.Width = PC_WIDTH
                                col.Format = PC_FORMAT
                                col.CellActivation = Activation.ActivateOnly
                                col.CellAppearance.BackColor = SystemColors.Control
                                col.TabStop = False
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpShares
                            Case Columns.SharesBar.ToString
                                FormatBar(col, grpShares)
                            Case Columns.Total.ToString
                                col.Header.Caption = "Total"
                                col.Width = MONEY_WIDTH
                                col.Format = MONEY_FORMAT
                                col.CellActivation = Activation.ActivateOnly
                                col.CellAppearance.BackColor = SystemColors.Control
                                col.TabStop = False
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpTotal
                            Case Columns.DifferenceTotal.ToString
                                col.Header.Caption = "Diff"
                                col.Width = DIFF_WIDTH
                                col.Format = MONEY_FORMAT
                                col.CellActivation = Activation.ActivateOnly
                                col.CellAppearance.BackColor = SystemColors.Control
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpTotal
                            Case Columns.DifferenceTotalPc.ToString
                                col.Header.Caption = "%"
                                col.Width = PC_WIDTH
                                col.Format = PC_FORMAT
                                col.CellActivation = Activation.ActivateOnly
                                col.CellAppearance.BackColor = SystemColors.Control
                                col.TabStop = False
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                                col.Group = grpTotal
                            Case Else
                                col.Hidden = True
                        End Select
                    Next
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub FormatBar(col As UltraGridColumn, grp As UltraGridGroup)
                col.MinWidth = 1
                col.Width = 1
                col.Header.Caption = String.Empty
                col.Group = grp
                col.TabStop = False
                col.CellAppearance.BackColor = Color.Silver
                col.CellActivation = Activation.Disabled
            End Sub

            Private Shared Function GetBlankDt() As DataTable
                Dim dt = New DataTable
                dt.Columns.Add(Columns.SnapshotDate.ToString, GetType(Date))
                dt.Columns.Add(Columns.DateBar.ToString)
                dt.Columns.Add(Columns.Coins.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.DifferenceCoins.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.DifferenceCoinsPc.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.CoinsBar.ToString)
                dt.Columns.Add(Columns.Shares.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.DifferenceShares.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.DifferenceSharesPc.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.SharesBar.ToString)
                dt.Columns.Add(Columns.Total.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.DifferenceTotal.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.DifferenceTotalPc.ToString, GetType(Decimal))
                dt.PrimaryKey = New DataColumn() {dt.Columns(Columns.SnapshotDate.ToString)}
                Return dt
            End Function
            Friend Shared Function GetAll(grid As UltraGrid) As IEnumerable(Of Snapshots.CSnapshot)
                grid.UpdateData()
                Dim all As New List(Of Snapshots.CSnapshot)
                For Each row As UltraGridRow In grid.Rows
                    Dim snapshot = GetSnapshotFromRow(row)
                    all.Add(snapshot)
                Next
                Return all
            End Function
            Private Shared Function GetSnapshotFromRow(row As UltraGridRow) As Snapshots.CSnapshot
                Dim snapshotDate = CDate(row.Cells(Columns.SnapshotDate.ToString).Value)
                Dim coins = CDatabase.DbToDecimal(row.Cells(Columns.Coins.ToString).Value)
                Dim shares = CDatabase.DbToDecimal(row.Cells(Columns.Shares.ToString).Value)
                Dim snapshot As New Snapshots.CSnapshot(snapshotDate, coins, shares)
                Return snapshot
            End Function

            Friend Shared Sub SetValue(grid As UltraGrid, snapshotDate As Date, coinsAndShares As CCoinsAndShares)
                Dim theRow As UltraGridRow = Nothing
                For Each row As UltraGridRow In grid.Rows
                    Dim snapshot = GetSnapshotFromRow(row)
                    If snapshot.SnapshotDate.Date = snapshotDate.Date Then
                        theRow = row
                        Exit For
                    End If
                Next
                If theRow Is Nothing Then
                    theRow = grid.DisplayLayout.Bands(0).AddNew
                    theRow.Cells(Columns.SnapshotDate.ToString).Value = snapshotDate
                End If
                theRow.Cells(Columns.Coins.ToString).Value = Math.Round(coinsAndShares.CoinsProfit, 2)
                theRow.Cells(Columns.Shares.ToString).Value = Math.Round(coinsAndShares.SharesProfit, 2)
                theRow.Update()
                theRow.Refresh(RefreshRow.FireInitializeRow)
            End Sub
            Friend Shared Sub ScrollLast(grid As UltraGrid)
                Dim lastRow As UltraGridRow = Nothing
                For Each row In grid.Rows
                    lastRow = row
                Next
                If lastRow IsNot Nothing Then
                    grid.ActiveRowScrollRegion.ScrollRowIntoView(lastRow)
                End If
            End Sub
        End Class
        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Cursor = Cursors.WaitCursor
                    Dim all = GridHelper.GetAll(GrdSnapshots)
                    m_snapshots.SaveAll(all)
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnTakeSnapshot_Click(sender As Object, e As EventArgs) Handles BtnTakeSnapshot.Click
            Try
                Dim coinsAndShares = GetValues(m_commonObjects)

                TxtCoins.Text = coinsAndShares.CoinsProfit.ToString("0.00", CultureInfo.CurrentCulture)
                TxtShares.Text = coinsAndShares.SharesProfit.ToString("0.00", CultureInfo.CurrentCulture)

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnSetTodaysValues_Click(sender As Object, e As EventArgs) Handles BtnSetTodaysValues.Click
            Try
                Cursor = Cursors.WaitCursor
                Dim coinsAndShares = GetValues(m_commonObjects)
                GridHelper.SetValue(GrdSnapshots, Now.Date, coinsAndShares)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub DataChanged() Implements IDataChangedHandler.DataChanged
            ChangesMade(True)
        End Sub

    End Class
End Namespace
