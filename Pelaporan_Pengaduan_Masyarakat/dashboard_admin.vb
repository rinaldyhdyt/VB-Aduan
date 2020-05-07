Imports System.Data.OleDb

Public Class dashboard_admin

    Private Sub dashboard_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call warna()
        Call nama()
        pengaduan_admin_dash.Show()
        pengaduan_admin_dash.MdiParent = Me
        pengaduan_admin_dash.Location = New Point()
        Button2.BackColor = Color.Gainsboro
        Button3.BackColor = Color.White
    End Sub

    Sub warna()
        Dim c As Control
        For Each c In Me.Controls
            If TypeOf c Is MdiClient Then
                c.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        login_admin.Show()
        Me.Close()

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pengaduan_admin_dash.Show()
        pengaduan_admin_dash.MdiParent = Me
        pengaduan_admin_dash.Location = New Point()
        Button2.BackColor = Color.Gainsboro
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        daftar_tugas.Close()
        report.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        daftar_tugas.Show()
        daftar_tugas.MdiParent = Me
        daftar_tugas.Location = New Point()
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.Gainsboro
        pengaduan_admin_dash.Close()
        report.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        report.Show()
        report.MdiParent = Me
        report.Location = New Point()
        Button2.BackColor = Color.White
        Button3.BackColor = Color.Gainsboro
        Button4.BackColor = Color.White
        pengaduan_admin_dash.Close()
        daftar_tugas.Close()
    End Sub
End Class