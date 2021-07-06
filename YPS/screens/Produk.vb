Public Class ProdukModel
    Dim repository As Repository = Repository.getInstance()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not checkEmpty(TextBox1, TextBox2, TextBox3) Then
            If Not repository.checkDuplicate(TABLE_PRODUK, "id", TextBox1.Text) Then
                repository.saveData(TABLE_PRODUK, TextBox1, TextBox2, TextBox3)
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