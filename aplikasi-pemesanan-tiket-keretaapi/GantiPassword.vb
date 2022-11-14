Imports MySql.Data.MySqlClient

Public Class GantiPassword

    Private Sub GantiPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Text = "Input"
        Button2.Text = "Edit"
        Button3.Text = "Refresh"
        Button4.Text = "Delete Data"
        koneksiserver()
        kondisiawal()

    End Sub
    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        tampil_data()
        karyawan()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub
    Sub karyawan()
        ComboBox1.Items.Add("ADMIN")
        ComboBox1.Items.Add("USERS")
    End Sub
    Sub tampil_data()
        da = New MySqlDataAdapter("select * from karyawan order by id_karyawan", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "karyawan")
        DataGridView1.DataSource = (ds.Tables("karyawan"))
        nomor()
    End Sub

    Sub nomor()
        Dim DR As DataRow
        Dim x As String
        DR = SQLTable("select max(right(id_karyawan,1)) as nomor from karyawan").Rows(0)
        If DR.IsNull("Nomor") Then
            x = "K-0"
        Else
            x = "K-0" & Format(DR("Nomor") + 1, "0")
        End If
        TextBox1.Text = x
        TextBox1.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Datanya Belum Lengkap")
        Else
            Dim simpan As String
            MsgBox("data anda akan disimpan!")
            simpan = "Insert into karyawan VALUES ('" &
                    TextBox1.Text & "','" &
                    TextBox2.Text & "','" &
                    TextBox3.Text & "','" &
                    ComboBox1.Text & "')"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            kondisiawal()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Maaf datanya tidak ada yang diupdate")
        Else
            koneksiserver()
            MsgBox("Anda akan mengupdate datanya")
            Dim edit As String = "update karyawan set id_karyawan = '" & Me.TextBox1.Text _
                                 & "', username = '" & TextBox2.Text _
                                 & "', password = '" & TextBox3.Text _
                                 & "', status = '" & ComboBox1.Text _
                                 & TextBox1.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            MsgBox("Edit Berhasil")
            kondisiawal()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        kondisiawal()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Maaf datanya tidak ada yang dihapus")
            kondisiawal()
        Else
            If MessageBox.Show("Anda yakin akan menghapus datanya?", "",
                MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String
                hapus = "delete from karyawan where id_karyawan = '" & TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                kondisiawal()
            Else
            End If
        End If
    End Sub
End Class