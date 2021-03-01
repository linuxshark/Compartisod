Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Departamento")> _
Public Class Departamento

    Private m_IdDepartamento As Integer
    Private m_IdZona As Integer
    Private m_CodigoDepartamento As String
    Private m_Descripcion As String

    <WcfSerialization.DataMember(Name:="IdDepartamento", IsRequired:=False, Order:=0)> _
    Public Property IdDepartamento() As Integer
        Get
            Return m_IdDepartamento
        End Get
        Set(value As Integer)
            m_IdDepartamento = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=1)> _
    Public Property IdZona() As Integer
        Get
            Return m_IdZona
        End Get
        Set(value As Integer)
            m_IdZona = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="CodigoDepartamento", IsRequired:=False, Order:=2)> _
    Public Property CodigoDepartamento() As String
        Get
            Return m_CodigoDepartamento
        End Get
        Set(value As String)
            m_CodigoDepartamento = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=3)> _
    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

End Class
