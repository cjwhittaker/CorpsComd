<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class generate_subunits
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(generate_subunits))
        Me.orbattitle = New System.Windows.Forms.Label()
        Me.quality = New System.Windows.Forms.ComboBox()
        Me.unittype = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.sub_a = New System.Windows.Forms.Label()
        Me.sub_1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'orbattitle
        '
        Me.orbattitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.orbattitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.orbattitle.Location = New System.Drawing.Point(35, 28)
        Me.orbattitle.Name = "orbattitle"
        Me.orbattitle.Size = New System.Drawing.Size(614, 36)
        Me.orbattitle.TabIndex = 17
        Me.orbattitle.Text = "Label1"
        Me.orbattitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'quality
        '
        Me.quality.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quality.FormattingEnabled = True
        Me.quality.Items.AddRange(New Object() {"9", "8", "7", "6", "5", "4", "3", "2", "1"})
        Me.quality.Location = New System.Drawing.Point(295, 172)
        Me.quality.Name = "quality"
        Me.quality.Size = New System.Drawing.Size(214, 32)
        Me.quality.TabIndex = 21
        '
        'unittype
        '
        Me.unittype.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unittype.FormattingEnabled = True
        Me.unittype.Items.AddRange(New Object() {"Army", "Corps", "Division", "Brigade", "Regiment", "Battalion/Battlegroup", "Bty/Sqn/Coy/Platoon/Troop"})
        Me.unittype.Location = New System.Drawing.Point(294, 122)
        Me.unittype.Name = "unittype"
        Me.unittype.Size = New System.Drawing.Size(214, 32)
        Me.unittype.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(221, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 24)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Quality"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(177, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 24)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Type of Unit"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(181, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(327, 38)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "Generate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(75, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(213, 24)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Sub Unit Identifer Range"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sub_a
        '
        Me.sub_a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sub_a.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sub_a.Location = New System.Drawing.Point(418, 219)
        Me.sub_a.Name = "sub_a"
        Me.sub_a.Size = New System.Drawing.Size(91, 38)
        Me.sub_a.TabIndex = 28
        Me.sub_a.Text = """A"""
        Me.sub_a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sub_1
        '
        Me.sub_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sub_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sub_1.Location = New System.Drawing.Point(295, 219)
        Me.sub_1.Name = "sub_1"
        Me.sub_1.Size = New System.Drawing.Size(91, 38)
        Me.sub_1.TabIndex = 29
        Me.sub_1.Text = """1"""
        Me.sub_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'generate_subunits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 339)
        Me.Controls.Add(Me.sub_1)
        Me.Controls.Add(Me.sub_a)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.quality)
        Me.Controls.Add(Me.unittype)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.orbattitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "generate_subunits"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Unit Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents orbattitle As System.Windows.Forms.Label
    Friend WithEvents quality As System.Windows.Forms.ComboBox
    Friend WithEvents unittype As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sub_a As Label
    Friend WithEvents sub_1 As Label
End Class
