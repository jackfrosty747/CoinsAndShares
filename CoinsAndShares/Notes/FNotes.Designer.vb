Namespace Notes
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FNotes
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
            Me.TabNotes = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnClose = New System.Windows.Forms.Button()
            Me.BtnSave = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.TabNotes.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabNotes
            '
            Me.TabNotes.Controls.Add(Me.TabPage1)
            Me.TabNotes.Controls.Add(Me.TabPage2)
            Me.TabNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabNotes.Location = New System.Drawing.Point(5, 5)
            Me.TabNotes.Name = "TabNotes"
            Me.TabNotes.SelectedIndex = 0
            Me.TabNotes.Size = New System.Drawing.Size(774, 513)
            Me.TabNotes.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(766, 487)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "TabPage1"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'TabPage2
            '
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage2.Size = New System.Drawing.Size(766, 487)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "TabPage2"
            Me.TabPage2.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnClose)
            Me.Panel1.Controls.Add(Me.BtnSave)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 523)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 1
            '
            'BtnClose
            '
            Me.BtnClose.AutoSize = True
            Me.BtnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnClose.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnClose.Image = Global.CoinsAndShares.My.Resources.Resources.cross_circle_frame
            Me.BtnClose.Location = New System.Drawing.Point(718, 5)
            Me.BtnClose.Name = "BtnClose"
            Me.BtnClose.Size = New System.Drawing.Size(61, 28)
            Me.BtnClose.TabIndex = 3
            Me.BtnClose.Text = "&Close"
            Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnClose.UseVisualStyleBackColor = False
            '
            'BtnSave
            '
            Me.BtnSave.AutoSize = True
            Me.BtnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnSave.Image = Global.CoinsAndShares.My.Resources.Resources.disk
            Me.BtnSave.Location = New System.Drawing.Point(5, 5)
            Me.BtnSave.Name = "BtnSave"
            Me.BtnSave.Size = New System.Drawing.Size(56, 28)
            Me.BtnSave.TabIndex = 2
            Me.BtnSave.Text = "&Save"
            Me.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnSave.UseVisualStyleBackColor = False
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Silver
            Me.Panel2.Controls.Add(Me.TabNotes)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(784, 523)
            Me.Panel2.TabIndex = 2
            '
            'FNotes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FNotes"
            Me.Text = "Notes"
            Me.TabNotes.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TabNotes As TabControl
        Friend WithEvents TabPage1 As TabPage
        Friend WithEvents TabPage2 As TabPage
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnSave As Button
        Friend WithEvents BtnClose As Button
        Friend WithEvents Panel2 As Panel
    End Class

End Namespace
