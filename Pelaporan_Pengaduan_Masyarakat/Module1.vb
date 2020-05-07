Imports System.Data.OleDb

Module Module1
    Public konek As OleDbConnection
    Public cmd As OleDbCommand
    Public dr As OleDbDataReader
    Public da As OleDbDataAdapter
    Public ds As DataSet
    Public query As String

    Public Sub buka()
        Try
            query = "Provider = Microsoft.JET.OLEDB.4.0; Data source = pengaduan.mdb"
            konek = New OleDbConnection(query)

            If konek.State = ConnectionState.Closed Then
                konek.Open()
            End If
        Catch ex As Exception
            MsgBox("Koneksi Terputus !", MsgBoxStyle.Critical, "Preingatan!")
        End Try
    End Sub
End Module
