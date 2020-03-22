Public Class Configuration

    Public QuizOperatorDataToExecute As String = ""

    Private Sub Configuration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OutgoingIPAddress_TextBox.Text = My.Settings.StateDataIPAddress
        OutgoingQOperatorPort_TextBox.Text = My.Settings.StateDataPort
        FFFPosition_ComboBox.SelectedIndex = My.Settings.FFFPosition

    End Sub

    Private Sub Configuration_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FFFScreenFrm.Close()

    End Sub

    Private Sub SaveNetworkSettings_Button_Click(sender As Object, e As EventArgs) Handles SaveNetworkSettings_Button.Click
        My.Settings.StateDataIPAddress = OutgoingIPAddress_TextBox.Text
        My.Settings.StateDataPort = OutgoingQOperatorPort_TextBox.Text
        My.Settings.FFFPosition = FFFPosition_ComboBox.SelectedIndex

        My.Settings.Save()
    End Sub

    Private Sub ResetNetworkSettings_Button_Click(sender As Object, e As EventArgs) Handles ResetNetworkSettings_Button.Click
        My.Settings.Reset()
        My.Settings.StateDataIPAddress = OutgoingIPAddress_TextBox.Text
        My.Settings.StateDataPort = OutgoingQOperatorPort_TextBox.Text
        My.Settings.FFFPosition = FFFPosition_ComboBox.SelectedIndex
    End Sub

    Private Sub ConfigureAndStart_Button_Click(sender As Object, e As EventArgs) Handles ConfigureAndStart_Button.Click
        If FFFScreenFrm.ThreadListener.IsAlive Then
            Dim n As String = MsgBox("Do you really want to restart the server?", MsgBoxStyle.YesNo, "ShowControl Screen")
            If Not n = vbYes Then
                Return
            End If
        End If
        If Application.OpenForms().OfType(Of FFFScreenFrm).Any Then
            FFFScreenFrm.Close()
        End If
        FFFScreenFrm.Show(FFFPosition_ComboBox.SelectedIndex)
    End Sub

    Public Sub WindowState_Label_Click(sender As Object, e As EventArgs) Handles WindowState_Label.Click
        If FFFScreenFrm.FormBorderStyle = FormBorderStyle.Sizable Then
            FFFScreenFrm.FormBorderStyle = FormBorderStyle.None
        ElseIf FFFScreenFrm.FormBorderStyle = FormBorderStyle.None Then
            FFFScreenFrm.FormBorderStyle = FormBorderStyle.Sizable
        End If
    End Sub

    Private Sub CheckServerStatus_LinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CheckServerStatus_LinkLabel.LinkClicked
        System.Diagnostics.Process.Start($"https://{My.Settings.StateDataIPAddress}/wwtbam-state/GetFFFPlayState.php")

    End Sub
End Class
