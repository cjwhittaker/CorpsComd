Public Class orbatmanager
    Public n As cunit, orbatside As String
    Dim no As TreeNode, mgt As String = "", parentnode As New TreeNode, currcomd As Integer, col As Collection
    Dim neworbat As Collection
    Dim file As System.IO.StreamWriter
    Private Sub selectnode(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles comdtree.NodeMouseClick
        Dim x As Integer = 1, parentnode As New TreeNode
        If comdtree.SelectedNode Is Nothing Then Exit Sub
        selectunit(orbat(e.Node.Text))
        currcomd = orbat(e.Node.Text).comd
        mgt = ""
        If Control.ModifierKeys = Keys.Control And e.Button = Windows.Forms.MouseButtons.Left And currcomd > 0 Then
            'insert new units
            mgt = "insert"
            purpose.Text = "Inserting a new Command"
            comdtree.Enabled = False
            selectedunit.Enabled = True
            n = New cunit
            n.parent = e.Node.Text
            selectunit(n)
            parentnode = comdtree.SelectedNode
        ElseIf Control.ModifierKeys = Keys.Control And e.Button = Windows.Forms.MouseButtons.Right And currcomd > 0 Then
            'insert sub units
            mgt = "insert-subunits"
            go_generate_subunits(orbat(e.Node.Text))
            populate_command_structure(comdtree, orbatside, "Orbat")
        ElseIf Control.ModifierKeys = Keys.Alt And e.Button = Windows.Forms.MouseButtons.Left And e.Node.Text <> comdtree.TopNode.Text Then
            'Clone Unit
            mgt = "clone"
            purpose.Text = "Cloning a Command"
            no = e.Node
            comdtree.Enabled = False
            selectedunit.Enabled = True
            n = New cunit
            n.parent = e.Node.Text
            selectunit(n)

        ElseIf Control.ModifierKeys = Keys.Shift And e.Button = Windows.Forms.MouseButtons.Left Then
            'mark to edit
            mgt = "edit"
            purpose.Text = "Editing a Command"
            n = New cunit
            n = orbat(e.Node.Text)
            selectunit(n)
            If e.Node.BackColor = golden Then
                e.Node.BackColor = nostatus
            Else
                e.Node.BackColor = golden
            End If
        ElseIf Control.ModifierKeys = Keys.Shift And e.Button = Windows.Forms.MouseButtons.Right Then
            ' edit
            Dim editunit As Boolean = False
            mgt = "edit"
            purpose.Text = "Editing a Command"
            If e.Node.BackColor <> golden Then e.Node.BackColor = golden
            group_edit()
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


    Private Sub group_edit()
        no = check_next_to_edit(comdtree.TopNode)
        If Not no Is Nothing Then
            no.BackColor = nostatus
            comdtree.Enabled = False
            selectedunit.Enabled = True
            n = New cunit
            n = orbat(no.Text)
            selectunit(n)
        Else
            comdtree.Enabled = True
            selectedunit.Enabled = False
            purpose.Text = ""

        End If
    End Sub

    Private Function check_next_to_edit(ByVal x As TreeNode)
        check_next_to_edit = Nothing
        Dim t As TreeNode, t1 As TreeNode
        For Each t In x.Nodes
            If Not t.BackColor = golden Then
                t1 = check_next_to_edit(t)
                If Not (t1 Is Nothing) Then
                    If t1.BackColor = golden Then check_next_to_edit = t1 : Exit Function
                End If
            Else
                check_next_to_edit = t : Exit Function
            End If
        Next
    End Function

    Private Sub finish_edit(sender As Object, e As EventArgs) Handles confirm.Click, reject.Click
        If mgt = "edit" And sender.name = "confirm" Then
            currcomd = orbat(orbat(no.Text).parent).comd
            orbat.Remove(no.Text)
            If orbat.Contains(title.Text) Or nullentry() Then
                orbat.Add(n, n.title)
            Else
                accept_unit_properties(n)
                If no.Text <> title.Text And orbat(title.Text).comd > 0 Then
                    For Each u As cunit In orbat
                        If u.parent = no.Text Then u.parent = title.Text
                    Next
                End If
                no.Text = title.Text
            End If
            group_edit()
        ElseIf sender.name = "reject" Then
            group_edit()
        ElseIf mgt = "insert" And sender.name = "confirm" Then
            If orbat.Contains(title.Text) Or nullentry() Then Exit Sub
            accept_unit_properties(n)
            comdtree.SelectedNode.Nodes.Add(n.title, n.title)
            comdtree.ExpandAll()
            comdtree.Enabled = True
            selectedunit.Enabled = False
            purpose.Text = ""
        ElseIf mgt = "clone" And sender.name = "confirm" Then
            If orbat.Contains(title.Text) Then title.Text = renamed(title.Text)
            cloneorbat(no, no.Text, orbat(no.Text).parent)
            populate_command_structure(comdtree, orbatside, "Orbat")
            comdtree.Enabled = True
            selectedunit.Enabled = False
            selectunit(orbat(comdtree.SelectedNode.Text))
            purpose.Text = ""
        Else

        End If
    End Sub

    Private Sub cloneorbat(nt As TreeNode, origin As String, newpar As String)
        Dim c As New cunit, par As String = orbat(nt.Text).parent
        c = orbat(nt.Text).Clone
        If InStr(c.title, origin) > 0 Then
            c.title = Replace(c.title, origin, title.Text)
        Else
            c.title = renamed(c.title)
        End If
        If nt.Text <> no.Text Then
            If InStr(c.parent, origin) > 0 Then
                c.parent = Replace(c.parent, origin, title.Text)
            Else
                c.parent = newpar
            End If

        End If
        orbat.Add(c, c.title)
        For Each nn As TreeNode In nt.Nodes
            cloneorbat(nn, origin, c.title)
        Next
    End Sub

    Private Sub accept_unit_properties(ByVal a As cUnit)
        Dim t As String = a.title
        With a
            .title = title.Text
            .comd = 6 - comd.SelectedIndex
            .quality = Val(quality.SelectedItem)
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
        quality.SelectedItem = Trim(Str(u.quality))
        strength.Text = u.initial
        If mgt = "insert" Then
            comd.SelectedIndex = 6 - orbat(n.parent).comd + 1
        ElseIf u.parent = "root" Then
            comd.Enabled = False
            strength.Enabled = False
        ElseIf mgt = "clone" Then
            comd.Enabled = False
            strength.Enabled = False
            quality.Enabled = False
            equip.Enabled = False
        ElseIf u.comd > 0 Or mgt = "insert" Then
            strength.Enabled = False
            equip.Text = "HQ"
        ElseIf mgt = "reject" Then
            strength.Enabled = False
            equip.Text = "HQ"
        ElseIf u.comd = 0 Then
            strength.Enabled = True
            equip.Enabled = False
            equip.Text = u.equipment
        Else
        End If
    End Sub

    Private Sub comd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comd.SelectedIndexChanged
        If 6 - sender.SelectedIndex <= 0 Then
            strength.Enabled = True
            'equip.Enabled = True
            'equip.Text = u.equipment
        Else
            strength.Enabled = False
            equip.Enabled = False
            equip.Text = "HQ"
        End If
    End Sub

    Private Function nullentry()
        If title.Text = "" Or quality.SelectedIndex < 0 Or comd.SelectedIndex < 0 Then
            nullentry = False
        ElseIf n.parent = "root" Then
            nullentry = False
        ElseIf currcomd > 6 - comd.SelectedIndex Then
            nullentry = False
        Else
            nullentry = True
        End If
    End Function

    Public Sub comdtree_ItemDrag(ByVal sender As System.Object,
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
        Dim pt As Point =
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

    Public Sub comdtree_DragEnter(ByVal sender As System.Object,
        ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles comdtree.DragEnter

        'See if there is a TreeNode being dragged
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode",
            True) Then
            'TreeNode found allow move effect
            e.Effect = DragDropEffects.Move
        Else
            'No TreeNode found, prevent move
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Public Sub comdtree_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles comdtree.DragDrop
        Dim l As String = ""
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
        orbat(dropNode.Text).arrives = orbat(targetNode.Text).arrives
        l = orbat(dropNode.Text).loaded
        If orbat(dropNode.Text).loaded <> "" Then orbat(orbat(dropNode.Text).loaded).parent = targetNode.Text

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
        Dim n As String = orbat(currentcomd).title + " " + IIf(orbat(currentcomd).equipment <> "", "(" + Trim(Str(orbat(currentcomd).strength) + "-" + orbat(currentcomd).equipment + ")"), "")
        file.WriteLine(Space(indentlevel * 5) + n) 'Space(50 - (indentlevel * 5) - Len(n)) + orbat(currentcomd).text_status)

        For x = 1 To orbat.Count
            If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                printunit(orbat(x).title, indentlevel + 1)
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        printorbattofile()
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
        Dim tpt As String = ""
        If InStr(sender.text, "Embus") > 0 Then
            loadvehicles.Text = "Dismount all Passengers"
            For Each u As cunit In orbat
                If u.nation = orbatside Then
                    If Not u.troopcarrier And u.loaded = "" And u.debussed Then
                        tpt = Replace(u.title, "#", "")
                        If orbat.Contains(tpt) Then
                            u.loaded = tpt
                            u.debussed = False
                            orbat(tpt).loaded = u.title
                            orbat(tpt).debussed = False
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
                        orbat(u.loaded).debussed = True
                        u.loaded = ""
                        u.debussed = True
                    End If
                End If
            Next

        End If
        populate_command_structure(comdtree, orbatside, "Orbat")
    End Sub

    Public Function renamed(ByVal title As String)
        Dim prefix As String, t As String
        If InStr(title, "/") = 0 Then
            prefix = "1"
            t = "/" + title
        Else
            prefix = Strings.Left(title, InStr(title, "/") - 1)
            t = Strings.Mid(title, InStr(title, "/"))
        End If
        renamed = prefix + t
        Do Until Not orbat.Contains(renamed)
            If Val(prefix) > 0 Then
                prefix = Trim(Val(prefix + 1))
            Else
                prefix = Chr(Asc(prefix) + 1)
            End If
            renamed = prefix + t
        Loop

    End Function

End Class
