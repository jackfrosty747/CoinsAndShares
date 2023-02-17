Namespace BackupRestore.JSon
    Public Class JSonSnapshot
        Public Property SnapshotDate As Date?
        Public Property CoinsValue As Decimal
        Public Property SharesValue As Decimal
        Public Sub Fill(snapshotDate As Date?, coinsValue As Decimal, sharesValue As Decimal)
            Me.SnapshotDate = snapshotDate
            Me.CoinsValue = coinsValue
            Me.SharesValue = sharesValue
        End Sub
    End Class

End Namespace
