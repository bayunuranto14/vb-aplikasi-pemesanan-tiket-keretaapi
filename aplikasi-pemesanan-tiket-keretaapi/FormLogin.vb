Imports MySql.Data.MySqlClient

Public Class FormLogin
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        GroupBox1.Text = ""
        Label2.Text = "Username :"
        Label3.Text = "Password :"
        Button1.Text = " LOGIN "

    End Sub

    Sub munculkanpassword()
        If CheckBox1.Checked = True Then
            TextBox2.UseSystemPasswordChar = False
        ElseIf CheckBox1.Checked = False Then
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Sub login()
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MessageBox.Show("Isi username dan password terlebih dahulu!!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                koneksiserver()
                cmd = New MySqlCommand("select * from karyawan where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", con)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then
                    If rd("status").ToString = "ADMIN" Then
                        Me.Hide()
                        MessageBox.Show("Berhasil Login!", "SUKSES LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dashboard.Show()
                    ElseIf rd("status").ToString = "USERS" Then
                        Me.Hide()
                        MessageBox.Show("Berhasil Login!", "SUKSES LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        FormKaryawan.Show()
                    End If
                Else
                    MessageBox.Show("Akun anda belum terdaftar!!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub


   
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        munculkanpassword()
    End Sub
End Class