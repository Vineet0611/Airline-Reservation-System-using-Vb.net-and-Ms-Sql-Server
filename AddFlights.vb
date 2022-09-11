
Imports System.Data.SqlClient

Public Class AddFlights
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Label14.BackColor = Color.FromArgb(10, Color.Transparent)
        Label15.BackColor = Color.FromArgb(10, Color.Transparent)

        Label13.BackColor = Color.FromArgb(10, Color.Transparent)
        DateTimePicker3.MinDate = Date.Today
        DateTimePicker4.MinDate = Date.Today
        DateTimePicker3.MinDate = DateTimePicker3.MinDate.AddDays(5)
        DateTimePicker4.MinDate = DateTimePicker4.MinDate.AddDays(5)
        DateTimePicker3.Value = DateTimePicker3.MinDate
        DateTimePicker4.Value = DateTimePicker4.MinDate
        DateTimePicker4.MaxDate = DateTimePicker4.MinDate.AddMonths(3)
        DateTimePicker3.MaxDate = DateTimePicker3.MinDate.AddMonths(3)
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.Text = "Select" Or ComboBox2.Text = "Select" Or TextBox1.Text = "" Then
            MessageBox.Show("Please Fill All The Fields", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf ComboBox1.Text = ComboBox2.Text Then
            MessageBox.Show("Departure And Arrival Cannot Be Same!!!", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf DateTimePicker4.Value.Date < DateTimePicker3.Value.Date Then
            MessageBox.Show("Arrival Date Is Smaller than Departure Date ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ElseIf DateTimePicker3.Text = DateTimePicker4.Text And DateTimePicker2.Text = DateTimePicker5.Text Then
            MessageBox.Show("Depature and Arrival Time Cannot be Same!!!", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim dept As String = ComboBox1.Text
            Dim arri As String = ComboBox2.Text

            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim cmd As SqlCommand = New SqlCommand("Select f_code from Flight_Info where Source='" + dept + "' and Destination='" + arri + "'")
                cmd.Connection = conn
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader
                myreader.Read()
                Dim f_code As Integer = myreader("f_code")
                Dim DeptTime As String = DateTimePicker3.Text.ToString & " " & DateTimePicker2.Text.ToString
                Dim ArriTime As String = DateTimePicker4.Text.ToString & " " & DateTimePicker5.Text.ToString
                myreader.Close()

                Dim cmd1 As SqlCommand = New SqlCommand("Insert into FlightSchedule values('" & f_code & "','" & DateTimePicker3.Text.ToString & "','" & dept & "','" & DeptTime & "','" & arri & "','" & ArriTime & "','" & Convert.ToInt32(TextBox1.Text) & "','102','54','8')")
                cmd1.Connection = conn
                cmd1.ExecuteNonQuery()
                MessageBox.Show("New Flight Added Successfully", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DateTimePicker3.Text = DateTimePicker3.MinDate
                DateTimePicker4.Text = DateTimePicker4.MinDate
                ComboBox1.Text = "Select"
                ComboBox2.Text = "Select"

                TextBox1.Text = ""

                DateTimePicker2.Text = DateTime.Now
                DateTimePicker5.Text = DateTime.Now

                conn.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)


            End Try
        End If


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Back As New AdminOptions
        Me.Hide()
        Back.Show()

    End Sub

    Private Sub AddFlights_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = "Select"
        ComboBox2.Text = "Select"

        DateTimePicker3.Value = DateTimePicker3.MinDate
        DateTimePicker4.Value = DateTimePicker4.MinDate
        DateTimePicker2.Value = Date.Now
        DateTimePicker5.Value = Date.Now
        TextBox1.Text = ""





    End Sub



    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("Only Numeric Values Allowed ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("Only Numeric Values Allowed ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub
End Class
