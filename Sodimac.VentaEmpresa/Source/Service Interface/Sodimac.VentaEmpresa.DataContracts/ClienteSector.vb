
Imports WcfSerialization = System.Runtime.Serialization
<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteSector")> _
Public Class ClienteSector
    Private m_IdClienteSector As Integer
    Private m_Descripcion As String
    Private m_DescripcionCorta As String
    Private m_FechaDesde As System.DateTime
    Private m_FechaHasta As System.DateTime
    Private m_activo As Boolean

    <WcfSerialization.DataMember(Name:="IdClienteSector", IsRequired:=False, Order:=0)> _
    Public Property IdClienteSector() As Integer
        Get
            Return m_IdClienteSector
        End Get
        Set(ByVal value As Integer)
            m_IdClienteSector = value
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
    <WcfSerialization.DataMember(Name:="FechaDesde", IsRequired:=False, Order:=3)> _
    Public Property FechaDesde() As System.DateTime
        Get
            Return m_FechaDesde
        End Get
        Set(ByVal value As System.DateTime)
            m_FechaDesde = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="FechaHasta", IsRequired:=False, Order:=4)> _
    Public Property FechaHasta() As System.DateTime
        Get
            Return m_FechaHasta
        End Get
        Set(ByVal value As System.DateTime)
            m_FechaHasta = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Activo", IsRequired:=False, Order:=4)> _
    Public Property Activo() As Boolean
        Get
            Return m_activo
        End Get
        Set(ByVal value As Boolean)
            m_activo = value
        End Set
    End Property

End Class
