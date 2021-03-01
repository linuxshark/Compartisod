Imports WcfSerialization = System.Runtime.Serialization

<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="EmpleadoCargo")> _
Public Class EmpleadoCargo

    Private m_IdEmpleadoCargo As Integer
    Private m_DescripcionCargo As String
    Private m_Estado As Boolean
    Private m_EmpleadoPerfil As EmpleadoPerfil
    '<WcfSerialization.DataMember(Name:="IdEmpleadoCargo", IsRequired:=False, Order:=0)> _
    <WcfSerialization.DataMember(Name:="IdCargo", IsRequired:=False, Order:=0)> _
    Public Property IdEmpleadoCargo() As Integer
        Get
            Return m_IdEmpleadoCargo
        End Get
        Set(ByVal value As Integer)
            m_IdEmpleadoCargo = value
        End Set
    End Property


    '<WcfSerialization.DataMember(Name:="Descripcion", IsRequired:=False, Order:=1)> _
    <WcfSerialization.DataMember(Name:="NombreCargo", IsRequired:=False, Order:=1)> _
    Public Property DescripcionCargo() As String
        Get
            Return m_DescripcionCargo
        End Get
        Set(ByVal value As String)
            m_DescripcionCargo = value
        End Set
    End Property


    <WcfSerialization.DataMember(Name:="Estado", IsRequired:=False, Order:=2)> _
    Public Property Estado() As Boolean
        Get
            Return m_Estado
        End Get
        Set(ByVal value As Boolean)
            m_Estado = value
        End Set
    End Property

    <WcfSerialization.DataMember(Name:="EmpleadoPerfil", IsRequired:=False, Order:=3)> _
    Public Property EmpleadoPerfil() As EmpleadoPerfil
        Get
            Return m_EmpleadoPerfil
        End Get
        Set(ByVal value As EmpleadoPerfil)
            m_EmpleadoPerfil = value
        End Set
    End Property




End Class

