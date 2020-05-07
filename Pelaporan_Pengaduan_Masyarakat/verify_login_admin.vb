Public Class verify_login_admin

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            Label7.Text = "* Mohon Isi Kode Verifikasi"
            Label7.Visible = True
            TextBox1.Focus()

        Else
            If TextBox1.Text = "1234" Then
                login_admin.Show()
                Me.Close()
                Form1.Hide()
                login_admin.TextBox1.Focus()
            Else
                Label7.Text = "* Kode Verifikasi Salah"
                Label7.Visible = True
                TextBox1.Focus()
                TextBox1.Clear()

            End If
        End If
    End Sub
End Class