Public Class FormCorreusElectronics
    Private _correus As String
    Public Property Correus As String
        Get
            Return _correus
        End Get
        Set(value As String)
            _correus = value
            TextBox1.Text = value
        End Set
    End Property

    Private Sub FormCorreusElectronics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class