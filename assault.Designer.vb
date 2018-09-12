<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class assault
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(assault))
        Me.assaulting = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fight = New System.Windows.Forms.Button()
        Me.defending = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.d_arty = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.defenders = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.attacking = New System.Windows.Forms.Panel()
        Me.a_arty = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.supports = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Secondary = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.factors = New System.Windows.Forms.Panel()
        Me.defile = New System.Windows.Forms.Label()
        Me.atgw_spt = New System.Windows.Forms.Label()
        Me.afv_spt = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cover = New System.Windows.Forms.Label()
        Me.defending.SuspendLayout()
        Me.attacking.SuspendLayout()
        Me.factors.SuspendLayout()
        Me.SuspendLayout()
        '
        'assaulting
        '
        Me.assaulting.BackColor = System.Drawing.Color.Transparent
        Me.assaulting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.assaulting.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.assaulting.Location = New System.Drawing.Point(236, 10)
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
        Me.Label6.Location = New System.Drawing.Point(62, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 24)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Assaulting Attacker"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(79, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 24)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Supporting"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(90, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 24)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Defending"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(264, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(236, 35)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Artillery Support"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fight
        '
        Me.fight.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fight.Location = New System.Drawing.Point(526, 590)
        Me.fight.Name = "fight"
        Me.fight.Size = New System.Drawing.Size(268, 49)
        Me.fight.TabIndex = 73
        Me.fight.Text = "Resolve the Assault"
        Me.fight.UseVisualStyleBackColor = True
        '
        'defending
        '
        Me.defending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.defending.Controls.Add(Me.Label4)
        Me.defending.Controls.Add(Me.d_arty)
        Me.defending.Controls.Add(Me.defenders)
        Me.defending.Controls.Add(Me.Label5)
        Me.defending.Controls.Add(Me.Label1)
        Me.defending.Location = New System.Drawing.Point(535, 24)
        Me.defending.Name = "defending"
        Me.defending.Size = New System.Drawing.Size(512, 550)
        Me.defending.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 24)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Defender"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'd_arty
        '
        Me.d_arty.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader8})
        Me.d_arty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d_arty.FullRowSelect = True
        Me.d_arty.GridLines = True
        Me.d_arty.HideSelection = False
        Me.d_arty.Location = New System.Drawing.Point(265, 83)
        Me.d_arty.Name = "d_arty"
        Me.d_arty.Size = New System.Drawing.Size(225, 435)
        Me.d_arty.TabIndex = 87
        Me.d_arty.Tag = ""
        Me.d_arty.UseCompatibleStateImageBehavior = False
        Me.d_arty.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Unit"
        Me.ColumnHeader1.Width = 79
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Str"
        Me.ColumnHeader2.Width = 35
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Equip"
        Me.ColumnHeader8.Width = 100
        '
        'defenders
        '
        Me.defenders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.defenders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.defenders.FullRowSelect = True
        Me.defenders.GridLines = True
        Me.defenders.HideSelection = False
        Me.defenders.Location = New System.Drawing.Point(19, 83)
        Me.defenders.MultiSelect = False
        Me.defenders.Name = "defenders"
        Me.defenders.Size = New System.Drawing.Size(225, 435)
        Me.defenders.TabIndex = 86
        Me.defenders.Tag = ""
        Me.defenders.UseCompatibleStateImageBehavior = False
        Me.defenders.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Unit"
        Me.ColumnHeader9.Width = 81
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Str"
        Me.ColumnHeader10.Width = 35
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Equip"
        Me.ColumnHeader11.Width = 100
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(261, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(236, 35)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Artillery Support"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'attacking
        '
        Me.attacking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.attacking.Controls.Add(Me.a_arty)
        Me.attacking.Controls.Add(Me.supports)
        Me.attacking.Controls.Add(Me.Label2)
        Me.attacking.Controls.Add(Me.Label3)
        Me.attacking.Controls.Add(Me.assaulting)
        Me.attacking.Controls.Add(Me.Label6)
        Me.attacking.Location = New System.Drawing.Point(12, 24)
        Me.attacking.Name = "attacking"
        Me.attacking.Size = New System.Drawing.Size(507, 550)
        Me.attacking.TabIndex = 76
        '
        'a_arty
        '
        Me.a_arty.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader7})
        Me.a_arty.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.a_arty.FullRowSelect = True
        Me.a_arty.GridLines = True
        Me.a_arty.HideSelection = False
        Me.a_arty.Location = New System.Drawing.Point(261, 83)
        Me.a_arty.Name = "a_arty"
        Me.a_arty.Size = New System.Drawing.Size(225, 435)
        Me.a_arty.TabIndex = 83
        Me.a_arty.Tag = ""
        Me.a_arty.UseCompatibleStateImageBehavior = False
        Me.a_arty.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Unit"
        Me.ColumnHeader3.Width = 82
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Str"
        Me.ColumnHeader5.Width = 35
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Equip"
        Me.ColumnHeader7.Width = 100
        '
        'supports
        '
        Me.supports.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.Secondary, Me.ColumnHeader6})
        Me.supports.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supports.FullRowSelect = True
        Me.supports.GridLines = True
        Me.supports.HideSelection = False
        Me.supports.Location = New System.Drawing.Point(16, 83)
        Me.supports.MultiSelect = False
        Me.supports.Name = "supports"
        Me.supports.Size = New System.Drawing.Size(225, 435)
        Me.supports.TabIndex = 82
        Me.supports.Tag = ""
        Me.supports.UseCompatibleStateImageBehavior = False
        Me.supports.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Unit"
        Me.ColumnHeader4.Width = 85
        '
        'Secondary
        '
        Me.Secondary.Text = "Str"
        Me.Secondary.Width = 35
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Equip"
        Me.ColumnHeader6.Width = 100
        '
        'factors
        '
        Me.factors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.factors.Controls.Add(Me.defile)
        Me.factors.Controls.Add(Me.atgw_spt)
        Me.factors.Controls.Add(Me.afv_spt)
        Me.factors.Controls.Add(Me.Label7)
        Me.factors.Controls.Add(Me.Label11)
        Me.factors.Controls.Add(Me.cover)
        Me.factors.Location = New System.Drawing.Point(1063, 24)
        Me.factors.Name = "factors"
        Me.factors.Size = New System.Drawing.Size(206, 550)
        Me.factors.TabIndex = 77
        '
        'defile
        '
        Me.defile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.defile.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.defile.Location = New System.Drawing.Point(28, 74)
        Me.defile.Name = "defile"
        Me.defile.Size = New System.Drawing.Size(158, 34)
        Me.defile.TabIndex = 86
        Me.defile.Tag = "Defending Defile"
        Me.defile.Text = "No Defile"
        Me.defile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'atgw_spt
        '
        Me.atgw_spt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.atgw_spt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.atgw_spt.Location = New System.Drawing.Point(28, 221)
        Me.atgw_spt.Name = "atgw_spt"
        Me.atgw_spt.Size = New System.Drawing.Size(158, 34)
        Me.atgw_spt.TabIndex = 85
        Me.atgw_spt.Tag = "Inf +ATGW <600"
        Me.atgw_spt.Text = "No ATGW Support"
        Me.atgw_spt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'afv_spt
        '
        Me.afv_spt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.afv_spt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.afv_spt.Location = New System.Drawing.Point(28, 175)
        Me.afv_spt.Name = "afv_spt"
        Me.afv_spt.Size = New System.Drawing.Size(158, 34)
        Me.afv_spt.TabIndex = 84
        Me.afv_spt.Tag = "Inf + AFV <300m"
        Me.afv_spt.Text = "No AFV Support"
        Me.afv_spt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(38, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 20)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Defender's Support"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(40, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(132, 20)
        Me.Label11.TabIndex = 82
        Me.Label11.Text = "Defender's Cover"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cover
        '
        Me.cover.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.cover.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cover.Location = New System.Drawing.Point(28, 30)
        Me.cover.Name = "cover"
        Me.cover.Size = New System.Drawing.Size(158, 34)
        Me.cover.TabIndex = 76
        Me.cover.Tag = "None"
        Me.cover.Text = "None"
        Me.cover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'assault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1284, 661)
        Me.Controls.Add(Me.factors)
        Me.Controls.Add(Me.attacking)
        Me.Controls.Add(Me.defending)
        Me.Controls.Add(Me.fight)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "assault"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "assault"
        Me.defending.ResumeLayout(False)
        Me.defending.PerformLayout()
        Me.attacking.ResumeLayout(False)
        Me.attacking.PerformLayout()
        Me.factors.ResumeLayout(False)
        Me.factors.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents assaulting As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fight As System.Windows.Forms.Button
    Friend WithEvents defending As Panel
    Friend WithEvents attacking As Panel
    Friend WithEvents a_arty As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents supports As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Secondary As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Label4 As Label
    Friend WithEvents d_arty As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents defenders As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents Label5 As Label
    Friend WithEvents factors As Panel
    Friend WithEvents cover As Label
    Friend WithEvents atgw_spt As Label
    Friend WithEvents afv_spt As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents defile As Label
End Class
