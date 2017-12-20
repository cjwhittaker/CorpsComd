Module Game_sequence
    Public Sub initialise_turn()
        If gt = 1 Then
            scenariodefaults.enable_data_entry(False)
            For Each u As cunit In orbat
                u.fired = -1
                u.moved = -1
            Next
        End If
        Randomize(3600 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        p1_hqs = New Collection
        p2_HQs = New Collection
        p1_orbat = New Collection
        p2_orbat = New Collection
        p1_units = New Collection
        p2_Units = New Collection
        oppfire = False
        For Each u As cunit In orbat
            If u.nation = scenariodefaults.player1.Text Then
                p1_orbat.Add(u, u.title)
                If u.comd > 0 Then p1_hqs.Add(u, u.title) Else p1_units.Add(u, u.title)
            Else
                p2_orbat.Add(u, u.title)
                If u.comd > 0 Then p2_HQs.Add(u, u.title) Else p2_Units.Add(u, u.title)
            End If
            If u.comd = 0 Then
                With u
                    .hits = 0
                    .aborts = 0
                    .casualties = 0
                End With
            End If
        Next
    End Sub

    Public Sub determineinitiative()
        Dim p1_roll As Integer = 0, p2_roll As Integer = 0
        'ph = scenariodefaults.player2.Text : nph = scenariodefaults.player1.Text
        'Exit Sub
        Do
            p1_roll = d6() + Val(scenariodefaults.player1_init.Text) : p2_roll = d6() + Val(scenariodefaults.player2_init.Text)
        Loop Until p1_roll <> p2_roll
        If p1_roll > p2_roll Then
            ph = scenariodefaults.player1.Text : nph = scenariodefaults.player2.Text
        Else
            ph = scenariodefaults.player2.Text : nph = scenariodefaults.player1.Text
        End If
        swap_phasing_player(False)
        With resultform
            .ok_button.Visible = False
            .result.Text = "Initiative Phase" + vbNewLine + vbNewLine + ph + " has won the initiative, do they want to move first or second?"
            .yb.Text = "First"
            .yb.Visible = True
            .nb.Text = "Second"
            .nb.Visible = True
            .ShowDialog()
            .ok_button.Visible = False
        End With
        oppfire = False
    End Sub

    Public Sub command_and_control()
        For i As Integer = 1 To 2
            'populate_lists(unit_selection.units, ph_hqs, "Command", "commanders")
            populate_command_structure(unit_selection.comdtree, ph, "Command")
            With unit_selection
                .Tag = "Command"
                .Text = "Command and Control Phase " + ph + " - Game Turn " + Str(gt)
                .ShowDialog()
            End With
            test_for_events(ph, gamedate)
            swap_phasing_player(True)
        Next
    End Sub

    Public Sub air_mission_planning()
        '5 - Reset results of subordination and reset units for tasking
        Dim arty As Boolean = False, air As Boolean = False
        For Each u As cunit In orbat
            If u.comd > 0 Then
                For Each uc As cunit In orbat
                    If uc.comd = 0 Then
                        If Not air And uc.Aircraft And uc.parent = u.title Then
                            u.primary = "Air units"
                            air = True
                        ElseIf Not air Then
                            u.primary = ""
                        Else
                        End If
                        If Not arty And uc.indirect And uc.parent = u.title Then
                            u.loaded = "Arty units"
                            arty = True
                        ElseIf Not arty Then
                            u.loaded = ""
                        Else
                        End If
                    End If
                Next
                air = False : arty = False
            Else
                If u.Aircraft Then u.reset_air_phase()
                If u.indirect And orbat(u.parent).comd <= 3 Then u.task = "DS"
                If u.indirect And orbat(u.parent).comd > 3 Then u.task = "GS"
                If u.indirect Then u.primary = ""
            End If
        Next

        For i = 1 To 2
            With movement
                .Text = "Air Tasking Phase for " + ph + " - Game Turn" + Str(gt)
                .current_phase.Text = movement.Text
                .Tag = "Air Tasking"
                .options_for("Air Tasking")
                .ShowDialog()
            End With
            swap_phasing_player(True)
        Next
    End Sub

    Public Sub break_emcon()
        For i = 1 To 2
            unit_selection.Tag = "Radar On"
            populate_lists(unit_selection.units, ph_units, "Radar On", "")
            If unit_selection.units.Items.Count > 0 Then unit_selection.ShowDialog()
            swap_phasing_player(True)
        Next

    End Sub

    Public Sub artillery_allocation_planning()
        For i = 1 To 2
            With movement
                .Text = "Arty Tasking Phase for " + ph + " - Game Turn " + Str(gt)
                .current_phase.Text = movement.Text
                .Tag = "Arty Tasking"
                .options_for("Arty Tasking")
                .ShowDialog()
            End With
            swap_phasing_player(True)
        Next

    End Sub

    Public Sub deploy_air_missions()
        unit_selection.Tag = "Deploy Aircraft"
        populate_lists(unit_selection.units, orbat, "Deploy Aircraft", "")
        If unit_selection.units.Items.Count > 0 Then
            unit_selection.ShowDialog()
            'quality check step
            For Each ac As cunit In orbat
                If ac.airborne Then
                    dice = d10()
                    dice = 1
                    If dice > ac.quality Or dice = 10 Then ac.task = "Abort"
                End If
            Next
            unit_selection.Tag = "Abort Aircraft"
            populate_lists(unit_selection.units, orbat, "Abort Aircraft", "")
            If unit_selection.units.Items.Count > 0 Then unit_selection.ShowDialog()
        End If
    End Sub

    Public Sub air_to_air(cap_battle As Boolean)
        For Each cap As cunit In orbat
            If cap.task = "CAP" Then cap.fires = False : cap.hits = 0
        Next
        'CAP vs CAP
        For i As Integer = 1 To 2
            unit_selection.Tag = "CAP Missions"
            populate_lists(unit_selection.units, ph_units, "CAP Missions", "")
            If unit_selection.units.Items.Count > 0 And combat.targets.Items.Count > 0 Then
                populate_lists(combat.targets, enemy, IIf(cap_battle, "CAP Targets", "Air Targets"), "")
                unit_selection.ShowDialog()
            End If
            swap_phasing_player(True)
        Next
    End Sub

    Public Sub ground_to_air(purpose As String)
        For i As Integer = 1 To 2
            unit_selection.Tag = "Air Defence"
            unit_selection.title.Text = unit_selection.Tag + " against " + purpose
            populate_lists(unit_selection.units, enemy, "Air Defence", "")
            If unit_selection.units.Items.Count <> 0 Then
                combat.targets.Items.Clear()
                If phase = 10 Then
                    populate_lists(combat.targets, ph_units, "SEAD Defence Targets", "")
                ElseIf cap_deployed(ph_units, enemy) And phase = 8 Then
                    populate_lists(combat.targets, ph_units, "CAP Targets", "")
                Else
                    populate_lists(combat.targets, ph_units, "Air Targets", "")
                End If
                If combat.targets.Items.Count > 0 Then unit_selection.ShowDialog()
            End If
            swap_phasing_player(True)
        Next
        'keep air defenders tactical action pts
        For Each u As cunit In orbat
            If u.comd = 0 Then
                If u.airdefence Then u.comdpts = u.tacticalpts Else u.comdpts = 0
            End If
        Next
    End Sub

    Public Sub conduct_sead()
        For i As Integer = 1 To 2
            unit_selection.Tag = "SEAD"
            populate_lists(unit_selection.units, ph_units, "SEAD", "")
            If unit_selection.units.Items.Count = 0 Then Exit Sub
            populate_lists(combat.targets, enemy, "SEAD Targets", "")
            If combat.targets.Items.Count > 0 Then unit_selection.ShowDialog()
            swap_phasing_player(True)
        Next
    End Sub

    Public Sub conduct_air_to_ground()
        For i As Integer = 1 To 2
            unit_selection.Tag = "Air Ground"
            populate_lists(unit_selection.units, ph_units, "Air Ground", "")
            If unit_selection.units.Items.Count > 0 Then
                populate_lists(combat.targets, enemy, "Ground Targets", "")
                If combat.targets.Items.Count > 0 Then unit_selection.ShowDialog()
            End If
            swap_phasing_player(True)
        Next
    End Sub

    Public Sub artillery_area_fire()
        For Each u As cunit In orbat
            If u.comd = 0 Then
                If u.indirect Then u.tacticalpts = 4
            End If
        Next
        'area fire phase
        For i As Integer = 1 To 2
            If arty_fire_mission("AF", ph_units) Then
                populate_lists(combat.targets, enemy, "Ground Targets", "")
                With movement
                    .Text = "Area Fire Artillery Phase for " + ph + " - Game Turn " + Str(gt)
                    .current_phase.Text = movement.Text
                    .Tag = "Area Fire"
                    .options_for("Area Fire")
                    .ShowDialog()
                End With
            End If
            swap_phasing_player(True)
        Next

    End Sub

    Public Sub artillery_interdiction_markers()
        For i As Integer = 1 To 2
            If arty_fire_mission("IN", ph_units) Then
                With resultform
                    .result.Text = ph + " player must now place his artillery fire interdiction markers"
                    .ShowDialog()
                End With
            End If
            swap_phasing_player(True)
        Next

    End Sub

    Public Sub cb_fire()
        For i As Integer = 1 To 2
            If cb_capable(ph_hqs) And cb_targets(enemy) Then
                If arty_fire_mission("CB", ph_units) Then
                    populate_lists(combat.targets, enemy, "CB Targets", "")
                    With movement
                        .Text = "Counter Battery Artillery Phase for " + ph + " - Game Turn " + Str(gt)
                        .current_phase.Text = movement.Text
                        .Tag = "CB Fire"
                        .options_for("CB Fire")
                        .ShowDialog()
                    End With
                End If
            End If
            swap_phasing_player(True)
        Next
    End Sub

    Public Sub fire_and_movement()
        Do
            For Each u As cunit In orbat
                If u.comd = 0 Then u.reset_fire_phase(ph)
            Next
            populate_lists(combat.targets, enemy, "Ground Targets", "")
            For Each u As cunit In ph_units
                If Not u.has_moved Then u.moving = False
            Next
            For Each u As cunit In ph_hqs
                u.comdpts = 1
            Next
            With movement
                .Text = "Fire and Movement Phase for " + ph + " - Game Turn " + Str(gt)
                .current_phase.Text = movement.Text
                .Tag = "Fire and Movement"
                .options_for("Fire and Movement")
                .ShowDialog()
            End With
            playerphase = playerphase + 1
            swap_phasing_player(True)
        Loop Until playerphase > 2

    End Sub

    Public Sub end_sorties()
        Dim endsortie As String = ""
        For Each subject As cunit In ph_units
            If subject.airborne Then
                subject.lands(False)
                'If subject.disrupted Then subject.sorties = 0 Else subject.sorties = subject.sorties - 1
                'If subject.sorties = 0 Then
                '    subject.airborne = False
                '    subject.sorties = -equipment(subject.equipment).sortie
                endsortie = endsortie + subject.title + ", "
                'End If
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
    End Sub

    Public Sub morale_recovery()
        For i As Integer = 1 To 2
            'Moralerecovery()
            'Phase 1 - spend command points to rally BGs from demoralised and units from rout or repulsed
            unit_selection.Tag = "Demoralisation Recovery"
            populate_lists(unit_selection.units, ph_hqs, "Demoralisation", "")
            If unit_selection.units.Items.Count > 0 Then unit_selection.ShowDialog()
            With movement
                .Text = "Morale Recovery Phase for " + ph + " - Game Turn " + Str(gt)
                .current_phase.Text = movement.Text
                .options_for("Morale Recovery")
                .Tag = "Morale Recovery"
                .ShowDialog()
            End With
            swap_phasing_player(True)
        Next
    End Sub

End Module
