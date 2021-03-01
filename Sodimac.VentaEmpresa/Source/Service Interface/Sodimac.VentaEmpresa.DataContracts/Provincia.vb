Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Provincia")> _
Public Class Provincia

    Private m_IdProvincia As Integer
    Private m_CodigoProvincia As String
    Private m_Descripcion As String
    Private m_Departamento As Departamento

    <WcfSerialization.DataMember(Name:="IdProvincia", IsRequired:=False, Order:=0)> _
    Public Property IdProvincia() As String
        Get
            Return m_IdProvincia
        End Get
        Set(value As String)
            m_IdProvincia = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="CodigoProvincia", IsRequired:=False, Order:=1)> _
    Public Property CodigoProvincia() As String
        Get
            Return m_CodigoProvincia
        End Get
        Set(value As String)
            m_CodigoProvincia = value
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
    <WcfSerialization.DataMember(Name:="Departamento", IsRequired:=False, Order:=3)> _
    Public Property Departamento() As Departamento
        Get
            Return m_Departamento
        End Get
        Set(value As Departamento)
            m_Departamento = value
        End Set
    End Property
End Class
