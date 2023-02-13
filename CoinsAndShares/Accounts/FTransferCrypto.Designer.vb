Namespace Accounts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FTransferCrypto
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FTransferCrypto))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.CmbAccountFrom = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.CmbAccountTo = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.CmbInstrumentToTransfer = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TxtTransferQuantity = New System.Windows.Forms.TextBox()
            Me.LblSendTotalFiatValue = New System.Windows.Forms.Label()
            Me.TxtDate = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.BtnMax = New System.Windows.Forms.Button()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.LblInstrumentDescription = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.CmbAccountFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbAccountTo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbInstrumentToTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnCancel)
            Me.Panel1.Controls.Add(Me.BtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 403)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(624, 38)
            Me.Panel1.TabIndex = 2
            '
            'BtnCancel
            '
            Me.BtnCancel.AutoSize = True
            Me.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
            Me.BtnCancel.Location = New System.Drawing.Point(552, 5)
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
            Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
            Me.BtnOk.Location = New System.Drawing.Point(5, 5)
            Me.BtnOk.Name = "BtnOk"
            Me.BtnOk.Size = New System.Drawing.Size(48, 28)
            Me.BtnOk.TabIndex = 0
            Me.BtnOk.Text = "O&K"
            Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOk.UseVisualStyleBackColor = False
            '
            'CmbAccountFrom
            '
            Me.CmbAccountFrom.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountFrom.DisplayMember = ""
            Me.CmbAccountFrom.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbAccountFrom.Location = New System.Drawing.Point(220, 132)
            Me.CmbAccountFrom.Name = "CmbAccountFrom"
            Me.CmbAccountFrom.Size = New System.Drawing.Size(114, 22)
            Me.CmbAccountFrom.TabIndex = 3
            Me.CmbAccountFrom.ValueMember = ""
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(114, 129)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(78, 16)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "From Account"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(114, 274)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(64, 16)
            Me.Label2.TabIndex = 11
            Me.Label2.Text = "To Account"
            '
            'CmbAccountTo
            '
            Me.CmbAccountTo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountTo.DisplayMember = ""
            Me.CmbAccountTo.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbAccountTo.Location = New System.Drawing.Point(220, 277)
            Me.CmbAccountTo.Name = "CmbAccountTo"
            Me.CmbAccountTo.Size = New System.Drawing.Size(114, 22)
            Me.CmbAccountTo.TabIndex = 12
            Me.CmbAccountTo.ValueMember = ""
            '
            'CmbInstrumentToTransfer
            '
            Me.CmbInstrumentToTransfer.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrumentToTransfer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrumentToTransfer.DisplayMember = ""
            Me.CmbInstrumentToTransfer.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbInstrumentToTransfer.Location = New System.Drawing.Point(220, 190)
            Me.CmbInstrumentToTransfer.Name = "CmbInstrumentToTransfer"
            Me.CmbInstrumentToTransfer.Size = New System.Drawing.Size(114, 22)
            Me.CmbInstrumentToTransfer.TabIndex = 5
            Me.CmbInstrumentToTransfer.ValueMember = ""
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(114, 187)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(100, 16)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Crypto To Transfer"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(114, 215)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(24, 16)
            Me.Label4.TabIndex = 7
            Me.Label4.Text = "Qty"
            '
            'TxtTransferQuantity
            '
            Me.TxtTransferQuantity.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtTransferQuantity.Location = New System.Drawing.Point(220, 218)
            Me.TxtTransferQuantity.Name = "TxtTransferQuantity"
            Me.TxtTransferQuantity.Size = New System.Drawing.Size(114, 22)
            Me.TxtTransferQuantity.TabIndex = 8
            '
            'LblSendTotalFiatValue
            '
            Me.LblSendTotalFiatValue.AutoSize = True
            Me.LblSendTotalFiatValue.Location = New System.Drawing.Point(390, 215)
            Me.LblSendTotalFiatValue.Name = "LblSendTotalFiatValue"
            Me.LblSendTotalFiatValue.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblSendTotalFiatValue.Size = New System.Drawing.Size(120, 16)
            Me.LblSendTotalFiatValue.TabIndex = 10
            Me.LblSendTotalFiatValue.Text = "LblSendTotalFiatValue"
            '
            'TxtDate
            '
            Me.TxtDate.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtDate.Location = New System.Drawing.Point(220, 104)
            Me.TxtDate.Name = "TxtDate"
            Me.TxtDate.Size = New System.Drawing.Size(114, 22)
            Me.TxtDate.TabIndex = 1
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(114, 101)
            Me.Label7.Name = "Label7"
            Me.Label7.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label7.Size = New System.Drawing.Size(31, 16)
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "Date"
            '
            'BtnMax
            '
            Me.BtnMax.AutoSize = True
            Me.BtnMax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnMax.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnMax.Location = New System.Drawing.Point(340, 218)
            Me.BtnMax.Name = "BtnMax"
            Me.BtnMax.Size = New System.Drawing.Size(38, 23)
            Me.BtnMax.TabIndex = 9
            Me.BtnMax.Text = "Max"
            Me.BtnMax.UseVisualStyleBackColor = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.LblInstrumentDescription, 3, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.Label7, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtDate, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbAccountTo, 2, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbAccountFrom, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.BtnMax, 3, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtTransferQuantity, 2, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbInstrumentToTransfer, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.LblSendTotalFiatValue, 4, 5)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 9
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 403)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'LblInstrumentDescription
            '
            Me.LblInstrumentDescription.AutoSize = True
            Me.TableLayoutPanel1.SetColumnSpan(Me.LblInstrumentDescription, 2)
            Me.LblInstrumentDescription.Location = New System.Drawing.Point(340, 187)
            Me.LblInstrumentDescription.Name = "LblInstrumentDescription"
            Me.LblInstrumentDescription.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblInstrumentDescription.Size = New System.Drawing.Size(137, 16)
            Me.LblInstrumentDescription.TabIndex = 6
            Me.LblInstrumentDescription.Text = "LblInstrumentDescription"
            '
            'FTransferCrypto
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FTransferCrypto"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Transfer Crypto"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.CmbAccountFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbAccountTo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbInstrumentToTransfer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents CmbAccountFrom As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents CmbAccountTo As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents CmbInstrumentToTransfer As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label3 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents TxtTransferQuantity As TextBox
        Friend WithEvents LblSendTotalFiatValue As Label
        Friend WithEvents TxtDate As TextBox
        Friend WithEvents Label7 As Label
        Friend WithEvents BtnMax As Button
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents LblInstrumentDescription As Label
    End Class

End Namespace
