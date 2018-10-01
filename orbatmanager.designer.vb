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
        Me.debusvehicles = New System.Windows.Forms.Button()
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
        Me.selectedunit.SuspendLayout()
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
        Me.orbattitle.Location = New System.Drawing.Point(134, 24)
        Me.orbattitle.Name = "orbattitle"
        Me.orbattitle.Size = New System.Drawing.Size(614, 36)
        Me.orbattitle.TabIndex = 16
        Me.orbattitle.Text = "Label1"
        Me.orbattitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'printorbat
        '
        Me.printorbat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.printorbat.Location = New System.Drawing.Point(489, 590)
        Me.printorbat.Name = "printorbat"
        Me.printorbat.Size = New System.Drawing.Size(309, 45)
        Me.printorbat.TabIndex = 23
        Me.printorbat.Text = "Print Orbat to File"
        Me.printorbat.UseVisualStyleBackColor = True
        '
        'debusvehicles
        '
        Me.debusvehicles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.debusvehicles.Location = New System.Drawing.Point(594, 542)
        Me.debusvehicles.Name = "debusvehicles"
        Me.debusvehicles.Size = New System.Drawing.Size(99, 42)
        Me.debusvehicles.TabIndex = 18
        Me.debusvehicles.Text = "Debus"
        Me.debusvehicles.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 76)
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
        Me.Label1.Location = New System.Drawing.Point(5, 124)
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
        Me.Label4.Location = New System.Drawing.Point(36, 225)
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
        Me.Label5.Location = New System.Drawing.Point(14, 271)
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
        Me.Label2.Location = New System.Drawing.Point(49, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Quality"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'title
        '
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.Location = New System.Drawing.Point(122, 73)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(215, 29)
        Me.title.TabIndex = 12
        '
        'strength
        '
        Me.strength.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.strength.Location = New System.Drawing.Point(123, 222)
        Me.strength.Name = "strength"
        Me.strength.Size = New System.Drawing.Size(215, 29)
        Me.strength.TabIndex = 12
        '
        'equip
        '
        Me.equip.Enabled = False
        Me.equip.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.equip.Location = New System.Drawing.Point(124, 268)
        Me.equip.Name = "equip"
        Me.equip.Size = New System.Drawing.Size(215, 29)
        Me.equip.TabIndex = 12
        '
        'comd
        '
        Me.comd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comd.FormattingEnabled = True
        Me.comd.Items.AddRange(New Object() {"Army", "Corps", "Division", "Brigade", "Regiment", "Battalion/Battlegroup/Combat Team", "Bty/Sqn/Coy/Platoon/Troop"})
        Me.comd.Location = New System.Drawing.Point(122, 121)
        Me.comd.Name = "comd"
        Me.comd.Size = New System.Drawing.Size(214, 32)
        Me.comd.TabIndex = 13
        '
        'quality
        '
        Me.quality.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quality.FormattingEnabled = True
        Me.quality.Items.AddRange(New Object() {"9", "8", "7", "6", "5", "4", "3", "2", "1"})
        Me.quality.Location = New System.Drawing.Point(123, 171)
        Me.quality.Name = "quality"
        Me.quality.Size = New System.Drawing.Size(214, 32)
        Me.quality.TabIndex = 14
        '
        'confirm
        '
        Me.confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirm.Location = New System.Drawing.Point(31, 313)
        Me.confirm.Name = "confirm"
        Me.confirm.Size = New System.Drawing.Size(139, 42)
        Me.confirm.TabIndex = 18
        Me.confirm.Text = "Confirm Edit"
        Me.confirm.UseVisualStyleBackColor = True
        '
        'reject
        '
        Me.reject.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reject.Location = New System.Drawing.Point(198, 313)
        Me.reject.Name = "reject"
        Me.reject.Size = New System.Drawing.Size(139, 42)
        Me.reject.TabIndex = 18
        Me.reject.Text = "Reject Edit"
        Me.reject.UseVisualStyleBackColor = True
        '
        'selectedunit
        '
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
        Me.selectedunit.Size = New System.Drawing.Size(372, 382)
        Me.selectedunit.TabIndex = 15
        Me.selectedunit.TabStop = False
        '
        'purpose
        '
        Me.purpose.BackColor = System.Drawing.Color.Transparent
        Me.purpose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.purpose.Location = New System.Drawing.Point(38, 20)
        Me.purpose.Name = "purpose"
        Me.purpose.Size = New System.Drawing.Size(300, 29)
        Me.purpose.TabIndex = 19
        Me.purpose.Text = "Function"
        Me.purpose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dispmode
        '
        Me.dispmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dispmode.Location = New System.Drawing.Point(489, 494)
        Me.dispmode.Name = "dispmode"
        Me.dispmode.Size = New System.Drawing.Size(99, 42)
        Me.dispmode.TabIndex = 24
        Me.dispmode.Text = "Disp"
        Me.dispmode.UseVisualStyleBackColor = True
        '
        'concmode
        '
        Me.concmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.concmode.Location = New System.Drawing.Point(594, 494)
        Me.concmode.Name = "concmode"
        Me.concmode.Size = New System.Drawing.Size(99, 42)
        Me.concmode.TabIndex = 25
        Me.concmode.Text = "Conc"
        Me.concmode.UseVisualStyleBackColor = True
        '
        'travelmode
        '
        Me.travelmode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.travelmode.Location = New System.Drawing.Point(699, 494)
        Me.travelmode.Name = "travelmode"
        Me.travelmode.Size = New System.Drawing.Size(99, 42)
        Me.travelmode.TabIndex = 26
        Me.travelmode.Text = "Travel"
        Me.travelmode.UseVisualStyleBackColor = True
        '
        'embusvehicles
        '
        Me.embusvehicles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.embusvehicles.Location = New System.Drawing.Point(699, 542)
        Me.embusvehicles.Name = "embusvehicles"
        Me.embusvehicles.Size = New System.Drawing.Size(99, 42)
        Me.embusvehicles.TabIndex = 27
        Me.embusvehicles.Text = "Embus"
        Me.embusvehicles.UseVisualStyleBackColor = True
        '
        'dismountvehicles
        '
        Me.dismountvehicles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dismountvehicles.Location = New System.Drawing.Point(489, 542)
        Me.dismountvehicles.Name = "dismountvehicles"
        Me.dismountvehicles.Size = New System.Drawing.Size(99, 42)
        Me.dismountvehicles.TabIndex = 28
        Me.dismountvehicles.Text = "Dismount"
        Me.dismountvehicles.UseVisualStyleBackColor = True
        '
        'insert_formation
        '
        Me.insert_formation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.insert_formation.Location = New System.Drawing.Point(462, 85)
        Me.insert_formation.Name = "insert_formation"
        Me.insert_formation.Size = New System.Drawing.Size(181, 42)
        Me.insert_formation.TabIndex = 29
        Me.insert_formation.Text = "Insert a new formation"
        Me.insert_formation.UseVisualStyleBackColor = True
        '
        'clone_formation
        '
        Me.clone_formation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clone_formation.Location = New System.Drawing.Point(462, 153)
        Me.clone_formation.Name = "clone_formation"
        Me.clone_formation.Size = New System.Drawing.Size(181, 42)
        Me.clone_formation.TabIndex = 30
        Me.clone_formation.Text = "Clone the formation"
        Me.clone_formation.UseVisualStyleBackColor = True
        '
        'generate_sub_units
        '
        Me.generate_sub_units.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.generate_sub_units.Location = New System.Drawing.Point(462, 223)
        Me.generate_sub_units.Name = "generate_sub_units"
        Me.generate_sub_units.Size = New System.Drawing.Size(181, 42)
        Me.generate_sub_units.TabIndex = 31
        Me.generate_sub_units.Text = "Generate Sub Units"
        Me.generate_sub_units.UseVisualStyleBackColor = True
        '
        'edit_selected_units
        '
        Me.edit_selected_units.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit_selected_units.Location = New System.Drawing.Point(462, 302)
        Me.edit_selected_units.Name = "edit_selected_units"
        Me.edit_selected_units.Size = New System.Drawing.Size(181, 42)
        Me.edit_selected_units.TabIndex = 32
        Me.edit_selected_units.Text = "Edit Selected Units"
        Me.edit_selected_units.UseVisualStyleBackColor = True
        '
        'orbatmanager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 662)
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
        Me.Controls.Add(Me.debusvehicles)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents comdtree As System.Windows.Forms.TreeView
    Friend WithEvents orbattitle As System.Windows.Forms.Label
    Friend WithEvents printorbat As System.Windows.Forms.Button
    Friend WithEvents debusvehicles As System.Windows.Forms.Button
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
End Class
