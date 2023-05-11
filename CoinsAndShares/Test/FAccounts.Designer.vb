Namespace Test
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccounts
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
            Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Me.GrdAccounts = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            Me.ChkIncludeZero = New System.Windows.Forms.CheckBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnOpenAccount = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnFiatTransfer = New System.Windows.Forms.Button()
            CType(Me.GrdAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdAccounts
            '
            Appearance1.BackColor = System.Drawing.Color.SlateGray
            Me.GrdAccounts.DisplayLayout.Appearance = Appearance1
            Me.GrdAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdAccounts.Location = New System.Drawing.Point(0, 38)
            Me.GrdAccounts.Name = "GrdAccounts"
            Me.GrdAccounts.Size = New System.Drawing.Size(784, 523)
            Me.GrdAccounts.TabIndex = 2
            Me.GrdAccounts.Text = "Accounts"
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
            Me.BtnRefresh.TabIndex = 3
            Me.BtnRefresh.Text = "Refresh"
            Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnRefresh.UseVisualStyleBackColor = False
            '
            'ChkIncludeZero
            '
            Me.ChkIncludeZero.AutoSize = True
            Me.ChkIncludeZero.Dock = System.Windows.Forms.DockStyle.Left
            Me.ChkIncludeZero.Location = New System.Drawing.Point(77, 5)
            Me.ChkIncludeZero.Name = "ChkIncludeZero"
            Me.ChkIncludeZero.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
            Me.ChkIncludeZero.Size = New System.Drawing.Size(187, 28)
            Me.ChkIncludeZero.TabIndex = 4
            Me.ChkIncludeZero.Text = "Include Zero Balance Accounts"
            Me.ChkIncludeZero.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnOpenAccount)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnFiatTransfer)
            Me.Panel1.Controls.Add(Me.ChkIncludeZero)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 5
            '
            'BtnOpenAccount
            '
            Me.BtnOpenAccount.AutoSize = True
            Me.BtnOpenAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnOpenAccount.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnOpenAccount.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnOpenAccount.Image = Global.CoinsAndShares.My.Resources.Resources.blue_folder_open
            Me.BtnOpenAccount.Location = New System.Drawing.Point(367, 5)
            Me.BtnOpenAccount.Name = "BtnOpenAccount"
            Me.BtnOpenAccount.Size = New System.Drawing.Size(107, 28)
            Me.BtnOpenAccount.TabIndex = 6
            Me.BtnOpenAccount.Text = "Open Account"
            Me.BtnOpenAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOpenAccount.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(362, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 28)
            Me.Label1.TabIndex = 7
            '
            'BtnFiatTransfer
            '
            Me.BtnFiatTransfer.AutoSize = True
            Me.BtnFiatTransfer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnFiatTransfer.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnFiatTransfer.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnFiatTransfer.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_resize
            Me.BtnFiatTransfer.Location = New System.Drawing.Point(264, 5)
            Me.BtnFiatTransfer.Name = "BtnFiatTransfer"
            Me.BtnFiatTransfer.Size = New System.Drawing.Size(98, 28)
            Me.BtnFiatTransfer.TabIndex = 5
            Me.BtnFiatTransfer.Text = "FIAT Transfer"
            Me.BtnFiatTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnFiatTransfer.UseVisualStyleBackColor = False
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
        Friend WithEvents BtnRefresh As Button
        Friend WithEvents ChkIncludeZero As CheckBox
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnFiatTransfer As Button
        Friend WithEvents BtnOpenAccount As Button
        Friend WithEvents Label1 As Label
    End Class
End Namespace

