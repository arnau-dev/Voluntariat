<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenuDisponibilitat
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
        Me.PictureBoxVoluntari = New System.Windows.Forms.PictureBox()
        Me.PictureBoxProjecte = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxVoluntari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxProjecte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxVoluntari
        '
        Me.PictureBoxVoluntari.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxVoluntari.Location = New System.Drawing.Point(913, 298)
        Me.PictureBoxVoluntari.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBoxVoluntari.Name = "PictureBoxVoluntari"
        Me.PictureBoxVoluntari.Size = New System.Drawing.Size(683, 90)
        Me.PictureBoxVoluntari.TabIndex = 0
        Me.PictureBoxVoluntari.TabStop = False
        '
        'PictureBoxProjecte
        '
        Me.PictureBoxProjecte.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxProjecte.Location = New System.Drawing.Point(904, 497)
        Me.PictureBoxProjecte.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBoxProjecte.Name = "PictureBoxProjecte"
        Me.PictureBoxProjecte.Size = New System.Drawing.Size(692, 90)
        Me.PictureBoxProjecte.TabIndex = 1
        Me.PictureBoxProjecte.TabStop = False
        '
        'FormMenuDisponibilitat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.voluntariaaat.My.Resources.Resources.MenuDisponibilitat
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1902, 1033)
        Me.Controls.Add(Me.PictureBoxProjecte)
        Me.Controls.Add(Me.PictureBoxVoluntari)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormMenuDisponibilitat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMenuDisponibilitat"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBoxVoluntari, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxProjecte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBoxVoluntari As PictureBox
    Friend WithEvents PictureBoxProjecte As PictureBox
End Class
