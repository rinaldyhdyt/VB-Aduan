Imports System.Data.OleDb

Public Class daftar_tugas

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call buka()
        query = "INSERT into petugas values (@id, @nama, @user, @pass, @telp, 'petugas')"
        cmd = New OleDbCommand(query, konek)
        With cmd.Parameters
            .AddWithValue("$id", Label9.Text)
            .AddWithValue("$nama", TextBox2.Text)
            .AddWithValue("$user", TextBox3.Text)
            .AddWithValue("$pass", TextBox4.Text)
            .AddWithValue("$telp", TextBox5.Text)
        End With

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            konek.Close()
            MsgBox("Daftar Berhasil", MsgBoxStyle.Information, "Berhasil")
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()

            Me.Controls.Clear()
            InitializeComponent()
            daftar_tugas_Load(e, e)
            Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub daftar_tugas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call id()
        TextBox4.UseSystemPasswordChar = True
    End Sub

    Sub id()
        Call buka()
        Dim nomor As Integer

        Try
            query = "select id_petugas from petugas order by id_petugas desc"
            cmd = New OleDbCommand(query, konek)
            dr = cmd.ExecuteReader

            If dr.Read Then
                nomor = dr.Item("id_petugas")
                nomor = nomor + 1
                Label9.Text = nomor
            Else
                Label9.Text = "1"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox4.UseSystemPasswordChar = False
        Else
            TextBox4.UseSystemPasswordChar = True
        End If
    End Sub
End Class