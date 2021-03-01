Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="DescuentoFamilia")>
Public Class DescuentoFamilia
    Private _mMargenDscto As Decimal
    Private _mDescuento As Decimal

    <WcfSerialization.DataMember(Name:="CodigoFamilia", IsRequired:=True, Order:=0)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoFamilia), ErrorMessageResourceName:="CodigoFamiliaRequired")>
    Public Property CodigoFamilia As String

    <WcfSerialization.DataMember(Name:="NombreFamilia", IsRequired:=False, Order:=1)>
    Public Property NombreFamilia As String

    <WcfSerialization.DataMember(Name:="MargenDscto", IsRequired:=True, Order:=2)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoFamilia), ErrorMessageResourceName:="MargenDsctoRequired")>
    Public Property MargenDscto As Decimal
        Get
            Return _mMargenDscto
        End Get
        Set(value As Decimal)
            _mMargenDscto = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descuento", IsRequired:=True, Order:=3)>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceType:=GetType(RecursoDescuentoFamilia), ErrorMessageResourceName:="DescuentoRequired")>
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
