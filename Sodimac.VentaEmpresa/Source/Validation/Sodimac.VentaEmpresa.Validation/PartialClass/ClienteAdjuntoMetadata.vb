Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class ClienteAdjuntoMetadata
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreTemp() As String
        Get
            Return m_nombreAdjTemp
        End Get
        Set(value As String)
            m_nombreAdjTemp = value
        End Set
    End Property
    Private m_nombreAdjTemp As String
End Class
