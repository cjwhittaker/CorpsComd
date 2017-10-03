Public Class orbatmanager
    Public n As cUnit
    Dim no As TreeNode, mgt As String = "", parentnode As New TreeNode, orbatside As String
    Dim neworbat As Collection
    Dim file As System.IO.StreamWriter
    Private Sub selectnode(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles comdtree.NodeMouseClick
        Dim x As Integer = 1, parentnode As New TreeNode
        If comdtree.SelectedNode Is Nothing Then Exit Sub
        selectunit(orbat(e.Node.Text))
        If Control.ModifierKeys = Keys.Control And e.Button = Windows.Forms.MouseButtons.Left Then
            'insert new units
            mgt = "insert"
            comdtree.Enabled = False
            selectedunit.Enabled = True
            n = New cunit
            n.parent = e.Node.Text
            selectunit(n)
            parentnode = comdtree.SelectedNode
        ElseIf Control.ModifierKeys = Keys.Control And e.Button = Windows.Forms.MouseButtons.Right Then
            'insert sub units
            mgt = "insert-subunits"
            go_generate_subunits(orbat(e.Node.Text))
            populate_command_structure(orbatside)
        ElseIf Control.ModifierKeys = Keys.Shift And e.Button = Windows.Forms.MouseButtons.Left Then
            'mark to edit
            mgt = "edit"
            If e.Node.BackColor = Color.DarkGoldenrod Then
                e.Node.BackColor = Color.White
            Else
                e.Node.BackColor = Color.DarkGoldenrod
            End If
        ElseIf Control.ModifierKeys = Keys.Shift And e.Button = Windows.Forms.MouseButtons.Right Then
            ' edit
            Dim editunit As Boolean = False
            mgt = "edit"
            If e.Node.BackColor <> Color.DarkGoldenrod Then e.Node.BackColor = Color.DarkGoldenrod
            For Each anode In comdtree.Nodes
                If anode.backcolor = Color.DarkGoldenrod Then
                    editunit = True
                    no = anode
                    Exit For
                Else
                    no = check_next_to_edit(anode)
                    If Not (no Is Nothing) Then editunit = True : Exit For
                End If
            Next
            If editunit Then
                comdtree.Enabled = False
                selectedunit.Enabled = True
                n = New cunit
                n = orbat(no.Text)
                selectunit(n)
            End If

        ElseIf Control.ModifierKeys = Keys.Shift + Keys.Control Then
            'delete units
            If comdtree.SelectedNode.Level = 0 Then Exit Sub
            If e.Node.Nodes.Count = 0 Then
                orbat.Remove(e.Node.Text)
                e.Node.Remove()
            End If
        Else
        End If

    End Sub
    Private Function check_next_to_edit(ByVal x As TreeNode)
        check_next_to_edit = Nothing
        Dim t As TreeNode, t1 As TreeNode
        For Each t In x.Nodes
            If Not t.BackColor = Color.DarkGoldenrod Then
                t1 = check_next_to_edit(t)
                If Not (t1 Is Nothing) Then
                    If t1.BackColor = Color.DarkGoldenrod Then check_next_to_edit = t1 : Exit Function
                End If
            Else
                check_next_to_edit = t : Exit Function
            End If
        Next
    End Function

    Private Sub finish_edit() Handles confirm.Click
        Dim editunit As Boolean = False, t1 As TreeNode
        If mgt = "edit" Then
            orbat.Remove(n.title)
            If orbat.Contains(title.Text) Or nullentry() Then orbat.Add(n, n.title) : Exit Sub
            no.Text = title.Text
            no.BackColor = Color.White
            accept_unit_properties(n)
            For Each t In comdtree.Nodes
                t1 = check_next_to_edit(t)
                If Not (t1 Is Nothing) Then no = t1 : editunit = True : Exit For
            Next
            If editunit Then
                n = New cUnit
                n = orbat(no.Text)
                selectunit(n)
            Else
                comdtree.Enabled = True
                selectedunit.Enabled = False
            End If
        ElseIf mgt = "reject" Then
            If Not (no Is Nothing) Then no.BackColor = Color.White
            selectunit(n)
            For Each t In comdtree.Nodes
                t1 = check_next_to_edit(t)
                If Not (t1 Is Nothing) Then no = t1 : editunit = True : Exit For
            Next
            If editunit Then
                n = New cUnit
                n = orbat(no.Text)
                selectunit(n)
            Else
                comdtree.Enabled = True
                selectedunit.Enabled = False
                selectunit(orbat(comdtree.SelectedNode.Text))
            End If
        ElseIf mgt = "insert" Then
            If orbat.Contains(title.Text) Or nullentry() Then Exit Sub
            accept_unit_properties(n)
            comdtree.SelectedNode.Nodes.Add(n.title, n.title)
            comdtree.ExpandAll()
            comdtree.Enabled = True
            selectedunit.Enabled = False
        Else

        End If
        mgt = ""
    End Sub

    Private Sub accept_unit_properties(ByVal a As cUnit)
        Dim t As String = a.title
        With a
            .title = title.Text
            .comd = 6 - comd.SelectedIndex
            .quality = quality.SelectedItem
            .nation = orbatside
            .initial = Val(strength.Text)
        End With

        For Each i In orbat
            If i.parent = t Then i.parent = title.Text
        Next
        orbat.Add(a, a.title)
        selectunit(a)

    End Sub
    Private Sub selectunit(ByVal u As cUnit)
        title.Text = u.title
        comd.SelectedIndex = 6 - u.comd
        comd.Enabled = True
        quality.SelectedItem = u.quality
        strength.Text = u.initial
        If u.parent = "root" Then
            quality.SelectedIndex = 1
            comd.Enabled = False
            strength.Enabled = False
        ElseIf u.comd > 0 Or mgt = "insert" Then
            quality.SelectedIndex = 1
            strength.Enabled = False
            equip.Text = "HQ"
        ElseIf mgt = "reject" Then
            strength.Enabled = False
            equip.Text = "HQ"
        Else
            strength.Enabled = True
            equip.Text = equipment(u.equipment).title
        End If
    End Sub

    Private Sub reject_edit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reject.Click
        mgt = "reject"
        finish_edit()
    End Sub
    Private Function nullentry()
        If title.Text = "" Or quality.SelectedIndex < 0 Or comd.SelectedIndex < 0 Then
            nullentry = False
        ElseIf n.parent = "root" Then
            nullentry = False
        ElseIf u.comd > 6 - comd.SelectedIndex Then
            nullentry = False
        Else
            nullentry = True
        End If
    End Function
    Public Sub comdtree_ItemDrag(ByVal sender As System.Object, _
    ByVal e As System.Windows.Forms.ItemDragEventArgs) _
    Handles comdtree.ItemDrag

        'Set the drag node and initiate the DragDrop 
        DoDragDrop(e.Item, DragDropEffects.Move)

    End Sub
    Public Sub comdtree_DragOver(ByVal sender As System.Object, ByVal e As DragEventArgs) Handles comdtree.DragOver

        'Check that there is a TreeNode being dragged 
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeView raising the event (incase multiple on form)
        Dim selectedTreeview As TreeView = CType(sender, TreeView)

        'As the mouse moves over nodes, provide feedback to 
        'the user by highlighting the node that is the 
        'current drop target
        Dim pt As Point = _
            CType(sender, TreeView).PointToClient(New Point(e.X, e.Y))
        Dim targetNode As TreeNode = selectedTreeview.GetNodeAt(pt)

        'See if the targetNode is currently selected, 
        'if so no need to validate again
        If Not (selectedTreeview.SelectedNode Is targetNode) Then
            'Select the    node currently under the cursor
            selectedTreeview.SelectedNode = targetNode

            'Check that the selected node is not the dropNode and
            'also that it is not a child of the dropNode and 
            'therefore an invalid target
            Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

            Do Until targetNode Is Nothing
                If targetNode Is dropNode Then
                    e.Effect = DragDropEffects.None
                    Exit Sub
                End If
                targetNode = targetNode.Parent
            Loop
        End If

        'Currently selected node is a suitable target
        e.Effect = DragDropEffects.Move

    End Sub
    Public Sub comdtree_DragEnter(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles comdtree.DragEnter

        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", _
            True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Move
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If

    End Sub
    Public Sub comdtree_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles comdtree.DragDrop

        'Check that there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) = False Then Exit Sub

        'Get the TreeNode being dragged
        Dim dropNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)

        'The target node should be selected from the DragOver event
        Dim targetNode As TreeNode = comdtree.SelectedNode
        If targetNode.Text = dropNode.Text Then Exit Sub
        If orbat(targetNode.Text).comd < orbat(dropNode.Text).comd Then Exit Sub
        If targetNode Is Nothing Then Exit Sub
        orbat(dropNode.Text).parent = targetNode.Text
        'Remove the drop node from its current location
        dropNode.Remove()

        'If there is no targetNode add dropNode to the bottom of the TreeView root nodes, otherwise add it to the end of the dropNode child nodes
        'If targetNode Is Nothing Then
        'comdtree.Nodes.Add(dropNode)
        'Else
        targetNode.Nodes.Add(dropNode)
        'End If

        'Ensure the newley created node is visible to the user and select it
        dropNode.EnsureVisible()
        comdtree.SelectedNode = dropNode

    End Sub

    Public Sub populate_command_structure(ByVal currentside As String)
        Dim TopNode As TreeNode, u As New cUnit, x As Integer = 0
        orbatside = currentside
        For Each u In orbat
            If u.root And u.nation = orbatside Then Exit For
        Next
        comdtree.Nodes.Clear()
        TopNode = comdtree.Nodes.Add(key:=u.title, text:=u.title)
        CreateNodes(ParentNode:=TopNode, currentcomd:=u.title)
        comdtree.ExpandAll()
        comdtree.SelectedNode = TopNode
        selectunit(orbat(comdtree.SelectedNode.Text))
    End Sub
    Private Sub CreateNodes(ByRef ParentNode As TreeNode, ByRef currentcomd As String)
        Dim subNode As New TreeNode, commandname As String, x As Integer, keynode As String
        For x = 1 To orbat.Count
            If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                If Not orbat(x).embussed Then
                    commandname = orbat(x).Title
                    keynode = orbat(x).title
                    subNode = ParentNode.Nodes.Add(text:=commandname, key:=keynode)
                    subNode.Tag = keynode
                End If
                'subNode.BackColor = Color.White
                If orbat(x).comd > 0 Then
                    CreateNodes(ParentNode:=subNode, currentcomd:=orbat(x).title)
                End If
            End If
        Next
    End Sub

    Private Sub closeorbat(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim x As Integer = 0, root As cunit = Nothing
        For Each u As cunit In orbat
            x = 0
            If u.nation = orbatside Then
                For Each c As cunit In orbat
                    If c.parent = u.title Then x = x + 1
                Next
                u.no_of_units = x
            End If
        Next
        sort()

    End Sub

    Private Sub go_generate_subunits(ByVal u As cunit)
        If u.comd = 0 Then Exit Sub
        For Each x As cunit In orbat
            If InStr(x.title, "/" + u.title) > 0 Then Exit Sub
        Next
        generate_subunits.unittype.Items.Clear()
        For Each t As cunittype In unittypes
            If t.nation = u.nation And t.comd = u.comd Then generate_subunits.unittype.Items.Add(t.title)
        Next
        With generate_subunits
            .orbattitle.Text = u.title
            '.unittype.SelectedIndex = 0
            .quality.SelectedIndex = 1
            .ShowDialog()
        End With
    End Sub

    Private Sub printorbattofile()

        Dim Topunit As String, u As New cunit, x As Integer = 0
        file = My.Computer.FileSystem.OpenTextFileWriter(Strings.Left(scenario, (Len(scenario) - 4)) + "_" + orbatside + "_orbat.txt", False)

        For Each u In orbat
            x = x + 1
            If u.nation = orbatside And u.parent = "root" Then Exit For
        Next
        Topunit = u.title
        printunit(Topunit, 0)
        file.Close()

    End Sub
    Private Sub printunit(ByVal currentcomd As String, ByVal indentlevel As Integer)
        Dim n As String = orbat(currentcomd).title + " " + IIf(orbat(currentcomd).equipment <> "", "(" + orbat(currentcomd).equipment + ")", "")
        file.WriteLine(Space(indentlevel * 5) + n + Space(50 - (indentlevel * 5) - Len(n)) + orbat(currentcomd).text_status)

        For x = 1 To orbat.Count
            If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                printunit(orbat(x).title, indentlevel + 1)
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        printorbattofile()
    End Sub
    Private Sub reorderorbat(ByRef x As cunit)
        If InStr(x.title, "/") = 0 Then
            x.sort = x.title
        ElseIf InStr(x.title, "HQ") <> 0 Then
            x.sort = Chr(44) + Mid(x.title, InStr(x.title, "/")) + Strings.Left(x.title, InStr(x.title, "/") - 1)
        Else
            x.sort = Mid(x.title, InStr(x.title, "/")) + Strings.Left(x.title, InStr(x.title, "/") - 1)
        End If
        neworbat.Add(x, x.title)
        If x.comd = 0 Then
            Exit Sub
        End If
        For Each u As cunit In orbat
            If u.parent = x.title Then
                reorderorbat(u)
            End If
        Next
    End Sub


    Private Sub select_type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each x As cunittype In unittypes
            If u.nation = x.nation And u.comd = x.comd Then
                generate_subunits.unittype.Items.Add(x.title)
            End If
        Next
        With generate_subunits
            .orbattitle.Text = u.title
            .ShowDialog()
        End With
    End Sub

    Private Sub loadvehicles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadvehicles.Click
        Dim passenger As String = "", sub_id As String = ""
        If InStr(sender.text, "Embus") > 0 Then
            loadvehicles.Text = "Debus all Passengers"
            For Each u As cunit In orbat
                If u.nation = orbatside Then
                    If u.troopcarrier And u.loaded = "" Then
                        sub_id = Strings.Left(u.title, 1) + "1"
                        passenger = sub_id + Mid(u.title, 2)
                        If orbat.Contains(passenger) Then
                            u.loaded = passenger
                            orbat(u.loaded).loaded = u.title
                        End If
                    End If
                End If
            Next

        Else
            loadvehicles.Text = "Embus all Passengers"
            For Each u As cunit In orbat
                If u.nation = orbatside Then
                    If u.troopcarrier And Not u.loaded = "" Then
                        orbat(u.loaded).loaded = ""
                        u.loaded = ""
                    End If
                End If
            Next

        End If
        populate_command_structure(orbatside)
    End Sub
End Class