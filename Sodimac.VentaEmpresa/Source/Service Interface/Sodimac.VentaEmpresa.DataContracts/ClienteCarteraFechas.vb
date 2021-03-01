Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteCarteraFechas")>
Public Class ClienteCarteraFechas
    Private m_IdFechaCartera As Integer
    Private m_Idcliente As Integer
    Private m_FechaInicio As DateTime
    Private m_FechaFin As DateTime
    Private m_FechaRegistro As DateTime
    Private m_Vigente As String

    <WcfSerialization.DataMember(Name:="IdFechaCartera", IsRequired:=False, Order:=0)>
    Public Property IdFechaCartera() As Integer
        Get
            Return m_IdFechaCartera
        End Get
        Set(ByVal value As Integer)
            m_IdFechaCartera = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Idcliente", IsRequired:=False, Order:=1)>
    Public Property Idcliente() As Integer
        Get
            Return m_Idcliente
        End Get
        Set(ByVal value As Integer)
            m_Idcliente = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaInicio", IsRequired:=False, Order:=2)>
    Public Property FechaInicio() As String
        Get
            Return m_FechaInicio
        End Get
        Set(ByVal value As String)
            m_FechaInicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaFin", IsRequired:=False, Order:=3)>
    Public Property FechaFin() As String
        Get
            Return m_FechaFin
        End Get
        Set(ByVal value As String)
            m_FechaFin = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=4)>
    Public Property FechaRegistro() As String
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As String)
            m_FechaRegistro = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Vigente", IsRequired:=False, Order:=5)>
    Public Property Vigente() As String
        Get
            Return m_Vigente
        End Get
        Set(ByVal value As String)
            m_Vigente = value
        End Set
    End Property

End Class
