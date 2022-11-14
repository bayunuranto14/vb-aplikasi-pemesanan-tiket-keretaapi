Imports MySql.Data.MySqlClient

Module koneksi
    Public con As MySqlConnection
    Public cmd As MySqlCommand
    Public ds As DataSet
    Public da As MySqlDataAdapter
    Public rd As MySqlDataReader
    Public db As String

    Public Sub koneksiserver()
        db = "Server=localhost;user id = root;password=;database=db_tiketkereta;Convert Zero Datetime=True"
        con = New MySqlConnection(db)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub testkoneksi()
        db = "Server=localhost;user id = root;password=;database=db_tiketkereta"
        con = New MySqlConnection(db)
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
                MsgBox("Koneksi Tersambung", MsgBoxStyle.Information, "Informasi")
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function SQLTable(ByVal Source As String) As DataTable
        Try
            Dim adp As New MySqlDataAdapter(Source, con)
            Dim DT As New DataTable
            adp.Fill(DT)
            SQLTable = DT
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLTable = Nothing
        End Try
    End Function
End Module
