Public Class GUIHelpers

    Public Shared Sub FitTextInsideControl(ByRef FormControl As System.Windows.Forms.Control, defaultFont As System.Drawing.Font)
        If String.IsNullOrEmpty(FormControl.Text) Then Return
        If IsShowingEllipsis(FormControl) Then
            FormControl.Font = New Font(FormControl.Font.FontFamily, FormControl.Font.Size - 0.1F, FormControl.Font.Style)
            FitTextInsideControl(FormControl, defaultFont)
        End If
    End Sub

    Public Shared Function IsShowingEllipsis(ByVal FormControl As System.Windows.Forms.Control) As Boolean
        Dim sz As Size = TextRenderer.MeasureText(FormControl.Text, FormControl.Font, FormControl.Size, TextFormatFlags.WordBreak)
        Return (sz.Width > FormControl.Size.Width OrElse sz.Height > FormControl.Size.Height)

    End Function

End Class

Public Class GUIDesignerPropertisContext

    Public Shared QuestionFontSize As Short = 28
    Public Shared AnswerFontSize As Short = 28
    Public Shared ExplanationFontSize As Short = 20
    Public Shared DirectorsChatFontSize As Short = 21
    Public Shared PronunciationFontSize As Short = 20
    Public Shared QuestionFontCutOff As Short = 1150
    Public Shared AnswerFontCutOff As Short = 550

    Public Shared DefaultQuestionFont = New Font(FontFamily.GenericSansSerif, QuestionFontSize)
    Public Shared DefaultAnswerFont = New Font(FontFamily.GenericSansSerif, AnswerFontSize)

    Shared Sub SetDesignerData(ScreenResolution As String)
        Select Case ScreenResolution.ToUpper.Trim
            Case "1080", "1080P", "FULLHD", "1920X1080"
                QuestionFontSize = 35
                AnswerFontSize = 35
                ExplanationFontSize = 32
                DirectorsChatFontSize = 34
                PronunciationFontSize = 28

                QuestionFontCutOff = 1490
                AnswerFontCutOff = 640

            Case "768", "720P", "HDREADY", "1366X768", "1280X720"
                QuestionFontSize = 28
                AnswerFontSize = 28
                ExplanationFontSize = 20
                DirectorsChatFontSize = 21
                PronunciationFontSize = 20

                QuestionFontCutOff = 1150
                AnswerFontCutOff = 550

        End Select

    End Sub

End Class