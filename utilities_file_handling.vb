Module utilities_file_handling
    Dim file As System.IO.StreamWriter, x As String = "", MyReader As Microsoft.VisualBasic.FileIO.TextFieldParser, myType As Type = GetType(cunit), properties As System.Reflection.PropertyInfo() = myType.GetProperties()

    Public Sub load_orbat()
        If Not My.Computer.FileSystem.FileExists(Replace(scenario, ".sce", ".orb")) Then Exit Sub
        Dim pnames As New Collection
        Dim myType As Type = GetType(cunit), pname As String = "", pval As String = "", i As Integer
        Dim p As System.Reflection.PropertyInfo
        MyReader = New Microsoft.VisualBasic.FileIO.TextFieldParser(Strings.Left(scenario, (Len(scenario) - 4)) + ".orb")
        orbat = New Collection
        'Using MyReader
        MyReader.TextFieldType = FileIO.FieldType.Delimited
        MyReader.SetDelimiters(",")
        Dim currentRow As String()
        currentRow = MyReader.ReadFields()
        For Each cfield As String In currentRow
            pnames.Add(cfield)
        Next
        While Not MyReader.EndOfData
            u = New cunit
            Try
                currentRow = MyReader.ReadFields()
                i = 1
                For Each cfield As String In currentRow
                    p = myType.GetProperty(pnames(i))

                    If cfield = "" Then

                    ElseIf p.PropertyType.Name = "Int32" Then
                        p.SetValue(u, CInt(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "DateTime" Then
                        p.SetValue(u, CDate(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Single" Then
                        p.SetValue(u, CSng(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Boolean" Then
                        p.SetValue(u, CBool(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    Else
                        p.SetValue(u, cfield, Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    End If
                    i = i + 1
                Next
                If orbat.Contains(u.title) Then orbat.Remove(u.title)
                orbat.Add(u, Key:=u.title)
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While

    End Sub
    Public Sub save_orbat()
        If IsNothing(orbat) Then Exit Sub
        populate_command_structure(p1_tree, scenariodefaults.player1.Text, "Orbat")
        populate_command_structure(p2_tree, scenariodefaults.player2.Text, "Orbat")
        file = My.Computer.FileSystem.OpenTextFileWriter(Replace(scenario, ".sce", ".orb"), False)
        Dim y As String = "", n As String = ""
        For Each p As System.Reflection.PropertyInfo In properties
            y = y + p.Name + ","
        Next
        file.WriteLine(y)
        save_command_structure(p1_tree.Nodes(0))
        save_command_structure(p2_tree.Nodes(0))
        file.Close()
    End Sub
    Private Sub save_command_structure(no As TreeNode)
        u = orbat(no.Text)
        For i As Integer = 1 To 2
            x = ""
            For Each p As System.Reflection.PropertyInfo In properties
                If x <> "" Then x = x + ","
                If p.PropertyType.Name = "Single" Or p.PropertyType.Name = "Boolean" Or p.PropertyType.Name = "Int32" Then
                    x = x + Trim(Str(p.GetValue(u, Nothing)))
                ElseIf p.PropertyType.Name = "DateTime" Then
                    x = x + Format(p.GetValue(u, Nothing), "dd MMM yyyy HH:mm")
                Else
                    x = x + p.GetValue(u, Nothing)
                End If
            Next
            file.WriteLine(x)

            If i = 1 And u.loaded <> "" Then
                u = orbat(u.loaded)
            Else
                Exit For
            End If
        Next
        For Each n As TreeNode In no.Nodes
            save_command_structure(n)
        Next
    End Sub



    Public Sub load_equipment()
        If Not My.Computer.FileSystem.FileExists(d_dir + "equipment.dat") Then Exit Sub
        Dim pnames As New Collection, equip As cequipment
        Dim myType As Type = GetType(cequipment), pname As String = "", pval As String = "", i As Integer
        Dim p As System.Reflection.PropertyInfo
        equipment = New Collection
        Dim MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(d_dir + "equipment.dat")
        'Using MyReader
        MyReader.TextFieldType = FileIO.FieldType.Delimited
        MyReader.SetDelimiters(",")
        Dim currentRow As String()
        currentRow = MyReader.ReadFields()
        For Each cfield As String In currentRow
            pnames.Add(cfield)
        Next
        While Not MyReader.EndOfData
            equip = New cequipment
            Try
                currentRow = MyReader.ReadFields()
                i = 1
                For Each cfield As String In currentRow
                    p = myType.GetProperty(pnames(i))
                    'data changes
                    If cfield = "" Then

                    ElseIf p.PropertyType.Name = "Int32" Then
                        p.SetValue(equip, CInt(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "DateTime" Then
                        p.SetValue(equip, CDate(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Single" Then
                        p.SetValue(equip, CSng(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Boolean" Then
                        p.SetValue(equip, CBool(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    Else
                        p.SetValue(equip, cfield, Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    End If
                    i = i + 1
                    If i > pnames.Count Then Exit For
                Next
                If equipment.Contains(equip.title) Then equipment.Remove(equip.title)
                equipment.Add(equip, equip.title)
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While
    End Sub
    Public Sub save_equipment()
        If IsNothing(orbat) Then Exit Sub
        file = My.Computer.FileSystem.OpenTextFileWriter(d_dir + "equipment.dat", False)
        Dim myType As Type = GetType(cequipment)
        Dim x As String = "", y As String = "", n As String = ""
        Dim properties As System.Reflection.PropertyInfo() = myType.GetProperties()
        For Each p As System.Reflection.PropertyInfo In properties
            y = y + p.Name + ","
        Next
        file.WriteLine(y)
        For Each e As cequipment In equipment
            x = ""
            For Each p As System.Reflection.PropertyInfo In properties
                If x <> "" Then x = x + ","
                If p.PropertyType.Name = "Single" Or p.PropertyType.Name = "Boolean" Or p.PropertyType.Name = "Int32" Then
                    x = x + Str(p.GetValue(e, Nothing))
                ElseIf p.PropertyType.Name = "DateTime" Then
                    x = x + Format(p.GetValue(e, Nothing), "dd MMM yyyy HH:mm")
                Else
                    x = x + p.GetValue(e, Nothing)
                End If
            Next
            file.WriteLine(x)
        Next
        file.Close()
    End Sub

    Public Sub load_subunits()
        If Not My.Computer.FileSystem.FileExists(d_dir + "\" + "subunits.dat") Then Exit Sub
        TOE = New Collection
        unittypes = New Collection
        Dim pnames As New Collection, subunit As csubunit
        Dim myType As Type = GetType(csubunit), pname As String = "", pval As String = "", i As Integer
        Dim p As System.Reflection.PropertyInfo
        Dim MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(d_dir + "subunits.dat")
        MyReader.TextFieldType = FileIO.FieldType.Delimited
        MyReader.SetDelimiters(",")
        Dim currentRow As String()
        currentRow = MyReader.ReadFields()
        For Each cfield As String In currentRow
            pnames.Add(cfield)
        Next
        While Not MyReader.EndOfData
            subunit = New csubunit
            Try
                currentRow = MyReader.ReadFields()
                i = 1
                For Each cfield As String In currentRow
                    p = myType.GetProperty(pnames(i))
                    'data changes
                    If cfield = "" Then

                    ElseIf p.PropertyType.Name = "Int32" Then
                        p.SetValue(subunit, CInt(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "DateTime" Then
                        p.SetValue(subunit, CDate(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Single" Then
                        p.SetValue(subunit, CSng(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Boolean" Then
                        p.SetValue(subunit, CBool(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    Else
                        p.SetValue(subunit, cfield, Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    End If
                    i = i + 1
                    If i > pnames.Count Then Exit For
                Next
                'If TOE.Contains(subunit.title) Then TOE.Remove(subunit.title)
                TOE.Add(subunit)
                If Not unittypes.Contains(subunit.title) Then
                    unittype = New cunittype
                    With unittype
                        .nation = subunit.nation
                        .title = subunit.title
                        .comd = subunit.comd
                    End With
                    unittypes.Add(unittype, subunit.title)
                End If
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While

    End Sub

    Public Sub save_subunits()
        Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("subunits.dat", False)
        For Each subunit As csubunit In TOE
            file.WriteLine(subunit.savetofile)
        Next
        file.Close()
    End Sub

    Public Sub savedata(ByVal scenariofile As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(scenariofile, False)
        file.WriteLine("player1=," + My.Forms.scenariodefaults.player1.Text + "," + (My.Forms.scenariodefaults.player1_init.Text) + "," + (My.Forms.scenariodefaults.lock_1.Text))
        file.WriteLine("player2=," + My.Forms.scenariodefaults.player2.Text + "," + (My.Forms.scenariodefaults.player2_init.Text) + "," + (My.Forms.scenariodefaults.lock_2.Text))
        file.WriteLine("gamedate=," + Format(gamedate, "dd/MMM/yyyy HH:mm"))
        file.WriteLine("starttime=, " + scenariodefaults.start_time.Text)
        file.WriteLine("dawn=," + Str(dawn))
        file.WriteLine("dusk=," + Str(dusk))
        file.WriteLine("currenttime=, " + scenariodefaults.Current_time.Text)
        file.WriteLine("gameturn=, " + scenariodefaults.gameturn.Text)
        file.WriteLine("ph=, " + ph)
        file.WriteLine("nph=, " + nph)
        file.WriteLine("player phase=, " + Str(playerphase))
        file.WriteLine("game phase=, " + Str(phase))
        file.WriteLine("smoke fired=, " + Str(smokefiredthisturn))
        file.Close()
        save_orbat()
        If Not event_list Is Nothing Then
            scenariofile = Strings.Left(scenariofile, InStrRev(scenariofile, ".") - 1) + ".ent"
            file = My.Computer.FileSystem.OpenTextFileWriter(scenariofile, False)
            For Each e As cevents In event_list
                e.save_to_file(file)
            Next
            file.Close()
        End If

    End Sub
    Public Sub load_events()
        If Not My.Computer.FileSystem.FileExists(Replace(scenario, ".sce", ".ent")) Then Exit Sub
        event_list = New Collection
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Replace(scenario, ".sce", ".ent"))
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            While Not MyReader.EndOfData
                Dim e = New cevents
                Try
                    e.load_from_file(MyReader.ReadFields)
                    event_list.Add(e)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message &
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub
End Module
