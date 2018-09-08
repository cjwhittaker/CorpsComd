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
    Private pphase As String
    Private phalfstrength As Boolean
    Private pstrength As Integer
    Private pmode As String
    Private pelevated As Boolean
    Private proadmove As Boolean
    Private pmoving As Boolean
    Private pdisrupted_gt As Boolean
    Private pdisrupted As Boolean
    Private pcover As Integer
    Private ploaded As String
    Private pmoved As Integer
    Private pfired As Integer
    Private phit As Boolean
    Private pparent As String
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
    Private parrives As String
    Private pspotted As Boolean
    Private peffective As Boolean
    Private peffect As Integer
    Private pfires As Boolean
    Private pmsg As String
    Private party_spt As Integer
    Private pstatusimpact As Integer
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

    Private pdismounted As Boolean
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
    Property dismounted() As Boolean
        Get
            Return pdismounted
        End Get
        Set(ByVal Value As Boolean)
            pdismounted = Value
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
    Property arty_spt() As Integer
        Get
            Return party_spt
        End Get
        Set(ByVal Value As Integer)
            party_spt = Value
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
    Property phase() As String
        Get
            Return pphase
        End Get
        Set(ByVal Value As String)
            pphase = Value
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

    Property arrives() As String
        Get
            Return parrives
        End Get
        Set(ByVal Value As String)
            parrives = Value
        End Set
    End Property

    Public Function w2()
        w2 = ""
        Try
            If Not eq_list(Me.equipment).weapon_2 Is Nothing Then w2 = eq_list(Me.equipment).weapon_2
        Catch
        End Try
    End Function


    Public Function observer()
        observer = False
        If heli() Then observer = True
        If ground_unit() And Not (indirect() And mode <> disp And Not conc()) Then observer = True
    End Function
    Public Function indirect()
        indirect = False
        If InStr("|ARTY|RL|MOR|", role) > 0 Then indirect = True
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
        If (InStr(title, "#") > 0 And loaded <> "") Or (troopcarrier And loaded<>"") Then embussed = True
    End Function
    'Public Function loiter()
    '    loiter = False
    '    Try
    '        If aircraft() And InStr(eq_list(equipment).special, "L") Then loiter = True
    '    Catch
    '    End Try
    'End Function
    Public Function airdefence()
        airdefence = False
        If mode = travel Then
            airdefence = False
        ElseIf Inf And Not dismounted() Then
            airdefence = False
        ElseIf InStr("|PDSAM|InfSAM|ADSAM|AAA|", role) > 0 Then
            airdefence = True
        Else
        End If
    End Function

    Public Function radar()
        Try
            If mode = travel Then
                radar = False
            ElseIf InStr("|PDSAM|ADSAM|", role) > 0 And InStr(UCase(eq_list(Me.equipment).special), "E") > 0 Then
                radar = True
            Else
                radar = False
            End If

        Catch ex As Exception
            radar = False

        End Try
    End Function

    Public Function Airsuperiority()
        If airborne And (task = "CAP" Or task = "EW Support") Then Airsuperiority = True Else Airsuperiority = False
    End Function
    Public Function sead()
        If task = "SEAD" And airborne Then sead = True Else sead = False
    End Function

    Public Function heli()
        heli = False
        If InStr("|AH|OH|UH|TH|", role) > 0 Then heli = True
    End Function
    Public Function aircraft()
        aircraft = False
        If InStr("|AC|AH|OH|TB|AD|GA|AWACS|EW|", role) > 0 Then aircraft = True
    End Function


    Public Function Airground()
        If task = "CAS" Or task = "Strike" Or task = "SEAD" Then Airground = True Else Airground = False
    End Function
    Public Function Inf()
        Inf = False
        If InStr(role, "Inf") > 0 Then Inf = True
    End Function
    Public Function cae(armd As Boolean)
        If armd Then
            cae = eq_list(equipment).cae
        Else
            cae = eq_list(equipment + "soft").cae
        End If


    End Function
    Public Function afv()
        afv = False
        If InStr("|MICV|TANK|", role) > 0 Then afv = True
    End Function
    Public Function atgw()
        atgw = False
        If InStr("|ATGW|InfATGW|AH|", role) > 0 Then atgw = True
    End Function

    Public Function armour()
        armour = False
        If eq_list(equipment).defence > 0 And Not aircraft() Then armour = True
    End Function

    Public Function hq()
        If Me.comd > 0 Then hq = True : Exit Function
        If role = "|Comd|" Then hq = True Else hq = False
    End Function
    Public Function nondetect()
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
    Public Function getmaxrange(ByVal secondary As String)
        Dim maxrange As Integer
        Try
            If airborne And Airground() And InStr(UCase(equipment), "GA") > 0 Then
                getmaxrange = 5000
            ElseIf secondary.Equals(equipment) Then
                maxrange = eq_list(equipment).maxrange
            ElseIf Not secondary.Equals(equipment) Then
                getmaxrange = eq_list(equipment + w2()).maxrange
            Else
            End If

        Catch ex As Exception
            'getmaxrange = 2000

        End Try
        getmaxrange = maxrange
    End Function
    Public Sub set_fire_effect(target As cunit, r As Integer, stage As Integer)
        Dim context As String = ""
        Dim max_range As Integer
        Dim standoff_range As String = ""
        Try
            If secondary = "" Then max_range = eq_list(equipment).maxrange Else max_range = eq_list(secondary).maxrange
            standoff_range = eq_list(target.equipment).standoff_range
        Catch ex As Exception
            standoff_range = ""
        End Try
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
            If standoff_range = "s" Then
                max_range = 10000
            ElseIf standoff_range = "m" Then
                max_range = 20000
            Else
                max_range = 40000
            End If
        Else
        End If


        If Not context = "AS" And r > max_range Then effect = 0 : Exit Sub
        Try

            If context = "SEAD" And target.eligibleCB And target.airdefence Then
                effect = eq_list(equipment).standoff
                If r > max_range / 2 Then target.modifier = 1
            ElseIf context = "SEAD" And Not target.eligibleCB And target.airdefence Then
                effect = eq_list(equipment).ordnance

            ElseIf context = "GA" Then
                If halfstrength >= 2 Then
                    effect = eq_list(equipment).ordnance
                Else
                    effect = eq_list(equipment).cannon
                End If
            ElseIf context = "AS" Then
                If stage = 0 Then
                    effect = eq_list(equipment).air_to_air_effect
                    If role = "|TB|" And Not heli() Then effect = Int(effect / 3)
                ElseIf stage = 1 Then
                    effect = eq_list(equipment).aam
                    eq_list(target.equipment).defence = eq_list(target.equipment).miss_def
                ElseIf stage = 2 Then
                    effect = eq_list(equipment).aam_close
                Else
                    effect = eq_list(equipment).cannon
                    eq_list(target.equipment).defence = eq_list(target.equipment).gun_def
                    If role = "|TB|" And Not heli() Then effect = Int(effect / 3)
                End If
            ElseIf context = "AD" Then
                If r / eq_list(equipment).max > 0.667 Or (r / eq_list(equipment).max > 0.5 And role = "|AAA|") Then
                    effect = eq_list(equipment).full
                    If InStr(radar, "M") > 0 And Not eligibleCB Then effect = -1
                ElseIf r / eq_list(equipment).max > 0.333 Or role = "|AAA|" Then
                    effect = eq_list(equipment).twothird
                    If InStr(radar, "E") > 0 And Not eligibleCB Then effect = -1
                Else
                    effect = eq_list(equipment).onethird
                    If InStr(radar, "C") > 0 And Not eligibleCB Then effect = -1
                End If
                If (target.mode = "Low" Or target.mode = "Very Low") Then
                    modifier = eq_list(equipment).low
                ElseIf target.mode = "Medium" Then
                    modifier = eq_list(equipment).medium
                Else
                    modifier = eq_list(equipment).high
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
                If secondary = "" Then weapon = equipment Else weapon = secondary
                effect = 0
                For i As Integer = 1 To 2
                    If Not armour() And Not eq_list.Contains(weapon + "soft") Then Exit For
                    If Not armour() Then weapon = weapon + "soft"
                    Select Case r
                        Case 300
                            j = eq_list(weapon).R300
                        Case 600
                            j = eq_list(weapon).R600
                        Case 1000
                            j = eq_list(weapon).R1000
                        Case 1500
                            j = eq_list(weapon).R1500
                        Case 2000
                            j = eq_list(weapon).R2000
                        Case 2500
                            j = eq_list(weapon).R2500
                        Case 3000
                            j = eq_list(weapon).R3000
                        Case 4000
                            j = eq_list(weapon).R4000
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
                        If armour() Then Exit For
                        weapon = orbat(loaded).equipment
                    ElseIf troopcarrier() And Not debussed And i = 2 And r <= 300 Then
                        j = j / 3
                    Else
                    End If
                Next
                effect = effect + j
            ElseIf indirect() And Not spotted Then
                If r / eq_list(equipment).maxrange > 0.667 Then
                    effect = eq_list(equipment).indirect_m
                Else
                    effect = eq_list(equipment).indirect_e
                End If
            Else
                effect = 0
            End If
        Catch ex As Exception
            effect = 0

        End Try
    End Sub
    Public Function composite()
        composite = False
        Try
            If InStr(UCase(eq_list(equipment).special), "C") > 0 Then composite = True
        Catch ex As Exception

        End Try
    End Function
    Public Function heat()
        heat = False
        Try
            If InStr(UCase(eq_list(equipment).special), "H") > 0 Then heat = True

        Catch ex As Exception

        End Try
    End Function
    Public Function heavy_fire()
        heavy_fire = False
        Try
            If InStr(UCase(eq_list(equipment).special), "Y") > 0 Then heavy_fire = True

        Catch ex As Exception

        End Try
    End Function
    Public Function bomblets()
        bomblets = False
        Try
            If InStr(UCase(eq_list(equipment).special), "X") > 0 Then bomblets = True

        Catch ex As Exception

        End Try
    End Function

    Public Function spaced()
        spaced = False
        Try
            If InStr(UCase(eq_list(equipment).special), "S") > 0 Then spaced = True
        Catch ex As Exception
        End Try
    End Function
    Public Function stabilised()
        stabilised = False
        Try
            If InStr(UCase(eq_list(equipment).special), "B") > 0 Then stabilised = True
        Catch ex As Exception
        End Try
    End Function
    Public Function recon()
        recon = False
        If role = "|RECON|" Then recon = True
    End Function
    Public Function size()
        size = ""
        Try
            size = eq_list(equipment).size

        Catch ex As Exception

        End Try
    End Function
    Public Function soft_tpt()
        soft_tpt = False
        Try
            If InStr(UCase(eq_list(equipment).special), "V") > 0 Then soft_tpt = True

        Catch ex As Exception

        End Try
    End Function
    Public Function conc()
        conc = True
        If InStr(UCase(eq_list(equipment).special), "D") > 0 Then conc = False
    End Function
    Public Function smoke_discharger()
        smoke_discharger = False
        Try
            If InStr(UCase(eq_list(equipment).special), "P") > 0 Then smoke_discharger = True

        Catch ex As Exception

        End Try
    End Function
    Public Function smoke_generator()
        smoke_generator = False
        Try
            If InStr(UCase(eq_list(equipment).special), "G") > 0 Then smoke_generator = True

        Catch ex As Exception

        End Try
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
        Try
            If indirect() And mode = disp Then
                If moved = -1 Then emplaced = True : Exit Function
                sorties = 0
                If InStr(eq_list(equipment).special, "2") > 0 Then
                    sorties = 2
                ElseIf InStr(eq_list(equipment).special, "1") > 0 Then
                    sorties = 1
                Else
                End If
                If InStr(UCase(eq_list(equipment).special), "L") = 0 Then sorties = sorties - 1
                x = Val(scenariodefaults.gameturn.Text) - moved + sorties
                If (orbat(parent).comd - 2) - x <= 0 Then emplaced = True
            End If

        Catch ex As Exception

        End Try
    End Function
    Public Function ground_unit()
        ground_unit = False
        If aircraft() Or comd > 0 Then Exit Function
        ground_unit = True
        If troopcarrier() And debussed And loaded <> "" Then
            ground_unit = False
        ElseIf Inf() And Not debussed Then
            ground_unit = False
        ElseIf (troopcarrier() And debussed And loaded = "") Or (Inf() And debussed And loaded = "") Then
            ground_unit = True
        Else
        End If
    End Function

    Public Function status(fm As String)
        status = nostatus
        If comd > 0 And ooc Then
            status = no_action_pts
        ElseIf fm <> "Orbat" And demoralised Then
            status = demoralisedstatus
        ElseIf comd = 0 Then
            If Not conc() And mode = conc() Then mode = disp
            If disrupted Then
                status = disruptedstatus
            ElseIf strength <= 0 Then
                status = dead
            ElseIf assault Then
                status = assaulting
            ElseIf fm <> "Orbat" And halfstrength = 0 And phase = 17 Then
                status = no_action_pts
            ElseIf airborne Then
                status = take_off
            ElseIf mode = travel And fm = "Orbat" Then
                status = Color.DeepSkyBlue
            ElseIf mode = disp And fm = "Orbat" Then
                status = Color.DarkKhaki
            ElseIf arty_spt = 1 Then
                status = can_observe
            ElseIf fm <> "Orbat" And secondary <> "" And task = "DS" Then
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
        Try
            If aborted Then sorties = scenariodefaults.gameturn.Text + 1 Else sorties = eq_list(equipment).sortie

        Catch ex As Exception

        End Try
        strength = strength - casualties
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
    Public Function missile_armed()
        missile_armed = False
        Try
            If InStr(eq_list(equipment).special, "1") + InStr(eq_list(equipment).special, "2") + InStr(eq_list(equipment).special, "3") > 0 Then missile_armed = True

        Catch ex As Exception

        End Try
    End Function
    Public Sub reset_fire_phase(phasing As String)
        '    ooc = False
        '    If nation = phasing Then
        '        If fired = gt Then halfstrength = 0 Else halfstrength = 4
        '        lostcomms = False
        '        If atgw() Then reset_missiles()
        '    Else
        '        fatigue = strength * 2
        '        opp_ca = strength * 2
        '        opp_mode = strength * 2
        '        opp_move = strength * 2
        '    End If
        '    hits = 0
    End Sub
    Public Sub reset_missiles()
        Try
            If InStr(eq_list(equipment).special, "1") > 0 Then
                missiles = 1
            ElseIf InStr(eq_list(equipment).special, "2") > 0 Then
                missiles = 2
            ElseIf InStr(eq_list(equipment).special, "3") > 0 Then
                missiles = 3
            Else
                missiles = 0
            End If

        Catch ex As Exception
            missiles = 0

        End Try
    End Sub
    Public Sub update_after_firing(phasing As String, weapon As String, finished As Boolean)
        Dim i As Integer = 0
        If fires And weapon <> "Minefield" Then
            'calculates tactical pts
            'If (airdefence() And phase <> 17) Or (aircraft() And finished) Then
            '    i = 1
            'ElseIf finished And phasing = nation And movement.scoot Then
            '    i = 4
            'ElseIf phasing = nation And finished Then
            '    i = 2
            'ElseIf Not phasing = nation Then
            '    If Not oppfire Then
            '        opp_return = opp_return - firers - (casualties * 2)
            '    ElseIf oppfire And (movement.tactical = 0 Or movement.tactical = 2) Then
            '        opp_move = opp_move - firers
            '    ElseIf oppfire And movement.tactical = 3 Then
            '        opp_ca = opp_ca - firers
            '    ElseIf oppfire And movement.tactical >= 4 Then
            '        opp_mode = opp_mode - firers
            '    Else
            '    End If
            'Else
            'End If
            If indirect() And loaded <> "" Then loaded = ""
            'If Not aircraft() Then fired = gt Else fired = CorpsComd.phase
            firers_available = firers_available - firers
            firers = 0
            If firers_available <= 0 Then fired = gt : firers_available = 0
            'If indirect() And movement.tactical = 1 Then eligibleCB = True
            If missile_armed() Then missiles = missiles - 1
        End If
        msg = ""
        If aircraft() Then
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
            firers_available = 0
        Else
            msg = ""
            'If casualties > 2 Or hits >= 4 Or statusimpact = 1 Then
            'With morale_test
            '    .Tag = "Immediate"
            '    .tester = Me
            '    .ShowDialog()
            '    .Tag = ""
            'End With
            'End If
            strength = strength - hits
            If strength < firers_available Then firers_available = strength
            If strength / initial <= 0.5 Then halfstrength = True Else halfstrength = False
            hits = 0
            statusimpact = 0
        End If
        'If msg <> "" Then
        '    With resultform_2
        '        .result.Text = msg
        '        .ShowDialog()
        '    End With
        'End If
        If loaded <> "" Then
            With orbat(loaded)
                .strength = strength
                .casualties = casualties
                .mode = mode
            End With

        End If
    End Sub

    Public Function validunit(ByVal phase As String, ByVal hq As String)
        validunit = False
        'If Not (arrives = "" Or arrives = "25") And comd = 0 And phase <> "Orbat" Then Exit Function
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
        ElseIf phase = "Direct Fire" And arrives = 0 And Not disrupted And nation = hq And Not demoralised And firers_available > 0 And Not has_fired And Not airdefence() And Not aircraft() And Not (embussed() And Inf()) Then
            validunit = True
        ElseIf phase = "Smoke Barrage" And Not disrupted And nation = hq And Not demoralised And firers_available > 0 And Not airdefence() And Not aircraft() And Not (embussed() And Inf()) And indirect Then
            validunit = True
        ElseIf phase = "Indirect Fire" And indirect() And emplaced() And Not disrupted And firers_available > 0 And nation = hq Then
            If indirect() And emplaced() And tacticalpts > 0 And Not disrupted Then
                If orbat(parent).ooc Or orbat(orbat(parent).title).ooc Then
                    validunit = False
                Else
                    'If parent = hq Or primary = hq Then
                    '    arty_spt = 0
                    'ElseIf (brigade_comd(Me) = brigade_comd(orbat(hq))) Then
                    '    arty_spt = 1
                    'ElseIf primary <> "" Then
                    '    If brigade_comd(orbat(hq)) = brigade_comd(orbat(primary)) Then arty_spt = 1 Else arty_spt = 2
                    'Else
                    '    arty_spt = 2
                    'End If
                    validunit = True
                End If
            End If
        ElseIf phase = "Observers" And Not disrupted And Not demoralised And Not lostcomms And observer And nation = hq And (arrives = 0 Or arrives Is Nothing) Then
            If orbat(parent).ooc Or orbat(orbat(parent).title).ooc Then
                validunit = False
            Else
                'If parent = hq Or (task = "Obse" And heli()) Then
                '        arty_spt = 0
                '    ElseIf brigade_comd(Me) = brigade_comd(orbat(hq)) Then
                '        arty_spt = 1
                '    Else
                '        arty_spt = 2
                '    End If
                validunit = True
                'End If
            End If
        ElseIf strength <= 0 Or (aircraft() And strength - aborts <= 0) Then
            validunit = False
        ElseIf phase = "Transport" Then
            If troopcarrier() And loaded = "" And parent = hq Then validunit = True
        ElseIf phase = "Fire and Movement" Then
            If Not ground_unit() And Not heli() Then
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
            If parent = hq And Not airborne And sorties = 0 And aircraft() Then validunit = True
        ElseIf phase = "Arty Tasking" Then
            If indirect() Then
                If (parent = hq Or primary = hq) And Not disrupted And emplaced() Then validunit = True
            End If
        ElseIf phase = "SEAD" Then
            If sead() Then validunit = True
        ElseIf phase = "SEAD Targets" Then
            If airdefence() And Not aircraft() Then validunit = True
        ElseIf phase = "CAP Missions" Then
            If airborne And Airsuperiority() And tacticalpts >= 2 Then validunit = True
        ElseIf phase = "CAP Targets" Then
            If airborne And task = "CAP" And strength - aborts > 0 And tacticalpts >= 2 Then validunit = True
        ElseIf phase = "CAP AD Targets" Then
            If airborne And task = "CAP" And strength - aborts > 0 Then validunit = True
        ElseIf phase = "Intercept" Then
            If airborne And strength - aborts > 0 And task = "CAP" And tacticalpts >= 1 Then validunit = True
        ElseIf phase = "Air to Air" Then
            If airborne And strength - aborts > 0 And task <> "CAP" Then validunit = True
        ElseIf phase = "Deploy Aircraft" Then
            If airborne Then validunit = True
        ElseIf phase = "Abort Aircraft" And task = "Abort" Then
            validunit = True : task = ""
        ElseIf phase = "Radar On" Then
            If airdefence() And radar() Then validunit = True
        ElseIf phase = "Air Defence" Then
            If airdefence() Then
                If missile_armed() And missiles = 0 Then
                    validunit = False
                ElseIf CorpsComd.phase = 8 Then
                    If eq_list(equipment).maxrange >= 30000 Then validunit = True Else validunit = False
                Else
                    validunit = True
                End If
            End If
        ElseIf phase = "SEAD Defence Targets" Then
            If airborne And Not heli() And task = "SEAD" Then validunit = True
        ElseIf phase = "Air Defence Targets" Then
            If airborne And Not heli() And Airground() Then validunit = True
        ElseIf phase = "Air Ground" Then
            If airborne And Airground() And Not sead() Then validunit = True
        ElseIf phase = "Ground Attack Targets" And ground_unit() Then
            validunit = True
        ElseIf phase = "Air Targets" Then
            If aircraft() And airborne And Not heli() And task <> "CAP" Then validunit = True
        ElseIf phase = "Ground Targets" And nation = hq Then
            If ground_unit() Then validunit = True
        ElseIf phase = "Opportunity Fire" Then
            If ((ground_unit() And Not indirect() And Not movement.mover.heli) Or
                (indirect() And task = "IN") Or
                (airdefence() And movement.mover.heli And (Not missile_armed() Or (missile_armed() And missiles > 0)))) _
                    And Not (disrupted Or demoralised) Then
                If ((movement.tactical = 0 Or movement.tactical = 2) And opp_move > 0) Or (movement.tactical = 3 And opp_ca > 0) Or (movement.tactical >= 4 And opp_mode > 0) Then validunit = True
            End If
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
    Public Function return_fire_strength(mode As Integer)
        return_fire_strength = 0
        If airborne Then return_fire_strength = strength - aborts : Exit Function
        Select Case mode
            Case 1 : If fatigue - 2 > strength Then return_fire_strength = fatigue - strength Else return_fire_strength = strength
            Case 4 To 9 : If opp_ca - 2 > strength Then return_fire_strength = opp_ca - strength Else return_fire_strength = strength
            Case 3 : If opp_mode - 2 > strength Then return_fire_strength = opp_mode - strength Else return_fire_strength = strength
            Case 0, 2 : If opp_move - 2 > strength Then return_fire_strength = opp_move - strength Else return_fire_strength = strength
        End Select
    End Function
    Public Function capable_of_abort(firer As String)
        capable_of_abort = False
        Try
            If eq_list(equipment).miss_def >= eq_list(firer).aam Then
                capable_of_abort = True
            ElseIf eq_list(equipment).miss_def >= eq_list(firer).aam_close Then
                capable_of_abort = True
            ElseIf eq_list(equipment).gun_def >= eq_list(firer).cannon Then
                capable_of_abort = True
            Else
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function has_moved()
        has_moved = False
        If gt - moved <= 1 And moved <> 0 Then has_moved = True
    End Function
    Public Function has_fired()
        has_fired = False
        If gt - fired = 0 Then has_fired = True
    End Function
    Public Function has_moved_fired()
        has_moved_fired = False
        If moved = gt And fired = gt Then has_moved_fired = True
    End Function
    Public Function hvy_loss(disperse As Boolean)
        hvy_loss = False
        Dim i As Integer = IIf(disperse, -1, 0)
        If (hits + i > 2 And mode = disp) Or (hits + i >= 3 And mode <> disp) Or casualties + i > 4 Then hvy_loss = True
    End Function
    Public Function destroyed()
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
