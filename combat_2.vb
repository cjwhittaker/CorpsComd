Public Class combat

    Public firer As cunit, target As cunit, combatmode As String, target_fires As Boolean = False, range_not_needed As Boolean
    Private weapon As String, fired_this_turn As Integer = 0
    Dim currentrange As Integer, tn As Integer
    Public Sub enable_controls()
        For Each c As Control In Me.Controls
            c.Enabled = True
            c.Visible = True
            If c.BackColor = golden Then c.BackColor = defa : c.Text = c.Tag
        Next
        tgt_range_select.SelectedIndex = -1
        vis_range_select.SelectedIndex = -1
        tgt_range.Text = tgt_range.Tag
        visrange.Text = visrange.Tag
    End Sub
    Private Sub calc_factors(c As Object)
        If c.Name = "taltitude" And c.Enabled Then
            target.mode = c.Text
        ElseIf InStr(c.Name, "cover") > 0 Then
            If InStr(c.Name, "firer") > 0 Then firer.Cover = Val(c.Text) Else target.Cover = Val(c.Text)
        ElseIf InStr(c.Name, "aspect") > 0 And c.Text = "Front" Then
            If InStr(c.Name, "firer") > 0 Then target.flanked = False : target.rear = False
            If InStr(c.Name, "target") > 0 Then firer.flanked = False : firer.rear = False
        ElseIf InStr(c.Name, "aspect") > 0 And c.Text = "Flank" Then
            If InStr(c.Name, "firer") > 0 Then target.flanked = True Else firer.flanked = True
        ElseIf InStr(c.Name, "aspect") > 0 And c.Text = "Rear" Then
            If InStr(c.Name, "firer") > 0 Then target.rear = True Else firer.rear = True
        ElseIf InStr(c.Name, "elevation") > 0 And c.Text = "Elevated" Then
            If InStr(c.Name, "firer") > 0 Then firer.elevated = True Else target.elevated = True
        ElseIf InStr(c.Name, "elevation") > 0 And c.Text <> "Elevated" Then
            If InStr(c.Name, "firer") > 0 Then firer.elevated = False Else target.elevated = False
        ElseIf InStr(c.Name, "dismounted") > 0 And c.Text = "Dismounted" And c.enabled Then
            If InStr(c.Name, "firer") > 0 Then target.dismounted = True Else firer.dismounted = True
        ElseIf InStr(c.Name, "dismounted") > 0 And (c.Text <> "Dismounted" Or Not c.enabled) Then
            If InStr(c.Name, "firer") > 0 Then target.dismounted = False Else firer.dismounted = False
        ElseIf InStr(c.Name, "mode") > 0 Then
            If InStr(c.Name, "firer") > 0 Then firer.mode = c.Text Else target.mode = c.Text
        ElseIf InStr(c.Name, "roadmove") > 0 And c.Text = "Road Move" Then
            If c.Name = "froadmove" Then firer.roadmove = True Else target.roadmove = True
        ElseIf InStr(c.Name, "roadmove") > 0 And c.Text <> "Road Move" Then
            If c.Name = "froadmove" Then firer.roadmove = False Else target.roadmove = False
        ElseIf InStr(c.Name, "plains") > 0 And c.Text = "Open Terrain" Then
            If c.Name = "fplains" Then firer.plains = False Else target.plains = False
        ElseIf InStr(c.Name, "plains") > 0 And c.Text <> "Open Terrain" Then
            If c.Name = "fplains" Then firer.plains = True Else target.plains = True
        ElseIf InStr(c.Name, "insmoke") > 0 And c.Text = "No Smoke" Then
            If c.Name = "finsmoke" Then firer.insmoke = False Else target.insmoke = False
        ElseIf InStr(c.Name, "insmoke") > 0 And c.Text <> "No Smoke" Then
            If c.Name = "finsmoke" Then firer.insmoke = True Else target.insmoke = True
        ElseIf InStr(c.Name, "fired") > 0 And c.Text = "Not Fired" Then
            If c.Name = "firerfired" Then firer.fired = False Else target.fired = False
        ElseIf InStr(c.Name, "fired") > 0 And c.Text <> "Not Fired" Then
            If c.Name = "firerfired" Then firer.fired = True Else target.fired = True
        ElseIf InStr(c.Name, "moving") > 0 And c.Text = "Static" Then
            If c.Name = "firermoving" Then firer.moved = False Else target.moved = False
        ElseIf InStr(c.Name, "moving") > 0 And c.Text <> "Static" Then
            If c.Name = "firermoving" Then firer.moved = True Else target.moved = True
        ElseIf InStr(c.Name, "fatigued") > 0 And c.Text = "Unfatigued" Then
            If c.Name = "firerfatigued" Then firer.fatigue = 0 Else target.fatigue = 0
        ElseIf InStr(c.Name, "fatigued") > 0 And c.Text = "Fatigued" Then
            If c.Name = "firerfatigued" Then firer.fatigue = -1 Else target.fatigue = -1
        ElseIf InStr(c.Name, "fatigued") > 0 And c.Text = "Exhausted" Then
            If c.Name = "firerfatigued" Then firer.fatigue = -2 Else target.fatigue = -2

        Else
        End If

    End Sub
    Private Sub combat_Load(sender As Object, e As EventArgs) Handles Me.Load

        Randomize(24 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        'test message
        If Me.Tag = "Direct Fire" Then return_fire.Visible = True Else return_fire.Visible = False
        return_fire.Enabled = False
        fire.Enabled = False
        If Me.Tag = "Air Ground" Or Me.Tag = "SEAD" Then
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
        ElseIf Me.Tag = "Air Defence" Then
            target = New cunit
            'selectedtarget.Text = target.title
            targets.Visible = False
            altitude.Visible = True
            taltitude.Visible = True

            For Each c As Control In Panel2.Controls
                If c.Tag = "2" Then c.Enabled = False
            Next
            If combatmode = "Air Defence against CAP Missions" Then
                tgt_range.Enabled = False
                tgt_range_select.Enabled = False
                tgt_range.Text = "30000"
                range_not_needed = True
                With taltitude
                    .Text = "Medium"
                    .BackColor = golden
                    .Enabled = False
                End With
                fire.Enabled = True
            End If

        ElseIf Me.Tag = "CAP" Or Me.Tag = "Intercept" Then
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
            observation(False)
            tgt_range.Enabled = False
            tgt_range_select.Enabled = False
            tgt_range.Text = "0"
            range_not_needed = True
        Else
        End If
        'update_firer_parameters()
        firer.fires = False
    End Sub

    Public Sub observation(enable As Boolean)
        'If enable Then observer.Text = firer.loaded
        'observer.Visible = enable
        visrange.Visible = enable
        vis_range_select.Visible = enable
    End Sub

    Private Sub choose_weapon(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f_wpn.Click, t_wpn.Click
        If Not sender.enabled Then Exit Sub
        'If selectedtarget.Text = "" Then Exit Sub
        If sender.name = "f_wpn" Then
            If firer.w2 = "" Then Exit Sub
            If sender.text = firer.w2 Then sender.text = firer.equipment Else sender.text = firer.w2
        Else
            If target.w2 = "" Then Exit Sub
            If sender.text = target.w2 Then sender.text = target.equipment Else sender.text = target.w2
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub select_altitude(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taltitude.Click
        If target.title Is Nothing Then Exit Sub
        If target.equipment = "" Then Exit Sub
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

    End Sub

    Private Sub select_cover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firercover.Click, targetcover.Click
        Dim cover As Object
        If sender.name = "targetcover" And target.title Is Nothing Then Exit Sub
        If sender.name = "firercover" And firer.title Is Nothing Then Exit Sub
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
        If sender.name = "firercover" Then firer.Cover = IIf(cover.text = "None", 0, cover.text) Else target.Cover = IIf(cover.text = "None", 0, cover.text)

        eligible_to_fire(sender)

    End Sub

    Private Sub Flank_and_rear(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fireraspect.Click, targetaspect.Click
        If sender.name = "targetaspect" And target.title Is Nothing Then Exit Sub
        If sender.name = "fireraspect" And firer.title Is Nothing Then Exit Sub
        If sender.text = "Front" Then
            sender.text = "Flank"
            sender.backcolor = golden
            If sender.name = "firerelevation" Then
                firer.flanked = True
                firer.rear = False
            Else
                target.flanked = True
                target.rear = False
            End If
        ElseIf sender.text = "Flank" Then
            sender.text = "Rear"
            If sender.name = "firerelevation" Then
                firer.flanked = False
                firer.rear = True
            Else
                target.flanked = False
                target.rear = True
            End If
        Else
            sender.text = "Front"
            sender.backcolor = defa
            If sender.name = "firerelevation" Then
                firer.flanked = False
                firer.rear = True
            Else
                target.flanked = False
                target.rear = True
            End If

        End If
        eligible_to_fire(sender)

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
        If Strings.Left(f1.name, 1) = "s" Or Me.Tag = "CAP" Or Me.Tag = "Intercept" Then
            f1.BackColor = golden
        End If
    End Sub
    Private Sub update_parameters(opt As String)
        If opt = "firers" Then
            For Each c As Control In Panel1.Controls
                If c.BackColor = golden And c.Tag <> "" Then c.BackColor = defa : c.Text = c.Tag
            Next
            If firer.Cover > 0 Then select_cover(firercover, Nothing)
            If firer.elevated Then elevation(firerelevation, Nothing)
            If firer.roadmove Then roadmove(froadmove, Nothing)
            If firer.plains Then plains(fplains, Nothing)
            If firer.insmoke Then in_smoke(finsmoke, Nothing)
            If gt - firer.moved <= 1 Then firer.moving = True Else firer.moving = False
            If firer.moving Then moved(firermoving, Nothing)
            If firer.mode <> conc Then mode(firermode, Nothing)
            f_wpn.Text = firer.equipment
            If firer.w2 = "" Then f_wpn.Enabled = False Else f_wpn.Enabled = True
            If firer.troopcarrier And firer.embussed Then firerdismounted.Enabled = True Else firerdismounted.Enabled = False
            If firer.Inf And firer.loaded = "" Then
                With firerdismounted
                    .Enabled = True
                    .Text = "Mount"
                    .BackColor = golden
                End With
            End If
        Else

            For Each c As Control In Panel2.Controls
                If c.BackColor = golden Then c.BackColor = defa : c.Text = c.Tag
            Next
            If target.Cover > 0 Then select_cover(targetcover, Nothing)
            If target.elevated Then elevation(targetelevation, Nothing)
            If target.roadmove Then roadmove(troadmove, Nothing)
            If target.plains Then plains(tplains, Nothing)
            If target.insmoke Then in_smoke(tinsmoke, Nothing)
            If gt - target.moved <= 1 Then target.moving = True Else target.moving = False
            If target.moving Then moved(targetmoving, Nothing)
            If target.mode <> conc Then mode(targetmode, Nothing)
            t_wpn.Text = target.equipment
            If target.w2 = "" Then t_wpn.Enabled = False Else t_wpn.Enabled = True
            If Not target.troopcarrier Then targetdismounted.Enabled = False Else targetdismounted.Enabled = True
        End If
    End Sub

    Private Sub Select_units(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles targets.Click, firers.Click
        If sender.name = "targets" Then
            target = orbat(sender.FocusedItem.Text)
            firer_strength(t1, t2, t3, target.strength)
        Else
            'With firer
            '    .equipment = sender.FocusedItem.Text
            '    .secondary = sender.FocusedItem.SubItems(1).Text
            '    .fires = False
            '    .dismounted = False
            'End With
            firer = orbat(sender.FocusedItem.Text)
            'If Not firer.conc Then firer.mode = disp : firermode.Text = disp : firermode.BackColor = golden Else firer.mode = conc
            'With firerdismounted
            '    .BackColor = defa
            '    .Text = .Tag
            '    .Enabled = firer.Inf
            'End With
            firer_strength(s1, s2, s3, firer.strength)
        End If
        update_parameters(sender.name)
        If sender.name = "targets" Then eligible_to_fire(sender)

        'If target.airborne And target.task = "SEAD" And Not firer.airborne Then
        '    taltitude.Enabled = True
        '    return_fire.Enabled = True
        'ElseIf target.airborne And Not firer.airborne Then
        '    taltitude.Enabled = True
        'ElseIf target.airborne And target.fired <> corpscommander.phase And firer.airborne Then
        '    return_fire.Enabled = True
        'Else
        '    If target.elevated Then elevation(targetelevation, Nothing)
        '    If target.roadmove Then roadmove(troadmove, Nothing)
        '    If target.plains Then plains(tplains, Nothing)
        '    If target.Cover > 0 Then
        '        targetcover.Text = "+" + Trim(Str(target.Cover))
        '        targetcover.BackColor = golden
        '    Else
        '        targetcover.Text = "None"
        '        targetcover.BackColor = defa
        '    End If
        '    For Each c As Control In Panel2.Controls
        '        If c.Tag = "2" Then c.Enabled = True
        '    Next
        '    fireraspect.Enabled = True
        'End If
        'return_fire_available()
    End Sub

    Private Sub elevation(sender As Object, e As EventArgs) Handles firerelevation.Click, targetelevation.Click
        If sender.name = "targetelevation" Then If target.title Is Nothing Then Exit Sub
        If sender.name = "firerelevation" Then If firer.title Is Nothing Then Exit Sub
        If sender.backcolor = defa Then
            sender.text = "Elevated"
            sender.backcolor = golden
            If sender.name = "firerelevation" Then firer.elevated = True Else target.elevated = True
        Else
            sender.text = "Same Level"
            sender.backcolor = defa
            If sender.name = "firerelevation" Then firer.elevated = False Else target.elevated = False
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub dismounted(sender As Object, e As EventArgs) Handles firerdismounted.Click, targetdismounted.Click
        If sender.name = "targetdismounted" Then
            If target.title Is Nothing Then Exit Sub
            If (sender.backcolor = golden And Not target.Inf) Then Exit Sub
        Else
            If firer.title Is Nothing Then Exit Sub
            If (sender.backcolor = golden And Not firer.Inf) Then Exit Sub
        End If

        Dim tmp As String = ""
        If sender.backcolor = defa Then
            sender.text = "Mount"
            sender.backcolor = golden
            If sender.name = "firerdismounted" Then
                tmp = firer.loaded
                firer.loaded = ""
                orbat(tmp).loaded = ""
                orbat(tmp).mode = firer.mode
                populate_lists(firers, orbat, "Direct Fire", firer.nation)
            Else
                tmp = target.loaded
                target.loaded = ""
                orbat(tmp).loaded = ""
                orbat(tmp).mode = target.mode
                populate_lists(targets, orbat, "Direct Fire", target.nation)
            End If
        Else
            sender.text = "Dismount"
            sender.backcolor = defa
            If sender.name = "firerdismounted" Then
                tmp = Replace(firer.title, "#", "")
                firer.loaded = tmp
                orbat(tmp).loaded = firer.title
                orbat(tmp).mode = firer.mode
                firers.FocusedItem.Remove()
            Else
                tmp = Replace(target.title, "#", "")
                target.loaded = tmp
                orbat(tmp).loaded = target.title
                orbat(tmp).mode = target.mode
                targets.FocusedItem.Remove()
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub mode(sender As Object, e As EventArgs) Handles firermode.Click, targetmode.Click
        If sender.name = "targetmode" And target.title Is Nothing Then Exit Sub
        If sender.name = "firermode" And firer.title Is Nothing Then Exit Sub

        If sender.text = conc Then
            sender.text = disp
            sender.backcolor = golden
        ElseIf sender.text = disp Then
            sender.text = travel
        ElseIf sender.text = travel Then
            sender.text = conc
            sender.backcolor = defa
        Else
        End If
        If sender.name = "firermode" Then
            firer.mode = sender.text
            If Not firer.conc And firer.mode = conc Then
                firer.mode = disp
                sender.Text = disp
                sender.BackColor = golden
            End If
        End If
        If sender.name = "targetmode" Then
            target.mode = sender.text
            If Not target.conc And target.mode = conc Then
                target.mode = disp
                sender.Text = disp
                sender.BackColor = golden
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub roadmove(sender As Object, e As EventArgs) Handles troadmove.Click, froadmove.Click
        If sender.name = "troadmove" Then If target.title Is Nothing Then Exit Sub
        If sender.name = "froadmove" Then If firer.title Is Nothing Then Exit Sub
        If sender.backcolor = defa Then
            sender.text = "Road Move"
            sender.backcolor = golden
            If sender.name = "froadmove" Then firer.roadmove = True Else target.roadmove = True
        Else
            sender.text = "X Country"
            sender.backcolor = defa
            If sender.name = "troadmove" Then firer.roadmove = True Else target.roadmove = True
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub plains(sender As Object, e As EventArgs) Handles tplains.Click, fplains.Click
        If sender.name = "tplains" Then If target.title Is Nothing Then Exit Sub
        If sender.name = "fplains" Then If firer.title Is Nothing Then Exit Sub
        If sender.backcolor = defa Then
            sender.text = "Plains/Steppes"
            sender.backcolor = golden
            If sender.name = "fplains" Then firer.plains = True Else target.plains = True
        Else
            sender.text = "Open Terrain"
            sender.backcolor = defa
            If sender.name = "tplains" Then firer.plains = True Else target.plains = True
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub in_smoke(sender As Object, e As EventArgs) Handles finsmoke.Click, tinsmoke.Click
        If sender.name = "tinsmoke" Then If target.title Is Nothing Then Exit Sub
        If sender.name = "finsmoke" Then If firer.title Is Nothing Then Exit Sub
        If sender.backcolor = defa Then
            sender.text = "In Smoke"
            sender.backcolor = golden
            If sender.name = "finsmoke" Then firer.insmoke = True Else target.insmoke = True
        Else
            sender.text = "No Smoke"
            sender.backcolor = defa
            If sender.name = "tinsmoke" Then firer.insmoke = True Else target.insmoke = True
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub abort_target_Click(sender As Object, e As EventArgs) Handles abort_target.Click
        firer.firers = 0 : target.firers = 0
        abort_firer.Visible = False
        abort_target.Visible = False
        If sender.name = "abort_targets" Then
            targets.Items(tn).Remove()
            target.lands(False)
            If targets.Items.Count = 0 Then Me.Close()
        Else
            firer.lands(False)
            Me.Close()
        End If
    End Sub

    'Private Sub reset_mode(sender As Object, e As EventArgs)
    '    If sender.name = "selectedtarget" Then
    '        If (target.mode = disp And target.not_conc) Or target.mode = conc Then
    '            targetmode.Text = travel
    '            target.mode = travel
    '        ElseIf target.mode = travel Then
    '            targetmode.Text = disp
    '            target.mode = disp
    '        ElseIf target.mode = disp And Not target.not_conc Then
    '            targetmode.Text = conc
    '            target.mode = conc
    '        End If
    '    Else
    '        If (firer.mode = disp And firer.not_conc) Or firer.mode = conc Then
    '            firermode.Text = travel
    '            firer.mode = travel
    '        ElseIf firer.mode = travel Then
    '            firermode.Text = disp
    '            firer.mode = disp
    '        ElseIf firer.mode = disp And Not firer.not_conc Then
    '            firermode.Text = conc
    '            firer.mode = conc
    '        End If
    '    End If
    '    eligible_to_fire()
    'End Sub


    Private Sub return_fire_Click(sender As Object, e As EventArgs) Handles return_fire.Click
        If sender.backcolor = defa Then
            sender.backcolor = golden
        Else
            sender.backcolor = defa
        End If
    End Sub

    Private Sub moved(sender As Object, e As EventArgs) Handles firermoving.Click, targetmoving.Click
        If sender.name = "targetmoving" Then If target.title Is Nothing Then Exit Sub
        If sender.name = "firermoving" Then If firer.title Is Nothing Then Exit Sub

        If sender.backcolor = defa Then
            sender.text = "Moved"
            sender.backcolor = golden
            If sender.name = "firermoving" Then firer.moving = True Else target.moving = True
        Else
            sender.text = "Static"
            sender.backcolor = defa
            If sender.name = "firermoving" Then firer.moving = True Else target.moving = True
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub return_fire_available()
        If Me.Tag <> "Direct Fire" Then
            return_fire.BackColor = defa
            return_fire.Enabled = False
            Exit Sub
        End If
        Dim rge As Integer = Val(tgt_range_select.SelectedItem)
        Dim rf As Boolean = IIf(return_fire.BackColor = golden, True, False)
        return_fire.BackColor = defa
        'reset_target_strength()
        If firer.title Is Nothing Or target.title Is Nothing Then Exit Sub
        If range_not_needed Or tgt_range_select.SelectedIndex = -1 Then Exit Sub
        If target.secondary <> "" Then
            If rge > eq_list(target.secondary).maxrange Then Exit Sub
        Else
            If rge > eq_list(target.equipment).maxrange Then Exit Sub
        End If
        If spotting(rge, target, firer) Then
            If rf Then return_fire.BackColor = golden
            return_fire.Enabled = True
        End If
    End Sub

    Private Sub firingmode_Click(sender As Object, e As EventArgs)
        If firingmode.BackColor = defa Then
            firingmode.Text = "Half Fire"
            firingmode.BackColor = golden
            firer.moving = True
            With firermoving
                .Enabled = False
                .BackColor = golden
                .Text = "Moving"
            End With
        ElseIf firingmode.Text = "Half Fire" Then
            firingmode.Text = "Opportunity Fire"
            firingmode.BackColor = golden
            firer.moving = False
            oppfire = True
            With firermoving
                .Enabled = True
                .BackColor = defa
                .Text = "Static"
            End With
        ElseIf firingmode.Text = "Opportunity Fire" Then
            oppfire = False
            firingmode.BackColor = defa
            firingmode.Text = "Direct Fire"
        Else
        End If
        If firingmode.BackColor = golden Then return_fire.Enabled = False : return_fire.BackColor = defa
    End Sub

    Private Sub fatigue(sender As Object, e As EventArgs)
        If sender.BackColor = defa Then
            sender.Text = "Fatigued"
            sender.BackColor = golden
        ElseIf sender.Text = "Fatigued" Then
            sender.Text = "Exhausted"
            sender.BackColor = golden
        ElseIf sender.Text = "Exhausted" Then
            sender.BackColor = defa
            sender.Text = "Unfatigued"
        Else
        End If
    End Sub

    Private Sub rangechange(sender As Object, e As EventArgs) Handles tgt_range_select.SelectedIndexChanged, vis_range_select.SelectedIndexChanged
        eligible_to_fire(sender)
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

    Private Sub eligible_to_fire(sender As Object)
        If firingmode.Text = "Direct Fire" Or Me.Tag = "Indirect Fire" Then return_fire.Enabled = False
        fire.Enabled = False
        firesmoke.Enabled = False
        firesmoke.Visible = False
        If target.title Is Nothing Then Exit Sub
        calc_factors(sender)
        return_fire_available()

        If Me.Tag = "Indirect Fire" Then
            firesmoke.Visible = True
            firesmoke.Enabled = True
        End If
        If Not range_not_needed And tgt_range_select.SelectedIndex = -1 Then Exit Sub
        firer.spotted = False
        firer.task = ""
        target.spotted = False
        If range_not_needed Then
            firer.spotted = True
            target.spotted = True
            fire.Enabled = True
            Exit Sub
        End If
        tgt_range.Text = tgt_range_select.SelectedItem
        Dim rge As Integer = Val(tgt_range.Text), out_of_range As Boolean = False
        If rge > eq_list(firer.equipment).maxrange Then out_of_range = True

        If out_of_range Then
            fire.Enabled = False
            target.spotted = fire.Enabled
            tgt_range.ForeColor = Color.Red
            Exit Sub
        End If
        If Me.Tag = "Direct Fire" Then
            fire.Enabled = spotting(Val(tgt_range.Text), firer, target)
            target.spotted = fire.Enabled
            If target.spotted Then tgt_range.ForeColor = Color.Green Else tgt_range.ForeColor = Color.Red

        ElseIf Me.Tag = "Air Defence" Or (firer.sead And target.eligibleCB And target.airdefence) Then
            fire.Enabled = True
            target.spotted = True
            tgt_range.ForeColor = Color.Green

        ElseIf Me.Tag = "Indirect Fire" Then
            Dim tmp As String = ""
            visrange.Text = vis_range_select.SelectedItem
            Dim observed As Boolean, identified As Boolean, unobserved As Boolean
            identified = spotting(Val(tgt_range.Text), firer, target)
            'If observer.Text <> "Observer" Then
            observed = spotting(Val(visrange.Text), firer, target)
            firer.task = "FFE"
            unobserved = spotting(Val(visrange.Text), firer, target)
            firer.task = ""
            target.spotted = False
            'Else
            '    observed = False
            'End If
            If identified Then tgt_range.ForeColor = Color.Green Else tgt_range.ForeColor = Color.Red
            If observed Then visrange.ForeColor = Color.Green Else visrange.ForeColor = Color.Red
            If Not observed And Not identified And unobserved Then visrange.ForeColor = Color.Blue
            fire.Enabled = observed Or identified Or unobserved
            target.spotted = fire.Enabled
            'If (firer.task = "IN" Or firer.task = "AF") And observer.Text <> "Observer" Then orbat(observer.Text).task = tmp
            If firer.task = "CB" And Not observed Then
                With resultform_2
                    .result.Text = "Failed to locate " + target.equipment
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
        'If selectedtarget.Text = "" Then Exit Sub
        'firer.firers = 0 : target.firers = 0
        'firer.firers = IIf(s1.BackColor = golden, Val(s1.Text), 0) + IIf(s2.BackColor = golden, Val(s2.Text), 0) + IIf(s3.BackColor = golden, Val(s3.Text), 0)
        'fired_this_turn = fired_this_turn + firer.firers
        'target.firers = IIf(t1.BackColor = golden, Val(t1.Text), 0) + IIf(t2.BackColor = golden, Val(t2.Text), 0) + IIf(t3.BackColor = golden, Val(t3.Text), 0)
        If firer.firers = 0 Then Exit Sub
        'If s1.BackColor = golden Then s1.Enabled = False : s1.BackColor = defa
        'If s2.BackColor = golden Then s2.Enabled = False : s2.BackColor = defa
        'If s3.BackColor = golden Then s3.Enabled = False : s3.BackColor = defa
        'If t1.BackColor = golden Then t1.Enabled = False : t1.BackColor = defa
        'If t2.BackColor = golden Then t2.Enabled = False : t2.BackColor = defa
        'If t3.BackColor = golden Then t3.Enabled = False : t3.BackColor = defa

        If firer.airborne And firer.ordnance And Val(tgt_range.Text) > 1000 Then firer.ordnance = False

        If Me.Tag = "Air Defence" Or target.heli Then target.mode = taltitude.Text
        'If firer.indirect And Not firer.has_moved Then oppfire = False
        resolvefire(firer, target, Me.Tag)
        return_fire.BackColor = defa
        'target = New cunit
        'Select_units(targets, Nothing)
        'firer = New cunit
        'Select_units(firers, Nothing)
        'firer.fires = True
        'target.update_after_firing(ph, targetprimary.Text, True)
        'If target.strength = 0 Or (target.aircraft And Not target.airborne) Or Me.Tag = "CAP" Then
        '    targets.Items(tn).Remove()
        'ElseIf target.airborne And Me.Tag = "Intercept" And target.fires Then
        '    targets.Items(tn).Remove()
        '    target.lands(False)
        'ElseIf targets.Visible Then
        '    targets.Items(tn).SubItems(1).Text = IIf(target.aircraft, target.strength - target.aborts, target.strength)
        '    targets.Items(tn).BackColor = target.status(Me.Name)
        '    targets.Refresh()
        'Else
        'End If
        'If (s1.Enabled = False And s2.Enabled = False And s3.Enabled = False) Or IIf(firer.airborne, firer.strength - firer.aborts - fired_this_turn, firer.strength - fired_this_turn) <= 0 Then
        '    Me.Close()
        'Else
        '    firer.update_after_firing(ph, firerprimary.Text, False)
        '    'firer_strength(s1, s2, s3, IIf(firer.airborne, firer.strength - firer.aborts - fired_this_turn, firer.strength - fired_this_turn))
        '    'firer_strength(t1, t2, t3, target.return_fire_strength(1))
        '    return_fire_available()
        'End If
    End Sub

    Private Sub firesmoke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firesmoke.Click
        firer.smoke = gt
        Me.Hide()
        resultform_2.result.Text = "Smoke Fired"
        resultform_2.ShowDialog()
        smokefiredthisturn = True
    End Sub

    Private Sub combat_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        taltitude.Visible = False
        altitude.Visible = False
        'If firer.fires Then firer.update_after_firing(ph, firerprimary.Text, True)

    End Sub
    Public Sub reset_target_strength()
        t1.BackColor = defa
        t2.BackColor = defa
        t3.BackColor = defa
        t1.Enabled = False
        t2.Enabled = False
        t3.Enabled = False
        return_fire.Enabled = False
    End Sub


End Class