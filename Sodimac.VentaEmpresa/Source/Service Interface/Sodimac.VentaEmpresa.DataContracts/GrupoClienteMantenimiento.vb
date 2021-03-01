Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="GrupoClienteMantenimiento")> _
Public Class GrupoClienteMantenimiento
    Private m_IdGrupoCliente As Integer
    Private m_IdGrupo As Integer
    Private m_IdCliente As Integer
    Private m_Grupo As Grupo
    Private m_ClienteVenta As ClienteVenta
    Private m_VentaCartera As VentaCartera
    Private m_Empleado As Empleado


    <WcfSerialization.DataMember(Name:="IdGrupoCliente", IsRequired:=False, Order:=0)> _
    Public Property IdGrupoCliente() As Integer
        Get
            Return m_IdGrupoCliente
        End Get
        Set(value As Integer)
            m_IdGrupoCliente = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdGrupo", IsRequired:=False, Order:=1)> _
    Public Property IdGrupo() As Integer
        Get
            Return m_IdGrupo
        End Get
        Set(value As Integer)
            m_IdGrupo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=2)> _
    Public Property IdCliente() As Integer
        Get
            Return m_IdCliente
        End Get
        Set(value As Integer)
            m_IdCliente = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Grupo", IsRequired:=False, Order:=3)> _
    Public Property Grupo() As Grupo
        Get
            Return m_Grupo
        End Get
        Set(value As Grupo)
            m_Grupo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="ClienteVenta", IsRequired:=False, Order:=4)> _
    Public Property ClienteVenta() As ClienteVenta
        Get
            Return m_ClienteVenta
        End Get
        Set(value As ClienteVenta)
            m_ClienteVenta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Empleado", IsRequired:=False, Order:=6)> _
    Public Property Empleado() As Empleado
        Get
            Return m_Empleado
        End Get
        Set(value As Empleado)
            m_Empleado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="VentaCartera", IsRequired:=False, Order:=5)> _
    Public Property VentaCartera() As VentaCartera
        Get
            Return m_VentaCartera
        End Get
        Set(value As VentaCartera)
            m_VentaCartera = value
        End Set
    End Property
End Class
