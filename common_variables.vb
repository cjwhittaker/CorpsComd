Module common_variables
    Public orbat As Collection, unit As cunit, u As cunit
    Public equipment As Collection, e As cequipment
    Public TOE As Collection, subunit As csubunit
    Public unittypes As Collection, unittype As cunittype
    Public scenario As String
    Public ph As String, nph As String
    Public ph_hqs As Collection, recovered As Collection
    Public p1_hqs As Collection, p2_HQs As Collection
    Public p1_units As Collection, p2_Units As Collection
    Public p1_orbat As Collection, p2_orbat As Collection
    Public testfirers As Collection, testtargets As Collection
    Public ph_units As Collection, enemy As Collection, subject As cunit
    Public smokefiredlasturn As Boolean = False, smokefiredthisturn As Boolean
    Public qtypinned As Integer, qtyrepulsed As Integer, qtydestroyed As Integer
    Public topserial As Integer, oppfire As Boolean
    Public repulsedstatus As Color = Color.Green, lowammo As Color = Color.Blue, pinnedstatus As Color = Color.Yellow, pinnedandrepulsedstatus As Color = Color.YellowGreen
    Public nostatus As Color = Color.White, routedstatus As Color = Color.Red, dead As Color = Color.DarkGray, demoralisedstatus As Color = Color.DarkOrange, airborne As Color = Color.Aquamarine
    Public demoralisationrecovery As New unit_selection, opportunityfire As New unit_selection
    Public transport As New unit_selection, aircombat As New unit_selection, airdefence As New unit_selection
    Public ca_defenders As New unit_selection
    Public night As Boolean
End Module
