Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Cotizacion")>
Public Class Cotizacion
    Private _mNroCotizacion As Integer
    Private _mSubTotal As Decimal
    Private _mDescuentoTotal As Decimal
    Private _mTotalGeneral As Decimal
    Private _mNroCotizacionUxpos As Integer

    <WcfSerialization.DataMember(Name:="NroCotizacion", IsRequired:=False, Order:=0)>
    Public Property NroCotizacion As Integer
        Get
            Return _mNroCotizacion
        End Get
        Set(value As Integer)
            _mNroCotizacion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NroCotizacionUxpos", IsRequired:=True, Order:=1)>
    Public Property NroCotizacionUxpos As Integer
        Get
            Return _mNroCotizacionUxpos
        End Get
        Set
            _mNroCotizacionUxpos = Value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Fecha", IsRequired:=False, Order:=2)>
    Public Property Fecha As String

    <WcfSerialization.DataMember(Name:="Vendedor", IsRequired:=False, Order:=3)>
    Public Property Vendedor As String

    <WcfSerialization.DataMember(Name:="Ruc", IsRequired:=False, Order:=4)>
    Public Property Ruc As String

    <WcfSerialization.DataMember(Name:="Cliente", IsRequired:=False, Order:=5)>
    Public Property Cliente As String

    <WcfSerialization.DataMember(Name:="Tienda", IsRequired:=False, Order:=6)>
    Public Property Tienda As String

    <WcfSerialization.DataMember(Name:="SubTotal", IsRequired:=False, Order:=7)>
    Public Property SubTotal As Decimal
        Get
            Return _mSubTotal
        End Get
        Set(value As Decimal)
            _mSubTotal = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescuentoTotal", IsRequired:=False, Order:=8)>
    Public Property DescuentoTotal As Decimal
        Get
            Return _mDescuentoTotal
        End Get
        Set(value As Decimal)
            _mDescuentoTotal = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TotalGeneral", IsRequired:=False, Order:=9)>
    Public Property TotalGeneral As Decimal
        Get
            Return _mTotalGeneral
        End Get
        Set(value As Decimal)
            _mTotalGeneral = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="EsPreProforma", IsRequired:=False, Order:=10)>
    Public Property EsPreProforma As Boolean

    Public ReadOnly Property NroCotizacionDesc As String
        Get
            Return If(EsPreProforma, "PREPROF 00" & _mNroCotizacion, "PROF 00" & _mNroCotizacion)
        End Get
    End Property

    Public ReadOnly Property NroCotizacionUxposDesc As String
        Get
            Return If(_mNroCotizacionUxpos = 0, "", "" & _mNroCotizacionUxpos)
        End Get
    End Property

    Public ReadOnly Property SubTotalDesc As String
        Get
            Return "S/ " & _mSubTotal
        End Get
    End Property

    Public ReadOnly Property DescuentoTotalDesc As String
        Get
            Return "S/ " & _mDescuentoTotal
        End Get
    End Property

    Public ReadOnly Property TotalGeneralDesc As String
        Get
            Return "S/ " & _mTotalGeneral
        End Get
    End Property

End Class
