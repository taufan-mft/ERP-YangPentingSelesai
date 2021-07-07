Public Class DaftarSales
    Dim repository As Repository = Repository.getInstance()
    Private Sub DaftarSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showData($"SELECT * FROM {TABLE_ORDER} WHERE fullfilled=0", DataGridView1)
        repository.showData($"SELECT * FROM {TABLE_ORDER} WHERE fullfilled=-1", DataGridView3)
    End Sub


End Class