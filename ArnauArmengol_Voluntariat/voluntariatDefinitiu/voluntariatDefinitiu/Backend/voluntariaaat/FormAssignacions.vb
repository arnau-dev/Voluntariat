Imports System.Data.SqlClient

Public Class FormAssignacions
    Private Sub FormAssignacions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProjectes()
        CargarVoluntaris()
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

    Private Sub DataGridViewVoluntaris_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewVoluntaris.SelectionChanged
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            MostrarNIFVoluntari()
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

    Public Sub CargarVoluntarisNoAssignats()
        Dim query As String = "SELECT v.nif, nom, cognoms FROM Voluntari v
                               LEFT JOIN Assignacio_voluntari_projecte avp ON v.nif = avp.nif
                               WHERE v.actiu = 1 AND v.assegurat = 1 AND avp.nif IS NULL"
        Dim dataTable As New DataTable()
        Using connexio As SqlConnection = ObtindreConexio()
            Using command As New SqlCommand(query, connexio)
                Try
                    connexio.Open()
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable) ' Llenar el DataTable con los datos obtenidos de la consulta
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al consultar la base de datos: " & ex.Message)
                End Try
            End Using
        End Using

        ' Establecer el DataTable como origen de datos del DataGridView
        DataGridViewVoluntaris.DataSource = dataTable
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
                    MessageBox.Show("Error al carregar projectes: " & ex.Message)
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
                            MessageBox.Show("Error al asignar voluntaris al projecte: " & ex.Message)
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

    Private Sub MostrarVoluntarisAssignatsAProjecte()
        ' Verificar si se ha seleccionado un proyecto en el ComboBox
        If ComboBoxProjecte.SelectedIndex >= 0 Then
            ' Obtener el nombre del proyecto seleccionado
            Dim proyecto As String = ComboBoxProjecte.SelectedItem.ToString()

            ' Consulta SQL para obtener los voluntarios asignados al proyecto
            Dim query As String = "SELECT v.nif, v.nom, v.cognoms, v.correu_Electronic, v.telefon FROM Voluntari v INNER JOIN Assignacio_Voluntari_Projecte a ON v.nif = a.nif WHERE a.Projecte_nom = @proyecto"

            ' Crear una conexión a la base de datos y un adaptador de datos
            Using connexio As SqlConnection = ObtindreConexio()
                Using command As New SqlCommand(query, connexio)
                    ' Agregar el parámetro del nombre del proyecto a la consulta
                    command.Parameters.AddWithValue("@proyecto", proyecto)

                    ' Crear un DataTable para almacenar los resultados de la consulta
                    Dim dataTable As New DataTable()

                    Try
                        ' Abrir la conexión y llenar el DataTable con los resultados de la consulta
                        connexio.Open()
                        Dim adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable)

                        ' Asignar el DataTable como origen de datos del DataGridView
                        DataGridViewVoluntarisAsignats.DataSource = dataTable
                    Catch ex As Exception
                        ' Mostrar un mensaje de error si hay problemas con la consulta
                        MessageBox.Show("Error al cargar els voluntaris assignats al projecte: " & ex.Message)
                    End Try
                End Using
            End Using
        Else
            ' Mostrar un mensaje si no se ha seleccionado ningún proyecto
            MessageBox.Show("Selecciona un projecte per veure els voluntaris assignats.")
        End If

    End Sub

    Private Sub ComboBoxProjecte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxProjecte.SelectedIndexChanged
        MostrarVoluntarisAssignatsAProjecte()

        If CheckBoxAmbitVoluntari.Checked Then
            If ComboBoxProjecte.SelectedIndex >= 0 Then
                Dim ambitProjecte As String = ObtenirAmbitDelProjecte(ComboBoxProjecte.SelectedItem.ToString())
                MostrarVoluntarisSegonsAmbitDelProjecte(ambitProjecte)
            End If
        End If

        If ComboBoxProjecte.SelectedIndex >= 0 Then
            Dim projecte As String = ComboBoxProjecte.SelectedItem.ToString()

            ' Obtener el número de voluntarios asignados al proyecto
            Dim numVoluntariosAssignats As Integer = ObtenerNumeroVoluntariosAssignats(projecte)

            ' Obtener el número total de voluntarios que podrían haber en el proyecto
            Dim numTotalVoluntarios As Integer = ObtenerNumeroTotalVoluntariosProyecto(projecte)

            ' Mostrar el número de voluntarios asignados y el número total de voluntarios en el proyecto
            Label5.Text = $"{numVoluntariosAssignats} / {numTotalVoluntarios}"
        End If
    End Sub

    Private Sub EliminarVoluntariDelProjecte()
        ' Verificar si hay al menos una fila seleccionada en el DataGridView
        If DataGridViewVoluntarisAsignats.SelectedRows.Count > 0 Then
            ' Obtener el NIF del voluntario seleccionado
            Dim nif As String = DataGridViewVoluntarisAsignats.SelectedRows(0).Cells("nif").Value.ToString()

            ' Obtener el motivo de la baja del usuario
            Dim motivo As String = InputBox("Introdueix el motiu de la baixa del voluntari del projecte:", "Motiu de la baixa")

            ' Verificar si se proporcionó un motivo
            If Not String.IsNullOrWhiteSpace(motivo) Then
                ' Llamar a la función para eliminar al voluntario del proyecto
                Try
                    ' Abrir una conexión a la base de datos
                    Using conn As SqlConnection = ObtindreConexio()
                        conn.Open()

                        ' Consulta SQL para actualizar la participación del voluntario en el proyecto 'AND data_final IS NULL;
                        Dim query As String = "  DELETE FROM Assignacio_Voluntari_Projecte
                        WHERE Projecte_nom = @projecte AND nif = @nif; 

                        INSERT INTO ReportBaixaVoluntari (nif, projecte_nom, motiu_baixa)
                        VALUES (@nif, @projecte, @motiu);
                    "
                        ' Crear y configurar el comando SQL
                        Using cmd As New SqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@projecte", ComboBoxProjecte.SelectedItem.ToString())
                            cmd.Parameters.AddWithValue("@nif", nif)
                            cmd.Parameters.AddWithValue("@motiu", motivo)

                            ' Ejecutar la consulta
                            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                            ' Verificar si se actualizaron filas
                            If filasAfectadas > 0 Then
                                MessageBox.Show("Voluntari eliminat del projecte correctamente.")
                            Else
                                MessageBox.Show("No es pot eliminar al voluntari del projecte.")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    ' Mostrar un mensaje de error en caso de problemas de conexión
                    MessageBox.Show("Error al conectar a la base de dades: " & ex.Message)
                End Try
            Else
                MessageBox.Show("proporciona un motiu de baixa per al voluntari del projecte.")
            End If
        Else
            MessageBox.Show("No hi ha ningun voluntari seleccionat per a eliminar del projecte.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EliminarVoluntariDelProjecte()
    End Sub

    Private Function ObtenirReportsBaixesDelProjecte()
        Dim dataSet As New DataSet()
        ' Verificar si se ha seleccionado un proyecto en el ComboBox
        If ComboBoxProjecte.SelectedIndex >= 0 Then
            ' Obtener el nombre del proyecto seleccionado
            Dim projecte As String = ComboBoxProjecte.SelectedItem.ToString()

            ' Consulta SQL para obtener los informes de baja del proyecto seleccionado
            Dim query As String = "
            SELECT nif, data_final, motiu_baixa
            FROM ReportBaixaVoluntari
            WHERE projecte_nom = @projecte
           
        "

            ' Crear una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                ' Abrir la conexión
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Asignar el parámetro del proyecto seleccionado
                    cmd.Parameters.AddWithValue("@projecte", projecte)

                    ' Crear un adaptador de datos y llenar el DataSet con los resultados de la consulta
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dataSet, "Reports")
                    End Using
                End Using
            End Using
        Else
            MessageBox.Show("Selecciona un projecte abans de consultar els informes de baixa.")
        End If

        Return dataSet
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Crear una instancia del formulario de informes de bajas
        Dim formInformesBaixes As New FormReportBaixes()

        ' Obtener los informes de baja del proyecto seleccionado

        Dim dataSetInformes As DataSet = ObtenirReportsBaixesDelProjecte()

        ' Mostrar los informes de baja en el formulario de informes de bajas
        formInformesBaixes.MostrarInformesBaixes(dataSetInformes)
        '  Mostrar los informes de baja en el formulario de informes de bajas

        '  Mostrar el formulario de informes de bajas como una nueva pestaña
        formInformesBaixes.Show()
    End Sub

    Private Sub Button_Correus_Click(sender As Object, e As EventArgs) Handles Button_Correus.Click

        Dim formulariCorreus As New FormCorreusElectronics()

            Dim correus As New List(Of String)()

        For Each fila As DataGridViewRow In DataGridViewVoluntarisAsignats.Rows
            If fila.Cells("correu_Electronic").Value IsNot Nothing Then
                correus.Add("<" & fila.Cells("correu_Electronic").Value.ToString() & ">")
            End If
        Next
        If correus.Count > 0 Then
                formulariCorreus.Correus = "<" & String.Join(";", correus) & ">"
                formulariCorreus.Show()
            Else
                MessageBox.Show("No s'han trobat correus per a enviar.")
            End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_NoAssignats.CheckedChanged

        If RadioButton_NoAssignats.Checked Then
            CargarVoluntarisNoAssignats()
        End If
    End Sub
    Private Sub MostrarVoluntarisSegonsAmbitDelProjecte(ByVal ambitProjecte As String)
        Try
            ' Consulta SQL para obtener los voluntarios según el ámbito del proyecto seleccionado
            Dim query As String = "
            SELECT v.nif, v.nom, v.cognoms
            FROM Voluntari v
            INNER JOIN Ambit_Voluntari av ON v.nif = av.nif
            WHERE av.Ambit_nom = @ambitProjecte
        "

            ' Crear una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                ' Abrir la conexión
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Asignar el parámetro del ámbito del proyecto seleccionado
                    cmd.Parameters.AddWithValue("@ambitProjecte", ambitProjecte)

                    ' Crear un adaptador de datos y un conjunto de datos para almacenar los resultados
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim dataSet As New DataSet()

                        ' Llenar el conjunto de datos con los resultados de la consulta
                        adapter.Fill(dataSet)

                        ' Mostrar los resultados en el DataGridViewVoluntaris
                        DataGridViewVoluntaris.DataSource = dataSet.Tables(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al mostrar voluntarios según el ámbito del proyecto: " & ex.Message)
        End Try
    End Sub

    Private Function ObtenirAmbitDelProjecte(ByVal nomProjecte As String) As String
        Dim ambit As String = ""

        Try
            ' Consulta SQL para obtener el ámbito del proyecto seleccionado
            Dim query As String = "SELECT Ambit_nom FROM Projecte WHERE Projecte_nom = @nomProjecte"

            ' Crear una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                ' Abrir la conexión
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Asignar el parámetro del nombre del proyecto seleccionado
                    cmd.Parameters.AddWithValue("@nomProjecte", nomProjecte)

                    ' Ejecutar la consulta y obtener el ámbito
                    ambit = Convert.ToString(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener el ámbito del proyecto: " & ex.Message)
        End Try

        Return ambit
    End Function

    Private Sub CheckBoxAmbitVoluntari_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAmbitVoluntari.CheckedChanged
        If CheckBoxAmbitVoluntari.Checked Then
            ' Verificar si hay un proyecto seleccionado en el ComboBoxProjecte
            If ComboBoxProjecte.SelectedIndex >= 0 Then
                Dim ambitProjecte As String = ObtenirAmbitDelProjecte(ComboBoxProjecte.SelectedItem.ToString())
                MostrarVoluntarisSegonsAmbitDelProjecte(ambitProjecte)
            End If
        Else
            ' Si el checkbox no está marcado, mostrar todos los voluntarios nuevamente
            CargarVoluntaris()
        End If
    End Sub

    Private Function ObtenerNumeroVoluntariosAssignats(ByVal projecte As String) As Integer
        Dim numVoluntariosAssignats As Integer = 0

        Try
            ' Consulta SQL para obtener el número de voluntarios asignados al proyecto
            Dim query As String = "SELECT COUNT(*) FROM Assignacio_Voluntari_Projecte WHERE Projecte_nom = @projecte"

            ' Abrir una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Asignar el parámetro del nombre del proyecto
                    cmd.Parameters.AddWithValue("@projecte", projecte)

                    ' Ejecutar la consulta y obtener el número de voluntarios asignados
                    numVoluntariosAssignats = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            ' Manejar cualquier error que pueda ocurrir al obtener el número de voluntarios asignados
            MessageBox.Show("Error al obtenir el número de voluntaris asignats: " & ex.Message)
        End Try

        Return numVoluntariosAssignats
    End Function

    Private Function ObtenerNumeroTotalVoluntariosProyecto(ByVal projecte As String) As Integer
        Dim numTotalVoluntariosProyecto As Integer = 0

        Try
            ' Consulta SQL para obtener el número total de voluntarios del proyecto
            Dim query As String = "SELECT nombre_voluntaris FROM Projecte WHERE Projecte_nom = @projecte"

            ' Abrir una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Asignar el parámetro del nombre del proyecto
                    cmd.Parameters.AddWithValue("@projecte", projecte)

                    ' Ejecutar la consulta y obtener el número total de voluntarios del proyecto
                    numTotalVoluntariosProyecto = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            ' Manejar cualquier error que pueda ocurrir al obtener el número total de voluntarios del proyecto
            MessageBox.Show("Error al obtenir el número total de voluntaris del projecte: " & ex.Message)
        End Try

        Return numTotalVoluntariosProyecto
    End Function

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim estadistiques As New FormEstadistiques
        estadistiques.Show()
        Me.Close()
    End Sub
End Class