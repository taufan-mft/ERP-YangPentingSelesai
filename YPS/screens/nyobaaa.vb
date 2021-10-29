Public Class nyobaaa
    Dim repository As Repository = Repository.getInstance()
    Private Sub nyobaaa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repository.showData($"SELECT * FROM {TABLE_ORDER_DETAIL} WHERE id_order = 'tania'", DataGridView1)
    End Sub
End Class