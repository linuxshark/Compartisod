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
    Public Class AutorizacionController
        Inherits BaseController

        <RequiresAuthenticationAttribute()> _
        <RequiresAuthorizationAttribute()> _
        Function BuscarAsignacion() As ActionResult
            Dim BE As New ClienteBusinessLogic
            Dim VM As New AutorizacionesViewModel

            VM.ListaMotivo = BE.ListarMotivos()

            Return View(VM)
        End Function

        <RequiresAuthenticationAttribute()> _
        <RequiresAuthorizationAttribute()> _
        Function ConsultarAsignacion() As ActionResult
            Dim BE As New ClienteBusinessLogic
            Dim VM As New AutorizacionesViewModel


            VM.ListaMotivo = BE.ListarMotivos()
            VM.ListaModoPago = BE.ListaModoPago()
            VM.PaginacionContado = New Paginacion
            VM.PaginacionContado.ListaClienteVenta = New ListaClienteVenta
            Return View(VM)

        End Function
        <RequiresAuthenticationAttribute()> _
        Function BuscarContado(Optional ByVal sordir As String = Constantes.ValorDefecto,
                               Optional ByVal sort As String = Constantes.ValorDefecto,
                               Optional ByVal page As Integer = Constantes.ValorUno,
                               Optional ByVal RazonSocialRUc As String = Constantes.ValorDefecto,
                               Optional ByVal IdMotivo As String = Constantes.ValorDefecto,
                               Optional ByVal sRRVV As String = Constantes.ValorDefecto) As ActionResult
            Dim VM As New AutorizacionesViewModel
            Dim BE As New ClienteBusinessLogic

            VM.PaginacionContado = New Paginacion
            VM.PaginacionContado.PageNumber = page
            VM.PaginacionContado.SortType = sort
            VM.PaginacionContado.SortBy = sordir
            VM.PaginacionContado.PageSize = Constantes.RowsPerPage
            VM.PaginacionContado = BE.BuscarClienteXModoPago(Constantes.ValorDos, VM.PaginacionContado, RazonSocialRUc, IdMotivo, sRRVV)
            VM.PaginacionContado.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(VM.PaginacionContado.PageNumber, VM.PaginacionContado.PageSize, VM.PaginacionContado.TotalRows)
            Return PartialView(ParametrosView.ParametrosPartialView.BuscarContado, VM)
        End Function


        <RequiresAuthenticationAttribute()> _
        Function BuscarContado2(Optional ByVal sordir As String = Constantes.ValorDefecto,
                               Optional ByVal sort As String = Constantes.ValorDefecto,
                               Optional ByVal page As Integer = Constantes.ValorUno,
                               Optional ByVal RazonSocialRUc As String = Constantes.ValorDefecto,
                               Optional ByVal IdMotivo As String = Constantes.ValorDefecto,
                               Optional ByVal sRRVV_NombreEmpleado As String = Constantes.ValorDefecto,
                               Optional ByVal IdModoPago As Integer = Constantes.ValorCero) As ActionResult
            Dim VM As New AutorizacionesViewModel
            'Dim BE As New ClienteBusinessLogic
            If IdMotivo = "-TODOS-" Then
                IdMotivo = ""
            End If

            VM.PaginacionContado = New Paginacion
            VM.PaginacionContado.PageNumber = page
            VM.PaginacionContado.SortType = sort
            VM.PaginacionContado.SortBy = sordir
            VM.PaginacionContado.PageSize = Constantes.RowsPerPage

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "RazonSocialRUc:" & RazonSocialRUc.ToString() & "|IdMotivo:" & IdMotivo.ToString() & "|sRRVV_NombreEmpleado:" & sRRVV_NombreEmpleado.ToString() & "|IdModoPago:" & IdModoPago.ToString()
            Log.IdOrigenAccion = Constantes.Venta_Cliente
            Log.IdLogAccion = Constantes.Buscar
            Dim oComisionBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic(True, Log)

            VM.PaginacionContado = oComisionBusinessLogic.BuscarClienteXModoPago_C_Autorizacion(IdModoPago, VM.PaginacionContado, RazonSocialRUc, IdMotivo, sRRVV_NombreEmpleado)
            VM.PaginacionContado.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(VM.PaginacionContado.PageNumber, VM.PaginacionContado.PageSize, VM.PaginacionContado.TotalRows)
            Return PartialView(VM)
        End Function


        <RequiresAuthenticationAttribute()> _
        Function BuscarCredito(Optional ByVal sordir As String = Constantes.ValorDefecto,
                               Optional ByVal sort As String = Constantes.ValorDefecto,
                               Optional ByVal page As Integer = Constantes.ValorUno,
                               Optional ByVal RazonSocialRUc As String = Constantes.ValorDefecto,
                               Optional ByVal IdMotivo As String = Constantes.ValorDefecto,
                               Optional ByVal sRRVV As String = Constantes.ValorDefecto) As ActionResult
            Dim VM As New AutorizacionesViewModel
            Dim BE As New ClienteBusinessLogic

            VM.PaginacionCredito = New Paginacion
            VM.PaginacionCredito.PageNumber = page
            VM.PaginacionCredito.SortType = sort
            VM.PaginacionCredito.SortBy = sordir
            VM.PaginacionCredito.PageSize = Constantes.RowsPerPage
            VM.PaginacionCredito = BE.BuscarClienteXModoPago(Constantes.ValorUno, VM.PaginacionCredito, RazonSocialRUc, IdMotivo, sRRVV)
            VM.PaginacionCredito.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(VM.PaginacionCredito.PageNumber, VM.PaginacionCredito.PageSize, VM.PaginacionCredito.TotalRows)
            Return PartialView(ParametrosView.ParametrosPartialView.BuscarCredito, VM)
        End Function

        <ValidateAntiForgeryToken()> _
        <RequiresAuthenticationAttribute()> _
        Function AsignarCliente(Optional ByVal Data As String = Constantes.ValorDefecto) As ActionResult
            Dim Mensaje As String
            Dim jsonData
            Dim oClienteVenta As New ClienteVenta
            Dim Mensaje1 As String

            Try
                Dim Lista = JsonConvert.DeserializeObject(Of ListaAutorizaciones)(Data)
                Mensaje = New ClienteBusinessLogic().ActivarCliente(Lista)

                For Each A As Autorizaciones In Lista

                    oClienteVenta.RUC = A.RUC
                    oClienteVenta.IdModoPago = A.IdModoPago
                    oClienteVenta.RazonSocial = ""
                    oClienteVenta.IdAprobado = "8"
                    oClienteVenta.Anotacion = A.Anotacion
                    oClienteVenta.Motivo = A.Motivo
                    Mensaje1 = New ClienteBusinessLogic().InsertarCliente_HA(oClienteVenta)
                Next



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
