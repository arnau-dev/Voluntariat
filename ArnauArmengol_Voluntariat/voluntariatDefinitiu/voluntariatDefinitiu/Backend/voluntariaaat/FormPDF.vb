Imports Microsoft.Office.Interop.Word
Imports System.Data.SqlClient
Imports System.IO ' Agregar esta línea para importar el espacio de nombres System.IO

Public Class FormPDF

    Private Sub FormPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar los datos en el DataGridView
        CargarDatosDataGridView()
    End Sub

    Private Sub CargarDatosDataGridView()
        ' Obtener los datos de los voluntarios y proyectos
        Dim query As String = "SELECT V.nom, V.cognoms, V.NIF, P.Projecte_nom, P.data_fi_projecte " &
                              "FROM Voluntari V " &
                              "INNER JOIN Assignacio_voluntari_projecte AVP ON V.NIF = AVP.NIF " &
                              "INNER JOIN Projecte P ON AVP.Projecte_nom = P.Projecte_nom"

        ' Obtener la conexión a la base de datos utilizando la función del módulo ModulConexio
        Dim connection As SqlConnection = ModulConexio.ObtindreConexio()

        ' Crear un adaptador de datos y un conjunto de datos
        Dim adapter As New SqlDataAdapter(query, connection)
        Dim dataSet As New DataSet()

        Try
            connection.Open()

            ' Llenar el conjunto de datos con los resultados de la consulta
            adapter.Fill(dataSet, "VoluntariosProyectos")

            ' Asignar el conjunto de datos como origen de datos del DataGridView
            DataGridView1.DataSource = dataSet.Tables("VoluntariosProyectos")
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Obtener los datos de la fila seleccionada en el DataGridView
            Dim nom As String = DataGridView1.SelectedRows(0).Cells("nom").Value.ToString()
            Dim cognoms As String = DataGridView1.SelectedRows(0).Cells("cognoms").Value.ToString()
            Dim NIF As String = DataGridView1.SelectedRows(0).Cells("NIF").Value.ToString()
            Dim projecte_nom As String = DataGridView1.SelectedRows(0).Cells("Projecte_nom").Value.ToString()
            Dim data_fi_projecte As Date = Convert.ToDateTime(DataGridView1.SelectedRows(0).Cells("data_fi_projecte").Value)

            ' Abrir la plantilla de 
            Dim wordApp As New Application()
            Dim doc As Document = wordApp.Documents.Open("C:\Users\arnau\Downloads\voluntariatDefinitivisim (1)\voluntariatDefinitiu (1)\voluntariatDefinitiu\voluntariatDefinitiu\voluntariaaat\Microsoft\plantillaCertificat.docx")

            ' Rellenar la plantilla de Word con los datos obtenidos
            doc.Bookmarks("nom").Range.Text = nom & " " & cognoms
            doc.Bookmarks("nif").Range.Text = NIF
            doc.Bookmarks("project").Range.Text = projecte_nom
            doc.Bookmarks("date").Range.Text = data_fi_projecte.ToString("dd/MM/yyyy")

            ' Obtener la ruta de acceso desde el TextBox
            Dim pdfFolderPath As String = TextBox1.Text

            ' Verificar si la ruta de acceso es válida
            If Not String.IsNullOrWhiteSpace(pdfFolderPath) Then
                ' Crear la ruta completa del archivo PDF
                Dim pdfFileName As String = Path.Combine(pdfFolderPath, NIF & ".pdf")

                ' Guardar el certificado como PDF en la ruta especificada sin mostrar el cuadro de diálogo de guardar
                doc.SaveAs2(pdfFileName, WdSaveFormat.wdFormatPDF)

                ' Cerrar Word
                wordApp.Quit()

                MessageBox.Show("Certificado generado correctamente en la ruta especificada.")
            Else
                MessageBox.Show("Por favor, introduzca una ruta de acceso válida.")
            End If
        Else
            MessageBox.Show("Por favor, seleccione una fila en el DataGridView.")
        End If
    End Sub



End Class


