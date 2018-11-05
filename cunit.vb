Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class cunit
    Implements ICloneable
    Private pTitle As String
    Private pcomd As Integer
    Private pcomdpts As Integer
    Private ptacticalpts As Integer
    Private pnation As String
    Private pquality As Integer
    Private pequipment As String
    Private prole As String
    Private pinitial As Integer
    Private paborts As Integer
    Private pcas_gt As Integer
    Private phalfstrength As Boolean
    Private pstrength As Integer
    Private pmode As String
    Private ppre_mode As String
    Private pelevated As Boolean
    Private proadmove As Boolean
    Private pfire_phase As Boolean
    Private pdisrupted_gt As Boolean
    Private pdisrupted As Boolean
    Private pcover As Integer
    Private pcarrying As String
    Private pmoved As Integer
    Private pfired As Integer
    Private phit As Boolean
    Private pparent As String
    Private pairbase As String
    Private pfirers_available As Integer
    Private psorties As Integer
    Private pflanked As Boolean
    Private prear As Boolean
    Private pdemoralised As Boolean
    Private psecondary As String
    Private pprimary As String
    Private pairborne As Boolean
    Private phits As Integer
    Private psmoke As Integer
    Private peligibleCB As Boolean
    Private pfirers As Integer
    Private pcasualties As Integer
    Private ptask As String
    Private pordnance As Boolean
    Private pewsupported As Boolean
    Private pplains As Boolean
    Private pinsmoke As Boolean
    Private parrives As Integer
    Private pspotted As Boolean
    Private peffective As Boolean
    Private peffect As Integer
    Private pfires As Boolean
    Private pmsg As String
    Private prockets As Integer
    Private phel_atgw As Boolean
    Private pmodifier As Integer
    Private presult As Integer
    Private psupport As Boolean
    Private passault As Boolean
    Private pmissiles As Integer
    Private plostcomms As Boolean
    Private pfatigue As Integer
    Private popp_move As Integer
    Private popp_mode As Integer
    Private popp_ca As Integer
    Private popp_return As Integer
    Private pscoot As Boolean
    Private pdebussed_gt As Integer
    Private party_int As Integer
    Private pooc As Boolean
    Private pemplaced As Boolean


    Property nation() As String
        Get
            Return pnation
        End Get
        Set(ByVal Value As String)
            pnation = Value
        End Set
    End Property
    Property title() As String
        Get
            Return pTitle
        End Get
        Set(ByVal Value As String)
            pTitle = Value
        End Set
    End Property
    Property comd() As Integer
        Get
            Return pcomd
        End Get
        Set(ByVal Value As Integer)
            pcomd = Value
        End Set
    End Property
    Property comdpts() As Integer
        Get
            Return pcomdpts
        End Get
        Set(ByVal Value As Integer)
            pcomdpts = Value
        End Set
    End Property
    Property tacticalpts() As Integer
        Get
            Return ptacticalpts
        End Get
        Set(ByVal Value As Integer)
            ptacticalpts = Value
        End Set
    End Property
    Property ooc() As Boolean
        Get
            Return pooc
        End Get
        Set(ByVal Value As Boolean)
            pooc = Value
        End Set
    End Property
    Property equipment() As String
        Get
            Return pequipment
        End Get
        Set(ByVal Value As String)
            pequipment = Value
        End Set
    End Property
    Property role() As String
        Get
            Return prole
        End Get
        Set(ByVal Value As String)
            prole = Value
        End Set
    End Property
    Property strength() As Integer
        Get
            Return pstrength
        End Get
        Set(ByVal Value As Integer)
            pstrength = Value
        End Set
    End Property
    Property arty_int() As Integer
        Get
            Return party_int
        End Get
        Set(ByVal Value As Integer)
            party_int = Value
        End Set
    End Property
    Property initial() As Integer
        Get
            Return pinitial
        End Get
        Set(ByVal Value As Integer)
            pinitial = Value
        End Set
    End Property
    Property quality() As Integer
        Get
            Return pquality
        End Get
        Set(ByVal Value As Integer)
            pquality = Value
        End Set
    End Property
    Property mode() As String
        Get
            Return pmode
        End Get
        Set(ByVal Value As String)
            pmode = Value
        End Set
    End Property
    Property pre_mode() As String
        Get
            Return ppre_mode
        End Get
        Set(ByVal Value As String)
            ppre_mode = Value
        End Set
    End Property
    Property casualties() As Integer
        Get
            Return pcasualties
        End Get
        Set(ByVal Value As Integer)
            pcasualties = Value
        End Set
    End Property
    Property aborts() As Integer
        Get
            Return paborts
        End Get
        Set(ByVal Value As Integer)
            paborts = Value
        End Set
    End Property
    Property parent() As String
        Get
            Return pparent
        End Get
        Set(ByVal Value As String)
            pparent = Value
        End Set
    End Property
    Property airbase() As String
        Get
            Return pairbase
        End Get
        Set(ByVal Value As String)
            pairbase = Value
        End Set
    End Property
    Property carrying() As String
        Get
            Return pcarrying
        End Get
        Set(ByVal Value As String)
            pcarrying = Value
        End Set
    End Property
    Property secondary() As String
        Get
            Return psecondary
        End Get
        Set(ByVal Value As String)
            psecondary = Value
        End Set
    End Property
    Property primary() As String
        Get
            Return pprimary
        End Get
        Set(ByVal Value As String)
            pprimary = Value
        End Set
    End Property
    Property scoot() As Boolean
        Get
            Return pscoot
        End Get
        Set(ByVal Value As Boolean)
            pscoot = Value
        End Set
    End Property
    Property emplaced() As Boolean
        Get
            Return pemplaced
        End Get
        Set(ByVal Value As Boolean)
            pemplaced = Value
        End Set
    End Property
    Property debussed_gt() As Integer
        Get
            Return pdebussed_gt
        End Get
        Set(ByVal Value As Integer)
            pdebussed_gt = Value
        End Set
    End Property

    Property disrupted_gt() As Boolean
        Get
            Return pdisrupted_gt
        End Get
        Set(ByVal Value As Boolean)
            pdisrupted_gt = Value
        End Set
    End Property
    Property disrupted() As Boolean
        Get
            Return pdisrupted
        End Get
        Set(ByVal Value As Boolean)
            pdisrupted = Value
        End Set
    End Property
    Property roadmove() As Boolean
        Get
            Return proadmove
        End Get
        Set(ByVal Value As Boolean)
            proadmove = Value
        End Set
    End Property
    Property fire_phase() As Boolean
        Get
            Return pfire_phase
        End Get
        Set(ByVal Value As Boolean)
            pfire_phase = Value
        End Set
    End Property
    Property elevated() As Boolean
        Get
            Return pelevated
        End Get
        Set(ByVal Value As Boolean)
            pelevated = Value
        End Set
    End Property
    Property demoralised() As Boolean
        Get
            Return pdemoralised
        End Get
        Set(ByVal Value As Boolean)
            pdemoralised = Value
        End Set
    End Property
    Property hit() As Boolean
        Get
            Return phit
        End Get
        Set(ByVal Value As Boolean)
            phit = Value
        End Set
    End Property
    Property fired() As Integer
        Get
            Return pfired
        End Get
        Set(ByVal Value As Integer)
            pfired = Value
        End Set
    End Property
    Property moved() As Integer
        Get
            Return pmoved
        End Get
        Set(ByVal Value As Integer)
            pmoved = Value
        End Set
    End Property
    Property assault() As Boolean
        Get
            Return passault
        End Get
        Set(ByVal Value As Boolean)
            passault = Value
        End Set
    End Property
    Property support() As Boolean
        Get
            Return psupport
        End Get
        Set(ByVal Value As Boolean)
            psupport = Value
        End Set
    End Property
    Property lostcomms() As Boolean
        Get
            Return plostcomms
        End Get
        Set(ByVal Value As Boolean)
            plostcomms = Value
        End Set
    End Property
    Property fires() As Boolean
        Get
            Return pfires
        End Get
        Set(ByVal Value As Boolean)
            pfires = Value
        End Set
    End Property
    Property spotted() As Boolean
        Get
            Return pspotted
        End Get
        Set(ByVal Value As Boolean)
            pspotted = Value
        End Set
    End Property
    Property ordnance() As Boolean
        Get
            Return pordnance
        End Get
        Set(ByVal Value As Boolean)
            pordnance = Value
        End Set
    End Property
    Property eligibleCB() As Boolean
        Get
            Return peligibleCB
        End Get
        Set(ByVal Value As Boolean)
            peligibleCB = Value
        End Set
    End Property
    Property plains() As Boolean
        Get
            Return pplains
        End Get
        Set(ByVal Value As Boolean)
            pplains = Value
        End Set
    End Property
    Property insmoke() As Boolean
        Get
            Return pinsmoke
        End Get
        Set(ByVal Value As Boolean)
            pinsmoke = Value
        End Set
    End Property

    Property airborne() As Boolean
        Get
            Return pairborne
        End Get
        Set(ByVal Value As Boolean)
            pairborne = Value
        End Set
    End Property
    Property ewsupported() As Boolean
        Get
            Return pewsupported
        End Get
        Set(ByVal Value As Boolean)
            pewsupported = Value
        End Set
    End Property
    Property flanked() As Boolean
        Get
            Return pflanked
        End Get
        Set(ByVal Value As Boolean)
            pflanked = Value
        End Set
    End Property
    Property rear() As Boolean
        Get
            Return prear
        End Get
        Set(ByVal Value As Boolean)
            prear = Value
        End Set
    End Property
    Property effective() As Boolean
        Get
            Return peffective
        End Get
        Set(ByVal Value As Boolean)
            peffective = Value
        End Set
    End Property
    Property result() As Integer
        Get
            Return presult
        End Get
        Set(ByVal Value As Integer)
            presult = Value
        End Set
    End Property
    Property modifier() As Integer
        Get
            Return pmodifier
        End Get
        Set(ByVal Value As Integer)
            pmodifier = Value
        End Set
    End Property
    Property hel_atgw() As Boolean
        Get
            Return phel_atgw
        End Get
        Set(ByVal Value As Boolean)
            phel_atgw = Value
        End Set
    End Property
    Property msg() As String
        Get
            Return pmsg
        End Get
        Set(ByVal Value As String)
            pmsg = Value
        End Set
    End Property
    Property effect() As Integer
        Get
            Return peffect
        End Get
        Set(ByVal Value As Integer)
            peffect = Value
        End Set
    End Property
    Property task() As String
        Get
            Return ptask
        End Get
        Set(ByVal Value As String)
            ptask = Value
        End Set
    End Property
    Property rockets() As Integer
        Get
            Return prockets
        End Get
        Set(ByVal Value As Integer)
            prockets = Value
        End Set
    End Property
    Property firers() As Integer
        Get
            Return pfirers
        End Get
        Set(ByVal Value As Integer)
            pfirers = Value
        End Set
    End Property
    Property smoke() As Integer
        Get
            Return psmoke
        End Get
        Set(ByVal Value As Integer)
            psmoke = Value
        End Set
    End Property
    Property hits() As Integer
        Get
            Return phits
        End Get
        Set(ByVal Value As Integer)
            phits = Value
        End Set
    End Property
    Property sorties() As Integer
        Get
            Return psorties
        End Get
        Set(ByVal Value As Integer)
            psorties = Value
        End Set
    End Property
    Property firers_available() As Integer
        Get
            Return pfirers_available
        End Get
        Set(ByVal Value As Integer)
            pfirers_available = Value
        End Set
    End Property
    Property Cover() As Integer
        Get
            Return pcover
        End Get
        Set(ByVal Value As Integer)
            pcover = Value
        End Set
    End Property
    Property missiles() As Integer
        Get
            Return pmissiles
        End Get
        Set(ByVal Value As Integer)
            pmissiles = Value
        End Set
    End Property
    Property halfstrength() As Boolean
        Get
            Return phalfstrength
        End Get
        Set(ByVal Value As Boolean)
            phalfstrength = Value
        End Set
    End Property
    Property cas_gt() As Integer
        Get
            Return pcas_gt
        End Get
        Set(ByVal Value As Integer)
            pcas_gt = Value
        End Set
    End Property
    Property fatigue() As Integer
        Get
            Return pfatigue
        End Get
        Set(ByVal Value As Integer)
            pfatigue = Value
        End Set
    End Property
    Property opp_move() As Integer
        Get
            Return popp_move
        End Get
        Set(ByVal Value As Integer)
            popp_move = Value
        End Set
    End Property
    Property opp_mode() As Integer
        Get
            Return popp_mode
        End Get
        Set(ByVal Value As Integer)
            popp_mode = Value
        End Set
    End Property
    Property opp_ca() As Integer
        Get
            Return popp_ca
        End Get
        Set(ByVal Value As Integer)
            popp_ca = Value
        End Set
    End Property
    Property opp_return() As Integer
        Get
            Return popp_return
        End Get
        Set(ByVal Value As Integer)
            popp_return = Value
        End Set
    End Property

    Property arrives() As Integer
        Get
            Return parrives
        End Get
        Set(ByVal Value As Integer)
            parrives = Value
        End Set
    End Property

    Public Function w2()
        w2 = ""
        If helarm() Then
            If eq_list(equipment).ordnance = 0 And eq_list(equipment).cannon = 0 Then
            ElseIf eq_list(equipment).weapon_2 Is Nothing And eq_list(equipment).cannon = 0 Then
            ElseIf eq_list(equipment).weapon_2 Is Nothing And eq_list(equipment).ordnance = 0 Then
            Else
                w2 = "ATK"
            End If
        ElseIf Not eq_list(equipment).weapon_2 Is Nothing Then
            w2 = eq_list(equipment).weapon_2
        Else
        End If
    End Function

    Public Function observer() As Boolean
        observer = False
        If heli() And task = "DS" Then observer = True
        If ground_unit() And Not (indirect() And mode <> disp And Not conc()) Then observer = True
    End Function
    Public Function indirect() As Boolean
        indirect = False
        If InStr("|ARTY|RL|MOR|", role) > 0 Then indirect = True
    End Function
    Public Function depth_fire() As Boolean
        depth_fire = False
        If InStr("|FFR|RL|", role) > 0 Then depth_fire = True
    End Function
    Public Function root() As Boolean
        If parent = "root" Then root = True Else root = False
    End Function
    Public Function troopcarrier() As Boolean
        troopcarrier = False
        If InStr("|MICV|APC|", role) > 0 Then troopcarrier = True
    End Function
    Public Function embussed() As Boolean
        embussed = False
        If carrying <> "" And (InStr(title, "#") > 0 Or troopcarrier()) Then embussed = True
    End Function
    Public Function dismounted() As Boolean
        dismounted = False
        If (InStr(title, "#") > 0 And carrying = "") Then dismounted = True
    End Function
    Public Function arty_type()
        arty_type = ""
        If Not indirect() Then Exit Function
        If role = "|MOR|" Then
            arty_type = 0
        ElseIf role = "|ARTY|" Then
            arty_type = 1
        Else
            arty_type = 2
        End If
    End Function
    Public Function cb() As Boolean
        cb = False
        If indirect() And task = "DS" Then
            If orbat(parent).arty_int > 0 Then
                cb = True
            ElseIf primary Is Nothing Then
                cb = False
            ElseIf orbat(primary).arty_int > 0 Then
                cb = True
            Else
            End If
        End If
    End Function
    Public Function can_embus() As Boolean
        can_embus = True
        If Not Inf() Or Not dismounted() Then can_embus = False
        Dim tmp As String = Replace(title, "#", "")
        If Not orbat.Contains(tmp) Then can_embus = False

    End Function
    Public Sub embus()
        Dim tmp As String = Replace(title, "#", "")
        carrying = tmp
        With orbat(tmp)
            .carrying = title
            .mode = mode
            .debussed_gt = phase
        End With
    End Sub
    Public Sub debus()
        Dim tmp As String = carrying
        If tmp = "" Then Exit Sub
        carrying = ""
        debussed_gt = phase
        With orbat(tmp)
            .carrying = ""
            .mode = mode
            .debussed_gt = phase
        End With
    End Sub
    Public Function loiter() As Boolean
        loiter = False
        If aircraft() And InStr(eq_list(equipment).special, "L") Then loiter = True
    End Function
    Public Function second_attack() As Boolean
        second_attack = False
        If ((loiter() And tacticalpts <= 2) Or (aircraft() And tacticalpts = 1)) Then second_attack = True
    End Function
    Public Function airdefence() As Boolean
        airdefence = False
        If role = "|InfSAM|" And Not dismounted() Then
            If orbat(carrying).mode <> travel Then airdefence = True : emplaced = True
        ElseIf mode = travel Then
            airdefence = False
            'ElseIf carrying <> "" Then
            '    If orbat(carrying).Inf() And orbat(carrying).role = "|InfSAM|" Then
            '        equipment = equipment + ph_units(carrying).equipment : secondary = ph_units(carrying).equipment

            '        airdefence = True
            '    ElseIf Not dismounted() And role = "|InfSAM|" Then
            '        airdefence = False
            '    Else
            '    End If
        ElseIf InStr("|PDSAM|InfSAM|ADSAM|AAA|", role) > 0 Then
            airdefence = True
        Else
        End If
    End Function
    Public Function area_air_defence() As Boolean
        area_air_defence = False
        Try
            If Not airdefence() Then Exit Function
            If eq_list(equipment).maxrange < 30000 Then Exit Function
            If Not eligibleCB Or mode <> disp Then Exit Function
            area_air_defence = True
        Catch ex As Exception
            MsgBox(title + " " + equipment)
        End Try
    End Function

    Public Function radar() As Boolean
        radar = False
        If mode = travel Then
            radar = False
        ElseIf InStr("|PDSAM|ADSAM|AAA|", role) > 0 And InStr(UCase(eq_list(Me.equipment).special), "E") > 0 Then
            radar = True
        Else
            radar = False
        End If

    End Function
    Public Function valid_air_defence(r As Integer, altitude As String) As Boolean
        valid_air_defence = False
        'If mode = travel Then Exit Function
        If r / eq_list(equipment).maxrange > 0.67 Or (r / eq_list(equipment).maxrange > 0.5 And role = "|AAA|") Then
            If InStr(eq_list(equipment).radar, "M") > 0 And Not eligibleCB Then Exit Function
        ElseIf r / eq_list(equipment).maxrange > 0.34 Or role = "|AAA|" Then
            If InStr(eq_list(equipment).radar, "E") > 0 And Not eligibleCB Then Exit Function
        Else
            If InStr(eq_list(equipment).radar, "C") > 0 And Not eligibleCB Then Exit Function
        End If
        If (altitude = "Low" Or altitude = "Very Low") Then
            modifier = eq_list(equipment).low
        ElseIf altitude = "Medium" Then
            modifier = eq_list(equipment).medium
        Else
            modifier = eq_list(equipment).high
        End If
        If modifier = 9 Then Exit Function
        If ordnance Then Exit Function
        valid_air_defence = True

    End Function
    Public Function Airsuperiority() As Boolean
        Airsuperiority = False
        If airborne And (task = "Escort" Or task = "CAP" Or task = "EW Support") Then Airsuperiority = True
    End Function
    Public Function sead() As Boolean
        If task = "SEAD" And airborne Then sead = True Else sead = False
    End Function

    Public Function heli() As Boolean
        heli = False
        If InStr("|AH|OH|UH|TH|", role) > 0 Then heli = True
    End Function
    Public Function aircraft() As Boolean
        aircraft = False
        If InStr("|AC|AS|SO|SEAD|AH|OH|TB|GA|AWACS|EW|", role) > 0 Then aircraft = True
    End Function
    Public Function helarm() As Boolean
        helarm = False
        If role = "|AH|" And airborne Then helarm = True
    End Function
    Public Function helarm_select_wpn(wpn As String) As String
        helarm_select_wpn = ""
        If Not heli() Then Exit Function
        If wpn = equipment Then
            If Not hel_atgw And Not eq_list(equipment).weapon_2 Is Nothing Then
                helarm_select_wpn = eq_list(equipment).weapon_2
            ElseIf Not ordnance And eq_list(equipment).cannon = 0 Then
                helarm_select_wpn = "RP"
            ElseIf Not ordnance Or oppfire Then
                helarm_select_wpn = "Guns"
            Else

            End If
            secondary = helarm_select_wpn
            Exit Function
        End If
        helarm_select_wpn = wpn
        If wpn = eq_list(equipment).weapon_2 Then
            If (Not ordnance Or oppfire) And eq_list(equipment).cannon > 0 Then
                helarm_select_wpn = "Guns"
            ElseIf Not ordnance And eq_list(equipment).ordnance > 0 Then
                helarm_select_wpn = "RP"
            Else
            End If
        ElseIf wpn = "Guns" Then
            If Not ordnance And eq_list(equipment).ordnance > 0 Then
                helarm_select_wpn = "RP"
            ElseIf Not hel_atgw And Not eq_list(equipment).weapon_2 Is Nothing Then
                helarm_select_wpn = eq_list(equipment).weapon_2
            Else
            End If
        ElseIf wpn = "RP" Then
            If Not hel_atgw And Not eq_list(equipment).weapon_2 Is Nothing Then
                helarm_select_wpn = eq_list(equipment).weapon_2
            ElseIf (Not ordnance Or oppfire) And eq_list(equipment).cannon > 0 Then
                helarm_select_wpn = "Guns"
            Else
            End If
        Else
        End If

    End Function
    Public Function engr() As Boolean
        engr = False
        If title Is Nothing Then
            engr = False
        ElseIf InStr("|AEV|Eng|", role) > 0 Then
            engr = True
        Else
        End If

    End Function

    Public Function Airground() As Boolean
        Airground = False
        If task Is Nothing Then Exit Function
        If InStr("Ground AttackPGMSEAD", task) > 0 Then Airground = True

    End Function
    Public Function Inf() As Boolean
        Inf = False
        If InStr(role, "Inf") > 0 Or InStr(role, "Eng") Then Inf = True
    End Function
    Public Function cae(armd As Boolean)
        cae = 0
        If Not equipment Is Nothing Then If armd Then cae = eq_list(equipment).cae Else cae = eq_list(equipment + "soft").cae
    End Function
    Public Function afv() As Boolean
        afv = False
        If InStr("|MICV|TANK|RECON|", role) > 0 Then afv = True
    End Function
    Public Function atgw() As Boolean
        atgw = False
        If InStr("|ATGW|InfATGW|AH|", role) > 0 Then atgw = True
    End Function

    Public Function armour() As Boolean
        armour = False
        If Not equipment Is Nothing Then If eq_list(equipment).defence > 0 And Not aircraft() Then armour = True
    End Function

    Public Function hq() As Boolean
        If Me.comd > 0 Then hq = True : Exit Function
        If role = "|Comd|" Then hq = True Else hq = False
    End Function
    Public Function nondetect() As Boolean
        If airdefence() Or Airsuperiority() Or sead() Then nondetect = True Else nondetect = False
    End Function
    Public Function text_status()
        text_status = ""
        If demoralised Then
            text_status = "- Demoralised"
        ElseIf strength = 0 And comd = 0 Then
            text_status = "- Destroyed"
        ElseIf disrupted Then
            text_status = "- Routing"
        ElseIf moved Then
            text_status = "- Moving"
        ElseIf hit Then
            text_status = "- Under Fire " + IIf(Cover > 0, "in cover +" + Trim(Str(Cover)), "")
        Else
            text_status = "- Static " + IIf(Cover > 0, "in cover +" + Trim(Str(Cover)), "")
        End If
    End Function
    Public Function valid_air_mission(mission As String)
        valid_air_mission = False
        Dim x As String = ""
        If (mission = "CAP" Or mission = "Escort") Then
            x = "-AS"
        ElseIf mission = "Ground Attack" Then
            x = "-GA"
        ElseIf mission = "PGM" Then
            x = "-SO"
        ElseIf mission = "SEAD" Then
            x = "-SEAD"
        Else
        End If
        If Strings.Left(mission, 2) = "AH" And role = "|AH|" Then
            valid_air_mission = True
        ElseIf mission = "Observation" And role = "|OH|" Then
            valid_air_mission = True
        ElseIf eq_list.Contains(equipment + x) Then
            valid_air_mission = True
        Else
        End If
    End Function
    Public Function air_package()
        air_package = ""
        If (task = "CAP" Or task = "Escort") Then
            air_package = "-AS"
        ElseIf task = "Ground Attack" Then
            air_package = "-GA"
        ElseIf task = "PGM" Then
            air_package = "-SO"
        ElseIf task = "SEAD" Then
            air_package = "-SEAD"
        Else
        End If

    End Function
    Public Function abbrev_air_mission()
        If task Is Nothing Then
            abbrev_air_mission = ""
        ElseIf task = "CAP" And role = "|AS|" Then
            abbrev_air_mission = "AS"
        ElseIf task = "Escort" And role = "|AS|" Then
            abbrev_air_mission = "CE"
        ElseIf task = "Ground Attack" And (role = "|GA|" Or role = "|TB|") Then
            abbrev_air_mission = "CAS"
        ElseIf task = "PGM" And role = "|SO|" Then
            abbrev_air_mission = task
        ElseIf task = "SEAD" And role = "|SEAD|" Then
            abbrev_air_mission = task
        ElseIf instr(task, "AH ") > 0 And role = "|AH|" Then
            abbrev_air_mission = "AH"
        ElseIf (task = "Observation" Or task = "DS") And role = "|OH|" Then
            abbrev_air_mission = "OBS"
        Else
            abbrev_air_mission = "ERR"
        End If
    End Function
    Public Function set_altitude()
        If task Is Nothing Then
            set_altitude = "Medium"
        ElseIf task = "CAP" And role = "|AS|" Then
            set_altitude = "Medium"
        ElseIf task = "Escort" And role = "|AS|" Then
            set_altitude = "Low"
        ElseIf task = "Ground Attack" And (role = "|GA|" Or role = "|TB|") Then
            set_altitude = "Low"
        ElseIf task = "PGM" And role = "|SO|" Then
            set_altitude = "Medium"
        ElseIf task = "SEAD" And role = "|SEAD|" Then
            set_altitude = "Medium"
        ElseIf InStr(task, "AH ") > 0 And role = "|AH|" Then
            set_altitude = "Very Low"
        ElseIf (task = "DS" Or task = "Observation") And role = "|OH|" Then
            set_altitude = "Very Low"
        Else
            set_altitude = "ERR"
        End If

    End Function

    Public Function get_range(max As Boolean)
        get_range = 0
        If Not equipment Is Nothing Then
            If airborne Then
                If InStr(UCase(equipment), "GA") > 0 Or (heli() And secondary = "RP") Then
                    If max Then get_range = 2000 Else max = 1500
                ElseIf InStr(UCase(equipment), "SEAD") > 0 Then
                    get_range = 20000
                ElseIf heli() And secondary = eq_list(equipment).weapon_2 Then
                    If max Then get_range = eq_list(eq_list(equipment).weapon_2).maxrange Else get_range = eq_list(eq_list(equipment).weapon_2).opr
                ElseIf heli() And secondary = "Guns" Then
                    If max Then get_range = eq_list(equipment).maxrange Else get_range = eq_list(equipment).opr
                ElseIf InStr(equipment, "SO") > 0 Then
                    If eq_list(equipment).standoff_range = "s" Then
                        get_range = 10000
                    ElseIf eq_list(equipment).standoff_range = "m" Then
                        get_range = 20000
                    Else
                        get_range = 40000
                    End If
                Else
                    get_range = 100000
                End If
            ElseIf equipment <> secondary Then
                If max Then get_range = eq_list(equipment).maxrange Else get_range = eq_list(equipment).opr
            Else
                If max Then get_range = eq_list(equipment + secondary).maxrange Else get_range = eq_list(equipment + secondary).opr
            End If
        End If
        'get_range = maxrange
    End Function
    Public Sub set_fire_effect(target As cunit, r As Integer, stage As Integer)
        If equipment Is Nothing Then effect = 0 : Exit Sub
        Dim context As String = IIf(airborne, abbrev_air_mission, "")
        Dim max_range As Integer = get_range(True)
        If r > max_range Then effect = 0 : Exit Sub

        If context = "SEAD" And target.eligibleCB And target.airdefence Then
            effect = eq_list(equipment).standoff
            If r > max_range / 2 Then target.modifier = 1
        ElseIf context = "SEAD" And Not target.eligibleCB And target.airdefence Then
            effect = eq_list(equipment).ordnance
        ElseIf context = "CAS" Then
            If Not second_attack() And Not disrupted_gt Then
                effect = eq_list(equipment).ordnance
            Else
                effect = eq_list(equipment).cannon
            End If
        ElseIf context = "AS" Or context = "CE" Then
            'If stage = 0 Then
            '    effect = eq_list(equipment).air_to_air_effect
            '    If role = "|TB|" And Not heli() Then effect = Int(effect / 3)
            'Else
            If stage = 1 Then
                effect = eq_list(equipment).aam
                eq_list(target.equipment).defence = eq_list(target.equipment).miss_def
            ElseIf stage = 2 Then
                effect = eq_list(equipment).aam_close
            Else
                effect = eq_list(equipment).cannon
                eq_list(target.equipment).defence = eq_list(target.equipment).gun_def
                If role = "|TB|" Then effect = Int(effect / 3)
            End If
        ElseIf InStr("|PDSAM|InfSAM|ADSAM|AAA|", role) > 0 Then
            If r / eq_list(equipment).maxrange > 0.67 Or (r / eq_list(equipment).maxrange > 0.5 And role = "|AAA|") Then
                effect = eq_list(equipment).full
            ElseIf r / eq_list(equipment).maxrange > 0.34 Or role = "|AAA|" Then
                effect = eq_list(equipment).twothird
            Else
                effect = eq_list(equipment).onethird
            End If
            If (target.mode = "Low" Or target.mode = "Very Low") Then
                modifier = eq_list(equipment).low
            ElseIf target.mode = "Medium" Then
                modifier = eq_list(equipment).medium
            Else
                modifier = eq_list(equipment).high
            End If

        ElseIf Not indirect() Or (indirect() And spotted) Then
            Dim j As Integer = 0, weapon As String = ""
            effect = 0
            If heli() And role = "|AH|" Then
                weapon = secondary
                If weapon = "RP" Then
                    effect = eq_list(equipment).ordnance
                    Exit Sub
                ElseIf weapon = "Guns" Then
                    weapon = equipment
                Else
                End If
            ElseIf secondary = "" Then
                weapon = equipment
            Else
                weapon = secondary
            End If
            If Not target.armour() And Not eq_list.Contains(weapon + "soft") Then
                effect = 0
            Else
                If Not target.armour() Then weapon = weapon + "soft"
                Select Case r
                    Case 300
                        effect = eq_list(weapon).R300
                    Case 600
                        effect = eq_list(weapon).R600
                    Case 1000
                        effect = eq_list(weapon).R1000
                    Case 1500
                        effect = eq_list(weapon).R1500
                    Case 2000
                        effect = eq_list(weapon).R2000
                    Case 2500
                        effect = eq_list(weapon).R2500
                    Case 3000
                        effect = eq_list(weapon).R3000
                    Case 4000
                        effect = eq_list(weapon).R4000
                End Select
                If carrying <> "" And troopcarrier() And r <= 300 And Not target.armour Then effect = effect + 1
            End If
        ElseIf indirect() And Not spotted Then
            If r / eq_list(equipment).maxrange > 0.667 Then
                effect = eq_list(equipment).indirect_m
            Else
                effect = eq_list(equipment).indirect_e
            End If
        Else
            effect = 0
        End If
        End Sub
    Public Function composite() As Boolean
        composite = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "C") > 0 Then composite = True
    End Function
    Public Function heat() As Boolean
        heat = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "H") > 0 Then heat = True
    End Function
    Public Function heavy_fire() As Boolean
        heavy_fire = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "Y") > 0 Then heavy_fire = True
    End Function
    Public Function bomblets() As Boolean
        bomblets = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "X") > 0 Then bomblets = True
    End Function

    Public Function spaced() As Boolean
        spaced = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "S") > 0 Then spaced = True
    End Function
    Public Function stabilised() As Boolean
        stabilised = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "B") > 0 Then stabilised = True
    End Function
    Public Function recon() As Boolean
        recon = False
        If role = "|RECON|" Then recon = True
    End Function
    Public Function size() As Integer
        size = 0
        If Not equipment Is Nothing Then size = eq_list(equipment).size
    End Function
    Public Function soft_tpt() As Boolean
        soft_tpt = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "V") > 0 Then soft_tpt = True
    End Function
    Public Function conc() As Boolean
        conc = True
        If equipment = "" Then If InStr(UCase(eq_list(equipment).special), "D") > 0 Then conc = False
    End Function
    Public Function smoke_discharger() As Boolean
        smoke_discharger = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "P") > 0 Then smoke_discharger = True
    End Function
    Public Function smoke_generator() As Boolean
        smoke_generator = False
        If Not equipment Is Nothing Then If InStr(UCase(eq_list(equipment).special), "G") > 0 Then smoke_generator = True
    End Function
    Public Function arty_hq() As Boolean
        arty_hq = False
        If comd >= 4 Then
            arty_hq = True
        ElseIf comd >= 1 And InStr(LCase(title), "arty") > 0 Then
            arty_hq = True
        Else
        End If
    End Function
    Public Sub emplace()
        Dim x As Integer
        If Not equipment Is Nothing And (indirect() Or airdefence()) And mode <> travel And Not emplaced Then
            If orbat(parent).comd < 3 Then x = 1 Else x = orbat(parent).comd - 2
            If d10() > 3 Then tacticalpts = tacticalpts - 1
            If x + tacticalpts <= 0 Then emplaced = True : Exit Sub
        End If
    End Sub
    Public Function ground_unit() As Boolean
        ground_unit = False
        If aircraft() Or comd > 0 Then Exit Function
        ground_unit = True
        If troopcarrier() And carrying <> "" Then
            ground_unit = True
        ElseIf Inf() And embussed() Then
            ground_unit = False
        ElseIf (troopcarrier() And carrying = "") Or (Inf() And carrying = "") Then
            ground_unit = True
        Else
        End If
    End Function
    Public Sub morale_checks()
        Dim r As Integer = 1000000
        msg = ""
        If strength = 0 Then Exit Sub
        effective = False
        If nuclear_attack Then r = r + 1
        If chemical_attack Then r = r + 10
        If quality <= 3 Then r = r + 100
        If disrupted Then r = r + 1000
        If halfstrength And Not hit Then r = r + 10000
        If halfstrength And hit Then r = r + 100000
        msg = Mid(Trim(Str(r)), 2)
    End Sub
    Public Function status(fm As String)
        status = nostatus
        If comd > 0 And fm = "Morale Recovery" Then
            For Each u As cunit In ph_units
                'If title = "1-115 MRR" Then Stop

                If u.parent = title And Not u.effective And u.ground_unit Then
                    If Val(u.msg) = 0 And Not status = may_test Then
                        status = nostatus
                    ElseIf Val(u.msg) <> 100000 Then
                        status = may_test
                    Else
                        status = must_test
                        Exit Function
                    End If
                End If
            Next
            'If title = "1-115 MRR" Then Stop

        ElseIf comd > 0 Then
            status = nostatus
        ElseIf fm <> "Orbat" And demoralised Then
            status = emcon
            ElseIf comd = 0 Then
            If fm = "Orbat" Then
                If mode = travel Then
                    status = Color.DeepSkyBlue
                ElseIf mode = disp Then
                    status = Color.DarkKhaki
                Else
                End If
            ElseIf fm = "Morale Recovery" Then
                If disrupted And Not effective Then
                    status = disruptedstatus
                ElseIf disrupted And effective Then
                    status = tested_and_disrupted
                ElseIf Val(msg) >= 100000 And Not effective Then
                    status = must_test
                ElseIf Val(msg) > 0 And Not effective Then
                    status = may_test
                ElseIf effective Then
                    status = no_action_pts
                Else
                    status = nostatus
                End If
            ElseIf fm = "movement" Then
                If fires And fired <> gt And moved = gt Then
                    status = half_and_moved
                ElseIf assault Then
                    status = assaulting
                ElseIf support Then
                    status = supporting
                ElseIf fires And fired <> gt Then
                    status = half_fire
                ElseIf moved = gt Then
                    status = moved_now
                Else
                End If

            ElseIf strength <= 0 Then
                status = dead
            ElseIf disrupted Then
                status = disruptedstatus
            ElseIf airborne Or (aircraft() And arrives = gt + 1) Then
                status = take_off
                ElseIf Not eligibleCB And InStr(UCase(eq_list(equipment).special), "E") > 0 Then
                    status = emcon
                ElseIf eligibleCB And InStr(UCase(eq_list(equipment).special), "E") > 0 Then
                    status = can_observe
                ElseIf eligibleCB And indirect() And fm = "T" Then
                    status = can_observe
                ElseIf indirect() And primary <> "" And task = "DS" Then
                    status = in_ds
                ElseIf ooc And fm = "Command" Then
                    status = assaulting
                Else
                    status = nostatus
                End If
            Else
            End If

    End Function
    Public Function pass_quality_test(modi As Integer)
        pass_quality_test = False
        If d10() <= quality + modi Then pass_quality_test = True
    End Function
    Public Sub lands(aborted As Boolean)
        If Not airborne Then Exit Sub
        If equipment Is Nothing Then Exit Sub
        If aborted Then sorties = eq_list(equipment).sortie + 2 Else sorties = eq_list(equipment).sortie + 1
        If InStr(equipment, "-") > 0 Then equipment = Strings.Left(equipment, InStr(equipment, "-") - 1)
        strength = strength + aborts
        If strength <= 0 Then strength = 0
        casualties = 0
        aborts = 0
        airborne = False
        halfstrength = 0
        task = ""
        secondary = ""
    End Sub
    Public Sub reset_air_phase()
        'If aircraft() And loiter() Then
        '    halfstrength = 3
        'ElseIf aircraft() Then
        '    halfstrength = 2
        'ElseIf airdefence() Then
        '    halfstrength = 4
        '    reset_missiles()
        'Else
        '    halfstrength = 0
        'End If
        'If disrupted Or demoralised Then halfstrength = 0
    End Sub
    Public Function missile_armed() As Boolean
        missile_armed = False
        Try
            If eq_list(equipment).payload > 0 Then
                missile_armed = True
            End If
        Catch ex As Exception
        End Try
    End Function
    Public Sub reset_unit()
        ooc = False
        lostcomms = False
        If aircraft() And arrives = gt Then airborne = True : arrives = 0
        If atgw() Then reset_missiles()
        rockets = IIf(helarm, Val(Mid(task, 6, 1)), 0)
        Dim x As Integer = IIf(atgw() And Not heli(), 1, 2)
        'fatigue = strength * 2
        If airdefence() And missile_armed() Then reset_missiles()
        opp_ca = strength * x
        opp_mode = strength * x
        opp_move = strength * x
        hits = 0
        firers_available = strength
        fires = False
        hits = 0
        'hit = False
        aborts = 0
        scoot = False
        casualties = 0
        cas_gt = 0
        'sorties = IIf(aircraft() And sorties > 0, sorties - 1, sorties)
        disrupted_gt = False
        debussed_gt = 0
        reset_helarm()
        assault = False
        support = False
        fire_phase = False
        If airborne Then
            If task = "CAP" Then
                tacticalpts = 3
            Else
                tacticalpts = 1
            End If
        ElseIf (indirect Or airdefence) Then
            If has_moved() Then tacticalpts = eq_list(equipment).e_time Else tacticalpts = 0
        Else
            tacticalpts = 0
        End If
    End Sub

    Public Sub reset_helarm()
        ordnance = False
        hel_atgw = False
        If Not helarm() Then Exit Sub
        If Val(Mid(task, 6, 1)) = 0 Or rockets = 0 Then ordnance = True
        If Val(Mid(task, 4, 1)) = 0 Or missiles = 0 Then hel_atgw = True
    End Sub

    Public Sub reset_missiles()
        missiles = 0
        Try
            If helarm() Then
                missiles = Val(Mid(task, 4, 1))
            Else
                missiles = eq_list(equipment).payload
            End If
        Catch ex As Exception
        End Try

    End Sub
    Public Function check_demoralization() As String
        If initial = 0 Then check_demoralization = "no change" : Exit Function
        Dim result_string As String
        Dim morale As Integer, loss_rate As Integer = Int(100 * casualties / initial), r As Single
        If loss_rate > 80 Then loss_rate = 80
        If loss_rate < 30 Then
            r = 0
        Else
            morale = (quality * 10) + modifier - (-0.0002 * loss_rate ^ 3 + 0.0267 * loss_rate ^ 2 - 0.172 * loss_rate + 6.1)
            r = d100() - morale
        End If
        pre_mode = ""
        If r <= 0 And mode = "regroup" Then
            mode = "mission"
        ElseIf r <= 0 And mode = "defend" Then
            mode = "regroup"
        ElseIf r <= 0 And mode = "withdraw" Then
            mode = "recover"
        ElseIf r <= 0 And mode = "recover" Then
            mode = "regroup"
        ElseIf r > 0 And r <= 50 And mode = "mission" Then
            mode = "defend"
        ElseIf r > 50 And (mode = "mission" Or mode = "defend") Then
            mode = "withdraw"
        Else
            pre_mode = "no change"
        End If
        If pre_mode <> "no change" Then
            If mode = "mission" Then
                result_string = title + vbNewLine + "resumes the mission"
            ElseIf mode = "withdraw" Then
                result_string = title + vbNewLine + "must withdraw for one rout move and regroup"
            ElseIf mode = "recover" Then
                result_string = title + vbNewLine + "is recovering from withdrawing"
            ElseIf mode = "defend" Then
                result_string = title + vbNewLine + "must halt forward movement and adopt a defensive position in place in cover. Where necessary units must withdraw to cover"
            ElseIf u.mode = "regroup" Then
                result_string = title + vbNewLine + "is regrouping before continuing its mission"
            Else
            End If
        Else
            result_string = pre_mode
        End If
        check_demoralization = result_string
    End Function
    Public Sub update_after_firing(opp_firer As Boolean)
        If fires Then
            firers_available = firers_available - firers
            If indirect() Then
                If carrying <> "" Then carrying = ""
                sorties = sorties + 1
            End If
            If heli() Then
                If secondary = "RP" Then
                    rockets = rockets - 1
                    ordnance = True
                ElseIf secondary = "Guns" Then
                    ordnance = True
                Else
                    missiles = missiles - 1
                    hel_atgw = True
                End If
            Else
                If missile_armed() Then missiles = missiles - 1
            End If
            If opp_firer Then
                If movement.tactical_option = 1 Then
                    opp_move = opp_move - firers
                    If opp_move <= strength Then firers_available = opp_move Else firers_available = opp_move - strength
                ElseIf movement.tactical_option = 2 Then
                    opp_ca = opp_ca - firers
                    If opp_ca <= strength Then firers_available = opp_ca Else firers_available = opp_ca - strength
                ElseIf movement.tactical_option >= 3 Then
                    opp_mode = opp_mode - firers
                    If opp_mode <= strength Then firers_available = opp_mode Else firers_available = opp_mode - strength
                Else
                End If
            End If
            If missile_armed() And missiles = 0 Then firers_available = 0
                If helarm() And Val(Mid(task, 6, 1)) > 0 And rockets = 0 And Not opp_firer Then firers_available = 0
                firers = 0
                If firers_available <= 0 Then firers_available = 0
            End If
            msg = ""
        If aircraft() Then
            If hits = 1 And casualties = 0 Then
                strength = strength - 1
                aborts = aborts + 1
            ElseIf hits >= 1 And casualties > 0 Then
                strength = strength - casualties
                casualties = 0
            Else
            End If
            If strength < 0 Then strength = 0
            If strength = 0 Or (fires And sead()) Then lands(False)
        Else
            If strength < firers_available Then firers_available = strength
        End If
        msg = ""
        hits = 0
    End Sub
    Public Sub apply_casualties()
        If ground_unit() And casualties > 0 Then
            If strength - casualties < 0 Then casualties = strength
            update_parent("casualties")
            strength = strength - casualties
            cas_gt = cas_gt + casualties
            If strength / initial <= 0.5 Then halfstrength = True Else halfstrength = False
            If carrying <> "" Then
                With orbat(carrying)
                    .strength = strength
                    .casualties = casualties
                    .mode = mode
                    .cas_gt = cas_gt
                    .disrupted = disrupted
                    .disrupted_gt = disrupted_gt
                End With
            End If
        End If
    End Sub
    Public Sub update_parent(why As String)
        Dim x As Integer = 0
        If InStr(why, "disrupted") > 0 Then
            x = +strength
        ElseIf InStr(why, "rallied") > 0 Then
            x = -strength
        ElseIf why = "destroyed" Then
            x = +strength
        ElseIf why = "casualties" Then
            x = +casualties
        Else
        End If
        orbat(parent).casualties = orbat(parent).casualties + x
        If InStr(why, "rallied") > 0 Then
            orbat(parent).modifier = orbat(parent).modifier + IIf(InStr(why, "HQ") > 0, 4, 2)
        ElseIf InStr(why, "routed") > 0 Or why = "failed CA" Then
            orbat(parent).modifier = orbat(parent).modifier - 5
        ElseIf why = "successful CA" Then
            orbat(parent).modifier = orbat(parent).modifier + 5
        ElseIf InStr(why, "inflicted") > 0 Then
            orbat(parent).modifier = orbat(parent).modifier + Val(Mid(why, 10))
        Else

        End If
    End Sub
    Public Function opp_fire_available() As Boolean
        opp_fire_available = False
        If movement.tactical_option = 1 Then
            If opp_move > strength Then opp_fire_available = True
        ElseIf movement.tactical_option = 2 Then
            If opp_ca > strength Then opp_fire_available = True
        ElseIf movement.tactical_option >= 3 Then
            If opp_mode > strength Then opp_fire_available = True
        Else
        End If
    End Function
    Public Sub set_opp_fire_available()
        If firers_available = 0 Then
            If movement.tactical_option = 1 Then
                If opp_move <= strength Then firers_available = opp_move Else firers_available = opp_move - strength
            ElseIf movement.tactical_option = 2 Then
                If opp_ca <= strength Then firers_available = opp_ca Else firers_available = opp_ca - strength
            ElseIf movement.tactical_option >= 3 Then
                If opp_mode <= strength Then firers_available = opp_mode Else firers_available = opp_mode - strength
            Else
                firers_available = 0
            End If
        End If
    End Sub
    Public Function valid_arty_observer(obs As cunit)
        valid_arty_observer = False
        If obs.indirect Then
            If parent = obs.primary Then
                valid_arty_observer = True
            ElseIf primary = obs.primary And task = "DS" Then
                valid_arty_observer = True
            ElseIf primary = obs.parent And task = "DS" Then
                valid_arty_observer = True
            Else
            End If
        Else
            If parent = obs.parent Then
                valid_arty_observer = True
            ElseIf primary = obs.parent And task = "DS" Then
                valid_arty_observer = True
            ElseIf primary = obs.primary And obs.task = "DS" Then
                valid_arty_observer = True
            ElseIf parent = obs.primary And obs.task = "DS" Then
                valid_arty_observer = True
            Else
            End If
        End If
    End Function
    Public Function validunit(ByVal phase As String, ByVal hq As String) As Boolean
        validunit = False
        'If Not (arrives = "" Or arrives = "25") And comd = 0 And phase <> "Orbat" Then Exit Function
        'If title = "SAM/1-115 MRR" Then Stop
        'If indirect() And nation = hq Then Stop
        If comd > 0 Then
            If phase = "Command" Or phase = "Observee" Then
                validunit = True
            ElseIf phase = "Orbat" And hq = parent Then
                validunit = True
            ElseIf phase = "Demoralisation" And demoralised Then
                validunit = True
            ElseIf phase = "Movement" And hq = parent And Not demoralised Then
                validunit = True
            ElseIf phase = "Air Tasking" And hq = parent And Not demoralised And primary = "Air units" Then
                validunit = True
            ElseIf InStr("Arty Tasking", phase) > 0 And hq = parent And Not demoralised And carrying = "Arty units" Then
                validunit = True
            ElseIf phase = "Observer" And hq = "" And Not demoralised And carrying = "Arty units" And arty_int > 0 Then
                validunit = True
            ElseIf phase = "Arty Support" And divisional_comd(Me) = hq Then
                validunit = True
            ElseIf phase = "Morale Recovery" And hq = parent Then
                validunit = True
            Else
                validunit = False
            End If
        ElseIf strength = 0 Then
            validunit = False
        ElseIf phase = "Select Air Unit" And Not disrupted And aircraft() And Not airborne And sorties = 0 And (arrives = 0 Or (arrives = gt + 1 And (task = "Observation" Or task = "DS"))) Then
            validunit = True
        ElseIf phase = "CAP Combat" And task = "CAP" And airborne And arrives = 0 Then
            If (hq = "firer" And tacticalpts > 1) Or hq = "" Then validunit = True
        ElseIf phase = "ADSAM Fire" And Not disrupted And emplaced And area_air_defence() Then
            validunit = True
        ElseIf phase = "Intercept" And arrives = 0 And airborne And task = "CAP" And tacticalpts > 0 Then
            validunit = True
        ElseIf phase = "Intercept Targets" And airborne And task <> "CAP" And arrives = 0 Then
            validunit = True
        ElseIf phase = "Select Unit" And Not disrupted Then
            validunit = True
        ElseIf (phase = "Orbat" And hq = parent) Then
            validunit = True
        ElseIf phase = "Command" And (hq = parent Or hq = primary) And Not ((Inf() And embussed()) Or (aircraft() And sorties > 0)) Then
            validunit = True
        ElseIf phase = "Direct Fire" And arrives = 0 And Not disrupted And Not demoralised And firers_available > 0 And Not has_fired() And Not airdefence() And (Not aircraft() Or (airborne And heli())) And Not (embussed() And Inf()) Then
            validunit = True
        ElseIf phase = "Opportunity Fire" And arrives = 0 And Not disrupted And Not demoralised And Not airdefence() And (Not aircraft() Or (airborne And heli())) And Not (embussed() And Inf()) Then
            If (movement.tactical_option = 1 And opp_move > 0) Or (movement.tactical_option = 2 And opp_ca > 0) Or (movement.tactical_option >= 3 And opp_mode > 0) Then
                set_opp_fire_available()
                validunit = True
            Else
                validunit = False
            End If
        ElseIf phase = "Opportunity AA Fire" And opp_move > 0 And arrives = 0 And Not disrupted And (Not missile_armed() Or (missile_armed() And missiles > 0)) And Not demoralised And airdefence() And Not (embussed() And Inf()) Then
            validunit = True
        ElseIf phase = "CA Defenders" And arrives = 0 Then
            If ground_unit() Then validunit = True
        ElseIf phase = "CA Supports" And arrives = 0 And Not disrupted And Not demoralised And Not airdefence() And Not (embussed() And Inf()) And Not assault And Not support Then
            If ground_unit() And title <> My.Forms.assault.attacker.title Then validunit = True
        ElseIf phase = "Smoke Barrage" And Not disrupted And Not demoralised And firers_available > 0 And indirect() And gt - smoke >= 4 And emplaced Then
            validunit = True
        ElseIf phase = "Indirect Fire" And indirect() And emplaced() And Not disrupted And firers_available > 0 Then
            If indirect() And emplaced() Then
                If orbat(parent).ooc Or orbat(orbat(parent).title).ooc Then
                    validunit = False
                Else
                    validunit = True
                End If
            End If
        ElseIf phase = "Artillery Support" And indirect() And emplaced() And Not disrupted And Not support Then
            If parent = hq Or (primary = hq And task = "DS") Then
                If orbat(parent).ooc Or orbat(orbat(parent).title).ooc Then validunit = False Else validunit = True
            End If
        ElseIf phase = "Observers" And Not disrupted And Not demoralised And Not lostcomms And observer() And (arrives = 0 Or role = "|Comd|") Then
            If orbat(parent).ooc Or orbat(orbat(parent).title).ooc Then validunit = False Else validunit = True
        ElseIf phase = "Smoke Observers" And Not disrupted And Not demoralised And Not lostcomms And observer() And arrives = 0 And role = "|Comd|" Then
            If orbat(parent).ooc Or orbat(orbat(parent).title).ooc Then validunit = False Else validunit = True
        ElseIf phase = "Ground to Air" And airdefence() And Not disrupted And emplaced And (Not missile_armed() Or (missile_armed() And missiles > 0)) Then
            validunit = True
        ElseIf phase = "Air to Ground" And arrives = 0 And airborne And Airground() And Not sead() And tacticalpts > 0 And Not heli() Then
            validunit = True
        ElseIf phase = "Air Defence Targets" And arrives = 0 And airborne And task <> "CAP" Then
            validunit = True
            'ElseIf strength <= 0 Or (aircraft() And strength - aborts <= 0) Then
            '    validunit = False
        ElseIf phase = "Movement" And (ground_unit() Or (heli() And airborne)) And Not demoralised And Not disrupted And parent = hq And arrives = 0 And (Not fire_phase Or (fire_phase And scoot) Or (fire_phase And helarm())) Then
            validunit = True
        ElseIf phase = "Morale Recovery" And ground_unit() And parent = hq Then
            validunit = True
        ElseIf phase = "CB Targets" And indirect() And fired = gt And Not scoot Then
            validunit = True
        ElseIf phase = "Ground Targets" And ground_unit() And arrives = 0 Then
            validunit = True
        ElseIf phase = "Off Table Targets" And ground_unit() And arrives > 0 Then
            validunit = True
        ElseIf phase = "Air Tasking" Then
            If parent = hq And Not airborne And sorties = 0 And aircraft() Then validunit = True
        ElseIf phase = "Arty Tasking" Then
            If indirect() Then
                If (parent = hq Or primary = hq) And Not disrupted And emplaced() Then validunit = True
            End If
        ElseIf phase = "SEAD" Then
            If sead() Then validunit = True
        ElseIf phase = "Air to Air" Then
            If airborne And task <> "CAP" Then validunit = True
        ElseIf phase = "Deploy Aircraft" Then
            If airborne Then validunit = True
        Else
        End If
    End Function
    Public Sub set_fire_parameters()
        result = 0
        msg = ""
        modifier = 0
        effect = 0
        hits = 0
        effective = False
        lostcomms = False
    End Sub
    Public Function return_fire_strength(mode As Integer) As Integer
        return_fire_strength = 0
        If airborne Then return_fire_strength = strength - aborts : Exit Function
        Select Case mode
            Case 1 : If fatigue - 2 > strength Then return_fire_strength = fatigue - strength Else return_fire_strength = strength
            Case 4 To 9 : If opp_ca - 2 > strength Then return_fire_strength = opp_ca - strength Else return_fire_strength = strength
            Case 3 : If opp_mode - 2 > strength Then return_fire_strength = opp_mode - strength Else return_fire_strength = strength
            Case 0, 2 : If opp_move - 2 > strength Then return_fire_strength = opp_move - strength Else return_fire_strength = strength
        End Select
    End Function
    Public Function capable_of_abort(firer As String) As Boolean
        capable_of_abort = False
        If Not equipment Is Nothing Then
            If eq_list(equipment).miss_def >= eq_list(firer).aam Then
                capable_of_abort = True
            ElseIf eq_list(equipment).miss_def >= eq_list(firer).aam_close Then
                capable_of_abort = True
            ElseIf eq_list(equipment).gun_def >= eq_list(firer).cannon Then
                capable_of_abort = True
            Else
            End If

        End If
    End Function

    Public Function has_moved() As Boolean
        has_moved = False
        If gt - moved <= 1 Then has_moved = True
    End Function
    Public Function has_fired() As Boolean
        has_fired = False
        If helarm() And (Not ordnance Or Not hel_atgw) Then
        ElseIf gt - fired = 0 Then
            has_fired = True
        Else
        End If
    End Function
    Public Function has_moved_fired() As Boolean
        has_moved_fired = False
        If moved = gt And fired = gt Then has_moved_fired = True
    End Function
    Public Function hvy_loss(before_test As Boolean) As Boolean
        hvy_loss = False
        If airborne Then Exit Function
        If Not before_test Then
            If (hits > 2 And mode = disp) Or (hits - 1 > 2 And mode <> disp) Or casualties + IIf(mode <> disp, -1, 0) >= 4 Then hvy_loss = True
        Else
            If hits > 2 Or casualties >= 4 Then hvy_loss = True
        End If
    End Function
    Public Function destroyed() As Boolean
        'checks generate fire message for the word destroyed
        destroyed = False
        If InStr(msg, "destroyed") > 0 Or casualties > strength Then destroyed = True
    End Function

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function


End Class
