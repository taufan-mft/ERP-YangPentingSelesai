Public Class Gudang
    Dim repository As Repository = Repository.getInstance()
    Dim listUnfullOrder As New List(Of Order)()
    Dim listNeeded As New List(Of Needed)()
    Dim listProduk As New List(Of Prod)()
    Private Sub Gudang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchData()
    End Sub

    Private Sub fetchData()
        listUnfullOrder.Clear()
        listProduk.Clear()
        listNeeded.Clear()
        ListView1.Items.Clear()
        repository.showData($"SELECT {TABLE_GUDANG}.id, {TABLE_PRODUK}.nama, {TABLE_GUDANG}.jumlah FROM  {TABLE_GUDANG} INNER JOIN {TABLE_PRODUK} ON {TABLE_GUDANG}.id_produk={TABLE_PRODUK}.id WHERE direction='in'", DataGridView1)
        repository.showData($"SELECT {TABLE_GUDANG}.id, {TABLE_PRODUK}.nama, {TABLE_GUDANG}.jumlah FROM  {TABLE_GUDANG} INNER JOIN {TABLE_PRODUK} ON {TABLE_GUDANG}.id_produk={TABLE_PRODUK}.id WHERE direction='out'", DataGridView2)
        listUnfullOrder = repository.retrieveUnpaidOrders(fullfilled:=False)
        listProduk = repository.retrieveProducts()
        populateNeeded()
    End Sub

    Private Sub populateNeeded()
        For Each prod In listProduk
            Dim total As Integer = 0
            For Each order In listUnfullOrder
                total = total + repository.retrieveProductCount(prod.id, order.id)
            Next
            Debug.WriteLine(prod.nama + " " + total.ToString)
            If total > 0 Then
                total = total - repository.getProductWarehouseCount(prod.id)
                If total > 0 Then
                    Dim needed As New Needed(prod.nama, total, prod.id)
                    listNeeded.Add(needed)
                End If
            End If
            'Dim indexOfMyApple = list.FindIndex(Function(apple) myApple.Equals(apple))
        Next

        For Each entry In listNeeded
            ListView1.Items.Add(New ListViewItem(New String() {entry.name, entry.jumlah}))
        Next
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each entry In listUnfullOrder
            Dim listProduct As List(Of OrderDetail) = repository.retrieveOrderDetail(entry.id)
            Dim kode As Integer = repository.getLargestId(TABLE_GUDANG) + 1
            For Each order In listProduct
                repository.saveData(TABLE_GUDANG, kode, order.id_produk, order.jumlah, DIRECTION_OUT)
            Next
            repository.updateData(TABLE_ORDER, "id", entry.id, "fullfilled", "-1")
        Next
        fetchData()
    End Sub
End Class