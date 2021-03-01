Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Estructura.SucursalEmpleado")> _
<MetadataType(GetType(Validation.SucursalEmpleadoMetadata))> _
Public Class SucursalEmpleado

    Private _IdSucursalEmpleado As Integer
    <WcfSerialization.DataMember(Name:="IdSucursalEmpleado", IsRequired:=False, Order:=0)> _
    Public Property IdSucursalEmpleado() As Integer
        Get
            Return _IdSucursalEmpleado
        End Get
        Set(ByVal value As Integer)
            _IdSucursalEmpleado = value
        End Set
    End Property

    Private _FechaTranspasoSucursal As Date
    <WcfSerialization.DataMember(Name:="FechaTranspasoSucursal", IsRequired:=False, Order:=1)> _
    Public Property FechaTranspasoSucursal() As Date
        Get
            Return _FechaTranspasoSucursal
        End Get
        Set(ByVal value As Date)
            _FechaTranspasoSucursal = value
        End Set
    End Property

    Private _FechaIngresoSucursal As Date
    <WcfSerialization.DataMember(Name:="FechaIngresoSucursal", IsRequired:=False, Order:=2)> _
    Public Property FechaIngresoSucursal() As Date
        Get
            Return _FechaIngresoSucursal
        End Get
        Set(ByVal value As Date)
            _FechaIngresoSucursal = value
        End Set
    End Property

    Private _FechaActivacionVenta As Date
    <WcfSerialization.DataMember(Name:="FechaActivacionVenta", IsRequired:=False, Order:=3)> _
    Public Property FechaActivacionVenta() As Date
        Get
            Return _FechaActivacionVenta
        End Get
        Set(ByVal value As Date)
            _FechaActivacionVenta = value
        End Set
    End Property

    Private _FechaRegistro As Date
    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=4)> _
    Public Property FechaRegistro() As Date
        Get
            Return _FechaRegistro
        End Get
        Set(ByVal value As Date)
            _FechaRegistro = value
        End Set
    End Property



    Private _IdEstadoActual As Integer
    <WcfSerialization.DataMember(Name:="IdEstadoActual", IsRequired:=False, Order:=5)> _
    Public Property IdEstadoActual() As Integer
        Get
            Return _IdEstadoActual
        End Get
        Set(ByVal value As Integer)
            _IdEstadoActual = value
        End Set
    End Property



    Private _Activo As Integer
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=6)> _
    Public Property Activo() As Integer
        Get
            Return _Activo
        End Get
        Set(ByVal value As Integer)
            _Activo = value
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

    Private _Ubigeo As String
    <WcfSerialization.DataMember(Name:="Ubigeo", IsRequired:=False, Order:=8)> _
    Public Property Ubigeo() As String
        Get
            Return _Ubigeo
        End Get
        Set(ByVal value As String)
            _Ubigeo = value
        End Set
    End Property

    Private _Zona As String
    <WcfSerialization.DataMember(Name:="Zona", IsRequired:=False, Order:=9)> _
    Public Property Zona() As String
        Get
            Return _Zona
        End Get
        Set(ByVal value As String)
            _Zona = value
        End Set
    End Property

    Private _EscalaTiempoAsignado As Integer
    <WcfSerialization.DataMember(Name:="EscalaTiempoAsignado", IsRequired:=False, Order:=10)> _
    Public Property EscalaTiempoAsignado() As Integer
        Get
            Return _EscalaTiempoAsignado
        End Get
        Set(ByVal value As Integer)
            _EscalaTiempoAsignado = value
        End Set
    End Property

    Private _FechaActualizacion As Date
    <WcfSerialization.DataMember(Name:="FechaActualizacion", IsRequired:=False, Order:=11)> _
    Public Property FechaActualizacion() As Date
        Get
            Return _FechaActualizacion
        End Get
        Set(ByVal value As Date)
            _FechaActualizacion = value
        End Set
    End Property

    Private _EmpleadoCargo As String
    <WcfSerialization.DataMember(Name:="EmpleadoCargo", IsRequired:=False, Order:=12)> _
    Public Property EmpleadoCargo() As String
        Get
            Return _EmpleadoCargo
        End Get
        Set(ByVal value As String)
            _EmpleadoCargo = value
        End Set
    End Property

    Private _Total As Integer
    <WcfSerialization.DataMember(Name:="Total", IsRequired:=False, Order:=13)> _
    Public Property Total() As Integer
        Get
            Return _Total
        End Get
        Set(ByVal value As Integer)
            _Total = value
        End Set
    End Property
    Private _IdZonaSucursal As Integer
    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=14)> _
    Public Property IdZona() As Integer
        Get
            Return _IdZonaSucursal
        End Get
        Set(value As Integer)
            _IdZonaSucursal = value
        End Set
    End Property
    Private _IdCargoSupervisorSucursal As Integer
    <WcfSerialization.DataMember(Name:="IdCargoSupervisor", IsRequired:=False, Order:=15)> _
    Public Property IdCargoSupervisor() As Integer
        Get
            Return _IdCargoSupervisorSucursal
        End Get
        Set(value As Integer)
            _IdCargoSupervisorSucursal = value
        End Set
    End Property

    Private _NombreCargo As String
    <WcfSerialization.DataMember(Name:="NombreCargo", IsRequired:=False, Order:=16)> _
    Public Property NombreCargo() As String
        Get
            Return _NombreCargo
        End Get
        Set(ByVal value As String)
            _NombreCargo = value
        End Set
    End Property
    Private _Cargo As Cargo
    <WcfSerialization.DataMember(Name:="Cargo", IsRequired:=False, Order:=17)> _
    Public Property Cargo() As Cargo
        Get
            Return _Cargo
        End Get
        Set(ByVal value As Cargo)
            _Cargo = value
        End Set
    End Property

    Private _Empleado As Empleado
    <WcfSerialization.DataMember(Name:="Empleado", IsRequired:=False, Order:=18)> _
    Public Property Empleado() As Empleado
        Get
            Return _Empleado
        End Get
        Set(ByVal value As Empleado)
            _Empleado = value
        End Set
    End Property
    Private _Perfil As Perfil
    <WcfSerialization.DataMember(Name:="Perfil", IsRequired:=False, Order:=19)> _
    Public Property Perfil() As Perfil
        Get
            Return _Perfil
        End Get
        Set(ByVal value As Perfil)
            _Perfil = value
        End Set
    End Property
    Private _zonaMantenimiento As ZonaMantenimiento
    <WcfSerialization.DataMember(Name:="ZonaMantenimiento", IsRequired:=False, Order:=19)> _
    Public Property ZonaMantenimiento() As ZonaMantenimiento
        Get
            Return _zonaMantenimiento
        End Get
        Set(ByVal value As ZonaMantenimiento)
            _zonaMantenimiento = value
        End Set
    End Property
    Private _ComisionEscala As ComisionEscala
    <WcfSerialization.DataMember(Name:="ComisionEscala", IsRequired:=False, Order:=20)> _
    Public Property ComisionEscala() As ComisionEscala
        Get
            Return _ComisionEscala
        End Get
        Set(ByVal value As ComisionEscala)
            _ComisionEscala = value
        End Set
    End Property
    Private _ComisionEscalaTiempoServicio As ComisionEscalaTiempoServicio
    <WcfSerialization.DataMember(Name:="ComisionEscalaTiempoServicio", IsRequired:=False, Order:=21)> _
    Public Property ComisionEscalaTiempoServicio() As ComisionEscalaTiempoServicio
        Get
            Return _ComisionEscalaTiempoServicio
        End Get
        Set(ByVal value As ComisionEscalaTiempoServicio)
            _ComisionEscalaTiempoServicio = value
        End Set
    End Property

    Private m_Reporta As String
    <WcfSerialization.DataMember(Name:="Reporta", IsRequired:=False, Order:=22)> _
    Public Property Reporta() As String
        Get
            Return m_Reporta
        End Get
        Set(value As String)
            m_Reporta = value
        End Set
    End Property
    Private _FechaSalida As Date
    <WcfSerialization.DataMember(Name:="FechaSalida", IsRequired:=False, Order:=23)> _
    Public Property FechaSalida() As Date
        Get
            Return _FechaSalida
        End Get
        Set(ByVal value As Date)
            _FechaSalida = value
        End Set
    End Property


End Class
