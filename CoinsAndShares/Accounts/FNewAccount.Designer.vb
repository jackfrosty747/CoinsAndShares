Namespace Accounts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FNewAccount
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.CmbAccountTypeName = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TxtAccountCode = New System.Windows.Forms.TextBox()
            Me.TxtName = New System.Windows.Forms.TextBox()
            Me.Panel1.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.CmbAccountTypeName, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnCancel)
            Me.Panel1.Controls.Add(Me.BtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 223)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(384, 38)
            Me.Panel1.TabIndex = 1
            '
            'BtnCancel
            '
            Me.BtnCancel.AutoSize = True
            Me.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancel.Image = Global.CoinsAndShares.My.Resources.Resources.cross_circle_frame
            Me.BtnCancel.Location = New System.Drawing.Point(312, 5)
            Me.BtnCancel.Name = "BtnCancel"
            Me.BtnCancel.Size = New System.Drawing.Size(67, 28)
            Me.BtnCancel.TabIndex = 1
            Me.BtnCancel.Text = "&Cancel"
            Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnCancel.UseVisualStyleBackColor = False
            '
            'BtnOk
            '
            Me.BtnOk.AutoSize = True
            Me.BtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnOk.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnOk.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnOk.Image = Global.CoinsAndShares.My.Resources.Resources.tick_circle_frame
            Me.BtnOk.Location = New System.Drawing.Point(5, 5)
            Me.BtnOk.Name = "BtnOk"
            Me.BtnOk.Size = New System.Drawing.Size(48, 28)
            Me.BtnOk.TabIndex = 0
            Me.BtnOk.Text = "O&K"
            Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOk.UseVisualStyleBackColor = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 5
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.CmbAccountTypeName, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtAccountCode, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtName, 2, 2)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(384, 223)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'CmbAccountTypeName
            '
            Me.CmbAccountTypeName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountTypeName.DisplayMember = ""
            Me.CmbAccountTypeName.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbAccountTypeName.Location = New System.Drawing.Point(96, 128)
            Me.CmbAccountTypeName.Name = "CmbAccountTypeName"
            Me.CmbAccountTypeName.Size = New System.Drawing.Size(114, 22)
            Me.CmbAccountTypeName.TabIndex = 5
            Me.CmbAccountTypeName.ValueMember = ""
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(54, 69)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(34, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Code"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(54, 97)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(36, 16)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Name"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(54, 125)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(30, 16)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Type"
            '
            'TxtAccountCode
            '
            Me.TxtAccountCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.TxtAccountCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAccountCode.Location = New System.Drawing.Point(96, 72)
            Me.TxtAccountCode.Name = "TxtAccountCode"
            Me.TxtAccountCode.Size = New System.Drawing.Size(114, 22)
            Me.TxtAccountCode.TabIndex = 1
            '
            'TxtName
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtName, 2)
            Me.TxtName.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtName.Location = New System.Drawing.Point(96, 100)
            Me.TxtName.Name = "TxtName"
            Me.TxtName.Size = New System.Drawing.Size(234, 22)
            Me.TxtName.TabIndex = 3
            '
            'FNewAccount
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(384, 261)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FNewAccount"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "New Account"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.CmbAccountTypeName, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents TxtAccountCode As TextBox
        Friend WithEvents TxtName As TextBox
        Friend WithEvents CmbAccountTypeName As Infragistics.Win.UltraWinGrid.UltraCombo
    End Class

End Namespace
