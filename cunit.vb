Public Class cunit
    Private pTitle As String
    Private pcomd As Integer
    Private pnation As String
    Private pquality As String
    Private pequipment As String
    Private pinitial As Integer
    Private pcomdpts As Integer
    Private ptacticalpts As Integer
    Private pstrength As Integer
    Private ppinned As Boolean
    Private prepulsed As Boolean
    Private prouted As Boolean
    Private pcover As Integer
    Private ploaded As String
    Private pmoved As Boolean
    Private pfired As Boolean
    Private phit As Boolean
    Private pparent As String
    Private pno_of_units As Integer
    Private psorties As Integer
    Private pflanked As Boolean
    Private prear As Boolean
    Private pdemoralised As Boolean
    Private pprimary As String
    Private pairborne As Boolean
    Private pserialno As Integer
    Private psmoke As Integer
    Private peligibleCB As Boolean
    Private psuppression As Integer
    Private pcasualties As Integer
    Private pairtask As String
    Private pordnance As Boolean
    Private pewsupported As Boolean
    Private pfiredthistarget As Boolean
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
    Property fires() As Boolean
        Get
            Return pfires
        End Get
        Set(ByVal Value As Boolean)
            pfires = Value
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
    Property effective() As Boolean
        Get
            Return peffective
        End Get
        Set(ByVal Value As Boolean)
            peffective = Value
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
    Property airtask() As String
        Get
            Return pairtask
        End Get
        Set(ByVal Value As String)
            pairtask = Value
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
    Property suppression() As Integer
        Get
            Return psuppression
        End Get
        Set(ByVal Value As Integer)
            psuppression = Value
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
    Property firedthistarget() As Boolean
        Get
            Return pfiredthistarget
        End Get
        Set(ByVal Value As Boolean)
            pfiredthistarget = Value
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
    Property serialno() As Integer
        Get
            Return pserialno
        End Get
        Set(ByVal Value As Integer)
            pserialno = Value
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
    Property primary() As String
        Get
            Return pprimary
        End Get
        Set(ByVal Value As String)
            pprimary = Value
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
    Property rear() As Boolean
        Get
            Return prear
        End Get
        Set(ByVal Value As Boolean)
            prear = Value
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
    Property sorties() As Integer
        Get
            Return psorties
        End Get
        Set(ByVal Value As Integer)
            psorties = Value
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
    Property hit() As Boolean
        Get
            Return phit
        End Get
        Set(ByVal Value As Boolean)
            phit = Value
        End Set
    End Property
    Property fired() As Boolean
        Get
            Return pfired
        End Get
        Set(ByVal Value As Boolean)
            pfired = Value
        End Set
    End Property
    Property moved() As Boolean
        Get
            Return pmoved
        End Get
        Set(ByVal Value As Boolean)
            pmoved = Value
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
    Property strength() As Integer
        Get
            Return pstrength
        End Get
        Set(ByVal Value As Integer)
            pstrength = Value
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
    Property tacticalpts() As Integer
        Get
            Return ptacticalpts
        End Get
        Set(ByVal Value As Integer)
            ptacticalpts = Value
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
    Property routed() As Boolean
        Get
            Return prouted
        End Get
        Set(ByVal Value As Boolean)
            prouted = Value
        End Set
    End Property
    Property repulsed() As Boolean
        Get
            Return prepulsed
        End Get
        Set(ByVal Value As Boolean)
            prepulsed = Value
        End Set
    End Property
    Property pinned() As Boolean
        Get
            Return ppinned
        End Get
        Set(ByVal Value As Boolean)
            ppinned = Value
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
    Property initial() As Integer
        Get
            Return pinitial
        End Get
        Set(ByVal Value As Integer)
            pinitial = Value
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
    Property quality() As String
        Get
            Return pquality
        End Get
        Set(ByVal Value As String)
            pquality = Value
        End Set
    End Property
    Property nation() As String
        Get
            Return pnation
        End Get
        Set(ByVal Value As String)
            pnation = Value
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
    Property sort() As String
        Get
            Return psort
        End Get
        Set(ByVal Value As String)
            psort = Value
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

    Public Sub loadfromfile(ByVal x As Array)
        Dim currentField As String, i As Integer
        i = 1
        For Each currentField In x
            Select Case i
                Case 1 : title = currentField
                Case 2 : comd = Val(currentField)
                Case 3 : nation = currentField
                Case 4 : quality = currentField
                Case 5 : equipment = currentField
                Case 6 : initial = Val(currentField)
                Case 7 : comdpts = Val(currentField)
                Case 8 : tacticalpts = Val(currentField)
                Case 9 : strength = Val(currentField)
                Case 10 : pinned = CBool(currentField)
                Case 11 : repulsed = CBool(currentField)
                Case 12 : routed = CBool(currentField)
                Case 13 : Cover = Val(currentField)
                Case 14 : loaded = currentField
                Case 15 : moved = CBool(currentField)
                Case 16 : fired = CBool(currentField)
                Case 17 : hit = CBool(currentField)
                Case 18 : parent = currentField
                Case 19 : no_of_units = Val(currentField)
                Case 20 : sorties = Val(currentField)
                Case 21 : flanked = CBool(currentField)
                Case 22 : rear = CBool(currentField)
                Case 23 : demoralised = CBool(currentField)
                Case 24 : primary = currentField
                Case 25 : airborne = CBool(currentField)
                Case 26 : serialno = Val(currentField)
                Case 27 : smoke = Val(currentField)
                Case 28 : eligibleCB = CBool(currentField)
                Case 29 : suppression = Val(currentField)
                Case 30 : airtask = currentField
                Case 31 : ordnance = CBool(currentField)
                Case 32 : ewsupported = CBool(currentField)
            End Select
            i = i + 1
        Next
    End Sub
    Public Function savetofile()
        Dim x As String = "", d As String = ","
        x = x + title
        x = x + d + Str(comd)
        x = x + d + nation
        x = x + d + quality
        x = x + d + equipment
        x = x + d + Str(initial)
        x = x + d + Str(comdpts)
        x = x + d + Str(tacticalpts)
        x = x + d + Str(strength)
        x = x + d + Str(pinned)
        x = x + d + Str(repulsed)
        x = x + d + Str(routed)
        x = x + d + Str(Cover)
        x = x + d + loaded
        x = x + d + Str(moved)
        x = x + d + Str(fired)
        x = x + d + Str(hit)
        x = x + d + parent
        x = x + d + Str(no_of_units)
        x = x + d + Str(sorties)
        x = x + d + Str(flanked)
        x = x + d + Str(rear)
        x = x + d + Str(demoralised)
        x = x + d + primary
        x = x + d + Str(airborne)
        x = x + d + Str(serialno)
        x = x + d + Str(smoke)
        x = x + d + Str(eligibleCB)
        x = x + d + Str(suppression)
        x = x + d + airtask
        x = x + d + Str(ordnance)
        x = x + d + Str(ewsupported)

        Return x
    End Function

    Public Function w2()
        If CorpsComd.equipment(Me.equipment).weapon_2 = "" Then w2 = "" : Exit Function
        w2 = CorpsComd.equipment(Me.equipment).weapon_2
    End Function

    Public Function indirect()
        If Me.equipment = "" Then indirect = False : Exit Function
        If CorpsComd.equipment(Me.equipment).role = "ARTY" Or CorpsComd.equipment(Me.equipment).role = "MOR" Then
            indirect = True
        Else
            indirect = False
        End If
    End Function

    Public Function role()
        role = CorpsComd.equipment(Me.equipment).role
    End Function

    Public Function observer()
        If Me.indirect Or (pordnance And (pairtask = "CAS" Or pairtask = "Strike")) Then observer = True Else observer = False
    End Function
    Public Function root()
        If parent = "root" Then root = True Else root = False
    End Function
    Public Function troopcarrier() As Boolean
        If Me.equipment = "" Then troopcarrier = False : Exit Function
        If CorpsComd.equipment(Me.equipment).role = "APC" Or CorpsComd.equipment(Me.equipment).role = "MICV" Then troopcarrier = True Else troopcarrier = False
    End Function
    Public Function embussed() As Boolean
        If Me.equipment = "" Then embussed = False : Exit Function
        If Not (CorpsComd.equipment(Me.equipment).role = "APC" Or CorpsComd.equipment(Me.equipment).role = "MICV") And Me.loaded <> "" Then embussed = True Else embussed = False
    End Function

    Public Function loiter()
        If pequipment = "A10" Or pequipment = "SU25" Or pequipment = "Harrier-GR8" Then loiter = True Else loiter = False
    End Function
    Public Function atgw()
        If Me.equipment = "" Then atgw = False : Exit Function
        If Right(CorpsComd.equipment(Me.equipment).role, 4) = "ATGW" Or (CorpsComd.equipment(Me.equipment).role = "AH" And pairborne) Then atgw = True Else atgw = False
    End Function
    Public Function airdefence()
        If CorpsComd.equipment(Me.equipment).role = "PDSAM" Or CorpsComd.equipment(Me.equipment).role = "ADSAM" Or CorpsComd.equipment(Me.equipment).role = "AAA" Or (Me.airborne And pairtask = "Air Superiority") Then airdefence = True Else airdefence = False
    End Function
    Public Function Airsuperiority()
        If pairtask = "Air Superiority" Or pairtask = "EW Support" Then Airsuperiority = True Else Airsuperiority = False
    End Function
    Public Function hel()
        If CorpsComd.equipment(Me.equipment).role = "AH" Or CorpsComd.equipment(Me.equipment).role = "OH" Then hel = True Else hel = False
    End Function
    Public Function Airground()
        If pairtask = "CAS" Or pairtask = "Strike" Or pairtask = "Wild Weasel" Then Airground = True Else Airground = False
    End Function
    Public Function Aircraft()
        If CorpsComd.equipment(Me.equipment).role = "AC" Or CorpsComd.equipment(Me.equipment).role = "AH" Or CorpsComd.equipment(Me.equipment).role = "OH" Then Aircraft = True Else Aircraft = False
    End Function
    Public Function Inf()
        If Left(CorpsComd.equipment(Me.equipment).role, 3) = "Inf" Then Inf = True Else Inf = False
    End Function
    Public Function cae()
        cae = CorpsComd.equipment(Me.equipment).cae
    End Function
    Public Function afv()
        If Left(CorpsComd.equipment(Me.equipment).role, 3) = "MICV" Or InStr(CorpsComd.equipment(Me.equipment).role, "TANK") > 0 Then
            afv = True
        Else
            afv = False
        End If
    End Function
    Public Function hq()
        If Me.comd > 0 Then hq = True : Exit Function
        If CorpsComd.equipment(Me.equipment).role = "HQ" Then hq = True Else hq = False
    End Function
    Public Function nondetect()
        If Me.airdefence Or Me.Airsuperiority Or pairtask = "Wild Weasel" Then nondetect = True Else nondetect = False
    End Function
    Public Function text_status()
        text_status = ""
        If demoralised Then
            text_status = "- Demoralised"
        ElseIf strength = 0 And comd = 0 Then
            text_status = "- Destroyed"
        ElseIf routed Then
            text_status = "- Routing"
        ElseIf pinned And repulsed Then
            text_status = "- Pinned and Repulsed"
        ElseIf repulsed Then
            text_status = "- Repulsed"
        ElseIf pinned Then
            text_status = "- Pinned"
        ElseIf airborne Then
            text_status = "- Airborne"
        ElseIf moved Then
            text_status = "- Moving"
        ElseIf hit Then
            text_status = "- Under Fire " + IIf(pcover > 0, "in cover +" + Trim(Str(pcover)), "")
        Else
            text_status = "- Static " + IIf(pcover > 0, "in cover +" + Trim(Str(pcover)), "")
        End If
    End Function
End Class
