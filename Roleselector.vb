Imports System.Drawing.Text

Public Class RoleSelector

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox1.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox2.BackColor = Color.FromArgb(10, Color.Transparent)

        Dim pfc As New PrivateFontCollection
        pfc.AddFontFile("C:\Users\vineet mendon\Desktop\bot\HARRINGT.ttf")
        ' Label2.Font = New Font(pfc.Families(0), 18, FontStyle.Bold)
        ' Label1.Font = New Font(pfc.Families(0), 25, FontStyle.Bold)


        Panel1.BackColor = Color.FromArgb(110, Color.Transparent)
        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.FlatAppearance.BorderSize = 0
    End Sub

    Private Sub RoleSelector_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim admin As New AdminLogin
        Me.Hide()
        admin.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim emp As New EmployeeLogin
        Me.Hide()
        emp.Show()
    End Sub
End Class