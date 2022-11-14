Imports MySql.Data.MySqlClient

Public Class FormPetugas
    Dim petugas As String

    Private Sub FormPetugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiserver()
        GroupBox1.Text = ""
        Button1.Text = "Simpan Data"
        Button2.Text = "Update / Edit Data"
        Button3.Text = "Hapus Data"
        Button4.Text = "Refresh Data"
        kondisiawal()

    End Sub
    Sub kuncisemua()
        Me.Button1.Enabled = False
        Me.Button2.Enabled = False
        Me.Button3.Enabled = False
        Me.Button4.Enabled = False

        TextBox1.Enabled = False
        TextBox5.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
    End Sub

    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        tampil_data()

    End Sub

    Sub tampil_data()
        da = New MySqlDataAdapter("select * from petugas order by id_petugas", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "petugas")
        Me.DataGridView1.DataSource = (ds.Tables("petugas"))
        nomor()
    End Sub


    Sub nomor()
        Dim DR As DataRow
        Dim s As String
        DR = SQLTable("select max(right(id_petugas,1)) as nomor from petugas").Rows(0)
        'jika berisi null atau tidak ditemukan
        If DR.IsNull("Nomor") Then
            s = "0" 'member nilai awal
        Else
            s = "0" & Format(DR("Nomor") + 1, "0")
        End If
        TextBox1.Text = s
        TextBox1.Enabled = False
    End Sub

    

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        petugas = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = petugas
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        Me.Button1.Enabled = False
        Me.Button2.Enabled = True
        Me.Button3.Enabled = True
        Me.Button4.Enabled = True
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        kondisiawal()
    End Sub

   
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        da = New MySqlDataAdapter("select * from petugas where nama_petugas like '%" _
                                  & Me.TextBox5.Text & "%'", con)
        ds = New DataSet
        'ds.Clear()
        da.Fill(ds, "petugas")
        DataGridView1.DataSource = (ds.Tables("petugas"))
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Me.Button1.Enabled = True
        Me.Button2.Enabled = True
        Me.Button3.Enabled = True
        Me.Button4.Enabled = True
        TextBox1.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox6.Enabled = True
    End Sub

    Private Sub DataGridView1_CellClick2(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        petugas = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = petugas
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        Me.Button1.Enabled = False
        Me.Button2.Enabled = True
        Me.Button3.Enabled = True
        Me.Button4.Enabled = True
    End Sub

    
    
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        'edit data
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Maaf datanya tidak ada yang diupdate")
        Else
            MsgBox("Anda akan mengupdate datanya")
            Dim edit As String = "update petugas set id_petugas ='" & Me.TextBox1.Text _
                                 & "', nama_petugas = '" & Me.TextBox2.Text _
                                 & "', jenis_kelamin ='" & Me.TextBox3.Text _
                                 & "', jabatan ='" & Me.TextBox4.Text _
                                 & "', daerah_operasional = '" & Me.TextBox6.Text _
                                  & "', alamat = '" & Me.TextBox7.Text _
                                 & "' where id_petugas = '" _
                                 & Me.TextBox1.Text & "'"

            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            MsgBox("Edit Berhasil")
            kondisiawal()
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" _
           Or Me.TextBox6.Text = "" Then
            MsgBox("Maaf, Datanya tidak ada yang dihapus ")
            kondisiawal()
        Else
            If MessageBox.Show("Anda yakin akan menghapus datanya ??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete from petugas where id_petugas = '" & Me.TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                kondisiawal()
            Else
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'simpan data
        If Me.TextBox1.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.TextBox4.Text = "" Or Me.TextBox6.Text = "" Then
            MsgBox("Maaf datanya belum lengkap")
        Else
            Dim simpan As String
            MsgBox("data anda akan disimpan!")
            simpan = "Insert into petugas (id_petugas,nama_petugas,jenis_kelamin,jabatan,daerah_operasional,alamat) values('" & Me.TextBox1.Text _
            & "','" & Me.TextBox2.Text & "','" & Me.TextBox3.Text & "','" & Me.TextBox4.Text & "','" & Me.TextBox6.Text & "','" & Me.TextBox7.Text & "')"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            kondisiawal()
        End If
    End Sub
End Class