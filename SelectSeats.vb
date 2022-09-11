Imports System.Data.SqlClient


Public Class SelectSeats
    Dim con As New SqlConnection("Data Source=HARSHADS-DESKTO;Initial Catalog=Airline;User ID=sa;Password=password")

    Private cbchecked As Integer = 0
    Private TicketClassCount1 As Integer = 0
    Private TicketClassCount2 As Integer = 0
    Private TicketClassCount3 As Integer = 0
    Private FlightCodeCount As Integer = 0

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click

        Dim tickno As String = TxtBxPassID.Text
        Dim className As String = ComboClass.Text


        Dim Seat_No As String = ""

        Dim cn As SqlConnection = New SqlConnection
        cn.ConnectionString = "Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True"


        For Each cbName In Me.Controls.OfType(Of CheckBox)
                If cbName.Checked Then
                    Seat_No = cbName.Name
                End If
            Next
        Try

            cn.Open()
            Dim command As New SqlCommand("UPDATE Booking_Details SET Seat_No = '" & Seat_No & "' WHERE Ticket_No ='" & tickno & "' ", cn)
            command.ExecuteNonQuery()
            Button2.Enabled = True
            MessageBox.Show("Seat Selection Successful, Print Your Ticket!", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearEverything()

            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub

    Sub CkBxEnable()
        If ComboClass.Text = "First Class" Then
            _1LW.Enabled = True
            _2LW.Enabled = True
            _1LS.Enabled = True
            _2LS.Enabled = True
            _1US.Enabled = True
            _2US.Enabled = True
            _1UW.Enabled = True
            _2UW.Enabled = True
        End If

        If ComboClass.Text = "Business" Then
            _3LW.Enabled = True
            _4LW.Enabled = True
            _5LW.Enabled = True
            _6LW.Enabled = True
            _7LW.Enabled = True
            _8LW.Enabled = True
            _9LW.Enabled = True
            _10LW.Enabled = True
            _11LW.Enabled = True
            _3LM.Enabled = True
            _4LM.Enabled = True
            _5LM.Enabled = True
            _6LM.Enabled = True
            _7LM.Enabled = True
            _8LM.Enabled = True
            _9LM.Enabled = True
            _10LM.Enabled = True
            _11LM.Enabled = True
            _3LS.Enabled = True
            _4LS.Enabled = True
            _5LS.Enabled = True
            _6LS.Enabled = True
            _7LS.Enabled = True
            _8LS.Enabled = True
            _9LS.Enabled = True
            _10LS.Enabled = True
            _11LS.Enabled = True
            _3US.Enabled = True
            _4US.Enabled = True
            _5US.Enabled = True
            _6US.Enabled = True
            _7US.Enabled = True
            _8US.Enabled = True
            _9US.Enabled = True
            _10US.Enabled = True
            _11US.Enabled = True
            _3UM.Enabled = True
            _4UM.Enabled = True
            _5UM.Enabled = True
            _6UM.Enabled = True
            _7UM.Enabled = True
            _8UM.Enabled = True
            _9UM.Enabled = True
            _10UM.Enabled = True
            _11UM.Enabled = True
            _3UW.Enabled = True
            _4UW.Enabled = True
            _5UW.Enabled = True
            _6UW.Enabled = True
            _7UW.Enabled = True
            _8UW.Enabled = True
            _9UW.Enabled = True
            _10UW.Enabled = True
            _11UW.Enabled = True
        End If

        If ComboClass.Text = "Economy" Then
            _12LW.Enabled = True
            _13LW.Enabled = True
            _14LW.Enabled = True
            _15LW.Enabled = True
            _16LW.Enabled = True
            _17LW.Enabled = True
            _18LW.Enabled = True
            _19LW.Enabled = True
            _20LW.Enabled = True
            _21LW.Enabled = True
            _22LW.Enabled = True
            _23LW.Enabled = True
            _24LW.Enabled = True
            _25LW.Enabled = True
            _26LW.Enabled = True
            _27LW.Enabled = True
            _28LW.Enabled = True
            _12LM.Enabled = True
            _13LM.Enabled = True
            _14LM.Enabled = True
            _15LM.Enabled = True
            _16LM.Enabled = True
            _17LM.Enabled = True
            _18LM.Enabled = True
            _19LM.Enabled = True
            _20LM.Enabled = True
            _21LM.Enabled = True
            _22LM.Enabled = True
            _23LM.Enabled = True
            _24LM.Enabled = True
            _25LM.Enabled = True
            _26LM.Enabled = True
            _27LM.Enabled = True
            _28LM.Enabled = True
            _12LS.Enabled = True
            _13LS.Enabled = True
            _14LS.Enabled = True
            _15LS.Enabled = True
            _16LS.Enabled = True
            _17LS.Enabled = True
            _18LS.Enabled = True
            _19LS.Enabled = True
            _20LS.Enabled = True
            _21LS.Enabled = True
            _22LS.Enabled = True
            _23LS.Enabled = True
            _24LS.Enabled = True
            _25LS.Enabled = True
            _26LS.Enabled = True
            _27LS.Enabled = True
            _28LS.Enabled = True
            _12US.Enabled = True
            _13US.Enabled = True
            _14US.Enabled = True
            _15US.Enabled = True
            _16US.Enabled = True
            _17US.Enabled = True
            _18US.Enabled = True
            _19US.Enabled = True
            _20US.Enabled = True
            _21US.Enabled = True
            _22US.Enabled = True
            _23US.Enabled = True
            _24US.Enabled = True
            _25US.Enabled = True
            _26US.Enabled = True
            _27US.Enabled = True
            _28US.Enabled = True
            _12UM.Enabled = True
            _13UM.Enabled = True
            _14UM.Enabled = True
            _15UM.Enabled = True
            _16UM.Enabled = True
            _17UM.Enabled = True
            _18UM.Enabled = True
            _19UM.Enabled = True
            _20UM.Enabled = True
            _21UM.Enabled = True
            _22UM.Enabled = True
            _23UM.Enabled = True
            _24UM.Enabled = True
            _25UM.Enabled = True
            _26UM.Enabled = True
            _27UM.Enabled = True
            _28UM.Enabled = True
            _12UW.Enabled = True
            _13UW.Enabled = True
            _14UW.Enabled = True
            _15UW.Enabled = True
            _16UW.Enabled = True
            _17UW.Enabled = True
            _18UW.Enabled = True
            _19UW.Enabled = True
            _20UW.Enabled = True
            _21UW.Enabled = True
            _22UW.Enabled = True
            _23UW.Enabled = True
            _24UW.Enabled = True
            _25UW.Enabled = True
            _26UW.Enabled = True
            _27UW.Enabled = True
            _28UW.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxes_CheckedChanged(sender As Object, e As EventArgs) _
                     Handles _1LW.CheckedChanged,
_2LW.CheckedChanged,
_3LW.CheckedChanged,
_4LW.CheckedChanged,
_5LW.CheckedChanged,
_6LW.CheckedChanged,
_7LW.CheckedChanged,
_8LW.CheckedChanged,
_9LW.CheckedChanged,
_10LW.CheckedChanged,
_11LW.CheckedChanged,
_12LW.CheckedChanged,
_13LW.CheckedChanged,
_14LW.CheckedChanged,
_15LW.CheckedChanged,
_16LW.CheckedChanged,
_17LW.CheckedChanged,
_18LW.CheckedChanged,
_19LW.CheckedChanged,
_20LW.CheckedChanged,
_21LW.CheckedChanged,
_22LW.CheckedChanged,
_23LW.CheckedChanged,
_24LW.CheckedChanged,
_25LW.CheckedChanged,
_26LW.CheckedChanged,
_27LW.CheckedChanged,
_28LW.CheckedChanged,
_3LM.CheckedChanged,
_4LM.CheckedChanged,
_5LM.CheckedChanged,
_6LM.CheckedChanged,
_7LM.CheckedChanged,
_8LM.CheckedChanged,
_9LM.CheckedChanged,
_10LM.CheckedChanged,
_11LM.CheckedChanged,
_12LM.CheckedChanged,
_13LM.CheckedChanged,
_14LM.CheckedChanged,
_15LM.CheckedChanged,
_16LM.CheckedChanged,
_17LM.CheckedChanged,
_18LM.CheckedChanged,
_19LM.CheckedChanged,
_20LM.CheckedChanged,
_21LM.CheckedChanged,
_22LM.CheckedChanged,
_23LM.CheckedChanged,
_24LM.CheckedChanged,
_25LM.CheckedChanged,
_26LM.CheckedChanged,
_27LM.CheckedChanged,
_28LM.CheckedChanged,
_1LS.CheckedChanged,
_2LS.CheckedChanged,
_3LS.CheckedChanged,
_4LS.CheckedChanged,
_5LS.CheckedChanged,
_6LS.CheckedChanged,
_7LS.CheckedChanged,
_8LS.CheckedChanged,
_9LS.CheckedChanged,
_10LS.CheckedChanged,
_11LS.CheckedChanged,
_12LS.CheckedChanged,
_13LS.CheckedChanged,
_14LS.CheckedChanged,
_15LS.CheckedChanged,
_16LS.CheckedChanged,
_17LS.CheckedChanged,
_18LS.CheckedChanged,
_19LS.CheckedChanged,
_20LS.CheckedChanged,
_21LS.CheckedChanged,
_22LS.CheckedChanged,
_23LS.CheckedChanged,
_24LS.CheckedChanged,
_25LS.CheckedChanged,
_26LS.CheckedChanged,
_27LS.CheckedChanged,
_28LS.CheckedChanged,
_1US.CheckedChanged,
_2US.CheckedChanged,
_3US.CheckedChanged,
_4US.CheckedChanged,
_5US.CheckedChanged,
_6US.CheckedChanged,
_7US.CheckedChanged,
_8US.CheckedChanged,
_9US.CheckedChanged,
_10US.CheckedChanged,
_11US.CheckedChanged,
_12US.CheckedChanged,
_13US.CheckedChanged,
_14US.CheckedChanged,
_15US.CheckedChanged,
_16US.CheckedChanged,
_17US.CheckedChanged,
_18US.CheckedChanged,
_19US.CheckedChanged,
_20US.CheckedChanged,
_21US.CheckedChanged,
_22US.CheckedChanged,
_23US.CheckedChanged,
_24US.CheckedChanged,
_25US.CheckedChanged,
_26US.CheckedChanged,
_27US.CheckedChanged,
_28US.CheckedChanged,
_3UM.CheckedChanged,
_4UM.CheckedChanged,
_5UM.CheckedChanged,
_6UM.CheckedChanged,
_7UM.CheckedChanged,
_8UM.CheckedChanged,
_9UM.CheckedChanged,
_10UM.CheckedChanged,
_11UM.CheckedChanged,
_12UM.CheckedChanged,
_13UM.CheckedChanged,
_14UM.CheckedChanged,
_15UM.CheckedChanged,
_16UM.CheckedChanged,
_17UM.CheckedChanged,
_18UM.CheckedChanged,
_19UM.CheckedChanged,
_20UM.CheckedChanged,
_21UM.CheckedChanged,
_22UM.CheckedChanged,
_23UM.CheckedChanged,
_24UM.CheckedChanged,
_25UM.CheckedChanged,
_26UM.CheckedChanged,
_27UM.CheckedChanged,
_28UM.CheckedChanged,
_1UW.CheckedChanged,
_2UW.CheckedChanged,
_3UW.CheckedChanged,
_4UW.CheckedChanged,
_5UW.CheckedChanged,
_6UW.CheckedChanged,
_7UW.CheckedChanged,
_8UW.CheckedChanged,
_9UW.CheckedChanged,
_10UW.CheckedChanged,
_11UW.CheckedChanged,
_12UW.CheckedChanged,
_13UW.CheckedChanged,
_14UW.CheckedChanged,
_15UW.CheckedChanged,
_16UW.CheckedChanged,
_17UW.CheckedChanged,
_18UW.CheckedChanged,
_19UW.CheckedChanged,
_20UW.CheckedChanged,
_21UW.CheckedChanged,
_22UW.CheckedChanged,
_23UW.CheckedChanged,
_24UW.CheckedChanged,
_25UW.CheckedChanged,
_26UW.CheckedChanged,
_27UW.CheckedChanged,
_28UW.CheckedChanged

        disable_selected_seats()

        Dim cb As CheckBox = TryCast(sender, CheckBox)
        If cb.Checked Then
            cbchecked += 1
        Else
            cbchecked -= 1
        End If

        If cbchecked = 1 Then
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                    If Not cbx.Checked Then
                    cbx.Enabled = False
                    btnConfirm.Enabled = True
                End If
                Next
            Else
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                CkBxEnable()
                btnConfirm.Enabled = False
            Next
            End If


    End Sub

    Sub EnableCB1()
        If TicketClassCount1 = 1 Then
            disable_selected_seats()
            TicketClassCount1 = 0
            FlightCodeCount = 0
            _1LW.Enabled = True
            _2LW.Enabled = True
            _1LS.Enabled = True
            _2LS.Enabled = True
            _1US.Enabled = True
            _2US.Enabled = True
            _1UW.Enabled = True
            _2UW.Enabled = True
        End If
    End Sub
    Sub EnableCB2()
        If TicketClassCount2 = 1 Then
            disable_selected_seats()
            TicketClassCount2 = 0
            FlightCodeCount = 0
            _3LW.Enabled = True
            _4LW.Enabled = True
            _5LW.Enabled = True
            _6LW.Enabled = True
            _7LW.Enabled = True
            _8LW.Enabled = True
            _9LW.Enabled = True
            _10LW.Enabled = True
            _11LW.Enabled = True
            _3LM.Enabled = True
            _4LM.Enabled = True
            _5LM.Enabled = True
            _6LM.Enabled = True
            _7LM.Enabled = True
            _8LM.Enabled = True
            _9LM.Enabled = True
            _10LM.Enabled = True
            _11LM.Enabled = True
            _3LS.Enabled = True
            _4LS.Enabled = True
            _5LS.Enabled = True
            _6LS.Enabled = True
            _7LS.Enabled = True
            _8LS.Enabled = True
            _9LS.Enabled = True
            _10LS.Enabled = True
            _11LS.Enabled = True
            _3US.Enabled = True
            _4US.Enabled = True
            _5US.Enabled = True
            _6US.Enabled = True
            _7US.Enabled = True
            _8US.Enabled = True
            _9US.Enabled = True
            _10US.Enabled = True
            _11US.Enabled = True
            _3UM.Enabled = True
            _4UM.Enabled = True
            _5UM.Enabled = True
            _6UM.Enabled = True
            _7UM.Enabled = True
            _8UM.Enabled = True
            _9UM.Enabled = True
            _10UM.Enabled = True
            _11UM.Enabled = True
            _3UW.Enabled = True
            _4UW.Enabled = True
            _5UW.Enabled = True
            _6UW.Enabled = True
            _7UW.Enabled = True
            _8UW.Enabled = True
            _9UW.Enabled = True
            _10UW.Enabled = True
            _11UW.Enabled = True
        End If
    End Sub
    Sub EnableCB3()
        If TicketClassCount3 = 1 Then
            disable_selected_seats()
            TicketClassCount3 = 0
            FlightCodeCount = 0
            _12LW.Enabled = True
            _13LW.Enabled = True
            _14LW.Enabled = True
            _15LW.Enabled = True
            _16LW.Enabled = True
            _17LW.Enabled = True
            _18LW.Enabled = True
            _19LW.Enabled = True
            _20LW.Enabled = True
            _21LW.Enabled = True
            _22LW.Enabled = True
            _23LW.Enabled = True
            _24LW.Enabled = True
            _25LW.Enabled = True
            _26LW.Enabled = True
            _27LW.Enabled = True
            _28LW.Enabled = True
            _12LM.Enabled = True
            _13LM.Enabled = True
            _14LM.Enabled = True
            _15LM.Enabled = True
            _16LM.Enabled = True
            _17LM.Enabled = True
            _18LM.Enabled = True
            _19LM.Enabled = True
            _20LM.Enabled = True
            _21LM.Enabled = True
            _22LM.Enabled = True
            _23LM.Enabled = True
            _24LM.Enabled = True
            _25LM.Enabled = True
            _26LM.Enabled = True
            _27LM.Enabled = True
            _28LM.Enabled = True
            _12LS.Enabled = True
            _13LS.Enabled = True
            _14LS.Enabled = True
            _15LS.Enabled = True
            _16LS.Enabled = True
            _17LS.Enabled = True
            _18LS.Enabled = True
            _19LS.Enabled = True
            _20LS.Enabled = True
            _21LS.Enabled = True
            _22LS.Enabled = True
            _23LS.Enabled = True
            _24LS.Enabled = True
            _25LS.Enabled = True
            _26LS.Enabled = True
            _27LS.Enabled = True
            _28LS.Enabled = True
            _12US.Enabled = True
            _13US.Enabled = True
            _14US.Enabled = True
            _15US.Enabled = True
            _16US.Enabled = True
            _17US.Enabled = True
            _18US.Enabled = True
            _19US.Enabled = True
            _20US.Enabled = True
            _21US.Enabled = True
            _22US.Enabled = True
            _23US.Enabled = True
            _24US.Enabled = True
            _25US.Enabled = True
            _26US.Enabled = True
            _27US.Enabled = True
            _28US.Enabled = True
            _12UM.Enabled = True
            _13UM.Enabled = True
            _14UM.Enabled = True
            _15UM.Enabled = True
            _16UM.Enabled = True
            _17UM.Enabled = True
            _18UM.Enabled = True
            _19UM.Enabled = True
            _20UM.Enabled = True
            _21UM.Enabled = True
            _22UM.Enabled = True
            _23UM.Enabled = True
            _24UM.Enabled = True
            _25UM.Enabled = True
            _26UM.Enabled = True
            _27UM.Enabled = True
            _28UM.Enabled = True
            _12UW.Enabled = True
            _13UW.Enabled = True
            _14UW.Enabled = True
            _15UW.Enabled = True
            _16UW.Enabled = True
            _17UW.Enabled = True
            _18UW.Enabled = True
            _19UW.Enabled = True
            _20UW.Enabled = True
            _21UW.Enabled = True
            _22UW.Enabled = True
            _23UW.Enabled = True
            _24UW.Enabled = True
            _25UW.Enabled = True
            _26UW.Enabled = True
            _27UW.Enabled = True
            _28UW.Enabled = True
        End If
    End Sub

    Sub EnableCB()
        For Each cbDisable In Me.Controls.OfType(Of CheckBox)
            cbDisable.Enabled = False
        Next
        If TicketClassCount1 = 1 And FlightCodeCount = 1 Then
            EnableCB1()
        End If
        If TicketClassCount2 = 1 And FlightCodeCount = 1 Then
            EnableCB2()
        End If
        If TicketClassCount3 = 1 And FlightCodeCount = 1 Then
            EnableCB3()
        End If
    End Sub

    Sub ClearEverything()
        TxtBxPassID.Text = ""
        ComboClass.Text = ""


        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.Visible = True
        Next

        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.CheckState = CheckState.Unchecked
        Next
        For Each cbDisable In Me.Controls.OfType(Of CheckBox)
            cbDisable.Enabled = False
        Next




    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearEverything()
    End Sub

    Private Sub SelectSeats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnConfirm.Enabled = False
        Button2.Enabled = False

        For Each cbDisable In Me.Controls.OfType(Of CheckBox)
            cbDisable.Enabled = False
        Next
        ComboClass.Enabled = False

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ComboClass.Text = ""

        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.Visible = True
        Next

        ComboClass.Enabled = True
        Dim conn As SqlConnection = New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
        conn.Open()
        Dim cmd As SqlCommand = New SqlCommand("Select * FROM Booking_Details WHERE Ticket_No = '" & TxtBxPassID.Text & "'", conn)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        If myreader.Read() Then

            Dim dt As String = myreader("Departure_At")
            Dim CurrDate As String = Date.Now().ToString("dd-MM-yyyy HH:mm:ss")
            Dim Diff As System.TimeSpan = (Convert.ToDateTime(dt) - Convert.ToDateTime(CurrDate))
            Dim TimDiff As Integer = CInt(Math.Ceiling(Diff.TotalHours))

            If TimDiff > 0 Then
                ComboClass.Text = myreader("Class_of_travel")
                CkBxEnable()
                disable_selected_seats()
            Else
                MessageBox.Show("The Flight Has Departed Hence The Seat Selection Not Possible", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If


        Else
            MessageBox.Show("No Ticket Found On Given Ticket Number", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        conn.Close()


    End Sub

    Sub disable_selected_seats()
        Dim number_of_rows As Integer = 0
        Dim seats As String()
        Dim f_code As Integer = 0
        Dim deptTime As String = ""
        Dim cn As SqlConnection


        Try
            cn = New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            cn.Open()
            Dim myreader As SqlDataReader

        Dim cmd1 As SqlCommand = New SqlCommand("SELECT * FROM Booking_Details WHERE Ticket_No ='" & Convert.ToInt32(TxtBxPassID.Text) & "'", cn)

        myreader = cmd1.ExecuteReader
            myreader.Read()
            f_code = myreader("f_code")
            deptTime = myreader("Departure_At")
            myreader.Close()
            Dim cm_number_of_seats As SqlCommand = New SqlClient.SqlCommand("SELECT COUNT(*) FROM Booking_Details WHERE f_code = '" & f_code & "' and  Departure_At='" & deptTime & "'", cn)
            number_of_rows = cm_number_of_seats.ExecuteScalar()
            seats = New String(number_of_rows - 1) {}

            cn.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try


        If number_of_rows >= 2 Then
            Dim seat_num_table = New DataTable
            Using con = New SqlClient.SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
                Using da = New SqlClient.SqlDataAdapter("SELECT Seat_No FROM Booking_Details WHERE f_code = '" & f_code & "' and  Departure_At='" & deptTime & "'", con)
                    da.Fill(seat_num_table)
                End Using
            End Using
            For j = 0 To number_of_rows - 1 Step 1
                seats(j) = seat_num_table.Rows(j).Field(Of String)("Seat_No")
            Next
            For l = 0 To number_of_rows - 1 Step 1
                For Each cbName In Me.Controls.OfType(Of CheckBox)
                    If cbName.Name = seats(l) Then
                        cbName.Visible = False
                    End If
                Next
            Next

        ElseIf number_of_rows = 1 Then
            cn.ConnectionString = "Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True"
            cn.Open()
            Dim cm_seat_no As SqlCommand = New SqlClient.SqlCommand("SELECT Seat_No FROM Booking_Details WHERE f_code = '" & f_code & "' and  Departure_At='" & deptTime & "'", cn)
            Dim dr_single_seat_no = cm_seat_no.ExecuteScalar()
            Dim single_seat_no As String = Convert.ToString(dr_single_seat_no)

            cn.Close()

            For Each cbName In Me.Controls.OfType(Of CheckBox)
                If cbName.Name = single_seat_no Then
                    cbName.Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim print As New PrintTicket
        Me.Hide()
        print.Show()
    End Sub

    Private Sub SelectSeats_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim back As New EmployeeOptions
        Me.Hide()
        back.Show()
    End Sub
End Class