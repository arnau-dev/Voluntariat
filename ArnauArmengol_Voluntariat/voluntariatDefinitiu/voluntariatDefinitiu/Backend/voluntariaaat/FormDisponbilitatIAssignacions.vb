Imports System.Data.SqlClient

Public Class FormDisponbilitatIAssignacions

    Private Sub FormDisponbilitatIAssignacions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProjectes()

        CargarVoluntaris()

        CarregarDiaComboboxdia()
        CarregarHoraIniciComboboxhoraIn()
        CarregarHoraFiComboboxhoraFi()

    End Sub



    Private Sub DataGridViewVoluntaris_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewVoluntaris.SelectionChanged
        MostrarNIFVoluntari()

        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtener el NIF del voluntario seleccionado en el DataGridViewVoluntaris
            Dim nif As String = DataGridViewVoluntaris.SelectedRows(0).Cells("nif").Value.ToString()

            ' Llamar a la función para consultar la disponibilidad según el NIF
            ConsultarDisponibilitatPerNIF(nif)
        End If
    End Sub

    Private Sub CargarVoluntaris()
        ' Consulta SQL para obtener los voluntarios disponibles
        Dim query As String = "SELECT nif, nom, cognoms FROM Voluntari WHERE actiu = 1 AND assegurat = 1"

        ' Conexión a la base de datos
        Using connexio As SqlConnection = ObtindreConexio()
            ' Comando SQL para ejecutar la consulta
            Using command As New SqlCommand(query, connexio)
                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    ' Abrir la conexión y llenar el DataTable con los resultados de la consulta
                    connexio.Open()
                    adapter.Fill(dataTable)

                    ' Asignar el DataTable como origen de datos del DataGridView
                    DataGridViewVoluntaris.DataSource = dataTable
                Catch ex As Exception
                    ' Manejar errores de consulta
                    MessageBox.Show("Error al cargar voluntarios: " & ex.Message)
                Finally
                    ' Cerrar la conexión
                    connexio.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub CargarProjectes()
        ' Consulta SQL para obtener los proyectos disponibles
        Dim query As String = "SELECT Projecte_nom FROM Projecte"

        ' Conexión a la base de datos
        Using connexio As SqlConnection = ObtindreConexio()
            ' Comando SQL para ejecutar la consulta
            Using command As New SqlCommand(query, connexio)
                Dim reader As SqlDataReader

                Try
                    ' Abrir la conexión
                    connexio.Open()
                    ' Ejecutar la consulta y obtener los resultados en un lector de datos
                    reader = command.ExecuteReader()

                    ' Limpiar la lista desplegable de proyectos antes de cargar nuevos datos
                    ComboBoxProjecte.Items.Clear()

                    ' Leer cada fila del resultado y agregar el nombre del proyecto a la lista desplegable
                    While reader.Read()
                        ComboBoxProjecte.Items.Add(reader("Projecte_nom").ToString())
                    End While

                    ' Seleccionar el primer proyecto por defecto
                    If ComboBoxProjecte.Items.Count > 0 Then
                        ComboBoxProjecte.SelectedIndex = 0
                    End If
                Catch ex As Exception
                    ' Manejar errores de consulta
                    MessageBox.Show("Error al cargar proyectos: " & ex.Message)
                Finally
                    ' Cerrar el lector de datos y la conexión
                    If Not reader Is Nothing Then reader.Close()
                    connexio.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub AsignarVoluntarisAProjecte(proyecto As String, voluntarios As List(Of String))
        ' Verificar si hay algún voluntario seleccionado
        If voluntarios.Count > 0 Then
            Try
                ' Abrir una conexión a la base de datos
                Using connexio As SqlConnection = ObtindreConexio()
                    connexio.Open()

                    ' Iniciar una transacción para asegurar la atomicidad de las operaciones
                    Using transaction As SqlTransaction = connexio.BeginTransaction()
                        Try
                            ' Iterar sobre la lista de voluntarios seleccionados
                            For Each voluntario As String In voluntarios
                                ' Construir la consulta SQL para insertar la asignación del voluntario al proyecto
                                Dim query As String = "INSERT INTO Assignacio_Voluntari_Projecte (Projecte_nom, nif) VALUES (@proyecto, @nifVoluntario)"
                                ' Crear un comando SQL con la consulta y la conexión
                                Using command As New SqlCommand(query, connexio, transaction)
                                    ' Asignar los parámetros de la consulta
                                    command.Parameters.AddWithValue("@proyecto", proyecto)
                                    command.Parameters.AddWithValue("@nifVoluntario", voluntario)
                                    ' Ejecutar la consulta
                                    command.ExecuteNonQuery()
                                End Using
                            Next

                            ' Commit para confirmar la transacción
                            transaction.Commit()

                            ' Mostrar un mensaje de éxito
                            MessageBox.Show("Voluntaris asignats al projecte correctamente.")
                        Catch ex As Exception
                            ' Rollback en caso de error
                            transaction.Rollback()
                            ' Mostrar un mensaje de error
                            MessageBox.Show("Error al asignar voluntarios al projecte: " & ex.Message)
                        End Try
                    End Using
                End Using
            Catch ex As Exception
                ' Mostrar un mensaje de error en caso de problemas de conexión
                MessageBox.Show("Error al conectar a la base de dades: " & ex.Message)
            End Try
        Else
            ' Mostrar un mensaje de error si no se ha seleccionado ningún voluntario
            MessageBox.Show("Siusplau, selecciona al menys un voluntari per assignar al projecte.")
        End If
    End Sub

    Private Sub MostrarNIFVoluntari()
        ' Verificar si hay al menos una fila seleccionada en el DataGridView
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtener la fila seleccionada
            Dim selectedRow As DataGridViewRow = DataGridViewVoluntaris.SelectedRows(0)

            ' Verificar si la celda de NIF no es nula
            If selectedRow.Cells("NIF").Value IsNot Nothing Then
                ' Obtener el valor del NIF del voluntario seleccionado
                Dim nif As String = selectedRow.Cells("NIF").Value.ToString()

                ' Asignar el valor del NIF al TextBoxVoluntario
                TextBoxVoluntari.Text = nif
            End If
        Else
            ' Si no hay ninguna fila seleccionada, limpiar el TextBox
            TextBoxVoluntari.Clear()
        End If
    End Sub

    Private Sub ButtonAssignar_Click(sender As Object, e As EventArgs) Handles ButtonAssignar.Click
        Dim projecte As String = ComboBoxProjecte.SelectedItem.ToString()

        ' Obtener los NIF de los voluntarios seleccionados en el DataGridView
        Dim nifsSeleccionats As New List(Of String)()
        For Each row As DataGridViewRow In DataGridViewVoluntaris.SelectedRows
            nifsSeleccionats.Add(row.Cells("nif").Value.ToString())
        Next

        ' Asignar los voluntarios seleccionados al proyecto
        AsignarVoluntarisAProjecte(projecte, nifsSeleccionats)
    End Sub

    Private Sub CarregarDiaComboboxdia()
        ' Lista de los días de la semana en catalán
        Dim diasSemana As New List(Of String) From {"Dilluns", "Dimarts", "Dimecres", "Dijous", "Divendres", "Dissabte", "Diumenge"}

        ' Limpiar el ComboBox antes de cargar los nuevos datos
        ComboBoxdia.Items.Clear()

        ' Agregar los días alComboBoxdia
        For Each dia As String In diasSemana
            ComboBoxdia.Items.Add(dia)
        Next

        ' Obtener el día seleccionado antes de limpiar el ComboBox
        Dim selectedDay As String = If(ComboBoxdia.SelectedItem IsNot Nothing, ComboBoxdia.SelectedItem.ToString(), Nothing)

        ' Mantener la selección del día si aún está en la lista
        If Not String.IsNullOrEmpty(selectedDay) AndAlso ComboBoxdia.Items.Contains(selectedDay) Then
            ComboBoxdia.SelectedItem = selectedDay
        End If
    End Sub

    Private Sub CarregarHoraIniciComboboxhoraIn()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT disponibilitat_INCIAL FROM Disponibilitat WHERE disponibilitat_INCIAL IN ('07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00', '00:00')"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Limpiar el ComboBox antes de cargar los nuevos datos
                ComboBoxhoraIn.Items.Clear()

                ' Leer cada fila y agregar la hora de inicio al ComboBox
                While reader.Read()
                    ComboBoxhoraIn.Items.Add(reader("disponibilitat_INCIAL").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar las horas de inicio: " & ex.Message)
        End Try
    End Sub

    Private Sub CarregarHoraFiComboboxhoraFi()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT disponibilitat_FINAL FROM Disponibilitat WHERE disponibilitat_FINAL IN ('07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00', '00:00')"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Limpiar el ComboBox antes de cargar los nuevos datos
                ComboBoxhoraFi.Items.Clear()

                ' Leer cada fila y agregar la hora de fin al ComboBox
                While reader.Read()
                    ComboBoxhoraFi.Items.Add(reader("disponibilitat_FINAL").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar las horas de fin: " & ex.Message)
        End Try
    End Sub

    Private Sub AgregarDisponibilitat()
        ' Obtener el NIF del voluntario seleccionado en el DataGridView
        Dim nifVoluntari As String = DataGridViewVoluntaris.CurrentRow.Cells("nif").Value.ToString()

        ' Obtener el día, hora de inicio y hora final de los ComboBox
        Dim dia As String = ComboBoxdia.SelectedItem.ToString()
        Dim horaInici As String = ComboBoxhoraIn.SelectedItem.ToString()
        Dim horaFinal As String = ComboBoxhoraFi.SelectedItem.ToString()

        ' Consulta SQL para insertar la disponibilidad en la tabla Disponibilidad
        Dim query As String = "INSERT INTO Disponibilitat (nif, dia, disponibilitat_INCIAL, disponibilitat_FINAL) VALUES (@nif, @dia, @horaInici, @horaFinal)"

        ' Crear una conexión a la base de datos y un comando SQL
        Using connexio As SqlConnection = ObtindreConexio()

            Using command As New SqlCommand(query, connexio)
                ' Agregar parámetros a la consulta SQL
                command.Parameters.AddWithValue("@nif", nifVoluntari)
                command.Parameters.AddWithValue("@dia", dia)
                command.Parameters.AddWithValue("@horaInici", horaInici)
                command.Parameters.AddWithValue("@horaFinal", horaFinal)


                Try
                    ' Abrir la conexión
                    connexio.Open()
                    ' Ejecutar la consulta SQL
                    command.ExecuteNonQuery()

                    ConsultarDisponibilitatPerNIF(nifVoluntari)

                    MessageBox.Show("Disponibilidad agregada correctamente.")
                Catch ex As Exception
                    MessageBox.Show("Error al agregar la disponibilidad: " & ex.Message)
                End Try
            End Using
        End Using


    End Sub


    Private Sub ConsultarDisponibilitatPerNIF(ByVal nif As String)
        ' Consulta SQL para seleccionar la disponibilidad según el NIF
        Dim query As String = "SELECT dia, disponibilitat_INCIAL, disponibilitat_FINAL FROM Disponibilitat WHERE nif = @nif"

        ' Crear una conexión a la base de datos y un comando SQL
        Using connection As SqlConnection = ObtindreConexio()

            Using command As New SqlCommand(query, connection)
                ' Agregar el parámetro del NIF a la consulta SQL
                command.Parameters.AddWithValue("@nif", nif)

                Try
                    ' Abrir la conexión
                    connection.Open()

                    ' Crear un DataTable para almacenar los resultados de la consulta
                    Dim dataTable As New DataTable()

                    ' Ejecutar la consulta SQL y llenar el DataTable con los resultados
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable)
                    End Using

                    ' Mostrar los resultados en un DataGridView u otro control de tu elección
                    DataGridViewDisponibilitat.DataSource = dataTable
                Catch ex As Exception
                    MessageBox.Show("Error al consultar la disponibilidad: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub ButtonAssignarDisponibilitat_Click(sender As Object, e As EventArgs) Handles ButtonAssignarDisponibilitat.Click
        AgregarDisponibilitat()
    End Sub

    Private Sub MenuProjecteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuProjecteToolStripMenuItem.Click
        Dim menuprojecte As New FormMenuDisponibilitat
        menuprojecte.Show()
        Me.Close()
    End Sub
End Class