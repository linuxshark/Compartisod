Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ComisionPeriodo")> _
Public Class ComisionPeriodo
    Private m_IdPeriodo As Integer
    Private m_NombrePeriodo As String
    Private m_FechaInicio As DateTime
    Private m_FechaFin As DateTime
    Private m_PlanVentaBase As Decimal
    Private m_CantidadTiempoServicio As Integer
    Private m_CantidadBono As Integer
    Private m_PlanVentaSumatoria As Boolean
    Private m_BonoEspecial As Boolean
    Private m_BonoMontoEspecial As Decimal
    Private m_Porcentaje As Decimal
    Private m_Estado As Estado
    Private m_IdPeriodoPlantilla As Integer
    Private m_Activo As Boolean

    'variable agregada 
    Private m_FechaPeriodo As String


    <WcfSerialization.DataMember(Name:="IdPeriodo", IsRequired:=False, Order:=0)> _
    Public Property IdPeriodo() As Integer
        Get
            Return m_IdPeriodo
        End Get
        Set(ByVal value As Integer)
            m_IdPeriodo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombrePeriodo", IsRequired:=False, Order:=1)> _
    Public Property NombrePeriodo() As String
        Get
            Return m_NombrePeriodo
        End Get
        Set(ByVal value As String)
            m_NombrePeriodo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaInicio", IsRequired:=False, Order:=2)> _
    Public Property FechaInicio() As DateTime
        Get
            Return m_FechaInicio
        End Get
        Set(ByVal value As DateTime)
            m_FechaInicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaFin", IsRequired:=False, Order:=3)> _
    Public Property FechaFin() As DateTime
        Get
            Return m_FechaFin
        End Get
        Set(ByVal value As DateTime)
            m_FechaFin = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaBase", IsRequired:=False, Order:=4)> _
    Public Property PlanVentaBase() As Decimal
        Get
            Return m_PlanVentaBase
        End Get
        Set(ByVal value As Decimal)
            m_PlanVentaBase = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CantidadTiempoServicio", IsRequired:=False, Order:=5)> _
    Public Property CantidadTiempoServicio() As Integer
        Get
            Return m_CantidadTiempoServicio
        End Get
        Set(ByVal value As Integer)
            m_CantidadTiempoServicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CantidadBono", IsRequired:=False, Order:=6)> _
    Public Property CantidadBono() As Integer
        Get
            Return m_CantidadBono
        End Get
        Set(ByVal value As Integer)
            m_CantidadBono = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PlanVentaSumatoria", IsRequired:=False, Order:=7)> _
    Public Property PlanVentaSumatoria() As Boolean
        Get
            Return m_PlanVentaSumatoria
        End Get
        Set(ByVal value As Boolean)
            m_PlanVentaSumatoria = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="BonoEspecial", IsRequired:=False, Order:=8)> _
    Public Property BonoEspecial() As Boolean
        Get
            Return m_BonoEspecial
        End Get
        Set(ByVal value As Boolean)
            m_BonoEspecial = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="BonoMontoEspecial", IsRequired:=False, Order:=9)> _
    Public Property BonoMontoEspecial() As Decimal
        Get
            Return m_BonoMontoEspecial
        End Get
        Set(ByVal value As Decimal)
            m_BonoMontoEspecial = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=10)> _
    Public Property Estado() As Estado
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Estado)
            m_Estado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Porcentaje", IsRequired:=False, Order:=11)> _
    Public Property Porcentaje() As Decimal
        Get
            Return m_Porcentaje
        End Get
        Set(ByVal value As Decimal)
            m_Porcentaje = value
        End Set
    End Property

    'variable agregada

    <WcfSerialization.DataMember(Name:="FechaPeriodo", IsRequired:=False, Order:=12)> _
    Public Property FechaPeriodo() As String
        Get
            Return m_FechaPeriodo
        End Get
        Set(ByVal value As String)
            m_FechaPeriodo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdPeriodoPlantilla", IsRequired:=False, Order:=13)> _
    Public Property IdPeriodoPlantilla() As Int32
        Get
            Return m_IdPeriodoPlantilla
        End Get
        Set(ByVal value As Int32)
            m_IdPeriodoPlantilla = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=14)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property


End Class
