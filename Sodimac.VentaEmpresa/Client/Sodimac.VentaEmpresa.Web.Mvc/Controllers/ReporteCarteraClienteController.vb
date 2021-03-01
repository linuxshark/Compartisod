Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.Common
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
Imports System.IO
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Spreadsheet
Imports OfficeOpenXml

Public Class ReporteCarteraClienteController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /ReporteCarteraCliente
    Function Index() As ActionResult
        Dim oReporteViewModel As New ReporteViewModel
        Dim oReporteBusinessLogic As New ReporteBusinessLogic
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

        Return PartialView(ParametrosPartialView.PartialJefeRegional, oReporteViewModel)
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

    <RequiresAuthenticationAttribute()>
    Function _ComboVendedor(IdSucursal As Integer) As ActionResult
        Dim oReporteViewModel As New ReporteViewModel
        Dim oReporteBusinessLogic As New ReporteBusinessLogic
        oReporteViewModel.ListaEmpleado = oReporteBusinessLogic.BuscarVendedoresVentas(IdSucursal)
        Return PartialView(ParametrosPartialView.PVVendedorPrincipal, oReporteViewModel)
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

        Dim DiaFI As String = Session("FechaInicio").ToString().Substring(0, 2)
        Dim MesFI As String = Session("FechaInicio").ToString().Substring(3, 2)
        Dim AnnioFI As String = Session("FechaInicio").ToString().Substring(6, 4)

        Dim DiaFF As String = Session("FechaFin").ToString().Substring(0, 2)
        Dim MesFF As String = Session("FechaFin").ToString().Substring(3, 2)
        Dim AnnioFF As String = Session("FechaFin").ToString().Substring(6, 4)

        Dim FechaIni As String = AnnioFI & MesFI & DiaFI
        Dim FechaFi As String = AnnioFF & MesFF & DiaFF
        Dim Rol As String = Session("Rol")

        Dim listReportVenta = New ReporteBusinessLogic().ListarReporteClienteCartera(FechaIni, FechaFi, JefeRegional, Zona, Sucursal, Vendedor, Ruc, RazonSocial, TipoCliente, IdGrupo, Rol)
        listReportVenta.Insert(0, New ReporteClienteCartera)

        Dim codedate As String = Date.Now.ToString("yyyyMMddHHmmssfff")

        Dim nameFile As String = "ReporteCarteraCliente" + codedate + ".xlsx"
        Dim relativepath As String = Server.MapPath(ConfigurationManager.AppSettings("ReporteVentas"))
        Dim absolutepath As String = Path.Combine(relativepath, nameFile)


        'Borra todos los "Reportes Ventas" menos los del presente dia
        Try
            Dim xlsList As String() = Directory.GetFiles(Path.Combine(relativepath, ""), "*.xlsx")
            For Each f As String In xlsList
                If Not (f.Contains(codedate.Substring(0, 8))) Then
                    IO.File.Delete(f)
                End If
            Next
        Catch ex As Exception
        End Try

        Directory.CreateDirectory(Path.GetDirectoryName(absolutepath))

        Dim p As New ExcelPackage
        Dim exe = New RptClienteCartera(p.Workbook)
        Dim listaCabecera = ColumnCarteraCliente()
        exe.CrearExcel_ClienteCartera(listReportVenta, listaCabecera)
        Dim bin As Byte()
        bin = p.GetAsByteArray()
        IO.File.WriteAllBytes(absolutepath, bin)

        Return Content(ConfigurationManager.AppSettings("ReporteVentas") + "/" + nameFile)
    End Function

    Private Shared Function ColumnCarteraCliente() As List(Of String)
        Dim lista As New List(Of String) From {
            "Empresa",
            "Zona",
            "SubGerente",
            "Jefe Ventas Regionales",
            "Asig EEVV / Tienda",
            "Código EEVV",
            "Nombre del EEVV / Mesón",
            "Sucursal",
            "RUC",
            "Razón Social",
            "Sector",
            "Fecha Creación",
            "Fecha Ultima Asignación",
            "Modo de Pago",
            "Fec. Apertura SIGIC",
            "Fecha Expiración",
            "Plazo Pago",
            "LC SIGIC",
            "Fact.SIGIC",
            "LC Disponible",
            "% Utilización",
            "Estado LC",
            "Estado Cliente",
            "Venta Total Crédito",
            "Venta Total Oracle (Crédito)",
            "Venta Total Contado",
            "Venta Total Oracle (Contado)",
            "Total Ventas (Avance)",
            "Total Costos (Avance)",
            "Total Contribución (Avance)",
            "Margen de Contribución %",
            "Venta Total Sodimac",
            "Venta Total Maestro"
        }
        Return lista
    End Function

    Private Shared Sub ReadFile(oxa As List(Of OpenXmlAttribute), oxw As OpenXmlWriter, data As String)
        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))
        oxw.WriteStartElement(New Cell(), oxa)
        oxw.WriteElement(New CellValue(Data))
        oxw.WriteEndElement()
    End Sub
End Class