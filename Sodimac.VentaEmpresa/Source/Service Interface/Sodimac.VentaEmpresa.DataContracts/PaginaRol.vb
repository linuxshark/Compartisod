Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="PaginaRol")> _
Public Class PaginaRol
    Private m_rol As Rol
    Private m_pagina As Pagina

    <WcfSerialization.DataMember(Name:="Rol", IsRequired:=False, Order:=0)> _
    Public Property Rol() As Rol
        Get
            Return m_rol
        End Get
        Set(value As Rol)
            m_rol = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Pagina", IsRequired:=False, Order:=1)> _
    Public Property Pagina() As Pagina
        Get
            Return m_pagina
        End Get
        Set(value As Pagina)
            m_pagina = value
        End Set
    End Property
End Class
