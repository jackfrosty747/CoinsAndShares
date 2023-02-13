Namespace Hedging
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FHedging
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
            Me.CmbHedgingGroupCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.GrdInstruments = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TxtLocalValue = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            CType(Me.CmbHedgingGroupCode, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.GrdInstruments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'CmbHedgingGroupCode
            '
            Me.CmbHedgingGroupCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbHedgingGroupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbHedgingGroupCode.DisplayMember = ""
            Me.CmbHedgingGroupCode.Dock = System.Windows.Forms.DockStyle.Left
            Me.CmbHedgingGroupCode.Location = New System.Drawing.Point(123, 5)
            Me.CmbHedgingGroupCode.Name = "CmbHedgingGroupCode"
            Me.CmbHedgingGroupCode.Size = New System.Drawing.Size(94, 22)
            Me.CmbHedgingGroupCode.TabIndex = 10
            Me.CmbHedgingGroupCode.ValueMember = ""
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(5, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(118, 18)
            Me.Label1.TabIndex = 11
            Me.Label1.Text = "Hedging Group Code"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.CmbHedgingGroupCode)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(784, 38)
            Me.Panel1.TabIndex = 12
            '
            'GrdInstruments
            '
            Me.GrdInstruments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdInstruments.Location = New System.Drawing.Point(0, 38)
            Me.GrdInstruments.Name = "GrdInstruments"
            Me.GrdInstruments.Size = New System.Drawing.Size(784, 414)
            Me.GrdInstruments.TabIndex = 13
            Me.GrdInstruments.Text = "Instruments"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.TxtLocalValue)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(0, 452)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(784, 109)
            Me.Panel2.TabIndex = 14
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(199, 57)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(275, 13)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "Value in £ of all assets affected by currency specified"
            '
            'TxtLocalValue
            '
            Me.TxtLocalValue.Location = New System.Drawing.Point(93, 54)
            Me.TxtLocalValue.Name = "TxtLocalValue"
            Me.TxtLocalValue.Size = New System.Drawing.Size(100, 22)
            Me.TxtLocalValue.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(23, 57)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 13)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Local Value"
            '
            'FHedging
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.GrdInstruments)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FHedging"
            Me.Text = "Hedging"
            CType(Me.CmbHedgingGroupCode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.GrdInstruments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents CmbHedgingGroupCode As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label1 As Label
        Friend WithEvents Panel1 As Panel
        Friend WithEvents GrdInstruments As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel2 As Panel
        Friend WithEvents TxtLocalValue As TextBox
        Friend WithEvents Label2 As Label
        Friend WithEvents Label3 As Label
    End Class
End Namespace

