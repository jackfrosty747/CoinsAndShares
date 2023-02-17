Namespace BackupRestore.JSon
    Public Class JSonDatabase
        Public Property Accounts As List(Of JSonAccount)
        Public Property Currencies As List(Of JSonCurrency)
        Public Property Instruments As List(Of JSonInstrument)
        Public Property Transactions As List(Of JSonTransaction)
        Public Property Settings As JSonSettings
        Public Property Snapshots As List(Of JSonSnapshot)
        Public Property ElectricityItems As List(Of JSonElectricityItem)
        Public Property NoteItems As List(Of JsonNoteItem)
        Public Property NetworksItems As List(Of JsonNetworkItem)
        Friend Sub Fill(accounts As List(Of JSonAccount), currencies As List(Of JSonCurrency), instruments As List(Of JSonInstrument),
                        transactions As List(Of JSonTransaction), settings As JSonSettings, snapshots As List(Of JSonSnapshot),
                        electricityItems As List(Of JSonElectricityItem),
                        noteItems As List(Of JsonNoteItem), networksItems As List(Of JsonNetworkItem))
            Me.Accounts = accounts
            Me.Currencies = currencies
            Me.Instruments = instruments
            Me.Transactions = transactions
            Me.Settings = settings
            Me.Snapshots = snapshots
            Me.ElectricityItems = electricityItems
            Me.NoteItems = noteItems
            Me.NetworksItems = networksItems
        End Sub
    End Class
End Namespace
