Public Class assault
    Public defender As cunit, attacker As cunit, supporter As cunit

    Private Sub conduct_close_assault() Handles fight.Click
        Dim modi As Integer = 0, odds As Single = 0
        modi = close_assault_difference(attacker, defender)
        odds = close_assault_ratio(attacker, supporter, defender, defile.Checked)
        modi = modi + Asc(attacker.quality) - Asc(defender.quality)
        If odds > 1 Then
            modi = modi + Int(odds) - 1
        ElseIf odds < 1 Then
            modi = modi - Int(1 / odds) + 1
        Else
        End If
        modi = modi + arty_support(a_arty_spt)
        modi = modi - arty_support(d_arty_spt)
        If cover.Text <> "None" Then modi = modi - (1 + Val(cover.Text))
        If engr.Checked Then modi = modi + 1 + Val(cover.Text)
        If uphill.Checked Then modi = modi - 1
        If (attacker.Inf And supporter.afv) Or (supporter.Inf And attacker.afv) Or (attacker.Inf And attacker.debussed And attacker.loaded <> "" And orbat(attacker.loaded).afv) Then modi = modi + 2
        If (attacker.afv Or supporter.afv Or (attacker.Inf And attacker.debussed And attacker.loaded <> "" And orbat(attacker.loaded).afv)) And atgw_spt.Checked = True Then modi = modi - 2
        If defender.disrupted Then modi = modi + 4
        modi = modi + d6()
        Select Case modi
            Case Is <= 0
                attacker.casualties = 2
            Case Is <= 2
                attacker.casualties = 1
            Case Is <= 7
                defender.casualties = 0
            Case Is <= 9
                defender.casualties = 1
            Case Is <= 11
                defender.casualties = 2
            Case Is >= 12
                defender.casualties = 3
        End Select
        If modi <= 5 Then attacker.disrupted = True
        If modi >= 5 And defender.disrupted Then
            With defender
                .strength = 0
                .casualties = 0
                .hits = 0
            End With
        ElseIf modi >= 5 And Not defender.disrupted Then
            defender.disrupted = True
        Else
        End If
        If modi < 5 Then
            resultform.result.Text = attacker.title + " " + generateresult(attacker, 2, False, False, True)
        ElseIf modi = 5 Then
            resultform.result.Text = attacker.title + " " + generateresult(attacker, 2, False, False, True)
            resultform.result.Text = resultform.result.Text + vbNewLine + defender.title + " " + generateresult(defender, 1, False, False, True)
        Else
            resultform.result.Text = defender.title + " " + generateresult(defender, 2, False, False, True)
        End If
        With resultform
            .Tag = "ca"
            .ok_button.Visible = True
            .yb.Visible = IIf(InStr(Me.Text, "retreat") > 0, True, False)
            .yb.Text = "Defender destroyed"
            .ShowDialog()
            .yb.Text = "Yes"
            .nb.Text = "No"
            .yb.Visible = False
            .nb.Visible = False
        End With
        If resultform.Tag = " has been destroyed" Then defender.casualties = defender.strength
        If modi <= 2 Then applyresult(attacker)
        If modi >= 8 And defender.strength > 0 Then applyresult(defender)
        Me.Hide()
    End Sub
    Private Function close_assault_ratio(a As cunit, s As cunit, d As cunit, defile As Boolean)
        close_assault_ratio = 1
        Dim at As Integer = 0, dt As Integer = 0
        If a.Inf And a.debussed And a.loaded <> "" Then
            at = a.strength + s.strength
        ElseIf s Is Nothing Or s.title = "" Then
            at = a.strength
        Else
            at = a.strength + s.strength
        End If
        If defile Then at = at / 2
        If d.Inf And d.debussed And d.loaded <> "" Then dt = d.strength + orbat(d.loaded).strength Else dt = d.strength
        close_assault_ratio = at / dt
    End Function
    Private Function close_assault_difference(a As cunit, d As cunit)
        close_assault_difference = 0
        Dim ac As Integer = 0, dc As Integer = 0
        If a.loaded = "" Then
            ac = a.cae(d.armour)
        ElseIf a.Inf And a.debussed Then
            ac = a.cae(d.armour) + orbat(a.loaded).cae(d.armour) / 2
        ElseIf a.troopcarrier And Not a.debussed Then
            ac = a.cae(d.armour) + IIf(d.armour, 0, orbat(a.loaded).cae(d.armour) / 2)
        Else
            ac = 0
        End If
        If d.loaded = "" Then
            dc = d.cae(a.armour)
        ElseIf d.Inf And d.debussed Then
            dc = d.cae(a.armour) + orbat(d.loaded).cae(a.armour) / 2
        ElseIf d.troopcarrier And Not d.debussed Then
            dc = d.cae(a.armour) + IIf(a.armour, 0, orbat(d.loaded).cae(a.armour) / 2)
        Else
            dc = 0
        End If
        close_assault_difference = ac - dc

    End Function

    Private Sub select_cover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles select_cover.Click
        If cover.Text = "None" Then
            cover.Text = "+1" : cover.BackColor = Color.DarkGoldenrod
        ElseIf cover.Text = "+1" Then
            cover.Text = "+2"
        ElseIf cover.Text = "+2" Then
            cover.Text = "+3"
        Else
            cover.Text = "None" : cover.BackColor =defa
        End If
        defender.Cover = Val(cover.text)
    End Sub

    Private Sub assault_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If defender.Cover > 0 Then
            cover.Text = "+" + Trim(Val(defender.Cover))
            cover.BackColor = golden
        End If
        assaulting.Text = attacker.title
        defending.Text = defender.title
        If attacker.Inf And attacker.debussed And attacker.loaded <> "" Then
            supporting.Text = attacker.loaded
            supporter = orbat(attacker.loaded)
        Else
            supporting.Text = supporter.title
        End If
        If defender.troopcarrier And Not defender.debussed Then debus.Visible = True Else debus.Visible = False
    End Sub

    Private Sub Factors_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles engr.CheckedChanged, uphill.CheckedChanged, afv_spt.CheckedChanged, atgw_spt.CheckedChanged, defile.CheckedChanged
        If sender.checked Then
            sender.backcolor = golden
        Else
            sender.backcolor =defa
        End If
    End Sub

    Private Sub debus_Click(sender As Object, e As EventArgs) Handles debus.Click
        If debus.BackColor = golden Then Exit Sub
        debus.BackColor = golden
        defender.debussed = True
        movement.debus(defender, False)
        defender = orbat(defender.loaded)
        defending.Text = defender.title
    End Sub

    Private Sub select_arty_spt(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles a_arty_spt.ItemSelectionChanged, d_arty_spt.ItemSelectionChanged
        If Not e.IsSelected Then Exit Sub
        If sender.items.count = 0 Then Exit Sub
        Dim j As Integer = e.ItemIndex
        If sender.Items(j).BackColor = golden Then
            sender.Items(j).BackColor = nostatus
            Exit Sub
        ElseIf sender.Items(j).BackColor = nostatus Then
            sender.Items(j).BackColor = golden
        Else
        End If
    End Sub

    Private Function arty_support(ByVal spt As ListView)
        arty_support = 0
        For Each l As ListViewItem In spt.Items
            If l.BackColor = golden Then
                arty_support = arty_support + orbat(l.Text).strength
            End If
        Next
        Dim i As Integer = 0
        If Strings.Left(spt.Name, 1) = "a" Then i = 6 Else i = 4

        arty_support = Int(arty_support / i)
        If arty_support > 4 Then arty_support = 4
    End Function
End Class