Imports WebMatrix.WebData
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters

Public Class HomeController
    Inherits BaseController

    <RequiresAuthenticationAttribute()>
    Function Index() As ActionResult
        Return View()
    End Function

    <RequiresAuthenticationAttribute()>
    Function Controles() As ActionResult
        Return View()
    End Function

    Function PageError() As ActionResult
        'Dim exception As Exception = HttpContext.AllErrors.Last()
        'Dim oHandleErrorInfo As New System.Web.Mvc.HandleErrorInfo(exception, "Home", "PageError")
        'Return View(oHandleErrorInfo)
        Return View()
    End Function

    <RequiresAuthenticationAttribute()> _
    <RequiresAuthorizationAttribute()> _
    Function MapaSitio() As ActionResult
        Return View()
    End Function
End Class
