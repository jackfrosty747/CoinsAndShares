Namespace SQLInterface
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSqlInterface
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
            Me.TxtSql = New System.Windows.Forms.TextBox()
            Me.GrdSql = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.BtnGo = New System.Windows.Forms.Button()
            Me.TxtTables = New System.Windows.Forms.TextBox()
            Me.SplitTop = New System.Windows.Forms.SplitContainer()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.SplitWholeScreen = New System.Windows.Forms.SplitContainer()
            CType(Me.GrdSql, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SplitTop, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitTop.Panel1.SuspendLayout()
            Me.SplitTop.Panel2.SuspendLayout()
            Me.SplitTop.SuspendLayout()
            Me.Panel1.SuspendLayout()
            CType(Me.SplitWholeScreen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitWholeScreen.Panel1.SuspendLayout()
            Me.SplitWholeScreen.Panel2.SuspendLayout()
            Me.SplitWholeScreen.SuspendLayout()
            Me.SuspendLayout()
            '
            'TxtSql
            '
            Me.TxtSql.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtSql.Location = New System.Drawing.Point(0, 0)
            Me.TxtSql.Multiline = True
            Me.TxtSql.Name = "TxtSql"
            Me.TxtSql.Size = New System.Drawing.Size(519, 244)
            Me.TxtSql.TabIndex = 0
            '
            'GrdSql
            '
            Me.GrdSql.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdSql.Location = New System.Drawing.Point(0, 0)
            Me.GrdSql.Name = "GrdSql"
            Me.GrdSql.Size = New System.Drawing.Size(784, 275)
            Me.GrdSql.TabIndex = 3
            Me.GrdSql.Text = "Query Output"
            '
            'BtnGo
            '
            Me.BtnGo.AutoSize = True
            Me.BtnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnGo.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnGo.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnGo.Image = Global.CoinsAndShares.My.Resources.Resources.wand
            Me.BtnGo.Location = New System.Drawing.Point(466, 5)
            Me.BtnGo.Name = "BtnGo"
            Me.BtnGo.Size = New System.Drawing.Size(48, 28)
            Me.BtnGo.TabIndex = 4
            Me.BtnGo.Text = "&Go"
            Me.BtnGo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnGo.UseVisualStyleBackColor = False
            '
            'TxtTables
            '
            Me.TxtTables.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TxtTables.Location = New System.Drawing.Point(0, 0)
            Me.TxtTables.Multiline = True
            Me.TxtTables.Name = "TxtTables"
            Me.TxtTables.ReadOnly = True
            Me.TxtTables.Size = New System.Drawing.Size(261, 282)
            Me.TxtTables.TabIndex = 5
            '
            'SplitTop
            '
            Me.SplitTop.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitTop.Location = New System.Drawing.Point(0, 0)
            Me.SplitTop.Name = "SplitTop"
            '
            'SplitTop.Panel1
            '
            Me.SplitTop.Panel1.Controls.Add(Me.TxtTables)
            '
            'SplitTop.Panel2
            '
            Me.SplitTop.Panel2.Controls.Add(Me.TxtSql)
            Me.SplitTop.Panel2.Controls.Add(Me.Panel1)
            Me.SplitTop.Size = New System.Drawing.Size(784, 282)
            Me.SplitTop.SplitterDistance = 261
            Me.SplitTop.TabIndex = 6
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnGo)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 244)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(519, 38)
            Me.Panel1.TabIndex = 1
            '
            'SplitWholeScreen
            '
            Me.SplitWholeScreen.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitWholeScreen.Location = New System.Drawing.Point(0, 0)
            Me.SplitWholeScreen.Name = "SplitWholeScreen"
            Me.SplitWholeScreen.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitWholeScreen.Panel1
            '
            Me.SplitWholeScreen.Panel1.Controls.Add(Me.SplitTop)
            '
            'SplitWholeScreen.Panel2
            '
            Me.SplitWholeScreen.Panel2.Controls.Add(Me.GrdSql)
            Me.SplitWholeScreen.Size = New System.Drawing.Size(784, 561)
            Me.SplitWholeScreen.SplitterDistance = 282
            Me.SplitWholeScreen.TabIndex = 7
            '
            'FSqlInterface
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.SplitWholeScreen)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FSqlInterface"
            Me.Text = "SQL Interface"
            CType(Me.GrdSql, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitTop.Panel1.ResumeLayout(False)
            Me.SplitTop.Panel1.PerformLayout()
            Me.SplitTop.Panel2.ResumeLayout(False)
            Me.SplitTop.Panel2.PerformLayout()
            CType(Me.SplitTop, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitTop.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.SplitWholeScreen.Panel1.ResumeLayout(False)
            Me.SplitWholeScreen.Panel2.ResumeLayout(False)
            CType(Me.SplitWholeScreen, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitWholeScreen.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TxtSql As TextBox
        Friend WithEvents GrdSql As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents BtnGo As Button
        Friend WithEvents TxtTables As TextBox
        Friend WithEvents SplitTop As SplitContainer
        Friend WithEvents Panel1 As Panel
        Friend WithEvents SplitWholeScreen As SplitContainer
    End Class

End Namespace
