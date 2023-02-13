Imports System.Collections.ObjectModel
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Transactions

Namespace Accounts
    Friend Class CAccount
        Friend ReadOnly Property AccountCode As String
        Friend ReadOnly Property AccountName As String
        Friend ReadOnly Property AccountType As EAccountType
        Friend ReadOnly Property Notes As String
        Friend ReadOnly Property NetworkId As String
        Friend ReadOnly Property IncludeOnShortcuts As Boolean
        Friend Property Transactions As Collection(Of CTransaction)
        Friend Sub New(accountCode As String, accountName As String, accountType As EAccountType, notes As String,
            networkId As String, includeOnShortcuts As Boolean)
            Me.AccountCode = accountCode
            Me.AccountName = accountName
            Me.AccountType = accountType
            Me.Notes = notes
            Me.NetworkId = networkId
            Me.IncludeOnShortcuts = includeOnShortcuts
            Transactions = New Collection(Of CTransaction)
        End Sub
        Friend Function GetLocalCurrencyBalance(instruments As IEnumerable(Of CInstrument), allCurrencies As IEnumerable(Of CCurrencyDetail)) As Decimal
            Return Transactions.Sum(Function(c) c.GetLocalCurrencyBalance(instruments, allCurrencies))
        End Function
        Friend Function GetLocalCashBalance(instruments As IEnumerable(Of CInstrument), allCurrencies As IEnumerable(Of CCurrencyDetail)) As Decimal
            Dim cashTransactions = Transactions.Where(Function(c) String.IsNullOrEmpty(c.InstrumentCode))
            Return cashTransactions.Sum(Function(c) c.GetLocalCurrencyBalance(instruments, allCurrencies))
        End Function
    End Class
End Namespace
