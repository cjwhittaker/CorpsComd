<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class combat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(combat))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.firercover = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.targets = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.targetcover = New System.Windows.Forms.Label()
        Me.firesmoke = New System.Windows.Forms.Button()
        Me.fire = New System.Windows.Forms.Button()
        Me.visrange = New System.Windows.Forms.Label()
        Me.tgt_range = New System.Windows.Forms.Label()
        Me.vis_range_select = New System.Windows.Forms.ListBox()
        Me.tgt_range_select = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.s2 = New System.Windows.Forms.Label()
        Me.s3 = New System.Windows.Forms.Label()
        Me.s1 = New System.Windows.Forms.Label()
        Me.firingmode = New System.Windows.Forms.Label()
        Me.firerdismounted = New System.Windows.Forms.Label()
        Me.firermoving = New System.Windows.Forms.Label()
        Me.abort_firer = New System.Windows.Forms.Button()
        Me.firers = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Secondary = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.firermode = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.finsmoke = New System.Windows.Forms.Label()
        Me.firerelevation = New System.Windows.Forms.Label()
        Me.fireraspect = New System.Windows.Forms.Label()
        Me.fplains = New System.Windows.Forms.Label()
        Me.froadmove = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.t2 = New System.Windows.Forms.Label()
        Me.t3 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.Label()
        Me.targetdismounted = New System.Windows.Forms.Label()
        Me.targetmoving = New System.Windows.Forms.Label()
        Me.abort_target = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.taltitude = New System.Windows.Forms.Label()
        Me.altitude = New System.Windows.Forms.Label()
        Me.tinsmoke = New System.Windows.Forms.Label()
        Me.targetelevation = New System.Windows.Forms.Label()
        Me.targetaspect = New System.Windows.Forms.Label()
        Me.targetmode = New System.Windows.Forms.Label()
        Me.tplains = New System.Windows.Forms.Label()
        Me.troadmove = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.return_fire = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Firer's view of the Target"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firercover
        '
        Me.firercover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firercover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firercover.Location = New System.Drawing.Point(40, 290)
        Me.firercover.Name = "firercover"
        Me.firercover.Size = New System.Drawing.Size(132, 30)
        Me.firercover.TabIndex = 50
        Me.firercover.Tag = "None"
        Me.firercover.Text = "None"
        Me.firercover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 264)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 20)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Firer's Cover"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targets
        '
        Me.targets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader2})
        Me.targets.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targets.FullRowSelect = True
        Me.targets.GridLines = True
        Me.targets.HideSelection = False
        Me.targets.Location = New System.Drawing.Point(23, 45)
        Me.targets.MultiSelect = False
        Me.targets.Name = "targets"
        Me.targets.Size = New System.Drawing.Size(238, 477)
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
        Me.ColumnHeader2.Text = "Equipment"
        Me.ColumnHeader2.Width = 102
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(298, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(181, 20)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Target's view of the Firer"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(333, 264)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 20)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Target's Cover"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetcover
        '
        Me.targetcover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetcover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetcover.Location = New System.Drawing.Point(322, 290)
        Me.targetcover.Name = "targetcover"
        Me.targetcover.Size = New System.Drawing.Size(132, 30)
        Me.targetcover.TabIndex = 50
        Me.targetcover.Tag = "None"
        Me.targetcover.Text = "None"
        Me.targetcover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firesmoke
        '
        Me.firesmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firesmoke.Location = New System.Drawing.Point(27, 448)
        Me.firesmoke.Name = "firesmoke"
        Me.firesmoke.Size = New System.Drawing.Size(165, 42)
        Me.firesmoke.TabIndex = 62
        Me.firesmoke.Text = "Fire Smoke"
        Me.firesmoke.UseVisualStyleBackColor = True
        Me.firesmoke.Visible = False
        '
        'fire
        '
        Me.fire.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fire.Location = New System.Drawing.Point(27, 499)
        Me.fire.Name = "fire"
        Me.fire.Size = New System.Drawing.Size(165, 42)
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
        Me.visrange.Location = New System.Drawing.Point(118, 11)
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
        Me.tgt_range.Location = New System.Drawing.Point(18, 11)
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
        Me.vis_range_select.Items.AddRange(New Object() {"300", "600", "1000", "1500", "2000", "2500", "3000", "4000", "5000", "6000", "8000", "10000", "15000", "20000", "25000", "30000"})
        Me.vis_range_select.Location = New System.Drawing.Point(118, 58)
        Me.vis_range_select.Name = "vis_range_select"
        Me.vis_range_select.Size = New System.Drawing.Size(94, 384)
        Me.vis_range_select.TabIndex = 67
        '
        'tgt_range_select
        '
        Me.tgt_range_select.BackColor = System.Drawing.SystemColors.Control
        Me.tgt_range_select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tgt_range_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tgt_range_select.FormattingEnabled = True
        Me.tgt_range_select.ItemHeight = 24
        Me.tgt_range_select.Items.AddRange(New Object() {"300", "600", "1000", "1500", "2000", "2500", "3000", "4000", "5000", "6000", "8000", "10000", "15000", "20000", "25000", "30000"})
        Me.tgt_range_select.Location = New System.Drawing.Point(18, 58)
        Me.tgt_range_select.Name = "tgt_range_select"
        Me.tgt_range_select.Size = New System.Drawing.Size(94, 384)
        Me.tgt_range_select.TabIndex = 68
        Me.tgt_range_select.Tag = "1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.s2)
        Me.Panel1.Controls.Add(Me.s3)
        Me.Panel1.Controls.Add(Me.s1)
        Me.Panel1.Controls.Add(Me.firingmode)
        Me.Panel1.Controls.Add(Me.firerdismounted)
        Me.Panel1.Controls.Add(Me.firermoving)
        Me.Panel1.Controls.Add(Me.abort_firer)
        Me.Panel1.Controls.Add(Me.firers)
        Me.Panel1.Controls.Add(Me.firermode)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.finsmoke)
        Me.Panel1.Controls.Add(Me.firerelevation)
        Me.Panel1.Controls.Add(Me.fireraspect)
        Me.Panel1.Controls.Add(Me.fplains)
        Me.Panel1.Controls.Add(Me.froadmove)
        Me.Panel1.Controls.Add(Me.firercover)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(491, 638)
        Me.Panel1.TabIndex = 69
        '
        's2
        '
        Me.s2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s2.Location = New System.Drawing.Point(335, 554)
        Me.s2.Name = "s2"
        Me.s2.Size = New System.Drawing.Size(40, 40)
        Me.s2.TabIndex = 94
        Me.s2.Text = "5"
        Me.s2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        's3
        '
        Me.s3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s3.Location = New System.Drawing.Point(381, 554)
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
        Me.s1.Location = New System.Drawing.Point(289, 554)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(40, 40)
        Me.s1.TabIndex = 92
        Me.s1.Text = "5"
        Me.s1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firingmode
        '
        Me.firingmode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firingmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firingmode.Location = New System.Drawing.Point(281, 8)
        Me.firingmode.Name = "firingmode"
        Me.firingmode.Size = New System.Drawing.Size(132, 30)
        Me.firingmode.TabIndex = 90
        Me.firingmode.Tag = "Direct Fire"
        Me.firingmode.Text = "Direct Fire"
        Me.firingmode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firerdismounted
        '
        Me.firerdismounted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firerdismounted.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firerdismounted.Location = New System.Drawing.Point(40, 123)
        Me.firerdismounted.Name = "firerdismounted"
        Me.firerdismounted.Size = New System.Drawing.Size(132, 30)
        Me.firerdismounted.TabIndex = 89
        Me.firerdismounted.Tag = "Dismounted"
        Me.firerdismounted.Text = "Dismounted"
        Me.firerdismounted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firermoving
        '
        Me.firermoving.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firermoving.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firermoving.Location = New System.Drawing.Point(40, 84)
        Me.firermoving.Name = "firermoving"
        Me.firermoving.Size = New System.Drawing.Size(132, 30)
        Me.firermoving.TabIndex = 87
        Me.firermoving.Tag = "Static"
        Me.firermoving.Text = "Static"
        Me.firermoving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'abort_firer
        '
        Me.abort_firer.BackColor = System.Drawing.SystemColors.Control
        Me.abort_firer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abort_firer.Location = New System.Drawing.Point(40, 525)
        Me.abort_firer.Name = "abort_firer"
        Me.abort_firer.Size = New System.Drawing.Size(132, 35)
        Me.abort_firer.TabIndex = 86
        Me.abort_firer.Text = "Abort Flight"
        Me.abort_firer.UseVisualStyleBackColor = False
        '
        'firers
        '
        Me.firers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.Secondary})
        Me.firers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firers.FullRowSelect = True
        Me.firers.GridLines = True
        Me.firers.HideSelection = False
        Me.firers.Location = New System.Drawing.Point(239, 45)
        Me.firers.MultiSelect = False
        Me.firers.Name = "firers"
        Me.firers.Size = New System.Drawing.Size(230, 477)
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
        Me.Secondary.Text = "Equipment"
        Me.Secondary.Width = 100
        '
        'firermode
        '
        Me.firermode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firermode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firermode.Location = New System.Drawing.Point(40, 45)
        Me.firermode.Name = "firermode"
        Me.firermode.Size = New System.Drawing.Size(132, 30)
        Me.firermode.TabIndex = 82
        Me.firermode.Tag = "Conc"
        Me.firermode.Text = "Conc"
        Me.firermode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 20)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Firer Status"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'finsmoke
        '
        Me.finsmoke.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.finsmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finsmoke.Location = New System.Drawing.Point(40, 407)
        Me.finsmoke.Name = "finsmoke"
        Me.finsmoke.Size = New System.Drawing.Size(132, 30)
        Me.finsmoke.TabIndex = 75
        Me.finsmoke.Tag = "No Smoke"
        Me.finsmoke.Text = "No Smoke"
        Me.finsmoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firerelevation
        '
        Me.firerelevation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firerelevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firerelevation.Location = New System.Drawing.Point(40, 226)
        Me.firerelevation.Name = "firerelevation"
        Me.firerelevation.Size = New System.Drawing.Size(132, 30)
        Me.firerelevation.TabIndex = 74
        Me.firerelevation.Tag = "Same Level"
        Me.firerelevation.Text = "Same Level"
        Me.firerelevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fireraspect
        '
        Me.fireraspect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fireraspect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fireraspect.Location = New System.Drawing.Point(40, 187)
        Me.fireraspect.Name = "fireraspect"
        Me.fireraspect.Size = New System.Drawing.Size(132, 30)
        Me.fireraspect.TabIndex = 73
        Me.fireraspect.Tag = "Front"
        Me.fireraspect.Text = "Front"
        Me.fireraspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fplains
        '
        Me.fplains.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fplains.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fplains.Location = New System.Drawing.Point(40, 368)
        Me.fplains.Name = "fplains"
        Me.fplains.Size = New System.Drawing.Size(132, 30)
        Me.fplains.TabIndex = 50
        Me.fplains.Tag = "Open Terrain"
        Me.fplains.Text = "Open Terrain"
        Me.fplains.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'froadmove
        '
        Me.froadmove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.froadmove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.froadmove.Location = New System.Drawing.Point(40, 329)
        Me.froadmove.Name = "froadmove"
        Me.froadmove.Size = New System.Drawing.Size(132, 30)
        Me.froadmove.TabIndex = 50
        Me.froadmove.Tag = "X Country"
        Me.froadmove.Text = "X Country"
        Me.froadmove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(299, 525)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 20)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Firing Strength"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.t2)
        Me.Panel2.Controls.Add(Me.t3)
        Me.Panel2.Controls.Add(Me.t1)
        Me.Panel2.Controls.Add(Me.targetdismounted)
        Me.Panel2.Controls.Add(Me.targetmoving)
        Me.Panel2.Controls.Add(Me.abort_target)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.taltitude)
        Me.Panel2.Controls.Add(Me.altitude)
        Me.Panel2.Controls.Add(Me.tinsmoke)
        Me.Panel2.Controls.Add(Me.targetelevation)
        Me.Panel2.Controls.Add(Me.targetaspect)
        Me.Panel2.Controls.Add(Me.targetmode)
        Me.Panel2.Controls.Add(Me.targets)
        Me.Panel2.Controls.Add(Me.tplains)
        Me.Panel2.Controls.Add(Me.troadmove)
        Me.Panel2.Controls.Add(Me.targetcover)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(773, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(499, 638)
        Me.Panel2.TabIndex = 70
        '
        't2
        '
        Me.t2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t2.Location = New System.Drawing.Point(114, 554)
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
        Me.t3.Location = New System.Drawing.Point(160, 554)
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
        Me.t1.Location = New System.Drawing.Point(68, 554)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(40, 40)
        Me.t1.TabIndex = 92
        Me.t1.Tag = ""
        Me.t1.Text = "5"
        Me.t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetdismounted
        '
        Me.targetdismounted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetdismounted.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetdismounted.Location = New System.Drawing.Point(322, 123)
        Me.targetdismounted.Name = "targetdismounted"
        Me.targetdismounted.Size = New System.Drawing.Size(132, 30)
        Me.targetdismounted.TabIndex = 90
        Me.targetdismounted.Tag = "Dismounted"
        Me.targetdismounted.Text = "Dismounted"
        Me.targetdismounted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetmoving
        '
        Me.targetmoving.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetmoving.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetmoving.Location = New System.Drawing.Point(322, 84)
        Me.targetmoving.Name = "targetmoving"
        Me.targetmoving.Size = New System.Drawing.Size(132, 30)
        Me.targetmoving.TabIndex = 87
        Me.targetmoving.Tag = "Static"
        Me.targetmoving.Text = "Static"
        Me.targetmoving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'abort_target
        '
        Me.abort_target.BackColor = System.Drawing.SystemColors.Control
        Me.abort_target.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abort_target.Location = New System.Drawing.Point(257, 528)
        Me.abort_target.Name = "abort_target"
        Me.abort_target.Size = New System.Drawing.Size(132, 35)
        Me.abort_target.TabIndex = 80
        Me.abort_target.Text = "Abort Flight"
        Me.abort_target.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(51, 525)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 20)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Target Firing Strength"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'taltitude
        '
        Me.taltitude.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.taltitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.taltitude.Location = New System.Drawing.Point(322, 464)
        Me.taltitude.Name = "taltitude"
        Me.taltitude.Size = New System.Drawing.Size(132, 30)
        Me.taltitude.TabIndex = 77
        Me.taltitude.Tag = "Low"
        Me.taltitude.Text = "Low"
        Me.taltitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.taltitude.Visible = False
        '
        'altitude
        '
        Me.altitude.AutoSize = True
        Me.altitude.BackColor = System.Drawing.Color.Transparent
        Me.altitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altitude.Location = New System.Drawing.Point(326, 444)
        Me.altitude.Name = "altitude"
        Me.altitude.Size = New System.Drawing.Size(124, 20)
        Me.altitude.TabIndex = 78
        Me.altitude.Text = "Target's Altitude"
        Me.altitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.altitude.Visible = False
        '
        'tinsmoke
        '
        Me.tinsmoke.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tinsmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tinsmoke.Location = New System.Drawing.Point(322, 407)
        Me.tinsmoke.Name = "tinsmoke"
        Me.tinsmoke.Size = New System.Drawing.Size(132, 30)
        Me.tinsmoke.TabIndex = 76
        Me.tinsmoke.Tag = "No Smoke"
        Me.tinsmoke.Text = "No Smoke"
        Me.tinsmoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetelevation
        '
        Me.targetelevation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetelevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetelevation.Location = New System.Drawing.Point(322, 226)
        Me.targetelevation.Name = "targetelevation"
        Me.targetelevation.Size = New System.Drawing.Size(132, 30)
        Me.targetelevation.TabIndex = 74
        Me.targetelevation.Tag = "Same Level"
        Me.targetelevation.Text = "Same Level"
        Me.targetelevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetaspect
        '
        Me.targetaspect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetaspect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetaspect.Location = New System.Drawing.Point(322, 187)
        Me.targetaspect.Name = "targetaspect"
        Me.targetaspect.Size = New System.Drawing.Size(132, 30)
        Me.targetaspect.TabIndex = 74
        Me.targetaspect.Tag = "Front"
        Me.targetaspect.Text = "Front"
        Me.targetaspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetmode
        '
        Me.targetmode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetmode.Location = New System.Drawing.Point(322, 45)
        Me.targetmode.Name = "targetmode"
        Me.targetmode.Size = New System.Drawing.Size(132, 30)
        Me.targetmode.TabIndex = 73
        Me.targetmode.Tag = "Conc"
        Me.targetmode.Text = "Conc"
        Me.targetmode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tplains
        '
        Me.tplains.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tplains.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tplains.Location = New System.Drawing.Point(322, 368)
        Me.tplains.Name = "tplains"
        Me.tplains.Size = New System.Drawing.Size(132, 30)
        Me.tplains.TabIndex = 50
        Me.tplains.Tag = "Open Terrain"
        Me.tplains.Text = "Open Terrain"
        Me.tplains.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'troadmove
        '
        Me.troadmove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.troadmove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.troadmove.Location = New System.Drawing.Point(322, 329)
        Me.troadmove.Name = "troadmove"
        Me.troadmove.Size = New System.Drawing.Size(132, 30)
        Me.troadmove.TabIndex = 50
        Me.troadmove.Tag = "X Country"
        Me.troadmove.Text = "X Country"
        Me.troadmove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(337, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 20)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Target Status"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'return_fire
        '
        Me.return_fire.BackColor = System.Drawing.SystemColors.Control
        Me.return_fire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.return_fire.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.return_fire.Location = New System.Drawing.Point(27, 550)
        Me.return_fire.Name = "return_fire"
        Me.return_fire.Size = New System.Drawing.Size(165, 42)
        Me.return_fire.TabIndex = 85
        Me.return_fire.Tag = "Return Fire"
        Me.return_fire.Text = "Return Fire"
        Me.return_fire.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.return_fire.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.tgt_range_select)
        Me.Panel3.Controls.Add(Me.tgt_range)
        Me.Panel3.Controls.Add(Me.return_fire)
        Me.Panel3.Controls.Add(Me.vis_range_select)
        Me.Panel3.Controls.Add(Me.visrange)
        Me.Panel3.Controls.Add(Me.firesmoke)
        Me.Panel3.Controls.Add(Me.fire)
        Me.Panel3.Location = New System.Drawing.Point(526, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(223, 638)
        Me.Panel3.TabIndex = 83
        '
        'combat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "combat"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Firing"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents firercover As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents targets As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents targetcover As System.Windows.Forms.Label
    Friend WithEvents firesmoke As System.Windows.Forms.Button
    Friend WithEvents fire As System.Windows.Forms.Button
    Friend WithEvents visrange As System.Windows.Forms.Label
    Friend WithEvents tgt_range As System.Windows.Forms.Label
    Friend WithEvents vis_range_select As System.Windows.Forms.ListBox
    Friend WithEvents tgt_range_select As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents fireraspect As Label
    Friend WithEvents targetaspect As Label
    Friend WithEvents firerelevation As Label
    Friend WithEvents tplains As Label
    Friend WithEvents troadmove As Label
    Friend WithEvents targetelevation As Label
    Friend WithEvents fplains As Label
    Friend WithEvents froadmove As Label
    Friend WithEvents finsmoke As Label
    Friend WithEvents tinsmoke As Label
    Friend WithEvents taltitude As Label
    Friend WithEvents altitude As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents abort_target As Button
    Friend WithEvents firermode As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents targetmode As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents firers As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents Panel3 As Panel
    Friend WithEvents return_fire As Label
    Friend WithEvents abort_firer As Button
    Friend WithEvents firermoving As Label
    Friend WithEvents targetmoving As Label
    Friend WithEvents firerdismounted As Label
    Friend WithEvents targetdismounted As Label
    Friend WithEvents Secondary As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents firingmode As Label
    Friend WithEvents s2 As Label
    Friend WithEvents s3 As Label
    Friend WithEvents s1 As Label
    Friend WithEvents t2 As Label
    Friend WithEvents t3 As Label
    Friend WithEvents t1 As Label
End Class
