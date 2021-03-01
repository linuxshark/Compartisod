Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports Sodimac.VentaEmpresa.Web.Mvc.VentasViewModel
Imports Sodimac.VentaEmpresa.Common
Imports System.Web.UI.WebControls
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports System.IO
Imports Newtonsoft.Json

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class ConfiguracionController
        Inherits BaseController

        <RequiresAuthenticationAttribute()> _
        <RequiresAuthorizationAttribute()> _
        Function BuscarParametro() As ActionResult
            Dim VM As New ConfiguracionViewModel
            Return View(VM)
        End Function

        <RequiresAuthenticationAttribute()> _
        Function BuscarParametroNegocio() As ActionResult
            Dim VM As New ConfiguracionViewModel
            VM.PagConfNegocio = UtilWebGrid.Paginacion_PorDefecto()
            VM.PagConfNegocio = New ConfiguracionBusinessLogic().Buscar_Parametros(VM.PagConfNegocio)
            Return PartialView(ParametrosView.ParametrosPartialView.BuscarParametroNegocio, VM)
        End Function

        <RequiresAuthenticationAttribute()> _
        Function GestionarParametro(Optional ByVal IdParametro As Integer = Constantes.ValorCero) As ActionResult
            Dim VM As New ConfiguracionViewModel
            VM.Parametro = New ConfiguracionBusinessLogic().ObtenerParametro(IdParametro)
            Return View(VM)
        End Function

        <ValidateAntiForgeryToken()>
        <RequiresAuthenticationAttribute()> _
        Function ActualizarParametro(Optional ByVal Data As String = Constantes.ValorDefecto) As ActionResult
            Dim Mensaje As String
            Dim jsonData
            Try
                Dim Parametro = JsonConvert.DeserializeObject(Of Parametro)(Data)
                Mensaje = New ConfiguracionBusinessLogic().Actualizar_Parametro(Parametro)

            Catch ex As Exception
                Mensaje = ex.Message
            End Try

            jsonData = New With
                {
                    .mensaje = Mensaje
                }
            Return Json(jsonData, JsonRequestBehavior.AllowGet)
        End Function

    End Class
End Namespace