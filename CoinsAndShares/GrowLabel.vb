Friend Class GrowLabel : Inherits Label

    Private m_fGrowing As Boolean

    Public Sub New()
        InitializeComponent()
        AutoSize = False
    End Sub

    Private Sub ResizeLabel()
        If m_fGrowing Then
            Return
        End If
        Try
            m_fGrowing = True
            'Dim sz As New Size(Me.Width, Int32.MaxValue)
            'sz = TextRenderer.MeasureText(Me.Text, Me.Font, sz, TextFormatFlags.WordBreak)
            'Me.Height = sz.Height + Me.Padding.Vertical



            Dim g As Graphics = CreateGraphics()
            Dim sizeOfString As SizeF = g.MeasureString(Text, Font, Width - Padding.Horizontal)
            Height = CInt(sizeOfString.Height + Padding.Vertical)
        Finally
            m_fGrowing = False
        End Try
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        ResizeLabel()
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        ResizeLabel()
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        ResizeLabel()
    End Sub

    Protected Overrides Sub OnPaddingChanged(e As EventArgs)
        MyBase.OnPaddingChanged(e)
        ResizeLabel()
    End Sub

End Class
