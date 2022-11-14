Imports MySql.Data.MySqlClient
Public Class CariTiket

    Private Sub CariTiket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiserver()
        DataGridView1.ReadOnly = True
    End Sub

    Sub tampil_data()
        da = New MySqlDataAdapter("select * from tiket order by kode_booking", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tiket")
        Me.DataGridView1.DataSource = (ds.Tables("tiket"))

    End Sub

   
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call tampil_data()
        da = New MySqlDataAdapter("select * from tiket where nama_pemesan like '%" _
                                  & Me.TextBox1.Text & "%'", con)
        ds = New DataSet
        'ds.Clear()
        da.Fill(ds, "tiket")
        DataGridView1.DataSource = (ds.Tables("tiket"))
       
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
      
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub
End Class