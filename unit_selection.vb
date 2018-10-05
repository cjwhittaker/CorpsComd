Public Class unit_selection
    Public i As Integer = -1, subject As cunit

    Private Sub units_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles units.Click
        If units.SelectedItems.Count = 0 Then Exit Sub
        i = units.FocusedItem.Index
        If Me.Tag = "Radar On" Or Me.Tag = "Call for Fire" Then
            If units.Items(i).Focused And units.Items(i).BackColor <> golden Then
                If Not subject.disrupted Then units.Items(i).BackColor = golden
            ElseIf units.Items(i).Focused And units.Items(i).BackColor = golden Then
                units.Items(i).BackColor = nostatus
                If Me.Tag = "Call for Fire" Then
                    If orbat(units.FocusedItem.Text).rockets = 0 Then
                        units.FocusedItem.BackColor = in_ds
                    ElseIf orbat(units.FocusedItem.Text).rockets = 1 Then
                        units.FocusedItem.BackColor = can_observe
                    Else
                        units.FocusedItem.BackColor = not_on_net
                    End If

                End If
            Else
            End If
            'takeaction.Focus()
        ElseIf Not (Me.Tag = "Deploy Aircraft" Or Me.Tag = "Abort Aircraft") Then
            If units.Items(i).BackColor = golden Then
                units.Items(i).BackColor = nostatus
            Else
                For Each l As ListViewItem In units.Items
                    l.BackColor = nostatus
                Next
                units.Items(i).BackColor = golden
            End If
        Else
        End If
        units.SelectedItems.Clear()
    End Sub

    Private Sub selectnode(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles comdtree.NodeMouseClick
        Dim x As Integer = 1, parentnode As New TreeNode
        If comdtree.SelectedNode Is Nothing Then Exit Sub
        'selectunit(orbat(e.Node.Text))
        'If commanders.Items.Count <> 1 And commander.title = e.Item.Text Then Exit Sub
        'subject = orbat(e.Node.Text)
        comdtree.HideSelection = True
        If e.Node.BackColor = nostatus Then
            e.Node.BackColor = golden
        Else
            e.Node.BackColor = nostatus
        End If
        takeaction.Focus()
    End Sub

    Private Sub execute() Handles takeaction.Click
        If Me.Tag = "Command" Then
            mark_ooc(comdtree.Nodes)
            Exit Sub
        End If
        If units.Items.Count = 0 Then Me.Close() : Exit Sub
        If Me.Tag = "Deploy Aircraft" Then
            Me.Close()
        ElseIf Me.Tag = "Abort Aircraft" Then
            For Each ac As ListViewItem In units.Items
                orbat(ac.Text).lands(True)
            Next
            Me.Hide()
        Else
        End If
        Dim none_selected As Boolean = True
        For Each l As ListViewItem In units.Items
            If l.BackColor = golden And l.Text <> "Minefield" Then
                subject = New cunit
                subject = orbat(l.Text)
                i = l.Index
                none_selected = False
                Exit For
            ElseIf Me.Tag = "Opportunity Fire" And l.BackColor = golden And l.Text = "Minefield" Then
                With mine_attack
                    .tester = movement.mover
                    .subject.Text = movement.mover.title
                    .ShowDialog()
                End With
                Me.Close()
            Else
            End If
        Next
        If none_selected Then Exit Sub
        Dim tmp As String = ""
        If Me.Tag = "Transport" Then
            movement.carrier = subject
            Me.Hide()
        ElseIf Me.Tag = "Observee" Then
            movement.mover.primary = subject.title
            Me.Hide()
        ElseIf Me.Tag = "Demoralisation Recovery" Then
            Dim d As Integer = d10()
            If d >= subject.quality + 1 Then
                resultform_2.result.Text = subject.title + " has recovered from being demoralised"
                subject.demoralised = False
                For Each u As cunit In ph_units
                    If u.parent = subject.title Then u.demoralised = False
                Next
                units.Items(i).Remove()
            Else
                resultform_2.result.Text = subject.title + " has (" + Trim(Str(d)) + ") not recovered from being demoralised" + vbNewLine + "It has expended all of its Command Points and it must now retire all of its units between half and a normal move"
                units.Items(i).Remove()
            End If
            resultform_2.ShowDialog()
            If units.Items.Count = 0 Then Me.Hide()
        ElseIf Me.Tag = "Opportunity Fire" Then
            With combat_2
                .Tag = Me.Tag
                .firer = New cunit
                .firer = subject
                .f_mode.Text = subject.mode
                .targets.Visible = False
                '.selectedtarget.Text = movement.mover.title
                .combatmode = subject.nation + " " + Me.Tag
                .ShowDialog()
                .targets.Visible = True
            End With
            If orbat(units.Items(i).Text).fires Then units.Items(i).Remove()
            'Me.Hide()
        ElseIf Me.Tag = "CA Defenders" Then
            With assault
                .defender = New cunit
                .defender = subject
            End With
            Me.Hide()
        ElseIf Me.Tag = "SEAD" Then
            If subject.strength > 0 And Not subject.disrupted Then
                oppfire = False
                With combat_2
                    .Tag = "SEAD"
                    .firer = New cunit
                    .firer = subject
                    .combatmode = subject.nation + " SEAD Combat"
                    '.title.Text = combat_2.combatmode
                    .ShowDialog()
                End With
                If orbat(units.Items(i).Text).fires Then units.Items(i).Remove()
            End If
        ElseIf Me.Tag = "CAP Missions" Or Me.Tag = "Intercept" Then
            If combat_2.targets.Items.Count = 0 Then Exit Sub
            If subject.pass_quality_test(0) Then
                With combat_2
                    .Tag = IIf(Me.Tag = "Intercept", "Intercept", "CAP")
                    .firer = New cunit
                    .firer = subject
                    .combatmode = IIf(Me.Tag = "Intercept", "CAP Intercept Combat", "Simultaneous CAP Combat")
                    ' .title.Text = combat_2.combatmode
                    .ShowDialog()
                End With
                If orbat(units.Items(i).Text).fires Or Not orbat(units.Items(i).Text).airborne Then units.Items(i).Remove()
                If combat_2.targets.Items.Count = 0 Then Me.Hide()
            Else
                With resultform_2
                    .result.Text = orbat(units.Items(i).Text).title + "(" + orbat(units.Items(i).Text).equipment + ")" + " failed to intercept and has aborted"
                    .ShowDialog()
                End With
                orbat(units.Items(i).Text).lands(True)
                units.Items(i).Remove()
            End If
        ElseIf Me.Tag = "CAP AD Targets" Then
            If groundair.units.Items.Count > 0 Then
                With groundair
                    .Tag = "Air Defence against CAP Missions"
                    .ShowDialog()
                    .Tag = "groundair"
                End With
                For Each ac As ListViewItem In groundair.units.Items
                    ac.BackColor = nostatus
                Next
            End If
            units.Items(i).Remove()
        ElseIf Me.Tag = "Air Ground" Then
            If groundair.units.Items.Count > 0 Then
                groundair.ShowDialog()
            End If
            subject = orbat(units.Items(i).Text)
            If subject.strength - subject.aborts <= 0 Then
                subject.lands(False)
            Else
                oppfire = False
                With combat_2
                    .Tag = "Air Ground"
                    .firer = New cunit
                    .firer = subject
                    .combatmode = subject.nation + " Air Ground Combat"
                    '.title.Text = combat_2.combatmode
                    .ShowDialog()
                End With
                For Each ac As ListViewItem In groundair.units.Items
                    ac.BackColor = nostatus
                Next
                If orbat(units.Items(i).Text).fires And orbat(units.Items(i).Text).tacticalpts <= 0 Then units.Items(i).Remove()
            End If

        ElseIf Me.Tag = "Radar On" Then
            For j As Integer = units.Items.Count - 1 To 0 Step -1
                If units.Items(j).BackColor = golden Then
                    orbat(units.Items(j).SubItems(0).Text).eligibleCB = True
                    units.Items(j).Remove()
                End If
                If units.Items.Count = 0 Then Me.Close()
            Next
        ElseIf Me.Tag = "Arty Support" Then
            If subject Is Nothing Then Exit Sub
            For Each ar As ListViewItem In movement.undercommand.Items
                If ar.BackColor = golden Then
                    With orbat(ar.Text)
                        .task = movement.tac_opt_txt
                        .primary = subject.title
                    End With
                    ar.SubItems(2).Text = UCase(movement.tac_opt_txt)
                    ar.BackColor = in_ds
                End If
            Next
            Me.Hide()

        ElseIf InStr(Me.Tag, "Air Defence") > 0 Then
            If units.Items(i).BackColor = no_action_pts Then Exit Sub
            With combat_2
                .Tag = "Air Defence"
                .firer = New cunit
                .firer = subject
                '.selectedfirer.Text = subject.title
                .targets.Visible = True
                .combatmode = Me.Tag
                '.title.Text = subject.nation + " " + title.Text
                .ShowDialog()
            End With
            If orbat(units.Items(i).Text).fires Then units.Items(i).BackColor = no_action_pts
            If orbat(units.Items(i).Text).missiles = 0 And orbat(units.Items(i).Text).missile_armed() Then units.Items(i).Remove()

        ElseIf Me.Tag = "Observer" Then
            Dim dice As Integer = d10()
            If dice = 10 Or (subject.rockets = 2 And dice > subject.quality - 1) Or (subject.rockets = 1 And dice > subject.quality) Then
                subject.tacticalpts = subject.tacticalpts - 2
                With resultform_2
                    .result.Text = "The observer failed to communicate fire order to firing battery"
                    .ShowDialog()
                End With
                orbat(units.Items(i).Text).lostcomms = True
                units.Items(i).Remove()
            Else
                movement.observing = True
                movement.mover.carrying = units.Items(i).Text
                'combat_2.observer.Text = units.Items(i).Text
                Me.Hide()
            End If
        ElseIf Me.Tag = "Call for Fire" Then
            For j As Integer = 0 To 2
                For Each ar As ListViewItem In units.Items
                    If ar.BackColor = golden And orbat(ar.Text).rockets = j Then
                        subject = orbat(ar.Text)
                        Dim dice As Integer = d10()
                        If dice = 10 Or (subject.rockets = 2 And dice > subject.quality - 1) Or (subject.rockets = 1 And dice > subject.quality) Then
                            With resultform_2
                                .result.Text = "The observer failed to communicate fire order to firing battery"
                                .ShowDialog()
                            End With
                            movement.mover.lostcomms = True
                            Me.Hide()
                        Else
                            subject.carrying = movement.mover.title
                            'movement.load_combat(subject)
                            If subject.tacticalpts <= 0 Then units.Items(i).Remove()
                        End If
                    End If
                Next
            Next
        Else

        End If
        If (units.Visible And units.Items.Count = 0) Then Me.Hide()
    End Sub

    Private Sub unit_selection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim side As String = " - Game Turn " + scenariodefaults.gameturn.Text
        'If units.Items.Count > 0 Then side = orbat(units.Items(0).Text).nation + side

        If Me.Tag = "Transport" Then
            With Me
                .Text = "Transport Selection for " + side
                .takeaction.Text = "Load Passengers"
                .units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Tag = "Command" Then
            With Me
                .title.Text = "Command and Control Status for " + side
                .takeaction.Text = "Out of Command"
                .comdtree.Visible = True
                .units.Visible = False
                '.units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Tag = "Observee" Then
            With Me
                .Text = "Observer allocation for " + side
                .title.Text = "Allocate " + movement.mover.title + " to observe for a HQ"
                .takeaction.Text = "Allocate"
            End With

        ElseIf Me.Tag = "Opportunity Fire" Then
            populate_lists(units, enemy, "Opportunity Fire", "")
            Dim reason As String = ""
            If (movement.tactical = 0 Or movement.tactical = 2 Or movement.scoot) Then
                reason = " moving "
            ElseIf movement.tactical >= 4 Then
                reason = " mode change "
            Else
                reason = "close assault "
            End If
            With Me
                .Text = "Opportunity Fire for " + side
                .takeaction.Text = "Select Unit"
                .title.Text = "Select Unit to conduct Opportunity Fire for " + reason + "by " + movement.mover.title
                .units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Tag = "CAP Missions" Then
            With Me
                .Text = "CAP Combat Phase for " + side
                .title.Text = "Select Unit to conduct CAP Combat"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "Intercept" Then
            With Me
                .Text = "CAP Intercept Combat Phase for " + side
                .title.Text = "Select Unit to conduct CAP Intercept Combat"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "CAP AD Targets" Then
            With Me
                .Text = "Ground Air Defence against CAP Combat Phase for " + side
                .title.Text = "Select CAP Unit to be engaged by air defence"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.tag = "Air Ground" Then
            With Me
                .Text = "Air-Ground Attack Combat Phase for " + side
                .title.Text = "Select Unit to conduct Air-Ground Attack"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Mission"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "SEAD" Then
            With Me
                .Text = "SEAD Attack Combat Phase for " + side
                .title.Text = "Select Unit to conduct SEAD Attack"
                .takeaction.Text = "Execute Attack"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "Radar On" Then
            With Me
                .Text = "Initialise Radar Phase for " + side
                .title.Text = "Select Unit to Switch Radar On"
                .takeaction.Text = "Radar On"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "Deploy Aircraft" Then
            With Me
                .Text = "Deploy Aircraft Phase for " + side
                .title.Text = "Deploy the following aircraft to table"
                .takeaction.Text = "Completed"
                .units.Columns(1).Text = "Task"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "Observer" Then
            With Me
                .Text = "Select indirect fire observer for " + side
                .title.Text = "Select indirect fire observer for" + vbNewLine + movement.mover.title
                .takeaction.Text = "Selected"
                .units.Columns(1).Text = "Equipment"
                .units.Columns(2).Text = "On Net"
            End With
        ElseIf Me.Tag = "Abort Aircraft" Then
            With Me
                .Text = "Abort Aircraft Phase for " + side
                .title.Text = "The following aircraft abort missions"
                .takeaction.Text = "Completed"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "Arty Support" Then
            With Me
                .Text = "Allocate Artillery Direct Support Phase for " + side
                .title.Text = "Select the HQ you wish to receive direct support from  the highlighted artillery units"
                .takeaction.Text = "Allocate"
                .units.Columns(0).Width = 252
                .units.Columns(1).Width = 96
            End With
        ElseIf Me.Tag = "Call for Fire" Then
            With Me
                .Text = "Calling for Fire Support " + side
                .title.Text = "Available Indirect Fire Support for " + movement.mover.title
                .takeaction.Text = "Request"
                .units.Columns(0).Width = 252
                .units.Columns(1).Width = 96
            End With
        ElseIf Me.Name = "groundair" Then
            With Me
                .Text = "Air Defence Combat Phase for " + side
                .title.Text = "Select the air defence unit to fire at " + airground.subject.title
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
            'ElseIf Me.Tag = "Air Defence" Then
            '    With Me
            '        .Text = "Air Defence Combat Phase for " + side
            '        .title.Text = "Select the air defence unit to fire"
            '        .takeaction.Text = "Select Unit"
            '        .units.Columns(1).Text = "Strength"
            '        .units.Columns(2).Text = "Equipment"
            '    End With

        ElseIf Me.Tag = "CA Defenders" Then
            populate_lists(units, enemy, "CA Defenders", "")
            With Me
                .Text = "Close Assault Action for " + side
                .title.Text = "Select Unit defending against the Close Assault"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
        ElseIf Me.Tag = "Demoralisation Recovery" Then
            With Me
                .Text = "Demoralisation Recovery Phase for " + side
                .title.Text = "Select any Battlegroups you wish to recover from being demoralised"
                .takeaction.Text = "Recover from being demoralised"
                .units.Columns(0).Width = 252
                .units.Columns(1).Width = 96
                .units.Columns(1).Text = "Comd Pts"
            End With
        Else
        End If
        'If Me.Name = "airdefence" Or Me.Tag = "CAP" Or Me.Name = "unit_selection" Then
        '    For Each l As ListViewItem In units.Items
        '        orbat(l.Text).firedthistarget = False
        '    Next
        'End If
    End Sub

    Private Sub unit_selection_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.Closed
        If Me.Tag = "Opportunity Fire" Then
            oppfire = True : movement.opp_fire.BackColor = golden
        ElseIf Me.Tag = "Observer" Then
            movement.observing = False
        ElseIf Me.Tag = "Command" Then
            comdtree.Visible = False
            units.Visible = True
        Else
        End If
    End Sub

    Private Sub unit_selection_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        subject = New cunit
    End Sub

    Private Sub mark_ooc(t As TreeNodeCollection)
        For Each tn As TreeNode In t
            If tn.Nodes.Count > 0 Then mark_ooc(tn.Nodes)
            If tn.BackColor = golden Then
                orbat(tn.Text).ooc = True
                tn.BackColor = no_action_pts
            Else
                orbat(tn.Text).ooc = False
                tn.BackColor = nostatus
            End If
        Next

    End Sub

End Class