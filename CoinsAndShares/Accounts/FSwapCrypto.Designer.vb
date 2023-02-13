Namespace Accounts
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FSwapCrypto
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
            Me.BtnCancel = New System.Windows.Forms.Button()
            Me.BtnOk = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.TxtFromQuantity = New System.Windows.Forms.TextBox()
            Me.TxtToQuantity = New System.Windows.Forms.TextBox()
            Me.CmbFromInstrument = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.CmbToInstrument = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.TxtFromRate = New System.Windows.Forms.TextBox()
            Me.TxtToRate = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TxtDate = New System.Windows.Forms.TextBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.BtnAll = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.LblFromValue = New System.Windows.Forms.Label()
            Me.LblToValue = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            CType(Me.CmbFromInstrument, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CmbToInstrument, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnCancel)
            Me.Panel1.Controls.Add(Me.BtnOk)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 403)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(624, 38)
            Me.Panel1.TabIndex = 2
            '
            'BtnCancel
            '
            Me.BtnCancel.AutoSize = True
            Me.BtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnCancel.Image = Global.CoinsAndShares.My.Resources.Resources.cross_circle_frame
            Me.BtnCancel.Location = New System.Drawing.Point(552, 5)
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
            Me.BtnOk.Image = Global.CoinsAndShares.My.Resources.Resources.tick_circle_frame
            Me.BtnOk.Location = New System.Drawing.Point(5, 5)
            Me.BtnOk.Name = "BtnOk"
            Me.BtnOk.Size = New System.Drawing.Size(48, 28)
            Me.BtnOk.TabIndex = 0
            Me.BtnOk.Text = "O&K"
            Me.BtnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnOk.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 21)
            Me.Label1.Name = "Label1"
            Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label1.Size = New System.Drawing.Size(33, 18)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "From"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(3, 50)
            Me.Label2.Name = "Label2"
            Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.Label2.Size = New System.Drawing.Size(19, 18)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "To"
            '
            'TxtFromQuantity
            '
            Me.TxtFromQuantity.Location = New System.Drawing.Point(42, 24)
            Me.TxtFromQuantity.Name = "TxtFromQuantity"
            Me.TxtFromQuantity.Size = New System.Drawing.Size(94, 22)
            Me.TxtFromQuantity.TabIndex = 6
            '
            'TxtToQuantity
            '
            Me.TxtToQuantity.Location = New System.Drawing.Point(42, 53)
            Me.TxtToQuantity.Name = "TxtToQuantity"
            Me.TxtToQuantity.Size = New System.Drawing.Size(94, 22)
            Me.TxtToQuantity.TabIndex = 7
            '
            'CmbFromInstrument
            '
            Me.CmbFromInstrument.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbFromInstrument.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbFromInstrument.DisplayMember = ""
            Me.CmbFromInstrument.Location = New System.Drawing.Point(142, 24)
            Me.CmbFromInstrument.Name = "CmbFromInstrument"
            Me.CmbFromInstrument.Size = New System.Drawing.Size(94, 22)
            Me.CmbFromInstrument.TabIndex = 10
            Me.CmbFromInstrument.ValueMember = ""
            '
            'CmbToInstrument
            '
            Me.CmbToInstrument.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbToInstrument.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbToInstrument.DisplayMember = ""
            Me.CmbToInstrument.Location = New System.Drawing.Point(142, 53)
            Me.CmbToInstrument.Name = "CmbToInstrument"
            Me.CmbToInstrument.Size = New System.Drawing.Size(94, 22)
            Me.CmbToInstrument.TabIndex = 11
            Me.CmbToInstrument.ValueMember = ""
            '
            'TxtFromRate
            '
            Me.TxtFromRate.Location = New System.Drawing.Point(242, 24)
            Me.TxtFromRate.Name = "TxtFromRate"
            Me.TxtFromRate.Size = New System.Drawing.Size(94, 22)
            Me.TxtFromRate.TabIndex = 13
            '
            'TxtToRate
            '
            Me.TxtToRate.Location = New System.Drawing.Point(242, 53)
            Me.TxtToRate.Name = "TxtToRate"
            Me.TxtToRate.Size = New System.Drawing.Size(94, 22)
            Me.TxtToRate.TabIndex = 14
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(198, 65)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(31, 13)
            Me.Label4.TabIndex = 16
            Me.Label4.Text = "Date"
            '
            'TxtDate
            '
            Me.TxtDate.Location = New System.Drawing.Point(248, 62)
            Me.TxtDate.Name = "TxtDate"
            Me.TxtDate.Size = New System.Drawing.Size(100, 22)
            Me.TxtDate.TabIndex = 17
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.TableLayoutPanel1.ColumnCount = 6
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.BtnAll, 4, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.Label5, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label6, 2, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label7, 3, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label8, 5, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtToRate, 3, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtFromQuantity, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbToInstrument, 2, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.CmbFromInstrument, 2, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtFromRate, 3, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TxtToQuantity, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.LblFromValue, 5, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.LblToValue, 5, 2)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 134)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 4
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(600, 144)
            Me.TableLayoutPanel1.TabIndex = 18
            '
            'BtnAll
            '
            Me.BtnAll.AutoSize = True
            Me.BtnAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnAll.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnAll.Location = New System.Drawing.Point(342, 24)
            Me.BtnAll.Name = "BtnAll"
            Me.BtnAll.Size = New System.Drawing.Size(30, 23)
            Me.BtnAll.TabIndex = 19
            Me.BtnAll.Text = "All"
            Me.BtnAll.UseVisualStyleBackColor = False
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(42, 0)
            Me.Label5.Name = "Label5"
            Me.Label5.Padding = New System.Windows.Forms.Padding(0, 5, 0, 3)
            Me.Label5.Size = New System.Drawing.Size(52, 21)
            Me.Label5.TabIndex = 18
            Me.Label5.Text = "Quantity"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(142, 0)
            Me.Label6.Name = "Label6"
            Me.Label6.Padding = New System.Windows.Forms.Padding(0, 5, 0, 3)
            Me.Label6.Size = New System.Drawing.Size(64, 21)
            Me.Label6.TabIndex = 19
            Me.Label6.Text = "Instrument"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(242, 0)
            Me.Label7.Name = "Label7"
            Me.Label7.Padding = New System.Windows.Forms.Padding(0, 5, 0, 3)
            Me.Label7.Size = New System.Drawing.Size(30, 21)
            Me.Label7.TabIndex = 20
            Me.Label7.Text = "Rate"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.Location = New System.Drawing.Point(378, 0)
            Me.Label8.Name = "Label8"
            Me.Label8.Padding = New System.Windows.Forms.Padding(0, 5, 0, 3)
            Me.Label8.Size = New System.Drawing.Size(35, 21)
            Me.Label8.TabIndex = 21
            Me.Label8.Text = "Value"
            '
            'LblFromValue
            '
            Me.LblFromValue.AutoSize = True
            Me.LblFromValue.Location = New System.Drawing.Point(378, 21)
            Me.LblFromValue.Name = "LblFromValue"
            Me.LblFromValue.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblFromValue.Size = New System.Drawing.Size(76, 18)
            Me.LblFromValue.TabIndex = 22
            Me.LblFromValue.Text = "LblFromValue"
            '
            'LblToValue
            '
            Me.LblToValue.AutoSize = True
            Me.LblToValue.Location = New System.Drawing.Point(378, 50)
            Me.LblToValue.Name = "LblToValue"
            Me.LblToValue.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblToValue.Size = New System.Drawing.Size(62, 18)
            Me.LblToValue.TabIndex = 23
            Me.LblToValue.Text = "LblToValue"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(25, 323)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(576, 39)
            Me.Label9.TabIndex = 19
            Me.Label9.Text = "This will sell the FROM instrument at the current rate and buy the TO instrument " &
    "with that amount of currency." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The buy and sell will be separate batches"
            '
            'FSwapCrypto
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.Label9)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.TxtDate)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FSwapCrypto"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Swap Crypto"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.CmbFromInstrument, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CmbToInstrument, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnCancel As Button
        Friend WithEvents BtnOk As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents Label2 As Label
        Friend WithEvents TxtFromQuantity As TextBox
        Friend WithEvents TxtToQuantity As TextBox
        Friend WithEvents CmbFromInstrument As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents CmbToInstrument As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents TxtFromRate As TextBox
        Friend WithEvents TxtToRate As TextBox
        Friend WithEvents Label4 As Label
        Friend WithEvents TxtDate As TextBox
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents Label5 As Label
        Friend WithEvents Label6 As Label
        Friend WithEvents Label7 As Label
        Friend WithEvents Label8 As Label
        Friend WithEvents LblFromValue As Label
        Friend WithEvents LblToValue As Label
        Friend WithEvents BtnAll As Button
        Friend WithEvents Label9 As Label
    End Class

End Namespace
