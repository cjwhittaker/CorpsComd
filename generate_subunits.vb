Public Class generate_subunits

 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n As New cunit, i As Integer = 0, l As String = "", passengers As Boolean = False, t As String = ""
        Dim same_desig As Boolean = False, ch As Integer = 65, pas As String = "*", subunits As Integer = 0, desig As String = ""
        If Not sub_1.BackColor = golden And Not sub_a.BackColor = golden Then Exit Sub
        For Each s As csubunit In TOE
            If s.title = unittype.SelectedItem And s.unit_comd <> 1 Then
                If s.desig = "" And Not passengers And Not s.equipment = "ACV" Then subunits = subunits + s.quantity
                passengers = False
                Try
                    If eq_list(s.equipment).troopcarrier Then passengers = True
                Catch ex As Exception
                End Try
            End If
        Next
        For Each s As csubunit In TOE
            If s.title = unittype.SelectedItem Then
                If subunits > 9 Or sub_a.BackColor = golden Then
                    ch = 65
                Else
                    ch = 49
                End If
                If s.desig <> desig Then
                    desig = s.desig
                    same_desig = False
                Else
                    same_desig = True
                End If
                If passengers Then
                    i = i - s.quantity
                ElseIf same_desig Then
                    i = i
                Else
                    i = 0
                End If
                For x As Integer = 0 To s.quantity - 1
                    If s.desig = "" Then
                        t = Chr(ch + i)
                    Else
                        t = Chr(ch + IIf(same_desig, i, x))
                    End If
                    If s.unit_comd > 0 Then
                        l = IIf(s.desig = "", Chr(49 + x), s.desig) + "-"
                    ElseIf s.equipment = "ACV" And s.desig = "" Then
                        l = "HQ/"
                    ElseIf s.desig <> "" Then
                        If passengers Then
                            If s.sub_comd Then
                                l = Replace(s.desig, "/", pas + "/") + t + "-"
                            Else
                                l = IIf(s.quantity > 1 Or same_desig, t + pas + "/", "1/") + s.desig
                            End If
                        Else
                            If s.sub_comd Then
                                l = s.desig + t + "-"
                            Else
                                l = IIf(s.quantity > 1 Or same_desig, t + "/", "") + s.desig
                            End If
                        End If
                    ElseIf s.desig = "" Then
                        If passengers Then
                            l = t + pas + "/"
                        Else
                            l = t + "/"
                        End If
                    Else
                    End If
                    'If l = "HQ" And x = 1 Then
                    '    l = l
                    'ElseIf l = "HQ" And x > 1 And Not s.sub_comd Then
                    '    l = l + Trim(Str(x - 1))
                    'Else
                    If s.quantity > 1 Or (same_desig And s.unit_comd = 0 And s.equipment <> "ACV") Or (s.desig = "" And s.unit_comd = 0 And s.equipment <> "ACV") Then
                        i = i + 1
                    End If
                    n = New cunit
                    If InStr(l, pas) > 0 Then
                        orbat(Replace(Trim(l) + Trim(orbattitle.Text), pas, "")).carrying = Replace(Trim(l) + Trim(orbattitle.Text), pas, "#")
                        n.carrying = Replace(Trim(l) + Trim(orbattitle.Text), pas, "")
                        l = Replace(l, pas, "#")
                    End If
                    With n
                        .title = Trim(l) + Trim(orbattitle.Text)
                        .comd = s.unit_comd
                        .nation = s.nation
                        .initial = IIf(s.unit_comd = 0, s.strength, 0)
                        .strength = IIf(s.unit_comd = 0, s.strength, 0)
                        .equipment = IIf(s.unit_comd = 0, s.equipment, "")
                        .quality = Val(quality.SelectedItem)
                        .parent = Trim(orbattitle.Text)
                    End With

                    Dim j As Integer = 0
                    Do While orbat.Contains(n.title)
                        n.title = Trim(Chr(49 + j)) + "/" + Mid(n.title, InStr(n.title, "/"))
                        j = j + 1
                    Loop
                    orbat.Add(n, n.title)
                Next
                'i = i + 1
                If n.troopcarrier Then passengers = True Else passengers = False
            End If
        Next
        Me.Hide()
    End Sub

    Private Sub generate_subunits_Load(sender As Object, e As EventArgs) Handles Me.Load
        If unittype.Items.Count > 0 Then
            unittype.SelectedIndex = 0
            quality.SelectedItem = Trim(Str(orbat(Trim(orbattitle.Text)).quality))
            sub_1.BackColor = defa
            sub_a.BackColor = defa
        Else
            Me.Close()
        End If
    End Sub

    Private Sub sub_identifers(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sub_1.Click, sub_a.Click
        If (sender.name = "sub_a" And sender.backcolor = defa) Or (sender.name = "sub_1" And sender.backcolor = golden) Then
            sub_1.BackColor = defa
            sub_a.BackColor = golden
        ElseIf (sender.name = "sub_1" And sender.backcolor = defa) Or (sender.name = "sub_a" And sender.backcolor = golden) Then
            sub_a.BackColor = defa
            sub_1.BackColor = golden
        Else

        End If
    End Sub

    Private Sub quality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles quality.SelectedIndexChanged
        If Val(quality.SelectedItem) > orbat(Trim(orbattitle.Text)).quality Then quality.SelectedItem = Trim(Str(orbat(Trim(orbattitle.Text)).quality))
    End Sub
End Class