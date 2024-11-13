Namespace BackupRestore.JSon
    Public Class JSonTransaction
        Public Property Id As Long
        Public Property TransDate As Date?
        Public Property TransType As String
        Public Property AccountCode As String
        Public Property InstrumentCode As String
        Public Property Rate As Decimal?
        Public Property Amount As Decimal?
        Public Property Description As String
        Public Property Batch As Integer?
        Public Property ExchangeRate As Decimal?
        Public Property Reconciled As Boolean
        Friend Sub Fill(id As Long, transDate As Date?, transType As String, accountCode As String,
                        instrumentCode As String, rate As Decimal?, amount As Decimal?,
                        description As String, batch As Integer?, exchangeRate As Decimal?, reconciled As Boolean)
            Me.Id = id
            Me.TransDate = transDate
            Me.TransType = transType
            Me.AccountCode = accountCode
            Me.InstrumentCode = instrumentCode
            Me.Rate = rate
            Me.Amount = amount
            Me.Description = description
            Me.Batch = batch
            Me.ExchangeRate = exchangeRate
            Me.Reconciled = reconciled
        End Sub
    End Class
End Namespace
