Namespace Accounts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAccountList
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
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.ChkShowZero = New System.Windows.Forms.CheckBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.BtnTransferCrypto = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.LblGrandTotal = New System.Windows.Forms.Label()
            Me.BtnTransferFiat = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.BtnDelete = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.BtnEdit = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnNew = New System.Windows.Forms.Button()
            CType(Me.GrdAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdAccounts
            '
            Appearance1.BackColor = System.Drawing.Color.Silver
            Me.GrdAccounts.DisplayLayout.Appearance = Appearance1
            Me.GrdAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdAccounts.Location = New System.Drawing.Point(0, 0)
            Me.GrdAccounts.Name = "GrdAccounts"
            Me.GrdAccounts.Size = New System.Drawing.Size(784, 523)
            Me.GrdAccounts.TabIndex = 1
            Me.GrdAccounts.Text = "Accounts"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.ChkShowZero)
            Me.Panel1.Controls.Add(Me.Label7)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.BtnTransferCrypto)
            Me.Panel1.Controls.Add(Me.Label6)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.LblGrandTotal)
            Me.Panel1.Controls.Add(Me.BtnTransferFiat)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.BtnDelete)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.BtnEdit)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnNew)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 523)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 2
            '
            'ChkShowZero
            '
            Me.ChkShowZero.AutoSize = True
            Me.ChkShowZero.Dock = System.Windows.Forms.DockStyle.Left
            Me.ChkShowZero.Location = New System.Drawing.Point(402, 5)
            Me.ChkShowZero.Name = "ChkShowZero"
            Me.ChkShowZero.Size = New System.Drawing.Size(81, 28)
            Me.ChkShowZero.TabIndex = 3
            Me.ChkShowZero.Text = "Show Zero"
            Me.ChkShowZero.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label7.Location = New System.Drawing.Point(397, 5)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(5, 28)
            Me.Label7.TabIndex = 15
            '
            'BtnRefresh
            '
            Me.BtnRefresh.AutoSize = True
            Me.BtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnRefresh.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_circle_double_135
            Me.BtnRefresh.Location = New System.Drawing.Point(325, 5)
            Me.BtnRefresh.Name = "BtnRefresh"
            Me.BtnRefresh.Size = New System.Drawing.Size(72, 28)
            Me.BtnRefresh.TabIndex = 10
            Me.BtnRefresh.Text = "Refresh"
            Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnRefresh.UseVisualStyleBackColor = False
            '
            'Label4
            '
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(320, 5)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(5, 28)
            Me.Label4.TabIndex = 9
            '
            'BtnTransferCrypto
            '
            Me.BtnTransferCrypto.AutoSize = True
            Me.BtnTransferCrypto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnTransferCrypto.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnTransferCrypto.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnTransferCrypto.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_resize
            Me.BtnTransferCrypto.Location = New System.Drawing.Point(253, 5)
            Me.BtnTransferCrypto.Name = "BtnTransferCrypto"
            Me.BtnTransferCrypto.Size = New System.Drawing.Size(67, 28)
            Me.BtnTransferCrypto.TabIndex = 14
            Me.BtnTransferCrypto.Text = "Crypto"
            Me.BtnTransferCrypto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnTransferCrypto.UseVisualStyleBackColor = False
            '
            'Label6
            '
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label6.Location = New System.Drawing.Point(248, 5)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(5, 28)
            Me.Label6.TabIndex = 13
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Right
            Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(664, 5)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
            Me.Label5.Size = New System.Drawing.Size(35, 21)
            Me.Label5.TabIndex = 12
            Me.Label5.Text = "Total:"
            '
            'LblGrandTotal
            '
            Me.LblGrandTotal.AutoSize = True
            Me.LblGrandTotal.Dock = System.Windows.Forms.DockStyle.Right
            Me.LblGrandTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblGrandTotal.ForeColor = System.Drawing.Color.Blue
            Me.LblGrandTotal.Location = New System.Drawing.Point(699, 5)
            Me.LblGrandTotal.Name = "LblGrandTotal"
            Me.LblGrandTotal.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
            Me.LblGrandTotal.Size = New System.Drawing.Size(80, 21)
            Me.LblGrandTotal.TabIndex = 11
            Me.LblGrandTotal.Text = "LblGrandTotal"
            '
            'BtnTransferFiat
            '
            Me.BtnTransferFiat.AutoSize = True
            Me.BtnTransferFiat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnTransferFiat.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnTransferFiat.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnTransferFiat.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_resize
            Me.BtnTransferFiat.Location = New System.Drawing.Point(195, 5)
            Me.BtnTransferFiat.Name = "BtnTransferFiat"
            Me.BtnTransferFiat.Size = New System.Drawing.Size(53, 28)
            Me.BtnTransferFiat.TabIndex = 8
            Me.BtnTransferFiat.Text = "FIAT"
            Me.BtnTransferFiat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnTransferFiat.UseVisualStyleBackColor = False
            '
            'Label3
            '
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(190, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(5, 28)
            Me.Label3.TabIndex = 7
            '
            'BtnDelete
            '
            Me.BtnDelete.AutoSize = True
            Me.BtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnDelete.Image = Global.CoinsAndShares.My.Resources.Resources.cross_script
            Me.BtnDelete.Location = New System.Drawing.Point(124, 5)
            Me.BtnDelete.Name = "BtnDelete"
            Me.BtnDelete.Size = New System.Drawing.Size(66, 28)
            Me.BtnDelete.TabIndex = 6
            Me.BtnDelete.Text = "Delete"
            Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnDelete.UseVisualStyleBackColor = False
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(119, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(5, 28)
            Me.Label2.TabIndex = 5
            '
            'BtnEdit
            '
            Me.BtnEdit.AutoSize = True
            Me.BtnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnEdit.Image = Global.CoinsAndShares.My.Resources.Resources.blue_folder_open
            Me.BtnEdit.Location = New System.Drawing.Point(66, 5)
            Me.BtnEdit.Name = "BtnEdit"
            Me.BtnEdit.Size = New System.Drawing.Size(53, 28)
            Me.BtnEdit.TabIndex = 3
            Me.BtnEdit.Text = "Edit"
            Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnEdit.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(61, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 28)
            Me.Label1.TabIndex = 4
            '
            'BtnNew
            '
            Me.BtnNew.AutoSize = True
            Me.BtnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnNew.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnNew.Image = Global.CoinsAndShares.My.Resources.Resources._new
            Me.BtnNew.Location = New System.Drawing.Point(5, 5)
            Me.BtnNew.Name = "BtnNew"
            Me.BtnNew.Size = New System.Drawing.Size(56, 28)
            Me.BtnNew.TabIndex = 2
            Me.BtnNew.Text = "New"
            Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnNew.UseVisualStyleBackColor = False
            '
            'FAccountList
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.GrdAccounts)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FAccountList"
            Me.Text = "Accounts"
            CType(Me.GrdAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GrdAccounts As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnNew As Button
        Friend WithEvents BtnEdit As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents BtnDelete As Button
        Friend WithEvents Label2 As Label
        Friend WithEvents BtnTransferFiat As Button
        Friend WithEvents Label3 As Label
        Friend WithEvents BtnRefresh As Button
        Friend WithEvents Label4 As Label
        Friend WithEvents Label5 As Label
        Friend WithEvents LblGrandTotal As Label
        Friend WithEvents BtnTransferCrypto As Button
        Friend WithEvents Label6 As Label
        Friend WithEvents ChkShowZero As CheckBox
        Friend WithEvents Label7 As Label
    End Class

End Namespace
