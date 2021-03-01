Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Accion")> _
Public Class Accion

    Private m_IdOperacion As Integer
    Private m_Descripcion As String
    Private m_DescripcionCorta As String
    Private m_Etiqueta As String
    Private m_ToolTip As String
    Private m_CodigoHTML As String
    Private m_Activo As Boolean

    <WcfSerialization.DataMember(Name:="IdOperacion", IsRequired:=False, Order:=0)> _
    Public Property IdOperacion() As Integer
        Get
            Return m_IdOperacion
        End Get
        Set(ByVal value As Integer)
            m_IdOperacion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=1)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(ByVal value As String)
            m_Descripcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=2)> _
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(ByVal value As String)
            m_DescripcionCorta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Etiqueta", IsRequired:=False, Order:=3)> _
    Public Property Etiqueta() As String
        Get
            Return m_Etiqueta
        End Get
        Set(ByVal value As String)
            m_Etiqueta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ToolTip", IsRequired:=False, Order:=4)> _
    Public Property ToolTip() As String
        Get
            Return m_ToolTip
        End Get
        Set(ByVal value As String)
            m_ToolTip = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CodigoHTML", IsRequired:=False, Order:=5)> _
    Public Property CodigoHTML() As String
        Get
            Return m_CodigoHTML
        End Get
        Set(ByVal value As String)
            m_CodigoHTML = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=6)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property

End Class
