Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Instruments.MInstuments
Imports CoinsAndShares.Settings
Imports CoinsAndShares.Transactions

Namespace Dashboard
    Friend Class UHoldings : Implements IDashboardPanel

        Const FONT_SIZE = 7

        Private Const _PADDING As Integer = 5

        Private m_commonObjects As CCommonObjects

        Private m_settings As CSettings

        Private m_allInstruments As IEnumerable(Of CInstrument)

        Private m_analysis As CTransactionAnalyserResult

        Private Enum EContextMenuItems
            Set_Rate
            Edit_Instrument
        End Enum

        Private ReadOnly m_mouseClickAreas As New List(Of Tuple(Of RectangleF, CInstrument))
        Private m_contextMenuItem As Tuple(Of RectangleF, CInstrument)

        Friend Sub RefreshData() Implements IDashboardPanel.RefreshData
            LoadData()
        End Sub

        Friend Sub Initialise(commonObjects As CCommonObjects) Implements IDashboardPanel.Initialise

            m_commonObjects = commonObjects

            LoadData()

        End Sub

        Private Sub LoadData()

            Dim allTransactions = m_commonObjects.Transactions.GetAll().ToList
            m_allInstruments = m_commonObjects.Instruments.GetAll().ToList
            Dim allCurrencies = m_commonObjects.Currencies.GetAll().ToList
            m_settings = New CSettings(m_commonObjects)
            m_analysis = CTransactions.Analyse(allTransactions, m_allInstruments, allCurrencies)

            ' Redraw
            Invalidate()

        End Sub

        Private Sub UHoldings_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

            Const HEADING = "HOLDINGS"

            If m_commonObjects Is Nothing Then
                ' Initialise not called yet.  Will only happen at runtime
                Return
            End If

            m_mouseClickAreas.Clear()

            Using boldFont As New Font(Font, FontStyle.Bold)
                Using blackBrush As New SolidBrush(Color.Black)

                    Dim szf = e.Graphics.MeasureString(HEADING, boldFont)
                    Dim r = New RectangleF(New PointF(_PADDING, _PADDING), szf)
                    e.Graphics.DrawString(HEADING, boldFont, blackBrush, r)

                    Dim y As Single = r.Bottom + _PADDING

                    ' y = DrawAssetType(e.Graphics, Nothing, y)
                    y = DrawAssetType(e.Graphics, EInstrumentType.Crypto, y)
                    y = DrawAssetType(e.Graphics, EInstrumentType.Share, y)

                    Height = CInt(y)
                End Using
            End Using

        End Sub

        Private Function DrawAssetType(g As Graphics, instrumentType As EInstrumentType?, top As Single) As Single

            ' Output the specified asset type working from "top" down.  Return the new bottom

            Dim y = top

            Dim sTitle As String
            Dim assetColor As Color
            If instrumentType Is Nothing Then
                sTitle = GetLocalCurrencyName()
                assetColor = CColours.AccountType(Accounts.EAccountType.Bank_Account)
            Else
                sTitle = instrumentType.Value.ToString
                assetColor = CColours.InstrumentType(instrumentType.Value)
            End If

            Dim warningIcon As Icon = Icon.FromHandle(My.Resources.exclamation.GetHicon)

            Font = New Font(Font.FontFamily, FONT_SIZE)

            Using sfNoClip As New StringFormat(StringFormatFlags.LineLimit Or StringFormatFlags.NoWrap Or StringFormatFlags.NoClip) With {
                .Trimming = StringTrimming.None
            }

                Using assetBrush As New SolidBrush(assetColor)
                    Using boldFont = New Font(Font, FontStyle.Bold)
                        Using headingFont = New Font(Font, FontStyle.Bold Or FontStyle.Underline)

                            ' Type heading
                            Dim szf = g.MeasureString(sTitle, boldFont)
                            Dim rowRectF = New RectangleF(New PointF(_PADDING, y), New SizeF(g.VisibleClipBounds.Width - 2 * _PADDING, szf.Height))
                            g.DrawString(sTitle, headingFont, assetBrush, rowRectF, sfNoClip)

                            Dim instrumentAnalysis = If(m_analysis Is Nothing, New List(Of CInstrumentAnalysis), m_analysis.InstrumentAnalysis)

                            ' Currency boxes
                            Using currencyBoxFormat As New StringFormat With {
                                        .Alignment = StringAlignment.Far
                                    }

                                Dim currencyBoxSize As SizeF = g.MeasureString(FormatCurrency(CDec(10000)), Font)

                                ' Current Worth Heading
                                Dim currencyBoxF = New RectangleF(New PointF(rowRectF.Right - currencyBoxSize.Width * 2, rowRectF.Top), currencyBoxSize)
                                g.DrawString("Current", headingFont, assetBrush, currencyBoxF, currencyBoxFormat)

                                ' P/L Worth Heading
                                currencyBoxF = New RectangleF(New PointF(rowRectF.Right - currencyBoxSize.Width, rowRectF.Top), currencyBoxSize)
                                g.DrawString("P/L", headingFont, assetBrush, currencyBoxF, currencyBoxFormat)

                                y = rowRectF.Bottom

                                Dim cTotalCurrentWorth As Decimal
                                Dim cCurrentButHiddenPl As Decimal
                                Dim cTotalPl As Decimal
                                For Each a In instrumentAnalysis.OrderByDescending(Function(c) c.CurrentWorth)
                                    Dim fOutputRow As Boolean = False ' If correct type
                                    Dim sInstrumentName As String = String.Empty
                                    Dim fDisplayRateWarning As Boolean = False
                                    Dim i As CInstrument = Nothing

                                    If instrumentType.HasValue Then
                                        'If a.CurrentHolding <> 0 Then
                                        If True Then
                                            i = m_allInstruments.Where(Function(c) c.Code.Equals(a.InstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                                            If i IsNot Nothing Then
                                                fOutputRow = i.InstrumentType.Equals(instrumentType.Value)
                                                If fOutputRow Then
                                                    sInstrumentName = i.Description
                                                    Dim iHoursWarning = If(m_settings.RateUpdateWarningHours, 24)
                                                    fDisplayRateWarning = Not i.RateUpdated.HasValue OrElse i.RateUpdated.Value < Now.AddHours(iHoursWarning * -1)
                                                End If
                                            End If
                                        End If
                                    Else
                                        fOutputRow = String.IsNullOrEmpty(a.InstrumentCode)
                                        If fOutputRow Then
                                            sInstrumentName = GetLocalCurrencyName()
                                        End If
                                    End If

                                    If fOutputRow Then
                                        Dim fs As FontStyle = FontStyle.Regular
                                        Using instrumentFont = New Font(Font, fs)
                                            If a.CurrentWorth > 0.01 Then
                                                szf = g.MeasureString(sInstrumentName, Font)

                                                rowRectF = New RectangleF(New PointF(_PADDING, y), New SizeF(g.VisibleClipBounds.Width - 2 * _PADDING, szf.Height))

                                                ' Draw warning triangle
                                                If fDisplayRateWarning Then
                                                    g.DrawIcon(warningIcon, CInt(rowRectF.Location.X), CInt(rowRectF.Location.Y))
                                                End If

                                                ' Rate name
                                                Dim r = New RectangleF(New PointF(_PADDING + warningIcon.Width, y), szf)
                                                m_mouseClickAreas.Add(New Tuple(Of RectangleF, CInstrument)(r, i))
                                                g.DrawString(sInstrumentName, instrumentFont, assetBrush, r, sfNoClip)

                                                ' Draw box over the two currency columns to make sure long name doesn't spread over
                                                Using bb = New SolidBrush(BackColor)
                                                    g.FillRectangle(bb, rowRectF.Right - currencyBoxSize.Width * 2, rowRectF.Top, currencyBoxSize.Width * 2, rowRectF.Height)
                                                End Using

                                                ' Current Worth
                                                currencyBoxF = New RectangleF(New PointF(rowRectF.Right - currencyBoxSize.Width * 2, rowRectF.Top), currencyBoxSize)
                                                g.DrawString(FormatCurrency(a.CurrentWorth), instrumentFont, assetBrush, currencyBoxF, currencyBoxFormat)

                                                ' PL - Not for sterling though
                                                If instrumentType.HasValue Then
                                                    currencyBoxF = New RectangleF(New PointF(rowRectF.Right - currencyBoxSize.Width, rowRectF.Top), currencyBoxSize)
                                                    g.DrawString(FormatCurrency(a.Pl), instrumentFont, assetBrush, currencyBoxF, currencyBoxFormat)
                                                End If
                                            Else
                                                cCurrentButHiddenPl += a.Pl

                                            End If

                                        End Using

                                        ' Compile totals
                                        cTotalCurrentWorth += a.CurrentWorth
                                        cTotalPl += a.Pl

                                        y = rowRectF.Bottom

                                    End If
                                Next

                                ' Total of hidden items (with no current value)
                                If cCurrentButHiddenPl <> 0 Then
                                    rowRectF = New RectangleF(New PointF(_PADDING + warningIcon.Width, y), New SizeF(g.VisibleClipBounds.Width - 2 * _PADDING, szf.Height))
                                    g.DrawString("Sold", Font, assetBrush, rowRectF)

                                    '' Total Current Worth
                                    'currencyBoxF = New RectangleF(New PointF(rowRectF.Right - currencyBoxSize.Width * 2, rowRectF.Top), currencyBoxSize)
                                    'g.DrawString(FormatCurrency(cTotalCurrentWorth), boldFont, assetBrush, currencyBoxF, currencyBoxFormat)

                                    ' Total PL
                                    currencyBoxF = New RectangleF(New PointF(rowRectF.Right - warningIcon.Width - currencyBoxSize.Width, rowRectF.Top), currencyBoxSize)
                                    g.DrawString(FormatCurrency(cCurrentButHiddenPl), Font, assetBrush, currencyBoxF, currencyBoxFormat)

                                    y = rowRectF.Bottom
                                End If

                                ' Total Row - Not for sterling though
                                If instrumentType.HasValue Then
                                    rowRectF = New RectangleF(New PointF(_PADDING, y), New SizeF(g.VisibleClipBounds.Width - 2 * _PADDING, szf.Height))
                                    g.DrawString("Exc Fees/Bonus/Div", boldFont, assetBrush, rowRectF)

                                    ' Total Current Worth
                                    currencyBoxF = New RectangleF(New PointF(rowRectF.Right - currencyBoxSize.Width * 2, rowRectF.Top), currencyBoxSize)
                                    g.DrawString(FormatCurrency(cTotalCurrentWorth), boldFont, assetBrush, currencyBoxF, currencyBoxFormat)

                                    ' Total PL
                                    currencyBoxF = New RectangleF(New PointF(rowRectF.Right - currencyBoxSize.Width, rowRectF.Top), currencyBoxSize)
                                    g.DrawString(FormatCurrency(cTotalPl), boldFont, assetBrush, currencyBoxF, currencyBoxFormat)

                                    y = rowRectF.Bottom
                                End If
                            End Using

                        End Using
                    End Using
                End Using
            End Using

            Return y

        End Function

        Private Sub UHoldings_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            Try
                Dim m = m_mouseClickAreas.Where(Function(c) c.Item1.Contains(e.Location)).FirstOrDefault
                Cursor = If(m IsNot Nothing AndAlso m.Item2 IsNot Nothing, Cursors.Hand, Cursors.Default)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub UHoldings_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

            Try
                m_contextMenuItem = m_mouseClickAreas.Where(Function(c) c.Item1.Contains(e.Location)).FirstOrDefault

                Select Case e.Button
                    Case MouseButtons.Left
                        If m_contextMenuItem IsNot Nothing AndAlso m_contextMenuItem.Item2 IsNot Nothing Then
                            FInstrument.Launch(m_commonObjects, m_contextMenuItem.Item2.Code)
                        End If

                    Case MouseButtons.Right
                        If m_contextMenuItem IsNot Nothing AndAlso m_contextMenuItem.Item2 IsNot Nothing Then
                            Cms.Show(Me, e.Location)
                        End If

                End Select

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub MnuEditInstrument_Click(sender As Object, e As EventArgs) Handles MnuEditInstrument.Click
            Try
                If m_contextMenuItem IsNot Nothing Then
                    Cursor = Cursors.WaitCursor
                    FInstrument.Launch(m_commonObjects, m_contextMenuItem.Item2.Code)
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

    End Class

End Namespace


