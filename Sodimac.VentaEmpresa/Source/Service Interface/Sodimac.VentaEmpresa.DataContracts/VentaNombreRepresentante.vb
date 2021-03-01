Imports WcfSerialization = System.Runtime.Serialization
<WcfSerialization.DataContract([Namespace]:="http://Sodimac.VentaEmpresa.Model/2013/DCSodimac", Name:="Estructura.Empleado")> _
Public Class VentaNombreRepresentante

    Private m_IdEmpleado As Integer
    Private m_NombresApellidos As String

    <WcfSerialization.DataMember(Name:="IdEmpleado", IsRequired:=False, Order:=0)> _
    Public Property IdEmpleado() As Integer
        Get
            Return m_IdEmpleado
        End Get
        Set(value As Integer)
            m_IdEmpleado = value
        End Set
    End Property
    <WcfSerialization.DataMember(Name:="NombresApellidos", IsRequired:=False, Order:=1)> _
    Public Property NombresApellidos() As String
        Get
            Return m_NombresApellidos
        End Get
        Set(value As String)
            m_NombresApellidos = value
        End Set
    End Property

End Class
