﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.loadvehicles = New System.Windows.Forms.Button()
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
        Me.selectedunit.SuspendLayout()
        Me.SuspendLayout()
        '
        'comdtree
        '
        Me.comdtree.AllowDrop = True
        Me.comdtree.BackColor = System.Drawing.Color.White
        Me.comdtree.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comdtree.HideSelection = False
        Me.comdtree.Location = New System.Drawing.Point(44, 104)
        Me.comdtree.Name = "comdtree"
        Me.comdtree.ShowPlusMinus = False
        Me.comdtree.Size = New System.Drawing.Size(347, 524)
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
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(545, 569)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(203, 45)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Print Orbat to File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'loadvehicles
        '
        Me.loadvehicles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loadvehicles.Location = New System.Drawing.Point(545, 521)
        Me.loadvehicles.Name = "loadvehicles"
        Me.loadvehicles.Size = New System.Drawing.Size(203, 42)
        Me.loadvehicles.TabIndex = 18
        Me.loadvehicles.Text = "Dismount All Passengers"
        Me.loadvehicles.UseVisualStyleBackColor = True
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
        Me.selectedunit.Location = New System.Drawing.Point(458, 104)
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
        'orbatmanager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(884, 662)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.loadvehicles)
        Me.Controls.Add(Me.orbattitle)
        Me.Controls.Add(Me.comdtree)
        Me.Controls.Add(Me.selectedunit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "orbatmanager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnn"
        Me.selectedunit.ResumeLayout(False)
        Me.selectedunit.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents comdtree As System.Windows.Forms.TreeView
    Friend WithEvents orbattitle As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents loadvehicles As System.Windows.Forms.Button
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
End Class
