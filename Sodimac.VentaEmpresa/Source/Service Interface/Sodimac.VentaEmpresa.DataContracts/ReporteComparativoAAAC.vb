Public Class ReporteComparativoAAAC

    Private _IdFam As String
    Public Property IdFam() As String
        Get
            Return _IdFam
        End Get
        Set(ByVal value As String)
            _IdFam = value
        End Set
    End Property

    Private _NombreFam As String
    Public Property NombreFam() As String
        Get
            Return _NombreFam
        End Get
        Set(ByVal value As String)
            _NombreFam = value
        End Set
    End Property

    Private _TotalAA As Decimal
    Public Property TotalAA() As Decimal
        Get
            Return _TotalAA
        End Get
        Set(ByVal value As Decimal)
            _TotalAA = value
        End Set
    End Property

    Private _TotalAC As Decimal
    Public Property TotalAC() As Decimal
        Get
            Return _TotalAC
        End Get
        Set(ByVal value As Decimal)
            _TotalAC = value
        End Set
    End Property

  

    Private _Comps As Decimal
    Public Property Comps() As Decimal
        Get
            Return _Comps
        End Get
        Set(ByVal value As Decimal)
            _Comps = value
        End Set
    End Property


End Class
