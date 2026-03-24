Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class HintTextBox : Inherits TextBox

    ' --- Properties ---
    Private _hintText As String = "Enter text..."

    <Category("Appearance")>
    <Description("The ghost text that appears when the box is empty.")>
    Public Property HintText As String
        Get
            Return _hintText
        End Get
        Set(value As String)
            _hintText = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Behavior")>
    <Description("If true, double-clicking the box opens a large pop-up editor.")>
    Public Property EnableLargeEditor As Boolean = True

    <Category("Appearance")>
    <Description("The title of the pop-up editor window.")>
    Public Property EditorTitle As String = "Edit Content"

    ' --- Double Click Logic ---
    Protected Overrides Sub OnDoubleClick(e As EventArgs)
        MyBase.OnDoubleClick(e)

        If EnableLargeEditor Then
            OpenEditor()
        End If
    End Sub

    Private Sub OpenEditor()
        ' Create a dynamic form on the fly
        Using editorForm As New Form()
            Dim txtBig As New TextBox()

            ' 1. Configure Form
            editorForm.Text = Me.EditorTitle
            editorForm.Size = New Size(600, 450)
            editorForm.StartPosition = FormStartPosition.CenterParent
            editorForm.MinimizeBox = False
            editorForm.MaximizeBox = True ' Allow maximizing for long comments
            editorForm.FormBorderStyle = FormBorderStyle.SizableToolWindow
            editorForm.Font = Me.Font ' Match the font of the parent form

            ' Control panel at the bottom for buttons
            Dim pnlControl As New Panel
            pnlControl.Dock = DockStyle.Bottom
            pnlControl.Height = 38
            pnlControl.Padding = New Padding(5)
            pnlControl.BackColor = Color.White

            ' OK
            Dim btnOK = New Button
            btnOK.Text = "OK"
            btnOK.Dock = DockStyle.Left
            btnOK.AutoSize = True
            btnOK.AutoSizeMode = AutoSizeMode.GrowAndShrink
            btnOK.Image = My.Resources.tick_circle_frame
            btnOK.TextImageRelation = TextImageRelation.ImageBeforeText
            btnOK.BackColor = Color.FromKnownColor(KnownColor.ControlLight)
            btnOK.DialogResult = DialogResult.OK

            pnlControl.Controls.Add(btnOK)

            ' Cancel
            Dim btnCancel = New Button
            btnCancel.Text = "Cancel"
            btnCancel.Dock = DockStyle.Right
            btnCancel.AutoSize = True
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink
            btnCancel.Image = My.Resources.cross_circle_frame
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText
            btnCancel.BackColor = Color.FromKnownColor(KnownColor.ControlLight)
            btnCancel.DialogResult = DialogResult.Cancel

            pnlControl.Controls.Add(btnCancel)

            ' 4. Configure Large TextBox
            txtBig.Multiline = True
            txtBig.AcceptsReturn = True ' FIX: Allows "Enter" for new lines
            txtBig.AcceptsTab = True    ' Allows "Tab" for indenting
            txtBig.ScrollBars = ScrollBars.Vertical
            txtBig.Dock = DockStyle.Fill
            txtBig.Text = Me.Text
            txtBig.Font = New Font(Font.FontFamily, 10.5F) ' Slightly larger for readability

            ' 5. Assemble Controls
            editorForm.Controls.Add(txtBig)
            editorForm.Controls.Add(pnlControl)

            ' Map Enter to the OK button ONLY if not inside the textbox
            ' Since AcceptsReturn is True, the TextBox will "steal" the Enter key correctly
            editorForm.AcceptButton = btnOK
            editorForm.CancelButton = btnCancel

            ' Show it and check result
            If editorForm.ShowDialog() = DialogResult.OK Then
                Me.Text = txtBig.Text
                ' Move cursor to end of text in the original box
                Me.SelectionStart = Me.Text.Length
            End If
        End Using
    End Sub

    ' --- Painting Logic for the Hint ---
    ' This draws the hint text manually when the box is empty and not focused
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        ' WM_PAINT = 0xF
        If m.Msg = &HF AndAlso String.IsNullOrEmpty(Me.Text) AndAlso Not Me.Focused Then
            Using g As Graphics = Me.CreateGraphics()
                ' Define where the text should be drawn
                Dim rect As New Rectangle(3, 3, Me.Width - 5, Me.Height - 5)

                ' Draw the text using the standard Windows text renderer
                TextRenderer.DrawText(g, _hintText, Me.Font, rect, Color.Gray, TextFormatFlags.Top Or TextFormatFlags.Left)
            End Using
        End If
    End Sub
End Class
