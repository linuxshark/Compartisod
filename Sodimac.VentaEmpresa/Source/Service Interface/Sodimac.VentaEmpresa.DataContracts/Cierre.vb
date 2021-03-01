Imports System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")>
<MetadataType(GetType(Validation.CierreMetaData))>
Public Class Cierre
    Private m_IdCierre As Integer
    Private m_Anio As Integer
    Private m_Mes As Integer
    Private m_Fecha As String
    Private m_Estado As String
    Private m_UsuarioRegistro As String
    Private m_UsuarioUpdate As String
    Private m_NombreMes As String
    Private m_cont As Integer
    Private m_Msg As String

    Public Property IdCierre() As Integer
        Get
            Return m_IdCierre
        End Get
        Set(value As Integer)
            m_IdCierre = value
        End Set
    End Property

    Public Property Año() As Integer
        Get
            Return m_Anio
        End Get
        Set(value As Integer)
            m_Anio = value
        End Set
    End Property

    Public Property Mes() As Integer
        Get
            Return m_Mes
        End Get
        Set(value As Integer)
            m_Mes = value
        End Set
    End Property

    Public Property FechaCierre() As String
        Get
            Return m_Fecha
        End Get
        Set(value As String)
            m_Fecha = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return m_Estado
        End Get
        Set(value As String)
            m_Estado = value
        End Set
    End Property

    Public Property UsuarioRegistro() As String
        Get
            Return m_UsuarioRegistro
        End Get
        Set(value As String)
            m_UsuarioRegistro = value
        End Set
    End Property

    Public Property UsuarioUpdate() As String
        Get
            Return m_UsuarioUpdate
        End Get
        Set(value As String)
            m_UsuarioUpdate = value
        End Set
    End Property

    Public Property NombreMes() As String
        Get
            Return m_NombreMes
        End Get
        Set(value As String)
            m_NombreMes = value
        End Set
    End Property

    Public Property Cont() As Integer
        Get
            Return m_cont
        End Get
        Set(value As Integer)
            m_cont = value
        End Set
    End Property

    Public Property Msg() As String
        Get
            Return m_IdCierre
        End Get
        Set(value As String)
            m_Msg = value
        End Set
    End Property
End Class
