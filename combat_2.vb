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

    'Private Sub choose_weapon(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firerprimary.Click, targetprimary.Click, targetmode.Click
    '    If Not sender.enabled Then Exit Sub
    '    'If selectedtarget.Text = "" Then Exit Sub
    '    If sender.name = "firerprimary" Then
    '        If firer.w2 = "" Then Exit Sub
    '        If weapon = firer.w2 Then weapon = firer.equipment Else weapon = firer.w2
    '        firerprimary.Text = weapon
    '    Else
    '        If target.w2 = "" Then Exit Sub
    '        If weapon = target.w2 Then weapon = target.equipment Else weapon = target.w2
    '        targetprimary.Text = weapon
    '    End If

    'End Sub

    Private Sub select_altitude(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taltitude.Click
        If target Is Nothing Then Exit Sub
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
        If sender.name = "targetcover" Then
            If target Is Nothing Then Exit Sub
            If target.equipment = "" Then Exit Sub
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
        eligible_to_fire(sender)

    End Sub

    Private Sub Flank_and_rear(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fireraspect.Click, targetaspect.Click
        If sender.name = "targetaspect" Then
            If target Is Nothing And target.equipment = "" Then Exit Sub
        End If
        If sender.text = "Front" Then
            sender.text = "Flank"
            sender.backcolor = golden
        ElseIf sender.text = "Flank" Then
            sender.text = "Rear"
        Else
            sender.text = "Front"
            sender.backcolor = defa
        End If

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
    Private Sub update_parameters(opt As Object)
        If opt.name = "firers" Then
            If (firer.elevated And firerelevation.BackColor = defa) Or (Not firer.elevated And firerelevation.BackColor = golden) Then elevation(firerelevation, Nothing)
            If (firer.roadmove And froadmove.BackColor = defa) Or (Not firer.roadmove And froadmove.BackColor = golden) Then roadmove(froadmove, Nothing)
            If (firer.plains And fplains.BackColor = defa) Or (Not firer.plains And fplains.BackColor = golden) Then plains(fplains, Nothing)
            If finsmoke.BackColor = defa Then in_smoke(finsmoke, Nothing)
            firermode.Text = firer.mode
            If firer.mode <> conc Then firermode.BackColor = golden Else firermode.BackColor = defa
            If firer.Cover > 0 Then
                firercover.Text = "+" + Trim(Str(firer.Cover))
                firercover.BackColor = golden
            Else
                firercover.Text = "None"
                firercover.BackColor = defa
            End If

        End If
    End Sub

    Private Sub Select_units(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles targets.Click, firers.Click
        If sender.name = "targets" Then
            With target
                .equipment = sender.FocusedItem.Text
                .secondary = sender.FocusedItem.SubItems(1).Text
                .fires = False
                .dismounted = False
            End With
            With targetdismounted
                .BackColor = defa
                .Text = .Tag
                .Enabled = target.Inf
            End With
            If Not target.conc Then target.mode = disp : targetmode.Text = disp : targetmode.BackColor = golden Else target.mode = conc
            firer_strength(t1, t2, t3, target.strength)
        Else
            With firer
                .equipment = sender.FocusedItem.Text
                .secondary = sender.FocusedItem.SubItems(1).Text
                .fires = False
                .dismounted = False
            End With
            If Not firer.conc Then firer.mode = disp : firermode.Text = disp : firermode.BackColor = golden Else firer.mode = conc
            With firerdismounted
                .BackColor = defa
                .Text = .Tag
                .Enabled = firer.Inf
            End With
            firer_strength(s1, s2, s3, firer.strength)
        End If
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
        If sender.name = "targetelevation" Then
            If target Is Nothing And target.equipment = "" Then Exit Sub
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
        eligible_to_fire(sender)

    End Sub

    Private Sub dismounted(sender As Object, e As EventArgs) Handles firerdismounted.Click, targetdismounted.Click
        If sender.name = "targetdismounted" Then
            If target Is Nothing Then Exit Sub
            If target.equipment = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "Mounted"
            sender.backcolor = golden
        Else
            sender.text = "Dismounted"
            sender.backcolor = defa
        End If

    End Sub

    Private Sub mode(sender As Object, e As EventArgs) Handles firermode.Click, targetmode.Click
        If sender.name = "targetmode" And target.equipment Is Nothing Then Exit Sub
        If sender.name = "firermode" And firer.equipment Is Nothing Then Exit Sub

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
        If InStr(sender.Name, "firer") > 0 And Not firer.conc And firer.mode <> disp Then firer.mode = disp : sender.Text = disp : sender.BackColor = golden
        If InStr(sender.Name, "target") > 0 And Not target.conc And target.mode = conc Then target.mode = disp : sender.Text = disp : sender.BackColor = golden
        eligible_to_fire(sender)

    End Sub

    Private Sub roadmove(sender As Object, e As EventArgs) Handles troadmove.Click, froadmove.Click
        If sender.name = "troadmove" Then
            If target Is Nothing Then Exit Sub
            If target.equipment = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "Road Move"
            sender.backcolor = golden
        Else
            sender.text = "X Country"
            sender.backcolor = defa
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub plains(sender As Object, e As EventArgs) Handles tplains.Click, fplains.Click
        If sender.name = "tplains" Then
            If target Is Nothing Then Exit Sub
            If target.equipment = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "Plains/Steppes"
            sender.backcolor = golden
        Else
            sender.text = "Open Terrain"
            sender.backcolor = defa
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub in_smoke(sender As Object, e As EventArgs) Handles finsmoke.Click, tinsmoke.Click
        If sender.name = "tinsmoke" Then
            If target Is Nothing Then Exit Sub
            If target.equipment = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "In Smoke"
            sender.backcolor = golden
        Else
            sender.text = "No Smoke"
            sender.backcolor = defa
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
        If sender.name = "targetmoving" Then
            If target Is Nothing Then Exit Sub
            If target.equipment = "" Then Exit Sub
        End If
        If sender.backcolor = defa Then
            sender.text = "Moved"
            sender.backcolor = golden
        Else
            sender.text = "Static"
            sender.backcolor = defa
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub return_fire_available()
        If firingmode.BackColor = golden Or Me.Tag = "Indirect Fire" Then
            return_fire.BackColor = defa
            return_fire.Enabled = False
            Exit Sub
        End If
        Dim rge As Integer = Val(tgt_range_select.SelectedItem)
        Dim rf As Boolean = IIf(return_fire.BackColor = golden, True, False)
        return_fire.BackColor = defa
        'reset_target_strength()
        If firer.equipment Is Nothing Or target.equipment Is Nothing Then Exit Sub
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

    Private Sub firingmode_Click(sender As Object, e As EventArgs) Handles firingmode.Click
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
        If firingmode.BackColor = defa Or Me.Tag = "Indirect Fire" Then return_fire.Enabled = False
        fire.Enabled = False
        firesmoke.Enabled = False
        firesmoke.Visible = False
        If target.equipment Is Nothing Or target.equipment = "" Then Exit Sub
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
                With resultform
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
        resultform.result.Text = "Smoke Fired"
        resultform.ShowDialog()
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