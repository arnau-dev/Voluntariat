Imports System.Data.SqlClient

Public Class FormVoluntaris

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Método que se ejecuta cuando se carga el formulario
        MostrarVoluntaris()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Obtener la fila seleccionada
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Extraer los valores de las columnas "nif", "nom" y "cognoms"
            Dim nif As String = selectedRow.Cells("nif").Value.ToString()
            Dim nom As String = selectedRow.Cells("nom").Value.ToString()
            Dim cognoms As String = selectedRow.Cells("cognoms").Value.ToString()

            ' Asignar los valores a los TextBox correspondientes
            TextNif.Text = nif
            TextNom.Text = nom
            TextCognoms.Text = cognoms
        End If

    End Sub
    Private Sub RadioButtonNoAssignats_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNoAssignats.CheckedChanged

        If RadioButtonNoAssignats.Checked Then
            ' Muestra los voluntarios no asignados en el DataGridView
            MostrarVoluntarisNoAssignats()
        End If

    End Sub

    Private Sub RadioButtonAssignats_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAssignats.CheckedChanged
        If RadioButtonAssignats.Checked Then
            ' Muestra los voluntarios no asignados en el DataGridView
            MostrarVoluntarisAssignats()
        End If
    End Sub

    Private Sub Button_MostrarDades_Click(sender As Object, e As EventArgs) Handles Button_MostrarDades.Click
        MostrarDadesPerNIF()
    End Sub

    Private Sub Button_ActualitzarDades_Click(sender As Object, e As EventArgs) Handles Button_ActualitzarDades.Click
        Dim nif As String = TextNif.Text.Trim()

        ' Verificar si se ingresó un NIF válido
        If Not String.IsNullOrEmpty(nif) Then
            ' Crear una instancia del segundo formulario, pasando el NIF como parámetro
            Dim form2 As New FormVoluntaris2(nif, False)
            ' Mostrar el segundo formulario
            Me.Hide()
            form2.Show()

        Else
            ' Mostrar un mensaje si el campo de NIF está vacío
            MessageBox.Show("Siusplau, ingresa un NIF vàlid.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonAfegir.Click

        Dim form2 As New FormVoluntaris2(0, False)
        form2.Show()

        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonCorreus.Click
        Dim formulariCorreus As New FormCorreusElectronics()

        Dim correus As New List(Of String)()

        For Each fila As DataGridViewRow In DataGridView1.Rows
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


    Private Sub MostrarVoluntaris()
        ' Consulta SQL para obtener la información de los voluntarios
        Dim query As String = "SELECT nif, nom, cognoms, actiu, correu_Electronic FROM Voluntari"
        ' DataTable para almacenar los resultados de la consulta
        Dim dataTable As New DataTable()
        ' Conexión a la base de datos
        Using connexio As SqlConnection = ObtindreConexio()
            ' Comando SQL para ejecutar la consulta
            Using command As New SqlCommand(query, connexio)
                Try
                    ' Abrir la conexión
                    connexio.Open()
                    ' Adaptador para llenar el DataTable con los resultados de la consulta
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable) ' Llenar el DataTable con los datos obtenidos de la consulta
                    End Using
                Catch ex As Exception
                    ' Manejo de errores
                    MessageBox.Show("Error al consultar la base de dades: " & ex.Message)
                End Try
            End Using
        End Using

        ' Establecer el DataTable como origen de datos del DataGridView
        DataGridView1.DataSource = dataTable

        ' Personalizar el color de las filas según el estado de activo
        Dim rowCount As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To rowCount - 1
            ' Obtener el valor del campo "actiu" de la fila actual y convertirlo a tipo booleano
            Dim actiu As Boolean = Convert.ToBoolean(DataGridView1.Rows(i).Cells("actiu").Value)
            ' Cambiar el color de la fila según el estado de activo
            If actiu Then
                ' Si el voluntario está activo, mostrar la fila en verde
                DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.Green
            Else
                ' Si el voluntario está inactivo, mostrar la fila en rojo
                DataGridView1.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
    End Sub


    Private Sub MostrarVoluntarisNoAssignats()
        ' Consulta SQL para obtener los voluntarios activos y no asignados a ningún proyecto
        Dim query As String = "SELECT v.nif, nom, cognoms, correu_Electronic FROM Voluntari v
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
                    MessageBox.Show("Error al consultar la base de dades: " & ex.Message)
                End Try
            End Using
        End Using

        ' Establecer el DataTable como origen de datos del DataGridView
        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub MostrarVoluntarisAssignats()

        Dim query As String = "SELECT v.nif, nom, cognoms, correu_Electronic FROM Voluntari v
                               LEFT JOIN Assignacio_voluntari_projecte avp ON v.nif = avp.nif
                               WHERE v.actiu = 1 AND v.assegurat = 1 AND avp.Projecte_nom IS NOT NULL"
        Dim dataTable As New DataTable()
        Using connexio As SqlConnection = ObtindreConexio()
            Using command As New SqlCommand(query, connexio)
                Try
                    connexio.Open()
                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dataTable) ' Llenar el DataTable con los datos obtenidos de la consulta
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al consultar la base de dades: " & ex.Message)
                End Try
            End Using
        End Using

        ' Establecer el DataTable como origen de datos del DataGridView
        DataGridView1.DataSource = dataTable

    End Sub

    Private Sub MostrarDadesPerNIF()

        Dim nif As String = TextNif.Text.Trim()

        ' Verificar si se ingresó un NIF válido
        If Not String.IsNullOrEmpty(nif) Then
            ' Consulta SQL para obtener los datos del voluntario por su NIF
            Dim query As String = "SELECT * FROM Voluntari WHERE nif = @nif"

            ' DataTable para almacenar los resultados de la consulta
            Dim dataTable As New DataTable()

            ' Conexión a la base de datos
            Using connexio As SqlConnection = ObtindreConexio()
                ' Comando SQL para ejecutar la consulta
                Using command As New SqlCommand(query, connexio)
                    ' Parámetro para el NIF
                    command.Parameters.AddWithValue("@nif", nif)

                    Try
                        ' Abrir la conexión
                        connexio.Open()

                        ' Adaptador para llenar el DataTable con los resultados de la consulta
                        Using adapter As New SqlDataAdapter(command)
                            adapter.Fill(dataTable) ' Llenar el DataTable con los datos obtenidos de la consulta
                        End Using
                    Catch ex As Exception
                        ' Manejo de errores
                        MessageBox.Show("Error al consultar la base de dades: " & ex.Message)
                    End Try
                End Using
            End Using

            If dataTable.Rows.Count > 0 Then
                ' Mostrar los datos en los TextBox
                TextNom.Text = dataTable.Rows(0)("nom").ToString()
                TextCognoms.Text = dataTable.Rows(0)("cognoms").ToString()
            Else
                ' Limpiar los TextBox si no se encontraron datos
                TextNom.Clear()
                TextCognoms.Clear()
                MessageBox.Show("No s'han trobat dades del NIF seleccionat.")
            End If

            DataGridView1.DataSource = dataTable
        Else
            ' Mostrar un mensaje si el campo de NIF está vacío
            MessageBox.Show("Siusplau, ingresa un NIF vàlid.")
        End If


    End Sub





    Private Sub ConsultarProjectesEnCurs()
        ' Verificar si hay una fila seleccionada en el DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Obtener el valor del NIF de la fila seleccionada
            Dim nif As String = DataGridView1.SelectedRows(0).Cells("nif").Value.ToString()

            ' Consulta SQL para obtener los proyectos en curso asociados al voluntario con el NIF seleccionado
            Dim query As String = "SELECT p.Projecte_nom, p.deficinicio, p.data_fi_projecte, p.lloc, p.nom_estat 
                               FROM Projecte p
                               INNER JOIN Assignacio_voluntari_projecte avp ON p.Projecte_nom = avp.Projecte_nom
                               WHERE avp.nif = @nif AND p.nom_estat = 'En vigor'"

            ' DataTable para almacenar los resultados de la consulta
            Dim dataTable As New DataTable()

            ' Conexión a la base de datos
            Using connexio As SqlConnection = ObtindreConexio()
                ' Comando SQL para ejecutar la consulta
                Using command As New SqlCommand(query, connexio)
                    ' Parámetro para el NIF
                    command.Parameters.AddWithValue("@nif", nif)

                    Try
                        ' Abrir la conexión
                        connexio.Open()

                        ' Adaptador para llenar el DataTable con los resultados de la consulta
                        Using adapter As New SqlDataAdapter(command)
                            adapter.Fill(dataTable) ' Llenar el DataTable con los datos obtenidos de la consulta
                        End Using
                    Catch ex As Exception
                        ' Manejo de errores
                        MessageBox.Show("Error al consultar la base de dades: " & ex.Message)
                    End Try
                End Using
            End Using

            ' Establecer el DataTable como origen de datos del DataGridView
            DataGridView1.DataSource = dataTable
        Else
            MessageBox.Show("Siusplau, selecciona una fila al DataGridView per a consultar els projectes amb curs.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ConsultarProjectesEnCurs()
    End Sub

    Private Sub RadioButtonMostrarTots_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonMostrarTots.CheckedChanged
        If RadioButtonMostrarTots.Checked Then
            ' Muestra los voluntarios no asignados en el DataGridView
            MostrarVoluntaris()
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formulariAmbitsVoluntari As New FormAmbitVoluntariIdiomes

        formulariAmbitsVoluntari.Show()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cert As New FormPDF
        cert.Show()
        Me.Close()
    End Sub
End Class
