Namespace Snapshots
    Friend Class CSnapshot
        Friend ReadOnly Property SnapshotDate As Date
        Friend ReadOnly Property Coins As Decimal
        Friend ReadOnly Property Shares As Decimal
        Friend Sub New(snapshotDate As Date, coins As Decimal, shares As Decimal)
            Me.SnapshotDate = snapshotDate
            Me.Coins = coins
            Me.Shares = shares
        End Sub
        Friend Function Total() As Decimal
            Return Coins + Shares
        End Function
    End Class
End Namespace
