Imports System.Data.OleDb

Public Class daftar_admin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        query = "select * from petugas where username = @us"
        cmd = New OleDbCommand(query, konek)
        cmd.Parameters.AddWithValue("$us", TextBox3.Text)
        dr = cmd.ExecuteReader
        dr.Read()

        If Not dr.HasRows Then
            Call buka()
            query = "INSERT into petugas values (@id, @nama, @user, @pass, @telp, 'admin')"
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
                daftar_admin_Load(e, e)
                Refresh()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            Label10.Text = "* Username sudah terpakai!"
            Label10.Visible = True
        End If
        
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
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

    Private Sub daftar_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        login_admin.Show()
        Me.Close()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox4.UseSystemPasswordChar = False
        Else
            TextBox4.UseSystemPasswordChar = True
        End If
    End Sub
End Class