Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="UsuarioRol")> _
Public Class UsuarioRol
    Private m_rol As Rol
    Private m_usuario As Usuario

    <WcfSerialization.DataMember(Name:="Rol", IsRequired:=False, Order:=0)> _
    Public Property Rol() As Rol
        Get
            Return m_rol
        End Get
        Set(value As Rol)
            m_rol = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Usuario", IsRequired:=False, Order:=1)> _
    Public Property Usuario() As Usuario
        Get
            Return m_usuario
        End Get
        Set(value As Usuario)
            m_usuario = value
        End Set
    End Property
End Class
