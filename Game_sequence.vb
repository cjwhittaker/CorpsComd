Module Game_sequence
    Public Sub initialise_turn()
        Randomize(3600 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        gameturn = " for Game Turn" + Str(gt) + " at " + Format(gamedate, "HHmm") + "hrs " + Format(gamedate, "dd MMM yyyy")
        If gt = 1 And phase = 0 Then
            initialise_collections()
            scenariodefaults.enable_data_entry(False)
            For Each u As cunit In orbat
                If u.comd = 0 Then
                    'If Not u.conc Then u.mode = disp Else u.mode = conc
                    u.fired = -1
                    u.moved = -1
                    If u.indirect Then u.smoke = -4
                    If u.mode = disp And (u.airdefence Or u.indirect) Then u.emplaced = True
                End If
            Next
            savedata(scenario)
        End If
        If phase <> 0 Then
            If (ph <> initiative And phase <= 13 And phase >= 20) Or (phase = 15 And first_player <> ph) Or (phase = 17 And first_player <> nph) Then swap_phasing_player(True)
        End If
        oppfire = False
        If phase <= 1 Then
            For Each u As cunit In orbat
                If u.comd = 0 Then u.reset_unit()
            Next
        End If
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
        For Each u As cunit In ph_units
            u.emplace()
        Next
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
            .indirectfirepanel.Visible = False
            .directfirepanel.Visible = True
            .directfirepanel.Enabled = True
            .targetpanel.Enabled = True
            .Tag = "Direct Fire"
            .enable_controls(True, combat_2.directfirepanel)
            .enable_controls(True, combat_2.targetpanel)
            .observation(False)
            .firer = New cunit
            .target = New cunit
            .firesmoke.Visible = False
            .fire.Visible = True
            .range_not_needed = False
            .swap.Visible = True
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
        populate_lists(combat_2.targets, enemy, "Off Table Targets", second)
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
            .range_not_needed = False
            .swap.Visible = True
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
        combat_2.artillery.Items.Clear()
        populate_lists(combat_2.artillery, ph_units, "Smoke Barrage", first)
        With combat_2
            .directfirepanel.Visible = False
            .indirectfirepanel.Visible = True
            .targetpanel.Visible = True
            .targetpanel.Enabled = False
            .Tag = "Smoke Barrage"
            .enable_controls(False, combat_2.indirectfirepanel)
            .enable_controls(True, combat_2.targetpanel)
            .observers.Enabled = False
            .observation(False)
            .firer = New cunit
            .target = New cunit
            .firesmoke.Visible = True
            .range_not_needed = True
            .reset_strength(combat_2.a1, .a2, .a3)
            .firer_strength(.a1, .a2, .a3, 0, False)
            .swap.Visible = True
        End With
        If Not combat_2.Visible Then
            With combat_2
                .Text = "Smoke Barrage Sub Phase" + gameturn
                .ShowDialog()
                .observers.Enabled = True
                .indirectfirepanel.Visible = False
            End With
        End If
    End Sub


    Public Sub deploy_air_missions()
        Dim r As String = ""
        unit_selection.Tag = "Deploy Aircraft"
        populate_lists(unit_selection.units, orbat, "Deploy Aircraft", "")
        For Each l As ListViewItem In unit_selection.units.Items
            r = r + l.Text + ", "
        Next
        If unit_selection.units.Items.Count > 0 Then
            unit_selection.ShowDialog()
            log_entry("Game Turn" + Str(gt) + " " + scenariodefaults.Current_time.Text + " Air Missions deployed " + r)

        End If
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
                .indirectfirepanel.Visible = False
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
                .swap.Visible = True
            End With
            If Not combat_2.Visible Then
                With combat_2
                    .Text = "Air to Air Fire Sub Phase for " + gameturn
                    .ShowDialog()
                End With
            End If
        End If


    End Sub


    Public Sub ground_to_air(ad As Collection, ac As Collection)
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        populate_lists(combat_2.firers, ad, "Ground to Air", "")
        populate_lists(combat_2.targets, ac, "Air Defence Targets", "")
        With combat_2
            .Tag = "Ground to Air"
            .indirectfirepanel.Visible = False
            .directfirepanel.Visible = True
            .directfirepanel.Enabled = True
            .targetpanel.Enabled = True
            .enable_controls(True, combat_2.directfirepanel)
            .enable_controls(False, combat_2.targetpanel)
            .observation(False)
            .abort_firer.Visible = False
            .abort_target.Visible = True
            .firer = New cunit
            .target = New cunit
            .fire.Visible = True
            .firesmoke.Visible = False
            .range_not_needed = False
            .swap.Visible = True
        End With
        If Not combat_2.Visible Then
            With combat_2
                .Text = "Ground to Air Fire Sub Phase for " + gameturn
                .ShowDialog()
            End With
        End If
    End Sub
    Public Sub air_to_ground()
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        populate_lists(combat_2.firers, friend_air, "Air to Ground", "")
        populate_lists(combat_2.targets, enemy, "Ground Targets", "")
        With combat_2
            .indirectfirepanel.Visible = False
            .directfirepanel.Visible = True
            .directfirepanel.Enabled = True
            .targetpanel.Enabled = True
            .Tag = "Air to Ground"
            .Text = "Air to Ground Fire Sub Phase for " + gameturn
            .enable_controls(False, .directfirepanel)
            .enable_controls(True, .targetpanel)
            .abort_firer.Visible = True
            .abort_target.Visible = False
            .fire.Visible = True
            .firesmoke.Visible = False
            .range_not_needed = False
            .swap.Visible = True
        End With
        If Not combat_2.Visible Then
            With combat_2
                .Text = "Air to Ground Fire Sub Phase for " + gameturn
                .ShowDialog()
            End With
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

    Public Sub movement_phase()
        'For Each u As cunit In orbat
        '    If u.comd = 0 Then u.reset_fire_phase(ph)
        'Next
        populate_lists(combat_2.targets, enemy, "Ground Targets", "")
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
                    If ac.strength > 0 Then
                        endsortie = True
                        Dim l As New ListViewItem
                        With l
                            .Text = ac.title
                            .SubItems.Add(ac.task)
                            .SubItems.Add(ac.equipment)
                        End With
                        unit_selection.units.Items.Add(l)
                    Else
                        orbat.Remove(ac.title)
                        If UCase(p1) = UCase(ac.nation) Then p1_air.Remove(ac.title) Else p2_air.Remove(ac.title)
                    End If
                Else
                End If
            Next
            For i As Integer = friend_air.Count To 1 Step -1
                If friend_air(i).sorties = -1 Then
                    orbat.Remove(friend_air(i).title)
                    If UCase(p1) = UCase(friend_air(i).nation) Then p1_air.Remove(friend_air(i).title) Else p2_air.Remove(friend_air(i).title)
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
            For Each u As cunit In ph_units
                u.morale_checks()
            Next

            With movement
                .Text = "Morale Recovery Phase for " + ph + " - Game Turn " + Str(gt)
                .opp_fire.Text = ""
                .opp_fire.Visible = True
                .options_for("Morale Recovery")
                .Tag = "Morale Recovery"
                .ShowDialog()
                .opp_fire.Text = .opp_fire.Tag
                .opp_fire.Visible = False
            End With
            swap_phasing_player(True)
        Next
    End Sub

End Module
