Imports System.Data.SqlClient

Public Class FormAmbitEstat
    Dim connectionString As String = ObtindreConexio().ConnectionString

    Private Sub FormAmbitEstat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarDadesAlDataGridView("SELECT nom_estat FROM EstatProjecte", DataGridView1, connectionString)
        CarregarDadesAlDataGridView("SELECT Ambit_nom FROM Ambit", DataGridView2, connectionString)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CarregarDadesAlDataGridView("SELECT nom_estat FROM EstatProjecte", DataGridView1, connectionString)
        CarregarDadesAlDataGridView("SELECT Ambit_nom FROM Ambit", DataGridView2, connectionString)
    End Sub

    Private Sub CarregarDadesAlDataGridView(query As String, dataGridView As DataGridView, connectionString As String)
        Try
            Using connection As SqlConnection = New SqlConnection(connectionString)
                connection.Open()
                Using command As SqlCommand = New SqlCommand(query, connection)
                    Using adapter As SqlDataAdapter = New SqlDataAdapter(command)
                        Dim dataSet As DataSet = New DataSet()
                        adapter.Fill(dataSet)
                        dataGridView.DataSource = dataSet.Tables(0)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar les dades: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Verificar si hi ha una fila seleccionada al DataGridView1 (EstatProjecte)
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim nomEstat As String = selectedRow.Cells(0).Value.ToString()

            Try
                Using connection As SqlConnection = New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "DELETE FROM EstatProjecte WHERE nom_estat = @nom_estat"
                    Using command As SqlCommand = New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@nom_estat", nomEstat)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                DataGridView1.Rows.Remove(selectedRow)
            Catch ex As Exception
                MessageBox.Show("Error en eliminar l'estat del projecte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf DataGridView2.SelectedRows.Count > 0 Then

            Dim selectedRow As DataGridViewRow = DataGridView2.SelectedRows(0)
            Dim nomAmbit As String = selectedRow.Cells(0).Value.ToString()

            Try
                Using connection As SqlConnection = New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "DELETE FROM Ambit WHERE Ambit_nom = @Ambit_nom"
                    Using command As SqlCommand = New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@Ambit_nom", nomAmbit)
                        command.ExecuteNonQuery()
                    End Using
                End Using
                DataGridView2.Rows.Remove(selectedRow)
            Catch ex As Exception
                MessageBox.Show("Error en eliminar l'àmbit: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Seleccioneu una fila per eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ambitNom As String = TextBox1.Text

        If Not String.IsNullOrWhiteSpace(ambitNom) Then
            Try
                Using connection As SqlConnection = New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "INSERT INTO Ambit (Ambit_nom) VALUES (@Ambit_nom)"
                    Using command As SqlCommand = New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@Ambit_nom", ambitNom)
                        command.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("L'àmbit s'ha inserit correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CarregarDadesAlDataGridView("SELECT Ambit_nom FROM Ambit", DataGridView2, connectionString)
            Catch ex As Exception
                MessageBox.Show("Error en inserir l'àmbit: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Introduïu un nom d'àmbit vàlid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim estatNom As String = TextBox1.Text

        If Not String.IsNullOrWhiteSpace(estatNom) Then
            Try
                Using connection As SqlConnection = New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "INSERT INTO EstatProjecte (nom_estat) VALUES (@nom_estat)"
                    Using command As SqlCommand = New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@nom_estat", estatNom)
                        command.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("L'estat del projecte s'ha inserit correctament.", "Èxit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CarregarDadesAlDataGridView("SELECT nom_estat FROM EstatProjecte", DataGridView1, connectionString)
            Catch ex As Exception
                MessageBox.Show("Error en inserir l'estat del projecte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Introduïu un nom d'estat del projecte vàlid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim rowIndex As Integer = DataGridView1.SelectedRows(0).Index
            Dim nomEstatOriginal As String = DataGridView1.Rows(rowIndex).Cells(0).Value.ToString()
            Dim nouNomEstat As String = TextBox1.Text

            Try
                Using connection As SqlConnection = New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE EstatProjecte SET nom_estat = @nouNomEstat WHERE nom_estat = @nomEstatOriginal"
                    Using command As SqlCommand = New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@nouNomEstat", nouNomEstat)
                        command.Parameters.AddWithValue("@nomEstatOriginal", nomEstatOriginal)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                CarregarDadesAlDataGridView("SELECT nom_estat FROM EstatProjecte", DataGridView1, connectionString)
            Catch ex As Exception
                MessageBox.Show("Error en modificar l'estat del projecte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf DataGridView2.SelectedRows.Count > 0 Then
            ' Obtindre l'índex de la fila seleccionada
            Dim rowIndex As Integer = DataGridView2.SelectedRows(0).Index

            ' Obtindre el nom de l'àmbit original
            Dim nomAmbitOriginal As String = DataGridView2.Rows(rowIndex).Cells(0).Value.ToString()

            Dim nouNomAmbit As String = TextBox1.Text

            Try
                Using connection As SqlConnection = New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE Ambit SET Ambit_nom = @nouNomAmbit WHERE Ambit_nom = @nomAmbitOriginal"
                    Using command As SqlCommand = New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@nouNomAmbit", nouNomAmbit)
                        command.Parameters.AddWithValue("@nomAmbitOriginal", nomAmbitOriginal)
                        command.ExecuteNonQuery()
                    End Using
                End Using

                ' Actualitzar el DataGridView2
                CarregarDadesAlDataGridView("SELECT Ambit_nom FROM Ambit", DataGridView2, connectionString)
            Catch ex As Exception
                MessageBox.Show("Error en modificar l'àmbit: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Seleccioneu una fila per modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub MenuProjecteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuProjecteToolStripMenuItem.Click
        Dim Inici As New FormMenuProjecte()
        Inici.Show()
        Me.Close()
    End Sub
End Class
