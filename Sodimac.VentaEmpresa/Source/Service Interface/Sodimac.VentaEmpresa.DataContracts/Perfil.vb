Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Perfil")> _
<MetadataType(GetType(Validation.PerfilMetadata))> _
Public Class Perfil

    Private m_descripcionEmplePer As EmpleadoPerfil


    Private m_idPerfil As Integer
    Private m_nombrePerfil As String
    Private m_idPerfilSuperior As Integer
    Private m_activoPerfil As Boolean
    Private m_nombrePerfilSuperior As String
    Private m_tipoPerfil As Integer
    Private m_nombrePerfilMenor As String

    <WcfSerialization.DataMember(Name:="IdPerfil", IsRequired:=False, Order:=0)> _
    Public Property IdPerfil() As Integer
        Get
            Return m_idPerfil
        End Get
        Set(value As Integer)
            m_idPerfil = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombrePerfil", IsRequired:=False, Order:=1)> _
    Public Property NombrePerfil() As String
        Get
            Return m_nombrePerfil
        End Get
        Set(value As String)
            m_nombrePerfil = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdPerfilSuperior", IsRequired:=False, Order:=2)> _
    Public Property IdPerfilSuperior() As Nullable(Of Integer)
        Get
            Return m_idPerfilSuperior
        End Get
        Set(value As Nullable(Of Integer))
            m_idPerfilSuperior = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ActivoPerfil", IsRequired:=False, Order:=3)> _
    Public Property ActivoPerfil() As Boolean
        Get
            Return m_activoPerfil
        End Get
        Set(value As Boolean)
            m_activoPerfil = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombrePerfilSuperior", IsRequired:=False, Order:=4)> _
    Public Property NombrePerfilSuperior() As String
        Get
            Return m_nombrePerfilSuperior
        End Get
        Set(value As String)
            m_nombrePerfilSuperior = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="TipoPerfil", IsRequired:=False, Order:=5)> _
    Public Property TipoPerfil() As Integer
        Get
            Return m_tipoPerfil
        End Get
        Set(value As Integer)
            m_tipoPerfil = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="EmpleadoPerfil", IsRequired:=False, Order:=6)> _
    Public Property EmpleadoPerfil() As EmpleadoPerfil
        Get
            Return m_descripcionEmplePer
        End Get
        Set(value As EmpleadoPerfil)
            m_descripcionEmplePer = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="NombrePerfilInferior", IsRequired:=False, Order:=8)> _
    Public Property NombrePerfilInferior() As String
        Get
            Return m_nombrePerfilMenor
        End Get
        Set(value As String)
            m_nombrePerfilMenor = value
        End Set
    End Property


End Class
