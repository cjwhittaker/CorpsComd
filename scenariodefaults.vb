Public Class scenariodefaults
    Public quit As Boolean = False, deployment_complete As Boolean = False
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub start_time_inc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles start_time_inc.ValueChanged
        Dim hrs As Integer
        hrs = (0 + 1 * start_time_inc.Value)
        If hrs > 23 Then start_time_inc.Value = start_time_inc.Value - 1 : Exit Sub
        start_time.Text = Format(TimeSerial(hrs, 0, 0), "HH:mm")
        Current_time.Text = start_time.Text
        gamedate = DateAdd(DateInterval.Hour, -Hour(gamedate) + hrs, gamedate)
    End Sub

    Private Sub loadscenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadscenario.Click
        'Dim y As String
        Dim currdir As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Wargames Automated Play Assistants"
        OpenFileDialog1.InitialDirectory = currdir
        OpenFileDialog1.Filter = "Scenario files (*.sce)|*.sce|All files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then scenario = OpenFileDialog1.FileName Else Exit Sub
        currdir = Replace(OpenFileDialog1.FileName, "\" + OpenFileDialog1.SafeFileName, "")
        My.Computer.FileSystem.CurrentDirectory = currdir
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(scenario)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    If currentRow(0) = "player1=" Then
                        player1.Text = currentRow(1)
                        player1_init.Text = currentRow(2)
                        lock_1.Text = currentRow(3)
                        player1.Tag = player1.Text
                    ElseIf currentRow(0) = "player2=" Then
                        player2.Text = currentRow(1)
                        player2_init.Text = currentRow(2)
                        lock_2.Text = currentRow(3)
                        player2.Tag = player2.Text
                    ElseIf currentRow(0) = "gamedate=" Then
                        gamedate = Convert.ToDateTime(currentRow(1))
                        DateTimePicker1.Value = gamedate
                    ElseIf currentRow(0) = "starttime=" Then
                        start_time.Text = currentRow(1)
                        'If lock_1.Text <> "Locked" And lock_2.Text <> "Locked" Then start_time_inc.Value = Val(currentRow(1))
                    ElseIf currentRow(0) = "dawn=" Then
                        sunrise.Text = currentRow(1)
                    ElseIf currentRow(0) = "dusk=" Then
                        sunset.Text = currentRow(1)
                    ElseIf currentRow(0) = "currenttime=" Then
                        Current_time.Text = currentRow(1)
                    ElseIf currentRow(0) = "gameturn=" Then
                        gameturn.Text = currentRow(1)
                    ElseIf currentRow(0) = "ph=" Then
                        ph = currentRow(1)
                    ElseIf currentRow(0) = "nph=" Then
                        nph = currentRow(1)
                    ElseIf currentRow(0) = "player phase=" Then
                        playerphase = currentRow(1)
                    ElseIf currentRow(0) = "game phase=" Then
                        phase = currentRow(1)
                    ElseIf currentRow(0) = "smoke fired=" Then
                        smokefiredthisturn = Val(currentRow(1))
                    Else
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
        scenario_name.Text = Replace(Mid(Replace(scenario, sys_dir, ""), 2), ".sce", "")
        load_orbat()
        load_events()
        enable_data_entry(True)
        If lock_1.Text = "Locked" Then
            p1_orbat_manager.Enabled = False
            player1.Enabled = False
            player1_init.Enabled = False
            lock_1.Enabled = False
        End If
        If lock_2.Text = "Locked" Then
            p2_orbat_manager.Enabled = False
            player2.Enabled = False
            player2_init.Enabled = False
            lock_2.Enabled = False
        End If
        If Not lock_1.Enabled And Not lock_2.Enabled Then enable_data_entry(False)
    End Sub

    Private Sub savescenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savescenario.Click
        Dim newscenario As String
        SaveFileDialog1.Filter = "Scenario files (*.sce)|*.sce|All files (*.*)|*.*"
        If SaveFileDialog1.ShowDialog Then
            newscenario = SaveFileDialog1.FileName
            If newscenario <> scenario Then scenario = newscenario
            savedata(scenario)
            scenario_name.Text = Mid(Replace(scenario, sys_dir, ""), 2)
        End If

    End Sub

    Private Sub reset_parent()
        For Each u As cunit In orbat
            If u.comd > 0 Then
                For Each n As cunit In orbat
                    If Val(n.parent) = u.sorties Then n.parent = u.title
                Next
            End If
        Next
    End Sub

    Public Sub enable_data_entry(ByRef setting As Boolean)
        start_time_inc.Enabled = setting
        start_time.Enabled = setting
        DateTimePicker1.Enabled = setting
        Current_time.Enabled = setting
        gameturn.Enabled = setting
        player1.Enabled = setting
        player2.Enabled = setting
        player1_init.Enabled = setting
        player2_init.Enabled = setting
        p1_orbat_manager.Enabled = setting
        p2_orbat_manager.Enabled = setting
        lock_1.Enabled = setting
        lock_2.Enabled = setting
        p1_events.Enabled = setting
        p2_events.Enabled = setting
        nextturn.Enabled = Not setting
    End Sub

    Private Sub newscenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newscenario.Click
        reset_form()

        orbat = New Collection
    End Sub

    Private Sub reset_form()
        event_list = New Collection
        orbat = New Collection
        start_time.Text = TimeValue("00:00")
        DateTimePicker1_ValueChanged(DateTimePicker1, Nothing)
        start_time_inc.Value = (10)
        Current_time.Text = start_time.Text
        player1.Text = "" : player1.Tag = "" : player1_init.Text = "" : ph = ""
        player2.Text = "" : player2.Tag = "" : player2_init.Text = "" : nph = ""
        lock_1.Text = "Lock P1 Orbat"
        lock_2.Text = "Lock P2 Orbat"
        gameturn.Text = 1
        enable_data_entry(True)
        phase = 0
        playerphase = 1
        quit = True
        Randomize()
    End Sub

    Private Sub manage_orbats(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p1_orbat_manager.Click, p2_orbat_manager.Click
        Dim p As String, f As String
        p = Strings.Left(sender.Name, 2) : f = Strings.Right(sender.Name, 4)
        If (player1.Text = "" And p = "p1") Or (player2.Text = "" And p = "p2") Then Exit Sub
        If (orbat Is Nothing) Then Exit Sub
        If p = "p1" Then orbatmanager.orbatside = player1.Text Else orbatmanager.orbatside = player2.Text
        populate_command_structure(orbatmanager.comdtree, orbatmanager.orbatside, "Orbat")
        With orbatmanager
            .Text = "Orbat Manager"
            .orbattitle.Text = orbatmanager.orbatside + " - Order of Battle"
            .selectedunit.Visible = True
            .comdtree.HideSelection = False
            .ShowDialog()
        End With
        If scenario Is Nothing Then savescenario_Click(savescenario, Nothing) Else savedata(scenario)

    End Sub

    Private Sub maintain_player_names(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles player1.Leave, player2.Leave
        Dim t As TextBox = sender
        If t.Tag = t.Text Then
            Exit Sub
        ElseIf t.Tag = "" And t.Text <> "" Then
            t.Tag = t.Text
            u = New cunit
            With u
                .title = t.Text + " Root HQ"
                .parent = "root"
                .nation = t.Text
                .comd = 6
            End With
            orbat.Add(u, u.title)
        ElseIf t.Tag <> t.Text Then
            t.Text = t.Tag
        Else
        End If
    End Sub

    Private Sub reset_scenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If orbat Is Nothing Then Exit Sub
        If orbat.Count = 0 Then Exit Sub
        Dim newscenario As String
        SaveFileDialog1.Filter = "Scenario files (*.sce)|*.sce|All files (*.*)|*.*"
        If SaveFileDialog1.ShowDialog Then
            'reset_all_units()
            gameturn.Text = 1
            phase = 0
            playerphase = 1
            newscenario = SaveFileDialog1.FileName
            'savedata(newscenario)
            enable_data_entry(True)
        End If

    End Sub

    Private Sub nextturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextturn.Click
        If orbat Is Nothing Or orbat.Count <= 2 Then Exit Sub
        Me.Visible = False
        gt = Val(gameturn.Text)
        If Hour(TimeValue(Current_time.Text)) > dusk Or Hour(TimeValue(Current_time.Text)) < dawn Then night = True Else night = False

        If Hour(TimeValue(Current_time.Text)) = dusk Or Hour(TimeValue(Current_time.Text)) = dawn Then twilight = True Else twilight = False
        initialise_turn()
        If phase = 0 Then phase = phase + 1
        Do
            Select Case phase
                Case 1 : determineinitiative()
                'Case 2 : smoke_barrage_phase(ph)
                'Case 5 : deploy_air_missions()
                'Case 6 : air_air_combat(ph, nph)
                'Case 7 : If ground_air_required(True) Then ground_to_air(ph_units, enemy_air)
                Case 10 : indirect_fire_phase(ph, nph)
                Case 13 : direct_fire_phase(ph, nph)
                '    'player 1
                Case 15 : command_and_control()
                Case 16 : movement_phase()
                '    'player 2
                Case 17 : command_and_control()
                Case 18 : movement_phase()
                Case 20 : morale_recovery()
                Case 21 : end_sorties()
            End Select
            'If ph <> initiative Then swap_phasing_player(True)
            If phase = 2 Or phase = 10 Or phase = 7 Or phase = 13 Or phase = 16 Or phase = 18 Then
                For Each u As cunit In orbat
                    If u.comd = 0 And u.fires And u.fired <> gt Then u.fired = gt
                Next
            End If
            phase = phase + 1
            If ph <> initiative And phase <> 15 And phase <> 17 Then
                swap_phasing_player(True)
            End If
            If phase = 15 Or phase = 16 Then
                If first_player <> ph Then swap_phasing_player(True)
            End If
            If phase = 17 Or phase = 18 Then
                If first_player = ph Then swap_phasing_player(True)
            End If
            'If phase = 2 Then phase = 17
            'If phase = 18 Then phase = 20
            'savedata(scenario)
            'If phase = 3 Or phase = 6 Or phase = 14 Or phase = 17 Then
            '    If MsgBox("Do you wish to quit the program", MsgBoxStyle.YesNo, "Quit Program") = MsgBoxResult.Yes Then Exit Sub
            'End If

        Loop Until phase = 22
        'Me.Visible = True
        If smokefiredthisturn Then MsgBox("Remove all smoke fired during the last tactical action phase before this one", vbOKOnly + vbInformation, "Remove Smoke")
        smokefiredthisturn = False
        gameturn.Text = gameturn.Text + 1
        gamedate = DateAdd(DateInterval.Hour, 1, gamedate)
        gt = Val(gameturn.Text)
        Current_time.Text = Format(gamedate, "HH:mm")
        phase = 0
        playerphase = 1
        savedata(scenario)
        If Not Me.Visible Then Me.Show()

    End Sub

    Private Sub test(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each u As cunit In orbat
            If u.parent = "115 MRR" And u.comd = 0 Then
                If u.indirect Then u.eligibleCB = True
            End If
        Next
    End Sub

    Private Sub lock_orbats(sender As Object, e As EventArgs) Handles lock_1.Click, lock_2.Click
        sender.text = "Locked"
        If sender.name = "lock_1" Then
            lock_1.Text = "Locked"
            p1_orbat_manager.Enabled = False
            player1.Enabled = False
            player1_init.Enabled = False
            lock_1.Enabled = False
        Else
            lock_2.Text = "Locked"
            p2_orbat_manager.Enabled = False
            player2.Enabled = False
            player2_init.Enabled = False
            lock_2.Enabled = False
        End If
        If Not lock_1.Enabled And Not lock_2.Enabled Then
            savedata(scenario)
            enable_data_entry(False)
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        gamedate = DateTimePicker1.Value
        calcdawn()
    End Sub

    Private Sub calcdawn()

        Dim yr As Integer
        If DateAndTime.Day(gamedate) < 23 And DateAndTime.Month(gamedate) <= 9 Then yr = Year(gamedate) - 1 Else yr = Year(gamedate)
        dawn = Int(0.5 + (6 + 2 * Math.Sin(2 * Math.PI * DateDiff(DateInterval.Day, DateSerial(yr, 9, 23), gamedate) / 365)))
        sunrise.Text = Format(TimeSerial(dawn, 0, 0), "HH:mm")
        dusk = Int(0.5 + (18 - 2 * Math.Sin(2 * Math.PI * DateDiff(DateInterval.Day, DateSerial(yr, 9, 23), gamedate) / 365)))
        sunset.Text = Format(TimeSerial(dusk, 0, 0), "HH:mm")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Stop

    End Sub

    Private Sub manage_events_Click(sender As Object, e As EventArgs) Handles p1_events.Click, p2_events.Click
        If event_list Is Nothing Then event_list = New Collection
        With event_manager
            .Tag = Strings.Left(sender.name, 2)
            .ShowDialog()
            .Tag = ""
        End With
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        For Each u As cunit In orbat
            u.fatigue = 0
        Next
        Dim a As String = Strings.Left("F16-AS", InStr("F16-AS", "-") - 1)
    End Sub


    Private Sub scenariodefaults_Load(sender As Object, e As EventArgs) Handles Me.Load
        sys_dir = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Wargames Automated Play Assistants\Corps Commander"
        g_dir = sys_dir + "\Graphics\"
        d_dir = sys_dir + "\Data\"
        'g_dir = Strings.Left(currdir, InStrRev(sys_dir, "\") - 1) + "\Graphics\"
        'd_dir = Strings.Left(currdir, InStrRev(sys_dir, "\") - 1) + "\Data\"
        eq_list = New Collection
        pnames = New Collection
        load_orbat_properties()
        load_equipment()
        unittypes = New Collection
        load_subunits()
        airground = New unit_selection
        airground.Name = "airground"
        airground.Tag = "Air Ground"
        groundair = New unit_selection
        groundair.Name = "groundair"
        groundair.Tag = "Air Defence"

    End Sub
End Class
