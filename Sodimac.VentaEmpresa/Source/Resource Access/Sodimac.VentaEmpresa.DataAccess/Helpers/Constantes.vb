Public Class Constantes

#Region "Constastes Default"
    Public Const ValorDefecto As String = ""
    Public Const FechaDefecto As String = "10-10-1900"
    Public Const ValorDefectoCero As String = "0"
    Public Const ValorDefectoUno As String = "1"
    Public Const ValorDefectoMenosUno As String = "-1"
    Public Const Menostres As Integer = -3
    Public Const MenosDos As Integer = -2
    Public Const MenosUno As Integer = -1
    Public Const ValorCero As Integer = 0
    Public Const ValorUno As Integer = 1
    Public Const ValorDos As Integer = 2
    Public Const ValorTres As Integer = 3
    Public Const ValorCuatro As Integer = 4
    Public Const ValorCinco As Integer = 5
    Public Const ValorSeis As Integer = 6
    Public Const ValorSiete As Integer = 7
    Public Const ValorOcho As Integer = 8
    Public Const ValorNueve As Integer = 9
    Public Const ValorDiez As Integer = 10
    Public Const ValorCatorce As Integer = 14
    Public Const ValorQuince As Integer = 15
#End Region

#Region "PARÁMETROS DE CONFIGURACIÓN"
    Public Const PARAMETRO_PERIODOCOMISONEMPLEADO As String = "PeriodoComisonEmpleado"
    Public Const PARAMETRO_BONOSDEFECTO As String = "BonosDefecto"
    Public Const PARAMETRO_MAXIMOFINALESCALA As String = "MaximoFinalEscala"
#End Region

End Class

Public Class Procedimientos

#Region "PROCEDIDIENTOS LOG"
    Public Const USP_ACTUALIZAR_LOG As String = "[Notificacion].[Usp_Actualizar_Log]"
    Public Const USP_SEL_ORIGENACCION As String = "[Notificacion].[Usp_Sel_OrigenAccion]"
    Public Const USP_SEL_LOGACCION As String = "[Notificacion].[Usp_Sel_LogAccion]"
#End Region

#Region "PROCEDIDIENTOS SEGURIDAD"
    Public Const SITEMAP_ROL_BY_USER As String = "[Seguridad].[SiteMap_Rol_by_User]"
    Public Const USP_INS_ROL As String = "[Seguridad].[Usp_Ins_Rol]"
    Public Const USP_DEL_ROL As String = "[Seguridad].[Usp_Del_Rol]"
    Public Const USP_UPD_ROL As String = "[Seguridad].[Usp_Upd_Rol]"
    Public Const USP_SEL_ROL As String = "[Seguridad].[Usp_Sel_Rol]"
    Public Const USP_SEL_ROL_PAGINADO As String = "[Seguridad].[Usp_Sel_Rol_Paginado]"
    Public Const USP_SEL_ROLPORID As String = "[Seguridad].[Usp_Sel_RolPorId]"
    Public Const USP_INS_ROLUSUARIO As String = "[Seguridad].[Usp_Ins_RolUsuario]"
    Public Const USP_DEL_ROLUSUARIO As String = "[Seguridad].[Usp_Del_RolUsuario]"
    Public Const USP_SEL_ROLCHECK As String = "[Seguridad].[Usp_Sel_RolCheck]"
    Public Const USP_SEL_ROLPORESTADO As String = "[Seguridad].[Usp_Sel_Rol_Estado]"
    Public Const USP_SEL_VALIDAR_USUARIO As String = "[Seguridad].[Usp_Sel_Validar_Usuario]"
    Public Const USP_ROL_BY_USER As String = "[Seguridad].[Usp_Rol_By_User]"
    Public Const USP_SEL_PAGINA As String = "[Seguridad].[Usp_Sel_Pagina]"
    Public Const USP_DEL_PAGINAROL As String = "[Seguridad].[Usp_Del_PaginaRol]"
    Public Const USP_SEL_PAGINAROL As String = "[Seguridad].[Usp_Sel_PaginaRol]"
    Public Const USP_INS_PAGINAROL As String = "[Seguridad].[Usp_Ins_PaginaRol]"
    Public Const USP_INS_USUARIO As String = "[Seguridad].[Usp_Ins_Usuario]"
    Public Const USP_UPD_USUARIO As String = "[Seguridad].[Usp_Upd_Usuario]"
    Public Const USP_DEL_USUARIO As String = "[Seguridad].[Usp_Del_Usuario]"
    Public Const USP_SEL_USUARIO As String = "[Seguridad].[Usp_Sel_Usuario]"
    Public Const USP_SEL_USUARIOPORID As String = "[Seguridad].[Usp_Sel_UsuarioPorId]"
    Public Const USP_SEL_USUARIO_PAGINADO As String = "[Seguridad].[Usp_Sel_Usuario_Paginado]"
    Public Const USP_UPD_SESIONUSUARIO As String = "[Seguridad].[Usp_Upd_SesionUsuario]"

    Public Const USP_SEL_VALIDARUSUARIOEXISTE As String = "[Seguridad].[Usp_Sel_Validar_UsuarioExiste]"

#End Region

#Region "PROCEDIMIENTOS COMISION"
    Public Const USP_INS_PERIODOCOMISION As String = "[Comision].[Usp_Ins_PeriodoComision_Nuevo]"
    Public Const USP_UPD_APROBARPERIODOCOMISION As String = "[Comision].[Usp_Upd_AprobarPeriodoComision]"
    Public Const USP_SEL_COMISIONPERIODO_PORID As String = "[Comision].[Usp_Sel_ComisionPeriodo_PorId]"
    Public Const USP_SEL_LISTAPERIODOPAGINADO As String = "[Comision].[Usp_Sel_ListaPeriodoPaginado]"
    Public Const USP_SEL_NOMBRECOMISIONPERIODO As String = "[Comision].[Usp_Sel_NombreComisionPeriodo]"
    Public Const USP_UPD_ESCALACOMISION As String = "[Comision].[Usp_Upd_EscalaComision]"
    Public Const USP_SEL_ESCALACOMISION_PORID As String = "[Comision].[Usp_Sel_EscalaComision_PorId]"
    Public Const USP_LISTAPERIODOPAGINADO As String = "[Comision].[USP_ListaPeriodoPaginado]"
    Public Const USP_SEL_COMISIONPERIODO_POR_ID As String = "[Comision].[Usp_Sel_ComisionPeriodo_Por_Id]"
    Public Const Usp_CabeceraEscalaComision As String = "Comision.Usp_CabeceraEscalaComision_Listar"
    Public Const USP_UPD_COMISIONESCALA_CAB_DETALLE As String = "Comision.Usp_UPD_EscalaComision"

    'SPRINT 6

    Public Const USP_SEL_LISTARMESESCOMISIONALES As String = "[Comision].[Usp_Sel_ListarMesesComisionales]"
    Public Const USP_CREARMESESCOMISIONALES As String = "[Comision].[Usp_CrearMesesComisionales]"
    Public Const USP_CERRARMESCOMISIONAL As String = "[Comision].[Usp_CerrarMesComisional]"

    Public Const USP_FILTRAR_EMPLEADO_VENTA As String = "[Comision].[Usp_Fil_EmpleadoVenta]"
    Public Const USP_INS_COMISION_ADJUNTO As String = "[Comision].[Usp_Ins_ComisionAdjunto]"
    Public Const USP_LISTAR_ADJUNTO_COMISION As String = "[Comision].[Usp_Sel_ComisionAdjunto]"
    Public Const USP_UPDATE_ADJUNTO_COMISION As String = "[Comision].[Usp_Upd_ComisionAdjunto]"
    Public Const USP_DESCARGAR_ADJUNTO_COMISION As String = "[Comision].[Usp_Descargar_Archivo_Comision]"

    Public Const USP_ACTUALIZA_ESTADOPROCESADO_MESCOMISIONAL As String = "[Comision].[Usp_Actualiza_EstadoProcesado_MesComisional]"

#End Region

#Region "PROCEDIMIENTOS PERIODO"

    Public Const USP_SEL_PERIODO As String = "Usp_Periodo_Listar"
    Public Const USP_UPD_PERIODO As String = "Usp_Upd_Periodo"
    Public Const USP_INS_PERIODO As String = "Usp_Ins_Periodo"
    Public Const USP_CAN_PERIODO As String = "Usp_Can_Periodo"
    Public Const USP_APR_PERIODO As String = "Usp_Apr_Periodo"

#End Region
    'Diego Valverde
#Region "PROCEDIMIENTOS Ventas"

    Public Const USP_SEL_MODOPAGO As String = "Estructura.Usp_Sel_ModoPago"
    Public Const USP_SEL_BUSCAVENTAEMPLEADO As String = "[Estructura].[Usp_Sel_BuscaVentaEmpleado]"
    Public Const USP_EMPLEADODEPARTAMENTOLISTAR As String = "[Venta].[Usp_EmpleadoDepartamentoListar]"
    Public Const USP_SEL_COMISION_REPRESENTANTESVENTAS As String = "[Comision].[Usp_Sel_Comision_RepresentantesVentas]"
    Public Const USP_SEL_NOMBRE_REPRESENTANTESVENTAS As String = "[Venta].[Usp_Sel_Nombre_RepresentantesVentas]"
    Public Const USP_LISTADEPARTAMENTO As String = "[Estructura].[Usp_ListaDepartamento]"
    Public Const USP_EMPLEADOCARGOLISTA As String = "[Estructura].[Usp_EmpleadoCargoLista]"
    Public Const USP_LISTAPROVINCIA As String = "[Estructura].[Usp_ListaProvincia]"
    Public Const USP_LISTACLIENTESECTOR As String = "[Venta].[Usp_ListaClienteSector]"
    Public Const USP_SEL_CLIENTE_SECTOR As String = "[Venta].[Usp_Sel_ClienteSector]"
    Public Const USP_SEL_CLIENTE_TIPO As String = "[Venta].[Usp_Sel_ClienteTipo]"
    Public Const USP_SEL_CLIENTE_CATEGORIA As String = "[Venta].[Usp_Sel_ClienteCategoria]"
    Public Const USP_SEL_DISTRITO As String = "[Estructura].[Usp_Sel_Distrito]"
    Public Const USP_LISTACONTACTO As String = "[Venta].[USP_ListaContactoPaginado]"
    Public Const USP_INS_CLIENTE As String = "[Venta].[Usp_Ins_Cliente]"
    Public Const USP_UPD_CLIENTE As String = "[Venta].[Usp_Upd_Cliente]"
    Public Const USP_SEL_ESTADO As String = "[Proceso].[Usp_Sel_Estado]"
    Public Const USP_SEL_BUSCACLIENTE As String = "[Cliente].[Usp_Sel_BuscaCliente]"
    Public Const USP_SEL_HISTORICOSUCURSAL As String = "[Estructura].[Usp_Sel_HistoricoSucursal]"
    Public Const USP_UPD_CLIENTE_ESTADO As String = "[Venta].[Usp_Upd_ClienteEstado]"
    Public Const USP_INS_CLIENTE_ADJUNTO As String = "[Venta].[Usp_Ins_ClienteAdjunto]"
    Public Const USP_SEL_CLIENTE_ADJUNTO As String = "[Venta].[Usp_Sel_ClienteAdjunto]"
    Public Const USP_SEL_CLIENTE_ADJUNTOID As String = "[Venta].[Usp_Sel_ClienteAdjuntoID]"
    Public Const USP_DEL_CLIENTEADJUNTO As String = "[Venta].[Usp_Del_ClienteAdjunto]"
    'JL
    Public Const USP_INS_EMPLEADO As String = "[Estructura].[Usp_Ins_Empleado]"
    Public Const USP_SEL_LISTA_SUCURSAL As String = "[Estructura].[Usp_Sel_ListaSucursales]"
    Public Const USP_LISTARSUCUSAL_GRILLA As String = "[Estructura].[Usp_ListarSucursal_Grilla]"
    ' LISTA LOS CARGOS X ZONA
    Public Const USP_SEL_LISTA_CARGOS_ZONA As String = "[Mantenimiento].[Usp_sel_Cargos_Zonas]"
    Public Const USP_SEL_LISTA_CARGOS_SUCURSALES As String = "[Mantenimiento].[Usp_sel_Cargos_Zonas_Sucursales]"
    Public Const USP_SEL_LISTA_ZONAS_SUCURSALES As String = "[Mantenimiento].[Usp_sel_Zonas_Sucursales]"
    Public Const USP_SEL_LISTA_SUPER_CARGOS As String = "[Mantenimiento].[Usp_sel_Superior_ByCargo]"
    Public Const USP_SEL_LISTA_JEFE_CARGOS As String = "[Mantenimiento].[Usp_sel_Jefe_ByCargo]"

    Public Const USP_SEL_LISTA_ZONA As String = "[Mantenimiento].[Usp_Sel_ListaZonas]"
    Public Const USP_SEL_CLIENTE_ID As String = "[Venta].[Usp_Sel_ClienteID]"
    Public Const USP_SEL_ESCALATIEMPO As String = "[Estructura].[Usp_Sel_TiempoEscalaActual]"
    Public Const USP_SEL_EMPLEADOCARGO_PORIDEMPLEADOPERFIL As String = "[Estructura].[Usp_Sel_EmpleadoCargo_PorIdEmpleadoPerfil]"

    Public Const USP_OBTENERTIEMPOSERVICIOPOREMPLEADO As String = "[Estructura].[Usp_ObtenerTiempoServicioPlanventa]"


    Public Const USP_SEL_EMPLEADO_BY_ID As String = "[Estructura].[Usp_Sel_ObtenerEmpleadoPorId]"
    Public Const USP_SEL_SUCURSAL_BY_IDEMPLEADO As String = "[Estructura].[Usp_Sel_ListaSucursalesPorEmpleados_M13068]"
    Public Const USP_INS_SUCURSALEMPLEADO As String = "[Estructura].[Usp_Insertar_SucursalEmpleado_M13068]"
    Public Const USP_DESACTIVAR_EMPLEADO As String = "[Estructura].[Usp_Desactivar_Empleado]"
    Public Const USP_CARTERACLIENTE_LIST As String = "PV_CarteraClientesLIST"


    Public Const USP_SEL_TIPO_PERFILCARGO As String = "[Estructura].[Usp_Sel_TipoPerfil]"
    Public Const USP_OBTENER_TIPO_PERFILVENDEDOR As String = "[Estructura].[Usp_Obtener_TipoPerfil]"
    Public Const USP_SEL_CARGAR_ESCALAS As String = "[Estructura].[Usp_Sel_EscalaTiempoInicial]"
    Public Const USP_OBTENER_ESCALASTIEMPO As String = "[Estructura].[Usp_Obtener_EscalaTiempoInicial]"
    Public Const USP_SEL_LISTAPERFIL As String = "[Mantenimiento].[Usp_ListaPerfil]"
    Public Const USP_SEL_LISTACARGOXPERFIL As String = "[Mantenimiento].[Usp_Perfil_CargoLista]"
    Public Const USP_SEL_MOTRARNOMBREXPERFIL As String = "[estructura].[Usp_Sel_PerfilMenor_nombre]"
    Public Const USP_OBTENER_CARGOSUPERIOR As String = "[Estructura].[Usp_Obtener_CargoSuperior]"
    Public Const USP_OBTENERNOMBREEMPLEADO As String = "[Venta].[Usp_Validar_NombreEmpleado]"
    'Public Const USP_INSERTAREPROCESOVENTAS As String = "[Venta].[Usp_Ins_Reproceso_Ventas_Prueba]"
    Public Const USP_INSERTAREPROCESOVENTAS As String = "[Venta].[Usp_Ins_Reproceso_Ventas]"
    Public Const USP_PROGRAMARJOB As String = "[dbo].[PRC_Programar]"

    'store nuevo

    Public Const USP_SEL_SUCURSALEMPLEADO_BY_ID As String = "[Estructura].[Usp_sel_ObtenerSucursalesporEmpleado]"
    Public Const USP_SEL_SUCURSALEMPLEADO_BY_IDV2 As String = "[Estructura].[Usp_sel_ObtenerSucursalesporEmpleadoV2]"
    Public Const USP_SEL_PLANVENTAEMPLEADO_BY_ID As String = "[Estructura].[Usp_Sel_ListaPlanVentasPorEmpleados]"

    Public Const USP_INS_PLANVENTAEMPLEADO As String = "[Estructura].[Usp_Insertar_PlanVentaEmpleado]"
    Public Const USP_SEL_LISTAPERFILVENTAS As String = "[Mantenimiento].[Usp_ListaPerfilVentas]"
    Public Const USP_SEL_LISTADINAMICAESCALAS As String = "[Estructura].[USP_Sel_Obtener_EscalasPeriodo]"
    Public Const USP_SEL_OBTENERESCALASPERIODOTIEMPO As String = "[Estructura].[USP_Sel_Obtener_EscalasPeriodoTiempoServicio]"
    'Public Const USP_SEL_OBTENERESCALASTIEMPOSERVICIOEMPLEADO As String = "[Estructura].[USP_Sel_Obtener_EscalasPeriodoTiempoServicioEmpleado]"
    Public Const USP_SEL_OBTENERESCALASTIEMPOSERVICIOEMPLEADO As String = "[Estructura].[Usp_Obtener_TotalServicio]"
    Public Const USP_OBTENER_MESESCOMISIONALESFALTANTES As String = "[Estructura].[Usp_Obtener_MesesComisionalesFaltantes]"

    'PROCEDIMIENTOS AGREGADOS
    Public Const USP_SEL_BUSCAEMPLEADOPORFILTROS As String = "[Estructura].[Usp_Sel_BuscaEmpleadoVenta_M13068]"
    Public Const USP_SEL_LISTAESTADO As String = "[Proceso].[Usp_Sel_ListarEstado]"
    Public Const USP_SEL_OBTENEREMPLEADOTIPO As String = "[Estructura].[Usp_Sel_ObtenerTipoPerfil]"
    Public Const USP_VAL_SUCURSALEMPLEADOCARTERA As String = "[Estructura].[Usp_Val_SucursalEmpleadoCartera]"
    Public Const USP_OBTENER_NOMBRECARGO_BY_PERFILZONA As String = "[Venta].[Usp_ObtenerNombreCargo]"

    Public Const USP_VAL_EMPLEADOCARTERA As String = "[Venta].[Usp_Val_EmpleadorelacionCartera]"
    Public Const USP_VAL_CLIENTECARTERA As String = "[Venta].[Usp_Val_ClienterelacionCartera]"

    'PLAN DE VENTAS
    Public Const USP_LISTAR_TIPOREPRESENTANTEVENTAPORPERFIL As String = "[Mantenimiento].[Usp_ListarTipoRepresentanteVentaPorPerfil_N13068]"

#End Region

    'Joel Panocca Romero
#Region "Procedimientos para Escala de comisiones"
    Public Const Usp_ListaCargo As String = "Estructura.Usp_EmpleadoCargoListar"
    Public Const Usp_ListaPerfil As String = "Estructura.Usp_EmpleadoPerfilListar"
    Public Const Usp_ListaTiempoServicio As String = "Comision.Usp_TiempoServicioListar"
    Public Const Usp_ListaEscalaComisiones As String = "Comision.Usp_EscalaComisiones_List"
    Public Const Usp_ListaPeriodo As String = "Comision.Usp_Periodo_Listar"
    Public Const USP_SEL_ESCALACOMISION_PORIDPERIODO As String = "[Comision].[Usp_Sel_EscalaComision_PorIdPeriodo]"
    Public Const USP_SEL_PERIODOCOMISIONDETALLE_PORIDPERIODO As String = "[Comision].[Usp_Sel_PeriodoComisionDetalle_PorIdPeriodo]"
    Public Const USP_SEL_LISTARESCALACOMISIONDETALLE_PORIDESCALA As String = "[Comision].[Usp_Sel_ListarEscalaComisionDetalle_PorIdEscala]"
    Public Const USP_SEL_PERIODO_PORID As String = "[Comision].[Usp_Sel_Periodo_PorId]"
    Public Const USP_SEL_LISTARESCALACOMISIONTIEMPOSERVICIO_BYPERIODO As String = "[Comision].[Usp_Sel_ListarEscalaComisionTiempoServicio_ByIdPeriodo]"
    Public Const USP_SEL_LISTARESCALACOMISIONJEFE As String = "[Comision].[Usp_Sel_ListarEscalaComisionJefe]"
    Public Const USP_SEL_LISTARTIEMPOSERVICIORRVV As String = "[Comision].[Usp_Sel_ListarTiempoServicioRRVV]"
    Public Const USP_SEL_LISTARCOMISIONESCALADETALLERRVV As String = "[Comision].[Usp_Sel_ListarComisionEscalaDetalleRRVV]"

    Public Const USP_DEL_COMISIONPERIODO As String = "[Comision].[Usp_Del_ComsionPeriodo]"

    'Nueva store para listar los periodos cancelados
    Public Const USP_SEL_LISTAPERIDOPLANTILLA As String = "[Comision].[Usp_Sel_Periodos_Plantilla]"





#End Region

#Region "PROCEDIMIENTOS CONFIGURACION"
    Public Const USP_SEL_PARAMETRO_PORCODIGOPARAMETRO As String = "[Configuracion].[Usp_Sel_Parametro_PorCodigoParametro]"
    Public Const USP_SEL_PARAMETRO_PORCODIGO As String = "[Configuracion].[Usp_Sel_Parametro_PorCodigo]"
    Public Const USP_SEL_PARAMETROS As String = "[Configuracion].[Usp_Sel_Parametros]"
    Public Const USP_ACTUALIZAR_PARAMETRO As String = "[Configuracion].[Usp_Actualizar_Parametro]"
#End Region

#Region "PROCEDIMIENTOS REPORTES"
    Public Const USP_REPORTE_GUIA_FILTROSUCURSAL1 As String = "Venta.Usp_Reporte_Guia_FiltroSucursal"
    Public Const USP_REPORTE_GUIA_FILTROSUCURSAL As String = "Venta.Usp_Reporte_Guia_FiltroSucursal3"
    Public Const USP_REPORTE_GUIA_FILTROSUCURSAL_3 As String = "Venta.Usp_Reporte_Guia_FiltroSucursal_3"
    Public Const USP_REPORTE_VENTAS_FILTROSUCURSAL As String = "Venta.Usp_Reporte_Ventas_FiltroSucursal"
    Public Const USP_REPORTE_VENDEDORES_FILTROSUCURSAL As String = "Estructura.Usp_Reporte_Vendedores_FiltroSucursal"
    Public Const USP_REPORTE_JEFEREGIONAL_FILTROZONA As String = "Estructura.Usp_Reporte_JefeRegional_FiltroZona"
    Public Const USP_REPORTE_TIENDA_FILTROSUCURSAL As String = "Estructura.Usp_Reporte_Tienda_FiltroSucursal"
    Public Const USP_REPORTE_CLIENTE_FILTROSECTOR As String = "Venta.Usp_Reporte_Cliente_FiltroSector"
    Public Const USP_REPORTE_CLIENTE_FILTROCATEGORIA As String = "Venta.Usp_Reporte_Cliente_FiltroCategoria"
    Public Const USP_REPORTE_CLIENTE_FILTROFORMAPAGO As String = "Venta.Usp_Reporte_Cliente_FiltroFormaPago"
    Public Const USP_REPORTE_TIENDA_FILTROZONA As String = "Estructura.Usp_Reporte_Tienda_FiltroZona"
    Public Const USP_REPORTE_CLIENTE_FILTROTIPOCLIENTE As String = "Venta.Usp_Reporte_Cliente_FiltroTipoCliente"
    Public Const USP_REPORTE_VENDEDORES_FILTROJEFEREGIONAL As String = "Estructura.Usp_Reporte_Vendedores_FiltroJefeRegional"
    Public Const USP_REPORTE_VENTAS_FILTROVENDEDOR As String = "Venta.Usp_Reporte_Ventas_FiltroVendedor"
    'Public Const USP_REPORTE_VENTAS_FILTROJEFEREGIONAL As String = "Venta.Usp_Reporte_Ventas_FiltroJefeRegional"
    Public Const USP_REPORTE_VENTAS_FILTROJEFEREGIONAL As String = "Venta.Usp_Reporte_Ventas_FiltroJefeRegional_2"
    Public Const USP_REPORTE_AVANCE_VENTA_FiltroSubGerente As String = "Venta.Usp_Reporte_Avance_Venta_FiltroSubGerente"
    Public Const USP_REPORTE_VENTAS_FILTROSUCURSAL_BYZONA As String = "Venta.Usp_Reporte_Ventas_FiltroSucursal_ByZona"
    'Public Const USP_REPORTE_VENDEDORES As String = "Venta.Usp_Reporte_Vendedores"
    Public Const USP_REPORTE_VENDEDORES As String = "Venta.Usp_Reporte_Vendedores_3"
    Public Const USP_SEl_LISTASUBGERENTE As String = "Venta.Usp_Sel_ListarSubGerentes"
    Public Const USP_REPORTE_VENDEDORES_G As String = "Venta.Usp_Reporte_Vendedores_G"

    Public Const USP_REPORTE_VENTAS_FILTROJEFEREGIONAL_VENTAS As String = "Venta.Usp_Reporte_Ventas_FiltroJefeRegional_Ventas"
    'Henry Raico Cerna

    Public Const USP_REPORTE_CLIENTE_FILTROESTADOLINEA As String = "[Venta].[Usp_Reporte_Cliente_FiltroEstadoLinea]"
    Public Const USP_REPORTE_CLIENTE_FILTROVENDEDORPRINCIPAL As String = "[Venta].[Usp_Reporte_Cliente_FiltroVendedorPrincipal]"

    Public Const USP_REPORTE_CLIENTE_FILTROSUCURSAL As String = "Venta.Usp_Reporte_Ventas_FiltroSucursal_Cliente"
    Public Const USP_REPORTE_VENTAS_EXPORTAR As String = "Venta.Usp_Reporte_Ventas_Exportar"

    Public Const USP_LISTAR_EMPRESA As String = "[Estructura].[Usp_Listar_Empresa]"
    Public Const USP_LISTAR_SUCURSAL_EMPRESA As String = "[Estructura].[Usp_Listar_Sucursal_Empresa]"

    Public Const USP_SEL_LISTAZONAS_REPORTEVE As String = "[ReporteVE].[Usp_Sel_ListaZonas]"
    Public Const USP_SEL_LISTASUCURSALES_REPORTEVE As String = "[ReporteVE].[Usp_Sel_ListaSucursales]"
    Public Const USP_SEL_DIASUTILESDELMES As String = "[ReporteVE].[Usp_Sel_DiasUtilesDelMes]"
    Public Const USP_SEL_DIASDEAVANCE As String = "[ReporteVE].[Usp_Sel_DiasDeAvance000000000]"
    Public Const USP_SEL_PLANVENTAPORTIENDA As String = "[ReporteVE].[Usp_Sel_PlanVentaPorTienda]"
    Public Const USP_SEL_DIASUTILESYDIASAVANCEPORMES As String = "[ReporteVE].[Usp_Sel_DiasUtilesyDiasAvancePorMes]"
    Public Const USP_SEL_VENTANETACONTADOPORTIENDA As String = "[ReporteVE].[Usp_Sel_VentaNetaContadoPorTienda]"
    Public Const USP_SEL_VENTANETACREDITOPORTIENDA As String = "[ReporteVE].[Usp_Sel_VentaNetaCreditoPorTienda]"
    Public Const USP_SEL_VENTAINTERANUAL As String = "[ReporteVE].[Usp_Sel_VentaInteranual]"
    Public Const USP_SEL_PERIODOSVENTAINTERANUAL As String = "[ReporteVE].[Usp_Sel_PeriodosVentaInteranual]"
    Public Const USP_SEL_PLANMARGENPORTIENDA As String = "[ReporteVE].[Usp_Sel_PlanMargenPorTienda]"
    Public Const USP_SEL_MARGENNETOCONTADOPORTIENDA As String = "[ReporteVE].[Usp_Sel_MargenNetoContadoPorTienda]"
    Public Const USP_SEL_MARGENNETOCONTADOPORZONA As String = "[ReporteVE].[Usp_Sel_MargenNetoContadoPorZona]"

    Public Const USP_SEL_MARGENTOTALCONTADO As String = "[ReporteVE].[Usp_Sel_MargenTotalContadoPorZona]"
    Public Const USP_SEL_MARGENTOTALCREDITO As String = "[ReporteVE].[Usp_Sel_MargenTotalCredito]"

    Public Const USP_SEL_MARGENNETOCREDITOPORTIENDA As String = "[ReporteVE].[Usp_Sel_MargenNetoCreditoPorTienda]"
    Public Const USP_SEL_MARGENNETOCREDITOPORZONA As String = "[ReporteVE].[Usp_Sel_MargenNetoCreditoPorZona]"
    Public Const USP_SEL_MARGENNETOTOTALPORTIENDA As String = "[ReporteVE].[Usp_Sel_MargenNetoTotalPorTienda]"

    Public Const USP_SEL_MARGENNETOTOTALPORZONA As String = "[ReporteVE].[Usp_Sel_MargenNetoTotalPorZona]"
    Public Const USP_SEL_MARGENNETOTOTAL As String = "[ReporteVE].[Usp_Sel_MargenNetoTotal]"

    Public Const USP_SEL_TRANSACVENTACONTADOPORTIENDA As String = "[ReporteVE].[Usp_Sel_TransacVentaContadoPorTienda]"
    Public Const USP_SEL_TRANSACVENTACREDITOPORTIENDA As String = "[ReporteVE].[Usp_Sel_TransacVentaCreditoPorTienda]"


    Public Const USP_SEL_TRANSACVENTACONTADOPORSUCURSAL As String = "[ReporteVE].[Usp_Sel_TransaccionPorSucursal]"
    Public Const USP_SEL_TRANSACVENTACREDITOPORSUCURSAL As String = "[ReporteVE].[Usp_Sel_TransaccionPorSucursalCredito]"
    Public Const USP_SEL_TRANSACVENTATOTAL As String = "[ReporteVE].[Usp_Sel_TransaccionTotal]"

    Public Const USP_SEL_TOTALTICKETSUCURSALCONTADO As String = "[ReporteVE].[Usp_Sel_Total_Por_Ticket_Sucursales]"
    Public Const USP_SEL_TOTALTICKETSUCURSALCREDITO As String = "[ReporteVE].[Usp_Sel_Total_Por_Ticket_SucursalesCredito ]"
    Public Const USP_SEL_TOTALTICKETZONACONTADO As String = "[ReporteVE].[Usp_Sel_Total_Por_Ticket_ZonaContado]"
    Public Const USP_SEL_TOTALTICKETZONACREDITO As String = "[ReporteVE].[Usp_Sel_Total_Por_Ticket_ZonaCredito]"

    Public Const USP_SEL_TOTALTICKETTOTAL As String = "[ReporteVE].[Usp_Sel_Total_Por_Ticket]"


    Public Const Usp_Sel_Detallado_Por_Familia As String = "[ReporteVE].[Usp_Sel_Detallado_Por_Familia]"
    Public Const Usp_Sel_Detallado_Por_Dia As String = "[ReporteVE].[Usp_Sel_Detallado_Por_Dia]"
    Public Const Usp_Sel_ComparativoFamilia As String = "[ReporteVE].[Usp_Sel_ComparativoFamilia]"

    Public Const Usp_Sel_TransaccionTicket As String = "[ReporteVE].[Usp_Sel_Detallado_Por_Ticket]"
    Public Const Usp_Sel_TransaccionTicketCredito As String = "[ReporteVE].[Usp_Sel_Detallado_Por_TicketCredito]"
    Public Const Usp_Sel_TransaccionTicketCreditoZona As String = "[ReporteVE].[Usp_Sel_Detallado_Por_TicketZonaCredito]"
    Public Const Usp_Sel_TransaccionTicketContadoZona As String = "[ReporteVE].[Usp_Sel_Detallado_Por_TicketZonaContado]"
    Public Const Usp_Sel_TransaccionTicketTotalContado As String = "[ReporteVE].[Usp_Sel_Detallado_Por_TicketTotalContado]"
    Public Const Usp_Sel_TransaccionTicketTotalCredito As String = "[ReporteVE].[Usp_Sel_Detallado_Por_TicketTotalCredito]"
    Public Const Usp_Sel_TransaccionTicketTotal As String = "[ReporteVE].[Usp_Sel_Detallado_Por_TicketTotal]"

    Public Const Usp_Sel_TotalTicketContado As String = "[ReporteVE].[Usp_Sel_Total_Por_Ticket_Contado]"
    Public Const Usp_Sel_TotalTicketCredito As String = "[ReporteVE].[Usp_Sel_Total_Por_Ticket_Credito]"




    Public Const Usp_Sel_ComparativoFamiliaPorZona As String = "[ReporteVE].[Usp_Sel_MargenNetoPorZona]"
    Public Const Usp_Sel_ComparativoFamiliaNetoContado As String = "[ReporteVE].[Usp_Sel_MargenNetoContadoPorDia]"

    Public Const Usp_Sel_ComparativoFamiliaPorZonaCredito As String = "[ReporteVE].[Usp_Sel_MargenNetoCreditoPorDia]"

    Public Const Usp_Sel_ComparativoFamiliaNetoCredito As String = "[ReporteVE].[Usp_Sel_MargenNetoCredito]"
    Public Const Usp_Sel_ComparativoTotalDia As String = "[ReporteVE].[Usp_Sel_MargenTotalPorDia]"
    Public Const Usp_Sel_VentaPorFamilia As String = "[ReporteVE].[Usp_Sel_TransaccionPorFamilia]"
    Public Const Usp_Sel_VentaPorFamiliaTicket As String = "[ReporteVE].[Usp_Sel_Detallado_Por_Familia_Ticket]"

    Public Const Usp_Sel_DetalladoPorFamiliaTotalTicket As String = "[ReporteVE].[Usp_Sel_Detallado_Por_Familia_TotalTicket]"

#End Region

#Region "LINEAS DE CREDITO"
    Public Const USP_SEL_LISTACLIENTELINEACREDITO As String = "[Venta].[Usp_Sel_ListaClienteLineaCredito]"
    Public Const USP_SEL_LISTACLIENTELINEACREDITO_NUEVO As String = "[Venta].[Usp_Sel_ListaClienteLineaCredito_Nuevo]"
#End Region

#Region "SP para Clientes"
    'Panocca
    Public Const USP_LIST_TIPOCONTACTO As String = "Cliente.USP_LIST_TIPOCONTACTO"
    Public Const USP_LISTACLASECONTACTO As String = "Cliente.USP_LISTACLASECONTACTO"
    Public Const USP_CONTACTOAGREGAR As String = "Cliente.USP_CONTACTOAGREGAR"
    Public Const USP_CARTERACLIENTE_LISTA As String = "[Cliente].[USP_CARTERA_LIST]"
    Public Const USP_INSERT_CARTERA As String = "[Venta].[USP_INSERT_CARTERA]"
    Public Const USP_LISTACOMBO_EMPLEADOS_BYSUCURSAL As String = "[Cliente].[USP_LISTAVENDEDOR_SUCURSAL]"
    Public Const USP_LISTARGRUPO_CLIENTE As String = "[Cliente].[Usp_Sel_ListaGrupo]"
    Public Const USP_LISTACLIENTES_GRUPO As String = "[Mantenimiento].[USP_SEL_BuscarGrupoClientes]"
    Public Const USP_UDP_IDGRUPOCLIENTES As String = "[Mantenimiento].[Usp_Udp_EstadoGrupoCLiente]"
    Public Const USP_Val_GruporelacionCliente As String = "[Mantenimiento].[Usp_Val_GruporelacionCliente]"
    Public Const USP_SEL_CLIENTESXMODOPAGO As String = "[Cliente].[Usp_Sel_ClientesxModoPago]"
    Public Const USP_SEL_CLIENTESXMODOPAGO_CONSULTAAUTORIZACION As String = "[Cliente].[Usp_Sel_ClientesxModoPago_ConsultaAutorizacion2]"
    Public Const USP_ACTIVARCLIENTE As String = "[Cliente].[Usp_ActivarCliente]"
    'Fin Panocca

    'Agregar fechas cartera compartida
    Public Const USP_FECHASCARTERACOMPARTIDAAGREGAR As String = "[Cliente].[USP_FECHASCARTERACOMPARTIDAAGREGAR]"
    Public Const USP_CARTERACOMPARTIDAFECHAS_LISTA As String = "[Cliente].[USP_CARTERACOMPARTIDAFECHAS_LIST]"
    Public Const USP_SEL_MOTIVO_CLIENTE As String = "Cliente.Usp_Sel_Motivo_Cliente"

#End Region

    Public Const USP_SEL_TIPODOCUMENTOCLIENTE As String = "[cliente].[Usp_Sel_TipoDocumentoCliente]"
    Public Const USP_INS_CLIENTECONTACTO As String = "[Venta].[Usp_Ins_ClienteContacto]"
    Public Const USP_UPD_CLIENTECONTACTO As String = "[Venta].[Usp_Upd_ClienteContacto]"
    Public Const USP_DEL_CLIENTECONTACTO As String = "[Venta].[Usp_Del_ClienteContacto]"
    Public Const USP_SEL_CLIENTECONTACTOID As String = "[Venta].[Usp_Sel_ClienteContactoID]"
    Public Const USP_SEL_CLIENTEMODOPAGO As String = "[Cliente].[Usp_Sel_ClienteModoPago]"
    Public Const USP_SEL_CLIENTETIPO As String = "[Cliente].[Usp_Sel_ClienteTipo]"
    Public Const USP_SEL_CLIENTECONSULTARESTADO As String = "[Cliente].[Usp_Sel_ClienteConsultarEstado]"
    Public Const USP_UPD_ACTUALIZARCARTERA As String = "[Venta].[USP_UPD_ACTUALIZARESTADOCARTERA]"
    Public Const USP_DEL_ACTUALIZAESTADOCARTERA As String = "[Cliente].[Usp_Del_CarteraDesactivada]"
    '"[Venta].[USP_UPD_ACTUALIZARESTADO]"

    Public Const USP_OBT_TRAERRAZONSOCIAL As String = "[Venta].[Usp_Obt_Cliente_razonsocial]"
    Public Const USP_OBTENERFECHAACTIVACION As String = "[Venta].[Usp_Val_FechaActivacion]"
    Public Const USP_VERIFICARCARTERA As String = "[Cliente].[Usp_VerificarCarteraCliente]"
    Public Const USP_VERIFICAREMPLEADOMESON As String = "[Cliente].[Usp_Valida_meson]"
    Public Const USP_VERIFICARTIPOEMPLEADOMESON As String = "[Cliente].[Usp_ValidaTipoEmpleado_meson]"
    Public Const USP_VALIDARCARTERAPRINCIPAL As String = "[Cliente].[Usp_Val_CarteraPrincipal]"
    Public Const USP_VALIDAVENDEDORCARTERA As String = "[Cliente].[Usp_Valida_Vendedor_Cartera]"
    Public Const USP_VALIDAEMPLEADOTIPOCARTERA As String = "[Cliente].[Usp_Valida_TipoCarteraMeson]"
    Public Const USP_EXISTENCIAMESON As String = "[Venta].[Usp_ExistenciaMeson]"

    'Sprint 5 -- Cartera Compartida
    Public Const USP_SEL_AUTOCOMPLETERRVV As String = "[Venta].[Usp_Sel_AutocompleteRRVV]"
    Public Const USP_INS_CARTERA As String = "[Venta].[Usp_Ins_Cartera]"
    Public Const USP_SEL_SUCURSALESDISPONIBLES As String = "[Estructura].[Usp_Sel_SucursalesDisponibles]"
    Public Const USP_SEL_EMPLEADOSDISPONIBLES As String = "[Cliente].[Usp_Sel_EmpleadosDisponibles]"

    Public Const USP_INSERTAR_CLIENTE_HA As String = "[Venta].[Usp_Insertar_Cliente_HA]"
    Public Const USP_SEL_IDEMPLEADOPERFILACTUAL As String = "Estructura.Usp_sel_IdEmpleadoPerfilActual"

    Public Const Usp_Sel_FeriadoPaginacion As String = "[Mantenimiento].[Usp_Sel_FeriadoPaginacion]"
    Public Const Usp_Ins_Feriado As String = "[Mantenimiento].[Usp_Ins_Feriado]"
    Public Const Usp_Sel_Feriado As String = "[Mantenimiento].[Usp_Sel_Feriado]"
    Public Const Usp_Upd_Feriado As String = "[Mantenimiento].[Usp_Upd_Feriado]"
    Public Const Usp_UpdEst_Feriado As String = "[Mantenimiento].[Usp_UpdEst_Feriado]"

#Region "Mantenimientos"

    'AGREGADO POR AA
    Public Const SP_REGISTRAR_CLIENTE_CARTERA As String = "SP_GRABAR_CARGA_MASIVA_CLIENTE_CARTERA"




    Public Const USP_SEL_LISTAMARCAS As String = "[Mantenimiento].[Usp_Sel_ListaMarcas]"

    Public Const USP_SEL_BUSCAPERFILES As String = "[Mantenimiento].[Usp_Sel_BuscaPerfil]"
    Public Const USP_SEL_PERFILCBO As String = "[Mantenimiento].[Usp_Sel_PerfilCBO]"
    Public Const USP_GESTIONAR_PERFIL As String = "[Mantenimiento].[Usp_GestionarPerfil]"
    Public Const USP_DESACTIVAR_PERFIL As String = "[Mantenimiento].[Usp_DesactivarPerfil]"
    Public Const USP_SEL_AUTOCOMPLETEPERFIL As String = "[Mantenimiento].[Usp_Sel_AutocompletePerfil]"

    Public Const USP_SEL_BUSCACARTERACLIENTE As String = "[Mantenimiento].[Usp_Sel_BuscaCarteraCliente]"
    Public Const USP_LISTARREPORTECARTERACLIENTE As String = "[Mantenimiento].[Usp_ListarReporteCarteraCliente]"



    'AGREGADO
    Public Const USP_SEL_EMPLEADOPERFIL As String = "[Estructura].[Usp_Sel_listarComboEmplePerfil]"
    Public Const USP_SEL_PERFIL_PERFILMENOR As String = "[Mantenimiento].[Usp_Sel_Perfil_PerfilMenor]"

    Public Const USP_SEL_BUSCACARGOS As String = "[Mantenimiento].[Usp_Sel_BuscaCargo]"
    Public Const USP_SEL_CARGOBYPERFILCBO As String = "[Mantenimiento].[Usp_Sel_CargoByPerfilCBO]"
    Public Const USP_SEL_ZONACBO As String = "[Mantenimiento].[USP_SEL_ZonaCBO]"
    Public Const USP_SEL_ZONACBOREPORTE As String = "[Mantenimiento].[USP_SEL_ZonaCBO3]"



    'AGREGADO POR JY
    Public Const USP_SEL_ZONACBO2 As String = "[mantenimiento].[USP_SEL_ZonaCBO2]"

    Public Const USP_GESTIONAR_CARGO As String = "[Mantenimiento].[Usp_GestionarCargo]"
    Public Const USP_DESACTIVAR_CARGO As String = "[Mantenimiento].[Usp_DesactivarCargo]"
    Public Const USP_SEL_AUTOCOMPLETECARGO As String = "[Mantenimiento].[Usp_Sel_AutocompleteCargo]"
    Public Const USP_SEL_TIPOPERFIL As String = "[Mantenimiento].[Usp_Sel_TipoPerfil]"
    Public Const USP_SEL_MOSTRARPERFILMENOR As String = "[Mantenimiento].[Usp_Sel_PerfilMenor]"

    Public Const USP_SEL_BUSCAZONAS As String = "[Mantenimiento].[Usp_Sel_BuscaZona]"
    Public Const USP_DESACTIVAR_ZONA As String = "[Mantenimiento].[Usp_DesactivarZona]"
    Public Const USP_SEL_AUTOCOMPLETEZONA As String = "[Mantenimiento].[Usp_Sel_AutocompleteZona]"
    Public Const USP_SEL_LISTASUCURSALES_MULTISELECT As String = "[Mantenimiento].[Usp_Sel_ListaSucursales]"
    Public Const USP_GESTIONAR_ZONA As String = "[Mantenimiento].[Usp_GestionarZona]"
    Public Const USP_SEL_LISTASUCURSALES_SELECCIONADAS As String = "[Mantenimiento].[Usp_Sel_ListaSucursales_Seleccionadas]"
    Public Const USP_SEL_ESTADO_ZONA As String = "[Mantenimiento].[Usp_Sel_Estado_Seleccionado]"

    Public Const USP_SEL_BUSCARSUCURSALES As String = "[Mantenimiento].[USP_SEL_SUCURSAL]"
    Public Const USP_SEL_AUTOCOMPLETESUCURSAL As String = "[Estructura].[Usp_Sel_AutocompleteSucursal]"
    Public Const USP_GESTIONAR_SUCURSAL As String = "[Estructura].[Usp_GestionarSucursal]"
    Public Const USP_DESACTIVAR_SUCURSAL As String = "[Estructura].[Usp_DesactivarSucursal]"

    Public Const USP_VENDEDORCARGO As String = "[Mantenimiento].[Usp_Obtener_NombreVendedor]"

    Public Const USP_SEL_BUSCAGRUPO As String = "[Mantenimiento].[USP_SEL_BuscarGrupo]"
    Public Const USO_SEL_AUTOCOMPLETEGRUPO As String = "[Mantenimiento].[Usp_Sel_AutocompleteGrupo]"
    Public Const USP_SEL_LISTACLIENTES_MULTISELECT As String = "[Mantenimiento].[Usp_Sel_ListaClientes]"
    Public Const USP_GESTIONAR_GRUPO As String = "[Mantenimiento].[Usp_GestionarGrupo]"
    Public Const USP_SEL_LISTACLIENTES_SELECCIONADOS As String = "[Mantenimiento].[Usp_Sel_ListaClientes_Seleccionados]"
    Public Const USP_DESACTIVAR_GRUPO As String = "[Mantenimiento].[Usp_DesactivarGrupo]"
    Public Const USP_LISTACLIENTE_GRUPO As String = "[Mantenimiento].[USP_SEL_BuscarGrupoClientes]"


    'RELEASE 2 *********************************************************************************************************************************************************
    Public Const USP_SEL_LISTACARGOS_TABS As String = "[Comision].[Usp_Sel_ListaCargos_Tabs]"
    Public Const USP_SEL_COMISIONESCALA As String = "[Comision].[Usp_Sel_ComisionEscala]"

    Public Const Usp_Ins_Proveedor As String = "[Mantenimiento].[Usp_Ins_Proveedor]"
    Public Const Usp_Sel_Proveedor As String = "[Mantenimiento].[Usp_Sel_Proveedor]"
    Public Const Usp_Sel_ProveedorPaginacion As String = "[Mantenimiento].[Usp_Sel_ProveedorPaginacion]"
    Public Const Usp_Upd_Proveedor As String = "[Mantenimiento].[Usp_Upd_Proveedor]"
    Public Const Usp_UpdEst_Proveedor As String = "[Mantenimiento].[Usp_UpdEst_Proveedor]"

    Public Const Usp_Sel_ProductoPaginacion As String = "[Mantenimiento].[Usp_Sel_ProveedorSkuPaginacion]"
    Public Const Usp_UpdEst_ProveedorSku As String = "[Mantenimiento].[Usp_UpdEst_ProveedorSku]"
    Public Const Usp_Sel_ProductoSeleccionar As String = "[Mantenimiento].[Usp_Sel_ProductoSeleccionar]"
    Public Const Usp_Ins_ProveedorSku As String = "[Mantenimiento].[Usp_Ins_ProveedorSku]"


    'COTIZACIONES ******************************************************************************************************************************************************
    Public Const USP_SEL_FAMILIACBO As String = "[Venta].[Usp_Sel_FamiliaCbo]"
    Public Const USP_SEL_BUSCADESCUENTOFAMILIA As String = "[Venta].[Usp_Sel_BuscaDescuentoFamilia]"
    Public Const USP_DESACTIVAR_DESCUENTOFAMILIA As String = "[Venta].[Usp_DesactivarDescuentoFamilia]"
    Public Const USP_GESTIONAR_DESCUENTOFAMILIA As String = "[Venta].[Usp_GestionarDescuentoFamilia]"

    Public Const USP_SEL_BUSCADESCUENTOSKU As String = "[Venta].[Usp_Sel_BuscaDescuentoSku]"
    Public Const USP_DESACTIVAR_DESCUENTOSKU As String = "[Venta].[Usp_DesactivarDescuentoSku]"
    Public Const USP_GESTIONAR_DESCUENTOSKU As String = "[Venta].[Usp_GestionarDescuentoSku]"

    Public Const USP_VALIDA_EXISTESKU As String = "[Venta].[Usp_ValidaExisteSku]"

    Public Const USP_SEL_MARCACBO As String = "[Venta].[Usp_Sel_MarcaCbo]"
    Public Const USP_SEL_EMPLEADOXPERFILCBO As String = "[Estructura].[Usp_Sel_EmpleadoxPerfilCbo]"
    Public Const USP_SEL_BUSCACOTIZACION As String = "[Venta].[Usp_Sel_BuscaCotizacion]"
    Public Const USP_GESTIONAR_COTIZACION As String = "[Venta].[Usp_GestionarCotizacion]"
    Public Const USP_SEL_BUSCADETALLECOTIZACION As String = "[Venta].[Usp_Sel_BuscaDetalleCotizacion]"

    Public Const USP_SEL_LISTASUCURSALES_XMARCA As String = "[Mantenimiento].[Usp_Sel_ListaSucursales_xMarca]"

    Public Const USP_SEL_REPORTECOTIZACION As String = "[Venta].[Usp_Sel_ReporteCotizacion]"

    Public Const USP_SEL_BUSCASKUBLOQUEADOS As String = "[Venta].[Usp_Sel_BuscaSkuBloqueados]"
    Public Const USP_DESACTIVAR_SKUBLOQUEADO As String = "[Venta].[Usp_DesactivarSkuBloqueado]"
    Public Const USP_GESTIONAR_SKUBLOQUEADO As String = "[Venta].[Usp_GestionarSkuBloqueado]"

    'PLAN POR TIPO REPRESENTANTE VENTA - SOD13068
    Public Const Usp_ListarMesPlan As String = "[Mantenimiento].[Usp_ListarMesPlan_N13068]"
    Public Const Usp_ListarTipoRepresentanteVenta As String = "[Mantenimiento].[Usp_ListarTipoRepresentanteVenta_N13068]"
    Public Const Usp_ListarPlanTipoRepresentanteVenta As String = "[Mantenimiento].[Usp_ListarPlanTipoRepresentanteVenta_N13068]"
    Public Const Usp_ObtenerPlanTipoRepresentanteVenta As String = "[Mantenimiento].[Usp_ObtenerPlanTipoRepresentanteVenta_N13068]"
    Public Const Usp_GestionarPlanTipoRepresentanteVenta As String = "[Mantenimiento].[Usp_GestionarPlanTipoRepresentanteVenta_N13068]"
    Public Const Usp_EliminarPlanTipoRepresentanteVenta As String = "[Mantenimiento].[Usp_EliminarPlanTipoRepresentanteVenta_N13068]"

#End Region

#Region "Plan Venta"
    Public Const USP_INS_COMISIONESCALA As String = "[Comision].[Usp_Ins_ComisionEscala]"
    Public Const USP_INS_COMISIONESCALADETALLE As String = "[Comision].[Usp_Ins_ComisionEscalaDetalle]"
    Public Const USP_INS_COMISIONESCALATIEMPOSERVICIO As String = "[Comision].[Usp_Ins_ComisionEscalaTiempoServicio]"
    Public Const USP_DLT_COMISIONESCALADETALLE As String = "[Comision].[Usp_Dlt_ComisionEscalaDetalle]"
#End Region

#Region "Reasignacion"
    Public Const USP_SEL_LISTAZONAS As String = "[Mantenimiento].[USP_SEL_ZonaCBO]"
    Public Const USP_SEL_LISTASUCURSALPORZONA As String = "[Estructura].[Usp_sel_Zonas_Sucursales]"
    Public Const USP_SEL_LISTARSUCURSAL As String = "[Estructura].[Usp_Sel_ListarSucursales]"
    Public Const USP_SEL_LISTAEMPLEADOSPORSUCURSAL As String = "[Estructura].[Usp_Sel_ListarEmpleadoPorSucursal]"
    Public Const USP_SEL_LISTAEMPLEADOSPORSUCURSALFILTROIDVENDEDOR As String = "[Estructura].[Usp_Sel_ListarEmpleadoPorSucursalFiltroIdVendedor]"
    Public Const USP_SEL_LISTAUSUARIOSPOREMPLEADOSINACTIVOS As String = "[Venta].[Usp_Sel_ListarClientePorEmpleadoInactivo]"
    Public Const USP_SEL_LISTAUSUARIOSPOREMPLEADOSACTIVOS As String = "[Venta].[Usp_Sel_ListarClientesPorEmpleadoActivos]"

    Public Const USP_INS_CARTERACLIENTEVENDEDOR As String = "[Venta].[Usp_Ins_CarteraClienteVendedor]"
    Public Const USP_UPD_CARTERACLIENTEVENDEDOR As String = "[Venta].[Usp_Udp_VentaCarteraporVendedor]"


#End Region

#Region "Cargas Manuales"
    'Carlos Ubillus
    Public Const USP_BUSCARCLIENTERUC As String = "[Venta].[Usp_BuscarClienteRuc]"
    Public Const USP_BUSCARPRODUCTOSKU As String = "[Venta].[Usp_BuscarProductoSku]"
    Public Const USP_LISTARCARGAMANUALHISTORICA = "[Venta].[Usp_ListarCargaManualHistorica]"
    Public Const USP_GUARDARFACTURASEXCEL As String = "[SSIS].[Usp_GuardarFacturasExcel]"
    Public Const USP_GUARDARFACTURASEXCELDETALLE As String = "[SSIS].[Usp_GuardarFacturasExcelDetalle]"
    Public Const USP_GUARDARNOTACREDITOEXCEL As String = "[SSIS].[Usp_GuardarNotaCreditoExcel]"
    Public Const USP_GUARDARNOTACREDITOEXCELDETALLE As String = "[SSIS].[Usp_GuardarNotaCreditoExcelDetalle]"
    Public Const USP_ACTUALIZAVENTACOMISION As String = "[Venta].[Usp_ActualizaVentaComision]"
    Public Const USP_TRUNCARTABLAFACTURASNOTACREDITO As String = "[SSIS].[Usp_TruncarTablaFacturasNotaCredito]"
    Public Const USP_INS_CARGAMANUAL As String = "[Venta].[Usp_Ins_CargaManual]"

    'Luis Peralta
    Public Const USP_INS_VENTACABECERA As String = "[Venta].[Usp_Ins_VentaCabecera]"
    Public Const USP_INS_VENTADETALLE As String = "[Venta].[Usp_Ins_VentaDetalle]"
    Public Const USP_LISTAPARAMETROSCARGA As String = "[Configuracion].[Usp_ListaParametrosCarga]"
    Public Const USP_INS_VENTA As String = "[Venta].[Usp_Ins_Venta]"
    Public Const USP_LISTARCARGASMANUALES As String = "[Venta].[Usp_ListarCargasManuales]"
    Public Const USP_DEL_ELIMINARCARGARMANUAL As String = "[Venta].[Usp_Del_CargaManual]"
    Public Const USP_DEL_QUITARHISTORIALCARGA As String = "[Venta].[Usp_Del_QuitarCargaManual]"
    Public Const USP_ACTUALIZAVENTACOMISIONMANUAL As String = "[Venta].[Usp_ActualizaVentaComisionManual]"
    Public Const USP_OBTENERFECHAS As String = "[Venta].[Usp_ObtenerFechas]"
    Public Const USP_SEL_VENTAPORIDCARGA As String = "[Venta].[Usp_Sel_VentaporIdCarga]"
    Public Const USP_BUSCARMONEDA As String = "[Venta].[Usp_BuscarMoneda]"
    Public Const USP_LISTARDOCUMENTOTIPO As String = "[Venta].[Usp_ListarDocumentoTipo]"
    Public Const USP_LISTARSUCURSAL As String = "[Venta].[Usp_ListarSucursal]"
    Public Const USP_LISTARVENTAS As String = "[Venta].[Usp_ListarVentas]"
    Public Const USP_LISTASKU As String = "[Venta].[Usp_ListaSKU]"
    Public Const USP_LISTAMONEDA As String = "[Venta].[Usp_ListaMoneda]"
    Public Const USP_LISTACLIENTE As String = "[Venta].[Usp_ListaCliente]"
    Public Const USP_INS_VENTA_DETALLE As String = "[Venta].[Usp_Ins_Venta_Detalle]"
    Public Const USP_INS_VENTA_VENTA As String = "[Venta].[Usp_Ins_Venta_Venta]"
    Public Const USP_OBTENERRESULTADOREPROCESO As String = "[Venta].[Usp_ObtenerResultadoReproceso]"

#End Region


#Region "Empleado"
    Public Const USP_VALIDARUSUARIOUSU_EEMPLEADO As String = "[Estructura].[Usp_ValidarUsuarioUsu_EEmpleado]"
#End Region


#Region "Cierre Mes"

    Public Const USP_CIERREMES_REPORTE_GUIA As String = "Usp_CierreMes_Reporte_Guia"
    Public Const USP_CIERREMES_REPORTE_VENTAS As String = "Usp_CierreMes_Reporte_Ventas"
    Public Const USP_CIERREMES_REPORTE_COMISIONES As String = "Usp_CierreMes_Reporte_Comisiones"
    Public Const USP_CIERREMES_REPORTE_RRVV As String = "Usp_CierreMes_Reporte_RRVV"
    Public Const USP_CIERREMES_REPORTE_JEFE_VENTAS As String = "Usp_CierreMes_Reporte_Jefe_Ventas"
    Public Const USP_CIERREMES_REPORTE_HISTORIALCLIENTE As String = "Usp_CierreMes_Reporte_HistorialCliente"
    Public Const USP_CIERREMES_REPORTE_COMISIONESDETALLADO As String = "Usp_CierreMes_Reporte_ComisionesDetallado"


#End Region

#Region "Mantenimiento Cierre"
    Public Const Usp_Registrar_Cierre As String = "Mantenimiento.Usp_Registrar_FehaCierre"
    Public Const Usp_Buscar_CierrePaginacion As String = "Mantenimiento.Usp_Buscar_CierrePaginacion"
    Public Const Usp_Eliminar_Cierre As String = "Mantenimiento.Usp_Eliminar_Cierre"
#End Region

#Region "Venta Empresa Tienda"
    Public Const Usp_VentaEmpresaTienda As String = "VENTA.USP_REPORTEVENTAEMPRESA_TIENDA"
#End Region

    Public Const USP_SEL_VENTAEMPRESA_CLIENTE As String = "[Venta].[USP_REPORTEVENTAEMPRESA_CLIENTE]"

#Region "CARGA MASIVA CLIENTE"
    Public Const USP_LISTA_TABLA_GENERAL As String = "USP_LISTA_TABLA_GENERAL"
    Public Const USP_LISTA_CLIENTE_CATEGORIA As String = "USP_LISTA_CLIENTE_CATEGORIA"
    Public Const USP_LISTA_DEPARTAMENTO As String = "USP_LISTA_DEPARTAMENTO"
    Public Const USP_LISTA_DISTRITO As String = "USP_LISTA_DISTRITO"
    Public Const USP_LISTA_GRUPO As String = "USP_LISTA_GRUPO"
    Public Const USP_LISTA_PROVINCIA As String = "USP_LISTA_PROVINCIA"
    Public Const USP_LISTA_SECTOR As String = "USP_LISTA_SECTOR"
    Public Const USP_LISTA_TIPO As String = "USP_LISTA_TIPO"
    Public Const USP_LISTA_EMPLEADO As String = "USP_LISTA_EMPLEADO"
    Public Const USP_LISTA_EMPLEADO_SECUNDARIO As String = "USP_LISTA_EMPLEADO_SECUNDARIO"
    Public Const USP_LISTASUCURSAL As String = "USP_LISTASUCURSAL"
    Public Const USP_LISTA_CLIENTE_EMPLEADO As String = "USP_LISTA_CLIENTE_EMPLEADO"
    Public Const USP_LISTA_CLIENTE_CONTACTO As String = "USP_LISTA_CLIENTE_CONTACTO"
    Public Const SP_REGISTRAR_CLIENTE As String = "SP_GRABAR_CARGA_MASIVA_CLIENTE_EMPLEADO"
    Public Const SP_DESACTIVAR_CLIENTE As String = "SP_DESACTIVAR_CLIENTE_CARGA_MASIVA"
    Public Const USP_LISTA_TIPO_DOCUMENTO As String = "USP_LISTA_TIPO_DOCUMENTO"
    Public Const USPLSISTARUC As String = "usp_listar_Cliente_Ruc"


#End Region

    Public Const Usp_Clientes_Vendedores_Asociados As String = "[SSIS].[Usp_Consulta_Clientes_Vendedores_Asociados_Paginado]"

#Region "Carga Masiva Empleado"

    Public Const USP_SEL_CONSULTAR_SUCURSAL As String = "[Estructura].[usps_ConsultarSucursal_Empleado]"
    Public Const USP_SEL_CONSULTAR_PERFIL As String = "[Mantenimiento].[usps_ConsultarPerfil_Empleado]"
    Public Const USP_INSERT_EMPLEADO_MASIVO As String = "[uspi_Registrar_empleado]"
    Public Const USP_DELETE_EMPLEADO_MASIVO As String = "[uspd_Eliminar_empleado]"
    Public Const USP_SEL_LISTARREPROCESO_BOLETA As String = "Venta.Usp_VentaBoletaDetalle_Consultar"


    Public Const USP_INSERT_BOLETAS_REPORCESAR As String = "usp_Registra_BoletasReprocesar"

    Public Const USP_DELTETE_BOLETAS_REPORCESAR As String = "usp_Eliminar_BoletasReprocesar"
    Public Const USP_LISTAR_ZONA_NOMBRE As String = "usp_listar_Zona_Nombre"

#End Region

    Public Const UspReporteCarteraCliente As String = "[ReporteVE].[Usp_ReporteCarteraCliente2]"

#Region "Reporte Usuarios"
    Public Const Usp_ListarReporteUsuario As String = "[Seguridad].[Usp_ListarReporteUsuario]"
#End Region

#Region "Reporte Roles y Páginas"
    Public Const Usp_ListarReporteRolPagina As String = "[Seguridad].[Usp_ListarReporteRolPagina]"
#End Region

End Class
