Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports  ' Libreria COM
Imports System.Text
Imports System.IO

Delegate Sub SetTextCallback(ByVal [text] As String)


Public Class CommController
    Dim buffer As Byte()
    Dim COMtext As String
    Dim BitText As String
    Dim Decoded As StringBuilder
#Region "Serial Interface"
    Private Sub CommController_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialIN.PortName = My.Settings.COMPort
        SerialIN.BaudRate = My.Settings.COMBaud
        SerialOUT.PortName = My.Settings.VirtualPort
        SerialOUT.BaudRate = My.Settings.VirtualRate
        SerialIN.Open()
        SerialOUT.Open()
        IODialog.Show()
        Main.Show()
    End Sub

    Private Sub SerialIN_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialIN.DataReceived
        COMtext = SerialIN.ReadLine
        ReceivedTextIN(COMtext)
    End Sub

    Private Sub SerialOUT_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialOUT.DataReceived

        Dim byte1 As Byte = SerialOUT.ReadByte
        Dim byte2 As Byte = SerialOUT.ReadByte
        Dim byte3 As Byte = SerialOUT.ReadByte
        Dim byte4 As Byte = SerialOUT.ReadByte
        Dim byte5 As Byte = SerialOUT.ReadByte
        Dim byte6 As Byte = SerialOUT.ReadByte
        Dim byte7 As Byte = SerialOUT.ReadByte
        Dim byte8 As Byte = SerialOUT.ReadByte

        BitText = Convert.ToChar(byte4) & Convert.ToChar(byte5) & Convert.ToChar(byte6) _
        & Convert.ToChar(byte7)
        MsgBox(BitText)
        SerialIN.WriteLine(BitText)
        'ReceivedTextOUT(SerialOUT.ReadExisting)
    End Sub

    Private Sub ReceivedTextIN(ByVal [text] As String)
        If Me.RichTextBox2.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedTextIN)
            Me.Invoke(x, New Object() {(text)})
        Else
            RichTextBox1.AppendText([text])
            CheckInput()
            IODialog.msgReceived.AppendText("Serial IN : " & [text] & vbCr)
        End If
    End Sub

    Private Sub ReceivedTextOUT(ByVal [text] As String)
        If Me.RichTextBox3.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedTextOUT)
            Me.Invoke(x, New Object() {(text)})
        Else
            SerialIN.WriteLine([text])
            IODialog.msgReceived.AppendText("Serial OUT : " & [text] & vbCr)
        End If
    End Sub
    

#End Region

#Region "INPUT CHECK"
    ' TABELLA CODICI
    ' Tipo dati ingresso : A = Alert (Avvertimento)
    '                      C = Command (Comando)
    '                      T = Temperature

    Dim CheckTries As Integer = 0
    Dim temp As Integer
    Public Sub CheckInput()

        If COMtext.Length > 0 Then ' Un piccolo debug
            If COMtext(0) = "C" Then ' controlla se è Comando
                If COMtext(1) = "C" Then
                    If COMtext(2) = "1" Then
                        MsgBox("E' notte")
                        Clear()
                        CheckTries = 0
                    ElseIf COMtext(2) = "0" Then
                        MsgBox("E' giorno")
                        Clear()
                        CheckTries = 0
                    End If
                End If
            ElseIf RichTextBox1.SelectedText = "A" Then
                RichTextBox1.Select(1, 2)
                If RichTextBox1.SelectedText = "CA" Then
                    Clear()
                    My.Computer.Audio.Play("H:\Voices\ACA.wav", AudioPlayMode.Background)
                    CheckTries = 0
                End If
                If RichTextBox1.SelectedText = "OK" Then
                    Clear()
                    My.Computer.Audio.Play("H:\Voices\ok.wav", AudioPlayMode.Background)
                    CheckTries = 0
                End If
            ElseIf RichTextBox1.SelectedText = "T" Then ' controlla se è Temperatura
                RichTextBox1.Select(3, 1)
                If RichTextBox1.SelectedText = "R" Then ' controlla se è richiesta => Sintesi vocale
                    RichTextBox1.Select(1, 2) ' Seleziona la temperatura
                    temp = RichTextBox1.SelectedText
                    Clear() ' Pulisce preventivamente per altri messaggi
                    MsgBox("Temperatura : " & temp & "°C", MsgBoxStyle.Information, "TEMPERATURA")
                    My.Computer.Audio.Play("H:\Voices\temp" & temp & ".wav", AudioPlayMode.Background) ' Ricorda di mettere condizione o TRY
                    CheckTries = 0 ' Operazione effettuata correttamente => Tentativi check azzerati
                ElseIf RichTextBox1.SelectedText = "U" Then ' controlla se non è richiesta
                    RichTextBox1.Select(1, 2) ' Seleziona la temperatura 
                    temp = RichTextBox1.SelectedText
                    Clear() ' Pulisce preventivamente per altri messaggi
                    MsgBox("Temperatura : " & temp & "°C", MsgBoxStyle.Information, "TEMPERATURA")
                    CheckTries = 0  ' Operazione effettuata correttamente => Tentativi check azzerati
                Else 'Se nessuna delle precedenti ha senso allora errore seriale => DEBUG spostando select di 1 carattere
                    RichTextBox1.Select(4, 1)
                    If RichTextBox1.SelectedText = "R" Then
                        RichTextBox1.Select(2, 2)
                        temp = RichTextBox1.SelectedText
                        Clear()
                        MsgBox("Temperatura : " & temp & "°C", MsgBoxStyle.Information, "TEMPERATURA")
                        My.Computer.Audio.Play("H:\Voices\temp" & temp & ".wav", AudioPlayMode.Background) ' Ricorda di mettere condizione o TRY
                        CheckTries = 0
                    ElseIf RichTextBox1.SelectedText = "U" Then
                        RichTextBox1.Select(2, 2)
                        temp = RichTextBox1.SelectedText
                        Clear()
                        MsgBox("Temperatura : " & temp & "°C", MsgBoxStyle.Information, "TEMPERATURA")
                        CheckTries = 0
                    End If
                End If
            Else
                If CheckTries < 3 Then ' Debug : Ripete il check per un massimo di 3 volte
                    RepeatCheck()
                    CheckTries += 1
                Else
                    MsgBox("Sintassi comando errata")
                    Clear()
                    CheckTries = 0
                End If
            End If
        Else
            If CheckTries < 3 Then ' Debug : Ripete il check per un massimo di 3 volte
                RepeatCheck()
                CheckTries += 1
            Else
                Clear()
                MsgBox("Sintassi comando errata")
                CheckTries = 0
            End If

        End If
    End Sub

    Private Sub RepeatCheck() ' Attende che il messaggio da seriale sia ricevuto correttamente e ripete la verifica
        Timer1.Start()
    End Sub
    Dim counter As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        counter += 1
        If counter = 200 Then
            counter = 0
            Timer1.Stop()
            CheckInput()
        End If
    End Sub


    'Cleans the RichTextBox completely
    Private Sub Clear()
        CleanTimer.Start()
    End Sub
    Dim cleanercounter As Integer
    Private Sub CleanTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CleanTimer.Tick
        counter += 1
        RichTextBox1.Clear()
        If cleanercounter = 100 Then
            cleanercounter = 0
            CleanTimer.Stop()
        End If
    End Sub
#End Region

End Class