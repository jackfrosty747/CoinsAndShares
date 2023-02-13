Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Accounts.MAccounts
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Instruments.MInstuments
Imports CoinsAndShares.Networks
Imports Infragistics.Win.UltraWinGrid

Friend Class CDropdowns
    Friend NotInheritable Class CInstrumentTypeNames
        Private Enum Columns
            Description
            Code
        End Enum
        Friend Shared Sub SetupDropdown(cmb As UltraCombo, commonObjects As CCommonObjects)
            cmb.Tag = New TagBits(commonObjects)
            Dim dt As DataTable = GetBlankDt()
            For Each instrumentType As EInstrumentType In [Enum].GetValues(GetType(EInstrumentType))
                Dim dr = dt.NewRow
                dr(Columns.Description.ToString) = instrumentType.ToString.Replace("_", " ")
                dr(Columns.Code.ToString) = instrumentType.Code
                dt.Rows.Add(dr)
            Next
            RemoveHandler cmb.TextChanged, AddressOf TextChanged
            AddHandler cmb.TextChanged, AddressOf TextChanged
            RemoveHandler cmb.InitializeLayout, AddressOf InitializeLayout
            AddHandler cmb.InitializeLayout, AddressOf InitializeLayout
            RemoveHandler cmb.InitializeRow, AddressOf InitializeRow
            AddHandler cmb.InitializeRow, AddressOf InitializeRow
            cmb.DataSource = dt
        End Sub

        Private Shared Sub TextChanged(sender As Object, e As EventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                Dim i As EInstrumentType = GetInstrumentTypeFromName(cmb.Text, True)
                Dim c As Color = CColours.InstrumentType(i)
                cmb.Appearance.ForeColor = c
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            If e.ReInitialize Then
                Return
            End If
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                Dim sCode As String = e.Row.Cells(Columns.Code.ToString).Text
                Dim i = GetInstrumentTypeFromCode(sCode, True)
                e.Row.CellAppearance.ForeColor = CColours.InstrumentType(i)
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.Description.ToString
                            col.Width = 100
                            col.Header.Caption = "Type"
                            'Case Columns.Code.ToString
                            '    col.Width = 60
                            '    col.Header.Caption = "Code"
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Function GetBlankDt() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add(Columns.Description.ToString)
            dt.Columns.Add(Columns.Code.ToString)
            Return dt
        End Function
    End Class
    Friend NotInheritable Class CAccountTypeNames
        Private Enum Columns
            TypeName
            TypeCode
        End Enum
        Friend Shared Sub SetupDropdown(Cmb As UltraCombo, commonObjects As CCommonObjects)
            Cmb.Tag = New TagBits(commonObjects)
            Dim dt As DataTable = GetBlankDt()
            For Each e As EAccountType In [Enum].GetValues(GetType(EAccountType))
                Dim dr = dt.NewRow
                dr(Columns.TypeName.ToString) = e.ToString.Replace("_", " ")
                dr(Columns.TypeCode.ToString) = e.Code
                dt.Rows.Add(dr)
            Next
            RemoveHandler Cmb.TextChanged, AddressOf TextChanged
            AddHandler Cmb.TextChanged, AddressOf TextChanged
            RemoveHandler Cmb.InitializeLayout, AddressOf InitializeLayout
            AddHandler Cmb.InitializeLayout, AddressOf InitializeLayout
            RemoveHandler Cmb.InitializeRow, AddressOf InitializeRow
            AddHandler Cmb.InitializeRow, AddressOf InitializeRow
            Cmb.DataSource = dt
        End Sub

        Private Shared Sub TextChanged(sender As Object, e As EventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                Dim accountType As EAccountType = GetAccountTypeFromName(cmb.Text, True)
                Dim c As Color = CColours.AccountType(accountType)
                cmb.Appearance.ForeColor = c
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            If e.ReInitialize Then
                Return
            End If
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                Dim sCode As String = e.Row.Cells(Columns.TypeCode.ToString).Text
                Dim accountType As EAccountType = GetAccountTypeFromCode(sCode, True)
                e.Row.CellAppearance.ForeColor = CColours.AccountType(accountType)
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Header.Caption
                        Case Columns.TypeName.ToString
                            col.Width = cmb.Width
                            col.Header.Caption = "Type"
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Function GetBlankDt() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add(Columns.TypeName.ToString)
            dt.Columns.Add(Columns.TypeCode.ToString)
            Return dt
        End Function
    End Class
    Friend NotInheritable Class CAccountsDropdown
        Private NotInheritable Class LocalTagBits : Inherits TagBits
            Friend ReadOnly AllAccounts As IEnumerable(Of CAccount)
            Friend ReadOnly Networks As CNetworks
            Friend Sub New(commonObjects As CCommonObjects, allAccounts As IEnumerable(Of CAccount), networks As CNetworks)
                MyBase.New(commonObjects)
                Me.AllAccounts = allAccounts
                Me.Networks = networks
            End Sub
        End Class
        Private Enum Columns
            AccountCode
            AccountName
            AccountTypeCode
            AccountTypeDesc
        End Enum
        Friend Shared Sub SetupAccountsDropdown(cmb As UltraDropDownBase, accounts As IEnumerable(Of CAccount), commonObjects As CCommonObjects)
            Dim networks = commonObjects.Networks
            cmb.Tag = New LocalTagBits(commonObjects, accounts, networks)
            Dim dt As DataTable = GetBlankDt()
            For Each account In accounts.OrderBy(Function(c) c.NetworkId)
                Dim dr = dt.NewRow
                dr(Columns.AccountCode.ToString) = account.AccountCode
                dr(Columns.AccountName.ToString) = account.AccountName
                dr(Columns.AccountTypeCode.ToString) = account.AccountType.Code
                dr(Columns.AccountTypeDesc.ToString) = account.AccountType.ToString.Replace("_", " ")
                dt.Rows.Add(dr)
            Next
            RemoveHandler cmb.TextChanged, AddressOf TextChanged
            AddHandler cmb.TextChanged, AddressOf TextChanged
            If TypeOf cmb Is UltraCombo Then
                Dim combo = CType(cmb, UltraCombo)
                RemoveHandler combo.InitializeLayout, AddressOf InitializeLayout
                AddHandler combo.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler combo.InitializeRow, AddressOf InitializeRow
                AddHandler combo.InitializeRow, AddressOf InitializeRow
            ElseIf TypeOf cmb Is UltraDropDown Then
                Dim drp = CType(cmb, UltraDropDown)
                RemoveHandler drp.InitializeLayout, AddressOf InitializeLayout
                AddHandler drp.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler drp.InitializeRow, AddressOf InitializeRow
                AddHandler drp.InitializeRow, AddressOf InitializeRow
            End If
            cmb.DataSource = dt
        End Sub
        Private Shared Sub TextChanged(sender As Object, e As EventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As LocalTagBits = CType(cmb.Tag, LocalTagBits)
            Try
                Dim account = tagBits.AllAccounts.Where(Function(c) c.AccountCode.Equals(cmb.Text, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                Dim accountType As EAccountType
                If account IsNot Nothing Then
                    accountType = account.AccountType
                End If
                cmb.Appearance.ForeColor = CColours.AccountType(accountType)
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            If e.ReInitialize Then
                Return
            End If
            Dim cmb As UltraDropDownBase = CType(sender, UltraDropDownBase)
            Dim tagBits = CType(cmb.Tag, LocalTagBits)
            Try
                Dim sAccountTypeCode = e.Row.Cells(Columns.AccountTypeCode.ToString).Text
                Dim sAccountCode = e.Row.Cells(Columns.AccountCode.ToString).Text

                Dim accountType As EAccountType = GetAccountTypeFromCode(sAccountTypeCode, True)
                e.Row.CellAppearance.ForeColor = CColours.AccountType(accountType)

                Dim account = tagBits.AllAccounts.FirstOrDefault(Function(c) c.AccountCode.Equals(sAccountCode, StringComparison.InvariantCultureIgnoreCase))
                Dim colour = Color.White
                If account IsNot Nothing Then
                    colour = tagBits.Networks.GetColour(account)
                End If
                e.Row.CellAppearance.BackColor = colour

            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim cmb As UltraDropDownBase = CType(sender, UltraDropDownBase)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                '
                cmb.MaxDropDownItems = 25
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.AccountCode.ToString
                            col.Header.Caption = "Account Code"
                            col.Width = cmb.Width
                        Case Columns.AccountName.ToString
                            col.Header.Caption = "Name"
                            col.Width = 180
                        Case Columns.AccountTypeDesc.ToString
                            col.Header.Caption = "Type"
                            col.Width = 100
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Function GetBlankDt() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add(Columns.AccountCode.ToString)
            dt.Columns.Add(Columns.AccountName.ToString)
            dt.Columns.Add(Columns.AccountTypeCode.ToString)
            dt.Columns.Add(Columns.AccountTypeDesc.ToString)
            Return dt
        End Function
    End Class
    Friend NotInheritable Class CInstrumentsDropdown
        Private NotInheritable Class LocalTagBits : Inherits TagBits
            Friend ReadOnly Instruments As IEnumerable(Of CInstrument)
            Friend ReadOnly InstrumentReader As IInstrumentReader
            Friend Sub New(commonObjects As CCommonObjects, instruments As IEnumerable(Of CInstrument), instrumentReader As IInstrumentReader)
                MyBase.New(commonObjects)
                Me.Instruments = instruments
                Me.InstrumentReader = instrumentReader
            End Sub
        End Class
        Friend Enum Columns
            Code
            Description
            InstrumentTypeCode
            Rate
            RateUpdated
            ProviderLinkCode
            CurrencyCode
            ProviderMultiplier
            Notes
            HedgingGroupCode
        End Enum
        Friend Shared Sub SetupDropdown(Cmb As UltraDropDownBase, instruments As IEnumerable(Of CInstrument), commonObjects As CCommonObjects,
                                        instrumentReader As IInstrumentReader)
            Cmb.Tag = New LocalTagBits(commonObjects, instruments, instrumentReader)
            Dim dt As DataTable = GetBlankDt()
            For Each instrument In instruments
                Dim dr = dt.NewRow
                dr(Columns.Code.ToString) = instrument.Code
                dr(Columns.Description.ToString) = instrument.Description
                dr(Columns.InstrumentTypeCode.ToString) = instrument.InstrumentType.Code
                dr(Columns.Rate.ToString) = instrument.Rate
                If instrument.RateUpdated.HasValue Then
                    dr(Columns.RateUpdated.ToString) = instrument.RateUpdated.Value
                End If
                dr(Columns.ProviderLinkCode.ToString) = instrument.ProviderLinkCode
                dr(Columns.CurrencyCode.ToString) = instrument.CurrencyCode
                dr(Columns.ProviderMultiplier.ToString) = instrument.ProviderMultiplier
                dr(Columns.Notes.ToString) = instrument.Notes
                dr(Columns.HedgingGroupCode.ToString) = instrument.HedgingGroupCode
                dt.Rows.Add(dr)
            Next
            RemoveHandler Cmb.TextChanged, AddressOf TextChanged
            AddHandler Cmb.TextChanged, AddressOf TextChanged
            If TypeOf Cmb Is UltraCombo Then
                Dim combo = CType(Cmb, UltraCombo)
                RemoveHandler combo.InitializeLayout, AddressOf InitializeLayout
                AddHandler combo.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler combo.InitializeRow, AddressOf InitializeRow
                AddHandler combo.InitializeRow, AddressOf InitializeRow
            ElseIf TypeOf Cmb Is UltraDropDown Then
                Dim dropdown = CType(Cmb, UltraDropDown)
                RemoveHandler dropdown.InitializeLayout, AddressOf InitializeLayout
                AddHandler dropdown.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler dropdown.InitializeRow, AddressOf InitializeRow
                AddHandler dropdown.InitializeRow, AddressOf InitializeRow
            End If
            Cmb.DataSource = dt
        End Sub

        Private Shared Sub TextChanged(sender As Object, e As EventArgs)
            Dim cmb As UltraDropDownBase = CType(sender, UltraDropDownBase)
            Dim tagBits As LocalTagBits = CType(cmb.Tag, LocalTagBits)
            Try
                Dim instrument = tagBits.Instruments.Where(Function(c) c.Code.Equals(cmb.Text, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault
                Dim instrumentType As EInstrumentType
                If instrument IsNot Nothing Then
                    instrumentType = instrument.InstrumentType
                    If tagBits.InstrumentReader IsNot Nothing Then
                        tagBits.InstrumentReader.ReadInstrument(instrument)
                    End If
                End If
                If TypeOf cmb Is UltraCombo Then
                    Dim combo = CType(cmb, UltraCombo)
                    combo.Appearance.ForeColor = CColours.InstrumentType(instrumentType)
                End If
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            If e.ReInitialize Then
                Return
            End If
            Dim cmb As UltraDropDownBase = CType(sender, UltraDropDownBase)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                Dim instrument As CInstrument = GetInstrumentFromRow(e.Row)
                e.Row.CellAppearance.ForeColor = CColours.InstrumentType(instrument.InstrumentType)
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Function GetInstrumentFromRow(row As UltraGridRow) As CInstrument
            Dim sCode As String = row.Cells(Columns.Code.ToString).Text
            Dim sInstrumentType As String = row.Cells(Columns.InstrumentTypeCode.ToString).Text
            Dim instrumentType As EInstrumentType = GetInstrumentTypeFromCode(sInstrumentType, True)
            Dim sDesc As String = row.Cells(Columns.Description.ToString).Text
            Dim rRate As Decimal = CDatabase.DbToDecimal(row.Cells(Columns.Rate.ToString).Value)
            Dim rateUpdated As Date? = Nothing
            If Not IsDBNull(row.Cells(Columns.RateUpdated.ToString).Value) Then
                rateUpdated = CType(row.Cells(Columns.RateUpdated.ToString).Value, Date)
            End If
            Dim sProviderLinkCode As String = row.Cells(Columns.ProviderLinkCode.ToString).Text
            Dim sCurrencyCode As String = row.Cells(Columns.CurrencyCode.ToString).Text
            Dim rProviderMultiplier As Decimal = CDec(row.Cells(Columns.ProviderMultiplier.ToString).Value)
            Dim sNotes = row.Cells(Columns.Notes.ToString).Text
            Dim sHedgingGroupCode = row.Cells(Columns.HedgingGroupCode.ToString).Text
            Dim instrument As New CInstrument(sCode, instrumentType, sDesc, rRate, rateUpdated, sProviderLinkCode,
                                              sCurrencyCode, rProviderMultiplier, sNotes, sHedgingGroupCode)
            Return instrument
        End Function

        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim cmb As UltraDropDownBase = CType(sender, UltraDropDownBase)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.Code.ToString
                            col.Header.Caption = "Code"
                            col.Width = cmb.Width
                        Case Columns.Description.ToString
                            col.Header.Caption = "Description"
                            col.Width = cmb.Width * 3
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Function GetBlankDt() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add(Columns.Code.ToString)
            dt.Columns.Add(Columns.Description.ToString)
            dt.Columns.Add(Columns.InstrumentTypeCode.ToString)
            dt.Columns.Add(Columns.Rate.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.RateUpdated.ToString, GetType(Date))
            dt.Columns.Add(Columns.ProviderLinkCode.ToString)
            dt.Columns.Add(Columns.CurrencyCode.ToString)
            dt.Columns.Add(Columns.ProviderMultiplier.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.Notes.ToString)
            dt.Columns.Add(Columns.HedgingGroupCode.ToString)
            Return dt
        End Function
    End Class
    Friend NotInheritable Class CTransactionTypes
        Private Enum Columns
            TypeName
        End Enum
        Friend Shared Sub SetupNamesDropdown(cmb As UltraCombo, commonObjects As CCommonObjects)
            cmb.Tag = New TagBits(commonObjects)
            Dim dt As DataTable = GetBlankDt()
            For Each transactionType As ETransactionType In [Enum].GetValues(GetType(ETransactionType))
                Dim dr = dt.NewRow
                dr(Columns.TypeName.ToString) = transactionType.ToString
                dt.Rows.Add(dr)
            Next
            RemoveHandler cmb.InitializeLayout, AddressOf InitializeLayout
            AddHandler cmb.InitializeLayout, AddressOf InitializeLayout
            RemoveHandler cmb.InitializeRow, AddressOf InitializeRow
            AddHandler cmb.InitializeRow, AddressOf InitializeRow
            RemoveHandler cmb.TextChanged, AddressOf TextChanged
            AddHandler cmb.TextChanged, AddressOf TextChanged
            cmb.DataSource = dt
        End Sub

        Private Shared Sub TextChanged(sender As Object, e As EventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                Dim tt As ETransactionType = GetTransactionTypeFromDesc(cmb.Text, True)
                Dim c As Color = CColours.TransactionType(tt)
                cmb.Appearance.ForeColor = c
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                If e.ReInitialize Then
                    Return
                End If
                Dim sTypeDesc As String = e.Row.Cells(Columns.TypeName.ToString).Text
                Dim tt As ETransactionType = GetTransactionTypeFromDesc(sTypeDesc, True)
                e.Row.CellAppearance.ForeColor = CColours.TransactionType(tt)
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.TypeName.ToString
                            col.Width = cmb.Width
                            col.Header.Caption = "Type"
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Function GetBlankDt() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add(Columns.TypeName.ToString)
            Return dt
        End Function
    End Class

    Friend NotInheritable Class CHedgingGroupsGropdown
        Const COL_HEDGINGGROUPCODE = "code"
        Friend Shared Sub SetupDropdown(combo As UltraCombo, allInstruments As IEnumerable(Of CInstrument))
            Dim dt = New DataTable
            dt.Columns.Add(COL_HEDGINGGROUPCODE)
            Dim codes = allInstruments.Select(Function(c) c.HedgingGroupCode.ToUpper).Distinct.Where(Function(c) Not String.IsNullOrEmpty(c)).OrderBy(Function(c) c)
            For Each hCode In codes
                Dim dr = dt.NewRow
                dr(COL_HEDGINGGROUPCODE) = hCode
                dt.Rows.Add(dr)
            Next
            RemoveHandler combo.InitializeLayout, AddressOf InitializeLayout
            AddHandler combo.InitializeLayout, AddressOf InitializeLayout
            combo.DataSource = dt
        End Sub
        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            GridDefaults(e.Layout)
            With e.Layout.Bands(0).Columns(COL_HEDGINGGROUPCODE)
                .Header.Caption = "Hedging Group"
                .Width = 100
            End With
        End Sub
    End Class
    Friend NotInheritable Class CCurrenciesDropdown
        Enum Columns
            ISO
            Name
            Rate
            Favourite
        End Enum
        Friend Shared Sub SetupDropdown(cmb As UltraCombo, commonObjects As CCommonObjects, all As IEnumerable(Of CCurrencyDetail))
            cmb.Tag = New TagBits(commonObjects)
            Dim dt = GetBlankDt()
            For Each c In all.OrderByDescending(Function(d) d.Favourite).ThenBy(Function(d) d.CurrencyCode)
                Dim dr = dt.NewRow
                dr(Columns.ISO.ToString) = c.CurrencyCode
                dr(Columns.Name.ToString) = c.CurrencyName
                If c.CurrencyRate.HasValue Then
                    dr(Columns.Rate.ToString) = c.CurrencyRate.Value
                End If
                dr(Columns.Favourite.ToString) = c.Favourite
                dt.Rows.Add(dr)
            Next
            RemoveHandler cmb.InitializeLayout, AddressOf InitializeLayout
            AddHandler cmb.InitializeLayout, AddressOf InitializeLayout
            RemoveHandler cmb.InitializeRow, AddressOf InitializeRow
            AddHandler cmb.InitializeRow, AddressOf InitializeRow
            cmb.DataSource = dt
        End Sub

        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            If e.ReInitialize Then
                Return
            End If
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                Dim fFavourite As Boolean = CBool(e.Row.Cells(Columns.Favourite.ToString).Value)
                If fFavourite Then
                    e.Row.CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                End If
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim cmb As UltraCombo = CType(sender, UltraCombo)
            Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                With e.Layout.Override

                End With
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.ISO.ToString
                            col.Header.Caption = "ISO"
                            col.Width = cmb.Width
                        Case Columns.Name.ToString
                            col.Header.Caption = "Name"
                            col.Width = cmb.Width * 2
                        Case Columns.Rate.ToString
                            col.Header.Caption = "Rate"
                            col.Width = cmb.Width
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Shared Function GetBlankDt() As DataTable
            Dim dt As New DataTable
            dt.Columns.Add(Columns.ISO.ToString)
            dt.Columns.Add(Columns.Name.ToString)
            dt.Columns.Add(Columns.Rate.ToString, GetType(Decimal))
            dt.Columns.Add(Columns.Favourite.ToString, GetType(Boolean))
            Return dt
        End Function
    End Class

    Friend NotInheritable Class CNetworksDropdown
        Friend Shared Sub SetupDropdown(cmb As UltraCombo, all As IEnumerable(Of CNetwork), commonObjects As CCommonObjects)
            cmb.Tag = New TagBits(commonObjects)
            Dim dt = GetBlankDt()
            For Each network In all
                Dim dr = dt.NewRow
                dr(Columns.NetworkId.ToString) = network.NetworkId
                dr(Columns.Description.ToString) = network.Description
                If network.Colour.HasValue Then
                    dr(Columns.Colour.ToString) = network.Colour.Value.ToArgb
                End If
                dt.Rows.Add(dr)
            Next
            RemoveHandler cmb.InitializeLayout, AddressOf InitializeLayout
            AddHandler cmb.InitializeLayout, AddressOf InitializeLayout
            RemoveHandler cmb.InitializeRow, AddressOf InitializeRow
            AddHandler cmb.InitializeRow, AddressOf InitializeRow
            cmb.DataSource = dt
        End Sub
        Private Shared Function GetBlankDt() As DataTable
            Dim dt = New DataTable
            dt.Columns.Add(Columns.NetworkId.ToString)
            dt.Columns.Add(Columns.Description.ToString)
            dt.Columns.Add(Columns.Colour.ToString, GetType(Integer))
            Return dt
        End Function
        Private Enum Columns
            NetworkId
            Description
            Colour
        End Enum
        Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
            Dim cmb = CType(sender, UltraCombo)
            Dim tagBits = CType(cmb.Tag, TagBits)
            Try
                Dim backColour As Color = Nothing
                If Not IsDBNull(e.Row.Cells(Columns.Colour.ToString).Value) Then
                    Dim iColour = CInt(e.Row.Cells(Columns.Colour.ToString).Value)
                    Try
                        Dim c As Color = Color.FromArgb(iColour)
                        backColour = c
                    Catch ex As Exception
                    End Try
                End If
                e.Row.CellAppearance.BackColor = backColour
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
            Dim cmb = CType(sender, UltraCombo)
            Dim tagBits = CType(cmb.Tag, TagBits)
            Try
                GridDefaults(e.Layout)
                For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                    Select Case col.Key
                        Case Columns.NetworkId.ToString
                            col.Header.Caption = $"Network ID"
                            col.Width = cmb.Width
                            col.Case = [Case].Upper
                        Case Columns.Description.ToString
                            col.Header.Caption = $"Network Description"
                            col.Width = 250
                        Case Else
                            col.Hidden = True
                    End Select
                Next
            Catch ex As Exception
                tagBits.CommonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class
End Class
