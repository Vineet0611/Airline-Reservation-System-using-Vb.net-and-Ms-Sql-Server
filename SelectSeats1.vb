Imports System.Data.SqlClient


Public Class SelectSeats1
    Dim con As New SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")

    Private cbChecked As Integer = 0
    Private TicketClassCount1 As Integer = 0
    Private TicketClassCount2 As Integer = 0
    Private TicketClassCount3 As Integer = 0

    Private ClassName As String
    Private NoOfTickets As Integer
    Private TicketNo() As Integer
    Private f_code As Integer
    Dim PidNo As Integer()
    Dim depatAt As String
    Dim ArrivalAt As String
    Dim Adult As Integer
    Dim Child As Integer
    Dim Infant As Integer
    Dim deptTime As String
    Dim arriTime As String
    Dim Pname(3) As String
    Dim Page(3) As Integer
    Dim Padd(3) As String
    Dim Price As Integer
    Dim dat As String
    Dim all_seat_no As String = ""
    Dim first_seat_no As String = "NUll"
    Dim second_seat_no As String = "NULL"
    Dim third_seat_no As String = "NULL"


    Public Sub getinfo2(ByVal noTic As Integer, ByVal TicNo() As Integer, ByVal cotr As String, ByVal fcode As Integer, ByVal DeTime As String)
        NoOfTickets = noTic
        TicketNo = TicNo
        ClassName = cotr
        f_code = fcode
    End Sub
    Public Sub SSgetinfo(ByVal pid As Integer(), ByVal depAt As String, ByVal arrAt As String)
        PidNo = pid
        depatAt = depAt
        ArrivalAt = arrAt

    End Sub
    Public Sub SSGetinfo1(ByVal adt As Integer, ByVal cld As Integer, ByVal infan As Integer, ByVal pnam As String(), ByVal depttim As String, ByVal arrtim As String, ByVal prz As Integer, ByVal dt As String)
        Adult = adt
        Child = cld
        Infant = infan
        Pname = pnam
        deptTime = depttim
        arriTime = arrtim
        Price = prz
        dat = dt
    End Sub
    Public Sub SSGetInfo2(ByVal age As Integer(), ByVal addr As String())
        Page = age
        Padd = addr
    End Sub
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click




        Dim cn As SqlConnection = New SqlClient.SqlConnection
        cn.ConnectionString = "Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True"
        If NoOfTickets = 1 Then
            For Each cbName In Me.Controls.OfType(Of CheckBox)
                If cbName.Checked Then
                    all_seat_no &= cbName.Name
                    all_seat_no &= ","
                End If
            Next

            If all_seat_no.Length = 5 Then
                all_seat_no = all_seat_no.Remove(4, 1).Insert(4, "")
            ElseIf all_seat_no.Length = 6 Then
                all_seat_no = all_seat_no.Remove(5, 1).Insert(5, "")
            End If

            Dim words = all_seat_no.Split(","c)

            first_seat_no = words(words.Length - 1)

        End If

        If NoOfTickets = 2 Then
            For Each cbName In Me.Controls.OfType(Of CheckBox)
                If cbName.Checked Then
                    all_seat_no &= cbName.Name
                    all_seat_no &= ","
                End If
            Next

            If all_seat_no.Length = 10 Then
                all_seat_no = all_seat_no.Remove(9, 1).Insert(9, "")
            ElseIf all_seat_no.Length = 11 Then
                all_seat_no = all_seat_no.Remove(10, 1).Insert(10, "")
            ElseIf all_seat_no.Length = 12 Then
                all_seat_no = all_seat_no.Remove(11, 1).Insert(11, "")
            End If

            Dim words = all_seat_no.Split(","c)

            first_seat_no = words(words.Length - 1)
            second_seat_no = words(words.Length - 2)

        End If

        If NoOfTickets = 3 Then
            For Each cbName In Me.Controls.OfType(Of CheckBox)
                If cbName.Checked Then
                    all_seat_no &= cbName.Name
                    all_seat_no &= ","
                End If
            Next

            If all_seat_no.Length = 15 Then
                all_seat_no = all_seat_no.Remove(14, 1).Insert(14, "")
            ElseIf all_seat_no.Length = 16 Then
                all_seat_no = all_seat_no.Remove(15, 1).Insert(15, "")
            ElseIf all_seat_no.Length = 17 Then
                all_seat_no = all_seat_no.Remove(16, 1).Insert(16, "")
            ElseIf all_seat_no.Length = 18 Then
                all_seat_no = all_seat_no.Remove(17, 1).Insert(17, "")
            End If

            Dim words = all_seat_no.Split(","c)

            first_seat_no = words(words.Length - 1)
            second_seat_no = words(words.Length - 2)
            third_seat_no = words(words.Length - 3)



        End If

        MessageBox.Show("Seat Selected Successfully", "Airline Reservation System", MessageBoxButtons.OK, MessageBoxIcon.Information)



        BtnPrint.Enabled = True
        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.Visible = True
        Next

        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.CheckState = CheckState.Unchecked
        Next

        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.Visible = False
        Next
        If NoOfTickets = 1 Then
            TxtBxSeat1.Text = first_seat_no
        ElseIf NoOfTickets = 2 Then
            TxtBxSeat1.Text = first_seat_no
            TxtBxSeat2.Text = second_seat_no
        ElseIf NoOfTickets = 3 Then
            TxtBxSeat1.Text = first_seat_no
            TxtBxSeat2.Text = second_seat_no
            TxtBxSeat3.Text = third_seat_no
        End If


        con.Close()
    End Sub

    Sub Unable_First_Class()
        _1LW.Enabled = True
        _2LW.Enabled = True
        _1LS.Enabled = True
        _2LS.Enabled = True
        _1US.Enabled = True
        _2US.Enabled = True
        _1UW.Enabled = True
        _2UW.Enabled = True
    End Sub
    Sub Unable_Second_Class()
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
    End Sub

    Sub Unable_Third_Class()
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
    End Sub

    Sub CkBxEnable()
        If ClassName = "First Class" Then
            Unable_First_Class()
        End If

        If ClassName = "Business" Then
            Unable_Second_Class()
        End If

        If ClassName = "Economy" Then
            Unable_Third_Class()
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
            cbChecked += 1
        Else
            cbChecked -= 1
        End If
        If NoOfTickets = "1" Then
            If cbChecked = 1 Then
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                    If Not cbx.Checked Then
                        cbx.Enabled = False
                    End If
                Next
                btnConfirm.Enabled = True
            Else
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                    CkBxEnable()
                    btnConfirm.Enabled = False
                Next
            End If

            If cb.Checked Then
                TxtBxSeat1.Text = cb.Name
            Else
                TxtBxSeat1.Text = ""
            End If
        End If

        If NoOfTickets = "2" Then
            If cbChecked = 2 Then
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                    If Not cbx.Checked Then
                        cbx.Enabled = False
                    End If
                Next
                btnConfirm.Enabled = True
            Else
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                    CkBxEnable()
                    btnConfirm.Enabled = False
                Next

            End If

            If cb.Checked Then
                If TxtBxSeat1.Text = "" And TxtBxSeat2.Text = "" Then
                    TxtBxSeat1.Text = cb.Name
                ElseIf TxtBxSeat1.Text <> "" And TxtBxSeat2.Text = "" Then
                    TxtBxSeat2.Text = cb.Name
                End If
            Else
                If TxtBxSeat1.Text <> "" And TxtBxSeat2.Text <> "" Then
                    TxtBxSeat2.Text = ""
                ElseIf TxtBxSeat1.Text <> "" And TxtBxSeat2.Text = "" Then
                    TxtBxSeat1.Text = ""
                End If
            End If
        End If

        If NoOfTickets = "3" Then
            If cbChecked = 3 Then
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                    If Not cbx.Checked Then
                        cbx.Enabled = False
                    End If
                Next
                btnConfirm.Enabled = True
            Else
                For Each cbx As CheckBox In Me.Controls.OfType(Of CheckBox)
                    CkBxEnable()
                    btnConfirm.Enabled = False
                Next

            End If

            If cb.Checked Then
                If TxtBxSeat1.Text = "" And TxtBxSeat2.Text = "" And TxtBxSeat3.Text = "" Then
                    TxtBxSeat1.Text = cb.Name
                ElseIf TxtBxSeat1.Text <> "" And TxtBxSeat2.Text = "" And TxtBxSeat3.Text = "" Then
                    TxtBxSeat2.Text = cb.Name
                ElseIf TxtBxSeat1.Text <> "" And TxtBxSeat2.Text <> "" And TxtBxSeat3.Text = "" Then
                    TxtBxSeat3.Text = cb.Name
                End If
            Else
                If TxtBxSeat1.Text <> "" And TxtBxSeat2.Text <> "" And TxtBxSeat3.Text <> "" Then
                    TxtBxSeat3.Text = ""
                ElseIf TxtBxSeat1.Text <> "" And TxtBxSeat2.Text <> "" And TxtBxSeat3.Text = "" Then
                    TxtBxSeat2.Text = ""
                ElseIf TxtBxSeat1.Text <> "" And TxtBxSeat2.Text = "" And TxtBxSeat3.Text = "" Then
                    TxtBxSeat1.Text = ""
                End If
            End If
        End If

    End Sub

    Sub EnableCB1()
        If TicketClassCount1 = 1 Then
            disable_selected_seats()
            TicketClassCount1 = 0
            Unable_First_Class()
        End If
    End Sub
    Sub EnableCB2()
        If TicketClassCount2 = 1 Then
            disable_selected_seats()
            TicketClassCount2 = 0
            Unable_Second_Class()
        End If
    End Sub
    Sub EnableCB3()
        If TicketClassCount3 = 1 Then
            disable_selected_seats()
            TicketClassCount3 = 0
            Unable_Third_Class()
        End If
    End Sub

    Sub EnableCB()
        If TicketClassCount1 = 1 Then
            EnableCB1()
        End If
        If TicketClassCount2 = 1 Then
            EnableCB2()
        End If
        If TicketClassCount3 = 1 Then
            EnableCB3()
        End If
    End Sub

    Sub ClearEverything()

        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.Visible = True
        Next

        For Each cbBtnClick In Me.Controls.OfType(Of CheckBox)
            cbBtnClick.CheckState = CheckState.Unchecked
        Next

        disable_selected_seats()

        TxtBxSeat1.Enabled = False
        TxtBxSeat2.Enabled = False
        TxtBxSeat3.Enabled = False

    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearEverything()
    End Sub

    Private Sub UpdateSeats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnConfirm.Enabled = False
        BtnPrint.Enabled = False

        'If there are 1 or 2 tickets then assign textBoxes In center (changing location)
        If NoOfTickets = 2 Then
            'Label6.Location = New Point(477, 565)
            'TxtBxClass.Location = New Point(525, 565)
            'TxtBxTicket1.Location = New Point(728, 565)
            'TxtBxSeat1.Location = New Point(780, 565)
            'Label3.Location = New Point(740, 538)
            Label8.Visible = True
            Label4.Visible = True
            TxtBxTicket2.Visible = True
            TxtBxSeat2.Visible = True

        End If
        If NoOfTickets = 3 Then
            'Label6.Location = New Point(375, 565)
            'TxtBxClass.Location = New Point(421, 565)
            'TxtBxTicket1.Location = New Point(597, 565)
            'TxtBxSeat1.Location = New Point(658, 565)
            'TxtBxTicket2.Location = New Point(826, 565)
            'TxtBxSeat2.Location = New Point(885, 565)
            'Label3.Location = New Point(620, 538)
            'Label4.Location = New Point(840, 538)
            Label4.Visible = True
            Label8.Visible = True
            Label9.Visible = True
            Label5.Visible = True
            TxtBxTicket2.Visible = True
            TxtBxTicket3.Visible = True
            TxtBxSeat2.Visible = True
            TxtBxSeat3.Visible = True
        End If


        disable_selected_seats()

        TxtBxClass.Text = ClassName


        If NoOfTickets = 2 Then
            TxtBxSeat3.Visible = False
            TxtBxTicket3.Visible = False
            TxtBxTicket1.Text = TicketNo(0)
            TxtBxTicket2.Text = TicketNo(1)
        ElseIf NoOfTickets = 1 Then
            TxtBxSeat2.Visible = False
            TxtBxTicket2.Visible = False
            TxtBxSeat3.Visible = False
            TxtBxTicket3.Visible = False
            TxtBxTicket1.Text = TicketNo(0)
        Else
            TxtBxTicket1.Text = TicketNo(0)
            TxtBxTicket2.Text = TicketNo(1)
            TxtBxTicket3.Text = TicketNo(2)
        End If


        TxtBxClass.ReadOnly = True
        TxtBxSeat1.ReadOnly = True
        TxtBxSeat2.ReadOnly = True
        TxtBxSeat3.ReadOnly = True
        'TxtBxTicket1.ReadOnly = True
        'TxtBxTicket2.ReadOnly = True
        'TxtBxTicket3.ReadOnly = True

        For Each cbdisable In Me.Controls.OfType(Of CheckBox)
            cbdisable.Enabled = False
        Next

        If ClassName = "First Class" Then
            TicketClassCount1 = 1
            EnableCB()
        ElseIf ClassName = "Business" Then
            TicketClassCount2 = 1
            EnableCB()
        ElseIf ClassName = "Economy" Then
            TicketClassCount3 = 1
            EnableCB()
        End If

    End Sub

    Sub disable_selected_seats()

        Dim cn As SqlConnection = New SqlClient.SqlConnection
        cn.ConnectionString = "Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True"
        cn.Open()

        Dim cm_number_of_seats As SqlCommand = New SqlClient.SqlCommand("SELECT COUNT(*) FROM Booking_Details WHERE f_code LIKE '" & f_code & "'", cn)
        Dim number_of_rows = cm_number_of_seats.ExecuteScalar()
        Dim seats As String() = New String(number_of_rows - 1) {}

        cn.Close()

        Dim seat_num_table = New DataTable
        Using con = New SqlClient.SqlConnection("Data Source=LAPTOP-25OBO32L;Initial Catalog=Airline;Integrated Security=True")
            Using da = New SqlClient.SqlDataAdapter("SELECT Seat_No FROM Booking_Details WHERE f_code LIKE '" & f_code & "'", con)
                da.Fill(seat_num_table)
            End Using
        End Using

        If seat_num_table.Rows.Count > 1 Then
            For i = 0 To number_of_rows - 1 Step 1
                seats(i) = seat_num_table.Rows(i).Field(Of String)("Seat_No")
            Next
        End If

        For l = 0 To number_of_rows - 1 Step 1
            For Each cbName In Me.Controls.OfType(Of CheckBox)
                If cbName.Name = seats(l) Then
                    cbName.Visible = False
                End If
            Next
        Next
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs)
        'back kuthe jayacha ahe
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'payment  sathi
        Dim pay As New TicketPayment1
        pay.TTGetInfo2(Page, Padd)
        pay.TTgetinfo(NoOfTickets, TicketNo, PidNo, f_code, depatAt, ArrivalAt, ClassName)
        pay.TTGetinfo1(Adult, Child, Infant, Pname, deptTime, arriTime, Price, dat)
        pay.TTGetSeatno(first_seat_no, second_seat_no, third_seat_no)
        Me.Hide()
        pay.Show()
    End Sub

    Private Sub SelectSeats_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub





    'seat numbers first_seat_no second_seat_no ani third_seat_no madhe save hotat
    'Hya file madhun searchticket madhe seat numbers transfer kar
    'database connection check kr
    'seat numbers show hotat to messagebox remove kr
End Class