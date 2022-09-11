Public Class EmployeeOptions
    Dim username As String
    Private Sub EmployeeOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(150, Color.Transparent)
        Label4.BackColor = Color.FromArgb(10, Color.Transparent)
        Label5.BackColor = Color.FromArgb(10, Color.Transparent)
        Label6.BackColor = Color.FromArgb(10, Color.Transparent)
        Label7.BackColor = Color.FromArgb(10, Color.Transparent)
        Label8.BackColor = Color.FromArgb(10, Color.Transparent)
        PictureBox1.BackColor = Color.FromArgb(10, Color.Transparent)

    End Sub

    Private Sub EmployeeOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.Hide()
        Dim logout As New RoleSelector
        logout.Show()
    End Sub

    Private Sub FlightOccupancyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlightOccupancyToolStripMenuItem.Click
        Dim searchTicket As New SearchTicket1
        Me.Hide()
        searchTicket.Show()
    End Sub


    Private Sub AddFlightsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddFlightsToolStripMenuItem.Click
        Dim printik As New PrintTicket
        printik.Show()
        Me.Hide()

    End Sub

    Private Sub AddEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddEmployeeToolStripMenuItem.Click
        Dim UpdateTick As New UpdateTicket
        UpdateTick.Show()
        Me.Hide()

    End Sub

    Private Sub UpdateFlightInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateFlightInfoToolStripMenuItem.Click
        Dim CnTick As New CancelTicket1
        Me.Hide()
        CnTick.Show()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentToolStripMenuItem.Click
        Dim PrintTic As New PaymetDetail1
        Me.Hide()
        PrintTic.Show()
    End Sub

    Private Sub CanceledTicketsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CanceledTicketsToolStripMenuItem.Click
        Dim viCan As New ViewCanceledTicket
        Me.Hide()
        viCan.Show()
    End Sub

    Private Sub UpdateSeatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateSeatToolStripMenuItem.Click
        Dim Selectseat As New SelectSeats
        Me.Hide()
        Selectseat.Show()
    End Sub

    Private Sub PassengerListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PassengerListToolStripMenuItem.Click
        Dim viewpass As New CheckPassengerList
        Me.Hide()
        viewpass.Show()
    End Sub

    Private Sub ViewFlightsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewFlightsToolStripMenuItem.Click
        Dim viewfli As New ViewFlights
        Me.Hide()
        viewfli.Show()
    End Sub
End Class