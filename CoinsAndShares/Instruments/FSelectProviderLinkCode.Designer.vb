Namespace Instruments

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSelectProviderLinkCode
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FSelectProviderLinkCode))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.GrdCoins = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.BtnSearch = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.TxtFilter = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.GrdCoins, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
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
            Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
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
            Me.BtnOk.Image = CType(resources.GetObject("BtnOk.Image"), System.Drawing.Image)
            Me.BtnOk.Location = New System.Drawing.Point(5, 5)
            Me.BtnOk.Name = "BtnOk"
            Me.BtnOk.Size = New System.Drawing.Size(48, 28)
            Me.BtnOk.TabIndex = 0
            Me.BtnOk.Text = "O&K"
            Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOk.UseVisualStyleBackColor = False
            '
            'GrdCoins
            '
            Me.GrdCoins.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdCoins.Location = New System.Drawing.Point(0, 38)
            Me.GrdCoins.Name = "GrdCoins"
            Me.GrdCoins.Size = New System.Drawing.Size(624, 365)
            Me.GrdCoins.TabIndex = 1
            Me.GrdCoins.Text = "Symbols"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.Controls.Add(Me.BtnSearch)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Controls.Add(Me.TxtFilter)
            Me.Panel2.Controls.Add(Me.Label1)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(0, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(624, 38)
            Me.Panel2.TabIndex = 0
            '
            'BtnSearch
            '
            Me.BtnSearch.AutoSize = True
            Me.BtnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnSearch.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSearch.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnSearch.Image = Global.CoinsAndShares.My.Resources.Resources.binocular
            Me.BtnSearch.Location = New System.Drawing.Point(296, 5)
            Me.BtnSearch.Name = "BtnSearch"
            Me.BtnSearch.Size = New System.Drawing.Size(67, 28)
            Me.BtnSearch.TabIndex = 2
            Me.BtnSearch.Text = "&Search"
            Me.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSearch.UseVisualStyleBackColor = False
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(291, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(5, 28)
            Me.Label2.TabIndex = 3
            '
            'TxtFilter
            '
            Me.TxtFilter.Dock = System.Windows.Forms.DockStyle.Left
            Me.TxtFilter.Location = New System.Drawing.Point(56, 5)
            Me.TxtFilter.Name = "TxtFilter"
            Me.TxtFilter.Size = New System.Drawing.Size(235, 22)
            Me.TxtFilter.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(5, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(10, 5, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(51, 18)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Search"
            '
            'FSelectProviderLinkCode
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.GrdCoins)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FSelectProviderLinkCode"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Set Link Symbol"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.GrdCoins, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents GrdCoins As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel2 As Panel
        Friend WithEvents TxtFilter As TextBox
        Friend WithEvents Label1 As Label
        Friend WithEvents BtnSearch As Button
        Friend WithEvents Label2 As Label
    End Class

End Namespace
