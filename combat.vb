Public Class combat
    Public firer As cunit, target As cunit, combatmode As String, target_fires As Boolean = False
    Private weapon As String
    Dim currentrange As Integer, maxrange As Integer, tn As Integer, range_not_needed As Boolean = False

    Private Sub combat_Load(sender As Object, e As EventArgs) Handles Me.Load

        Randomize(24 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        'test message
        For Each c As Control In Panel1.Controls
            If c.Tag = "1" Then c.Enabled = True
        Next
        For Each c As Control In Panel2.Controls
            If c.Tag = "2" Then c.Enabled = False
        Next
        s1.BackColor = defa
        s2.BackColor = defa
        s3.BackColor = defa
        reset_target_strength()
        range_not_needed = False
        movement.notfired = True
        title.Text = combatmode + " - Game Turn " + scenariodefaults.gameturn.Text
        targets.Visible = True
        observation(False)
        return_fire.Enabled = False
        'return_fire2.BackColor = defa
        firesmoke.Visible = False
        firesmoke.Enabled = False
        fire.Enabled = False
        selectedtarget.Text = ""
        'targetprimary.Text = "Primary"
        targetprimary.Text = ""
        target = New cunit
        If combatmode = "Fire and Movement" And Not firer.observer Then
            fireraspect.Enabled = False
            selectedtarget.Text = ""
        ElseIf Me.Tag = "Opportunity Fire" Then
            target = New cunit
            If movement.tactical = 3 Then target = assault.attacker Else target = movement.mover
            selectedtarget.Text = target.title
            targets.Visible = False
            targetprimary.Text = target.equipment
            If target.heli Then
                altitude.Visible = True
                taltitude.Visible = True
            End If
            For Each c As Control In Panel2.Controls
                If c.Tag = "2" Then c.Enabled = True
            Next
            If target.Cover > 0 Then
                targetcover.Text = "+" + Trim(Str(target.Cover))
                targetcover.BackColor = golden
            End If
        ElseIf Me.tag = "Air Ground" Or Me.tag = "SEAD" Then
            targets.Visible = True
            fireraspect.Enabled = True
            firercover.Enabled = False
            fplains.Enabled = False
            firercover.Enabled = False
            froadmove.Enabled = False
            finsmoke.Enabled = False
            tplains.Enabled = True
            targetcover.Enabled = True
            troadmove.Enabled = True
        ElseIf Me.Tag = "Air Defence" Or combatmode = "Air-to-Air" Then
            targets.Visible = True
            fireraspect.Enabled = False
            firercover.Enabled = False
            finsmoke.Enabled = False
            fplains.Enabled = False
            froadmove.Enabled = False
            firerelevation.Enabled = False
            altitude.Visible = True
            taltitude.Visible = True
            taltitude.Enabled = True
            If combatmode = "Air-to-Air" Then
                observation(False)
                tgt_range.Enabled = False
                tgt_range_select.Enabled = False
                tgt_range.Text = "0"
                range_not_needed = True
            ElseIf combatmode = "Air Defence against CAP Missions" Then
                tgt_range.Enabled = False
                tgt_range_select.Enabled = False
                tgt_range.Text = "30000"
                range_not_needed = True
            Else

            End If
        Else
        End If
        If firer.observer Then
            observation(IIf(firer.indirect, True, False))
            tgt_range_select.SelectedIndex = tgt_range_select.Items.Count - 1
            firercover.Enabled = False
            fplains.Enabled = False
            froadmove.Enabled = False
            fireraspect.Enabled = False
            With firer
                .plains = False
                .roadmove = False
            End With
        End If
        update_firer_parameters()
        If firer.indirect And firer.smoke > 0 Then firesmoke.Visible = True : firesmoke.Enabled = True Else firesmoke.Visible = False
        selectedfirer.Text = firer.title
        firer.fires = False
    End Sub

    Public Sub observation(enable As Boolean)
        observer.Visible = enable
        visrange.Visible = enable
        vis_range_select.Visible = enable
    End Sub

    Private Sub reset_target_strength()
        t1.BackColor = defa
        t2.BackColor = defa
        t3.BackColor = defa
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        return_fire.Enabled = False
    End Sub

    Private Sub update_firer_parameters()
        firerprimary.Text = firer.equipment
        If firer.elevated Then elevation(firerelevation, Nothing)
        If firer.roadmove Then roadmove(froadmove, Nothing)
        If firer.plains Then plains(fplains, Nothing)
        If firer.Cover > 0 Then
            firercover.Text = "+" + Trim(Str(firer.Cover))
            firercover.BackColor = golden
        Else
            firercover.Text = "None"
            firercover.BackColor = defa
        End If
        firer_strength(s1, s2, s3, IIf(oppfire, firer.return_fire_strength(movement.tactical), firer.strength))
    End Sub

    Private Sub firer_strength(f1 As Object, f2 As Object, f3 As Object, strength As Integer)
        If strength <= 5 Then
            f1.Enabled = True
            f2.Enabled = False
            f3.Enabled = False
        ElseIf strength <= 11 Then
            f1.Enabled = True
            f2.Enabled = True
            f3.Enabled = False
        Else
            f1.Enabled = True
            f2.Enabled = True
            f3.Enabled = True
        End If
        Select Case strength
            Case 1, 2, 3, 4, 5
                f1.Text = strength : f2.Text = "" : f3.Text = ""
            Case 6
                f1.Text = "3" : f2.Text = "3" : f3.Text = ""
            Case 7
                f1.Text = "4" : f2.Text = "3" : f3.Text = ""
            Case 8
                f1.Text = "4" : f2.Text = "4" : f3.Text = ""
            Case 9
                f1.Text = "5" : f2.Text = "4" : f3.Text = ""
            Case 10
                f1.Text = "5" : f2.Text = "5" : f3.Text = ""
            Case 11
                f1.Text = "6" : f2.Text = "5" : f3.Text = ""
            Case 12
                f1.Text = "4" : f2.Text = "4" : f3.Text = "4"
            Case 13
                f1.Text = "5" : f2.Text = "4" : f3.Text = "4"
            Case 14
                f1.Text = "5" : f2.Text = "5" : f3.Text = "4"
            Case 15
                f1.Text = "5" : f2.Text = "5" : f3.Text = "5"
        End Select
        If Strings.Left(f1.name, 1) = "s" Then
            f1.BackColor = golden
        End If
    End Sub

    Private Sub choose_weapon(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firerprimary.Click, targetprimary.Click
        If Not sender.enabled Then Exit Sub
        If selectedtarget.Text = "" Then Exit Sub
        If firer.w2 = "" Then Exit Sub
        If sender.name = "firerprimary" Then
            If weapon = firer.w2 Then weapon = firer.equipment Else weapon = firer.w2
            firerprimary.Text = weapon
        Else
            If weapon = target.w2 Then weapon = target.equipment Else weapon = target.w2
            targetprimary.Text = weapon
        End If

    End Sub

    Private Sub select_altitude(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taltitude.Click
        If target Is Nothing Then Exit Sub
        If target.title = "" Then Exit Sub
        If sender.Text = "Low" Then
            sender.Text = "Medium" : sender.BackColor = golden
        ElseIf sender.Text = "Medium" Then
            sender.Text = "High"
        ElseIf sender.Text = "High" Then
            sender.Text = "Very Low"
        ElseIf sender.Text = "Very Low" Then
            sender.Text = "Low"
            sender.BackColor = defa
        Else
        End If
        target.mode = sender.text
    End Sub

    Private Sub select_cover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firercover.Click, targetcover.Click
        Dim cover As Object
        If sender.name = "targetcover" Then
            If target Is Nothing Then Exit Sub
            If target.title = "" Then Exit Sub
        End If
        If InStr(sender.name, "firer") > 0 Then cover = firercover Else cover = targetcover
        If cover.Text = "None" Then
            cover.Text = "+1" : cover.BackColor = golden
        ElseIf cover.Text = "+1" Then
            cover.Text = "+2"
        ElseIf cover.Text = "+2" Then
            cover.Text = "+3"
        ElseIf cover.Text = "+3" Then
            cover.Text = "+4"
        ElseIf cover.Text = "+4" Then
            cover.Text = "None" : cover.BackColor = defa
        Else
        End If
        If InStr(sender.name, "firer") > 0 Then
            firer.Cover = Val(cover.text)
        Else
            target.Cover = Val(cover.text)
        End If
    End Sub

    Private Sub Flank_and_rear(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fireraspect.Click, targetaspect.Click
        If sender.name = "targetaspect" Then
            If target Is Nothing Then Exit Sub
            If target.title = "" Then Exit Sub
        End If
        If sender.text = "Front" Then
            sender.text = "Flank"
            sender.backcolor = golden
            If InStr(sender.name, "firer") > 0 Then
                target.flanked = True
                target.rear = False
            Else
                firer.flanked = True
                firer.rear = False
            End If
        ElseIf sender.text = "Flank" Then
            sender.text = "Rear"
            If InStr(sender.name, "firer") > 0 Then
                target.flanked = False
                target.rear = True
            Else
                firer.flanked = False
                firer.rear = True
            End If
        Else
            sender.text = "Front"
            sender.backcolor = defa
            If InStr(sender.name, "firer") > 0 Then
                target.flanked = False
                target.rear = False
            Else
                firer.flanked = False
                firer.rear = False
            End If
        End If
    End Sub

    Private Sub Select_target(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles targets.Click
        target = orbat(targets.FocusedItem.Text)
        firer_strength(t1, t2, t3, target.return_fire_strength(1))
        reset_target_strength()
        tn = targets.FocusedItem.Index
        selectedtarget.Text = target.title
        targetprimary.Text = target.equipment
        weapon = targetprimary.Text
        'If target.w2 <> "" Then targetprimary.Enabled = True Else targetprimary.Enabled = False
        If target.airborne And target.task = "CAP" And Not firer.airborne Then
            With taltitude
                .Text = "Medium"
                .BackColor = golden
                .Enabled = False
            End With
        ElseIf target.airborne And target.task = "SEAD" And Not firer.airborne Then
            taltitude.Enabled = True
            return_fire.Enabled = True
        ElseIf target.airborne And Not firer.airborne Then
            taltitude.Enabled = True
        ElseIf target.airborne And target.fired <> CorpsComd.phase And firer.airborne Then
            return_fire.Enabled = True
        Else
            If target.elevated Then elevation(targetelevation, Nothing)
            If target.roadmove Then roadmove(troadmove, Nothing)
            If target.plains Then plains(tplains, Nothing)
            If target.Cover > 0 Then
                targetcover.Text = "+" + Trim(Str(target.Cover))
                targetcover.BackColor = golden
            Else
                targetcover.Text = "None"
                targetcover.BackColor = defa
            End If
            For Each c As Control In Panel2.Controls
                If c.Tag = "2" Then c.Enabled = True
            Next
            fireraspect.Enabled = True
        End If
        target.fires = False
        return_fire_available()
    End Sub

    Private Sub select_strength_firing(sender As Object, e As EventArgs) Handles s1.Click, s2.Click, s3.Click, t3.Click, t2.Click, t1.Click
        If Not sender.enabled Then Exit Sub
        If sender.backcolor = defa Then
            sender.backcolor = golden
            If Strings.Left(sender.name, 1) = "s" Then firer.firers = firer.firers + Val(sender.text) Else target.firers = target.firers + Val(sender.text)
        Else
            sender.backcolor = defa
            If Strings.Left(sender.name, 1) = "s" Then firer.firers = firer.firers - Val(sender.text) Else target.firers = target.firers - Val(sender.text)
        End If
    End Sub

    Private Sub elevation(sender As Object, e As EventArgs) Handles firerelevation.Click, targetelevation.Click
        If sender.name = "targetelevation" Then
            If target Is Nothing Then Exit Sub
            If target.title = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "Elevated"
            sender.backcolor = golden
            If InStr(sender.name, "firer") > 0 Then firer.elevated = True Else target.elevated = True
        Else
            sender.text = "Same Level"
            sender.backcolor = defa
            If InStr(sender.name, "firer") > 0 Then firer.elevated = False Else target.elevated = False
        End If

    End Sub

    Private Sub roadmove(sender As Object, e As EventArgs) Handles troadmove.Click, froadmove.Click
        If sender.name = "troadmove" Then
            If target Is Nothing Then Exit Sub
            If target.title = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "Road Move"
            sender.backcolor = golden
            If sender.name = "froadmove" Then firer.roadmove = True Else target.roadmove = True
        Else
            sender.text = "X Country"
            sender.backcolor = defa
            If sender.name = "froadmove" Then firer.roadmove = False Else target.roadmove = False
        End If
    End Sub

    Private Sub plains(sender As Object, e As EventArgs) Handles tplains.Click, fplains.Click
        If sender.name = "tplains" Then
            If target Is Nothing Then Exit Sub
            If target.title = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "Plains/Steppes"
            sender.backcolor = golden
            If sender.name = "fplains" Then firer.plains = True Else target.plains = True
        Else
            sender.text = "Clear Terrain"
            sender.backcolor = defa
            If sender.name = "fplains" Then firer.plains = False Else target.plains = False
        End If
    End Sub

    Private Sub in_smoke(sender As Object, e As EventArgs) Handles finsmoke.Click, tinsmoke.Click
        If sender.name = "tinsmoke" Then
            If target Is Nothing Then Exit Sub
            If target.title = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "In Smoke"
            sender.backcolor = golden
            If sender.name = "finsmoke" Then firer.insmoke = True Else target.insmoke = True
        Else
            sender.text = "No Smoke"
            sender.backcolor = defa
            If sender.name = "finsmoke" Then firer.insmoke = False Else target.insmoke = False
        End If

    End Sub

    'Private Sub return_fire_Click(sender As Object, e As EventArgs) Handles return_fire.Click
    '    If sender.backcolor = defa Then
    '        sender.backcolor = golden
    '    Else
    '        sender.backcolor = defa
    '    End If
    'End Sub

    Private Sub return_fire_available() Handles tgt_range_select.Click, targets.Click, targetcover.Click, firercover.Click, firerelevation.Click, targetelevation.Click, froadmove.Click, fplains.Click, troadmove.Click, tplains.Click
        reset_target_strength()
        If combatmode = "Opportunity Fire" Then Exit Sub
        If firer.indirect Then Exit Sub
        If tgt_range_select.SelectedIndex = -1 Then Exit Sub
        If target Is Nothing Or target.title = "" Then Exit Sub
        If target.opp_return <= 0 Or target.atgw Then Exit Sub
        Dim r As Integer
        If tgt_range_select.SelectedItem <> tgt_range.Text Then
            r = Val(tgt_range_select.SelectedItem)
        Else
            r = Val(tgt_range.Text)
        End If
        If r > equipment(target.equipment).max Then Exit Sub
        firer_strength(t1, t2, t3, target.return_fire_strength(1))
        If spotting(r, target, firer) Or combatmode = "Air Defence" Then return_fire.Enabled = True
    End Sub

    Private Sub observer_Click(sender As Object, e As EventArgs)
        If sender.text = "Observer" Then
            sender.text = "Observing"
            vis_range_select.Enabled = False
        Else
            sender.text = "Observer"
            vis_range_select.Enabled = True
        End If
    End Sub

    Private Sub eligible_to_fire() Handles vis_range_select.Click, tgt_range_select.Click, targets.Click, targetcover.Click, firercover.Click, firerelevation.Click, targetelevation.Click, froadmove.Click, fplains.Click, troadmove.Click, tplains.Click
        fire.Enabled = False
        firesmoke.Enabled = False
        firesmoke.Visible = False
        If firer.indirect And (firer.smoke = 0 Or gt >= firer.smoke + 4) Then
            firesmoke.Visible = True
            firesmoke.Enabled = True
        End If
        If Not range_not_needed And tgt_range_select.SelectedIndex = -1 Then Exit Sub
        If target Is Nothing Or target.title = "" Then Exit Sub
        firer.spotted = False
        target.spotted = False
        If range_not_needed Then
            firer.spotted = True
            target.spotted = True
            fire.Enabled = True
            Exit Sub
        End If
        tgt_range.Text = tgt_range_select.SelectedItem
        If Val(tgt_range.Text) > getmaxrange(firer, IIf(firer.equipment = firerprimary.Text Or Not firerprimary.Enabled, True, False)) Then
            fire.Enabled = False
            target.spotted = fire.Enabled
            tgt_range.ForeColor = Color.Red
            Exit Sub
        End If
        If Me.Tag = "Air Defence" Or (firer.sead And target.eligibleCB And target.airdefence) Then
            fire.Enabled = True
            target.spotted = True
            tgt_range.ForeColor = Color.Green

        ElseIf Not firer.indirect Then
            fire.Enabled = spotting(Val(tgt_range.Text), firer, target)
            target.spotted = fire.Enabled
            If target.spotted Then tgt_range.ForeColor = Color.Green Else tgt_range.ForeColor = Color.Red
        ElseIf observer.Visible And vis_range_select.Enabled Then
            Dim tmp As String = ""
            visrange.Text = vis_range_select.SelectedItem
            If (firer.task = "IN" Or firer.task = "AF") And observer.Text <> "Observer" Then
                tmp = orbat(observer.Text).task
                orbat(observer.Text).task = firer.task
            End If
            Dim observed As Boolean, identified As Boolean
            identified = spotting(Val(tgt_range.Text), firer, target)
            If observer.Text <> "Observer" Then
                observed = spotting(Val(visrange.Text), orbat(observer.Text), target)
            Else
                observed = False
            End If
            fire.Enabled = observed Or identified
            target.spotted = fire.Enabled
            If identified Then tgt_range.ForeColor = Color.Green Else tgt_range.ForeColor = Color.Red
            If observed Then visrange.ForeColor = Color.Green Else visrange.ForeColor = Color.Red
            If (firer.task = "IN" Or firer.task = "AF") And observer.Text <> "Observer" Then orbat(observer.Text).task = tmp
            If firer.task = "CB" And Not observed Then
                With resultform
                    .result.Text = observer.Text + " failed to locate " + target.title + "(" + target.equipment + ")"
                    .ShowDialog()
                End With
                targets.Items(tn).Remove()
                If targets.Items.Count = 0 Then Me.Close()
            End If
        Else
        End If

    End Sub

    Private Sub fire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fire.Click
        If Not range_not_needed And tgt_range.Text = "Range" Then Exit Sub
        If firer.observer And visrange.Text = "Vis Range" Then Exit Sub
        If selectedtarget.Text = "" Then Exit Sub
        firer.firers = 0 : target.firers = 0
        firer.firers = IIf(s1.BackColor = golden, Val(s1.Text), 0) + IIf(s2.BackColor = golden, Val(s2.Text), 0) + IIf(s3.BackColor = golden, Val(s3.Text), 0)
        target.firers = IIf(t1.BackColor = golden, Val(t1.Text), 0) + IIf(t2.BackColor = golden, Val(t2.Text), 0) + IIf(t3.BackColor = golden, Val(t3.Text), 0)
        If firer.firers = 0 Then Exit Sub
        If s1.BackColor = golden Then s1.Enabled = False : s1.BackColor = defa
        If s2.BackColor = golden Then s2.Enabled = False : s2.BackColor = defa
        If s3.BackColor = golden Then s3.Enabled = False : s3.BackColor = defa
        If t1.BackColor = golden Then t1.Enabled = False : t1.BackColor = defa
        If t2.BackColor = golden Then t2.Enabled = False : t2.BackColor = defa
        If t3.BackColor = golden Then t3.Enabled = False : t3.BackColor = defa

        If firer.airborne And firer.ordnance And Val(tgt_range.Text) > 1000 Then firer.ordnance = False

        If Me.Tag = "Air Defence" Or target.heli Then target.mode = taltitude.Text
        If firer.indirect And Not firer.has_moved Then oppfire = False
        If oppfire Then
            resolvefire(enemy, firer, ph_units, target, Me.Tag)
        Else
            resolvefire(ph_units, firer, enemy, target, Me.Tag)
        End If
        firer.fires = True
        target.update_after_firing(ph, targetprimary.Text, True)
        If target.strength = 0 Or (target.Aircraft And Not target.airborne) Then
            targets.Items(tn).Remove()
        ElseIf targets.Visible Then
            targets.Items(tn).SubItems(1).Text = target.strength
            targets.Items(tn).BackColor = target.status
            targets.Refresh()
        Else
        End If
        return_fire.Enabled = False
        If (s1.Enabled = False And s2.Enabled = False And s3.Enabled = False) Or firer.strength - firer.firers <= 0 Then Me.Close()
        firer.update_after_firing(ph, firerprimary.Text, False)
        firer_strength(s1, s2, s3, firer.strength - firer.firers)
        firer_strength(t1, t2, t3, target.return_fire_strength(1))
        return_fire_available()

    End Sub

    Private Sub firesmoke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firesmoke.Click
        firer.smoke = gt
        Me.Hide()
        resultform.result.Text = "Smoke Fired"
        resultform.ShowDialog()
        smokefiredthisturn = True
    End Sub

    Private Sub combat_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        taltitude.Visible = False
        altitude.Visible = False
        If firer.fires Then firer.update_after_firing(ph, firerprimary.Text, True)

    End Sub
End Class