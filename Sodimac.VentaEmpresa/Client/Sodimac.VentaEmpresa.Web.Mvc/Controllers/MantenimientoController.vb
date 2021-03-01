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
Imports Excel
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports Sodimac.VentaEmpresa.Common.My.Resources
Imports Sodimac.VentaEmpresa.Web.Mvc.Models.ViewModel
Imports System.Data.OleDb

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class MantenimientoController
        'Inherits BaseController
        Inherits AsyncController
        Dim objDataSet As New DataSet
        Dim Dst As New DataSet()
        Dim I, j As Integer
        Dim excelReader As IExcelDataReader
        Dim tmp As New MantenimientoViewModel


#Region "Perfiles"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarPerfil() As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.Perfil = New Perfil()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oMantenimientoViewModel.Paginacion.ListaPerfil = New ListaPerfil()
            oMantenimientoViewModel.ListaPerfil = oMantenimientoBusinessLogic.ListarPerfil_Combo()
            Return View(oMantenimientoViewModel)
        End Function
        <RequiresAuthenticationAttribute()>
        Function GestionarPerfil(Optional ByVal IdPerfil As Integer = Constantes.ValorCero,
                                 Optional ByVal TipoPerfil As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.ListaPerfil = oMantenimientoBusinessLogic.ListarPerfil_Combo()
            oMantenimientoViewModel.ListaEmpleadoPerfil = oMantenimientoBusinessLogic.ListarEmpleadoPerfil_Combo()
            oMantenimientoViewModel.Perfil = New Perfil
            If (TipoPerfil = 2) Then
                oMantenimientoViewModel.Perfil = oMantenimientoBusinessLogic.Sel_Perfil_PerfilMenor(IdPerfil)
            End If
            Return (PartialView(oMantenimientoViewModel))
        End Function



        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarPerfil_PVGrilla(
                                 Optional ByVal NombrePerfil As String = Constantes.Clear,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "NombrePerfil:" & NombrePerfil
            Log.IdOrigenAccion = Constantes.Mantenimiento_Perfil
            Log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortBy = sort
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.Perfil = New Perfil()
            oMantenimientoViewModel.Paginacion.Perfil.NombrePerfil = NombrePerfil
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarPerfiles(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
            )

            Return PartialView(oMantenimientoViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function GestionarPerfil_(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPerfil:" & oMantenimientoViewModel.Perfil.IdPerfil &
                "|IdPerfilSuperior:" & oMantenimientoViewModel.Perfil.IdPerfilSuperior &
                "|NombrePerfil:" & oMantenimientoViewModel.Perfil.NombrePerfil &
                "|TipoPerfil:" & oMantenimientoViewModel.Perfil.TipoPerfil &
                "|NombrePerfilInferior:" & oMantenimientoViewModel.Perfil.NombrePerfilInferior
            Log.IdOrigenAccion = Constantes.Mantenimiento_Perfil
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero

            If String.IsNullOrEmpty(oMantenimientoViewModel.Perfil.NombrePerfilInferior) Then
                oMantenimientoViewModel.Perfil.NombrePerfilInferior = String.Empty
                'Resultado = oMantenimientoBusinessLogic.GestionarPerfil(oMantenimientoViewModel.Perfil)
            End If

            Resultado = oMantenimientoBusinessLogic.GestionarPerfil(oMantenimientoViewModel.Perfil)
            Select Case Resultado
                Case Constantes.MenosDos
                    Mensaje = "Seleccione otro perfil a reportar."
                Case Constantes.MenosUno
                    Mensaje = "El nombre del perfil ingresado ya existe."
                Case Constantes.ValorCero
                    Mensaje = "Sucedió un error al registrar el perfil, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    Mensaje = "Se grabó correctamente el perfil " + oMantenimientoViewModel.Perfil.NombrePerfil.ToUpper()
                Case Constantes.ValorDos
                    Mensaje = "Se actualizó correctamente el perfil " + oMantenimientoViewModel.Perfil.NombrePerfil.ToUpper()
                Case Else
                    Mensaje = "Sucedió un error al registrar el perfil, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje

            Return Content(Convert.ToString(Mensaje))
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarPerfil(Optional ByVal IdPerfil As Integer = Constantes.ValorCero) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPerfil:" & IdPerfil
            Log.IdOrigenAccion = Constantes.Mantenimiento_Perfil
            Log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Resultado = oMantenimientoBusinessLogic.EliminarPerfil(IdPerfil)
            Select Case Resultado
                Case Constantes.MenosDos
                    Mensaje = "No se puede eliminar el perfil porque está asociado con perfiles inferiores."
                Case Constantes.MenosUno
                    Mensaje = "No se puede eliminar porque el perfil está asociado con un cargo activo."
                Case Constantes.ValorUno
                    Mensaje = "Se eliminó correctamente el perfil "
                Case Constantes.ValorDos
                    Mensaje = "Se eliminó correctamente el Perfil "
                Case Else
                    Mensaje = "Sucedió un error al eliminar el perfil, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function Autocompletado_Perfil(Optional ByVal q As String = Constantes.Clear) As JsonResult
            Dim oListaPerfil As New ListaPerfil
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oListaPerfil = oMantenimientoBusinessLogic.Autocompletado_Perfil(q)
            Return Json(oListaPerfil)
        End Function

#End Region

#Region "Cartera Clientes"

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarCarteraClientes() As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()

            oMantenimientoViewModel.Perfil = New Perfil()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oMantenimientoViewModel.Paginacion.ListaClienteCartera = New ListaClienteCartera()
            oMantenimientoViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursal()
            oMantenimientoViewModel.ListaPerfil = oMantenimientoBusinessLogic.ListarPerfil_Combo()
            oMantenimientoViewModel.ListaMes = oMantenimientoBusinessLogic.ListarMes()
            Return View(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarCarteraCliente_PVGrilla(
                                 Optional ByVal RUC As String = Constantes.Clear,
                                 Optional ByVal CodigoSucursal As String = Constantes.Clear,
                                 Optional ByVal Anio As String = Constantes.Clear,
                                 Optional ByVal Mes As String = Constantes.Clear,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "RUC:" & RUC & "|CodigoSucursal:" & CodigoSucursal & "|Anio:" & Anio & "|Mes:" & Mes
            Log.IdOrigenAccion = Constantes.Mantenimiento_Perfil
            Log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortBy = sort
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.ClienteCartera = New ClienteCartera()
            oMantenimientoViewModel.Paginacion.ClienteCartera.RUC = RUC
            oMantenimientoViewModel.Paginacion.ClienteCartera.CodigoSucursal = CodigoSucursal
            oMantenimientoViewModel.Paginacion.ClienteCartera.Mes = Mes
            oMantenimientoViewModel.Paginacion.ClienteCartera.Anio = Anio
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarCarteraCliente(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
            )

            Return PartialView(oMantenimientoViewModel)
        End Function

        Function GenerarReporteCarteraClientes(RUC As String, CodigoSucursal As String, Anio As String, Mes As String) As ActionResult
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic

            Dim ruta As String = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("PathArchivo"))
            Dim nombreRep As String = ConfigurationManager.AppSettings("nombreReporteUsuario").ToString()
            Dim nombreArchivo As String = nombreRep & "_" &
                                          Now.Date.ToString("dd-MM-yyyy") & "_" & ".xlsx"

            Dim rep As New ReporteVE
            Dim ListaCarteraClientes As New ListaClienteCartera

            ListaCarteraClientes = oMantenimientoBusinessLogic.ListarReporteCarteraClientes(RUC, CodigoSucursal, Anio, Mes)
            rep.GenerarReporteCarteraClientes(ListaCarteraClientes, ruta, nombreArchivo)

            Dim fileBytes As Byte() = System.IO.File.ReadAllBytes(ruta + nombreArchivo)
            Return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, nombreArchivo)
            Return Json(nombreArchivo)

        End Function

        Function GestionarCartera() As ActionResult

            Dim oMantenimientoViewModel As New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()

            oMantenimientoViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()
            oMantenimientoViewModel.ListaMes = oMantenimientoBusinessLogic.ListarMes()

            Return View(oMantenimientoViewModel)
        End Function

        Function DescargarPlantilla() As FileResult
            Dim nameFile = "PlantillaCargaMasivaClienteCartera.xlsx"
            Dim ruta = Server.MapPath("~/Files")
            Dim pathFile = Path.Combine(ruta, nameFile)
            Dim fil = System.IO.File.ReadAllBytes(pathFile)
            Return File(fil, System.Net.Mime.MediaTypeNames.Application.Octet, nameFile)

        End Function

        Function GuardarCliente(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            tmp = Session("tmpCargaMasivaClienteCartera")
            Dim Log As Log = Session("Log")
            Dim result = String.Empty
            If (oMantenimientoViewModel.ClienteCartera.Accion) Then
                result = New MantenimientoBusinessLogic().RegistraClienteCartera(tmp.ListaClienteCarteraTotal, Log)
            Else
                'result = New ProcesoBusinessLogic().DesactivaCliente(tmp.ListaClienteTotal, tmp.ListaClienteEmpleadoTotal, Log)
            End If

            Return Content(result)
        End Function

        Function CargarCMClienteCartera(Optional ByVal page As Integer = Constantes.ValorUno)
            Dim lstClienteCartera As New List(Of ClienteCartera)
            tmp = Session("tmpCargaMasivaClienteCartera")
            lstClienteCartera = tmp.ListaClienteCarteraTotal.ToList()
            tmp.ListaClienteCartera = lstClienteCartera.Skip((page - 1) * 10).Take(10).ToList()
            tmp.PaginacionCartera.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmp.PaginacionCartera.TotalRows)
            Return PartialView("PV_GestionarCartera", tmp)
        End Function

        Function CargarClienteCartera(oMantenimientoViewModel As MantenimientoViewModel, Optional ByVal page As Integer = 1) As ActionResult
            Dim oViewModel As New MantenimientoViewModel
            Dim oProcesoBusinnessLogic As New ProcesoBusinessLogic
            oViewModel.PaginacionCartera = New Paginacion
            'oViewModel.PaginacionClienteEmpleado = New Paginacion
            'oViewModel.TipoOperacion = New TipoOperacion
            Dim message As String = Constantes.Clear
            Dim grabar As String = String.Empty
            Dim file As HttpPostedFileBase = Me.HttpContext.Request.Files.[Get]("file1")
            'oViewModel.ListaTipoOperacion = oProcesoBusinnessLogic.ListaTipoOperacion()
            'oViewModel.TipoOperacion.IdTipoOperacion = oCargaClienteViewModel.TipoOperacion.IdTipoOperacion
            Dim ext As String = Path.GetExtension(file.FileName)

            If (ext = ".xls" Or ext = ".xlsx") Then

                Dim Data As Byte() = New Byte(file.ContentLength - 1) {}
                file.InputStream.Read(Data, Constantes.ValorCero, file.ContentLength)

                Dim Name As [String] = file.FileName
                If Name.LastIndexOf("\") <> -1 Then
                    Dim fin As Integer = Name.LastIndexOf("\") + 1
                    Name = Name.Substring(fin)
                End If
                Dim FileName As [String] = Server.MapPath(ConfigurationManager.AppSettings("PathArchivo") + Name)
                Dim fil As MemoryStream
                fil = New System.IO.MemoryStream(Data)

                Dim dataByte As Byte() = fil.ToArray()
                Dim fs As New FileStream(FileName, FileMode.Create)
                fs.Write(dataByte, 0, dataByte.Length)
                fs.Close()

                Dim NombreHoja As String = String.Empty
                Try
                    oViewModel.ListaProcesoCargaErrorCartera = New List(Of ClienteCartera)
                    'oViewModel.ListaProcesoCargaErrorTotales = New ListaErrorCargaMasiva
                    'oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente = New List(Of CargaMasivaCliente)
                    'oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado = New List(Of CargaMasivaCliente)

                    Dim stream As FileStream = System.IO.File.Open(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    If ext = ".xls" Then
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream, True)
                    ElseIf ext = ".xlsx" Then
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream)
                    End If
                    excelReader.IsFirstRowAsColumnNames = True

                    'CLIENTES---------------------------------------------------------------
                    Dim dsC As New DataSet()
                    NombreHoja = "Clientes"
                    dsC = excelReader.AsDataSet(True)

                    Dim dtC As New DataTable
                    Try
                        dtC = BorrarFilasVaciasCargaMasiva(dsC.Tables(NombreHoja))
                    Catch ex As Exception
                        dtC = New DataTable
                    End Try
                    '-----------------------------------------------------------------------

                    If (dtC.Rows.Count <> 0) Then
                        oViewModel.ClienteCartera = New ClienteCartera
                        oViewModel.DesAccion = If(oMantenimientoViewModel.ClienteCartera.Accion, "REGISTRA", "DESACTIVA")
                        oViewModel.DesAccionAnt = oViewModel.DesAccion
                        Dim lst As ListaCargaMasivaCliente = oProcesoBusinnessLogic.ListaPrincipal()

                        Dim i As Int32
                        Try
                            If (dtC.Rows.Count <> 0) Then
                                oViewModel.ListaClienteCartera = New List(Of ClienteCartera)
                                oViewModel.ListaClienteCarteraTotal = New List(Of ClienteCartera)

                                'PESTAÑA 1: CLIENTES
                                For i = 0 To dtC.Rows.Count - 1
                                    Dim flag0 As Boolean = True
                                    Dim flag1 As Boolean = True
                                    Dim flag2 As Boolean = True
                                    Dim flag3 As Boolean = True
                                    Dim flagNoExiste As Boolean = True
                                    Dim flagContacto As Boolean = True
                                    oViewModel.ClienteCartera = New ClienteCartera
                                    'oViewModel.ClienteCartera.ProcesoCarga = New ProcesoCarga

                                    'flagContacto = ValidarContacto(If(Convert.IsDBNull(dtC.Rows(i)(1)), String.Empty, CStr(dtC.Rows(i)(1))),
                                    '                                If(Convert.IsDBNull(dtC.Rows(i)(2)), String.Empty, CInt(dtC.Rows(i)(2))),
                                    '                                If(Convert.IsDBNull(dtC.Rows(i)(3)), String.Empty, CInt(dtC.Rows(i)(3))),
                                    '                                If(Convert.IsDBNull(dtC.Rows(i)(4)), String.Empty, CStr(dtC.Rows(i)(4))))

                                    For j = 0 To dtC.Columns.Count - 1
                                        Select Case j
                                            Case 0
                                                oViewModel.ClienteCartera.RUC = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oMantenimientoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.RUC = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 1
                                                oViewModel.ClienteCartera.CodigoSucursal = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oMantenimientoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.CodigoSucursal = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 2
                                                oViewModel.ClienteCartera.Anio = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oMantenimientoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.Anio = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 3
                                                oViewModel.ClienteCartera.Mes = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oMantenimientoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.Mes = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If
                                        End Select
                                    Next

                                    Dim ruc As Object = dtC.Rows(i)(2)
                                    Dim duplicados As Integer = 0
                                    'duplicados = (From rucs In dtC.Rows Where rucs(2).ToString().Trim() = ruc.ToString().Trim() Select rucs(2)).Count()

                                    If flag0 And flag1 And flag2 And flag3 And duplicados <= 1 Then
                                        oViewModel.ListaClienteCartera.Add(oViewModel.ClienteCartera)
                                        oViewModel.ListaClienteCarteraTotal.Add(oViewModel.ClienteCartera)
                                        'oViewModel.ListaClienteTotal.Add(oViewModel.CargaMasivaCliente)
                                    Else
                                        'Dim str As String = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError
                                        'If (Not flagNoExiste) Then
                                        '    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = " NO EXISTE "
                                        '    oViewModel.ListaProcesoCargaErrorCliente.Add(oViewModel.CargaMasivaCliente)
                                        'Else
                                        '    If duplicados > 1 Then
                                        '        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = " está duplicado."
                                        '    Else
                                        '        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = String.Format("{0} {1}", " tiene un error en la columna(s) ", str.Substring(0, str.Length - 2))
                                        '    End If
                                        '    oViewModel.ListaProcesoCargaErrorCliente.Add(oViewModel.CargaMasivaCliente)
                                        'End If
                                    End If

                                Next

                                'oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente.AddRange(oViewModel.ListaProcesoCargaErrorCliente)
                            End If

                        Catch ex As Exception
                            message = "Ocurrió un error mientras se procesaba el archivo, por favor inténtelo nuevamente. Detalle del Error: " & ex.Message
                            grabar = "NO"
                        End Try
                    Else
                        message = "El archivo seleccionado no contiene datos."
                        grabar = "NO"
                    End If

                Catch ex As Exception
                    If TypeOf ex Is OleDbException Then
                        message = "No se encontró la hoja:" & NombreHoja & " en el archivo " & file.FileName & ".Detalle del Error:" & ex.Message
                        grabar = "NO"
                    End If
                End Try

            Else
                message = "No es la extensión correcta."
                grabar = "NO"
            End If


            oViewModel.mensaje = message
            oViewModel.grabar = If(grabar.Equals(String.Empty), "SI", grabar)
            Session("tmpCargaMasivaClienteCartera") = oViewModel
            Return RedirectToAction("CargarCartera", "Mantenimiento", New With {.page = page})

        End Function

        Private Function ValidarContacto(TipoC As String, Clase As Integer, Nombre As Integer, Apellido As String) As Boolean
            If (TipoC.Equals(String.Empty) And Clase.Equals(String.Empty) And Nombre.Equals(String.Empty) And Apellido.Equals(String.Empty)) Then
                Return True
            Else
                Return False
            End If
        End Function

        Function CargarCartera(Optional ByVal page As Integer = 1) As ActionResult

            Dim lstCliente As New List(Of ClienteCartera)
            tmp = Session("tmpCargaMasivaClienteCartera")

            lstCliente = If(Not tmp.ListaClienteCarteraTotal Is Nothing, tmp.ListaClienteCarteraTotal.ToList(), New List(Of ClienteCartera))

            tmp.PaginacionCartera.Page = Constantes.ValorUno
            tmp.PaginacionCartera.RowsPerPage = Constantes.ValorDiez
            tmp.PaginacionCartera.TotalRows = If(Not tmp.ListaClienteCartera Is Nothing, tmp.ListaClienteCartera.Count(), 0)

            tmp.ListaClienteCartera = lstCliente.Skip((page - 1) * 10).Take(10).ToList()
            tmp.PaginacionCartera.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmp.PaginacionCartera.TotalRows)
            Return View("GestionarCartera", tmp)
        End Function

        Private Function BorrarFilasVaciasCargaMasiva(ByVal dt As DataTable) As DataTable
            Try
                Dim col = dt.Columns.Count
                Dim can As Integer = 0
                For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                    Dim row As DataRow = dt.Rows(i)
                    For J As Integer = col - 1 To 0 Step -1
                        If row.Item(J) Is Nothing Then
                            can += 1 'dt.Rows.Remove(row)
                        ElseIf row.Item(J).ToString = "" Then
                            can += 1 'dt.Rows.Remove(row)
                        End If
                    Next
                    If (col.Equals(can)) Then
                        dt.Rows.Remove(row)
                    End If
                    can = 0
                Next
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

#End Region

#Region "CARGOS"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarCargo() As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.Perfil = New Perfil()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oMantenimientoViewModel.Paginacion.ListaCargo = New ListaCargo()
            oMantenimientoViewModel.ListaPerfil = oMantenimientoBusinessLogic.ListarPerfil_Combo()
            Return View(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarCargo_PVGrilla(
                                 Optional ByVal NombreCargo As String = Constantes.Clear,
                                 Optional ByVal IdPerfil As Integer = Constantes.ValorCero,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "NombrePerfil:" & NombreCargo & "|IdPerfil:" & IdPerfil
            Log.IdOrigenAccion = Constantes.Mantenimiento_Cargo
            Log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortBy = sort
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.Perfil = New Perfil()
            oMantenimientoViewModel.Paginacion.Perfil.IdPerfil = IdPerfil
            oMantenimientoViewModel.Paginacion.Cargo = New Cargo()
            oMantenimientoViewModel.Paginacion.Cargo.NombreCargo = NombreCargo
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarCargos(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
            )

            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarCargo(Optional ByVal Comisiona As String = "True", Optional ByVal TipoPerfil As Integer = Constantes.ValorCero, Optional ByVal IdCargo As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.ListaPerfil = oMantenimientoBusinessLogic.ListarPerfil_Combo()
            oMantenimientoViewModel.ListaZonaMantenimiento = oMantenimientoBusinessLogic.ListaZonaMantenimiento()
            oMantenimientoViewModel.ListaCargo = New ListaCargo()
            oMantenimientoViewModel.Cargo = New Cargo()
            oMantenimientoViewModel.Cargo.Comisiona = Comisiona
            If (TipoPerfil = 2) Then
                oMantenimientoViewModel.Cargo.NombreCargoInferior = oMantenimientoBusinessLogic.NombreVendedor(IdCargo)

            End If

            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function ListaCargo_ByPerfil(Optional ByVal IdPerfil As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.ListaCargo = oMantenimientoBusinessLogic.ListarCargoByPerfil_Combo(IdPerfil)
            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function GestionarCargo_(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdCargo:" & oMantenimientoViewModel.Cargo.IdCargo &
                "|IdCargoSuperior:" & oMantenimientoViewModel.Cargo.IdCargoSuperior &
                "|IdPerfil:" & oMantenimientoViewModel.Cargo.Perfil.IdPerfil &
                "|IdZona:" & oMantenimientoViewModel.Cargo.Zona.IdZona &
                "|NombreCargo:" & oMantenimientoViewModel.Cargo.NombreCargo &
                "|Comisiona:" & oMantenimientoViewModel.Cargo.Comisiona &
                "|NombreCargoInferior:" & oMantenimientoViewModel.Cargo.NombreCargoInferior
            Log.IdOrigenAccion = Constantes.Mantenimiento_Cargo
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            'oMantenimientoViewModel.Cargo = New Cargo()
            If String.IsNullOrEmpty(oMantenimientoViewModel.Cargo.NombreCargoInferior) Then
                oMantenimientoViewModel.Cargo.NombreCargoInferior = String.Empty
                'ElseIf String.IsNullOrEmpty(oMantenimientoViewModel.Cargo.NombreCargo) Then
                '    oMantenimientoViewModel.Cargo.NombreCargo = String.Empty

            End If
            Resultado = oMantenimientoBusinessLogic.GestionarCargo_(oMantenimientoViewModel.Cargo)
            Select Case Resultado
                Case Constantes.MenosDos
                    Mensaje = "Seleccione otro cargo a reportar."
                Case Constantes.MenosUno
                    Mensaje = "El nombre del cargo ingresado ya existe."
                    'Case Constantes.Menostres
                    '    Mensaje = "El nombre de la Zona ingresada ya existe para ese cargo."
                Case Constantes.ValorCero
                    Mensaje = "Sucedió un error al registrar el cargo, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    Mensaje = "Se grabó correctamente el cargo " + oMantenimientoViewModel.Cargo.NombreCargo.ToUpper()
                Case Constantes.ValorDos
                    Mensaje = "Se actualizó correctamente el cargo " + oMantenimientoViewModel.Cargo.NombreCargo.ToUpper()
                Case Else
                    Mensaje = "Sucedió un error al registrar el cargo, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarCargo(Optional ByVal IdCargo As Integer = Constantes.ValorCero) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdCargo:" & IdCargo
            Log.IdOrigenAccion = Constantes.Mantenimiento_Cargo
            Log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            Resultado = oMantenimientoBusinessLogic.EliminarCargo(IdCargo)
            Select Case Resultado
                Case Constantes.MenosUno
                    Mensaje = "No se puede eliminar el cargo porque está asociado con otros cargos inferiores."
                Case Constantes.ValorUno
                    Mensaje = "Se eliminó correctamente el Cargo"
                Case Else
                    Mensaje = "Sucedió un error al eliminar el cargo, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function Autocompletado_Cargo(Optional ByVal q As String = Constantes.Clear) As JsonResult
            Dim oListaCargo As New ListaCargo
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oListaCargo = oMantenimientoBusinessLogic.Autocompletado_Cargo(q)
            Return Json(oListaCargo)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function Seleccion_tipoPerfil(Optional ByVal IdPerfil As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim resultado As Integer
            resultado = oMantenimientoBusinessLogic.Seleccion_tipoPerfil(IdPerfil)
            Return Content(resultado)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function Seleccionar_PerfilMayor_Menor(Optional ByVal IdPerfil As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim resultado As String = ""
            oMantenimientoViewModel.Perfil = New Perfil()
            oMantenimientoViewModel.Perfil.NombrePerfilInferior = oMantenimientoBusinessLogic.Seleccionar_PerfilMayor_Menor(IdPerfil)
            resultado = oMantenimientoViewModel.Perfil.NombrePerfilInferior
            'oMantenimientoViewModel.Perfil.NombrePerfilInferior = oMantenimientoBusinessLogic.Seleccionar_PerfilMayor_Menor(IdPerfil)
            'resultado = oMantenimientoBusinessLogic.Sel_Perfil_PerfilMenor(IdPerfil)
            Return Content(resultado)
        End Function

#End Region

#Region "ZONAS"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarZona() As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oMantenimientoViewModel.Paginacion.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            'oMantenimientoViewModel.ListaPerfil = oMantenimientoBusinessLogic.ListarPerfil_Combo()
            Return View(oMantenimientoViewModel)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarZona_PVGrilla(
                                 Optional ByVal NombreZona As String = Constantes.Clear,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "NombreZona:" & NombreZona
            Log.IdOrigenAccion = Constantes.Mantenimiento_Zonas
            Log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortBy = sort
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.ZonaMantenimiento = New ZonaMantenimiento()
            oMantenimientoViewModel.Paginacion.ZonaMantenimiento.NombreZona = NombreZona
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarZonas(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
            )

            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarZona(Optional ByVal IdZona As Integer = Constantes.ValorCero, Optional ByVal IsNacional As String = Constantes.ValorFalso) As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()

            'If IsNacional = "False" Then
            oMantenimientoViewModel.ListaSucursalSeleccionadas = oMantenimientoBusinessLogic.ListaSucursalesSeleccionadas(IdZona)
            oMantenimientoViewModel.Sucursal = New DataContracts.Sucursal()
            oMantenimientoViewModel.Sucursal.CodigoSucursal = String.Join(",", oMantenimientoViewModel.ListaSucursalSeleccionadas.Select(Function(x) x.IdSucursal.ToString()).ToArray())
            oMantenimientoViewModel.ListaSucursal = oMantenimientoBusinessLogic.ListaSucursal_Multiselect(IdZona, IIf(IsNacional = "True", 1, 0)) 'Le envio el idzona para traer las sucursales seleccionadas al Editar una Zona
            'Else
            '   oMantenimientoViewModel.ListaSucursalSeleccionadas = oMantenimientoBusinessLogic.ListaSucursalesSeleccionadas(0)
            '  oMantenimientoViewModel.ListaSucursal = oMantenimientoBusinessLogic.ListaSucursal_Multiselect(0)
            'End If
            oMantenimientoViewModel.Zona = New ZonaMantenimiento()
            oMantenimientoViewModel.Zona.IdZona = IdZona
            oMantenimientoViewModel.Zona.IsNacional = Convert.ToBoolean(IsNacional)
            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarZonaNacional(Optional ByVal IdZona As Integer = Constantes.ValorCero, Optional ByVal IsNacional As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()

            oMantenimientoViewModel.ListaSucursalSeleccionadas = oMantenimientoBusinessLogic.ListaSucursalesSeleccionadas(IdZona)

            oMantenimientoViewModel.Sucursal = New DataContracts.Sucursal()
            oMantenimientoViewModel.Sucursal.CodigoSucursal = String.Join(",", oMantenimientoViewModel.ListaSucursalSeleccionadas.Select(Function(x) x.IdSucursal.ToString()).ToArray())
            oMantenimientoViewModel.ListaSucursal = oMantenimientoBusinessLogic.ListaSucursal_Multiselect(IdZona, IsNacional)

            oMantenimientoViewModel.Zona = New ZonaMantenimiento()
            oMantenimientoViewModel.Zona.IdZona = IdZona
            oMantenimientoViewModel.Zona.IsNacional = Convert.ToBoolean(IsNacional)
            Return PartialView("PVZona_Combo", oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarZona(Optional ByVal IdZona As Integer = Constantes.ValorCero) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdZona:" & IdZona
            Log.IdOrigenAccion = Constantes.Mantenimiento_Zonas
            Log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            Resultado = oMantenimientoBusinessLogic.EliminarZona(IdZona)
            Select Case Resultado
                Case Constantes.MenosUno
                    Mensaje = "No se puede eliminar la zona, ya que está asociado a un cargo"
                Case Constantes.ValorUno
                    Mensaje = "Se eliminó correctamente la zona"
                Case Else
                    Mensaje = "Sucedió un error al eliminar el cargo, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function Autocompletado_Zona(Optional ByVal q As String = Constantes.Clear) As JsonResult
            Dim oListaZona As New ListaZonaMantenimiento
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oListaZona = oMantenimientoBusinessLogic.Autocompletado_Zona(q)
            Return Json(oListaZona)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function GestionarZona_(oViewModel As MantenimientoViewModel) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdZona:" & oViewModel.Zona.IdZona &
                "|IsNacional:" & oViewModel.Zona.IsNacional &
                "|NombreZona:" & oViewModel.Zona.NombreZona &
                "|IdSucursales:" & String.Join(",", oViewModel.Sucursal.CodigosSucursales)
            Log.IdOrigenAccion = Constantes.Mantenimiento_Zonas
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            Resultado = oMantenimientoBusinessLogic.GestionarZona_(oViewModel.Zona.IdZona, oViewModel.Zona.NombreZona, oViewModel.Zona.IsNacional, String.Join(",", oViewModel.Sucursal.CodigosSucursales))
            Select Case Resultado
                Case Constantes.MenosUno
                    Mensaje = "El nombre de la zona ingresado ya existe."
                Case Constantes.ValorCero
                    Mensaje = "Sucedió un error al registrar la zona, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    Mensaje = "Se grabó correctamente la zona " + oViewModel.Zona.NombreZona.ToUpper()
                Case Constantes.ValorDos
                    Mensaje = "Se actualizó correctamente la zona " + oViewModel.Zona.NombreZona.ToUpper()
                Case Else
                    Mensaje = "Sucedió un error al registrar  la zona, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function
#End Region

#Region "Sucursales"
        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarSucursales_PVGrilla(Optional ByVal IdZona As Integer = Constantes.ValorCero,
                                              Optional ByVal NombreSucursal As String = Constantes.Clear,
                                              Optional ByVal page As Integer = Constantes.FirstPage,
                                              Optional ByVal sortDir As String = Constantes.Clear,
                                              Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortBy = sort
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.ZonaMantenimiento = New ZonaMantenimiento()
            oMantenimientoViewModel.Paginacion.ZonaMantenimiento.IdZona = IdZona
            oMantenimientoViewModel.Paginacion.SucursalMantenimiento = New SucursalMantenimiento()
            oMantenimientoViewModel.Paginacion.SucursalMantenimiento.Descripcion = NombreSucursal
            oMantenimientoViewModel.Paginacion.ListaSucursalMantenimiento = New ListaSucursalMantenimiento()
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarSucursales(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                 oMantenimientoViewModel.Paginacion.PageNumber,
                 oMantenimientoViewModel.Paginacion.PageSize,
                 oMantenimientoViewModel.Paginacion.TotalRows
                )

            Return PartialView(oMantenimientoViewModel)
        End Function

        'Function ConsultarCargo_PVGrilla(
        '                         Optional ByVal NombreCargo As String = Constantes.Clear,
        '                         Optional ByVal IdPerfil As Integer = Constantes.ValorCero,
        '                         Optional ByVal page As Integer = Constantes.FirstPage,
        '                         Optional ByVal sortDir As String = Constantes.Clear,
        '                         Optional ByVal sort As String = Constantes.Clear) As ActionResult

        '    Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
        '    Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
        '    oMantenimientoViewModel.Paginacion = New Paginacion()
        '    oMantenimientoViewModel.Paginacion.PageNumber = page
        '    oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
        '    oMantenimientoViewModel.Paginacion.SortBy = sort
        '    oMantenimientoViewModel.Paginacion.SortType = sortDir
        '    oMantenimientoViewModel.Paginacion.Perfil = New Perfil()
        '    oMantenimientoViewModel.Paginacion.Perfil.IdPerfil = IdPerfil
        '    oMantenimientoViewModel.Paginacion.Cargo = New Cargo()
        '    oMantenimientoViewModel.Paginacion.Cargo.NombreCargo = NombreCargo
        '    oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarCargos(oMantenimientoViewModel.Paginacion)

        '    oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
        '        oMantenimientoViewModel.Paginacion.PageNumber,
        '        oMantenimientoViewModel.Paginacion.PageSize,
        '        oMantenimientoViewModel.Paginacion.TotalRows
        '    )

        '    Return PartialView(oMantenimientoViewModel)

        <RequiresAuthenticationAttribute()>
        Function BuscarSucursales() As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion = New Paginacion() With {
               .PageNumber = Constantes.ValorUno,
               .PageSize = Constantes.ValorDiez,
               .TotalRows = Constantes.ValorCero
           }
            oMantenimientoViewModel.Paginacion.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oMantenimientoViewModel.Paginacion.ListaSucursalMantenimiento = New ListaSucursalMantenimiento()
            oMantenimientoViewModel.ListaZonaMantenimiento = oMantenimientoBusinessLogic.ListaZonaMantenimiento()
            Return View(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function Autocompletado_Sucursal(Optional ByVal su As String = Constantes.Clear) As JsonResult
            Dim oListaSucursalMantenimiento As New ListaSucursalMantenimiento
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oListaSucursalMantenimiento = oMantenimientoBusinessLogic.Autocompletado_Sucursal(su)
            Return Json(oListaSucursalMantenimiento)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarSucursal() As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.ListaDepartamento = oMantenimientoBusinessLogic.ConsultarDepartamento()
            oMantenimientoViewModel.ListaProvincia = New ListaProvincia()
            oMantenimientoViewModel.ListaDistrito = New ListaDistrito()
            Return (PartialView(oMantenimientoViewModel))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ListarProvincia(IdDepartamento As Integer) As ActionResult
            Dim oMantenimientoViewModel As New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.ListaProvincia = oMantenimientoBusinessLogic.ConsultarProvinciaDepartamento(IdDepartamento)
            Return PartialView(ParametrosPartialView.PVSucursal_Provincia_Dep, oMantenimientoViewModel)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ListarDistrito(IdProvincia As Integer) As ActionResult
            Dim oMantenimientoViewModel As New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.ListaDistrito = oMantenimientoBusinessLogic.ConsultarDistritoProvincia(IdProvincia)
            Return PartialView(ParametrosPartialView.PVSucursal_Distrito_Combo, oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function GestionarSucursal_(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            'If String.IsNullOrEmpty(oMantenimientoViewModel.Cargo.NombreCargoInferior) Then
            '    oMantenimientoViewModel.Cargo.NombreCargoInferior = String.Empty
            'End If
            Resultado = oMantenimientoBusinessLogic.GestionarSucursal_(oMantenimientoViewModel.SucursalMantenimiento)
            Select Case Resultado
                Case Constantes.MenosDos
                    Mensaje = "Seleccione otro cargo a reportar."
                Case Constantes.MenosUno
                    Mensaje = "El nombre de la Sucursal ingresado ya existe."
                    'Case Constantes.Menostres
                    '    Mensaje = "El nombre de la Zona ingresada ya existe para ese cargo."
                Case Constantes.ValorCero
                    Mensaje = "Sucedió un error al registrar el cargo, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    Mensaje = "Se grabó correctamente la sucursal " + oMantenimientoViewModel.SucursalMantenimiento.Descripcion.ToUpper()
                Case Constantes.ValorDos
                    Mensaje = "Se actualizó correctamente el sucursal " + oMantenimientoViewModel.SucursalMantenimiento.Descripcion.ToUpper()
                Case Else
                    Mensaje = "Sucedió un error al registrar el cargo, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarSucursal(Optional ByVal IdSucursal As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            Resultado = oMantenimientoBusinessLogic.EliminarSucursal(IdSucursal)
            Select Case Resultado
                Case Constantes.MenosUno
                    Mensaje = "No se puede eliminar la sucursal porque está asociado a una zona."
                Case Constantes.ValorUno
                    Mensaje = "Se eliminó correctamente la sucursal"
                Case Else
                    Mensaje = "Sucedió un error al eliminar la sucursal, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function




#End Region

#Region "GRUPOS"

        <RequiresAuthenticationAjaxAttribute()>
        Function PVListaClientes_Grupo(Optional ByVal IdGrupo As Integer = Constantes.ValorCero,
                                       Optional ByVal page As Integer = Constantes.FirstPage,
                                       Optional ByVal sortDir As String = Constantes.Clear,
                                       Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()

            'oVentasViewModel.Paginacion.ListaSucursalEmpleado = New ListaSucursalEmpleado()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.ListaGrupoClienteMantenimiento = New ListaGrupoClienteMantenimiento()
            ' oMantenimientoViewModel.Paginacion.ListaGrupo = New ListaGrupo()


            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortBy = sort
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.Grupo = New Grupo()
            oMantenimientoViewModel.Paginacion.Grupo.IdGrupo = IdGrupo

            ' oMantenimientoViewModel.Paginacion.ListaGrupoClienteMantenimiento = New ListaGrupoClienteMantenimiento()
            ' oMantenimientoViewModel.ListaGrupoClienteMantenimiento = New ListaGrupoClienteMantenimiento()
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListaClientesGrupo(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
             oMantenimientoViewModel.Paginacion.PageNumber,
             oMantenimientoViewModel.Paginacion.PageSize,
             oMantenimientoViewModel.Paginacion.TotalRows)

            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ListadoGrupos(Optional ByVal IdGrupo As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()

            oMantenimientoViewModel.Grupo = New Grupo()
            oMantenimientoViewModel.Grupo.IdGrupo = IdGrupo
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.ListaGrupoClienteMantenimiento = New ListaGrupoClienteMantenimiento()

            Return View(oMantenimientoViewModel)

        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarGrupo() As ActionResult
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oMantenimientoViewModel.Paginacion.ListaGrupo = New ListaGrupo()
            Return View(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarGrupo_PVGrilla(Optional ByVal NombreGrupo As String = Constantes.Clear,
                                         Optional ByVal page As Integer = Constantes.FirstPage,
                                         Optional ByVal sortDir As String = Constantes.Clear,
                                         Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "NombreGrupo:" & NombreGrupo
            Log.IdOrigenAccion = Constantes.Mantenimiento_Grupos
            Log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortBy = sort
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.Grupo = New Grupo()
            oMantenimientoViewModel.Paginacion.Grupo.NombreGrupo = NombreGrupo
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarGrupos(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
             oMantenimientoViewModel.Paginacion.PageNumber,
             oMantenimientoViewModel.Paginacion.PageSize,
             oMantenimientoViewModel.Paginacion.TotalRows)

            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarGrupo(Optional ByVal IdGrupo As Integer = Constantes.ValorCero) As ActionResult
            Dim razon As String = ""
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            If IdGrupo = 0 Then
                oMantenimientoViewModel.ListaClienteVenta = oMantenimientoBusinessLogic.ListaClientes_Multiselect(IdGrupo)
                oMantenimientoViewModel.ListaClientesSeleccionadas = oMantenimientoBusinessLogic.ListaClientesSeleccionados(IdGrupo)
            Else
                oMantenimientoViewModel.ListaClienteVenta = oMantenimientoBusinessLogic.ListaClientes_Multiselect(0)
                oMantenimientoViewModel.ListaClientesSeleccionadas = oMantenimientoBusinessLogic.ListaClientesSeleccionados(IdGrupo)
            End If

            oMantenimientoViewModel.Grupo = New Grupo()
            oMantenimientoViewModel.Grupo.IdGrupo = IdGrupo
            oMantenimientoViewModel.Paginacion = UtilWebGrid.Paginacion_PorDefecto()
            ' oMantenimientoViewModel.Grupo.ClienteVenta.RazonSocial = razon
            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function GestionarGrupo_(Optional ByVal IdGrupo As Integer = Constantes.ValorCero, Optional ByVal NombreGrupo As String = Constantes.ValorDefecto, Optional ByVal IdClientes As String = Constantes.ValorDefecto) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdGrupo:" & IdGrupo &
                "|IdNombreGrupo:" & NombreGrupo &
                "|IdClientes" & IdClientes
            Log.IdOrigenAccion = Constantes.Mantenimiento_Grupos
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            Resultado = oMantenimientoBusinessLogic.GestionarGrupo_(IdGrupo, NombreGrupo, IdClientes)
            Select Case Resultado
                Case Constantes.MenosUno
                    Mensaje = "El nombre del grupo ingresado ya existe."
                Case Constantes.ValorCero
                    Mensaje = "Sucedió un error al registrar la grupo, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    Mensaje = "Se grabó correctamente el grupo " + NombreGrupo.ToUpper()
                Case Constantes.ValorDos
                    Mensaje = "Se actualizó correctamente el grupo " + NombreGrupo.ToUpper()
                Case Else
                    Mensaje = "Sucedió un error al registrar  el grupo, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function Autocompletado_Grupo(Optional ByVal q As String = Constantes.Clear) As ActionResult
            Dim oListaGrupo As New ListaGrupo
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oListaGrupo = oMantenimientoBusinessLogic.Autocompletado_Grupo(q)
            Return Json(oListaGrupo)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarGrupo(Optional ByVal IdGrupo As Integer = Constantes.ValorCero) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdGrupo:" & IdGrupo
            Log.IdOrigenAccion = Constantes.Mantenimiento_Grupos
            Log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero
            Resultado = oMantenimientoBusinessLogic.EliminarGrupo(IdGrupo)
            Select Case Resultado
                Case Constantes.MenosUno
                    Mensaje = "No se puede eliminar el Grupo, ya que está asociado a un Cliente"
                Case Constantes.ValorUno
                    Mensaje = "Se eliminó correctamente el Grupo"
                Case Else
                    Mensaje = "Sucedió un error al eliminar el cargo, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function PVListaClientes(
            Optional ByVal RazonSocial As String = Constantes.Clear,
            Optional ByVal sortdir As String = Constantes.ValorDefecto,
            Optional ByVal sort As String = Constantes.ValorDefecto,
            Optional ByVal page As Integer = Constantes.ValorUno) As ActionResult
            Dim oClientesViewModel As New MantenimientoViewModel()
            Dim oClienteBusinessLogic As New ClienteBusinessLogic()

            oClientesViewModel.Paginacion = New Paginacion()
            oClientesViewModel.Paginacion.ListaClienteVenta = New ListaClienteVenta()

            oClientesViewModel.Paginacion = UtilWebGrid.Paginacion_PorDefecto()
            oClientesViewModel.Paginacion.ClienteVenta = New ClienteVenta()
            oClientesViewModel.Paginacion.ClienteVenta.RazonSocial = RazonSocial

            oClientesViewModel.Paginacion.ClienteVenta.ProcesoEstado = New ProcesoEstado()
            oClientesViewModel.Paginacion.ClienteVenta.ProcesoEstado.IdEstado = Constantes.ValorCero
            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoDepartamento = New EmpleadoDepartamento()
            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoDepartamento.IdDepartamento = Constantes.ValorCero

            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoProvincia = New EmpleadoProvincia()
            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoProvincia.IdProvincia = Constantes.ValorCero

            oClientesViewModel.Paginacion.ClienteVenta.ClienteSector = New ClienteSector()
            oClientesViewModel.Paginacion.ClienteVenta.ClienteSector.IdClienteSector = Constantes.ValorCero

            oClientesViewModel.Paginacion.ClienteVenta.ClienteCategoria = New ClienteCategoria()
            oClientesViewModel.Paginacion.ClienteVenta.ClienteCategoria.IdClienteCategoria = Constantes.ValorCero

            oClientesViewModel.Paginacion.ClienteVenta.ClienteTipo = New ClienteTipo()
            oClientesViewModel.Paginacion.ClienteVenta.ClienteTipo.IdClienteTipo = Constantes.ValorCero
            oClientesViewModel.Paginacion.ClienteVenta.IdModoPago = Constantes.ValorCero
            oClientesViewModel.Paginacion.SortType = sortdir
            oClientesViewModel.Paginacion.SortBy = sort
            oClientesViewModel.Paginacion.PageSize = Constantes.ValorCinco
            oClientesViewModel.Paginacion.PageNumber = page

            oClientesViewModel.Paginacion = oClienteBusinessLogic.BuscarCliente(oClientesViewModel.Paginacion)

            oClientesViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                 oClientesViewModel.Paginacion.PageNumber,
                 oClientesViewModel.Paginacion.PageSize,
                 oClientesViewModel.Paginacion.TotalRows
             )
            Return PartialView("PVListaClientes", oClientesViewModel)
        End Function

#End Region

#Region "Proveedor"

        <RequiresAuthentication()>
        Function GestionarProveedor() As ActionResult
            Dim model = New ProveedorViewModel()
            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic

            model.Paginacion = New Paginacion
            model.Paginacion.Page = 1
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = model.sortDir
            model.Paginacion.SortType = model.sort

            model.ListaEmpresa = New ReporteBusinessLogic().ListarEmpresas
            model.ListaEstado = oMantenimientoBusinessLogic.ListarEstadoProveedor()
            model.ListaProveedor = New List(Of Proveedor)

            Return View(model)
        End Function

        <RequiresAuthenticationAjax()>
        Function ConsultaProveedor(ByVal model As ProveedorViewModel) As ActionResult

            Dim rowCount As Integer = 0
            model.Paginacion = New Paginacion
            model.Paginacion.Page = If(model.page = 0, 1, model.page)
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = If(model.sortDir = Nothing, String.Empty, model.sortDir)
            model.Paginacion.SortType = If(model.sort = Nothing, String.Empty, model.sort)
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdEmpresa:" & model.Proveedor.IdEmpresa & "|Ruc:" & model.Proveedor.Ruc & "|RazonSocial:" & model.Proveedor.RazonSocial & "|EstadoP:" & model.Proveedor.EstadoP
            Log.IdOrigenAccion = Constantes.Mantenimiento_Proveedor
            Log.IdLogAccion = Constantes.Buscar
            'METODO Q LLENA TU LISTA
            model.ListaProveedor = New MantenimientoBusinessLogic(True, Log).BuscarProveedor(model.Proveedor, model.Paginacion, rowCount)


            model.Paginacion.TotalRows = rowCount
            model.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(model.page, 10, rowCount)

            Return PartialView("_Grid", model)
        End Function

        <HttpGet()>
        Function NuevoProveedor() As ActionResult
            Dim model = New ProveedorViewModel
            model.ListaEmpresa = New ReporteBusinessLogic().ListarEmpresas
            Return PartialView("_Nuevo", model)
        End Function

        <HttpPost()>
        Function RegistrarProveedor(model As ProveedorViewModel) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Ruc:" & model.Proveedor.Ruc &
                "|Razón Social:" & model.Proveedor.RazonSocial &
                "|Numero:" & model.Proveedor.Numero &
                "|Dirección:" & model.Proveedor.Direccion &
                "|IdEmpresa:" & model.Proveedor.IdEmpresa
            Log.IdOrigenAccion = Constantes.Mantenimiento_Proveedor
            Log.IdLogAccion = Constantes.Insertar

            Dim result = New MantenimientoBusinessLogic(True, Log).InsertarProveedor(model.Proveedor)
            If result > 0 Then
                Return Content("Registrado correctamente.")
            ElseIf result = -1 Then
                Return Content("El Ruc ingreso ya es existente.")
            Else
                Return Content("Error al registrar.")
            End If
        End Function

        <HttpGet()>
        Function EditarProveedor(id As Integer) As ActionResult
            Dim model = New ProveedorViewModel
            model.ListaEmpresa = New ReporteBusinessLogic().ListarEmpresas
            model.Proveedor = New MantenimientoBusinessLogic().GetProveedor(id)
            Return PartialView("_Editar", model)
        End Function

        <HttpPost()>
        Function ActualizarProveedor(model As ProveedorViewModel) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Ruc:" & model.Proveedor.Ruc &
                "|Razón Social:" & model.Proveedor.RazonSocial &
                "|Numero:" & model.Proveedor.Numero &
                "|Dirección:" & model.Proveedor.Direccion &
                "|IdEmpresa:" & model.Proveedor.IdEmpresa &
                "|IdProveedor:" & model.Proveedor.IdProveedor
            Log.IdOrigenAccion = Constantes.Mantenimiento_Proveedor
            Log.IdLogAccion = Constantes.Modificar
            Dim result = New MantenimientoBusinessLogic(True, Log).ActualizarProveedor(model.Proveedor)
            If result > 0 Then
                Return Content("Cambios realizados correctamente.")
            ElseIf result = -1 Then
                Return Content("El Ruc ingreso ya es existente.")
            Else
                Return Content("Error al registrar.")
            End If
        End Function

        <HttpGet()>
        Function EliminarProveedor(id As Integer) As ActionResult
            Dim model = New ProveedorViewModel
            model.ListaEmpresa = New ReporteBusinessLogic().ListarEmpresas
            model.Proveedor = New MantenimientoBusinessLogic().GetProveedor(id)
            ViewBag.Estado = If(model.Proveedor.Estado, "desactivar", "activar")
            ViewBag.Boton = If(model.Proveedor.Estado, "Desactivar", "Activar")
            Return PartialView("_Eliminar", model)
        End Function

        <HttpPost()>
        Function EliminarProveedor(model As ProveedorViewModel) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "|IdProveedor:" & CStr(model.Proveedor.IdProveedor)
            Log.IdOrigenAccion = Constantes.Mantenimiento_Proveedor
            Log.IdLogAccion = Constantes.Eliminar
            Dim result = New MantenimientoBusinessLogic(True, Log).ActualizarProveedorEstado(model.Proveedor)
            If (result > 0) Then
                Return Content("Se realizó el cambio correctamente")
            ElseIf result = -1 Then
                Return Content("No se realizaron Cambios, Proveedor no existe")
            Else
                Return Content("Error")
            End If
        End Function

#End Region

#Region "Producto"

        <HttpGet()>
        Function AsociarSku(id As Integer) As ActionResult
            Dim model As New ProveedorViewModel
            model.Proveedor = New MantenimientoBusinessLogic().GetProveedor(id)
            'model.ListaProducto = New MantenimientoBusinessLogic().ListarProductos(id)
            model.ListaProducto = New List(Of Producto)()
            model.Paginacion = New Paginacion
            model.Paginacion.Page = 1
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = model.sortDir
            model.Paginacion.SortType = model.sort
            Return PartialView("_AsociarSku", model)
        End Function

        <RequiresAuthenticationAjax()>
        Function ConsultaSku(ByVal model As ProveedorViewModel) As ActionResult
            Dim rowCount As Integer
            model.Paginacion = New Paginacion
            model.Paginacion.Page = If(model.page = 0, 1, model.page)
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = If(model.sortDir = Nothing, String.Empty, model.sortDir)
            model.Paginacion.SortType = If(model.sort = Nothing, String.Empty, model.sort)
            model.Proveedor.Sku = If(model.Proveedor.Sku = Nothing, String.Empty, model.Proveedor.Sku)

            'METODO Q LLENA TU LISTA
            model.ListaProducto = New MantenimientoBusinessLogic().ListarProductos(model.Proveedor, model.Paginacion, rowCount)
            model.Paginacion.TotalRows = rowCount
            model.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(model.page, 10, rowCount)
            Return PartialView("_GridSku", model)
        End Function

        <RequiresAuthenticationAjax()>
        Function EliminarSkuProv(Sku As String, Estado As Boolean, IdProv As Integer) As ActionResult

            Dim result = New MantenimientoBusinessLogic().ActualizarSkuProveedorEstado(Sku, IdProv, Estado)
            If (result > 0) Then
                Return Content("Se realizó el cambio correctamente")
            ElseIf result = -1 Then
                Return Content("No se realizaron Cambios, Proveedor no existe")
            Else
                Return Content("Error")
            End If
        End Function

        <RequiresAuthenticationAjax()>
        Function AgregarSkuProveedor(ByVal model As ProveedorViewModel) As ActionResult
            model.Paginacion = New Paginacion
            model.Paginacion.Page = 1
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = model.sortDir
            model.Paginacion.SortType = model.sort
            model.ListaProducto = New List(Of Producto)
            Return PartialView("_AgregarSkuProveedor", model)
        End Function

        <RequiresAuthenticationAjax()>
        Function ConsultaSkuProductos(ByVal model As ProveedorViewModel) As ActionResult
            Dim rowCount As Integer
            model.Paginacion = New Paginacion
            model.Paginacion.Page = If(model.page = 0, 1, model.page)
            model.Paginacion.RowsPerPage = 5
            model.Paginacion.SortBy = If(model.sortDir = Nothing, String.Empty, model.sortDir)
            model.Paginacion.SortType = If(model.sort = Nothing, String.Empty, model.sort)
            model.Producto.Sku = If(model.Producto.Sku = Nothing, String.Empty, model.Producto.Sku)
            model.Producto.Descripcion = If(model.Producto.Descripcion = Nothing, String.Empty, model.Producto.Descripcion)

            'METODO Q LLENA TU LISTA
            model.ListaProducto = New MantenimientoBusinessLogic().ListarProductosSeleccionar(model.Producto, model.Proveedor, model.Paginacion, rowCount)
            model.Paginacion.TotalRows = rowCount
            model.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(model.page, 5, rowCount)
            Return PartialView("_GridProductosBusqueda", model)
        End Function

        Function ConfirmarSkuProv(model As ProveedorViewModel) As ActionResult
            If (model.Producto.Item Is Nothing) Then
                Return Content("No existen productos para grabar")
            Else
                Dim result = New MantenimientoBusinessLogic().InsertarProveedorSku(model.Producto, model.Proveedor)
                If result > 0 Then
                    Return Content("Registrado correctamente.")
                ElseIf result = -1 Then
                    Return Content("El Ruc ingreso ya es existente.")
                Else
                    Return Content("Error al registrar.")
                End If
            End If
        End Function

#End Region

#Region "Feriados"
        <RequiresAuthentication()>
        Function GestionarFeriados() As ActionResult
            Dim model = New FeriadosViewModel()
            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic

            model.Paginacion = New Paginacion
            model.Paginacion.Page = 1
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = model.sortDir
            model.Paginacion.SortType = model.sort

            model.ListaMes = oMantenimientoBusinessLogic.ListarMes()
            model.ListaEstado = oMantenimientoBusinessLogic.ListarEstado()

            model.ListaFeriados = New List(Of Feriados)

            Return View(model)
        End Function

        <RequiresAuthenticationAjax()>
        Function ConsultaFeriados(ByVal model As FeriadosViewModel) As ActionResult

            Dim rowCount As Integer = 0
            Dim busqMes As String = String.Empty
            Dim busqEstado As String = String.Empty
            Dim arrayMes() As String = {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"}
            Dim arrayEstado() As String = {"INACTIVO", "ACTIVO"}

            model.Paginacion = New Paginacion
            model.Paginacion.Page = If(model.page = 0, 1, model.page)
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = If(model.sortDir = Nothing, String.Empty, model.sortDir)
            model.Paginacion.SortType = If(model.sort = Nothing, String.Empty, model.sort)

            model.Feriados.BusqMes = model.MesMulti

            If Not model.MesMulti Is Nothing Or Not model.MesMulti = String.Empty Then
                Dim splitMes As String() = model.MesMulti.Split(New Char() {","c})
                For index = 0 To splitMes.Length - 1
                    busqMes += arrayMes(index) & ", "
                    If index = splitMes.Length - 1 Then
                        busqMes = busqMes.Substring(0, busqMes.Length - 2)
                    End If
                Next
            End If

            If model.Feriados.BusqEstado Is Nothing Or model.Feriados.BusqEstado = String.Empty Then
                busqEstado = "TODOS"
            Else
                busqEstado = arrayEstado(Integer.Parse(model.Feriados.BusqEstado))
            End If

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Mes: " & busqMes & "| Modalidad: " & model.Feriados.BusqModalidad & " | Estado: " & busqEstado
            Log.IdOrigenAccion = Constantes.Mantinimiento_CalendarioFeriados
            Log.IdLogAccion = Constantes.Buscar
            Dim MantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)


            model.ListaFeriados = MantenimientoBusinessLogic.BuscarFeriados(model.Feriados, model.Paginacion, rowCount)

            model.Paginacion.TotalRows = rowCount
            model.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(model.page, 10, rowCount)

            Return PartialView("_GridFeriados", model)
        End Function

        <HttpGet()>
        Function NuevoFeriado() As ActionResult
            Dim model = New FeriadosViewModel
            model.ListaMes = New MantenimientoBusinessLogic().ListarMes
            Return PartialView("_NuevoFeriado", model)
        End Function

        <HttpPost()>
        Function RegistrarFeriado(model As FeriadosViewModel) As ActionResult

            Dim arrayMes() As String = {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"}

            If model.OpcionModalidad = True Then
                model.Feriados.Anio = 0
            End If

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Mes: " & arrayMes(model.Feriados.Mes - 1) & " | Día: " & model.Feriados.Dia & " | Descripción: " & model.Feriados.Descripcion & " | Modalidad: " & IIf(model.OpcionModalidad, "Todos los años", model.Feriados.Anio.ToString())
            Log.IdOrigenAccion = Constantes.Mantinimiento_CalendarioFeriados
            Log.IdLogAccion = Constantes.Insertar
            Dim MantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim result = MantenimientoBusinessLogic.InsertarFeriados(model.Feriados)
            If result > 0 Then
                Return Content("Registrado correctamente.")
            ElseIf result = -1 Then
                Return Content("Los datos ya existen.")
            Else
                Return Content("Error al registrar.")
            End If
        End Function

        <HttpGet()>
        Function EditarFeriado(id As Integer) As ActionResult
            Dim model = New FeriadosViewModel
            model.ListaMes = New MantenimientoBusinessLogic().ListarMes()
            model.Feriados = New MantenimientoBusinessLogic().GetFeriado(id)
            Return PartialView("_EditarFeriado", model)
        End Function

        <HttpPost()>
        Function ActualizarFeriado(model As FeriadosViewModel) As ActionResult
            Dim arrayMes() As String = {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"}

            If model.OpcionModalidad = True Then
                model.Feriados.Anio = 0
            End If

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Codigo: " & model.Feriados.IdFeriado & " | Mes: " & arrayMes(model.Feriados.Mes - 1) & " | Día: " & model.Feriados.Dia & " | Descripción: " & model.Feriados.Descripcion & " | Modalidad: " & IIf(model.OpcionModalidad, "Todos los años", model.Feriados.Anio.ToString())
            Log.IdOrigenAccion = Constantes.Mantinimiento_CalendarioFeriados
            Log.IdLogAccion = Constantes.Modificar
            Dim MantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim result = MantenimientoBusinessLogic.ActualizarFeriado(model.Feriados)
            If result > 0 Then
                Return Content("Cambios realizados correctamente.")
            ElseIf result = -1 Then
                Return Content("Los datos ya existen.")
            Else
                Return Content("Error al registrar.")
            End If
        End Function

        <HttpGet()>
        Function EliminarFeriado(id As Integer) As ActionResult
            Dim model = New FeriadosViewModel
            'model.ListaMes = New MantenimientoBusinessLogic().ListarMes
            model.Feriados = New MantenimientoBusinessLogic().GetFeriado(id)
            ViewBag.Estado = If(model.Feriados.Activo, "desactivar", "activar")
            ViewBag.Boton = If(model.Feriados.Activo, "Desactivar", "Activar")
            Return PartialView("_EliminarFeriado", model)
        End Function

        <HttpPost()>
        Function EliminarFeriado(model As FeriadosViewModel) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Codigo: " & model.Feriados.IdFeriado.ToString() & " | Estado: " & IIf(model.Feriados.Activo, "INACTIVO", "ACTIVO")
            Log.IdOrigenAccion = Constantes.Mantinimiento_CalendarioFeriados
            Select Case model.Feriados.Activo
                Case True
                    Log.IdLogAccion = Constantes.Desactivar
                Case False
                    Log.IdLogAccion = Constantes.Activar
            End Select
            Dim MantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim result = MantenimientoBusinessLogic.ActualizarFeriadoEstado(model.Feriados)
            If (result > 0) Then
                Return Content("Se " & IIf(model.Feriados.Activo, "activo", "inactivo") & " correctamente")
            ElseIf result = -1 Then
                Return Content("No se realizaron Cambios, Feriado no existe")
            Else
                Return Content("Error")
            End If
        End Function

#End Region

#Region "FECHA DE CIERRES"

        <RequiresAuthentication()>
        Function GestionarCierre() As ActionResult
            Dim model As New CierreViewModel()
            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic
            model.Cierre = New Cierre()
            model.Paginacion = New Paginacion
            model.Paginacion.Page = 1
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = model.sortDir
            model.Paginacion.SortType = model.sort

            model.ListaMes = oMantenimientoBusinessLogic.ListarMes()
            model.ListaAño = oMantenimientoBusinessLogic.ListarAño()
            model.Cierre.Año = System.DateTime.Now.Year
            model.ListaCierre = New List(Of Cierre)

            Return View(model)
        End Function

        Function ConsultarCierre(ByVal model As CierreViewModel) As ActionResult
            Dim rowCount As Integer = 0
            Dim busqMes As String = String.Empty

            model.Paginacion = New Paginacion
            model.Paginacion.Page = If(model.page = 0, 1, model.page)
            model.Paginacion.RowsPerPage = 10
            model.Paginacion.SortBy = If(model.sortDir = Nothing, String.Empty, model.sortDir)
            model.Paginacion.SortType = If(model.sort = Nothing, String.Empty, model.sort)

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Año: " & model.Cierre.Año & " | Mes: " & model.Cierre.NombreMes & " | Fecha: " & model.Cierre.FechaCierre
            Log.IdOrigenAccion = Constantes.Mantenimiento_CalendarioCierre
            Log.IdLogAccion = Constantes.Buscar
            Dim MantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            model.ListaCierre = New MantenimientoBusinessLogic().BuscarCierre(model.Cierre, model.Paginacion, rowCount)
            model.Paginacion.TotalRows = rowCount
            model.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(model.page, 10, rowCount)

            Return PartialView("_GridCierre", model)
        End Function

        <HttpGet()>
        Function RegistrarCierre() As ActionResult
            Dim model = New CierreViewModel
            model.ListaMes = New MantenimientoBusinessLogic().ListarMes()
            model.ListaAño = New MantenimientoBusinessLogic().ListarAño()
            Return PartialView("_RegistrarCierre", model)
        End Function

        <HttpPost()>
        Function RegistrarCierre(model As CierreViewModel) As ActionResult
            model.Cierre.UsuarioRegistro = Session("User")
            model.Cierre.UsuarioUpdate = Session("User")

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "Año: " & model.Cierre.Año & " | Mes: " & model.Cierre.NombreMes & " | Fecha: " & model.Cierre.FechaCierre
            Log.IdOrigenAccion = Constantes.Mantenimiento_CalendarioCierre
            Log.IdLogAccion = Constantes.Insertar

            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic(True, Log)

            Dim result As Int32 = oMantenimientoBusinessLogic.RegistrarCierre(model.Cierre)
            Dim mensaje As String = ""
            If (result > 0) Then
                mensaje = "Se registró correctamente."
            Else
                If (result = -1) Then
                    mensaje = "Los datos ya existen."
                Else
                    mensaje = "Error al registrar."
                End If
            End If
            Return Content(mensaje)
        End Function

        Function EliminarCierre(idCierre As Integer) As ActionResult
            Dim Log As Log = Session("Log")
            Log.IdOrigenAccion = Constantes.Mantenimiento_CalendarioCierre
            Log.IdLogAccion = Constantes.Eliminar
            Dim _cierre = New MantenimientoBusinessLogic(True, Log).EliminarCierre(idCierre)
            If _cierre.Cont > 0 Then
                Return Content("Error al Eliminar")
            Else
                Return Content("Registro Eliminado.")
            End If
        End Function

#End Region

#Region "REGISTRO BOLETA"

        Function RegistroBoleta() As ActionResult

            Return View()
        End Function

        Function RegistrarBoleta() As ActionResult
            Return Content("test")
        End Function
#End Region

#Region "COTIZACION - Descuento Familia"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function DescuentoFamilia() As ActionResult
            Dim oMantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.Familia = New Familia()
            oMantenimientoViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oMantenimientoViewModel.Paginacion.ListaDescuentoFamilia = New ListaDescuentoFamilia()
            oMantenimientoViewModel.ListaFamilia = oMantenimientoBusinessLogic.ListarFamilia_Combo()
            ' ReSharper disable once Mvc.ViewNotResolved
            Return View(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarDsctoFamilia_PVGrilla(
                                 Optional ByVal codigoFamilia As String = Constantes.Clear,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim log As Log = Session("Log")
            log.DescripcionAccion = "CodigoFamilia:" & codigoFamilia
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                .Paginacion = New Paginacion With {
                .PageNumber = page,
                .PageSize = Constantes.RowsPerPage,
                .SortBy = sort,
                .SortType = sortDir,
                .DescuentoFamilia = New DescuentoFamilia()
            }
            }
            oMantenimientoViewModel.Paginacion.DescuentoFamilia.CodigoFamilia = codigoFamilia
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarDescuentoFamilia(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
            )

            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarDescuentoFamilia(Optional ByVal codigoFamilia As String = Constantes.ValorDefecto) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "codigoFamilia:" & codigoFamilia
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultado As Integer = Constantes.ValorCero
            resultado = oMantenimientoBusinessLogic.EliminarDescuentoFamilia(codigoFamilia)
            Select Case resultado
                Case Constantes.ValorUno
                    mensaje = "Se eliminó correctamente el Descuento por Familia"
                Case Else
                    mensaje = "Sucedió un error al eliminar el Descuento por Familia, por favor inténtelo nuevamente."
            End Select
            mensaje = resultado & "/" & mensaje
            Return Content(Convert.ToString(mensaje))
        End Function

        <HttpGet()>
        <RequiresAuthenticationAttribute()>
        Function EditarDescuentoFamilia(Optional ByVal codigoFamilia As String = Constantes.ValorDefecto, Optional ByVal margenDscto As Decimal = Constantes.ValorCero, Optional ByVal descuento As Decimal = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoViewModel = New MantenimientoViewModel()
            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            oMantenimientoViewModel.ListaFamilia = oMantenimientoBusinessLogic.ListarFamilia_Combo()
            oMantenimientoViewModel.DescuentoFamilia = New DescuentoFamilia With {
                .codigoFamilia = codigoFamilia,
                .margenDscto = margenDscto,
                .descuento = descuento
            }

            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function EditarDescuentoFamilia(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "CodigoFamilia:" & oMantenimientoViewModel.DescuentoFamilia.CodigoFamilia &
                "|MargenDscto:" & oMantenimientoViewModel.DescuentoFamilia.MargenDscto &
                "|Descuento:" & oMantenimientoViewModel.DescuentoFamilia.Descuento
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultado As Integer = Constantes.ValorCero
            mensaje = "se actualizo"
            resultado = 2
            resultado = oMantenimientoBusinessLogic.GestionarDescuentoFamilia(oMantenimientoViewModel.DescuentoFamilia)
            Select Case resultado
                Case Constantes.ValorCero
                    mensaje = "Sucedió un error al registrar el descuento de la familia, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    mensaje = "Se grabó correctamente el descuento de la familia."
                Case Constantes.ValorDos
                    mensaje = "Se actualizó correctamente el descuento de la familia."
                Case Else
                    mensaje = "Sucedió un error al registrar el cargo, por favor inténtelo nuevamente."
            End Select
            mensaje = resultado & "/" & mensaje
            Return Content(Convert.ToString(mensaje))
        End Function
#End Region

#Region "COTIZACION - Descuento Sku"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function DescuentoSku() As ActionResult
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                .Producto = New Producto(),
                .Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
                }
            }
            oMantenimientoViewModel.Paginacion.ListaDescuentoSku = New ListaDescuentoSku()
            Return View(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarDsctoSku_PVGrilla(
                                                Optional ByVal codigoSku As String = Constantes.Clear,
                                                Optional ByVal page As Integer = Constantes.FirstPage,
                                                Optional ByVal sortDir As String = Constantes.Clear,
                                                Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim log As Log = Session("Log")
            log.DescripcionAccion = "codigoSku:" & codigoSku
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                    .Paginacion = New Paginacion With {
                    .PageNumber = page,
                    .PageSize = Constantes.RowsPerPage,
                    .SortBy = sort,
                    .SortType = sortDir,
                    .DescuentoSku = New DescuentoSku()
                    }
                    }
            oMantenimientoViewModel.Paginacion.DescuentoSku.CodigoSku = codigoSku
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarDescuentoSku(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
                )

            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarDescuentoSku(Optional ByVal codigoSku As Integer = Constantes.ValorCero) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "IdDescuentoSku:" & codigoSku
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultado As Integer = Constantes.ValorCero
            resultado = oMantenimientoBusinessLogic.EliminarDescuentoSku(codigoSku)
            Select Case resultado
                Case Constantes.ValorUno
                    mensaje = "Se eliminó correctamente el Descuento por Sku"
                Case Else
                    mensaje = "Sucedió un error al eliminar el Descuento por Sku, por favor inténtelo nuevamente."
            End Select
            mensaje = resultado & "/" & mensaje
            Return Content(Convert.ToString(mensaje))
        End Function

        <HttpGet()>
        <RequiresAuthenticationAttribute()>
        Function EditarDescuentoSku() As ActionResult
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                .DescuentoSku = New DescuentoSku
            }
            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function EditarDescuentoSku(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "CodigoFamilia:" & oMantenimientoViewModel.DescuentoSku.CodigoSku &
                "|CantidadDesde:" & oMantenimientoViewModel.DescuentoSku.CantidadDesde &
                "|CantidadHasta:" & oMantenimientoViewModel.DescuentoSku.CantidadHasta &
                "|MargenDscto:" & oMantenimientoViewModel.DescuentoSku.MargenDscto &
                "|Descuento:" & oMantenimientoViewModel.DescuentoSku.Descuento
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultado As Integer = Constantes.ValorCero
            mensaje = "se actualizo"
            resultado = 2
            If oMantenimientoBusinessLogic.ValidaExiteSku(oMantenimientoViewModel.DescuentoSku.CodigoSku) = 0 Then
                resultado = Constantes.ValorCuatro
            ElseIf oMantenimientoViewModel.DescuentoSku.CantidadDesde > oMantenimientoViewModel.DescuentoSku.CantidadHasta Then
                resultado = Constantes.ValorTres
            Else
                resultado = oMantenimientoBusinessLogic.GestionarDescuentoSku(oMantenimientoViewModel.DescuentoSku)
            End If
            Select Case resultado
                Case Constantes.ValorCero
                    mensaje = "Sucedió un error al registrar el descuento de la familia, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    mensaje = "Se grabó correctamente el descuento de la familia."
                Case Constantes.ValorDos
                    mensaje = "Se encontro un conflicto, parte del rango de cantidad ya pertenece a otro registro del mismo Sku."
                Case Constantes.ValorTres
                    mensaje = "El valor del campo 'Cantidad Desde' no puedes ser mayor al valor del campo 'Cantidad Hasta'"
                Case Constantes.ValorCuatro
                    mensaje = "El Sku ingresado no existe."
                Case Else
                    mensaje = "Sucedió un error al registrar el cargo, por favor inténtelo nuevamente."
            End Select
            mensaje = resultado & "/" & mensaje
            Return Content(Convert.ToString(mensaje))
        End Function
#End Region

#Region "COTIZACION - UXPOS"
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function Cotizacion() As ActionResult
            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                .Marca = New Marca(),
                .Sucursal = New Sucursal(),
                .FechaIni = Today.Date.ToShortDateString(),
                .FechaFin = Today.Date.ToShortDateString(),
                .RucRazSoc = String.Empty,
                .SubGerente = New Empleado(),
                .JefeRegional = New Empleado(),
                .CodOfisisEmpleado = String.Empty,
                .Familia = New Familia(),
                .SkuProducto = String.Empty,
                .NroCotizacion = String.Empty,
                .Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
                }
            }
            Dim listaTipoProforma = New List(Of TipoProforma)
            listaTipoProforma.Add(New TipoProforma With {
                                     .IdTipo = 0,
                                     .Descripcion = "PROFORMA"
                                     })
            listaTipoProforma.Add(New TipoProforma With {
                                     .IdTipo = 1,
                                     .Descripcion = "PREPROFORMA"
                                     })
            oMantenimientoViewModel.Paginacion.ListaCotizacion = New ListaCotizacion()
            oMantenimientoViewModel.ListaMarca = oMantenimientoBusinessLogic.ListarMarca_Combo()
            oMantenimientoViewModel.ListaSucursal = New ListaSucursal()
            oMantenimientoViewModel.ListaSubGerente = oMantenimientoBusinessLogic.ListarEmpleadoxPerfil_Combo(RecursoPerfil.SubGerente)
            oMantenimientoViewModel.ListaJefeRegional = oMantenimientoBusinessLogic.ListarEmpleadoxPerfil_Combo(RecursoPerfil.JefeVentas)
            oMantenimientoViewModel.ListaFamilia = oMantenimientoBusinessLogic.ListarFamilia_Combo()
            oMantenimientoViewModel.ListaTipoProforma = listaTipoProforma
            Return View(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarCotizacion_PVGrilla(
                                            Optional ByVal codMarca As Integer = Constantes.ValorCero,
                                            Optional ByVal codSucursal As Integer = Constantes.ValorCero,
                                            Optional ByVal codFechaIni As String = Constantes.Clear,
                                            Optional ByVal codFechaFin As String = Constantes.Clear,
                                            Optional ByVal codRucRazSoc As String = Constantes.Clear,
                                            Optional ByVal codSubGerente As Integer = Constantes.ValorCero,
                                            Optional ByVal codJefeRegional As Integer = Constantes.ValorCero,
                                            Optional ByVal codOfisisEmpleado As String = Constantes.Clear,
                                            Optional ByVal codFamilia As String = Constantes.Clear,
                                            Optional ByVal codSkuProducto As String = Constantes.Clear,
                                            Optional ByVal codNroCotizacion As Integer = Constantes.ValorCero,
                                            Optional ByVal codIdTipoProforma As Integer = Constantes.ValorDos,
                                            Optional ByVal page As Integer = Constantes.FirstPage,
                                            Optional ByVal sortDir As String = Constantes.Clear,
                                            Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim log As Log = Session("Log")
            log.DescripcionAccion = "codMarca:" & codMarca &
                                    "codSucursal:" & codSucursal &
                                    "codFechaIni:" & codFechaIni &
                                    "codFechaFin:" & codFechaFin &
                                    "codRucRazSoc:" & codRucRazSoc &
                                    "codSubGerente:" & codSubGerente &
                                    "codJefeRegional:" & codJefeRegional &
                                    "codOfisisEmpleado:" & codOfisisEmpleado &
                                    "codFamilia:" & codFamilia &
                                    "codSkuProducto:" & codSkuProducto &
                                    "codNroCotizacion:" & codNroCotizacion &
                                    "codIdTipoProforma:" & codIdTipoProforma
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                    .Paginacion = New Paginacion With {
                    .PageNumber = page,
                    .PageSize = Constantes.RowsPerPage,
                    .SortBy = sort,
                    .SortType = sortDir,
                    .BusquedaCotizacion = New BusquedaCotizacion()
                    }
                    }
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.Marca = codMarca
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.Sucursal = codSucursal
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.FechaIni = codFechaIni
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.FechaFin = codFechaFin
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.RucRazSoc = codRucRazSoc
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.SubGerente = codSubGerente
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.JefeRegional = codJefeRegional
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.OfisisEmpleado = codOfisisEmpleado
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.CodigoFamilia = codFamilia
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.SkuProducto = codSkuProducto
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.NroCotizacion = codNroCotizacion
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.EsPreProforma = codIdTipoProforma
            oMantenimientoViewModel.Paginacion.BusquedaCotizacion.Usuario = Convert.ToString(Session("User"))

            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListaCotizacion(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
                )

            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpGet()>
        <RequiresAuthenticationAttribute()>
        Function EditarCotizacion(Optional ByVal nroCotizacion As String = Constantes.ValorDefecto) As ActionResult
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                .Cotizacion = New Cotizacion With {
                .nroCotizacion = nroCotizacion
                }
            }

            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function EditarCotizacion(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "NroCotizacion:" & oMantenimientoViewModel.Cotizacion.NroCotizacion &
                                    "|NroCotizacionUxpos:" & oMantenimientoViewModel.Cotizacion.NroCotizacionUxpos
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultado As Integer = Constantes.ValorCero
            mensaje = "se actualizo"
            resultado = 2
            resultado = oMantenimientoBusinessLogic.GestionarCotizacion(oMantenimientoViewModel.Cotizacion)
            Select Case resultado
                Case Constantes.ValorCero
                    mensaje = "Sucedió un error al registrar el descuento de la familia, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    mensaje = "Se grabó correctamente el descuento de la familia."
            End Select
            mensaje = resultado & "/" & mensaje
            Return Content(Convert.ToString(mensaje))
        End Function

        <HttpGet()>
        <RequiresAuthenticationAttribute()>
        Function VerDetalleCotizacion(Optional ByVal nroCotizacion As String = Constantes.ValorDefecto,
                                      Optional ByVal page As Integer = Constantes.FirstPage,
                                      Optional ByVal sortDir As String = Constantes.Clear,
                                      Optional ByVal sort As String = Constantes.Clear) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "DetalleCotizacion_nroCotizacion: " & nroCotizacion
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                                              .Paginacion = New Paginacion With {
                                              .PageNumber = page,
                                              .PageSize = Constantes.RowsPerPage,
                                              .SortBy = sort,
                                              .SortType = sortDir,
                    .DetalleCotizacion = New DetalleCotizacion With {
                    .nroCotizacion = nroCotizacion
                    }
                                              }
                                            }
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListaDetalleCotizacion(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
                )
            Return PartialView(oMantenimientoViewModel)
        End Function

        Function ListarSucursalControl(Optional ByVal idMarca As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                                              .Sucursal = New Sucursal(),
                .ListaSucursal = oMantenimientoBusinessLogic.ListarSucursalControl(idMarca)
            }
            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ExportarCotizacion(
                                            Optional ByVal codMarca As Integer = Constantes.ValorCero,
                                            Optional ByVal codSucursal As Integer = Constantes.ValorCero,
                                            Optional ByVal codFechaIni As String = Constantes.Clear,
                                            Optional ByVal codFechaFin As String = Constantes.Clear,
                                            Optional ByVal codRucRazSoc As String = Constantes.Clear,
                                            Optional ByVal codSubGerente As Integer = Constantes.ValorCero,
                                            Optional ByVal codJefeRegional As Integer = Constantes.ValorCero,
                                            Optional ByVal codOfisisEmpleado As String = Constantes.Clear,
                                            Optional ByVal codFamilia As String = Constantes.Clear,
                                            Optional ByVal codSkuProducto As String = Constantes.Clear,
                                            Optional ByVal codNroCotizacion As Integer = Constantes.ValorCero,
                                            Optional ByVal codIdTipoProforma As Integer = Constantes.ValorDos,
                                            Optional ByVal page As Integer = Constantes.FirstPage,
                                            Optional ByVal sortDir As String = Constantes.Clear,
                                            Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim log As Log = Session("Log")
            log.DescripcionAccion = "codMarca:" & codMarca &
                                    "codSucursal:" & codSucursal &
                                    "codFechaIni:" & codFechaIni &
                                    "codFechaFin:" & codFechaFin &
                                    "codRucRazSoc:" & codRucRazSoc &
                                    "codSubGerente:" & codSubGerente &
                                    "codJefeRegional:" & codJefeRegional &
                                    "codOfisisEmpleado:" & codOfisisEmpleado &
                                    "codFamilia:" & codFamilia &
                                    "codSkuProducto:" & codSkuProducto &
                                    "codNroCotizacion:" & codNroCotizacion &
                                    "codIdTipoProforma:" & codIdTipoProforma
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Exportar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim busquedaCotizacion As BusquedaCotizacion = New BusquedaCotizacion With {
                    .Marca = codMarca,
                    .Sucursal = codSucursal,
                    .FechaIni = codFechaIni,
                    .FechaFin = codFechaFin,
                    .RucRazSoc = codRucRazSoc,
                    .SubGerente = codSubGerente,
                    .JefeRegional = codJefeRegional,
                    .OfisisEmpleado = codOfisisEmpleado,
                    .CodigoFamilia = codFamilia,
                    .SkuProducto = codSkuProducto,
                    .NroCotizacion = codNroCotizacion,
                    .EsPreProforma = codIdTipoProforma,
                    .Usuario = Convert.ToString(Session("User"))
                    }

            Dim listaReporteCotizacion = oMantenimientoBusinessLogic.ListaReporteCotizacion(busquedaCotizacion)
            listaReporteCotizacion.Insert(0, New ReporteCotizacion)
            Dim codedate As String = GenerateCodeDate()

            Dim nameFile As String = "ReporteCotizacion_" + codedate + ".xlsx"
            Dim relativepath As String = Server.MapPath(ConfigurationManager.AppSettings("ReporteCotizacion"))
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
                For Each item As ReporteCotizacion In listaReporteCotizacion
                    oxa = New List(Of OpenXmlAttribute) From {
                        New OpenXmlAttribute("r", Nothing, item.ToString())
                    }
                    oxw.WriteStartElement(New Row(), oxa)

                    If (IsNothing(item.Ruc)) Then
                        For Each headerstring As String In ColumnsReporteCotizacion()
                            ReadFile(oxa, oxw, headerstring)
                        Next
                    Else
                        ReadFile(oxa, oxw, item.NroCotizacionDesc)
                        ReadFile(oxa, oxw, item.NroCotizacionUxposDesc)
                        ReadFile(oxa, oxw, item.Fecha)
                        ReadFile(oxa, oxw, item.Vendedor)
                        ReadFile(oxa, oxw, item.Ruc)
                        ReadFile(oxa, oxw, item.Cliente)
                        ReadFile(oxa, oxw, item.Ccosto)
                        ReadFile(oxa, oxw, item.Tienda)
                        ReadFile(oxa, oxw, item.Sku)
                        ReadFile(oxa, oxw, item.Producto)
                        ReadFile(oxa, oxw, item.PrecioTienda)
                        ReadFile(oxa, oxw, item.PrecioVvEe)
                        ReadFile(oxa, oxw, item.PrecioVvEeSinIgv)
                        ReadFile(oxa, oxw, item.Cantidad)
                        ReadFile(oxa, oxw, item.Total)
                        ReadFile(oxa, oxw, item.TipoProforma)
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

            Return Content(ConfigurationManager.AppSettings("ReporteCotizacion") + "/" + nameFile)
        End Function

        Private Shared Function GenerateCodeDate() As String
            Return Date.Now.ToString("yyyyMMddHHmmssfff")
        End Function

        Private Shared Sub ReadFile(oxa As List(Of OpenXmlAttribute), oxw As OpenXmlWriter, data As String)
            oxa = New List(Of OpenXmlAttribute)()
            oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))
            oxw.WriteStartElement(New Cell(), oxa)
            oxw.WriteElement(New CellValue(data))
            oxw.WriteEndElement()
        End Sub

        Private Shared Sub ReadFile(oxa As List(Of OpenXmlAttribute), oxw As OpenXmlWriter, data As Decimal)
            oxa = New List(Of OpenXmlAttribute)()
            oxw.WriteStartElement(New Cell(), oxa)
            oxw.WriteElement(New CellValue(data))
            oxw.WriteEndElement()
        End Sub

        Private Shared Function ColumnsReporteCotizacion() As String()
            Return {
                       "NRO COTIZACIÓN",
                       "NRO COTIZACIÓN UXPOS",
                       "FECHA",
                       "VENDEDOR",
                       "RUC",
                       "CLIENTE",
                       "CCOSTO",
                       "TIENDA",
                       "SKU",
                       "PRODUCTO",
                       "PRECIO TIENDA",
                       "PRECIO VVEE",
                       "PRECIO VVEE SIN IGV",
                       "CANTIDAD",
                       "TOTAL",
                       "TIPO PROFORMA"}
        End Function

        Public Class TipoProforma
            Public Property IdTipo As Integer
            Public Property Descripcion As String
        End Class
#End Region

#Region "COTIZACION - Sku Bloquedos"
        <RequiresAuthenticationAttribute()>
        Function SkuBloqueados() As ActionResult
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                .Producto = New Producto(),
                .Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
                }
            }
            oMantenimientoViewModel.Paginacion.ListaProducto = New ListaProducto()
            Return View(oMantenimientoViewModel)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarSkuBloqueados_PVGrilla(
                                                Optional ByVal codigoSku As String = Constantes.Clear,
                                                Optional ByVal page As Integer = Constantes.FirstPage,
                                                Optional ByVal sortDir As String = Constantes.Clear,
                                                Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim log As Log = Session("Log")
            log.DescripcionAccion = "codigoSku:" & codigoSku
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Buscar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                    .Paginacion = New Paginacion With {
                    .PageNumber = page,
                    .PageSize = Constantes.RowsPerPage,
                    .SortBy = sort,
                    .SortType = sortDir,
                    .Producto = New Producto()
                    }
                    }
            oMantenimientoViewModel.Paginacion.Producto.Sku = codigoSku
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarSkuBloqueados(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
                )

            Return PartialView(oMantenimientoViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarSkuBloqueado(Optional ByVal codigoSku As String = Constantes.Clear) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "IdDescuentoSku:" & codigoSku
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultado As Integer = Constantes.ValorCero
            resultado = oMantenimientoBusinessLogic.EliminarSkuBloqueado(codigoSku)
            Select Case resultado
                Case Constantes.ValorUno
                    mensaje = "Se eliminó correctamente el Sku Bloqueado"
                Case Else
                    mensaje = "Sucedió un error al eliminar el Sku Bloqueado, por favor inténtelo nuevamente."
            End Select
            mensaje = resultado & "/" & mensaje
            Return Content(Convert.ToString(mensaje))
        End Function

        <HttpGet()>
        <RequiresAuthenticationAttribute()>
        Function EditarSkuBloqueado() As ActionResult
            Dim oMantenimientoViewModel = New MantenimientoViewModel With {
                .Producto = New Producto
            }
            Return PartialView(oMantenimientoViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function EditarSkuBloqueado(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim log As Log = Session("Log")
            log.DescripcionAccion = "CodigoSku:" & oMantenimientoViewModel.Producto.Sku
            log.IdOrigenAccion = Constantes.Mantenimiento_Cotizacion
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultado As Integer = Constantes.ValorCero
            mensaje = "se actualizo"
            resultado = 2
            If oMantenimientoBusinessLogic.ValidaExiteSku(oMantenimientoViewModel.Producto.Sku) = 0 Then
                resultado = Constantes.ValorDos
            Else
                resultado = oMantenimientoBusinessLogic.GestionarSkuBloqueado(oMantenimientoViewModel.Producto)
            End If
            Select Case resultado
                Case Constantes.ValorCero
                    mensaje = "Sucedió un error al registrar el sku bloqueado, por favor inténtelo nuevamente."
                Case Constantes.ValorUno
                    mensaje = "Se grabó correctamente el sku bloqueado."
                Case Constantes.ValorDos
                    mensaje = "El Sku ingresado no existe."
                Case Else
                    mensaje = "Sucedió un error al registrar el cargo, por favor inténtelo nuevamente."
            End Select
            mensaje = resultado & "/" & mensaje
            Return Content(Convert.ToString(mensaje))
        End Function
#End Region

#Region "Plan Ventas por Tipo Representante - SOD13068"

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarPlanTipoRepresentanteVenta() As ActionResult
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel As New MantenimientoViewModel()

            oMantenimientoViewModel.PlanTipoRepresentanteVenta = New PlanTipoRepresentanteVenta()
            oMantenimientoViewModel.PlanTipoRepresentanteVenta.ListaTipoRepresentanteVenta = oMantenimientoBusinessLogic.ListarTipoRepresentanteVenta()
            oMantenimientoViewModel.PlanTipoRepresentanteVenta.ListaMesPlan = oMantenimientoBusinessLogic.ListarMesPlan()

            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = Constantes.ValorUno
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.ValorDiez
            oMantenimientoViewModel.Paginacion.TotalRows = Constantes.ValorCero
            oMantenimientoViewModel.Paginacion.ListaPlanTipoRepresentanteVenta = New ListaPlanTipoRepresentanteVenta()

            Return View(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarPlanTipoRepresentanteVenta_PVGrilla(
                                 Optional ByVal IdTipoRepVen As Integer = Constantes.ValorCero,
                                 Optional ByVal IdMes As Integer = Constantes.ValorCero,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdTipoRepVen:" & IdTipoRepVen & "|IdMes:" & IdMes
            Log.IdOrigenAccion = Constantes.Mantenimiento_PlanTipoRepresentanteVenta
            Log.IdLogAccion = Constantes.Buscar

            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()

            oMantenimientoViewModel.Paginacion = New Paginacion()
            oMantenimientoViewModel.Paginacion.PageNumber = page
            oMantenimientoViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oMantenimientoViewModel.Paginacion.SortType = sortDir
            oMantenimientoViewModel.Paginacion.SortBy = sort

            oMantenimientoViewModel.Paginacion.PlanTipoRepresentanteVenta = New PlanTipoRepresentanteVenta()
            oMantenimientoViewModel.Paginacion.PlanTipoRepresentanteVenta.TipoRepresentanteVenta = New TipoRepresentanteVenta()
            oMantenimientoViewModel.Paginacion.PlanTipoRepresentanteVenta.MesPlan = New MesPlan()

            oMantenimientoViewModel.Paginacion.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen = IdTipoRepVen
            oMantenimientoViewModel.Paginacion.PlanTipoRepresentanteVenta.MesPlan.IdMes = IdMes
            oMantenimientoViewModel.Paginacion = oMantenimientoBusinessLogic.ListarPlanTipoRepresentanteVenta(oMantenimientoViewModel.Paginacion)

            oMantenimientoViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oMantenimientoViewModel.Paginacion.PageNumber,
                oMantenimientoViewModel.Paginacion.PageSize,
                oMantenimientoViewModel.Paginacion.TotalRows
            )

            Return PartialView(oMantenimientoViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarPlanTipoRepresentanteVenta(Optional ByVal IdPlanTipoRepVen As Integer = Constantes.ValorCero) As ActionResult
            Dim oMantenimientoBusinessLogic As MantenimientoBusinessLogic = New MantenimientoBusinessLogic()
            Dim oMantenimientoViewModel As MantenimientoViewModel = New MantenimientoViewModel()

            oMantenimientoViewModel.PlanTipoRepresentanteVenta = New PlanTipoRepresentanteVenta()
            If IdPlanTipoRepVen <> 0 Then
                'Obtener datos para editar
                oMantenimientoViewModel.PlanTipoRepresentanteVenta = oMantenimientoBusinessLogic.ObtenerPlanTipoRepresentanteVenta(IdPlanTipoRepVen)
            End If
            oMantenimientoViewModel.PlanTipoRepresentanteVenta.ListaTipoRepresentanteVenta = oMantenimientoBusinessLogic.ListarTipoRepresentanteVenta()
            oMantenimientoViewModel.PlanTipoRepresentanteVenta.ListaMesPlan = oMantenimientoBusinessLogic.ListarMesPlan()

            Return (PartialView(oMantenimientoViewModel))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function GestionarPlanTipoRepresentanteVenta_(oMantenimientoViewModel As MantenimientoViewModel) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdTipoPerVen:" & oMantenimientoViewModel.PlanTipoRepresentanteVenta.TipoRepresentanteVenta.IdTipoRepVen &
                "|IdMes:" & oMantenimientoViewModel.PlanTipoRepresentanteVenta.MesPlan.IdMes &
                "|Plan:" & oMantenimientoViewModel.PlanTipoRepresentanteVenta.Plan &
                "|FechaRegistro:" & oMantenimientoViewModel.PlanTipoRepresentanteVenta.FechaRegistro
            Log.IdOrigenAccion = Constantes.Mantenimiento_PlanTipoRepresentanteVenta
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim mensaje As String = Constantes.ValorDefecto
            Dim resultStr As String = Constantes.ValorDefecto
            Dim resulInt As Integer = Constantes.ValorCero

            resultStr = oMantenimientoBusinessLogic.GestionarPlanTipoRepresentanteVenta(oMantenimientoViewModel.PlanTipoRepresentanteVenta)

            Dim resultado() As String = Split(resultStr, ":")
            resulInt = Convert.ToInt32(resultado(0))

            Select Case resulInt
                Case Constantes.ValorCero
                    mensaje = "Sucedió un error al registrar el plan de ventas, por favor inténtelo nuevamente."
                Case Constantes.MenosUno
                    mensaje = "Seleccione el mes siguiente: " + resultado(1)
                Case Constantes.ValorUno
                    mensaje = "Se grabó correctamente el plan de ventas."
                Case Constantes.ValorDos
                    mensaje = "Se actualizó correctamente el plan de ventas."
            End Select
            mensaje = resulInt & "/" & mensaje

            Return Content(Convert.ToString(mensaje))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function EliminarPlanTipoRepresentanteVenta(Optional ByVal IdPlanTipoRepVen As Integer = Constantes.ValorCero) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPlanTipoRepVen:" & IdPlanTipoRepVen
            Log.IdOrigenAccion = Constantes.Mantenimiento_PlanTipoRepresentanteVenta
            Log.IdLogAccion = Constantes.Eliminar
            Dim oMantenimientoBusinessLogic As New MantenimientoBusinessLogic(True, Log)

            Dim Mensaje As String = Constantes.ValorDefecto
            Dim Resultado As Integer = Constantes.ValorCero

            Resultado = oMantenimientoBusinessLogic.EliminarPlanTipoRepresentanteVenta(IdPlanTipoRepVen)
            Select Case Resultado
                Case Constantes.ValorUno
                    Mensaje = "Se eliminó correctamente el Plan Venta."
                Case Else
                    Mensaje = "Sucedió un error al eliminar el Plan Venta, por favor inténtelo nuevamente."
            End Select
            Mensaje = Resultado & "/" & Mensaje
            Return Content(Convert.ToString(Mensaje))
        End Function
#End Region
    End Class
End Namespace
