Public Class ProduksiProduk
    Dim repository As Repository = Repository.getInstance()
    Dim listUnfullOrder As New List(Of Order)()
    Dim listFullOrder As New List(Of Order)()
    Dim listNeeded As New List(Of Needed)()
    Dim listProduk As New List(Of Prod)()
    Private Sub ProduksiProduk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        calculateNeeds()
    End Sub

    Private Sub calculateNeeds()
        listFullOrder.Clear()
        listUnfullOrder.Clear()
        listNeeded.Clear()
        listProduk.Clear()
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        ListView3.Items.Clear()
        listUnfullOrder = repository.retrieveUnpaidOrders(fullfilled:=False)
        listProduk = repository.retrieveProducts()
        Debug.WriteLine(listUnfullOrder.Count)
        For Each pesanan In listUnfullOrder
            ListView1.Items.Add(New ListViewItem(New String() {pesanan.id, pesanan.nama, pesanan.alamat,
                                                 pesanan.tanggal, pesanan.fullfilled, pesanan.paid, pesanan.total}))
        Next
        resizeList(ListView1)
        listFullOrder = repository.retrieveUnpaidOrders(fullfilled:=True)
        Debug.WriteLine(listFullOrder.Count)
        For Each pesanan In listFullOrder
            ListView3.Items.Add(New ListViewItem(New String() {pesanan.id, pesanan.nama, pesanan.alamat,
                                                 pesanan.tanggal, pesanan.fullfilled, pesanan.paid, pesanan.total}))
        Next
        resizeList(ListView3)
        populateList2()
    End Sub

    Private Sub populateList2()
        For Each prod In listProduk
            Dim total As Integer = 0
            For Each order In listUnfullOrder
                total = total + repository.retrieveProductCount(prod.id, order.id)
            Next
            Debug.WriteLine(prod.nama + " " + total.ToString)
            If total > 0 Then
                Dim needed As New Needed(prod.nama, total)
                listNeeded.Add(needed)
            End If
            'Dim indexOfMyApple = list.FindIndex(Function(apple) myApple.Equals(apple))
        Next

        For Each entry In listNeeded
            ListView2.Items.Add(New ListViewItem(New String() {entry.name, entry.jumlah}))
        Next
        resizeList(ListView2)
    End Sub

    Private Sub resizeList(list As ListView)
        list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        updateFullFilled()
    End Sub

    Private Sub updateFullFilled()
        For Each order In listUnfullOrder
            repository.updateData(TABLE_ORDER, "id", order.id, "fullfilled", "-1")
        Next
        calculateNeeds()
    End Sub
End Class