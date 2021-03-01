Public Class TipoOperacion

    Private _Operacion As String
    Public Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal value As String)
            _Operacion = value
        End Set
    End Property
    Private _IdOperacion As String
    Public Property IdOperacion() As String
        Get
            Return _IdOperacion
        End Get
        Set(ByVal value As String)
            _IdOperacion = value
        End Set
    End Property

    Private _IdTipoOperacion As Integer
    Public Property IdTipoOperacion() As Integer
        Get
            Return _IdTipoOperacion
        End Get
        Set(ByVal value As Integer)
            _IdTipoOperacion = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property



End Class
