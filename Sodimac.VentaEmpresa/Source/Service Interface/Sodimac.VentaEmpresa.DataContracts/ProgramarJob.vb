Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ProgramarJob")> _
Public Class ProgramarJob

    Private m_idProg As Integer
    Private m_fechaProg As System.DateTime
    Private m_horaProg As System.TimeSpan
    'Private m_periodo As Periodo
    'Private m_usuario As Usuario

    <WcfSerialization.DataMember(Name:="IdProg", IsRequired:=False, Order:=0)> _
    Public Property IdProg() As Integer
        Get
            Return m_idProg
        End Get
        Set(value As Integer)
            m_idProg = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaProg", IsRequired:=False, Order:=1)> _
    Public Property FechaProg() As System.DateTime
        Get
            Return m_fechaProg
        End Get
        Set(value As System.DateTime)
            m_fechaProg = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="HoraProg", IsRequired:=False, Order:=2)> _
    Public Property HoraProg() As System.TimeSpan
        Get
            Return m_horaProg
        End Get
        Set(value As System.TimeSpan)
            m_horaProg = value
        End Set
    End Property

   
End Class
