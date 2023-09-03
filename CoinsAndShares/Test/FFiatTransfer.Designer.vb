Imports MaterialSkin.Controls

Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FFiatTransfer
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.MBtnCancel = New MaterialSkin.Controls.MaterialButton()
            Me.MBtnOk = New MaterialSkin.Controls.MaterialButton()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.CmbAccountFrom = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.CmbAccountTo = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.LblAccountNameFrom = New System.Windows.Forms.Label()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.LblBalanceFrom = New System.Windows.Forms.Label()
            Me.LblBalanceTo = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.LblAccountNameTo = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TxtAmount = New System.Windows.Forms.TextBox()
            Me.BtnAll = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.DtpTransferDate = New System.Windows.Forms.DateTimePicker()
            Me.Panel1.SuspendLayout()
            CType(Me.CmbAccountFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbAccountTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.MBtnCancel)
            Me.Panel1.Controls.Add(Me.MBtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(3, 293)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(428, 45)
            Me.Panel1.TabIndex = 1
            '
            'MBtnCancel
            '
            Me.MBtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnCancel.Depth = 0
            Me.MBtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.MBtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.MBtnCancel.HighEmphasis = True
            Me.MBtnCancel.Icon = Nothing
            Me.MBtnCancel.Location = New System.Drawing.Point(346, 5)
            Me.MBtnCancel.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnCancel.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnCancel.Name = "MBtnCancel"
            Me.MBtnCancel.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnCancel.Size = New System.Drawing.Size(77, 35)
            Me.MBtnCancel.TabIndex = 1
            Me.MBtnCancel.Text = "Cancel"
            Me.MBtnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnCancel.UseAccentColor = False
            Me.MBtnCancel.UseVisualStyleBackColor = True
            '
            'MBtnOk
            '
            Me.MBtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnOk.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnOk.Depth = 0
            Me.MBtnOk.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnOk.HighEmphasis = True
            Me.MBtnOk.Icon = Nothing
            Me.MBtnOk.Location = New System.Drawing.Point(5, 5)
            Me.MBtnOk.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnOk.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnOk.Name = "MBtnOk"
            Me.MBtnOk.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnOk.Size = New System.Drawing.Size(64, 35)
            Me.MBtnOk.TabIndex = 0
            Me.MBtnOk.Text = "OK"
            Me.MBtnOk.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnOk.UseAccentColor = False
            Me.MBtnOk.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(23, 69)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(39, 18)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "FROM"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(23, 179)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(21, 18)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "TO"
            '
            'CmbAccountFrom
            '
            Me.CmbAccountFrom.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountFrom.DisplayMember = ""
            Me.CmbAccountFrom.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbAccountFrom.Location = New System.Drawing.Point(84, 72)
            Me.CmbAccountFrom.Name = "CmbAccountFrom"
            Me.CmbAccountFrom.Size = New System.Drawing.Size(143, 22)
            Me.CmbAccountFrom.TabIndex = 3
            Me.CmbAccountFrom.ValueMember = ""
            '
            'CmbAccountTo
            '
            Me.CmbAccountTo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountTo.DisplayMember = ""
            Me.CmbAccountTo.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbAccountTo.Location = New System.Drawing.Point(84, 182)
            Me.CmbAccountTo.Name = "CmbAccountTo"
            Me.CmbAccountTo.Size = New System.Drawing.Size(143, 22)
            Me.CmbAccountTo.TabIndex = 7
            Me.CmbAccountTo.ValueMember = ""
            '
            'LblAccountNameFrom
            '
            Me.LblAccountNameFrom.AutoSize = True
            Me.LblAccountNameFrom.Location = New System.Drawing.Point(233, 69)
            Me.LblAccountNameFrom.Name = "LblAccountNameFrom"
            Me.LblAccountNameFrom.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblAccountNameFrom.Size = New System.Drawing.Size(119, 18)
            Me.LblAccountNameFrom.TabIndex = 2
            Me.LblAccountNameFrom.Text = "LblAccountNameFrom"
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 5
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.LblBalanceFrom, 3, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.LblBalanceTo, 3, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.LblAccountNameTo, 3, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.LblAccountNameFrom, 3, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbAccountTo, 2, 8)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbAccountFrom, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 9)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAmount, 2, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.BtnAll, 3, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.DtpTransferDate, 2, 1)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 64)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 10
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(428, 229)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(23, 130)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(55, 18)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "AMOUNT"
            '
            'LblBalanceFrom
            '
            Me.LblBalanceFrom.AutoSize = True
            Me.LblBalanceFrom.ForeColor = System.Drawing.Color.Blue
            Me.LblBalanceFrom.Location = New System.Drawing.Point(233, 97)
            Me.LblBalanceFrom.Name = "LblBalanceFrom"
            Me.LblBalanceFrom.Size = New System.Drawing.Size(87, 13)
            Me.LblBalanceFrom.TabIndex = 4
            Me.LblBalanceFrom.Text = "LblBalanceFrom"
            '
            'LblBalanceTo
            '
            Me.LblBalanceTo.AutoSize = True
            Me.LblBalanceTo.ForeColor = System.Drawing.Color.Blue
            Me.LblBalanceTo.Location = New System.Drawing.Point(233, 207)
            Me.LblBalanceTo.Name = "LblBalanceTo"
            Me.LblBalanceTo.Size = New System.Drawing.Size(73, 13)
            Me.LblBalanceTo.TabIndex = 12
            Me.LblBalanceTo.Text = "LblBalanceTo"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.ForeColor = System.Drawing.Color.Blue
            Me.Label4.Location = New System.Drawing.Point(84, 97)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 13)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "BALANCE:"
            '
            'LblAccountNameTo
            '
            Me.LblAccountNameTo.AutoSize = True
            Me.LblAccountNameTo.Location = New System.Drawing.Point(233, 179)
            Me.LblAccountNameTo.Name = "LblAccountNameTo"
            Me.LblAccountNameTo.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblAccountNameTo.Size = New System.Drawing.Size(105, 18)
            Me.LblAccountNameTo.TabIndex = 10
            Me.LblAccountNameTo.Text = "LblAccountNameTo"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.ForeColor = System.Drawing.Color.Blue
            Me.Label5.Location = New System.Drawing.Point(84, 207)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(56, 13)
            Me.Label5.TabIndex = 11
            Me.Label5.Text = "BALANCE:"
            '
            'TxtAmount
            '
            Me.TxtAmount.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAmount.Location = New System.Drawing.Point(84, 133)
            Me.TxtAmount.Name = "TxtAmount"
            Me.TxtAmount.Size = New System.Drawing.Size(143, 22)
            Me.TxtAmount.TabIndex = 5
            '
            'BtnAll
            '
            Me.BtnAll.AutoSize = True
            Me.BtnAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnAll.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnAll.Location = New System.Drawing.Point(233, 133)
            Me.BtnAll.Name = "BtnAll"
            Me.BtnAll.Size = New System.Drawing.Size(34, 23)
            Me.BtnAll.TabIndex = 7
            Me.BtnAll.Text = "ALL"
            Me.BtnAll.UseVisualStyleBackColor = False
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(23, 21)
            Me.Label6.Name = "Label6"
            Me.Label6.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label6.Size = New System.Drawing.Size(33, 18)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "DATE"
            '
            'DtpTransferDate
            '
            Me.DtpTransferDate.Dock = System.Windows.Forms.DockStyle.Top
            Me.DtpTransferDate.Location = New System.Drawing.Point(84, 24)
            Me.DtpTransferDate.Name = "DtpTransferDate"
            Me.DtpTransferDate.Size = New System.Drawing.Size(143, 22)
            Me.DtpTransferDate.TabIndex = 1
            '
            'FFiatTransfer
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.MBtnCancel
            Me.ClientSize = New System.Drawing.Size(434, 341)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FFiatTransfer"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "FIAT Transfer"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.CmbAccountFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbAccountTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents CmbAccountFrom As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents CmbAccountTo As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents LblAccountNameFrom As Label
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents LblAccountNameTo As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents LblBalanceFrom As Label
        Friend WithEvents LblBalanceTo As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents TxtAmount As TextBox
        Friend WithEvents BtnAll As Button
        Friend WithEvents Label6 As Label
        Friend WithEvents DtpTransferDate As DateTimePicker
        Friend WithEvents MBtnCancel As MaterialButton
        Friend WithEvents MBtnOk As MaterialButton
    End Class

End Namespace
