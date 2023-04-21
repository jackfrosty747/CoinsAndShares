Imports Infragistics.Win.UltraWinGrid
Imports CoinsAndShares.Accounts
Imports Infragistics.Win

Namespace Test
    Friend Class CDropdowns
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
                    Dim accountType = GetAccountTypeFromCode(accountTypeCode, True)
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

    End Class

End Namespace
