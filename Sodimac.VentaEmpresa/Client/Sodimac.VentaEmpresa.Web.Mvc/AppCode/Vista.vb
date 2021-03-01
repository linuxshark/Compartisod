Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Diagnostics.CodeAnalysis
Public Class ParametrosView
    Public Class ParametrosPartialView

#Region "Nombre Vistas Cliente"
        Public Const Datos_Cliente_Ruta_Tab As String = "~/Views/Cliente/Cliente_PVCliente.vbhtml"
        Public Const Personal_Contacto_Cliente_Ruta_Tab As String = "~/Views/Cliente/Cliente_PVPersonal.vbhtml"
        Public Const Historial_Credito_Cliente_Ruta_Tab As String = "~/Views/Cliente/Cliente_PVHistorial.vbhtml"
        Public Const Representante_Ventas_Cliente_Ruta_Tab As String = "~/Views/Cliente/Cliente_PVRepresentante.vbhtml"
        Public Const Archivos_Cliente_Ruta_Tab As String = "~/Views/Cliente/Cliente_PVArchivo.vbhtml"
        Public Const UCCLiente_Provincia_Combo As String = "~/Views/Cliente/UCCliente_Provincia_Combo.vbhtml"
        Public Const UCCLiente_Distrito_Combo As String = "~/Views/Cliente/UCCliente_Distrito_Combo.vbhtml"
        Public Const Colsultar_Cliente_Adjunto_Grilla As String = "~/Views/Cliente/ConsultarClienteAdjunto_PVGrilla.vbhtml"
        Public Const ListarSucursales_Grilla As String = "~/Views/Cliente/Sucursales_PV_Grilla.vbhtml"
        Public Const ListarSucursales_ComboBox As String = "~/Views/Cliente/ComboSucursal.vbhtml"
        Public Const ComboEmpleados_PV As String = "~/Views/Cliente/ComboEmpleados_PV.vbhtml"
        Public Const CarteraCliente_TAB As String = "~/Views/Cliente/CarteraClientes.vbhtml"
        Public Const CarteraCompartida_TAB As String = "~/Views/Cliente/CarteraCompartidaFechas.vbhtml"
        Public Const Empleado_Sucursales_PV As String = "~/Views/Ventas/Sucursal.vbhtml"
        Public Const Empleado_DatosContacto_PV As String = "~/Views/Ventas/DatosContacto.vbhtml"

        'agregar ultimo
        Public Const Empleado_PlanVentas As String = "~/Views/Ventas/PlanVentas.vbhtml"
        Public Const Empleado_Cargo As String = "~/Views/Ventas/UCEmpleado_Cargo.vbhtml"
        Public Const UCSucursal_cargos As String = "~/Views/Ventas/UCSucursal__Combo.vbhtml"
        Public Const Empleado_Supervisor As String = "~/Views/Ventas/PVSuperior_Cargo.vbhtml"
        Public Const PVSucursal_Zona As String = "~/Views/Ventas/PVSucursal_Combo.vbhtml"
        Public Const PVEscalaTiempoServicio As String = "~/Views/Ventas/PVEscalaTiempoServicio_Combo.vbhtml"
        Public Const PVCargo_porPerfil As String = "~/Views/Ventas/PVCargo_Combo.vbhtml"
        Public Const PVHistorialPlanVentas As String = "~/Views/Ventas/Planventa.vbhtml"
        Public Const PVPerfil_comboCargo As String = "~/Views/Ventas/PVPerfil_ComboCargo.vbhtml"

        'partial view para fecha de activacion
        Public Const PVFechaActivaporEmpleado As String = "~/Views/Cliente/PVFechaActivacionporEmpleado.vbhtml"

        'Public Const PVHistorialPlanVentas As String = "~/Views/Ventas/PlanVentasEmpleado.vbhtml"
        Public Const PVSucursal_ZonaReasignar As String = "~/Views/Cliente/PVSucursalporZona.vbhtml"
        Public Const PVSucursalporZonaReasignarActiva As String = "~/Views/Cliente/PVSucursalporZonaActiva.vbhtml"
        Public Const PVVendedor_Sucursal As String = "~/Views/Cliente/PVVendedorPorSucursal.vbhtml"
        Public Const PVVendedor_SucursalActivos As String = "~/Views/Cliente/PVVendedorPorSucursalActivos.vbhtml"
        Public Const PVCliente_Vendedor As String = "~/Views/Cliente/VistaClienteporVendedor.vbhtml"
        Public Const PVCliente_VendedorActivo As String = "~/Views/Cliente/VistaClienteporVendedorActivos.vbhtml"

        'Sprint 5
        Public Const PVCliente_NuevaCarteraporTipo As String = "~/Views/Cliente/CargarVistaCartera.vbhtml"
        Public Const PV_SucursalesDisponibles As String = "~/Views/Cliente/ListaSucursalesDisponibles.vbhtml"

#End Region

#Region "Nombre Vistas Coimisión"
        Public Const Comision_GestionarPeriodoComisionBonosRRVV As String = "~/Views/Comision/_GestionarPeriodoComisionBonosRRVV.vbhtml"
        Public Const Comision_GestionarPeriodoComisionBonosJefatura As String = "~/Views/Comision/_GestionarPeriodoComisionBonosJefatura.vbhtml"
        Public Const Comision_BuscarEscalaComision As String = "~/Views/Comision/_BuscarEscalaComision.vbhtml"
        Public Const Comision_ListaEscalaComisionTiempoServicio As String = "~/Views/Comision/_ListaEscalaComisionTiempoServicio.vbhtml"
        Public Const Comision_GestionarPlanVentasRRVV As String = "~/Views/Comision/_GestionarPlanVentasRRVV.vbhtml"
        Public Const Comision_Listar_Periodos As String = "~/Views/Comision/Listar_Periodos.vbhtml"
        Public Const _BuscarMesesComisionales As String = "~/Views/Comision/_BuscarMesesComisionales.vbhtml"
        Public Const _ListaAdjuntoComisionales As String = "~/Views/Comision/ListarAdjuntoComisional.vbhtml"
#End Region

#Region "Mantenimiento Panocca"
        Public Const ConsultarPerfil_PVGrilla As String = "~/Views/Mantenimiento/ConsultarPerfil_PVGrilla.vbhtml"
        Public Const GestionarPerfil As String = "~/Views/Mantenimiento/GestionarPerfil.vbhtml"

        Public Const ConsultarCargo_PVGrilla As String = "~/Views/Mantenimiento/ConsultarCargo_PVGrilla.vbhtml"
        Public Const GestionarCargo As String = "~/Views/Mantenimiento/GestionarCargo.vbhtml"
        Public Const ListaCargo_ByPerfil As String = "~/Views/Mantenimiento/ListaCargo_ByPerfil.vbhtml"

        'prueba
        Public Const ConsultarZona_PVGrilla As String = "~/Views/Mantenimiento/ConsultarZona_PVGrilla.vbhtml"

        'Grupo
        Public Const ConsultarGrupo_PVGrilla As String = "~/Views/Mantenimiento/ConsultarGrupo_PVGrilla.vbhtml"
        Public Const PVClientesGrupos As String = "~/Views/Mantenimiento/PVListaClientes_Grupo.vbhtml"
        Public Const PVListaClientes As String = "~/Views/Mantenimiento/PVListaClientes.vbhtml"

#End Region


#Region "Mantenimiento Cartera Clientes"

        Public Const ConsultarCarteraCliente_PVGrilla As String = "~/Views/Mantenimiento/ConsultarCarteraCliente_PVGrilla.vbhtml"

#End Region

#Region "Mantenimiento Ricardo"
        Public Const ConsultarSucursal_PVGrilla As String = "~/Views/Mantenimiento/ConsultarSucursales_PVGrilla.vbhtml"
        Public Const PVSucursal_Provincia_Dep As String = "~/Views/Mantenimiento/PVSucursal_Provincia_Combo.vbhtml"
        Public Const PVSucursal_Distrito_Combo As String = "~/Views/Mantenimiento/PVSucursal_Distrito_Combo.vbhtml"

        Public Const PVZona_Combo As String = "~/Views/Mantenimiento/PVZona_Combo.vbhtml"

        Public Const AgregarPlanVentaEmpleado As String = "~/Views/Ventas/GestionarPlanVentaEmpleado.vbhtml"
        Public Const ListarPlanVentasEmpleados_PVGrilla As String = "~/Views/Ventas/ListarPlanVentaEmpleado.vbhtml"

        Public Const AgregarSucursalEmpleado As String = "~/Views/Ventas/CargoFechaActivacion.vbhtml"
        Public Const ListarSucursalEmpelado_PVGrilla As String = "~/Views/Ventas/RegistrarSucursalEmpleado.vbhtml"

#End Region

#Region "Vistas Reportes"
        Public Const ReporteClientesHistorial As String = "~/Views/Reportes/VerReporteClientesHistorial.vbhtml"
        Public Const ReporteLog As String = "~/Views/Reportes/VerReporteLog.vbhtml"
        Public Const PVSucursal_By_Zona As String = "~/Views/Reportes/_ComboSucursal.vbhtml"
        Public Const PVZona As String = "~/Views/Reportes/_ComboZona.vbhtml"
        Public Const PVClienteEstadoLinea As String = "~/Views/Reportes/_ComboEstadoLinea.vbhtml"
        Public Const PVVendedorPrincipal As String = "~/Views/Reportes/_ComboVendedor.vbhtml"
        Public Const PartialZona As String = "~/Views/Reportes/_ComboMultiZona.vbhtml"
        Public Const PartialRRVV As String = "~/Views/Reportes/_ComboRRVV.vbhtml"
        Public Const PartialJefeRegional As String = "~/Views/Reportes/_ComboJefeRegional.vbhtml"
        Public Const PartialSucursal As String = "~/Views/Reportes/_ComboMultiSucursal.vbhtml"
        Public Const PartialSucursalVVEE As String = "~/Views/Reportes/_ComboMultiSucursalVVEE.vbhtml"
        Public Const PartialMargenFierro As String = "~/Views/Reportes/VerReporteMargenFierro.vbhtml"

        'Vistas Reporte Avance Venta
        Public Const PartialSucursalAv As String = "~/Views/ReporteAvanceVentas/_ComboMultiSucursal.vbhtml"
        Public Const PartialJefeVenta As String = "~/Views/ReporteAvanceVentas/_ComboMultiJefeVenta.vbhtml"
        Public Const PartialVendedor As String = "~/Views/ReporteAvanceVentas/_ComboMultiRRVV.vbhtml"
#End Region

#Region "Vista Autorizaciones"
        Public Const BuscarContado As String = "~/Views/Autorizacion/BuscarContado.vbhtml"
        Public Const BuscarContado2 As String = "~/Views/Autorizacion/BuscarContado2.vbhtml"
        Public Const BuscarCredito As String = "~/Views/Autorizacion/BuscarCredito.vbhtml"
        Public Const BuscarCredito2 As String = "~/Views/Autorizacion/BuscarCredito2.vbhtml"
#End Region

#Region "Vista Configuracion"
        Public Const BuscarParametroNegocio As String = "~/Views/Configuracion/BuscarParametroNegocio.vbhtml"
        Public Const BuscarParametroSistema As String = "~/Views/Configuracion/BuscarParametroSistema.vbhtml"
        Public Const BuscarParametroSeguridad As String = "~/Views/Configuracion/BuscarParametroSeguridad.vbhtml"
#End Region

#Region "Proceso Carga Manual"

        Public Const PV_Historial As String = "~/Views/Proceso/PV_Historial.vbhtml"
        Public Const PV_Grilla As String = "~/Views/Proceso/PV_Grilla.vbhtml"

#End Region

#Region "Mantenimiento Cotizacion"
        Public Const ConsultarDsctoFamilia_PVGrilla As String = "~/Views/Mantenimiento/ConsultarDsctoFamilia_PVGrilla.vbhtml"
        Public Const ConsultarDsctoSku_PVGrilla As String = "~/Views/Mantenimiento/ConsultarDsctoSku_PVGrilla.vbhtml"
        Public Const ConsultarCotizacion_PVGrilla As String = "~/Views/Mantenimiento/ConsultarCotizacion_PVGrilla.vbhtml"
        Public Const ConsultarSkuBloqueados_PVGrilla As String = "~/Views/Mantenimiento/ConsultarSkuBloqueados_PVGrilla.vbhtml"
#End Region

#Region "Mantenimiento Empleado"
        Public Const TipoRepresentanteVentaPV As String = "~/Views/Ventas/_TipoRepresentanteVenta.vbhtml"
        Public Const TipoRepresentanteVentaEmpleadoPV As String = "~/Views/Ventas/_TipoRepresentanteVentaEmpleado.vbhtml"
#End Region

#Region "Mantenimiento Plan Ventas - SOD13068"

        Public Const ConsultarPlanTipoRepresentanteVenta_PVGrilla As String = "~/Views/Mantenimiento/ConsultarPlanTipoRepresentanteVenta_PVGrilla.vbhtml"

#End Region

    End Class

    Public Class Parametros

        '/********************************************************\
        'PARAMETROS PARA ESTADO - ESTADO DEL CLIENTE
        '********************************************************/
        Public Const CLIENTE_ESTADO_CODIGO_ACTIVO As String = "ACTIVO"
        Public Const CLIENTE_ESTADO_CODIGO_INACTIVO As String = "INACTIVO"
        Public Const CLIENTE_ESTADO_ID_ACTIVO As Integer = 8
        Public Const CLIENTE_ESTADO_ID_INACTIVO As Integer = 9
        Public Const CLIENTE_ACTIVO As Integer = 1
        Public Const CLIENTE_INACTIVO As Integer = 0
        'PARAMETROS PARA ESTADO DE VENDEDOR
        Public Const VENDEDOR_ESTADO_CODIGO_ACTIVO As String = "REGISTRADO"
        Public Const VENDEDOR_ESTADO_CODIGO_INACTIVO As String = "INACTIVO"
        Public Const VENDEDOR_ESTADO_ID_ACTIVO As Integer = 26
        Public Const VENDEDOR_ESTADO_ID_INACTIVO As Integer = 27

        ' para desactivar 
        Public Const CARTERA_ESTADO_CODIGO_ACTIVO As Boolean = True
        Public Const CARTERA_ESTADO_CODIGO_INACTIVO As Boolean = False
        Public Const CARTERA_ESTADO_ID_ACTIVO As Integer = 1
        Public Const CARTERA_ESTADO_ID_INACTIVO As Integer = 0


        Public Const EMPLEADO_ESTA_ACTIVO As Boolean = True
        Public Const EMPLEADO_ESTA_INACTIVO As Boolean = False
        Public Const EMPLEADO_ESTADO_ACTIVO As Integer = 1
        Public Const EMPLEADO_ESTADO_INACTIVO As Integer = 0


        'TIPO DE CARTERA
        Public Const CARTERA_ESTADO1 As Integer = 0
        Public Const CARTERA_ESTADO2 As Integer = 1
        Public Const RETORNACARTERA_ESTADO1 As Integer = 2
        Public Const RETORNACARTERA_ESTADO2 As Integer = 1

        'Sprint 6
        Public Const MES_COMISIONAL_ABIERTO As Integer = 30
        Public Const MES_COMISIONAL_PROCESADO As Integer = 31
        Public Const MES_COMISIONAL_CERRADO As Integer = 32


    End Class

End Class
