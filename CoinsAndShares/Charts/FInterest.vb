Imports System.Windows.Forms.DataVisualization.Charting

Namespace Charts
    Friend Class FInterest
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            Icon = Icon.FromHandle(My.Resources.chart.GetHicon)

            AddDescriptionButtons()

            TxtFilter.Text = EDescriptionPresets.Interest.ToString

            LoadData()

        End Sub
        Private Sub AddDescriptionButtons()
            For Each b In [Enum].GetValues(GetType(EDescriptionPresets))
                Dim sText = b.ToString.Replace("_", " ")
                Dim btn = New Button With {
                    .Parent = PnlDescriptions,
                    .Text = sText,
                    .Dock = DockStyle.Left,
                    .BackColor = SystemColors.ButtonFace
                }
                AddHandler btn.Click, Sub()
                                          Cursor = Cursors.WaitCursor
                                          Try
                                              TxtFilter.Text = sText
                                              LoadData()
                                          Catch ex As Exception
                                              m_commonObjects.Errors.Handle(ex)
                                          Finally
                                              Cursor = Cursors.Default
                                          End Try
                                      End Sub
            Next
        End Sub

        Private Sub LoadData()

            Dim transactions = m_commonObjects.Transactions
            Dim filtered = transactions.GetAll.Where(Function(c)
                                                         If ChkExactMatch.Checked AndAlso c.Description.Equals(TxtFilter.Text, StringComparison.CurrentCultureIgnoreCase) Then
                                                             Return True
                                                         ElseIf ContainsIgnoreCase(c.Description, TxtFilter.Text) Then
                                                             Return True
                                                         End If
                                                         Return False
                                                     End Function)

            Try
                Dim accounts = From trans In filtered
                               Group By trans.AccountCode Into AccountValue = Sum(CDec(IIf(String.IsNullOrEmpty(trans.InstrumentCode), 1, trans.Rate)) * trans.Amount)
                               Order By AccountValue Descending

                ChartAccount.Series.Clear()
                ChartAccount.Titles.Clear()
                With ChartAccount.Titles.Add("Totals By Account")
                    .Font = New Font(Font, FontStyle.Bold)
                End With

                ChartAccount.AntiAliasing = AntiAliasingStyles.All
                Const SERIES_ACCOUNT = "Account"
                With ChartAccount.Series.Add(SERIES_ACCOUNT)
                    .BorderWidth = 3
                    .ChartType = SeriesChartType.Column
                    .IsValueShownAsLabel = True
                    .LabelFormat = "0"
                    .Font = New Font(.Font.FontFamily, 7)
                    .IsVisibleInLegend = False
                End With
                With ChartAccount.ChartAreas(0)
                    .AxisX.Interval = 1
                    .AxisX.Title = "Account"
                    .AxisX.LabelAutoFitMaxFontSize = 8
                    .AxisX.MajorGrid.LineColor = Color.LightGray

                    .AxisY.LabelStyle.Format = "c2"
                    .AxisY.LabelAutoFitMaxFontSize = 8
                    .AxisY.Title = "Total"
                    .AxisY.MajorGrid.LineColor = Color.LightGray
                End With

                For Each account In accounts
                    With ChartAccount.Series(SERIES_ACCOUNT).Points.Add(account.AccountValue)
                        .AxisLabel = account.AccountCode
                        .Color = If(account.AccountValue > 0, Color.Green, Color.Red)
                    End With
                Next

            Catch ex As Exception
                Throw
            End Try

            Try
                ChartMonth.Series.Clear()
                ChartMonth.Titles.Clear()
                With ChartMonth.Titles.Add("Totals By Month")
                    .Font = New Font(Font, FontStyle.Bold)
                End With

                ChartMonth.AntiAliasing = AntiAliasingStyles.All
                Const SERIES_MONTH = "Month"
                With ChartMonth.Series.Add(SERIES_MONTH)
                    .BorderWidth = 3
                    .ChartType = SeriesChartType.Column
                    .IsValueShownAsLabel = True
                    .LabelFormat = "c2"
                    .Font = New Font(.Font.FontFamily, 7)
                    .IsVisibleInLegend = False
                End With
                With ChartMonth.ChartAreas(0)
                    .AxisX.Title = "Month"
                    .AxisX.LabelAutoFitMaxFontSize = 8
                    .AxisX.MajorGrid.LineColor = Color.LightGray

                    .AxisY.LabelStyle.Format = "c2"
                    .AxisY.LabelAutoFitMaxFontSize = 8
                    .AxisY.Title = "Total"
                    .AxisY.MajorGrid.LineColor = Color.LightGray
                End With

                Dim months = filtered.
                    GroupBy(Function(c) c.TransDate.ToString("yyyy MM")).
                    OrderBy(Function(c) c.Key)
                For Each m In months
                    Dim sMonth = m.Key
                    Dim cTotal = m.Sum(Function(c)
                                           Return CDec(IIf(String.IsNullOrEmpty(c.InstrumentCode), 1, c.Rate)) * c.Amount
                                       End Function)
                    With ChartMonth.Series(SERIES_MONTH).Points.Add(cTotal)
                        .AxisLabel = sMonth
                    End With
                Next

            Catch ex As Exception
                Throw
            End Try

        End Sub

        Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilter.KeyPress
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub BtnGo_Click(sender As Object, e As EventArgs) Handles BtnGo.Click
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub ChkExactMatch_CheckedChanged(sender As Object, e As EventArgs) Handles ChkExactMatch.CheckedChanged
            Try
                Cursor = Cursors.WaitCursor
                LoadData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
