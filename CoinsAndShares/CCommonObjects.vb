Friend Class CCommonObjects
    Friend ReadOnly Database As CDatabase
    Friend ReadOnly Errors As CErrors
    Friend ReadOnly FrmMdi As FMdi
    Friend CustomColors As Integer() ' Just a place to hold custom colours while the program is in memory
    Friend Sub New(database As CDatabase, errors As CErrors, frmMdi As FMdi)
        Me.Database = database
        Me.Errors = errors
        Me.FrmMdi = frmMdi
    End Sub
    Friend Sub RefreshForms()
        ' Refresh the data on all forms that implement IDataRefresh
        ' Call this just after transaction commit in whichever class has the commit
        For Each frm In FrmMdi.MdiChildren
            Dim frmAccountForm As IDataRefresh = TryCast(frm, IDataRefresh)
            If frmAccountForm IsNot Nothing Then
                frmAccountForm.RefreshData()
            End If
        Next
        For Each ctl In FrmMdi.Controls
            Dim ctlRefreshForm As IDataRefresh = TryCast(ctl, IDataRefresh)
            If ctlRefreshForm IsNot Nothing Then
                ctlRefreshForm.RefreshData()
            End If
        Next
    End Sub

    Friend Sub ClearCache()
        m_accounts = Nothing
        m_instruments = Nothing
        m_transactions = Nothing
        m_currencies = Nothing
        m_networks = Nothing
        m_electricity = Nothing
        m_notes = Nothing
    End Sub

    Private m_accounts As Accounts.CAccounts
    Private m_instruments As Instruments.CInstruments
    Private m_transactions As Transactions.CTransactions
    Private m_currencies As Currencies.CCurrencies
    Private m_networks As Networks.CNetworks
    Private m_electricity As Electricity.CElectricity
    Private m_notes As Notes.CNotes
    Friend Function Accounts() As Accounts.CAccounts
        If m_accounts Is Nothing Then
            m_accounts = New Accounts.CAccounts(Me)
        End If
        Return m_accounts
    End Function

    Friend Function Instruments() As Instruments.CInstruments
        If m_instruments Is Nothing Then
            m_instruments = New Instruments.CInstruments(Me)
        End If
        Return m_instruments
    End Function

    Friend Function Transactions() As Transactions.CTransactions
        If m_transactions Is Nothing Then
            m_transactions = New Transactions.CTransactions(Me)
        End If
        Return m_transactions
    End Function

    Friend Function Currencies() As Currencies.CCurrencies
        If m_currencies Is Nothing Then
            m_currencies = New Currencies.CCurrencies(Me)
        End If
        Return m_currencies
    End Function

    Friend Function Networks() As Networks.CNetworks
        If m_networks Is Nothing Then
            m_networks = New Networks.CNetworks(Me)
        End If
        Return m_networks
    End Function
    Friend Function Electricity() As Electricity.CElectricity
        If m_electricity Is Nothing Then
            m_electricity = New Electricity.CElectricity(Me)
        End If
        Return m_electricity
    End Function

    Friend Function Notes() As Notes.CNotes
        If m_notes Is Nothing Then
            m_notes = New Notes.CNotes(Me)
        End If
        Return m_notes
    End Function

End Class
