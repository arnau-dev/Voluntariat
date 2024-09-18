Imports System.Data.SqlClient

Public Class FormConsultarProjecte
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        seleccionarProjecte()
    End Sub

    Private Sub seleccionarProjecte()
        Try

            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                Dim consulta As String = "select * FROM Projecte"

                Using adaptador As New SqlDataAdapter(consulta, connexio)
                    Dim dataSet As New DataSet()

                    adaptador.Fill(dataSet, "Projecte")

                    DataGridView1.DataSource = dataSet.Tables("Projecte")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar els projectes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim menuProjecte As New FormEliminarProjecte
        menuProjecte.Show()
        Me.Close()
    End Sub

    Private Sub CrearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearToolStripMenuItem.Click
        Dim crear As New FormInserirProjecte
        crear.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        Dim mode As New FormModificiarProjecte
        mode.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim menuprojecte As New FormMenuProjecte
        menuprojecte.Show()
        Me.Close()
    End Sub
End Class
