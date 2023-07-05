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
            Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Me.GrdAccounts = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            Me.ChkIncludeZero = New System.Windows.Forms.CheckBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnNew = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.BtnFiatTransfer = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnOpenAccount = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.BtnDelete = New System.Windows.Forms.Button()
            CType(Me.GrdAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdAccounts
            '
            Appearance2.BackColor = System.Drawing.Color.SlateGray
            Me.GrdAccounts.DisplayLayout.Appearance = Appearance2
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
            Me.Panel1.Controls.Add(Me.BtnDelete)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.BtnNew)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.BtnFiatTransfer)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnOpenAccount)
            Me.Panel1.Controls.Add(Me.ChkIncludeZero)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 5
            '
            'BtnNew
            '
            Me.BtnNew.AutoSize = True
            Me.BtnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnNew.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnNew.Image = Global.CoinsAndShares.My.Resources.Resources.wand
            Me.BtnNew.Location = New System.Drawing.Point(434, 5)
            Me.BtnNew.Name = "BtnNew"
            Me.BtnNew.Size = New System.Drawing.Size(56, 28)
            Me.BtnNew.TabIndex = 9
            Me.BtnNew.Text = "New"
            Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnNew.UseVisualStyleBackColor = False
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(429, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(5, 28)
            Me.Label2.TabIndex = 8
            '
            'BtnFiatTransfer
            '
            Me.BtnFiatTransfer.AutoSize = True
            Me.BtnFiatTransfer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnFiatTransfer.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnFiatTransfer.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnFiatTransfer.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_resize
            Me.BtnFiatTransfer.Location = New System.Drawing.Point(331, 5)
            Me.BtnFiatTransfer.Name = "BtnFiatTransfer"
            Me.BtnFiatTransfer.Size = New System.Drawing.Size(98, 28)
            Me.BtnFiatTransfer.TabIndex = 5
            Me.BtnFiatTransfer.Text = "FIAT Transfer"
            Me.BtnFiatTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnFiatTransfer.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(326, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 28)
            Me.Label1.TabIndex = 7
            '
            'BtnOpenAccount
            '
            Me.BtnOpenAccount.AutoSize = True
            Me.BtnOpenAccount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnOpenAccount.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnOpenAccount.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnOpenAccount.Image = Global.CoinsAndShares.My.Resources.Resources.blue_folder_open
            Me.BtnOpenAccount.Location = New System.Drawing.Point(264, 5)
            Me.BtnOpenAccount.Name = "BtnOpenAccount"
            Me.BtnOpenAccount.Size = New System.Drawing.Size(62, 28)
            Me.BtnOpenAccount.TabIndex = 6
            Me.BtnOpenAccount.Text = "Open"
            Me.BtnOpenAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOpenAccount.UseVisualStyleBackColor = False
            '
            'Label3
            '
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(490, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(5, 28)
            Me.Label3.TabIndex = 10
            '
            'BtnDelete
            '
            Me.BtnDelete.AutoSize = True
            Me.BtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnDelete.Image = Global.CoinsAndShares.My.Resources.Resources.cross_script
            Me.BtnDelete.Location = New System.Drawing.Point(495, 5)
            Me.BtnDelete.Name = "BtnDelete"
            Me.BtnDelete.Size = New System.Drawing.Size(66, 28)
            Me.BtnDelete.TabIndex = 11
            Me.BtnDelete.Text = "Delete"
            Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnDelete.UseVisualStyleBackColor = False
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
        Friend WithEvents BtnNew As Button
        Friend WithEvents Label2 As Label
        Friend WithEvents BtnDelete As Button
        Friend WithEvents Label3 As Label
    End Class
End Namespace

