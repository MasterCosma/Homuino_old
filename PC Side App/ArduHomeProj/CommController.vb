Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports  ' Libreria COM
Imports System.Text
Imports System.IO

Delegate Sub SetTextCallback(ByVal [text] As String)

Public Class CommController
    Dim COMtext As String
    Dim BitText As String

    Dim c As Char = "c"
    Dim a As Char = "a"
    Dim seven As Char = "7"
    Dim eight As Char = "8"
    Dim six As Char = "6"
    Dim three As Char = "3"
    Dim four As Char = "4"
    Dim one As Char = "1"
    Dim zero As Char = "0"

    Dim yesno As Integer = 0    ' 0 = null    1 = no    2= yes
    Dim operation As Integer = 0 ' Indica a quale operazione si risponde con si/no
    '0 = nessuna operazione in corso
    '1 = Capacitivo Entrata/Uscita

#Region "Serial Interface"
    Private Sub CommController_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SerialIN.PortName = My.Settings.COMPort
            SerialIN.BaudRate = My.Settings.COMBaud
            SerialOUT.PortName = My.Settings.VirtualPort
            SerialOUT.BaudRate = My.Settings.VirtualRate
            SerialIN.Open()
            SerialOUT.Open()
        Catch ex As Exception
            MsgBox("Errore : " & ex.ToString, MsgBoxStyle.Critical, "Errore")
        End Try
        
        IODialog.Show()
        Main.Show()
    End Sub

    Private Sub SerialIN_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialIN.DataReceived
        COMtext = SerialIN.ReadLine
        ReceivedTextIN(COMtext)
    End Sub

    

    Private Sub SerialOUT_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialOUT.DataReceived
        OUTInput()
    End Sub

    Private Sub ReceivedTextIN(ByVal [text] As String)
        If Me.RichTextBox2.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedTextIN)
            Me.Invoke(x, New Object() {(text)})
        Else
            CheckInput()
            IODialog.msgReceived.AppendText("Serial IN : " & [text] & vbCr)
        End If
    End Sub

    Private Sub ReceivedTextOUT(ByVal [text] As String)
        If Me.RichTextBox3.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedTextOUT)
            Me.Invoke(x, New Object() {(text)})
        Else
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
                        CheckTries = 0
                    ElseIf COMtext(2) = "0" Then
                        MsgBox("E' giorno")
                        CheckTries = 0
                    End If
                End If
            ElseIf COMtext(0) = "A" Then
                If COMtext(1) & COMtext(2) = "CA" Then
                    My.Computer.Audio.Play("H:\Voices\ACA.wav", AudioPlayMode.Background)
                    CheckTries = 0
                ElseIf COMtext(1) & COMtext(2) = "OK" Then
                    My.Computer.Audio.Play("H:\Voices\ok.wav", AudioPlayMode.Background)
                    CheckTries = 0
                ElseIf COMtext(1) & COMtext(2) = "RS" Then
                    My.Computer.Audio.Play("H:\Voices\ARS.wav", AudioPlayMode.Background)
                    operation = 1
                    CheckTries = 0
                ElseIf COMtext(1) & COMtext(2) = "DO" Then
                    My.Computer.Audio.Play("H:\Voices\Done.wav", AudioPlayMode.Background)
                    CheckTries = 0
                End If
            ElseIf COMtext(0) = "T" Then ' controlla se è Temperatura
                If COMtext(3) = "R" Then ' controlla se è richiesta => Sintesi vocale
                    temp = COMtext(1) & COMtext(2)
                    MsgBox("Temperatura : " & temp & "°C", MsgBoxStyle.Information, "TEMPERATURA")
                    My.Computer.Audio.Play("H:\Voices\temp" & temp & ".wav", AudioPlayMode.Background) ' Ricorda di mettere condizione o TRY
                    CheckTries = 0 ' Operazione effettuata correttamente => Tentativi check azzerati
                ElseIf COMtext(3) = "U" Then ' controlla se non è richiesta
                    temp = COMtext(1) & COMtext(2)
                    MsgBox("Temperatura : " & temp & "°C", MsgBoxStyle.Information, "TEMPERATURA")
                    CheckTries = 0  ' Operazione effettuata correttamente => Tentativi check azzerati
            Else
                If CheckTries < 3 Then ' Debug : Ripete il check per un massimo di 3 volte
                    RepeatCheck()
                    CheckTries += 1
                Else
                    MsgBox("Sintassi comando errata")
                    CheckTries = 0
                End If
            End If
        Else
            If CheckTries < 3 Then ' Debug : Ripete il check per un massimo di 3 volte
                RepeatCheck()
                CheckTries += 1
            Else
                MsgBox("Sintassi comando errata")
                CheckTries = 0
            End If
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

    'Decodifica il messaggio da bitVoicer, lo interpreta e lo invia ad Arduino se necessario
    Private Sub OUTInput()

        Dim byte1 As Byte = SerialOUT.ReadByte
        Dim byte2 As Byte = SerialOUT.ReadByte
        Dim byte3 As Byte = SerialOUT.ReadByte
        Dim byte4 As Byte = SerialOUT.ReadByte
        Dim byte5 As Byte = SerialOUT.ReadByte
        Dim byte6 As Byte = SerialOUT.ReadByte
        Dim byte7 As Byte = SerialOUT.ReadByte
        Dim byte8 As Byte = SerialOUT.ReadByte
        Dim byte9 As Byte = SerialOUT.ReadByte

        If Convert.ToChar(byte4) = c Then
            If Convert.ToChar(byte5) & Convert.ToChar(byte6) = "AL" Then
                If Convert.ToChar(byte7) & Convert.ToChar(byte8) = "ON" Then
                    AlarmStatus = True
                ElseIf Convert.ToChar(byte7) & Convert.ToChar(byte8) = "OF" Then
                    AlarmStatus = False
                ElseIf Convert.ToChar(byte7) = six Then
                    If Convert.ToChar(byte8) = four Then
                        AlarmTime = "06:45:00"
                        My.Computer.Audio.Play("H:\Voices\AL64.wav", AudioPlayMode.Background)
                    End If
                ElseIf Convert.ToChar(byte7) = seven Then
                    If Convert.ToChar(byte8) = zero Then
                        AlarmTime = "09:10:10"
                        My.Computer.Audio.Play("H:\Voices\AL70.wav", AudioPlayMode.Background)
                    ElseIf Convert.ToChar(byte8) = one Then
                        AlarmTime = "07:15:00"
                        My.Computer.Audio.Play("H:\Voices\AL71.wav", AudioPlayMode.Background)
                    ElseIf Convert.ToChar(byte8) = three Then
                        AlarmTime = "07:30:00"
                        My.Computer.Audio.Play("H:\Voices\AL73.wav", AudioPlayMode.Background)
                    End If
                ElseIf Convert.ToChar(byte7) = eight Then
                    If Convert.ToChar(byte8) = zero Then
                        AlarmTime = "08:00:00"
                        My.Computer.Audio.Play("H:\Voices\AL80.wav", AudioPlayMode.Background)
                    End If
                End If
            ElseIf Convert.ToChar(byte5) & Convert.ToChar(byte6) & Convert.ToChar(byte7) = "YES" Then
                yesno = 2
                CheckYESNO()
            ElseIf Convert.ToChar(byte5) & Convert.ToChar(byte6) = "NO" Then
                yesno = 1
                CheckYESNO()
            End If

        ElseIf Convert.ToChar(byte4) = a Then
        MsgBox(BitText)
        SerialIN.WriteLine(BitText)
        End If

        BitText = Convert.ToChar(byte5) & Convert.ToChar(byte6) & Convert.ToChar(byte7) & Convert.ToChar(byte8)
        ReceivedTextOUT(BitText)
        'Cancella le variabili
        BitText = ""
        byte1 = 0
        byte2 = 0
        byte3 = 0
        byte4 = 0
        byte5 = 0
        byte6 = 0
        byte7 = 0
        byte8 = 0
        byte9 = 0

    End Sub

    ' Controlla a quale operazione è riferito il si/no
    Public Sub CheckYESNO()
        If yesno = 2 Then ' Se si
            If operation = 1 Then ' RipristinoSistema
                SerialIN.WriteLine("CRS")
                My.Computer.Audio.Play("H:\Voices\restoring.wav", AudioPlayMode.Background)
                operation = 0
            End If
        ElseIf yesno = 1 Then ' Se no
            If operation = 1 Then ' RipristinoSistema
                My.Computer.Audio.Play("H:\Voices\ok.wav", AudioPlayMode.Background) ' OK
            End If
        End If
        yesno = 0 ' Nessuna operazione in corso
    End Sub
#End Region

    'Controllo per la sveglia
    Private Sub Alarm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Alarm.Tick
        If TimeOfDay = AlarmTime Then
            Alarm.Enabled = False
            Alarm.Stop()
            SerialIN.WriteLine("AAL")
            ' AZIONI DA ESEGUIRE
        End If
    End Sub

    'Controlla se la sveglia è attiva o no secondo la variabile globale (debug)
    Private Sub CheckAlarm_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAlarm.Tick
        If AlarmStatus = True Then
            Alarm.Enabled = True
        Else
            Alarm.Enabled = False
        End If
    End Sub
End Class