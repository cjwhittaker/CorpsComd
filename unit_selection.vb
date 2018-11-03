Public Class unit_selection
    Public i As Integer = -1, subject As cunit

    Private Sub units_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles units.Click
        If units.SelectedItems.Count = 0 Then Exit Sub
        i = units.FocusedItem.Index
        If Me.Tag = "Call for Fire" Then
            If units.Items(i).Focused And units.Items(i).BackColor <> golden Then
                If Not subject.disrupted Then units.Items(i).BackColor = golden
            ElseIf units.Items(i).Focused And units.Items(i).BackColor = golden Then
                units.Items(i).BackColor = nostatus
                If Me.Tag = "Call for Fire" Then
                    If orbat(units.FocusedItem.Text).rockets = 0 Then
                        units.FocusedItem.BackColor = in_ds
                    ElseIf orbat(units.FocusedItem.Text).rockets = 1 Then
                        units.FocusedItem.BackColor = can_observe
                    Else
                        units.FocusedItem.BackColor = not_on_net
                    End If

                End If
            Else
            End If
            'takeaction.Focus()
        ElseIf Not (Me.Tag = "Deploy Aircraft" Or Me.Tag = "Recover Aircraft") Then
            If units.Items(i).BackColor = golden Then
                units.Items(i).BackColor = nostatus
            Else
                For Each l As ListViewItem In units.Items
                    l.BackColor = nostatus
                Next
                units.Items(i).BackColor = golden
            End If
        Else
        End If
        units.SelectedItems.Clear()
    End Sub

    Private Sub selectnode(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles comdtree.NodeMouseClick
        Dim x As Integer = 1, parentnode As New TreeNode
        If comdtree.SelectedNode Is Nothing Then Exit Sub
        'selectunit(orbat(e.Node.Text))
        'If commanders.Items.Count <> 1 And commander.title = e.Item.Text Then Exit Sub
        'subject = orbat(e.Node.Text)
        comdtree.HideSelection = True
        If e.Node.BackColor = nostatus Then
            e.Node.BackColor = golden
        Else
            e.Node.BackColor = nostatus
        End If
        takeaction.Focus()
    End Sub

    Private Sub execute() Handles takeaction.Click
        If Me.Tag = "Deploy Aircraft" Then
            Me.Close()
        End If
    End Sub

    Private Sub unit_selection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim side As String = " - Game Turn " + scenariodefaults.gameturn.Text
        With Me
            .Text = Tag + " Phase for " + side
            .title.Text = IIf(Tag = "Deploy Aircraft", "Deploy the following aircraft to table", "Recover and Land the following aircraft from table")
            .takeaction.Text = "Completed"
            .units.Columns(1).Text = "Task"
            .units.Columns(2).Text = "Equipment"
        End With
    End Sub

    Private Sub unit_selection_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.Closed
    End Sub

    Private Sub unit_selection_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        subject = New cunit
    End Sub

    Private Sub mark_ooc(t As TreeNodeCollection)
        For Each tn As TreeNode In t
            If tn.Nodes.Count > 0 Then mark_ooc(tn.Nodes)
            If tn.BackColor = golden Then
                orbat(tn.Text).ooc = True
                tn.BackColor = no_action_pts
            Else
                orbat(tn.Text).ooc = False
                tn.BackColor = nostatus
            End If
        Next

    End Sub

End Class