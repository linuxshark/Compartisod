Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Reflection

Public Class VentasBusinessLogic
    Private Log As Log = Nothing
    Private SiLog As Boolean = False

    Public Sub New(Optional ByVal oSiLog As Boolean = False, Optional ByVal oLog As Log = Nothing)
        If (oSiLog) Then
            Me.Log = oLog
            Me.SiLog = oSiLog
        End If
    End Sub

    Function ListaSucursal() As ListaSucursal
        Dim oSucursal As New VentasDataAccess
        Return oSucursal.ListaSucursal()
    End Function

    'Function ListaZonas(ByVal idcargos As Integer) As ListaZona
    '    Dim oZonas As New VentasDataAccess
    '    Return oZonas.ListarCargos_Zonas(idcargos)
    'End Function
    Public Function BuscarVendedorPorFiltros(ByRef oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New VentasDataAccess().BuscarVendedorPorFiltros(oPaginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
        End Using
        Return oPaginacion
    End Function

    Public Function BuscarVendedor(ByRef oPaginacion As Paginacion) As Paginacion
        Return New VentasDataAccess().BuscarVendedor(oPaginacion)
    End Function

    Function ListaZonaMantenimiento2(Usuario As String, FechaIni As String, FechaFin As String) As ListaZonaMantenimiento
        Return New MantenimientoDataAccess().ListaZonaMantenimiento2(Usuario, FechaIni, FechaFin)
    End Function

    Function ObtenerSucursalPorIdEmpleados(ByRef oPaginacion As Paginacion) As Paginacion
        Return New VentasDataAccess().ObtenerSucursalPorIdEmpleados(oPaginacion)
    End Function
    Function BuscarSucursalPersonal(ByRef oPaginacion As Paginacion) As Paginacion
        Return New VentasDataAccess().ObtenerSucursalPorIdEmpleados(oPaginacion)
    End Function

    Public Function ObtenerPlanVentaPorIdEmpleado(ByRef oPaginacion As Paginacion) As Paginacion
        Return New VentasDataAccess().ObtenerPlanVentaPorIdEmpleado(oPaginacion)
    End Function
    Function ObtenerTiempoServicioEmpleado(IdEmpleado As Integer) As Integer
        Return New VentasDataAccess().ObtenerTiempoServicioEmpleado(IdEmpleado)
    End Function

    Function Selecion_PerfilNombre(idperfil As Integer) As String
        Return New VentasDataAccess().Selecion_PerfilNombre(idperfil)
    End Function

    Function ListaRepresentantesVenta() As ListaComisionRepresentantesVenta
        Dim oComisionRepresentanteVenta As New VentasDataAccess()
        Return oComisionRepresentanteVenta.ListaRepresentantesVenta
    End Function

    Function ListaVentaNombreRepresentante() As ListaVentaNombreRepresentante
        Dim oVentaNombreRepresentante As New VentasDataAccess()
        Return oVentaNombreRepresentante.ListaVentaNombreRepresentante
    End Function

    Function ListaEmpleadoCargo() As ListaEmpleadoCargo
        Dim oEmpleadoCargo As New VentasDataAccess
        Return oEmpleadoCargo.ListaEmpleadoCargo
    End Function

    Function CargarPerfiles() As ListaPerfil
        Dim oPerfil As New VentasDataAccess
        Return oPerfil.CargarPerfiles
    End Function

    Function ListaEmpleadoPerfil() As ListaEmpleadoPerfil
        Dim oEmpleadoPerfil As New VentasDataAccess
        Return oEmpleadoPerfil.ListaPerfil
    End Function
    Function CargarListaCargoxPerfil(IdPerfil As Integer) As ListaCargo
        Dim oVentasData As New VentasDataAccess
        Return oVentasData.CargarListaCargoxPerfil(IdPerfil)
    End Function

    Function ListaClienteSector() As ListaClienteSector
        Dim oClienteSector As New VentasDataAccess
        Return oClienteSector.ListaClienteSector()
    End Function

    'Function CargarEstado() As ListaProcesoEstado
    Function CargarEstado() As ListaEstado
        Dim oVentasData As New VentasDataAccess
        Return oVentasData.CargarEstado()
    End Function

    Function RegistrarEmpleado(ventaEmpleado As Empleado) As Integer
        Dim result As Integer = 0

        For Each item As PropertyInfo In ventaEmpleado.GetType().GetProperties()
            If item.GetValue(ventaEmpleado, Nothing) Is Nothing Then
                If item.PropertyType.Name = "String" Then
                    ventaEmpleado.GetType().GetProperty(item.Name.ToString()).SetValue(ventaEmpleado, "", Nothing)
                End If
            End If
        Next

        Dim oVentasDataAccess As VentasDataAccess = New VentasDataAccess

        Try
            Using scope As New TransactionScope()
                result = oVentasDataAccess.RegistrarEmpleado(ventaEmpleado)
                If (SiLog) Then
                    Dim LogDA As New LogDataAccess
                    Log.IdLogAccion = IIf(ventaEmpleado.IdEmpleado = 0, 1, 2)
                    LogDA.Actualizar_Log(Log)
                End If
                scope.Complete()
            End Using
        Catch ex As Exception
            result = -1
        End Try

        Return result
    End Function
    Function ListaZonas() As ListaZona
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ListaZonas()
    End Function

    Function ListaSucursales() As ListaSucursal
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ListaSucursal()
    End Function

    Function ObtenerEmpleadoPorId(IdEmpleado As Integer, tipoperfil As Integer) As Empleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerEmpleadoPorId(IdEmpleado, tipoperfil)
    End Function
    Function ObtenerPerfilEmpleado(IdEmpleado As Integer, TipoPerfil As Integer) As Empleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerPerfilEmpleado(IdEmpleado, TipoPerfil)
    End Function

    Function ObtenerSucursalEmpleadoPorId(IdEmpleado As Integer) As SucursalEmpleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerSucursalEmpleadoPorId(IdEmpleado)
    End Function

    Function ObtenerSucursalEmpleadoPorIdV2(IdEmpleado As Integer) As SucursalEmpleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerSucursalEmpleadoPorIdV2(IdEmpleado)
    End Function

    'Function ObtenerSucursalPorIdEmpleado(IdEmpleado As Integer) As List(Of SucursalEmpleado)
    '    'Dim oVentasDataAccess As New VentasDataAccess
    '    'Return oVentasDataAccess.ObtenerSucursalPorIdEmpleado(IdEmpleado)
    'End Function

    Function RegistrarSucursalEmpleado(sucursalEmpleado As Empleado) As String
        Using scope As New TransactionScope()
            Dim Valor As Integer = New VentasDataAccess().RegistrarSucursalEmpleado(sucursalEmpleado)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function
    Function RegistrarPlanVentasEmpleado(planventaEmpleado As Empleado) As String
        Using scope As New TransactionScope()
            Dim Valor As Integer = New VentasDataAccess().RegistrarPlanVentasEmpleado(planventaEmpleado)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function
    Function ObtenerEscalasPeriodo(ByVal idempleado As Integer) As ListaPlanVentaEmpleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerEscalasPeriodo(idempleado)
    End Function

    Function DesactivarEmpleado(IdEmpleado As Integer) As Integer
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.DesactivarEmpleado(IdEmpleado)
    End Function
    Function DesactivarEmpleadoporEstado(IdEmpleado As Integer, IdEstado As Integer, Usuario As String, Origen As String) As Integer
        Using scope As New TransactionScope()
            Dim oVentasDataAccess As New VentasDataAccess()
            Dim Valor = oVentasDataAccess.DesactivarEmpleadoporEstado(IdEmpleado, IdEstado, Usuario, Origen)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function ObtenerTiempoServicio() As Integer
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerTiempoServicio()
    End Function

    Public Function ListarCargosPorPerfil(ByRef IdEmpleadoPerfil As Integer) As ListaEmpleadoCargo
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ListarCargosPorPerfil(IdEmpleadoPerfil)
    End Function

    Public Function Seleccion_tipoPerfilCargo(idcargos As Integer) As Integer
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.Seleccion_tipoPerfilCargo(idcargos)
    End Function

    Function ObtenerTipoPerfilVendedor(IdPerfil As Integer, IdZona As Integer) As Integer
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerTipoPerfilVendedor(IdPerfil, IdZona)
    End Function

    Public Function CargarEscalasComisionTiempoServicio(IdPerfil As Integer, IdZona As Integer) As ListaComisionEscala
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.CargarEscalasComisionTiempoServicio(IdPerfil, IdZona)
    End Function

    Function ValidarEmpleadoCartera(ByVal idempleado As Integer) As Integer
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ValidarEmpleadoCartera(idempleado)
    End Function
    Function ValidaEmpleadoActivoCartera(ByVal IdEmpleado As Integer) As Integer
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ValidaEmpleadoActivoCartera(IdEmpleado)
    End Function

    Function ObtenerNombreCargoVendedor(IdPerfil As Integer, IdZona As Integer) As String
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerNombreCargoVendedor(IdPerfil, IdZona)
    End Function

    Function ObtenerNombreCargoSuperior(IdPerfil As Integer, IdZona As Integer) As String
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerNombreCargoSuperior(IdPerfil, IdZona)
    End Function

    Function ObtenerTiempoServicioPeriodo(ByVal IdEmpleado As Integer) As ListaPlanVentaEmpleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerTiempoServicioPeriodo(IdEmpleado)
    End Function

    Function ObtenerTiempoServicioporEmpleado(ByVal IdEmpleado As Integer) As ListaPlanVentaEmpleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerTiempoServicioporEmpleado(IdEmpleado)
    End Function
    Function ObtenerMesesComisonalesFaltantes() As ListaComisionPeriodoDetalle
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerMesesComisonalesFaltantes()
    End Function


    Function ObtenerNombreEmpleado(IdEmpleado As Integer) As String
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerNombreEmpleado(IdEmpleado)
    End Function

    Function ObtenerDatosEmpleado(IdEmpleado As Integer) As Empleado
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.ObtenerDatosEmpleado(IdEmpleado)
    End Function

    Function InsertaVentasporConsulta(IdZona As Integer, IdSucursal As String, FechaInicio As String, FechaFin As String) As Integer
        Dim resultado As Integer = 1
        Dim oVentasDataAccess As New VentasDataAccess
        Dim oprogramarjob As New ProgramarJob
        'Dim IdSucursales_Array() As String
        'IdSucursales_Array = Split(IdSucursal, ",")
        'For i As Integer = 0 To IdSucursales_Array.Length - 1

        'Next
        ' Using oTransactionScope As New TransactionScope()
        Using scope As New TransactionScope()
            Dim Valor = New VentasDataAccess().InsertaVentasporConsulta(IdZona, IdSucursal, FechaInicio, FechaFin)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
        '  For Each item As ProgramarJob In
        'resultado = oVentasDataAccess.ConsultarJob(oprogramarjob)
        '  oTransactionScope.Complete()
        '  End Using

        Return resultado
    End Function

    Function ListaSucursale_Grilla(ByVal paginacion As Paginacion) As Paginacion
        Return New VentasDataAccess().Sucursales_PV_Grilla(paginacion)
    End Function

    Function CargarTipoRepresentanteVenta(idPerfil As Integer) As ListaTipoRepresentanteVenta
        Dim oVentasDataAccess As New VentasDataAccess
        Return oVentasDataAccess.CargarTipoRepresentanteVenta(idPerfil)
    End Function
End Class
