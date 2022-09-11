Imports System.Data.SqlClient
Public Class Flight_occupancy
    Private Sub Flight_occupancy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label1.BackColor = Color.FromArgb(10, Color.Transparent)
        Label2.BackColor = Color.FromArgb(10, Color.Transparent)
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label6.BackColor = Color.FromArgb(10, Color.Transparent)
        Label7.BackColor = Color.FromArgb(10, Color.Transparent)
        Label8.BackColor = Color.FromArgb(10, Color.Transparent)
        Label9.BackColor = Color.FromArgb(10, Color.Transparent)
        Label12.BackColor = Color.FromArgb(10, Color.Transparent)
        Label13.BackColor = Color.FromArgb(10, Color.Transparent)
        Label14.BackColor = Color.FromArgb(10, Color.Transparent)
        Label15.BackColor = Color.FromArgb(10, Color.Transparent)
        Label16.BackColor = Color.FromArgb(10, Color.Transparent)
        Label17.BackColor = Color.FromArgb(10, Color.Transparent)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Back As New AdminOptions
        Me.Hide()
        Back.Show()
    End Sub

    Private Sub Flight_occupancy_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = "Select"
        Label15.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        DateTimePicker2.Text = Now()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "Select" Then
            MessageBox.Show("Please Select The Flight Code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim query As String = "Select Economy_Seat,Business_Seat,First_class_Seat From FlightSchedule where f_code='" & ComboBox1.Text & "' and Date='" & DateTimePicker2.Text & "'"
                Dim cmd As SqlCommand = New SqlCommand(query, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader
                If myreader.Read() Then

                    Dim SeatCount As Integer = myreader("Economy_Seat")

                    Dim OccSeat As Integer = 102 - SeatCount
                    Label17.Text = OccSeat


                    Dim SeatCount1 As Integer = myreader("Business_Seat")
                    Dim OccSeat1 As Integer = 54 - SeatCount1
                    Label16.Text = OccSeat1


                    Dim SeatCount2 As Integer = myreader("First_class_Seat")
                    Dim OccSeat2 As Integer = 8 - SeatCount2
                    Label15.Text = OccSeat2
                    myreader.Close()
                    conn.Close()
                Else
                    MessageBox.Show("No Flights Found On Given Date And Time", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    myreader.Close()
                    conn.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)


            End Try
        End If
    End Sub
End Class
