Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Sucursal")> _
<MetadataType(GetType(Validation.SucursalMetadata))> _
Partial Public Class Sucursal
    Private m_IdSucursal As Integer
    Private m_IdZona As Integer
    Private m_IdEmpleadoResponsable As Integer
    Private m_IdDepartamento As Integer
    Private m_IdProvincia As Integer
    Private m_IdDistrito As Integer
    Private m_CodigoSucursal As String

    Private m_CodigosSucursales As String()
    Private m_CodigoUbigeo As String
    Private m_DescripcionSucursal As String
    Private m_DescripcionCorta As String
    Private m_Direccion As String
    Private m_Telefono As String
    Private m_FechaDesde As DateTime
    Private m_FechaHasta As DateTime
    Private m_Activo As Boolean
    Private m_IdSucursalActual As String
    Private m_Descripcion As String
    Private m_SucursalEmpleado As SucursalEmpleado
    Private _Zona As Zona
    Private _EmpleadoCargo As EmpleadoCargo
    Private m_VentaCliente As ClienteVenta
    Private m_Porcentaje As Decimal
    Private m_FechaAsignacion As DateTime
    Private m_FechaDesasignacion As Nullable(Of DateTime) = Nothing
    <WcfSerialization.DataMember(Name:="SucursalEmpleado", IsRequired:=False, Order:=0)> _
    Public Property SucursalEmpleado() As SucursalEmpleado
        Get
            Return m_SucursalEmpleado
        End Get
        Set(value As SucursalEmpleado)
            m_SucursalEmpleado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ClienteVenta", IsRequired:=False, Order:=1)> _
    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_VentaCliente
        End Get
        Set(value As ClienteVenta)
            m_VentaCliente = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="EmpleadoCargo", IsRequired:=False, Order:=2)> _
    Public Property EmpleadoCargo() As EmpleadoCargo
        Get
            Return _EmpleadoCargo
        End Get
        Set(value As EmpleadoCargo)
            _EmpleadoCargo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Zona", IsRequired:=False, Order:=3)> _
    Public Property Zona() As Zona
        Get
            Return _Zona
        End Get
        Set(value As Zona)
            _Zona = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=4)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdSucursalActual", IsRequired:=False, Order:=5)> _
    Public Property IdSucursalActual() As String
        Get
            Return m_IdSucursalActual
        End Get
        Set(value As String)
            m_IdSucursalActual = value
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

    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=7)> _
    Public Property IdZona() As Integer
        Get
            Return m_IdZona
        End Get
        Set(value As Integer)
            m_IdZona = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdEmpleadoResponsable", IsRequired:=False, Order:=8)> _
    Public Property IdEmpleadoResponsable() As String
        Get
            Return m_IdEmpleadoResponsable
        End Get
        Set(value As String)
            m_IdEmpleadoResponsable = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdDepartamento", IsRequired:=False, Order:=9)> _
    Public Property IdDepartamento() As Integer
        Get
            Return m_IdDepartamento
        End Get
        Set(value As Integer)
            m_IdDepartamento = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdProvincia", IsRequired:=False, Order:=10)> _
    Public Property IdProvincia() As Integer
        Get
            Return m_IdProvincia
        End Get
        Set(value As Integer)
            m_IdProvincia = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdDistrito", IsRequired:=False, Order:=11)> _
    Public Property IdDistrito() As Integer
        Get
            Return m_IdDistrito
        End Get
        Set(value As Integer)
            m_IdDistrito = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CodigoSucursal", IsRequired:=False, Order:=12)> _
    Public Property CodigoSucursal() As String
        Get
            Return m_CodigoSucursal
        End Get
        Set(value As String)
            m_CodigoSucursal = value
        End Set
    End Property




    <WcfSerialization.DataMember(Name:="CodigoUbigeo", IsRequired:=False, Order:=13)> _
    Public Property CodigoUbigeo() As String
        Get
            Return m_CodigoUbigeo
        End Get
        Set(value As String)
            m_CodigoUbigeo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=8)> _
    Public Property DescripcionSucursal() As String
        Get
            Return m_DescripcionSucursal
        End Get
        Set(value As String)
            m_DescripcionSucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=15)> _
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(value As String)
            m_DescripcionCorta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Direccion", IsRequired:=False, Order:=16)> _
    Public Property Direccion() As String
        Get
            Return m_Direccion
        End Get
        Set(value As String)
            m_Direccion = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Telefono", IsRequired:=False, Order:=17)> _
    Public Property Telefono() As String
        Get
            Return m_Telefono
        End Get
        Set(value As String)
            m_Telefono = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=18)> _
    Public Property FechaDesde() As DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(value As DateTime)
            m_FechaDesde = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=19)> _
    Public Property FechaHasta() As DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(value As DateTime)
            m_FechaDesde = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=20)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(value As Boolean)
            m_Activo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Porcentaje", IsRequired:=False, Order:=21)> _
    Public Property Porcentaje() As Decimal
        Get
            Return m_Porcentaje
        End Get
        Set(value As Decimal)
            m_Porcentaje = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaAsignacion", IsRequired:=False, Order:=22)> _
    Public Property FechaAsignacion() As DateTime
        Get
            Return m_FechaAsignacion
        End Get
        Set(value As DateTime)
            m_FechaAsignacion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaDesasignacion", IsRequired:=False, Order:=23)> _
    Public Property FechaDesasignacion() As Nullable(Of DateTime)
        Get
            Return m_FechaDesasignacion
        End Get
        Set(value As Nullable(Of DateTime))
            m_FechaDesasignacion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CodigosSucursales", IsRequired:=False, Order:=24)> _
    Public Property CodigosSucursales() As String()
        Get
            Return m_CodigosSucursales
        End Get
        Set(value As String())
            m_CodigosSucursales = value
        End Set
    End Property
End Class
