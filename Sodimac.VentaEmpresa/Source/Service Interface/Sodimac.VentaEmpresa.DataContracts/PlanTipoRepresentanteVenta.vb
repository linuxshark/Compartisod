Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Mantenimiento.PlanTipoRepresentanteVenta")>
<MetadataType(GetType(Validation.PlanTipoRepresentanteVentaMetaData))>
Public Class PlanTipoRepresentanteVenta

    <WcfSerialization.DataMember(Name:="IdPlanTipoRepVen", IsRequired:=False, Order:=0)>
    Private m_IdPlanTipoRepVen As Integer
    Public Property IdPlanTipoRepVen() As Integer
        Get
            Return m_IdPlanTipoRepVen
        End Get
        Set(ByVal value As Integer)
            m_IdPlanTipoRepVen = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TipoRepresentanteVenta", IsRequired:=False, Order:=1)>
    Private m_TipoRepresentanteVenta As TipoRepresentanteVenta
    Public Property TipoRepresentanteVenta() As TipoRepresentanteVenta
        Get
            Return m_TipoRepresentanteVenta
        End Get
        Set(ByVal value As TipoRepresentanteVenta)
            m_TipoRepresentanteVenta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="MesPlan", IsRequired:=False, Order:=2)>
    Private m_MesPlan As MesPlan
    Public Property MesPlan() As MesPlan
        Get
            Return m_MesPlan
        End Get
        Set(ByVal value As MesPlan)
            m_MesPlan = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Plan", IsRequired:=False, Order:=3)>
    Private m_Plan As Decimal
    Public Property Plan() As Decimal
        Get
            Return m_Plan
        End Get
        Set(ByVal value As Decimal)
            m_Plan = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ListaTipoRepresentanteVenta", IsRequired:=False, Order:=4)>
    Private m_ListaTipoRepresentanteVenta As ListaTipoRepresentanteVenta
    Public Property ListaTipoRepresentanteVenta() As ListaTipoRepresentanteVenta
        Get
            Return m_ListaTipoRepresentanteVenta
        End Get
        Set(ByVal value As ListaTipoRepresentanteVenta)
            m_ListaTipoRepresentanteVenta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ListaMesPlan", IsRequired:=False, Order:=5)>
    Private m_ListaMesPlan As ListaMesPlan
    Public Property ListaMesPlan() As ListaMesPlan
        Get
            Return m_ListaMesPlan
        End Get
        Set(ByVal value As ListaMesPlan)
            m_ListaMesPlan = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=6)>
    Private m_FechaRegistro As String
    Public Property FechaRegistro() As String
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As String)
            m_FechaRegistro = value
        End Set
    End Property

End Class
