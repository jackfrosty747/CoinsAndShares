Namespace TWRR
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class Ftwrr
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
            Me.TxtStartingBalance = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TxtChange1 = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.TxtChange2 = New System.Windows.Forms.TextBox()
            Me.TxtChange3 = New System.Windows.Forms.TextBox()
            Me.TxtChange4 = New System.Windows.Forms.TextBox()
            Me.LblTwrr = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TxtEndBalance1 = New System.Windows.Forms.TextBox()
            Me.TxtEndBalance2 = New System.Windows.Forms.TextBox()
            Me.TxtEndBalance3 = New System.Windows.Forms.TextBox()
            Me.TxtEndBalance4 = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'TxtStartingBalance
            '
            Me.TxtStartingBalance.Location = New System.Drawing.Point(161, 48)
            Me.TxtStartingBalance.Name = "TxtStartingBalance"
            Me.TxtStartingBalance.Size = New System.Drawing.Size(100, 22)
            Me.TxtStartingBalance.TabIndex = 0
            Me.TxtStartingBalance.Text = "1000000"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(45, 51)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(90, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Starting Balance"
            '
            'TxtChange1
            '
            Me.TxtChange1.Location = New System.Drawing.Point(161, 102)
            Me.TxtChange1.Name = "TxtChange1"
            Me.TxtChange1.Size = New System.Drawing.Size(100, 22)
            Me.TxtChange1.TabIndex = 2
            Me.TxtChange1.Text = "0"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(158, 86)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(55, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Cashflow"
            '
            'TxtChange2
            '
            Me.TxtChange2.Location = New System.Drawing.Point(161, 130)
            Me.TxtChange2.Name = "TxtChange2"
            Me.TxtChange2.Size = New System.Drawing.Size(100, 22)
            Me.TxtChange2.TabIndex = 4
            Me.TxtChange2.Text = "100000"
            '
            'TxtChange3
            '
            Me.TxtChange3.Location = New System.Drawing.Point(161, 158)
            Me.TxtChange3.Name = "TxtChange3"
            Me.TxtChange3.Size = New System.Drawing.Size(100, 22)
            Me.TxtChange3.TabIndex = 5
            '
            'TxtChange4
            '
            Me.TxtChange4.Location = New System.Drawing.Point(161, 186)
            Me.TxtChange4.Name = "TxtChange4"
            Me.TxtChange4.Size = New System.Drawing.Size(100, 22)
            Me.TxtChange4.TabIndex = 6
            '
            'LblTwrr
            '
            Me.LblTwrr.AutoSize = True
            Me.LblTwrr.Location = New System.Drawing.Point(158, 248)
            Me.LblTwrr.Name = "LblTwrr"
            Me.LblTwrr.Size = New System.Drawing.Size(44, 13)
            Me.LblTwrr.TabIndex = 10
            Me.LblTwrr.Text = "LblTwrr"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(45, 248)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(41, 13)
            Me.Label6.TabIndex = 11
            Me.Label6.Text = "TWRR:"
            '
            'TxtEndBalance1
            '
            Me.TxtEndBalance1.Location = New System.Drawing.Point(267, 102)
            Me.TxtEndBalance1.Name = "TxtEndBalance1"
            Me.TxtEndBalance1.Size = New System.Drawing.Size(100, 22)
            Me.TxtEndBalance1.TabIndex = 12
            Me.TxtEndBalance1.Text = "1162484"
            '
            'TxtEndBalance2
            '
            Me.TxtEndBalance2.Location = New System.Drawing.Point(267, 130)
            Me.TxtEndBalance2.Name = "TxtEndBalance2"
            Me.TxtEndBalance2.Size = New System.Drawing.Size(100, 22)
            Me.TxtEndBalance2.TabIndex = 13
            Me.TxtEndBalance2.Text = "1192328"
            '
            'TxtEndBalance3
            '
            Me.TxtEndBalance3.Location = New System.Drawing.Point(267, 158)
            Me.TxtEndBalance3.Name = "TxtEndBalance3"
            Me.TxtEndBalance3.Size = New System.Drawing.Size(100, 22)
            Me.TxtEndBalance3.TabIndex = 14
            '
            'TxtEndBalance4
            '
            Me.TxtEndBalance4.Location = New System.Drawing.Point(267, 186)
            Me.TxtEndBalance4.Name = "TxtEndBalance4"
            Me.TxtEndBalance4.Size = New System.Drawing.Size(100, 22)
            Me.TxtEndBalance4.TabIndex = 15
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(264, 86)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(69, 13)
            Me.Label7.TabIndex = 16
            Me.Label7.Text = "End Balance"
            '
            'Ftwrr
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.TxtEndBalance4)
            Me.Controls.Add(Me.TxtEndBalance3)
            Me.Controls.Add(Me.TxtEndBalance2)
            Me.Controls.Add(Me.TxtEndBalance1)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.LblTwrr)
            Me.Controls.Add(Me.TxtChange4)
            Me.Controls.Add(Me.TxtChange3)
            Me.Controls.Add(Me.TxtChange2)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.TxtChange1)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.TxtStartingBalance)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Ftwrr"
            Me.Text = "Time Weighted Rate of Return"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents TxtStartingBalance As TextBox
        Friend WithEvents Label1 As Label
        Friend WithEvents TxtChange1 As TextBox
        Friend WithEvents Label2 As Label
        Friend WithEvents TxtChange2 As TextBox
        Friend WithEvents TxtChange3 As TextBox
        Friend WithEvents TxtChange4 As TextBox
        Friend WithEvents LblTwrr As Label
        Friend WithEvents Label6 As Label
        Friend WithEvents TxtEndBalance1 As TextBox
        Friend WithEvents TxtEndBalance2 As TextBox
        Friend WithEvents TxtEndBalance3 As TextBox
        Friend WithEvents TxtEndBalance4 As TextBox
        Friend WithEvents Label7 As Label
    End Class

End Namespace
