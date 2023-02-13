Namespace Accounts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAdjust
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FAdjust))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.LblWarning = New System.Windows.Forms.Label()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.OptAdjustTypeInstrument = New System.Windows.Forms.RadioButton()
            Me.OptAdjustTypeMoney = New System.Windows.Forms.RadioButton()
            Me.TxtRate = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TxtValue = New System.Windows.Forms.TextBox()
            Me.LblAmountCaption = New System.Windows.Forms.Label()
            Me.LblInstrumentName = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.CmbInstrumentCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.TxtDescription = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.TlpInstrument = New System.Windows.Forms.TableLayoutPanel()
            Me.ChkPinQuantity = New System.Windows.Forms.CheckBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TxtQuantity = New System.Windows.Forms.TextBox()
            Me.ChkPinRate = New System.Windows.Forms.CheckBox()
            Me.DtpDateTime = New System.Windows.Forms.DateTimePicker()
            Me.ChkPinValue = New System.Windows.Forms.CheckBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.OptReasonMining = New System.Windows.Forms.RadioButton()
            Me.OptReasonAdjustment = New System.Windows.Forms.RadioButton()
            Me.OptReasonFee = New System.Windows.Forms.RadioButton()
            Me.OptReasonBonus = New System.Windows.Forms.RadioButton()
            Me.PnlDescriptions = New System.Windows.Forms.Panel()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.CmbInstrumentCode, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TlpInstrument.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.LblWarning)
            Me.Panel1.Controls.Add(Me.BtnCancel)
            Me.Panel1.Controls.Add(Me.BtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 403)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(624, 38)
            Me.Panel1.TabIndex = 1
            '
            'LblWarning
            '
            Me.LblWarning.AutoSize = True
            Me.LblWarning.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblWarning.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblWarning.ForeColor = System.Drawing.Color.Red
            Me.LblWarning.Location = New System.Drawing.Point(53, 5)
            Me.LblWarning.Name = "LblWarning"
            Me.LblWarning.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
            Me.LblWarning.Size = New System.Drawing.Size(68, 21)
            Me.LblWarning.TabIndex = 2
            Me.LblWarning.Text = "LblWarning"
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
            'GroupBox1
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 4)
            Me.GroupBox1.Controls.Add(Me.OptAdjustTypeInstrument)
            Me.GroupBox1.Controls.Add(Me.OptAdjustTypeMoney)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox1.Location = New System.Drawing.Point(93, 151)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Padding = New System.Windows.Forms.Padding(8, 3, 3, 3)
            Me.GroupBox1.Size = New System.Drawing.Size(437, 68)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Type"
            '
            'OptAdjustTypeInstrument
            '
            Me.OptAdjustTypeInstrument.AutoSize = True
            Me.OptAdjustTypeInstrument.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptAdjustTypeInstrument.Location = New System.Drawing.Point(8, 35)
            Me.OptAdjustTypeInstrument.Name = "OptAdjustTypeInstrument"
            Me.OptAdjustTypeInstrument.Size = New System.Drawing.Size(426, 17)
            Me.OptAdjustTypeInstrument.TabIndex = 1
            Me.OptAdjustTypeInstrument.TabStop = True
            Me.OptAdjustTypeInstrument.Text = "OptBonusTypeInstrument"
            Me.OptAdjustTypeInstrument.UseVisualStyleBackColor = True
            '
            'OptAdjustTypeMoney
            '
            Me.OptAdjustTypeMoney.AutoSize = True
            Me.OptAdjustTypeMoney.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptAdjustTypeMoney.Location = New System.Drawing.Point(8, 18)
            Me.OptAdjustTypeMoney.Name = "OptAdjustTypeMoney"
            Me.OptAdjustTypeMoney.Size = New System.Drawing.Size(426, 17)
            Me.OptAdjustTypeMoney.TabIndex = 0
            Me.OptAdjustTypeMoney.TabStop = True
            Me.OptAdjustTypeMoney.Text = "LocalCurrencyName"
            Me.OptAdjustTypeMoney.UseVisualStyleBackColor = True
            '
            'TxtRate
            '
            Me.TxtRate.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtRate.Location = New System.Drawing.Point(72, 59)
            Me.TxtRate.Name = "TxtRate"
            Me.TxtRate.Size = New System.Drawing.Size(144, 22)
            Me.TxtRate.TabIndex = 7
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(30, 16)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Rate"
            '
            'TxtValue
            '
            Me.TxtValue.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtValue.Location = New System.Drawing.Point(165, 315)
            Me.TxtValue.Name = "TxtValue"
            Me.TxtValue.Size = New System.Drawing.Size(144, 22)
            Me.TxtValue.TabIndex = 5
            '
            'LblAmountCaption
            '
            Me.LblAmountCaption.AutoSize = True
            Me.LblAmountCaption.Location = New System.Drawing.Point(93, 312)
            Me.LblAmountCaption.Name = "LblAmountCaption"
            Me.LblAmountCaption.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblAmountCaption.Size = New System.Drawing.Size(35, 16)
            Me.LblAmountCaption.TabIndex = 4
            Me.LblAmountCaption.Text = "Value"
            '
            'LblInstrumentName
            '
            Me.LblInstrumentName.AutoSize = True
            Me.TlpInstrument.SetColumnSpan(Me.LblInstrumentName, 2)
            Me.LblInstrumentName.Location = New System.Drawing.Point(222, 0)
            Me.LblInstrumentName.Name = "LblInstrumentName"
            Me.LblInstrumentName.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblInstrumentName.Size = New System.Drawing.Size(107, 16)
            Me.LblInstrumentName.TabIndex = 2
            Me.LblInstrumentName.Text = "LblInstrumentName"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(3, 0)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(63, 16)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "Instrument"
            '
            'CmbInstrumentCode
            '
            Me.CmbInstrumentCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrumentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrumentCode.DisplayMember = ""
            Me.CmbInstrumentCode.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbInstrumentCode.Location = New System.Drawing.Point(72, 3)
            Me.CmbInstrumentCode.Name = "CmbInstrumentCode"
            Me.CmbInstrumentCode.Size = New System.Drawing.Size(144, 22)
            Me.CmbInstrumentCode.TabIndex = 1
            Me.CmbInstrumentCode.ValueMember = ""
            '
            'TxtDescription
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.TxtDescription, 3)
            Me.TxtDescription.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtDescription.Location = New System.Drawing.Point(165, 369)
            Me.TxtDescription.Name = "TxtDescription"
            Me.TxtDescription.Size = New System.Drawing.Size(365, 22)
            Me.TxtDescription.TabIndex = 8
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(93, 366)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(66, 16)
            Me.Label4.TabIndex = 7
            Me.Label4.Text = "Description"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(93, 120)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label5.Size = New System.Drawing.Size(65, 16)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Date / Time"
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.TlpInstrument, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 1, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtDescription, 2, 7)
            Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.LblAmountCaption, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtValue, 2, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.DtpDateTime, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.ChkPinValue, 3, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.PnlDescriptions, 1, 6)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 9
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 403)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'TlpInstrument
            '
            Me.TlpInstrument.AutoSize = True
            Me.TlpInstrument.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TlpInstrument.ColumnCount = 4
            Me.TableLayoutPanel1.SetColumnSpan(Me.TlpInstrument, 4)
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpInstrument.Controls.Add(Me.ChkPinQuantity, 2, 1)
            Me.TlpInstrument.Controls.Add(Me.TxtRate, 1, 2)
            Me.TlpInstrument.Controls.Add(Me.Label1, 0, 2)
            Me.TlpInstrument.Controls.Add(Me.Label3, 0, 0)
            Me.TlpInstrument.Controls.Add(Me.CmbInstrumentCode, 1, 0)
            Me.TlpInstrument.Controls.Add(Me.Label6, 0, 1)
            Me.TlpInstrument.Controls.Add(Me.TxtQuantity, 1, 1)
            Me.TlpInstrument.Controls.Add(Me.LblInstrumentName, 2, 0)
            Me.TlpInstrument.Controls.Add(Me.ChkPinRate, 2, 2)
            Me.TlpInstrument.Location = New System.Drawing.Point(93, 225)
            Me.TlpInstrument.Name = "TlpInstrument"
            Me.TlpInstrument.RowCount = 3
            Me.TlpInstrument.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpInstrument.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpInstrument.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpInstrument.Size = New System.Drawing.Size(332, 84)
            Me.TlpInstrument.TabIndex = 3
            '
            'ChkPinQuantity
            '
            Me.ChkPinQuantity.Appearance = System.Windows.Forms.Appearance.Button
            Me.ChkPinQuantity.AutoSize = True
            Me.ChkPinQuantity.Image = Global.CoinsAndShares.My.Resources.Resources.pin
            Me.ChkPinQuantity.Location = New System.Drawing.Point(222, 31)
            Me.ChkPinQuantity.Name = "ChkPinQuantity"
            Me.ChkPinQuantity.Size = New System.Drawing.Size(22, 22)
            Me.ChkPinQuantity.TabIndex = 5
            Me.ChkPinQuantity.TabStop = False
            Me.ChkPinQuantity.UseVisualStyleBackColor = True
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(3, 28)
            Me.Label6.Name = "Label6"
            Me.Label6.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label6.Size = New System.Drawing.Size(51, 16)
            Me.Label6.TabIndex = 3
            Me.Label6.Text = "Quantity"
            '
            'TxtQuantity
            '
            Me.TxtQuantity.Location = New System.Drawing.Point(72, 31)
            Me.TxtQuantity.Name = "TxtQuantity"
            Me.TxtQuantity.Size = New System.Drawing.Size(144, 22)
            Me.TxtQuantity.TabIndex = 4
            '
            'ChkPinRate
            '
            Me.ChkPinRate.Appearance = System.Windows.Forms.Appearance.Button
            Me.ChkPinRate.AutoSize = True
            Me.ChkPinRate.Image = Global.CoinsAndShares.My.Resources.Resources.pin
            Me.ChkPinRate.Location = New System.Drawing.Point(222, 59)
            Me.ChkPinRate.Name = "ChkPinRate"
            Me.ChkPinRate.Size = New System.Drawing.Size(22, 22)
            Me.ChkPinRate.TabIndex = 8
            Me.ChkPinRate.TabStop = False
            Me.ChkPinRate.UseVisualStyleBackColor = True
            '
            'DtpDateTime
            '
            Me.DtpDateTime.Location = New System.Drawing.Point(165, 123)
            Me.DtpDateTime.Name = "DtpDateTime"
            Me.DtpDateTime.Size = New System.Drawing.Size(144, 22)
            Me.DtpDateTime.TabIndex = 1
            '
            'ChkPinValue
            '
            Me.ChkPinValue.Appearance = System.Windows.Forms.Appearance.Button
            Me.ChkPinValue.AutoSize = True
            Me.ChkPinValue.Image = Global.CoinsAndShares.My.Resources.Resources.pin
            Me.ChkPinValue.Location = New System.Drawing.Point(315, 315)
            Me.ChkPinValue.Name = "ChkPinValue"
            Me.ChkPinValue.Size = New System.Drawing.Size(22, 22)
            Me.ChkPinValue.TabIndex = 6
            Me.ChkPinValue.TabStop = False
            Me.ChkPinValue.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox2, 4)
            Me.GroupBox2.Controls.Add(Me.OptReasonMining)
            Me.GroupBox2.Controls.Add(Me.OptReasonAdjustment)
            Me.GroupBox2.Controls.Add(Me.OptReasonFee)
            Me.GroupBox2.Controls.Add(Me.OptReasonBonus)
            Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GroupBox2.Location = New System.Drawing.Point(93, 12)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Padding = New System.Windows.Forms.Padding(8, 3, 3, 3)
            Me.GroupBox2.Size = New System.Drawing.Size(437, 105)
            Me.GroupBox2.TabIndex = 9
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Reason"
            '
            'OptReasonMining
            '
            Me.OptReasonMining.AutoSize = True
            Me.OptReasonMining.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptReasonMining.Location = New System.Drawing.Point(8, 69)
            Me.OptReasonMining.Name = "OptReasonMining"
            Me.OptReasonMining.Size = New System.Drawing.Size(426, 17)
            Me.OptReasonMining.TabIndex = 3
            Me.OptReasonMining.TabStop = True
            Me.OptReasonMining.Text = "Mining"
            Me.OptReasonMining.UseVisualStyleBackColor = True
            '
            'OptReasonAdjustment
            '
            Me.OptReasonAdjustment.AutoSize = True
            Me.OptReasonAdjustment.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptReasonAdjustment.Location = New System.Drawing.Point(8, 52)
            Me.OptReasonAdjustment.Name = "OptReasonAdjustment"
            Me.OptReasonAdjustment.Size = New System.Drawing.Size(426, 17)
            Me.OptReasonAdjustment.TabIndex = 2
            Me.OptReasonAdjustment.TabStop = True
            Me.OptReasonAdjustment.Text = "Adjustment"
            Me.OptReasonAdjustment.UseVisualStyleBackColor = True
            '
            'OptReasonFee
            '
            Me.OptReasonFee.AutoSize = True
            Me.OptReasonFee.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptReasonFee.Location = New System.Drawing.Point(8, 35)
            Me.OptReasonFee.Name = "OptReasonFee"
            Me.OptReasonFee.Size = New System.Drawing.Size(426, 17)
            Me.OptReasonFee.TabIndex = 1
            Me.OptReasonFee.TabStop = True
            Me.OptReasonFee.Text = "Fee"
            Me.OptReasonFee.UseVisualStyleBackColor = True
            '
            'OptReasonBonus
            '
            Me.OptReasonBonus.AutoSize = True
            Me.OptReasonBonus.Dock = System.Windows.Forms.DockStyle.Top
            Me.OptReasonBonus.Location = New System.Drawing.Point(8, 18)
            Me.OptReasonBonus.Name = "OptReasonBonus"
            Me.OptReasonBonus.Size = New System.Drawing.Size(426, 17)
            Me.OptReasonBonus.TabIndex = 0
            Me.OptReasonBonus.TabStop = True
            Me.OptReasonBonus.Text = "Bonus (Inc Dividend)"
            Me.OptReasonBonus.UseVisualStyleBackColor = True
            '
            'PnlDescriptions
            '
            Me.TableLayoutPanel1.SetColumnSpan(Me.PnlDescriptions, 4)
            Me.PnlDescriptions.Dock = System.Windows.Forms.DockStyle.Top
            Me.PnlDescriptions.Location = New System.Drawing.Point(93, 343)
            Me.PnlDescriptions.Name = "PnlDescriptions"
            Me.PnlDescriptions.Size = New System.Drawing.Size(437, 20)
            Me.PnlDescriptions.TabIndex = 10
            '
            'FAdjust
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.MinimumSize = New System.Drawing.Size(640, 480)
            Me.Name = "FAdjust"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Adjustment"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            CType(Me.CmbInstrumentCode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.TlpInstrument.ResumeLayout(False)
            Me.TlpInstrument.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents OptAdjustTypeInstrument As RadioButton
        Friend WithEvents OptAdjustTypeMoney As RadioButton
        Friend WithEvents TxtRate As TextBox
        Friend WithEvents Label1 As Label
        Friend WithEvents TxtValue As TextBox
        Friend WithEvents LblAmountCaption As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents CmbInstrumentCode As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents LblInstrumentName As Label
        Friend WithEvents TxtDescription As TextBox
        Friend WithEvents Label4 As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TlpInstrument As TableLayoutPanel
        Friend WithEvents DtpDateTime As DateTimePicker
        Friend WithEvents Label6 As Label
        Friend WithEvents TxtQuantity As TextBox
        Friend WithEvents ChkPinQuantity As CheckBox
        Friend WithEvents ChkPinRate As CheckBox
        Friend WithEvents ChkPinValue As CheckBox
        Friend WithEvents GroupBox2 As GroupBox
        Friend WithEvents OptReasonBonus As RadioButton
        Friend WithEvents OptReasonFee As RadioButton
        Friend WithEvents OptReasonAdjustment As RadioButton
        Friend WithEvents LblWarning As Label
        Friend WithEvents OptReasonMining As RadioButton
        Friend WithEvents PnlDescriptions As Panel
    End Class

End Namespace
