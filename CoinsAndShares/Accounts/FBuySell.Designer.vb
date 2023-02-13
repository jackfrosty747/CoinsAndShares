Namespace Accounts

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FBuySell
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
            Me.components = New System.ComponentModel.Container()
            Me.GbBuySell = New System.Windows.Forms.GroupBox()
            Me.OptSell = New System.Windows.Forms.RadioButton()
            Me.OptBuy = New System.Windows.Forms.RadioButton()
            Me.TxtQuantity = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.TxtRate = New System.Windows.Forms.TextBox()
            Me.TxtValue = New System.Windows.Forms.TextBox()
            Me.LblValueCaption = New System.Windows.Forms.Label()
            Me.CmbInstrument = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.DtpBuySellDate = New System.Windows.Forms.DateTimePicker()
            Me.ChkPinQuantity = New System.Windows.Forms.CheckBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.ChkPinRate = New System.Windows.Forms.CheckBox()
            Me.ChkPinValue = New System.Windows.Forms.CheckBox()
            Me.BtnCreateNewInstrument = New System.Windows.Forms.Button()
            Me.LblCurrency = New System.Windows.Forms.Label()
            Me.BtnAll = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.GrowLabel1 = New CoinsAndShares.GrowLabel()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.GbBuySell.SuspendLayout()
            CType(Me.CmbInstrument, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'GbBuySell
            '
            Me.GbBuySell.Controls.Add(Me.OptSell)
            Me.GbBuySell.Controls.Add(Me.OptBuy)
            Me.GbBuySell.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GbBuySell.Location = New System.Drawing.Point(64, 131)
            Me.GbBuySell.Name = "GbBuySell"
            Me.GbBuySell.Padding = New System.Windows.Forms.Padding(8, 3, 3, 3)
            Me.GbBuySell.Size = New System.Drawing.Size(168, 141)
            Me.GbBuySell.TabIndex = 0
            Me.GbBuySell.TabStop = False
            Me.GbBuySell.Text = "GbBuySell"
            '
            'OptSell
            '
            Me.OptSell.AutoSize = True
            Me.OptSell.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptSell.Location = New System.Drawing.Point(8, 35)
            Me.OptSell.Name = "OptSell"
            Me.OptSell.Size = New System.Drawing.Size(157, 17)
            Me.OptSell.TabIndex = 1
            Me.OptSell.TabStop = True
            Me.OptSell.Text = "OptSell"
            Me.OptSell.UseVisualStyleBackColor = True
            '
            'OptBuy
            '
            Me.OptBuy.AutoSize = True
            Me.OptBuy.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptBuy.Location = New System.Drawing.Point(8, 18)
            Me.OptBuy.Name = "OptBuy"
            Me.OptBuy.Size = New System.Drawing.Size(157, 17)
            Me.OptBuy.TabIndex = 0
            Me.OptBuy.TabStop = True
            Me.OptBuy.Text = "OptBuy"
            Me.OptBuy.UseVisualStyleBackColor = True
            '
            'TxtQuantity
            '
            Me.TxtQuantity.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtQuantity.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TxtQuantity.Location = New System.Drawing.Point(147, 59)
            Me.TxtQuantity.Name = "TxtQuantity"
            Me.TxtQuantity.Size = New System.Drawing.Size(144, 22)
            Me.TxtQuantity.TabIndex = 5
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(3, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(52, 16)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Quantity"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(3, 85)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(30, 16)
            Me.Label2.TabIndex = 6
            Me.Label2.Text = "Rate"
            '
            'TxtRate
            '
            Me.TxtRate.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtRate.Location = New System.Drawing.Point(147, 88)
            Me.TxtRate.Name = "TxtRate"
            Me.TxtRate.Size = New System.Drawing.Size(144, 22)
            Me.TxtRate.TabIndex = 7
            '
            'TxtValue
            '
            Me.TxtValue.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtValue.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TxtValue.Location = New System.Drawing.Point(147, 116)
            Me.TxtValue.Name = "TxtValue"
            Me.TxtValue.Size = New System.Drawing.Size(144, 22)
            Me.TxtValue.TabIndex = 11
            '
            'LblValueCaption
            '
            Me.LblValueCaption.AutoSize = True
            Me.LblValueCaption.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblValueCaption.Location = New System.Drawing.Point(3, 113)
            Me.LblValueCaption.Name = "LblValueCaption"
            Me.LblValueCaption.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblValueCaption.Size = New System.Drawing.Size(35, 16)
            Me.LblValueCaption.TabIndex = 10
            Me.LblValueCaption.Text = "Value"
            '
            'CmbInstrument
            '
            Me.CmbInstrument.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrument.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrument.DisplayMember = ""
            Me.CmbInstrument.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbInstrument.Location = New System.Drawing.Point(147, 31)
            Me.CmbInstrument.Name = "CmbInstrument"
            Me.CmbInstrument.Size = New System.Drawing.Size(144, 22)
            Me.CmbInstrument.TabIndex = 3
            Me.CmbInstrument.ValueMember = ""
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 28)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(63, 16)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Instrument"
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 4
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.DtpBuySellDate, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.ChkPinQuantity, 3, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.LblValueCaption, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbInstrument, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtQuantity, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtRate, 2, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtValue, 2, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.ChkPinRate, 3, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.ChkPinValue, 3, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.BtnCreateNewInstrument, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.LblCurrency, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.BtnAll, 1, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(238, 131)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 5
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(322, 141)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'DtpBuySellDate
            '
            Me.DtpBuySellDate.Dock = System.Windows.Forms.DockStyle.Top
            Me.DtpBuySellDate.Location = New System.Drawing.Point(147, 3)
            Me.DtpBuySellDate.Name = "DtpBuySellDate"
            Me.DtpBuySellDate.Size = New System.Drawing.Size(144, 22)
            Me.DtpBuySellDate.TabIndex = 1
            '
            'ChkPinQuantity
            '
            Me.ChkPinQuantity.Appearance = System.Windows.Forms.Appearance.Button
            Me.ChkPinQuantity.AutoSize = True
            Me.ChkPinQuantity.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.ChkPinQuantity.Image = Global.CoinsAndShares.My.Resources.Resources.pin
            Me.ChkPinQuantity.Location = New System.Drawing.Point(297, 59)
            Me.ChkPinQuantity.Name = "ChkPinQuantity"
            Me.ChkPinQuantity.Size = New System.Drawing.Size(22, 22)
            Me.ChkPinQuantity.TabIndex = 12
            Me.ChkPinQuantity.TabStop = False
            Me.ChkPinQuantity.UseVisualStyleBackColor = False
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(3, 0)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(65, 16)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Date / Time"
            '
            'ChkPinRate
            '
            Me.ChkPinRate.Appearance = System.Windows.Forms.Appearance.Button
            Me.ChkPinRate.AutoSize = True
            Me.ChkPinRate.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.ChkPinRate.Image = Global.CoinsAndShares.My.Resources.Resources.pin
            Me.ChkPinRate.Location = New System.Drawing.Point(297, 88)
            Me.ChkPinRate.Name = "ChkPinRate"
            Me.ChkPinRate.Size = New System.Drawing.Size(22, 22)
            Me.ChkPinRate.TabIndex = 13
            Me.ChkPinRate.TabStop = False
            Me.ChkPinRate.UseVisualStyleBackColor = False
            '
            'ChkPinValue
            '
            Me.ChkPinValue.Appearance = System.Windows.Forms.Appearance.Button
            Me.ChkPinValue.AutoSize = True
            Me.ChkPinValue.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.ChkPinValue.Image = Global.CoinsAndShares.My.Resources.Resources.pin
            Me.ChkPinValue.Location = New System.Drawing.Point(297, 116)
            Me.ChkPinValue.Name = "ChkPinValue"
            Me.ChkPinValue.Size = New System.Drawing.Size(22, 22)
            Me.ChkPinValue.TabIndex = 15
            Me.ChkPinValue.TabStop = False
            Me.ChkPinValue.UseVisualStyleBackColor = False
            '
            'BtnCreateNewInstrument
            '
            Me.BtnCreateNewInstrument.AutoSize = True
            Me.BtnCreateNewInstrument.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCreateNewInstrument.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCreateNewInstrument.Image = Global.CoinsAndShares.My.Resources.Resources._new
            Me.BtnCreateNewInstrument.Location = New System.Drawing.Point(297, 31)
            Me.BtnCreateNewInstrument.Name = "BtnCreateNewInstrument"
            Me.BtnCreateNewInstrument.Size = New System.Drawing.Size(22, 22)
            Me.BtnCreateNewInstrument.TabIndex = 16
            Me.ToolTip1.SetToolTip(Me.BtnCreateNewInstrument, "Create new instrument")
            Me.BtnCreateNewInstrument.UseVisualStyleBackColor = False
            '
            'LblCurrency
            '
            Me.LblCurrency.AutoSize = True
            Me.LblCurrency.Location = New System.Drawing.Point(74, 85)
            Me.LblCurrency.Name = "LblCurrency"
            Me.LblCurrency.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblCurrency.Size = New System.Drawing.Size(67, 16)
            Me.LblCurrency.TabIndex = 17
            Me.LblCurrency.Text = "LblCurrency"
            '
            'BtnAll
            '
            Me.BtnAll.AutoSize = True
            Me.BtnAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnAll.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnAll.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnAll.Location = New System.Drawing.Point(111, 59)
            Me.BtnAll.Name = "BtnAll"
            Me.BtnAll.Size = New System.Drawing.Size(30, 23)
            Me.BtnAll.TabIndex = 18
            Me.BtnAll.Text = "All"
            Me.BtnAll.UseVisualStyleBackColor = False
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
            Me.Panel1.TabIndex = 1
            '
            'BtnCancel
            '
            Me.BtnCancel.AutoSize = True
            Me.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancel.Image = Global.CoinsAndShares.My.Resources.Resources.cross_circle_frame
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
            Me.BtnOk.Image = Global.CoinsAndShares.My.Resources.Resources.tick_circle_frame
            Me.BtnOk.Location = New System.Drawing.Point(5, 5)
            Me.BtnOk.Name = "BtnOk"
            Me.BtnOk.Size = New System.Drawing.Size(48, 28)
            Me.BtnOk.TabIndex = 0
            Me.BtnOk.Text = "O&K"
            Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOk.UseVisualStyleBackColor = False
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 4
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.GbBuySell, 1, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 2, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.GrowLabel1, 2, 2)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 3
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(624, 403)
            Me.TableLayoutPanel2.TabIndex = 0
            '
            'GrowLabel1
            '
            Me.GrowLabel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GrowLabel1.ForeColor = System.Drawing.Color.Blue
            Me.GrowLabel1.Location = New System.Drawing.Point(238, 275)
            Me.GrowLabel1.Name = "GrowLabel1"
            Me.GrowLabel1.Size = New System.Drawing.Size(322, 16)
            Me.GrowLabel1.TabIndex = 1
            Me.GrowLabel1.Text = "ENSURE THE QUANTITY AND VALUE ARE CORRECT"
            '
            'FBuySell
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.TableLayoutPanel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FBuySell"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Buy / Sell"
            Me.GbBuySell.ResumeLayout(False)
            Me.GbBuySell.PerformLayout()
            CType(Me.CmbInstrument, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GbBuySell As GroupBox
        Friend WithEvents OptSell As RadioButton
        Friend WithEvents OptBuy As RadioButton
        Friend WithEvents TxtQuantity As TextBox
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents TxtRate As TextBox
        Friend WithEvents TxtValue As TextBox
        Friend WithEvents LblValueCaption As Label
        Friend WithEvents CmbInstrument As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label3 As Label
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents Label4 As Label
        Friend WithEvents ChkPinQuantity As CheckBox
        Friend WithEvents ChkPinRate As CheckBox
        Friend WithEvents ChkPinValue As CheckBox
        Friend WithEvents DtpBuySellDate As DateTimePicker
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents BtnCreateNewInstrument As Button
        Friend WithEvents ToolTip1 As ToolTip
        Friend WithEvents LblCurrency As Label
        Friend WithEvents GrowLabel1 As GrowLabel
        Friend WithEvents BtnAll As Button
    End Class
End Namespace
