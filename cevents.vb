Public Class cevents
    Private pside As String
    Private punit As String
    Private ptext As String
    Private pdie As String
    Private pscore As Integer
    Private pdec As Boolean
    Private ptime As String
    Private ptested As Boolean
    Private pid As String
    Property id() As String
        Get
            Return pid
        End Get
        Set(ByVal Value As String)
            pid = Value
        End Set
    End Property
    Property side() As String
        Get
            Return pside
        End Get
        Set(ByVal Value As String)
            pside = Value
        End Set
    End Property
    Property unit() As String
        Get
            Return punit
        End Get
        Set(ByVal Value As String)
            punit = Value
        End Set
    End Property

    Property die() As String
        Get
            Return pdie
        End Get
        Set(ByVal Value As String)
            pdie = Value
        End Set
    End Property
    Property text() As String
        Get
            Return ptext
        End Get
        Set(ByVal Value As String)
            ptext = Value
        End Set
    End Property
    Property time() As String
        Get
            Return ptime
        End Get
        Set(ByVal Value As String)
            ptime = Value
        End Set
    End Property
    Property dec() As Boolean
        Get
            Return pdec
        End Get
        Set(ByVal Value As Boolean)
            pdec = Value
        End Set
    End Property
    Property tested() As Boolean
        Get
            Return ptested
        End Get
        Set(ByVal Value As Boolean)
            ptested = Value
        End Set
    End Property
    Property score() As Integer
        Get
            Return pscore
        End Get
        Set(ByVal Value As Integer)
            pscore = Value
        End Set
    End Property
    Public Sub load_from_file(ByVal x As Array)
        Dim i As Integer = 1, currentfield As String
        For Each currentfield In x
            Select Case i
                Case 1 : pside = currentfield
                Case 2 : ptime = currentfield
                Case 3 : ptext = currentfield
                Case 4 : pdie = currentfield
                Case 5 : pscore = Val(currentfield)
                Case 6 : pdec = CBool(currentfield)
                Case 7 : ptested = CBool(currentfield)
            End Select
            i = i + 1
        Next
    End Sub
    Public Sub save_to_file(ByVal x As Object)
        x.WriteLine(side + "," + time + "," + text + "," + die + "," + Str(score) + "," + Str(dec) + "," + Str(tested))
    End Sub
    Public Sub create_id()
        Dim i As Integer = 0
        Do
            id = Trim(Str(event_list.Count + i))
            i = i + 1
        Loop Until Not event_list.Contains(id)
    End Sub
End Class
