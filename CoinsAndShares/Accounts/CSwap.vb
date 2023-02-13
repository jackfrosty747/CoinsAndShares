Namespace Accounts
    Friend Class CSwap
        Friend ReadOnly Property AccountCode As String
        Friend ReadOnly Property SwapDate As Date
        Friend ReadOnly Property FromQuantity As Decimal
        Friend ReadOnly Property FromInstrumentCode As String
        Friend ReadOnly Property FromRate As Decimal
        Friend ReadOnly Property ToQuantity As Decimal
        Friend ReadOnly Property ToInstrumentCode As String
        Friend ReadOnly Property ToRate As Decimal
        Friend Sub New(accountCode As String, swapDate As Date, fromQuantity As Decimal, fromInstrumentCode As String,
                       fromRate As Decimal, toQuantity As Decimal, toInstrumentCode As String, toRate As Decimal)
            Me.AccountCode = accountCode
            Me.SwapDate = swapDate
            Me.FromQuantity = fromQuantity
            Me.FromInstrumentCode = fromInstrumentCode
            Me.FromRate = fromRate
            Me.ToQuantity = toQuantity
            Me.ToInstrumentCode = toInstrumentCode
            Me.ToRate = toRate
        End Sub
        Friend Function FromValue() As Decimal
            Return FromQuantity * FromRate
        End Function
        Friend Function ToValue() As Decimal
            Return ToQuantity * ToRate
        End Function
    End Class

End Namespace
