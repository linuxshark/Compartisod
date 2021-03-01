Imports WcfSerialization = System.Runtime.Serialization
<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="VentaExportar")> _
Public Class VentaExportar

    Private m_id As Integer
    Private m_row As Integer

    Public Property Id() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property

    Public Property Row() As Integer
        Get
            Return m_row
        End Get
        Set(ByVal value As Integer)
            m_row = value
        End Set
    End Property

    Private m_idTipoDocumento As Integer
    Public Property IdTipoDocumento() As Integer
        Get
            Return m_idTipoDocumento
        End Get
        Set(ByVal value As Integer)
            m_idTipoDocumento = value
        End Set
    End Property
    Private m_descripcion As String
    Public Property Descripcion() As String
        Get
            Return m_descripcion
        End Get
        Set(ByVal value As String)
            m_descripcion = value
        End Set
    End Property
    Private m_numeroDocumento As Integer
    Public Property NumeroDocumento() As Integer
        Get
            Return m_numeroDocumento
        End Get
        Set(ByVal value As Integer)
            m_numeroDocumento = value
        End Set
    End Property

    Private m_RUC As String
    Public Property RUC() As String
        Get
            Return m_RUC
        End Get
        Set(ByVal value As String)
            m_RUC = value
        End Set
    End Property

    Private m_RazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return m_RazonSocial
        End Get
        Set(ByVal value As String)
            m_RazonSocial = value
        End Set
    End Property
    Private m_CodigoSucursal As String
    Public Property CodigoSucursal() As String
        Get
            Return m_CodigoSucursal
        End Get
        Set(ByVal value As String)
            m_CodigoSucursal = value
        End Set
    End Property
    Private m_NombreSucursal As String
    Public Property NombreSucursal() As String
        Get
            Return m_NombreSucursal
        End Get
        Set(ByVal value As String)
            m_NombreSucursal = value
        End Set
    End Property
    Private m_CodigoRRVV As String
    Public Property CodigoRRVV() As String
        Get
            Return m_CodigoRRVV
        End Get
        Set(ByVal value As String)
            m_CodigoRRVV = value
        End Set
    End Property
    Private m_RepresentanteVenta As String
    Public Property RepresentanteVenta() As String
        Get
            Return m_RepresentanteVenta
        End Get
        Set(ByVal value As String)
            m_RepresentanteVenta = value
        End Set
    End Property
    Private m_IdJefeVentas As Integer
    Public Property IdJefeVentas() As Integer
        Get
            Return m_IdJefeVentas
        End Get
        Set(ByVal value As Integer)
            m_IdJefeVentas = value
        End Set
    End Property
    Private m_JefeVentas As String
    Public Property JefeVentas() As String
        Get
            Return m_JefeVentas
        End Get
        Set(ByVal value As String)
            m_JefeVentas = value
        End Set
    End Property
    Private m_TipoCliente As String
    Public Property TipoCliente() As String
        Get
            Return m_TipoCliente
        End Get
        Set(ByVal value As String)
            m_TipoCliente = value
        End Set
    End Property
    Private m_Fecha As String
    Public Property Fecha() As String
        Get
            Return m_Fecha
        End Get
        Set(ByVal value As String)
            m_Fecha = value
        End Set
    End Property
    Private m_Fecha1 As String
    Public Property Fecha1() As String
        Get
            Return m_Fecha1
        End Get
        Set(ByVal value As String)
            m_Fecha1 = value
        End Set
    End Property
    Private m_TipoCaja As String
    Public Property NewProperty() As String
        Get
            Return m_TipoCaja
        End Get
        Set(ByVal value As String)
            m_TipoCaja = value
        End Set
    End Property
    Private m_FormaPago As String
    Public Property FormaPago() As String
        Get
            Return m_FormaPago
        End Get
        Set(ByVal value As String)
            m_FormaPago = value
        End Set
    End Property
    Private m_CodigoProveedor As String
    Public Property CodigoProveedor() As String
        Get
            Return m_CodigoProveedor
        End Get
        Set(ByVal value As String)
            m_CodigoProveedor = value
        End Set
    End Property
    Private m_NombreProveedor As String
    Public Property NombreProveedor() As String
        Get
            Return m_NombreProveedor
        End Get
        Set(ByVal value As String)
            m_NombreProveedor = value
        End Set
    End Property
    Private m_SKU As String
    Public Property SKU() As String
        Get
            Return m_SKU
        End Get
        Set(ByVal value As String)
            m_SKU = value
        End Set
    End Property
    Private m_DescripcionSKU As String
    Public Property DescripcionSKU() As String
        Get
            Return m_DescripcionSKU
        End Get
        Set(ByVal value As String)
            m_DescripcionSKU = value
        End Set
    End Property
    Private m_ClaCom As String
    Public Property ClaCom() As String
        Get
            Return m_ClaCom
        End Get
        Set(ByVal value As String)
            m_ClaCom = value
        End Set
    End Property
    Private m_DescripcionClaCom As String
    Public Property DescripcionClaCom() As String
        Get
            Return m_DescripcionClaCom
        End Get
        Set(ByVal value As String)
            m_DescripcionClaCom = value
        End Set
    End Property
    Private m_CodDepAnt As String
    Public Property CodDepAnt() As String
        Get
            Return m_CodDepAnt
        End Get
        Set(ByVal value As String)
            m_CodDepAnt = value
        End Set
    End Property
    Private m_NomDepAnt As String
    Public Property NomDepAnt() As String
        Get
            Return m_NomDepAnt
        End Get
        Set(ByVal value As String)
            m_NomDepAnt = value
        End Set
    End Property
    Private m_CodFamAnt As String
    Public Property CodFamAnt() As String
        Get
            Return m_CodFamAnt
        End Get
        Set(ByVal value As String)
            m_CodFamAnt = value
        End Set
    End Property
    Private m_NomFamAnt As String
    Public Property NomFamAnt() As String
        Get
            Return m_NomFamAnt
        End Get
        Set(ByVal value As String)
            m_NomFamAnt = value
        End Set
    End Property
    Private m_Cantidad As Decimal
    Public Property Cantidad() As Decimal
        Get
            Return m_Cantidad
        End Get
        Set(ByVal value As Decimal)
            m_Cantidad = value
        End Set
    End Property
    Private m_PrecioNeto As Decimal
    Public Property PrecioNeto() As Decimal
        Get
            Return m_PrecioNeto
        End Get
        Set(ByVal value As Decimal)
            m_PrecioNeto = value
        End Set
    End Property
    Private m_Subtotal As Decimal
    Public Property Subtotal() As Decimal
        Get
            Return m_Subtotal
        End Get
        Set(ByVal value As Decimal)
            m_Subtotal = value
        End Set
    End Property
    Private m_IGV_ As Decimal
    Public Property IGV_() As Decimal
        Get
            Return m_IGV_
        End Get
        Set(ByVal value As Decimal)
            m_IGV_ = value
        End Set
    End Property
    Private m_TOTAL_ As Decimal
    Public Property TOTAL_() As Decimal
        Get
            Return m_TOTAL_
        End Get
        Set(ByVal value As Decimal)
            m_TOTAL_ = value
        End Set
    End Property
    Private m_CostoUnitario As Decimal
    Public Property CostoUnitario() As Decimal
        Get
            Return m_CostoUnitario
        End Get
        Set(ByVal value As Decimal)
            m_CostoUnitario = value
        End Set
    End Property
    Private m_IGV As Decimal
    Public Property IGV() As Decimal
        Get
            Return m_IGV
        End Get
        Set(ByVal value As Decimal)
            m_IGV = value
        End Set
    End Property
    Private m_Total As Decimal
    Public Property Total() As Decimal
        Get
            Return m_Total
        End Get
        Set(ByVal value As Decimal)
            m_Total = value
        End Set
    End Property
    Private m_CostoTotal As Decimal
    Public Property CostoTotal() As Decimal
        Get
            Return m_CostoTotal
        End Get
        Set(ByVal value As Decimal)
            m_CostoTotal = value
        End Set
    End Property
    Private m_Contribucion As Decimal
    Public Property Contribucion() As Decimal
        Get
            Return m_Contribucion
        End Get
        Set(ByVal value As Decimal)
            m_Contribucion = value
        End Set
    End Property
    Private m_Margen As Decimal
    Public Property Margen() As Decimal
        Get
            Return m_Margen
        End Get
        Set(ByVal value As Decimal)
            m_Margen = value
        End Set
    End Property
    Private m_DescripcionCorta As String
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(ByVal value As String)
            m_DescripcionCorta = value
        End Set
    End Property
    Private m_NombresApellidos As String
    Public Property NombresApellidos() As String
        Get
            Return m_NombresApellidos
        End Get
        Set(ByVal value As String)
            m_NombresApellidos = value
        End Set
    End Property
    Private m_NombresApellidosJefeRegional As String
    Public Property NombresApellidosJefeRegional() As String
        Get
            Return m_NombresApellidosJefeRegional
        End Get
        Set(ByVal value As String)
            m_NombresApellidosJefeRegional = value
        End Set
    End Property
    Private m_NombreTipoCliente As String
    Public Property NombreTipoCliente() As String
        Get
            Return m_NombreTipoCliente
        End Get
        Set(ByVal value As String)
            m_NombreTipoCliente = value
        End Set
    End Property
    Private m_NombreGrupo As String
    Public Property NombreGrupo() As String
        Get
            Return m_NombreGrupo
        End Get
        Set(ByVal value As String)
            m_NombreGrupo = value
        End Set
    End Property
    Private m_DESCRIPHEADER1 As String
    Public Property DESCRIPHEADER1() As String
        Get
            Return m_DESCRIPHEADER1
        End Get
        Set(ByVal value As String)
            m_DESCRIPHEADER1 = value
        End Set
    End Property
    Private m_DESCRIPHEADER2 As String
    Public Property DESCRIPHEADER2() As String
        Get
            Return m_DESCRIPHEADER2
        End Get
        Set(ByVal value As String)
            m_DESCRIPHEADER2 = value
        End Set
    End Property
    Private m_DESCRIPHEADER3 As String
    Public Property DESCRIPHEADER3() As String
        Get
            Return m_DESCRIPHEADER3
        End Get
        Set(ByVal value As String)
            m_DESCRIPHEADER3 = value
        End Set
    End Property
    Private m_DESCRIPHEADER4 As String
    Public Property DESCRIPHEADER4() As String
        Get
            Return m_DESCRIPHEADER4
        End Get
        Set(ByVal value As String)
            m_DESCRIPHEADER4 = value
        End Set
    End Property
    Private m_DESCRIPHEADER5 As String
    Public Property DESCRIPHEADER5() As String
        Get
            Return m_DESCRIPHEADER5
        End Get
        Set(ByVal value As String)
            m_DESCRIPHEADER5 = value
        End Set
    End Property
    Private m_DESCRIPHEADER6 As String
    Public Property DESCRIPHEADER6() As String
        Get
            Return m_DESCRIPHEADER6
        End Get
        Set(ByVal value As String)
            m_DESCRIPHEADER6 = value
        End Set
    End Property
    Private m_DescZona As String
    Public Property DescZona() As String
        Get
            Return m_DescZona
        End Get
        Set(ByVal value As String)
            m_DescZona = value
        End Set
    End Property
    Private m_DescGrupo As String
    Public Property DescGrupo() As String
        Get
            Return m_DescGrupo
        End Get
        Set(ByVal value As String)
            m_DescGrupo = value
        End Set
    End Property
    Private m_MARCA As String
    Public Property MARCA() As String
        Get
            Return m_MARCA
        End Get
        Set(ByVal value As String)
            m_MARCA = value
        End Set
    End Property
    Private m_PercepcionPorcentaje As Decimal
    Public Property PercepcionPorcentaje() As Decimal
        Get
            Return m_PercepcionPorcentaje
        End Get
        Set(ByVal value As Decimal)
            m_PercepcionPorcentaje = value
        End Set
    End Property
    Private m_MontoPercepcion As Decimal
    Public Property MontoPercepcion() As Decimal
        Get
            Return m_MontoPercepcion
        End Get
        Set(ByVal value As Decimal)
            m_MontoPercepcion = value
        End Set
    End Property
    Private m_TotalVtaIgvPercepcion As Decimal
    Public Property TotalVtaIgvPercepcion() As Decimal
        Get
            Return m_TotalVtaIgvPercepcion
        End Get
        Set(ByVal value As Decimal)
            m_TotalVtaIgvPercepcion = value
        End Set
    End Property



End Class
