Imports System.Collections.ObjectModel
Imports CoinsAndShares.Instruments
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Transactions
    Friend Class CHoldingsGridHelper
        Private Enum Columns
            InstrumentCode
            InstrumentName
            Quantity
            CurrentRate
            CurrentValue

            NetCash
            Pl
        End Enum
        Private NotInheritable Class LocalTagBits : Inherits TagBits
            Friend ReadOnly Property AllInstruments As IEnumerable(Of CInstrument)
            Friend Sub New(commonObjects As CCommonObjects, allInstruments As IEnumerable(Of CInstrument))
                MyBase.New(commonObjects)
                Me.AllInstruments = allInstruments
            End Sub
        End Class
        Friend Shared Sub LoadData(grid As UltraGrid, transactions As Collection(Of CTransaction),
                                   commonObjects As CCommonObjects, batches As IEnumerable(Of CBatch), allInstruments As IEnumerable(Of CInstrument))
            'Dim instruments = New CInstruments(commonObjects)
            'Dim allInstruments = instruments.GetAll

            Dim currencies = commonObjects.Currencies
            Dim allCurrencies = currencies.GetAll

            grid.Tag = New LocalTagBits(commonObjects, allInstruments)
            Dim dt As DataTable = GetBlankDt()

            Dim totalsByInstrument = From t In transactions
                                     Group t By t.InstrumentCode Into Group
                                     Select InstrumentCode, TotalQuantity = Group.Sum(Function(c) c.Amount),
                                         LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))

            For Each t In totalsByInstrument.OrderBy(Function(c) Not String.IsNullOrEmpty(c.InstrumentCode)).ThenByDescending(Function(c) c.LocalCurrencyValue)
                Dim dr = dt.NewRow
                dr(Columns.InstrumentCode.ToString) = t.InstrumentCode
                If String.IsNullOrEmpty(t.InstrumentCode) Then
                    dr(Columns.InstrumentName.ToString) = GetLocalCurrencyName()
                Else
                    Dim i = allInstruments.Where(Function(c) c.Code.Equals(t.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                    If i IsNot Nothing Then
                        dr(Columns.InstrumentName.ToString) = i.Description
                        dr(Columns.CurrentRate.ToString) = i.Rate
                    End If
                    dr(Columns.Quantity.ToString) = t.TotalQuantity

                    Dim cPurchasedNetLocalCurrency =
                        batches.Where(Function(c)
                                          Return c.InstrumentCode.Equals(t.InstrumentCode, StringComparison.CurrentCultureIgnoreCase) AndAlso
                                          (c.TransactionType = ETransactionType.Buy OrElse c.TransactionType = ETransactionType.Sell)
                                      End Function).Sum(Function(c) c.MonetaryAmount)

                    dr(Columns.NetCash.ToString) = cPurchasedNetLocalCurrency

                    dr(Columns.Pl.ToString) = cPurchasedNetLocalCurrency + t.LocalCurrencyValue

                End If
                dr(Columns.CurrentValue.ToString) = t.LocalCurrencyValue


                dt.Rows.Add(dr)
            Next

            RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
            AddHandler grid.InitializeLayout, AddressOf InitializeLayout
            RemoveHandler grid.InitializeRow, AddressOf InitializeRow
            AddHandler grid.InitializeRow, AddressOf InitializeRow
            RemoveHandler grid.DoubleClick, AddressOf DoubleClick
            AddHandler grid.DoubleClick, AddressOf DoubleClick
            RemoveHandler grid.ClickCellButton, AddressOf ClickCellButton
            AddHandler grid.ClickCellButton, AddressOf ClickCellButton
            grid.DataSource = dt
        End Sub

        Private Shared Sub ClickCellButton(sender As Object, e As CellEventArgs)
            Dim grid As UltraGrid = CType(sender, UltraGrid)
            Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
            Try
                Select Case e.Cell.Column.Key
                    Case Columns.Quantity.ToString
                        Clipboard.SetText(e.Cell.Text)
                        'MessageBox.Show("Quantity copied to clipboard", "Quantity Copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Select
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub DoubleClick(sender As Object, e As EventArgs)
            Dim grid As UltraGrid = CType(sender, UltraGrid)
            Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
            Try
                If WasGridRowClicked(grid) AndAlso grid.Selected.Rows.Count = 1 Then
                    Dim sInstrumentCode As String = grid.Selected.Rows(0).Cells(Columns.InstrumentCode.ToString).Text

                    FInstrument.Launch(tagBits.CommonObjects, sInstrumentCode)

                End If
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            Dim grid As UltraGrid = CType(sender, UltraGrid)
            Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
            Try
                Dim sInstrumentCode As String = e.Row.Cells(Columns.InstrumentCode.ToString).Text

                Dim foreColour As Color = Color.Black
                If Not String.IsNullOrEmpty(sInstrumentCode) Then
                    Dim instrument = tagBits.AllInstruments.Where(Function(c) c.Code.Equals(sInstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                    Dim instrumentType As EInstrumentType

                    If instrument IsNot Nothing Then
                        instrumentType = instrument.InstrumentType
                        foreColour = CColours.InstrumentType(instrumentType)
                    End If
                End If

                Dim cValue = CDatabase.DbToDecimal(e.Row.Cells(Columns.CurrentValue).Value)

                If Math.Abs(cValue) > 0.01 Then
                    e.Row.CellAppearance.FontData.Bold = DefaultableBoolean.True
                End If

                e.Row.CellAppearance.ForeColor = foreColour

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
                    .AllowDelete = DefaultableBoolean.False
                    .AllowUpdate = DefaultableBoolean.False
                    .RowSelectors = DefaultableBoolean.False
                    .CellClickAction = CellClickAction.RowSelect
                    .SelectTypeRow = SelectType.Single
                    .SelectTypeCol = SelectType.None
                    .HeaderClickAction = HeaderClickAction.SortMulti

                    .SummaryFooterCaptionVisible = DefaultableBoolean.False
                    .SummaryFooterAppearance.BackColor = Color.AliceBlue
                    .SummaryValueAppearance.BackColor = Color.AliceBlue
                End With
                e.Layout.AutoFitColumns = True

                With e.Layout.Bands(0)
                    .Summaries.Clear()
                    With .Summaries.Add(SummaryType.Sum, .Columns(Columns.CurrentValue.ToString), SummaryPosition.UseSummaryPositionColumn)
                        .DisplayFormat = "{0:C2}"
                        .Appearance.TextHAlign = HAlign.Right
                    End With
                    With .Summaries.Add(SummaryType.Sum, .Columns(Columns.NetCash.ToString), SummaryPosition.UseSummaryPositionColumn)
                        .DisplayFormat = "{0:C2}"
                        .Appearance.TextHAlign = HAlign.Right
                    End With
                    With .Summaries.Add(SummaryType.Sum, .Columns(Columns.Pl.ToString), SummaryPosition.UseSummaryPositionColumn)
                        .DisplayFormat = "{0:C2}"
                        .Appearance.TextHAlign = HAlign.Right
                    End With
                    .SummaryFooterCaption = "Total"
                End With

                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.InstrumentCode.ToString
                            col.Header.Caption = "Instr"
                            col.Width = 90
                        Case Columns.InstrumentName.ToString
                            col.Header.Caption = "Name"
                            col.Width = 120
                        Case Columns.Quantity.ToString
                            col.Header.Caption = "Qty Held"
                            col.Width = 125
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Format = FORMAT_QUANTITY
                            col.Style = ColumnStyle.Button
                        Case Columns.CurrentRate.ToString
                            col.Header.Caption = "Cur Rate"
                            col.Width = 100
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Format = FORMAT_RATE
                        Case Columns.CurrentValue.ToString
                            col.Header.Caption = "Value"
                            col.Width = 100
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Format = "c2"

                        Case Columns.NetCash.ToString
                            col.Header.Caption = "Net Cash"
                            col.Width = 100
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Format = "c2"
                        Case Columns.Pl.ToString
                            col.Header.Caption = "P/L"
                            col.Width = 100
                            col.CellAppearance.TextHAlign = HAlign.Right
                            col.Format = "c2"
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
            dt.Columns.Add(Columns.InstrumentCode.ToString)
            dt.Columns.Add(Columns.InstrumentName.ToString)
            dt.Columns.Add(Columns.Quantity.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.CurrentRate.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.CurrentValue.ToString, GetType(Decimal))

            dt.Columns.Add(Columns.NetCash.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.Pl.ToString, GetType(Decimal))
            Return dt
        End Function
    End Class

End Namespace
