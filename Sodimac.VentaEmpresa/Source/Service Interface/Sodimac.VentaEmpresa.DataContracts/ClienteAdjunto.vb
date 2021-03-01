Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="ClienteAdjunto")> _
<MetadataType(GetType(Validation.ClienteAdjuntoMetadata))> _
Public Class ClienteAdjunto
    Private m_idAdj As Integer
    Private m_idCliente As Integer
    Private m_nombreAdj As String
    Private m_nombreAdjTemp As String
    Private m_tipoContenidoAdj As String
    Private m_tamanioAdj As Long
    Private m_RutaAdj As String
    Private m_activoAdj As Boolean


    <WcfSerialization.DataMember(Name:="IdCliente", IsRequired:=False, Order:=0)> _
    Public Property IdCliente() As Integer
        Get
            Return m_idCliente
        End Get
        Set(ByVal value As Integer)
            m_idCliente = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="IdAdj", IsRequired:=False, Order:=1)> _
    Public Property IdAdj() As Integer
        Get
            Return m_idAdj
        End Get
        Set(value As Integer)
            m_idAdj = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreAdj", IsRequired:=False, Order:=2)> _
    Public Property NombreAdj() As String
        Get
            Return m_nombreAdj
        End Get
        Set(value As String)
            m_nombreAdj = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreTemp", IsRequired:=False, Order:=3)> _
    Public Property NombreTemp() As String
        Get
            Return m_nombreAdjTemp
        End Get
        Set(value As String)
            m_nombreAdjTemp = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TipoContenidoAdj", IsRequired:=False, Order:=2)> _
    Public Property TipoContenidoAdj() As String
        Get
            Return m_tipoContenidoAdj
        End Get
        Set(value As String)
            m_tipoContenidoAdj = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="TamanioAdj", IsRequired:=False, Order:=4)> _
    Public Property TamanioAdj() As Long
        Get
            Return m_tamanioAdj
        End Get
        Set(value As Long)
            m_tamanioAdj = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DatoAdj", IsRequired:=False, Order:=5)> _
    Public Property RutaAdj() As String
        Get
            Return m_RutaAdj
        End Get
        Set(value As String)
            m_RutaAdj = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FechaRegistro", IsRequired:=False, Order:=6)> _
    Public Property FechaRegistro() As Date
        Get
            Return _FechaRegistro
        End Get
        Set(value As Date)
            _FechaRegistro = value
        End Set
    End Property
    Private _FechaRegistro As Date

    <WcfSerialization.DataMember(Name:="ActivoAdj", IsRequired:=False, Order:=7)> _
    Public Property ActivoAdj() As Boolean
        Get
            Return m_activoAdj
        End Get
        Set(value As Boolean)
            m_activoAdj = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Tamanio", IsRequired:=False, Order:=8)> _
    Public Property Tamanio() As Decimal
        Get
            Return m_tamanio
        End Get
        Set(value As Decimal)
            m_tamanio = value
        End Set
    End Property
    Private m_tamanio
End Class
