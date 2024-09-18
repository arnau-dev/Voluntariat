<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDisponbilitatIAssignacions
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
        Me.DataGridViewVoluntaris = New System.Windows.Forms.DataGridView()
        Me.ComboBoxProjecte = New System.Windows.Forms.ComboBox()
        Me.TextBoxVoluntari = New System.Windows.Forms.TextBox()
        Me.ButtonAssignar = New System.Windows.Forms.Button()
        Me.ComboBoxdia = New System.Windows.Forms.ComboBox()
        Me.ComboBoxhoraIn = New System.Windows.Forms.ComboBox()
        Me.ComboBoxhoraFi = New System.Windows.Forms.ComboBox()
        Me.ButtonAssignarDisponibilitat = New System.Windows.Forms.Button()
        Me.DataGridViewDisponibilitat = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuProjecteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewDisponibilitat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewVoluntaris
        '
        Me.DataGridViewVoluntaris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewVoluntaris.Location = New System.Drawing.Point(336, 203)
        Me.DataGridViewVoluntaris.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewVoluntaris.Name = "DataGridViewVoluntaris"
        Me.DataGridViewVoluntaris.RowHeadersWidth = 62
        Me.DataGridViewVoluntaris.RowTemplate.Height = 28
        Me.DataGridViewVoluntaris.Size = New System.Drawing.Size(460, 263)
        Me.DataGridViewVoluntaris.TabIndex = 0
        '
        'ComboBoxProjecte
        '
        Me.ComboBoxProjecte.FormattingEnabled = True
        Me.ComboBoxProjecte.Location = New System.Drawing.Point(930, 261)
        Me.ComboBoxProjecte.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxProjecte.Name = "ComboBoxProjecte"
        Me.ComboBoxProjecte.Size = New System.Drawing.Size(172, 24)
        Me.ComboBoxProjecte.TabIndex = 1
        '
        'TextBoxVoluntari
        '
        Me.TextBoxVoluntari.Location = New System.Drawing.Point(930, 225)
        Me.TextBoxVoluntari.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBoxVoluntari.Name = "TextBoxVoluntari"
        Me.TextBoxVoluntari.Size = New System.Drawing.Size(172, 22)
        Me.TextBoxVoluntari.TabIndex = 2
        '
        'ButtonAssignar
        '
        Me.ButtonAssignar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAssignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ButtonAssignar.Location = New System.Drawing.Point(1164, 225)
        Me.ButtonAssignar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAssignar.Name = "ButtonAssignar"
        Me.ButtonAssignar.Size = New System.Drawing.Size(207, 79)
        Me.ButtonAssignar.TabIndex = 3
        Me.ButtonAssignar.Text = "Assignar"
        Me.ButtonAssignar.UseVisualStyleBackColor = False
        '
        'ComboBoxdia
        '
        Me.ComboBoxdia.FormattingEnabled = True
        Me.ComboBoxdia.Location = New System.Drawing.Point(764, 584)
        Me.ComboBoxdia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxdia.Name = "ComboBoxdia"
        Me.ComboBoxdia.Size = New System.Drawing.Size(139, 24)
        Me.ComboBoxdia.TabIndex = 4
        '
        'ComboBoxhoraIn
        '
        Me.ComboBoxhoraIn.FormattingEnabled = True
        Me.ComboBoxhoraIn.Location = New System.Drawing.Point(944, 584)
        Me.ComboBoxhoraIn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxhoraIn.Name = "ComboBoxhoraIn"
        Me.ComboBoxhoraIn.Size = New System.Drawing.Size(143, 24)
        Me.ComboBoxhoraIn.TabIndex = 5
        '
        'ComboBoxhoraFi
        '
        Me.ComboBoxhoraFi.FormattingEnabled = True
        Me.ComboBoxhoraFi.Location = New System.Drawing.Point(1121, 584)
        Me.ComboBoxhoraFi.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxhoraFi.Name = "ComboBoxhoraFi"
        Me.ComboBoxhoraFi.Size = New System.Drawing.Size(143, 24)
        Me.ComboBoxhoraFi.TabIndex = 6
        '
        'ButtonAssignarDisponibilitat
        '
        Me.ButtonAssignarDisponibilitat.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonAssignarDisponibilitat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ButtonAssignarDisponibilitat.Location = New System.Drawing.Point(900, 689)
        Me.ButtonAssignarDisponibilitat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButtonAssignarDisponibilitat.Name = "ButtonAssignarDisponibilitat"
        Me.ButtonAssignarDisponibilitat.Size = New System.Drawing.Size(228, 130)
        Me.ButtonAssignarDisponibilitat.TabIndex = 7
        Me.ButtonAssignarDisponibilitat.Text = "Afegir Disponibilitat"
        Me.ButtonAssignarDisponibilitat.UseVisualStyleBackColor = False
        '
        'DataGridViewDisponibilitat
        '
        Me.DataGridViewDisponibilitat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDisponibilitat.Location = New System.Drawing.Point(326, 584)
        Me.DataGridViewDisponibilitat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewDisponibilitat.Name = "DataGridViewDisponibilitat"
        Me.DataGridViewDisponibilitat.RowHeadersWidth = 62
        Me.DataGridViewDisponibilitat.RowTemplate.Height = 28
        Me.DataGridViewDisponibilitat.Size = New System.Drawing.Size(380, 248)
        Me.DataGridViewDisponibilitat.TabIndex = 8
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuProjecteToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1902, 39)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuProjecteToolStripMenuItem
        '
        Me.MenuProjecteToolStripMenuItem.AutoSize = False
        Me.MenuProjecteToolStripMenuItem.BackgroundImage = Global.voluntariaaat.My.Resources.Resources.flechaatras
        Me.MenuProjecteToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuProjecteToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 30.0!)
        Me.MenuProjecteToolStripMenuItem.Name = "MenuProjecteToolStripMenuItem"
        Me.MenuProjecteToolStripMenuItem.Size = New System.Drawing.Size(45, 35)
        '
        'FormDisponbilitatIAssignacions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1902, 1033)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DataGridViewDisponibilitat)
        Me.Controls.Add(Me.ButtonAssignarDisponibilitat)
        Me.Controls.Add(Me.ComboBoxhoraFi)
        Me.Controls.Add(Me.ComboBoxhoraIn)
        Me.Controls.Add(Me.ComboBoxdia)
        Me.Controls.Add(Me.ButtonAssignar)
        Me.Controls.Add(Me.TextBoxVoluntari)
        Me.Controls.Add(Me.ComboBoxProjecte)
        Me.Controls.Add(Me.DataGridViewVoluntaris)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormDisponbilitatIAssignacions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridViewVoluntaris, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewDisponibilitat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridViewVoluntaris As DataGridView
    Friend WithEvents ComboBoxProjecte As ComboBox
    Friend WithEvents TextBoxVoluntari As TextBox
    Friend WithEvents ButtonAssignar As Button
    Friend WithEvents ComboBoxdia As ComboBox
    Friend WithEvents ComboBoxhoraIn As ComboBox
    Friend WithEvents ComboBoxhoraFi As ComboBox
    Friend WithEvents ButtonAssignarDisponibilitat As Button
    Friend WithEvents DataGridViewDisponibilitat As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuProjecteToolStripMenuItem As ToolStripMenuItem
End Class
