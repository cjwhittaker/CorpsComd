Public Class combat_2

    Public firer As cunit, target As cunit, observer As cunit, combatmode As String, target_fires As Boolean = False, range_not_needed As Boolean
    Public weapon As String, fired_this_turn As Integer = 0, nt As Integer, nf As Integer, no As Integer, interceptor As String
    Dim currentrange As Integer, tn As Integer
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
        directfirepanel.Visible = True
        If Tag = "Direct Fire" Or Tag = "Air to Air" Then return_fire.Visible = True Else return_fire.Visible = False
        If Tag = "Smoke Barrage" Then
            targetpanel.Enabled = False
            For Each c As Control In directfirepanel.Controls
                If TypeOf c Is Label Then c.Enabled = False
            Next
            'For Each c As Control In Panel2.Controls
            '    c.Enabled = False
            'Next
            firesmoke.Enabled = False
            fire.Visible = False
            return_fire.Visible = False
        End If
        If Tag = "Indirect Fire" Then
            directfirepanel.Visible = False
            indirectfirepanel.Visible = True
            targetpanel.Enabled = True
            fire.Visible = True
        End If
        If Tag = "Direct Fire" Or Tag = "Opportunity Fire" Then
            directfirepanel.Visible = True
            indirectfirepanel.Visible = False
        End If
        If Tag = "Opportunity Fire" Then swap.Visible = False Else swap.Visible = True
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
            t_move.Enabled = True
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
        If sender.name= "f_cover" Then cover = f_cover Else cover = t_cover
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
        If sender.name = "targetaspect" And target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "fireraspect" And firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
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

    Public Sub firer_strength(f1 As Object, f2 As Object, f3 As Object, strength As Integer, airunit As Boolean)
        reset_strength(f1, f2, f3)
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
        Dim air_strength As Integer = 0
        If airunit Then air_strength = strength : strength = 5
        Select Case strength
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
        If Tag = "Air to Air" Then
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
        If ((Not return_fire.Visible And m = "t") Or sender.text = "" Or (m = "t" And Not fire.Enabled)) And Tag <> "Air to Air" Then Exit Sub
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
            If firer.Cover > 0 Then select_cover(f_cover, Nothing)
            If firer.elevated Then elevation(f_elevation, Nothing)
            If firer.roadmove Then roadmove(f_roadmove, Nothing)
            If firer.plains Then plains(f_plains, Nothing)
            If firer.insmoke Then in_smoke(f_insmoke, Nothing)
            'If gt - firer.moved <= 1 Then firer.moving = True Else firer.moving = False
            If firer.has_moved Then moved(f_moving, Nothing)
            If firer.aircraft Then
                fa_altitude.Text = firer.mode
                If firer.mode <> "Low" Then fa_altitude.BackColor = golden Else fa_altitude.BackColor = defa
            Else
                f_mode.Text = firer.mode
                If firer.mode <> conc Then f_mode.BackColor = golden Else f_mode.BackColor = defa
            End If
            fwpn.Text = IIf(Not firer.helarm, firer.equipment, firer.helarm_select_wpn(firer.equipment))
            If firer.w2 = "" Then fwpn.Enabled = False Else fwpn.Enabled = True
            If firer.troopcarrier And firer.embussed Then f_dismounted.Enabled = True Else f_dismounted.Enabled = False
            If firer.Inf And firer.dismounted Then
                With f_dismounted
                    .Enabled = True
                    .Text = "Mount"
                    .BackColor = golden
                End With
            End If
            If Tag = "Indirect Fire" Then
                If firer.scoot Then set_shoot(scoot, Nothing)
            End If
        ElseIf opt = "targets" Then
            reset_unit_options(targetpanel)
            If target.Cover > 0 Then select_cover(t_cover, Nothing)
            If target.elevated Then elevation(t_elevation, Nothing)
            If target.roadmove Then roadmove(t_move, Nothing)
            If target.plains Then plains(t_plains, Nothing)
            If target.insmoke Then in_smoke(t_insmoke, Nothing)
            'If gt - target.moved <= 1 Then target.moving= True Else target.moving= False
            If target.has_moved Then moved(t_moving, Nothing)
            If target.aircraft Then
                ta_altitude.Text = target.mode
                If target.mode <> "Low" Then ta_altitude.BackColor = golden Else ta_altitude.BackColor = defa
            Else
                t_mode.Text = target.mode
                If target.mode <> conc Then t_mode.BackColor = golden Else t_mode.BackColor = defa
            End If
            twpn.Text = IIf(target.helarm, target.helarm_select_wpn(target.equipment), target.equipment)
            If target.w2 = "" Then twpn.Enabled = False Else twpn.Enabled = True
            If Not target.troopcarrier Then t_dismounted.Enabled = False Else t_dismounted.Enabled = True
        Else
        End If
    End Sub

    Private Sub select_units(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles targets.Click, firers.Click, observers.Click, artillery.Click
        set_sel_color(sender.items, False, False)
        If sender.name = "targets" Then
            target = orbat(sender.FocusedItem.Text)
            nt = targets.FocusedItem.Index
            set_sel_color(sender.items, True, True)
            If Tag <> "Smoke Barrage" And Tag <> "Indirect Fire" Then firer_strength(t1, t2, t3, target.firers_available, target.airborne)
            If Tag = "Air to Air" Then If Not firer.title Is Nothing Then abort_target.Visible = abort_option(target, firer, 0)
        ElseIf sender.name = "firers" Then
            firer = orbat(sender.FocusedItem.Text)
            nf = firers.FocusedItem.Index
            set_sel_color(sender.items, True, False)
            firer_strength(s1, s2, s3, firer.firers_available, firer.airborne)
            If Tag = "Air to Air" Then If Not target.title Is Nothing Then abort_firer.Visible = abort_option(firer, target, 0)
        ElseIf sender.name = "artillery" And Not observer.title Is Nothing Then
            firer = orbat(sender.FocusedItem.Text)
            If firer.valid_arty_observer(observer) Then
                firer = orbat(sender.FocusedItem.Text)
                firer_strength(a1, a2, a3, firer.firers_available, False)
                nf = artillery.FocusedItem.Index
                set_sel_color(sender.items, True, False)
            Else
                firer = New cunit
                reset_strength(a1, a2, a3)
                tgt_range_select.SelectedIndex = -1
                tgt_range.Text = "Range"
                Exit Sub
            End If
        ElseIf sender.name = "observers" Then
            observer = orbat(sender.FocusedItem.Text)
            For Each l As ListViewItem In artillery.Items
                If observer.valid_arty_observer(ph_units(l.Text)) Then l.BackColor = in_ds Else l.BackColor = nostatus
            Next
            no = observers.FocusedItem.Index
            set_sel_color(sender.items, True, False)
            If observer.indirect Then firer = observer Else Exit Sub
        Else
            Exit Sub
        End If
        update_parameters(sender.name)
        eligible_to_fire(sender)

    End Sub
    Private Sub set_sel_color(obj As Object, set_color As Boolean, t As Boolean)
        For Each l As ListViewItem In obj
            If set_color Then
                If l.Focused Then l.Selected = False : l.BackColor = golden
            ElseIf Not set_color And l.BackColor = golden Then
                l.BackColor = nostatus
            Else
            End If
            If Tag = "Indirect Fire" And t And l.BackColor = nostatus Then
                If enemy(l.Text).indirect And enemy(l.Text).eligibleCB Then l.BackColor = can_observe
            End If
            If Tag = "Indirect Fire" And Not t And l.BackColor = nostatus Then
                If ph_units.Contains(l.Text) Then
                    If ph_units(l.Text).task = "DS" Then l.BackColor = in_ds
                ElseIf friend_air.Contains(l.Text) Then
                    If friend_air(l.Text).task = "DS" Then l.BackColor = in_ds
                Else
                End If
            End If
        Next

    End Sub


    Private Sub dismounted(sender As Object, e As EventArgs) Handles f_dismounted.Click, t_dismounted.Click
        If sender.name = "targetdismounted" Then
            If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
            If (sender.backcolor = golden And Not target.Inf) Then Exit Sub
        Else
            If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
            If (sender.backcolor = golden And Not firer.Inf) Then Exit Sub
        End If

        Dim tmp As String = ""
        If sender.backcolor = defa Then
            sender.text = "Mount"
            sender.backcolor = golden
            If sender.name = "firerdismounted" Then
                firer.debus()
                populate_lists(firers, orbat, "Direct Fire", firer.nation)
            Else
                target.debus()
                populate_lists(targets, orbat, "Direct Fire", target.nation)
            End If
        Else
            If sender.name = "firerdismounted" Then firer.embus() Else target.embus()
            If (sender.name = "firerdismounted" And firer.embussed) Or (sender.name = "targetdismounted" And target.embussed) Then
                If sender.name = "firerdismounted" Then firers.FocusedItem.Remove() Else targets.FocusedItem.Remove()
                sender.text = "Dismount"
                sender.backcolor = defa
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub mode(sender As Object, e As EventArgs) Handles f_mode.Click, t_mode.Click, obs_mode.Click
        If target.title Is Nothing Or targets.Items.Count = 0 Then If sender.name = "t_mode" Then Exit Sub
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
            firer.mode = sender.text
            If Not firer.conc And firer.mode = conc Then
                firer.mode = disp
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

    Private Sub roadmove(sender As Object, e As EventArgs) Handles t_move.Click, f_roadmove.Click
        If sender.name = "troadmove" Then If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "froadmove" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
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

    Private Sub plains(sender As Object, e As EventArgs) Handles t_plains.Click, f_plains.Click
        If sender.name = "tplains" Then If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "fplains" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
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

    Private Sub in_smoke(sender As Object, e As EventArgs) Handles f_insmoke.Click, t_insmoke.Click
        If sender.name = "tinsmoke" Then If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "finsmoke" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
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

    Private Sub set_shoot(sender As Object, e As EventArgs) Handles scoot.Click
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
        If sender.name = "t_moving" Then If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "f_moving" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.name = "obs_moving" Then If observer.title Is Nothing Then Exit Sub

        If sender.backcolor = defa Then
            sender.text = "Moved"
            sender.backcolor = golden
            If sender.name = "f_moving" Then
                firer.moved = firer.moved + 1
            ElseIf sender.name = "t_moving" Then
                target.moved = target.moved + 1
            Else
                observer.moved = observer.moved + 1
            End If
        Else
            sender.text = "Static"
            sender.backcolor = defa
            If sender.name = "f_moving" Then
                firer.moved = firer.moved - IIf(firer.moved = 0, 0, 1)
            ElseIf sender.name = "t_moving" Then
                target.moved = target.moved - IIf(target.moved = 0, 0, 1)
            Else
                observer.moved = observer.moved - IIf(observer.moved = 0, 0, 1)
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub elevation(sender As Object, e As EventArgs) Handles f_elevation.Click, t_elevation.Click, obs_elevation.Click
        If sender.name = "targetelevation" Then If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        If sender.name = "firerelevation" Then If firer.title Is Nothing Or firers.Items.Count = 0 Then Exit Sub
        If sender.name = "obs_elevation" Then If observer.title Is Nothing Then Exit Sub

        If sender.backcolor = defa Then
            sender.text = "Elevated"
            sender.backcolor = golden
            If sender.name = "firerelevation" Then
                firer.elevated = firer.elevated
            ElseIf sender.name = "targetelevation" Then
                target.elevated = target.elevated
            Else
                observer.elevated = observer.elevated
            End If
        Else
            sender.text = "Same Level"
            sender.backcolor = defa
            If sender.name = "firerelevation" Then
                firer.elevated = firer.elevated
            ElseIf sender.name = "targetelevation" Then
                target.elevated = target.elevated
            Else
                observer.elevated = observer.elevated
            End If
        End If
        eligible_to_fire(sender)

    End Sub

    Private Sub return_fire_available()
        If (Tag <> "Direct Fire" And Tag<>"Air to Air") Or firer.firers = 0 Then
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

    Private Sub rangechange(sender As Object, e As EventArgs) Handles tgt_range_select.SelectedIndexChanged, vis_range_select.SelectedIndexChanged
        If Tag = "Indirect Fire" Then
            If observer.title = firer.title And tgt_range_select.SelectedItem <> vis_range_select.SelectedItem Then
                If sender.name = " tgt_range_select" Then vis_range_select.SelectedItem = tgt_range_select.SelectedItem Else tgt_range_select.SelectedItem = vis_range_select.SelectedItem
            End If
        End If

        eligible_to_fire(sender)
    End Sub

    Private Sub swap_Click(sender As Object, e As EventArgs) Handles swap.Click
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
            populate_lists(firers, friend_air, "CAP Combat", "firer")
            populate_lists(targets, enemy_air, "CAP Combat", "")
        ElseIf Tag = "Ground to Air" Then
            ground_to_air()
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
            sender.backcolor = golden
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
        If Not range_not_needed And tgt_range_select.SelectedIndex = -1 And Tag <> "Indirect Fire" Then return_fire_disable() : Exit Sub
        If (target.title Is Nothing And Not Tag = "Smoke Barrage") Or firer.title Is Nothing Then return_fire_disable() : Exit Sub
        tgt_range.Text = tgt_range_select.SelectedItem
        Dim rge As Integer = Val(tgt_range.Text), out_of_range As Boolean = False
        If (rge > firer.getmaxrange) Or (Tag = "Opportunity Fire" And Not target.heli And rge > eq_list(firer.equipment).opr) Or (Tag = "Opportunity Fire" And rge > eq_list(firer.equipment).maxrange And target.heli) Then out_of_range = True
        'Or (Tag = "Air to Ground" And Not firer.heli And rge > 1000)
        'Dim r As Boolean = rge > firer.getmaxrange
        If out_of_range And Not range_not_needed Then
            fire.Enabled = False
            tgt_range.ForeColor = Color.Red
            Exit Sub
        ElseIf Tag = "Smoke Barrage" Then
            tgt_range.ForeColor = Color.Green
            firesmoke.Enabled = True
            Exit Sub
        ElseIf firer.firers = 0 Then
            return_fire_disable()
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
        ElseIf Tag = "Direct Fire" Or (Tag = "Opportunity Fire" And Not target.heli) Or (Tag = "Air to Ground" And firer.task <> "PGM") Then
            If firers.Items.Count = 0 Or targets.Items.Count = 0 Then Exit Sub
            fire.Enabled = spotting(Val(tgt_range.Text), firer, target)
            target.spotted = fire.Enabled
            If Not fire.Enabled Or firer.airborne Then return_fire_disable()
            If target.spotted Then tgt_range.ForeColor = Color.Green Else tgt_range.ForeColor = Color.Red
            If Tag = "Direct Fire" And fire.Enabled Then
                If Not spotting(rge, target, firer) Then return_fire_disable()
                If rge > target.getmaxrange Then return_fire_disable()
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
            visrange.Text = vis_range_select.SelectedItem
            rge = Val(visrange.Text)
            If Not observed And target.has_fired Then identified = True
            If target.eligibleCB And firer.cb Then identified = True
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

    End Sub

    Private Sub fire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fire.Click
        If Not range_not_needed And tgt_range.Text = "Range" Then Exit Sub
        If Tag = "Indirect Fire" And visrange.Text = "Vis Range" Then Exit Sub
        If target.title Is Nothing Or targets.Items.Count = 0 Then Exit Sub
        firer.firers = 0 : target.firers = 0
        If Tag = "Direct Fire" Or Tag = "Opportunity Fire" Or Tag = "Air to Air" Or Tag = "Ground to Air" Or Tag = "Air to Ground" Then
            firer.firers = IIf(s1.BackColor = golden, Val(s1.Text), 0) + IIf(s2.BackColor = golden, Val(s2.Text), 0) + IIf(s3.BackColor = golden, Val(s3.Text), 0)
        ElseIf Tag = "Indirect Fire" Then
            firer.firers = IIf(a1.BackColor = golden, Val(a1.Text), 0) + IIf(a2.BackColor = golden, Val(a2.Text), 0) + IIf(a3.BackColor = golden, Val(a3.Text), 0)
        Else
        End If
        'fired_this_turn = fired_this_turn + firer.firers
        target.firers = IIf(t1.BackColor = golden, Val(t1.Text), 0) + IIf(t2.BackColor = golden, Val(t2.Text), 0) + IIf(t3.BackColor = golden, Val(t3.Text), 0)
        If firer.firers = 0 Then Exit Sub

        'If firer.airborne And firer.ordnance And Val(tgt_range.Text) > 1000 Then firer.ordnance = False

        If Me.Tag = "Ground to Air" Or target.heli Then target.mode = ta_altitude.Text
        Dim stages As Integer, stage As Integer
        If Tag = "Air to Air" Then
            If firer.tacticalpts = 3 And firer.task = "CAP" Then stage = 1 Else stage = 2
            stages = 3
        Else
            stage = 1 : stages = 1
        End If
        For i As Integer = stage To stages
            firer.fires = True
            resolvefire(firer, target, i)
            target.update_after_firing(False)
            If oppfire Then firer.update_after_firing(True) Else firer.update_after_firing(False)
            'update_parameters("firers")
            'update_parameters("targets")
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
            ElseIf Tag = "Opportunity Fire" And target.strength <= 0 Then
                Close()
            ElseIf Tag = "Opportunity Fire" And target.strength > 0 Then
                reset_strength(s1, s2, s3)
                reset_unit_options(directfirepanel)
                reset_range()
                firers.FindItemWithText(firer.title).BackColor = nostatus
                If Not firer.opp_fire_available Then
                    firers.FindItemWithText(firer.title).Remove()
                    fwpn.Text = ""
                    firer = New cunit
                End If
                targets.FindItemWithText(target.title).SubItems(1).Text = target.strength
            ElseIf InStr(Text, "Moving Fire") > 0 And firer.firers_available > 0 Then
                reset_target()
                firer_strength(s1, s2, s3, firer.firers_available, firer.airborne)
                reset_range()
            ElseIf InStr(Text, "Moving Fire") > 0 And firer.firers_available <= 0 Then
                Close()
            ElseIf Tag = "Ground to Air" Then
                reset_aircraft(target, False, i, IIf(target.strength = 0, True, False))
                If ta_ecm_ds.BackColor = golden Then enemy_air(ta_ecm_ds.Text).lands(False)
            ElseIf Tag = "Air to Ground" Then
                reset_aircraft(firer, True, 3, IIf(firer.strength = 0, True, False))
                reset_target()
            ElseIf Tag = "Air to Air" Then
                reset_aircraft(firer, True, i, IIf(target.strength = 0, True, False))
                reset_aircraft(target, False, i, IIf(firer.strength = 0, True, False))
                If interceptor = "Parity" Then interceptor = air_assessment(3, interceptor)
                If Not firer.airborne Or Not target.airborne Or firer.strength = 0 Or target.strength = 0 Then Exit For
            Else
                reset_target()
                reset_firer()
            End If
        Next
        eligible_to_fire(firers)

    End Sub


    Private Sub firesmoke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firesmoke.Click
        firer.smoke = gt
        firers.Items(firers.FocusedItem.Index).Remove()
        resultform_2.result.Text = "Smoke Fired"
        resultform_2.ShowDialog()
        smokefiredthisturn = True
        firesmoke.Enabled = False
        reset_range()
    End Sub

    Private Sub combat_Closed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.Closing
        If Tag = "Air to Air" Then
            For Each ac As cunit In friend_air
                If ac.tacticalpts = 3 And ac.task = "CAP" Then e.Cancel = True : Exit Sub
            Next
            For Each ac As cunit In enemy_air
                If ac.tacticalpts = 3 And ac.task = "CAP" Then e.Cancel = True : Exit Sub
            Next
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
        ElseIf Tag = "Ground to Air" Then
            e.Cancel = True
            Tag = "Air to Ground"
            Text = "Ground to Air Fire Sub Phase for " + gameturn
            firers.Items.Clear()
            targets.Items.Clear()
            enable_controls(False, directfirepanel)
            enable_controls(True, targetpanel)
            populate_lists(firers, friend_air, "Air to Ground", "")
            populate_lists(targets, enemy, "Ground Targets", "")
            swap.Visible = True
        ElseIf Tag = "Direct Fire" Then
            For Each u As cunit In orbat
                If Not u.airborne And u.comd = 0 Then u.firers_available = u.strength
            Next
        Else
        End If

    End Sub
    Private Sub reset_target()
        If target.strength = 0 Then
            targets.FindItemWithText(target.title).Remove()
            twpn.Text = ""
        Else
            targets.FindItemWithText(target.title).Selected = False
            targets.FindItemWithText(target.title).SubItems(1).Text = target.strength
            targets.Refresh()
            If target.mode = disp And t_mode.Text <> disp Then t_mode.Text = disp : t_mode.BackColor = golden
            targetpanel.Refresh()
            return_fire_disable()
            reset_strength(t1, t2, t3)
            'reset_unit_options(targetpanel)
        End If
    End Sub
    Private Sub reset_firer()
        If firer.firers_available <= 0 Or Tag = "Indirect Fire" Then
            If Tag = "indirect" And scoot.BackColor = golden And Not firer.moving Then firer.moving = True Else firer.moving = False
            If firer.firers_available <= 0 Then
                If Tag = "Indirect Fire" Then
                    artillery.Items(nf).Remove()
                Else
                    firers.Items(nf).Remove()
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
            If f Then firers.FindItemWithText(airunit.title).BackColor = nostatus Else targets.FindItemWithText(airunit.title).BackColor = nostatus
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
    Private Sub reset_strength(f1 As Object, f2 As Object, f3 As Object)
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
        For Each c As Control In p.Controls
            If c.BackColor = golden And c.Tag <> "" Then c.BackColor = defa : c.Text = c.Tag
        Next

    End Sub
End Class