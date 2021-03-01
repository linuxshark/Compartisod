Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class TipoRepresentanteVentaMetaData

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    Public Property IdTipoRepVen() As Nullable(Of Integer)
        Get
            Return m_IdTipoRepVen
        End Get
        Set(value As Nullable(Of Integer))
            m_IdTipoRepVen = value
        End Set
    End Property
    Private m_IdTipoRepVen As Integer

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreTipoRepVen() As String
        Get
            Return m_NombreTipoRepVen
        End Get
        Set(value As String)
            m_NombreTipoRepVen = value
        End Set
    End Property
    Private m_NombreTipoRepVen As String

End Class
