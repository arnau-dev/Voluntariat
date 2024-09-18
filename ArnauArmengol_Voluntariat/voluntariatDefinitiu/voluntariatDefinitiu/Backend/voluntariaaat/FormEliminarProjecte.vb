Imports System.Data.SqlClient

Public Class FormEliminarProjecte
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatosDataGridView()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim projecteNom As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()

            Dim result As DialogResult = MessageBox.Show("Estas segur de que vols eliminar el projecte seleccionat?", "Confirmar Eliminació", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                EliminarProyecto(projecteNom)
            End If
        Else
            MessageBox.Show("Si us plau, selecciona un projecte per eliminar.", "Selecció requerida", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub CargarDatosDataGridView()
        Try
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                Dim query As String = "SELECT * FROM Projecte"

                Using adapter As New SqlDataAdapter(query, connexio)
                    Dim dataSet As New DataSet()
                    adapter.Fill(dataSet, "Projecte")

                    DataGridView1.DataSource = dataSet.Tables("Projecte")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar dades: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EliminarProyecto(projecteNom As String)
        Try
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                Dim query As String = "DELETE FROM Projecte WHERE Projecte_nom = @Projecte_nom"

                Using cmd As New SqlCommand(query, connexio)
                    cmd.Parameters.AddWithValue("@Projecte_nom", projecteNom)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Projecte eliminat correctament.", "Eliminat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CargarDatosDataGridView()
                    Else
                        MessageBox.Show("No sa trobat el projecte amb el nom especificat.", "Error d'eliminació", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al eliminar projecte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim Iniciprojecte As New FormMenuProjecte()
        Iniciprojecte.Show()
        Me.Close()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim Consultar As New FormConsultarProjecte()
        Consultar.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        Dim Modificar As New FormModificiarProjecte()
        Modificar.Show()
        Me.Close()
    End Sub

    Private Sub InserirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirToolStripMenuItem.Click
        Dim Inserir As New FormInserirProjecte()
        Inserir.Show()
        Me.Close()
    End Sub
End Class