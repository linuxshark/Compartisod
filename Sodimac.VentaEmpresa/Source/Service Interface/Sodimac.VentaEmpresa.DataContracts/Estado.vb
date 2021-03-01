Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
Public Class Estado
    Private m_IdEstado As Integer
    Private m_IdObjeto As Integer
    Private m_Codigo As String
    Private m_Descripcion As String
    Private m_DescripcionCorta As String
    Private m_Activo As Boolean

    <WcfSerialization.DataMember(Name:="IdEstado", IsRequired:=False, Order:=0)> _
    Public Property IdEstado() As Integer
        Get
            Return m_IdEstado
        End Get
        Set(value As Integer)
            m_IdEstado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdObjeto", IsRequired:=False, Order:=1)> _
    Public Property IdObjeto() As Integer
        Get
            Return m_IdObjeto
        End Get
        Set(value As Integer)
            m_IdObjeto = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Codigo", IsRequired:=False, Order:=2)> _
    Public Property Codigo() As String
        Get
            Return m_Codigo
        End Get
        Set(value As String)
            m_Codigo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=3)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=4)> _
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(value As String)
            m_DescripcionCorta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=5)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(value As Boolean)
            m_Activo = value
        End Set
    End Property
End Class
