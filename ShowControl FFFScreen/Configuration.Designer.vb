<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuration))
        Me.ConfigureAndStart_Button = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ResetNetworkSettings_Button = New System.Windows.Forms.Label()
        Me.SaveNetworkSettings_Button = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FFFPosition_ComboBox = New System.Windows.Forms.ComboBox()
        Me.WindowState_Label = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ScreenResoultion_ComboBox = New System.Windows.Forms.ComboBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OutgoingIPAddress_TextBox = New System.Windows.Forms.TextBox()
        Me.OutgoingQOperatorPort_TextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MessageTextBox = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckServerStatus_LinkLabel = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConfigureAndStart_Button
        '
        Me.ConfigureAndStart_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ConfigureAndStart_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfigureAndStart_Button.ForeColor = System.Drawing.Color.Green
        Me.ConfigureAndStart_Button.Location = New System.Drawing.Point(6, 262)
        Me.ConfigureAndStart_Button.Name = "ConfigureAndStart_Button"
        Me.ConfigureAndStart_Button.Size = New System.Drawing.Size(148, 36)
        Me.ConfigureAndStart_Button.TabIndex = 26
        Me.ConfigureAndStart_Button.Text = "Start"
        Me.ConfigureAndStart_Button.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"None", "Sizable"})
        Me.ComboBox1.Location = New System.Drawing.Point(134, 55)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(149, 28)
        Me.ComboBox1.TabIndex = 25
        Me.ComboBox1.Text = "None"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(43, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 20)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Resolution"
        '
        'ResetNetworkSettings_Button
        '
        Me.ResetNetworkSettings_Button.AutoSize = True
        Me.ResetNetworkSettings_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetNetworkSettings_Button.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ResetNetworkSettings_Button.Location = New System.Drawing.Point(443, 110)
        Me.ResetNetworkSettings_Button.Name = "ResetNetworkSettings_Button"
        Me.ResetNetworkSettings_Button.Size = New System.Drawing.Size(52, 20)
        Me.ResetNetworkSettings_Button.TabIndex = 25
        Me.ResetNetworkSettings_Button.Text = "Reset"
        '
        'SaveNetworkSettings_Button
        '
        Me.SaveNetworkSettings_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SaveNetworkSettings_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveNetworkSettings_Button.ForeColor = System.Drawing.Color.Goldenrod
        Me.SaveNetworkSettings_Button.Location = New System.Drawing.Point(363, 102)
        Me.SaveNetworkSettings_Button.Name = "SaveNetworkSettings_Button"
        Me.SaveNetworkSettings_Button.Size = New System.Drawing.Size(64, 36)
        Me.SaveNetworkSettings_Button.TabIndex = 24
        Me.SaveNetworkSettings_Button.Text = "Save"
        Me.SaveNetworkSettings_Button.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FFFPosition_ComboBox)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(363, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 63)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Position"
        '
        'FFFPosition_ComboBox
        '
        Me.FFFPosition_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FFFPosition_ComboBox.FormattingEnabled = True
        Me.FFFPosition_ComboBox.Items.AddRange(New Object() {"FFF-None", "FFF-01", "FFF-02", "FFF-03", "FFF-04", "FFF-05", "FFF-06", "FFF-07", "FFF-08", "FFF-09", "FFF-10"})
        Me.FFFPosition_ComboBox.Location = New System.Drawing.Point(6, 21)
        Me.FFFPosition_ComboBox.Name = "FFFPosition_ComboBox"
        Me.FFFPosition_ComboBox.Size = New System.Drawing.Size(143, 28)
        Me.FFFPosition_ComboBox.TabIndex = 0
        '
        'WindowState_Label
        '
        Me.WindowState_Label.AutoSize = True
        Me.WindowState_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowState_Label.Location = New System.Drawing.Point(13, 58)
        Me.WindowState_Label.Name = "WindowState_Label"
        Me.WindowState_Label.Size = New System.Drawing.Size(108, 20)
        Me.WindowState_Label.TabIndex = 26
        Me.WindowState_Label.Text = "Window State"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.WindowState_Label)
        Me.TabPage2.Controls.Add(Me.ComboBox1)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.ScreenResoultion_ComboBox)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(632, 173)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Screen Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ScreenResoultion_ComboBox
        '
        Me.ScreenResoultion_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScreenResoultion_ComboBox.FormattingEnabled = True
        Me.ScreenResoultion_ComboBox.Items.AddRange(New Object() {"1280x720", "1366x768", "1920x1080"})
        Me.ScreenResoultion_ComboBox.Location = New System.Drawing.Point(134, 16)
        Me.ScreenResoultion_ComboBox.Name = "ScreenResoultion_ComboBox"
        Me.ScreenResoultion_ComboBox.Size = New System.Drawing.Size(149, 28)
        Me.ScreenResoultion_ComboBox.TabIndex = 23
        Me.ScreenResoultion_ComboBox.Text = "1366x768"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.OutgoingIPAddress_TextBox)
        Me.TabPage1.Controls.Add(Me.OutgoingQOperatorPort_TextBox)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.MessageTextBox)
        Me.TabPage1.Controls.Add(Me.ResetNetworkSettings_Button)
        Me.TabPage1.Controls.Add(Me.SaveNetworkSettings_Button)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(632, 173)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Network Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 20)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Outgoing IP Address"
        '
        'OutgoingIPAddress_TextBox
        '
        Me.OutgoingIPAddress_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutgoingIPAddress_TextBox.Location = New System.Drawing.Point(178, 35)
        Me.OutgoingIPAddress_TextBox.Name = "OutgoingIPAddress_TextBox"
        Me.OutgoingIPAddress_TextBox.Size = New System.Drawing.Size(149, 26)
        Me.OutgoingIPAddress_TextBox.TabIndex = 27
        Me.OutgoingIPAddress_TextBox.Text = "127.0.0.1"
        Me.OutgoingIPAddress_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'OutgoingQOperatorPort_TextBox
        '
        Me.OutgoingQOperatorPort_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutgoingQOperatorPort_TextBox.Location = New System.Drawing.Point(178, 72)
        Me.OutgoingQOperatorPort_TextBox.Name = "OutgoingQOperatorPort_TextBox"
        Me.OutgoingQOperatorPort_TextBox.Size = New System.Drawing.Size(149, 26)
        Me.OutgoingQOperatorPort_TextBox.TabIndex = 29
        Me.OutgoingQOperatorPort_TextBox.Text = "443"
        Me.OutgoingQOperatorPort_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(65, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 20)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Outgoing Port"
        '
        'MessageTextBox
        '
        Me.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MessageTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageTextBox.Location = New System.Drawing.Point(243, 119)
        Me.MessageTextBox.Name = "MessageTextBox"
        Me.MessageTextBox.Size = New System.Drawing.Size(84, 19)
        Me.MessageTextBox.TabIndex = 26
        Me.MessageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 44)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(640, 199)
        Me.TabControl1.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(446, 25)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Fastest Finger First Configuration Wizard"
        '
        'CheckServerStatus_LinkLabel
        '
        Me.CheckServerStatus_LinkLabel.AutoSize = True
        Me.CheckServerStatus_LinkLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CheckServerStatus_LinkLabel.LinkColor = System.Drawing.Color.DarkGray
        Me.CheckServerStatus_LinkLabel.Location = New System.Drawing.Point(487, 262)
        Me.CheckServerStatus_LinkLabel.Name = "CheckServerStatus_LinkLabel"
        Me.CheckServerStatus_LinkLabel.Size = New System.Drawing.Size(155, 20)
        Me.CheckServerStatus_LinkLabel.TabIndex = 27
        Me.CheckServerStatus_LinkLabel.TabStop = True
        Me.CheckServerStatus_LinkLabel.Text = "Check Server Status"
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 319)
        Me.Controls.Add(Me.CheckServerStatus_LinkLabel)
        Me.Controls.Add(Me.ConfigureAndStart_Button)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Configuration"
        Me.Text = "FFFConfiguration"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConfigureAndStart_Button As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ResetNetworkSettings_Button As Label
    Friend WithEvents SaveNetworkSettings_Button As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents WindowState_Label As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ScreenResoultion_ComboBox As ComboBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Label6 As Label
    Friend WithEvents FFFPosition_ComboBox As ComboBox
    Friend WithEvents MessageTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents OutgoingIPAddress_TextBox As TextBox
    Friend WithEvents OutgoingQOperatorPort_TextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckServerStatus_LinkLabel As LinkLabel
End Class
