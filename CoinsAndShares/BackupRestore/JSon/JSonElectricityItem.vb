Namespace BackupRestore.JSon
    Public Class JSonElectricityItem
        Public Sub Fill(dateFrom As Date, dailyRate As Decimal)
            Me.DateFrom = dateFrom
            Me.DailyRate = dailyRate
        End Sub
        Public Property DateFrom As Date
        Public Property DailyRate As Decimal
    End Class

End Namespace
