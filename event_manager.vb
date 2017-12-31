Public Class event_manager
    Dim selected_row As Integer = 0, new_e As Boolean, nation As String
    Private Sub event_time_inc_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles event_time_inc.ValueChanged
        Dim hrs As Integer
        hrs = (1 * event_time_inc.Value)
        event_time.Text = Format(TimeSerial(hrs, 0, 0), "HH:mm")
    End Sub

    Private Sub dice_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dice_type.SelectedIndexChanged
        If dice_type.Text = "None" Then
            dice_score.Enabled = False
            dec_dice.Enabled = False
        Else
            dice_score.Enabled = True
            dec_dice.Enabled = True
        End If
    End Sub

    Private Sub dice_score_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dice_score.Leave, dice_type.Leave
        If Val(dice_score.Text) < 1 Then dice_score.Text = 1 : Exit Sub
        If Val(dice_score.Text) > 6 And dice_type.Text = "D6" Then dice_score.Text = 6 : Exit Sub
        If Val(dice_score.Text) > 10 And dice_type.Text = "D10" Then dice_score.Text = 10 : Exit Sub
    End Sub

    Private Sub me_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.Tag = "p1" Then
            nation = scenariodefaults.player1.Text
        ElseIf Me.Tag = "p2" Then
            nation = scenariodefaults.player2.Text
        Else
        End If
        side_options.Items.Clear()
        For Each u As cunit In orbat
            If u.nation = nation And u.comd > 0 Then
                Me.side_options.Items.Add(u.title)
            End If
        Next
        'With Me
        '    .side_options.Items.Clear()
        '    .side_options.Items.Add(scenariodefaults.player1.Text)
        '    .side_options.Items.Add(scenariodefaults.player2.Text)
        '    .side_options.Items.Add("Both")
        'End With
        reset_fields(False)
        populate_events()
        'If event_list Is Nothing Then
        '    Dim event_list As New Collection
        'End If
    End Sub

    Private Sub populate_events()
        event_table.Items.Clear()
        If event_list Is Nothing Then Exit Sub
        For Each v As cevents In event_list
            If v.side = nation Then
                Dim lv As ListViewItem
                lv = New ListViewItem
                With lv
                    .Text = v.unit
                    .SubItems.Add(v.text)
                    .SubItems.Add(v.die)
                    .SubItems.Add(v.score)
                    .SubItems.Add(IIf(v.dec, "Yes", "No"))
                    .SubItems.Add(v.time + ":00")
                    .SubItems.Add(IIf(v.tested, "Yes", "No"))
                End With
                event_table.Items.Add(lv)
            End If
        Next

    End Sub

    Private Sub reset_fields(ByVal setting As Boolean)
        With Me
            .side_options.Text = ""
            .event_time.Text = scenariodefaults.Current_time.Text
            .detail.Text = ""
            .dice_type.SelectedItem = "None"
            .dice_score.Text = "O"
            .dec_dice.SelectedItem = "No"
            .event_table.SelectedItems.Clear()
            .side_options.Enabled = setting
            .event_time_inc.Enabled = setting
            .detail.Enabled = setting
            .dice_type.Enabled = setting
            .dice_score.Enabled = setting
            .dec_dice.Enabled = setting
        End With
    End Sub

    Private Sub save_event_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save_event.Click
        If selected_row <> 0 Then
            With event_list(selected_row)
                .side = nation
                .unit = side_options.Text
                .time = IIf(LCase(detail.Text) = "off table", "25", Replace(event_time.Text, ":00", ""))
                .text = detail.Text
                .die = dice_type.Text
                ' .score = IIf(.die = "D6" And .score > 6, 6, Val(dice_score.Text))
                .score = Val(dice_score.Text)
                .dec = IIf(dec_dice.Text = "Yes", True, False)
            End With
            populate_events()
            link_event_to_unit(event_list(selected_row).time)
            selected_row = 0
        End If
        reset_fields(False)
        enable_edits(False)

    End Sub

    Private Sub discard_event_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles discard_event.Click
        If selected_row <> 0 Then
            If new_e Then
                event_list.Remove(selected_row)
                new_e = False
            End If
            selected_row = 0
        End If
        reset_fields(False)
        enable_edits(False)

    End Sub

    Private Sub edit_event_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit_event.Click
        If selected_row <> 0 And event_list.Count <> 0 Then
            Dim v As New cevents
            v = event_list(selected_row)
            reset_fields(True)
            With Me
                .side_options.Text = v.unit
                .event_time.Text = v.time + ":00"
                .detail.Text = v.text
                .dice_type.SelectedItem = v.die
                .dice_score.Enabled = IIf(v.die = "None", False, True)
                .dice_score.Text = IIf(v.die = "None", "0", v.score)
                .dec_dice.Enabled = IIf(v.die = "None", False, True)
                .dec_dice.SelectedItem = IIf(v.dec, "Yes", "No")
            End With
            enable_edits(True)
        End If


    End Sub

    Private Sub new_event_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles new_event.Click
        Dim v As cevents
        v = New cevents
        'v.reset()
        reset_fields(True)
        event_list.Add(v)
        selected_row = event_list.Count
        enable_edits(True)
        dec_dice.Enabled = False
        dice_score.Enabled = False
        new_e = True
    End Sub

    Private Sub enable_edits(ByVal setting As Boolean)
        event_table.Enabled = Not setting
        delete_event.Enabled = Not setting
        new_event.Enabled = Not setting
        save_event.Enabled = setting
        discard_event.Enabled = setting
    End Sub

    Private Sub delete_event_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delete_event.Click

        If selected_row <> 0 Then
            link_event_to_unit("")
            event_list.Remove(selected_row)
            event_table.Items(selected_row - 1).Remove()
            selected_row = 0
        End If
    End Sub


    Private Sub event_table_Selection(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles event_table.Click
        If event_list.Count = 0 Then selected_row = 0 : Exit Sub
        selected_row = event_table.FocusedItem.Index + 1
        Dim x As Integer = selected_row
        'reset_fields(False)
        'With Me
        '    .side_options.SelectedItem = event_list(x).side
        '    .event_time.Text = event_list(x).time
        '    .detail.Text = event_list(x).text
        '    .dice_type.SelectedItem = event_list(x).die
        '    .dice_score.Text = event_list(x).score
        '    .dec_dice.SelectedItem = event_list(x).dec
        'End With

    End Sub

    Private Sub link_event_to_unit(t As String)
        If t <> "" Then t = Replace(t, ":00", "")
        For Each u As cunit In orbat
            If u.nation = nation And ((u.parent = event_list(selected_row).unit And u.comd = 0) Or u.title = event_list(selected_row).unit) Then
                u.arrives = t
            End If
        Next
    End Sub
End Class