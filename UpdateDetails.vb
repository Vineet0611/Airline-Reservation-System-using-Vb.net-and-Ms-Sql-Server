Imports System.Data.SqlClient
Imports System.Globalization

Public Class UpdateDetails
    Dim Ticket_No As Integer
    Dim source As String
    Dim destination As String
    Dim Date1 As String
    Dim ClasOfTrav As String
    Dim Depttime As String
    Dim RimAmount As Integer
    Dim passId As Integer
    Dim namee As String
    Private Sub AdminLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub UpdateDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label6.BackColor = Color.FromArgb(10, Color.Transparent)
        Label7.BackColor = Color.FromArgb(10, Color.Transparent)
        Label8.BackColor = Color.FromArgb(10, Color.Transparent)
        Label9.BackColor = Color.FromArgb(10, Color.Transparent)
        Label10.BackColor = Color.FromArgb(10, Color.Transparent)
        Label11.BackColor = Color.FromArgb(10, Color.Transparent)
        Label12.BackColor = Color.FromArgb(10, Color.Transparent)
        Label13.BackColor = Color.FromArgb(10, Color.Transparent)
        Try
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Booking_Details Where Ticket_No='" & Ticket_No & "'")
            cmd.Connection = conn
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            Dim f_code As Integer = myreader("f_code")
            passId = myreader("Pass_id")
            Date1 = myreader("Date").ToString
            ClasOfTrav = myreader("Class_of_Travel").ToString
            Depttime = myreader("Departure_At").ToString
            myreader.Close()

            Dim cmd1 As SqlCommand = New SqlCommand("Select * from Flight_Info Where f_code='" & f_code & "'")
            cmd1.Connection = conn
            Dim myreader1 As SqlDataReader
            myreader1 = cmd1.ExecuteReader
            myreader1.Read()
            source = myreader1("Source")
            destination = myreader1("Destination")
            myreader1.Close()

            Dim cmd2 As SqlCommand = New SqlCommand("Select * from Passenger_details Where Pid='" & passId & "'")
            cmd2.Connection = conn
            Dim myreader2 As SqlDataReader
            myreader2 = cmd2.ExecuteReader
            myreader2.Read()
            namee = myreader2("Name")
            Dim age As String = myreader2("Age")
            Dim address As String = myreader2("Address")
            myreader2.Close()

            Label11.Text = namee
            Label12.Text = age
            Label13.Text = address
            ComboBox2.Text = source
            ComboBox3.Text = destination
            ComboBox1.Text = ClasOfTrav
            DateTimePicker1.Text = Date1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim UpdateT As New UpdateTicket
        UpdateT.Show()
        Me.Hide()
    End Sub
    Public Sub getTicNo(ByVal ticno As String)
        Ticket_No = ticno
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim CurrDate As String = Date.Now().ToString("dd-MM-yyyy HH:mm:ss")
        Dim Diff As System.TimeSpan = (Convert.ToDateTime(Depttime) - Convert.ToDateTime(CurrDate))
        Dim TimDiff As Integer = CInt(Math.Ceiling(Diff.TotalHours))

        If Not String.Equals(ComboBox2.Text, source) OrElse Not String.Equals(ComboBox3.Text, destination) OrElse Not String.Equals(ComboBox1.Text, ClasOfTrav) OrElse Not String.Equals(DateTimePicker1.Text, Date1) Then
            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim myreader As SqlDataReader

                Dim cmd As SqlCommand = New SqlCommand("Select * From FlightSchedule where Depart_At='" & ComboBox2.Text & "' and Arrival_At='" & ComboBox3.Text & "'and Date='" & DateTimePicker1.Text & "'")
                cmd.Connection = conn

                myreader = cmd.ExecuteReader
                Dim Result As DialogResult

                If myreader.Read() Then
                    myreader.Close()
                    Dim TicPrice As Integer
                    Try

                        Dim Query As String = "Select * From FlightSchedule Where Depart_At='" & source & "' and Arrival_At='" & destination & "' and  Depart_time='" & Depttime & "'"
                        Dim cmd1 As SqlCommand = New SqlCommand(Query, conn)
                        Dim myreader1 As SqlDataReader
                        myreader1 = cmd1.ExecuteReader
                        myreader1.Read()
                        TicPrice = myreader1("Price")
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    If TimDiff >= 96 Then
                        Result = MessageBox.Show("₹2500 Will Be Deducted As A Cancelation Fees of Previous Ticket" & vbCrLf & "Are You Sure You Want To Cancel Ticket", "Airline Reservation System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If Result = DialogResult.Yes Then
                            Try
                                RimAmount = TicPrice - 2500
                                Dim pay As New UpdatePayment
                                pay.getman(RimAmount, ComboBox2.Text, ComboBox3.Text, DateTimePicker1.Text, Ticket_No, namee, passId, Depttime)
                                pay.getcan(source, destination, ClasOfTrav, ComboBox1.Text)
                                Me.Hide()
                                pay.Show()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message & "2")
                            End Try

                        End If

                    ElseIf TimDiff < 96 And TimDiff > 24 Then
                        Result = MessageBox.Show("₹3000 Will Be Deducted As A Cancelation Fees of Previous Ticket" & vbCrLf & "Are You Sure You Want To Cancel Ticket", "Airline Reservation System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If Result = DialogResult.Yes Then

                            RimAmount = TicPrice - 3000
                            Try
                                Dim payg As New UpdatePayment
                                ' MessageBox.Show(RimAmount & " " & ComboBox2.Text.ToString & " " & ComboBox3.Text.ToString & " " & DateTimePicker1.Text.ToString & " " & Convert.ToInt32(Ticket_No) & " " & namee & " " & Depttime & " " & passId)
                                payg.getman(RimAmount, ComboBox2.Text.ToString, ComboBox3.Text.ToString, DateTimePicker1.Text.ToString, Convert.ToInt32(Ticket_No), namee, passId, Depttime)
                                'MessageBox.Show(source & " " & destination & " " & ClasOfTrav)
                                payg.getcan(source, destination, ClasOfTrav, ComboBox1.Text)

                                Me.Hide()
                                payg.Show()

                            Catch ex As Exception
                                MessageBox.Show(ex.Message & "1")
                            End Try
                        End If
                    ElseIf TimDiff <= 24 Then
                        Result = MessageBox.Show("100% Amount  Will Be Deducted As A Cancelation Fees of Previous Ticket" & vbCrLf & "Are You Sure You Want To Cancel Ticket", "Airline Reservation System", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If Result = DialogResult.Yes Then
                            RimAmount = 0
                            Try
                                Dim pay As New UpdatePayment
                                pay.getcan(source, destination, ClasOfTrav, ComboBox1.Text)
                                pay.getman(RimAmount, ComboBox2.Text, ComboBox3.Text, DateTimePicker1.Text, Ticket_No, namee, passId, Depttime)
                                Me.Hide()
                                pay.Show()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message & "3")
                            End Try
                        End If
                    End If
                Else
                    MessageBox.Show("No Tickets Found For the give date", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception

            End Try
        Else
            MessageBox.Show("No Change In The Data Hence Update Not Possible", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class