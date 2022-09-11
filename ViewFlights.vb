Imports System.Data.SqlClient

Public Class ViewFlights
    Dim loadCheck As Boolean = False
    Private Sub ViewFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.BackColor = Color.FromArgb(0, Color.Transparent)
        Label5.BackColor = Color.FromArgb(0, Color.Transparent)
        Label2.BackColor = Color.FromArgb(0, Color.Transparent)
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
                Dim query As String = "Select f_code,Depart_At,Depart_time,Arrival_At,Arrival_time,Price,Economy_Seat,Business_Seat,First_class_Seat from FlightSchedule where f_code='" & Convert.ToInt32(ComboBox1.Text) & "'"
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
                        DataGridView1.Columns(2).Width = 170
                        DataGridView1.Columns(4).Width = 170
                        DataGridView1.Columns(1).Width = 115
                        DataGridView1.Columns(3).Width = 115
                        DataGridView1.Columns(8).Width = 125
                        DataGridView1.Columns(6).Width = 120
                        DataGridView1.Columns(7).Width = 120

                        sda.Update(dbdataset)

                        conn.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "3")
                    End Try
                Else
                    MessageBox.Show("No Flights Found on given Flight Code ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "2")
            End Try
        End If

    End Sub

    Private Sub ViewFlights_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub DateTimePicker1_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp
        If loadCheck = True Then


            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            Dim sda As New SqlDataAdapter
            Dim dbdataset As New DataTable
            Dim bsource As New BindingSource
            Try


                conn.Open()
                Dim query As String = "Select f_code,Depart_At,Depart_time,Arrival_At,Arrival_time,Price,Economy_Seat,Business_Seat,First_class_Seat from FlightSchedule where Date='" & DateTimePicker1.Text & "'"
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
                        DataGridView1.Columns(2).Width = 170
                        DataGridView1.Columns(4).Width = 170
                        DataGridView1.Columns(1).Width = 115
                        DataGridView1.Columns(3).Width = 115
                        DataGridView1.Columns(8).Width = 125
                        DataGridView1.Columns(6).Width = 120
                        DataGridView1.Columns(7).Width = 120

                        sda.Update(dbdataset)

                        conn.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "3")
                    End Try
                Else
                    MessageBox.Show("No Flights Found on given Date", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "2")
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New EmployeeOptions
        Me.Hide()
        back.Show()
    End Sub
End Class