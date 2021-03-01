Imports System.Threading.Tasks
Imports System.Web.Mvc
Imports System.Web.Routing
Imports System.Web.Security
Imports MvcSiteMapProvider

Public Class RedirectResultTo

    Public Shared Function Redirect(route As RouteValueDictionary, context As ActionExecutingContext) As ActionResult


        If context.HttpContext.Request.IsAjaxRequest() Then
            Dim url As New UrlHelper(context.RequestContext)

            Dim result As New JavaScriptResult
            result.Script = "window.location = '" + url.Action(Nothing, route) + "';"
            Return result
        Else
            Dim result As ActionResult
            result = New RedirectToRouteResult(route)
            Return result
        End If
    End Function




End Class
