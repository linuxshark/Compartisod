Public Class Mes
    Private _IdMes As Integer
    Private _Mes As String

    Public Property IdMes() As Integer
        Get
            Return _IdMes
        End Get
        Set(ByVal value As Integer)
            _IdMes = value
        End Set
    End Property

    Public Property Mes() As String
        Get
            Return _Mes
        End Get
        Set(ByVal value As String)
            _Mes = value
        End Set
    End Property

End Class
