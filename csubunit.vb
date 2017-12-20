Public Class csubunit
    Private pnation As String
    Private ptitle As String
    Private pequipment As String
    Private pquantity As Integer
    Private pstrength As Integer
    Private pcomd As Integer
    Private punit_comd As Integer
    Private psub_comd As Boolean
    Private pdesig As String


    Property comd() As Integer
        Get
            Return pcomd
        End Get
        Set(ByVal Value As Integer)
            pcomd = Value
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
    Property quantity() As Integer
        Get
            Return pquantity
        End Get
        Set(ByVal Value As Integer)
            pquantity = Value
        End Set
    End Property
    Property title() As String
        Get
            Return ptitle
        End Get
        Set(ByVal Value As String)
            ptitle = Value
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
    Property unit_comd() As Integer
        Get
            Return punit_comd
        End Get
        Set(ByVal Value As Integer)
            punit_comd = Value
        End Set
    End Property
    Property sub_comd() As Boolean
        Get
            Return psub_comd
        End Get
        Set(ByVal Value As Boolean)
            psub_comd = Value
        End Set
    End Property
    Property desig() As String
        Get
            Return pdesig
        End Get
        Set(ByVal Value As String)
            pdesig = Value
        End Set
    End Property





    Public Function savetofile()
        Dim x As String = "", d As String = ","
        x = x + nation
        x = x + d + title
        x = x + d + equipment
        x = x + d + Str(quantity)
        x = x + d + Str(strength)
        x = x + d + Str(comd)

        Return x
    End Function
    Public Sub loadfromfile(ByVal x As Array)
        Dim currentField As String, i As Integer
        i = 1
        For Each currentField In x
            Select Case i
                Case 1 : nation = currentField
                Case 2 : title = currentField
                Case 3 : equipment = currentField
                Case 4 : quantity = Val(currentField)
                Case 5 : strength = Val(currentField)
                Case 6 : comd = Val(currentField)

            End Select
            i = i + 1
        Next
    End Sub



End Class
