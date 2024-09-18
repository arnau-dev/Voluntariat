Imports System.Data.SqlClient
Public Class FormAmbitVoluntariIdiomes

    Private Sub FormAmbitVoluntariIdiomes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarAmbits()
        CargarVoluntaris()
        CargarIdiomes()
    End Sub

    Private Sub DataGridViewVoluntaris_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewVoluntaris.SelectionChanged
        ' Verificar si hay al menos una fila seleccionada en el DataGridViewVoluntaris
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtener el NIF del voluntario seleccionado
            Dim nif As String = DataGridViewVoluntaris.SelectedRows(0).Cells("nif").Value.ToString()

            ' Llamar a la función para mostrar los ámbitos e idiomas del voluntario seleccionado
            MostrarAmbitsIdiomes(nif)
        End If
    End Sub

    Private Sub AgregarAmbit(nomAmbit As String)
        Try
            ' Consulta SQL para insertar el ámbito en la base de datos
            Dim query As String = "INSERT INTO Ambit_Voluntari (Ambit_nom) VALUES (@nomAmbit)"

            ' Crear una conexión a la base de datos
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                ' Crear y configurar el comando SQL
                Using command As New SqlCommand(query, connexio)
                    ' Asignar el valor del parámetro del nombre del ámbito
                    command.Parameters.AddWithValue("@nomAmbit", nomAmbit)

                    ' Ejecutar el comando SQL
                    command.ExecuteNonQuery()

                    ' Mostrar un mensaje de éxito
                    MessageBox.Show("Àmbit afegit correctament.")
                End Using
            End Using
        Catch ex As Exception
            ' Mostrar un mensaje de error en caso de problemas
            MessageBox.Show("Error en afegir l'àmbit: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonAddAmbit_Click(sender As Object, e As EventArgs) Handles ButtonAddAmbit.Click
        Dim nomAmbit As String = TextBoxNomAmbit.Text

        ' Verificar si se proporcionó un nombre de ámbito
        If Not String.IsNullOrWhiteSpace(nomAmbit) Then
            ' Llamar a la función para agregar el ámbito
            AgregarAmbit(nomAmbit)
        Else
            MessageBox.Show("Si us plau, introdueix un nom d'àmbit.")
        End If

        CargarAmbits()
    End Sub

    Private Sub CargarAmbits()
        Try
            ' Consulta SQL para obtener los ámbitos de la base de datos
            Dim query As String = "SELECT Distinct(Ambit_Nom) FROM Ambit_Voluntari"

            ' Crear una lista para almacenar los nombres de los ámbitos
            Dim ambits As New List(Of String)()

            ' Crear una conexión a la base de datos
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                ' Crear y configurar el comando SQL
                Using command As New SqlCommand(query, connexio)
                    ' Ejecutar la consulta y obtener un lector de datos
                    Using reader As SqlDataReader = command.ExecuteReader()
                        ' Leer los resultados y añadir los nombres de los ámbitos a la lista
                        While reader.Read()
                            ambits.Add(reader.GetString(0))
                        End While
                    End Using
                End Using
            End Using

            ' Asignar la lista de ámbitos al ComboBox
            ComboBoxAmbits.DataSource = ambits
        Catch ex As Exception
            ' Mostrar un mensaje de error en caso de problemas
            MessageBox.Show("Error en carregar els àmbits: " & ex.Message)
        End Try

    End Sub

    Private Sub CargarVoluntaris()
        Try
            ' Consulta SQL per obtenir els voluntaris des de la base de dades
            Dim query As String = "SELECT nif, nom, cognoms FROM Voluntari WHERE actiu = 1 AND assegurat = 1"

            ' Crear una connexió a la base de dades
            Using connexio As SqlConnection = ObtindreConexio()
                connexio.Open()

                ' Crear i configurar la comanda SQL
                Using command As New SqlCommand(query, connexio)
                    ' Crear un adaptador de dades i un conjunt de dades per emmagatzemar els resultats
                    Using adapter As New SqlDataAdapter(command)
                        Dim dataTable As New DataTable()

                        ' Omplir el conjunt de dades amb els resultats de la consulta
                        adapter.Fill(dataTable)

                        ' Assignar el conjunt de dades com a origen de dades del DataGridView
                        DataGridViewVoluntaris.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Mostrar un missatge d'error en cas de problemes
            MessageBox.Show("Error en carregar els voluntaris: " & ex.Message)
        End Try
    End Sub

    Private Sub AfegirAmbitAVoluntari()
        ' Verificar si se ha seleccionado un voluntario en el DataGridView
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtener el NIF del voluntario seleccionado
            Dim nifVoluntari As String = DataGridViewVoluntaris.SelectedRows(0).Cells("nif").Value.ToString()

            ' Verificar si se ha seleccionado un ámbito en el ComboBox
            If ComboBoxAmbits.SelectedIndex >= 0 Then
                ' Obtener el ámbito seleccionado
                Dim ambit As String = ComboBoxAmbits.SelectedItem.ToString()

                Try
                    ' Consulta SQL para insertar el ámbito al voluntario en la tabla correspondiente
                    Dim query As String = "INSERT INTO Ambit_Voluntari (nif, Ambit_nom) VALUES (@nif, @ambit)"

                    Using connexio As SqlConnection = ObtindreConexio()
                        connexio.Open()

                        ' Crear y configurar la comanda SQL
                        Using command As New SqlCommand(query, connexio)
                            ' Asignar los parámetros de la consulta
                            command.Parameters.AddWithValue("@nif", nifVoluntari)
                            command.Parameters.AddWithValue("@ambit", ambit)

                            ' Ejecutar la consulta
                            command.ExecuteNonQuery()

                            MessageBox.Show("Àmbit afegit al voluntari correctament.")
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al afegir l'àmbit al voluntari: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Selecciona un àmbit abans d'afegir-lo al voluntari.")
            End If
        Else
            MessageBox.Show("Selecciona un voluntari abans d'afegir l'àmbit.")
        End If
    End Sub

    Private Sub ButtonAddAmbitAVoluntari_Click(sender As Object, e As EventArgs) Handles ButtonAddAmbitAVoluntari.Click
        AfegirAmbitAVoluntari()
    End Sub

    Private Sub EliminarAmbitDeVoluntari()
        ' Verificar si hay al menos una fila seleccionada en el DataGridView
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtener el NIF del voluntario seleccionado
            Dim nifVoluntari As String = DataGridViewVoluntaris.SelectedRows(0).Cells("nif").Value.ToString()

            ' Verificar si hay un ámbito seleccionado en la fila del DataGridView
            If DataGridViewAmbits.SelectedRows.Count > 0 Then
                ' Obtener el ámbito seleccionado
                Dim ambit As String = DataGridViewAmbits.SelectedRows(0).Cells("Ambit").Value.ToString()

                Try
                    ' Consulta SQL para eliminar el ámbito del voluntario en la tabla correspondiente
                    Dim query As String = "DELETE FROM Ambit_Voluntari WHERE nif = @nif AND Ambit_nom = @ambit"

                    Using connexio As SqlConnection = ObtindreConexio()
                        connexio.Open()

                        ' Crear y configurar la comanda SQL
                        Using command As New SqlCommand(query, connexio)
                            ' Asignar los parámetros de la consulta
                            command.Parameters.AddWithValue("@nif", nifVoluntari)
                            command.Parameters.AddWithValue("@ambit", ambit)

                            ' Ejecutar la consulta
                            Dim filasAfectadas As Integer = command.ExecuteNonQuery()

                            ' Verificar si se eliminaron filas
                            If filasAfectadas > 0 Then
                                MessageBox.Show("Àmbit eliminat del voluntari correctament.")
                            Else
                                MessageBox.Show("No s'ha pogut eliminar l'àmbit del voluntari.")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error en eliminar l'àmbit del voluntari: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Selecciona un àmbit per eliminar-lo del voluntari.")
            End If
        Else
            MessageBox.Show("Selecciona un voluntari abans d'eliminar l'àmbit.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EliminarAmbitDeVoluntari()

    End Sub

    Private Sub MostrarAmbitsIdiomes(ByVal nif As String)
        Try
            ' Consulta SQL para obtener los ámbitos e idiomas del voluntario seleccionado
            Dim query As String = "
        SELECT DISTINCT 
    iv.nom_idioma AS Idioma,
    av.Ambit_nom AS Ambit 
FROM 
    Ambit_Voluntari av
INNER JOIN 
    Idioma_Voluntari iv ON av.nif = iv.nif
WHERE 
    av.nif = @nif
GROUP BY av.Ambit_nom, iv.nom_idioma ;
        "

            ' Crear una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                ' Abrir la conexión
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Asignar el parámetro del NIF del voluntario
                    cmd.Parameters.AddWithValue("@nif", nif)

                    ' Crear un adaptador de datos y un conjunto de datos para almacenar los resultados
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim dataSet As New DataSet()

                        ' Llenar el conjunto de datos con los resultados de la consulta
                        adapter.Fill(dataSet)

                        ' Mostrar los resultados en el DataGridViewAmbits
                        DataGridViewAmbits.DataSource = dataSet.Tables(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al mostrar ámbits e idiomes: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarIdiomes()
        Try
            ' Consulta SQL para obtener todos los idiomas disponibles
            Dim query As String = "SELECT Distinct(nom_idioma) FROM Idioma_Voluntari"

            ' Crear una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                ' Abrir la conexión
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Ejecutar la consulta y obtener un lector de datos
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        ' Limpiar el ComboBox
                        ComboBoxIdiomes.Items.Clear()

                        ' Leer cada fila del resultado y agregar el idioma al ComboBox
                        While reader.Read()
                            ComboBoxIdiomes.Items.Add(reader("nom_idioma").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al carregar els idiomes: " & ex.Message)
        End Try
    End Sub

    Private Sub AfegirIdioma()
        Try
            ' Verificar si se ha proporcionado un nombre de idioma
            If Not String.IsNullOrWhiteSpace(TextBoxIdioma.Text) Then
                ' Consulta SQL para insertar el nuevo idioma en la tabla Idioma
                Dim query As String = "INSERT INTO Idioma_Voluntari (nom_idioma) VALUES (@nom_idioma)"

                ' Crear una conexión a la base de datos
                Using conn As SqlConnection = ObtindreConexio()
                    ' Abrir la conexión
                    conn.Open()

                    ' Crear y configurar el comando SQL
                    Using cmd As New SqlCommand(query, conn)
                        ' Asignar el parámetro del nombre del idioma
                        cmd.Parameters.AddWithValue("@nom_idioma", TextBoxIdioma.Text)

                        ' Ejecutar la consulta para insertar el nuevo idioma
                        cmd.ExecuteNonQuery()

                        ' Mostrar un mensaje de éxito
                        MessageBox.Show("Idioma afegit correctament.")
                    End Using
                End Using
            Else
                MessageBox.Show("Si us plau, introdueix el nom del idioma.")
            End If
        Catch ex As Exception
            ' Mostrar un mensaje de error en caso de problemas
            MessageBox.Show("Error al afegir idioma: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonAddIdioma_Click(sender As Object, e As EventArgs) Handles ButtonAddIdioma.Click
        AfegirIdioma()
        CargarIdiomes()
    End Sub

    Private Sub AfegirIdiomaSegonsNIF()
        ' Verificar si hay al menos una fila seleccionada en el DataGridView
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtener el NIF del voluntario seleccionado
            Dim nif As String = DataGridViewVoluntaris.SelectedRows(0).Cells("nif").Value.ToString()

            ' Obtener el idioma seleccionado en el ComboBoxIdiomes
            Dim idioma As String = ComboBoxIdiomes.SelectedItem.ToString()

            ' Verificar si se seleccionó un idioma
            If Not String.IsNullOrEmpty(idioma) Then
                Try
                    ' Abrir una conexión a la base de datos
                    Using conn As SqlConnection = ObtindreConexio()
                        conn.Open()

                        ' Consulta SQL para insertar el idioma del voluntario
                        Dim query As String = "INSERT INTO Idioma_Voluntari (nom_idioma, nif) VALUES (@idioma, @nif)"

                        ' Crear y configurar el comando SQL
                        Using cmd As New SqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@idioma", idioma)
                            cmd.Parameters.AddWithValue("@nif", nif)

                            ' Ejecutar la consulta
                            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()

                            ' Verificar si se insertaron filas
                            If filasAfectadas > 0 Then
                                MessageBox.Show("Idioma afegit correctament al voluntari.")
                            Else
                                MessageBox.Show("No es pot afegir l'idioma al voluntari.")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    ' Mostrar un mensaje de error en caso de problemas de conexión
                    MessageBox.Show("Error al connectar amb la base de dades: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Selecciona un idioma abans d'afegir-lo al voluntari.")
            End If
        Else
            MessageBox.Show("No hi ha cap voluntari seleccionat per afegir-li l'idioma.")
        End If
    End Sub

    Private Sub ButtonAddIdiomaAVoluntari_Click(sender As Object, e As EventArgs) Handles ButtonAddIdiomaAVoluntari.Click
        AfegirIdiomaSegonsNIF()
    End Sub
    Private Sub EliminarIdiomaParaVoluntarioSeleccionado()
        ' Verificar si hay al menos una fila seleccionada en el DataGridViewVoluntari
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtener el NIF del voluntario seleccionado
            Dim nif As String = DataGridViewVoluntaris.SelectedRows(0).Cells("nif").Value.ToString()

            ' Verificar si hay al menos una fila seleccionada en el DataGridViewAmbits
            If DataGridViewAmbits.SelectedRows.Count > 0 Then
                ' Obtener el nombre del idioma seleccionado
                Dim idioma As String = DataGridViewAmbits.SelectedRows(0).Cells("idioma").Value.ToString()

                ' Llamar a la función para eliminar el idioma del voluntario
                EliminarIdiomaVoluntario(nif, idioma)
            Else
                MessageBox.Show("Selecciona un idioma para eliminar.")
            End If
        Else
            MessageBox.Show("Selecciona un voluntario para eliminar el idioma.")
        End If
    End Sub

    Private Sub EliminarIdiomaVoluntario(ByVal nif As String, ByVal idioma As String)
        Try
            ' Consulta SQL para eliminar el idioma del voluntario
            Dim query As String = "DELETE FROM Idioma_Voluntari WHERE nif = @nif AND nom_idioma = @idioma"

            ' Abrir una conexión a la base de datos
            Using conn As SqlConnection = ObtindreConexio()
                conn.Open()

                ' Crear y configurar el comando SQL
                Using cmd As New SqlCommand(query, conn)
                    ' Asignar los parámetros de la consulta
                    cmd.Parameters.AddWithValue("@nif", nif)
                    cmd.Parameters.AddWithValue("@idioma", idioma)

                    ' Ejecutar la consulta
                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Idioma eliminado correctamente para el voluntario con NIF: " & nif)
                End Using
            End Using
        Catch ex As Exception
            ' Manejar cualquier error que pueda ocurrir al eliminar el idioma del voluntario
            MessageBox.Show("Error al eliminar el idioma del voluntario: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EliminarIdiomaParaVoluntarioSeleccionado()
    End Sub
End Class