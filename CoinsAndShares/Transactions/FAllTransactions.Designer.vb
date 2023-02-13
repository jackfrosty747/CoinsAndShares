Namespace Transactions
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FAllTransactions
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
            Me.GrdTransactions = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.GroupBox5 = New System.Windows.Forms.GroupBox()
            Me.TxtDescription = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.TlpDates = New System.Windows.Forms.TableLayoutPanel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.DtpFrom = New System.Windows.Forms.DateTimePicker()
            Me.DtpTo = New System.Windows.Forms.DateTimePicker()
            Me.ChkAllDates = New System.Windows.Forms.CheckBox()
            Me.GroupBox4 = New System.Windows.Forms.GroupBox()
            Me.CmbType = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.PnlAccountSingle = New System.Windows.Forms.Panel()
            Me.CmbAccount = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.PnlAccountType = New System.Windows.Forms.Panel()
            Me.CmbAccountType = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.OptAccountSingle = New System.Windows.Forms.RadioButton()
            Me.OptAccountAll = New System.Windows.Forms.RadioButton()
            Me.OptAccountType = New System.Windows.Forms.RadioButton()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.PnlInstrumentType = New System.Windows.Forms.Panel()
            Me.CmbInstrumentTypeName = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.OptInstrumentSingle = New System.Windows.Forms.RadioButton()
            Me.OptInstrumentAll = New System.Windows.Forms.RadioButton()
            Me.OptInstrumentLocalCurrency = New System.Windows.Forms.RadioButton()
            Me.OptInstrumentType = New System.Windows.Forms.RadioButton()
            Me.PnlInstrumentCode = New System.Windows.Forms.Panel()
            Me.CmbInstrumentCode = New Infragistics.Win.UltraWinGrid.UltraCombo()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.BtnRefresh = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.BtnDelete = New System.Windows.Forms.Button()
            Me.LblSelected = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.LblTotalAmount = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.BtnExport = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.BtnEdit = New System.Windows.Forms.Button()
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.GroupBox5.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.TlpDates.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            CType(Me.CmbType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.PnlAccountSingle.SuspendLayout()
            CType(Me.CmbAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PnlAccountType.SuspendLayout()
            CType(Me.CmbAccountType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.PnlInstrumentType.SuspendLayout()
            CType(Me.CmbInstrumentTypeName, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PnlInstrumentCode.SuspendLayout()
            CType(Me.CmbInstrumentCode, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'GrdTransactions
            '
            Me.GrdTransactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GrdTransactions.Location = New System.Drawing.Point(0, 273)
            Me.GrdTransactions.Name = "GrdTransactions"
            Me.GrdTransactions.Size = New System.Drawing.Size(784, 250)
            Me.GrdTransactions.TabIndex = 5
            Me.GrdTransactions.Text = "Transactions"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.GroupBox5)
            Me.Panel1.Controls.Add(Me.GroupBox3)
            Me.Panel1.Controls.Add(Me.GroupBox4)
            Me.Panel1.Controls.Add(Me.GroupBox2)
            Me.Panel1.Controls.Add(Me.GroupBox1)
            Me.Panel1.Controls.Add(Me.BtnRefresh)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(784, 273)
            Me.Panel1.TabIndex = 6
            '
            'GroupBox5
            '
            Me.GroupBox5.Controls.Add(Me.TxtDescription)
            Me.GroupBox5.Controls.Add(Me.Label10)
            Me.GroupBox5.Location = New System.Drawing.Point(12, 215)
            Me.GroupBox5.Name = "GroupBox5"
            Me.GroupBox5.Size = New System.Drawing.Size(341, 52)
            Me.GroupBox5.TabIndex = 15
            Me.GroupBox5.TabStop = False
            Me.GroupBox5.Text = "Other"
            '
            'TxtDescription
            '
            Me.TxtDescription.Location = New System.Drawing.Point(78, 21)
            Me.TxtDescription.Name = "TxtDescription"
            Me.TxtDescription.Size = New System.Drawing.Size(241, 22)
            Me.TxtDescription.TabIndex = 1
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(6, 24)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(66, 13)
            Me.Label10.TabIndex = 6
            Me.Label10.Text = "Description"
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.TlpDates)
            Me.GroupBox3.Controls.Add(Me.ChkAllDates)
            Me.GroupBox3.Location = New System.Drawing.Point(359, 141)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox3.Size = New System.Drawing.Size(341, 118)
            Me.GroupBox3.TabIndex = 13
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Date Range"
            '
            'TlpDates
            '
            Me.TlpDates.AutoSize = True
            Me.TlpDates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TlpDates.ColumnCount = 2
            Me.TlpDates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpDates.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TlpDates.Controls.Add(Me.Label1, 0, 0)
            Me.TlpDates.Controls.Add(Me.Label2, 0, 1)
            Me.TlpDates.Controls.Add(Me.DtpFrom, 1, 0)
            Me.TlpDates.Controls.Add(Me.DtpTo, 1, 1)
            Me.TlpDates.Dock = System.Windows.Forms.DockStyle.Top
            Me.TlpDates.Location = New System.Drawing.Point(5, 43)
            Me.TlpDates.Name = "TlpDates"
            Me.TlpDates.RowCount = 2
            Me.TlpDates.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpDates.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TlpDates.Size = New System.Drawing.Size(331, 56)
            Me.TlpDates.TabIndex = 0
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(3, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(60, 13)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "Date From"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(3, 28)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(46, 13)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "Date To"
            '
            'DtpFrom
            '
            Me.DtpFrom.Location = New System.Drawing.Point(69, 3)
            Me.DtpFrom.Name = "DtpFrom"
            Me.DtpFrom.Size = New System.Drawing.Size(150, 22)
            Me.DtpFrom.TabIndex = 2
            '
            'DtpTo
            '
            Me.DtpTo.Location = New System.Drawing.Point(69, 31)
            Me.DtpTo.Name = "DtpTo"
            Me.DtpTo.Size = New System.Drawing.Size(150, 22)
            Me.DtpTo.TabIndex = 3
            '
            'ChkAllDates
            '
            Me.ChkAllDates.AutoSize = True
            Me.ChkAllDates.Checked = True
            Me.ChkAllDates.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ChkAllDates.Dock = System.Windows.Forms.DockStyle.Top
            Me.ChkAllDates.Location = New System.Drawing.Point(5, 20)
            Me.ChkAllDates.Name = "ChkAllDates"
            Me.ChkAllDates.Padding = New System.Windows.Forms.Padding(3)
            Me.ChkAllDates.Size = New System.Drawing.Size(331, 23)
            Me.ChkAllDates.TabIndex = 1
            Me.ChkAllDates.Text = "All Dates"
            Me.ChkAllDates.UseVisualStyleBackColor = True
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.CmbType)
            Me.GroupBox4.Location = New System.Drawing.Point(12, 157)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(341, 52)
            Me.GroupBox4.TabIndex = 14
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Type"
            '
            'CmbType
            '
            Me.CmbType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbType.DisplayMember = ""
            Me.CmbType.Location = New System.Drawing.Point(78, 21)
            Me.CmbType.Name = "CmbType"
            Me.CmbType.Size = New System.Drawing.Size(241, 22)
            Me.CmbType.TabIndex = 8
            Me.CmbType.ValueMember = ""
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
            Me.GroupBox2.Location = New System.Drawing.Point(359, 12)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(341, 123)
            Me.GroupBox2.TabIndex = 12
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Account"
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoSize = True
            Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel1.Controls.Add(Me.PnlAccountSingle, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.PnlAccountType, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.OptAccountSingle, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.OptAccountAll, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.OptAccountType, 0, 1)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 18)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 3
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(335, 84)
            Me.TableLayoutPanel1.TabIndex = 13
            '
            'PnlAccountSingle
            '
            Me.PnlAccountSingle.Controls.Add(Me.CmbAccount)
            Me.PnlAccountSingle.Controls.Add(Me.Label4)
            Me.PnlAccountSingle.Location = New System.Drawing.Point(66, 56)
            Me.PnlAccountSingle.Name = "PnlAccountSingle"
            Me.PnlAccountSingle.Size = New System.Drawing.Size(256, 25)
            Me.PnlAccountSingle.TabIndex = 13
            '
            'CmbAccount
            '
            Me.CmbAccount.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccount.DisplayMember = ""
            Me.CmbAccount.Dock = System.Windows.Forms.DockStyle.Left
            Me.CmbAccount.Location = New System.Drawing.Point(49, 0)
            Me.CmbAccount.Name = "CmbAccount"
            Me.CmbAccount.Size = New System.Drawing.Size(146, 22)
            Me.CmbAccount.TabIndex = 7
            Me.CmbAccount.ValueMember = ""
            '
            'Label4
            '
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label4.Location = New System.Drawing.Point(0, 0)
            Me.Label4.Name = "Label4"
            Me.Label4.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label4.Size = New System.Drawing.Size(49, 25)
            Me.Label4.TabIndex = 8
            Me.Label4.Text = "Account"
            '
            'PnlAccountType
            '
            Me.PnlAccountType.Controls.Add(Me.CmbAccountType)
            Me.PnlAccountType.Controls.Add(Me.Label6)
            Me.PnlAccountType.Location = New System.Drawing.Point(66, 26)
            Me.PnlAccountType.Name = "PnlAccountType"
            Me.PnlAccountType.Size = New System.Drawing.Size(256, 24)
            Me.PnlAccountType.TabIndex = 14
            '
            'CmbAccountType
            '
            Me.CmbAccountType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbAccountType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbAccountType.DisplayMember = ""
            Me.CmbAccountType.Dock = System.Windows.Forms.DockStyle.Left
            Me.CmbAccountType.Location = New System.Drawing.Point(49, 0)
            Me.CmbAccountType.Name = "CmbAccountType"
            Me.CmbAccountType.Size = New System.Drawing.Size(146, 22)
            Me.CmbAccountType.TabIndex = 7
            Me.CmbAccountType.ValueMember = ""
            '
            'Label6
            '
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label6.Location = New System.Drawing.Point(0, 0)
            Me.Label6.Name = "Label6"
            Me.Label6.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label6.Size = New System.Drawing.Size(49, 24)
            Me.Label6.TabIndex = 8
            Me.Label6.Text = "Type"
            '
            'OptAccountSingle
            '
            Me.OptAccountSingle.AutoSize = True
            Me.OptAccountSingle.Location = New System.Drawing.Point(3, 56)
            Me.OptAccountSingle.Name = "OptAccountSingle"
            Me.OptAccountSingle.Size = New System.Drawing.Size(57, 17)
            Me.OptAccountSingle.TabIndex = 11
            Me.OptAccountSingle.Text = "Single"
            Me.OptAccountSingle.UseVisualStyleBackColor = True
            '
            'OptAccountAll
            '
            Me.OptAccountAll.AutoSize = True
            Me.OptAccountAll.Checked = True
            Me.OptAccountAll.Location = New System.Drawing.Point(3, 3)
            Me.OptAccountAll.Name = "OptAccountAll"
            Me.OptAccountAll.Size = New System.Drawing.Size(38, 17)
            Me.OptAccountAll.TabIndex = 9
            Me.OptAccountAll.TabStop = True
            Me.OptAccountAll.Text = "All"
            Me.OptAccountAll.UseVisualStyleBackColor = True
            '
            'OptAccountType
            '
            Me.OptAccountType.AutoSize = True
            Me.OptAccountType.Location = New System.Drawing.Point(3, 26)
            Me.OptAccountType.Name = "OptAccountType"
            Me.OptAccountType.Size = New System.Drawing.Size(48, 17)
            Me.OptAccountType.TabIndex = 10
            Me.OptAccountType.Text = "Type"
            Me.OptAccountType.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
            Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
            Me.GroupBox1.Size = New System.Drawing.Size(341, 139)
            Me.GroupBox1.TabIndex = 11
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Instrument"
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.AutoSize = True
            Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.TableLayoutPanel2.ColumnCount = 2
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.TableLayoutPanel2.Controls.Add(Me.PnlInstrumentType, 1, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.OptInstrumentSingle, 0, 3)
            Me.TableLayoutPanel2.Controls.Add(Me.OptInstrumentAll, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.OptInstrumentLocalCurrency, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.OptInstrumentType, 0, 2)
            Me.TableLayoutPanel2.Controls.Add(Me.PnlInstrumentCode, 1, 3)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(5, 20)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 4
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(331, 106)
            Me.TableLayoutPanel2.TabIndex = 13
            '
            'PnlInstrumentType
            '
            Me.PnlInstrumentType.Controls.Add(Me.CmbInstrumentTypeName)
            Me.PnlInstrumentType.Controls.Add(Me.Label7)
            Me.PnlInstrumentType.Location = New System.Drawing.Point(105, 49)
            Me.PnlInstrumentType.Name = "PnlInstrumentType"
            Me.PnlInstrumentType.Size = New System.Drawing.Size(256, 24)
            Me.PnlInstrumentType.TabIndex = 15
            '
            'CmbInstrumentTypeName
            '
            Me.CmbInstrumentTypeName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrumentTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrumentTypeName.DisplayMember = ""
            Me.CmbInstrumentTypeName.Dock = System.Windows.Forms.DockStyle.Left
            Me.CmbInstrumentTypeName.Location = New System.Drawing.Point(63, 0)
            Me.CmbInstrumentTypeName.Name = "CmbInstrumentTypeName"
            Me.CmbInstrumentTypeName.Size = New System.Drawing.Size(146, 22)
            Me.CmbInstrumentTypeName.TabIndex = 7
            Me.CmbInstrumentTypeName.ValueMember = ""
            '
            'Label7
            '
            Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label7.Location = New System.Drawing.Point(0, 0)
            Me.Label7.Name = "Label7"
            Me.Label7.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label7.Size = New System.Drawing.Size(63, 24)
            Me.Label7.TabIndex = 8
            Me.Label7.Text = "Type"
            '
            'OptInstrumentSingle
            '
            Me.OptInstrumentSingle.AutoSize = True
            Me.OptInstrumentSingle.Location = New System.Drawing.Point(3, 79)
            Me.OptInstrumentSingle.Name = "OptInstrumentSingle"
            Me.OptInstrumentSingle.Size = New System.Drawing.Size(57, 17)
            Me.OptInstrumentSingle.TabIndex = 3
            Me.OptInstrumentSingle.Text = "Single"
            Me.OptInstrumentSingle.UseVisualStyleBackColor = True
            '
            'OptInstrumentAll
            '
            Me.OptInstrumentAll.AutoSize = True
            Me.OptInstrumentAll.Checked = True
            Me.OptInstrumentAll.Location = New System.Drawing.Point(3, 3)
            Me.OptInstrumentAll.Name = "OptInstrumentAll"
            Me.OptInstrumentAll.Size = New System.Drawing.Size(38, 17)
            Me.OptInstrumentAll.TabIndex = 1
            Me.OptInstrumentAll.TabStop = True
            Me.OptInstrumentAll.Text = "All"
            Me.OptInstrumentAll.UseVisualStyleBackColor = True
            '
            'OptInstrumentLocalCurrency
            '
            Me.OptInstrumentLocalCurrency.AutoSize = True
            Me.OptInstrumentLocalCurrency.Location = New System.Drawing.Point(3, 26)
            Me.OptInstrumentLocalCurrency.Name = "OptInstrumentLocalCurrency"
            Me.OptInstrumentLocalCurrency.Size = New System.Drawing.Size(96, 17)
            Me.OptInstrumentLocalCurrency.TabIndex = 0
            Me.OptInstrumentLocalCurrency.Text = "LocalCurrency"
            Me.OptInstrumentLocalCurrency.UseVisualStyleBackColor = True
            '
            'OptInstrumentType
            '
            Me.OptInstrumentType.AutoSize = True
            Me.OptInstrumentType.Location = New System.Drawing.Point(3, 49)
            Me.OptInstrumentType.Name = "OptInstrumentType"
            Me.OptInstrumentType.Size = New System.Drawing.Size(48, 17)
            Me.OptInstrumentType.TabIndex = 2
            Me.OptInstrumentType.Text = "Type"
            Me.OptInstrumentType.UseVisualStyleBackColor = True
            '
            'PnlInstrumentCode
            '
            Me.PnlInstrumentCode.Controls.Add(Me.CmbInstrumentCode)
            Me.PnlInstrumentCode.Controls.Add(Me.Label8)
            Me.PnlInstrumentCode.Location = New System.Drawing.Point(105, 79)
            Me.PnlInstrumentCode.Name = "PnlInstrumentCode"
            Me.PnlInstrumentCode.Size = New System.Drawing.Size(256, 24)
            Me.PnlInstrumentCode.TabIndex = 16
            '
            'CmbInstrumentCode
            '
            Me.CmbInstrumentCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
            Me.CmbInstrumentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.CmbInstrumentCode.DisplayMember = ""
            Me.CmbInstrumentCode.Dock = System.Windows.Forms.DockStyle.Left
            Me.CmbInstrumentCode.Location = New System.Drawing.Point(63, 0)
            Me.CmbInstrumentCode.Name = "CmbInstrumentCode"
            Me.CmbInstrumentCode.Size = New System.Drawing.Size(146, 22)
            Me.CmbInstrumentCode.TabIndex = 7
            Me.CmbInstrumentCode.ValueMember = ""
            '
            'Label8
            '
            Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label8.Location = New System.Drawing.Point(0, 0)
            Me.Label8.Name = "Label8"
            Me.Label8.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
            Me.Label8.Size = New System.Drawing.Size(63, 24)
            Me.Label8.TabIndex = 8
            Me.Label8.Text = "Instrument"
            '
            'BtnRefresh
            '
            Me.BtnRefresh.AutoSize = True
            Me.BtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnRefresh.Image = Global.CoinsAndShares.My.Resources.Resources.arrow_circle_double_135
            Me.BtnRefresh.Location = New System.Drawing.Point(706, 236)
            Me.BtnRefresh.Name = "BtnRefresh"
            Me.BtnRefresh.Size = New System.Drawing.Size(72, 23)
            Me.BtnRefresh.TabIndex = 0
            Me.BtnRefresh.Text = "Refresh"
            Me.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnRefresh.UseVisualStyleBackColor = False
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.White
            Me.Panel2.Controls.Add(Me.BtnDelete)
            Me.Panel2.Controls.Add(Me.LblSelected)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Controls.Add(Me.LblTotalAmount)
            Me.Panel2.Controls.Add(Me.Label9)
            Me.Panel2.Controls.Add(Me.BtnExport)
            Me.Panel2.Controls.Add(Me.Label5)
            Me.Panel2.Controls.Add(Me.BtnEdit)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel2.Location = New System.Drawing.Point(0, 523)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
            Me.Panel2.Size = New System.Drawing.Size(784, 38)
            Me.Panel2.TabIndex = 7
            '
            'BtnDelete
            '
            Me.BtnDelete.AutoSize = True
            Me.BtnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
            Me.BtnDelete.Image = Global.CoinsAndShares.My.Resources.Resources.cross_script
            Me.BtnDelete.Location = New System.Drawing.Point(646, 5)
            Me.BtnDelete.Name = "BtnDelete"
            Me.BtnDelete.Size = New System.Drawing.Size(133, 28)
            Me.BtnDelete.TabIndex = 4
            Me.BtnDelete.Text = "&Delete Transactions"
            Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnDelete.UseVisualStyleBackColor = False
            '
            'LblSelected
            '
            Me.LblSelected.AutoSize = True
            Me.LblSelected.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblSelected.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblSelected.Location = New System.Drawing.Point(396, 5)
            Me.LblSelected.Name = "LblSelected"
            Me.LblSelected.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblSelected.Size = New System.Drawing.Size(66, 18)
            Me.LblSelected.TabIndex = 11
            Me.LblSelected.Text = "LblSelected"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Location = New System.Drawing.Point(338, 5)
            Me.Label3.Name = "Label3"
            Me.Label3.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
            Me.Label3.Size = New System.Drawing.Size(58, 18)
            Me.Label3.TabIndex = 10
            Me.Label3.Text = "Selected:"
            '
            'LblTotalAmount
            '
            Me.LblTotalAmount.AutoSize = True
            Me.LblTotalAmount.Dock = System.Windows.Forms.DockStyle.Left
            Me.LblTotalAmount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LblTotalAmount.Location = New System.Drawing.Point(247, 5)
            Me.LblTotalAmount.Name = "LblTotalAmount"
            Me.LblTotalAmount.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.LblTotalAmount.Size = New System.Drawing.Size(91, 18)
            Me.LblTotalAmount.TabIndex = 9
            Me.LblTotalAmount.Text = "LblTotalAmount"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label9.Location = New System.Drawing.Point(191, 5)
            Me.Label9.Name = "Label9"
            Me.Label9.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
            Me.Label9.Size = New System.Drawing.Size(56, 18)
            Me.Label9.TabIndex = 8
            Me.Label9.Text = "Amount:"
            '
            'BtnExport
            '
            Me.BtnExport.AutoSize = True
            Me.BtnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnExport.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnExport.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnExport.Image = Global.CoinsAndShares.My.Resources.Resources.database_share
            Me.BtnExport.Location = New System.Drawing.Point(125, 5)
            Me.BtnExport.Name = "BtnExport"
            Me.BtnExport.Size = New System.Drawing.Size(66, 28)
            Me.BtnExport.TabIndex = 7
            Me.BtnExport.Text = "Export"
            Me.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnExport.UseVisualStyleBackColor = False
            '
            'Label5
            '
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label5.Location = New System.Drawing.Point(120, 5)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(5, 28)
            Me.Label5.TabIndex = 6
            '
            'BtnEdit
            '
            Me.BtnEdit.AutoSize = True
            Me.BtnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Left
            Me.BtnEdit.Image = Global.CoinsAndShares.My.Resources.Resources.pencil
            Me.BtnEdit.Location = New System.Drawing.Point(5, 5)
            Me.BtnEdit.Name = "BtnEdit"
            Me.BtnEdit.Size = New System.Drawing.Size(115, 28)
            Me.BtnEdit.TabIndex = 5
            Me.BtnEdit.Text = "Edit Transaction"
            Me.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
            Me.BtnEdit.UseVisualStyleBackColor = False
            '
            'FAllTransactions
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.GrdTransactions)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "FAllTransactions"
            Me.Text = "Transaction History"
            CType(Me.GrdTransactions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.GroupBox5.ResumeLayout(False)
            Me.GroupBox5.PerformLayout()
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.TlpDates.ResumeLayout(False)
            Me.TlpDates.PerformLayout()
            Me.GroupBox4.ResumeLayout(False)
            CType(Me.CmbType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.PnlAccountSingle.ResumeLayout(False)
            CType(Me.CmbAccount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PnlAccountType.ResumeLayout(False)
            CType(Me.CmbAccountType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel2.PerformLayout()
            Me.PnlInstrumentType.ResumeLayout(False)
            CType(Me.CmbInstrumentTypeName, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PnlInstrumentCode.ResumeLayout(False)
            CType(Me.CmbInstrumentCode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GrdTransactions As Infragistics.Win.UltraWinGrid.UltraGrid
        Friend WithEvents Panel1 As Panel
        Friend WithEvents BtnRefresh As Button
        Friend WithEvents TxtDescription As TextBox
        Friend WithEvents DtpTo As DateTimePicker
        Friend WithEvents DtpFrom As DateTimePicker
        Friend WithEvents Label2 As Label
        Friend WithEvents Label1 As Label
        Friend WithEvents CmbAccount As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label4 As Label
        Friend WithEvents GroupBox2 As GroupBox
        Friend WithEvents OptAccountSingle As RadioButton
        Friend WithEvents OptAccountType As RadioButton
        Friend WithEvents OptAccountAll As RadioButton
        Friend WithEvents PnlAccountSingle As Panel
        Friend WithEvents PnlAccountType As Panel
        Friend WithEvents Label6 As Label
        Friend WithEvents CmbAccountType As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
        Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
        Friend WithEvents PnlInstrumentType As Panel
        Friend WithEvents CmbInstrumentTypeName As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label7 As Label
        Friend WithEvents OptInstrumentSingle As RadioButton
        Friend WithEvents OptInstrumentAll As RadioButton
        Friend WithEvents OptInstrumentLocalCurrency As RadioButton
        Friend WithEvents OptInstrumentType As RadioButton
        Friend WithEvents PnlInstrumentCode As Panel
        Friend WithEvents CmbInstrumentCode As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents Label8 As Label
        Friend WithEvents GroupBox1 As GroupBox
        Friend WithEvents GroupBox3 As GroupBox
        Friend WithEvents TlpDates As TableLayoutPanel
        Friend WithEvents GroupBox4 As GroupBox
        Friend WithEvents ChkAllDates As CheckBox
        Friend WithEvents Panel2 As Panel
        Friend WithEvents BtnEdit As Button
        Friend WithEvents BtnDelete As Button
        Friend WithEvents BtnExport As Button
        Friend WithEvents Label5 As Label
        Friend WithEvents LblTotalAmount As Label
        Friend WithEvents Label9 As Label
        Friend WithEvents GroupBox5 As GroupBox
        Friend WithEvents Label10 As Label
        Friend WithEvents CmbType As Infragistics.Win.UltraWinGrid.UltraCombo
        Friend WithEvents LblSelected As Label
        Friend WithEvents Label3 As Label
    End Class

End Namespace
