Module utilities_firing
    Public Sub resolvefire(ByVal firer As cunit, ByVal target As cunit, stage As Integer)
        Dim unobserved As Boolean = Not target.spotted, abort_firer As Boolean = False, abort_target As Boolean = False
        Dim airtoair As Boolean = IIf(combat_2.Tag = "Air to Air", True, False)
        firer.set_fire_parameters()
        target.set_fire_parameters()

        Dim tgtrange As Integer = Val(combat_2.tgt_range.Text)
        If target.firers = 0 Then
            target.fires = False
            target.msg = IIf(combat_2.directfirepanel.Visible, target.title + " does not return fire", "")
        ElseIf stage = 1 And target.airborne And firer.airborne And target.tacticalpts = 2 And firer.tacticalpts = 3 Then
            target.fires = False
            target.msg = target.title + " does not return fire"
        Else
            target.fires = True
        End If
        firer.set_fire_effect(target, tgtrange, stage)
        If target.fires Then
            target.set_fire_effect(firer, tgtrange, stage)
        Else
            target.effect = 0
            If airtoair And target.Airground Then
                target.disrupted_gt = True
            End If
        End If

        If firer.effect > 0 And (firer.indirect Or firer.Airground) Then
            If Not target.spotted And Not firer.depth_fire Then unobserved = True Else unobserved = False
            firer.effective = True
        ElseIf stage = 1 And target.airborne And firer.airborne And target.tacticalpts = 3 And firer.tacticalpts = 2 Then
            firer.effective = False
            firer.msg = IIf(firer.aircraft, firer.title + " has no effect", " spotted their target but no effect firing")
        ElseIf firer.effect > 0 Then
            firer.effective = True
        Else
            firer.effective = False
            firer.msg = IIf(firer.aircraft, firer.title + " has no effect", " spotted their target but no effect firing")
        End If

        If target.fires And target.effect = 0 And firer.spotted Then
            target.msg = IIf(target.aircraft, target.title + " has no effect", " spotted the firer but no effect firing")
            target.effective = False
        ElseIf target.fires And target.effect > 0 Then
            target.effective = True
        Else
        End If

        Dim init_msg As String = ""
        'firer.fired = gt
        'If target.fires Then target.fired = gt
        'If Not firer.effective And Not target.effective Then

        'Else
        If airtoair Then
            init_msg = "Air-to-Air" + IIf(stage = 1, " LRAAM ", IIf(stage = 2, " SRAAM  ", " Gun ")) + "combat Result "
            If firer.effective Then
                firer.result = firecasualties(firer, target, tgtrange, False)
                apply_result(target, firer.result) : firer.result = 0
                firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, airtoair, False)
            End If
            If target.fires Then
                If target.effective Then
                    target.result = firecasualties(target, firer, tgtrange, False)
                    apply_result(firer, target.result)
                    target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)
                End If
            End If
            abort_firer = abort_option(firer, target, stage)
            abort_target = abort_option(target, firer, stage)
        ElseIf combat_2.Tag = "Ground to Air" Or target.heli Then
            init_msg = "Air Defence Result "
            firer.result = firecasualties(firer, target, tgtrange, True)
            apply_result(target, firer.result)
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, True, False)
            'SEAD attack returns fire
            If target.fires And phase = 10 Then
                target.result = firecasualties(target, firer, tgtrange, False)
                target.msg = target.title + "(" + target.title + ")" + " fired at " + firer.title + generateresult(firer, target.result, False, False, False)
            End If
        ElseIf combat_2.Tag = "SEAD" Then
            init_msg = "SEAD Attack Result "
            firer.result = firecasualties(firer, target, tgtrange, True)
            apply_result(target, firer.result) : firer.result = 0
            'If firer.result > 0 Then target.ordnance = True
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, firer.indirect, False, False)
        ElseIf firer.indirect Or firer.Airground Then
            If firer.indirect And unobserved Then
                init_msg = "Unobserved Indirect Fire "
            ElseIf firer.indirect And Not unobserved Then
                init_msg = "Observed Indirect Fire "
            ElseIf firer.Airground Then
                init_msg = "Air-Ground Fire "
            End If
            firer.result = firecasualties(firer, target, tgtrange, unobserved)
            apply_result(target, firer.result)
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, True, False, False)
        ElseIf combat_2.Tag = "Opportunity Fire" Then
            init_msg = "Opportunity Fire "
            If oppfire Then init_msg = firer.title + " conducts opportunity fire against " + target.title
            firer.result = firecasualties(firer, target, tgtrange, unobserved)
            apply_result(target, firer.result)
            firer.msg = target.title + " " + generateresult(target, firer.result, firer.indirect, airtoair, False)
            target.msg = ""
        Else
            init_msg = "Direct Fire "
            If firer.effective Then firer.result = firecasualties(firer, target, tgtrange, unobserved)
            If target.fires And target.effective Then target.result = firecasualties(target, firer, tgtrange, unobserved)
            apply_result(target, firer.result)
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, firer.indirect, airtoair, False)
            If target.fires And target.effective Then
                apply_result(target, firer.result)
                target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)
            End If
        End If
        result_option = ""
        Dim f As Boolean = firer.hvy_loss(True) And Not firer.destroyed And init_msg = "Direct Fire ", t As Boolean = Not airtoair And ((target.hvy_loss(True) And Not target.destroyed) Or (Not target.destroyed And firer.heavy_fire))
        With resultform_2
            .result.Text = "Results" + vbNewLine + init_msg + vbNewLine + firer.msg + vbNewLine + target.msg
            .Tag = "firing"
            .ok_button.Visible = True
            .yb.Text = IIf(abort_firer, "Abort Firer", "Disperse Firer")
            .yb.Visible = IIf((InStr(target.msg, "disperse") > 0 Or abort_firer) And Not firer.destroyed, True, False)
            .hvy1.Text = "Hvy Loss Firer"
            .hvy1.Visible = IIf(f, True, False)
            .hvy1.BackColor = IIf(f, golden, defa)
            .hvy1.Enabled = IIf(f, False, True)
            .nb.Text = IIf(abort_target, "Abort Target", "Disperse Target")
            .nb.Visible = IIf((InStr(firer.msg, "disperse") > 0 Or abort_target) And Not target.destroyed, True, False)
            .hvy2.Text = "Hvy Loss Target"
            .hvy2.Visible = IIf(t, True, False)
            .hvy2.BackColor = IIf(t, golden, defa)
            .hvy2.Enabled = IIf(t, False, True)
            .ShowDialog()
            .yb.Text = "Yes"
            .nb.Text = "No"
            .yb.Visible = False
            .nb.Visible = False
        End With
        If InStr(result_option, "Abort Firer") > 0 Then firer.lands(True)
        If InStr(result_option, "Abort Target") > 0 Then target.lands(True)
        If airtoair Then Exit Sub
        If InStr(result_option, "Disperse Firer") > 0 Then
            With firer
                .casualties = firer.casualties - 1
                .hits = firer.hits - 1
                .mode = disp
            End With
        End If
        If InStr(result_option, "Disperse Target") > 0 Then
            With target
                .casualties = target.casualties - 1
                .hits = target.hits - 1
                .mode = disp
            End With
        End If
        f = firer.hvy_loss(False) And Not firer.destroyed
        t = (target.hvy_loss(False) And Not target.destroyed) Or (Not target.destroyed And firer.heavy_fire)

        If f Then
            With morale_test
                .tester = firer
                .immediate = True
                .rallying = False
                .ShowDialog()
            End With
        End If
        If t Then
            With morale_test
                .tester = target
                .immediate = True
                .rallying = False
                .ShowDialog()
            End With
        End If

    End Sub
    Function spotting(range As Integer, spotter As cunit, target As cunit)
        spotting = False
        If target Is Nothing Or target.equipment = "" Then Exit Function
        If spotter Is Nothing Or spotter.title = "" Then Exit Function
        If spotter.indirect Then
            If spotter.Cover > 0 And target.Cover > 0 And range <= 300 Then
                spotting = True
                Exit Function
            End If
        End If
        Dim obr As Integer, om As Integer
        obr = 100 * eq_list(target.equipment).bor
        If spotter.task = "FFE" Then
            obr = 1200
        ElseIf target.pre_mode = travel Then
            obr = 1000
        ElseIf target.Inf And target.dismounted Then
            If target.pre_mode = disp Then
                obr = 100
            ElseIf target.pre_mode = conc Then
                obr = 200
            Else
            End If
        ElseIf target.pre_mode = disp And obr = 800 Then
            obr = 600
        Else
        End If

        Dim smoked As Boolean = IIf(target.insmoke Or spotter.insmoke, True, False)
        If night Then
            om = 1
        ElseIf twilight Then
            om = 3
        Else
            om = 4
        End If
        If InStr(LCase(eq_list(spotter.equipment).special), "t") > 0 Then
            If night Or smoked Or twilight Then om = 3
        ElseIf InStr(LCase(eq_list(spotter.equipment).special), "i") > 0 Then
            If night Then om = 2
        Else
        End If
        If smoked And InStr(LCase(eq_list(spotter.equipment).special), "t") = 0 Then om = om - 4
        If spotter.elevated And (Not spotter.airborne Or spotter.heli) Then om = om + 1
        If spotter.has_moved Or (spotter.airborne And Not spotter.heli) Then om = om - 1
        If spotter.pre_mode = travel Then om = om - 1
        If spotter.task <> "FFE" Then
            If gt - target.fired <= 1 Then om = om + 2
            If target.has_moved Then om = om + 1
            If target.roadmove And Not target.pre_mode = disp Then om = om + 1
            If target.plains Then om = om + 1
        End If
        'If target.mode = disp Then om = om - 1
        om = om - target.Cover
        If om <= 0 And night Then
            om = 0
        ElseIf om <= 0 Then
            om = 1
        ElseIf om > 9 Then
            om = 9
        Else
        End If
        If range <= obr * om Then spotting = True
    End Function

    Function firecasualties(ByVal firer As cunit, ByVal target As cunit, ByVal rng As Integer, ByVal unobserved As Boolean)
        firecasualties = 0
        Dim airtoair As Boolean = firer.airborne And target.airborne
        Dim airdefence As Boolean = firer.airdefence And target.airborne
        Dim directfire As Boolean = IIf(combat_2.Tag = "Direct Fire" Or combat_2.Tag = "Half Fire" Or (combat_2.Tag = "Opportunity Fire" And Not airdefence), True, False)
        Dim indirectfire As Boolean = IIf(combat_2.Tag = "Indirect Fire", True, False)

        Dim modifiers As Integer = 0, col As Integer = 0, row As Integer = 0, dice As Integer = 0, fv As Integer = 0, fire_effect As Integer = 0, fire_strength As Integer = 0
        Dim airground As Boolean = firer.Airground
        Dim defence As Integer = 0

        If firer.effect = 0 Then firecasualties = 0 : Exit Function
        If airdefence Then
            If firer.role = "|AAA|" Then defence = eq_list(target.equipment).gun_def Else defence = eq_list(target.equipment).miss_def
        Else
            defence = eq_list(target.equipment).defence
        End If
        If combat_2.Tag = "SEAD" Then
            directfire = True
            modifiers = modifiers - target.modifier
        End If
        If airtoair Then
            'Bounce attack
            If firer.fires And Not target.fires Then modifiers = modifiers + 2
        End If
        If airtoair Or airdefence Then
            If combat_2.ta_ecm_ds.BackColor = golden Then modifiers = modifiers + IIf(firer.missile_armed, eq_list(combat_2.ta_ecm_ds.Text).ecm_miss, eq_list(combat_2.ta_ecm_ds.Text).ecm_gun)
            If combat_2.ta_ecm_gs.BackColor = golden Then modifiers = modifiers + Int(IIf(firer.missile_armed, eq_list(combat_2.ta_ecm_gs.Text).ecm_miss, eq_list(combat_2.ta_ecm_gs.Text).ecm_gun) / 2)
        End If
        If airdefence Then
            'If combat_2.ta_ecm_ds.BackColor = golden Then modifiers = modifiers + IIf(firer.missile_armed, eq_list(combat_2.ta_ecm_ds.Text).ecm_miss, eq_list(combat_2.ta_ecm_ds.Text).ecm_gun)
            'If combat_2.ta_ecm_gs.BackColor = golden Then modifiers = modifiers + Int(IIf(firer.missile_armed, eq_list(combat_2.ta_ecm_gs.Text).ecm_miss, eq_list(combat_2.ta_ecm_gs.Text).ecm_gun) / 2)
            'modifiers = modifiers + firer.modifier
            If firer.eligibleCB Then modifiers = modifiers + 1
        End If
        If target.heli Then
            If target.mode = "Very Low" And Not firer.eligibleCB Then
                modifiers = modifiers - 1
            ElseIf target.mode = "Very Low" And firer.eligibleCB Then
                modifiers = modifiers - 6
            ElseIf target.mode = "Low" And firer.eligibleCB Then
                modifiers = modifiers - 4
            Else
            End If
        End If
        If directfire Then
            If target.armour And (target.mode = conc Or target.mode = travel) And (target.flanked Or target.rear) Then modifiers = modifiers + 2
            If target.armour And target.mode = disp And (target.flanked Or target.rear) Then modifiers = modifiers + 1
            If (combat_2.Tag = "Opportunity Fire") Then
                If target.smoke_discharger Or target.smoke_generator Then
                    modifiers = modifiers - 1
                ElseIf target.smoke_discharger Then
                    modifiers = modifiers - 1
                Else
                End If
            End If
            modifiers = modifiers + target.size
            If firer.heat And target.composite Then modifiers = modifiers - 2
            If firer.heat And target.spaced Then modifiers = modifiers - 1
            If firer.pre_mode = travel Then firer.firers = 1
            'If firer.mode = disp And firer.conc Then modifiers = modifiers - 2
            If combat_2.Tag = "Half Fire" Then
                If firer.heli Then
                ElseIf firer.stabilised Then
                    modifiers = modifiers - 1
                Else
                    modifiers = modifiers - 2
                End If
            End If
            If target.mode <> disp And target.plains Then modifiers = modifiers + 2
        End If
        If indirectfire Then
            If firer.scoot Then modifiers = modifiers - 1
            If unobserved Then modifiers = modifiers - 2
            If target.mode <> disp And target.plains Then modifiers = modifiers + 1
        End If
        If indirectfire Or airground Then
            If firer.bomblets Then modifiers = modifiers + 2
        End If
        If indirectfire Or directfire Then
            If target.mode = travel And Not target.recon Then modifiers = modifiers + 2
            If target.soft_tpt Then modifiers = modifiers + 2
            If target.mode = disp Then modifiers = modifiers - target.Cover
            If target.mode = disp And target.Cover = 0 Then modifiers = modifiers - 1
            If firer.insmoke Then modifiers = modifiers - 2
            If target.insmoke Then modifiers = modifiers - 2
            If firer.conc And firer.pre_mode = disp Then modifiers = modifiers - 2
        End If
        Dim fs As Integer = firer.firers, r As Integer = 0
        firing_result = ""
        If airdefence Or directfire Or airtoair Then
            dice = d10() - 1
            For i As Integer = 0 To 11
                If direct_fire(defence, i) >= firer.effect Then
                    col = i
                    Exit For
                End If
                If i = 11 Then col = i
            Next
            col = col + modifiers - 1
            col = IIf(col < 0, 0, col)
            If firer.quality >= 8 Then dice = dice + 1
            If firer.quality <= 3 Then dice = dice - 1
            dice = dice + IIf(col > 11, col - 11, 0) + firer.fatigue
            dice = IIf(dice < 0, 0, dice)
            dice = IIf(dice > 9, 9, dice)
            col = IIf(col > 11, 11, col)
            Do
                fire_strength = IIf(fs > 9, 9, fs)
                fv = direct_fire_strength(fire_strength - 1, col)
                If fv <= 0 Then firecasualties = 0
                If fv > 0 Then r = fire_loss_table(dice, IIf(fv > 19, 19, fv))
                firing_result = firing_result + "((" + Str(fire_strength) + "," + Str(firer.effect) + "," + Str(defence) + ")=" + Str(fv) + "," + Str(dice) + ")=" + Str(r) + vbNewLine
                If firecasualties < 0 And r > 0 Then
                    firecasualties = r
                ElseIf r < 0 And firecasualties = 0 Then
                    firecasualties = r
                ElseIf r > 0 And firecasualties >= 0 Then
                    firecasualties = firecasualties + r
                Else
                End If
                fs = fs - 9
            Loop Until fs <= 0
        ElseIf indirectfire Or airground Then
            dice = d10() - 1
            Do
                fire_effect = IIf(firer.effect > 10, 10, firer.effect)
                For row = 0 To 4
                    If row = 4 Or defence <= indirect_fire(row, 0) Then Exit For
                Next
                For col = 1 To 11
                    If fire_effect <= indirect_fire(row, col) Then Exit For
                Next
                col = col + modifiers - 1
                col = IIf(col < 0, 0, col)
                dice = dice + IIf(col > 11, col - 11, 0) + firer.fatigue
                If firer.quality >= 8 Then dice = dice + 1
                If firer.quality <= 3 Then dice = dice - 1
                dice = IIf(dice < 0, 0, dice)
                dice = IIf(dice > 9, 9, dice)
                col = (IIf(col > 11, 11, col))
                fv = indirect_fire_strength(firer.firers, col)
                If fv <= 0 Then firecasualties = 0
                If fv > 0 Then r = fire_loss_table(dice, IIf(fv > 19, 19, fv))
                firing_result = firing_result + "((" + Str(firer.firers) + "," + Str(firer.effect) + "," + Str(defence) + ")=" + Str(fv) + "," + Str(dice) + ")=" + Str(r) + vbNewLine
                firecasualties = firecasualties + fire_loss_table(dice, IIf(fv > 19, 19, fv))
                firer.effect = firer.effect - 10
            Loop Until firer.effect <= 0
        Else
        End If
    End Function

    Function generateresult(ByVal target As cunit, ByVal c As Integer, ByVal indirect As Boolean, airtoair As Boolean, ByVal assault As Boolean)
        generateresult = ""
        If Not assault And Not target.hit Then target.hit = True
        If Not assault And Not airtoair And target.mode = travel And Not target.recon Then
            If c = -1 Then
                c = 1
            ElseIf c > 0 Then
                c = c + 1
            Else
            End If
        End If
        If airtoair Then
            If target.casualties >= target.strength Then target.casualties = target.strength
            'If target.casualties < target.strength And target.aborts > 0 And target.casualties + target.aborts > target.strength Then target.aborts = target.strength - target.casualties
            If target.hits = 0 Then
                generateresult = " with no Effect"
            ElseIf target.casualties > 0 Then
                generateresult = " with" + Str(target.casualties) + " aircraft shot down"
            ElseIf target.hits > 0 And target.casualties = 0 Then
                generateresult = " with" + Str(target.hits) + " aircraft aborted"
            Else
            End If
        ElseIf assault Then
            If Not (target.assault Or target.support) And target.strength > 0 Then
                generateresult = " disrupted, and suffered  " + Str(target.casualties) + " casualties, and must retreat 600m"
            ElseIf target.strength = 0 Then
                generateresult = " destroyed  "
            Else
                generateresult = " disrupted, and suffered  " + Str(target.casualties) + " casualties, and holds its current position"
            End If
        ElseIf c = 0 Then
            generateresult = " with no effect"
        ElseIf target.strength - c <= 0 Then
            generateresult = " which has been destroyed"
        ElseIf target.mode = disp And c < 0 Then
            generateresult = " with no effect"
            target.hits = 0
        ElseIf target.mode = disp Then
            generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties")
            'target.casualties = target.casualties + c
            'target.hits = target.hits + c
        ElseIf target.mode <> disp Then
            If c < 0 Then
                c = 0
                generateresult = " with no casualties but which may disperse or accept 1 casualty"
            Else
                generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties") + " which may now disperse or accept an additional casualty"
            End If
            target.casualties = target.casualties + 1
            target.hits = target.hits + 1
        Else
        End If
        generateresult = generateresult + vbNewLine + firing_result
    End Function

    Public Sub apply_result(victim As cunit, result As Integer)
        If result < 0 Then
            If victim.airborne Then
                victim.aborts = victim.aborts + 1
                victim.hits = victim.hits + 1
            Else
                victim.hits = victim.hits + 1
            End If
        ElseIf result > 0 Then
            victim.casualties = victim.casualties + result
            victim.hits = victim.hits + result
        Else
        End If

    End Sub
End Module
