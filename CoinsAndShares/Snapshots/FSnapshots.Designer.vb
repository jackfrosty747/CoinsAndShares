Namespace Snapshots
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSnapshots
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FSnapshots))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnSetTodaysValues = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TxtShares = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TxtCoins = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.BtnTakeSnapshot = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.GrdSnapshots = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1.SuspendLayout()
            CType(Me.GrdSnapshots, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnSetTodaysValues)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.TxtShares)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.TxtCoins)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.BtnTakeSnapshot)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnCancel)
            Me.Panel1.Controls.Add(Me.BtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 523)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 1
            '
            'BtnSetTodaysValues
            '
            Me.BtnSetTodaysValues.AutoSize = True
            Me.BtnSetTodaysValues.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnSetTodaysValues.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSetTodaysValues.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnSetTodaysValues.Image = Global.CoinsAndShares.My.Resources.Resources.wand
            Me.BtnSetTodaysValues.Location = New System.Drawing.Point(506, 5)
            Me.BtnSetTodaysValues.Name = "BtnSetTodaysValues"
            Me.BtnSetTodaysValues.Size = New System.Drawing.Size(126, 28)
            Me.BtnSetTodaysValues.TabIndex = 8
            Me.BtnSetTodaysValues.Text = "Set Today's Values"
            Me.BtnSetTodaysValues.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSetTodaysValues.UseVisualStyleBackColor = False
            '
            'Label4
            '
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(501, 5)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(5, 28)
            Me.Label4.TabIndex = 9
            '
            'TxtShares
            '
            Me.TxtShares.Dock = System.Windows.Forms.DockStyle.Left
            Me.TxtShares.Location = New System.Drawing.Point(401, 5)
            Me.TxtShares.Name = "TxtShares"
            Me.TxtShares.Size = New System.Drawing.Size(100, 22)
            Me.TxtShares.TabIndex = 6
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(355, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(5, 3, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(46, 16)
            Me.Label3.TabIndex = 7
            Me.Label3.Text = "Shares"
            '
            'TxtCoins
            '
            Me.TxtCoins.Dock = System.Windows.Forms.DockStyle.Left
            Me.TxtCoins.Location = New System.Drawing.Point(255, 5)
            Me.TxtCoins.Name = "TxtCoins"
            Me.TxtCoins.Size = New System.Drawing.Size(100, 22)
            Me.TxtCoins.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(214, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(5, 3, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(41, 16)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "Coins"
            '
            'BtnTakeSnapshot
            '
            Me.BtnTakeSnapshot.AutoSize = True
            Me.BtnTakeSnapshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnTakeSnapshot.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnTakeSnapshot.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnTakeSnapshot.Image = Global.CoinsAndShares.My.Resources.Resources.camera
            Me.BtnTakeSnapshot.Location = New System.Drawing.Point(58, 5)
            Me.BtnTakeSnapshot.Name = "BtnTakeSnapshot"
            Me.BtnTakeSnapshot.Size = New System.Drawing.Size(156, 28)
            Me.BtnTakeSnapshot.TabIndex = 3
            Me.BtnTakeSnapshot.Text = "View Current Figures ->"
            Me.BtnTakeSnapshot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnTakeSnapshot.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(53, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 28)
            Me.Label1.TabIndex = 2
            '
            'BtnCancel
            '
            Me.BtnCancel.AutoSize = True
            Me.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
            Me.BtnCancel.Location = New System.Drawing.Point(712, 5)
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
            'GrdSnapshots
            '
            Me.GrdSnapshots.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdSnapshots.Location = New System.Drawing.Point(0, 0)
            Me.GrdSnapshots.Name = "GrdSnapshots"
            Me.GrdSnapshots.Size = New System.Drawing.Size(784, 523)
            Me.GrdSnapshots.TabIndex = 2
            Me.GrdSnapshots.Text = "Snapshots"
            '
            'FSnapshots
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.GrdSnapshots)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FSnapshots"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Snapshots"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.GrdSnapshots, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnOk As Button
        Friend WithEvents BtnCancel As Button
        Friend WithEvents GrdSnapshots As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents BtnTakeSnapshot As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents TxtShares As TextBox
        Friend WithEvents Label3 As Label
        Friend WithEvents TxtCoins As TextBox
        Friend WithEvents Label2 As Label
        Friend WithEvents BtnSetTodaysValues As Button
        Friend WithEvents Label4 As Label
    End Class

End Namespace

