Public Class morale_test
    Public rally_ends As Boolean = False, rallied As Boolean = False, tester As cunit, immediate As Boolean, modifier As Integer = 0, rallying As Boolean
    Private Sub select_modifiers(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hq_in_sight.Click, nuclear.Click, friends_in_sight.Click, chemical.Click, en_visible.Click
        If sender.backcolor = golden Then sender.backcolor = defa Else sender.backcolor = golden
    End Sub

    Private Sub disrupted_friends_Click(sender As Object, e As EventArgs) Handles disrupted_friends.Click
        change_disrupted_friends(sender)
    End Sub

    Public Sub testing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles get_result.Click
        'If immediate Then rallying = False

        For Each ctrl In Me.Controls
            If ctrl.name = "disrupted_friends" Then
                modifier = modifier + Val(Strings.Left(ctrl.text, 1))
            ElseIf TypeOf ctrl Is Label And ctrl.backcolor = golden Then
                modifier = modifier + Val(ctrl.tag)
            Else
            End If
        Next
        test_result.Text = test_morale(tester, modifier, False)
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