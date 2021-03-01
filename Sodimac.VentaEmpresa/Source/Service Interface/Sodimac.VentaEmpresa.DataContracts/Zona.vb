Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Zona")> _
<MetadataType(GetType(Validation.ZonaMetadata))> _
Partial Public Class Zona

    Private m_REGION As String
    Private m_DESCREGION As String
    Private m_DescZona As String

    Private m_IdZona As String
    Private m_Descripcion As String
    Private m_DescripcionCorta As String
    Private m_FechaDesde As DateTime
    Private m_FechaHasta As DateTime
    Private m_Activo As Boolean
    Private m_nombreZona As String


    <WcfSerialization.DataMember(Name:="DescZona", IsRequired:=False, Order:=0)> _
    Public Property DescZona() As String
        Get
            Return m_DescZona
        End Get
        Set(value As String)
            m_DescZona = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DESCREGION", IsRequired:=False, Order:=1)> _
    Public Property DESCREGION() As String
        Get
            Return m_REGION
        End Get
        Set(value As String)
            m_REGION = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="REGION", IsRequired:=False, Order:=2)> _
    Public Property REGION() As String
        Get
            Return m_REGION
        End Get
        Set(value As String)
            m_REGION = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=3)> _
    Public Property IdZona() As Integer
        Get
            Return m_IdZona
        End Get
        Set(value As Integer)
            m_IdZona = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreZona", IsRequired:=False, Order:=8)> _
    Public Property NombreZona() As String
        Get
            Return m_nombreZona
        End Get
        Set(value As String)
            m_nombreZona = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=4)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=5)> _
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(value As String)
            m_DescripcionCorta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=6)> _
    Public Property FechaDesde() As DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(value As DateTime)
            m_FechaDesde = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=7)> _
    Public Property FechaHasta() As DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(value As DateTime)
            m_FechaHasta = value
        End Set
    End Property

End Class

