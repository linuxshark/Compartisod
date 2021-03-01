Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Estructura.Provincia")> _
Public Class EmpleadoProvincia
    Private m_IdProvincia As Integer
    Private m_IdDepartamento As Integer
    Private m_CodigoProvincia As String
    Private m_DescripcionProv As String

    <WcfSerialization.DataMember(Name:="IdProvincia", IsRequired:=False, Order:=0)> _
    Public Property IdProvincia() As Integer
        Get
            Return m_IdProvincia
        End Get
        Set(ByVal value As Integer)
            m_IdProvincia = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="IdDepartamento", IsRequired:=False, Order:=1)> _
    Public Property IdDepartamento() As Integer
        Get
            Return m_IdDepartamento
        End Get
        Set(ByVal value As Integer)
            m_IdDepartamento = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="CodigoProvincia", IsRequired:=False, Order:=2)> _
    Public Property CodigoProvincia() As String
        Get
            Return m_CodigoProvincia
        End Get
        Set(ByVal value As String)
            m_CodigoProvincia = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=3)> _
    Public Property DescripcionProv() As String
        Get
            Return m_DescripcionProv
        End Get
        Set(ByVal value As String)
            m_DescripcionProv = value
        End Set
    End Property
End Class
