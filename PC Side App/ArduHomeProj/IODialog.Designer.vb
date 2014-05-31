<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IODialog
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
        Me.ReconForm1 = New ArduHomeProj.ReconForm
        Me.ReconGroupBox1 = New ArduHomeProj.ReconGroupBox
        Me.msgReceived = New System.Windows.Forms.RichTextBox
        Me.SezioneInvio = New ArduHomeProj.ReconGroupBox
        Me.ReconButton1 = New ArduHomeProj.ReconButton
        Me.msgText = New System.Windows.Forms.TextBox
        Me.ReconForm1.SuspendLayout()
        Me.ReconGroupBox1.SuspendLayout()
        Me.SezioneInvio.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReconForm1
        '
        Me.ReconForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.ReconForm1.Controls.Add(Me.ReconGroupBox1)
        Me.ReconForm1.Controls.Add(Me.SezioneInvio)
        Me.ReconForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReconForm1.ForeColor = System.Drawing.Color.Orange
        Me.ReconForm1.Image = Nothing
        Me.ReconForm1.Location = New System.Drawing.Point(0, 0)
        Me.ReconForm1.MoveHeight = 30
        Me.ReconForm1.Name = "ReconForm1"
        Me.ReconForm1.Resizable = True
        Me.ReconForm1.ShowIcon = False
        Me.ReconForm1.Size = New System.Drawing.Size(403, 533)
        Me.ReconForm1.TabIndex = 0
        Me.ReconForm1.Text = "Console"
        Me.ReconForm1.TextAlignment = ArduHomeProj.ReconForm.TextAlign.Left
        Me.ReconForm1.TransparencyKey = System.Drawing.Color.Fuchsia
        '
        'ReconGroupBox1
        '
        Me.ReconGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.ReconGroupBox1.Controls.Add(Me.msgReceived)
        Me.ReconGroupBox1.Location = New System.Drawing.Point(12, 117)
        Me.ReconGroupBox1.Name = "ReconGroupBox1"
        Me.ReconGroupBox1.NoRounding = False
        Me.ReconGroupBox1.Size = New System.Drawing.Size(379, 406)
        Me.ReconGroupBox1.TabIndex = 3
        Me.ReconGroupBox1.Text = "Sezione Ricezione"
        '
        'msgReceived
        '
        Me.msgReceived.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.msgReceived.Location = New System.Drawing.Point(8, 29)
        Me.msgReceived.Name = "msgReceived"
        Me.msgReceived.Size = New System.Drawing.Size(365, 371)
        Me.msgReceived.TabIndex = 0
        Me.msgReceived.Text = ""
        '
        'SezioneInvio
        '
        Me.SezioneInvio.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.SezioneInvio.Controls.Add(Me.ReconButton1)
        Me.SezioneInvio.Controls.Add(Me.msgText)
        Me.SezioneInvio.Location = New System.Drawing.Point(12, 40)
        Me.SezioneInvio.Name = "SezioneInvio"
        Me.SezioneInvio.NoRounding = False
        Me.SezioneInvio.Size = New System.Drawing.Size(379, 71)
        Me.SezioneInvio.TabIndex = 2
        Me.SezioneInvio.Text = "Sezione Invio"
        '
        'ReconButton1
        '
        Me.ReconButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReconButton1.ForeColor = System.Drawing.Color.DarkOrange
        Me.ReconButton1.Image = Nothing
        Me.ReconButton1.Location = New System.Drawing.Point(293, 35)
        Me.ReconButton1.Name = "ReconButton1"
        Me.ReconButton1.NoRounding = False
        Me.ReconButton1.Size = New System.Drawing.Size(75, 23)
        Me.ReconButton1.TabIndex = 1
        Me.ReconButton1.Text = "Invia"
        '
        'msgText
        '
        Me.msgText.Location = New System.Drawing.Point(14, 35)
        Me.msgText.Name = "msgText"
        Me.msgText.Size = New System.Drawing.Size(272, 20)
        Me.msgText.TabIndex = 0
        '
        'IODialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 533)
        Me.Controls.Add(Me.ReconForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "IODialog"
        Me.Text = "IODialog"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ReconForm1.ResumeLayout(False)
        Me.ReconGroupBox1.ResumeLayout(False)
        Me.SezioneInvio.ResumeLayout(False)
        Me.SezioneInvio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReconForm1 As ArduHomeProj.ReconForm
    Friend WithEvents ReconGroupBox1 As ArduHomeProj.ReconGroupBox
    Friend WithEvents msgReceived As System.Windows.Forms.RichTextBox
    Friend WithEvents SezioneInvio As ArduHomeProj.ReconGroupBox
    Friend WithEvents msgText As System.Windows.Forms.TextBox
    Friend WithEvents ReconButton1 As ArduHomeProj.ReconButton
End Class
