Public Class VentaEmpresaTienda
    Private m_CodSucursal As Integer
    Private m_NomSucursal As String
    Private m_Dia As DateTime
    Private m_CodFamilia As String
    Private m_NombreFamilia As String
    Private m_Marca As String
    Private m_VentaContado As Decimal
    Private m_VentaCredito As Decimal
    Private m_VentaNetaTotal As Decimal
    Private m_VentaNetaTotalCIA As Decimal
    Private m_PlanVentaVVEE As Decimal
    Private m_VentaContadoAA As Decimal
    Private m_VentaCreditoAA As Decimal
    Private m_VentaNetaTotalAA As Decimal
    Private m_PlanMargenVVEE As Decimal
    Private m_MargenCredito As Decimal
    Private m_MargenContado As Decimal
    Private m_MargenTotal As Decimal
    Private m_MargenCreditoAA As Decimal
    Private m_MargenContadoAA As Decimal
    Private m_MargenTotalAA As Decimal
    Private m_TranCredito As Integer
    Private m_TranContado As Integer
    Private m_TranTotal As Integer
    Private m_TranCreditoAA As Integer
    Private m_TranContadoAA As Integer
    Private m_TranTotalAA As Integer

    Public Property CodSucursal() As Integer
        Get
            Return m_CodSucursal
        End Get
        Set(ByVal value As Integer)
            m_CodSucursal = value
        End Set
    End Property

    Public Property NomSucursal As String
        Get
            Return m_NomSucursal
        End Get
        Set(value As String)
            m_NomSucursal = value
        End Set
    End Property

    Public Property Dia As String
        Get
            Return m_Dia
        End Get
        Set(value As String)
            m_Dia = value
        End Set
    End Property

    Public Property CodFamilia() As String
        Get
            Return m_CodFamilia
        End Get
        Set(ByVal value As String)
            m_CodFamilia = value
        End Set
    End Property

    Public Property NombreFamilia As String
        Get
            Return m_NombreFamilia
        End Get
        Set(value As String)
            m_NombreFamilia = value
        End Set
    End Property

    Public Property Marca As String
        Get
            Return m_Marca
        End Get
        Set(value As String)
            m_Marca = value
        End Set
    End Property

    Public Property VentaContado As Decimal
        Get
            Return m_VentaContado
        End Get
        Set(value As Decimal)
            m_VentaContado = value
        End Set
    End Property

    Public Property VentaCredito As Decimal
        Get
            Return m_VentaCredito
        End Get
        Set(value As Decimal)
            m_VentaCredito = value
        End Set
    End Property

    Public Property VentaNetaTotal As Decimal
        Get
            Return m_VentaNetaTotal
        End Get
        Set(value As Decimal)
            m_VentaNetaTotal = value
        End Set
    End Property

    Public Property VentaNetaTotalCIA As Decimal
        Get
            Return m_VentaNetaTotalCIA
        End Get
        Set(value As Decimal)
            m_VentaNetaTotalCIA = value
        End Set
    End Property

    Public Property PlanVentaVVEE As Decimal
        Get
            Return m_PlanVentaVVEE
        End Get
        Set(value As Decimal)
            m_PlanVentaVVEE = value
        End Set
    End Property

    Public Property VentaContadoAA As Decimal
        Get
            Return m_VentaContadoAA
        End Get
        Set(value As Decimal)
            m_VentaContadoAA = value
        End Set
    End Property

    Public Property VentaCreditoAA As Decimal
        Get
            Return m_VentaCreditoAA
        End Get
        Set(value As Decimal)
            m_VentaCreditoAA = value
        End Set
    End Property

    Public Property VentaNetaTotalAA As Decimal
        Get
            Return m_VentaNetaTotalAA
        End Get
        Set(value As Decimal)
            m_VentaNetaTotalAA = value
        End Set
    End Property

    Public Property PlanMargenVVEE As Decimal
        Get
            Return m_PlanMargenVVEE
        End Get
        Set(value As Decimal)
            m_PlanMargenVVEE = value
        End Set
    End Property

    Public Property MargenCredito As Decimal
        Get
            Return m_MargenCredito
        End Get
        Set(value As Decimal)
            m_MargenCredito = value
        End Set
    End Property

    Public Property MargenContado As Decimal
        Get
            Return m_MargenContado
        End Get
        Set(value As Decimal)
            m_MargenContado = value
        End Set
    End Property

    Public Property MargenTotal As Decimal
        Get
            Return m_MargenTotal
        End Get
        Set(value As Decimal)
            m_MargenTotal = value
        End Set
    End Property

    Public Property MargenCreditoAA As Decimal
        Get
            Return m_MargenCreditoAA
        End Get
        Set(value As Decimal)
            m_MargenCreditoAA = value
        End Set
    End Property

    Public Property MargenContadoAA As Decimal
        Get
            Return m_MargenContadoAA
        End Get
        Set(value As Decimal)
            m_MargenContadoAA = value
        End Set
    End Property

    Public Property MargenTotalAA As Decimal
        Get
            Return m_MargenTotalAA
        End Get
        Set(value As Decimal)
            m_MargenTotalAA = value
        End Set
    End Property

    Public Property TranCredito As Integer
        Get
            Return m_TranCredito
        End Get
        Set(value As Integer)
            m_TranCredito = value
        End Set
    End Property

    Public Property TranContado As Integer
        Get
            Return m_TranContado
        End Get
        Set(value As Integer)
            m_TranContado = value
        End Set
    End Property

    Public Property TranTotal As Integer
        Get
            Return m_TranTotal
        End Get
        Set(value As Integer)
            m_TranTotal = value
        End Set
    End Property

    Public Property TranCreditoAA As Integer
        Get
            Return m_TranCreditoAA
        End Get
        Set(value As Integer)
            m_TranCreditoAA = value
        End Set
    End Property

    Public Property TranContadoAA As Integer
        Get
            Return m_TranContadoAA
        End Get
        Set(value As Integer)
            m_TranContadoAA = value
        End Set
    End Property

    Public Property TranTotalAA As Integer
        Get
            Return m_TranTotalAA
        End Get
        Set(value As Integer)
            m_TranTotalAA = value
        End Set
    End Property
End Class