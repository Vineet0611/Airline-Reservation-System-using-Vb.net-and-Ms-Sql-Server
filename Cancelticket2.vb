
Imports System.Data.SqlClient
Public Class Cancelticket2
    Dim ticketno As String
    Dim DepTime As String
    Dim depPlace As String
    Dim arrPlace As String
    Dim dt As Date
    Dim CofTr As String
    Dim pid As String
    Dim fcode As Integer
    Dim ArrTime As String
    Dim SeatNo As String
    Private Sub Cancelticket2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New CancelTicket1
        Me.Hide()
        back.Show()
    End Sub

    Private Sub Cancelticket2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(200, 232, 246, 250)
        PictureBox3.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox1.BackColor = Color.FromArgb(10, Color.Transparent)
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
        Label11.BackColor = Color.FromArgb(10, Color.Transparent)
        Label12.BackColor = Color.FromArgb(10, Color.Transparent)
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
        Label23.Text = ticketno
        Try
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Booking_Details where Ticket_No='" & ticketno & "' ")
            cmd.Connection = conn
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            pid = myreader("Pass_id")
            fcode = myreader("f_code")
            DepTime = myreader("Departure_At")
            ArrTime = myreader("Arrival_At")
            dt = myreader("Date")
            SeatNo = myreader("Seat_No")
            CofTr = myreader("Class_of_travel")
            Label22.Text = fcode
            Label13.Text = DepTime
            Label14.Text = ArrTime
            Label24.Text = SeatNo
            Label21.Text = CofTr

            myreader.Close()

            Dim query As String = "Select * from Flight_info where f_code='" & fcode & "'"
            Dim cmd1 As SqlCommand = New SqlCommand(query, conn)
            Dim myreader1 As SqlDataReader
            myreader1 = cmd1.ExecuteReader()
            myreader1.Read()
            depPlace = myreader1("Source")
            arrPlace = myreader1("Destination")
            Label10.Text = depPlace
            Label15.Text = arrPlace
            myreader1.Close()

            Dim query1 As String = "Select * from Passenger_details where Pid='" & pid & "'"
            Dim cmd2 As SqlCommand = New SqlCommand(query1, conn)
            Dim myreader2 As SqlDataReader
            myreader2 = cmd2.ExecuteReader()
            myreader2.Read()
            Label4.Text = myreader2("Name")
            myreader2.Close()

            Dim query2 As String = "Select * from Payment_Details where Pid='" & pid & "'"
            Dim cmd3 As SqlCommand = New SqlCommand(query2, conn)
            Dim myreader3 As SqlDataReader
            myreader3 = cmd3.ExecuteReader()
            myreader3.Read()
            Label5.Text = myreader3("Time_Of_Payment")
            myreader3.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & "2")
        End Try
    End Sub
    Public Sub getTicketNo(ByVal Tno As String)
        ticketno = Tno
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult
        Dim CurrDate As String = Date.Now().ToString("dd-MM-yyyy HH:mm:ss")
        Dim Diff As System.TimeSpan = (Convert.ToDateTime(DepTime) - Convert.ToDateTime(CurrDate))
        Dim TimDiff As Integer = CInt(Math.Ceiling(Diff.TotalHours))
        If TimDiff > 96 Then
            result = MessageBox.Show("₹2500 Will Be Deducted As A Cancelation Fees " & vbCrLf & "Are You Sure You Want To Cancel ticket", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        ElseIf TimDiff < 96 And TimDiff > 24 Then
            result = MessageBox.Show("₹3000 Will Be Deducted As A Cancelation Fees " & vbCrLf & "Are You Sure You Want To Cancel ticket", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        ElseIf TimDiff < 24 Then
            result = MessageBox.Show("100% Amount Will Be Deducted As A Cancelation Fees " & vbCrLf & "Are You Sure You Want To Cancel ticket", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        End If
        If result = DialogResult.Yes Then
            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim query As String = "Delete  from Booking_Details where Ticket_No='" & ticketno & "'"
                Dim cmd As SqlCommand = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()

                Dim query1 As String = ""
                If CofTr = "Economy" Then
                    query1 = "Update  FlightSchedule Set Economy_Seat=Economy_Seat+1 where Depart_At ='" & depPlace & "' and Arrival_At='" & arrPlace & "' and Depart_time= '" & DepTime & "'"
                ElseIf CofTr = "Business" Then
                    query1 = "Update  FlightSchedule Set Business_Seat=Business_Seat+1 where Depart_At ='" & depPlace & "' and Arrival_At='" & arrPlace & "' and Depart_time= '" & DepTime & "'"
                ElseIf CofTr = "First Class" Then
                    query1 = "Update  FlightSchedule Set First_class_Seat=First_class_Seat+1 where Depart_At ='" & depPlace & "' and Arrival_At='" & arrPlace & "' and  Depart_time= '" & DepTime & "'"
                End If

                Dim cmd1 As SqlCommand = New SqlCommand(query1, conn)
                cmd1.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message & "3")
            End Try
            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim query2 As String = "insert into Canceled_Ticket values ('" & pid & "', '" & ticketno & "','" & fcode & "','" & DepTime & "','" & ArrTime & "','" & SeatNo & "','" & dt & "','" & CofTr & "')"
                Dim cmd2 As SqlCommand = New SqlCommand(query2, conn)
                cmd2.ExecuteNonQuery()
                MessageBox.Show("Ticket Canceled Successfull" & vbCrLf & "Refund Process Is Initiated", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim backTo As New CancelTicket1
                Me.Hide()
                backTo.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message & "1")
            End Try
        End If
    End Sub
End Class