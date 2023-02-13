Imports System.Globalization

Namespace Settings
    Friend Class FSettings
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend Property OkPressed As Boolean
        Friend Sub New(commonObjects As CCommonObjects)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            Icon = Icon.FromHandle(My.Resources.toolbox__pencil.GetHicon)
            LoadSettings()
        End Sub

        Private Sub LoadSettings()
            Dim settings As New CSettings(m_commonObjects)
            TxtAlphavantageApiKey.Text = settings.AlphavantageKey

            If settings.RateUpdateWarningHours.HasValue Then
                TxtRateUpdateWarningHours.Text = settings.RateUpdateWarningHours.Value.ToString(CultureInfo.CurrentCulture)
            Else
                TxtRateUpdateWarningHours.Text = String.Empty
            End If

            TxtExchangeRatesApiKey.Text = settings.ExchangeRatesApiKey

            TxtDefaultBackupPath.Text = settings.DefaultBackupPath
        End Sub

        Private Sub BtnOkCancel_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Cursor = Cursors.WaitCursor
                    Dim settings As New CSettings(m_commonObjects)

                    Dim rateUpdateWarningHours As Integer? = Nothing
                    Dim i As Integer
                    If TxtRateUpdateWarningHours.Text.Length > 0 Then
                        If Not Integer.TryParse(TxtRateUpdateWarningHours.Text, i) Then
                            Throw New Exception(My.Resources.Error_QuantityNotValid)
                        End If
                        rateUpdateWarningHours = i
                    End If

                    settings.SaveSettings(TxtAlphavantageApiKey.Text, rateUpdateWarningHours, TxtExchangeRatesApiKey.Text, TxtDefaultBackupPath.Text)
                    OkPressed = True
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
