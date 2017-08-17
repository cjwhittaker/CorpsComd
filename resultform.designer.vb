<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class resultform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(resultform))
        Me.ok_button = New System.Windows.Forms.Button()
        Me.result = New System.Windows.Forms.Label()
        Me.yb = New System.Windows.Forms.Button()
        Me.nb = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ok_button
        '
        Me.ok_button.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ok_button.Location = New System.Drawing.Point(328, 354)
        Me.ok_button.Name = "ok_button"
        Me.ok_button.Size = New System.Drawing.Size(94, 47)
        Me.ok_button.TabIndex = 0
        Me.ok_button.Text = "[O]K"
        Me.ok_button.UseVisualStyleBackColor = True
        '
        'result
        '
        Me.result.BackColor = System.Drawing.Color.Transparent
        Me.result.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.result.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.result.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.result.Location = New System.Drawing.Point(12, 9)
        Me.result.Name = "result"
        Me.result.Size = New System.Drawing.Size(410, 332)
        Me.result.TabIndex = 1
        Me.result.Text = "Label1"
        Me.result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'yb
        '
        Me.yb.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.yb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.yb.Location = New System.Drawing.Point(116, 354)
        Me.yb.Name = "yb"
        Me.yb.Size = New System.Drawing.Size(94, 47)
        Me.yb.TabIndex = 2
        Me.yb.Text = "[Y]es"
        Me.yb.UseVisualStyleBackColor = True
        Me.yb.Visible = False
        '
        'nb
        '
        Me.nb.DialogResult = System.Windows.Forms.DialogResult.No
        Me.nb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nb.Location = New System.Drawing.Point(222, 353)
        Me.nb.Name = "nb"
        Me.nb.Size = New System.Drawing.Size(94, 47)
        Me.nb.TabIndex = 3
        Me.nb.Text = "[N]o"
        Me.nb.UseVisualStyleBackColor = True
        Me.nb.Visible = False
        '
        'resultform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(434, 411)
        Me.Controls.Add(Me.nb)
        Me.Controls.Add(Me.yb)
        Me.Controls.Add(Me.result)
        Me.Controls.Add(Me.ok_button)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(450, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 450)
        Me.Name = "resultform"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ok_button As System.Windows.Forms.Button
    Friend WithEvents result As System.Windows.Forms.Label
    Friend WithEvents yb As System.Windows.Forms.Button
    Friend WithEvents nb As System.Windows.Forms.Button




End Class
