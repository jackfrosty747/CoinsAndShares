Imports System.Globalization
Imports CoinsAndShares.Instruments

Namespace Accounts
    Friend Class FSwapCrypto
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_sAccountCode As String
        Private ReadOnly m_allCryptoInstruments As IEnumerable(Of CInstrument)
        Friend Sub New(commonObjects As CCommonObjects, sAccountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects
            m_sAccountCode = sAccountCode

            Icon = Icon.FromHandle(My.Resources.arrow_resize.GetHicon)

            Dim instruments = commonObjects.Instruments
            Dim allInstruments = instruments.GetAll

            m_allCryptoInstruments = allInstruments.Where(Function(c) c.InstrumentType = EInstrumentType.Crypto)

            Dim account = m_commonObjects.Accounts.GetAll.First(Function(c) c.AccountCode.Equals(sAccountCode, StringComparison.InvariantCultureIgnoreCase))
            Dim currencies = m_commonObjects.Currencies
            Dim allCurrencies = currencies.GetAll
            Dim totalsByInstrument = From t In account.Transactions
                                     Group t By t.InstrumentCode Into Group
                                     Select InstrumentCode, TotalQuantity = Group.Sum(Function(c) c.Amount),
                                         LocalCurrencyValue = Group.Sum(Function(c) c.GetLocalCurrencyBalance(allInstruments, allCurrencies))

            Dim allCryptoInstrumentsWithBalance = m_allCryptoInstruments.Where(Function(c) totalsByInstrument.Any(Function(b) b.InstrumentCode = c.Code And b.TotalQuantity > 0)).ToList

            allInstruments = allInstruments.OrderByDescending(Function(c) IsAtTop(c.Code)).ThenBy(Function(c)
                                                                                                      Return c.Code
                                                                                                  End Function)

            CDropdowns.CInstrumentsDropdown.SetupDropdown(CmbFromInstrument, allCryptoInstrumentsWithBalance, commonObjects, New LocalInstrumentReader(TxtFromRate))
            CDropdowns.CInstrumentsDropdown.SetupDropdown(CmbToInstrument, allInstruments, commonObjects, New LocalInstrumentReader(TxtToRate))

            TxtDate.Text = Now.Date.ToShortDateString

            OutputSummary()

        End Sub
        Private Class LocalInstrumentReader : Implements IInstrumentReader
            Private ReadOnly Property RateTextbox As TextBox
            Friend Sub New(rateTextbox As TextBox)
                Me.RateTextbox = rateTextbox
            End Sub
            Private Sub ReadInstrument(instrument As CInstrument) Implements IInstrumentReader.ReadInstrument
                RateTextbox.Text = instrument.Rate.ToString
            End Sub
        End Class

        Private Function GetSwap(fSilent As Boolean) As CSwap

            Dim swapDate As Date
            If Not Date.TryParse(TxtDate.Text, swapDate) Then
                If Not fSilent Then
                    Throw New Exception(My.Resources.Error_NotAValidDate)
                End If
                swapDate = Now.Date
            End If

            Dim fromQuantity As Decimal
            If TxtFromQuantity.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtFromQuantity.Text, fromQuantity) AndAlso Not fSilent Then
                Throw New Exception(My.Resources.Error_QuantityNotValid)
            End If
            Dim fromRate As Decimal
            If TxtFromRate.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtFromRate.Text, fromRate) AndAlso Not fSilent Then
                Throw New Exception(My.Resources.Error_RateNotValid)
            End If
            Dim toQuantity As Decimal
            If TxtToQuantity.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtToQuantity.Text, toQuantity) AndAlso Not fSilent Then
                Throw New Exception(My.Resources.Error_QuantityNotValid)
            End If
            Dim toRate As Decimal
            If TxtToRate.Text.Length > 0 AndAlso Not Decimal.TryParse(TxtToRate.Text, toRate) AndAlso Not fSilent Then
                Throw New Exception(My.Resources.Error_RateNotValid)
            End If

            Dim swap = New CSwap(m_sAccountCode, swapDate,
                                fromQuantity, CmbFromInstrument.Text.ToUpperInvariant, fromRate,
                                toQuantity, CmbToInstrument.Text.ToUpperInvariant, toRate)

            Return swap
        End Function

        Private Sub BtnOkCancel_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Dim swap = GetSwap(False)
                    If MessageBox.Show("Post swap?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        Dim accounts = m_commonObjects.Accounts
                        accounts.ProcessSwap(swap)
                    Else
                        Return
                    End If
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub OutputSummary()

            Dim swap = GetSwap(True)

            LblFromValue.Text = swap.FromValue.ToString("c2")
            LblToValue.Text = swap.ToValue.ToString("c2")

        End Sub

        Private Sub TxtFromQuantity_TextChanged(sender As Object, e As EventArgs) Handles TxtFromQuantity.TextChanged, TxtToQuantity.TextChanged, CmbFromInstrument.TextChanged, CmbToInstrument.TextChanged,
            TxtFromRate.TextChanged, TxtToRate.TextChanged
            Try
                OutputSummary()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
            Try
                Cursor = Cursors.WaitCursor
                Dim accounts = m_commonObjects.Accounts
                Dim account = accounts.GetAll.FirstOrDefault(Function(c) c.AccountCode.Equals(m_sAccountCode, StringComparison.CurrentCultureIgnoreCase))
                If account Is Nothing Then
                    Throw New Exception(My.Resources.Error_AccountCodeNotValid)
                End If
                Dim trans = account.Transactions.Where(Function(c) c.InstrumentCode.Equals(CmbFromInstrument.Text, StringComparison.CurrentCultureIgnoreCase))
                Dim cHoldings = trans.Sum(Function(c) c.Amount)
                TxtFromQuantity.Text = cHoldings.ToString(CultureInfo.CurrentCulture)
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

    End Class
End Namespace
