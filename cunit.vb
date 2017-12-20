Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable()> Public Class cunit
    Implements ICloneable
    Private pTitle As String
    Private pcomd As Integer
    Private pnation As String
    Private pquality As Integer
    Private pequipment As String
    Private pinitial As Integer
    Private paborts As Integer
    Private pcomdpts As Integer
    Private ptacticalpts As Integer
    Private pstrength As Integer
    Private pmode As String
    Private pelevated As Boolean
    Private proadmove As Boolean
    Private pmoving As Boolean
    Private pdisordered As Boolean
    Private pdisrupted As Boolean
    Private pcover As Integer
    Private ploaded As String
    Private pmoved As Integer
    Private pfired As Integer
    Private phit As Boolean
    Private pparent As String
    Private pno_of_units As Integer
    Private psorties As Integer
    Private pflanked As Boolean
    Private prear As Boolean
    Private pdemoralised As Boolean
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
    Private psort As String
    Private pspotted As Boolean
    Private peffective As Boolean
    Private peffect As Integer
    Private pfires As Boolean
    Private pmsg As String
    Private pstatusimpact As Integer
    Private pmodifier As Integer
    Private presult As Integer
    Private psupport As Boolean
    Private passault As Boolean
    Private pmissiles As Integer
    Private plostcomms As Boolean
    Private popp_return As Integer
    Private popp_move As Integer
    Private popp_mode As Integer
    Private popp_ca As Integer
    Private pdebussed As Boolean
    Private party_int As Integer
    Private pooc As Boolean


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
    Property loaded() As String
        Get
            Return ploaded
        End Get
        Set(ByVal Value As String)
            ploaded = Value
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
    Property debussed() As Boolean
        Get
            Return pdebussed
        End Get
        Set(ByVal Value As Boolean)
            pdebussed = Value
        End Set
    End Property

    Property disordered() As Boolean
        Get
            Return pdisordered
        End Get
        Set(ByVal Value As Boolean)
            pdisordered = Value
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
    Property moving() As Boolean
        Get
            Return pmoving
        End Get
        Set(ByVal Value As Boolean)
            pmoving = Value
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
    Property statusimpact() As Integer
        Get
            Return pstatusimpact
        End Get
        Set(ByVal Value As Integer)
            pstatusimpact = Value
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
    Property no_of_units() As Integer
        Get
            Return pno_of_units
        End Get
        Set(ByVal Value As Integer)
            pno_of_units = Value
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
    Property tacticalpts() As Integer
        Get
            Return ptacticalpts
        End Get
        Set(ByVal Value As Integer)
            ptacticalpts = Value
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
    Property opp_return() As Integer
        Get
            Return popp_return
        End Get
        Set(ByVal Value As Integer)
            popp_return = Value
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
    Property sort() As String
        Get
            Return psort
        End Get
        Set(ByVal Value As String)
            psort = Value
        End Set
    End Property


    Public Function w2()
        If CorpsComd.equipment(Me.equipment).weapon_2 = "" Then w2 = "" : Exit Function
        w2 = CorpsComd.equipment(Me.equipment).weapon_2
    End Function

    Public Function indirect()
        indirect = False
        If InStr("|ARTY|RL|MOR|", role) > 0 Then indirect = True
    End Function

    Public Function role()
        If equipment Is "" Or equipment Is Nothing Then
            role = "XX"
        Else
            role = CorpsComd.equipment(Me.equipment).role
        End If
    End Function

    Public Function observer()
        If indirect() Or (task = "CAS" Or task = "Strike") Then observer = True Else observer = False
    End Function
    Public Function root()
        If parent = "root" Then root = True Else root = False
    End Function
    Public Function troopcarrier() As Boolean
        troopcarrier = False
        If InStr("|MICV|APC|", role) > 0 Then troopcarrier = True
    End Function
    Public Function embussed() As Boolean
        embussed = False
        If Not debussed And troopcarrier() And loaded <> "" Then embussed = True
    End Function
    Public Function dismounted()
        dismounted = False
        If Inf() And debussed And loaded = "" Then dismounted = True
    End Function
    Public Function loiter()
        loiter = False
        If InStr("|A10|SU25|Harrier-GR8|", equipment) > 0 Then loiter = True
    End Function
    Public Function atgw()
        atgw = False
        If InStr(role, "ATGW") > 0 Or (role() = "AH" And pairborne) Then atgw = True
    End Function
    Public Function airdefence()
        airdefence = False
        If InStr("|PDSAM|InfSAM|ADSAM|AAA|", role) > 0 Then airdefence = True
    End Function

    Public Function radar()
        If (CorpsComd.equipment(Me.equipment).role = "PDSAM" Or CorpsComd.equipment(Me.equipment).role = "ADSAM") And InStr(UCase(CorpsComd.equipment(Me.equipment).special), "E") > 0 Then radar = True Else radar = False
    End Function

    Public Function Airsuperiority()
        If airborne And (task = "CAP" Or task = "EW Support") Then Airsuperiority = True Else Airsuperiority = False
    End Function
    Public Function sead()
        If task = "SEAD" And airborne Then sead = True Else sead = False
    End Function

    Public Function Airground()
        If ptask = "CAS" Or ptask = "Strike" Or ptask = "SEAD" Then Airground = True Else Airground = False
    End Function
    Public Function Aircraft()
        Aircraft = False
        If InStr("|AC|AH|OH|TB|AD|GA|AWACS|EW|", "|" + Trim(role) + "|") > 0 Then Aircraft = True
    End Function
    Public Function hels()
        hels = False
        If InStr("|AH|OH|UH|TH|", "|" + Trim(role) + "|") > 0 And airborne Then hels = True
    End Function
    Public Function heli()
        heli = False
        If InStr("|AH|OH|UH|TH|", "|" + Trim(role) + "|") > 0 Then heli = True
    End Function
    Public Function Inf()
        Inf = False
        If InStr(role(), "Inf") > 0 Then Inf = True
    End Function
    Public Function cae(armd As Boolean)
        If armd Then
            cae = CorpsComd.equipment(equipment).cae
        Else
            cae = CorpsComd.equipment(equipment + "soft").cae
        End If

    End Function
    Public Function afv()
        afv = False
        If InStr("|MICV|TANK|", role) > 0 Then afv = True
    End Function
    Public Function armour()
        armour = False
        If CorpsComd.equipment(equipment).defence > 0 Then armour = True
    End Function

    Public Function hq()
        If Me.comd > 0 Then hq = True : Exit Function
        If role() = "HQ" Then hq = True Else hq = False
    End Function
    Public Function nondetect()
        If airdefence() Or Airsuperiority() Or task = "SEAD" Then nondetect = True Else nondetect = False
    End Function
    Public Function text_status()
        text_status = ""
        If demoralised Then
            text_status = "- Demoralised"
        ElseIf strength = 0 And comd = 0 Then
            text_status = "- Destroyed"
        ElseIf disrupted Then
            text_status = "- Routing"
        ElseIf disordered Then
            text_status = "- Disordered"
        ElseIf moved Then
            text_status = "- Moving"
        ElseIf hit Then
            text_status = "- Under Fire " + IIf(pcover > 0, "in cover +" + Trim(Str(pcover)), "")
        Else
            text_status = "- Static " + IIf(pcover > 0, "in cover +" + Trim(Str(pcover)), "")
        End If
    End Function
    Public Sub set_fire_effect(target As cunit, r As Integer, stage As Integer)
        Dim context As String = "", armd As Boolean
        Dim max_range As Integer = CorpsComd.equipment(equipment).max
        If airdefence() And target.airborne Then
            context = "AD"
        ElseIf airborne And target.airborne Then
            context = "AS"
        ElseIf InStr(equipment, "SEAD") > 0 Then
            context = "SEAD"
            max_range = 20000
        ElseIf InStr(equipment, "GA") > 0 Then
            context = "GA"
            max_range = 2000
        ElseIf InStr(equipment, "SO") > 0 Then
            context = "SO"
            If CorpsComd.equipment(target.equipment).standoff_range = "s" Then
                max_range = 10000
            ElseIf CorpsComd.equipment(target.equipment).standoff_range = "m" Then
                max_range = 20000
            Else
                max_range = 40000
            End If
        ElseIf CorpsComd.equipment(target.equipment).defence > 0 Then
            armd = True
        ElseIf CorpsComd.equipment(target.equipment).defence = 0 Then
            armd = False
        Else
        End If


        If Not context = "AS" And r > max_range Then effect = 0 : Exit Sub

        If context = "SEAD" Then
            effect = CorpsComd.equipment(equipment).standoff
            If r > max_range / 2 Then target.modifier = 1
        ElseIf context = "GA" Then
            If stage = 0 Then
                effect = CorpsComd.equipment(equipment).ordnance
            Else
                effect = CorpsComd.equipment(equipment).cannon
            End If
        ElseIf context = "AS" Then
            If stage = 0 Then
                effect = CorpsComd.equipment(equipment).air_to_air_effect
                If role() = "TB" And Not target.hels Then effect = Int(effect / 3)
            ElseIf stage = 1 Then
                effect = CorpsComd.equipment(equipment).aam
                CorpsComd.equipment(target.equipment).defence = CorpsComd.equipment(target.equipment).miss_def
            ElseIf stage = 2 Then
                effect = CorpsComd.equipment(equipment).aam_close
            Else
                effect = CorpsComd.equipment(equipment).cannon
                CorpsComd.equipment(target.equipment).defence = CorpsComd.equipment(target.equipment).gun_def
                If role() = "TB" And Not target.hels Then effect = Int(effect / 3)
            End If
        ElseIf context = "AD" Then
            If r / CorpsComd.equipment(equipment).max > 0.667 Or (r / CorpsComd.equipment(equipment).max > 0.5 And role() = "AAA") Then
                effect = CorpsComd.equipment(equipment).full
                If InStr(radar, "M") > 0 And Not eligibleCB Then effect = -1
            ElseIf r / CorpsComd.equipment(equipment).max > 0.333 Or role = "AAA" Then
                effect = CorpsComd.equipment(equipment).twothird
                If InStr(radar, "E") > 0 And Not eligibleCB Then effect = -1
            Else
                effect = CorpsComd.equipment(equipment).onethird
                If InStr(radar, "C") > 0 And Not eligibleCB Then effect = -1
            End If
            If (target.mode = "Low" Or target.mode = "Very Low") Then
                modifier = CorpsComd.equipment(equipment).low
            ElseIf target.mode = "Medium" Then
                modifier = CorpsComd.equipment(equipment).medium
            Else
                modifier = CorpsComd.equipment(equipment).high
            End If
            If modifier = 9 And effect > 0 Then
                modifier = 0
                effect = -2
            ElseIf modifier = 9 And effect = -1 Then
                modifier = 0
                effect = -3
            ElseIf effect = -1 Then
                modifier = 0
                effect = -1
            Else
            End If
        ElseIf Not indirect() Or (indirect() And spotted) Then
            Dim j As Integer = 0, weapon As String = ""
            If w2() = "" Then weapon = equipment Else weapon = equipment + w2()
            effect = 0
            For i As Integer = 1 To 2
                If Not armd And Not CorpsComd.equipment.Contains(weapon + "soft") Then Exit For
                If Not armd Then weapon = weapon + "soft"
                Select Case r
                    Case 300
                        j = CorpsComd.equipment(weapon).R300
                    Case 600
                        j = CorpsComd.equipment(weapon).R600
                    Case 1000
                        j = CorpsComd.equipment(weapon).R1000
                    Case 1500
                        j = CorpsComd.equipment(weapon).R1500
                    Case 2000
                        j = CorpsComd.equipment(weapon).R2000
                    Case 2500
                        j = CorpsComd.equipment(weapon).R2500
                    Case 3000
                        j = CorpsComd.equipment(weapon).R3000
                    Case 4000
                        j = CorpsComd.equipment(weapon).R4000
                End Select
                If loaded = "" Then
                    Exit For
                ElseIf Inf() And debussed And i = 1 Then
                    effect = j
                    weapon = orbat(loaded).equipment
                ElseIf Inf() And debussed And i = 2 Then
                    j = Int(j / 2)
                    weapon = orbat(loaded).equipment
                ElseIf troopcarrier() And Not debussed And i = 1 Then
                    effect = j
                    If armd Then Exit For
                    weapon = orbat(loaded).equipment
                ElseIf troopcarrier() And Not debussed And i = 2 And r <= 300 Then
                    j = j / 3
                Else
                End If
            Next
            effect = effect + j
        ElseIf indirect() And Not spotted Then
            If r / CorpsComd.equipment(equipment).max > 0.667 Then
                effect = CorpsComd.equipment(equipment).indirect_m
            Else
                effect = CorpsComd.equipment(equipment).indirect_e
            End If
        Else
            effect = 0
        End If
    End Sub
    Public Function composite()
        composite = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "C") > 0 Then composite = True
    End Function
    Public Function heat()
        heat = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "H") > 0 Then heat = True
    End Function
    Public Function heavy_fire()
        heavy_fire = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "Y") > 0 Then heavy_fire = True
    End Function
    Public Function bomblets()
        bomblets = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "X") > 0 Then bomblets = True
    End Function

    Public Function spaced()
        spaced = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "S") > 0 Then spaced = True
    End Function
    Public Function stabilised()
        stabilised = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "B") > 0 Then stabilised = True
    End Function
    Public Function recon()
        recon = False
        If role() = "RECON" Then recon = True
    End Function
    Public Function size()
        size = CorpsComd.equipment(equipment).size
    End Function
    Public Function soft_tpt()
        soft_tpt = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "V") > 0 Then soft_tpt = True
    End Function
    Public Function not_conc()
        not_conc = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "D") > 0 Then not_conc = True
    End Function
    Public Function smoke_discharger()
        smoke_discharger = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "P") > 0 Then smoke_discharger = True
    End Function
    Public Function smoke_generator()
        smoke_generator = False
        If InStr(UCase(CorpsComd.equipment(equipment).special), "G") > 0 Then smoke_generator = True
    End Function
    Public Function arty_hq()
        arty_hq = False
        If comd >= 4 Then
            arty_hq = True
        ElseIf comd >= 1 And InStr(LCase(title), "arty") > 0 Then
            arty_hq = True
        Else
        End If
    End Function
    Public Function emplaced()
        Dim x As Integer
        emplaced = False
        If indirect() And mode = disp Then
            If moved = -1 Then emplaced = True : Exit Function
            sorties = 0
            If InStr(CorpsComd.equipment(equipment).special, "2") > 0 Then
                sorties = 2
            ElseIf InStr(CorpsComd.equipment(equipment).special, "1") > 0 Then
                sorties = 1
            Else
            End If
            If InStr(UCase(CorpsComd.equipment(equipment).special), "L") = 0 Then sorties = sorties - 1
            x = Val(scenariodefaults.gameturn.Text) - moved + sorties
            If (orbat(parent).comd - 2) - x <= 0 Then emplaced = True
        End If
    End Function
    Public Function ground_unit()
        ground_unit = False
        If Aircraft() Or comd > 0 Then Exit Function
        ground_unit = True
        If troopcarrier() And debussed And loaded <> "" Then
            ground_unit = False
        ElseIf Inf() And Not debussed Then
            ground_unit = False
        ElseIf (troopcarrier And debussed And loaded = "") Or (Inf And debussed And loaded = "") Then
            ground_unit = True
        Else
        End If
    End Function
    Public Function validunit(ByVal phase As String, ByVal hq As String)
        validunit = False
        If comd > 0 Then
            If phase = "Command" Or phase = "Observee" Then
                validunit = True
            ElseIf phase = "Orbat" And hq = parent Then
                validunit = True
            ElseIf phase = "Demoralisation" And demoralised Then
                validunit = True
            ElseIf phase = "Fire and Movement" And hq = parent And Not demoralised Then
                validunit = True
            ElseIf phase = "Air Tasking" And hq = parent And Not demoralised And primary = "Air units" Then
                validunit = True
            ElseIf InStr("Arty TaskingArea Fire", phase) > 0 And hq = parent And Not demoralised And loaded = "Arty units" Then
                validunit = True
            ElseIf phase = "CB Fire" And hq = parent And Not demoralised And loaded = "Arty units" And arty_int > 0 Then
                validunit = True
            ElseIf phase = "Observer" And hq = "" And Not demoralised And loaded = "Arty units" And arty_int > 0 Then
                validunit = True
            ElseIf phase = "Arty Support" And divisional_comd(Me) = hq Then
                validunit = True
            ElseIf phase = "Morale Recovery" And hq = parent Then
                validunit = True
            Else
                validunit = False
            End If
        ElseIf phase = "Orbat" And hq = parent Then
            validunit = True
        ElseIf strength <= 0 Or (Aircraft() And strength - aborts <= 0) Then
            validunit = False
        ElseIf phase = "Transport" Then
            If troopcarrier() And loaded = "" And parent = hq Then validunit = True
        ElseIf phase = "Fire and Movement" Then
            If Not ground_unit() And Not hels() Then
                validunit = False
            ElseIf demoralised Then
                validunit = False
            ElseIf parent = hq Then
                validunit = True
                'ElseIf coc(hq, Me, comd) Then
                '    validunit = True
            Else
            End If
        ElseIf phase = "CA Defenders" Then
            If ground_unit() Then validunit = True
        ElseIf phase = "Morale Recovery" Then
            If ground_unit() And coc(hq, Me, comd) And strength > 0 Then validunit = True
        ElseIf phase = "Area Fire" Then
            If indirect() And task = "AF" Then validunit = True
        ElseIf phase = "CB Fire" Then
            If indirect() And task = "CB" Then validunit = True
        ElseIf phase = "CB Targets" Then
            If eligibleCB Then validunit = True
        ElseIf phase = "Transport" Then
            If parent = hq And loaded = "" And Not disrupted Then validunit = True
        ElseIf phase = "Air Tasking" Then
            If parent = hq And Not airborne And sorties > 0 And Aircraft() Then validunit = True
        ElseIf phase = "Observing" Then
            If parent = hq And Not disrupted Then validunit = True
        ElseIf phase = "Observer" Then
            If Not disrupted And Not disordered And Not demoralised And Not lostcomms And (ground_unit() Or hels()) And tacticalpts >= 2 Then
                If orbat(parent).ooc Or orbat(orbat(parent)).ooc Then
                    validunit = False
                Else
                    If parent = hq Or (primary = hq And hels()) Then
                        statusimpact = 0
                    ElseIf orbat(parent).parent = hq Then
                        statusimpact = 1
                    Else
                        statusimpact = 2
                    End If
                    validunit = True
                End If
            End If
        ElseIf phase = "Arty Tasking" Then
            If (parent = hq Or primary = hq) And Not disrupted And emplaced() Then validunit = True
        ElseIf phase = "SEAD" Then
            If sead() Then validunit = True
        ElseIf phase = "SEAD Targets" Then
            If airdefence() And Not Aircraft() Then validunit = True
        ElseIf phase = "CAP Missions" Then
            If airborne And Airsuperiority() Then validunit = True
        ElseIf phase = "Deploy Aircraft" Then
            If airborne Then validunit = True
        ElseIf phase = "Abort Aircraft" And task = "Abort" Then
            validunit = True : task = ""
        ElseIf phase = "Radar On" Then
            If airdefence() And radar() Then validunit = True
        ElseIf phase = "Air Defence" Then
            If airdefence() Then
                If CorpsComd.phase = 8 Then
                    If CorpsComd.equipment(equipment).Max >= 30000 Then validunit = True Else validunit = False
                Else
                    validunit = True
                End If
            End If
        ElseIf phase = "SEAD Defence Targets" Then
            If airborne And Not heli() And task = "SEAD" Then validunit = True
        ElseIf phase = "Air Defence Targets" Then
            If airborne And Not heli() And Airground() Then validunit = True
        ElseIf phase = "CAP Targets" Then
            If airborne And task = "CAP" And strength - aborts > 0 Then validunit = True
        ElseIf phase = "Air Ground" Then
            If airborne And Airground() Then validunit = True
        ElseIf phase = "Ground Attack Targets" And ground_unit() Then
            validunit = True
        ElseIf phase = "Air Targets" Then
            If Aircraft() And airborne And Not heli() And task <> "CAP" Then validunit = True
        ElseIf phase = "Ground Targets" Then
            If ground_unit() Then validunit = True
        ElseIf phase = "Opportunity Fire" Then
            If ((ground_unit() And Not indirect() And Not movement.mover.heli) Or
                (indirect() And task = "IN") Or
                (airdefence() And movement.mover.heli And (Not missile_armed(equipment) Or (missile_armed(equipment) And missiles > 0)))) _
                    And Not (disordered Or disrupted Or demoralised) Then
                If ((movement.tactical = 0 Or movement.tactical = 2) And opp_move > 0) Or (movement.tactical = 3 And opp_ca > 0) Or (movement.tactical >= 4 And opp_mode > 0) Then validunit = True
            End If
        Else
        End If
    End Function
    Public Function status()
        status = nostatus
        If comd > 0 And ooc Then
            status = no_action_pts
        ElseIf demoralised Then
            status = demoralisedstatus
        ElseIf comd = 0 Then
            If disrupted Then
                status = disruptedstatus
            ElseIf disordered Then
                status = disorderedstatus
            ElseIf comd = 0 And strength <= 0 Then
                status = dead
            ElseIf assault Then
                status = assaulting
            ElseIf comd = 0 And tacticalpts = 0 Then
                status = no_action_pts
            ElseIf airborne Then
                status = take_off
            ElseIf statusimpact = 1 Then
                status = can_observe
            ElseIf (primary <> "" And task = "DS") Then
                status = in_ds
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
        If aborted Then sorties = scenariodefaults.gameturn.Text + 1 Else sorties = CorpsComd.equipment(equipment).sortie
        strength = strength - casualties
        If strength <= 0 Then strength = 0
        casualties = 0
        aborts = 0
        airborne = False
        task = ""
        primary = ""
    End Sub
    Public Sub reset_air_phase()
        If Aircraft() And loiter() Then
            tacticalpts = 3
        ElseIf Aircraft() Then
            tacticalpts = 2
        ElseIf airdefence() Then
            tacticalpts = 4
            reset_missiles()
        Else
            tacticalpts = 0
        End If
        If disrupted Or demoralised Then tacticalpts = 0
    End Sub
    Public Function missile_armed(weapon As String)
        missile_armed = False
        If InStr(CorpsComd.equipment(weapon).special, "1") + InStr(CorpsComd.equipment(weapon).special, "2") + InStr(CorpsComd.equipment(weapon).special, "3") > 0 Then missile_armed = True
    End Function
    Public Sub reset_fire_phase(phasing As String)
        ooc = False
        If nation = phasing Then
            If Not (indirect() And fired = gt) Then tacticalpts = 4
            lostcomms = False
            If atgw() Then reset_missiles()
        Else
            opp_return = strength * 2
            opp_ca = strength * 2
            opp_mode = strength * 2
            opp_move = strength * 2
        End If
        If airdefence() Then
            If nation = phasing Then tacticalpts = comdpts Else tacticalpts = Int((comdpts + 1) / 2)
        End If
        hits = 0
    End Sub
    Public Sub reset_missiles()
        If InStr(CorpsComd.equipment(equipment).special, "1") > 0 Then
            missiles = 1
        ElseIf InStr(CorpsComd.equipment(equipment).special, "2") > 0 Then
            missiles = 2
        ElseIf InStr(CorpsComd.equipment(equipment).special, "3") > 0 Then
            missiles = 3
        Else
            missiles = 0
        End If
    End Sub
    Public Sub set_fire_parameters()
        result = 0
        msg = ""
        modifier = 0
        effect = 0
        effective = False
        lostcomms = False
    End Sub
    Public Function return_fire_strength(mode As Integer)
        return_fire_strength = 0
        Select Case mode
            Case 1 : If opp_return - 2 > strength Then return_fire_strength = opp_return - strength Else return_fire_strength = strength
            Case 4 To 9 : If opp_ca - 2 > strength Then return_fire_strength = opp_ca - strength Else return_fire_strength = strength
            Case 3 : If opp_mode - 2 > strength Then return_fire_strength = opp_mode - strength Else return_fire_strength = strength
            Case 0, 2 : If opp_move - 2 > strength Then return_fire_strength = opp_move - strength Else return_fire_strength = strength
        End Select
    End Function
    Public Sub update_after_firing(phasing As String, weapon As String, finished As Boolean)
        Dim i As Integer = 0
        If fires Then
            If Aircraft() And finished Then
                i = 1
            ElseIf finished And phasing = nation And movement.scoot Then
                i = 4
            ElseIf phasing = nation And finished Then
                i = 2
            ElseIf Not phasing = nation Then
                If Not oppfire Then
                    opp_return = opp_return - firers - (casualties * 2)
                ElseIf oppfire And (movement.tactical = 0 Or movement.tactical = 2) Then
                    opp_move = opp_move - firers
                ElseIf oppfire And movement.tactical = 3 Then
                    opp_ca = opp_ca - firers
                ElseIf oppfire And movement.tactical >= 4 Then
                    opp_mode = opp_mode - firers
                Else
                End If
            Else
            End If
            If Not Aircraft() Then fired = gt Else fired = CorpsComd.phase
            tacticalpts = tacticalpts - i
            'If indirect() And movement.tactical = 1 Then eligibleCB = True
            If missile_armed(weapon) Then missiles = missiles - 1
        End If
        msg = ""
        If Aircraft() Then
            strength = strength - casualties : casualties = 0
            If strength < 0 Then strength = 0
            If strength = 0 Then msg = title + "(" + equipment + ")" + " has been destroyed"
            If strength > 0 And strength - aborts <= 0 Then msg = title + "(" + equipment + ")" + " aborts air mission"
            If strength - aborts <= 0 Or strength = 0 Or (fires And sead()) Then lands(False)
        ElseIf (strength - casualties <= 0) Then
            msg = title + " has been destroyed"
            strength = 0
            casualties = 0
            hits = 0
        Else
            msg = ""
            If casualties > 2 Or hits >= 4 Or statusimpact = 1 Then
                With morale_test
                    .Tag = "Immediate"
                    .tester = Me
                    .ShowDialog()
                    .Tag = ""
                End With
            End If
            strength = strength - casualties
            casualties = 0
            statusimpact = 0
        End If
        If msg <> "" Then
            With resultform
                .result.Text = msg
                .ShowDialog()
            End With
        End If
        If loaded <> "" Then orbat(loaded).strength = strength
    End Sub
    Public Function has_moved()
        has_moved = False
        If moved = gt Then has_moved = True
    End Function
    Public Function has_fired()
        has_fired = False
        If fired = gt Then has_fired = True
    End Function
    Public Function has_moved_fired()
        has_moved_fired = False
        If moved = gt And fired = gt Then has_moved_fired = True
    End Function
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim m As New MemoryStream()
        Dim f As New BinaryFormatter()
        f.Serialize(m, Me)
        m.Seek(0, SeekOrigin.Begin)
        Return f.Deserialize(m)
    End Function


End Class
