Imports System.Deployment.Application
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports CoinsAndShares.Accounts
Imports CoinsAndShares.Accounts.MAccounts
Imports CoinsAndShares.BackupRestore
Imports CoinsAndShares.Charts
Imports CoinsAndShares.Currencies
Imports CoinsAndShares.Dashboard
Imports CoinsAndShares.Electricity
Imports CoinsAndShares.Hedging
Imports CoinsAndShares.Instruments
Imports CoinsAndShares.Maintenance
Imports CoinsAndShares.Networks
Imports CoinsAndShares.Notes
Imports CoinsAndShares.Rates
Imports CoinsAndShares.Settings
Imports CoinsAndShares.Snapshots
Imports CoinsAndShares.SQLInterface
Imports CoinsAndShares.Transactions

Friend Class FMdi

    Private Const SHOW_SHORTCUTS = True

    Private ReadOnly m_commonObjects As CCommonObjects
    Private ReadOnly m_dashboard As UDashboard

    Private m_shortcutPanel As Panel

    Friend Sub New(database As CDatabase, errors As CErrors)

        InitializeComponent()

        m_commonObjects = New CCommonObjects(database, errors, Me)
        Icon = Icon.FromHandle(My.Resources.chart_up_color.GetHicon)

        Text = Application.ProductName
        Dim buildDateTime = GetBuildDateTime()

        If buildDateTime.HasValue Then
            Text &= " - Build " & buildDateTime.Value.ToShortDateString & " " & buildDateTime.Value.ToShortTimeString
        End If


        m_dashboard = New UDashboard With {
            .Parent = Me,
            .Dock = DockStyle.Right,
            .Visible = False
        }

        m_dashboard.Initialise(m_commonObjects)
        ShowDashboard()

        If SHOW_SHORTCUTS Then
            LoadShortcuts()
        End If

        ShowPortfolioValue

    End Sub

    Private Sub ShowPortfolioValue()
        TsslPortfolioValue.Text = "Loading Portfolio Value..."
        StatusStrip1.Refresh()
        Task.Run(Sub()
                     Dim value = MAssets.GetHodlings(m_commonObjects, DateTime.Now.Date).Item2

                     ' Update UI safely using Invoke
                     Me.Invoke(Sub()
                                   TsslPortfolioValue.Text = $"Portfolio Value: {value:c2}"
                               End Sub)
                 End Sub)
    End Sub

    Private Sub LoadShortcuts()
        ' Remove
        If m_shortcutPanel IsNot Nothing Then
            For i = m_shortcutPanel.Controls.Count - 1 To 0 Step -1
                Dim ctl = m_shortcutPanel.Controls(i)
                ctl.Dispose()
            Next
            Controls.Remove(m_shortcutPanel)
            m_shortcutPanel.Dispose()
        End If

        ' Recreate panel
        m_shortcutPanel = New Panel With {
            .Parent = Me,
            .Dock = DockStyle.Left,
            .Width = 38,
            .Padding = New Padding(5, 5, 5, 5)
        }
        m_shortcutPanel.BringToFront()

        Dim networks = m_commonObjects.Networks
        Dim accounts = m_commonObjects.Accounts
        Dim shortcuts = accounts.GetAll().Where(Function(c) c.IncludeOnShortcuts).OrderBy(Function(c) c.AccountCode)

        ' (Re)load account buttons
        Dim g = CreateGraphics()
        Dim buttonFont = Font
        Const PADDING = 5
        For Each account In shortcuts
            Dim textSize = g.MeasureString(account.AccountCode, buttonFont)
            Dim btn = New Button With {
                .Parent = m_shortcutPanel,
                .Tag = account.AccountCode,
                .AutoSize = False,
                .Dock = DockStyle.Top,
                .Height = PADDING + CInt(textSize.Width) + PADDING
            }
            AddHandler btn.Click, Sub(sender As Object, e As EventArgs)
                                      Dim b = CType(sender, Button)
                                      Dim sAccountCode = CStr(b.Tag)

                                      Dim frmAccount As FAccount = Nothing
                                      For Each frm As Form In MdiChildren
                                          Dim frmTest = TryCast(frm, FAccount)
                                          If frmTest IsNot Nothing AndAlso frmTest.AccountCode.Equals(sAccountCode, StringComparison.InvariantCultureIgnoreCase) Then
                                              frmAccount = frmTest
                                              Exit For
                                          End If
                                      Next
                                      If frmAccount Is Nothing Then
                                          Cursor = Cursors.WaitCursor
                                          Try
                                              frmAccount = New FAccount(m_commonObjects, sAccountCode) With {
                                                    .MdiParent = Me
                                                }
                                              frmAccount.Show()
                                          Finally
                                              Cursor = Cursors.Default
                                          End Try
                                      End If
                                      frmAccount.Activate()
                                  End Sub
            AddHandler btn.Paint, Sub(sender As Object, e As PaintEventArgs)
                                      Dim b = CType(sender, Button)
                                      Dim sAccountCode = CStr(b.Tag)
                                      Dim iTextTop As Integer = CInt((btn.Width - e.Graphics.MeasureString(sAccountCode, buttonFont).Height) / 2)
                                      Dim backColour = networks.GetColour(account)

                                      Dim bgRect = New Rectangle(0, 0, b.Width, b.Height)
                                      bgRect.Inflate(-2, -2)
                                      With e.Graphics
                                          .FillRectangle(New SolidBrush(backColour), 1, 1, bgRect.Width, bgRect.Height)
                                          .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                                          .TranslateTransform(0, b.Height)
                                          .RotateTransform(270)
                                          .DrawString(sAccountCode, buttonFont, Brushes.Black, 4, iTextTop)
                                      End With
                                  End Sub

            Dim lbl = New Label With {
                .Parent = m_shortcutPanel,
                .Dock = DockStyle.Top,
                .Height = PADDING
            }
        Next

    End Sub

    Private Sub MnuFileExit_Click(sender As Object, e As EventArgs) Handles MnuFileExit.Click
        Try
            Close()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        End Try
    End Sub

    Private Sub MnuSetupInstruments_Click(sender As Object, e As EventArgs) Handles MnuSetupInstruments.Click
        Try
            Dim frmInstruments = MdiChildren.Where(Function(c) TypeOf c Is FInstruments).FirstOrDefault
            If frmInstruments Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmInstruments = New FInstruments(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmInstruments.Show()
            End If
            frmInstruments.Activate()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuAccountList_Click(sender As Object, e As EventArgs) Handles MnuAccountList.Click
        Try
            Dim frmAccountList = MdiChildren.Where(Function(c) TypeOf c Is FAccountList).FirstOrDefault
            If frmAccountList Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmAccountList = New FAccountList(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmAccountList.Show()
            End If
            frmAccountList.Activate()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuTransactionHistory_Click(sender As Object, e As EventArgs) Handles MnuTransactionHistory.Click
        Try
            Dim frmAllTransactions = MdiChildren.Where(Function(c) TypeOf c Is FAllTransactions).FirstOrDefault
            If frmAllTransactions Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmAllTransactions = New FAllTransactions(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmAllTransactions.Show()
            End If
            frmAllTransactions.Activate()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFileViewDashboard_Click(sender As Object, e As EventArgs) Handles MnuFileViewDashboard.Click
        Try
            ShowDashboard()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        End Try
    End Sub

    Private Sub ShowDashboard()
        m_dashboard.Visible = True
        m_dashboard.BringToFront()
    End Sub

    Private Sub MnuFileCurrencies_Click(sender As Object, e As EventArgs) Handles MnuFileCurrencies.Click
        Try
            Dim frmCurrencies = MdiChildren.Where(Function(c) TypeOf c Is FCurrencies).FirstOrDefault
            If frmCurrencies Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmCurrencies = New FCurrencies(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmCurrencies.Show()
            End If
            frmCurrencies.Activate()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFileBackupBackup_Click(sender As Object, e As EventArgs) Handles MnuFileBackupBackup.Click
        Try
            Dim settings = New CSettings(m_commonObjects)
            Using sfc As New SaveFileDialog
                With sfc
                    If Not String.IsNullOrEmpty(settings.DefaultBackupPath) AndAlso IO.Directory.Exists(settings.DefaultBackupPath) Then
                        .InitialDirectory = settings.DefaultBackupPath
                    End If
                    .FileName = $"coins {Now.Date:dd}{Now.Date:MM}{Now.Date:yy}.json"
                    .AddExtension = True
                    .DefaultExt = ".json"
                    .Filter = "JSon Files (*.json)|*.json"
                    .OverwritePrompt = True
                End With
                Dim res = sfc.ShowDialog
                If res = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    CBackupRestore.Backup(m_commonObjects, sfc.FileName)
                    MessageBox.Show($"Data exported to {sfc.FileName}", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFileBackupRestore_Click(sender As Object, e As EventArgs) Handles MnuFileBackupRestore.Click
        Const PROMPT = "RESTORE"
        Try
            Using ofd As New OpenFileDialog
                With ofd
                    .DefaultExt = ".json"
                    .Filter = "JSon Files (*.json)|*.json"
                End With
                Dim res = ofd.ShowDialog
                If res = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim jsonDatabase = CBackupRestore.ReadFile(ofd.FileName)
                    Dim sRet = InputBox($"This will overwrite the current database.  Are you sure?  Type {PROMPT} to continue", Text)
                    If String.IsNullOrEmpty(sRet) Then
                        Return
                    ElseIf Not sRet.Equals(PROMPT, StringComparison.CurrentCultureIgnoreCase) Then
                        Throw New Exception(My.Resources.Error_IncorrectResponse)
                    End If
                    Cursor = Cursors.WaitCursor
                    CBackupRestore.Restore(m_commonObjects, jsonDatabase)
                    m_commonObjects.ClearCache()
                    m_commonObjects.RefreshForms()
                    MessageBox.Show("Database restored", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFileDatabaseCleardown_Click(sender As Object, e As EventArgs) Handles MnuFileDatabaseCleardown.Click
        Const PROMPT = "Cleardown"
        Try
            Dim sRet = InputBox($"All data will be deleted.  This cannot be undone.  Type {PROMPT} to confirm", Text)
            If String.IsNullOrEmpty(sRet) Then
                Return
            ElseIf Not PROMPT.Equals(sRet, StringComparison.InvariantCultureIgnoreCase) Then
                Throw New Exception(My.Resources.Error_IncorrectResponse)
            End If
            Cursor = Cursors.WaitCursor
            m_commonObjects.Database.Cleardown()
            m_commonObjects.RefreshForms()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFileSettings_Click(sender As Object, e As EventArgs) Handles MnuFileSettings.Click
        Try
            Using frm = New FSettings(m_commonObjects)
                frm.ShowDialog()
                If frm.OkPressed Then
                    Cursor = Cursors.WaitCursor
                    m_commonObjects.RefreshForms()
                End If
            End Using
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuSnapshotsTakeSnapshot_Click(sender As Object, e As EventArgs) Handles MnuSnapshotsTakeSnapshot.Click
        Try
            Dim frmSnapshot = MdiChildren.Where(Function(c) TypeOf c Is FSnapshots).FirstOrDefault
            If frmSnapshot Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmSnapshot = New FSnapshots(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmSnapshot.Show()
            End If
            frmSnapshot.BringToFront()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuCharts_Click(sender As Object, e As EventArgs) Handles MnuReports.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frmReports = New FReports(m_commonObjects) With {
                .MdiParent = Me
                }
            frmReports.Show()
            frmReports.BringToFront()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFileDatabaseSqlInterface_Click(sender As Object, e As EventArgs) Handles MnuFileDatabaseSqlInterface.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frmSqlInterface = New FSqlInterface(m_commonObjects) With {
                .MdiParent = Me
                }
            frmSqlInterface.Show()
            frmSqlInterface.BringToFront()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TsmiInstrumentRateUpdater_Click(sender As Object, e As EventArgs) Handles TsmiInstrumentRateUpdater.Click
        Try
            Dim frmSharePriceScraper = MdiChildren.Where(Function(c) TypeOf c Is FSharePriceScraper).FirstOrDefault
            If frmSharePriceScraper Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmSharePriceScraper = New FSharePriceScraper(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmSharePriceScraper.Show()
            End If
            frmSharePriceScraper.Activate()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuFileElectricityRates_Click(sender As Object, e As EventArgs) Handles MnuFileElectricityRates.Click
        Try
            Dim frmElectricity = MdiChildren.Where(Function(c) TypeOf c Is FElectricity).FirstOrDefault
            If frmElectricity Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmElectricity = New FElectricity(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmElectricity.Show()
            End If
            frmElectricity.Activate()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TsmiInstrumentHedging_Click(sender As Object, e As EventArgs) Handles TsmiInstrumentHedging.Click
        Try
            Dim frmHedging = MdiChildren.Where(Function(c) TypeOf c Is FHedging).FirstOrDefault
            If frmHedging Is Nothing Then
                Cursor = Cursors.WaitCursor
                frmHedging = New FHedging(m_commonObjects) With {
                    .MdiParent = Me
                }
                frmHedging.Show()
            End If
            frmHedging.Activate()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuAssets_Click(sender As Object, e As EventArgs) Handles MnuAssets.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frmAssets = New FAssets(m_commonObjects) With {
                .MdiParent = Me
                }
            frmAssets.Show()
            frmAssets.BringToFront()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuInterest_Click(sender As Object, e As EventArgs) Handles MnuInterest.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frmInterest = New FInterest(m_commonObjects) With {
                .MdiParent = Me
                }
            frmInterest.Show()
            frmInterest.BringToFront()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuNotes_Click(sender As Object, e As EventArgs) Handles MnuNotes.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frmNotes = New FNotes(m_commonObjects) With {
                .MdiParent = Me
                }
            frmNotes.Show()
            frmNotes.BringToFront()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuAccountsNetworks_Click(sender As Object, e As EventArgs) Handles MnuAccountsNetworks.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frmNetworks = New FNetworks(m_commonObjects)
            frmNetworks.ShowDialog()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuHelpAbout_Click(sender As Object, e As EventArgs) Handles MnuHelpAbout.Click
        Try
            Using frmAbout = New FAbout(m_commonObjects)
                frmAbout.ShowDialog()
            End Using
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        End Try
    End Sub

    Private Sub MnuFileDatabaseMaintenance_Click(sender As Object, e As EventArgs) Handles MnuFileDatabaseMaintenance.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim frmMaintenance = New FMaintenance(m_commonObjects) With {
                .MdiParent = Me
                }
            frmMaintenance.Show()
            frmMaintenance.BringToFront()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuReportsSavingsTax_Click(sender As Object, e As EventArgs) Handles MnuReportsSavingsTax.Click
        Dim accountTypes = New List(Of EAccountType) From {EAccountType.Bank_Account, EAccountType.Share_Account}

        Dim interestDescription = EDescriptionPresets.Interest.ToString.Replace("_", " ")

        Try
            Dim taxYearStartInclusive As Date
            Try
                ' Get the current date
                Dim currentDate As Date = Date.Today
                ' Calculate the tax year start date based on the current date
                Dim taxYearStart As Date
                If currentDate.Month > 4 Or (currentDate.Month = 4 And currentDate.Day >= 6) Then
                    ' If the current date is on or after April 6th, use the current year's April 6th
                    taxYearStart = New Date(currentDate.Year, 4, 6)
                Else
                    ' If the current date is before April 6th, use the previous year's April 6th
                    taxYearStart = New Date(currentDate.Year - 1, 4, 6)
                End If
                Dim sRet = InputBox("Enter the tax year start (inclusive)", Text, taxYearStart.ToShortDateString)
                If String.IsNullOrEmpty(sRet) Then
                    Return
                ElseIf Not Date.TryParse(sRet, taxYearStartInclusive) Then
                    Throw New Exception(My.Resources.Error_NotAValidDate)
                End If
            Catch ex As Exception
                Throw
            End Try

            Dim allowance As Decimal = 1000
            Try
                Dim sRet = InputBox("Enter tax allowace", Text, allowance.ToString("c2"))
                If String.IsNullOrEmpty(sRet) Then
                    Return
                ElseIf Not Decimal.TryParse(sRet, Globalization.NumberStyles.Currency, Globalization.CultureInfo.CurrentCulture, allowance) Then
                    Throw New Exception(My.Resources.Error_CurrencyAmountNotValid)
                End If
            Catch ex As Exception
                Throw
            End Try

            Dim taxRate As Decimal = 20
            Try
                Dim sRet = InputBox("Enter tax rate", Text, taxRate.ToString() & "%").Replace("%", "")
                If String.IsNullOrEmpty(sRet) Then
                    Return
                ElseIf Not Decimal.TryParse(sRet, taxRate) Then
                    Throw New Exception(My.Resources.Error_IncorrectResponse)
                End If
            Catch ex As Exception
                Throw
            End Try


            Cursor = Cursors.WaitCursor

            Dim transactions = New CTransactions(m_commonObjects)
            Dim accounts = New CAccounts(m_commonObjects)

            Dim selectedAccounts = accounts.GetAll.Where(Function(c) accountTypes.Contains(c.AccountType))
            Dim nonTaxedAccounts = accounts.GetAll.Where(Function(c) c.NonTaxable)

            selectedAccounts = selectedAccounts.Where(Function(c) Not nonTaxedAccounts.Any(Function(d) d.AccountCode.Equals(c.AccountCode, StringComparison.CurrentCultureIgnoreCase)))

            Dim selectedAccountCodes = selectedAccounts.Select(Function(c) c.AccountCode)

            Dim all = transactions.GetAll

            'MsgBox($"testing: {all.Where(Function(c) c.Description.ToUpper = interestDescription.ToUpper And
            '                                 c.TransDate > taxYearStartInclusive.Date.AddDays(-1) AndAlso c.TransDate < taxYearStartInclusive.Date.AddYears(1) And
            '                                 selectedAccountCodes.Any(Function(d) d.Equals(c.AccountCode, StringComparison.CurrentCultureIgnoreCase))).Sum(Function(c) c.Amount)}")

            ' Only interest records
            all = all.Where(Function(c) c.Description.Equals(interestDescription, StringComparison.CurrentCultureIgnoreCase))

            ' Only records from this tax year
            all = all.Where(Function(c) c.TransDate > taxYearStartInclusive.Date.AddDays(-1) AndAlso c.TransDate < taxYearStartInclusive.Date.AddYears(1))

            ' Exclude non taxable and types we're not interested in
            all = all.Where(Function(c) selectedAccountCodes.Any(Function(d) d.Equals(c.AccountCode, StringComparison.CurrentCultureIgnoreCase)))


            '' DEBUG
            'Dim accountCodes = all.Select(Function(c) c.AccountCode.ToUpper).Distinct.OrderBy(Function(c) c)
            'For Each accountCode In accountCodes
            '    Dim a = all.Where(Function(c) c.AccountCode.ToUpper = accountCode)
            '    MsgBox($"Account {accountCode}: {a.Sum(Function(c) c.Amount):c2}")
            'Next




            ' Total interest
            Dim interest = Math.Round(all.Sum(Function(c) c.Amount), 2)

            ' Taxable
            Dim taxable = Math.Max(interest - allowance, 0)
            Dim tax As Decimal
            If taxable > 0 Then
                tax = Math.Round(taxable / 100 * taxRate, 2)
            End If

            ' Progress through tax year
            Dim totalDaysInTaxYear As Integer = CInt((taxYearStartInclusive.AddYears(1).AddDays(-1) - taxYearStartInclusive).TotalDays)
            Dim daysPassed As Integer = CInt((Now.Date - taxYearStartInclusive).TotalDays)
            Dim percentagePassed As Double = (daysPassed / totalDaysInTaxYear) * 100
            percentagePassed = Math.Min(Math.Max(percentagePassed, 0), 100)

            ' Projected tax
            Dim projectedInterest = CDec(interest / percentagePassed * 100)
            Dim projectedTaxable = Math.Max(projectedInterest - allowance, 0)
            Dim projectedTax As Decimal
            If projectedTaxable > 0 Then
                projectedTax = Math.Round(projectedTaxable / 100 * taxRate, 2)
            End If

            Dim sMsg = $"Savings Tax Summary
========================
Tax Year: {taxYearStartInclusive.ToShortDateString} to {taxYearStartInclusive.AddYears(1).AddDays(-1).ToShortDateString} ({percentagePassed:0}% through year)
Allowance: {allowance:c2}
Tax Rate: {taxRate:0}%
Account types: {String.Join(", ", accountTypes)}
Excluding non-taxable accounts: {String.Join(", ", nonTaxedAccounts.Select(Function(c) c.AccountCode))}

Total Interest: {interest:c2}
    less {allowance:c2} allowance
Taxable: {taxable:c2}

Tax Due: {tax:c2}
-------------------
Projected Interest: {projectedInterest:c2} less allowance = {projectedTaxable:c2}
Projected Tax: {projectedTax:c2}"

            MessageBox.Show(sMsg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MnuReportsIsaTransfers_Click(sender As Object, e As EventArgs) Handles MnuReportsIsaTransfers.Click
        Try
            Dim taxYearStartInclusive As Date
            Try
                ' Get the current date
                Dim currentDate As Date = Date.Today
                ' Calculate the tax year start date based on the current date
                Dim taxYearStart As Date
                If currentDate.Month > 4 Or (currentDate.Month = 4 And currentDate.Day >= 6) Then
                    ' If the current date is on or after April 6th, use the current year's April 6th
                    taxYearStart = New Date(currentDate.Year, 4, 6)
                Else
                    ' If the current date is before April 6th, use the previous year's April 6th
                    taxYearStart = New Date(currentDate.Year - 1, 4, 6)
                End If
                Dim sRet = InputBox("Enter the tax year start (inclusive)", Text, taxYearStart.ToShortDateString)
                If String.IsNullOrEmpty(sRet) Then
                    Return
                ElseIf Not Date.TryParse(sRet, taxYearStartInclusive) Then
                    Throw New Exception(My.Resources.Error_NotAValidDate)
                End If
            Catch ex As Exception
                Throw
            End Try

            Cursor = Cursors.WaitCursor

            Dim transactions = New CTransactions(m_commonObjects)
            Dim accounts = New CAccounts(m_commonObjects)

            Dim selectedAccounts = accounts.GetAll.Where(Function(c) c.AccountType = EAccountType.Bank_Account AndAlso ContainsIgnoreCase(c.AccountName, "ISA"))
            Dim accountTransactions = transactions.GetAll().Where(Function(c) selectedAccounts.Select(Function(d) d.AccountCode.ToUpper).Contains(c.AccountCode.ToUpper))
            accountTransactions = accountTransactions.Where(Function(c) c.TransDate >= taxYearStartInclusive AndAlso c.TransDate < taxYearStartInclusive.AddYears(1))
            Dim transfers = accountTransactions.Where(Function(c) c.TransactionType = ETransactionType.Transfer)

            Dim sMsg = $"Accounts of: BANK ACCOUNT TYPE containing ISA in the name.
TRANSFER type transactions greater or equal to {taxYearStartInclusive:d} and before {taxYearStartInclusive.AddYears(1):d}.

Transfers: {transfers.Sum(Function(c) c.Amount):c}
"

            For Each i In transfers.OrderBy(Function(c) c.AccountCode.ToUpper)
                sMsg &= $"{vbNewLine}{i.AccountCode}       {i.Amount:c}"
            Next

            MessageBox.Show(sMsg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TsslPortfolioValue_Click(sender As Object, e As EventArgs) Handles TsslPortfolioValue.Click
        Try
            ShowPortfolioValue()
        Catch ex As Exception
            m_commonObjects.Errors.Handle(ex)
        End Try
    End Sub


    'Private Sub BtnTwrr_Click(sender As Object, e As EventArgs) Handles BtnTwrr.Click
    '    Try
    '        Const INSTRUMENT_CASH = "Cash"
    '        Const NETWORK_METALS = "METALS"
    '        Const NETWORK_SAVINGS = "SAVINGS"
    '        Const ACCOUNT_TYPE_CRYPTO As String = NameOf(EAccountType.Crypto)

    '        Dim transactions = New CTransactions(m_commonObjects).GetAll
    '        Dim allInstruments = New CInstruments(m_commonObjects).GetAll
    '        Dim allCurrencies = New CCurrencies(m_commonObjects).GetAll
    '        Dim allAccounts = New CAccounts(m_commonObjects).GetAll

    '        Dim totalAmountsByInstrument = transactions.
    '            GroupBy(Function(t) If(String.IsNullOrEmpty(t.InstrumentCode), INSTRUMENT_CASH, t.InstrumentCode.ToUpperInvariant())).
    '            Select(Function(g) New With {
    '                .InstrumentCode = g.Key,
    '                .TotalAmount = g.Sum(Function(t) t.Amount),
    '                .AccountCodes = g.Select(Function(t) t.AccountCode).Distinct().ToList() ' Collect account codes
    '            }).
    '            Where(Function(g) g.TotalAmount <> 0). ' Filter out zero balances
    '            Select(Function(g)
    '                       Dim instrument = allInstruments.FirstOrDefault(Function(i) i.Code.ToUpperInvariant() = g.InstrumentCode)
    '                       Dim rate As Decimal = If(instrument?.Rate, 1) ' Default rate to 1

    '                       ' Get currency exchange rate
    '                       Dim exchangeRate As Decimal = 1
    '                       If instrument IsNot Nothing AndAlso Not String.IsNullOrEmpty(instrument.CurrencyCode) Then
    '                           Dim currency = allCurrencies.FirstOrDefault(Function(c) c.CurrencyCode.Equals(instrument.CurrencyCode, StringComparison.CurrentCultureIgnoreCase))
    '                           If currency IsNot Nothing AndAlso currency.CurrencyRate.HasValue AndAlso currency.CurrencyRate.Value > 0 Then
    '                               exchangeRate = currency.CurrencyRate.Value
    '                           End If
    '                       End If
    '                       ' Calculate local currency value
    '                       Dim currentValue As Decimal = If(g.InstrumentCode = INSTRUMENT_CASH, g.TotalAmount, g.TotalAmount * rate / exchangeRate)

    '                       ' Get the NetworkId (assuming multiple accounts might be involved)
    '                       Dim networkIds = g.AccountCodes.
    '                           Select(Function(ac) allAccounts.FirstOrDefault(Function(a) a.AccountCode = ac)?.NetworkId).
    '                           Where(Function(nid) nid IsNot Nothing).
    '                           Distinct().
    '                           ToList()

    '                       ' Get AccountTypes (descriptions)
    '                       Dim accountTypes = g.AccountCodes.
    '                           Select(Function(ac) allAccounts.FirstOrDefault(Function(a) a.AccountCode = ac)?.AccountType).
    '                           Where(Function(nid) nid IsNot Nothing).
    '                           Distinct().
    '                           ToList()

    '                       ' If multiple NetworkIds exist, join them into a string; otherwise, use the single one
    '                       Dim networkIdDisplay As String = If(networkIds.Count > 0, String.Join(", ", networkIds), "N/A")
    '                       Dim accountTypeDisplay As String = If(accountTypes.Count > 0, String.Join(", ", accountTypes), "N/A")

    '                       Return New With {
    '                            .InstrumentCode = g.InstrumentCode,
    '                            .TotalAmount = g.TotalAmount,
    '                            .CurrentValue = currentValue,
    '                            .NetworkId = networkIdDisplay,
    '                            .AccountType = accountTypeDisplay
    '                        }
    '                   End Function).
    '            ToList()

    '        ' Display results
    '        'For Each item In totalAmountsByInstrument.Where(Function(c) c.InstrumentCode <> INSTRUMENT_CASH)
    '        '    Console.WriteLine($"Instrument: {item.InstrumentCode,-20} Total Amount: {item.TotalAmount,-15:0.0000000} Current Value: {item.CurrentValue,-15:C2} Account Type: {item.AccountType,-20} Network ID: {item.NetworkId,-20}")
    '        'Next

    '        Dim nonCashItems = totalAmountsByInstrument.Where(Function(c) Not c.InstrumentCode.Equals(INSTRUMENT_CASH, StringComparison.CurrentCultureIgnoreCase))
    '        Dim metals = nonCashItems.Where(Function(c) c.NetworkId.Equals(NETWORK_METALS, StringComparison.CurrentCultureIgnoreCase))
    '        Dim crypto = nonCashItems.Where(Function(c) Not c.NetworkId.Equals(NETWORK_METALS, StringComparison.CurrentCultureIgnoreCase) And c.AccountType.Contains(ACCOUNT_TYPE_CRYPTO))
    '        Dim stock = nonCashItems.Where(Function(c) Not c.NetworkId.Equals(NETWORK_METALS, StringComparison.CurrentCultureIgnoreCase) And Not c.AccountType.Contains(ACCOUNT_TYPE_CRYPTO))

    '        Console.WriteLine($"Metals: {metals.Sum(Function(c) c.CurrentValue):c2}")
    '        Console.WriteLine($"Crypto: {crypto.Sum(Function(c) c.CurrentValue):c2}")
    '        For Each item In crypto.OrderByDescending(Function(c) c.CurrentValue)
    '            Console.WriteLine($"  ->  Instrument: {item.InstrumentCode,-20} Total Amount: {item.TotalAmount,-15:0.0000000} Current Value: {item.CurrentValue,-15:C2}")
    '        Next
    '        Console.WriteLine($"Shares: {stock.Sum(Function(c) c.CurrentValue):c2}")
    '        For Each item In stock.OrderByDescending(Function(c) c.CurrentValue)
    '            Console.WriteLine($"  ->  Instrument: {item.InstrumentCode,-20} Total Amount: {item.TotalAmount,-15:0.0000000} Current Value: {item.CurrentValue,-15:C2}")
    '        Next

    '        ' TODO - Add SAVINGS

    '        'Add savings
    '        Dim cashBalances = transactions.Where(Function(t) String.IsNullOrEmpty(t.InstrumentCode)).
    '            GroupBy(Function(t) t.AccountCode). ' Group by AccountCode
    '            Select(Function(g) New With {
    '                .AccountCode = g.Key,
    '                .TotalCashBalance = g.Sum(Function(t) t.Amount)
    '            }).ToList()
    '        Dim savings = From account In allAccounts
    '                      Where account.NetworkId.Equals(NETWORK_SAVINGS, StringComparison.CurrentCultureIgnoreCase)
    '                      Join cash In cashBalances On account.AccountCode Equals cash.AccountCode
    '                      Where cash.TotalCashBalance <> 0
    '                      Select New With {
    '                            .AccountCode = account.AccountCode,
    '                            .TotalCashBalance = cash.TotalCashBalance
    '                        }
    '        Console.WriteLine($"Savings: {savings.Sum(Function(c) c.TotalCashBalance):c2}")
    '        For Each item In savings.OrderByDescending(Function(c) c.TotalCashBalance)
    '            Console.WriteLine($"  ->  Savings Account: {item.AccountCode,-20} Total Amount: {item.TotalCashBalance,-15:c2}")
    '        Next

    '        ' Add - run for specific dates to show on chart
    '        Dim grandTotal = metals.Sum(Function(c) c.CurrentValue) + crypto.Sum(Function(c) c.CurrentValue) +
    '            stock.Sum(Function(c) c.CurrentValue) + savings.Sum(Function(c) c.TotalCashBalance)
    '        Console.WriteLine($"GRAND TOTAL: {grandTotal,-15:c2}")

    '    Catch ex As Exception
    '        m_commonObjects.Errors.Handle(ex)
    '    End Try
    'End Sub

End Class
