<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomePage
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
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.btnPatients = New System.Windows.Forms.Button()
        Me.btnReferrals = New System.Windows.Forms.Button()
        Me.btnDoctors = New System.Windows.Forms.Button()
        Me.btnLaboratory = New System.Windows.Forms.Button()
        Me.btnPharmacy = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRegistration
        '
        Me.btnRegistration.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRegistration.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistration.Location = New System.Drawing.Point(250, 256)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Size = New System.Drawing.Size(313, 88)
        Me.btnRegistration.TabIndex = 0
        Me.btnRegistration.Text = "Registration"
        Me.btnRegistration.UseVisualStyleBackColor = False
        '
        'btnPatients
        '
        Me.btnPatients.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPatients.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPatients.Location = New System.Drawing.Point(569, 256)
        Me.btnPatients.Name = "btnPatients"
        Me.btnPatients.Size = New System.Drawing.Size(313, 88)
        Me.btnPatients.TabIndex = 1
        Me.btnPatients.Text = "Patients"
        Me.btnPatients.UseVisualStyleBackColor = False
        '
        'btnReferrals
        '
        Me.btnReferrals.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnReferrals.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReferrals.Location = New System.Drawing.Point(569, 350)
        Me.btnReferrals.Name = "btnReferrals"
        Me.btnReferrals.Size = New System.Drawing.Size(313, 88)
        Me.btnReferrals.TabIndex = 3
        Me.btnReferrals.Text = "Referrals"
        Me.btnReferrals.UseVisualStyleBackColor = False
        '
        'btnDoctors
        '
        Me.btnDoctors.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDoctors.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoctors.Location = New System.Drawing.Point(250, 350)
        Me.btnDoctors.Name = "btnDoctors"
        Me.btnDoctors.Size = New System.Drawing.Size(313, 88)
        Me.btnDoctors.TabIndex = 2
        Me.btnDoctors.Text = "Doctors"
        Me.btnDoctors.UseVisualStyleBackColor = False
        '
        'btnLaboratory
        '
        Me.btnLaboratory.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLaboratory.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaboratory.Location = New System.Drawing.Point(569, 443)
        Me.btnLaboratory.Name = "btnLaboratory"
        Me.btnLaboratory.Size = New System.Drawing.Size(313, 88)
        Me.btnLaboratory.TabIndex = 5
        Me.btnLaboratory.Text = "Laboratory"
        Me.btnLaboratory.UseVisualStyleBackColor = False
        '
        'btnPharmacy
        '
        Me.btnPharmacy.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPharmacy.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPharmacy.Location = New System.Drawing.Point(250, 443)
        Me.btnPharmacy.Name = "btnPharmacy"
        Me.btnPharmacy.Size = New System.Drawing.Size(313, 88)
        Me.btnPharmacy.TabIndex = 4
        Me.btnPharmacy.Text = "Pharmacy"
        Me.btnPharmacy.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(252, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(623, 77)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "CURIS DIAGNOSTIC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(167, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(843, 77)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "AND LABORATORY CENTER"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CurisSystem.My.Resources.Resources.back_arrow
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'HomePage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1112, 635)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnLaboratory)
        Me.Controls.Add(Me.btnPharmacy)
        Me.Controls.Add(Me.btnReferrals)
        Me.Controls.Add(Me.btnDoctors)
        Me.Controls.Add(Me.btnPatients)
        Me.Controls.Add(Me.btnRegistration)
        Me.Name = "HomePage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HomePage"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRegistration As System.Windows.Forms.Button
    Friend WithEvents btnPatients As System.Windows.Forms.Button
    Friend WithEvents btnReferrals As System.Windows.Forms.Button
    Friend WithEvents btnDoctors As System.Windows.Forms.Button
    Friend WithEvents btnLaboratory As System.Windows.Forms.Button
    Friend WithEvents btnPharmacy As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
