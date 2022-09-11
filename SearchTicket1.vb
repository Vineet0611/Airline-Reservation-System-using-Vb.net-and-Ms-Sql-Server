Imports System.Data.SqlClient


Public Class SearchTicket1
    Dim Departure As String = ""
    Dim Arrival As String = ""
    Dim Dat As String = ""
    Dim Adult As Integer = 0
    Dim Child As Integer = 0
    Dim Infant As Integer = 0
    Dim ClassOfTravel As String = ""
    Dim flightCode As Integer = 0
    Dim Arri_At As String = ""
    Dim Arri_time As String = ""
    Dim Cloftrav As String = ""
    Dim Total_Ticket As Integer = 0
    Dim Pname(3) As String
    Dim Page(3) As Integer
    Dim Ticketno(3) As Integer
    Dim PassId(3) As Integer
    Dim Paddress(3) As String
    Dim tt_no As Integer
    Dim Pid As Integer
    Dim Depart_Time As String
    Dim Depart_At As String
    Dim Price As Integer

    Private Sub SearchTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Panel2.BackColor = Color.FromArgb(150, Color.Transparent)
        Panel3.BackColor = Color.FromArgb(150, Color.Transparent)

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
        Label14.BackColor = Color.FromArgb(10, Color.Transparent)
        Label15.BackColor = Color.FromArgb(10, Color.Transparent)
        Label16.BackColor = Color.FromArgb(10, Color.Transparent)
        Label17.BackColor = Color.FromArgb(10, Color.Transparent)
        Label18.BackColor = Color.FromArgb(10, Color.Transparent)
        Label19.BackColor = Color.FromArgb(10, Color.Transparent)
        Label20.BackColor = Color.FromArgb(10, Color.Transparent)
        Label21.BackColor = Color.FromArgb(10, Color.Transparent)
        Label22.BackColor = Color.FromArgb(10, Color.Transparent)


        Button1.Padding = New Padding(0, 0, 0, 0)
        DateTimePicker1.MinDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        DateTimePicker1.MaxDate = DateTimePicker1.MinDate.AddMonths(3)
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
        ComboBox5.SelectedIndex = 0
        ComboBox6.SelectedIndex = 0




    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As String
        Dim b As String
        a = ComboBox1.Text
        b = ComboBox2.Text

        ComboBox1.SelectedItem = b
        ComboBox2.SelectedItem = a

    End Sub

    Private Sub SearchTicket_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim back As New EmployeeOptions
        Me.Hide()
        back.Show()

    End Sub



    Private Sub SearchSubmit_Click(sender As Object, e As EventArgs) Handles SearchSubmit.Click
        Dim sdate As String
        Departure = ComboBox1.Text
        Arrival = ComboBox2.Text
        Adult = ComboBox3.Text
        Child = ComboBox4.Text
        Infant = ComboBox5.Text
        Cloftrav = ComboBox6.Text
        ClassOfTravel = ComboBox6.Text
        sdate = DateTimePicker1.Text

        Dim Query As String = ""
        Total_Ticket = Convert.ToInt32(Adult) + Convert.ToInt32(Child) + Convert.ToInt32(Infant)
        If ComboBox1.Text = "Select" Or ComboBox2.Text = "Select" Or ComboBox6.Text = "Select" Then
            MessageBox.Show("Please Select  All the Fields ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf ComboBox1.Text = ComboBox2.Text Then
            MessageBox.Show("Departure and Arrival value Cannot Be Same ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Total_Ticket > 3 Then
            MessageBox.Show("You Can Only Book Three Tickets At A Time", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else

            If ClassOfTravel = "Economy" Then
                Query = "Select f_code,Depart_At,Depart_time,Arrival_At,Arrival_time,Price,Economy_Seat,Business_Seat,First_class_Seat,Date from FlightSchedule Where Date >='" & sdate & "' and Depart_At='" & Departure & "' and Arrival_At='" & Arrival & "' and Economy_Seat > '" & Total_Ticket & "' "
            ElseIf ClassOfTravel = "Business" Then
                Query = "Select f_code,Depart_At,Depart_time,Arrival_At,Arrival_time,Price,Economy_Seat,Business_Seat,First_class_Seat,Date from FlightSchedule Where Date >='" & sdate & "' and Depart_At='" & Departure & "' and Arrival_At='" & Arrival & "' and Business_Seat > '" & Total_Ticket & "' "
            ElseIf ClassOfTravel = "First Class" Then
                Query = "Select f_code,Depart_At,Depart_time,Arrival_At,Arrival_time,Price,Economy_Seat,Business_Seat,First_class_Seat,Date from FlightSchedule Where Date >='" & sdate & "' and Depart_At='" & Departure & "' and Arrival_At='" & Arrival & "' and First_class_Seat > '" & Total_Ticket & "' "
            End If

            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                Dim sda As New SqlDataAdapter
                Dim dbdataset As New DataTable
                Dim bsource As New BindingSource


                conn.Open()


                Dim cmd As New SqlCommand
                cmd = New SqlCommand(Query, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader
                If (myreader.Read()) Then
                    myreader.Close()
                    sda.SelectCommand = cmd
                    sda.Fill(dbdataset)
                    bsource.DataSource = dbdataset
                    DataGridView1.DataSource = bsource
                    sda.Update(dbdataset)
                    conn.Close()

                    DataGridView1.Columns(0).Width = 70
                    DataGridView1.Columns(1).Width = 100
                    DataGridView1.Columns(2).Width = 190
                    DataGridView1.Columns(3).Width = 100
                    DataGridView1.Columns(4).Width = 190
                    DataGridView1.Columns(5).Width = 50
                    DataGridView1.Columns(6).Width = 120
                    DataGridView1.Columns(7).Width = 120
                    DataGridView1.Columns(8).Width = 117

                    Panel2.Visible = True
                    Panel1.Visible = False
                Else
                    MessageBox.Show("No Tickets Found For Given Date " & vbCrLf & "Or Tickets may be not available for the selected class", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SelectedRowCount As Integer = DataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If SelectedRowCount > 0 Then


            If Total_Ticket = 2 Then
                Label16.Visible = True
                Label17.Visible = True
                Label18.Visible = True
                TextBox4.Visible = True
                TextBox5.Visible = True
                TextBox6.Visible = True

            End If
            If Total_Ticket = 3 Then
                Label16.Visible = True
                Label17.Visible = True
                Label18.Visible = True
                Label13.Visible = True
                Label14.Visible = True
                Label15.Visible = True
                TextBox4.Visible = True
                TextBox5.Visible = True
                TextBox6.Visible = True
                TextBox9.Visible = True
                TextBox8.Visible = True
                TextBox7.Visible = True


            End If
            Panel3.Visible = True
            Panel2.Visible = False

        Else
            MessageBox.Show("Please Select A Row!!!", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.Visible = True
        Panel2.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Panel2.Visible = True
        Panel3.Visible = False

        Label16.Visible = False
        Label17.Visible = False
        Label18.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        TextBox6.Visible = False
        TextBox9.Visible = False
        TextBox8.Visible = False
        TextBox7.Visible = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select Top 1 Ticket_No From Booking_Details order by Ticket_No Desc")
            cmd.Connection = conn
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            tt_no = myreader("Ticket_No")
            myreader.Close()
            Dim cmd1 As SqlCommand = New SqlCommand("Select Top 1 Pid From Passenger_details order by Pid Desc")
            cmd1.Connection = conn
            Dim myreader1 As SqlDataReader
            myreader1 = cmd1.ExecuteReader
            myreader1.Read()
            Pid = myreader1("Pid")
            myreader1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        If Total_Ticket = 1 Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
                MessageBox.Show("Please Fill All The Fields ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                For i = 0 To Total_Ticket - 1 Step 1
                    Pname(0) = TextBox1.Text.ToString
                    Page(0) = Convert.ToInt32(TextBox2.Text)
                    Paddress(0) = TextBox3.Text.ToString
                Next


                Dim NoofTick As Integer = 1
                Ticketno(0) = tt_no + 1
                PassId(0) = Pid + 1

                Dim SelSeat As New SelectSeats1
                SelSeat.getinfo2(NoofTick, Ticketno, Cloftrav, flightCode, Depart_Time)
                SelSeat.SSgetinfo(PassId, Depart_At, Arri_At)
                SelSeat.SSGetinfo1(Adult, Child, Infant, Pname, Depart_Time, Arri_time, Price, Dat)
                SelSeat.SSGetInfo2(Page, Paddress)
                Me.Hide()
                SelSeat.Show()

            End If


        ElseIf Total_Ticket = 2 Then

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox4.Text = "" Then
                MessageBox.Show("Please Fill All The Fields ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                For i = 0 To Total_Ticket - 1 Step 1
                    Pname(0) = TextBox1.Text.ToString
                    Page(0) = Convert.ToInt32(TextBox2.Text)
                    Paddress(0) = TextBox3.Text.ToString
                    Pname(1) = TextBox6.Text.ToString
                    Page(1) = Convert.ToInt32(TextBox5.Text)
                    Paddress(1) = TextBox4.Text.ToString
                Next
                Ticketno(0) = tt_no + 1

                Ticketno(1) = tt_no + 2
                PassId(0) = Pid + 1
                PassId(1) = Pid + 2


                Dim NoofTick As Integer = 2

                Dim SelSeat As New SelectSeats1
                SelSeat.getinfo2(NoofTick, Ticketno, Cloftrav, flightCode, Depart_Time.ToString)
                SelSeat.SSgetinfo(PassId, Depart_At.ToString, Arri_At)
                SelSeat.SSGetinfo1(Adult, Child, Infant, Pname, Depart_Time.ToString, Arri_time, Convert.ToInt32(Price), Dat)
                SelSeat.SSGetInfo2(Page, Paddress)
                Me.Hide()
                SelSeat.Show()

            End If
        ElseIf Total_Ticket = 3 Then

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox4.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
                MessageBox.Show("Please Fill All The Fields ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                For i = 0 To Total_Ticket - 1 Step 1
                    Pname(0) = TextBox1.Text.ToString
                    Page(0) = Convert.ToInt32(TextBox2.Text)
                    Paddress(0) = TextBox3.Text.ToString
                    Pname(1) = TextBox6.Text.ToString
                    Page(1) = Convert.ToInt32(TextBox5.Text)
                    Paddress(1) = TextBox4.Text.ToString
                    Pname(2) = TextBox9.Text.ToString
                    Page(2) = Convert.ToInt32(TextBox8.Text)
                    Paddress(2) = TextBox7.Text.ToString

                Next
                Ticketno(0) = tt_no + 1
                Ticketno(1) = tt_no + 2
                Ticketno(2) = tt_no + 3
                PassId(0) = Pid + 1
                PassId(1) = Pid + 2
                PassId(2) = Pid + 3

                Dim NoofTick As Integer = 3
                Dim SelSeat As New SelectSeats1
                SelSeat.getinfo2(NoofTick, Ticketno, Cloftrav, flightCode, Depart_Time.ToString)
                SelSeat.SSgetinfo(PassId, Depart_At.ToString, Arri_At)
                SelSeat.SSGetinfo1(Adult, Child, Infant, Pname, Depart_Time.ToString, Arri_time, Convert.ToInt32(Price), Dat)
                SelSeat.SSGetInfo2(Page, Paddress)
                Me.Hide()
                SelSeat.Show()


            End If


        End If


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer
        Dim dumdat As String
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        flightCode = selectedRow.Cells(0).Value
        Depart_At = selectedRow.Cells(1).Value
        Depart_time = selectedRow.Cells(2).Value
        Arri_At = selectedRow.Cells(3).Value
        Arri_time = selectedRow.Cells(4).Value
        Price = selectedRow.Cells(5).Value
        dumdat = selectedRow.Cells(9).Value


        Dim SDate() As String = dumdat.Split("-")
        Dat = SDate(2) & "-" & SDate(1) & "-" & SDate(0)


    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("Only Numeric Values Allowed ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("Only Numeric Values Allowed ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("Only Numeric Values Allowed ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class