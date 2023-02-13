Namespace Currencies
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FCurrencies
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
            Me.GrdCurrencies = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnUpdate = New System.Windows.Forms.Button()
            CType(Me.GrdCurrencies, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdCurrencies
            '
            Me.GrdCurrencies.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdCurrencies.Location = New System.Drawing.Point(0, 0)
            Me.GrdCurrencies.Name = "GrdCurrencies"
            Me.GrdCurrencies.Size = New System.Drawing.Size(384, 223)
            Me.GrdCurrencies.TabIndex = 1
            Me.GrdCurrencies.Text = "Currencies"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnUpdate)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 223)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(384, 38)
            Me.Panel1.TabIndex = 2
            '
            'BtnUpdate
            '
            Me.BtnUpdate.AutoSize = True
            Me.BtnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnUpdate.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnUpdate.Image = Global.CoinsAndShares.My.Resources.Resources.globe
            Me.BtnUpdate.Location = New System.Drawing.Point(5, 5)
            Me.BtnUpdate.Name = "BtnUpdate"
            Me.BtnUpdate.Size = New System.Drawing.Size(88, 28)
            Me.BtnUpdate.TabIndex = 0
            Me.BtnUpdate.Text = "BtnUpdate"
            Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnUpdate.UseVisualStyleBackColor = False
            '
            'FCurrencies
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(384, 261)
            Me.Controls.Add(Me.GrdCurrencies)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FCurrencies"
            Me.Text = "Currencies"
            CType(Me.GrdCurrencies, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GrdCurrencies As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnUpdate As Button
    End Class

End Namespace
