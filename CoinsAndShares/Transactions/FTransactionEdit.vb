Namespace Transactions
    Friend Class FTransactionEdit
        Private ReadOnly m_commonObjects As CCommonObjects
        Private ReadOnly m_transaction As CTransaction
        Friend Sub New(commonObjects As CCommonObjects, transaction As CTransaction)

            ' This call is required by the designer.
            InitializeComponent()

            m_commonObjects = commonObjects
            m_transaction = transaction

            ' Add any initialization after the InitializeComponent() call.
            Icon = Icon.FromHandle(My.Resources.pencil.GetHicon)

            LoadData()
        End Sub

        Private Sub LoadData()
            DtpDate.Value = m_transaction.TransDate.Date
            TxtRate.Text = m_transaction.Rate.ToString
            TxtDescription.Text = m_transaction.Description
        End Sub

        Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click, BtnCancel.Click
            Try
                If sender Is BtnOk Then
                    Cursor = Cursors.WaitCursor
                    Save()
                End If
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub Save()
            Dim transactions = m_commonObjects.Transactions

            m_transaction.TransDate = DtpDate.Value

            Dim rRate As Decimal
            If Not Decimal.TryParse(TxtRate.Text, rRate) Then
                Throw New Exception(My.Resources.Error_RateNotValid)
            End If

            m_transaction.Rate = rRate
            m_transaction.Description = TxtDescription.Text

            transactions.UpdateExistingTransaction(m_transaction)
        End Sub
    End Class
End Namespace
