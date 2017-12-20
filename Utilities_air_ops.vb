Module Utilities_air_ops


    Public Function cap_deployed(cap1 As Collection, cap2 As Collection)
        cap_deployed = False
        Dim c1 As Integer = 0, c2 As Integer = 0
        For Each ac As cunit In cap1
            If ac.airborne And ac.task = "CAP" Then c1 = c1 + 1
        Next
        For Each ac As cunit In cap2
            If ac.airborne And ac.task = "CAP" Then c2 = c2 + 1
        Next
        If c1 > 0 And c2 = 0 Then cap_deployed = True
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
