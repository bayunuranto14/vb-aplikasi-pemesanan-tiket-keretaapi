Imports MySql.Data.MySqlClient

Public Class Penumpang

    Private Sub Penumpang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kondisiawal()
    End Sub
    Sub kondisiawal()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        tampil_data()
    End Sub

    Sub tampil_data()
        da = New MySqlDataAdapter("select * from penumpang order by id_penumpang", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "penumpang")
        Me.DataGridView1.DataSource = (ds.Tables("penumpang"))
        nomor()
    End Sub

    Sub nomor()
        Dim DR As DataRow
        Dim pnp As String
        DR = SQLTable("select max(right(id_penumpang,1)) as nomor from penumpang").Rows(0)
        If DR.IsNull("Nomor") Then
            pnp = "0-1" 'member nilai awal
        Else
            pnp = "0-" & Format(DR("Nomor") + 1, "0")
        End If
        TextBox2.Text = pnp
        TextBox2.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value

        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Data Belum Lengkap")
        Else
            Dim simpan As String
            MsgBox("data anda akan disimpan!")
            simpan = "INSERT into penumpang (id_penumpang,nama_penumpang,alamat,no_identitas) VALUES('" &
                TextBox2.Text & "','" &
                TextBox3.Text & "','" &
                TextBox4.Text & "','" &
                TextBox5.Text & "')"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            kondisiawal()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call tampil_data()
        da = New MySqlDataAdapter("select * from penumpang where nama_penumpang like '%" _
                                  & Me.TextBox1.Text & "%'", con)
        ds = New DataSet
        'ds.Clear()
        da.Fill(ds, "penumpang")
        DataGridView1.DataSource = (ds.Tables("penumpang"))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kondisiawal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Tidak ada yang di update datanya")
        Else
            koneksiserver()
            MsgBox("Anda akan mengupdate datanya")
            Dim edit As String = "update penumpang set id_penumpang = '" & Me.TextBox2.Text _
                                 & "', nama_penumpang = '" & Me.TextBox3.Text _
                                 & "', alamat = '" & Me.TextBox4.Text _
                                 & "', no_identitas = '" & Me.TextBox5.Text _
                                 & "' where id_penumpang = '" _
                                 & Me.TextBox2.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            MsgBox("Edit Berhasil")
            kondisiawal()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Maaf, Data tidak ada yang dihapus")
            kondisiawal()
        Else
            If MessageBox.Show("Anda yakin akan menghapus datanya ??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete from penumpang where id_penumpang ='" & Me.TextBox2.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                kondisiawal()
            End If

        End If
    End Sub
End Class