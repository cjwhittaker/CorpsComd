Module Tests

    Sub testfiring()
        Dim firer As cunit = orbat("A/45 Fd"), target As cunit = orbat("D/35 GMRR"), range As Integer = 12000
        firer.firers = 5
        Dim cas As Integer = firecasualties(firer, target, range, False)
    End Sub


End Module
