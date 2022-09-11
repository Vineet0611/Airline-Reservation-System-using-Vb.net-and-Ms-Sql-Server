Imports System.Data.SqlClient
Public Class PaymentDetail2
    Dim TicketNo As String
    Private Sub PaymentDetail2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub PaymentDetail2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(180, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label1.BackColor = Color.FromArgb(0, Color.Transparent)
        Label2.BackColor = Color.FromArgb(0, Color.Transparent)
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
        PictureBox3.BackColor = Color.FromArgb(0, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label6.Text = TicketNo
        Try
            Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            conn.Open()
            Dim cmd As SqlCommand = New SqlCommand("Select Top 1 Passenger_details.Name,Amount,Time_Of_Payment,Card_No,Account_No,UPI
                From Booking_Details
                inner join Payment_Details
                on Booking_Details.Pass_id=Payment_Details.Pid
                inner join Passenger_details
                on Booking_Details.Pass_id=Passenger_details.Pid
                where Ticket_No='" & TicketNo & "'
                order by Amount Asc ;")
            cmd.Connection = conn
            Dim myreader As SqlDataReader
            myreader = cmd.ExecuteReader
            myreader.Read()
            Label4.Text = myreader("Name")
            Label8.Text = myreader("Amount")
            Label10.Text = myreader("Time_Of_Payment")
            Dim cardn As String = myreader("Card_No")
            Dim accn As String = myreader("Account_No")
            Dim upn As String = myreader("UPI")
            If accn = "NA" And upn = "NA" Then
                Label14.Text = "Card_No :"
                Label12.Text = myreader("Card_No")

            ElseIf cardn = "NA" And upn = "NA" Then
                Label14.Text = "Account_No :"
                Label12.Text = myreader("Account_No")
            ElseIf cardn = "NA" And accn = "NA" Then
                Label14.Text = "UPI ID :"
                Label12.Text = myreader("UPI")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub GetTicket(ByVal tno As String)
        TicketNo = tno
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New PaymetDetail1
        Me.Hide()
        back.Show()
    End Sub
End Class