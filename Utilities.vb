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
            If Not (subject.routed Or subject.demoralised) Then
                'Phase 1c - recover from pinned
                If subject.pinned Then
                    If Not subject.hit Then
                        If Not unitsrecoveredpinned Then unitsrecoveredpinned = True
                        subject.pinned = False
                        recoverfrompinned = recoverfrompinned + subject.title + vbNewLine
                    End If
                End If
                'Phase 1d - recover from repulsed
                If subject.repulsed Then
                    If d6() >= Asc(subject.quality) - 62 Then
                        If Not unitsrecoveredrepulsed Then unitsrecoveredrepulsed = True
                        subject.repulsed = False
                        recoverfromrepulsed = recoverfromrepulsed + subject.title + Chr(13)
                    Else
                        If Not unitsremainrepulsed Then unitsremainrepulsed = True Else unitsremainrepulsed = False
                        remainrepulsed = remainrepulsed + subject.title + Chr(13)
                        subject.moved = True
                        subject.tacticalpts = 0
                    End If
                End If
                'Phase1e - recover suppression
                If subject.suppression > 0 Then
                    Dim suppressed As Integer = subject.suppression
                    For i As Integer = 1 To suppressed
                        If d6() >= 5 Then subject.suppression = subject.suppression - 1
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
        Dim listitem As ListViewItem, j As Integer = 0, loaded As String = "*"
        For Each i As ListViewItem In l.Items
            i.Remove()
        Next
        'l.Items.Clear()
        For Each u As cunit In c
            If validunit(purpose, u, hq) Then
                listitem = New ListViewItem
                listitem.Text = u.title
                If hq = "commanders" And (purpose = "Tactical Action" Or purpose = "Air Tasking") Then
                    listitem.SubItems.Add(u.comdpts)
                ElseIf l.Name = "undercommand" Then
                    If u.troopcarrier And u.loaded <> "" Then loaded = "*" Else loaded = ""
                    listitem.SubItems.Add(u.strength)
                    listitem.SubItems.Add(u.equipment + loaded)
                ElseIf InStr("Air DefenceAir Superiority CombatTactical ActionOpportunity Fire", purpose) > 0 Then
                    listitem.SubItems.Add(u.strength)
                    listitem.SubItems.Add(u.equipment)
                ElseIf purpose = "Demoralisation" Or purpose = "Morale Recovery" Then
                    listitem.SubItems.Add(u.comdpts)
                ElseIf purpose = "Close Assault" Or purpose = "Artillery Support" Or Left(purpose, 3) = "Air" Or purpose = "Transport" Or Right(purpose, 7) = "Targets" Then
                    listitem.SubItems.Add(u.equipment)
                Else
                End If
                l.Items.Add(listitem)
                'If purpose <> "Demoralisation" Then l.Items(j).BackColor = status(u)
                color_item(l.Items(j), u)
                j = j + 1
            End If
        Next

    End Sub
    Function status(ByVal temp As cunit)
        If temp.demoralised Then
            status = demoralisedstatus
        ElseIf temp.pinned And temp.repulsed Then
            status = pinnedandrepulsedstatus
        ElseIf temp.pinned Then
            status = pinnedstatus
        ElseIf temp.repulsed Then
            status = repulsedstatus
        ElseIf temp.routed Then
            status = routedstatus
        ElseIf temp.strength <= 0 And Not temp.hq Then
            status = dead
        ElseIf temp.airborne Then
            status = airborne
        Else
            status = nostatus
        End If
    End Function
    Public Sub color_item(ByVal l As ListViewItem, ByVal u As cunit)
        l.BackColor = status(u)
        If Not (l.BackColor = pinnedstatus Or l.BackColor = nostatus Or l.BackColor = airborne) Then l.ForeColor = nostatus Else l.ForeColor = Color.Black
    End Sub
    Function validunit(ByVal phase As String, ByVal tester As cunit, ByVal hq As String)
        validunit = False
        If tester.comd > 0 Then
            If phase = "Demoralisation" And tester.demoralised Then
                validunit = True : Exit Function
            ElseIf hq = "commanders" And Not tester.demoralised Then
                validunit = True : Exit Function
            Else
                validunit = False : Exit Function
            End If
        ElseIf tester.strength = 0 Then
            validunit = False : Exit Function
        ElseIf phase = "Transport" Then
            If tester.troopcarrier And tester.loaded = "" And tester.parent = hq Then validunit = True : Exit Function

        ElseIf phase = "Tactical Action" Then
            If ((tester.Inf And tester.loaded <> "") Or tester.role = "AC" Or (tester.hel And Not tester.airborne)) Then
                validunit = False : Exit Function
            ElseIf tester.demoralised Then
                validunit = False : Exit Function
            ElseIf coc(hq, tester, tester.comd) Then
                validunit = True : Exit Function
            Else
            End If
        ElseIf phase = "Close Assault" And Not tester.Aircraft And tester.comd = 0 Then
            validunit = True : Exit Function
        ElseIf phase = "Artillery Support" And tester.indirect And Not (tester.routed Or tester.repulsed Or tester.pinned Or tester.tacticalpts = 0) Then
            validunit = True : Exit Function
        ElseIf phase = "Morale Recovery" And coc(hq, tester, tester.comd) And (tester.routed Or tester.repulsed) Then
            validunit = True : Exit Function
        ElseIf phase = "Transport" And tester.parent = hq And tester.loaded = "" And Not tester.routed Then
            validunit = True : Exit Function
        ElseIf phase = "Air Tasking" And tester.parent = hq And Not tester.airborne And tester.sorties > 0 And tester.Aircraft Then
            validunit = True : Exit Function
        ElseIf phase = "Air Superiority" And tester.airborne And tester.Airsuperiority Then
            validunit = True : Exit Function
        ElseIf phase = "Air Defence" And tester.airdefence Then
            validunit = True : Exit Function
        ElseIf phase = "Air Defence Targets" And tester.airborne And tester.Airground Then
            validunit = True : Exit Function
        ElseIf phase = "Air-Ground Attack" And tester.airborne And tester.Airground Then
            validunit = True : Exit Function
        ElseIf phase = "Ground Attack Targets" And Not tester.Aircraft And Not (tester.Inf And tester.loaded <> "") Then
            validunit = True : Exit Function
        ElseIf phase = "Air Targets" And tester.role = "AC" And tester.airborne Then
            validunit = True : Exit Function
        ElseIf phase = "Ground Targets" And Not (tester.Inf And tester.loaded <> "") And Not tester.role = "AC" And Not (tester.hel And Not tester.airborne) Then
            validunit = True : Exit Function
        ElseIf phase = "Opportunity Fire" And Not tester.airdefence And Not tester.indirect And Not (tester.Inf And tester.loaded <> "") And Not tester.routed And Not tester.role = "AC" And Not (tester.hel And Not tester.airborne) Then
            validunit = True : Exit Function
        Else
        End If
    End Function

    Function checkaircombat(ByVal phase As String, ByVal air1 As Collection)
        checkaircombat = False
        For Each temp In air1
            If phase = "Air Superiority" And temp.airborne And temp.Airsuperiority Then
                checkaircombat = True
                Exit Function
            ElseIf phase = "Air-Ground Attack" And temp.airborne And temp.Airground Then
                checkaircombat = True
                Exit Function
            Else
            End If
        Next
    End Function
    Public Sub ewsupport(ByVal candidates As Collection, ByVal phase As String)
        Dim ewac As Boolean = False
        For Each subject As cunit In candidates
            If phase = "Air Superiority" And subject.airtask = "EW Support" And subject.airborne Then
                ewac = True : Exit For
            ElseIf phase = "Air-Ground Attack" And subject.airtask = "Wild Weasel" And subject.airborne Then
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
        Dim spotrange As Integer

        Dim tgtrange As Integer = Val(combat.tgt_range.Text)
        If Not (oppfire Or target.tacticalpts <= 0 Or firer.indirect Or firephase = "Air-Ground Attack" Or firephase = "Air Defence") Then
            If tgtrange <= getmaxrange(target, combat.targetprimary.Checked) Then
                Dim x As Integer = MsgBox("Does the target wish to fire", vbYesNo + vbQuestion, "Target Return Fire")
                If x = vbYes Then
                    target.fires = True
                    target.msg = ""
                Else
                    target.fires = False
                    target.msg = "Opted not to fire "
                End If
            Else
                target.fires = False
                target.msg = "did not fire, out of range"
            End If
        Else
            target.fires = False
            target.msg = ""
        End If
        If combat.vis_range_select.Visible = True Then spotrange = Val(combat.visrange.Text) Else spotrange = tgtrange

        If firer.nondetect Then target.spotted = True Else target.spotted = spotting(spotrange, target, firer.airborne)
        If target.fires And target.nondetect Then
            firer.spotted = True
        ElseIf target.fires Then
            firer.spotted = spotting(spotrange, firer, target.airborne)
        Else
            firer.spotted = False
        End If

        Dim initiative = d6() - d6()
        If 68 - Asc(firer.quality) > 68 - Asc(target.quality) Then initiative = initiative + 1
        If 68 - Asc(target.quality) > 68 - Asc(firer.quality) Then initiative = initiative - 1
        If target.fired Then initiative = initiative + 1
        If target.spotted Then initiative = initiative + 3
        If firer.spotted And target.fires Then initiative = initiative - 3
        If firer.pinned Then
            firer.statusimpact = -1
        ElseIf firer.repulsed Then
            firer.statusimpact = -2
        Else
            firer.statusimpact = 0
        End If
        If target.pinned Then
            target.statusimpact = -1
        ElseIf target.repulsed Then
            target.statusimpact = -2
        ElseIf target.routed Then
            target.statusimpact = -4
        Else
            target.statusimpact = 0
        End If

        initiative = initiative + firer.statusimpact - target.statusimpact
        firer.effect = scoreforeffect(firer, target, tgtrange)
        If target.fires Then target.effect = scoreforeffect(target, firer, tgtrange)
        firer.modifier = 0
        target.modifier = 0

        If firer.effect = 0 Then initiative = initiative - 2
        If firer.effect > 0 And Not target.spotted And (firer.indirect Or firer.Airground) Then
            firer.effective = True
            firer.modifier = firer.modifier - 2
            firer.msg = ""
            unobserved = True
        ElseIf firer.effect > 0 And Not target.spotted Then
            firer.msg = "did not spot their target"
            firer.effective = False
        ElseIf firer.effect > 0 And target.spotted Then
            firer.effective = True
        ElseIf firer.effect = 0 And Not target.spotted Then
            firer.effective = False
            firer.msg = "did not spot their target"
        ElseIf firer.effect = 0 And target.spotted Then
            firer.effective = False
            firer.msg = "spotted their target but no effect firing"
        Else
            firer.msg = ""
        End If

        If oppfire Then firer.tacticalpts = firer.tacticalpts - 1

        If target.effect = 0 Then initiative = initiative + 2
        If Not target.fires Then
            target.msg = ""
            target.effective = False
        ElseIf target.effect = 0 And Not firer.spotted Then
            target.msg = "did not spot their target"
            target.effective = False
        ElseIf target.effect = 0 And firer.spotted Then
            target.msg = "spotted their target but no effect firing"
            target.effective = False
        ElseIf target.effect > 0 And firer.spotted And target.fires Then
            target.msg = ""
            target.effective = True
        ElseIf target.effect > 0 And Not firer.spotted Then
            target.msg = "did not spot their target"
            target.effective = False
        Else
            target.msg = ""
            target.effective = False
        End If

        If firer.effect = 0 And target.effect = 0 Then
            If firephase = "Air-Ground Attack" Or firephase = "Air Defence" Then
                resultform.result.Text = "Firer has no effect"
            Else
                resultform.result.Text = "Neither Firer or target has any effect on each other"
            End If
            resultform.ShowDialog()
            combat.Hide()
            Exit Sub
        End If

        Dim init_msg As String = ""
        firer.fired = True
        target.result = 0
        firer.result = 0

        If target.fires Then
            target.fired = True
            target.tacticalpts = target.tacticalpts - 1
        End If

        If firer.indirect Or firer.Airground Then
            If firer.indirect And firer.effective And unobserved Then
                init_msg = "Unobserved Indirect Fire "
            ElseIf firer.indirect And firer.effective And Not unobserved Then
                init_msg = "Observed Indirect Fire"
            ElseIf firer.Airground Then
                init_msg = "Air-Ground Fire "
            End If
            If firer.effective Then
                firer.result = firecasualties(firer, target, firer.effect, combat.firerflank.Checked, combat.firerrear.Checked, tgtrange, unobserved)
                firer.msg = firer.title + " " + applyresult(target, firer.result, firer.indirect, False)
            Else
                firer.msg = firer.title + " " + firer.msg
            End If
        ElseIf initiative >= 4 Or combat.combatmode = "Opportunity Fire" Then
            If oppfire And combat.combatmode = "Opportunity Fire" Then
                init_msg = firer.title + " conducts opportunity fire against " + target.title
            Else
                init_msg = firer.nation + " won the initiative (" + Trim(Str(initiative)) + ") and fired first"
            End If
            If firer.effective Then
                firer.result = firecasualties(firer, target, firer.effect, combat.firerflank.Checked, combat.firerrear.Checked, tgtrange, unobserved)
                firer.msg = firer.title + " " + applyresult(target, firer.result, firer.indirect, False)
            Else
                firer.msg = firer.title + " " + firer.msg
            End If
            If target.routed Or target.strength = 0 Then target.effective = False : target.msg = ""
            If combat.combatmode = "Opportunity Fire" Then
                target.msg = ""
            ElseIf target.fires And target.effective Then
                target.result = firecasualties(target, firer, target.effect, combat.targetflank.Checked, combat.targetrear.Checked, tgtrange, unobserved)
                target.msg = target.title + " fired second " + applyresult(firer, target.result, False, False)
            ElseIf target.fires And Not target.effective And target.msg <> "" Then
                target.msg = target.title + " fired second " + target.msg
            ElseIf target.routed Then
                target.msg = target.title + " did not fire because of routing "
            ElseIf target.strength = 0 Then
                target.msg = target.title + " did not fire because it has been destroyed"
            Else
            End If
        ElseIf initiative <= -4 Then
            init_msg = target.nation + " won the initiative (" + Trim(Str(initiative)) + ") and fired first"
            If target.fires And target.effective Then
                target.result = firecasualties(target, firer, target.effect, combat.targetflank.Checked, combat.targetrear.Checked, tgtrange, unobserved)
                target.msg = target.title + " " + applyresult(firer, target.result, False, False)
            ElseIf target.fires And Not target.effective Then
                target.msg = target.title + " " + target.msg
            Else
            End If
            If firer.routed Or firer.strength = 0 Then firer.effective = False : firer.msg = ""
            If firer.effective Then
                firer.result = firecasualties(firer, target, firer.effect, combat.firerflank.Checked, combat.firerrear.Checked, tgtrange, unobserved)
                firer.msg = firer.title + " fired second " + applyresult(target, firer.result, firer.indirect, False)
            ElseIf Not firer.effective And firer.msg <> "" Then
                firer.msg = firer.title + " fired second " + firer.msg
            ElseIf firer.routed Then
                firer.msg = firer.title + " did not fire because of routing "
            ElseIf firer.strength = 0 Then
                firer.msg = firer.title + " did not fire because it has been destroyed"
            Else
            End If
        Else
            init_msg = "Simultaneous firefight (" + Trim(Str(initiative)) + ") "
            If firer.effective Then firer.result = firecasualties(firer, target, firer.effect, combat.firerflank.Checked, combat.firerrear.Checked, tgtrange, unobserved)
            If target.fires And target.effective Then target.result = firecasualties(target, firer, target.effect, combat.targetflank.Checked, combat.targetrear.Checked, tgtrange, unobserved)
            If firer.effective Then
                firer.msg = firer.title + " fired " + applyresult(target, firer.result, firer.indirect, False)
            Else
                firer.msg = firer.title + " " + firer.msg
            End If
            If target.fires And target.effective Then
                target.msg = target.title + " fired " + applyresult(firer, target.result, False, False)
            Else
                target.msg = target.title + " " + target.msg
            End If
        End If
        If initiative > -4 Or firer.indirect Or firer.Airground Or combat.combatmode = "Opportunity Fire" Then
            resultform.result.Text = "Results" + vbNewLine + init_msg + vbNewLine + firer.msg + vbNewLine + target.msg
        Else
            resultform.result.Text = "Results" + vbNewLine + init_msg + vbNewLine + target.msg + vbNewLine + firer.msg
        End If
            resultform.ShowDialog()

            If combat.combatmode = "Air Defence" Or combat.combatmode = "Air Superiority" Or (combat.combatmode = "Tactical Action" And target.hel) Then
                If target.hit And (target.repulsed Or target.routed) Then
                    target.airborne = False
                target.sorties = -equipment(target.equipment).sortie
            End If
            ElseIf combat.combatmode = "Air-Ground Attack" Then
                If target.hit And (target.repulsed Or target.pinned Or target.routed) Then check_demoralisation(targets, target.parent, target.quality)
            ElseIf combat.combatmode = "Opportunity Fire" Then
                If target.hit And (target.repulsed Or target.pinned Or target.routed Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
            ElseIf combat.combatmode = "Tactical Action" Then
                If target.hit And (target.repulsed Or target.pinned Or target.routed Or target.strength <= 0) Then check_demoralisation(targets, target.parent, target.quality)
                If firer.hit And (firer.repulsed Or firer.pinned Or firer.routed Or firer.strength <= 0) Then check_demoralisation(firers, firer.parent, firer.quality)
            Else
            End If

    End Sub
    Function spotting(ByVal x As Integer, ByVal subject As cunit, ByVal airborne As Boolean)
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
            spotting = True
        ElseIf x <= r * 2 + firedetection And diceroll >= 5 Then
            spotting = True
        Else
            spotting = False
        End If
    End Function
    Function scoreforeffect(ByVal shooter As cunit, ByVal victim As cunit, ByVal x As Integer)
        scoreforeffect = 0
        If shooter.Airsuperiority Then
            scoreforeffect = equipment(shooter.equipment).aam
            Exit Function
        End If
        Dim weapon As String
        If shooter.W2 = "" Then weapon = shooter.equipment Else weapon = shooter.equipment + shooter.W2
        If equipment(victim.equipment).defence < 0 And (shooter.atgw Or shooter.Inf) Then weapon = "MG"
        If equipment(shooter.equipment).max < x Then Exit Function
        Dim myType As Type = GetType(cequipment)
        Dim e As New cequipment
        e = equipment(weapon)
        Dim properties As System.Reflection.PropertyInfo() = myType.GetProperties()
        For Each p As System.Reflection.PropertyInfo In properties
            If p.Name <> "role" And Left(p.Name, 1) = "r" Then
                If x <= Val(Mid(p.Name, 2)) Then
                    scoreforeffect = p.GetValue(e, Nothing)
                    Exit For
                End If
            End If
        Next
    End Function
    Function firecasualties(ByVal shooter As cunit, ByVal victim As cunit, ByVal firevalue As Integer, ByVal Flank As Boolean, ByVal rear As Boolean, ByVal rng As Integer, ByVal unobserved As Boolean)
        Dim directfire As Boolean
        Dim modifiers As Integer = 0
        If shooter.pinned Then modifiers = modifiers - 1
        If shooter.repulsed Then modifiers = modifiers - 2
        If victim.ewsupported Then modifiers = modifiers - 2
        modifiers = modifiers - shooter.suppression
        If victim.pinned Then modifiers = modifiers - 1
        If victim.repulsed Then modifiers = modifiers - 2
        If shooter.atgw Then modifiers = modifiers - equipment(victim.equipment).special
        modifiers = modifiers + equipment(victim.equipment).size
        modifiers = modifiers - victim.Cover
        If victim.Cover > 0 And shooter.atgw Then modifiers = modifiers - 1
        If Flank Then modifiers = modifiers + 2
        If rear Or victim.routed Then modifiers = modifiers + 3
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
        firecasualties = Int(Math.Exp(firevalue2 / 13.05) + (x - 7.4) / 3.1)
        If firecasualties < 0 Then firecasualties = 0
        victim.casualties = firecasualties
        'firecasualties = Int((firecasualties * 10 / victim.strength) - adjust)
        firecasualties = Int((firecasualties * 100 / victim.strength))

    End Function
    Function applyresult(ByVal subject As cunit, ByVal c As Integer, ByVal indirect As Boolean, ByVal assault As Boolean)
        applyresult = ""
        Dim d As Integer, adjust As Integer = 0, y As Integer, result As Integer
        If subject.strength - subject.casualties <= 0 Then
            With subject
                .routed = False
                .strength = 0
                .moved = False
                .repulsed = False
                .pinned = False
                .airborne = False
                .fired = False
                .sorties = 0
                .hit = True
            End With
        Else
            subject.strength = subject.strength - subject.casualties
        End If
        If subject.troopcarrier And subject.loaded <> "" Then
            If orbat(subject.loaded).strength - subject.casualties <= 0 Or subject.strength = 0 Then
                With orbat(subject.loaded)
                    .routed = False
                    .strength = 0
                    .moved = False
                    .repulsed = False
                    .pinned = False
                    .fired = False
                    .sorties = 0
                    .hit = True
                    .loaded = ""
                End With
                subject.loaded = ""
            Else
                orbat(subject.loaded).strength = orbat(subject.loaded).strength - subject.casualties
            End If
        End If
        If subject.strength <= 0 Then applyresult = "has DESTROYED by fire " + subject.title + " inflicting " + Trim(Str(subject.casualties)) + " casualties" : Exit Function
        If Not assault Then
            If indirect Then adjust = 10
            y = 10 * (Asc(subject.quality) - 67)
            d = d100() + c + y + 5 * subject.suppression

            If d > 140 - adjust Then
                result = 3
            ElseIf d > 110 - adjust Then
                result = 2
            ElseIf d > 80 - adjust Then
                result = 1
            Else
                result = 0
            End If
        Else
            result = c
        End If
        Select Case result
            Case 0
                applyresult = "has inflicted " + Trim(Str(subject.casualties)) + " casualties on " + subject.title + " but with no morale effect"
            Case 1
                subject.pinned = True
                subject.hit = True
                applyresult = "has PINNED " + subject.title + " inflicting " + Trim(Str(subject.casualties)) + " casualties"
                subject.suppression = subject.suppression + 1
            Case 2
                subject.repulsed = True
                subject.hit = True
                subject.pinned = False
                subject.moved = True
                applyresult = "has REPULSED " + subject.title + " inflicting " + Trim(Str(subject.casualties)) + " casualties"
                If subject.airborne Then applyresult = applyresult + Chr(13) + "which now must end its current sortie"
                If subject.indirect Then subject.eligibleCB = False
                subject.suppression = subject.suppression + 2
            Case 3
                With subject
                    .routed = True
                    .moved = False
                    .repulsed = False
                    .pinned = False
                    .airborne = False
                    .fired = False
                    .eligibleCB = False
                    .sorties = 0
                    .hit = True
                End With
                applyresult = "has ROUTED " + subject.title + " inflicting " + Trim(Str(subject.casualties)) + " casualties"
                subject.suppression = subject.suppression + 3

        End Select
        subject.casualties = 0
    End Function
    Public Sub check_demoralisation(ByVal candidates As Collection, ByVal x As String, ByVal y As String)
        Randomize()
        Dim z As Integer = Asc(y) - 62, repulsed As Integer = 0, pinned As Integer = 0, destroyed As Integer = 0, totalunits As Integer = 0
        For Each temp As cunit In candidates
            If temp.parent = x Then
                totalunits = totalunits + temp.initial
                destroyed = destroyed + (temp.initial - temp.strength)
                If temp.routed Then
                    destroyed = destroyed + temp.strength
                ElseIf temp.repulsed Then
                    repulsed = repulsed + temp.strength
                ElseIf temp.pinned Then
                    pinned = pinned + temp.strength
                Else
                End If
            End If
        Next
        Dim percentrepulsed As Single = (repulsed + destroyed) / totalunits
        Dim percentpinnedrepulsed As Single = (pinned + repulsed + destroyed) / totalunits
        Dim d As Integer = d6()
        If d < z And (percentrepulsed >= 0.333 Or percentpinnedrepulsed >= 0.5) Then
            With resultform
                .result.Text = parent(candidates, x)
                .ShowDialog()
            End With
        End If
    End Sub
    Function parent(ByVal candidates As Collection, ByVal x As String)
        parent = ""
        Dim fail_text As String = ""
        With orbat(x)
            .demoralised = True
            .moved = True
        End With
        For Each temp As cunit In candidates
            If temp.parent = x Then
                temp.demoralised = True
                temp.moved = True
                parent = parent + temp.title + ", "
            End If
        Next
        fail_text = " are now demoralised and on table units must move a minimum of half a tactical"
        fail_text = fail_text + vbNewLine + "move per turn toward their own sides baseline. The units of this BG"
        fail_text = fail_text + vbNewLine + "may not initiate fire and CPs can only be used to halt retreating units"
        parent = parent + vbNewLine + fail_text
    End Function
    Public Sub log_entry(ByVal result As String)
        'logtime = to_hr(x)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Strings.Left(scenario, (Len(scenario) - 4)) + ".his", True)
        file.WriteLine(result)
        file.Close()
    End Sub
    Public Sub sort()
        Dim t As String
        For Each u As cunit In orbat
            If Left(u.title, 2) = "HQ" And InStr(u.title, "/") > 0 Then
                t = "0" + Mid(u.title, InStr(u.title, "/"))
            ElseIf u.comd > 0 Then
                t = "0/" + u.title
            Else
                t = u.title
            End If
            u.sort = u.nation + Str(7 - u.comd) + u.parent + Mid(t, InStr(t, "/") + 1) + Left(t, InStr(t, "/") - 1)
        Next
        Dim vtemp As cunit
        For i = 1 To orbat.Count - 1
            For j = i + 1 To orbat.Count
                If orbat(i).sort >= orbat(j).sort Then
                    vtemp = orbat.Item(j)
                    orbat.Remove(j)
                    orbat.Add(vtemp, vtemp.title, Before:=i)
                End If
            Next j
        Next i
        save_orbat()
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
        If u.airborne And Not u.ordnance And u.Airground Then
            getmaxrange = 1000
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

End Module
