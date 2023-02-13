Namespace Charts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAssets
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
            Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Me.GrdAssetsByAccount = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.GrdAccountsByAsset = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.TxtSummary = New System.Windows.Forms.TextBox()
            CType(Me.GrdAssetsByAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.GrdAccountsByAsset, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage3.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdAssetsByAccount
            '
            Appearance1.BackColor = System.Drawing.Color.Silver
            Me.GrdAssetsByAccount.DisplayLayout.Appearance = Appearance1
            Me.GrdAssetsByAccount.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdAssetsByAccount.Location = New System.Drawing.Point(3, 3)
            Me.GrdAssetsByAccount.Name = "GrdAssetsByAccount"
            Me.GrdAssetsByAccount.Size = New System.Drawing.Size(760, 519)
            Me.GrdAssetsByAccount.TabIndex = 2
            '
            'TabControl1
            '
            Me.TabControl1.Controls.Add(Me.TabPage1)
            Me.TabControl1.Controls.Add(Me.TabPage2)
            Me.TabControl1.Controls.Add(Me.TabPage3)
            Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControl1.Location = New System.Drawing.Point(5, 5)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(774, 551)
            Me.TabControl1.TabIndex = 3
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.GrdAssetsByAccount)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(766, 525)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Assets By Account"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Controls.Add(Me.GrdAccountsByAsset)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(766, 525)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Accounts By Asset"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'GrdAccountsByAsset
            '
            Appearance2.BackColor = System.Drawing.Color.Silver
            Me.GrdAccountsByAsset.DisplayLayout.Appearance = Appearance2
            Me.GrdAccountsByAsset.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdAccountsByAsset.Location = New System.Drawing.Point(3, 3)
            Me.GrdAccountsByAsset.Name = "GrdAccountsByAsset"
            Me.GrdAccountsByAsset.Size = New System.Drawing.Size(760, 519)
            Me.GrdAccountsByAsset.TabIndex = 3
            '
            'TabPage3
            '
            Me.TabPage3.Controls.Add(Me.TxtSummary)
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(766, 525)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Summary"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'TxtSummary
            '
            Me.TxtSummary.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtSummary.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TxtSummary.Location = New System.Drawing.Point(3, 3)
            Me.TxtSummary.Multiline = True
            Me.TxtSummary.Name = "TxtSummary"
            Me.TxtSummary.ReadOnly = True
            Me.TxtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TxtSummary.Size = New System.Drawing.Size(760, 519)
            Me.TxtSummary.TabIndex = 0
            '
            'FAssets
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Gray
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.TabControl1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FAssets"
            Me.Padding = New System.Windows.Forms.Padding(5)
            Me.Text = "Assets"
            CType(Me.GrdAssetsByAccount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            CType(Me.GrdAccountsByAsset, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage3.ResumeLayout(False)
            Me.TabPage3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GrdAssetsByAccount As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents TabControl1 As TabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents GrdAccountsByAsset As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents TabPage3 As TabPage
        Friend WithEvents TxtSummary As TextBox
    End Class

End Namespace

