Imports Sodimac.VentaEmpresa.DataContracts
Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc

Public Class MantenimientoViewModel

    Inherits Parameters
    Private m_PaginacionCartera As Paginacion
    Private m_ListaProcesoCargaErrorCartera As List(Of ClienteCartera)
    Private m_mensaje As String
    Private m_DesAccion As String
    Private m_DesAccionAnt As String
    Private m_grabar As String
    Private m_PaginacionCliente As Paginacion

    Public m_Mes As Mes
    Public m_ListaMes As List(Of Mes)
    Public m_ListaClienteCartera As List(Of ClienteCartera)
    Public m_ListaClienteCarteraTotal As List(Of ClienteCartera)

    Public Property Mes() As Mes
        Get
            Return m_Mes
        End Get
        Set(ByVal value As Mes)
            m_Mes = value
        End Set
    End Property

    Public Property ListaMes As List(Of Mes)
        Get
            Return m_ListaMes
        End Get
        Set(value As List(Of Mes))
            m_ListaMes = value
        End Set
    End Property

    Public Property ListaClienteCarteraTotal As List(Of ClienteCartera)
        Get
            Return m_ListaClienteCarteraTotal
        End Get
        Set(value As List(Of ClienteCartera))
            m_ListaClienteCarteraTotal = value
        End Set
    End Property

    Public Property ListaClienteCartera As List(Of ClienteCartera)
        Get
            Return m_ListaClienteCartera
        End Get
        Set(value As List(Of ClienteCartera))
            m_ListaClienteCartera = value
        End Set
    End Property

    Private _ClienteCartera As ClienteCartera

    Public Property grabar As String
        Get
            Return m_grabar
        End Get
        Set(value As String)
            m_grabar = value
        End Set
    End Property

    Public Property DesAccionAnt As String
        Get
            Return m_DesAccionAnt
        End Get
        Set(value As String)
            m_DesAccionAnt = value
        End Set
    End Property

    Public Property DesAccion As String
        Get
            Return m_DesAccion
        End Get
        Set(value As String)
            m_DesAccion = value
        End Set
    End Property

    Public Property mensaje As String
        Get
            Return m_mensaje
        End Get
        Set(value As String)
            m_mensaje = value
        End Set
    End Property
    Public Property ListaProcesoCargaErrorCartera As List(Of ClienteCartera)
        Get
            Return m_ListaProcesoCargaErrorCartera
        End Get
        Set(value As List(Of ClienteCartera))
            m_ListaProcesoCargaErrorCartera = value
        End Set
    End Property
    Public Property PaginacionCartera As Paginacion
        Get
            Return m_PaginacionCartera
        End Get
        Set(value As Paginacion)
            m_PaginacionCartera = value
        End Set
    End Property
    Public Property ClienteCartera() As ClienteCartera
        Get
            Return _ClienteCartera
        End Get
        Set(ByVal value As ClienteCartera)
            _ClienteCartera = value
        End Set
    End Property

    Public ListaPerfil As ListaPerfil
    'Public ListaZonaMantenimiento As ListaZonaMantenimiento
    Private _Perfil As Perfil
    Public Property Perfil() As Perfil
        Get
            Return _Perfil
        End Get
        Set(ByVal value As Perfil)
            _Perfil = value
        End Set
    End Property

    Public ListaEmpleadoPerfil As ListaEmpleadoPerfil
    Private _EmpleadoPerfil As EmpleadoPerfil
    Public Property EmpleadoPerfil() As EmpleadoPerfil
        Get
            Return _EmpleadoPerfil
        End Get
        Set(value As EmpleadoPerfil)
            _EmpleadoPerfil = value
        End Set
    End Property
    Public ListaGrupoClienteMantenimiento As ListaGrupoClienteMantenimiento
    Property _GrupoClienteMantenimiento As GrupoClienteMantenimiento
    Public Property GrupoClienteMantenimiento() As GrupoClienteMantenimiento
        Get
            Return _GrupoClienteMantenimiento
        End Get
        Set(value As GrupoClienteMantenimiento)
            _GrupoClienteMantenimiento = value
        End Set
    End Property


    Public ListaClienteVenta As ListaClienteVenta
    Private m_ClienteVenta As ClienteVenta
    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_ClienteVenta
        End Get
        Set(ByVal value As ClienteVenta)
            m_ClienteVenta = value
        End Set
    End Property


    Public ListaCargo As ListaCargo
    Private _Cargo As Cargo
    Public Property Cargo() As Cargo
        Get
            Return _Cargo
        End Get
        Set(ByVal value As Cargo)
            _Cargo = value
        End Set
    End Property
    Public ListaSucursalSeleccionadas As ListaSucursalSeleccionadas
    Public ListaSucursal As ListaSucursal
    Private _Sucursal As Sucursal
    Public Property Sucursal() As Sucursal
        Get
            Return _Sucursal
        End Get
        Set(ByVal value As Sucursal)
            _Sucursal = value
        End Set
    End Property


    Public ListaSucursalMantenimiento As ListaSucursalMantenimiento
    Private _SucursalMantenimiento As SucursalMantenimiento
    Public Property SucursalMantenimiento() As SucursalMantenimiento
        Get
            Return _SucursalMantenimiento
        End Get
        Set(ByVal value As SucursalMantenimiento)
            _SucursalMantenimiento = value
        End Set
    End Property
    Public ListaDepartamento As ListaDepartamento
    Private _departamento As Departamento
    Public Property Departamento() As Departamento
        Get
            Return _departamento
        End Get
        Set(value As Departamento)
            _departamento = value
        End Set
    End Property
    Public ListaProvincia As ListaProvincia
    Private _provincia As Provincia
    Public Property Provincia() As Provincia
        Get
            Return _provincia
        End Get
        Set(value As Provincia)
            _provincia = value
        End Set
    End Property
    Public ListaDistrito As ListaDistrito
    Private _distrito As Distrito
    Public Property Distrito() As Distrito
        Get
            Return _distrito
        End Get
        Set(value As Distrito)
            _distrito = value
        End Set
    End Property

    Public ListaZonaMantenimiento As ListaZonaMantenimiento
    Private _Zona As ZonaMantenimiento
    Public Property Zona() As ZonaMantenimiento
        Get
            Return _Zona
        End Get
        Set(ByVal value As ZonaMantenimiento)
            _Zona = value
        End Set
    End Property
    Public ListaClientesSeleccionadas As ListaClientesSeleccionadas
    Public ListaGrupo As ListaGrupo
    Private m_Grupo As Grupo
    Public Property Grupo() As Grupo
        Get
            Return m_Grupo
        End Get
        Set(value As Grupo)
            m_Grupo = value
        End Set
    End Property

    Private _Paginacion As Paginacion
    Public Property Paginacion() As Paginacion
        Get
            Return _Paginacion
        End Get
        Set(ByVal value As Paginacion)
            _Paginacion = value
        End Set
    End Property


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
    Private m_RegistroPorPagina As Integer
    Public Property DescRegistrosPorPagina() As String
        Get
            Return m_DescRegistrosPorPagina
        End Get
        Set(value As String)
            m_DescRegistrosPorPagina = value
        End Set
    End Property
    Private m_DescRegistrosPorPagina As String

    Private m_PlanVentaEmpleado As PlanVentaEmpleado
    Public Property PlanVentaEmpleado() As PlanVentaEmpleado
        Get
            Return m_PlanVentaEmpleado
        End Get
        Set(ByVal value As PlanVentaEmpleado)
            m_PlanVentaEmpleado = value
        End Set
    End Property

    Private m_PlanTipoRepresentanteVenta As PlanTipoRepresentanteVenta
    Public Property PlanTipoRepresentanteVenta() As PlanTipoRepresentanteVenta
        Get
            Return m_PlanTipoRepresentanteVenta
        End Get
        Set(ByVal value As PlanTipoRepresentanteVenta)
            m_PlanTipoRepresentanteVenta = value
        End Set
    End Property

    Private m_ListaPlanTipoRepresentanteVenta As ListaPlanTipoRepresentanteVenta
    Public Property ListaPlanTipoRepresentanteVenta() As ListaPlanTipoRepresentanteVenta
        Get
            Return m_ListaPlanTipoRepresentanteVenta
        End Get
        Set(ByVal value As ListaPlanTipoRepresentanteVenta)
            m_ListaPlanTipoRepresentanteVenta = value
        End Set
    End Property

    Public ListaFamilia As ListaFamilia
    Public Property Familia As Familia
    Public ListaDescuentoFamilia As ListaDescuentoFamilia
    Public Property DescuentoFamilia As DescuentoFamilia
    Public ListaProducto As ListaProducto
    Public Property Producto As Producto
    Public ListaDescuentoSku As ListaDescuentoSku
    Public Property DescuentoSku As DescuentoSku
    Public ListaMarca As ListaMarca
    Public Property Marca As Marca
    Public Property FechaIni As String
    Public Property FechaFin As String
    Public Property RucRazSoc As String
    Public Property ListaSubGerente As ListaEmpleado
    Public Property SubGerente As Empleado
    Public Property ListaJefeRegional As ListaEmpleado
    Public Property JefeRegional As Empleado
    Public Property CodOfisisEmpleado As String
    Public Property SkuProducto As String
    Public Property NroCotizacion As String
    Public Property Cotizacion As Cotizacion
    Public Property ListaTipoProforma As List(Of MantenimientoController.TipoProforma)
    Public Property TipoProforma As MantenimientoController.TipoProforma
End Class
