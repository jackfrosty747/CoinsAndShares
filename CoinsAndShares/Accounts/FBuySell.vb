Imports System.Globalization
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Instruments.MInstuments

Namespace Accounts
    Friend Class FBuySell : Implements IInstrumentReader

        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_sAccountCode As String

        Private m_fCalculating As Boolean

        Private m_fOkPressed As Boolean
        Friend Sub New(commonObjects As CCommonObjects, sAccountCode As String)
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_sAccountCode = sAccountCode

            Icon = Icon.FromHandle(My.Resources.money.GetHicon)

            DisplayCurrencyCode()

            LoadData()

            DtpBuySellDate.Value = GetDateToUse(Nothing)

        End Sub

        Private Shared Function GetDateToUse(setDate As Date?) As Date

            Static lastDate As Date?

            If setDate.HasValue Then
                lastDate = setDate.Value
            End If

            If lastDate Is Nothing OrElse Not lastDate.HasValue Then
                lastDate = Now.Date
            End If

            Return lastDate.Value

        End Function

        Friend ReadOnly Property OkPressed As Boolean
            Get
                Return m_fOkPressed
            End Get
        End Property
        Private Sub LoadData()
            Dim account = GetAccount()

            Dim instrumentType = GetInstrumentTypeApplicable(account)

            Dim instrumentsSubset = m_commonObjects.Instruments.GetAll.Where(Function(c) c.InstrumentType = instrumentType)

            If OptSell.Checked Then
                ' Just show instruments with some in
                Dim allInstruments = m_commonObjects.Instruments.GetAll
                Dim allCurrencies = m_commonObjects.Currencies.GetAll
                Dim totalsByInstrument = From t In account.Transactions
                                         Group t By t.InstrumentCode Into Group
                                         Select InstrumentCode, TotalQuantity = Group.Sum(Function(c) c.Amount),
                                         LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))
                instrumentsSubset = instrumentsSubset.Where(Function(c) totalsByInstrument.Any(Function(b) b.InstrumentCode = c.Code And b.TotalQuantity > 0))
            End If

            CDropdowns.CInstrumentsDropdown.SetupDropdown(CmbInstrument, instrumentsSubset, m_commonObjects, Me)

            Dim sInstrumentTypeName As String = instrumentType.ToString.Replace("_", " ")

            GbBuySell.Text = $"Buy / Sell {sInstrumentTypeName}"
            OptBuy.Text = $"Buy {sInstrumentTypeName}"
            OptSell.Text = $"Sell {sInstrumentTypeName}"

        End Sub

        Private Function GetBuySellFromScreen(fSilent As Boolean) As CBuySell
            Dim buyOrsell As EBuySell
            If OptBuy.Checked Then
                buyOrsell = EBuySell.Buy
            ElseIf OptSell.Checked Then
                buyOrsell = EBuySell.Sell
            Else
                If Not fSilent Then
                    Throw New Exception("Select Buy or Sell")
                End If
            End If
            Dim rQuantity As Decimal = 0
            If TxtQuantity.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtQuantity.Text, rQuantity) AndAlso Not fSilent Then
                Throw New Exception($"Quantity not valid")
            End If
            Dim rRate As Decimal = 0
            If TxtRate.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtRate.Text, rRate) AndAlso Not fSilent Then
                Throw New Exception($"Rate not valid")
            End If
            Dim cValue As Decimal = GetCurrencyAmount(LblValueCaption.Text, TxtValue.Text, fSilent)

            Dim buySell As New CBuySell(buyOrsell, CmbInstrument.Text, DtpBuySellDate.Value, rQuantity, rRate, cValue, m_sAccountCode)
            Return buySell
        End Function


        Public Sub ReadInstrument(instrument As CInstrument) Implements IInstrumentReader.ReadInstrument
            Try
                TxtRate.Text = instrument.Rate.ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Dim buySell = GetBuySellFromScreen(False)
                    If MessageBox.Show($"Process {buySell.BuySell} of {buySell.Quantity} of {buySell.InstrumentCode}?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                        m_commonObjects.Accounts.ProcessBuySell(buySell)
                    Else
                        Return
                    End If
                    m_fOkPressed = True
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Function GetExchangeRate() As Decimal
            Return m_commonObjects.Instruments.GetExchangeRate(CmbInstrument.Text, m_commonObjects.Currencies)
        End Function




        Private Sub TxtQuantity_TextChanged(sender As Object, e As EventArgs) Handles TxtQuantity.TextChanged
            If m_fCalculating Then
                Return
            End If
            m_fCalculating = True
            Try
                Dim buySell = GetBuySellFromScreen(True)
                If Not ChkPinValue.Checked Then
                    TxtValue.Text = FormatCurrency(buySell.Quantity * buySell.Rate / GetExchangeRate())

                ElseIf Not ChkPinRate.Checked Then
                    Dim c As Decimal = 0
                    If buySell.Quantity <> 0 Then
                        c = buySell.Amount * GetExchangeRate() / buySell.Quantity
                    End If
                    TxtRate.Text = c.ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
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
                Dim buySell = GetBuySellFromScreen(True)
                If Not ChkPinValue.Checked Then
                    TxtValue.Text = FormatCurrency(buySell.Quantity * buySell.Rate / GetExchangeRate())
                ElseIf Not ChkPinQuantity.Checked Then
                    Dim c As Decimal = 0
                    If buySell.Rate <> 0 Then
                        c = buySell.Amount * GetExchangeRate() / buySell.Rate
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
            If m_fCalculating Then
                Return
            End If
            m_fCalculating = True
            Try
                Dim buySell = GetBuySellFromScreen(True)
                If Not ChkPinRate.Checked Then
                    Dim c As Decimal = 0
                    If buySell.Quantity <> 0 Then
                        c = buySell.Amount * GetExchangeRate() / buySell.Quantity
                    End If
                    TxtRate.Text = c.ToString(FORMAT_RATE, CultureInfo.CurrentCulture)
                ElseIf Not ChkPinQuantity.Checked Then
                    Dim c As Decimal = 0
                    If buySell.Rate <> 0 Then
                        c = buySell.Amount * GetExchangeRate() / buySell.Rate
                    End If
                    TxtQuantity.Text = c.ToString(FORMAT_QUANTITY, CultureInfo.CurrentCulture)
                End If

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                m_fCalculating = False
            End Try
        End Sub



        Private Sub ChkPin_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPinQuantity.CheckedChanged,
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

        Private Sub BtnCreateNewInstrument_Click(sender As Object, e As EventArgs) Handles BtnCreateNewInstrument.Click
            Try
                Dim account = GetAccount()

                Using frmNewInstrument As New FNewInstrument(m_commonObjects, GetInstrumentTypeApplicable(account))
                    frmNewInstrument.ShowDialog()
                    If frmNewInstrument.OkPressed Then
                        LoadData()
                        CmbInstrument.Text = frmNewInstrument.InstrumentCodeCreated
                    End If
                End Using
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Function GetAccount() As CAccount
            Dim account = m_commonObjects.Accounts.GetAll().Where(Function(c) c.AccountCode.Equals(m_sAccountCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If account Is Nothing Then
                Throw New Exception(My.Resources.Error_AccountCodeNotValid)
            End If
            Return account
        End Function
        Private Shared Function GetInstrumentTypeApplicable(account As CAccount) As EInstrumentType
            Dim instrumentType As EInstrumentType
            Select Case account.AccountType
                Case EAccountType.Crypto : instrumentType = EInstrumentType.Crypto
                Case EAccountType.Share_Account : instrumentType = EInstrumentType.Share
                Case Else
                    Throw New Exception($"Not applicable for {account.AccountType.ToString.Replace("_", " ")} accounts")
            End Select
            Return instrumentType
        End Function

        Private Sub CmbInstrument_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CmbInstrument.InitializeLayout

        End Sub

        Private Sub CmbInstrument_TextChanged(sender As Object, e As EventArgs) Handles CmbInstrument.TextChanged
            Try
                DisplayCurrencyCode()
                ' Exchange rate might have changed.  Clear these
                TxtQuantity.Text = String.Empty
                TxtRate.Text = String.Empty
                TxtValue.Text = String.Empty
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub DisplayCurrencyCode()

            Dim sCurrencyCode As String = String.Empty

            If CmbInstrument.Text.Length > 0 Then
                Dim i = m_commonObjects.Instruments.GetAll.Where(Function(c) c.Code.Equals(CmbInstrument.Text, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                If i IsNot Nothing Then
                    sCurrencyCode = i.CurrencyCode
                End If
            End If

            LblCurrency.Text = sCurrencyCode

        End Sub

        Private Sub DtpBuySellDate_ValueChanged(sender As Object, e As EventArgs) Handles DtpBuySellDate.ValueChanged
            Try
                GetDateToUse(DtpBuySellDate.Value)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub OptBuy_CheckedChanged(sender As Object, e As EventArgs) Handles OptBuy.CheckedChanged, OptSell.CheckedChanged
            Try
                BtnAll.Visible = OptSell.Checked

                Dim r As RadioButton = CType(sender, RadioButton)
                If r.Checked Then
                    LoadData()
                End If
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
            Try
                Dim account = m_commonObjects.Accounts.GetAll.Where(Function(c) c.AccountCode.Equals(m_sAccountCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                If account Is Nothing Then
                    Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                End If
                Dim trans = account.Transactions.Where(Function(c) c.InstrumentCode.Equals(CmbInstrument.Text, StringComparison.CurrentCultureIgnoreCase))

                Dim cHoldings = trans.Sum(Function(c) c.Amount)

                TxtQuantity.Text = cHoldings.ToString(CultureInfo.CurrentCulture)

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class
End Namespace
