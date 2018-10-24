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
    Public Sub change_disrupted_friends(sender As Object)
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
    Public Sub test_morale(subject As cunit, modifier As Integer, rallying As Boolean)
        Dim dice As Integer = d10(), r As String = "", result As Integer, result_string As String = IIf(morale_test.Visible, "Immediate Morale Test", "Morale Test") + vbNewLine
        If modifier <> -100 Then
            If subject.disrupted Then modifier = modifier + 2
            If subject.disrupted_gt Then modifier = modifier + 2
            If subject.halfstrength Then modifier = modifier + 1
            If rallying And subject.halfstrength And rallying Then modifier = modifier + 2
            If subject.cas_gt > 3 Then modifier = modifier + 2
            result = dice + modifier - subject.quality
            r = vbNewLine + " [" + Trim(Str(dice)) + IIf(modifier < 0, "-", "+") + Trim(Str(Math.Abs(modifier))) + "=" + Trim(Str(dice + modifier)) + " X " + Trim(Str(subject.quality)) + "] "
            If result < 0 And ((Not rallying And Not subject.disrupted) Or (rallying And subject.disrupted)) Then
                r = Replace(r, "X", "<")
                result_string = subject.title + " has passed its Morale Test" + r
                If rallying And subject.disrupted Then
                    result_string = result_string + " and has rallied from being disrupted"
                    subject.disrupted = False
                    subject.mode = disp
                End If
            ElseIf result <= 4 And subject.disrupted Then
                r = Replace(r, "X", ">=")
                result_string = subject.title + IIf(rallying, " has failed its Morale Test to rally and ", "") + " remains disrupted" + r
            ElseIf result >= 5 Then
                r = Replace(r, "X", ">=")
                result_string = subject.title + " has failed its Morale Test." + vbNewLine + "If it is contact or has enemy advancing within 600m it surrenders and is removed from the table." + vbNewLine + "If not it must retire 2000m away from all enemy" + vbNewLine + r
                subject.strength = 0
            ElseIf result = 0 Then
                r = Replace(r, "X", "=")
                result_string = subject.title + " has failed its Morale Test" + r + " and is now dispersed. If not in cover it must retreat one move"
                subject.mode = disp
            ElseIf result <= 4 And Not subject.disrupted Then
                r = Replace(r, "X", ">=")
                result_string = subject.title + " has failed its Morale Test and is now disrupted" + r
                subject.disrupted = True
                subject.disrupted_gt = True
            Else
            End If
        Else
            result_string = result_string + "No Morale Test Required"
        End If
        result_option = ""
        With resultform_2
            .result.Text = result_string
            .Tag = "Morale Test"
            .ok_button.Visible = True
            .yb.Visible = False
            .hvy1.Visible = False
            .nb.Text = IIf(result >= 5, "Surrender", "")
            .nb.Visible = IIf(result > 5, True, False)
            .nb.Enabled = .nb.Visible
            .hvy2.Visible = False
            .ShowDialog()
            .Tag = ""
            .yb.Text = "Yes"
            .nb.Text = "No"
            .yb.Visible = False
            .nb.Visible = False
        End With
        If result_option = "surrender" Then subject.strength = 0
        If morale_test.Visible Then
            With morale_test
                .get_result.Enabled = False
                .ok_button.Visible = True
                .Close()
            End With

        End If
    End Sub

    Public Sub populate_lists(ByVal l As ListView, ByVal c As Collection, ByVal purpose As String, ByVal hq As String)
        Dim listitem As ListViewItem, j As Integer = 0, info As String = ""
        l.BackColor = nostatus

        If purpose = "Opportunity Fire" And Not hq = "Air" Then
            listitem = New ListViewItem
            listitem.Text = "Minefield"
            l.Items.Add(listitem)
        End If
        For Each u As cunit In orbat
            If u.comd = 0 Then If u.airdefence And Not u.emplaced Then u.emplace()

        Next
        If c Is Nothing Then Exit Sub
        For Each u As cunit In c
            If u.validunit(purpose, hq) Then
                listitem = New ListViewItem
                listitem.Text = u.title
                If hq = "commanders" And InStr("ObserveeCommandMorale RecoveryMovementAir TaskingArty TaskingArea FireCB Fire", purpose) > 0 Then

                ElseIf l.Name = "undercommand" Then
                    If purpose = "Movement" Or InStr(purpose, "Command") > 0 Or purpose = "Morale Recovery" Then
                        info = UCase(Strings.Left(u.mode, 1))
                        listitem.BackColor = u.status(purpose)
                        If purpose = "Morale Recovery" Then
                            If listitem.BackColor = may_test Then
                                listitem.Tag = "may test"
                            ElseIf listitem.BackColor = must_test Then
                                listitem.Tag = "must test"
                            Else
                                listitem.Tag = ""
                            End If
                        Else
                            listitem.Tag = ""
                        End If
                    End If
                    listitem.SubItems.Add(u.strength)
                    listitem.SubItems.Add(info)
                    listitem.SubItems.Add(IIf(u.aircraft, u.abbrev_air_mission, IIf(u.Cover > 0, "+" + Trim(Str(u.Cover)), "")))
                    listitem.SubItems.Add(u.equipment + IIf(u.embussed, "*", ""))
                ElseIf InStr("Air to AirGround to AirAir to GroundAir Defence TargetsOpportunity AA FireADSAM FireArtillery SupportOff Table TargetsSmoke BarrageCA DefendersCA SupportsGround TargetsIndirect FireDirect FireMovementArea FireCB FireOpportunity FireRadar OnSEAD TargetsIntercept TargetsCAP Combat", purpose) > 0 Then
                    listitem.SubItems.Add(u.strength)
                    listitem.SubItems.Add(u.equipment)
                    If (purpose = "Ground Targets" Or purpose = "Off Table Targets") And u.indirect And u.eligibleCB Then
                        listitem.BackColor = can_observe
                    Else
                        listitem.BackColor = orbat(listitem.Text).status("")
                    End If
                    If purpose = "CAP Combat" Then
                        If Not l.Columns.ContainsKey("RD") Then l.Columns.Add("RD", "RD")
                        listitem.SubItems.Add(4 - u.tacticalpts)
                    Else
                        If l.Columns.ContainsKey("RD") Then l.Columns.RemoveByKey("RD")
                    End If
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
    Public Sub initialise_collections()
        p1_hqs = New Collection
        p2_HQs = New Collection
        p1_orbat = New Collection
        p2_orbat = New Collection
        p1_units = New Collection
        p2_Units = New Collection
        p1_air = New Collection
        p2_air = New Collection
        p1 = scenariodefaults.player1.Text
        p2 = scenariodefaults.player2.Text
        For Each u As cunit In orbat
            If UCase(u.nation) = UCase(p1) Then
                p1_orbat.Add(u, u.title)
                If u.comd > 0 Then
                    p1_hqs.Add(u, u.title)
                ElseIf u.comd = 0 And u.aircraft Then
                    p1_air.Add(u, u.title)
                Else
                    p1_units.Add(u, u.title)
                End If
            Else
                p2_orbat.Add(u, u.title)
                If u.comd > 0 Then
                    p2_HQs.Add(u, u.title)
                ElseIf u.comd = 0 And u.aircraft Then
                    p2_air.Add(u, u.title)
                Else
                    p2_Units.Add(u, u.title)
                End If
            End If
        Next

    End Sub

    Public Sub swap_phasing_player(exec As Boolean)
        Dim tmp As String
        If exec Then
            tmp = ph
            ph = nph
            nph = tmp
        End If
        If UCase(ph) = UCase(p1) Then
            ph_hqs = New Collection
            ph_hqs = p1_hqs
            ph_units = New Collection
            ph_units = p1_units
            friend_air = New Collection
            friend_air = p1_air
            enemy = New Collection
            enemy = p2_Units
            enemy_air = New Collection
            enemy_air = p2_air
        Else
            ph_hqs = New Collection
            ph_hqs = p2_HQs
            ph_units = New Collection
            ph_units = p2_Units
            friend_air = New Collection
            friend_air = p2_air
            enemy = New Collection
            enemy = p1_units
            enemy_air = New Collection
            enemy_air = p1_air
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
            If u.root And UCase(u.nation) = UCase(side) Then Exit For
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
        'If currentcomd = "ASOC" Then Stop
        For x As Integer = 1 To orbat.Count
            If UCase(orbat(x).nation) = UCase(side) Then
                If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                    If (orbat(x).comd = 0 And purpose = "Orbat") Or orbat(x).comd > 0 Then
                        subNode = ParentNode.Nodes.Add(orbat(x).Title, orbat(x).Title)
                        subNode.BackColor = orbat(x).status(purpose)
                        If orbat(x).comd = 0 Then
                            If purpose = "Orbat" And orbat(x).Inf Then If orbat(x).dismounted Then subNode.ToolTipText = "Dismounted" Else subNode.ToolTipText = "Embused"
                        End If
                    End If
                    If (purpose = "Orbat" And orbat(x).comd > 0) Or (purpose <> "Orbat" And orbat(x).comd > 1) Then
                        CreateNodes(side, subNode, orbat(x).title, purpose)
                    End If
                End If
            End If
        Next
    End Sub
    Public Sub link_event_to_unit(unit_name As String, t As String)
        If t <> "" Then t = Replace(t, ":00", "")
        For Each u As cunit In orbat
            If (u.parent = orbat(unit_name).title And u.comd = 0 And Not u.aircraft) Or u.title = unit_name Then u.arrives = Val(t)
        Next
    End Sub

    Public Sub test_for_events(ByVal s As String, ByVal t As Date)
        For Each e As cevents In event_list
            If Not e.tested Then
                If Format(t, "HH:mm") >= e.time And UCase(s) = UCase(e.side) Then
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
                            If UCase(u.nation) = UCase(e.side) And (u.title = e.unit Or u.parent = e.unit) Then
                                u.arrives = 0
                                If gt <> 1 And u.comd = 0 Then
                                    With u
                                        .mode = travel
                                        .moved = gt
                                        .emplaced = False
                                    End With
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        Next
    End Sub

End Module
