Imports System.Globalization
Imports CoinsAndShares.Currencies

Namespace Dashboard
    Friend Class UCurrency : Implements IDashboardPanel

        Private m_currencyRateApi As ICurrencyRateApi

        Private m_commonObjects As CCommonObjects

        Private m_currenciesToShow As New List(Of CCurrencyDetail)

        Private m_rateBoxes As List(Of CRateBox)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private NotInheritable Class CRateBox
            Friend Sub New(rect As Rectangle, currencyDetail As CCurrencyDetail)
                Me.Rect = rect
                Me.CurrencyDetail = currencyDetail
            End Sub
            Friend ReadOnly Property Rect As Rectangle
            Friend ReadOnly Property CurrencyDetail As CCurrencyDetail
        End Class

        Friend Sub LoadData()

            ' Get list of ISO codes to show based of what's been used in the Instruments already set up
            Dim currencyCodesToShow As List(Of String)
            If m_commonObjects.Instruments Is Nothing Then
                currencyCodesToShow = New List(Of String)
            Else
                Dim sLocalIso = GetLocalCurrencyIso()
                currencyCodesToShow = New List(Of String)(
                    m_commonObjects.Instruments.GetAll.Where(Function(c)
                                                                 Return Not String.IsNullOrEmpty(c.CurrencyCode) AndAlso Not c.CurrencyCode.Equals(sLocalIso, StringComparison.CurrentCulture)
                                                             End Function).Select(Function(c) c.CurrencyCode).Distinct
                    )
            End If

            If m_commonObjects.Currencies Is Nothing Then
                m_currenciesToShow = New List(Of CCurrencyDetail)
            Else
                m_currenciesToShow = New List(Of CCurrencyDetail)(
                    m_commonObjects.Currencies.GetAll().Where(Function(c)
                                                                  Return currencyCodesToShow.Where(Function(d) d.Equals(c.CurrencyCode, StringComparison.CurrentCultureIgnoreCase)).Any
                                                              End Function)
                    )
            End If

            Invalidate()

        End Sub

        Private Sub UCurrency_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

            Const PADDING As Integer = 5

            If m_commonObjects Is Nothing Then
                ' Not initialised yet.  Will only happen at runtime
                Return
            End If

            m_rateBoxes = New List(Of CRateBox)

            e.Graphics.Clear(Color.WhiteSmoke)

            Dim normalFont = Font
            Using boldFont = New Font(Font, FontStyle.Bold)
                Using ulFont = New Font(Font, FontStyle.Underline)
                    Dim firstRowY = PnlControl.Height + PADDING
                    Dim y = firstRowY
                    Using blackBrush = New SolidBrush(Color.Black)
                        Using blueBrush = New SolidBrush(Color.Blue)
                            Dim rowHeight = CInt(e.Graphics.MeasureString("XXX", normalFont).Height)
                            Dim x = PADDING
                            Dim maxwidth As Integer

                            maxwidth = 0
                            y = firstRowY
                            For Each currencyToShow In m_currenciesToShow
                                Dim s = currencyToShow.CurrencyCode
                                Dim sz = e.Graphics.MeasureString(s, boldFont)
                                Dim r As New Rectangle(x, y, CInt(sz.Width), CInt(sz.Height))
                                e.Graphics.DrawString(s, boldFont, blackBrush, r)
                                maxwidth = CInt(Math.Max(maxwidth, r.Width))
                                y += rowHeight
                            Next
                            x += maxwidth + PADDING

                            maxwidth = 0
                            y = firstRowY
                            For Each currencyToShow In m_currenciesToShow
                                Dim s = currencyToShow.CurrencyRate.ToString
                                Dim sz = e.Graphics.MeasureString(s, ulFont)
                                Dim r As New Rectangle(x, y, CInt(sz.Width), CInt(sz.Height))
                                e.Graphics.DrawString(s, ulFont, blueBrush, r)
                                m_rateBoxes.Add(New CRateBox(r, currencyToShow))
                                maxwidth = CInt(Math.Max(maxwidth, r.Width))
                                y += rowHeight
                            Next
                            x += maxwidth

                            maxwidth = 0
                            y = firstRowY
                            For Each currencyToShow In m_currenciesToShow
                                Dim s = currencyToShow.CurrencyName
                                Dim sz = e.Graphics.MeasureString(s, boldFont)
                                Dim r As New Rectangle(x, y, CInt(sz.Width), CInt(sz.Height))
                                e.Graphics.DrawString(s, normalFont, blackBrush, r)
                                maxwidth = CInt(Math.Max(maxwidth, r.Width))
                                y += rowHeight
                            Next
                            x += maxwidth + PADDING

                        End Using

                        Height = CInt(y) + PADDING
                    End Using
                End Using
            End Using
        End Sub

        Private Sub BtnUpdateCurrencyRates_Click(sender As Object, e As EventArgs) Handles BtnUpdateCurrencyRates.Click
            Try
                Cursor = Cursors.WaitCursor
                m_commonObjects.Currencies.UpdateRatesFromApi(m_currencyRateApi)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub UCurrency_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
            Try
                Dim rb = m_rateBoxes.Where(Function(c) c.Rect.Contains(e.Location)).FirstOrDefault
                If rb IsNot Nothing Then
                    Dim all = m_commonObjects.Currencies.GetAll

                    Dim currencyDetail = all.Where(Function(c) c.CurrencyCode.Equals(rb.CurrencyDetail.CurrencyCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault

                    If currencyDetail Is Nothing Then
                        Throw New Exception(My.Resources.Error_CurrencyCodeNotValid)
                    End If

                    Dim sRet As String = String.Empty
                    If currencyDetail.CurrencyRate.HasValue Then
                        sRet = currencyDetail.CurrencyRate.Value.ToString(CultureInfo.CurrentCulture)
                    End If
                    sRet = InputBox("Enter new currency rate", Text, sRet)
                    Dim newrate As Decimal
                    If String.IsNullOrEmpty(sRet) Then
                        Return
                    ElseIf Not Decimal.TryParse(sRet, newrate) Then
                        Throw New Exception(My.Resources.Error_RateNotValid)
                    End If

                    Cursor = Cursors.WaitCursor

                    currencyDetail.CurrencyRate = newrate

                    m_commonObjects.Currencies.SaveAll(all)
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub Initialise(commonObjects As CCommonObjects) Implements IDashboardPanel.Initialise

            m_commonObjects = commonObjects

            m_currencyRateApi = GetCurrencyRateApiToUse(commonObjects)
            BtnUpdateCurrencyRates.Text = $"Update From {m_currencyRateApi.GetName}"

            LoadData()

        End Sub

        Friend Sub RefreshData() Implements IDashboardPanel.RefreshData
            LoadData()
        End Sub

        Private Sub UCurrency_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            Try
                Dim m = m_rateBoxes.Where(Function(c) c.Rect.Contains(e.Location)).FirstOrDefault
                If m IsNot Nothing Then
                    Cursor = Cursors.Hand
                Else
                    Cursor = Cursors.Default
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class

End Namespace
