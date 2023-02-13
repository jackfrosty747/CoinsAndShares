Namespace Dashboard

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UHoldings
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.BtnUpdateCryptoRates = New System.Windows.Forms.Button()
            Me.PnlHeader = New System.Windows.Forms.Panel()
            Me.Cms = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.MnuSetRate = New System.Windows.Forms.ToolStripMenuItem()
            Me.MnuEditInstrument = New System.Windows.Forms.ToolStripMenuItem()
            Me.PnlHeader.SuspendLayout()
            Me.Cms.SuspendLayout()
            Me.SuspendLayout()
            '
            'BtnUpdateCryptoRates
            '
            Me.BtnUpdateCryptoRates.AutoSize = True
            Me.BtnUpdateCryptoRates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnUpdateCryptoRates.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnUpdateCryptoRates.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnUpdateCryptoRates.Image = Global.CoinsAndShares.My.Resources.Resources.globe
            Me.BtnUpdateCryptoRates.Location = New System.Drawing.Point(5, 5)
            Me.BtnUpdateCryptoRates.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.BtnUpdateCryptoRates.Name = "BtnUpdateCryptoRates"
            Me.BtnUpdateCryptoRates.Size = New System.Drawing.Size(139, 28)
            Me.BtnUpdateCryptoRates.TabIndex = 4
            Me.BtnUpdateCryptoRates.Text = "Update Crypto Rates"
            Me.BtnUpdateCryptoRates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnUpdateCryptoRates.UseVisualStyleBackColor = False
            '
            'PnlHeader
            '
            Me.PnlHeader.BackColor = System.Drawing.Color.White
            Me.PnlHeader.Controls.Add(Me.BtnUpdateCryptoRates)
            Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.PnlHeader.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.PnlHeader.Name = "PnlHeader"
            Me.PnlHeader.Padding = New System.Windows.Forms.Padding(5)
            Me.PnlHeader.Size = New System.Drawing.Size(298, 38)
            Me.PnlHeader.TabIndex = 6
            '
            'Cms
            '
            Me.Cms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuSetRate, Me.MnuEditInstrument})
            Me.Cms.Name = "ContextMenuStrip1"
            Me.Cms.Size = New System.Drawing.Size(156, 48)
            '
            'MnuSetRate
            '
            Me.MnuSetRate.Name = "MnuSetRate"
            Me.MnuSetRate.Size = New System.Drawing.Size(155, 22)
            Me.MnuSetRate.Text = "Set Rate"
            '
            'MnuEditInstrument
            '
            Me.MnuEditInstrument.Name = "MnuEditInstrument"
            Me.MnuEditInstrument.Size = New System.Drawing.Size(155, 22)
            Me.MnuEditInstrument.Text = "Edit Instrument"
            '
            'UHoldings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.Name = "UHoldings"
            Me.Size = New System.Drawing.Size(298, 506)
            Me.PnlHeader.ResumeLayout(False)
            Me.PnlHeader.PerformLayout()
            Me.Cms.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents BtnUpdateCryptoRates As Button
        Friend WithEvents PnlHeader As Panel
        Friend WithEvents Cms As ContextMenuStrip
        Friend WithEvents MnuSetRate As ToolStripMenuItem
        Friend WithEvents MnuEditInstrument As ToolStripMenuItem
    End Class

End Namespace

