Public Class beranda_user

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        aduan.Show()
        aduan.MdiParent = dashboard_user
        aduan.Location = New Point()
        dashboard_user.Button2.BackColor = Color.White
        dashboard_user.Button3.BackColor = Color.Gainsboro
    End Sub
End Class