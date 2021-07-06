Public Class Sales
    Dim repository As Repository = Repository.getInstance()
    Dim listPesanan As New List(Of OrderDetail)()
    Dim selectedProduct As Prod
    Dim total As Integer = 0
    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox6.Text = retrieveProduct(TextBox5.Text)
    End Sub

    Private Function retrieveProduct(id As String) As String
        selectedProduct = repository.retrieveProduct(id)
        Return selectedProduct.nama
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim entryDetail As New OrderDetail(selectedProduct.nama, TextBox1.Text, selectedProduct.id, TextBox7.Text, CInt(TextBox7.Text) * selectedProduct.harga, selectedProduct.harga)
        listPesanan.Add(entryDetail)
        populateList()
    End Sub

    Private Sub populateList()
        ListView1.Items.Clear()
        For Each pesanan In listPesanan
            ListView1.Items.Add(New ListViewItem(New String() {pesanan.id_produk, pesanan.nama, pesanan.harga, pesanan.jumlah, pesanan.total}))
            total = total + pesanan.total
        Next
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        repository.saveData(TABLE_ORDER, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, "0", "0", total.ToString)
        repository.saveMultipleData(TABLE_ORDER_DETAIL, listPesanan)
    End Sub
End Class