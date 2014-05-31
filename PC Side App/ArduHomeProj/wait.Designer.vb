<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wait
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ReconForm1 = New ArduHomeProj.ReconForm
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.RadialBar1 = New ArduHomeProj.RadialBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.ReconForm1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'ReconForm1
        '
        Me.ReconForm1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.ReconForm1.Controls.Add(Me.ProgressBar1)
        Me.ReconForm1.Controls.Add(Me.RadialBar1)
        Me.ReconForm1.Controls.Add(Me.Label1)
        Me.ReconForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReconForm1.ForeColor = System.Drawing.Color.Gold
        Me.ReconForm1.Image = Nothing
        Me.ReconForm1.Location = New System.Drawing.Point(0, 0)
        Me.ReconForm1.MoveHeight = 30
        Me.ReconForm1.Name = "ReconForm1"
        Me.ReconForm1.Resizable = True
        Me.ReconForm1.ShowIcon = False
        Me.ReconForm1.Size = New System.Drawing.Size(427, 208)
        Me.ReconForm1.TabIndex = 0
        Me.ReconForm1.Text = "Attendi..."
        Me.ReconForm1.TextAlignment = ArduHomeProj.ReconForm.TextAlign.Left
        Me.ReconForm1.TransparencyKey = System.Drawing.Color.Fuchsia
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(33, 163)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 2
        Me.ProgressBar1.Visible = False
        '
        'RadialBar1
        '
        Me.RadialBar1.Font = New System.Drawing.Font("Verdana", 14.0!)
        Me.RadialBar1.Location = New System.Drawing.Point(265, 44)
        Me.RadialBar1.Maximum = CType(50, Long)
        Me.RadialBar1.Name = "RadialBar1"
        Me.RadialBar1.Size = New System.Drawing.Size(150, 146)
        Me.RadialBar1.TabIndex = 1
        Me.RadialBar1.Text = "RadialBar1"
        Me.RadialBar1.Thickness = 20
        Me.RadialBar1.Value = CType(0, Long)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Aspetta 1 secondo prima di " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "eseguire un nuovo comando"
        '
        'wait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 208)
        Me.Controls.Add(Me.ReconForm1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "wait"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ReconForm1.ResumeLayout(False)
        Me.ReconForm1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReconForm1 As ArduHomeProj.ReconForm
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadialBar1 As ArduHomeProj.RadialBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
