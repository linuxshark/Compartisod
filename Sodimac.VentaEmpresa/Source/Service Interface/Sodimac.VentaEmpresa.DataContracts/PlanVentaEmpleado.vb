Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Estructura.PlanVentaEmpleado")> _
<MetadataType(GetType(Validation.PlanVentaEmpleadoMetadata))> _
Public Class PlanVentaEmpleado

    Private _IdPlanVentaEmpleado As Integer
    <WcfSerialization.DataMember(Name:="IdPlanVentaEmpleado", IsRequired:=False, Order:=0)> _
    Public Property IdPlanVentaEmpleado() As Integer
        Get
            Return _IdPlanVentaEmpleado
        End Get
        Set(ByVal value As Integer)
            _IdPlanVentaEmpleado = value
        End Set
    End Property
    Private m_IdEmpleado As Empleado
    <WcfSerialization.DataMember(Name:="IdEmpleado", IsRequired:=False, Order:=1)> _
    Public Property IdEmpleado() As Empleado
        Get
            Return m_IdEmpleado
        End Get
        Set(value As Empleado)
            m_IdEmpleado = value
        End Set
    End Property
    Private _PlanVentaBase As Decimal
    <WcfSerialization.DataMember(Name:="PlanVentaBase", IsRequired:=False, Order:=2)> _
    Public Property PlanVentaBase() As Decimal
        Get
            Return _PlanVentaBase
        End Get
        Set(value As Decimal)
            _PlanVentaBase = value
        End Set
    End Property
    Private _IngresoBasicoMensual As Decimal
    <WcfSerialization.DataMember(Name:="IngresoBasicoMensual", IsRequired:=False, Order:=3)> _
    Public Property IngresoBasicoMensual() As Decimal
        Get
            Return _IngresoBasicoMensual
        End Get
        Set(value As Decimal)
            _IngresoBasicoMensual = value
        End Set
    End Property
    Private m_FechaActivacion As DateTime
    <WcfSerialization.DataMember(Name:="FechaActivacion", IsRequired:=False, Order:=4)> _
    Public Property FechaActivacion() As Date
        Get
            Return m_FechaActivacion
        End Get
        Set(value As Date)
            m_FechaActivacion = value
        End Set
    End Property

    Private _Perfil As Perfil
    <WcfSerialization.DataMember(Name:="Perfil", IsRequired:=False, Order:=5)> _
    Public Property Perfil() As Perfil
        Get
            Return _Perfil
        End Get
        Set(value As Perfil)
            _Perfil = value
        End Set
    End Property
    Private _Cargo As Cargo
    <WcfSerialization.DataMember(Name:="Cargo", IsRequired:=False, Order:=6)> _
    Public Property Cargo() As Cargo
        Get
            Return _Cargo
        End Get
        Set(value As Cargo)
            _Cargo = value
        End Set
    End Property

    Private _Sucursal As Sucursal
    <WcfSerialization.DataMember(Name:="Sucursal", IsRequired:=False, Order:=7)> _
    Public Property Sucursal() As Sucursal
        Get
            Return _Sucursal
        End Get
        Set(ByVal value As Sucursal)
            _Sucursal = value
        End Set
    End Property

    Private _Zona As ZonaMantenimiento
    <WcfSerialization.DataMember(Name:="ZonaMantenimiento", IsRequired:=False, Order:=8)> _
    Public Property ZonaMantenimiento() As ZonaMantenimiento
        Get
            Return _Zona
        End Get
        Set(value As ZonaMantenimiento)
            _Zona = value
        End Set
    End Property

    Private _Activo As Integer
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=9)> _
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal value As Integer)
            _Activo = value
        End Set
    End Property
    Private _ComisionEscala As ComisionEscala
    <WcfSerialization.DataMember(Name:="ComisionEscala", IsRequired:=False, Order:=10)> _
    Public Property ComisionEscala() As ComisionEscala
        Get
            Return _ComisionEscala
        End Get
        Set(value As ComisionEscala)
            _ComisionEscala = value
        End Set
    End Property
    Private _ComisionPeriodo As ComisionPeriodo
    <WcfSerialization.DataMember(Name:="ComisionPeriodo", IsRequired:=False, Order:=11)> _
    Public Property ComisionPeriodo() As ComisionPeriodo
        Get
            Return _ComisionPeriodo
        End Get
        Set(value As ComisionPeriodo)
            _ComisionPeriodo = value
        End Set
    End Property

    Private _ComisionEscalaTiempoServicio As ComisionEscalaTiempoServicio
    <WcfSerialization.DataMember(Name:="ComisionEscalaTiempoServicio", IsRequired:=False, Order:=12)> _
    Public Property ComisionEscalaTiempoServicio() As ComisionEscalaTiempoServicio
        Get
            Return _ComisionEscalaTiempoServicio
        End Get
        Set(value As ComisionEscalaTiempoServicio)
            _ComisionEscalaTiempoServicio = value
        End Set
    End Property
    Private _Empleado As Empleado
    <WcfSerialization.DataMember(Name:="Empleado", IsRequired:=False, Order:=13)> _
    Public Property Empleado() As Empleado
        Get
            Return _Empleado
        End Get
        Set(value As Empleado)
            _Empleado = value
        End Set
    End Property
    Private _TiempoServicio As Integer
    <WcfSerialization.DataMember(Name:="TiempoServicio", IsRequired:=False, Order:=14)> _
    Public Property TiempoServicio() As Integer
        Get
            Return _TiempoServicio
        End Get
        Set(value As Integer)
            _TiempoServicio = value
        End Set
    End Property
    Private _comboTiempoServicio As Integer
    <WcfSerialization.DataMember(Name:="comboTiempoServicio", IsRequired:=False, Order:=15S)> _
    Public Property comboTiempoServicio() As Integer
        Get
            Return _comboTiempoServicio
        End Get
        Set(value As Integer)
            _comboTiempoServicio = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="DescripcionMes", IsRequired:=False, Order:=16)> _
    Private m_DescripcionMes As String
    Public Property DescripcionMes() As String
        Get
            Return m_DescripcionMes
        End Get
        Set(ByVal value As String)
            m_DescripcionMes = value
        End Set
    End Property


End Class
