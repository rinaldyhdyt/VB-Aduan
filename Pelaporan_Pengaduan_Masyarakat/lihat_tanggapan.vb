Imports System.Data.OleDb
Imports System.IO

Public Class lihat_tanggapan

    Private Sub lihat_tanggapan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call data()
        Call grid()
    End Sub

    Sub data()
        Call buka()
        query = "SELECT pengaduan.id_pengaduan, pengaduan.nik, pengaduan.nama, pengaduan.isi_laporan, pengaduan.foto, pengaduan.status, tanggapan.id_tanggapan, tanggapan.tanggapan FROM pengaduan INNER JOIN tanggapan ON pengaduan.id_pengaduan = tanggapan.id_pengaduan"
        da = New OleDbDataAdapter(query, konek)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub

    Sub grid()
        Try
            With DataGridView1
                .Columns(0).HeaderText = "ID Pengaduan"
                .Columns(1).HeaderText = "NIK"
                .Columns(2).HeaderText = "Nama"
                .Columns(3).HeaderText = "Isi Laporan"
                .Columns(4).HeaderText = "Foto"
                .Columns(5).HeaderText = "Status"
                .Columns(6).HeaderText = "ID Tanggapan"
                .Columns(7).HeaderText = "Tanggapan"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Try
            Dim a As Integer
            a = Me.DataGridView1.CurrentRow.Index
            With DataGridView1.Rows.Item(a)
                Label3.Text = .Cells(0).Value
                Label5.Text = .Cells(2).Value
                Label6.Text = .Cells(1).Value
                TextBox1.Text = .Cells(3).Value
                TextBox2.Text = .Cells(7).Value

                Dim b As MemoryStream
                b = New IO.MemoryStream(CType(DataGridView1.Item(4, DataGridView1.CurrentRow.Index).Value, Byte()))
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                PictureBox1.Image = Image.FromStream(b)
            End With

            Label3.Visible = True
            Label5.Visible = True
            Label6.Visible = True

            If TextBox2.Text = "" Then
                Label11.Visible = True
            Else
                Label11.Visible = False
            End If
        Catch ex As Exception
            MsgBox("Tidak Ada Data Yang Di Pilih !", MsgBoxStyle.Critical, "Perhatian !")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        query = "DELETE * FROM pengaduan where id_pengaduan = @id"
        cmd = New OleDbCommand(query, konek)
        cmd.Parameters.AddWithValue("$id", Label3.Text)

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Dim pilih = MessageBox.Show("Data Berhasil Di Hapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If pilih = Windows.Forms.DialogResult.OK Then
                query = "delete * from tanggapan where id_pengaduan = @id"
                cmd = New OleDbCommand(query, konek)
                cmd.Parameters.AddWithValue("$id", Label3.Text)

                Try
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    konek.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            Call clear()
            Call data()
            Label11.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub clear()
        Label3.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        TextBox1.Clear()
        TextBox2.Clear()
        PictureBox1.Image = Nothing
    End Sub
End Class