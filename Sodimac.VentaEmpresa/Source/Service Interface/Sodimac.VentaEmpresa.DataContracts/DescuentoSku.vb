Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="DescuentoSku")>
Public Class DescuentoSku
    Private _mMargenDscto As Decimal
    Private _mDescuento As Decimal

    <WcfSerialization.DataMember(Name:="IdDescuentoSku", IsRequired:=False, Order:=0)>
    Public Property IdDescuentoSku As Integer

    <WcfSerialization.DataMember(Name:="CodigoSku", IsRequired:=True, Order:=1)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoSku), ErrorMessageResourceName:="CodigoSkuRequired")>
    Public Property CodigoSku As String

    <WcfSerialization.DataMember(Name:="NombreSku", IsRequired:=False, Order:=2)>
    Public Property NombreSku As String

    <WcfSerialization.DataMember(Name:="CantidadDesde", IsRequired:=True, Order:=3)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoSku), ErrorMessageResourceName:="CantidadDesdeRequired"), Range(0, 100000000000000, ErrorMessageResourceType:=GetType(RecursoDescuentoSku), ErrorMessageResourceName:="CantidadDesdeRange")>
    Public Property CantidadDesde As Decimal

    <WcfSerialization.DataMember(Name:="CantidadHasta", IsRequired:=True, Order:=4)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoSku), ErrorMessageResourceName:="CantidadHastaRequired"), Range(0, 100000000000000, ErrorMessageResourceType:=GetType(RecursoDescuentoSku), ErrorMessageResourceName:="CantidadHastaRange")>
    Public Property CantidadHasta As Decimal

    <WcfSerialization.DataMember(Name:="MargenDscto", IsRequired:=True, Order:=5)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoSku), ErrorMessageResourceName:="MargenDsctoRequired")>
    Public Property MargenDscto As Decimal
        Get
            Return _mMargenDscto
        End Get
        Set(value As Decimal)
            _mMargenDscto = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descuento", IsRequired:=True, Order:=6)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoSku), ErrorMessageResourceName:="DescuentoRequired")>
    Public Property Descuento As Decimal
        Get
            Return _mDescuento
        End Get
        Set(value As Decimal)
            _mDescuento = value
        End Set
    End Property

    Public ReadOnly Property MargenDsctoDsc As String
        Get
            Return _mMargenDscto & " %"
        End Get
    End Property

    Public ReadOnly Property DescuentoDsc As String
        Get
            Return _mDescuento & " %"
        End Get
    End Property
End Class
