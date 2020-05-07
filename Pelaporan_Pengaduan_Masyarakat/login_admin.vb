Imports System.Data.OleDb

Public Class login_admin

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        daftar_admin.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call buka()
        query = "select *from petugas where username = @user and password = @pass"
        cmd = New OleDbCommand(query, konek)
        With cmd.Parameters
            .AddWithValue("$user", TextBox1.Text)
            .AddWithValue("$pass", TextBox2.Text)
        End With

        dr = cmd.ExecuteReader
        dr.Read()

        If TextBox1.Text = "" Then
            Label7.Text = "* Mohon Isi Kolom Username !"
            Label7.Visible = True
            TextBox1.Focus()
        ElseIf TextBox2.Text = "" Then
            Label7.Text = "* Mohon Isi Kolom Password !"
            Label7.Visible = True
            TextBox2.Focus()
        Else
            If dr.HasRows Then
                Dim level As String
                level = dr.Item("level")

                If level = "admin" Then
                    dashboard_admin.Show()
                    Me.Close()
                ElseIf level = "petugas" Then
                    dash_petugas.Show()
                    Me.Close()
                End If
            Else
                Label7.Text = "* Anda Belum Terdaftar !"
                Label7.Visible = True
                TextBox1.Focus()
                Call clear()

            End If
        End If
    End Sub

    Sub clear()
        TextBox1.Clear()
        TextBox2.Clear()

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
End Class