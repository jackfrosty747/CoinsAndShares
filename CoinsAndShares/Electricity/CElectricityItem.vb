Namespace Electricity
    Friend Class CElectricityItem
        Friend ReadOnly Property DateFrom As Date
        Friend ReadOnly Property DailyRate As Decimal
        Friend Sub New(dateFrom As Date, dailyRate As Decimal)
            Me.DateFrom = dateFrom
            Me.DailyRate = dailyRate
        End Sub
    End Class

End Namespace
