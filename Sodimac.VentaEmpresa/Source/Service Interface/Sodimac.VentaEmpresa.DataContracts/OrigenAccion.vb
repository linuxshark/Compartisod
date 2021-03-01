Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="OrigenAccion")> _
Public Class OrigenAccion
    Private m_IdOrigenAccion As Int32

    <WcfSerialization.DataMember(Name:="IdOrigenAccion", IsRequired:=False, Order:=0)> _
    Public Property IdOrigenAccion() As Int32
        Get
            Return m_IdOrigenAccion
        End Get
        Set(ByVal value As Int32)
            m_IdOrigenAccion = value
        End Set
    End Property

    Private m_Esquema As String

    <WcfSerialization.DataMember(Name:="Esquema", IsRequired:=False, Order:=1)> _
    Public Property Esquema() As String
        Get
            Return m_Esquema
        End Get
        Set(ByVal value As String)
            m_Esquema = value
        End Set
    End Property

    Private m_Descripcion As String

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=2)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(ByVal value As String)
            m_Descripcion = value
        End Set
    End Property

    Private m_Estado As Boolean

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=3)> _
    Public Property Estado() As Boolean
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Boolean)
            m_Estado = value
        End Set
    End Property

    Private m_EsqDesc As String

    <WcfSerialization.DataMember(Name:="EsqDesc", IsRequired:=False, Order:=4)> _
    Public Property EsqDesc() As String
        Get
            Return m_EsqDesc
        End Get
        Set(ByVal value As String)
            m_EsqDesc = value
        End Set
    End Property

End Class
