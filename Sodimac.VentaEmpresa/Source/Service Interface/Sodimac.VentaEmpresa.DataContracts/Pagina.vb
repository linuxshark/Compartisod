Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Pagina")> _
Public Class Pagina
    Private m_idPagina As Integer
    Private m_nombrePagina As String
    Private m_urlPagina As String
    Private m_padrePagina As Integer
    Private m_nivelPagina As Integer
    Private m_activoPagina As Boolean
    Private m_visiblePagina As Integer
    Private m_urlImagePagina As String
    Private m_estadoPagina As String

    <WcfSerialization.DataMember(Name:="IdPagina", IsRequired:=False, Order:=0)> _
    Public Property IdPagina() As Integer
        Get
            Return m_idPagina
        End Get
        Set(value As Integer)
            m_idPagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombrePagina", IsRequired:=False, Order:=1)> _
    Public Property NombrePagina() As String
        Get
            Return m_nombrePagina
        End Get
        Set(value As String)
            m_nombrePagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="UrlPagina", IsRequired:=False, Order:=2)> _
    Public Property UrlPagina() As String
        Get
            Return m_urlPagina
        End Get
        Set(value As String)
            m_urlPagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PadrePagina", IsRequired:=False, Order:=3)> _
    Public Property PadrePagina() As Integer
        Get
            Return m_padrePagina
        End Get
        Set(value As Integer)
            m_padrePagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NivelPagina", IsRequired:=False, Order:=4)> _
    Public Property NivelPagina() As Integer
        Get
            Return m_nivelPagina
        End Get
        Set(value As Integer)
            m_nivelPagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ActivoPagina", IsRequired:=False, Order:=5)> _
    Public Property ActivoPagina() As Boolean
        Get
            Return m_activoPagina
        End Get
        Set(value As Boolean)
            m_activoPagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="VisiblePagina", IsRequired:=False, Order:=6)> _
    Public Property VisiblePagina() As Integer
        Get
            Return m_visiblePagina
        End Get
        Set(value As Integer)
            m_visiblePagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="UrlImagePagina", IsRequired:=False, Order:=7)> _
    Public Property UrlImagePagina() As String
        Get
            Return m_urlImagePagina
        End Get
        Set(value As String)
            m_urlImagePagina = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="EstadoPagina", IsRequired:=False, Order:=8)> _
    Public Property EstadoPagina() As String
        Get
            Return m_estadoPagina
        End Get
        Set(value As String)
            m_estadoPagina = value
        End Set
    End Property

End Class
