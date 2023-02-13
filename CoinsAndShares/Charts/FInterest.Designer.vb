Namespace Charts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FInterest
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
            Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
            Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
            Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
            Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
            Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
            Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
            Me.ChartAccount = New System.Windows.Forms.DataVisualization.Charting.Chart()
            Me.TxtFilter = New System.Windows.Forms.TextBox()
            Me.BtnGo = New System.Windows.Forms.Button()
            Me.PnlDescriptions = New System.Windows.Forms.Panel()
            Me.ChkExactMatch = New System.Windows.Forms.CheckBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.ChartMonth = New System.Windows.Forms.DataVisualization.Charting.Chart()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.ChartAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.ChartMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ChartAccount
            '
            ChartArea1.Name = "ChartArea1"
            Me.ChartAccount.ChartAreas.Add(ChartArea1)
            Me.ChartAccount.Dock = System.Windows.Forms.DockStyle.Fill
            Legend1.Name = "Legend1"
            Me.ChartAccount.Legends.Add(Legend1)
            Me.ChartAccount.Location = New System.Drawing.Point(3, 3)
            Me.ChartAccount.Name = "ChartAccount"
            Me.ChartAccount.Padding = New System.Windows.Forms.Padding(3)
            Series1.ChartArea = "ChartArea1"
            Series1.Legend = "Legend1"
            Series1.Name = "Series1"
            Me.ChartAccount.Series.Add(Series1)
            Me.ChartAccount.Size = New System.Drawing.Size(760, 455)
            Me.ChartAccount.TabIndex = 5
            Me.ChartAccount.Text = "Chart1"
            '
            'TxtFilter
            '
            Me.TxtFilter.Location = New System.Drawing.Point(45, 29)
            Me.TxtFilter.Name = "TxtFilter"
            Me.TxtFilter.Size = New System.Drawing.Size(192, 22)
            Me.TxtFilter.TabIndex = 6
            '
            'BtnGo
            '
            Me.BtnGo.AutoSize = True
            Me.BtnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnGo.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnGo.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_circle_double_135
            Me.BtnGo.Location = New System.Drawing.Point(422, 27)
            Me.BtnGo.Name = "BtnGo"
            Me.BtnGo.Size = New System.Drawing.Size(48, 23)
            Me.BtnGo.TabIndex = 7
            Me.BtnGo.Text = "Go"
            Me.BtnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnGo.UseVisualStyleBackColor = False
            '
            'PnlDescriptions
            '
            Me.PnlDescriptions.Location = New System.Drawing.Point(44, 3)
            Me.PnlDescriptions.Name = "PnlDescriptions"
            Me.PnlDescriptions.Size = New System.Drawing.Size(426, 20)
            Me.PnlDescriptions.TabIndex = 11
            '
            'ChkExactMatch
            '
            Me.ChkExactMatch.AutoSize = True
            Me.ChkExactMatch.Location = New System.Drawing.Point(244, 31)
            Me.ChkExactMatch.Name = "ChkExactMatch"
            Me.ChkExactMatch.Size = New System.Drawing.Size(87, 17)
            Me.ChkExactMatch.TabIndex = 12
            Me.ChkExactMatch.Text = "Exact Match"
            Me.ChkExactMatch.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.Panel1.Controls.Add(Me.PnlDescriptions)
            Me.Panel1.Controls.Add(Me.ChkExactMatch)
            Me.Panel1.Controls.Add(Me.TxtFilter)
            Me.Panel1.Controls.Add(Me.BtnGo)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(5, 5)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(774, 59)
            Me.Panel1.TabIndex = 13
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(5, 69)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(774, 487)
            Me.TabControl1.TabIndex = 14
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.ChartAccount)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(766, 461)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Per Account"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.ChartMonth)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(766, 461)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Over Time"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'ChartMonth
            '
            ChartArea2.Name = "ChartArea1"
            Me.ChartMonth.ChartAreas.Add(ChartArea2)
            Me.ChartMonth.Dock = System.Windows.Forms.DockStyle.Fill
            Legend2.Name = "Legend1"
            Me.ChartMonth.Legends.Add(Legend2)
            Me.ChartMonth.Location = New System.Drawing.Point(3, 3)
            Me.ChartMonth.Name = "ChartMonth"
            Me.ChartMonth.Padding = New System.Windows.Forms.Padding(3)
            Series2.ChartArea = "ChartArea1"
            Series2.Legend = "Legend1"
            Series2.Name = "Series1"
            Me.ChartMonth.Series.Add(Series2)
            Me.ChartMonth.Size = New System.Drawing.Size(760, 455)
            Me.ChartMonth.TabIndex = 6
            Me.ChartMonth.Text = "Chart1"
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Location = New System.Drawing.Point(5, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(774, 5)
            Me.Label1.TabIndex = 15
            '
            'FInterest
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.ControlDark
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.TabControl1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FInterest"
            Me.Padding = New System.Windows.Forms.Padding(5)
            Me.Text = "Interest"
            CType(Me.ChartAccount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            CType(Me.ChartMonth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents ChartAccount As DataVisualization.Charting.Chart
        Friend WithEvents TxtFilter As TextBox
        Friend WithEvents BtnGo As Button
        Friend WithEvents PnlDescriptions As Panel
        Friend WithEvents ChkExactMatch As CheckBox
        Friend WithEvents Panel1 As Panel
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents Label1 As Label
        Friend WithEvents ChartMonth As DataVisualization.Charting.Chart
    End Class

End Namespace
