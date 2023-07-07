Imports MaterialSkin.Controls

Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccountNew
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
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.MCmbAccountTypeName = New MaterialSkin.Controls.MaterialComboBox()
            Me.MTxtAccountCode = New MaterialSkin.Controls.MaterialTextBox2()
            Me.MTxtAccountName = New MaterialSkin.Controls.MaterialTextBox2()
            Me.Panel1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.MBtnCancel)
            Me.Panel1.Controls.Add(Me.MBtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(3, 432)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(634, 45)
            Me.Panel1.TabIndex = 1
            '
            'MBtnCancel
            '
            Me.MBtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnCancel.Depth = 0
            Me.MBtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.MBtnCancel.HighEmphasis = True
            Me.MBtnCancel.Icon = Nothing
            Me.MBtnCancel.Location = New System.Drawing.Point(552, 5)
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
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.MCmbAccountTypeName, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.MTxtAccountCode, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.MTxtAccountName, 1, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 64)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(634, 368)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'MCmbAccountTypeName
            '
            Me.MCmbAccountTypeName.AutoResize = False
            Me.MCmbAccountTypeName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.MCmbAccountTypeName.Depth = 0
            Me.MCmbAccountTypeName.Dock = System.Windows.Forms.DockStyle.Top
            Me.MCmbAccountTypeName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
            Me.MCmbAccountTypeName.DropDownHeight = 174
            Me.MCmbAccountTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.MCmbAccountTypeName.DropDownWidth = 121
            Me.MCmbAccountTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
            Me.MCmbAccountTypeName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.MCmbAccountTypeName.FormattingEnabled = True
            Me.MCmbAccountTypeName.Hint = "Account Type"
            Me.MCmbAccountTypeName.IntegralHeight = False
            Me.MCmbAccountTypeName.ItemHeight = 43
            Me.MCmbAccountTypeName.Location = New System.Drawing.Point(23, 213)
            Me.MCmbAccountTypeName.MaxDropDownItems = 4
            Me.MCmbAccountTypeName.MouseState = MaterialSkin.MouseState.OUT
            Me.MCmbAccountTypeName.Name = "MCmbAccountTypeName"
            Me.MCmbAccountTypeName.Size = New System.Drawing.Size(194, 49)
            Me.MCmbAccountTypeName.StartIndex = 0
            Me.MCmbAccountTypeName.TabIndex = 2
            '
            'MTxtAccountCode
            '
            Me.MTxtAccountCode.AnimateReadOnly = False
            Me.MTxtAccountCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.MTxtAccountCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.MTxtAccountCode.Depth = 0
            Me.MTxtAccountCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MTxtAccountCode.HideSelection = True
            Me.MTxtAccountCode.Hint = "Account Code"
            Me.MTxtAccountCode.LeadingIcon = Nothing
            Me.MTxtAccountCode.Location = New System.Drawing.Point(23, 105)
            Me.MTxtAccountCode.MaxLength = 32767
            Me.MTxtAccountCode.MouseState = MaterialSkin.MouseState.OUT
            Me.MTxtAccountCode.Name = "MTxtAccountCode"
            Me.MTxtAccountCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
            Me.MTxtAccountCode.PrefixSuffixText = Nothing
            Me.MTxtAccountCode.ReadOnly = False
            Me.MTxtAccountCode.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.MTxtAccountCode.SelectedText = ""
            Me.MTxtAccountCode.SelectionLength = 0
            Me.MTxtAccountCode.SelectionStart = 0
            Me.MTxtAccountCode.ShortcutsEnabled = True
            Me.MTxtAccountCode.Size = New System.Drawing.Size(194, 48)
            Me.MTxtAccountCode.TabIndex = 0
            Me.MTxtAccountCode.TabStop = False
            Me.MTxtAccountCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.MTxtAccountCode.TrailingIcon = Nothing
            Me.MTxtAccountCode.UseSystemPasswordChar = False
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
            Me.MTxtAccountName.Location = New System.Drawing.Point(23, 159)
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
            Me.MTxtAccountName.Size = New System.Drawing.Size(588, 48)
            Me.MTxtAccountName.TabIndex = 1
            Me.MTxtAccountName.TabStop = False
            Me.MTxtAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.MTxtAccountName.TrailingIcon = Nothing
            Me.MTxtAccountName.UseSystemPasswordChar = False
            '
            'FAccountNew
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(640, 480)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FAccountNew"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Create Account"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As Panel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents MBtnOk As MaterialButton
        Friend WithEvents MBtnCancel As MaterialButton
        Friend WithEvents MCmbAccountTypeName As MaterialComboBox
        Friend WithEvents MTxtAccountCode As MaterialTextBox2
        Friend WithEvents MTxtAccountName As MaterialTextBox2
    End Class

End Namespace
