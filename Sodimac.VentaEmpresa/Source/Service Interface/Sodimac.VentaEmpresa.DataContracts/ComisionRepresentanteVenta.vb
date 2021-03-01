Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Comision.ComisionEscala")> _
Public Class ComisionRepresentanteVenta
    Private m_IdComisionEscala As Integer
    Private m_TiempoServicio As Integer

    <WcfSerialization.DataMember(Name:="IdComisionEscala", IsRequired:=False, Order:=0)> _
    Public Property IdComisionEscala() As Integer
        Get
            Return m_IdComisionEscala
        End Get
        Set(value As Integer)
            m_IdComisionEscala = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="TiempoServicio", IsRequired:=False, Order:=1)> _
    Public Property TiempoServicio() As Integer
        Get
            Return m_TiempoServicio
        End Get
        Set(value As Integer)
            m_TiempoServicio = value
        End Set
    End Property




End Class
