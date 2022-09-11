Imports System.Data.SqlClient

Public Class TicketPayment1
    Dim NTic As Integer
    Dim TicketNo As Integer()
    Dim PidNo As Integer()
    Dim f_code As Integer
    Dim depatAt As String
    Dim ArrivalAt As String
    Dim ClassOfTravel As String
    Dim Adult As Integer
    Dim Child As Integer
    Dim Infant As Integer
    Dim deptTime As String
    Dim arriTime As String
    Dim SeatNo1 As String = ""
    Dim SeatNo2 As String = "NULL"
    Dim SeatNo3 As String = "NULL"
    Dim Pname(3) As String
    Dim Page(3) As Integer
    Dim Padd(3) As String
    Dim Price As Integer
    Dim Dat As String
    Dim AllSeatno(3) As String



    Private Sub TicketPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If NTic = 1 Then
            Label28.Visible = False
            Label24.Visible = False
            Label30.Visible = False
            Label26.Visible = False
            Label29.Visible = False
            Label27.Visible = False
            Label25.Visible = False
            Label23.Visible = False
            Label38.Text = Pname(0)
            Label32.Text = TicketNo(0)
            Label40.Text = depatAt
            Label37.Text = ArrivalAt
            Label35.Text = ClassOfTravel
            Label42.Text = f_code
            Label39.Text = deptTime
            Label36.Text = arriTime
            Label34.Text = Adult
            Label33.Text = Child
            Label31.Text = Infant
            Label45.Text = Price
            RadioButton1.Checked = True

        ElseIf NTic = 2 Then
            Label28.Visible = True
            Label30.Visible = True
            Label29.Visible = True
            Label27.Visible = True
            Label25.Visible = False
            Label23.Visible = False
            Label24.Visible = False
            Label26.Visible = False
            Label38.Text = Pname(0)
            Label32.Text = TicketNo(0)
            Label27.Text = TicketNo(1)
            Label30.Text = Pname(1)
            Label40.Text = depatAt
            Label37.Text = ArrivalAt
            Label42.Text = f_code
            Label35.Text = ClassOfTravel
            Label39.Text = deptTime
            Label36.Text = arriTime
            Label34.Text = Adult
            Label33.Text = Child
            Label31.Text = Infant
            Label45.Text = Price
            RadioButton1.Checked = True
        ElseIf NTic = 3 Then
            Label28.Visible = True
            Label30.Visible = True
            Label29.Visible = True
            Label27.Visible = True
            Label25.Visible = True
            Label23.Visible = True
            Label24.Visible = True
            Label26.Visible = True
            Label38.Text = Pname(0)
            Label32.Text = TicketNo(0)
            Label27.Text = TicketNo(1)
            Label23.Text = TicketNo(2)
            Label30.Text = Pname(1)
            Label26.Text = Pname(2)
            Label40.Text = depatAt
            Label37.Text = ArrivalAt
            Label42.Text = f_code
            Label35.Text = ClassOfTravel
            Label39.Text = deptTime
            Label36.Text = arriTime
            Label34.Text = Adult
            Label33.Text = Child
            Label31.Text = Infant
            Label45.Text = Price
            RadioButton1.Checked = True
        End If
        Panel4.BackColor = Color.FromArgb(200, Color.Transparent)
        Panel5.BackColor = Color.FromArgb(200, Color.Transparent)
        Label43.BackColor = Color.FromArgb(10, Color.Transparent)
        Label44.BackColor = Color.FromArgb(10, Color.Transparent)
        Label45.BackColor = Color.FromArgb(10, Color.Transparent)
        Label46.BackColor = Color.FromArgb(10, Color.Transparent)
        Label47.BackColor = Color.FromArgb(10, Color.Transparent)
        LblFlightno.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblsource.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblarrival.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblclasstravel.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbladult.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblchildren.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblinfant.BackColor = Color.FromArgb(10, Color.Transparent)

        Lbldeptime.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblarrivaltime.BackColor = Color.FromArgb(10, Color.Transparent)
        LblPassengername.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblticketdetails.BackColor = Color.FromArgb(10, Color.Transparent)
        Lblticketno.BackColor = Color.FromArgb(10, Color.Transparent)
        Label40.BackColor = Color.FromArgb(10, Color.Transparent)
        Label42.BackColor = Color.FromArgb(10, Color.Transparent)
        Label37.BackColor = Color.FromArgb(10, Color.Transparent)
        Label27.BackColor = Color.FromArgb(10, Color.Transparent)
        Label28.BackColor = Color.FromArgb(10, Color.Transparent)
        Label29.BackColor = Color.FromArgb(10, Color.Transparent)
        Label30.BackColor = Color.FromArgb(10, Color.Transparent)
        Label31.BackColor = Color.FromArgb(10, Color.Transparent)
        Label32.BackColor = Color.FromArgb(10, Color.Transparent)
        Label33.BackColor = Color.FromArgb(10, Color.Transparent)
        Label34.BackColor = Color.FromArgb(10, Color.Transparent)
        Label35.BackColor = Color.FromArgb(10, Color.Transparent)
        Label36.BackColor = Color.FromArgb(10, Color.Transparent)
        Label37.BackColor = Color.FromArgb(10, Color.Transparent)
        Label38.BackColor = Color.FromArgb(10, Color.Transparent)
        Label39.BackColor = Color.FromArgb(10, Color.Transparent)
        Label23.BackColor = Color.FromArgb(10, Color.Transparent)
        Label24.BackColor = Color.FromArgb(10, Color.Transparent)
        Label25.BackColor = Color.FromArgb(10, Color.Transparent)
        Label26.BackColor = Color.FromArgb(10, Color.Transparent)
        If NTic = 1 Then
            AllSeatno(0) = SeatNo1
        ElseIf NTic = 2 Then
            AllSeatno(0) = SeatNo1
            AllSeatno(1) = SeatNo2
        ElseIf NTic = 3 Then
            AllSeatno(0) = SeatNo1
            AllSeatno(1) = SeatNo2
            AllSeatno(2) = SeatNo3
        End If

    End Sub
    Public Sub TTgetinfo(ByVal nooftic As Integer, ByVal ticno As Integer(), ByVal pid As Integer(), ByVal fcode As Integer, ByVal depAt As String, ByVal arrAt As String, ByVal clt As String)
        NTic = nooftic
        TicketNo = ticno
        PidNo = pid
        f_code = fcode
        depatAt = depAt
        ArrivalAt = arrAt
        ClassOfTravel = clt
    End Sub
    Public Sub TTGetinfo1(ByVal adt As Integer, ByVal cld As Integer, ByVal infan As Integer, ByVal pnam As String(), ByVal depttim As String, ByVal arrtim As String, ByVal prz As Integer, ByVal dt As String)
        Adult = adt
        Child = cld
        Infant = infan
        Pname = pnam
        deptTime = depttim
        arriTime = arrtim
        Price = prz
        Dat = dt
    End Sub
    Public Sub TTGetSeatno(ByVal s1 As String, ByVal s2 As String, ByVal s3 As String)
        If NTic = 1 Then
            SeatNo1 = s1
        ElseIf NTic = 2 Then
            SeatNo1 = s1
            SeatNo2 = s2
        ElseIf NTic = 3 Then
            SeatNo1 = s1
            SeatNo2 = s2
            SeatNo3 = s3
        End If




    End Sub
    Public Sub TTGetInfo2(ByVal age() As Integer, ByVal addr() As String)
        Page = age
        Padd = addr
    End Sub

    Private Sub TicketPayment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If RadioButton1.Checked Then
            Dim curdat As String = DateTime.Now.ToString("dd/MMMM/yyyy  HH:mm:ss")
            If TextBox11.Text = "" Or TextBox10.Text = "" Then
                MessageBox.Show("Please Fill All the Fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf TextBox11.Text.Length < 12 Or TextBox11.Text.Length > 12 Then
                MessageBox.Show("Card Number Shoud be of 12 Digits ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Book()
                Try
                    Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                    conn.Open()
                    For i = 0 To NTic - 1 Step 1
                        Dim query As String = "Insert into Payment_Details values('" & PidNo(i) & "','" & TextBox11.Text & "','NA','NA','" & curdat & "','" & Price & "')"
                        Dim cmd As SqlCommand = New SqlCommand(query, conn)
                        cmd.ExecuteNonQuery()
                    Next
                    TextBox11.Text = ""
                    TextBox10.Text = ""
                    Button8.Enabled = False
                    Button3.Enabled = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message & "1")
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
                Book()
                Try
                    Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                    conn.Open()
                    For i = 0 To NTic - 1 Step 1
                        Dim query As String = "Insert into Payment_Details values('" & PidNo(i) & "','NA','" & TextBox11.Text & "','NA','" & curdat & "','" & Price & "')"
                        Dim cmd As SqlCommand = New SqlCommand(query, conn)
                        cmd.ExecuteNonQuery()
                    Next
                    TextBox11.Text = ""
                    TextBox10.Text = ""
                    Button8.Enabled = False
                    Button3.Enabled = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message & "2")
                End Try
            End If
        End If
        If RadioButton3.Checked Then
            Dim curdat As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            If TextBox11.Text = "" Then
                MessageBox.Show("Please Fill All the Fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf TextBox11.Text.Length < 10 Or TextBox11.Text.Length > 10 Then
                MessageBox.Show("UPI ID Shoud be of 10 Digits ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Book()
                Try
                    Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                    conn.Open()
                    For i = 0 To NTic - 1 Step 1
                        Dim query As String = "Insert into Payment_Details values('" & PidNo(i) & "','NA','NA','" & TextBox11.Text & "','" & curdat & "','" & Price & "')"
                        Dim cmd As SqlCommand = New SqlCommand(query, conn)
                        cmd.ExecuteNonQuery()
                    Next
                    TextBox11.Text = ""
                    Button8.Enabled = False
                    Button3.Enabled = True

                Catch ex As Exception
                    MessageBox.Show(ex.Message & "3")
                End Try

            End If
        End If
    End Sub
    Public Sub Book()

        Try
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim query3 As String = ""
            If ClassOfTravel = "Economy" Then
                query3 = "Select Economy_Seat From FlightSchedule where f_code= '" & f_code & "' and Depart_time='" & deptTime & "'"
            ElseIf ClassOfTravel = "Business" Then
                query3 = "Select Business_Seat From FlightSchedule where f_code= '" & f_code & "' and Depart_time='" & deptTime & "'"
            ElseIf ClassOfTravel = "First Class" Then
                query3 = "Select First_class_Seat From FlightSchedule where f_code= '" & f_code & "' and Depart_time='" & deptTime & "'"
            End If

            Dim cmd3 As SqlCommand = New SqlCommand(query3, conn)
            Dim myreader1 As SqlDataReader
            myreader1 = cmd3.ExecuteReader
            myreader1.Read()

            Dim St As Integer = 0
            Dim bot As Integer = 0
            If ClassOfTravel = "Economy" Then
                St = myreader1("Economy_Seat")
                bot = 102 - St
            ElseIf ClassOfTravel = "Business" Then
                St = myreader1("Business_Seat")
                bot = 54 - St
            ElseIf ClassOfTravel = "First Class" Then
                St = myreader1("First_class_Seat")
                bot = 8 - St
            End If


            Dim seat(3) As Integer
            If NTic = 1 Then
                seat(0) = bot + 1
                St = St - 1
            ElseIf NTic = 2 Then
                seat(0) = bot + 1
                seat(1) = bot + 2
                St = St - 2
            ElseIf NTic = 3 Then
                seat(0) = bot + 1
                seat(1) = bot + 2
                seat(2) = bot + 3
                St = St - 3

            End If
            myreader1.Close()
            Dim query2 As String = ""
            If ClassOfTravel = "Economy" Then
                query2 = "Update FlightSchedule Set Economy_Seat='" & St & "' Where f_code='" & f_code & "' and Depart_time='" & deptTime & "'"
            ElseIf ClassOfTravel = "Business" Then
                query2 = "Update FlightSchedule Set Business_Seat='" & St & "' Where f_code='" & f_code & "' and Depart_time='" & deptTime & "'"
            ElseIf ClassOfTravel = "First Class" Then
                query2 = "Update FlightSchedule Set First_class_Seat='" & St & "' Where f_code='" & f_code & "' and Depart_time='" & deptTime & "'"
            End If

            Dim cmd4 As SqlCommand = New SqlCommand(query2, conn)
            cmd4.ExecuteNonQuery()
            For i = 0 To NTic - 1 Step 1

                Dim query As String = "Insert into Booking_Details values('" & PidNo(i) & "','" & TicketNo(i) & "','" & f_code & "','" & deptTime & "','" & arriTime & "','" & Dat & "','" & ClassOfTravel & "','" & AllSeatno(i) & "')"
                Dim cmd1 As SqlCommand = New SqlCommand(query, conn)
                cmd1.ExecuteNonQuery()

                Dim query1 As String = "Insert into Passenger_details values('" & PidNo(i) & "','" & Pname(i) & "','" & Page(i) & "','" & Padd(i) & "')"
                Dim cmd2 As SqlCommand = New SqlCommand(query1, conn)
                cmd2.ExecuteNonQuery()


            Next


            MessageBox.Show("Ticket Booking Successfull", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Button8.Enabled = False
            Button3.Visible = True
            Button3.Enabled = True
            Button9.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message & "4")
        End Try
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim print As New PrintTicket
        Me.Hide()
        print.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub
End Class
