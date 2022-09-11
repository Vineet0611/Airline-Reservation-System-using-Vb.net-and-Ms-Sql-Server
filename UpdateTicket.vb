Imports System.Data.SqlClient
Public Class UpdateTicket
    Private Sub UpdateTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
    End Sub
    Private Sub AdminLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New EmployeeOptions
        back.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please Enter The Ticket number", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select * from Booking_Details Where Ticket_No='" & TextBox1.Text & "'")
            cmd.Connection = conn
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader

            If myreader.Read() Then
                Dim deptime As String = myreader("Departure_At")
                Dim CurrDate As String = Date.Now().ToString("dd-MM-yyyy HH:mm:ss")
                Dim Diff As System.TimeSpan = (Convert.ToDateTime(deptime) - Convert.ToDateTime(CurrDate))
                Dim TimDiff As Integer = CInt(Math.Ceiling(Diff.TotalHours))
                If TimDiff < 0 Then
                    MessageBox.Show("The Flight has Already Departed " & vbCrLf & "Update Of The Ticket Not Possible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Dim UpdateD As New UpdateDetails
                    UpdateD.getTicNo(TextBox1.Text)
                    UpdateD.Show()
                    Me.Hide()
                End If

            Else
                MessageBox.Show("No Tickets Found On Given Ticket No ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End If

    End Sub
End Class