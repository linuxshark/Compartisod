Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Proveedor")>
<MetadataType(GetType(Validation.ProveedorMetaData))>
Public Class Proveedor
    Private _IdProveedor As Integer
    Private _Ruc As String
    Private _RazonSocial As String
    Private _Numero As String
    Private _Direccion As String
    Private _IdEmpresa As Integer
    Private _Estado As Boolean
    Private _EmpresaDescripcion As String
    Private _Sku As String

    Public Property IdProveedor() As Integer
        Get
            Return _IdProveedor
        End Get
        Set(ByVal value As Integer)
            _IdProveedor = value
        End Set
    End Property


    Private _EstadoP As String
    Public Property EstadoP() As String
        Get
            Return _EstadoP
        End Get
        Set(ByVal value As String)
            _EstadoP = value
        End Set
    End Property


    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _Direccion
        End Get
        Set(ByVal value As String)
            _Direccion = value
        End Set
    End Property

    Public Property IdEmpresa() As Integer
        Get
            Return _IdEmpresa
        End Get
        Set(ByVal value As Integer)
            _IdEmpresa = value
        End Set
    End Property

    Public Property Estado() As Boolean
        Get
            Return _Estado
        End Get
        Set(ByVal value As Boolean)
            _Estado = value
        End Set
    End Property

    Public Property EmpresaDescripcion() As String
        Get
            Return _EmpresaDescripcion
        End Get
        Set(ByVal value As String)
            _EmpresaDescripcion = value
        End Set
    End Property

    Public Property Sku() As String
        Get
            Return _Sku
        End Get
        Set(ByVal value As String)
            _Sku = value
        End Set
    End Property

End Class
