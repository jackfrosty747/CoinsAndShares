Namespace Charts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSavingsAndTaxPredictor
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
            Me.DtpTaxYearStart = New System.Windows.Forms.DateTimePicker()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            Me.GrdHoldings = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.LblToPay = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.TxtTaxRate = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TxtAllowance = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.LblTaxable = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(5, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Tax Year Start"
            '
            'DtpTaxYearStart
            '
            Me.DtpTaxYearStart.Dock = System.Windows.Forms.DockStyle.Left
            Me.DtpTaxYearStart.Location = New System.Drawing.Point(77, 5)
            Me.DtpTaxYearStart.Name = "DtpTaxYearStart"
            Me.DtpTaxYearStart.Size = New System.Drawing.Size(200, 22)
            Me.DtpTaxYearStart.TabIndex = 1
            '
            'BtnRefresh
            '
            Me.BtnRefresh.AutoSize = True
            Me.BtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnRefresh.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_circle_double_135
            Me.BtnRefresh.Location = New System.Drawing.Point(547, 5)
            Me.BtnRefresh.Name = "BtnRefresh"
            Me.BtnRefresh.Size = New System.Drawing.Size(72, 28)
            Me.BtnRefresh.TabIndex = 2
            Me.BtnRefresh.Text = "Refresh"
            Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnRefresh.UseVisualStyleBackColor = False
            '
            'GrdHoldings
            '
            Me.GrdHoldings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdHoldings.Location = New System.Drawing.Point(0, 38)
            Me.GrdHoldings.Name = "GrdHoldings"
            Me.GrdHoldings.Size = New System.Drawing.Size(624, 365)
            Me.GrdHoldings.TabIndex = 13
            Me.GrdHoldings.Text = "Cash Savings"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.DtpTaxYearStart)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(624, 38)
            Me.Panel1.TabIndex = 14
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.Controls.Add(Me.LblToPay)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.TxtTaxRate)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.TxtAllowance)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.LblTaxable)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(0, 403)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(624, 38)
            Me.Panel2.TabIndex = 15
            '
            'LblToPay
            '
            Me.LblToPay.AutoSize = True
            Me.LblToPay.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblToPay.ForeColor = System.Drawing.Color.Red
            Me.LblToPay.Location = New System.Drawing.Point(502, 5)
            Me.LblToPay.Name = "LblToPay"
            Me.LblToPay.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblToPay.Size = New System.Drawing.Size(50, 18)
            Me.LblToPay.TabIndex = 7
            Me.LblToPay.Text = "LblToPay"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Red
            Me.Label5.Location = New System.Drawing.Point(445, 5)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(10, 5, 0, 0)
            Me.Label5.Size = New System.Drawing.Size(57, 18)
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "TO PAY:"
            '
            'TxtTaxRate
            '
            Me.TxtTaxRate.Dock = System.Windows.Forms.DockStyle.Left
            Me.TxtTaxRate.Location = New System.Drawing.Point(347, 5)
            Me.TxtTaxRate.Name = "TxtTaxRate"
            Me.TxtTaxRate.Size = New System.Drawing.Size(98, 22)
            Me.TxtTaxRate.TabIndex = 5
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(289, 5)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(10, 5, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(58, 18)
            Me.Label4.TabIndex = 4
            Me.Label4.Text = "Tax Rate"
            '
            'TxtAllowance
            '
            Me.TxtAllowance.Dock = System.Windows.Forms.DockStyle.Left
            Me.TxtAllowance.Location = New System.Drawing.Point(191, 5)
            Me.TxtAllowance.Name = "TxtAllowance"
            Me.TxtAllowance.Size = New System.Drawing.Size(98, 22)
            Me.TxtAllowance.TabIndex = 3
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(121, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(10, 5, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(70, 18)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Allowance"
            '
            'LblTaxable
            '
            Me.LblTaxable.AutoSize = True
            Me.LblTaxable.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblTaxable.ForeColor = System.Drawing.Color.Red
            Me.LblTaxable.Location = New System.Drawing.Point(62, 5)
            Me.LblTaxable.Name = "LblTaxable"
            Me.LblTaxable.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblTaxable.Size = New System.Drawing.Size(59, 18)
            Me.LblTaxable.TabIndex = 1
            Me.LblTaxable.Text = "LblTaxable"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Red
            Me.Label2.Location = New System.Drawing.Point(5, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(57, 18)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "TAXABLE:"
            '
            'FSavingsAndTaxPredictor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.GrdHoldings)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FSavingsAndTaxPredictor"
            Me.Text = "Savings And Tax Predictor"
            CType(Me.GrdHoldings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Label1 As Label
        Friend WithEvents DtpTaxYearStart As DateTimePicker
        Friend WithEvents BtnRefresh As Button
        Friend WithEvents GrdHoldings As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel1 As Panel
        Friend WithEvents Panel2 As Panel
        Friend WithEvents Label2 As Label
        Friend WithEvents LblTaxable As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents TxtAllowance As TextBox
        Friend WithEvents TxtTaxRate As TextBox
        Friend WithEvents Label4 As Label
        Friend WithEvents LblToPay As Label
        Friend WithEvents Label5 As Label
    End Class

End Namespace
