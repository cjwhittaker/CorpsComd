Public Class movement
    Public carrier As cunit, mover As cunit, notfired As Boolean, tac_opt As Integer = -1, tac_points As Integer = 0, tac_opt_txt As String = "", tactical As Integer, observing As Boolean, scoot As Boolean
    Dim commander As New cunit, subject As New cunit, j As Integer, k As Integer = -1, recovermsg As String, cover_selected As Boolean = False
    Dim comdpoints As Integer = 0, ca As Boolean = False, spt As Boolean = False, select_all As Boolean = False, selected_units As Integer = 0

    Private Sub select_hq(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles comdtree.NodeMouseClick
        Dim x As Integer = 1, parentnode As New TreeNode
        If comdtree.SelectedNode Is Nothing Then Exit Sub
        'selectunit(orbat(e.Node.Text))
        'If commanders.Items.Count <> 1 And commander.title = e.Item.Text Then Exit Sub
        mark_ooc(comdtree.Nodes)
        commander = orbat(e.Node.Text)
        undercommand.Items.Clear()
        comdtree.HideSelection = True
        If Me.Tag = "Fire and Movement" And commander.comdpts = 0 Then
            update_title("Units Under Command")
            Exit Sub
        End If
        If e.Node.BackColor <> golden Then e.Node.BackColor = golden
        undercommand.Focus()
        update_title(commander.title)
        populate_lists(undercommand, ph_units, Me.Tag, commander.title)
        If Me.Tag = "Fire and Movement" Then commander.comdpts = 0
        k = -1
        reset_unit_options()
    End Sub

    Private Sub count_selected_units()
        selected_units = 0
        For Each l As ListViewItem In undercommand.Items
            If l.BackColor = golden Then selected_units = selected_units + 1
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
        If (Me.Tag = "Air Tasking" And undercommand.FocusedItem.BackColor = Color.Pink) Or
        (Me.Tag <> "Morale Recovery" And undercommand.FocusedItem.BackColor = no_action_pts) Or
        (Me.Tag <> "Morale Recovery" And undercommand.FocusedItem.BackColor = disruptedstatus) Or
         undercommand.FocusedItem.BackColor = dead Or
        (Me.Tag <> "Morale Recovery" And undercommand.FocusedItem.BackColor = disorderedstatus) Then
            undercommand.SelectedItems.Clear()
            Exit Sub
        End If

        k = undercommand.FocusedItem.Index
        subject = orbat(undercommand.FocusedItem.Text)
        If undercommand.FocusedItem.BackColor = golden Then
            undercommand.FocusedItem.BackColor = subject.status(Me.Name)
            'selected_units = selected_units - 1
        Else
            undercommand.FocusedItem.BackColor = golden
            'selected_units = selected_units + 1
        End If
        count_selected_units()
        set_actions()
        undercommand.SelectedItems.Clear()
    End Sub

    Private Sub set_actions()
        If selected_units > 0 Then
            executeorders.Enabled = True
            opp_fire.Enabled = True
            unitcover.Enabled = True
            tactical_actions.Enabled = True
        Else
            executeorders.Enabled = False
            opp_fire.Enabled = False
            unitcover.Enabled = False
            tactical_actions.Enabled = False

        End If
        If Me.Tag = "Fire and Movement" Then
            If subject.Cover > 0 Then
                cover.Text = "+" + Trim(Str(subject.Cover))
                cover.BackColor = golden
            Else
                cover.Text = "None"
                cover.BackColor = defa
            End If
            opp_fire.Enabled = True
            unitcover.Enabled = True
        End If
    End Sub

    Private Sub update_title(ByVal x As String)
        selected_hq.Text = "Units under comd of " + x
    End Sub

    Public Sub options_for(ByVal purpose As String)
        populate_command_structure(comdtree, ph, "Command")
        If purpose = "Fire and Movement" Then
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
        Else

        End If


    End Sub

    Private Sub select_cover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cover.Click
        If selected_units <= 0 Then Exit Sub
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
        subject.Cover = Val(cover.Text)
    End Sub

    Private Sub Execute_orders() Handles executeorders.Click
        Dim comdcost As Integer = 0, dice As Integer, tactical_option As Integer
        tactical = -1
        For Each c As Control In tactical_actions.Controls
            If c.BackColor = golden Then
                tactical = Val(c.Tag)
                Exit For
            End If
        Next
        If tactical = -1 Then reset_unit_options() : Exit Sub
        If Me.Tag = "Fire and Movement" Then
            tactical_option = tactical
            If selected_units > 1 And tactical_option = 6 Then Exit Sub
            Dim msg As String = ""
            For Each l As ListViewItem In undercommand.Items
                If l.BackColor = golden Then
                    dice = d6()
                    If orbat(l.Text).ooc Or (dice >= 4 And orbat(orbat(l.Text).parent).ooc) Then
                        orbat(l.Text).ooc = True
                        msg = msg + l.Text + ", "
                        l.BackColor = no_action_pts
                    End If
                End If
            Next
            If msg <> "" Then
                With resultform
                    .result.Text = "The following units cannot move or change mode because their command HQ is out of command:" + vbNewLine + msg
                    .ShowDialog()
                End With
            End If
            If Not ca And selected_units = 0 Then Exit Sub
            If ca And selected_units = 0 Then spt = True
            If Not ca Then assault.attacker = New cunit
            If ca And spt Then
                assault.supporter = New cunit
                assault.defender = New cunit
            End If

        ElseIf Me.Tag = "Air Tasking" Then
            tactical_option = 16
        ElseIf Me.Tag = "Arty Tasking" Then
            tactical_option = tactical + 20
        ElseIf Me.Tag = "Morale Recovery" Then
            tactical_option = 17
        Else
        End If
        If Me.Tag <> "Morale Recovery" And Not ca And tac_opt_txt = "" Then Exit Sub
        'establish which tactical action or order has been chosen = tactical
        For Each l As ListViewItem In undercommand.Items
            mover = New cunit
            mover = orbat(l.SubItems(0).Text)
            If l.BackColor = golden And
                (mover.tacticalpts - tac_points >= 0 Or Me.Tag = "Air Tasking" Or Me.Tag = "Arty Tasking") Then
                If tactical_option = 5 And ((Not mover.troopcarrier And mover.loaded <> "") Or (Not mover.Inf And mover.loaded = "")) Then Exit Sub
                notfired = False
                mover.modifier = 0
                scoot = False
                Select Case tactical_option
                    Case 0
                        'If mover.has_fired And Not mover.has_moved_fired Then Exit Select
                        mover.moved = gt
                        mover.tacticalpts = mover.tacticalpts - tac_points
                        If mover.indirect Then mover.eligibleCB = False
                        If opp_fire.BackColor = golden Then opportunityfire.ShowDialog()
                    Case 1, 2
                        'If mover.has_moved And Not mover.has_moved_fired Then Exit Select
                        If tactical_option = 2 Then
                            With mover
                                .moved = gt
                                .moving = True
                            End With
                        End If
                        If mover.indirect Then
                            observing = False
                            check_observer(mover)
                            If observing Then
                                If mover.moving Then
                                    scoot = True
                                    mover.eligibleCB = False
                                Else
                                    mover.eligibleCB = True
                                End If
                                load_combat(mover)
                            End If
                        ElseIf tac_opt_txt = "Call for Fire (2)" And Not mover.lostcomms Then
                            populate_lists(unit_selection.units, ph_units, "Artillery Support", mover.parent)
                            With unit_selection
                                .Tag = "Call for Fire"
                                .ShowDialog()
                            End With
                            mover.tacticalpts = mover.tacticalpts - 2
                        Else
                            load_combat(mover)
                        End If
                        If (tactical_option = 2 Or scoot) And oppfire Then opportunityfire.ShowDialog()
                    Case 3
                        If ca And Not spt Then
                            If mover.title <> assault.attacker.title Then
                                spt = True
                                mover.support = True
                                assault.supporter = mover
                            End If
                        End If
                        If Not ca Then
                            ca = True
                            mover.assault = True
                            assault.attacker = mover
                            For Each c As Control In tactical_actions.Controls
                                If c.Name <> "o3" Then c.Enabled = False
                            Next
                        End If
                    Case 4
                        If mover.loaded = "" Or Not mover.troopcarrier Then Exit Select
                        If oppfire Then opportunityfire.ShowDialog()
                        mover.debussed = True
                        debus(mover, False)
                        mover = orbat(mover.loaded)
                        With l
                            .SubItems(0).Text = mover.title
                            .SubItems(1).Text = mover.strength
                            .SubItems(2).Text = UCase(Strings.Left(mover.mode, 1))
                            .SubItems(3).Text = mover.equipment + "*"
                        End With
                    Case 5
                        If mover.loaded = "" Or Not mover.troopcarrier Then Exit Select
                        If oppfire Then opportunityfire.ShowDialog()
                        mover.debussed = True
                        l.SubItems(3).Text = mover.equipment
                        debus(mover, True)
                    Case 6
                        If Not mover.Inf Then Exit Select
                        If opp_fire.BackColor = golden Then opportunityfire.ShowDialog()
                        embus(mover)
                        If mover.loaded <> "" Then
                            l.Remove()
                            mover.tacticalpts = mover.tacticalpts - 2
                            For Each v As ListViewItem In undercommand.Items
                                If v.Text = mover.loaded Then
                                    v.SubItems(3).Text = v.SubItems(3).Text + "*"
                                    Exit For
                                End If
                            Next
                        End If
                    Case 7, 8, 9
                        Dim prev_mode As String = mover.mode
                        If oppfire Then opportunityfire.ShowDialog()
                        If prev_mode = mover.mode Then
                            If tactical_option = 7 And Not mover.not_conc Then
                                mover.tacticalpts = mover.tacticalpts - 2
                                If mover.mode = travel Then
                                    mover.mode = conc
                                ElseIf mover.mode = conc Then
                                    mover.mode = travel
                                Else
                                End If
                            ElseIf tactical_option = 8 And Not mover.not_conc Then
                                mover.tacticalpts = mover.tacticalpts - 2
                                If mover.mode = conc Then
                                    mover.mode = disp
                                ElseIf mover.mode = disp Then
                                    mover.mode = conc
                                Else
                                End If
                            Else
                                If mover.not_conc Then mover.tacticalpts = mover.tacticalpts - 2 Else mover.tacticalpts = mover.tacticalpts - 4
                                If mover.mode = travel Then
                                    mover.mode = disp
                                ElseIf mover.mode = disp Then
                                    mover.mode = travel
                                Else
                                End If
                            End If
                            l.SubItems(2).Text = UCase(Strings.Left(mover.mode, 1))
                        End If
                    Case 15
                        mover.moved = gt
                        mover.fired = gt
                        comdcost = 3
                        mover.tacticalpts = 0

                    Case 16
                        If (tactical = 0 And InStr(mover.equipment, "AS") = 0) Or
                            (tactical = 1 And InStr(mover.equipment, "EW") = 0) Or
                            (tactical = 2 And InStr(mover.equipment, "GA") = 0) Or
                            (tactical = 3 And InStr(mover.equipment, "SO") = 0) Or
                            (tactical = 4 And InStr(mover.equipment, "SEAD") = 0) Or
                            (tactical = 5 And Not mover.heli And Not mover.role = "|AH|") Or
                            (tactical = 6 And Not mover.heli) Then Exit Select
                        dice = d10()
                        If (dice <= mover.quality Or dice = 1) And dice <> 10 Then
                            With mover
                                .airborne = True
                                .fired = IIf(mover.heli, 0, gt)
                                .task = tac_opt_txt
                            End With
                            With l
                                .BackColor = Color.Aquamarine
                                .SubItems(2).Text = IIf(Len(tac_opt_txt) < 4, tac_opt_txt, Strings.Left(tac_opt_txt, 4))
                            End With
                            If tactical = 6 Then
                                populate_lists(unit_selection.units, ph_hqs, "Observee", "commanders")
                            End If
                        Else
                            l.BackColor = Color.Pink
                        End If
                    Case 17
                        If l.BackColor <> golden Or mover.effective Then comdcost = 0 : Exit Select
                        Dim recovermsg As String = ""
                        With morale_test
                            .Tag = Me.Tag
                            .tester = mover
                            .rallying = IIf(o5.BackColor = golden, False, True)
                            .modifier = tac_points
                            .testing(Me.executeorders, Nothing)
                            .rallying = False
                        End With
                        With resultform
                            .result.Text = morale_test.test_result.Text
                            .ShowDialog()
                        End With
                        mover.effective = True
                        l.Remove()
                    Case 22
                        mover.task = "CB"
                        l.SubItems(2).Text = UCase(mover.task)
                    Case 20, 21, 23
                        If tactical_option = 20 Then
                            tac_opt_txt = "AF"
                        ElseIf tactical_option = 21 Then
                            tac_opt_txt = "IN"
                        Else
                            tac_opt_txt = "DS"
                        End If
                        populate_lists(unit_selection.units, orbat, "Arty Support", divisional_comd(mover))
                        With unit_selection
                            .Tag = "Arty Support"
                            .ShowDialog()
                        End With
                End Select
                If tactical_option <> 16 Then l.BackColor = mover.status(Me.Name)
                If Not mover Is Nothing Or mover.title <> "" Then
                    If tactical_option <= 9 Then
                        l.SubItems(1).Text = mover.strength
                        l.SubItems(2).Text = UCase(Strings.Left(mover.mode, 1))
                        If mover.tacticalpts <= 0 Then l.BackColor = no_action_pts
                    ElseIf tactical_option >= 20 Then
                        If mover.primary <> commander.title And commander.title <> mover.parent Then l.Remove()
                    Else
                    End If
                    If cover_selected Then mover.Cover = Val(cover.Text)
                End If
            End If
        Next
        If ca And spt Then conduct_assault()
        update_title(commander.title)
        reset_unit_options()
        tactical_option = 0
        cover_selected = False
    End Sub

    Private Sub select_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selected_hq.Click
        If Not select_all Then select_all = True Else select_all = False
        selected_units = 0
        For Each l As ListViewItem In undercommand.Items
            If select_all And orbat(l.Text).tacticalpts > 0 And Not orbat(l.Text).disrupted And Not orbat(l.Text).disordered Then
                l.BackColor = golden
            ElseIf Not select_all Then
                l.BackColor = orbat(l.Text).status
            Else
            End If
            If l.BackColor = golden Then selected_units = selected_units + 1
        Next
        If selected_units > 0 Then set_actions()
    End Sub

    Public Sub debus(ByVal unit As cunit, dismount As Boolean)
        subject = orbat(unit.loaded)
        With subject
            .parent = unit.parent
            '.strength = unit.strength * (.initial / unit.initial)
            .firers = unit.firers
            .tacticalpts = unit.tacticalpts
            .moved = gt
            .fired = unit.fired
            .lostcomms = unit.lostcomms
            .mode = unit.mode
            .debussed = unit.debussed
        End With
        If dismount Then
            subject.loaded = ""
            unit.loaded = ""
            Dim listitem As New ListViewItem
            With listitem
                .Text = subject.title
                .SubItems.Add(subject.strength)
                .SubItems.Add(UCase(Strings.Left(subject.mode, 1)))
                .SubItems.Add(subject.equipment)
            End With
            undercommand.Items.Add(listitem)
        End If
    End Sub

    Private Sub embus(ByVal unit As cunit)
        If unit.debussed And unit.loaded <> "" Then
            unit.debussed = False
            debus(unit, False)
        Else
            populate_lists(unit_selection.units, ph_units, "Transport", unit.parent)
            If unit_selection.units.Items.Count = 0 Then Exit Sub
            carrier = New cunit
            With unit_selection
                .Tag = "Transport"
                .title.Text = "Choose which transport to load " + unit.title + " onto"
                .ShowDialog()
            End With
            If carrier Is Nothing Then Exit Sub
            unit.debussed = False
            unit.loaded = carrier.title
            debus(unit, False)
            carrier = Nothing
        End If
    End Sub

    Public Sub load_combat(ByVal firer As cunit)
        With combat
            .Tag = Me.Tag
            .firer = New cunit
            .firer = firer
            .firermode.Text = firer.mode
            .combatmode = firer.nation + " " + Me.Tag
            .title.Text = firer.nation + " " + Me.Tag
            .ShowDialog()
        End With
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
        tactical_actions.Enabled = False
        tac_points = 0
        selected_hq.Text = ""
        selected_units = 0
        load_orders(Me.Tag)
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
        If Me.Tag = "Fire and Movement" Then mov_rates.Show()
        opportunityfire.Tag = "Opportunity Fire"
        opp_fire.BackColor = golden : oppfire = True
    End Sub

    Private Sub movement_closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Closed
        For Each i As ListViewItem In undercommand.Items
            i.Remove()
        Next
        If Me.Tag = "Fire and Movement" Then mov_rates.Hide()
        selected_hq.Text = "Units"
    End Sub

    Private Sub load_orders(ByVal purpose As String)
        If purpose = "Fire and Movement" Then
            o0.Text = "Half Move (2)"
            o1.Text = "Fire (2)"
            o2.Text = "Fire and move (2)"
            o3.Text = IIf(ca, "Support Assault (2)", "Close Assault (2)")
            o4.Text = "Debus (0)"
            o5.Text = "Dismount (2)"
            o6.Text = "Embus (2)"
            o7.Text = "Travel<>Conc (2)"
            o8.Text = "Conc<>Disp (2)"
            o9.Text = "Travel<>Disp (4)"
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

        Else

        End If
        For Each ctrl In tactical_actions.Controls
            If Strings.Left(ctrl.name, 1) = "o" Then
                ctrl.backcolor = defa
                If ctrl.text = "" Then ctrl.visible = False Else ctrl.visible = True
            End If
        Next

    End Sub

    Private Sub orders_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles o0.Click, o1.Click, o2.Click, o3.Click, o4.Click, o5.Click, o6.Click, o7.Click, o8.Click, o9.Click
        Dim t As Integer = Val(Mid(sender.text, InStr(sender.text, "(") + 1, 2))

        If Me.Tag = "Morale Recovery" Then
            tac_opt_txt = ""
            If sender.BackColor = golden Then
                sender.backcolor = defa
                tac_points = tac_points - t
            Else
                sender.backcolor = golden
                tac_points = tac_points + t
            End If
        Else
            If sender.backcolor = defa Or (sender.name = "o0" And sender.text = "Half Move (2)" And sender.backcolor = golden) Or (sender.name = "o1" And sender.text = "Fire (2)" And sender.backcolor = golden) Then
                If sender.name = "o0" And sender.text = "Half Move (2)" And sender.backcolor = golden Then sender.text = "Full Move (4)" : t = t + 2
                If sender.name = "o1" And sender.text = "Fire (2)" And sender.backcolor = golden Then sender.text = "Call for Fire (2)"
                sender.backcolor = golden
                tac_opt_txt = sender.text
                tac_points = t
                For Each c As Control In tactical_actions.Controls
                    If Strings.Left(c.Name, 1) = "o" And c.BackColor = golden And sender.name <> c.Name Then c.BackColor = defa
                Next
            Else
                sender.backcolor = defa
                If sender.name = "o0" And sender.text = "Full Move (4)" Then sender.text = "Half Move (2)"
                If sender.name = "o1" And sender.text = "Call for Fire (2)" Then sender.text = "Fire (2)"
                tac_points = 0
                tac_opt_txt = ""
            End If
            If opp_fire.Visible And opp_fire.BackColor = golden And sender.name = "o1" Then opp_fire_clicked(opp_fire, Nothing)
        End If

    End Sub

    Private Sub conduct_assault()
        If Not ca Then Exit Sub
        assault.attacker.moved = gt
        assault.attacker.tacticalpts = assault.attacker.tacticalpts - 4
        If opp_fire.BackColor = golden Then opportunityfire.ShowDialog()

        If Not assault.supporter Is Nothing Or assault.supporter.title = "" Then
            assault.supporter.fired = gt
            assault.supporter.moved = gt
            assault.supporter.tacticalpts = assault.supporter.tacticalpts - 1
        End If
        'populate_lists(assault.a_arty_spt, ph_units, "Artillery Support", "")
        'populate_lists(assault.d_arty_spt, enemy, "Artillery Support", "")
        populate_lists(unit_selection.units, enemy, "CA Defenders", "")
        With unit_selection
            .Tag = "CA Defenders"
            .ShowDialog()
        End With
        If assault.defender Is Nothing Or assault.defender.title = "" Then Exit Sub
        With combat
            .Tag = "Opportunity Fire"
            .firer = New cunit
            .firer = assault.defender
            .targets.Visible = False
            .selectedtarget.Text = assault.attacker.title
            .combatmode = "Opportunity Fire"
            .title.Text = nph + " " + combat.combatmode + "against Close Assault"
            .ShowDialog()
            .targets.Visible = True
        End With
        If assault.attacker.disrupted Then
            assault.attacker.assault = False
            assault.supporter.support = False
            With resultform
                .result.Text = "Close Assault has Failed to close on the defender's position"
                .ShowDialog()
            End With
        Else
            assault.attacker.fired = gt
            With assault
                .ShowDialog()
            End With
        End If

        undercommand.Items(assault.attacker.sorties).BackColor = assault.attacker.status(Me.Name)
        undercommand.Items(assault.supporter.sorties).BackColor = assault.supporter.status(Me.Name)
        ca = False : spt = False
        o6.Text = "Close Assault (2)"
        For Each c As Control In tactical_actions.Controls
            c.Enabled = True
        Next

    End Sub

End Class