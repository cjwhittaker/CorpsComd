<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class assault
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(assault))
        Me.a_arty_spt = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.assaulting = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.supporting = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.d_arty_spt = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.defending = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.engr = New System.Windows.Forms.CheckBox()
        Me.defile = New System.Windows.Forms.CheckBox()
        Me.uphill = New System.Windows.Forms.CheckBox()
        Me.afv_spt = New System.Windows.Forms.CheckBox()
        Me.atgw_spt = New System.Windows.Forms.CheckBox()
        Me.select_cover = New System.Windows.Forms.Button()
        Me.cover = New System.Windows.Forms.Label()
        Me.fight = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'a_arty_spt
        '
        Me.a_arty_spt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader5})
        Me.a_arty_spt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.a_arty_spt.FullRowSelect = True
        Me.a_arty_spt.GridLines = True
        Me.a_arty_spt.HideSelection = False
        Me.a_arty_spt.Location = New System.Drawing.Point(311, 83)
        Me.a_arty_spt.Name = "a_arty_spt"
        Me.a_arty_spt.Size = New System.Drawing.Size(236, 473)
        Me.a_arty_spt.TabIndex = 62
        Me.a_arty_spt.UseCompatibleStateImageBehavior = False
        Me.a_arty_spt.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Unit"
        Me.ColumnHeader3.Width = 130
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Equipment"
        Me.ColumnHeader5.Width = 97
        '
        'assaulting
        '
        Me.assaulting.BackColor = System.Drawing.Color.Transparent
        Me.assaulting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.assaulting.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assaulting.Location = New System.Drawing.Point(30, 83)
        Me.assaulting.Name = "assaulting"
        Me.assaulting.Size = New System.Drawing.Size(199, 35)
        Me.assaulting.TabIndex = 64
        Me.assaulting.Text = "Assaulting"
        Me.assaulting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(81, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 24)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Assaulting"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'supporting
        '
        Me.supporting.BackColor = System.Drawing.Color.Transparent
        Me.supporting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.supporting.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supporting.Location = New System.Drawing.Point(30, 155)
        Me.supporting.Name = "supporting"
        Me.supporting.Size = New System.Drawing.Size(199, 35)
        Me.supporting.TabIndex = 66
        Me.supporting.Text = "supporting"
        Me.supporting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 24)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Supporting"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'd_arty_spt
        '
        Me.d_arty_spt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.d_arty_spt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d_arty_spt.FullRowSelect = True
        Me.d_arty_spt.GridLines = True
        Me.d_arty_spt.HideSelection = False
        Me.d_arty_spt.Location = New System.Drawing.Point(971, 83)
        Me.d_arty_spt.Name = "d_arty_spt"
        Me.d_arty_spt.Size = New System.Drawing.Size(236, 473)
        Me.d_arty_spt.TabIndex = 67
        Me.d_arty_spt.UseCompatibleStateImageBehavior = False
        Me.d_arty_spt.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Unit"
        Me.ColumnHeader1.Width = 123
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Equipment"
        Me.ColumnHeader2.Width = 97
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(706, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Defending"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'defending
        '
        Me.defending.BackColor = System.Drawing.Color.Transparent
        Me.defending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.defending.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.defending.Location = New System.Drawing.Point(655, 83)
        Me.defending.Name = "defending"
        Me.defending.Size = New System.Drawing.Size(199, 35)
        Me.defending.TabIndex = 64
        Me.defending.Text = "Defending"
        Me.defending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(311, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(236, 35)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Attackers Artillery Support"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(971, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(236, 35)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Defenders Artillery Support"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'engr
        '
        Me.engr.Appearance = System.Windows.Forms.Appearance.Button
        Me.engr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.engr.Location = New System.Drawing.Point(30, 214)
        Me.engr.Name = "engr"
        Me.engr.Size = New System.Drawing.Size(199, 42)
        Me.engr.TabIndex = 68
        Me.engr.Text = "Engineers Support"
        Me.engr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.engr.UseVisualStyleBackColor = True
        '
        'defile
        '
        Me.defile.Appearance = System.Windows.Forms.Appearance.Button
        Me.defile.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.defile.Location = New System.Drawing.Point(30, 262)
        Me.defile.Name = "defile"
        Me.defile.Size = New System.Drawing.Size(199, 42)
        Me.defile.TabIndex = 69
        Me.defile.Text = "Attacking Defile"
        Me.defile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.defile.UseVisualStyleBackColor = True
        '
        'uphill
        '
        Me.uphill.Appearance = System.Windows.Forms.Appearance.Button
        Me.uphill.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.uphill.Location = New System.Drawing.Point(655, 214)
        Me.uphill.Name = "uphill"
        Me.uphill.Size = New System.Drawing.Size(199, 42)
        Me.uphill.TabIndex = 68
        Me.uphill.Text = "Defending a hilltop"
        Me.uphill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.uphill.UseVisualStyleBackColor = True
        '
        'afv_spt
        '
        Me.afv_spt.Appearance = System.Windows.Forms.Appearance.Button
        Me.afv_spt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.afv_spt.Location = New System.Drawing.Point(655, 262)
        Me.afv_spt.Name = "afv_spt"
        Me.afv_spt.Size = New System.Drawing.Size(199, 42)
        Me.afv_spt.TabIndex = 68
        Me.afv_spt.Text = "Defending AFVs < 300m"
        Me.afv_spt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.afv_spt.UseVisualStyleBackColor = True
        '
        'atgw_spt
        '
        Me.atgw_spt.Appearance = System.Windows.Forms.Appearance.Button
        Me.atgw_spt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atgw_spt.Location = New System.Drawing.Point(655, 310)
        Me.atgw_spt.Name = "atgw_spt"
        Me.atgw_spt.Size = New System.Drawing.Size(199, 42)
        Me.atgw_spt.TabIndex = 70
        Me.atgw_spt.Text = "Defending ATGWs < 600m"
        Me.atgw_spt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.atgw_spt.UseVisualStyleBackColor = True
        '
        'select_cover
        '
        Me.select_cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.select_cover.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.select_cover.Location = New System.Drawing.Point(655, 358)
        Me.select_cover.Name = "select_cover"
        Me.select_cover.Size = New System.Drawing.Size(199, 42)
        Me.select_cover.TabIndex = 71
        Me.select_cover.Text = "Select Defenders Cover"
        Me.select_cover.UseVisualStyleBackColor = True
        '
        'cover
        '
        Me.cover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cover.Location = New System.Drawing.Point(655, 403)
        Me.cover.Name = "cover"
        Me.cover.Size = New System.Drawing.Size(199, 42)
        Me.cover.TabIndex = 72
        Me.cover.Text = "None"
        Me.cover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fight
        '
        Me.fight.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fight.Location = New System.Drawing.Point(468, 581)
        Me.fight.Name = "fight"
        Me.fight.Size = New System.Drawing.Size(268, 63)
        Me.fight.TabIndex = 73
        Me.fight.Text = "Resolve the Assualt"
        Me.fight.UseVisualStyleBackColor = True
        '
        'assault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 662)
        Me.Controls.Add(Me.fight)
        Me.Controls.Add(Me.select_cover)
        Me.Controls.Add(Me.cover)
        Me.Controls.Add(Me.atgw_spt)
        Me.Controls.Add(Me.defile)
        Me.Controls.Add(Me.afv_spt)
        Me.Controls.Add(Me.uphill)
        Me.Controls.Add(Me.engr)
        Me.Controls.Add(Me.d_arty_spt)
        Me.Controls.Add(Me.supporting)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.defending)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.assaulting)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.a_arty_spt)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "assault"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "assault"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents a_arty_spt As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents assaulting As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents supporting As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents d_arty_spt As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents defending As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents engr As System.Windows.Forms.CheckBox
    Friend WithEvents defile As System.Windows.Forms.CheckBox
    Friend WithEvents uphill As System.Windows.Forms.CheckBox
    Friend WithEvents afv_spt As System.Windows.Forms.CheckBox
    Friend WithEvents atgw_spt As System.Windows.Forms.CheckBox
    Friend WithEvents select_cover As System.Windows.Forms.Button
    Friend WithEvents cover As System.Windows.Forms.Label
    Friend WithEvents fight As System.Windows.Forms.Button
End Class
