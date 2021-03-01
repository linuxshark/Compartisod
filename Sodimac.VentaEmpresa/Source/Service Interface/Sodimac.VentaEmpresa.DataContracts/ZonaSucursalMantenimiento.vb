Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ZonaSucursalMantenimiento")> _
Public Class ZonaSucursalMantenimiento
    Private m_idZonaSucursal As Integer
    Private m_idZona As Integer
    Private m_idSucursal As Integer
    Private m_ZonaMantenimiento As ZonaMantenimiento
    Private m_isNacional As Boolean

    <WcfSerialization.DataMember(Name:="IdZonaSucursal", IsRequired:=False, Order:=0)> _
    Public Property IdZonaSucursal() As Integer
        Get
            Return m_idZonaSucursal
        End Get
        Set(value As Integer)
            m_idZonaSucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=1)> _
    Public Property IdZona() As Integer
        Get
            Return m_idZona
        End Get
        Set(value As Integer)
            m_idZona = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdSucursal", IsRequired:=False, Order:=2)> _
    Public Property IdSucursal() As Integer
        Get
            Return m_idSucursal
        End Get
        Set(value As Integer)
            m_idSucursal = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="ZonaMantenimiento", IsRequired:=False, Order:=3)> _
    Public Property ZonaMantenimiento() As ZonaMantenimiento
        Get
            Return m_ZonaMantenimiento
        End Get
        Set(value As ZonaMantenimiento)
            m_ZonaMantenimiento = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IsNacional", IsRequired:=False, Order:=3)> _
    Public Property IsNacional() As Boolean
        Get
            Return m_isNacional
        End Get
        Set(value As Boolean)
            m_isNacional = value
        End Set
    End Property
End Class
