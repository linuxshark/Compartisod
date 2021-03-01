
Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations
<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Motivo")> _
Public Class Motivo

    Private m_IdMotivo As Integer
    Private m_Descripcion As String

    <WcfSerialization.DataMember(Name:="IdMotivo", IsRequired:=False, Order:=0)> _
    Public Property IdMotivo() As Integer
        Get
            Return m_IdMotivo
        End Get
        Set(ByVal value As Integer)
            m_IdMotivo = value
        End Set
    End Property


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
