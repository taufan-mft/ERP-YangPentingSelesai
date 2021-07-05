Public Class Customer

    Dim repository As Repository = Repository.getInstance()
    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showDataFromTable(TABLE_ORDER, DataGridView1)

    End Sub
End Class