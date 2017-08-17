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
        Me.observing = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.firerprimary = New System.Windows.Forms.CheckBox()
        Me.firersecondary = New System.Windows.Forms.CheckBox()
        Me.firerflank = New System.Windows.Forms.CheckBox()
        Me.firerrear = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.firercover = New System.Windows.Forms.Label()
        Me.select_cover_firer = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.selectedfirer = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.selectedtarget = New System.Windows.Forms.Label()
        Me.targets = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.targetprimary = New System.Windows.Forms.CheckBox()
        Me.targetsecondary = New System.Windows.Forms.CheckBox()
        Me.targetflank = New System.Windows.Forms.CheckBox()
        Me.targetrear = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.targetcover = New System.Windows.Forms.Label()
        Me.select_cover_target = New System.Windows.Forms.Button()
        Me.firesmoke = New System.Windows.Forms.Button()
        Me.fire = New System.Windows.Forms.Button()
        Me.visrange = New System.Windows.Forms.Label()
        Me.tgt_range = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.spot = New System.Windows.Forms.Button()
        Me.vis_range_select = New System.Windows.Forms.ListBox()
        Me.tgt_range_select = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'observing
        '
        Me.observing.AutoSize = True
        Me.observing.BackColor = System.Drawing.Color.Transparent
        Me.observing.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observing.Location = New System.Drawing.Point(266, 11)
        Me.observing.Name = "observing"
        Me.observing.Size = New System.Drawing.Size(97, 24)
        Me.observing.TabIndex = 9
        Me.observing.Text = "Observing"
        Me.observing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(423, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 24)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Firing"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'firerprimary
        '
        Me.firerprimary.Appearance = System.Windows.Forms.Appearance.Button
        Me.firerprimary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firerprimary.Location = New System.Drawing.Point(74, 126)
        Me.firerprimary.Name = "firerprimary"
        Me.firerprimary.Size = New System.Drawing.Size(101, 34)
        Me.firerprimary.TabIndex = 56
        Me.firerprimary.Text = "Primary"
        Me.firerprimary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.firerprimary.UseVisualStyleBackColor = True
        '
        'firersecondary
        '
        Me.firersecondary.Appearance = System.Windows.Forms.Appearance.Button
        Me.firersecondary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firersecondary.Location = New System.Drawing.Point(74, 166)
        Me.firersecondary.Name = "firersecondary"
        Me.firersecondary.Size = New System.Drawing.Size(101, 34)
        Me.firersecondary.TabIndex = 57
        Me.firersecondary.Text = "Secondary"
        Me.firersecondary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.firersecondary.UseVisualStyleBackColor = True
        '
        'firerflank
        '
        Me.firerflank.Appearance = System.Windows.Forms.Appearance.Button
        Me.firerflank.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firerflank.Location = New System.Drawing.Point(74, 232)
        Me.firerflank.Name = "firerflank"
        Me.firerflank.Size = New System.Drawing.Size(101, 34)
        Me.firerflank.TabIndex = 56
        Me.firerflank.Text = "Flank"
        Me.firerflank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.firerflank.UseVisualStyleBackColor = True
        '
        'firerrear
        '
        Me.firerrear.Appearance = System.Windows.Forms.Appearance.Button
        Me.firerrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firerrear.Location = New System.Drawing.Point(74, 272)
        Me.firerrear.Name = "firerrear"
        Me.firerrear.Size = New System.Drawing.Size(101, 34)
        Me.firerrear.TabIndex = 57
        Me.firerrear.Text = "Rear"
        Me.firerrear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.firerrear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 206)
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
        Me.Label3.Location = New System.Drawing.Point(90, 100)
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
        Me.firercover.Location = New System.Drawing.Point(74, 378)
        Me.firercover.Name = "firercover"
        Me.firercover.Size = New System.Drawing.Size(101, 34)
        Me.firercover.TabIndex = 50
        Me.firercover.Text = "None"
        Me.firercover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'select_cover_firer
        '
        Me.select_cover_firer.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.select_cover_firer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.select_cover_firer.Location = New System.Drawing.Point(74, 338)
        Me.select_cover_firer.Name = "select_cover_firer"
        Me.select_cover_firer.Size = New System.Drawing.Size(101, 34)
        Me.select_cover_firer.TabIndex = 49
        Me.select_cover_firer.Text = "Select"
        Me.select_cover_firer.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(76, 312)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 20)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Firer's Cover"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(76, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 24)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Firing Unit"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'selectedfirer
        '
        Me.selectedfirer.BackColor = System.Drawing.Color.Transparent
        Me.selectedfirer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.selectedfirer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedfirer.Location = New System.Drawing.Point(24, 43)
        Me.selectedfirer.Name = "selectedfirer"
        Me.selectedfirer.Size = New System.Drawing.Size(199, 35)
        Me.selectedfirer.TabIndex = 60
        Me.selectedfirer.Text = "Firing Unit"
        Me.selectedfirer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(142, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 24)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Target Unit"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'selectedtarget
        '
        Me.selectedtarget.BackColor = System.Drawing.Color.Transparent
        Me.selectedtarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.selectedtarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedtarget.Location = New System.Drawing.Point(69, 59)
        Me.selectedtarget.Name = "selectedtarget"
        Me.selectedtarget.Size = New System.Drawing.Size(245, 35)
        Me.selectedtarget.TabIndex = 60
        Me.selectedtarget.Text = "Target Unit"
        Me.selectedtarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'targets
        '
        Me.targets.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader5})
        Me.targets.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targets.FullRowSelect = True
        Me.targets.GridLines = True
        Me.targets.HideSelection = False
        Me.targets.Location = New System.Drawing.Point(10, 116)
        Me.targets.MultiSelect = False
        Me.targets.Name = "targets"
        Me.targets.Size = New System.Drawing.Size(364, 456)
        Me.targets.TabIndex = 61
        Me.targets.UseCompatibleStateImageBehavior = False
        Me.targets.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Unit"
        Me.ColumnHeader3.Width = 208
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Equipment"
        Me.ColumnHeader5.Width = 144
        '
        'targetprimary
        '
        Me.targetprimary.Appearance = System.Windows.Forms.Appearance.Button
        Me.targetprimary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetprimary.Location = New System.Drawing.Point(476, 142)
        Me.targetprimary.Name = "targetprimary"
        Me.targetprimary.Size = New System.Drawing.Size(101, 34)
        Me.targetprimary.TabIndex = 56
        Me.targetprimary.Text = "Primary"
        Me.targetprimary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.targetprimary.UseVisualStyleBackColor = True
        '
        'targetsecondary
        '
        Me.targetsecondary.Appearance = System.Windows.Forms.Appearance.Button
        Me.targetsecondary.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetsecondary.Location = New System.Drawing.Point(476, 182)
        Me.targetsecondary.Name = "targetsecondary"
        Me.targetsecondary.Size = New System.Drawing.Size(101, 34)
        Me.targetsecondary.TabIndex = 57
        Me.targetsecondary.Text = "Secondary"
        Me.targetsecondary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.targetsecondary.UseVisualStyleBackColor = True
        '
        'targetflank
        '
        Me.targetflank.Appearance = System.Windows.Forms.Appearance.Button
        Me.targetflank.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetflank.Location = New System.Drawing.Point(476, 248)
        Me.targetflank.Name = "targetflank"
        Me.targetflank.Size = New System.Drawing.Size(101, 34)
        Me.targetflank.TabIndex = 56
        Me.targetflank.Text = "Flank"
        Me.targetflank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.targetflank.UseVisualStyleBackColor = True
        '
        'targetrear
        '
        Me.targetrear.Appearance = System.Windows.Forms.Appearance.Button
        Me.targetrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.targetrear.Location = New System.Drawing.Point(476, 288)
        Me.targetrear.Name = "targetrear"
        Me.targetrear.Size = New System.Drawing.Size(101, 34)
        Me.targetrear.TabIndex = 57
        Me.targetrear.Text = "Rear"
        Me.targetrear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.targetrear.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(436, 222)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(181, 20)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Firer's view of the Target"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(478, 328)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 20)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "Firer's Cover"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(492, 116)
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
        Me.targetcover.Location = New System.Drawing.Point(476, 394)
        Me.targetcover.Name = "targetcover"
        Me.targetcover.Size = New System.Drawing.Size(101, 34)
        Me.targetcover.TabIndex = 50
        Me.targetcover.Text = "None"
        Me.targetcover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'select_cover_target
        '
        Me.select_cover_target.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.select_cover_target.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.select_cover_target.Location = New System.Drawing.Point(476, 354)
        Me.select_cover_target.Name = "select_cover_target"
        Me.select_cover_target.Size = New System.Drawing.Size(101, 34)
        Me.select_cover_target.TabIndex = 49
        Me.select_cover_target.Text = "Select"
        Me.select_cover_target.UseVisualStyleBackColor = True
        '
        'firesmoke
        '
        Me.firesmoke.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.firesmoke.Location = New System.Drawing.Point(10, 501)
        Me.firesmoke.Name = "firesmoke"
        Me.firesmoke.Size = New System.Drawing.Size(165, 87)
        Me.firesmoke.TabIndex = 62
        Me.firesmoke.Text = "Fire Smoke"
        Me.firesmoke.UseVisualStyleBackColor = True
        Me.firesmoke.Visible = False
        '
        'fire
        '
        Me.fire.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fire.Location = New System.Drawing.Point(396, 501)
        Me.fire.Name = "fire"
        Me.fire.Size = New System.Drawing.Size(165, 87)
        Me.fire.TabIndex = 62
        Me.fire.Text = "Fire"
        Me.fire.UseVisualStyleBackColor = True
        '
        'visrange
        '
        Me.visrange.BackColor = System.Drawing.Color.Transparent
        Me.visrange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.visrange.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.visrange.Location = New System.Drawing.Point(249, 43)
        Me.visrange.Name = "visrange"
        Me.visrange.Size = New System.Drawing.Size(114, 35)
        Me.visrange.TabIndex = 60
        Me.visrange.Text = "Vis Range"
        Me.visrange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tgt_range
        '
        Me.tgt_range.BackColor = System.Drawing.Color.Transparent
        Me.tgt_range.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tgt_range.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tgt_range.Location = New System.Drawing.Point(396, 43)
        Me.tgt_range.Name = "tgt_range"
        Me.tgt_range.Size = New System.Drawing.Size(114, 35)
        Me.tgt_range.TabIndex = 63
        Me.tgt_range.Text = "Range"
        Me.tgt_range.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.BackColor = System.Drawing.Color.Transparent
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(1, -2)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(202, 29)
        Me.title.TabIndex = 64
        Me.title.Text = "Tactical Combat"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'spot
        '
        Me.spot.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spot.Location = New System.Drawing.Point(207, 501)
        Me.spot.Name = "spot"
        Me.spot.Size = New System.Drawing.Size(165, 87)
        Me.spot.TabIndex = 62
        Me.spot.Text = "Spot"
        Me.spot.UseVisualStyleBackColor = True
        '
        'vis_range_select
        '
        Me.vis_range_select.BackColor = System.Drawing.SystemColors.Control
        Me.vis_range_select.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.vis_range_select.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vis_range_select.FormattingEnabled = True
        Me.vis_range_select.ItemHeight = 24
        Me.vis_range_select.Items.AddRange(New Object() {"0", "125", "250", "500", "750", "1000", "1250", "1500", "2000", "2500", "3000", "4000", "5000", "6000", "8000", "10000"})
        Me.vis_range_select.Location = New System.Drawing.Point(269, 94)
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
        Me.tgt_range_select.Items.AddRange(New Object() {"0", "125", "250", "500", "750", "1000", "1250", "1500", "2000", "2500", "3000", "4000", "5000", "6000", "8000", "10000"})
        Me.tgt_range_select.Location = New System.Drawing.Point(416, 94)
        Me.tgt_range_select.Name = "tgt_range_select"
        Me.tgt_range_select.Size = New System.Drawing.Size(94, 384)
        Me.tgt_range_select.TabIndex = 68
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.tgt_range_select)
        Me.Panel1.Controls.Add(Me.vis_range_select)
        Me.Panel1.Controls.Add(Me.tgt_range)
        Me.Panel1.Controls.Add(Me.spot)
        Me.Panel1.Controls.Add(Me.fire)
        Me.Panel1.Controls.Add(Me.firesmoke)
        Me.Panel1.Controls.Add(Me.visrange)
        Me.Panel1.Controls.Add(Me.selectedfirer)
        Me.Panel1.Controls.Add(Me.select_cover_firer)
        Me.Panel1.Controls.Add(Me.firercover)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.firerrear)
        Me.Panel1.Controls.Add(Me.firerflank)
        Me.Panel1.Controls.Add(Me.firersecondary)
        Me.Panel1.Controls.Add(Me.firerprimary)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.observing)
        Me.Panel1.Location = New System.Drawing.Point(28, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 606)
        Me.Panel1.TabIndex = 69
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.targets)
        Me.Panel2.Controls.Add(Me.selectedtarget)
        Me.Panel2.Controls.Add(Me.select_cover_target)
        Me.Panel2.Controls.Add(Me.targetcover)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.targetrear)
        Me.Panel2.Controls.Add(Me.targetflank)
        Me.Panel2.Controls.Add(Me.targetsecondary)
        Me.Panel2.Controls.Add(Me.targetprimary)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(620, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(639, 605)
        Me.Panel2.TabIndex = 70
        '
        'combat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.title)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "combat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Firing"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents observing As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents firerprimary As System.Windows.Forms.CheckBox
    Friend WithEvents firersecondary As System.Windows.Forms.CheckBox
    Friend WithEvents firerflank As System.Windows.Forms.CheckBox
    Friend WithEvents firerrear As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents firercover As System.Windows.Forms.Label
    Friend WithEvents select_cover_firer As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents selectedfirer As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents selectedtarget As System.Windows.Forms.Label
    Friend WithEvents targets As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents targetprimary As System.Windows.Forms.CheckBox
    Friend WithEvents targetsecondary As System.Windows.Forms.CheckBox
    Friend WithEvents targetflank As System.Windows.Forms.CheckBox
    Friend WithEvents targetrear As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents targetcover As System.Windows.Forms.Label
    Friend WithEvents select_cover_target As System.Windows.Forms.Button
    Friend WithEvents firesmoke As System.Windows.Forms.Button
    Friend WithEvents fire As System.Windows.Forms.Button
    Friend WithEvents visrange As System.Windows.Forms.Label
    Friend WithEvents tgt_range As System.Windows.Forms.Label
    Friend WithEvents title As System.Windows.Forms.Label
    Protected WithEvents spot As System.Windows.Forms.Button
    Friend WithEvents vis_range_select As System.Windows.Forms.ListBox
    Friend WithEvents tgt_range_select As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
