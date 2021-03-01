Imports Sodimac.VentaEmpresa.DataContracts
Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class ClientesViewModel
    Public ListaEmpleadoDepartamento As ListaEmpleadoDepartamento
    Public ListaEmpleadoProvincia As ListaEmpleadoProvincia
    Public ListaEmpleadoDistrito As ListaEmpleadoDistrito
    Public ListaClienteLineaCredito As ListaClienteLineaCredito
    Public ListaClienteSector As ListaClienteSector
    Public ListaClienteTipo As ListaClienteTipo
    Public ListaClienteCategoria As ListaClienteCategoria
    Public ListaProcesoEstado As ListaProcesoEstado
    Public ListaContactoTipo As ListaContactoTipo
    Public ListaContactoClase As ListaContactoClase
    Private m_Sucursal As Sucursal
    Private m_ListaSucursal As ListaSucursal
    Public m_ListaClienteVenta As ListaClienteVenta
    Public ListaClienteModoPagoCliente As ListaClienteModoPagoCombo
    Public m_ListaClienteVenta2 As ListaClienteVenta
    Public m_ListaZonaMantenimiento As ListaZonaMantenimiento
    Public m_ListaGrupo As ListaGrupo
    Public ListaTipoDocumentoCliente As ListaTipoDocumento

    Private _ClienteVenta As ClienteVenta
    Private m_ClienteContacto As ClienteContacto
    Private m_Paginacion As Paginacion
    Private m_TotalRegistros As Integer
    Private m_ContadorPorPaginas As Integer
    Private _ContactoTipo As ContactoTipo
    Private _ContactoClase As ContactoClase
    Private _ClienteAdjunto As ClienteAdjunto
    Private _ZonaMantenimiento As ZonaMantenimiento
    Private _GrupoMantenimiento As Grupo

    Private _PaginacionAdj As Paginacion

    Private m_ParametroExt As Parametro

    Private m_ParametroLong As Parametro

    Private _FileUploadCliente As HttpPostedFileBase

    Private m_ClienteModoPagoCombo As ClienteModoPagoCombo

    Private m_ClienteTipo As ClienteTipo

    Private m_ClienteLineaCredito As ClienteLineaCredito

    Public Property ClienteVenta() As ClienteVenta
        Get
            Return _ClienteVenta
        End Get
        Set(ByVal value As ClienteVenta)
            _ClienteVenta = value
        End Set
    End Property

    Public Property ClienteLineaCredito() As ClienteLineaCredito
        Get
            Return m_ClienteLineaCredito
        End Get
        Set(ByVal value As ClienteLineaCredito)
            m_ClienteLineaCredito = value
        End Set
    End Property


    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    Public Property FileUploadCliente() As HttpPostedFileBase
        Get
            Return _FileUploadCliente
        End Get
        Set(value As HttpPostedFileBase)
            _FileUploadCliente = value
        End Set
    End Property

    Public Property ParametroLong As Parametro
        Get
            Return m_ParametroLong
        End Get
        Set(ByVal value As Parametro)
            m_ParametroLong = value
        End Set
    End Property


    Public Property PaginacionClienteAdjunto() As Paginacion
        Get
            Return _PaginacionAdj
        End Get
        Set(ByVal value As Paginacion)
            _PaginacionAdj = value
        End Set
    End Property


    Public Property ContactoTipo() As ContactoTipo
        Get
            Return _ContactoTipo
        End Get
        Set(ByVal value As ContactoTipo)
            _ContactoTipo = value
        End Set
    End Property
    Public Property ContactoClase() As ContactoClase
        Get
            Return _ContactoClase
        End Get
        Set(ByVal value As ContactoClase)
            _ContactoClase = value
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
    Public Property TotalRegistros() As Integer
        Get
            Return m_TotalRegistros
        End Get
        Set(ByVal value As Integer)
            m_TotalRegistros = value
        End Set
    End Property


    Public Property ClienteContacto() As ClienteContacto
        Get
            Return m_ClienteContacto
        End Get
        Set(ByVal value As ClienteContacto)
            m_ClienteContacto = value
        End Set
    End Property

    Public Property ClienteModoPagoCombo() As ClienteModoPagoCombo
        Get
            Return m_ClienteModoPagoCombo
        End Get
        Set(ByVal value As ClienteModoPagoCombo)
            m_ClienteModoPagoCombo = value
        End Set
    End Property

    Public Property ClienteTipo() As ClienteTipo
        Get
            Return m_ClienteTipo
        End Get
        Set(ByVal value As ClienteTipo)
            m_ClienteTipo = value
        End Set
    End Property

    Public Property ParametroExt As Parametro
        Get
            Return m_ParametroExt
        End Get
        Set(ByVal value As Parametro)
            m_ParametroExt = value
        End Set
    End Property

    Public Property ClienteAdjunto() As ClienteAdjunto
        Get
            Return _ClienteAdjunto
        End Get
        Set(ByVal value As ClienteAdjunto)
            _ClienteAdjunto = value
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
    Public Property arraySucursales() As [String]
        Get
            Return m_arraySucursales
        End Get
        Set(value As [String])
            m_arraySucursales = value
        End Set
    End Property
    Private m_arraySucursales As [String]

    Private _ListaEmpleado As ListaEmpleado
    Public Property ListaEmpleado() As ListaEmpleado
        Get
            Return _ListaEmpleado
        End Get
        Set(ByVal value As ListaEmpleado)
            _ListaEmpleado = value
        End Set
    End Property

    Private m_Empleado As Empleado
    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(ByVal value As Empleado)
            m_Empleado = value
        End Set

    End Property

    Private _ListaVentaCartera As ListaVentaCartera
    Public Property ListaVentaCartera() As ListaVentaCartera
        Get
            Return _ListaVentaCartera
        End Get
        Set(ByVal value As ListaVentaCartera)
            _ListaVentaCartera = value
        End Set
    End Property

    Private m_VentaCartera As VentaCartera
    Public Property VentaCartera() As VentaCartera
        Get
            Return m_VentaCartera
        End Get
        Set(ByVal value As VentaCartera)
            m_VentaCartera = value
        End Set
    End Property


    Private m_GuardaArchivo As Boolean
    Public Property GuardaArchivo() As Boolean
        Get
            Return m_GuardaArchivo
        End Get
        Set(ByVal value As Boolean)
            m_GuardaArchivo = value
        End Set
    End Property



    Public Property ListaClienteVenta() As ListaClienteVenta
        Get
            Return m_ListaClienteVenta
        End Get
        Set(value As ListaClienteVenta)
            m_ListaClienteVenta = value
        End Set
    End Property

    Public Property ListaClienteVenta2() As ListaClienteVenta
        Get
            Return m_ListaClienteVenta2
        End Get
        Set(value As ListaClienteVenta)
            m_ListaClienteVenta2 = value
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

    Public Property ZonaMantenimiento() As ZonaMantenimiento
        Get
            Return _ZonaMantenimiento
        End Get
        Set(value As ZonaMantenimiento)
            _ZonaMantenimiento = value
        End Set
    End Property



    Public Property ListaGrupo() As ListaGrupo
        Get
            Return m_ListaGrupo
        End Get
        Set(ByVal value As ListaGrupo)
            m_ListaGrupo = value
        End Set
    End Property

    Public Property Grupo() As Grupo
        Get
            Return _GrupoMantenimiento
        End Get
        Set(ByVal value As Grupo)
            _GrupoMantenimiento = value
        End Set
    End Property



End Class
