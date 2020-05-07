Imports System.Data.OleDb

Public Class aduan

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call buka()
        query = "INSERT into pengaduan values (@id, @tgl, @nik, @nama, @isi, @foto, 'proses')"
        cmd = New OleDbCommand(query, konek)
        With cmd.Parameters
            .AddWithValue("$id", Label7.Text)
            .AddWithValue("$tgl", Date.Now.ToString("yy/MM/dd-hh:mm:ss"))
            .AddWithValue("$nik", TextBox1.Text)
            .AddWithValue("$nama", TextBox3.Text)
            .AddWithValue("$isi", TextBox2.Text)

            If OpenFileDialog1.FileName = Nothing Then
                MsgBox("Harap Pilih Gambar yang Sesuai !", MsgBoxStyle.Information, "Perhatian !")
            Else
                .AddWithValue("@foto", IO.File.ReadAllBytes(OpenFileDialog1.FileName))
            End If

        End With

        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            konek.Close()
            MsgBox("Pengaduan Berhasil Dikirim dan Sedang Di Tinjau!", MsgBoxStyle.Information, "Berhasil")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            PictureBox1.Image = Nothing

            Me.Controls.Clear()
            InitializeComponent()
            aduan_Load(e, e)
            Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub id()
        Call buka()
        Dim nomor As Integer

        Try
            query = "select id_pengaduan from pengaduan order by id_pengaduan desc"
            cmd = New OleDbCommand(query, konek)
            dr = cmd.ExecuteReader

            If dr.Read Then
                nomor = dr.Item("id_pengaduan")
                nomor = nomor + 1
                Label7.Text = nomor
            Else
                Label7.Text = "1"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim lokasi As String
        OpenFileDialog1.Filter = "JPG Files (*.jpg) | *.jpg | JPEG Files (*.jpeg) | *.jpeg | PNG Files (*.png) | *.png"
        OpenFileDialog1.FileName = ""
        lokasi = OpenFileDialog1.FileName

        Try
            If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image = New Bitmap(OpenFileDialog1.FileName)
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub aduan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call id()
    End Sub

End Class