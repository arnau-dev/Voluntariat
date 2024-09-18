Imports System.Data.SqlClient

Public Class FormInserirProjecte
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        opcionsComboBox()
        opcionsComboBoxAmbit()
        opcionsComboBoxProjecte()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using connexio As SqlConnection = ObtindreConexio()
            If connexio.State = ConnectionState.Closed Then
                connexio.Open()
            End If

            Dim estadoProyecto As String
            Dim ambitProyecto As String
            Dim continuidadProyecto As String

            ' Verificar si se ha seleccionado un estado del ComboBox
            If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString() <> "Afegir un estat..." Then
                estadoProyecto = ComboBox1.SelectedItem.ToString()
            ElseIf Not String.IsNullOrEmpty(TextBox3.Text.Trim()) Then
                estadoProyecto = TextBox3.Text.Trim()

                Dim cmdInsertEstado As New SqlCommand("INSERT INTO EstatProjecte (nom_estat) VALUES (@nom_estat)", connexio)
                cmdInsertEstado.Parameters.AddWithValue("@nom_estat", estadoProyecto)
                cmdInsertEstado.ExecuteNonQuery()

                opcionsComboBox()

                ComboBox1.SelectedItem = estadoProyecto
            Else
                MessageBox.Show("Si us plau, selecciona un estat o ingresseu un de nou.")
                Return
            End If

            ' Verificar si se ha seleccionado un ámbito del ComboBox
            If ComboBox2.SelectedItem IsNot Nothing AndAlso ComboBox2.SelectedItem.ToString() <> "Afegir un àmbit..." Then
                ambitProyecto = ComboBox2.SelectedItem.ToString()
            ElseIf Not String.IsNullOrEmpty(TextBox4.Text.Trim()) Then
                ambitProyecto = TextBox4.Text.Trim()

                ' Insertar ámbito si no existe en la base de datos
                Dim cmdInsertAmbit As New SqlCommand("INSERT INTO Ambit (Ambit_nom) VALUES (@Ambit_nom)", connexio)
                cmdInsertAmbit.Parameters.AddWithValue("@Ambit_nom", ambitProyecto)
                cmdInsertAmbit.ExecuteNonQuery()

                opcionsComboBoxAmbit()
            Else
                MessageBox.Show("Si us plau, selecciona un àmbit o ingresseu un de nou.")
                Return
            End If

            ' Determinar continuidad del proyecto según el RadioButton seleccionado
            If RadioButton1.Checked Then
                continuidadProyecto = "Sí"
            ElseIf RadioButton2.Checked Then
                continuidadProyecto = "No"
            Else
                MessageBox.Show("Si us plau, selecciona si el projecte té continuïtat o no.")
                Return
            End If

            ' Insertar proyecto con el ámbito y la continuidad
            Dim cmd As New SqlCommand()
            cmd.CommandText = "INSERT INTO Projecte (Projecte_nom, deficinicio, data_inici_projecte, data_fi_projecte, lloc, nombre_voluntaris, dedicacio_necessaria, nom_estat, Ambit_nom, continuitat, coordinador) VALUES (@Projecte_nom, @deficinicio, @data_inici_projecte, @data_fi_projecte, @lloc, @nombre_voluntaris, @dedicacio_necessaria, @nom_estat, @Ambit_nom, @continuitat, @coordinador)"
            cmd.Parameters.AddWithValue("@Projecte_nom", TextBox1.Text)
            cmd.Parameters.AddWithValue("@deficinicio", TextBox2.Text)
            cmd.Parameters.AddWithValue("@data_inici_projecte", MonthCalendar1.SelectionStart)
            cmd.Parameters.AddWithValue("@data_fi_projecte", MonthCalendar2.SelectionEnd)
            cmd.Parameters.AddWithValue("@lloc", TextBox5.Text)
            cmd.Parameters.AddWithValue("@nombre_voluntaris", TextBox6.Text)
            cmd.Parameters.AddWithValue("@dedicacio_necessaria", TextBox7.Text)
            cmd.Parameters.AddWithValue("@nom_estat", estadoProyecto)
            cmd.Parameters.AddWithValue("@Ambit_nom", ambitProyecto)
            cmd.Parameters.AddWithValue("@continuitat", continuidadProyecto)
            cmd.Parameters.AddWithValue("@coordinador", TextBox8.Text)

            cmd.Connection = connexio

            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Dades insertades correctament.")
            Catch ex As Exception
                MessageBox.Show("Error al insertar dades: " & ex.Message)
            End Try
        End Using
    End Sub





    Private Sub opcionsComboBox()
        ' list combobox
        Dim opciones As New List(Of String) From {"Afegir un estat...", "Descartat", "En vigor", "Finalitzat", "Pendent de realitzar"}


        ComboBox1.DataSource = opciones
    End Sub

    Private Sub opcionsComboBoxAmbit()
        ' Listar ámbitos en ComboBox2
        Dim opcionesAmbit As New List(Of String) From {"Afegir un àmbit...", "Econòmic", "Educatiu", "Social", "Salut"}
        ComboBox2.DataSource = opcionesAmbit
    End Sub




    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim formulari4 As New FormConsultarProjecte()
        formulari4.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dim formulari5 As New FormModificiarProjecte()
        formulari5.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim formulari6 As New FormInserirEntitatICOntacte()
        formulari6.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' verifica si sa seleccionat afegir un estat..."
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString() = "Afegir un estat..." Then

            TextBox3.Enabled = True
        Else

            TextBox3.Enabled = False
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Verificar si se seleccionó "Afegir un àmbit..."
        If ComboBox2.SelectedItem IsNot Nothing AndAlso ComboBox2.SelectedItem.ToString() = "Afegir un àmbit..." Then
            TextBox4.Enabled = True
        Else
            TextBox4.Enabled = False
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim formulari2 As New FormInserirDIsponibilitatProjecte()
        formulari2.Show()
    End Sub


    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim menuProject As New FormMenuProjecte()
        menuProject.Show()
        Me.Close()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        Dim Consultar As New FormConsultarProjecte()
        Consultar.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        Dim Modificar As New FormModificiarProjecte()
        Modificar.Show()
        Me.Close()
    End Sub

    Private Sub InserirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InserirToolStripMenuItem.Click
        Dim Eliminar As New FormEliminarProjecte()
        Eliminar.Show()
        Me.Close()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim menuproj As New FormMenuProjecte()
        menuproj.Show()
        Me.Close()
    End Sub
    Private Sub opcionsComboBoxProjecte()
        ' Conectar a la base de datos
        Using connexio As SqlConnection = ObtindreConexio()
            Try
                connexio.Open()

                ' Consulta SQL para obtener los nombres de todos los proyectos
                Dim query As String = "SELECT Projecte_nom FROM Projecte"

                Using command As New SqlCommand(query, connexio)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Dim proyectos As New List(Of String)

                        ' Leer nombres de proyectos y agregarlos a la lista
                        While reader.Read()
                            proyectos.Add(reader.GetString(0))
                        End While

                        ' Asignar la lista de nombres de proyectos al ComboBox
                        ComboBox3.DataSource = proyectos
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al cargar los proyectos: " & ex.Message)
            End Try
        End Using
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox3.SelectedItem IsNot Nothing Then
            Dim proyectoSeleccionado As String = ComboBox3.SelectedItem.ToString()
            Dim nuevoNombreProyecto As String = proyectoSeleccionado & "2" ' Agregar "2" al final del nombre del proyecto

            Using connexio As SqlConnection = ObtindreConexio()
                Try
                    connexio.Open()

                    ' Verificar si el proyecto ya existe en la tabla Projecte_Repetit
                    Dim queryCheckExistence As String = "SELECT COUNT(*) FROM Projecte_Repetit WHERE projecte_nom = @projecte_nom"
                    Using cmdExistence As New SqlCommand(queryCheckExistence, connexio)
                        cmdExistence.Parameters.AddWithValue("@projecte_nom", proyectoSeleccionado)
                        Dim existe As Integer = CInt(cmdExistence.ExecuteScalar())

                        If existe > 0 Then
                            ' El proyecto ya existe, incrementar el contador
                            Dim queryIncrement As String = "UPDATE Projecte_Repetit SET numero_repetit = numero_repetit + 1 WHERE projecte_nom = @projecte_nom"
                            Dim cmdIncrement As New SqlCommand(queryIncrement, connexio)
                            cmdIncrement.Parameters.AddWithValue("@projecte_nom", proyectoSeleccionado)
                            cmdIncrement.ExecuteNonQuery()
                            MessageBox.Show("Se ha incrementado el contador del proyecto repetido en la tabla Projecte_Repetit.")
                        Else
                            ' Nuevo proyecto repetido, insertarlo en la tabla de proyectos repetidos con contador inicial de 1
                            Dim queryInsert As String = "INSERT INTO Projecte_Repetit (projecte_nom, numero_repetit) VALUES (@projecte_nom, 1)"
                            Dim cmdInsert As New SqlCommand(queryInsert, connexio)
                            cmdInsert.Parameters.AddWithValue("@projecte_nom", proyectoSeleccionado)
                            cmdInsert.ExecuteNonQuery()
                            MessageBox.Show("Se ha agregado el proyecto repetido a la tabla Projecte_Repetit.")
                        End If
                    End Using

                    ' Insertar el proyecto seleccionado en la tabla Projecte
                    Dim queryInsertProjecte As String = "INSERT INTO Projecte (Projecte_nom, deficinicio, data_inici_projecte, data_fi_projecte, lloc, nombre_voluntaris, dedicacio_necessaria, nom_estat, Ambit_nom, continuitat, coordinador) SELECT @nuevoNombreProyecto, deficinicio, data_inici_projecte, data_fi_projecte, lloc, nombre_voluntaris, dedicacio_necessaria, nom_estat, Ambit_nom, continuitat, coordinador FROM Projecte WHERE Projecte_nom = @projecte_nom"
                    Using cmdInsertProjecte As New SqlCommand(queryInsertProjecte, connexio)
                        cmdInsertProjecte.Parameters.AddWithValue("@nuevoNombreProyecto", nuevoNombreProyecto) ' Usar el nuevo nombre del proyecto
                        cmdInsertProjecte.Parameters.AddWithValue("@projecte_nom", proyectoSeleccionado)
                        cmdInsertProjecte.ExecuteNonQuery()
                        MessageBox.Show("Se ha insertado el proyecto repetido en la tabla Projecte.")
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error al agregar el proyecto repetido: " & ex.Message)
                End Try
            End Using
        Else
            MessageBox.Show("Por favor, selecciona un proyecto existente de ComboBox3.")
        End If
    End Sub


End Class