Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Grupo")> _
<MetadataType(GetType(Validation.GrupoMantenimientoMetadata))> _
Public Class Grupo
    Private m_IdGrupo As Nullable(Of Integer)
    Private m_NombreGrupo As String
    Private m_Activo As Boolean
    Private m_ClienteVenta As ClienteVenta
    Private m_VentaCartera As VentaCartera
    Private m_Empleado As Empleado
    Private m_GrupoClienteMantenimiento As GrupoClienteMantenimiento


    <WcfSerialization.DataMember(Name:="IdGrupo", IsRequired:=False, Order:=0)> _
    Public Property IdGrupo() As Nullable(Of Integer)
        Get
            Return m_IdGrupo
        End Get
        Set(value As Nullable(Of Integer))
            m_IdGrupo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="NombreGrupo", IsRequired:=False, Order:=1)> _
    Public Property NombreGrupo() As String
        Get
            Return m_NombreGrupo
        End Get
        Set(value As String)
            m_NombreGrupo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=2)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ClienteVenta", IsRequired:=False, Order:=3)> _
    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_ClienteVenta
        End Get
        Set(value As ClienteVenta)
            m_ClienteVenta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=4)> _
    Public Property IdCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
    Private _idCliente As Integer

    <WcfSerialization.DataMember(Name:="VentaCartera", IsRequired:=False, Order:=5)> _
    Public Property VentaCartera() As VentaCartera
        Get
            Return m_VentaCartera
        End Get
        Set(value As VentaCartera)
            m_VentaCartera = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="VentaCartera", IsRequired:=False, Order:=6)> _
    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(ByVal value As Empleado)
            m_Empleado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="GrupoClienteMantenimiento", IsRequired:=False, Order:=7)> _
    Public Property GrupoClienteMantenimiento() As GrupoClienteMantenimiento
        Get
            Return m_GrupoClienteMantenimiento
        End Get
        Set(ByVal value As GrupoClienteMantenimiento)
            m_GrupoClienteMantenimiento = value
        End Set
    End Property


End Class
