<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mine_attack
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mine_attack))
        Me.subject = New System.Windows.Forms.Label()
        Me.attempt = New System.Windows.Forms.Label()
        Me.get_result = New System.Windows.Forms.Button()
        Me.engineers = New System.Windows.Forms.Label()
        Me.mine_type = New System.Windows.Forms.Label()
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
        'attempt
        '
        Me.attempt.BackColor = System.Drawing.SystemColors.ControlLight
        Me.attempt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.attempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.attempt.Location = New System.Drawing.Point(95, 164)
        Me.attempt.Name = "attempt"
        Me.attempt.Size = New System.Drawing.Size(300, 33)
        Me.attempt.TabIndex = 13
        Me.attempt.Tag = "2"
        Me.attempt.Text = "Crossing Attempts 0"
        Me.attempt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'get_result
        '
        Me.get_result.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.get_result.Location = New System.Drawing.Point(95, 212)
        Me.get_result.Name = "get_result"
        Me.get_result.Size = New System.Drawing.Size(300, 40)
        Me.get_result.TabIndex = 14
        Me.get_result.Text = "Resolve Crossing Attempt"
        Me.get_result.UseVisualStyleBackColor = True
        '
        'engineers
        '
        Me.engineers.BackColor = System.Drawing.SystemColors.ControlLight
        Me.engineers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.engineers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.engineers.Location = New System.Drawing.Point(95, 116)
        Me.engineers.Name = "engineers"
        Me.engineers.Size = New System.Drawing.Size(300, 33)
        Me.engineers.TabIndex = 38
        Me.engineers.Tag = "-1"
        Me.engineers.Text = "No Support"
        Me.engineers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mine_type
        '
        Me.mine_type.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mine_type.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.mine_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mine_type.Location = New System.Drawing.Point(95, 68)
        Me.mine_type.Name = "mine_type"
        Me.mine_type.Size = New System.Drawing.Size(300, 33)
        Me.mine_type.TabIndex = 39
        Me.mine_type.Tag = "-2"
        Me.mine_type.Text = "Barrier Minefield"
        Me.mine_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mine_attack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(473, 506)
        Me.Controls.Add(Me.mine_type)
        Me.Controls.Add(Me.engineers)
        Me.Controls.Add(Me.get_result)
        Me.Controls.Add(Me.attempt)
        Me.Controls.Add(Me.subject)
        Me.Name = "mine_attack"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minefields"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents subject As System.Windows.Forms.Label
    Friend WithEvents attempt As System.Windows.Forms.Label
    Friend WithEvents get_result As System.Windows.Forms.Button
    Friend WithEvents engineers As System.Windows.Forms.Label
    Friend WithEvents mine_type As System.Windows.Forms.Label
End Class
