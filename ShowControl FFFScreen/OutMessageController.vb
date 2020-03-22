Imports System.Net.Sockets

Public Class OutMessageController

    Private Shared Host As String
    Private Shared Port As String

    Private Shared Message As New System.Text.StringBuilder

    Friend Shared Sub ConfirmFFForder(order As String, elapsedTime As String)

        ''http://127.0.0.1/wwtbam-state/postfffplaydata.php?contestantposition=1&givenanswer=3421&timeofanswer=5.670254
        Dim p = HttpApiRequests.GetPostRequests.Get($"https://{My.Settings.StateDataIPAddress}/wwtbam-state/PostFFFPlayData.php?ContestantPosition={My.Settings.FFFPosition}&GivenAnswer={order}&TimeOfAnswer={elapsedTime}")

    End Sub

    'Friend Shared Sub ConfirmFFForder_Old(order As String, elapsedTime As String)

    '    Message.Clear()
    '    Message.Append("<FFF-MESSAGE>")
    '    Message.Append("<MESSAGE-TYPE>FFFCONFIRMORDER</MESSAGE-TYPE>")
    '    Message.Append(String.Format("<POSITION>{0}</POSITION>", My.Settings.FFFPosition))
    '    Message.Append(String.Format("<ORDER>{0}</ORDER>", order))
    '    Message.Append(String.Format("<ELAPSEDTIME>{0}</ELAPSEDTIME>", elapsedTime))
    '    Message.Append("</FFF-MESSAGE>")

    '    ConnectAndSend(Message.ToString)
    'End Sub

#Region "TCP-METHODS"

    Friend Shared Sub PostFFFPlayData()

    End Sub

    'Friend Shared Sub ConnectAndSend(message As [String])
    '    Host = My.Settings.StateDataIPAddress
    '    Port = My.Settings.StateDataPort
    '    Try
    '        ' Create a TcpClient.
    '        ' Note, for this client to work you need to have a TcpServer 
    '        ' connected to the same address as specified by the server, port
    '        ' combination.
    '        'If Debugger.IsAttached Then server = "127.0.0.1"

    '        Dim port As Integer = OutMessageController.Port
    '        Dim client As New TcpClient(Host, port)
    '        client.SendBufferSize = Integer.MaxValue '???

    '        ' Translate the passed message into ASCII and store it as a Byte array.
    '        Dim data As [Byte]() = System.Text.Encoding.UTF8.GetBytes(message)

    '        ' Get a client stream for reading and writing.
    '        '  Stream stream = client.GetStream();
    '        Dim stream As NetworkStream = client.GetStream()

    '        ' Send the message to the connected TcpServer. 
    '        stream.Write(data, 0, data.Length)

    '        'Log.LogWrite(String.Format("Sent: {0}", message))
    '        'Console.WriteLine("Sent: {0}", message)

    '        '' Receive the TcpServer.response.
    '        '' Buffer to store the response bytes.
    '        'data = New [Byte](500000) {} 'New [Byte](256) {}

    '        '' String to store the response ASCII representation.
    '        'Dim responseData As [String] = [String].Empty

    '        '' Read the first batch of the TcpServer response bytes.
    '        'Dim bytes As Int32 = stream.Read(data, 0, data.Length)
    '        'responseData = System.Text.Encoding.UTF8.GetString(data, 0, bytes)
    '        ''Console.WriteLine("Received: {0}", responseData)

    '        ' Close everything.
    '        stream.Close()
    '        client.Close()
    '    Catch e As ArgumentNullException
    '        Log.LogWrite(String.Format("ArgumentNullException: {0}", e))
    '        'Console.WriteLine("ArgumentNullException: {0}", e)
    '    Catch e As SocketException
    '        Log.LogWrite(String.Format("SocketException: {0}", e))
    '        'Console.WriteLine("SocketException: {0}", e)
    '    End Try

    '    'Console.WriteLine(ControlChars.Cr + " Press Enter to continue...")
    '    'Console.Read()
    'End Sub


#End Region

End Class
