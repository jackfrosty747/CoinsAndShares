<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FMdi
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try

            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
                If MdiChildren IsNot Nothing Then
                    For Each childForm In MdiChildren
                        If childForm IsNot Nothing Then
                            childForm.Dispose()
                        End If
                    Next
                End If
                If m_dashboard IsNot Nothing Then
                    m_dashboard.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileViewDashboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileCurrencies = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileElectricityRates = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFileBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileBackupBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileBackupRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileDatabaseCleardown = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFileDatabaseMaintenance = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuFileDatabaseSqlInterface = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstrumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSetupInstruments = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsmiInstrumentRateUpdater = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TsmiInstrumentHedging = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAccountList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuAccountsNetworks = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuTransactionHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnapshotsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSnapshotsTakeSnapshot = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChartsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuAssets = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuInterest = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReportsSavingsTax = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuReportsIsaTransfers = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoptesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuNotes = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.InstrumentsToolStripMenuItem, Me.AccountsToolStripMenuItem, Me.HistoryToolStripMenuItem, Me.SnapshotsToolStripMenuItem, Me.ChartsToolStripMenuItem, Me.NoptesToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFileViewDashboard, Me.MnuFileCurrencies, Me.MnuFileElectricityRates, Me.MnuFileSettings, Me.ToolStripMenuItem1, Me.MnuFileBackup, Me.ToolStripMenuItem2, Me.MnuFileExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'MnuFileViewDashboard
        '
        Me.MnuFileViewDashboard.Name = "MnuFileViewDashboard"
        Me.MnuFileViewDashboard.Size = New System.Drawing.Size(159, 22)
        Me.MnuFileViewDashboard.Text = "View Dashboard"
        '
        'MnuFileCurrencies
        '
        Me.MnuFileCurrencies.Name = "MnuFileCurrencies"
        Me.MnuFileCurrencies.Size = New System.Drawing.Size(159, 22)
        Me.MnuFileCurrencies.Text = "Currencies"
        '
        'MnuFileElectricityRates
        '
        Me.MnuFileElectricityRates.Name = "MnuFileElectricityRates"
        Me.MnuFileElectricityRates.Size = New System.Drawing.Size(159, 22)
        Me.MnuFileElectricityRates.Text = "Electricity Rates"
        '
        'MnuFileSettings
        '
        Me.MnuFileSettings.Name = "MnuFileSettings"
        Me.MnuFileSettings.Size = New System.Drawing.Size(159, 22)
        Me.MnuFileSettings.Text = "Settings"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(156, 6)
        '
        'MnuFileBackup
        '
        Me.MnuFileBackup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuFileBackupBackup, Me.MnuFileBackupRestore, Me.MnuFileDatabaseCleardown, Me.ToolStripMenuItem3, Me.MnuFileDatabaseMaintenance, Me.MnuFileDatabaseSqlInterface})
        Me.MnuFileBackup.Name = "MnuFileBackup"
        Me.MnuFileBackup.Size = New System.Drawing.Size(159, 22)
        Me.MnuFileBackup.Text = "Database"
        '
        'MnuFileBackupBackup
        '
        Me.MnuFileBackupBackup.Name = "MnuFileBackupBackup"
        Me.MnuFileBackupBackup.Size = New System.Drawing.Size(144, 22)
        Me.MnuFileBackupBackup.Text = "Backup Data"
        '
        'MnuFileBackupRestore
        '
        Me.MnuFileBackupRestore.Name = "MnuFileBackupRestore"
        Me.MnuFileBackupRestore.Size = New System.Drawing.Size(144, 22)
        Me.MnuFileBackupRestore.Text = "Restore Data"
        '
        'MnuFileDatabaseCleardown
        '
        Me.MnuFileDatabaseCleardown.Name = "MnuFileDatabaseCleardown"
        Me.MnuFileDatabaseCleardown.Size = New System.Drawing.Size(144, 22)
        Me.MnuFileDatabaseCleardown.Text = "Cleardown"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(141, 6)
        '
        'MnuFileDatabaseMaintenance
        '
        Me.MnuFileDatabaseMaintenance.Name = "MnuFileDatabaseMaintenance"
        Me.MnuFileDatabaseMaintenance.Size = New System.Drawing.Size(144, 22)
        Me.MnuFileDatabaseMaintenance.Text = "Maintenance"
        '
        'MnuFileDatabaseSqlInterface
        '
        Me.MnuFileDatabaseSqlInterface.Name = "MnuFileDatabaseSqlInterface"
        Me.MnuFileDatabaseSqlInterface.Size = New System.Drawing.Size(144, 22)
        Me.MnuFileDatabaseSqlInterface.Text = "SQL Interface"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(156, 6)
        '
        'MnuFileExit
        '
        Me.MnuFileExit.Name = "MnuFileExit"
        Me.MnuFileExit.Size = New System.Drawing.Size(159, 22)
        Me.MnuFileExit.Text = "E&xit"
        '
        'InstrumentsToolStripMenuItem
        '
        Me.InstrumentsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSetupInstruments, Me.TsmiInstrumentRateUpdater, Me.ToolStripMenuItem4, Me.TsmiInstrumentHedging})
        Me.InstrumentsToolStripMenuItem.Name = "InstrumentsToolStripMenuItem"
        Me.InstrumentsToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.InstrumentsToolStripMenuItem.Text = "Instruments"
        '
        'MnuSetupInstruments
        '
        Me.MnuSetupInstruments.Name = "MnuSetupInstruments"
        Me.MnuSetupInstruments.Size = New System.Drawing.Size(174, 22)
        Me.MnuSetupInstruments.Text = "Setup Instruments"
        '
        'TsmiInstrumentRateUpdater
        '
        Me.TsmiInstrumentRateUpdater.Name = "TsmiInstrumentRateUpdater"
        Me.TsmiInstrumentRateUpdater.Size = New System.Drawing.Size(174, 22)
        Me.TsmiInstrumentRateUpdater.Text = "Share Price Scraper"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(171, 6)
        '
        'TsmiInstrumentHedging
        '
        Me.TsmiInstrumentHedging.Name = "TsmiInstrumentHedging"
        Me.TsmiInstrumentHedging.Size = New System.Drawing.Size(174, 22)
        Me.TsmiInstrumentHedging.Text = "Hedging"
        '
        'AccountsToolStripMenuItem
        '
        Me.AccountsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAccountList, Me.ToolStripMenuItem5, Me.MnuAccountsNetworks})
        Me.AccountsToolStripMenuItem.Name = "AccountsToolStripMenuItem"
        Me.AccountsToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.AccountsToolStripMenuItem.Text = "Accounts"
        '
        'MnuAccountList
        '
        Me.MnuAccountList.Name = "MnuAccountList"
        Me.MnuAccountList.Size = New System.Drawing.Size(140, 22)
        Me.MnuAccountList.Text = "Account List"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(137, 6)
        '
        'MnuAccountsNetworks
        '
        Me.MnuAccountsNetworks.Name = "MnuAccountsNetworks"
        Me.MnuAccountsNetworks.Size = New System.Drawing.Size(140, 22)
        Me.MnuAccountsNetworks.Text = "Networks"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTransactionHistory})
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'MnuTransactionHistory
        '
        Me.MnuTransactionHistory.Name = "MnuTransactionHistory"
        Me.MnuTransactionHistory.Size = New System.Drawing.Size(176, 22)
        Me.MnuTransactionHistory.Text = "Transaction History"
        '
        'SnapshotsToolStripMenuItem
        '
        Me.SnapshotsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSnapshotsTakeSnapshot})
        Me.SnapshotsToolStripMenuItem.Name = "SnapshotsToolStripMenuItem"
        Me.SnapshotsToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.SnapshotsToolStripMenuItem.Text = "Snapshots"
        '
        'MnuSnapshotsTakeSnapshot
        '
        Me.MnuSnapshotsTakeSnapshot.Name = "MnuSnapshotsTakeSnapshot"
        Me.MnuSnapshotsTakeSnapshot.Size = New System.Drawing.Size(144, 22)
        Me.MnuSnapshotsTakeSnapshot.Text = "Snapshot List"
        '
        'ChartsToolStripMenuItem
        '
        Me.ChartsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuReports, Me.MnuAssets, Me.MnuInterest, Me.MnuReportsSavingsTax, Me.MnuReportsIsaTransfers})
        Me.ChartsToolStripMenuItem.Name = "ChartsToolStripMenuItem"
        Me.ChartsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ChartsToolStripMenuItem.Text = "Reports"
        '
        'MnuReports
        '
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(188, 22)
        Me.MnuReports.Text = "Reports"
        '
        'MnuAssets
        '
        Me.MnuAssets.Name = "MnuAssets"
        Me.MnuAssets.Size = New System.Drawing.Size(188, 22)
        Me.MnuAssets.Text = "Assets"
        '
        'MnuInterest
        '
        Me.MnuInterest.Name = "MnuInterest"
        Me.MnuInterest.Size = New System.Drawing.Size(188, 22)
        Me.MnuInterest.Text = "Interest"
        '
        'MnuReportsSavingsTax
        '
        Me.MnuReportsSavingsTax.Name = "MnuReportsSavingsTax"
        Me.MnuReportsSavingsTax.Size = New System.Drawing.Size(188, 22)
        Me.MnuReportsSavingsTax.Text = "Savings Tax Summary"
        '
        'MnuReportsIsaTransfers
        '
        Me.MnuReportsIsaTransfers.Name = "MnuReportsIsaTransfers"
        Me.MnuReportsIsaTransfers.Size = New System.Drawing.Size(188, 22)
        Me.MnuReportsIsaTransfers.Text = "ISA Transfers"
        '
        'NoptesToolStripMenuItem
        '
        Me.NoptesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNotes})
        Me.NoptesToolStripMenuItem.Name = "NoptesToolStripMenuItem"
        Me.NoptesToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.NoptesToolStripMenuItem.Text = "Notes"
        '
        'MnuNotes
        '
        Me.MnuNotes.Name = "MnuNotes"
        Me.MnuNotes.Size = New System.Drawing.Size(105, 22)
        Me.MnuNotes.Text = "Notes"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuHelpAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'MnuHelpAbout
        '
        Me.MnuHelpAbout.Name = "MnuHelpAbout"
        Me.MnuHelpAbout.Size = New System.Drawing.Size(107, 22)
        Me.MnuHelpAbout.Text = "About"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'FMdi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FMdi"
        Me.Text = "FMdi"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuFileExit As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents InstrumentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuSetupInstruments As ToolStripMenuItem
    Friend WithEvents AccountsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuAccountList As ToolStripMenuItem
    Friend WithEvents HistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuTransactionHistory As ToolStripMenuItem
    Friend WithEvents MnuFileViewDashboard As ToolStripMenuItem
    Friend WithEvents MnuFileCurrencies As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents UCurrency1 As Dashboard.UCurrency
    Friend WithEvents MnuFileBackup As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents MnuFileBackupBackup As ToolStripMenuItem
    Friend WithEvents MnuFileBackupRestore As ToolStripMenuItem
    Friend WithEvents MnuFileDatabaseCleardown As ToolStripMenuItem
    Friend WithEvents MnuFileSettings As ToolStripMenuItem
    Friend WithEvents SnapshotsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuSnapshotsTakeSnapshot As ToolStripMenuItem
    Friend WithEvents ChartsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuReports As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents MnuFileDatabaseSqlInterface As ToolStripMenuItem
    Friend WithEvents TsmiInstrumentRateUpdater As ToolStripMenuItem
    Friend WithEvents MnuFileElectricityRates As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents TsmiInstrumentHedging As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents MnuAssets As ToolStripMenuItem
    Friend WithEvents MnuInterest As ToolStripMenuItem
    Friend WithEvents NoptesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuNotes As ToolStripMenuItem
    Friend WithEvents MnuAccountsNetworks As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuHelpAbout As ToolStripMenuItem
    Friend WithEvents MnuFileDatabaseMaintenance As ToolStripMenuItem
    Friend WithEvents MnuReportsSavingsTax As ToolStripMenuItem
    Friend WithEvents MnuReportsIsaTransfers As ToolStripMenuItem
End Class
