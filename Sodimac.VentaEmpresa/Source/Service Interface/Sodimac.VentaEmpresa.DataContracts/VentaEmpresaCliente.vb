Public Class VentaEmpresaCliente

    Private m_Ruc As String
    Private m_RazonSocial As String
    Private m_Tiendas As String
    Private m_VentaContadoSOD As Decimal
    Private m_VentaCreditoSOD As Decimal
    Private m_VentaSODIMAC As Decimal
    Private m_VentaContadoMAE As Decimal
    Private m_VentaCreditoMAE As Decimal
    Private m_VentaMAESTRO As Decimal
    Private m_VentaSOD_ObraGruesa As Decimal
    Private m_VentaMAE_ObraGruesa As Decimal
    Private m_VentaContadoSODAA As Decimal
    Private m_VentaCreditoSODAA As Decimal
    Private m_VentaSodimacAA As Decimal
    Private m_VentaContadoMAEAA As Decimal
    Private m_VentaCreditoMAEAA As Decimal
    Private m_VentaMaestroAA As Decimal
    Private m_VentaSOD_ObraGruesaAA As Decimal
    Private m_VentaMAE_ObraGruesaAA As Decimal
    Private m_Boletas_SOD As Integer
    Private m_Boletas_AA As Integer




    Public Property Ruc As String
        Get
            Return m_Ruc
        End Get
        Set(value As String)
            m_Ruc = value
        End Set
    End Property

    Public Property RazonSocial As String
        Get
            Return m_RazonSocial
        End Get
        Set(value As String)
            m_RazonSocial = value
        End Set
    End Property

    Public Property Tiendas As String
        Get
            Return m_Tiendas
        End Get
        Set(value As String)
            m_Tiendas = value
        End Set
    End Property


    Public Property VentaContadoSOD As Decimal
        Get
            Return m_VentaContadoSOD
        End Get
        Set(value As Decimal)
            m_VentaContadoSOD = value
        End Set
    End Property

    Public Property VentaCreditoSOD As Decimal
        Get
            Return m_VentaCreditoSOD
        End Get
        Set(value As Decimal)
            m_VentaCreditoSOD = value
        End Set
    End Property

    Public Property VentaSODIMAC As Decimal
        Get
            Return m_VentaSODIMAC
        End Get
        Set(value As Decimal)
            m_VentaSODIMAC = value
        End Set
    End Property

    Public Property VentaContadoMAE As Decimal
        Get
            Return m_VentaContadoMAE
        End Get
        Set(value As Decimal)
            m_VentaContadoMAE = value
        End Set
    End Property

    Public Property VentaCreditoMAE As Decimal
        Get
            Return m_VentaCreditoMAE
        End Get
        Set(value As Decimal)
            m_VentaCreditoMAE = value
        End Set
    End Property

    Public Property VentaMAESTRO As Decimal
        Get
            Return m_VentaMAESTRO
        End Get
        Set(value As Decimal)
            m_VentaMAESTRO = value
        End Set
    End Property

    Public Property VentaSOD_ObraGruesa As Decimal
        Get
            Return m_VentaSOD_ObraGruesa
        End Get
        Set(value As Decimal)
            m_VentaSOD_ObraGruesa = value
        End Set
    End Property

    Public Property VentaMAE_ObraGruesa As Decimal
        Get
            Return m_VentaMAE_ObraGruesa
        End Get
        Set(value As Decimal)
            m_VentaMAE_ObraGruesa = value
        End Set
    End Property

    Public Property VentaContadoSODAA As Decimal
        Get
            Return m_VentaContadoSODAA
        End Get
        Set(value As Decimal)
            m_VentaContadoSODAA = value
        End Set
    End Property

    Public Property VentaCreditoSODAA As Decimal
        Get
            Return m_VentaCreditoSODAA
        End Get
        Set(value As Decimal)
            m_VentaCreditoSODAA = value
        End Set
    End Property

    Public Property VentaSodimacAA As Decimal
        Get
            Return m_VentaSodimacAA
        End Get
        Set(value As Decimal)
            m_VentaSodimacAA = value
        End Set
    End Property

    Public Property VentaContadoMAEAA As Decimal
        Get
            Return m_VentaContadoMAEAA
        End Get
        Set(value As Decimal)
            m_VentaContadoMAEAA = value
        End Set
    End Property

    Public Property VentaCreditoMAEAA As Decimal
        Get
            Return m_VentaCreditoMAEAA
        End Get
        Set(value As Decimal)
            m_VentaCreditoMAEAA = value
        End Set
    End Property

    Public Property VentaMaestroAA As Decimal
        Get
            Return m_VentaMaestroAA
        End Get
        Set(value As Decimal)
            m_VentaMaestroAA = value
        End Set
    End Property

    Public Property VentaSOD_ObraGruesaAA As Decimal
        Get
            Return m_VentaSOD_ObraGruesaAA
        End Get
        Set(value As Decimal)
            m_VentaSOD_ObraGruesaAA = value
        End Set
    End Property

    Public Property VentaMAE_ObraGruesaAA As Decimal
        Get
            Return m_VentaMAE_ObraGruesaAA
        End Get
        Set(value As Decimal)
            m_VentaMAE_ObraGruesaAA = value
        End Set
    End Property

    Public Property Boletas_SOD As Integer
        Get
            Return m_Boletas_SOD
        End Get
        Set(value As Integer)
            m_Boletas_SOD = value
        End Set
    End Property

    Public Property Boletas_AA As Integer
        Get
            Return m_Boletas_AA
        End Get
        Set(value As Integer)
            m_Boletas_AA = value
        End Set
    End Property

End Class
