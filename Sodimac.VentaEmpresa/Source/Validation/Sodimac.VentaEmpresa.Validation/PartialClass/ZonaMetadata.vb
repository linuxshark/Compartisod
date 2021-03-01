Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class ZonaMetadata
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreZona() As String
        Get
            Return m_nombreZona
        End Get
        Set(value As String)
            m_nombreZona = value
        End Set
    End Property
    Private m_nombreZona As String
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    Public Property IdZona() As Nullable(Of Integer)
        Get
            Return _IdZona
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _IdZona = value
        End Set
    End Property
    Private _IdZona As Integer
End Class
