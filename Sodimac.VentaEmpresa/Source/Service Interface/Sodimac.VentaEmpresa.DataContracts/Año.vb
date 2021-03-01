Public Class Año
    Private m_IdAño As Integer
    Private m_Año As Integer

    Public Property IdAño As Integer
        Get
            Return m_IdAño
        End Get
        Set(value As Integer)
            m_IdAño = value
        End Set
    End Property

    Public Property Año As Integer
        Get
            Return m_Año
        End Get
        Set(value As Integer)
            m_Año = value
        End Set
    End Property
End Class
