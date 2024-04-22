Imports CoinsAndShares.Rates

Namespace Instruments
    Friend Class FNewInstrument
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_fOkPressed As Boolean
        Friend ReadOnly Property OkPressed As Boolean
            Get
                Return m_fOkPressed
            End Get
        End Property
        Private m_sInstrumentCodeCreated As String
        Friend ReadOnly Property InstrumentCodeCreated As String
            Get
                Return m_sInstrumentCodeCreated
            End Get
        End Property
        Friend Sub New(commonObjects As CCommonObjects, restrictType As EInstrumentType?)
            ' This call is required by the designer.
            InitializeComponent()

            TxtInstrumentCode.MaxLength = CDatabase.LENGTH_INSTRUMENT_CODE

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources._new.GetHicon)
            CDropdowns.CInstrumentTypeNames.SetupDropdown(CmbInstrumentTypeName, commonObjects)
            CDropdowns.CCurrenciesDropdown.SetupDropdown(CmbCurrencyCode, commonObjects, m_commonObjects.Currencies.GetAll)
            CmbCurrencyCode.Text = GetLocalCurrencyIso()

            If restrictType.HasValue Then
                CmbInstrumentTypeName.Text = restrictType.Value.ToString.Replace("_", " ")
            End If
            CmbInstrumentTypeName.ReadOnly = restrictType.HasValue
        End Sub
        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                m_fOkPressed = False
                If sender Is BtnOk Then
                    Dim instrumentType As EInstrumentType = GetInstrumentTypeFromName(CmbInstrumentTypeName.Text, False)
                    If Not m_commonObjects.Currencies.GetAll().Where(Function(c) c.CurrencyCode.Equals(CmbCurrencyCode.Text, StringComparison.CurrentCultureIgnoreCase)).Any Then
                        Throw New Exception(My.Resources.Error_CurrencyCodeNotValid)
                    End If
                    Dim instrument = New CInstrument(TxtInstrumentCode.Text.ToUpper, instrumentType, TxtDescription.Text, 0, Nothing,
                                                     String.Empty, CmbCurrencyCode.Text, 0, String.Empty, String.Empty, 0)
                    m_commonObjects.Instruments.CreateNew(instrument)
                    m_sInstrumentCodeCreated = instrument.Code
                    m_fOkPressed = True
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

    End Class

End Namespace
