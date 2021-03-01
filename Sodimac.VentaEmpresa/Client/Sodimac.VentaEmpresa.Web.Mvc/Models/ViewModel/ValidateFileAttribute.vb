Imports System.ComponentModel.DataAnnotations
Imports System.Drawing

Public Class ValidateFileAttribute
    Inherits RequiredAttribute
    Public Overrides Function IsValid(value As Object) As Boolean
        Dim file = TryCast(value, HttpPostedFileBase)
        If file Is Nothing Then
            Return False
        End If

        'If file.ContentLength > 1 * 1024 * 1024 Then
        '    Return False
        'End If

        Try
            Using img = Image.FromStream(file.InputStream)
                Return img.RawFormat.Equals(Imaging.ImageFormat.Png)
            End Using
        Catch
        End Try
        Return False
    End Function
End Class