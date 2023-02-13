Namespace Notes
    Friend Class CNote
        Friend ReadOnly Property Id As Integer
        Friend ReadOnly Property NoteTitle As String
        Friend ReadOnly Property NoteBody As String
        Friend Sub New(id As Integer, noteTitle As String, noteBody As String)
            Me.Id = id
            Me.NoteTitle = noteTitle
            Me.NoteBody = noteBody
        End Sub
    End Class
End Namespace
