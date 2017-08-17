Public Class combat
    Public firer As cunit, target As cunit, combatmode As String
    Dim currentrange As Integer, maxrange As Integer

    Private Sub combat_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize(24 * Hour(TimeOfDay) + 60 * Minute(TimeOfDay) + Second(TimeOfDay))
        'test message

        If firer.w2 <> "" Then
            firerprimary.Enabled = True
            firersecondary.Enabled = True
            firerprimary.Checked = True
        Else
            firerprimary.Enabled = False
            firersecondary.Enabled = False
            firerprimary.Checked = False
        End If
        firerprimary.Text = firer.equipment
        firersecondary.Text = firer.w2
        firerflank.Checked = False
        targetflank.Checked = False
        firerrear.Checked = False
        targetrear.Checked = False
        firerflank.Enabled = True
        targetflank.Enabled = True
        firerrear.Enabled = True
        targetrear.Enabled = True
        firercover.Enabled = True
        select_cover_firer.Enabled = True
        targetcover.Enabled = True
        select_cover_target.Enabled = True
        title.Text = combatmode
        spot.Visible = False
        If combatmode = "Tactical Action" Then
            targets.Visible = True
            selectedtarget.Text = ""
            targetprimary.Text = ""
            targetsecondary.Text = ""
            spot.Visible = True
        ElseIf combatmode = "Opportunity Fire" Then
            selectedtarget.Text = target.title
            targets.Visible = False
            targetprimary.Text = target.equipment
            targetsecondary.Text = target.w2
            If target.Cover > 0 Then
                targetcover.Text = "+" + Trim(Str(target.Cover))
                targetcover.BackColor = Color.Goldenrod
            End If
        ElseIf combatmode = "Air Superiority" Then
            targets.Visible = True
            firerflank.Enabled = False
            targetflank.Enabled = False
            firerrear.Enabled = False
            targetrear.Enabled = False
            firercover.Enabled = False
            select_cover_firer.Enabled = False
            targetcover.Enabled = False
            select_cover_target.Enabled = False
        ElseIf combatmode = "Air-Ground Attack" Then
            targets.Visible = True
            firerflank.Enabled = False
            firerrear.Enabled = False
            firercover.Enabled = False
            select_cover_firer.Enabled = False
        ElseIf combatmode = "Air Defence" Then
            selectedtarget.Text = target.title
            targetprimary.Text = target.equipment
            targets.Visible = False
            firerflank.Enabled = False
            targetflank.Enabled = False
            firerrear.Enabled = False
            targetrear.Enabled = False
            firercover.Enabled = False
            select_cover_firer.Enabled = False
            targetcover.Enabled = False
            select_cover_target.Enabled = False
        Else
        End If
        If firer.indirect And firer.smoke > 0 Then firesmoke.Visible = True : firesmoke.Enabled = True Else firesmoke.Visible = False
        selectedfirer.Text = firer.title
        If firer.Cover > 0 Then
            firercover.Text = "+" + Trim(Str(firer.Cover))
            firercover.BackColor = Color.Goldenrod
        Else
            firercover.Text = "None"
            firercover.BackColor = Color.FromName("Control")

        End If
        If firer.observer Then
            observing.Visible = True
            visrange.Visible = True
            vis_range_select.Visible = True
            tgt_range_select.SelectedIndex = tgt_range_select.Items.Count - 1
        Else
            observing.Visible = False
            visrange.Visible = False
            vis_range_select.Visible = False
            tgt_range_select.SelectedIndex = 3
        End If
        targetprimary.Enabled = False
        targetsecondary.Enabled = False
        If selectedtarget.Text <> "" Or oppfire Then fire.Enabled = True
    End Sub

    Private Sub choose_weapon(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firerprimary.CheckedChanged, firersecondary.CheckedChanged, targetprimary.CheckedChanged, targetsecondary.CheckedChanged
        If sender.checked = False Then Exit Sub
        sender.checked = True
        sender.backcolor = Color.Goldenrod
        If InStr(sender.name, "firer") > 0 And InStr(sender.name, "primary") > 0 Then
            firersecondary.Checked = False : firersecondary.BackColor = Color.FromName("Control") : firer.primary = True
        ElseIf InStr(sender.name, "firer") > 0 And InStr(sender.name, "secondary") > 0 Then
            firerprimary.Checked = False : firerprimary.BackColor = Color.FromName("Control")
        ElseIf InStr(sender.name, "target") > 0 And InStr(sender.name, "primary") > 0 Then
            targetsecondary.Checked = False : targetsecondary.BackColor = Color.FromName("Control") : target.primary = True
        ElseIf InStr(sender.name, "target") > 0 And InStr(sender.name, "secondary") > 0 Then
            targetprimary.Checked = False : targetprimary.BackColor = Color.FromName("Control")
        Else
        End If
    End Sub

    Private Sub test()
        'another test
        'test update
    End Sub
    Private Sub select_cover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles select_cover_firer.Click, select_cover_target.Click
        Dim cover As Object
        If InStr(sender.name, "firer") > 0 Then cover = firercover Else cover = targetcover
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
        If InStr(sender.name, "firer") > 0 Then
            firer.Cover = Val(cover.text)
        Else
            target.Cover = Val(cover.text)
        End If
    End Sub

    Private Sub Flank_and_rear(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firerflank.CheckedChanged, firerrear.CheckedChanged, targetflank.CheckedChanged, targetrear.CheckedChanged
        Dim a As Object = Nothing, b As Object = Nothing
        If InStr(sender.name, "firer") > 0 And InStr(sender.name, "flank") > 0 Then
            a = firerflank
            b = firerrear
        ElseIf InStr(sender.name, "firer") > 0 And InStr(sender.name, "rear") > 0 Then
            a = firerrear
            b = firerflank
        ElseIf InStr(sender.name, "target") > 0 And InStr(sender.name, "flank") > 0 Then
            a = targetflank
            b = targetrear
        ElseIf InStr(sender.name, "target") > 0 And InStr(sender.name, "rear") > 0 Then
            a = targetrear
            b = targetflank
        Else
        End If
        If a.Checked Then
            a.BackColor = Color.Goldenrod
            b.BackColor = Color.FromName("Control")
            b.Checked = False
        Else
            a.BackColor = Color.FromName("Control")
        End If

    End Sub

    Private Sub combat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        movement.notfired = True
    End Sub

    Private Sub targets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles targets.ItemSelectionChanged
        target = orbat(e.Item.Text)
        selectedtarget.Text = target.title
        If target.w2 <> "" Then
            targetprimary.Enabled = True
            targetsecondary.Enabled = True
            targetprimary.Checked = True
        Else
            targetprimary.Enabled = False
            targetsecondary.Enabled = False
            targetprimary.Checked = False
        End If
        targetprimary.Text = target.equipment
        targetsecondary.Text = target.w2
        If target.Cover > 0 Then
            targetcover.Text = "+" + Trim(Str(target.Cover))
            targetcover.BackColor = Color.Goldenrod
        Else
            targetcover.Text = "None"
            targetcover.BackColor = Color.FromName("Control")
        End If
    End Sub

    Private Sub fire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fire.Click, spot.Click
        If tgt_range.Text = "Range" Then Exit Sub
        If firer.observer And visrange.Text = "Vis Range" Then Exit Sub
        If selectedtarget.Text = "" Then Exit Sub

        If firer.airborne And firer.ordnance And Val(tgt_range.Text) > 1000 Then firer.ordnance = False
        If Not oppfire And sender.name = "fire" Then
            resolvefire(ph_units, firer, enemy, target, Me.Tag)
        ElseIf oppfire And sender.name = "fire" Then
            resolvefire(enemy, firer, ph_units, target, Me.Tag)
        ElseIf sender.name = "spot" Then
            If spotting(Val(tgt_range.Text), target, firer.airborne) Then
                resultform.result.Text = "Target Spotted"
            Else
                resultform.result.Text = "Target has not been spotted"
            End If
            resultform.ShowDialog()
        Else

        End If

        Me.Hide()
    End Sub

    Private Sub select_ranges(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vis_range_select.SelectedIndexChanged, tgt_range_select.SelectedIndexChanged
        Dim primary As Boolean, hitmax As Boolean = False
        If firerprimary.Checked Or Not firerprimary.Enabled Then primary = True Else primary = False
        If InStr(sender.name, "tgt") > 0 Then
            tgt_range.Text = tgt_range_select.SelectedItem
            If tgt_range_select.SelectedItem > getmaxrange(firer, primary) Then
                tgt_range_select.SelectedItem = getmaxrange(firer, primary)
                hitmax = True
            End If
        Else
            visrange.Text = vis_range_select.SelectedItem
        End If

    End Sub

    Private Sub firesmoke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles firesmoke.Click
        firer.smoke = firer.smoke - 1
        Me.Hide()
        resultform.result.Text = "Smoke Fired"
        resultform.ShowDialog()
        smokefiredthisturn = True
    End Sub
End Class