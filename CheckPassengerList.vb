Imports System.Data.SqlClient
Imports System.Configuration



Public Class CheckPassengerList
    Dim dt As New DataTable
    Dim rd As SqlDataReader
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim ada As New SqlDataAdapter
    Dim ds As New DataSet
    Dim loadCheck As Boolean = False
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New EmployeeOptions
        Me.Hide()
        back.Show()
        '---------------------------------
        'Changesss needed here as per Form_Name.open()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim con As SqlConnection = New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            con.Open()
            Dim query As String = "Select Distinct f_code from FlightSchedule"
            Dim cmd As SqlCommand = New SqlCommand(query, con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            ComboBox1.DataSource = dt
            ComboBox1.DisplayMember = "f_code"

        Catch ex As Exception
            MessageBox.Show(ex.Message & "1")
        End Try
        loadCheck = True



    End Sub




    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If loadCheck = True Then


            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            Dim sda As New SqlDataAdapter
            Dim dbdataset As New DataTable
            Dim bsource As New BindingSource
            Try


                conn.Open()
                Dim query As String = "Select Ticket_No,Booking_Details.f_code,Seat_No,Name,Age,Address,Source,Departure_At,Destination,Arrival_At,Class_of_travel
                     from Booking_Details 
                     inner join Passenger_details
                     on Booking_Details.Pass_id=Passenger_details.Pid
                     inner join Flight_Info
                     on Booking_Details.f_code =Flight_Info.f_code
                     where Booking_Details.f_code='" & Convert.ToInt32(ComboBox1.Text) & "'"
                Dim cmd As SqlCommand = New SqlCommand(query, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader()
                If (myreader.Read()) Then
                    myreader.Close()
                    Try
                        sda.SelectCommand = cmd
                        sda.Fill(dbdataset)
                        bsource.DataSource = dbdataset
                        DataGridView1.DataSource = bsource
                        DataGridView1.Columns(7).Width = 170
                        DataGridView1.Columns(1).Width = 70
                        DataGridView1.Columns(2).Width = 70
                        DataGridView1.Columns(4).Width = 50
                        DataGridView1.Columns(0).Width = 70
                        DataGridView1.Columns(9).Width = 170
                        DataGridView1.Columns(10).Width = 145

                        sda.Update(dbdataset)

                        conn.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "3")
                    End Try
                Else
                    MessageBox.Show("No Passenger List  Found on given Flight code")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "2")
            End Try
        End If

    End Sub

    Private Sub DateTimePicker1_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp
        If loadCheck = True Then


            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            Dim sda As New SqlDataAdapter
            Dim dbdataset As New DataTable
            Dim bsource As New BindingSource
            Try


                conn.Open()
                Dim query As String = "Select Ticket_No,Booking_Details.f_code,Seat_No,Name,Age,Address,Source,Departure_At,Destination,Arrival_At,Class_of_travel
                     from Booking_Details 
                     inner join Passenger_details
                     on Booking_Details.Pass_id=Passenger_details.Pid
                     inner join Flight_Info
                     on Booking_Details.f_code =Flight_Info.f_code
                     where Booking_Details.Date='" & DateTimePicker1.Text & "'"
                Dim cmd As SqlCommand = New SqlCommand(query, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader()
                If (myreader.Read()) Then
                    myreader.Close()
                    Try
                        sda.SelectCommand = cmd
                        sda.Fill(dbdataset)
                        bsource.DataSource = dbdataset
                        DataGridView1.DataSource = bsource
                        DataGridView1.Columns(7).Width = 170
                        DataGridView1.Columns(1).Width = 70
                        DataGridView1.Columns(2).Width = 70
                        DataGridView1.Columns(4).Width = 50
                        DataGridView1.Columns(0).Width = 70
                        DataGridView1.Columns(9).Width = 170
                        DataGridView1.Columns(10).Width = 145

                        sda.Update(dbdataset)

                        conn.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "3")
                    End Try
                Else
                    MessageBox.Show("No Ticket Booking Found For Given Date", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "2")
            End Try
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If loadCheck = True Then


            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            Dim sda As New SqlDataAdapter
            Dim dbdataset As New DataTable
            Dim bsource As New BindingSource
            Try


                conn.Open()
                Dim query As String = "Select Ticket_No,Booking_Details.f_code,Seat_No,Name,Age,Address,Source,Departure_At,Destination,Arrival_At,Class_of_travel
                     from Booking_Details 
                     inner join Passenger_details
                     on Booking_Details.Pass_id=Passenger_details.Pid
                     inner join Flight_Info
                     on Booking_Details.f_code =Flight_Info.f_code
                     where Passenger_details.Name Like'" & TextBox1.Text & "%'"
                Dim cmd As SqlCommand = New SqlCommand(query, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader()
                If TextBox1.Text <> "" Then


                    If (myreader.Read()) Then
                        myreader.Close()
                        Try
                            sda.SelectCommand = cmd
                            sda.Fill(dbdataset)
                            bsource.DataSource = dbdataset
                            DataGridView1.DataSource = bsource
                            DataGridView1.Columns(7).Width = 170
                            DataGridView1.Columns(1).Width = 70
                            DataGridView1.Columns(2).Width = 70
                            DataGridView1.Columns(4).Width = 50
                            DataGridView1.Columns(0).Width = 70
                            DataGridView1.Columns(9).Width = 170
                            DataGridView1.Columns(10).Width = 145

                            sda.Update(dbdataset)

                            conn.Close()

                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "3")
                        End Try
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "2")
            End Try
        End If
    End Sub
End Class
