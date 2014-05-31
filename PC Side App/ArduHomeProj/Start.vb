Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.IO.Ports
Public Class Start
    Dim myPort As Array  'COM Ports detected on the system will be stored here

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'When our form loads, auto detect all serial ports in the system and populate the cmbPort Combo box.
        myPort = IO.Ports.SerialPort.GetPortNames() 'Get all com ports available
        ComBaud.Items.Add(9600)     'Populate the cmbBaud Combo box to common baud rates used
        ComBaud.Items.Add(19200)
        ComBaud.Items.Add(38400)
        ComBaud.Items.Add(57600)
        ComBaud.Items.Add(115200)
        ComBaud1.Items.Add(9600)     'Populate the cmbBaud Combo box to common baud rates used
        ComBaud1.Items.Add(19200)
        ComBaud1.Items.Add(38400)
        ComBaud1.Items.Add(57600)
        ComBaud1.Items.Add(115200)

        For i = 0 To UBound(myPort)
            ComPort.Items.Add(myPort(i))
            ComPort1.Items.Add(myPort(i))
        Next
        ComPort.Text = ComPort.Items.Item(0)    'Set cmbPort text to the first COM port detected
        ComBaud.Text = ComBaud.Items.Item(0)    'Set cmbBaud text to the first Baud rate on the list
        ComPort1.Text = ComPort1.Items.Item(0)    'Set cmbPort text to the first COM port detected
        ComBaud1.Text = ComBaud1.Items.Item(0)    'Set cmbBaud text to the first Baud rate on the list
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        My.Settings.COMPort = ComPort.SelectedItem.ToString
        My.Settings.COMBaud = ComBaud.SelectedItem.ToString
        My.Settings.VirtualPort = ComPort1.SelectedItem.ToString
        My.Settings.VirtualRate = ComBaud1.SelectedItem.ToString
        CommController.Show()
        Me.Hide()
    End Sub

    Private Sub ReconButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReconButton1.Click
        Me.Close()
    End Sub
End Class
