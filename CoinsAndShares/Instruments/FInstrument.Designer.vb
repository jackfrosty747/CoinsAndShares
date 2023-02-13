Namespace Instruments
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FInstrument
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnSave = New System.Windows.Forms.Button()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.TxtProviderLinkCode = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TxtInstrumentCode = New System.Windows.Forms.TextBox()
            Me.TxtDescription = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TxtRate = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.LblQuantityHeld = New System.Windows.Forms.Label()
            Me.TxtInstrumentTypeName = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.BtnSelectLinkSymbol = New System.Windows.Forms.Button()
            Me.LblUpdated = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.CmbCurrencyCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.TxtProviderMultiplier = New System.Windows.Forms.TextBox()
            Me.BtnGetRate = New System.Windows.Forms.Button()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.TxtNotes = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.CmbHedgingGroupCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.GrdTransactions = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.BtnEdit = New System.Windows.Forms.Button()
            Me.BtnDelete = New System.Windows.Forms.Button()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.GrdHoldings = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.Panel1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.CmbCurrencyCode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbHedgingGroupCode, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnSave)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 403)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(624, 38)
            Me.Panel1.TabIndex = 5
            '
            'BtnSave
            '
            Me.BtnSave.AutoSize = True
            Me.BtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnSave.Image = Global.CoinsAndShares.My.Resources.Resources.disk
            Me.BtnSave.Location = New System.Drawing.Point(5, 5)
            Me.BtnSave.Name = "BtnSave"
            Me.BtnSave.Size = New System.Drawing.Size(56, 28)
            Me.BtnSave.TabIndex = 2
            Me.BtnSave.Text = "&Save"
            Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSave.UseVisualStyleBackColor = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 8
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.TxtProviderLinkCode, 2, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtInstrumentCode, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtDescription, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtRate, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.LblQuantityHeld, 5, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtInstrumentTypeName, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.BtnSelectLinkSymbol, 3, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.LblUpdated, 2, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.Label7, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbCurrencyCode, 2, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtProviderMultiplier, 5, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.BtnGetRate, 3, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label9, 4, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label8, 4, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtNotes, 5, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label10, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbHedgingGroupCode, 2, 8)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 9
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 234)
            Me.TableLayoutPanel1.TabIndex = 4
            '
            'TxtProviderLinkCode
            '
            Me.TxtProviderLinkCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtProviderLinkCode.Location = New System.Drawing.Point(132, 180)
            Me.TxtProviderLinkCode.Name = "TxtProviderLinkCode"
            Me.TxtProviderLinkCode.Size = New System.Drawing.Size(94, 22)
            Me.TxtProviderLinkCode.TabIndex = 13
            Me.TxtProviderLinkCode.Text = "TxtProviderLinkCode"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(23, 76)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(30, 16)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Type"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(23, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(36, 16)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Name"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(23, 20)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(93, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Instrument Code"
            '
            'TxtInstrumentCode
            '
            Me.TxtInstrumentCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtInstrumentCode.Location = New System.Drawing.Point(132, 23)
            Me.TxtInstrumentCode.Name = "TxtInstrumentCode"
            Me.TxtInstrumentCode.ReadOnly = True
            Me.TxtInstrumentCode.Size = New System.Drawing.Size(94, 22)
            Me.TxtInstrumentCode.TabIndex = 1
            Me.TxtInstrumentCode.Text = "TxtInstrumentCode"
            '
            'TxtDescription
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtDescription, 2)
            Me.TxtDescription.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtDescription.Location = New System.Drawing.Point(132, 51)
            Me.TxtDescription.Name = "TxtDescription"
            Me.TxtDescription.Size = New System.Drawing.Size(219, 22)
            Me.TxtDescription.TabIndex = 3
            Me.TxtDescription.Text = "TxtDescription"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(23, 104)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(30, 16)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "Rate"
            '
            'TxtRate
            '
            Me.TxtRate.Location = New System.Drawing.Point(132, 107)
            Me.TxtRate.Name = "TxtRate"
            Me.TxtRate.Size = New System.Drawing.Size(94, 22)
            Me.TxtRate.TabIndex = 7
            Me.TxtRate.Text = "TxtRate"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(357, 20)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label5.Size = New System.Drawing.Size(51, 16)
            Me.Label5.TabIndex = 15
            Me.Label5.Text = "Qty Held"
            '
            'LblQuantityHeld
            '
            Me.LblQuantityHeld.AutoSize = True
            Me.LblQuantityHeld.ForeColor = System.Drawing.Color.Blue
            Me.LblQuantityHeld.Location = New System.Drawing.Point(420, 20)
            Me.LblQuantityHeld.Name = "LblQuantityHeld"
            Me.LblQuantityHeld.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblQuantityHeld.Size = New System.Drawing.Size(90, 16)
            Me.LblQuantityHeld.TabIndex = 16
            Me.LblQuantityHeld.Text = "LblQuantityHeld"
            '
            'TxtInstrumentTypeName
            '
            Me.TxtInstrumentTypeName.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtInstrumentTypeName.Location = New System.Drawing.Point(132, 79)
            Me.TxtInstrumentTypeName.Name = "TxtInstrumentTypeName"
            Me.TxtInstrumentTypeName.ReadOnly = True
            Me.TxtInstrumentTypeName.Size = New System.Drawing.Size(94, 22)
            Me.TxtInstrumentTypeName.TabIndex = 5
            Me.TxtInstrumentTypeName.Text = "TxtInstrumentTypeName"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(23, 177)
            Me.Label6.Name = "Label6"
            Me.Label6.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label6.Size = New System.Drawing.Size(103, 16)
            Me.Label6.TabIndex = 12
            Me.Label6.Text = "Provider Link Code"
            '
            'BtnSelectLinkSymbol
            '
            Me.BtnSelectLinkSymbol.AutoSize = True
            Me.BtnSelectLinkSymbol.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSelectLinkSymbol.Image = Global.CoinsAndShares.My.Resources.Resources.chain
            Me.BtnSelectLinkSymbol.Location = New System.Drawing.Point(232, 180)
            Me.BtnSelectLinkSymbol.Name = "BtnSelectLinkSymbol"
            Me.BtnSelectLinkSymbol.Size = New System.Drawing.Size(63, 23)
            Me.BtnSelectLinkSymbol.TabIndex = 14
            Me.BtnSelectLinkSymbol.Text = "Select"
            Me.BtnSelectLinkSymbol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSelectLinkSymbol.UseVisualStyleBackColor = False
            '
            'LblUpdated
            '
            Me.LblUpdated.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.LblUpdated, 3)
            Me.LblUpdated.Location = New System.Drawing.Point(132, 133)
            Me.LblUpdated.Name = "LblUpdated"
            Me.LblUpdated.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblUpdated.Size = New System.Drawing.Size(67, 16)
            Me.LblUpdated.TabIndex = 9
            Me.LblUpdated.Text = "LblUpdated"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(23, 149)
            Me.Label7.Name = "Label7"
            Me.Label7.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label7.Size = New System.Drawing.Size(52, 16)
            Me.Label7.TabIndex = 10
            Me.Label7.Text = "Currency"
            '
            'CmbCurrencyCode
            '
            Me.CmbCurrencyCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbCurrencyCode.DisplayMember = ""
            Me.CmbCurrencyCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbCurrencyCode.Location = New System.Drawing.Point(132, 152)
            Me.CmbCurrencyCode.Name = "CmbCurrencyCode"
            Me.CmbCurrencyCode.Size = New System.Drawing.Size(94, 22)
            Me.CmbCurrencyCode.TabIndex = 11
            Me.CmbCurrencyCode.ValueMember = ""
            '
            'TxtProviderMultiplier
            '
            Me.TxtProviderMultiplier.Location = New System.Drawing.Point(420, 180)
            Me.TxtProviderMultiplier.Name = "TxtProviderMultiplier"
            Me.TxtProviderMultiplier.Size = New System.Drawing.Size(94, 22)
            Me.TxtProviderMultiplier.TabIndex = 20
            Me.TxtProviderMultiplier.Text = "TxtProviderMultiplier"
            Me.ToolTip1.SetToolTip(Me.TxtProviderMultiplier, "It the rate returned by the rate provider needs adjusting, in case it's in differ" &
        "ent units.  0.01 if the provider returns pence and we need £")
            '
            'BtnGetRate
            '
            Me.BtnGetRate.AutoSize = True
            Me.BtnGetRate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnGetRate.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnGetRate.Image = Global.CoinsAndShares.My.Resources.Resources.globe
            Me.BtnGetRate.Location = New System.Drawing.Point(232, 107)
            Me.BtnGetRate.Name = "BtnGetRate"
            Me.BtnGetRate.Size = New System.Drawing.Size(97, 23)
            Me.BtnGetRate.TabIndex = 8
            Me.BtnGetRate.Text = "Update Rate"
            Me.BtnGetRate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnGetRate.UseVisualStyleBackColor = False
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(357, 48)
            Me.Label9.Name = "Label9"
            Me.Label9.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label9.Size = New System.Drawing.Size(37, 16)
            Me.Label9.TabIndex = 17
            Me.Label9.Text = "Notes"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(357, 177)
            Me.Label8.Name = "Label8"
            Me.Label8.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label8.Size = New System.Drawing.Size(57, 16)
            Me.Label8.TabIndex = 19
            Me.Label8.Text = "Multiplier"
            '
            'TxtNotes
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtNotes, 2)
            Me.TxtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtNotes.Location = New System.Drawing.Point(420, 51)
            Me.TxtNotes.Multiline = True
            Me.TxtNotes.Name = "TxtNotes"
            Me.TableLayoutPanel1.SetRowSpan(Me.TxtNotes, 5)
            Me.TxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TxtNotes.Size = New System.Drawing.Size(181, 123)
            Me.TxtNotes.TabIndex = 18
            Me.TxtNotes.Text = "TxtNotes"
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(23, 206)
            Me.Label10.Name = "Label10"
            Me.Label10.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label10.Size = New System.Drawing.Size(88, 16)
            Me.Label10.TabIndex = 21
            Me.Label10.Text = "Hedging Group"
            '
            'CmbHedgingGroupCode
            '
            Me.CmbHedgingGroupCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbHedgingGroupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbHedgingGroupCode.DisplayMember = ""
            Me.CmbHedgingGroupCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbHedgingGroupCode.Location = New System.Drawing.Point(132, 209)
            Me.CmbHedgingGroupCode.Name = "CmbHedgingGroupCode"
            Me.CmbHedgingGroupCode.Size = New System.Drawing.Size(94, 22)
            Me.CmbHedgingGroupCode.TabIndex = 22
            Me.CmbHedgingGroupCode.ValueMember = ""
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(0, 234)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(624, 169)
            Me.TabControl1.TabIndex = 6
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.GrdTransactions)
            Me.TabPage1.Controls.Add(Me.Panel2)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(616, 143)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Transactions"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'GrdTransactions
            '
            Me.GrdTransactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdTransactions.Location = New System.Drawing.Point(3, 3)
            Me.GrdTransactions.Name = "GrdTransactions"
            Me.GrdTransactions.Size = New System.Drawing.Size(610, 99)
            Me.GrdTransactions.TabIndex = 4
            Me.GrdTransactions.Text = "Transactions"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.Controls.Add(Me.BtnEdit)
            Me.Panel2.Controls.Add(Me.BtnDelete)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(3, 102)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(610, 38)
            Me.Panel2.TabIndex = 5
            '
            'BtnEdit
            '
            Me.BtnEdit.AutoSize = True
            Me.BtnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnEdit.Image = Global.CoinsAndShares.My.Resources.Resources.pencil
            Me.BtnEdit.Location = New System.Drawing.Point(5, 5)
            Me.BtnEdit.Name = "BtnEdit"
            Me.BtnEdit.Size = New System.Drawing.Size(115, 28)
            Me.BtnEdit.TabIndex = 5
            Me.BtnEdit.Text = "Edit Transaction"
            Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnEdit.UseVisualStyleBackColor = False
            '
            'BtnDelete
            '
            Me.BtnDelete.AutoSize = True
            Me.BtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnDelete.Image = Global.CoinsAndShares.My.Resources.Resources.cross_script
            Me.BtnDelete.Location = New System.Drawing.Point(472, 5)
            Me.BtnDelete.Name = "BtnDelete"
            Me.BtnDelete.Size = New System.Drawing.Size(133, 28)
            Me.BtnDelete.TabIndex = 4
            Me.BtnDelete.Text = "&Delete Transactions"
            Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnDelete.UseVisualStyleBackColor = False
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.GrdHoldings)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(616, 143)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Holdings"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'GrdHoldings
            '
            Me.GrdHoldings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdHoldings.Location = New System.Drawing.Point(3, 3)
            Me.GrdHoldings.Name = "GrdHoldings"
            Me.GrdHoldings.Size = New System.Drawing.Size(610, 137)
            Me.GrdHoldings.TabIndex = 5
            Me.GrdHoldings.Text = "Holdings"
            '
            'FInstrument
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.TabControl1)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FInstrument"
            Me.Text = "Instrument"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.CmbCurrencyCode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbHedgingGroupCode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnSave As Button
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents Label3 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label1 As Label
        Friend WithEvents TxtInstrumentCode As TextBox
        Friend WithEvents TxtDescription As TextBox
        Friend WithEvents Label4 As Label
        Friend WithEvents TxtRate As TextBox
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents GrdTransactions As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Label5 As Label
        Friend WithEvents LblQuantityHeld As Label
        Friend WithEvents Panel2 As Panel
        Friend WithEvents BtnDelete As Button
        Friend WithEvents BtnEdit As Button
        Friend WithEvents TxtInstrumentTypeName As TextBox
        Friend WithEvents Label6 As Label
        Friend WithEvents TxtProviderLinkCode As TextBox
        Friend WithEvents BtnSelectLinkSymbol As Button
        Friend WithEvents LblUpdated As Label
        Friend WithEvents Label7 As Label
        Friend WithEvents CmbCurrencyCode As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents BtnGetRate As Button
        Friend WithEvents Label8 As Label
        Friend WithEvents TxtProviderMultiplier As TextBox
        Friend WithEvents ToolTip1 As ToolTip
        Friend WithEvents Label9 As Label
        Friend WithEvents TxtNotes As TextBox
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents GrdHoldings As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Label10 As Label
        Friend WithEvents CmbHedgingGroupCode As Infragistics.Win.UltraWinGrid.UltraCombo
    End Class

End Namespace
