Imports System.Globalization
Imports CoinsAndShares.Instruments

Namespace Accounts
    Friend Class FAdjust : Implements IInstrumentReader
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_sAccountCode As String

        Private m_fCalculating As Boolean

        Friend Sub New(commonObjects As CCommonObjects, sAccountCode As String)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Icon = Icon.FromHandle(My.Resources.present.GetHicon)
            m_commonObjects = commonObjects
            m_sAccountCode = sAccountCode

            Dim account = m_commonObjects.Accounts.GetAll.Where(Function(c) c.AccountCode.Equals(m_sAccountCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If account Is Nothing Then
                Throw New Exception(My.Resources.Error_AccountCodeNotValid)
            End If

            OptAdjustTypeMoney.Text = GetLocalCurrencyName()

            Dim validInstrumentOptions = m_commonObjects.Instruments.GetAll
            If account.AccountType = EAccountType.Crypto Then
                validInstrumentOptions = validInstrumentOptions.Where(Function(c) c.InstrumentType = EInstrumentType.Crypto)
            ElseIf account.AccountType = EAccountType.Share_Account Then
                validInstrumentOptions = validInstrumentOptions.Where(Function(c) c.InstrumentType = EInstrumentType.Share)
            Else
                validInstrumentOptions = validInstrumentOptions.Where(Function(c) False)
            End If
            CDropdowns.CInstrumentsDropdown.SetupDropdown(CmbInstrumentCode, validInstrumentOptions, commonObjects, Me)

            DtpDateTime.Value = Now

            Dim sBonusType As String
            Dim fEnabled As Boolean = True
            Select Case account.AccountType
                Case EAccountType.Crypto
                    sBonusType = "Crypto"
                Case EAccountType.Share_Account
                    sBonusType = "Share"
                Case Else
                    sBonusType = "N/A"
                    fEnabled = False
            End Select
            OptAdjustTypeInstrument.Text = sBonusType
            OptAdjustTypeInstrument.Enabled = fEnabled

            OptReasonAdjustment.ForeColor = CColours.TransactionType(ETransactionType.Adjustment)
            OptReasonFee.ForeColor = CColours.TransactionType(ETransactionType.Fee)
            OptReasonBonus.ForeColor = CColours.TransactionType(ETransactionType.Bonus)
            OptReasonMining.ForeColor = CColours.TransactionType(ETransactionType.Mining)

            AddDescriptionButtons()

            CheckSign()

            ReadInstrument(Nothing)
        End Sub
        Private Sub AddDescriptionButtons()
            Dim iButtonCount = [Enum].GetValues(GetType(EDescriptionPresets)).GetUpperBound(0) + 1
            For Each b In [Enum].GetValues(GetType(EDescriptionPresets))
                Dim sText = b.ToString.Replace("_", " ")
                Dim btn = New Button With {
                    .Parent = PnlDescriptions,
                    .Text = sText,
                    .Dock = DockStyle.Left,
                    .BackColor = SystemColors.ButtonFace,
                    .Font = New Font(Font.FontFamily, 7, FontStyle.Regular),
                    .Width = CInt(PnlDescriptions.Width / iButtonCount) - 1
                }
                AddHandler btn.Click, Sub()
                                          TxtDescription.Text = sText
                                      End Sub
            Next
        End Sub
        Private Sub ReadInstrument(instrument As CInstrument) Implements IInstrumentReader.ReadInstrument
            Dim sName As String = String.Empty
            Dim sRate As String = String.Empty
            If instrument IsNot Nothing Then
                sName = instrument.Description
                sRate = instrument.Rate.ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
            End If
            LblInstrumentName.Text = sName
            TxtRate.Text = sRate

            OptAdjustTypeInstrument.Checked = True ' Or getbonus from screen (silent) doesnt work
        End Sub

        Private Sub BtnOkCancel_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Dim adjustment As CAdjustment = GetAdjustmentFromScreen(False)

                    If MessageBox.Show($"Process {adjustment.TransactionType}?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
                        Return
                    End If
                    m_commonObjects.Accounts.ProcessAdjustment(adjustment)
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Function GetAdjustmentFromScreen(fSilent As Boolean) As CAdjustment
            Dim transactionType As ETransactionType
            If OptReasonFee.Checked Then
                transactionType = ETransactionType.Fee
            ElseIf OptReasonBonus.Checked Then
                transactionType = ETransactionType.Bonus
            ElseIf OptReasonAdjustment.Checked Then
                transactionType = ETransactionType.Adjustment
            ElseIf OptReasonMining.Checked Then
                transactionType = ETransactionType.Mining
            Else
                If Not fSilent Then
                    Throw New Exception(My.Resources.Error_ReasonNotSelected)
                End If
            End If

            Dim adjustType As EAdjustType
            Dim sInstrumentCode As String = String.Empty
            Dim rRate As Decimal = 0
            Dim rQuantity As Decimal = 0
            If OptAdjustTypeMoney.Checked Then
                adjustType = EAdjustType.Money
            ElseIf OptAdjustTypeInstrument.Checked Then
                adjustType = EAdjustType.Instrument
                sInstrumentCode = CmbInstrumentCode.Text
                If Not Decimal.TryParse(TxtRate.Text, rRate) AndAlso Not fSilent Then
                    Throw New Exception(My.Resources.Error_RateNotValid)
                End If
                If Not Decimal.TryParse(TxtQuantity.Text, rQuantity) AndAlso Not fSilent Then
                    Throw New Exception(My.Resources.Error_QuantityNotValid)
                End If
            ElseIf Not fSilent Then
                Throw New Exception(My.Resources.Error_BonusTypeNotSelected)
            End If
            Dim rAmount As Decimal = GetCurrencyAmount(LblAmountCaption.Text, TxtValue.Text, fSilent)

            Dim adjustment As New CAdjustment(transactionType, m_sAccountCode, DtpDateTime.Value, adjustType,
                                         sInstrumentCode, rQuantity, rRate, rAmount, TxtDescription.Text)

            Return adjustment
        End Function

        Private Sub OptBonusTypeMoney_CheckedChanged(sender As Object, e As EventArgs) Handles OptAdjustTypeMoney.CheckedChanged,
                OptAdjustTypeInstrument.CheckedChanged
            Dim opt As RadioButton = CType(sender, RadioButton)
            Try
                If opt.Checked Then
                    TlpInstrument.Enabled = OptAdjustTypeInstrument.Checked
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub



        Private Sub TxtQuantity_TextChanged(sender As Object, e As EventArgs) Handles TxtQuantity.TextChanged
            If m_fCalculating Then
                Return
            End If
            m_fCalculating = True
            Try
                Dim bonus = GetAdjustmentFromScreen(True)
                If Not ChkPinValue.Checked Then
                    TxtValue.Text = FormatCurrency(bonus.Quantity * bonus.Rate)
                ElseIf Not ChkPinRate.Checked Then
                    Dim c As Decimal = 0
                    If bonus.Quantity <> 0 Then
                        c = bonus.Amount / bonus.Quantity
                    End If
                    TxtRate.Text = (c).ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                m_fCalculating = False
            End Try
        End Sub

        Private Sub TxtRate_TextChanged(sender As Object, e As EventArgs) Handles TxtRate.TextChanged
            If m_fCalculating Then
                Return
            End If
            m_fCalculating = True
            Try
                Dim bonus = GetAdjustmentFromScreen(True)
                If Not ChkPinValue.Checked Then
                    TxtValue.Text = FormatCurrency(bonus.Quantity * bonus.Rate)
                ElseIf Not ChkPinQuantity.Checked Then
                    Dim c As Decimal = 0
                    If bonus.Rate <> 0 Then
                        c = bonus.Amount / bonus.Rate
                    End If
                    TxtQuantity.Text = c.ToString(FORMAT_QUANTITY, CultureInfo.CurrentCulture)
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                m_fCalculating = False
            End Try
        End Sub

        Private Sub TxtValue_TextChanged(sender As Object, e As EventArgs) Handles TxtValue.TextChanged
            CheckSign()

            If m_fCalculating Then
                Return
            End If
            m_fCalculating = True
            Try
                Dim bonus = GetAdjustmentFromScreen(True)
                If Not ChkPinRate.Checked Then
                    Dim c As Decimal = 0
                    If bonus.Quantity <> 0 Then
                        c = bonus.Amount / bonus.Quantity
                    End If
                    TxtRate.Text = (c).ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
                ElseIf Not ChkPinQuantity.Checked Then
                    Dim c As Decimal = 0
                    If bonus.Rate <> 0 Then
                        c = bonus.Amount / bonus.Rate
                    End If
                    TxtQuantity.Text = c.ToString(FORMAT_QUANTITY, CultureInfo.CurrentCulture)
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                m_fCalculating = False
            End Try
        End Sub

        Private Sub ChkPinQuantity_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPinQuantity.CheckedChanged,
                ChkPinRate.CheckedChanged, ChkPinValue.CheckedChanged
            Dim chk As CheckBox = CType(sender, CheckBox)
            Try
                Static lastCheckedOn As CheckBox
                If chk.Checked AndAlso PinsChecked() > 1 AndAlso lastCheckedOn IsNot Nothing Then
                    lastCheckedOn.Checked = False
                End If
                If chk.Checked Then
                    lastCheckedOn = chk
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Function PinsChecked() As Integer
            Dim i As Integer = 0
            If ChkPinQuantity.Checked Then
                i += 1
            End If
            If ChkPinRate.Checked Then
                i += 1
            End If
            If ChkPinValue.Checked Then
                i += 1
            End If
            Return i
        End Function

        Private Sub OptReasonBonus_CheckedChanged(sender As Object, e As EventArgs) Handles OptReasonBonus.CheckedChanged, OptReasonFee.CheckedChanged
            Try
                CheckSign()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Sub CheckSign()
            Dim sWarning As String = String.Empty
            Dim rValue As Decimal = GetCurrencyAmount("", TxtValue.Text, True)
            If rValue > 0 AndAlso OptReasonFee.Checked Then
                sWarning = "Fee should be negative"
            ElseIf rValue < 0 AndAlso OptReasonBonus.Checked Then
                sWarning = "Bonus should be positive"
            ElseIf rValue < 0 AndAlso OptReasonMining.Checked Then
                sWarning = "Mining amount should be positive"
            End If
            LblWarning.Text = sWarning
        End Sub

        Private Sub OptReasonMining_CheckedChanged(sender As Object, e As EventArgs) Handles OptReasonMining.CheckedChanged
            Try
                If TxtDescription.Text.Length = 0 Then
                    TxtDescription.Text = "Mining"
                End If
                If CmbInstrumentCode.Text.Length = 0 Then
                    CmbInstrumentCode.Text = "BTC"
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class
End Namespace
