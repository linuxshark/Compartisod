Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources
Public Class EmpresaMetadata

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))>
    Public Property NomEmpresa() As String
        Get
            Return m_NomEmpresa
        End Get
        Set(value As String)
            m_NomEmpresa = value
        End Set
    End Property
    Private m_NomEmpresa As String

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")>
    Public Property IdEmpresa() As Nullable(Of Integer)
        Get
            Return m_IdEmpresa
        End Get
        Set(ByVal value As Nullable(Of Integer))
            m_IdEmpresa = value
        End Set
    End Property
    Private m_IdEmpresa As Integer

End Class
