Imports System.Data.OleDb
Imports System.IO

Public Class pengaduan_admin_dash

    Private Sub pengaduan_admin_dash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call data()
        Call grid()
        Call id()
        Call id_tug()
    End Sub

    Sub data()
        Call buka()
        query = "select *from pengaduan order by id_pengaduan asc"
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
                .Columns(1).HeaderText = "Tanggal"
                .Columns(2).HeaderText = "NIK"
                .Columns(3).HeaderText = "Nama"
                .Columns(4).HeaderText = "Laporan"
                .Columns(5).HeaderText = "Foto"
                .Columns(6).HeaderText = "Status"
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
                Label5.Text = .Cells(3).Value
                Label6.Text = .Cells(2).Value
                TextBox1.Text = .Cells(4).Value

                Dim b As MemoryStream
                b = New IO.MemoryStream(CType(DataGridView1.Item(5, DataGridView1.CurrentRow.Index).Value, Byte()))
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                PictureBox1.Image = Image.FromStream(b)
            End With

            Label3.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            TextBox2.Enabled = True
        Catch ex As Exception
            MsgBox("Tidak Ada Data Yang Di Pilih !", MsgBoxStyle.Critical, "Perhatian !")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox2.Text = "" Then
            Label10.Text = "* Mohon Isi Kolom!"
            Label10.Visible = True
        Else
            Call buka()

            query = "INSERT into tanggapan (id_tanggapan, id_pengaduan, tgl_tanggapan, tanggapan, id_petugas) values (@id_tanggap, @id_adu, @tgl, @tanggapan, @id_tugas)"
            cmd = New OleDbCommand(query, konek)
            With cmd.Parameters
                .AddWithValue("$id_tanggap", Label11.Text)
                .AddWithValue("$id_adu", Label3.Text)
                .AddWithValue("$tgl", Date.Now.ToString("yy/MM/dd-HH:mm:ss"))
                .AddWithValue("$tanggapan", TextBox2.Text)
                .AddWithValue("$id_tugas", Label12.Text)
                
            End With

            Try
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                konek.Close()
                Dim pilih = MessageBox.Show("Tanggapan Berhasil Dikirim!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If pilih = Windows.Forms.DialogResult.OK Then
                    Call buka()
                    query = "update pengaduan set [status] = '" & Label13.Text & "' where [id_pengaduan] = @id_adu"
                    cmd = New OleDbCommand(query, konek)
                    cmd.Parameters.AddWithValue("$id_adu", Label3.Text)

                    Try
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        konek.Close()
                        Call data()

                        Me.Controls.Clear()
                        InitializeComponent()
                        pengaduan_admin_dash_Load(e, e)
                        Refresh()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
                TextBox2.Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub id()
        Call buka()
        Dim nomor As Integer

        Try
            query = "select id_tanggapan from tanggapan order by id_tanggapan desc"
            cmd = New OleDbCommand(query, konek)
            dr = cmd.ExecuteReader

            If dr.Read Then
                nomor = dr.Item("id_tanggapan")
                nomor = nomor + 1
                Label11.Text = nomor
            Else
                Label11.Text = "1"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub id_tug()
        Call buka()
        query = "select id_petugas from petugas where username = '" & login_admin.TextBox1.Text & "'"
        cmd = New OleDbCommand(query, konek)
        dr = cmd.ExecuteReader
        dr.Read()

        If dr.HasRows Then
            Label12.Text = dr.Item("id_petugas")
        End If
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        query = "DELETE * FROM pengaduan where id_pengaduan = @id"
        cmd = New OleDbCommand(query, konek)
        cmd.Parameters.AddWithValue("$id", Label3.Text)

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Dim pilih = MessageBox.Show("Data Berhasil Di Hapus !", "Berhasil !", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub clear()
        Label3.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        TextBox1.Clear()
        PictureBox1.Image = Nothing
    End Sub
End Class