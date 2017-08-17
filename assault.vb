Public Class assault
    Public defender As cunit, attacker As cunit, supporter As cunit

    Private Sub conduct_close_assault() Handles fight.Click
        Dim modi As Integer = 0, attack_str As Integer = 0
        modi = attacker.cae - defender.cae
        attack_str = attacker.strength + supporter.strength
        If defile.Checked Then attack_str = Int(attack_str / 2)
        modi = modi + Asc(attacker.quality) - Asc(defender.quality)
        If attacker.strength + supporter.strength >= defender.strength Then
            modi = modi + Int(attack_str / defender.strength)
        Else
            modi = modi - Int(defender.strength / attack_str)
        End If
        modi = modi + arty_support(a_arty_spt)
        modi = modi - arty_support(d_arty_spt)
        If cover.Text <> "None" Then modi = modi - (1 + Val(cover.Text))
        If engr.Checked Then modi = modi + 1 + Val(cover.Text)
        If uphill.Checked Then modi = modi - 1
        If (attacker.Inf And supporter.afv) + (supporter.Inf And attacker.afv) Then modi = modi + 2
        If (attacker.afv Or supporter.afv) And atgw_spt.Checked = True Then modi = modi - 2
        If defender.pinned Or defender.repulsed Then modi = modi + 2
        If defender.routed Then modi = modi + 4
        modi = modi + defender.suppression - attacker.suppression
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
        If modi < 5 Then
            resultform.result.Text = defender.title + " " + applyresult(attacker, 2, False, True)
        ElseIf modi = 5 Then
            resultform.result.Text = defender.title + " " + applyresult(attacker, 2, False, True)
            resultform.result.Text = resultform.result.Text + vbNewLine + attacker.title + " " + applyresult(defender, 1, False, True)
        Else
            resultform.result.Text = attacker.title + " " + applyresult(defender, 2, False, True)
        End If
        resultform.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub select_cover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles select_cover.Click
        If cover.Text = "None" Then
            cover.Text = "+1" : cover.BackColor = Color.DarkGoldenrod
        ElseIf cover.Text = "+1" Then
            cover.Text = "+2"
        ElseIf cover.Text = "+2" Then
            cover.Text = "+3"
        Else
            cover.Text = "None" : cover.BackColor = Color.FromName("Control")
        End If
        defender.Cover = Val(cover.text)
    End Sub

    Private Sub assault_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If defender.Cover > 0 Then
            cover.Text = "+" + Trim(Val(defender.Cover))
            cover.BackColor = Color.Goldenrod
        End If
        assaulting.Text = attacker.title
        defending.Text = defender.title
        supporting.Text = supporter.title
    End Sub

    Private Sub Factors_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles engr.CheckedChanged, uphill.CheckedChanged, afv_spt.CheckedChanged, atgw_spt.CheckedChanged, defile.CheckedChanged
        If sender.checked Then
            sender.backcolor = Color.Goldenrod
        Else
            sender.backcolor = Color.FromName("Control")
        End If
    End Sub

    Private Sub select_arty_spt(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles a_arty_spt.ItemSelectionChanged, d_arty_spt.ItemSelectionChanged
        If Not e.IsSelected Then Exit Sub
        If sender.items.count = 0 Then Exit Sub
        Dim j As Integer = e.ItemIndex
        If sender.Items(j).BackColor = Color.Goldenrod Then
            sender.Items(j).BackColor = nostatus
            Exit Sub
        ElseIf sender.Items(j).BackColor = nostatus Then
            sender.Items(j).BackColor = Color.Goldenrod
        Else
        End If
    End Sub

    Private Function arty_support(ByVal spt As ListView)
        arty_support = 0
        For Each l As ListViewItem In spt.Items
            If l.BackColor = Color.Goldenrod Then
                arty_support = arty_support + orbat(l.Text).strength
            End If
        Next
        Dim i As Integer = 0
        If Strings.Left(spt.Name, 1) = "a" Then i = 6 Else i = 4

        arty_support = Int(arty_support / i)
        If arty_support > 4 Then arty_support = 4
    End Function
End Class