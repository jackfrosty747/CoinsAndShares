Namespace Accounts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccount
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAccount))
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.ChkNonTaxable = New System.Windows.Forms.CheckBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TxtAccountCode = New System.Windows.Forms.TextBox()
            Me.TxtAccountName = New System.Windows.Forms.TextBox()
            Me.TxtAccountType = New System.Windows.Forms.TextBox()
            Me.GrdHoldings = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.TxtNotes = New System.Windows.Forms.TextBox()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.CmbNetworkId = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.LblBalance = New System.Windows.Forms.Label()
            Me.ChkIncludeOnShortcuts = New System.Windows.Forms.CheckBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnReconcile = New System.Windows.Forms.Button()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.LblSelected = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.LblAmount = New System.Windows.Forms.Label()
            Me.LblTransCount = New System.Windows.Forms.Label()
            Me.BtnSave = New System.Windows.Forms.Button()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Btn212 = New System.Windows.Forms.Button()
            Me.BtnNexo = New System.Windows.Forms.Button()
            Me.LblCustomImportSep = New System.Windows.Forms.Label()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.BtnSwapCrypto = New System.Windows.Forms.Button()
            Me.LblBtnSwapCryptoSep = New System.Windows.Forms.Label()
            Me.BtnBonus = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.BtnBuySell = New System.Windows.Forms.Button()
            Me.GrdTransactions = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.Transactions = New System.Windows.Forms.TabPage()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.CmbType = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.BtnEdit = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TxtFilter = New System.Windows.Forms.TextBox()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.BtnDelete = New System.Windows.Forms.Button()
            Me.Analysis = New System.Windows.Forms.TabPage()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.LblProfitLoss = New System.Windows.Forms.Label()
            Me.LblAccountValue = New System.Windows.Forms.Label()
            Me.LblNetTransfers = New System.Windows.Forms.Label()
            Me.LblTransfersOut = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.LblAccountValueCaption = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.LblTransfersIn = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.LblFeesCaption = New System.Windows.Forms.Label()
            Me.LblBonusCaption = New System.Windows.Forms.Label()
            Me.LblFees = New System.Windows.Forms.Label()
            Me.LblBonus = New System.Windows.Forms.Label()
            Me.LblAdjustmentsCaption = New System.Windows.Forms.Label()
            Me.LblAdjustments = New System.Windows.Forms.Label()
            Me.LblMiningCaption = New System.Windows.Forms.Label()
            Me.LblMining = New System.Windows.Forms.Label()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.Label21 = New System.Windows.Forms.Label()
            Me.TxtCashSavingsRate = New System.Windows.Forms.TextBox()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbNetworkId, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.Transactions.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.CmbType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Analysis.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 7
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.ChkNonTaxable, 4, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label16, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountCode, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountName, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountType, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.GrdHoldings, 6, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtNotes, 2, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.Label19, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbNetworkId, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label5, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.LblBalance, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.ChkIncludeOnShortcuts, 4, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label21, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtCashSavingsRate, 2, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.Label22, 3, 5)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 7
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 220)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'ChkNonTaxable
            '
            Me.ChkNonTaxable.AutoSize = True
            Me.ChkNonTaxable.Location = New System.Drawing.Point(233, 64)
            Me.ChkNonTaxable.Name = "ChkNonTaxable"
            Me.ChkNonTaxable.Size = New System.Drawing.Size(67, 17)
            Me.ChkNonTaxable.TabIndex = 8
            Me.ChkNonTaxable.Text = "Non-Tax"
            Me.ToolTip1.SetToolTip(Me.ChkNonTaxable, "Non-taxable account.  Interest is not taxed, e.g. ISA")
            Me.ChkNonTaxable.UseVisualStyleBackColor = True
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(23, 145)
            Me.Label16.Name = "Label16"
            Me.Label16.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label16.Size = New System.Drawing.Size(37, 16)
            Me.Label16.TabIndex = 15
            Me.Label16.Text = "Notes"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(23, 61)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(29, 16)
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "Type"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(23, 33)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(36, 16)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Name"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(23, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(79, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Account Code"
            '
            'TxtAccountCode
            '
            Me.TxtAccountCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAccountCode.Location = New System.Drawing.Point(108, 8)
            Me.TxtAccountCode.Name = "TxtAccountCode"
            Me.TxtAccountCode.ReadOnly = True
            Me.TxtAccountCode.Size = New System.Drawing.Size(79, 22)
            Me.TxtAccountCode.TabIndex = 1
            Me.TxtAccountCode.Text = "TxtAccountCode"
            '
            'TxtAccountName
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtAccountName, 3)
            Me.TxtAccountName.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAccountName.Location = New System.Drawing.Point(108, 36)
            Me.TxtAccountName.Name = "TxtAccountName"
            Me.TxtAccountName.Size = New System.Drawing.Size(204, 22)
            Me.TxtAccountName.TabIndex = 5
            Me.TxtAccountName.Text = "TxtAccountName"
            '
            'TxtAccountType
            '
            Me.TxtAccountType.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAccountType.Location = New System.Drawing.Point(108, 64)
            Me.TxtAccountType.Name = "TxtAccountType"
            Me.TxtAccountType.ReadOnly = True
            Me.TxtAccountType.Size = New System.Drawing.Size(79, 22)
            Me.TxtAccountType.TabIndex = 7
            Me.TxtAccountType.Text = "TxtAccountType"
            '
            'GrdHoldings
            '
            Me.GrdHoldings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdHoldings.Location = New System.Drawing.Point(323, 3)
            Me.GrdHoldings.Name = "GrdHoldings"
            Me.TableLayoutPanel1.SetRowSpan(Me.GrdHoldings, 7)
            Me.GrdHoldings.Size = New System.Drawing.Size(458, 214)
            Me.GrdHoldings.TabIndex = 12
            Me.GrdHoldings.Text = "Holdings"
            '
            'TxtNotes
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtNotes, 3)
            Me.TxtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtNotes.Location = New System.Drawing.Point(108, 148)
            Me.TxtNotes.Multiline = True
            Me.TxtNotes.Name = "TxtNotes"
            Me.TxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TxtNotes.Size = New System.Drawing.Size(204, 69)
            Me.TxtNotes.TabIndex = 16
            Me.TxtNotes.Text = "TxtNotes"
            '
            'Label19
            '
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(23, 89)
            Me.Label19.Name = "Label19"
            Me.Label19.Padding = New System.Windows.Forms.Padding(0, 3, 0, 5)
            Me.Label19.Size = New System.Drawing.Size(65, 21)
            Me.Label19.TabIndex = 9
            Me.Label19.Text = "Network ID"
            '
            'CmbNetworkId
            '
            Me.CmbNetworkId.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbNetworkId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbNetworkId.DisplayMember = ""
            Me.CmbNetworkId.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbNetworkId.Location = New System.Drawing.Point(108, 92)
            Me.CmbNetworkId.Name = "CmbNetworkId"
            Me.CmbNetworkId.Size = New System.Drawing.Size(79, 22)
            Me.CmbNetworkId.TabIndex = 10
            Me.CmbNetworkId.ValueMember = ""
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(193, 5)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(0, 3, 0, 5)
            Me.Label5.Size = New System.Drawing.Size(22, 21)
            Me.Label5.TabIndex = 2
            Me.Label5.Text = "Val"
            '
            'LblBalance
            '
            Me.LblBalance.AutoSize = True
            Me.LblBalance.ForeColor = System.Drawing.Color.Blue
            Me.LblBalance.Location = New System.Drawing.Point(233, 5)
            Me.LblBalance.Name = "LblBalance"
            Me.LblBalance.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblBalance.Size = New System.Drawing.Size(62, 16)
            Me.LblBalance.TabIndex = 3
            Me.LblBalance.Text = "LblBalance"
            '
            'ChkIncludeOnShortcuts
            '
            Me.ChkIncludeOnShortcuts.AutoSize = True
            Me.ChkIncludeOnShortcuts.Location = New System.Drawing.Point(233, 92)
            Me.ChkIncludeOnShortcuts.Name = "ChkIncludeOnShortcuts"
            Me.ChkIncludeOnShortcuts.Size = New System.Drawing.Size(70, 17)
            Me.ChkIncludeOnShortcuts.TabIndex = 11
            Me.ChkIncludeOnShortcuts.Text = "Shortcut"
            Me.ToolTip1.SetToolTip(Me.ChkIncludeOnShortcuts, "Create a shortcut button to this account on the left panel")
            Me.ChkIncludeOnShortcuts.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnReconcile)
            Me.Panel1.Controls.Add(Me.Label20)
            Me.Panel1.Controls.Add(Me.LblSelected)
            Me.Panel1.Controls.Add(Me.Label15)
            Me.Panel1.Controls.Add(Me.LblAmount)
            Me.Panel1.Controls.Add(Me.LblTransCount)
            Me.Panel1.Controls.Add(Me.BtnSave)
            Me.Panel1.Controls.Add(Me.Label13)
            Me.Panel1.Controls.Add(Me.Btn212)
            Me.Panel1.Controls.Add(Me.BtnNexo)
            Me.Panel1.Controls.Add(Me.LblCustomImportSep)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Controls.Add(Me.Label14)
            Me.Panel1.Controls.Add(Me.BtnSwapCrypto)
            Me.Panel1.Controls.Add(Me.LblBtnSwapCryptoSep)
            Me.Panel1.Controls.Add(Me.BtnBonus)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.BtnBuySell)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 523)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 3
            '
            'BtnReconcile
            '
            Me.BtnReconcile.AutoSize = True
            Me.BtnReconcile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnReconcile.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnReconcile.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnReconcile.Location = New System.Drawing.Point(771, 5)
            Me.BtnReconcile.Name = "BtnReconcile"
            Me.BtnReconcile.Size = New System.Drawing.Size(24, 28)
            Me.BtnReconcile.TabIndex = 26
            Me.BtnReconcile.Text = "R"
            Me.BtnReconcile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.ToolTip1.SetToolTip(Me.BtnReconcile, "Reconcile or unreconcile selected transactions")
            Me.BtnReconcile.UseVisualStyleBackColor = False
            '
            'Label20
            '
            Me.Label20.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label20.Location = New System.Drawing.Point(766, 5)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(5, 28)
            Me.Label20.TabIndex = 25
            '
            'LblSelected
            '
            Me.LblSelected.AutoSize = True
            Me.LblSelected.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblSelected.Location = New System.Drawing.Point(696, 5)
            Me.LblSelected.Name = "LblSelected"
            Me.LblSelected.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
            Me.LblSelected.Size = New System.Drawing.Size(70, 18)
            Me.LblSelected.TabIndex = 15
            Me.LblSelected.Text = "LblSelected"
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.Location = New System.Drawing.Point(630, 5)
            Me.Label15.Name = "Label15"
            Me.Label15.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
            Me.Label15.Size = New System.Drawing.Size(66, 18)
            Me.Label15.TabIndex = 14
            Me.Label15.Text = "SELECTED:"
            '
            'LblAmount
            '
            Me.LblAmount.AutoSize = True
            Me.LblAmount.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblAmount.Location = New System.Drawing.Point(562, 5)
            Me.LblAmount.Name = "LblAmount"
            Me.LblAmount.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
            Me.LblAmount.Size = New System.Drawing.Size(68, 18)
            Me.LblAmount.TabIndex = 13
            Me.LblAmount.Text = "LblAmount"
            '
            'LblTransCount
            '
            Me.LblTransCount.AutoSize = True
            Me.LblTransCount.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblTransCount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblTransCount.Location = New System.Drawing.Point(475, 5)
            Me.LblTransCount.Name = "LblTransCount"
            Me.LblTransCount.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
            Me.LblTransCount.Size = New System.Drawing.Size(87, 18)
            Me.LblTransCount.TabIndex = 12
            Me.LblTransCount.Text = "LblTransCount"
            '
            'BtnSave
            '
            Me.BtnSave.AutoSize = True
            Me.BtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
            Me.BtnSave.Location = New System.Drawing.Point(419, 5)
            Me.BtnSave.Name = "BtnSave"
            Me.BtnSave.Size = New System.Drawing.Size(56, 28)
            Me.BtnSave.TabIndex = 18
            Me.BtnSave.Text = "&Save"
            Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSave.UseVisualStyleBackColor = False
            '
            'Label13
            '
            Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label13.Location = New System.Drawing.Point(414, 5)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(5, 28)
            Me.Label13.TabIndex = 23
            '
            'Btn212
            '
            Me.Btn212.AutoSize = True
            Me.Btn212.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.Btn212.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.Btn212.Dock = System.Windows.Forms.DockStyle.Left
            Me.Btn212.Image = CType(resources.GetObject("Btn212.Image"), System.Drawing.Image)
            Me.Btn212.Location = New System.Drawing.Point(363, 5)
            Me.Btn212.Name = "Btn212"
            Me.Btn212.Size = New System.Drawing.Size(51, 28)
            Me.Btn212.TabIndex = 24
            Me.Btn212.Text = "212"
            Me.Btn212.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.ToolTip1.SetToolTip(Me.Btn212, "Import transactions from Trading 212")
            Me.Btn212.UseVisualStyleBackColor = False
            '
            'BtnNexo
            '
            Me.BtnNexo.AutoSize = True
            Me.BtnNexo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnNexo.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnNexo.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnNexo.Image = CType(resources.GetObject("BtnNexo.Image"), System.Drawing.Image)
            Me.BtnNexo.Location = New System.Drawing.Point(304, 5)
            Me.BtnNexo.Name = "BtnNexo"
            Me.BtnNexo.Size = New System.Drawing.Size(59, 28)
            Me.BtnNexo.TabIndex = 20
            Me.BtnNexo.Text = "Nexo"
            Me.BtnNexo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.ToolTip1.SetToolTip(Me.BtnNexo, "Import Interest entries only from Nexo CSV download")
            Me.BtnNexo.UseVisualStyleBackColor = False
            '
            'LblCustomImportSep
            '
            Me.LblCustomImportSep.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblCustomImportSep.Location = New System.Drawing.Point(299, 5)
            Me.LblCustomImportSep.Name = "LblCustomImportSep"
            Me.LblCustomImportSep.Size = New System.Drawing.Size(5, 28)
            Me.LblCustomImportSep.TabIndex = 10
            '
            'BtnRefresh
            '
            Me.BtnRefresh.AutoSize = True
            Me.BtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnRefresh.Image = CType(resources.GetObject("BtnRefresh.Image"), System.Drawing.Image)
            Me.BtnRefresh.Location = New System.Drawing.Point(227, 5)
            Me.BtnRefresh.Name = "BtnRefresh"
            Me.BtnRefresh.Size = New System.Drawing.Size(72, 28)
            Me.BtnRefresh.TabIndex = 8
            Me.BtnRefresh.Text = "Refresh"
            Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnRefresh.UseVisualStyleBackColor = False
            '
            'Label14
            '
            Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label14.Location = New System.Drawing.Point(222, 5)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(5, 28)
            Me.Label14.TabIndex = 17
            '
            'BtnSwapCrypto
            '
            Me.BtnSwapCrypto.AutoSize = True
            Me.BtnSwapCrypto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnSwapCrypto.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSwapCrypto.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnSwapCrypto.Image = CType(resources.GetObject("BtnSwapCrypto.Image"), System.Drawing.Image)
            Me.BtnSwapCrypto.Location = New System.Drawing.Point(161, 5)
            Me.BtnSwapCrypto.Name = "BtnSwapCrypto"
            Me.BtnSwapCrypto.Size = New System.Drawing.Size(61, 28)
            Me.BtnSwapCrypto.TabIndex = 16
            Me.BtnSwapCrypto.Text = "Swap"
            Me.BtnSwapCrypto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSwapCrypto.UseVisualStyleBackColor = False
            '
            'LblBtnSwapCryptoSep
            '
            Me.LblBtnSwapCryptoSep.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblBtnSwapCryptoSep.Location = New System.Drawing.Point(156, 5)
            Me.LblBtnSwapCryptoSep.Name = "LblBtnSwapCryptoSep"
            Me.LblBtnSwapCryptoSep.Size = New System.Drawing.Size(5, 28)
            Me.LblBtnSwapCryptoSep.TabIndex = 9
            '
            'BtnBonus
            '
            Me.BtnBonus.AutoSize = True
            Me.BtnBonus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnBonus.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnBonus.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnBonus.Image = CType(resources.GetObject("BtnBonus.Image"), System.Drawing.Image)
            Me.BtnBonus.Location = New System.Drawing.Point(90, 5)
            Me.BtnBonus.Name = "BtnBonus"
            Me.BtnBonus.Size = New System.Drawing.Size(66, 28)
            Me.BtnBonus.TabIndex = 6
            Me.BtnBonus.Text = "Adjust"
            Me.BtnBonus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnBonus.UseVisualStyleBackColor = False
            '
            'Label6
            '
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label6.Location = New System.Drawing.Point(85, 5)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(5, 28)
            Me.Label6.TabIndex = 7
            '
            'BtnBuySell
            '
            Me.BtnBuySell.AutoSize = True
            Me.BtnBuySell.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnBuySell.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnBuySell.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnBuySell.Image = CType(resources.GetObject("BtnBuySell.Image"), System.Drawing.Image)
            Me.BtnBuySell.Location = New System.Drawing.Point(5, 5)
            Me.BtnBuySell.Name = "BtnBuySell"
            Me.BtnBuySell.Size = New System.Drawing.Size(80, 28)
            Me.BtnBuySell.TabIndex = 4
            Me.BtnBuySell.Text = "Buy / Sell"
            Me.BtnBuySell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnBuySell.UseVisualStyleBackColor = False
            '
            'GrdTransactions
            '
            Me.GrdTransactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdTransactions.Location = New System.Drawing.Point(3, 3)
            Me.GrdTransactions.Name = "GrdTransactions"
            Me.GrdTransactions.Size = New System.Drawing.Size(770, 229)
            Me.GrdTransactions.TabIndex = 4
            Me.GrdTransactions.Text = "Transactions"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.Transactions)
            Me.TabControl1.Controls.Add(Me.Analysis)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(0, 0)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(784, 299)
            Me.TabControl1.TabIndex = 0
            '
            'Transactions
            '
            Me.Transactions.Controls.Add(Me.GrdTransactions)
            Me.Transactions.Controls.Add(Me.Panel2)
            Me.Transactions.Location = New System.Drawing.Point(4, 22)
            Me.Transactions.Name = "Transactions"
            Me.Transactions.Padding = New System.Windows.Forms.Padding(3)
            Me.Transactions.Size = New System.Drawing.Size(776, 273)
            Me.Transactions.TabIndex = 0
            Me.Transactions.Text = "Transactions"
            Me.Transactions.UseVisualStyleBackColor = True
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.Controls.Add(Me.CmbType)
            Me.Panel2.Controls.Add(Me.Label18)
            Me.Panel2.Controls.Add(Me.BtnEdit)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.TxtFilter)
            Me.Panel2.Controls.Add(Me.Label17)
            Me.Panel2.Controls.Add(Me.BtnDelete)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(3, 232)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(770, 38)
            Me.Panel2.TabIndex = 5
            '
            'CmbType
            '
            Me.CmbType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbType.DisplayMember = ""
            Me.CmbType.Dock = System.Windows.Forms.DockStyle.Left
            Me.CmbType.Location = New System.Drawing.Point(167, 5)
            Me.CmbType.Name = "CmbType"
            Me.CmbType.Size = New System.Drawing.Size(158, 22)
            Me.CmbType.TabIndex = 13
            Me.CmbType.ValueMember = ""
            '
            'Label18
            '
            Me.Label18.AutoSize = True
            Me.Label18.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label18.Location = New System.Drawing.Point(133, 5)
            Me.Label18.Name = "Label18"
            Me.Label18.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
            Me.Label18.Size = New System.Drawing.Size(34, 18)
            Me.Label18.TabIndex = 14
            Me.Label18.Text = "TYPE"
            '
            'BtnEdit
            '
            Me.BtnEdit.AutoSize = True
            Me.BtnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
            Me.BtnEdit.Location = New System.Drawing.Point(598, 5)
            Me.BtnEdit.Name = "BtnEdit"
            Me.BtnEdit.Size = New System.Drawing.Size(53, 28)
            Me.BtnEdit.TabIndex = 11
            Me.BtnEdit.Text = "Edit"
            Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnEdit.UseVisualStyleBackColor = False
            '
            'Label4
            '
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Right
            Me.Label4.Location = New System.Drawing.Point(651, 5)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(5, 28)
            Me.Label4.TabIndex = 12
            '
            'TxtFilter
            '
            Me.TxtFilter.Dock = System.Windows.Forms.DockStyle.Left
            Me.TxtFilter.Location = New System.Drawing.Point(43, 5)
            Me.TxtFilter.Name = "TxtFilter"
            Me.TxtFilter.Size = New System.Drawing.Size(90, 22)
            Me.TxtFilter.TabIndex = 9
            '
            'Label17
            '
            Me.Label17.AutoSize = True
            Me.Label17.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label17.Location = New System.Drawing.Point(5, 5)
            Me.Label17.Name = "Label17"
            Me.Label17.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label17.Size = New System.Drawing.Size(38, 18)
            Me.Label17.TabIndex = 10
            Me.Label17.Text = "FILTER"
            '
            'BtnDelete
            '
            Me.BtnDelete.AutoSize = True
            Me.BtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
            Me.BtnDelete.Location = New System.Drawing.Point(656, 5)
            Me.BtnDelete.Name = "BtnDelete"
            Me.BtnDelete.Size = New System.Drawing.Size(109, 28)
            Me.BtnDelete.TabIndex = 7
            Me.BtnDelete.Text = "Delete Batches"
            Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnDelete.UseVisualStyleBackColor = False
            '
            'Analysis
            '
            Me.Analysis.Controls.Add(Me.TableLayoutPanel2)
            Me.Analysis.Location = New System.Drawing.Point(4, 22)
            Me.Analysis.Name = "Analysis"
            Me.Analysis.Padding = New System.Windows.Forms.Padding(3)
            Me.Analysis.Size = New System.Drawing.Size(776, 290)
            Me.Analysis.TabIndex = 1
            Me.Analysis.Text = "Analysis"
            Me.Analysis.UseVisualStyleBackColor = True
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.AutoSize = True
            Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel2.ColumnCount = 2
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel2.Controls.Add(Me.LblProfitLoss, 1, 10)
            Me.TableLayoutPanel2.Controls.Add(Me.LblAccountValue, 1, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.LblNetTransfers, 1, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.LblTransfersOut, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.LblAccountValueCaption, 0, 8)
            Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 10)
            Me.TableLayoutPanel2.Controls.Add(Me.LblTransfersIn, 1, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.Label10, 1, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.Label12, 1, 9)
            Me.TableLayoutPanel2.Controls.Add(Me.LblFeesCaption, 0, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.LblBonusCaption, 0, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.LblFees, 1, 7)
            Me.TableLayoutPanel2.Controls.Add(Me.LblBonus, 1, 5)
            Me.TableLayoutPanel2.Controls.Add(Me.LblAdjustmentsCaption, 0, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.LblAdjustments, 1, 6)
            Me.TableLayoutPanel2.Controls.Add(Me.LblMiningCaption, 0, 4)
            Me.TableLayoutPanel2.Controls.Add(Me.LblMining, 1, 4)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 11
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(241, 284)
            Me.TableLayoutPanel2.TabIndex = 1
            '
            'LblProfitLoss
            '
            Me.LblProfitLoss.AutoSize = True
            Me.LblProfitLoss.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblProfitLoss.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblProfitLoss.Location = New System.Drawing.Point(163, 108)
            Me.LblProfitLoss.Name = "LblProfitLoss"
            Me.LblProfitLoss.Size = New System.Drawing.Size(75, 176)
            Me.LblProfitLoss.TabIndex = 9
            Me.LblProfitLoss.Text = "LblProfitLoss"
            '
            'LblAccountValue
            '
            Me.LblAccountValue.AutoSize = True
            Me.LblAccountValue.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblAccountValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblAccountValue.Location = New System.Drawing.Point(144, 93)
            Me.LblAccountValue.Name = "LblAccountValue"
            Me.LblAccountValue.Size = New System.Drawing.Size(94, 13)
            Me.LblAccountValue.TabIndex = 8
            Me.LblAccountValue.Text = "LblAccountValue"
            '
            'LblNetTransfers
            '
            Me.LblNetTransfers.AutoSize = True
            Me.LblNetTransfers.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblNetTransfers.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblNetTransfers.Location = New System.Drawing.Point(150, 28)
            Me.LblNetTransfers.Name = "LblNetTransfers"
            Me.LblNetTransfers.Size = New System.Drawing.Size(88, 13)
            Me.LblNetTransfers.TabIndex = 7
            Me.LblNetTransfers.Text = "LblNetTransfers"
            '
            'LblTransfersOut
            '
            Me.LblTransfersOut.AutoSize = True
            Me.LblTransfersOut.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblTransfersOut.Location = New System.Drawing.Point(151, 13)
            Me.LblTransfersOut.Name = "LblTransfersOut"
            Me.LblTransfersOut.Size = New System.Drawing.Size(87, 13)
            Me.LblTransfersOut.TabIndex = 6
            Me.LblTransfersOut.Text = "LblTransfersOut"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(3, 0)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(65, 13)
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "Transfers In"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(3, 13)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(75, 13)
            Me.Label8.TabIndex = 1
            Me.Label8.Text = "Transfers Out"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.Location = New System.Drawing.Point(3, 28)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(92, 13)
            Me.Label9.TabIndex = 2
            Me.Label9.Text = "NET TRANSFERS"
            '
            'LblAccountValueCaption
            '
            Me.LblAccountValueCaption.AutoSize = True
            Me.LblAccountValueCaption.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblAccountValueCaption.Location = New System.Drawing.Point(3, 93)
            Me.LblAccountValueCaption.Name = "LblAccountValueCaption"
            Me.LblAccountValueCaption.Size = New System.Drawing.Size(135, 13)
            Me.LblAccountValueCaption.TabIndex = 3
            Me.LblAccountValueCaption.Text = "LblAccountValueCaption"
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.Location = New System.Drawing.Point(3, 108)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(81, 13)
            Me.Label11.TabIndex = 4
            Me.Label11.Text = "PROFIT / LOSS"
            '
            'LblTransfersIn
            '
            Me.LblTransfersIn.AutoSize = True
            Me.LblTransfersIn.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblTransfersIn.Location = New System.Drawing.Point(161, 0)
            Me.LblTransfersIn.Name = "LblTransfersIn"
            Me.LblTransfersIn.Size = New System.Drawing.Size(77, 13)
            Me.LblTransfersIn.TabIndex = 5
            Me.LblTransfersIn.Text = "LblTransfersIn"
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Silver
            Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label10.Location = New System.Drawing.Point(144, 26)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(94, 2)
            Me.Label10.TabIndex = 10
            Me.Label10.Text = "Label10"
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Silver
            Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label12.Location = New System.Drawing.Point(144, 106)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(94, 2)
            Me.Label12.TabIndex = 11
            Me.Label12.Text = "Label12"
            '
            'LblFeesCaption
            '
            Me.LblFeesCaption.AutoSize = True
            Me.LblFeesCaption.Location = New System.Drawing.Point(3, 80)
            Me.LblFeesCaption.Name = "LblFeesCaption"
            Me.LblFeesCaption.Size = New System.Drawing.Size(30, 13)
            Me.LblFeesCaption.TabIndex = 12
            Me.LblFeesCaption.Text = "Fees"
            '
            'LblBonusCaption
            '
            Me.LblBonusCaption.AutoSize = True
            Me.LblBonusCaption.Location = New System.Drawing.Point(3, 54)
            Me.LblBonusCaption.Name = "LblBonusCaption"
            Me.LblBonusCaption.Size = New System.Drawing.Size(40, 13)
            Me.LblBonusCaption.TabIndex = 13
            Me.LblBonusCaption.Text = "Bonus"
            '
            'LblFees
            '
            Me.LblFees.AutoSize = True
            Me.LblFees.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblFees.Location = New System.Drawing.Point(193, 80)
            Me.LblFees.Name = "LblFees"
            Me.LblFees.Size = New System.Drawing.Size(45, 13)
            Me.LblFees.TabIndex = 14
            Me.LblFees.Text = "LblFees"
            '
            'LblBonus
            '
            Me.LblBonus.AutoSize = True
            Me.LblBonus.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblBonus.Location = New System.Drawing.Point(183, 54)
            Me.LblBonus.Name = "LblBonus"
            Me.LblBonus.Size = New System.Drawing.Size(55, 13)
            Me.LblBonus.TabIndex = 15
            Me.LblBonus.Text = "LblBonus"
            '
            'LblAdjustmentsCaption
            '
            Me.LblAdjustmentsCaption.AutoSize = True
            Me.LblAdjustmentsCaption.Location = New System.Drawing.Point(3, 67)
            Me.LblAdjustmentsCaption.Name = "LblAdjustmentsCaption"
            Me.LblAdjustmentsCaption.Size = New System.Drawing.Size(71, 13)
            Me.LblAdjustmentsCaption.TabIndex = 16
            Me.LblAdjustmentsCaption.Text = "Adjustments"
            '
            'LblAdjustments
            '
            Me.LblAdjustments.AutoSize = True
            Me.LblAdjustments.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblAdjustments.Location = New System.Drawing.Point(152, 67)
            Me.LblAdjustments.Name = "LblAdjustments"
            Me.LblAdjustments.Size = New System.Drawing.Size(86, 13)
            Me.LblAdjustments.TabIndex = 17
            Me.LblAdjustments.Text = "LblAdjustments"
            '
            'LblMiningCaption
            '
            Me.LblMiningCaption.AutoSize = True
            Me.LblMiningCaption.Location = New System.Drawing.Point(3, 41)
            Me.LblMiningCaption.Name = "LblMiningCaption"
            Me.LblMiningCaption.Size = New System.Drawing.Size(44, 13)
            Me.LblMiningCaption.TabIndex = 18
            Me.LblMiningCaption.Text = "Mining"
            '
            'LblMining
            '
            Me.LblMining.AutoSize = True
            Me.LblMining.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblMining.Location = New System.Drawing.Point(179, 41)
            Me.LblMining.Name = "LblMining"
            Me.LblMining.Size = New System.Drawing.Size(59, 13)
            Me.LblMining.TabIndex = 19
            Me.LblMining.Text = "LblMining"
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
            Me.SplitContainer1.Size = New System.Drawing.Size(784, 523)
            Me.SplitContainer1.SplitterDistance = 220
            Me.SplitContainer1.TabIndex = 6
            '
            'Label21
            '
            Me.Label21.AutoSize = True
            Me.Label21.Location = New System.Drawing.Point(23, 117)
            Me.Label21.Name = "Label21"
            Me.Label21.Padding = New System.Windows.Forms.Padding(0, 3, 0, 5)
            Me.Label21.Size = New System.Drawing.Size(72, 21)
            Me.Label21.TabIndex = 12
            Me.Label21.Text = "Savings Rate"
            '
            'TxtCashSavingsRate
            '
            Me.TxtCashSavingsRate.Location = New System.Drawing.Point(108, 120)
            Me.TxtCashSavingsRate.Name = "TxtCashSavingsRate"
            Me.TxtCashSavingsRate.Size = New System.Drawing.Size(79, 22)
            Me.TxtCashSavingsRate.TabIndex = 13
            '
            'Label22
            '
            Me.Label22.AutoSize = True
            Me.Label22.Location = New System.Drawing.Point(193, 117)
            Me.Label22.Name = "Label22"
            Me.Label22.Padding = New System.Windows.Forms.Padding(0, 3, 0, 5)
            Me.Label22.Size = New System.Drawing.Size(16, 21)
            Me.Label22.TabIndex = 14
            Me.Label22.Text = "%"
            '
            'FAccount
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FAccount"
            Me.Text = "Account"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbNetworkId, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.Transactions.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.CmbType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Analysis.ResumeLayout(False)
            Me.Analysis.PerformLayout()
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel1.PerformLayout()
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents TxtAccountCode As TextBox
        Friend WithEvents TxtAccountName As TextBox
        Friend WithEvents Label3 As Label
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnBuySell As Button
        Friend WithEvents GrdTransactions As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents Transactions As TabPage
        Friend WithEvents Label5 As Label
        Friend WithEvents LblBalance As Label
        Friend WithEvents Panel2 As Panel
        Friend WithEvents BtnDelete As Button
        Friend WithEvents BtnBonus As Button
        Friend WithEvents Label6 As Label
        Friend WithEvents TxtAccountType As TextBox
        Friend WithEvents GrdHoldings As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents BtnRefresh As Button
        Friend WithEvents LblBtnSwapCryptoSep As Label
        Friend WithEvents Analysis As TabPage
        Friend WithEvents Label7 As Label
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents Label8 As Label
        Friend WithEvents LblAccountValueCaption As Label
        Friend WithEvents Label11 As Label
        Friend WithEvents LblProfitLoss As Label
        Friend WithEvents LblAccountValue As Label
        Friend WithEvents LblTransfersOut As Label
        Friend WithEvents LblTransfersIn As Label
        Friend WithEvents Label10 As Label
        Friend WithEvents Label12 As Label
        Friend WithEvents LblFeesCaption As Label
        Friend WithEvents LblBonusCaption As Label
        Friend WithEvents LblFees As Label
        Friend WithEvents LblBonus As Label
        Friend WithEvents LblAdjustmentsCaption As Label
        Friend WithEvents LblAdjustments As Label
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents Label16 As Label
        Friend WithEvents TxtNotes As TextBox
        Friend WithEvents TxtFilter As TextBox
        Friend WithEvents Label17 As Label
        Friend WithEvents LblMiningCaption As Label
        Friend WithEvents LblMining As Label
        Friend WithEvents LblNetTransfers As Label
        Friend WithEvents Label9 As Label
        Friend WithEvents LblCustomImportSep As Label
        Friend WithEvents LblTransCount As Label
        Friend WithEvents LblAmount As Label
        Friend WithEvents LblSelected As Label
        Friend WithEvents Label15 As Label
        Friend WithEvents Label14 As Label
        Friend WithEvents BtnSwapCrypto As Button
        Friend WithEvents BtnEdit As Button
        Friend WithEvents Label4 As Label
        Friend WithEvents CmbType As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label18 As Label
        Friend WithEvents Label19 As Label
        Friend WithEvents CmbNetworkId As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents BtnSave As Button
        Friend WithEvents ChkIncludeOnShortcuts As CheckBox
        Friend WithEvents BtnNexo As Button
        Friend WithEvents ToolTip1 As ToolTip
        Friend WithEvents Label13 As Label
        Friend WithEvents ChkNonTaxable As CheckBox
        Friend WithEvents Btn212 As Button
        Friend WithEvents BtnReconcile As Button
        Friend WithEvents Label20 As Label
        Friend WithEvents Label21 As Label
        Friend WithEvents TxtCashSavingsRate As TextBox
        Friend WithEvents Label22 As Label
    End Class

End Namespace
