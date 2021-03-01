Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="VentaCliente")> _
Public Class VentaCliente

    Private _RazonSocial As String
    <WcfSerialization.DataMember(Name:="RazonSocial", IsRequired:=False, Order:=0)> _
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property


End Class
