Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="TipoCaja")>
Public Class TipoCaja

    <WcfSerialization.DataMember(Name:="IdTipoCaja", IsRequired:=False, Order:=0)>
    Public Property IdTipoCaja() As Integer
        Get
            Return _idTipoCaja
        End Get
        Set(ByVal value As Integer)
            _idTipoCaja = value

        End Set
    End Property

    Private _idTipoCaja As Integer

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=1)>
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)

            _descripcion = value

        End Set
    End Property

    Private _descripcion As String

End Class
