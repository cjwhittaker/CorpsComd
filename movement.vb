Public Class movement
    Public carrier As cunit, mover As cunit, notfired As Boolean, tac_opt As Integer = -1, tac_opt_txt As String = ""
    Dim commander As New cunit, subject As New cunit, i As Integer, j As Integer, k As Integer = -1, tactical_option As String, recovermsg As String, unitsselected As Integer = 0
    Dim comdpoints As Integer = 0, ca As Boolean = False, spt As Boolean = False
    Private Sub commanders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles commanders.ItemSelectionChanged
        If commander.title = e.Item.Text Then Exit Sub
        commander = orbat(e.Item.Text)
        i = e.ItemIndex
        comdpoints = commander.comdpts
        update_title(commander)
        populate_lists(undercommand, ph_units, Me.Tag, commander.title)
        unitsselected = 0 : k = -1
        reset_unit_options()
    End Sub

    Private Sub undercommand_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles undercommand.Click
        Dim deselect As Boolean = False

        If k <> -1 And Not undercommand.MultiSelect Then
            undercommand.Items(k).BackColor = status(orbat(undercommand.Items(k).Text))
            unitsselected = 0
            executeorders.Enabled = False
            tactical_actions.Enabled = False
            If Me.Tag = "Air Tasking" Then
                comdpoints = comdpoints + subject.comdpts
                subject.comdpts = 0
                update_title(commander)
            End If
            If k = undercommand.FocusedItem.Index Then
                k = -1
                subject = New cunit
                GoTo endsub
            End If
        End If
        k = undercommand.FocusedItem.Index
        subject = orbat(undercommand.FocusedItem.Text)
        If undercommand.FocusedItem.BackColor <> Color.Goldenrod Then
            If Me.Tag = "Tactical Action" Then
                If subject.tacticalpts = 0 Or (tac_opt = -1 And unitsselected = 1 And Not marchmove.Checked) Or (subject.airborne And Not subject.hel) Then GoTo endsub
                If marchmove.Checked And comdpoints - 3 * (1 + comd_distance_ranges.SelectedIndex) < 0 And unitsselected = 0 Then GoTo endsub
            ElseIf Me.Tag = "Air Tasking" Then
                If subject.hel And comdpoints - 2 < 0 Then GoTo endsub
                If subject.role = "AC" And comdpoints - 3 < 0 Then GoTo endsub
                tactical_actions.Enabled = Enabled
            End If
            executeorders.Enabled = True
            undercommand.FocusedItem.BackColor = Color.Goldenrod
            unitsselected = unitsselected + 1
            If Me.Tag = "Air Tasking" Then
                tactical_actions.Enabled = Enabled
                If subject.Airsuperiority Then
                    subject.comdpts = 2
                ElseIf subject.hel Then
                    subject.comdpts = 2
                Else
                    subject.comdpts = 3
                End If
                If comdpoints - subject.comdpts < 0 Then
                    subject.comdpts = 0
                    undercommand.Items(k).BackColor = status(subject)
                    unitsselected = unitsselected - 1
                    GoTo endsub
                End If
                comdpoints = comdpoints - subject.comdpts
                update_title(commander)
                GoTo endsub
            End If
        ElseIf undercommand.FocusedItem.BackColor = Color.Goldenrod Then
            undercommand.FocusedItem.BackColor = status(subject)
            unitsselected = unitsselected - 1
            deselect = True
            If Me.Tag = "Air Tasking" Then
                tactical_actions.Enabled = Enabled
                comdpoints = comdpoints + subject.comdpts
                subject.comdpts = 0
                update_title(commander)
                subject = New cunit
                GoTo endsub
            End If
        Else
        End If

        If Me.Tag = "Tactical Action" And deselect Then
            tactical_actions.Text = tactical_option
            If Not marchmove.Checked Then
                comdpoints = comdpoints + subject.comdpts
                subject.comdpts = 0
                update_title(commander)
                subject = New cunit
            End If
            If unitsselected <= 0 Then reset_unit_options() : GoTo endsub
            GoTo endsub
        End If
        If Me.Tag = "Tactical Action" And Not deselect Then
            If Not marchmove.Checked Then
                If tac_opt <> -1 Then
                    If tac_opt = 9 And ca And Not spt Then
                        subject.support = True
                        spt = True
                    End If
                    If subject.hel Then
                        subject.comdpts = 1
                    Else
                        subject.comdpts = comd_distance_ranges.SelectedIndex + 1
                    End If
                    If comdpoints - subject.comdpts < 0 Then
                        subject.comdpts = 0
                        undercommand.Items(k).BackColor = status(subject)
                        unitsselected = unitsselected - 1
                        GoTo endsub
                    End If
                End If
                comdpoints = comdpoints - subject.comdpts
                update_title(commander)
            End If
            tactical_actions.Enabled = True
            If subject.Cover > 0 Then
                cover.Text = "+" + Trim(Str(subject.Cover))
                cover.BackColor = Color.Goldenrod
            Else
                cover.Text = "None"
                cover.BackColor = Color.FromName("Control")
            End If
            executeorders.Enabled = True
            tactical_actions.Text = tactical_option + " " + subject.title + " (" + Trim(Str(subject.tacticalpts)) + ")"
            opp_fire.Enabled = True
            If unitsselected = 1 Then opp_fire.Checked = True
            marchmove.Enabled = True
            unitcover.Enabled = True
            GoTo endsub
        End If


endsub:
        undercommand.FocusedItem.Selected = False
    End Sub

    Private Sub update_title(ByVal x As cunit)
        title.Text = x.title + " - " + Str(comdpoints) + " Command Points"
    End Sub
    Private Sub Comd_distance_select(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comd_distance_ranges.SelectedIndexChanged
        comd_dist.Text = comd_distance_ranges.SelectedItem
    End Sub
    Public Sub options_for(ByVal purpose As String)
        'availablecommand = 0
        'commandpoints.Caption = ""
        comd_distance_ranges.SelectedIndex = 0
        'comd_dist.Text = 0
        'k = 0
        If purpose = "Tactical Action" Then
            populate_lists(commanders, ph_hqs, purpose, "commanders")
            commanders.Items(0).Selected = True
            undercommand.MultiSelect = True
            tactical_actions.Visible = True
            tactical_option = "Tactical Action"
            load_orders(purpose)
            tactical_actions.Text = tactical_option
            comd_dist_gp.Visible = True
            executeorders.Text = "Execute Tactical Orders"
            unitcover.Visible = True
            marchmove.Visible = True
            opp_fire.Visible = True
            selectall.Visible = True
            opp_fire.Checked = True
        ElseIf purpose = "Morale Recovery" Then
            undercommand.MultiSelect = False
            tactical_actions.Visible = False
            comd_dist_gp.Visible = True
            executeorders.Text = "Recover Morale"
            unitcover.Visible = False
            marchmove.Visible = False
            populate_lists(commanders, ph_hqs, purpose, "commanders")
            unitcover.Visible = False
            opp_fire.Visible = False
            selectall.Visible = False
        ElseIf purpose = "Air Tasking" Then
            populate_lists(commanders, ph_hqs, purpose, "commanders")
            undercommand.MultiSelect = False
            tactical_actions.Visible = True
            load_orders(purpose)
            tactical_option = "Air Task Type "
            tactical_actions.Text = tactical_option
            comd_dist_gp.Visible = False
            executeorders.Text = "Deploy Sortie"
            unitcover.Visible = False
            marchmove.Visible = False
            unitcover.Visible = False
            opp_fire.Visible = False
            selectall.Visible = False
        Else

        End If


    End Sub
    Private Sub select_cover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles select_cover.Click
        If cover.Text = "None" Then
            cover.Text = "+1" : cover.BackColor = Color.DarkGoldenrod
        ElseIf cover.Text = "+1" Then
            cover.Text = "+2"
        ElseIf cover.Text = "+2" Then
            cover.Text = "+3"
        ElseIf cover.Text = "+3" Then
            cover.Text = "None" : cover.BackColor = Color.FromName("Control")
        Else
        End If
        subject.Cover = Val(cover.Text)
    End Sub
    Private Sub Execute_orders() Handles executeorders.Click
        If undercommand.Items.Count = 0 Then Exit Sub
        If undercommand.Items.Count = 1 Then subject = orbat(undercommand.Items(0).Text)
        If Me.Tag = "Tactical Action" And tac_opt = -1 And Not marchmove.Checked Then Exit Sub
        If Me.Tag = "Air Tasking" And tac_opt = -1 Then Exit Sub

        Dim x As Integer, tactical As Integer = 0, comdcost As Integer = 0
        assault.attacker = New cunit
        assault.supporter = New cunit
        assault.defender = New cunit
        unitsselected = 0
        If marchmove.Checked Then
            tactical = 15
        ElseIf Me.Tag = "Air Tasking" Then
            tactical = 16
        ElseIf Me.Tag = "Morale Recovery" Then
            tactical = 17
        Else
            tactical = tac_opt
        End If

        For Each l As ListViewItem In undercommand.Items
            If l.BackColor = Color.Goldenrod Or (l.Selected And Me.Tag = "Morale Recovery") Then
                mover = New cunit
                mover = orbat(l.SubItems(0).Text)
                mover.comdpts = 0
                'If tactical < 15 Then mover.Cover = Val(cover.Text)
                If tactical = 5 And ((Not mover.troopcarrier And mover.loaded <> "") Or (Not mover.Inf And mover.loaded = "")) Then Exit Sub
                comdcost = 1 : notfired = False : unitsselected = unitsselected + 1
                Select Case tactical
                    Case 0
                        mover.moved = True
                        mover.tacticalpts = mover.tacticalpts - 2
                        If mover.indirect Then mover.eligibleCB = False
                        If opp_fire.Checked Then opportunityfire.ShowDialog()
                    Case 1
                        load_combat(mover)
                        If notfired = True Then
                            unitsselected = unitsselected - 1
                            notfired = False
                        Else
                            mover.fired = True
                            mover.tacticalpts = mover.tacticalpts - 2
                            If mover.indirect Then mover.eligibleCB = True
                        End If
                    Case 2, 4
                        mover.moved = True
                        mover.fired = False
                        If opp_fire.Checked Then opportunityfire.ShowDialog()
                        load_combat(mover)
                        If notfired Then
                            notfired = False
                            mover.tacticalpts = mover.tacticalpts - 2
                        Else
                            mover.fired = True
                            If mover.indirect Then mover.eligibleCB = True
                            If tactical = 2 Then mover.tacticalpts = mover.tacticalpts - 3 Else mover.tacticalpts = mover.tacticalpts - 4
                        End If
                    Case 3, 5
                        load_combat(mover)
                        mover.fired = False
                        mover.moved = True
                        If notfired Then
                            notfired = False
                            mover.tacticalpts = mover.tacticalpts - 2
                        Else
                            If tactical = 3 Then mover.tacticalpts = mover.tacticalpts - 3 Else mover.tacticalpts = mover.tacticalpts - 4
                            If mover.indirect Then mover.eligibleCB = False
                        End If
                    Case 6
                        If mover.loaded <> "" And mover.troopcarrier Then
                            If opp_fire.Checked Then opportunityfire.ShowDialog()
                            debus(mover, x)
                        ElseIf mover.loaded = "" And mover.Inf Then
                            If opp_fire.Checked Then opportunityfire.ShowDialog()
                            embus(mover, x)
                            mover.tacticalpts = mover.tacticalpts - 1
                            x = 0
                        Else

                        End If
                    Case 7
                        If mover.loaded <> "" And mover.troopcarrier Then
                            mover.moved = True
                            mover.fired = False
                            If opp_fire.Checked Then opportunityfire.ShowDialog()
                            mover.tacticalpts = mover.tacticalpts - 2
                            debus(mover, x)
                        End If
                    Case 8
                        If mover.loaded = "" And mover.Inf Then
                            If opp_fire.Checked Then opportunityfire.ShowDialog()
                            embus(mover, x)
                            mover.tacticalpts = mover.tacticalpts - 2
                            mover.moved = True
                            mover.fired = False
                            x = 0
                        End If
                    Case 9
                        If ca And mover.assault Then assault.attacker = mover : assault.attacker.serialno = l.Index
                        If spt And mover.support Then assault.supporter = mover : assault.supporter.serialno = l.Index
                    Case 15
                        mover.moved = True
                        mover.fired = False
                        comdcost = 3
                        mover.tacticalpts = 0

                    Case 16
                        mover.airborne = True
                        mover.fired = False
                        mover.airtask = tac_opt_txt
                        Select Case tac_opt
                            Case 0, 1
                                mover.sorties = 4
                            Case 2, 3, 4
                                mover.sorties = 1
                                mover.ordnance = True
                            Case 5
                                mover.sorties = 3
                            Case 6
                                mover.sorties = 4
                        End Select
                        If mover.Airsuperiority Or mover.hel Then
                            comdcost = 2
                        Else
                            comdcost = 3
                        End If
                    Case 17
                        If l.BackColor <> Color.Goldenrod Then comdcost = 0 : Exit Select
                        Dim recovermsg As String = ""
                        unitsselected = 1
                        mover.moved = True
                        If mover.indirect Then mover.eligibleCB = False
                        mover.tacticalpts = 0
                        If d6() >= Asc(mover.quality) - 62 Then
                            If mover.repulsed Then
                                mover.repulsed = False
                                recovermsg = mover.title + " has recovered from being repulsed"
                            ElseIf mover.routed Then
                                mover.routed = False
                                mover.repulsed = True
                                recovermsg = mover.title + " has recovered from being routed and is now repulsed"
                            Else
                            End If
                            mover.tacticalpts = 0
                        Else
                            recovermsg = "Morale recovery failed"
                        End If
                        With resultform
                            .result.Text = recovermsg
                            .ShowDialog()
                        End With

                End Select
                If Not tactical = 17 Then l.BackColor = status(mover)
                If Not mover Is Nothing Then
                    l.SubItems(1).Text = mover.strength
                    color_item(l, mover)
                End If
                If Not undercommand.MultiSelect Then Exit For
            End If
        Next
        If tactical = 9 Then conduct_assault()
        ca = False : spt = False
        If tactical = 15 Then marchmove.Checked = False
        If tactical >= 15 Then unitsselected = 1
        If tactical = 16 Then
            commander.comdpts = commander.comdpts - comdcost
        Else
            commander.comdpts = commander.comdpts - unitsselected * comdcost * (1 + comd_distance_ranges.SelectedIndex)
        End If
        comdpoints = commander.comdpts
        commanders.Items(i).SubItems(1).Text = commander.comdpts
        update_title(commander)
        tactical_actions.Text = tactical_option
        reset_unit_options()
    End Sub

    Private Sub select_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectall.Click
        If unitsselected = 0 Then selectall.Text = "Deselect All" Else selectall.Text = "Select All"
        For Each l As ListViewItem In undercommand.Items
            If selectall.Text = "Deselect All" And orbat(l.Text).tacticalpts > 0 Then
                l.BackColor = Color.Goldenrod
                unitsselected = unitsselected + 1
            ElseIf selectall.Text = "Select All" Then
                l.BackColor = Color.White
            Else
            End If
        Next
        If selectall.Text = "Select All" Then unitsselected = 0
    End Sub
    Private Sub debus(ByVal unit As cunit, ByVal z As Integer)
        subject = ph_units(unit.loaded)
        With subject
            .loaded = ""
            .repulsed = unit.repulsed
            .pinned = unit.pinned
            .parent = unit.parent
            '.strength = unit.strength * (.initial / unit.initial)
            .suppression = unit.suppression
            .tacticalpts = unit.tacticalpts
            .moved = False
        End With
        unit.loaded = ""
        Dim listitem As New ListViewItem
        With listitem
            .Text = subject.title
            .SubItems.Add(subject.strength)
            .SubItems.Add(subject.equipment)
        End With
        undercommand.Items.Add(listitem)
    End Sub
    Private Sub embus(ByVal unit As cunit, ByVal z As Integer)
        populate_lists(transport.units, ph_units, "Transport", unit.parent)
        If transport.units.Items.Count = 0 Then Exit Sub
        carrier = New cunit
        transport.title.Text = "Choose which units to load " + unit.title + " on"
        transport.ShowDialog()
        If carrier Is Nothing Then Exit Sub
        With carrier
            .loaded = unit.title
            .parent = unit.parent
            .tacticalpts = unit.tacticalpts
            .moved = False
        End With
        With unit
            .loaded = carrier.title
        End With
        carrier = Nothing
    End Sub
    Private Sub load_combat(ByVal firer As cunit)
        With combat
            .firer = New cunit
            .firer = firer
            .combatmode = "Tactical Action"
            .title.Text = "Ground Combat"
            .ShowDialog()
        End With
    End Sub
    Private Sub opp_fire_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opp_fire.CheckedChanged
        If opp_fire.Checked Then
            opp_fire.BackColor = Color.Goldenrod
            oppfire = True
        Else
            opp_fire.BackColor = selectall.BackColor
            oppfire = False
        End If
    End Sub
    Private Sub reset_unit_options()
        tac_opt = -1
        tactical_actions.Enabled = False
        load_orders(tactical_option)
        marchmove.Checked = False
        opp_fire.Checked = True
        With cover
            .Text = "None"
            .BackColor = Color.FromName("Control")
        End With
        comd_distance_ranges.SelectedIndex = 0
        unitsselected = 0
        k = -1
        comdpoints = commander.comdpts
        update_title(commander)
        Me.Focus()
    End Sub
    Private Sub marchmove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marchmove.CheckedChanged
        If commander.comdpts - (comd_distance_ranges.SelectedIndex + 1) * 3 < 0 Then Exit Sub
        If marchmove.Checked Then marchmove.BackColor = Color.Goldenrod Else marchmove.BackColor = Color.FromName("Control")
        If Not marchmove.Checked Then
            comdpoints = commander.comdpts
            update_title(commander)
            tactical_actions.Enabled = True
            For Each l As ListViewItem In undercommand.Items
                If l.BackColor = Color.Goldenrod Then l.BackColor = Color.White
            Next
            Exit Sub
        End If
        load_orders(tactical_option)
        comdpoints = commander.comdpts - (comd_distance_ranges.SelectedIndex + 1) * 3
        update_title(commander)
        tactical_actions.Enabled = False
    End Sub

    Private Sub movement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        comd_distance_ranges.SelectedIndex = 0
        If Me.Tag = "Tactical Action" Then mov_rates.Show()

    End Sub
    Private Sub movement_closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        For Each i As ListViewItem In undercommand.Items
            i.Remove()
        Next
        title.Text = ""
        If Me.Tag = "Tactical Action" Then mov_rates.Hide()
    End Sub

    Private Sub load_orders(ByVal purpose As String)
        If purpose = "Tactical Action" Then
            o0.Text = "Full Move (2)"
            o1.Text = "Fire Halted (2)"
            o2.Text = "Move 1/2 then Fire (3)"
            o3.Text = "Fire then move 1/2 (3)"
            o4.Text = "Full move then Fire (4)"
            o5.Text = "Fire then Full Move (4)"
            o6.Text = "Debus/Embus (1)"
            o7.Text = "Move 1/2 & Debus (2)"
            o8.Text = "Embus & Move 1/2 (2)"
            o9.Text = "Close Assault (1)"
            o7.Visible = True
            o8.Visible = True
            o9.Visible = True
        Else
            o0.Text = "Air Superiority"
            o1.Text = "EW Support"
            o2.Text = "CAS"
            o3.Text = "Strike"
            o4.Text = "Wild Weasel"
            o5.Text = "AH Mission"
            o6.Text = "Observation"
            o7.Visible = False
            o8.Visible = False
            o9.Visible = False
        End If
        o0.Checked = False
        o1.Checked = False
        o2.Checked = False
        o3.Checked = False
        o4.Checked = False
        o5.Checked = False
        o6.Checked = False
        o7.Checked = False
        o8.Checked = False
        o9.Checked = False
        o0.BackColor = Color.FromName("Control")
        o1.BackColor = Color.FromName("Control")
        o2.BackColor = Color.FromName("Control")
        o3.BackColor = Color.FromName("Control")
        o4.BackColor = Color.FromName("Control")
        o5.BackColor = Color.FromName("Control")
        o6.BackColor = Color.FromName("Control")
        o7.BackColor = Color.FromName("Control")
        o8.BackColor = Color.FromName("Control")
        o9.BackColor = Color.FromName("Control")

    End Sub
    Private Sub orders_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles o0.CheckedChanged, o1.CheckedChanged, o2.CheckedChanged, o3.CheckedChanged, o4.CheckedChanged, o5.CheckedChanged, o6.CheckedChanged, o7.CheckedChanged, o8.CheckedChanged, o9.CheckedChanged

        If sender.tag = "deselect" Or Not tactical_actions.Enabled Then Exit Sub
        If sender.checked Then
            sender.tag = "changed"
            sender.backcolor = Color.Goldenrod
            tac_opt = Val(Strings.Right(sender.name, 1))
            tac_opt_txt = sender.text
            Dim t As Integer = Val(Mid(tac_opt_txt, InStr(tac_opt_txt, "(") + 1, 1))
            If Not valid_order(tactical_option, t) Then
                sender.checked = False
                Exit Sub
            End If
            orders_accepted()
        Else
            sender.backcolor = Color.FromName("Control")
            tac_opt = -1
            tac_opt_txt = ""
            orders_deleted()
        End If

    End Sub
    Private Sub orders_deselect(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles o0.Click, o1.Click, o2.Click, o3.Click, o4.Click, o5.Click, o6.Click, o7.Click, o8.Click, o9.Click
        If sender.tag = "changed" Then
            sender.tag = ""
            Exit Sub
        End If

        If sender.checked Then
            sender.tag = "deselect"
            sender.checked = False
            sender.tag = ""
            sender.backcolor = Color.FromName("Control")
            tac_opt = -1
            tac_opt_txt = ""
            orders_deleted()
        End If

    End Sub
    Private Sub orders_deleted()
        If tac_opt <> 9 And (ca Or spt) Then
            ca = False : spt = False
            o9.Text = "Close Assault (1)"
            o9.Enabled = True
            For Each l As ListViewItem In undercommand.Items
                If l.BackColor = Color.Goldenrod Then
                    comdpoints = comdpoints + ph_units(l.Text).comdpts
                    With ph_units(l.Text)
                        .comdpts = 0
                        .support = False
                        .assault = False
                    End With
                    l.Selected = False
                    l.BackColor = status(ph_units(l.Text))
                End If
            Next
            unitsselected = 0
            tactical_actions.Enabled = False
        Else
            comdpoints = comdpoints + subject.comdpts : subject.comdpts = 0
        End If
        update_title(commander)
    End Sub
    Private Sub orders_accepted()
        If InStr(tactical_option, "air") > 0 Then
            If subject.hel Then subject.comdpts = 2 Else subject.comdpts = 3
        Else
            If marchmove.Checked Then
                subject.comdpts = (comd_distance_ranges.SelectedIndex + 1) * 3
            ElseIf tac_opt = 1 Then
                opp_fire.Checked = False
            ElseIf tac_opt = 9 And Not ca And Not spt Then
                ca = True
                subject.assault = True
                o9.Text = "Support Assault (1)"
            ElseIf tac_opt = 9 And ca And Not spt Then
                spt = True
                subject.support = True
                o9.Enabled = False
            Else

            End If
            subject.comdpts = comd_distance_ranges.SelectedIndex + 1
        End If

        If comdpoints - subject.comdpts < 0 Then Exit Sub
        comdpoints = comdpoints - subject.comdpts
        update_title(commander)
    End Sub
    Private Function valid_order(ByVal purpose As String, ByVal tac_points As Integer)
        valid_order = False
        If tac_opt <= -1 Then Exit Function
        If purpose = "Tactical Action" Then
            If subject.tacticalpts - tac_points < 0 Then Exit Function
            If ca And spt And Not (subject.assault Or subject.support) Then Exit Function
            If undercommand.SelectedItems.Count > 1 And Not ca And tac_opt = 9 Then Exit Function
            If comdpoints <= 0 Then Exit Function
        End If
        valid_order = True
    End Function

    Private Sub conduct_assault()
        If Not ca Then Exit Sub
        assault.attacker.fired = True
        assault.attacker.moved = True
        assault.attacker.tacticalpts = assault.attacker.tacticalpts - 1
        If Not assault.supporter Is Nothing Then
            assault.supporter.fired = True
            assault.supporter.moved = True
            assault.supporter.tacticalpts = assault.supporter.tacticalpts - 1
        End If
        populate_lists(assault.a_arty_spt, ph_units, "Artillery Support", "")
        populate_lists(assault.d_arty_spt, enemy, "Artillery Support", "")
        If oppfire Then
            With combat
                .firer = New cunit
                .firer = assault.defender
                .target = New cunit
                .target = assault.attacker
                .targets.Visible = False
                .selectedtarget.Text = assault.attacker.title
                .combatmode = "Opportunity Fire"
                .title.Text = combat.combatmode
                .ShowDialog()
                .targets.Visible = True
            End With
            If assault.attacker.pinned Or assault.attacker.repulsed Or assault.attacker.routed Then
                assault.attacker.assault = False
                assault.supporter.support = False
                With resultform
                    .result.Text = "Close Assault has Failed to close on the defender's position"
                    .ShowDialog()
                End With
                Exit Sub
            End If
        End If
        ca_defenders.ShowDialog()
        If assault.defender Is Nothing Then Exit Sub
        With assault
            .ShowDialog()
        End With
        undercommand.Items(assault.attacker.serialno).BackColor = status(assault.attacker)
        undercommand.Items(assault.supporter.serialno).BackColor = status(assault.supporter)

    End Sub

End Class