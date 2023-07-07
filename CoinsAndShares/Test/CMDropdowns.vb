Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Header
Imports CoinsAndShares.Accounts.MAccounts
Imports MaterialSkin.Controls

Namespace Test
    Friend Class CMDropdowns
        Friend Class AccountTypesDropdown
            Friend Shared Sub Setup(MCmb As MaterialComboBox)
                MCmb.Items.Clear()

                For Each e As EAccountType In [Enum].GetValues(GetType(EAccountType))
                    MCmb.Items.Add(e.ToString.Replace("_", " "))
                Next
            End Sub
        End Class

    End Class

End Namespace
