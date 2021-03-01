Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports Sodimac.VentaEmpresa.Web.Mvc.NoCacheAttribute

<NoCacheAttribute()> _
Public Class BaseController
    Inherits Controller
    Public Function RedirectJSEnviarPagina(actiondestino As String, controllerdestino As String) As RedirectResult
        Return Redirect(Url.Action(actiondestino, controllerdestino))
    End Function

    Protected Overrides Function Redirect(url As String) As RedirectResult
        Return New AjaxAwareRedirectResult(url)
    End Function

    Public Class AjaxAwareRedirectResult
        Inherits RedirectResult
        Public Sub New(url As String)
            MyBase.New(url)
        End Sub

        Public Overrides Sub ExecuteResult(context As ControllerContext)
            If context.RequestContext.HttpContext.Request.IsAjaxRequest() Then
                Dim destinationUrl As String = UrlHelper.GenerateContentUrl(Url, context.HttpContext)
                Dim result As New JavaScriptResult()
                result.Script = "window.location='" & destinationUrl & "';"
                result.ExecuteResult(context)
            Else
                MyBase.ExecuteResult(context)
            End If
        End Sub
    End Class
End Class

