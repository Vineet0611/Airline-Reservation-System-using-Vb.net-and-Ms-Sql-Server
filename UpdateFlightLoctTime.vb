Imports System.Data.SqlClient
Public Class UpdateFlightLoctTime
    Dim DeptAt As String
    Dim DeptTime As String
    Dim ArriAt As String
    Dim ArriTime As String
    Dim ClassTrav As String
    Dim F_code As String
    Dim Dte As String
    Dim Seat As Integer
    Dim TPrice As Integer

    Private Sub UpdateFlightLoctTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
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
        Label15.BackColor = Color.FromArgb(10, Color.Transparent)
        Label16.BackColor = Color.FromArgb(10, Color.Transparent)
        Label17.BackColor = Color.FromArgb(10, Color.Transparent)
        Label18.BackColor = Color.FromArgb(10, Color.Transparent)
        Label19.BackColor = Color.FromArgb(10, Color.Transparent)
        Label20.BackColor = Color.FromArgb(10, Color.Transparent)
        Label21.BackColor = Color.FromArgb(10, Color.Transparent)
        Label22.BackColor = Color.FromArgb(10, Color.Transparent)
        Label10.Text = DeptAt
        Label11.Text = ArriAt
        TextBox1.Text = TPrice
        Label16.Text = Seat
        DateTimePicker1.Text = Convert.ToDateTime(DeptTime)
        DateTimePicker2.Text = Convert.ToDateTime(ArriTime)


    End Sub
    Private Sub AdminLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        DateTimePicker1.Text = Now()
        DateTimePicker2.Text = Now()
        Dim UpdateFI As New UpdateFlightInfo
        UpdateFI.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim oDate As DateTime = Convert.ToDateTime(DeptTime)
        Dim oDate1 As DateTime = Convert.ToDateTime(DateTimePicker1.Value)
        Dim result As Integer = DateTime.Compare(oDate, oDate1)


        Dim oDate2 As DateTime = Convert.ToDateTime(ArriTime)
        Dim oDate3 As DateTime = Convert.ToDateTime(DateTimePicker2.Value)
        Dim result1 As Integer = DateTime.Compare(oDate2, oDate3)

        If Convert.ToInt32(TextBox1.Text) <> TPrice Or result <> 0 Or result1 <> 0 Then

            If DateTimePicker2.Value.Date < DateTimePicker1.Value.Date Then
                MessageBox.Show("Arrival Date Is Smaller than Departure Date ", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ElseIf DateTimePicker2.Text = DateTimePicker1.Text Then


                MessageBox.Show("Depature and Arrival Time Cannot be Same!!!", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Dim conn As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                    conn.Open()
                    Dim query As String = "Update FlightSchedule Set Depart_time ='" & DateTimePicker1.Text & "',Arrival_time='" & DateTimePicker2.Text & "',Price='" & TextBox1.Text & "' where f_code='" & F_code & "' and Depart_Time='" & DeptTime & "'"
                    Dim cmd As SqlCommand = New SqlCommand(query, conn)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Flight Information Updated Successfully", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim back As New UpdateFlightInfo
                    Me.Hide()
                    back.Show()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Else
                MessageBox.Show("No Change In the Data Update Not Possible", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub getvalue(ByVal Depart_At As String, ByVal Depart_Time As String, ByVal Arri_At As String, ByVal Arri_Time As String, ByVal Price As Integer, ByVal Dt As String, ByVal fcode As String)
        DeptAt = Depart_At
        DeptTime = Depart_Time
        ArriAt = Arri_At
        ArriTime = Arri_Time

        TPrice = Price

        Dte = Dt
        F_code = fcode

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class