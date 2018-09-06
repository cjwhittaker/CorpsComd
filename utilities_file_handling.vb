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
        For Each u As cunit In orbat
            If u.comd = 0 Then u.role = "|" + eq_list(u.equipment).role + "|"
        Next
    End Sub
    Public Sub save_orbat()
        If IsNothing(orbat) Then Exit Sub
        order_command_structure(scenariodefaults.player1.Text)
        order_command_structure(scenariodefaults.player2.Text)
        file = My.Computer.FileSystem.OpenTextFileWriter(Replace(scenario, ".sce", ".orb"), False)
        Dim y As String = "", n As String = ""
        For Each p As System.Reflection.PropertyInfo In properties
            y = y + p.Name + ","
        Next
        file.WriteLine(y)
        save_command_structure(p1_tree)
        save_command_structure(p2_tree)
        file.Close()
    End Sub
    Public Sub save_command_structure(comdtree As Collection)
        For Each u As cunit In comdtree
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
        Next
    End Sub

    Public Sub order_command_structure(side As String)

        Dim Topunit As String, u As New cunit, x As Integer = 0
        If side = scenariodefaults.player1.Text Then
            p1_tree = New Collection
            p1_tree.Clear()
        Else
            p2_tree = New Collection
            p2_tree.Clear()
        End If
        For Each u In orbat
            x = x + 1
            If u.nation = side And u.parent = "root" Then Exit For
        Next
        Topunit = u.title
        create_structure(Topunit)

    End Sub

    Public Sub create_structure(ByVal currentcomd As String)
        If orbat(currentcomd).nation = scenariodefaults.player1.Text Then
            p1_tree.Add(orbat(currentcomd), orbat(currentcomd).title)
        Else
            p2_tree.Add(orbat(currentcomd), orbat(currentcomd).title)
        End If

        For x As Integer = 1 To orbat.Count
            If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                create_structure(orbat(x).title)
            End If
        Next
    End Sub


    Public Sub load_equipment()
        If Not My.Computer.FileSystem.FileExists(d_dir + "equipment.dat") Then Exit Sub
        Dim pnames As New Collection, equip As cequipment
        Dim myType As Type = GetType(cequipment), pname As String = "", pval As String = "", i As Integer
        Dim p As System.Reflection.PropertyInfo
        'eq_list = New Collection
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
                'If eq_list.Contains(equip.title) Then eq_list.Remove(equip.title)
                eq_list.Add(equip, equip.title)
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While

    End Sub

    Public Sub load_subunits()
        If Not My.Computer.FileSystem.FileExists(d_dir + "\" + "subunits.dat") Then Exit Sub
        TOE = New Collection
        'unittypes = New Collection
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
        save_events()
    End Sub
    Public Sub load_events()
        If Not My.Computer.FileSystem.FileExists(Replace(scenario, ".sce", ".ent")) Then Exit Sub
        event_list = New Collection
        Dim pnames As New Collection, evt As cevents
        Dim myType As Type = GetType(cevents), pname As String = "", pval As String = "", i As Integer
        Dim p As System.Reflection.PropertyInfo
        Dim MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Replace(scenario, ".sce", ".ent"))
        'Using MyReader
        MyReader.TextFieldType = FileIO.FieldType.Delimited
        MyReader.SetDelimiters(",")
        Dim currentRow As String()
        currentRow = MyReader.ReadFields()
        For Each cfield As String In currentRow
            pnames.Add(cfield)
        Next
        While Not MyReader.EndOfData
            evt = New cevents
            Try
                currentRow = MyReader.ReadFields()
                i = 1
                For Each cfield As String In currentRow
                    p = myType.GetProperty(pnames(i))
                    'data changes
                    If cfield = "" Then

                    ElseIf p.PropertyType.Name = "Int32" Then
                        p.SetValue(evt, CInt(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "DateTime" Then
                        p.SetValue(evt, CDate(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Single" Then
                        p.SetValue(evt, CSng(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    ElseIf p.PropertyType.Name = "Boolean" Then
                        p.SetValue(evt, CBool(cfield), Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    Else
                        p.SetValue(evt, cfield, Reflection.BindingFlags.SetField, Nothing, Nothing, Nothing)
                    End If
                    i = i + 1
                    If i > pnames.Count Then Exit For
                Next
                event_list.Add(evt)
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message &
                "is not valid and will be skipped.")
            End Try
        End While

    End Sub
    Public Sub save_events()
        If IsNothing(event_list) Then Exit Sub
        file = My.Computer.FileSystem.OpenTextFileWriter(Replace(scenario, ".sce", ".ent"), False)
        Dim myType As Type = GetType(cevents)
        Dim x As String = "", y As String = "", n As String = ""
        Dim properties As System.Reflection.PropertyInfo() = myType.GetProperties()
        For Each p As System.Reflection.PropertyInfo In properties
            y = y + p.Name + ","
        Next
        file.WriteLine(y)
        For Each e As cevents In event_list
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
End Module
