Public Class ProdukModel
    Dim repository As Repository = Repository.getInstance()
    Dim idProduk As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not checkEmpty(TextBox1, TextBox2, TextBox3) Then
            If Not repository.checkDuplicate(TABLE_PRODUK, "id", TextBox1.Text) Then
                idProduk = TextBox1.Text
                repository.saveData(TABLE_PRODUK, TextBox1, TextBox2, TextBox3)
                Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
                While repository.checkDuplicateInteger(TABLE_GUDANG, "id", kode.ToString)
                    kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
                End While
                repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
            Else
                MsgBox("ID tidak boleh sama.")

            End If
        Else
            MsgBox("Masih ada yang kosong.")
        End If
    End Sub

    Private Sub Produk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
    End Sub
End Class