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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.firercover = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.selectedfirer = New System.Windows.Forms.Label()
        Me.selectedtarget = New System.Windows.Forms.Label()
        Me.targets = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.targetcover = New System.Windows.Forms.Label()
        Me.firesmoke = New System.Windows.Forms.Button()
        Me.fire = New System.Windows.Forms.Button()
        Me.visrange = New System.Windows.Forms.Label()
        Me.tgt_range = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.vis_range_select = New System.Windows.Forms.ListBox()
        Me.tgt_range_select = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.observer = New System.Windows.Forms.Label()
        Me.finsmoke = New System.Windows.Forms.Label()
        Me.firerelevation = New System.Windows.Forms.Label()
        Me.fireraspect = New System.Windows.Forms.Label()
        Me.firerprimary = New System.Windows.Forms.Label()
        Me.s2 = New System.Windows.Forms.Label()
        Me.s3 = New System.Windows.Forms.Label()
        Me.s1 = New System.Windows.Forms.Label()
        Me.fplains = New System.Windows.Forms.Label()
        Me.froadmove = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.return_fire = New System.Windows.Forms.Panel()
        Me.t2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.t3 = New System.Windows.Forms.Label()
        Me.t1 = New System.Windows.Forms.Label()
        Me.taltitude = New System.Windows.Forms.Label()
        Me.altitude = New System.Windows.Forms.Label()
        Me.tinsmoke = New System.Windows.Forms.Label()
        Me.targetelevation = New System.Windows.Forms.Label()
        Me.return_fire2 = New System.Windows.Forms.Label()
        Me.targetaspect = New System.Windows.Forms.Label()
        Me.targetprimary = New System.Windows.Forms.Label()
        Me.tplains = New System.Windows.Forms.Label()
        Me.troadmove = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.return_fire.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(27, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(181, 20)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Firer's view of the Target"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(76, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Weapon"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firercover
        '
        Me.firercover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firercover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firercover.Location = New System.Drawing.Point(43, 271)
        Me.firercover.Name = "firercover"
        Me.firercover.Size = New System.Drawing.Size(132, 34)
        Me.firercover.TabIndex = 50
        Me.firercover.Tag = "1"
        Me.firercover.Text = "None"
        Me.firercover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(67, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 20)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Firer's Cover"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'selectedfirer
        '
        Me.selectedfirer.BackColor = System.Drawing.Color.Transparent
        Me.selectedfirer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.selectedfirer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedfirer.Location = New System.Drawing.Point(21, 19)
        Me.selectedfirer.Name = "selectedfirer"
        Me.selectedfirer.Size = New System.Drawing.Size(199, 35)
        Me.selectedfirer.TabIndex = 60
        Me.selectedfirer.Text = "Firing Unit"
        Me.selectedfirer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'selectedtarget
        '
        Me.selectedtarget.BackColor = System.Drawing.Color.Transparent
        Me.selectedtarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.selectedtarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedtarget.Location = New System.Drawing.Point(86, 19)
        Me.selectedtarget.Name = "selectedtarget"
        Me.selectedtarget.Size = New System.Drawing.Size(245, 35)
        Me.selectedtarget.TabIndex = 60
        Me.selectedtarget.Text = "Target Unit"
        Me.selectedtarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targets
        '
        Me.targets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader1})
        Me.targets.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targets.FullRowSelect = True
        Me.targets.GridLines = True
        Me.targets.HideSelection = False
        Me.targets.Location = New System.Drawing.Point(47, 66)
        Me.targets.MultiSelect = False
        Me.targets.Name = "targets"
        Me.targets.Size = New System.Drawing.Size(364, 518)
        Me.targets.TabIndex = 61
        Me.targets.Tag = ""
        Me.targets.UseCompatibleStateImageBehavior = False
        Me.targets.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Unit"
        Me.ColumnHeader3.Width = 138
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DisplayIndex = 2
        Me.ColumnHeader5.Text = "Equipment"
        Me.ColumnHeader5.Width = 144
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 1
        Me.ColumnHeader1.Text = "Strength"
        Me.ColumnHeader1.Width = 75
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(417, 138)
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
        Me.Label11.Location = New System.Drawing.Point(454, 251)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 20)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Target's Cover"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(474, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 20)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "Weapon"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetcover
        '
        Me.targetcover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetcover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetcover.Location = New System.Drawing.Point(447, 271)
        Me.targetcover.Name = "targetcover"
        Me.targetcover.Size = New System.Drawing.Size(132, 34)
        Me.targetcover.TabIndex = 50
        Me.targetcover.Tag = "2"
        Me.targetcover.Text = "None"
        Me.targetcover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firesmoke
        '
        Me.firesmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firesmoke.Location = New System.Drawing.Point(198, 546)
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
        Me.fire.Location = New System.Drawing.Point(385, 546)
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
        Me.visrange.Location = New System.Drawing.Point(469, 19)
        Me.visrange.Name = "visrange"
        Me.visrange.Size = New System.Drawing.Size(78, 35)
        Me.visrange.TabIndex = 60
        Me.visrange.Text = "Vis Range"
        Me.visrange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tgt_range
        '
        Me.tgt_range.BackColor = System.Drawing.Color.Transparent
        Me.tgt_range.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tgt_range.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tgt_range.Location = New System.Drawing.Point(239, 19)
        Me.tgt_range.Name = "tgt_range"
        Me.tgt_range.Size = New System.Drawing.Size(78, 35)
        Me.tgt_range.TabIndex = 63
        Me.tgt_range.Text = "Range"
        Me.tgt_range.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.BackColor = System.Drawing.Color.Transparent
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.White
        Me.title.Location = New System.Drawing.Point(170, 9)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(162, 29)
        Me.title.TabIndex = 64
        Me.title.Text = "Resolve Fire"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'vis_range_select
        '
        Me.vis_range_select.BackColor = System.Drawing.SystemColors.Control
        Me.vis_range_select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.vis_range_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vis_range_select.FormattingEnabled = True
        Me.vis_range_select.ItemHeight = 24
        Me.vis_range_select.Items.AddRange(New Object() {"300", "600", "1000", "1500", "2000", "2500", "3000", "4000", "5000", "6000", "8000", "10000", "15000", "20000", "25000", "30000"})
        Me.vis_range_select.Location = New System.Drawing.Point(469, 66)
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
        Me.tgt_range_select.Location = New System.Drawing.Point(239, 66)
        Me.tgt_range_select.Name = "tgt_range_select"
        Me.tgt_range_select.Size = New System.Drawing.Size(94, 384)
        Me.tgt_range_select.TabIndex = 68
        Me.tgt_range_select.Tag = "1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.observer)
        Me.Panel1.Controls.Add(Me.finsmoke)
        Me.Panel1.Controls.Add(Me.firerelevation)
        Me.Panel1.Controls.Add(Me.fireraspect)
        Me.Panel1.Controls.Add(Me.firerprimary)
        Me.Panel1.Controls.Add(Me.s2)
        Me.Panel1.Controls.Add(Me.s3)
        Me.Panel1.Controls.Add(Me.s1)
        Me.Panel1.Controls.Add(Me.fplains)
        Me.Panel1.Controls.Add(Me.tgt_range_select)
        Me.Panel1.Controls.Add(Me.froadmove)
        Me.Panel1.Controls.Add(Me.vis_range_select)
        Me.Panel1.Controls.Add(Me.tgt_range)
        Me.Panel1.Controls.Add(Me.fire)
        Me.Panel1.Controls.Add(Me.firesmoke)
        Me.Panel1.Controls.Add(Me.visrange)
        Me.Panel1.Controls.Add(Me.selectedfirer)
        Me.Panel1.Controls.Add(Me.firercover)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(28, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 606)
        Me.Panel1.TabIndex = 69
        '
        'observer
        '
        Me.observer.BackColor = System.Drawing.Color.Transparent
        Me.observer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.observer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.observer.Location = New System.Drawing.Point(336, 19)
        Me.observer.Name = "observer"
        Me.observer.Size = New System.Drawing.Size(114, 35)
        Me.observer.TabIndex = 76
        Me.observer.Text = "Observer"
        Me.observer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'finsmoke
        '
        Me.finsmoke.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.finsmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finsmoke.Location = New System.Drawing.Point(43, 410)
        Me.finsmoke.Name = "finsmoke"
        Me.finsmoke.Size = New System.Drawing.Size(132, 34)
        Me.finsmoke.TabIndex = 75
        Me.finsmoke.Tag = "1"
        Me.finsmoke.Text = "No Smoke"
        Me.finsmoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firerelevation
        '
        Me.firerelevation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firerelevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firerelevation.Location = New System.Drawing.Point(43, 207)
        Me.firerelevation.Name = "firerelevation"
        Me.firerelevation.Size = New System.Drawing.Size(132, 34)
        Me.firerelevation.TabIndex = 74
        Me.firerelevation.Tag = "1"
        Me.firerelevation.Text = "Same Level"
        Me.firerelevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fireraspect
        '
        Me.fireraspect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fireraspect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fireraspect.Location = New System.Drawing.Point(43, 161)
        Me.fireraspect.Name = "fireraspect"
        Me.fireraspect.Size = New System.Drawing.Size(132, 34)
        Me.fireraspect.TabIndex = 73
        Me.fireraspect.Tag = "1"
        Me.fireraspect.Text = "Front"
        Me.fireraspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firerprimary
        '
        Me.firerprimary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.firerprimary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firerprimary.Location = New System.Drawing.Point(43, 92)
        Me.firerprimary.Name = "firerprimary"
        Me.firerprimary.Size = New System.Drawing.Size(132, 34)
        Me.firerprimary.TabIndex = 72
        Me.firerprimary.Tag = ""
        Me.firerprimary.Text = "Primary"
        Me.firerprimary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        's2
        '
        Me.s2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s2.Location = New System.Drawing.Point(89, 546)
        Me.s2.Name = "s2"
        Me.s2.Size = New System.Drawing.Size(40, 40)
        Me.s2.TabIndex = 71
        Me.s2.Text = "5"
        Me.s2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        's3
        '
        Me.s3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s3.Location = New System.Drawing.Point(135, 546)
        Me.s3.Name = "s3"
        Me.s3.Size = New System.Drawing.Size(40, 40)
        Me.s3.TabIndex = 70
        Me.s3.Text = "5"
        Me.s3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        's1
        '
        Me.s1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.s1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s1.Location = New System.Drawing.Point(43, 546)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(40, 40)
        Me.s1.TabIndex = 69
        Me.s1.Text = "5"
        Me.s1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fplains
        '
        Me.fplains.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.fplains.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fplains.Location = New System.Drawing.Point(43, 363)
        Me.fplains.Name = "fplains"
        Me.fplains.Size = New System.Drawing.Size(132, 34)
        Me.fplains.TabIndex = 50
        Me.fplains.Tag = "1"
        Me.fplains.Text = "Clear Terrain"
        Me.fplains.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'froadmove
        '
        Me.froadmove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.froadmove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.froadmove.Location = New System.Drawing.Point(43, 315)
        Me.froadmove.Name = "froadmove"
        Me.froadmove.Size = New System.Drawing.Size(132, 34)
        Me.froadmove.TabIndex = 50
        Me.froadmove.Tag = "1"
        Me.froadmove.Text = "X Country"
        Me.froadmove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(54, 526)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 20)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Firing Strength"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.return_fire)
        Me.Panel2.Controls.Add(Me.taltitude)
        Me.Panel2.Controls.Add(Me.altitude)
        Me.Panel2.Controls.Add(Me.tinsmoke)
        Me.Panel2.Controls.Add(Me.targetelevation)
        Me.Panel2.Controls.Add(Me.return_fire2)
        Me.Panel2.Controls.Add(Me.targetaspect)
        Me.Panel2.Controls.Add(Me.targetprimary)
        Me.Panel2.Controls.Add(Me.targets)
        Me.Panel2.Controls.Add(Me.selectedtarget)
        Me.Panel2.Controls.Add(Me.tplains)
        Me.Panel2.Controls.Add(Me.troadmove)
        Me.Panel2.Controls.Add(Me.targetcover)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Location = New System.Drawing.Point(620, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(639, 605)
        Me.Panel2.TabIndex = 70
        '
        'return_fire
        '
        Me.return_fire.Controls.Add(Me.t2)
        Me.return_fire.Controls.Add(Me.Label1)
        Me.return_fire.Controls.Add(Me.t3)
        Me.return_fire.Controls.Add(Me.t1)
        Me.return_fire.Location = New System.Drawing.Point(428, 523)
        Me.return_fire.Name = "return_fire"
        Me.return_fire.Size = New System.Drawing.Size(169, 75)
        Me.return_fire.TabIndex = 79
        '
        't2
        '
        Me.t2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t2.Location = New System.Drawing.Point(64, 24)
        Me.t2.Name = "t2"
        Me.t2.Size = New System.Drawing.Size(40, 40)
        Me.t2.TabIndex = 71
        Me.t2.Tag = ""
        Me.t2.Text = "5"
        Me.t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 20)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Target Firing Strength"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't3
        '
        Me.t3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t3.Location = New System.Drawing.Point(110, 24)
        Me.t3.Name = "t3"
        Me.t3.Size = New System.Drawing.Size(40, 40)
        Me.t3.TabIndex = 70
        Me.t3.Tag = ""
        Me.t3.Text = "5"
        Me.t3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        't1
        '
        Me.t1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.t1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.t1.Location = New System.Drawing.Point(18, 24)
        Me.t1.Name = "t1"
        Me.t1.Size = New System.Drawing.Size(40, 40)
        Me.t1.TabIndex = 69
        Me.t1.Tag = ""
        Me.t1.Text = "5"
        Me.t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'taltitude
        '
        Me.taltitude.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.taltitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.taltitude.Location = New System.Drawing.Point(447, 474)
        Me.taltitude.Name = "taltitude"
        Me.taltitude.Size = New System.Drawing.Size(132, 34)
        Me.taltitude.TabIndex = 77
        Me.taltitude.Tag = ""
        Me.taltitude.Text = "Low"
        Me.taltitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.taltitude.Visible = False
        '
        'altitude
        '
        Me.altitude.AutoSize = True
        Me.altitude.BackColor = System.Drawing.Color.Transparent
        Me.altitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altitude.Location = New System.Drawing.Point(454, 454)
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
        Me.tinsmoke.Location = New System.Drawing.Point(447, 410)
        Me.tinsmoke.Name = "tinsmoke"
        Me.tinsmoke.Size = New System.Drawing.Size(132, 34)
        Me.tinsmoke.TabIndex = 76
        Me.tinsmoke.Tag = "2"
        Me.tinsmoke.Text = "No Smoke"
        Me.tinsmoke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetelevation
        '
        Me.targetelevation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetelevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetelevation.Location = New System.Drawing.Point(447, 207)
        Me.targetelevation.Name = "targetelevation"
        Me.targetelevation.Size = New System.Drawing.Size(132, 34)
        Me.targetelevation.TabIndex = 74
        Me.targetelevation.Tag = "2"
        Me.targetelevation.Text = "Same Level"
        Me.targetelevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'return_fire2
        '
        Me.return_fire2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.return_fire2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.return_fire2.Location = New System.Drawing.Point(433, 12)
        Me.return_fire2.Name = "return_fire2"
        Me.return_fire2.Size = New System.Drawing.Size(165, 42)
        Me.return_fire2.TabIndex = 75
        Me.return_fire2.Text = "Return Fire"
        Me.return_fire2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetaspect
        '
        Me.targetaspect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetaspect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetaspect.Location = New System.Drawing.Point(447, 161)
        Me.targetaspect.Name = "targetaspect"
        Me.targetaspect.Size = New System.Drawing.Size(132, 34)
        Me.targetaspect.TabIndex = 74
        Me.targetaspect.Tag = "2"
        Me.targetaspect.Text = "Front"
        Me.targetaspect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targetprimary
        '
        Me.targetprimary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.targetprimary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetprimary.Location = New System.Drawing.Point(447, 92)
        Me.targetprimary.Name = "targetprimary"
        Me.targetprimary.Size = New System.Drawing.Size(132, 34)
        Me.targetprimary.TabIndex = 73
        Me.targetprimary.Tag = ""
        Me.targetprimary.Text = "Primary"
        Me.targetprimary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tplains
        '
        Me.tplains.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tplains.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tplains.Location = New System.Drawing.Point(447, 363)
        Me.tplains.Name = "tplains"
        Me.tplains.Size = New System.Drawing.Size(132, 34)
        Me.tplains.TabIndex = 50
        Me.tplains.Tag = "2"
        Me.tplains.Text = "Clear Terrain"
        Me.tplains.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'troadmove
        '
        Me.troadmove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.troadmove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.troadmove.Location = New System.Drawing.Point(447, 315)
        Me.troadmove.Name = "troadmove"
        Me.troadmove.Size = New System.Drawing.Size(132, 34)
        Me.troadmove.TabIndex = 50
        Me.troadmove.Tag = "2"
        Me.troadmove.Text = "X Country"
        Me.troadmove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'combat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.title)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "combat"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Firing"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.return_fire.ResumeLayout(False)
        Me.return_fire.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents firercover As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents selectedfirer As System.Windows.Forms.Label
    Friend WithEvents selectedtarget As System.Windows.Forms.Label
    Friend WithEvents targets As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents targetcover As System.Windows.Forms.Label
    Friend WithEvents firesmoke As System.Windows.Forms.Button
    Friend WithEvents fire As System.Windows.Forms.Button
    Friend WithEvents visrange As System.Windows.Forms.Label
    Friend WithEvents tgt_range As System.Windows.Forms.Label
    Friend WithEvents title As System.Windows.Forms.Label
    Friend WithEvents vis_range_select As System.Windows.Forms.ListBox
    Friend WithEvents tgt_range_select As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents s2 As Label
    Friend WithEvents s3 As Label
    Friend WithEvents s1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents firerprimary As Label
    Friend WithEvents targetprimary As Label
    Friend WithEvents fireraspect As Label
    Friend WithEvents targetaspect As Label
    Friend WithEvents firerelevation As Label
    Friend WithEvents tplains As Label
    Friend WithEvents troadmove As Label
    Friend WithEvents return_fire2 As Label
    Friend WithEvents targetelevation As Label
    Friend WithEvents fplains As Label
    Friend WithEvents froadmove As Label
    Friend WithEvents finsmoke As Label
    Friend WithEvents tinsmoke As Label
    Friend WithEvents taltitude As Label
    Friend WithEvents altitude As Label
    Friend WithEvents observer As Label
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents t2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents t3 As Label
    Friend WithEvents t1 As Label
    Friend WithEvents return_fire As Panel
End Class
