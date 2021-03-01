Imports System.Web
Imports System.Web.Mvc
Imports System.Data.Common

Public Class FilterConfig
    Public Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute() With {.ExceptionType = GetType(DbException), .View = "~/Views/PageError", .Order = 2})
        filters.Add(New HandleErrorAttribute())
    End Sub
End Class