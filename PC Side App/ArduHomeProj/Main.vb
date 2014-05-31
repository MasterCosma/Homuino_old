Public Class Main

    Private Sub ReconButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReconButton11.Click
        If ReconButton11.Text = "Accendi" Then
            CommController.SerialIN.Write("101311")
            ReconButton11.Text = "Spegni"
            fade.Show()
            wait.Show()
        Else
            CommController.SerialIN.Write("101300")
            ReconButton11.Text = "Accendi"
            fade.Show()
            wait.Show()
        End If
    End Sub

    Private Sub ReconButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReconButton12.Click
        If ReconButton12.Text = "Accendi" Then
            CommController.SerialIN.Write("101211")
            ReconButton12.Text = "Spegni"
            fade.Show()
            wait.Show()
        Else
            CommController.SerialIN.Write("101200")
            ReconButton12.Text = "Accendi"
            fade.Show()
            wait.Show()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CommController.SerialIN.Write("101121")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CommController.SerialIN.Write("101120")
    End Sub
End Class