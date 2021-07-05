Public Class Form1
    Dim repository As Repository = Repository.getInstance()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Customer.Show()
    End Sub
End Class
