Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Error")> _
Partial Public Class [Error]
    Private m_gUID As System.Guid
    Private m_mensaje As String

    <WcfSerialization.DataMember(Name:="GUID", IsRequired:=False, Order:=0)> _
    Public Property GUID() As System.Guid
        Get
            Return m_gUID
        End Get
        Set(value As System.Guid)
            m_gUID = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Mensaje", IsRequired:=False, Order:=1)> _
    Public Property Mensaje() As String
        Get
            Return m_mensaje
        End Get
        Set(value As String)
            m_mensaje = value
        End Set
    End Property
End Class


