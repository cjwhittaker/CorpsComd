Public Class morale_test
    Public rally_ends As Boolean = False, rallied As Boolean = False, tester As cunit, immediate As Boolean, modifier As Integer = 0, rallying As Boolean
    Private Sub select_modifiers(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hq_in_sight.Click, nuclear.Click, friends_in_sight.Click, chemical.Click
        If sender.backcolor = golden Then sender.backcolor = defa Else sender.backcolor = golden
    End Sub

    Public Sub testing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles get_result.Click
        'If immediate Then rallying = False
        Dim dice As Integer = d10(), r As String = ""
        For Each ctrl In Me.Controls
            If TypeOf ctrl Is Label And ctrl.backcolor = golden Then modifier = modifier + Val(ctrl.tag)
        Next
        If tester.disrupted Then modifier = modifier + 3
        If tester.strength / tester.initial < 0.5 Then modifier = modifier + 1
        r = " [" + Trim(Str(dice)) + IIf(modifier < 0, "-", "+") + Trim(Str(Math.Abs(modifier))) + "X" + Trim(Str(tester.quality)) + "] "
        If dice + modifier < tester.quality Then
            r = Replace(r, "X", "<")
            test_result.Text = tester.title + " has passed its Morale Test" + r
            If Not immediate And tester.disordered Or tester.disrupted Then
                test_result.Text = test_result.Text + " and has rallied from " + IIf(tester.disordered, "disorder", "") + IIf(tester.disordered And tester.disrupted, " and ", "") + IIf(tester.disrupted, "disrupted", "")
                With tester
                    .disrupted = False
                    .disordered = False
                End With
            End If
        ElseIf rallying Then
            r = Replace(r, "X", ">=")
            test_result.Text = tester.title + " has failed its Morale Test to rally " + r + " and remains " + IIf(tester.disordered, "disordered", "") + IIf(tester.disordered And tester.disrupted, " and ", "") + IIf(tester.disrupted, "disrupted", "")
        ElseIf dice + modifier = tester.quality Then
            r = Replace(r, "X", "=")
            test_result.Text = tester.title + " has failed its Morale Test" + r
            If Not tester.mode = disp Then test_result.Text = test_result.Text + " and is now dispersed. " : tester.mode = disp
            test_result.Text = test_result.Text + " If not in cover it must retreat one move"
            If tester.disrupted Then
                test_result.Text = test_result.Text + " At the end of the retreat the element is no longer disrupted"
                tester.disrupted = False
            End If
        ElseIf dice + modifier > tester.quality And tester.quality - (dice + modifier) <= 4 Then
            r = Replace(r, "X", "<")
            test_result.Text = tester.title + " has failed its Morale Test and is now dispersed and disrupted." + r
            tester.mode = disp
            tester.disrupted = True
        Else
            r = Replace(r, "X", "<")
            test_result.Text = tester.title + " has failed its Morale Test and surrenders." + r
            tester.strength = 0
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
        subject.Text = tester.title + " " + tester.equipment
        ok_button.Visible = False
        If Me.Tag = "Immediate" Then
            immediate = True
        Else
            immediate = False
        End If
    End Sub

End Class