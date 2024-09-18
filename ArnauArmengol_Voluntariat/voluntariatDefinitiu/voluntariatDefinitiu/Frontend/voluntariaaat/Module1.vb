Imports System.Data.SqlClient

Module ModulConexio

    Public Function ObtindreConexio() As SqlConnection
        Dim connexioBD As String = "Data Source=DESKTOP-PRC7Q18\SQLEXPRESS;Initial Catalog=voluntariatSenior;Integrated Security=True"
        Return New SqlConnection(connexioBD)
    End Function

End Module
