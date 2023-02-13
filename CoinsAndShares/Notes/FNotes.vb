Imports System.ComponentModel

Namespace Notes
    Friend Class FNotes
        Const MAX_TITLE_LENGTH = 20
        Const TAG_TITLE = "title"
        Const TAG_BODY = "body"

        Private ReadOnly m_commonObjects As CCommonObjects

        Private m_fChangesMade As Boolean
        Friend Sub New(commonObjects As CCommonObjects)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            m_commonObjects = commonObjects

            Icon = Icon.FromHandle(My.Resources.pencil.GetHicon)

            TabNotes.DrawMode = TabDrawMode.OwnerDrawFixed

            LoadData()

        End Sub
        Private Sub ChangesMade(f As Boolean)
            m_fChangesMade = f
            If f Then
                BtnSave.BackColor = Color.Red
                BtnSave.ForeColor = Color.Yellow
            Else
                BtnSave.BackColor = SystemColors.ButtonFace
                BtnSave.ForeColor = SystemColors.ControlText
            End If
        End Sub
        Private Sub LoadData()

            Const FONT_FAMILY = "Courier New"
            Const FONT_SIZE = 8

            TabNotes.Visible = False
            Try
                ' Initialise
                TabNotes.TabPages.Clear()

                ' Load data
                Dim all = m_commonObjects.Notes.GetAll

                ' Place onto screen
                For i = 1 To NOTE_COUNT
                    Dim iNoteId = i

                    Dim sTabCaption = $"Note {iNoteId}"
                    Dim sNoteTitle = String.Empty
                    Dim sNoteBody = String.Empty

                    Dim note = all.FirstOrDefault(Function(c) c.Id = iNoteId)
                    If note IsNot Nothing Then
                        If Not String.IsNullOrEmpty(note.NoteTitle) Then
                            sTabCaption = note.NoteTitle
                        End If
                        sNoteTitle = note.NoteTitle
                        sNoteBody = note.NoteBody
                    End If

                    If sTabCaption.Length > MAX_TITLE_LENGTH Then
                        sTabCaption = sTabCaption.Substring(0, MAX_TITLE_LENGTH)
                    End If

                    Dim tp = New TabPage With {
                        .Text = sTabCaption,
                        .Tag = iNoteId
                        }
                    TabNotes.TabPages.Add(tp)

                    Dim txtTitle = New TextBox With {
                        .Text = sNoteTitle,
                        .Dock = DockStyle.Top,
                        .Visible = True,
                        .Tag = TAG_TITLE,
                        .Font = New Font(FONT_FAMILY, FONT_SIZE, FontStyle.Bold)
                    }
                    AddHandler txtTitle.TextChanged, AddressOf Txt_Changed
                    tp.Controls.Add(txtTitle)

                    Dim txtBody = New TextBox With {
                    .Text = sNoteBody,
                    .Dock = DockStyle.Fill,
                    .Multiline = True,
                    .ScrollBars = ScrollBars.Vertical,
                    .Visible = True,
                    .Tag = TAG_BODY,
                    .Font = New Font(FONT_FAMILY, FONT_SIZE, FontStyle.Regular)
                }
                    AddHandler txtBody.TextChanged, AddressOf Txt_Changed
                    tp.Controls.Add(txtBody)
                    txtBody.BringToFront()
                Next

            Finally
                TabNotes.Visible = True
            End Try

            ChangesMade(False)
        End Sub

        Private Sub Txt_Changed(sender As Object, e As EventArgs)
            ChangesMade(True)
        End Sub

        Private Sub FNotes_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
            Try
                If m_fChangesMade Then
                    If MessageBox.Show("Save changes?", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                        SaveChanges()
                    End If
                End If
            Catch ex As Exception
                e.Cancel = True
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
        Private Sub SaveChanges()

            Dim all = New List(Of CNote)

            For Each tp In TabNotes.TabPages
                Dim tabPage = CType(tp, TabPage)

                Dim iPageId = CType(tabPage.Tag, Integer)
                Dim sNoteTitle = String.Empty
                Dim sNoteBody = String.Empty

                For Each ctl In tabPage.Controls
                    Dim txt = TryCast(ctl, TextBox)

                    If txt IsNot Nothing Then
                        If CType(txt.Tag, String) = TAG_TITLE Then
                            sNoteTitle = txt.Text
                        ElseIf CType(txt.Tag, String) = TAG_BODY Then
                            sNoteBody = txt.Text
                        End If
                    End If
                Next

                Dim note = New CNote(iPageId, sNoteTitle, sNoteBody)
                all.Add(note)
            Next

            m_commonObjects.Notes.SaveAll(all)

            LoadData()
        End Sub

        Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
            Try
                Close()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub

        Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
            Cursor = Cursors.WaitCursor
            Try
                SaveChanges()
            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub TabNotes_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabNotes.DrawItem
            Try
                Dim tabControl = CType(sender, TabControl)

                Dim tab = tabControl.TabPages(e.Index)

                Dim sNoteTitle = String.Empty
                Dim sNoteBody = String.Empty

                For Each ctl In tab.Controls
                    Dim txt = TryCast(ctl, TextBox)
                    If txt IsNot Nothing Then
                        If CType(txt.Tag, String) = TAG_TITLE Then
                            sNoteTitle = txt.Text
                        ElseIf CType(txt.Tag, String) = TAG_BODY Then
                            sNoteBody = txt.Text
                        End If
                    End If
                Next

                Using textbrush = New SolidBrush(Color.Black)
                    Dim itemrect = tabControl.GetTabRect(e.Index)

                    Dim cl = SystemColors.Control
                    Dim fs = FontStyle.Regular
                    If Not String.IsNullOrEmpty(sNoteTitle) OrElse Not String.IsNullOrEmpty(sNoteBody) Then
                        'fs = FontStyle.Bold
                        cl = Color.PaleGreen
                    End If
                    If Convert.ToBoolean(e.State And DrawItemState.Selected) Then
                        fs = FontStyle.Bold
                    End If

                    Dim bgBrush As New SolidBrush(cl)
                    e.Graphics.FillRectangle(bgBrush, itemrect)

                    Dim sf = New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }

                    Dim f = New Font(tabControl.Font, fs)
                    e.Graphics.DrawString(tab.Text, f, textbrush, itemrect, sf)

                End Using

            Catch ex As Exception
                m_commonObjects.Errors.Handle(ex)
            End Try
        End Sub
    End Class
End Namespace
