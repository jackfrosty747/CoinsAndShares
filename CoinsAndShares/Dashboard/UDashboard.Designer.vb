Namespace Dashboard
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class UDashboard
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Me.BtnHideDashboard = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.UHoldings1 = New CoinsAndShares.Dashboard.UHoldings()
            Me.UCurrency1 = New CoinsAndShares.Dashboard.UCurrency()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'BtnHideDashboard
            '
            Me.BtnHideDashboard.AutoSize = True
            Me.BtnHideDashboard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnHideDashboard.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnHideDashboard.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnHideDashboard.Image = Global.CoinsAndShares.My.Resources.Resources.cross_script
            Me.BtnHideDashboard.Location = New System.Drawing.Point(209, 5)
            Me.BtnHideDashboard.Name = "BtnHideDashboard"
            Me.BtnHideDashboard.Size = New System.Drawing.Size(22, 22)
            Me.BtnHideDashboard.TabIndex = 0
            Me.BtnHideDashboard.UseVisualStyleBackColor = False
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnHideDashboard)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(236, 32)
            Me.Panel1.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(5, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(75, 18)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "DASHBOARD"
            '
            'UHoldings1
            '
            Me.UHoldings1.Dock = System.Windows.Forms.DockStyle.Top
            Me.UHoldings1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UHoldings1.Location = New System.Drawing.Point(0, 133)
            Me.UHoldings1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
            Me.UHoldings1.Name = "UHoldings1"
            Me.UHoldings1.Size = New System.Drawing.Size(236, 111)
            Me.UHoldings1.TabIndex = 3
            '
            'UCurrency1
            '
            Me.UCurrency1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.UCurrency1.Dock = System.Windows.Forms.DockStyle.Top
            Me.UCurrency1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.UCurrency1.Location = New System.Drawing.Point(0, 32)
            Me.UCurrency1.Name = "UCurrency1"
            Me.UCurrency1.Size = New System.Drawing.Size(236, 101)
            Me.UCurrency1.TabIndex = 2
            '
            'UDashboard
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.Controls.Add(Me.UHoldings1)
            Me.Controls.Add(Me.UCurrency1)
            Me.Controls.Add(Me.Panel1)
            Me.DoubleBuffered = True
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "UDashboard"
            Me.Size = New System.Drawing.Size(236, 415)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents BtnHideDashboard As Button
        Friend WithEvents Panel1 As Panel
        Friend WithEvents Label1 As Label
        Friend WithEvents ToolTip1 As ToolTip
        Friend WithEvents UCurrency1 As UCurrency
        Friend WithEvents UHoldings1 As UHoldings
    End Class

End Namespace

