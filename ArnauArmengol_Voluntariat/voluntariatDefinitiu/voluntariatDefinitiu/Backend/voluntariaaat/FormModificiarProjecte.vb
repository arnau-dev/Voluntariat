Imports System.Data.SqlClient
Imports System.Drawing

Public Class FormModificiarProjecte
    'nom original del projecte seleccionat
    Private nomProjecteSeleccionat As String

    ' Diccionario para almacenar los colores de las filas
    Private rowColors As New Dictionary(Of DataGridViewRow, Color)()

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar los estados en el ComboBox al cargar el formulario
        LoadEstats()

        ' Cargar los proyectos en el DataGridView y aplicar colores
        SelectProjecteWithFormatting()

        ' Aplicar colores a las filas del DataGridView
        ApplyRowColors()

        LoadAmbits()
    End Sub

    Private Sub LoadEstats()
        Try
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                Dim sqlEstats As String = "SELECT nom_estat FROM EstatProjecte"

                Using cmdEstats As New SqlCommand(sqlEstats, connexio)
                    Using reader As SqlDataReader = cmdEstats.ExecuteReader()
                        ComboBox1.Items.Clear()
                        While reader.Read()
                            Dim estat As String = reader("nom_estat").ToString()
                            ComboBox1.Items.Add(estat)
                            Debug.WriteLine("Estado del proyecto cargado: " & estat) ' Agregar para depuración
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los estados: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAmbits()
        Try
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                Dim sqlAmbits As String = "SELECT Ambit_nom FROM Ambit"

                Using cmdAmbits As New SqlCommand(sqlAmbits, connexio)
                    Using reader As SqlDataReader = cmdAmbits.ExecuteReader()
                        ComboBox2.Items.Clear()
                        While reader.Read()
                            Dim ambit As String = reader("Ambit_nom").ToString()
                            ComboBox2.Items.Add(ambit)
                            Debug.WriteLine("Ámbito del proyecto cargado: " & ambit) ' Agregar para depuración
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los ámbitos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SelectProjecteWithFormatting()
        Try
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                Dim query As String = "SELECT Projecte_nom, deficinicio, data_inici_projecte, data_fi_projecte, lloc, nombre_voluntaris, dedicacio_necessaria, nom_estat, Ambit_nom, continuitat, coordinador FROM Projecte"

                Using adapter As New SqlDataAdapter(query, connexio)
                    Dim dataSet As New DataSet()
                    adapter.Fill(dataSet, "Projecte")

                    ' Establecer el origen de datos del DataGridView
                    DataGridView1.DataSource = dataSet.Tables("Projecte")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim selectedDataRow As DataRow = DirectCast(selectedRow.DataBoundItem, DataRowView).Row

            TextBox1.Text = selectedDataRow("Projecte_nom").ToString()
            TextBox2.Text = selectedDataRow("deficinicio").ToString()
            TextBox3.Text = selectedDataRow("lloc").ToString()
            TextBox4.Text = selectedDataRow("nombre_voluntaris").ToString()
            TextBox5.Text = selectedDataRow("dedicacio_necessaria").ToString()
            ComboBox1.Text = selectedDataRow("nom_estat").ToString()
            ComboBox2.Text = selectedDataRow("Ambit_nom").ToString()

            MonthCalendar1.SelectionStart = Convert.ToDateTime(selectedDataRow("data_inici_projecte"))
            MonthCalendar2.SelectionEnd = Convert.ToDateTime(selectedDataRow("data_fi_projecte"))

            ' Guardar el nombre del proyecto original seleccionado
            nomProjecteSeleccionat = selectedDataRow("Projecte_nom").ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Try
                Using connexio As SqlConnection = ObtindreConexio()
                    connexio.Open()

                    Dim query As String = "UPDATE Projecte SET Projecte_nom = @Projecte_nom, deficinicio = @deficinicio, data_inici_projecte = @data_inici_projecte, data_fi_projecte = @data_fi_projecte, lloc = @lloc, nombre_voluntaris = @nombre_voluntaris, dedicacio_necessaria = @dedicacio_necessaria, nom_estat = @nom_estat, Ambit_nom = @Ambit_nom, continuitat = @continuitat, coordinador = @coordinador WHERE Projecte_nom = @Old_Projecte_nom"

                    Using cmd As New SqlCommand(query, connexio)
                        cmd.Parameters.AddWithValue("@Old_Projecte_nom", nomProjecteSeleccionat)

                        cmd.Parameters.AddWithValue("@Projecte_nom", TextBox1.Text)
                        cmd.Parameters.AddWithValue("@deficinicio", TextBox2.Text)
                        cmd.Parameters.AddWithValue("@data_inici_projecte", MonthCalendar1.SelectionStart)
                        cmd.Parameters.AddWithValue("@data_fi_projecte", MonthCalendar2.SelectionEnd)
                        cmd.Parameters.AddWithValue("@lloc", TextBox3.Text)
                        cmd.Parameters.AddWithValue("@nombre_voluntaris", TextBox4.Text)
                        cmd.Parameters.AddWithValue("@dedicacio_necessaria", TextBox5.Text)
                        cmd.Parameters.AddWithValue("@nom_estat", ComboBox1.Text)
                        cmd.Parameters.AddWithValue("@Ambit_nom", ComboBox2.Text)

                        ' Establecer el estado de continuidad según el RadioButton seleccionado
                        Dim continuidadProyecto As String
                        If RadioButton1.Checked Then
                            continuidadProyecto = "Sí"
                        ElseIf RadioButton2.Checked Then
                            continuidadProyecto = "No"
                        Else
                            MessageBox.Show("Si us plau, selecciona si el projecte té continuïtat o no.")
                            Return
                        End If
                        cmd.Parameters.AddWithValue("@continuitat", continuidadProyecto)

                        ' Obtener el valor del coordinador del TextBox6
                        cmd.Parameters.AddWithValue("@coordinador", TextBox6.Text)

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Projecte actualitzat correctament.", "Actualiztat", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ' Actualizar
                            SelectProjecteWithFormatting() ' Actualizar con colores
                            ApplyRowColors() ' Actualizar colores después de la actualización
                        Else
                            MessageBox.Show("No s'ha trobat el projecte amb el nom especificat.", "Error d'actualització", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al actualitzar projecte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Si us plau, selecciona un projecte per modificar.", "Selecció requerida", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub ApplyRowColors()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then ' Verificar que no sea una fila nueva
                Dim cell As DataGridViewCell = row.Cells("nom_estat")
                If cell.Value IsNot Nothing AndAlso Not cell.Value Is DBNull.Value Then
                    Dim estado As String = cell.Value.ToString()
                    If estado = "En vigor" Then
                        row.DefaultCellStyle.ForeColor = Color.Green
                    ElseIf estado = "pendent de realitzar" Then
                        row.DefaultCellStyle.ForeColor = Color.Yellow
                    ElseIf estado = "descartat" OrElse estado = "finalitzat" Then
                        row.DefaultCellStyle.ForeColor = Color.Red
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Form5_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Al cargar el formulario, asegurarse de que los colores se apliquen también
        ApplyRowColors()
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
        Dim Eliminar As New FormEliminarProjecte()
        Eliminar.Show()
        Me.Close()
    End Sub

    Private Sub InserirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirToolStripMenuItem.Click
        Dim Inserir As New FormInserirProjecte()
        Inserir.Show()
        Me.Close()
    End Sub
End Class
