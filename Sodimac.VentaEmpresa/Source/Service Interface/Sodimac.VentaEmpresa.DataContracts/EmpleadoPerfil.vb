Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="EmpleadoPerfil")> _
<MetadataType(GetType(Validation.EmpleadoPerfilMetadata))> _
Public Class EmpleadoPerfil

    Private m_IdPerfil As Integer
    Private m_DescripcionPerfil As String
    Private m_FechaDesde As DateTime
    Private m_FechaHasta As DateTime
    Private m_Activo As Boolean

    <WcfSerialization.DataMember(Name:="IdPerfil", IsRequired:=False, Order:=0)> _
    Public Property IdPerfil() As Integer
        Get
            Return m_IdPerfil
        End Get
        Set(ByVal value As Integer)
            m_IdPerfil = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=1)> _
    Public Property DescripcionPerfil() As String
        Get
            Return m_DescripcionPerfil
        End Get
        Set(ByVal value As String)
            m_DescripcionPerfil = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=2)> _
    Public Property FechaDesde() As DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(ByVal value As DateTime)
            m_FechaDesde = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=3)> _
    Public Property FechaHasta() As DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(ByVal value As DateTime)
            m_FechaHasta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=4)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property

    Property Descripcion As String

End Class
