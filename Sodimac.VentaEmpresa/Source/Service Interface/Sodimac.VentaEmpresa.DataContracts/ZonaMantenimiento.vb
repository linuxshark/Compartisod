Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ZonaMantenimiento")> _
<MetadataType(GetType(Validation.ZonaMetadata))> _
Public Class ZonaMantenimiento
    Private m_idZona As Integer
    Private m_nombreZona As String
    Private m_activoZona As Boolean
    Private m_isNacional As Boolean

    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=0)> _
    Public Property IdZona() As Integer
        Get
            Return m_idZona
        End Get
        Set(value As Integer)
            m_idZona = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="NombreZona", IsRequired:=False, Order:=1)> _
    Public Property NombreZona() As String
        Get
            Return m_nombreZona
        End Get
        Set(value As String)
            m_nombreZona = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="ActivoZona", IsRequired:=False, Order:=2)> _
    Public Property ActivoZona() As Boolean
        Get
            Return m_activoZona
        End Get
        Set(value As Boolean)
            m_activoZona = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IsNacional", IsRequired:=False, Order:=3)> _
    Public Property IsNacional() As Boolean
        Get
            Return m_isNacional
        End Get
        Set(value As Boolean)
            m_isNacional = value
        End Set
    End Property

End Class
