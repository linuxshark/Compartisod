

Imports Sodimac.VentaEmpresa.DataContracts
Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Public Class EmpleadoViewModel
    Private m_IdEmpleado As Integer
    Private m_IdEmpleadoCargoActual As Integer
    Private m_IdEmpleadoPerfilActual As Integer
    Private m_IdSucursalActual As Integer

    Private m_descripcionSucursal As Sucursal
    Private m_RazonSocial As ClienteVenta
    Private m_DescripcionCargo As EmpleadoCargo
    Private m_DescripcionPerfil As EmpleadoPerfil
    Private m_VentaCartera As VentaCartera
    Private m_TablaGeneral As TablaGeneral
    '' agregado
    Private m_descripcionZona As Zona
    Private m_descripcionCargoS As Cargo
    Private m_ComisionEscalaDetalle As ComisionEscalaDetalle
    Private m_ComisionEscalaTiempoServicio As ComisionEscalaTiempoServicio
    Private m_Perfil As Perfil
    Private m_PlanVentaEmpleado As PlanVentaEmpleado
    Private m_ComisionEscala As ComisionEscala
    Private m_Estado As Estado
    Private m_ListaEstado As ListaProcesoEstado
    Private m_ListaCargo As ListaCargo
    Private m_ProcesoEstado As ProcesoEstado
    Private m_ListaProcesoEstado As ListaProcesoEstado
    Private m_ZonaMantenimiento As ZonaMantenimiento
    Private m_ListaZonaMantenimiento As ListaZonaMantenimiento



    Private m_IdAreaDepartamento As Integer
    Private m_IdJefeVentas As Integer
    Private m_CodigoOfisis As String
    Private m_DNI As String
    Private m_Nombres As String
    Private m_Apellidos As String
    Private m_NombresApellidos As String
    Private m_NombresApellidos2 As String
    Private m_FechaNacimiento As Date
    Private m_FechaContrato As Date
    Private m_Telefono As String
    Private m_Email As String
    Private m_Direccion As String
    Private m_FechaDesde As Date
    Private m_FechaHasta As Date
    Private m_IdEstadoActual As Integer
    Private m_Activo As Boolean
    Private m_IdCliente As Integer
    Private m_Porcentaje As String
    Private m_PlanVentas As Decimal
    Private m_IngresoBasicoMensual As Decimal

    Private m_Reporta As String
    Private m_NombresApellidosCargo As String
    Private m_EscalaTiempoInicial As Integer

    Private m_UsuarioIngreso As String



    Public Property IdEmpleado() As Integer
        Get
            Return m_IdEmpleado
        End Get
        Set(value As Integer)
            m_IdEmpleado = value
        End Set
    End Property


    Public Property IdEmpleadoCargoActual() As Integer
        Get
            Return m_IdEmpleadoCargoActual
        End Get
        Set(value As Integer)
            m_IdEmpleadoCargoActual = value
        End Set
    End Property


    Public Property IdEmpleadoPerfilActual() As Integer
        Get
            Return m_IdEmpleadoPerfilActual
        End Get
        Set(value As Integer)
            m_IdEmpleadoPerfilActual = value
        End Set
    End Property


    Public Property IdSucursalActual() As Integer
        Get
            Return m_IdSucursalActual
        End Get
        Set(value As Integer)
            m_IdSucursalActual = value
        End Set
    End Property

    Public Property Sucursal() As Sucursal
        Get
            Return m_descripcionSucursal
        End Get
        Set(value As Sucursal)
            m_descripcionSucursal = value
        End Set
    End Property



    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_RazonSocial
        End Get
        Set(value As ClienteVenta)
            m_RazonSocial = value
        End Set
    End Property

    Public Property EmpleadoCargo() As EmpleadoCargo
        Get
            Return m_DescripcionCargo
        End Get
        Set(value As EmpleadoCargo)
            m_DescripcionCargo = value
        End Set
    End Property


    Public Property EmpleadoPerfil() As EmpleadoPerfil
        Get
            Return m_DescripcionPerfil
        End Get
        Set(value As EmpleadoPerfil)
            m_DescripcionPerfil = value
        End Set
    End Property


    Public Property Perfil() As Perfil
        Get
            Return m_Perfil
        End Get
        Set(value As Perfil)
            m_Perfil = value
        End Set
    End Property


    Public Property IdAreaDepartamento() As Integer
        Get
            Return m_IdAreaDepartamento
        End Get
        Set(value As Integer)
            m_IdAreaDepartamento = value
        End Set
    End Property


    Public Property IdJefeVentas() As Integer
        Get
            Return m_IdJefeVentas
        End Get
        Set(value As Integer)
            m_IdJefeVentas = value
        End Set
    End Property


    Public Property CodigoOfisis() As String
        Get
            Return m_CodigoOfisis
        End Get
        Set(value As String)
            m_CodigoOfisis = value
        End Set
    End Property


    Public Property DNI() As String
        Get
            Return m_DNI
        End Get
        Set(value As String)
            m_DNI = value
        End Set
    End Property

    Public Property Nombres() As String
        Get
            Return m_Nombres
        End Get
        Set(value As String)
            m_Nombres = value
        End Set
    End Property

    Public Property Apellidos() As String
        Get
            Return m_Apellidos
        End Get
        Set(value As String)
            m_Apellidos = value
        End Set
    End Property

    Public Property NombresApellidos() As String
        Get
            Return m_NombresApellidos
        End Get
        Set(value As String)
            m_NombresApellidos = value
        End Set
    End Property

    Public Property NombresApellidosCargo() As String
        Get
            Return m_NombresApellidosCargo
        End Get
        Set(value As String)
            m_NombresApellidosCargo = value
        End Set
    End Property


    Public Property FechaNacimiento() As Date
        Get
            Return m_FechaNacimiento
        End Get
        Set(value As Date)
            m_FechaNacimiento = value
        End Set
    End Property

    Public Property FechaContrato() As Date
        Get
            Return m_FechaContrato
        End Get
        Set(value As Date)
            m_FechaContrato = value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return m_Telefono
        End Get
        Set(value As String)
            m_Telefono = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(value As String)
            m_Email = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return m_Direccion
        End Get
        Set(value As String)
            m_Direccion = value
        End Set
    End Property

    Public Property FechaDesde() As Date
        Get
            Return m_FechaDesde
        End Get
        Set(value As Date)
            m_FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta() As Date
        Get
            Return m_FechaHasta
        End Get
        Set(value As Date)
            m_FechaHasta = value
        End Set
    End Property

    Public Property IdEstadoActual() As Integer
        Get
            Return m_IdEstadoActual
        End Get
        Set(value As Integer)
            m_IdEstadoActual = value
        End Set
    End Property

    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(value As Boolean)
            m_Activo = value
        End Set
    End Property

    Private _Celular1 As String

    Public Property Celular1() As String
        Get
            Return _Celular1
        End Get
        Set(ByVal value As String)
            _Celular1 = value
        End Set
    End Property

    Private _Celular2 As String

    Public Property Celular2() As String
        Get
            Return _Celular2
        End Get
        Set(ByVal value As String)
            _Celular2 = value
        End Set
    End Property

    Private _PersonalVenta As String

    Public Property PersonalVenta() As String
        Get
            Return _PersonalVenta
        End Get
        Set(ByVal value As String)
            _PersonalVenta = value
        End Set
    End Property


    Private _SucursalEmpleado As SucursalEmpleado

    Public Property SucursalEmpleado() As SucursalEmpleado
        Get
            Return _SucursalEmpleado
        End Get
        Set(ByVal value As SucursalEmpleado)
            _SucursalEmpleado = value
        End Set
    End Property

    Private _ListaSucursalEmpleado As List(Of SucursalEmpleado)

    Public Property ListaSucursalEmpleado() As List(Of SucursalEmpleado)
        Get
            Return _ListaSucursalEmpleado
        End Get
        Set(ByVal value As List(Of SucursalEmpleado))
            _ListaSucursalEmpleado = value
        End Set
    End Property

    Public Property VentaCartera() As VentaCartera
        Get
            Return m_VentaCartera
        End Get
        Set(value As VentaCartera)
            m_VentaCartera = value
        End Set
    End Property

    Private _ListaVentaCartera As List(Of VentaCartera)

    Public Property ListaVentaCartera() As List(Of VentaCartera)
        Get
            Return _ListaVentaCartera
        End Get
        Set(ByVal value As List(Of VentaCartera))
            _ListaVentaCartera = value
        End Set
    End Property


    Public Property TablaGeneral() As TablaGeneral
        Get
            Return m_TablaGeneral
        End Get
        Set(value As TablaGeneral)
            m_TablaGeneral = value
        End Set
    End Property

    Private _ListaTablaGeneral As List(Of TablaGeneral)

    Public Property ListaTablaGeneral() As List(Of TablaGeneral)
        Get
            Return _ListaTablaGeneral
        End Get
        Set(ByVal value As List(Of TablaGeneral))
            _ListaTablaGeneral = value
        End Set
    End Property



    Public Property IdCliente() As Integer
        Get
            Return m_IdCliente
        End Get
        Set(value As Integer)
            m_IdCliente = value
        End Set
    End Property


    Public Property Porcentaje() As String
        Get
            Return m_Porcentaje
        End Get
        Set(value As String)
            m_Porcentaje = value
        End Set
    End Property


    Public Property PlanVenta() As Decimal
        Get
            Return m_PlanVentas
        End Get
        Set(value As Decimal)
            m_PlanVentas = value
        End Set
    End Property


    Public Property IngresoBasicoMensual() As Decimal
        Get
            Return m_IngresoBasicoMensual
        End Get
        Set(value As Decimal)
            m_IngresoBasicoMensual = value
        End Set
    End Property


    Public Property Zona() As Zona
        Get
            Return m_descripcionZona
        End Get
        Set(value As Zona)
            m_descripcionZona = value
        End Set
    End Property

    Public Property Cargo() As Cargo
        Get
            Return m_descripcionCargoS
        End Get
        Set(value As Cargo)
            m_descripcionCargoS = value
        End Set
    End Property


    Public Property ComisionEscalaDetalle() As ComisionEscalaDetalle
        Get
            Return m_ComisionEscalaDetalle
        End Get
        Set(value As ComisionEscalaDetalle)
            m_ComisionEscalaDetalle = value
        End Set
    End Property

    Public Property ComisionEscalaTiempoServicio() As ComisionEscalaTiempoServicio
        Get
            Return m_ComisionEscalaTiempoServicio
        End Get
        Set(value As ComisionEscalaTiempoServicio)
            m_ComisionEscalaTiempoServicio = value
        End Set
    End Property

    Public Property Reporta() As String
        Get
            Return m_Reporta
        End Get
        Set(value As String)
            m_Reporta = value
        End Set
    End Property

    Public Property PlanVentaEmpleado() As PlanVentaEmpleado
        Get
            Return m_PlanVentaEmpleado
        End Get
        Set(value As PlanVentaEmpleado)
            m_PlanVentaEmpleado = value
        End Set
    End Property

    Public Property ComisionEscala() As ComisionEscala
        Get
            Return m_ComisionEscala
        End Get
        Set(value As ComisionEscala)
            m_ComisionEscala = value
        End Set
    End Property


    Public Property EscalaTiempoInicial() As Integer
        Get
            Return m_EscalaTiempoInicial
        End Get
        Set(value As Integer)
            m_EscalaTiempoInicial = value
        End Set
    End Property


    Public Property Estado() As Estado
        Get
            Return m_Estado
        End Get
        Set(value As Estado)
            m_Estado = value
        End Set
    End Property



    Public Property ListaProcesoEstado() As ListaProcesoEstado
        Get
            Return m_ListaEstado
        End Get
        Set(value As ListaProcesoEstado)
            m_ListaEstado = value
        End Set
    End Property

    Public Property ListaCargo() As ListaCargo
        Get
            Return m_ListaCargo
        End Get
        Set(value As ListaCargo)
            m_ListaCargo = value
        End Set
    End Property


    Public Property ProcesoEstado() As ProcesoEstado
        Get
            Return m_ProcesoEstado
        End Get
        Set(value As ProcesoEstado)
            m_ProcesoEstado = value
        End Set
    End Property
    '<WcfSerialization.DataMember(Name:="ListaProcesoEstado", IsRequired:=False, Order:=49)> _
    'Public Property ListaProcesoEstado() As ListaProcesoEstado
    '    Get
    '        Return m_ListaProcesoEstado
    '    End Get
    '    Set(value As ListaProcesoEstado)
    '        m_ListaProcesoEstado = value
    '    End Set
    'End Property

    Private m_IdEmpleadoAnterior As Integer
    Public Property IdEmpleadoAnterior() As Integer
        Get
            Return m_IdEmpleadoAnterior
        End Get
        Set(ByVal value As Integer)
            m_IdEmpleadoAnterior = value
        End Set
    End Property


    Public Property ZonaMantenimiento() As ZonaMantenimiento
        Get
            Return m_ZonaMantenimiento
        End Get
        Set(value As ZonaMantenimiento)
            m_ZonaMantenimiento = value
        End Set
    End Property

    Public Property ListaZonaMantenimiento() As ListaZonaMantenimiento
        Get
            Return m_ListaZonaMantenimiento
        End Get
        Set(value As ListaZonaMantenimiento)
            m_ListaZonaMantenimiento = value
        End Set
    End Property


    Private m_Reportar As String
    Public Property Reportar() As String
        Get
            Return m_Reportar
        End Get
        Set(ByVal value As String)
            m_Reportar = value
        End Set
    End Property


    Public Property NombresApellidos2() As String
        Get
            Return m_NombresApellidos2
        End Get
        Set(value As String)
            m_NombresApellidos2 = value
        End Set
    End Property


    Private _FechaSucursalUltimo As String

    Public Property FechaSucursalUltimo() As String
        Get
            Return _FechaSucursalUltimo
        End Get
        Set(ByVal value As String)
            _FechaSucursalUltimo = value
        End Set
    End Property


    Public Property UsuarioIngreso() As String
        Get
            Return m_UsuarioIngreso
        End Get
        Set(ByVal value As String)
            m_UsuarioIngreso = value
        End Set
    End Property


    Private _Empleado As Empleado
    Public Property Empleado() As Empleado
        Get
            Return _Empleado
        End Get
        Set(ByVal value As Empleado)
            _Empleado = value
        End Set
    End Property

    Public Property ListaProcesoCarga As List(Of Empleado)
        Get
            Return _ListaProcesoCarga
        End Get
        Set(value As List(Of Empleado))
            _ListaProcesoCarga = value
        End Set
    End Property
    Private _ListaProcesoCarga As List(Of Empleado)

End Class
