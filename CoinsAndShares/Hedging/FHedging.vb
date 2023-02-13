Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments

Namespace Hedging
    Friend Class FHedging
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_allInstruments As IEnumerable(Of CInstrument)
        Private ReadOnly m_allCurrencies As IEnumerable(Of CCurrencyDetail)
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            m_allInstruments = commonObjects.Instruments.GetAll()

            m_allCurrencies = commonObjects.Currencies.GetAll()

            CDropdowns.CHedgingGroupsGropdown.SetupDropdown(CmbHedgingGroupCode, m_allInstruments)

        End Sub

        Private Sub CmbHedgingGroupCode_TextChanged(sender As Object, e As EventArgs) Handles CmbHedgingGroupCode.TextChanged
            Try
                LoadData
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Sub LoadData()

            Dim insts = m_allInstruments.Where(Function(c) c.HedgingGroupCode.Equals(CmbHedgingGroupCode.Text, StringComparison.InvariantCultureIgnoreCase))
            Dim totalUkValue As Decimal
            For Each i In insts
                totalUkValue += i.GetLocalCurrencyBalance(m_allInstruments, m_allCurrencies)
            Next

            TxtLocalValue.Text = totalUkValue.ToString("c2")

        End Sub
    End Class
End Namespace
