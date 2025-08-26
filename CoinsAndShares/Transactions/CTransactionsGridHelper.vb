Imports System.Collections.ObjectModel
Imports System.Windows.Forms.DataVisualization.Charting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Transactions

    Friend NotInheritable Class CTransactionsGridHelper

        Private Enum Columns
            Id
            TransDate
            TransTypeCode
            TransTypeCodeDisplay
            AccountCode
            InstrumentCode
            Rate
            Amount
            AmountDisplay
            Sterling
            Description
            Batch
            ExchangeRate
            Reconciled
        End Enum
        Private NotInheritable Class LocalTagBits : Inherits TagBits
            Friend ReadOnly HostForm As ITransactionsForm
            Friend Sub New(commonObjects As CCommonObjects, hostForm As ITransactionsForm)
                MyBase.New(commonObjects)
                Me.HostForm = hostForm
            End Sub
        End Class

        Friend Shared Sub LoadData(grid As UltraGrid, transactions As IEnumerable(Of CTransaction),
                                   commonObjects As CCommonObjects, hostForm As ITransactionsForm)
            Dim dt As DataTable = GetBlankDt()
            grid.Tag = New LocalTagBits(commonObjects, hostForm)
            For Each transaction In transactions.OrderByDescending(Function(c) c.TransDate.Date).ThenByDescending(Function(c) c.Id)
                Dim dr = dt.NewRow
                dr(Columns.Id.ToString) = transaction.Id
                dr(Columns.Batch.ToString) = transaction.Batch
                dr(Columns.TransDate.ToString) = transaction.TransDate
                dr(Columns.TransTypeCode.ToString) = transaction.TransactionType.Code
                dr(Columns.AccountCode.ToString) = transaction.AccountCode
                dr(Columns.InstrumentCode.ToString) = transaction.InstrumentCode
                If transaction.Rate > 0 Then
                    dr(Columns.Rate.ToString) = transaction.Rate
                End If
                dr(Columns.Amount.ToString) = transaction.Amount
                dr(Columns.Sterling.ToString) = transaction.Sterling
                dr(Columns.Description.ToString) = transaction.Description
                If transaction.ExchangeRate > 0 And transaction.ExchangeRate <> 1 Then
                    dr(Columns.ExchangeRate.ToString) = transaction.ExchangeRate
                End If
                dr(Columns.Reconciled.ToString) = transaction.Reconciled
                dt.Rows.Add(dr)
            Next
            RemoveHandler grid.InitializeRow, AddressOf InitializeRow
            AddHandler grid.InitializeRow, AddressOf InitializeRow
            RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
            AddHandler grid.InitializeLayout, AddressOf InitializeLayout
            RemoveHandler grid.AfterSelectChange, AddressOf AfterSelectChange
            AddHandler grid.AfterSelectChange, AddressOf AfterSelectChange
            grid.DataSource = dt
            SpaceGridRows(grid)
        End Sub
        Private Shared Sub SpaceGridRows(grid As UltraGrid)

            For Each row As UltraGridRow In grid.Rows
                If row.HasNextSibling Then
                    Dim nextRow = row.GetSibling(SiblingRow.Next)
                    Dim nextTx = GetTransactionFromRow(nextRow)

                    Dim thisTx = GetTransactionFromRow(row)
                    If Not thisTx.Batch = nextTx.Batch Then
                        row.RowSpacingAfter = 1
                    End If
                End If
            Next
        End Sub
        Private Shared Sub AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs)
            Dim grid As UltraGrid = CType(sender, UltraGrid)
            Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
            Try
                Dim selectedTransactions = GetSelectedTransactions(grid)
                Dim totalAmount = selectedTransactions.Sum(Function(c) c.Amount)
                Dim totalSterling = selectedTransactions.Sum(Function(c) c.Sterling)
                tagBits.HostForm.SelectChanged(selectedTransactions.Count, totalAmount, totalSterling)
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private NotInheritable Class AmountComparer : Implements IComparer

            Friend Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
                Dim firstCell As UltraGridCell = CType(x, UltraGridCell)
                Dim secondCell As UltraGridCell = CType(y, UltraGridCell)
                Dim cFirstAmount = CDatabase.DbToDecimal(firstCell.Row.Cells(Columns.Amount.ToString).Value)
                Dim cSecondAmount = CDatabase.DbToDecimal(secondCell.Row.Cells(Columns.Amount.ToString).Value)
                If cFirstAmount > cSecondAmount Then
                    Return 1
                ElseIf cFirstAmount < cSecondAmount Then
                    Return -1
                Else
                    Return 0
                End If
            End Function

        End Class

        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim grid As UltraGrid = CType(sender, UltraGrid)
            Dim tagBits As TagBits = CType(grid.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                e.Layout.AutoFitColumns = True
                With e.Layout.Override
                    .AllowDelete = DefaultableBoolean.False
                    .AllowUpdate = DefaultableBoolean.False
                    .CellClickAction = CellClickAction.RowSelect
                    .HeaderClickAction = HeaderClickAction.SortMulti
                    .RowSelectors = DefaultableBoolean.False
                End With
                For Each col In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.Id.ToString
                            col.Header.Caption = "Id"
                            col.MinWidth = 45
                            col.MaxWidth = 45
                        Case Columns.Batch.ToString
                            col.Header.Caption = "Batch"
                            col.MinWidth = 45
                            col.MaxWidth = 45
                        Case Columns.TransDate.ToString
                            col.Header.Caption = "Date"
                            col.Width = 80
                            col.MinWidth = 70
                            col.MaxWidth = 70
                            col.CellAppearance.TextHAlign = HAlign.Center
                        Case Columns.TransTypeCodeDisplay.ToString
                            col.Header.Caption = "Trans Type"
                            col.Width = 80
                        Case Columns.AccountCode.ToString
                            col.Header.Caption = "Account"
                            col.Width = 80
                        Case Columns.InstrumentCode.ToString
                            col.Header.Caption = "Instrument"
                            col.Width = 80
                        Case Columns.Rate.ToString
                            col.Header.Caption = "Rate"
                            col.Width = 80
                            col.Format = FORMAT_RATE
                        Case Columns.AmountDisplay.ToString
                            col.Header.Caption = "Amount"
                            col.Width = 80
                            col.Format = FORMAT_QUANTITY
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.SortComparer = New AmountComparer
                        Case Columns.Sterling.ToString
                            col.Header.Caption = "Sterling"
                            col.Width = 80
                            col.Format = "c2"
                            col.CellAppearance.TextHAlign = HAlign.Right
                        Case Columns.Description.ToString
                            col.Header.Caption = "Description"
                            col.Width = 250
                        Case Columns.ExchangeRate.ToString
                            col.Header.Caption = "Exch/R"
                            col.Width = 40
                        Case Columns.Reconciled.ToString
                            col.Header.Caption = "R"
                            col.MinWidth = 20
                            col.MaxWidth = 20
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        'Private Class DateComparer : Implements IComparer
        '    Friend Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        '        Dim firstCell As UltraGridCell = CType(x, UltraGridCell)
        '        Dim secondCell As UltraGridCell = CType(y, UltraGridCell)
        '        Dim firstDate As Date
        '        If IsDBNull(firstCell.Row.Cells(Columns.TransDateTime.ToString).Value) Then
        '            firstDate = CDate("1/1/1900")
        '        Else
        '            firstDate = CDate(firstCell.Row.Cells(Columns.TransDateTime.ToString).Value)
        '        End If
        '        Dim seconddate As Date
        '        If IsDBNull(secondCell.Row.Cells(Columns.TransDateTime.ToString).Value) Then
        '            seconddate = CDate("1/1/1900")
        '        Else
        '            seconddate = CDate(secondCell.Row.Cells(Columns.TransDateTime.ToString).Value)
        '        End If
        '        If firstDate > seconddate Then
        '            Return 1
        '        ElseIf firstDate < seconddate Then
        '            Return -1
        '        Else
        '            Return 0
        '        End If
        '    End Function
        'End Class

        Friend Shared Function GetSelectedTransactions(grid As UltraGrid) As IEnumerable(Of CTransaction)
            Dim col As New Collection(Of CTransaction)
            For Each row As UltraGridRow In grid.Selected.Rows
                col.Add(GetTransactionFromRow(row))
            Next
            Return col
        End Function

        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            If e.ReInitialize Then
                Return
            End If
            Dim grid As UltraGrid = CType(sender, UltraGrid)
            Dim tagBits As TagBits = CType(grid.Tag, TagBits)
            Try
                Dim transaction As CTransaction = GetTransactionFromRow(e.Row)
                e.Row.Cells(Columns.TransTypeCodeDisplay.ToString).Value = transaction.TransactionType.ToString

                Dim sAmountDisplay As String
                'Dim sTooltip = String.Empty
                If String.IsNullOrEmpty(transaction.InstrumentCode) Then
                    sAmountDisplay = FormatCurrency(transaction.Amount)
                Else
                    sAmountDisplay = CType(transaction.Amount, String)
                    'sTooltip = FormatCurrency(transaction.Amount * transaction.Rate)
                End If
                e.Row.Cells(Columns.AmountDisplay.ToString).Value = sAmountDisplay
                'e.Row.Cells(Columns.AmountDisplay.ToString).ToolTipText = sTooltip

                e.Row.CellAppearance.ForeColor = CColours.TransactionType(transaction.TransactionType)

                e.Row.CellAppearance.BackColor = If(transaction.Reconciled, Color.PaleGreen, Color.White)

            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Function GetTransactionFromRow(row As UltraGridRow) As CTransaction
            Dim lId As Long = CDatabase.DbToLong(row.Cells(Columns.Id.ToString).Value)
            Dim transDate As Date = CType(row.Cells(Columns.TransDate.ToString).Value, Date)
            Dim transactionType As ETransactionType = GetTransactionTypeFromCode(row.Cells(Columns.TransTypeCode.ToString).Text, True)
            Dim sAccountCode As String = row.Cells(Columns.AccountCode.ToString).Text
            Dim sInstrumentCode As String = row.Cells(Columns.InstrumentCode.ToString).Text
            Dim rRate As Decimal = CDatabase.DbToDecimal(row.Cells(Columns.Rate.ToString).Value)
            Dim rAmount As Decimal = CDatabase.DbToDecimal(row.Cells(Columns.Amount.ToString).Value)
            Dim sDescription As String = row.Cells(Columns.Description.ToString).Text
            Dim lBatch As Long = CDatabase.DbToLong(row.Cells(Columns.Batch.ToString).Value)
            Dim rExchangeRate As Decimal = CDatabase.DbToDecimal(row.Cells(Columns.ExchangeRate.ToString).Value)
            Dim fReconciled As Boolean = CDatabase.DbToBool(row.Cells(Columns.Reconciled.ToString).Value)
            Dim transaction As New CTransaction(lId, transDate, transactionType, sAccountCode, sInstrumentCode,
                                                rRate, rAmount, sDescription, lBatch, rExchangeRate, fReconciled)
            Return transaction
        End Function

        Private Shared Function GetBlankDt() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add(Columns.Id.ToString, GetType(Long))
            dt.Columns.Add(Columns.Batch.ToString, GetType(Long))
            dt.Columns.Add(Columns.TransDate.ToString, GetType(Date))
            dt.Columns.Add(Columns.TransTypeCode.ToString)
            dt.Columns.Add(Columns.TransTypeCodeDisplay.ToString)
            dt.Columns.Add(Columns.AccountCode.ToString)
            dt.Columns.Add(Columns.InstrumentCode.ToString)
            dt.Columns.Add(Columns.Rate.ToString, GetType(Double))
            dt.Columns.Add(Columns.Amount.ToString, GetType(Double))
            dt.Columns.Add(Columns.AmountDisplay.ToString)
            dt.Columns.Add(Columns.Sterling.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.Description.ToString)
            dt.Columns.Add(Columns.ExchangeRate.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.Reconciled.ToString, GetType(Boolean))
            Return dt
        End Function

        Friend Shared Function GetFirstVisibleId(grid As UltraGrid) As Long?
            If grid.ActiveRowScrollRegion Is Nothing Then
                Return Nothing
            End If
            Return CDatabase.DbToLong(grid.ActiveRowScrollRegion.FirstRow.Cells(Columns.Id.ToString).Value)
        End Function

        Friend Shared Sub SetFirstVisibleId(grid As UltraGrid, id As Long)
            For Each r As UltraGridRow In grid.Rows
                If CDatabase.DbToLong(r.Cells(Columns.Id.ToString).Value) = id Then
                    grid.ActiveRowScrollRegion.FirstRow = r
                    Exit For
                End If
            Next
        End Sub
    End Class
End Namespace
