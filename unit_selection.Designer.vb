<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class unit_selection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(unit_selection))
        Me.title = New System.Windows.Forms.Label()
        Me.units = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.takeaction = New System.Windows.Forms.Button()
        Me.comdtree = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.BackColor = System.Drawing.Color.Transparent
        Me.title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.title.ForeColor = System.Drawing.Color.White
        Me.title.Location = New System.Drawing.Point(34, 25)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(614, 57)
        Me.title.TabIndex = 18
        Me.title.Text = "Select any Battlegroups you wish to recover from being demoralised"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'units
        '
        Me.units.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader3})
        Me.units.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.units.FullRowSelect = True
        Me.units.GridLines = True
        Me.units.Location = New System.Drawing.Point(96, 114)
        Me.units.MultiSelect = False
        Me.units.Name = "units"
        Me.units.Size = New System.Drawing.Size(525, 405)
        Me.units.TabIndex = 41
        Me.units.UseCompatibleStateImageBehavior = False
        Me.units.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Unit"
        Me.ColumnHeader2.Width = 186
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Comd Pts"
        Me.ColumnHeader1.Width = 96
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 235
        '
        'takeaction
        '
        Me.takeaction.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.takeaction.Location = New System.Drawing.Point(160, 550)
        Me.takeaction.Name = "takeaction"
        Me.takeaction.Size = New System.Drawing.Size(359, 65)
        Me.takeaction.TabIndex = 42
        Me.takeaction.Text = "Recover from being demoralised"
        Me.takeaction.UseVisualStyleBackColor = True
        '
        'comdtree
        '
        Me.comdtree.AllowDrop = True
        Me.comdtree.BackColor = System.Drawing.Color.White
        Me.comdtree.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comdtree.HideSelection = False
        Me.comdtree.Location = New System.Drawing.Point(96, 114)
        Me.comdtree.Name = "comdtree"
        Me.comdtree.ShowPlusMinus = False
        Me.comdtree.Size = New System.Drawing.Size(525, 405)
        Me.comdtree.TabIndex = 71
        Me.comdtree.Visible = False
        '
        'unit_selection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(684, 662)
        Me.Controls.Add(Me.takeaction)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.comdtree)
        Me.Controls.Add(Me.units)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "unit_selection"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demoralisation Recovery"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents title As System.Windows.Forms.Label
    Friend WithEvents units As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents takeaction As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents comdtree As TreeView
End Class
