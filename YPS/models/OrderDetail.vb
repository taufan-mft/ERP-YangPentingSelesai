Public Class OrderDetail
    Inherits BaseModel
    Dim repository As Repository = Repository.getInstance()
    Public id_detail As String
    Public id_order As String
    Public id_produk As String
    Public jumlah As Integer
    Public nama As String
    Public total As Integer
    Public harga As Integer

    Public Sub New(nama As String, id_order As String, id_produk As String, jumlah As Integer, total As Integer, harga As Integer)
        Dim kode As Integer = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        While repository.checkDuplicateInteger(TABLE_ORDER_DETAIL, "id", kode.ToString)
            kode = CInt(Math.Ceiling(Rnd() * 99)) + CInt(Math.Ceiling(Rnd() * 12))
        End While
        Me.id_detail = kode
        Me.id_order = id_order
        Me.id_produk = id_produk
        Me.jumlah = jumlah
        Me.total = total
        Me.nama = nama
        Me.harga = harga
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id_detail, Me.id_order, Me.id_produk, Me.jumlah.ToString(), Me.total.ToString}
        Return dynArray
    End Function

End Class
