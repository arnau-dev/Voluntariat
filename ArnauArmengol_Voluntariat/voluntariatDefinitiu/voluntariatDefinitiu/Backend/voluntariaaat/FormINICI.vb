Public Class FormINICI

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim formulariMENU As New FormMENU()
        formulariMENU.Show()
        Me.Hide()
    End Sub
End Class