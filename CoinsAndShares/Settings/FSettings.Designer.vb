Namespace Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSettings
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
            Me.TxtAlphavantageApiKey = New System.Windows.Forms.TextBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.TxtExchangeRatesApiKey = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.TxtRateUpdateWarningHours = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.TxtDefaultBackupPath = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(5, 20)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(43, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "API Key"
            '
            'TxtAlphavantageApiKey
            '
            Me.TxtAlphavantageApiKey.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtAlphavantageApiKey.Location = New System.Drawing.Point(48, 20)
            Me.TxtAlphavantageApiKey.Name = "TxtAlphavantageApiKey"
            Me.TxtAlphavantageApiKey.Size = New System.Drawing.Size(561, 22)
            Me.TxtAlphavantageApiKey.TabIndex = 1
            Me.TxtAlphavantageApiKey.Text = "TxtAlphavantageApiKey"
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
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TxtAlphavantageApiKey)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox1.Size = New System.Drawing.Size(614, 67)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Alphavantage API"
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.GroupBox4)
            Me.Panel2.Controls.Add(Me.GroupBox3)
            Me.Panel2.Controls.Add(Me.GroupBox2)
            Me.Panel2.Controls.Add(Me.GroupBox1)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(624, 403)
            Me.Panel2.TabIndex = 0
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.TxtExchangeRatesApiKey)
            Me.GroupBox3.Controls.Add(Me.Label3)
            Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBox3.Location = New System.Drawing.Point(5, 136)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox3.Size = New System.Drawing.Size(614, 67)
            Me.GroupBox3.TabIndex = 2
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Exchangeratesapi.io"
            '
            'TxtExchangeRatesApiKey
            '
            Me.TxtExchangeRatesApiKey.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtExchangeRatesApiKey.Location = New System.Drawing.Point(48, 20)
            Me.TxtExchangeRatesApiKey.Name = "TxtExchangeRatesApiKey"
            Me.TxtExchangeRatesApiKey.Size = New System.Drawing.Size(561, 22)
            Me.TxtExchangeRatesApiKey.TabIndex = 1
            Me.TxtExchangeRatesApiKey.Text = "TxtExchangeRatesApiKey"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(5, 20)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(43, 16)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "API Key"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.TxtRateUpdateWarningHours)
            Me.GroupBox2.Controls.Add(Me.Label2)
            Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBox2.Location = New System.Drawing.Point(5, 72)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox2.Size = New System.Drawing.Size(614, 64)
            Me.GroupBox2.TabIndex = 1
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Rate Update Warning"
            '
            'TxtRateUpdateWarningHours
            '
            Me.TxtRateUpdateWarningHours.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtRateUpdateWarningHours.Location = New System.Drawing.Point(43, 20)
            Me.TxtRateUpdateWarningHours.Name = "TxtRateUpdateWarningHours"
            Me.TxtRateUpdateWarningHours.Size = New System.Drawing.Size(566, 22)
            Me.TxtRateUpdateWarningHours.TabIndex = 1
            Me.TxtRateUpdateWarningHours.Text = "TxtRateUpdateWarningHours"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(5, 20)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(38, 16)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Hours"
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.TxtDefaultBackupPath)
            Me.GroupBox4.Controls.Add(Me.Label4)
            Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
            Me.GroupBox4.Location = New System.Drawing.Point(5, 203)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox4.Size = New System.Drawing.Size(614, 67)
            Me.GroupBox4.TabIndex = 3
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Backup"
            '
            'TxtDefaultBackupPath
            '
            Me.TxtDefaultBackupPath.Dock = System.Windows.Forms.DockStyle.Top
            Me.TxtDefaultBackupPath.Location = New System.Drawing.Point(35, 20)
            Me.TxtDefaultBackupPath.Name = "TxtDefaultBackupPath"
            Me.TxtDefaultBackupPath.Size = New System.Drawing.Size(574, 22)
            Me.TxtDefaultBackupPath.TabIndex = 1
            Me.TxtDefaultBackupPath.Text = "TxtDefaultBackupPath"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(5, 20)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(30, 16)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Path"
            '
            'FSettings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FSettings"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Settings"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox4.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Label1 As Label
        Friend WithEvents TxtAlphavantageApiKey As TextBox
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents Panel2 As Panel
        Friend WithEvents GroupBox2 As GroupBox
        Friend WithEvents TxtRateUpdateWarningHours As TextBox
        Friend WithEvents Label2 As Label
        Friend WithEvents GroupBox3 As GroupBox
        Friend WithEvents TxtExchangeRatesApiKey As TextBox
        Friend WithEvents Label3 As Label
        Friend WithEvents GroupBox4 As GroupBox
        Friend WithEvents TxtDefaultBackupPath As TextBox
        Friend WithEvents Label4 As Label
    End Class

End Namespace
