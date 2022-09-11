Imports System.Data
Imports System.Data.SqlClient
Public Class EmployeeLogin
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox1.BackColor = Color.FromArgb(10, Color.Transparent)
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0
    End Sub
    Private Sub AdminLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Dim rolesele As New RoleSelector
        rolesele.Show()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please Fill All The Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim cmd As SqlCommand = New SqlCommand("Select * from Employee_Login where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'")
                cmd.Connection = conn
                Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim dt As DataTable = New DataTable()
                sda.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Me.Hide()
                    Dim empoption As New EmployeeOptions

                    empoption.Show()
                Else

                    MessageBox.Show("Invalid Login Credentials!!!", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class