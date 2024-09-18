Imports System.Data.SqlClient

Module ModulConexio

    Public Function ObtindreConexio() As SqlConnection
        Dim connexioBD As String = "Data Source=ARNAU\ARNAU;Initial Catalog=voluntariat_v1;Integrated Security=True"
        Return New SqlConnection(connexioBD)
    End Function

End Module
