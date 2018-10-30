Module Utilities_air_ops
    Public Function abort_option(f As cunit, t As cunit, stage As Integer)
        abort_option = False
        If t.title Is Nothing Or f.title Is Nothing Then Exit Function
        If f.strength - f.aborts - f.casualties > 0 Then
            If stage = 3 Then
                If eq_list(f.equipment).gun_def + 2 >= eq_list(t.equipment).gun_def Then abort_option = True
            ElseIf stage > 0 Then
                If eq_list(f.equipment).miss_def + 2 >= eq_list(t.equipment).miss_def Then abort_option = True
            Else
                If eq_list(f.equipment).miss_def >= eq_list(t.equipment).miss_def Then abort_option = True
            End If
        End If
    End Function

    Public Function air_assessment(subphase As Integer, curr As String)
        air_assessment = ""
        Dim x As Integer = 0, y As Integer = 0, x_ad As Integer = 0, y_ad As Integer = 0, x1 As Integer = 0, y1 As Integer = 0, x2 As Integer = 0, y2 As Integer = 0
        For Each ac As cunit In p1_air
            If ac.airborne And ac.task = "CAP" And ac.tacticalpts = 3 Then x = x + 1
            If subphase > 2 And ac.airborne And ac.task = "CAP" And ac.tacticalpts = 2 Then x1 = x1 + 1
            If subphase > 2 And ac.airborne And ac.task = "CAP" And ac.tacticalpts = 1 Then x2 = x2 + 1
            If ac.area_air_defence Then x_ad = x_ad + 1
        Next
        For Each ac As cunit In p2_air
            If ac.airborne And ac.task = "CAP" And ac.tacticalpts = 3 Then y = y + 1
            If subphase > 2 And ac.airborne And ac.task = "CAP" And ac.tacticalpts = 2 Then y1 = y1 + 1
            If subphase > 2 And ac.airborne And ac.task = "CAP" And ac.tacticalpts = 1 Then y2 = y2 + 1
            If ac.area_air_defence Then y_ad = y_ad + 1
        Next
        If x + x1 + x2 = 0 And y + y1 + y2 = 0 Then air_assessment = "None" : Exit Function
        If subphase = 1 Then
            If x = y Then
                air_assessment = "Parity"
            ElseIf x > y Then
                air_assessment = p1
            Else
                air_assessment = p2
            End If
        ElseIf subphase = 2 Then
            If x = 0 And y > 0 And x_ad > 0 Then
                air_assessment = p1 + " ADSAM"
            ElseIf y = 0 And x > 0 And y_ad > 0 Then
                air_assessment = p2 = " ADSAM"
            Else
                air_assessment = "None"
            End If
        ElseIf subphase = 3 Then
            If x + x1 = 0 And y + y1 > 0 And y2 = 0 Then
                air_assessment = p2
            ElseIf y + y1 = 0 And x + x1 > 0 And x2 = 0 Then
                air_assessment = p1
            Else
                air_assessment = curr
            End If
        ElseIf subphase = 4 Then
            If p1 = curr And x2 + x1 + x = 0 Then
                air_assessment = "Parity"
            ElseIf p2 = curr And y2 + y1 + y = 0 Then
                air_assessment = "Parity"
            Else
                air_assessment = curr
            End If
        Else
        End If

    End Function
    Public Function ground_air_required(initial)
        ground_air_required = False
        Dim x As Integer = 0, y As Integer = 0
        For Each ac As cunit In p1_air
            If ac.airborne Then
                If initial And ac.abbrev_air_mission = "CAS" Then
                    ac.tacticalpts = IIf(ac.loiter, 3, 2)
                ElseIf initial And ac.abbrev_air_mission = "PGM" Or ac.abbrev_air_mission = "SEAD" Then
                    ac.tacticalpts = 1
                Else
                End If
                If (Not initial And Not ac.heli) Or initial Then x = x + 1
            End If
        Next
        For Each ac As cunit In p2_air
            If ac.airborne Then
                If initial And ac.abbrev_air_mission = "CAS" Then
                    ac.tacticalpts = IIf(ac.loiter, 3, 2)
                ElseIf initial And ac.abbrev_air_mission = "PGM" Or ac.abbrev_air_mission = "SEAD" Then
                    ac.tacticalpts = 1
                Else
                End If
                If (Not initial And Not ac.heli) Or initial Then y = y + 1
            End If
        Next
        If x > 0 Or y > 0 Then ground_air_required = True
    End Function
    Public Function arty_fire_mission(mission As String, side As Collection)
        arty_fire_mission = False
        For Each u As cunit In side
            If u.comd = 0 And u.indirect And u.task = mission Then arty_fire_mission = True : Exit For
        Next
    End Function
    Public Function cb_capable(side As Collection)
        cb_capable = False
        For Each u As cunit In side
            If u.arty_int > 0 Then cb_capable = True : Exit For
        Next
    End Function
    Public Function cb_targets(side As Collection)
        cb_targets = False
        For Each u As cunit In side
            If u.sorties > 0 And u.indirect Then cb_targets = True : Exit For
        Next
    End Function

End Module
