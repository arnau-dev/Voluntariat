<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReportBaixes
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
        Me.DataGridViewInformes = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewInformes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewInformes
        '
        Me.DataGridViewInformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewInformes.Location = New System.Drawing.Point(83, 23)
        Me.DataGridViewInformes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DataGridViewInformes.Name = "DataGridViewInformes"
        Me.DataGridViewInformes.RowHeadersWidth = 62
        Me.DataGridViewInformes.RowTemplate.Height = 28
        Me.DataGridViewInformes.Size = New System.Drawing.Size(514, 303)
        Me.DataGridViewInformes.TabIndex = 0
        '
        'FormReportBaixes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(97, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(711, 360)
        Me.Controls.Add(Me.DataGridViewInformes)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormReportBaixes"
        Me.Text = "FormReportBaixes"
        CType(Me.DataGridViewInformes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridViewInformes As DataGridView
End Class
