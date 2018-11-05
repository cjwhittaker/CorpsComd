Public Class mine_attack
    Public rally_ends As Boolean = False, rallied As Boolean = False, tester As cunit, immediate As Boolean, modifier As Integer = 0, attempts As Integer = -1, permitted As Integer = 0
    Private Sub select_mine_type(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mine_type.Click
        If sender.Text = "Barrier" Then
            sender.Text = "Auto-laid"
            sender.BackColor = golden
            modifier = modifier - 8 + 6
        ElseIf sender.Text = "Auto-laid" Then
            sender.Text = "Artillery/Air Delivered"
            modifier = modifier - 6 + 5
        ElseIf sender.Text = "Artillery/Air Delivered" Then
            sender.Text = "Barrier"
            sender.backcolor = defa
            modifier = modifier - 5 + 8
        Else
        End If
    End Sub

    Private Sub subject_Click(sender As Object, e As EventArgs) Handles subject.Click
        reset_form()
    End Sub

    Private Sub select_support(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles engineers.Click
        If sender.Text = "No Support" Then
            sender.Text = "Dismounted Engineers Support"
            sender.BackColor = golden
            modifier = modifier - 2
        ElseIf sender.Text = "Dismounted Engineers Support" Then
            sender.Text = "No Support"
            sender.backcolor = defa
            modifier = modifier + 2
        Else
        End If
    End Sub
    Private Sub select_attempts(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles attempt.Click
        Dim prompt As String = "Crossing Attempts"
        attempts = Val(Replace(sender.text, prompt, "")) + 1
        modifier = modifier - Val(Replace(sender.text, prompt, "")) - 1
        sender.Text = "Crossing Attempt" + Str(attempts)
        sender.BackColor = golden
    End Sub

    Private Sub testing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles get_result.Click
        Dim fire_effect As Integer, fv As Integer, cas As Integer = 0
        modifier = modifier + 1
        'test for engineer equipment
        'test for soft vehicle
        If tester.soft_tpt Then modifier = modifier + 2
        'test for specialist engineer
        Do
            dice = d10() - 1
            fire_effect = IIf(modifier > 10, 10, modifier)
            dice = dice + IIf(fire_effect > 11, fire_effect - 11, 0)
            dice = IIf(dice < 0, 0, dice)
            dice = IIf(dice > 9, 9, dice)
            fv = indirect_fire_strength(tester.strength, modifier) - 1
            cas = cas + fire_loss_table(dice, IIf(fv > 19, 19, fv))
            modifier = modifier - 10
        Loop Until modifier <= 0
        tester.msg = "100m of the minefield crossed " + generateresult(tester, cas, True, False, False)
        Dim max_cas As Boolean = IIf(tester.strength - tester.casualties + 1 = 0, True, False)
        With resultform_2
            .result.Text = "Results" + vbNewLine + tester.msg
            .Tag = "firing"
            .ok_button.Visible = True
            .yb.Visible = False
            .nb.Visible = IIf(InStr(tester.msg, "disperse") > 0 And Not max_cas, True, False)
            .nb.Text = "Disperse " + tester.title
            .ShowDialog()
            .yb.Text = "Yes"
            .nb.Text = "No"
            .yb.Visible = False
            .nb.Visible = False
        End With
        If InStr(result_option, "Disperse") > 0 Or max_cas Then
            With tester
                .casualties = .casualties + cas - 1
                .mode = disp
                .moved = gt
            End With
            movement.undercommand.FindItemWithText(tester.title).Remove()
        Else
            With tester
                .strength = .strength - .casualties
            End With
        End If
        permitted = permitted + 1
        If InStr(result_option, "Disperse") > 0 Or permitted > 4 Then
            reset_form()
            result_option = ""
            Me.Close()
        End If
        'select_attempts(attempt, Nothing)
    End Sub

    Private Sub reset_form()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Label And ctrl.BackColor = golden Then ctrl.BackColor = defa
            ctrl.Enabled = True
            ctrl.Visible = True
        Next
        mine_type.Text = "Barrier"
        engineers.Text = "No Support"
        attempt.Text = "Crossing attempts 0"
        subject.Text = ""
        permitted = 0
    End Sub

    Private Sub mine_attack_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        reset_form()
    End Sub

    Private Sub mine_attack_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        reset_form()
        modifier = 8
        subject.Text = tester.title + " " + tester.equipment
    End Sub

End Class