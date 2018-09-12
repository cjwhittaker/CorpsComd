Module utilities_firing
    Public Sub resolvefire(ByVal firer As cunit, ByVal target As cunit)
        Dim unobserved As Boolean = False
        Dim airtoair As Boolean = False
        If combat_2.Tag = "Air-to-Air" Then airtoair = True
        'Dim spotrange As Integer
        firer.set_fire_parameters()
        target.set_fire_parameters()

        Dim tgtrange As Integer = Val(combat_2.tgt_range.Text)
        If target.firers > 0 Then
            target.fires = True
        Else
            target.fires = False
            target.msg = IIf(combat_2.directfire.Visible, "No return fire from the target", "")
        End If
        firer.set_fire_effect(target, tgtrange, 0)
        If target.fires Then target.set_fire_effect(firer, tgtrange, 0) Else target.effect = 0

        If firer.effect > 0 And Not target.spotted And (firer.indirect Or firer.Airground) Then
            firer.effective = True
            If firer.role = "|RL|" Then unobserved = False Else unobserved = True
        ElseIf firer.effect > 0 Then
            firer.effective = True
            If firer.task = "AF" Then unobserved = True Else unobserved = False
        Else
            firer.effective = False
            firer.msg = " spotted their target but no effect firing"
        End If

        If target.fires And target.effect = 0 And firer.spotted Then
            target.msg = "spotted the firer but no effect firing"
            target.effective = False
        ElseIf target.fires And target.effect > 0 Then
            target.effective = True
        Else
        End If

        If Not firer.effective And Not target.effective Then
            If combat_2.Tag = "Air Defence" Or target.heli Then
                If firer.effect = -1 Then
                    resultform_2.result.Text = "Air Defence unit cannot engage - Radar off"
                ElseIf firer.effect = -2 Then
                    resultform_2.result.Text = "Air unit is too high to engage"
                Else
                    resultform_2.result.Text = "Air Defence unit cannot engage - Radar off" + vbNewLine + "and air unit is too high to engage"
                End If
            ElseIf Not target.fires Then
                resultform_2.result.Text = "Firer has no effect"
            ElseIf target.fires Then
                resultform_2.result.Text = "Neither Firer or target has any effect on each other"
            Else
            End If
            resultform_2.ShowDialog()
            combat_2.Hide()
            Exit Sub
        End If

        Dim init_msg As String = ""
        'firer.fired = gt
        'If target.fires Then target.fired = gt

        If combat_2.Tag = "CAP" Or combat_2.Tag = "Intercept" Then
            init_msg = "Air-to-Air combat Result "
            For i As Integer = 1 To 3
                If combat_2.Tag = "Intercept" And i = 1 Then i = 2
                firer.set_fire_effect(target, tgtrange, i)
                If firer.effect > 0 Then firer.result = firecasualties(firer, target, tgtrange, False)
                If firer.result < 0 Then target.aborts = target.aborts + 1 : target.hits = target.hits + 1 : firer.result = 0
                If firer.result > 0 Then target.casualties = target.casualties + firer.result : target.hits = target.hits + firer.result : firer.result = 0
                If target.fires Then
                    target.set_fire_effect(firer, tgtrange, i)
                    If target.effect > 0 Then target.result = firecasualties(target, firer, tgtrange, False)
                    If target.result < 0 Then firer.aborts = firer.aborts + 1 : firer.hits = firer.hits + 1 : target.result = 0
                    If target.result > 0 Then firer.casualties = firer.casualties + target.result : firer.hits = firer.hits + target.result : target.result = 0
                End If
            Next
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, airtoair, False)
            If target.fires Then target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)

        ElseIf combat_2.tag = "Air Defence" Or target.heli Then
            init_msg = "Air Defence Result "
            firer.result = firecasualties(firer, target, tgtrange, True)
            If firer.result < 0 Then target.aborts = target.aborts + 1 : target.hits = target.hits + 1 : firer.result = 0
            If firer.result > 0 Then target.casualties = target.casualties + firer.result : target.hits = target.hits + firer.result : firer.result = 0
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, True, False)
            'SEAD attack returns fire
            If target.fires And phase = 10 Then
                target.result = firecasualties(target, firer, tgtrange, False)
                target.msg = target.title + "(" + target.title + ")" + " fired at " + firer.title + generateresult(firer, target.result, False, False, False)
            End If
        ElseIf combat_2.tag = "SEAD" Then
            init_msg = "SEAD Attack Result "
            firer.result = firecasualties(firer, target, tgtrange, True)
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, firer.indirect, False, False)
        ElseIf firer.indirect Or firer.Airground Then
            If firer.indirect And unobserved Then
                init_msg = "Unobserved Indirect Fire "
            ElseIf firer.indirect And Not unobserved Then
                init_msg = "Observed Indirect Fire"
            ElseIf firer.Airground Then
                init_msg = "Air-Ground Fire "
            End If
            firer.result = firecasualties(firer, target, tgtrange, unobserved)
            If firer.heavy_fire And firer.result <> 0 Then target.statusimpact = 1
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, True, False, False)
        ElseIf oppfire Then
            init_msg = "Opportunity Fire "
            If oppfire Then init_msg = firer.title + " conducts opportunity fire against " + target.title
            firer.result = firecasualties(firer, target, tgtrange, unobserved)
            firer.msg = target.title + " " + generateresult(target, firer.result, firer.indirect, airtoair, False)
            target.msg = ""
        Else
            init_msg = "Direct Fire "
            If firer.effective Then firer.result = firecasualties(firer, target, tgtrange, unobserved)
            If target.fires And target.effective Then target.result = firecasualties(target, firer, tgtrange, unobserved)
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, firer.indirect, airtoair, False)
            If target.fires And target.effective Then
                target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)
            End If
        End If
        result_option = ""
        Dim f As Boolean = firer.hvy_loss(True) And Not firer.destroyed, t As Boolean = (target.hvy_loss(True) And Not target.destroyed) Or (Not target.destroyed And firer.heavy_fire)
        With resultform_2
            .result.Text = "Results" + vbNewLine + init_msg + vbNewLine + firer.msg + vbNewLine + target.msg
            .Tag = "firing"
            .ok_button.Visible = True
            .yb.Text = "Disperse Firer"
            .yb.Visible = IIf(InStr(target.msg, "disperse") > 0 And Not firer.destroyed, True, False)
            .hvy1.Text = "Hvy Loss Firer"
            .hvy1.Visible = IIf(f, True, False)
            .hvy1.BackColor = IIf(f, golden, defa)
            .hvy1.Enabled = IIf(f, False, True)
            .nb.Text = "Disperse Target"
            .nb.Visible = IIf(InStr(firer.msg, "disperse") > 0 And Not target.destroyed, True, False)
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

        'If firer.result < 0 Then firer.result = 1
        'If target.result < 0 Then target.result = 1
        'If InStr(firer.msg, "disperse") > 0 And InStr(result_option, "Disperse nph") > 0 Then
        '    target.casualties = target.casualties + firer.result - 1
        '    target.mode = disp
        'End If
        'If InStr(target.msg, "disperse") > 0 And InStr(result_option, "Disperse ph") > 0 Then
        '    firer.casualties = firer.casualties + target.result - 1
        '    firer.mode = disp
        'End If
        'If InStr(firer.msg, "disperse") > 0 And InStr(result_option, "Disperse nph") = 0 Then target.casualties = target.casualties + firer.result
        'If InStr(target.msg, "disperse") > 0 And InStr(result_option, "Disperse ph") = 0 Then firer.casualties = firer.casualties + target.result

        'If firephase = "Air Defence" Or firephase = "CAP" Or (firephase = "Fire and Movement" And target.heli) Then
        '    If target.hit And target.disrupted Then target.lands(False)
        'ElseIf firephase = "Air Ground" Then
        '    If target.hit And target.disrupted Then check_demoralisation(targets, target.parent, target.quality)
        'ElseIf firephase = "Opportunity Fire" Then
        '    If target.hit And (target.disrupted Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
        'ElseIf firephase = "Fire and Movement" Then
        '    If target.hit And (target.disrupted Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
        '    If firer.hit And (firer.disrupted Or firer.strength <= 0) Then check_demoralisation(firers, firer.parent, firer.quality)
        'Else
        'End If

    End Sub
    Function spotting(range As Integer, spotter As cunit, target As cunit)
        spotting = False
        If target Is Nothing Or target.equipment = "" Then Exit Function
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
        ElseIf target.mode = travel Then
            obr = 1000
        ElseIf target.Inf And target.dismounted Then
            If target.mode = disp Then
                obr = 100
            ElseIf target.mode = conc Then
                obr = 200
            Else
            End If
        ElseIf target.mode = disp And obr = 800 Then
            obr = 600
        Else
        End If

        Dim smoked As Boolean = IIf(combat_2.tinsmoke.BackColor = golden Or combat_2.finsmoke.BackColor = golden, True, False)
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
        If spotter.elevated Then om = om + 1
        If spotter.has_moved Then om = om - 1
        If spotter.mode = travel Then om = om - 1
        If spotter.task <> "FFE" Then
            If target.fired Then om = om + 2
            If target.has_moved Then om = om + 1
            If target.roadmove And Not target.mode = disp Then om = om + 1
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
        Dim directfire As Boolean = IIf(combat_2.Tag = "Direct Fire" Or combat_2.Tag = "Opportunity Fire", True, False)
        Dim indirectfire As Boolean = IIf(combat_2.Tag = "Indirect Fire", True, False)

        Dim modifiers As Integer = 0, col As Integer = 0, row As Integer = 0, dice As Integer = 0, fv As Integer = 0, fire_effect As Integer = 0, fire_strength As Integer = 0
        Dim airground As Boolean = firer.Airground
        Dim defence As Integer = 0

        If firer.effect = 0 Then firecasualties = 0 : Exit Function
        If airtoair Then
            defence = eq_list(target.equipment).defence
        ElseIf airdefence Then
            If eq_list(firer.equipment).role = "|AAA|" Then defence = eq_list(target.equipment).gun_def Else defence = eq_list(target.equipment).miss_def
        Else
            defence = eq_list(target.equipment).defence
        End If
        If combat_2.Tag = "SEAD" Then
            directfire = True
            modifiers = modifiers - target.modifier
        End If
        If airtoair Then
            If firer.task = "CAP" And target.task <> "CAP" Then modifiers = modifiers + 2
            If target.ewsupported Then modifiers = modifiers - 2
        End If
        If airdefence Then
            If target.ewsupported Then modifiers = modifiers - 2
            modifiers = modifiers + firer.modifier
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
            If oppfire And (target.smoke_discharger Or target.smoke_generator) Then modifiers = modifiers - 1
            If oppfire And target.smoke_discharger Then modifiers = modifiers - 1
            modifiers = modifiers + target.size
            If firer.heat And target.composite Then modifiers = modifiers - 2
            If firer.heat And target.spaced Then modifiers = modifiers - 1
            If firer.mode = travel Then firer.firers = 1
            'If firer.mode = disp And firer.conc Then modifiers = modifiers - 2
            If combat_2.Tag = "Half Fire" And firer.stabilised Then modifiers = modifiers - 1
            If combat_2.Tag = "Half Fire" And Not firer.stabilised Then modifiers = modifiers - 2
            If target.mode <> disp And target.plains Then modifiers = modifiers + 2
        End If
        If indirectfire Then
            If firer.has_moved Then modifiers = modifiers - 1
            If firer.bomblets Then modifiers = modifiers + 2
            If unobserved Then modifiers = modifiers - 2
            If target.mode <> disp And target.plains Then modifiers = modifiers + 1
        End If
        If indirectfire Or directfire Then
            If target.mode = travel And Not target.recon Then modifiers = modifiers + 2
            If target.soft_tpt Then modifiers = modifiers + 2
            If target.mode = disp Then modifiers = modifiers - target.Cover
            If firer.insmoke Then modifiers = modifiers - 2
            If target.insmoke Then modifiers = modifiers - 2
            If firer.conc And firer.mode = disp Then modifiers = modifiers - 2
        End If
        If airdefence Or directfire Or airtoair Then
            Dim fs As Integer = firer.firers
            Do
                dice = d10() - 1
                For i As Integer = 0 To 11
                    If direct_fire(defence, i) >= firer.effect Then
                        col = i
                        Exit For
                    End If
                    If i = 11 Then col = i
                Next
                col = col + modifiers
                col = IIf(col < 0, 0, col)
                If firer.quality >= 8 Then dice = dice + 1
                If firer.quality <= 3 Then dice = dice - 1
                dice = dice + IIf(col > 11, col - 11, 0) + firer.fatigue
                dice = IIf(dice < 0, 0, dice)
                dice = IIf(dice > 9, 9, dice)
                col = IIf(col > 11, 11, col)
                fire_strength = IIf(fs > 9, 9, fs)
                fv = direct_fire_strength(fire_strength, col) - 1
                If fv <= 0 Then firecasualties = 0 : Exit Function
                firecasualties = firecasualties + fire_loss_table(dice, IIf(fv > 19, 19, fv))
                fs = fs - 9
            Loop Until fs <= 0
        ElseIf indirectfire Then
            Do
                dice = d10() - 1
                fire_effect = IIf(firer.effect > 10, 10, firer.effect)
                For row = 0 To 4
                    If row = 4 Or defence <= indirect_fire(row, 0) Then Exit For
                Next
                For col = 0 To 11
                    If firer.effect <= indirect_fire(row, col) Then Exit For
                Next
                col = col + modifiers
                col = IIf(col < 0, 0, col)
                dice = dice + IIf(col > 11, col - 11, 0) + firer.fatigue
                If firer.quality >= 8 Then dice = dice + 1
                If firer.quality <= 3 Then dice = dice - 1
                dice = IIf(dice < 0, 0, dice)
                dice = IIf(dice > 9, 9, dice)
                col = (IIf(col > 11, 11, col))
                fv = indirect_fire_strength(firer.firers, col) - 1
                firecasualties = firecasualties + fire_loss_table(dice, IIf(fv > 19, 19, fv))
                firer.effect = firer.effect - 10
            Loop Until firer.effect <= 0
        Else
        End If
    End Function

    Function generateresult(ByVal target As cunit, ByVal c As Integer, ByVal indirect As Boolean, airtoair As Boolean, ByVal assault As Boolean)
        target.hits = 0
        generateresult = ""
        If Not assault And Not airtoair And target.mode = travel And Not target.recon Then
            If c = -1 Then
                c = 1
            ElseIf c > 0 Then
                c = c + 1
            Else
            End If
        End If
        If airtoair Then
            If target.hits >= target.strength Then
                If target.casualties >= target.strength Then target.casualties = target.strength : target.aborts = 0
                If target.casualties < target.strength And target.aborts > 0 And target.casualties + target.aborts > target.strength Then target.aborts = target.strength - target.casualties
            End If
            generateresult = " with " + Str(target.casualties) + " aircraft shot down, with " + Str(target.aborts) + " aircraft aborted"
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
            'ElseIf target.airborne And c < 0 Then
            '    generateresult = " with an aircraft aborted"
            '    target.aborts = target.aborts + c
            'ElseIf target.airborne Then
            '    generateresult = " with " + Str(c) + " aircraft shot down"
            '    target.casualties = target.casualties + c
        ElseIf target.mode = disp And c < 0 Then
            generateresult = " with no effect"
            target.hits = 0
        ElseIf target.mode = disp Then
            If target.strength - c <= 0 Then
                generateresult = " which has been destroyed"
            Else
                generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties")
                'If c >= 2 Then target.disrupted_gt = True
                target.casualties = target.casualties + c
                target.hits = target.hits + c
            End If
        ElseIf target.mode <> disp And c < 0 Then
            generateresult = " with no casualties but which must disperse or accept 1 casualty"
            target.hits = 1
        Else
            If target.strength - c + 1 <= 0 Then
                generateresult = " which has been destroyed"
            Else
                generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties") + " which may now disperse"
            End If
            target.hits = target.hits + c
            target.casualties = target.casualties + c
        End If

    End Function

    Public Sub applyresult(ByVal subject As cunit)
        Dim msg As String = ""
        If (subject.strength - subject.casualties <= 0) Then
            msg = subject.equipment + " has been destroyed"
            With subject
                .strength = 0
                .casualties = 0
                .hits = 0
            End With
        Else
            msg = ""
            If subject.casualties > 2 Or subject.hits >= 4 Or subject.statusimpact = 1 Then

                With morale_test
                    .Tag = "Immediate"
                    .tester = subject
                    .ShowDialog()
                    .Tag = ""
                End With
            End If
            With subject
                .strength = subject.strength - subject.casualties
                .casualties = 0
                .statusimpact = 0
            End With
        End If
        If msg <> "" Then
            With resultform_2
                .result.Text = msg
                .ShowDialog()
            End With
        End If
    End Sub

End Module
