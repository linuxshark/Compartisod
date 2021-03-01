Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Security
Imports System.Web.Routing
Imports MvcSiteMapProvider

Namespace Filters

    Public Class RequiresAuthorizationAttribute
        Inherits ActionFilterAttribute
        'Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
        '    Dim isAccessibleToUser As Boolean = False

        '    If Not filterContext.HttpContext.Request.IsAuthenticated Then
        '        filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With { _
        '         Key .controller = "Home", _
        '         Key .action = "Index" _
        '        }))
        '    Else
        '        If SiteMap.CurrentNode IsNot Nothing Then
        '            isAccessibleToUser = DirectCast(SiteMap.Provider, DefaultSiteMapProvider).IsAccessibleToUser(HttpContext.Current, SiteMap.CurrentNode)
        '        End If

        '        If Not isAccessibleToUser Then
        '            filterContext.Result = New RedirectToRouteResult(New RouteValueDictionary(New With { _
        '             Key .controller = "Home", _
        '             Key .action = "Index" _
        '            }))
        '        End If
        '    End If

        '    MyBase.OnActionExecuting(filterContext)
        'End Sub

        Public Overrides Sub OnActionExecuting(filterContext As ActionExecutingContext)
            Dim isAccessibleToUser As [Boolean] = False

            If SiteMaps.Current.CurrentNode IsNot Nothing Then
                isAccessibleToUser = SiteMaps.Current.CurrentNode.IsAccessibleToUser()
            End If
            If Not isAccessibleToUser Then

                filterContext.Result = RedirectResultTo.Redirect(New RouteValueDictionary(New With { _
                 Key .controller = "Account", _
                 Key .action = "LogOn" _
                }), filterContext)
            End If

            MyBase.OnActionExecuting(filterContext)
        End Sub

    End Class

End Namespace

