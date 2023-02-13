Namespace Transactions
    Friend Class CCoinsAndShares
        Friend ReadOnly Property CoinsProfit As Decimal
        Friend ReadOnly Property SharesProfit As Decimal
        Friend ReadOnly Property CoinsHoldings As Decimal
        Friend ReadOnly Property SharesHoldings As Decimal
        Friend Sub New(coinsProfit As Decimal, sharesProfit As Decimal, coinsHoldings As Decimal, sharesHoldings As Decimal)
            Me.CoinsProfit = coinsProfit
            Me.SharesProfit = sharesProfit
            Me.CoinsHoldings = coinsHoldings
            Me.SharesHoldings = sharesHoldings
        End Sub
    End Class

End Namespace
