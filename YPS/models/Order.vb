Public Class Order
    Inherits BaseModel
    Public id As String
    Public nama As String
    Public alamat As String
    Public tanggal As String
    Public fullfilled As String
    Public paid As String
    Public total As Integer

    Public Sub New(id As String, nama As String, alamat As String, tanggal As String, fullfilled As String, paid As String, total As Integer)
        Me.id = id
        Me.nama = nama
        Me.tanggal = tanggal
        Me.fullfilled = fullfilled
        Me.paid = paid
        Me.total = total
        Me.alamat = alamat
    End Sub

    Public Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.nama, Me.alamat, Me.tanggal, Me.fullfilled, Me.paid, Me.total}
        Return dynArray
    End Function
End Class
