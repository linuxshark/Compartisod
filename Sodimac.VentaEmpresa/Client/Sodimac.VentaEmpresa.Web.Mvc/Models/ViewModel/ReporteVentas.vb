Public Class ReporteVentas

    Private _TipoDocumento As String
    Public Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get
        Set(ByVal value As String)
            _TipoDocumento = value
        End Set
    End Property

    Private _Correlativo As String
    Public Property Correlativo() As String
        Get
            Return _Correlativo
        End Get
        Set(ByVal value As String)
            _Correlativo = value
        End Set
    End Property

    Private _Ruc As String
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Private _RazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property

    Private _CodigoProveedor As String
    Public Property CodigoProveedor() As String
        Get
            Return _CodigoProveedor
        End Get
        Set(ByVal value As String)
            _CodigoProveedor = value
        End Set
    End Property

    Private _NombreProveedor As String
    Public Property NombreProveedor() As String
        Get
            Return _NombreProveedor
        End Get
        Set(ByVal value As String)
            _NombreProveedor = value
        End Set
    End Property

    Private _Marca As String
    Public Property Marca() As String
        Get
            Return _Marca
        End Get
        Set(ByVal value As String)
            _Marca = value
        End Set
    End Property

    Private _Zona As String
    Public Property Zona() As String
        Get
            Return _Zona
        End Get
        Set(ByVal value As String)
            _Zona = value
        End Set
    End Property

    Private _Grupo As String
    Public Property Grupo() As String
        Get
            Return _Grupo
        End Get
        Set(ByVal value As String)
            _Grupo = value
        End Set
    End Property

    Private _CodigoSucursal As String
    Public Property CodigoSucursal() As String
        Get
            Return _CodigoSucursal
        End Get
        Set(ByVal value As String)
            _CodigoSucursal = value
        End Set
    End Property

    Private _DescripcionSucursal As String
    Public Property DescripcionSucursal() As String
        Get
            Return _DescripcionSucursal
        End Get
        Set(ByVal value As String)
            _DescripcionSucursal = value
        End Set
    End Property

    Private _CodigoRRVV As String
    Public Property CodigoRRVV() As String
        Get
            Return _CodigoRRVV
        End Get
        Set(ByVal value As String)
            _CodigoRRVV = value
        End Set
    End Property

    Private _RepresentanteVentas As String
    Public Property RepresentanteVentas() As String
        Get
            Return _RepresentanteVentas
        End Get
        Set(ByVal value As String)
            _RepresentanteVentas = value
        End Set
    End Property

    Private _JefeVentas As String
    Public Property JefeVentas() As String
        Get
            Return _JefeVentas
        End Get
        Set(ByVal value As String)
            _JefeVentas = value
        End Set
    End Property

    Private _TipoCliente As String
    Public Property TipoCliente() As String
        Get
            Return _TipoCliente
        End Get
        Set(ByVal value As String)
            _TipoCliente = value
        End Set
    End Property

    Private _Fecha As String
    Public Property Fecha() As String
        Get
            Return _Fecha
        End Get
        Set(ByVal value As String)
            _Fecha = value
        End Set
    End Property

    Private _TipoCaja As String
    Public Property TipoCaja() As String
        Get
            Return _TipoCaja
        End Get
        Set(ByVal value As String)
            _TipoCaja = value
        End Set
    End Property

    Private _ModoPago As String
    Public Property ModoPago() As String
        Get
            Return _ModoPago
        End Get
        Set(ByVal value As String)
            _ModoPago = value
        End Set
    End Property

    Private _SKU As String
    Public Property SKU() As String
        Get
            Return _SKU
        End Get
        Set(ByVal value As String)
            _SKU = value
        End Set
    End Property

    Private _DescripcionSKU As String
    Public Property DescripcionSKU() As String
        Get
            Return _DescripcionSKU
        End Get
        Set(ByVal value As String)
            _DescripcionSKU = value
        End Set
    End Property

    Private _CLACOM As String
    Public Property CLACOM() As String
        Get
            Return _CLACOM
        End Get
        Set(ByVal value As String)
            _CLACOM = value
        End Set
    End Property

    Private _DescripcionCLACOM As String
    Public Property DescripcionCLACOM() As String
        Get
            Return _DescripcionCLACOM
        End Get
        Set(ByVal value As String)
            _DescripcionCLACOM = value
        End Set
    End Property

    Private _DPTOAntiguo As String
    Public Property DPTOAntiguo() As String
        Get
            Return _DPTOAntiguo
        End Get
        Set(ByVal value As String)
            _DPTOAntiguo = value
        End Set
    End Property

    Private _DescDPTO As String
    Public Property DescDPTO() As String
        Get
            Return _DescDPTO
        End Get
        Set(ByVal value As String)
            _DescDPTO = value
        End Set
    End Property

    Private _FamiliaAntigua As String
    Public Property FamiliaAntigua() As String
        Get
            Return _FamiliaAntigua
        End Get
        Set(ByVal value As String)
            _FamiliaAntigua = value
        End Set
    End Property

    Private _DESCFamilia As String
    Public Property DescripcionFamilia() As String
        Get
            Return _DESCFamilia
        End Get
        Set(ByVal value As String)
            _DESCFamilia = value
        End Set
    End Property

    Private _Cantidad As String
    Public Property Cantidad() As String
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As String)
            _Cantidad = value
        End Set
    End Property

    Private _ValorVenta As String
    Public Property ValorVenta() As String
        Get
            Return _ValorVenta
        End Get
        Set(ByVal value As String)
            _ValorVenta = value
        End Set
    End Property

    Private _SubTotal As String
    Public Property SubTotal() As String
        Get
            Return _SubTotal
        End Get
        Set(ByVal value As String)
            _SubTotal = value
        End Set
    End Property

    Private _IGV As String
    Public Property IGV() As String
        Get
            Return _IGV
        End Get
        Set(ByVal value As String)
            _IGV = value
        End Set
    End Property

    Private _Total As String
    Public Property Total() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
        End Set
    End Property

    Private _CostoTotal As String
    Public Property CostoTotal() As String
        Get
            Return _CostoTotal
        End Get
        Set(ByVal value As String)
            _CostoTotal = value
        End Set
    End Property

    Private _Margen As String
    Public Property Margen() As String
        Get
            Return _Margen
        End Get
        Set(ByVal value As String)
            _Margen = value
        End Set
    End Property

    Private _Contribucion As String
    Public Property Contribucion() As String
        Get
            Return _Contribucion
        End Get
        Set(ByVal value As String)
            _Contribucion = value
        End Set
    End Property

    Private _Percepcion As String
    Public Property Percepcion() As String
        Get
            Return _Percepcion
        End Get
        Set(ByVal value As String)
            _Percepcion = value
        End Set
    End Property

    Private _MontoPercepcion As String
    Public Property MontoPercepcion() As String
        Get
            Return _MontoPercepcion
        End Get
        Set(ByVal value As String)
            _MontoPercepcion = value
        End Set
    End Property

    Private _TotalIGV_Percepcion As String
    Public Property TotalIGV_Percepcion() As String
        Get
            Return _TotalIGV_Percepcion
        End Get
        Set(ByVal value As String)
            _TotalIGV_Percepcion = value
        End Set
    End Property
End Class
