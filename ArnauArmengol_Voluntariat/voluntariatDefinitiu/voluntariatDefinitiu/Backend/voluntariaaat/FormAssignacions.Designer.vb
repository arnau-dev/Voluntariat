<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAssignacions
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonAssignar = New System.Windows.Forms.Button()
        Me.TextBoxVoluntari = New System.Windows.Forms.TextBox()
        Me.ComboBoxProjecte = New System.Windows.Forms.ComboBox()
        Me.DataGridViewVoluntaris = New System.Windows.Forms.DataGridView()
        Me.DataGridViewVoluntarisAsignats = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button_Correus = New System.Windows.Forms.Button()
        Me.RadioButton_NoAssignats = New System.Windows.Forms.RadioButton()
        Me.CheckBoxAmbitVoluntari = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewVoluntarisAsignats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(821, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 25)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Projecte"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(409, 689)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 25)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "NIF"
        '
        'ButtonAssignar
        '
        Me.ButtonAssignar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAssignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAssignar.Location = New System.Drawing.Point(394, 729)
        Me.ButtonAssignar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAssignar.Name = "ButtonAssignar"
        Me.ButtonAssignar.Size = New System.Drawing.Size(264, 91)
        Me.ButtonAssignar.TabIndex = 14
        Me.ButtonAssignar.Text = "Assignar Voluntari a Projecte"
        Me.ButtonAssignar.UseVisualStyleBackColor = False
        '
        'TextBoxVoluntari
        '
        Me.TextBoxVoluntari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxVoluntari.Location = New System.Drawing.Point(466, 685)
        Me.TextBoxVoluntari.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxVoluntari.Name = "TextBoxVoluntari"
        Me.TextBoxVoluntari.Size = New System.Drawing.Size(172, 30)
        Me.TextBoxVoluntari.TabIndex = 13
        '
        'ComboBoxProjecte
        '
        Me.ComboBoxProjecte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxProjecte.FormattingEnabled = True
        Me.ComboBoxProjecte.Location = New System.Drawing.Point(917, 63)
        Me.ComboBoxProjecte.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxProjecte.Name = "ComboBoxProjecte"
        Me.ComboBoxProjecte.Size = New System.Drawing.Size(163, 33)
        Me.ComboBoxProjecte.TabIndex = 12
        '
        'DataGridViewVoluntaris
        '
        Me.DataGridViewVoluntaris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewVoluntaris.Location = New System.Drawing.Point(344, 143)
        Me.DataGridViewVoluntaris.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewVoluntaris.Name = "DataGridViewVoluntaris"
        Me.DataGridViewVoluntaris.RowHeadersWidth = 62
        Me.DataGridViewVoluntaris.RowTemplate.Height = 28
        Me.DataGridViewVoluntaris.Size = New System.Drawing.Size(333, 498)
        Me.DataGridViewVoluntaris.TabIndex = 11
        '
        'DataGridViewVoluntarisAsignats
        '
        Me.DataGridViewVoluntarisAsignats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewVoluntarisAsignats.Location = New System.Drawing.Point(749, 162)
        Me.DataGridViewVoluntarisAsignats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewVoluntarisAsignats.Name = "DataGridViewVoluntarisAsignats"
        Me.DataGridViewVoluntarisAsignats.RowHeadersWidth = 62
        Me.DataGridViewVoluntarisAsignats.RowTemplate.Height = 28
        Me.DataGridViewVoluntarisAsignats.Size = New System.Drawing.Size(776, 437)
        Me.DataGridViewVoluntarisAsignats.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1325, 769)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(242, 51)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Eliminar Voluntari de Projecte"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1074, 784)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(228, 25)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "(Selecciona un voluntari)"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1096, 52)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 54)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Biaxes"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button_Correus
        '
        Me.Button_Correus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button_Correus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Correus.Location = New System.Drawing.Point(1226, 53)
        Me.Button_Correus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button_Correus.Name = "Button_Correus"
        Me.Button_Correus.Size = New System.Drawing.Size(222, 54)
        Me.Button_Correus.TabIndex = 21
        Me.Button_Correus.Text = "Generar Correus "
        Me.Button_Correus.UseVisualStyleBackColor = False
        '
        'RadioButton_NoAssignats
        '
        Me.RadioButton_NoAssignats.AutoSize = True
        Me.RadioButton_NoAssignats.ForeColor = System.Drawing.Color.White
        Me.RadioButton_NoAssignats.Location = New System.Drawing.Point(44, -38)
        Me.RadioButton_NoAssignats.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButton_NoAssignats.Name = "RadioButton_NoAssignats"
        Me.RadioButton_NoAssignats.Size = New System.Drawing.Size(169, 21)
        Me.RadioButton_NoAssignats.TabIndex = 22
        Me.RadioButton_NoAssignats.TabStop = True
        Me.RadioButton_NoAssignats.Text = "VoluntarisPerAssignar"
        Me.RadioButton_NoAssignats.UseVisualStyleBackColor = True
        '
        'CheckBoxAmbitVoluntari
        '
        Me.CheckBoxAmbitVoluntari.AutoSize = True
        Me.CheckBoxAmbitVoluntari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxAmbitVoluntari.Location = New System.Drawing.Point(394, 67)
        Me.CheckBoxAmbitVoluntari.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CheckBoxAmbitVoluntari.Name = "CheckBoxAmbitVoluntari"
        Me.CheckBoxAmbitVoluntari.Size = New System.Drawing.Size(191, 29)
        Me.CheckBoxAmbitVoluntari.TabIndex = 23
        Me.CheckBoxAmbitVoluntari.Text = "Ambit del Projecte"
        Me.CheckBoxAmbitVoluntari.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(381, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(263, 25)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "------------- Filtres --------------"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1221, 640)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 25)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "label5"
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Button9.Location = New System.Drawing.Point(1603, 301)
        Me.Button9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(225, 112)
        Me.Button9.TabIndex = 26
        Me.Button9.Text = "Generar estadistiques"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'FormAssignacions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1902, 1033)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBoxAmbitVoluntari)
        Me.Controls.Add(Me.RadioButton_NoAssignats)
        Me.Controls.Add(Me.Button_Correus)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridViewVoluntarisAsignats)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonAssignar)
        Me.Controls.Add(Me.TextBoxVoluntari)
        Me.Controls.Add(Me.ComboBoxProjecte)
        Me.Controls.Add(Me.DataGridViewVoluntaris)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormAssignacions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewVoluntarisAsignats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonAssignar As Button
    Friend WithEvents TextBoxVoluntari As TextBox
    Friend WithEvents ComboBoxProjecte As ComboBox
    Friend WithEvents DataGridViewVoluntaris As DataGridView
    Friend WithEvents DataGridViewVoluntarisAsignats As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button_Correus As Button
    Friend WithEvents RadioButton_NoAssignats As RadioButton
    Friend WithEvents CheckBoxAmbitVoluntari As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button9 As Button
End Class
