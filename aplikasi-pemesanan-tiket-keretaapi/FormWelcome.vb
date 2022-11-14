Public Class FormWelcome

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CekKoneksiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CekKoneksiToolStripMenuItem.Click
        Testkoneksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormLogin.Show()
    End Sub

    Private Sub ExitApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitApplicationToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
