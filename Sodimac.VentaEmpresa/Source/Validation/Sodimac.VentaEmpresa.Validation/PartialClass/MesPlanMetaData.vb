Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class MesPlanMetaData
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    Public Property IdMes() As Nullable(Of Integer)
        Get
            Return m_IdMes
        End Get
        Set(value As Nullable(Of Integer))
            m_IdMes = value
        End Set
    End Property
    Private m_IdMes As Integer

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property OrdenMes() As String
        Get
            Return m_OrdenMes
        End Get
        Set(value As String)
            m_OrdenMes = value
        End Set
    End Property
    Private m_OrdenMes As String
End Class
