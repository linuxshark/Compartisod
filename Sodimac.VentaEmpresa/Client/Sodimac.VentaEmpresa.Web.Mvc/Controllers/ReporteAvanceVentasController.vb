Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.Common
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports System.Globalization
Imports System.IO
Imports System.Web.Helpers
Imports Microsoft.Reporting.WebForms
Imports System.Net
Imports System.Net.Mime

Public Class ReporteAvanceVentasController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /ReporteAvanceVentas

    Function Index() As ActionResult
        Dim oReporteViewModel As New ReporteViewModel
        Dim oReporteBusinessLogic As New ReporteBusinessLogic
        Dim usuarioUsu As String = Session("User")
        oReporteViewModel.ListaAvanceVentas = oReporteBusinessLogic.ListarAvanceVentas(usuarioUsu, Constantes.ValorDefecto, Constantes.ValorDefecto, Constantes.ValorDefecto, Constantes.ValorDefecto)
        oReporteViewModel.FechaInicio = Date.Now
        oReporteViewModel.FechaFin = Date.Now
        Return View(oReporteViewModel)
    End Function

    <RequiresAuthenticationAjaxAttribute()>
    Function _ComboMultiSucursal(Optional IdZonaCadena As String = Constantes.ValorDefecto, Optional FechaIni As String = Constantes.ValorDefecto,
                                      Optional FechaFin As String = Constantes.ValorDefecto) As ActionResult

        Dim oReporteViewModel As New ReporteViewModel
        Dim oReporteBusinessLogic As New ReporteBusinessLogic
        oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
        oReporteViewModel.ListaAvanceVentas = New ListaAvanceVentas()
        oReporteViewModel.ListaAvanceVentas.ListaSucursal = oReporteBusinessLogic.BuscarSucursal(IdZonaCadena, Session("User"), FechaIni, FechaFin)

        Return PartialView(ParametrosView.ParametrosPartialView.PartialSucursalAv, oReporteViewModel)
    End Function

    <RequiresAuthenticationAttribute()>
    Function _ComboJefeRegional(Optional FechaIni As String = Constantes.ValorDefecto,
                                Optional FechaFin As String = Constantes.ValorDefecto,
                                Optional idZona As String = Constantes.ValorDefecto,
                                Optional SubGerente As String = Constantes.ValorDefecto) As ActionResult
        Dim usuarioUsu As String = Session("User")
        Dim oReporteViewModel As New ReporteViewModel
        Dim oReporteBusinessLogic As New ReporteBusinessLogic
        oReporteViewModel.ListaAvanceVentas = New ListaAvanceVentas()
        oReporteViewModel.ListaAvanceVentas.ListaJefeVenta = New ListaEmpleado()
        oReporteViewModel.ListaAvanceVentas.ListaJefeVenta = oReporteBusinessLogic.BuscarJefeRegionalAvanceVenta(usuarioUsu, SubGerente, idZona)
        oReporteViewModel.JefeCadena = String.Join(",", CType(oReporteViewModel.ListaAvanceVentas.ListaJefeVenta, List(Of Empleado)).Select(Function(i) i.IdEmpleado.ToString()))
        If (oReporteViewModel.JefeCadena = "") Then
            oReporteViewModel.JefeCadena = "-1"
        End If

        Return PartialView(ParametrosView.ParametrosPartialView.PartialJefeVenta, oReporteViewModel)


    End Function

    <RequiresAuthenticationAttribute()>
    Function _ComboRRVV(Optional jefe As String = Constantes.ValorDefecto, Optional FechaIni As String = Constantes.ValorDefecto,
                                      Optional FechaFin As String = Constantes.ValorDefecto) As ActionResult
        Dim usuarioUsu As String = Session("User")
        Dim oReporteViewModel As New ReporteViewModel
        Dim oReporteBusinessLogic As New ReporteBusinessLogic()
        oReporteViewModel.ListaAvanceVentas = New ListaAvanceVentas()
        oReporteViewModel.ListaAvanceVentas.ListaRrvv = oReporteBusinessLogic.ListarVendedores(usuarioUsu, jefe, FechaIni, FechaFin)

        Return PartialView(ParametrosView.ParametrosPartialView.PartialVendedor, oReporteViewModel)
    End Function

    <HttpPost()>
    <RequiresAuthenticationAttribute()>
    Function GenerarReporte(Optional fechaInicio As String = Constantes.ValorDefecto,
                            Optional fechaFin As String = Constantes.ValorDefecto,
                            Optional zona As String = Constantes.ValorDefecto,
                            Optional sucursal As String = Constantes.ValorDefecto,
                            Optional subGerente As String = Constantes.ValorDefecto,
                            Optional jefeVenta As String = Constantes.ValorDefecto,
                            Optional rrvv As String = Constantes.ValorDefecto) As ActionResult


        Dim oReporteViewModel As New ReporteViewModel
        oReporteViewModel.FechaInicio = New DateTime(Convert.ToDateTime(fechaFin).Year, Convert.ToDateTime(fechaFin).Month, 1)
        oReporteViewModel.FechaInicio = oReporteViewModel.FechaInicio.ToString("dd'/'MM'/'yyyy")
        oReporteViewModel.FechaFin = fechaFin
        If subGerente = String.Empty Then
            oReporteViewModel.TipoSubGerente = 0
        End If
        oReporteViewModel.CadenaZona = zona
        oReporteViewModel.CadenaSucursal = sucursal
        oReporteViewModel.CadenaSubGerente = subGerente
        oReporteViewModel.CadenaJefeVenta = jefeVenta
        oReporteViewModel.CadenaRrvv = rrvv

        Dim jsonResult As JsonResult

        Dim nameReportFlash = ConfigurationManager.AppSettings("ReporteAvanceVenta")
        Dim nameFileReporteFlash = nameReportFlash + "_" + DateTime.Now.ToString(CultureInfo.InvariantCulture).Replace("/", "-").Replace(":", " ")

        Try
            GeneraExcel(nameReportFlash, oReporteViewModel, nameFileReporteFlash)
            jsonResult = Json(New With {
                                Key .nameFile = nameFileReporteFlash,
                                Key .error = False
                                }, JsonRequestBehavior.AllowGet)
        Catch ex As Exception
            Dim msj = ex.Message
            Return Json(New With {Key .mensaje = msj}, JsonRequestBehavior.AllowGet)
        End Try

        Return jsonResult
    End Function

    <RequiresAuthenticationAttribute()>
    Function DescargarExcel(nameFile As String) As FileResult
        Dim absolutePath = Server.MapPath(ConfigurationManager.AppSettings("ReportesVVEE"))
        'Dim urlEncode = HttpUtility.UrlEncode(nameFile, Encoding.UTF8) ?? "Reporte Flash Vacio"
        Dim urlEncode = If(HttpUtility.UrlEncode(nameFile, Encoding.UTF8), "Reporte Avance Venta Vacio")
        Dim pathFile = Path.Combine(absolutePath, urlEncode.Replace("+", " ") + ".xls")
        Dim excelFile = IO.File.ReadAllBytes(pathFile)

        If IO.File.Exists(pathFile) Then
            IO.File.Delete(pathFile)
        End If

        Return File(excelFile, MediaTypeNames.Application.Octet, urlEncode.Replace("+", " ") + ".xls")
    End Function

    <RequiresAuthenticationAttribute()>
    Private Sub GeneraExcel(nameReport As String, model As ReporteViewModel, nameFileReport As String)
        Dim urlReporting = ConfigurationManager.AppSettings("Servidor")
        Dim fileFolder = ConfigurationManager.AppSettings("CarpetaAV")
        Dim fechaIniCMes = New DateTime(model.FechaInicio.Year, model.FechaInicio.Month, 1)
        Dim fechaAcuFin = fechaIniCMes.AddDays(-1).ToString("yyyyMMdd")
        Dim fechaAcuFinENviar = fechaIniCMes.AddDays(-1)
        Dim tempfecha = fechaAcuFinENviar.AddMonths(-2).ToString("yyyyMMdd")
        Dim tempfechaEnviar = fechaAcuFinENviar.AddMonths(-2)
        Dim fechaAcuIni = New DateTime(tempfechaEnviar.Year, tempfechaEnviar.Month, 1).ToString("yyyyMMdd")

        Dim fechaInicio = model.FechaInicio.ToString("yyyyMMdd")
        Dim fechaFin = model.FechaFin.ToString("yyyyMMdd")
        Dim fechaFinEnviar = model.FechaFin
        Dim fechaIniNextMes = New DateTime(fechaFinEnviar.Year, fechaFinEnviar.Month, 1).AddMonths(1).ToString("yyyyMMdd")
        Dim fechaIniNextMesEnviar = New DateTime(fechaFinEnviar.Year, fechaFinEnviar.Month, 1).AddMonths(1)
        Dim fechaFinMes = fechaIniNextMesEnviar.AddDays(-1).ToString("yyyyMMdd")
        Dim fechaFinMesEnviar = fechaIniNextMesEnviar.AddDays(-1)
        Dim mesVenta = fechaFinMesEnviar.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"))

        Dim viewer As New ReportViewer()
        viewer.ProcessingMode = ProcessingMode.Remote
        viewer.ServerReport.Timeout = -1
        viewer.ServerReport.ReportServerUrl = New Uri(urlReporting)
        viewer.ServerReport.ReportPath = "/" + fileFolder + "/" + nameReport
        viewer.ServerReport.ReportServerCredentials = New ReportServerCredentials()

        Dim dimFechaAcuIni = New ReportParameter
        dimFechaAcuIni.Name = "FechaAcuIni"
        dimFechaAcuIni.Values.Add(fechaAcuIni)

        Dim dimFechaAcuFin = New ReportParameter
        dimFechaAcuFin.Name = "FechaAcuFin"
        dimFechaAcuFin.Values.Add(fechaAcuFin)

        Dim dimFechaInicio = New ReportParameter
        dimFechaInicio.Name = "FechaInicio"
        dimFechaInicio.Values.Add(fechaInicio)

        Dim dimFechaFin = New ReportParameter
        dimFechaFin.Name = "FechaFin"
        dimFechaFin.Values.Add(fechaFin)

        Dim dimFechaFinMes = New ReportParameter
        dimFechaFinMes.Name = "FechaFinMes"
        dimFechaFinMes.Values.Add(fechaFinMes)

        Dim dimMesVenta = New ReportParameter
        dimMesVenta.Name = "MesVenta"
        dimMesVenta.Values.Add(mesVenta)

        Dim dimAnio = New ReportParameter
        dimAnio.Name = "Anio"
        dimAnio.Values.Add(fechaFinMesEnviar.Year)

        Dim dimZona = New ReportParameter
        dimZona.Name = "Zona"
        dimZona.Values.Add(model.CadenaZona)

        Dim dimTipoSubGerente = New ReportParameter
        dimTipoSubGerente.Name = "TipoSubGerente"
        dimTipoSubGerente.Values.Add(model.TipoSubGerente)

        Dim dimSucursal = New ReportParameter
        dimSucursal.Name = "Sucursal"
        dimSucursal.Values.Add(model.CadenaSucursal)

        Dim dimSubGerente = New ReportParameter
        dimSubGerente.Name = "SubGerente"
        dimSubGerente.Values.Add(model.CadenaSubGerente)

        Dim dimJefeVenta = New ReportParameter
        dimJefeVenta.Name = "JefeVenta"
        dimJefeVenta.Values.Add(model.CadenaJefeVenta)

        Dim dimVendedor = New ReportParameter
        dimVendedor.Name = "Rrvv"
        dimVendedor.Values.Add(model.CadenaRrvv)

        viewer.ServerReport.SetParameters(
                    New ReportParameter() _
                    {
                        dimFechaAcuIni,
                        dimFechaAcuFin,
                        dimFechaInicio,
                        dimFechaFin,
                        dimFechaFinMes,
                        dimMesVenta,
                        dimAnio,
                        dimZona,
                        dimSucursal,
                        dimSubGerente,
                        dimJefeVenta,
                        dimVendedor
                    })

        Dim streamIds As String()
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = "xls"
        Dim warnings As Warning()

        Dim bytes As Byte() = viewer.ServerReport.Render("EXCEL", Nothing, mimeType, encoding, extension, streamIds, warnings)
        Dim absolutePath = Server.MapPath(ConfigurationManager.AppSettings("ReportesVVEE"))
        If Not Directory.Exists(Server.MapPath(ConfigurationManager.AppSettings("ReportesVVEE"))) Then
            Directory.CreateDirectory(Server.MapPath(ConfigurationManager.AppSettings("ReportesVVEE")))
        End If

        Dim finalPath = Path.Combine(absolutePath, nameFileReport + "." + "xls")
        IO.File.WriteAllBytes(finalPath, bytes)
    End Sub
End Class