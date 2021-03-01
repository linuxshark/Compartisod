Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ReporteCotizacion")>
Public Class ReporteCotizacion
    Private _mNroCotizacion As Integer
    Private _mNroCotizacionUxpos As Integer

    Public Property NroCotizacion As Integer
        Get
            Return _mNroCotizacion
        End Get
        Set(value As Integer)
            _mNroCotizacion = value
        End Set
    End Property

    Public Property NroCotizacionUxpos As Integer
        Get
            Return _mNroCotizacionUxpos
        End Get
        Set
            _mNroCotizacionUxpos = Value
        End Set
    End Property

    Public Property Fecha As DateTime

    Public Property Vendedor As String

    Public Property Ruc As String

    Public Property Cliente As String

    Public Property Ccosto As String

    Public Property Tienda As String

    Public Property Sku As String

    Public Property Producto As String

    Public Property PrecioTienda As Decimal

    Public Property PrecioVvEe As Decimal

    Public Property PrecioVvEeSinIgv As Decimal

    Public Property Cantidad As Decimal

    Public Property Total As Decimal

    Public Property EsPreProforma As Boolean

    Public ReadOnly Property NroCotizacionDesc As String
        Get
            Return "PROF 00" & _mNroCotizacion
        End Get
    End Property

    Public ReadOnly Property NroCotizacionUxposDesc As String
        Get
            Return If(_mNroCotizacionUxpos = 0, "", "" & _mNroCotizacionUxpos)
        End Get
    End Property

    Public ReadOnly Property TipoProforma As String
        Get
            Return If(EsPreProforma, "PreProforma", "Proforma")
        End Get
    End Property
End Class