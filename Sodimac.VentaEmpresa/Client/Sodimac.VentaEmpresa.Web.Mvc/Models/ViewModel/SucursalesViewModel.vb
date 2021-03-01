Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Sodimac.VentaEmpresa.DataContracts
'Imports Sodimac.PLE.Web.Mvc.Sodimac.PLE.Web.Mvc.ServicioVentas


Public Class SucursalesViewModel


    Private m_Empleado As Empleado
    Private m_ListaVentaEmpleado As List(Of Empleado)
    Private m_ClienteSector As ClienteSector
    Private m_ListaClienteSector As List(Of ClienteSector)
    Private m_Sucursal As Sucursal
    Private m_ListaSucursal As List(Of Sucursal)
    Private m_ClienteVenta As ClienteVenta

    Private m_Paginacion As Paginacion
    Private m_ListaPaginacion As List(Of Paginacion)

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

    Property ClienteVenta() As ClienteVenta
        Get
            Return m_ClienteVenta
        End Get
        Set(ByVal value As ClienteVenta)
            m_ClienteVenta = value
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
    Private m_RegistroPorPagina As Integer


    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(ByVal value As Empleado)
            m_Empleado = value
        End Set
    End Property
End Class
