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
            CType(Me.CmbNetworkId, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 33)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(92, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "ACCOUNT CODE"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(12, 61)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(38, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "NAME"
            '
            'TxtAccountCode
            '
            Me.TxtAccountCode.Location = New System.Drawing.Point(110, 30)
            Me.TxtAccountCode.Name = "TxtAccountCode"
            Me.TxtAccountCode.ReadOnly = True
            Me.TxtAccountCode.Size = New System.Drawing.Size(106, 22)
            Me.TxtAccountCode.TabIndex = 2
            Me.TxtAccountCode.Text = "TxtAccountCode"
            '
            'TxtAccountName
            '
            Me.TxtAccountName.Location = New System.Drawing.Point(110, 58)
            Me.TxtAccountName.Name = "TxtAccountName"
            Me.TxtAccountName.Size = New System.Drawing.Size(236, 22)
            Me.TxtAccountName.TabIndex = 3
            Me.TxtAccountName.Text = "TxtAccountName"
            '
            'TxtAccountType
            '
            Me.TxtAccountType.Location = New System.Drawing.Point(246, 30)
            Me.TxtAccountType.Name = "TxtAccountType"
            Me.TxtAccountType.ReadOnly = True
            Me.TxtAccountType.Size = New System.Drawing.Size(100, 22)
            Me.TxtAccountType.TabIndex = 4
            Me.TxtAccountType.Text = "TxtAccountType"
            '
            'CmbNetworkId
            '
            Me.CmbNetworkId.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbNetworkId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbNetworkId.DisplayMember = ""
            Me.CmbNetworkId.Location = New System.Drawing.Point(110, 86)
            Me.CmbNetworkId.Name = "CmbNetworkId"
            Me.CmbNetworkId.Size = New System.Drawing.Size(106, 22)
            Me.CmbNetworkId.TabIndex = 10
            Me.CmbNetworkId.ValueMember = ""
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(12, 95)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(60, 13)
            Me.Label3.TabIndex = 11
            Me.Label3.Text = "NETWORK"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(12, 143)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(42, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "NOTES"
            '
            'TxtNotes
            '
            Me.TxtNotes.Location = New System.Drawing.Point(96, 135)
            Me.TxtNotes.Multiline = True
            Me.TxtNotes.Name = "TxtNotes"
            Me.TxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TxtNotes.Size = New System.Drawing.Size(304, 174)
            Me.TxtNotes.TabIndex = 13
            Me.TxtNotes.Text = "TxtNotes"
            '
            'ChkIncludeOnShortcuts
            '
            Me.ChkIncludeOnShortcuts.AutoSize = True
            Me.ChkIncludeOnShortcuts.Location = New System.Drawing.Point(103, 333)
            Me.ChkIncludeOnShortcuts.Name = "ChkIncludeOnShortcuts"
            Me.ChkIncludeOnShortcuts.Size = New System.Drawing.Size(166, 17)
            Me.ChkIncludeOnShortcuts.TabIndex = 14
            Me.ChkIncludeOnShortcuts.Text = "Include On Shortcuts Panel"
            Me.ChkIncludeOnShortcuts.UseVisualStyleBackColor = True
            '
            'BtnSave
            '
            Me.BtnSave.AutoSize = True
            Me.BtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSave.Image = Global.CoinsAndShares.My.Resources.Resources.disk
            Me.BtnSave.Location = New System.Drawing.Point(340, 328)
            Me.BtnSave.Name = "BtnSave"
            Me.BtnSave.Size = New System.Drawing.Size(58, 23)
            Me.BtnSave.TabIndex = 15
            Me.BtnSave.Text = "SAVE"
            Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSave.UseVisualStyleBackColor = False
            '
            'FAccount
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.BtnSave)
            Me.Controls.Add(Me.ChkIncludeOnShortcuts)
            Me.Controls.Add(Me.TxtNotes)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.CmbNetworkId)
            Me.Controls.Add(Me.TxtAccountType)
            Me.Controls.Add(Me.TxtAccountName)
            Me.Controls.Add(Me.TxtAccountCode)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.WindowText
            Me.Name = "FAccount"
            Me.Text = "FAccount"
            CType(Me.CmbNetworkId, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
    End Class

End Namespace
