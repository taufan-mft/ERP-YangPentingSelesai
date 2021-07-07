Public Class Form1
    Dim repository As Repository = Repository.getInstance()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Sales.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ProdukModel.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DaftarSales.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        repository.nukeTable(TABLE_ORDER)
        repository.nukeTable(TABLE_ORDER_DETAIL)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ProduksiProduk.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Gudang.Show()
    End Sub
End Class
