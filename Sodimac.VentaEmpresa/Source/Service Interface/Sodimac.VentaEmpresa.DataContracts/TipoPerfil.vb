Public Class TipoPerfil

    Private _IdTipoPerfil As Integer
    Public Property IdTipoPerfil() As Integer
        Get
            Return _IdTipoPerfil
        End Get
        Set(ByVal value As Integer)
            _IdTipoPerfil = value
        End Set
    End Property

    Private _TipoPerfil As String
    Public Property TipoPerfil() As String
        Get
            Return _TipoPerfil
        End Get
        Set(ByVal value As String)
            _TipoPerfil = value
        End Set
    End Property

End Class
