Imports System.Data.SqlClient

Public Class FormInserirDIsponibilitatProjecte
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarDiaCombobox1()
        CarregarHoraIniciCombobox2()
        CarregarHoraFiCombobox3()
        LoadProjecteNomDataGridView()
    End Sub

    Private Sub CarregarDiaCombobox1()
        Dim diesSetmana As New List(Of String) From {"Dilluns", "Dimarts", "Dimecres", "Dijous", "Divendres", "Dissabte", "Diumenge"}

        ' Netejar el combobox
        ComboBox1.Items.Clear()

        For Each dia As String In diesSetmana
            ComboBox1.Items.Add(dia)
        Next

        ' Obtenir el dia seleccionat 
        Dim selectedDay As String = If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedItem.ToString(), Nothing)

        ' Mantenir la selecció del dia si encara esta a la llista
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


                ComboBox2.Items.Clear()

                While reader.Read()
                    ComboBox2.Items.Add(reader("hora_inici").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar les hores d'inici: " & ex.Message)
        End Try
    End Sub

    Private Sub CarregarHoraFiCombobox3()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT hora_fi FROM DisponibilitatProjecte WHERE hora_fi IN ('07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00', '00:00')"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ComboBox3.Items.Clear()

                While reader.Read()
                    ComboBox3.Items.Add(reader("hora_fi").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar les hores de fi: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim projecteSeleccionat As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()

            Dim dia As String = ComboBox1.SelectedItem.ToString()
            Dim horaInici As String = ComboBox2.SelectedItem.ToString()
            Dim horaFi As String = ComboBox3.SelectedItem.ToString()

            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()
                    Dim query As String = "INSERT INTO DisponibilitatProjecte (Projecte_nom, dia, hora_inici, hora_fi) VALUES (@Projecte_nom, @dia, @hora_inici, @hora_fi)"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Projecte_nom", projecteSeleccionat)
                    command.Parameters.AddWithValue("@dia", dia)
                    command.Parameters.AddWithValue("@hora_inici", horaInici)
                    command.Parameters.AddWithValue("@hora_fi", horaFi)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Disponibilitat afegida correctament.")

                    ' Després d'inserir, recarregar els dies en ComboBox1
                    CarregarDiaCombobox1()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error en inserir la disponibilitat: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Seleccioneu un projecte primer.")
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim projecteSeleccionat As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()

            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()
                    Dim query As String = "SELECT dia, hora_inici, hora_fi FROM DisponibilitatProjecte WHERE Projecte_nom = @Projecte_nom"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Projecte_nom", projecteSeleccionat)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    DataGridView2.DataSource = dataTable
                End Using
            Catch ex As Exception
                MessageBox.Show("Error en carregar la disponibilitat del projecte: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox2.SelectedItem IsNot Nothing AndAlso ComboBox3.SelectedItem IsNot Nothing Then
                Dim projecteSeleccionat As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()
                Dim diaOriginal As String = DataGridView2.SelectedRows(0).Cells("dia").Value.ToString()
                Dim diaNou As String = ComboBox1.SelectedItem.ToString()
                Dim horaInici As String = ComboBox2.SelectedItem.ToString()
                Dim horaFi As String = ComboBox3.SelectedItem.ToString()

                Try
                    Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                        connection.Open()
                        Dim query As String = "UPDATE DisponibilitatProjecte SET dia = @dia_nou, hora_inici = @hora_inici, hora_fi = @hora_fi WHERE Projecte_nom = @Projecte_nom AND dia = @dia_original"
                        Dim command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@dia_nou", diaNou)
                        command.Parameters.AddWithValue("@hora_inici", horaInici)
                        command.Parameters.AddWithValue("@hora_fi", horaFi)
                        command.Parameters.AddWithValue("@Projecte_nom", projecteSeleccionat)
                        command.Parameters.AddWithValue("@dia_original", diaOriginal)
                        command.ExecuteNonQuery()

                        MessageBox.Show("Disponibilitat actualitzada correctament.")

                        CarregarDiaCombobox1()

                        DataGridView1_SelectionChanged(Nothing, Nothing)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error en actualitzar la disponibilitat: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Seleccioneu un dia, hora d'inici i hora de fi primer.")
            End If
        Else
            MessageBox.Show("Seleccioneu una fila a la taula de disponibilitat primer.")
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            Dim projecteSeleccionat As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()
            Dim diaSeleccionat As String = DataGridView2.SelectedRows(0).Cells("dia").Value.ToString()

            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()
                    Dim query As String = "DELETE FROM DisponibilitatProjecte WHERE Projecte_nom = @Projecte_nom AND dia = @dia"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Projecte_nom", projecteSeleccionat)
                    command.Parameters.AddWithValue("@dia", diaSeleccionat)
                    command.ExecuteNonQuery()

                    MessageBox.Show("Disponibilitat eliminada correctament.")

                    DataGridView1_SelectionChanged(Nothing, Nothing)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error en eliminar la disponibilitat: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Seleccioneu una fila a la taula de disponibilitat primer.")
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
            MessageBox.Show("Error en carregar els projectes: " & ex.Message)
        End Try
    End Sub

    Private Sub MenuProjecteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuProjecteToolStripMenuItem.Click
        Dim Inici As New FormMenuDisponibilitat()
        Inici.Show()
        Me.Close()
    End Sub
End Class
