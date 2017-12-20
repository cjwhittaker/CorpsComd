<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class morale_test
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(morale_test))
        Me.subject = New System.Windows.Forms.Label()
        Me.chemical = New System.Windows.Forms.Label()
        Me.get_result = New System.Windows.Forms.Button()
        Me.ok_button = New System.Windows.Forms.Button()
        Me.friends_in_sight = New System.Windows.Forms.Label()
        Me.hq_in_sight = New System.Windows.Forms.Label()
        Me.test_result = New System.Windows.Forms.Label()
        Me.nuclear = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'subject
        '
        Me.subject.BackColor = System.Drawing.Color.White
        Me.subject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.subject.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subject.Location = New System.Drawing.Point(95, 20)
        Me.subject.Name = "subject"
        Me.subject.Size = New System.Drawing.Size(300, 33)
        Me.subject.TabIndex = 11
        Me.subject.Tag = "0"
        Me.subject.Text = "Tester"
        Me.subject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chemical
        '
        Me.chemical.BackColor = System.Drawing.SystemColors.ControlLight
        Me.chemical.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.chemical.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chemical.Location = New System.Drawing.Point(95, 161)
        Me.chemical.Name = "chemical"
        Me.chemical.Size = New System.Drawing.Size(300, 33)
        Me.chemical.TabIndex = 13
        Me.chemical.Tag = "2"
        Me.chemical.Text = "Chemical Attack"
        Me.chemical.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'get_result
        '
        Me.get_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.get_result.Location = New System.Drawing.Point(95, 251)
        Me.get_result.Name = "get_result"
        Me.get_result.Size = New System.Drawing.Size(300, 40)
        Me.get_result.TabIndex = 14
        Me.get_result.Text = "Test Morale"
        Me.get_result.UseVisualStyleBackColor = True
        '
        'ok_button
        '
        Me.ok_button.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ok_button.Location = New System.Drawing.Point(95, 439)
        Me.ok_button.Name = "ok_button"
        Me.ok_button.Size = New System.Drawing.Size(300, 40)
        Me.ok_button.TabIndex = 14
        Me.ok_button.Text = "OK"
        Me.ok_button.UseVisualStyleBackColor = True
        Me.ok_button.Visible = False
        '
        'friends_in_sight
        '
        Me.friends_in_sight.BackColor = System.Drawing.SystemColors.ControlLight
        Me.friends_in_sight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.friends_in_sight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.friends_in_sight.Location = New System.Drawing.Point(95, 116)
        Me.friends_in_sight.Name = "friends_in_sight"
        Me.friends_in_sight.Size = New System.Drawing.Size(300, 33)
        Me.friends_in_sight.TabIndex = 38
        Me.friends_in_sight.Tag = "-1"
        Me.friends_in_sight.Text = "Undisrupted friends within 600m"
        Me.friends_in_sight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'hq_in_sight
        '
        Me.hq_in_sight.BackColor = System.Drawing.SystemColors.ControlLight
        Me.hq_in_sight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.hq_in_sight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hq_in_sight.Location = New System.Drawing.Point(95, 71)
        Me.hq_in_sight.Name = "hq_in_sight"
        Me.hq_in_sight.Size = New System.Drawing.Size(300, 33)
        Me.hq_in_sight.TabIndex = 39
        Me.hq_in_sight.Tag = "-2"
        Me.hq_in_sight.Text = "Undisrupted HQ within 600m"
        Me.hq_in_sight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'test_result
        '
        Me.test_result.BackColor = System.Drawing.Color.White
        Me.test_result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.test_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.test_result.Location = New System.Drawing.Point(95, 304)
        Me.test_result.Name = "test_result"
        Me.test_result.Size = New System.Drawing.Size(300, 122)
        Me.test_result.TabIndex = 41
        Me.test_result.Tag = ""
        Me.test_result.Text = "result"
        Me.test_result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.test_result.Visible = False
        '
        'nuclear
        '
        Me.nuclear.BackColor = System.Drawing.SystemColors.ControlLight
        Me.nuclear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.nuclear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nuclear.Location = New System.Drawing.Point(95, 203)
        Me.nuclear.Name = "nuclear"
        Me.nuclear.Size = New System.Drawing.Size(300, 33)
        Me.nuclear.TabIndex = 40
        Me.nuclear.Tag = "3"
        Me.nuclear.Text = "Nuclear Attack"
        Me.nuclear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'morale_test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(473, 506)
        Me.Controls.Add(Me.test_result)
        Me.Controls.Add(Me.nuclear)
        Me.Controls.Add(Me.hq_in_sight)
        Me.Controls.Add(Me.friends_in_sight)
        Me.Controls.Add(Me.ok_button)
        Me.Controls.Add(Me.get_result)
        Me.Controls.Add(Me.chemical)
        Me.Controls.Add(Me.subject)
        Me.Name = "morale_test"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Morale Test"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents subject As System.Windows.Forms.Label
    Friend WithEvents chemical As System.Windows.Forms.Label
    Friend WithEvents get_result As System.Windows.Forms.Button
    Friend WithEvents ok_button As System.Windows.Forms.Button
    Friend WithEvents friends_in_sight As System.Windows.Forms.Label
    Friend WithEvents hq_in_sight As System.Windows.Forms.Label
    Friend WithEvents test_result As System.Windows.Forms.Label
    Friend WithEvents nuclear As System.Windows.Forms.Label
End Class
