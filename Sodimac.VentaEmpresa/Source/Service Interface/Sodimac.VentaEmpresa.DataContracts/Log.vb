Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Log")> _
Public Class Log
    Private m_IdLog As Integer
    Private m_Fecha As DateTime
    Private m_Usuario As String
    Private m_Administrador As Boolean
    Private m_IdLogAccion As Integer
    Private m_IdOrigenAccion As Integer
    Private m_TiempoNavegacion As String
    Private m_NombrePc As String
    Private m_MACPc As String
    Private m_DescripcionAccion As String

    <WcfSerialization.DataMember(Name:="IdLog", IsRequired:=False, Order:=0)> _
    Public Property IdLog() As Integer
        Get
            Return m_IdLog
        End Get
        Set(ByVal value As Integer)
            m_IdLog = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Fecha", IsRequired:=False, Order:=1)> _
    Public Property Fecha() As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal value As DateTime)
            m_Fecha = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Usuario", IsRequired:=False, Order:=2)> _
    Public Property Usuario() As String
        Get
            Return m_Usuario
        End Get
        Set(ByVal value As String)
            m_Usuario = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Administrador", IsRequired:=False, Order:=3)> _
    Public Property Administrador() As Boolean
        Get
            Return m_Administrador
        End Get
        Set(ByVal value As Boolean)
            m_Administrador = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdLogAccion", IsRequired:=False, Order:=4)> _
    Public Property IdLogAccion() As Integer
        Get
            Return m_IdLogAccion
        End Get
        Set(ByVal value As Integer)
            m_IdLogAccion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="IdOrigenAccion", IsRequired:=False, Order:=5)> _
    Public Property IdOrigenAccion() As Integer
        Get
            Return m_IdOrigenAccion
        End Get
        Set(ByVal value As Integer)
            m_IdOrigenAccion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TiempoNavegacion", IsRequired:=False, Order:=6)> _
    Public Property TiempoNavegacion() As String
        Get
            Return m_TiempoNavegacion
        End Get
        Set(ByVal value As String)
            m_TiempoNavegacion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombrePc", IsRequired:=False, Order:=7)> _
    Public Property NombrePc() As String
        Get
            Return m_NombrePc
        End Get
        Set(ByVal value As String)
            m_NombrePc = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="MACPc", IsRequired:=False, Order:=8)> _
    Public Property MACPc() As String
        Get
            Return m_MACPc
        End Get
        Set(ByVal value As String)
            m_MACPc = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionAccion", IsRequired:=False, Order:=9)> _
    Public Property DescripcionAccion() As String
        Get
            Return m_DescripcionAccion
        End Get
        Set(ByVal value As String)
            m_DescripcionAccion = value
        End Set
    End Property

End Class