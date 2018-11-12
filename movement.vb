Public Class movement
    Public carrier As cunit, mover As cunit, notfired As Boolean, tactical_option As Integer = -1, tac As Integer = 0, tac_less_move As Integer = 0, tac_opt_txt As String = "", tactical As Integer, observing As Boolean, scoot As Boolean
    Dim commander As New cunit, subject As New cunit, j As Integer, k As Integer = -1, recovermsg As String, cover_selected As Boolean = False, select_count As Integer, supportee As String = ""
    Dim comdpoints As Integer = 0, ca As Boolean = False, spt As Boolean = False, select_all As Boolean = False, stabilised As Boolean = False, not_conc As Boolean = False

    Private Sub allocate_Click(sender As Object, e As EventArgs) Handles allocate.Click
        If (tactical_option = 3 Or tactical_option = 5) And supportee <> "" Then
            For Each l As ListViewItem In undercommand.Items
                If l.BackColor = golden And (orbat(l.Text).indirect Or orbat(l.Text).task = "Observation" Or orbat(l.Text).task = "DS") Then
                    orbat(l.Text).primary = supportee
                    orbat(l.Text).task = "DS"
                    l.BackColor = in_ds
                End If
            Next
            units.FindItemWithText(supportee).BackColor = defa
        ElseIf tactical_option = 7 And units.SelectedItems.Count <= 3 Then
            Dim r As String = ""
            For Each l As ListViewItem In units.Items
                If l.BackColor = golden Then
                    Dim j As Integer = orbat(subject.parent).arty_int - 1 + enemy(l.Text).sorties * 2 - subject.initial + subject.strength
                    If j > 9 Then j = 9
                    If j <= 0 Then j = 0
                    If d10() >= arty_location(j, enemy(l.Text).arty_type) Then
                        r = r + l.Text + vbNewLine
                        enemy(l.Text).eligibleCB = True
                    End If
                End If
            Next
            If r <> "" Then
                With resultform_2
                    .result.Text = "The following batterys have been located" + vbNewLine + r
                    .ShowDialog()
                End With
            End If
        End If
        set_allocation(False)
    End Sub

    Private Sub units_SelectedIndexChanged(sender As Object, e As EventArgs) Handles units.Click
        If tactical_option = 7 Then
            Dim i As Integer = 0
            For Each l As ListViewItem In units.Items
                If l.BackColor = golden Then i = i + 1

            Next
            If i <= 2 Or (i = 3 And units.FocusedItem.BackColor = golden) Then
                If units.FocusedItem.BackColor = golden Then units.FocusedItem.BackColor = nostatus Else units.FocusedItem.BackColor = golden
            End If
        Else
            For Each l As ListViewItem In units.Items
                l.BackColor = nostatus
            Next
            supportee = units.FocusedItem.Text
            units.FocusedItem.BackColor = golden
        End If
        units.FocusedItem.Selected = False
    End Sub
    Private Sub set_allocation(setting As Boolean)
        If setting Then
            units.Items.Clear()
            If tactical_option = 3 Or tactical_option = 5 Then
                populate_lists(units, ph_hqs, "Command", "")
                units.MultiSelect = False
                command_function.Text = "Provide Direct Support to"
                allocate.Text = "Support"
                For Each l As ListViewItem In units.Items
                    l.BackColor = nostatus
                    If l.Text = subject.primary Then l.BackColor = golden
                Next
            ElseIf tactical_option = 7 Then
                populate_lists(units, enemy, "CB Targets", "")
                command_function.Text = "Artillery to attempt to Locate"
                allocate.Text = "Locate"
                units.MultiSelect = True
            Else
            End If

        End If
        movement_actions.Visible = Not setting
        arty_allocation.Visible = setting
        executeorders.Enabled = Not setting
        allocate.Enabled = setting

    End Sub



    Private Sub comdtree_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles comdtree.NodeMouseClick

        Dim x As Integer = 1, parentnode As New TreeNode
        If comdtree.SelectedNode Is Nothing Then Exit Sub
        'selectunit(orbat(e.Node.Text))
        'If commanders.Items.Count <> 1 And commander.title = e.Item.Text Then Exit Sub
        If tactical_actions.Text = "Air Tasking" Or tactical_actions.Text = "Helarm Tasking" Then o9.Text = "Return to Command" : end_air_tasking(o9, Nothing)
        If arty_allocation.Visible Then set_allocation(False)
        'mark_ooc(comdtree.Nodes)
        commander = orbat(e.Node.Text)
        reset_comd_nodes(comdtree.Nodes(0))

        undercommand.Items.Clear()
        comdtree.HideSelection = True
        If Tag = "Movement" And commander.comdpts = 0 Then
            update_title("Units Under Command")
            Exit Sub
        End If
        If e.Node.BackColor <> golden Then e.Node.BackColor = golden

        Me.Focus()
        update_title(commander.title)
        populate_lists(undercommand, ph_units, IIf(InStr(Tag, "Command") > 0, "Command", Tag), commander.title)
        If InStr(Tag, "Command") > 0 Then
            If commander.role = "Air HQ" Then
                populate_lists(undercommand, friend_air, "Command", commander.title)
                undercommand.Columns(3).Text = "Msn"
            Else
                undercommand.Columns(3).Text = "Cover"
            End If
            If arty_allocation.Visible Then arty_allocation.Visible = False
        ElseIf Tag = "Movement" Then
            populate_lists(undercommand, friend_air, Tag, commander.title)
        Else
        End If
        k = -1
        reset_unit_options()
    End Sub
    Private Sub reset_comd_nodes(node As TreeNode)
        For Each n As TreeNode In node.Nodes
            n.BackColor = ph_hqs(n.Text).status(Tag)
            reset_comd_nodes(n)
        Next
        node.BackColor = ph_hqs(node.Text).status(Tag)

    End Sub
    Private Sub count_selected_units()
        select_count = 0
        For Each l As ListViewItem In undercommand.Items
            If subject.title = l.Text And Tag = "Morale Recovery" And (l.BackColor = disruptedstatus Or l.BackColor = may_test Or BackColor = must_test) Then select_count = 1 : Exit Sub
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
        k = undercommand.FocusedItem.Index
        subject = orbat(undercommand.FocusedItem.Text)
        If arty_allocation.Visible Then set_allocation(False)
        If Tag = "Movement" Then
            Dim lv As ListViewItem
            If Tag = "Movement" Then commander.comdpts = 0
            If undercommand.FocusedItem.BackColor = golden Then
                undercommand.FocusedItem.BackColor = subject.status("movement")
                lv = undercommand.FocusedItem
                undercommand.FocusedItem.Remove()
                undercommand.Items.Insert(undercommand.Items.Count, lv)
            Else
                undercommand.FocusedItem.BackColor = golden
                lv = undercommand.FocusedItem
                undercommand.FocusedItem.Remove()
                undercommand.Items.Insert(select_count, lv)
            End If
        ElseIf InStr(Tag, "Command") > 0 And subject.aircraft Then
            If undercommand.FocusedItem.BackColor <> golden And select_count = 1 Then
                For Each l As ListViewItem In undercommand.Items
                    l.BackColor = friend_air(l.Text).status(Tag)
                Next
            End If
            If subject.validunit("Select Air Unit", subject.parent) Then
                undercommand.FocusedItem.BackColor = golden
                If Not subject.role = "|AH|" And tactical_actions.Text = "Helarm Tasking" Then options_for("Air Tasking")
                If subject.role = "|AH|" And tactical_actions.Text <> "Helarm Tasking" Then options_for("Helarm Tasking")
                If subject.heli And (subject.task = "Observation" Or subject.task = "DS") Then tactical_option = 5 : set_allocation(True)
            End If
            For Each c As RadioButton In flight_strength.Controls
                If c.Checked Then c.Checked = False
            Next
        ElseIf InStr(Tag, "Command") > 0 Then
            If Not subject.validunit("Select Unit", subject.parent) Then
            Else
                If undercommand.FocusedItem.BackColor = golden Then undercommand.FocusedItem.BackColor = subject.status("Command") Else undercommand.FocusedItem.BackColor = golden
            End If
        ElseIf Tag = "Morale Recovery" Then
            If subject.strength = 0 Or subject.effective Then undercommand.SelectedItems.Clear() : Exit Sub
            If (undercommand.FocusedItem.BackColor <> nostatus And undercommand.FocusedItem.BackColor <> golden) Or Not (o9.BackColor = golden And (undercommand.FocusedItem.BackColor = nostatus Or undercommand.FocusedItem.BackColor = golden)) Then
                For Each l As ListViewItem In undercommand.Items
                    l.BackColor = ph_units(l.Text).status(Tag)
                Next
            End If
            If undercommand.FocusedItem.BackColor <> nostatus And undercommand.FocusedItem.BackColor <> golden Then
                If o9.BackColor = golden Then orders_changed(o9, Nothing)
                If opp_fire.Text = "" Or opp_fire.Text <> subject.title Then
                    opp_fire.Text = subject.title
                    set_morale_factors(True)
                Else
                    opp_fire.Text = ""
                    set_morale_factors(False)
                End If
                If undercommand.FocusedItem.BackColor = may_test Then
                    For i As Integer = 2 To 6
                        If Val(Mid(subject.msg, i, 1)) = 1 Then
                            Select Case i
                                Case 2, 4
                                    orders_changed(o3, Nothing)
                                Case 3
                                    If o2.BackColor <> golden Then orders_changed(o2, Nothing)
                                Case 5
                                    orders_changed(4, Nothing)
                                Case 6
                                    orders_changed(o5, Nothing)
                            End Select
                        End If
                    Next
                End If

            Else
                If undercommand.FocusedItem.BackColor = nostatus Then
                    undercommand.FocusedItem.BackColor = golden
                    If o9.BackColor <> golden Then set_morale_factors(True)
                ElseIf undercommand.FocusedItem.BackColor = golden Then
                    undercommand.FocusedItem.BackColor = nostatus
                    If select_count = 1 And o9.BackColor = golden Then orders_changed(o9, Nothing)
                Else
                End If
                opp_fire.Text = ""
                count_selected_units()
                set_actions()
            End If
        Else
        End If
        If Not Tag = "Morale Recovery" Then
            'opp_fire.Text = ""
            count_selected_units()
            set_actions()
        End If
        undercommand.SelectedItems.Clear()
    End Sub
    Private Sub set_morale_factors(setting As Boolean)
        tactical_actions.Enabled = setting
        executeorders.Enabled = setting
        If setting Then
            For Each c As Control In tactical_actions.Controls
                c.BackColor = defa
                If c.Name = "o2" Then c.Text = "0 disrupted friends within 1000m"
            Next
        End If


    End Sub

    Private Sub set_actions()
        If select_count > 0 Then
            If tactical_actions.Visible = True Then executeorders.Enabled = True
            opp_fire.Enabled = True
            unitcover.Enabled = True
            executeorders.Enabled = IIf(Tag = "Morale Recovery" And o9.BackColor <> golden, False, True)
            tactical_actions.Enabled = True
            flight_strength.Enabled = True
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
            flight_strength.Enabled = False
            tactical_actions.Enabled = False
            For Each c As RadioButton In flight_strength.Controls
                If c.Checked Then c.Checked = False
            Next
        End If
    End Sub

    Private Sub update_title(ByVal x As String)
        selected_hq.Text = "Units under comd of " + x
    End Sub

    Public Sub options_for(ByVal purpose As String)
        If purpose <> "Morale Recovery" Then populate_command_structure(comdtree, ph, "Command") Else populate_command_structure(comdtree, ph, purpose)
        set_allocation(False)

        If purpose = "Movement" Then
            form_function.Text = "Movement Orders"
            tactical_actions.Focus()
            undercommand.MultiSelect = True
            undercommand.Items.Clear()
            load_orders(purpose)
            tactical_actions.Text = purpose
            executeorders.Text = "Execute Tactical Orders"
            unitcover.Visible = True
            oppfire = True
            opp_fire.Text = "Opportunity Fire"
            opp_fire.Visible = True
            opp_fire.BackColor = golden
            flight_strength.Visible = False
        ElseIf purpose = "Morale Recovery" Then
            form_function.Text = "Morale Tests"
            load_orders(purpose)
            tactical_actions.Focus()
            undercommand.MultiSelect = False
            tactical_actions.Text = "Morale Factors"
            executeorders.Text = "Test Morale"
            unitcover.Visible = False
            'opp_fire.Visible = False
            flight_strength.Visible = False
        ElseIf purpose = "Air Tasking" Or purpose = "Helarm Tasking" Then
            undercommand.MultiSelect = False
            load_orders(purpose)
            tactical_actions.Text = purpose
            executeorders.Text = "Deploy Sortie"
            unitcover.Visible = False
            opp_fire.Visible = False
            flight_strength.Visible = True
            flight_strength.Enabled = True
        ElseIf purpose = "Command" Or purpose = "Initial Command" Then
            form_function.Text = IIf(purpose = "Command", "Command Orders", "Pre-Game Initial Orders")
            movement_actions.Visible = True
            arty_allocation.Visible = False
            form_function.Tag = form_function.Text
            'form_function.Text = "Command Tasks"
            load_orders(purpose)
            tactical_actions.Text = "Commands"
            executeorders.Text = "Execute Commands"
            flight_strength.Visible = False
            opp_fire.Visible = False
            unitcover.Visible = False
            oppfire = False
        Else

        End If


    End Sub

    Private Sub select_cover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cover.Click
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
                l.BackColor = orbat(l.Text).status("movement")
                orbat(l.Text).cover = Val(cover.Text)
                l.SubItems(3).Text = IIf(cover.Text <> "None", cover.Text, "")
            End If
        Next
        'subject.Cover = Val(cover.Text)
    End Sub

    Private Sub Execute_orders() Handles executeorders.Click
        If Tag = "Movement" Then
            movement_orders()
        ElseIf Tag = "Morale Recovery" Then
            morale_tests()
        ElseIf InStr(Tag, "Command") > 0 And (tactical_actions.Text = "Air Tasking" Or tactical_actions.Text = "Helarm Tasking") Then
            air_tasks()
        ElseIf Tag = "Command" Then
            command_orders()
        ElseIf Tag = "Initial Command" Then
            initial_orders()
        Else
        End If
    End Sub
    Private Sub morale_tests()
        If o9.BackColor = golden Then
            For Each l As ListViewItem In undercommand.Items
                If l.BackColor = golden Then
                    With ph_units(l.Text)
                        .disrupted = True
                        .disrupted_gt = True
                        .effective = True
                        .msg = ""
                    End With
                    l.BackColor = ph_units(l.Text).status("Morale Recovery")
                End If
            Next
            o9.BackColor = defa
            Exit Sub
        Else
            Dim test_needed As Boolean = False, r As String = ""
            If undercommand.FindItemWithText(subject.title).Tag = "may test" Then
                test_needed = False
                For i As Integer = 2 To 6
                    If Val(Mid(subject.msg, i, 1)) = 1 Then
                        If ((i = 2 Or i = 4) And o3.BackColor = golden) Or (i = 3 And o2.BackColor = golden) Or (i = 5 And o4.BackColor = golden) Or (i = 6 And o5.BackColor = golden) Then test_needed = True : Exit For
                    End If
                Next
            ElseIf (subject.disrupted And Not subject.effective) Or undercommand.FindItemWithText(subject.title).Tag = "must test" Then
                test_needed = True
            End If
            Dim modifier As Integer = 0
            If test_needed Then test_morale(subject, Me.Controls, True) Else test_morale(subject, Me.Controls, False)
            subject.effective = True
            opp_fire.Text = ""
            If subject.strength = 0 Then
                undercommand.FindItemWithText(subject.title).Remove()
            Else
                With undercommand.FindItemWithText(subject.title)
                    .SubItems(1).Text = subject.strength
                    .SubItems(2).Text = UCase(Strings.Left(subject.mode, 1))
                    .BackColor = subject.status("Morale Recovery")
                    .Tag = ""
                End With
            End If
        End If
        'If ca And spt Then conduct_assault()
        update_title(commander.title)
        reset_unit_options()
    End Sub
    Private Sub command_orders()
        Dim comdcost As Integer = 0
        For Each a As Control In tactical_actions.Controls
            If a.BackColor = golden Then
                tactical_option = Val(Strings.Right(a.Name, 1))
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
                    Case 3, 5, 7
                        'Artillery Missions and observer
                        'If Not mover.indirect Then Exit Select
                        set_allocation(True)
                    Case 6
                        break_emcon()
                    Case 8
                        off_table(True)
                    Case 9
                        For Each l As ListViewItem In undercommand.Items
                            If l.BackColor = golden Then
                                l.BackColor = defa
                                With orbat(l.Text)
                                    .arrives = -1
                                    .moved = gt

                                End With
                                log_entry("Game Turn" + Str(gt) + " " + scenariodefaults.Current_time.Text + " " + l.Text + " Leaves the Table")
                            End If
                        Next
                End Select
            End If
        Next

    End Sub
    Private Sub break_emcon()
        For Each l As ListViewItem In undercommand.Items
            If l.BackColor = golden Then
                If orbat(l.Text).radar Then
                    orbat(l.Text).eligiblecb = True
                    orbat(l.Text).status("Command")
                End If
            End If
            l.BackColor = orbat(l.Text).status("Command")
        Next
    End Sub
    Private Sub off_table(on_table As Boolean)
        If on_table And Not (gt = 1 And phase = 0) Then
            Dim v As New cevents
            v.create_id()
            With v
                .side = subject.nation
                .unit = commander.title
                .time = ":00"
                .text = commander.title + " follows new order and arrives on table"
                .die = "None"
                ' .score = IIf(.die = "D6" And .score > 6, 6, Val(dice_score.Text))
                .score = 0
                .dec = False
            End With
            link_event_to_unit(commander.title, v.time)
            For Each u As cunit In ph_units
                If u.parent = commander.title Then
                    With u
                        .mode = travel
                        .moved = gt
                    End With
                End If

            Next
        ElseIf on_table Then
            link_event_to_unit(commander.title, Str(Hour(DateAdd(DateInterval.Hour, 1, gamedate))))
        ElseIf Not on_table Then
            link_event_to_unit(commander.title, "-1")
        Else
        End If
        For Each l As ListViewItem In undercommand.Items
            l.BackColor = defa
        Next
    End Sub

    Private Sub initial_orders()
        'Dim comdcost As Integer = 0
        For Each a As ListViewItem In undercommand.Items
            If a.BackColor = golden Then
                mover = New cunit
                mover = orbat(a.Text)
                subject = mover
                tactical_option = tac
                Select Case tac

                    Case 0, 1, 2
                        change_mode_action(a)
                    Case 3, 5
                        'Artillery Missions and observer
                        'If Not mover.indirect Then Exit Select
                        set_allocation(True)
                    Case 6
                        break_emcon()
                    Case 7
                        dismount_action(a)
                    Case 8
                        embus_action(a)
                    Case 9
                        off_table(False)
                End Select
            End If
        Next

    End Sub
    Private Sub select_air_tasking(sender As Object, e As EventArgs) Handles o4.Click
        If (sender.text = "Air Mission Planning" And commander.role = "Air HQ") Then
            If subject.helarm Then options_for("Helarm Tasking") Else options_for("Air Tasking")

        End If
    End Sub
    Private Sub end_air_tasking(sender As Object, e As EventArgs) Handles o9.Click
        If sender.text <> "Return to Command" Then Exit Sub
        If Tag = "Command" Then
            options_for("Command")
        ElseIf Tag = "Initial Command" Then
            options_for("Initial Command")
        Else
        End If

    End Sub

    Private Sub air_tasks()
        If Not subject.valid_air_mission(tac_opt_txt) Then Exit Sub
        Dim s As Integer = 0
        For Each c As RadioButton In flight_strength.Controls
            If c.Checked Then s = Val(c.Text) : Exit For
        Next
        If s = 0 Then Exit Sub
        Dim ac As New cunit
        ac = subject.Clone
        With ac
            .parent = subject.parent
            .airbase = subject.title
            .title = air_task_order(subject.parent)
            .task = tac_opt_txt
            .equipment = .equipment + .air_package
            .role = "|" + eq_list(ac.equipment).role + "|"
            .airborne = False
            .initial = 0
            .arrives = gt + 1
            .mode = ac.set_altitude
            .strength = s
            .missiles = IIf(ac.helarm, Val(Mid(tac_opt_txt, 4, 1)), 0)
            .rockets = IIf(ac.helarm, Val(Mid(tac_opt_txt, 6, 1)), 0)
        End With
        subject.strength = subject.strength - ac.strength
        undercommand.FindItemWithText(subject.title).SubItems(1).Text = subject.strength
        orbat.Add(ac, ac.title)
        If UCase(ac.nation) = UCase(p1) Then p1_air.Add(ac, ac.title) Else p2_air.Add(ac, ac.title)
        Dim l As New ListViewItem
        With l
            .Text = ac.title
            .SubItems.Add(ac.strength)
            .SubItems.Add(Strings.Left(ac.mode, 1))
            .SubItems.Add(ac.abbrev_air_mission)
            .SubItems.Add(ac.equipment)
            .BackColor = take_off
        End With
        undercommand.Items.Add(l)
    End Sub

    Private Function air_task_order(airunit As String)
        air_task_order = ""
        For i As Integer = 1001 To 9999
            air_task_order = Mid(Trim(Str(i)), 2) + "/" + airunit
            If Not orbat.Contains(air_task_order) Then Exit Function
        Next
    End Function

    Private Sub movement_orders()
        Dim comdcost As Integer = 0
        For Each l As ListViewItem In undercommand.Items
            If l.BackColor = golden Then
                l.Tag = ""
                mover = New cunit
                mover = orbat(l.SubItems(0).Text)
                For Each a As Control In tactical_actions.Controls
                    If a.BackColor = golden Then
                        tactical_option = Val(Strings.Right(a.Name, 1))
                        Select Case tactical_option
                            Case 0
                                'half fire
                                If mover.fire_phase and not mover.helarm Then Exit Select
                                conduct_fire(tactical_option)
                            Case 1
                                'move
                                If mover.fire_phase And Not mover.helarm Then Exit Select
                                If mover.ooc And d10() < 6 Then
                                    With resultform_2
                                        .result.Text = mover.title + " is out of command and has failed to move"
                                        .ShowDialog()
                                    End With
                                    Exit Select
                                End If
                                mover.moved = gt
                                If mover.indirect Then mover.eligibleCB = False : mover.sorties = 0
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
                                If Not mover.embussed Or mover.debussed_gt <> 0 Or mover.dismounted Then Exit Select
                                dismount_action(l)
                            Case 4
                                'embuss
                                If mover.embussed Or mover.debussed_gt <> 0 Or Not mover.dismounted Then Exit Select
                                embus_action(l)
                            Case 5, 6, 7
                                'change modes
                                'Dim prev_mode As String = mover.mode
                                change_mode_action(l)
                        End Select
                        'If tactical_option <> 16 Then l.BackColor = mover.status(Me.Name)
                        l.BackColor = mover.status("movement")
                        If Not mover Is Nothing Or mover.title <> "" Then
                            If cover_selected Then mover.Cover = Val(cover.Text)
                        End If
                        If mover.strength <= 0 Then Exit For
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

    Private Sub change_mode_action(l As ListViewItem)
        If oppfire Then conduct_fire(tactical_option)
        If mover.mode Is Nothing Then mover.mode = disp
        'If prev_mode = mover.mode Then
        Dim t_opt As Integer = IIf(Tag = "Initial Command", tactical_option + 5, tatical_option)
        If t_opt = 5 And mover.conc Then
            If mover.mode = travel Then
                mover.mode = conc
            ElseIf mover.mode = conc Then
                mover.mode = travel
            Else
            End If
        ElseIf t_opt = 6 And mover.conc Then
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
        If Not mover.conc And mover.mode = conc Then mover.mode = disp
        l.SubItems(2).Text = UCase(Strings.Left(mover.mode, 1))
        'End If
        mover.pre_mode = mover.mode
    End Sub

    Private Sub dismount_action(l As ListViewItem)
        'dismount
        If oppfire Then conduct_fire(tactical_option)
        Dim listitem As New ListViewItem, nu As New cunit
        nu = orbat(mover.carrying)
        mover.debus()
        l.SubItems(4).Text = Replace(l.SubItems(4).Text, "*", "")
        With listitem
            .Text = nu.title
            .SubItems.Add(nu.strength)
            .SubItems.Add(UCase(Strings.Left(nu.mode, 1)))
            .SubItems.Add(IIf(nu.Cover > 0, "+" + Trim(Str(nu.Cover)), ""))
            .SubItems.Add(nu.equipment)
        End With
        undercommand.Items.Insert(l.Index + 1, listitem)
    End Sub
    Private Sub embus_action(l As ListViewItem)
        If Not mover.can_embus() Then Exit Sub
        If oppfire Then conduct_fire(tactical_option)
        mover.embus()
        If mover.carrying = "" Then Exit Sub
        undercommand.Items.Remove(l)
        undercommand.Items(undercommand.FindItemWithText(mover.carrying).Index).SubItems(4).Text = undercommand.Items(undercommand.FindItemWithText(mover.carrying).Index).SubItems(4).Text + "*"

    End Sub
    Private Sub conduct_fire(opt As Integer)
        combat_2.targets.Items.Clear()
        combat_2.firers.Items.Clear()
        Dim t As ListViewItem
        t = New ListViewItem
        With t
            .Text = mover.title
            .SubItems.Add(mover.strength)
            .SubItems.Add(mover.equipment)
            .BackColor = golden
        End With
        If opt <> 0 Then
            If mover.helarm Then
                populate_lists(combat_2.firers, enemy, "Opportunity AA Fire", nph)
                With combat_2
                    .enable_controls(True, combat_2.directfirepanel)
                    .enable_controls(False, combat_2.targetpanel)
                    .ta_altitude_label.Visible = True
                    .ta_altitude.Visible = True
                End With
            Else
                populate_lists(combat_2.firers, enemy, "Opportunity Fire", "")
                populate_lists(combat_2.firers, enemy_air, "Opportunity Fire", "Air")
                With combat_2
                    .enable_controls(True, combat_2.directfirepanel)
                    .enable_controls(True, combat_2.targetpanel)
                    .ta_altitude_label.Visible = False
                    .ta_altitude.Visible = False
                End With
            End If

            With combat_2
                .firer = New cunit
                .target = mover
                .targets.Items.Add(t)
                .nt = 0
                .update_parameters("targets")
                .Tag = "Opportunity Fire"
                .Text = "Opportunity Fire for " + gameturn
            End With
        ElseIf opt = 0 Then
            populate_lists(combat_2.targets, enemy, "Ground Targets", nph)
            populate_lists(combat_2.targets, enemy_air, "Air Defence Targets", nph)
            With combat_2
                .directfirepanel.Visible = True
                .targetpanel.Visible = True
                .indirectfirepanel.Visible = False
                .enable_controls(True, combat_2.directfirepanel)
                .enable_controls(True, combat_2.targetpanel)
                .firers.Items.Add(t)
                .firer = mover
                .target = New cunit
                .nf = 0
                .update_parameters("firers")
                .firer_strength(combat_2.s1, combat_2.s2, combat_2.s3, mover.firers_available, mover.airborne)
                .Tag = "Half Fire"
                .Text = "Moving Fire for " + gameturn
            End With
        Else

        End If

        With combat_2
            .observation(False)
            .firesmoke.Visible = False
            .abort_firer.Visible = False
            .abort_target.Visible = False
            .range_not_needed = False
            .swap.Visible = False
        End With

        If Not combat_2.Visible Then
            With combat_2
                .ShowDialog()
            End With
        End If
        If opt <> 0 Then
            If mover.strength <= 0 Or mover.disrupted Then
                undercommand.FindItemWithText(mover.title).Remove()
            Else
                With undercommand.FindItemWithText(mover.title)
                    .SubItems(1).Text = mover.strength
                    .SubItems(2).Text = UCase(Strings.Left(mover.mode, 1))
                End With

            End If
        End If

    End Sub

    Private Sub select_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selected_hq.Click
        If undercommand.Items.Count = 0 Then Exit Sub
        If Not select_all Then
            subject = orbat(undercommand.Items(0).Text)
            select_all = True
        Else
            subject = New cunit
            select_all = False
            reset_tactical_actions()
            tactical_actions.Enabled = False

        End If
        Dim i As Integer = 1
        For Each l As ListViewItem In undercommand.Items
            If select_all And Not orbat(l.Text).disrupted Then
                l.BackColor = golden
                If Tag = "Movement" Then
                    l.Tag = Str(i)
                    i = i + 1
                End If
            ElseIf Not select_all Then
                If InStr(Tag, "Command") > 0 Then
                    l.BackColor = orbat(l.Text).status(Tag)
                ElseIf Tag = "Movement" Then
                    l.BackColor = orbat(l.Text).status("movement")
                ElseIf Tag = "Morale Recovery" Then
                    l.BackColor = orbat(l.Text).status(Tag)
                Else
                End If
                l.Tag = ""
            Else
            End If
        Next
        count_selected_units()
        If select_count > 0 Then set_actions()
    End Sub


    Private Sub opp_fire_clicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opp_fire.Click
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
        count_selected_units()
        tactical_actions.Enabled = False
        tac = 0
        selected_hq.Text = ""
        load_orders(Tag)
        opp_fire.BackColor = golden
        If Tag = "Movement" Then oppfire = True Else oppfire = False
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
        If Tag = "Movement" Then
            mov_rates.Show()
        End If
    End Sub

    Private Sub movement_closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Closed
        undercommand.Items.Clear()
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
            o1.Text = "Escort"
            o2.Text = "Ground Attack"
            o3.Text = "PGM"
            o4.Text = "SEAD"
            o5.Text = "AH Mission"
            o6.Text = "Observation"
            o7.Text = "ECM DS"
            o8.Text = "ECM GS"
            o9.Text = "Return to Command"
        ElseIf purpose = "Helarm Tasking" Then
            Dim lo As String = "", pay As Integer = eq_list(subject.equipment).payload
            For i As Integer = 0 To 8
                If pay - i >= 0 And (eq_list(subject.equipment).ordnance > 0 Or i = 0) Then lo = "AH " + Trim(Str(pay - i)) + "/" + Trim(Str(i)) Else lo = ""
                For Each c As Label In tactical_actions.Controls
                    If Val(Mid(c.Name, 2)) = i Then
                        c.Text = lo
                        Exit For
                    End If
                Next
            Next
            o9.Text = "Return to Command"
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
            o0.Text = "Undisrupted HQ within 1000m"
            o1.Text = "Undisrupted friends within 1500m"
            o2.Text = "0 disrupted friends within 1000m"
            o3.Text = "Inf or AFV Threatened"
            o4.Text = "Under Chemical Attack"
            o5.Text = "Under Nuclear Attack"
            o6.Text = ""
            o7.Text = ""
            o8.Text = ""
            o9.Text = "Voluntarily Disrupt"
        ElseIf purpose = "Command" Then
            o0.Text = "Out of Command"
            o1.Text = "Line of Supply broken"
            o2.Text = "Out of Supply"
            o3.Text = "Artillery Allocation"
            o4.Text = "Air Mission Planning"
            o5.Text = "Allocate Air Observers"
            o6.Text = "Break EMCON"
            o7.Text = "Artillery Location Finding"
            o8.Text = "Release Off table Units"
            o9.Text = "Leave the Table"
        ElseIf purpose = "Initial Command" Then
            o0.Text = "Travel<>Conc "
            o1.Text = "Conc<>Disp "
            o2.Text = "Travel<>Disp"
            o3.Text = "Artillery Allocation"
            o4.Text = "Air Mission Planning"
            o5.Text = "Allocate Air Observers"
            o6.Text = "Break EMCON"
            o7.Text = "Dismount"
            o8.Text = "Embus"
            o9.Text = IIf(commander.arrives = 0, "Place off Table", "Bring onto the table")

        Else

        End If
        reset_tactical_actions()

    End Sub
    Sub reset_tactical_actions()
        For Each ctrl As Control In tactical_actions.Controls
            If Strings.Left(ctrl.Name, 1) = "o" Then
                ctrl.BackColor = defa
                If ctrl.Text = "" Then ctrl.Visible = False Else ctrl.Visible = True
            End If
        Next

    End Sub
    Private Sub orders_changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles o0.Click, o1.Click, o2.Click, o3.Click, o4.Click, o5.Click, o6.Click, o7.Click, o8.Click, o9.Click
        Dim t As Integer = Val(Strings.Right(sender.name, 1))

        If Tag = "Morale Recovery" Then
            tac_opt_txt = ""
            If sender.name = "o9" Or (sender.name <> "o9" And o9.BackColor = golden) Then
                If sender.name = "o9" And o9.BackColor = defa Then
                    For Each c As Control In tactical_actions.Controls
                        c.BackColor = defa
                        If c.Name = "o2" Then c.Text = "0 disrupted friends within 1000m"
                    Next
                    o9.BackColor = golden
                    executeorders.Text = "Disperse Selected Units"
                Else
                    For Each l As ListViewItem In undercommand.Items
                        l.BackColor = ph_units(l.Text).status(Tag)
                    Next
                    o9.BackColor = defa
                    executeorders.Text = "Test Morale"
                End If
            End If
            If sender.name <> "o9" Then
                If sender.name = "o2" Then
                    change_disrupted_friends(sender)
                ElseIf sender.BackColor = golden Then
                    sender.backcolor = defa
                Else
                    sender.backcolor = golden
                End If
            End If
        ElseIf instr(Tag, "Command") > 0 Then
            For Each c As Control In tactical_actions.Controls
                If c.BackColor = golden And sender.name <> c.Name Then c.BackColor = defa
            Next
            If sender.backcolor = golden Then
                sender.backcolor = defa
                tac_opt_txt = ""
                tac = -1
                Exit Sub
            Else
                sender.backcolor = golden
                tac = t
                tac_opt_txt = sender.text
            End If
            If t = 3 And Not subject.indirect Then Exit Sub
            If t = 4 Or t = 9 Then Exit Sub
            If t = 5 And subject.task <> "Observation" Then Exit Sub
            If t = 6 And Not subject.radar Then Exit Sub
            If Tag = "Command" And t = 7 And Not orbat(subject.parent).arty_int > 0 Then Exit Sub

        ElseIf Tag = "Movement" Then
            Dim x As Integer = select_count
                If t = 1 And sender.backcolor = golden Then
                    tac = tac_less_move : tac_less_move = 0
                    sender.backcolor = defa
                ElseIf t = 1 And sender.backcolor = defa Then
                    tac_less_move = tac
                    If subject.helarm Then tac = 2 Else tac = 4
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