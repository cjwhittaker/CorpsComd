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
        Me.title = New System.Windows.Forms.Label()
        Me.comd_dist = New System.Windows.Forms.TextBox()
        Me.commanders = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.undercommand = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.marchmove = New System.Windows.Forms.CheckBox()
        Me.cover = New System.Windows.Forms.Label()
        Me.select_cover = New System.Windows.Forms.Button()
        Me.tactical_actions = New System.Windows.Forms.GroupBox()
        Me.o9 = New System.Windows.Forms.RadioButton()
        Me.o8 = New System.Windows.Forms.RadioButton()
        Me.o7 = New System.Windows.Forms.RadioButton()
        Me.o6 = New System.Windows.Forms.RadioButton()
        Me.o5 = New System.Windows.Forms.RadioButton()
        Me.o4 = New System.Windows.Forms.RadioButton()
        Me.o3 = New System.Windows.Forms.RadioButton()
        Me.o2 = New System.Windows.Forms.RadioButton()
        Me.o1 = New System.Windows.Forms.RadioButton()
        Me.o0 = New System.Windows.Forms.RadioButton()
        Me.executeorders = New System.Windows.Forms.Button()
        Me.unitcover = New System.Windows.Forms.GroupBox()
        Me.comd_dist_gp = New System.Windows.Forms.GroupBox()
        Me.comd_distance_ranges = New System.Windows.Forms.ListBox()
        Me.opp_fire = New System.Windows.Forms.CheckBox()
        Me.selectall = New System.Windows.Forms.Button()
        Me.current_phase = New System.Windows.Forms.Label()
        Me.tactical_actions.SuspendLayout()
        Me.unitcover.SuspendLayout()
        Me.comd_dist_gp.SuspendLayout()
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(280, 62)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(396, 34)
        Me.title.TabIndex = 19
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'comd_dist
        '
        Me.comd_dist.Enabled = False
        Me.comd_dist.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comd_dist.Location = New System.Drawing.Point(20, 21)
        Me.comd_dist.Name = "comd_dist"
        Me.comd_dist.Size = New System.Drawing.Size(125, 35)
        Me.comd_dist.TabIndex = 21
        Me.comd_dist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'commanders
        '
        Me.commanders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader1})
        Me.commanders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.commanders.FullRowSelect = True
        Me.commanders.GridLines = True
        Me.commanders.HideSelection = False
        Me.commanders.Location = New System.Drawing.Point(12, 110)
        Me.commanders.MultiSelect = False
        Me.commanders.Name = "commanders"
        Me.commanders.Size = New System.Drawing.Size(357, 456)
        Me.commanders.TabIndex = 42
        Me.commanders.UseCompatibleStateImageBehavior = False
        Me.commanders.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Unit"
        Me.ColumnHeader2.Width = 252
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Comd Pts"
        Me.ColumnHeader1.Width = 96
        '
        'undercommand
        '
        Me.undercommand.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.undercommand.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.undercommand.FullRowSelect = True
        Me.undercommand.GridLines = True
        Me.undercommand.Location = New System.Drawing.Point(543, 110)
        Me.undercommand.MultiSelect = False
        Me.undercommand.Name = "undercommand"
        Me.undercommand.Size = New System.Drawing.Size(357, 456)
        Me.undercommand.TabIndex = 43
        Me.undercommand.UseCompatibleStateImageBehavior = False
        Me.undercommand.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Unit"
        Me.ColumnHeader3.Width = 205
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Str"
        Me.ColumnHeader4.Width = 38
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Equipment"
        Me.ColumnHeader5.Width = 110
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 32)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Headquarters"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(579, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 32)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Units"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'marchmove
        '
        Me.marchmove.Appearance = System.Windows.Forms.Appearance.Button
        Me.marchmove.Enabled = False
        Me.marchmove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.marchmove.Location = New System.Drawing.Point(931, 151)
        Me.marchmove.Name = "marchmove"
        Me.marchmove.Size = New System.Drawing.Size(320, 34)
        Me.marchmove.TabIndex = 48
        Me.marchmove.Text = "March Movement"
        Me.marchmove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.marchmove.UseVisualStyleBackColor = True
        '
        'cover
        '
        Me.cover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cover.Location = New System.Drawing.Point(209, 19)
        Me.cover.Name = "cover"
        Me.cover.Size = New System.Drawing.Size(122, 34)
        Me.cover.TabIndex = 50
        Me.cover.Text = "None"
        Me.cover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'select_cover
        '
        Me.select_cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.select_cover.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.select_cover.Location = New System.Drawing.Point(11, 19)
        Me.select_cover.Name = "select_cover"
        Me.select_cover.Size = New System.Drawing.Size(192, 34)
        Me.select_cover.TabIndex = 49
        Me.select_cover.Text = "[C]over"
        Me.select_cover.UseVisualStyleBackColor = True
        '
        'tactical_actions
        '
        Me.tactical_actions.Controls.Add(Me.o9)
        Me.tactical_actions.Controls.Add(Me.o8)
        Me.tactical_actions.Controls.Add(Me.o7)
        Me.tactical_actions.Controls.Add(Me.o6)
        Me.tactical_actions.Controls.Add(Me.o5)
        Me.tactical_actions.Controls.Add(Me.o4)
        Me.tactical_actions.Controls.Add(Me.o3)
        Me.tactical_actions.Controls.Add(Me.o2)
        Me.tactical_actions.Controls.Add(Me.o1)
        Me.tactical_actions.Controls.Add(Me.o0)
        Me.tactical_actions.Enabled = False
        Me.tactical_actions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tactical_actions.Location = New System.Drawing.Point(920, 191)
        Me.tactical_actions.Name = "tactical_actions"
        Me.tactical_actions.Size = New System.Drawing.Size(347, 375)
        Me.tactical_actions.TabIndex = 51
        Me.tactical_actions.TabStop = False
        Me.tactical_actions.Text = "Tactical Actions"
        '
        'o9
        '
        Me.o9.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o9.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o9.Location = New System.Drawing.Point(64, 330)
        Me.o9.Name = "o9"
        Me.o9.Size = New System.Drawing.Size(223, 28)
        Me.o9.TabIndex = 66
        Me.o9.Text = "Move (2)"
        Me.o9.UseVisualStyleBackColor = True
        '
        'o8
        '
        Me.o8.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o8.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o8.Location = New System.Drawing.Point(64, 296)
        Me.o8.Name = "o8"
        Me.o8.Size = New System.Drawing.Size(223, 28)
        Me.o8.TabIndex = 65
        Me.o8.Text = "Move (2)"
        Me.o8.UseVisualStyleBackColor = True
        '
        'o7
        '
        Me.o7.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o7.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o7.Location = New System.Drawing.Point(64, 262)
        Me.o7.Name = "o7"
        Me.o7.Size = New System.Drawing.Size(223, 28)
        Me.o7.TabIndex = 64
        Me.o7.Text = "Move (2)"
        Me.o7.UseVisualStyleBackColor = True
        '
        'o6
        '
        Me.o6.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o6.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o6.Location = New System.Drawing.Point(64, 228)
        Me.o6.Name = "o6"
        Me.o6.Size = New System.Drawing.Size(223, 28)
        Me.o6.TabIndex = 63
        Me.o6.Text = "Move (2)"
        Me.o6.UseVisualStyleBackColor = True
        '
        'o5
        '
        Me.o5.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o5.Location = New System.Drawing.Point(64, 191)
        Me.o5.Name = "o5"
        Me.o5.Size = New System.Drawing.Size(223, 28)
        Me.o5.TabIndex = 62
        Me.o5.Text = "Move (2)"
        Me.o5.UseVisualStyleBackColor = True
        '
        'o4
        '
        Me.o4.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o4.Location = New System.Drawing.Point(64, 157)
        Me.o4.Name = "o4"
        Me.o4.Size = New System.Drawing.Size(223, 28)
        Me.o4.TabIndex = 61
        Me.o4.Text = "Move (2)"
        Me.o4.UseVisualStyleBackColor = True
        '
        'o3
        '
        Me.o3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o3.Location = New System.Drawing.Point(64, 123)
        Me.o3.Name = "o3"
        Me.o3.Size = New System.Drawing.Size(223, 28)
        Me.o3.TabIndex = 60
        Me.o3.Text = "Move (2)"
        Me.o3.UseVisualStyleBackColor = True
        '
        'o2
        '
        Me.o2.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o2.Location = New System.Drawing.Point(64, 89)
        Me.o2.Name = "o2"
        Me.o2.Size = New System.Drawing.Size(223, 28)
        Me.o2.TabIndex = 59
        Me.o2.Text = "Move (2)"
        Me.o2.UseVisualStyleBackColor = True
        '
        'o1
        '
        Me.o1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o1.Location = New System.Drawing.Point(64, 55)
        Me.o1.Name = "o1"
        Me.o1.Size = New System.Drawing.Size(223, 28)
        Me.o1.TabIndex = 58
        Me.o1.Text = "Move (2)"
        Me.o1.UseVisualStyleBackColor = True
        '
        'o0
        '
        Me.o0.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.o0.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.o0.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.o0.Location = New System.Drawing.Point(64, 21)
        Me.o0.Name = "o0"
        Me.o0.Size = New System.Drawing.Size(223, 28)
        Me.o0.TabIndex = 57
        Me.o0.Text = "Move (2)"
        Me.o0.UseVisualStyleBackColor = True
        '
        'executeorders
        '
        Me.executeorders.Enabled = False
        Me.executeorders.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.executeorders.Location = New System.Drawing.Point(197, 587)
        Me.executeorders.Name = "executeorders"
        Me.executeorders.Size = New System.Drawing.Size(609, 60)
        Me.executeorders.TabIndex = 52
        Me.executeorders.Text = "Execute Actions"
        Me.executeorders.UseVisualStyleBackColor = True
        '
        'unitcover
        '
        Me.unitcover.Controls.Add(Me.cover)
        Me.unitcover.Controls.Add(Me.select_cover)
        Me.unitcover.Enabled = False
        Me.unitcover.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unitcover.Location = New System.Drawing.Point(920, 582)
        Me.unitcover.Name = "unitcover"
        Me.unitcover.Size = New System.Drawing.Size(347, 65)
        Me.unitcover.TabIndex = 53
        Me.unitcover.TabStop = False
        Me.unitcover.Text = "Unit Cover"
        '
        'comd_dist_gp
        '
        Me.comd_dist_gp.Controls.Add(Me.comd_distance_ranges)
        Me.comd_dist_gp.Controls.Add(Me.comd_dist)
        Me.comd_dist_gp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comd_dist_gp.Location = New System.Drawing.Point(375, 110)
        Me.comd_dist_gp.Name = "comd_dist_gp"
        Me.comd_dist_gp.Size = New System.Drawing.Size(163, 229)
        Me.comd_dist_gp.TabIndex = 54
        Me.comd_dist_gp.TabStop = False
        Me.comd_dist_gp.Text = "Command Distance"
        '
        'comd_distance_ranges
        '
        Me.comd_distance_ranges.BackColor = System.Drawing.SystemColors.Control
        Me.comd_distance_ranges.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.comd_distance_ranges.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comd_distance_ranges.FormattingEnabled = True
        Me.comd_distance_ranges.ItemHeight = 24
        Me.comd_distance_ranges.Items.AddRange(New Object() {"3000", "6000", "9000", "12000", "15000"})
        Me.comd_distance_ranges.Location = New System.Drawing.Point(45, 62)
        Me.comd_distance_ranges.Name = "comd_distance_ranges"
        Me.comd_distance_ranges.Size = New System.Drawing.Size(80, 144)
        Me.comd_distance_ranges.TabIndex = 58
        '
        'opp_fire
        '
        Me.opp_fire.Appearance = System.Windows.Forms.Appearance.Button
        Me.opp_fire.Enabled = False
        Me.opp_fire.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opp_fire.Location = New System.Drawing.Point(931, 110)
        Me.opp_fire.Name = "opp_fire"
        Me.opp_fire.Size = New System.Drawing.Size(151, 34)
        Me.opp_fire.TabIndex = 55
        Me.opp_fire.Text = "Liable for Opp Fire"
        Me.opp_fire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.opp_fire.UseVisualStyleBackColor = True
        '
        'selectall
        '
        Me.selectall.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectall.Location = New System.Drawing.Point(1097, 109)
        Me.selectall.Name = "selectall"
        Me.selectall.Size = New System.Drawing.Size(154, 35)
        Me.selectall.TabIndex = 56
        Me.selectall.Text = "Select All Units"
        Me.selectall.UseVisualStyleBackColor = True
        '
        'current_phase
        '
        Me.current_phase.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.current_phase.Location = New System.Drawing.Point(1, 9)
        Me.current_phase.Name = "current_phase"
        Me.current_phase.Size = New System.Drawing.Size(706, 34)
        Me.current_phase.TabIndex = 57
        Me.current_phase.Text = "Game Phase and Player"
        Me.current_phase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'movement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.current_phase)
        Me.Controls.Add(Me.selectall)
        Me.Controls.Add(Me.opp_fire)
        Me.Controls.Add(Me.comd_dist_gp)
        Me.Controls.Add(Me.unitcover)
        Me.Controls.Add(Me.executeorders)
        Me.Controls.Add(Me.tactical_actions)
        Me.Controls.Add(Me.marchmove)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.undercommand)
        Me.Controls.Add(Me.commanders)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "movement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movement"
        Me.tactical_actions.ResumeLayout(False)
        Me.unitcover.ResumeLayout(False)
        Me.comd_dist_gp.ResumeLayout(False)
        Me.comd_dist_gp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents title As System.Windows.Forms.Label
    Friend WithEvents comd_dist As System.Windows.Forms.TextBox
    Friend WithEvents commanders As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents undercommand As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents marchmove As System.Windows.Forms.CheckBox
    Friend WithEvents cover As System.Windows.Forms.Label
    Friend WithEvents select_cover As System.Windows.Forms.Button
    Friend WithEvents tactical_actions As System.Windows.Forms.GroupBox
    Friend WithEvents executeorders As System.Windows.Forms.Button
    Friend WithEvents unitcover As System.Windows.Forms.GroupBox
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents comd_dist_gp As System.Windows.Forms.GroupBox
    Friend WithEvents opp_fire As System.Windows.Forms.CheckBox
    Friend WithEvents selectall As System.Windows.Forms.Button
    Friend WithEvents comd_distance_ranges As System.Windows.Forms.ListBox
    Friend WithEvents o0 As System.Windows.Forms.RadioButton
    Friend WithEvents o1 As System.Windows.Forms.RadioButton
    Friend WithEvents o2 As System.Windows.Forms.RadioButton
    Friend WithEvents o9 As System.Windows.Forms.RadioButton
    Friend WithEvents o8 As System.Windows.Forms.RadioButton
    Friend WithEvents o7 As System.Windows.Forms.RadioButton
    Friend WithEvents o6 As System.Windows.Forms.RadioButton
    Friend WithEvents o5 As System.Windows.Forms.RadioButton
    Friend WithEvents o4 As System.Windows.Forms.RadioButton
    Friend WithEvents o3 As System.Windows.Forms.RadioButton
    Friend WithEvents current_phase As System.Windows.Forms.Label
End Class
