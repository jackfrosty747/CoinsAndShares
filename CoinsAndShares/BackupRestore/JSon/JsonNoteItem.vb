Namespace BackupRestore.JSon
    Public Class JsonNoteItem
        Public Sub Fill(id As Integer, noteTitle As String, noteBody As String)
            Me.Id = id
            Me.NoteTitle = noteTitle
            Me.NoteBody = noteBody
        End Sub

        Public Property Id As Integer
        Public Property NoteTitle As String
        Public Property NoteBody As String
    End Class

End Namespace
