Namespace DataSet1TableAdapters
    Partial Public Class Usp_Reporte_Ventas_ExportarTableAdapter
        Public WriteOnly Property CommandTimeout() As Integer
            Set(ByVal value As Integer)
                Dim i As Integer = 0
                While (i < Me.CommandCollection.Length)
                    If (Me.CommandCollection(i) IsNot Nothing) Then
                        Me.CommandCollection(i).CommandTimeout = value
                    End If
                    i = (i + 1)
                End While
            End Set
        End Property
    End Class
End Namespace
