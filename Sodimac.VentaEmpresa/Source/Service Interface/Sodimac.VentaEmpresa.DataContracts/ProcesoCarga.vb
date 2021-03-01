Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ProcesoCarga")> _
Public Class ProcesoCarga

    <WcfSerialization.DataMember(Name:="IdDocumento", IsRequired:=False, Order:=0)> _
    Public Property IdDocumento() As String
        Get
            Return _IdDocumento
        End Get
        Set(value As String)
            _IdDocumento = value
        End Set
    End Property
    Protected _IdDocumento As String

    <WcfSerialization.DataMember(Name:="IdSucursal", IsRequired:=False, Order:=1)> _
    Public Property IdSucursal() As Int32
        Get
            Return _IdSucursal
        End Get
        Set(value As Int32)
            _IdSucursal = value
        End Set
    End Property
    Protected _IdSucursal As Int32

    <WcfSerialization.DataMember(Name:="NumeroDocumento", IsRequired:=False, Order:=2)> _
    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Set(value As String)
            _NumeroDocumento = value
        End Set
    End Property
    Protected _NumeroDocumento As String

    <WcfSerialization.DataMember(Name:="Fecha", IsRequired:=False, Order:=3)> _
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property
    Protected _Fecha As Date

    <WcfSerialization.DataMember(Name:="Ruc", IsRequired:=False, Order:=4)> _
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(value As String)
            _Ruc = value
        End Set
    End Property
    Protected _Ruc As String

    <WcfSerialization.DataMember(Name:="Sku", IsRequired:=False, Order:=5)> _
    Public Property Sku() As String
        Get
            Return _Sku
        End Get
        Set(value As String)
            _Sku = value
        End Set
    End Property
    Protected _Sku As String

    <WcfSerialization.DataMember(Name:="Cantidad", IsRequired:=False, Order:=6)> _
    Public Property Cantidad() As Int32
        Get
            Return _Cantidad
        End Get
        Set(value As Int32)
            _Cantidad = value
        End Set
    End Property
    Protected _Cantidad As Int32

    <WcfSerialization.DataMember(Name:="ValorVenta", IsRequired:=False, Order:=7)> _
    Public Property ValorVenta() As Decimal
        Get
            Return _ValorVenta
        End Get
        Set(value As Decimal)
            _ValorVenta = value
        End Set
    End Property
    Protected _ValorVenta As Decimal

    <WcfSerialization.DataMember(Name:="Igv", IsRequired:=False, Order:=8)> _
    Public Property Igv() As Decimal
        Get
            Return _Igv
        End Get
        Set(value As Decimal)
            _Igv = value
        End Set
    End Property
    Protected _Igv As Decimal

    <WcfSerialization.DataMember(Name:="Total", IsRequired:=False, Order:=9)> _
    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(value As Decimal)
            _Total = value
        End Set
    End Property
    Protected _Total As Decimal

    <WcfSerialization.DataMember(Name:="Moneda", IsRequired:=False, Order:=10)> _
    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(value As String)
            _Moneda = value
        End Set
    End Property
    Protected _Moneda As String

    <WcfSerialization.DataMember(Name:="Tc", IsRequired:=False, Order:=11)> _
    Public Property Tc() As Decimal
        Get
            Return _Tc
        End Get
        Set(value As Decimal)
            _Tc = value
        End Set
    End Property
    Protected _Tc As Decimal

    <WcfSerialization.DataMember(Name:="DocumentoAfecto", IsRequired:=False, Order:=12)> _
    Public Property DocumentoAfecto() As String
        Get
            Return _DocumentoAfecto
        End Get
        Set(value As String)
            _DocumentoAfecto = value
        End Set
    End Property
    Protected _DocumentoAfecto As String

    <WcfSerialization.DataMember(Name:="Comentario", IsRequired:=False, Order:=13)> _
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(value As String)
            _Comentario = value
        End Set
    End Property
    Protected _Comentario As String

    <WcfSerialization.DataMember(Name:="IDCarga", IsRequired:=False, Order:=14)> _
    Public Property IDCarga() As Integer
        Get
            Return _IDCarga
        End Get
        Set(value As Integer)
            _IDCarga = value
        End Set
    End Property
    Protected _IDCarga As Integer

    <WcfSerialization.DataMember(Name:="DescError", IsRequired:=False, Order:=15)> _
    Public Property DescError() As String
        Get
            Return _DescError
        End Get
        Set(value As String)
            _DescError = value
        End Set
    End Property
    Protected _DescError As String

    <WcfSerialization.DataMember(Name:="Flag", IsRequired:=False, order:=16)> _
    Public Property Flag() As Boolean
        Get
            Return _Flag
        End Get
        Set(value As Boolean)
            _Flag = value
        End Set
    End Property
    Protected _Flag As Boolean

    <WcfSerialization.DataMember(Name:="UserReg", IsRequired:=False, Order:=17)> _
    Public Property UserReg() As String
        Get
            Return _UserReg
        End Get
        Set(value As String)
            _UserReg = value
        End Set
    End Property
    Protected _UserReg As String

    <WcfSerialization.DataMember(Name:="TipoDocumento", IsRequired:=False, Order:=18)> _
    Public Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get
        Set(value As String)
            _TipoDocumento = value
        End Set
    End Property
    Protected _TipoDocumento As String

    <WcfSerialization.DataMember(Name:="TipoCarga", IsRequired:=False, Order:=19)> _
    Public Property TipoCarga() As Integer
        Get
            Return _TipoCarga
        End Get
        Set(value As Integer)
            _TipoCarga = value
        End Set
    End Property
    Protected _TipoCarga As Integer

    <WcfSerialization.DataMember(Name:="CajaCargaManual", IsRequired:=False, Order:=20)> _
    Public Property CajaCargaManual() As Integer
        Get
            Return _CajaCargaManual
        End Get
        Set(ByVal value As Integer)
            _CajaCargaManual = value
        End Set
    End Property
    Protected _CajaCargaManual As Integer

    <WcfSerialization.DataMember(Name:="TotalDocumentos", IsRequired:=False, Order:=21)> _
    Public Property TotalDocumentos() As String
        Get
            Return _TotalDocumentos
        End Get
        Set(ByVal value As String)
            _TotalDocumentos = value
        End Set
    End Property
    Protected _TotalDocumentos As String

    <WcfSerialization.DataMember(Name:="ValorDocumento", IsRequired:=False, Order:=22)> _
    Public Property ValorDocumento() As String
        Get
            Return _ValorDocumento
        End Get
        Set(ByVal value As String)
            _ValorDocumento = value
        End Set
    End Property
    Protected _ValorDocumento As String

    <WcfSerialization.DataMember(Name:="Id_Estado", IsRequired:=False, Order:=23)> _
    Public Property Id_Estado() As Integer
        Get
            Return _Id_Estado
        End Get
        Set(ByVal value As Integer)
            _Id_Estado = value
        End Set
    End Property
    Protected _Id_Estado As Integer

    <WcfSerialization.DataMember(Name:="IdMoneda", IsRequired:=False, Order:=24)> _
    Public Property IdMoneda() As Integer
        Get
            Return _IdMoneda
        End Get
        Set(ByVal value As Integer)
            _IdMoneda = value
        End Set
    End Property
    Protected _IdMoneda As Integer

    <WcfSerialization.DataMember(Name:="IdTipoDocumento", IsRequired:=False, Order:=25)> _
    Public Property IdTipoDocumento() As Integer
        Get
            Return _IdTipoDocumento
        End Get
        Set(value As Integer)
            _IdTipoDocumento = value
        End Set
    End Property
    Protected _IdTipoDocumento As Integer

    <WcfSerialization.DataMember(Name:="IdProducto", IsRequired:=False, Order:=26)> _
    Public Property IdProducto() As Integer
        Get
            Return _IdProducto
        End Get
        Set(value As Integer)
            _IdProducto = value
        End Set
    End Property
    Protected _IdProducto As Integer

    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=27)> _
    Public Property IdCliente() As Integer
        Get
            Return _IdCliente
        End Get
        Set(value As Integer)
            _IdCliente = value
        End Set
    End Property
    Protected _IdCliente As Integer

    <WcfSerialization.DataMember(Name:="DescripcionSku", IsRequired:=False, Order:=28)> _
    Public Property DescripcionSku() As String
        Get
            Return _DescripcionSku
        End Get
        Set(value As String)
            _DescripcionSku = value
        End Set
    End Property
    Protected _DescripcionSku As String

    <WcfSerialization.DataMember(Name:="RazonSocial", IsRequired:=False, Order:=29)> _
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(value As String)
            _RazonSocial = value
        End Set
    End Property
    Protected _RazonSocial As String

    <WcfSerialization.DataMember(Name:="TipoCaja", IsRequired:=False, Order:=30)> _
    Public Property TipoCaja() As String
        Get
            Return _TipoCaja
        End Get
        Set(value As String)
            _TipoCaja = value
        End Set
    End Property
    Protected _TipoCaja As String

    <WcfSerialization.DataMember(Name:="ClaCom", IsRequired:=False, Order:=31)> _
    Public Property ClaCom() As String
        Get
            Return _ClaCom
        End Get
        Set(value As String)
            _ClaCom = value
        End Set
    End Property
    Protected _ClaCom As String

    <WcfSerialization.DataMember(Name:="DescripcionClaCom", IsRequired:=False, Order:=32)> _
    Public Property DescripcionClaCom() As String
        Get
            Return _DescripcionClaCom
        End Get
        Set(value As String)
            _DescripcionClaCom = value
        End Set
    End Property
    Protected _DescripcionClaCom As String

    <WcfSerialization.DataMember(Name:="CodDepAnt", IsRequired:=False, Order:=33)> _
    Public Property CodDepAnt() As String
        Get
            Return _CodDepAnt
        End Get
        Set(value As String)
            _CodDepAnt = value
        End Set
    End Property
    Protected _CodDepAnt As String

    <WcfSerialization.DataMember(Name:="NomDepAnt", IsRequired:=False, Order:=34)> _
    Public Property NomDepAnt() As String
        Get
            Return _NomDepAnt
        End Get
        Set(value As String)
            _NomDepAnt = value
        End Set
    End Property
    Protected _NomDepAnt As String


    <WcfSerialization.DataMember(Name:="CodFamAnt", IsRequired:=False, Order:=35)> _
    Public Property CodFamAnt() As String
        Get
            Return _CodFamAnt
        End Get
        Set(value As String)
            _CodFamAnt = value
        End Set
    End Property
    Protected _CodFamAnt As String

    <WcfSerialization.DataMember(Name:="NomFamAnt", IsRequired:=False, Order:=36)> _
    Public Property NomFamAnt() As String
        Get
            Return _NomFamAnt
        End Get
        Set(value As String)
            _NomFamAnt = value
        End Set
    End Property
    Protected _NomFamAnt As String

    <WcfSerialization.DataMember(Name:="CostoUnitario", IsRequired:=False, Order:=37)> _
    Public Property CostoUnitario() As Decimal
        Get
            Return _CostoUnitario
        End Get
        Set(value As Decimal)
            _CostoUnitario = value
        End Set
    End Property
    Protected _CostoUnitario As Decimal

    <WcfSerialization.DataMember(Name:="PrecioIGV", IsRequired:=False, Order:=38)> _
    Public Property PrecioIGV() As Decimal
        Get
            Return _PrecioIGV
        End Get
        Set(value As Decimal)
            _PrecioIGV = value
        End Set
    End Property
    Protected _PrecioIGV As Decimal

    <WcfSerialization.DataMember(Name:="VVPrecioNeto", IsRequired:=False, Order:=39)> _
    Public Property VVPrecioNeto() As Decimal
        Get
            Return _VVPrecioNeto
        End Get
        Set(value As Decimal)
            _VVPrecioNeto = value
        End Set
    End Property
    Protected _VVPrecioNeto As Decimal

    <WcfSerialization.DataMember(Name:="Margen", IsRequired:=False, Order:=40)> _
    Public Property Margen() As Decimal
        Get
            Return _Margen
        End Get
        Set(value As Decimal)
            _Margen = value
        End Set
    End Property
    Protected _Margen As Decimal

    <WcfSerialization.DataMember(Name:="Contribucion", IsRequired:=False, Order:=41)> _
    Public Property Contribucion() As Decimal
        Get
            Return _Contribucion
        End Get
        Set(value As Decimal)
            _Contribucion = value
        End Set
    End Property
    Protected _Contribucion As Decimal

    <WcfSerialization.DataMember(Name:="NombreSucursal", IsRequired:=False, Order:=42)> _
    Public Property NombreSucursal() As String
        Get
            Return _NombreSucursal
        End Get
        Set(value As String)
            _NombreSucursal = value
        End Set
    End Property
    Protected _NombreSucursal As String

    <WcfSerialization.DataMember(Name:="ContadorSKU", IsRequired:=False, Order:=43)> _
    Public Property ContadorSKU() As Integer
        Get
            Return _ContadorSKU
        End Get
        Set(value As Integer)
            _ContadorSKU = value
        End Set
    End Property
    Protected _ContadorSKU As Integer

    <WcfSerialization.DataMember(Name:="HUA", IsRequired:=False, Order:=44)> _
    Public Property HUA() As String
        Get
            Return _HUA
        End Get
        Set(value As String)
            _HUA = value
        End Set
    End Property
    Protected _HUA As String

    <WcfSerialization.DataMember(Name:="HUA", IsRequired:=False, Order:=45)> _
    Public Property Valor() As Decimal
        Get
            Return _Valor
        End Get
        Set(value As Decimal)
            _Valor = value
        End Set
    End Property
    Protected _Valor As Decimal

    <WcfSerialization.DataMember(Name:="FormaPago", IsRequired:=False, Order:=46)> _
    Public Property FormaPago() As String
        Get
            Return _FormaPago
        End Get
        Set(value As String)
            _FormaPago = value
        End Set
    End Property
    Protected _FormaPago As String

    <WcfSerialization.DataMember(Name:="Hora", IsRequired:=False, Order:=47)> _
    Public Property Hora() As Integer
        Get
            Return _Hora
        End Get
        Set(value As Integer)
            _Hora = value
        End Set
    End Property
    Protected _Hora As Integer

    <WcfSerialization.DataMember(Name:="Minuto", IsRequired:=False, Order:=48)> _
    Public Property Minuto() As Integer
        Get
            Return _Minuto
        End Get
        Set(value As Integer)
            _Minuto = value
        End Set
    End Property
    Protected _Minuto As Integer

    <WcfSerialization.DataMember(Name:="NombreCliente", IsRequired:=False, Order:=49)> _
    Public Property NombreCliente() As String
        Get
            Return _NombreCliente
        End Get
        Set(value As String)
            _NombreCliente = value
        End Set
    End Property
    Protected _NombreCliente As String

    <WcfSerialization.DataMember(Name:="NumeroTarjeta", IsRequired:=False, Order:=50)> _
    Public Property NumeroTarjeta() As String
        Get
            Return _NumeroTarjeta
        End Get
        Set(value As String)
            _NumeroTarjeta = value
        End Set
    End Property
    Protected _NumeroTarjeta As String

    <WcfSerialization.DataMember(Name:="CajeMeson", IsRequired:=False, Order:=51)> _
    Public Property CajeMeson() As Decimal
        Get
            Return _CajeMeson
        End Get
        Set(value As Decimal)
            _CajeMeson = value
        End Set
    End Property
    Protected _CajeMeson As Decimal

    <WcfSerialization.DataMember(Name:="Redondeo", IsRequired:=False, Order:=52)> _
    Public Property Redondeo() As Decimal
        Get
            Return _Redondeo
        End Get
        Set(value As Decimal)
            _Redondeo = value
        End Set
    End Property
    Protected _Redondeo As Decimal

    <WcfSerialization.DataMember(Name:="IdTipoCarga", IsRequired:=False, Order:=53)> _
    Public Property IdTipoCarga() As Integer
        Get
            Return _IdTipoCarga
        End Get
        Set(value As Integer)
            _IdTipoCarga = value
        End Set
    End Property
    Protected _IdTipoCarga As Integer

    <WcfSerialization.DataMember(Name:="VVIGV", IsRequired:=False, Order:=52)> _
    Public Property VVIGV() As Decimal
        Get
            Return _VVIGV
        End Get
        Set(value As Decimal)
            _VVIGV = value
        End Set
    End Property
    Protected _VVIGV As Decimal

    <WcfSerialization.DataMember(Name:="VDIGV", IsRequired:=False, Order:=53)> _
    Public Property VDIGV() As Decimal
        Get
            Return _VDIGV
        End Get
        Set(value As Decimal)
            _VDIGV = value
        End Set
    End Property
    Protected _VDIGV As Decimal

    <WcfSerialization.DataMember(Name:="VVTotal", IsRequired:=False, Order:=54)> _
    Public Property VVTotal() As Decimal
        Get
            Return _VVTotal
        End Get
        Set(value As Decimal)
            _VVTotal = value
        End Set
    End Property

    Protected _VVTotal As Decimal



    <WcfSerialization.DataMember(Name:="CostoTotal", IsRequired:=False, Order:=55)> _
    Private _CostoTotal As Decimal
    Public Property CostoTotal() As Decimal
        Get
            Return _CostoTotal
        End Get
        Set(ByVal value As Decimal)
            _CostoTotal = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="PercepcionPorcentaje", IsRequired:=False, Order:=56)> _
    Private _PercepcionPorcentaje As Decimal
    Public Property PercepcionPorcentaje() As Decimal
        Get
            Return _PercepcionPorcentaje
        End Get
        Set(ByVal value As Decimal)
            _PercepcionPorcentaje = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="MontoPercepcion", IsRequired:=False, Order:=57)> _
    Private _MontoPercepcion As Decimal
    Public Property MontoPercepcion() As Decimal
        Get
            Return _MontoPercepcion
        End Get
        Set(ByVal value As Decimal)
            _MontoPercepcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TotalVtaIgvPercepcion", IsRequired:=False, Order:=58)> _
    Private _TotalVtaIgvPercepcion As Decimal
    Public Property TotalVtaIgvPercepcion() As Decimal
        Get
            Return _TotalVtaIgvPercepcion
        End Get
        Set(ByVal value As Decimal)
            _TotalVtaIgvPercepcion = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="IdSucursalReal", IsRequired:=False, Order:=59)> _
    Private _IdSucursalReal As Int32
    Public Property IdSucursalReal() As Int32
        Get
            Return _IdSucursalReal
        End Get
        Set(ByVal value As Int32)
            _IdSucursalReal = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescErrorVal", IsRequired:=False, Order:=60)> _
    Public Property DescErrorVal() As String
        Get
            Return _DescErrorVal
        End Get
        Set(value As String)
            _DescErrorVal = value
        End Set
    End Property
    Protected _DescErrorVal As String

    Private Empleado As Empleado
    Public Property NewProperty() As Empleado
        Get
            Return Empleado
        End Get
        Set(ByVal value As Empleado)
            Empleado = value
        End Set
    End Property

    Private _fechaFin As String
    Public Property fechaFin() As String
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As String)
            _fechaFin = value
        End Set
    End Property

    Private _fechaInicio As String
    Public Property fechaInicio() As String
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As String)
            _fechaInicio = value
        End Set
    End Property

    Private _Sucursal As Integer
    Public Property Sucursal() As Integer
        Get
            Return _Sucursal
        End Get
        Set(ByVal value As Integer)
            _Sucursal = value
        End Set
    End Property
    Private _Estado As Integer
    Public Property Estado() As Integer
        Get
            Return _Estado
        End Get
        Set(ByVal value As Integer)
            _Estado = value
        End Set
    End Property

    Private _Valores As Boolean
    Public Property Valores() As Boolean
        Get
            Return _Valores
        End Get
        Set(ByVal value As Boolean)
            _Valores = value
        End Set
    End Property

    Private _Nom_Sku As String
    Public Property Nom_Sku() As String
        Get
            Return _Nom_Sku
        End Get
        Set(ByVal value As String)
            _Nom_Sku = value
        End Set
    End Property



End Class
