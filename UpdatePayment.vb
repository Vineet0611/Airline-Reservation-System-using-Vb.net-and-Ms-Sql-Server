Imports System.Data.SqlClient
Public Class UpdatePayment
    Dim TicketAmt As Integer
    Dim TicketNo As Integer
    Dim price As Integer
    Dim pids As Integer
    Dim Source As String
    Dim des As String
    Dim Dat As String
    Dim namez As String
    Dim flightc As String
    Dim DepTime As String
    Dim ArrTime As String
    Dim Classt As String
    Dim DeTime As String
    Dim CanSource As String
    Dim CanArrival As String
    Dim CanCft As String
    Dim NewDat As String
    Dim totalPrice As Integer
    Dim newCotrv As String

    Private Sub UpdatePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.BackColor = Color.FromArgb(150, Color.Transparent)
        Panel5.BackColor = Color.FromArgb(150, Color.Transparent)

        Label32.BackColor = Color.FromArgb(10, Color.Transparent)

        Label35.BackColor = Color.FromArgb(10, Color.Transparent)
        Label36.BackColor = Color.FromArgb(10, Color.Transparent)
        Label37.BackColor = Color.FromArgb(10, Color.Transparent)
        Label38.BackColor = Color.FromArgb(10, Color.Transparent)
        Label39.BackColor = Color.FromArgb(10, Color.Transparent)
        Label40.BackColor = Color.FromArgb(10, Color.Transparent)

        Label42.BackColor = Color.FromArgb(10, Color.Transparent)
        Label43.BackColor = Color.FromArgb(10, Color.Transparent)
        Label44.BackColor = Color.FromArgb(10, Color.Transparent)
        Label45.BackColor = Color.FromArgb(10, Color.Transparent)
        Label46.BackColor = Color.FromArgb(10, Color.Transparent)
        Label47.BackColor = Color.FromArgb(10, Color.Transparent)
        LblFlightno.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblsource.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblarrival.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblclasstravel.BackColor = Color.FromArgb(10, Color.Transparent)


        Lbldeptime.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblarrivaltime.BackColor = Color.FromArgb(10, Color.Transparent)
        LblPassengername.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblticketdetails.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblticketno.BackColor = Color.FromArgb(10, Color.Transparent)
        Label32.Text = TicketNo
        Label38.Text = namez
        Label40.Text = Source
        Label37.Text = des

        Try
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim query As String = "Select * from FlightSchedule Where Depart_At='" & Source & "' and Arrival_At='" & des & "' and Date='" & Dat & "'"
            Dim myreader As SqlDataReader
            Dim cmd As SqlCommand = New SqlCommand(query, conn)
            myreader = cmd.ExecuteReader()
            myreader.Read()

            flightc = myreader("f_code")
                DepTime = myreader("Depart_time")
                ArrTime = myreader("Arrival_time")

            price = myreader("Price")
            NewDat = myreader("Date")

            Label42.Text = flightc.ToString
            Label39.Text = DepTime
            Label36.Text = ArrTime
            Label35.Text = newCotrv
            totalPrice = price - TicketAmt
            Label45.Text = totalPrice.ToString
            myreader.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub UpdatePayment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub
    Public Sub getman(ByVal amt As Integer, ByVal dept As String, ByVal arri As String, ByVal dt As String, ByVal TicNo As Integer, ByVal name1 As String, ByVal pid As Integer, ByVal dtime As String)
        TicketAmt = amt
        Source = dept
        des = arri
        Dat = dt
        TicketNo = TicNo
        namez = name1
        pids = pid
        DeTime = dtime
    End Sub
    Public Sub getcan(ByVal CanSrc As String, ByVal CanArr As String, ByVal CanCoft As String, ByVal NeCoft As String)
        CanSource = CanSrc
        CanArrival = CanArr
        CanCft = CanCoft
        newCotrv = NeCoft
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ptick As New SelectSeats
        Me.Hide()
        ptick.Show()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If RadioButton1.Checked Then
            Dim curdat As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            If TextBox11.Text = "" Or TextBox10.Text = "" Then
                MessageBox.Show("Please Fill All the Fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf TextBox11.Text.Length < 12 Or TextBox11.Text.Length > 12 Then
                MessageBox.Show("Card Number Shoud be of 12 Digits ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                Try
                    Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                    conn.Open()
                    updateTicket()
                    Dim query As String = "Insert into Payment_Details values('" & pids & "','" & TextBox11.Text & "','NA','NA','" & curdat & "','" & totalPrice & "')"
                    Dim cmd As SqlCommand = New SqlCommand(query, conn)
                    cmd.ExecuteNonQuery()

                    TextBox11.Text = ""
                    TextBox10.Text = ""
                    MessageBox.Show("Ticket Updated Successfully", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            End If
        End If
        If RadioButton2.Checked Then
            Dim curdat As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            If TextBox11.Text = "" Or TextBox10.Text = "" Then
                MessageBox.Show("Please Fill All the Fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf TextBox11.Text.Length < 16 Or TextBox11.Text.Length > 16 Then
                MessageBox.Show("Account Number Shoud be of 16 Digits ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                Try
                    Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                    conn.Open()
                    updateTicket()
                    Dim query As String = "Insert into Payment_Details values('" & pids & "','NA','" & TextBox11.Text & "','NA','" & curdat & "','" & totalPrice & "')"
                    Dim cmd As SqlCommand = New SqlCommand(query, conn)
                    cmd.ExecuteNonQuery()

                    TextBox11.Text = ""
                    TextBox10.Text = ""
                    MessageBox.Show("Ticket Updated Successfully", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
        If RadioButton3.Checked Then
            Dim curdat As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            If TextBox11.Text = "" Then
                MessageBox.Show("Please Fill All the Fields ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf TextBox11.Text.Length < 10 Or TextBox11.Text.Length > 10 Then
                MessageBox.Show("UPI ID Shoud be of 10 Digits ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                Try
                    Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                    conn.Open()
                    updateTicket()
                    Dim query As String = "Insert into Payment_Details values('" & pids & "','NA','NA','" & TextBox11.Text & "','" & curdat & "','" & totalPrice & "')"
                    Dim cmd As SqlCommand = New SqlCommand(query, conn)
                    cmd.ExecuteNonQuery()

                    TextBox11.Text = ""
                    TextBox10.Text = ""
                    MessageBox.Show("Ticket Updated Successfully", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        Label44.Location = New Point(270, 168)
        TextBox10.Visible = True
        Label44.Text = "Account No:"
        Label43.Visible = True
        TextBox10.Text = ""
        TextBox11.Text = ""
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Label44.Location = New Point(312, 168)
        Label44.Text = "UPI Id:"
        Label43.Visible = False
        TextBox10.Visible = False
        TextBox11.Text = ""
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Label44.Location = New Point(312, 168)
        Label44.Text = "Card No:"
        TextBox10.Visible = True
        TextBox10.Text = ""
        TextBox11.Text = ""
        Label43.Visible = True
    End Sub
    Public Sub updateTicket()
        Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")

        Dim Nseat As Integer
        Dim Nseat1 As Integer = 0
        Dim Seatno As Integer = 0
        Dim myreader As SqlDataReader
        'Increasing the seat count of old flight
        Try
            conn.Open()
            'Fetching the  seat count from database
            Dim Query As String = "Select * from  FlightSchedule where Depart_At='" & CanSource & "' and Arrival_At='" & CanArrival & "' and Depart_time='" & DeTime & "'"
            Dim cmd As SqlCommand = New SqlCommand(Query, conn)
            Dim oSeat As Integer = 0
            myreader = cmd.ExecuteReader
            myreader.Read()
            If CanCft = "Economy" Then
                oSeat = Convert.ToInt32(myreader("Economy_Seat"))
            ElseIf CanCft = "Business" Then
                oSeat = Convert.ToInt32(myreader("Business_Seat"))
            ElseIf CanCft = "First_Class" Then
                oSeat = Convert.ToInt32(myreader("Business_Seat"))
            End If

            Nseat = oSeat + 1
            myreader.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & "1")
        End Try
        Try
            'updating the seat count in database
            Dim Query1 As String = ""
            Dim cmd1 As SqlCommand
            If CanCft = "Economy" Then
                Query1 = "Update FlightSchedule Set Economy_Seat='" & Nseat & "' where Depart_At='" & CanSource & "' and Arrival_At='" & CanArrival & "' and Depart_time='" & DeTime & "' "
                cmd1 = New SqlCommand(Query1, conn)
                cmd1.ExecuteNonQuery()
            ElseIf CanCft = "Business" Then
                Query1 = "Update FlightSchedule Set Business_Seat='" & Nseat & "' where Depart_At='" & CanSource & "' and Arrival_At='" & CanArrival & "' and Depart_time='" & DeTime & "' "
                cmd1 = New SqlCommand(Query1, conn)
                cmd1.ExecuteNonQuery()
            ElseIf CanCft = "First_Class" Then
                Query1 = "Update FlightSchedule Set First_class_Seat='" & Nseat & "' where Depart_At='" & CanSource & "' and Arrival_At='" & CanArrival & "' and Depart_time='" & DeTime & "' "
                cmd1 = New SqlCommand(Query1, conn)
                cmd1.ExecuteNonQuery()
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message & "2")
        End Try

        Try
            Dim Query1 As String = ""
            Dim cmd3 As SqlCommand
            If newCotrv = "Economy" Then
                Query1 = "Update FlightSchedule Set Economy_Seat=Economy_Seat-1 where Depart_At='" & Source & "' and Arrival_At='" & des & "' and Date='" & Dat & "' "
                cmd3 = New SqlCommand(Query1, conn)
                cmd3.ExecuteNonQuery()
            ElseIf newCotrv = "Business" Then
                Query1 = "Update FlightSchedule Set Business_Seat=Business_Seat-1 where Depart_At='" & Source & "' and Arrival_At='" & des & "' and Date='" & Dat & "' "
                cmd3 = New SqlCommand(Query1, conn)
                cmd3.ExecuteNonQuery()
            ElseIf newCotrv = "First Class" Then
                Query1 = "Update FlightSchedule Set First_class_Seat=First_class_Seat-1 where Depart_At='" & Source & "' and Arrival_At='" & des & "' and Date='" & Dat & "' "
                cmd3 = New SqlCommand(Query1, conn)
                cmd3.ExecuteNonQuery()
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message & "4")
        End Try
        Try

            Dim Query1 As String = "Update Booking_Details Set f_code='" & flightc & "',Departure_At='" & DepTime & "',Arrival_At='" & ArrTime & "',Date='" & NewDat & "' ,Class_of_travel='" & newCotrv & "', Seat_No='NULL' where Ticket_No='" & TicketNo & "'"
            Dim cmd4 As SqlCommand = New SqlCommand(Query1, conn)
            cmd4.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message & "5")
        End Try
        Button8.Enabled = False
        Button8.Visible = False
        Button3.Visible = True
        Button3.Enabled = True

    End Sub
End Class