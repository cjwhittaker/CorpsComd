Module Utilities
    Function d6()
        d6 = Int(6 * Rnd + 1)
    End Function
    Function daverage()
        Dim Dice As Integer = Int(6 * Rnd() + 1)
        If Dice = 1 Then Dice = 3
        If Dice = 6 Then Dice = 4
        daverage = Dice
    End Function
    Function d4()
        d4 = Int(4 * Rnd + 1)
    End Function
    Function d10()
        d10 = Int(10 * Rnd + 1)
    End Function
    Function d100()
        d100 = Int(100 * Rnd + 1)
    End Function
    Function d20()
        d20 = Int(20 * Rnd + 1)
    End Function

    Public Sub populate_lists(ByVal l As ListView, ByVal c As Collection, ByVal purpose As String, ByVal hq As String)
        Dim listitem As ListViewItem, j As Integer = 0, loaded As String = "*", info As String = ""
        'For Each i As ListViewItem In l.Items
        '    i.Remove()
        'Next
        l.Items.Clear()
        l.BackColor = nostatus
        If purpose = "Opportunity Fire" Then
            listitem = New ListViewItem
            listitem.Text = "Minefield"
            l.Items.Add(listitem)
        End If
        If c Is Nothing Then Exit Sub
        For Each u As cunit In c
            u.arty_spt = 0
            If u.validunit(purpose, hq) Then
                listitem = New ListViewItem
                listitem.Text = u.title
                If hq = "commanders" And InStr("ObserveeCommandMorale RecoveryMovementAir TaskingArty TaskingArea FireCB Fire", purpose) > 0 Then
                    'listitem.SubItems.Add(u.comdpts)
                ElseIf l.Name = "undercommand" Then
                    If u.loaded <> "" Then loaded = "*" Else loaded = ""
                    If InStr("Arty Tasking", purpose) > 0 Then
                        info = u.task
                    ElseIf purpose = "Movement" Then
                        info = UCase(Strings.Left(u.mode, 1))
                    Else
                    End If
                    listitem.SubItems.Add(u.strength)
                    listitem.SubItems.Add(info)
                    listitem.SubItems.Add(IIf(u.Cover > 0, "+" + Trim(Str(u.Cover)), ""))
                    listitem.SubItems.Add(u.equipment + loaded)
                    'l.BackColor = u.status
                ElseIf InStr("Artillery SupportSmoke BarrageCA DefendersGround TargetsCB TargetsAir DefenceCAP MissionsIndirect FireDirect FireMovementArea FireCB FireOpportunity FireRadar OnSEAD TargetsInterceptAir to AirCAP AD Targets", purpose) > 0 Then
                    listitem.SubItems.Add(IIf(u.aircraft, u.strength - u.aborts, u.strength))
                    listitem.SubItems.Add(u.equipment)
                ElseIf InStr("Deploy AircraftAbort AircraftAir Ground", purpose) > 0 Then
                    listitem.SubItems.Add(u.task)
                    listitem.SubItems.Add(u.equipment)
                ElseIf InStr("DemoralisationMorale Recovery", purpose) > 0 Then
                    listitem.SubItems.Add(u.comdpts)
                ElseIf InStr("TransportCAP TargetsAir TargetsSEAD TargetsSEAD Defence TargetsObserver", purpose) > 0 Then
                    listitem.SubItems.Add(u.equipment)
                Else
                End If
                l.Items.Add(listitem)
                j = j + 1
            End If
        Next
        For Each li As ListViewItem In l.Items
            If orbat.Contains(li.Text) Then
                If purpose = "Observer" Or purpose = "Artillery Support" Then
                    If orbat(li.Text).arty_spt = 0 Then
                        li.BackColor = in_ds
                    ElseIf orbat(li.Text).arty_spt = 1 Then
                        li.BackColor = can_observe
                    Else
                        li.BackColor = not_on_net
                    End If
                ElseIf InStr("DemoralisationMorale RecoveryMovementArty Tasking", purpose) > 0 Then
                    li.BackColor = orbat(li.Text).status("")
                Else
                End If
            End If
        Next
    End Sub

    Public Function divisional_comd(ByVal p As cunit)
        If p.comd >= 4 Then
            divisional_comd = p.title : Exit Function
        Else
            divisional_comd = divisional_comd(orbat(p.parent))
        End If
    End Function
    Public Function brigade_comd(ByVal p As cunit)
        If p.comd >= 2 Then
            brigade_comd = p.title : Exit Function
        Else
            brigade_comd = brigade_comd(orbat(p.parent))
        End If
    End Function
    Public Sub hq_functions(ByVal p As cunit, func As String)
        If p.parent <> "root" Then hq_functions(orbat(p.parent), func)
        If func = "Air units" And p.primary <> func Then p.primary = func
        If func = "Arty units" And p.loaded <> func Then p.loaded = func
    End Sub

    Public Sub ewsupport(ByVal candidates As Collection, ByVal phase As String)
        Dim ewac As Boolean = False
        For Each subject As cunit In candidates
            If phase = "CAP" And subject.task = "EW Support" And subject.airborne Then
                ewac = True : Exit For
            ElseIf phase = "Air-Ground Attack" And subject.task = "SEAD" And subject.airborne Then
                ewac = True : Exit For
            Else

            End If
        Next
        For Each subject As cunit In candidates
            If (subject.aircraft And Not subject.heli) And subject.airborne Then subject.ewsupported = ewac Else subject.ewsupported = ewac
        Next
    End Sub
    'Public Sub resolvefire(ByVal firers As Collection, ByVal firer As cunit, ByVal targets As Collection, ByVal target As cunit, ByVal firephase As String)
    '    Dim unobserved As Boolean = False
    '    Dim airtoair As Boolean = firer.airborne And target.airborne
    '    Dim directfire As Boolean = Not firer.indirect

    '    'Dim spotrange As Integer
    '    firer.set_fire_parameters()
    '    target.set_fire_parameters()

    '    Dim tgtrange As Integer = Val(combat.tgt_range.Text)
    '    If target.firers > 0 Then
    '        target.fires = True
    '    Else
    '        target.fires = False
    '        target.msg = "No return fire from the target"
    '    End If
    '    firer.set_fire_effect(target, tgtrange, 0)
    '    If target.fires Then target.set_fire_effect(firer, tgtrange, 0) Else target.effect = 0

    '    If firer.effect > 0 And Not target.spotted And (firer.indirect Or firer.Airground) Then
    '        firer.effective = True
    '        If firer.role = "|RL|" Then unobserved = False Else unobserved = True
    '    ElseIf firer.effect > 0 Then
    '        firer.effective = True
    '        If firer.task = "AF" Then unobserved = True Else unobserved = False
    '    Else
    '        firer.effective = False
    '        firer.msg = " spotted their target but no effect firing"
    '    End If

    '    If target.fires And target.effect = 0 And firer.spotted Then
    '        target.msg = "spotted the firer but no effect firing"
    '        target.effective = False
    '    ElseIf target.fires And target.effect > 0 Then
    '        target.effective = True
    '    Else
    '    End If

    '    If Not firer.effective And Not target.effective Then
    '        If firephase = "Air Defence" Or target.heli Then
    '            If firer.effect = -1 Then
    '                resultform_2.result.Text = "Air Defence unit cannot engage - Radar off"
    '            ElseIf firer.effect = -2 Then
    '                resultform_2.result.Text = "Air unit is too high to engage"
    '            Else
    '                resultform_2.result.Text = "Air Defence unit cannot engage - Radar off" + vbNewLine + "and air unit is too high to engage"
    '            End If
    '        ElseIf Not target.fires Then
    '            resultform_2.result.Text = "Firer has no effect"
    '        ElseIf target.fires Then
    '            resultform_2.result.Text = "Neither Firer or target has any effect on each other"
    '        Else
    '        End If
    '        resultform_2.ShowDialog()
    '        combat.Hide()
    '        Exit Sub
    '    End If

    '    Dim init_msg As String = ""
    '    firer.fired = gt
    '    If target.fires Then target.fired = gt

    '    If firephase = "CAP" Or firephase = "Intercept" Then
    '        init_msg = "Air-to-Air combat Result "
    '        For i As Integer = 1 To 3
    '            If firephase = "Intercept" And i = 1 And firer.tacticalpts >= 2 Then i = 2
    '            firer.set_fire_effect(target, tgtrange, i)
    '            If firer.effect > 0 Then firer.result = firecasualties(firer, target, tgtrange, False)
    '            If firer.result < 0 Then target.aborts = target.aborts + 1 : target.hits = target.hits + 1 : firer.result = 0
    '            If firer.result > 0 Then target.casualties = target.casualties + firer.result : target.hits = target.hits + firer.result : firer.result = 0
    '            If target.fires Then
    '                target.set_fire_effect(firer, tgtrange, i)
    '                If target.effect > 0 Then target.result = firecasualties(target, firer, tgtrange, False)
    '                If target.result < 0 Then firer.aborts = firer.aborts + 1 : firer.hits = firer.hits + 1 : target.result = 0
    '                If target.result > 0 Then firer.casualties = firer.casualties + target.result : firer.hits = firer.hits + target.result : target.result = 0
    '            End If
    '        Next
    '        firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, airtoair, False)
    '        If target.fires Then target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)

    '    ElseIf firephase = "Air Defence" Or target.heli Then
    '        init_msg = "Air Defence Result "
    '        firer.result = firecasualties(firer, target, tgtrange, True)
    '        If firer.result < 0 Then target.aborts = target.aborts + 1 : target.hits = target.hits + 1 : firer.result = 0
    '        If firer.result > 0 Then target.casualties = target.casualties + firer.result : target.hits = target.hits + firer.result : firer.result = 0
    '        firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, True, False)
    '        'SEAD attack returns fire
    '        If target.fires And phase = 10 Then
    '            target.result = firecasualties(target, firer, tgtrange, False)
    '            target.msg = target.title + "(" + target.equipment + ")" + " fired at " + firer.title + generateresult(firer, target.result, False, False, False)
    '        End If
    '    ElseIf firephase = "SEAD" Then
    '        init_msg = "SEAD Attack Result "
    '        firer.result = firecasualties(firer, target, tgtrange, True)
    '        firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, firer.indirect, False, False)
    '    ElseIf firer.indirect Or firer.Airground Then
    '        If firer.indirect And unobserved Then
    '            init_msg = "Unobserved Indirect Fire "
    '        ElseIf firer.indirect And Not unobserved Then
    '            init_msg = "Observed Indirect Fire"
    '        ElseIf firer.Airground Then
    '            init_msg = "Air-Ground Fire "
    '        End If
    '        firer.result = firecasualties(firer, target, tgtrange, unobserved)
    '        If firer.heavy_fire And firer.result <> 0 Then target.statusimpact = 1
    '        firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, True, False, False)
    '    ElseIf firephase = "Opportunity Fire" Then
    '        init_msg = "Opportunity Fire "
    '        If oppfire And firephase = "Opportunity Fire" Then init_msg = firer.title + " conducts opportunity fire against " + target.title
    '        firer.result = firecasualties(firer, target, tgtrange, unobserved)
    '        firer.msg = target.title + " " + generateresult(target, firer.result, firer.indirect, airtoair, False)
    '        target.msg = ""
    '    Else
    '        init_msg = "Simultaneous firefight "
    '        If firer.effective Then firer.result = firecasualties(firer, target, tgtrange, unobserved)
    '        If target.fires And target.effective Then target.result = firecasualties(target, firer, tgtrange, unobserved)
    '        firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, firer.indirect, airtoair, False)
    '        If target.fires And target.effective Then
    '            target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)
    '        End If
    '    End If
    '    With resultform_2
    '        .result.Text = "Results" + vbNewLine + init_msg + vbNewLine + firer.msg + vbNewLine + target.msg
    '        .Tag = "firing"
    '        .ok_button.Visible = True
    '        .yb.Visible = IIf(InStr(target.msg, "disperse") > 0, True, False)
    '        .yb.Text = "Disperse " + firer.title
    '        .nb.Visible = IIf(InStr(firer.msg, "disperse") > 0, True, False)
    '        .nb.Text = "Disperse " + target.title
    '        .ShowDialog()
    '        .yb.Text = "Yes"
    '        .nb.Text = "No"
    '        .yb.Visible = False
    '        .nb.Visible = False
    '    End With
    '    If firer.result < 0 Then firer.result = 1
    '    If target.result < 0 Then target.result = 1
    '    If InStr(firer.msg, "disperse") > 0 And InStr(result_option, "Disperse nph") > 0 Then
    '        target.casualties = target.casualties + firer.result - 1
    '        target.mode = disp
    '    End If
    '    If InStr(target.msg, "disperse") > 0 And InStr(result_option, "Disperse ph") > 0 Then
    '        firer.casualties = firer.casualties + target.result - 1
    '        firer.mode = disp
    '    End If
    '    If InStr(firer.msg, "disperse") > 0 And InStr(result_option, "Disperse nph") = 0 Then target.casualties = target.casualties + firer.result
    '    If InStr(target.msg, "disperse") > 0 And InStr(result_option, "Disperse ph") = 0 Then firer.casualties = firer.casualties + target.result

    '    If firephase = "Air Defence" Or firephase = "CAP" Or (firephase = "Fire and Movement" And target.heli) Then
    '        If target.hit And target.disrupted Then target.lands(False)
    '    ElseIf firephase = "Air Ground" Then
    '        If target.hit And target.disrupted Then check_demoralisation(targets, target.parent, target.quality)
    '    ElseIf firephase = "Opportunity Fire" Then
    '        If target.hit And (target.disrupted Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
    '    ElseIf firephase = "Fire and Movement" Then
    '        If target.hit And (target.disrupted Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
    '        If firer.hit And (firer.disrupted Or firer.strength <= 0) Then check_demoralisation(firers, firer.parent, firer.quality)
    '    Else
    '    End If

    'End Sub
    'Function spotting(range As Integer, spotter As cunit, target As cunit)
    '    spotting = False
    '    If phase = 16 And spotter.arty_int >= 1 And range > 10000 Then Exit Function
    '    If phase = 16 And spotter.arty_int >= 1 Then
    '        Dim i As Integer = 0
    '        If target.role = "|ARTY|" Then
    '            i = 0
    '        ElseIf target.role = "|MOR|" Then
    '            i = 1
    '        Else
    '            i = 2
    '        End If
    '        If d6() >= cb_table(i, spotter.arty_int - 1) Then spotting = True
    '        Exit Function
    '    End If
    '    If target Is Nothing Or target.title = "" Then Exit Function
    '    If Not spotter.indirect Then
    '        If spotter.Cover > 0 And target.Cover > 0 And range <= 300 Then
    '            spotting = True
    '        End If
    '    End If
    '    Dim obr As Integer, om As Integer
    '    Try
    '        obr = 100 * eq_list(target.equipment).bor
    '        If spotter.task = "AF" Or spotter.task = "IN" Then
    '            obr = 1200
    '        ElseIf target.mode = travel Then
    '            obr = 1000
    '        ElseIf target.debussed And target.loaded <> "" And target.Inf Then
    '            obr = eq_list(orbat(target.loaded).equipment).bor
    '            If target.mode = disp Then obr = 100
    '        ElseIf target.mode = disp Then
    '            obr = 600
    '        Else
    '        End If

    '    Catch ex As Exception
    '        obr = 800
    '    End Try
    '    Dim smoked As Boolean = IIf(combat.tinsmoke.BackColor = golden Or combat.finsmoke.BackColor = golden, True, False)
    '    If night Then
    '        om = 1
    '    ElseIf twilight Then
    '        om = 3
    '    Else
    '        om = 4
    '    End If
    '    Try
    '        If (night Or smoked) And InStr(LCase(eq_list(spotter.equipment).special), "t") > 0 Then om = om + 2
    '        If twilight And InStr(LCase(eq_list(spotter.equipment).special), "t") > 0 Then om = om + 1
    '        If smoked And InStr(LCase(eq_list(spotter.equipment).special), "t") = 0 Then om = om - 4
    '        If night And InStr(LCase(eq_list(spotter.equipment).special), "i") > 0 Then om = om + 1

    '    Catch ex As Exception

    '    End Try

    '    If gt - target.fired < 2 Then om = om + 2
    '    If gt - target.moved < 2 Then om = om + 1
    '    If target.roadmove And Not target.mode = disp Then om = om + 1
    '    If target.plains Then om = om + 1
    '    If spotter.elevated Then om = om + 1
    '    If target.mode = disp Then om = om - 1
    '    If gt - spotter.moved < 2 Or (spotter.airborne And Not spotter.heli) Then om = om - 1
    '    If Not target.airborne Then om = om - target.Cover
    '    If om < 0 Then om = 0
    '    If om > 9 Then om = 9
    '    If range <= obr * om Then
    '        spotting = True
    '    End If
    'End Function

    'Function firecasualties(ByVal firer As cunit, ByVal target As cunit, ByVal rng As Integer, ByVal unobserved As Boolean)
    '    firecasualties = 0
    '    Dim airtoair As Boolean = firer.airborne And target.airborne
    '    Dim airdefence As Boolean = firer.airdefence And target.airborne
    '    Dim directfire As Boolean = Not (firer.indirect Or firer.Airground)
    '    Dim modifiers As Integer = 0, col As Integer = 0, row As Integer = 0, dice As Integer = 0, fv As Integer = 0, fire_effect As Integer = 0, fire_strength As Integer = 0
    '    Dim airground As Boolean = firer.Airground
    '    Dim defence As Integer = 0

    '    If firer.effect = 0 Then firecasualties = 0 : Exit Function
    '    If firer.task = "SEAD" Then directfire = True
    '    Try
    '        If airtoair Then
    '            defence = eq_list(target.equipment).defence
    '        ElseIf airdefence Then
    '            If eq_list(firer.equipment).role = "|AAA|" Then defence = eq_list(target.equipment).gun_def Else defence = eq_list(target.equipment).miss_def
    '        Else
    '            defence = eq_list(target.equipment).defence
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    If airtoair Then
    '        If firer.task = "CAP" And target.task <> "CAP" Then modifiers = modifiers + 2
    '        If target.ewsupported Then modifiers = modifiers - 2
    '    ElseIf airdefence Then
    '        If target.ewsupported Then modifiers = modifiers - 2
    '        modifiers = modifiers + firer.modifier
    '    Else
    '        modifiers = modifiers - target.modifier
    '        If target.heli Then
    '            If target.mode = "Very Low" And Not firer.eligibleCB Then
    '                modifiers = modifiers - 1
    '            ElseIf target.mode = "Very Low" And firer.eligibleCB Then
    '                modifiers = modifiers - 6
    '            ElseIf target.mode = "Low" And firer.eligibleCB Then
    '                modifiers = modifiers - 4
    '            Else
    '            End If
    '        Else
    '            If target.mode = conc And (target.flanked Or target.rear) Then modifiers = modifiers + 2
    '            If target.mode = travel And Not target.recon Then modifiers = modifiers + 2
    '            If target.mode <> disp And target.plains Then modifiers = modifiers + 1
    '            If Not target.armour And target.mode = travel And (target.flanked Or target.rear) Then modifiers = modifiers + 1
    '            If Not target.armour And target.mode = disp And (target.flanked Or target.rear) Then modifiers = modifiers + 1
    '            If target.mode = disp Then modifiers = modifiers - target.Cover
    '        End If
    '        If oppfire And (movement.tactical = 0 Or movement.tactical = 2) And (target.smoke_discharger Or target.smoke_generator) Then modifiers = modifiers - 1
    '        If oppfire And movement.tactical >= 4 And target.smoke_discharger Then modifiers = modifiers - 1
    '        modifiers = modifiers + target.size
    '        If firer.disrupted_gt Then modifiers = modifiers - 2
    '        If firer.insmoke Then modifiers = modifiers - 2
    '        If target.insmoke Then modifiers = modifiers - 2
    '        If firer.mode = travel Then firer.firers_available = 1
    '        If firer.heat And target.composite Then modifiers = modifiers - 2
    '        If firer.heat And target.spaced Then modifiers = modifiers - 1
    '        If Not firer.indirect And firer.moving And Not firer.stabilised Then modifiers = modifiers - 4
    '        If Not firer.indirect And firer.moving And firer.stabilised Then modifiers = modifiers - 2
    '        If firer.indirect And firer.moving Then modifiers = modifiers - 1
    '        If firer.bomblets Then modifiers = modifiers + 2
    '        If target.soft_tpt Then modifiers = modifiers + 2
    '    End If
    '    If firer.quality >= 8 Then dice = dice + 1
    '    If firer.quality <= 3 Then dice = dice - 1
    '    If airdefence Or directfire Or airtoair Then
    '        Dim fs As Integer = firer.firers
    '        Do
    '            dice = d10() - 1
    '            For i As Integer = 0 To 11
    '                If direct_fire(defence, i) >= firer.effect Then
    '                    col = i
    '                    Exit For
    '                End If
    '                If i = 11 Then col = i
    '            Next
    '            col = col + modifiers
    '            col = IIf(col < 0, 0, col)
    '            dice = dice + IIf(col > 11, col - 11, 0)
    '            dice = IIf(dice < 0, 0, dice)
    '            dice = IIf(dice > 9, 9, dice)
    '            col = IIf(col > 11, 11, col)
    '            fire_strength = IIf(fs > 9, 9, fs)
    '            fv = direct_fire_strength(fire_strength, col) - 1
    '            If fv <= 0 Then firecasualties = 0 : Exit Function
    '            firecasualties = firecasualties + fire_loss_table(dice, IIf(fv > 19, 19, fv))
    '            fs = fs - 9
    '        Loop Until fs <= 0
    '    Else
    '        Do
    '            dice = d10() - 1
    '            fire_effect = IIf(firer.effect > 10, 10, firer.effect)
    '            For row = 0 To 4
    '                If row = 4 Or defence <= indirect_fire(row, 0) Then Exit For
    '            Next
    '            For col = 0 To 11
    '                If firer.effect <= indirect_fire(row, col) Then Exit For
    '            Next
    '            If unobserved Then modifiers = modifiers - 2
    '            If firer.indirect And firer.smoke = gt Then dice = dice - 1
    '            col = col + modifiers
    '            col = IIf(col < 0, 0, col)
    '            dice = dice + IIf(col > 11, col - 11, 0)
    '            dice = IIf(dice < 0, 0, dice)
    '            dice = IIf(dice > 9, 9, dice)
    '            col = (IIf(col > 11, 11, col))
    '            fv = indirect_fire_strength(firer.firers, col) - 1
    '            firecasualties = firecasualties + fire_loss_table(dice, IIf(fv > 19, 19, fv))
    '            firer.effect = firer.effect - 10
    '        Loop Until firer.effect <= 0
    '    End If
    'End Function

    'Function generateresult(ByVal target As cunit, ByVal c As Integer, ByVal indirect As Boolean, airtoair As Boolean, ByVal assault As Boolean)
    '    generateresult = ""
    '    If airtoair Then
    '        If target.hits >= target.strength Then
    '            If target.casualties >= target.strength Then target.casualties = target.strength : target.aborts = 0
    '            If target.casualties < target.strength And target.aborts > 0 And target.casualties + target.aborts > target.strength Then target.aborts = target.strength - target.casualties
    '        End If
    '        generateresult = " with " + Str(target.casualties) + " aircraft shot down, with " + Str(target.aborts) + " aircraft aborted"
    '    ElseIf assault Then
    '        If Not (target.assault Or target.support) And target.strength > 0 Then
    '            generateresult = " disrupted, and suffered  " + Str(target.casualties) + " casualties, and must retreat 600m"
    '        ElseIf Not (target.assault Or target.support) And target.strength = 0 Then
    '            generateresult = " eliminated  "
    '        Else
    '            generateresult = " disrupted, and suffered  " + Str(target.casualties) + " casualties, and holds its current position"
    '        End If
    '    ElseIf target.mode = travel And Not target.recon And Not target.airborne Then
    '        If c = 0 Then
    '            c = -1
    '        ElseIf c = -1 Then
    '            c = 1
    '        Else
    '            c = c + 1
    '        End If
    '    ElseIf c = 0 Then
    '        generateresult = " with no effect"
    '        'ElseIf target.airborne And c < 0 Then
    '        '    generateresult = " with an aircraft aborted"
    '        '    target.aborts = target.aborts + c
    '        'ElseIf target.airborne Then
    '        '    generateresult = " with " + Str(c) + " aircraft shot down"
    '        '    target.casualties = target.casualties + c
    '    ElseIf (target.mode = disp And c < 0) Then
    '        generateresult = " with no effect"
    '        target.hits = target.hits + 1
    '    ElseIf target.mode = disp Then
    '        generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties")
    '        If c >= 2 Then target.disrupted_gt = True
    '        target.casualties = target.casualties + c
    '        target.hits = target.hits + c
    '    ElseIf target.mode <> disp And c < 0 Then
    '        generateresult = " with no casualties but it must disperse or accept 1 casualty"
    '        target.hits = target.hits + 1
    '    Else
    '        generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties") + " it may now disperse"
    '        target.hits = target.hits + c
    '    End If
    'End Function

    'Public Sub applyresult(ByVal subject As cunit)
    '    Dim msg As String = ""
    '    If (subject.strength - subject.casualties <= 0) Then
    '        msg = subject.title + " has been destroyed"
    '        With subject
    '            .strength = 0
    '            .casualties = 0
    '            .hits = 0
    '        End With
    '    Else
    '        msg = ""
    '        If subject.casualties > 2 Or subject.hits >= 4 Or subject.statusimpact = 1 Then

    '            With morale_test
    '                .Tag = "Immediate"
    '                .tester = subject
    '                .ShowDialog()
    '                .Tag = ""
    '            End With
    '        End If
    '        With subject
    '            .strength = subject.strength - subject.casualties
    '            .casualties = 0
    '            .statusimpact = 0
    '        End With
    '    End If
    '    If msg <> "" Then
    '        With resultform_2
    '            .result.Text = msg
    '            .ShowDialog()
    '        End With
    '    End If
    'End Sub

    Public Sub check_demoralisation(ByVal candidates As Collection, ByVal x As String, ByVal y As String)
        Randomize()
        Dim disrupted As Integer = 0, destroyed As Integer = 0, totalunits As Integer = 0
        For Each temp As cunit In candidates
            If temp.parent = x And temp.comd = 0 Then
                totalunits = totalunits + temp.initial
                destroyed = destroyed + (temp.initial - temp.strength)
                If temp.disrupted Then
                    disrupted = disrupted + temp.strength
                End If
            End If
        Next
        Dim percentdisrupted As Single = (disrupted + destroyed) / totalunits
        Dim d As Integer = d10()
        If d > y And percentdisrupted >= 0.333 Then
            With resultform_2
                .result.Text = parent(candidates, x)
                .ShowDialog()
            End With
        End If
    End Sub
    Public Function parent(ByVal candidates As Collection, ByVal x As String)
        parent = ""
        Dim fail_text As String = ""
        With orbat(x)
            .demoralised = True
            .moved = gt
        End With
        For Each temp As cunit In candidates
            If temp.parent = x Then
                temp.demoralised = True
                temp.moved = gt
                parent = parent + temp.title + ", "
            End If
        Next
        fail_text = " are now demoralised and on table units must move a minimum of half a tactical"
        fail_text = fail_text + vbNewLine + "move per turn toward their own sides baseline. The units of this BG"
        fail_text = fail_text + vbNewLine + "may not initiate fire"
        parent = parent + vbNewLine + fail_text
    End Function
    Public Sub log_entry(ByVal result As String)
        'logtime = to_hr(x)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Strings.Left(scenario, (Len(scenario) - 4)) + ".his", True)
        file.WriteLine(result)
        file.Close()
    End Sub

    Public Function coc(ByVal title As String, ByVal hq As cunit, ByVal comd As Integer)
        If title = hq.title And comd = 0 Then
            coc = True
            Exit Function
        End If
        If hq.parent = "root" Then
            coc = False
            Exit Function
        End If


        coc = coc(title, orbat(hq.parent), comd)
    End Function


    Public Sub swap_phasing_player(exec As Boolean)
        Dim tmp As String
        If exec Then
            tmp = ph
            ph = nph
            nph = tmp
        End If
        If ph = scenariodefaults.player1.Text Then
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
    End Sub

    Public Sub check_observer(firer As cunit)
        populate_lists(unit_selection.units, ph_units, "Observer", IIf(firer.primary <> "", firer.primary, firer.parent))
        With unit_selection
            .Tag = "Observer"
            .ShowDialog()
        End With
    End Sub

    Public Sub populate_command_structure(tree As TreeView, ByVal side As String, purpose As String)
        Dim TopNode As TreeNode, u As New cunit, x As Integer = 0
        For Each u In orbat
            If u.root And u.nation = side Then Exit For
        Next
        tree.Nodes.Clear()
        TopNode = tree.Nodes.Add(u.title, u.title)
        CreateNodes(side, TopNode, u.title, purpose)
        tree.ExpandAll()
        tree.SelectedNode = TopNode

        'selectunit(orbat(tree.SelectedNode.Text))
    End Sub
    Public Sub CreateNodes(ByRef side As String, ByRef ParentNode As TreeNode, ByRef currentcomd As String, ByRef purpose As String)
        Dim subNode As New TreeNode
        For x As Integer = 1 To orbat.Count
            If orbat(x).nation = side Then

                If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                    If (orbat(x).comd = 0 And purpose = "Orbat") Or orbat(x).comd > 0 Then
                        subNode = ParentNode.Nodes.Add(orbat(x).Title, orbat(x).Title)
                        subNode.BackColor = orbat(x).status(purpose)
                        If orbat(x).comd = 0 Then
                            If purpose = "Orbat" And orbat(x).inf Then
                                If orbat(x).debussed And orbat(x).loaded = "" Then
                                    subNode.ToolTipText = "Dismounted"
                                ElseIf orbat(x).debussed And orbat(x).loaded <> "" Then
                                    subNode.ToolTipText = "Debussed"
                                ElseIf Not orbat(x).debussed Then
                                    subNode.ToolTipText = "Embused"
                                Else
                                End If
                            End If
                        End If
                    End If
                    If (purpose = "Orbat") Or (purpose = "Command" And orbat(x).comd > 1) Then CreateNodes(side, subNode, orbat(x).title, purpose)
                End If
            End If
        Next
    End Sub

    Public Sub test_for_events(ByVal s As String, ByVal t As Date)
        For Each e As cevents In event_list
            If Not e.tested Then
                If Format(t, "HH:mm") >= e.time And s = e.side Then
                    If e.die = "None" Then
                        e.tested = True
                    Else
                        Dim dice6 As Integer = d6(), dice10 As Integer = d10()
                        If (e.die = "D6" And dice6 >= e.score) Or (e.die = "D10" And dice10 >= e.score) Then
                            e.tested = True
                        Else
                            If e.dec Then e.score = e.score - 1
                        End If
                    End If
                    If e.tested Then
                        With resultform_2
                            .Text = "Game Events - GT" + Trim(Str(gt)) + " at " + Format(t, "HH:mm") + "hrs"
                            .result.Text = e.unit + " " + e.text
                            .yb.Visible = False
                            .nb.Visible = False
                            .ok_button.Visible = True
                            .ShowDialog()
                            .nb.Visible = False
                        End With
                        For Each u As cunit In orbat
                            If u.nation = e.side And (u.title = e.unit Or u.parent = e.unit) Then
                                u.arrives = ""
                                If u.comd = 0 Then
                                    If Not u.conc Then u.mode = travel
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        Next
    End Sub

End Module
