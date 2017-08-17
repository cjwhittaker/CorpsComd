Public Class resultform
    Private Sub ok_Click() Handles ok_button.Click

        If result.Text = "Target has been seen place on the table" Then Me.DialogResult = Windows.Forms.DialogResult.Retry Else Me.DialogResult = Windows.Forms.DialogResult.No
        log_entry(result.Text)
        Me.Hide()
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub



    Private Sub detect_key_press(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'act_on_key_press(Me, e.KeyChar)
    End Sub




End Class

