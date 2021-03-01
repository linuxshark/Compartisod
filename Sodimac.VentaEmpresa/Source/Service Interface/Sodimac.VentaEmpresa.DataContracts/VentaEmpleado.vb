Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Venta.VentaEmpleado")> _
Public Class VentaEmpleado

    Private m_IdVentaEmpleado As Integer
    Private m_IdVentaEmpleadoTipoCierre As Integer
    Private m_IdVentaPeriodo As Integer
    Private m_IdEmpleado As Integer
    Private m_IdEmpleadoCargo As Integer
    Private m_EmpleadoCargo As String
    Private m_IdSucursal As Integer
    Private m_Sucursal As String
    Private m_IdPlanVenta As Integer
    Private m_PlanVenta As Decimal
    Private m_TotalVentas As Decimal
    Private m_TotalVentasComisionable As Decimal
    Private m_PorcentajeCumplimiento As Decimal
    Private m_TotalFactura As Decimal
    Private m_TotalNotaCredito As Decimal
    Private m_TotalNotaDebitoSuma As Decimal
    Private m_TotalNotaDebitoResta As Decimal
    Private m_TiempoServicioSucursal As Integer
    Private m_TiempoServicioTotal As Integer
    Private m_IdEstadoActual As Integer
    Private m_FechaRegistro As DateTime
    Private m_FechaActualizacion As DateTime
    Private m_Activo As Boolean

    <WcfSerialization.DataMember(Name:="IdVentaEmpleado", IsRequired:=False, Order:=0)> _
    Public Property IdVentaEmpleado() As Integer
        Get
            Return m_IdVentaEmpleado
        End Get
        Set(value As Integer)
            m_IdVentaEmpleado = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdVentaEmpleadoTipoCierre", IsRequired:=False, Order:=1)> _
    Public Property IdVentaEmpleadoTipoCierre() As Integer
        Get
            Return m_IdVentaEmpleadoTipoCierre
        End Get
        Set(value As Integer)
            m_IdVentaEmpleadoTipoCierre = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdVentaPeriodo", IsRequired:=False, Order:=2)> _
    Public Property IdVentaPeriodo() As Integer
        Get
            Return m_IdVentaPeriodo
        End Get
        Set(value As Integer)
            m_IdVentaPeriodo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdEmpleado", IsRequired:=False, Order:=3)> _
    Public Property IdEmpleado() As Integer
        Get
            Return m_IdEmpleado
        End Get
        Set(value As Integer)
            m_IdEmpleado = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdEmpleadoCargo", IsRequired:=False, Order:=4)> _
    Public Property IdEmpleadoCargo() As Integer
        Get
            Return m_IdEmpleadoCargo
        End Get
        Set(value As Integer)
            m_IdEmpleadoCargo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="EmpleadoCargo", IsRequired:=False, Order:=5)> _
    Public Property EmpleadoCargo() As String
        Get
            Return m_EmpleadoCargo
        End Get
        Set(value As String)
            m_EmpleadoCargo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdSucursal", IsRequired:=False, Order:=6)> _
    Public Property IdSucursal() As Integer
        Get
            Return m_IdSucursal
        End Get
        Set(value As Integer)
            m_IdSucursal = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Sucursal", IsRequired:=False, Order:=7)> _
    Public Property Sucursal() As String
        Get
            Return m_Sucursal
        End Get
        Set(value As String)
            m_Sucursal = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdPlanVenta", IsRequired:=False, Order:=8)> _
    Public Property IdPlanVenta() As Integer
        Get
            Return m_IdPlanVenta
        End Get
        Set(value As Integer)
            m_IdPlanVenta = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="PlanVenta", IsRequired:=False, Order:=9)> _
    Public Property PlanVenta() As Decimal
        Get
            Return m_PlanVenta
        End Get
        Set(value As Decimal)
            m_PlanVenta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TotalVentas", IsRequired:=False, Order:=10)> _
    Public Property TotalVentas() As Decimal
        Get
            Return m_TotalVentas
        End Get
        Set(value As Decimal)
            m_TotalVentas = value
        End Set

    End Property

    <WcfSerialization.DataMember(Name:="TotalVentasComisionable", IsRequired:=False, Order:=11)> _
    Public Property TotalVentasComisionable() As Decimal
        Get
            Return m_TotalVentasComisionable
        End Get
        Set(value As Decimal)
            m_TotalVentasComisionable = value
        End Set

    End Property

    <WcfSerialization.DataMember(Name:="PorcentajeCumplimiento", IsRequired:=False, Order:=12)> _
    Public Property PorcentajeCumplimiento() As Decimal
        Get
            Return m_PorcentajeCumplimiento
        End Get
        Set(value As Decimal)
            m_PorcentajeCumplimiento = value
        End Set

    End Property
    <WcfSerialization.DataMember(Name:="TotalFactura", IsRequired:=False, Order:=13)> _
    Public Property TotalFactura() As Decimal
        Get
            Return m_TotalFactura
        End Get
        Set(value As Decimal)
            m_TotalFactura = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="TotalNotaCredito", IsRequired:=False, Order:=14)> _
    Public Property TotalNotaCredito() As Decimal
        Get
            Return m_TotalNotaCredito
        End Get
        Set(value As Decimal)
            m_TotalNotaCredito = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TotalNotaDebitoSuma", IsRequired:=False, Order:=15)> _
    Public Property TotalNotaDebitoSuma() As Decimal
        Get
            Return m_TotalNotaDebitoSuma
        End Get
        Set(value As Decimal)
            m_TotalNotaDebitoSuma = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="TotalNotaDebitoResta", IsRequired:=False, Order:=16)> _
    Public Property TotalNotaDebitoResta() As Decimal
        Get
            Return m_TotalNotaDebitoResta
        End Get
        Set(value As Decimal)
            m_TotalNotaDebitoResta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="TiempoServicioSucursal", IsRequired:=False, Order:=17)> _
    Public Property TiempoServicioSucursal() As Integer
        Get
            Return m_TiempoServicioSucursal
        End Get
        Set(value As Integer)
            m_TiempoServicioSucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="TiempoServicioTotal", IsRequired:=False, Order:=18)> _
    Public Property TiempoServicioTotal() As Integer
        Get
            Return m_TiempoServicioTotal
        End Get
        Set(value As Integer)
            m_TiempoServicioTotal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdEstadoActual", IsRequired:=False, Order:=19)> _
    Public Property IdEstadoActual() As Integer
        Get
            Return m_IdEstadoActual
        End Get
        Set(value As Integer)
            m_IdEstadoActual = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=20)> _
    Public Property FechaRegistro() As DateTime
        Get
            Return m_FechaRegistro
        End Get
        Set(value As DateTime)
            m_FechaRegistro = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaActualizacion", IsRequired:=False, Order:=21)> _
    Public Property FechaActualizacion() As DateTime
        Get
            Return m_FechaActualizacion
        End Get
        Set(value As DateTime)
            m_FechaActualizacion = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=22)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(value As Boolean)
            m_Activo = value
        End Set
    End Property
End Class
