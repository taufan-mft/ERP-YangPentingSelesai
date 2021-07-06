Public Class DaftarSales
    Dim repository As Repository = Repository.getInstance()
    Private Sub DaftarSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showDataFromTable(TABLE_ORDER, DataGridView1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class