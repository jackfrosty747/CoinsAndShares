Imports MaterialSkin.Controls

Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccountRename
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
            Me.MTxtOldAccountCode = New MaterialSkin.Controls.MaterialTextBox()
            Me.MTxtName = New MaterialSkin.Controls.MaterialTextBox()
            Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
            Me.MaterialLabel3 = New MaterialSkin.Controls.MaterialLabel()
            Me.MTxtNewAccountCode = New MaterialSkin.Controls.MaterialTextBox()
            Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
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
            Me.TableLayoutPanel1.ColumnCount = 5
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.MTxtOldAccountCode, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.MTxtName, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.MaterialLabel2, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.MaterialLabel3, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.MTxtNewAccountCode, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.MaterialLabel1, 1, 1)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 64)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 6
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(634, 368)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'MTxtOldAccountCode
            '
            Me.MTxtOldAccountCode.AnimateReadOnly = False
            Me.MTxtOldAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.MTxtOldAccountCode.Depth = 0
            Me.MTxtOldAccountCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.MTxtOldAccountCode.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MTxtOldAccountCode.LeadingIcon = Nothing
            Me.MTxtOldAccountCode.Location = New System.Drawing.Point(163, 93)
            Me.MTxtOldAccountCode.MaxLength = 50
            Me.MTxtOldAccountCode.MouseState = MaterialSkin.MouseState.OUT
            Me.MTxtOldAccountCode.Multiline = False
            Me.MTxtOldAccountCode.Name = "MTxtOldAccountCode"
            Me.MTxtOldAccountCode.ReadOnly = True
            Me.MTxtOldAccountCode.Size = New System.Drawing.Size(194, 50)
            Me.MTxtOldAccountCode.TabIndex = 1
            Me.MTxtOldAccountCode.TabStop = False
            Me.MTxtOldAccountCode.Text = ""
            Me.MTxtOldAccountCode.TrailingIcon = Nothing
            '
            'MTxtName
            '
            Me.MTxtName.AnimateReadOnly = False
            Me.MTxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.TableLayoutPanel1.SetColumnSpan(Me.MTxtName, 2)
            Me.MTxtName.Depth = 0
            Me.MTxtName.Dock = System.Windows.Forms.DockStyle.Top
            Me.MTxtName.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MTxtName.LeadingIcon = Nothing
            Me.MTxtName.Location = New System.Drawing.Point(163, 149)
            Me.MTxtName.MaxLength = 50
            Me.MTxtName.MouseState = MaterialSkin.MouseState.OUT
            Me.MTxtName.Multiline = False
            Me.MTxtName.Name = "MTxtName"
            Me.MTxtName.ReadOnly = True
            Me.MTxtName.Size = New System.Drawing.Size(448, 50)
            Me.MTxtName.TabIndex = 3
            Me.MTxtName.TabStop = False
            Me.MTxtName.Text = ""
            Me.MTxtName.TrailingIcon = Nothing
            '
            'MaterialLabel2
            '
            Me.MaterialLabel2.AutoSize = True
            Me.MaterialLabel2.Depth = 0
            Me.MaterialLabel2.Dock = System.Windows.Forms.DockStyle.Left
            Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel2.Location = New System.Drawing.Point(23, 146)
            Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel2.Name = "MaterialLabel2"
            Me.MaterialLabel2.Size = New System.Drawing.Size(43, 56)
            Me.MaterialLabel2.TabIndex = 2
            Me.MaterialLabel2.Text = "Name"
            Me.MaterialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MaterialLabel3
            '
            Me.MaterialLabel3.AutoSize = True
            Me.MaterialLabel3.Depth = 0
            Me.MaterialLabel3.Dock = System.Windows.Forms.DockStyle.Left
            Me.MaterialLabel3.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel3.Location = New System.Drawing.Point(23, 222)
            Me.MaterialLabel3.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel3.Name = "MaterialLabel3"
            Me.MaterialLabel3.Size = New System.Drawing.Size(134, 56)
            Me.MaterialLabel3.TabIndex = 4
            Me.MaterialLabel3.Text = "New Account Code"
            Me.MaterialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MTxtNewAccountCode
            '
            Me.MTxtNewAccountCode.AnimateReadOnly = False
            Me.MTxtNewAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.MTxtNewAccountCode.Depth = 0
            Me.MTxtNewAccountCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.MTxtNewAccountCode.Font = New System.Drawing.Font("Roboto", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MTxtNewAccountCode.LeadingIcon = Nothing
            Me.MTxtNewAccountCode.Location = New System.Drawing.Point(163, 225)
            Me.MTxtNewAccountCode.MaxLength = 50
            Me.MTxtNewAccountCode.MouseState = MaterialSkin.MouseState.OUT
            Me.MTxtNewAccountCode.Multiline = False
            Me.MTxtNewAccountCode.Name = "MTxtNewAccountCode"
            Me.MTxtNewAccountCode.Size = New System.Drawing.Size(194, 50)
            Me.MTxtNewAccountCode.TabIndex = 5
            Me.MTxtNewAccountCode.Text = ""
            Me.MTxtNewAccountCode.TrailingIcon = Nothing
            '
            'MaterialLabel1
            '
            Me.MaterialLabel1.AutoSize = True
            Me.MaterialLabel1.Depth = 0
            Me.MaterialLabel1.Dock = System.Windows.Forms.DockStyle.Left
            Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel1.Location = New System.Drawing.Point(23, 90)
            Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel1.Name = "MaterialLabel1"
            Me.MaterialLabel1.Size = New System.Drawing.Size(127, 56)
            Me.MaterialLabel1.TabIndex = 0
            Me.MaterialLabel1.Text = "Old Account Code"
            Me.MaterialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'FAccountRename
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(640, 480)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FAccountRename"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Rename Account"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents MTxtOldAccountCode As MaterialTextBox
        Friend WithEvents MTxtName As MaterialTextBox
        Friend WithEvents MaterialLabel1 As MaterialLabel
        Friend WithEvents MaterialLabel2 As MaterialLabel
        Friend WithEvents MaterialLabel3 As MaterialLabel
        Friend WithEvents MTxtNewAccountCode As MaterialTextBox
        Friend WithEvents MBtnCancel As MaterialButton
        Friend WithEvents MBtnOk As MaterialButton
    End Class

End Namespace
