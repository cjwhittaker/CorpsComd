Module utilities_file_handling
    Public Sub load_orbat()
        If Not My.Computer.FileSystem.FileExists(Strings.Left(scenario, (Len(scenario) - 4)) + ".orb") Then Exit Sub

        orbat = New Collection
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Strings.Left(scenario, (Len(scenario) - 4)) + ".orb")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                u = New cunit
                Try
                    currentRow = MyReader.ReadFields()
                    u.loadfromfile(currentRow)
                    orbat.Add(u, u.title, After:=orbat.Count)
                    'orbat.Add(u, u.unitid, After:=orbat.Count)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & _
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using

    End Sub
    Public Sub save_orbat()
        If scenario Is Nothing Then Exit Sub
        Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(Strings.Left(scenario, (Len(scenario) - 4)) + ".orb", False)
        For Each u As cunit In orbat
            file.WriteLine(u.savetofile)
        Next
        file.Close()
    End Sub

    Public Sub load_equipment()
        If Not My.Computer.FileSystem.FileExists("equipment.dat") Then Exit Sub

        equipment = New Collection
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("equipment.dat")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                e = New cequipment
                Try
                    currentRow = MyReader.ReadFields()
                    e.loadfromfile(currentRow)
                    equipment.Add(e, e.title, After:=equipment.Count)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & _
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using

    End Sub
    Public Sub save_equipment()
        Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("equipment.dat", False)
        For Each e As cequipment In equipment
            file.WriteLine(e.savetofile)
        Next
        file.Close()
    End Sub
    Public Sub load_subunits()
        If Not My.Computer.FileSystem.FileExists("subunits.dat") Then Exit Sub
        TOE = New Collection
        unittypes = New Collection
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("subunits.dat")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                subunit = New csubunit
                Try
                    currentRow = MyReader.ReadFields()
                    subunit.loadfromfile(currentRow)
                    TOE.Add(subunit, After:=TOE.Count)
                    If Not unittypes.Contains(subunit.title) Then
                        unittype = New cunittype
                        With unittype
                            .nation = subunit.nation
                            .title = subunit.title
                            .comd = subunit.comd
                        End With
                        unittypes.Add(unittype, unittype.title)
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & _
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using

    End Sub
    Public Sub save_subunits()
        Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("subunits.dat", False)
        For Each subunit As csubunit In TOE
            file.WriteLine(subunit.savetofile)
        Next
        file.Close()
    End Sub
    Sub savedata(ByVal scenariofile As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(scenariofile, False)
        file.WriteLine("player1=," + My.Forms.scenariodefaults.player1.Text + "," + (My.Forms.scenariodefaults.player1_init.Text))
        file.WriteLine("player2=," + My.Forms.scenariodefaults.player2.Text + "," + (My.Forms.scenariodefaults.player2_init.Text))
        file.WriteLine("starttime=," + scenariodefaults.start_time.Text)
        file.WriteLine("dusk=," + scenariodefaults.Dusk.Text)
        file.WriteLine("currenttime=," + scenariodefaults.Current_time.Text)
        file.WriteLine("gameturn=," + scenariodefaults.gameturn.Text)
        file.WriteLine("ph=," + ph)
        file.WriteLine("nph=," + nph)
        file.WriteLine("player phase=," + Str(scenariodefaults.playerphase))
        file.WriteLine("game phase=," + Str(scenariodefaults.phase))
        file.WriteLine("smoke fired=," + Str(smokefiredlasturn) + "," + Str(smokefiredthisturn))
        file.Close()
    End Sub
End Module
