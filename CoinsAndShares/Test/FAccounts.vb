Imports CoinsAndShares.Accounts
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Test
    Friend Class FAccounts : Implements IDataRefresh

        Const REG_SETTING_TRUE = "1"
        Const REG_SETTING_FALSE = "0"

        Private ReadOnly m_commonObjects As CCommonObjects
        Public Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.bank.GetHicon)

            ChkIncludeZero.Checked = GetSetting(Application.ProductName, Name, ChkIncludeZero.Name, REG_SETTING_TRUE) = REG_SETTING_TRUE

            LoadData()

            AddHandler ChkIncludeZero.CheckedChanged, AddressOf ChkIncludeZero_CheckedChanged
        End Sub

        Private Sub ChkIncludeZero_CheckedChanged(sender As Object, e As EventArgs)
            Cursor = Cursors.WaitCursor
            Try
                LoadData()
                Dim sSetting = If(ChkIncludeZero.Checked, REG_SETTING_TRUE, REG_SETTING_FALSE)
                SaveSetting(Application.ProductName, Name, ChkIncludeZero.Name, sSetting)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub LoadData()

            Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)

            GridHelper.LoadData(GrdAccounts, cs.AllAccounts, m_commonObjects, ChkIncludeZero.Checked)

        End Sub

        Private Class GridHelper
            Private Enum ColumnsAccount
                IsAccountBand
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

            Friend Shared Sub LoadData(grid As UltraGrid, allAccounts As IEnumerable(Of CAccount), commonObjects As CCommonObjects,
                                       includeZeroBalanceAccounts As Boolean)

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
                dtAccounts.Columns.Add(ColumnsAccount.IsAccountBand.ToString, GetType(Boolean))
                dtAccounts.Columns.Add(ColumnsAccount.AccountCode.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountName.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountTypeCode.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.NetworkId.ToString)
                dtAccounts.Columns.Add(ColumnsAccount.AccountValue.ToString, GetType(Decimal))
                dtAccounts.Columns.Add(ColumnsAccount.FreeCashBalance.ToString, GetType(Decimal))
                dtAccounts.Columns.Add(ColumnsAccount.Profit.ToString, GetType(Decimal))
                For Each account In allAccounts.OrderBy(Function(c) c.NetworkId).ThenBy(Function(c) c.AccountCode)
                    Dim cBalance = Decimal.Round(account.GetBalance, 2)
                    If cBalance <> 0 OrElse includeZeroBalanceAccounts Then
                        Dim dr = dtAccounts.NewRow
                        dr(ColumnsAccount.IsAccountBand.ToString) = True
                        dr(ColumnsAccount.AccountCode.ToString) = account.AccountCode
                        dr(ColumnsAccount.AccountName.ToString) = account.AccountName
                        dr(ColumnsAccount.AccountTypeCode.ToString) = account.AccountType.Code
                        dr(ColumnsAccount.NetworkId.ToString) = account.NetworkId
                        If cBalance <> 0 Then
                            dr(ColumnsAccount.AccountValue.ToString) = cBalance
                        End If
                        If account.AccountType <> EAccountType.Bank_Account Then
                            dr(ColumnsAccount.FreeCashBalance.ToString) = account.GetCashBalance
                        End If
                        dr(ColumnsAccount.Profit.ToString) = account.GetPl
                        dtAccounts.Rows.Add(dr)
                    End If
                Next

                Dim ds As New DataSet

                ds.Tables.Add(dtGroups)
                ds.Tables.Add(dtAccounts)
                ds.Relations.Add(String.Empty, dtGroups.Columns(ColumnsGroup.AccountTypeCode.ToString), dtAccounts.Columns(ColumnsAccount.AccountTypeCode.ToString))

                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout

                grid.DataSource = ds

                For Each row As UltraGridRow In grid.Rows
                    row.ExpandAll()
                Next

            End Sub
            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                If e.ReInitialize Then
                    Return
                End If
                Dim grid = CType(sender, UltraGrid)
                Dim tagBits = CType(grid.Tag, TagBits)
                Try
                    Dim accountTypeCode = String.Empty
                    Dim fBold = DefaultableBoolean.False
                    If e.Row.Cells.Exists(ColumnsAccount.IsAccountBand.ToString) Then
                        accountTypeCode = e.Row.Cells(ColumnsAccount.AccountTypeCode.ToString).Text
                        Dim cLocalBalance = CDatabase.DbToDecimal(e.Row.Cells(ColumnsAccount.AccountValue.ToString).Value)
                        If Math.Round(cLocalBalance, 2) <> 0 Then
                            fBold = DefaultableBoolean.True
                        End If

                        Dim sNetworkId = e.Row.Cells(ColumnsAccount.NetworkId.ToString).Text
                        Dim backColour = Color.White
                        If Not String.IsNullOrEmpty(sNetworkId) Then
                            Dim cs = CCoinsAndShares.GetInstance(tagBits.CommonObjects)
                            Dim network = cs.AllNetworks().FirstOrDefault(Function(c) c.NetworkId.Equals(sNetworkId, StringComparison.CurrentCultureIgnoreCase))
                            If network IsNot Nothing AndAlso network.Colour.HasValue Then
                                backColour = network.Colour.Value
                            End If
                        End If

                        e.Row.CellAppearance.BackColor = backColour
                    ElseIf e.Row.Cells.Exists(ColumnsGroup.IsGroupBand.ToString) Then
                        accountTypeCode = e.Row.Cells(ColumnsGroup.AccountTypeCode).Text
                    End If
                    Dim accountType = GetAccountTypeFromCode(accountTypeCode, True)
                    e.Row.CellAppearance.ForeColor = CColours.AccountType(accountType)
                    e.Row.CellAppearance.FontData.Bold = fBold
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    e.Layout.AutoFitColumns = True
                    With e.Layout.Override
                        .AllowAddNew = AllowAddNew.No
                        .HeaderClickAction = HeaderClickAction.SortMulti
                        .RowSelectors = DefaultableBoolean.False
                        .CellClickAction = CellClickAction.RowSelect
                        .SelectTypeRow = SelectType.Extended
                        .SelectTypeCol = SelectType.None
                        .HeaderClickAction = HeaderClickAction.SortMulti
                        .SummaryFooterCaptionVisible = DefaultableBoolean.False
                        .SummaryFooterAppearance.BackColor = Color.AliceBlue
                        .SummaryValueAppearance.BackColor = Color.AliceBlue
                    End With

                    ' Groups Band
                    With e.Layout.Bands(0)
                        .ColHeadersVisible = False
                        .Override.RowSpacingBefore = 5
                        .Override.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case ColumnsGroup.AccountTypeDesc.ToString
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                    ' Account Band
                    With e.Layout.Bands(1)
                        .Summaries.Clear()
                        With .Summaries.Add(SummaryType.Sum, .Columns(ColumnsAccount.AccountValue.ToString), SummaryPosition.UseSummaryPositionColumn)
                            .DisplayFormat = "{0:C2}"
                            .Appearance.TextHAlign = HAlign.Right
                            .Appearance.FontData.Bold = DefaultableBoolean.True
                        End With
                        .SummaryFooterCaption = "Total Balance"
                    End With
                    For Each col As UltraGridColumn In e.Layout.Bands(1).Columns
                        Select Case col.Key
                            Case ColumnsAccount.AccountCode.ToString
                                col.Header.Caption = "Code"
                                col.Width = 85
                                col.Case = [Case].Upper
                                col.CellActivation = Activation.ActivateOnly
                                col.TabStop = False
                            Case ColumnsAccount.AccountName.ToString
                                col.Header.Caption = "Name"
                                col.Width = 175
                            Case ColumnsAccount.NetworkId.ToString
                                col.Header.Caption = "Network Id"
                                col.Width = 65
                            Case ColumnsAccount.AccountValue.ToString
                                col.Header.Caption = "Net Balance"
                                col.Width = 60
                                col.Format = "c2"
                                col.CellAppearance.TextHAlign = HAlign.Right
                            Case ColumnsAccount.FreeCashBalance.ToString
                                col.Header.Caption = "Free Cash"
                                col.Width = 60
                                col.Format = "c2"
                                col.CellAppearance.TextHAlign = HAlign.Right
                            Case ColumnsAccount.Profit.ToString
                                col.Header.Caption = "Profit/Loss"
                                col.Width = 60
                                col.Format = "c2"
                                col.CellAppearance.TextHAlign = HAlign.Right
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
        End Class

        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Cursor = Cursors.WaitCursor
            Try
                Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)
                cs.ClearCache()
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnFiatTransfer_Click(sender As Object, e As EventArgs) Handles BtnFiatTransfer.Click
            Try
                Cursor = Cursors.WaitCursor
                Using frmFiatTransfer = New FFiatTransfer(m_commonObjects)
                    Cursor = Cursors.Default
                    frmFiatTransfer.ShowDialog()
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Friend Sub RefreshData() Implements IDataRefresh.RefreshData

            LoadData()

        End Sub
    End Class
End Namespace
