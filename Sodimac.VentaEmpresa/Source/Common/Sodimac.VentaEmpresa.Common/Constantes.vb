Public Class Constantes
    Public Const ValorDefecto As String = ""
    Public Const FechaDefecto As String = "10-10-1900"
    Public Const ValorDefectoCero As String = "0"
    Public Const ValorDefectoUno As String = "1"
    Public Const ValorDefectoMenosUno As String = "-1"
    Public Const Menosseis As Integer = -6
    Public Const Menoscinco As Integer = -5
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
    Public Const ValorDoce As Integer = 12
    Public Const ValorCatorce As Integer = 14
    Public Const ValorQuince As Integer = 15
    Public Const RegistrosPorPagina As Integer = 10
    Public Const RegistrosPorPaginaLogError As Integer = 15
    Public Const Ruc As String = "20389230724"
    Public Const Dia As String = "00"
    Public Const CodigoOportunidad As String = "00"
    Public Const IndicadorOperaciones As String = "1"
    Public Const ListaInformacion As String = "1"
    Public Const ListaSinInformacion As String = "0"
    Public Const Soles As String = "1"
    Public Const Dolares As String = "2"
    Public Const Indicador As String = "1"
    Public Const msjGrabarError As String = "Ocurrió un error durante el registro."
    Public Const msjGrabarSucursalExiste As String = "El cliente ya tiene asociado un RRVV en la sucursal seleccionada."
    Public Const msjActualizarError As String = "Ocurrió un error durante la actualización."
    Public Const msjSessionExpiro As String = "Su sesión a finalizado por favor vuelva iniciar sesión para continuar."
    Public Const msjGrabar As String = "Se registró correctamente"
    Public Const msjActualizar As String = "Se actualizó correctamente"
    Public Const msjAprobar As String = "Se aprobó correctamente"
    Public Const msjGrabarMenosUno As String = "No puede programar un nuevo proceso. Mientras esté en un estado programado"
    Public Const msjeExsiste As String = "Para aperturar un nuevo periodo. Cierre el periodo anterior"
    Public Const msjArchivo As String = "Otro usuario esta generando el archivo PLE"
    Public Const msjenegativo As String = "El Periodo no se puede cerrar"
    Public Const msjGrabarPerfil As String = "Roles asignados correctamente"
    Public Const msjGrabarPerfilError As String = "Se ha producido una excepción"
    Public Const msjPrincipalRepetido As String = "Ya existe un empleado principal asociado"
    Public Const msjErrorCartera As String = "Las sucursales seleccionadas ya tienen un empleado asociado"
    Public Const msjSucursalRepetida As String = "Se agregó correctamente a las sucursales que NO tenían un empleado asociado"
    Public Const msjContactoPrincipalRepetido As String = "Ya existe un contacto principal para este cliente"
    Public Const msjFechaCarteraCompartidaRepetido As String = "Ya existe un registro con las fechas ingresadas"
    Public Const msjContactoNombreRepetido As String = "Ya existe un contacto con ese nombre para este Cliente"
    Public Const FirstPage As Integer = 1
    Public Const RowsPerPage As Integer = 10
    Public Const RowsPerPage2 As Integer = 3
    Public Const Clear As String = ""
    Public Const LessOne As Integer = -1
    Public Const Activo As String = "Activo"
    Public Const One As Integer = 1
    Public Const Zero As Integer = 0
    Public Const Inactivo As String = "Inactivo"
    Public Const ValorFalso As String = "False"


    Public Const MensajeClienteError As String = "Sucedió un error al grabar cliente."
    Public Const MensajeClienteSucursal As String = "No puede registrar a un cliente en una misma sucursal."
    Public Const MensajeClienteGrabar As String = "Se grabó correctamente."
    Public Const MensajeClienteActualizar As String = "Se actualizó correctamente."


    Public Const MensajeClienteEliminarError As String = "Sucedió un error al eliminar cliente."
    Public Const MensajeClienteEliminarGrabar As String = "Se eliminó correctamente."

    Public Const MensajeClienteEstadoActivo As String = "Se activó el cliente correctamente."
    Public Const MensajeClienteEstadoInActivo As String = "Se desactivó el cliente correctamente."

    Public Const MensajeClienteAdjuntoError As String = "Sucedió un error al grabar el archivo del cliente."
    Public Const MensajeClienteAdjuntoGrabar As String = "Se grabó correctamente el archivo de cliente."
    Public Const MensajeClienteAdjuntoSizeError As String = "El archivo excede los 10Mb."
    Public Const ID_OBJETO_ESTADO_CLIENTE As Integer = 4

    Public Const EstadoClienteActivoContacto As Integer = 1
    Public Const EstadoClienteInactivoContacto As Integer = 2

    Public Const MensajeClienteContactoError As String = "Sucedió un error al grabar contacto."
    Public Const MensajeClienteContactoGrabar As String = "Se grabó correctamente el contacto."
    Public Const MensajeClienteContactoActualizar As String = "Se actualizó correctamente el contacto."

#Region "PARÁMETROS DE CONFIGURACIÓN"
    Public Const CLIENTE_TIPO_ARCHIVO As String = "CLIENTE_TIPO_ARCHIVO"
    Public Const CLIENTE_TAMANIO_ARCHIVO As String = "CLIENTE_TAMANIO_ARCHIVO"
#End Region

#Region "Estados del Periodo de Comisión"
    Public Const ID_ESTADO_PERIODOCOMISION_REGISTRADO As Integer = 12
    Public Const ID_ESTADO_PERIODOCOMISION_APROBADO As Integer = 14
    Public Const ID_ESTADO_PERIODOCOMISION_ENPROCESO As Integer = 17
    Public Const ID_ESTADO_PERIODOCOMISION_PROCESADO As Integer = 18
#End Region

#Region "Modos de Pago del Cliente"
    Public Const ID_MODOPAGO_CREDITO As Integer = 1
    Public Const ID_MODOPAGO_CONTADO As Integer = 2
#End Region

#Region "Mensajes para Reasignación de Clientes"



#End Region

#Region "Constantes de Tipos de Escala"
    Public Const TIPOESCALA_PRINCIPAL_ID As Integer = 1
    Public Const TIPOESCALA_SECUNDARIA_ID As Integer = 2
#End Region

#Region "Proceso Carga Manual"

    Public Const EstadoCargaActivo As Integer = 28
    Public Const EstadoCargaInactivo As Integer = 29

#End Region

#Region "Tipos de Documento"

    Public Const IdTpoDocFA As Integer = 1
    Public Const IdTpoDocNC As Integer = 2
    Public Const IdTpoDocND As Integer = 3
    Public Const IdTpoDocGD As Integer = 4

#End Region

#Region "Constates de Log Accion"
    Public Const Insertar As Integer = 1
    Public Const Modificar As Integer = 2
    Public Const Eliminar As Integer = 3
    Public Const Exportar As Integer = 4
    Public Const Buscar As Integer = 5
    Public Const Aprobar As Integer = 6
    Public Const Activar As Integer = 7
    Public Const Desactivar As Integer = 8
    Public Const Reasignacion As Integer = 9
    Public Const Reproceso As Integer = 10
    Public Const VerReporte As Integer = 11
    Public Const Asociar As Integer = 12
    Public Const Asignar As Integer = 13
    Public Const Visualizar As Integer = 14
    Public Const CerrarMes As Integer = 15
#End Region

#Region "Constates de Origen Accion"
    Public Const Comision_Periodo As Integer = 1
    Public Const Estructura_Empleado As Integer = 2
    Public Const Estructura_SucursalEmpleado As Integer = 3
    Public Const Estructura_PlanVentaEmpleado As Integer = 4
    Public Const Venta_Cliente As Integer = 5
    Public Const Venta_ClienteContacto As Integer = 6
    Public Const Venta_Cartera As Integer = 7
    Public Const Venta_ClienteAdjunto As Integer = 8
    Public Const Mantenimiento_Perfil As Integer = 9
    Public Const Mantenimiento_Cargo As Integer = 10
    Public Const Mantenimiento_Zonas As Integer = 11
    Public Const Mantenimiento_Grupos As Integer = 12
    Public Const Venta_HistorialReprocesoVenta As Integer = 13
    Public Const Reporte_Guias As Integer = 14
    Public Const Reporte_Ventas As Integer = 15
    Public Const Reporte_Comisiones As Integer = 16
    Public Const Reporte_Tiendas As Integer = 17
    Public Const Reporte_RepresentanteVenta As Integer = 18
    Public Const Reporte_JefeVentas As Integer = 19
    Public Const Reporte_Clientes As Integer = 20
    Public Const Reporte_ClientesHistorial As Integer = 21
    Public Const Reporte_Log As Integer = 22
    Public Const Seguridad_Rol As Integer = 23
    Public Const Seguridad_Perfil As Integer = 24
    Public Const Seguridad_Permisos As Integer = 25
    Public Const Seguridad_Usuario As Integer = 26
    Public Const Venta_Reproceso As Integer = 27
    Public Const Venta_CargaManual As Integer = 28
    Public Const Reporte_EstadoCuenta As Integer = 29
    Public Const Reporte_VentaEmpresa As Integer = 30
    Public Const Reporte_MargenFierro As Integer = 33
    Public Const Mantenimiento_Proveedor As Integer = 34
    Public Const Mantinimiento_CalendarioFeriados As Integer = 35
    Public Const Mantenimiento_CalendarioCierre As Integer = 36
    Public Const Mantenimiento_Cotizacion As Integer = 37
    Public Const Mantenimiento_PlanTipoRepresentanteVenta As Integer = 38
#End Region


#Region "Constantes Estado Mes Comisional"

    Public Const ID_ESTADO_MES_COMISIONAL_ABIERTO As Integer = 30
    Public Const ID_ESTADO_MES_COMISIONAL_PROCESADO As Integer = 31
    Public Const ID_ESTADO_MES_COMISIONAL_CERRADO As Integer = 32

#End Region

#Region "Tipos de Documentos Cliente"
    Public Const ID_TIPODOCUMENTOCLIENTE_RUC As Integer = 1
    Public Const ID_TIPODOCUMENTOCLIENTE_DNI As Integer = 2
#End Region
End Class
