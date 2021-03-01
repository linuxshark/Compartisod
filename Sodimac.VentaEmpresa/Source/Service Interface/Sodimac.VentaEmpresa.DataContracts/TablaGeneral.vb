Imports WcfSerialization = System.Runtime.Serialization


<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac")> _
Public Class TablaGeneral
    Private m_idTabGen As Integer
    Private m_tablaGrupo As TablaGrupo
    Private m_ordenTabGen As Integer
    Private m_descripcionTabGen As String
    Private m_activoTabGen As Boolean
    Private m_descripcionLargaTabGen As String

    <WcfSerialization.DataMember(Name:="IdTabGen", IsRequired:=False, Order:=0)> _
    Public Property IdTabGen() As Integer
        Get
            Return m_idTabGen
        End Get
        Set(value As Integer)
            m_idTabGen = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TablaGrupo", IsRequired:=False, Order:=1)> _
    Public Property TablaGrupo() As TablaGrupo
        Get
            Return m_tablaGrupo
        End Get
        Set(value As TablaGrupo)
            m_tablaGrupo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="OrdenTabGen", IsRequired:=False, Order:=2)> _
    Public Property OrdenTabGen() As Integer
        Get
            Return m_ordenTabGen
        End Get
        Set(value As Integer)
            m_ordenTabGen = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionTabGen", IsRequired:=False, Order:=3)> _
    Public Property DescripcionTabGen() As String
        Get
            Return m_descripcionTabGen
        End Get
        Set(value As String)
            m_descripcionTabGen = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ActivoTabGen", IsRequired:=False, Order:=4)> _
    Public Property ActivoTabGen() As Boolean
        Get
            Return m_activoTabGen
        End Get
        Set(value As Boolean)
            m_activoTabGen = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionLargaTabGen", IsRequired:=False, Order:=5)> _
    Public Property DescripcionLargaTabGen() As String
        Get
            Return m_descripcionLargaTabGen
        End Get
        Set(value As String)
            m_descripcionLargaTabGen = value
        End Set
    End Property
End Class
