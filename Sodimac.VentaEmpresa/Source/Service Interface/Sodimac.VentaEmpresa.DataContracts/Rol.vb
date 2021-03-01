Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Rol")> _
Public Class Rol
    Private m_idRol As Integer
    Private m_nombreRol As String
    Private m_activoRol As Boolean
    Private m_estadoId As Integer

    <WcfSerialization.DataMember(Name:="IdRol", IsRequired:=False, Order:=0)> _
    Public Property IdRol() As Integer
        Get
            Return m_idRol
        End Get
        Set(value As Integer)
            m_idRol = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreRol", IsRequired:=False, Order:=1)> _
    Public Property NombreRol() As String
        Get
            Return m_nombreRol
        End Get
        Set(value As String)
            m_nombreRol = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ActivoRol", IsRequired:=False, Order:=2)> _
    Public Property ActivoRol() As Boolean
        Get
            Return m_activoRol
        End Get
        Set(value As Boolean)
            m_activoRol = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="EstadoId", IsRequired:=False, Order:=3)> _
    Public Property EstadoId() As Integer
        Get
            Return m_estadoId
        End Get
        Set(value As Integer)
            m_estadoId = value
        End Set
    End Property
End Class
