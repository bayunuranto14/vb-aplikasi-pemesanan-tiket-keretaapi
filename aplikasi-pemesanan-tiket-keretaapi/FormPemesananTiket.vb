Imports MySql.Data.MySqlClient

Public Class FormPemesananTiket
    Dim tiket

    Private Sub FormPemesananTiket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TB_Harga.Enabled = False
        koneksiserver()
        stasiun()
        namakereta()
        harga_tiket()
        kelas()
        GroupBox1.Text = ""
        Label2.Text = "DATA PEMESAN"
        Button1.Text = "Simpan Data"
        Button2.Text = "Update / Edit Data"
        Button3.Text = "Hapus Data"
        Button4.Text = "Refresh Data"
        bersih()
    End Sub

    Sub bersih()
        TB_KodeBooking.Text = ""
        TB_NamaPemesan.Text = ""
        CB_NamaKereta.Text = ""
        CB_Class.Text = ""
        CB_StasiunKeberangkatan.Text = ""
        CB_StasiunTujuan.Text = ""
        tampil_data()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Sub tampil_data()
        da = New MySqlDataAdapter("select * from tiket order by kode_booking", con)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "tiket")
        Me.DataGridView1.DataSource = (ds.Tables("tiket"))

       
        nomor()
    End Sub



    Sub namakereta()
        CB_NamaKereta.Items.Add("Argo Anggrek")
        CB_NamaKereta.Items.Add("Argo Lawu")
        CB_NamaKereta.Items.Add("Argo Dwipangga")
        CB_NamaKereta.Items.Add("Argo Sindoro")
        CB_NamaKereta.Items.Add("Argo Muria")
        CB_NamaKereta.Items.Add("Argo Jati")
        CB_NamaKereta.Items.Add("Argo Parahyangan")
        CB_NamaKereta.Items.Add("Argo Gajayana")
        CB_NamaKereta.Items.Add("Bima")
        CB_NamaKereta.Items.Add("Taksaka")
        CB_NamaKereta.Items.Add("Gumarang")
        CB_NamaKereta.Items.Add("Menoreh")
        CB_NamaKereta.Items.Add("Senja Utama Yogya")
        CB_NamaKereta.Items.Add("Sawunggalih")
        CB_NamaKereta.Items.Add("Bogowonto")
        CB_NamaKereta.Items.Add("Progo")
    End Sub
    Sub harga_tiket()
        Select Case CB_NamaKereta.Text
            Case "Argo Anggrek"
                TB_Harga.Text = FormatCurrency(300000)
            Case "Argo Lawu"
                TB_Harga.Text = FormatCurrency(250000)
            Case "Argo Dwipangga"
                TB_Harga.Text = FormatCurrency(250000)
            Case "Argo Sindoro"
                TB_Harga.Text = FormatCurrency(200000)
            Case "Argo Muria"
                TB_Harga.Text = FormatCurrency(200000)
            Case "Argo Jati"
                TB_Harga.Text = FormatCurrency(100000)
            Case "Argo Parahyangan"
                TB_Harga.Text = FormatCurrency(60000)
            Case "Argo Gajayana"
                TB_Harga.Text = FormatCurrency(330000)
            Case "Bima"
                TB_Harga.Text = FormatCurrency(330000)
            Case "Taksaka"
                TB_Harga.Text = FormatCurrency(230000)
            Case "Gumarang"
                TB_Harga.Text = FormatCurrency(240000)
            Case "Menoreh"
                TB_Harga.Text = FormatCurrency(90000)
            Case "Senja Utama Yogya"
                TB_Harga.Text = FormatCurrency(140000)
            Case "Sawunggalih"
                TB_Harga.Text = FormatCurrency(180000)
            Case "Bogowonto"
                TB_Harga.Text = FormatCurrency(90000)
            Case "Progo"
                TB_Harga.Text = FormatCurrency(75000)
        End Select

    End Sub

    Sub kelas()
        Dim kelas As Array = {"Eksekutif", "Bisnis", "Ekonomi"}
        For i As Integer = 0 To 2
            CB_Class.Items.Add(kelas(i))
        Next
    End Sub

    Sub stasiun()
        Dim stasiun As Array = {"Stasiun Gambir (Jakarta)", "Stasiun Bandung (BD)", "Stasiun Yogyakarta (YK)", "Stasiun Lempuyangan (LMP)", "Stasiun Surabaya Gubeng (SBE)", "Stasiun Surabaya Pasar Turi (SBI)"}
        For i As Integer = 0 To 5
            CB_StasiunKeberangkatan.Items.Add(stasiun(i))
            CB_StasiunTujuan.Items.Add(stasiun(i))
        Next
    End Sub

    Sub nomor()
        Dim DR As DataRow
        Dim tiket As String
        DR = SQLTable("select max(right(kode_booking,1)) as nomor from tiket").Rows(0)
        If DR.IsNull("Nomor") Then
            tiket = "NRT00-1" 'member nilai awal
        Else
            tiket = "NRT-" & Format(DR("Nomor") + 1, "0")
        End If
        TB_KodeBooking.Text = tiket
        TB_KodeBooking.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'simpan data
        If Me.TB_KodeBooking.Text = "" Or Me.TB_NamaPemesan.Text = "" Or Me.DateTimePicker1.Text = "" Or Me.CB_NamaKereta.Text = "" Or Me.CB_Class.Text = "" Or
            Me.CB_StasiunKeberangkatan.Text = "" Or Me.CB_StasiunTujuan.Text = "" Or Me.TB_Harga.Text = "" Or Me.DateTimePicker2.Text = "" Then
            MsgBox("Maaf datanya belum lengkap")
        Else
            Dim simpan As String
            MsgBox("data anda akan disimpan!")
            simpan = "INSERT INTO tiket (kode_booking, nama_pemesan, tanggal_lahir, nama_kereta, class, stasiun_keberangkatan, stasiun_tujuan, harga_tiket, tanggal_keberangkatan)VALUES ('" &
                TB_KodeBooking.Text & "','" &
                TB_NamaPemesan.Text & "','" &
                Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") & "','" &
                CB_NamaKereta.Text & "','" &
                CB_Class.Text & "','" &
                CB_StasiunKeberangkatan.Text & "','" &
                CB_StasiunTujuan.Text & "','" &
                TB_Harga.Text & "','" &
                Format(Me.DateTimePicker2.Value, "yyyy-MM-dd") &
                "')"

            cmd = New MySql.Data.MySqlClient.MySqlCommand(simpan, con)
            cmd.ExecuteNonQuery()
            bersih()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        tiket = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TB_KodeBooking.Text = tiket
        TB_NamaPemesan.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        CB_NamaKereta.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        CB_Class.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        CB_StasiunKeberangkatan.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        CB_StasiunTujuan.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TB_Harga.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        DateTimePicker2.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value

        Me.Button1.Enabled = False
        Me.Button2.Enabled = True
        Me.Button3.Enabled = True
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'edit data
        If TB_KodeBooking.Text = "" Or TB_NamaPemesan.Text = "" Or DateTimePicker1.Text = "" Or CB_Class.Text = "" Or CB_NamaKereta.Text = "" Or CB_StasiunKeberangkatan.Text = "" Or CB_StasiunTujuan.Text = "" Or TB_Harga.Text = "" Or DateTimePicker2.Text = "" Then
            MsgBox("Maaf datanya tidak ada yang diupdate")
        Else
            Call koneksiserver()
            MsgBox("Anda akan mengupdate datanya")
            Dim edit As String = "update tiket set kode_booking ='" & Me.TB_KodeBooking.Text _
                                 & "', nama_pemesan = '" & Me.TB_NamaPemesan.Text _
                                 & "', tanggal_lahir ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") _
                                 & "', nama_kereta ='" & Me.CB_NamaKereta.Text _
                                 & "', class ='" & Me.CB_Class.Text _
                                 & "', stasiun_keberangkatan ='" & Me.CB_StasiunKeberangkatan.Text _
                                 & "', stasiun_tujuan ='" & Me.CB_StasiunTujuan.Text _
                                 & "', harga_tiket ='" & Me.TB_Harga.Text _
                                  & "', tanggal_keberangkatan ='" & Format(DateTimePicker2.Value, "yyyy-MM-dd") _
                                 & "' where kode_booking = '" _
                                 & Me.TB_KodeBooking.Text & "'"
            cmd = New MySqlCommand(edit, con)
            cmd.ExecuteNonQuery()
            MsgBox("Edit Berhasil")
            bersih()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        bersih()
    End Sub


    Private Sub CB_NamaKereta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_NamaKereta.SelectedIndexChanged
        Call harga_tiket()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TB_KodeBooking.Text = "" Or TB_NamaPemesan.Text = "" Or DateTimePicker1.Text = "" Or CB_Class.Text = "" Or CB_NamaKereta.Text = "" Or CB_StasiunKeberangkatan.Text = "" Or CB_StasiunTujuan.Text = "" Or TB_Harga.Text = "" Or DateTimePicker2.Text = "" Then
            MsgBox("Maaf, Datanya tidak ada yang dihapus ")
            bersih()
        Else
            If MessageBox.Show("Anda yakin akan menghapus datanya ??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete from tiket where kode_booking = '" & Me.TextBox1.Text & "'"
                cmd = New MySqlCommand(hapus, con)
                cmd.ExecuteNonQuery()
                bersih()
            End If
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        bersih()
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
    
End Class