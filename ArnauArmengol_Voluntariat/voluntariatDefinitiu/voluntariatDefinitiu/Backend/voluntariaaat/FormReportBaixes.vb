Public Class FormReportBaixes

    Public Sub MostrarInformesBaixes(dataSet As DataSet)
        DataGridViewInformes.DataSource = dataSet.Tables(0)
    End Sub

End Class