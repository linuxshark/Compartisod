
Imports WcfSerialization = System.Runtime.Serialization
<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteContacto")> _
Public Class ClienteContacto
    Private m_IdContacto As Integer
    Private m_IdCargoTipo As Integer
    Private m_Nombres As String
    Private m_Apellidos As String
    Private m_Telefono As String
    Private m_Email As String
    Private m_Cargo As String
    Private m_IdEstadoActual As Integer
    Private m_FechaDesde As System.DateTime
    Private m_FechaHasta As System.DateTime
    Private m_FechaNacimiento As System.DateTime
    Private m_activo As Boolean
    Private m_IdCliente As Integer
    Private m_IdContactoClase As Integer
    Private m_Fax As String
    Private m_Celular1 As String
    Private m_Celular2 As String
    Private m_ContactoTipo As Integer
    Private m_TipoContancto As ContactoTipo
    Private m_ClaseContacto As ContactoClase

    Public Property TipoContancto() As ContactoTipo
        Get
            Return m_TipoContancto
        End Get
        Set(ByVal value As ContactoTipo)
            m_TipoContancto = value
        End Set
    End Property

    Public Property ClaseContacto() As ContactoClase
        Get
            Return m_ClaseContacto
        End Get
        Set(ByVal value As ContactoClase)
            m_ClaseContacto = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="IdContacto", IsRequired:=False, Order:=0)> _
    Public Property IdContacto() As Integer
        Get
            Return m_IdContacto
        End Get
        Set(ByVal value As Integer)
            m_IdContacto = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCargoTipo", IsRequired:=False, Order:=1)> _
    Public Property IdCargoTipo() As Integer
        Get
            Return m_IdCargoTipo
        End Get
        Set(ByVal value As Integer)
            m_IdCargoTipo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Nombres", IsRequired:=False, Order:=2)> _
    Public Property Nombres() As String
        Get
            Return m_Nombres
        End Get
        Set(ByVal value As String)
            m_Nombres = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Apellidos", IsRequired:=False, Order:=3)> _
    Public Property Apellidos() As String
        Get
            Return m_Apellidos
        End Get
        Set(ByVal value As String)
            m_Apellidos = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Telefono", IsRequired:=False, Order:=4)> _
    Public Property Telefono() As String
        Get
            Return m_Telefono
        End Get
        Set(ByVal value As String)
            m_Telefono = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Email", IsRequired:=False, Order:=5)> _
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            m_Email = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdEstadoActual", IsRequired:=False, Order:=6)> _
    Public Property IdEstadoActual() As Integer
        Get
            Return m_IdEstadoActual
        End Get
        Set(ByVal value As Integer)
            m_IdEstadoActual = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=7)> _
    Public Property FechaDesde() As System.DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(ByVal value As System.DateTime)
            m_FechaDesde = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=8)> _
    Public Property FechaHasta() As System.DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(ByVal value As System.DateTime)
            m_FechaHasta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=9)> _
    Public Property Activo() As Boolean
        Get
            Return m_activo
        End Get
        Set(ByVal value As Boolean)
            m_activo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=10)> _
    Public Property IdCliente() As Integer
        Get
            Return m_IdCliente
        End Get
        Set(ByVal value As Integer)
            m_IdCliente = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Cargo", IsRequired:=False, Order:=11)> _
    Public Property Cargo() As String
        Get
            Return m_Cargo
        End Get
        Set(ByVal value As String)
            m_Cargo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaNacimiento", IsRequired:=False, Order:=12)> _
    Public Property FechaNacimiento() As DateTime
        Get
            Return m_FechaNacimiento
        End Get
        Set(ByVal value As DateTime)
            m_FechaNacimiento = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdContactoClase", IsRequired:=False, Order:=13)> _
    Public Property IdContactoClase() As Integer
        Get
            Return m_IdContactoClase
        End Get
        Set(ByVal value As Integer)
            m_IdContactoClase = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Fax", IsRequired:=False, Order:=14)> _
    Public Property Fax() As String
        Get
            Return m_Fax
        End Get
        Set(ByVal value As String)
            m_Fax = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Celular1", IsRequired:=False, Order:=15)> _
    Public Property Celular1() As String
        Get
            Return m_Celular1
        End Get
        Set(ByVal value As String)
            m_Celular1 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Celular2", IsRequired:=False, Order:=16)> _
    Public Property Celular2() As String
        Get
            Return m_Celular2
        End Get
        Set(ByVal value As String)
            m_Celular2 = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ContactoTipo", IsRequired:=False, Order:=17)> _
    Public Property ContactoTipo() As Integer
        Get
            Return m_ContactoTipo
        End Get
        Set(ByVal value As Integer)
            m_ContactoTipo = value
        End Set
    End Property

End Class
