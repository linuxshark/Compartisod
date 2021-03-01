Imports System.Web.Security
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing
Imports MvcSiteMapProvider.DefaultSiteMapProvider
Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc.ServicioSeguridad
Imports Sodimac.VentaEmpresa.Web.Seguridad
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports Sodimac.VentaEmpresa.Common
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic

Public Class SucursalController
    Inherits BaseController

    <RequiresAuthenticationAttribute()>
    Function BuscarSucursal(Optional page As Integer = 1,
                               Optional sort As String = "",
                               Optional sortdir As String = "") As ActionResult

        Dim oSucursalesViewModel As New SucursalesViewModel()
        Dim oVentasBusinessLogic As New SucursalesBusinessLogic()

        oSucursalesViewModel.Paginacion = New Paginacion()
        oSucursalesViewModel.Paginacion.Sucursal = New Sucursal()
        oSucursalesViewModel.Paginacion.ListaSucursal = New ListaSucursal()

        'oVentasViewModel.ListaSucursal = oVentasBusinessLogic.ListarSucursalHistorico()

        oSucursalesViewModel.Paginacion.SortType = sortdir
        oSucursalesViewModel.Paginacion.SortBy = sort
        oSucursalesViewModel.Paginacion.PageSize = 10
        oSucursalesViewModel.Paginacion.PageNumber = page

        oSucursalesViewModel.Paginacion = oVentasBusinessLogic.ListarSucursalHistorico(oSucursalesViewModel.Paginacion)

        oSucursalesViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
             oSucursalesViewModel.Paginacion.PageNumber,
             oSucursalesViewModel.Paginacion.PageSize,
             oSucursalesViewModel.Paginacion.TotalRows
         )
        Return View(oSucursalesViewModel)

    End Function
End Class
