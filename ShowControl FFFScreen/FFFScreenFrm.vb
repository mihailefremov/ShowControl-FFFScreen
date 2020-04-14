Imports System.Threading

Public Class FFFScreenFrm

    Public StateId As String = ""

    Friend Shared QuizOperatorDataToExecute As String = ""

    Public IsListenerAlive As Boolean = True

    Public messageQue As New Queue(Of String)

    Public ThreadListener As New Thread(AddressOf ListenAllTime)
    Public ThreadProcessData As New Thread(AddressOf ProcessData)

    Public Sub FFFScreenFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GUIConfigureMarkAnswers()

        ThreadListener.Start()
        ThreadProcessData.Start()

        MessageBox.Show(":: SERVER STARTED ::" & vbCrLf)

    End Sub

    Sub ListenAllTime()
        While True And IsListenerAlive
            Listen()
            Thread.Sleep(300)
        End While
    End Sub

    Sub ProcessData()
        Dim p As String
        While True
            If messageQue.Count > 0 Then
                p = messageQue.Dequeue
                If Not IsNothing(p) Then
                    OnLineReceivedQuizOperator(p)
                End If
            End If
            Thread.Sleep(100)
        End While
    End Sub

    Private Sub FFFScreenFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ThreadListener.Abort()
        ThreadProcessData.Abort()
    End Sub

    Overloads Sub Show(position As String)
        FFFData.ContestantPosition = position
        Show()
    End Sub
    Friend Sub Answer1_PlaceGfx_Click(sender As Object, e As MouseEventArgs) Handles Answer1_PlaceGfx.Click, MarkA_Label.Click, AnswerA_Label.Click
        Answer1_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("FinalAC")
        AnswerA_Label.ForeColor = Color.Black
        MarkA_Label.ForeColor = Color.White
        FFFData.InsertAnswerInOrder(1)
        ParseOrderIntoFields()
    End Sub
    Friend Sub Answer2_PlaceGfx_Click(sender As Object, e As EventArgs) Handles Answer2_PlaceGfx.Click, MarkB_Label.Click, AnswerB_Label.Click
        Answer2_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("FinalAC")
        AnswerB_Label.ForeColor = Color.Black
        MarkB_Label.ForeColor = Color.White
        FFFData.InsertAnswerInOrder(2)
        ParseOrderIntoFields()
    End Sub
    Friend Sub Answer3_PlaceGfx_Click(sender As Object, e As EventArgs) Handles Answer3_PlaceGfx.Click, MarkC_Label.Click, AnswerC_Label.Click
        Answer3_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("FinalAC")
        AnswerC_Label.ForeColor = Color.Black
        MarkC_Label.ForeColor = Color.White
        FFFData.InsertAnswerInOrder(3)
        ParseOrderIntoFields()
    End Sub
    Friend Sub Answer4_PlaceGfx_Click(sender As Object, e As EventArgs) Handles Answer4_PlaceGfx.Click, MarkD_Label.Click, AnswerD_Label.Click
        Answer4_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("FinalAC")
        AnswerD_Label.ForeColor = Color.Black
        MarkD_Label.ForeColor = Color.White
        FFFData.InsertAnswerInOrder(4)
        ParseOrderIntoFields()
    End Sub

    Friend Sub OK_Click(sender As Object, e As EventArgs) Handles OK_Label.Click, OKButton_Panel.Click
        WriteTickToConfirmClicking(True)
        Dim isOrderConfirmed As Boolean
        FFFData.ConfirmOrder(isOrderConfirmed)
        EnableDisableOKButton(Not isOrderConfirmed)
        EnableDisableDELButton(Not isOrderConfirmed)
    End Sub

    Friend Sub DeleteButton_Panel_MouseClick(sender As Object, e As MouseEventArgs) Handles DeleteButton_Panel.Click, Delete_Label.Click
        FFFData.ContestantAnswerOrder.Clear()
        GUIResetAnswerGraphicFields()
    End Sub

#Region "SERVER LISTENER"

    Public Sub Listen()

        Dim ReceivedData As String = HttpApiRequests.GetPostRequests.Get($"https://{My.Settings.StateDataIPAddress}/wwtbam-state/GetFFFPlayState.php")

        messageQue.Clear()
        messageQue.Enqueue(ReceivedData)

    End Sub

    Delegate Sub SetThisFormCloseCallback()
    Private Sub SetThisFormCloseThreadSafe()
        If Me.InvokeRequired Then
            Dim d As SetThisFormCloseCallback = New SetThisFormCloseCallback(AddressOf SetThisFormCloseThreadSafe)
            Me.Invoke(d)
        Else
            Me.Close()
        End If
    End Sub

    ' ALLOW THREAD TO COMMUNICATE WITH FORM CONTROL
    Private Delegate Sub UpdateTextDelegate(TB As Form, txt As String)

    ' UPDATE TEXTBOX
    Sub UpdateExecuteCommandText(TB As Form, txt As String)
        If TB.InvokeRequired Then
            TB.Invoke(New UpdateTextDelegate(AddressOf UpdateExecuteCommandText), New Object() {TB, txt})
        Else
            If txt IsNot Nothing Then
                'TB.AppendText(txt & vbCrLf)
                Try
                    ExecuteClientMessage(txt)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub

    ' UPDATE TEXT WHEN DATA IS RECEIVED
    Sub OnLineReceivedQuizOperator(Data As String)
        QuizOperatorDataToExecute = Data + vbCrLf

        Dim TimeStampFromData As String = FFFData.GetValueStringBetweenTags(QuizOperatorDataToExecute, "<STATEID>", "</STATEID>")
        If StateId = TimeStampFromData Then
            Exit Sub
        End If
        StateId = TimeStampFromData

        UpdateExecuteCommandText(Me, QuizOperatorDataToExecute)

    End Sub

#End Region

    Sub ExecuteClientMessage(Message As String)

        If Message.Trim() = "" Then Exit Sub
        If Not Message.Contains("<WWTBAM-FFFPLAY-STATE>") AndAlso Message.Contains("</WWTBAM-FFFPLAY-STATE>") Then Exit Sub

        Dim MessageType As String
        MessageType = FFFData.GetValueStringBetweenTags(Message, "<FFFPLAYSTATE>", "</FFFPLAYSTATE>")
        MessageType = MessageType.ToUpper

        Select Case MessageType
            Case "CONTESTANTNAMETOWN"
                FFFData.ContestantLoad()
                StandByContestantName()
            Case "STANDBYFFFGAME"
                StandByFFFGame()
            Case "READQ"
                FFFData.QuestionLoad(Message)
                GUIQuestionFire()
            Case "READQ1234READY"
                FFFData.QuestionLoad(Message)
                GUIQuestionFire()
                GUIThreeBeepsFire()
            Case "READQ1234"
                FFFData.QuestionLoad(Message)
                GUIQuestionFire()
                GUIFastestFingerFirstFire()
                'Case "RESETFFFGAME"
                '    'FFFData.ResetFFFClockAndOrder()
                '    'FFFData.ResetFFFQuestionAnswers()
                '    GUIResetLastFFFGame()
        End Select

    End Sub

#Region "MAIN METHODS"
    Friend Sub StandByContestantName()
        Dim Contestant As String = String.Format("{0}", FFFData.ContestantNameLastname)
        Dim City As String = FFFData.ContestantCity
        GUIResetLastFFFGame()
        GUIShowHideAnswerField(False)
        Question_Label.Text = UCase(Contestant + vbCrLf + City)
    End Sub

    Friend Sub StandByFFFGame()
        'GUIResetLastFFFGame() 'ne znam dali ovde treba da bide ova
        'GUIResetQATextFields()
        GUIShowHideQuestionField(True)
        GUIShowHideAnswerField(True)
        GUIEnableDisableAnswerField(False)
    End Sub

    Friend Sub GUIQuestionFire()
        GUIResetLastFFFGame()
        GUIShowHideAnswerField(True)
        GUIEnableDisableAnswerField(False)
        Question_Label.Text = FFFData.Question
        Question_Label.Font = GUIDesignerPropertisContext.DefaultQuestionFont
        GUIHelpers.FitTextInsideControl(Question_Label, GUIDesignerPropertisContext.DefaultQuestionFont)
    End Sub

    Friend Sub GUIThreeBeepsFire()
        GUIQuestionFire()
        AnswerA_Label.Text = FFFData.Answer1
        AnswerB_Label.Text = FFFData.Answer2
        AnswerC_Label.Text = FFFData.Answer3
        AnswerD_Label.Text = FFFData.Answer4

        AnswerA_Label.Font = GUIDesignerPropertisContext.DefaultAnswerFont
        AnswerB_Label.Font = GUIDesignerPropertisContext.DefaultAnswerFont
        AnswerC_Label.Font = GUIDesignerPropertisContext.DefaultAnswerFont
        AnswerD_Label.Font = GUIDesignerPropertisContext.DefaultAnswerFont

        GUIHelpers.FitTextInsideControl(AnswerA_Label, GUIDesignerPropertisContext.DefaultAnswerFont)
        GUIHelpers.FitTextInsideControl(AnswerB_Label, GUIDesignerPropertisContext.DefaultAnswerFont)
        GUIHelpers.FitTextInsideControl(AnswerC_Label, GUIDesignerPropertisContext.DefaultAnswerFont)
        GUIHelpers.FitTextInsideControl(AnswerD_Label, GUIDesignerPropertisContext.DefaultAnswerFont)
    End Sub

    Private Sub GUIFastestFingerFirstFire()
        GUIThreeBeepsFire()
        GUIEnableDisableAnswerField(True)
        FFFData.StopWatchFire()
        'TODO TIMER AKO NEMA ISPRATENO POGRESKA NISTO DA GO ISPRATI AVTOMATSKI POSLE 20 SEKUNDI
    End Sub

#End Region

#Region "HELPER METHODS"

    Friend Sub ParseOrderIntoFields()
        Select Case FFFData.ContestantAnswerOrder.Count
            Case 1
                AnsOrder1_Label.Text = FFFData.ParseAnswer(FFFData.ContestantAnswerOrder.ElementAt(0))
            Case 2
                AnsOrder2_Label.Text = FFFData.ParseAnswer(FFFData.ContestantAnswerOrder.ElementAt(1))
            Case 3
                AnsOrder3_Label.Text = FFFData.ParseAnswer(FFFData.ContestantAnswerOrder.ElementAt(2))
            Case 4
                AnsOrder4_Label.Text = FFFData.ParseAnswer(FFFData.ContestantAnswerOrder.ElementAt(3))
            Case 0
                AnsOrder1_Label.Text = ""
                AnsOrder2_Label.Text = ""
                AnsOrder3_Label.Text = ""
                AnsOrder4_Label.Text = ""
        End Select
    End Sub
    'https://www.iconsdb.com/orange-icons/two-fingers-icon.html icon ifle
    Friend Sub WriteTickToConfirmClicking(enable As Boolean)
        If enable Then
            OKButton_Panel.Enabled = False
            OK_Label.Enabled = False
            OK_Label.Text = "✔"
        End If
    End Sub

    Friend Sub EnableDisableOKButton(enable As Boolean)
        If enable Then
            OKButton_Panel.Enabled = True
            OK_Label.Enabled = True
            OK_Label.Text = "OK"
        Else
            OKButton_Panel.Enabled = False
            OK_Label.Enabled = False
            OK_Label.Text = "✔"
        End If
    End Sub

    Friend Sub EnableDisableDELButton(enable As Boolean)
        If enable Then
            DeleteButton_Panel.Enabled = True
            Delete_Label.Enabled = True
        Else
            DeleteButton_Panel.Enabled = False
            Delete_Label.Enabled = False
        End If
    End Sub
    Function CreateSuitableQuestionFontSize(textsizelimit As Integer, teksttonarrow As String) As Font
        'teksttonarrow = "tekst----------------------------------------------------------------------------------------------------"
        Dim myFont As Font = New Font("Arial", GUIDesignerPropertisContext.QuestionFontSize, FontStyle.Regular, GraphicsUnit.Point)
        Dim textSize = TextRenderer.MeasureText(teksttonarrow, myFont)
        Dim narrowFont As Font

        If teksttonarrow.Trim.Equals(String.Empty) Then Return myFont

        Dim makeFontLower As Int16 = 0
        If textSize.Width > textsizelimit Then
            Dim difference As Integer
            difference = textSize.Width - textsizelimit
            makeFontLower = difference / 50
        End If

        If makeFontLower > 13 Then
            makeFontLower = 13
        End If

        narrowFont = New Font("Arial", GUIDesignerPropertisContext.QuestionFontSize - makeFontLower, FontStyle.Regular, GraphicsUnit.Point)
        Return narrowFont
    End Function

    Function CreateSuitableAnswerFontSize(textsizelimit As Integer, teksttonarrow As String) As Font
        'teksttonarrow = "Answer::1-------------------------------------"
        Dim myFont As Font = New Font("Arial", GUIDesignerPropertisContext.AnswerFontSize, FontStyle.Regular, GraphicsUnit.Point)
        Dim textSize = TextRenderer.MeasureText(teksttonarrow, myFont)
        Dim narrowFont As Font

        If teksttonarrow.Trim.Equals(String.Empty) Then Return myFont

        Dim makeFontLower As Int16 = 0
        If textSize.Width > textsizelimit Then
            Dim difference As Integer
            difference = textSize.Width - textsizelimit
            makeFontLower = difference / 19
        End If

        If makeFontLower > 13 Then
            makeFontLower = 13
        End If

        narrowFont = New Font("Arial", GUIDesignerPropertisContext.AnswerFontSize - makeFontLower, FontStyle.Regular, GraphicsUnit.Point)
        Return narrowFont
    End Function

    Friend Sub GUIShowHideQuestionField(isVisible As Boolean)
        Question_Label.Visible = isVisible
    End Sub

    Friend Sub GUIShowHideAnswerField(isVisible As Boolean)
        Answer1_PlaceGfx.Visible = isVisible
        Answer2_PlaceGfx.Visible = isVisible
        Answer3_PlaceGfx.Visible = isVisible
        Answer4_PlaceGfx.Visible = isVisible
        AnsOrder1_Panel.Visible = isVisible
        AnsOrder2_Panel.Visible = isVisible
        AnsOrder3_Panel.Visible = isVisible
        AnsOrder4_Panel.Visible = isVisible
        LineAnswer1_PictureBox.Visible = isVisible
        LineAnswer2_PictureBox.Visible = isVisible
        LineAnswer3_PictureBox.Visible = isVisible
        LineAnswer4_PictureBox.Visible = isVisible
    End Sub

    Friend Sub GUIEnableDisableAnswerField(isEnabled As Boolean)
        Answer1_PlaceGfx.Enabled = isEnabled
        Answer2_PlaceGfx.Enabled = isEnabled
        Answer3_PlaceGfx.Enabled = isEnabled
        Answer4_PlaceGfx.Enabled = isEnabled
        AnswerA_Label.Enabled = isEnabled
        AnswerB_Label.Enabled = isEnabled
        AnswerC_Label.Enabled = isEnabled
        AnswerD_Label.Enabled = isEnabled
        MarkA_Label.Enabled = isEnabled
        MarkB_Label.Enabled = isEnabled
        MarkC_Label.Enabled = isEnabled
        MarkD_Label.Enabled = isEnabled
    End Sub

    Friend Sub GUIResetLastFFFGame()
        'FFFData.ResetFFFQuestionAnswers()
        FFFData.ResetFFFClockAndOrder()
        EnableDisableDELButton(True)
        EnableDisableOKButton(True)
        GUIResetQATextFields()
        GUIResetAnswerGraphicFields()
        GUIEnableDisableAnswerField(False)
    End Sub

    Friend Sub GUIResetAnswerGraphicFields()
        AnsOrder1_Label.Text = ""
        AnsOrder2_Label.Text = ""
        AnsOrder3_Label.Text = ""
        AnsOrder4_Label.Text = ""
        Answer1_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("AC")
        Answer2_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("AC")
        Answer3_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("AC")
        Answer4_PlaceGfx.BackgroundImage = My.Resources.ResourceManager.GetObject("AC")
        AnswerA_Label.ForeColor = Color.White
        AnswerB_Label.ForeColor = Color.White
        AnswerC_Label.ForeColor = Color.White
        AnswerD_Label.ForeColor = Color.White
        MarkA_Label.ForeColor = Color.Orange
        MarkB_Label.ForeColor = Color.Orange
        MarkC_Label.ForeColor = Color.Orange
        MarkD_Label.ForeColor = Color.Orange
        EnableDisableOKButton(True)
    End Sub

    Friend Sub GUIResetQATextFields()
        Question_Label.Text = String.Empty
        GUIResetAnswerTextFields()
    End Sub

    Friend Sub GUIResetAnswerTextFields()
        AnswerA_Label.Text = String.Empty
        AnswerB_Label.Text = String.Empty
        AnswerC_Label.Text = String.Empty
        AnswerD_Label.Text = String.Empty
    End Sub

    Private Sub GUIConfigureMarkAnswers()
        MarkA_Label.Text = FFFData.Mark1label + ":"
        MarkB_Label.Text = FFFData.Mark2label + ":"
        MarkC_Label.Text = FFFData.Mark3label + ":"
        MarkD_Label.Text = FFFData.Mark4label + ":"
    End Sub

#End Region

End Class