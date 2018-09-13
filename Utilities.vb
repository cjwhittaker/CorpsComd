Module Utilities
    Function d6()
        d6 = Int(6 * Rnd + 1)
    End Function
    Function daverage()
        Dim Dice As Integer = Int(6 * Rnd() + 1)
        If Dice = 1 Then Dice = 3
        If Dice = 6 Then Dice = 4
        daverage = Dice
    End Function
    Function d4()
        d4 = Int(4 * Rnd + 1)
    End Function
    Function d10()
        d10 = Int(10 * Rnd + 1)
    End Function
    Function d100()
        d100 = Int(100 * Rnd + 1)
    End Function
    Function d20()
        d20 = Int(20 * Rnd + 1)
    End Function

    Public Sub populate_lists(ByVal l As ListView, ByVal c As Collection, ByVal purpose As String, ByVal hq As String)
        Dim listitem As ListViewItem, j As Integer = 0, info As String = ""
        'For Each i As ListViewItem In l.Items
        '    i.Remove()
        'Next
        l.Items.Clear()
        l.BackColor = nostatus
        If purpose = "Opportunity Fire" Then
            listitem = New ListViewItem
            listitem.Text = "Minefield"
            l.Items.Add(listitem)
        End If
        If c Is Nothing Then Exit Sub
        For Each u As cunit In c
            u.arty_spt = 0
            If u.validunit(purpose, hq) Then
                listitem = New ListViewItem
                listitem.Text = u.title
                If hq = "commanders" And InStr("ObserveeCommandMorale RecoveryMovementAir TaskingArty TaskingArea FireCB Fire", purpose) > 0 Then
                    'listitem.SubItems.Add(u.comdpts)
                ElseIf l.Name = "undercommand" Then
                    If InStr("Arty Tasking", purpose) > 0 Then
                        info = u.task
                    ElseIf purpose = "Movement" Or purpose = "Command" Then
                        info = UCase(Strings.Left(u.mode, 1))
                    Else
                    End If
                    listitem.SubItems.Add(u.strength)
                    listitem.SubItems.Add(info)
                    listitem.SubItems.Add(IIf(u.Cover > 0, "+" + Trim(Str(u.Cover)), ""))
                    listitem.SubItems.Add(u.equipment + IIf(u.embussed, "*", ""))
                    If purpose = "Command" Then listitem.BackColor = u.status(purpose)
                ElseIf InStr("Artillery SupportSmoke BarrageCA DefendersCA SupportsGround TargetsCB TargetsAir DefenceCAP MissionsIndirect FireDirect FireMovementArea FireCB FireOpportunity FireRadar OnSEAD TargetsInterceptAir to AirCAP AD Targets", purpose) > 0 Then
                    listitem.SubItems.Add(IIf(u.aircraft, u.strength - u.aborts, u.strength))
                    listitem.SubItems.Add(u.equipment)
                ElseIf InStr("Deploy AircraftAbort AircraftAir Ground", purpose) > 0 Then
                    listitem.SubItems.Add(u.task)
                    listitem.SubItems.Add(u.equipment)
                ElseIf InStr("DemoralisationMorale Recovery", purpose) > 0 Then
                    listitem.SubItems.Add(u.comdpts)
                ElseIf InStr("TransportCAP TargetsAir TargetsSEAD TargetsSEAD Defence TargetsObserver", purpose) > 0 Then
                    listitem.SubItems.Add(u.equipment)
                Else
                End If
                l.Items.Add(listitem)
                j = j + 1
            End If
        Next
        'For Each li As ListViewItem In l.Items
        '    If orbat.Contains(li.Text) Then
        '        If purpose = "Observer" Or purpose = "Artillery Support" Then
        '            'If orbat(li.Text).arty_spt = 0 Then
        '            '    li.BackColor = in_ds
        '            'ElseIf orbat(li.Text).arty_spt = 1 Then
        '            '    li.BackColor = can_observe
        '            'Else
        '            '    li.BackColor = not_on_net
        '            'End If
        '        ElseIf InStr("DemoralisationMorale RecoveryMovementArty Tasking", purpose) > 0 Then
        '            li.BackColor = orbat(li.Text).status("")
        '        Else
        '        End If
        '    End If
        'Next
    End Sub

    Public Function divisional_comd(ByVal p As cunit)
        If p.comd >= 4 Then
            divisional_comd = p.title : Exit Function
        Else
            divisional_comd = divisional_comd(orbat(p.parent))
        End If
    End Function
    Public Function brigade_comd(ByVal p As cunit)
        If p.comd >= 2 Then
            brigade_comd = p.title : Exit Function
        Else
            brigade_comd = brigade_comd(orbat(p.parent))
        End If
    End Function
    Public Sub hq_functions(ByVal p As cunit, func As String)
        If p.parent <> "root" Then hq_functions(orbat(p.parent), func)
        If func = "Air units" And p.primary <> func Then p.primary = func
        If func = "Arty units" And p.carrying <> func Then p.carrying = func
    End Sub

    Public Sub ewsupport(ByVal candidates As Collection, ByVal phase As String)
        Dim ewac As Boolean = False
        For Each subject As cunit In candidates
            If phase = "CAP" And subject.task = "EW Support" And subject.airborne Then
                ewac = True : Exit For
            ElseIf phase = "Air-Ground Attack" And subject.task = "SEAD" And subject.airborne Then
                ewac = True : Exit For
            Else

            End If
        Next
        For Each subject As cunit In candidates
            If (subject.aircraft And Not subject.heli) And subject.airborne Then subject.ewsupported = ewac Else subject.ewsupported = ewac
        Next
    End Sub

    Public Sub check_demoralisation(ByVal candidates As Collection, ByVal x As String, ByVal y As String)
        Randomize()
        Dim disrupted As Integer = 0, destroyed As Integer = 0, totalunits As Integer = 0
        For Each temp As cunit In candidates
            If temp.parent = x And temp.comd = 0 Then
                totalunits = totalunits + temp.initial
                destroyed = destroyed + (temp.initial - temp.strength)
                If temp.disrupted Then
                    disrupted = disrupted + temp.strength
                End If
            End If
        Next
        Dim percentdisrupted As Single = (disrupted + destroyed) / totalunits
        Dim d As Integer = d10()
        If d > y And percentdisrupted >= 0.333 Then
            With resultform_2
                .result.Text = parent(candidates, x)
                .ShowDialog()
            End With
        End If
    End Sub
    Public Function parent(ByVal candidates As Collection, ByVal x As String)
        parent = ""
        Dim fail_text As String = ""
        With orbat(x)
            .demoralised = True
            .moved = gt
        End With
        For Each temp As cunit In candidates
            If temp.parent = x Then
                temp.demoralised = True
                temp.moved = gt
                parent = parent + temp.title + ", "
            End If
        Next
        fail_text = " are now demoralised and on table units must move a minimum of half a tactical"
        fail_text = fail_text + vbNewLine + "move per turn toward their own sides baseline. The units of this BG"
        fail_text = fail_text + vbNewLine + "may not initiate fire"
        parent = parent + vbNewLine + fail_text
    End Function
    Public Sub log_entry(ByVal result As String)
        'logtime = to_hr(x)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Strings.Left(scenario, (Len(scenario) - 4)) + ".his", True)
        file.WriteLine(result)
        file.Close()
    End Sub

    Public Function coc(ByVal title As String, ByVal hq As cunit, ByVal comd As Integer)
        If title = hq.title And comd = 0 Then
            coc = True
            Exit Function
        End If
        If hq.parent = "root" Then
            coc = False
            Exit Function
        End If


        coc = coc(title, orbat(hq.parent), comd)
    End Function


    Public Sub swap_phasing_player(exec As Boolean)
        Dim tmp As String
        If exec Then
            tmp = ph
            ph = nph
            nph = tmp
        End If
        If ph = scenariodefaults.player1.Text Then
            ph_hqs = New Collection
            ph_hqs = p1_hqs
            ph_units = New Collection
            ph_units = p1_units
            enemy = New Collection
            enemy = p2_Units
        Else
            ph_hqs = New Collection
            ph_hqs = p2_HQs
            ph_units = New Collection
            ph_units = p2_Units
            enemy = New Collection
            enemy = p1_units
        End If
    End Sub

    Public Sub check_observer(firer As cunit)
        populate_lists(unit_selection.units, ph_units, "Observer", IIf(firer.primary <> "", firer.primary, firer.parent))
        With unit_selection
            .Tag = "Observer"
            .ShowDialog()
        End With
    End Sub

    Public Sub populate_command_structure(tree As TreeView, ByVal side As String, purpose As String)
        Dim TopNode As TreeNode, u As New cunit, x As Integer = 0
        For Each u In orbat
            If u.root And u.nation = side Then Exit For
        Next
        tree.Nodes.Clear()
        TopNode = tree.Nodes.Add(u.title, u.title)
        CreateNodes(side, TopNode, u.title, purpose)
        tree.ExpandAll()
        tree.SelectedNode = TopNode

        'selectunit(orbat(tree.SelectedNode.Text))
    End Sub
    Public Sub CreateNodes(ByRef side As String, ByRef ParentNode As TreeNode, ByRef currentcomd As String, ByRef purpose As String)
        Dim subNode As New TreeNode
        For x As Integer = 1 To orbat.Count
            If orbat(x).nation = side Then

                If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                    If (orbat(x).comd = 0 And purpose = "Orbat") Or orbat(x).comd > 0 Then
                        subNode = ParentNode.Nodes.Add(orbat(x).Title, orbat(x).Title)
                        subNode.BackColor = orbat(x).status(purpose)
                        If orbat(x).comd = 0 Then
                            If purpose = "Orbat" And orbat(x).inf Then
                                If orbat(x).debussed And orbat(x).carrying = "" Then
                                    subNode.ToolTipText = "Dismounted"
                                ElseIf orbat(x).debussed And orbat(x).carrying <> "" Then
                                    subNode.ToolTipText = "Debussed"
                                ElseIf Not orbat(x).debussed Then
                                    subNode.ToolTipText = "Embused"
                                Else
                                End If
                            End If
                        End If
                    End If
                    If (purpose = "Orbat") Or (purpose = "Command" And orbat(x).comd > 1) Then CreateNodes(side, subNode, orbat(x).title, purpose)
                End If
            End If
        Next
    End Sub

    Public Sub test_for_events(ByVal s As String, ByVal t As Date)
        For Each e As cevents In event_list
            If Not e.tested Then
                If Format(t, "HH:mm") >= e.time And s = e.side Then
                    If e.die = "None" Then
                        e.tested = True
                    Else
                        Dim dice6 As Integer = d6(), dice10 As Integer = d10()
                        If (e.die = "D6" And dice6 >= e.score) Or (e.die = "D10" And dice10 >= e.score) Then
                            e.tested = True
                        Else
                            If e.dec Then e.score = e.score - 1
                        End If
                    End If
                    If e.tested Then
                        With resultform_2
                            .Text = "Game Events - GT" + Trim(Str(gt)) + " at " + Format(t, "HH:mm") + "hrs"
                            .result.Text = e.unit + " " + e.text
                            .yb.Visible = False
                            .nb.Visible = False
                            .ok_button.Visible = True
                            .ShowDialog()
                            .nb.Visible = False
                        End With
                        For Each u As cunit In orbat
                            If u.nation = e.side And (u.title = e.unit Or u.parent = e.unit) Then
                                u.arrives = 0
                                If u.comd = 0 Then
                                    If Not u.conc Then u.mode = travel
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        Next
    End Sub

End Module
