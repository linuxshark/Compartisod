Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls
'Imports Sodimac.PLE.Web.Mvc.Sodimac.PLE.Web.Mvc.ServicioComun
Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad
Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc.ServicioComun

Public Class AccountViewModel

    Public Property Usuario() As Usuario
        Get
            Return m_Usuario
        End Get
        Set(value As Usuario)
            m_Usuario = value
        End Set
    End Property
    Private m_Usuario As Usuario
    Public Property Rol() As Rol
        Get
            Return m_Rol
        End Get
        Set(value As Rol)
            m_Rol = value
        End Set
    End Property
    Private m_Rol As Rol
    Public Property Alerta() As [String]
        Get
            Return m_Alerta
        End Get
        Set(value As [String])
            m_Alerta = value
        End Set
    End Property
    Private m_Alerta As [String]

    Public Property ListaEstados() As ListaTablaGeneral
        Get
            Return m_ListaEstados
        End Get
        Set(value As ListaTablaGeneral)
            m_ListaEstados = value
        End Set
    End Property
    Private m_ListaEstados As ListaTablaGeneral

    Public Property arrayRoles() As [String]
        Get
            Return m_arrayRoles
        End Get
        Set(value As [String])
            m_arrayRoles = value
        End Set
    End Property
    Private m_arrayRoles As [String]

    Public Property Pagina() As Pagina
        Get
            Return m_Pagina
        End Get
        Set(value As Pagina)
            m_Pagina = value
        End Set
    End Property
    Private m_Pagina As Pagina
    Public Property ListaPaginas() As ListaPagina
        Get
            Return m_ListaPaginas
        End Get
        Set(value As ListaPagina)
            m_ListaPaginas = value
        End Set
    End Property
    Private m_ListaPaginas As ListaPagina

    Public Property ListaNodos() As List(Of TreeNode)
        Get
            Return m_ListaNodos
        End Get
        Set(value As List(Of TreeNode))
            m_ListaNodos = value
        End Set
    End Property
    Private m_ListaNodos As List(Of TreeNode)

    Public Property ListaUsuarios() As ListaUsuario
        Get
            Return m_ListaUsuarios
        End Get
        Set(value As ListaUsuario)
            m_ListaUsuarios = value
        End Set
    End Property
    Private m_ListaUsuarios As ListaUsuario
    Public Property ListaUsuarios2() As ListaUsuario
        Get
            Return m_ListaUsuarios2
        End Get
        Set(value As ListaUsuario)
            m_ListaUsuarios2 = value
        End Set
    End Property
    Private m_ListaUsuarios2 As ListaUsuario

    Public Property ListaRoles() As ListaRol
        Get
            Return m_ListaRoles
        End Get
        Set(value As ListaRol)
            m_ListaRoles = value
        End Set
    End Property
    Private m_ListaRoles As ListaRol

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


End Class