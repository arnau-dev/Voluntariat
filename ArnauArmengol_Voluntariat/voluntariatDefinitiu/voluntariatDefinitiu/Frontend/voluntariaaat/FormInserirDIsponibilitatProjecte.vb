Imports System.Data.SqlClient

Public Class FormInserirDIsponibilitatProjecte
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llenar ComboBox1 con todos los días de DisponibilitatProjecte
        CarregarDiaCombobox1()
        CarregarHoraIniciCombobox2()
        CarregarHoraFiCombobox3()

        LoadProjecteNomDataGridView()
    End Sub

    Private Sub CarregarDiaCombobox1()
        ' Lista de los días de la semana en catalán
        Dim diasSemana As New List(Of String) From {"Dilluns", "Dimarts", "Dimecres", "Dijous", "Divendres", "Dissabte", "Diumenge"}

        ' Limpiar el ComboBox antes de cargar los nuevos datos
        ComboBox1.Items.Clear()

        ' Agregar los días al ComboBox1
        For Each dia As String In diasSemana
            ComboBox1.Items.Add(dia)
        Next

        ' Obtener el día seleccionado antes de limpiar el ComboBox
        Dim selectedDay As String = If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedItem.ToString(), Nothing)

        ' Mantener la selección del día si aún está en la lista
        If Not String.IsNullOrEmpty(selectedDay) AndAlso ComboBox1.Items.Contains(selectedDay) Then
            ComboBox1.SelectedItem = selectedDay
        End If
    End Sub

    Private Sub CarregarHoraIniciCombobox2()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT hora_inici FROM DisponibilitatProjecte WHERE hora_inici IN ('07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00', '00:00')"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Limpiar el ComboBox antes de cargar los nuevos datos
                ComboBox2.Items.Clear()

                ' Leer cada fila y agregar la hora de inicio al ComboBox
                While reader.Read()
                    ComboBox2.Items.Add(reader("hora_inici").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar las horas de inicio: " & ex.Message)
        End Try
    End Sub

    Private Sub CarregarHoraFiCombobox3()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT hora_fi FROM DisponibilitatProjecte WHERE hora_fi IN ('07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00', '00:00')"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Limpiar el ComboBox antes de cargar los nuevos datos
                ComboBox3.Items.Clear()

                ' Leer cada fila y agregar la hora de fin al ComboBox
                While reader.Read()
                    ComboBox3.Items.Add(reader("hora_fi").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar las horas de fin: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim proyectoSeleccionado As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()

            ' Obtener los valores seleccionados en los ComboBox
            Dim dia As String = ComboBox1.SelectedItem.ToString()
            Dim horaInicio As String = ComboBox2.SelectedItem.ToString()
            Dim horaFin As String = ComboBox3.SelectedItem.ToString()

            ' Insertar en la tabla DisponibilitatProjecte
            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()
                    Dim query As String = "INSERT INTO DisponibilitatProjecte (Projecte_nom, dia, hora_inici, hora_fi) VALUES (@Projecte_nom, @dia, @hora_inici, @hora_fi)"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Projecte_nom", proyectoSeleccionado)
                    command.Parameters.AddWithValue("@dia", dia)
                    command.Parameters.AddWithValue("@hora_inici", horaInicio)
                    command.Parameters.AddWithValue("@hora_fi", horaFin)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Disponibilidad agregada correctamente.")

                    ' Después de insertar, recargar los días en ComboBox1
                    CarregarDiaCombobox1()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al insertar disponibilidad: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Seleccione un proyecto primero.")
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        ' Cuando cambia la selección en DataGridView1, mostrar información de disponibilidad en DataGridView2
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim proyectoSeleccionado As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()

            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()
                    Dim query As String = "SELECT dia, hora_inici, hora_fi FROM DisponibilitatProjecte WHERE Projecte_nom = @Projecte_nom"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Projecte_nom", proyectoSeleccionado)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    DataGridView2.DataSource = dataTable
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al cargar la disponibilidad del proyecto: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox2.SelectedItem IsNot Nothing AndAlso ComboBox3.SelectedItem IsNot Nothing Then
                Dim proyectoSeleccionado As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()
                Dim diaOriginal As String = DataGridView2.SelectedRows(0).Cells("dia").Value.ToString()
                Dim diaNuevo As String = ComboBox1.SelectedItem.ToString()
                Dim horaInicio As String = ComboBox2.SelectedItem.ToString()
                Dim horaFin As String = ComboBox3.SelectedItem.ToString()

                ' Realizar el update en la tabla DisponibilitatProjecte
                Try
                    Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                        connection.Open()
                        Dim query As String = "UPDATE DisponibilitatProjecte SET dia = @dia_nuevo, hora_inici = @hora_inici, hora_fi = @hora_fi WHERE Projecte_nom = @Projecte_nom AND dia = @dia_original"
                        Dim command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@dia_nuevo", diaNuevo)
                        command.Parameters.AddWithValue("@hora_inici", horaInicio)
                        command.Parameters.AddWithValue("@hora_fi", horaFin)
                        command.Parameters.AddWithValue("@Projecte_nom", proyectoSeleccionado)
                        command.Parameters.AddWithValue("@dia_original", diaOriginal)
                        command.ExecuteNonQuery()

                        MessageBox.Show("Disponibilidad actualizada correctamente.")

                        ' Después de actualizar, recargar los días en ComboBox1
                        CarregarDiaCombobox1()

                        ' Actualizar DataGridView2
                        DataGridView1_SelectionChanged(Nothing, Nothing)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar la disponibilidad: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Seleccione un día, hora de inicio y hora de fin primero.")
            End If
        Else
            MessageBox.Show("Seleccione una fila en la tabla de disponibilidad primero.")
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            Dim proyectoSeleccionado As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()
            Dim diaSeleccionado As String = DataGridView2.SelectedRows(0).Cells("dia").Value.ToString()

            ' Eliminar la disponibilidad del proyecto para el día seleccionado
            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()
                    Dim query As String = "DELETE FROM DisponibilitatProjecte WHERE Projecte_nom = @Projecte_nom AND dia = @dia"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Projecte_nom", proyectoSeleccionado)
                    command.Parameters.AddWithValue("@dia", diaSeleccionado)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Disponibilidad eliminada correctamente.")

                    ' Actualizar DataGridView2
                    DataGridView1_SelectionChanged(Nothing, Nothing)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al eliminar la disponibilidad: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Seleccione una fila en la tabla de disponibilidad primero.")
        End If
    End Sub

    Private Sub LoadProjecteNomDataGridView()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT Projecte_nom FROM Projecte"
                Dim adapter As New SqlDataAdapter(query, connection)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)

                DataGridView1.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los proyectos: " & ex.Message)
        End Try
    End Sub


End Class
