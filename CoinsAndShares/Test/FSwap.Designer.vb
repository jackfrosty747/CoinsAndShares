Imports MaterialSkin.Controls

Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSwap
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
            Me.MlblAccountCode = New MaterialSkin.Controls.MaterialLabel()
            Me.MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
            Me.CmbInstrumentFrom = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.MBtnCancel = New MaterialSkin.Controls.MaterialButton()
            Me.MBtnOk = New MaterialSkin.Controls.MaterialButton()
            Me.MLblName = New MaterialSkin.Controls.MaterialLabel()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.CmbInstrumentFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'MlblAccountCode
            '
            Me.MlblAccountCode.AutoSize = True
            Me.MlblAccountCode.Depth = 0
            Me.MlblAccountCode.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MlblAccountCode.Location = New System.Drawing.Point(95, 82)
            Me.MlblAccountCode.MouseState = MaterialSkin.MouseState.HOVER
            Me.MlblAccountCode.Name = "MlblAccountCode"
            Me.MlblAccountCode.Size = New System.Drawing.Size(126, 19)
            Me.MlblAccountCode.TabIndex = 0
            Me.MlblAccountCode.Text = "MlblAccountCode"
            '
            'MaterialLabel2
            '
            Me.MaterialLabel2.AutoSize = True
            Me.MaterialLabel2.Depth = 0
            Me.MaterialLabel2.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel2.Location = New System.Drawing.Point(26, 82)
            Me.MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel2.Name = "MaterialLabel2"
            Me.MaterialLabel2.Size = New System.Drawing.Size(63, 19)
            Me.MaterialLabel2.TabIndex = 1
            Me.MaterialLabel2.Text = "Account:"
            '
            'CmbInstrumentFrom
            '
            Me.CmbInstrumentFrom.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrumentFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrumentFrom.DisplayMember = ""
            Me.CmbInstrumentFrom.Location = New System.Drawing.Point(98, 164)
            Me.CmbInstrumentFrom.Name = "CmbInstrumentFrom"
            Me.CmbInstrumentFrom.Size = New System.Drawing.Size(143, 22)
            Me.CmbInstrumentFrom.TabIndex = 8
            Me.CmbInstrumentFrom.ValueMember = ""
            '
            'MaterialLabel1
            '
            Me.MaterialLabel1.AutoSize = True
            Me.MaterialLabel1.Depth = 0
            Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel1.Location = New System.Drawing.Point(26, 167)
            Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel1.Name = "MaterialLabel1"
            Me.MaterialLabel1.Size = New System.Drawing.Size(41, 19)
            Me.MaterialLabel1.TabIndex = 9
            Me.MaterialLabel1.Text = "Swap"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.MBtnCancel)
            Me.Panel1.Controls.Add(Me.MBtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(3, 252)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(394, 45)
            Me.Panel1.TabIndex = 10
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
            Me.MBtnCancel.Location = New System.Drawing.Point(312, 5)
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
            'MLblName
            '
            Me.MLblName.AutoSize = True
            Me.MLblName.Depth = 0
            Me.MLblName.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MLblName.Location = New System.Drawing.Point(95, 101)
            Me.MLblName.MouseState = MaterialSkin.MouseState.HOVER
            Me.MLblName.Name = "MLblName"
            Me.MLblName.Size = New System.Drawing.Size(79, 19)
            Me.MLblName.TabIndex = 11
            Me.MLblName.Text = "MLblName"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.ForeColor = System.Drawing.Color.Red
            Me.Label1.Location = New System.Drawing.Point(183, 208)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(38, 13)
            Me.Label1.TabIndex = 12
            Me.Label1.Text = "TODO"
            '
            'FSwap
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(400, 300)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.MLblName)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.MaterialLabel1)
            Me.Controls.Add(Me.CmbInstrumentFrom)
            Me.Controls.Add(Me.MaterialLabel2)
            Me.Controls.Add(Me.MlblAccountCode)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FSwap"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Swap"
            CType(Me.CmbInstrumentFrom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents MlblAccountCode As MaterialLabel
        Friend WithEvents MaterialLabel2 As MaterialLabel
        Friend WithEvents CmbInstrumentFrom As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents MaterialLabel1 As MaterialLabel
        Friend WithEvents Panel1 As Panel
        Friend WithEvents MBtnCancel As MaterialButton
        Friend WithEvents MBtnOk As MaterialButton
        Friend WithEvents MLblName As MaterialLabel
        Friend WithEvents Label1 As Label
    End Class

End Namespace
