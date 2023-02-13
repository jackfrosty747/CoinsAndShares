Namespace Transactions
    Friend Class CTransactionExporter
        Private Enum Columns
            Id
            TransDate
            TransactionType
            AccountCode
            InstrumentCode
            Rate
            Amount
            Description
            Batch
            ExchangeRate
        End Enum
        Private Sub New() : End Sub
        Friend Shared Sub ExportCsv(transactions As IEnumerable(Of CTransaction), sOutputFile As String)

            If transactions Is Nothing OrElse Not transactions.Any Then
                Throw New ArgumentNullException(NameOf(transactions))
            End If

            Using dt As New DataTable
                dt.Columns.Add(Columns.Id.ToString, GetType(Long))
                dt.Columns.Add(Columns.TransDate.ToString, GetType(Date))
                dt.Columns.Add(Columns.TransactionType.ToString, GetType(String))
                dt.Columns.Add(Columns.AccountCode.ToString, GetType(String))
                dt.Columns.Add(Columns.InstrumentCode.ToString, GetType(String))
                dt.Columns.Add(Columns.Rate.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Amount.ToString, GetType(Decimal))
                dt.Columns.Add(Columns.Description.ToString, GetType(String))
                dt.Columns.Add(Columns.Batch.ToString, GetType(Long))
                dt.Columns.Add(Columns.ExchangeRate.ToString, GetType(Decimal))

                For Each transaction In transactions
                    Dim dr = dt.NewRow

                    dr(Columns.Id.ToString) = transaction.Id
                    dr(Columns.TransDate.ToString) = transaction.TransDate
                    dr(Columns.TransactionType.ToString) = transaction.TransactionType.ToString
                    dr(Columns.AccountCode.ToString) = transaction.AccountCode
                    dr(Columns.InstrumentCode.ToString) = transaction.InstrumentCode
                    dr(Columns.Rate.ToString) = transaction.Rate
                    dr(Columns.Amount.ToString) = transaction.Amount
                    dr(Columns.Description.ToString) = transaction.Description
                    dr(Columns.Batch.ToString) = transaction.Batch
                    dr(Columns.ExchangeRate.ToString) = transaction.ExchangeRate

                    dt.Rows.Add(dr)
                Next

                CCsv.SaveDatatableToCsv(dt, sOutputFile)
            End Using

        End Sub

    End Class

End Namespace
