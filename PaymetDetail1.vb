Imports System.Data.SqlClient
Public Class PaymetDetail1

    Private Sub PaymetDetail1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label4.BackColor = Color.FromArgb(0, Color.Transparent)
        Label1.BackColor = Color.FromArgb(0, Color.Transparent)
        Label2.BackColor = Color.FromArgb(0, Color.Transparent)
        PictureBox3.BackColor = Color.FromArgb(0, Color.Transparent)
        Label5.BackColor = Color.FromArgb(0, Color.Transparent)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please Enter The Ticket Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim cmd As SqlCommand = New SqlCommand("Select * from Booking_Details where Ticket_No='" & TextBox1.Text & "' ")
                cmd.Connection = conn
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader
                If myreader.Read() Then
                    Dim Paymentdetail As New PaymentDetail2
                    Paymentdetail.GetTicket(TextBox1.Text)
                    Me.Hide()
                    Paymentdetail.Show()
                Else
                    MessageBox.Show("No Tickets Found On Given Ticket Number", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New EmployeeOptions
        Me.Hide()
        back.Show()
    End Sub
End Class