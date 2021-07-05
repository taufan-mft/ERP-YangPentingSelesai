Module Helpers


    Function checkEmpty(ParamArray var() As TextBox) As Boolean
        Dim nomor As Integer = 0
        For i As Integer = 0 To UBound(var, 1)
            If (var(i).Text = "") Then
                nomor += 1
            End If
        Next
        Return nomor > 0
    End Function

    Sub clearForm(ParamArray var() As TextBox)
        For i As Integer = 0 To UBound(var, 1)
            var(i).Clear()
        Next
    End Sub
End Module
