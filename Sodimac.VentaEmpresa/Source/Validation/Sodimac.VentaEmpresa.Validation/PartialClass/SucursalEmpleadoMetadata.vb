Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Public Class SucursalEmpleadoMetadata

    Private m_FechaRegistro As Date
    Private _EscalaTiempoAsignado As Integer
   
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <RegularExpression("^(([0-9])|([0-2][0-9])|(3[0-1]))/(([1-9])|(0[1-9])|(1[0-2]))/(([0-9][0-9])|([1-2][0,9][0-9][0-9]))$", ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="FormatoIncorrecto")> _
    Public Property FechaRegistro() As Nullable(Of Date)
        Get
            Return m_FechaRegistro
        End Get
        Set(value As Nullable(Of Date))
            m_FechaRegistro = value
        End Set
    End Property
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    Public Property EscalaTiempoAsignado() As Integer
        Get
            Return _EscalaTiempoAsignado
        End Get
        Set(ByVal value As Integer)
            _EscalaTiempoAsignado = value
        End Set
    End Property

End Class
