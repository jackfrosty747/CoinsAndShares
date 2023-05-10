Namespace Test
    Friend Class FAccount : Implements IDataRefresh
        Private ReadOnly m_commonObjects As CCommonObjects
        Friend ReadOnly AccountCode As String

        Friend Sub New(commonObjects As CCommonObjects, accountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            Me.AccountCode = accountCode

            Text = $"ACCOUNT: {accountCode}"

            Icon = Icon.FromHandle(My.Resources.bank.GetHicon)

            Dim coinsAndShares = CCoinsAndShares.GetInstance(m_commonObjects)

            CDropdowns.CNetworksDropdown.SetupDropdown(CmbNetworkId, coinsAndShares.AllNetworks, m_commonObjects)

            LoadDataEntryData()
            LoadTransactionData()

            AddHandler TxtAccountName.TextChanged, AddressOf DataEntryChanged
            AddHandler CmbNetworkId.TextChanged, AddressOf DataEntryChanged
            AddHandler TxtNotes.TextChanged, AddressOf DataEntryChanged
            AddHandler ChkIncludeOnShortcuts.CheckedChanged, AddressOf DataEntryChanged

        End Sub

        Private Sub DataEntryChanged(sender As Object, e As EventArgs)
            ChangesMade(True)
        End Sub

        Private Sub ChangesMade(f As Boolean)
            If f Then
                BtnSave.BackColor = Color.Red
                BtnSave.ForeColor = Color.Yellow
            Else
                BtnSave.BackColor = SystemColors.ButtonFace
                BtnSave.ForeColor = SystemColors.ControlText
            End If
        End Sub

        Private Sub LoadDataEntryData()

            Dim coinsAndShares = CCoinsAndShares.GetInstance(m_commonObjects)

            Dim account = coinsAndShares.AllAccounts.SingleOrDefault(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))

            ForeColor = CColours.AccountType(account.AccountType)

            TxtAccountCode.Text = account.AccountCode
            TxtAccountType.Text = account.AccountType.ToString.Replace("_", " ")
            TxtAccountName.Text = account.AccountName
            CmbNetworkId.Text = account.NetworkId
            TxtNotes.Text = account.Notes
            ChkIncludeOnShortcuts.Checked = account.IncludeOnShortcuts

        End Sub

        Private Sub LoadTransactionData()
            ' Load the display data (transactions, holdings) not the editable data because that might be changed and not saved yet

            ' TODO

            ' Load transactions
            ' Load holdings



            ChangesMade(False)
        End Sub

        Public Sub RefreshData() Implements IDataRefresh.RefreshData
            ' Load the display data (transactions, holdings) not the editable data because that might be changed and not saved yet
            LoadTransactionData()
        End Sub

        Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
            Try
                Cursor = Cursors.WaitCursor

                Dim coinsAndShares = CCoinsAndShares.GetInstance(m_commonObjects)

                Dim account = coinsAndShares.AllAccounts.Single(Function(c) c.AccountCode.Equals(AccountCode, StringComparison.CurrentCultureIgnoreCase))
                ' TODO
                ' Save header
                account.AccountName = TxtAccountName.Text
                account.Notes = TxtNotes.Text
                account.NetworkId = CmbNetworkId.Text
                account.IncludeOnShortcuts = ChkIncludeOnShortcuts.Checked

                coinsAndShares.UpdateAccount(account)

                ' Load the data entry part.  The rest will refresh by the save function
                LoadDataEntryData()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class

End Namespace
