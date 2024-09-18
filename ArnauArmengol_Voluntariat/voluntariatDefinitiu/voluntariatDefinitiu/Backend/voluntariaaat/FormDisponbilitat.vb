Imports System.Data.SqlClient

Public Class FormDisponbilitat

    Private Sub FormDisponbilitatIAssignacions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarVoluntaris()
        CarregarDiaComboboxdia()
        CarregarHoraIniciComboboxhoraIn()
        CarregarHoraFiComboboxhoraFi()
    End Sub

    Private Sub DataGridViewVoluntaris_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewVoluntaris.SelectionChanged
        If DataGridViewVoluntaris.SelectedRows.Count > 0 Then
            ' Obtenir el NIF del voluntari seleccionat en el DataGridViewVoluntaris
            Dim nif As String = DataGridViewVoluntaris.SelectedRows(0).Cells("nif").Value.ToString()

            ' Trucar a la funció per consultar la disponibilitat segons el NIF
            ConsultarDisponibilitatPerNIF(nif)
        End If
    End Sub

    Private Sub CargarVoluntaris()
        ' Consulta SQL per obtenir els voluntaris disponibles
        Dim query As String = "SELECT nif, nom, cognoms FROM Voluntari WHERE actiu = 1 AND assegurat = 1"

        ' Connexió a la base de dades
        Using connexio As SqlConnection = ObtindreConexio()
            ' Comandament SQL per executar la consulta
            Using command As New SqlCommand(query, connexio)
                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()

                Try
                    ' Obrir la connexió i omplir el DataTable amb els resultats de la consulta
                    connexio.Open()
                    adapter.Fill(dataTable)

                    ' Assignar el DataTable com a origen de dades del DataGridView
                    DataGridViewVoluntaris.DataSource = dataTable
                Catch ex As Exception
                    ' Gestionar els errors de consulta
                    MessageBox.Show("Error en carregar els voluntaris: " & ex.Message)
                Finally
                    ' Tancar la connexió
                    connexio.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub CarregarDiaComboboxdia()
        ' Llista dels dies de la setmana 
        Dim diesSetmana As New List(Of String) From {"Dilluns", "Dimarts", "Dimecres", "Dijous", "Divendres", "Dissabte", "Diumenge"}

        ' Netegem el ComboBox abans de carregar les noves dades
        ComboBoxdia.Items.Clear()

        ' Afegir els dies al ComboBoxdia
        For Each dia As String In diesSetmana
            ComboBoxdia.Items.Add(dia)
        Next

        ' Obtenir el dia seleccionat abans de netejar el ComboBox
        Dim selectedDay As String = If(ComboBoxdia.SelectedItem IsNot Nothing, ComboBoxdia.SelectedItem.ToString(), Nothing)

        ' Mantenir la selecció del dia si encara està a la llista
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

                ' Netegem el ComboBox abans de carregar les noves dades
                ComboBoxhoraIn.Items.Clear()

                ' Llegim cada fila i afegim l'hora d'inici al ComboBox
                While reader.Read()
                    ComboBoxhoraIn.Items.Add(reader("disponibilitat_INCIAL").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar les hores d'inici: " & ex.Message)
        End Try
    End Sub

    Private Sub CarregarHoraFiComboboxhoraFi()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT disponibilitat_FINAL FROM Disponibilitat WHERE disponibilitat_FINAL IN ('07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00', '00:00')"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Netegem el ComboBox abans de carregar les noves dades
                ComboBoxhoraFi.Items.Clear()

                ' Llegim cada fila i afegim l'hora de fi al ComboBox
                While reader.Read()
                    ComboBoxhoraFi.Items.Add(reader("disponibilitat_FINAL").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar les hores: " & ex.Message)
        End Try
    End Sub

    Private Sub AgregarDisponibilitat()
        ' Obtenir el NIF del voluntari seleccionat en el DataGridView
        Dim nifVoluntari As String = DataGridViewVoluntaris.CurrentRow.Cells("nif").Value.ToString()

        ' Obtenir el dia, hora d'inici i hora final dels ComboBox
        Dim dia As String = ComboBoxdia.SelectedItem.ToString()
        Dim horaInici As String = ComboBoxhoraIn.SelectedItem.ToString()
        Dim horaFinal As String = ComboBoxhoraFi.SelectedItem.ToString()

        ' Consulta SQL per insertar la disponibilitat a la taula Disponibilitat
        Dim query As String = "INSERT INTO Disponibilitat (nif, dia, disponibilitat_INCIAL, disponibilitat_FINAL) VALUES (@nif, @dia, @horaInici, @horaFinal)"

        ' Crear una connexió a la base de dades i un comandament SQL
        Using connexio As SqlConnection = ObtindreConexio()
            Using command As New SqlCommand(query, connexio)
                ' Afegir paràmetres a la consulta SQL
                command.Parameters.AddWithValue("@nif", nifVoluntari)
                command.Parameters.AddWithValue("@dia", dia)
                command.Parameters.AddWithValue("@horaInici", horaInici)
                command.Parameters.AddWithValue("@horaFinal", horaFinal)

                Try
                    ' Obrir la connexió
                    connexio.Open()
                    ' Executar la consulta SQL
                    command.ExecuteNonQuery()

                    ConsultarDisponibilitatPerNIF(nifVoluntari)

                    MessageBox.Show("Disponibilitat afegida correctament.")
                Catch ex As Exception
                    MessageBox.Show("Error en afegir la disponibilitat: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ConsultarDisponibilitatPerNIF(ByVal nif As String)
        ' Consulta SQL per seleccionar la disponibilitat segons el NIF
        Dim query As String = "SELECT dia, disponibilitat_INCIAL, disponibilitat_FINAL FROM Disponibilitat WHERE nif = @nif"

        ' Crear una connexió a la base de dades i un comandament SQL
        Using connection As SqlConnection = ObtindreConexio()
            Using command As New SqlCommand(query, connection)
                ' Afegir el paràmetre del NIF a la consulta SQL
                command.Parameters.AddWithValue("@nif", nif)

                Try
                    ' Obrir la connexió
                    connection.Open()

                    ' Crear un DataTable per emmagatzemar els resultats de la consulta
                    Dim dataTable As New DataTable()

                    ' Executar la consulta SQL i omplir el DataTable amb els resultats
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable)
                    End Using

                    ' Mostrar els resultats en un DataGridView o un altre control de la teva elecció
                    DataGridViewDisponibilitat.DataSource = dataTable
                Catch ex As Exception
                    MessageBox.Show("Error en consultar la disponibilitat: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ButtonAssignarDisponibilitat_Click(sender As Object, e As EventArgs) Handles ButtonAssignarDisponibilitat.Click
        AgregarDisponibilitat()
    End Sub

End Class
