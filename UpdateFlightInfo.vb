Imports System.Data.SqlClient
Public Class UpdateFlightInfo
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "Select" Then
            MessageBox.Show("Please Select The Flight Code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim query As String = "Select * from FlightSchedule where f_code='" & ComboBox1.Text & "' and Date='" & DateTimePicker1.Text & "'"
                Dim cmd As SqlCommand = New SqlCommand(query, conn)
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader
                If myreader.Read() Then
                    Dim DeptAt As String = myreader("Depart_At")
                    Dim DeptTime As String = myreader("Depart_Time")
                    Dim ArriAt As String = myreader("Arrival_At")
                    Dim ArriTime As String = myreader("Arrival_Time")

                    Dim date1 As String = myreader("Date")
                    Dim fcode As String = myreader("f_code")

                    Dim Price As Integer = Convert.ToInt32(myreader("Price"))

                    Dim UpdateLT As New UpdateFlightLoctTime
                    UpdateLT.getvalue(DeptAt, DeptTime, ArriAt, ArriTime, Price, date1, fcode)
                    UpdateLT.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("No Flights Found On Given Date For The FlightCode", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    Private Sub AdminLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub UpdateFlightInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label6.BackColor = Color.FromArgb(10, Color.Transparent)
        DateTimePicker1.MinDate = Date.Today
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim Back As New AdminOptions
        Back.Show()
        Me.Hide()
    End Sub
End Class