Namespace Rates
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSharePriceScraper
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
            Me.GrdInstruments = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnStop = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.BtnScrape = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.BtnCommit = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            CType(Me.GrdInstruments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdInstruments
            '
            Me.GrdInstruments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdInstruments.Location = New System.Drawing.Point(0, 0)
            Me.GrdInstruments.Name = "GrdInstruments"
            Me.GrdInstruments.Size = New System.Drawing.Size(784, 523)
            Me.GrdInstruments.TabIndex = 1
            Me.GrdInstruments.Text = "Instruments"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnStop)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.BtnScrape)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.BtnCommit)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 523)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 2
            '
            'BtnStop
            '
            Me.BtnStop.AutoSize = True
            Me.BtnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnStop.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnStop.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnStop.Image = Global.CoinsAndShares.My.Resources.Resources.cross_script
            Me.BtnStop.Location = New System.Drawing.Point(231, 5)
            Me.BtnStop.Name = "BtnStop"
            Me.BtnStop.Size = New System.Drawing.Size(57, 28)
            Me.BtnStop.TabIndex = 6
            Me.BtnStop.Text = "Stop"
            Me.BtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnStop.UseVisualStyleBackColor = False
            '
            'Label3
            '
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(226, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(5, 28)
            Me.Label3.TabIndex = 5
            '
            'BtnScrape
            '
            Me.BtnScrape.AutoSize = True
            Me.BtnScrape.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnScrape.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnScrape.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnScrape.Image = Global.CoinsAndShares.My.Resources.Resources.wand
            Me.BtnScrape.Location = New System.Drawing.Point(159, 5)
            Me.BtnScrape.Name = "BtnScrape"
            Me.BtnScrape.Size = New System.Drawing.Size(67, 28)
            Me.BtnScrape.TabIndex = 4
            Me.BtnScrape.Text = "Scrape"
            Me.BtnScrape.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnScrape.UseVisualStyleBackColor = False
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(154, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(5, 28)
            Me.Label2.TabIndex = 3
            '
            'BtnCommit
            '
            Me.BtnCommit.AutoSize = True
            Me.BtnCommit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCommit.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCommit.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnCommit.Image = Global.CoinsAndShares.My.Resources.Resources.disk
            Me.BtnCommit.Location = New System.Drawing.Point(82, 5)
            Me.BtnCommit.Name = "BtnCommit"
            Me.BtnCommit.Size = New System.Drawing.Size(72, 28)
            Me.BtnCommit.TabIndex = 2
            Me.BtnCommit.Text = "Commit"
            Me.BtnCommit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnCommit.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(77, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 28)
            Me.Label1.TabIndex = 1
            '
            'BtnRefresh
            '
            Me.BtnRefresh.AutoSize = True
            Me.BtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnRefresh.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_circle_double_135
            Me.BtnRefresh.Location = New System.Drawing.Point(5, 5)
            Me.BtnRefresh.Name = "BtnRefresh"
            Me.BtnRefresh.Size = New System.Drawing.Size(72, 28)
            Me.BtnRefresh.TabIndex = 0
            Me.BtnRefresh.Text = "Refresh"
            Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnRefresh.UseVisualStyleBackColor = False
            '
            'FSharePriceScraper
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.GrdInstruments)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FSharePriceScraper"
            Me.Text = "Share Price Scraper"
            CType(Me.GrdInstruments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GrdInstruments As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnRefresh As Button
        Friend WithEvents BtnCommit As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents BtnScrape As Button
        Friend WithEvents Label2 As Label
        Friend WithEvents BtnStop As Button
        Friend WithEvents Label3 As Label
    End Class
End Namespace
