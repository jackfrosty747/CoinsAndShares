Namespace Maintenance
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FMaintenance
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
            Me.Label3 = New System.Windows.Forms.Label()
            Me.CmbTransType = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.CmbAccount = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnGo = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.CmbTransType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.BtnGo)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.CmbTransType)
            Me.Panel1.Controls.Add(Me.CmbAccount)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Location = New System.Drawing.Point(28, 40)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(565, 201)
            Me.Panel1.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(39, 109)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(30, 13)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Type"
            '
            'CmbTransType
            '
            Me.CmbTransType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbTransType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbTransType.DisplayMember = ""
            Me.CmbTransType.Location = New System.Drawing.Point(119, 100)
            Me.CmbTransType.Name = "CmbTransType"
            Me.CmbTransType.Size = New System.Drawing.Size(146, 22)
            Me.CmbTransType.TabIndex = 9
            Me.CmbTransType.ValueMember = ""
            '
            'CmbAccount
            '
            Me.CmbAccount.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccount.DisplayMember = ""
            Me.CmbAccount.Location = New System.Drawing.Point(119, 72)
            Me.CmbAccount.Name = "CmbAccount"
            Me.CmbAccount.Size = New System.Drawing.Size(146, 22)
            Me.CmbAccount.TabIndex = 8
            Me.CmbAccount.ValueMember = ""
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(39, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(49, 13)
            Me.Label2.TabIndex = 1
            Me.Label2.Text = "Account"
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(565, 71)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Combine multiple records into a single one for each month, reducing the number of" &
    " transactions to speed up the program when there are large numbers of transactio" &
    "ns"
            '
            'BtnGo
            '
            Me.BtnGo.AutoSize = True
            Me.BtnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnGo.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnGo.Image = Global.CoinsAndShares.My.Resources.Resources.wand
            Me.BtnGo.Location = New System.Drawing.Point(215, 144)
            Me.BtnGo.Name = "BtnGo"
            Me.BtnGo.Size = New System.Drawing.Size(50, 23)
            Me.BtnGo.TabIndex = 11
            Me.BtnGo.Text = "GO"
            Me.BtnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnGo.UseVisualStyleBackColor = False
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.ForeColor = System.Drawing.Color.Red
            Me.Label4.Location = New System.Drawing.Point(67, 44)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(198, 13)
            Me.Label4.TabIndex = 12
            Me.Label4.Text = "BACKUP DATA BEFORE RUNNING THIS"
            '
            'FMaintenance
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FMaintenance"
            Me.Text = "Maintenance"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.CmbTransType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbAccount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents CmbAccount As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label3 As Label
        Friend WithEvents CmbTransType As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents BtnGo As Button
        Friend WithEvents Label4 As Label
    End Class

End Namespace
