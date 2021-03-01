Imports Sodimac.VentaEmpresa.DataContracts
Public Class ProcesoViewModel

    Private m_Sucursal As Sucursal
    Private m_ListaSucursal As List(Of Sucursal)
    Private m_Zona As Zona
    Private m_ListaZona As List(Of Zona)
    Private m_ClienteVenta As ClienteVenta
    Private m_ListaClienteVenta As List(Of ClienteVenta)
    Private m_ListaPlanVenta As ListaPlanVentaEmpleado
    Private m_ZonaMantenimiento As ZonaMantenimiento
    Dim _ListaOperacion As List(Of TipoOperacion)
    Private m_mensaje As String

    Private m_PaginacionCartera As Paginacion
    Private m_ListaProcesoCargaErrorCartera As List(Of ClienteCartera)
    Private m_DesAccion As String
    Private m_DesAccionAnt As String
    Private m_PaginacionCliente As Paginacion
    Private _ClienteCartera As ClienteCartera

    Public Mes As Mes
    Public ListaMeses As List(Of Mes)
    Public m_ListaClienteCartera As List(Of ClienteCartera)
    Public m_ListaClienteCarteraTotal As List(Of ClienteCartera)

    Public Property ClienteCartera() As ClienteCartera
        Get
            Return _ClienteCartera
        End Get
        Set(ByVal value As ClienteCartera)
            _ClienteCartera = value
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

    Public Property ListaProcesoCargaErrorCartera As List(Of ClienteCartera)
        Get
            Return m_ListaProcesoCargaErrorCartera
        End Get
        Set(value As List(Of ClienteCartera))
            m_ListaProcesoCargaErrorCartera = value
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

    Public Property mensaje As String
        Get
            Return m_mensaje
        End Get
        Set(ByVal value As String)
            m_mensaje = value
        End Set
    End Property

    Public Property ListaProcesoCarga As ListaProcesoCarga
        Get
            Return _ListaProcesoCarga
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCarga = value
        End Set
    End Property
    Private _ListaProcesoCarga As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorRuc As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorRuc
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorRuc = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorRuc As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorSku As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorSku
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorSku = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorSku As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorTotal As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorTotal
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorTotal = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorTotal As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorTpoDoc As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorTpoDoc
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorTpoDoc = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorTpoDoc As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorSucu As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorSucu
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorSucu = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorSucu As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorNumeroDoc As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorNumeroDoc
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorNumeroDoc = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorNumeroDoc As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorFecha As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorFecha
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorFecha = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorFecha As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorCantidad As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorCantidad
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorCantidad = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorCantidad As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorValVenta As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorValVenta
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorValVenta = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorValVenta As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorIgv As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorIgv
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorIgv = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorIgv As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorTC As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorTC
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorTC = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorTC As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorCostoTotal As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorCostoTotal
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorCostoTotal = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorCostoTotal As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorPorcentajePercepcion As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorPorcentajePercepcion
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorPorcentajePercepcion = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorPorcentajePercepcion As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorMontoPercepcion As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorMontoPercepcion
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorMontoPercepcion = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorMontoPercepcion As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorTotalVtaIgvPercepcion As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorTotalVtaIgvPercepcion
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorTotalVtaIgvPercepcion = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorTotalVtaIgvPercepcion As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorTotales As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorTotales
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorTotales = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorTotales As ListaProcesoCarga

    Public Property ListaProcesoCargaHistorica As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaHistorica
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaHistorica = value
        End Set
    End Property
    Private _ListaProcesoCargaHistorica As ListaProcesoCarga

    Public Property ListaProcesoCargaErrorMoneda As ListaProcesoCarga
        Get
            Return _ListaProcesoCargaErrorMoneda
        End Get
        Set(value As ListaProcesoCarga)
            _ListaProcesoCargaErrorMoneda = value
        End Set
    End Property
    Private _ListaProcesoCargaErrorMoneda As ListaProcesoCarga

    Public Property ProcesoCarga As ProcesoCarga
        Get
            Return _ProcesoCarga
        End Get
        Set(value As ProcesoCarga)
            _ProcesoCarga = value
        End Set
    End Property
    Private _ProcesoCarga As ProcesoCarga

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

    Public Property NumeroRegistros() As Integer
        Get
            Return m_NumeroRegistros
        End Get
        Set(value As Integer)
            m_NumeroRegistros = value
        End Set
    End Property
    Private m_NumeroRegistros As Integer

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

    Public Property Hoja() As String
        Get
            Return _Hoja
        End Get
        Set(value As String)
            _Hoja = value
        End Set
    End Property
    Protected _Hoja As String

    Public Property TotalErrores As Int64
        Get
            Return _TotalErrores
        End Get
        Set(value As Int64)
            _TotalErrores = value
        End Set
    End Property
    Protected _TotalErrores As Int64

    Public Property TotalCorrectos As Int64
        Get
            Return _TotalCorrectos
        End Get
        Set(value As Int64)
            _TotalCorrectos = value
        End Set
    End Property
    Protected _TotalCorrectos As Int64

    Public Property DescripcionCorrectos As String
        Get
            Return _DescripcionCorrectos
        End Get
        Set(value As String)
            _DescripcionCorrectos = value
        End Set
    End Property
    Protected _DescripcionCorrectos As String

    Public Property DescripcionErrores As String
        Get
            Return _DescripcionErrores
        End Get
        Set(value As String)
            _DescripcionErrores = value
        End Set
    End Property
    Protected _DescripcionErrores As String

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

    Private _ListaZonaMantenimiento As ListaZonaMantenimiento
    Public Property ListaZonaMantenimiento() As ListaZonaMantenimiento
        Get
            Return _ListaZonaMantenimiento
        End Get
        Set(value As ListaZonaMantenimiento)
            _ListaZonaMantenimiento = value
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
    Private _ListaZona As ListaZona
    Public Property ListaZona() As ListaZona
        Get
            Return _ListaZona
        End Get
        Set(value As ListaZona)
            _ListaZona = value
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

    Private _ListaParametros As ListaParametro
    Public Property ListaParametros() As ListaParametro
        Get
            Return _ListaParametros
        End Get
        Set(ByVal value As ListaParametro)
            _ListaParametros = value
        End Set
    End Property


    Public Property ListaOperacion() As List(Of TipoOperacion)
        Get
            Return _ListaOperacion
        End Get
        Set(ByVal value As List(Of TipoOperacion))
            _ListaOperacion = value
        End Set
    End Property


    Private _Operacion As TipoOperacion
    Public Property Operacion() As TipoOperacion
        Get
            Return _Operacion
        End Get
        Set(ByVal value As TipoOperacion)
            _Operacion = value
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


    Private _ListaProcesoCargaE As ListaEmpleado
    Public Property ListaProcesoCargaE As ListaEmpleado
        Get
            Return _ListaProcesoCargaE
        End Get
        Set(value As ListaEmpleado)
            _ListaProcesoCargaE = value
        End Set
    End Property

    Private _ListaProcesoCargaEmpleados As List(Of Empleado)
    Public Property ListaProcesoCargaEmpleados As List(Of Empleado)
        Get
            Return _ListaProcesoCargaEmpleados
        End Get
        Set(value As List(Of Empleado))
            _ListaProcesoCargaEmpleados = value
        End Set
    End Property


    Private _ListaProcesoCargaEmpleadostOTALES As List(Of Empleado)
    Public Property ListaProcesoCargaEmpleadostOTALES As List(Of Empleado)
        Get
            Return _ListaProcesoCargaEmpleadostOTALES
        End Get
        Set(value As List(Of Empleado))
            _ListaProcesoCargaEmpleadostOTALES = value
        End Set
    End Property

    Private _ListarProcesoCargaEErrores As ListaEmpleado
    Public Property ListarProcesoCargaEErrores() As ListaEmpleado
        Get
            Return _ListarProcesoCargaEErrores
        End Get
        Set(ByVal value As ListaEmpleado)
            _ListarProcesoCargaEErrores = value
        End Set
    End Property











    Private _Perfil As List(Of Perfil)
    Public Property Perfil() As List(Of Perfil)
        Get
            Return _Perfil
        End Get
        Set(ByVal value As List(Of Perfil))
            _Perfil = value
        End Set
    End Property

    Private _Variable As String
    Public Property Variable() As String
        Get
            Return _Variable
        End Get
        Set(ByVal value As String)
            _Variable = value
        End Set
    End Property
    Private m_PaginacionEmpleado As Paginacion
    Public Property PaginacionEmpleado As Paginacion
        Get
            Return m_PaginacionEmpleado
        End Get
        Set(value As Paginacion)
            m_PaginacionEmpleado = value
        End Set
    End Property

    Private m_grabar As String
    Public Property grabar As String
        Get
            Return m_grabar
        End Get
        Set(value As String)
            m_grabar = value
        End Set
    End Property

End Class