Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ComisionEscalaTiempoServicio")> _
Public Class ComisionEscalaTiempoServicio

    Private m_IdComisionTiempoServicio As Integer
    <WcfSerialization.DataMember(Name:="IdComisionTiempoServicio", IsRequired:=False, Order:=0)> _
    Public Property IdComisionTiempoServicio() As Integer
        Get
            Return m_IdComisionTiempoServicio
        End Get
        Set(ByVal value As Integer)
            m_IdComisionTiempoServicio = value
        End Set
    End Property

    Private m_IdPeriodo As Integer
    <WcfSerialization.DataMember(Name:="IdPeriodo", IsRequired:=False, Order:=1)> _
    Public Property IdPeriodo() As Integer
        Get
            Return m_IdPeriodo
        End Get
        Set(ByVal value As Integer)
            m_IdPeriodo = value
        End Set
    End Property

    Private m_ComisionPeriodo As ComisionPeriodo
    <WcfSerialization.DataMember(Name:="ComisionPeriodo", IsRequired:=False, Order:=2)> _
    Public Property ComisionPeriodo() As ComisionPeriodo
        Get
            Return m_ComisionPeriodo
        End Get

        Set(ByVal value As ComisionPeriodo)
            m_ComisionPeriodo = value
        End Set
    End Property

    Private m_Perfil As Perfil
    <WcfSerialization.DataMember(Name:="Perfil", IsRequired:=False, Order:=3)> _
    Public Property Perfil() As Perfil
        Get
            Return m_Perfil
        End Get
        Set(ByVal value As Perfil)
            m_Perfil = value
        End Set
    End Property

    Private m_Cargo As Cargo
    <WcfSerialization.DataMember(Name:="Cargo", IsRequired:=False, Order:=4)> _
    Public Property Cargo() As Cargo
        Get
            Return m_Cargo
        End Get
        Set(ByVal value As Cargo)
            m_Cargo = value
        End Set
    End Property

    Private m_TiempoServicio As Integer
    <WcfSerialization.DataMember(Name:="TiempoServicio", IsRequired:=False, Order:=5)> _
    Public Property TiempoServicio() As Integer
        Get
            Return m_TiempoServicio
        End Get
        Set(ByVal value As Integer)
            m_TiempoServicio = value
        End Set
    End Property

    Private m_PlanVenta As Decimal
    <WcfSerialization.DataMember(Name:="PlanVenta", IsRequired:=False, Order:=6)> _
    Public Property PlanVenta() As Decimal
        Get
            Return m_PlanVenta
        End Get
        Set(ByVal value As Decimal)
            m_PlanVenta = value
        End Set
    End Property

    Private m_IngresoBasico As Decimal
    <WcfSerialization.DataMember(Name:="IngresoBasico", IsRequired:=False, Order:=7)> _
    Public Property IngresoBasico() As Decimal
        Get
            Return m_IngresoBasico
        End Get
        Set(ByVal value As Decimal)
            m_IngresoBasico = value
        End Set
    End Property

    Private m_FechaRegistro As DateTime
    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=8)> _
    Public Property FechaRegistro() As DateTime
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As DateTime)
            m_FechaRegistro = value
        End Set
    End Property

    Private m_FechaActualizacion As DateTime
    <WcfSerialization.DataMember(Name:="FechaActualizacion", IsRequired:=False, Order:=9)> _
    Public Property FechaActualizacion() As DateTime
        Get
            Return m_FechaActualizacion
        End Get
        Set(ByVal value As DateTime)
            m_FechaActualizacion = value
        End Set
    End Property

    Private m_Activo As Boolean
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=10)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property

    Private m_ListaComisionEscalaDetalle As ListaComisionEscalaDetalle
    <WcfSerialization.DataMember(Name:="ListaComisionEscalaDetalle", IsRequired:=False, Order:=11)> _
    Public Property ListaComisionEscalaDetalleRRVV() As ListaComisionEscalaDetalle
        Get
            Return m_ListaComisionEscalaDetalle
        End Get
        Set(ByVal value As ListaComisionEscalaDetalle)
            m_ListaComisionEscalaDetalle = value
        End Set
    End Property

    Private m_PorcInicial As Decimal
    <WcfSerialization.DataMember(Name:="PorcInicial", IsRequired:=False, Order:=12)> _
    Public Property PorcInicial() As Decimal
        Get
            Return m_PorcInicial
        End Get
        Set(ByVal value As Decimal)
            m_PorcInicial = value
        End Set
    End Property

    Private m_BonoMin As Decimal
    <WcfSerialization.DataMember(Name:="BonoMin", IsRequired:=False, Order:=13)> _
    Public Property BonoMin() As Decimal
        Get
            Return m_BonoMin
        End Get
        Set(ByVal value As Decimal)
            m_BonoMin = value
        End Set
    End Property

    Private m_PorcFinal As Decimal
    <WcfSerialization.DataMember(Name:="PorcFinal", IsRequired:=False, Order:=14)> _
    Public Property PorcFinal() As Decimal
        Get
            Return m_PorcFinal
        End Get
        Set(ByVal value As Decimal)
            m_PorcFinal = value
        End Set
    End Property

    Private m_BonoMax As Decimal
    <WcfSerialization.DataMember(Name:="BonoMax", IsRequired:=False, Order:=15)> _
    Public Property BonoMax() As Decimal
        Get
            Return m_BonoMax
        End Get
        Set(ByVal value As Decimal)
            m_BonoMax = value
        End Set
    End Property
End Class
