Public Class Repository
    Private Shared objRepository As Repository
    Private Sub New()
        koneksiDB()
    End Sub

    Public Shared Function getInstance() As Repository
        If (objRepository Is Nothing) Then
            objRepository = New Repository()
        End If
        Return objRepository
    End Function




End Class
