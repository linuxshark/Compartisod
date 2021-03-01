Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Sodimac.VentaEmpresa.DataContracts
'Imports Sodimac.PLE.Web.Mvc.Sodimac.PLE.Web.Mvc.ServicioVentas

Public Class VentasViewModel

    Private m_EmpleadoProvincia As EmpleadoProvincia
    Private m_ListaEmpleadoProvincia As List(Of EmpleadoProvincia)
    Private m_EmpleadoDepartamento As EmpleadoDepartamento
    Private m_ListaEmpleadoDepartamento As List(Of EmpleadoDepartamento)
    Private m_ListaComisionRepresentantesVenta As List(Of ComisionRepresentanteVenta)
    Private m_RepresentanteVenta As ComisionRepresentanteVenta
    Private m_VentaNombreRepresentante As VentaNombreRepresentante
    Private m_ListaVentaNombreRepresentante As List(Of VentaNombreRepresentante)

    Private m_Empleado As Empleado
    Private m_ListaVentaEmpleado As List(Of Empleado)
    Private m_ClienteSector As ClienteSector
    Private m_ListaClienteSector As List(Of ClienteSector)
    Private m_Sucursal As Sucursal
    Private m_ListaSucursal As List(Of Sucursal)
    Private m_Zona As Zona
    Private m_ListaZona As List(Of Zona)
    Private m_ClienteVenta As ClienteVenta
    Private m_ListaClienteVenta As List(Of ClienteVenta)
    Private m_EmpleadoCargo As EmpleadoCargo
    Private m_ListaEmpleadoCargo As List(Of EmpleadoCargo)
    Private m_EmpleadoPerfil As EmpleadoPerfil
    Private m_ListaEmpleadoPerfil As List(Of EmpleadoPerfil)
    Private m_Paginacion As Paginacion
    Private m_ListaPaginacion As List(Of Paginacion)
    Private m_Cargo As Cargo
    Private m_ListaCargo As List(Of Cargo)
    Private m_PlanVentaEmpleado As PlanVentaEmpleado
    Private m_ListaPerfil As ListaPerfil
    Private m_SucursalEmpleado As SucursalEmpleado
    Private m_ListaPlanVenta As ListaPlanVentaEmpleado
    Private m_ZonaMantenimiento As ZonaMantenimiento
    Private m_listaenteros As List(Of Integer)
    Private m_UsuarioIngreso As String
    Private m_ListaComisionPeriodoDetalle As ListaComisionPeriodoDetalle
    Private m_TiempoServicioTotal As Integer
    Private m_ListaTipoPerfil As List(Of TipoPerfil)
    Private m_ListaTipoRepresentanteVenta As ListaTipoRepresentanteVenta

    Public Property TiempoServicioTotal() As Integer
        Get
            Return m_TiempoServicioTotal
        End Get
        Set(ByVal value As Integer)
            m_TiempoServicioTotal = value
        End Set
    End Property


    Private _PageSize As Integer
    Public Property PageSize() As Integer
        Get
            Return _PageSize
        End Get
        Set(ByVal value As Integer)
            _PageSize = value
        End Set
    End Property


    Public Property Paginacion() As Paginacion
        Get
            Return m_Paginacion
        End Get
        Set(ByVal value As Paginacion)
            m_Paginacion = value
        End Set
    End Property


    Public Property ListaPaginacion() As List(Of Paginacion)
        Get
            Return m_ListaPaginacion
        End Get
        Set(ByVal value As List(Of Paginacion))
            m_ListaPaginacion = value
        End Set
    End Property


    Public Property EmpleadoPerfil() As EmpleadoPerfil
        Get
            Return m_EmpleadoPerfil
        End Get
        Set(ByVal value As EmpleadoPerfil)
            m_EmpleadoPerfil = value
        End Set
    End Property
    Public Property ListaEmpleadoPerfil() As List(Of EmpleadoPerfil)
        Get
            Return m_ListaEmpleadoPerfil
        End Get
        Set(ByVal value As List(Of EmpleadoPerfil))
            m_ListaEmpleadoPerfil = value
        End Set
    End Property

    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_ClienteVenta
        End Get
        Set(ByVal value As ClienteVenta)
            m_ClienteVenta = value
        End Set
    End Property
    Public Property ListaClienteVenta() As List(Of ClienteVenta)
        Get
            Return m_ListaClienteVenta
        End Get
        Set(ByVal value As List(Of ClienteVenta))
            m_ListaClienteVenta = value
        End Set
    End Property


    Public Property Sucursal() As Sucursal
        Get
            Return m_Sucursal
        End Get
        Set(ByVal value As Sucursal)
            m_Sucursal = value
        End Set
    End Property

    Private _ListaSucursal As ListaSucursal
    Public Property ListaSucursal() As ListaSucursal
        Get
            Return _ListaSucursal
        End Get
        Set(ByVal value As ListaSucursal)
            _ListaSucursal = value
        End Set
    End Property
    Private _ListaComisionEscalaDetalle As ListaComisionEscalaDetalle
    Public Property ListaComisionEscalaDetalle() As ListaComisionEscalaDetalle
        Get
            Return _ListaComisionEscalaDetalle
        End Get
        Set(value As ListaComisionEscalaDetalle)
            _ListaComisionEscalaDetalle = value
        End Set
    End Property
    Private _ListaComisionEscalaTiempoServicio As ListaComisionEscalaTiempoServicio
    Public Property ListaComisionEscalaTiempoServicio() As ListaComisionEscalaTiempoServicio
        Get
            Return _ListaComisionEscalaTiempoServicio
        End Get
        Set(value As ListaComisionEscalaTiempoServicio)
            _ListaComisionEscalaTiempoServicio = value
        End Set
    End Property
    Public Property Zona() As Zona
        Get
            Return m_Zona
        End Get
        Set(value As Zona)
            m_Zona = value
        End Set
    End Property

    Private _ListaZona As ListaZona
    Public Property ListaZona() As ListaZona
        Get
            Return _ListaZona
        End Get
        Set(value As ListaZona)
            _ListaZona = value
        End Set
    End Property
    Private _ListaZonaMantenimiento As ListaZonaMantenimiento
    Public Property ListaZonaMantenimiento() As ListaZonaMantenimiento
        Get
            Return _ListaZonaMantenimiento
        End Get
        Set(value As ListaZonaMantenimiento)
            _ListaZonaMantenimiento = value
        End Set
    End Property

    Public Property Cargo() As Cargo
        Get
            Return m_Cargo
        End Get
        Set(value As Cargo)
            m_Cargo = value
        End Set
    End Property
    Private _ListaCargo As ListaCargo
    Public Property ListaCargo() As ListaCargo
        Get
            Return _ListaCargo
        End Get
        Set(value As ListaCargo)
            _ListaCargo = value
        End Set
    End Property

    Public Property ListaClienteSector() As List(Of ClienteSector)
        Get
            Return m_ListaClienteSector
        End Get
        Set(ByVal value As List(Of ClienteSector))
            m_ListaClienteSector = value
        End Set
    End Property

    Public Property ClienteSector() As ClienteSector
        Get
            Return m_ClienteSector
        End Get
        Set(ByVal value As ClienteSector)
            m_ClienteSector = value
        End Set
    End Property

    Public Property EmpleadoProvincia() As EmpleadoProvincia
        Get
            Return m_EmpleadoProvincia
        End Get
        Set(ByVal value As EmpleadoProvincia)
            m_EmpleadoProvincia = value
        End Set
    End Property
    Public Property ListaEmpleadoProvincia() As List(Of EmpleadoProvincia)
        Get
            Return m_ListaEmpleadoProvincia
        End Get
        Set(ByVal value As List(Of EmpleadoProvincia))
            m_ListaEmpleadoProvincia = value
        End Set
    End Property


    Public Property ListaVentaEmpleado() As List(Of Empleado)
        Get
            Return m_ListaVentaEmpleado
        End Get
        Set(ByVal value As List(Of Empleado))
            m_ListaVentaEmpleado = value
        End Set
    End Property

    Private m_VentaEmpleado As VentaEmpleado
    Public Property VentaEmpleado() As VentaEmpleado
        Get
            Return m_VentaEmpleado
        End Get
        Set(ByVal value As VentaEmpleado)
            m_VentaEmpleado = value
        End Set
    End Property
    Public Property EmpleadoCargo() As EmpleadoCargo
        Get
            Return m_EmpleadoCargo
        End Get
        Set(ByVal value As EmpleadoCargo)
            m_EmpleadoCargo = value
        End Set
    End Property
    Public Property ListaEmpleadoCargo() As List(Of EmpleadoCargo)
        Get
            Return m_ListaEmpleadoCargo
        End Get
        Set(ByVal value As List(Of EmpleadoCargo))
            m_ListaEmpleadoCargo = value
        End Set
    End Property

    Public Property ListaPerfil() As ListaPerfil
        Get
            Return m_ListaPerfil
        End Get
        Set(value As ListaPerfil)
            m_ListaPerfil = value
        End Set
    End Property

    Public Property EmpleadoDepartamento() As EmpleadoDepartamento
        Get
            Return m_EmpleadoDepartamento
        End Get
        Set(ByVal value As EmpleadoDepartamento)
            m_EmpleadoDepartamento = value
        End Set
    End Property

    Public Property ListaEmpleadoDepartamento() As List(Of EmpleadoDepartamento)
        Get
            Return m_ListaEmpleadoDepartamento
        End Get
        Set(ByVal value As List(Of EmpleadoDepartamento))
            m_ListaEmpleadoDepartamento = value
        End Set
    End Property

    Public Property ListaEmpleado() As ListaEmpleado
        Get
            Return m_ListaEmpleado
        End Get
        Set(value As ListaEmpleado)
            m_ListaEmpleado = value
        End Set
    End Property
    Private m_ListaEmpleado As ListaEmpleado

    Public Property sortType() As [String]
        Get
            Return m_sortType
        End Get
        Set(value As [String])
            m_sortType = value
        End Set
    End Property
    Private m_sortType As [String]
    Public Property maximumRows() As Integer
        Get
            Return m_maximumRows
        End Get
        Set(value As Integer)
            m_maximumRows = value
        End Set
    End Property
    Private m_maximumRows As Integer
    Public Property startRowIndex() As Integer
        Get
            Return m_startRowIndex
        End Get
        Set(value As Integer)
            m_startRowIndex = value
        End Set
    End Property
    Private m_startRowIndex As Integer
    Public Property TotalRegistros() As Integer
        Get
            Return m_TotalRegistros
        End Get
        Set(value As Integer)
            m_TotalRegistros = value
        End Set
    End Property
    Private m_TotalRegistros As Integer
    Public Property RegistroPorPagina() As Integer
        Get
            Return m_RegistroPorPagina
        End Get
        Set(value As Integer)
            m_RegistroPorPagina = value
        End Set
    End Property

    Public Property ListaComisionRepresentantesVenta() As List(Of ComisionRepresentanteVenta)
        Get
            Return m_ListaComisionRepresentantesVenta
        End Get
        Set(ByVal value As List(Of ComisionRepresentanteVenta))
            m_ListaComisionRepresentantesVenta = value
        End Set
    End Property
    Public Property ComisionRepresentantesVenta() As ComisionRepresentanteVenta
        Get
            Return m_RepresentanteVenta
        End Get
        Set(ByVal value As ComisionRepresentanteVenta)
            m_RepresentanteVenta = value
        End Set
    End Property

    Public Property ListaVentaNombreRepresentante() As List(Of VentaNombreRepresentante)

        Get
            Return m_ListaVentaNombreRepresentante
        End Get
        Set(ByVal value As List(Of VentaNombreRepresentante))
            m_ListaVentaNombreRepresentante = value
        End Set

    End Property

    Public Property VentaNombreRepresentante() As VentaNombreRepresentante
        Get
            Return m_VentaNombreRepresentante
        End Get
        Set(ByVal value As VentaNombreRepresentante)
            m_VentaNombreRepresentante = value
        End Set
    End Property

    Private m_RegistroPorPagina As Integer


    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(ByVal value As Empleado)
            m_Empleado = value
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

    Private m_HistorialPlanVentaEmpleado As PlanVentaEmpleado
    Public Property HistorialPlanVentaEmpleado() As PlanVentaEmpleado
        Get
            Return m_HistorialPlanVentaEmpleado
        End Get
        Set(value As PlanVentaEmpleado)
            m_HistorialPlanVentaEmpleado = value
        End Set
    End Property

    Public Property SucursalEmpleado() As SucursalEmpleado
        Get
            Return m_SucursalEmpleado
        End Get
        Set(value As SucursalEmpleado)
            m_SucursalEmpleado = value
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
    Private _ListaComisionEscala As ListaComisionEscala
    Public Property ListaComisionEscala() As ListaComisionEscala
        Get
            Return _ListaComisionEscala
        End Get
        Set(value As ListaComisionEscala)
            _ListaComisionEscala = value
        End Set
    End Property
    Private _ListaPlanVentaEmpleado As ListaPlanVentaEmpleado
    Public Property ListaPlanVentaEmpleado() As ListaPlanVentaEmpleado
        Get
            Return _ListaPlanVentaEmpleado
        End Get
        Set(value As ListaPlanVentaEmpleado)
            _ListaPlanVentaEmpleado = value
        End Set
    End Property

    Private m_ProcesoEstado As ProcesoEstado
    Public Property ProcesoEstado() As ProcesoEstado
        Get
            Return m_ProcesoEstado
        End Get
        Set(value As ProcesoEstado)
            m_ProcesoEstado = value
        End Set
    End Property
    Private m_Estado As Estado
    Public Property Estado() As Estado
        Get
            Return m_Estado
        End Get
        Set(value As Estado)
            m_Estado = value
        End Set
    End Property

    Private _ListaProcesoEstado As ListaProcesoEstado
    Public Property ListaProcesoEstado() As ListaProcesoEstado
        Get
            Return _ListaProcesoEstado
        End Get
        Set(value As ListaProcesoEstado)
            _ListaProcesoEstado = value
        End Set
    End Property
    Private _ListaEstado As ListaEstado
    Public Property ListaEstado() As ListaEstado
        Get
            Return _ListaEstado
        End Get
        Set(value As ListaEstado)
            _ListaEstado = value
        End Set
    End Property

    Public Property listaenteros() As List(Of Integer)
        Get
            Return m_listaenteros
        End Get
        Set(value As List(Of Integer))
            m_listaenteros = value
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

    Public Property ListaComsionPeriodoDetalle() As ListaComisionPeriodoDetalle
        Get
            Return m_ListaComisionPeriodoDetalle
        End Get
        Set(ByVal value As ListaComisionPeriodoDetalle)
            m_ListaComisionPeriodoDetalle = value
        End Set
    End Property

    Public Property ListaTipoPerfil() As List(Of TipoPerfil)
        Get
            Return m_ListaTipoPerfil
        End Get
        Set(value As List(Of TipoPerfil))
            m_ListaTipoPerfil = value
        End Set
    End Property

    Public Property ListaTipoRepresentanteVenta() As ListaTipoRepresentanteVenta
        Get
            Return m_ListaTipoRepresentanteVenta
        End Get
        Set(ByVal value As ListaTipoRepresentanteVenta)
            m_ListaTipoRepresentanteVenta = value
        End Set
    End Property

End Class
