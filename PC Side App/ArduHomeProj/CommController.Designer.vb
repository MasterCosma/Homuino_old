<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommController
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
        Me.components = New System.ComponentModel.Container
        Me.SerialIN = New System.IO.Ports.SerialPort(Me.components)
        Me.SerialOUT = New System.IO.Ports.SerialPort(Me.components)
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Alarm = New System.Windows.Forms.Timer(Me.components)
        Me.CheckAlarm = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'SerialIN
        '
        '
        'SerialOUT
        '
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(12, 398)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(117, 74)
        Me.RichTextBox2.TabIndex = 1
        Me.RichTextBox2.Text = ""
        Me.RichTextBox2.Visible = False
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(126, 398)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(117, 74)
        Me.RichTextBox3.TabIndex = 2
        Me.RichTextBox3.Text = ""
        Me.RichTextBox3.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Alarm
        '
        '
        'CheckAlarm
        '
        Me.CheckAlarm.Enabled = True
        Me.CheckAlarm.Interval = 4000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 25)
        Me.Label1.TabIndex = 15
        '
        'CommController
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(498, 484)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.RichTextBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CommController"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TransparencyKey = System.Drawing.SystemColors.ControlDarkDark
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialIN As System.IO.Ports.SerialPort
    Friend WithEvents SerialOUT As System.IO.Ports.SerialPort
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Alarm As System.Windows.Forms.Timer
    Friend WithEvents CheckAlarm As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
