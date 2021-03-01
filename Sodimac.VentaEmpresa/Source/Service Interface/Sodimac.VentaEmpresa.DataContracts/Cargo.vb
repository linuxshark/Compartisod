Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Cargo")> _
<MetadataType(GetType(Validation.CargoMetadata))> _
Public Class Cargo
    Private m_idCargo As Integer
    Private m_Perfil As Perfil
    Private m_PerfilSuperior As Perfil
    Private m_idCargoSuperior As Integer
    Private m_nombreCargo As String
    Private m_nombreCargoSuperior As String
    Private m_comisiona As Boolean
    Private m_activoCargo As Boolean
    Private m_zona As ZonaMantenimiento
    Private m_nombreCargoInferior As String



    <WcfSerialization.DataMember(Name:="IdCargo", IsRequired:=False, Order:=0)> _
    Public Property IdCargo() As Nullable(Of Integer)
        Get
            Return m_idCargo
        End Get
        Set(value As Nullable(Of Integer))
            m_idCargo = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Perfil", IsRequired:=False, Order:=1)> _
    Public Property Perfil() As Perfil
        Get
            Return m_Perfil
        End Get
        Set(value As Perfil)
            m_Perfil = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdCargoSuperior", IsRequired:=False, Order:=2)> _
    Public Property IdCargoSuperior() As Nullable(Of Integer)
        Get
            Return m_idCargoSuperior
        End Get
        Set(value As Nullable(Of Integer))
            m_idCargoSuperior = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreCargo", IsRequired:=False, Order:=3)> _
    Public Property NombreCargo() As String
        Get
            Return m_nombreCargo
        End Get
        Set(value As String)
            m_nombreCargo = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="Comisiona", IsRequired:=False, Order:=4)> _
    Public Property Comisiona() As Boolean
        Get
            Return m_comisiona
        End Get
        Set(value As Boolean)
            m_comisiona = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="ActivoCargo", IsRequired:=False, Order:=5)> _
    Public Property ActivoCargo() As Boolean
        Get
            Return m_activoCargo
        End Get
        Set(value As Boolean)
            m_activoCargo = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Zona", IsRequired:=False, Order:=6)> _
    Public Property Zona() As ZonaMantenimiento
        Get
            Return m_zona
        End Get
        Set(value As ZonaMantenimiento)
            m_zona = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreCargoSuperior", IsRequired:=False, Order:=7)> _
    Public Property NombreCargoSuperior() As String
        Get
            Return m_nombreCargoSuperior
        End Get
        Set(value As String)
            m_nombreCargoSuperior = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="PerfilSuperior", IsRequired:=False, Order:=8)> _
    Public Property PerfilSuperior() As Perfil
        Get
            Return m_PerfilSuperior
        End Get
        Set(value As Perfil)
            m_PerfilSuperior = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NombreCargoInferior", IsRequired:=False, Order:=9)> _
    Public Property NombreCargoInferior() As String
        Get
            Return m_nombreCargoInferior
        End Get
        Set(value As String)
            m_nombreCargoInferior = value
        End Set
    End Property
End Class
