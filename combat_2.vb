﻿Public Class combat_2

    Public firer As cunit, target As cunit, observer As cunit, combatmode As String, target_fires As Boolean = False, range_not_needed As Boolean, ac_firer As cunit
    Public weapon As String, fired_this_turn As Integer = 0, nt As Integer, nf As Integer, no As Integer, interceptor As String, area_fire As Boolean
    Dim currentrange As Integer, tn As Integer, a2g_target As cunit, a2g_range As String
    Public Sub enable_controls(groundfire As Boolean, panel As Object)
        Dim gf As Boolean = False, af As Boolean = False
        For Each c As Control In panel.controls
            If Mid(c.Name, 2, 1) = "_" Then gf = True Else gf = False
            If Mid(c.Name, 3, 1) = "_" Then af = True Else af = False
            'If groundfire Then
            If gf And TypeOf c Is Label Then
                With c
                    .Enabled = groundfire
                    .Visible = groundfire
                End With
            ElseIf af And TypeOf c Is Label Then
                With c
                    .Enabled = Not groundfire
                    .Visible = Not groundfire
                End With
            Else
            End If
            'Else
            'End If
            If c.BackColor = golden Then c.BackColor = defa : c.Text = c.Tag
            reset_range()
        Next
    End Sub
    Private Sub combat_Load(sender As Object, e As EventArgs) Handles Me.Load

        Randomize(24 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        'test message
        'return_fire.Enabled = False
        fire.Enabled = False
        'directfirepanel.Visible = True
        If Tag = "Direct Fire" Or Tag = "Air to Air" Then return_fire.Visible = True Else return_fire.Visible = False
        If Tag = "Smoke Barrage" Then
            'For Each c As Control In directfirepanel.Controls
            '    If TypeOf c Is Label Then c.Enabled = False
            'Next
            'For Each c As Control In Panel2.Controls
            '    c.Enabled = False
            'Next
            firesmoke.Enabled = False
            fire.Visible = False
            return_fire.Visible = False
            range_not_needed = True
        End If
        If Tag = "Indirect Fire" Then
            fire.Visible = True
        End If
        If Tag = "Direct Fire" Or Tag = "Opportunity Fire" Then
            obs_chart.Show()
            directfirepanel.Visible = True
            indirectfirepanel.Visible = False
        End If
        If Tag = "Opportunity Fire" Then swap.Visible = False
        If Me.Tag = "Air Ground" Or Me.Tag = "SEAD" Then
            targets.Visible = True
            f_aspect.Enabled = True
            f_cover.Enabled = False
            f_plains.Enabled = False
            f_cover.Enabled = False
            f_roadmove.Enabled = False
            f_insmoke.Enabled = False
            t_plains.Enabled = True
            t_cover.Enabled = True
            t_roadmove.Enabled = True
        ElseIf Me.Tag = "Air Defence" Then
            target = New cunit
            'selectedtarget.Text = target.title
            targets.Visible = False
            ta_altitude_label.Visible = True
            ta_altitude.Visible = True

            For Each c As Control In targetpanel.Controls
                If c.Tag = "2" Then c.Enabled = False
            Next
            If combatmode = "Air Defence against CAP Missions" Then
                tgt_range.Enabled = False
                tgt_range_select.Enabled = False
                tgt_range.Text = "30000"
                range_not_needed = True
                With ta_altitude
                    .Text = "Medium"
                    .BackColor = golden
                    .Enabled = False
                End With
                fire.Enabled = True
            End If

        ElseIf Me.Tag = "CAP" Or Me.Tag = "Intercept" Then
            targets.Visible = True
            f_aspect.Enabled = False
            f_cover.Enabled = False
            f_insmoke.Enabled = False
            f_plains.Enabled = False
            f_roadmove.Enabled = False
            f_elevation.Enabled = False
            ta_altitude_label.Visible = True
            ta_altitude.Visible = True
            ta_altitude.Enabled = True
            observation(False)
            tgt_range.Enabled = False
            tgt_range_select.Enabled = False
            tgt_range.Text = "0"
            range_not_needed = True
        Else
        End If
        'update_firer_parameters()
        'firer.fires = False
    End Sub

    Public Sub observation(enable As Boolean)
        'If enable Then observer.Text = firer.carrying
        'observer.Visible = enable
        visrange.Visible = enable
        vis_range_select.Visible = enable
        For Each c As Control In indirectfirepanel.Controls
            If Strings.Left(c.Name, 4) = "obs_" Then c.Enabled = enable
        Next
    End Sub

    Private Sub choose_weapon(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fwpn.Click, twpn.Click
        If Tag = "Smoke Barrage" Then Exit Sub
        Dim t As String = ""
        'If selectedtarget.Text = "" Then Exit Sub
        If sender.name = "fwpn" Then
            If firer.w2 = "" Or firers.Items.Count = 0 Then Exit Sub
            If firer.helarm Then
                t = firer.helarm_select_wpn(sender.text)
                If t = sender.text Then firer.secondary = t : sender.enabled = False : Exit Sub
                sender.text = t
                firer.secondary = sender.text
            ElseIf sender.text = firer.w2 Then
                sender.text = firer.equipment
                firer.secondary = ""
            Else
                sender.text = firer.w2
                firer.secondary = sender.text
            End If
        Else
            If target.w2 = "" Or targets.Items.Count = 0 Then Exit Sub
            If target.helarm Then
                t = target.helarm_select_wpn(sender.text)
                If t = sender.text Then target.secondary = t : sender.enabled = False : Exit Sub
                sender.text = t
                target.secondary = sender.text
            ElseIf sender.text = target.w2 Then
                sender.text = target.equipment
                target.secondary = ""
            Else
                sender.text = target.w2
                target.secondary = sender.text
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub select_altitude(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ta_altitude.Click, fa_altitude.Click
        If sender.name = "ta_altitude" Then If target.title Is Nothing Or targets.Items.Count = 0 Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "fa_altitude" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
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
        If sender.name = "fa_altitude" Then
            firer.mode = sender.text
        Else
            target.mode = sender.text
        End If
        eligible_to_fire(firer)
    End Sub

    Private Sub select_cover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f_cover.Click, t_cover.Click
        Dim cover As Object
        If sender.name = "t_cover" Then If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "f_cover" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.name = "f_cover" Then cover = f_cover Else cover = t_cover
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
        If sender.name = "f_cover" Then firer.Cover = IIf(cover.text = "None", 0, cover.text) Else target.Cover = IIf(cover.text = "None", 0, cover.text)

        eligible_to_fire(sender)

    End Sub

    Private Sub Flank_and_rear(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles f_aspect.Click, t_aspect.Click
        If sender.name = "t_aspect" And target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "f_aspect" And firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.text = "Front" Then
            sender.text = "Flank"
            sender.backcolor = golden
            If sender.name = "f_aspect" Then
                firer.flanked = True
                firer.rear = False
            Else
                target.flanked = True
                target.rear = False
            End If
        ElseIf sender.text = "Flank" Then
            sender.text = "Rear"
            If sender.name = "t_aspect" Then
                firer.flanked = False
                firer.rear = True
            Else
                target.flanked = False
                target.rear = True
            End If
        Else
            sender.text = "Front"
            sender.backcolor = defa
            If sender.name = "f_aspect" Then
                firer.flanked = False
                firer.rear = False
            Else
                target.flanked = False
                target.rear = False
            End If

        End If
        eligible_to_fire(sender)

    End Sub

    Public Sub firer_strength(f1 As Object, f2 As Object, f3 As Object, strength As Integer, airunit As Boolean)
        reset_strength(f1, f2, f3)
        If strength <= 0 Then
            f1.Enabled = False
            f2.Enabled = False
            f3.Enabled = False
            Exit Sub
        ElseIf strength <= 5 Or Tag = "Indirect Fire" Or airunit Then
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
        Dim air_strength As Integer = 0, arty_strength As Integer = strength
        If airunit Then air_strength = strength : strength = 5
        If Tag = "Ground to Air" And (Not firer.missile_armed Or (firer.missile_armed And firer.missiles > 0)) Then firer.firers_available = firer.strength : strength = firer.firers_available
        If Tag = "Indirect Fire" Then strength = -1

        Select Case strength
            Case -1
                f1.Text = arty_strength : f2.Text = "" : f3.Text = ""
            Case 1, 2, 3, 4, 5
                f1.Text = IIf(airunit, air_strength, strength) : f2.Text = "" : f3.Text = ""
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
        If Tag = "Air to Air" Or Tag = "Air to Ground" Then
            select_strength_firing(f1, Nothing)
        ElseIf Strings.Left(f1.name, 1) = "s" Then
            firer.firers = 0
            select_strength_firing(s1, Nothing)
        ElseIf Strings.Left(f1.name, 1) = "t" Then
            target.firers = 0
        ElseIf Tag = "Smoke Barrage" Then
            f1.Enabled = False
            f2.Enabled = False
            f3.Enabled = False
        Else
        End If
    End Sub

    Private Sub select_strength_firing(sender As Object, e As EventArgs) Handles s1.Click, s2.Click, s3.Click, t3.Click, t2.Click, t1.Click, a1.Click, a2.Click, a3.Click
        Dim m As String = Strings.Left(sender.name, 1)
        If ((Not return_fire.Visible And m = "t") Or sender.text = "" Or (m = "t" And Not fire.Enabled)) And Tag <> "Air to Air" And Tag <> "Air to Ground" Then Exit Sub
        Dim f As Boolean = IIf(m = "s" Or m = "a", True, False)
        If sender.backcolor = defa Then
            sender.backcolor = golden
        Else
            sender.backcolor = defa
        End If
        If m = "t" Then If t1.BackColor = defa And t2.BackColor = defa And t3.BackColor = defa Then target.firers = 0 Else target.firers = 1
        If m = "a" Then If a1.BackColor = defa And a2.BackColor = defa And a3.BackColor = defa Then firer.firers = 0 Else firer.firers = 1
        If m = "s" Then If s1.BackColor = defa And s2.BackColor = defa And s3.BackColor = defa Then firer.firers = 0 Else firer.firers = 1
        'If target.firers <> 0 Then eligible_to_fire(sender)
        eligible_to_fire(sender)
        If fire.Enabled And Not f Then
            If t1.BackColor = golden Or t2.BackColor = golden Or t3.BackColor = golden Then return_fire.BackColor = golden Else return_fire.BackColor = defa
        End If
    End Sub

    Public Sub update_parameters(opt As String)
        If opt = "firers" Or opt = "artillery" Then
            If Tag = "Indirect Fire" Then reset_unit_options(indirectfirepanel) Else reset_unit_options(directfirepanel)
            If firer.title Is Nothing Then Exit Sub
            If firer.Cover > 0 Then f_cover.BackColor = golden : f_cover.Text = "+" + Trim(Str(firer.Cover))
            If firer.elevated Then elevation(f_elevation, Nothing)
            If firer.roadmove Then roadmove(f_roadmove, Nothing)
            If firer.plains Then plains(f_plains, Nothing)
            If firer.insmoke Then in_smoke(f_insmoke, Nothing)
            'If gt - firer.moved <= 1 Then firer.moving = True Else firer.moving = False
            If firer.has_moved Then f_moving.Text = "Moved" : f_moving.BackColor = golden
            If firer.aircraft Then
                fa_altitude.Text = firer.mode
                If firer.mode <> "Low" Then fa_altitude.BackColor = golden Else fa_altitude.BackColor = defa
            Else
                f_mode.Text = firer.mode
                If firer.pre_mode <> conc Then f_mode.BackColor = golden Else f_mode.BackColor = defa
            End If
            If Not firer.helarm Then fwpn.Text = firer.equipment Else fwpn.Text = firer.helarm_select_wpn(firer.equipment)
            If firer.w2 = "" Then fwpn.Enabled = False Else fwpn.Enabled = True
            If firer.debussed_gt = 0 Or firer.debussed_gt = phase Then
                If firer.troopcarrier And firer.embussed Then
                    With f_dismounted
                        .Enabled = True
                        .Text = "Loaded"
                        .BackColor = golden
                    End With
                ElseIf firer.Inf And firer.dismounted Then
                    With f_dismounted
                        .Enabled = True
                        .Text = "Dismounted"
                        .BackColor = defa
                    End With
                ElseIf firer.troopcarrier And Not firer.embussed Then
                    With f_dismounted
                        .Enabled = False
                        .Text = "Empty"
                        .BackColor = defa
                    End With
                Else
                    With f_dismounted
                        .Enabled = False
                        .Text = .Tag
                        .BackColor = defa
                    End With
                End If
            End If
            If Tag = "Indirect Fire" Or Tag = "Smoke Barrage" Then
                If firer.scoot Then set_shoot_scoot(scoot, Nothing)
            End If
            If firer.role = "InfSAM" And firer.carrying <> "" Then
                With ph_units(firer.carrying)
                    .cover = firer.Cover
                    .elevated = firer.elevated
                    .roadmove = firer.roadmove
                    .plains = firer.plains
                    .insmoke = firer.insmoke
                    .moved = firer.moved
                    .mode = firer.mode
                    .flanked = firer.flanked
                    .rear = firer.rear
                End With
            End If
        ElseIf opt = "targets" Then
            reset_unit_options(targetpanel)
            If target.title Is Nothing Or target.title = "No Effect" Then Exit Sub
            If target.Cover > 0 Then t_cover.BackColor = golden : t_cover.Text = "+" + Trim(Str(target.Cover))
            If target.elevated Then elevation(t_elevation, Nothing)
            If target.roadmove Then roadmove(t_roadmove, Nothing)
            If target.plains Then plains(t_plains, Nothing)
            If target.insmoke Then in_smoke(t_insmoke, Nothing)
            'If gt - target.moved <= 1 Then target.moving= True Else target.moving= False
            If target.has_moved Then t_moving.Text = "Moved" : t_moving.BackColor = golden
            If target.aircraft Then
                ta_altitude.Text = target.mode
                If target.mode <> "Low" Then ta_altitude.BackColor = golden Else ta_altitude.BackColor = defa
            Else
                t_mode.Text = target.mode
                If target.mode <> conc Then t_mode.BackColor = golden Else t_mode.BackColor = defa
            End If
            If target.helarm Then twpn.Text = target.helarm_select_wpn(target.equipment) Else twpn.Text = target.equipment
            If target.w2 <> "" And Tag = "Direct Fire" Then twpn.Enabled = True Else twpn.Enabled = False
            If target.debussed_gt = 0 Or target.debussed_gt = phase Then
                If target.troopcarrier And target.embussed Then
                    With t_dismounted
                        .Enabled = True
                        .Text = "Loaded"
                        .BackColor = golden
                    End With
                ElseIf target.Inf And target.dismounted Then
                    With t_dismounted
                        .Enabled = True
                        .Text = "Dismounted"
                        .BackColor = defa
                    End With
                ElseIf target.troopcarrier And Not target.embussed Then
                    With t_dismounted
                        .Enabled = False
                        .Text = "Empty"
                        .BackColor = defa
                    End With
                Else
                    With t_dismounted
                        .Enabled = False
                        .Text = .Tag
                        .BackColor = defa
                    End With
                End If
            End If
        ElseIf opt = "observers" Then
            reset_unit_options(indirectfirepanel)
                If observer.title Is Nothing Then Exit Sub
                If observer.elevated Then elevation(obs_elevation, Nothing)
                If observer.insmoke Then in_smoke(obs_insmoke, Nothing)
                'If gt - observer.moved <= 1 Then observer.moving = True Else observer.moving = False
                If observer.has_moved Then obs_moving.Text = "Moved" : obs_moving.BackColor = golden
                obs_mode.Text = observer.mode
                If observer.mode <> conc Then obs_mode.BackColor = golden Else obs_mode.BackColor = defa
            Else
            End If
    End Sub

    Private Sub select_units(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles targets.Click, firers.Click, observers.Click, artillery.Click

        'If sender.focuseditem.backcolor <> golden Then sender.focuseditem.backcolor = golden Else sender.focuseditem.backcolor = nostatus
        If sender.name = "targets" Then
            If target.title = sender.focuseditem.text And sender.focuseditem.backcolor = golden Then
                sender.focuseditem.backcolor = target.status("")
                reset_strength(t1, t2, t3)
                If abort_target.Visible Then abort_target.Visible = False
                target = New cunit
            Else
                If Not target.title Is Nothing Then If Not targets.FindItemWithText(target.title) Is Nothing Then targets.FindItemWithText(target.title).BackColor = target.status("")
                sender.focuseditem.backcolor = golden
                If sender.FocusedItem.Text = "No Effect" And Tag = "Indirect Fire" Then
                    target = New cunit
                    target.title = sender.FocusedItem.Text
                Else
                    target = orbat(sender.FocusedItem.Text)
                End If
                'If Tag = "Indirect Fire" Then If target.indirect And target.eligibleCB Then targets.FindItemWithText(target.title).BackColor = can_observe
                If Tag <> "Smoke Barrage" And Tag <> "Indirect Fire" Then firer_strength(t1, t2, t3, target.firers_available, target.airborne)
                If Tag = "Air to Air" Then abort_target.Visible = abort_option(target, firer, 0) : abort_firer.Visible = abort_option(firer, target, 0)
            End If
        ElseIf sender.name = "firers" Then
            If firer.title = sender.focuseditem.text And sender.focuseditem.backcolor = golden Then
                sender.focuseditem.backcolor = firer.status("")
                reset_strength(s1, s2, s3)
                If abort_firer.Visible Then abort_firer.Visible = False
                firer = New cunit
            Else
                If Not firer.title Is Nothing Then If Not firers.FindItemWithText(firer.title) Is Nothing Then firers.FindItemWithText(firer.title).BackColor = firer.status("")
                sender.focuseditem.backcolor = golden
                firer = orbat(sender.FocusedItem.Text)
                firer_strength(s1, s2, s3, firer.firers_available, firer.airborne)
                If Tag = "Air to Air" Then abort_target.Visible = abort_option(target, firer, 0) : abort_firer.Visible = abort_option(firer, target, 0)
            End If
        ElseIf sender.name = "artillery" Then
            If firer.title = sender.focuseditem.text And sender.focuseditem.backcolor = golden Then
                sender.focuseditem.backcolor = firer.status("")
                reset_artillery()
                firer = New cunit
            ElseIf sender.focuseditem.backcolor <> golden And ph_units(sender.FocusedItem.Text).valid_arty_observer(observer) Then
                If Tag = "Indirect Fire" And Not firer.title Is Nothing Then If Not artillery.FindItemWithText(firer.title) Is Nothing Then artillery.FindItemWithText(firer.title).BackColor = firer.status("")
                sender.focuseditem.backcolor = golden
                    firer = ph_units(sender.FocusedItem.Text)
                    If Tag = "Indirect Fire" Then firer_strength(a1, a2, a3, firer.firers_available, firer.airborne)
                Else
                    If Not observer.title Is Nothing Then
                    If observer.valid_arty_observer(ph_units(sender.focuseditem.text)) Then sender.focuseditem.BackColor = ph_units(sender.focuseditem.text).status("")
                    If firer.title Is Nothing Then
                        firer = New cunit
                        'area_fire = False
                        reset_artillery()
                        tgt_range_select.SelectedIndex = -1
                        tgt_range.Text = "Range"
                    End If
                End If
            End If
        ElseIf sender.name = "observers" Then
            reset_artillery()
            If observer.title = sender.focuseditem.text And sender.focuseditem.backcolor = golden Then
                sender.focuseditem.backcolor = nostatus
                observer = New cunit
                For Each l As ListViewItem In artillery.Items
                    l.BackColor = nostatus
                Next
            Else
                If Not observer.title Is Nothing Then observers.FindItemWithText(observer.title).BackColor = nostatus
                sender.focuseditem.backcolor = golden
                observer = orbat(sender.FocusedItem.Text)
                If observer.role <> "|Comd|" And Not vis_range_select.Enabled Then vis_range_select.Enabled = True
                For Each l As ListViewItem In artillery.Items
                    If observer.valid_arty_observer(ph_units(l.Text)) Then l.BackColor = in_ds Else l.BackColor = nostatus
                Next
            End If
        Else
        End If
        sender.focuseditem.selected = False
        update_parameters(sender.name)
        eligible_to_fire(sender)

    End Sub
    Public Sub reset_artillery()
        scoot.Text = scoot.Tag
        scoot.BackColor = defa
        firer = New cunit
        reset_strength(a1, a2, a3)
    End Sub

    'If Tag = "Indirect Fire" And firer.role = "|RL|" Then
    '    area_fire = True
    'Else
    '    If area_fire = True Then area_fire = False : reset_unit_options(targetpanel) : set_sel_color(targets, False, False)
    'End If

    Private Sub dismounted(sender As Object, e As EventArgs) Handles f_dismounted.Click, t_dismounted.Click
        If sender.name = "t_dismounted" Then
            If target.title Is Nothing Or targets.Items.Count = 0 Or target.title = "No Effect" Then Exit Sub
            'If (sender.backcolor = golden And Not target.Inf) Then Exit Sub
        Else
            If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
            'If (sender.backcolor = golden And Not firer.Inf) Then Exit Sub
        End If

        Dim tmp As String = ""
        If sender.text = "Loaded" Then
            sender.text = "Empty"
            sender.backcolor = defa
            sender.enabled = False
            If sender.name = "f_dismounted" Then
                Dim l As New ListViewItem
                l.Text = firer.carrying
                l.SubItems.Add(firer.strength)
                l.SubItems.Add(firer.equipment)
                firers.Items.Insert(firers.FindItemWithText(firer.title).Index + 1, l)
                firer.debus()
            Else
                Dim l As New ListViewItem
                l.Text = target.carrying
                l.SubItems.Add(target.strength)
                l.SubItems.Add(target.equipment)
                targets.Items.Insert(targets.FindItemWithText(target.title).Index + 1, l)
                target.debus()
            End If
        ElseIf sender.text = "Dismounted" Then
            sender.BackColor = golden
            sender.Text = "Loaded"
            If sender.name = "f_dismounted" Then
                firer.embus()
                firers.FocusedItem.Remove()
                reset_unit_options(directfirepanel)
                reset_strength(s1, s2, s3)
                firer = New cunit
            Else
                target.embus()
                targets.FocusedItem.Remove()
                reset_unit_options(targetpanel)
                reset_strength(t1, t2, t3)
                target = New cunit
            End If
        Else
            Exit Sub
        End If
        eligible_to_fire(sender)
    End Sub

    Private Sub mode(sender As Object, e As EventArgs) Handles f_mode.Click, t_mode.Click, obs_mode.Click
        If target.title Is Nothing Or targets.Items.Count = 0 Or target.title = "No Effect" Then If sender.name = "t_mode" Then Exit Sub
        If firer.title Is Nothing Or firers.Items.Count = 0 Then If sender.name = "f_mode" Then Exit Sub
        If Tag = "Indirect Fire" Then If observer.title Is Nothing Then If sender.name = "obs_mode" Then Exit Sub

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
        If sender.name = "f_mode" Then
            firer.pre_mode = sender.text
            If Not firer.conc And firer.pre_mode = conc Then
                firer.pre_mode = disp
                sender.Text = disp
                sender.BackColor = golden
            End If
        End If
        If sender.name = "t_mode" Then
            target.mode = sender.text
            If Not target.conc And target.mode = conc Then
                target.mode = disp
                sender.Text = disp
                sender.BackColor = golden
            End If
        End If
        If sender.name = "obs_mode" Then
            observer.mode = sender.text
            If Not observer.conc And observer.mode = conc Then
                observer.mode = disp
                sender.Text = disp
                sender.BackColor = golden
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub roadmove(sender As Object, e As EventArgs) Handles t_roadmove.Click, f_roadmove.Click
        If sender.name = "t_roadmove" Then If target.title Is Nothing Or targets.Items.Count = 0 Or target.title = "No Effect" Then Exit Sub
        If sender.name = "f_roadmove" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.backcolor = defa Then
            sender.text = "Road Move"
            sender.backcolor = golden
            If sender.name = "f_roadmove" Then firer.roadmove = True Else target.roadmove = True
        Else
            sender.text = "X Country"
            sender.backcolor = defa
            If sender.name = "f_roadmove" Then firer.roadmove = True Else target.roadmove = True
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub plains(sender As Object, e As EventArgs) Handles t_plains.Click, f_plains.Click
        If sender.name = "t_plains" Then If target.title Is Nothing Or targets.Items.Count = 0 Or target.title = "No Effect" Then Exit Sub
        If sender.name = "f_plains" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.backcolor = defa Then
            sender.text = "Plains/Steppes"
            sender.backcolor = golden
            If sender.name = "f_plains" Then firer.plains = True Else target.plains = True
        Else
            sender.text = "Open Terrain"
            sender.backcolor = defa
            If sender.name = "f_plains" Then firer.plains = True Else target.plains = True
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub in_smoke(sender As Object, e As EventArgs) Handles f_insmoke.Click, t_insmoke.Click, obs_insmoke.Click
        If sender.name = "t_insmoke" Then If target.title Is Nothing Or targets.Items.Count = 0 Or target.title = "No Effect" Then Exit Sub
        If sender.name = "f_insmoke" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.name = "obs_insmoke" Then If observer.title Is Nothing Or observers.Items.Count = 0 Then Exit Sub
        If sender.backcolor = defa Then
            sender.text = "In Smoke"
            sender.backcolor = golden
            If sender.name = "f_insmoke" Then
                firer.insmoke = True
            ElseIf sender.name = "t_insmoke" Then
                target.insmoke = True
            Else
                observer.insmoke = True
            End If
        Else
            sender.text = "No Smoke"
            sender.backcolor = defa
            If sender.name = "f_insmoke" Then
                firer.insmoke = False
            ElseIf sender.name = "t_insmoke" Then
                target.insmoke = False
            Else
                observer.insmoke = False
            End If
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

    Private Sub set_shoot_scoot(sender As Object, e As EventArgs) Handles scoot.Click
        If sender.backcolor = defa Then
            sender.backcolor = golden
            sender.text = "Shoot and Scoot"
            firer.scoot = True
        Else
            sender.backcolor = defa
            sender.text = sender.tag
            firer.scoot = False
        End If
    End Sub

    Private Sub moved(sender As Object, e As EventArgs) Handles f_moving.Click, t_moving.Click, obs_moving.Click
        If sender.name = "t_moving" Then If target.title Is Nothing Or targets.Items.Count = 0 Or target.title = "No Effect" Then Exit Sub
        If sender.name = "f_moving" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.name = "obs_moving" Then If observer.title Is Nothing Then Exit Sub

        If sender.backcolor = defa Then
            sender.text = "Moved last turn"
            sender.backcolor = golden
            If sender.name = "f_moving" Then
                firer.moved = gt - 1
            ElseIf sender.name = "t_moving" Then
                target.moved = gt - 1
            Else
                observer.moved = gt - 1
            End If
        ElseIf sender.text = "Moved last turn" Then
            sender.text = "Moved this turn"
            If sender.name = "f_moving" Then
                firer.moved = gt
            ElseIf sender.name = "t_moving" Then
                target.moved = gt
            Else
                observer.moved = gt
            End If
        Else
            sender.text = "Static"
            sender.backcolor = defa
            If sender.name = "f_moving" Then
                firer.moved = gt - 2
            ElseIf sender.name = "t_moving" Then
                target.moved = gt - 2
            Else
                observer.moved = gt - 2
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub elevation(sender As Object, e As EventArgs) Handles f_elevation.Click, t_elevation.Click, obs_elevation.Click
        If sender.name = "t_elevation" Then If target.title Is Nothing Or targets.Items.Count = 0 Or target.title = "No Effect" Then Exit Sub
        If sender.name = "f_elevation" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.name = "obs_elevation" Then If observer.title Is Nothing Then Exit Sub

        If sender.backcolor = defa Then
            sender.text = "Elevated"
            sender.backcolor = golden
            If sender.name = "f_elevation" Then
                firer.elevated = firer.elevated
            ElseIf sender.name = "t_elevation" Then
                target.elevated = target.elevated
            Else
                observer.elevated = observer.elevated
            End If
        Else
            sender.text = "Same Level"
            sender.backcolor = defa
            If sender.name = "f_elevation" Then
                firer.elevated = firer.elevated
            ElseIf sender.name = "t_elevation" Then
                target.elevated = target.elevated
            Else
                observer.elevated = observer.elevated
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub return_fire_available()
        If (Tag <> "Direct Fire" And Tag <> "Air to Air") Or firer.firers = 0 Then
            return_fire.BackColor = defa
            Exit Sub
        End If
        Dim rge As Integer = Val(tgt_range_select.SelectedItem)
        If firer.title Is Nothing Or target.title Is Nothing Then return_fire_disable() : Exit Sub
        If Tag = "Air to Air" Then Exit Sub
        'If firer.firers = 0 Or target.firers = 0 Then Exit Sub
        If range_not_needed Or tgt_range_select.SelectedIndex = -1 Then return_fire_disable() : Exit Sub
        If target.secondary <> "" Then
            If rge > eq_list(target.secondary).maxrange Then return_fire_disable() : Exit Sub
        Else
            If rge > eq_list(target.equipment).maxrange Then return_fire_disable() : Exit Sub
        End If
        If Not spotting(rge, target, firer) Then return_fire_disable()
    End Sub

    Private Sub return_fire_disable()
        t1.BackColor = defa
        t2.BackColor = defa
        t3.BackColor = defa
        return_fire.BackColor = defa
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

    Private Sub visrange_Click(sender As Object, e As EventArgs) Handles visrange.Click
        If Tag <> "Indirect Fire" Then Exit Sub
        If observer.title Is Nothing Then Exit Sub
        If observer.role <> "|Comd|" Then Exit Sub
        If vis_range_select.Enabled Then vis_range_select.Enabled = False Else vis_range_select.Enabled = True
    End Sub

    Private Sub rangechange(sender As Object, e As EventArgs) Handles tgt_range_select.SelectedIndexChanged, vis_range_select.SelectedIndexChanged
        If Tag = "Indirect Fire" Then
            If observer.title = firer.title And tgt_range_select.SelectedItem <> vis_range_select.SelectedItem Then
                If sender.name = " tgt_range_select" Then vis_range_select.SelectedItem = tgt_range_select.SelectedItem Else tgt_range_select.SelectedItem = vis_range_select.SelectedItem
            End If
        End If

        eligible_to_fire(sender)
    End Sub

    Private Sub swap_Click(sender As Object, e As EventArgs) Handles swap.Click
        'For Each u As cunit In enemy
        '    If u.comd = 0 And u.arrives = 6 Then u.arrives = 0
        'Next
        targets.Items.Clear()
        firers.Items.Clear()

        swap_phasing_player(True)
        If Tag = "Direct Fire" Then
            direct_fire_phase(ph, nph)
        ElseIf Tag = "Smoke Barrage" Then
            smoke_barrage_phase(ph)
        ElseIf Tag = "Indirect Fire" Then
            indirect_fire_phase(ph, nph)
        ElseIf Tag = "Air to Air" Then
            reset_unit_options(targetpanel)
            reset_unit_options(directfirepanel)
            return_fire.BackColor = defa
            reset_strength(s1, s2, s3)
            reset_strength(t1, t2, t3)
            firer = New cunit
            target = New cunit
            abort_firer.Visible = False
            abort_target.Visible = False
            populate_lists(firers, friend_air, "CAP Combat", "firer")
            populate_lists(targets, enemy_air, "CAP Combat", "")
        ElseIf Tag = "Ground to Air" Then
            ground_to_air(ph_units, enemy_air)
        ElseIf Tag = "Air to Ground" Then
            populate_lists(firers, friend_air, "Air to Ground", "")
            populate_lists(targets, enemy, "Ground Targets", "")
        Else

        End If
        fire.Enabled = False

    End Sub

    Private Sub abort_firer_Click(sender As Object, e As EventArgs) Handles abort_firer.Click, abort_target.Click
        If sender.tag = "Firer" Then
            firer.lands(True)
            reset_aircraft(firer, True, 0, False)
        Else
            target.lands(True)
            reset_aircraft(target, True, 0, False)
        End If

    End Sub

    Private Sub ta_ecm_gs_Click(sender As Object, e As EventArgs) Handles ta_ecm_gs.Click, ta_ecm_ds.Click
        Dim no_ecm As Boolean = True
        For Each ac As cunit In enemy_air
            If (ac.task = "ECM GS" And sender.name = "ta_ecm_gs") Or (ac.task = "ECM DS" And sender.name = "ta_ecm_ds") Then
                sender.text = ac.title
                sender.backcolor = golden
                no_ecm = False
                Exit Sub
            End If
        Next
        If no_ecm Then
            sender.text = "None"
            sender.backcolor = defa
        End If
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
        fire.Enabled = False
        firesmoke.Enabled = False
        firer.spotted = False
        target.spotted = False
        If target.title = "No Effect" Then fire.Enabled = True : Exit Sub
        If Not range_not_needed And tgt_range_select.SelectedIndex = -1 And Tag <> "Indirect Fire" Then return_fire_disable() : Exit Sub
        If (target.title Is Nothing And Not Tag = "Smoke Barrage") Or firer.title Is Nothing Then return_fire_disable() : Exit Sub
        tgt_range.Text = tgt_range_select.SelectedItem
        Dim rge As Integer = Val(tgt_range.Text), out_of_range As Boolean = False
        If Not range_not_needed Then
            If (rge > firer.get_range(True)) Or (Tag = "Opportunity Fire" And Not target.heli And rge > firer.get_range(False)) Or (Tag = "Opportunity Fire" And rge > firer.get_range(False) And target.heli) Then out_of_range = True
        End If
        'Or (Tag = "Air to Ground" And Not firer.heli And rge > 1000)
        'Dim r As Boolean = rge > firer.get_range
        If out_of_range And Not range_not_needed Then
            fire.Enabled = False
            tgt_range.ForeColor = Color.Red
            Exit Sub
        ElseIf Tag = "Smoke Barrage" Then
            rge = firer.get_range(True)
            For Each l As String In tgt_range_select.Items
                If Val(l) >= rge Then
                    tgt_range.Text = l
                    tgt_range.ForeColor = Color.Green
                    Exit For
                End If
            Next
            firesmoke.Enabled = False
            For Each l As ListViewItem In artillery.Items
                If l.BackColor = golden Then firesmoke.Enabled = True : Exit Sub
            Next
            Exit Sub
        ElseIf Tag = "Air to Air" Then
            If firers.Items.Count = 0 Or targets.Items.Count = 0 Then Exit Sub
            firer.spotted = True
            target.spotted = True
            If firer.task = "CAP" And target.task = "CAP" And target.tacticalpts = 1 Then return_fire_disable()
            If firer.task = "CAP" And target.task = "CAP" And firer.tacticalpts = 1 Then fire.Enabled = False : Exit Sub
            fire.Enabled = True
        ElseIf range_not_needed Then
            firer.spotted = True
            target.spotted = True
            fire.Enabled = True
            Exit Sub
        ElseIf Tag = "Direct Fire" Or Tag = "Half Fire" Or (Tag = "Opportunity Fire" And Not target.heli) Or (Tag = "Air to Ground" And firer.task <> "PGM") Then
            If firers.Items.Count = 0 Or targets.Items.Count = 0 Then Exit Sub
            If firer.firers = 0 Then
                return_fire_disable()
                Exit Sub
            End If
            fire.Enabled = spotting(Val(tgt_range.Text), firer, target)
            target.spotted = fire.Enabled
            If Not fire.Enabled Or firer.airborne Then return_fire_disable()
            If target.spotted Then tgt_range.ForeColor = Color.Green Else tgt_range.ForeColor = Color.Red
            If Tag = "Direct Fire" And fire.Enabled Then
                If Not spotting(rge, target, firer) Then return_fire_disable()
                If rge > target.get_range(True) Then return_fire_disable()
            End If
        ElseIf Tag = "Ground to Air" Or (Tag = "Opportunity Fire" And target.heli) Then

            If firer.valid_air_defence(rge, ta_altitude.Text) And Not (firer.eligibleCB And target.disrupted_gt) Then
                fire.Enabled = True
                target.spotted = True
                tgt_range.ForeColor = Color.Green
            Else
                tgt_range.ForeColor = Color.Red
            End If

        ElseIf Tag = "Indirect Fire" Then
            If observers.Items.Count = 0 Or artillery.Items.Count = 0 Or targets.Items.Count = 0 Then Exit Sub
            Dim tmp As String = "", observed As Boolean, identified As Boolean = False
            tgt_range.ForeColor = Color.Green
            If vis_range_select.Enabled Then
                visrange.Text = vis_range_select.SelectedItem
                rge = Val(visrange.Text)
                observed = spotting(rge, observer, target)
            Else
                observed = False
            End If
            If Not observed And (Not vis_range_select.Enabled Or target.has_fired) Then identified = True
            If target.eligibleCB And firer.cb Then identified = True : observed = False
            If observed Then
                visrange.ForeColor = Color.Green
            ElseIf identified And Not observed Then
                visrange.ForeColor = Color.Blue
            Else
                visrange.ForeColor = Color.Red
            End If
            fire.Enabled = (observed Or (identified And Not observed)) And tgt_range_select.SelectedIndex <> -1 And Not out_of_range And firer.firers > 0
            If observed Then target.spotted = True Else target.spotted = False
        Else
        End If
        If firer.firers = 0 Or target.title Is Nothing Or firer.title Is Nothing Or tgt_range.ForeColor = Color.Red Or (target.firers = 0 And Tag = "Direct Fire" And return_fire.BackColor = golden) Then return_fire.Enabled = False
    End Sub

    Private Sub fire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fire.Click
        If Not range_not_needed And tgt_range.Text = "Range" And target.title<>"No Effect" Then Exit Sub
        If Tag = "Indirect Fire" And visrange.Text = "Vis Range" Then Exit Sub
        If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        ac_firer = New cunit
        If Tag = "Air to Ground" And firer.second_attack And Not firer.disrupted_gt Then
            firer.disrupted_gt = True
            a2g_range = tgt_range.Text
            ac_firer = firer.Clone
            a2g_target = target.Clone
            ground_to_air(enemy, friend_air)
            target = ac_firer.Clone
            'firer = New cunit
            targets.Items.Clear()
            Dim t As ListViewItem
            t = New ListViewItem
            With t
                .Text = target.title
                .SubItems.Add(target.strength)
                .SubItems.Add(target.equipment)
                .BackColor = golden
            End With
            targets.Items.Add(t)
            twpn.Text = target.equipment
            Exit Sub
        End If
        firer.firers = 0 : target.firers = 0
        If Tag = "Indirect Fire" Then
            firer.firers = IIf(a1.BackColor = golden, Val(a1.Text), 0) + IIf(a2.BackColor = golden, Val(a2.Text), 0) + IIf(a3.BackColor = golden, Val(a3.Text), 0)
        Else
            firer.firers = IIf(s1.BackColor = golden, Val(s1.Text), 0) + IIf(s2.BackColor = golden, Val(s2.Text), 0) + IIf(s3.BackColor = golden, Val(s3.Text), 0)
        End If
        target.firers = IIf(t1.BackColor = golden, Val(t1.Text), 0) + IIf(t2.BackColor = golden, Val(t2.Text), 0) + IIf(t3.BackColor = golden, Val(t3.Text), 0)
        If firer.firers = 0 Then Exit Sub

        If Me.Tag = "Ground to Air" Or target.heli Then target.mode = ta_altitude.Text
        Dim stages As Integer, stage As Integer
        If Tag = "Air to Air" Then
            If firer.tacticalpts = 3 And firer.task = "CAP" Then stage = 1 Else stage = 2
            stages = 3
        ElseIf area_fire Then
            firer.aborts = firer.firers
            stages = 0 : stage = 1
            For Each l As ListViewItem In targets.Items
                If l.BackColor = golden Then stages = stages + 1 : l.Tag = "Area"
            Next
            If stages = 0 Then Exit Sub
        Else
            stage = 1 : stages = 1
        End If
        For i As Integer = stage To stages
            If area_fire Then
                For Each l As ListViewItem In targets.Items
                    If l.BackColor = golden And l.Tag = "Area" Then target = enemy(l.Text) : Exit For
                Next
                firer.firers = firer.aborts
            End If
            firer.fires = True
            If target.title <> "No Effect" Then
                resolvefire(firer, target, i)
                target.update_after_firing(False)
            End If
            If oppfire Then firer.update_after_firing(True) Else firer.update_after_firing(False)
            If firer.heli And (Tag = "Direct Fire" Or InStr(Text, "Moving Fire") > 0) Then
                If firer.ordnance And firer.hel_atgw Then
                    firer.reset_helarm()
                    firers.FindItemWithText(firer.title).Remove()
                Else
                    choose_weapon(fwpn, Nothing)
                    firers.FindItemWithText(firer.title).BackColor = nostatus
                End If
                firer.firers_available = firer.strength
                reset_strength(s1, s2, s3)
                reset_target()
            ElseIf Tag = "Opportunity Fire" Then
                reset_strength(s1, s2, s3)
                reset_unit_options(directfirepanel)
                reset_range()
                firers.FindItemWithText(firer.title).BackColor = nostatus
                If Not firer.opp_fire_available Then
                    firers.FindItemWithText(firer.title).Remove()
                    fwpn.Text = ""
                    firer = New cunit
                End If
                target.apply_casualties()
                reset_target()
                If target.strength <= 0 Then Close()
            ElseIf InStr(Text, "Moving Fire") > 0 And firer.firers_available > 0 Then
                target.apply_casualties()
                reset_target()
                firer_strength(s1, s2, s3, firer.firers_available, firer.airborne)
                reset_range()
            ElseIf InStr(Text, "Moving Fire") > 0 And firer.firers_available <= 0 Then
                Close()
            ElseIf Tag = "Ground to Air" Then
                If firer.missile_armed And firer.missiles <= 0 Then
                    firers.FindItemWithText(firer.title).Remove()
                    fwpn.Text = ""
                    firer = New cunit
                    reset_strength(s1, s2, s3)
                    reset_unit_options(directfirepanel)
                    reset_range()
                Else
                    firer.firers_available = firer.strength
                End If
                'reset_strength(s1, s2, s3)
                'reset_unit_options(directfirepanel)
                'reset_range()
                If InStr(firer.equipment, firer.secondary) > 0 Then firer.equipment = Replace(firer.equipment, firer.secondary, "") : firer.secondary = ""
                reset_aircraft(target, False, i, IIf(target.strength = 0 Or Not target.airborne, True, False))
                If ta_ecm_ds.BackColor = golden Then
                    ta_ecm_ds.Text = ta_ecm_ds.Tag
                    ta_ecm_ds.BackColor = defa
                    enemy_air(ta_ecm_ds.Text).lands(False)
                End If
            ElseIf Tag = "Air to Ground" Then
                If firer.second_attack And firer.disrupted_gt Then firer.disrupted_gt = False
                reset_aircraft(firer, True, 3, IIf(firer.strength = 0 Or Not firer.airborne, True, False))
                target.apply_casualties()
                reset_target()

                reset_range()
                fire.Enabled = False
            ElseIf Tag = "Air to Air" Then
                reset_aircraft(firer, True, i, IIf(target.strength = 0 Or Not target.airborne, True, False))
                reset_aircraft(target, False, i, IIf(firer.strength = 0 Or Not firer.airborne, True, False))
                If interceptor = "Parity" Then interceptor = air_assessment(3, interceptor)
                If Not firer.airborne Or Not target.airborne Or firer.strength = 0 Or target.strength = 0 Then Exit For
            Else
                If area_fire Then targets.FindItemWithText(target.title).Tag = ""
                If target.title <> "No Effect" Then reset_target()
                If i = stages Then reset_firer()
            End If
        Next
        If Tag = "Ground to Air" And targets.Items.Count = 0 Then Close()
        area_fire = False
        eligible_to_fire(firers)
    End Sub


    Private Sub firesmoke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firesmoke.Click
        For Each l As ListViewItem In artillery.Items
            If l.BackColor = golden Then
                firer = ph_units(l.Text)
                firer.smoke = gt
                firer.eligibleCB = True
                artillery.Items.Remove(artillery.FindItemWithText(l.Text))
                resultform_2.result.Text = firer.title + vbNewLine + "Smoke Fired"
                resultform_2.ShowDialog()
                smokefiredthisturn = True
            End If
        Next
        firesmoke.Enabled = False
        reset_range()
    End Sub

    Private Sub combat_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.Closing
        If Tag = "Air to Air" Then
            Dim fnd_cap As Boolean = False, en_cap As Boolean = False
            For Each ac As cunit In friend_air
                If ac.tacticalpts = 3 And ac.task = "CAP" Then
                    fnd_cap = True
                    Exit For
                End If
            Next
            For Each ac As cunit In enemy_air
                If ac.tacticalpts = 3 And ac.task = "CAP" Then
                    en_cap = True
                    Exit For
                End If
            Next
            If en_cap And fnd_cap Then e.Cancel = True : Exit Sub

            If InStr("ParityNone", air_assessment(4, interceptor)) = 0 Then
                e.Cancel = True
                For Each ac As cunit In friend_air
                    If ac.airborne And ac.tacticalpts >= 2 And ac.task = "CAP" Then ac.tacticalpts = 1
                Next
                For Each ac As cunit In enemy_air
                    If ac.airborne And ac.tacticalpts >= 2 And ac.task = "CAP" Then ac.tacticalpts = 1
                Next
                firers.Items.Clear()
                targets.Items.Clear()
                populate_lists(firers, IIf(interceptor = ph, friend_air, enemy_air), "Intercept", "")
                populate_lists(targets, IIf(interceptor = ph, enemy_air, friend_air), "Intercept Targets", "")
                swap.Visible = False
                interceptor = "None"
            End If
        ElseIf Tag = "Ground to Air" And ground_air_required(False) Then
            e.Cancel = True
            air_to_ground()
            If target.title Is Nothing Then
                firer = New cunit
                target = New cunit
                swap.Visible = True
            ElseIf target.second_attack And Not target.disrupted_gt Then
                firer = New cunit
                reset_range()
                reset_unit_options(targetpanel)
                reset_unit_options(directfirepanel)
                twpn.Text = ""
                fire.Enabled = False
            ElseIf target.second_attack And target.disrupted_gt Then
                If target.strength <> friend_air(target.title).strength Then
                    friend_air.Remove(target.title)
                    orbat.Remove(target.title)
                    friend_air.Add(target, target.title)
                    orbat.Add(target, target.title)
                End If
                firer = friend_air(target.title)
                target = New cunit
                target = enemy(a2g_target.title)
                tgt_range.Text = a2g_range
                firer_strength(s1, s2, s3, firer.strength, True)
                fire_Click(fire, Nothing)
            Else
            End If
        ElseIf Tag = "Direct Fire" Then
            For Each u As cunit In orbat
                If Not u.airborne And u.comd = 0 Then u.firers_available = u.strength
            Next
        Else
        End If

    End Sub
    Private Sub reset_target()
        If target.strength - target.casualties <= 0 Then
            targets.FindItemWithText(target.title).Remove()
            twpn.Text = ""
        Else
            targets.FindItemWithText(target.title).Selected = False
            targets.FindItemWithText(target.title).SubItems(1).Text = target.strength - target.casualties
            'targets.Refresh()
            If target.mode = disp And t_mode.Text <> disp Then t_mode.Text = disp : t_mode.BackColor = golden
            'targetpanel.Refresh()
            return_fire_disable()
            reset_strength(t1, t2, t3)
            'reset_unit_options(targetpanel)
        End If
    End Sub
    Private Sub reset_firer()
        If firer.firers_available <= 0 Or Tag = "Indirect Fire" Then
            If Tag = "Indirect Fire" And scoot.BackColor = golden Then
                If Not firer.scoot Then
                    With firer
                        .scoot = True
                        .emplaced = False
                        .moved = gt
                        .eligibleCB = False
                    End With
                End If
                scoot.BackColor = defa : scoot.Text = scoot.Tag
            End If
            If firer.firers_available <= 0 Then
                If Tag = "Indirect Fire" Then
                    artillery.FindItemWithText(firer.title).Remove()
                Else
                    firers.FindItemWithText(firer.title).Remove()
                    fwpn.Text = ""
                End If
            Else
                If Tag = "Indirect Fire" Then artillery.Items(nf).Selected = False Else firers.Items(nf).Selected = False
            End If
            If Tag = "Indirect Fire" Then
                reset_strength(a1, a2, a3)
            Else
                reset_strength(s1, s2, s3)
                reset_unit_options(directfirepanel)
                reset_range()
            End If
        Else
            If Tag = "Indirect Fire" Then firer_strength(a1, a2, a3, firer.firers_available, False) Else firer_strength(s1, s2, s3, firer.firers_available, firer.airborne)
        End If
    End Sub
    Private Sub reset_aircraft(airunit As cunit, f As Boolean, stage As Integer, tgt_destroyed As Boolean)
        If airunit.airborne Then
            With airunit
                .firers_available = .strength
                .firers = IIf((f And s1.BackColor = golden) Or (Not f And t1.BackColor = golden), .strength, 0)
            End With
            If f Then
                s1.Text = airunit.strength
                firers.FindItemWithText(firer.title).SubItems(1).Text = firer.strength
            Else
                t1.Text = airunit.strength
                targets.FindItemWithText(target.title).SubItems(1).Text = target.strength
                'targets.Refresh()
            End If
        End If
        If (stage = 3 And airunit.airborne) Or tgt_destroyed Then
            If airunit.fires Then airunit.tacticalpts = airunit.tacticalpts - 1
            If f Then
                firers.FindItemWithText(airunit.title).BackColor = nostatus
                'If Tag = "Air to Air" Then firers.FindItemWithText(airunit.title).SubItems(3).Text = 4 - airunit.tacticalpts
            Else
                targets.FindItemWithText(airunit.title).BackColor = nostatus
                'If Tag = "Air to Air" Then targets.FindItemWithText(airunit.title).SubItems(3).Text = 4 - airunit.tacticalpts
            End If
            reset_strength(s1, s2, s3)
            reset_strength(t1, t2, t3)
            return_fire_disable()
        End If
        If airunit.strength = 0 Or Not airunit.airborne Or airunit.tacticalpts = 0 Then
            If f Then
                firers.FindItemWithText(airunit.title).Remove()
                fwpn.Text = ""
            Else
                targets.FindItemWithText(airunit.title).Remove()
                twpn.Text = ""
            End If
        End If
    End Sub
    Public Sub reset_strength(f1 As Object, f2 As Object, f3 As Object)
        f1.backcolor = defa : f2.BackColor = defa : f3.backcolor = defa
        f1.Text = "" : f2.Text = "" : f3.Text = ""
    End Sub
    Private Sub reset_range()
        tgt_range_select.SelectedIndex = -1
        vis_range_select.SelectedIndex = -1
        tgt_range.Text = tgt_range.Tag
        visrange.Text = visrange.Tag

    End Sub
    Private Sub reset_unit_options(p As Object)
        If p.name = "targetpanel" Then
            twpn.Text = ""
        ElseIf p.name = "directfirepanel" Then
            fwpn.Text = ""
        Else
        End If

        For Each c As Control In p.Controls
            If c.BackColor = golden And c.Tag <> "" Then c.BackColor = defa : c.Text = c.Tag
        Next

    End Sub
End Class