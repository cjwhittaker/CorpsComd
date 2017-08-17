Public Class cequipment
    Private ptitle As String
    Private pdefence As Integer
    Private pspecial As Integer
    Private pweapon_2 As String
    Private prole As String
    Private paam As Integer
    Private pcannon As Integer
    Private pSize As Integer
    Private pCAE As Integer
    Private pR0 As Integer
    Private pR125 As Integer
    Private pR250 As Integer
    Private pR500 As Integer
    Private pR750 As Integer
    Private pR1000 As Integer
    Private pR1250 As Integer
    Private pR1500 As Integer
    Private pR2000 As Integer
    Private pR2500 As Integer
    Private pR3000 As Integer
    Private pR4000 As Integer
    Private pR5000 As Integer
    Private pR6000 As Integer
    Private pR8000 As Integer
    Private pR10000 As Integer
    Private pMax As Integer
    Private pSortie As Integer
    Private pEWCapable As Boolean
    Property title() As String
        Get
            Return pTitle
        End Get
        Set(ByVal value As String)
            pTitle = value
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
    Property defence() As Integer
        Get
            Return pdefence
        End Get
        Set(ByVal Value As Integer)
            pdefence = Value
        End Set
    End Property
    Property special() As Integer
        Get
            Return pspecial
        End Get
        Set(ByVal Value As Integer)
            pspecial = Value
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
    Property cannon() As Integer
        Get
            Return pcannon
        End Get
        Set(ByVal Value As Integer)
            pcannon = Value
        End Set
    End Property
    Property size() As Integer
        Get
            Return pSize
        End Get
        Set(ByVal Value As Integer)
            pSize = Value
        End Set
    End Property
    Property cae() As Integer
        Get
            Return pCAE
        End Get
        Set(ByVal Value As Integer)
            pCAE = Value
        End Set
    End Property
    Property r0() As Integer
        Get
            Return pR0
        End Get
        Set(ByVal Value As Integer)
            pR0 = Value
        End Set
    End Property
    Property r125() As Integer
        Get
            Return pR125
        End Get
        Set(ByVal Value As Integer)
            pR125 = Value
        End Set
    End Property
    Property r250() As Integer
        Get
            Return pR250
        End Get
        Set(ByVal Value As Integer)
            pR250 = Value
        End Set
    End Property
    Property r500() As Integer
        Get
            Return pR500
        End Get
        Set(ByVal Value As Integer)
            pR500 = Value
        End Set
    End Property
    Property r750() As Integer
        Get
            Return pR750
        End Get
        Set(ByVal Value As Integer)
            pR750 = Value
        End Set
    End Property
    Property r1000() As Integer
        Get
            Return pR1000
        End Get
        Set(ByVal Value As Integer)
            pR1000 = Value
        End Set
    End Property
    Property r1250() As Integer
        Get
            Return pR1250
        End Get
        Set(ByVal Value As Integer)
            pR1250 = Value
        End Set
    End Property
    Property r1500() As Integer
        Get
            Return pR1500
        End Get
        Set(ByVal Value As Integer)
            pR1500 = Value
        End Set
    End Property
    Property r2000() As Integer
        Get
            Return pR2000
        End Get
        Set(ByVal Value As Integer)
            pR2000 = Value
        End Set
    End Property
    Property r2500() As Integer
        Get
            Return pR2500
        End Get
        Set(ByVal Value As Integer)
            pR2500 = Value
        End Set
    End Property
    Property r3000() As Integer
        Get
            Return pR3000
        End Get
        Set(ByVal Value As Integer)
            pR3000 = Value
        End Set
    End Property
    Property r4000() As Integer
        Get
            Return pR4000
        End Get
        Set(ByVal Value As Integer)
            pR4000 = Value
        End Set
    End Property
    Property r5000() As Integer
        Get
            Return pR5000
        End Get
        Set(ByVal Value As Integer)
            pR5000 = Value
        End Set
    End Property
    Property r6000() As Integer
        Get
            Return pR6000
        End Get
        Set(ByVal Value As Integer)
            pR6000 = Value
        End Set
    End Property
    Property r8000() As Integer
        Get
            Return pR8000
        End Get
        Set(ByVal Value As Integer)
            pR8000 = Value
        End Set
    End Property
    Property r10000() As Integer
        Get
            Return pR10000
        End Get
        Set(ByVal Value As Integer)
            pR10000 = Value
        End Set
    End Property
    Property max() As Integer
        Get
            Return pMax
        End Get
        Set(ByVal Value As Integer)
            pMax = Value
        End Set
    End Property
    Property sortie() As Integer
        Get
            Return pSortie
        End Get
        Set(ByVal Value As Integer)
            pSortie = Value
        End Set
    End Property
    Property ewcapable() As Boolean
        Get
            Return pEWCapable
        End Get
        Set(ByVal Value As Boolean)
            pEWCapable = Value
        End Set
    End Property
    Public Function savetofile()
        Dim x As String = "", d As String = ","
        x = x + ptitle
        x = x + d + Str(pdefence)
        x = x + d + Str(pspecial)
        x = x + d + pweapon_2
        x = x + d + prole
        x = x + d + Str(paam)
        x = x + d + Str(pcannon)
        x = x + d + Str(pSize)
        x = x + d + Str(pCAE)
        x = x + d + Str(pR0)
        x = x + d + Str(pR125)
        x = x + d + Str(pR250)
        x = x + d + Str(pR500)
        x = x + d + Str(pR750)
        x = x + d + Str(pR1000)
        x = x + d + Str(pR1250)
        x = x + d + Str(pR1500)
        x = x + d + Str(pR2000)
        x = x + d + Str(pR2500)
        x = x + d + Str(pR3000)
        x = x + d + Str(pR4000)
        x = x + d + Str(pR5000)
        x = x + d + Str(pR6000)
        x = x + d + Str(pR8000)
        x = x + d + Str(pR10000)
        x = x + d + Str(pMax)
        x = x + d + Str(pSortie)
        x = x + d + Str(pEWCapable)
        Return x

    End Function
    Public Sub loadfromfile(ByVal x As Array)
        Dim currentField As String, i As Integer
        i = 1
        For Each currentField In x
            Select Case i
                Case 1 : ptitle = currentField
                Case 2 : pdefence = Val(currentField)
                Case 3 : pspecial = Val(currentField)
                Case 4 : pweapon_2 = currentField
                Case 5 : prole = currentField
                Case 6 : paam = Val(currentField)
                Case 7 : pcannon = Val(currentField)
                Case 8 : pSize = Val(currentField)
                Case 9 : pCAE = Val(currentField)
                Case 10 : pR0 = Val(currentField)
                Case 11 : pR125 = Val(currentField)
                Case 12 : pR250 = Val(currentField)
                Case 13 : pR500 = Val(currentField)
                Case 14 : pR750 = Val(currentField)
                Case 15 : pR1000 = Val(currentField)
                Case 16 : pR1250 = Val(currentField)
                Case 17 : pR1500 = Val(currentField)
                Case 18 : pR2000 = Val(currentField)
                Case 19 : pR2500 = Val(currentField)
                Case 20 : pR3000 = Val(currentField)
                Case 21 : pR4000 = Val(currentField)
                Case 22 : pR5000 = Val(currentField)
                Case 23 : pR6000 = Val(currentField)
                Case 24 : pR8000 = Val(currentField)
                Case 25 : pR10000 = Val(currentField)
                Case 26 : pMax = Val(currentField)
                Case 27 : pSortie = Val(currentField)
                Case 28 : pEWCapable = Val(currentField)
            End Select
            i = i + 1
        Next
    End Sub

End Class
