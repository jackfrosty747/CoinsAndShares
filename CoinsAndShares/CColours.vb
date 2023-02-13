Imports CoinsAndShares.Accounts.MAccounts
Imports CoinsAndShares.Instruments.MInstuments

Public NotInheritable Class CColours

    Private Shared ReadOnly FORECOLOUR_DEFAULT As Color = Color.Black

    Private Shared ReadOnly FORECOLOUR_BANK As Color = Color.DarkRed
    Private Shared ReadOnly FORECOLOUR_CRYPTO As Color = Color.DarkGreen
    Private Shared ReadOnly FORECOLOUR_SHARE As Color = Color.DarkBlue

    Private Shared ReadOnly FORECOLOUR_TRANSTYPE_BUY As Color = Color.DarkGreen
    Private Shared ReadOnly FORECOLOUR_TRANSTYPE_SELL As Color = Color.DarkMagenta
    Private Shared ReadOnly FORECOLOUR_TRANSTYPE_FEE As Color = Color.DarkRed
    Private Shared ReadOnly FORECOLOUR_TRANSTYPE_TRANSFER As Color = Color.DarkBlue
    Private Shared ReadOnly FORECOLOUR_TRANSTYPE_BONUS As Color = Color.DarkCyan
    Private Shared ReadOnly FORECOLOUR_TRANSTYPE_ADJUSTMENT As Color = Color.Crimson
    Private Shared ReadOnly FORECOLOUR_TRANSTYPE_MINING As Color = Color.DarkGoldenrod

    Friend Shared Function InstrumentType(i As EInstrumentType) As Color
        Select Case i
            Case EInstrumentType.Crypto
                Return FORECOLOUR_CRYPTO
            Case EInstrumentType.Share
                Return FORECOLOUR_SHARE
            Case Else
                Return FORECOLOUR_DEFAULT
        End Select
    End Function
    Friend Shared Function AccountType(a As EAccountType) As Color
        Select Case a
            Case EAccountType.Crypto
                Return FORECOLOUR_CRYPTO
            Case EAccountType.Share_Account
                Return FORECOLOUR_SHARE
            Case EAccountType.Bank_Account
                Return FORECOLOUR_BANK
            Case Else
                Return FORECOLOUR_DEFAULT
        End Select
    End Function
    Friend Shared Function TransactionType(tt As ETransactionType) As Color
        Select Case tt
            Case ETransactionType.Buy
                Return FORECOLOUR_TRANSTYPE_BUY
            Case ETransactionType.Fee
                Return FORECOLOUR_TRANSTYPE_FEE
            Case ETransactionType.Sell
                Return FORECOLOUR_TRANSTYPE_SELL
            Case ETransactionType.Transfer
                Return FORECOLOUR_TRANSTYPE_TRANSFER
            Case ETransactionType.Bonus
                Return FORECOLOUR_TRANSTYPE_BONUS
            Case ETransactionType.Adjustment
                Return FORECOLOUR_TRANSTYPE_ADJUSTMENT
            Case ETransactionType.Mining
                Return FORECOLOUR_TRANSTYPE_MINING
            Case Else
                Return FORECOLOUR_DEFAULT
        End Select
    End Function
End Class
