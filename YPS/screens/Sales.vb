Public Class Sales
    Dim repository As Repository = Repository.getInstance()

    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showDataFromTable(TABLE_PRODUK, DataGridView1)
    End Sub
End Class