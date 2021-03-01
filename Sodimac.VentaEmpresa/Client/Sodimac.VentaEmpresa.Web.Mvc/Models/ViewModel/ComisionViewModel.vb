Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.Common
Imports Sodimac.VentaEmpresa.Web.Mvc.UtilFile

Public Class ComisionViewModel

    Private _maximumRows As Integer
    Private _startRowIndex As Integer
    Private m_rowsPerPage As Integer
    Private _sortType As String

    Private m_EmpleadoCargo As EmpleadoCargo
    Private m_Empleado As Empleado
    Private m_TiempoServicio As ComisionEscala
    Private m_ComisionEscala As ComisionEscala
    Private m_EmpleadoPerfil As EmpleadoPerfil
    Private m_ComisionPeriodo As ComisionPeriodo
    Private m_ListaNombrePeriodo As ListaNombrePeriodo
    Private m_ComisionArchivo As Archivo

    Private m_RegistroPorPagina As Integer
    Private m_TotalRegistros As Integer

    Private m_ListaEmpleado As List(Of Empleado)
    Private m_ListaComisionArchivo As List(Of Archivo)
    Private m_ListaArchivo_ As ListaArchivo

    Private m_ListaTiempoServicio As List(Of ComisionEscala)
    Private m_ListaEmpleadoPerfil As List(Of EmpleadoPerfil)
    Private m_ListaComisionPeriodo As List(Of ComisionPeriodo)
    Private m_ListaComisionEscala As List(Of ComisionEscala)
    Private m_ListaEmpleadoCargo As List(Of EmpleadoCargo)
    Private m_ListaPlanVenta As ListaPlanVenta
    Private m_ComisionPeriodoDetalle As ComisionPeriodoDetalle
    Private m_ListaComisionPeriodoDetalle As ListaComisionPeriodoDetalle
    Private m_ListadoProcesoEstado As ListaProcesoEstado
    Private m_ProcesoEstado As ProcesoEstado

   


    Public FileAttached_ As FileAttached
    Private Id_maxRequestLengthDEV_ As Integer

    Public Property FileAttached() As FileAttached
        Get
            Return FileAttached_
        End Get
        Set(ByVal value As FileAttached)
            FileAttached_ = value
        End Set
    End Property

    Public Property ListarArchivo() As ListaArchivo
        Get
            Return m_ListaArchivo_
        End Get
        Set(ByVal value As ListaArchivo)
            m_ListaArchivo_ = value
        End Set
    End Property

    Public Property Id_maxRequestLengthDEV() As Integer
        Get
            Return Id_maxRequestLengthDEV_
        End Get
        Set(ByVal value As Integer)
            Id_maxRequestLengthDEV_ = value
        End Set
    End Property

    Public Property ComisionPeriodoDetalle() As ComisionPeriodoDetalle
        Get
            Return m_ComisionPeriodoDetalle
        End Get
        Set(ByVal value As ComisionPeriodoDetalle)
            m_ComisionPeriodoDetalle = value
        End Set
    End Property


    Public Property ListaComisionPeriodoDetalle() As ListaComisionPeriodoDetalle
        Get
            Return m_ListaComisionPeriodoDetalle
        End Get
        Set(ByVal value As ListaComisionPeriodoDetalle)
            m_ListaComisionPeriodoDetalle = value
        End Set
    End Property


    Public Property ListaPlanVenta() As ListaPlanVenta
        Get
            Return m_ListaPlanVenta
        End Get
        Set(ByVal value As ListaPlanVenta)
            m_ListaPlanVenta = value
        End Set
    End Property
    Private m_ListaCargo As ListaCargo
    Public Property ListaCargo() As ListaCargo
        Get
            Return m_ListaCargo
        End Get
        Set(ByVal value As ListaCargo)
            m_ListaCargo = value
        End Set
    End Property
    Private m_PlanVenta As PlanVenta

    Private m_sortDir As String
    Private m_page As Integer
    Private m_Total As Integer

    Private m_InsertarDatosPeriodoComision As String
    Private m_DescRegistrosPorPaginas As String

    Private m_Paginacion As Paginacion
    Public Property Paginacion() As Paginacion
        Get
            Return m_Paginacion
        End Get
        Set(ByVal value As Paginacion)
            m_Paginacion = value
        End Set
    End Property

    Public Property DescRegistrosPorPagina() As String
        Get
            Return m_DescRegistrosPorPaginas
        End Get
        Set(ByVal value As String)
            m_DescRegistrosPorPaginas = value
        End Set
    End Property

    Private m_ListaComisionEscalaDetalle As List(Of ComisionEscalaDetalle)
    Private m_ComisionEscalaDetalle As ComisionEscalaDetalle


    Public Property Total() As Integer
        Get
            Return m_Total
        End Get
        Set(ByVal value As Integer)
            m_Total = value
        End Set
    End Property

    Public Property page() As Integer
        Get
            Return m_page
        End Get
        Set(ByVal value As Integer)
            m_page = value
        End Set
    End Property

    Public Property sortDir() As String
        Get
            Return m_sortDir
        End Get
        Set(ByVal value As String)
            m_sortDir = value
        End Set
    End Property

    Public Property maximumRows() As Integer
        Get
            Return _maximumRows
        End Get
        Set(ByVal value As Integer)
            _maximumRows = value
        End Set
    End Property

    Public Property startRowIndex() As Integer
        Get
            Return _startRowIndex
        End Get
        Set(ByVal value As Integer)
            _startRowIndex = value
        End Set
    End Property

    Public Property sortType() As String
        Get
            Return _sortType
        End Get
        Set(ByVal value As String)
            _sortType = value
        End Set
    End Property

    Public Property InsertarDatosPeriodoComision() As String
        Get
            Return m_InsertarDatosPeriodoComision
        End Get
        Set(ByVal value As String)
            m_InsertarDatosPeriodoComision = value
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

    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(ByVal value As Empleado)
            m_Empleado = value
        End Set
    End Property

    Public Property ListaEmpleado() As List(Of Empleado)
        Get
            Return m_ListaEmpleado
        End Get
        Set(ByVal value As List(Of Empleado))
            m_ListaEmpleado = value
        End Set
    End Property

    Public Property ComisionArchivo() As Archivo
        Get
            Return m_ComisionArchivo
        End Get
        Set(ByVal value As Archivo)
            m_ComisionArchivo = value
        End Set
    End Property

    Public Property ListaComisionArchivo() As List(Of Archivo)
        Get
            Return m_ListaComisionArchivo
        End Get
        Set(ByVal value As List(Of Archivo))
            m_ListaComisionArchivo = value
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

    Public Property rowsPerPage() As Integer
        Get
            Return m_rowsPerPage
        End Get
        Set(ByVal value As Integer)
            m_rowsPerPage = value
        End Set
    End Property

    Public Property ListaNombrePeriodo() As ListaNombrePeriodo
        Get
            Return m_ListaNombrePeriodo
        End Get
        Set(ByVal value As ListaNombrePeriodo)
            m_ListaNombrePeriodo = value
        End Set
    End Property

    Public Property ListaComisionPeriodo() As List(Of ComisionPeriodo)
        Get
            Return m_ListaComisionPeriodo
        End Get
        Set(ByVal value As List(Of ComisionPeriodo))
            m_ListaComisionPeriodo = value
        End Set
    End Property

    Public Property ComisionPeriodo() As ComisionPeriodo
        Get
            Return m_ComisionPeriodo
        End Get
        Set(ByVal value As ComisionPeriodo)
            m_ComisionPeriodo = value
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

    Public Property TiempoServicio() As ComisionEscala
        Get
            Return m_TiempoServicio
        End Get
        Set(ByVal value As ComisionEscala)
            m_TiempoServicio = value
        End Set
    End Property

    Public Property ListaTiempoServicio() As List(Of ComisionEscala)
        Get
            Return m_ListaTiempoServicio
        End Get
        Set(ByVal value As List(Of ComisionEscala))
            m_ListaTiempoServicio = value
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

    Public Property ListaComisionEscala() As List(Of ComisionEscala)
        Get
            Return m_ListaComisionEscala
        End Get
        Set(ByVal value As List(Of ComisionEscala))
            m_ListaComisionEscala = value
        End Set
    End Property

    Public Property ComisionEscala() As ComisionEscala
        Get
            Return m_ComisionEscala
        End Get
        Set(ByVal value As ComisionEscala)
            m_ComisionEscala = value
        End Set
    End Property

    Public Property ListaComisionEscalaDetalle() As List(Of ComisionEscalaDetalle)
        Get
            Return m_ListaComisionEscalaDetalle
        End Get
        Set(ByVal value As List(Of ComisionEscalaDetalle))
            m_ListaComisionEscalaDetalle = value
        End Set
    End Property

    Public Property ComisionEscalaDetalle() As ComisionEscalaDetalle
        Get
            Return m_ComisionEscalaDetalle
        End Get
        Set(ByVal value As ComisionEscalaDetalle)
            m_ComisionEscalaDetalle = value
        End Set
    End Property

    Private m_Parametro As Parametro
    Public Property Parametro As Parametro
        Get
            Return m_Parametro
        End Get
        Set(ByVal value As Parametro)
            m_Parametro = value
        End Set
    End Property

    Private m_ModificaEscala As Boolean
    Public Property ModificaEscala As Boolean
        Get
            Return m_ModificaEscala
        End Get
        Set(ByVal value As Boolean)
            m_ModificaEscala = value
        End Set
    End Property

    Public Property PlanVenta() As PlanVenta
        Get
            Return m_PlanVenta
        End Get
        Set(ByVal value As PlanVenta)
            m_PlanVenta = value
        End Set
    End Property

 

    Public Property ProcesoEstado() As ProcesoEstado
        Get
            Return m_ProcesoEstado
        End Get
        Set(ByVal value As ProcesoEstado)
            m_ProcesoEstado = value
        End Set
    End Property

    Public Property ListadoProcesoEstado() As ListaProcesoEstado
        Get
            Return m_ListadoProcesoEstado
        End Get
        Set(ByVal value As ListaProcesoEstado)
            m_ListadoProcesoEstado = value
        End Set
    End Property

End Class
