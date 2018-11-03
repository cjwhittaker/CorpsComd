Public Class cequipment
    Private ptitle As String
    Private pdefence As Integer
    Private prole As String
    Private pspecial As String
    Private ppayload As Integer
    Private pweapon_2 As String
    Private pmobility As String
    Private pbor As Integer
    Private pSize As Integer
    Private pe_time As Integer
    Private pindirect_e As Integer
    Private pindirect_m As Integer
    Private pCAE As Integer
    Private pR300 As Integer
    Private pR600 As Integer
    Private pR1000 As Integer
    Private pR1500 As Integer
    Private pR2000 As Integer
    Private pR2500 As Integer
    Private pR3000 As Integer
    Private pR4000 As Integer
    Private pmaxrange As Integer
    Private popr As Integer
    Private psortie As Integer
    Private pEWCapable As Boolean
    Private pmiss_def As Integer
    Private pgun_def As Integer
    Private pecm_miss As Integer
    Private pecm_gun As Integer
    Private pcannon As Integer
    Private pordnance As Integer
    Private pstandoff As Integer
    Private pstandoff_range As String
    Private paam As Integer
    Private paam_close As Integer
    Private ponethird As Integer
    Private ptwothird As Integer
    Private pfull As Integer
    Private pradar As String
    Private plow As Integer
    Private pmedium As Integer
    Private phigh As Integer

    Property title() As String
        Get
            Return ptitle
        End Get
        Set(ByVal value As String)
            ptitle = value
        End Set
    End Property
    Property weapon_2() As String
        Get
            Return pweapon_2
        End Get
        Set(ByVal value As String)
            pweapon_2 = value
        End Set
    End Property
    Property role() As String
        Get
            Return prole
        End Get
        Set(ByVal value As String)
            prole = value
        End Set
    End Property
    Property mobility() As String
        Get
            Return pmobility
        End Get
        Set(ByVal value As String)
            pmobility = value
        End Set
    End Property
    Property bor() As Integer
        Get
            Return pbor
        End Get
        Set(ByVal Value As Integer)
            pbor = Value
        End Set
    End Property
    Property defence() As Integer
        Get
            Return pdefence
        End Get
        Set(ByVal Value As Integer)
            pdefence = Value
        End Set
    End Property
    Property special() As String
        Get
            Return pspecial
        End Get
        Set(ByVal Value As String)
            pspecial = Value
        End Set
    End Property
    Property payload() As Integer
        Get
            Return ppayload
        End Get
        Set(ByVal Value As Integer)
            ppayload = Value
        End Set
    End Property
    Property Size() As Integer
        Get
            Return pSize
        End Get
        Set(ByVal Value As Integer)
            pSize = Value
        End Set
    End Property
    Property e_time() As Integer
        Get
            Return pe_time
        End Get
        Set(ByVal Value As Integer)
            pe_time = Value
        End Set
    End Property
    Property CAE() As Integer
        Get
            Return pCAE
        End Get
        Set(ByVal Value As Integer)
            pCAE = Value
        End Set
    End Property
    Property indirect_e() As Integer
        Get
            Return pindirect_e
        End Get
        Set(ByVal Value As Integer)
            pindirect_e = Value
        End Set
    End Property
    Property indirect_m() As Integer
        Get
            Return pindirect_m
        End Get
        Set(ByVal Value As Integer)
            pindirect_m = Value
        End Set
    End Property
    Property R300() As Integer
        Get
            Return pR300
        End Get
        Set(ByVal Value As Integer)
            pR300 = Value
        End Set
    End Property
    Property R600() As Integer
        Get
            Return pR600
        End Get
        Set(ByVal Value As Integer)
            pR600 = Value
        End Set
    End Property
    Property R1000() As Integer
        Get
            Return pR1000
        End Get
        Set(ByVal Value As Integer)
            pR1000 = Value
        End Set
    End Property
    Property R1500() As Integer
        Get
            Return pR1500
        End Get
        Set(ByVal Value As Integer)
            pR1500 = Value
        End Set
    End Property
    Property R2000() As Integer
        Get
            Return pR2000
        End Get
        Set(ByVal Value As Integer)
            pR2000 = Value
        End Set
    End Property
    Property R2500() As Integer
        Get
            Return pR2500
        End Get
        Set(ByVal Value As Integer)
            pR2500 = Value
        End Set
    End Property
    Property R3000() As Integer
        Get
            Return pR3000
        End Get
        Set(ByVal Value As Integer)
            pR3000 = Value
        End Set
    End Property
    Property R4000() As Integer
        Get
            Return pR4000
        End Get
        Set(ByVal Value As Integer)
            pR4000 = Value
        End Set
    End Property
    Property maxrange() As Integer
        Get
            Return pmaxrange
        End Get
        Set(ByVal Value As Integer)
            pmaxrange = Value
        End Set
    End Property
    Property opr() As Integer
        Get
            Return popr
        End Get
        Set(ByVal Value As Integer)
            popr = Value
        End Set
    End Property
    Property sortie() As Integer
        Get
            Return psortie
        End Get
        Set(ByVal Value As Integer)
            psortie = Value
        End Set
    End Property
    Property EWcapable() As Boolean
        Get
            Return pEWCapable
        End Get
        Set(ByVal Value As Boolean)
            pEWCapable = Value
        End Set
    End Property
    Property miss_def() As Integer
        Get
            Return pmiss_def
        End Get
        Set(ByVal Value As Integer)
            pmiss_def = Value
        End Set
    End Property
    Property gun_def() As Integer
        Get
            Return pgun_def
        End Get
        Set(ByVal Value As Integer)
            pgun_def = Value
        End Set
    End Property
    Property ecm_miss() As Integer
        Get
            Return pecm_miss
        End Get
        Set(ByVal Value As Integer)
            pecm_miss = Value
        End Set
    End Property
    Property ecm_gun() As Integer
        Get
            Return pecm_gun
        End Get
        Set(ByVal Value As Integer)
            pecm_gun = Value
        End Set
    End Property
    Property cannon() As Integer
        Get
            Return pcannon
        End Get
        Set(ByVal Value As Integer)
            pcannon = Value
        End Set
    End Property
    Property ordnance() As Integer
        Get
            Return pordnance
        End Get
        Set(ByVal Value As Integer)
            pordnance = Value
        End Set
    End Property
    Property standoff() As Integer
        Get
            Return pstandoff
        End Get
        Set(ByVal Value As Integer)
            pstandoff = Value
        End Set
    End Property
    Property standoff_range() As String
        Get
            Return pstandoff_range
        End Get
        Set(ByVal Value As String)
            pstandoff_range = Value
        End Set
    End Property
    Property aam() As Integer
        Get
            Return paam
        End Get
        Set(ByVal Value As Integer)
            paam = Value
        End Set
    End Property
    Property aam_close() As Integer
        Get
            Return paam_close
        End Get
        Set(ByVal Value As Integer)
            paam_close = Value
        End Set
    End Property
    Property onethird() As Integer
        Get
            Return ponethird
        End Get
        Set(ByVal Value As Integer)
            ponethird = Value
        End Set
    End Property
    Property twothird() As Integer
        Get
            Return ptwothird
        End Get
        Set(ByVal Value As Integer)
            ptwothird = Value
        End Set
    End Property
    Property full() As Integer
        Get
            Return pfull
        End Get
        Set(ByVal Value As Integer)
            pfull = Value
        End Set
    End Property
    Property radar() As String
        Get
            Return pradar
        End Get
        Set(ByVal Value As String)
            pradar = Value
        End Set
    End Property
    Property low() As Integer
        Get
            Return plow
        End Get
        Set(ByVal Value As Integer)
            plow = Value
        End Set
    End Property
    Property medium() As Integer
        Get
            Return pmedium
        End Get
        Set(ByVal Value As Integer)
            pmedium = Value
        End Set
    End Property
    Property high() As Integer
        Get
            Return phigh
        End Get
        Set(ByVal Value As Integer)
            phigh = Value
        End Set
    End Property
    Public Function air_to_air_effect()
        air_to_air_effect = 0
        If aam >= aam_close And aam >= cannon Then
            air_to_air_effect = aam
        ElseIf aam_close >= aam And aam_close >= cannon Then
            air_to_air_effect = aam_close
        Else
            air_to_air_effect = cannon
        End If
    End Function
    Public Function valid_equipment(n As String, purpose As String)
        'valid_equipment = False
        'If InStr(title, "soft") > 0 Then Exit Function
        'If (purpose = "Ground Fire Targets" And n = nation And Not aircraft()) _
        '        Or (purpose = "Direct Fire" And n = nation And Not indirect() And Not aircraft() And Not airdefence()) _
        '        Or (purpose = "Indirect Fire" And n = nation And indirect() And Not aircraft()) Then
        '    valid_equipment = True
        'End If
    End Function
End Class
