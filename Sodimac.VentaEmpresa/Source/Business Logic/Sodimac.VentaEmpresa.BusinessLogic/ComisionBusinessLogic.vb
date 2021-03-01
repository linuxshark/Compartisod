Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Threading.Tasks

Public Class ComisionBusinessLogic
    Private Log As Log = Nothing
    Private SiLog As Boolean = False

    Public Sub New(Optional ByVal oSiLog As Boolean = False, Optional ByVal oLog As Log = Nothing)
        If (oSiLog) Then
            Me.Log = oLog
            Me.SiLog = oSiLog
        End If
    End Sub

    Function ObtenerPeriodo(ByVal oPaginacion As Paginacion) As Paginacion
        Try
            Using scope As New TransactionScope()
                Dim oComisionDataAccess As ComisionDataAccess = New ComisionDataAccess()
                oPaginacion = oComisionDataAccess.ListaComisionPeriodo(oPaginacion)
                If (SiLog) Then
                    Dim LogDA As New LogDataAccess
                    LogDA.Actualizar_Log(Log)
                End If
                scope.Complete()
            End Using
        Catch ex As Exception
            oPaginacion.ErrorLog = New ErrorLog()
            oPaginacion.ErrorLog.ErrorMessage = ex.Message
            oPaginacion.ErrorLog.ErrorStackTrace = ex.StackTrace
        End Try


        Return oPaginacion

    End Function


    Function ListaNombrePeriodo() As ListaNombrePeriodo
        Dim oNombreComisionPeriodo As New ComisionDataAccess()
        Return oNombreComisionPeriodo.ListaNombrePeriodo()
    End Function

    Public Function InsertarPeriodoComision(ByVal pComisionPeriodo As ComisionPeriodo, ByRef IdPeriodo As Integer)
        Using scope As New TransactionScope()
            Dim Valor As Integer = New ComisionDataAccess().RegistrarPeriodoComision(pComisionPeriodo, IdPeriodo)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ListaCargo() As ListaEmpleadoCargo
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.ListaCargo()
    End Function

    Public Function ListaPerfil() As ListaEmpleadoPerfil
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.ListaPerfil()
    End Function

    Public Function ListaTiempoServicio(IdComisionEscala As Integer) As ListaComisionEscala
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.ListaTiempoServicio(IdComisionEscala)
    End Function

    Public Function ListaPeriodoCbo() As ListaComisionPeriodo
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.ListaPeriodoCbo()
    End Function

    Public Function ListaComisionEscala_PorIdPeriodo(ByVal IdPeriodo As Integer) As ListaComisionEscala
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.ListaComisionEscala_PorIdPeriodo(IdPeriodo)
    End Function

    Public Function ListaComisionPeriodoDetalle_PorIdPeriodo(ByVal IdPeriodo As Integer) As ListaComisionPeriodoDetalle
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.ListaComisionPeriodoDetalle_PorIdPeriodo(IdPeriodo)
    End Function

    Public Function CabeceraComisionEscala(ByVal IdComisionEscala As Integer) As ComisionEscala
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.CabeceraComisionEscala(IdComisionEscala)
    End Function

    Function CabeceraPeriodoComision(ByVal IdPeriodo As Integer) As ComisionPeriodo
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.CabeceraPeriodoComision(IdPeriodo)
    End Function

    Function ListaComisionEscalaDetalle(ByVal IdEscalaComision As Integer) As ListaComisionEscalaDetalle
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.ListaComisionEscalaDetalle(IdEscalaComision)
    End Function

    Function RegistrarEscalaComision(ByVal oListaComisionEscalaDetalle As List(Of ComisionEscalaDetalle)) As Integer
        Dim oComisionDataAccess As New ComisionDataAccess()
        Return oComisionDataAccess.RegistrarEscalaComision(oListaComisionEscalaDetalle)
    End Function

    Public Function InsertaDatosPeriodo(ByVal pComisionPeriodo As ComisionPeriodo, ByRef IdPeriodo As Integer) As Integer
        Return New ComisionDataAccess().RegistrarPeriodoComision(pComisionPeriodo, IdPeriodo)
    End Function

    Function ObtenerPeriodoPorId(ByVal IdPeriodo As Integer) As ComisionPeriodo
        Return New ComisionDataAccess().ObtenerPeriodoPorId(IdPeriodo)
    End Function

    Function AprobarPeriodoComision(ByVal IdPeriodo As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor As Integer = New ComisionDataAccess().AprobarPeriodoComision(IdPeriodo)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function ListarTabsJefes(IdPeriodo As Integer) As ListaPlanVenta
        Return New ComisionDataAccess().ListarTabsJefes(IdPeriodo)
    End Function

    Function Registrar_PlanVentaJefe(ByVal oPlanVenta As PlanVenta) As Integer
        Dim result As Integer
        'Inicio Cabecera JEFE'
        oPlanVenta.ComisionEscala.Perfil = New Perfil()
        oPlanVenta.ComisionEscala.Perfil = oPlanVenta.Cargo.PerfilSuperior
        oPlanVenta.ComisionEscala.Cargo = New Cargo()
        oPlanVenta.ComisionEscala.Cargo.IdCargo = oPlanVenta.Cargo.IdCargoSuperior
        Dim IdComisionEscalaJefe_ As Integer
        result = New ComisionDataAccess().Registrar_ComisionEscala(oPlanVenta.ComisionEscala, IdComisionEscalaJefe_)

        'Guarda la tabla de las escalas de comision del jefe
        For Each oComisionEscalaDetalle As ComisionEscalaDetalle In oPlanVenta.ListaComisionEscalaDetalleJefe
            oComisionEscalaDetalle.ComisionEscala = oPlanVenta.ComisionEscala
            oComisionEscalaDetalle.ComisionEscala.IdComisionEscala = IdComisionEscalaJefe_
            oComisionEscalaDetalle.IdComisionEscalaTipo = Sodimac.VentaEmpresa.Common.Constantes.TIPOESCALA_PRINCIPAL_ID
            result = New ComisionDataAccess().Registrar_ComisionEscalaDetalle(oComisionEscalaDetalle)
        Next
        result = Sodimac.VentaEmpresa.Common.Constantes.ValorUno
        Return result
    End Function

    Function Registrar_PlanVentaRRVV(ByVal oPlanVenta As PlanVenta) As Integer
        Dim result As Integer
        Dim PlanVenta_ As Integer = oPlanVenta.ComisionEscalaRRVV.PlanVenta
        'Inicio Cabecera RRVV
        oPlanVenta.ComisionEscalaRRVV.Perfil = New Perfil()
        oPlanVenta.ComisionEscalaRRVV.Perfil = oPlanVenta.Cargo.Perfil
        oPlanVenta.ComisionEscalaRRVV.Cargo = New Cargo()
        oPlanVenta.ComisionEscalaRRVV.Cargo.IdCargo = oPlanVenta.Cargo.IdCargo

        oPlanVenta.ComisionEscalaRRVV.PlanVentaFactorFechaInicio = DateTime.Parse(Sodimac.VentaEmpresa.Common.Constantes.FechaDefecto)
        oPlanVenta.ComisionEscalaRRVV.PlanVentaFactorFechaFin = DateTime.Parse(Sodimac.VentaEmpresa.Common.Constantes.FechaDefecto)
        Dim IdComisionEscalaRRVV_ As Integer
        result = New ComisionDataAccess().Registrar_ComisionEscala(oPlanVenta.ComisionEscalaRRVV, IdComisionEscalaRRVV_)

        oPlanVenta.ComisionEscalaRRVV.ComisionPeriodo = oPlanVenta.ComisionEscala.ComisionPeriodo
        'Ahora va a grabar varias veces dependiendo del Tiempo de Servicio
        For i = 0 To oPlanVenta.ComisionEscalaRRVV.TiempoServicio
            Dim oComisionEscalaTiempoServicio As New ComisionEscalaTiempoServicio
            oComisionEscalaTiempoServicio.Perfil = oPlanVenta.ComisionEscalaRRVV.Perfil
            oComisionEscalaTiempoServicio.Cargo = oPlanVenta.ComisionEscalaRRVV.Cargo
            oComisionEscalaTiempoServicio.TiempoServicio = i
            oComisionEscalaTiempoServicio.Activo = True
            oComisionEscalaTiempoServicio.ComisionPeriodo = oPlanVenta.ComisionEscalaRRVV.ComisionPeriodo
            oComisionEscalaTiempoServicio.PlanVenta = oPlanVenta.ListaComisionEscalaTiempoServicio(i).PlanVenta
            oComisionEscalaTiempoServicio.PorcInicial = oPlanVenta.ListaComisionEscalaTiempoServicio(i).PorcInicial
            oComisionEscalaTiempoServicio.PorcFinal = oPlanVenta.ListaComisionEscalaTiempoServicio(i).PorcFinal
            oComisionEscalaTiempoServicio.BonoMin = oPlanVenta.ListaComisionEscalaTiempoServicio(i).BonoMin
            oComisionEscalaTiempoServicio.BonoMax = oPlanVenta.ListaComisionEscalaTiempoServicio(i).BonoMax

            Dim IdComisionEscalaTiempoServicio = New ComisionDataAccess().Registrar_ComisionEscalaTiempoServicio(oComisionEscalaTiempoServicio)

            For Each oComisionEscalaDetalle As ComisionEscalaDetalle In oPlanVenta.ListaComisionEscalaTiempoServicio(i).ListaComisionEscalaDetalleRRVV
                oComisionEscalaDetalle.ComisionEscala = oPlanVenta.ComisionEscalaRRVV
                oComisionEscalaDetalle.ComisionEscala.IdComisionEscala = IdComisionEscalaTiempoServicio
                oComisionEscalaDetalle.IdComisionEscalaTipo = Sodimac.VentaEmpresa.Common.Constantes.TIPOESCALA_SECUNDARIA_ID
                result = New ComisionDataAccess().Registrar_ComisionEscalaDetalle(oComisionEscalaDetalle)
            Next
        Next

        result = Sodimac.VentaEmpresa.Common.Constantes.ValorUno
        Return result
    End Function

    Function ListaComisionEscalaTiempoServicio(IdPeriodo As Integer) As ListaComisionEscalaTiempoServicio
        Return New ComisionDataAccess().ListaComisionEscalaTiempoServicio(IdPeriodo)
    End Function

    Function ObtenerComisionEscala(IdPeriodo As Integer, IdCargo As Integer) As ComisionEscala
        Return New ComisionDataAccess().ObtenerComisionEscala(IdPeriodo, IdCargo)
    End Function

    Function ListarComisionEscalaDetalleJefe(IdPeriodo As Integer, IdCargoSuperior As Integer) As ListaComisionEscalaDetalle
        Return New ComisionDataAccess().ListarComisionEscalaDetalleJefe(IdPeriodo, IdCargoSuperior)
    End Function

    Function ListarComisionEscalaTiempoServicio(IdPeriodo As Integer, IdCargoRRVV As Integer) As ListaComisionEscalaTiempoServicio
        Return New ComisionDataAccess().ListarComisionEscalaTiempoServicio(IdPeriodo, IdCargoRRVV)
    End Function

    Function ListarComisionEscalaDetalleRRVV(IdComisionTiempoServicio As Integer) As DataContracts.ListaComisionEscalaDetalle
        Return New ComisionDataAccess().ListarComisionEscalaDetalleRRVV(IdComisionTiempoServicio)
    End Function

    Function DesactivarEstadoPeriodoComision(IdPeriodo As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor As Integer = New ComisionDataAccess().DesactivarEstadoPeriodoComision(IdPeriodo)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function ListarMesesComisionales2(IdNombreMesComisional As String, IdEstado As Integer, FechaIni As String, FechaFin As String, IdPeriodo As Integer, oPaginacion As Paginacion) As ListaComisionPeriodoDetalle
        Return New ComisionDataAccess().ListarMesesComisionales(IdNombreMesComisional, IdEstado, FechaIni, FechaFin, IdPeriodo, oPaginacion)
    End Function

    Function ListarMesesComisionales(IdNombreMesComisional As String, IdEstado As Integer, FechaIni As String, FechaFin As String, IdPeriodo As Integer, oPaginacion As Paginacion) As ListaComisionPeriodoDetalle
        Using scope As New TransactionScope()
            Dim LogDA As New LogDataAccess
            Dim OComisionDataAccess As ComisionDataAccess
            Dim oListaComisionPeriosoDetalle As ListaComisionPeriodoDetalle

            oListaComisionPeriosoDetalle = New ListaComisionPeriodoDetalle()
            OComisionDataAccess = New ComisionDataAccess()
            oListaComisionPeriosoDetalle = OComisionDataAccess.ListarMesesComisionales(IdNombreMesComisional, IdEstado, FechaIni, FechaFin, IdPeriodo, oPaginacion)

            LogDA.Actualizar_Log(Log)
            scope.Complete()
            Return oListaComisionPeriosoDetalle
        End Using
    End Function

    Function CerrarMesComisional(IdPeriodoDetalle As Integer) As Integer
        Dim resultado As Integer
        Try
            'Using scope As New TransactionScope()
            resultado = New ComisionDataAccess().CerrarMesComisional(IdPeriodoDetalle)
            Dim resultado1 As Integer

            If resultado = 1 Then

                Parallel.Invoke(Sub()
                                    resultado1 = New ComisionDataAccess().CierreMesReporteGuia(IdPeriodoDetalle)
                                End Sub,
                          Sub()
                              resultado1 = New ComisionDataAccess().CierreMesReporteVentas(IdPeriodoDetalle)
                          End Sub,
                          Sub()
                              resultado1 = New ComisionDataAccess().CierreMesReporteComision(IdPeriodoDetalle)
                          End Sub,
                          Sub()
                              resultado1 = New ComisionDataAccess().CierreMesReporteVendedor(IdPeriodoDetalle)
                          End Sub,
                          Sub()
                              resultado1 = New ComisionDataAccess().CierreMesReporteJefeVentas(IdPeriodoDetalle)
                          End Sub,
                          Sub()
                              resultado1 = New ComisionDataAccess().CierreMesReporteHistorialCliente(IdPeriodoDetalle)
                          End Sub,
                          Sub()
                              resultado1 = New ComisionDataAccess().CierreMesReporteComisionDetalle(IdPeriodoDetalle)
                          End Sub)

            End If

          


            If resultado = Constantes.ValorUno Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                'scope.Complete()
            End If
            'End Using

        Catch ex As Exception
            Throw
        End Try
        Return resultado
    End Function

    Function ListarEmpleado(ByVal Cadena As String) As ListaEmpleado
        Return New ComisionDataAccess().ListarEmpleado(Cadena)
    End Function

    Public Function GuardarComisionAdjunto(ByVal oComisionAdjunto As Archivo, usuario As Integer)
        Using scope As New TransactionScope()
            Dim Valor = New ComisionDataAccess().GuardarComisionAdjunto(oComisionAdjunto, usuario)
            If (Valor <> Constantes.ValorCero) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function DescargarAdjuntoComision(ByVal IdAdj As Integer) As Archivo
        Return New ComisionDataAccess().DescargarAdjuntoComision(IdAdj)
    End Function

    Function ListarAdjuntoComision(ByVal IdPeriodo As Integer, oPaginacion As Paginacion, RowCount As Integer) As ListaArchivo
        Return New ComisionDataAccess().ListarAdjuntoComision(IdPeriodo, oPaginacion, RowCount)
    End Function

    Public Function EliminarComisionAdjunto(ByVal IdAdjunto As Integer, IdPeriodo As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New ComisionDataAccess().EliminarComisionAdjunto(IdAdjunto, IdPeriodo)
            If (Valor <> Constantes.ValorCero) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function Actualiza_Estados_MesesComisionales() As Integer
        Return New ComisionDataAccess().Actualiza_Estados_MesesComisionales()
    End Function

End Class
