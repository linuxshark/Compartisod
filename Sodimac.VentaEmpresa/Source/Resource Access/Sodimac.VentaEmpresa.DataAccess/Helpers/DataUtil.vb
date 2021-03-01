Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public NotInheritable Class DataUtil

    Private Sub New()
    End Sub

    Public Shared Function DbValueToNullable(Of T As Structure)(dbValue As Object) As Nullable(Of T)
        Dim returnValue As Nullable(Of T) = Nothing

        If (dbValue IsNot Nothing) AndAlso (dbValue IsNot DBNull.Value) Then
            returnValue = DirectCast(dbValue, T)
        End If

        Return returnValue
    End Function

    Public Shared Function DbValueToDefault(Of T)(obj As Object) As T
        If obj Is Nothing OrElse obj Is DBNull.Value Then
            Return Nothing
        Else
            Return DirectCast(obj, T)
        End If
    End Function

End Class