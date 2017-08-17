Public Class generate_subunits

 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n As New cunit, i As Integer = 0, l As String = "", passengers As Boolean = False, ch As Integer = 65, pas As String = "1"
        If Not sub_1.Checked And Not sub_a.Checked Then Exit Sub
        For Each s As csubunit In TOE
            If s.title = unittype.SelectedItem Then
                If s.quantity > 9 Or sub_a.Checked Then
                    ch = 65
                Else
                    ch = 49
                End If
                If passengers Then i = i - s.quantity
                For x As Integer = 1 To s.quantity
                    If s.equipment = "ACV" Then
                        l = "HQ"
                    ElseIf passengers Then
                        l = Chr(ch + i) + pas
                    Else
                        l = Chr(ch + i)
                    End If
                    If l = "HQ" And x = 1 Then
                        l = l
                    ElseIf l = "HQ" And x > 1 Then
                        l = l + Trim(Str(x - 1))
                    Else
                        i = i + 1
                    End If
                    n = New cunit
                    With n
                        .title = Trim(l) + "/" + Trim(orbattitle.Text)
                        .comd = 0
                        .nation = s.nation
                        .initial = s.strength
                        .strength = s.strength
                        .equipment = s.equipment
                        .quality = quality.SelectedItem
                        .parent = Trim(orbattitle.Text)
                    End With
                    Dim j As Integer = 0
                    Do While orbat.Contains(n.title)
                        n.title = Trim(l + Chr(49 + j)) + "/" + Trim(orbattitle.Text)
                        j = j + 1
                    Loop
                    orbat.Add(n, n.title)
                Next
                If n.troopcarrier Then passengers = True Else passengers = False
            End If
        Next
        Me.Hide()
    End Sub

    Private Sub sub_identifers(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sub_a.CheckedChanged, sub_1.CheckedChanged
        If sender.name = "sub_a" And sender.checked Then
            sub_1.Checked = False
            sub_1.BackColor = Color.FromName("Control")
            sub_a.BackColor = Color.Goldenrod
        ElseIf sender.name = "sub_1" And sender.checked Then
            sub_a.Checked = False
            sub_a.BackColor = Color.FromName("Control")
            sub_1.BackColor = Color.Goldenrod
        Else

        End If
    End Sub
End Class