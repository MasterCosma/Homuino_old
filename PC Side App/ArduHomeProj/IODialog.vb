Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Imports System.Text
Public Class IODialog
    Private Sub ReconButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReconButton1.Click
        CommController.SerialIN.Write(msgText.Text)
    End Sub
    
End Class