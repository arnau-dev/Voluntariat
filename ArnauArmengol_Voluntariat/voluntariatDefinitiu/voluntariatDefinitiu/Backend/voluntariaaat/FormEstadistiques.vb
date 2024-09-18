Imports Microsoft.Office.Interop.Word
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting
Imports Series = Microsoft.Office.Interop.Word.Series

Public Class FormEstadistiques

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtenir la ruta i el nom de l'arxiu PDF dels TextBox
        Dim carpetaPDF As String = TextBox1.Text.Trim()
        Dim nomArxiuPDF As String = TextBox2.Text.Trim() & ".pdf" ' Afegir l'extensió .pdf al nom de l'arxiu

        ' Verificar si s'han proporcionat valors vàlids
        If Not String.IsNullOrWhiteSpace(carpetaPDF) AndAlso Not String.IsNullOrWhiteSpace(nomArxiuPDF) Then
            ' Obrir la plantilla de Word
            Dim aplicacioWord As New Microsoft.Office.Interop.Word.Application()
            Dim doc As Document = aplicacioWord.Documents.Open("C:\Users\arnau\Downloads\voluntariatDefinitiu (1)\voluntariatDefinitiu\voluntariatDefinitiu\voluntariaaat\Microsoft\plantilla_estadistiques.docx")

            ' Omplir el document de Word amb les dades de la base de dades
            OmplirDades(doc)

            ' Guardar el document de Word temporalment
            Dim rutaTemp As String = Path.Combine(Path.GetTempPath(), "estadistiques.docx")
            doc.SaveAs2(rutaTemp)

            ' Convertir el document Word a PDF 
            ConvertirWordAPDF(rutaTemp, carpetaPDF, nomArxiuPDF)

            doc.Close()
            aplicacioWord.Quit()

            MessageBox.Show("Informe generat correctament com a document de Word i PDF.")
        Else
            MessageBox.Show("Si us plau, introdueixi una ruta d'accés i un nom d'arxiu vàlids.")
        End If
    End Sub

    Private Sub OmplirDades(ByRef doc As Document)
        ' Realitzar la connexió a la base de dades utilitzant la funció ObtindreConexio del mòdul ModulConexio
        Using connexio As SqlConnection = ModulConexio.ObtindreConexio()
            Try
                connexio.Open()

                ' Consulta SQL per obtenir el nombre total de voluntaris
                Dim consultaNomTotal As String = "SELECT COUNT(*) FROM Voluntari"
                Dim nombreTotal As Integer
                Using comandaNomTotal As New SqlCommand(consultaNomTotal, connexio)
                    nombreTotal = Convert.ToInt32(comandaNomTotal.ExecuteScalar())
                End Using
                OmplirMarcador(doc, "numero", nombreTotal.ToString())

                ' Consulta SQL per obtenir el nombre total de voluntaris participants
                Dim consultaVoluntarisParticipants As String = "SELECT COUNT(DISTINCT NIF) FROM Assignacio_voluntari_projecte"
                Dim voluntarisParticipants As Integer
                Using comandaVoluntarisParticipants As New SqlCommand(consultaVoluntarisParticipants, connexio)
                    voluntarisParticipants = Convert.ToInt32(comandaVoluntarisParticipants.ExecuteScalar())
                End Using
                OmplirMarcador(doc, "participant", voluntarisParticipants.ToString())

                ' Consulta SQL per obtenir el nombre total de projectes durant l'any actual
                Dim consultaProjectesDurantAny As String = "SELECT COUNT(*) FROM Projecte WHERE YEAR(data_inici_projecte) = YEAR(GETDATE())"
                Dim projectesDurantAny As Integer
                Using comandaProjectesDurantAny As New SqlCommand(consultaProjectesDurantAny, connexio)
                    projectesDurantAny = Convert.ToInt32(comandaProjectesDurantAny.ExecuteScalar())
                End Using
                OmplirMarcador(doc, "durantany", projectesDurantAny.ToString())

                ' Consulta SQL per obtenir la quantitat de projectes per àmbit durant l'any actual
                Dim consultaProjectesPerAmbit As String = "SELECT Ambit_nom, COUNT(*) AS NumProjectes FROM Projecte GROUP BY Ambit_nom"
                Dim projectesPerAmbit As New Dictionary(Of String, Integer)()
                Using comandaProjectesPerAmbit As New SqlCommand(consultaProjectesPerAmbit, connexio)
                    Using lector As SqlDataReader = comandaProjectesPerAmbit.ExecuteReader()
                        While lector.Read()
                            Dim ambit As String = lector("Ambit_nom").ToString()
                            Dim NumProjectes As Integer = Convert.ToInt32(lector("NumProjectes"))
                            projectesPerAmbit.Add(ambit, NumProjectes)
                        End While
                    End Using
                End Using
                OmplirMarcadorProjectesPerAmbit(doc, projectesPerAmbit)

                ' Consulta SQL per obtenir la quantitat de projectes repetits
                Dim consultaProjectesRepetits As String = "SELECT COUNT(*) FROM Projecte_Repetit"
                Dim numProjectesRepetits As Integer
                Using comandaProjectesRepetits As New SqlCommand(consultaProjectesRepetits, connexio)
                    numProjectesRepetits = Convert.ToInt32(comandaProjectesRepetits.ExecuteScalar())
                End Using
                OmplirMarcador(doc, "repetits", numProjectesRepetits.ToString())

                ' Consulta SQL per obtenir la llista d'entitats
                Dim consultaEntitats As String = "SELECT DISTINCT nom_entitat FROM Entitat"
                Dim entitats As New List(Of String)()
                Using comandaEntitats As New SqlCommand(consultaEntitats, connexio)
                    Using lector As SqlDataReader = comandaEntitats.ExecuteReader()
                        While lector.Read()
                            Dim entitat As String = lector("nom_entitat").ToString()
                            entitats.Add(entitat)
                        End While
                    End Using
                End Using
                OmplirMarcadorEntitats(doc, entitats)

                ' Consulta SQL per obtenir la quantitat de projectes per entitat
                Dim consultaProjectesPerEntitat As String = "SELECT nom_entitat, COUNT(*) AS NumProjectes FROM Projecte GROUP BY nom_entitat"
                Dim projectesPerEntitat As New Dictionary(Of String, Integer)()
                Using comandaProjectesPerEntitat As New SqlCommand(consultaProjectesPerEntitat, connexio)
                    Using lector As SqlDataReader = comandaProjectesPerEntitat.ExecuteReader()
                        While lector.Read()
                            Dim entitat As String = lector("nom_entitat").ToString()
                            Dim NumProjectes As Integer = Convert.ToInt32(lector("NumProjectes"))
                            projectesPerEntitat.Add(entitat, NumProjectes)
                        End While
                    End Using
                End Using
                OmplirMarcadorProjectesPerEntitat(doc, projectesPerEntitat, entitats)

                ' Consulta Sql per obtenir el nombre total de projectes realitzats
                Dim consultaNomTotali As String = "SELECT COUNT(*) FROM Projecte"
                Dim nombreTotali As Integer
                Using comandaNomTotal As New SqlCommand(consultaNomTotali, connexio)
                    nombreTotali = Convert.ToInt32(comandaNomTotal.ExecuteScalar())
                End Using
                OmplirMarcadore(doc, "projectesrealitzats", nombreTotali.ToString())

                ' Consulta SQL per obtenir la quantitat de projectes realitzats per cada àmbit
                Dim consultaProjectesPerAmbits As String = "SELECT Ambit_nom, COUNT(*) AS NumProjectes FROM Projecte GROUP BY Ambit_nom"
                Dim projectesPerAmbits As New Dictionary(Of String, Integer)()
                Using comandaProjectesPerAmbit As New SqlCommand(consultaProjectesPerAmbits, connexio)
                    Using lector As SqlDataReader = comandaProjectesPerAmbit.ExecuteReader()
                        While lector.Read()
                            Dim ambit As String = lector("Ambit_nom").ToString()
                            Dim NumProjectes As Integer = Convert.ToInt32(lector("NumProjectes"))
                            projectesPerAmbits.Add(ambit, NumProjectes)
                        End While
                    End Using
                End Using
                OmplirMarcadorProjectesPerAmbits(doc, projectesPerAmbits)

            Catch ex As Exception
                MessageBox.Show("Error en obtenir les dades de la base de dades: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub OmplirMarcador(ByRef doc As Document, nomMarcador As String, text As String)
        If doc.Bookmarks.Exists(nomMarcador) Then
            Dim rang As Range = doc.Bookmarks(nomMarcador).Range
            rang.Text = text
            doc.Bookmarks.Add(nomMarcador, rang)
        End If
    End Sub


    Private Sub OmplirMarcadorProjectesPerAmbit(ByRef doc As Document, projectesPerAmbit As Dictionary(Of String, Integer))
        For Each kvp As KeyValuePair(Of String, Integer) In projectesPerAmbit
            Dim ambit As String = kvp.Key
            Dim NumProjectes As Integer = kvp.Value
            Dim nomMarcador As String = "ambit"
            Dim text As String = NumProjectes.ToString()
            OmplirMarcador(doc, nomMarcador & ambit, text)
        Next
    End Sub

    Private Sub OmplirMarcadorEntitats(ByRef doc As Document, entitats As List(Of String))
        Dim nomMarcador As String = "entitats"
        Dim text As String = String.Join(", ", entitats)
        OmplirMarcador(doc, nomMarcador, text)
    End Sub

    Private Sub OmplirMarcadorProjectesPerEntitat(ByRef doc As Document, projectesPerEntitat As Dictionary(Of String, Integer), entitats As List(Of String))
        If doc.Bookmarks.Exists("entitats") Then
            Dim rang As Range = doc.Bookmarks("entitats").Range
            Dim text As String = ""

            For Each entitat As String In entitats
                If projectesPerEntitat.ContainsKey(entitat) Then
                    text &= entitat & ": " & projectesPerEntitat(entitat) & " projecte(s)" & vbCrLf
                End If
            Next

            rang.Text = text
            doc.Bookmarks.Add("entitats", rang)
        End If
    End Sub

    Private Sub OmplirMarcadore(ByRef doc As Document, nomMarcador As String, text As String)
        If doc.Bookmarks.Exists(nomMarcador) Then
            Dim rang As Range = doc.Bookmarks(nomMarcador).Range
            rang.Text = text
            doc.Bookmarks.Add(nomMarcador, rang)
        End If
    End Sub

    Private Sub OmplirMarcadorProjectesPerAmbits(ByRef doc As Document, projectesPerAmbit As Dictionary(Of String, Integer))
        For Each kvp As KeyValuePair(Of String, Integer) In projectesPerAmbit
            Dim ambit As String = kvp.Key
            Dim NumProjectes As Integer = kvp.Value
            Dim nomMarcador As String = "projectesambitrealitzats" & ambit.Replace(" ", "_")
            Dim text As String = NumProjectes.ToString()
            OmplirMarcador(doc, nomMarcador, text)
        Next
    End Sub

    Private Sub ConvertirWordAPDF(rutaArxiuWord As String, carpetaPDF As String, nomArxiuPDF As String)
        If Not String.IsNullOrWhiteSpace(carpetaPDF) AndAlso Not String.IsNullOrWhiteSpace(nomArxiuPDF) Then
            Try
                Dim rutaArxiuPDF As String = Path.Combine(carpetaPDF, nomArxiuPDF)

                Dim aplicacioWord As New Microsoft.Office.Interop.Word.Application()
                Dim doc As Document = aplicacioWord.Documents.Open(rutaArxiuWord)

                doc.ExportAsFixedFormat(rutaArxiuPDF, WdExportFormat.wdExportFormatPDF)


                doc.Close()
                aplicacioWord.Quit()

                MessageBox.Show("Document PDF generat correctament.")
            Catch ex As Exception
                MessageBox.Show("Error en convertir el document Word a PDF: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Si us plau, introdueixi una ruta d'accés i un nom d'arxiu vàlids.")
        End If
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click
        '       netejar dades del gràfic
        Chart1.Series.Clear()

        ' Afegir nova sèrie al gràfic
        Chart1.Series.Add("Voluntaris")


        Using connexio As SqlConnection = ModulConexio.ObtindreConexio()
            Try
                connexio.Open()


                Dim consulta As String = "SELECT MONTH(dataInscripcio) AS Mes, COUNT(*) AS NumVoluntaris FROM Voluntari GROUP BY MONTH(dataInscripcio)"
                Using comanda As New SqlCommand(consulta, connexio)
                    Using lector As SqlDataReader = comanda.ExecuteReader()

                        While lector.Read()
                            Dim mes As Integer = Convert.ToInt32(lector("Mes"))
                            Dim numVoluntaris As Integer = Convert.ToInt32(lector("NumVoluntaris"))
                            Chart1.Series("Voluntaris").Points.AddXY(mes, numVoluntaris)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error en obtenir les dades de la base de dades: " & ex.Message)
            End Try
        End Using

        ' Etiquetes

        Chart1.ChartAreas(0).AxisX.Title = "Mes"
        Chart1.ChartAreas(0).AxisY.Title = "Nombre de voluntaris"
        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.ChartAreas(0).AxisX.Minimum = 1
        Chart1.ChartAreas(0).AxisX.Maximum = 12
        Chart1.ChartAreas(0).AxisY.Minimum = 0

        'llegenda
        Chart1.Legends(0).Enabled = True
    End Sub

    Private Sub FormEstadistiques_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
