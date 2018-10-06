Module Game_sequence
    Public Sub initialise_turn()
        If gt = 1 And phase = 0 Then
            scenariodefaults.enable_data_entry(False)
            For Each u As cunit In orbat
                u.fired = -1
                u.moved = -1
                If u.indirect Then u.smoke = -4
                If u.comd = 0 Then If Not u.conc Then u.mode = disp Else u.mode = conc
            Next
        End If
        Randomize(3600 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        oppfire = False
        For Each u As cunit In orbat
            If u.comd = 0 Then u.reset_unit()
        Next
        If phase <> 0 Then swap_phasing_player(False)
        gameturn = " for Game Turn" + Str(gt) + " at " + Format(gamedate, "HHmm") + "hrs " + Format(gamedate, "dd MMM yyyy")
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
        initiative = ph
        swap_phasing_player(False)
        With resultform_2
            .ok_button.Visible = False
            .result.Text = "Initiative Phase" + vbNewLine + vbNewLine + ph + " has won the initiative, do they want to move first or second?"
            .yb.Text = "First"
            .yb.Visible = True
            .nb.Text = "Second"
            .nb.Visible = True
            .ShowDialog()
            .yb.Visible = False
            .nb.Visible = False
            .ok_button.Visible = True
        End With
        oppfire = False
    End Sub

    Public Sub command_and_control()
        'populate_lists(unit_selection.units, ph_hqs, "Command", "commanders")
        'populate_command_structure(unit_selection.comdtree, ph, "Command")
        populate_lists(movement.units, ph_hqs, "Command", "")
        With movement
            .Tag = "Command"
            .Text = "Command and Control Phase " + gameturn
            .options_for("Command")
            .ShowDialog()
        End With
        test_for_events(ph, gamedate)
    End Sub

    Public Sub direct_fire_phase(first As String, second As String)
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        populate_lists(combat_2.targets, enemy, "Ground Targets", second)
        populate_lists(combat_2.firers, ph_units, "Direct Fire", first)
        populate_lists(combat_2.firers, friend_air, "Direct Fire", first)
        With combat_2
            .Tag = "Direct Fire"
            .enable_controls(True, combat_2.directfirepanel)
            .enable_controls(True, combat_2.targetpanel)
            .observation(False)
            .firer = New cunit
            .target = New cunit
            .firesmoke.Visible = False
            .fire.Visible = True
            '.abort_firer.Visible = False
            '.abort_target.Visible = False
            '.ta_altitude_label.Visible = False
            '.ta_altitude.Visible = False
            .range_not_needed = False
        End With
        If Not combat_2.Visible Then
            With combat_2
                .Text = "Direct Fire Sub Phase for " + gameturn
                .ShowDialog()
            End With
        End If

    End Sub

    Public Sub indirect_fire_phase(first As String, second As String)
        combat_2.targets.Items.Clear()
        combat_2.artillery.Items.Clear()
        combat_2.observers.Items.Clear()
        populate_lists(combat_2.targets, enemy, "Ground Targets", second)
        populate_lists(combat_2.artillery, ph_units, "Indirect Fire", first)
        populate_lists(combat_2.observers, ph_units, "Observers", first)
        populate_lists(combat_2.observers, friend_air, "Observers", first)

        With combat_2
            .Tag = "Indirect Fire"
            .enable_controls(True, combat_2.indirectfirepanel)
            .enable_controls(True, combat_2.targetpanel)
            .observation(True)
            .firer = New cunit
            .target = New cunit
            .observer = New cunit
            .indirectfirepanel.Visible = True
            .directfirepanel.Visible = False
            .firesmoke.Visible = False
            .fire.Visible = True
            .firesmoke.Visible = False

            '.abort_firer.Visible = False
            '.abort_target.Visible = False
            '.ta_altitude_label.Visible = False
            '.ta_altitude.Visible = False
            .range_not_needed = False
        End With
        If Not combat_2.Visible Then
            With combat_2
                .Text = "Indirect Fire Sub Phase for " + gameturn
                .ShowDialog()
                .indirectfirepanel.Visible = False
                .directfirepanel.Visible = True

            End With
        End If

    End Sub

    Public Sub smoke_barrage_phase(first As String)
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        'populate_lists(combat_2.targets, enemy, "Ground Targets", target)
        populate_lists(combat_2.firers, ph_units, "Smoke Barrage", first)
        With combat_2
            .Tag = "Smoke Barrage"
            .enable_controls(True, combat_2.indirectfirepanel)
            .enable_controls(True, combat_2.targetpanel)
            .indirectfirepanel.Visible = False
            .directfirepanel.Visible = True
            .observation(False)
            .firer = New cunit
            .target = New cunit
            .firesmoke.Visible = True
            '.abort_firer.Visible = False
            '.abort_target.Visible = False
            '.ta_altitude_label.Visible = False
            '.ta_altitude.Visible = False
            .range_not_needed = False
            '.ShowDialog()
        End With
        If Not combat_2.Visible Then
            With combat_2
                .Text = "Smoke Barrage Sub Phase" + gameturn
                .ShowDialog()
            End With
        End If
    End Sub

    'Public Sub break_emcon()
    '    For i = 1 To 2
    '        unit_selection.Tag = "Radar On"
    '        populate_lists(unit_selection.units, ph_units, "Radar On", "")
    '        If unit_selection.units.Items.Count > 0 Then unit_selection.ShowDialog()
    '        swap_phasing_player(True)
    '    Next

    'End Sub

    'Public Sub artillery_allocation_planning()
    '    Dim arty As Boolean
    '    For i = 1 To 2
    '        arty = False
    '        For Each u As cunit In orbat
    '            If u.comd = 0 Then
    '                If u.nation = ph And u.indirect Then
    '                    hq_functions(orbat(u.parent), "Arty units")
    '                    If u.primary Is Nothing Then u.primary = ""
    '                    If u.primary <> "" And orbat.Contains(u.primary) Then hq_functions(orbat(u.primary), "Arty units")
    '                    arty = True
    '                    If u.task = "" Then u.task = "DS"
    '                    'If orbat(u.parent).comd > 3 Then u.task = "GS"
    '                    'If u.indirect Then u.primary = ""
    '                End If
    '            End If
    '        Next
    '        If arty Then
    '            With movement
    '                .Text = "Arty Tasking Phase for " + ph + " - Game Turn " + Str(gt)
    '                .Tag = "Arty Tasking"
    '                .options_for("Arty Tasking")
    '                .ShowDialog()
    '            End With
    '            swap_phasing_player(True)
    '        End If
    '    Next

    'End Sub

    Public Sub deploy_air_missions()
        unit_selection.Tag = "Deploy Aircraft"
        populate_lists(unit_selection.units, orbat, "Deploy Aircraft", "")
        If unit_selection.units.Items.Count > 0 Then unit_selection.ShowDialog()
        '    'quality check step
        '    For Each ac As cunit In orbat
        '        If ac.airborne Then
        '            dice = d10()
        '            'dice = 1
        '            If dice > ac.quality Or dice = 10 Then ac.task = "Abort"
        '        End If
        '    Next
        '    unit_selection.Tag = "Abort Aircraft"
        '    populate_lists(unit_selection.units, orbat, "Abort Aircraft", "")
        '    If unit_selection.units.Items.Count > 0 Then unit_selection.ShowDialog()
        'End If
    End Sub

    Public Sub air_air_combat(first As String, second As String)
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        Dim cap_result As String = air_assessment(1, "")
        Dim adsam As Boolean = IIf(InStr(cap_result, "ADSAM") > 0, True, False)
        If cap_result <> "None" Then
            If Not adsam Then
                populate_lists(combat_2.firers, friend_air, "CAP Combat", "firer")
                populate_lists(combat_2.targets, enemy_air, "CAP Combat", "")
            Else
                populate_lists(combat_2.firers, IIf(adsam, ph_units, enemy), "ADSAM Fire", IIf(adsam, first, second))
                populate_lists(combat_2.targets, IIf(adsam, enemy_air, friend_air), "CAP Combat", IIf(adsam, second, first))
            End If
            With combat_2
                .Tag = "Air to Air"
                .directfirepanel.Visible = True
                .directfirepanel.Enabled = True
                .targetpanel.Enabled = True
                .enable_controls(False, combat_2.directfirepanel)
                .enable_controls(False, combat_2.targetpanel)
                .observation(False)
                .interceptor = cap_result
                .firer = New cunit
                .target = New cunit
                .fire.Visible = True
                .firesmoke.Visible = False
                .range_not_needed = True
            End With
            If Not combat_2.Visible Then
                With combat_2
                    .Text = "Air to Air Fire Sub Phase for " + gameturn
                    .ShowDialog()
                End With
            End If
        End If


    End Sub


    Public Sub ground_to_air()
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        Dim x As Integer = 0, y As Integer = 0
        For Each ac As cunit In p1_air
            If ac.airborne Then ac.tacticalpts = 2 : x = x + 1
        Next
        For Each ac As cunit In p2_air
            If ac.airborne Then ac.tacticalpts = 2 : y = y + 1
        Next
        If x > 0 Or y > 0 Then
            populate_lists(combat_2.firers, ph_units, "Ground to Air", "")
            populate_lists(combat_2.targets, enemy_air, "Air Defence Targets", "")
            With combat_2
                .Tag = "Ground to Air"
                .enable_controls(True, combat_2.directfirepanel)
                .enable_controls(False, combat_2.targetpanel)
                .observation(False)
                .firer = New cunit
                .target = New cunit
                .fire.Visible = True
                .firesmoke.Visible = False
                .range_not_needed = False
            End With
            If Not combat_2.Visible Then
                With combat_2
                    .Text = "Ground to Air Fire Sub Phase for " + gameturn
                    .ShowDialog()
                End With
            End If
        End If

    End Sub


    'Public Sub conduct_sead()
    '    airground.Tag = "SEAD"
    '    For i As Integer = 1 To 2
    '        populate_lists(airground.units, ph_units, "SEAD", "")
    '        If airground.units.Items.Count > 0 Then
    '            populate_lists(combat_2.targets, enemy, "SEAD Targets", "")
    '            populate_lists(groundair.units, enemy, "Air Defence", "")
    '            With airground
    '                .Tag = "SEAD"
    '                .ShowDialog()
    '            End With
    '        End If

    '        'populate_lists(unit_selection.units, ph_units, "SEAD", "")
    '        'If unit_selection.units.Items.Count > 0 Then
    '        '    populate_lists(combat_2.targets, enemy, "SEAD Targets", "")
    '        '    If combat_2.targets.Items.Count > 0 Then unit_selection.ShowDialog()
    '        'End If
    '        swap_phasing_player(True)
    '    Next
    'End Sub

    'Public Sub conduct_air_to_ground()
    '    For i As Integer = 1 To 2
    '        populate_lists(airground.units, ph_units, "Air Ground", "")
    '        If airground.units.Items.Count > 0 Then
    '            populate_lists(combat_2.targets, enemy, "Ground Targets", "")
    '            populate_lists(groundair.units, enemy, "Air Defence", "")
    '            With airground
    '                .Tag = "Air Ground"
    '                .ShowDialog()
    '            End With
    '        End If
    '        swap_phasing_player(True)
    '    Next
    'End Sub

    Public Sub artillery_area_fire()
        For Each u As cunit In orbat
            If u.comd = 0 Then
                If u.indirect Then u.tacticalpts = 4
            End If
        Next
        'area fire phase
        For i As Integer = 1 To 2
            If arty_fire_mission("AF", ph_units) Then
                populate_lists(combat_2.targets, enemy, "Ground Targets", "")
                With movement
                    .Text = "Area Fire Artillery Phase for " + ph + " - Game Turn " + Str(gt)
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
                With resultform_2
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
                    populate_lists(combat_2.targets, enemy, "CB Targets", "")
                    With movement
                        .Text = "Counter Battery Artillery Phase for " + ph + " - Game Turn " + Str(gt)
                        .Tag = "CB Fire"
                        .options_for("CB Fire")
                        .ShowDialog()
                    End With
                End If
            End If
            swap_phasing_player(True)
        Next
    End Sub

    Public Sub movement_phase()
        'For Each u As cunit In orbat
        '    If u.comd = 0 Then u.reset_fire_phase(ph)
        'Next
        populate_lists(combat_2.targets, enemy, "Ground Targets", "")
        For Each u As cunit In ph_units
            If Not u.has_moved Then u.moving = False
        Next
        For Each ac As cunit In friend_air
            If ac.helarm And ac.has_fired Then ac.fired = 0
        Next
        For Each u As cunit In ph_hqs
            u.comdpts = 1
        Next
        With movement
            .Text = "Movement Phase " + gameturn
            .Tag = "Movement"
            .options_for("Movement")
            .ShowDialog()
        End With

    End Sub

    Public Sub end_sorties()
        Dim endsortie As Boolean = False
        unit_selection.units.Items.Clear()
        For j As Integer = 1 To 2
            For Each ac As cunit In friend_air
                If ac.sorties > 1 Then
                    ac.sorties = ac.sorties - 1
                ElseIf ac.sorties = 1 And ac.comd = 0 Then
                    ac.sorties = -1
                    friend_air(ac.airbase).strength = friend_air(ac.airbase).strength + ac.strength
                    ac.strength = 0
                ElseIf ac.airborne Then
                    ac.lands(False)
                    endsortie = True
                    Dim l As New ListViewItem
                    With l
                        .Text = ac.title
                        .SubItems.Add(ac.task)
                        .SubItems.Add(ac.equipment)
                    End With
                    unit_selection.units.Items.Add(l)
                Else
                End If
            Next
            For i As Integer = friend_air.Count To 1 Step -1
                If friend_air(i).sorties = -1 Then
                    orbat.Remove(friend_air(i).title)
                    If p1 = friend_air(i).nation Then p1_air.Remove(friend_air(i).title) Else p2_air.Remove(friend_air(i).title)
                    'friend_air.Remove(i)
                    If i > friend_air.Count Then i = friend_air.Count
                End If
            Next
            swap_phasing_player(True)
        Next
        If endsortie Then
            unit_selection.Tag = "Recover Aircraft"
            unit_selection.ShowDialog()
        End If
    End Sub

    Public Sub morale_recovery()
        For i As Integer = 1 To 2
            'Moralerecovery()
            'Phase 1 - spend command points to rally BGs from demoralised and units from rout or repulsed
            'unit_selection.Tag = "Demoralisation Recovery"
            'populate_lists(unit_selection.units, ph_hqs, "Demoralisation", "")
            'If unit_selection.units.Items.Count > 0 Then unit_selection.ShowDialog()
            'For Each u As cunit In ph_units
            '    If u.comd = 0 Then u.effective = False
            'Next
            With movement
                .Text = "Morale Recovery Phase for " + ph + " - Game Turn " + Str(gt)
                .options_for("Morale Recovery")
                .Tag = "Morale Recovery"
                .ShowDialog()
            End With
            swap_phasing_player(True)
        Next
    End Sub

End Module
