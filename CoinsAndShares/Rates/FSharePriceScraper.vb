﻿Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Transactions
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Namespace Rates
    Friend Class FSharePriceScraper
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_fStop As Boolean
        Friend Sub New(commonObjects As CCommonObjects)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            Icon = Icon.FromHandle(My.Resources.wand.GetHicon)
            LoadData()
        End Sub

        Private Sub LoadData()

            Dim allTransactions = m_commonObjects.Transactions.GetAll
            Dim allInstruments = m_commonObjects.Instruments.GetAll
            Dim allCurrencies = m_commonObjects.Currencies.GetAll

            Dim analysis = CTransactions.Analyse(allTransactions, allInstruments, allCurrencies)

            Dim ratesToUpdate As New List(Of RateToUpdate)

            For Each instrumentAnalysis In analysis.InstrumentAnalysis().Where(Function(c) c.CurrentHolding > 0)
                Dim instrument = allInstruments.FirstOrDefault(Function(c) c.Code.Equals(instrumentAnalysis.InstrumentCode, StringComparison.CurrentCultureIgnoreCase))
                If instrument IsNot Nothing AndAlso instrument.InstrumentType = EInstrumentType.Share Then

                    Dim rateToUpdate = New RateToUpdate(instrument, instrumentAnalysis)
                    ratesToUpdate.Add(rateToUpdate)

                End If
            Next

            ' Sort
            GridHelper.LoadData(GrdInstruments, ratesToUpdate.OrderBy(Function(c) c.Instrument.Code), m_commonObjects, Me)

            ChangesMade(False)
        End Sub
        Private Sub ChangesMade(f As Boolean)
            If f Then
                BtnCommit.BackColor = Color.Red
                BtnCommit.ForeColor = Color.Yellow
            Else
                BtnCommit.BackColor = SystemColors.ButtonFace
                BtnCommit.ForeColor = SystemColors.WindowText
            End If
        End Sub

        Friend Class RateToUpdate
            Friend Sub New(instrument As CInstrument, instrumentAnalysis As CInstrumentAnalysis)
                Me.Instrument = instrument
                Me.instrumentAnalysis = instrumentAnalysis
            End Sub
            Friend Property Instrument As CInstrument
            Friend Property InstrumentAnalysis As CInstrumentAnalysis
        End Class

        Friend Class GridHelper
            Private Enum Columns
                Code
                Description
                ProviderMultiplier
                ProviderLinkCode
                CurrentHolding
                RateUpdated
                ExistingPrice
                NewPrice

                CurrentValue
                NewValue
                Difference

                UpdateButton
            End Enum
            Private Class LocalTagBits : Inherits TagBits
                Friend ReadOnly Property HostForm As FSharePriceScraper
                Friend Sub New(commonObjects As CCommonObjects, hostForm As FSharePriceScraper)
                    MyBase.New(commonObjects)
                    Me.HostForm = hostForm
                End Sub
            End Class
            Friend Shared Sub LoadData(grid As UltraGrid, ratesToUpdate As IEnumerable(Of RateToUpdate), commonObjects As CCommonObjects, hostForm As FSharePriceScraper)
                grid.Tag = New LocalTagBits(commonObjects, hostForm)
                Dim dt = GetBlankDt()
                RemoveHandler grid.InitializeRow, AddressOf InitializeRow
                AddHandler grid.InitializeRow, AddressOf InitializeRow
                For Each rateToUpdate In ratesToUpdate
                    Dim dr = dt.NewRow
                    dr(Columns.Code.ToString) = rateToUpdate.Instrument.Code
                    dr(Columns.Description.ToString) = rateToUpdate.Instrument.Description
                    dr(Columns.ProviderMultiplier.ToString) = rateToUpdate.Instrument.ProviderMultiplier
                    dr(Columns.ProviderLinkCode.ToString) = rateToUpdate.Instrument.ProviderLinkCode
                    dr(Columns.CurrentHolding.ToString) = rateToUpdate.InstrumentAnalysis.CurrentHolding
                    If rateToUpdate.Instrument.RateUpdated.HasValue Then
                        dr(Columns.RateUpdated.ToString) = rateToUpdate.Instrument.RateUpdated.Value
                    End If
                    dr(Columns.ExistingPrice.ToString) = rateToUpdate.Instrument.Rate

                    dt.Rows.Add(dr)
                Next
                RemoveHandler grid.InitializeLayout, AddressOf InitializeLayout
                AddHandler grid.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler grid.KeyDown, AddressOf KeyDown
                AddHandler grid.KeyDown, AddressOf KeyDown
                RemoveHandler grid.ClickCellButton, AddressOf ClickCellButton
                AddHandler grid.ClickCellButton, AddressOf ClickCellButton
                RemoveHandler grid.AfterCellUpdate, AddressOf AfterCellUpdate
                AddHandler grid.AfterCellUpdate, AddressOf AfterCellUpdate
                grid.DataSource = dt
            End Sub

            Private Shared Sub AfterCellUpdate(sender As Object, e As CellEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As LocalTagBits = CType(grid.Tag, LocalTagBits)
                Try
                    tagBits.HostForm.ChangesMade(True)
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub ClickCellButton(sender As Object, e As CellEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    Dim sSymbol = e.Cell.Row.Cells(Columns.ProviderLinkCode.ToString).Text
                    If String.IsNullOrEmpty(sSymbol) Then
                        Throw New Exception(My.Resources.Error_InstrumentContainsNoSymbol)
                    End If
                    Dim rateProvider = GetRateProviderToUse(EInstrumentType.Share)
                    Dim symbols As New List(Of String) From {
                        sSymbol
                    }
                    tagBits.CommonObjects.FrmMdi.Cursor = Cursors.WaitCursor
                    Dim rates = rateProvider.GetNewRates(symbols)
                    If rates IsNot Nothing AndAlso rates.Any Then
                        Dim cNewPrice = rates.First.Rate
                        Dim rMult = CDec(e.Cell.Row.Cells(Columns.ProviderMultiplier.ToString).Value)
                        If rMult > 0 Then
                            cNewPrice *= rMult
                        End If
                        e.Cell.Row.Cells(Columns.NewPrice.ToString).Value = cNewPrice
                        e.Cell.Row.Update()
                    End If
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                Finally
                    tagBits.CommonObjects.FrmMdi.Cursor = Cursors.Default
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

            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    Dim rHolding = CDec(e.Row.Cells(Columns.CurrentHolding.ToString).Value)
                    Dim cOldPrice = CDec(e.Row.Cells(Columns.ExistingPrice.ToString).Value)
                    Dim cOldValue = rHolding * cOldPrice
                    e.Row.Cells(Columns.CurrentValue.ToString).Value = cOldValue

                    If IsDBNull(e.Row.Cells(Columns.NewPrice.ToString).Value) Then
                        e.Row.Cells(Columns.NewValue.ToString).Value = DBNull.Value
                        e.Row.Cells(Columns.Difference.ToString).Value = DBNull.Value
                    Else
                        Dim cNewPrice = CDec(e.Row.Cells(Columns.NewPrice.ToString).Value)
                        Dim cNewValue = rHolding * cNewPrice
                        e.Row.Cells(Columns.NewValue.ToString).Value = cNewValue

                        Dim cDifference = cNewValue - cOldValue
                        e.Row.Cells(Columns.Difference.ToString).Value = cDifference
                    End If

                    ' Colour difference
                    Dim cDiff As Decimal
                    If Not IsDBNull(e.Row.Cells(Columns.Difference.ToString).Value) Then
                        cDiff = CDec(e.Row.Cells(Columns.Difference.ToString).Value)
                    End If
                    Dim diffForeColour As Color = Color.Black
                    If cDiff < 0 Then
                        diffForeColour = Color.Red
                    ElseIf cDiff > 0 Then
                        diffForeColour = Color.Green
                    End If
                    e.Row.Cells(Columns.Difference.ToString).Appearance.ForeColor = diffForeColour

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub

            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim COLOUR_EXISTING As Color = Color.DarkBlue
                Dim COLOUR_NEW As Color = Color.Blue
                Const FORMAT_PRICE = "0.######"
                Const FORMAT_MONEY = "c2"
                Const PRICE_WIDTH = 65
                Const MONEY_WIDTH = 65
                Dim grid As UltraGrid = CType(sender, UltraGrid)
                Dim tagBits As TagBits = CType(grid.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    With e.Layout.Override
                        .RowSelectors = DefaultableBoolean.False
                    End With

                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Dim a As Activation = Activation.NoEdit
                        Select Case col.Key
                            Case Columns.Code.ToString
                                col.Header.Caption = "Instrument"
                                col.Width = 75
                                col.CellAppearance.ForeColor = CColours.InstrumentType(EInstrumentType.Share)
                                col.Header.Appearance.ForeColor = CColours.InstrumentType(EInstrumentType.Share)
                            Case Columns.Description.ToString
                                col.Header.Caption = "Description"
                                col.Width = 150
                            Case Columns.ProviderLinkCode.ToString
                                col.Header.Caption = "Symbol"
                                col.Width = 50
                            Case Columns.CurrentHolding.ToString
                                col.Header.Caption = "Holding"
                                col.Width = 55
                                col.Format = "0.######"
                            Case Columns.RateUpdated.ToString
                                col.Header.Caption = "Updated"
                                col.Width = 85
                                col.Format = "dd/MM/yy HH:mm"
                            Case Columns.ExistingPrice.ToString
                                col.Header.Caption = "Old Price"
                                col.Width = PRICE_WIDTH
                                col.CellAppearance.ForeColor = COLOUR_EXISTING
                                col.Header.Appearance.ForeColor = COLOUR_EXISTING
                                col.Format = FORMAT_PRICE
                            Case Columns.NewPrice.ToString
                                col.Header.Caption = "New Price"
                                col.Width = PRICE_WIDTH
                                col.CellAppearance.ForeColor = COLOUR_NEW
                                col.Header.Appearance.ForeColor = COLOUR_NEW
                                col.Format = FORMAT_PRICE
                                a = Activation.AllowEdit
                            Case Columns.CurrentValue.ToString
                                col.Header.Caption = "Old Value"
                                col.Width = MONEY_WIDTH
                                col.CellAppearance.ForeColor = COLOUR_EXISTING
                                col.Header.Appearance.ForeColor = COLOUR_EXISTING
                                col.Format = FORMAT_MONEY
                                col.CellAppearance.TextHAlign = HAlign.Right
                            Case Columns.NewValue.ToString
                                col.Header.Caption = "New Value"
                                col.Width = MONEY_WIDTH
                                col.CellAppearance.ForeColor = COLOUR_NEW
                                col.Header.Appearance.ForeColor = COLOUR_NEW
                                col.Format = FORMAT_MONEY
                                col.CellAppearance.TextHAlign = HAlign.Right
                            Case Columns.Difference.ToString
                                col.Header.Caption = "Diff"
                                col.Width = MONEY_WIDTH
                                col.Format = FORMAT_MONEY
                                col.CellAppearance.TextHAlign = HAlign.Right
                            Case Columns.UpdateButton.ToString
                                col.Header.Caption = String.Empty
                                col.Header.Appearance.Image = My.Resources.wand
                                col.Header.Appearance.ImageHAlign = HAlign.Center
                                col.Width = 22
                                col.Style = ColumnStyle.Button
                                col.ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                            Case Else
                                col.Hidden = True
                        End Select
                        col.CellActivation = a
                    Next

                    e.Layout.Bands(0).Summaries.Clear()

                    With e.Layout.Bands(0).Summaries.Add(SummaryType.Sum, e.Layout.Bands(0).Columns(Columns.Difference.ToString))
                        '.DisplayFormat = "{0:#,##0.00}"
                        .DisplayFormat = "£{0:#,##0.00}"
                        .Appearance.TextHAlign = HAlign.Right
                        .Appearance.BackColor = Color.White
                    End With


                    'With e.Layout.Bands(0).Summaries.Add("summaryKey", SummaryType.Sum, e.Layout.Bands(0).Columns(Columns.Difference.ToString))
                    '    e.Layout.Bands(0).Summaries("summaryKey").DisplayFormat = "0.00"
                    e.Layout.Bands(0).Override.SummaryFooterCaptionVisible = DefaultableBoolean.False

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Function GetBlankDt() As DataTable
                Dim dt = New DataTable
                dt.Columns.Add(Columns.Code.ToString)
                dt.Columns.Add(Columns.Description.ToString)
                dt.Columns.Add(Columns.ProviderMultiplier.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.ProviderLinkCode.ToString)
                dt.Columns.Add(Columns.CurrentHolding.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.RateUpdated.ToString, GetType(Date))
                dt.Columns.Add(Columns.ExistingPrice.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.NewPrice.ToString, GetType(Decimal))

                dt.Columns.Add(Columns.CurrentValue.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.NewValue.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Difference.ToString, GetType(Decimal))

                dt.Columns.Add(Columns.UpdateButton.ToString)

                Return dt
            End Function

            Friend Shared Function GetUpdatesRequired(grid As UltraGrid) As IEnumerable(Of CRate)
                ' Return the instrument code and new rate entered for only the rows entered
                grid.UpdateData()
                Dim updates As New List(Of CRate)
                For Each row As UltraGridRow In grid.Rows
                    If Not IsDBNull(row.Cells(Columns.NewPrice.ToString).Value) Then
                        Dim cRate = CDec(row.Cells(Columns.NewPrice.ToString).Value)
                        If cRate <= 0 Then
                            Throw New Exception(My.Resources.Error_RateNotValid)
                        End If
                        Dim sCode = row.Cells(Columns.Code.ToString).Text
                        Dim r = New CRate(sCode, cRate)
                        updates.Add(r)
                    End If
                Next
                Return updates
            End Function

            Friend Shared Function GetScrapesRequired(grid As UltraGrid) As IEnumerable(Of String)
                ' Get the list of link codes in order of oldest updated to newest
                Dim all As New List(Of Tuple(Of String, Date))
                For Each row As UltraGridRow In grid.Rows
                    If row.Cells(Columns.ProviderLinkCode.ToString).Text.Length > 0 Then
                        Dim dt As Date
                        If IsDBNull(row.Cells(Columns.RateUpdated.ToString).Value) Then
                            dt = CDate("1/1/1900")
                        Else
                            dt = CDate(row.Cells(Columns.RateUpdated.ToString).Value)
                        End If
                        all.Add(New Tuple(Of String, Date)(row.Cells(Columns.ProviderLinkCode.ToString).Text, dt))
                    End If
                Next
                Dim codes = all.OrderBy(Function(c) c.Item2).Select(Function(c) c.Item1).Distinct
                Return codes
            End Function

            Friend Shared Sub SetScrapedRate(grid As UltraGrid, sLinkCode As String, rate As Decimal)
                If rate <= 0 Then
                    Throw New Exception(My.Resources.Error_RateNotValid)
                End If
                For Each row As UltraGridRow In grid.Rows
                    If row.Cells(Columns.ProviderLinkCode.ToString).Text.Equals(sLinkCode, StringComparison.CurrentCultureIgnoreCase) Then
                        Dim rMult As Decimal = 0
                        If Not IsDBNull(row.Cells(Columns.ProviderMultiplier.ToString).Value) Then
                            rMult = CDec(row.Cells(Columns.ProviderMultiplier.ToString).Value)
                        End If
                        Dim rRateToUse = rate
                        If rMult > 0 Then
                            rRateToUse *= rMult
                        End If
                        row.Cells(Columns.NewPrice.ToString).Value = rRateToUse
                        row.Update()
                    End If
                Next
            End Sub
        End Class

        Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
            Try
                Dim sMsg = "Reload data?  Uncommitted new prices entered will be lost"
                If MessageBox.Show(sMsg, Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    LoadData()
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnCommit_Click(sender As Object, e As EventArgs) Handles BtnCommit.Click
            Try
                Dim updatesRequired = GridHelper.GetUpdatesRequired(GrdInstruments)
                If Not updatesRequired.Any Then
                    Throw New Exception(My.Resources.Error_NothingToDo)
                End If
                Dim sMsg = $"Update {updatesRequired.Count} price{IIf(updatesRequired.Count > 1, "s", String.Empty)}?  (Blank ones will be left as they are)"
                If MessageBox.Show(sMsg, Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim instruments = m_commonObjects.Instruments
                    instruments.StoreNewRates(updatesRequired)
                    LoadData()
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnScrape_Click(sender As Object, e As EventArgs) Handles BtnScrape.Click
            Try
                Dim linkCodes = GridHelper.GetScrapesRequired(GrdInstruments)

                Dim sMsg = $"Begin scraping {linkCodes.Count} instrument{IIf(linkCodes.Count > 1, "s", String.Empty)} from oldest update to newest?"
                If MessageBox.Show(sMsg, Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    m_fStop = False
                    Dim rateProvider = GetRateProviderToUse(EInstrumentType.Share)

                    For Each sLinkCode In linkCodes
                        Application.DoEvents()

                        If m_fStop Then
                            Exit For
                        End If

                        Dim codes As New List(Of String) From {
                            sLinkCode
                        }
                        Dim newRates = rateProvider.GetNewRates(codes)
                        If newRates IsNot Nothing AndAlso newRates.Any Then
                            GridHelper.SetScrapedRate(GrdInstruments, sLinkCode, newRates.First.Rate)
                        End If
                    Next

                    If m_fStop Then
                        MessageBox.Show("Process stopped", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Process completed", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
            Try
                m_fStop = True
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

    End Class
End Namespace
