<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVoluntaris
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RadioButtonAssignats = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNoAssignats = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonAfegir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextCognoms = New System.Windows.Forms.TextBox()
        Me.TextNom = New System.Windows.Forms.TextBox()
        Me.TextNif = New System.Windows.Forms.TextBox()
        Me.Button_MostrarDades = New System.Windows.Forms.Button()
        Me.Button_ActualitzarDades = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RadioButtonMostrarTots = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ButtonCorreus = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(26, 105)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(1035, 608)
        Me.DataGridView1.TabIndex = 0
        '
        'RadioButtonAssignats
        '
        Me.RadioButtonAssignats.AutoSize = True
        Me.RadioButtonAssignats.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonAssignats.ForeColor = System.Drawing.Color.White
        Me.RadioButtonAssignats.Location = New System.Drawing.Point(1158, 219)
        Me.RadioButtonAssignats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButtonAssignats.Name = "RadioButtonAssignats"
        Me.RadioButtonAssignats.Size = New System.Drawing.Size(255, 29)
        Me.RadioButtonAssignats.TabIndex = 1
        Me.RadioButtonAssignats.TabStop = True
        Me.RadioButtonAssignats.Text = "Assignats Projecte (actiu)"
        Me.RadioButtonAssignats.UseVisualStyleBackColor = True
        '
        'RadioButtonNoAssignats
        '
        Me.RadioButtonNoAssignats.AutoSize = True
        Me.RadioButtonNoAssignats.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonNoAssignats.ForeColor = System.Drawing.Color.White
        Me.RadioButtonNoAssignats.Location = New System.Drawing.Point(1158, 251)
        Me.RadioButtonNoAssignats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButtonNoAssignats.Name = "RadioButtonNoAssignats"
        Me.RadioButtonNoAssignats.Size = New System.Drawing.Size(278, 29)
        Me.RadioButtonNoAssignats.TabIndex = 3
        Me.RadioButtonNoAssignats.TabStop = True
        Me.RadioButtonNoAssignats.Text = "No Assignats a cap Projecte"
        Me.RadioButtonNoAssignats.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1142, 762)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Vols afegir un Voluntari?"
        '
        'ButtonAfegir
        '
        Me.ButtonAfegir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAfegir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonAfegir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAfegir.Location = New System.Drawing.Point(1398, 750)
        Me.ButtonAfegir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAfegir.Name = "ButtonAfegir"
        Me.ButtonAfegir.Size = New System.Drawing.Size(105, 35)
        Me.ButtonAfegir.TabIndex = 6
        Me.ButtonAfegir.Text = "Afegir"
        Me.ButtonAfegir.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1139, 504)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 25)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "cognoms:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1191, 448)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 25)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "nom:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1191, 388)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 25)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "nif:"
        '
        'TextCognoms
        '
        Me.TextCognoms.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCognoms.ForeColor = System.Drawing.Color.Black
        Me.TextCognoms.Location = New System.Drawing.Point(1261, 500)
        Me.TextCognoms.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextCognoms.Name = "TextCognoms"
        Me.TextCognoms.Size = New System.Drawing.Size(152, 30)
        Me.TextCognoms.TabIndex = 17
        '
        'TextNom
        '
        Me.TextNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNom.ForeColor = System.Drawing.Color.Black
        Me.TextNom.Location = New System.Drawing.Point(1261, 446)
        Me.TextNom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextNom.Name = "TextNom"
        Me.TextNom.Size = New System.Drawing.Size(152, 30)
        Me.TextNom.TabIndex = 16
        '
        'TextNif
        '
        Me.TextNif.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNif.ForeColor = System.Drawing.Color.Black
        Me.TextNif.Location = New System.Drawing.Point(1247, 388)
        Me.TextNif.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextNif.Name = "TextNif"
        Me.TextNif.Size = New System.Drawing.Size(165, 30)
        Me.TextNif.TabIndex = 15
        '
        'Button_MostrarDades
        '
        Me.Button_MostrarDades.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button_MostrarDades.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_MostrarDades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_MostrarDades.ForeColor = System.Drawing.Color.Black
        Me.Button_MostrarDades.Location = New System.Drawing.Point(1175, 556)
        Me.Button_MostrarDades.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button_MostrarDades.Name = "Button_MostrarDades"
        Me.Button_MostrarDades.Size = New System.Drawing.Size(136, 60)
        Me.Button_MostrarDades.TabIndex = 21
        Me.Button_MostrarDades.Text = "Mostrar Dades"
        Me.Button_MostrarDades.UseVisualStyleBackColor = False
        '
        'Button_ActualitzarDades
        '
        Me.Button_ActualitzarDades.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button_ActualitzarDades.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_ActualitzarDades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_ActualitzarDades.ForeColor = System.Drawing.Color.Black
        Me.Button_ActualitzarDades.Location = New System.Drawing.Point(1349, 556)
        Me.Button_ActualitzarDades.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button_ActualitzarDades.Name = "Button_ActualitzarDades"
        Me.Button_ActualitzarDades.Size = New System.Drawing.Size(139, 60)
        Me.Button_ActualitzarDades.TabIndex = 22
        Me.Button_ActualitzarDades.Text = "Actualitzar Dades"
        Me.Button_ActualitzarDades.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1204, 640)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(255, 38)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Projectes del voluntari"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'RadioButtonMostrarTots
        '
        Me.RadioButtonMostrarTots.AutoSize = True
        Me.RadioButtonMostrarTots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonMostrarTots.ForeColor = System.Drawing.Color.White
        Me.RadioButtonMostrarTots.Location = New System.Drawing.Point(1158, 188)
        Me.RadioButtonMostrarTots.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButtonMostrarTots.Name = "RadioButtonMostrarTots"
        Me.RadioButtonMostrarTots.Size = New System.Drawing.Size(143, 29)
        Me.RadioButtonMostrarTots.TabIndex = 25
        Me.RadioButtonMostrarTots.TabStop = True
        Me.RadioButtonMostrarTots.Text = "Mostrar Tots"
        Me.RadioButtonMostrarTots.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1118, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(348, 25)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "-------------------Consultar-----------------"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1139, 300)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(313, 25)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "-------------------------------------------"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1067, 348)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(468, 25)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "-------------------Consultar per Voluntari -----------------"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1118, 688)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(418, 25)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "----------------------------------------------------------"
        '
        'ButtonCorreus
        '
        Me.ButtonCorreus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonCorreus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonCorreus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCorreus.Location = New System.Drawing.Point(598, 762)
        Me.ButtonCorreus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonCorreus.Name = "ButtonCorreus"
        Me.ButtonCorreus.Size = New System.Drawing.Size(177, 43)
        Me.ButtonCorreus.TabIndex = 30
        Me.ButtonCorreus.Text = "generar correus"
        Me.ButtonCorreus.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Button1.Location = New System.Drawing.Point(361, 756)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(195, 55)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "ambits i idiomes"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(825, 828)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(309, 156)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "Generar Certificat"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'FormVoluntaris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1902, 1033)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonCorreus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.RadioButtonMostrarTots)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button_ActualitzarDades)
        Me.Controls.Add(Me.Button_MostrarDades)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextCognoms)
        Me.Controls.Add(Me.TextNom)
        Me.Controls.Add(Me.TextNif)
        Me.Controls.Add(Me.ButtonAfegir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadioButtonNoAssignats)
        Me.Controls.Add(Me.RadioButtonAssignats)
        Me.Controls.Add(Me.DataGridView1)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormVoluntaris"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RadioButtonAssignats As RadioButton
    Friend WithEvents RadioButtonNoAssignats As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonAfegir As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextCognoms As TextBox
    Friend WithEvents TextNom As TextBox
    Friend WithEvents TextNif As TextBox
    Friend WithEvents Button_MostrarDades As Button
    Friend WithEvents Button_ActualitzarDades As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents RadioButtonMostrarTots As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ButtonCorreus As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
End Class
