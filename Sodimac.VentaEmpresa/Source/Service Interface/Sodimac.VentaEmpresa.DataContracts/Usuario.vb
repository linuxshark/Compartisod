Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Usuario")>
Public Class Usuario
    Private m_idUsu As Integer
    Private m_usuarioUsu As String
    Private m_activoUsu As Integer
    Private m_usuarioNom As String
    Private m_passwordUsu As String
    Private m_rol As Rol
    Private m_fechaSesion As DateTime
    Private m_empleado As Empleado
    Private m_estado As String

    <WcfSerialization.DataMember(Name:="IdUsu", IsRequired:=False, Order:=0)>
    Public Property IdUsu() As Integer
        Get
            Return m_idUsu
        End Get
        Set(value As Integer)
            m_idUsu = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="UsuarioUsu", IsRequired:=False, Order:=1)>
    Public Property UsuarioUsu() As String
        Get
            Return m_usuarioUsu
        End Get
        Set(value As String)
            m_usuarioUsu = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ActivoUsu", IsRequired:=False, Order:=2)>
    Public Property ActivoUsu() As Integer
        Get
            Return m_activoUsu
        End Get
        Set(value As Integer)
            m_activoUsu = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="UsuarioNom", IsRequired:=False, Order:=3)>
    Public Property UsuarioNom() As String
        Get
            Return m_usuarioNom
        End Get
        Set(value As String)
            m_usuarioNom = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PasswordUsu", IsRequired:=False, Order:=4)>
    Public Property PasswordUsu() As String
        Get
            Return m_passwordUsu
        End Get
        Set(value As String)
            m_passwordUsu = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Rol", IsRequired:=False, Order:=5)>
    Public Property Rol() As Rol
        Get
            Return m_rol
        End Get
        Set(ByVal value As Rol)
            m_rol = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaSesion", IsRequired:=False, Order:=6)>
    Public Property FechaSesion() As DateTime
        Get
            Return m_fechaSesion
        End Get
        Set(ByVal value As DateTime)
            m_fechaSesion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Empleado", IsRequired:=False, Order:=7)>
    Public Property Empleado() As Empleado
        Get
            Return m_empleado
        End Get
        Set(ByVal value As Empleado)
            m_empleado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=8)>
    Public Property Estado() As String
        Get
            Return m_estado
        End Get
        Set(ByVal value As String)
            m_estado = value
        End Set
    End Property

End Class
