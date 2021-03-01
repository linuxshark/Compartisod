Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts

Public Class ComunBusinessLogic
    Function ConsultarDepartamento() As ListaEmpleadoDepartamento
        Return New ComunDataAccess().ConsultarDepartamento()
    End Function
    Public Function ConsultarCargosSupervisor(idcargos As Integer) As ListaCargo
        Return New ComunDataAccess().ListarSupervisorCargos(idcargos)
    End Function
    Public Function ConsultartipoPerfilCargo(idcargos As Integer) As Integer
        Return New ComunDataAccess().Seleccion_tipoPerfilCargo(idcargos)
    End Function
    Public Function ConsultarZonasCargos(Idcargo As Integer) As ListaZona
        Return New ComunDataAccess().ListarCargos_Zonas(Idcargo)
    End Function
    Public Function ConsultarSucursalCargos(idcargos As Integer) As ListaSucursal
        Return New ComunDataAccess().ListaCargos_Sucursales(idcargos)
    End Function
    Public Function ListaZonas_Sucursales(ByVal idzona As Integer) As ListaSucursal
        Return New ComunDataAccess().ListaZonas_Sucursales(idzona)
    End Function
    Public Function CargarEscalas_Tiempo_Servicio(ByVal idcargos As Integer) As ListaComisionEscalaDetalle
        Return New ComunDataAccess().CargarEscalas_Tiempo_Servicio(idcargos)
    End Function
    Public Function CargarEscalasComision_Tiempo_Servicios(ByVal idcargos As Integer) As ListaComisionEscala
        Return New ComunDataAccess().CargarEscalasComision_Tiempo_Servicios(idcargos)
    End Function
    Public Function CargarEscalas_Tiempo_Servicios(ByVal idcargos As Integer) As ListaComisionEscalaTiempoServicio
        Return New ComunDataAccess().CargarEscalas_Tiempo_Servicios(idcargos)
    End Function

    Function ConsultarProvinciaDepartamento(IdDepartamento As Integer) As ListaEmpleadoProvincia
        Return New ComunDataAccess().ConsultarProvinciaDepartamento(IdDepartamento)
    End Function

    Function ConsultarDistritoProvincia(IdProvincia As Integer) As ListaEmpleadoDistrito
        Return New ComunDataAccess().ConsultarDistritoProvincia(IdProvincia)
    End Function

    'Function ConsultarModoPago(IdModoPago As Integer) As ListaClienteVenta
    '    Return New ComunDataAccess().ConsultarModoPago(IdModoPago)
    'End Function

    Function ListaEstado(IdObjeto As Integer) As ListaProcesoEstado
        Return New ComunDataAccess().ListaEstado(IdObjeto)

    End Function
End Class
