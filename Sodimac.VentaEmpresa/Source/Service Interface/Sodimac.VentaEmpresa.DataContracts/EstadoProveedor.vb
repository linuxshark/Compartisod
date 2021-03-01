Public Class EstadoProveedor
    Private _IdEstado As Integer
    Private _Descripcion As String

    Public Property IdEstado() As Integer
        Get
            Return _IdEstado
        End Get
        Set(ByVal value As Integer)
            _IdEstado = value
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
