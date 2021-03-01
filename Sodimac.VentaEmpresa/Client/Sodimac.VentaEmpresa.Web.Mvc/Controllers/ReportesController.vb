Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.Common
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
Imports Newtonsoft.Json
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports ClosedXML.Excel
Imports System.IO
Imports OfficeOpenXml

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class ReportesController
        Inherits BaseController

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteGuias() As ActionResult
            Dim usuarioUsu As String = Session("User")
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic
            oReporteViewModel.ListaEmpleado = New ListaEmpleado()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaEmpleado = oReporteBusinessLogic.ListarVendedores(usuarioUsu, Constantes.ValorDefecto, Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.FechaInicio = Date.Now
            oReporteViewModel.FechaFin = Date.Now
            Return View(oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteVentas() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oCVM As New ClienteBusinessLogic()
            Dim usuarioUsu As String = Session("User")

            oReporteViewModel.ListaClienteTipo = oReporteBusinessLogic.BuscarTipoClientes()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)

            oReporteViewModel.ListaEmpleado = New ListaEmpleado()
            oReporteViewModel.ListaEmpleado = oReporteBusinessLogic.ListarVendedores(usuarioUsu, Constantes.ValorDefecto, Constantes.ValorDefecto, Constantes.ValorDefecto)

            oReporteViewModel.ListaJefeRegional = New ListaEmpleado()
            oReporteViewModel.ListaJefeRegional = oReporteBusinessLogic.BuscarJefeRegionalVentas(usuarioUsu, Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)

            oReporteViewModel.ListaGrupo = oCVM.ListarGrupo()


            oReporteViewModel.FechaInicio = Date.Now
            oReporteViewModel.FechaFin = Date.Now

            Return View(oReporteViewModel)
        End Function


        <RequiresAuthenticationAjaxAttribute()>
        Function _ComboMultiZona(Optional FechaIni As String = Constantes.ValorDefecto,
                                      Optional FechaFin As String = Constantes.ValorDefecto) As ActionResult

            Dim oReporteViewModel As ReporteViewModel = New ReporteViewModel
            Dim oReporteBusinessLogic As ReporteBusinessLogic = New ReporteBusinessLogic()
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), FechaIni, FechaFin)

            Return PartialView(ParametrosPartialView.PartialZona, oReporteViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function _ComboMultiSucursal(Optional IdZonaCadena As String = Constantes.ValorDefecto, Optional FechaIni As String = Constantes.ValorDefecto,
                                      Optional FechaFin As String = Constantes.ValorDefecto) As ActionResult

            Dim oReporteViewModel As ReporteViewModel = New ReporteViewModel
            Dim oReporteBusinessLogic As ReporteBusinessLogic = New ReporteBusinessLogic()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal(IdZonaCadena, Session("User"), FechaIni, FechaFin)

            Return PartialView(ParametrosPartialView.PartialSucursal, oReporteViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function _ComboMultiSucursalCliente(Optional IdZonaCadena As String = Constantes.ValorDefecto) As ActionResult

            Dim oReporteViewModel As ReporteViewModel = New ReporteViewModel
            Dim oReporteBusinessLogic As ReporteBusinessLogic = New ReporteBusinessLogic()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.ListarSucursalZona_Cliente(IdZonaCadena, Session("User"))

            Return PartialView(ParametrosPartialView.PartialSucursal, oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function _ComboJefeRegional(Optional FechaIni As String = Constantes.ValorDefecto,
                                      Optional FechaFin As String = Constantes.ValorDefecto) As ActionResult
            Dim usuarioUsu As String = Session("User")
            Dim oReporteViewModel As ReporteViewModel = New ReporteViewModel
            Dim oReporteBusinessLogic As ReporteBusinessLogic = New ReporteBusinessLogic()
            oReporteViewModel.ListaJefeRegional = New ListaEmpleado()
            oReporteViewModel.ListaJefeRegional = oReporteBusinessLogic.BuscarJefeRegionalVentas(usuarioUsu, FechaIni, FechaFin)

            Return PartialView(oReporteViewModel)


        End Function

        <RequiresAuthenticationAttribute()>
        Function _ComboRRVV(Optional jefe As String = Constantes.ValorDefecto, Optional FechaIni As String = Constantes.ValorDefecto,
                                      Optional FechaFin As String = Constantes.ValorDefecto) As ActionResult
            Dim usuarioUsu As String = Session("User")
            Dim oReporteViewModel As ReporteViewModel = New ReporteViewModel
            Dim oReporteBusinessLogic As ReporteBusinessLogic = New ReporteBusinessLogic()
            oReporteViewModel.ListaEmpleado = New ListaEmpleado()
            If jefe = "null" Then
                jefe = "0"
            End If
            oReporteViewModel.ListaEmpleado = oReporteBusinessLogic.ListarVendedores(usuarioUsu, jefe, FechaIni, FechaFin)

            Return PartialView(ParametrosPartialView.PartialRRVV, oReporteViewModel)


        End Function
        '<RequiresAuthenticationAttribute()>
        'Function _ComboSucursal(IdJefeRegional As Integer) As ActionResult
        '    Dim oReporteViewModel As New ReporteViewModel
        '    Dim oReporteBusinessLogic As New ReporteBusinessLogic
        '    oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursalVentas(IdJefeRegional)
        '    Return PartialView(oReporteViewModel)
        'End Function



        '<RequiresAuthenticationAttribute()>
        'Function _ComboSucursalByZona(IdZona As Integer) As ActionResult
        '    Dim oReporteViewModel As New ReporteViewModel
        '    Dim oReporteBusinessLogic As New ReporteBusinessLogic
        '    oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursalByZona(IdZona)
        '    Return PartialView(oReporteViewModel)
        'End Function
        <RequiresAuthenticationAttribute()>
        Function _ComboVendedor(IdSucursal As Integer) As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            oReporteViewModel.ListaEmpleado = oReporteBusinessLogic.BuscarVendedoresVentas(IdSucursal)
            Return PartialView(oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteComisiones() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.FechaInicio = Date.Now
            oReporteViewModel.FechaFin = Date.Now
            Return View(oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        <HttpGet()>
        Function ReporteVAP() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            oReporteViewModel.ListaMarca = oReporteBusinessLogic.ListarMarcas()
            Return View(oReporteViewModel)
        End Function

        '<RequiresAuthenticationAttribute()> _
        '<RequiresAuthorizationAttribute()> _
        '<HttpPost()>
        'Function ReporteVAP(model As ReporteViewModel) As ActionResult

        '    Return File()
        'End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteVendedores() As ActionResult
            Dim usuarioUsu As String = Session("User")
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()

            oReporteViewModel.ListaJefeRegional = New ListaEmpleado()
            oReporteViewModel.ListaJefeRegional = oReporteBusinessLogic.BuscarJefeRegionalVentas(usuarioUsu, Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.FechaInicio = Date.Now
            oReporteViewModel.FechaFin = Date.Now
            oReporteViewModel.IdPerfilActual = oClienteBusinessLogic.Obtener_IdPerfilActualEmpleado(usuarioUsu)
            Return View(oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteJefeRegional() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.FechaInicio = Date.Now
            oReporteViewModel.FechaFin = Date.Now
            Return View(oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function ReporteTiendas() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaSucursal = New ListaSucursal
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.FechaInicio = Date.Now
            oReporteViewModel.FechaFin = Date.Now
            Return View(oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteClientes() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oClienteBusinessLogic As New ClienteBusinessLogic
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic
            Dim usuarioUsu As String = Session("User")
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento3(usuarioUsu)

            'oReporteViewModel.ListaSucursal = New ListaSucursal
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal3(Session("User"))
            oReporteViewModel.ListaClienteSector = oReporteBusinessLogic.BuscarSectorClientes()
            oReporteViewModel.ListaClienteCategoria = oReporteBusinessLogic.BuscarCategoriaClientes()
            oReporteViewModel.ListaClienteModoPagoCombo = oReporteBusinessLogic.BuscarFormaPagoClientes()
            oReporteViewModel.ListaClienteTipo = oReporteBusinessLogic.BuscarTipoClientes()
            oReporteViewModel.ListaClienteEstadoLinea = oReporteBusinessLogic.ListarEstados()
            oReporteViewModel.ListaEmpleado = oClienteBusinessLogic.ListarVendedorPrincipal()
            Return (View(oReporteViewModel))
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteClientesHistorial() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oClienteBusinessLogic As New ClienteBusinessLogic
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaSucursal = New ListaSucursal
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaClienteSector = oReporteBusinessLogic.BuscarSectorClientes()
            oReporteViewModel.ListaClienteCategoria = oReporteBusinessLogic.BuscarCategoriaClientes()
            oReporteViewModel.ListaClienteModoPagoCombo = oReporteBusinessLogic.BuscarFormaPagoClientes()
            Return View(oReporteViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteLog() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Dim oLogBusinessLog As New LogBusinessLogic

            oReporteViewModel.ListaOrigenAccion = oLogBusinessLog.OrigenAccion_Listar()
            oReporteViewModel.ListaLogAccion = oLogBusinessLog.LogAccion_Listar()
            oReporteViewModel.FechaInicio = Date.Now
            oReporteViewModel.FechaFin = Date.Now

            Return View(oReporteViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteGuias(Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto, Optional Sucursal As String = "0", Optional Zona As String = "0", Optional Correlativo As String = "", Optional TipoPedido As String = "", Optional Caja As String = "", Optional Vendedor As String = "0") As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Sucursal") = Sucursal
            Session("Zona") = Zona
            Session("Correlativo") = Correlativo
            Session("TipoPedido") = TipoPedido
            Session("Caja") = Caja
            Session("Vendedor") = Vendedor

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Sucursal:" & Sucursal &
                "|Correlativo:" & Correlativo &
                "|TipoPedido:" & TipoPedido &
                "|Caja:" & Caja &
                "|Vendedor:" & Vendedor
            Log.IdOrigenAccion = Constantes.Reporte_Guias
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView("VerReporteGuias")
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteVentas(Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto, Optional Ruc As String = "0", Optional Vendedor As String = "", Optional TipoCliente As String = "", Optional JefeRegional As String = "", Optional Sucursal As String = "", Optional RazonSocial As String = "0", Optional Zona As String = "", Optional IdGrupo As String = "") As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Sucursal") = Sucursal
            Session("Ruc") = Ruc
            Session("JefeRegional") = JefeRegional
            Session("Vendedor") = Vendedor
            Session("TipoCliente") = TipoCliente
            Session("RazonSocial") = RazonSocial
            Session("Zona") = Zona
            Session("IdGrupo") = IdGrupo

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Sucursal:" & Sucursal &
                "|Ruc:" & Ruc &
                "|JefeRegional:" & JefeRegional &
                "|Vendedor:" & Vendedor &
                "|TipoCliente:" & TipoCliente &
                "|RazonSocial:" & RazonSocial &
                "|Zona:" & Zona &
                "|IdGrupo:" & IdGrupo
            Log.IdOrigenAccion = Constantes.Reporte_Ventas
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)



            Return PartialView("VerReporteVentas")
        End Function

        Function ExportarReporteVentas(Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto, Optional Ruc As String = "0", Optional Vendedor As String = "", Optional TipoCliente As String = "0", Optional JefeRegional As String = "", Optional Sucursal As String = "", Optional RazonSocial As String = "0", Optional Zona As String = "", Optional IdGrupo As String = "0") _
        As ActionResult 'As FileResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            If RazonSocial = "" Then RazonSocial = Constantes.ValorCero
            If TipoCliente = "" Then TipoCliente = Constantes.ValorCero
            If IdGrupo = "" Then IdGrupo = Constantes.ValorCero

            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Sucursal") = Sucursal
            Session("Ruc") = Ruc
            Session("JefeRegional") = JefeRegional
            Session("Vendedor") = Vendedor
            Session("TipoCliente") = TipoCliente
            Session("RazonSocial") = RazonSocial
            Session("Zona") = Zona
            Session("IdGrupo") = IdGrupo

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Sucursal:" & Sucursal &
                "|Ruc:" & Ruc &
                "|JefeRegional:" & JefeRegional &
                "|Vendedor:" & Vendedor &
                "|TipoCliente:" & TipoCliente &
                "|RazonSocial:" & RazonSocial &
                "|Zona:" & Zona &
                "|IdGrupo:" & IdGrupo
            Log.IdOrigenAccion = Constantes.Reporte_Ventas
            Log.IdLogAccion = Constantes.Exportar


            Dim DiaFI As String = Session("FechaInicio").ToString().Substring(0, 2)
            Dim MesFI As String = Session("FechaInicio").ToString().Substring(3, 2)
            Dim AnnioFI As String = Session("FechaInicio").ToString().Substring(6, 4)

            Dim DiaFF As String = Session("FechaFin").ToString().Substring(0, 2)
            Dim MesFF As String = Session("FechaFin").ToString().Substring(3, 2)
            Dim AnnioFF As String = Session("FechaFin").ToString().Substring(6, 4)

            Dim FechaIni As String = AnnioFI & MesFI & DiaFI
            Dim FechaFi As String = AnnioFF & MesFF & DiaFF
            Dim usuarioUsu As String = Session("User")


            Dim listReportVenta = New ReporteBusinessLogic().ListarReporteVenta(FechaIni, FechaFi, JefeRegional, Zona, Sucursal, Vendedor, Ruc, RazonSocial, TipoCliente, IdGrupo, usuarioUsu)
            listReportVenta.Insert(0, New ReportVenta)

            Dim codedate As String = GenerateCodeDate() 'formato: yyyyMMddHHmmssfff
            'Dim relativepath As String = GenerateRelativeTempPath()
            'Dim absolutepath As String = Path.Combine(relativepath, "ReporteVenta" + codedate + ".xlsx")

            Dim nameFile As String = "ReporteVenta" + codedate + ".xlsx"
            Dim relativepath As String = Server.MapPath(ConfigurationManager.AppSettings("ReporteVentas"))
            Dim absolutepath As String = Path.Combine(relativepath, nameFile)


            'Borra todos los "Reportes Ventas" menos los del presente dia
            Try
                Dim xlsList As String() = Directory.GetFiles(Path.Combine(relativepath, ""), "*.xlsx")
                For Each f As String In xlsList
                    If Not (f.Contains(codedate.Substring(0, 8))) Then
                        System.IO.File.Delete(f)
                    End If
                Next
            Catch ex As Exception
            End Try

            Directory.CreateDirectory(Path.GetDirectoryName(absolutepath))

            Using xl As SpreadsheetDocument = SpreadsheetDocument.Create(absolutepath, SpreadsheetDocumentType.Workbook)
                Dim oxa As List(Of OpenXmlAttribute)
                Dim oxw As OpenXmlWriter
                xl.AddWorkbookPart()

                Dim wsp As WorksheetPart = xl.WorkbookPart.AddNewPart(Of WorksheetPart)()
                oxw = OpenXmlWriter.Create(wsp)
                oxw.WriteStartElement(New Worksheet())
                oxw.WriteStartElement(New SheetData())
                For Each item As ReportVenta In listReportVenta
                    oxa = New List(Of OpenXmlAttribute)()
                    oxa.Add(New OpenXmlAttribute("r", Nothing, item.ToString()))
                    oxw.WriteStartElement(New Row(), oxa)

                    If (IsNothing(item.TipoDocumento)) Then
                        For Each headerstring As String In ColumnsReporteVentas()
                            ReadFile(oxa, oxw, headerstring)
                        Next
                    Else
                        ReadFile(oxa, oxw, item.NomEmpresa)
                        ReadFile(oxa, oxw, item.TipoDocumento)
                        ReadFile(oxa, oxw, item.Correlativo)
                        ReadFile(oxa, oxw, item.DocRelacionado)
                        ReadFile(oxa, oxw, item.TipoDocRelacionado)
                        ReadFile(oxa, oxw, item.Ruc)
                        ReadFile(oxa, oxw, item.RazonSocial)
                        ReadFile(oxa, oxw, item.CodigoProveedor)
                        ReadFile(oxa, oxw, item.NombreProveedor)
                        ReadFile(oxa, oxw, item.Marca)
                        ReadFile(oxa, oxw, item.Zona)
                        ReadFile(oxa, oxw, item.Grupo)
                        ReadFile(oxa, oxw, item.CodigoSucursal)
                        ReadFile(oxa, oxw, item.DescripcionSucursal)
                        ReadFile(oxa, oxw, item.CodigoRRVV)
                        ReadFile(oxa, oxw, item.RepresentanteVentas)
                        ReadFile(oxa, oxw, item.JefeVentas)
                        ReadFile(oxa, oxw, item.SubGerente)
                        ReadFile(oxa, oxw, item.TipoCliente)
                        ReadFile(oxa, oxw, item.Fecha)
                        ReadFile(oxa, oxw, item.TipoCaja)
                        ReadFile(oxa, oxw, item.ModoPago)
                        ReadFile(oxa, oxw, item.SKU)
                        ReadFile(oxa, oxw, item.DescripcionSKU)
                        ReadFile(oxa, oxw, item.CLACOM)
                        ReadFile(oxa, oxw, item.DescripcionCLACOM)
                        ReadFile(oxa, oxw, item.DPTONuevo)
                        ReadFile(oxa, oxw, item.DescDPTONuevo)
                        ReadFile(oxa, oxw, item.FamiliaNueva)
                        ReadFile(oxa, oxw, item.DescripcionFamiliaNueva)
                        ReadFile(oxa, oxw, item.Cantidad)
                        ReadFile(oxa, oxw, item.ValorVenta)
                        ReadFile(oxa, oxw, item.SubTotal)
                        ReadFile(oxa, oxw, item.IGV)
                        ReadFile(oxa, oxw, item.Total)
                        ReadFile(oxa, oxw, item.CostoTotal)
                        ReadFile(oxa, oxw, item.CostoUnitario)
                        ReadFile(oxa, oxw, item.Margen)
                        ReadFile(oxa, oxw, item.Contribucion)
                        ReadFile(oxa, oxw, item.Percepcion)
                        ReadFile(oxa, oxw, item.MontoPercepcion)
                        ReadFile(oxa, oxw, item.TotalIGV_Percepcion)
                    End If

                    oxw.WriteEndElement()
                Next

                oxw.WriteEndElement()
                oxw.WriteEndElement()
                oxw.Close()
                oxw = OpenXmlWriter.Create(xl.WorkbookPart)
                oxw.WriteStartElement(New Workbook())
                oxw.WriteStartElement(New Sheets())

                oxw.WriteElement(New Sheet() With {
                 .Name = "Sheet1",
                 .SheetId = 1,
                 .Id = xl.WorkbookPart.GetIdOfPart(wsp)
                })

                oxw.WriteEndElement()
                oxw.WriteEndElement()
                oxw.Close()
                xl.Close()

            End Using

            'Dim fl As Byte() = System.IO.File.ReadAllBytes(absolutepath)
            'Return File(fl, System.Net.Mime.MediaTypeNames.Application.Octet, "ReporteVenta.xlsx")

            Return Content(ConfigurationManager.AppSettings("ReporteVentas") + "/" + nameFile)
        End Function



        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteComisiones(Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto, Optional Sucursal As String = "0", Optional Zona As String = "0") As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Sucursal") = Sucursal
            Session("Zona") = Zona

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Sucursal:" & Sucursal &
                "|Zona:" & Zona
            Log.IdOrigenAccion = Constantes.Reporte_Comisiones
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView("VerReporteComisiones")
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <RequiresAuthorizationAttribute()>
        Function VerReporteComisionesDetallado(Optional FechaInicio As String = Constantes.FechaDefecto,
                                               Optional FechaFin As String = Constantes.FechaDefecto,
                                               Optional Sucursal As String = "0", Optional Zona As String = "0",
                                               Optional IdRRVV As String = "0", Optional IdJefe As String = "0") As ActionResult

            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Sucursal") = Sucursal
            Session("Zona") = Zona
            Session("IdRRVV") = IIf(IdRRVV = "null", "0", IdRRVV)
            Session("IdJefe") = IIf(IdJefe = "null", "0", IdJefe)

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Sucursal:" & Sucursal &
                "|Zona:" & Zona &
                "|IdRRVV:" & IdRRVV &
                "|IdJefe:" & IdJefe
            Log.IdOrigenAccion = Constantes.Reporte_Comisiones
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView("VerReporteComisionesDetallado")
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteVendedores(Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto, Optional Sucursal As String = "0", Optional JefeRegional As String = "0", Optional IdZona As String = "0") As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Sucursal") = Sucursal
            Session("JefeRegional") = JefeRegional
            Session("Zona") = IdZona

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Sucursal:" & Sucursal &
                "|JefeRegional:" & JefeRegional &
                "|Zona:" & IdZona
            Log.IdOrigenAccion = Constantes.Reporte_RepresentanteVenta
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView("VerReporteVendedores")
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteJefeRegional(Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto, Optional Zona As String = "", Optional Sucursal As String = "") As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Zona") = Zona
            Session("Sucursal") = Sucursal

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Zona:" & Zona
            Log.IdOrigenAccion = Constantes.Reporte_JefeVentas
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView("VerReporteJefeRegional")
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteTiendas(Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto, Optional Sucursal As String = "", Optional Zona As String = "") As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Sucursal") = Sucursal
            Session("Zona") = Zona

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Sucursal:" & Sucursal &
                "|Zona:" & Zona
            Log.IdOrigenAccion = Constantes.Reporte_Tiendas
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView("VerReporteTiendas")
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteClientes(Optional Sector As String = "", Optional Categoria As String = "", Optional FormaPago As String = "", Optional Sucursal As String = "", Optional TipoCliente As Integer = 0, Optional Zona As String = "", Optional EstadoLinea As Integer = 0, Optional Vendedor As Integer = 0) As ActionResult
            Session("Sector") = Sector
            Session("Categoria") = Categoria
            Session("FormaPago") = FormaPago
            Session("Sucursal") = Sucursal
            Session("Zona") = Zona
            Session("TipoCliente") = TipoCliente
            Session("EstadoLinea") = EstadoLinea
            Session("Vendedor") = Vendedor

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Sector:" & Sector &
                "|Categoria:" & Categoria &
                "|FormaPago:" & FormaPago &
                "|Sucursal:" & Sucursal &
                "|Zona:" & Zona &
                "|TipoCliente:" & TipoCliente &
                "|EstadoLinea:" & EstadoLinea &
                "|Vendedor:" & Vendedor
            Log.IdOrigenAccion = Constantes.Reporte_Clientes
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView("VerReporteClientes")
        End Function
        '<HttpPost()>
        '<RequiresAuthenticationAjaxAttribute()>
        'Function ListarSucursal_By_Zona(Optional IdZona As Integer = Constantes.ValorCero) As ActionResult
        '    Dim oReportesViewModel As ReporteViewModel = New ReporteViewModel()
        '    Dim oVentasBussinessLogic As New VentasBusinessLogic()
        '    Dim oComunBusinessLogic As New ComunBusinessLogic()
        '    oReportesViewModel.ListaSucursal = oComunBusinessLogic.ListaZonas_Sucursales(IdZona)
        '    Return PartialView(ParametrosPartialView.PVSucursal_By_Zona, oReportesViewModel)
        'End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteClientesHistorial(
                                            Optional FechaInicio As String = Constantes.FechaDefecto,
                                            Optional FechaFin As String = Constantes.FechaDefecto,
                                            Optional Zona As String = Constantes.Clear,
                                            Optional Sucursal As String = Constantes.Clear,
                                            Optional Sector As String = Constantes.Clear,
                                            Optional Categoria As String = Constantes.Clear,
                                            Optional FormaPago As String = Constantes.Clear,
                                            Optional RazonSocialRUC As String = Constantes.Clear) As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("Zona") = Zona
            Session("Sucursal") = Sucursal
            Session("Sector") = Sector
            Session("Categoria") = Categoria
            Session("FormaPago") = FormaPago
            Session("RazonSocial") = RazonSocialRUC

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Sector:" & Sector &
                "|FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Zona:" & Zona &
                "|Sucursal:" & Sucursal &
                "|Sector:" & Sector &
                "|Categoria:" & Categoria &
                "|FormaPago:" & FormaPago &
                "|RazonSocial:" & RazonSocialRUC '& _
            '"|RUC:" & RUC
            Log.IdOrigenAccion = Constantes.Reporte_ClientesHistorial
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            Return PartialView(ParametrosPartialView.ReporteClientesHistorial)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteLog(Optional FechaInicio As String = Constantes.FechaDefecto,
                               Optional FechaFin As String = Constantes.FechaDefecto,
                               Optional IdLogAccion As String = "",
                               Optional IdOrigenAccion As String = "") As ActionResult
            If FechaInicio = "" Then FechaInicio = Constantes.FechaDefecto
            If FechaFin = "" Then FechaFin = Constantes.FechaDefecto
            Session("FechaInicio") = FechaInicio
            Session("FechaFin") = FechaFin
            Session("LogAccion") = IdLogAccion
            Session("OrigenAccion") = IdOrigenAccion

            '---------
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|IdLogAccion:" & IdLogAccion &
                "|IdOrigenAccion" & IdOrigenAccion
            Log.IdOrigenAccion = Constantes.Reporte_Log
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)
            '---------

            Return PartialView(ParametrosPartialView.ReporteLog)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GuardarLogExport(
            Optional ByVal TipoExport As String = Constantes.ValorDefecto,
            Optional ByVal IdOrigenAccion As Integer = Constantes.ValorCero) As ActionResult
            Dim Mensaje As String
            Dim jsonData
            Try
                Dim Log As Log = Session("Log")
                Log.DescripcionAccion = "TipoExport:" & TipoExport
                Log.IdOrigenAccion = IdOrigenAccion
                Log.IdLogAccion = Constantes.Exportar
                Dim LogBE As New LogBusinessLogic()
                LogBE.ActualizarLog(Log)
                Mensaje = "Se guardo correctamente!"
            Catch ex As Exception
                Mensaje = ex.Message
            End Try

            jsonData = New With
                        {
                            .mensaje = Mensaje
                        }
            Return Json(jsonData, JsonRequestBehavior.AllowGet)
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarSucursal() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarSucursalVendedores() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarZonaVendedores() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarSucursalJefeRegional() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarZonaJefeRegional() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarSectorClientes() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarCategoriaClientes() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarFormaPagoClientes() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function BuscarTipoClientes() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function ReporteComisionesDetallado() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic
            Dim oClienteBusinessLogic As New ClienteBusinessLogic
            Dim oReporteBusinessLogic As New ReporteBusinessLogic

            'oReporteViewModel.ListaSucursal = New ListaSucursal()
            'oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            'oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            'oReporteViewModel.ListaJefeRegional = oReporteBusinessLogic.BuscarJefeRegionalVentas(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            'oReporteViewModel.ListaEmpleado = oReporteBusinessLogic.ListarVendedores(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto, Constantes.ValorDefecto)
            'oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            'oReporteViewModel.FechaInicio = Date.Now
            'oReporteViewModel.FechaFin = Date.Now

            oReporteViewModel.ListaClienteTipo = oReporteBusinessLogic.BuscarTipoClientes()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal("", Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)

            oReporteViewModel.ListaEmpleado = New ListaEmpleado()
            oReporteViewModel.ListaEmpleado = oReporteBusinessLogic.ListarVendedores(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto, Constantes.ValorDefecto)

            oReporteViewModel.ListaJefeRegional = New ListaEmpleado()
            oReporteViewModel.ListaJefeRegional = oReporteBusinessLogic.BuscarJefeRegionalVentas(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)
            oReporteViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oReporteViewModel.ListaZonaMantenimiento = oReporteBusinessLogic.ListaZonaMantenimiento2(Session("User"), Constantes.ValorDefecto, Constantes.ValorDefecto)

            Return View(oReporteViewModel)
        End Function

        Private Function ColumnsReporteVentas() As String()
            Return {
            "EMPRESA",
            "TIPO DOCUMENTO",
            "CORRELATIVO",
            "DOCUMENTO REALACIONADO",
            "TIPO DE DOCUMENTO RELACIONADO",
            "RUC",
            "RAZÓN SOCIAL",
            "CODIGO PROVEEDOR",
            "NOMBRE PROVEEDOR",
            "MARCA",
            "Zona",
            "Grupo",
            "CÓDIGO SUCURSAL",
            "DESCRIPCIÓN SUCURSAL",
            "CÓDIGO RRVV",
            "REPRESENTANTE VENTAS",
            "JEFE VENTAS",
            "SUBGERENTE",
            "TIPO CLIENTE",
            "FECHA",
            "TIPO CAJA",
            "MODO PAGO",
            "SKU",
            "DESCRIPCIÓN SKU",
            "CLACOM",
            "DESCRIPCÓN CLACOM",
            "DPTO NUEVO",
            "DESC DPTO NUEVO",
            "FAM NUEVA",
            "DESC FAM NUEVA",
            "CANTIDAD",
            "VALOR VENTA",
            "SUBTOTAL",
            "IGV",
            "TOTAL",
            "COSTO TOTAL",
            "COSTO UNITARIO",
            "MARGEN",
            "CONTRIBUCIÓN",
            "% PERCEPCIÓN",
            "MONTO PERCEPCIÓN",
            "TOTAL IGV + PERCEPCIÓN"}
        End Function

        Private Function GetDataReporteVentas() As List(Of ReporteVentas)
            Dim count As Integer = 1
            Dim list As New List(Of ReporteVentas)
            For i As Integer = 1 To 500000
                list.Add(New ReporteVentas() With {
                .TipoDocumento = "FACTURA",
                .Correlativo = "195000206" + count,
                .Ruc = "20515678540" + count,
                .RazonSocial = "INVEB S.A.C." + count.ToString,
                .CodigoProveedor = "826" + count.ToString,
                .NombreProveedor = "UNION ANDINA DE CEMENTOS S.A.A." + count.ToString,
                .Marca = "Aceros Arequipa" + count.ToString,
                .Zona = "ZONA CENTRO SUR" + count.ToString,
                .Grupo = "Grupo Descripcion" + count.ToString,
                .CodigoSucursal = "S.J.LURIGANCHO" + count.ToString,
                .DescripcionSucursal = "S.J.LURIGANCHO" + count.ToString,
                .CodigoRRVV = "Codigo RRVV" + count.ToString,
                .RepresentanteVentas = "GONZALES TEJADA  KARINA VERONICA" + count.ToString,
                .JefeVentas = "ESPINOZA DAVID" + count.ToString,
                .TipoCliente = "Sector Privado" + count.ToString,
                .Fecha = DateTime.Now.ToString.ToString,
                .TipoCaja = "CAJA VENTA EMPRESA" + count.ToString,
                .ModoPago = "CREDITO",
                .SKU = "0105040101" + count.ToString,
                .DescripcionCLACOM = "CEMENTO ALTA RESISTENCIA TIPO I" + count.ToString,
                .DPTOAntiguo = "22",
                .DescDPTO = "CONSTRUCCION" + count.ToString,
                .FamiliaAntigua = "04",
                .DescripcionFamilia = "AGLOM, ARIDOS, ADITIVOS , IMPERMEB Y LADRILLOS" + count.ToString,
                .Cantidad = "20" + count.ToString,
                .ValorVenta = "14.57" + count.ToString,
                .SubTotal = "2915.25" + count.ToString,
                .IGV = "2.62" + count.ToString,
                .Total = "3438" + count.ToString,
                .CostoTotal = "0",
                .Margen = "1",
                .Contribucion = "2914",
                .Percepcion = "0",
                .MontoPercepcion = "0",
                .TotalIGV_Percepcion = "0"})

                count = count + 1
            Next
            list.Insert(0, New ReporteVentas)
            Return list
        End Function

        Private Sub ReadFile(oxa As List(Of OpenXmlAttribute), oxw As OpenXmlWriter, data As String)
            oxa = New List(Of OpenXmlAttribute)()
            oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))
            oxw.WriteStartElement(New Cell(), oxa)
            oxw.WriteElement(New CellValue(data))
            oxw.WriteEndElement()
        End Sub

        Private Sub ReadFile(oxa As List(Of OpenXmlAttribute), oxw As OpenXmlWriter, data As Decimal)
            oxa = New List(Of OpenXmlAttribute)()
            oxw.WriteStartElement(New Cell(), oxa)
            oxw.WriteElement(New CellValue(data))
            oxw.WriteEndElement()
        End Sub

        Private Sub ReadFile(oxa As List(Of OpenXmlAttribute), oxw As OpenXmlWriter, data As Long)
            oxa = New List(Of OpenXmlAttribute)()
            oxw.WriteStartElement(New Cell(), oxa)
            oxw.WriteElement(New CellValue(data))
            oxw.WriteEndElement()
        End Sub

        Private Function GenerateRelativeTempPath() As String

            Try
                Dim relativePath0 As [String] = Path.Combine(ConfigurationManager.AppSettings("GenerateTempFile"), String.Empty)
                Dim index0 = relativePath0.Split("/").Count - 2
                Dim extracnamedirectory0 As [String] = relativePath0.Split("/")(index0)
                relativePath0 = Replace(relativePath0, extracnamedirectory0, extracnamedirectory0 + Date.Now.AddDays(-1).ToString("yyyyMMdd"))
                Dim absolutePath0 As [String] = Server.MapPath(relativePath0)
                If Directory.Exists(absolutePath0) Then
                    Directory.Delete(absolutePath0, True)
                End If
            Catch ex As Exception

            End Try


            Dim relativePath As [String] = Path.Combine(ConfigurationManager.AppSettings("GenerateTempFile"), String.Empty)

            Dim index = relativePath.Split("/").Count - 2
            Dim extracnamedirectory As [String] = relativePath.Split("/")(index)
            relativePath = Replace(relativePath, extracnamedirectory, extracnamedirectory + Date.Now.ToString("yyyyMMdd"))

            Dim absolutePath As [String] = Server.MapPath(relativePath)
            If Not Directory.Exists(absolutePath) Then
                Directory.CreateDirectory(absolutePath)
            End If

            Return absolutePath
        End Function

        Private Function GenerateCodeDate() As String
            Return Date.Now.ToString("yyyyMMddHHmmssfff")
        End Function

#Region "Reporte Estado de Cuenta"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteEstadoCuenta() As ActionResult
            Dim usuarioUsu As String = Session("User")
            Dim oReporteViewModel As New ReporteViewModel
            Return View(oReporteViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerReporteEstadoCuenta(Optional RUC As String = "", Optional RazonSocial As String = "") As ActionResult
            Session("RUC") = RUC
            Session("RazonSocial") = RazonSocial
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "RUC:" & RUC & "|RazonSocial:" & RazonSocial
            Log.IdOrigenAccion = Constantes.Reporte_EstadoCuenta
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)
            Return PartialView("VerReporteEstadoCuenta")
        End Function
#End Region

#Region "Reporte Margen de Fierros"

        <HttpGet()>
        <RequiresAuthentication()>
        Function ReporteMargenFierro() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            oReporteViewModel.ListaEmpresa = New ListaEmpresa()
            oReporteViewModel.ListaEmpresa = oReporteBusinessLogic.ListarEmpresas()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaTipoCaja = oReporteBusinessLogic.ListarTipoCaja()
            'oReporteViewModel.ListaProducto = oReporteBusinessLogic.ListarSkuMargenFierro()

            Return View(oReporteViewModel)
        End Function

        <HttpGet()>
        <RequiresAuthentication()>
        Function _ProductosMargenFierro() As ActionResult
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            Return Json(oReporteBusinessLogic.ListarSkuMargenFierro(), JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost()>
        <RequiresAuthentication()>
        Function ReporteMargenFierro(FechaInicio As String, FechaFin As String, Empresa As String, Optional Sucursal As String = "", Optional Sku As String = "", Optional TipoCaja As String = "") As ActionResult


            Session("FECHAI") = FechaInicio
            Session("FECHAF") = FechaFin
            Session("IdEmpresa") = Empresa
            Session("IdSucursal") = Sucursal
            Session("Sku") = Sku
            Session("TipoCaja") = TipoCaja

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "FechaInicio:" & FechaInicio &
                "|FechaFin:" & FechaFin &
                "|Empresa:" & Empresa &
                "|Sucursal:" & Sucursal &
                "|Sku:" & Sku &
                "|TipoCaja:" & TipoCaja
            Log.IdOrigenAccion = Constantes.Reporte_MargenFierro
            Log.IdLogAccion = Constantes.VerReporte
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)


            Return PartialView(ParametrosPartialView.PartialMargenFierro)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function _ComboSucursal_(empresa As String) As ActionResult
            Dim oReporteViewModel As ReporteViewModel = New ReporteViewModel
            Dim oReporteBusinessLogic As ReporteBusinessLogic = New ReporteBusinessLogic()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal(empresa)
            Return PartialView(ParametrosPartialView.PartialSucursal, oReporteViewModel)
        End Function

#End Region

#Region "Reporte VE"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        <HttpGet()>
        Function ReporteVE() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic()
            oReporteViewModel.ListaMarca = oReporteBusinessLogic.ListarMarcas()
            Return View(oReporteViewModel)
        End Function

        Function ExportReporteVE(uri As String) As FileResult
            Dim idMarca As String = Request.QueryString("IdMarca").ToString()
            Dim NomMarca As String = Request.QueryString("NomMarca").ToString()
            Dim FechaInicio As String = Request.QueryString("FechaInicio").ToString()
            Dim FechaFin As String = Request.QueryString("FechaFin").ToString()

            'Genera log de Auditoria
            Dim Log As Log = Session("Log")
            Log.IdOrigenAccion = Constantes.Reporte_VentaEmpresa
            Log.IdLogAccion = Constantes.VerReporte
            Log.DescripcionAccion = "IdMarca:" & idMarca &
                                    "|FechaInicio:" & FechaInicio &
                                    "|FechaFin:" & FechaFin
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            'Elimina ultimo Excel generado en el servidor
            Dim path As String = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo"))
            Dim fileName As String = ConfigurationManager.AppSettings("fileNameReporteVE").ToString() 'ReporteVE.xls
            Dim DownloadFileName As String = String.Empty

            If System.IO.File.Exists(path + fileName) Then
                System.IO.File.Delete(path + fileName)
            End If

            'Genera y guardar nuevo Excel file
            Dim rep As New ReporteVE
            rep.GenerarExcel(idMarca, NomMarca, FechaInicio, FechaFin)

            'download Excel file
            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(path + "ReporteVE.xlsx")
            DownloadFileName = "AVANCE " + NomMarca + " AL " + FechaFin.Substring(0, 2) + " " + (New HelperReporteVE).getNombreMes(FechaFin.Substring(3, 2)).ToUpper() + " " + FechaFin.Substring(6, 4) + ".xlsx"
            Return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, DownloadFileName)
        End Function
#End Region

#Region "Reporte Nuevo VE"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReporteNuevoVAP() As ActionResult
            Dim oReporteViewModel As New ReporteViewModel
            Dim oReporteBusinessLogic As New ReporteBusinessLogic()
            oReporteViewModel.ListaMarca = oReporteBusinessLogic.ListarMarcas()
            Return View("ReporteVAP", oReporteViewModel)
        End Function

        Function ExportarVAP(IdMarca As String, NomMarca As String, Optional FechaInicio As String = Constantes.FechaDefecto, Optional FechaFin As String = Constantes.FechaDefecto) As ActionResult
            'Dim FechaInicio As String = Constantes.FechaDefecto
            'Dim FechaFin As String = Constantes.FechaDefecto
            Dim pathas As String = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo"))
            Dim fileName As String = ConfigurationManager.AppSettings("fileNameReporteVE").ToString()
            Dim DownloadFileName As String = String.Empty

            Dim rep As New ReporteVE
            rep.CrearExcel_EPPlus(IdMarca, NomMarca, FechaInicio, FechaFin, pathas, fileName)

            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(pathas + fileName)
            'DownloadFileName = "AVANCE " + NomMarca + " AL " + FechaFin.Substring(0, 2) + " " + (New HelperReporteVE).getNombreMes(FechaFin.Substring(3, 2)).ToUpper() + " " + FechaFin.Substring(6, 4) + ".xlsx"
            Return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName)
            Return Json(fileName)
        End Function

#End Region

#Region "Reporte VVEE_Tienda"

        <RequiresAuthenticationAjaxAttribute()>
        Function _ComboSucursalVVEE(empresa As String) As ActionResult
            Dim oReporteViewModel As ReporteViewModel = New ReporteViewModel
            Dim oReporteBusinessLogic As ReporteBusinessLogic = New ReporteBusinessLogic()
            oReporteViewModel.ListaSucursal = New ListaSucursal()
            oReporteViewModel.ListaSucursal = oReporteBusinessLogic.BuscarSucursal(empresa)
            Return PartialView(ParametrosPartialView.PartialSucursalVVEE, oReporteViewModel)
        End Function

        Function ReporteVE_Tienda() As ActionResult
            Dim oReporteTiendaViewModel As New ReporteTiendaViewModel()
            Dim oReporteBusinessLogic As New ReporteBusinessLogic
            oReporteTiendaViewModel.ListaEmpresa = New ListaEmpresa()
            oReporteTiendaViewModel.ListaEmpresa = oReporteBusinessLogic.ListarEmpresas()
            oReporteTiendaViewModel.ListaSucursal = New ListaSucursal()
            Return View(oReporteTiendaViewModel)
        End Function

        Function GenerarExcelVentaTienda(FechaInicio As String, FechaFin As String, Empresa As String, Optional Sucursal As String = "") As ActionResult
            Dim oReporteTiendaViewModel As New ReporteTiendaViewModel()
            oReporteTiendaViewModel.listaVentaEmpresaTienda = New VentaEmpresaTiendaBusinessLogic().ReporteVentaEmpresaTienda(FechaInicio, FechaFin, Empresa, Sucursal)

            Dim oExpor = New ExportarExcel()
            Dim param As String() = New String() {}

            param = {
            "FechaActual," + System.DateTime.Now.ToShortDateString(),
            "FechaInicio," + FechaInicio
            }

            Dim contentExcel As Byte()
            contentExcel = oExpor.CreateExcelRldcPrueba("Reportes\\ReportesVentaEmpresa\\ReporteVentaEmpresaTienda.rdlc", "ReporteTiendaVVEE", "DSReporteTiendaVVEE", oReporteTiendaViewModel.listaVentaEmpresaTienda.ToList(), param, Response)

            'Elimina ultimo Excel generado en el servidor
            Dim path As String = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo"))
            Dim fileName As String = ConfigurationManager.AppSettings("fileNameReporteVE_Tienda").ToString() 'ReporteVE_Tienda.xlsx
            Dim DownloadFileName As String = path + fileName

            If System.IO.File.Exists(DownloadFileName) Then
                System.IO.File.Delete(DownloadFileName)
            End If

            Dim fs As New FileStream(DownloadFileName, FileMode.Create)
            fs.Write(contentExcel, 0, contentExcel.Length)
            fs.Close()

            Return Content(ConfigurationManager.AppSettings("PathArchivo") + ";" + fileName)
        End Function
#End Region

#Region "Reporte VVEE_Cliente"

        Function ReporteVE_Cliente() As ActionResult
            Dim oReporteClienteViewModel As New ReporteClienteViewModel()
            Dim oReporteBusinessLogic As New ReporteBusinessLogic

            oReporteClienteViewModel.ListaSucursal = oReporteBusinessLogic.ListarSucursales_CodigoSucursal()

            Return View(oReporteClienteViewModel)
        End Function

        Function ReporteVentaEmpresaCliente(FechaInicio As String, FechaFin As String, Sucursal As String, RUC As String) As ActionResult
            Dim oReporteClienteViewModel As New ReporteClienteViewModel()
            oReporteClienteViewModel.listaVentaEmpresaCliente = New VentaEmpresaClienteBusinessLogic().ReporteVentaEmpresaCliente(FechaInicio, FechaFin, Sucursal, RUC)

            Dim oExpor = New ExportarExcel()
            Dim param As String() = New String() {}
            param = {
                "FechaActual," + System.DateTime.Now.ToShortDateString(),
                "FechaInicio," + FechaInicio
            }
            Dim contentExcel As Byte()
            contentExcel = oExpor.CreateExcelRldcPrueba("Reportes\\ReportesVentaEmpresa\\ReporteVentaEmpresaCliente.rdlc", "ReporteClienteVVEE", "DSVentaEmpresaCliente", oReporteClienteViewModel.listaVentaEmpresaCliente.ToList(), param, Response)

            'Elimina ultimo Excel generado en el servidor
            Dim path As String = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo"))
            Dim fileName As String = ConfigurationManager.AppSettings("fileNameReporteVE_Cliente").ToString() 'ReporteVE_Cliente.xlsx
            Dim DownloadFileName As String = path + fileName

            If System.IO.File.Exists(DownloadFileName) Then
                System.IO.File.Delete(DownloadFileName)
            End If

            Dim fs As New FileStream(DownloadFileName, FileMode.Create)
            fs.Write(contentExcel, 0, contentExcel.Length)
            fs.Close()

            Return Content(ConfigurationManager.AppSettings("PathArchivo") + ";" + fileName)
        End Function

#End Region

#Region "CONSULTA CLIENTES VENDEDORES ASOCIADOS"
        Function ClienteVendedorAsociado() As ActionResult
            Dim oModel As New ClienteVendedorAsociadoViewModel()
            oModel.clienteVenta = New ClienteVenta()
            oModel.listaClienteVenta = New List(Of ClienteVenta)
            oModel.Paginacion = New Paginacion
            oModel.Paginacion.Page = 1
            oModel.Paginacion.RowsPerPage = 10
            oModel.Paginacion.SortBy = oModel.sortDir
            oModel.Paginacion.SortType = oModel.sort

            Return View(oModel)
        End Function

        Function ConsultarClienteVendedorAsociado(oModel As ClienteVendedorAsociadoViewModel) As ActionResult
            Dim rowCount As Integer = 0
            oModel.Paginacion = New Paginacion
            oModel.Paginacion.Page = If(oModel.page.Equals(0), 1, oModel.page)
            oModel.Paginacion.RowsPerPage = 10
            oModel.Paginacion.SortBy = If(oModel.sortDir = Nothing, String.Empty, oModel.sortDir)
            oModel.Paginacion.SortType = If(oModel.sort = Nothing, String.Empty, oModel.sort)
            'oModel.page =
            oModel.listaClienteVenta = New ReporteBusinessLogic().ListarClienteVendedorAsociado(oModel.clienteVenta, oModel.Paginacion, rowCount)
            oModel.Paginacion.TotalRows = rowCount
            'oModel.listaClienteVentaTemp = oModel.listaClienteVenta.Skip((oModel.Paginacion.Page - 1) * 10).Take(10).ToList()
            oModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(oModel.Paginacion.Page, 10, rowCount)

            Return PartialView("PV_ClienteVendedorAsociado", oModel)
        End Function

#End Region

#Region "Reporte Usuarios"
        Function ReporteUsuario() As ActionResult
            Dim oReporteUsuarioViewModel As New ReporteUsuarioViewModel()
            Dim oAccountBusinessLogic As New AccountBusinessLogic()

            Dim listaEstado = New ListaEstado From {
                New Estado With {.IdEstado = -1, .Descripcion = "- TODOS -"},
                New Estado With {.IdEstado = 0, .Descripcion = "Inactivo"},
                New Estado With {.IdEstado = 1, .Descripcion = "Activo"}
            }

            oReporteUsuarioViewModel.ListaRol = New ListaRol
            oReporteUsuarioViewModel.ListaRol = oAccountBusinessLogic.ListarRol()
            oReporteUsuarioViewModel.ListaEstado = listaEstado

            Return View(oReporteUsuarioViewModel)
        End Function

        Function GenerarReporteUsuario(IdsRol As String, FechaIni As String, FechaFin As String, Estado As Integer, Usuario As String) As ActionResult
            Dim oReporteBusinessLogic As New ReporteBusinessLogic

            Dim ruta As String = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo"))
            Dim nombreRep As String = ConfigurationManager.AppSettings("nombreReporteUsuario").ToString()
            Dim nombreArchivo As String = nombreRep & "_" &
                                          Now.Date.ToString("dd-MM-yyyy") & "_" &
                                          Now.Hour.ToString() & "_" &
            Now.Minute.ToString() & ".xlsx"

            Dim rep As New ReporteVE
            Dim listaUsuario As New ListaUsuario
            Dim oUsuario As New Usuario

            oUsuario.ActivoUsu = Estado
            oUsuario.UsuarioUsu = Usuario
            FechaIni = CDate(FechaIni).ToString("yyyyMMdd")
            FechaFin = CDate(FechaFin).ToString("yyyyMMdd")

            listaUsuario = oReporteBusinessLogic.ListarReporteUsuario(oUsuario, IdsRol, FechaIni, FechaFin)
            rep.GenerarReporteUsuario(listaUsuario, ruta, nombreArchivo)

            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(ruta + nombreArchivo)
            Return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, nombreArchivo)
            Return Json(nombreArchivo)

        End Function

#End Region

#Region "Reporte Roles y Página"

        Function ReporteRolPagina() As ActionResult
            Dim oReporteRolPaginaViewModel As New ReporteRolPaginaViewModel()
            Dim oAccountBusinessLogic As New AccountBusinessLogic()

            Dim listaEstado = New ListaEstado From {
                New Estado With {.IdEstado = -1, .Descripcion = "- TODOS -"},
                New Estado With {.IdEstado = 0, .Descripcion = "Inactivo"},
                New Estado With {.IdEstado = 1, .Descripcion = "Activo"}
            }

            oReporteRolPaginaViewModel.ListaRol = New ListaRol
            oReporteRolPaginaViewModel.ListaRol = oAccountBusinessLogic.ListarRol()
            oReporteRolPaginaViewModel.ListaEstado = listaEstado

            Return View(oReporteRolPaginaViewModel)
        End Function

        Function GenerarReporteRolPagina(IdsRol As String, Estado As Integer, NombrePag As String) As ActionResult
            Dim oReporteBusinessLogic As New ReporteBusinessLogic

            Dim ruta As String = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo"))
            Dim nombreRep As String = ConfigurationManager.AppSettings("nombreReporteRolPagina").ToString()
            Dim nombreArchivo As String = nombreRep & "_" &
                                          Now.Date.ToString("dd-MM-yyyy") & "_" &
                                          Now.Hour.ToString() & "_" &
            Now.Minute.ToString() & ".xlsx"

            Dim rep As New ReporteVE
            Dim oListaPaginaRol As New ListaPaginaRol
            NombrePag = IIf(String.IsNullOrEmpty(NombrePag), "", NombrePag)
            oListaPaginaRol = oReporteBusinessLogic.ListarReporteRolPagina(IdsRol, Estado, NombrePag)
            rep.GenerarReporteRolPagina(oListaPaginaRol, ruta, nombreArchivo)

            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(ruta + nombreArchivo)
            Return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, nombreArchivo)
            Return Json(nombreArchivo)
        End Function

#End Region

    End Class
End Namespace
