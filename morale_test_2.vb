Public Class morale_test
    Public rally_ends As Boolean = False, rallied As Boolean = False, tester As cunit, immediate As Boolean, modifier As Integer = 0, rallying As Boolean
    Private Sub select_modifiers(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hq_in_sight.Click, nuclear.Click, friends_in_sight.Click, chemical.Click, en_visible.Click
        If sender.backcolor = golden Then sender.backcolor = defa Else sender.backcolor = golden
    End Sub

    Private Sub disrupted_friends_Click(sender As Object, e As EventArgs) Handles disrupted_friends.Click
        If Strings.Left(sender.text, 1) = "0" Then
            sender.text = "1 disrupted friends within 1000m"
            sender.backcolor = golden
        ElseIf Strings.Left(sender.text, 1) = "1" Then
            sender.text = "2 disrupted friends within 1000m"
        ElseIf Strings.Left(sender.text, 1) = "2" Then
            sender.text = "3 disrupted friends within 1000m"
        ElseIf Strings.Left(sender.text, 1) = "3" Then
            sender.text = "0 disrupted friends within 1000m"
            sender.backcolor = defa
        Else
        End If
    End Sub

    Public Sub testing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles get_result.Click
        'If immediate Then rallying = False
        Dim dice As Integer = d10(), r As String = "", result As Integer
        For Each ctrl In Me.Controls
            If ctrl.name = "disrupted_friends" Then
                modifier = modifier + Val(Strings.Left(ctrl.text, 1))
            ElseIf TypeOf ctrl Is Label And ctrl.backcolor = golden Then
                modifier = modifier + Val(ctrl.tag)
            Else
            End If
        Next
        If tester.disrupted Then modifier = modifier + 2
        If tester.disrupted_gt Then modifier = modifier + 2
        If tester.halfstrength Then modifier = modifier + 1
        If rallying And tester.halfstrength And rallying Then modifier = modifier + 2
        If tester.casualties > 3 Then modifier = modifier + 2
        r = vbNewLine + " [" + Trim(Str(dice)) + IIf(modifier < 0, "-", "+") + Trim(Str(Math.Abs(modifier))) + "X" + Trim(Str(tester.quality)) + "] "
        result = dice + modifier - tester.quality
        If result < 0 Then
            r = Replace(r, "X", "<")
            test_result.Text = tester.title + " has passed its Morale Test" + r
            If rallying And tester.disrupted Then
                test_result.Text = test_result.Text + " and has rallied from being disrupted"
                tester.disrupted = False
                tester.mode = disp
            End If
        ElseIf result < 4 And tester.disrupted Then
            r = Replace(r, "X", ">=")
            test_result.Text = tester.title + IIf(rallying, " has failed its Morale Test to rally and ", "") + " remains disrupted" + r
        ElseIf result >= 5 Then
            r = Replace(r, "X", "<")
            test_result.Text = tester.title + " has failed its Morale Test and surrenders. Remove the unit from the table. " + r
            tester.strength = 0
        ElseIf result = 0 Then
            r = Replace(r, "X", "=")
            test_result.Text = tester.title + " has failed its Morale Test" + r + " and is now dispersed. If not in cover it must retreat one move"
            tester.mode = disp
        ElseIf result <= 4 Then
            r = Replace(r, "X", "<")
            test_result.Text = tester.title + " has failed its Morale Test and is now disrupted. " + r
            tester.disrupted = True
            tester.disrupted_gt = True
        Else
        End If
        test_result.Visible = True
        get_result.Enabled = False
        ok_button.Visible = True
    End Sub

    Private Sub ok_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok_button.Click
        Me.Close()
    End Sub

    Private Sub reset_form()
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Label And ctrl.backcolor = golden Then ctrl.backcolor = defa
            ctrl.enabled = True
            ctrl.visible = True
        Next
        test_result.Visible = False
        test_result.Text = ""
        subject.Text = ""
    End Sub

    Private Sub rally_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        reset_form()
    End Sub

    Private Sub rally_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        reset_form()
        subject.Text = tester.title
        en_visible.Enabled = True
        If tester.Inf Then
            en_visible.Text = "Enemy AFVs visible within 1000m"
        ElseIf tester.armour Then
            en_visible.Text = "Deployed Atk visible within 1000m"
        Else
            en_visible.Text = ""
            en_visible.Enabled = False
        End If
        ok_button.Visible = False
    End Sub

End Class