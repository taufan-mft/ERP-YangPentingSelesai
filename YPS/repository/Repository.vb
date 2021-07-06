Imports System.Data.OleDb

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


    Sub showData(sql As String, DGV As DataGridView)
        DA = New OleDb.OleDbDataAdapter(sql, Conn)
        DS = New DataSet
        DA.Fill(DS)

        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Sub showDataFromTable(table As String, dgv As DataGridView)
        Dim sql As String = "SELECT * FROM " + table
        Debug.WriteLine(sql)
        DA = New OleDb.OleDbDataAdapter(sql, Conn)
        DS = New DataSet
        DA.Fill(DS)

        dgv.DataSource = DS.Tables(0)
        dgv.ReadOnly = True
    End Sub

    Sub saveData(tableName As String, ParamArray var() As TextBox)
        Dim sql As String = "insert into " + tableName + " values("
        For i As Integer = 0 To UBound(var, 1)
            If i <> UBound(var, 1) Then
                sql = sql + "'" + var(i).Text + "',"
            Else
                sql = sql + "'" + var(i).Text + "')"
            End If

        Next
        CMD = New OleDb.OleDbCommand(sql, Conn)
        CMD.ExecuteNonQuery()
        clearForm(var)

    End Sub

    Sub saveData(tableName As String, ParamArray var() As String)
        Dim sql As String = "insert into " + tableName + " values("
        For i As Integer = 0 To UBound(var, 1)
            If i <> UBound(var, 1) Then
                sql = sql + "'" + var(i) + "',"
            Else
                sql = sql + "'" + var(i) + "')"
            End If

        Next
        CMD = New OleDb.OleDbCommand(sql, Conn)
        CMD.ExecuteNonQuery()

    End Sub

    Sub saveMultipleData(tableName As String, packets As IEnumerable(Of BaseModel))
        For Each packet In packets
            saveData(tableName, packet.toArray().ToArray())

        Next
    End Sub

    Sub updateData(tableName As String, idName As String, id As String, ParamArray var() As String)
        Dim sql As String
        sql = "update " + tableName + " set "
        For i As Integer = 0 To UBound(var, 1) Step 2
            If i <> (UBound(var, 1) - 1) Then
                sql = sql + var(i) + " ='" + var(i + 1) + "', "

            Else
                sql = sql + var(i) + " ='" + var(i + 1) + "'"
            End If
        Next
        sql = sql + " where " + idName + " = '" + id + "'"

        CMD = New OleDbCommand(sql, Conn)
        DM = CMD.ExecuteReader
        MsgBox("Update berhasil")


    End Sub

    Function checkDuplicate(tableName As String, idName As String, id As String)
        Dim sequel As String
        sequel = "select * from " + tableName + " where " + idName + " = '" + id + "'"
        CMD = New OleDb.OleDbCommand(sequel, Conn)

        DM = CMD.ExecuteReader()
        DM.Read()
        Return DM.HasRows

    End Function
    Function checkDuplicateInteger(tableName As String, idName As String, id As String)
        Dim sequel As String
        sequel = "select * from " + tableName + " where " + idName + " = " + id + ""
        CMD = New OleDb.OleDbCommand(sequel, Conn)

        DM = CMD.ExecuteReader()
        DM.Read()
        Return DM.HasRows

    End Function
    Function retrieveProduct(id As String) As Prod
        Dim sql As String = "Select * from " + TABLE_PRODUK + " where id = '" + id + "'"
        CMD = New OleDb.OleDbCommand(sql, Conn)
        Dim hasil As Prod
        DM = CMD.ExecuteReader()
        If DM.HasRows = True Then
            'MsgBox("Dianis")
            While DM.Read
                'MsgBox(DM.GetString(0))
                ''Label3.Text = DM.GetString(0)
                hasil = New Prod(DM.GetString(0), DM.GetString(1), DM.GetValue(2))
            End While
        End If
        Return hasil
    End Function

End Class
