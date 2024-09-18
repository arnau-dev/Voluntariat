Imports System.Data.SqlClient

Public Class FormVoluntaris2


    Private ReadOnly Property NIF As String
        Get
            Return TextNif.Text
        End Get
    End Property

    Public Sub New(ByVal nif As String, ByVal esNuevo As Boolean)
        InitializeComponent()

        ' Cargar los datos del voluntario correspondiente al NIF proporcionado
        If Not esNuevo Then
            CargarDadesVoluntari(nif)
        End If
    End Sub

    Private Sub CargarDadesVoluntari(ByVal nif As String)
        Dim query As String = "SELECT * FROM Voluntari WHERE nif = @nif"

        Using connexio As SqlConnection = ObtindreConexio()

            Using command As New SqlCommand(query, connexio)
                connexio.Open()

                ' Asignar el parámetro NIF al comando SQL
                command.Parameters.AddWithValue("@nif", nif)

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Mostrar los datos del voluntario en los controles del formulario
                        TextNif.Text = reader("nif").ToString()
                        TextNom.Text = reader("nom").ToString()
                        TextCognoms.Text = reader("cognoms").ToString()
                        DateTimePicker_Neixement.Value = Convert.ToDateTime(reader("data_De_Neixement"))
                        TextAdreca.Text = reader("adreca").ToString()
                        TextTelefon.Text = reader("telefon").ToString()
                        TextTelefon2.Text = If(reader.IsDBNull(reader.GetOrdinal("telefon2")), "", reader("telefon2").ToString())
                        TextCorreuElectronic.Text = If(reader.IsDBNull(reader.GetOrdinal("correu_Electronic")), "", reader("correu_Electronic").ToString())
                        CheckActiu.Checked = Convert.ToBoolean(reader("actiu"))
                        CheckAssegurat.Checked = Convert.ToBoolean(reader("assegurat"))
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub AfegirVoluntari_Click(sender As Object, e As EventArgs) Handles AfegirVoluntari.Click

        Try
            Dim query As String = "INSERT INTO Voluntari (nif, nom, cognoms, dataInscripcio, data_De_Neixement, adreca, telefon, telefon2, correu_Electronic, actiu, motiu, assegurat) " &
                             "VALUES (@nif, @nom, @cognoms, @dataInscripcio, @data_De_Neixement, @adreca, @telefon, @telefon2, @correu_Electronic, @actiu, @motiu, @assegurat)"

            Using connexio As SqlConnection = ObtindreConexio()

                Using command As New SqlCommand(query, connexio)
                    connexio.Open()

                    Dim dataInscripcio As DateTime = DateTime.Now
                    ' Asignar valores de los controles al comando SQL
                    command.Parameters.AddWithValue("@nif", TextNif.Text)
                    command.Parameters.AddWithValue("@nom", TextNom.Text)
                    command.Parameters.AddWithValue("@cognoms", TextCognoms.Text)
                    command.Parameters.AddWithValue("@dataInscripcio", dataInscripcio)
                    command.Parameters.AddWithValue("@data_De_Neixement", DateTimePicker_Neixement.Value)
                    command.Parameters.AddWithValue("@adreca", TextAdreca.Text)
                    command.Parameters.AddWithValue("@telefon", TextTelefon.Text)
                    command.Parameters.AddWithValue("@telefon2", If(String.IsNullOrEmpty(TextTelefon2.Text), DBNull.Value, TextTelefon2.Text))
                    command.Parameters.AddWithValue("@correu_Electronic", TextCorreuElectronic.Text)
                    command.Parameters.AddWithValue("@actiu", If(CheckActiu.Checked, 1, 0))
                    command.Parameters.AddWithValue("@motiu", TextMotiu.Text)
                    command.Parameters.AddWithValue("@assegurat", If(CheckAssegurat.Checked, 1, 0))

                    ' Ejecutar el comando SQL
                    command.ExecuteNonQuery()

                    MessageBox.Show("Voluntario insertado correctamente.")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al insertar el voluntari: " & ex.Message)
        End Try
    End Sub

    Private Sub ActualizarDadesVoluntari()
        Dim query As String = "UPDATE Voluntari SET nom = @nom, cognoms = @cognoms,  data_De_Neixement = @data_De_Neixement, adreca = @adreca, telefon = @telefon, telefon2 = @telefon2, correu_Electronic = @correu_Electronic, actiu = @actiu, assegurat = @assegurat WHERE nif = @nif"

        Using connexio As SqlConnection = ObtindreConexio()

            Using command As New SqlCommand(query, connexio)
                connexio.Open()

                ' Asignar valores de los controles al comando SQL
                command.Parameters.AddWithValue("@nif", TextNif.Text)
                command.Parameters.AddWithValue("@nom", TextNom.Text)
                command.Parameters.AddWithValue("@cognoms", TextCognoms.Text)
                command.Parameters.AddWithValue("@data_De_Neixement", DateTimePicker_Neixement.Value)
                command.Parameters.AddWithValue("@adreca", TextAdreca.Text)
                command.Parameters.AddWithValue("@telefon", TextTelefon.Text)
                command.Parameters.AddWithValue("@telefon2", If(String.IsNullOrEmpty(TextTelefon2.Text), DBNull.Value, TextTelefon2.Text))
                command.Parameters.AddWithValue("@correu_Electronic", TextCorreuElectronic.Text)
                command.Parameters.AddWithValue("@actiu", If(CheckActiu.Checked, 1, 0))
                command.Parameters.AddWithValue("@assegurat", If(CheckAssegurat.Checked, 1, 0))

                ' Ejecutar el comando SQL
                command.ExecuteNonQuery()

                MessageBox.Show("Dades del voluntari actualitzades correctament.")
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FormVoluntaris.Show()
    End Sub

    Private Sub Button_Actualitzar_Click(sender As Object, e As EventArgs) Handles Button_Actualitzar.Click
        ActualizarDadesVoluntari()
    End Sub


End Class