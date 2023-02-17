Namespace BackupRestore.JSon
    Public Class JSonSettings
        Public Property AlphavantageApiKey As String
        Public Property RateUpdateWarningHours As Integer?
        Public Property ExchangeRatesApiKey As String
        Public Property DefaultBackupPath As String
        Friend Sub Fill(alphavantageApiKey As String, rateUpdateWarningHours As Integer?, exchangeRatesApiKey As String, defaultBackupPath As String)
            Me.AlphavantageApiKey = alphavantageApiKey
            Me.RateUpdateWarningHours = rateUpdateWarningHours
            Me.ExchangeRatesApiKey = exchangeRatesApiKey
            Me.DefaultBackupPath = defaultBackupPath
        End Sub
    End Class

End Namespace
