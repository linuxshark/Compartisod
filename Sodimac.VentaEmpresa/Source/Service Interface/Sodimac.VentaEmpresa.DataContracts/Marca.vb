Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Marca")>
Public Class Marca
    <WcfSerialization.DataMember(Name:="idMarca", IsRequired:=False, Order:=0)>
    Public Property IdMarca As Integer

    <WcfSerialization.DataMember(Name:="NomMarca", IsRequired:=False, Order:=0)>
    Public Property NomMarca As String
End Class
