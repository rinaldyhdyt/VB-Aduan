Imports System.Data.OleDb

Public Class daftar

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        TextBox1.Focus()
        TextBox4.UseSystemPasswordChar = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox4.UseSystemPasswordChar = False
        Else
            TextBox4.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Show()
        Me.Hide()
        Form1.clear()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call buka()
        query = "select *from masyarakat where nik = @nomor"
        cmd = New OleDbCommand(query, konek)
        cmd.Parameters.AddWithValue("$nomor", TextBox1.Text)
        dr = cmd.ExecuteReader
        dr.Read()

        If Not dr.HasRows Then
            query = "select *from masyarakat where username = @us"
            cmd = New OleDbCommand(query, konek)
            cmd.Parameters.AddWithValue("$us", TextBox3.Text)
            dr = cmd.ExecuteReader
            dr.Read()

            If Not dr.HasRows Then
                Call buka()
                query = "insert into masyarakat values (@nik, @nama, @user, @pass, @telp)"
                cmd = New OleDbCommand(query, konek)
                With cmd.Parameters
                    .AddWithValue("$nik", TextBox1.Text)
                    .AddWithValue("$nama", TextBox2.Text)
                    .AddWithValue("$user", TextBox3.Text)
                    .AddWithValue("$pass", TextBox4.Text)
                    .AddWithValue("$telp", TextBox5.Text)
                End With

                Try
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    konek.Close()
                    MsgBox("Daftar Berhasil!", MsgBoxStyle.Information, "Berhasil !")
                    Form1.Show()
                    Me.Close()
                    Form1.TextBox1.Focus()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                Label9.Text = "* Username ini sudah dipakai!"
                Label9.Visible = True
                TextBox3.Focus()
            End If
        Else
            Label9.Text = "* Akun ini sudah ada!"
            Label9.Visible = True
        End If
    End Sub
End Class