Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Venta.Cartera")> _
<MetadataType(GetType(Validation.VentaCarteraMetadata))> _
Public Class VentaCartera

    Private m_IdCartera As Integer
    Private m_IdCliente As Integer
    Private m_IdEmpleado As Integer
    Private m_IdCarteraEmpleadoTipo As Integer
    Private m_FechaDesde As DateTime
    Private m_FechaHasta As DateTime
    Private m_FechaActivacion As DateTime
    Private m_IdEstadoActual As Integer
    Private m_IdSucursal As String
    Private m_Activo As Boolean
    Private m_Empleado As Empleado
    Private m_Cliente As ClienteVenta
    Private m_Sucursal As Sucursal
    Private _Flag As Integer
    Private m_Usuario As String
    Private m_TCompartida As Integer

    Public Property TCompartida() As Integer
        Get
            Return m_TCompartida
        End Get
        Set(ByVal value As Integer)
            m_TCompartida = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_Usuario
        End Get
        Set(ByVal value As String)
            m_Usuario = value
        End Set
    End Property

    Public Property Flag() As Integer
        Get
            Return _Flag
        End Get
        Set(ByVal value As Integer)
            _Flag = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCartera", IsRequired:=False, Order:=0)> _
    Public Property IdCartera() As Integer
        Get
            Return m_IdCartera
        End Get
        Set(ByVal value As Integer)
            m_IdCartera = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=1)> _
    Public Property IdCliente() As Integer
        Get
            Return m_IdCliente
        End Get
        Set(ByVal value As Integer)
            m_IdCliente = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdEmpleado", IsRequired:=False, Order:=2)> _
    Public Property IdEmpleado() As Integer
        Get
            Return m_IdEmpleado
        End Get
        Set(ByVal value As Integer)
            m_IdEmpleado = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCarteraEmpleadoTipo", IsRequired:=False, Order:=3)> _
    Public Property IdCarteraEmpleadoTipo() As Integer
        Get
            Return m_IdCarteraEmpleadoTipo
        End Get
        Set(ByVal value As Integer)
            m_IdCarteraEmpleadoTipo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=4)> _
    Public Property FechaDesde() As DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(ByVal value As DateTime)
            m_FechaDesde = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=5)> _
    Public Property FechaHasta() As DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(ByVal value As DateTime)
            m_FechaHasta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdEstadoActual", IsRequired:=False, Order:=6)> _
    Public Property IdEstadoActual() As Integer
        Get
            Return m_IdEstadoActual
        End Get
        Set(ByVal value As Integer)
            m_IdEstadoActual = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=7)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdSucursal", IsRequired:=False, Order:=8)> _
    Public Property IdSucursal() As String
        Get
            Return m_IdSucursal
        End Get
        Set(ByVal value As String)
            m_IdSucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaActivacion", IsRequired:=False, Order:=9)> _
    Public Property FechaActivacion() As String
        Get
            Return m_FechaActivacion
        End Get
        Set(ByVal value As String)
            m_FechaActivacion = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Empleado", IsRequired:=False, Order:=10)> _
    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(value As Empleado)
            m_Empleado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ClienteVenta", IsRequired:=False, Order:=12)> _
    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_Cliente
        End Get
        Set(value As ClienteVenta)
            m_Cliente = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Sucursal", IsRequired:=False, Order:=13)> _
    Public Property Sucursal() As Sucursal
        Get
            Return m_Sucursal
        End Get
        Set(value As Sucursal)
            m_Sucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Porcentaje", IsRequired:=False, Order:=14)> _
    Private m_Porcentaje As Decimal
    Public Property Porcentaje() As Decimal
        Get
            Return m_Porcentaje
        End Get
        Set(ByVal value As Decimal)
            m_Porcentaje = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaDesignacion", IsRequired:=False, Order:=15)> _
    Private m_FechaDesignacion As DateTime
    Public Property FechaDesignacion() As DateTime
        Get
            Return m_FechaDesignacion
        End Get
        Set(value As DateTime)
            m_FechaDesignacion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaAsignacion", IsRequired:=False, Order:=16)> _
    Private m_FechaAsignacion As DateTime
    Public Property FechaAsignacion() As DateTime
        Get
            Return m_FechaAsignacion
        End Get
        Set(value As DateTime)
            m_FechaAsignacion = value
        End Set
    End Property

End Class
