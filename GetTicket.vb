Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.Metadata


Public Class GetTicket
    Dim ticket_no As Integer
    Private Sub GetTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(230, 232, 246, 250)
        PictureBox2.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox3.BackColor = Color.FromArgb(10, Color.Transparent)
        Label1.BackColor = Color.FromArgb(10, Color.Transparent)
        Label2.BackColor = Color.FromArgb(10, Color.Transparent)
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label6.BackColor = Color.FromArgb(10, Color.Transparent)
        Label7.BackColor = Color.FromArgb(10, Color.Transparent)
        Label8.BackColor = Color.FromArgb(10, Color.Transparent)
        Label9.BackColor = Color.FromArgb(10, Color.Transparent)
        Label10.BackColor = Color.FromArgb(10, Color.Transparent)
        Label15.BackColor = Color.FromArgb(10, Color.Transparent)
        Label16.BackColor = Color.FromArgb(10, Color.Transparent)
        Label13.BackColor = Color.FromArgb(10, Color.Transparent)
        Label14.BackColor = Color.FromArgb(10, Color.Transparent)
        Label17.BackColor = Color.FromArgb(10, Color.Transparent)
        Label18.BackColor = Color.FromArgb(10, Color.Transparent)
        Label19.BackColor = Color.FromArgb(10, Color.Transparent)
        Label20.BackColor = Color.FromArgb(10, Color.Transparent)
        Label21.BackColor = Color.FromArgb(10, Color.Transparent)
        Label22.BackColor = Color.FromArgb(10, Color.Transparent)
        Label23.BackColor = Color.FromArgb(10, Color.Transparent)
        Label24.BackColor = Color.FromArgb(10, Color.Transparent)
        Label25.BackColor = Color.FromArgb(10, Color.Transparent)
        Label26.BackColor = Color.FromArgb(10, Color.Transparent)
        Label27.BackColor = Color.FromArgb(10, Color.Transparent)
        Label28.BackColor = Color.FromArgb(10, Color.Transparent)
        Label29.BackColor = Color.FromArgb(10, Color.Transparent)
        Label30.BackColor = Color.FromArgb(10, Color.Transparent)
        Label31.BackColor = Color.FromArgb(10, Color.Transparent)
        Label32.BackColor = Color.FromArgb(10, Color.Transparent)
        Label33.BackColor = Color.FromArgb(10, Color.Transparent)

        Try
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Booking_Details Where Ticket_No='" & ticket_no & "'")
            cmd.Connection = conn
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            Dim f_code As Integer = myreader("f_code")
            Dim passId As Integer = myreader("Pass_id")
            Dim DeptTime As String = myreader("Departure_At").ToString
            Dim ArriTime As String = myreader("Arrival_At").ToString
            Dim SeatNo As String = myreader("Seat_No").ToString
            Dim ClasOfTrav As String = myreader("Class_of_Travel").ToString
            myreader.Close()

            Dim cmd1 As SqlCommand = New SqlCommand("Select * from Flight_Info Where f_code='" & f_code & "'")
            cmd1.Connection = conn
            Dim myreader1 As SqlDataReader
            myreader1 = cmd1.ExecuteReader
            myreader1.Read()
            Dim source As String = myreader1("Source")
            Dim destination As String = myreader1("Destination")
            myreader1.Close()

            Dim cmd2 As SqlCommand = New SqlCommand("Select * from Passenger_details Where Pid='" & passId & "'")
            cmd2.Connection = conn
            Dim myreader2 As SqlDataReader
            myreader2 = cmd2.ExecuteReader
            myreader2.Read()
            Dim name As String = myreader2("Name")
            myreader2.Close()

            Dim cmd3 As SqlCommand = New SqlCommand("Select * from Payment_Details Where Pid='" & passId & "'")
            cmd3.Connection = conn
            Dim myreader3 As SqlDataReader
            myreader3 = cmd3.ExecuteReader
            myreader3.Read()
            Dim bookingdate As String = myreader3("Time_of_Payment")
            myreader3.Close()

            Label4.Text = name.ToUpper
            Label5.Text = bookingdate
            Label10.Text = source.ToUpper
            Label15.Text = destination.ToUpper
            Label13.Text = DeptTime
            Label14.Text = ArriTime
            Label21.Text = ClasOfTrav.ToUpper
            Label22.Text = f_code
            Label24.Text = SeatNo
            Label23.Text = ticket_no
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GetTicket_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New PrintTicket
        Me.Hide()
        back.Show()
    End Sub
    Public Sub getTicNo(ByVal ticno As Integer)
        ticket_no = ticno
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show("Printing Ticket.......", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class