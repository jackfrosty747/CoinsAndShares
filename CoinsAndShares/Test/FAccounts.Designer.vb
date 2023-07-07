Imports MaterialSkin.Controls

Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccounts
        Inherits MaterialForm

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
            Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Me.GrdAccounts = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.MBtnFiatTransfer = New MaterialSkin.Controls.MaterialButton()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.MBtnRename = New MaterialSkin.Controls.MaterialButton()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.MBtnDelete = New MaterialSkin.Controls.MaterialButton()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.MBtnNew = New MaterialSkin.Controls.MaterialButton()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.MBtnOpen = New MaterialSkin.Controls.MaterialButton()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.MBtnRefresh = New MaterialSkin.Controls.MaterialButton()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.MChkZero = New MaterialSkin.Controls.MaterialSwitch()
            CType(Me.GrdAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdAccounts
            '
            Appearance2.BackColor = System.Drawing.Color.SlateGray
            Me.GrdAccounts.DisplayLayout.Appearance = Appearance2
            Me.GrdAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdAccounts.Location = New System.Drawing.Point(3, 109)
            Me.GrdAccounts.Name = "GrdAccounts"
            Me.GrdAccounts.Size = New System.Drawing.Size(778, 449)
            Me.GrdAccounts.TabIndex = 1
            Me.GrdAccounts.Text = "Accounts"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.MBtnFiatTransfer)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.MBtnRename)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.MBtnDelete)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.MBtnNew)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.MBtnOpen)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.MBtnRefresh)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.MChkZero)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(3, 64)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(778, 45)
            Me.Panel1.TabIndex = 0
            '
            'MBtnFiatTransfer
            '
            Me.MBtnFiatTransfer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnFiatTransfer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnFiatTransfer.Depth = 0
            Me.MBtnFiatTransfer.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnFiatTransfer.HighEmphasis = True
            Me.MBtnFiatTransfer.Icon = Nothing
            Me.MBtnFiatTransfer.Location = New System.Drawing.Point(585, 5)
            Me.MBtnFiatTransfer.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnFiatTransfer.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnFiatTransfer.Name = "MBtnFiatTransfer"
            Me.MBtnFiatTransfer.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnFiatTransfer.Size = New System.Drawing.Size(129, 35)
            Me.MBtnFiatTransfer.TabIndex = 6
            Me.MBtnFiatTransfer.Text = "FIAT Transfer"
            Me.MBtnFiatTransfer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnFiatTransfer.UseAccentColor = False
            Me.MBtnFiatTransfer.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(580, 5)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(5, 35)
            Me.Label4.TabIndex = 12
            '
            'MBtnRename
            '
            Me.MBtnRename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnRename.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnRename.Depth = 0
            Me.MBtnRename.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnRename.HighEmphasis = True
            Me.MBtnRename.Icon = Nothing
            Me.MBtnRename.Location = New System.Drawing.Point(500, 5)
            Me.MBtnRename.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnRename.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnRename.Name = "MBtnRename"
            Me.MBtnRename.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnRename.Size = New System.Drawing.Size(80, 35)
            Me.MBtnRename.TabIndex = 5
            Me.MBtnRename.Text = "Rename"
            Me.MBtnRename.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnRename.UseAccentColor = False
            Me.MBtnRename.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(495, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(5, 35)
            Me.Label3.TabIndex = 10
            '
            'MBtnDelete
            '
            Me.MBtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnDelete.Depth = 0
            Me.MBtnDelete.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnDelete.HighEmphasis = True
            Me.MBtnDelete.Icon = Nothing
            Me.MBtnDelete.Location = New System.Drawing.Point(422, 5)
            Me.MBtnDelete.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnDelete.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnDelete.Name = "MBtnDelete"
            Me.MBtnDelete.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnDelete.Size = New System.Drawing.Size(73, 35)
            Me.MBtnDelete.TabIndex = 4
            Me.MBtnDelete.Text = "Delete"
            Me.MBtnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnDelete.UseAccentColor = False
            Me.MBtnDelete.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(417, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 35)
            Me.Label1.TabIndex = 7
            '
            'MBtnNew
            '
            Me.MBtnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnNew.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnNew.Depth = 0
            Me.MBtnNew.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnNew.HighEmphasis = True
            Me.MBtnNew.Icon = Nothing
            Me.MBtnNew.Location = New System.Drawing.Point(353, 5)
            Me.MBtnNew.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnNew.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnNew.Name = "MBtnNew"
            Me.MBtnNew.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnNew.Size = New System.Drawing.Size(64, 35)
            Me.MBtnNew.TabIndex = 3
            Me.MBtnNew.Text = "New"
            Me.MBtnNew.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnNew.UseAccentColor = False
            Me.MBtnNew.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(348, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(5, 35)
            Me.Label2.TabIndex = 8
            '
            'MBtnOpen
            '
            Me.MBtnOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnOpen.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnOpen.Depth = 0
            Me.MBtnOpen.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnOpen.HighEmphasis = True
            Me.MBtnOpen.Icon = Nothing
            Me.MBtnOpen.Location = New System.Drawing.Point(284, 5)
            Me.MBtnOpen.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnOpen.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnOpen.Name = "MBtnOpen"
            Me.MBtnOpen.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnOpen.Size = New System.Drawing.Size(64, 35)
            Me.MBtnOpen.TabIndex = 2
            Me.MBtnOpen.Text = "Open"
            Me.MBtnOpen.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnOpen.UseAccentColor = False
            Me.MBtnOpen.UseVisualStyleBackColor = True
            '
            'Label5
            '
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label5.Location = New System.Drawing.Point(279, 5)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(5, 35)
            Me.Label5.TabIndex = 16
            '
            'MBtnRefresh
            '
            Me.MBtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.MBtnRefresh.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.[Default]
            Me.MBtnRefresh.Depth = 0
            Me.MBtnRefresh.Dock = System.Windows.Forms.DockStyle.Left
            Me.MBtnRefresh.HighEmphasis = True
            Me.MBtnRefresh.Icon = Nothing
            Me.MBtnRefresh.Location = New System.Drawing.Point(195, 5)
            Me.MBtnRefresh.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
            Me.MBtnRefresh.MouseState = MaterialSkin.MouseState.HOVER
            Me.MBtnRefresh.Name = "MBtnRefresh"
            Me.MBtnRefresh.NoAccentTextColor = System.Drawing.Color.Empty
            Me.MBtnRefresh.Size = New System.Drawing.Size(84, 35)
            Me.MBtnRefresh.TabIndex = 1
            Me.MBtnRefresh.Text = "Refresh"
            Me.MBtnRefresh.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
            Me.MBtnRefresh.UseAccentColor = False
            Me.MBtnRefresh.UseVisualStyleBackColor = True
            '
            'Label6
            '
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label6.Location = New System.Drawing.Point(190, 5)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(5, 35)
            Me.Label6.TabIndex = 23
            '
            'MChkZero
            '
            Me.MChkZero.AutoSize = True
            Me.MChkZero.Depth = 0
            Me.MChkZero.Dock = System.Windows.Forms.DockStyle.Left
            Me.MChkZero.Location = New System.Drawing.Point(5, 5)
            Me.MChkZero.Margin = New System.Windows.Forms.Padding(0)
            Me.MChkZero.MouseLocation = New System.Drawing.Point(-1, -1)
            Me.MChkZero.MouseState = MaterialSkin.MouseState.HOVER
            Me.MChkZero.Name = "MChkZero"
            Me.MChkZero.Ripple = True
            Me.MChkZero.Size = New System.Drawing.Size(185, 35)
            Me.MChkZero.TabIndex = 0
            Me.MChkZero.Text = "Inc Zero Accounts"
            Me.MChkZero.UseVisualStyleBackColor = True
            '
            'FAccounts
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.GrdAccounts)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FAccounts"
            Me.Text = "Accounts"
            CType(Me.GrdAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GrdAccounts As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel1 As Panel
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents Label4 As Label
        Friend WithEvents MBtnRefresh As MaterialButton
        Friend WithEvents MBtnOpen As MaterialButton
        Friend WithEvents Label5 As Label
        Friend WithEvents MChkZero As MaterialSwitch
        Friend WithEvents MBtnNew As MaterialButton
        Friend WithEvents MBtnDelete As MaterialButton
        Friend WithEvents MBtnRename As MaterialButton
        Friend WithEvents MBtnFiatTransfer As MaterialButton
        Friend WithEvents Label6 As Label
    End Class
End Namespace

