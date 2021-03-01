Imports System.Data.OleDb
Imports Sodimac.VentaEmpresa.Web.Mvc.ProcesoViewModel
Imports Sodimac.VentaEmpresa.Common
Imports System.IO
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports System.Configuration
Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView
Imports Excel
Imports System.Data
Imports DocumentFormat.OpenXml.Office2010.PowerPoint
Imports System.Net.Mail

Namespace Sodimac.VentaEmpresa.Web.Mvc

    Public Class ProcesoController
        Inherits AsyncController
        Dim objDataSet As New DataSet
        Dim Dst As New DataSet()
        Dim I, j As Integer
        Dim tmp As New CargaMasivaClienteViewModel
        Dim tmpcc As New ProcesoViewModel
        Dim tm2 As New ProcesoViewModel
        'Dim worExcel As Excel.Workbook
        'Dim sheExcel As Excel.Worksheet
        Dim excelReader As IExcelDataReader
        Dim dt, dt1 As System.Data.DataTable
        Public Prueba As System.Data.DataTable
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function ReprocesoVentas() As ActionResult
            Dim resultado As Integer = 0
            Dim NombresApellidos As String = ""
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel
            Dim oViewModel As New ProcesoViewModel
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            oViewModel.ListaZona = New ListaZona()

            oViewModel.ListaZona = oVentasBusinessLogic.ListaZonas()
            oViewModel.ListaSucursal = New ListaSucursal()
            oViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()
            '' oVentasViewModel. 

            Return View(oViewModel)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ReprocesoVentas_(Optional ByVal IdZona As Integer = Constantes.ValorCero, Optional ByVal IdSucursal As String = "",
                                Optional ByVal FechaInicio As String = Constantes.FechaDefecto, Optional ByVal FechaFin As String = Constantes.FechaDefecto) As ActionResult
            Dim mensaje As String = ""
            Dim resultado As Integer = 0
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel
            Dim oViewModelProceso As New ProcesoViewModel
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()


            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdZona:" & IdZona & "|IdSucursal:" & IdSucursal & "|FechaInicio:" & FechaInicio & "|FechaFin:" & FechaFin
            Log.IdOrigenAccion = Constantes.Venta_Reproceso
            Log.IdLogAccion = Constantes.Reproceso
            resultado = New ProcesoBusinessLogic(True, Log).InsertaVentasporConsulta(IdZona, IdSucursal, FechaInicio, FechaFin)

            Select Case resultado
                Case Constantes.ValorUno
                    mensaje = "El reproceso de Venta se ha iniciado de forma exitosa."
                Case Constantes.ValorDos
                    mensaje = "Actualmente hay un reproceso en ejecución, por favor inténtelo más tarde"
                Case Else
                    mensaje = "No se pudo iniciar el reproceso de venta, por favor inténtelo más tarde"
            End Select

            mensaje = resultado & "/" & mensaje

            Return Content(mensaje)
        End Function

        <RequiresAuthorizationAttribute()>
        Function Index() As ActionResult
            Dim oViewModel As New ProcesoViewModel
            oViewModel.ListaProcesoCarga = New ListaProcesoCarga
            oViewModel.ListaProcesoCargaErrorTotales = New ListaProcesoCarga
            'oViewModel.ListaProcesoCargaHistorica = New ListaProcesoCarga
            oViewModel.Hoja = "DocumentosManuales"
            Return View(oViewModel)
        End Function

        <HttpPost()>
        Function PV_Errores() As ActionResult
            Dim oViewModel As New ProcesoViewModel
            oViewModel.ListaProcesoCargaErrorTotales = DirectCast(Session("ListaErrores"), ListaProcesoCarga)
            Return PartialView("PV_Errores", oViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ImportarArchivos() As ActionResult

            Dim IdTipoCarga As Integer = CInt(ConfigurationManager.AppSettings("IdTipoCarga"))
            Dim oViewModel As New ProcesoViewModel
            oViewModel.ListaProcesoCarga = New ListaProcesoCarga
            oViewModel.ListaParametros = New ListaParametro
            oViewModel.ListaParametros = New ProcesoBusinessLogic().ListaParametrosCargaManual()
            oViewModel.ListaProcesoCarga = DirectCast(Session("ListaGuardar"), ListaProcesoCarga)
            oViewModel.ListaProcesoCarga(0).UserReg = TryCast(Session("User"), String)
            For Each el As ProcesoCarga In oViewModel.ListaProcesoCarga
                el.TipoCarga = IdTipoCarga
                el.TipoCaja = oViewModel.ListaParametros(0).Valor1
                el.FormaPago = oViewModel.ListaParametros(1).Valor1
                el.IdSucursalReal = el.IdSucursalReal 'el.IdSucursal
                el.IdSucursal = el.IdSucursal 'CInt(oViewModel.ListaParametros(2).Valor1)
                el.NombreSucursal = el.NombreSucursal 'oViewModel.ListaParametros(2).CodigoParametro

                'el.CajaCargaManual = oViewModel.ListaParametros(0).Valor1
            Next

            Dim Log As Log = Session("Log")
            Log.IdOrigenAccion = Constantes.Venta_Reproceso
            Log.IdLogAccion = Constantes.Insertar
            Dim _resultado As Int32 = New ProcesoBusinessLogic(True, Log).Importar(oViewModel.ListaProcesoCarga)
            Return Content(_resultado.ToString())
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function UpdVentasCotizacion() As ActionResult

            Dim _resultado As Int32 = New ProcesoBusinessLogic().Sincronizar()
            Return Content(_resultado.ToString())
        End Function

        '     <HttpPost()> _
        '<RequiresAuthenticationAjaxAttribute()> _
        Sub AdjuntarDataMensualAsync(oViewModelProceso As ProcesoViewModel)

            Dim oViewModel As New ProcesoViewModel
            Dim message As String = Constantes.Clear
            Dim file As HttpPostedFileBase = Me.HttpContext.Request.Files.[Get]("file1")
            Dim ext As String = Path.GetExtension(file.FileName)

            Dim Log As Log = Session("Log")

            Log.DescripcionAccion = "Archivo:" & file.FileName
            Log.IdOrigenAccion = Constantes.Venta_CargaManual
            Log.IdLogAccion = Constantes.Visualizar
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

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
                Try

                    Dim stream As FileStream = System.IO.File.Open(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream)
                    excelReader.IsFirstRowAsColumnNames = True
                    'excelReader.AsDataSet(True)

                    objDataSet = excelReader.AsDataSet(True)


                    Dim ds As New DataSet()
                    'ds = LeerArchivoExcel(FileName, oViewModelProceso.Hoja)
                    ds = excelReader.AsDataSet(True)
                    Dim dt As New DataTable
                    dt = BorrarFilasVacias(ds.Tables(0))

                    If (dt.Rows.Count <> 0) Then

                        Dim ok As Integer = -1

                        Dim i As Int32
                        Dim oBL As New ProcesoBusinessLogic

                        Try
                            oViewModel.ListaProcesoCarga = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorRuc = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorSku = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorTotal = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorCantidad = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorFecha = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorIgv = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorNumeroDoc = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorSucu = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorTC = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorTpoDoc = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorValVenta = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorMoneda = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorTotales = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorCostoTotal = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorPorcentajePercepcion = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorMontoPercepcion = New ListaProcesoCarga
                            oViewModel.ListaProcesoCargaErrorTotalVtaIgvPercepcion = New ListaProcesoCarga

                            Dim oListaMoneda As ListaProcesoCarga = oBL.ListaMoneda()
                            Dim oListaSKU As ListaProcesoCarga = oBL.ListaSKU()
                            Dim oListaTipoDocumento As ListaProcesoCarga = oBL.ListaDocumentoTipo()
                            Dim oListaClienteVenta As ListaClienteVenta = oBL.ListaCliente()
                            Dim oListaSucursal As ListaProcesoCarga = oBL.ListaSucursalVenta()

                            For i = 0 To dt.Rows.Count - 1
                                Dim flag0 As Boolean = True
                                Dim flag1 As Boolean = True
                                Dim flag2 As Boolean = True
                                Dim flag3 As Boolean = True
                                Dim flag4 As Boolean = True
                                Dim flag5 As Boolean = True
                                Dim flag6 As Boolean = True
                                Dim flag7 As Boolean = True
                                Dim flag8 As Boolean = True
                                Dim flag9 As Boolean = True
                                Dim flag10 As Boolean = True
                                Dim flag11 As Boolean = True
                                'Dim flag12 As Boolean = True
                                Dim flag13 As Boolean = True
                                Dim flag15 As Boolean = True
                                Dim flag16 As Boolean = True
                                Dim flag17 As Boolean = True

                                Dim vv As Decimal = 0
                                Dim igv As Decimal = 0
                                Dim t As Decimal = 0
                                Dim cell As String = String.Empty
                                oViewModel.ProcesoCarga = New ProcesoCarga

                                For j = 0 To dt.Columns.Count - 1

                                    Select Case j

                                        Case 0
                                            oViewModel.ProcesoCarga.TipoDocumento = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (CStr(dt.Rows(i)(j)) = Constantes.Clear) Then
                                                flag0 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TIPODOCUMENTO, "
                                            Else
                                                oViewModel.ProcesoCarga.TipoDocumento = CStr(dt.Rows(i)(j)).ToUpper()
                                                If Not EsTipoDocumentoValido(oViewModel.ProcesoCarga, oListaTipoDocumento) Then
                                                    flag0 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TIPODOCUMENTO, "
                                                End If

                                            End If
                                        Case 1
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " SUCURSAL, "
                                            Else
                                                oViewModel.ProcesoCarga.IdSucursal = CInt(dt.Rows(i)(j))
                                                If Not EsSucursalValido(oViewModel.ProcesoCarga, oListaSucursal) Then
                                                    flag1 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " SUCURSAL, "
                                                End If
                                            End If
                                        Case 2
                                            Dim rgx = New Regex("^[0-9]*$")
                                            oViewModel.ProcesoCarga.NumeroDocumento = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, ToNumericOnly(CStr(dt.Rows(i)(j))))
                                            If (EsEntero(oViewModel.ProcesoCarga.NumeroDocumento)) Then
                                                oViewModel.ProcesoCarga.NumeroDocumento = ToNumericOnly(CStr(dt.Rows(i)(j)))
                                            Else
                                                flag2 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " NUMERODOCUMENTO, "
                                            End If
                                        Case 3
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                flag3 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " FECHA, "
                                            Else
                                                Dim isdate As Boolean = ValidarFecha(CStr(dt.Rows(i)(j)))
                                                If (isdate) Then
                                                    oViewModel.ProcesoCarga.Fecha = CDate(dt.Rows(i)(j))
                                                    oViewModel.ProcesoCarga.Hora = oViewModel.ProcesoCarga.Fecha.Hour
                                                    oViewModel.ProcesoCarga.Minuto = oViewModel.ProcesoCarga.Fecha.Minute
                                                Else
                                                    flag3 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " FECHA, "
                                                End If
                                            End If
                                        Case 4
                                            oViewModel.ProcesoCarga.Ruc = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)).Trim())
                                            If (cell = Constantes.Clear) Then
                                                flag4 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " RUC, "
                                            Else
                                                If Not EsClienteValido(oViewModel.ProcesoCarga, oListaClienteVenta) Then
                                                    flag4 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " RUC, "
                                                End If
                                            End If

                                        Case 5
                                            oViewModel.ProcesoCarga.Sku = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (CStr(dt.Rows(i)(j)) = Constantes.Clear) Then
                                                flag5 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " SKU, "
                                            Else
                                                If Not EsProductoValido(oViewModel.ProcesoCarga, oListaSKU) Then
                                                    flag5 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " SKU, "
                                                End If
                                            End If
                                        Case 6
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                flag6 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " CANTIDAD, "
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    oViewModel.ProcesoCarga.Cantidad = CDec(dt.Rows(i)(j))
                                                Else
                                                    flag6 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " CANTIDAD, "
                                                End If
                                            End If
                                        Case 7
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                flag7 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " VALORVENTA, "
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    If (CDec(dt.Rows(i)(j)).Equals(0)) Then
                                                        flag8 = False
                                                        oViewModel.ProcesoCarga.DescErrorVal = oViewModel.ProcesoCarga.DescErrorVal + " VALORVENTA, "
                                                    Else
                                                        oViewModel.ProcesoCarga.ValorVenta = Decimal.Round(CDec(dt.Rows(i)(j)), 2)
                                                        vv = Decimal.Round(CDec(dt.Rows(i)(j)), 2)
                                                    End If
                                                Else
                                                    flag7 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " VALORVENTA, "
                                                End If
                                            End If
                                        Case 8
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                flag8 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " IGV, "
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    If (Convert.ToDecimal(dt.Rows(i)(j)).Equals(0)) Then
                                                        flag8 = False
                                                        oViewModel.ProcesoCarga.DescErrorVal = oViewModel.ProcesoCarga.DescErrorVal + " IGV, "
                                                    Else
                                                        oViewModel.ProcesoCarga.Igv = Decimal.Round(CDec(dt.Rows(i)(j)), 2)
                                                        igv = oViewModel.ProcesoCarga.Igv
                                                    End If
                                                Else
                                                    flag8 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " IGV, "
                                                End If
                                            End If
                                        Case 9
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                flag9 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TOTAL, "
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    oViewModel.ProcesoCarga.Total = Decimal.Round(CDec(dt.Rows(i)(j)), 2)
                                                    t = vv + igv
                                                    If t <> oViewModel.ProcesoCarga.Total Then
                                                        flag9 = False
                                                        oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TOTAL, "
                                                    ElseIf Convert.ToDecimal(dt.Rows(i)(j)).Equals(0) Then
                                                        flag9 = False
                                                        oViewModel.ProcesoCarga.DescErrorVal = oViewModel.ProcesoCarga.DescErrorVal + " TOTAL, "
                                                    Else
                                                        flag9 = True
                                                        CalcularValores(oViewModel.ProcesoCarga)
                                                    End If
                                                Else
                                                    flag9 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TOTAL, "
                                                End If
                                            End If
                                        Case 10
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                flag10 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " MONEDA, "
                                            Else
                                                oViewModel.ProcesoCarga.Moneda = CStr(dt.Rows(i)(j))
                                                If Not EsMonedaValida(oViewModel.ProcesoCarga, oListaMoneda) Then
                                                    flag10 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " MONEDA, "
                                                End If
                                            End If

                                        Case 11
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                flag11 = False
                                                oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TC, "
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    oViewModel.ProcesoCarga.Tc = CDec(dt.Rows(i)(j))
                                                Else
                                                    flag11 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TC, "
                                                End If
                                            End If
                                            'oViewModel.ProcesoCarga.Tc = CDec(dt.Rows(i)(j))
                                        Case 12
                                            If Convert.IsDBNull((dt.Rows(i)(j))) Then
                                                oViewModel.ProcesoCarga.DocumentoAfecto = Constantes.Clear
                                            Else
                                                oViewModel.ProcesoCarga.DocumentoAfecto = (dt.Rows(i)(j)).ToString()
                                            End If
                                        Case 13
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                oViewModel.ProcesoCarga.CostoTotal = 0
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    oViewModel.ProcesoCarga.CostoTotal = CDec(dt.Rows(i)(j))
                                                Else
                                                    flag13 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " COSTOTOTAL, "
                                                End If
                                            End If
                                        Case 14
                                            'If String.IsNullOrEmpty(dt.Rows(i)(j)) Then
                                            '    oViewModel.ProcesoCarga.Comentario = Constantes.Clear
                                            'Else
                                            oViewModel.ProcesoCarga.Comentario = (dt.Rows(i)(j)).ToString()
                                            'End If
                                        Case 15

                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                oViewModel.ProcesoCarga.PercepcionPorcentaje = 0
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    oViewModel.ProcesoCarga.PercepcionPorcentaje = CDec(dt.Rows(i)(j))
                                                Else
                                                    flag15 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " %PERCEPCION, "
                                                End If
                                            End If
                                        Case 16

                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))

                                            If (cell = Constantes.Clear) Then
                                                oViewModel.ProcesoCarga.MontoPercepcion = 0
                                            Else
                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    oViewModel.ProcesoCarga.MontoPercepcion = CDec(dt.Rows(i)(j))
                                                Else
                                                    flag16 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " MONTOPERCEPCION, "
                                                End If
                                            End If

                                        Case 17
                                            cell = If(Convert.IsDBNull(dt.Rows(i)(j)), String.Empty, CStr(dt.Rows(i)(j)))
                                            If (cell = Constantes.Clear) Then
                                                oViewModel.ProcesoCarga.TotalVtaIgvPercepcion = 0
                                            Else

                                                Dim isnumero As Boolean = ValidarNumero(CStr(dt.Rows(i)(j)))
                                                If (isnumero) Then
                                                    oViewModel.ProcesoCarga.TotalVtaIgvPercepcion = CDec(dt.Rows(i)(j))
                                                Else
                                                    flag17 = False
                                                    oViewModel.ProcesoCarga.DescError = oViewModel.ProcesoCarga.DescError + " TOTALVTAIGVPERCEPCION, "
                                                End If
                                            End If

                                    End Select

                                Next

                                If flag0 And flag1 And flag2 And flag3 And flag4 And flag5 And flag6 And flag7 And flag8 And flag9 And flag10 And flag11 And flag13 And flag15 And flag16 And flag17 Then
                                    oViewModel.ListaProcesoCarga.Add(oViewModel.ProcesoCarga)
                                Else
                                    Dim str As String = oViewModel.ProcesoCarga.DescError
                                    Dim strVal As String
                                    If Not String.IsNullOrEmpty(oViewModel.ProcesoCarga.DescErrorVal) Then
                                        strVal = String.Format("{0} {1}", " Valores 0 sobre las columnas: ", oViewModel.ProcesoCarga.DescErrorVal.Substring(0, oViewModel.ProcesoCarga.DescErrorVal.Length - 2))
                                    End If
                                    If String.IsNullOrEmpty(str) Then
                                        oViewModel.ProcesoCarga.DescError = strVal
                                    ElseIf String.IsNullOrEmpty(strVal) Then
                                        oViewModel.ProcesoCarga.DescError = " un error en la columna(s) " + str.Substring(0, str.Length - 2)
                                    Else
                                        oViewModel.ProcesoCarga.DescError = " un error en la columna(s) " + str.Substring(0, str.Length - 2) + " y " + strVal
                                    End If

                                    oViewModel.ListaProcesoCargaErrorTotales.Add(oViewModel.ProcesoCarga)
                                End If
                                'If Not flag0 Then
                                '    oViewModel.ListaProcesoCargaErrorTpoDoc.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag1 Then
                                '    oViewModel.ListaProcesoCargaErrorSucu.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag2 Then
                                '    oViewModel.ListaProcesoCargaErrorNumeroDoc.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag3 = False Then
                                '    oViewModel.ListaProcesoCargaErrorFecha.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag4 Then
                                '    oViewModel.ListaProcesoCargaErrorRuc.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag5 Then
                                '    oViewModel.ListaProcesoCargaErrorSku.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag6 Then
                                '    oViewModel.ListaProcesoCargaErrorCantidad.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag7 Then
                                '    oViewModel.ListaProcesoCargaErrorValVenta.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag8 Then
                                '    oViewModel.ListaProcesoCargaErrorIgv.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag9 Then
                                '    oViewModel.ListaProcesoCargaErrorTotal.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag10 Then
                                '    oViewModel.ListaProcesoCargaErrorMoneda.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag11 Then
                                '    oViewModel.ListaProcesoCargaErrorTC.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag13 Then
                                '    oViewModel.ListaProcesoCargaErrorCostoTotal.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag15 Then
                                '    oViewModel.ListaProcesoCargaErrorPorcentajePercepcion.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag16 Then
                                '    oViewModel.ListaProcesoCargaErrorMontoPercepcion.Add(oViewModel.ProcesoCarga)
                                'End If
                                'If Not flag17 Then
                                '    oViewModel.ListaProcesoCargaErrorTotalVtaIgvPercepcion.Add(oViewModel.ProcesoCarga)
                                'End If
                            Next
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorRuc)
                            ''oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorRuc)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorSku)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorTotal)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorCantidad)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorFecha)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorIgv)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorNumeroDoc)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorSucu)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorTC)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorTpoDoc)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorValVenta)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorMoneda)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorCostoTotal)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorPorcentajePercepcion)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorMontoPercepcion)
                            'oViewModel.ListaProcesoCargaErrorTotales.AddRange(oViewModel.ListaProcesoCargaErrorTotalVtaIgvPercepcion)

                            Dim oLista1 As ListaProcesoCarga = oViewModel.ListaProcesoCarga
                            Dim Suma1 As Decimal = oLista1.Sum(Function(t) t.Total)
                            Dim oLista2 As ListaProcesoCarga = oViewModel.ListaProcesoCargaErrorTotales
                            Dim Suma2 As Decimal = oLista2.Sum(Function(t) t.Total)

                            oViewModel.TotalCorrectos = oViewModel.ListaProcesoCarga.Count()
                            oViewModel.TotalErrores = oViewModel.ListaProcesoCargaErrorTotales.Count()
                            'oViewModel.TotalErrores = oViewModel.ListaProcesoCargaErrorRuc.Count() + oViewModel.ListaProcesoCargaErrorSku.Count() + oViewModel.ListaProcesoCargaErrorTotal.Count()
                            'oViewModel.TotalErrores += oViewModel.ListaProcesoCargaErrorCantidad.Count() + oViewModel.ListaProcesoCargaErrorFecha.Count() + oViewModel.ListaProcesoCargaErrorIgv.Count()
                            'oViewModel.TotalErrores += oViewModel.ListaProcesoCargaErrorNumeroDoc.Count() + oViewModel.ListaProcesoCargaErrorSucu.Count() + oViewModel.ListaProcesoCargaErrorTC.Count()
                            'oViewModel.TotalErrores += oViewModel.ListaProcesoCargaErrorTpoDoc.Count() + oViewModel.ListaProcesoCargaErrorValVenta.Count() + oViewModel.ListaProcesoCargaErrorMoneda.Count()
                            'oViewModel.TotalErrores += oViewModel.ListaProcesoCargaErrorCostoTotal.Count() + oViewModel.ListaProcesoCargaErrorPorcentajePercepcion.Count()
                            'oViewModel.TotalErrores += oViewModel.ListaProcesoCargaErrorMontoPercepcion.Count() + oViewModel.ListaProcesoCargaErrorTotalVtaIgvPercepcion.Count()

                            If oViewModel.TotalCorrectos > 0 Then
                                oViewModel.DescripcionCorrectos = "Se encontraron " + oViewModel.TotalCorrectos.ToString() + " registros por S/." + Suma1.ToString("N2")
                            Else
                                oViewModel.DescripcionCorrectos = Constantes.Clear
                            End If

                            If oViewModel.TotalErrores > 0 Then
                                oViewModel.DescripcionErrores = "Se encontraron " + oViewModel.TotalErrores.ToString() + " errores."
                            Else
                                oViewModel.DescripcionErrores = Constantes.Clear
                            End If

                            Session("ListaErrores") = oViewModel.ListaProcesoCargaErrorTotales
                            Session("ListaGuardar") = oViewModel.ListaProcesoCarga
                            oViewModel.RegistroPorPagina = Constantes.ValorDiez
                        Catch ex As Exception
                            message = "Ocurrió un error mientras se procesaba el archivo, por favor inténtelo nuevamente. Detalle del Error: " & ex.Message
                        End Try
                    Else
                        message = "El fichero Excel no contiene datos."
                    End If
                Catch ex As Exception
                    If TypeOf ex Is OleDbException Then
                        message = "No se encontró la hoja:" & oViewModelProceso.Hoja & " en el archivo " & file.FileName & ".Detalle del Error:" & ex.Message
                    End If

                End Try
            Else
                message = "No es la extensión correcta."
            End If
            oViewModel.mensaje = message
            AsyncManager.Parameters("oViewModelProceso") = oViewModel
        End Sub

        Function AdjuntarDataMensualCompleted(oViewModelProceso As ProcesoViewModel) As ActionResult
            'Dim oViewModelProceso As ProcesoViewModel
            'If AsyncManager.Parameters.ContainsKey("oViewModelProceso") Then
            '    oViewModelProceso = DirectCast(AsyncManager.Parameters("oViewModelProceso"), ProcesoViewModel)
            'Else
            '    oViewModelProceso = New ProcesoViewModel()
            'End If
            Return View("Index", oViewModelProceso)
        End Function

        Private Function LeerArchivoExcel(ByVal file As String, Optional pHoja As String = "DocumentosManuales") As DataSet

            Dim ext As String = If(Path.GetExtension(file).Equals(".xls"), ".xls", ".xlsx")
            Dim cad As String = If(ext.Equals(".xls"), ConfigurationManager.ConnectionStrings("cnExcel03").ConnectionString, ConfigurationManager.ConnectionStrings("cnExcel03").ConnectionString)
            'Dim conStr As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;", file)
            Dim conStr As String = String.Format(cad, file)
            Dim conn2 As New OleDbConnection(conStr)

            Dim da As New OleDbDataAdapter("SELECT * FROM [" & pHoja & "$]", conn2)
            Dim ds As New DataSet()
            Try
                da.Fill(ds)
                Return ds
            Catch ex As Exception
                Throw ex
            Finally
                conn2.Close()
            End Try
            Return ds
        End Function

        Function PV_Historial(Optional sort As String = Constantes.ValorDefecto,
                                      Optional page As Integer = 0,
                                      Optional sortdir As String = Constantes.ValorDefecto) As ActionResult
            Dim oViewModel As New ProcesoViewModel

            Dim Total As Integer

            oViewModel.startRowIndex = page
            Dim ServicioPagina As Integer = 10
            If page = 0 Then
                page = 1
            Else
                page = ((page - 1) * ServicioPagina) + 1
                ServicioPagina -= 1
            End If

            oViewModel.RegistroPorPagina = Constantes.RowsPerPage
            oViewModel.sortType = If(sortdir = "ASC", sort, Convert.ToString(sort) & " DESC")
            oViewModel.maximumRows = ServicioPagina

            oViewModel.ListaProcesoCargaHistorica = New ListaProcesoCarga
            oViewModel.ListaProcesoCargaHistorica = New ProcesoBusinessLogic().ListarHistorial(ServicioPagina, page, Total)
            oViewModel.DescRegistrosPorPagina = ""
            oViewModel.DescRegistrosPorPagina = UtilWebGrid.ContadorRegistrosWebGrid(oViewModel.startRowIndex, Constantes.RowsPerPage, Total)
            oViewModel.TotalRegistros = Total

            Return PartialView(oViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ActualizarEstadoCarga(Optional ByVal IDCarga As Integer = Constantes.ValorCero, Optional ByVal IdEstado As Integer = Constantes.ValorCero) As ActionResult

            Dim oViewModelProceso As New ProcesoViewModel
            Dim oProcesoCarga As New ProcesoCarga()
            Dim resultado As Integer = 0
            Dim oProcesoBusinessLogic As New ProcesoBusinessLogic
            Dim mensaje As String = Constantes.Clear

            resultado = oProcesoBusinessLogic.ActualizarEstadoCargaManual(IDCarga, IdEstado)

            Return Content(Convert.ToString(resultado))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function QuitarEstadohistorialCarga(Optional ByVal IDCarga As Integer = Constantes.ValorCero, Optional ByVal IdEstadoA As Integer = Constantes.ValorCero) As ActionResult
            Dim oViewModelProceso As New ProcesoViewModel
            Dim oProcesoCarga As New ProcesoCarga()
            Dim resultado As Integer = 0
            Dim mensaje As String = Constantes.Clear
            Dim oProcesoBusinessLogic As New ProcesoBusinessLogic

            resultado = oProcesoBusinessLogic.QuitarEstadoCargaManual(IDCarga, IdEstadoA)

            Return Content(Convert.ToString(resultado))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ActualizarComisionesManual(Optional ByVal IdCarga As Integer = Constantes.ValorCero) As ActionResult
            Dim resultado As Integer = 0
            Dim oProcesoBusinessLogic As New ProcesoBusinessLogic

            resultado = oProcesoBusinessLogic.CalculaComisionesCargaManual(IdCarga)

            Return Content(Convert.ToString(resultado))
        End Function

        Public Function ValidarFecha(pFecha As String) As Boolean
            Try
                Dim vFecha As DateTime
                vFecha = Convert.ToDateTime(pFecha)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Function ValidarEmail(email As String) As String
            'Dim isEmail = Regex.IsMatch(email, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)
            'Dim var122 = Regex.IsMatch(email, "^[^@]+@[^@]+\.[a-zA-Z]{2,}$")
            Try
                Dim correo = New MailAddress(email)
                Return email
            Catch ex As Exception
                Return String.Empty
            End Try
        End Function

        Public Function ValidarNumero(pNumero As String) As Boolean
            Try
                Dim vNumero As Decimal
                vNumero = Convert.ToDecimal(pNumero)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Function EsEntero(pNumero As String) As Boolean
            Try
                Dim vNumero As Integer
                vNumero = Convert.ToInt32(pNumero)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function VerDetalleHistorial(IDCarga As Integer) As ActionResult
            Dim oViewModel As New ProcesoViewModel
            oViewModel.ListaProcesoCarga = New ProcesoBusinessLogic().ListaDetalleHistorial(IDCarga)
            oViewModel.RegistroPorPagina = Constantes.ValorDiez
            Return PartialView(ParametrosView.ParametrosPartialView.PV_Grilla, oViewModel)
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

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

        Private Function BorrarFilasVacias(ByVal dt As DataTable) As DataTable
            Try
                For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                    Dim row As DataRow = dt.Rows(i)
                    If row.Item(0) Is Nothing Then
                        dt.Rows.Remove(row)
                    ElseIf row.Item(0).ToString = "" Then
                        dt.Rows.Remove(row)
                    End If
                Next
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        Private Function EsTipoDocumentoValido(Proceso As ProcesoCarga, ListaTipoDocumento As ListaProcesoCarga) As Boolean
            If Not ListaTipoDocumento.Find(Function(m) m.TipoDocumento = Proceso.TipoDocumento) Is Nothing Then
                Proceso.IdTipoDocumento = ListaTipoDocumento.Find(Function(m) m.TipoDocumento = Proceso.TipoDocumento).IdTipoDocumento
                Return True
            Else
                Return False
            End If
        End Function

        Private Function EsSucursalValido(Proceso As ProcesoCarga, ListaSucursal As ListaProcesoCarga) As Boolean
            If Not ListaSucursal.Find(Function(m) m.IdSucursalReal = Proceso.IdSucursal) Is Nothing Then
                Dim SucursalProcesoCarga = ListaSucursal.Find(Function(m) m.IdSucursalReal = Proceso.IdSucursal)

                Proceso.IdSucursalReal = SucursalProcesoCarga.IdSucursalReal 'Proceso.IdSucursal
                Proceso.IdSucursal = SucursalProcesoCarga.IdSucursal
                Proceso.NombreSucursal = SucursalProcesoCarga.NombreSucursal
                'Proceso.IdSucursal = ListaSucursal.Find(Function(m) m.IdSucursalReal = Proceso.IdSucursalReal).IdSucursal
                Return True
            Else
                Return False
            End If
        End Function

        Private Function EsMonedaValida(Proceso As ProcesoCarga, ListaMoneda As ListaProcesoCarga) As Boolean
            If Not ListaMoneda.Find(Function(m) m.Moneda = Proceso.Moneda) Is Nothing Then
                Proceso.IdMoneda = ListaMoneda.Find(Function(m) m.Moneda = Proceso.Moneda).IdMoneda
                Return True
            Else
                Return False
            End If
        End Function

        Private Function EsProductoValido(Proceso As ProcesoCarga, ListaProducto As ListaProcesoCarga) As Boolean
            Dim tmp = ListaProducto.Find(Function(m) m.Sku = Proceso.Sku)
            If Not tmp Is Nothing Then
                Proceso.Sku = tmp.Sku
                Proceso.DescripcionSku = tmp.DescripcionSku
                Proceso.ClaCom = tmp.ClaCom
                Proceso.DescripcionClaCom = tmp.DescripcionClaCom
                Proceso.CodDepAnt = tmp.CodDepAnt
                Proceso.NomDepAnt = tmp.NomDepAnt
                Proceso.CodFamAnt = tmp.CodFamAnt
                Proceso.NomFamAnt = tmp.NomFamAnt
                Proceso.CostoUnitario = tmp.CostoUnitario
                Return (True)
            Else
                Return False
            End If
        End Function

        Private Function EsClienteValido(Proceso As ProcesoCarga, ListaClienteVenta As ListaClienteVenta) As Boolean
            Dim tmp = ListaClienteVenta.Find(Function(m) m.RUC = Proceso.Ruc)
            If Not tmp Is Nothing Then
                Proceso.Ruc = tmp.RUC
                Proceso.IdCliente = tmp.IdCliente
                Proceso.RazonSocial = tmp.RazonSocial
                Proceso.NombreCliente = tmp.NombreFantasia
                Proceso.NumeroTarjeta = tmp.NumeroTarjeta
                Return True
            Else
                Return False
            End If
        End Function

        Private Sub CalcularValores(oProcesoCarga As ProcesoCarga)
            Dim cant As Integer = oProcesoCarga.Cantidad
            'Dim pctigv As Decimal = Decimal.Parse(New ProcesoBusinessLogic().ListaParametrosCargaManual(3).Valor1)
            Dim pctigv As Decimal = Decimal.Parse("0.18")
            'Venta.Venta
            oProcesoCarga.VVPrecioNeto = If(cant = 0, 0, oProcesoCarga.ValorVenta / cant)
            oProcesoCarga.Margen = If(oProcesoCarga.Total = 0, 0, (1 - (oProcesoCarga.CostoUnitario / oProcesoCarga.Total)))
            oProcesoCarga.Contribucion = oProcesoCarga.Total - (oProcesoCarga.CostoUnitario * cant)
            oProcesoCarga.VVIGV = oProcesoCarga.VVPrecioNeto * pctigv
            oProcesoCarga.PrecioIGV = oProcesoCarga.VVPrecioNeto + oProcesoCarga.VVIGV
            oProcesoCarga.VVTotal = oProcesoCarga.Total
            'Venta.VentaDetalle
            oProcesoCarga.Valor = If(cant = 0, 0, oProcesoCarga.Total / cant)
            oProcesoCarga.VDIGV = oProcesoCarga.Valor * pctigv
            'Venta.VentaCabecera
        End Sub

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function ObtenerResultadoReproceso() As ActionResult
            Return Content(New ProcesoBusinessLogic().ObtenerResultadoReprocesoVenta().ToString)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function CierrePeriodo() As ActionResult
            Return View()
        End Function

#Region "Carga Masiva Cliente"
        Public Function CargaMasivaCliente() As ActionResult
            Dim oViewModel As New CargaMasivaClienteViewModel
            oViewModel.ListaProcesoCargaErrorTotales = New ListaErrorCargaMasiva
            oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente = New List(Of CargaMasivaCliente)
            oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado = New List(Of CargaMasivaCliente)
            Dim oProcesoBusinnessLogic As New ProcesoBusinessLogic
            oViewModel.ListaTipoOperacion = oProcesoBusinnessLogic.ListaTipoOperacion()
            Return View(oViewModel)
        End Function

        Function CargarClientePri(oCargaClienteViewModel As CargaMasivaClienteViewModel, Optional ByVal page As Integer = 1) As ActionResult
            Dim oViewModel As New CargaMasivaClienteViewModel
            Dim oProcesoBusinnessLogic As New ProcesoBusinessLogic
            oViewModel.PaginacionCliente = New Paginacion
            oViewModel.PaginacionClienteEmpleado = New Paginacion
            oViewModel.TipoOperacion = New TipoOperacion
            Dim message As String = Constantes.Clear
            Dim grabar As String = String.Empty
            Dim file As HttpPostedFileBase = Me.HttpContext.Request.Files.[Get]("file1")
            oViewModel.ListaTipoOperacion = oProcesoBusinnessLogic.ListaTipoOperacion()
            oViewModel.TipoOperacion.IdTipoOperacion = oCargaClienteViewModel.TipoOperacion.IdTipoOperacion
            Dim ext As String = Path.GetExtension(file.FileName)

            'Dim Log As Log = Session("Log")

            'Log.DescripcionAccion = "Archivo:" & file.FileName
            'Log.IdOrigenAccion = Constantes.Venta_CargaManual
            'Log.IdLogAccion = Constantes.Visualizar
            'Dim LogBE As New LogBusinessLogic()
            'LogBE.ActualizarLog(Log)

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
                    oViewModel.ListaProcesoCargaErrorCliente = New List(Of CargaMasivaCliente)
                    oViewModel.ListaProcesoCargaErrorTotales = New ListaErrorCargaMasiva
                    oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente = New List(Of CargaMasivaCliente)
                    oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado = New List(Of CargaMasivaCliente)

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

                    'CLIENTES_EMPLEADOS-----------------------------------------------------
                    Dim dsE As New DataSet()
                    NombreHoja = "Clientes_Empleados"
                    dsE = excelReader.AsDataSet(True)

                    Dim dtE As New DataTable
                    Try
                        dtE = BorrarFilasVaciasCargaMasiva(dsE.Tables(NombreHoja))
                    Catch ex As Exception
                        dtE = New DataTable
                    End Try
                    '-----------------------------------------------------------------------

                    If (dtC.Rows.Count <> 0 Or dtE.Rows.Count <> 0) Then
                        oViewModel.CargaMasivaCliente = New CargaMasivaCliente
                        oViewModel.DesAccion = If(oCargaClienteViewModel.CargaMasivaCliente.Accion, "REGISTRA", "DESACTIVA")
                        oViewModel.DesAccionAnt = oViewModel.DesAccion
                        Dim lst As ListaCargaMasivaCliente = oProcesoBusinnessLogic.ListaPrincipal()

                        Dim i As Int32
                        Try
                            If (dtC.Rows.Count <> 0) Then
                                oViewModel.ListaCliente = New List(Of CargaMasivaCliente)
                                oViewModel.ListaClienteTotal = New List(Of CargaMasivaCliente)

                                'PESTAÑA 1: CLIENTES
                                For i = 0 To dtC.Rows.Count - 1
                                    Dim flag0 As Boolean = True
                                    Dim flag1 As Boolean = True
                                    Dim flag2 As Boolean = True
                                    Dim flag3 As Boolean = True
                                    Dim flag4 As Boolean = True
                                    Dim flag5 As Boolean = True
                                    Dim flag6 As Boolean = True
                                    Dim flag7 As Boolean = True
                                    Dim flag8 As Boolean = True
                                    Dim flag9 As Boolean = True
                                    Dim flag10 As Boolean = True
                                    Dim flag11 As Boolean = True
                                    Dim flag12 As Boolean = True
                                    Dim flag13 As Boolean = True
                                    Dim flag14 As Boolean = True
                                    Dim flag15 As Boolean = True
                                    Dim flag16 As Boolean = True
                                    Dim flag17 As Boolean = True
                                    Dim flagNoExiste As Boolean = True
                                    Dim flagContacto As Boolean = True
                                    oViewModel.CargaMasivaCliente = New CargaMasivaCliente
                                    oViewModel.CargaMasivaCliente.ClienteVenta = New ClienteVenta
                                    oViewModel.CargaMasivaCliente.Departamento = New Departamento
                                    oViewModel.CargaMasivaCliente.Provincia = New Provincia
                                    oViewModel.CargaMasivaCliente.Distrito = New Distrito
                                    oViewModel.CargaMasivaCliente.ClienteVenta.Grupo = New Grupo
                                    oViewModel.CargaMasivaCliente.ClienteSector = New ClienteSector
                                    oViewModel.CargaMasivaCliente.ClienteCategoria = New ClienteCategoria
                                    oViewModel.CargaMasivaCliente.ClienteTipo = New ClienteTipo
                                    oViewModel.CargaMasivaCliente.ClienteContacto = New ClienteContacto
                                    oViewModel.CargaMasivaCliente.ClienteContacto.TipoContancto = New ContactoTipo
                                    oViewModel.CargaMasivaCliente.ClienteContacto.ClaseContacto = New ContactoClase
                                    oViewModel.CargaMasivaCliente.ProcesoCarga = New ProcesoCarga

                                    flagContacto = ValidarContacto(If(Convert.IsDBNull(dtC.Rows(i)(15)), String.Empty, CStr(dtC.Rows(i)(15))),
                                                                    If(Convert.IsDBNull(dtC.Rows(i)(16)), String.Empty, CStr(dtC.Rows(i)(16))),
                                                                    If(Convert.IsDBNull(dtC.Rows(i)(17)), String.Empty, CStr(dtC.Rows(i)(17))),
                                                                    If(Convert.IsDBNull(dtC.Rows(i)(18)), String.Empty, CStr(dtC.Rows(i)(18))))

                                    For j = 0 To dtC.Columns.Count - 1
                                        Select Case j
                                            'Razón Social
                                            Case 0
                                                oViewModel.CargaMasivaCliente.ClienteVenta.RazonSocial = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.RazonSocial = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 1
                                                'Tipo Documento
                                                oViewModel.CargaMasivaCliente.TieneRuc = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty)) Then
                                                    flag17 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO DOCUMENTO, "
                                                Else
                                                    If (lst.lstTipoDocumento.Select(Function(m) m.Descripcion).Contains(oViewModel.CargaMasivaCliente.TieneRuc.Trim.ToUpper())) Then
                                                        oViewModel.CargaMasivaCliente.TieneRuc = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                    Else
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO DOCUMENTO, "
                                                    End If
                                                End If

                                            Case 2
                                                'RUC
                                                oViewModel.CargaMasivaCliente.ClienteVenta.RUC = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty)) Then
                                                    flag1 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " RUC, "
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.RUC = "Vacio "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.RUC = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                    If (ValidarRUCDNI(oViewModel.CargaMasivaCliente)) Then
                                                        oViewModel.CargaMasivaCliente.ClienteVenta.RUC = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                    Else
                                                        flag1 = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " RUC, "
                                                    End If
                                                End If

                                            Case 3
                                                'Nombre Comercial
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag2 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " NOMBRE COMERCIAL, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.NombreComercial = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                End If

                                            Case 4
                                                'Departamento
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag3 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " DEPARTAMENTO, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.Departamento.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                        If (lst.lstDepartamento.Select(Function(m) m.Descripcion).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.Departamento.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())

                                                            Dim descripcion As String = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper
                                                            oViewModel.CargaMasivaCliente.Departamento.IdDepartamento = lst.lstDepartamento.Where(Function(m) m.Descripcion.Equals(descripcion).ToString.ToUpper()).Select(Function(m) m.IdDepartamento).FirstOrDefault()
                                                        Else
                                                            flag3 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " DEPARTAMENTO, "
                                                        End If
                                                    End If
                                                End If

                                            Case 5
                                                'Provincia
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag4 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " PROVINCIA, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.Provincia.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                        If (lst.lstProvincia.Select(Function(m) m.Descripcion).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.Provincia.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.Provincia.IdProvincia = lst.lstProvincia.Where(Function(m) m.Descripcion.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper))).Select(Function(m) m.IdProvincia).FirstOrDefault()
                                                        Else
                                                            flag4 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " PROVINCIA, "
                                                        End If
                                                    End If
                                                End If

                                            Case 6
                                                'Distrito
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag5 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " DISTRITO, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.Distrito.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                        If (lst.lstDistrito.Select(Function(m) m.Descripcion).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.Distrito.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.Distrito.IdDistrito = lst.lstDistrito.Where(Function(m) m.Descripcion.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper))).Select(Function(m) m.IdDistrito).FirstOrDefault()
                                                        Else
                                                            flag5 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " DISTRITO, "
                                                        End If
                                                    End If
                                                End If

                                            Case 7
                                                'Dirección
                                                oViewModel.CargaMasivaCliente.ClienteVenta.Direccion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)

                                            Case 8
                                                'Fecha Ingreso
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag6 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " FECHA INGRESO, "
                                                Else
                                                    Dim isdate As Boolean = True
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                                                        isdate = ValidarFecha(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim))
                                                    End If

                                                    If (isdate) Then
                                                        oViewModel.CargaMasivaCliente.ClienteVenta.FechaIngreso = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                    Else
                                                        flag6 = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " FECHA INGRESO, "
                                                    End If
                                                End If

                                            Case 9
                                                'Fecha Vigencia
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True) And oViewModel.CargaMasivaCliente.TieneRuc.Equals("DNI")) Then
                                                    flag7 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " FECHA VIGENCIA, "
                                                Else
                                                    Dim isdate As Boolean = True
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion And oViewModel.CargaMasivaCliente.TieneRuc.Equals("DNI")) Then
                                                        isdate = ValidarFecha(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim))
                                                    End If
                                                    If (isdate) Then
                                                        oViewModel.CargaMasivaCliente.ClienteVenta.FechaVigencia = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                    Else
                                                        flag7 = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " FECHA VIGENCIA, "
                                                    End If
                                                End If

                                            Case 10
                                                'Grupo
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag8 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " GRUPO, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.Grupo.NombreGrupo = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                                                        If (lst.lstGrupo.Select(Function(m) m.NombreGrupo).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.ClienteVenta.Grupo.NombreGrupo = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.ClienteVenta.Grupo.IdGrupo = lst.lstGrupo.Where(Function(m) m.NombreGrupo.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper))).Select(Function(m) m.IdGrupo).FirstOrDefault()
                                                        Else
                                                            flag8 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " GRUPO, "
                                                        End If
                                                    End If
                                                End If

                                            Case 11
                                                'Procedencia
                                                oViewModel.CargaMasivaCliente.ClienteVenta.ProcedenciaCapital = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)

                                            Case 12
                                                'Sector Económico
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag9 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " SECTOR ECONÓMICO, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteSector.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                                                        If (lst.lstSector.Select(Function(m) m.Descripcion).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.ClienteSector.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.ClienteSector.IdClienteSector = lst.lstSector.Where(Function(m) m.Descripcion.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper()))).Select(Function(m) m.IdClienteSector).FirstOrDefault()
                                                        Else
                                                            flag9 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " SECTOR ECONÓMICO, "
                                                        End If
                                                    End If
                                                End If

                                            Case 13
                                                'Categoría
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag10 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " CATEGORÍA, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteCategoria.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                                                        If (lst.lstCategoria.Select(Function(m) m.Descripcion).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.ClienteCategoria.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.ClienteCategoria.IdClienteCategoria = lst.lstCategoria.Where(Function(m) m.Descripcion.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim))).Select(Function(m) m.IdClienteCategoria).FirstOrDefault()
                                                        Else
                                                            flag10 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " CATEGORÍA, "
                                                        End If
                                                    End If
                                                End If

                                            Case 14
                                                'Tipo
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag11 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteTipo.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                                                        If (lst.lstTipo.Select(Function(m) m.Descripcion).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.ClienteTipo.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.ClienteTipo.IdClienteTipo = lst.lstTipo.Where(Function(m) m.Descripcion.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper()))).Select(Function(m) m.IdClienteTipo).FirstOrDefault()
                                                        Else
                                                            flag11 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO, "
                                                        End If
                                                    End If
                                                End If

                                            Case 15
                                                'Autorizar
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag12 = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " AUTORIZAR, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.Autorizar = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                End If

                                            Case 16
                                                'Tipo Contacto
                                                If (Not flagContacto) Then
                                                    If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                        flag13 = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO CONTACTO, "
                                                    Else
                                                        oViewModel.CargaMasivaCliente.ClienteContacto.TipoContancto.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                        If (lst.lstTipoContacto.Select(Function(m) m.DescripcionTabGen).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.ClienteContacto.TipoContancto.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.ClienteContacto.TipoContancto.IdContactoTipo = lst.lstTipoContacto.Where(Function(m) m.DescripcionTabGen.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim))).Select(Function(m) m.IdTabGen).FirstOrDefault()
                                                        Else
                                                            flag13 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO CONTACTO, "
                                                        End If
                                                    End If
                                                End If

                                            Case 17
                                                'Clase Contacto
                                                If (Not flagContacto) Then
                                                    If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                        flag14 = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " CLASE CONTACTO, "
                                                    Else
                                                        oViewModel.CargaMasivaCliente.ClienteContacto.ClaseContacto.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                        If (lst.lstClaseContacto.Select(Function(m) m.DescripcionTabGen).Contains(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.ClienteContacto.ClaseContacto.Descripcion = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.ClienteContacto.ClaseContacto.IdContactoClase = lst.lstClaseContacto.Where(Function(m) m.DescripcionTabGen.Equals(If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim))).Select(Function(m) m.IdTabGen).FirstOrDefault()
                                                        Else
                                                            flag14 = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " CLASE CONTACTO, "
                                                        End If
                                                    End If
                                                End If

                                            Case 18
                                                'Nombres Contacto
                                                If (Not flagContacto) Then
                                                    If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                        flag15 = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " NOMBRES CONTACTO, "
                                                    Else
                                                        oViewModel.CargaMasivaCliente.ClienteContacto.Nombres = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    End If
                                                End If

                                            Case 19
                                                'Apellidos Contacto
                                                If (Not flagContacto) Then
                                                    If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                        flag16 = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " APELLIDOS CONTACTO, "
                                                    Else
                                                        oViewModel.CargaMasivaCliente.ClienteContacto.Apellidos = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim.ToUpper())
                                                    End If
                                                End If

                                            Case 20
                                                'Celular
                                                oViewModel.CargaMasivaCliente.ClienteContacto.Celular1 = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)

                                            Case 21
                                                'Email
                                                oViewModel.CargaMasivaCliente.ClienteContacto.Email = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                        End Select
                                    Next

                                    Dim ruc As Object = dtC.Rows(i)(2)
                                    Dim duplicados As Integer = 0
                                    duplicados = (From rucs In dtC.Rows Where rucs(2).ToString().Trim() = ruc.ToString().Trim() Select rucs(2)).Count()

                                    If flag0 And flag1 And flag2 And flag3 And flag4 And flag5 And flag6 And flag7 And flag8 And flag9 And flag10 And flag11 And flag12 And flag13 And flag14 And flag15 And flag16 And flag17 And duplicados <= 1 Then
                                        oViewModel.ListaCliente.Add(oViewModel.CargaMasivaCliente)
                                        oViewModel.ListaClienteTotal.Add(oViewModel.CargaMasivaCliente)
                                    Else
                                        Dim str As String = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError
                                        If (Not flagNoExiste) Then
                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = " NO EXISTE "
                                            oViewModel.ListaProcesoCargaErrorCliente.Add(oViewModel.CargaMasivaCliente)
                                        Else
                                            If duplicados > 1 Then
                                                oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = " está duplicado."
                                            Else
                                                oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = String.Format("{0} {1}", " tiene un error en la columna(s) ", str.Substring(0, str.Length - 2))
                                            End If
                                            oViewModel.ListaProcesoCargaErrorCliente.Add(oViewModel.CargaMasivaCliente)
                                        End If
                                    End If

                                Next

                                oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalCliente.AddRange(oViewModel.ListaProcesoCargaErrorCliente)
                            End If

                            'PESTAÑA 2: CLIENTES_EMPLEADOS
                            If (dtE.Rows.Count <> 0) Then
                                oViewModel.ListaClienteEmpleado = New List(Of CargaMasivaCliente)
                                oViewModel.ListaClienteEmpleadoTotal = New List(Of CargaMasivaCliente)
                                oViewModel.ListaProcesoCargaErrorClienteEmpleado = New List(Of CargaMasivaCliente)
                                Dim lstClienteRuc = New ProcesoBusinessLogic().ListaCliente()

                                For i = 0 To dtE.Rows.Count - 1
                                    Dim flag0CE As Boolean = True
                                    Dim flag1CE As Boolean = True
                                    Dim flag2CE As Boolean = True
                                    Dim flag3CE As Boolean = True
                                    Dim flag4CE As Boolean = True
                                    Dim flag5CE As Boolean = True
                                    Dim flag6CE As Boolean = True

                                    oViewModel.CargaMasivaCliente = New CargaMasivaCliente
                                    oViewModel.CargaMasivaCliente.ClienteVenta = New ClienteVenta
                                    oViewModel.CargaMasivaCliente.Empleado = New Empleado
                                    oViewModel.CargaMasivaCliente.Empleado.TablaGeneral = New TablaGeneral
                                    oViewModel.CargaMasivaCliente.ProcesoCarga = New ProcesoCarga
                                    oViewModel.CargaMasivaCliente.Empleado.Sucursal = New Sucursal

                                    For j = 0 To dtE.Columns.Count - 1
                                        Select Case j
                                    'RUC
                                            Case 0
                                                If (If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j))).Trim.Equals(String.Empty)) Then
                                                    flag0CE = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = " RUC, "
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.RUC = "Vacio "
                                                Else
                                                    Dim lstClienteRucS = New ProcesoBusinessLogic().ListaClienteRuc(dtE.Rows(i)(j))
                                                    oViewModel.CargaMasivaCliente.ClienteVenta.RUC = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)

                                                    If (lstClienteRucS.Select(Function(m) m.RUC).Contains(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))) Then
                                                        oViewModel.CargaMasivaCliente.ClienteVenta.RUC = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)
                                                        oViewModel.CargaMasivaCliente.Empleado.IdCliente = lstClienteRucS.Where(Function(m) m.RUC.Equals(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))).Select(Function(m) m.IdCliente).FirstOrDefault()
                                                    Else
                                                        flag0CE = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " RUC, "
                                                    End If
                                                End If

                                            Case 1
                                                'Tipo Vendedor
                                                If (If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag1CE = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO VENDEDOR, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.Empleado.TablaGeneral.DescripcionTabGen = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim).ToUpper()
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                                                        If (lst.lstTipoVendedor.Select(Function(m) m.DescripcionTabGen).Contains(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim).ToUpper())) Then
                                                            oViewModel.CargaMasivaCliente.Empleado.TablaGeneral.DescripcionTabGen = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim.ToUpper())
                                                            oViewModel.CargaMasivaCliente.Empleado.TablaGeneral.IdTabGen = lst.lstTipoVendedor.Where(Function(m) m.DescripcionTabGen.Equals(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))).Select(Function(m) m.IdTabGen).FirstOrDefault()
                                                        Else
                                                            flag1CE = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " TIPO VENDEDOR, "
                                                        End If
                                                    End If
                                                End If

                                            Case 2
                                                'Código Ofisis
                                                If (If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j))).Trim.Equals(String.Empty)) Then
                                                    flag3CE = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " CÓDIGO OFISIS, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.Empleado.CodigoOfisis = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)

                                                    If (lst.lstEmpleado.Select(Function(m) m.CodigoOfisis).Contains(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))) Then
                                                        oViewModel.CargaMasivaCliente.Empleado.CodigoOfisis = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)
                                                        oViewModel.CargaMasivaCliente.Empleado.IdEmpleado = lst.lstEmpleado.Where(Function(m) m.CodigoOfisis.Equals(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))).Select(Function(m) m.IdEmpleado).FirstOrDefault()
                                                        'oViewModel.CargaMasivaCliente.Empleado.Sucursal.CodigoSucursal = lst.lstEmpleado.Where(Function(m) m.CodigoOfisis.Equals(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))).Select(Function(m) m.IdSucursalActual).FirstOrDefault()
                                                        oViewModel.CargaMasivaCliente.Empleado.Sucursal.CodigoSucursal = lst.lstEmpleadoSecundario.Where(Function(m) m.CodigoOfisis.Equals(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))).Select(Function(m) m.CodigoSucursal).FirstOrDefault()
                                                    Else
                                                        If (flag2CE And lst.lstEmpleado.Where(Function(m) m.IdSucursalActual.Equals(CInt(oViewModel.CargaMasivaCliente.Empleado.Sucursal.CodigoSucursal))).Select(Function(m) m.Apellidos).Contains(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))) Then
                                                            oViewModel.CargaMasivaCliente.Empleado.CodigoOfisis = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)))
                                                            oViewModel.CargaMasivaCliente.Empleado.IdEmpleado = lst.lstEmpleado.Where(Function(m) m.Apellidos.Equals(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)) And m.IdSucursalActual.Equals(CInt(oViewModel.CargaMasivaCliente.Empleado.Sucursal.CodigoSucursal))).Select(Function(m) m.IdEmpleado).FirstOrDefault()
                                                            oViewModel.CargaMasivaCliente.Empleado.IdSucursalActual = lst.lstEmpleado.Where(Function(m) m.CodigoOfisis.Equals(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))).Select(Function(m) m.IdSucursalActual).FirstOrDefault()
                                                        Else
                                                            flag3CE = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " CÓDIGO OFISIS, "
                                                        End If

                                                    End If
                                                End If

                                            Case 3
                                                'Fecha Asignación
                                                If (If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag4CE = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " FECHA ASIGNACIÓN, "
                                                Else
                                                    oViewModel.CargaMasivaCliente.Empleado.FechaAsignacion = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)
                                                    If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                                                        Dim isdate As Boolean = ValidarFecha(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))
                                                        If (isdate) Then
                                                            oViewModel.CargaMasivaCliente.Empleado.FechaAsignacion = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)
                                                        Else
                                                            flag4CE = False
                                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " FECHA ASIGNACIÓN, "
                                                        End If
                                                    End If
                                                End If

                                            Case 4
                                                'Porcentaje
                                                If (If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j))).Trim.Equals(String.Empty) And oCargaClienteViewModel.CargaMasivaCliente.Accion.Equals(True)) Then
                                                    flag5CE = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " PORCENTAJE, "
                                                Else
                                                    Dim isnumeric As Boolean = True
                                                    isnumeric = ValidarNumero(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))

                                                    If isnumeric Then
                                                        oViewModel.CargaMasivaCliente.Empleado.Porcentaje = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)
                                                    Else
                                                        flag5CE = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " PORCENTAJE, "
                                                    End If
                                                End If
                                            Case 5
                                                'Sucursal
                                                If (If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j))).Trim.Equals(String.Empty)) Then
                                                    flag6CE = False
                                                    oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " SUCURSAL, "
                                                Else
                                                    Dim isnumeric As Boolean = True
                                                    isnumeric = ValidarNumero(If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim))

                                                    If isnumeric And flag1CE Then
                                                        oViewModel.CargaMasivaCliente.Empleado.SucursalSecundario = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)
                                                        oViewModel.CargaMasivaCliente.Empleado.Sucursal.CodigoSucursal = If(Convert.IsDBNull(dtE.Rows(i)(j)), String.Empty, CStr(dtE.Rows(i)(j)).Trim)
                                                    Else
                                                        flag6CE = False
                                                        oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError + " SUCURSAL, "
                                                    End If
                                                End If
                                        End Select
                                    Next

                                    Dim ruc As Object = dtE.Rows(i)(0)
                                    Dim duplicados As Integer = 0
                                    duplicados = (From rucs In dtE.Rows Where rucs(0).ToString().Trim() = ruc.ToString().Trim() Select rucs(0)).Count()

                                    If flag0CE And flag1CE And flag2CE And flag3CE And flag4CE And flag5CE And flag6CE Then
                                        oViewModel.ListaClienteEmpleado.Add(oViewModel.CargaMasivaCliente)
                                        oViewModel.ListaClienteEmpleadoTotal.Add(oViewModel.CargaMasivaCliente)
                                    Else
                                        Dim str As String = oViewModel.CargaMasivaCliente.ProcesoCarga.DescError
                                        If duplicados > 1 Then
                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = " está duplicado."
                                        Else
                                            oViewModel.CargaMasivaCliente.ProcesoCarga.DescError = String.Format("{0} {1}", " tiene un error en la columna(s) ", str.Substring(0, str.Length - 2))
                                        End If
                                        oViewModel.ListaProcesoCargaErrorClienteEmpleado.Add(oViewModel.CargaMasivaCliente)
                                    End If
                                Next

                                oViewModel.ListaProcesoCargaErrorTotales.ListaProcesoCargaErrorTotalClienteEmpleado.AddRange(oViewModel.ListaProcesoCargaErrorClienteEmpleado)
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
            Session("tmpCargaMasiva") = oViewModel
            Return RedirectToAction("CargarCliente", "Proceso", New With {.page = page})

        End Function

        Private Function ToNumericOnly(input As String) As String
            Dim rgx = New Regex("[^0-9]")
            Return rgx.Replace(input, "")
        End Function

        Private Function ValidaRazonSocial(_Cliente As ClienteVenta, ListaClienteVenta As List(Of ClienteVenta)) As Boolean
            If Not ListaClienteVenta.Find(Function(m) m.RazonSocial = _Cliente.RazonSocial) Is Nothing Then
                _Cliente.RazonSocial = ListaClienteVenta.Find(Function(m) m.RazonSocial = _Cliente.RazonSocial).RazonSocial
                Return True
            Else
                Return False
            End If
        End Function

        Private Function ValidarContacto(TipoC As String, Clase As String, Nombre As String, Apellido As String) As Boolean
            If (TipoC.Equals(String.Empty) And Clase.Equals(String.Empty) And Nombre.Equals(String.Empty) And Apellido.Equals(String.Empty)) Then
                Return True
            Else
                Return False
            End If

        End Function

        Private Function ValidarRUCDNI(ByVal oModel As CargaMasivaCliente) As Boolean
            If (oModel.TieneRuc.Equals("RUC") And oModel.ClienteVenta.RUC.Trim.Length.Equals(11)) Then
                Return True
            Else
                If (oModel.TieneRuc.Equals("DNI") And oModel.ClienteVenta.RUC.Trim.Length.Equals(8)) Then
                    Return True
                Else
                    Return False
                End If
            End If
        End Function

        Function CargarCliente(Optional ByVal page As Integer = 1) As ActionResult
            Dim lstClienteEmpleado As New List(Of CargaMasivaCliente)
            Dim lstCliente As New List(Of CargaMasivaCliente)
            tmp = Session("tmpCargaMasiva")
            lstClienteEmpleado = If(Not tmp.ListaClienteEmpleadoTotal Is Nothing, tmp.ListaClienteEmpleadoTotal.ToList(), New List(Of CargaMasivaCliente)) 'tmp.ListaClienteEmpleadoTotal.ToList()
            lstCliente = If(Not tmp.ListaClienteTotal Is Nothing, tmp.ListaClienteTotal.ToList(), New List(Of CargaMasivaCliente))

            tmp.PaginacionCliente.RowsPerPage = Constantes.ValorDiez
            tmp.PaginacionCliente.TotalRows = If(Not tmp.ListaCliente Is Nothing, tmp.ListaCliente.Count(), 0)

            tmp.PaginacionClienteEmpleado.Page = Constantes.ValorUno
            tmp.PaginacionClienteEmpleado.RowsPerPage = Constantes.ValorDiez
            tmp.PaginacionClienteEmpleado.TotalRows = If(Not tmp.ListaClienteEmpleado Is Nothing, tmp.ListaClienteEmpleado.Count(), 0)

            tmp.ListaCliente = lstCliente.Skip((page - 1) * 10).Take(10).ToList()
            tmp.ListaClienteEmpleado = lstClienteEmpleado.Skip((page - 1) * 10).Take(10).ToList()
            tmp.PaginacionCliente.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmp.PaginacionCliente.TotalRows)
            tmp.PaginacionClienteEmpleado.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmp.PaginacionClienteEmpleado.TotalRows)
            Return View("CargaMasivaCliente", tmp)
        End Function

        Function CargarCMCliente(Optional ByVal page As Integer = Constantes.ValorUno)
            Dim lstCliente As New List(Of CargaMasivaCliente)
            tmp = Session("tmpCargaMasiva")
            lstCliente = tmp.ListaClienteTotal.ToList()
            tmp.ListaCliente = lstCliente.Skip((page - 1) * 10).Take(10).ToList()
            tmp.PaginacionCliente.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmp.PaginacionCliente.TotalRows)
            Return PartialView("PV_CargaMasivaCliente", tmp)
        End Function

        Function CargarClienteEmpleado(Optional ByVal page As Integer = Constantes.ValorUno) As ActionResult
            Dim lstClienteEmpleado As New List(Of CargaMasivaCliente)
            tmp = Session("tmpCargaMasiva")
            lstClienteEmpleado = tmp.ListaClienteEmpleadoTotal.ToList()
            tmp.ListaClienteEmpleado = lstClienteEmpleado.Skip((page - 1) * 10).Take(10).ToList()
            tmp.PaginacionClienteEmpleado.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmp.PaginacionClienteEmpleado.TotalRows)
            Return PartialView("PV_CargaMasivaClienteEmpleado", tmp)
        End Function

        Function GuardarCliente(oCargaClienteViewModel As CargaMasivaClienteViewModel) As ActionResult
            tmp = Session("tmpCargaMasiva")
            Dim Log As Log = Session("Log")
            Dim result = String.Empty
            If (oCargaClienteViewModel.CargaMasivaCliente.Accion) Then
                result = New ProcesoBusinessLogic().RegistraCliente(tmp.ListaClienteTotal, tmp.ListaClienteEmpleadoTotal, Log)
            Else
                result = New ProcesoBusinessLogic().DesactivaCliente(tmp.ListaClienteTotal, tmp.ListaClienteEmpleadoTotal, Log)
            End If

            Return Content(result)
        End Function

        Function DescargarPlantilla() As FileResult
            Dim nameFile = "PlantillaCargaMasivaCliente.xlsx"
            Dim ruta = Server.MapPath("~/Files")
            Dim pathFile = Path.Combine(ruta, nameFile)
            Dim fil = System.IO.File.ReadAllBytes(pathFile)
            Return File(fil, System.Net.Mime.MediaTypeNames.Application.Octet, nameFile)
        End Function

#End Region

        Public Function CargarMasivaEmpleado() As ActionResult
            Dim model = New ProcesoViewModel()
            Dim oProcesooBusinessLogic = New ProcesoBusinessLogic

            model.ListaOperacion = oProcesooBusinessLogic.ListaOperacion()


            Return View(model)

        End Function

        Function AdjuntarDataEmpleadoAsync(oViewModelProceso As ProcesoViewModel, Optional ByVal page As Integer = 1)
            Dim oViewModel As New ProcesoViewModel
            Dim oProcesooBusinessLogic = New ProcesoBusinessLogic
            Dim grabar As String = String.Empty
            Dim empleadoPrueba, Codigos As String

            oViewModel.PaginacionEmpleado = New Paginacion
            'Dim fecha_contrato, Fecha_Nacim, fecha_Ingreso As Date
            Dim IdOperacion = oViewModelProceso.Operacion.Operacion
            Session("Operacion") = IdOperacion
            oViewModel.ListaOperacion = oProcesooBusinessLogic.ListaOperacion()

            Dim message As String = Constantes.Clear
            Dim files As HttpPostedFileBase = Me.HttpContext.Request.Files.[Get]("file1")
            Dim ext As String = Path.GetExtension(files.FileName)

            Dim Log As Log = Session("Log")

            Log.DescripcionAccion = "Archivo:" & files.FileName
            Log.IdOrigenAccion = Constantes.Venta_CargaManual
            AsyncManager.Parameters("oViewModelProceso") = oViewModel
            Session("File") = files.FileName
            Log.IdLogAccion = Constantes.Visualizar
            Dim LogBE As New LogBusinessLogic()
            LogBE.ActualizarLog(Log)

            If (ext = ".xls" Or ext = ".xlsx") Then

                Dim Data As Byte() = New Byte(files.ContentLength - 1) {}
                files.InputStream.Read(Data, Constantes.ValorCero, files.ContentLength)

                Dim Name As [String] = files.FileName
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
                Session("Archivo") = FileName
                Dim stream As FileStream = System.IO.File.Open(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                If ext = ".xls" Then
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream, True)
                ElseIf ext = ".xlsx" Then
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream)
                End If
                'excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream)
                excelReader.IsFirstRowAsColumnNames = True
                'excelReader.AsDataSet(True)

                Dim i, j As Int32
                objDataSet = excelReader.AsDataSet(True)
                oViewModel.ListaProcesoCargaE = New ListaEmpleado
                oViewModel.ListaProcesoCargaEmpleados = New List(Of Empleado)
                oViewModel.ListaProcesoCargaEmpleadostOTALES = New List(Of Empleado)
                oViewModel.ListarProcesoCargaEErrores = New ListaEmpleado
                Try


                    'oViewModel.ListarCodigoOfisis = New String 
                    Prueba = objDataSet.Tables("Empleados")
                    If IdOperacion = 0 Then
                        dt = BorrarFilasVaciasCargaMasiva(objDataSet.Tables("Empleados"))
                    Else
                        dt = objDataSet.Tables("Empleados")
                    End If

                    If dt.Columns.Count = 17 Then



                        If dt.Rows.Count > 0 Then

                            If IdOperacion = 0 Then
                                For i = 0 To dt.Rows.Count - 1

                                    Dim Nombre As Boolean = True
                                    Dim Apellido As Boolean = True
                                    Dim DNI As Boolean = True
                                    Dim CodigoOfis As Boolean = True
                                    Dim usuario As Boolean = True
                                    Dim perfil As Boolean = True
                                    Dim Zonas As Boolean = True
                                    Dim sucursal As Boolean = True
                                    Dim escala As Boolean = True
                                    Dim fecha_contrato As Boolean = True
                                    Dim Fecha_Nacim As Boolean = True
                                    Dim fecha_Ingreso As Boolean = True

                                    oViewModel.Empleado = New Empleado

                                    oViewModel.Empleado.EmpleadoPerfil = New EmpleadoPerfil
                                    oViewModel.Empleado.Sucursal = New Sucursal
                                    oViewModel.Empleado.Zona = New Zona

                                    If dt.Rows(i)(0).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "NOMBRES"

                                    Else
                                        oViewModel.Empleado.Nombres = dt.Rows(i)(0).ToString.Trim()
                                        Nombre = False
                                    End If

                                    If dt.Rows(i)(1).ToString = "" Then

                                        oViewModel.Empleado.DescError += " , " + "APELLIDOS"

                                    Else

                                        oViewModel.Empleado.Apellidos = dt.Rows(i)(1).ToString.Trim()
                                        Apellido = False
                                    End If


                                    If dt.Rows(i)(2).ToString() = "" Then
                                        oViewModel.Empleado.DescError += " , " + "DNI"
                                        DNI = False
                                    Else
                                        Dim isnumeric As Boolean = True
                                        isnumeric = ValidarNumero(dt.Rows(i)(2).ToString.Trim())
                                        If isnumeric Then
                                            oViewModel.Empleado.DNI = dt.Rows(i)(2).ToString.Trim()
                                            DNI = False
                                            If Len(oViewModel.Empleado.DNI) = 8 Then

                                            Else


                                                oViewModel.Empleado.DescError += " , " + "DNI"

                                                oViewModel.Empleado.CodigoOfisis = dt.Rows(i)(3).ToString
                                                DNI = True
                                            End If
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "DNI"

                                            oViewModel.Empleado.CodigoOfisis = dt.Rows(i)(3).ToString.Trim()
                                            DNI = True
                                        End If




                                    End If
                                    If dt.Rows(i)(3).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "CODIGO OFISIS"
                                        oViewModel.Empleado.CodigoOfisis = "NO EXISTE"

                                    Else
                                        oViewModel.Empleado.CodigoOfisis = dt.Rows(i)(3).ToString.Trim()

                                        CodigoOfis = False
                                    End If
                                    If dt.Rows(i)(4).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "FECHA CONTRATO"

                                    Else
                                        Dim isdate As Boolean = True
                                        isdate = ValidarFecha(dt.Rows(i)(4))
                                        If isdate Then
                                            oViewModel.Empleado.FechaContrato = dt.Rows(i)(4).ToString.Trim()
                                            fecha_contrato = False
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "FECHA CONTRATO"
                                        End If


                                    End If

                                    If dt.Rows(i)(5).ToString = "" Then

                                        oViewModel.Empleado.DescError += " , " + "FECHA NACIMIENTO"
                                    Else
                                        Dim isdate As Boolean = True
                                        isdate = ValidarFecha(dt.Rows(i)(5))
                                        If isdate Then
                                            oViewModel.Empleado.FechaNacimiento = dt.Rows(i)(5).ToString.Trim()
                                            Fecha_Nacim = False
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "FECHA NACIMIENTO"
                                        End If


                                    End If

                                    If dt.Rows(i)(6).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "USUARIO"

                                    Else
                                        oViewModel.Empleado.UsuarioIngreso = dt.Rows(i)(6).ToString.Trim()
                                        usuario = False
                                    End If

                                    oViewModel.Empleado.Celular1 = dt.Rows(i)(7).ToString
                                    oViewModel.Empleado.Celular2 = dt.Rows(i)(8).ToString
                                    oViewModel.Empleado.Telefono = dt.Rows(i)(9).ToString
                                    oViewModel.Empleado.Email = dt.Rows(i)(10).ToString
                                    oViewModel.Empleado.Direccion = dt.Rows(i)(11).ToString

                                    If dt.Rows(i)(12).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "PERFIL"

                                    Else
                                        oViewModel.Empleado.EmpleadoPerfil.DescripcionPerfil = dt.Rows(i)(12).ToString.Trim()
                                        perfil = False
                                        Dim perfilE As String = oViewModel.Empleado.EmpleadoPerfil.DescripcionPerfil
                                        Dim perfiles As String = oProcesooBusinessLogic.ListarPerfil_Empleado(perfilE)
                                        If perfiles <> "" Then
                                            oViewModel.Empleado.EmpleadoPerfil.IdPerfil = perfiles
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "PERFIL"

                                        End If


                                    End If

                                    If dt.Rows(i)(13).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "ZONA"

                                    Else
                                        oViewModel.Empleado.Zona.Descripcion = dt.Rows(i)(13).ToString.Trim()
                                        Zonas = False
                                        Dim Zona As String = oViewModel.Empleado.Zona.Descripcion
                                        Dim oZona As String = oProcesooBusinessLogic.ListarZona_Sucursal(Zona)
                                        If oZona.ToString <> "" Then
                                            oViewModel.Empleado.Zona.IdZona = oZona
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "ZONA"
                                            Zonas = True
                                        End If


                                    End If

                                    If dt.Rows(i)(14).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "SUCURSAL"

                                    Else
                                        oViewModel.Empleado.Sucursal.DescripcionSucursal = dt.Rows(i)(14).ToString.Trim()
                                        sucursal = False
                                        Dim SucursalE As String = oViewModel.Empleado.Sucursal.DescripcionSucursal.ToUpper.ToLower

                                        Dim idSocursal As String = oProcesooBusinessLogic.ListarSucursal_Empleado(SucursalE)
                                        If idSocursal <> "" Then
                                            oViewModel.Empleado.Sucursal.IdSucursal = idSocursal.ToString
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "SUCURSAL"

                                        End If

                                    End If

                                    If dt.Rows(i)(15).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "ESCALA TIEMPO INICIAL"

                                    Else
                                        Dim isnumeric As Boolean = True
                                        isnumeric = ValidarNumero(dt.Rows(i)(15))
                                        If isnumeric Then
                                            oViewModel.Empleado.EscalaTiempoInicial = dt.Rows(i)(15).ToString.Trim()
                                            escala = False
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "ESCALA TIEMPO INICIAL"
                                        End If


                                    End If
                                    If dt.Rows(i)(16).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "FECHA INGRESO"

                                    Else

                                        Dim isdate As Boolean = True
                                        isdate = ValidarFecha(dt.Rows(i)(16))
                                        If isdate Then
                                            oViewModel.Empleado.FechaDesde = dt.Rows(i)(16).ToString.Trim()
                                            fecha_Ingreso = False
                                        Else
                                            oViewModel.Empleado.DescError += " , " + "FECHA INGRESO"
                                        End If


                                    End If

                                    Dim ruc As Object = dt.Rows(i)(2)
                                    Dim duplicados As Integer = 0
                                    duplicados = (From rucs In dt.Rows Where rucs(2).ToString().Trim() = ruc.ToString().Trim() Select rucs(2)).Count()

                                    If Nombre = False And Apellido = False And DNI = False And CodigoOfis = False And fecha_contrato = False And Fecha_Nacim = False And usuario = False And Zonas = False And perfil = False And sucursal = False And escala = False And fecha_Ingreso = False And duplicados <= 1 Then
                                        oViewModel.ListaProcesoCargaE.Add(oViewModel.Empleado)
                                        oViewModel.ListaProcesoCargaEmpleados.Add(oViewModel.Empleado)
                                        oViewModel.ListaProcesoCargaEmpleadostOTALES.Add(oViewModel.Empleado)
                                    Else
                                        If Nombre = True And Apellido = True And DNI = True And CodigoOfis = True And fecha_contrato = True And Fecha_Nacim = True And usuario = True And Zonas = True And perfil = True And sucursal = True And escala = True And fecha_Ingreso = True Then

                                        Else
                                            If duplicados > 1 Then
                                                oViewModel.Empleado.DescError = " DNI, está duplicado."
                                            Else
                                                If Not oViewModel.Empleado.DescError Is Nothing Then
                                                    oViewModel.Empleado.DescError = Mid(oViewModel.Empleado.DescError, 4)
                                                End If
                                            End If
                                            oViewModel.ListarProcesoCargaEErrores.Add(oViewModel.Empleado)

                                        End If



                                    End If

                                Next

                            Else
                                For i = 0 To dt.Rows.Count - 1

                                    Dim Nombre As Boolean = True
                                    Dim Apellido As Boolean = True
                                    Dim DNI As Boolean = True
                                    Dim CodigoOfis As Boolean = True
                                    Dim usuario As Boolean = True
                                    Dim perfil As Boolean = True
                                    Dim Zonas As Boolean = True
                                    Dim sucursal As Boolean = True
                                    Dim escala As Boolean = True
                                    Dim fecha_contrato As Boolean = True
                                    Dim Fecha_Nacim As Boolean = True
                                    Dim fecha_Ingreso As Boolean = True
                                    Dim Celular1 As Boolean = True
                                    Dim Celular2 As Boolean = True
                                    Dim Telefono As Boolean = True
                                    Dim Email As Boolean = True
                                    Dim Direccion As Boolean = True


                                    oViewModel.Empleado = New Empleado

                                    oViewModel.Empleado.EmpleadoPerfil = New EmpleadoPerfil
                                    oViewModel.Empleado.Sucursal = New Sucursal
                                    oViewModel.Empleado.Zona = New Zona

                                    If dt.Rows(i)(0).ToString = "" Then

                                    Else
                                        oViewModel.Empleado.Nombres = dt.Rows(i)(0).ToString
                                        Nombre = False
                                    End If

                                    If dt.Rows(i)(1).ToString = "" Then


                                    Else

                                        oViewModel.Empleado.Apellidos = dt.Rows(i)(1).ToString
                                        Apellido = False
                                    End If


                                    If dt.Rows(i)(2).ToString = "" Then


                                    Else
                                        oViewModel.Empleado.DNI = dt.Rows(i)(2).ToString
                                        DNI = False
                                        If Len(oViewModel.Empleado.DNI) = 8 Then
                                            DNI = False
                                        Else
                                            oViewModel.Empleado.DNI += " , " + "DNI"
                                            DNI = True
                                            oViewModel.Empleado.CodigoOfisis = dt.Rows(i)(3).ToString
                                        End If


                                    End If
                                    If dt.Rows(i)(3).ToString = "" Then
                                        oViewModel.Empleado.DescError += " , " + "CODIGO OFISIS"
                                        oViewModel.Empleado.CodigoOfisis = "NO EXISTE"

                                    Else
                                        oViewModel.Empleado.CodigoOfisis = dt.Rows(i)(3).ToString

                                        CodigoOfis = False
                                    End If
                                    If dt.Rows(i)(4).ToString = "" Then


                                    Else
                                        oViewModel.Empleado.FechaContrato = dt.Rows(i)(4).ToString
                                        fecha_contrato = False
                                    End If

                                    If dt.Rows(i)(5).ToString = "" Then


                                    Else
                                        oViewModel.Empleado.FechaNacimiento = dt.Rows(i)(5).ToString
                                        Fecha_Nacim = False
                                    End If

                                    If dt.Rows(i)(6).ToString = "" Then


                                    Else
                                        oViewModel.Empleado.UsuarioIngreso = dt.Rows(i)(6).ToString
                                        usuario = False
                                    End If


                                    If dt.Rows(i)(7).ToString = "" Then

                                    Else
                                        oViewModel.Empleado.Celular1 = dt.Rows(i)(7).ToString
                                        Celular1 = False
                                    End If


                                    If dt.Rows(i)(8).ToString = "" Then

                                    Else
                                        oViewModel.Empleado.Celular2 = dt.Rows(i)(8).ToString
                                        Celular2 = False
                                    End If
                                    If dt.Rows(i)(9).ToString = "" Then

                                    Else
                                        oViewModel.Empleado.Telefono = dt.Rows(i)(9).ToString
                                        Telefono = False
                                    End If

                                    If dt.Rows(i)(10).ToString = "" Then

                                    Else
                                        oViewModel.Empleado.Email = dt.Rows(i)(10).ToString
                                        Email = False
                                    End If

                                    If dt.Rows(i)(11).ToString = "" Then

                                    Else
                                        oViewModel.Empleado.Direccion = dt.Rows(i)(11).ToString
                                        Direccion = False
                                    End If


                                    If dt.Rows(i)(12).ToString = "" Then


                                    Else
                                        oViewModel.Empleado.Zona.Descripcion = dt.Rows(i)(12)
                                        Zonas = False



                                    End If

                                    If dt.Rows(i)(13).ToString = "" Then


                                    Else
                                        oViewModel.Empleado.EmpleadoPerfil.DescripcionPerfil = dt.Rows(i)(13)
                                        perfil = False


                                    End If

                                    If dt.Rows(i)(14).ToString = "" Then


                                    Else
                                        oViewModel.Empleado.Sucursal.DescripcionSucursal = dt.Rows(i)(14).ToString
                                        sucursal = False

                                        'End If
                                        'If dt.Rows(i)(3).ToString = "" Then
                                        '    oViewModel.Empleado.DescError += " , " + "CODIGO OFISIS"
                                        '    oViewModel.Empleado.CodigoOfisis = "NO EXISTE"

                                        'Else
                                        '    oViewModel.Empleado.CodigoOfisis = dt.Rows(i)(3).ToString

                                        '    CodigoOfis = False
                                        'End If
                                        'If dt.Rows(i)(4).ToString = "" Then
                                        '    If dt.Rows(i)(15).ToString = "" Then


                                        '    Else
                                        '        oViewModel.Empleado.FechaContrato = dt.Rows(i)(4).ToString
                                        '        fecha_contrato = False
                                        '    End If

                                        '    If dt.Rows(i)(5).ToString = "" Then


                                        '    Else
                                        '        oViewModel.Empleado.FechaNacimiento = dt.Rows(i)(5).ToString
                                        '        Fecha_Nacim = False
                                        '    End If

                                        '    If dt.Rows(i)(6).ToString = "" Then


                                        '    Else
                                        '        oViewModel.Empleado.UsuarioIngreso = dt.Rows(i)(6).ToString
                                        '        usuario = False
                                        '    End If


                                        '    If dt.Rows(i)(7).ToString = "" Then

                                        '    Else
                                        '        oViewModel.Empleado.Celular1 = dt.Rows(i)(7).ToString
                                        '        Celular1 = False
                                        '    End If


                                        '    If dt.Rows(i)(8).ToString = "" Then

                                        '    Else
                                        '        oViewModel.Empleado.Celular2 = dt.Rows(i)(8).ToString
                                        '        Celular2 = False
                                        '    End If
                                        '    If dt.Rows(i)(9).ToString = "" Then

                                        '    Else
                                        '        oViewModel.Empleado.Telefono = dt.Rows(i)(9).ToString
                                        '        Telefono = False
                                        '    End If

                                        '    If dt.Rows(i)(10).ToString = "" Then

                                        '    Else
                                        '        oViewModel.Empleado.Email = dt.Rows(i)(10).ToString
                                        '        Email = False
                                        '    End If

                                        '    If dt.Rows(i)(11).ToString = "" Then

                                        '    Else
                                        '        oViewModel.Empleado.Direccion = dt.Rows(i)(11).ToString
                                        '        Direccion = False
                                        '    End If


                                        '    If dt.Rows(i)(12).ToString = "" Then


                                        '    Else
                                        '        oViewModel.Empleado.Zona.Descripcion = dt.Rows(i)(12)
                                        '        Zonas = False



                                        '    End If

                                        '    If dt.Rows(i)(13).ToString = "" Then


                                        '                Else
                                        '                    oViewModel.Empleado.EmpleadoPerfil.DescripcionPerfil = dt.Rows(i)(13)
                                        '                    perfil = False


                                        '                End If

                                        '                If dt.Rows(i)(14).ToString = "" Then


                                        '                Else
                                        '                    oViewModel.Empleado.Sucursal.DescripcionSucursal = dt.Rows(i)(14).ToString
                                        '                    sucursal = False


                                    End If

                                    If dt.Rows(i)(15).ToString = "" Then

                                    Else
                                        oViewModel.Empleado.EscalaTiempoInicial = dt.Rows(i)(15).ToString
                                        escala = False
                                    End If
                                    If dt.Rows(i)(16).ToString = "" Then



                                    Else
                                        oViewModel.Empleado.FechaDesde = dt.Rows(i)(16).ToString
                                        fecha_Ingreso = False
                                    End If

                                    'If Nombre = False And Apellido = False And DNI = False And fecha_contrato = False And Fecha_Nacim = False And Usuario = False And Celular1 = False And Celular2 = False And Email = False And Direccion = False And perfil = False And Zonas = False And sucursal = False And escala = False And fecha_Ingreso = False And CodigoOfis = False And duplicados <= 1 Then

                                    'End If
                                    'If CodigoOfis = False Then

                                    '    oViewModel.ListaProcesoCargaE.Add(oViewModel.Empleado)
                                    '    oViewModel.ListaProcesoCargaEmpleados.Add(oViewModel.Empleado)
                                    '    oViewModel.ListaProcesoCargaEmpleadostOTALES.Add(oViewModel.Empleado)
                                    '        End If

                                    Dim ruc As Object = dt.Rows(i)(2)
                                    Dim duplicados As Integer = 0
                                    duplicados = (From rucs In dt.Rows Where rucs(2).ToString().Trim() = ruc.ToString().Trim() Select rucs(2)).Count()

                                    If Nombre = False And Apellido = False And DNI = False And fecha_contrato = False And Fecha_Nacim = False And usuario = False And Celular1 = False And Celular2 = False And Email = False And Direccion = False And perfil = False And Zonas = False And sucursal = False And escala = False And fecha_Ingreso = False And CodigoOfis = False And duplicados <= 1 Then
                                        If CodigoOfis = False Then

                                            oViewModel.ListaProcesoCargaE.Add(oViewModel.Empleado)
                                            oViewModel.ListaProcesoCargaEmpleados.Add(oViewModel.Empleado)
                                            oViewModel.ListaProcesoCargaEmpleadostOTALES.Add(oViewModel.Empleado)
                                        End If

                                    Else
                                        If Nombre = True And Apellido = True And DNI = True And fecha_contrato = True And Fecha_Nacim = True And usuario = True And Celular1 = True And Celular2 = True And Email = True And Direccion = True And Zonas = True And perfil = True And sucursal = True And escala = True And fecha_Ingreso = True And CodigoOfis = True Then

                                        Else
                                            If CodigoOfis = False Then
                                                oViewModel.ListaProcesoCargaE.Add(oViewModel.Empleado)
                                                oViewModel.ListaProcesoCargaEmpleados.Add(oViewModel.Empleado)
                                                oViewModel.ListaProcesoCargaEmpleadostOTALES.Add(oViewModel.Empleado)
                                            Else
                                                If duplicados > 1 Then
                                                    oViewModel.Empleado.DescError = " DNI, está duplicado."
                                                End If
                                                oViewModel.ListarProcesoCargaEErrores.Add(oViewModel.Empleado)
                                            End If
                                        End If

                                    End If

                                Next


                            End If


                            oViewModel.RegistroPorPagina = Constantes.ValorDiez
                            oViewModel.grabar = If(grabar.Equals(String.Empty), "SI", grabar)
                            'oViewModel.ListaOperacion = Constantes.ValorDiez


                            'lstCliente = If(Not tmp.ListaClienteTotal Is Nothing, tmp.ListaClienteTotal.ToList(), New List(Of CargaMasivaCliente))

                            'tmp.PaginacionCliente.RowsPerPage = Constantes.ValorDiez
                            'tmp.PaginacionCliente.TotalRows = If(Not tmp.ListaCliente Is Nothing, tmp.ListaCliente.Count(), 0)

                            'tmp.ListaCliente = lstCliente.Skip((page - 1) * 10).Take(10).ToList()

                            'tmp.PaginacionCliente.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmp.PaginacionCliente.TotalRows)



                        Else
                            message = "El fichero Excel no contiene datos."
                            grabar = "NO"
                        End If
                    Else
                        oViewModel.Empleado = New Empleado
                        oViewModel.Empleado.DescError = ""
                        oViewModel.ListarProcesoCargaEErrores.Add(oViewModel.Empleado)
                    End If
                Catch ex As Exception
                    oViewModel.Empleado = New Empleado
                    oViewModel.Empleado.DescError = ""
                    oViewModel.ListarProcesoCargaEErrores.Add(oViewModel.Empleado)
                End Try
            Else
                message = "No es la extensión correcta."
                grabar = "NO"
            End If
            Session("ListaGuardar") = oViewModel

            Return RedirectToAction("AdjuntarDataEmpleadoCompleted", "Proceso", New With {.page = page})
            'AsyncManager.Parameters("oViewModelProceso") = oViewModel

        End Function

        Function AdjuntarDataEmpleadoCompleted(Optional ByVal page As Integer = 1) As ActionResult

            Dim lstlista As New List(Of Empleado)

            tm2 = Session("ListaGuardar")
            lstlista = If(Not tm2.ListaProcesoCargaEmpleadostOTALES Is Nothing, tm2.ListaProcesoCargaEmpleadostOTALES.ToList(), New List(Of Empleado))
            tm2.PaginacionEmpleado.RowsPerPage = Constantes.ValorDiez

            tm2.PaginacionEmpleado.TotalRows = If(Not tm2.ListaProcesoCargaEmpleados Is Nothing, tm2.ListaProcesoCargaEmpleados.Count(), 0)
            tm2.ListaProcesoCargaEmpleados = lstlista.Skip((page - 1) * 10).Take(10).ToList()
            tm2.PaginacionEmpleado.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tm2.PaginacionEmpleado.TotalRows)



            Return View("CargarMasivaEmpleado", tm2)


        End Function

        Function GrillaImportarEmpleado(Optional ByVal page As Integer = Constantes.ValorUno)
            Dim lstlista As New List(Of Empleado)

            tm2 = Session("ListaGuardar")
            lstlista = tm2.ListaProcesoCargaEmpleadostOTALES.ToList()
            tm2.ListaProcesoCargaEmpleados = lstlista.Skip((page - 1) * 10).Take(10).ToList()
            tm2.PaginacionEmpleado.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tm2.PaginacionEmpleado.TotalRows)
            Return PartialView("PV_GrillaEmpleado", tm2)
        End Function


        Function Guardar(ByVal Operacion As Integer) As ActionResult
            Dim message As String = Constantes.Clear
            Dim Log As Log = Session("Log")
            Dim oViewModel As New ProcesoViewModel
            oViewModel.ListaProcesoCargaE = New ListaEmpleado
            oViewModel.Empleado = New Empleado
            oViewModel.Empleado.EmpleadoPerfil = New EmpleadoPerfil
            oViewModel.Empleado.Sucursal = New Sucursal
            oViewModel.Empleado.Zona = New Zona
            'oViewModel.ListaParametros = New ProcesoBusinessLogic().ListaParametrosCargaManual()
            tm2 = Session("ListaGuardar")
            Dim oProceso As New ProcesoBusinessLogic
            If Operacion = 0 Then
                If Session("Operacion") = Operacion Then
                    For Each el As Empleado In tm2.ListaProcesoCargaE
                        'el.TipoCarga = IdTipoCarga
                        oViewModel.Empleado.Nombres = el.Nombres

                        oViewModel.Empleado.Apellidos = el.Apellidos
                        oViewModel.Empleado.DNI = el.DNI
                        oViewModel.Empleado.CodigoOfisis = el.CodigoOfisis
                        oViewModel.Empleado.FechaContrato = el.FechaContrato
                        oViewModel.Empleado.FechaNacimiento = el.FechaNacimiento
                        oViewModel.Empleado.UsuarioIngreso = el.UsuarioIngreso
                        oViewModel.Empleado.Celular1 = el.Celular1
                        oViewModel.Empleado.Celular2 = el.Celular2
                        oViewModel.Empleado.Telefono = el.Telefono
                        oViewModel.Empleado.Email = el.Email
                        oViewModel.Empleado.EmpleadoPerfil.IdPerfil = el.EmpleadoPerfil.IdPerfil
                        oViewModel.Empleado.Zona.IdZona = el.Zona.IdZona
                        oViewModel.Empleado.Sucursal.IdSucursal = el.Sucursal.IdSucursal
                        oViewModel.Empleado.UsuarioRegistro = Session("UsuarioUsu").ToString()
                        oViewModel.Empleado.OrigenRegistro = "Carga Masiva"


                        oViewModel.Empleado.EscalaTiempoInicial = el.EscalaTiempoInicial
                        oViewModel.Empleado.FechaDesde = el.FechaDesde

                        oProceso.ImportarEmpleadoMasivo(oViewModel.Empleado)
                    Next
                    message = "Datos Actualizados / Agregados"
                    Return Json(message)
                Else
                    message = "El tipo de operacion es diferente al seleccionado"
                    Return Json(message)
                End If


            Else
                If Session("Operacion") = Operacion Then
                    For Each el As Empleado In tm2.ListaProcesoCargaE
                        oViewModel.Empleado.UsuarioRegistro = Session("UsuarioUsu").ToString()
                        oViewModel.Empleado.OrigenRegistro = "Carga Masiva"



                        oViewModel.Empleado.CodigoOfisis = el.CodigoOfisis

                        oProceso.EliminarEmpleadoMasivo(oViewModel.Empleado)
                    Next

                    message = "Datos Desactivados"
                    Return Json(message)
                Else
                    message = "El tipo de operacion es diferente al que se selecciono al hacer la carga"
                    Return Json(message)
                End If

            End If


        End Function

        Function Descargar() As ActionResult

            Dim archivo As String = Server.MapPath("~/CargaEmpleado/PlantillaCargaMasivaEmpleado_v2.0.xlsx")
            Dim fileByte As Byte() = System.IO.File.ReadAllBytes(archivo)
            Dim fileName As String = "PlantillaCargaMasivaEmpleado_v2.0.xlsx"
            Return File(fileByte, System.Net.Mime.MediaTypeNames.Application.Octet, fileName)

        End Function

#Region "Carga Masiva Cliente"
        Function CargaMasivaCarteraClientes() As ActionResult

            Dim oProcesoViewModel As New ProcesoViewModel()
            'Dim oProcesoBusinessLogic As New ProcesoBusinessLogic()
            'Dim oVentasBusinessLogic As New VentasBusinessLogic()

            'oProcesoViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()
            'oProcesoViewModel.ListaMeses = oProcesoBusinessLogic.ListarMes()

            Return View(oProcesoViewModel)
        End Function

        Function CargarClienteCartera(oProcesoViewModel As ProcesoViewModel, Optional ByVal page As Integer = 1) As ActionResult
            Dim oViewModel As New ProcesoViewModel
            Dim oProcesoBusinnessLogic As New ProcesoBusinessLogic
            oViewModel.PaginacionCartera = New Paginacion
            Dim message As String = Constantes.Clear
            Dim grabar As String = String.Empty
            Dim file As HttpPostedFileBase = Me.HttpContext.Request.Files.[Get]("file1")
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
                        dtC = BorrarFilasVaciasCargaMasivaCarteraCliente(dsC.Tables(NombreHoja))
                    Catch ex As Exception
                        dtC = New DataTable
                    End Try
                    '-----------------------------------------------------------------------

                    If (dtC.Rows.Count <> 0) Then
                        oViewModel.ClienteCartera = New ClienteCartera
                        oViewModel.DesAccion = If(oProcesoViewModel.ClienteCartera.Accion, "REGISTRA", "DESACTIVA")
                        oViewModel.DesAccionAnt = oViewModel.DesAccion
                        'Dim lst As ListaCargaMasivaCliente = oProcesoBusinnessLogic.ListaPrincipal()

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
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oProcesoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.RUC = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 1
                                                oViewModel.ClienteCartera.CodigoSucursal = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oProcesoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.CodigoSucursal = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 2
                                                oViewModel.ClienteCartera.CodigoOfisis = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oProcesoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.CodigoOfisis = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 3
                                                oViewModel.ClienteCartera.Fechainicio = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oProcesoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.Fechainicio = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 4
                                                oViewModel.ClienteCartera.FechaFin = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oProcesoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.FechaFin = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 5
                                                oViewModel.ClienteCartera.Mes = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oProcesoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.Mes = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
                                                End If

                                            Case 6
                                                oViewModel.ClienteCartera.Anio = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim)
                                                If (If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim) = Constantes.Clear And oProcesoViewModel.ClienteCartera.Accion.Equals(True)) Then
                                                    flag0 = False
                                                    'oViewModel.ClienteCartera.ProcesoCarga.DescError = " RAZÓN SOCIAL, "
                                                Else
                                                    oViewModel.ClienteCartera.Anio = If(Convert.IsDBNull(dtC.Rows(i)(j)), String.Empty, CStr(dtC.Rows(i)(j)).Trim).ToUpper()
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
            Return RedirectToAction("CargarCartera", "Proceso", New With {.page = page})

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
            tmpcc = Session("tmpCargaMasivaClienteCartera")

            lstCliente = If(Not tmpcc.ListaClienteCarteraTotal Is Nothing, tmpcc.ListaClienteCarteraTotal.ToList(), New List(Of ClienteCartera))

            tmpcc.PaginacionCartera.Page = Constantes.ValorUno
            tmpcc.PaginacionCartera.RowsPerPage = Constantes.ValorDiez
            tmpcc.PaginacionCartera.TotalRows = If(Not tmpcc.ListaClienteCartera Is Nothing, tmpcc.ListaClienteCartera.Count(), 0)

            tmpcc.ListaClienteCartera = lstCliente.Skip((page - 1) * 10).Take(10).ToList()
            tmpcc.PaginacionCartera.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmpcc.PaginacionCartera.TotalRows)
            Return View("CargaMasivaCarteraClientes", tmpcc)
        End Function

        Private Function BorrarFilasVaciasCargaMasivaCarteraCliente(ByVal dt As DataTable) As DataTable
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

        Function DescargarPlantillaCarteraCliente() As FileResult
            Dim nameFile = "PlantillaCargaMasivaClienteCartera.xlsx"
            Dim ruta = Server.MapPath("~/Files")
            Dim pathFile = Path.Combine(ruta, nameFile)
            Dim fil = System.IO.File.ReadAllBytes(pathFile)
            Return File(fil, System.Net.Mime.MediaTypeNames.Application.Octet, nameFile)

        End Function

        Function GuardarCarteraCliente(oProcesoViewModel As ProcesoViewModel) As ActionResult
            tmpcc = Session("tmpCargaMasivaClienteCartera")
            Dim Log As Log = Session("Log")
            Dim result = String.Empty
            If (oProcesoViewModel.ClienteCartera.Accion) Then
                result = New ProcesoBusinessLogic().RegistraClienteCartera(tmpcc.ListaClienteCarteraTotal, Log)
            Else
                'result = New ProcesoBusinessLogic().DesactivaCliente(tmp.ListaClienteTotal, tmp.ListaClienteEmpleadoTotal, Log)
            End If

            Return Content(result)
        End Function

        Function CargarCMClienteCartera(Optional ByVal page As Integer = Constantes.ValorUno)
            Dim lstClienteCartera As New List(Of ClienteCartera)
            tmpcc = Session("tmpCargaMasivaClienteCartera")
            lstClienteCartera = tmpcc.ListaClienteCarteraTotal.ToList()
            tmpcc.ListaClienteCartera = lstClienteCartera.Skip((page - 1) * 10).Take(10).ToList()
            tmpcc.PaginacionCartera.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(page, 10, tmpcc.PaginacionCartera.TotalRows)
            Return PartialView("PV_CargaMasivaCarteraClientes", tmpcc)
        End Function
#End Region

    End Class
End Namespace
