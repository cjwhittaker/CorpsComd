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
            insert_formation_click(insert_formation, Nothing)
        ElseIf Control.ModifierKeys = Keys.Control And e.Button = Windows.Forms.MouseButtons.Right And currcomd > 0 Then
            'insert sub units
            generate_sub_units_Click(generate_sub_units, Nothing)
        ElseIf Control.ModifierKeys = Keys.Alt And e.Button = Windows.Forms.MouseButtons.Left And e.Node.Text <> comdtree.Nodes(0).Text Then
            'Clone Unit
            clone_formation_Click(clone_formation, Nothing)
        ElseIf e.Button = Windows.Forms.MouseButtons.right Then
            'mark to edit
            mgt = "edit"
            purpose.Text = "Editing a Command"
            n = New cunit
            n = orbat(e.Node.Text)
            selectunit(n)
            If e.Node.BackColor = golden Then e.Node.BackColor = nostatus Else e.Node.BackColor = golden
        ElseIf Control.ModifierKeys = Keys.Shift And e.Button = Windows.Forms.MouseButtons.left Then
            comdtree.SelectedNode.Expand()
            If comdtree.SelectedNode.BackColor = nostatus Then comdtree.SelectedNode.BackColor = golden Else comdtree.SelectedNode.BackColor = nostatus
            select_all(comdtree.SelectedNode, comdtree.SelectedNode.BackColor)
        ElseIf Control.ModifierKeys = Keys.Shift + Keys.Control Then
            'delete units
            delete_unit_Click(delete_unit, Nothing)
        Else
        End If
    End Sub
    Private Sub comdtree_DoubleClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then Exit Sub
        comdtree.SelectedNode.Expand()
        If comdtree.SelectedNode.BackColor = nostatus Then comdtree.SelectedNode.BackColor = golden Else comdtree.SelectedNode.BackColor = nostatus
        select_all(comdtree.SelectedNode, comdtree.SelectedNode.BackColor)
    End Sub
    Private Sub select_all(no As TreeNode, c As Color)
        For Each n As TreeNode In no.Nodes
            select_all(n, c)
            n.BackColor = c
        Next
    End Sub
    Private Sub group_edit()
        'Dim no As TreeNode
        'Do
        no = next_edit(comdtree.Nodes(0))
        'Loop Until no Is Nothing
        'no = check_next_to_edit(comdtree.Nodes(0))
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
            mgt = ""

        End If
    End Sub
    Private Function next_edit(currentcomd As TreeNode)
        If currentcomd.BackColor = golden Then
            next_edit = currentcomd
            Exit Function
        End If
        For Each no As TreeNode In currentcomd.Nodes
            If Not no.BackColor = golden Then
                currentcomd = next_edit(no)
                If Not currentcomd Is Nothing Then
                    If currentcomd.BackColor = golden Then next_edit = currentcomd : Exit Function
                End If
            Else
                next_edit = no
                Exit Function
            End If
        Next
    End Function


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
    Public Sub clear_selected_unit()
        title.Text = ""
        arty_rating.Text = ""
        equip.Text = ""
        strength.Text = ""
        comd.SelectedIndex = -1
        quality.SelectedIndex = -1
    End Sub
    Private Sub finish_edit(sender As Object, e As EventArgs) Handles confirm.Click, reject.Click
        If sender.name = "reject" Or title.Text = "" Then
            group_edit()
            clear_selected_unit()
        ElseIf mgt = "edit" And sender.name = "confirm" Then
            currcomd = orbat(n.parent).comd
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
        ElseIf mgt = "insert" And sender.name = "confirm" Then
            currcomd = orbat(n.parent).comd
            If orbat.Contains(title.Text) Or nullentry() Then Exit Sub
            accept_unit_properties(n)
            comdtree.SelectedNode.Nodes.Add(n.title, n.title)
            comdtree.ExpandAll()
            comdtree.Enabled = True
            selectedunit.Enabled = False
            purpose.Text = ""
            clear_selected_unit()
            mgt = ""
        ElseIf mgt = "clone" And sender.name = "confirm" Then
            If orbat.Contains(title.Text) Then title.Text = renamed(title.Text)
            cloneorbat(no, no.Text, orbat(no.Text).parent)
            populate_command_structure(comdtree, orbatside, "Orbat")
            comdtree.Enabled = True
            selectedunit.Enabled = False
            selectunit(orbat(comdtree.SelectedNode.Text))
            purpose.Text = ""
            mgt = ""

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

    Private Sub accept_unit_properties(ByVal a As cunit)
        Dim t As String = a.title
        With a
            .title = title.Text
            .comd = 6 - comd.SelectedIndex
            .quality = Val(quality.SelectedItem)
            .nation = orbatside
            .initial = Val(strength.Text)
            .arty_int = Val(arty_rating.Text)
        End With

        For Each i As cunit In orbat
            If i.parent = t Then i.parent = title.Text
        Next
        orbat.Add(a, a.title)
        selectunit(a)

    End Sub

    Private Sub selectunit(ByVal u As cunit)
        title.Text = u.title
        comd.SelectedIndex = 6 - u.comd
        comd.Enabled = True
        quality.SelectedItem = Trim(Str(u.quality))
        strength.Text = u.strength
        arty_rating.Text = u.arty_int
        If mgt = "insert" Then
            comd.SelectedIndex = 6 - orbat(n.parent).comd + 1
            quality.SelectedItem = Trim(Str(orbat(n.parent).quality))

            If u.comd > 0 Or mgt = "insert" Then
                strength.Enabled = False
                equip.Text = "HQ"
                arty_rating.Enabled = True
            End If
            'ElseIf u.parent = "root" Then
            'comd.Enabled = False
            'strength.Enabled = False
        ElseIf mgt = "edit" Then
            If u.comd > 0 Then
                comd.Enabled = True
                strength.Enabled = False
                quality.Enabled = True
                equip.Enabled = False
                arty_rating.Enabled = True
            Else
                comd.Enabled = False
                strength.Enabled = True
                quality.Enabled = True
                equip.Enabled = False
                equip.Text = u.equipment
                arty_rating.Enabled = False
            End If
        ElseIf mgt = "clone" Then
            comd.Enabled = False
            strength.Enabled = False
            quality.Enabled = False
            equip.Enabled = False
            arty_rating.Enabled = False
        ElseIf u.comd = 0 Then
            equip.Text = u.equipment
        Else
        End If
    End Sub

    Private Sub comd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comd.SelectedIndexChanged
        Dim comd_level As Integer = 6 - sender.SelectedIndex
        If comd_level = 0 Then
            strength.Enabled = True
            'equip.Enabled = True
            'equip.Text = u.equipment
        ElseIf comd_level <= 6 Then
            arty_rating.Enabled = False
            strength.Enabled = False
            equip.Enabled = False
            equip.Text = "HQ"
        Else
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
        If InStr(dropNode.Text, "#") > 0 Then
            l = orbat(dropNode.Text).carrying
            If l = "" Then
                If targetNode.Text <> Replace(dropNode.Text, "#", "") Then Exit Sub
                orbat(targetNode.Text).carrying = dropNode.Text
                orbat(dropNode.Text).carrying = targetNode.Text
                orbat(dropNode.Text).parent = orbat(targetNode.Text).parent
            Else
                orbat(l).carrying = ""
                orbat(dropNode.Text).carrying = ""
            End If
        End If
        'Remove the drop node from its current location
        dropNode.Remove()

        'If there is no targetNode add dropNode to the bottom of the TreeView root nodes, otherwise add it to the end of the dropNode child nodes
        'If targetNode Is Nothing Then
        'comdtree.Nodes.Add(dropNode)
        'Else
        targetNode.Nodes.Add(dropNode)
        'End If
        'Ensure the newley created node is visible to the user and select it
        'dropNode.EnsureVisible()
        'comdtree.SelectedNode = dropNode
    End Sub

    Private Sub go_generate_subunits(ByVal u As cunit)
        If u.comd = 0 Then Exit Sub
        For Each x As cunit In orbat
            If InStr(x.title, "/" + u.title) > 0 Then Exit Sub
        Next
        unittype.Items.Clear()
        For Each t As csubunit In TOE
            If UCase(t.nation) = UCase(u.nation) And t.comd = u.comd And Not unittype.Items.Contains(t.title) Then
                unittype.Items.Add(t.title)
            End If
        Next
        If unittype.Items.Count > 0 Then
            select_unit_template.Enabled = True
            unittype.SelectedIndex = 0
            sub_unit_quality.SelectedItem = Trim(Str(orbat(comdtree.SelectedNode.Text).quality))
            sub_1.BackColor = defa
            sub_a.BackColor = defa
        Else
            select_unit_template.Enabled = False
            Exit Sub
        End If

    End Sub

    Private Sub printorbattofile()

        Dim Topunit As String, u As New cunit, x As Integer = 0
        file = My.Computer.FileSystem.OpenTextFileWriter(Strings.Left(scenario, (Len(scenario) - 4)) + "_" + orbatside + "_orbat.txt", False)

        For Each u In orbat
            x = x + 1
            If UCase(u.nation) = UCase(orbatside) And u.parent = "root" Then Exit For
        Next
        Topunit = u.title
        printunit(Topunit, 0)
        file.Close()

    End Sub


    Private Sub insert_formation_click(sender As Object, e As EventArgs) Handles insert_formation.Click
        mgt = "insert"
        purpose.Text = "Inserting a new Command"
        comdtree.Enabled = False
        selectedunit.Enabled = True
        n = New cunit
        n.parent = comdtree.SelectedNode.Text
        selectunit(n)
        parentnode = comdtree.SelectedNode

    End Sub

    Private Sub generate_sub_units_Click(sender As Object, e As EventArgs) Handles generate_sub_units.Click
        If comdtree.SelectedNode.Text Is Nothing Then Exit Sub
        mgt = "insert-subunits"
        go_generate_subunits(orbat(comdtree.SelectedNode.Text))
        'populate_command_structure(comdtree, orbatside, "Orbat")

    End Sub

    Private Sub clone_formation_Click(sender As Object, e As EventArgs) Handles clone_formation.Click
        mgt = "clone"
        purpose.Text = "Cloning a Command"
        no = comdtree.SelectedNode
        comdtree.Enabled = False
        selectedunit.Enabled = True
        'n = New cunit
        'n.parent = comdtree.SelectedNode.Text
        selectunit(orbat(comdtree.SelectedNode.Text))
    End Sub

    Private Sub edit_selected_units_Click(sender As Object, e As EventArgs) Handles edit_selected_units.Click
        mgt = "edit"
        purpose.Text = "Editing a Command"
        If comdtree.SelectedNode.BackColor <> golden Then comdtree.SelectedNode.BackColor = golden
        group_edit()
        Dim t As String = orbat(32).title

    End Sub

    Private Sub delete_unit_Click(sender As Object, e As EventArgs) Handles delete_unit.Click
        If comdtree.SelectedNode.Text = comdtree.Nodes(0).Text Then Exit Sub
        'If comdtree.SelectedNode.Nodes.Count = 0 Then remove_comd_branches(comdtree.SelectedNode.Text)
        remove_comd_branches(comdtree.SelectedNode.Text)
        orbat.Remove(comdtree.SelectedNode.Text)
        populate_command_structure(comdtree, orbatside, "Orbat")
    End Sub
    Private Sub remove_comd_branches(parent As String)
        Dim x As Integer = 1
        Do
            If orbat(x).parent = parent Then
                If orbat(x).comd > 0 Then
                    remove_comd_branches(orbat(x).title)
                    orbat.Remove(x)
                Else
                    orbat.Remove(x)
                End If
                If x = orbat.Count Then Exit Sub
            Else
                x = x + 1
            End If
        Loop Until x = orbat.Count
    End Sub
    Private Sub printunit(ByVal currentcomd As String, ByVal indentlevel As Integer)
        Dim n As String = orbat(currentcomd).title + " " + IIf(orbat(currentcomd).equipment <> "", "(" + Trim(Str(orbat(currentcomd).strength) + "-" + orbat(currentcomd).equipment + ")"), "")
        file.WriteLine(Space(indentlevel * 5) + n) 'Space(50 - (indentlevel * 5) - Len(n)) + orbat(currentcomd).text_status)

        For x As Integer = 1 To orbat.Count
            If orbat(x).parent = currentcomd And orbat(x).comd < 6 Then
                printunit(orbat(x).title, indentlevel + 1)
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printorbat.Click
        printorbattofile()
    End Sub

    Private Sub reject_sub_Click(sender As Object, e As EventArgs) Handles reject_sub.Click
        unittype.SelectedIndex = -1
        sub_unit_quality.SelectedIndex = -1
        sub_1.BackColor = defa
        sub_a.BackColor = defa
        select_unit_template.Enabled = False
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

    Private Sub sub_identifers(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sub_1.Click, sub_a.Click
        If (sender.name = "sub_a" And sender.backcolor = defa) Or (sender.name = "sub_1" And sender.backcolor = golden) Then
            sub_1.BackColor = defa
            sub_a.BackColor = golden
        ElseIf (sender.name = "sub_1" And sender.backcolor = defa) Or (sender.name = "sub_a" And sender.backcolor = golden) Then
            sub_a.BackColor = defa
            sub_1.BackColor = golden
        Else

        End If
    End Sub

    Private Sub sub_unit_quality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sub_unit_quality.SelectedIndexChanged
        If Val(sub_unit_quality.SelectedItem) > orbat(comdtree.SelectedNode.Text).quality Then sub_unit_quality.SelectedItem = Str(orbat(comdtree.SelectedNode.Text).quality)
    End Sub
    Private Sub generate_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generate.Click
        Dim n As New cunit, i As Integer = 0, l As String = "", passengers As Boolean = False, t As String = "", sub_unit_comd As String = "", orbattitle As String = comdtree.SelectedNode.Text
        Dim same_desig As Boolean = False, ch As Integer = 65, pas As String = "*", subunits As Integer = 0, desig As String = "", unit_root As Boolean = True
        If Not sub_1.BackColor = golden And Not sub_a.BackColor = golden Then Exit Sub
        For Each s As csubunit In TOE
            If s.title = unittype.SelectedItem Then
                If unit_root Then subunits = s.quantity : unit_root = False
                If s.airhq Then orbat(orbattitle).role = "Air HQ"
                If s.quantity > 9 Or sub_a.BackColor = golden Then
                    ch = 65
                Else
                    ch = 49
                End If
                'If s.desig = "RECON/" Then Stop
                If s.desig <> desig Then
                    desig = s.desig
                    same_desig = False
                Else
                    same_desig = True
                End If
                If s.passengers Then
                    'Stop
                    i = i - s.quantity
                ElseIf same_desig Then
                    i = i
                Else
                    i = 0
                End If
                For x As Integer = 0 To s.quantity - 1
                    If s.desig = "" Then t = Chr(ch + i) Else t = Chr(ch + IIf(same_desig, i, x))

                    If s.unit_comd > 0 Then
                        l = IIf(s.desig = "", Chr(49 + x), s.desig) + "-"
                    ElseIf s.equipment = "ACV" And s.desig = "" Then
                        l = "HQ/"
                    ElseIf s.desig <> "" Then
                        If s.passengers Then
                            If s.sub_comd And s.quantity <= subunits Then l = Replace(s.desig, "/", pas + "/") + t + "-" Else l = IIf(s.sub_units, t + pas + "/", "1/") + s.desig
                        Else
                            If s.sub_comd And s.quantity <= subunits Then l = s.desig + t + "-" Else l = IIf(s.sub_units, t + "/", "") + s.desig
                        End If
                    ElseIf s.desig = "" Then
                        If s.passengers Then l = t + pas + "/" Else l = t + "/"
                    Else
                    End If
                    If s.sub_comd Then
                        sub_unit_comd = IIf(s.quantity > subunits, Trim(Str((Int(x / subunits)) + 1)) + "-", Trim(Str(x + 1)) + "-")
                    End If
                    If s.sub_units Or s.quantity > 1 Or (same_desig And s.unit_comd = 0 And s.equipment <> "ACV") Or (s.desig = "" And s.unit_comd = 0 And s.equipment <> "ACV") Then
                        i = i + 1
                    End If
                    n = New cunit
                    If InStr(l, pas) > 0 Then
                        orbat(Replace(Trim(l) + orbattitle, pas, "")).carrying = Replace(Trim(l) + orbattitle, pas, "#")
                        n.carrying = Replace(Trim(l) + orbattitle, pas, "")
                        l = Replace(l, pas, "#")
                    End If
                    With n
                        .title = Trim(l) + orbattitle
                        .comd = s.unit_comd
                        .nation = s.nation
                        .initial = IIf(s.unit_comd = 0, s.strength, 0)
                        .strength = IIf(s.unit_comd = 0, s.strength, 0)
                        .equipment = IIf(s.unit_comd = 0, s.equipment, "")
                        .quality = Val(sub_unit_quality.SelectedItem)
                        .parent = IIf(s.sub_comd, sub_unit_comd + orbattitle, orbattitle)
                    End With
                    If n.comd = 0 Then n.role = "|" + eq_list(s.equipment).role + "|"
                    Dim j As Integer = 0
                    Do While orbat.Contains(n.title)
                        n.title = Trim(Chr(49 + j)) + "/" + Mid(n.title, InStr(n.title, "/"))
                        j = j + 1
                    Loop
                    orbat.Add(n, n.title)
                Next
                'i = i + 1
                'If n.troopcarrier Then passengers = True Else passengers = False
            End If
        Next
        select_unit_template.Enabled = False
        sub_1.BackColor = defa
        sub_a.BackColor = defa
        sub_unit_quality.SelectedIndex = -1
        unittype.SelectedIndex = -1
        populate_command_structure(comdtree, orbatside, "Orbat")

    End Sub

End Class
