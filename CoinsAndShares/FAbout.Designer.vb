<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAbout
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblName = New System.Windows.Forms.Label()
        Me.TxtOut = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LblName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TxtOut, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(5, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(614, 388)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.CoinsAndShares.My.Resources.Resources.Emblem_Money_64
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'LblName
        '
        Me.LblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblName.Location = New System.Drawing.Point(73, 0)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(538, 70)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "LblName"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtOut
        '
        Me.TxtOut.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.TxtOut, 2)
        Me.TxtOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtOut.Location = New System.Drawing.Point(3, 73)
        Me.TxtOut.Multiline = True
        Me.TxtOut.Name = "TxtOut"
        Me.TxtOut.ReadOnly = True
        Me.TxtOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtOut.Size = New System.Drawing.Size(608, 312)
        Me.TxtOut.TabIndex = 0
        Me.TxtOut.Text = "TxtOut"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.BtnOk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 403)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(624, 38)
        Me.Panel1.TabIndex = 0
        '
        'BtnOk
        '
        Me.BtnOk.AutoSize = True
        Me.BtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BtnOk.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnOk.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnOk.Image = Global.CoinsAndShares.My.Resources.Resources.tick_circle_frame
        Me.BtnOk.Location = New System.Drawing.Point(571, 5)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(48, 28)
        Me.BtnOk.TabIndex = 0
        Me.BtnOk.Text = "O&K"
        Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 398)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(624, 5)
        Me.Label1.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(624, 398)
        Me.Panel2.TabIndex = 1
        '
        'FAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAbout"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LblName As Label
    Friend WithEvents TxtOut As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnOk As Button
    Friend WithEvents Panel2 As Panel
End Class
