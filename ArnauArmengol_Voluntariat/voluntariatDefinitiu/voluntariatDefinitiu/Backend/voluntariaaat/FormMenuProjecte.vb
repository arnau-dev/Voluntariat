Public Class FormMenuProjecte






    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim dispo As New FormInserirDIsponibilitatProjecte()
        dispo.Show()
        Me.Close()
    End Sub



    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Dim pdf As New FormPDF
        pdf.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Dim estadistiques As New FormEstadistiques
        estadistiques.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim InserirProjecte As New FormInserirProjecte()
        InserirProjecte.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim ModificarProjecte As New FormModificiarProjecte()
        ModificarProjecte.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim ConsultarProjecte As New FormConsultarProjecte()
        ConsultarProjecte.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim ConsultarProjecte As New FormEliminarProjecte()
        ConsultarProjecte.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim Entitat As New FormInserirEntitatICOntacte()
        Entitat.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim Ambit As New FormAmbitEstat
        Ambit.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formMenu As New FormMENU
        formMenu.Show()
        Me.Close()
    End Sub
End Class