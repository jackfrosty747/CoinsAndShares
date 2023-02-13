Namespace Dashboard
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UCurrency
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
            Me.BtnUpdateCurrencyRates = New System.Windows.Forms.Button()
            Me.PnlControl = New System.Windows.Forms.Panel()
            Me.PnlControl.SuspendLayout()
            Me.SuspendLayout()
            '
            'BtnUpdateCurrencyRates
            '
            Me.BtnUpdateCurrencyRates.AutoSize = True
            Me.BtnUpdateCurrencyRates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnUpdateCurrencyRates.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnUpdateCurrencyRates.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnUpdateCurrencyRates.Image = Global.CoinsAndShares.My.Resources.Resources.globe
            Me.BtnUpdateCurrencyRates.Location = New System.Drawing.Point(5, 5)
            Me.BtnUpdateCurrencyRates.Name = "BtnUpdateCurrencyRates"
            Me.BtnUpdateCurrencyRates.Size = New System.Drawing.Size(150, 28)
            Me.BtnUpdateCurrencyRates.TabIndex = 3
            Me.BtnUpdateCurrencyRates.Text = "Update Currency Rates"
            Me.BtnUpdateCurrencyRates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnUpdateCurrencyRates.UseVisualStyleBackColor = False
            '
            'PnlControl
            '
            Me.PnlControl.BackColor = System.Drawing.Color.White
            Me.PnlControl.Controls.Add(Me.BtnUpdateCurrencyRates)
            Me.PnlControl.Dock = System.Windows.Forms.DockStyle.Top
            Me.PnlControl.Location = New System.Drawing.Point(0, 0)
            Me.PnlControl.Name = "PnlControl"
            Me.PnlControl.Padding = New System.Windows.Forms.Padding(5)
            Me.PnlControl.Size = New System.Drawing.Size(293, 38)
            Me.PnlControl.TabIndex = 4
            '
            'UCurrency
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.Controls.Add(Me.PnlControl)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "UCurrency"
            Me.Size = New System.Drawing.Size(293, 302)
            Me.PnlControl.ResumeLayout(False)
            Me.PnlControl.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents BtnUpdateCurrencyRates As Button
        Friend WithEvents PnlControl As Panel
    End Class

End Namespace

