Imports System.Drawing.Text
Public Class WelcomePage


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True

        Dim pfc As New PrivateFontCollection
        pfc.AddFontFile("C:\Users\vineet mendon\Desktop\bot\HARRINGT.ttf")
        Label3.Font = New Font(pfc.Families(0), 28, FontStyle.Bold)
        'Label1.Font = New Font(pfc.Families(0), 28, FontStyle.Bold)


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 1000

        If ProgressBar2.Value = ProgressBar2.Maximum Then
            Dim frm2 As New RoleSelector
            Timer1.Dispose()
            Me.Hide()
            frm2.Show()
        End If
        If ProgressBar2.Value <= ProgressBar2.Maximum - 1 Then
            ProgressBar2.Value += 10
            If ProgressBar2.Value = 10 Then
                Label5.Text = "10%"

            ElseIf ProgressBar2.Value = 20 Then
                Label5.Text = "20%"
                Label1.Text = "Connecting to Database"
            ElseIf ProgressBar2.Value = 30 Then
                Label5.Text = "30%"
                Label1.Text = "Connecting to Database."
            ElseIf ProgressBar2.Value = 40 Then
                Label5.Text = "40%"
                Label1.Text = "Connecting to Database.."
            ElseIf ProgressBar2.Value = 50 Then
                Label5.Text = "50%"
                Label1.Text = "Connecting to Database..."
            ElseIf ProgressBar2.Value = 60 Then
                Label5.Text = "60%"
                Label1.Text = "Launching the Application"
            ElseIf ProgressBar2.Value = 70 Then
                Label5.Text = "70%"
                Label1.Text = "Launching the Application."
            ElseIf ProgressBar2.Value = 80 Then
                Label5.Text = "80%"
                Label1.Text = "Launching the Application.."
            ElseIf ProgressBar2.Value = 90 Then
                Label5.Text = "90%"
                Label1.Text = "Launching the Application..."
            ElseIf ProgressBar2.Value = 100 Then
                Label5.Text = "100%"

            End If
        End If



    End Sub


End Class
