Imports WcfSerialization = System.Runtime.Serialization
Imports System.ComponentModel.DataAnnotations

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Empresa")>
<MetadataType(GetType(Validation.EmpresaMetadata))>
Partial Public Class Empresa
    Public m_IdEmpresa As Integer
    Public m_NomEmpresa As String
    Public m_DirEmpresa As String
    Public m_NumRuc As String
    Public m_Telefono As String
    Public m_FlagActivo As Boolean



    <WcfSerialization.DataMember(Name:="IdEmpresa", IsRequired:=False, Order:=0)>
    Public Property IdEmpresa() As Integer
        Get
            Return m_IdEmpresa
        End Get
        Set(value As Integer)
            m_IdEmpresa = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NomEmpresa", IsRequired:=False, Order:=1)>
    Public Property NomEmpresa() As String
        Get
            Return m_NomEmpresa
        End Get
        Set(value As String)
            m_NomEmpresa = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DirEmpresa", IsRequired:=False, Order:=2)>
    Public Property DirEmpresa() As String
        Get
            Return m_DirEmpresa
        End Get
        Set(value As String)
            m_DirEmpresa = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="NumRuc", IsRequired:=False, Order:=3)>
    Public Property NumRuc() As String
        Get
            Return m_NumRuc
        End Get
        Set(value As String)
            m_NumRuc = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Telefono", IsRequired:=False, Order:=4)>
    Public Property Telefono() As String
        Get
            Return m_Telefono
        End Get
        Set(value As String)
            m_Telefono = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="FlagActivo", IsRequired:=False, Order:=5)>
    Public Property FlagActivo() As Boolean
        Get
            Return m_FlagActivo
        End Get
        Set(value As Boolean)
            m_FlagActivo = value
        End Set
    End Property


End Class
