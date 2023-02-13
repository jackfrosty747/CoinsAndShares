Namespace Electricity
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FElectricity
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FElectricity))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.GrdElectricityItems = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.GrdElectricityItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.Panel1.TabIndex = 3
            '
            'BtnCancel
            '
            Me.BtnCancel.AutoSize = True
            Me.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
            Me.BtnCancel.Location = New System.Drawing.Point(312, 5)
            Me.BtnCancel.Name = "BtnCancel"
            Me.BtnCancel.Size = New System.Drawing.Size(67, 28)
            Me.BtnCancel.TabIndex = 7
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
            Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
            Me.BtnOk.Location = New System.Drawing.Point(5, 5)
            Me.BtnOk.Name = "BtnOk"
            Me.BtnOk.Size = New System.Drawing.Size(48, 28)
            Me.BtnOk.TabIndex = 6
            Me.BtnOk.Text = "O&K"
            Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOk.UseVisualStyleBackColor = False
            '
            'GrdElectricityItems
            '
            Me.GrdElectricityItems.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdElectricityItems.Location = New System.Drawing.Point(0, 23)
            Me.GrdElectricityItems.Name = "GrdElectricityItems"
            Me.GrdElectricityItems.Size = New System.Drawing.Size(384, 200)
            Me.GrdElectricityItems.TabIndex = 5
            Me.GrdElectricityItems.Text = "Electricity Rates - Estimated Usage Per Day"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(5)
            Me.Label1.Size = New System.Drawing.Size(198, 23)
            Me.Label1.TabIndex = 6
            Me.Label1.Text = "Used for mining profitability report"
            '
            'FElectricity
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(384, 261)
            Me.Controls.Add(Me.GrdElectricityItems)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FElectricity"
            Me.Text = "Electricity Rates"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.GrdElectricityItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents GrdElectricityItems As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Label1 As Label
    End Class

End Namespace
