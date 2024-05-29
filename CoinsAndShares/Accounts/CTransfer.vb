Namespace Accounts
    Friend Class CTransfer
        Friend ReadOnly Property AccountCodeFrom As String
        Friend ReadOnly Property AccountCodeTo As String
        Friend ReadOnly Property SendDebit As Decimal
        Friend ReadOnly Property SendFee As Decimal
        Friend ReadOnly Property SendDateTime As Date
        Friend ReadOnly Property ReceiveDateTime As Date
        Friend Property DescriptionSuffix As String

        Friend Function IntermediateAmount() As Decimal
            Return SendDebit - SendFee
        End Function

        Friend ReadOnly ReceiveFee As Decimal

        Friend Function ReceiveCredit() As Decimal
            Return IntermediateAmount() - ReceiveFee
        End Function

        Friend Sub New(accountCodeFrom As String, accountCodeTo As String, sendDebit As Decimal, sendFee As Decimal, receiveFee As Decimal,
                       sendDateTime As Date, receiveDateTime As Date)
            Me.AccountCodeFrom = accountCodeFrom
            Me.AccountCodeTo = accountCodeTo
            Me.SendDebit = sendDebit
            Me.SendFee = sendFee
            Me.ReceiveFee = receiveFee
            Me.SendDateTime = sendDateTime
            Me.ReceiveDateTime = receiveDateTime
        End Sub

    End Class

End Namespace
