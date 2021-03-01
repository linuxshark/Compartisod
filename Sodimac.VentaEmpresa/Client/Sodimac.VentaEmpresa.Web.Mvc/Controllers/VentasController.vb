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
Imports Sodimac.VentaEmpresa.Web.Seguridad.Filters
Imports Sodimac.VentaEmpresa.Web.Mvc.ParametrosView

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class VentasController
        Inherits BaseController

        <RequiresAuthenticationAttribute()>
        Function AgregarRepresentantes() As ActionResult
            Return View()
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarEmpleado(Optional IdEmpleado As Integer = 0, Optional TipoPerfil As Integer = 0, Optional IdEstado As Integer = 0) As ActionResult

            Dim oVentasViewModel As New VentasViewModel()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()

            oVentasViewModel.ListaEmpleadoCargo = oVentasBusinessLogic.ListaEmpleadoCargo()
            oVentasViewModel.ListaSucursal = New ListaSucursal()
            oVentasViewModel.ListaZona = New ListaZona()
            oVentasViewModel.ListaCargo = New ListaCargo()
            oVentasViewModel.ListaPerfil = New ListaPerfil()
            oVentasViewModel.ListaPerfil = oVentasBusinessLogic.CargarPerfiles()
            oVentasViewModel.ProcesoEstado = New ProcesoEstado()
            oVentasViewModel.ListaProcesoEstado = New ListaProcesoEstado()
            oVentasViewModel.ListaEstado = New ListaEstado()
            oVentasViewModel.Estado = New Estado()

            oVentasViewModel.ListaZona = oVentasBusinessLogic.ListaZonas()
            oVentasViewModel.ListaComisionEscalaDetalle = New ListaComisionEscalaDetalle()
            oVentasViewModel.ListaComisionEscalaTiempoServicio = New ListaComisionEscalaTiempoServicio()
            oVentasViewModel.ListaComisionEscala = New ListaComisionEscala()
            oVentasViewModel.ListaPlanVentaEmpleado = New ListaPlanVentaEmpleado()


            oVentasViewModel.Empleado = New Empleado()
            oVentasViewModel.ProcesoEstado = New ProcesoEstado()
            oVentasViewModel.Estado = New Estado()
            oVentasViewModel.Empleado.Estado = New Estado()
            oVentasViewModel.Empleado.ProcesoEstado = New ProcesoEstado()
            oVentasViewModel.Empleado.ListaSucursalEmpleado = New List(Of SucursalEmpleado)
            oVentasViewModel.PageSize = 10
            Session("SesionIdEstado") = IdEstado
            If IdEmpleado <> 0 Then
                oVentasViewModel.Empleado = oVentasBusinessLogic.ObtenerEmpleadoPorId(IdEmpleado, TipoPerfil)
                oVentasViewModel.Empleado.IdEmpleado = IdEmpleado
                oVentasViewModel.Estado.IdEstado = IdEstado
                'oVentasViewModel.ProcesoEstado.IdEstado = IdEstado
                oVentasViewModel.SucursalEmpleado = oVentasBusinessLogic.ObtenerSucursalEmpleadoPorId(IdEmpleado)

                oVentasViewModel.TiempoServicioTotal = oVentasBusinessLogic.ObtenerTiempoServicio()

                Session("UsuarioEmp") = oVentasViewModel.Empleado.UsuarioIngreso
            End If

            Return View(oVentasViewModel)

        End Function

        Function ConsultarBoletasReprocesar() As ActionResult
            Dim oViewEmpleado As New ProcesoViewModel
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            oViewEmpleado.ListaSucursal = oVentasBusinessLogic.ListaSucursal()
            Return View(oViewEmpleado)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ListarPlanVentaEmpleado(Optional IdEmpleado As Integer = Constantes.ValorCero,
                                            Optional page As Integer = Constantes.FirstPage,
                                            Optional sort As String = Constantes.ValorDefecto,
                                            Optional sortdir As String = Constantes.ValorDefecto) As ActionResult
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            oVentasViewModel.Paginacion = New Paginacion()
            oVentasViewModel.Paginacion.ListaPlanVentaEmpleado = New ListaPlanVentaEmpleado()
            oVentasViewModel.Paginacion.PageSize = Constantes.RegistrosPorPagina
            oVentasViewModel.Paginacion.PageNumber = page
            oVentasViewModel.Paginacion.SortBy = sort
            oVentasViewModel.Paginacion.SortType = sortdir
            oVentasViewModel.Paginacion.TotalRows = 0
            oVentasViewModel.Paginacion.Empleado = New Empleado()
            'oVentasViewModel.Empleado.SucursalEmpleado = New SucursalEmpleado()
            oVentasViewModel.Paginacion.Empleado.IdEmpleado = IdEmpleado


            oVentasViewModel.Paginacion = oVentasBusinessLogic.ObtenerPlanVentaPorIdEmpleado(oVentasViewModel.Paginacion)

            oVentasViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oVentasViewModel.Paginacion.PageNumber,
                oVentasViewModel.Paginacion.PageSize,
                oVentasViewModel.Paginacion.TotalRows
            )

            Return PartialView(oVentasViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function RegistrarSucursalEmpleado(Optional IdEmpleado As Integer = Constantes.ValorCero,
                                            Optional page As Integer = Constantes.FirstPage,
                                              Optional sort As String = Constantes.ValorDefecto,
                                            Optional sortdir As String = Constantes.ValorDefecto) As ActionResult

            Dim oVentasViewModel As VentasViewModel = New VentasViewModel
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            oVentasViewModel.Paginacion = New Paginacion()
            'oVentasViewModel.Empleado.ZonaMantenimiento = New ZonaMantenimiento()
            oVentasViewModel.Paginacion.ListaSucursalEmpleado = New ListaSucursalEmpleado()
            'oVentasViewModel.Paginacion.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            oVentasViewModel.Paginacion.PageSize = Constantes.RegistrosPorPagina
            oVentasViewModel.Paginacion.PageNumber = page
            oVentasViewModel.Paginacion.SortBy = sort
            oVentasViewModel.Paginacion.SortType = sortdir
            oVentasViewModel.Paginacion.TotalRows = 0
            oVentasViewModel.PageSize = 10

            oVentasViewModel.Paginacion.Empleado = New Empleado()
            oVentasViewModel.Paginacion.Empleado.IdEmpleado = IdEmpleado

            'oVentasViewModel.Paginacion = oVentasBusinessLogic.ObtenerSucursalPorIdEmpleados(oVentasViewModel.Paginacion)
            oVentasViewModel.Paginacion = oVentasBusinessLogic.BuscarSucursalPersonal(oVentasViewModel.Paginacion)

            oVentasViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oVentasViewModel.Paginacion.PageNumber,
                oVentasViewModel.Paginacion.PageSize,
                oVentasViewModel.Paginacion.TotalRows
            )

            Return PartialView(oVentasViewModel)

        End Function

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarEmpleado() As ActionResult
            Dim oVentasViewModel As New VentasViewModel()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            Dim oClienteBusinessLogic As New ClienteBusinessLogic()
            oVentasViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oVentasViewModel.Paginacion.ListaEmpleado = New ListaEmpleado()
            oVentasViewModel.Paginacion.ListaPlanVentaEmpleado = New ListaPlanVentaEmpleado()
            oVentasViewModel.Paginacion.ListaCargo = New ListaCargo()
            oVentasViewModel.ListaZona = New ListaZona()
            oVentasViewModel.ListaCargo = New ListaCargo()
            oVentasViewModel.ListaProcesoEstado = New ListaProcesoEstado()
            oVentasViewModel.ListaEstado = New ListaEstado()
            oVentasViewModel.ListaZonaMantenimiento = New ListaZonaMantenimiento()
            'oVentasViewModel.Paginacion.ListaSucursalEmpleado = New ListaSucursalEmpleado()
            oVentasViewModel.ListaPerfil = oVentasBusinessLogic.CargarPerfiles()
            oVentasViewModel.ListaTipoRepresentanteVenta = New ListaTipoRepresentanteVenta()
            oVentasViewModel.ListaEmpleadoCargo = oVentasBusinessLogic.ListaEmpleadoCargo()
            oVentasViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursal()
            oVentasViewModel.ListaZona = oVentasBusinessLogic.ListaZonas()
            oVentasViewModel.ListaZonaMantenimiento = oClienteBusinessLogic.ListaZonas()
            oVentasViewModel.ListaEstado = oVentasBusinessLogic.CargarEstado()
            'oVentasViewModel.ListaProcesoEstado = oVentasBusinessLogic.CargarEstado()
            Return View(oVentasViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function _BuscarEmpleado(
            Optional NombresApellidos As String = Constantes.ValorDefecto,
            Optional CodigoOfisis As String = Constantes.ValorDefecto,
            Optional IdSucursal As Integer = Constantes.ValorCero,
            Optional IdPerfil As Integer = Constantes.ValorCero,
            Optional IdTipoRepVen As Integer = Constantes.ValorCero,
            Optional IdZona As Integer = Constantes.ValorCero,
            Optional IdEstado As Integer = Constantes.ValorCero,
            Optional page As Integer = Constantes.ValorUno,
            Optional sort As String = Constantes.ValorDefecto,
            Optional sortdir As String = Constantes.ValorDefecto
        ) As ActionResult
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "ApellidosNombres:" & NombresApellidos & "|Perfil:" & IdPerfil & "|TipoRepVen:" & IdTipoRepVen &
                "|Sucursal:" & IdSucursal & "|CodigoOfisis:" & CodigoOfisis & "|Zona:" & IdZona & "|Estado:" & IdEstado
            Log.IdOrigenAccion = Constantes.Estructura_Empleado
            Log.IdLogAccion = Constantes.Buscar
            Dim oVentasBusinessLogic As New VentasBusinessLogic(True, Log)

            Dim oClienteBusinessLogic As New ClienteBusinessLogic()
            oVentasViewModel.Paginacion = New Paginacion()
            oVentasViewModel.Paginacion.PageSize = Constantes.RegistrosPorPagina
            oVentasViewModel.Paginacion.PageNumber = page
            oVentasViewModel.Paginacion.SortBy = sort
            oVentasViewModel.Paginacion.SortType = sortdir
            oVentasViewModel.Paginacion.TotalRows = 0

            oVentasViewModel.Paginacion.Empleado = New Empleado()
            oVentasViewModel.Paginacion.Empleado.CodigoOfisis = CodigoOfisis
            oVentasViewModel.Paginacion.Empleado.NombresApellidos = NombresApellidos

            oVentasViewModel.Paginacion.Empleado.Sucursal = New Sucursal()
            oVentasViewModel.Paginacion.Empleado.Sucursal.IdSucursal = IdSucursal

            oVentasViewModel.Paginacion.Empleado.Perfil = New Perfil()
            oVentasViewModel.Paginacion.Empleado.Perfil.IdPerfil = IdPerfil

            oVentasViewModel.Paginacion.Empleado.TipoRepresentanteVenta = New TipoRepresentanteVenta()
            oVentasViewModel.Paginacion.Empleado.TipoRepresentanteVenta.IdTipoRepVen = IdTipoRepVen

            oVentasViewModel.Paginacion.Empleado.Estado = New Estado()
            oVentasViewModel.Paginacion.Empleado.Estado.IdEstado = IdEstado

            oVentasViewModel.Paginacion.Empleado.ZonaMantenimiento = New ZonaMantenimiento()
            oVentasViewModel.Paginacion.Empleado.ZonaMantenimiento.IdZona = IdZona

            oVentasViewModel.Paginacion = oVentasBusinessLogic.BuscarVendedorPorFiltros(oVentasViewModel.Paginacion)

            oVentasViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                oVentasViewModel.Paginacion.PageNumber,
                oVentasViewModel.Paginacion.PageSize,
                oVentasViewModel.Paginacion.TotalRows
            )

            Return PartialView(oVentasViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function ListarTipoRepresentanteVenta(ByVal idPerfil As Integer, ByVal FlagCmbTipoRepVen As Integer) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()

            Dim nombreTipoRepVen As String = Constantes.ValorDefecto
            nombreTipoRepVen = IIf(FlagCmbTipoRepVen = 0, "-TODOS-", "-SELECCIONE-")

            Dim lista = oVentasBusinessLogic.CargarTipoRepresentanteVenta(idPerfil)
            Dim oVentasViewModel As New VentasViewModel
            oVentasViewModel.ListaTipoRepresentanteVenta = New ListaTipoRepresentanteVenta

            oVentasViewModel.ListaTipoRepresentanteVenta = lista
            If FlagCmbTipoRepVen = 0 Or (FlagCmbTipoRepVen = 1 And lista.Count = 0) Then

                lista.Add(New TipoRepresentanteVenta With {.IdTipoRepVen = 0, .nombreTipoRepVen = nombreTipoRepVen})
                Dim listaOrd = lista.OrderBy(Function(m) m.IdTipoRepVen).ToList()

                oVentasViewModel.ListaTipoRepresentanteVenta = New ListaTipoRepresentanteVenta
                For Each item As TipoRepresentanteVenta In listaOrd
                    oVentasViewModel.ListaTipoRepresentanteVenta.Add(item)
                Next

                Return PartialView(ParametrosPartialView.TipoRepresentanteVentaPV, oVentasViewModel)
            Else
                Return PartialView(ParametrosPartialView.TipoRepresentanteVentaEmpleadoPV, oVentasViewModel)
            End If

        End Function

        Function RP_Boletas(oViewBoletas As ReprocesoBoletasViewModel) As ActionResult
            Dim message As String = Constantes.Clear
            Dim oVentasViewModel As New ProcesoViewModel
            Dim oClienteBusinessLogic As New ReprocesoBusinessLogic()
            Dim consulta As String
            consulta = "0"
            Session("Consulta") = consulta
            Dim oBoletasBE As New ProcesoCarga
            oBoletasBE.IdSucursal = oViewBoletas.Sucursal
            oBoletasBE.fechaInicio = oViewBoletas.FechaInicio
            oBoletasBE.fechaFin = oViewBoletas.FechaFin
            oBoletasBE.Ruc = oViewBoletas.Dni
            oBoletasBE.NumeroDocumento = oViewBoletas.NumeroDocumento
            Session("ini") = oBoletasBE.fechaInicio
            Session("fin") = oBoletasBE.fechaFin

            If Not oBoletasBE.IdSucursal = 0 And oBoletasBE.Ruc = Nothing And oBoletasBE.NumeroDocumento = Nothing And oBoletasBE.Fecha.ToString = "12:00:00 AM" And oBoletasBE.fechaFin.ToString = "12:00:00 AM" Then

                oVentasViewModel.ListaProcesoCarga = oClienteBusinessLogic.ListarReprocesoBoletas(oBoletasBE)
                Session("ListaCarga") = oVentasViewModel.ListaProcesoCarga
            Else
                If oBoletasBE.IdSucursal = 0 Then
                    Session("sucursal") = 0
                Else
                    Session("sucursal") = oBoletasBE.IdSucursal
                End If

                If oBoletasBE.Ruc = Nothing Then
                    oBoletasBE.Ruc = "0"
                    Session("DNI") = "0"
                Else
                    oBoletasBE.Ruc = oViewBoletas.Dni
                    Session("DNI") = oBoletasBE.Ruc
                End If
                If oBoletasBE.NumeroDocumento = Nothing Then
                    oBoletasBE.NumeroDocumento = 0
                    Session("NDoc") = 0
                Else
                    oBoletasBE.NumeroDocumento = oViewBoletas.NumeroDocumento
                    Session("NDoc") = oBoletasBE.NumeroDocumento
                End If

                oVentasViewModel.ListaProcesoCarga = oClienteBusinessLogic.ListarReprocesoBoletas(oBoletasBE)
                Session("ListaCarga") = oVentasViewModel.ListaProcesoCarga
                If oVentasViewModel.ListaProcesoCarga.Count = 0 Then
                    oVentasViewModel.Mensaje = "No se encontro ningun registro"
                    consulta = 0
                    Session("Consulta") = consulta
                Else
                    consulta = 1
                    Session("Consulta") = consulta
                End If

            End If

            oVentasViewModel.RegistroPorPagina = Constantes.ValorDiez
            oVentasViewModel.Variable = ""

            Return PartialView(oVentasViewModel)
        End Function

        Function Guardar(ListaProcesoCarga As ProcesoViewModel) As ActionResult
            Dim Estado As Integer = 0
            Dim message As String = Constantes.Clear
            Dim allCust As New ListaProcesoCarga
            allCust = Session("ListaCarga")
            'ListaProcesoCarga.Variable
            Dim Proceso As New ReprocesoBusinessLogic
            Dim lista As New ListaProcesoCarga
            Dim _be As New ProcesoCarga
            Dim index As Integer
            Dim dt As DataTable
            Dim dni As String
            dni = Session("Dni")
            Dim ndoc As String
            ndoc = Session("NDoc")
            If Session("Consulta") = 0 Then
                message = 2
            Else
                'Dim Val2 As Integer = ListaProcesoCarga.Variable.Count
                If allCust.Count > 0 Then
                    If ListaProcesoCarga.Variable = Nothing Then
                        'If Session("Dni") = "0" And Session("NDoc") = 0 And Session("sucursal") = 0 Then
                        'If Val2 = 0 Then
                        If Session("Dni") = "0" And Session("NDoc") = 0 Then
                            _be.Estado = 1
                            _be.Ruc = Session("Dni")
                            _be.NumeroDocumento = 0
                            _be.IdSucursal = Session("sucursal")
                            _be.fechaInicio = Session("ini")
                            _be.fechaFin = Session("fin")
                            Proceso.EliminarRBoletas(_be)
                            message = 1
                        Else
                            _be.Estado = 0
                            _be.Ruc = Session("Dni")
                            _be.NumeroDocumento = Session("NDoc")
                            _be.IdSucursal = Session("sucursal")
                            _be.fechaInicio = Session("ini")
                            _be.fechaFin = Session("fin")
                            Proceso.EliminarRBoletas(_be)
                            message = 1
                        End If


                        'Else

                        '    _be.Estado = 0
                        '    _be.Ruc = Session("Dni")
                        '    _be.NumeroDocumento = Session("NDoc")
                        '    _be.IdSucursal = Session("sucursal")
                        '    _be.Fecha = Session("ini")
                        '    _be.fechaFin = Session("fin")
                        '    Proceso.EliminarRBoletas(_be)
                        '    _be.fechaFin = Session("fin")
                        '    message = 1

                        'End If
                        '_be.Estado = 1
                        '_be.Ruc = Session("sucursal")
                        '_be.NumeroDocumento = 0
                        '_be.IdSucursal = 0
                        '_be.Fecha = Session("ini")
                        '_be.fechaFin = Session("fin")
                        'Proceso.EliminarRBoletas(_be)
                        'message = 1
                        'Else
                        '    '_be.Estado = 0
                        '    '_be.Ruc = Session("Dni")
                        '    '_be.NumeroDocumento = Session("NDoc")
                        '    '_be.IdSucursal = Session("sucursal")
                        '    '_be.Fecha = Session("ini")
                        '    'Proceso.EliminarRBoletas(_be)
                        '    'message = 1
                        'End If


                    Else
                        Dim Val As String() = ListaProcesoCarga.Variable.Split(",")

                        For index = 0 To Val.Count - 1
                            If allCust.Select(Function(prueba) prueba.IdCliente).Contains(Val(index)) Then
                                lista.Add(allCust.Where(Function(prueba) prueba.IdCliente.Equals(CInt(Val(index)))).FirstOrDefault)
                            End If
                        Next
                        If lista.Count > 0 Then
                            For Each item As ProcesoCarga In lista
                                _be.Fecha = item.Fecha
                                _be.fechaFin = Session("fin")
                                _be.IdSucursal = item.Sucursal

                                If Estado = 0 Then
                                    _be.NumeroDocumento = item.NumeroDocumento
                                    _be.Ruc = item.Ruc
                                    If Session("Dni") = "0" Then
                                        _be.Ruc = "0"
                                    Else
                                        _be.Ruc = Session("Dni")
                                    End If
                                    If Session("NDoc") = 0 Then
                                        _be.NumeroDocumento = 0
                                    Else
                                        _be.NumeroDocumento = Session("NDoc")
                                    End If
                                    _be.fechaInicio = Session("ini")
                                    _be.Estado = 1
                                    Proceso.EliminarRBoletas(_be)
                                    Estado = 1
                                End If
                                If Estado = 1 Then
                                    _be.NumeroDocumento = item.NumeroDocumento
                                    _be.Ruc = item.Ruc

                                    Proceso.RegistrarRBoletas(_be)

                                End If
                            Next
                            message = 1
                        Else
                            message = -1

                        End If

                    End If
                Else
                    message = 2
                End If
            End If

            Return Content(message)

        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <RequiresAuthenticationAttribute()>
        Function RegistrarEmpleado(ByVal oVentasViewModel As VentasViewModel) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim Resultado As Integer = -1
            Dim MensajeResultado As String = ""

            oVentasViewModel.ListaEmpleadoCargo = New List(Of EmpleadoCargo)
            oVentasViewModel.ListaEmpleadoCargo = oVentasBusinessLogic.ListaEmpleadoCargo()
            oVentasViewModel.ListaEmpleado = New ListaEmpleado()
            oVentasViewModel.ListaSucursal = New ListaSucursal()

            oVentasViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()

            oVentasViewModel.Empleado.UsuarioRegistro = Session("UsuarioUsu").ToString()
            oVentasViewModel.Empleado.OrigenRegistro = "Mantenimiento Empleado"

            Try
                Resultado = oVentasBusinessLogic.RegistrarEmpleado(oVentasViewModel.Empleado)
            Catch ex As Exception
                Resultado = -1
            End Try

            Select Case Resultado
                Case Constantes.MenosUno
                    MensajeResultado = Constantes.msjGrabarError
                Case Constantes.ValorUno
                    MensajeResultado = Constantes.msjGrabar
                Case Constantes.ValorDos
                    MensajeResultado = Constantes.msjActualizar
                Case Constantes.ValorTres
                    MensajeResultado = "Ya existe un empleado con el Código Ofisis: " & oVentasViewModel.Empleado.CodigoOfisis
                Case Constantes.ValorCuatro
                    MensajeResultado = "Ya existe un empleado con el DNI:  " & oVentasViewModel.Empleado.DNI
                Case Constantes.ValorCinco
                    MensajeResultado = "Ya existe un empleado con el nombre 'Usuario Sistema' : " & oVentasViewModel.UsuarioIngreso
            End Select

            MensajeResultado = Resultado & "/" & MensajeResultado

            Return Content(MensajeResultado)
        End Function

        <RequiresAuthenticationAttribute()>
        Function RegistraSucursalEmpleado(Optional IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim resultado As Integer = 0
            Dim NombresApellidos As String = ""
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()

            oVentasViewModel.Empleado = New Empleado()
            oVentasViewModel.ListaCargo = New ListaCargo()
            oVentasViewModel.ListaSucursal = New ListaSucursal()
            oVentasViewModel.SucursalEmpleado = New SucursalEmpleado()
            oVentasViewModel.ListaComisionEscala = New ListaComisionEscala()
            oVentasViewModel.ListaTipoRepresentanteVenta = New ListaTipoRepresentanteVenta()
            oVentasViewModel.ListaPerfil = oVentasBusinessLogic.CargarPerfiles()
            oVentasViewModel.ListaZona = oVentasBusinessLogic.ListaZonas()
            oVentasViewModel.Empleado = oVentasBusinessLogic.ObtenerDatosEmpleado(IdEmpleado)
            oVentasViewModel.Empleado.IdEmpleado = IdEmpleado
            oVentasViewModel.Empleado.SucursalEmpleado = New SucursalEmpleado()
            'oVentasViewModel.Empleado.SucursalEmpleado.FechaRegistro = DateTime.Now
            'oVentasViewModel.Empleado.SucursalEmpleado.FechaActivacionVenta = DateTime.Now

            Return PartialView(oVentasViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAttribute()>
        <ValidateAntiForgeryToken()>
        Function RegistraSucursalEmpleado_(ByVal oVentasViewModel As VentasViewModel) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim Mensaje As String = Constantes.ValorDefecto
            Dim result As Integer = 0
            oVentasViewModel.PageSize = 10

            Dim ReportarA() As String = Split(oVentasViewModel.Empleado.Reportar, "-")
            oVentasViewModel.Empleado.Reportar = ReportarA(0)
            Try
                '  result = oVentasBusinessLogic.RegistrarSucursalEmpleado(oVentasViewModel.Empleado)
                'oVentasViewModel.Empleado.ListaSucursalEmpleado = oVentasBusinessLogic.ObtenerSucursalPorIdEmpleado(oVentasViewModel.Empleado.IdEmpleado)
            Catch ex As Exception
            End Try

            result = oVentasBusinessLogic.RegistrarSucursalEmpleado(oVentasViewModel.Empleado)

            Select Case result
                Case Constantes.ValorUno
                    Mensaje = "Se grabó correctamente la sucursal asociado al Empleado" '+ oVentasViewModel.Empleado.NombresApellidos.ToUpper()
                Case Constantes.MenosUno
                    Mensaje = "Ya existe un Jefe para la zona seleccionada."
                Case Else
                    Mensaje = "Sucedió un error al registrar la sucursal, por favor inténtelo nuevamente."
            End Select

            Mensaje = result & "/" & Mensaje

            Return Content(Mensaje)
        End Function

        <RequiresAuthenticationAttribute()>
        Function GestionarPlanVentaEmpleado(Optional IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim resultado As Integer = 0
            Dim NombresApellidos As String = ""
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            oVentasViewModel.Paginacion = New Paginacion()

            oVentasViewModel.Empleado = New Empleado()
            oVentasViewModel.Empleado.IdEmpleado = IdEmpleado

            If IdEmpleado <> 0 Then
                oVentasViewModel.SucursalEmpleado = oVentasBusinessLogic.ObtenerSucursalEmpleadoPorIdV2(IdEmpleado)
                'oVentasViewModel.ListaPlanVentaEmpleado = oVentasBusinessLogic.ObtenerTiempoServicioporEmpleado(IdEmpleado)
                oVentasViewModel.ListaComsionPeriodoDetalle = oVentasBusinessLogic.ObtenerMesesComisonalesFaltantes
            End If

            'If IdEmpleado <> 0 Then
            '    oVentasViewModel.SucursalEmpleado = oVentasBusinessLogic.ObtenerSucursalEmpleadoPorId(IdEmpleado)
            '    oVentasViewModel.ListaPlanVentaEmpleado = oVentasBusinessLogic.ObtenerTiempoServicioporEmpleado(IdEmpleado)
            'Dim dia As Integer = Convert.ToInt32(Day(Date.Now))
            'Dim tiempo As Integer = Convert.ToInt32(Month(Date.Now))
            'Dim tiempo2 As Integer
            'If dia < 21 Then
            '    tiempo2 = tiempo
            'ElseIf dia > 20 Then
            '    tiempo2 = tiempo + 1
            'End If

            'For i As Integer = tiempo2 To 12
            '    If i >= tiempo2 Then
            '        oplanventaempleado = New PlanVentaEmpleado()
            '        oplanventaempleado.comboTiempoServicio = i
            '    End If
            '    ListaPlanVentaEmpleado.Add(oplanventaempleado)
            'Next
            'oVentasViewModel.ListaPlanVentaEmpleado = ListaPlanVentaEmpleado
            'End If

            Return PartialView(oVentasViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function GestionarPlanVentaEmpleado_(ByVal oVentasViewModel As VentasViewModel) As ActionResult
            Dim Mensaje As String = Constantes.ValorDefecto

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdPlanVentaEmpleado:" & oVentasViewModel.Empleado.PlanVentaEmpleado.IdPlanVentaEmpleado.ToString() & "|IdEmpleado:" & oVentasViewModel.Empleado.IdEmpleado.ToString()
            Log.IdOrigenAccion = Constantes.Estructura_PlanVentaEmpleado
            Log.IdLogAccion = Constantes.Insertar
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic(True, Log)

            Dim Resultado As Integer = Constantes.ValorCero
            'Dim oVentasViewModel As VentasViewModel = New VentasViewModel
            Dim result As Integer = 0
            oVentasViewModel.PageSize = 10
            '   Try


            result = oVentasBusinessLogic.RegistrarPlanVentasEmpleado(oVentasViewModel.Empleado)
            Select Case result
                Case Constantes.MenosUno
                    Mensaje = "Ocurrio un error al registrar"
                Case Constantes.ValorUno
                    Mensaje = "Se grabó correctamente el plan de venta para el empleado" '+ oVentasViewModel.Empleado.NombresApellidos.ToUpper()
                Case Else
                    Mensaje = "Sucedió un error al registrar el plan de venta, por favor inténtelo nuevamente."
            End Select

            Mensaje = result & "/" & Mensaje

            Return Content(Convert.ToString(Mensaje))

        End Function
        <HttpPost()>
        <RequiresAuthenticationAttribute()>
        Function DesactivarEmpleado(ByVal IdEmpleado As Integer) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim result As Integer = 0
            Try
                result = oVentasBusinessLogic.DesactivarEmpleado(IdEmpleado)
            Catch ex As Exception
            End Try
            Return Content(result)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAttribute()>
        Function DesactivarEmpleadoporEstado(IdEmpleado As Integer, IdEstado As Integer) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim resultado As Integer = Constantes.ValorCero
            '   Dim IdEstado As Integer = Convert.ToInt32(Session("SesionIdEstado"))
            Dim Manda As Integer = Constantes.ValorCero

            If IdEstado = Parametros.VENDEDOR_ESTADO_ID_ACTIVO Then
                Manda = Parametros.VENDEDOR_ESTADO_ID_INACTIVO
            Else
                Manda = Parametros.VENDEDOR_ESTADO_ID_ACTIVO

            End If

            Dim usuario As String = Session("UsuarioUsu").ToString()
            Dim origen As String = "Mantenimiento Empleado"

            ' If resultado <> Constantes.ValorCero Then
            resultado = oVentasBusinessLogic.DesactivarEmpleadoporEstado(IdEmpleado, Manda, usuario, origen)

            Dim mensajeCliente As String = ""
            Select Case resultado
                Case 0
                    mensajeCliente = Constantes.MensajeClienteError
                Case 1
                    mensajeCliente = "Actualizado correctamente"
            End Select

            If Session("SesionIdEstado") = 26 Then
                If resultado = 1 Then
                    Dim usu As String = Session("User")
                    If UCase(Session("UsuarioEmp")) = UCase(usu) Then
                        mensajeCliente = mensajeCliente & "/" & "4"
                    End If
                Else
                    mensajeCliente = mensajeCliente & "/" & "0"
                End If
            Else
                mensajeCliente = mensajeCliente & "/" & "0"
            End If

            '  End If
            Return Content(Convert.ToString(mensajeCliente))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function _ComboListaCargo(Optional IdPerfil As Integer = 0) As ActionResult
            Dim oVentasViewModel As New VentasViewModel
            Dim oVentasBusinessLogic As New VentasBusinessLogic

            oVentasViewModel.ListaEmpleadoCargo = oVentasBusinessLogic.ListarCargosPorPerfil(IdPerfil)
            Return PartialView(oVentasViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function PVSucursal_Combo(Optional idzona As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasViewModel As New VentasViewModel
            oVentasViewModel.ListaSucursal = ServicioComunController.ConsultarZonas_Sucursales(idzona)
            Return PartialView(ParametrosPartialView.PVSucursal_Zona, oVentasViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function PVEscalaTiempoServicio_Combo(Optional ByVal IdPerfil As Integer = Constantes.ValorCero, Optional ByVal IdZona As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasViewModel As New VentasViewModel
            Dim oVentasBusinessLogic As New VentasBusinessLogic
            'oVentasViewModel.ListaComisionEscalaTiempoServicio = ServicioComunController.CargarEscalas_Tiempo_Servicios(idcargos)
            oVentasViewModel.ListaComisionEscala = oVentasBusinessLogic.CargarEscalasComisionTiempoServicio(IdPerfil, IdZona)
            Return PartialView(ParametrosPartialView.PVEscalaTiempoServicio, oVentasViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function UCSucursal__Combo(Optional idcargos As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasViewModel As New VentasViewModel
            oVentasViewModel.ListaSucursal = ServicioComunController.ConsultarSucursalCargos(idcargos)
            Return PartialView(ParametrosPartialView.UCSucursal_cargos, oVentasViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ListarZona_Cargo(Optional idcargos As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasViewModel As New VentasViewModel()
            oVentasViewModel.ListaZona = ServicioComunController.ConsultarZonasCargos(idcargos)
            Return PartialView(ParametrosPartialView.Empleado_Cargo, oVentasViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function PVSuperior_Cargo(Optional idcargos As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasViewModel As New VentasViewModel()
            oVentasViewModel.ListaCargo = ServicioComunController.ConsultarCargosSuperv(idcargos)
            Return PartialView(ParametrosPartialView.Empleado_Supervisor, oVentasViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function PVCargo_Combo(Optional ByVal idPerfil As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasViewModel As New VentasViewModel()
            oVentasViewModel.ListaCargo = New ListaCargo()
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            oVentasViewModel.ListaCargo = oVentasBusinessLogic.CargarListaCargoxPerfil(idPerfil)
            Return PartialView(ParametrosPartialView.PVCargo_porPerfil, oVentasViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function PVPerfil_ComboCargo(Optional ByVal idPerfil As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasViewModel As New VentasViewModel()
            oVentasViewModel.ListaCargo = New ListaCargo()

            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            oVentasViewModel.ListaCargo = oVentasBusinessLogic.CargarListaCargoxPerfil(idPerfil)
            Return PartialView(ParametrosPartialView.PVPerfil_comboCargo, oVentasViewModel)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultartipoPerfilZona(Optional ByVal IdPerfil As Integer = Constantes.ValorCero, Optional ByVal IdZona As Integer = Constantes.ValorCero) As ActionResult

            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel()
            Dim resultado As Integer
            resultado = oVentasBusinessLogic.ObtenerTipoPerfilVendedor(IdPerfil, IdZona)
            Return Content(resultado)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function Seleccion_tipoPerfilCargo(Optional ByVal idcargos As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel()
            Dim resultado As Integer
            resultado = oVentasBusinessLogic.Seleccion_tipoPerfilCargo(idcargos)
            Return Content(resultado)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ValidarEmpleadoCartera(Optional ByVal idempleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel()
            Dim resultado As Integer
            resultado = oVentasBusinessLogic.ValidarEmpleadoCartera(idempleado)
            Return Content(resultado)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ValidaEmpleadoActivoCartera(Optional ByVal IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel()
            Dim resultado As Integer
            resultado = oVentasBusinessLogic.ValidaEmpleadoActivoCartera(IdEmpleado)
            Return Content(resultado)
        End Function

        '///////////////////////////////////////          SELECCIONAR PERFIL Y ZONA, MOSTRAR NOMBRECARGO CORRECTO  //////////////////////////

        <RequiresAuthenticationAjaxAttribute()>
        Function comboCargoVendedor(Optional IdPerfil As Integer = Constantes.ValorCero, Optional IdZona As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel()
            Dim nombreCargo As String = ""
            nombreCargo = oVentasBusinessLogic.ObtenerNombreCargoVendedor(IdPerfil, IdZona)

            Return Content(nombreCargo)
        End Function

        '////////////////////////////////////    OBTENER CARGO SUPERIOR POR PERFIL Y ZONA   ///////////////////////////////////////////////////

        <RequiresAuthenticationAjaxAttribute()>
        Function comboCargarCargoSuperior(Optional IdPerfil As Integer = Constantes.ValorCero, Optional IdZona As Integer = Constantes.ValorCero) As ActionResult
            Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
            Dim oVentasViewModel As VentasViewModel = New VentasViewModel()
            Dim nombreCargoSuperior As String = ""
            nombreCargoSuperior = oVentasBusinessLogic.ObtenerNombreCargoSuperior(IdPerfil, IdZona)
            Return Content(nombreCargoSuperior)
        End Function

        '<RequiresAuthenticationAttribute()> _
        'Function ReprocesoVentas() As ActionResult
        '    Dim resultado As Integer = 0
        '    Dim NombresApellidos As String = ""
        '    Dim oVentasViewModel As VentasViewModel = New VentasViewModel
        '    Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()
        '    oVentasViewModel.ListaZona = New ListaZona()

        '    oVentasViewModel.ListaZona = oVentasBusinessLogic.ListaZonas()
        '    oVentasViewModel.ListaSucursal = New ListaSucursal()
        '    oVentasViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()
        '    '' oVentasViewModel. 

        '    Return View(oVentasViewModel)
        'End Function


        '<HttpPost()>
        '<RequiresAuthenticationAjaxAttribute()> _
        'Function ReprocesoVentas_(Optional ByVal IdZona As Integer = Constantes.ValorCero, Optional ByVal IdSucursal As String = "",
        '                        Optional ByVal FechaInicio As String = Constantes.FechaDefecto, Optional ByVal FechaFin As String = Constantes.FechaDefecto) As ActionResult
        '    Dim mensaje As String = ""
        '    Dim resultado As Integer = 0
        '    Dim oVentasViewModel As VentasViewModel = New VentasViewModel
        '    Dim oVentasBusinessLogic As VentasBusinessLogic = New VentasBusinessLogic()

        '    resultado = oVentasBusinessLogic.InsertaVentasporConsulta(IdZona, IdSucursal, FechaInicio, FechaFin)

        '    Select Case resultado
        '        Case Constantes.ValorUno
        '            mensaje = "Se culmino el reproceso de Venta"
        '        Case Constantes.ValorDos
        '            mensaje = "No se pudo culminar el reproceso de venta"
        '    End Select

        '    mensaje = resultado & "/" & mensaje

        '    Return Content(mensaje)
        'End Function

    End Class
End Namespace
