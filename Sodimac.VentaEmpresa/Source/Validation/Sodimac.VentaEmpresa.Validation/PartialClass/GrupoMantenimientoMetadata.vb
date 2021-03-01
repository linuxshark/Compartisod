Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class GrupoMantenimientoMetadata

    Private _NombreGrupo As String
    Private _IdCliente As Integer


    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="CampoRequeridoCustom")> _
   <StringLength(40, MinimumLength:=3, ErrorMessageResourceName:="LongitudCadena", ErrorMessageResourceType:=GetType(Validaciones))> _
    Public Property NombreGrupo() As String
        Get
            Return _NombreGrupo
        End Get
        Set(value As String)
            _NombreGrupo = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Validaciones), ErrorMessageResourceName:="SeleccionNecesaria")> _
    Public Property IdCliente() As Integer
        Get
            Return _IdCliente
        End Get
        Set(value As Integer)
            _IdCliente = value
        End Set
    End Property

End Class
