Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.DataAccess
Imports System.Transactions

Public Class ClienteBusinessLogic
    Private Log As Log = Nothing
    Private SiLog As Boolean = False

    Public Sub New(Optional ByVal oSiLog As Boolean = False, Optional ByVal oLog As Log = Nothing)
        If (oSiLog) Then
            Me.Log = oLog
            Me.SiLog = oSiLog
        End If
    End Sub

    Public Function ConsultarEstado() As ListaProcesoEstado
        Return New ClienteDataAccess().ConsultarEstado()
    End Function

    Public Function CrearCliente(ByVal oClienteVenta As ClienteVenta) As Int32
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().CrearCliente(oClienteVenta)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ModificarCliente(ByVal oClienteVenta As ClienteVenta) As Int32
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().ModificarCliente(oClienteVenta)
            If (SiLog And Valor = Constantes.ValorDos) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ListaClienteContacto(ByVal oPaginacion As Paginacion) As Paginacion
        Return New ClienteDataAccess().ListaClienteContacto(oPaginacion)
    End Function

    Public Function ListaClienteLineaCredito(oPaginacion As Paginacion) As Paginacion
        Return New ClienteDataAccess().ListarHistorialLineaCliente(oPaginacion)
    End Function

    Public Function ConsultarClienteID(ByVal IdCliente As Int32) As ClienteVenta
        Return New ClienteDataAccess().ConsultarClienteID(IdCliente)
    End Function

    Public Function ListaContactoTipo() As ListaContactoTipo
        Return New ClienteDataAccess().ListaContactoTipo()
    End Function

    Function ListaContactoClase() As ListaContactoClase
        Return New ClienteDataAccess().ListaContactoClase()
    End Function

    Function ListaClienteModoPago() As ListaClienteModoPagoCombo
        Return New ClienteDataAccess().ListaClienteModoPago
    End Function

    Public Function BuscarCliente(ByRef oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New ClienteDataAccess().BuscarCliente(oPaginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function

    Public Function AgregarContacto(ByVal oClienteContacto As ClienteContacto) As Int32
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().AgregarContacto(oClienteContacto)
            If (SiLog And Valor = Constantes.ValorTres) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ModificarClienteContacto(ByVal oClienteContacto As ClienteContacto) As Int32
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().ModificarClienteContacto(oClienteContacto)
            If (SiLog And Valor = 1) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ActualizarClienteEstado(ByVal IdCliente As Integer, ByVal IdEstado As Integer, ByVal Activo As Boolean, ByVal Usuario As String) As Int32

        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().ActualizarClienteEstado(IdCliente, IdEstado, Activo, Usuario)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function CrearClienteAdjunto(ByVal oClienteAdjunto As ClienteAdjunto)
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().CrearClienteAdjunto(oClienteAdjunto)
            If (SiLog And Valor > Constantes.ValorCero) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ConsultarClienteAdjunto(ByRef oPaginacion As Paginacion) As Paginacion
        Return New ClienteDataAccess().ConsultarClienteAdjunto(oPaginacion)
    End Function

    Function ConsultarClienteAdjuntoId(IdAdj As Integer) As ClienteAdjunto
        Return New ClienteDataAccess().ConsultarClienteAdjuntoId(IdAdj)
    End Function

    Function EliminarClienteAdjunto(IdAdj As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().EliminarClienteAdjunto(IdAdj)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ObtenerClienteContactoPorId(ByVal IdContacto As Int32) As ClienteContacto
        Return New ClienteDataAccess().ObtenerClienteContactoPorId(IdContacto)
    End Function

    Public Function CarteraClientes_LIST(ByRef oPaginacion As Paginacion) As Paginacion
        Return New ClienteDataAccess().CarteraClientes_LIST(oPaginacion)
    End Function

    Function ListarEmpleadosBySucursal(IdSucursal As String) As ListaEmpleado
        Return New ClienteDataAccess().ListarEmpleadosBySucursal(IdSucursal)
    End Function

    Public Function CrearCarteraClientes(ByRef oVentaCartera As VentaCartera) As Int32
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().CrearCarteraClientes(oVentaCartera)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function
    Public Function ActualizarEstadoCartera(ByVal IdCartera As Integer, ByVal IdCliente As Integer, ByVal FechaDesasignacion As DateTime) As Int32
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().ActualizarEstadoCartera(IdCartera, IdCliente, FechaDesasignacion)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                Log.IdLogAccion = IIf(Valor = Constantes.ValorUno, Constantes.ValorSiete, Constantes.ValorOcho)
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function ListaClienteTipo() As ListaClienteTipo
        Return New ClienteDataAccess().ListaClienteTipo
    End Function

    Function TraerCliente(IdCliente As Integer) As String
        Return New ClienteDataAccess().TraerCliente(IdCliente)
    End Function

    '////////////////////////////  REASIGNACIÓN DE CLIENTES A VENDEDORES /////////////////////////////////////////////////
    Function ListaZonas() As ListaZonaMantenimiento
        Return New MantenimientoDataAccess().ListaZonaMantenimiento()
    End Function
    Function ListarSucursales_Zona(IdZona As Integer) As ListaSucursal
        Return New ClienteDataAccess().ListarSucursales_Zona(IdZona)
    End Function

    Public Function ListarSucursales() As ListaSucursal
        Return New ClienteDataAccess().ListarSucursales()
    End Function

    Public Function ListarEmpleadoporSucursales(IdSucursal As Integer, Idestado As Boolean) As ListaEmpleado
        Return New ClienteDataAccess().ListarEmpleadoporSucursales(IdSucursal, Idestado)
    End Function

    Public Function ListarEmpleadoporSucursalesFiltroVendedor(IdSucursal As Integer, Idestado As Boolean, IdVendedor As Integer) As ListaEmpleado
        Return New ClienteDataAccess().ListarEmpleadoporSucursalesFiltroVendedor(IdSucursal, Idestado, IdVendedor)
    End Function

    Public Function ListarUsuariosporEmpleadoInactivos(IdEmpleado As Integer) As ListaClienteVenta
        Return New ClienteDataAccess().ListarUsuariosporEmpleadoInactivos(IdEmpleado)
    End Function
    Public Function ListarUsuariosporEmpleadosActivos(IdEmpleado As Integer) As ListaClienteVenta
        Return New ClienteDataAccess().ListarUsuariosporEmpleadosActivos(IdEmpleado)
    End Function

    Public Function AsignarClientesVendedor(oListaClienteCartera As ListaCarteraVenta, oListaClienteCartera2 As ListaCarteraVenta) As Integer
        Dim resultado As Integer = 1

        Using oTransactionScope As New TransactionScope()
            For Each itemoListaClienteCartera As VentaCartera In oListaClienteCartera
                resultado = New ClienteDataAccess().DesasignarClienteVendedor(itemoListaClienteCartera)
            Next
            If oListaClienteCartera2.First().ClienteVenta.IdCliente <> 0 Then
                For Each itemoListaClienteCartera2 As VentaCartera In oListaClienteCartera2
                    resultado = New ClienteDataAccess().AsignarClientesVendedor(itemoListaClienteCartera2)
                Next
            End If
            For Each itemoListaClienteCartera2 As VentaCartera In oListaClienteCartera2
                resultado = New ClienteDataAccess().DesasignarClienteVendedor(itemoListaClienteCartera2)
            Next
            If oListaClienteCartera.First().ClienteVenta.IdCliente <> 0 Then
                For Each itemoListaClienteCartera As VentaCartera In oListaClienteCartera
                    resultado = New ClienteDataAccess().AsignarClientesVendedor(itemoListaClienteCartera)
                Next

                If (SiLog) Then
                    Dim LogDA As New LogDataAccess
                    LogDA.Actualizar_Log(Log)
                End If
                oTransactionScope.Complete()
            End If
            'If oListaClienteCartera2.First().ClienteVenta.IdCliente <> 0 Then
            '    For Each item2 As VentaCartera In oListaClienteCartera2
            '        resultado = New ClienteDataAccess().AsignarClientesVendedor(item2)
            '    Next
            ' oTransactionScope.Complete()
            ' End If

        End Using
        Return resultado
    End Function

    Public Function ValidaFechaActivacion(IdCliente As Integer, IdEmpleado As Integer) As DateTime
        Return New ClienteDataAccess().ValidaFechaActivacion(IdCliente, IdEmpleado)
    End Function
    Public Function VerificarCartera(IdCliente As Integer) As Integer
        Return New ClienteDataAccess().VerificarCartera(IdCliente)
    End Function

    Public Function ComboValidaMeson(IdEmpleado As Integer) As Integer
        Return New ClienteDataAccess().ComboValidaMeson(IdEmpleado)
    End Function

    Public Function ComboValidaTipoMesonEmpleado(IdtipoCarteraEmpledo As Integer, IdEmpleado As Integer) As Integer
        Return New ClienteDataAccess().ComboValidaTipoMesonEmpleado(IdtipoCarteraEmpledo, IdEmpleado)
    End Function

    Public Function ValidarClienteCartera(ByVal IdCliente As Integer, ByVal IdEmpleado As Integer) As Integer
        Return New ClienteDataAccess().ValidarClienteCartera(IdCliente, IdEmpleado)
    End Function

    Public Function ValidarTipoVendedorCartera(IdCliente As Integer, IdEmpleado As Integer) As Integer
        Return New ClienteDataAccess().ValidarTipoVendedorCartera(IdCliente, IdEmpleado)
    End Function

    Public Function ValidarTipoEmpleadoCartera(IdTipoCartera As Integer, IdEmpleado As Integer) As Integer
        Return New ClienteDataAccess().ValidarTipoEmpleadoCartera(IdTipoCartera, IdEmpleado)
    End Function

    Public Function CambiarEstadoCarteraCliente(IdCliente As Integer, IdCartera As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New ClienteDataAccess().CambiarEstadoCarteraCliente(IdCliente, IdCartera)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function ValidaClienteActivoCartera(IdCliente As Integer) As Integer
        Return New ClienteDataAccess().ValidaClienteActivoCartera(IdCliente)
    End Function

    Public Function ListarGrupo() As ListaGrupo
        Return New ClienteDataAccess().ListarGrupo()
    End Function

    Public Function VerificarExistenciaMeson(IdCliente As Integer) As Integer
        Return New ClienteDataAccess().VerificarExistenciaMeson(IdCliente)
    End Function

    Public Function BuscarClienteXModoPago(ByVal IdModoPago As Integer, ByVal oPaginacion As Paginacion, ByVal RazonSocialRUc As String, ByVal IdMotivo As String, ByVal sRRVV As String) As Paginacion
        Return New ClienteDataAccess().BuscarClienteXModoPago(IdModoPago, oPaginacion, RazonSocialRUc, IdMotivo, sRRVV)
    End Function

    Public Function BuscarClienteXModoPago_C_Autorizacion(ByVal IdModoPago As Integer, ByVal oPaginacion As Paginacion, ByVal RazonSocialRUc As String, ByVal IdMotivo As String, ByVal sRRVV_NombreEmpleado As String) As Paginacion
        Using scope As New TransactionScope()
            Dim Valor2 = New ClienteDataAccess().BuscarClienteXModoPago_C_Autorizacion(IdModoPago, oPaginacion, RazonSocialRUc, IdMotivo, sRRVV_NombreEmpleado)
            Dim LogDA As New LogDataAccess
            LogDA.Actualizar_Log(Log)
            scope.Complete()
            Return Valor2
        End Using
        'Return New ClienteDataAccess().BuscarClienteXModoPago_C_Autorizacion(IdModoPago, oPaginacion, RazonSocialRUc, IdMotivo, sRRVV_NombreEmpleado)
    End Function

    Public Function ActivarCliente(ByVal LA As ListaAutorizaciones) As String
        Using scope As New TransactionScope()
            Dim Valor As Integer
            For Each A As Autorizaciones In LA
                Valor = New ClienteDataAccess().ActivarCliente(A)
            Next
            If (Valor = Constantes.ValorUno) Then
                scope.Complete()
            End If
            Return "Se autorizó correctamente"
        End Using
    End Function

    Public Function ListarVendedorPrincipal() As ListaEmpleado
        Return New ClienteDataAccess().ListarVendedorPrincipal()
    End Function

    Public Function ListaCliente_Grilla(oPaginacion As Paginacion) As Paginacion
        Return New ClienteDataAccess().ListaCliente_Grilla(oPaginacion)
    End Function

    Public Function ListarVendedores_Autocomplete(ByVal NombreRRVV As String, ByVal IdCliente As Integer) As ListaEmpleado
        Return New ClienteDataAccess().ListarVendedores_Autocomplete(NombreRRVV, IdCliente)
    End Function

    Public Function CrearCarteraSecundariaClientes(ventaCartera As VentaCartera, paginacion As Paginacion) As Integer
        Return New ClienteDataAccess().CrearCarteraSecundariaClientes(ventaCartera, paginacion)
    End Function

    Public Function ListaSucursalesDisponibles(IdCliente As Integer, IdEmpleado As Integer) As ListaSucursal
        Return New ClienteDataAccess().ListaSucursalesDisponibles(IdCliente, IdEmpleado)
    End Function


    Public Function ListarMotivos() As ListaMotivo
        Return New ClienteDataAccess().ListarMotivos()

    End Function

    Public Function ListaModoPago() As ListaModoPago
        Return New ClienteDataAccess().ListaModoPago()
    End Function


    Public Function InsertarCliente_HA(ByVal oClienteVenta As ClienteVenta) As Int32
        Using scope As New TransactionScope()
            If oClienteVenta.IdModoPago = Constantes.ValorDefectoUno Then
                oClienteVenta.ModoPagoDes = "CREDITO"
            ElseIf oClienteVenta.IdModoPago = Constantes.ValorDos Then
                oClienteVenta.ModoPagoDes = "CONTADO"

            End If

            Dim Valor = New ClienteDataAccess().InsertarCliente_HA(oClienteVenta)
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function Obtener_IdPerfilActualEmpleado(UsuarioUsu As String) As Integer
        Return New ClienteDataAccess().Obtener_IdPerfilActualEmpleado(UsuarioUsu)

    End Function

    Function ListaTipoDocumentoCliente() As ListaTipoDocumento
        Return New ClienteDataAccess().ListaTipoDocumentoCliente
    End Function
End Class
