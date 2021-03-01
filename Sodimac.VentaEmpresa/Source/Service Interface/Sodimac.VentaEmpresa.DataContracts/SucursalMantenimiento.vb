Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="SucursalMantenimiento")> _
<MetadataType(GetType(Validation.SucursalMetadata))> _
Public Class SucursalMantenimiento

    'objetos 
    Private m_departamento As Departamento
    Private m_provincia As Provincia
    Private m_distrito As Distrito
    Private m_zona As ZonaMantenimiento

    '' variable privadas
    Private m_IdSucursal As Integer
    Private m_IdZona As Integer
    Private m_IdEmpleadoResponsable As Integer
    Private m_IdDepartamento As Integer
    Private m_IdProvincia As Integer
    Private m_IdDistrito As Integer
    Private m_CodigoSucursal As String
    Private m_CodigoUbigeo As String
    Private m_Descripcion As String
    Private m_DescripcionCorta As String
    Private m_Direccion As String
    Private m_Telefono As String
    Private m_FechaDesde As DateTime
    Private m_FechaHasta As DateTime
    Private m_Activo As Boolean

    <WcfSerialization.DataMember(Name:="IdSucursal", IsRequired:=False, Order:=0)> _
    Public Property IdSucursal() As Integer
        Get
            Return m_IdSucursal
        End Get
        Set(value As Integer)
            m_IdSucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=1)> _
    Public Property IdZona() As Integer
        Get
            Return m_IdZona
        End Get
        Set(value As Integer)
            m_IdZona = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdEmpleadoResponsable", IsRequired:=False, Order:=2)> _
    Public Property IdEmpleadoResponsable() As Integer
        Get
            Return m_IdEmpleadoResponsable
        End Get
        Set(value As Integer)
            m_IdEmpleadoResponsable = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Departamento", IsRequired:=False, Order:=3)> _
    Public Property Departamento() As Departamento
        Get
            Return m_departamento
        End Get
        Set(value As Departamento)
            m_departamento = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Provincia", IsRequired:=False, Order:=4)> _
    Public Property Provincia() As Provincia
        Get
            Return m_provincia
        End Get
        Set(value As Provincia)
            m_provincia = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Distrito", IsRequired:=False, Order:=5)> _
    Public Property Distrito() As Distrito
        Get
            Return m_distrito
        End Get
        Set(value As Distrito)
            m_distrito = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="CodigoSucursal", IsRequired:=False, Order:=6)> _
    Public Property CodigoSucursal() As String
        Get
            Return m_CodigoSucursal
        End Get
        Set(value As String)
            m_CodigoSucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="CodigoUbigeo", IsRequired:=False, Order:=7)> _
    Public Property CodigoUbigeo() As String
        Get
            Return m_CodigoUbigeo
        End Get
        Set(value As String)
            m_CodigoUbigeo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=8)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=9)> _
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(value As String)
            m_DescripcionCorta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Direccion", IsRequired:=False, Order:=10)> _
    Public Property Direccion() As String
        Get
            Return m_Direccion
        End Get
        Set(value As String)
            m_Direccion = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Telefono", IsRequired:=False, Order:=11)> _
    Public Property Telefono() As String
        Get
            Return m_Telefono
        End Get
        Set(value As String)
            m_Telefono = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=12)> _
    Public Property FechaDesde() As DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(value As DateTime)
            m_FechaDesde = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=13)> _
    Public Property FechaHasta() As DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(value As DateTime)
            m_FechaHasta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=14)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(value As Boolean)
            m_Activo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Zona", IsRequired:=False, Order:=15)> _
    Public Property Zona() As ZonaMantenimiento
        Get
            Return m_zona
        End Get
        Set(value As ZonaMantenimiento)
            m_zona = value
        End Set
    End Property

End Class
