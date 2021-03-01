Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="HistorialReprocesoVenta")> _
Public Class Reproceso

    Private m_descripcionEmplePer As EmpleadoPerfil


    Private m_IdReproceso As Integer
    Private m_IdZona As String
    Private m_Sucursal As Sucursal
    Private m_FechaInicio As Date
    Private m_FechaFin As Date


    <WcfSerialization.DataMember(Name:="IdReproceso", IsRequired:=False, Order:=0)> _
    Public Property IdReproceso() As Integer
        Get
            Return m_IdReproceso
        End Get
        Set(value As Integer)
            m_IdReproceso = value
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
    <WcfSerialization.DataMember(Name:="IdZona", IsRequired:=False, Order:=2)> _
    Public Property Sucursal() As Sucursal
        Get
            Return m_Sucursal
        End Get
        Set(value As Sucursal)
            m_Sucursal = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="FechaIni", IsRequired:=False, Order:=3)> _
    Public Property FechaInicio() As Date
        Get
            Return m_FechaInicio
        End Get
        Set(value As Date)
            m_FechaInicio = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaFin", IsRequired:=False, Order:=4)> _
    Public Property FechaFin() As Date
        Get
            Return m_FechaFin
        End Get
        Set(value As Date)
            m_FechaFin = value
        End Set
    End Property

End Class
