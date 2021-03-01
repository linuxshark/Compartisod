Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class ProveedorMetaData
    Private _IdProveedor As Integer
    Private _Ruc As String
    Private _RazonSocial As String
    Private _Numero As String
    Private _Direccion As String
    Private _IdEmpresa As Integer
    Private _Estado As Boolean
    Private _Sku As String


    <Display(Name:="Código Proveedor :")>
    Public Property IdProveedor() As Integer
        Get
            Return _IdProveedor
        End Get
        Set(ByVal value As Integer)
            _IdProveedor = value
        End Set
    End Property
    <Display(Name:="Ruc :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    <StringLength(11, MinimumLength:=8, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))>
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property
    <Display(Name:="Razon Social :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property
    <Display(Name:="Número :")>
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property
    <Display(Name:="Dirección :")>
    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property
    <Display(Name:="Empresa :")>
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    Public Property IdEmpresa() As Integer
        Get
            Return _IdEmpresa
        End Get
        Set(ByVal value As Integer)
            _IdEmpresa = value
        End Set
    End Property
    <Display(Name:="Estado :")>
    Public Property Estado() As Boolean
        Get
            Return _Estado
        End Get
        Set(ByVal value As Boolean)
            _Estado = value
        End Set
    End Property

    <Display(Name:="Sku :")>
    Public Property Sku() As String
        Get
            Return _Sku
        End Get
        Set(ByVal value As String)
            _Sku = value
        End Set
    End Property

End Class
