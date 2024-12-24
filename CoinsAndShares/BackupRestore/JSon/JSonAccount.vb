Namespace BackupRestore.JSon
    Public Class JSonAccount
        Public Property AccountCode As String
        Public Property AccountName As String
        Public Property AccountType As String
        Public Property Notes As String
        Public Property NetworkId As String
        Public Property IncludeOnShortcuts As Boolean
        Public Property NonTaxable As Boolean
        Public Property CashSavingsRate As Decimal
        Friend Sub Fill(accountCode As String, accountName As String, accountType As String, notes As String,
                        networkId As String, includeOnShortcuts As Boolean, nonTaxable As Boolean, cashSavingsRate As Decimal)
            Me.AccountCode = accountCode
            Me.AccountName = accountName
            Me.AccountType = accountType
            Me.Notes = notes
            Me.NetworkId = networkId
            Me.IncludeOnShortcuts = includeOnShortcuts
            Me.NonTaxable = nonTaxable
            Me.CashSavingsRate = cashSavingsRate
        End Sub
    End Class
End Namespace
