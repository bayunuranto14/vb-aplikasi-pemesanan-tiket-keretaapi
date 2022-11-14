Imports MySql.Data.MySqlClient

Public Class FormKaryawan

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sembunyi()
        Dim search As New CariTiket
        CariTiket.MdiParent = Me
        CariTiket.Show()

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

    Private Sub FormKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiserver()
        sembunyi()
        Button1.Text = "Sign Out ??"
        waktu()
    End Sub

    Sub sembunyi()
        PanelDashboard.Hide()
    End Sub

    Sub muncul()
        PanelDashboard.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        muncul()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormWelcome.Show()
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        waktu()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        muncul()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        waktu()
    End Sub

  
End Class