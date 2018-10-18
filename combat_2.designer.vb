<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class combat_2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(combat_2))
        Me.f_view = New System.Windows.Forms.Label()
        Me.targets = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.t_view = New System.Windows.Forms.Label()
        Me.t_terrain = New System.Windows.Forms.Label()
        Me.t_cover = New System.Windows.Forms.Label()
        Me.firesmoke = New System.Windows.Forms.Button()
        Me.fire = New System.Windows.Forms.Button()
        Me.visrange = New System.Windows.Forms.Label()
        Me.tgt_range = New System.Windows.Forms.Label()
        Me.vis_range_select = New System.Windows.Forms.ListBox()
        Me.tgt_range_select = New System.Windows.Forms.ListBox()
        Me.directfirepanel = New System.Windows.Forms.Panel()
        Me.fa_altitude = New System.Windows.Forms.Label()
        Me.s2 = New System.Windows.Forms.Label()
        Me.fa_altitude_label = New System.Windows.Forms.Label()
        Me.s3 = New System.Windows.Forms.Label()
        Me.s1 = New System.Windows.Forms.Label()
        Me.f_dismounted = New System.Windows.Forms.Label()
        Me.f_moving = New System.Windows.Forms.Label()
        Me.abort_firer = New System.Windows.Forms.Button()
        Me.firers = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Secondary = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fwpn = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.f_mode = New System.Windows.Forms.Label()
        Me.f_status = New System.Windows.Forms.Label()
        Me.f_insmoke = New System.Windows.Forms.Label()
        Me.f_elevation = New System.Windows.Forms.Label()
        Me.f_aspect = New System.Windows.Forms.Label()
        Me.f_plains = New System.Windows.Forms.Label()
        Me.f_roadmove = New System.Windows.Forms.Label()
        Me.f_cover = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.f_terrain = New System.Windows.Forms.Label()
        Me.targetpanel = New System.Windows.Forms.Panel()
        Me.ta_ecm_ds = New System.Windows.Forms.Label()
        Me.ta_ecm_gs = New System.Windows.Forms.Label()
        Me.t2 = New System.Windows.Forms.Label()
        Me.t3 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.Label()
        Me.t_dismounted = New System.Windows.Forms.Label()
        Me.t_moving = New System.Windows.Forms.Label()
        Me.abort_target = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ta_altitude = New System.Windows.Forms.Label()
        Me.twpn = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ta_altitude_label = New System.Windows.Forms.Label()
        Me.t_insmoke = New System.Windows.Forms.Label()
        Me.t_elevation = New System.Windows.Forms.Label()
        Me.t_aspect = New System.Windows.Forms.Label()
        Me.t_mode = New System.Windows.Forms.Label()
        Me.t_plains = New System.Windows.Forms.Label()
        Me.t_roadmove = New System.Windows.Forms.Label()
        Me.t_status = New System.Windows.Forms.Label()
        Me.ta_ecm_label = New System.Windows.Forms.Label()
        Me.return_fire = New System.Windows.Forms.Label()
        Me.centrepanel = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.swap = New System.Windows.Forms.Button()
        Me.indirectfirepanel = New System.Windows.Forms.Panel()
        Me.obs_insmoke = New System.Windows.Forms.Label()
        Me.scoot = New System.Windows.Forms.Label()
        Me.obs_moving = New System.Windows.Forms.Label()
        Me.obs_mode = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.obs_elevation = New System.Windows.Forms.Label()
        Me.observers = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.a2 = New System.Windows.Forms.Label()
        Me.a3 = New System.Windows.Forms.Label()
        Me.a1 = New System.Windows.Forms.Label()
        Me.artillery = New System.Windows.Forms.ListView()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label20 = New System.Windows.Forms.Label()
        Me.directfirepanel.SuspendLayout()
        Me.targetpanel.SuspendLayout()
        Me.centrepanel.SuspendLayout()
        Me.indirectfirepanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'f_view
        '
        Me.f_view.AutoSize = True
        Me.f_view.BackColor = System.Drawing.Color.Transparent
        Me.f_view.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_view.Location = New System.Drawing.Point(24, 230)
        Me.f_view.Name = "f_view"
        Me.f_view.Size = New System.Drawing.Size(181, 20)
        Me.f_view.TabIndex = 58
        Me.f_view.Text = "Firer's view of the Target"
        Me.f_view.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targets
        '
        Me.targets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader2, Me.ColumnHeader4})
        Me.targets.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targets.FullRowSelect = True
        Me.targets.GridLines = True
        Me.targets.Location = New System.Drawing.Point(21, 15)
        Me.targets.MultiSelect = False
        Me.targets.Name = "targets"
        Me.targets.Size = New System.Drawing.Size(269, 507)
        Me.targets.TabIndex = 61
        Me.targets.Tag = ""
        Me.targets.UseCompatibleStateImageBehavior = False
        Me.targets.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Unit"
        Me.ColumnHeader5.Width = 119
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Str"
        Me.ColumnHeader2.Width = 34
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Equip"
        Me.ColumnHeader4.Width = 105
        '
        't_view
        '
        Me.t_view.AutoSize = True
        Me.t_view.BackColor = System.Drawing.Color.Transparent
        Me.t_view.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_view.Location = New System.Drawing.Point(313, 230)
        Me.t_view.Name = "t_view"
        Me.t_view.Size = New System.Drawing.Size(181, 20)
        Me.t_view.TabIndex = 58
        Me.t_view.Text = "Target's view of the Firer"
        Me.t_view.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_terrain
        '
        Me.t_terrain.AutoSize = True
        Me.t_terrain.BackColor = System.Drawing.Color.Transparent
        Me.t_terrain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_terrain.Location = New System.Drawing.Point(348, 327)
        Me.t_terrain.Name = "t_terrain"
        Me.t_terrain.Size = New System.Drawing.Size(111, 20)
        Me.t_terrain.TabIndex = 58
        Me.t_terrain.Text = "Target's Cover"
        Me.t_terrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_cover
        '
        Me.t_cover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_cover.Location = New System.Drawing.Point(337, 353)
        Me.t_cover.Name = "t_cover"
        Me.t_cover.Size = New System.Drawing.Size(132, 30)
        Me.t_cover.TabIndex = 50
        Me.t_cover.Tag = "None"
        Me.t_cover.Text = "None"
        Me.t_cover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firesmoke
        '
        Me.firesmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firesmoke.Location = New System.Drawing.Point(27, 448)
        Me.firesmoke.Name = "firesmoke"
        Me.firesmoke.Size = New System.Drawing.Size(165, 34)
        Me.firesmoke.TabIndex = 62
        Me.firesmoke.Text = "Fire Smoke"
        Me.firesmoke.UseVisualStyleBackColor = True
        Me.firesmoke.Visible = False
        '
        'fire
        '
        Me.fire.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fire.Location = New System.Drawing.Point(27, 490)
        Me.fire.Name = "fire"
        Me.fire.Size = New System.Drawing.Size(165, 34)
        Me.fire.TabIndex = 62
        Me.fire.Text = "Fire"
        Me.fire.UseVisualStyleBackColor = True
        '
        'visrange
        '
        Me.visrange.BackColor = System.Drawing.Color.Transparent
        Me.visrange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.visrange.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.visrange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.visrange.Location = New System.Drawing.Point(15, 23)
        Me.visrange.Name = "visrange"
        Me.visrange.Size = New System.Drawing.Size(78, 35)
        Me.visrange.TabIndex = 60
        Me.visrange.Tag = "Obs"
        Me.visrange.Text = "Obs"
        Me.visrange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tgt_range
        '
        Me.tgt_range.BackColor = System.Drawing.Color.Transparent
        Me.tgt_range.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tgt_range.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tgt_range.Location = New System.Drawing.Point(120, 23)
        Me.tgt_range.Name = "tgt_range"
        Me.tgt_range.Size = New System.Drawing.Size(78, 35)
        Me.tgt_range.TabIndex = 63
        Me.tgt_range.Tag = "Range"
        Me.tgt_range.Text = "Range"
        Me.tgt_range.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'vis_range_select
        '
        Me.vis_range_select.BackColor = System.Drawing.SystemColors.Control
        Me.vis_range_select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.vis_range_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vis_range_select.FormattingEnabled = True
        Me.vis_range_select.ItemHeight = 24
        Me.vis_range_select.Items.AddRange(New Object() {"  300", "  600", " 1000", " 1500", " 2000", " 2500", " 3000", " 4000", " 5000", " 6000", " 8000", "10000", "15000", "20000", "25000", "30000"})
        Me.vis_range_select.Location = New System.Drawing.Point(24, 61)
        Me.vis_range_select.Name = "vis_range_select"
        Me.vis_range_select.Size = New System.Drawing.Size(69, 384)
        Me.vis_range_select.TabIndex = 67
        '
        'tgt_range_select
        '
        Me.tgt_range_select.BackColor = System.Drawing.SystemColors.Control
        Me.tgt_range_select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tgt_range_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tgt_range_select.FormattingEnabled = True
        Me.tgt_range_select.ItemHeight = 24
        Me.tgt_range_select.Items.AddRange(New Object() {"  300", "  600", " 1000", " 1500", " 2000", " 2500", " 3000", " 4000", " 5000", " 6000", " 8000", "10000", "15000", "20000", "25000", "30000"})
        Me.tgt_range_select.Location = New System.Drawing.Point(129, 61)
        Me.tgt_range_select.Name = "tgt_range_select"
        Me.tgt_range_select.Size = New System.Drawing.Size(76, 384)
        Me.tgt_range_select.TabIndex = 68
        Me.tgt_range_select.Tag = "1"
        '
        'directfirepanel
        '
        Me.directfirepanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.directfirepanel.Controls.Add(Me.fa_altitude)
        Me.directfirepanel.Controls.Add(Me.s2)
        Me.directfirepanel.Controls.Add(Me.fa_altitude_label)
        Me.directfirepanel.Controls.Add(Me.s3)
        Me.directfirepanel.Controls.Add(Me.s1)
        Me.directfirepanel.Controls.Add(Me.f_dismounted)
        Me.directfirepanel.Controls.Add(Me.f_moving)
        Me.directfirepanel.Controls.Add(Me.abort_firer)
        Me.directfirepanel.Controls.Add(Me.firers)
        Me.directfirepanel.Controls.Add(Me.fwpn)
        Me.directfirepanel.Controls.Add(Me.Label3)
        Me.directfirepanel.Controls.Add(Me.f_mode)
        Me.directfirepanel.Controls.Add(Me.f_status)
        Me.directfirepanel.Controls.Add(Me.f_insmoke)
        Me.directfirepanel.Controls.Add(Me.f_elevation)
        Me.directfirepanel.Controls.Add(Me.f_aspect)
        Me.directfirepanel.Controls.Add(Me.f_plains)
        Me.directfirepanel.Controls.Add(Me.f_roadmove)
        Me.directfirepanel.Controls.Add(Me.f_cover)
        Me.directfirepanel.Controls.Add(Me.Label13)
        Me.directfirepanel.Controls.Add(Me.f_terrain)
        Me.directfirepanel.Controls.Add(Me.f_view)
        Me.directfirepanel.Location = New System.Drawing.Point(12, 12)
        Me.directfirepanel.Name = "directfirepanel"
        Me.directfirepanel.Size = New System.Drawing.Size(491, 638)
        Me.directfirepanel.TabIndex = 69
        '
        'fa_altitude
        '
        Me.fa_altitude.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fa_altitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fa_altitude.Location = New System.Drawing.Point(45, 527)
        Me.fa_altitude.Name = "fa_altitude"
        Me.fa_altitude.Size = New System.Drawing.Size(132, 30)
        Me.fa_altitude.TabIndex = 95
        Me.fa_altitude.Tag = "Low"
        Me.fa_altitude.Text = "Low"
        Me.fa_altitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fa_altitude.Visible = False
        '
        's2
        '
        Me.s2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s2.Location = New System.Drawing.Point(321, 554)
        Me.s2.Name = "s2"
        Me.s2.Size = New System.Drawing.Size(40, 40)
        Me.s2.TabIndex = 94
        Me.s2.Text = "5"
        Me.s2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fa_altitude_label
        '
        Me.fa_altitude_label.AutoSize = True
        Me.fa_altitude_label.BackColor = System.Drawing.Color.Transparent
        Me.fa_altitude_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fa_altitude_label.Location = New System.Drawing.Point(49, 507)
        Me.fa_altitude_label.Name = "fa_altitude_label"
        Me.fa_altitude_label.Size = New System.Drawing.Size(110, 20)
        Me.fa_altitude_label.TabIndex = 96
        Me.fa_altitude_label.Text = "Firer's Altitude"
        Me.fa_altitude_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fa_altitude_label.Visible = False
        '
        's3
        '
        Me.s3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s3.Location = New System.Drawing.Point(367, 554)
        Me.s3.Name = "s3"
        Me.s3.Size = New System.Drawing.Size(40, 40)
        Me.s3.TabIndex = 93
        Me.s3.Text = "5"
        Me.s3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        's1
        '
        Me.s1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s1.Location = New System.Drawing.Point(275, 554)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(40, 40)
        Me.s1.TabIndex = 92
        Me.s1.Text = "5"
        Me.s1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_dismounted
        '
        Me.f_dismounted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_dismounted.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_dismounted.Location = New System.Drawing.Point(45, 186)
        Me.f_dismounted.Name = "f_dismounted"
        Me.f_dismounted.Size = New System.Drawing.Size(132, 30)
        Me.f_dismounted.TabIndex = 89
        Me.f_dismounted.Tag = "Dismount"
        Me.f_dismounted.Text = "Dismount"
        Me.f_dismounted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_moving
        '
        Me.f_moving.AccessibleDescription = ""
        Me.f_moving.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_moving.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_moving.Location = New System.Drawing.Point(45, 147)
        Me.f_moving.Name = "f_moving"
        Me.f_moving.Size = New System.Drawing.Size(132, 30)
        Me.f_moving.TabIndex = 87
        Me.f_moving.Tag = "Static"
        Me.f_moving.Text = "Static"
        Me.f_moving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'abort_firer
        '
        Me.abort_firer.BackColor = System.Drawing.SystemColors.Control
        Me.abort_firer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abort_firer.Location = New System.Drawing.Point(45, 571)
        Me.abort_firer.Name = "abort_firer"
        Me.abort_firer.Size = New System.Drawing.Size(132, 35)
        Me.abort_firer.TabIndex = 86
        Me.abort_firer.Tag = "Firer"
        Me.abort_firer.Text = "Abort Flight"
        Me.abort_firer.UseVisualStyleBackColor = False
        Me.abort_firer.Visible = False
        '
        'firers
        '
        Me.firers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Secondary, Me.ColumnHeader3})
        Me.firers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firers.FullRowSelect = True
        Me.firers.GridLines = True
        Me.firers.HideSelection = False
        Me.firers.Location = New System.Drawing.Point(211, 15)
        Me.firers.MultiSelect = False
        Me.firers.Name = "firers"
        Me.firers.Size = New System.Drawing.Size(258, 507)
        Me.firers.TabIndex = 81
        Me.firers.Tag = ""
        Me.firers.UseCompatibleStateImageBehavior = False
        Me.firers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Unit"
        Me.ColumnHeader1.Width = 114
        '
        'Secondary
        '
        Me.Secondary.Text = "Str"
        Me.Secondary.Width = 35
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Equip"
        Me.ColumnHeader3.Width = 100
        '
        'fwpn
        '
        Me.fwpn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fwpn.Enabled = False
        Me.fwpn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fwpn.Location = New System.Drawing.Point(45, 46)
        Me.fwpn.Name = "fwpn"
        Me.fwpn.Size = New System.Drawing.Size(132, 30)
        Me.fwpn.TabIndex = 82
        Me.fwpn.Tag = ""
        Me.fwpn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(67, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Equipment"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_mode
        '
        Me.f_mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_mode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_mode.Location = New System.Drawing.Point(45, 108)
        Me.f_mode.Name = "f_mode"
        Me.f_mode.Size = New System.Drawing.Size(132, 30)
        Me.f_mode.TabIndex = 82
        Me.f_mode.Tag = "Conc"
        Me.f_mode.Text = "Conc"
        Me.f_mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_status
        '
        Me.f_status.AutoSize = True
        Me.f_status.BackColor = System.Drawing.Color.Transparent
        Me.f_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_status.Location = New System.Drawing.Point(61, 85)
        Me.f_status.Name = "f_status"
        Me.f_status.Size = New System.Drawing.Size(92, 20)
        Me.f_status.TabIndex = 81
        Me.f_status.Text = "Firer Status"
        Me.f_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_insmoke
        '
        Me.f_insmoke.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_insmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_insmoke.Location = New System.Drawing.Point(45, 470)
        Me.f_insmoke.Name = "f_insmoke"
        Me.f_insmoke.Size = New System.Drawing.Size(132, 30)
        Me.f_insmoke.TabIndex = 75
        Me.f_insmoke.Tag = "No Smoke"
        Me.f_insmoke.Text = "No Smoke"
        Me.f_insmoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_elevation
        '
        Me.f_elevation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_elevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_elevation.Location = New System.Drawing.Point(45, 289)
        Me.f_elevation.Name = "f_elevation"
        Me.f_elevation.Size = New System.Drawing.Size(132, 30)
        Me.f_elevation.TabIndex = 74
        Me.f_elevation.Tag = "Same Level"
        Me.f_elevation.Text = "Same Level"
        Me.f_elevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_aspect
        '
        Me.f_aspect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_aspect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_aspect.Location = New System.Drawing.Point(45, 250)
        Me.f_aspect.Name = "f_aspect"
        Me.f_aspect.Size = New System.Drawing.Size(132, 30)
        Me.f_aspect.TabIndex = 73
        Me.f_aspect.Tag = "Front"
        Me.f_aspect.Text = "Front"
        Me.f_aspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_plains
        '
        Me.f_plains.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_plains.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_plains.Location = New System.Drawing.Point(45, 431)
        Me.f_plains.Name = "f_plains"
        Me.f_plains.Size = New System.Drawing.Size(132, 30)
        Me.f_plains.TabIndex = 50
        Me.f_plains.Tag = "Open Terrain"
        Me.f_plains.Text = "Open Terrain"
        Me.f_plains.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_roadmove
        '
        Me.f_roadmove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_roadmove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_roadmove.Location = New System.Drawing.Point(45, 392)
        Me.f_roadmove.Name = "f_roadmove"
        Me.f_roadmove.Size = New System.Drawing.Size(132, 30)
        Me.f_roadmove.TabIndex = 50
        Me.f_roadmove.Tag = "X Country"
        Me.f_roadmove.Text = "X Country"
        Me.f_roadmove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_cover
        '
        Me.f_cover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.f_cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_cover.Location = New System.Drawing.Point(45, 353)
        Me.f_cover.Name = "f_cover"
        Me.f_cover.Size = New System.Drawing.Size(132, 30)
        Me.f_cover.TabIndex = 50
        Me.f_cover.Tag = "None"
        Me.f_cover.Text = "None"
        Me.f_cover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(271, 527)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 20)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Firer Firing Strength"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f_terrain
        '
        Me.f_terrain.AutoSize = True
        Me.f_terrain.BackColor = System.Drawing.Color.Transparent
        Me.f_terrain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f_terrain.Location = New System.Drawing.Point(56, 327)
        Me.f_terrain.Name = "f_terrain"
        Me.f_terrain.Size = New System.Drawing.Size(97, 20)
        Me.f_terrain.TabIndex = 58
        Me.f_terrain.Text = "Firer's Cover"
        Me.f_terrain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetpanel
        '
        Me.targetpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetpanel.Controls.Add(Me.ta_ecm_ds)
        Me.targetpanel.Controls.Add(Me.ta_ecm_gs)
        Me.targetpanel.Controls.Add(Me.t2)
        Me.targetpanel.Controls.Add(Me.t3)
        Me.targetpanel.Controls.Add(Me.t1)
        Me.targetpanel.Controls.Add(Me.t_dismounted)
        Me.targetpanel.Controls.Add(Me.t_moving)
        Me.targetpanel.Controls.Add(Me.abort_target)
        Me.targetpanel.Controls.Add(Me.Label1)
        Me.targetpanel.Controls.Add(Me.ta_altitude)
        Me.targetpanel.Controls.Add(Me.twpn)
        Me.targetpanel.Controls.Add(Me.Label8)
        Me.targetpanel.Controls.Add(Me.ta_altitude_label)
        Me.targetpanel.Controls.Add(Me.t_insmoke)
        Me.targetpanel.Controls.Add(Me.t_elevation)
        Me.targetpanel.Controls.Add(Me.t_aspect)
        Me.targetpanel.Controls.Add(Me.t_mode)
        Me.targetpanel.Controls.Add(Me.targets)
        Me.targetpanel.Controls.Add(Me.t_plains)
        Me.targetpanel.Controls.Add(Me.t_roadmove)
        Me.targetpanel.Controls.Add(Me.t_cover)
        Me.targetpanel.Controls.Add(Me.t_status)
        Me.targetpanel.Controls.Add(Me.t_terrain)
        Me.targetpanel.Controls.Add(Me.t_view)
        Me.targetpanel.Controls.Add(Me.ta_ecm_label)
        Me.targetpanel.Location = New System.Drawing.Point(773, 12)
        Me.targetpanel.Name = "targetpanel"
        Me.targetpanel.Size = New System.Drawing.Size(499, 638)
        Me.targetpanel.TabIndex = 70
        '
        'ta_ecm_ds
        '
        Me.ta_ecm_ds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ta_ecm_ds.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ta_ecm_ds.Location = New System.Drawing.Point(337, 147)
        Me.ta_ecm_ds.Name = "ta_ecm_ds"
        Me.ta_ecm_ds.Size = New System.Drawing.Size(132, 30)
        Me.ta_ecm_ds.TabIndex = 96
        Me.ta_ecm_ds.Tag = "None"
        Me.ta_ecm_ds.Text = "None"
        Me.ta_ecm_ds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ta_ecm_gs
        '
        Me.ta_ecm_gs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ta_ecm_gs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ta_ecm_gs.Location = New System.Drawing.Point(337, 108)
        Me.ta_ecm_gs.Name = "ta_ecm_gs"
        Me.ta_ecm_gs.Size = New System.Drawing.Size(132, 30)
        Me.ta_ecm_gs.TabIndex = 95
        Me.ta_ecm_gs.Tag = "None"
        Me.ta_ecm_gs.Text = "None"
        Me.ta_ecm_gs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't2
        '
        Me.t2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t2.Location = New System.Drawing.Point(152, 554)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(40, 40)
        Me.t2.TabIndex = 94
        Me.t2.Tag = ""
        Me.t2.Text = "5"
        Me.t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't3
        '
        Me.t3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t3.Location = New System.Drawing.Point(198, 554)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(40, 40)
        Me.t3.TabIndex = 93
        Me.t3.Tag = ""
        Me.t3.Text = "5"
        Me.t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't1
        '
        Me.t1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t1.Location = New System.Drawing.Point(106, 554)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(40, 40)
        Me.t1.TabIndex = 92
        Me.t1.Tag = ""
        Me.t1.Text = "5"
        Me.t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_dismounted
        '
        Me.t_dismounted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_dismounted.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_dismounted.Location = New System.Drawing.Point(337, 186)
        Me.t_dismounted.Name = "t_dismounted"
        Me.t_dismounted.Size = New System.Drawing.Size(132, 30)
        Me.t_dismounted.TabIndex = 90
        Me.t_dismounted.Tag = "Dismount"
        Me.t_dismounted.Text = "Dismount"
        Me.t_dismounted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_moving
        '
        Me.t_moving.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_moving.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_moving.Location = New System.Drawing.Point(337, 147)
        Me.t_moving.Name = "t_moving"
        Me.t_moving.Size = New System.Drawing.Size(132, 30)
        Me.t_moving.TabIndex = 87
        Me.t_moving.Tag = "Static"
        Me.t_moving.Text = "Static"
        Me.t_moving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'abort_target
        '
        Me.abort_target.BackColor = System.Drawing.SystemColors.Control
        Me.abort_target.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abort_target.Location = New System.Drawing.Point(337, 571)
        Me.abort_target.Name = "abort_target"
        Me.abort_target.Size = New System.Drawing.Size(132, 35)
        Me.abort_target.TabIndex = 80
        Me.abort_target.Tag = "Target"
        Me.abort_target.Text = "Abort Flight"
        Me.abort_target.UseVisualStyleBackColor = False
        Me.abort_target.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(89, 525)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 20)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Target Firing Strength"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ta_altitude
        '
        Me.ta_altitude.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ta_altitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ta_altitude.Location = New System.Drawing.Point(337, 527)
        Me.ta_altitude.Name = "ta_altitude"
        Me.ta_altitude.Size = New System.Drawing.Size(132, 30)
        Me.ta_altitude.TabIndex = 77
        Me.ta_altitude.Tag = "Low"
        Me.ta_altitude.Text = "Low"
        Me.ta_altitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ta_altitude.Visible = False
        '
        'twpn
        '
        Me.twpn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.twpn.Enabled = False
        Me.twpn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.twpn.Location = New System.Drawing.Point(337, 46)
        Me.twpn.Name = "twpn"
        Me.twpn.Size = New System.Drawing.Size(132, 30)
        Me.twpn.TabIndex = 82
        Me.twpn.Tag = ""
        Me.twpn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(362, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 20)
        Me.Label8.TabIndex = 81
        Me.Label8.Text = "Equipment"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ta_altitude_label
        '
        Me.ta_altitude_label.AutoSize = True
        Me.ta_altitude_label.BackColor = System.Drawing.Color.Transparent
        Me.ta_altitude_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ta_altitude_label.Location = New System.Drawing.Point(341, 507)
        Me.ta_altitude_label.Name = "ta_altitude_label"
        Me.ta_altitude_label.Size = New System.Drawing.Size(124, 20)
        Me.ta_altitude_label.TabIndex = 78
        Me.ta_altitude_label.Text = "Target's Altitude"
        Me.ta_altitude_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ta_altitude_label.Visible = False
        '
        't_insmoke
        '
        Me.t_insmoke.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_insmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_insmoke.Location = New System.Drawing.Point(337, 470)
        Me.t_insmoke.Name = "t_insmoke"
        Me.t_insmoke.Size = New System.Drawing.Size(132, 30)
        Me.t_insmoke.TabIndex = 76
        Me.t_insmoke.Tag = "No Smoke"
        Me.t_insmoke.Text = "No Smoke"
        Me.t_insmoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_elevation
        '
        Me.t_elevation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_elevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_elevation.Location = New System.Drawing.Point(337, 289)
        Me.t_elevation.Name = "t_elevation"
        Me.t_elevation.Size = New System.Drawing.Size(132, 30)
        Me.t_elevation.TabIndex = 74
        Me.t_elevation.Tag = "Same Level"
        Me.t_elevation.Text = "Same Level"
        Me.t_elevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_aspect
        '
        Me.t_aspect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_aspect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_aspect.Location = New System.Drawing.Point(337, 250)
        Me.t_aspect.Name = "t_aspect"
        Me.t_aspect.Size = New System.Drawing.Size(132, 30)
        Me.t_aspect.TabIndex = 74
        Me.t_aspect.Tag = "Front"
        Me.t_aspect.Text = "Front"
        Me.t_aspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_mode
        '
        Me.t_mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_mode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_mode.Location = New System.Drawing.Point(337, 108)
        Me.t_mode.Name = "t_mode"
        Me.t_mode.Size = New System.Drawing.Size(132, 30)
        Me.t_mode.TabIndex = 73
        Me.t_mode.Tag = "Conc"
        Me.t_mode.Text = "Conc"
        Me.t_mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_plains
        '
        Me.t_plains.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_plains.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_plains.Location = New System.Drawing.Point(337, 431)
        Me.t_plains.Name = "t_plains"
        Me.t_plains.Size = New System.Drawing.Size(132, 30)
        Me.t_plains.TabIndex = 50
        Me.t_plains.Tag = "Open Terrain"
        Me.t_plains.Text = "Open Terrain"
        Me.t_plains.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_roadmove
        '
        Me.t_roadmove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t_roadmove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_roadmove.Location = New System.Drawing.Point(337, 392)
        Me.t_roadmove.Name = "t_roadmove"
        Me.t_roadmove.Size = New System.Drawing.Size(132, 30)
        Me.t_roadmove.TabIndex = 50
        Me.t_roadmove.Tag = "X Country"
        Me.t_roadmove.Text = "X Country"
        Me.t_roadmove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't_status
        '
        Me.t_status.AutoSize = True
        Me.t_status.BackColor = System.Drawing.Color.Transparent
        Me.t_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t_status.Location = New System.Drawing.Point(352, 85)
        Me.t_status.Name = "t_status"
        Me.t_status.Size = New System.Drawing.Size(106, 20)
        Me.t_status.TabIndex = 59
        Me.t_status.Text = "Target Status"
        Me.t_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ta_ecm_label
        '
        Me.ta_ecm_label.AutoSize = True
        Me.ta_ecm_label.BackColor = System.Drawing.Color.Transparent
        Me.ta_ecm_label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ta_ecm_label.Location = New System.Drawing.Point(341, 85)
        Me.ta_ecm_label.Name = "ta_ecm_label"
        Me.ta_ecm_label.Size = New System.Drawing.Size(123, 20)
        Me.ta_ecm_label.TabIndex = 97
        Me.ta_ecm_label.Text = "Target ECM Spt"
        Me.ta_ecm_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'return_fire
        '
        Me.return_fire.BackColor = System.Drawing.SystemColors.Control
        Me.return_fire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.return_fire.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.return_fire.Location = New System.Drawing.Point(27, 532)
        Me.return_fire.Name = "return_fire"
        Me.return_fire.Size = New System.Drawing.Size(165, 34)
        Me.return_fire.TabIndex = 85
        Me.return_fire.Tag = "Return Fire"
        Me.return_fire.Text = "Return Fire"
        Me.return_fire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.return_fire.Visible = False
        '
        'centrepanel
        '
        Me.centrepanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.centrepanel.Controls.Add(Me.Label6)
        Me.centrepanel.Controls.Add(Me.Label9)
        Me.centrepanel.Controls.Add(Me.swap)
        Me.centrepanel.Controls.Add(Me.tgt_range_select)
        Me.centrepanel.Controls.Add(Me.tgt_range)
        Me.centrepanel.Controls.Add(Me.return_fire)
        Me.centrepanel.Controls.Add(Me.vis_range_select)
        Me.centrepanel.Controls.Add(Me.visrange)
        Me.centrepanel.Controls.Add(Me.firesmoke)
        Me.centrepanel.Controls.Add(Me.fire)
        Me.centrepanel.Location = New System.Drawing.Point(526, 12)
        Me.centrepanel.Name = "centrepanel"
        Me.centrepanel.Size = New System.Drawing.Size(223, 638)
        Me.centrepanel.TabIndex = 83
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(120, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 23)
        Me.Label6.TabIndex = 88
        Me.Label6.Tag = "Range"
        Me.Label6.Text = "Range"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(15, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 23)
        Me.Label9.TabIndex = 87
        Me.Label9.Tag = "Obs"
        Me.Label9.Text = "Obs"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'swap
        '
        Me.swap.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.swap.Location = New System.Drawing.Point(27, 574)
        Me.swap.Name = "swap"
        Me.swap.Size = New System.Drawing.Size(165, 34)
        Me.swap.TabIndex = 86
        Me.swap.Text = "Swap"
        Me.swap.UseVisualStyleBackColor = True
        '
        'indirectfirepanel
        '
        Me.indirectfirepanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.indirectfirepanel.Controls.Add(Me.obs_insmoke)
        Me.indirectfirepanel.Controls.Add(Me.scoot)
        Me.indirectfirepanel.Controls.Add(Me.obs_moving)
        Me.indirectfirepanel.Controls.Add(Me.obs_mode)
        Me.indirectfirepanel.Controls.Add(Me.Label15)
        Me.indirectfirepanel.Controls.Add(Me.obs_elevation)
        Me.indirectfirepanel.Controls.Add(Me.observers)
        Me.indirectfirepanel.Controls.Add(Me.a2)
        Me.indirectfirepanel.Controls.Add(Me.a3)
        Me.indirectfirepanel.Controls.Add(Me.a1)
        Me.indirectfirepanel.Controls.Add(Me.artillery)
        Me.indirectfirepanel.Controls.Add(Me.Label20)
        Me.indirectfirepanel.Location = New System.Drawing.Point(12, 12)
        Me.indirectfirepanel.Name = "indirectfirepanel"
        Me.indirectfirepanel.Size = New System.Drawing.Size(491, 638)
        Me.indirectfirepanel.TabIndex = 95
        '
        'obs_insmoke
        '
        Me.obs_insmoke.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.obs_insmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obs_insmoke.Location = New System.Drawing.Point(45, 492)
        Me.obs_insmoke.Name = "obs_insmoke"
        Me.obs_insmoke.Size = New System.Drawing.Size(132, 30)
        Me.obs_insmoke.TabIndex = 111
        Me.obs_insmoke.Tag = "No Smoke"
        Me.obs_insmoke.Text = "No Smoke"
        Me.obs_insmoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'scoot
        '
        Me.scoot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.scoot.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scoot.Location = New System.Drawing.Point(289, 594)
        Me.scoot.Name = "scoot"
        Me.scoot.Size = New System.Drawing.Size(132, 30)
        Me.scoot.TabIndex = 110
        Me.scoot.Tag = "Stay and Shoot "
        Me.scoot.Text = "Stay and Shoot "
        Me.scoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'obs_moving
        '
        Me.obs_moving.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.obs_moving.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obs_moving.Location = New System.Drawing.Point(45, 560)
        Me.obs_moving.Name = "obs_moving"
        Me.obs_moving.Size = New System.Drawing.Size(132, 30)
        Me.obs_moving.TabIndex = 109
        Me.obs_moving.Tag = "Static"
        Me.obs_moving.Text = "Static"
        Me.obs_moving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'obs_mode
        '
        Me.obs_mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.obs_mode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obs_mode.Location = New System.Drawing.Point(45, 527)
        Me.obs_mode.Name = "obs_mode"
        Me.obs_mode.Size = New System.Drawing.Size(132, 30)
        Me.obs_mode.TabIndex = 108
        Me.obs_mode.Tag = "Conc"
        Me.obs_mode.Text = "Conc"
        Me.obs_mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(53, 470)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 20)
        Me.Label15.TabIndex = 107
        Me.Label15.Text = "Observer Status"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'obs_elevation
        '
        Me.obs_elevation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.obs_elevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obs_elevation.Location = New System.Drawing.Point(45, 593)
        Me.obs_elevation.Name = "obs_elevation"
        Me.obs_elevation.Size = New System.Drawing.Size(132, 30)
        Me.obs_elevation.TabIndex = 106
        Me.obs_elevation.Tag = "Same Level"
        Me.obs_elevation.Text = "Same Level"
        Me.obs_elevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'observers
        '
        Me.observers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10})
        Me.observers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observers.FullRowSelect = True
        Me.observers.GridLines = True
        Me.observers.Location = New System.Drawing.Point(17, 15)
        Me.observers.MultiSelect = False
        Me.observers.Name = "observers"
        Me.observers.Size = New System.Drawing.Size(189, 452)
        Me.observers.TabIndex = 105
        Me.observers.Tag = ""
        Me.observers.UseCompatibleStateImageBehavior = False
        Me.observers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Unit"
        Me.ColumnHeader10.Width = 173
        '
        'a2
        '
        Me.a2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.a2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.a2.Location = New System.Drawing.Point(334, 536)
        Me.a2.Name = "a2"
        Me.a2.Size = New System.Drawing.Size(40, 40)
        Me.a2.TabIndex = 104
        Me.a2.Text = "5"
        Me.a2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'a3
        '
        Me.a3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.a3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.a3.Location = New System.Drawing.Point(380, 536)
        Me.a3.Name = "a3"
        Me.a3.Size = New System.Drawing.Size(40, 40)
        Me.a3.TabIndex = 103
        Me.a3.Text = "5"
        Me.a3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'a1
        '
        Me.a1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.a1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.a1.Location = New System.Drawing.Point(288, 536)
        Me.a1.Name = "a1"
        Me.a1.Size = New System.Drawing.Size(40, 40)
        Me.a1.TabIndex = 102
        Me.a1.Text = "5"
        Me.a1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'artillery
        '
        Me.artillery.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.artillery.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.artillery.FullRowSelect = True
        Me.artillery.GridLines = True
        Me.artillery.Location = New System.Drawing.Point(216, 15)
        Me.artillery.MultiSelect = False
        Me.artillery.Name = "artillery"
        Me.artillery.Size = New System.Drawing.Size(258, 485)
        Me.artillery.TabIndex = 97
        Me.artillery.Tag = ""
        Me.artillery.UseCompatibleStateImageBehavior = False
        Me.artillery.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Unit"
        Me.ColumnHeader11.Width = 114
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Str"
        Me.ColumnHeader12.Width = 35
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Equip"
        Me.ColumnHeader13.Width = 100
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(285, 507)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(150, 20)
        Me.Label20.TabIndex = 96
        Me.Label20.Text = "Firer Firing Strength"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'combat_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.centrepanel)
        Me.Controls.Add(Me.targetpanel)
        Me.Controls.Add(Me.indirectfirepanel)
        Me.Controls.Add(Me.directfirepanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "combat_2"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Firing"
        Me.directfirepanel.ResumeLayout(False)
        Me.directfirepanel.PerformLayout()
        Me.targetpanel.ResumeLayout(False)
        Me.targetpanel.PerformLayout()
        Me.centrepanel.ResumeLayout(False)
        Me.indirectfirepanel.ResumeLayout(False)
        Me.indirectfirepanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents f_view As System.Windows.Forms.Label
    Friend WithEvents targets As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents t_view As System.Windows.Forms.Label
    Friend WithEvents t_terrain As System.Windows.Forms.Label
    Friend WithEvents t_cover As System.Windows.Forms.Label
    Friend WithEvents firesmoke As System.Windows.Forms.Button
    Friend WithEvents fire As System.Windows.Forms.Button
    Friend WithEvents visrange As System.Windows.Forms.Label
    Friend WithEvents tgt_range As System.Windows.Forms.Label
    Friend WithEvents vis_range_select As System.Windows.Forms.ListBox
    Friend WithEvents tgt_range_select As System.Windows.Forms.ListBox
    Friend WithEvents directfirepanel As Panel
    Friend WithEvents targetpanel As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents t_aspect As Label
    Friend WithEvents t_plains As Label
    Friend WithEvents t_roadmove As Label
    Friend WithEvents t_elevation As Label
    Friend WithEvents t_insmoke As Label
    Friend WithEvents ta_altitude As Label
    Friend WithEvents ta_altitude_label As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents abort_target As Button
    Friend WithEvents f_mode As Label
    Friend WithEvents f_status As Label
    Friend WithEvents t_mode As Label
    Friend WithEvents t_status As Label
    Friend WithEvents firers As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents centrepanel As Panel
    Friend WithEvents return_fire As Label
    Friend WithEvents abort_firer As Button
    Friend WithEvents t_moving As Label
    Friend WithEvents t_dismounted As Label
    Friend WithEvents Secondary As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents s2 As Label
    Friend WithEvents s3 As Label
    Friend WithEvents s1 As Label
    Friend WithEvents t2 As Label
    Friend WithEvents t3 As Label
    Friend WithEvents t1 As Label
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents fwpn As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents twpn As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents swap As Button
    Friend WithEvents indirectfirepanel As Panel
    Friend WithEvents observers As ListView
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents a2 As Label
    Friend WithEvents a3 As Label
    Friend WithEvents a1 As Label
    Friend WithEvents artillery As ListView
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents Label20 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents obs_moving As Label
    Friend WithEvents obs_mode As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents obs_elevation As Label
    Friend WithEvents scoot As Label
    Friend WithEvents f_dismounted As Label
    Friend WithEvents f_moving As Label
    Friend WithEvents f_insmoke As Label
    Friend WithEvents f_elevation As Label
    Friend WithEvents f_aspect As Label
    Friend WithEvents f_plains As Label
    Friend WithEvents f_roadmove As Label
    Friend WithEvents f_cover As Label
    Friend WithEvents f_terrain As Label
    Friend WithEvents fa_altitude As Label
    Friend WithEvents fa_altitude_label As Label
    Friend WithEvents ta_ecm_ds As Label
    Friend WithEvents ta_ecm_gs As Label
    Friend WithEvents ta_ecm_label As Label
    Friend WithEvents obs_insmoke As Label
End Class
