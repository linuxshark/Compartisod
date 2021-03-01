Public Class ReporteVentaEmpresa

    Private _IdZona As Integer
    Public Property IdZona() As Integer
        Get
            Return _IdZona
        End Get
        Set(ByVal value As Integer)
            _IdZona = value
        End Set
    End Property

    Private _NombreZona As String
    Public Property NombreZona() As String
        Get
            Return _NombreZona
        End Get
        Set(ByVal value As String)
            _NombreZona = value
        End Set
    End Property

    Private _CodigoTienda As Integer
    Public Property CodigoTienda() As Integer
        Get
            Return _CodigoTienda
        End Get
        Set(ByVal value As Integer)
            _CodigoTienda = value
        End Set
    End Property

    Private _Tienda As String
    Public Property Tienda() As String
        Get
            Return _Tienda
        End Get
        Set(ByVal value As String)
            _Tienda = value
        End Set
    End Property

#Region "Reporte Detallado por Familia"
    
    Private _CodFamNue As String
    Public Property CodigoFamilia() As String
        Get
            Return _CodFamNue
        End Get
        Set(ByVal value As String)
            _CodFamNue = value
        End Set
    End Property

    Private _Familia As String
    Public Property Familia() As String
        Get
            Return _Familia
        End Get
        Set(ByVal value As String)
            _Familia = value
        End Set
    End Property

    Private _Venta As Decimal
    Public Property Venta() As Decimal
        Get
            Return _Venta
        End Get
        Set(ByVal value As Decimal)
            _Venta = value
        End Set
    End Property

    Private _Margen As Decimal
    Public Property Margen() As Decimal
        Get
            Return _Margen
        End Get
        Set(ByVal value As Decimal)
            _Margen = value
        End Set
    End Property

    Private _Transacciones As Integer
    Public Property Transacciones() As Integer
        Get
            Return _Transacciones
        End Get
        Set(ByVal value As Integer)
            _Transacciones = value
        End Set
    End Property

    Private _TicketPromedio As Decimal
    Public Property TicketPromedio() As Decimal
        Get
            Return _TicketPromedio
        End Get
        Set(ByVal value As Decimal)
            _TicketPromedio = value
        End Set
    End Property
#End Region

#Region "Reporte Detallado por Dia"

    Private _DiaNatural As Date
    Public Property DiaNatural() As Date
        Get
            Return _DiaNatural
        End Get
        Set(ByVal value As Date)
            _DiaNatural = value
        End Set
    End Property

    Private _VentaContado As Decimal
    Public Property VentaContado() As Decimal
        Get
            Return _VentaContado
        End Get
        Set(ByVal value As Decimal)
            _VentaContado = value
        End Set
    End Property

    Private _VentaCredito As Decimal
    Public Property VentaCredito() As Decimal
        Get
            Return _VentaCredito
        End Get
        Set(ByVal value As Decimal)
            _VentaCredito = value
        End Set
    End Property

    Private _MargenContado As Decimal
    Public Property MargenContado() As Decimal
        Get
            Return _MargenContado
        End Get
        Set(ByVal value As Decimal)
            _MargenContado = value
        End Set
    End Property

    Private _MargenCredito As Decimal
    Public Property MargenCredito() As Decimal
        Get
            Return _MargenCredito
        End Get
        Set(ByVal value As Decimal)
            _MargenCredito = value
        End Set
    End Property

    Private _TransaccionesContado As Decimal
    Public Property TransaccionesContado() As Decimal
        Get
            Return _TransaccionesContado
        End Get
        Set(ByVal value As Decimal)
            _TransaccionesContado = value
        End Set
    End Property

    Private _TransaccionesCredito As Decimal
    Public Property TransaccionesCredito() As Decimal
        Get
            Return _TransaccionesCredito
        End Get
        Set(ByVal value As Decimal)
            _TransaccionesCredito = value
        End Set
    End Property

    Private _TicketPromedioContado As Decimal
    Public Property TicketPromedioContado() As Decimal
        Get
            Return _TicketPromedioContado
        End Get
        Set(ByVal value As Decimal)
            _TicketPromedioContado = value
        End Set
    End Property

    Private _TicketPromedioCredito As Decimal
    Public Property TicketPromedioCredito() As Decimal
        Get
            Return _TicketPromedioCredito
        End Get
        Set(ByVal value As Decimal)
            _TicketPromedioCredito = value
        End Set
    End Property

#End Region

End Class
