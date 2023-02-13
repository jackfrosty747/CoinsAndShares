Namespace Networks
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FNetworks
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.GrdNetworks = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1.SuspendLayout()
            CType(Me.GrdNetworks, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnCancel)
            Me.Panel1.Controls.Add(Me.BtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 223)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(384, 38)
            Me.Panel1.TabIndex = 0
            '
            'BtnCancel
            '
            Me.BtnCancel.AutoSize = True
            Me.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancel.Image = Global.CoinsAndShares.My.Resources.Resources.cross_circle_frame
            Me.BtnCancel.Location = New System.Drawing.Point(312, 5)
            Me.BtnCancel.Name = "BtnCancel"
            Me.BtnCancel.Size = New System.Drawing.Size(67, 28)
            Me.BtnCancel.TabIndex = 2
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
            Me.BtnOk.TabIndex = 1
            Me.BtnOk.Text = "O&K"
            Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOk.UseVisualStyleBackColor = False
            '
            'GrdNetworks
            '
            Me.GrdNetworks.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdNetworks.Location = New System.Drawing.Point(0, 0)
            Me.GrdNetworks.Name = "GrdNetworks"
            Me.GrdNetworks.Size = New System.Drawing.Size(384, 223)
            Me.GrdNetworks.TabIndex = 5
            Me.GrdNetworks.Text = "Networks"
            '
            'FNetworks
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(384, 261)
            Me.Controls.Add(Me.GrdNetworks)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FNetworks"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Networks"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.GrdNetworks, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnOk As Button
        Friend WithEvents BtnCancel As Button
        Friend WithEvents GrdNetworks As Infragistics.Win.UltraWinGrid.UltraGrid
    End Class

End Namespace
