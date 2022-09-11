Imports System.Data.SqlClient
Public Class PrintTicket
    Private Sub PrintTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label1.BackColor = Color.FromArgb(10, Color.Transparent)
        Label2.BackColor = Color.FromArgb(10, Color.Transparent)
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox2.BackColor = Color.FromArgb(10, Color.Transparent)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please Enter The Ticket Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Booking_Details Where Ticket_No='" & TextBox1.Text & "'")
            cmd.Connection = conn
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader

            If myreader.Read() Then
                Dim getTic As New GetTicket
                getTic.getTicNo(TextBox1.Text)
                getTic.Show()
                Me.Hide()
            Else
                MessageBox.Show("No Tickets Found On Given Ticket No ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If

    End Sub

    Private Sub PrintTicket_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New EmployeeOptions
        Me.Hide()
        back.Show()
    End Sub
End Class