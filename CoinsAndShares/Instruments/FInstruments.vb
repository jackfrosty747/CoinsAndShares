Imports System.Collections.ObjectModel
Imports CoinsAndShares.Currencies
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Instruments
    Friend Class FInstruments : Implements IDataRefresh

        Private ReadOnly m_commonObjects As CCommonObjects

        Private m_allInstruments As IEnumerable(Of CInstrument)
        Private m_allCurrencies As IEnumerable(Of CCurrencyDetail)

        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.block.GetHicon)

            OptTypeCrypto.ForeColor = CColours.InstrumentType(EInstrumentType.Crypto)
            OptTypeShares.ForeColor = CColours.InstrumentType(EInstrumentType.Share)

            OptTypeAll.Checked = True

            LoadData()

            AddHandler OptTypeAll.CheckedChanged, AddressOf FilterChanged
            AddHandler OptTypeCrypto.CheckedChanged, AddressOf FilterChanged
            AddHandler OptTypeShares.CheckedChanged, AddressOf FilterChanged
            AddHandler TxtFilter.TextChanged, AddressOf FilterChanged

        End Sub

        Private Sub FilterChanged(sender As Object, e As EventArgs)
            Try
                FilterAndDisplay()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub LoadData()
            m_allInstruments = m_commonObjects.Instruments.GetAll()
            m_allCurrencies = m_commonObjects.Currencies.GetAll()
            FilterAndDisplay()
        End Sub

        Private Sub FilterAndDisplay()
            Dim filtered = m_allInstruments

            filtered = filtered.Where(Function(c)
                                          If TxtFilter.Text.Length > 0 AndAlso Not (
                                                        c.Code.ToUpper.Contains(TxtFilter.Text.ToUpper) OrElse
                                                        c.Description.ToUpper.Contains(TxtFilter.Text.ToUpper) OrElse
                                                        c.ProviderLinkCode.ToUpper.Contains(TxtFilter.Text.ToUpper)
                                          ) Then
                                              Return False
                                          End If
                                          If OptTypeCrypto.Checked AndAlso Not c.InstrumentType = EInstrumentType.Crypto Then
                                              Return False
                                          ElseIf OptTypeShares.Checked AndAlso Not c.InstrumentType = EInstrumentType.Share Then
                                              Return False
                                          End If
                                          Return True
                                      End Function)

            GridHelper.LoadData(GrdInstruments, filtered, m_commonObjects, Me, m_allCurrencies)
        End Sub

        Private NotInheritable Class GridHelper
            Private Enum Columns
                Code
                InstrumentTypeCode
                InstrumentTypeDesc
                Description
                Rate
                RateUpdated
                LinkSymbol
                AmountHeld
                LocalCurrencyBalance
                CurrencyCode
                ProviderMultiplier
                Notes
                HedgingGroupCode
            End Enum
            Private Class LocalTagBits : Inherits TagBits
                Friend ReadOnly FrmInstruments As FInstruments
                Friend Sub New(commonObjects As CCommonObjects, frmInstruments As FInstruments)
                    MyBase.New(commonObjects)
                    Me.FrmInstruments = frmInstruments
                End Sub
            End Class

            Friend Shared Sub LoadData(grid As UltraGrid, allInstruments As IEnumerable(Of CInstrument),
                    commonObjects As CCommonObjects, frmInstruments As FInstruments, allCurrencies As IEnumerable(Of CCurrencyDetail))
                grid.Tag = New LocalTagBits(commonObjects, frmInstruments)
                Dim dt = GetBlankDt()
                For Each instrument As CInstrument In allInstruments
                    Dim dr = dt.NewRow
                    dr(Columns.Code.ToString) = instrument.Code
                    dr(Columns.InstrumentTypeCode.ToString) = instrument.InstrumentType.Code
                    dr(Columns.InstrumentTypeDesc.ToString) = instrument.InstrumentType.ToString.Replace("_", " ")
                    dr(Columns.Description.ToString) = instrument.Description
                    dr(Columns.Rate.ToString) = instrument.Rate
                    If instrument.RateUpdated.HasValue Then
                        dr(Columns.RateUpdated.ToString) = instrument.RateUpdated.Value
                    End If
                    dr(Columns.LinkSymbol.ToString) = instrument.ProviderLinkCode
                    dr(Columns.AmountHeld.ToString) = instrument.GetQuantityHeld
                    dr(Columns.LocalCurrencyBalance.ToString) = instrument.GetLocalCurrencyBalance(allInstruments, allCurrencies)
                    dr(Columns.CurrencyCode.ToString) = instrument.CurrencyCode
                    dr(Columns.ProviderMultiplier.ToString) = instrument.ProviderMultiplier
                    dr(Columns.Notes.ToString) = instrument.Notes
                    dr(Columns.HedgingGroupCode.ToString) = instrument.HedgingGroupCode
                    dt.Rows.Add(dr)
                Next
                RemoveHandler grid.DoubleClick, AddressOf DoubleClick
                AddHandler grid.DoubleClick, AddressOf DoubleClick
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                grid.DataSource = dt
            End Sub

            Private Shared Sub DoubleClick(sender As Object, e As EventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    If WasGridRowClicked(sender) Then
                        tagBits.FrmInstruments.EditClick()
                    End If
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    Dim instrument As CInstrument = GetInstrumentFromRow(e.Row)
                    e.Row.CellAppearance.ForeColor = CColours.InstrumentType(instrument.InstrumentType)

                    Dim rAmountHeld = CDatabase.DbToDecimal(e.Row.Cells(Columns.AmountHeld.ToString).Value)

                    If rAmountHeld <> 0 Then
                        e.Row.CellAppearance.FontData.Bold = DefaultableBoolean.True
                    End If

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Function GetInstrumentFromRow(row As UltraGridRow) As CInstrument
                Dim sCode As String = row.Cells(Columns.Code.ToString).Text
                Dim sType As String = row.Cells(Columns.InstrumentTypeCode.ToString).Text
                Dim instrumentType As EInstrumentType = GetInstrumentTypeFromCode(sType, True)
                Dim sDesc As String = row.Cells(Columns.Description.ToString).Text
                Dim rRate As Decimal = CDec(row.Cells(Columns.Rate.ToString).Value)
                Dim rateUpdated As Date? = Nothing
                If Not IsDBNull(row.Cells(Columns.RateUpdated.ToString).Value) Then
                    rateUpdated = CType(row.Cells(Columns.RateUpdated.ToString).Value, Date)
                End If
                Dim sLinkSymbol As String = row.Cells(Columns.LinkSymbol.ToString).Text
                Dim sCurrencyCode As String = row.Cells(Columns.CurrencyCode.ToString).Text
                Dim rProviderMultiplier As Decimal = CDec(row.Cells(Columns.ProviderMultiplier.ToString).Value)
                Dim sNotes = row.Cells(Columns.Notes.ToString).Text
                Dim sHedgingGroupCode = row.Cells(Columns.HedgingGroupCode.ToString).Text
                Dim instrument As New CInstrument(sCode, instrumentType, sDesc, rRate, rateUpdated, sLinkSymbol,
                                                  sCurrencyCode, rProviderMultiplier, sNotes, sHedgingGroupCode)
                Return instrument
            End Function

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .AllowAddNew = AllowAddNew.No
                        .HeaderClickAction = HeaderClickAction.SortMulti
                        .RowSelectors = Infragistics.Win.DefaultableBoolean.False
                        .CellClickAction = CellClickAction.RowSelect
                        .SelectTypeCol = SelectType.None
                        .SelectTypeRow = SelectType.Extended
                        .HeaderClickAction = HeaderClickAction.SortMulti
                    End With
                    e.Layout.AutoFitColumns = True
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        col.CellActivation = Activation.NoEdit
                        Select Case col.Key
                            Case Columns.Code.ToString
                                col.Header.Caption = "Code"
                                col.Width = 80
                                col.Case = [Case].Upper
                                col.CellActivation = Activation.ActivateOnly
                                col.TabStop = False
                            'Case Columns.InstrumentTypeCode.ToString
                            '    col.Header.Caption = "Type"
                            '    col.Width = 30
                            '    col.ValueList = tagBits.DrpInstrumentTypes
                            Case Columns.Description.ToString
                                col.Header.Caption = "Description"
                                col.Width = 200
                            Case Columns.InstrumentTypeDesc.ToString
                                col.Header.Caption = "Type"
                                col.Width = 100
                            Case Columns.LinkSymbol.ToString
                                col.Header.Caption = "Link"
                                col.Width = 50
                            Case Columns.AmountHeld.ToString
                                col.Header.Caption = "Held"
                                col.Width = 50
                                col.Format = FORMAT_QUANTITY
                            Case Columns.CurrencyCode.ToString
                                col.Header.Caption = "Cur"
                                col.Width = 20
                            Case Columns.Rate.ToString
                                col.Header.Caption = "Rate"
                                col.Width = 80
                                col.Format = FORMAT_RATE
                            Case Columns.RateUpdated.ToString
                                col.Header.Caption = "Updated"
                                col.Width = 80
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                            Case Columns.LocalCurrencyBalance.ToString
                                col.Header.Caption = GetLocalCurrencyName()
                                col.Width = 80
                                col.Format = "c2"
                                col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                            Case Columns.HedgingGroupCode.ToString
                                col.Header.Caption = "Hg"
                                col.Width = 35
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
                dt.Columns.Add(Columns.Code.ToString)
                dt.Columns.Add(Columns.InstrumentTypeCode.ToString)
                dt.Columns.Add(Columns.InstrumentTypeDesc.ToString)
                dt.Columns.Add(Columns.Description.ToString)
                dt.Columns.Add(Columns.AmountHeld.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Rate.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.RateUpdated.ToString, GetType(Date))
                dt.Columns.Add(Columns.LinkSymbol.ToString)
                dt.Columns.Add(Columns.LocalCurrencyBalance.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.CurrencyCode.ToString)
                dt.Columns.Add(Columns.ProviderMultiplier.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Notes.ToString)
                dt.Columns.Add(Columns.HedgingGroupCode.ToString)
                Return dt
            End Function

            Friend Shared Function GetSelectedInstruments(grid As UltraGrid) As IEnumerable(Of CInstrument)
                Dim col As New Collection(Of CInstrument)
                For Each row In grid.Selected.Rows
                    Dim instrument = GetInstrumentFromRow(row)
                    col.Add(instrument)
                Next
                Return col
            End Function
        End Class
        Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
            Try
                Using frmNewInstrument As New FNewInstrument(m_commonObjects, Nothing)
                    frmNewInstrument.ShowDialog()
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
            Dim selected As IEnumerable(Of CInstrument) = GridHelper.GetSelectedInstruments(GrdInstruments)
            If selected.Count <> 1 Then
                Throw New Exception(My.Resources.Error_SelectOneItemOnly)
            End If
            Dim instrument = selected.First
            Dim frmInstrument As FInstrument = Nothing
            For Each frm As Form In m_commonObjects.FrmMdi.MdiChildren
                If TypeOf frm Is FInstrument Then
                    Dim fTest = CType(frm, FInstrument)
                    If fTest.InstrumentCode.Equals(instrument.Code, StringComparison.CurrentCultureIgnoreCase) Then
                        frmInstrument = fTest
                        Exit For
                    End If
                End If
            Next
            If frmInstrument Is Nothing Then
                frmInstrument = New FInstrument(m_commonObjects, instrument.Code) With {
                    .MdiParent = m_commonObjects.FrmMdi
                }
                frmInstrument.Show()
            End If
            frmInstrument.Activate()
        End Sub

        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
            Try
                Dim selected = GridHelper.GetSelectedInstruments(GrdInstruments)
                If Not selected.Any Then
                    Throw New Exception(My.Resources.Error_NoRowsSelected)
                End If

                m_commonObjects.Instruments.ValidateDelete(selected)

                If MessageBox.Show($"Delete {selected.Count} instrument{IIf(selected.Count > 1, "s", String.Empty)}?",
                                   Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    m_commonObjects.Instruments.Delete(selected)
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub RefreshData() Implements IDataRefresh.RefreshData
            LoadData()
        End Sub
    End Class
End Namespace
