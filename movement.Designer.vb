<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class movement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(movement))
        Me.undercommand = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.selected_hq = New System.Windows.Forms.Label()
        Me.cover = New System.Windows.Forms.Label()
        Me.executeorders = New System.Windows.Forms.Button()
        Me.unitcover = New System.Windows.Forms.GroupBox()
        Me.o1 = New System.Windows.Forms.Label()
        Me.o2 = New System.Windows.Forms.Label()
        Me.o3 = New System.Windows.Forms.Label()
        Me.o4 = New System.Windows.Forms.Label()
        Me.o5 = New System.Windows.Forms.Label()
        Me.o6 = New System.Windows.Forms.Label()
        Me.o7 = New System.Windows.Forms.Label()
        Me.o8 = New System.Windows.Forms.Label()
        Me.o9 = New System.Windows.Forms.Label()
        Me.o0 = New System.Windows.Forms.Label()
        Me.tactical_actions = New System.Windows.Forms.GroupBox()
        Me.opp_fire = New System.Windows.Forms.Label()
        Me.comdtree = New System.Windows.Forms.TreeView()
        Me.unitcover.SuspendLayout()
        Me.tactical_actions.SuspendLayout()
        Me.SuspendLayout()
        '
        'undercommand
        '
        Me.undercommand.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6, Me.ColumnHeader5})
        Me.undercommand.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.undercommand.FullRowSelect = True
        Me.undercommand.GridLines = True
        Me.undercommand.Location = New System.Drawing.Point(482, 44)
        Me.undercommand.Name = "undercommand"
        Me.undercommand.Size = New System.Drawing.Size(418, 522)
        Me.undercommand.TabIndex = 43
        Me.undercommand.UseCompatibleStateImageBehavior = False
        Me.undercommand.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Unit"
        Me.ColumnHeader3.Width = 186
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Str"
        Me.ColumnHeader4.Width = 42
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "M"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 44
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Equipment"
        Me.ColumnHeader5.Width = 134
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(78, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 32)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Headquarters"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'selected_hq
        '
        Me.selected_hq.BackColor = System.Drawing.Color.Transparent
        Me.selected_hq.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selected_hq.ForeColor = System.Drawing.Color.White
        Me.selected_hq.Location = New System.Drawing.Point(504, 9)
        Me.selected_hq.Name = "selected_hq"
        Me.selected_hq.Size = New System.Drawing.Size(357, 32)
        Me.selected_hq.TabIndex = 44
        Me.selected_hq.Text = "Units"
        Me.selected_hq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cover
        '
        Me.cover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cover.Location = New System.Drawing.Point(71, 19)
        Me.cover.Name = "cover"
        Me.cover.Size = New System.Drawing.Size(158, 34)
        Me.cover.TabIndex = 50
        Me.cover.Text = "None"
        Me.cover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'executeorders
        '
        Me.executeorders.Enabled = False
        Me.executeorders.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.executeorders.Location = New System.Drawing.Point(261, 590)
        Me.executeorders.Name = "executeorders"
        Me.executeorders.Size = New System.Drawing.Size(609, 60)
        Me.executeorders.TabIndex = 52
        Me.executeorders.Text = "Execute Actions"
        Me.executeorders.UseVisualStyleBackColor = True
        '
        'unitcover
        '
        Me.unitcover.Controls.Add(Me.cover)
        Me.unitcover.Enabled = False
        Me.unitcover.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitcover.Location = New System.Drawing.Point(938, 501)
        Me.unitcover.Name = "unitcover"
        Me.unitcover.Size = New System.Drawing.Size(297, 65)
        Me.unitcover.TabIndex = 53
        Me.unitcover.TabStop = False
        Me.unitcover.Text = "Unit Cover"
        '
        'o1
        '
        Me.o1.BackColor = System.Drawing.SystemColors.Control
        Me.o1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o1.Location = New System.Drawing.Point(21, 60)
        Me.o1.Name = "o1"
        Me.o1.Size = New System.Drawing.Size(258, 28)
        Me.o1.TabIndex = 58
        Me.o1.Tag = "1"
        Me.o1.Text = "Option (1)"
        Me.o1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o2
        '
        Me.o2.BackColor = System.Drawing.SystemColors.Control
        Me.o2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o2.Location = New System.Drawing.Point(21, 95)
        Me.o2.Name = "o2"
        Me.o2.Size = New System.Drawing.Size(258, 28)
        Me.o2.TabIndex = 59
        Me.o2.Tag = "2"
        Me.o2.Text = "Option (1)"
        Me.o2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o3
        '
        Me.o3.BackColor = System.Drawing.SystemColors.Control
        Me.o3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o3.Location = New System.Drawing.Point(21, 130)
        Me.o3.Name = "o3"
        Me.o3.Size = New System.Drawing.Size(258, 28)
        Me.o3.TabIndex = 60
        Me.o3.Tag = "3"
        Me.o3.Text = "Option (1)"
        Me.o3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o4
        '
        Me.o4.BackColor = System.Drawing.SystemColors.Control
        Me.o4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o4.Location = New System.Drawing.Point(21, 165)
        Me.o4.Name = "o4"
        Me.o4.Size = New System.Drawing.Size(258, 28)
        Me.o4.TabIndex = 61
        Me.o4.Tag = "4"
        Me.o4.Text = "Option (1)"
        Me.o4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o5
        '
        Me.o5.BackColor = System.Drawing.SystemColors.Control
        Me.o5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o5.Location = New System.Drawing.Point(21, 200)
        Me.o5.Name = "o5"
        Me.o5.Size = New System.Drawing.Size(258, 28)
        Me.o5.TabIndex = 62
        Me.o5.Tag = "5"
        Me.o5.Text = "Option (1)"
        Me.o5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o6
        '
        Me.o6.BackColor = System.Drawing.SystemColors.Control
        Me.o6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o6.Location = New System.Drawing.Point(21, 235)
        Me.o6.Name = "o6"
        Me.o6.Size = New System.Drawing.Size(258, 28)
        Me.o6.TabIndex = 63
        Me.o6.Tag = "6"
        Me.o6.Text = "Option (1)"
        Me.o6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o7
        '
        Me.o7.BackColor = System.Drawing.SystemColors.Control
        Me.o7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o7.Location = New System.Drawing.Point(21, 270)
        Me.o7.Name = "o7"
        Me.o7.Size = New System.Drawing.Size(258, 28)
        Me.o7.TabIndex = 64
        Me.o7.Tag = "7"
        Me.o7.Text = "Option (1)"
        Me.o7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o8
        '
        Me.o8.BackColor = System.Drawing.SystemColors.Control
        Me.o8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o8.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o8.Location = New System.Drawing.Point(21, 305)
        Me.o8.Name = "o8"
        Me.o8.Size = New System.Drawing.Size(258, 28)
        Me.o8.TabIndex = 65
        Me.o8.Tag = "8"
        Me.o8.Text = "Option (1)"
        Me.o8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o9
        '
        Me.o9.BackColor = System.Drawing.SystemColors.Control
        Me.o9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o9.Location = New System.Drawing.Point(21, 340)
        Me.o9.Name = "o9"
        Me.o9.Size = New System.Drawing.Size(258, 28)
        Me.o9.TabIndex = 66
        Me.o9.Tag = "9"
        Me.o9.Text = "Option (1)"
        Me.o9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'o0
        '
        Me.o0.BackColor = System.Drawing.SystemColors.Control
        Me.o0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.o0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.o0.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o0.Location = New System.Drawing.Point(21, 25)
        Me.o0.Name = "o0"
        Me.o0.Size = New System.Drawing.Size(258, 28)
        Me.o0.TabIndex = 67
        Me.o0.Tag = "0"
        Me.o0.Text = "Option (1)"
        Me.o0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tactical_actions
        '
        Me.tactical_actions.Controls.Add(Me.o0)
        Me.tactical_actions.Controls.Add(Me.o6)
        Me.tactical_actions.Controls.Add(Me.o1)
        Me.tactical_actions.Controls.Add(Me.o7)
        Me.tactical_actions.Controls.Add(Me.o9)
        Me.tactical_actions.Controls.Add(Me.o5)
        Me.tactical_actions.Controls.Add(Me.o4)
        Me.tactical_actions.Controls.Add(Me.o2)
        Me.tactical_actions.Controls.Add(Me.o8)
        Me.tactical_actions.Controls.Add(Me.o3)
        Me.tactical_actions.Location = New System.Drawing.Point(938, 98)
        Me.tactical_actions.Name = "tactical_actions"
        Me.tactical_actions.Size = New System.Drawing.Size(297, 382)
        Me.tactical_actions.TabIndex = 68
        Me.tactical_actions.TabStop = False
        Me.tactical_actions.Text = "Tactical Actions"
        '
        'opp_fire
        '
        Me.opp_fire.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.opp_fire.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opp_fire.Location = New System.Drawing.Point(938, 44)
        Me.opp_fire.Name = "opp_fire"
        Me.opp_fire.Size = New System.Drawing.Size(297, 34)
        Me.opp_fire.TabIndex = 69
        Me.opp_fire.Text = "Liable for Opportunity Fire"
        Me.opp_fire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'comdtree
        '
        Me.comdtree.AllowDrop = True
        Me.comdtree.BackColor = System.Drawing.Color.White
        Me.comdtree.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comdtree.Location = New System.Drawing.Point(57, 44)
        Me.comdtree.Name = "comdtree"
        Me.comdtree.ShowPlusMinus = False
        Me.comdtree.Size = New System.Drawing.Size(329, 522)
        Me.comdtree.TabIndex = 70
        '
        'movement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.comdtree)
        Me.Controls.Add(Me.opp_fire)
        Me.Controls.Add(Me.tactical_actions)
        Me.Controls.Add(Me.unitcover)
        Me.Controls.Add(Me.executeorders)
        Me.Controls.Add(Me.selected_hq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.undercommand)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "movement"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movement"
        Me.unitcover.ResumeLayout(False)
        Me.tactical_actions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents undercommand As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents selected_hq As System.Windows.Forms.Label
    Friend WithEvents cover As System.Windows.Forms.Label
    Friend WithEvents executeorders As System.Windows.Forms.Button
    Friend WithEvents unitcover As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents o1 As Label
    Friend WithEvents o2 As Label
    Friend WithEvents o3 As Label
    Friend WithEvents o4 As Label
    Friend WithEvents o5 As Label
    Friend WithEvents o6 As Label
    Friend WithEvents o7 As Label
    Friend WithEvents o8 As Label
    Friend WithEvents o9 As Label
    Friend WithEvents o0 As Label
    Friend WithEvents tactical_actions As GroupBox
    Friend WithEvents opp_fire As Label
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents comdtree As TreeView
End Class
