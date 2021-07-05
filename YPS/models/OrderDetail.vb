Public Class OrderDetail
    Inherits BaseModel
    Public id_order As String
    Public id_produk As String
    Public jumlah As Integer
    Public total As Integer

    Public Sub New(id_order As String, id_produk As String, jumlah As Integer, total As Integer)
        Me.id_order = id_order
        Me.id_produk = id_produk
        Me.jumlah = jumlah
        Me.total = total
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {CInt(Math.Ceiling(Rnd() * 99)) + 1, Me.id_order, Me.id_produk, Me.jumlah.ToString(), Me.total.ToString}
        Return dynArray
    End Function
End Class
