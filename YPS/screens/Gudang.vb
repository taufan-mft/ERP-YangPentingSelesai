Public Class Gudang
    Dim repository As Repository = Repository.getInstance()
    Dim listUnfullOrder As New List(Of Order)()
    Private Sub Gudang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchData()
    End Sub

    Private Sub fetchData()
        repository.showData($"SELECT {TABLE_GUDANG}.id, {TABLE_PRODUK}.nama, {TABLE_GUDANG}.jumlah FROM  {TABLE_GUDANG} INNER JOIN {TABLE_PRODUK} ON {TABLE_GUDANG}.id_produk={TABLE_PRODUK}.id WHERE direction='in'", DataGridView1)
        repository.showData($"SELECT {TABLE_GUDANG}.id, {TABLE_PRODUK}.nama, {TABLE_GUDANG}.jumlah FROM  {TABLE_GUDANG} INNER JOIN {TABLE_PRODUK} ON {TABLE_GUDANG}.id_produk={TABLE_PRODUK}.id WHERE direction='out'", DataGridView2)
        listUnfullOrder = repository.retrieveUnpaidOrders(fullfilled:=False)
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