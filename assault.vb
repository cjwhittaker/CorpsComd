Public Class assault
    Public defender As cunit, attacker As cunit, supporter As cunit
    Private Sub select_unit(ByVal sender As Object, ByVal e As System.EventArgs) Handles supports.Click, defenders.Click
        reset_factors()

        If sender.FocusedItem.BackColor = golden Then
            sender.FocusedItem.BackColor = orbat(sender.focuseditem.text).status("")
            If sender.name = "supports" Then supporter = New cunit Else defender = New cunit
            defender = New cunit
            d_arty.Items.Clear()
        Else
            For Each l As ListViewItem In sender.items
                If l.BackColor = golden Then l.BackColor = orbat(l.Text).status("")
            Next
            sender.FocusedItem.BackColor = golden
            If sender.name = "supports" Then supporter = orbat(sender.FocusedItem.Text) Else defender = orbat(sender.FocusedItem.Text)
            If sender.name = "defenders" Then
                d_arty.Items.Clear()
                populate_lists(d_arty, enemy, "Artillery Support", defender.parent)
                If enemy(defenders.FocusedItem.Text).cover > 0 Then
                    cover.Text = "+" + Trim(Str(enemy(defenders.FocusedItem.Text).cover))
                    cover.BackColor = golden
                Else
                End If
            End If

        End If
        sender.SelectedItems.Clear()
    End Sub

    Private Sub conduct_close_assault() Handles fight.Click
        Dim modi As Integer = 0, odds As Single = 0, result_string = "Close Assault Results" + vbNewLine
        firing_result = ""
        attacker.assault = True : supporter.assault = True
        modi = close_assault_difference()
        odds = close_assault_ratio(attacker, supporter, defender)
        modi = modi + Asc(attacker.quality) - Asc(defender.quality)
        If odds > 1 Then
            modi = modi + Int(odds) - 1
        ElseIf odds < 1 Then
            modi = modi - Int(1 / odds) + 1
        Else
        End If
        modi = modi + arty_support(a_arty, True)
        modi = modi - arty_support(d_arty, True)
        modi = modi - defender.Cover
        If attacker.engr Or supporter.engr Then modi = modi + defender.Cover
        'If uphill.Checked Then modi = modi - 1
        If Not supporter.title Is Nothing Then
            If (attacker.Inf And supporter.afv) Or (supporter.Inf And attacker.afv) Then modi = modi + 2
            If (attacker.afv Or supporter.afv) And atgw_spt.BackColor = golden Then modi = modi - 2
        End If
        If afv_spt.BackColor = golden Then modi = modi - 1
        'If defender.disrupted Then modi = modi + 4
        Dim r As Integer = d6()
        firing_result = "(" + Trim(Str(modi)) + "+" + Trim(Str(r)) + ")"
        modi = modi + r
        attacker.casualties = 0 : defender.casualties = 0
        Select Case modi
            Case Is <= 0
                attacker.casualties = 2
            Case Is <= 2
                attacker.casualties = 1
            Case Is <= 7

            Case Is <= 9
                defender.casualties = 1
            Case Is <= 11
                defender.casualties = 2
            Case Is >= 12
                defender.casualties = 3
        End Select
        attacker.cas_gt = attacker.cas_gt + attacker.casualties
        defender.cas_gt = defender.cas_gt + defender.casualties
        If modi <= 5 Then
            If attacker.strength - attacker.casualties <= 0 Then
                supporter.casualties = supporter.casualties + attacker.strength - attacker.casualties
                attacker.casualties = attacker.strength
            Else
                supporter.casualties = 0
            End If
            With attacker
                .disrupted = True
                .apply_casualties()
                .update_parent("failed CA")
            End With
            If Not supporter.title Is Nothing Then
                With supporter
                    .disrupted = True
                    .apply_casualties()
                End With
            End If
            If modi < 5 Then defender.update_parent("successful CA")
        End If
        If modi >= 5 Then
            If defender.disrupted Then
                With defender
                    .casualties = defender.strength
                    .apply_casualties()
                End With
            Else
                With defender
                    .disrupted = True
                    .apply_casualties()
                End With
                defender.update_parent("failed CA")
            End If
            If modi > 5 Then attacker.update_parent("successful CA")
        End If
        If modi < 5 Then
            result_string = attacker.title + " " + generateresult(attacker, 2, False, False, True)
            If Not supporter.title Is Nothing Then result_string = result_string + vbNewLine + supporter.title + " " + generateresult(supporter, 2, False, False, True)
        ElseIf modi = 5 Then
            result_string = attacker.title + " " + generateresult(attacker, 2, False, False, True)
            If Not supporter.title Is Nothing Then result_string = result_string + vbNewLine + supporter.title + " " + generateresult(supporter, 2, False, False, True)
            result_string = result_string + vbNewLine + defender.title + " " + generateresult(defender, 1, False, False, True)
        Else
            result_string = defender.title + " " + generateresult(defender, 2, False, False, True)
        End If
        With resultform_2
            .result.Text = result_string
            .Tag = "ca"
            .ok_button.Visible = True
            .yb.Text = "Defender Destroyed"
            .yb.Visible = IIf(InStr(result_string, "retreat") > 0, True, False)
            .ShowDialog()
            .yb.Text = "Yes"
            .nb.Text = "No"
            .yb.Visible = False
            .nb.Visible = False
        End With
        If resultform_2.Tag = "ca destroyed" Then
            With defender
                .casualties = defender.strength
                .apply_casualties()
            End With
        End If
        'If modi <= 2 Then applyresult(attacker)
        'If modi >= 8 And defender.strength > 0 Then applyresult(defender)
        For Each l As ListViewItem In movement.undercommand.Items
            If l.Text = attacker.title Then l.Remove()
        Next
        If Not supporter.title Is Nothing Then
            For Each l As ListViewItem In movement.undercommand.Items
                If l.Text = supporter.title Then l.Remove()
            Next
        End If
        Me.Hide()
    End Sub
    Private Function close_assault_ratio(a As cunit, s As cunit, d As cunit)
        close_assault_ratio = 1
        Dim at As Integer = 0, dt As Integer = 0
        If a.Inf And a.dismounted And a.atgw Then
            at = a.strength / 3 + s.strength
        ElseIf s.Inf And s.dismounted And s.atgw Then
            at = a.strength + s.strength / 3
        ElseIf s Is Nothing Or s.title = "" Then
            at = a.strength
        Else
            at = a.strength + s.strength
        End If
        If defile.backcolor = golden Then at = at / 2
        If d.Inf And d.dismounted And d.atgw Then dt = d.strength / 3 Else dt = d.strength
        close_assault_ratio = at / dt
    End Function
    Private Function close_assault_difference()
        close_assault_difference = 0
        Dim ac As Integer = attacker.cae(defender.armour), dc As Integer = defender.cae(attacker.armour)
        If attacker.troopcarrier And attacker.afv And attacker.embussed And Not defender.afv Then ac = ac + 2
        If attacker.disrupted Then
            ac = ac - 4
            If ac > 4 Then ac = 4
        ElseIf attacker.mode = disp And Not attacker.dismounted And Not defender.armour Then
            ac = ac - 2
        Else
        End If

        If defender.troopcarrier And defender.afv And defender.embussed And Not attacker.afv Then dc = dc + 2
        If defender.disrupted Then
            dc = dc - 4
            If dc > 4 Then dc = 4
        ElseIf defender.mode = disp And Not (defender.dismounted And (attacker.armour Or supporter.armour)) Then
            dc = dc - 2
        Else
        End If

        close_assault_difference = ac - dc

    End Function

    Private Sub select_cover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cover.Click
        If cover.Text = "None" Then
            cover.Text = "+1" : cover.BackColor = golden
        ElseIf cover.Text = "+1" Then
            cover.Text = "+2"
        ElseIf cover.Text = "+2" Then
            cover.Text = "+3"
        Else
            cover.Text = "None" : cover.BackColor = defa
        End If
        defender.Cover = Val(cover.Text)
    End Sub
    Public Sub reset_factors()
        For Each c As Control In factors.Controls
            If c.BackColor = golden Then
                c.Text = Tag
                c.BackColor = defa
            End If
        Next
    End Sub

    Private Sub Factors_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles afv_spt.Click, atgw_spt.Click, defile.Click
        Dim tmp As String = sender.text
        If sender.checked Then
            sender.backcolor = golden
        Else
            sender.backcolor = defa
        End If
        sender.text = sender.tag
        sender.tag = tmp
    End Sub

    Private Sub select_arty_spt(ByVal sender As Object, ByVal e As System.EventArgs) Handles a_arty.Click, d_arty.Click
        If sender.focuseditem.BackColor = golden Then
            sender.focuseditem.BackColor = nostatus
        ElseIf sender.focuseditem.BackColor <> golden Then
            sender.focuseditem.BackColor = golden
            If arty_support(sender, False) > 4 Then sender.focuseditem.BackColor = nostatus
        Else
        End If
        sender.selecteditems.clear
    End Sub

    Private Function arty_support(ByVal spt As ListView, fired As Boolean)
        arty_support = 0
        For Each l As ListViewItem In spt.Items
            If l.BackColor = golden Then
                arty_support = arty_support + orbat(l.Text).strength
                If fired Then
                    With orbat(l.Text)
                        .fired = gt
                        .support = True
                    End With
                End If
            End If
        Next
        Dim i As Integer = 0
        If Strings.Left(spt.Name, 1) = "a" Then i = 6 Else i = 4

        arty_support = Int(arty_support / i)
        'If arty_support > 4 Then arty_support = 4
    End Function
End Class