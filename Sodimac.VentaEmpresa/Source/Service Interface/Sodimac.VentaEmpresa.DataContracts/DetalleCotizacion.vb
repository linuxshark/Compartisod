Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="DetalleCotizacion")>
Public Class DetalleCotizacion
    Private _mNroCotizacion As Integer
    Private _mPrecioTienda As Decimal
    Private _mPrecioVolumen As Decimal
    Private _mPrecioSinIgv As Decimal
    Private _mTotal As Decimal

    Public Property NroCotizacion As Integer
        Get
            Return _mNroCotizacion
        End Get
        Set(value As Integer)
            _mNroCotizacion = value
        End Set
    End Property

    Public Property Sku As String

    Public Property Producto As String

    Public Property PrecioTienda As Decimal
        Get
            Return _mPrecioTienda
        End Get
        Set(value As Decimal)
            _mPrecioTienda = value
        End Set
    End Property

    Public Property PrecioVolumen As Decimal
        Get
            Return _mPrecioVolumen
        End Get
        Set(value As Decimal)
            _mPrecioVolumen = value
        End Set
    End Property

    Public Property PrecioSinIgv As Decimal
        Get
            Return _mPrecioSinIgv
        End Get
        Set(value As Decimal)
            _mPrecioSinIgv = value
        End Set
    End Property

    Public Property Cantidad As Decimal

    Public Property Total As Decimal
        Get
            Return _mTotal
        End Get
        Set(value As Decimal)
            _mTotal = value
        End Set
    End Property

    Public ReadOnly Property NroCotizacionDesc As String
        Get
            Return "PROF 00" & _mNroCotizacion
        End Get
    End Property

    Public ReadOnly Property PrecioTiendaDesc As String
        Get
            Return "S/ " & _mPrecioTienda
        End Get
    End Property

    Public ReadOnly Property PrecioVolumenDesc As String
        Get
            Return "S/ " & _mPrecioVolumen
        End Get
    End Property

    Public ReadOnly Property PrecioSinIgvDesc As String
        Get
            Return "S/ " & _mPrecioSinIgv
        End Get
    End Property

    Public ReadOnly Property TotalDesc As String
        Get
            Return "S/ " & _mTotal
        End Get
    End Property
End Class
