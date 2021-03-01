Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Public Class NoCacheAttribute 
    Inherits ActionFilterAttribute

    Public Overrides Sub OnResultExecuting(filterContext As ResultExecutingContext)
        filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1))
        filterContext.HttpContext.Response.Cache.SetValidUntilExpires(False)
        filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches)
        filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        filterContext.HttpContext.Response.Cache.SetNoStore()
        MyBase.OnResultExecuting(filterContext)
    End Sub

End Class

