Public Class scenariodefaults
    Public quit As Boolean = False, phase As Integer, playerphase As Integer, deployment_complete As Boolean = False
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub start_time_inc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles start_time_inc.ValueChanged
        Dim mins As Integer, duskmins As Integer
        duskmins = Hour(TimeValue(Dusk.Text)) * 60 + Minute(TimeValue(Dusk.Text))
        mins = (390 + 30 * start_time_inc.Value)
        If mins > duskmins Then start_time_inc.Value = start_time_inc.Value - 1 : Exit Sub
        start_time.Text = Format(TimeSerial(0, mins, 0), "HH:mm")
        Current_time.Text = start_time.Text

    End Sub

    Private Sub dusk_inc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dusk_inc.ValueChanged
        Dim duskmins As Integer, mins As Integer
        duskmins = (16 * 60 + 30 + 30 * dusk_inc.Value)
        mins = Hour(TimeValue(start_time.Text)) * 60 + Minute(TimeValue(start_time.Text))
        If duskmins < mins Then dusk_inc.Value = dusk_inc.Value + 1 : Exit Sub

        Dusk.Text = Format(TimeSerial(0, duskmins, 0), "HH:mm")


    End Sub


    Private Sub loadscenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadscenario.Click
        'Dim y As String
        OpenFileDialog1.Filter = "Scenario files (*.sce)|*.sce|All files (*.*)|*.*"
        Dim currdir As String = ""
        'currdir = "C:\Users\Colin Whittaker\Documents\Wargame Rules\POW"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then scenario = OpenFileDialog1.FileName Else Exit Sub
        'y = Strings.Left(y, (Len(y) - 4))
        currdir = Replace(OpenFileDialog1.FileName, "\" + OpenFileDialog1.SafeFileName, "")
        My.Computer.FileSystem.CurrentDirectory = currdir
        OpenFileDialog1.InitialDirectory = currdir
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
                        player1.Tag = player1.Text
                    ElseIf currentRow(0) = "player2=" Then
                        player2.Text = currentRow(1)
                        player2_init.Text = currentRow(2)
                        player2.Tag = player2.Text
                    ElseIf currentRow(0) = "starttime=" Then
                        start_time.Text = currentRow(1)
                    ElseIf currentRow(0) = "dusk=" Then
                        Dusk.Text = currentRow(1)
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
                        smokefiredlasturn = Val(currentRow(1))
                        smokefiredthisturn = Val(currentRow(2))
                    Else
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & _
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
        load_orbat()
        'load_equipment()
        'load_subunits()
        p1_orbat_manager.Enabled = True
        p2_orbat_manager.Enabled = True
        nextturn.Enabled = True
        If gameturn.Text > 1 Then enable_data_entry(False) Else enable_data_entry(True)
    End Sub

    Private Sub savescenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savescenario.Click
        Dim newscenario As String
        SaveFileDialog1.Filter = "Scenario files (*.sce)|*.sce|All files (*.*)|*.*"
        If SaveFileDialog1.ShowDialog Then
            newscenario = SaveFileDialog1.FileName
            If newscenario <> scenario Then scenario = newscenario
            savedata(scenario)
            save_orbat()

        End If
    End Sub
    Private Sub reset_parent()
        For Each u As cunit In orbat
            If u.comd > 0 Then
                For Each n As cunit In orbat
                    If Val(n.parent) = u.serialno Then n.parent = u.title
                Next
            End If
        Next
    End Sub
    Private Sub inc_turn()
        gameturn.Text = gameturn.Text + 1
        Current_time.Text = Format(TimeSerial(Hour(TimeValue(Current_time.Text)), Minute(TimeValue(Current_time.Text)) + 60, 0), "HH:mm")
    End Sub

    Private Sub enable_data_entry(ByRef setting As Boolean)
        start_time_inc.Enabled = setting
        dusk_inc.Enabled = setting
        start_time.Enabled = setting
        Dusk.Enabled = setting
        Current_time.Enabled = setting
        gameturn.Enabled = setting
        player1.Enabled = setting
        player2.Enabled = setting
        player1_init.Enabled = setting
        player2_init.Enabled = setting
        deployment_complete = Not setting

    End Sub

    Private Sub newscenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newscenario.Click
        reset_form()
        orbat = New Collection
        p1_orbat_manager.Enabled = True
        p2_orbat_manager.Enabled = True
        nextturn.Enabled = True
    End Sub

    Private Sub reset_form()
        start_time.Text = TimeValue("10:00")
        Dusk.Text = TimeValue("18:00")
        start_time_inc.Value = (Hour(start_time.Text) * 60 + Minute(start_time.Text) - 390) / 30
        dusk_inc.Value = (Hour(Dusk.Text) * 60 + Minute(Dusk.Text) - (16 * 60 + 30)) / 30
        Current_time.Text = start_time.Text
        player1.Text = "" : player1.Tag = "" : player1_init.Text = "" : ph = ""
        player2.Text = "" : player2.Tag = "" : player2_init.Text = "" : nph = ""
        gameturn.Text = 1
        enable_data_entry(True)
        phase = 0
        playerphase = 1
        quit = True
        Randomize()
    End Sub

    Private Sub manage_orbats(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p1_orbat_manager.Click, p2_orbat_manager.Click
        Dim t As Button, p As String, f As String
        t = sender
        p = Strings.Left(t.Name, 2) : f = Strings.Right(t.Name, 4)
        If (player1.Text = "" And p = "p1") Or (player2.Text = "" And p = "p2") Then Exit Sub
        If (orbat Is Nothing) Then Exit Sub
        If p = "p1" Then p = player1.Text Else p = player2.Text
        orbatmanager.Tag = f

        With orbatmanager
            .orbattitle.Text = p + " - Order of Battle"
            .populate_command_structure(p)
            .selectedunit.Visible = True
            .comdtree.HideSelection = False
            .ShowDialog()
        End With
        deployment_complete = True
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


    Private Sub reset_scenario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset_scenario.Click
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


    Private Sub determineinitiative()
        Dim p1_roll As Integer = 0, p2_roll As Integer = 0
        'ph = player2.Text : nph = player1.Text
        'Exit Sub
        Do
            p1_roll = d6() + Val(player1_init.Text) : p2_roll = d6() + Val(player2_init.Text)
        Loop Until p1_roll <> p2_roll
        If p1_roll > p2_roll Then
            ph = player1.Text : nph = player2.Text
        Else
            ph = player2.Text : nph = player1.Text
        End If
        With resultform
            .ok_button.Visible = True
            .result.Text = "Initiative Phase" + vbNewLine + vbNewLine + ph + " is the First Player "
            .ShowDialog()
            .ok_button.Visible = False
        End With
        For Each u As cunit In orbat
            If u.indirect Then u.smoke = 2
        Next
        phase = 1
    End Sub
    Private Sub nextturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nextturn.Click
        Dim tmp As String
        If orbat Is Nothing Or orbat.Count <= 2 Then Exit Sub
        'If player1.Text = "" Or player2.Text = "" Or Current_time.Text = Dusk.Text Then GoTo avoidturninc
        If gameturn.Text = 1 Then enable_data_entry(False)
        Randomize(3600 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        'demoralisationrecovery.units.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        sort()
        transport.Name = "transport"
        demoralisationrecovery.Name = "demoralisationrecovery"
        opportunityfire.Name = "opportunityfire"
        aircombat.Name = "aircombat"
        airdefence.Name = "airdefence"
        ca_defenders.Name = "ca_defender"
        'Me.Hide()
        p1_hqs = New Collection
        p2_HQs = New Collection
        p1_orbat = New Collection
        p2_orbat = New Collection
        p1_units = New Collection
        p2_Units = New Collection
        oppfire = False
        For Each u As cunit In orbat
            If u.nation = player1.Text Then
                p1_orbat.Add(u, u.title)
            Else
                p2_orbat.Add(u, u.title)
            End If
        Next

        For Each u As cunit In p1_orbat
            If u.comd > 0 Then p1_hqs.Add(u, u.title) Else p1_units.Add(u, u.title)
        Next
        For Each u As cunit In p2_orbat
            If u.comd > 0 Then p2_HQs.Add(u, u.title) Else p2_Units.Add(u, u.title)
        Next
        Do
            If Hour(TimeValue(Current_time.Text)) > Val(Dusk.Text) Or Hour(TimeValue(Current_time.Text)) < 24 - Val(Dusk.Text) Then night = True Else night = False
            If playerphase = 1 And phase = 0 Then determineinitiative()
            oppfire = False
            If playerphase >= 2 And phase = 1 Then
                tmp = ph
                ph = nph
                nph = tmp
                If playerphase > 2 Then playerphase = 1
            End If
            If ph = player1.Text Then
                ph_hqs = New Collection
                ph_hqs = p1_hqs
                ph_units = New Collection
                ph_units = p1_units
                enemy = New Collection
                enemy = p2_Units
            Else
                ph_hqs = New Collection
                ph_hqs = p2_HQs
                ph_units = New Collection
                ph_units = p2_Units
                enemy = New Collection
                enemy = p1_units
            End If
            'Phase 0 - determine command points
            If phase = 1 Then
                For Each u As cunit In ph_hqs
                    u.comdpts = generatecomdpts(u.quality, u.no_of_units)
                Next

                'phase 0 - allocate tactical points per unit based on quality and role
                For Each u As cunit In ph_units
                    If u.quality = "A" Or u.loiter Then
                        u.tacticalpts = 4
                    ElseIf u.quality = "B" Then
                        u.tacticalpts = 3
                    Else
                        u.tacticalpts = 2
                    End If
                    If u.routed Or u.demoralised Then u.tacticalpts = 0
                    u.fired = False
                    u.moved = False
                    u.comdpts = 0
                Next
                For Each u As cunit In enemy
                    If u.atgw Or (u.airdefence And u.role <> "AC") Or (u.Airsuperiority And u.airborne) Then
                        u.tacticalpts = 3
                    ElseIf u.role <> "AC" Then
                        u.tacticalpts = 4
                    Else

                    End If
                    u.comdpts = 0
                Next
            End If
            '***** Start debug point
            'phase = 5
            'Phase 1 - morale recovery
            If phase = 1 Then
                Moralerecovery()
                'Phase 1 - spend command points to rally BGs from demoralised and units from rout or repulsed
                populate_lists(demoralisationrecovery.units, ph_hqs, "Demoralisation", "")
                If demoralisationrecovery.units.Items.Count > 0 Then demoralisationrecovery.ShowDialog()
                For Each subject As cunit In ph_units
                    If subject.routed Or subject.repulsed Then
                        With movement
                            .Text = "Morale Recovery Phase for " + ph + " - Game Turn " + gameturn.Text
                            .current_phase.Text = movement.Text
                            .options_for("Morale Recovery")
                            .Tag = "Morale Recovery"
                            .ShowDialog()
                        End With
                        Exit For
                    End If
                Next
                phase = phase + 1
            End If
            'phase 2 - Air  Tasking
            If phase = 2 Then
                With movement
                    .Text = "Air Tasking Phase for " + ph + " - Game Turn " + gameturn.Text
                    .current_phase.Text = movement.Text
                    .Tag = "Air Tasking"
                    .options_for("Air Tasking")
                    .ShowDialog()
                End With
                phase = phase + 1
            End If
            'phase 3 - Air Superiority Combat
            If phase = 3 Then
                aircombat.Tag = "Air Superiority"
                If checkaircombat(aircombat.Tag, ph_units) And checkaircombat(aircombat.Tag, enemy) Then
                    populate_lists(aircombat.units, ph_units, aircombat.Tag, "")
                    populate_lists(combat.targets, enemy, "Air Targets", "")
                    ewsupport(enemy, aircombat.Tag)
                    aircombat.ShowDialog()
                End If
                phase = phase + 1
            End If
            'phase 4 - Air Ground attack
            If phase = 4 Then
                aircombat.Tag = "Air-Ground Attack"
                If checkaircombat(aircombat.Tag, ph_units) Then
                    populate_lists(aircombat.units, ph_units, aircombat.Tag, "")
                    populate_lists(combat.targets, enemy, "Ground Attack Targets", "")
                    aircombat.ShowDialog()
                End If
                phase = phase + 1
            End If
            aircombat.Tag = ""
            'Phase 5 - Execute Tactical Actions
            If phase = 5 Then
                populate_lists(opportunityfire.units, enemy, "Opportunity Fire", "")
                populate_lists(ca_defenders.units, enemy, "Close Assault", "")
                populate_lists(combat.targets, enemy, "Ground Targets", "")
                With movement
                    .Text = "Tactical Action Phase for " + ph + " - Game Turn " + gameturn.Text
                    .current_phase.Text = movement.Text
                    .Tag = "Tactical Action"
                    .options_for("Tactical Action")
                    .ShowDialog()
                End With
                smokefiredthisturn = False
                phase = phase + 1
                If smokefiredlasturn Then
                    MsgBox("Remove all smoke fired during the last tactical action phase before this one", vbOKOnly + vbInformation, "Remove Smoke")
                End If
                If smokefiredthisturn Then smokefiredlasturn = True Else smokefiredlasturn = False
            End If

            'Phase 6 - reduce sortie length of Hels
            Dim endsortie As String = ""
            For Each subject As cunit In ph_units
                If subject.airborne Then
                    If subject.routed Or subject.repulsed Then subject.sorties = 0 Else subject.sorties = subject.sorties - 1
                    If subject.sorties = 0 Then
                        subject.airborne = False
                        subject.sorties = -equipment(subject.equipment).sortie
                        endsortie = endsortie + subject.title + ", "
                    End If
                ElseIf subject.sorties <= 0 Then
                    subject.sorties = subject.sorties + 1
                Else
                End If
            Next
            If endsortie <> "" Then
                With resultform
                    .result.Text = "Sorties end for" + vbNewLine + endsortie
                    .ShowDialog()
                End With
            End If
            playerphase = playerphase + 1
            phase = 1
            'savedata(scenario)
            If quit Then GoTo closeprogram
        Loop Until playerphase > 2
        inc_turn()
avoidturninc:
        If Not Me.Visible Then Me.Show()
        Exit Sub
closeprogram:
        If quit Then Me.Close()
    End Sub



    Private Sub test(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles test_button.Click

    End Sub

    Private Sub scenariodefaults_Load(sender As Object, e As EventArgs) Handles Me.Load
        sys_dir = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Corps Commander"
        g_dir = sys_dir + "\Graphics\"
        d_dir = sys_dir + "\Data\"
        'g_dir = Strings.Left(currdir, InStrRev(sys_dir, "\") - 1) + "\Graphics\"
        'd_dir = Strings.Left(currdir, InStrRev(sys_dir, "\") - 1) + "\Data\"

        load_equipment()
        load_subunits()

    End Sub
End Class
