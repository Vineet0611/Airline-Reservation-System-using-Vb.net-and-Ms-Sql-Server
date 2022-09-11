Imports System.Data.SqlClient
Public Class Add_Employee
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        GroupBox1.BackColor = Color.FromArgb(10, Color.Transparent)
        GroupBox2.BackColor = Color.FromArgb(10, Color.Transparent)
        RadioButton1.BackColor = Color.FromArgb(10, Color.Transparent)
        RadioButton2.BackColor = Color.FromArgb(10, Color.Transparent)
        RadioButton3.BackColor = Color.FromArgb(10, Color.Transparent)
        RadioButton4.BackColor = Color.FromArgb(10, Color.Transparent)
        RadioButton6.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbname.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbfname.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbdob.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbgender.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbms.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbnationality.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbqualification.BackColor = Color.FromArgb(10, Color.Transparent)
        LbAddress.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbphoneno.BackColor = Color.FromArgb(10, Color.Transparent)
        Lbemail.BackColor = Color.FromArgb(10, Color.Transparent)
        Label1.BackColor = Color.FromArgb(10, Color.Transparent)
    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Tbfname.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        Dim back As New AdminOptions
        Me.Hide()
        back.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Email As String = TextBox6.Text
        If Not RadioButton1.Checked AndAlso Not RadioButton2.Checked AndAlso Not RadioButton3.Checked Then
            MessageBox.Show("Please Select A Option For Gender ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not RadioButton4.Checked AndAlso Not RadioButton6.Checked Then
            MessageBox.Show("Please Select A Option for Marital Status ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Tbfname.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("Please Fill All The Fields ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf TextBox5.Text.Length < 10 Or TextBox5.Text.Length > 10 Then
            MessageBox.Show("Phone Number Should Contain 10 Digits ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf CheckEmail(Email) Then
            MessageBox.Show("@ Missing In Email ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf CheckEmail1(Email) Then
            MessageBox.Show(".com or .co.in Missing In Email ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf CheckEmail2(Email) Then
            MessageBox.Show("Domain name Missing In Email " & vbCrLf & "Hint:gmail,yahoo", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                conn.Open()
                Dim cmd As SqlCommand = New SqlCommand("Select Top 1 Emp_Id From Employee_Details  order by Emp_Id desc")
                cmd.Connection = conn
                Dim myreader As SqlDataReader
                myreader = cmd.ExecuteReader
                myreader.Read()
                Dim id As Integer = myreader("Emp_Id")
                Dim Emp_id As Integer = id + 1
                myreader.Close()
                Dim dat As String = DateTimePicker1.Text.ToString
                Dim gender As String = ""
                Dim mstatus As String = ""
                Dim RandGen As New Random
                Dim pass As Integer = RandGen.Next(1000, 9999)
                If RadioButton1.Checked Then
                    gender = "Male"
                ElseIf RadioButton2.Checked Then
                    gender = "Female"
                ElseIf RadioButton3.Checked Then
                    gender = "Other"
                End If
                If RadioButton4.Checked Then
                    mstatus = "Married"
                ElseIf RadioButton6.Checked Then
                    mstatus = "Unmarried"
                End If

                Dim query As String = "Insert into Employee_Details values('" & Emp_id & "','" & Tbfname.Text & "','" & TextBox1.Text & "','" & dat & "','" & gender & "','" & mstatus & "','" & TextBox3.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
                Dim cmd1 As SqlCommand = New SqlCommand(query, conn)
                cmd1.ExecuteNonQuery()

                Dim query2 As String = "Insert into Employee_Login values('" & Emp_id & "','" & Tbfname.Text & "','" & pass & "')"
                Dim cmd2 As SqlCommand = New SqlCommand(query2, conn)
                cmd2.ExecuteNonQuery()

                MessageBox.Show("New Employee Added Successfully" & vbCrLf & "Username :" & Tbfname.Text & vbCrLf & "Password :" & pass, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Tbfname.Text = ""
                TextBox1.Text = ""
                TextBox3.Text = ""
                TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
            MessageBox.Show("Only Numeric Values Allowed ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Public Function CheckEmail(ByVal email As String) As Boolean

        Dim check As Boolean = False
        If email.Contains("@") Then

            Return False
        Else

            Return True

        End If

    End Function
    Public Function CheckEmail1(ByVal email As String) As Boolean

        Dim check As Boolean = False
        If email.Contains(".com") Or email.Contains(".co.in") Then

            Return False
        Else

            Return True

        End If

    End Function
    Public Function CheckEmail2(ByVal email As String) As Boolean

        Dim check As Boolean = False
        If email.Contains("gmail") Or email.Contains("yahoo") Or email.Contains("hotmail") Or email.Contains("outlook") Then

            Return False
        Else

            Return True

        End If

    End Function

End Class
