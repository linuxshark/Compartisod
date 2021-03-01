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

Namespace Sodimac.VentaEmpresa.Web.Mvc
    Public Class ClienteController
        Inherits BaseController

        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Function BuscarCliente() As ActionResult

            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As New ClienteBusinessLogic()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            oClientesViewModel.Paginacion = New Paginacion()

            oClientesViewModel.Paginacion.ClienteVenta = New ClienteVenta()
            oClientesViewModel.Paginacion.ListaClienteVenta = New ListaClienteVenta()
            oClientesViewModel.ListaEmpleadoProvincia = New ListaEmpleadoProvincia()
            oClientesViewModel.ListaClienteModoPagoCliente = ServicioClienteController.ListaClienteModoPago()
            oClientesViewModel.ListaEmpleadoDepartamento = ServicioComunController.ConsultarDepartamento()
            oClientesViewModel.ListaClienteCategoria = ServicioClienteController.ConsultarClienteCategoria()
            oClientesViewModel.ListaClienteSector = ServicioClienteController.ConsultarClienteSector()
            oClientesViewModel.ListaProcesoEstado = ServicioClienteController.ConsultarEstado()
            oClientesViewModel.ListaClienteTipo = ServicioClienteController.ListaClienteTipo()
            oClientesViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursal()

            oClientesViewModel.Paginacion = New Paginacion() With {
                .PageNumber = Constantes.ValorUno,
                .PageSize = Constantes.ValorDiez,
                .TotalRows = Constantes.ValorCero
            }
            oClientesViewModel.Paginacion.ListaClienteVenta = New ListaClienteVenta()

            Return View(oClientesViewModel)

        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function _BuscarCliente(
            Optional ByVal RazonSocial As String = Constantes.ValorDefecto,
             Optional ByVal IdEstado As Integer = Constantes.ValorCero,
             Optional ByVal IdDepartamento As Integer = Constantes.ValorCero,
             Optional ByVal IdProvincia As Integer = Constantes.ValorCero,
             Optional ByVal IdClienteSector As Integer = Constantes.ValorCero,
             Optional ByVal IdClienteCategoria As Integer = Constantes.ValorCero,
             Optional ByVal IdClienteTipo As Integer = Constantes.ValorCero,
             Optional ByVal page As Integer = Constantes.FirstPage,
             Optional ByVal sortDir As String = Constantes.Clear,
             Optional ByVal sort As String = Constantes.Clear,
             Optional ByVal IdModoPago As Integer = Constantes.ValorCero) As ActionResult

            Dim oClientesViewModel As New ClientesViewModel()
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "RazonSocial:" & RazonSocial & "|IdEstado:" & IdEstado & "|IdDepartamento:" & IdDepartamento &
                "|IdProvincia:" & IdProvincia & "|IdClienteSector:" & IdClienteSector & "|IdClienteCategoria:" & IdClienteCategoria &
                "|IdClientetipo:" & IdClienteTipo
            Log.IdOrigenAccion = Constantes.Venta_Cliente
            Log.IdLogAccion = Constantes.Buscar
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

            RazonSocial = HttpUtility.UrlDecode(RazonSocial)

            oClientesViewModel.Paginacion = New Paginacion()
            oClientesViewModel.Paginacion.ListaClienteVenta = New ListaClienteVenta()

            oClientesViewModel.Paginacion.ClienteVenta = New ClienteVenta()
            oClientesViewModel.Paginacion.ClienteVenta.RazonSocial = RazonSocial
            'oClientesViewModel.Paginacion.ClienteVenta.FechaModificacion = Date.Now
            oClientesViewModel.Paginacion.ClienteVenta.ProcesoEstado = New ProcesoEstado()
            oClientesViewModel.Paginacion.ClienteVenta.ProcesoEstado.IdEstado = IdEstado

            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoDepartamento = New EmpleadoDepartamento()
            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoDepartamento.IdDepartamento = IdDepartamento

            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoProvincia = New EmpleadoProvincia()
            oClientesViewModel.Paginacion.ClienteVenta.EmpleadoProvincia.IdProvincia = IdProvincia

            oClientesViewModel.Paginacion.ClienteVenta.ClienteSector = New ClienteSector()
            oClientesViewModel.Paginacion.ClienteVenta.ClienteSector.IdClienteSector = IdClienteSector

            oClientesViewModel.Paginacion.ClienteVenta.ClienteCategoria = New ClienteCategoria()
            oClientesViewModel.Paginacion.ClienteVenta.ClienteCategoria.IdClienteCategoria = IdClienteCategoria

            oClientesViewModel.Paginacion.ClienteVenta.ClienteTipo = New ClienteTipo()
            oClientesViewModel.Paginacion.ClienteVenta.ClienteTipo.IdClienteTipo = IdClienteTipo

            oClientesViewModel.Paginacion.SortType = sortDir
            oClientesViewModel.Paginacion.SortBy = sort
            oClientesViewModel.Paginacion.PageSize = 10
            oClientesViewModel.Paginacion.PageNumber = page

            oClientesViewModel.Paginacion.ClienteVenta.IdModoPago = IdModoPago

            oClientesViewModel.Paginacion = oClienteBusinessLogic.BuscarCliente(oClientesViewModel.Paginacion)

            oClientesViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                 oClientesViewModel.Paginacion.PageNumber,
                 oClientesViewModel.Paginacion.PageSize,
                 oClientesViewModel.Paginacion.TotalRows
             )

            Return PartialView(oClientesViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ListarProvincia(IdDepartamento As Integer) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            oClientesViewModel.ListaEmpleadoProvincia = ServicioComunController.ConsultarProvinciaDepartamento(IdDepartamento)
            Return PartialView(ParametrosPartialView.UCCLiente_Provincia_Combo, oClientesViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ListarDistrito(IdProvincia As Integer) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            oClientesViewModel.ListaEmpleadoDistrito = ServicioComunController.ConsultarDistritoProvincia(IdProvincia)
            Return PartialView(ParametrosPartialView.UCCLiente_Distrito_Combo, oClientesViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function Sucursales_PV_Grilla(
            Optional ByVal IdsSucursal As String = Constantes.ValorDefecto,
            Optional ByVal sordir As String = Constantes.ValorDefecto,
            Optional ByVal sort As String = Constantes.ValorDefecto,
            Optional ByVal page As Integer = Constantes.ValorUno) As ActionResult
            Dim VM As New ClientesViewModel()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()

            VM.Paginacion = New Paginacion()
            VM.Paginacion.Sucursal = New Sucursal()
            VM.Paginacion.Sucursal.IdSucursalActual = IdsSucursal
            VM.Paginacion.PageNumber = page
            VM.Paginacion.SortType = sort
            VM.Paginacion.SortBy = sordir
            VM.Paginacion.PageSize = Constantes.RowsPerPage
            VM.Paginacion = oVentasBusinessLogic.ListaSucursale_Grilla(VM.Paginacion)
            VM.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(VM.Paginacion.PageNumber, VM.Paginacion.PageSize, VM.Paginacion.TotalRows)
            Return (PartialView(ParametrosPartialView.ListarSucursales_Grilla, VM))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ListarSucursalesComboBox() As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            oClientesViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()
            Return PartialView(ParametrosPartialView.ListarSucursales_ComboBox, oClientesViewModel)
        End Function



        <RequiresAuthenticationAttribute()>
        Function GestionarCliente(
            Optional ByVal IdCliente As Integer = Constantes.ValorCero,
            Optional ByVal GuardaArchivo As Boolean = False,
            Optional ByVal page As Integer = Constantes.FirstPage,
            Optional ByVal sortDir As String = Constantes.Clear,
            Optional ByVal sort As String = Constantes.Clear
        ) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            ' Dim oMantenimientoViewModel As New MantenimientoViewModel()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            Dim oClienteBusinessLogic As New ClienteBusinessLogic()

            oClientesViewModel.ListaEmpleadoDepartamento = ServicioComunController.ConsultarDepartamento()
            oClientesViewModel.ListaClienteModoPagoCliente = ServicioClienteController.ListaClienteModoPago()
            oClientesViewModel.ListaClienteSector = ServicioClienteController.ConsultarClienteSector()
            oClientesViewModel.ListaClienteTipo = ServicioClienteController.ConsultarClienteTipo()
            oClientesViewModel.ListaClienteCategoria = ServicioClienteController.ConsultarClienteCategoria()
            oClientesViewModel.ListaGrupo = ServicioClienteController.ListarGrupo()
            oClientesViewModel.ListaTipoDocumentoCliente = ServicioClienteController.ListaTipoDocumentoCliente()

            oClientesViewModel.ClienteContacto = New ClienteContacto()
            'oClientesViewModel.ClienteContacto.FechaNacimiento = Date.Now
            oClientesViewModel.ClienteAdjunto = New ClienteAdjunto()
            oClientesViewModel.ClienteAdjunto.IdCliente = IdCliente

            oClientesViewModel.Paginacion = New Paginacion()
            oClientesViewModel.Paginacion.ClienteVenta = New ClienteVenta
            oClientesViewModel.ListaEmpleado = New ListaEmpleado()
            oClientesViewModel.Paginacion.Empleado = New Empleado()
            oClientesViewModel.Paginacion.Grupo = New Grupo()

            If IdCliente <> 0 Then
                oClientesViewModel.GuardaArchivo = GuardaArchivo
                oClientesViewModel.ClienteVenta = ServicioClienteController.ConsultarClienteID(IdCliente)
                oClientesViewModel.ListaEmpleadoProvincia = ServicioComunController.ConsultarProvinciaDepartamento(oClientesViewModel.ClienteVenta.IdDepartamento)
                oClientesViewModel.ListaEmpleadoDistrito = ServicioComunController.ConsultarDistritoProvincia(oClientesViewModel.ClienteVenta.IdProvincia)
                oClientesViewModel.PaginacionClienteAdjunto = ConsultarClienteAdjunto_PVGrilla(IdCliente, page, sortDir, sort)
                oClientesViewModel.ParametroExt = ServicioComunController.ObtenerParametroPorCodigoParametro(Constantes.CLIENTE_TIPO_ARCHIVO)
                oClientesViewModel.ParametroLong = ServicioComunController.ObtenerParametroPorCodigoParametro(Constantes.CLIENTE_TAMANIO_ARCHIVO)
                oClientesViewModel.ListaEmpleado = New ListaEmpleado()
                oClientesViewModel.Paginacion.Grupo = New Grupo()
            Else
                oClientesViewModel.ClienteVenta = New ClienteVenta()
                oClientesViewModel.ClienteVenta.IdModoPago = Constantes.ID_MODOPAGO_CONTADO
                oClientesViewModel.ClienteVenta.IdTipoDocumentoCliente = constantes.ID_TIPODOCUMENTOCLIENTE_RUC
                oClientesViewModel.ClienteVenta.Estado = New Estado()
                oClientesViewModel.ListaEmpleadoProvincia = New ListaEmpleadoProvincia()
                oClientesViewModel.ListaEmpleadoDistrito = New ListaEmpleadoDistrito()
                oClientesViewModel.ListaEmpleado = New ListaEmpleado()
                oClientesViewModel.Paginacion.Grupo = New Grupo()
            End If

            oClientesViewModel.VentaCartera = New VentaCartera()
            'oClientesViewModel.VentaCartera.FechaActivacion = Date.Now

            Return View(oClientesViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function CarteraClientes(Optional ByVal IdCliente As Integer = Constantes.ValorCero,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult
            Dim RazonSocial As String = ""
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oClienteViewModel As ClientesViewModel = New ClientesViewModel()
            oClienteViewModel.VentaCartera = New VentaCartera()
            oClienteViewModel.VentaCartera.FechaActivacion = Date.Now
            oClienteViewModel.Paginacion = New Paginacion With {.PageNumber = page,
                                                                .PageSize = Constantes.RowsPerPage,
                                                                .SortBy = sort,
                                                                .SortType = sortDir,
                                                                .Empleado = New Empleado With {.IdCliente = IdCliente},
                                                                .ListaEmpleado = New ListaEmpleado()}
            oClienteViewModel.Paginacion.ClienteVenta = New ClienteVenta()
            oClienteViewModel.Paginacion.ClienteVenta.RazonSocial = oClienteBusinessLogic.TraerCliente(IdCliente)
            oClienteViewModel.ListaEmpleado = New ListaEmpleado()

            oClienteViewModel.Paginacion = oClienteBusinessLogic.CarteraClientes_LIST(oClienteViewModel.Paginacion)
            oClienteViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                                                                  oClienteViewModel.Paginacion.PageNumber,
                                                                  oClienteViewModel.Paginacion.PageSize,
                                                                  oClienteViewModel.Paginacion.TotalRows)
            Return PartialView(oClienteViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function AgregarContacto(oClienteContactoViewModel As ClientesViewModel) As ActionResult
            Dim resultado As Integer = 0
            Dim mensajeContacto As String = Constantes.ValorDefecto
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            oClienteContactoViewModel.ClienteContacto.IdCliente = oClienteContactoViewModel.ClienteVenta.IdCliente
            Try
                resultado = oClienteBusinessLogic.AgregarContacto(oClienteContactoViewModel.ClienteContacto)
            Catch ex As Exception
                resultado = -1
            End Try

            Select Case resultado
                Case Constantes.ValorDefectoMenosUno
                    mensajeContacto = Constantes.MensajeClienteSucursal
                Case Constantes.ValorCero
                    mensajeContacto = Constantes.MensajeClienteError
                Case Constantes.ValorUno
                    mensajeContacto = Constantes.MensajeClienteGrabar
                Case Constantes.ValorDos
                    mensajeContacto = Constantes.msjContactoPrincipalRepetido
                Case Constantes.ValorTres
                    mensajeContacto = Constantes.msjContactoNombreRepetido
                Case Else
                    mensajeContacto = Constantes.MensajeClienteError
            End Select

            mensajeContacto = resultado & "/" & mensajeContacto

            Return Content(mensajeContacto)

        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function CrearCliente(ByVal oClientesViewModel As ClientesViewModel) As ActionResult
            Dim resultado As Int32
            Dim IdUsuario As Integer
            If oClientesViewModel.ClienteVenta.FechaAniversario Is Nothing Then
                oClientesViewModel.ClienteVenta.FechaAniversario = "01/01/1900"
            End If
            If oClientesViewModel.ClienteVenta.FechaAniversario = "01/01/0001" Then
                oClientesViewModel.ClienteVenta.FechaAniversario = "01/01/1900"
            End If

            If oClientesViewModel.ClienteVenta.FechaVigenciaCliente Is Nothing Then
                oClientesViewModel.ClienteVenta.FechaVigenciaCliente = "01/01/1900"
            End If
            If oClientesViewModel.ClienteVenta.FechaVigenciaCliente = "01/01/0001" Then
                oClientesViewModel.ClienteVenta.FechaVigenciaCliente = "01/01/1900"
            End If

            If Not Session("CodigoUsuario") Is Nothing Then
                IdUsuario = DirectCast(Session("CodigoUsuario"), Integer)
            Else
                resultado = 3
            End If

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdClienteCategoria:" & oClientesViewModel.ClienteVenta.IdClienteCategoria &
                "|IdClienteSector:" & oClientesViewModel.ClienteVenta.IdClienteSector &
                "|IdClienteTipo:" & oClientesViewModel.ClienteVenta.IdClienteTipo &
                "|IdModoPago:" & oClientesViewModel.ClienteVenta.IdModoPago &
                "|FechaActivacion:" & oClientesViewModel.ClienteVenta.FechaActivacion &
                "|Ruc:" & oClientesViewModel.ClienteVenta.RUC &
                "|RazonSocial:" & oClientesViewModel.ClienteVenta.RazonSocial &
                "|NombreFantasia:" & oClientesViewModel.ClienteVenta.NombreFantasia &
                "|NombreCuenta:" & oClientesViewModel.ClienteVenta.NombreCuenta &
                "|NombreRepresentanteLegal:" & oClientesViewModel.ClienteVenta.NombreRepresentanteLegal &
                "|ClasificadorExterno:" & oClientesViewModel.ClienteVenta.ClasificadorExterno &
                "|IdDepartamento:" & oClientesViewModel.ClienteVenta.IdDepartamento &
                "|IdProvincia:" & oClientesViewModel.ClienteVenta.IdProvincia &
                "|IdDistrito:" & oClientesViewModel.ClienteVenta.IdDistrito &
                "|Calle:" & oClientesViewModel.ClienteVenta.Calle &
                "|Telefono:" & oClientesViewModel.ClienteVenta.Telefono &
                "|Fax:" & oClientesViewModel.ClienteVenta.Fax &
                "|Email:" & oClientesViewModel.ClienteVenta.Email &
                "|FechaAniversario:" & oClientesViewModel.ClienteVenta.FechaAniversario &
                "|UsuarioRegistro:" & oClientesViewModel.ClienteVenta.UsuarioRegistro &
                "|IdGrupo:" & oClientesViewModel.ClienteVenta.Grupo.IdGrupo
            Log.IdOrigenAccion = Constantes.Venta_Cliente
            Log.IdLogAccion = IIf(oClientesViewModel.ClienteVenta.IdCliente = Constantes.ValorCero, 1, 2)
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

            If resultado <> 3 Then
                oClientesViewModel.ClienteVenta.UsuarioRegistro = IdUsuario
                If oClientesViewModel.ClienteVenta.IdCliente = Constantes.ValorCero Then
                    resultado = oClienteBusinessLogic.CrearCliente(oClientesViewModel.ClienteVenta)
                    oClientesViewModel.ClienteVenta.IdAprobado = "9"
                    oClientesViewModel.ClienteVenta.Anotacion = ""
                    oClientesViewModel.ClienteVenta.Motivo = "Nuevo"
                    oClienteBusinessLogic.InsertarCliente_HA(oClientesViewModel.ClienteVenta)

                Else
                    resultado = oClienteBusinessLogic.ModificarCliente(oClientesViewModel.ClienteVenta)
                End If
            End If

            Dim mensajeCliente As String = ""

            Select Case resultado
                Case Constantes.ValorCero
                    mensajeCliente = Constantes.MensajeClienteError
                Case Constantes.ValorUno
                    mensajeCliente = Constantes.MensajeClienteGrabar
                Case Constantes.ValorDos
                    mensajeCliente = Constantes.MensajeClienteActualizar
                Case Constantes.ValorTres
                    mensajeCliente = Constantes.msjSessionExpiro
                Case Constantes.ValorCuatro
                    mensajeCliente = "Ya existe un cliente registrado con el RUC: " & oClientesViewModel.ClienteVenta.RUC
                Case Else
                    mensajeCliente = Constantes.MensajeClienteError
            End Select

            mensajeCliente = resultado & "/" & mensajeCliente

            Return Content(mensajeCliente)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function Cliente_PVHistorial(Optional ByVal IdCliente As Integer = Constantes.ValorCero,
                                 Optional ByVal page As Integer = Constantes.FirstPage,
                                 Optional ByVal sortDir As String = Constantes.Clear,
                                 Optional ByVal sort As String = Constantes.Clear) As ActionResult

            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oClienteViewModel As ClientesViewModel = New ClientesViewModel()
            oClienteViewModel.Paginacion = New Paginacion With {.PageNumber = page,
                                                                .PageSize = Constantes.RowsPerPage,
                                                                .SortBy = sort,
                                                                .SortType = sortDir,
                                                                .ClienteLineaCredito = New ClienteLineaCredito With {.IdCliente = IdCliente},
                                                                .ListaClienteLineaCredito = New List(Of ClienteLineaCredito)}
            oClienteViewModel.Paginacion = oClienteBusinessLogic.ListaClienteLineaCredito(oClienteViewModel.Paginacion)
            oClienteViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                       oClienteViewModel.Paginacion.PageNumber,
                       oClienteViewModel.Paginacion.PageSize,
                       oClienteViewModel.Paginacion.TotalRows
                   )
            Return PartialView(oClienteViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function ModificarClienteContacto(oClienteContactoViewModel As ClientesViewModel) As ActionResult
            oClienteContactoViewModel.ClienteContacto.IdEstadoActual = Constantes.EstadoClienteActivoContacto

            Dim resultado As Integer = 0
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdContacto:" & oClienteContactoViewModel.ClienteContacto.IdContacto &
                "|ContactoTipo:" & oClienteContactoViewModel.ClienteContacto.ContactoTipo &
                "|Nombres:" & oClienteContactoViewModel.ClienteContacto.Nombres &
                "|Apellidos:" & oClienteContactoViewModel.ClienteContacto.Apellidos &
                "|Telefono:" & oClienteContactoViewModel.ClienteContacto.Telefono &
                "|Email:" & oClienteContactoViewModel.ClienteContacto.Email &
                "|IdContactoClase:" & oClienteContactoViewModel.ClienteContacto.IdContactoClase &
                "|Fax:" & oClienteContactoViewModel.ClienteContacto.Fax &
                "|Celular1:" & oClienteContactoViewModel.ClienteContacto.Celular1 &
                "|Celular2:" & oClienteContactoViewModel.ClienteContacto.Celular2 &
                "|FechaNacimiento:" & oClienteContactoViewModel.ClienteContacto.FechaNacimiento
            Log.IdOrigenAccion = Constantes.Venta_ClienteContacto
            Log.IdLogAccion = Constantes.Modificar
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

            resultado = oClienteBusinessLogic.ModificarClienteContacto(oClienteContactoViewModel.ClienteContacto)
            Dim mensajeCliente As String = ""

            Select Case resultado
                Case 0
                    mensajeCliente = Constantes.MensajeClienteContactoError
                Case 1
                    mensajeCliente = Constantes.MensajeClienteContactoActualizar
                Case Else
                    mensajeCliente = Constantes.MensajeClienteContactoError
            End Select

            mensajeCliente = resultado & "/" & mensajeCliente

            Return Content(mensajeCliente)

        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function EditarClienteContacto(IdContacto As Integer) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            oClientesViewModel.ListaContactoTipo = ServicioClienteController.ListaContactoTipo()
            oClientesViewModel.ListaContactoClase = ServicioClienteController.ListaContactoClase()
            oClientesViewModel.ListaClienteModoPagoCliente = ServicioClienteController.ListaClienteModoPago()
            oClientesViewModel.ClienteContacto = ServicioClienteController.ObtenerClienteContactoPorId(IdContacto)
            oClientesViewModel.ClienteContacto.IdContacto = IdContacto
            Return PartialView("ModificarClienteContacto", oClientesViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function Editar_MuestraCarteraCliente(IdCartera As Integer) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            'oClientesViewModel.ListaContactoTipo = ServicioClienteController.ListaContactoTipo()
            'oClientesViewModel.ListaContactoClase = ServicioClienteController.ListaContactoClase()
            'oClientesViewModel.ListaClienteModoPagoCliente = ServicioClienteController.ListaClienteModoPago()
            'oClientesViewModel.ClienteContacto = ServicioClienteController.ObtenerClienteContactoPorId(IdContacto)
            'oClientesViewModel.ClienteContacto.IdContacto = IdContacto
            Return PartialView("ModificarCartera", oClientesViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function ActualizarEstadoCartera(ByVal IdCartera As Integer, ByVal IdCliente As Integer, ByVal FechaAsignacion As String, ByVal FecDesasignacion As String) As ActionResult
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oVentaCartera As New VentaCartera()
            Dim mensaje As String = ""
            Dim resultado As Integer = -5
            oVentaCartera.IdCartera = IdCartera

            Dim FecAsi As DateTime
            Dim FecDes As DateTime

            Try
                FecAsi = Convert.ToDateTime(FechaAsignacion)
                FecDes = Convert.ToDateTime(FecDesasignacion)
            Catch ex As Exception
                resultado = -6
            End Try

            If FecDes >= FecAsi Then
                resultado = oClienteBusinessLogic.ActualizarEstadoCartera(IdCartera, IdCliente, FecDes)
            End If



            Select Case resultado
                Case Constantes.MenosUno
                    mensaje = "Para activar este empleado con la sucursal, debe desactivar una vigente."
                Case Constantes.MenosDos
                    mensaje = "No puede activar la cartera seleccionada, ya que existe uno vigente"
                Case Constantes.ValorUno
                    mensaje = "Se Actualizó el estado de la Cartera."
                Case Constantes.ValorDos
                    mensaje = "Se actualizó la cartera."
                Case Constantes.ValorTres
                    mensaje = "Se actualizó el estado de la Cartera."
                Case Constantes.ValorCuatro
                    mensaje = "Se actualizo el estado de cartera secundaria."
                Case Constantes.Menostres
                    mensaje = "No se puede actualizar estado, existe uno activo para esa sucursal."
                Case Constantes.ValorCinco
                    mensaje = "No se puede actualizar estado, existe uno activo para esa sucursal."
                Case Constantes.Menoscinco
                    mensaje = "1/La fecha de desasignación no puede ser menor a la fecha de asignación."
                Case Constantes.Menosseis
                    mensaje = "1/Ingrese fecha correcta."

            End Select

            'mensaje = resultado & "/" & mensaje
            mensaje = mensaje

            Return Content(Convert.ToString(mensaje))
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ActualizarEstadoCarteraCliente(ByVal IdCliente As Integer, ByVal IdCartera As Integer) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdCliente:" & IdCliente & "|IdCartera:" & IdCartera
            Log.IdOrigenAccion = Constantes.Venta_Cartera
            Log.IdLogAccion = Constantes.Eliminar
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)
            Dim oVentaCartera As New VentaCartera()
            Dim mensaje As String = ""
            Dim resultado As Integer = 0

            resultado = oClienteBusinessLogic.CambiarEstadoCarteraCliente(IdCliente, IdCartera)
            Select Case resultado
                Case Constantes.ValorUno
                    mensaje = "Se eliminó la cartera desactivada."
                Case Constantes.MenosUno
                    mensaje = "No se pudo eliminar, ya que hubo un error."
            End Select
            mensaje = mensaje

            Return Content(Convert.ToString(mensaje))
        End Function

        '<HttpPost()>
        '<RequiresAuthenticationAjaxAttribute()> _
        'Function ActualizarEstadoCliente(ByVal IdCliente As Integer, ByVal IdCodigoEstado As String) As ActionResult
        '    Dim resultado As Int32 = Constantes.ValorCero
        '    Dim IdEstado As Integer
        '    If IdCodigoEstado = Parametros.CLIENTE_ESTADO_CODIGO_ACTIVO Then
        '        'IdEstado = Parametros.CLIENTE_ESTADO_ID_INACTIVO
        '        IdEstado = Constantes.Zero
        '        resultado = Constantes.ValorDos
        '    End If
        '    If IdCodigoEstado = Parametros.CLIENTE_ESTADO_CODIGO_INACTIVO Then
        '        'IdEstado = Parametros.CLIENTE_ESTADO_ID_ACTIVO
        '        IdEstado = Constantes.ValorUno
        '        resultado = Constantes.ValorUno
        '    End If
        '    If resultado <> Constantes.ValorCero Then
        '        Dim Log As Log = Session("Log")
        '        Log.DescripcionAccion = "IdCliente:" & IdCliente & "IdCodigoEstado:" & IdCodigoEstado
        '        Log.IdOrigenAccion = Constantes.Venta_Cliente
        '        Log.IdLogAccion = IIf(IdEstado = Constantes.ValorOcho, Constantes.ValorSiete, Constantes.ValorOcho)
        '        Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

        '        oClienteBusinessLogic.ActualizarClienteEstado(IdCliente, IdEstado)
        '    End If

        '    Dim mensajeCliente As String = ""

        '    Select Case resultado
        '        Case 0
        '            mensajeCliente = Constantes.MensajeClienteError
        '        Case 1
        '            mensajeCliente = Constantes.MensajeClienteEstadoActivo
        '        Case 2
        '            mensajeCliente = Constantes.MensajeClienteEstadoInActivo
        '        Case Else
        '            mensajeCliente = Constantes.MensajeClienteError
        '    End Select

        '    Return Content(mensajeCliente)
        'End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ActualizarEstadoCliente(ByVal IdCliente As Integer, ByVal IdCodigoEstado As String, ByVal Activo As Boolean) As ActionResult
            Dim resultado As Int32 = If(Activo = True, Constantes.ValorDos, Constantes.ValorUno)
            Dim IdCodigo As Integer = If(IdCodigoEstado = Parametros.CLIENTE_ESTADO_CODIGO_INACTIVO, Parametros.CLIENTE_ESTADO_ID_ACTIVO, Parametros.CLIENTE_ESTADO_ID_INACTIVO)
            'If resultado <> Constantes.ValorCero Then
            Dim Log As Log = Session("Log")
            Dim usuarioUsu = Session("UsuarioUsu")
            Log.DescripcionAccion = "IdCliente:" & IdCliente & "|IdCodigoEstado:" & IdCodigoEstado & "|Activo:" & Activo
            Log.IdOrigenAccion = Constantes.Venta_Cliente
            Log.IdLogAccion = If(IdCodigoEstado = Parametros.CLIENTE_ESTADO_CODIGO_ACTIVO, Constantes.ValorSiete, Constantes.ValorOcho)
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)
            oClienteBusinessLogic.ActualizarClienteEstado(IdCliente, IdCodigo, Not (Activo), usuarioUsu)
            'End If
            Dim mensajeCliente As String = Constantes.Clear
            Select Case resultado
                Case 0 : mensajeCliente = Constantes.MensajeClienteError
                Case 1 : mensajeCliente = Constantes.MensajeClienteEstadoActivo
                Case 2 : mensajeCliente = Constantes.MensajeClienteEstadoInActivo
                Case Else : mensajeCliente = Constantes.MensajeClienteError
            End Select
            Return Content(mensajeCliente)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ValidarClienteActivoCartera(Optional ByVal IdCliente As Integer = Constantes.ValorCero) As ActionResult
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oClientesViewModel As ClientesViewModel = New ClientesViewModel()
            Dim resultado As Integer = 0
            resultado = oClienteBusinessLogic.ValidaClienteActivoCartera(IdCliente)
            Return Content(resultado)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Function CrearClienteAdjunto(ByVal oClientesViewModel As ClientesViewModel) As ActionResult
            Dim resultado As Int32
            oClientesViewModel.ClienteAdjunto = AgregarAdjuntoInstructivo(oClientesViewModel.FileUploadCliente, oClientesViewModel.ClienteAdjunto.NombreTemp, oClientesViewModel.ClienteAdjunto.IdCliente)
            If (oClientesViewModel.FileUploadCliente.ContentLength / 1024 <= 10240) Then
                Dim Log As Log = Session("Log")
                Log.DescripcionAccion = "IdCliente:" & oClientesViewModel.ClienteAdjunto.IdCliente &
                    "|NombreTemp:" & oClientesViewModel.ClienteAdjunto.NombreTemp &
                    "|NombreAdj:" & oClientesViewModel.ClienteAdjunto.NombreAdj &
                    "|TipoContenidoAdj:" & oClientesViewModel.ClienteAdjunto.TipoContenidoAdj &
                    "|RutaAdj:" & oClientesViewModel.ClienteAdjunto.RutaAdj
                Log.IdOrigenAccion = Constantes.Venta_ClienteAdjunto
                Log.IdLogAccion = Constantes.Insertar
                Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

                resultado = oClienteBusinessLogic.CrearClienteAdjunto(oClientesViewModel.ClienteAdjunto)
            Else
                resultado = -1
            End If


            Dim mensajeCliente As String = ""
            Select Case resultado
                Case 0
                    mensajeCliente = Constantes.MensajeClienteAdjuntoError
                Case -1
                    mensajeCliente = Constantes.MensajeClienteAdjuntoSizeError
                Case Else
                    mensajeCliente = Constantes.MensajeClienteAdjuntoGrabar
            End Select

            Session("mensajeClienteAdjunto") = mensajeCliente

            Return RedirectToAction("GestionarCliente", "Cliente", New With {
            .IdCliente = oClientesViewModel.ClienteAdjunto.IdCliente,
              .GuardaArchivo = True
            })
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function AgregarAdjuntoInstructivo(fileAdjunto As HttpPostedFileBase, NombreTemporal As String, IdCliente As Integer) As ClienteAdjunto
            Dim oAdjuntoInstructivo As ClienteAdjunto = Nothing
            If fileAdjunto IsNot Nothing Then
                Dim RutaCarpeta As String = ConfigurationManager.AppSettings("RutaCompartidaAdjCliente")
                Dim FileName As String = ""
                Dim directorioUsuario As String = (RutaCarpeta & "\") + IdCliente.ToString()
                If Not Directory.Exists(directorioUsuario) Then
                    Directory.CreateDirectory(directorioUsuario)
                End If

                FileName = Path.GetFileName(fileAdjunto.FileName)
                Dim size As Integer = fileAdjunto.ContentLength
                Dim contentType As String = fileAdjunto.ContentType
                Dim RutaFinal As String = Path.Combine(directorioUsuario, FileName)
                fileAdjunto.SaveAs(RutaFinal)

                oAdjuntoInstructivo = New ClienteAdjunto() With {
                  .NombreAdj = FileName,
                  .TipoContenidoAdj = contentType,
                  .TamanioAdj = size,
                  .RutaAdj = RutaFinal,
                  .NombreTemp = NombreTemporal,
                .IdCliente = IdCliente
                }
            End If
            Return oAdjuntoInstructivo
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function ConsultarClienteAdjunto_PVGrilla(Optional ByVal IdCliente As Integer = Constantes.ValorCero,
                         Optional ByVal page As Integer = Constantes.FirstPage,
                         Optional ByVal sortDir As String = Constantes.Clear,
                         Optional ByVal sort As String = Constantes.Clear) As Paginacion

            Dim oClientesViewModel As ClientesViewModel = New ClientesViewModel()

            oClientesViewModel.Paginacion = New Paginacion()
            oClientesViewModel.Paginacion.SortType = sortDir
            oClientesViewModel.Paginacion.SortBy = sort
            oClientesViewModel.Paginacion.PageSize = Constantes.RegistrosPorPagina
            oClientesViewModel.Paginacion.PageNumber = page

            oClientesViewModel.Paginacion.ClienteAdjunto = New ClienteAdjunto With {.IdCliente = IdCliente}
            oClientesViewModel.Paginacion = ServicioClienteController.ConsultarClienteAdjunto(oClientesViewModel.Paginacion)

            oClientesViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                        oClientesViewModel.Paginacion.PageNumber,
                        oClientesViewModel.Paginacion.PageSize,
                        oClientesViewModel.Paginacion.TotalRows
                    )

            Return oClientesViewModel.Paginacion
        End Function

        <RequiresAuthenticationAttribute()>
        Public Function DownLoadClienteAdjuntoFile(IdAdj As Integer) As ActionResult
            Dim oClienteAdjunto As ClienteAdjunto
            oClienteAdjunto = ServicioClienteController.ConsultarClienteAdjuntoId(IdAdj)
            If System.IO.File.Exists(oClienteAdjunto.RutaAdj) Then
                Return File(oClienteAdjunto.RutaAdj, oClienteAdjunto.TipoContenidoAdj, oClienteAdjunto.NombreAdj)
            Else
                ViewData("ERROR") = "Sucedió un error al descargar el archivo"
                Return View("../Shared/Error")
            End If
            Return New EmptyResult()
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function EliminarClienteAdjunto(IdAdj As Integer) As ActionResult
            Dim mensajeCliente As String = ""
            Dim resultado As Integer

            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdAdj:" & IdAdj
            Log.IdOrigenAccion = Constantes.Venta_ClienteAdjunto
            Log.IdLogAccion = Constantes.Eliminar
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

            resultado = oClienteBusinessLogic.EliminarClienteAdjunto(IdAdj)
            Select Case resultado
                Case 0
                    mensajeCliente = Constantes.MensajeClienteEliminarError
                Case 1
                    mensajeCliente = Constantes.MensajeClienteEliminarGrabar
                Case 3
                    mensajeCliente = Constantes.msjSessionExpiro
                Case Else
                    mensajeCliente = Constantes.MensajeClienteEliminarError
            End Select
            Return Content(mensajeCliente)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Public Function Cliente_PVPersonal(
            Optional ByVal IdCliente As Integer = Constantes.ValorCero,
            Optional ByVal page As Integer = Constantes.FirstPage,
            Optional ByVal sortDir As String = Constantes.Clear,
            Optional ByVal sort As String = Constantes.Clear
         ) As ActionResult

            Dim oClientesViewModel As New ClientesViewModel
            Dim oClienteBusinessLogic As New ClienteBusinessLogic()

            oClientesViewModel.ListaContactoTipo = ServicioClienteController.ListaContactoTipo()
            oClientesViewModel.ListaContactoClase = ServicioClienteController.ListaContactoClase()

            oClientesViewModel.ClienteContacto = New ClienteContacto()
            oClientesViewModel.ClienteContacto.FechaNacimiento = Date.Now
            oClientesViewModel.ClienteContacto.IdCliente = IdCliente
            oClientesViewModel.Paginacion = New Paginacion With {.PageNumber = page,
                                                                .PageSize = Constantes.RowsPerPage,
                                                                .SortBy = sort,
                                                                .SortType = sortDir,
                                                                .ClienteContacto = New ClienteContacto With {.IdCliente = IdCliente},
                                                                .ListaClienteContacto = New List(Of ClienteContacto)}
            oClientesViewModel.Paginacion.ClienteVenta = New ClienteVenta()

            oClientesViewModel.Paginacion = oClienteBusinessLogic.ListaClienteContacto(oClientesViewModel.Paginacion)
            oClientesViewModel.Paginacion.ClienteVenta.RazonSocial = oClienteBusinessLogic.TraerCliente(IdCliente)
            oClientesViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(
                                                                     oClientesViewModel.Paginacion.PageNumber,
                                                                     oClientesViewModel.Paginacion.PageSize,
                                                                     oClientesViewModel.Paginacion.TotalRows)

            oClientesViewModel.ClienteVenta = ServicioClienteController.ConsultarClienteID(IdCliente)

            Return PartialView(oClientesViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ListarEmpleado_ComboBox(Optional ByVal IdSucursal As String = "0") As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            oClientesViewModel.ListaEmpleado = New ClienteBusinessLogic().ListarEmpleadosBySucursal(IdSucursal)
            Return PartialView(ParametrosPartialView.ComboEmpleados_PV, oClientesViewModel)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Public Function NuevaCarteraCliente(IdCliente As Integer) As ActionResult
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            Dim oClientesViewModel As ClientesViewModel = New ClientesViewModel()
            oClientesViewModel.ListaEmpleado = New ListaEmpleado()
            oClientesViewModel.Empleado = New Empleado()
            oClientesViewModel.VentaCartera = New VentaCartera()
            oClientesViewModel.ClienteVenta = New ClienteVenta()
            oClientesViewModel.Sucursal = New Sucursal()
            oClientesViewModel.ClienteVenta.IdCliente = IdCliente
            oClientesViewModel.ClienteVenta.RazonSocial = oClienteBusinessLogic.TraerCliente(IdCliente)
            oClientesViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()
            oClientesViewModel.TotalRegistros = Constantes.ValorUno
            'oClientesViewModel.VentaCartera.FechaActivacion = Date.Now
            'oClientesViewModel.VentaCartera.IdCliente = oClientesViewModel.ClienteVenta.IdCliente
            'oClientesViewModel.VentaCartera.IdEmpleado = oClientesViewModel.Empleado.IdEmpleado
            Return PartialView(oClientesViewModel)
        End Function



        '///////////////////////////////////  REASIGNACIÓN DE CLIENTES A VENDEDORES ACTIVOS ////////////////////////////////////////////////////
        <RequiresAuthenticationAttribute()>
        <RequiresAuthorizationAttribute()>
        Public Function GestionarReasignacion() As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As New ClienteBusinessLogic()
            Dim oVentasBusinessLogic As New VentasBusinessLogic()

            oClientesViewModel.Sucursal = New Sucursal()
            oClientesViewModel.ListaEmpleado = New ListaEmpleado()
            oClientesViewModel.ListaSucursal = New ListaSucursal()
            oClientesViewModel.VentaCartera = New VentaCartera()
            'oClientesViewModel.VentaCartera.FechaActivacion = Date.Now
            ' oClientesViewModel.VentaCartera.FechaActivacion = DateTime.Now

            oClientesViewModel.ListaZonaMantenimiento = oClienteBusinessLogic.ListaZonas()
            'oClientesViewModel.ListaSucursal = oClienteBusinessLogic.ListarSucursales()
            Return View(oClientesViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAttribute()>
        Public Function PVSucursalporZona(ByVal IdZona As Integer) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            oClientesViewModel.ListaSucursal = oClienteBusinessLogic.ListarSucursales_Zona(IdZona)
            Return PartialView(ParametrosPartialView.PVSucursal_ZonaReasignar, oClientesViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAttribute()>
        Public Function PVSucursalporZonaActiva(ByVal IdZona As Integer) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            oClientesViewModel.ListaSucursal = oClienteBusinessLogic.ListarSucursales_Zona(IdZona)
            Return PartialView(ParametrosPartialView.PVSucursalporZonaReasignarActiva, oClientesViewModel)
        End Function
        'PVSucursalporZonaActiva
        <HttpPost()>
        <RequiresAuthenticationAttribute()>
        Public Function PVVendedorPorSucursal(ByVal IdSucursal As Integer, ByVal Idestado As Boolean) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()

            oClientesViewModel.ListaEmpleado = oClienteBusinessLogic.ListarEmpleadoporSucursales(IdSucursal, Idestado)

            Return PartialView(ParametrosPartialView.PVVendedor_Sucursal, oClientesViewModel)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAttribute()>
        Public Function PVVendedorPorSucursalActivos(ByVal IdSucursal As Integer, ByVal Idestado As Boolean, ByVal IdVendedor As Integer) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()

            ' oClientesViewModel.ListaEmpleado = oClienteBusinessLogic.ListarEmpleadoporSucursales(IdSucursal, Idestado)
            oClientesViewModel.ListaEmpleado = oClienteBusinessLogic.ListarEmpleadoporSucursalesFiltroVendedor(IdSucursal, Idestado, IdVendedor)

            Return PartialView(ParametrosPartialView.PVVendedor_SucursalActivos, oClientesViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Public Function VistaClienteporVendedor(Optional ByVal IdEmpleado As Integer = 0) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()

            oClientesViewModel.ListaClienteVenta = New ListaClienteVenta()
            If IdEmpleado <> 0 Then
                oClientesViewModel.ListaClienteVenta = oClienteBusinessLogic.ListarUsuariosporEmpleadoInactivos(IdEmpleado)
            End If
            Return PartialView(ParametrosPartialView.PVCliente_Vendedor, oClientesViewModel)
            'Return PartialView("LstClientes_PV", oClientesViewModel)
        End Function

        <RequiresAuthenticationAttribute()>
        Public Function VistaClienteporVendedorActivos(Optional ByVal IdEmpleado As Integer = 0) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()

            oClientesViewModel.ListaClienteVenta2 = New ListaClienteVenta()
            If IdEmpleado <> 0 Then
                oClientesViewModel.ListaClienteVenta2 = oClienteBusinessLogic.ListarUsuariosporEmpleadosActivos(IdEmpleado)
            End If
            Return PartialView(ParametrosPartialView.PVCliente_VendedorActivo, oClientesViewModel)
        End Function
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function AsignarClientesVendedor(Optional idClientes As String = "", Optional idClientes1 As String = "", Optional idEmpleado As Integer = 0,
                                                Optional idSucursal As Integer = 0, Optional idSucursal1 As Integer = 0, Optional IdFechaActivacion As String = Constantes.FechaDefecto,
                                                Optional idempleadoantiguo As Integer = 0) As ActionResult
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdClientes:" & idClientes &
                "|IdClientes1:" & idClientes1 &
                "|IdEmplado:" & idEmpleado &
                "|IdSucursal:" & idSucursal &
                "|IdSucursal1:" & idSucursal1 &
                "|IdFechaActivacion:" & IdFechaActivacion &
                "|IdEmpleadoAntiguo:" & idempleadoantiguo
            Log.IdOrigenAccion = Constantes.Venta_Cartera
            Log.IdLogAccion = Constantes.Reasignacion
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

            Dim mensaje As String = ""
            Dim resultado As Integer = -1
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oListaCarteraVenta As New ListaCarteraVenta()
            Dim oListaCarteraVenta2 As New ListaCarteraVenta()
            If idClientes.Length <> 0 Then
                For Each item As String In idClientes.Split(",")
                    oListaCarteraVenta.Add(New VentaCartera With {
                                            .FechaActivacion = IdFechaActivacion,
                                            .Empleado = New Empleado() With {
                                            .idEmpleado = idEmpleado,
                                            .IdEmpleadoAnterior = idempleadoantiguo
                                            },
                                            .ClienteVenta = New ClienteVenta() With {
                                            .IdCliente = item
                                            },
                                            .Sucursal = New Sucursal() With {
                                            .idSucursal = idSucursal
                                            }
                                           })
                Next
            End If
            If idClientes1.Length <> 0 Then
                For Each itemlistaventa2 As String In idClientes1.Split(",")
                    oListaCarteraVenta2.Add(New VentaCartera With {
                                            .FechaActivacion = IdFechaActivacion,
                                            .Empleado = New Empleado() With {
                                            .idEmpleado = idempleadoantiguo,
                                            .IdEmpleadoAnterior = idEmpleado
                                            },
                                            .ClienteVenta = New ClienteVenta() With {
                                            .IdCliente = itemlistaventa2
                                            },
                                            .Sucursal = New Sucursal() With {
                                            .idSucursal = idSucursal1
                                            }
                                            })
                Next
            End If
            resultado = oClienteBusinessLogic.AsignarClientesVendedor(oListaCarteraVenta, oListaCarteraVenta2)
            Select Case resultado
                Case Constantes.MenosUno
                    mensaje = "No puede asignar nuevamente este cliente otra vez a la misma sucursal"
                Case Constantes.ValorCero
                    mensaje = "Se regitro satisfactoriamente"
                Case Constantes.ValorUno
                    mensaje = "Se regitro satisfactoriamente"
                Case Else
                    mensaje = "Ocurrio un error al registrar la reasignación, Por favor intentelo nuevamente"
            End Select

            mensaje = resultado & "/" & mensaje

            Return Content(mensaje.ToString())
        End Function
        <RequiresAuthenticationAttribute()>
        Public Function PVFechaActivacionporEmpleado(Optional ByVal IdCliente As Integer = Constantes.ValorCero,
                                                     Optional ByVal IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            oClientesViewModel.VentaCartera = New VentaCartera()
            oClientesViewModel.VentaCartera.FechaActivacion = oClienteBusinessLogic.ValidaFechaActivacion(IdCliente, IdEmpleado)
            oClientesViewModel.Empleado = New VentasBusinessLogic().ObtenerEmpleadoPorId(IdEmpleado, 0)

            Return PartialView(ParametrosPartialView.PVFechaActivaporEmpleado, oClientesViewModel)
        End Function
        <RequiresAuthenticationAttribute()>
        Public Function VerificarCartera(Optional IdCliente As Integer = Constantes.ValorCero) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            oClientesViewModel.VentaCartera = New VentaCartera()
            Dim resultado As Integer = 0
            resultado = oClienteBusinessLogic.VerificarCartera(IdCliente)

            'Dim mensajeResultado As String = ""
            'Select Case resultado
            '    Case Constantes.MenosDos
            '        mensajeResultado = ""
            '    Case Constantes.ValorUno
            '        mensajeResultado = "debe registra primero"
            'End Select

            Return Content(resultado)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Public Function ComboValidaMeson(Optional IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            oClientesViewModel.VentaCartera = New VentaCartera()
            Dim valorresultado As Integer = 0
            Dim resultado As Integer = 0
            resultado = oClienteBusinessLogic.ComboValidaMeson(IdEmpleado)

            Select Case resultado
                Case Constantes.ValorUno
                    valorresultado = 1
                Case Constantes.ValorDos
                    valorresultado = 2
                Case Constantes.ValorTres
                    valorresultado = 3

            End Select
            Return Content(valorresultado)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Public Function ComboValidaTipoMesonEmpleado(Optional IdtipoCarteraEmpleado As Integer = Constantes.ValorCero, Optional IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel()
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            oClientesViewModel.VentaCartera = New VentaCartera()
            Dim resultado As Integer = 0
            Dim IdtipoCartera As Integer
            If IdtipoCarteraEmpleado = Parametros.CARTERA_ESTADO1 Then
                IdtipoCartera = Parametros.RETORNACARTERA_ESTADO2
                resultado = Constantes.MenosDos
            End If
            If IdtipoCarteraEmpleado = Parametros.CARTERA_ESTADO2 Then
                IdtipoCartera = Parametros.RETORNACARTERA_ESTADO1
                resultado = Constantes.MenosUno
            End If


            resultado = oClienteBusinessLogic.ComboValidaTipoMesonEmpleado(IdtipoCarteraEmpleado, IdEmpleado)


            'Dim resultado As Integer = 0

            Return Content(resultado)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        <ValidateAntiForgeryToken()>
        Public Function NuevaCarteraCliente_(oClientesViewModel As ClientesViewModel) As ActionResult

            Dim resultado As Integer = -1
            Dim MensajeResultado As String = ""
            Dim mensaje As String = ""
            'string userName = HttpContext.Current.User.Identity.Name;
            oClientesViewModel.VentaCartera.Usuario = Session("UsuarioUsu")
            Dim Log As Log = Session("Log")
            Log.DescripcionAccion = "IdCliente:" & oClientesViewModel.VentaCartera.IdCliente &
                "|IdEmpleado:" & oClientesViewModel.VentaCartera.IdEmpleado &
                "|IdCarteraEmpleadoTipo:" & oClientesViewModel.VentaCartera.IdCarteraEmpleadoTipo &
                "|IdSucursal:" & oClientesViewModel.VentaCartera.IdSucursal &
                "|FechaActivacion:" & oClientesViewModel.VentaCartera.FechaActivacion &
                "|Porcentaje:" & oClientesViewModel.VentaCartera.Porcentaje
            Log.IdOrigenAccion = Constantes.Venta_Cartera
            Log.IdLogAccion = Constantes.Insertar
            Dim oClienteBusinessLogic As New ClienteBusinessLogic(True, Log)

            'Dim oClientesViewModel As ClientesViewModel = New ClientesViewModel()
            oClientesViewModel.VentaCartera.IdCliente = oClientesViewModel.ClienteVenta.IdCliente
            oClientesViewModel.VentaCartera.IdEmpleado = oClientesViewModel.Empleado.IdEmpleado
            'oClientesViewModel.Sucursal = New Sucursal()
            'For Each item As String In oClientesViewModel.VentaCartera.IdSucursal.Split(",")
            If Not (oClientesViewModel.VentaCartera.IdSucursal Is Nothing) Then
                oClientesViewModel.VentaCartera.IdSucursal = oClientesViewModel.Sucursal.IdSucursal
            End If
            'Next

            Try
                If oClientesViewModel.VentaCartera.IdCarteraEmpleadoTipo = Parametros.CARTERA_ESTADO2 Then
                    resultado = oClienteBusinessLogic.CrearCarteraClientes(oClientesViewModel.VentaCartera)
                Else
                    resultado = oClienteBusinessLogic.CrearCarteraSecundariaClientes(oClientesViewModel.VentaCartera, oClientesViewModel.Paginacion)
                End If
            Catch ex As Exception
                resultado = -1
            End Try
            Select Case resultado
                Case Constantes.MenosUno
                    MensajeResultado = Constantes.msjGrabarSucursalExiste
                Case Constantes.ValorCero
                    MensajeResultado = Constantes.msjSucursalRepetida
                Case Constantes.ValorUno
                    MensajeResultado = Constantes.msjGrabar
                Case Constantes.MenosDos
                    MensajeResultado = Constantes.msjPrincipalRepetido
                Case Constantes.ValorTres
                    MensajeResultado = Constantes.msjErrorCartera
            End Select

            MensajeResultado = resultado & "/" & MensajeResultado

            Return Content(MensajeResultado)
        End Function
        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Function ValidarClienteCarteraPrincipal(Optional ByVal IdCliente As Integer = Constantes.ValorCero, Optional ByVal IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oClientesViewModel As New ClientesViewModel()
            Dim resultado As Integer
            resultado = oClienteBusinessLogic.VerificarExistenciaMeson(IdCliente)
            If resultado = 1 Then
                resultado = oClienteBusinessLogic.ValidarClienteCartera(IdCliente, IdEmpleado)
            Else
                Return Content(resultado)
            End If
            Return Content(resultado)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ValidarTipoVendedorCartera(Optional ByVal IdCliente As Integer = Constantes.ValorCero, Optional ByVal IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oClientesViewModel As New ClientesViewModel()
            Dim resultado As Integer
            Dim valorresultado As Integer = 0
            resultado = oClienteBusinessLogic.ValidarTipoVendedorCartera(IdCliente, IdEmpleado)

            'Select Case resultado
            '    Case Constantes.ValorUno
            '        valorresultado = 1
            '    Case Constantes.ValorDos
            '        valorresultado = 2
            '    Case Constantes.ValorTres
            '        valorresultado = 3
            'End Select
            Return Content(resultado)
        End Function
        <RequiresAuthenticationAjaxAttribute()>
        Function ValidarTipoEmpleadoCartera(Optional ByVal IdTipoCartera As Integer = Constantes.ValorCero, Optional ByVal IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim oClientesViewModel As New ClientesViewModel()
            Dim resultado As Integer
            Dim valorresultado As Integer = 0
            resultado = oClienteBusinessLogic.ValidarTipoEmpleadoCartera(IdTipoCartera, IdEmpleado)
            'Select Case resultado
            '    Case Constantes.ValorUno
            '        valorresultado = 1
            '    Case Constantes.ValorDos
            '        valorresultado = 2
            '    Case Constantes.ValorTres
            '        valorresultado = 3
            'End Select

            Return Content(resultado)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function CargarVistaCartera(Optional ByVal IdTipoVendedor As Int32 = Constantes.ValorUno) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel
            Dim oVentasBusinessLogic As New VentasBusinessLogic()
            oClientesViewModel.ListaEmpleado = New ListaEmpleado()
            oClientesViewModel.ListaSucursal = oVentasBusinessLogic.ListaSucursales()
            oClientesViewModel.VentaCartera = New VentaCartera()
            oClientesViewModel.VentaCartera.IdCarteraEmpleadoTipo = IdTipoVendedor
            oClientesViewModel.Paginacion = UtilWebGrid.Paginacion_PorDefecto()
            oClientesViewModel.Paginacion.PageSize = Constantes.RowsPerPage
            oClientesViewModel.Paginacion.DescRegistrosPorPaginas = UtilWebGrid.ContadorRegistrosWebGrid(oClientesViewModel.Paginacion.PageNumber, oClientesViewModel.Paginacion.PageSize, oClientesViewModel.Paginacion.TotalRows)
            Return PartialView(ParametrosPartialView.PVCliente_NuevaCarteraporTipo, oClientesViewModel)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function ListaVendedoresAutoComplete(ByVal q As String, ByVal IdCliente As Integer) As JsonResult
            Dim oClientesViewModel As New ClientesViewModel
            oClientesViewModel.ListaEmpleado = New ClienteBusinessLogic().ListarVendedores_Autocomplete(q, IdCliente)
            Return Json(oClientesViewModel.ListaEmpleado, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost()>
        <RequiresAuthenticationAjaxAttribute()>
        Public Function ListaSucursalesDisponibles(IdCliente As Integer, Optional ByVal IdEmpleado As Integer = Constantes.ValorCero) As ActionResult
            Dim oClientesViewModel As New ClientesViewModel
            oClientesViewModel.ListaSucursal = New ListaSucursal
            oClientesViewModel.ListaSucursal = New ClienteBusinessLogic().ListaSucursalesDisponibles(IdCliente, IdEmpleado)
            Return PartialView(oClientesViewModel)
        End Function

        <RequiresAuthenticationAjaxAttribute()>
        Function VerificarMesonActivo(Optional ByVal IdCliente As Integer = Constantes.ValorCero) As ActionResult
            Dim oClienteBusinessLogic As ClienteBusinessLogic = New ClienteBusinessLogic()
            Dim resultado As Integer = oClienteBusinessLogic.VerificarExistenciaMeson(IdCliente)
            Return Content(resultado)
        End Function
    End Class
End Namespace
