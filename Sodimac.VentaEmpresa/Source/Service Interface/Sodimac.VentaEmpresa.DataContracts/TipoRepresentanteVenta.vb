Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="TipoRepresentanteVenta")> _
<MetadataType(GetType(Validation.TipoRepresentanteVentaMetaData))> _
Public Class TipoRepresentanteVenta

    Private m_IdTipoRepVen As Integer
    Private m_NombreTipoRepVen As String

    <WcfSerialization.DataMember(Name:="IdTipoRepVen", IsRequired:=False, Order:=0)> _
    Public Property IdTipoRepVen() As Integer
        Get
            Return m_IdTipoRepVen
        End Get
        Set(value As Integer)
            m_IdTipoRepVen = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreTipoRepVen", IsRequired:=False, Order:=1)> _
    Public Property NombreTipoRepVen() As String
        Get
            Return m_NombreTipoRepVen
        End Get
        Set(value As String)
            m_NombreTipoRepVen = value
        End Set
    End Property

End Class
