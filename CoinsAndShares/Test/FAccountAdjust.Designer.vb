Imports MaterialSkin.Controls

Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccountAdjust
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
            Me.MOptReasonBonus = New MaterialSkin.Controls.MaterialRadioButton()
            Me.MOptReasonFee = New MaterialSkin.Controls.MaterialRadioButton()
            Me.MOptReasonAdjust = New MaterialSkin.Controls.MaterialRadioButton()
            Me.MOptReasonMining = New MaterialSkin.Controls.MaterialRadioButton()
            Me.MaterialCard1 = New MaterialSkin.Controls.MaterialCard()
            Me.MTxtDate = New MaterialSkin.Controls.MaterialTextBox2()
            Me.MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
            Me.MaterialCard2 = New MaterialSkin.Controls.MaterialCard()
            Me.BtnProcess = New MaterialSkin.Controls.MaterialButton()
            Me.MaterialCard3 = New MaterialSkin.Controls.MaterialCard()
            Me.MAdjustTypeInstrument = New MaterialSkin.Controls.MaterialRadioButton()
            Me.MAdjustTypeMoney = New MaterialSkin.Controls.MaterialRadioButton()
            Me.TlpInstrument = New System.Windows.Forms.TableLayoutPanel()
            Me.ChkPinQuantity = New System.Windows.Forms.CheckBox()
            Me.TxtRate = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.CmbInstrument = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TxtQuantity = New System.Windows.Forms.TextBox()
            Me.LblInstrumentName = New System.Windows.Forms.Label()
            Me.ChkPinRate = New System.Windows.Forms.CheckBox()
            Me.LblAmountCaption = New System.Windows.Forms.Label()
            Me.TxtValue = New System.Windows.Forms.TextBox()
            Me.ChkPinValue = New System.Windows.Forms.CheckBox()
            Me.MaterialCard1.SuspendLayout()
            Me.MaterialCard2.SuspendLayout()
            Me.MaterialCard3.SuspendLayout()
            Me.TlpInstrument.SuspendLayout()
            CType(Me.CmbInstrument, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'MOptReasonBonus
            '
            Me.MOptReasonBonus.AutoSize = True
            Me.MOptReasonBonus.Depth = 0
            Me.MOptReasonBonus.Dock = System.Windows.Forms.DockStyle.Top
            Me.MOptReasonBonus.Location = New System.Drawing.Point(14, 14)
            Me.MOptReasonBonus.Margin = New System.Windows.Forms.Padding(0)
            Me.MOptReasonBonus.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MOptReasonBonus.MouseState = MaterialSkin.MouseState.HOVER
            Me.MOptReasonBonus.Name = "MOptReasonBonus"
            Me.MOptReasonBonus.Ripple = True
            Me.MOptReasonBonus.Size = New System.Drawing.Size(420, 37)
            Me.MOptReasonBonus.TabIndex = 0
            Me.MOptReasonBonus.TabStop = True
            Me.MOptReasonBonus.Text = "Bonus (Inc Dividend)"
            Me.MOptReasonBonus.UseVisualStyleBackColor = True
            '
            'MOptReasonFee
            '
            Me.MOptReasonFee.AutoSize = True
            Me.MOptReasonFee.Depth = 0
            Me.MOptReasonFee.Dock = System.Windows.Forms.DockStyle.Top
            Me.MOptReasonFee.Location = New System.Drawing.Point(14, 51)
            Me.MOptReasonFee.Margin = New System.Windows.Forms.Padding(0)
            Me.MOptReasonFee.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MOptReasonFee.MouseState = MaterialSkin.MouseState.HOVER
            Me.MOptReasonFee.Name = "MOptReasonFee"
            Me.MOptReasonFee.Ripple = True
            Me.MOptReasonFee.Size = New System.Drawing.Size(420, 37)
            Me.MOptReasonFee.TabIndex = 1
            Me.MOptReasonFee.TabStop = True
            Me.MOptReasonFee.Text = "Fee"
            Me.MOptReasonFee.UseVisualStyleBackColor = True
            '
            'MOptReasonAdjust
            '
            Me.MOptReasonAdjust.AutoSize = True
            Me.MOptReasonAdjust.Depth = 0
            Me.MOptReasonAdjust.Dock = System.Windows.Forms.DockStyle.Top
            Me.MOptReasonAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MOptReasonAdjust.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
            Me.MOptReasonAdjust.Location = New System.Drawing.Point(14, 88)
            Me.MOptReasonAdjust.Margin = New System.Windows.Forms.Padding(0)
            Me.MOptReasonAdjust.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MOptReasonAdjust.MouseState = MaterialSkin.MouseState.HOVER
            Me.MOptReasonAdjust.Name = "MOptReasonAdjust"
            Me.MOptReasonAdjust.Ripple = True
            Me.MOptReasonAdjust.Size = New System.Drawing.Size(420, 37)
            Me.MOptReasonAdjust.TabIndex = 2
            Me.MOptReasonAdjust.TabStop = True
            Me.MOptReasonAdjust.Text = "Adjustment"
            Me.MOptReasonAdjust.UseVisualStyleBackColor = True
            '
            'MOptReasonMining
            '
            Me.MOptReasonMining.AutoSize = True
            Me.MOptReasonMining.Depth = 0
            Me.MOptReasonMining.Dock = System.Windows.Forms.DockStyle.Top
            Me.MOptReasonMining.Location = New System.Drawing.Point(14, 125)
            Me.MOptReasonMining.Margin = New System.Windows.Forms.Padding(0)
            Me.MOptReasonMining.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MOptReasonMining.MouseState = MaterialSkin.MouseState.HOVER
            Me.MOptReasonMining.Name = "MOptReasonMining"
            Me.MOptReasonMining.Ripple = True
            Me.MOptReasonMining.Size = New System.Drawing.Size(420, 37)
            Me.MOptReasonMining.TabIndex = 3
            Me.MOptReasonMining.TabStop = True
            Me.MOptReasonMining.Text = "Mining"
            Me.MOptReasonMining.UseVisualStyleBackColor = True
            '
            'MaterialCard1
            '
            Me.MaterialCard1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.MaterialCard1.Controls.Add(Me.MOptReasonMining)
            Me.MaterialCard1.Controls.Add(Me.MOptReasonAdjust)
            Me.MaterialCard1.Controls.Add(Me.MOptReasonFee)
            Me.MaterialCard1.Controls.Add(Me.MOptReasonBonus)
            Me.MaterialCard1.Depth = 0
            Me.MaterialCard1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.MaterialCard1.Location = New System.Drawing.Point(166, 78)
            Me.MaterialCard1.Margin = New System.Windows.Forms.Padding(14)
            Me.MaterialCard1.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialCard1.Name = "MaterialCard1"
            Me.MaterialCard1.Padding = New System.Windows.Forms.Padding(14)
            Me.MaterialCard1.Size = New System.Drawing.Size(448, 179)
            Me.MaterialCard1.TabIndex = 4
            '
            'MTxtDate
            '
            Me.MTxtDate.AnimateReadOnly = False
            Me.MTxtDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.MTxtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.MTxtDate.Depth = 0
            Me.MTxtDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MTxtDate.HideSelection = True
            Me.MTxtDate.LeadingIcon = Nothing
            Me.MTxtDate.Location = New System.Drawing.Point(113, 11)
            Me.MTxtDate.MaxLength = 32767
            Me.MTxtDate.MouseState = MaterialSkin.MouseState.OUT
            Me.MTxtDate.Name = "MTxtDate"
            Me.MTxtDate.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
            Me.MTxtDate.PrefixSuffixText = Nothing
            Me.MTxtDate.ReadOnly = False
            Me.MTxtDate.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.MTxtDate.SelectedText = ""
            Me.MTxtDate.SelectionLength = 0
            Me.MTxtDate.SelectionStart = 0
            Me.MTxtDate.ShortcutsEnabled = True
            Me.MTxtDate.Size = New System.Drawing.Size(250, 48)
            Me.MTxtDate.TabIndex = 6
            Me.MTxtDate.TabStop = False
            Me.MTxtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
            Me.MTxtDate.TrailingIcon = Nothing
            Me.MTxtDate.UseSystemPasswordChar = False
            '
            'MaterialLabel1
            '
            Me.MaterialLabel1.AutoSize = True
            Me.MaterialLabel1.Depth = 0
            Me.MaterialLabel1.Font = New System.Drawing.Font("Roboto", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
            Me.MaterialLabel1.Location = New System.Drawing.Point(17, 25)
            Me.MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialLabel1.Name = "MaterialLabel1"
            Me.MaterialLabel1.Size = New System.Drawing.Size(34, 19)
            Me.MaterialLabel1.TabIndex = 7
            Me.MaterialLabel1.Text = "Date"
            '
            'MaterialCard2
            '
            Me.MaterialCard2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.MaterialCard2.Controls.Add(Me.MTxtDate)
            Me.MaterialCard2.Controls.Add(Me.MaterialLabel1)
            Me.MaterialCard2.Depth = 0
            Me.MaterialCard2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.MaterialCard2.Location = New System.Drawing.Point(166, 285)
            Me.MaterialCard2.Margin = New System.Windows.Forms.Padding(14)
            Me.MaterialCard2.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialCard2.Name = "MaterialCard2"
            Me.MaterialCard2.Padding = New System.Windows.Forms.Padding(14)
            Me.MaterialCard2.Size = New System.Drawing.Size(448, 68)
            Me.MaterialCard2.TabIndex = 8
            '
            'BtnProcess
            '
            Me.BtnProcess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnProcess.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.BtnProcess.Depth = 0
            Me.BtnProcess.HighEmphasis = True
            Me.BtnProcess.Icon = Nothing
            Me.BtnProcess.Location = New System.Drawing.Point(166, 555)
            Me.BtnProcess.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.BtnProcess.MouseState = MaterialSkin.MouseState.HOVER
            Me.BtnProcess.Name = "BtnProcess"
            Me.BtnProcess.NoAccentTextColor = System.Drawing.Color.Empty
            Me.BtnProcess.Size = New System.Drawing.Size(86, 36)
            Me.BtnProcess.TabIndex = 9
            Me.BtnProcess.Text = "Process"
            Me.BtnProcess.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.BtnProcess.UseAccentColor = False
            Me.BtnProcess.UseVisualStyleBackColor = True
            '
            'MaterialCard3
            '
            Me.MaterialCard3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.MaterialCard3.Controls.Add(Me.MAdjustTypeInstrument)
            Me.MaterialCard3.Controls.Add(Me.MAdjustTypeMoney)
            Me.MaterialCard3.Depth = 0
            Me.MaterialCard3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.MaterialCard3.Location = New System.Drawing.Point(81, 361)
            Me.MaterialCard3.Margin = New System.Windows.Forms.Padding(14)
            Me.MaterialCard3.MouseState = MaterialSkin.MouseState.HOVER
            Me.MaterialCard3.Name = "MaterialCard3"
            Me.MaterialCard3.Padding = New System.Windows.Forms.Padding(14)
            Me.MaterialCard3.Size = New System.Drawing.Size(333, 179)
            Me.MaterialCard3.TabIndex = 10
            '
            'MAdjustTypeInstrument
            '
            Me.MAdjustTypeInstrument.AutoSize = True
            Me.MAdjustTypeInstrument.Depth = 0
            Me.MAdjustTypeInstrument.Dock = System.Windows.Forms.DockStyle.Top
            Me.MAdjustTypeInstrument.Location = New System.Drawing.Point(14, 51)
            Me.MAdjustTypeInstrument.Margin = New System.Windows.Forms.Padding(0)
            Me.MAdjustTypeInstrument.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MAdjustTypeInstrument.MouseState = MaterialSkin.MouseState.HOVER
            Me.MAdjustTypeInstrument.Name = "MAdjustTypeInstrument"
            Me.MAdjustTypeInstrument.Ripple = True
            Me.MAdjustTypeInstrument.Size = New System.Drawing.Size(305, 37)
            Me.MAdjustTypeInstrument.TabIndex = 1
            Me.MAdjustTypeInstrument.TabStop = True
            Me.MAdjustTypeInstrument.Text = "MAdjustTypeInstrument"
            Me.MAdjustTypeInstrument.UseVisualStyleBackColor = True
            '
            'MAdjustTypeMoney
            '
            Me.MAdjustTypeMoney.AutoSize = True
            Me.MAdjustTypeMoney.Depth = 0
            Me.MAdjustTypeMoney.Dock = System.Windows.Forms.DockStyle.Top
            Me.MAdjustTypeMoney.Location = New System.Drawing.Point(14, 14)
            Me.MAdjustTypeMoney.Margin = New System.Windows.Forms.Padding(0)
            Me.MAdjustTypeMoney.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MAdjustTypeMoney.MouseState = MaterialSkin.MouseState.HOVER
            Me.MAdjustTypeMoney.Name = "MAdjustTypeMoney"
            Me.MAdjustTypeMoney.Ripple = True
            Me.MAdjustTypeMoney.Size = New System.Drawing.Size(305, 37)
            Me.MAdjustTypeMoney.TabIndex = 0
            Me.MAdjustTypeMoney.TabStop = True
            Me.MAdjustTypeMoney.Text = "MAdjustTypeMoney"
            Me.MAdjustTypeMoney.UseVisualStyleBackColor = True
            '
            'TlpInstrument
            '
            Me.TlpInstrument.AutoSize = True
            Me.TlpInstrument.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TlpInstrument.ColumnCount = 4
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpInstrument.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpInstrument.Controls.Add(Me.ChkPinQuantity, 2, 1)
            Me.TlpInstrument.Controls.Add(Me.TxtRate, 1, 2)
            Me.TlpInstrument.Controls.Add(Me.Label1, 0, 2)
            Me.TlpInstrument.Controls.Add(Me.Label3, 0, 0)
            Me.TlpInstrument.Controls.Add(Me.CmbInstrument, 1, 0)
            Me.TlpInstrument.Controls.Add(Me.Label6, 0, 1)
            Me.TlpInstrument.Controls.Add(Me.TxtQuantity, 1, 1)
            Me.TlpInstrument.Controls.Add(Me.LblInstrumentName, 2, 0)
            Me.TlpInstrument.Controls.Add(Me.ChkPinRate, 2, 2)
            Me.TlpInstrument.Location = New System.Drawing.Point(431, 361)
            Me.TlpInstrument.Name = "TlpInstrument"
            Me.TlpInstrument.RowCount = 3
            Me.TlpInstrument.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpInstrument.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpInstrument.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpInstrument.Size = New System.Drawing.Size(332, 84)
            Me.TlpInstrument.TabIndex = 12
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
            'CmbInstrument
            '
            Me.CmbInstrument.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrument.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrument.DisplayMember = ""
            Me.CmbInstrument.Dock = System.Windows.Forms.DockStyle.Top
            Me.CmbInstrument.Location = New System.Drawing.Point(72, 3)
            Me.CmbInstrument.Name = "CmbInstrument"
            Me.CmbInstrument.Size = New System.Drawing.Size(144, 22)
            Me.CmbInstrument.TabIndex = 1
            Me.CmbInstrument.ValueMember = ""
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
            'LblAmountCaption
            '
            Me.LblAmountCaption.AutoSize = True
            Me.LblAmountCaption.Location = New System.Drawing.Point(480, 515)
            Me.LblAmountCaption.Name = "LblAmountCaption"
            Me.LblAmountCaption.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.LblAmountCaption.Size = New System.Drawing.Size(35, 16)
            Me.LblAmountCaption.TabIndex = 13
            Me.LblAmountCaption.Text = "Value"
            '
            'TxtValue
            '
            Me.TxtValue.Location = New System.Drawing.Point(531, 518)
            Me.TxtValue.Name = "TxtValue"
            Me.TxtValue.Size = New System.Drawing.Size(144, 22)
            Me.TxtValue.TabIndex = 14
            '
            'ChkPinValue
            '
            Me.ChkPinValue.Appearance = System.Windows.Forms.Appearance.Button
            Me.ChkPinValue.AutoSize = True
            Me.ChkPinValue.Image = Global.CoinsAndShares.My.Resources.Resources.pin
            Me.ChkPinValue.Location = New System.Drawing.Point(702, 518)
            Me.ChkPinValue.Name = "ChkPinValue"
            Me.ChkPinValue.Size = New System.Drawing.Size(22, 22)
            Me.ChkPinValue.TabIndex = 15
            Me.ChkPinValue.TabStop = False
            Me.ChkPinValue.UseVisualStyleBackColor = True
            '
            'FAccountAdjust
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(800, 600)
            Me.Controls.Add(Me.LblAmountCaption)
            Me.Controls.Add(Me.TxtValue)
            Me.Controls.Add(Me.ChkPinValue)
            Me.Controls.Add(Me.TlpInstrument)
            Me.Controls.Add(Me.MaterialCard3)
            Me.Controls.Add(Me.BtnProcess)
            Me.Controls.Add(Me.MaterialCard2)
            Me.Controls.Add(Me.MaterialCard1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FAccountAdjust"
            Me.Text = "Post Transaction"
            Me.MaterialCard1.ResumeLayout(False)
            Me.MaterialCard1.PerformLayout()
            Me.MaterialCard2.ResumeLayout(False)
            Me.MaterialCard2.PerformLayout()
            Me.MaterialCard3.ResumeLayout(False)
            Me.MaterialCard3.PerformLayout()
            Me.TlpInstrument.ResumeLayout(False)
            Me.TlpInstrument.PerformLayout()
            CType(Me.CmbInstrument, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents MOptReasonBonus As MaterialRadioButton
        Friend WithEvents MOptReasonFee As MaterialRadioButton
        Friend WithEvents MOptReasonAdjust As MaterialRadioButton
        Friend WithEvents MOptReasonMining As MaterialRadioButton
        Friend WithEvents MaterialCard1 As MaterialCard
        Friend WithEvents MTxtDate As MaterialTextBox2
        Friend WithEvents MaterialLabel1 As MaterialLabel
        Friend WithEvents MaterialCard2 As MaterialCard
        Friend WithEvents BtnProcess As MaterialButton
        Friend WithEvents MaterialCard3 As MaterialCard
        Friend WithEvents MAdjustTypeInstrument As MaterialRadioButton
        Friend WithEvents MAdjustTypeMoney As MaterialRadioButton
        Friend WithEvents TlpInstrument As TableLayoutPanel
        Friend WithEvents ChkPinQuantity As CheckBox
        Friend WithEvents TxtRate As TextBox
        Friend WithEvents Label1 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents CmbInstrument As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label6 As Label
        Friend WithEvents TxtQuantity As TextBox
        Friend WithEvents LblInstrumentName As Label
        Friend WithEvents ChkPinRate As CheckBox
        Friend WithEvents LblAmountCaption As Label
        Friend WithEvents TxtValue As TextBox
        Friend WithEvents ChkPinValue As CheckBox
    End Class
End Namespace

