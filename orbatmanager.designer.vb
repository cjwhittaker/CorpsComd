<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class orbatmanager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(orbatmanager))
        Me.comdtree = New System.Windows.Forms.TreeView()
        Me.orbattitle = New System.Windows.Forms.Label()
        Me.printorbat = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.TextBox()
        Me.strength = New System.Windows.Forms.TextBox()
        Me.equip = New System.Windows.Forms.TextBox()
        Me.comd = New System.Windows.Forms.ComboBox()
        Me.quality = New System.Windows.Forms.ComboBox()
        Me.confirm = New System.Windows.Forms.Button()
        Me.reject = New System.Windows.Forms.Button()
        Me.selectedunit = New System.Windows.Forms.GroupBox()
        Me.purpose = New System.Windows.Forms.Label()
        Me.dispmode = New System.Windows.Forms.Button()
        Me.concmode = New System.Windows.Forms.Button()
        Me.travelmode = New System.Windows.Forms.Button()
        Me.embusvehicles = New System.Windows.Forms.Button()
        Me.dismountvehicles = New System.Windows.Forms.Button()
        Me.insert_formation = New System.Windows.Forms.Button()
        Me.clone_formation = New System.Windows.Forms.Button()
        Me.generate_sub_units = New System.Windows.Forms.Button()
        Me.edit_selected_units = New System.Windows.Forms.Button()
        Me.select_unit_template = New System.Windows.Forms.Panel()
        Me.reject_sub = New System.Windows.Forms.Button()
        Me.sub_1 = New System.Windows.Forms.Label()
        Me.sub_a = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.generate = New System.Windows.Forms.Button()
        Me.sub_unit_quality = New System.Windows.Forms.ComboBox()
        Me.unittype = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.delete_unit = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.arty_rating = New System.Windows.Forms.TextBox()
        Me.selectedunit.SuspendLayout()
        Me.select_unit_template.SuspendLayout()
        Me.SuspendLayout()
        '
        'comdtree
        '
        Me.comdtree.AllowDrop = True
        Me.comdtree.BackColor = System.Drawing.Color.White
        Me.comdtree.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comdtree.HideSelection = False
        Me.comdtree.Location = New System.Drawing.Point(45, 85)
        Me.comdtree.Name = "comdtree"
        Me.comdtree.ShowNodeToolTips = True
        Me.comdtree.ShowPlusMinus = False
        Me.comdtree.Size = New System.Drawing.Size(369, 553)
        Me.comdtree.TabIndex = 14
        '
        'orbattitle
        '
        Me.orbattitle.BackColor = System.Drawing.Color.Transparent
        Me.orbattitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.orbattitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orbattitle.ForeColor = System.Drawing.Color.White
        Me.orbattitle.Location = New System.Drawing.Point(337, 25)
        Me.orbattitle.Name = "orbattitle"
        Me.orbattitle.Size = New System.Drawing.Size(614, 36)
        Me.orbattitle.TabIndex = 16
        Me.orbattitle.Text = "Label1"
        Me.orbattitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'printorbat
        '
        Me.printorbat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.printorbat.Location = New System.Drawing.Point(445, 593)
        Me.printorbat.Name = "printorbat"
        Me.printorbat.Size = New System.Drawing.Size(181, 45)
        Me.printorbat.TabIndex = 23
        Me.printorbat.Text = "Print Orbat to File"
        Me.printorbat.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 24)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Unit Title"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Comd Level"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(35, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Strength"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 24)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Equipment"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Quality"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'title
        '
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(122, 45)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(293, 29)
        Me.title.TabIndex = 12
        '
        'strength
        '
        Me.strength.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.strength.Location = New System.Drawing.Point(122, 156)
        Me.strength.Name = "strength"
        Me.strength.Size = New System.Drawing.Size(293, 29)
        Me.strength.TabIndex = 12
        '
        'equip
        '
        Me.equip.Enabled = False
        Me.equip.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.equip.Location = New System.Drawing.Point(122, 191)
        Me.equip.Name = "equip"
        Me.equip.Size = New System.Drawing.Size(293, 29)
        Me.equip.TabIndex = 12
        '
        'comd
        '
        Me.comd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comd.FormattingEnabled = True
        Me.comd.Items.AddRange(New Object() {"Army", "Corps", "Division", "Brigade", "Regiment", "Battalion/Battlegroup/Combat Team", "Bty/Sqn/Coy/Platoon/Troop"})
        Me.comd.Location = New System.Drawing.Point(122, 80)
        Me.comd.Name = "comd"
        Me.comd.Size = New System.Drawing.Size(167, 32)
        Me.comd.TabIndex = 13
        '
        'quality
        '
        Me.quality.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quality.FormattingEnabled = True
        Me.quality.Items.AddRange(New Object() {"9", "8", "7", "6", "5", "4", "3", "2", "1"})
        Me.quality.Location = New System.Drawing.Point(122, 118)
        Me.quality.Name = "quality"
        Me.quality.Size = New System.Drawing.Size(293, 32)
        Me.quality.TabIndex = 14
        '
        'confirm
        '
        Me.confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirm.Location = New System.Drawing.Point(83, 235)
        Me.confirm.Name = "confirm"
        Me.confirm.Size = New System.Drawing.Size(139, 42)
        Me.confirm.TabIndex = 18
        Me.confirm.Text = "Confirm Edit"
        Me.confirm.UseVisualStyleBackColor = True
        '
        'reject
        '
        Me.reject.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reject.Location = New System.Drawing.Point(242, 235)
        Me.reject.Name = "reject"
        Me.reject.Size = New System.Drawing.Size(139, 42)
        Me.reject.TabIndex = 18
        Me.reject.Text = "Reject Edit"
        Me.reject.UseVisualStyleBackColor = True
        '
        'selectedunit
        '
        Me.selectedunit.Controls.Add(Me.Label9)
        Me.selectedunit.Controls.Add(Me.purpose)
        Me.selectedunit.Controls.Add(Me.reject)
        Me.selectedunit.Controls.Add(Me.confirm)
        Me.selectedunit.Controls.Add(Me.quality)
        Me.selectedunit.Controls.Add(Me.comd)
        Me.selectedunit.Controls.Add(Me.equip)
        Me.selectedunit.Controls.Add(Me.strength)
        Me.selectedunit.Controls.Add(Me.title)
        Me.selectedunit.Controls.Add(Me.Label2)
        Me.selectedunit.Controls.Add(Me.Label5)
        Me.selectedunit.Controls.Add(Me.Label4)
        Me.selectedunit.Controls.Add(Me.Label1)
        Me.selectedunit.Controls.Add(Me.Label3)
        Me.selectedunit.Enabled = False
        Me.selectedunit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.selectedunit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.selectedunit.Location = New System.Drawing.Point(763, 85)
        Me.selectedunit.Name = "selectedunit"
        Me.selectedunit.Size = New System.Drawing.Size(459, 292)
        Me.selectedunit.TabIndex = 15
        Me.selectedunit.TabStop = False
        '
        'purpose
        '
        Me.purpose.BackColor = System.Drawing.Color.Transparent
        Me.purpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.purpose.Location = New System.Drawing.Point(87, 13)
        Me.purpose.Name = "purpose"
        Me.purpose.Size = New System.Drawing.Size(300, 29)
        Me.purpose.TabIndex = 19
        Me.purpose.Text = "Function"
        Me.purpose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dispmode
        '
        Me.dispmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dispmode.Location = New System.Drawing.Point(445, 343)
        Me.dispmode.Name = "dispmode"
        Me.dispmode.Size = New System.Drawing.Size(181, 42)
        Me.dispmode.TabIndex = 24
        Me.dispmode.Text = "Disperse all Units"
        Me.dispmode.UseVisualStyleBackColor = True
        '
        'concmode
        '
        Me.concmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.concmode.Location = New System.Drawing.Point(445, 393)
        Me.concmode.Name = "concmode"
        Me.concmode.Size = New System.Drawing.Size(181, 42)
        Me.concmode.TabIndex = 25
        Me.concmode.Text = "Concentrate all Units"
        Me.concmode.UseVisualStyleBackColor = True
        '
        'travelmode
        '
        Me.travelmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.travelmode.Location = New System.Drawing.Point(445, 443)
        Me.travelmode.Name = "travelmode"
        Me.travelmode.Size = New System.Drawing.Size(181, 42)
        Me.travelmode.TabIndex = 26
        Me.travelmode.Text = "Travel mode all Units"
        Me.travelmode.UseVisualStyleBackColor = True
        '
        'embusvehicles
        '
        Me.embusvehicles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.embusvehicles.Location = New System.Drawing.Point(445, 543)
        Me.embusvehicles.Name = "embusvehicles"
        Me.embusvehicles.Size = New System.Drawing.Size(181, 42)
        Me.embusvehicles.TabIndex = 27
        Me.embusvehicles.Text = "Embus Passengers"
        Me.embusvehicles.UseVisualStyleBackColor = True
        '
        'dismountvehicles
        '
        Me.dismountvehicles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dismountvehicles.Location = New System.Drawing.Point(445, 493)
        Me.dismountvehicles.Name = "dismountvehicles"
        Me.dismountvehicles.Size = New System.Drawing.Size(181, 42)
        Me.dismountvehicles.TabIndex = 28
        Me.dismountvehicles.Text = "Dismount Passengers"
        Me.dismountvehicles.UseVisualStyleBackColor = True
        '
        'insert_formation
        '
        Me.insert_formation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.insert_formation.Location = New System.Drawing.Point(445, 93)
        Me.insert_formation.Name = "insert_formation"
        Me.insert_formation.Size = New System.Drawing.Size(181, 42)
        Me.insert_formation.TabIndex = 29
        Me.insert_formation.Text = "Insert a new formation"
        Me.insert_formation.UseVisualStyleBackColor = True
        '
        'clone_formation
        '
        Me.clone_formation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clone_formation.Location = New System.Drawing.Point(445, 143)
        Me.clone_formation.Name = "clone_formation"
        Me.clone_formation.Size = New System.Drawing.Size(181, 42)
        Me.clone_formation.TabIndex = 30
        Me.clone_formation.Text = "Clone the formation"
        Me.clone_formation.UseVisualStyleBackColor = True
        '
        'generate_sub_units
        '
        Me.generate_sub_units.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generate_sub_units.Location = New System.Drawing.Point(445, 193)
        Me.generate_sub_units.Name = "generate_sub_units"
        Me.generate_sub_units.Size = New System.Drawing.Size(181, 42)
        Me.generate_sub_units.TabIndex = 31
        Me.generate_sub_units.Text = "Generate Sub Units"
        Me.generate_sub_units.UseVisualStyleBackColor = True
        '
        'edit_selected_units
        '
        Me.edit_selected_units.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit_selected_units.Location = New System.Drawing.Point(445, 243)
        Me.edit_selected_units.Name = "edit_selected_units"
        Me.edit_selected_units.Size = New System.Drawing.Size(181, 42)
        Me.edit_selected_units.TabIndex = 32
        Me.edit_selected_units.Text = "Edit Selected Units"
        Me.edit_selected_units.UseVisualStyleBackColor = True
        '
        'select_unit_template
        '
        Me.select_unit_template.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.select_unit_template.Controls.Add(Me.reject_sub)
        Me.select_unit_template.Controls.Add(Me.sub_1)
        Me.select_unit_template.Controls.Add(Me.sub_a)
        Me.select_unit_template.Controls.Add(Me.Label6)
        Me.select_unit_template.Controls.Add(Me.generate)
        Me.select_unit_template.Controls.Add(Me.sub_unit_quality)
        Me.select_unit_template.Controls.Add(Me.unittype)
        Me.select_unit_template.Controls.Add(Me.Label7)
        Me.select_unit_template.Controls.Add(Me.Label8)
        Me.select_unit_template.Enabled = False
        Me.select_unit_template.Location = New System.Drawing.Point(762, 408)
        Me.select_unit_template.Name = "select_unit_template"
        Me.select_unit_template.Size = New System.Drawing.Size(460, 230)
        Me.select_unit_template.TabIndex = 33
        '
        'reject_sub
        '
        Me.reject_sub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reject_sub.Location = New System.Drawing.Point(241, 158)
        Me.reject_sub.Name = "reject_sub"
        Me.reject_sub.Size = New System.Drawing.Size(139, 42)
        Me.reject_sub.TabIndex = 38
        Me.reject_sub.Text = "Reject Edit"
        Me.reject_sub.UseVisualStyleBackColor = True
        '
        'sub_1
        '
        Me.sub_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sub_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sub_1.Location = New System.Drawing.Point(279, 106)
        Me.sub_1.Name = "sub_1"
        Me.sub_1.Size = New System.Drawing.Size(47, 38)
        Me.sub_1.TabIndex = 37
        Me.sub_1.Text = """1"""
        Me.sub_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sub_a
        '
        Me.sub_a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sub_a.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sub_a.Location = New System.Drawing.Point(341, 106)
        Me.sub_a.Name = "sub_a"
        Me.sub_a.Size = New System.Drawing.Size(45, 38)
        Me.sub_a.TabIndex = 36
        Me.sub_a.Text = """A"""
        Me.sub_a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(59, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(213, 24)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Sub Unit Identifer Range"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'generate
        '
        Me.generate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generate.Location = New System.Drawing.Point(82, 158)
        Me.generate.Name = "generate"
        Me.generate.Size = New System.Drawing.Size(139, 42)
        Me.generate.TabIndex = 34
        Me.generate.Text = "Generate"
        Me.generate.UseVisualStyleBackColor = True
        '
        'sub_unit_quality
        '
        Me.sub_unit_quality.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sub_unit_quality.FormattingEnabled = True
        Me.sub_unit_quality.Items.AddRange(New Object() {"9", "8", "7", "6", "5", "4", "3", "2", "1"})
        Me.sub_unit_quality.Location = New System.Drawing.Point(121, 63)
        Me.sub_unit_quality.Name = "sub_unit_quality"
        Me.sub_unit_quality.Size = New System.Drawing.Size(293, 32)
        Me.sub_unit_quality.TabIndex = 33
        '
        'unittype
        '
        Me.unittype.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unittype.FormattingEnabled = True
        Me.unittype.Items.AddRange(New Object() {"Army", "Corps", "Division", "Brigade", "Regiment", "Battalion/Battlegroup", "Bty/Sqn/Coy/Platoon/Troop"})
        Me.unittype.Location = New System.Drawing.Point(121, 20)
        Me.unittype.Name = "unittype"
        Me.unittype.Size = New System.Drawing.Size(293, 32)
        Me.unittype.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(47, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 24)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Quality"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 24)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Type of Unit"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'delete_unit
        '
        Me.delete_unit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delete_unit.Location = New System.Drawing.Point(445, 293)
        Me.delete_unit.Name = "delete_unit"
        Me.delete_unit.Size = New System.Drawing.Size(181, 42)
        Me.delete_unit.TabIndex = 34
        Me.delete_unit.Text = "Delete Selected Unit"
        Me.delete_unit.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(313, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 24)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "AR"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'arty_rating
        '
        Me.arty_rating.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.arty_rating.Location = New System.Drawing.Point(1118, 165)
        Me.arty_rating.Name = "arty_rating"
        Me.arty_rating.Size = New System.Drawing.Size(60, 29)
        Me.arty_rating.TabIndex = 21
        '
        'orbatmanager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.arty_rating)
        Me.Controls.Add(Me.delete_unit)
        Me.Controls.Add(Me.select_unit_template)
        Me.Controls.Add(Me.edit_selected_units)
        Me.Controls.Add(Me.generate_sub_units)
        Me.Controls.Add(Me.clone_formation)
        Me.Controls.Add(Me.insert_formation)
        Me.Controls.Add(Me.dismountvehicles)
        Me.Controls.Add(Me.embusvehicles)
        Me.Controls.Add(Me.travelmode)
        Me.Controls.Add(Me.concmode)
        Me.Controls.Add(Me.dispmode)
        Me.Controls.Add(Me.printorbat)
        Me.Controls.Add(Me.orbattitle)
        Me.Controls.Add(Me.comdtree)
        Me.Controls.Add(Me.selectedunit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "orbatmanager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orbat Manager"
        Me.selectedunit.ResumeLayout(False)
        Me.selectedunit.PerformLayout()
        Me.select_unit_template.ResumeLayout(False)
        Me.select_unit_template.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comdtree As System.Windows.Forms.TreeView
    Friend WithEvents orbattitle As System.Windows.Forms.Label
    Friend WithEvents printorbat As System.Windows.Forms.Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents title As TextBox
    Friend WithEvents strength As TextBox
    Friend WithEvents equip As TextBox
    Friend WithEvents comd As ComboBox
    Friend WithEvents quality As ComboBox
    Friend WithEvents confirm As Button
    Friend WithEvents reject As Button
    Friend WithEvents selectedunit As GroupBox
    Friend WithEvents purpose As Label
    Friend WithEvents dispmode As Button
    Friend WithEvents concmode As Button
    Friend WithEvents travelmode As Button
    Friend WithEvents embusvehicles As Button
    Friend WithEvents dismountvehicles As Button
    Friend WithEvents insert_formation As Button
    Friend WithEvents clone_formation As Button
    Friend WithEvents generate_sub_units As Button
    Friend WithEvents edit_selected_units As Button
    Friend WithEvents select_unit_template As Panel
    Friend WithEvents reject_sub As Button
    Friend WithEvents sub_1 As Label
    Friend WithEvents sub_a As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents generate As Button
    Friend WithEvents sub_unit_quality As ComboBox
    Friend WithEvents unittype As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents delete_unit As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents arty_rating As TextBox
End Class
