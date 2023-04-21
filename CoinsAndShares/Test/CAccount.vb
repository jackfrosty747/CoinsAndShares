﻿Namespace Test
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

        Public Function GetBalance() As Decimal
            Static balance As Decimal?
            If Not balance.HasValue Then
                balance = Transactions.Sum(Function(c) c.CurrentValue)
            End If
            Return balance.Value
        End Function
        Public Function GetCashBalance() As Decimal
            Static balance As Decimal?
            If Not balance.HasValue Then
                balance = Transactions.Sum(Function(c) c.CashBalance)
            End If
            Return balance.Value
        End Function

        Public Function GetPl() As Decimal
            Return Transactions.Sum(Function(c) c.CurrentValue - c.Transfers)
        End Function

    End Class

End Namespace
