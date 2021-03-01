Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class PerfilMetadata
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombrePerfil() As String
        Get
            Return m_nombrePerfil
        End Get
        Set(value As String)
            m_nombrePerfil = value
        End Set
    End Property
    Private m_nombrePerfil As String
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    <StringLength(100, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombrePerfilInferior() As String
        Get
            Return m_nombrePerfilMenor
        End Get
        Set(value As String)
            m_nombrePerfilMenor = value
        End Set
    End Property
    Private m_nombrePerfilMenor As String
    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
    Public Property IdPerfil() As Nullable(Of Integer)
        Get
            Return _IdPerfil
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _IdPerfil = value
        End Set
    End Property
    Private _IdPerfil As Integer

End Class
