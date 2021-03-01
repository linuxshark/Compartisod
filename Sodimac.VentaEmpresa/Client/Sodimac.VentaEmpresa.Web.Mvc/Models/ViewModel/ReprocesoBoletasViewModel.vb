Imports Sodimac.VentaEmpresa.DataContracts
Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Public Class ReprocesoBoletasViewModel

    Private m_Paginacion As Paginacion
    Private m_ListaPaginacion As List(Of Paginacion)


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

    Private _Anio As Integer

    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    Private _Mes As Integer

    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    Private _Dia As Integer

    Public Property Dia() As Integer
        Get
            Return _Dia
        End Get
        Set(ByVal value As Integer)
            _Dia = value
        End Set
    End Property
    Private _FechaVenta As Date

    Public Property FechaVenta() As Date
        Get
            Return _FechaVenta
        End Get
        Set(ByVal value As Date)
            _FechaVenta = value
        End Set
    End Property


    Private _FechaFin As String

    Public Property FechaFin() As String
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As String)
            _FechaFin = value
        End Set
    End Property

    Private _FechaInicio As String

    Public Property FechaInicio() As String
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As String)
            _FechaInicio = value
        End Set
    End Property

    Private _IdSucursal As Sucursal

    Public Property IdSucursal() As Sucursal
        Get
            Return _IdSucursal
        End Get
        Set(ByVal value As Sucursal)
            _IdSucursal = value
        End Set
    End Property

    Private _NumeroDocumento As String

    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(ByVal value As String)
            _NumeroDocumento = value
        End Set
    End Property

    Private _Dni As String

    Public Property Dni() As String
        Get
            Return _Dni
        End Get
        Set(ByVal value As String)
            _Dni = value
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

    Private _Sucursal As String
    Public Property Sucursal() As String
        Get
            Return _Sucursal
        End Get
        Set(ByVal value As String)
            _Sucursal = value
        End Set
    End Property

    Private _ListarBoletasReproceso As ProcesoCarga
    Public Property ListarBoletasReproceso() As ProcesoCarga
        Get
            Return _ListarBoletasReproceso
        End Get
        Set(ByVal value As ProcesoCarga)
            _ListarBoletasReproceso = value
        End Set
    End Property

    Private _estado As Integer
    Public Property estado() As Integer
        Get
            Return _estado
        End Get
        Set(ByVal value As Integer)
            _estado = value
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


End Class
