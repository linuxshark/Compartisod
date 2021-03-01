Imports Sodimac.VentaEmpresa.DataContracts

Public Class CargaMasivaClienteViewModel
    Inherits Parameters
    Private m_TipoOperacion As TipoOperacion
    Private m_ListaTipoOperacion As List(Of TipoOperacion)
    Private m_CargaMasivaCliente As CargaMasivaCliente
    Private m_ListaCliente As List(Of CargaMasivaCliente)
    Private m_ListaClienteEmpleado As List(Of CargaMasivaCliente)
    Private m_ListaClienteTotal As List(Of CargaMasivaCliente)
    Private m_ListaClienteEmpleadoTotal As List(Of CargaMasivaCliente)
    Private m_PaginacionCliente As Paginacion
    Private m_PaginacionClienteEmpleado As Paginacion
    Private m_Empleado As Empleado
    Private m_ListaProcesoCargaErrorCliente As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorClienteEmpleado As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorRUC As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorNomComercial As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorDepartamento As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorProvincia As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorDistrito As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorFechaIngreso As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorFechaVigencia As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorGrupo As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorSectorEconomico As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorCategoria As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorTipo As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorAutorizar As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorTipoContacto As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorClaseContacto As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorNomContacto As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorApContacto As List(Of CargaMasivaCliente)
    Private m_ListaProcesoCargaErrorTotales As ListaErrorCargaMasiva
    Private m_mensaje As String
    Private m_DesAccion As String
    Private m_DesAccionAnt As String
    Private m_grabar As String

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

    Public Property ListaProcesoCargaErrorTotales As ListaErrorCargaMasiva
        Get
            Return m_ListaProcesoCargaErrorTotales
        End Get
        Set(value As ListaErrorCargaMasiva)
            m_ListaProcesoCargaErrorTotales = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorCliente As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorCliente
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorCliente = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorClienteEmpleado As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorCliente
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorCliente = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorRUC As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorRUC
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorRUC = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorNomComercial As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorNomComercial
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorNomComercial = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorDepartamento As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorDepartamento
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorDepartamento = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorProvincia As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorProvincia
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorProvincia = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorDistrito As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorDistrito
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorDistrito = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorFechaIngreso As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorFechaIngreso
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorFechaIngreso = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorFechaVigencia As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorFechaVigencia
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorFechaVigencia = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorGrupo As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorGrupo
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorGrupo = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorSectorEconomico As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorSectorEconomico
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorSectorEconomico = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorCategoria As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorCategoria
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorCategoria = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorTipo As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorTipo
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorTipo = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorAutorizar As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorAutorizar
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorAutorizar = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorTipoContacto As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorTipoContacto
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorTipoContacto = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorClaseContacto As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorClaseContacto
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorClaseContacto = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorNomContacto As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorNomContacto
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorNomContacto = value
        End Set
    End Property

    Public Property ListaProcesoCargaErrorApContacto As List(Of CargaMasivaCliente)
        Get
            Return m_ListaProcesoCargaErrorApContacto
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaProcesoCargaErrorApContacto = value
        End Set
    End Property

    Public Property TipoOperacion As TipoOperacion
        Get
            Return m_TipoOperacion
        End Get
        Set(value As TipoOperacion)
            m_TipoOperacion = value
        End Set
    End Property

    Public Property ListaTipoOperacion As List(Of TipoOperacion)
        Get
            Return m_ListaTipoOperacion
        End Get
        Set(value As List(Of TipoOperacion))
            m_ListaTipoOperacion = value
        End Set
    End Property

    Public Property ListaCliente As List(Of CargaMasivaCliente)
        Get
            Return m_ListaCliente
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaCliente = value
        End Set
    End Property

    Public Property ListaClienteEmpleado As List(Of CargaMasivaCliente)
        Get
            Return m_ListaClienteEmpleado
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaClienteEmpleado = value
        End Set
    End Property

    Public Property ListaClienteTotal As List(Of CargaMasivaCliente)
        Get
            Return m_ListaClienteTotal
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaClienteTotal = value
        End Set
    End Property

    Public Property ListaClienteEmpleadoTotal As List(Of CargaMasivaCliente)
        Get
            Return m_ListaClienteEmpleadoTotal
        End Get
        Set(value As List(Of CargaMasivaCliente))
            m_ListaClienteEmpleadoTotal = value
        End Set
    End Property

    Public Property CargaMasivaCliente As CargaMasivaCliente
        Get
            Return m_CargaMasivaCliente
        End Get
        Set(value As CargaMasivaCliente)
            m_CargaMasivaCliente = value
        End Set
    End Property

    Public Property PaginacionCliente As Paginacion
        Get
            Return m_PaginacionCliente
        End Get
        Set(value As Paginacion)
            m_PaginacionCliente = value
        End Set
    End Property

    Public Property PaginacionClienteEmpleado As Paginacion
        Get
            Return m_PaginacionClienteEmpleado
        End Get
        Set(value As Paginacion)
            m_PaginacionClienteEmpleado = value
        End Set
    End Property

    'Public Property TipoVendedor As TablaGeneral
    '    Get
    '        Return m_TipoVendedor
    '    End Get
    '    Set(value As TablaGeneral)
    '        m_TipoVendedor = value
    '    End Set
    'End Property

    'Public Property Sucursal As Sucursal
    '    Get
    '        Return m_Sucursal
    '    End Get
    '    Set(value As Sucursal)
    '        m_Sucursal = value
    '    End Set
    'End Property
End Class
