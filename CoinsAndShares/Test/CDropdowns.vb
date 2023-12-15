Imports Infragistics.Win.UltraWinGrid

Imports Infragistics.Win
Imports CoinsAndShares.Accounts.MAccounts
Imports CoinsAndShares.Instruments.MInstuments

Namespace Test
    Friend Class CDropdowns
        Friend Class InstrumentsDropdown
            Private Enum Columns
                InstrumentCode
                Description
                InstrumentTypeCode
            End Enum
            Friend Shared Sub SetupDropdown(cmb As UltraCombo, all As IEnumerable(Of CInstrument), commonObjects As CCommonObjects)
                cmb.Tag = New TagBits(commonObjects)
                Dim dt = GetDt()
                For Each instrument In all.OrderBy(Function(c) c.InstrumentCode)
                    Dim dr = dt.NewRow
                    dr(Columns.InstrumentCode.ToString) = instrument.InstrumentCode
                    dr(Columns.Description.ToString) = instrument.Description
                    dr(Columns.InstrumentTypeCode.ToString) = instrument.InstrumentType.Code
                    dt.Rows.Add(dr)
                Next
                RemoveHandler cmb.InitializeLayout, AddressOf InitializeLayout
                AddHandler cmb.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler cmb.InitializeRow, AddressOf InitializeRow
                AddHandler cmb.InitializeRow, AddressOf InitializeRow
                cmb.DataSource = dt
            End Sub
            Private Shared Sub InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
                Dim cmb = DirectCast(sender, UltraCombo)
                Dim tagbits = DirectCast(cmb.Tag, TagBits)
                Try
                    GridDefaults(e.Layout)
                    For Each col As UltraGridColumn In e.Layout.Bands(0).Columns
                        Select Case col.Key
                            Case Columns.InstrumentCode.ToString
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
                    tagbits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                If e.ReInitialize Then
                    Return
                End If
                Dim cmb As UltraDropDownBase = CType(sender, UltraDropDownBase)
                Dim tagBits As TagBits = CType(cmb.Tag, TagBits)
                Try
                    Dim instrumentType = GetInstrumentTypeFromCode(e.Row.Cells(Columns.InstrumentTypeCode.ToString).Text, True)
                    e.Row.CellAppearance.ForeColor = CColours.InstrumentType(instrumentType)
                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
            Private Shared Function GetDt() As DataTable
                Dim dt = New DataTable
                dt.Columns.Add(Columns.InstrumentCode.ToString)
                dt.Columns.Add(Columns.Description.ToString)
                dt.Columns.Add(Columns.InstrumentTypeCode.ToString)
                Return dt
            End Function
        End Class
        Friend Class AccountsDropdown
            Private Enum Columns
                AccountCode
                AccountName
                AccountTypeCode
                CashBalance
            End Enum
            Friend Shared Sub SetupDropdown(cmb As UltraCombo, all As IEnumerable(Of CAccount), commonObjects As CCommonObjects)
                cmb.Tag = New TagBits(commonObjects)
                Dim dt = New DataTable
                dt.Columns.Add(Columns.AccountCode.ToString)
                dt.Columns.Add(Columns.AccountName.ToString)
                dt.Columns.Add(Columns.AccountTypeCode.ToString)
                dt.Columns.Add(Columns.CashBalance.ToString, GetType(Decimal))

                For Each account In all
                    Dim dr = dt.NewRow()
                    dr(Columns.AccountCode.ToString) = account.AccountCode
                    dr(Columns.AccountName.ToString) = account.AccountName
                    dr(Columns.AccountTypeCode.ToString) = account.AccountType.Code
                    dr(Columns.CashBalance.ToString) = account.GetCashBalance()
                    dt.Rows.Add(dr)
                Next

                RemoveHandler cmb.InitializeLayout, AddressOf InitializeLayout
                AddHandler cmb.InitializeLayout, AddressOf InitializeLayout
                RemoveHandler cmb.InitializeRow, AddressOf InitializeRow
                AddHandler cmb.InitializeRow, AddressOf InitializeRow

                cmb.DataSource = dt
            End Sub
            Private Shared Sub InitializeRow(sender As Object, e As InitializeRowEventArgs)
                Dim cmb = CType(sender, UltraCombo)
                Dim tagBits = CType(cmb.Tag, TagBits)
                Try
                    Dim accountTypeCode = e.Row.Cells(Columns.AccountTypeCode.ToString).Text
                    Dim accountType = Accounts.GetAccountTypeFromCode(accountTypeCode, True)
                    e.Row.CellAppearance.ForeColor = CColours.AccountType(accountType)
                    Dim cashBalance = CDec(e.Row.Cells(Columns.CashBalance.ToString).Value)
                    Dim fBold = cashBalance <> 0
                    e.Row.CellAppearance.FontData.Bold = If(fBold, DefaultableBoolean.True, DefaultableBoolean.False)
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
                            Case Columns.AccountCode.ToString
                                col.Width = cmb.Width
                                col.Header.Caption = "Account Code"
                            Case Columns.AccountName.ToString
                                col.Width = 200
                                col.Header.Caption = "Name"
                            Case Columns.CashBalance.ToString
                                col.Width = 85
                                col.Header.Caption = "Cash Balance"
                                col.CellAppearance.TextHAlign = HAlign.Right
                                col.Format = "c2"
                            Case Else
                                col.Hidden = True
                        End Select
                    Next

                Catch ex As Exception
                    tagBits.CommonObjects.Errors.Handle(ex)
                End Try
            End Sub
        End Class
        Friend Class NetworksDropdown
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
        Friend Class AccountTypesDropdown
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
    End Class

End Namespace
