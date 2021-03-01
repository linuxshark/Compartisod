Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Parametro")> _
Public Class Parametro
    Private m_IdParametro As Integer
    Private m_IdParametroTipo As Integer
    Private m_IdArea As Integer
    Private m_CodigoParametro As String
    Private m_Parametro As String
    Private m_Descripcion As String
    Private m_Descripcion1 As String
    Private m_Valor1 As String
    Private m_Descripcion2 As String
    Private m_Valor2 As String
    Private m_Descripcion3 As String
    Private m_Valor3 As String
    Private m_FechaDesde As DateTime
    Private m_FechaHasta As DateTime
    Private m_Activo As Boolean

    <WcfSerialization.DataMember(Name:="IdParametro", IsRequired:=False, Order:=0)> _
    Public Property IdParametro() As Integer
        Get
            Return m_IdParametro
        End Get
        Set(value As Integer)
            m_IdParametro = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdParametroTipo", IsRequired:=False, Order:=1)> _
    Public Property IdParametroTipo() As Integer
        Get
            Return m_IdParametroTipo
        End Get
        Set(value As Integer)
            m_IdParametroTipo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdArea", IsRequired:=False, Order:=2)> _
    Public Property IdArea() As Integer
        Get
            Return m_IdArea
        End Get
        Set(value As Integer)
            m_IdArea = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CodigoParametro", IsRequired:=False, Order:=3)> _
    Public Property CodigoParametro() As String
        Get
            Return m_CodigoParametro
        End Get
        Set(value As String)
            m_CodigoParametro = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Parametro", IsRequired:=False, Order:=4)> _
    Public Property Parametro() As String
        Get
            Return m_Parametro
        End Get
        Set(value As String)
            m_Parametro = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=5)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion1", IsRequired:=False, Order:=6)> _
    Public Property Descripcion1() As String
        Get
            Return m_Descripcion1
        End Get
        Set(value As String)
            m_Descripcion1 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Valor1", IsRequired:=False, Order:=7)> _
    Public Property Valor1() As String
        Get
            Return m_Valor1
        End Get
        Set(value As String)
            m_Valor1 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion2", IsRequired:=False, Order:=8)> _
    Public Property Descripcion2() As String
        Get
            Return m_Descripcion2
        End Get
        Set(value As String)
            m_Descripcion2 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Valor2", IsRequired:=False, Order:=9)> _
    Public Property Valor2() As String
        Get
            Return m_Valor2
        End Get
        Set(value As String)
            m_Valor2 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion3", IsRequired:=False, Order:=10)> _
    Public Property Descripcion3() As String
        Get
            Return m_Descripcion3
        End Get
        Set(value As String)
            m_Descripcion3 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Valor3", IsRequired:=False, Order:=11)> _
    Public Property Valor3() As String
        Get
            Return m_Valor3
        End Get
        Set(value As String)
            m_Valor3 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=12)> _
    Public Property FechaDesde() As DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(value As DateTime)
            m_FechaDesde = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=13)> _
    Public Property FechaHasta() As DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(value As DateTime)
            m_FechaHasta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=14)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(value As Boolean)
            m_Activo = value
        End Set
    End Property

End Class
