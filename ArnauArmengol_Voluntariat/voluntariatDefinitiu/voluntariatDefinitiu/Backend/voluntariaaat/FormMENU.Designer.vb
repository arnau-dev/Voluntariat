<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMENU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMENU))
        Me.PictureBox_Voluntaris = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Projectes = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Disponibilitat = New System.Windows.Forms.PictureBox()
        Me.PictureBox_Assignacions = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox_Voluntaris, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Projectes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Disponibilitat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox_Assignacions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_Voluntaris
        '
        Me.PictureBox_Voluntaris.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Voluntaris.Location = New System.Drawing.Point(57, 117)
        Me.PictureBox_Voluntaris.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox_Voluntaris.Name = "PictureBox_Voluntaris"
        Me.PictureBox_Voluntaris.Size = New System.Drawing.Size(384, 644)
        Me.PictureBox_Voluntaris.TabIndex = 0
        Me.PictureBox_Voluntaris.TabStop = False
        '
        'PictureBox_Projectes
        '
        Me.PictureBox_Projectes.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Projectes.Location = New System.Drawing.Point(521, 108)
        Me.PictureBox_Projectes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox_Projectes.Name = "PictureBox_Projectes"
        Me.PictureBox_Projectes.Size = New System.Drawing.Size(387, 668)
        Me.PictureBox_Projectes.TabIndex = 1
        Me.PictureBox_Projectes.TabStop = False
        '
        'PictureBox_Disponibilitat
        '
        Me.PictureBox_Disponibilitat.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Disponibilitat.Location = New System.Drawing.Point(986, 117)
        Me.PictureBox_Disponibilitat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox_Disponibilitat.Name = "PictureBox_Disponibilitat"
        Me.PictureBox_Disponibilitat.Size = New System.Drawing.Size(367, 659)
        Me.PictureBox_Disponibilitat.TabIndex = 2
        Me.PictureBox_Disponibilitat.TabStop = False
        '
        'PictureBox_Assignacions
        '
        Me.PictureBox_Assignacions.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_Assignacions.Location = New System.Drawing.Point(1457, 95)
        Me.PictureBox_Assignacions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox_Assignacions.Name = "PictureBox_Assignacions"
        Me.PictureBox_Assignacions.Size = New System.Drawing.Size(365, 696)
        Me.PictureBox_Assignacions.TabIndex = 3
        Me.PictureBox_Assignacions.TabStop = False
        '
        'FormMENU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1902, 1033)
        Me.Controls.Add(Me.PictureBox_Assignacions)
        Me.Controls.Add(Me.PictureBox_Disponibilitat)
        Me.Controls.Add(Me.PictureBox_Projectes)
        Me.Controls.Add(Me.PictureBox_Voluntaris)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormMENU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox_Voluntaris, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Projectes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Disponibilitat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox_Assignacions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox_Voluntaris As PictureBox
    Friend WithEvents PictureBox_Projectes As PictureBox
    Friend WithEvents PictureBox_Disponibilitat As PictureBox
    Friend WithEvents PictureBox_Assignacions As PictureBox
End Class
