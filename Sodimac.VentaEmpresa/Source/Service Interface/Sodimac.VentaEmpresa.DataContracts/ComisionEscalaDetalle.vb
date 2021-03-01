Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ComisionEscalaDetalle")> _
Public Class ComisionEscalaDetalle

    Private m_IdComisionEscalaDetalle As Integer
    Public Property IdComisionEscalaDetalle() As Integer
        Get
            Return m_IdComisionEscalaDetalle
        End Get
        Set(ByVal value As Integer)
            m_IdComisionEscalaDetalle = value
        End Set
    End Property

    Private m_ComisionEscala As ComisionEscala
    Public Property ComisionEscala() As ComisionEscala
        Get
            Return m_ComisionEscala
        End Get
        Set(ByVal value As ComisionEscala)
            m_ComisionEscala = value
        End Set
    End Property

    Private m_IdComisionEscalaTipo As Integer
    Public Property IdComisionEscalaTipo() As Integer
        Get
            Return m_IdComisionEscalaTipo
        End Get
        Set(ByVal value As Integer)
            m_IdComisionEscalaTipo = value
        End Set
    End Property

    Private m_IdComisionEscala As Integer
    Public Property IdComisionEscala() As Integer
        Get
            Return m_IdComisionEscala
        End Get
        Set(ByVal value As Integer)
            m_IdComisionEscala = value
        End Set
    End Property

    Private m_PorcentajeInicial As Decimal
    Public Property PorcentajeInicial() As Decimal
        Get
            Return m_PorcentajeInicial
        End Get
        Set(ByVal value As Decimal)
            m_PorcentajeInicial = value
        End Set
    End Property

    Private m_PorcentajeFinal As Decimal
    Public Property PorcentajeFinal() As Decimal
        Get
            Return m_PorcentajeFinal
        End Get
        Set(ByVal value As Decimal)
            m_PorcentajeFinal = value
        End Set
    End Property

    Private m_Bono As Decimal
    Public Property Bono() As Decimal
        Get
            Return m_Bono
        End Get
        Set(ByVal value As Decimal)
            m_Bono = value
        End Set
    End Property

    Private m_Estado As Integer
    Public Property Estado() As Integer
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Integer)
            m_Estado = value
        End Set
    End Property

End Class
