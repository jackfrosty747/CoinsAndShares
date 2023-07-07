Imports System.ComponentModel

Namespace Accounts
    Module MAccounts
        Friend Enum EAccountType
            <Description("B")> Bank_Account
            <Description("C")> Crypto ' Wallet or account
            <Description("S")> Share_Account
        End Enum
        Friend Function GetAccountTypeFromCode(sCode As String, fSilent As Boolean) As EAccountType
            For Each t As EAccountType In [Enum].GetValues(GetType(EAccountType))
                If t.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase) Then
                    Return t
                End If
            Next
            If fSilent Then
                Return EAccountType.Bank_Account
            End If
            Throw New Exception($"{sCode} is not a valid account type")
        End Function
        Friend Function GetAccountTypeFromName(sName As String, fSilent As Boolean) As EAccountType
            For Each t As EAccountType In [Enum].GetValues(GetType(EAccountType))
                If t.ToString.Replace(" ", "_").Equals(sName.Replace(" ", "_"), StringComparison.CurrentCultureIgnoreCase) Then
                    Return t
                End If
            Next
            If fSilent Then
                Return EAccountType.Bank_Account
            End If
            Throw New Exception($"{sName} is not a valid account type")
        End Function

        Friend Enum EBuySell
            Buy
            Sell
        End Enum
        Friend Enum EAdjustType
            Money
            Instrument
        End Enum


        Friend Function GetTransDescriptionTransferTo(accountCode As String) As String
            Return $"Transfer to account {accountCode}"
        End Function
        Friend Function GetTransDescriptionFeeForSending(accountCode As String) As String
            Return $"Fee for sending to account {accountCode}"
        End Function
        Friend Function GetTransDescriptionReceiptFrom(accountCode As String) As String
            Return $"Receipt from account {accountCode}"
        End Function
        Friend Function GetTransDescriptionFeeForReceiving(accountCode As String) As String
            Return $"Fee for receiving from account {accountCode}"
        End Function
    End Module
End Namespace
