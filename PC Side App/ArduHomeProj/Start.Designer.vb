<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Start
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComPort1 = New System.Windows.Forms.ComboBox
        Me.ComBaud1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New ArduHomeProj.ReconGroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComPort = New System.Windows.Forms.ComboBox
        Me.ComBaud = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ReconButton1 = New ArduHomeProj.ReconButton
        Me.btnConnect = New ArduHomeProj.ReconButton
        Me.ReconForm1.SuspendLayout()
        Me.ReconGroupBox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReconForm1
        '
        Me.ReconForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.ReconForm1.Controls.Add(Me.ReconGroupBox1)
        Me.ReconForm1.Controls.Add(Me.GroupBox1)
        Me.ReconForm1.Controls.Add(Me.ReconButton1)
        Me.ReconForm1.Controls.Add(Me.btnConnect)
        Me.ReconForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReconForm1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ReconForm1.Image = Nothing
        Me.ReconForm1.Location = New System.Drawing.Point(0, 0)
        Me.ReconForm1.MoveHeight = 30
        Me.ReconForm1.Name = "ReconForm1"
        Me.ReconForm1.Resizable = True
        Me.ReconForm1.ShowIcon = False
        Me.ReconForm1.Size = New System.Drawing.Size(415, 339)
        Me.ReconForm1.TabIndex = 0
        Me.ReconForm1.Text = "ArduHome"
        Me.ReconForm1.TextAlignment = ArduHomeProj.ReconForm.TextAlign.Left
        Me.ReconForm1.TransparencyKey = System.Drawing.Color.Fuchsia
        '
        'ReconGroupBox1
        '
        Me.ReconGroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.ReconGroupBox1.Controls.Add(Me.Label3)
        Me.ReconGroupBox1.Controls.Add(Me.ComPort1)
        Me.ReconGroupBox1.Controls.Add(Me.ComBaud1)
        Me.ReconGroupBox1.Controls.Add(Me.Label4)
        Me.ReconGroupBox1.Location = New System.Drawing.Point(12, 158)
        Me.ReconGroupBox1.Name = "ReconGroupBox1"
        Me.ReconGroupBox1.NoRounding = False
        Me.ReconGroupBox1.Size = New System.Drawing.Size(391, 111)
        Me.ReconGroupBox1.TabIndex = 14
        Me.ReconGroupBox1.Text = "Seriale BitVoicer (Virtuale)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Porta COM"
        '
        'ComPort1
        '
        Me.ComPort1.FormattingEnabled = True
        Me.ComPort1.Location = New System.Drawing.Point(96, 34)
        Me.ComPort1.Name = "ComPort1"
        Me.ComPort1.Size = New System.Drawing.Size(285, 21)
        Me.ComPort1.TabIndex = 6
        '
        'ComBaud1
        '
        Me.ComBaud1.FormattingEnabled = True
        Me.ComBaud1.Location = New System.Drawing.Point(96, 79)
        Me.ComBaud1.Name = "ComBaud1"
        Me.ComBaud1.Size = New System.Drawing.Size(285, 21)
        Me.ComBaud1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Baud Rate"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComPort)
        Me.GroupBox1.Controls.Add(Me.ComBaud)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.NoRounding = False
        Me.GroupBox1.Size = New System.Drawing.Size(391, 111)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.Text = "Seriale Arduino"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Porta COM"
        '
        'ComPort
        '
        Me.ComPort.FormattingEnabled = True
        Me.ComPort.Location = New System.Drawing.Point(96, 34)
        Me.ComPort.Name = "ComPort"
        Me.ComPort.Size = New System.Drawing.Size(285, 21)
        Me.ComPort.TabIndex = 6
        '
        'ComBaud
        '
        Me.ComBaud.FormattingEnabled = True
        Me.ComBaud.Location = New System.Drawing.Point(96, 79)
        Me.ComBaud.Name = "ComBaud"
        Me.ComBaud.Size = New System.Drawing.Size(285, 21)
        Me.ComBaud.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Baud Rate"
        '
        'ReconButton1
        '
        Me.ReconButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReconButton1.ForeColor = System.Drawing.Color.SteelBlue
        Me.ReconButton1.Image = Nothing
        Me.ReconButton1.Location = New System.Drawing.Point(381, 3)
        Me.ReconButton1.Name = "ReconButton1"
        Me.ReconButton1.NoRounding = False
        Me.ReconButton1.Size = New System.Drawing.Size(22, 23)
        Me.ReconButton1.TabIndex = 12
        Me.ReconButton1.Text = "X"
        '
        'btnConnect
        '
        Me.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConnect.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnConnect.Image = Nothing
        Me.btnConnect.Location = New System.Drawing.Point(239, 277)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.NoRounding = False
        Me.btnConnect.Size = New System.Drawing.Size(164, 50)
        Me.btnConnect.TabIndex = 10
        Me.btnConnect.Text = "Connetti ad ArduHome"
        '
        'Start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 339)
        Me.ControlBox = False
        Me.Controls.Add(Me.ReconForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Start"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ReconForm1.ResumeLayout(False)
        Me.ReconGroupBox1.ResumeLayout(False)
        Me.ReconGroupBox1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReconForm1 As ArduHomeProj.ReconForm
    Friend WithEvents btnConnect As ArduHomeProj.ReconButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComBaud As System.Windows.Forms.ComboBox
    Friend WithEvents ComPort As System.Windows.Forms.ComboBox
    Friend WithEvents ReconButton1 As ArduHomeProj.ReconButton
    Friend WithEvents GroupBox1 As ArduHomeProj.ReconGroupBox
    Friend WithEvents ReconGroupBox1 As ArduHomeProj.ReconGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComPort1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComBaud1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
