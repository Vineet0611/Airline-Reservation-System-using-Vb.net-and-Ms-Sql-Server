Public Class AdminOptions
    Dim uname As String
    Private Sub AdminOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label6.BackColor = Color.FromArgb(10, Color.Transparent)
        Label7.BackColor = Color.FromArgb(10, Color.Transparent)
        Label8.BackColor = Color.FromArgb(10, Color.Transparent)

        PictureBox1.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox2.BackColor = Color.FromArgb(10, Color.Transparent)

    End Sub
    Private Sub AdminOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()
        Dim logout As New RoleSelector
        logout.Show()

    End Sub

    Private Sub AddFlightsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFlightsToolStripMenuItem.Click
        Dim addFlights As New AddFlights
        Me.Hide()
        addFlights.Show()

    End Sub

    Private Sub AddEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddEmployeeToolStripMenuItem.Click
        Dim addEmp As New Add_Employee
        Me.Hide()
        addEmp.Show()

    End Sub

    Private Sub FlightOccupancyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlightOccupancyToolStripMenuItem.Click
        Dim flightoccu As New Flight_occupancy
        Me.Hide()
        flightoccu.Show()
    End Sub

    Private Sub UpdateFlightInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateFlightInfoToolStripMenuItem.Click
        Dim updatefli1 As New UpdateFlightInfo
        Me.Hide()
        updatefli1.Show()
    End Sub


End Class