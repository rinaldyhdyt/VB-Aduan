Imports System.Data.OleDb

Public Class dash_petugas

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub dash_petugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dashboard_petugas_adu.Show()
        dashboard_petugas_adu.MdiParent = Me
        dashboard_petugas_adu.Location = New Point()
        Button2.BackColor = Color.Gainsboro
        Call nama()
        Call warna()
    End Sub

    Sub nama()
        Call buka()
        query = "select nama_petugas from petugas where username = @user"
        cmd = New OleDbCommand(query, konek)
        cmd.Parameters.AddWithValue("$user", login_admin.TextBox1.Text)
        dr = cmd.ExecuteReader

        If dr.Read Then
            Label2.Text = dr.Item("nama_petugas")
        End If
    End Sub

    Sub warna()
        Dim c As Control
        For Each c In Me.Controls
            If TypeOf c Is MdiClient Then
                c.BackColor = Color.White
            End If
        Next
    End Sub
End Class