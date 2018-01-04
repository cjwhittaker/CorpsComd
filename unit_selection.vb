Public Class unit_selection
    Dim i As Integer = -1, subject As cunit

    Private Sub units_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles units.Click
        If units.SelectedItems.Count = 0 Then Exit Sub
        i = units.FocusedItem.Index
        If units.Items(i).Text <> "Minefield" Then
            subject = New cunit
            subject = orbat(units.FocusedItem.Text)
        End If
        If Me.Tag = "Radar On" Or Me.Tag = "Command" Then
            If units.Items(i).Focused And units.Items(i).BackColor <> golden Then
                If Not subject.disrupted Then units.Items(i).BackColor = golden
            ElseIf units.Items(i).Focused And units.Items(i).BackColor = golden Then
                units.Items(i).BackColor = subject.status
            End If
            units.SelectedItems.Clear()
            'takeaction.Focus()
        End If
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
        If units.Visible And units.Items.Count = 0 Then Me.Hide() : Exit Sub
        If units.Visible And units.Items.Count = 1 And units.Items(0).Text <> "Minefield" Then
            subject = New cunit
            subject = orbat(units.Items(0).Text)
        End If
        If units.Visible And (subject Is Nothing Or subject.title = "") And Not (Me.Tag = "Deploy Aircraft" Or Me.Tag = "Abort Aircraft" Or units.Items(0).Text = "Minefield") Then
            Exit Sub
        End If
        Dim tmp As String = ""
        If Me.Tag = "Deploy Aircraft" Then
            Me.Close()
        ElseIf Me.Tag = "Abort Aircraft" Then
            For Each l As ListViewItem In units.Items
                orbat(l.Text).lands(True)
            Next
            Me.Hide()
        ElseIf Me.Tag = "Transport" Then
            movement.carrier = subject
            Me.Hide()
        ElseIf Me.Tag = "Observee" Then
            movement.mover.primary = subject.title
            Me.Hide()
        ElseIf Me.Tag = "Command" Then
            mark_ooc(comdtree.Nodes)
        ElseIf Me.Tag = "Demoralisation Recovery" Then
            Dim d As Integer = d10()
            If d >= subject.quality + 1 Then
                resultform.result.Text = subject.title + " has recovered from being demoralised"
                subject.demoralised = False
                For Each u As cunit In ph_units
                    If u.parent = subject.title Then u.demoralised = False
                Next
                units.Items(i).Remove()
            Else
                resultform.result.Text = subject.title + " has (" + Trim(Str(d)) + ") not recovered from being demoralised" + vbNewLine + "It has expended all of its Command Points and it must now retire all of its units between half and a normal move"
                units.Items(i).Remove()
            End If
            resultform.ShowDialog()
            If units.Items.Count = 0 Then Me.Hide()
        ElseIf Me.Tag = "Opportunity Fire" Then
            If units.Items(i).Text = "Minefield" Then
                With mine_attack
                    .tester = movement.mover
                    .subject.Text = movement.mover.title
                    .ShowDialog()

                End With
            Else
                With combat
                    .Tag = Me.Tag
                    .firer = New cunit
                    .firer = subject
                    .targets.Visible = False
                    .selectedtarget.Text = movement.mover.title
                    .combatmode = subject.nation + " " + Me.Tag
                    .ShowDialog()
                    .targets.Visible = True
                End With
                If orbat(units.Items(i).Text).fires Then units.Items(i).Remove()
            End If
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
                With combat
                    .Tag = "SEAD"
                    .firer = New cunit
                    .firer = subject
                    .combatmode = subject.nation + " SEAD Combat"
                    .title.Text = combat.combatmode
                    .ShowDialog()
                End With
                If orbat(units.Items(i).Text).fires Then units.Items(i).Remove()
            End If
        ElseIf Me.Tag = "CAP Missions" Then
            If combat.targets.Items.Count = 0 Then Exit Sub
            If subject.pass_quality_test(0) Then
                With combat
                    .Tag = "CAP"
                    .firer = New cunit
                    .firer = subject
                    .combatmode = "Simultaneous Air-to-Air Combat"
                    .title.Text = combat.combatmode + " Combat"
                    .ShowDialog()
                End With
                If orbat(units.Items(i).Text).fires Then units.Items(i).Remove()
                If combat.targets.Items.Count = 0 Then Me.Hide()
            Else
                With resultform
                    .result.Text = orbat(units.Items(i).Text).title + "(" + orbat(units.Items(i).Text).equipment + ")" + " failed to intercept and has aborted"
                    .ShowDialog()
                End With
                orbat(units.Items(i).Text).lands(True)
                units.Items(i).Remove()
            End If
        ElseIf Me.Tag = "Air Ground" Then
            If subject.strength > 0 And Not subject.disrupted Then
                oppfire = False
                With combat
                    .Tag = "Air Ground"
                    .firer = New cunit
                    .firer = subject
                    .combatmode = subject.nation + " Air Ground Combat"
                    .title.Text = combat.combatmode
                    .ShowDialog()
                End With
                If orbat(units.Items(i).Text).fires And orbat(units.Items(i).Text).tacticalpts <= 0 Then units.Items(i).Remove()
            End If
        ElseIf Me.Tag = "Radar On" Then
            For j As Integer = units.Items.Count - 1 To 0 Step -1
                If units.Items(j).BackColor = golden Then
                    orbat(units.Items(j).SubItems(0).Text).eligibleCB = True
                    units.Items(j).Remove()
                End If
                If units.Items.Count = 0 Then Me.Hide()
            Next
        ElseIf Me.Tag = "Arty Support" Then
            If subject Is Nothing Then Exit Sub
            For Each l As ListViewItem In movement.undercommand.Items
                If l.BackColor = golden Then
                    With orbat(l.Text)
                        .task = movement.tac_opt_txt
                        .primary = subject.title
                    End With
                    l.SubItems(2).Text = UCase(movement.tac_opt_txt)
                    l.BackColor = in_ds
                End If
            Next
            Me.Hide()

        ElseIf Me.Tag = "Air Defence" Then
            If combat.targets.Items.Count > 0 Then
                With combat
                    .Tag = "Air Defence"
                    .firer = New cunit
                    .firer = subject
                    .selectedfirer.Text = subject.title
                    .targets.Visible = True
                    .combatmode = .Tag
                    .title.Text = subject.nation + " " + title.Text
                    .ShowDialog()
                End With
            End If
            If orbat(units.Items(i).Text).fires Then units.Items(i).Remove()
        ElseIf Me.Tag = "Observer" Then

            Dim dice As Integer = d10()
            If dice = 10 Or (subject.statusimpact = 2 And dice > subject.quality - 1) Or (subject.statusimpact = 1 And dice > subject.quality) Then
                subject.tacticalpts = subject.tacticalpts - 2
                With resultform
                    .result.Text = "The observer failed to communicate fire order to firing battery"
                    .ShowDialog()
                End With
                orbat(units.Items(i).Text).lostcomms = True
                units.Items(i).Remove()
            Else
                movement.observing = True
                combat.observer.Text = units.Items(i).Text
                Me.Hide()
            End If

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
        ElseIf Me.Tag = "Air Ground" Then
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
        ElseIf Me.Tag = "Air Defence" Then
            With Me
                .Text = "Air Defence Combat Phase for " + side
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
                .units.Columns(2).Text = "Equipment"
            End With
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