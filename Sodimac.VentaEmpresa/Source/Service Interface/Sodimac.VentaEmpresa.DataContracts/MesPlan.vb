Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="MesPlan")> _
<MetadataType(GetType(Validation.MesPlanMetaData))> _
Public Class MesPlan

    Private m_IdMes As Integer
    Private m_OrdenMes As String

    <WcfSerialization.DataMember(Name:="IdMes", IsRequired:=False, Order:=0)> _
    Public Property IdMes() As Integer
        Get
            Return m_IdMes
        End Get
        Set(value As Integer)
            m_IdMes = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="OrdenMes", IsRequired:=False, Order:=1)> _
    Public Property OrdenMes() As String
        Get
            Return m_OrdenMes
        End Get
        Set(value As String)
            m_OrdenMes = value
        End Set
    End Property

End Class
