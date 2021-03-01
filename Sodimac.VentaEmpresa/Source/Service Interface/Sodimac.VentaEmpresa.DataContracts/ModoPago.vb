Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ModoPago")> _
Public Class ModoPago


    Private m_IdModoPago As Int32

    <WcfSerialization.DataMember(Name:="IdModoPago", IsRequired:=False, Order:=0)> _
    Public Property IdModoPago() As Int32
        Get
            Return m_IdModoPago
        End Get
        Set(ByVal value As Int32)
            m_IdModoPago = value
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



End Class
