Imports System.Globalization

Namespace Test
    Friend Class FAccountAdjust

        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_acccountCode As String

        Private m_fCalculating As Boolean

        Friend Sub New(commonObjects As CCommonObjects, accountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_acccountCode = accountCode

            MTxtDate.Text = Now.Date.ToShortDateString

            MAdjustTypeMoney.Text = GetLocalCurrencyName()

            Dim cs = CCoinsAndShares.GetInstance(commonObjects)

            Dim account = cs.AllAccounts.SingleOrDefault(Function(c) c.AccountCode.Equals(accountCode, StringComparison.CurrentCultureIgnoreCase))

            Dim sBonusType As String
            Dim fEnabled As Boolean = True
            Select Case account.AccountType
                Case Accounts.MAccounts.EAccountType.Crypto
                    sBonusType = "Crypto"
                Case Accounts.MAccounts.EAccountType.Share_Account
                    sBonusType = "Share"
                Case Else
                    sBonusType = "N/A"
                    fEnabled = False
            End Select
            MAdjustTypeInstrument.Text = sBonusType
            MAdjustTypeInstrument.Enabled = fEnabled

            Dim instruments = cs.AllInstruments
            If account.AccountType = Accounts.MAccounts.EAccountType.Share_Account Then
                instruments = instruments.Where(Function(c) c.InstrumentType = CoinsAndShares.Instruments.MInstuments.EInstrumentType.Share)
            ElseIf account.AccountType = Accounts.MAccounts.EAccountType.Crypto Then
                instruments = instruments.Where(Function(c) c.InstrumentType = CoinsAndShares.Instruments.MInstuments.EInstrumentType.Crypto)
            Else
                instruments = instruments.Where(Function(c) False)
            End If

            CDropdowns.InstrumentsDropdown.SetupDropdown(CmbInstrument, instruments, commonObjects)

            EnableDisableInstrument()

        End Sub

        Private Sub BtnProcess_Click(sender As Object, e As EventArgs) Handles BtnProcess.Click
            Try
                Dim cs = CCoinsAndShares.GetInstance(m_commonObjects)

                Dim transactionType As ETransactionType
                If MOptReasonBonus.Checked Then
                    transactionType = ETransactionType.Bonus
                ElseIf MOptReasonFee.Checked Then
                    transactionType = ETransactionType.Fee
                ElseIf MOptReasonMining.Checked Then
                    transactionType = ETransactionType.Mining
                ElseIf MOptReasonAdjust.Checked Then
                    transactionType = ETransactionType.Adjustment
                Else
                    Throw New Exception(My.Resources.Error_ReasonNotSelected)
                End If

                Dim transactionDate As Date
                If Not Date.TryParse(MTxtDate.Text, transactionDate) Then
                    Throw New Exception(My.Resources.Error_NotAValidDate)
                End If

                Dim instrumentCode = String.Empty

                If MAdjustTypeMoney.Checked Then
                ElseIf MAdjustTypeInstrument.Checked Then
                    instrumentCode = CmbInstrument.Text
                    If cs.AllInstruments.SingleOrDefault(Function(c) c.InstrumentCode.Equals(instrumentCode, StringComparison.CurrentCultureIgnoreCase)) Is Nothing Then
                        Throw New Exception(My.Resources.Error_InstrumentCodeNotValid)
                    End If
                Else
                    Throw New Exception(My.Resources.Error_BonusTypeNotSelected)
                End If



                'cs.ProcessAdjustment(transactionType, transactionDate, m_acccountCode, instrumentCode, )

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub MAdjustTypeMoney_CheckedChanged(sender As Object, e As EventArgs) Handles MAdjustTypeMoney.CheckedChanged, MAdjustTypeInstrument.CheckedChanged
            Dim opt As RadioButton = CType(sender, RadioButton)
            Try
                If opt.Checked Then
                    EnableDisableInstrument()
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub EnableDisableInstrument()
            TlpInstrument.Enabled = MAdjustTypeInstrument.Checked
        End Sub

    End Class

End Namespace
