Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Estructura.Departamento")> _
Public Class EmpleadoDepartamento
    Private m_IdDepartamento As Integer
    Private m_CodigoDepartamento As String
    Private m_Descripcion As String
    <WcfSerialization.DataMember(Name:="IdDepartamento", IsRequired:=False, Order:=0)> _
    Public Property IdDepartamento() As Integer
        Get
            Return m_IdDepartamento
        End Get
        Set(ByVal value As Integer)
            m_IdDepartamento = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="CodigoDepartamento", IsRequired:=False, Order:=1)> _
    Public Property CodigoDepartamento() As String
        Get
            Return m_CodigoDepartamento
        End Get
        Set(ByVal value As String)
            m_CodigoDepartamento = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=2)> _
    Public Property DescripcionDepa() As String
        Get
            Return m_Descripcion
        End Get
        Set(ByVal value As String)
            m_Descripcion = value
        End Set
    End Property


End Class
