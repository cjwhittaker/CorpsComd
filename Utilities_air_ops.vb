Module Utilities_air_ops


    Public Function cap_deployed(cap_a As Collection, cap_b As Collection, purpose As String)
        cap_deployed = ""
        Dim x As Integer = 0, y As Integer = 0
        For Each ac As cunit In cap_a
            If ac.airborne And ac.task = "CAP" Then x = x + 1
        Next
        For Each ac As cunit In cap_b
            If ac.airborne And ac.task = "CAP" Then y = y + 1
        Next

        If x = 0 And y = 0 Then cap_deployed = "None" : Exit Function
        If x > 0 And y > 0 And purpose = "AS" Then cap_deployed = "AS battle" : Exit Function
        If x = y And x > 0 And y > 0 Then cap_deployed = "None" : Exit Function
        If x > 0 And (y = 0 Or x > y) And purpose = "Intercept" Then cap_deployed = "ph intercept" : Exit Function
        If (y > x Or x = 0) And y > 0 And purpose = "Intercept" Then cap_deployed = "nph intercept" : Exit Function
        If x > 0 And y = 0 And purpose = "Ground Air" Then cap_deployed = "nph ground air" : Exit Function
        If x = 0 And y > 0 And purpose = "Ground Air" Then cap_deployed = "ph ground air" : Exit Function
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
            If u.eligibleCB Then cb_targets = True : Exit For
        Next
    End Function

End Module
