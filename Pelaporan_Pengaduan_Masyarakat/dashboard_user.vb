Imports System.Data.OleDb

Public Class dashboard_user

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub dashboard_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call nama()
        Call warna()
        beranda_user.Show()
        beranda_user.MdiParent = Me
        beranda_user.Location = New Point()
        Button2.BackColor = Color.Gainsboro
        Button3.BackColor = Color.White
    End Sub

    Sub nama()
        Call buka()
        query = "select nama from masyarakat where username = @user"
        cmd = New OleDbCommand(query, konek)
        cmd.Parameters.AddWithValue("$user", Form1.TextBox1.Text)
        dr = cmd.ExecuteReader

        If dr.Read Then
            Label2.Text = dr.Item("nama")
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        beranda_user.Show()
        beranda_user.MdiParent = Me
        beranda_user.Location = New Point()
        aduan.Close()
        lihat_tanggapan.Close()
        Button2.BackColor = Color.Gainsboro
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        aduan.Show()
        aduan.MdiParent = Me
        aduan.Location = New Point()
        beranda_user.Close()
        lihat_tanggapan.Close()
        Button2.BackColor = Color.White
        Button3.BackColor = Color.Gainsboro
        Button4.BackColor = Color.White
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form1.Show()
        Me.Close()
        Form1.TextBox1.Focus()
        Form1.TextBox1.Clear()
        Form1.TextBox2.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        lihat_tanggapan.Show()
        lihat_tanggapan.MdiParent = Me
        lihat_tanggapan.Location = New Point()
        beranda_user.Close()
        aduan.Close()
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.Gainsboro
    End Sub
End Class