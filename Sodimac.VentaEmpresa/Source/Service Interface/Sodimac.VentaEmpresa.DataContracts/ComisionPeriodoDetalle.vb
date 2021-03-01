Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ComisionPeriodoDetalle")> _
Public Class ComisionPeriodoDetalle

    Private m_IdPeriodoDetalle As Integer
    Private m_IdPeriodo As Integer
    Private m_IdPerfil As Integer
    Private m_PorcentajeInicial As Decimal
    Private m_PorcentajeFinal As Decimal
    Private m_Bono As Decimal
    Private m_Estado As String
    Private m_FechaFin As Date
    Private m_Descripcion As String
    Private m_FechaIni As Date
    Private m_FechaRegistro As Date
    Private m_FechaActualizacion As Date

    Private m_IdEstado As Integer
    Private m_Contador As Integer

    Public Property Contador() As Integer
        Get
            Return m_Contador
        End Get
        Set(ByVal value As Integer)
            m_Contador = value
        End Set
    End Property


    Public Property IdPeriodoDetalle() As Integer
        Get
            Return m_IdPeriodoDetalle
        End Get
        Set(ByVal value As Integer)
            m_IdPeriodoDetalle = value
        End Set
    End Property

    Public Property IdPeriodo() As Integer
        Get
            Return m_IdPeriodo
        End Get
        Set(ByVal value As Integer)
            m_IdPeriodo = value
        End Set
    End Property

    Public Property IdPerfil() As Integer
        Get
            Return m_IdPerfil
        End Get
        Set(ByVal value As Integer)
            m_IdPerfil = value
        End Set
    End Property

    Public Property PorcentajeInicial() As Decimal
        Get
            Return m_PorcentajeInicial
        End Get
        Set(ByVal value As Decimal)
            m_PorcentajeInicial = value
        End Set
    End Property

    Public Property PorcentajeFinal() As Decimal
        Get
            Return m_PorcentajeFinal
        End Get
        Set(ByVal value As Decimal)
            m_PorcentajeFinal = value
        End Set
    End Property

    Public Property Bono() As Decimal
        Get
            Return m_Bono
        End Get
        Set(ByVal value As Decimal)
            m_Bono = value
        End Set
    End Property

    Public Property Estado() As Integer
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Integer)
            m_Estado = value
        End Set
    End Property

    Public Property DescripcionEstado() As String
        Get
            Return m_Estado
        End Get
        Set(ByVal value As String)
            m_Estado = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(ByVal value As String)
            m_Descripcion = value
        End Set
    End Property

    Public Property FechaIni() As Date
        Get
            Return m_FechaIni
        End Get
        Set(ByVal value As Date)
            m_FechaIni = value
        End Set
    End Property

    Public Property FechaRegistro() As Date
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As Date)
            m_FechaRegistro = value
        End Set
    End Property

    Public Property FechaActualizacion() As Date
        Get
            Return m_FechaActualizacion
        End Get
        Set(ByVal value As Date)
            m_FechaActualizacion = value
        End Set
    End Property

    Public Property FechaFin() As Date
        Get
            Return m_FechaFin
        End Get
        Set(ByVal value As Date)
            m_FechaFin = value
        End Set
    End Property


    Public Property IdEstado() As Integer
        Get
            Return m_IdEstado
        End Get
        Set(ByVal value As Integer)
            m_IdEstado = value
        End Set
    End Property


End Class
