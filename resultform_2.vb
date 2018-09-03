Public Class resultform_2
    Dim button_press As String = ""
    Private Sub ok_Click() Handles ok_button.Click
        Me.Close()
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub detect_key_press(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'act_on_key_press(Me, e.KeyChar)
    End Sub

    Private Sub yb_Click(sender As Object, e As EventArgs) Handles yb.Click, nb.Click, hvy1.Click, hvy2.Click
        button_press = ""
        If InStr(Me.result.Text, "Initiative Phase") > 0 Then
            If sender.name = "nb" Then swap_phasing_player(True)
            button_press = sender.text
            Me.Close()
        ElseIf Me.Tag = "firing" Then
            If InStr(result_option, sender.text) = 0 Then
                sender.backcolor = golden
                result_option = result_option + sender.text
            ElseIf InStr(result_option, sender.text) > 0 And sender.backcolor = golden Then
                sender.backcolor = defa
                result_option = Replace(result_option, sender.text, "")
            Else
            End If
            button_press = sender.text
        Else
            If sender.name = "yb" And InStr(Me.Tag, "eliminated") = 0 Then
                sender.backcolor = golden
                Me.Tag = Me.Tag + "eliminated"
            ElseIf sender.name = "yb" And InStr(Me.result.Text, "eliminated") > 0 And sender.backcolor = golden Then
                sender.backcolor = defa
                Me.Tag = Replace(Me.Tag, "eliminated", "")
            Else
            End If
            button_press = sender.text
        End If
        result_option = Me.Tag
    End Sub

    Private Sub resultform_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        log_entry("Game Turn" + Str(gt) + " " + scenariodefaults.Current_time.Text + " " + Replace(result.Text, vbNewLine, " ",) + " " + button_press)
        button_press = ""
        yb.BackColor = defa
        nb.BackColor = defa
        hvy1.BackColor = defa
        hvy2.BackColor = defa
        hvy1.Visible = False
        hvy2.Visible = False
    End Sub

End Class

