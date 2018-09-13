Public Class movement
    Public carrier As cunit, mover As cunit, notfired As Boolean, tactical_option As Integer = -1, tac As Integer = 0, tac_less_move As Integer = 0, tac_opt_txt As String = "", tactical As Integer, observing As Boolean, scoot As Boolean
    Dim commander As New cunit, subject As New cunit, j As Integer, k As Integer = -1, recovermsg As String, cover_selected As Boolean = False, select_count As Integer, supportee As String = ""
    Dim comdpoints As Integer = 0, ca As Boolean = False, spt As Boolean = False, select_all As Boolean = False, stabilised As Boolean = False, not_conc As Boolean = False

    Private Sub allocate_Click(sender As Object, e As EventArgs) Handles allocate.Click
        If supportee <> "" Then
            For Each l As ListViewItem In undercommand.Items
                If l.BackColor = golden And orbat(l.Text).indirect Then
                    orbat(l.Text).primary = supportee
                    orbat(l.Text).task = "DS"
                    l.BackColor = in_ds
                End If
            Next
            units.FindItemWithText(supportee).BackColor = defa
        End If
        movement_actions.Visible = True
        arty_allocation.Visible = False
        executeorders.Enabled = True
    End Sub

    Private Sub select_unit_to_support(sender As Object, e As EventArgs) Handles units.Click
        If units.FocusedItem.BackColor = golden Then
            units.FocusedItem.BackColor = nostatus
            supportee = ""
        Else
            units.FocusedItem.BackColor = golden
            If supportee <> "" Then units.FindItemWithText(supportee).BackColor = nostatus
            supportee = units.FocusedItem.Text
        End If
        units.SelectedItems.Clear()
    End Sub


    Private Sub comdtree_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles comdtree.NodeMouseClick

        Dim x As Integer = 1, parentnode As New TreeNode
        If comdtree.SelectedNode Is Nothing Then Exit Sub
        'selectunit(orbat(e.Node.Text))
        'If commanders.Items.Count <> 1 And commander.title = e.Item.Text Then Exit Sub
        mark_ooc(comdtree.Nodes)
        commander = orbat(e.Node.Text)
        undercommand.Items.Clear()
        comdtree.HideSelection = True
        If Tag = "Movement" And commander.comdpts = 0 Then
            update_title("Units Under Command")
            Exit Sub
        End If
        If e.Node.BackColor <> golden Then e.Node.BackColor = golden
        undercommand.Focus()
        update_title(commander.title)
        populate_lists(undercommand, ph_units, Tag, commander.title)
        k = -1
        reset_unit_options()
    End Sub

    Private Sub count_selected_units()
        select_count = 0
        For Each l As ListViewItem In undercommand.Items
            If l.BackColor = golden Then
                select_count = select_count + 1
                If InStr(eq_list(orbat(l.Text).equipment).special, "s") > 0 Then stabilised = True Else stabilised = False
                If InStr(eq_list(orbat(l.Text).equipment).special, "d") > 0 Then not_conc = True Else not_conc = False
            End If
        Next
    End Sub

    Private Sub mark_ooc(t As TreeNodeCollection)
        For Each tn As TreeNode In t
            If tn.Nodes.Count > 0 Then mark_ooc(tn.Nodes)
            If tn.BackColor = golden Then
                If orbat(tn.Text).ooc Then tn.BackColor = no_action_pts Else tn.BackColor = nostatus
            End If
        Next

    End Sub

    Private Sub select_unit() Handles undercommand.Click

        'If undercommand.SelectedItems.Count = 0 And selected_units > 0 Then Exit Sub
        'If list_cleared Then list_cleared = False : Exit Sub
        'If (Tag = "Air Tasking" And undercommand.FocusedItem.BackColor = Color.Pink) Or
        '(Tag <> "Morale Recovery" And undercommand.FocusedItem.BackColor = no_action_pts) Or
        '(Tag <> "Morale Recovery" And undercommand.FocusedItem.BackColor = disruptedstatus) Or
        ' undercommand.FocusedItem.BackColor = dead Then
        '    undercommand.SelectedItems.Clear()
        '    Exit Sub
        'End If

        If Tag = "Movement" Then commander.comdpts = 0
        k = undercommand.FocusedItem.Index
        subject = orbat(undercommand.FocusedItem.Text)
        If undercommand.FocusedItem.BackColor = golden Then undercommand.FocusedItem.BackColor = nostatus Else undercommand.FocusedItem.BackColor = golden
        count_selected_units()

        If select_count = 0 Then
            cover.Text = "None"
            cover.BackColor = defa
        End If
        set_actions()
        undercommand.SelectedItems.Clear()
    End Sub

    Private Sub set_actions()
        If select_count > 0 Then
            executeorders.Enabled = True
            opp_fire.Enabled = True
            unitcover.Enabled = True
            tactical_actions.Enabled = True
            If Tag = "Movement" Then
                If subject.Cover > 0 Then
                    cover.Text = "+" + Trim(Str(subject.Cover))
                    cover.BackColor = golden
                Else
                    cover.Text = "None"
                    cover.BackColor = defa
                End If
            End If
        Else
            tac = 0
            tac_less_move = tac
            For Each c As Control In tactical_actions.Controls
                c.BackColor = defa
            Next
            executeorders.Enabled = False
            opp_fire.Enabled = False
            unitcover.Enabled = False
            tactical_actions.Enabled = False

        End If
    End Sub

    Private Sub update_title(ByVal x As String)
        selected_hq.Text = "Units under comd of " + x
    End Sub

    Public Sub options_for(ByVal purpose As String)
        populate_command_structure(comdtree, ph, "Command")
        If purpose = "Movement" Then
            tactical_actions.Focus()
            undercommand.MultiSelect = True
            undercommand.Items.Clear()
            tactical_actions.Visible = True
            load_orders(purpose)
            tactical_actions.Text = purpose
            executeorders.Text = "Execute Tactical Orders"
            unitcover.Visible = True
            opp_fire.Visible = True
            opp_fire.BackColor = golden
        ElseIf purpose = "Morale Recovery" Then
            load_orders(purpose)
            tactical_actions.Focus()
            undercommand.MultiSelect = False
            tactical_actions.Text = "Morale Factors"
            tactical_actions.Visible = True
            executeorders.Text = "Recover Morale"
            unitcover.Visible = False
            opp_fire.Visible = False
        ElseIf purpose = "Area Fire" Or purpose = "CB Fire" Then
            tactical_actions.Focus()
            undercommand.MultiSelect = False
            undercommand.Items.Clear()
            tactical_actions.Visible = True
            load_orders(purpose)
            tactical_actions.Text = purpose
            executeorders.Text = "Execute Artillery Fire"
            unitcover.Visible = True
            opp_fire.Visible = True
        ElseIf purpose = "Morale Recovery" Then
            load_orders(purpose)
            tactical_actions.Focus()
            undercommand.MultiSelect = False
            tactical_actions.Visible = True
            executeorders.Text = "Recover Morale"
            unitcover.Visible = False
            opp_fire.Visible = False
        ElseIf purpose = "Air Tasking" Then
            undercommand.MultiSelect = True
            tactical_actions.Visible = True
            load_orders(purpose)
            tactical_actions.Text = purpose
            executeorders.Text = "Deploy Sortie"
            unitcover.Visible = False
            unitcover.Visible = False
            opp_fire.Visible = False
        ElseIf purpose = "Arty Tasking" Then
            undercommand.MultiSelect = True
            tactical_actions.Visible = True
            load_orders(purpose)
            tactical_actions.Text = purpose
            executeorders.Text = "Send Orders"
            unitcover.Visible = False
            unitcover.Visible = False
            opp_fire.Visible = False
        ElseIf purpose = "Command" Then
            movement_actions.Visible = True
            form_function.Tag = form_function.Text
            form_function.Text = "Command Tasks"
            tactical_actions.Visible = True
            load_orders("Command")
            tactical_actions.Text = "Commands"
            executeorders.Text = "Execute Commands"
            opp_fire.Visible = False
            unitcover.Visible = False
        Else

        End If


    End Sub

    Private Sub select_cover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If select_count <= 0 Then Exit Sub
        cover_selected = True
        If cover.Text = "None" Then
            cover.Text = "+1" : cover.BackColor = Color.DarkGoldenrod
        ElseIf cover.Text = "+1" Then
            cover.Text = "+2"
        ElseIf cover.Text = "+2" Then
            cover.Text = "+3"
        ElseIf cover.Text = "+3" Then
            cover.Text = "None" : cover.BackColor = defa
        Else
        End If
        For Each l As ListViewItem In undercommand.Items
            If l.BackColor = golden Then
                orbat(l.Text).cover = Val(cover.Text)
                l.SubItems(3).Text = IIf(cover.Text <> "None", cover.Text, "")
            End If
        Next
        'subject.Cover = Val(cover.Text)
    End Sub

    Private Sub Execute_orders() Handles executeorders.Click
        If Tag = "Movement" Then
            movement_orders()
        ElseIf Tag = "Command" Then
            command_orders
        Else
        End If
    End Sub

    Private Sub command_orders()
        Dim comdcost As Integer = 0
        For Each a As Control In tactical_actions.Controls
            If a.BackColor = golden Then
                tactical_option = Val(a.Tag)
                Select Case tac

                    Case 0
                        'out of command
                        For Each l As ListViewItem In undercommand.Items
                            If l.BackColor = golden Then
                                l.BackColor = defa
                                orbat(l.Text).ooc = True
                                orbat(l.Text).status(Tag)
                                If Strings.Left(l.Text, 2) = "HQ" Then orbat(orbat(l.Text).parent).ooc = True
                            End If
                        Next
                    Case 1
                                    'line of supply broken
                    Case 2
                                    'out of supply
                    Case 3
                        'Allocate Artillery
                        'If Not mover.indirect Then Exit Select
                        movement_actions.Visible = False
                        arty_allocation.Visible = True
                        executeorders.Enabled = False
                        allocate.Enabled = True
                End Select
            End If
        Next

    End Sub
    Private Sub movement_orders()
        Dim comdcost As Integer = 0, tactical_option As Integer
        For Each l As ListViewItem In undercommand.Items
            mover = New cunit
            mover = orbat(l.SubItems(0).Text)
            If l.BackColor = golden Then
                For Each a As Control In tactical_actions.Controls
                    If a.BackColor = golden Then
                        tactical_option = Val(a.Tag)
                        Select Case tactical_option
                            Case 0
                                'move
                                If mover.has_fired Or mover.has_moved_fired Then Exit Select
                                conduct_fire(tactical_option)
                            Case 1
                                'half fire
                                If mover.has_moved Or mover.has_moved_fired Then Exit Select
                                mover.moved = gt
                                If mover.indirect Then mover.eligibleCB = False
                                If oppfire Then conduct_fire(tactical_option)
                            Case 2
                                'conduct close assault
                                If mover.assault Or mover.support Then Exit Select
                                If oppfire Then conduct_fire(tactical_option)
                                If mover.disrupted_gt Then Exit Select
                                assault.attacker = mover
                                conduct_assault()
                            Case 3
                                'dismount
                                If Not mover.embussed Or mover.debussed_gt Or mover.dismounted Then Exit Select
                                If oppfire Then conduct_fire(tactical_option)
                                Dim listitem As New ListViewItem, nu As New cunit
                                nu = orbat(mover.carrying)
                                mover.debus()
                                l.SubItems(3).Text = Replace(l.SubItems(3).Text, "*", "")
                                With listitem
                                    .Text = nu.title
                                    .SubItems.Add(nu.strength)
                                    .SubItems.Add(UCase(Strings.Left(nu.mode, 1)))
                                    .SubItems.Add(IIf(nu.Cover > 0, "+" + Trim(Str(nu.Cover)), ""))
                                    .SubItems.Add(nu.equipment)
                                End With
                                undercommand.Items.Insert(l.Index + 1, listitem)
                            Case 4
                                'embuss
                                If mover.embussed Or mover.debussed_gt Or Not mover.dismounted Then Exit Select
                                If oppfire Then conduct_fire(tactical_option)
                                mover.embus()
                                undercommand.Items.Remove(l)
                                undercommand.Items(undercommand.FindItemWithText(mover.carrying).Index).SubItems(4).Text = undercommand.Items(undercommand.FindItemWithText(mover.carrying).Index).SubItems(4).Text + "*"
                            Case 5, 6, 7
                                'change modes
                                Dim prev_mode As String = mover.mode
                                If oppfire Then conduct_fire(tactical_option)

                                If prev_mode = mover.mode Then
                                    If tactical_option = 5 And mover.conc Then
                                        If mover.mode = travel Then
                                            mover.mode = conc
                                        ElseIf mover.mode = conc Then
                                            mover.mode = travel
                                        Else
                                        End If
                                    ElseIf tactical_option = 6 And mover.conc Then
                                        If mover.mode = conc Then
                                            mover.mode = disp
                                        ElseIf mover.mode = disp Then
                                            mover.mode = conc
                                        Else
                                        End If
                                    Else
                                        If mover.mode = travel Then
                                            mover.mode = disp
                                        ElseIf mover.mode = disp Then
                                            mover.mode = travel
                                        Else
                                        End If
                                    End If
                                    l.SubItems(2).Text = UCase(Strings.Left(mover.mode, 1))
                                End If
                                'Case 15
                                '    mover.moved = gt
                                '    mover.fired = gt
                                '    comdcost = 3
                                'Case 16
                                '    If (tactical = 0 And InStr(mover.equipment, "AS") = 0) Or
                                '        (tactical = 1 And InStr(mover.equipment, "EW") = 0) Or
                                '        (tactical = 2 And InStr(mover.equipment, "GA") = 0) Or
                                '        (tactical = 3 And InStr(mover.equipment, "SO") = 0) Or
                                '        (tactical = 4 And InStr(mover.equipment, "SEAD") = 0) Or
                                '        (tactical = 5 And Not mover.heli And Not mover.role = "|AH|") Or
                                '        (tactical = 6 And Not mover.heli) Then Exit Select
                                '    dice = d10()
                                '    If (dice <= mover.quality Or dice = 1) And dice <> 10 Then
                                '        With mover
                                '            .airborne = True
                                '            .fired = IIf(mover.heli, 0, gt)
                                '            .task = tac_opt_txt
                                '        End With
                                '        With l
                                '            .BackColor = Color.Aquamarine
                                '            .SubItems(2).Text = IIf(Len(tac_opt_txt) < 4, tac_opt_txt, Strings.Left(tac_opt_txt, 4))
                                '        End With
                                '        If tactical = 6 Then
                                '            populate_lists(unit_selection.units, ph_hqs, "Observee", "commanders")
                                '        End If
                                '    Else
                                '        l.BackColor = Color.Pink
                                '    End If
                                'Case 17
                                '    If l.BackColor <> golden Or mover.effective Then comdcost = 0 : Exit Select
                                '    Dim recovermsg As String = ""
                                '    With morale_test
                                '        .Tag = Tag
                                '        .tester = mover
                                '        .rallying = IIf(o5.BackColor = golden, False, True)
                                '        .modifier = tac
                                '        .testing(Me.executeorders, Nothing)
                                '        .rallying = False
                                '    End With
                                '    With resultform_2
                                '        .result.Text = morale_test.test_result.Text
                                '        .ShowDialog()
                                '    End With
                                '    mover.effective = True
                                '    l.Remove()
                                'Case 20
                                '    'out of command
                                'Case 21
                                '    'line of supply broken
                                'Case 22
                                '    ' out of supply
                                'Case 23
                                '    'Allocate Artillery
                                '    If Not mover.indirect Then Exit Select
                                '    movement_actions.Visible = False
                                '    arty_allocation.Visible = True
                                '    executeorders.Enabled = False
                                '    allocate.Enabled = True
                        End Select
                        'If tactical_option <> 16 Then l.BackColor = mover.status(Me.Name)
                        If Not mover Is Nothing Or mover.title <> "" Then
                            'If tactical_option <= 9 Then
                            '    l.SubItems(1).Text = mover.strength
                            '    l.SubItems(2).Text = UCase(Strings.Left(mover.mode, 1))
                            'ElseIf tactical_option >= 20 Then
                            '    If mover.primary <> commander.title And commander.title <> mover.parent Then l.Remove()
                            'Else
                            'End If
                            If cover_selected Then mover.Cover = Val(cover.Text)
                        End If
                    End If
                Next

            End If
        Next
        'If ca And spt Then conduct_assault()
        update_title(commander.title)
        reset_unit_options()
        tactical_option = 0
        cover_selected = False
    End Sub

    Private Sub conduct_fire(opt As Integer)
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        Dim t As ListViewItem
        t = New ListViewItem
        With t
            .Text = mover.title
            .SubItems.Add(IIf(mover.aircraft, mover.strength - mover.aborts, mover.strength))
            .SubItems.Add(mover.equipment)
            .BackColor = golden
        End With
        If opt <> 1 Then
            populate_lists(combat_2.firers, enemy, "Opportunity Fire", nph)
            With combat_2
                .firer = New cunit
                .target = mover
                .targets.Items.Add(t)
                .nt = 0
                .update_parameters("targets")
                .Tag = "Opportunity Fire"
                .Text = "Opportunity Fire for " + gameturn
            End With
        ElseIf opt = 1 Then
            populate_lists(combat_2.targets, enemy, "Direct Fire", nph)
            With combat_2
                .firers.Items.Add(t)
                .firer = mover
                .target = New cunit
                .nf = 0
                .update_parameters("firers")
                .firer_strength(combat_2.s1, combat_2.s2, combat_2.s3, mover.firers_available)
                .Tag = "Direct Fire"
                .Text = "Moving Fire for " + gameturn
            End With
        Else

        End If

        With combat_2
            .enable_controls()
            .observation(False)
            .firesmoke.Visible = False
            .abort_firer.Visible = False
            .abort_target.Visible = False
            .altitude.Visible = False
            .taltitude.Visible = False
            .range_not_needed = False
        End With

        If Not combat_2.Visible Then
            With combat_2
                .ShowDialog()
            End With
        End If

    End Sub

    Private Sub select_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selected_hq.Click
        If Not select_all Then select_all = True Else select_all = False
        For Each l As ListViewItem In undercommand.Items
            If select_all And Not orbat(l.Text).disrupted Then
                l.BackColor = golden
            ElseIf Not select_all Then
                If Tag = "Command" Then l.BackColor = orbat(l.Text).status(Tag) Else l.BackColor = nostatus
            Else
            End If
        Next
        count_selected_units()
        If select_count > 0 Then set_actions()
    End Sub

    Public Sub debus(ByVal unit As cunit, dismount As Boolean)
        'subject = orbat(unit.carrying)
        'With subject
        '    .parent = unit.parent
        '    '.strength = unit.strength * (.initial / unit.initial)
        '    .firers = unit.firers
        '    .moved = gt
        '    .fired = unit.fired
        '    .lostcomms = unit.lostcomms
        '    .mode = unit.mode
        '    .debussed = unit.debussed
        'End With
        'If dismount Then
        '    subject.carrying = ""
        '    unit.carrying = ""
        'End If
    End Sub

    Private Sub embus(ByVal unit As cunit)
        'If unit.debussed And unit.carrying <> "" Then
        '    unit.debussed = False
        '    debus(unit, False)
        'Else
        '    populate_lists(unit_selection.units, ph_units, "Transport", unit.parent)
        '    If unit_selection.units.Items.Count = 0 Then Exit Sub
        '    carrier = New cunit
        '    With unit_selection
        '        .Tag = "Transport"
        '        .title.Text = "Choose which transport to load " + unit.title + " onto"
        '        .ShowDialog()
        '    End With
        '    If carrier Is Nothing Then Exit Sub
        '    unit.debussed = False
        '    unit.carrying = carrier.title
        '    debus(unit, False)
        '    carrier = Nothing
        'End If
    End Sub

    Private Sub opp_fire_clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If opp_fire.BackColor = defa Then
            opp_fire.BackColor = golden
            oppfire = True
        Else
            opp_fire.BackColor = defa
            oppfire = False
        End If
    End Sub

    Private Sub reset_unit_options()
        select_all = False
        tactical_actions.Enabled = False
        tac = 0
        selected_hq.Text = ""
        load_orders(Tag)
        opp_fire.BackColor = golden
        With cover
            .Text = "None"
            .BackColor = defa
        End With
        'k = -1
        'comdpoints = commander.comdpts
        update_title(commander.title)
        'Me.Focus()
        undercommand.SelectedItems.Clear()
    End Sub

    Private Sub movement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Tag = "Movement" Then mov_rates.Show()
        opportunityfire.Tag = "Opportunity Fire"
        opp_fire.BackColor = golden : oppfire = True
    End Sub

    Private Sub movement_closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Closed
        For Each i As ListViewItem In undercommand.Items
            i.Remove()
        Next
        If Tag = "Movement" Then mov_rates.Hide()
        selected_hq.Text = "Units"
    End Sub

    Private Sub load_orders(ByVal purpose As String)
        If purpose = "Movement" Then
            o0.Text = "Fire"
            o1.Text = "Move"
            o2.Text = "Close Assault"
            o3.Text = "Dismount "
            o4.Text = "Embus "
            o5.Text = "Travel<>Conc "
            o6.Text = "Conc<>Disp "
            o7.Text = "Travel<>Disp"
            o8.Text = ""
            o9.Text = ""
        ElseIf purpose = "Air Tasking" Then
            o0.Text = "CAP"
            o1.Text = "EW Support"
            o2.Text = "CAS"
            o3.Text = "Strike"
            o4.Text = "SEAD"
            o5.Text = "AH Mission"
            o6.Text = "Observation"
            o7.Text = ""
            o8.Text = ""
            o9.Text = ""
        ElseIf purpose = "Arty Tasking" Then
            o0.Text = "Area Fire"
            o1.Text = "Interdiction"
            o2.Text = "Counter Battery"
            o3.Text = "Direct Support"
            o4.Text = ""
            o5.Text = ""
            o6.Text = ""
            o7.Text = ""
            o8.Text = ""
            o9.Text = ""
        ElseIf purpose = "Morale Recovery" Then
            o0.Text = "In contact with undisrupted comd HQ (-2)"
            o1.Text = "< 600m of undisrupted comd HQ (-2)"
            o2.Text = "Undisrupted unit from own Bn < 600m (-1)"
            o3.Text = "Under Chemical Attack (2)"
            o4.Text = "Under Nuclear Attack (3)"
            o5.Text = "Disrupted fnds <600m (0)"
            o6.Text = ""
            o7.Text = ""
            o8.Text = ""
            o9.Text = ""
        ElseIf purpose = "Area Fire" Or purpose = "CB Fire" Then
            o0.Text = ""
            o1.Text = "Fire (2)"
            o2.Text = "Shoot and Scoot (4)"
            o3.Text = ""
            o4.Text = ""
            o5.Text = ""
            o6.Text = ""
            o7.Text = ""
            o8.Text = ""
            o9.Text = ""
        ElseIf purpose = "Command" Then
            o0.Text = "Out of Command"
            o1.Text = "Line of Supply broken"
            o2.Text = "Out of Supply"
            o3.Text = "Allocate Artillery"
            o4.Text = ""
            o5.Text = ""
            o6.Text = ""
            o7.Text = ""
            o8.Text = ""
            o9.Text = ""

        Else

        End If
        For Each ctrl In tactical_actions.Controls
            If Strings.Left(ctrl.name, 1) = "o" Then
                ctrl.backcolor = defa
                If ctrl.text = "" Then ctrl.visible = False Else ctrl.visible = True
            End If
        Next

    End Sub

    Private Sub orders_changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles o0.Click, o1.Click, o2.Click, o3.Click, o4.Click, o5.Click, o6.Click, o7.Click, o8.Click, o9.Click
        Dim t As Integer = Val(Strings.Right(sender.name, 1))

        If Tag = "Morale Recovery" Then
            tac_opt_txt = ""
            If sender.BackColor = golden Then
                sender.backcolor = defa
                tac = tac - t
            Else
                sender.backcolor = golden
                tac = tac + t
            End If
        ElseIf Tag = "Command" Then
            For Each c As Control In tactical_actions.Controls
                If c.BackColor = golden And sender.name <> c.Name Then c.BackColor = defa
            Next
            If sender.backcolor = golden Then sender.backcolor = defa : tac = -1 Else sender.backcolor = golden : tac = t
        ElseIf Tag = "Movement" Then
            Dim x As Integer = select_count
            If t = 1 And sender.backcolor = golden Then
                tac = tac_less_move : tac_less_move = 0
                sender.backcolor = defa
            ElseIf t = 1 And sender.backcolor = defa Then
                tac_less_move = tac
                tac = 4
                sender.backcolor = golden
            ElseIf sender.backcolor = defa And tac < 4 Then
                If tac <= 3 And stabilised And t = 0 Then
                    tac = tac + 1
                    sender.backcolor = golden
                ElseIf tac <= 2 And Not stabilised And t = 0 Then
                    tac = tac + 2
                    sender.backcolor = golden
                ElseIf tac = 0 And not_conc And t = 8 Then
                    tac = tac + 4
                    sender.backcolor = golden
                ElseIf tac <= 2 And Not not_conc And t = 8 Then
                    tac = tac + 2
                    sender.backcolor = golden
                ElseIf t = 3 Then
                    tac = tac + 0
                    sender.backcolor = golden
                ElseIf tac <= 2 And (t > 1 And t <> 8) Then
                    tac = tac + 2
                    sender.backcolor = golden
                Else
                End If
            ElseIf sender.backcolor = golden Then
                If stabilised And t = 0 Then
                    tac = tac - 1
                ElseIf Not stabilised And t = 0 Then
                    tac = tac - 2
                ElseIf t = 1 Then
                    tac = tac_less_move
                    tac_less_move = 0
                ElseIf not_conc And t = 8 Then
                    tac = tac - 4
                ElseIf Not not_conc And t = 8 Then
                    tac = tac - 2
                ElseIf t = 4 Then
                    tac = tac + 0
                ElseIf (t > 1 And t <> 8) Then
                    tac = tac - 2
                Else
                End If
                sender.backcolor = defa
                If tac_less_move <= 2 And o1.BackColor = golden Then
                    tac_less_move = 0
                    tac = 0
                End If
            Else
            End If
            'If t = 1 Then o1.BackColor = golden
            If tac = 0 Then
                o1.Text = "Move"
                o1.BackColor = defa
            ElseIf tac = 1 Then
                o1.Text = "Move up to 3/4"
            ElseIf tac = 2 Then
                o1.Text = "Move up to 1/2"
            ElseIf tac = 3 Then
                o1.Text = "Move up to 1/4"
            Else
                o1.Text = "Move Allowance used"
            End If
        Else

            If sender.backcolor = defa Or (sender.name = "o0" And sender.text = "Half Move (2)" And sender.backcolor = golden) Or (sender.name = "o1" And sender.text = "Fire (2)" And sender.backcolor = golden) Then
                If sender.name = "o0" And sender.text = "Half Move (2)" And sender.backcolor = golden Then sender.text = "Full Move (4)" : t = t + 2
                If sender.name = "o1" And sender.text = "Fire (2)" And sender.backcolor = golden Then sender.text = "Call for Fire (2)"
                sender.backcolor = golden
                tac_opt_txt = sender.text
                tac = t
            Else
                sender.backcolor = defa
                If sender.name = "o0" And sender.text = "Full Move (4)" Then sender.text = "Half Move (2)"
                If sender.name = "o1" And sender.text = "Call for Fire (2)" Then sender.text = "Fire (2)"
                tac = 0
                tac_opt_txt = ""
            End If
            If opp_fire.Visible And opp_fire.BackColor = golden And sender.name = "o1" Then opp_fire_clicked(opp_fire, Nothing)
        End If

    End Sub

    Private Sub conduct_assault()
        With assault
            .supports.Items.Clear()
            .a_arty.Items.Clear()
            .defenders.Items.Clear()
            .d_arty.Items.Clear()
            .assaulting.Text = assault.attacker.title
            .reset_factors()
            .defender = New cunit
            .supporter = New cunit
        End With

        populate_lists(assault.supports, ph_units, "CA Supports", "")
        populate_lists(assault.a_arty, ph_units, "Artillery Support", assault.attacker.parent)
        populate_lists(assault.defenders, enemy, "CA Defenders", "")
        assault.ShowDialog()

        'undercommand.Items(assault.attacker.sorties).BackColor = assault.attacker.status(Me.Name)
        'undercommand.Items(assault.supporter.sorties).BackColor = assault.supporter.status(Me.Name)

    End Sub


End Class