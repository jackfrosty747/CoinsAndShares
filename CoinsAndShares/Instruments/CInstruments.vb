Imports System.Data.SqlServerCe
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Rates
Imports CoinsAndShares.Transactions

Namespace Instruments
    Friend Class CInstruments
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_all As IEnumerable(Of CInstrument)
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Function GetAll() As IEnumerable(Of CInstrument)
            If m_all Is Nothing Then
                m_all = GetAllNow()
            End If
            Return m_all
        End Function
        ' Replacing all with ChatGPT optimised below
        'Private Function GetAllNow() As IEnumerable(Of CInstrument)
        '    Const TEMP_INSTRUMENT_RATE As String = "instrumentRate"
        '    Dim sql As String = $"
        '        SELECT
        '            i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE},
        '            i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE},
        '            i.{CDatabase.FIELD_INSTRUMENT_DESCRIPTION},
        '            i.{CDatabase.FIELD_INSTRUMENT_RATE} {TEMP_INSTRUMENT_RATE},
        '            i.{CDatabase.FIELD_INSTRUMENT_RATEUPDATED},
        '            i.{CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE},
        '            i.{CDatabase.FIELD_INSTRUMENT_CURRENCYCODE},
        '            i.{CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER},
        '            i.{CDatabase.FIELD_INSTRUMENT_NOTES},
        '            i.{CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE},
        '            t.*
        '        FROM {CDatabase.TABLE_INSTRUMENT} i LEFT JOIN {CDatabase.TABLE_TRANSACTIONS} t ON
        '            i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE} = t.{CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE}
        '        ORDER BY i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE}, t.{CDatabase.FIELD_TRANSACTIONS_ID};"
        '    Dim col As New Collection(Of CInstrument)
        '    Using dt = m_commonObjects.Database.GetDatatable(sql)
        '        Dim instrument As CInstrument = Nothing
        '        For Each dr As DataRow In dt.Rows
        '            Dim sInstrumentCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE))
        '            If instrument Is Nothing OrElse Not instrument.Code.Equals(sInstrumentCode, StringComparison.CurrentCultureIgnoreCase) Then
        '                instrument = col.Where(Function(c) c.Code.Equals(sInstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
        '                If instrument Is Nothing Then
        '                    Dim sTypeCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE))
        '                    Dim instrumentType As EInstrumentType = GetInstrumentTypeFromCode(sTypeCode, True)
        '                    Dim sDescription As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_DESCRIPTION))
        '                    Dim rRate As Decimal = CDatabase.DbToDecimal(dr(TEMP_INSTRUMENT_RATE))
        '                    Dim sProviderLinkCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE))
        '                    Dim sCurrencyCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_CURRENCYCODE))
        '                    Dim rateUpdated As Date? = Nothing
        '                    If Not IsDBNull(dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED)) Then
        '                        rateUpdated = CType(dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED), Date)
        '                    End If
        '                    Dim providerMultiplier As Decimal = CDatabase.DbToDecimal(dr(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER))
        '                    Dim sNotes As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_NOTES))
        '                    Dim sHedgingGroupCode = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE))
        '                    instrument = New CInstrument(sInstrumentCode, instrumentType, sDescription, rRate,
        '                        rateUpdated, sProviderLinkCode, sCurrencyCode, providerMultiplier, sNotes, sHedgingGroupCode)
        '                    col.Add(instrument)
        '                End If
        '            End If
        '            If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_ID)) Then
        '                Dim transaction = CTransactions.GetTransactionFromDr(dr)
        '                instrument.Transactions.Add(transaction)
        '            End If
        '        Next
        '    End Using
        '    Return col
        'End Function
        Private Function GetAllNow() As IEnumerable(Of CInstrument)
            Const TEMP_INSTRUMENT_RATE As String = "instrumentRate"
            Dim sql As String = $"
        SELECT
            i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE},
            i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE},
            i.{CDatabase.FIELD_INSTRUMENT_DESCRIPTION},
            i.{CDatabase.FIELD_INSTRUMENT_RATE} {TEMP_INSTRUMENT_RATE},
            i.{CDatabase.FIELD_INSTRUMENT_RATEUPDATED},
            i.{CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE},
            i.{CDatabase.FIELD_INSTRUMENT_CURRENCYCODE},
            i.{CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER},
            i.{CDatabase.FIELD_INSTRUMENT_NOTES},
            i.{CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE},
            t.*
        FROM {CDatabase.TABLE_INSTRUMENT} i LEFT JOIN {CDatabase.TABLE_TRANSACTIONS} t ON
            i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE} = t.{CDatabase.FIELD_TRANSACTIONS_INSTRUMENTCODE}
        ORDER BY i.{CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE}, t.{CDatabase.FIELD_TRANSACTIONS_ID};"
            Dim col As New Dictionary(Of String, CInstrument)
            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim sInstrumentCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE))
                    Dim instrument As CInstrument = Nothing
                    If Not col.TryGetValue(sInstrumentCode, instrument) Then
                        Dim sTypeCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE))
                        Dim instrumentType As EInstrumentType = GetInstrumentTypeFromCode(sTypeCode, True)
                        Dim sDescription As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_DESCRIPTION))
                        Dim rRate As Decimal = CDatabase.DbToDecimal(dr(TEMP_INSTRUMENT_RATE))
                        Dim sProviderLinkCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE))
                        Dim sCurrencyCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_CURRENCYCODE))
                        Dim rateUpdated As Date? = Nothing
                        If Not IsDBNull(dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED)) Then
                            rateUpdated = CType(dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED), Date)
                        End If
                        Dim providerMultiplier As Decimal = CDatabase.DbToDecimal(dr(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER))
                        Dim sNotes As String = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_NOTES))
                        Dim sHedgingGroupCode = CDatabase.DbToString(dr(CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE))
                        instrument = New CInstrument(sInstrumentCode, instrumentType, sDescription, rRate,
                                                     rateUpdated, sProviderLinkCode, sCurrencyCode, providerMultiplier, sNotes, sHedgingGroupCode)
                        col.Add(sInstrumentCode, instrument)
                    End If
                    If Not IsDBNull(dr(CDatabase.FIELD_TRANSACTIONS_ID)) Then
                        Dim transaction = CTransactions.GetTransactionFromDr(dr)
                        instrument.Transactions.Add(transaction)
                    End If
                Next
            End Using
            Return col.Values
        End Function

        Friend Sub UpdateRates(instrumentType As EInstrumentType)

            Dim rateProvider = GetRateProviderToUse(instrumentType)
            m_commonObjects.Database.TransactionBegin()
            Try
                UpdateRatesNow(instrumentType)
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try

        End Sub
        Friend Sub UpdateRatesNow(instrumentType As EInstrumentType)
            m_commonObjects.Database.TransactionEnsureActive()

            Dim rateProvider = GetRateProviderToUse(instrumentType)

            Dim instruments = GetAll().Where(Function(c)
                                                 Return c.InstrumentType = instrumentType AndAlso
                                                    Not String.IsNullOrEmpty(c.ProviderLinkCode)
                                             End Function)

            instruments = instruments.OrderBy(Function(c)
                                                  If c.RateUpdated.HasValue Then
                                                      Return c.RateUpdated.Value
                                                  Else
                                                      Return CDate("1/1/1900")
                                                  End If
                                              End Function)

            ' Get the provider's codes we've set on all instruments.  E.g. will return BTC,ETH,etc..
            Dim providerLinkCodes = instruments.Select(Function(c) c.ProviderLinkCode).Distinct

            ' Get a collection of those codes with their new codes
            Dim newRates As IEnumerable(Of CRate) = rateProvider.GetNewRates(providerLinkCodes)

            For Each instrument In instruments
                If Not String.IsNullOrEmpty(instrument.ProviderLinkCode) Then
                    Dim newRate = newRates.Where(Function(c) c.ID.Equals(instrument.ProviderLinkCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                    If newRate IsNot Nothing Then
                        instrument.Rate = newRate.Rate
                        Select Case instrument.ProviderMultiplier
                            Case 0, 1
                            Case Else
                                instrument.Rate *= instrument.ProviderMultiplier
                        End Select
                        AddUpdateNow(instrument)
                    End If
                End If
            Next

        End Sub

        Friend Sub CreateNew(instrument As CInstrument)
            m_commonObjects.Database.TransactionBegin()
            Try
                Dim all = GetAll()
                If all.Where(Function(c) c.Code.Equals(instrument.Code, StringComparison.CurrentCultureIgnoreCase)).Any Then
                    Throw New Exception(My.Resources.Error_ItemAlreadyExists)
                End If
                AddUpdateNow(instrument)
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Friend Sub Update(instrument As CInstrument)
            m_commonObjects.Database.TransactionBegin()
            Try
                AddUpdateNow(instrument)
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub AddUpdateNow(instrument As CInstrument)
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_INSTRUMENT}
                WHERE {CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE} = {CDatabase.SqlString(instrument.Code)};"
            Using cm = m_commonObjects.Database.GetCommand(sql)
                Using da As New SqlCeDataAdapter(cm)
                    Using dt As New DataTable
                        da.Fill(dt)
                        Dim dr As DataRow
                        If dt.Rows.Count = 1 Then
                            dr = dt.Rows(0)
                        Else
                            dr = dt.NewRow()
                            dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE) = instrument.Code
                            dr(CDatabase.FIELD_INSTRUMENT_INSTRUMENTTYPE) = instrument.InstrumentType.Code
                            dt.Rows.Add(dr)
                        End If
                        dr(CDatabase.FIELD_INSTRUMENT_DESCRIPTION) = instrument.Description
                        dr(CDatabase.FIELD_INSTRUMENT_RATE) = instrument.Rate
                        If instrument.Rate <> 0 Then
                            dr(CDatabase.FIELD_INSTRUMENT_RATEUPDATED) = Now
                        End If

                        dr(CDatabase.FIELD_INSTRUMENT_PROVIDERLINKCODE) = instrument.ProviderLinkCode
                        dr(CDatabase.FIELD_INSTRUMENT_CURRENCYCODE) = instrument.CurrencyCode

                        dr(CDatabase.FIELD_INSTRUMENT_PROVIDERMULTIPLIER) = instrument.ProviderMultiplier

                        dr(CDatabase.FIELD_INSTRUMENT_NOTES) = instrument.Notes

                        dr(CDatabase.FIELD_INSTRUMENT_HEDGINGGROUPCODE) = instrument.HedgingGroupCode

                        Using cb As New SqlCeCommandBuilder(da)
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Friend Sub ValidateDelete(instruments As IEnumerable(Of CInstrument))

            Dim all = GetAll()

            For Each selected In instruments
                Dim i = all.Where(Function(c) c.Code.Equals(selected.Code, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                If i Is Nothing Then
                    Throw New Exception(My.Resources.Error_ItemNotFound)
                ElseIf i.Transactions.Any Then
                    Throw New Exception(My.Resources.Error_CannotDeleteTransactionsExist)
                End If
            Next

        End Sub

        Friend Sub Delete(instruments As IEnumerable(Of CInstrument))
            m_commonObjects.Database.TransactionBegin()
            ValidateDelete(instruments)
            Try
                For Each instrument In instruments
                    DeleteNow(instrument.Code)
                Next
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub DeleteNow(sInstrumentCode As String)
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql As String = $"
                DELETE
                FROM {CDatabase.TABLE_INSTRUMENT}
                WHERE {CDatabase.FIELD_INSTRUMENT_INSTRUMENTCODE} = {CDatabase.SqlString(sInstrumentCode)};"
            m_commonObjects.Database.ExecuteQuery(sql)
        End Sub





        Private Sub DataChanged()
            m_all = Nothing
            m_commonObjects.ClearCache()
            m_commonObjects.RefreshForms()
        End Sub


        Friend Function GetExchangeRate(sInstrumentCode As String, currencies As CCurrencies) As Decimal
            If String.IsNullOrEmpty(sInstrumentCode) Then
                Return 1
            End If
            Dim instrument = GetAll.Where(Function(c) c.Code.Equals(sInstrumentCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If instrument Is Nothing Then
                Return 1
            End If
            If String.IsNullOrEmpty(instrument.CurrencyCode) OrElse instrument.CurrencyCode.Equals(GetLocalCurrencyIso, StringComparison.CurrentCultureIgnoreCase) Then
                Return 1
            End If
            Dim cur = currencies.GetAll.Where(Function(c) c.CurrencyCode.Equals(instrument.CurrencyCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
            If cur Is Nothing OrElse cur.CurrencyRate <= 0 OrElse Not cur.CurrencyRate.HasValue Then
                Return 1
            End If
            Return cur.CurrencyRate.Value
        End Function

        Friend Sub StoreNewRates(rates As IEnumerable(Of CRate))
            m_commonObjects.Database.TransactionBegin()
            Try
                StoreNewRatesNow(rates)
                m_commonObjects.Database.TransactionCommit()
                DataChanged()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub StoreNewRatesNow(rates As IEnumerable(Of CRate))
            Dim all = GetAll()
            For Each r In rates
                Dim i = all.FirstOrDefault(Function(c) c.Code.Equals(r.ID, StringComparison.CurrentCultureIgnoreCase))
                If i Is Nothing Then
                    Throw New Exception(My.Resources.Error_InstrumentCodeNotValid)
                End If
                i.Rate = r.Rate
                AddUpdateNow(i)
            Next
        End Sub
    End Class

End Namespace
