Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="TipoDocumento")>
Public Class TipoDocumento
    Private m_IdTipoDocumento As Integer
    Private m_Descripcion As String
    Private m_DescripcionCorta As String
    Private m_Activo As Boolean
    
     <WcfSerialization.DataMember(Name:="IdTipoDocumento", IsRequired:=False, Order:=0)> _
    Public Property IdTipoDocumento As Integer
        Get
            Return m_IdTipoDocumento
        End Get
        Set(value As Integer)
            m_IdTipoDocumento = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=1)> _
    Public Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="DescripcionCorta", IsRequired:=False, Order:=2)> _
     Public Property DescripcionCorta As String
        Get
            Return m_DescripcionCorta
        End Get
        Set(value As String)
            m_DescripcionCorta = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=3)> _
    Public Property Estado() As Boolean
        Get
            Return m_Activo
        End Get
        Set(ByVal value As Boolean)
            m_Activo = value
        End Set
    End Property

    Public Property Activo As Boolean
        Get
            Return m_Activo
        End Get
        Set(value As Boolean)
            m_Activo = value
        End Set
    End Property
End Class
