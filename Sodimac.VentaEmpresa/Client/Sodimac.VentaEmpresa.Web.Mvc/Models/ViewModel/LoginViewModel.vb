Imports System.ComponentModel.DataAnnotations
Imports Sodimac.VentaEmpresa.Validation.My.Resources

Public Class LoginViewModel
    <Display(Name:="Usuario")>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceName:="CampoRequerido", ErrorMessageResourceType:=GetType(Validaciones))>
    Property UserName As String

    <Display(Name:="Contraseña")>
    <Required(AllowEmptyStrings:=False, ErrorMessageResourceName:="CampoRequerido", ErrorMessageResourceType:=GetType(Validaciones))>
    Property Password As String

End Class
