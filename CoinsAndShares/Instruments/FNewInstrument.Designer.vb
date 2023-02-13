Namespace Instruments
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FNewInstrument
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TxtInstrumentCode = New System.Windows.Forms.TextBox()
            Me.TxtDescription = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.CmbInstrumentTypeName = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TxtLinkCode = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.CmbCurrencyCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.BtnLinkCodeSearch = New System.Windows.Forms.Button()
            Me.Panel1.SuspendLayout()
            CType(Me.CmbInstrumentTypeName, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbCurrencyCode, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.Panel1.TabIndex = 8
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
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(59, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(34, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Code"
            '
            'TxtInstrumentCode
            '
            Me.TxtInstrumentCode.Location = New System.Drawing.Point(131, 53)
            Me.TxtInstrumentCode.Name = "TxtInstrumentCode"
            Me.TxtInstrumentCode.Size = New System.Drawing.Size(114, 22)
            Me.TxtInstrumentCode.TabIndex = 1
            '
            'TxtDescription
            '
            Me.TxtDescription.Location = New System.Drawing.Point(131, 81)
            Me.TxtDescription.Name = "TxtDescription"
            Me.TxtDescription.Size = New System.Drawing.Size(202, 22)
            Me.TxtDescription.TabIndex = 3
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(59, 84)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(66, 13)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Description"
            '
            'CmbInstrumentTypeName
            '
            Me.CmbInstrumentTypeName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrumentTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrumentTypeName.DisplayMember = ""
            Me.CmbInstrumentTypeName.Location = New System.Drawing.Point(131, 109)
            Me.CmbInstrumentTypeName.Name = "CmbInstrumentTypeName"
            Me.CmbInstrumentTypeName.Size = New System.Drawing.Size(114, 22)
            Me.CmbInstrumentTypeName.TabIndex = 5
            Me.CmbInstrumentTypeName.ValueMember = ""
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(59, 111)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(30, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Type"
            '
            'TxtLinkCode
            '
            Me.TxtLinkCode.Location = New System.Drawing.Point(131, 137)
            Me.TxtLinkCode.Name = "TxtLinkCode"
            Me.TxtLinkCode.Size = New System.Drawing.Size(114, 22)
            Me.TxtLinkCode.TabIndex = 7
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(59, 140)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(58, 13)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "Link Code"
            '
            'CmbCurrencyCode
            '
            Me.CmbCurrencyCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbCurrencyCode.DisplayMember = ""
            Me.CmbCurrencyCode.Location = New System.Drawing.Point(131, 165)
            Me.CmbCurrencyCode.Name = "CmbCurrencyCode"
            Me.CmbCurrencyCode.Size = New System.Drawing.Size(114, 22)
            Me.CmbCurrencyCode.TabIndex = 9
            Me.CmbCurrencyCode.ValueMember = ""
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(59, 169)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(52, 13)
            Me.Label5.TabIndex = 10
            Me.Label5.Text = "Currency"
            '
            'BtnLinkCodeSearch
            '
            Me.BtnLinkCodeSearch.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnLinkCodeSearch.Image = Global.CoinsAndShares.My.Resources.Resources.chain
            Me.BtnLinkCodeSearch.Location = New System.Drawing.Point(251, 137)
            Me.BtnLinkCodeSearch.Name = "BtnLinkCodeSearch"
            Me.BtnLinkCodeSearch.Size = New System.Drawing.Size(31, 22)
            Me.BtnLinkCodeSearch.TabIndex = 11
            Me.BtnLinkCodeSearch.TabStop = False
            Me.BtnLinkCodeSearch.UseVisualStyleBackColor = False
            '
            'FNewInstrument
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(384, 261)
            Me.Controls.Add(Me.BtnLinkCodeSearch)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.CmbCurrencyCode)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.TxtLinkCode)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.CmbInstrumentTypeName)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.TxtDescription)
            Me.Controls.Add(Me.TxtInstrumentCode)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FNewInstrument"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "New Instrument"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.CmbInstrumentTypeName, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbCurrencyCode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents TxtInstrumentCode As TextBox
        Friend WithEvents TxtDescription As TextBox
        Friend WithEvents Label2 As Label
        Friend WithEvents CmbInstrumentTypeName As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label3 As Label
        Friend WithEvents TxtLinkCode As TextBox
        Friend WithEvents Label4 As Label
        Friend WithEvents CmbCurrencyCode As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label5 As Label
        Friend WithEvents BtnLinkCodeSearch As Button
    End Class

End Namespace
