Imports System.Collections.ObjectModel
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Networks
Imports CoinsAndShares.Transactions
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Accounts
    Friend Class FAccountList : Implements IDataRefresh

        Const REG_SETTING_TRUE = "1"
        Const REG_SETTING_FALSE = "0"

        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.bank.GetHicon)

            ChkShowZero.Checked = GetSetting(Application.ProductName, Name, ChkShowZero.Name, REG_SETTING_TRUE) = REG_SETTING_TRUE

            LoadData()

            AddHandler ChkShowZero.CheckedChanged, AddressOf ChkShowZeroCheckedChanged
        End Sub
        Private Sub LoadData()
            Dim allInstruments = m_commonObjects.Instruments.GetAll()
            Dim allAccounts = m_commonObjects.Accounts.GetAll()
            Dim allCurrencies = m_commonObjects.Currencies.GetAll()
            GridHelper.LoadData(GrdAccounts, allAccounts, m_commonObjects, Me, allInstruments, allCurrencies, ChkShowZero.Checked, m_commonObjects.Networks)
            LblGrandTotal.Text = FormatCurrency(allAccounts.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies)))
        End Sub
        Private NotInheritable Class GridHelper
            Private NotInheritable Class LocalTagBits : Inherits TagBits
                Friend ReadOnly Property FrmAccountList As FAccountList
                Friend ReadOnly Property Networks As CNetworks
                Friend Sub New(commonObjects As CCommonObjects, frmAccountList As FAccountList, networks As CNetworks)
                    MyBase.New(commonObjects)
                    Me.FrmAccountList = frmAccountList
                    Me.Networks = networks
                End Sub
            End Class
            Private Enum ColumnsGroup
                IsGroupBand
                AccountTypeCode
                AccountTypeDesc
            End Enum
            Private Enum ColumnsAccount
                IsAccountBand
                AccountCode
                AccountName
                AccountTypeCode
                NetworkId
                LocalCurrencyBalance
                Pl
                Notes
                IncludeOnShortcuts
                NonTaxable
            End Enum
            Friend Shared Sub LoadData(grid As UltraGrid, accounts As IEnumerable(Of CAccount), commonObjects As CCommonObjects,
                                       frmAccountList As FAccountList, allInstruments As IEnumerable(Of CInstrument),
                                       allCurrencies As IEnumerable(Of CCurrencyDetail), fShowZeroBalanceAccounts As Boolean,
                                       networks As CNetworks)
                grid.Tag = New LocalTagBits(commonObjects, frmAccountList, networks)

                Dim dtGroups As DataTable = GetGroupsTable(accounts)

                accounts = accounts.OrderBy(Function(c) c.NetworkId).ThenBy(Function(c) c.AccountCode)

                Dim dtAccounts As DataTable = GetBlankDt()
                For Each account In accounts
                    Dim cBalance = account.GetLocalCurrencyBalance(allInstruments, allCurrencies)
                    cBalance = Decimal.Round(cBalance, 2)

                    If cBalance <> 0 OrElse fShowZeroBalanceAccounts Then
                        Dim dr = dtAccounts.NewRow
                        dr(ColumnsAccount.AccountCode.ToString) = account.AccountCode
                        dr(ColumnsAccount.AccountName.ToString) = account.AccountName
                        dr(ColumnsAccount.AccountTypeCode.ToString) = account.AccountType.Code
                        dr(ColumnsAccount.NetworkId.ToString) = account.NetworkId
                        dr(ColumnsAccount.LocalCurrencyBalance.ToString) = cBalance

                        Dim analysis = CTransactions.Analyse(account.Transactions, allInstruments, allCurrencies)
                        dr(ColumnsAccount.Pl.ToString) = analysis.ProfitLoss
                        dr(ColumnsAccount.Notes.ToString) = account.Notes

                        dr(ColumnsAccount.IncludeOnShortcuts.ToString) = account.IncludeOnShortcuts
                        dr(ColumnsAccount.NonTaxable.ToString) = account.NonTaxable

                        dtAccounts.Rows.Add(dr)
                    End If
                Next
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.DoubleClick, AddressOf DoubleClick
                AddHandler grid.DoubleClick, AddressOf DoubleClick

                Dim ds As New DataSet

                ds.Tables.Add(dtGroups)
                ds.Tables.Add(dtAccounts)
                ds.Relations.Add(String.Empty, dtGroups.Columns(ColumnsGroup.AccountTypeCode.ToString), dtAccounts.Columns(ColumnsAccount.AccountTypeCode.ToString))

                grid.DataSource = ds
                For Each row As UltraGridRow In grid.Rows
                    row.ExpandAll()
                Next
            End Sub
            Private Shared Function GetGroupsTable(accounts As IEnumerable(Of CAccount)) As DataTable
                Dim dt As New DataTable
                dt.Columns.Add(ColumnsGroup.IsGroupBand.ToString)
                dt.Columns.Add(ColumnsGroup.AccountTypeCode.ToString)
                dt.Columns.Add(ColumnsGroup.AccountTypeDesc.ToString)
                For Each accountType As EAccountType In [Enum].GetValues(GetType(EAccountType))
                    If accounts.Where(Function(c) c.AccountType = accountType).Any Then
                        Dim dr = dt.NewRow()
                        dr(ColumnsGroup.AccountTypeCode.ToString) = accountType.Code
                        dr(ColumnsGroup.AccountTypeDesc) = accountType.ToString.Replace("_", " ")
                        dt.Rows.Add(dr)
                    End If
                Next
                Return dt
            End Function
            Private Shared Sub DoubleClick(sender As Object, e As EventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    If WasGridRowClicked(sender) Then
                        tagBits.CommonObjects.FrmMdi.Cursor = Cursors.WaitCursor
                        tagBits.FrmAccountList.EditClick()
                    End If
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                Finally
                    tagBits.CommonObjects.FrmMdi.Cursor = Cursors.Default
                End Try
            End Sub
            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                If e.ReInitialize Then
                    Return
                End If
                Dim grid = CType(sender, UltraGrid)
                Dim tagBits = CType(grid.Tag, LocalTagBits)
                Try
                    Dim accountType As EAccountType
                    Dim fBold = DefaultableBoolean.False

                    If e.Row.Cells.Exists(ColumnsAccount.IsAccountBand.ToString) Then

                        Dim account As CAccount = GetAccountFromRow(e.Row)
                        accountType = account.AccountType

                        Dim cLocalBalance = CDatabase.DbToDecimal(e.Row.Cells(ColumnsAccount.LocalCurrencyBalance.ToString).Value)
                        If Math.Round(cLocalBalance, 2) <> 0 Then
                            fBold = DefaultableBoolean.True
                        End If

                        Dim backColour = tagBits.Networks.GetColour(account)
                        e.Row.CellAppearance.BackColor = backColour

                    ElseIf e.Row.Cells.Exists(ColumnsGroup.IsGroupBand.ToString) Then
                        Dim sAccountType As String = e.Row.Cells(ColumnsGroup.AccountTypeCode).Text
                        accountType = GetAccountTypeFromCode(sAccountType, True)

                    End If

                    e.Row.CellAppearance.ForeColor = CColours.AccountType(accountType)
                    e.Row.CellAppearance.FontData.Bold = fBold

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Function GetAccountFromRow(row As UltraGridRow) As CAccount
                Dim sAccountCode As String = row.Cells(ColumnsAccount.AccountCode.ToString).Text
                Dim sAccountName As String = row.Cells(ColumnsAccount.AccountName.ToString).Text
                Dim sAccountType As String = row.Cells(ColumnsAccount.AccountTypeCode.ToString).Text
                Dim accountType As EAccountType = GetAccountTypeFromCode(sAccountType, True)
                Dim sNetworkId As String = row.Cells(ColumnsAccount.NetworkId.ToString).Text
                Dim sNotes As String = row.Cells(ColumnsAccount.Notes.ToString).Text

                'Dim backgroundColour As Color? = Nothing
                'If Not IsDBNull(row.Cells(ColumnsAccount.BackgroundColour.ToString).Value) Then
                '    Try
                '        Dim c As Color
                '        Dim iColour = CDatabase.DbToInt(row.Cells(ColumnsAccount.BackgroundColour.ToString).Value)
                '        c = Color.FromArgb(iColour)
                '        backgroundColour = c
                '    Catch ignored As Exception
                '    End Try
                'End If

                Dim includeOnShortcuts = CDatabase.DbToBool(row.Cells(ColumnsAccount.IncludeOnShortcuts.ToString).Value)
                Dim nonTaxable = CDatabase.DbToBool(row.Cells(ColumnsAccount.NonTaxable.ToString).Value)

                Dim account As New CAccount(sAccountCode, sAccountName, accountType, sNotes, sNetworkId, includeOnShortcuts, nonTaxable)
                Return account
            End Function

            Private Shared Function GetBlankDt() As DataTable
                Dim dt As New DataTable
                dt.Columns.Add(ColumnsAccount.IsAccountBand.ToString)
                dt.Columns.Add(ColumnsAccount.AccountCode.ToString)
                dt.Columns.Add(ColumnsAccount.AccountName.ToString)
                dt.Columns.Add(ColumnsAccount.AccountTypeCode.ToString)
                dt.Columns.Add(ColumnsAccount.NetworkId.ToString)
                dt.Columns.Add(ColumnsAccount.LocalCurrencyBalance.ToString, GetType(Decimal))
                dt.Columns.Add(ColumnsAccount.Pl.ToString, GetType(Decimal))
                dt.Columns.Add(ColumnsAccount.Notes.ToString)
                dt.Columns.Add(ColumnsAccount.IncludeOnShortcuts.ToString, GetType(Boolean))
                dt.Columns.Add(ColumnsAccount.NonTaxable.ToString, GetType(Boolean))
                Return dt
            End Function
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
                        With .Summaries.Add(SummaryType.Sum, .Columns(ColumnsAccount.LocalCurrencyBalance.ToString), SummaryPosition.UseSummaryPositionColumn)
                            .DisplayFormat = "{0:C2}"
                            .Appearance.TextHAlign = HAlign.Right
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
                            Case ColumnsAccount.LocalCurrencyBalance.ToString
                                col.Header.Caption = GetLocalCurrencyName()
                                col.Width = 60
                                col.Format = "c2"
                                col.CellAppearance.TextHAlign = HAlign.Right
                            Case ColumnsAccount.Pl.ToString
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
            Friend Shared Function GetSelectedRows(grid As UltraGrid) As IEnumerable(Of CAccount)
                Dim col As New Collection(Of CAccount)
                For Each row In grid.Selected.Rows
                    If row.Cells.Exists(ColumnsAccount.IsAccountBand.ToString) Then
                        Dim account = GetAccountFromRow(row)
                        col.Add(account)
                    End If
                Next
                Return col
            End Function
        End Class

        Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
            Try
                Using frmNewAccount As New FNewAccount(m_commonObjects)
                    frmNewAccount.ShowDialog()
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
            Try
                EditClick()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub EditClick()
            Dim accounts As IEnumerable(Of CAccount) = GridHelper.GetSelectedRows(GrdAccounts)
            If Not accounts.Any Then
                Throw New Exception(My.Resources.Error_NoRowsSelected)
            ElseIf accounts.Count > 1 Then
                Throw New Exception(My.Resources.Error_SelectOneItemOnly)
            End If
            Dim account = accounts.First
            Dim frmAccount As FAccount = Nothing
            For Each frm As Form In m_commonObjects.FrmMdi.MdiChildren
                If TypeOf frm Is FAccount Then
                    Dim fTest = CType(frm, FAccount)
                    If fTest.AccountCode.Equals(account.AccountCode, StringComparison.CurrentCultureIgnoreCase) Then
                        frmAccount = fTest
                        Exit For
                    End If
                End If
            Next
            If frmAccount Is Nothing Then
                frmAccount = New FAccount(m_commonObjects, account.AccountCode) With {
                    .MdiParent = m_commonObjects.FrmMdi
                }
                frmAccount.Show()
            End If
            frmAccount.Activate()
        End Sub
        Friend Sub RefreshData() Implements IDataRefresh.RefreshData
            Try
                If Me.Visible Then
                    LoadData()
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
            Const PROMPT As String = "DELETE"
            Try
                Dim selected = GridHelper.GetSelectedRows(GrdAccounts)
                If selected.Count <> 1 Then
                    Throw New Exception(My.Resources.Error_SelectOneItemOnly)
                End If
                Dim account = selected.First
                Dim sRet = InputBox($"Type {PROMPT} to delete this account {account.AccountCode}")
                If String.IsNullOrEmpty(sRet) Then
                    Return
                End If
                If Not sRet.Equals(PROMPT, StringComparison.CurrentCultureIgnoreCase) Then
                    Throw New Exception(My.Resources.Error_IncorrectResponse)
                End If
                Cursor = Cursors.WaitCursor
                m_commonObjects.Accounts.Delete(account.AccountCode)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnTransferFiat_Click(sender As Object, e As EventArgs) Handles BtnTransferFiat.Click
            Try
                'If m_accounts.GetAll.Count < 2 Then
                '    Throw New Exception("Must have at least 2 accounts to transfer")
                'End If
                Cursor = Cursors.WaitCursor
                Using frmTransfer As New FTransferFiat(m_commonObjects)
                    frmTransfer.ShowDialog()
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Try
                Cursor = Cursors.WaitCursor
                m_commonObjects.ClearCache()
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnTransferCrypto_Click(sender As Object, e As EventArgs) Handles BtnTransferCrypto.Click
            Try
                'If m_accounts.GetAll.Count < 2 Then
                '    Throw New Exception("Must have at least 2 accounts to transfer")
                'End If
                Cursor = Cursors.WaitCursor
                Using frmTransferCrypto As New FTransferCrypto(m_commonObjects)
                    frmTransferCrypto.ShowDialog()
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub ChkShowZeroCheckedChanged(sender As Object, e As EventArgs)
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
                Dim sSetting = If(ChkShowZero.Checked, REG_SETTING_TRUE, REG_SETTING_FALSE)
                SaveSetting(Application.ProductName, Name, ChkShowZero.Name, sSetting)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
