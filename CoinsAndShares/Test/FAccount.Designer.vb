Namespace Test
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
            Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.TxtAccountCode = New System.Windows.Forms.TextBox()
            Me.TxtAccountName = New System.Windows.Forms.TextBox()
            Me.TxtAccountType = New System.Windows.Forms.TextBox()
            Me.CmbNetworkId = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TxtNotes = New System.Windows.Forms.TextBox()
            Me.ChkIncludeOnShortcuts = New System.Windows.Forms.CheckBox()
            Me.BtnSave = New System.Windows.Forms.Button()
            Me.GrdTransactions = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.GrdHoldings = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.Panel1 = New System.Windows.Forms.Panel()
            CType(Me.CmbNetworkId, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer2.Panel1.SuspendLayout()
            Me.SplitContainer2.Panel2.SuspendLayout()
            Me.SplitContainer2.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(37, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "CODE"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(3, 28)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(38, 16)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "NAME"
            '
            'TxtAccountCode
            '
            Me.TxtAccountCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAccountCode.Location = New System.Drawing.Point(69, 3)
            Me.TxtAccountCode.Name = "TxtAccountCode"
            Me.TxtAccountCode.ReadOnly = True
            Me.TxtAccountCode.Size = New System.Drawing.Size(172, 22)
            Me.TxtAccountCode.TabIndex = 2
            Me.TxtAccountCode.Text = "TxtAccountCode"
            '
            'TxtAccountName
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtAccountName, 2)
            Me.TxtAccountName.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAccountName.Location = New System.Drawing.Point(69, 31)
            Me.TxtAccountName.Name = "TxtAccountName"
            Me.TxtAccountName.Size = New System.Drawing.Size(350, 22)
            Me.TxtAccountName.TabIndex = 3
            Me.TxtAccountName.Text = "TxtAccountName"
            '
            'TxtAccountType
            '
            Me.TxtAccountType.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAccountType.Location = New System.Drawing.Point(247, 3)
            Me.TxtAccountType.Name = "TxtAccountType"
            Me.TxtAccountType.ReadOnly = True
            Me.TxtAccountType.Size = New System.Drawing.Size(172, 22)
            Me.TxtAccountType.TabIndex = 4
            Me.TxtAccountType.Text = "TxtAccountType"
            '
            'CmbNetworkId
            '
            Me.CmbNetworkId.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbNetworkId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbNetworkId.DisplayMember = ""
            Me.CmbNetworkId.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbNetworkId.Location = New System.Drawing.Point(69, 59)
            Me.CmbNetworkId.Name = "CmbNetworkId"
            Me.CmbNetworkId.Size = New System.Drawing.Size(172, 22)
            Me.CmbNetworkId.TabIndex = 10
            Me.CmbNetworkId.ValueMember = ""
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 56)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(60, 16)
            Me.Label3.TabIndex = 11
            Me.Label3.Text = "NETWORK"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(3, 84)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(42, 16)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "NOTES"
            '
            'TxtNotes
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtNotes, 2)
            Me.TxtNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtNotes.Location = New System.Drawing.Point(69, 87)
            Me.TxtNotes.Multiline = True
            Me.TxtNotes.Name = "TxtNotes"
            Me.TxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TxtNotes.Size = New System.Drawing.Size(350, 151)
            Me.TxtNotes.TabIndex = 13
            Me.TxtNotes.Text = "TxtNotes"
            '
            'ChkIncludeOnShortcuts
            '
            Me.ChkIncludeOnShortcuts.AutoSize = True
            Me.ChkIncludeOnShortcuts.Dock = System.Windows.Forms.DockStyle.Top
            Me.ChkIncludeOnShortcuts.Location = New System.Drawing.Point(247, 59)
            Me.ChkIncludeOnShortcuts.Name = "ChkIncludeOnShortcuts"
            Me.ChkIncludeOnShortcuts.Size = New System.Drawing.Size(172, 17)
            Me.ChkIncludeOnShortcuts.TabIndex = 14
            Me.ChkIncludeOnShortcuts.Text = "Shortcut"
            Me.ChkIncludeOnShortcuts.UseVisualStyleBackColor = True
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
            Me.BtnSave.Size = New System.Drawing.Size(58, 28)
            Me.BtnSave.TabIndex = 15
            Me.BtnSave.Text = "SAVE"
            Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSave.UseVisualStyleBackColor = False
            '
            'GrdTransactions
            '
            Appearance1.BackColor = System.Drawing.Color.Silver
            Me.GrdTransactions.DisplayLayout.Appearance = Appearance1
            Me.GrdTransactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdTransactions.Location = New System.Drawing.Point(0, 0)
            Me.GrdTransactions.Name = "GrdTransactions"
            Me.GrdTransactions.Size = New System.Drawing.Size(776, 252)
            Me.GrdTransactions.TabIndex = 16
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 3
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountCode, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountType, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtNotes, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.ChkIncludeOnShortcuts, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountName, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbNetworkId, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(422, 241)
            Me.TableLayoutPanel1.TabIndex = 17
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.GrdHoldings)
            Me.SplitContainer1.Size = New System.Drawing.Size(784, 241)
            Me.SplitContainer1.SplitterDistance = 422
            Me.SplitContainer1.TabIndex = 18
            '
            'GrdHoldings
            '
            Appearance2.BackColor = System.Drawing.Color.Silver
            Me.GrdHoldings.DisplayLayout.Appearance = Appearance2
            Me.GrdHoldings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdHoldings.Location = New System.Drawing.Point(0, 0)
            Me.GrdHoldings.Name = "GrdHoldings"
            Me.GrdHoldings.Size = New System.Drawing.Size(358, 241)
            Me.GrdHoldings.TabIndex = 17
            Me.GrdHoldings.Text = "HOLDINGS"
            '
            'SplitContainer2
            '
            Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
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
            Me.SplitContainer2.Size = New System.Drawing.Size(784, 523)
            Me.SplitContainer2.SplitterDistance = 241
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
            Me.TabControl1.Size = New System.Drawing.Size(784, 278)
            Me.TabControl1.TabIndex = 17
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.GrdTransactions)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(776, 252)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "TRANSACTIONS"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(776, 252)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "ANALYSIS"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnSave)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 523)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 20
            '
            'FAccount
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.SplitContainer2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.WindowText
            Me.Name = "FAccount"
            Me.Text = "FAccount"
            CType(Me.CmbNetworkId, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer2.Panel1.ResumeLayout(False)
            Me.SplitContainer2.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer2.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents TxtAccountCode As TextBox
        Friend WithEvents TxtAccountName As TextBox
        Friend WithEvents TxtAccountType As TextBox
        Friend WithEvents CmbNetworkId As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label3 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents TxtNotes As TextBox
        Friend WithEvents ChkIncludeOnShortcuts As CheckBox
        Friend WithEvents BtnSave As Button
        Friend WithEvents GrdTransactions As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents SplitContainer1 As SplitContainer
        Friend WithEvents SplitContainer2 As SplitContainer
        Friend WithEvents Panel1 As Panel
        Friend WithEvents GrdHoldings As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
    End Class

End Namespace
