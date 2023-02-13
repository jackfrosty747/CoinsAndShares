Imports System.Globalization

Namespace Currencies
    Friend Class CCurrencies
        Private ReadOnly m_commonObjects As CCommonObjects
        Private m_all As IEnumerable(Of CCurrencyDetail)
        Friend Sub New(commonObjects As CCommonObjects)
            m_commonObjects = commonObjects
        End Sub
        Friend Function GetAll() As IEnumerable(Of CCurrencyDetail)
            If m_all Is Nothing Then
                m_all = GetAllNow()
            End If
            Return m_all
        End Function
        Private Function GetAllNow() As IEnumerable(Of CCurrencyDetail)
            Dim all As New List(Of CCurrencyDetail)

            Dim sLocalCurrencyIso = GetLocalCurrencyIso()
            Dim favourites As New List(Of String) From {
                sLocalCurrencyIso,
                "USD",
                "GBP",
                "EUR"
            }

            Dim cultures = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(Function(c) Not c.Equals(CultureInfo.InvariantCulture) AndAlso Not c.IsNeutralCulture)
            For Each culture In cultures
                If Not culture.IsNeutralCulture Then
                    Dim ri = New RegionInfo(culture.LCID)
                    Dim sIso As String = ri.ISOCurrencySymbol.ToUpper
                    Dim fFavourite As Boolean = favourites.Contains(sIso)
                    Dim currency As New CCurrencyDetail(sIso, ri.CurrencyEnglishName, Nothing, fFavourite)
                    If Not all.Where(Function(c) c.CurrencyCode.Equals(sIso, StringComparison.CurrentCultureIgnoreCase)).Any Then
                        all.Add(currency)
                    End If
                End If
            Next

            Dim sql As String = $"
                SELECT *
                FROM {CDatabase.TABLE_CURRENCIES}
                ORDER BY {CDatabase.FIELD_CURRENCIES_CURRENCYCODE};"

            Using dt = m_commonObjects.Database.GetDatatable(sql)
                For Each dr As DataRow In dt.Rows
                    Dim sCode As String = CDatabase.DbToString(dr(CDatabase.FIELD_CURRENCIES_CURRENCYCODE))
                    Dim rRate As Decimal = CDatabase.DbToDecimal(dr(CDatabase.FIELD_CURRENCIES_CURRENCYRATE))
                    Dim r = all.Where(Function(c) c.CurrencyCode.Equals(sCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                    If r IsNot Nothing Then
                        r.CurrencyRate = rRate
                    End If
                Next
            End Using
            Return all
        End Function
        Friend Sub SaveAll(all As IEnumerable(Of CCurrencyDetail))
            m_commonObjects.Database.TransactionBegin()
            Try
                SaveAllNow(all)
                m_commonObjects.Database.TransactionCommit()
                RefreshForms()
            Catch ex As Exception
                m_commonObjects.Database.TransactionRollback()
                Throw
            End Try
        End Sub
        Private Sub SaveAllNow(all As IEnumerable(Of CCurrencyDetail))
            m_commonObjects.Database.TransactionEnsureActive()
            Dim sql As String = $"
                DELETE
                FROM {CDatabase.TABLE_CURRENCIES};"
            m_commonObjects.Database.ExecuteQuery(sql)

            sql = String.Empty
            For Each c In all.Where(Function(d) d.CurrencyRate.HasValue)
                If Not String.IsNullOrEmpty(sql) Then
                    sql &= " UNION "
                End If
                sql &= $"SELECT {CDatabase.SqlString(c.CurrencyCode)}, {c.CurrencyRate}"
            Next

            If Not String.IsNullOrEmpty(sql) Then
                sql = $"
                    INSERT INTO {CDatabase.TABLE_CURRENCIES} (
                        {CDatabase.FIELD_CURRENCIES_CURRENCYCODE},
                        {CDatabase.FIELD_CURRENCIES_CURRENCYRATE}
                    ) {sql};"
                m_commonObjects.Database.ExecuteQuery(sql)
            End If
        End Sub
        Private Sub RefreshForms()
            m_commonObjects.ClearCache()
            m_all = Nothing
            m_commonObjects.RefreshForms()
        End Sub
        Friend Sub UpdateRatesFromApi(currencyRateApi As ICurrencyRateApi)
            Dim all = GetAll()
            Dim updates = currencyRateApi.GetAll
            For Each r In all
                Dim update = updates.Where(Function(c) c.CurrencyCode.Equals(r.CurrencyCode, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                If update IsNot Nothing Then
                    r.CurrencyRate = update.CurrencyRate
                End If
            Next
            SaveAll(all)
        End Sub

    End Class
End Namespace
