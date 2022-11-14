Imports MySql.Data.MySqlClient
Public Class Dashboard

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiserver()
        CountPenumpang()
        CountPetugas()
        CountUsers()
        CountTiket()
        Label1.Text = Format(Now, "HH:mm:ss")
        Label2.Text = "WIB"
        Button1.Text = "EXIT"
        Button6.Text = "PETUGAS"
        PanelDashboard.Show()
        ContextMenuStrip = ContextMenuStrip1
    End Sub
    
    Public Sub CountPenumpang()
        Dim daftarpenumpang As Integer
        Dim query = "select COUNT(*) from penumpang"
        cmd = New MySqlCommand(query, con)
        daftarpenumpang = cmd.ExecuteScalar
        LBL_PENUMPANG.Text = daftarpenumpang
    End Sub

    Public Sub CountPetugas()
        Dim cekpetugas As Integer
        Dim query = "select COUNT(*) from petugas"
        cmd = New MySqlCommand(query, con)
        cekpetugas = cmd.ExecuteScalar
        LB_Petugas.Text = cekpetugas
    End Sub

    Public Sub CountUsers()
        Dim cekusers As Integer
        Dim query = "select COUNT(*) from karyawan"
        cmd = New MySqlCommand(query, con)
        cekusers = cmd.ExecuteScalar
        LB_Users.Text = cekusers
    End Sub

    Public Sub CountTiket()
        Dim hitungtiket As Integer
        Dim query = "Select COUNT(*) from tiket"
        cmd = New MySqlCommand(query, con)
        hitungtiket = cmd.ExecuteScalar
        LB_Penumpang.Text = hitungtiket
    End Sub

    Sub hidepanel()
        PanelDashboard.Hide()
    End Sub

    Sub waktu()
        'HR'
        Dim hr As String = TimeOfDay.Hour
        If hr = 1 Then
            hr = "0" + hr
        End If
        If hr = 2 Then
            hr = "0" + hr
        End If
        If hr = 3 Then
            hr = "0" + hr
        End If
        If hr = 4 Then
            hr = "0" + hr
        End If
        If hr = 5 Then
            hr = "0" + hr
        End If
        If hr = 6 Then
            hr = "0" + hr
        End If
        If hr = 7 Then
            hr = "0" + hr
        End If
        If hr = 8 Then
            hr = "0" + hr
        End If
        If hr = 9 Then
            hr = "0" + hr
        End If
        If hr = 0 Then
            hr = "0" + hr
        End If
        'MN'
        Dim mn As String = TimeOfDay.Minute
        If mn = 1 Then
            mn = "0" + mn
        End If
        If mn = 2 Then
            mn = "0" + mn
        End If
        If mn = 3 Then
            mn = "0" + mn
        End If
        If mn = 4 Then
            mn = "0" + mn
        End If
        If mn = 5 Then
            mn = "0" + mn
        End If
        If mn = 6 Then
            mn = "0" + mn
        End If
        If mn = 7 Then
            mn = "0" + mn
        End If
        If mn = 8 Then
            mn = "0" + mn
        End If
        If mn = 9 Then
            mn = "0" + mn
        End If
        If mn = 0 Then
            mn = "0" + mn
        End If
        'SC'
        Dim sc As String = TimeOfDay.Second
        If sc = 1 Then
            sc = "0" + sc
        End If
        If sc = 2 Then
            sc = "0" + sc
        End If
        If sc = 3 Then
            sc = "0" + sc
        End If
        If sc = 4 Then
            sc = "0" + sc
        End If
        If sc = 5 Then
            sc = "0" + sc
        End If
        If sc = 6 Then
            sc = "0" + sc
        End If
        If sc = 7 Then
            sc = "0" + sc
        End If
        If sc = 8 Then
            sc = "0" + sc
        End If
        If sc = 9 Then
            sc = "0" + sc
        End If
        If sc = 0 Then
            sc = "0" + sc
        End If
        Label1.Text = hr + ":" + mn + ":" + sc
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        waktu()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        waktu()
    End Sub

    Private Sub ExitApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitApplicationToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormPemesananTiket.Close()
        CariTiket.Close()
        GantiPassword.Close()
        FormPetugas.Close()
        PanelDashboard.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Apakah Anda Yakin ingin keluar ?? ", "", MessageBoxButtons.YesNo)
        Me.Close()
        FormWelcome.Show()
        MsgBox("Sign Out, Berhasil")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        hidepanel()
        Dim frmpemesanantiket As New FormPemesananTiket
        FormPemesananTiket.MdiParent = Me
        FormPemesananTiket.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        hidepanel()
        Dim search As New CariTiket
        CariTiket.MdiParent = Me
        CariTiket.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        hidepanel()
        Dim listpetugas As New FormPetugas
        FormPetugas.MdiParent = Me
        FormPetugas.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        hidepanel()
        Dim changepassword As New GantiPassword
        GantiPassword.MdiParent = Me
        GantiPassword.Show()
    End Sub


    Private Sub LB_Penumpang_Click(sender As Object, e As EventArgs) Handles LB_Penumpang.Click
        CountTiket()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CountPenumpang()
        CountPetugas()
        CountTiket()
        CountUsers()
        CountTiket()
    End Sub

    Private Sub SignOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignOutToolStripMenuItem.Click
        MessageBox.Show("Apakah Anda Yakin ingin keluar ?? ", "", MessageBoxButtons.YesNo)
        Me.Close()
        FormWelcome.Show()
        MsgBox("Sign Out, Berhasil")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        hidepanel()
        Dim daftarpenumpang As New Penumpang
        penumpang.MdiParent = Me
        Penumpang.Show()
    End Sub

   
    Private Sub LB_Petugas_Click(sender As Object, e As EventArgs) Handles LB_Petugas.Click
        CountPetugas()
    End Sub

    Private Sub LBL_PENUMPANG_Click(sender As Object, e As EventArgs) Handles LBL_PENUMPANG.Click
        CountPenumpang()
    End Sub
End Class