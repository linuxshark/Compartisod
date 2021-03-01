Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Familia")>
Public Class Familia
    Private m_codigoFamilia As String
    Private m_nombreFamilia As String

    <WcfSerialization.DataMember(Name:="CodigoFamilia", IsRequired:=True, Order:=0)>
    Public Property CodigoFamilia As String
        Get
            Return m_codigoFamilia
        End Get
        Set(value As String)
            m_codigoFamilia = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreFamilia", IsRequired:=False, Order:=1)>
    Public Property NombreFamilia As String
        Get
            Return m_nombreFamilia
        End Get
        Set(value As String)
            m_nombreFamilia = value
        End Set
    End Property
End Class
