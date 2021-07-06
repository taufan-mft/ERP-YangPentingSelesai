Public Class Prod
    Inherits BaseModel
    Public id As String
        Public nama As String
        Public harga As Integer

    Public Sub New(id As String, nama As String, harga As Integer)
        Me.id = id
        Me.nama = nama
        Me.harga = harga
    End Sub

    Overrides Function toArray() As List(Of String)
        Dim dynArray As New List(Of String) From {Me.id, Me.nama, Me.harga.ToString()}
        Return dynArray
    End Function

    Public Sub New(list As List(Of String))
        Me.id = list(0)
        Me.nama = list(1)
        Me.harga = list(2)
    End Sub
End Class
