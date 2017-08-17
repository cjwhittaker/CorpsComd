Public Class unit_selection
    Dim subject As cunit, i As Integer

    Private Sub units_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles units.ItemSelectionChanged
        subject = orbat(e.Item.Text)
        i = e.ItemIndex
    End Sub

    Private Sub execute() Handles takeaction.Click
        If subject Is Nothing Then Exit Sub
        If Me.Name = "transport" Then
            movement.carrier = subject
            Me.Hide()
        ElseIf Me.Name = "demoralisationrecovery" Then
            If subject.comdpts = 0 Then Exit Sub
            'Me.Hide()
            subject.comdpts = subject.comdpts - 1
            units.Items(i).SubItems(1).Text = subject.comdpts
            Dim d As Integer = d6()
            If d >= Asc(subject.quality) - 62 Then
                resultform.result.Text = subject.title + " has recovered from being demoralised"
                subject.demoralised = False
                For Each u As cunit In ph_units
                    If u.parent = subject.title Then u.demoralised = False : u.routed = False
                Next
                units.Items(i).Remove()
            ElseIf subject.comdpts = 0 Then
                resultform.result.Text = subject.title + " has (" + Trim(Str(d)) + ") not recovered from being demoralised" + vbNewLine + "It has expended all of its Command Points and it must now retire all of its units between half and a normal move"
                units.Items(i).Remove()
            Else
                resultform.result.Text = subject.title + " has (" + Trim(Str(d)) + ") not recovered from being demoralised"
            End If
            resultform.ShowDialog()
            If units.Items.Count = 0 Then Me.Hide() Else Me.Focus()
        ElseIf subject.firedthistarget And (Me.Name = "opportunityfire" Or Me.Name = "airdefence" Or Me.Tag = "Air Superiority") Then
            Exit Sub
        ElseIf Me.Name = "opportunityfire" And Not subject Is Nothing Then
            If subject.tacticalpts >= 0 Then
                With combat
                    .firer = New cunit
                    .firer = subject
                    .target = New cunit
                    .target = movement.mover
                    .targets.Visible = False
                    .selectedtarget.Text = movement.mover.title
                    .combatmode = "Opportunity Fire"
                    .ShowDialog()
                    .targets.Visible = True
                End With
                subject.firedthistarget = True
            End If
            'Me.Hide()
        ElseIf Me.Name = "ca_defender" And Not subject Is Nothing Then
            With assault
                .defender = New cunit
                .defender = subject
            End With
            Me.Hide()
        ElseIf Me.Tag = "Air Superiority" And Not subject.fired And subject.tacticalpts - 2 >= 0 Then
            If subject.strength > 0 And Not (subject.repulsed Or subject.routed) Then
                With combat
                    .firer = New cunit
                    .firer = subject
                    .combatmode = "Air Superiority"
                    .title.Text = combat.combatmode + " Combat"
                    .Tag = "Air Superiority"
                    .ShowDialog()
                End With
                subject.tacticalpts = subject.tacticalpts - 2
                subject.firedthistarget = True
            End If
        ElseIf Me.Tag = "Air-Ground Attack" Then
            If subject.tacticalpts - 2 >= 0 Then
                populate_lists(airdefence.units, enemy, "Air Defence", "")
                airdefence.ShowDialog()
                If subject.strength > 0 And Not (subject.repulsed Or subject.routed) Then
                    oppfire = False
                    With combat
                        .firer = New cunit
                        .firer = subject
                        .Tag = "Air-Ground Attack"
                        .combatmode = "Air-Ground Attack"
                        .title.Text = combat.combatmode
                        .ShowDialog()
                    End With
                    subject.tacticalpts = subject.tacticalpts - 2
                    subject.firedthistarget = True
                End If
            End If
        ElseIf Me.Name = "airdefence" Then
            With combat
                .firer = New cunit
                .firer = subject
                .target = New cunit
                .target = aircombat.subject
                .targets.Visible = False
                .selectedtarget.Text = aircombat.subject.title
                .Tag = "Air Defence"
                .combatmode = "Air Defence"
                .title.Text = combat.combatmode + " Engagement"
                .ShowDialog()
                .targets.Visible = True
            End With
            subject.firedthistarget = True
            'Me.Hide()
            Else

            End If
    End Sub

    Private Sub unit_selection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Name = "transport" Then
            With Me
                .Text = "Transport Selection"
                .takeaction.Text = "Load Passengers"
                .units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Name = "opportunityfire" Then
            With Me
                .Text = "Opportunity Fire"
                .takeaction.Text = "Select Unit"
                .title.Text = "Select Unit to conduct Opportunity Fire against " + movement.mover.title
                .units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Tag = "Air Superiority" Then
            With Me
                .Tag = "Air Superiority"
                .Text = "Air Superiority Combat Phase for " + ph + " - Game Turn " + scenariodefaults.gameturn.Text
                .title.Text = "Select Unit to conduct Air Superiority Combat"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Tag = "Air-Ground Attack" Then
            With Me
                .Tag = "Air-Ground Attack"
                .Text = "Air-Ground Attack Combat Phase for " + ph + " - Game Turn " + scenariodefaults.gameturn.Text
                .title.Text = "Select Unit to conduct Air-Ground Attack"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Name = "airdefence" Then
            With Me
                .Tag = "Air Defence"
                .Text = "Air Defence Combat Phase for " + nph + " - Game Turn " + scenariodefaults.gameturn.Text
                .title.Text = "Select Unit to conduct Air Defence Task"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Strength"
            End With
        ElseIf Me.Name = "ca_defender" Then
            With Me
                .Tag = "ca defence"
                .Text = "Close Assault Action for " + ph + " - Game Turn " + scenariodefaults.gameturn.Text
                .title.Text = "Select Unit to defend against the Close Assault"
                .takeaction.Text = "Select Unit"
                .units.Columns(1).Text = "Eqpt"
            End With
        ElseIf Me.Name = "demoralisationrecovery" Then
            With Me
                .Tag = "demoralisationrecovery"
                .Text = "Demoralisation Recovery Phase for " + ph + " - Game Turn " + scenariodefaults.gameturn.Text
                .title.Text = "Select any Battlegroups you wish to recover from being demoralised"
                .takeaction.Text = "Recover from being demoralised"
                .units.Columns(0).Width = 252
                .units.Columns(1).Width = 96
                .units.Columns(1).Text = "Comd Pts"
            End With
        Else
        End If
        If Me.Name = "airdefence" Or Me.Tag = "Air Superiority" Or Me.Name = "opportunityfire" Then
            For Each l As ListViewItem In units.Items
                orbat(l.Text).firedthistarget = False
            Next
        End If
    End Sub

    Private Sub unit_selection_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If Me.Name = "opportunityfire" Then
            oppfire = False : movement.opp_fire.Checked = False
        End If
    End Sub
End Class