<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class scenariodefaults
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(scenariodefaults))
        Me.start_time_inc = New System.Windows.Forms.TrackBar()
        Me.start_time = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dusk = New System.Windows.Forms.Label()
        Me.dusk_inc = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Current_time = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.player1 = New System.Windows.Forms.TextBox()
        Me.player2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gameturn = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.nextturn = New System.Windows.Forms.Button()
        Me.loadscenario = New System.Windows.Forms.Button()
        Me.savescenario = New System.Windows.Forms.Button()
        Me.newscenario = New System.Windows.Forms.Button()
        Me.player1_init = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.player2_init = New System.Windows.Forms.TextBox()
        Me.p1_orbat_manager = New System.Windows.Forms.Button()
        Me.p2_orbat_manager = New System.Windows.Forms.Button()
        Me.reset_scenario = New System.Windows.Forms.Button()
        Me.test_button = New System.Windows.Forms.Button()
        CType(Me.start_time_inc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dusk_inc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'start_time_inc
        '
        Me.start_time_inc.BackColor = System.Drawing.SystemColors.Control
        Me.start_time_inc.Enabled = False
        Me.start_time_inc.Location = New System.Drawing.Point(449, 33)
        Me.start_time_inc.Maximum = 30
        Me.start_time_inc.Name = "start_time_inc"
        Me.start_time_inc.Size = New System.Drawing.Size(172, 45)
        Me.start_time_inc.TabIndex = 0
        Me.start_time_inc.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'start_time
        '
        Me.start_time.AutoSize = True
        Me.start_time.BackColor = System.Drawing.Color.White
        Me.start_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.start_time.Enabled = False
        Me.start_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_time.Location = New System.Drawing.Point(318, 40)
        Me.start_time.MaximumSize = New System.Drawing.Size(125, 30)
        Me.start_time.MinimumSize = New System.Drawing.Size(125, 30)
        Me.start_time.Name = "start_time"
        Me.start_time.Size = New System.Drawing.Size(125, 30)
        Me.start_time.TabIndex = 1
        Me.start_time.Text = "0"
        Me.start_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(188, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Start Time"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(245, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 29)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Dusk"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dusk
        '
        Me.Dusk.AutoSize = True
        Me.Dusk.BackColor = System.Drawing.Color.White
        Me.Dusk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dusk.Enabled = False
        Me.Dusk.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dusk.Location = New System.Drawing.Point(318, 88)
        Me.Dusk.MaximumSize = New System.Drawing.Size(125, 30)
        Me.Dusk.MinimumSize = New System.Drawing.Size(125, 30)
        Me.Dusk.Name = "Dusk"
        Me.Dusk.Size = New System.Drawing.Size(125, 30)
        Me.Dusk.TabIndex = 4
        Me.Dusk.Text = "0"
        Me.Dusk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dusk_inc
        '
        Me.dusk_inc.BackColor = System.Drawing.SystemColors.Control
        Me.dusk_inc.Enabled = False
        Me.dusk_inc.Location = New System.Drawing.Point(449, 81)
        Me.dusk_inc.Name = "dusk_inc"
        Me.dusk_inc.Size = New System.Drawing.Size(172, 45)
        Me.dusk_inc.TabIndex = 3
        Me.dusk_inc.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(158, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 29)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Current Time"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Current_time
        '
        Me.Current_time.AutoSize = True
        Me.Current_time.BackColor = System.Drawing.Color.White
        Me.Current_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Current_time.Enabled = False
        Me.Current_time.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Current_time.Location = New System.Drawing.Point(318, 140)
        Me.Current_time.MaximumSize = New System.Drawing.Size(125, 30)
        Me.Current_time.MinimumSize = New System.Drawing.Size(125, 30)
        Me.Current_time.Name = "Current_time"
        Me.Current_time.Size = New System.Drawing.Size(125, 30)
        Me.Current_time.TabIndex = 7
        Me.Current_time.Text = "0"
        Me.Current_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(212, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 29)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Player 1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'player1
        '
        Me.player1.Enabled = False
        Me.player1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.player1.Location = New System.Drawing.Point(318, 193)
        Me.player1.Name = "player1"
        Me.player1.Size = New System.Drawing.Size(125, 35)
        Me.player1.TabIndex = 10
        Me.player1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'player2
        '
        Me.player2.Enabled = False
        Me.player2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.player2.Location = New System.Drawing.Point(318, 302)
        Me.player2.Name = "player2"
        Me.player2.Size = New System.Drawing.Size(125, 35)
        Me.player2.TabIndex = 12
        Me.player2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(212, 308)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 29)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Player 2"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gameturn
        '
        Me.gameturn.Enabled = False
        Me.gameturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gameturn.Location = New System.Drawing.Point(318, 413)
        Me.gameturn.Name = "gameturn"
        Me.gameturn.Size = New System.Drawing.Size(125, 35)
        Me.gameturn.TabIndex = 14
        Me.gameturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(178, 416)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 29)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Game Turn"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nextturn
        '
        Me.nextturn.Enabled = False
        Me.nextturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nextturn.Location = New System.Drawing.Point(507, 615)
        Me.nextturn.Name = "nextturn"
        Me.nextturn.Size = New System.Drawing.Size(165, 42)
        Me.nextturn.TabIndex = 15
        Me.nextturn.Text = "Continue to [N]ext Turn"
        Me.nextturn.UseVisualStyleBackColor = True
        '
        'loadscenario
        '
        Me.loadscenario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loadscenario.Location = New System.Drawing.Point(12, 520)
        Me.loadscenario.Name = "loadscenario"
        Me.loadscenario.Size = New System.Drawing.Size(120, 40)
        Me.loadscenario.TabIndex = 16
        Me.loadscenario.Text = "Load Scenario"
        Me.loadscenario.UseVisualStyleBackColor = True
        '
        'savescenario
        '
        Me.savescenario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.savescenario.Location = New System.Drawing.Point(12, 567)
        Me.savescenario.Name = "savescenario"
        Me.savescenario.Size = New System.Drawing.Size(120, 40)
        Me.savescenario.TabIndex = 17
        Me.savescenario.Text = "Save Scenario"
        Me.savescenario.UseVisualStyleBackColor = True
        '
        'newscenario
        '
        Me.newscenario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newscenario.Location = New System.Drawing.Point(12, 473)
        Me.newscenario.Name = "newscenario"
        Me.newscenario.Size = New System.Drawing.Size(120, 40)
        Me.newscenario.TabIndex = 18
        Me.newscenario.Text = "New Scenario"
        Me.newscenario.UseVisualStyleBackColor = True
        '
        'player1_init
        '
        Me.player1_init.Enabled = False
        Me.player1_init.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.player1_init.Location = New System.Drawing.Point(318, 249)
        Me.player1_init.Name = "player1_init"
        Me.player1_init.Size = New System.Drawing.Size(125, 35)
        Me.player1_init.TabIndex = 11
        Me.player1_init.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(119, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(193, 29)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Initiative Player 1"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(119, 361)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(193, 29)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Initiative Player 2"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'player2_init
        '
        Me.player2_init.Enabled = False
        Me.player2_init.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.player2_init.Location = New System.Drawing.Point(318, 358)
        Me.player2_init.Name = "player2_init"
        Me.player2_init.Size = New System.Drawing.Size(125, 35)
        Me.player2_init.TabIndex = 13
        Me.player2_init.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'p1_orbat_manager
        '
        Me.p1_orbat_manager.Enabled = False
        Me.p1_orbat_manager.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.p1_orbat_manager.Location = New System.Drawing.Point(477, 193)
        Me.p1_orbat_manager.Name = "p1_orbat_manager"
        Me.p1_orbat_manager.Size = New System.Drawing.Size(157, 35)
        Me.p1_orbat_manager.TabIndex = 19
        Me.p1_orbat_manager.Text = "Edit Player 1 Orbat"
        Me.p1_orbat_manager.UseVisualStyleBackColor = True
        '
        'p2_orbat_manager
        '
        Me.p2_orbat_manager.Enabled = False
        Me.p2_orbat_manager.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.p2_orbat_manager.Location = New System.Drawing.Point(477, 302)
        Me.p2_orbat_manager.Name = "p2_orbat_manager"
        Me.p2_orbat_manager.Size = New System.Drawing.Size(157, 35)
        Me.p2_orbat_manager.TabIndex = 21
        Me.p2_orbat_manager.Text = "Edit Player 2 Orbat"
        Me.p2_orbat_manager.UseVisualStyleBackColor = True
        '
        'reset_scenario
        '
        Me.reset_scenario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reset_scenario.Location = New System.Drawing.Point(12, 614)
        Me.reset_scenario.Name = "reset_scenario"
        Me.reset_scenario.Size = New System.Drawing.Size(120, 40)
        Me.reset_scenario.TabIndex = 24
        Me.reset_scenario.Text = "Reset Scenario"
        Me.reset_scenario.UseVisualStyleBackColor = True
        '
        'test_button
        '
        Me.test_button.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.test_button.Location = New System.Drawing.Point(477, 463)
        Me.test_button.Name = "test_button"
        Me.test_button.Size = New System.Drawing.Size(156, 37)
        Me.test_button.TabIndex = 25
        Me.test_button.Text = "Test"
        Me.test_button.UseVisualStyleBackColor = True
        Me.test_button.Visible = False
        '
        'scenariodefaults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(684, 661)
        Me.Controls.Add(Me.test_button)
        Me.Controls.Add(Me.reset_scenario)
        Me.Controls.Add(Me.p2_orbat_manager)
        Me.Controls.Add(Me.player2_init)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.player1_init)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.p1_orbat_manager)
        Me.Controls.Add(Me.newscenario)
        Me.Controls.Add(Me.savescenario)
        Me.Controls.Add(Me.loadscenario)
        Me.Controls.Add(Me.nextturn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.gameturn)
        Me.Controls.Add(Me.player2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.player1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Current_time)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Dusk)
        Me.Controls.Add(Me.dusk_inc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.start_time)
        Me.Controls.Add(Me.start_time_inc)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(700, 700)
        Me.MinimumSize = New System.Drawing.Size(700, 700)
        Me.Name = "scenariodefaults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Control and Defaults"
        CType(Me.start_time_inc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dusk_inc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents start_time_inc As System.Windows.Forms.TrackBar
    Friend WithEvents start_time As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dusk As System.Windows.Forms.Label
    Friend WithEvents dusk_inc As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Current_time As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents player1 As System.Windows.Forms.TextBox
    Friend WithEvents player2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gameturn As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents nextturn As System.Windows.Forms.Button
    Friend WithEvents loadscenario As System.Windows.Forms.Button
    Friend WithEvents savescenario As System.Windows.Forms.Button
    Friend WithEvents newscenario As System.Windows.Forms.Button
    Friend WithEvents player1_init As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents player2_init As System.Windows.Forms.TextBox
    Friend WithEvents p1_orbat_manager As System.Windows.Forms.Button
    Friend WithEvents p2_orbat_manager As System.Windows.Forms.Button
    Friend WithEvents reset_scenario As System.Windows.Forms.Button
    Friend WithEvents test_button As System.Windows.Forms.Button

End Class
