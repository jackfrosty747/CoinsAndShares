Namespace Test
    Friend Class CAccount
        Friend ReadOnly Property AccountCode As String
        Friend ReadOnly Property AccountName As String
        Friend ReadOnly Property AccountType As Accounts.EAccountType
        Friend ReadOnly Property Notes As String
        Friend ReadOnly Property NetworkId As String
        Friend ReadOnly Property IncludeOnShortcuts As Boolean
        Friend ReadOnly Property Transactions As IEnumerable(Of CTransaction)
        Friend Sub New(accountCode As String, accountName As String, accountType As Accounts.EAccountType, notes As String,
                       networkId As String, includeOnShortcuts As Boolean, transactions As IEnumerable(Of CTransaction))
            Me.AccountCode = accountCode
            Me.AccountName = accountName
            Me.AccountType = accountType
            Me.Notes = notes
            Me.NetworkId = networkId
            Me.IncludeOnShortcuts = includeOnShortcuts
            Me.Transactions = transactions
        End Sub

        Friend Function GetCashBalance() As Decimal
            ' You must Cache this if required, calling this multiple times will iterate the collection each time
            Return Transactions.Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode)).Sum(Function(d) d.Amount)
        End Function

    End Class

End Namespace
