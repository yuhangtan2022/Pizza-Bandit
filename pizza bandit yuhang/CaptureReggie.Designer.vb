<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CaptureReggie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CaptureReggie))
        Me.help = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tryagain = New System.Windows.Forms.Button()
        Me.quitbutton = New System.Windows.Forms.Button()
        CType(Me.help, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'help
        '
        Me.help.Image = CType(resources.GetObject("help.Image"), System.Drawing.Image)
        Me.help.Location = New System.Drawing.Point(85, 67)
        Me.help.Name = "help"
        Me.help.Size = New System.Drawing.Size(114, 111)
        Me.help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.help.TabIndex = 0
        Me.help.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Quartz MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(80, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CAPTURED..."
        '
        'tryagain
        '
        Me.tryagain.Location = New System.Drawing.Point(52, 205)
        Me.tryagain.Name = "tryagain"
        Me.tryagain.Size = New System.Drawing.Size(75, 23)
        Me.tryagain.TabIndex = 2
        Me.tryagain.Text = "TRY AGAIN"
        Me.tryagain.UseVisualStyleBackColor = True
        '
        'quitbutton
        '
        Me.quitbutton.Location = New System.Drawing.Point(167, 205)
        Me.quitbutton.Name = "quitbutton"
        Me.quitbutton.Size = New System.Drawing.Size(75, 23)
        Me.quitbutton.TabIndex = 3
        Me.quitbutton.Text = "QUIT"
        Me.quitbutton.UseVisualStyleBackColor = True
        '
        'CaptureReggie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.quitbutton)
        Me.Controls.Add(Me.tryagain)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.help)
        Me.Name = "CaptureReggie"
        Me.Text = "CaptureReggie"
        CType(Me.help, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents help As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tryagain As System.Windows.Forms.Button
    Friend WithEvents quitbutton As System.Windows.Forms.Button
End Class
