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
    Function generatecomdpts(ByVal quality As String, ByVal x As Integer)
        Dim i As Integer, k As Integer, j As Integer, l As Integer, low As Integer
        If quality = "A" Or quality = "B" Then
            generatecomdpts = d6() + d6()
        ElseIf quality = "C" Then
            i = d6()
            j = d6()
            k = d6()
            If i <= k And j <= k Then
                low = i + j
            ElseIf i <= j And k <= j Then
                low = i + k
            Else
                low = k + j
            End If
            generatecomdpts = low
        Else
            i = d6()
            j = d6()
            k = d6()
            l = d6()
            If i <= k And j <= k And i <= l And j <= l Then
                low = i + j
            ElseIf i <= j And k <= j And i <= l And k <= l Then
                low = i + k
            ElseIf i <= j And l <= j And i <= k And l <= k Then
                low = i + l
            ElseIf j <= i And k <= i And j <= l And k <= l Then
                low = j + k
            ElseIf j <= i And l <= i And j <= k And l <= k Then
                low = j + l
            Else
                low = k + l
            End If
            generatecomdpts = low
        End If
        generatecomdpts = Int((generatecomdpts * x / 12) + 0.5)
    End Function

    Public Sub Moralerecovery()
        Dim recoverfrompinned As String = "The following units are no longer pinned" + vbNewLine + vbNewLine
        Dim unitsrecoveredpinned As Boolean = False
        Dim recoverfromrepulsed As String = "The following units have recovered from being repulsed" + vbNewLine + vbNewLine
        Dim unitsrecoveredrepulsed As Boolean = False
        Dim remainrepulsed As String = "The following units remain repulsed" + Chr(13) + "and must retire a full move to cover or out of sight" + vbNewLine + vbNewLine
        Dim unitsremainrepulsed As Boolean = False
        For Each subject As cunit In ph_units
            If Not (subject.disrupted Or subject.demoralised) Then
                'Phase 1c - recover from pinned
                'Phase 1d - recover from repulsed
                'Phase1e - recover firers
                If subject.firers > 0 Then
                    Dim suppressed As Integer = subject.firers
                    For i As Integer = 1 To suppressed
                        If d6() >= 5 Then subject.firers = subject.firers - 1
                    Next
                End If
                If subject.hit Then subject.hit = False
            End If
        Next
        If unitsrecoveredpinned Then
            With resultform
                .result.Text = "Pinned Recovery" + vbNewLine + recoverfrompinned
                .ShowDialog()
            End With
        End If
        If unitsrecoveredrepulsed Then
            With resultform
                .result.Text = "Repulsed Recovery" + vbNewLine + recoverfromrepulsed
                .ShowDialog()
            End With
        End If
        If unitsremainrepulsed Then
            With resultform
                .result.Text = "Remain Repulsed" + vbNewLine + remainrepulsed
                .ShowDialog()
            End With
        End If
    End Sub
    Public Sub populate_lists(ByVal l As ListView, ByVal c As Collection, ByVal purpose As String, ByVal hq As String)
        Dim listitem As ListViewItem, j As Integer = 0, loaded As String = "*", info As String = ""
        'For Each i As ListViewItem In l.Items
        '    i.Remove()
        'Next
        l.Items.Clear()
        l.BackColor = nostatus
        For Each u As cunit In c
            u.statusimpact = 0
            If u.validunit(purpose, hq) Then
                listitem = New ListViewItem
                listitem.Text = u.title
                If hq = "commanders" And InStr("ObserveeCommandMorale RecoveryFire and MovementAir TaskingArty TaskingArea FireCB Fire", purpose) > 0 Then
                    'listitem.SubItems.Add(u.comdpts)
                ElseIf purpose = "Artillery Support" Then

                ElseIf l.Name = "undercommand" Then
                    If u.loaded <> "" Then loaded = "*" Else loaded = ""
                    If InStr("Arty Tasking", purpose) > 0 Then
                        info = u.task
                    ElseIf purpose = "Fire and Movement" Then
                        info = UCase(Strings.Left(u.mode, 1))
                    Else
                    End If
                    listitem.SubItems.Add(u.strength)
                    listitem.SubItems.Add(info)
                    listitem.SubItems.Add(u.equipment + loaded)
                    'l.BackColor = u.status
                ElseIf InStr("CA DefendersGround TargetsCB TargetsAir DefenceCAP MissionsFire and MovementArea FireCB FireOpportunity FireRadar OnSEAD Targets", purpose) > 0 Then
                    listitem.SubItems.Add(IIf(u.Aircraft, u.strength - u.aborts, u.strength))
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
            li.BackColor = orbat(li.Text).status
        Next
    End Sub
    Public Sub color_item(ByVal l As ListViewItem, ByVal u As cunit)
        l.BackColor = u.status
        If Not (l.BackColor = in_ds Or l.BackColor = nostatus Or l.BackColor = take_off) Then l.ForeColor = nostatus Else l.ForeColor = Color.Black
    End Sub
    Public Function divisional_comd(ByVal p As cunit)
        If p.comd >= 4 Then
            divisional_comd = p.title : Exit Function
        Else
            divisional_comd = divisional_comd(orbat(p.parent))
        End If
    End Function

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
            If subject.role = "AC" And subject.airborne Then subject.ewsupported = ewac Else subject.ewsupported = ewac
        Next
    End Sub
    Public Sub resolvefire(ByVal firers As Collection, ByVal firer As cunit, ByVal targets As Collection, ByVal target As cunit, ByVal firephase As String)
        Dim unobserved As Boolean = False
        Dim airtoair As Boolean = firer.airborne And target.airborne
        Dim directfire As Boolean = Not firer.indirect
        Dim soft As Boolean = IIf(equipment(target.equipment).defence > 0, False, True)

        'Dim spotrange As Integer
        firer.set_fire_parameters()
        target.set_fire_parameters()

        Dim tgtrange As Integer = Val(combat.tgt_range.Text)
        If target.firers > 0 Then
            target.fires = True
        Else
            target.fires = False
            target.msg = "No return fire from the target"
        End If
        firer.set_fire_effect(target, tgtrange, 0)
        If target.fires Then target.set_fire_effect(firer, tgtrange, 0) Else target.effect = 0

        If firer.effect > 0 And Not target.spotted And (firer.indirect Or firer.Airground) Then
            firer.effective = True
            If firer.role = "RL" Then unobserved = False Else unobserved = True
        ElseIf firer.effect > 0 Then
            firer.effective = True
            If firer.task = "AF" Then unobserved = True Else unobserved = False
        Else
            firer.effective = False
            firer.msg = " spotted their target but no effect firing"
        End If

        If oppfire Then firer.tacticalpts = firer.tacticalpts - 1

        If target.fires And target.effect = 0 And firer.spotted Then
            target.msg = "spotted the firer but no effect firing"
            target.effective = False
        ElseIf target.fires And target.effect > 0 Then
            target.effective = True
        Else
        End If

        If Not firer.effective And Not target.effective Then
            If firephase = "Air Defence" Or target.heli Then
                If firer.effect = -1 Then
                    resultform.result.Text = "Air Defence unit cannot engage - Radar off"
                ElseIf firer.effect = -2 Then
                    resultform.result.Text = "Air unit is too high to engage"
                Else
                    resultform.result.Text = "Air Defence unit cannot engage - Radar off" + vbNewLine + "and air unit is too high to engage"
                End If
            ElseIf Not target.fires Then
                resultform.result.Text = "Firer has no effect"
            ElseIf target.fires Then
                resultform.result.Text = "Neither Firer or target has any effect on each other"
            Else
            End If
            resultform.ShowDialog()
            combat.Hide()
            Exit Sub
        End If

        Dim init_msg As String = ""
        firer.fired = gt

        If target.fires Then
            'target.firers = target.strength
            target.fired = gt
            target.tacticalpts = target.tacticalpts - 1
        End If
        If firephase = "CAP" Then
            init_msg = "Air-to-Air combat Result "
            For i As Integer = 1 To 3
                firer.set_fire_effect(target, tgtrange, i)
                target.set_fire_effect(firer, tgtrange, i)
                If firer.effect > 0 Then firer.result = firecasualties(firer, target, tgtrange, False)
                If target.effect > 0 Then target.result = firecasualties(target, firer, tgtrange, False)
                If firer.result < 0 Then target.aborts = target.aborts + 1 : target.hits = target.hits + 1 : firer.result = 0
                If target.result < 0 Then firer.aborts = firer.aborts + 1 : firer.hits = firer.hits + 1 : target.result = 0
                If firer.result > 0 Then target.casualties = target.casualties + firer.result : target.hits = target.hits + firer.result : firer.result = 0
                If target.result > 0 Then firer.casualties = firer.casualties + target.result : firer.hits = firer.hits + target.result : target.result = 0
            Next
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, airtoair, False)
            target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)

        ElseIf firephase = "Air Defence" Or target.heli Then
            init_msg = "Air Defence Result "
            firer.result = firecasualties(firer, target, tgtrange, True)
            If firer.result < 0 Then target.aborts = target.aborts + 1 : target.hits = target.hits + 1 : firer.result = 0
            If firer.result > 0 Then target.casualties = target.casualties + firer.result : target.hits = target.hits + firer.result : firer.result = 0
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, False, True, False)
            'SEAD attack returns fire
            If target.fires And phase = 10 Then
                target.result = firecasualties(target, firer, tgtrange, False)
                target.msg = target.title + "(" + target.equipment + ")" + " fired at " + firer.title + generateresult(firer, target.result, False, False, False)
            End If
        ElseIf firephase = "SEAD" Then
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
        ElseIf firephase = "Opportunity Fire" Then
            init_msg = "Opportunity Fire "
            If oppfire And firephase = "Opportunity Fire" Then init_msg = firer.title + " conducts opportunity fire against " + target.title
            firer.result = firecasualties(firer, target, tgtrange, unobserved)
            firer.msg = target.title + " " + generateresult(target, firer.result, firer.indirect, airtoair, False)
            target.msg = ""
        Else
            init_msg = "Simultaneous firefight "
            If firer.effective Then firer.result = firecasualties(firer, target, tgtrange, unobserved)
            If target.fires And target.effective Then target.result = firecasualties(target, firer, tgtrange, unobserved)
            firer.msg = firer.title + " fired at " + target.title + generateresult(target, firer.result, firer.indirect, airtoair, False)
            If target.fires And target.effective Then
                target.msg = target.title + " fired at " + firer.title + generateresult(firer, target.result, False, airtoair, False)
            End If
        End If
        With resultform
            .result.Text = "Results" + vbNewLine + init_msg + vbNewLine + firer.msg + vbNewLine + target.msg
            .Tag = "firing"
            .ok_button.Visible = True
            .yb.Visible = IIf(InStr(target.msg, "disperse") > 0, True, False)
            .yb.Text = "Disperse " + firer.title
            .nb.Visible = IIf(InStr(firer.msg, "disperse") > 0, True, False)
            .nb.Text = "Disperse " + target.title
            .ShowDialog()
            .yb.Text = "Yes"
            .nb.Text = "No"
            .yb.Visible = False
            .nb.Visible = False
        End With
        If firer.result < 0 Then firer.result = 1
        If target.result < 0 Then target.result = 1
        If InStr(firer.msg, "disperse") > 0 And InStr(resultform.Tag, "Disperse nph") > 0 Then
            target.casualties = target.casualties + firer.result - 1
            target.mode = disp
        End If
        If InStr(target.msg, "disperse") > 0 And InStr(resultform.Tag, "Disperse ph") > 0 Then
            firer.casualties = firer.casualties + target.result - 1
            firer.mode = disp
        End If
        If InStr(firer.msg, "disperse") > 0 And InStr(resultform.Tag, "Disperse nph") = 0 Then target.casualties = target.casualties + firer.result
        If InStr(target.msg, "disperse") > 0 And InStr(resultform.Tag, "Disperse ph") = 0 Then firer.casualties = firer.casualties + target.result

        If firephase = "Air Defence" Or firephase = "CAP" Or (firephase = "Fire and Movement" And target.hels) Then
            If target.hit And target.disrupted Then
                target.airborne = False
                target.sorties = -equipment(target.equipment).sortie
            End If
        ElseIf firephase = "Air-Ground Attack" Then
            If target.hit And target.disrupted Then check_demoralisation(targets, target.parent, target.quality)
        ElseIf firephase = "Opportunity Fire" Then
            If target.hit And (target.disrupted Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
        ElseIf firephase = "Fire and Movement" Then
            If target.hit And (target.disrupted Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
            If firer.hit And (firer.disrupted Or firer.strength <= 0) Then check_demoralisation(firers, firer.parent, firer.quality)
        Else
        End If

    End Sub
    Function spotting(range As Integer, spotter As cunit, target As cunit)
        spotting = False
        If phase = 16 And spotter.arty_int >= 1 And range > 10000 Then Exit Function
        If phase = 16 And spotter.arty_int >= 1 Then
            Dim i As Integer = 0
            If target.role = "ARTY" Then
                i = 0
            ElseIf target.role = "MOR" Then
                i = 1
            Else
                i = 2
            End If
            If d6() >= cb_table(i, spotter.arty_int - 1) Then spotting = True
            Exit Function
        End If
        If target Is Nothing Or target.title = "" Then Exit Function
        If Not spotter.indirect Then
            If spotter.Cover = 1 And target.Cover = 1 Then
                If range <= 250 Then spotting = True
                Exit Function
            ElseIf spotter.Cover = 2 And target.Cover = 2 Then
                If range <= 125 Then spotting = True
                Exit Function
            ElseIf spotter.Cover = 3 And target.Cover = 3 Then
                If range = 0 Then spotting = True
                Exit Function
            Else
            End If
        End If
        Dim obr As Integer, obs As Integer() = {0, 1, 2, 3, 4, 6, 8, 10, 12, 14}, obn As Integer
        obr = equipment(target.equipment).bor
        If target.debussed And target.loaded <> "" And target.Inf Then obr = equipment(orbat(target.loaded).equipment).bor
        If spotter.task = "AF" Or spotter.task = "IN" Then obr = 12
        If target.mode = travel Then obr = 10
        For i As Integer = 0 To obs.Count
            If obs(i) = obr Then obn = i : Exit For
        Next
        If gt - target.fired < 2 Then obn = obn + 2
        If gt - target.moved < 2 Then obn = obn + 1
        If target.roadmove Then obn = obn + 1
        If target.plains Then obn = obn + 1
        If spotter.elevated Then obn = obn + 1
        If target.mode = disp Then obn = obn - 1
        If obn < 0 Then obn = 0
        If obn > 9 Then obn = 9
        'if dusk
        'if night
        If range <= obs(obn) * 100 * (4 - target.Cover) Then spotting = True
    End Function
    Function spotting_old(ByVal x As Integer, ByVal subject As cunit, ByVal airborne As Boolean)
        Dim r As Integer = 10000
        If subject.Inf Then
            If subject.Cover > 0 And Not subject.moved Then
                r = 125
            ElseIf subject.Cover > 0 And subject.moved Then
                r = 250
            ElseIf subject.Cover = 0 And subject.moved Then
                r = 750
            ElseIf subject.Cover = 0 And Not subject.moved Then
                r = 250
            Else
            End If
        Else
            If subject.Cover > 0 And subject.moved Then
                r = 500
            ElseIf subject.Cover = 0 And subject.moved Then
                r = 2500
            ElseIf subject.Cover > 0 And Not subject.moved Then
                r = 250
            ElseIf subject.Cover = 0 And Not subject.moved Then
                r = 1000
            Else

            End If
        End If

        Dim diceroll As Integer = d6(), firedetection As Integer = 0
        If subject.fired Or movement.tac_opt = 1 Then diceroll = diceroll + 1
        If night And Not (subject.fired Or movement.tac_opt = 1) Then diceroll = diceroll - 2
        If subject.fired And Not subject.Inf Then firedetection = 750
        If airborne Then diceroll = diceroll + 1
        If x <= r + firedetection And diceroll >= 2 Then
            spotting_old = True
        ElseIf x <= r * 2 + firedetection And diceroll >= 5 Then
            spotting_old = True
        Else
            spotting_old = False
        End If
    End Function
    Function scoreforeffect(ByVal shooter As cunit, ByVal victim As cunit, ByVal x As Integer)
        scoreforeffect = 0
        Dim myType As Type = GetType(cequipment)
        Dim e As New cequipment
        e = equipment("")
        Dim properties As System.Reflection.PropertyInfo() = myType.GetProperties()
        For Each p As System.Reflection.PropertyInfo In properties
            If p.Name <> "role" And LCase(Left(p.Name, 1)) = "r" Then
                If x <= Val(Mid(p.Name, 2)) Then
                    scoreforeffect = p.GetValue(e, Nothing)
                    Exit For
                End If
            End If
        Next

    End Function

    Function firecasualties(ByVal firer As cunit, ByVal target As cunit, ByVal rng As Integer, ByVal unobserved As Boolean)
        firecasualties = 0
        Dim airtoair As Boolean = firer.airborne And target.airborne
        Dim airdefence As Boolean = firer.airdefence And target.airborne
        Dim directfire As Boolean = Not (firer.indirect Or firer.Airground)
        Dim modifiers As Integer = 0, col As Integer = 0, row As Integer = 0, dice As Integer = 0, fv As Integer = 0, fire_effect As Integer = 0, fire_strength As Integer = 0
        Dim soft As Boolean = IIf(equipment(target.equipment).defence > 0, False, True)
        Dim airground As Boolean = firer.Airground
        Dim defence As Integer = 0

        If firer.effect = 0 Then firecasualties = 0 : Exit Function
        If firer.task = "SEAD" Then directfire = True

        If airtoair Then
            defence = equipment(target.equipment).defence
        ElseIf airdefence Then
            If equipment(firer.equipment).role = "AAA" Then defence = equipment(target.equipment).gun_def Else defence = equipment(target.equipment).miss_def
        Else
            defence = equipment(target.equipment).defence
        End If

        If airtoair Then
            If firer.task = "CAP" And target.task <> "CAP" Then modifiers = modifiers + 2
            If target.ewsupported Then modifiers = modifiers - 2
        ElseIf airdefence Then
            If target.ewsupported Then modifiers = modifiers - 2
            modifiers = modifiers + firer.modifier
        Else
            modifiers = modifiers - target.modifier
            If target.heli Then
                If target.mode = "Very Low" And Not firer.eligibleCB Then
                    modifiers = modifiers - 1
                ElseIf target.mode = "Very Low" And firer.eligibleCB Then
                    modifiers = modifiers - 6
                ElseIf target.mode = "Low" And firer.eligibleCB Then
                    modifiers = modifiers - 4
                Else
                End If
            Else
                If target.mode = conc And (target.flanked Or target.rear) Then modifiers = modifiers + 2
                If target.mode = travel And Not target.recon Then modifiers = modifiers + 2
                If target.mode <> disp And target.plains Then modifiers = modifiers + 1
                If Not soft And target.mode = travel And (target.flanked Or target.rear) Then modifiers = modifiers + 1
                If Not soft And target.mode = disp And (target.flanked Or target.rear) Then modifiers = modifiers + 1
                If target.mode = disp Then modifiers = modifiers - target.Cover
            End If
            If oppfire And (movement.tactical = 0 Or movement.tactical = 2) And (target.smoke_discharger Or target.smoke_generator) Then modifiers = modifiers - 1
            If oppfire And movement.tactical >= 4 And target.smoke_discharger Then modifiers = modifiers - 1
            modifiers = modifiers + target.size
            If firer.disordered Then modifiers = modifiers - 2
            If firer.insmoke Then modifiers = modifiers - 2
            If target.insmoke Then modifiers = modifiers - 2
            If firer.mode = travel Then firer.no_of_units = 1
            If firer.heat And target.composite Then modifiers = modifiers - 2
            If firer.heat And target.spaced Then modifiers = modifiers - 1
            If Not firer.indirect And firer.moving And Not firer.stabilised Then modifiers = modifiers - 4
            If Not firer.indirect And firer.moving And firer.stabilised Then modifiers = modifiers - 2
            If firer.indirect And firer.moving Then modifiers = modifiers - 1
            If firer.bomblets Then modifiers = modifiers + 2
            If target.soft_tpt Then modifiers = modifiers + 2
            End If
            If firer.quality >= 8 Then dice = dice + 1
        If firer.quality <= 3 Then dice = dice - 1
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
                dice = dice + IIf(col > 11, col - 11, 0)
                dice = IIf(dice < 0, 0, dice)
                dice = IIf(dice > 9, 9, dice)
                col = IIf(col > 11, 11, col)
                fire_strength = IIf(fs > 9, 9, fs)
                fv = direct_fire_strength(fire_strength, col) - 1
                If fv = 0 Then firecasualties = 0 : Exit Function
                firecasualties = firecasualties + fire_loss_table(dice, IIf(fv > 19, 19, fv))
                fs = fs - 9
            Loop Until fs <= 0
        Else
            Do
                dice = d10() - 1
                fire_effect = IIf(firer.effect > 10, 10, firer.effect)
                For row = 0 To 5
                    If defence <= indirect_fire(row, 0) Then Exit For
                Next
                For col = 0 To 11
                    If firer.effect <= indirect_fire(row, col) Then Exit For
                Next
                If unobserved Then modifiers = modifiers - 2
                If firer.indirect And firer.smoke = gt Then dice = dice - 1
                col = col + modifiers
                col = IIf(col < 0, 0, col)
                dice = dice + IIf(col > 11, col - 11, 0)
                dice = IIf(dice < 0, 0, dice)
                dice = IIf(dice > 9, 9, dice)
                col = (IIf(col > 11, 11, col))
                fv = indirect_fire_strength(firer.firers, col) - 1
                firecasualties = firecasualties + fire_loss_table(dice, IIf(fv > 19, 19, fv))
                firer.effect = firer.effect - 10
            Loop Until firer.effect <= 0
        End If
    End Function

    Function firecasualties_old(ByVal shooter As cunit, ByVal victim As cunit, ByVal firevalue As Integer, ByVal rng As Integer, ByVal unobserved As Boolean)
        Dim directfire As Boolean
        Dim modifiers As Integer = 0
        If victim.ewsupported Then modifiers = modifiers - 2
        modifiers = modifiers - shooter.firers
        If shooter.atgw Then modifiers = modifiers - equipment(victim.equipment).special
        modifiers = modifiers + equipment(victim.equipment).size
        modifiers = modifiers - victim.Cover
        If victim.Cover > 0 And shooter.atgw Then modifiers = modifiers - 1
        If victim.flanked Then modifiers = modifiers + 2
        If victim.rear Or victim.disrupted Then modifiers = modifiers + 3
        If unobserved Then modifiers = modifiers - 2
        If equipment(victim.equipment).defence < 0 Then
            If Not (shooter.atgw Or shooter.indirect) And rng < 1000 Then
                firevalue = firevalue * 0.4
            ElseIf Not (shooter.atgw Or shooter.indirect) And rng < 10000 Then
                firevalue = firevalue * 0.15
            Else
            End If
        End If
        'If (Not shooter.indirect And Not shooter.airborne) Or _
        '    (shooter.airborne And shooter.Airsuperiority) Or _
        '    (shooter.airborne And (rng <= 500 Or rng > 2500)) _
        '        Then directfire = True Else directfire = False
        If (Not shooter.indirect) Then directfire = True Else directfire = False

        Dim firestrength As Integer = 0, firevalue2 As Integer = 0
        'If shooter.strength > 10 Then firestrength = 10 Else firestrength = shooter.strength
        firestrength = shooter.strength
        If directfire Then
            firevalue2 = (firevalue - equipment(victim.equipment).defence + 5 + modifiers)
            If firevalue2 > 12 Then firevalue2 = 12
            firevalue2 = (firevalue2 * 1.4) + firestrength - 5
        ElseIf equipment(victim.equipment).defence > 0 And Not directfire Then
            firevalue2 = firevalue / 2 - equipment(victim.equipment).defence / 3 + 3 + modifiers
            'If shooter.equipment = "AS90" Then firevalue2 = firevalue2 + 1
            If firevalue2 > 12 Then firevalue2 = 12
            firevalue2 = (firevalue2 * 1.17) + firestrength - 4
        ElseIf equipment(victim.equipment).defence < 0 And Not directfire Then
            firevalue2 = (firevalue - equipment(victim.equipment).defence - 2 + modifiers)
            If firevalue2 > 12 Then firevalue2 = 12
            firevalue2 = (firevalue2 * 1.17) + firestrength - 4
        Else
        End If
        Dim x As Integer = d10()
        firecasualties_old = Int(Math.Exp(firevalue2 / 13.05) + (x - 7.4) / 3.1)
        If firecasualties_old < 0 Then firecasualties_old = 0
        victim.casualties = firecasualties_old
        'firecasualties_old = Int((firecasualties_old * 10 / victim.strength) - adjust)
        firecasualties_old = Int((firecasualties_old * 100 / victim.strength))

    End Function
    Function generateresult(ByVal target As cunit, ByVal c As Integer, ByVal indirect As Boolean, airtoair As Boolean, ByVal assault As Boolean)
        generateresult = ""
        If airtoair Then
            If target.hits >= target.strength Then
                If target.casualties >= target.strength Then target.casualties = target.strength : target.aborts = 0
                If target.casualties < target.strength And target.aborts > 0 And target.casualties + target.aborts > target.strength Then target.aborts = target.strength - target.casualties
            End If
            generateresult = " with " + Str(target.casualties) + " aircraft shot down, with " + Str(target.aborts) + " aircraft aborted"
        ElseIf assault Then
            If Not (target.assault Or target.support) And target.strength > 0 Then
                generateresult = " disrupted, and suffered  " + Str(target.casualties) + " casualties, and must retreat 600m"
            ElseIf Not (target.assault Or target.support) And target.strength = 0 Then
                generateresult = " eliminated  "
            Else
                generateresult = " disrupted, and suffered  " + Str(target.casualties) + " casualties, and holds its current position"
            End If
        ElseIf target.mode = travel And Not target.recon And Not target.airborne Then
                If c = 0 Then
                    c = -1
                ElseIf c = -1 Then
                    c = 1
                Else
                    c = c + 1
                End If
            ElseIf c = 0 Then
                generateresult = " with no effect"
                'ElseIf target.airborne And c < 0 Then
                '    generateresult = " with an aircraft aborted"
                '    target.aborts = target.aborts + c
                'ElseIf target.airborne Then
                '    generateresult = " with " + Str(c) + " aircraft shot down"
                '    target.casualties = target.casualties + c
            ElseIf (target.mode = disp And c < 0) Then
                generateresult = " with no effect"
                target.hits = target.hits + 1
            ElseIf target.mode = disp Then
                generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties")
                If c >= 2 Then target.disordered = True
                target.casualties = target.casualties + c
                target.hits = target.hits + c
            ElseIf target.mode <> disp And c < 0 Then
                generateresult = " with no casualties but it must disperse or accept 1 casualty"
                target.hits = target.hits + 1
            Else
                generateresult = " with" + Str(c) + IIf(c = 1, " casualty", " casualties") + " it may now disperse"
            target.hits = target.hits + c
        End If
    End Function

    Public Sub applyresult(ByVal subject As cunit)
        Dim msg As String = ""
        If subject.Aircraft Then
            subject.strength = subject.strength - subject.casualties : subject.casualties = 0
            If subject.strength < 0 Then subject.strength = 0
            If subject.strength = 0 Then msg = subject.title + "(" + subject.equipment + ")" + " has been destroyed"
            If subject.strength > 0 And subject.strength - subject.aborts <= 0 Then msg = subject.title + "(" + subject.equipment + ")" + " aborts air mission"
            If subject.strength - subject.aborts <= 0 Or subject.strength = 0 Then subject.lands(False)
        ElseIf (subject.strength - subject.casualties <= 0) Then
            msg = subject.title + " has been destroyed"
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
            With resultform
                .result.Text = msg
                .ShowDialog()
            End With
        End If
    End Sub

    Public Sub check_demoralisation(ByVal candidates As Collection, ByVal x As String, ByVal y As String)
        Randomize()
        Dim disrupted As Integer = 0, disordered As Integer = 0, destroyed As Integer = 0, totalunits As Integer = 0
        For Each temp As cunit In candidates
            If temp.parent = x And temp.comd = 0 Then
                totalunits = totalunits + temp.initial
                destroyed = destroyed + (temp.initial - temp.strength)
                If temp.disrupted Then
                    disrupted = disrupted + temp.strength
                ElseIf temp.disordered Then
                    disordered = disordered + temp.strength
                    'ElseIf temp.pinned Then
                    '    pinned = pinned + temp.strength
                Else
                End If
            End If
        Next
        Dim percentdisrupted As Single = (disrupted + destroyed) / totalunits
        Dim percentdisrupteddisordered As Single = (disrupted + disordered + destroyed) / totalunits
        Dim d As Integer = d10()
        If d > y And (percentdisrupted >= 0.333 Or percentdisrupteddisordered >= 0.5) Then
            With resultform
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

    Public Function getmaxrange(ByVal u As cunit, ByVal prime As Boolean)
        getmaxrange = 1000
        If u.airborne And u.Airground And u.task = "CAS" And InStr(u.equipment, "GA") > 0 Then
            getmaxrange = 2000
        ElseIf prime Then
            getmaxrange = equipment(u.equipment).max
        Else
            getmaxrange = equipment(u.equipment + u.W2).max
        End If
    End Function
    'Public Sub prep_units()
    '    For Each u As cunit In orbat
    '        If u.comd > 0 Then u.role = "HQ" Else u.role = equipment(u.equipment).role
    '        If u.role = "MOR" Or u.role = "ARTY" Then u.indirect = True Else u.indirect = False
    '        If u.comd > 0 Then u.W2 = "HQ" Else u.W2 = equipment(u.equipment).weapon_2
    '    Next
    'End Sub
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
        'Dim arty_comd As String = ""
        'If phase = 271 Then
        '    arty_comd = divisional_comd(firer)
        'Else
        '    arty_comd = firer.parent
        'End If
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
        CreateNodes(TopNode, u.title, purpose)
        tree.ExpandAll()
        tree.SelectedNode = TopNode
        'selectunit(orbat(tree.SelectedNode.Text))
    End Sub
    Public Sub CreateNodes(ByRef ParentNode As TreeNode, ByRef currentcomd As String, purpose As String)
        Dim subNode As New TreeNode, commandname As String, x As Integer, keynode As String
        For x = 1 To orbat.Count
            If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                If orbat(x).validunit(purpose, currentcomd) Then

                    If ((orbat(x).ground_unit Or orbat(x).aircraft) And orbat(x).comd = 0 And purpose = "Orbat") Or orbat(x).comd > 0 Then
                        commandname = orbat(x).Title
                        keynode = orbat(x).title
                        subNode = ParentNode.Nodes.Add(commandname, keynode)
                        subNode.BackColor = IIf(orbat(commandname).ooc, no_action_pts, nostatus)
                        subNode.Tag = keynode
                    End If
                End If
                If orbat(x).validunit(purpose, currentcomd) Then
                    CreateNodes(subNode, orbat(x).title, purpose)
                End If
            End If
        Next
    End Sub


    Public Sub test_for_events(ByVal s As String, ByVal t As Date)
        For Each e As cevents In event_list
            If Not e.tested Then
                If Format(t, "HH:mm") >= e.time And (s = e.side Or e.side = "Both") Then
                    If e.die = "None" Then
                        e.tested = True
                    Else
                        Dim d6 As Integer = d6, d10 As Integer = d10
                        If (e.die = "D6" And d6 >= e.score) Or (e.die = "D10" And d10 >= e.score) Then
                            e.tested = True
                        Else
                            If e.dec Then e.score = e.score - 1
                        End If
                    End If
                    If e.tested Then
                        With resultform
                            .Text = "Game Events - GT" + Trim(Str(gt)) + " at " + Format(t, "HH:mm") + "hrs"
                            .result.Text = e.text
                            .yb.Visible = False
                            .ShowDialog()
                            .nb.Visible = False
                        End With
                    End If
                End If
            End If
        Next
    End Sub

End Module
