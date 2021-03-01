Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Autorizaciones")> _
Public Class Autorizaciones

    Private m_IdAprobaciones As Integer
    <WcfSerialization.DataMember(Name:="IdAprobaciones", IsRequired:=False, Order:=0)> _
    Public Property IdAprobaciones() As Integer
        Get
            Return m_IdAprobaciones
        End Get
        Set(ByVal value As Integer)
            m_IdAprobaciones = value
        End Set
    End Property

    Private m_Fecha As DateTime
    <WcfSerialization.DataMember(Name:="Fecha", IsRequired:=False, Order:=1)> _
    Public Property Fecha() As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal value As DateTime)
            m_Fecha = value
        End Set
    End Property

    Private m_IdCliente As Integer
    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=2)> _
    Public Property IdCliente() As Integer
        Get
            Return m_IdCliente
        End Get
        Set(ByVal value As Integer)
            m_IdCliente = value
        End Set
    End Property

    Private m_Motivo As String
    <WcfSerialization.DataMember(Name:="Motivo", IsRequired:=False, Order:=3)> _
    Public Property Motivo() As String
        Get
            Return m_Motivo
        End Get
        Set(ByVal value As String)
            m_Motivo = value
        End Set
    End Property


    Private m_IdModoPago As Integer
    <WcfSerialization.DataMember(Name:="IdModoPago", IsRequired:=False, Order:=4)> _
    Public Property IdModoPago() As Integer
        Get
            Return m_IdModoPago
        End Get
        Set(ByVal value As Integer)
            m_IdModoPago = value
        End Set
    End Property


    Private m_Anotacion As String
    <WcfSerialization.DataMember(Name:="Anotacion", IsRequired:=False, Order:=5)> _
    Public Property Anotacion() As String
        Get
            Return m_Anotacion
        End Get
        Set(ByVal value As String)
            m_Anotacion = value
        End Set
    End Property

    Private m_Activo As Boolean
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=6)> _
    Public Property Activo() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property

    Private m_RUC As String
    <WcfSerialization.DataMember(Name:="RUC", IsRequired:=False, Order:=7)> _
    Public Property RUC() As String
        Get
            Return m_RUC
        End Get
        Set(ByVal value As String)
            m_RUC = value
        End Set
    End Property


End Class
