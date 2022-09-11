Imports System.Data.SqlClient
Public Class ViewCanceledTicket
    Dim loadCheck As Boolean = False
    Private Sub ViewCanceledTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Panel1.BackColor = Color.FromArgb(180, Color.Transparent)
        Label1.BackColor = Color.FromArgb(0, Color.Transparent)
        Label2.BackColor = Color.FromArgb(0, Color.Transparent)
        Label3.BackColor = Color.FromArgb(0, Color.Transparent)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If loadCheck = True Then


            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            Dim sda As New SqlDataAdapter
            Dim dbdataset As New DataTable
            Dim bsource As New BindingSource
            Try


                conn.Open()
                Dim query As String = "select pass_id,Ticket_no,Canceled_Ticket.f_code,Name,Source,depart_time,Destination,Arrival_time,Seat_no,class
                              from Canceled_Ticket
                              inner join Flight_Info 
                              on Canceled_Ticket.f_code=Flight_info.f_code 
                              inner join Passenger_details
                              on Canceled_Ticket.pass_id=Passenger_details.Pid
                              where Canceled_Ticket.f_code='" & Convert.ToInt32(ComboBox1.Text) & "'
                              order by Pass_id;"
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
                        DataGridView1.Columns(4).Width = 150
                        DataGridView1.Columns(6).Width = 150
                        DataGridView1.Columns(8).Width = 157
                        sda.Update(dbdataset)

                        conn.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "3")
                    End Try
                Else
                    MessageBox.Show("No Flights Cancelation Found on given Flight code", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Dim query As String = "select pass_id,Ticket_no,Canceled_Ticket.f_code,Name,Source,depart_time,Destination,Arrival_time,Seat_no,class
                              from Canceled_Ticket
                              inner join Flight_Info 
                              on Canceled_Ticket.f_code=Flight_info.f_code 
                              inner join Passenger_details
                              on Canceled_Ticket.pass_id=Passenger_details.Pid
                              where Canceled_Ticket.date='" & DateTimePicker1.Text & "'
                              order by Pass_id;"
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
                        DataGridView1.Columns(4).Width = 150
                        DataGridView1.Columns(6).Width = 150
                        DataGridView1.Columns(8).Width = 157
                        sda.Update(dbdataset)

                        conn.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "3")
                    End Try
                Else
                    MessageBox.Show("No Flights Cancelation Found on given Date", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "3")
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New EmployeeOptions
        Me.Hide()
        back.Show()
    End Sub

    Private Sub ViewCanceledTicket_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class