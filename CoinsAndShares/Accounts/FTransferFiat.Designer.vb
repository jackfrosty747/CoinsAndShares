Namespace Accounts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FTransferFiat
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
            Me.CmbAccountFrom = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.CmbAccountTo = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.TxtAmount = New System.Windows.Forms.TextBox()
            Me.LblDebitAmountCaption = New System.Windows.Forms.Label()
            Me.LblSendingFeeLabel = New System.Windows.Forms.Label()
            Me.TxtSendFee = New System.Windows.Forms.TextBox()
            Me.TxtReceiveFee = New System.Windows.Forms.TextBox()
            Me.TxtReceivingFeeLabel = New System.Windows.Forms.Label()
            Me.LblIntermediateAmount = New System.Windows.Forms.Label()
            Me.LblReceiveCredit = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.BtnAll = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.DtpSendDateTime = New System.Windows.Forms.DateTimePicker()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.LblCreditLabel = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.ChkSameAsSendingDate = New System.Windows.Forms.CheckBox()
            Me.DtpReceiveDateTime = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            CType(Me.CmbAccountFrom, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbAccountTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'CmbAccountFrom
            '
            Me.CmbAccountFrom.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountFrom.DisplayMember = ""
            Me.CmbAccountFrom.Location = New System.Drawing.Point(144, 55)
            Me.CmbAccountFrom.Name = "CmbAccountFrom"
            Me.CmbAccountFrom.Size = New System.Drawing.Size(146, 22)
            Me.CmbAccountFrom.TabIndex = 1
            Me.CmbAccountFrom.ValueMember = ""
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(60, 58)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(78, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "From Account"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(60, 37)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 13)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "To Account"
            '
            'CmbAccountTo
            '
            Me.CmbAccountTo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountTo.DisplayMember = ""
            Me.CmbAccountTo.Location = New System.Drawing.Point(144, 34)
            Me.CmbAccountTo.Name = "CmbAccountTo"
            Me.CmbAccountTo.Size = New System.Drawing.Size(146, 22)
            Me.CmbAccountTo.TabIndex = 1
            Me.CmbAccountTo.ValueMember = ""
            '
            'TxtAmount
            '
            Me.TxtAmount.Location = New System.Drawing.Point(402, 55)
            Me.TxtAmount.Name = "TxtAmount"
            Me.TxtAmount.Size = New System.Drawing.Size(105, 22)
            Me.TxtAmount.TabIndex = 3
            '
            'LblDebitAmountCaption
            '
            Me.LblDebitAmountCaption.AutoSize = True
            Me.LblDebitAmountCaption.Location = New System.Drawing.Point(308, 58)
            Me.LblDebitAmountCaption.Name = "LblDebitAmountCaption"
            Me.LblDebitAmountCaption.Size = New System.Drawing.Size(79, 13)
            Me.LblDebitAmountCaption.TabIndex = 2
            Me.LblDebitAmountCaption.Text = "Debit Amount"
            '
            'LblSendingFeeLabel
            '
            Me.LblSendingFeeLabel.AutoSize = True
            Me.LblSendingFeeLabel.Location = New System.Drawing.Point(308, 86)
            Me.LblSendingFeeLabel.Name = "LblSendingFeeLabel"
            Me.LblSendingFeeLabel.Size = New System.Drawing.Size(71, 13)
            Me.LblSendingFeeLabel.TabIndex = 6
            Me.LblSendingFeeLabel.Text = "Sending Fee"
            '
            'TxtSendFee
            '
            Me.TxtSendFee.Location = New System.Drawing.Point(402, 83)
            Me.TxtSendFee.Name = "TxtSendFee"
            Me.TxtSendFee.Size = New System.Drawing.Size(105, 22)
            Me.TxtSendFee.TabIndex = 7
            '
            'TxtReceiveFee
            '
            Me.TxtReceiveFee.Location = New System.Drawing.Point(402, 34)
            Me.TxtReceiveFee.Name = "TxtReceiveFee"
            Me.TxtReceiveFee.Size = New System.Drawing.Size(105, 22)
            Me.TxtReceiveFee.TabIndex = 3
            '
            'TxtReceivingFeeLabel
            '
            Me.TxtReceivingFeeLabel.AutoSize = True
            Me.TxtReceivingFeeLabel.Location = New System.Drawing.Point(308, 37)
            Me.TxtReceivingFeeLabel.Name = "TxtReceivingFeeLabel"
            Me.TxtReceivingFeeLabel.Size = New System.Drawing.Size(77, 13)
            Me.TxtReceivingFeeLabel.TabIndex = 2
            Me.TxtReceivingFeeLabel.Text = "Receiving Fee"
            '
            'LblIntermediateAmount
            '
            Me.LblIntermediateAmount.AutoSize = True
            Me.LblIntermediateAmount.Location = New System.Drawing.Point(411, 196)
            Me.LblIntermediateAmount.Name = "LblIntermediateAmount"
            Me.LblIntermediateAmount.Size = New System.Drawing.Size(128, 13)
            Me.LblIntermediateAmount.TabIndex = 3
            Me.LblIntermediateAmount.Text = "LblIntermediateAmount"
            '
            'LblReceiveCredit
            '
            Me.LblReceiveCredit.AutoSize = True
            Me.LblReceiveCredit.ForeColor = System.Drawing.Color.Blue
            Me.LblReceiveCredit.Location = New System.Drawing.Point(399, 93)
            Me.LblReceiveCredit.Name = "LblReceiveCredit"
            Me.LblReceiveCredit.Size = New System.Drawing.Size(91, 13)
            Me.LblReceiveCredit.TabIndex = 5
            Me.LblReceiveCredit.Text = "LblReceiveCredit"
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
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.Panel2.Controls.Add(Me.Label7)
            Me.Panel2.Controls.Add(Me.BtnAll)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.DtpSendDateTime)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.CmbAccountFrom)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Controls.Add(Me.TxtAmount)
            Me.Panel2.Controls.Add(Me.LblDebitAmountCaption)
            Me.Panel2.Controls.Add(Me.LblSendingFeeLabel)
            Me.Panel2.Controls.Add(Me.TxtSendFee)
            Me.Panel2.Location = New System.Drawing.Point(12, 12)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(600, 130)
            Me.Panel2.TabIndex = 0
            '
            'BtnAll
            '
            Me.BtnAll.AutoSize = True
            Me.BtnAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnAll.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnAll.Location = New System.Drawing.Point(513, 55)
            Me.BtnAll.Name = "BtnAll"
            Me.BtnAll.Size = New System.Drawing.Size(30, 23)
            Me.BtnAll.TabIndex = 9
            Me.BtnAll.Text = "All"
            Me.BtnAll.UseVisualStyleBackColor = False
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(60, 22)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(109, 13)
            Me.Label5.TabIndex = 8
            Me.Label5.Text = "Send From Account"
            '
            'DtpSendDateTime
            '
            Me.DtpSendDateTime.Location = New System.Drawing.Point(144, 83)
            Me.DtpSendDateTime.Name = "DtpSendDateTime"
            Me.DtpSendDateTime.Size = New System.Drawing.Size(146, 22)
            Me.DtpSendDateTime.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(60, 86)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(65, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Date / Time"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.Panel3.Controls.Add(Me.LblCreditLabel)
            Me.Panel3.Controls.Add(Me.Label6)
            Me.Panel3.Controls.Add(Me.ChkSameAsSendingDate)
            Me.Panel3.Controls.Add(Me.DtpReceiveDateTime)
            Me.Panel3.Controls.Add(Me.Label4)
            Me.Panel3.Controls.Add(Me.Label2)
            Me.Panel3.Controls.Add(Me.CmbAccountTo)
            Me.Panel3.Controls.Add(Me.TxtReceiveFee)
            Me.Panel3.Controls.Add(Me.LblReceiveCredit)
            Me.Panel3.Controls.Add(Me.TxtReceivingFeeLabel)
            Me.Panel3.Location = New System.Drawing.Point(12, 267)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(600, 130)
            Me.Panel3.TabIndex = 1
            '
            'LblCreditLabel
            '
            Me.LblCreditLabel.AutoSize = True
            Me.LblCreditLabel.Location = New System.Drawing.Point(308, 93)
            Me.LblCreditLabel.Name = "LblCreditLabel"
            Me.LblCreditLabel.Size = New System.Drawing.Size(85, 13)
            Me.LblCreditLabel.TabIndex = 10
            Me.LblCreditLabel.Text = "Credit Amount:"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(60, 8)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(107, 13)
            Me.Label6.TabIndex = 9
            Me.Label6.Text = "Receive To Account"
            '
            'ChkSameAsSendingDate
            '
            Me.ChkSameAsSendingDate.AutoSize = True
            Me.ChkSameAsSendingDate.Checked = True
            Me.ChkSameAsSendingDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ChkSameAsSendingDate.Location = New System.Drawing.Point(144, 80)
            Me.ChkSameAsSendingDate.Name = "ChkSameAsSendingDate"
            Me.ChkSameAsSendingDate.Size = New System.Drawing.Size(141, 17)
            Me.ChkSameAsSendingDate.TabIndex = 4
            Me.ChkSameAsSendingDate.Text = "Same As Sending Date"
            Me.ChkSameAsSendingDate.UseVisualStyleBackColor = True
            '
            'DtpReceiveDateTime
            '
            Me.DtpReceiveDateTime.Location = New System.Drawing.Point(144, 103)
            Me.DtpReceiveDateTime.Name = "DtpReceiveDateTime"
            Me.DtpReceiveDateTime.Size = New System.Drawing.Size(146, 22)
            Me.DtpReceiveDateTime.TabIndex = 5
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(60, 93)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(65, 13)
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "Date / Time"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(361, 108)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(194, 13)
            Me.Label7.TabIndex = 4
            Me.Label7.Text = "Fees will appear as separate batches"
            '
            'FTransferFiat
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.LblIntermediateAmount)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FTransferFiat"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Transfer"
            CType(Me.CmbAccountFrom, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbAccountTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents CmbAccountFrom As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents CmbAccountTo As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents TxtAmount As TextBox
        Friend WithEvents LblDebitAmountCaption As Label
        Friend WithEvents LblSendingFeeLabel As Label
        Friend WithEvents TxtSendFee As TextBox
        Friend WithEvents TxtReceiveFee As TextBox
        Friend WithEvents TxtReceivingFeeLabel As Label
        Friend WithEvents LblIntermediateAmount As Label
        Friend WithEvents LblReceiveCredit As Label
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents Panel2 As Panel
        Friend WithEvents Panel3 As Panel
        Friend WithEvents Label3 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents DtpSendDateTime As DateTimePicker
        Friend WithEvents DtpReceiveDateTime As DateTimePicker
        Friend WithEvents ChkSameAsSendingDate As CheckBox
        Friend WithEvents Label5 As Label
        Friend WithEvents Label6 As Label
        Friend WithEvents LblCreditLabel As Label
        Friend WithEvents Label7 As Label
        Friend WithEvents BtnAll As Button
    End Class

End Namespace
