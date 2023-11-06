Imports MaterialSkin.Controls

Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccount
        Inherits MaterialForm

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
            Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
            Me.MLblAccountType = New MaterialSkin.Controls.MaterialLabel()
            Me.MLblAccountCode = New MaterialSkin.Controls.MaterialLabel()
            Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
            Me.MTxtNotes = New MaterialSkin.Controls.MaterialMultiLineTextBox()
            Me.MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
            Me.MTxtAccountName = New MaterialSkin.Controls.MaterialTextBox2()
            Me.MCboNetworkId = New MaterialSkin.Controls.MaterialComboBox()
            Me.MSwEnableNetwork = New MaterialSkin.Controls.MaterialSwitch()
            Me.MSwShortcut = New MaterialSkin.Controls.MaterialSwitch()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.PnlNetworkColour = New System.Windows.Forms.Panel()
            Me.GrdHoldings = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.GrdTransactions = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.MBtnSwap = New MaterialSkin.Controls.MaterialButton()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.MBtnSave = New MaterialSkin.Controls.MaterialButton()
            Me.MSwNonTaxable = New MaterialSkin.Controls.MaterialSwitch()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.PnlNetworkColour.SuspendLayout()
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer2.Panel1.SuspendLayout()
            Me.SplitContainer2.Panel2.SuspendLayout()
            Me.SplitContainer2.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.MSwNonTaxable, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.MaterialLabel1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.MLblAccountType, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.MLblAccountCode, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.MaterialLabel2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.MTxtNotes, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.MaterialLabel3, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.MTxtAccountName, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.MCboNetworkId, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.MSwEnableNetwork, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.MSwShortcut, 2, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 5)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(416, 213)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'MaterialLabel1
            '
            Me.MaterialLabel1.AutoSize = True
            Me.MaterialLabel1.Depth = 0
            Me.MaterialLabel1.Dock = System.Windows.Forms.DockStyle.Left
            Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel1.Location = New System.Drawing.Point(3, 0)
            Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel1.Name = "MaterialLabel1"
            Me.MaterialLabel1.Size = New System.Drawing.Size(37, 30)
            Me.MaterialLabel1.TabIndex = 15
            Me.MaterialLabel1.Text = "Code"
            Me.MaterialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MLblAccountType
            '
            Me.MLblAccountType.AutoSize = True
            Me.MLblAccountType.Depth = 0
            Me.MLblAccountType.Dock = System.Windows.Forms.DockStyle.Left
            Me.MLblAccountType.Font = New System.Drawing.Font("Roboto", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
            Me.MLblAccountType.FontType = MaterialSkin.MaterialSkinManager.fontType.SubtleEmphasis
            Me.MLblAccountType.Location = New System.Drawing.Point(269, 0)
            Me.MLblAccountType.MouseState = MaterialSkin.MouseState.HOVER
            Me.MLblAccountType.Name = "MLblAccountType"
            Me.MLblAccountType.Size = New System.Drawing.Size(98, 30)
            Me.MLblAccountType.TabIndex = 17
            Me.MLblAccountType.Text = "MLblAccountType"
            Me.MLblAccountType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MLblAccountCode
            '
            Me.MLblAccountCode.AutoSize = True
            Me.MLblAccountCode.Depth = 0
            Me.MLblAccountCode.Dock = System.Windows.Forms.DockStyle.Left
            Me.MLblAccountCode.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MLblAccountCode.Location = New System.Drawing.Point(119, 0)
            Me.MLblAccountCode.MouseState = MaterialSkin.MouseState.HOVER
            Me.MLblAccountCode.Name = "MLblAccountCode"
            Me.MLblAccountCode.Size = New System.Drawing.Size(131, 30)
            Me.MLblAccountCode.TabIndex = 18
            Me.MLblAccountCode.Text = "MLblAccountCode"
            Me.MLblAccountCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MaterialLabel2
            '
            Me.MaterialLabel2.AutoSize = True
            Me.MaterialLabel2.Depth = 0
            Me.MaterialLabel2.Dock = System.Windows.Forms.DockStyle.Left
            Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel2.Location = New System.Drawing.Point(3, 30)
            Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel2.Name = "MaterialLabel2"
            Me.MaterialLabel2.Size = New System.Drawing.Size(43, 42)
            Me.MaterialLabel2.TabIndex = 20
            Me.MaterialLabel2.Text = "Name"
            Me.MaterialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MTxtNotes
            '
            Me.MTxtNotes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.MTxtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.TableLayoutPanel1.SetColumnSpan(Me.MTxtNotes, 2)
            Me.MTxtNotes.Depth = 0
            Me.MTxtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MTxtNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MTxtNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.MTxtNotes.Location = New System.Drawing.Point(119, 153)
            Me.MTxtNotes.MouseState = MaterialSkin.MouseState.HOVER
            Me.MTxtNotes.Name = "MTxtNotes"
            Me.MTxtNotes.Size = New System.Drawing.Size(294, 57)
            Me.MTxtNotes.TabIndex = 24
            Me.MTxtNotes.Text = ""
            '
            'MaterialLabel3
            '
            Me.MaterialLabel3.AutoSize = True
            Me.MaterialLabel3.Depth = 0
            Me.MaterialLabel3.Dock = System.Windows.Forms.DockStyle.Left
            Me.MaterialLabel3.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel3.Location = New System.Drawing.Point(3, 150)
            Me.MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel3.Name = "MaterialLabel3"
            Me.MaterialLabel3.Size = New System.Drawing.Size(42, 63)
            Me.MaterialLabel3.TabIndex = 25
            Me.MaterialLabel3.Text = "Notes"
            Me.MaterialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MTxtAccountName
            '
            Me.MTxtAccountName.AnimateReadOnly = False
            Me.MTxtAccountName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.MTxtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.TableLayoutPanel1.SetColumnSpan(Me.MTxtAccountName, 2)
            Me.MTxtAccountName.Depth = 0
            Me.MTxtAccountName.Dock = System.Windows.Forms.DockStyle.Top
            Me.MTxtAccountName.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MTxtAccountName.HideSelection = True
            Me.MTxtAccountName.Hint = "Account Name"
            Me.MTxtAccountName.LeadingIcon = Nothing
            Me.MTxtAccountName.Location = New System.Drawing.Point(119, 33)
            Me.MTxtAccountName.MaxLength = 32767
            Me.MTxtAccountName.MouseState = MaterialSkin.MouseState.OUT
            Me.MTxtAccountName.Name = "MTxtAccountName"
            Me.MTxtAccountName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
            Me.MTxtAccountName.PrefixSuffixText = Nothing
            Me.MTxtAccountName.ReadOnly = False
            Me.MTxtAccountName.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.MTxtAccountName.SelectedText = ""
            Me.MTxtAccountName.SelectionLength = 0
            Me.MTxtAccountName.SelectionStart = 0
            Me.MTxtAccountName.ShortcutsEnabled = True
            Me.MTxtAccountName.Size = New System.Drawing.Size(294, 36)
            Me.MTxtAccountName.TabIndex = 26
            Me.MTxtAccountName.TabStop = False
            Me.MTxtAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.MTxtAccountName.TrailingIcon = Nothing
            Me.MTxtAccountName.UseSystemPasswordChar = False
            Me.MTxtAccountName.UseTallSize = False
            '
            'MCboNetworkId
            '
            Me.MCboNetworkId.AutoResize = False
            Me.MCboNetworkId.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.MCboNetworkId.Depth = 0
            Me.MCboNetworkId.Dock = System.Windows.Forms.DockStyle.Top
            Me.MCboNetworkId.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
            Me.MCboNetworkId.DropDownHeight = 118
            Me.MCboNetworkId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.MCboNetworkId.DropDownWidth = 121
            Me.MCboNetworkId.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
            Me.MCboNetworkId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.MCboNetworkId.FormattingEnabled = True
            Me.MCboNetworkId.IntegralHeight = False
            Me.MCboNetworkId.ItemHeight = 29
            Me.MCboNetworkId.Location = New System.Drawing.Point(119, 75)
            Me.MCboNetworkId.MaxDropDownItems = 4
            Me.MCboNetworkId.MouseState = MaterialSkin.MouseState.OUT
            Me.MCboNetworkId.Name = "MCboNetworkId"
            Me.MCboNetworkId.Size = New System.Drawing.Size(144, 35)
            Me.MCboNetworkId.StartIndex = 0
            Me.MCboNetworkId.TabIndex = 28
            Me.MCboNetworkId.UseTallSize = False
            '
            'MSwEnableNetwork
            '
            Me.MSwEnableNetwork.AutoSize = True
            Me.MSwEnableNetwork.Depth = 0
            Me.MSwEnableNetwork.Location = New System.Drawing.Point(0, 72)
            Me.MSwEnableNetwork.Margin = New System.Windows.Forms.Padding(0)
            Me.MSwEnableNetwork.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MSwEnableNetwork.MouseState = MaterialSkin.MouseState.HOVER
            Me.MSwEnableNetwork.Name = "MSwEnableNetwork"
            Me.MSwEnableNetwork.Ripple = True
            Me.MSwEnableNetwork.Size = New System.Drawing.Size(116, 37)
            Me.MSwEnableNetwork.TabIndex = 29
            Me.MSwEnableNetwork.Text = "Network"
            Me.MSwEnableNetwork.UseVisualStyleBackColor = True
            '
            'MSwShortcut
            '
            Me.MSwShortcut.AutoSize = True
            Me.MSwShortcut.Depth = 0
            Me.MSwShortcut.Location = New System.Drawing.Point(266, 72)
            Me.MSwShortcut.Margin = New System.Windows.Forms.Padding(0)
            Me.MSwShortcut.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MSwShortcut.MouseState = MaterialSkin.MouseState.HOVER
            Me.MSwShortcut.Name = "MSwShortcut"
            Me.MSwShortcut.Ripple = True
            Me.MSwShortcut.Size = New System.Drawing.Size(118, 37)
            Me.MSwShortcut.TabIndex = 21
            Me.MSwShortcut.Text = "Shortcut"
            Me.MSwShortcut.UseVisualStyleBackColor = True
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.PnlNetworkColour)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.GrdHoldings)
            Me.SplitContainer1.Size = New System.Drawing.Size(794, 223)
            Me.SplitContainer1.SplitterDistance = 426
            Me.SplitContainer1.TabIndex = 18
            '
            'PnlNetworkColour
            '
            Me.PnlNetworkColour.Controls.Add(Me.TableLayoutPanel1)
            Me.PnlNetworkColour.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PnlNetworkColour.Location = New System.Drawing.Point(0, 0)
            Me.PnlNetworkColour.Name = "PnlNetworkColour"
            Me.PnlNetworkColour.Padding = New System.Windows.Forms.Padding(5)
            Me.PnlNetworkColour.Size = New System.Drawing.Size(426, 223)
            Me.PnlNetworkColour.TabIndex = 18
            '
            'GrdHoldings
            '
            Appearance1.BackColor = System.Drawing.Color.Silver
            Me.GrdHoldings.DisplayLayout.Appearance = Appearance1
            Me.GrdHoldings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdHoldings.Location = New System.Drawing.Point(0, 0)
            Me.GrdHoldings.Name = "GrdHoldings"
            Me.GrdHoldings.Size = New System.Drawing.Size(364, 223)
            Me.GrdHoldings.TabIndex = 17
            Me.GrdHoldings.Text = "HOLDINGS"
            '
            'SplitContainer2
            '
            Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer2.Location = New System.Drawing.Point(3, 64)
            Me.SplitContainer2.Name = "SplitContainer2"
            Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitContainer2.Panel1
            '
            Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
            '
            'SplitContainer2.Panel2
            '
            Me.SplitContainer2.Panel2.Controls.Add(Me.TabControl1)
            Me.SplitContainer2.Size = New System.Drawing.Size(794, 488)
            Me.SplitContainer2.SplitterDistance = 223
            Me.SplitContainer2.TabIndex = 19
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(0, 0)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(794, 261)
            Me.TabControl1.TabIndex = 18
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.GrdTransactions)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(786, 235)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "TRANSACTIONS"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'GrdTransactions
            '
            Appearance2.BackColor = System.Drawing.Color.Silver
            Me.GrdTransactions.DisplayLayout.Appearance = Appearance2
            Me.GrdTransactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdTransactions.Location = New System.Drawing.Point(3, 3)
            Me.GrdTransactions.Name = "GrdTransactions"
            Me.GrdTransactions.Size = New System.Drawing.Size(780, 229)
            Me.GrdTransactions.TabIndex = 16
            '
            'TabPage2
            '
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(786, 235)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "ANALYSIS"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.MBtnSwap)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.MBtnSave)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(3, 552)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(794, 45)
            Me.Panel1.TabIndex = 20
            '
            'MBtnSwap
            '
            Me.MBtnSwap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnSwap.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnSwap.Depth = 0
            Me.MBtnSwap.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnSwap.HighEmphasis = True
            Me.MBtnSwap.Icon = Nothing
            Me.MBtnSwap.Location = New System.Drawing.Point(74, 5)
            Me.MBtnSwap.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnSwap.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnSwap.Name = "MBtnSwap"
            Me.MBtnSwap.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnSwap.Size = New System.Drawing.Size(64, 35)
            Me.MBtnSwap.TabIndex = 17
            Me.MBtnSwap.Text = "Swap"
            Me.MBtnSwap.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnSwap.UseAccentColor = False
            Me.MBtnSwap.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(69, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 35)
            Me.Label1.TabIndex = 18
            '
            'MBtnSave
            '
            Me.MBtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnSave.Depth = 0
            Me.MBtnSave.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnSave.HighEmphasis = True
            Me.MBtnSave.Icon = Nothing
            Me.MBtnSave.Location = New System.Drawing.Point(5, 5)
            Me.MBtnSave.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnSave.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnSave.Name = "MBtnSave"
            Me.MBtnSave.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnSave.Size = New System.Drawing.Size(64, 35)
            Me.MBtnSave.TabIndex = 16
            Me.MBtnSave.Text = "Save"
            Me.MBtnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnSave.UseAccentColor = False
            Me.MBtnSave.UseVisualStyleBackColor = True
            '
            'MSwNonTaxable
            '
            Me.MSwNonTaxable.AutoSize = True
            Me.MSwNonTaxable.Depth = 0
            Me.MSwNonTaxable.Location = New System.Drawing.Point(266, 113)
            Me.MSwNonTaxable.Margin = New System.Windows.Forms.Padding(0)
            Me.MSwNonTaxable.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MSwNonTaxable.MouseState = MaterialSkin.MouseState.HOVER
            Me.MSwNonTaxable.Name = "MSwNonTaxable"
            Me.MSwNonTaxable.Ripple = True
            Me.MSwNonTaxable.Size = New System.Drawing.Size(148, 37)
            Me.MSwNonTaxable.TabIndex = 30
            Me.MSwNonTaxable.Text = "Non Taxable"
            Me.MSwNonTaxable.UseVisualStyleBackColor = True
            '
            'FAccount
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 600)
            Me.Controls.Add(Me.SplitContainer2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.WindowText
            Me.Name = "FAccount"
            Me.Text = "FAccount"
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.PnlNetworkColour.ResumeLayout(False)
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer2.Panel1.ResumeLayout(False)
            Me.SplitContainer2.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer2.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents SplitContainer2 As SplitContainer
        Friend WithEvents Panel1 As Panel
        Friend WithEvents GrdHoldings As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents MBtnSave As MaterialButton
        Friend WithEvents MaterialLabel1 As MaterialLabel
        Friend WithEvents MLblAccountType As MaterialLabel
        Friend WithEvents MLblAccountCode As MaterialLabel
        Friend WithEvents MaterialLabel2 As MaterialLabel
        Friend WithEvents MSwShortcut As MaterialSwitch
        Friend WithEvents MTxtNotes As MaterialMultiLineTextBox
        Friend WithEvents MaterialLabel3 As MaterialLabel
        Friend WithEvents MTxtAccountName As MaterialTextBox2
        Friend WithEvents MCboNetworkId As MaterialComboBox
        Friend WithEvents MSwEnableNetwork As MaterialSwitch
        Friend WithEvents PnlNetworkColour As Panel
        Friend WithEvents GrdTransactions As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents MBtnSwap As MaterialButton
        Friend WithEvents Label1 As Label
        Friend WithEvents MSwNonTaxable As MaterialSwitch
    End Class

End Namespace
