Public Class wait

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        RadialBar1.Value += 1
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 80 Then
            Timer1.Stop()
            fade.Close()
            Me.Close()
        End If
    End Sub
End Class