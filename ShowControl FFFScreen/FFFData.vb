Imports System.IO
Imports System.Web

Public Class FFFData

    Friend Shared Mark1label As String = "A"
    Friend Shared Mark2label As String = "B"
    Friend Shared Mark3label As String = "C"
    Friend Shared Mark4label As String = "D"

    Friend Shared ContestantPosition As String = String.Empty
    Friend Shared ContestantNameLastname As String = String.Empty
    Friend Shared ContestantCity As String = String.Empty

    Friend Shared Question As String = String.Empty
    Friend Shared Answer1 As String = String.Empty
    Friend Shared Answer2 As String = String.Empty
    Friend Shared Answer3 As String = String.Empty
    Friend Shared Answer4 As String = String.Empty

    Friend Shared Property ContestantAnswerOrder As New List(Of String)
    Friend Shared FFFStopWatch As New Stopwatch

    Public Shared Sub InsertAnswerInOrder(answer As String)
        If Not ContestantAnswerOrder.Contains(answer) Then
            ContestantAnswerOrder.Add(answer)
        End If
    End Sub

    Public Shared Sub DataSetMarkAnswersLabels(mark1 As String, mark2 As String, mark3 As String, mark4 As String)
        Mark1label = mark1 '+ ":"
        Mark2label = mark2 '+ ":"
        Mark3label = mark3 '+ ":"
        Mark4label = mark4 '+ ":"
    End Sub

    Friend Shared Function ParseAnswer(mark As String)
        Select Case mark
            Case 1
                Return Mark1label
            Case 2
                Return Mark2label
            Case 3
                Return Mark3label
            Case 4
                Return Mark4label
            Case Else
                Return mark
        End Select
    End Function

    Friend Shared Sub ContestantLoad()
        Dim Message As String = HttpApiRequests.GetPostRequests.Get($"https://{My.Settings.StateDataIPAddress}/wwtbam-state/GetFFFPlayData.php?ContestantPosition={My.Settings.FFFPosition}")

        ContestantNameLastname = GetValueStringBetweenTags(Message, "<CONTESTANTNAME>", "</CONTESTANTNAME>")
        ContestantCity = GetValueStringBetweenTags(Message, "<CONTESTANTTOWN>", "</CONTESTANTTOWN>")
    End Sub

    Friend Shared Sub QuestionLoad(message As String)
        ResetFFFQuestionAnswers()
        Question = HttpUtility.HtmlDecode(GetValueStringBetweenTags(message, "<QUESTIONTEXT>", "</QUESTIONTEXT>"))
        Answer1 = HttpUtility.HtmlDecode(GetValueStringBetweenTags(message, "<ANSWER1TEXT>", "</ANSWER1TEXT>"))
        Answer2 = HttpUtility.HtmlDecode(GetValueStringBetweenTags(message, "<ANSWER2TEXT>", "</ANSWER2TEXT>"))
        Answer3 = HttpUtility.HtmlDecode(GetValueStringBetweenTags(message, "<ANSWER3TEXT>", "</ANSWER3TEXT>"))
        Answer4 = HttpUtility.HtmlDecode(GetValueStringBetweenTags(message, "<ANSWER4TEXT>", "</ANSWER4TEXT>"))
    End Sub

    Friend Shared Sub StopWatchFire()
        FFFStopWatch.Start()
    End Sub

    Friend Shared Sub ConfirmOrder(ByRef canDisable As Boolean)
        If ContestantAnswerOrder.Count = FFFGame.Default.CorrectAnswerOptionsCount And FFFStopWatch.Elapsed.TotalSeconds <= FFFGame.Default.GameDurationSeconds Then
            FFFStopWatch.Stop()
            canDisable = True

            Dim createText As String = String.Format(Date.Now.ToString("yyyy-MM-dd HH:mm:ss.ff") + " | FFF{0} ORDER: {1}{2}{3}{4} | Time: {5}", ContestantPosition, ContestantAnswerOrder.ElementAt(0), ContestantAnswerOrder.ElementAt(1), ContestantAnswerOrder.ElementAt(2), ContestantAnswerOrder.ElementAt(3), FFFStopWatch.Elapsed.TotalSeconds.ToString)
            Log.LogWrite(createText)

            OutMessageController.ConfirmFFForder(String.Format("{0}{1}{2}{3}", ContestantAnswerOrder.ElementAt(0), ContestantAnswerOrder.ElementAt(1), ContestantAnswerOrder.ElementAt(2), ContestantAnswerOrder.ElementAt(3)), FFFStopWatch.Elapsed.TotalSeconds.ToString)
        End If
    End Sub

    Friend Shared Sub ResetFFFClockAndOrder()
        ContestantAnswerOrder.Clear()
        FFFStopWatch.Reset()
    End Sub

    Friend Shared Sub ResetFFFQuestionAnswers()
        Question = String.Empty
        Answer1 = String.Empty
        Answer2 = String.Empty
        Answer3 = String.Empty
        Answer4 = String.Empty
    End Sub

    Public Shared Function GetValueStringBetweenTags(value As String, startTag As String, endTag As String) As String
        Try
            If value.ToUpper.Contains(startTag) And value.ToUpper.Contains(endTag) Then
                Dim Index As Integer = value.IndexOf(startTag) + startTag.Length
                Return value.Substring(Index, value.IndexOf(endTag) - Index)
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

End Class