'Imports Sodimac.VentaEmpresa.Web.Mvc.Sodimac.VentaEmpresa.Web.Mvc.ServicioComun
Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataContracts
Public Class ServicioComunController

    'Public Shared Function ListarTablaGeneral(idTabGru As Integer, descripcionLargaTabGen As [String]) As ListaTablaGeneral
    '    Using oServicioComunSoapClient As New ServicioComunSoapClient()
    '        Return oServicioComunSoapClient.ListarTablaGeneral(idTabGru, descripcionLargaTabGen)
    '    End Using
    'End Function

    Public Shared Function ConsultarDepartamento() As ListaEmpleadoDepartamento
        Return New ComunBusinessLogic().ConsultarDepartamento()
    End Function
    Public Shared Function ConsultarCargosSuperv(Idcargos As Integer) As ListaCargo
        Return New ComunBusinessLogic().ConsultarCargosSupervisor(Idcargos)
    End Function
    Public Shared Function ConsultartipoPerfilCargo(Idcargos As Integer) As Integer
        Return New ComunBusinessLogic().ConsultartipoPerfilCargo(Idcargos)
    End Function

    Public Shared Function ConsultarZonasCargos(Idcargo As Integer) As ListaZona
        Return New ComunBusinessLogic().ConsultarZonasCargos(Idcargo)
    End Function
    Public Shared Function ConsultarSucursalCargos(idcargos As Integer) As ListaSucursal
        Return New ComunBusinessLogic().ConsultarSucursalCargos(idcargos)
    End Function
    Public Shared Function ConsultarZonas_Sucursales(ByVal idzona As Integer) As ListaSucursal
        Return New ComunBusinessLogic().ListaZonas_Sucursales(idzona)
    End Function
    Public Shared Function CargarEscalas_Tiempo_Servicio(ByVal idcargos As Integer) As ListaComisionEscalaDetalle
        Return New ComunBusinessLogic().CargarEscalas_Tiempo_Servicio(idcargos)
    End Function
    Public Shared Function CargarEscalasComision_Tiempo_Servicios(ByVal idcargos As Integer) As ListaComisionEscala
        Return New ComunBusinessLogic().CargarEscalasComision_Tiempo_Servicios(idcargos)
    End Function
    Public Shared Function CargarEscalas_Tiempo_Servicios(ByVal idcargos As Integer) As ListaComisionEscalaTiempoServicio
        Return New ComunBusinessLogic().CargarEscalas_Tiempo_Servicios(idcargos)
    End Function

    Public Shared Function ConsultarProvinciaDepartamento(IdDepartamento As Integer) As ListaEmpleadoProvincia
        Return New ComunBusinessLogic().ConsultarProvinciaDepartamento(IdDepartamento)
    End Function

    Public Shared Function ConsultarDistritoProvincia(IdProvincia As Integer) As ListaEmpleadoDistrito
        Return New ComunBusinessLogic().ConsultarDistritoProvincia(IdProvincia)
    End Function

    Public Shared Function ConsultarEstado(IdObjeto As Integer) As ListaProcesoEstado

        Return New ComunBusinessLogic().ListaEstado(IdObjeto)
    End Function

    Public Shared Function ObtenerParametroPorCodigoParametro(ByVal CodigoParametro As String) As Parametro
        Return New ConfiguracionBusinessLogic().ObtenerParametroPorCodigoParametro(CodigoParametro)
    End Function


End Class
