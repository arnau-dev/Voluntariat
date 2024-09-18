<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDisponbilitat
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
        Me.ComboBoxdia = New System.Windows.Forms.ComboBox()
        Me.ComboBoxhoraIn = New System.Windows.Forms.ComboBox()
        Me.ComboBoxhoraFi = New System.Windows.Forms.ComboBox()
        Me.ButtonAssignarDisponibilitat = New System.Windows.Forms.Button()
        Me.DataGridViewDisponibilitat = New System.Windows.Forms.DataGridView()
        Me.DataGridViewVoluntaris = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewDisponibilitat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxdia
        '
        Me.ComboBoxdia.FormattingEnabled = True
        Me.ComboBoxdia.Location = New System.Drawing.Point(904, 454)
        Me.ComboBoxdia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxdia.Name = "ComboBoxdia"
        Me.ComboBoxdia.Size = New System.Drawing.Size(131, 24)
        Me.ComboBoxdia.TabIndex = 4
        '
        'ComboBoxhoraIn
        '
        Me.ComboBoxhoraIn.FormattingEnabled = True
        Me.ComboBoxhoraIn.Location = New System.Drawing.Point(1065, 454)
        Me.ComboBoxhoraIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxhoraIn.Name = "ComboBoxhoraIn"
        Me.ComboBoxhoraIn.Size = New System.Drawing.Size(141, 24)
        Me.ComboBoxhoraIn.TabIndex = 5
        '
        'ComboBoxhoraFi
        '
        Me.ComboBoxhoraFi.FormattingEnabled = True
        Me.ComboBoxhoraFi.Location = New System.Drawing.Point(1235, 454)
        Me.ComboBoxhoraFi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxhoraFi.Name = "ComboBoxhoraFi"
        Me.ComboBoxhoraFi.Size = New System.Drawing.Size(145, 24)
        Me.ComboBoxhoraFi.TabIndex = 6
        '
        'ButtonAssignarDisponibilitat
        '
        Me.ButtonAssignarDisponibilitat.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAssignarDisponibilitat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ButtonAssignarDisponibilitat.Location = New System.Drawing.Point(1044, 507)
        Me.ButtonAssignarDisponibilitat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAssignarDisponibilitat.Name = "ButtonAssignarDisponibilitat"
        Me.ButtonAssignarDisponibilitat.Size = New System.Drawing.Size(191, 77)
        Me.ButtonAssignarDisponibilitat.TabIndex = 7
        Me.ButtonAssignarDisponibilitat.Text = "Afegir Disponibilitat"
        Me.ButtonAssignarDisponibilitat.UseVisualStyleBackColor = False
        '
        'DataGridViewDisponibilitat
        '
        Me.DataGridViewDisponibilitat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDisponibilitat.Location = New System.Drawing.Point(159, 445)
        Me.DataGridViewDisponibilitat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewDisponibilitat.Name = "DataGridViewDisponibilitat"
        Me.DataGridViewDisponibilitat.RowHeadersWidth = 62
        Me.DataGridViewDisponibilitat.RowTemplate.Height = 28
        Me.DataGridViewDisponibilitat.Size = New System.Drawing.Size(684, 365)
        Me.DataGridViewDisponibilitat.TabIndex = 8
        '
        'DataGridViewVoluntaris
        '
        Me.DataGridViewVoluntaris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewVoluntaris.Location = New System.Drawing.Point(159, 124)
        Me.DataGridViewVoluntaris.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewVoluntaris.Name = "DataGridViewVoluntaris"
        Me.DataGridViewVoluntaris.RowHeadersWidth = 62
        Me.DataGridViewVoluntaris.RowTemplate.Height = 28
        Me.DataGridViewVoluntaris.Size = New System.Drawing.Size(684, 302)
        Me.DataGridViewVoluntaris.TabIndex = 0
        '
        'FormDisponbilitat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1902, 1033)
        Me.Controls.Add(Me.DataGridViewDisponibilitat)
        Me.Controls.Add(Me.ButtonAssignarDisponibilitat)
        Me.Controls.Add(Me.ComboBoxhoraFi)
        Me.Controls.Add(Me.ComboBoxhoraIn)
        Me.Controls.Add(Me.ComboBoxdia)
        Me.Controls.Add(Me.DataGridViewVoluntaris)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormDisponbilitat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridViewDisponibilitat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBoxdia As ComboBox
    Friend WithEvents ComboBoxhoraIn As ComboBox
    Friend WithEvents ComboBoxhoraFi As ComboBox
    Friend WithEvents ButtonAssignarDisponibilitat As Button
    Friend WithEvents DataGridViewDisponibilitat As DataGridView
    Friend WithEvents DataGridViewVoluntaris As DataGridView
End Class
