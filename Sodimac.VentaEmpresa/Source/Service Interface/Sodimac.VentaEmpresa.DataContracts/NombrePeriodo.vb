Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="NombrePeriodo")> _
Public Class NombrePeriodo
    Private m_IdPeriodo As Integer
    Private m_NombrePeriodo As String
    Private m_Estado As Integer

    <WcfSerialization.DataMember(Name:="IdPeriodo", IsRequired:=False, Order:=0)> _
    Public Property IdPeriodo() As Integer
        Get
            Return m_IdPeriodo
        End Get
        Set(ByVal value As Integer)
            m_IdPeriodo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombrePeriodo", IsRequired:=False, Order:=1)> _
    Public Property NombrePeriodo() As String
        Get
            Return m_NombrePeriodo
        End Get
        Set(ByVal value As String)
            m_NombrePeriodo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=2)> _
    Public Property Estado() As Integer
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Integer)
            m_Estado = value
        End Set
    End Property

End Class
