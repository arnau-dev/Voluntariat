Public Class FormMenuDisponibilitat
    Private Sub PictureBoxVoluntari_Click(sender As Object, e As EventArgs) Handles PictureBoxVoluntari.Click
        Dim formVoluntari As New FormDisponbilitat

        formVoluntari.Show()
    End Sub

    Private Sub PictureBoxProjecte_Click(sender As Object, e As EventArgs) Handles PictureBoxProjecte.Click
        Dim formProjecte As New FormInserirDIsponibilitatProjecte

        formProjecte.Show()
    End Sub
End Class