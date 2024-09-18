<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAmbitVoluntariIdiomes
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
        Me.ButtonAddAmbit = New System.Windows.Forms.Button()
        Me.TextBoxNomAmbit = New System.Windows.Forms.TextBox()
        Me.ComboBoxAmbits = New System.Windows.Forms.ComboBox()
        Me.DataGridViewVoluntaris = New System.Windows.Forms.DataGridView()
        Me.ButtonAddAmbitAVoluntari = New System.Windows.Forms.Button()
        Me.DataGridViewAmbits = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBoxIdiomes = New System.Windows.Forms.ComboBox()
        Me.TextBoxIdioma = New System.Windows.Forms.TextBox()
        Me.ButtonAddIdioma = New System.Windows.Forms.Button()
        Me.ButtonAddIdiomaAVoluntari = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewAmbits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAddAmbit
        '
        Me.ButtonAddAmbit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAddAmbit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddAmbit.Location = New System.Drawing.Point(1544, 76)
        Me.ButtonAddAmbit.Name = "ButtonAddAmbit"
        Me.ButtonAddAmbit.Size = New System.Drawing.Size(159, 46)
        Me.ButtonAddAmbit.TabIndex = 0
        Me.ButtonAddAmbit.Text = "Afegir Ambit"
        Me.ButtonAddAmbit.UseVisualStyleBackColor = False
        '
        'TextBoxNomAmbit
        '
        Me.TextBoxNomAmbit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomAmbit.Location = New System.Drawing.Point(1203, 87)
        Me.TextBoxNomAmbit.Name = "TextBoxNomAmbit"
        Me.TextBoxNomAmbit.Size = New System.Drawing.Size(268, 35)
        Me.TextBoxNomAmbit.TabIndex = 1
        '
        'ComboBoxAmbits
        '
        Me.ComboBoxAmbits.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAmbits.FormattingEnabled = True
        Me.ComboBoxAmbits.Location = New System.Drawing.Point(960, 85)
        Me.ComboBoxAmbits.Name = "ComboBoxAmbits"
        Me.ComboBoxAmbits.Size = New System.Drawing.Size(216, 37)
        Me.ComboBoxAmbits.TabIndex = 2
        '
        'DataGridViewVoluntaris
        '
        Me.DataGridViewVoluntaris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewVoluntaris.Location = New System.Drawing.Point(28, 147)
        Me.DataGridViewVoluntaris.Name = "DataGridViewVoluntaris"
        Me.DataGridViewVoluntaris.RowHeadersWidth = 62
        Me.DataGridViewVoluntaris.RowTemplate.Height = 28
        Me.DataGridViewVoluntaris.Size = New System.Drawing.Size(698, 690)
        Me.DataGridViewVoluntaris.TabIndex = 3
        '
        'ButtonAddAmbitAVoluntari
        '
        Me.ButtonAddAmbitAVoluntari.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAddAmbitAVoluntari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddAmbitAVoluntari.Location = New System.Drawing.Point(795, 414)
        Me.ButtonAddAmbitAVoluntari.Name = "ButtonAddAmbitAVoluntari"
        Me.ButtonAddAmbitAVoluntari.Size = New System.Drawing.Size(292, 64)
        Me.ButtonAddAmbitAVoluntari.TabIndex = 4
        Me.ButtonAddAmbitAVoluntari.Text = "Afegir Ambit a Voluntari"
        Me.ButtonAddAmbitAVoluntari.UseVisualStyleBackColor = False
        '
        'DataGridViewAmbits
        '
        Me.DataGridViewAmbits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewAmbits.Location = New System.Drawing.Point(1055, 720)
        Me.DataGridViewAmbits.Name = "DataGridViewAmbits"
        Me.DataGridViewAmbits.RowHeadersWidth = 62
        Me.DataGridViewAmbits.RowTemplate.Height = 28
        Me.DataGridViewAmbits.Size = New System.Drawing.Size(532, 234)
        Me.DataGridViewAmbits.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1347, 604)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 70)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Eliminar Ambit de voluntari"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBoxIdiomes
        '
        Me.ComboBoxIdiomes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxIdiomes.FormattingEnabled = True
        Me.ComboBoxIdiomes.Location = New System.Drawing.Point(960, 181)
        Me.ComboBoxIdiomes.Name = "ComboBoxIdiomes"
        Me.ComboBoxIdiomes.Size = New System.Drawing.Size(216, 37)
        Me.ComboBoxIdiomes.TabIndex = 7
        '
        'TextBoxIdioma
        '
        Me.TextBoxIdioma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxIdioma.Location = New System.Drawing.Point(1203, 183)
        Me.TextBoxIdioma.Name = "TextBoxIdioma"
        Me.TextBoxIdioma.Size = New System.Drawing.Size(270, 35)
        Me.TextBoxIdioma.TabIndex = 8
        '
        'ButtonAddIdioma
        '
        Me.ButtonAddIdioma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAddIdioma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddIdioma.Location = New System.Drawing.Point(1529, 170)
        Me.ButtonAddIdioma.Name = "ButtonAddIdioma"
        Me.ButtonAddIdioma.Size = New System.Drawing.Size(185, 46)
        Me.ButtonAddIdioma.TabIndex = 9
        Me.ButtonAddIdioma.Text = "Afegir Idioma"
        Me.ButtonAddIdioma.UseVisualStyleBackColor = False
        '
        'ButtonAddIdiomaAVoluntari
        '
        Me.ButtonAddIdiomaAVoluntari.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAddIdiomaAVoluntari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAddIdiomaAVoluntari.Location = New System.Drawing.Point(795, 298)
        Me.ButtonAddIdiomaAVoluntari.Name = "ButtonAddIdiomaAVoluntari"
        Me.ButtonAddIdiomaAVoluntari.Size = New System.Drawing.Size(305, 64)
        Me.ButtonAddIdiomaAVoluntari.TabIndex = 10
        Me.ButtonAddIdiomaAVoluntari.Text = "Afegir Idioma a Voluntari"
        Me.ButtonAddIdiomaAVoluntari.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1055, 600)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(212, 79)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Eliminar Idioma de voluntari"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FormAmbitVoluntariIdiomes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1898, 1024)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonAddIdiomaAVoluntari)
        Me.Controls.Add(Me.ButtonAddIdioma)
        Me.Controls.Add(Me.TextBoxIdioma)
        Me.Controls.Add(Me.ComboBoxIdiomes)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridViewAmbits)
        Me.Controls.Add(Me.ButtonAddAmbitAVoluntari)
        Me.Controls.Add(Me.DataGridViewVoluntaris)
        Me.Controls.Add(Me.ComboBoxAmbits)
        Me.Controls.Add(Me.TextBoxNomAmbit)
        Me.Controls.Add(Me.ButtonAddAmbit)
        Me.Name = "FormAmbitVoluntariIdiomes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormAmbitVoluntariIdiomes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewAmbits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonAddAmbit As Button
    Friend WithEvents TextBoxNomAmbit As TextBox
    Friend WithEvents ComboBoxAmbits As ComboBox
    Friend WithEvents DataGridViewVoluntaris As DataGridView
    Friend WithEvents ButtonAddAmbitAVoluntari As Button
    Friend WithEvents DataGridViewAmbits As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBoxIdiomes As ComboBox
    Friend WithEvents TextBoxIdioma As TextBox
    Friend WithEvents ButtonAddIdioma As Button
    Friend WithEvents ButtonAddIdiomaAVoluntari As Button
    Friend WithEvents Button2 As Button
End Class
