Imports System.Web
Imports System.Web.Mvc
Imports System.Web.UI.WebControls
Imports System.IO
Imports Sodimac.VentaEmpresa.Web.Mvc.ComisionViewModel
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports Sodimac.VentaEmpresa.Common
Imports System.Web.UI.Control
Imports System.IO.Path

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class ComisionController
        Inherits BaseController

        <RequiresAuthenticationAttribute()> _
        Function BuscarEscalaComision() As ActionResult
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oComisionViewModel As ComisionViewModel = New ComisionViewModel
            oComisionViewModel.ListaComisionPeriodo = oComisionBusinessLogic.ListaPeriodoCbo()

            Return View(oComisionViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()> _
        Function _BuscarEscalaComision(ByVal IdPeriodo As Integer) As ActionResult
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oComisionViewModel As ComisionViewModel = New ComisionViewModel
            oComisionViewModel.RegistroPorPagina = 10
            oComisionViewModel.TotalRegistros = 100
            oComisionViewModel.ListaComisionEscala = oComisionBusinessLogic.ListaComisionEscala_PorIdPeriodo(IdPeriodo)
            Return PartialView(oComisionViewModel)
        End Function

        <RequiresAuthenticationAttribute()> _
        <RequiresAuthorizationAttribute()> _
        Function BuscarPeriodoComision() As ActionResult
            Dim oComisionViewModel As New ComisionViewModel()
            Dim oComisionBusinessLogic As New ComisionBusinessLogic()
            oComisionViewModel.ListaNombrePeriodo = oComisionBusinessLogic.ListaNombrePeriodo()
            oComisionViewModel.Paginacion = New Paginacion()
            Return View(oComisionViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()> _
        Function _BuscarPeriodoComision(Optional ByVal IdPeriodo As Integer = Constantes.ValorCero,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPeriodo:" & IdPeriodo.ToString()
            Log.IdOrigenAccion = Constantes.Comision_Periodo
            Log.IdLogAccion = Constantes.Buscar
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)
            Dim oComisionViewModel As ComisionViewModel = New ComisionViewModel()

            oComisionViewModel.Paginacion = New Paginacion With {.PageNumber = page,
                                                                .PageSize = Constantes.RowsPerPage,
                                                                .SortBy = sort,
                                                                .SortType = sortDir,
                                                                .ComisionPeriodo = New ComisionPeriodo With {.IdPeriodo = IdPeriodo},
                                                                .ListaComisionPeriodo = New List(Of ComisionPeriodo)}

            oComisionViewModel.Paginacion = oComisionBusinessLogic.ObtenerPeriodo(oComisionViewModel.Paginacion)

            oComisionViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oComisionViewModel.Paginacion.PageNumber,
                oComisionViewModel.Paginacion.PageSize,
                oComisionViewModel.Paginacion.TotalRows
            )

            Return PartialView(oComisionViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()> _
        Function InsertarDatosPeriodoComision(ByVal oComisionViewModel As ComisionViewModel) As ActionResult
            Dim oComisionBusinessLogic As New ComisionBusinessLogic()
            Dim resultado As Integer
            Dim message As String
            resultado = oComisionBusinessLogic.InsertaDatosPeriodo(oComisionViewModel.ComisionPeriodo, 10)

            If resultado > 0 Then
                message = "Periodo registrado correctamente"
            Else
                message = "No se pudo realizar la operación"
            End If

            Return Content(resultado)
        End Function

        <RequiresAuthenticationAttribute()> _
        Function GestionarEscalaComision(Optional IdComisionEscala As Integer = 0) As ActionResult
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oComisionViewModel As ComisionViewModel = New ComisionViewModel

            oComisionViewModel.ListaEmpleadoPerfil = oComisionBusinessLogic.ListaPerfil()
            oComisionViewModel.ListaEmpleadoCargo = oComisionBusinessLogic.ListaCargo()
            oComisionViewModel.ListaTiempoServicio = oComisionBusinessLogic.ListaTiempoServicio(IdComisionEscala)

            oComisionViewModel.ComisionEscala = oComisionBusinessLogic.CabeceraComisionEscala(IdComisionEscala)
            oComisionViewModel.ListaComisionEscalaDetalle = oComisionBusinessLogic.ListaComisionEscalaDetalle(oComisionViewModel.ComisionEscala.IdComisionEscala)
            Return View(oComisionViewModel)
        End Function

        <RequiresAuthenticationAttribute()> _
        Function GestionarPeriodoComision(Optional IdPeriodo As Integer = 0, Optional ModificaEscala As Boolean = False) As ActionResult
            Dim VM As ComisionViewModel = New ComisionViewModel
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            VM.PlanVenta = New PlanVenta
            VM.PlanVenta.ComisionEscala = New ComisionEscala
            VM.PlanVenta.ComisionEscala.IdPeriodo = IdPeriodo
            VM.ModificaEscala = ModificaEscala

            If IdPeriodo = 0 Then
                VM.ComisionPeriodo = New ComisionPeriodo()
                VM.ListaComisionPeriodo = oComisionBusinessLogic.ListaPeriodoCbo()    'New ListaComisionPeriodo()
                VM.ListaComisionPeriodoDetalle = New ListaComisionPeriodoDetalle()
                VM.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_PERIODOCOMISONEMPLEADO)
                Dim dateini As String = "01/" & VM.Parametro.Valor1 & "/" & DateTime.Now.Year
                'oComisionViewModel.ComisionPeriodo.FechaInicio = DateTime.Parse(oComisionViewModel.Parametro.Valor1 & "/12/" & (DateTime.Now.Year - 1))
                'oComisionViewModel.ComisionPeriodo.FechaFin = DateTime.Parse(oComisionViewModel.Parametro.Valor2 & "/12/" & DateTime.Now.Year)

                VM.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_BONOSDEFECTO)
                VM.ComisionPeriodo.CantidadBono = Integer.Parse(VM.Parametro.Valor1)
                VM.ComisionPeriodo.BonoEspecial = True
                VM.ComisionPeriodo.PlanVentaSumatoria = True
            Else
                VM.ListaComisionPeriodo = New ListaComisionPeriodo
                VM.ComisionPeriodo = oComisionBusinessLogic.ObtenerPeriodoPorId(IdPeriodo)
                'oComisionViewModel.ListaComisionEscala = oComisionBusinessLogic.ListaComisionEscala_PorIdPeriodo(oComisionViewModel.ComisionPeriodo.IdPeriodo)
                'oComisionViewModel.ListaComisionPeriodoDetalle = oComisionBusinessLogic.ListaComisionPeriodoDetalle_PorIdPeriodo(oComisionViewModel.ComisionPeriodo.IdPeriodo)
            End If

            Return View(VM)
        End Function
        <RequiresAuthenticationAjaxAttribute()> _
        Function _GestionarPeriodoComisionBonosRRVV(Optional NumeroBonos As Integer = 0) As ActionResult
            Dim oComisionViewModel As New ComisionViewModel
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            If NumeroBonos = 0 Then
                oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_BONOSDEFECTO)
                NumeroBonos = Integer.Parse(oComisionViewModel.Parametro.Valor1)
            End If
            oComisionViewModel.PlanVenta = New PlanVenta
            oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleRRVV = New ListaComisionEscalaDetalle
            For i = 0 To NumeroBonos - 1
                Dim oComisionEscalaDetalle As New ComisionEscalaDetalle()
                oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleRRVV.Add(oComisionEscalaDetalle)
            Next
            Return PartialView(oComisionViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function _GestionarPeriodoComisionBonosJefatura(Optional NumeroBonos As Integer = 0, Optional IdPeriodo As Integer = 0, Optional IdCargoSuperior As Integer = 0) As ActionResult
            Dim oComisionViewModel As New ComisionViewModel
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic

            If NumeroBonos = 0 Then
                oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_BONOSDEFECTO)
                NumeroBonos = Integer.Parse(oComisionViewModel.Parametro.Valor1)
            End If
            oComisionViewModel.PlanVenta = New PlanVenta
            oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe = oComisionBusinessLogic.ListarComisionEscalaDetalleJefe(IdPeriodo, IdCargoSuperior)
            If (oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count = 0 Or oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count <> NumeroBonos) Then  'Aki genero la tabla de comisiones vacía
                oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe = New ListaComisionEscalaDetalle
                For i = 0 To NumeroBonos - 1
                    Dim oComisionEscalaDetalle As New ComisionEscalaDetalle()
                    oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Add(oComisionEscalaDetalle)
                Next
            End If
            Return PartialView(oComisionViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function ValidaEscalaComisionJefe(ByVal oComisionViewModel As ComisionViewModel) As ActionResult
            Dim NumeroEscala As Integer = 0
            Dim Resultado As Integer = -1
            Dim Valida As Boolean = True
            Dim MensajeResultado As String = ""

            Dim oComisionEscalaDetalle As New ComisionEscalaDetalle
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_MAXIMOFINALESCALA)

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1
                    oComisionEscalaDetalle = oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(i)
                    If (oComisionEscalaDetalle.PorcentajeInicial = 0) Then
                        Resultado = Constantes.ValorDos
                        Valida = False
                        Exit For
                    End If
                Next
            End If

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1
                    oComisionEscalaDetalle = oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(i)
                    If (oComisionEscalaDetalle.PorcentajeFinal = 0 And i <> oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1) Then
                        Resultado = Constantes.ValorTres
                        Valida = False
                        Exit For
                    End If
                Next
            End If

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1
                    oComisionEscalaDetalle = oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(i)
                    If (oComisionEscalaDetalle.Bono = 0) Then
                        Resultado = Constantes.ValorCuatro
                        Valida = False
                        Exit For
                    End If
                Next
            End If

            If Valida Then
                If oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1).PorcentajeFinal = 0 Then
                    oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1).PorcentajeFinal = Decimal.Parse(oComisionViewModel.Parametro.Valor1)
                End If
                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1
                    If oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(i).PorcentajeInicial >= oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(i).PorcentajeFinal Then
                        Resultado = Constantes.ValorCinco
                        NumeroEscala = i + 1
                        Valida = False
                        Exit For
                    End If
                    If i <> oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe.Count - 1 Then
                        If oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(i).PorcentajeFinal <> oComisionViewModel.PlanVenta.ListaComisionEscalaDetalleJefe(i + 1).PorcentajeInicial Then

                            Resultado = Constantes.ValorSeis
                            NumeroEscala = i + 1
                            Valida = False
                            Exit For
                        End If
                    End If
                Next
            End If

            Select Case Resultado
                Case Constantes.ValorDos
                    MensajeResultado = "Por favor ingrese los valores para los porcentajes iniciales del plan de ventas del jefe"
                Case Constantes.ValorTres
                    MensajeResultado = "Por favor ingrese los valores para los porcentajes finales del plan de ventas del jefe" &
                        ", puede dejar en cero o en blanco el último porcentaje final para indicar el máximo valor (" & oComisionViewModel.Parametro.Valor1 & ")"
                Case Constantes.ValorCuatro
                    MensajeResultado = "Por favor ingrese los valores para los bonos del plan de ventas del jefe."
                Case Constantes.ValorCinco
                    MensajeResultado = "El porcentaje inicial no debe ser mayor o igual al porcentaje final para la fila " & NumeroEscala & " del plan de ventas del jefe."
                Case Constantes.ValorSeis
                    MensajeResultado = "El porcentaje inicial para la fila " & (NumeroEscala + 1) & " debe ser igual al porcentaje final de la fila " & NumeroEscala & " del plan de ventas del jefe."
            End Select

            MensajeResultado = Resultado & "/" & MensajeResultado
            Return Content(MensajeResultado)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function ValidaEscalaComisionRRVV(ByVal oComisionViewModel As ComisionViewModel) As ActionResult
            Dim NumeroEscala As Integer = 0
            Dim Resultado As Integer = -1
            Dim Valida As Boolean = True
            Dim MensajeResultado As String = ""
            Dim TiempoServicio As Integer = 0

            Dim oComisionEscalaDetalle As New ComisionEscalaDetalle
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_MAXIMOFINALESCALA)

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Count - 1
                    For j As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1
                        oComisionEscalaDetalle = oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(j)
                        If (oComisionEscalaDetalle.PorcentajeInicial = 0) Then
                            Resultado = Constantes.ValorDos
                            TiempoServicio = i
                            Valida = False
                            Exit For
                        End If
                    Next
                    If Valida = False Then
                        Exit For
                    End If
                Next
            End If

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Count - 1
                    For j As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1
                        oComisionEscalaDetalle = oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(j)
                        If (oComisionEscalaDetalle.PorcentajeFinal = 0 And j <> oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1) Then
                            Resultado = Constantes.ValorTres
                            TiempoServicio = i
                            Valida = False
                            Exit For
                        End If
                    Next
                    If Valida = False Then
                        Exit For
                    End If
                Next
            End If

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Count - 1
                    For j As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1
                        oComisionEscalaDetalle = oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(j)
                        If (oComisionEscalaDetalle.Bono = 0) Then
                            Resultado = Constantes.ValorCuatro
                            TiempoServicio = i
                            Valida = False
                            Exit For
                        End If
                    Next
                    If Valida = False Then
                        Exit For
                    End If
                Next
            End If

            If Valida Then

                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Count - 1
                    'For j As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1
                    If oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1).PorcentajeFinal = 0 Then
                        oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1).PorcentajeFinal = Decimal.Parse(oComisionViewModel.Parametro.Valor1)
                    End If
                    'Next
                Next

                For i As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Count - 1
                    For j As Integer = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1
                        If oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(j).PorcentajeInicial >= oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(j).PorcentajeFinal Then
                            Resultado = Constantes.ValorCinco
                            TiempoServicio = i
                            NumeroEscala = j + 1
                            Valida = False
                            Exit For
                        End If
                        If j <> oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV.Count - 1 And Valida Then
                            If oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(j).PorcentajeFinal <> oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV(j + 1).PorcentajeInicial Then
                                Resultado = Constantes.ValorSeis
                                TiempoServicio = i
                                NumeroEscala = j + 1
                                Valida = False
                                Exit For
                            End If
                        End If
                    Next
                    If Valida = False Then
                        Exit For
                    End If
                Next
            End If

            Select Case Resultado
                Case Constantes.ValorDos
                    MensajeResultado = "Por favor ingrese los valores para los porcentajes iniciales del plan de ventas del RRVV del tiempo de servicio " & TiempoServicio & "."
                Case Constantes.ValorTres
                    MensajeResultado = "Por favor ingrese los valores para los porcentajes finales del plan de ventas del RRVV del tiempo de servicio" & TiempoServicio &
                        ", puede dejar en cero o en blanco el último porcentaje final para indicar el máximo valor (" & oComisionViewModel.Parametro.Valor1 & ")."
                Case Constantes.ValorCuatro
                    MensajeResultado = "Por favor ingrese los valores para los bonos del plan de ventas del RRVV del tiempo de servicio" & TiempoServicio & "."
                Case Constantes.ValorCinco
                    MensajeResultado = "El porcentaje inicial no debe ser mayor o igual al porcentaje final para la fila " & NumeroEscala & " del plan de ventas del RRVV del tiempo de servicio" & TiempoServicio & "."
                Case Constantes.ValorSeis
                    MensajeResultado = "El porcentaje inicial para la fila " & (NumeroEscala + 1) & " debe ser igual al porcentaje final de la fila " & NumeroEscala & " del plan de ventas del RRVV  del tiempo de servicio" & TiempoServicio & "."
            End Select

            MensajeResultado = Resultado & "/" & MensajeResultado
            Return Content(MensajeResultado)
        End Function
        <RequiresAuthenticationAjaxAttribute()> _
        <ValidateAntiForgeryToken()> _
        Function GuardarPeriodoComision(oComisionViewModel As ComisionViewModel) As ActionResult
            Dim Resultado As Integer = -1
            Dim Valida As Boolean = True
            Dim MensajeResultado As String = ""
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            oComisionViewModel.ComisionPeriodo.Estado = New Estado()
            oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_MAXIMOFINALESCALA)

            Dim IdPeriodo_ As Integer
            Resultado = oComisionBusinessLogic.InsertarPeriodoComision(oComisionViewModel.ComisionPeriodo, IdPeriodo_)
            Select Case Resultado
                Case Constantes.MenosUno
                    MensajeResultado = Constantes.msjGrabarError
                Case Constantes.ValorUno
                    MensajeResultado = "Se grabó correctamente con estado REGISTRADO."
                Case Constantes.ValorDos
                    MensajeResultado = "Se grabó correctamente con estado REGISTRADO."
                Case Constantes.ValorTres
                    MensajeResultado = "Ya existe un periodo con el nombre " & oComisionViewModel.ComisionPeriodo.NombrePeriodo.ToUpper()
                Case Constantes.ValorCuatro
                    MensajeResultado = "No se pudo crear el periodo, porque aún no hay cargos de tipo Jefatura."
            End Select

            MensajeResultado = Resultado & "/" & MensajeResultado & "/" & IdPeriodo_
            Return Content(MensajeResultado)
        End Function

        <RequiresAuthenticationAjaxAttribute()> _
        <ValidateAntiForgeryToken()> _
        Function ValidarGuardarEscalaComision(ByVal oComisionViewModel As ComisionViewModel) As ActionResult
            Dim Resultado As Integer = -1
            Dim Valida As Boolean = True
            Dim MensajeResultado As String = ""
            Dim NumeroEscala As Integer = 0
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            Dim oComisionEscalaDetalle As New ComisionEscalaDetalle
            oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_MAXIMOFINALESCALA)

            For i As Integer = 0 To oComisionViewModel.ListaComisionEscalaDetalle.Count - 1
                oComisionEscalaDetalle = oComisionViewModel.ListaComisionEscalaDetalle(i)
                If (oComisionEscalaDetalle.PorcentajeInicial <= 0) Then
                    Resultado = Constantes.ValorDos
                    Valida = False
                    Exit For
                End If
            Next

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.ListaComisionEscalaDetalle.Count - 1
                    oComisionEscalaDetalle = oComisionViewModel.ListaComisionEscalaDetalle(i)
                    If (oComisionEscalaDetalle.PorcentajeFinal <= 0 And i <> oComisionViewModel.ListaComisionEscalaDetalle.Count - 1) Then
                        Resultado = Constantes.ValorTres
                        Valida = False
                        Exit For
                    End If
                Next
            End If

            If Valida Then
                For i As Integer = 0 To oComisionViewModel.ListaComisionEscalaDetalle.Count - 1
                    oComisionEscalaDetalle = oComisionViewModel.ListaComisionEscalaDetalle(i)
                    If (oComisionEscalaDetalle.Bono <= 0) Then
                        Resultado = Constantes.ValorCuatro
                        Valida = False
                        Exit For
                    End If
                Next
            End If

            If Valida Then
                If oComisionViewModel.ListaComisionEscalaDetalle(oComisionViewModel.ListaComisionEscalaDetalle.Count - 1).PorcentajeFinal = 0 Then
                    oComisionViewModel.ListaComisionEscalaDetalle(oComisionViewModel.ListaComisionEscalaDetalle.Count - 1).PorcentajeFinal = Decimal.Parse(oComisionViewModel.Parametro.Valor1)
                End If

                For i As Integer = 0 To oComisionViewModel.ListaComisionEscalaDetalle.Count - 1
                    If oComisionViewModel.ListaComisionEscalaDetalle(i).PorcentajeInicial >= oComisionViewModel.ListaComisionEscalaDetalle(i).PorcentajeFinal Then
                        Resultado = Constantes.ValorCinco
                        NumeroEscala = i + 1
                        Valida = False
                        Exit For
                    End If
                    If i <> oComisionViewModel.ListaComisionEscalaDetalle.Count - 1 Then
                        If oComisionViewModel.ListaComisionEscalaDetalle(i).PorcentajeFinal <> oComisionViewModel.ListaComisionEscalaDetalle(i + 1).PorcentajeInicial Then
                            Resultado = Constantes.ValorSeis
                            NumeroEscala = i + 1
                            Valida = False
                            Exit For
                        End If
                    End If
                Next
            End If

            Select Case Resultado
                Case Constantes.ValorDos
                    MensajeResultado = "Por favor ingrese valores positivos para los porcentajes iniciales de la escala"
                Case Constantes.ValorTres
                    MensajeResultado = "Por favor ingrese valores positivos para los porcentajes finales de la escala, " & _
                        "puede dejar en cero o en blanco el último porcentaje final para indicar el máximo valor (" & oComisionViewModel.Parametro.Valor1 & ")"
                Case Constantes.ValorCuatro
                    MensajeResultado = "Por favor ingrese valores positivos para los bonos de la escala"
                Case Constantes.ValorCinco
                    MensajeResultado = "El porcentaje inicial no debe ser mayor o igual al porcentaje final para la fila " & NumeroEscala
                Case Constantes.ValorSeis
                    MensajeResultado = "El porcentaje inicial para la fila " & (NumeroEscala + 1) & " debe ser igual al porcentaje final de la fila " & NumeroEscala
            End Select

            MensajeResultado = Resultado & "/" & MensajeResultado
            Return Content(MensajeResultado)
        End Function

        <RequiresAuthenticationAjaxAttribute()> _
        Function GuardarEscalaComision(ByVal oComisionViewModel As ComisionViewModel) As ActionResult
            Dim MensajeResultado As String = ""
            Dim Resultado As Integer = -1
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            For Each item As ComisionEscalaDetalle In oComisionViewModel.ListaComisionEscalaDetalle
                item.ComisionEscala = oComisionViewModel.ComisionEscala
            Next

            oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_MAXIMOFINALESCALA)
            If oComisionViewModel.ListaComisionEscalaDetalle(oComisionViewModel.ListaComisionEscalaDetalle.Count - 1).PorcentajeFinal = 0 Then
                oComisionViewModel.ListaComisionEscalaDetalle(oComisionViewModel.ListaComisionEscalaDetalle.Count - 1).PorcentajeFinal = Decimal.Parse(oComisionViewModel.Parametro.Valor1)
            End If

            Resultado = oComisionBusinessLogic.RegistrarEscalaComision(oComisionViewModel.ListaComisionEscalaDetalle)

            Select Case Resultado
                Case Constantes.ValorUno
                    MensajeResultado = Constantes.msjActualizar
                Case Constantes.MenosUno
                    MensajeResultado = Constantes.msjGrabarError
            End Select

            MensajeResultado = Resultado & "/" & MensajeResultado
            Return Content(MensajeResultado)
        End Function

        <RequiresAuthenticationAjaxAttribute()> _
        Function AprobarPeriodoComision(ByVal IdPeriodo As Integer) As ActionResult
            Dim MensajeResultado As String = ""
            Dim Resultado As Integer = -1
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPeriodo:" + IdPeriodo.ToString()
            Log.IdOrigenAccion = Constantes.Comision_Periodo
            Log.IdLogAccion = Constantes.Aprobar
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

            Resultado = oComisionBusinessLogic.AprobarPeriodoComision(IdPeriodo)

            Select Case Resultado
                Case Constantes.ValorUno
                    MensajeResultado = Constantes.msjAprobar
                Case Constantes.ValorDos
                    MensajeResultado = "Se necesita actualizar todas las escalas de comisión asociadas al periodo para que pueda ser aprobado"
                Case Constantes.ValorTres
                    MensajeResultado = "No se puede aprobar un periodo con una fecha menor a la actual o menor a la fecha de inicio del periodo actual"
                Case Constantes.ValorCuatro
                    MensajeResultado = "Debe completar los planes de venta por cada zona"
                Case Constantes.MenosUno
                    MensajeResultado = Constantes.msjGrabarError
            End Select

            MensajeResultado = Resultado & "/" & MensajeResultado
            Return Content(MensajeResultado)
        End Function
        <HttpPost()>
      <RequiresAuthenticationAjaxAttribute()> _
        Function _GestionarPeriodoComisionPlanVenta(Optional IdPeriodo As Integer = 0, Optional IdCargoSuperior As Integer = 0, Optional IdCargo As Integer = 0,
                                                    Optional Modifica As Boolean = False, Optional IdPerfil As Integer = 0, Optional IdPerfilSuperior As Integer = 0,
                                                    Optional NombreCargo As String = "", Optional NombreCargoSuperior As String = "") As ActionResult
            'Esto hará k se renderize los planes de venta del jefe y vendedor
            Dim oComisionViewModel As New ComisionViewModel
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic

            oComisionViewModel.PlanVenta = New PlanVenta()
            oComisionViewModel.PlanVenta.ComisionEscala = New ComisionEscala()
            oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo = New ComisionPeriodo()
            oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo.IdPeriodo = IdPeriodo

            oComisionViewModel.PlanVenta.ComisionEscalaRRVV = New ComisionEscala()
            oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo = New ComisionPeriodo()
            oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo.IdPeriodo = IdPeriodo

            oComisionViewModel.PlanVenta.Cargo = New Cargo
            oComisionViewModel.PlanVenta.Cargo.IdCargoSuperior = IdCargoSuperior
            oComisionViewModel.PlanVenta.Cargo.NombreCargoSuperior = NombreCargoSuperior
            oComisionViewModel.PlanVenta.Cargo.NombreCargo = NombreCargo
            oComisionViewModel.PlanVenta.Cargo.IdCargo = IdCargo
            oComisionViewModel.PlanVenta.Cargo.Perfil = New Perfil
            oComisionViewModel.PlanVenta.Cargo.Perfil.IdPerfil = IdPerfil

            oComisionViewModel.PlanVenta.Cargo.PerfilSuperior = New Perfil
            oComisionViewModel.PlanVenta.Cargo.PerfilSuperior.IdPerfil = IdPerfilSuperior

            oComisionViewModel.PlanVenta.ComisionEscala = oComisionBusinessLogic.ObtenerComisionEscala(IdPeriodo, IdCargoSuperior)
            If (oComisionViewModel.PlanVenta.ComisionEscala.CantidadEscalas = 0) Then
                oComisionViewModel.PlanVenta.ComisionEscala.CantidadEscalas = 4
            End If
            oComisionViewModel.PlanVenta.ComisionEscalaRRVV = oComisionBusinessLogic.ObtenerComisionEscala(IdPeriodo, IdCargo)
            If (oComisionViewModel.PlanVenta.ComisionEscalaRRVV.CantidadEscalas = 0) Then
                oComisionViewModel.PlanVenta.ComisionEscalaRRVV.CantidadEscalas = 4
                oComisionViewModel.PlanVenta.ComisionEscalaRRVV.TiempoServicio = 4
            End If
            'Lo siguiente es para setear el IdPeriodo a los 2 objetos del jefe y RVV los cuales estan almacenados en variables hidden
            oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo = New ComisionPeriodo()
            oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo.IdPeriodo = IdPeriodo
            oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo = New ComisionPeriodo()
            oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo.IdPeriodo = IdPeriodo

            If oComisionViewModel.PlanVenta.ComisionEscala.IdComisionEscala = 0 Then 'Verifica si ya tiene guardado la comision escala para el cargosuperior seleccionado
                oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_PERIODOCOMISONEMPLEADO)
                Dim dateini As String = "01/" & oComisionViewModel.Parametro.Valor1 & "/" & DateTime.Now.Year
                'oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaFactorFechaInicio = DateTime.Parse(oComisionViewModel.Parametro.Valor1 & "/12/" & (DateTime.Now.Year - 1))
                'oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaFactorFechaFin = DateTime.Parse(oComisionViewModel.Parametro.Valor2 & "/12/" & DateTime.Now.Year)

                oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_BONOSDEFECTO)
                oComisionViewModel.PlanVenta.ComisionEscala.CantidadEscalas = Integer.Parse(oComisionViewModel.Parametro.Valor1)
                oComisionViewModel.PlanVenta.ComisionEscalaRRVV.CantidadEscalas = Integer.Parse(oComisionViewModel.Parametro.Valor1)
                oComisionViewModel.PlanVenta.ComisionEscalaRRVV.TiempoServicio = Integer.Parse(oComisionViewModel.Parametro.Valor1)
                oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVV = True
                oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaFactorAplica = True

            End If


            'Solo Inicializa el modelo para el TAB Tiempo Servicio
            oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio = New ListaComisionEscalaTiempoServicio

            Return (PartialView(oComisionViewModel))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function _GestionarPeriodoComision(Optional IdPeriodo As Integer = 0, Optional Modifica As Boolean = False) As ActionResult
            Dim oComisionViewModel As ComisionViewModel = New ComisionViewModel
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic
            oComisionViewModel.PlanVenta = New PlanVenta()

            oComisionViewModel.ListaPlanVenta = oComisionBusinessLogic.ListarTabsJefes(IdPeriodo)

            oComisionViewModel.PlanVenta.ComisionEscala = New ComisionEscala()
            oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo = New ComisionPeriodo()
            oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo.IdPeriodo = IdPeriodo

            'oComisionViewModel.PlanVenta.ComisionEscalaRRVV = New ComisionEscala()
            'oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo = New ComisionPeriodo()
            'oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo.IdPeriodo = IdPeriodo

            'If Modifica = False Then
            '    oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_PERIODOCOMISONEMPLEADO)
            '    Dim dateini As String = "01/" & oComisionViewModel.Parametro.Valor1 & "/" & DateTime.Now.Year
            '    oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaFactorFechaInicio = DateTime.Parse(oComisionViewModel.Parametro.Valor1 & "/12/" & (DateTime.Now.Year - 1))
            '    oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaFactorFechaFin = DateTime.Parse(oComisionViewModel.Parametro.Valor2 & "/12/" & DateTime.Now.Year)

            '    oComisionViewModel.Parametro = oConfiguracionBusinessLogic.ObtenerParametroPorCodigoParametro(DataAccess.Constantes.PARAMETRO_BONOSDEFECTO)
            '    oComisionViewModel.PlanVenta.ComisionEscala.CantidadEscalas = Integer.Parse(oComisionViewModel.Parametro.Valor1)
            '    oComisionViewModel.PlanVenta.ComisionEscalaRRVV.CantidadEscalas = Integer.Parse(oComisionViewModel.Parametro.Valor1)
            '    oComisionViewModel.PlanVenta.ComisionEscalaRRVV.TiempoServicio = Integer.Parse(oComisionViewModel.Parametro.Valor1)
            '    oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVV = True
            '    oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaFactorAplica = True

            '    For Each item As PlanVenta In oComisionViewModel.ListaPlanVenta
            '        item.ComisionEscala = New ComisionEscala
            '        item.ComisionEscala.PlanVentaBonificacionRRVV = True
            '    Next
            'Else 'Aquí entra cuando se va a cargar los datos d cabeceras para la modificación
            '    oComisionViewModel.PlanVenta.ComisionEscala = oComisionBusinessLogic.ObtenerComisionEscala(IdPeriodo, oComisionViewModel.ListaPlanVenta(0).Cargo.IdCargoSuperior)
            '    oComisionViewModel.PlanVenta.ComisionEscalaRRVV = oComisionBusinessLogic.ObtenerComisionEscala(IdPeriodo, oComisionViewModel.ListaPlanVenta(0).Cargo.IdCargo)
            '    'Lo siguiente es para setear el IdPeriodo a los 2 objetos del jefe y RVV los cuales estan almacenados en variables hidden
            '    oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo = New ComisionPeriodo()
            '    oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo.IdPeriodo = IdPeriodo
            '    oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo = New ComisionPeriodo()
            '    oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo.IdPeriodo = IdPeriodo

            '    For Each item As PlanVenta In oComisionViewModel.ListaPlanVenta
            '        item.ComisionEscala = New ComisionEscala
            '        item.ComisionEscala.PlanVentaBonificacionRRVV = oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaBonificacionRRVV
            '        item.ComisionEscala.PlanVentaBonificacionJefe = oComisionViewModel.PlanVenta.ComisionEscala.PlanVentaBonificacionJefe
            '    Next
            'End If


            ''Solo Inicializa el modelo para el TAB Tiempo Servicio
            'oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio = New ListaComisionEscalaTiempoServicio

            Return (PartialView(oComisionViewModel))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function GuardarPlanVentaCargoJefe(oComisionViewModel As ComisionViewModel) As ActionResult
            oComisionViewModel.PlanVenta.ComisionEscala.Completo = Convert.ToBoolean(oComisionViewModel.PlanVenta.ComisionEscala.Completo_)
            Dim Resultado As Integer
            Dim MensajeResultado As String = ""
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Resultado = oComisionBusinessLogic.Registrar_PlanVentaJefe(oComisionViewModel.PlanVenta)

            oComisionViewModel.PlanVenta.ComisionEscala = oComisionBusinessLogic.ObtenerComisionEscala(oComisionViewModel.PlanVenta.ComisionEscala.ComisionPeriodo.IdPeriodo, oComisionViewModel.PlanVenta.Cargo.IdCargoSuperior)

            Select Case Resultado
                Case Constantes.MenosUno
                    MensajeResultado = Constantes.msjGrabarError
                Case Constantes.ValorUno
                    MensajeResultado = Constantes.msjGrabar
                Case Else
                    MensajeResultado = Constantes.msjGrabarError
            End Select

            MensajeResultado = MensajeResultado & "/" & Resultado & "/" & oComisionViewModel.PlanVenta.ComisionEscala.Completo

            Return Content(MensajeResultado)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function GuardarPlanVentaCargoRRVV(oComisionViewModel As ComisionViewModel) As ActionResult
            oComisionViewModel.PlanVenta.ComisionEscalaRRVV.Completo = Convert.ToBoolean(oComisionViewModel.PlanVenta.ComisionEscalaRRVV.Completo_)
            Dim Resultado As Integer
            Dim MensajeResultado As String = ""
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            Resultado = oComisionBusinessLogic.Registrar_PlanVentaRRVV(oComisionViewModel.PlanVenta)

            oComisionViewModel.PlanVenta.ComisionEscalaRRVV = oComisionBusinessLogic.ObtenerComisionEscala(oComisionViewModel.PlanVenta.ComisionEscalaRRVV.ComisionPeriodo.IdPeriodo, oComisionViewModel.PlanVenta.Cargo.IdCargo)

            Select Case Resultado
                Case Constantes.MenosUno
                    MensajeResultado = Constantes.msjGrabarError
                Case Constantes.ValorUno
                    MensajeResultado = Constantes.msjGrabar
                Case Else
                    MensajeResultado = Constantes.msjGrabarError
            End Select

            MensajeResultado = MensajeResultado & "/" & Resultado & "/" & oComisionViewModel.PlanVenta.ComisionEscalaRRVV.Completo

            Return Content(MensajeResultado)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function _ListaEscalaComisionTiempoServicio(Optional IdPeriodo As Integer = 0, Optional nBonificacion As Integer = 0) As ActionResult
            Dim oComisionViewModel As ComisionViewModel = New ComisionViewModel
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic

            'Solo Inicializa el modelo para el TAB Tiempo Servicio
            oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio = New ListaComisionEscalaTiempoServicio

            Return (PartialView(oComisionViewModel))
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function _GestionarPlanVentasRRVV(Optional CantidadTiempo As Integer = 0, Optional CantidadEscalas As Integer = 0, Optional Nombreperiodo As String = "",
                                          Optional IdPeriodo As Integer = 0, Optional IdCargoRRVV As Integer = 0, Optional Modifica As Boolean = False) As ActionResult
            Dim oComisionViewModel As New ComisionViewModel
            Dim oConfiguracionBusinessLogic As ConfiguracionBusinessLogic = New ConfiguracionBusinessLogic
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic
            oComisionViewModel.PlanVenta = New PlanVenta
            oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio = oComisionBusinessLogic.ListarComisionEscalaTiempoServicio(IdPeriodo, IdCargoRRVV)
            If (oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Count > 0 And Modifica) Then
                For i = 0 To oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Count - 1
                    Dim idcomisiontiemposervicio As Integer = oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).IdComisionTiempoServicio
                    oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV = oComisionBusinessLogic.ListarComisionEscalaDetalleRRVV(idcomisiontiemposervicio)
                Next

            Else
                oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio = New ListaComisionEscalaTiempoServicio
                For i = 0 To CantidadTiempo
                    Dim oComisionEscalaTiempoServicio As New ComisionEscalaTiempoServicio()
                    oComisionEscalaTiempoServicio.ComisionPeriodo = New ComisionPeriodo
                    oComisionEscalaTiempoServicio.ComisionPeriodo.NombrePeriodo = Nombreperiodo
                    oComisionEscalaTiempoServicio.ListaComisionEscalaDetalleRRVV = New ListaComisionEscalaDetalle
                    For j = 0 To CantidadEscalas - 1
                        Dim oComisionEscalaDetalle As New ComisionEscalaDetalle
                        oComisionEscalaTiempoServicio.ListaComisionEscalaDetalleRRVV.Add(oComisionEscalaDetalle)
                    Next
                    oComisionViewModel.PlanVenta.ListaComisionEscalaTiempoServicio.Add(oComisionEscalaTiempoServicio)
                Next
            End If

            Return PartialView(oComisionViewModel)
        End Function
        <HttpPost()>
       <RequiresAuthenticationAjaxAttribute()> _
        Public Function ActualizarEstadoPeriodoComision(Optional ByVal IdPeriodo As Integer = Constantes.ValorCero) As ActionResult
            Dim oComisionViewModel As New ComisionViewModel
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPeriodo:" & IdPeriodo
            Log.IdOrigenAccion = Constantes.Comision_Periodo
            Log.IdLogAccion = Constantes.Eliminar
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

            Dim mensaje As String = ""
            Dim resultado As Integer = 0
            resultado = oComisionBusinessLogic.DesactivarEstadoPeriodoComision(IdPeriodo)
            Select Case resultado
                Case Constantes.ValorUno
                    mensaje = "Se eliminó el periodo comision."
                Case Constantes.MenosUno
                    mensaje = "No se pudo eliminar, ya que hubo un error."
            End Select
            mensaje = mensaje
            Return Content(Convert.ToString(mensaje))
        End Function

        <RequiresAuthenticationAjaxAttribute()> _
        Function Listar_Periodos() As ActionResult
            Dim VM As New ComisionViewModel

            VM.ListaNombrePeriodo = New ComisionBusinessLogic().ListaNombrePeriodo()
            Return PartialView(ParametrosView.ParametrosPartialView.Comision_Listar_Periodos, VM)
        End Function

        <RequiresAuthentication()>
        Function BuscarMesesComisionales(Optional IdNombreMesComisional As String = Constantes.ValorDefecto,
                                         Optional IdEstado As Integer = Constantes.ValorCero,
                                         Optional IdPeriodo As Integer = Constantes.ValorCero,
                                         Optional ByVal page As Integer = Constantes.FirstPage) As ActionResult
            Dim oComisionViewModel As New ComisionViewModel With {.Paginacion = New Paginacion With {.ListaComisionPeriodoDetalle = New ListaComisionPeriodoDetalle}}
            oComisionViewModel.ComisionPeriodo = New ComisionPeriodo
            oComisionViewModel.ComisionPeriodo.IdPeriodo = IdPeriodo
            oComisionViewModel.ListaComisionArchivo = New ListaArchivo()
            oComisionViewModel.ComisionArchivo = New Archivo()
            oComisionViewModel.Paginacion = UtilWebGrid.Paginacion_PorDefecto()
            oComisionViewModel.ComisionPeriodoDetalle = New ComisionPeriodoDetalle()
            oComisionViewModel.ListadoProcesoEstado = New ListaProcesoEstado()

            oComisionViewModel.ListadoProcesoEstado = New ComunBusinessLogic().ListaEstado(Constantes.ValorQuince)
            Dim Rpt As Integer = New ComisionBusinessLogic().Actualiza_Estados_MesesComisionales()

            'Dim Log As Log = Session("Log")
            'Log.DescripcionAccion = "FechaIni:" & FechaIni.ToString() & "|FechaFin:" & FechaFin.ToString()
            'Log.IdOrigenAccion = Constantes.Comision_Periodo
            'Log.IdLogAccion = Constantes.Buscar
            'Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

            oComisionViewModel.Paginacion.ListarArchivoComision = New ListaArchivo

            'Dim RowCount As Integer = 0
            'oComisionViewModel.Paginacion = New Paginacion()
            'oComisionViewModel.Paginacion.Page = page
            'oComisionViewModel.Paginacion.RowsPerPage = 10
            'oComisionViewModel.Paginacion.ListaComisionPeriodoDetalle = New ComisionBusinessLogic().ListarMesesComisionales2(IdNombreMesComisional, IdEstado, "", "", IdPeriodo, oComisionViewModel.Paginacion)
            'oComisionViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(oComisionViewModel.Paginacion.Page, oComisionViewModel.Paginacion.RowsPerPage, oComisionViewModel.Paginacion.TotalRows)


            Session("ListaArchivoComision") = Nothing

            Return View(oComisionViewModel)
        End Function

        '<HttpPost()> 
        '<RequiresAuthentication()>
        <RequiresAuthenticationAjaxAttribute()> _
        Function _BuscarMesesComisionales(Optional IdNombreMesComisional As String = Constantes.ValorDefecto,
                                            Optional IdEstado As Integer = Constantes.ValorCero,
                                            Optional FechaIni As String = Constantes.ValorDefecto,
                                          Optional FechaFin As String = Constantes.ValorDefecto,
                                          Optional IdPeriodo As Integer = Constantes.ValorCero,
                                         Optional ByVal page As Integer = Constantes.ValorUno) As ActionResult

            Dim oComisionViewModel As New ComisionViewModel With {.Paginacion = New Paginacion With {.ListaComisionPeriodoDetalle = New ListaComisionPeriodoDetalle}}
            oComisionViewModel.Paginacion = UtilWebGrid.Paginacion_PorDefecto()

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPeriodo:" & IdPeriodo.ToString() & _
                "|NombreMesComisional:" & IdNombreMesComisional.ToString() & _
                "|IdEstado:" & IdEstado.ToString() & _
                "|FechaIni:" & FechaIni.ToString() & _
                "|FechaFin:" & FechaFin.ToString()
            Log.IdOrigenAccion = Constantes.Comision_Periodo
            Log.IdLogAccion = Constantes.Buscar

            If IdPeriodo <> 0 Then
                Session("IdPeriodo") = IdPeriodo
            Else
                IdPeriodo = Session("IdPeriodo")
            End If

            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

            oComisionViewModel.ComisionPeriodoDetalle = New ComisionPeriodoDetalle

            oComisionViewModel.Paginacion.Page = 1
            oComisionViewModel.Paginacion.RowsPerPage = Constantes.RowsPerPage

            Dim RowCount As Integer = 0
            oComisionViewModel.Paginacion = New Paginacion()
            oComisionViewModel.Paginacion.Page = page
            oComisionViewModel.Paginacion.RowsPerPage = Constantes.RowsPerPage

            Dim FechaI As String = Constantes.ValorDefecto
            Dim FechaF As String = Constantes.ValorDefecto

            If FechaIni <> "" And FechaFin <> "" Then
                Dim FechaInD As DateTime = Convert.ToDateTime(FechaIni)
                Dim FechaFiD As DateTime = Convert.ToDateTime(FechaFin)
                Dim Mes As String = Constantes.ValorDefecto
                Dim dia As String = Constantes.ValorDefecto
                Dim Mes2 As String = Constantes.ValorDefecto
                Dim dia2 As String = Constantes.ValorDefecto

                If Convert.ToString(FechaInD.Month).Length = 1 Then
                    Mes = "0" & Convert.ToString(FechaInD.Month)
                Else
                    Mes = Convert.ToString(FechaInD.Month)
                End If

                If Convert.ToString(FechaInD.Day).Length = 1 Then
                    dia = "0" & Convert.ToString(FechaInD.Day)
                Else
                    dia = Convert.ToString(FechaInD.Day)
                End If

                If Convert.ToString(FechaFiD.Month).Length = 1 Then
                    Mes2 = "0" & Convert.ToString(FechaFiD.Month)
                Else
                    Mes2 = Convert.ToString(FechaFiD.Month)
                End If

                If Convert.ToString(FechaFiD.Day).Length = 1 Then
                    dia2 = "0" & Convert.ToString(FechaFiD.Day)
                Else
                    dia2 = Convert.ToString(FechaFiD.Day)
                End If

                FechaI = Convert.ToString(FechaInD.Year) & Mes & dia
                FechaF = Convert.ToString(FechaFiD.Year) & Mes2 & dia2
            Else
                FechaI = ""
                FechaF = ""
            End If

            oComisionViewModel.Paginacion.ListaComisionPeriodoDetalle = oComisionBusinessLogic.ListarMesesComisionales(IdNombreMesComisional, IdEstado, FechaI, FechaF, IdPeriodo, oComisionViewModel.Paginacion)

            oComisionViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(oComisionViewModel.Paginacion.Page, oComisionViewModel.Paginacion.RowsPerPage, oComisionViewModel.Paginacion.TotalRows)

            Return PartialView(oComisionViewModel)
        End Function

        <HttpPost()> _
        Function FiltrarEmpleadoJEFEVV(Optional q As String = Constantes.ValorDefecto) As JsonResult
            Dim oListaEmpleado As New ListaEmpleado()
            oListaEmpleado = New ComisionBusinessLogic().ListarEmpleado(q)
            Return Json(oListaEmpleado)

        End Function

        '<HttpPost()>
        <RequiresAuthentication()>
        Function ListarAdjuntoComisional(ByVal IdPeriodo As Integer, Optional page As Integer = Constantes.ValorUno) As ActionResult

            Dim oComisionViewModel As New ComisionViewModel With {.Paginacion = New Paginacion With {.ListarArchivoComision = New ListaArchivo}}
            oComisionViewModel.ListarArchivo = New ListaArchivo()
            oComisionViewModel.Paginacion = UtilWebGrid.Paginacion_PorDefecto()

            oComisionViewModel.Paginacion.Page = 1
            oComisionViewModel.Paginacion.RowsPerPage = Constantes.RowsPerPage

            Dim RowCount As Integer = 0
            oComisionViewModel.Paginacion = New Paginacion()
            oComisionViewModel.Paginacion.Page = page
            oComisionViewModel.Paginacion.RowsPerPage = Constantes.RowsPerPage2

            oComisionViewModel.Paginacion.ListarArchivoComision = New ComisionBusinessLogic().ListarAdjuntoComision(IdPeriodo, oComisionViewModel.Paginacion, RowCount)

            oComisionViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(oComisionViewModel.Paginacion.Page, oComisionViewModel.Paginacion.RowsPerPage, oComisionViewModel.Paginacion.TotalRows)


            Return PartialView(oComisionViewModel)
        End Function

        Public Function GuardarAdjunto() As ActionResult
            Try
                Dim IdPeriodoComision As Integer = Constantes.ValorCero
                Dim IdJefe As Integer = Constantes.ValorCero
                Dim Descripcion As String = Constantes.ValorDefecto
                Dim Aprobado As String = Constantes.ValorDefecto
                Dim Message As String = ""

                Dim oComisionViewModel As New ComisionViewModel

                oComisionViewModel.Empleado = New Empleado

                oComisionViewModel.ComisionArchivo = Session("ComisionArchivo")
                oComisionViewModel.FileAttached = Session("FileAttached")

                IdPeriodoComision = oComisionViewModel.ComisionArchivo.IdPeriodoComision
                IdJefe = oComisionViewModel.ComisionArchivo.IdJefeRRVV.IdEmpleado
                Descripcion = oComisionViewModel.ComisionArchivo.Descripcion
                Aprobado = oComisionViewModel.ComisionArchivo.AprobadoPor

                Dim FileName As String = Constantes.ValorDefecto
                Dim Nombre As String = oComisionViewModel.ComisionArchivo.Name()

                FileName = Path.GetFileName(Nombre)

                oComisionViewModel.ListaComisionArchivo = New ListaArchivo()

                UtilFile.GetFileExtension(oComisionViewModel.FileAttached.File)

                Dim NombreArchivo As String = oComisionViewModel.ComisionArchivo.Name
                oComisionViewModel.ComisionArchivo = UtilFile.GetFileFromFileAttached(oComisionViewModel.FileAttached)

                oComisionViewModel.ComisionArchivo.IdJefeRRVV = New Empleado
                oComisionViewModel.ComisionArchivo.IdJefeRRVV.IdEmpleado = IdJefe
                oComisionViewModel.ComisionArchivo.Descripcion = Descripcion
                oComisionViewModel.ComisionArchivo.AprobadoPor = Aprobado
                oComisionViewModel.ComisionArchivo.IdPeriodoComision = IdPeriodoComision

                If FileName IsNot Nothing Then
                    oComisionViewModel.ComisionArchivo.Name = FileName
                    oComisionViewModel.ComisionArchivo.OriginalName = FileName
                End If

                Dim AbsolutePathFile As String = Server.MapPath("~/Files/" & FileName)

                oComisionViewModel.FileAttached.File.SaveAs(AbsolutePathFile)

                oComisionViewModel.ComisionArchivo.Path = AbsolutePathFile

                Dim Data2 As Byte() = IO.File.ReadAllBytes(AbsolutePathFile)
                oComisionViewModel.ComisionArchivo.Data = Data2

                oComisionViewModel.ListaComisionArchivo.Add(oComisionViewModel.ComisionArchivo)
                Session("ListaArchivoComision") = oComisionViewModel.ListaComisionArchivo

                Dim Log As Log = Session("Log")
                Log.DescripcionAccion = "IdPeriodoComisional:" & IdPeriodoComision.ToString() & _
                    "|IdJefe:" & IdJefe.ToString() & _
                    "|Descripcion:" & Descripcion.ToString() & _
                    "|Aprobado:" & Aprobado.ToString() & _
                    "|IdArchivo:" & oComisionViewModel.ComisionArchivo.IdArchivo.ToString()
                Log.IdOrigenAccion = Constantes.Comision_Periodo
                Log.IdLogAccion = Constantes.Insertar
                Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

                'guardar
                Dim ResultadoPDF As Integer
                Dim oArchivo As ListaArchivo = CType(Session("ListaArchivoComision"), ListaArchivo)
                If oArchivo IsNot Nothing Then
                    For Each item In oArchivo
                        ResultadoPDF = oComisionBusinessLogic.GuardarComisionAdjunto(item, Convert.ToInt32(Session("CodigoUsuario")))
                    Next
                End If

                If System.IO.File.Exists(AbsolutePathFile) Then
                    System.IO.File.Delete(AbsolutePathFile)
                End If

                Dim Encontrado As Integer = Constantes.ValorCero

                If IsNumeric(ResultadoPDF) Then
                    Encontrado = Constantes.ValorUno
                Else
                    Encontrado = Constantes.ValorCero
                End If

                Return RedirectToAction("BuscarMesesComisionales", "Comision", New With {.IdPeriodo = Constantes.ValorCero})

            Catch ex As Exception
                Dim message As String = ex.ToString()
                Return Content(message)

            End Try
        End Function

        <HttpPost()> _
        Public Function GuardarComisionAdjunto(ByVal oComisionViewModel As ComisionViewModel) As ActionResult
            Try

                Dim Nombre As String = oComisionViewModel.ComisionArchivo.Name()

                Session("ComisionArchivo") = oComisionViewModel.ComisionArchivo
                Session("FileAttached") = oComisionViewModel.FileAttached

                If (oComisionViewModel.FileAttached.File.ContentLength / 1024) > 10240 Then
                    oComisionViewModel.FileAttached.FileAceptSize = False

                Else
                    'Return RedirectToAction("GuardarAdjunto", "Comision")


                    Dim IdPeriodoComision As Integer = Constantes.ValorCero
                    Dim IdJefe As Integer = Constantes.ValorCero
                    Dim Descripcion As String = Constantes.ValorDefecto
                    Dim Aprobado As String = Constantes.ValorDefecto
                    Dim Message As String = ""

                    'Dim oComisionViewModel As New ComisionViewModel

                    oComisionViewModel.Empleado = New Empleado

                    oComisionViewModel.ComisionArchivo = Session("ComisionArchivo")
                    oComisionViewModel.FileAttached = Session("FileAttached")

                    IdPeriodoComision = oComisionViewModel.ComisionArchivo.IdPeriodoComision
                    IdJefe = oComisionViewModel.ComisionArchivo.IdJefeRRVV.IdEmpleado
                    Descripcion = oComisionViewModel.ComisionArchivo.Descripcion
                    Aprobado = oComisionViewModel.ComisionArchivo.AprobadoPor

                    Dim FileName As String = Constantes.ValorDefecto
                    'Dim Nombre As String = oComisionViewModel.ComisionArchivo.Name()

                    FileName = Path.GetFileName(Nombre)

                    oComisionViewModel.ListaComisionArchivo = New ListaArchivo()

                    UtilFile.GetFileExtension(oComisionViewModel.FileAttached.File)

                    Dim NombreArchivo As String = oComisionViewModel.ComisionArchivo.Name
                    oComisionViewModel.ComisionArchivo = UtilFile.GetFileFromFileAttached(oComisionViewModel.FileAttached)

                    oComisionViewModel.ComisionArchivo.IdJefeRRVV = New Empleado
                    oComisionViewModel.ComisionArchivo.IdJefeRRVV.IdEmpleado = IdJefe
                    oComisionViewModel.ComisionArchivo.Descripcion = Descripcion
                    oComisionViewModel.ComisionArchivo.AprobadoPor = Aprobado
                    oComisionViewModel.ComisionArchivo.IdPeriodoComision = IdPeriodoComision

                    If FileName IsNot Nothing Then
                        oComisionViewModel.ComisionArchivo.Name = FileName
                        oComisionViewModel.ComisionArchivo.OriginalName = FileName
                    End If

                    Dim AbsolutePathFile As String = Server.MapPath("~/Files/" & FileName)

                    oComisionViewModel.FileAttached.File.SaveAs(AbsolutePathFile)

                    oComisionViewModel.ComisionArchivo.Path = AbsolutePathFile

                    Dim Data2 As Byte() = IO.File.ReadAllBytes(AbsolutePathFile)
                    oComisionViewModel.ComisionArchivo.Data = Data2

                    oComisionViewModel.ListaComisionArchivo.Add(oComisionViewModel.ComisionArchivo)
                    Session("ListaArchivoComision") = oComisionViewModel.ListaComisionArchivo

                    Dim Log As Log = Session("Log")
                    Log.DescripcionAccion = "IdPeriodoComisional:" & IdPeriodoComision.ToString() & _
                                        "|IdJefe:" & IdJefe.ToString() & _
                                        "|Descripcion:" & Descripcion.ToString() & _
                                        "|Aprobado:" & Aprobado.ToString() & _
                                        "|IdArchivo:" & oComisionViewModel.ComisionArchivo.IdArchivo.ToString()
                    Log.IdOrigenAccion = Constantes.Comision_Periodo
                    Log.IdLogAccion = Constantes.Insertar
                    Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

                    'guardar
                    Dim ResultadoPDF As Integer
                    Dim oArchivo As ListaArchivo = CType(Session("ListaArchivoComision"), ListaArchivo)
                    If oArchivo IsNot Nothing Then
                        For Each item In oArchivo
                            ResultadoPDF = oComisionBusinessLogic.GuardarComisionAdjunto(item, Convert.ToInt32(Session("CodigoUsuario")))
                        Next
                    End If

                    If System.IO.File.Exists(AbsolutePathFile) Then
                        System.IO.File.Delete(AbsolutePathFile)
                    End If

                    oComisionViewModel.FileAttached.FileAceptSize = True

                End If


                Return PartialView(oComisionViewModel)
            Catch ex As Exception
                Dim message As String = ex.ToString()
                Return Content(message)

            End Try

        End Function

        <HttpPost()> _
        Public Function EliminarComisionAdjunto(ByVal IdAdjunto As Integer, IdPeriodo As Integer) As Integer
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdAdjunto:" & IdAdjunto.ToString() & "|IdPeriodo:" & IdPeriodo.ToString()
            Log.IdOrigenAccion = Constantes.Comision_Periodo
            Log.IdLogAccion = Constantes.Insertar
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

            Dim Resultado As Integer = Constantes.ValorCero
            Resultado = oComisionBusinessLogic.EliminarComisionAdjunto(IdAdjunto, IdPeriodo)
            Return Resultado
        End Function

        Public Function Descargar_PDF(Optional IdAj As Integer = Constantes.ValorCero) As ActionResult

            Dim FileName As String = Constantes.ValorDefecto
            Dim FileNameDescription As String = Constantes.ValorDefecto
            Dim ContentType As String = Constantes.ValorDefecto

            Dim DataPdf As Byte() = Nothing
            Dim Message As String = ""
            Dim RowCount As Integer = 0
            Dim oConsultaViewModel As New ComisionViewModel()
            oConsultaViewModel.ComisionArchivo = New Archivo()
            oConsultaViewModel.ComisionArchivo = New ComisionBusinessLogic().DescargarAdjuntoComision(IdAj)

            Dim Encontrado As Integer = Constantes.ValorCero

            If oConsultaViewModel.ComisionArchivo.IdArchivo = 0 Then
                Encontrado = Constantes.ValorCero
            Else
                Encontrado = Constantes.ValorUno
            End If

            Message = Encontrado & "/" & Message

            Return Content(Message)

        End Function

        Public Sub Descargar_Archivo(Optional IdAj As Integer = Constantes.ValorCero)

            Dim FileName As String = Constantes.ValorDefecto
            Dim FileNameDescription As String = Constantes.ValorDefecto
            Dim ContentType As String = Constantes.ValorDefecto

            Dim DataPdf As Byte() = Nothing
            Dim Message As String = ""
            Dim RowCount As Integer = 0
            Dim oConsultaViewModel As New ComisionViewModel()
            oConsultaViewModel.ComisionArchivo = New Archivo()
            oConsultaViewModel.ComisionArchivo = New ComisionBusinessLogic().DescargarAdjuntoComision(IdAj)

            Dim Encontrado As Integer = Constantes.ValorCero

            If oConsultaViewModel.ComisionArchivo.IdArchivo = 0 Then
                Encontrado = Constantes.ValorCero
            Else
                Encontrado = Constantes.ValorUno
            End If
            FileName = oConsultaViewModel.ComisionArchivo.Name
            FileNameDescription = oConsultaViewModel.ComisionArchivo.OriginalName
            ContentType = oConsultaViewModel.ComisionArchivo.ContentType
            DataPdf = oConsultaViewModel.ComisionArchivo.Data

            Dim oFileStream As FileStream
            Dim AbsolutePathFile As String = Server.MapPath("~/Files/" & FileName)

            If System.IO.File.Exists(AbsolutePathFile) Then
                System.IO.File.Delete(AbsolutePathFile)
                oFileStream = New FileStream(AbsolutePathFile, FileMode.Create)
                oFileStream.Write(DataPdf, 0, DataPdf.Length)
                oFileStream.Close()

            Else
                oFileStream = New FileStream(AbsolutePathFile, FileMode.Create)
                oFileStream.Write(DataPdf, 0, DataPdf.Length)
                oFileStream.Close()

            End If

            HttpContext.Response.ClearHeaders()
            HttpContext.Response.Clear()
            HttpContext.Response.SuppressContent = False
            HttpContext.Response.ContentType = ContentType
            HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" & FileName)
            HttpContext.Response.WriteFile(AbsolutePathFile)
            HttpContext.Response.Flush()
            HttpContext.Response.End()
            Message = Encontrado & "/" & Message
            Return

        End Sub

        Function CerrarMesComisional(Optional IdPeriodoDetalle As Integer = Constantes.ValorCero) As JsonResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "CerrarMesComisional:" & IdPeriodoDetalle.ToString() & "|IdPeriodoDetalle:" & IdPeriodoDetalle.ToString()
            Log.IdOrigenAccion = Constantes.Comision_Periodo
            Log.IdLogAccion = Constantes.CerrarMes
            Dim oComisionBusinessLogic As ComisionBusinessLogic = New ComisionBusinessLogic(True, Log)

            'Dim oComisionBusinessLogic As New ComisionBusinessLogic
            Dim Resultado As Integer
            Dim Mensaje As String
            Resultado = oComisionBusinessLogic.CerrarMesComisional(IdPeriodoDetalle)
            Select Case Resultado
                Case Constantes.MenosUno
                    Mensaje = "No se pudo cerrar, ya que hubo un error."
                Case Constantes.ValorUno
                    Mensaje = "Se cerró el " + "Mes comisional  " + " corrrectamente"
                Case Constantes.ValorDos
                    Mensaje = "No se pudo cerrar el mes comisional debido que aun no esta en estado Procesado."

            End Select
            ' Mensaje = Resultado & "/" & Mensaje
            Return Json(Convert.ToString(Mensaje))
        End Function



    End Class

End Namespace

