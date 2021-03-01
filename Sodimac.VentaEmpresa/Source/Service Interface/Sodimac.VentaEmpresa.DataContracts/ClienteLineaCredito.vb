Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteLineaCredito")> _
Public Class ClienteLineaCredito
    Private m_IdCliente As Integer
    Private m_MontoLineaCreditoAbierta As Decimal
    Private m_TotalDeudaLineaAbierta As Decimal
    Private m_FechaExpiracion As DateTime
    Private m_Responsable As String
    Private m_MontoLineaCreditoDocumento As Decimal
    Private m_TotalDeudaLineaDocumento As Decimal
    Private m_MontoComprometido As String
    Private m_DiasPlazo As Integer
    Private m_TipoContrato As Integer
    Private m_DescripcionContrato As String
    Private m_FechaAperturaLinea As DateTime
    Private m_FechaActivacionLinea As DateTime

    Private m_LCAutorizada As Decimal
    Private m_FactCentral As Decimal
    Private m_LCSigic As Decimal
    Private m_FactSigic As Decimal
    Private m_LCDisponible As Decimal


    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=0)> _
    Public Property IdCliente() As Integer
        Get
            Return m_IdCliente
        End Get
        Set(ByVal value As Integer)
            m_IdCliente = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="MontoLineaCreditoAbierta", IsRequired:=False, Order:=1)> _
    Public Property MontoLineaCreditoAbierta() As Decimal
        Get
            Return m_MontoLineaCreditoAbierta
        End Get
        Set(ByVal value As Decimal)
            m_MontoLineaCreditoAbierta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TotalDeudaLineaAbierta", IsRequired:=False, Order:=2)> _
    Public Property TotalDeudaLineaAbierta() As Decimal
        Get
            Return m_TotalDeudaLineaAbierta
        End Get
        Set(ByVal value As Decimal)
            m_TotalDeudaLineaAbierta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaExpiracion", IsRequired:=False, Order:=3)> _
    Public Property FechaExpiracion() As DateTime
        Get
            Return m_FechaExpiracion
        End Get
        Set(ByVal value As DateTime)
            m_FechaExpiracion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Responsable", IsRequired:=False, Order:=4)> _
    Public Property Responsable() As String
        Get
            Return m_Responsable
        End Get
        Set(ByVal value As String)
            m_Responsable = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="MontoLineaCreditoDocumento", IsRequired:=False, Order:=5)> _
    Public Property MontoLineaCreditoDocumento() As Decimal
        Get
            Return m_MontoLineaCreditoDocumento
        End Get
        Set(ByVal value As Decimal)
            m_MontoLineaCreditoDocumento = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TotalDeudaLineaDocumento", IsRequired:=False, Order:=6)> _
    Public Property TotalDeudaLineaDocumento() As Decimal
        Get
            Return m_TotalDeudaLineaDocumento
        End Get
        Set(ByVal value As Decimal)
            m_TotalDeudaLineaDocumento = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="MontoComprometido", IsRequired:=False, Order:=7)> _
    Public Property MontoComprometido() As String
        Get
            Return m_MontoComprometido
        End Get
        Set(ByVal value As String)
            m_MontoComprometido = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DiasPlazo", IsRequired:=False, Order:=8)> _
    Public Property DiasPlazo() As Integer
        Get
            Return m_DiasPlazo
        End Get
        Set(ByVal value As Integer)
            m_DiasPlazo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TipoContrato", IsRequired:=False, Order:=9)> _
    Public Property TipoContrato() As Integer
        Get
            Return m_TipoContrato
        End Get
        Set(ByVal value As Integer)
            m_TipoContrato = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionContrato", IsRequired:=False, Order:=10)> _
    Public Property DescripcionContrato() As String
        Get
            Return m_DescripcionContrato
        End Get
        Set(ByVal value As String)
            m_DescripcionContrato = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaAperturaLinea", IsRequired:=False, Order:=11)> _
    Public Property FechaAperturaLinea() As DateTime
        Get
            Return m_FechaAperturaLinea
        End Get
        Set(ByVal value As DateTime)
            m_FechaAperturaLinea = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaActivacionLinea", IsRequired:=False, Order:=12)> _
    Public Property FechaActivacionLinea() As DateTime
        Get
            Return m_FechaActivacionLinea
        End Get
        Set(ByVal value As DateTime)
            m_FechaActivacionLinea = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="LCAutorizada", IsRequired:=False, Order:=13)> _
    Public Property LCAutorizada() As Decimal
        Get
            Return m_LCAutorizada
        End Get
        Set(ByVal value As Decimal)
            m_LCAutorizada = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FactCentral", IsRequired:=False, Order:=14)> _
    Public Property FactCentral() As Decimal
        Get
            Return m_FactCentral
        End Get
        Set(ByVal value As Decimal)
            m_FactCentral = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="LCSigic", IsRequired:=False, Order:=15)> _
    Public Property LCSigic() As Decimal
        Get
            Return m_LCSigic
        End Get
        Set(ByVal value As Decimal)
            m_LCSigic = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FactSigic", IsRequired:=False, Order:=16)> _
    Public Property FactSigic() As Decimal
        Get
            Return m_FactSigic
        End Get
        Set(ByVal value As Decimal)
            m_FactSigic = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="LCDisponible", IsRequired:=False, Order:=17)> _
    Public Property LCDisponible() As Decimal
        Get
            Return m_LCDisponible
        End Get
        Set(ByVal value As Decimal)
            m_LCDisponible = value
        End Set
    End Property


End Class
