<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class event_manager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(event_manager))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.event_time = New System.Windows.Forms.Label()
        Me.event_time_inc = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.side_options = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.detail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dice_type = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dec_dice = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dice_score = New System.Windows.Forms.TextBox()
        Me.new_event = New System.Windows.Forms.Button()
        Me.save_event = New System.Windows.Forms.Button()
        Me.delete_event = New System.Windows.Forms.Button()
        Me.discard_event = New System.Windows.Forms.Button()
        Me.edit_event = New System.Windows.Forms.Button()
        Me.event_table = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.event_time_inc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(138, 410)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 23)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Event Time"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'event_time
        '
        Me.event_time.BackColor = System.Drawing.Color.White
        Me.event_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.event_time.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.event_time.Location = New System.Drawing.Point(242, 407)
        Me.event_time.MinimumSize = New System.Drawing.Size(125, 30)
        Me.event_time.Name = "event_time"
        Me.event_time.Size = New System.Drawing.Size(178, 30)
        Me.event_time.TabIndex = 4
        Me.event_time.Text = "0"
        Me.event_time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'event_time_inc
        '
        Me.event_time_inc.BackColor = System.Drawing.SystemColors.Control
        Me.event_time_inc.Location = New System.Drawing.Point(423, 400)
        Me.event_time_inc.Maximum = 23
        Me.event_time_inc.Name = "event_time_inc"
        Me.event_time_inc.Size = New System.Drawing.Size(249, 45)
        Me.event_time_inc.TabIndex = 3
        Me.event_time_inc.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(151, 273)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 23)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Event For"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'side_options
        '
        Me.side_options.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.side_options.FormattingEnabled = True
        Me.side_options.Location = New System.Drawing.Point(242, 273)
        Me.side_options.Name = "side_options"
        Me.side_options.Size = New System.Drawing.Size(335, 31)
        Me.side_options.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(181, 320)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 23)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Event"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'detail
        '
        Me.detail.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detail.Location = New System.Drawing.Point(242, 320)
        Me.detail.Multiline = True
        Me.detail.Name = "detail"
        Me.detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.detail.Size = New System.Drawing.Size(417, 74)
        Me.detail.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-103, 456)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(339, 28)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Dice Type for Event to occur"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dice_type
        '
        Me.dice_type.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dice_type.FormattingEnabled = True
        Me.dice_type.Items.AddRange(New Object() {"None", "D6", "D10"})
        Me.dice_type.Location = New System.Drawing.Point(242, 456)
        Me.dice_type.Name = "dice_type"
        Me.dice_type.Size = New System.Drawing.Size(178, 31)
        Me.dice_type.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-58, 551)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(294, 28)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Decrement dice per turn"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dec_dice
        '
        Me.dec_dice.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dec_dice.FormattingEnabled = True
        Me.dec_dice.Items.AddRange(New Object() {"Yes", "No"})
        Me.dec_dice.Location = New System.Drawing.Point(242, 551)
        Me.dec_dice.Name = "dec_dice"
        Me.dec_dice.Size = New System.Drawing.Size(178, 31)
        Me.dec_dice.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-103, 502)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(339, 32)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Dice Score for Event to occur"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dice_score
        '
        Me.dice_score.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dice_score.Location = New System.Drawing.Point(242, 504)
        Me.dice_score.Multiline = True
        Me.dice_score.Name = "dice_score"
        Me.dice_score.Size = New System.Drawing.Size(178, 32)
        Me.dice_score.TabIndex = 18
        '
        'new_event
        '
        Me.new_event.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.new_event.Location = New System.Drawing.Point(78, 215)
        Me.new_event.Name = "new_event"
        Me.new_event.Size = New System.Drawing.Size(158, 40)
        Me.new_event.TabIndex = 19
        Me.new_event.Text = "Add New Event"
        Me.new_event.UseVisualStyleBackColor = True
        '
        'save_event
        '
        Me.save_event.Enabled = False
        Me.save_event.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.save_event.Location = New System.Drawing.Point(173, 610)
        Me.save_event.Name = "save_event"
        Me.save_event.Size = New System.Drawing.Size(158, 40)
        Me.save_event.TabIndex = 20
        Me.save_event.Text = "Save Event"
        Me.save_event.UseVisualStyleBackColor = True
        '
        'delete_event
        '
        Me.delete_event.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delete_event.Location = New System.Drawing.Point(446, 215)
        Me.delete_event.Name = "delete_event"
        Me.delete_event.Size = New System.Drawing.Size(158, 40)
        Me.delete_event.TabIndex = 21
        Me.delete_event.Text = "Delete Event"
        Me.delete_event.UseVisualStyleBackColor = True
        '
        'discard_event
        '
        Me.discard_event.Enabled = False
        Me.discard_event.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.discard_event.Location = New System.Drawing.Point(373, 610)
        Me.discard_event.Name = "discard_event"
        Me.discard_event.Size = New System.Drawing.Size(158, 40)
        Me.discard_event.TabIndex = 23
        Me.discard_event.Text = "Discard Edit"
        Me.discard_event.UseVisualStyleBackColor = True
        '
        'edit_event
        '
        Me.edit_event.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.edit_event.Location = New System.Drawing.Point(262, 215)
        Me.edit_event.Name = "edit_event"
        Me.edit_event.Size = New System.Drawing.Size(158, 40)
        Me.edit_event.TabIndex = 19
        Me.edit_event.Text = "Edit Event"
        Me.edit_event.UseVisualStyleBackColor = True
        '
        'event_table
        '
        Me.event_table.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.event_table.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.event_table.FullRowSelect = True
        Me.event_table.GridLines = True
        Me.event_table.Location = New System.Drawing.Point(28, 22)
        Me.event_table.MultiSelect = False
        Me.event_table.Name = "event_table"
        Me.event_table.Size = New System.Drawing.Size(631, 180)
        Me.event_table.TabIndex = 24
        Me.event_table.UseCompatibleStateImageBehavior = False
        Me.event_table.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Unit"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Text"
        Me.ColumnHeader2.Width = 178
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Dice"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 44
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Score"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 46
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Dec"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 39
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Time"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader6.Width = 164
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Tested"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'event_manager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 661)
        Me.Controls.Add(Me.event_table)
        Me.Controls.Add(Me.discard_event)
        Me.Controls.Add(Me.delete_event)
        Me.Controls.Add(Me.save_event)
        Me.Controls.Add(Me.edit_event)
        Me.Controls.Add(Me.new_event)
        Me.Controls.Add(Me.dice_score)
        Me.Controls.Add(Me.dec_dice)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dice_type)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.detail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.side_options)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.event_time)
        Me.Controls.Add(Me.event_time_inc)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "event_manager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Events"
        CType(Me.event_time_inc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents event_time As System.Windows.Forms.Label
    Friend WithEvents event_time_inc As System.Windows.Forms.TrackBar
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents side_options As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents detail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dice_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dec_dice As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dice_score As System.Windows.Forms.TextBox
    Friend WithEvents new_event As System.Windows.Forms.Button
    Friend WithEvents save_event As System.Windows.Forms.Button
    Friend WithEvents delete_event As System.Windows.Forms.Button
    Friend WithEvents discard_event As System.Windows.Forms.Button
    Friend WithEvents edit_event As System.Windows.Forms.Button
    Friend WithEvents event_table As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
End Class
