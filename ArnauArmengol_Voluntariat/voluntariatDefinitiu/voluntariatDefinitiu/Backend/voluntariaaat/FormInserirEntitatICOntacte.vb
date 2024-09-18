Imports System.Data.SqlClient

Public Class FormInserirEntitatICOntacte

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEntitats()
        LoadProjectes()
    End Sub

    Private Sub LoadEntitats()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT nom_entitat FROM Entitat"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ComboBox1.Items.Clear()

                While reader.Read()
                    ComboBox1.Items.Add(reader("nom_entitat").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar les entitats: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadProjectes()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT Projecte_nom FROM Projecte"
                Dim command As New SqlCommand(query, connection)
                Dim reader As SqlDataReader = command.ExecuteReader()

                ComboBox2.Items.Clear()

                ' Llegim cada fila i afegim el nom del projecte al ComboBox
                While reader.Read()
                    ComboBox2.Items.Add(reader("Projecte_nom").ToString())
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar els projectes: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox2.SelectedItem IsNot Nothing Then
            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()

                    ' Obtindre el nom del projecte seleccionat
                    Dim nomProjecte As String = ComboBox2.SelectedItem.ToString()

                    Dim nomEntitat As String = String.Empty

                    If Not String.IsNullOrEmpty(TextBox5.Text) Then
                        ' Si es proporciona el valor a TextBox5 utilitzal com a nom de l'entitat
                        nomEntitat = TextBox5.Text

                        ' Inserir la nova entitat a la base de dades
                        Dim queryInsertEntitat As String = "INSERT INTO Entitat (nom_entitat) VALUES (@nom_entitat)"
                        Dim commandInsertEntitat As New SqlCommand(queryInsertEntitat, connection)
                        commandInsertEntitat.Parameters.AddWithValue("@nom_entitat", nomEntitat)
                        commandInsertEntitat.ExecuteNonQuery()

                        MessageBox.Show("Nova entitat afegida a la base de dades.")

                    ElseIf ComboBox1.SelectedItem IsNot Nothing Then
                        ' Si es selecciona una entitat a ComboBox1, utilitzar-la com a nom de l'entitat
                        nomEntitat = ComboBox1.SelectedItem.ToString()
                    Else
                        MessageBox.Show("Si us plau, introduïu un nom d'entitat o seleccioneu una entitat existent.")
                        Return ' Sortir del mètode si no es proporciona un nom d'entitat
                    End If

                    ' Verificar si l'entitat existeix a la base de dades
                    Dim queryCheckEntitat As String = "SELECT COUNT(*) FROM Entitat WHERE nom_entitat = @nom_entitat"
                    Dim commandCheckEntitat As New SqlCommand(queryCheckEntitat, connection)
                    commandCheckEntitat.Parameters.AddWithValue("@nom_entitat", nomEntitat)
                    Dim entitatCount As Integer = Convert.ToInt32(commandCheckEntitat.ExecuteScalar())

                    If entitatCount > 0 Then
                        ' L'entitat existeix, per tant, actualitzar el Projecte amb el nom de l'entitat proporcionada
                        Dim queryUpdateProjecte As String = "UPDATE Projecte SET nom_entitat = @nom_entitat WHERE Projecte_nom = @Projecte_nom"
                        Dim commandUpdateProjecte As New SqlCommand(queryUpdateProjecte, connection)
                        commandUpdateProjecte.Parameters.AddWithValue("@nom_entitat", nomEntitat)
                        commandUpdateProjecte.Parameters.AddWithValue("@Projecte_nom", nomProjecte)
                        commandUpdateProjecte.ExecuteNonQuery()

                        MessageBox.Show("Entitat actualitzada correctament en el projecte.")
                    Else
                        MessageBox.Show("L'entitat especificada no existeix a la base de dades.")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error en actualitzar l'entitat en el projecte: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Si us plau, seleccioneu un projecte.")
        End If

        ' Recarregar els noms dels projectes després d'actualitzar l'entitat
        LoadProjectes()
        LoadEntitats()
        LoadProjectes_datagridview1()
    End Sub









    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Verificar si s'ha seleccionat una entitat al ComboBox1
        If ComboBox1.SelectedItem IsNot Nothing Then
            If Not String.IsNullOrEmpty(TextBox1.Text) AndAlso Not String.IsNullOrEmpty(TextBox2.Text) AndAlso
               Not String.IsNullOrEmpty(TextBox3.Text) AndAlso Not String.IsNullOrEmpty(TextBox4.Text) Then
                Try
                    Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                        connection.Open()

                        ' Verificar si el contacte ja existeix a la taula Contacte
                        Dim contacteExistQuery As String = "SELECT COUNT(*) FROM Contacte WHERE nom_contacte = @nom_contacte"
                        Dim commandContacteExist As New SqlCommand(contacteExistQuery, connection)
                        commandContacteExist.Parameters.AddWithValue("@nom_contacte", TextBox1.Text)
                        Dim existingCount As Integer = Convert.ToInt32(commandContacteExist.ExecuteScalar())

                        If existingCount = 0 Then
                            ' Inserir el contacte a la taula Contacte
                            Dim queryContacte As String = "INSERT INTO Contacte (nom_contacte, telefon, correu_Electronic, direccio) VALUES (@nom_contacte, @telefon, @correu, @direccio)"
                            Dim commandContacte As New SqlCommand(queryContacte, connection)
                            commandContacte.Parameters.AddWithValue("@nom_contacte", TextBox1.Text)
                            commandContacte.Parameters.AddWithValue("@telefon", TextBox2.Text)
                            commandContacte.Parameters.AddWithValue("@correu", TextBox3.Text)
                            commandContacte.Parameters.AddWithValue("@direccio", TextBox4.Text)
                            commandContacte.ExecuteNonQuery()
                        End If

                        ' Obtindre l'ID del contacte inserit
                        Dim queryGetContactId As String = "SELECT nom_contacte FROM Contacte WHERE nom_contacte = @nom_contacte"
                        Dim commandGetContactId As New SqlCommand(queryGetContactId, connection)
                        commandGetContactId.Parameters.AddWithValue("@nom_contacte", TextBox1.Text)
                        Dim contactId As String = commandGetContactId.ExecuteScalar().ToString()

                        ' Obtindre el nom de l'entitat seleccionada
                        Dim selectedEntitat As String = ComboBox1.SelectedItem.ToString()

                        ' Inserir el nom del contacte a la taula Entitat
                        Dim queryInsertContacteEntitat As String = "UPDATE Entitat SET nom_contacte = @nom_contacte WHERE nom_entitat = @nom_entitat"
                        Dim commandInsertContacteEntitat As New SqlCommand(queryInsertContacteEntitat, connection)
                        commandInsertContacteEntitat.Parameters.AddWithValue("@nom_contacte", contactId)
                        commandInsertContacteEntitat.Parameters.AddWithValue("@nom_entitat", selectedEntitat)
                        commandInsertContacteEntitat.ExecuteNonQuery()

                        MessageBox.Show("Nom del contacte afegit a l'entitat correctament.")
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error en afegir el nom del contacte a l'entitat: " & ex.Message)
                End Try
            Else
                MessageBox.Show("Si us plau, ompliu tots els camps de contacte.")
            End If
        Else
            MessageBox.Show("Si us plau, seleccioneu una entitat.")
        End If
    End Sub


    Private Sub FormInserirEntitatICOntacte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carregar els noms dels projectes al DataGridView1
        LoadProjectes_datagridview1()
    End Sub

    Private Sub LoadProjectes_datagridview1()
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "SELECT Projecte.Projecte_nom, Entitat.nom_entitat FROM Projecte INNER JOIN Entitat ON Projecte.nom_entitat = Entitat.nom_entitat"
                Dim adapter As New SqlDataAdapter(query, connection)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)
                DataGridView1.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar els projectes: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim projectName As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()

            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()

                    ' Obtindre el nom de l'entitat associada al projecte seleccionat
                    Dim query As String = "SELECT nom_entitat FROM Projecte WHERE Projecte_nom = @projectName"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@projectName", projectName)
                    Dim entitat As String = Convert.ToString(command.ExecuteScalar())

                    ' Filtrar els contactes segons l'entitat
                    Dim queryContacte As String = "SELECT nom_contacte, telefon, correu_Electronic, direccio FROM Contacte WHERE nom_contacte IN (SELECT nom_contacte FROM Entitat WHERE nom_entitat = @entitat)"
                    Dim commandContacte As New SqlCommand(queryContacte, connection)
                    commandContacte.Parameters.AddWithValue("@entitat", entitat)
                    Dim adapter As New SqlDataAdapter(commandContacte)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    DataGridView2.DataSource = dataTable
                End Using
            Catch ex As Exception
                MessageBox.Show("Error en carregar els contactes associats al projecte: " & ex.Message)
            End Try
        End If
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim projectName As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()

            Try
                Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                    connection.Open()

                    ' Obtindre el nom de l'entitat associada al projecte seleccionat
                    Dim query As String = "SELECT nom_entitat FROM Projecte WHERE Projecte_nom = @projectName"
                    Dim command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@projectName", projectName)
                    Dim entitat As String = Convert.ToString(command.ExecuteScalar())

                    ' Filtrar les dades al DataGridView3 per mostrar només l'entitat associada al projecte seleccionat
                    Dim dataTable As New DataTable()
                    Dim adapter As New SqlDataAdapter("SELECT nom_entitat FROM Entitat WHERE nom_entitat = @nom_entitat", connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@nom_entitat", entitat)
                    adapter.Fill(dataTable)
                    DataGridView3.DataSource = dataTable
                End Using
            Catch ex As Exception
                MessageBox.Show("Error en carregar les dades d'Entitat associades al projecte seleccionat: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                ' Seleccionar tots els contactes
                Dim queryContacte As String = "SELECT nom_contacte, telefon, correu_Electronic, direccio FROM Contacte"
                Dim commandContacte As New SqlCommand(queryContacte, connection)
                Dim adapterContacte As New SqlDataAdapter(commandContacte)
                Dim dataTableContacte As New DataTable()
                adapterContacte.Fill(dataTableContacte)

                DataGridView2.DataSource = dataTableContacte

                ' Seleccionar totes les entitats
                Dim queryEntitat As String = "SELECT nom_entitat FROM Entitat"
                Dim commandEntitat As New SqlCommand(queryEntitat, connection)
                Dim adapterEntitat As New SqlDataAdapter(commandEntitat)
                Dim dataTableEntitat As New DataTable()
                adapterEntitat.Fill(dataTableEntitat)

                DataGridView3.DataSource = dataTableEntitat
            End Using
        Catch ex As Exception
            MessageBox.Show("Error en carregar les dades: " & ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If DataGridView2.SelectedRows.Count > 0 Then
                ' Eliminar el contacte seleccionat al DataGridView2
                Dim selectedContactName As String = DataGridView2.SelectedRows(0).Cells("nom_contacte").Value.ToString()
                DeleteContact(selectedContactName)
                MessageBox.Show("Contacte eliminat correctament.")
            ElseIf DataGridView3.SelectedRows.Count > 0 Then
                ' Eliminar l'entitat seleccionada al DataGridView3
                Dim selectedEntitatName As String = DataGridView3.SelectedRows(0).Cells("nom_entitat").Value.ToString()
                DeleteEntitat(selectedEntitatName)
                MessageBox.Show("Entitat eliminada correctament.")
            Else
                MessageBox.Show("Si us plau, seleccioneu un contacte o una entitat per eliminar.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error en eliminar el registre: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteContact(ByVal contactName As String)
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "DELETE FROM Contacte WHERE nom_contacte = @nom_contacte"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@nom_contacte", contactName)
                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeleteEntitat(ByVal entitatName As String)
        Try
            Using connection As SqlConnection = ModulConexio.ObtindreConexio()
                connection.Open()
                Dim query As String = "DELETE FROM Entitat WHERE nom_entitat = @nom_entitat"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@nom_entitat", entitatName)
                command.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Mostrar opcions d'entitat
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        Button1.Visible = True
        Button2.Visible = False
        Button3.Visible = False
        Label6.Visible = True
        TextBox5.Visible = True
        Button4.Visible = True
        ComboBox1.Visible = True
        ComboBox2.Visible = True
        Label8.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Mostrar opcions de contacte
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True
        Button1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        Label6.Visible = False
        TextBox5.Visible = False
        Button4.Visible = False
        ComboBox1.Visible = True
        ComboBox2.Visible = False
        Label8.Visible = False

    End Sub

    Private Sub MenuProjecteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuProjecteToolStripMenuItem.Click
        Dim Inici As New FormMenuProjecte()
        Inici.Show()
        Me.Close()
    End Sub
End Class
