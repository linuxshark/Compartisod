Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="LogAccion")> _
Public Class LogAccion
    Private m_IdLogAccion As Int32

    <WcfSerialization.DataMember(Name:="IdLogAccion", IsRequired:=False, Order:=0)> _
    Public Property IdLogAccion() As Int32
        Get
            Return m_IdLogAccion
        End Get
        Set(ByVal value As Int32)
            m_IdLogAccion = value
        End Set
    End Property

    Private m_Descripcion As String

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=1)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(ByVal value As String)
            m_Descripcion = value
        End Set
    End Property

    Private m_DescripcionCorta As String

    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=2)> _
    Public Property DescripcionCorta() As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(ByVal value As String)
            m_DescripcionCorta = value
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

End Class
