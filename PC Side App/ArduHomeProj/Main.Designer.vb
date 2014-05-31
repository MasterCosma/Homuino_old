<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.ReconButton12 = New ArduHomeProj.ReconButton1
        Me.ReconButton11 = New ArduHomeProj.ReconButton1
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 30
        '
        'Timer2
        '
        Me.Timer2.Interval = 30
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(555, 178)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Fade On"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(649, 178)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Fade Stop"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ReconButton12
        '
        Me.ReconButton12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReconButton12.Font = New System.Drawing.Font("LuzSans-Book", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReconButton12.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.ReconButton12.Image = Nothing
        Me.ReconButton12.Location = New System.Drawing.Point(297, 76)
        Me.ReconButton12.Name = "ReconButton12"
        Me.ReconButton12.NoRounding = False
        Me.ReconButton12.Size = New System.Drawing.Size(196, 174)
        Me.ReconButton12.TabIndex = 1
        Me.ReconButton12.Text = "Accendi"
        '
        'ReconButton11
        '
        Me.ReconButton11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReconButton11.Font = New System.Drawing.Font("LuzSans-Book", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReconButton11.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.ReconButton11.Image = Nothing
        Me.ReconButton11.Location = New System.Drawing.Point(86, 76)
        Me.ReconButton11.Name = "ReconButton11"
        Me.ReconButton11.NoRounding = False
        Me.ReconButton11.Size = New System.Drawing.Size(196, 174)
        Me.ReconButton11.TabIndex = 0
        Me.ReconButton11.Text = "Accendi"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(962, 584)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ReconButton12)
        Me.Controls.Add(Me.ReconButton11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReconButton11 As ArduHomeProj.ReconButton1
    Friend WithEvents ReconButton12 As ArduHomeProj.ReconButton1
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
