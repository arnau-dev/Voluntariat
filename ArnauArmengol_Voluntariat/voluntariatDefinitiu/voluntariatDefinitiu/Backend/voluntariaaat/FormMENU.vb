Public Class FormMENU
    Private Sub PictureBox_Voluntaris_Click(sender As Object, e As EventArgs) Handles PictureBox_Voluntaris.Click
        Dim formulariVoluntaris As New FormVoluntaris()
        formulariVoluntaris.Show()

    End Sub

    Private Sub PictureBox_Projectes_Click(sender As Object, e As EventArgs) Handles PictureBox_Projectes.Click
        Dim formulariProjectes As New FormMenuProjecte()
        formulariProjectes.Show()

    End Sub

    Private Sub PictureBox_Disponibilitat_Click(sender As Object, e As EventArgs) Handles PictureBox_Disponibilitat.Click
        Dim formulariDisponibilitat As New FormMenuDisponibilitat
        formulariDisponibilitat.Show()
    End Sub

    Private Sub PictureBox_Assignacions_Click(sender As Object, e As EventArgs) Handles PictureBox_Assignacions.Click
        Dim formulariAssignacions As New FormAssignacions()
        formulariAssignacions.Show()
    End Sub
End Class