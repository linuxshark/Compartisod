Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Security
Imports System.Web.Routing
Imports MvcSiteMapProvider

Namespace Filters

    Public Class RequiresAuthenticationAttribute
        Inherits ActionFilterAttribute

        Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
            If filterContext.HttpContext.Request.IsAjaxRequest() Then
                If (Not filterContext.HttpContext.Request.IsAuthenticated) Or (HttpContext.Current.Session("Usuario") Is Nothing) Then
                    Dim result As New JavaScriptResult() With {
                        .Script = "window.location='" & "/Account/LogOn" & "';"
                    }

                    filterContext.Result = result
                End If
            Else
                If Not filterContext.HttpContext.Request.IsAuthenticated Or (HttpContext.Current.Session("Usuario") Is Nothing) Then
                    filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With { _
                     Key .controller = "Account", _
                     Key .action = "LogOn" _
                    }))
                End If
            End If
            'If filterContext.HttpContext.Session IsNot Nothing Then
            '    If filterContext.HttpContext.Session.IsNewSession Then
            '        Dim sessionCookie = filterContext.HttpContext.Request.Headers("Cookie")
            '        If (sessionCookie IsNot Nothing) AndAlso (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0) Then
            '            filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With { _
            '             Key .controller = "Account", _
            '             Key .action = "LogOn" _
            '            }))
            '            MyBase.OnActionExecuting(filterContext)
            '            Exit Sub
            '        End If
            '    End If
            'End If

            'If Not filterContext.HttpContext.Request.IsAuthenticated Then
            '    filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With { _
            '     Key .controller = "Account", _
            '     Key .action = "LogOn" _
            '    }))
            'End If

            MyBase.OnActionExecuting(filterContext)
        End Sub
    End Class

End Namespace