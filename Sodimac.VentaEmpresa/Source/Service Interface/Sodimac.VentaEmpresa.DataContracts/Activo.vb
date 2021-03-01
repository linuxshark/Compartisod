Public Class Activo
    Private _IdActivo As String
    Private _Descripcion As String

    Public Property IdActivo() As String
        Get
            Return _IdActivo
        End Get
        Set(ByVal value As String)
            _IdActivo = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
End Class
