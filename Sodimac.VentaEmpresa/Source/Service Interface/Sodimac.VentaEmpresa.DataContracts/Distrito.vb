Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Distrito")> _
Public Class Distrito

    Private m_IdDistrito As Integer
    Private m_CodigoDistrito As String
    Private m_Descripcion As String
    Private m_Provincia As Provincia

    <WcfSerialization.DataMember(Name:="IdDistrito", IsRequired:=False, Order:=0)> _
    Public Property IdDistrito() As Integer
        Get
            Return m_IdDistrito
        End Get
        Set(value As Integer)
            m_IdDistrito = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="CodigoDistrito", IsRequired:=False, Order:=1)> _
    Public Property CodigoDistrito() As String
        Get
            Return m_CodigoDistrito
        End Get
        Set(value As String)
            m_CodigoDistrito = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=2)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Provincia", IsRequired:=False, Order:=3)> _
    Public Property Provincia() As Provincia
        Get
            Return m_Provincia
        End Get
        Set(value As Provincia)
            m_Provincia = value
        End Set
    End Property
End Class
