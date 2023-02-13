Namespace Instruments
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FInstruments
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
            Me.GrdInstruments = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.BtnDelete = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.BtnEdit = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.BtnNew = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.TxtFilter = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.OptTypeShares = New System.Windows.Forms.RadioButton()
            Me.OptTypeCrypto = New System.Windows.Forms.RadioButton()
            Me.OptTypeAll = New System.Windows.Forms.RadioButton()
            CType(Me.GrdInstruments, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdInstruments
            '
            Me.GrdInstruments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdInstruments.Location = New System.Drawing.Point(0, 38)
            Me.GrdInstruments.Name = "GrdInstruments"
            Me.GrdInstruments.Size = New System.Drawing.Size(624, 365)
            Me.GrdInstruments.TabIndex = 0
            Me.GrdInstruments.Text = "Instruments"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.White
            Me.Panel1.Controls.Add(Me.BtnDelete)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.BtnEdit)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.BtnNew)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 403)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel1.Size = New System.Drawing.Size(624, 38)
            Me.Panel1.TabIndex = 1
            '
            'BtnDelete
            '
            Me.BtnDelete.AutoSize = True
            Me.BtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnDelete.Image = Global.CoinsAndShares.My.Resources.Resources.cross_script
            Me.BtnDelete.Location = New System.Drawing.Point(201, 5)
            Me.BtnDelete.Name = "BtnDelete"
            Me.BtnDelete.Size = New System.Drawing.Size(125, 28)
            Me.BtnDelete.TabIndex = 7
            Me.BtnDelete.Text = "Delete Instrument"
            Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnDelete.UseVisualStyleBackColor = False
            '
            'Label3
            '
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(196, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(5, 28)
            Me.Label3.TabIndex = 8
            '
            'BtnRefresh
            '
            Me.BtnRefresh.AutoSize = True
            Me.BtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnRefresh.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_circle_double_135
            Me.BtnRefresh.Location = New System.Drawing.Point(124, 5)
            Me.BtnRefresh.Name = "BtnRefresh"
            Me.BtnRefresh.Size = New System.Drawing.Size(72, 28)
            Me.BtnRefresh.TabIndex = 5
            Me.BtnRefresh.Text = "Refresh"
            Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnRefresh.UseVisualStyleBackColor = False
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label2.Location = New System.Drawing.Point(119, 5)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(5, 28)
            Me.Label2.TabIndex = 6
            '
            'BtnEdit
            '
            Me.BtnEdit.AutoSize = True
            Me.BtnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnEdit.Image = Global.CoinsAndShares.My.Resources.Resources.blue_folder_open
            Me.BtnEdit.Location = New System.Drawing.Point(66, 5)
            Me.BtnEdit.Name = "BtnEdit"
            Me.BtnEdit.Size = New System.Drawing.Size(53, 28)
            Me.BtnEdit.TabIndex = 3
            Me.BtnEdit.Text = "Edit"
            Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnEdit.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label1.Location = New System.Drawing.Point(61, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(5, 28)
            Me.Label1.TabIndex = 4
            '
            'BtnNew
            '
            Me.BtnNew.AutoSize = True
            Me.BtnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnNew.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnNew.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnNew.Image = Global.CoinsAndShares.My.Resources.Resources._new
            Me.BtnNew.Location = New System.Drawing.Point(5, 5)
            Me.BtnNew.Name = "BtnNew"
            Me.BtnNew.Size = New System.Drawing.Size(56, 28)
            Me.BtnNew.TabIndex = 2
            Me.BtnNew.Text = "New"
            Me.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnNew.UseVisualStyleBackColor = False
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.Controls.Add(Me.TxtFilter)
            Me.Panel2.Controls.Add(Me.Label4)
            Me.Panel2.Controls.Add(Me.Panel3)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(0, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(624, 38)
            Me.Panel2.TabIndex = 2
            '
            'TxtFilter
            '
            Me.TxtFilter.Dock = System.Windows.Forms.DockStyle.Left
            Me.TxtFilter.Location = New System.Drawing.Point(214, 5)
            Me.TxtFilter.Name = "TxtFilter"
            Me.TxtFilter.Size = New System.Drawing.Size(136, 22)
            Me.TxtFilter.TabIndex = 3
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(161, 5)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(20, 5, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(53, 18)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Filter"
            '
            'Panel3
            '
            Me.Panel3.AutoSize = True
            Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.Panel3.Controls.Add(Me.OptTypeShares)
            Me.Panel3.Controls.Add(Me.OptTypeCrypto)
            Me.Panel3.Controls.Add(Me.OptTypeAll)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Panel3.Location = New System.Drawing.Point(5, 5)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(156, 28)
            Me.Panel3.TabIndex = 1
            '
            'OptTypeShares
            '
            Me.OptTypeShares.AutoSize = True
            Me.OptTypeShares.Dock = System.Windows.Forms.DockStyle.Left
            Me.OptTypeShares.Location = New System.Drawing.Point(97, 0)
            Me.OptTypeShares.Name = "OptTypeShares"
            Me.OptTypeShares.Size = New System.Drawing.Size(59, 28)
            Me.OptTypeShares.TabIndex = 2
            Me.OptTypeShares.TabStop = True
            Me.OptTypeShares.Text = "Shares"
            Me.OptTypeShares.UseVisualStyleBackColor = True
            '
            'OptTypeCrypto
            '
            Me.OptTypeCrypto.AutoSize = True
            Me.OptTypeCrypto.Dock = System.Windows.Forms.DockStyle.Left
            Me.OptTypeCrypto.Location = New System.Drawing.Point(38, 0)
            Me.OptTypeCrypto.Name = "OptTypeCrypto"
            Me.OptTypeCrypto.Size = New System.Drawing.Size(59, 28)
            Me.OptTypeCrypto.TabIndex = 1
            Me.OptTypeCrypto.TabStop = True
            Me.OptTypeCrypto.Text = "Crypto"
            Me.OptTypeCrypto.UseVisualStyleBackColor = True
            '
            'OptTypeAll
            '
            Me.OptTypeAll.AutoSize = True
            Me.OptTypeAll.Dock = System.Windows.Forms.DockStyle.Left
            Me.OptTypeAll.Location = New System.Drawing.Point(0, 0)
            Me.OptTypeAll.Name = "OptTypeAll"
            Me.OptTypeAll.Size = New System.Drawing.Size(38, 28)
            Me.OptTypeAll.TabIndex = 0
            Me.OptTypeAll.TabStop = True
            Me.OptTypeAll.Text = "All"
            Me.OptTypeAll.UseVisualStyleBackColor = True
            '
            'FInstruments
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(624, 441)
            Me.Controls.Add(Me.GrdInstruments)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FInstruments"
            Me.Text = "Instruments"
            CType(Me.GrdInstruments, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GrdInstruments As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnNew As Button
        Friend WithEvents BtnEdit As Button
        Friend WithEvents Label1 As Label
        Friend WithEvents BtnRefresh As Button
        Friend WithEvents Label2 As Label
        Friend WithEvents BtnDelete As Button
        Friend WithEvents Label3 As Label
        Friend WithEvents Panel2 As Panel
        Friend WithEvents OptTypeAll As RadioButton
        Friend WithEvents Panel3 As Panel
        Friend WithEvents OptTypeShares As RadioButton
        Friend WithEvents OptTypeCrypto As RadioButton
        Friend WithEvents Label4 As Label
        Friend WithEvents TxtFilter As TextBox
    End Class

End Namespace
