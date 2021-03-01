Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ComisionEscala")> _
Public Class ComisionEscala

    Private m_IdComisionEscala As Integer
    Private m_IdPeriodo As Integer
    Private m_ComisionPeriodo As ComisionPeriodo
    Private m_Perfil As Perfil
    Private m_Cargo As Cargo

    Private m_PlanVentaSumatoria As Boolean
    Private m_PlanVentaFactorAplica As Boolean
    Private m_PlanVentaFactor As Decimal
    Private m_PlanVentaFactorFechaInicio As DateTime
    Private m_PlanVentaFactorFechaFin As DateTime

    Private m_PlanVentaBonificacionRRVV As Boolean
    Private m_PlanVentaBonificacionRRVVPorcentaje As Decimal
    Private m_PlanVentaBonificacionRRVVMonto As Decimal

    Private m_PlanVentaBonificacionJefe As Boolean
    Private m_PlanVentaBonificacionJefePorcentaje As Decimal
    Private m_PlanVentaBonificacionJefeMonto As Decimal

    Private m_CantidadEscalas As Integer
    Private m_TiempoServicio As Integer
    Private m_FechaRegistro As DateTime
    Private m_FechaActualizacion As DateTime

    Private m_Estado As Boolean
    Private m_Completo As Boolean
    Private m_Completo_ As String


    <WcfSerialization.DataMember(Name:="IdComisionEscala", IsRequired:=False, Order:=0)> _
    Public Property IdComisionEscala() As Integer
        Get
            Return m_IdComisionEscala
        End Get
        Set(ByVal value As Integer)
            m_IdComisionEscala = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdPeriodo", IsRequired:=False, Order:=1)> _
    Public Property IdPeriodo() As Integer
        Get
            Return m_IdPeriodo
        End Get
        Set(ByVal value As Integer)
            m_IdPeriodo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ComisionPeriodo", IsRequired:=False, Order:=2)> _
    Public Property ComisionPeriodo() As ComisionPeriodo
        Get
            Return m_ComisionPeriodo
        End Get

        Set(ByVal value As ComisionPeriodo)
            m_ComisionPeriodo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Perfil", IsRequired:=False, Order:=3)> _
    Public Property Perfil() As Perfil
        Get
            Return m_Perfil
        End Get
        Set(ByVal value As Perfil)
            m_Perfil = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Cargo", IsRequired:=False, Order:=4)> _
    Public Property Cargo() As Cargo
        Get
            Return m_Cargo
        End Get
        Set(ByVal value As Cargo)
            m_Cargo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaSumatoria", IsRequired:=False, Order:=5)> _
    Public Property PlanVentaSumatoria() As Boolean
        Get
            Return m_PlanVentaSumatoria
        End Get
        Set(ByVal value As Boolean)
            m_PlanVentaSumatoria = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaFactor", IsRequired:=False, Order:=6)> _
    Public Property PlanVentaFactor() As Decimal
        Get
            Return m_PlanVentaFactor
        End Get
        Set(ByVal value As Decimal)
            m_PlanVentaFactor = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaFactorFechaInicio", IsRequired:=False, Order:=7)> _
    Public Property PlanVentaFactorFechaInicio() As DateTime
        Get
            Return m_PlanVentaFactorFechaInicio
        End Get
        Set(ByVal value As DateTime)
            m_PlanVentaFactorFechaInicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaFactorFechaFin", IsRequired:=False, Order:=8)> _
    Public Property PlanVentaFactorFechaFin() As DateTime
        Get
            Return m_PlanVentaFactorFechaFin
        End Get
        Set(ByVal value As DateTime)
            m_PlanVentaFactorFechaFin = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaBonificacionRRVV", IsRequired:=False, Order:=9)> _
    Public Property PlanVentaBonificacionRRVV() As Boolean
        Get
            Return m_PlanVentaBonificacionRRVV
        End Get
        Set(ByVal value As Boolean)
            m_PlanVentaBonificacionRRVV = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaBonificacionRRVVPorcentaje", IsRequired:=False, Order:=10)> _
    Public Property PlanVentaBonificacionRRVVPorcentaje() As Decimal
        Get
            Return m_PlanVentaBonificacionRRVVPorcentaje
        End Get
        Set(ByVal value As Decimal)
            m_PlanVentaBonificacionRRVVPorcentaje = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaBonificacionRRVVMonto", IsRequired:=False, Order:=11)> _
    Public Property PlanVentaBonificacionRRVVMonto() As Decimal
        Get
            Return m_PlanVentaBonificacionRRVVMonto
        End Get
        Set(ByVal value As Decimal)
            m_PlanVentaBonificacionRRVVMonto = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaBonificacionJefe", IsRequired:=False, Order:=12)> _
    Public Property PlanVentaBonificacionJefe() As Boolean
        Get
            Return m_PlanVentaBonificacionJefe
        End Get
        Set(ByVal value As Boolean)
            m_PlanVentaBonificacionJefe = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaBonificacionJefePorcentaje", IsRequired:=False, Order:=13)> _
    Public Property PlanVentaBonificacionJefePorcentaje() As Decimal
        Get
            Return m_PlanVentaBonificacionJefePorcentaje
        End Get
        Set(ByVal value As Decimal)
            m_PlanVentaBonificacionJefePorcentaje = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaBonificacionJefeMonto", IsRequired:=False, Order:=14)> _
    Public Property PlanVentaBonificacionJefeMonto() As Decimal
        Get
            Return m_PlanVentaBonificacionJefeMonto
        End Get
        Set(ByVal value As Decimal)
            m_PlanVentaBonificacionJefeMonto = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CantidadEscalas", IsRequired:=False, Order:=15)> _
    Public Property CantidadEscalas() As Integer
        Get
            Return m_CantidadEscalas
        End Get
        Set(ByVal value As Integer)
            m_CantidadEscalas = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TiempoServicio", IsRequired:=False, Order:=16)> _
    Public Property TiempoServicio() As Integer
        Get
            Return m_TiempoServicio
        End Get
        Set(ByVal value As Integer)
            m_TiempoServicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=17)> _
    Public Property FechaRegistro() As DateTime
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As DateTime)
            m_FechaRegistro = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaActualizacion", IsRequired:=False, Order:=18)> _
    Public Property FechaActualizacion() As DateTime
        Get
            Return m_FechaActualizacion
        End Get
        Set(ByVal value As DateTime)
            m_FechaActualizacion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=19)> _
    Public Property Estado() As Boolean
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Boolean)
            m_Estado = value
        End Set
    End Property







    Private m_PlanVenta As Decimal
    Private m_IngresoBasicoMensual As Decimal

    <WcfSerialization.DataMember(Name:="PlanVenta", IsRequired:=False, Order:=20)> _
    Public Property PlanVenta() As Decimal
        Get
            Return m_PlanVenta
        End Get
        Set(ByVal value As Decimal)
            m_PlanVenta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IngresoBasicoMensual", IsRequired:=False, Order:=21)> _
    Public Property IngresoBasicoMensual() As Decimal
        Get
            Return m_IngresoBasicoMensual
        End Get
        Set(ByVal value As Decimal)
            m_IngresoBasicoMensual = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="PlanVentaFactorAplica", IsRequired:=False, Order:=22)> _
    Public Property PlanVentaFactorAplica() As Boolean
        Get
            Return m_PlanVentaFactorAplica
        End Get
        Set(ByVal value As Boolean)
            m_PlanVentaFactorAplica = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Completo", IsRequired:=False, Order:=23)> _
    Public Property Completo() As Boolean
        Get
            Return m_Completo
        End Get
        Set(ByVal value As Boolean)
            m_Completo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Completo_", IsRequired:=False, Order:=24)> _
    Public Property Completo_() As String
        Get
            Return m_Completo_
        End Get
        Set(ByVal value As String)
            m_Completo_ = value
        End Set
    End Property

    Public EmpleadoCargo As EmpleadoCargo
    Public EmpleadoPerfil As EmpleadoPerfil


End Class
