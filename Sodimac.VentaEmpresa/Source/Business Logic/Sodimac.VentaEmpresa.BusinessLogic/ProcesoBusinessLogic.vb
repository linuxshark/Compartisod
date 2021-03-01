Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.DataAccess
Imports System.Transactions
Imports System.Configuration
Imports Sodimac.VentaEmpresa.Common.Constantes

Public Class ProcesoBusinessLogic
    Private Log As Log = Nothing
    Private SiLog As Boolean = False

    Public Sub New(Optional ByVal oSiLog As Boolean = False, Optional ByVal oLog As Log = Nothing)
        If (oSiLog) Then
            Me.Log = oLog
            Me.SiLog = oSiLog
        End If
    End Sub

    Public Function BuscarCliente(Ruc As Int64) As Boolean
        Dim Resultado As Boolean = New ProcesoDataAccess().BuscarCliente(Ruc)
        Return Resultado
    End Function

    Public Function BuscarProducto(Sku As String) As Boolean
        Dim Resultado As Boolean = New ProcesoDataAccess().BuscarProducto(Sku)
        Return Resultado
    End Function

    Public Function Importar(oListaProcesoCarga As ListaProcesoCarga) As Int32
        Dim sepTot As String = ConfigurationManager.AppSettings("SeparadorTotal")
        Dim sepDoc As String = ConfigurationManager.AppSettings("SeparadorDocumentos")
        Dim Result As Int32 = -1
        Dim options As New TransactionOptions()
        options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
        Dim IdCarga As Integer
        options.Timeout = New TimeSpan(0, 20, 0)
        Try
            Using tx As New TransactionScope(TransactionScopeOption.Required, options)

                Dim oDA As New ProcesoDataAccess
                Dim oProceso As New ProcesoCarga
                oProceso.UserReg = oListaProcesoCarga(0).UserReg
                Dim oListaProcesoAgrupada As New ListaProcesoCarga

                Dim ListaInsertar As ListaProcesoCarga = ObtenerRegistrosaInsertar(oListaProcesoCarga)
                If ListaInsertar.Count > 0 Then
                    Dim ListaFacturas = oListaProcesoCarga.Where(Function(m) m.IdTipoDocumento = IdTpoDocFA)
                    Dim ListaNotasCredito = oListaProcesoCarga.Where(Function(m) m.IdTipoDocumento = IdTpoDocNC)

                    If ListaFacturas.Count > 0 Then
                        oProceso.TotalDocumentos = String.Concat(ListaFacturas.Count.ToString(), sepDoc, ListaFacturas.First().TipoDocumento)
                        oProceso.ValorDocumento = CStr(Math.Round(ListaFacturas.ToList().Sum(Function(m) m.Total), 2))
                    End If
                    If ListaNotasCredito.Count > 0 Then
                        If ListaFacturas.Count > 0 Then
                            oProceso.TotalDocumentos = String.Concat(oProceso.TotalDocumentos, sepTot)
                            oProceso.ValorDocumento = String.Concat(oProceso.ValorDocumento, sepTot)
                        End If
                        oProceso.TotalDocumentos = String.Concat(oProceso.TotalDocumentos, CStr(ListaNotasCredito.Count), sepDoc, ListaNotasCredito.First().TipoDocumento)
                        oProceso.ValorDocumento = String.Concat(oProceso.ValorDocumento, CStr(Math.Round(ListaNotasCredito.ToList().Sum(Function(m) m.Total), 2)))
                    End If

                    IdCarga = oDA.RegHistorial(oProceso)
                    oProceso.IDCarga = IdCarga
                    For Each pro As ProcesoCarga In oListaProcesoCarga
                        pro.IDCarga = oProceso.IDCarga
                    Next

                    'Result = oDA.ImportarVenta_Detalle(oListaProcesoCarga, ObtenerListaAgrupada(oListaProcesoCarga))
                    Result = oDA.ImportarVenta_Venta(oListaProcesoCarga)
                    If Result = 1 Then
                        tx.Complete()
                    Else
                        Result = 3
                    End If
                Else
                    Result = 2 'Todos los registros ya han sido cargados previamente
                End If
            End Using
            'If Result = 1 Then
            '    Result = CalculaComisionesCargaManual(IdCarga)
            'End If
            If (Result = 1 Or Result = 2) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            Return Result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CalculaComisionesCargaManual(IdCarga As Integer) As Integer
        Try
            Dim oDA As New ProcesoDataAccess
            Dim objFechas As New ComisionEscala
            Dim result As Integer = -1
            objFechas = oDA.OtenerFechas(IdCarga)

            While objFechas.PlanVentaFactorFechaFin >= objFechas.PlanVentaFactorFechaInicio
                result = ActualizarComisionesManual(objFechas.PlanVentaFactorFechaInicio)
                objFechas.PlanVentaFactorFechaInicio = DateAdd(DateInterval.Day, 1, objFechas.PlanVentaFactorFechaInicio)
                If result <> 1 Then
                    Exit While
                End If
            End While
            Return result
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function Sincronizar() As Integer
        Dim Resultado As Integer
        Try
            Resultado = New ProcesoDataAccess().Sincronizar()
            Resultado = 1
        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado
    End Function

    Public Function ListarHistorial(pMax As Int32, pStart As Int32, ByRef pTotal As Int32) As ListaProcesoCarga
        Dim oLista As New ListaProcesoCarga
        oLista = New ProcesoDataAccess().ListarHistorial(pMax, pStart, pTotal)
        Return oLista
    End Function

    Public Function ObtenerFechasReprocesar(IdCarga As Integer) As ComisionEscala
        Return New ProcesoDataAccess().OtenerFechas(IdCarga)
    End Function

    Public Function ObtenerListaAgrupada(oListaProcesoCarga As ListaProcesoCarga) As ListaProcesoCarga
        Dim oDic As New Dictionary(Of String, ProcesoCarga)
        Dim oListaAgrupada As New ListaProcesoCarga
        Dim tmpProceso As ProcesoCarga
        Try
            For Each el As ProcesoCarga In oListaProcesoCarga
                Dim tmp = el
                If (existeItem(tmp, oListaAgrupada)) Then
                    tmpProceso = oListaAgrupada.Find(Function(m) m.NumeroDocumento = tmp.NumeroDocumento)
                    tmpProceso.ValorVenta += el.ValorVenta
                    tmpProceso.Igv += el.Igv
                    tmpProceso.Total += el.Total
                Else
                    oListaAgrupada.Add(el)
                End If
            Next
            Return oListaAgrupada
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Function InsertaVentasporConsulta(IdZona As Integer, IdSucursal As String, FechaInicio As String, FechaFin As String) As Integer
        Dim resultado As Integer = 1
        Dim oVentasDataAccess As New VentasDataAccess
        Dim oprogramarjob As New ProgramarJob
        Using scope As New TransactionScope()
            resultado = oVentasDataAccess.InsertaVentasporConsulta(IdZona, IdSucursal, FechaInicio, FechaFin)
            If (SiLog And resultado = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using

        Return resultado
    End Function




    Public Function ImportarEmpleadoMasivo(oEmpleado As Empleado) As Integer
        Try
            Dim oProceso As New ProcesoDataAccess
            oProceso.ImportarEmpleadoMasivo(oEmpleado)
        Catch ex As Exception

        End Try
    End Function
    Public Function EliminarEmpleadoMasivo(oEmpleado As Empleado) As Integer
        Try
            Dim oProceso As New ProcesoDataAccess
            oProceso.EliminarEmpleadoMasivo(oEmpleado)
        Catch ex As Exception

        End Try
    End Function

    Function ActualizarEstadoCargaManual(IDCarga As Integer, IdEstado As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oProcesoDataAccess As New ProcesoDataAccess
        resultado = oProcesoDataAccess.ActualizarEstadoCargaManual(IDCarga, IdEstado)
        Return resultado
    End Function

    Function QuitarEstadoCargaManual(IDCarga As Integer, IdEstado As Integer) As Integer
        Dim resultado As Integer = 0
        Dim oProcesoDataAccess As New ProcesoDataAccess
        resultado = oProcesoDataAccess.QuitarEstadoCargaManual(IDCarga, IdEstado)
        Return resultado
    End Function

    Public Function ListaDetalleHistorial(IDCarga As Integer) As ListaProcesoCarga
        Return New ProcesoDataAccess().ListaDetalleHistorial(IDCarga)
    End Function

    Public Function BuscarMoneda(Moneda As String) As Integer
        Return New ProcesoDataAccess().BuscarMoneda(Moneda)
    End Function

    Public Function ListaDocumentoTipo() As ListaProcesoCarga
        Return New ProcesoDataAccess().ListaDocumentoTipo()
    End Function

    Public Function ListaSucursalVenta() As ListaProcesoCarga
        Return New ProcesoDataAccess().ListaSucursalVenta()
    End Function

    Public Function ListaMoneda() As ListaProcesoCarga
        Return New ProcesoDataAccess().ListaMoneda()
    End Function

    Public Function ListaSKU() As ListaProcesoCarga
        Return New ProcesoDataAccess().ListaSKU()
    End Function

    Private Function ActualizarComisionesManual(Fecha As Date) As Integer
        Dim oDA As New ProcesoDataAccess
        Return oDA.ActualizarComisionesManual(Fecha)
    End Function

    Private Function existeItem(oProcesoCarga As ProcesoCarga, oListaProcesoCarga As ListaProcesoCarga) As Boolean
        Dim result As Boolean
        Dim tmp As New List(Of ProcesoCarga)
        For Each ele As ProcesoCarga In oListaProcesoCarga
            tmp = oListaProcesoCarga.FindAll(Function(m) m.TipoDocumento = oProcesoCarga.TipoDocumento And m.NumeroDocumento = oProcesoCarga.NumeroDocumento And m.Ruc = oProcesoCarga.Ruc And m.Fecha = oProcesoCarga.Fecha And m.Sku = oProcesoCarga.Sku)
            If tmp.Count >= 1 Then
                result = True
                Exit For
            Else
                result = False
            End If
        Next
        Return result
    End Function

    Private Function ObtenerRegistrosaInsertar(oListaProcesoCarga As ListaProcesoCarga) As ListaProcesoCarga
        Dim ListaVentas As ListaProcesoCarga = New ProcesoDataAccess().ListaPatronVentas(oListaProcesoCarga)
        Return QuitarDuplicados(ListaVentas)

        'Dim proc As ProcesoCarga
        'Dim tmp As New ProcesoCarga
        'For i As Integer = oListaProcesoCarga.Count - 1 To 0 Step -1
        '    proc = oListaProcesoCarga(i)
        '    tmp = ListaVentas.Find(Function(m) m.IdTipoDocumento = proc.IdTipoDocumento And m.IdSucursal = proc.IdSucursal And m.NumeroDocumento = proc.NumeroDocumento And m.Ruc = proc.Ruc And m.Fecha = proc.Fecha And m.Sku = proc.Sku)
        '    If Not tmp Is Nothing Then
        '        oListaProcesoCarga.Remove(proc)
        '    End If
        'Next
        'Return QuitarDuplicados(oListaProcesoCarga)

    End Function

    Private Function ValidarHistorialCargas(oListaProcesoCarga As ListaProcesoCarga) As Boolean
        Dim oListaCargasPatron As ListaProcesoCarga = New ProcesoDataAccess().ListarCargasManuales()
        'If oListaCargasPatron.Count > 0 Then
        Dim tmpProceso As New ProcesoCarga
        For Each pro As ProcesoCarga In oListaProcesoCarga
            tmpProceso = pro
            Dim otmp = oListaCargasPatron.Find(Function(m) m.NumeroDocumento = tmpProceso.NumeroDocumento And m.TipoDocumento = tmpProceso.TipoDocumento And m.Fecha = tmpProceso.Fecha And m.Ruc = tmpProceso.Ruc)
            If Not IsNothing(otmp) Then
                Return False
                Exit For
            End If
        Next
        Return True
        'Else
        'Return False
        'End If
    End Function

    Private Function QuitarDuplicados(oListaProcesoCarga As ListaProcesoCarga) As ListaProcesoCarga
        Dim tmp As List(Of ProcesoCarga)
        Dim proc As ProcesoCarga
        For i As Integer = oListaProcesoCarga.Count - 1 To 0 Step -1
            proc = oListaProcesoCarga(i)
            tmp = oListaProcesoCarga.FindAll(Function(m) m.IdTipoDocumento = proc.IdTipoDocumento And m.IdSucursal = proc.IdSucursal And m.NumeroDocumento = proc.NumeroDocumento And m.Ruc = proc.Ruc And m.Fecha = proc.Fecha And m.Sku = proc.Sku)
            If Not tmp Is Nothing AndAlso tmp.Count > 1 Then
                oListaProcesoCarga.Remove(proc)
            End If
        Next
        Return oListaProcesoCarga
    End Function

    Public Function ListaParametrosCargaManual() As ListaParametro
        Return New ProcesoDataAccess().ListaParametrosCargaManual()
    End Function

    Public Function ListaCliente() As ListaClienteVenta
        Return New ProcesoDataAccess().ListaCliente()
    End Function

    Public Function ListaClienteRuc(ByRef Ruc As String) As ListaClienteVenta
        Return New ProcesoDataAccess().ListaClienteRuc(Ruc)
    End Function

    Public Function ObtenerResultadoReprocesoVenta() As String
        Return New ProcesoDataAccess().ObtenerResultadoReprocesoVenta()
    End Function

    Public Function ListaOperacion() As List(Of TipoOperacion)
        Dim ListarOperacion As New List(Of TipoOperacion)
        ListarOperacion.Add(New TipoOperacion With {.IdOperacion = 0, .Operacion = "Actualizar / Agregar"})
        ListarOperacion.Add(New TipoOperacion With {.IdOperacion = 1, .Operacion = "Desactivar"})
        Return ListarOperacion
    End Function


    Public Function Importar(oListaProcesoCargaE As ListaEmpleado) As Int32
        'Dim sepTot As String = ConfigurationManager.AppSettings("SeparadorTotal")
        'Dim sepDoc As String = ConfigurationManager.AppSettings("SeparadorDocumentos")
        'Dim Result As Int32 = -1
        'Dim options As New TransactionOptions()
        'options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
        'Dim IdCarga As Integer
        'options.Timeout = New TimeSpan(0, 20, 0)
        'Try
        '    Using tx As New TransactionScope(TransactionScopeOption.Required, options)

        '        Dim oDA As New ProcesoDataAccess
        '        Dim oProceso As New ProcesoCarga
        '        oProceso.UserReg = oListaProcesoCargaE(0).UserReg
        '        Dim oListaProcesoAgrupada As New ListaProcesoCarga

        '        Dim ListaInsertar As ListaProcesoCarga = ObtenerRegistrosaInsertar(oListaProcesoCarga)
        '        If ListaInsertar.Count > 0 Then
        '            Dim ListaFacturas = oListaProcesoCarga.Where(Function(m) m.IdTipoDocumento = IdTpoDocFA)
        '            Dim ListaNotasCredito = oListaProcesoCarga.Where(Function(m) m.IdTipoDocumento = IdTpoDocNC)

        '            If ListaFacturas.Count > 0 Then
        '                oProceso.TotalDocumentos = String.Concat(ListaFacturas.Count.ToString(), sepDoc, ListaFacturas.First().TipoDocumento)
        '                oProceso.ValorDocumento = CStr(Math.Round(ListaFacturas.ToList().Sum(Function(m) m.Total), 2))
        '            End If
        '            If ListaNotasCredito.Count > 0 Then
        '                If ListaFacturas.Count > 0 Then
        '                    oProceso.TotalDocumentos = String.Concat(oProceso.TotalDocumentos, sepTot)
        '                    oProceso.ValorDocumento = String.Concat(oProceso.ValorDocumento, sepTot)
        '                End If
        '                oProceso.TotalDocumentos = String.Concat(oProceso.TotalDocumentos, CStr(ListaNotasCredito.Count), sepDoc, ListaNotasCredito.First().TipoDocumento)
        '                oProceso.ValorDocumento = String.Concat(oProceso.ValorDocumento, CStr(Math.Round(ListaNotasCredito.ToList().Sum(Function(m) m.Total), 2)))
        '            End If

        '            IdCarga = oDA.RegHistorial(oProceso)
        '            oProceso.IDCarga = IdCarga
        '            For Each pro As ProcesoCarga In oListaProcesoCarga
        '                pro.IDCarga = oProceso.IDCarga
        '            Next

        '            Result = oDA.ImportarVenta_Detalle(oListaProcesoCarga, ObtenerListaAgrupada(oListaProcesoCarga))
        '            If Result = 1 Then
        '                tx.Complete()
        '            Else
        '                Result = 3
        '            End If
        '        Else
        '            Result = 2 'Todos los registros ya han sido cargados previamente
        '        End If
        '    End Using
        '    If Result = 1 Then
        '        Result = CalculaComisionesCargaManual(IdCarga)
        '    End If
        '    If (Result = 1 Or Result = 2) Then
        '        Dim LogDA As New LogDataAccess
        '        LogDA.Actualizar_Log(Log)
        '    End If
        '    Return Result
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function

    Public Function ListarPerfil_Empleado(ByRef oPerfil As String) As String
        Try
            Return New MantenimientoDataAccess().ListarPerfil_Empleado(oPerfil)
        Catch ex As Exception

        End Try
    End Function

    Public Function ListarZona_Sucursal(ByRef oZona As String) As String
        Try
            Return New MantenimientoDataAccess().ListarZona_Sucursal(oZona)
        Catch ex As Exception

        End Try
    End Function

    Public Function ListarSucursal_Empleado(ByRef oSucursal As String) As String
        Try
            Return New MantenimientoDataAccess().ListarSucursal_Empleado(oSucursal)
        Catch ex As Exception

        End Try
    End Function

#Region "Carga Masiva Cliente"
    Public Function ListaTipoOperacion() As List(Of TipoOperacion)
        Dim lstTipoOperacion As New List(Of TipoOperacion)
        lstTipoOperacion.Add(New TipoOperacion With {.IdTipoOperacion = 1, .Descripcion = "Actualizar / Agregar"})
        lstTipoOperacion.Add(New TipoOperacion With {.IdTipoOperacion = 2, .Descripcion = "Desactivar"})
        Return lstTipoOperacion
    End Function

    Public Function ListaPrincipal() As ListaCargaMasivaCliente
        Dim lst As New ListaCargaMasivaCliente
        lst.lstCategoria = ListaClienteCategoria() 'New List(Of ClienteCategoria)
        lst.lstClaseContacto = ListaTablaGeneral(6) 'New List(Of TablaGeneral)
        'lst.lstClienteExiste = ListaCliente() 'New List(Of ClienteVenta)
        'lst.lstContacto = ListaContacto() 'New List(Of ClienteContacto)
        lst.lstDepartamento = ListaDepartamento() 'New List(Of Departamento)
        lst.lstDistrito = ListaDistrito() 'New List(Of Distrito)
        lst.lstGrupo = ListaGrupo() 'New List(Of Grupo)
        lst.lstProvincia = ListaProvincia() 'New List(Of Provincia)
        lst.lstSector = ListaSector() 'New List(Of ClienteSector)
        lst.lstTipo = ListaClienteTipo() 'New List(Of ClienteTipo)
        lst.lstTipoContacto = ListaTablaGeneral(4) 'New List(Of TablaGeneral)
        lst.lstEmpleado = ListaEmpleado() 'New List(Of Empleado)
        lst.lstEmpleadoSecundario = ListaEmpleadoSecundario() 'New List(Of Empleado)
        lst.lstSucursal = ListaSucursal() 'New List(Of Sucursal)
        lst.lstTipoVendedor = ListaTablaGeneral(1) 'New List(Of TablaGeneral)
        lst.lstTipoDocumento = ListaTipoDocumentoCliente()

        Return lst
    End Function

    Public Function RegistraCliente(lstCliente As List(Of CargaMasivaCliente), lstClienteEmpleado As List(Of CargaMasivaCliente), log As Log) As Integer
        Dim result = New ProcesoDataAccess().RegistraCliente(lstCliente, lstClienteEmpleado, log)
        Return result
    End Function

    Public Function DesactivaCliente(lstCliente As List(Of CargaMasivaCliente), lstClienteEmpleado As List(Of CargaMasivaCliente), log As Log) As Integer
        Dim result = New ProcesoDataAccess().DesactivaCliente(lstCliente, lstClienteEmpleado, log)
        Return result
    End Function
    Public Function ListaTablaGeneral(IdTabGru As Integer) As List(Of TablaGeneral)
        Return New ProcesoDataAccess().ListaTablaGeneral(IdTabGru)
    End Function

    Public Function ListaClienteCategoria() As List(Of ClienteCategoria)
        Return New ProcesoDataAccess().ListaClienteCategoria()
    End Function

    'Public Function ListaContacto() As List(Of ClienteContacto)
    '    Return New ProcesoDataAccess().ListaContacto()
    'End Function

    Public Function ListaDepartamento() As List(Of Departamento)
        Return New ProcesoDataAccess().ListaDepartamento()
    End Function

    Public Function ListaDistrito() As List(Of Distrito)
        Return New ProcesoDataAccess().ListaDistrito()
    End Function

    Public Function ListaGrupo() As List(Of Grupo)
        Return New ProcesoDataAccess().ListaGrupo()
    End Function

    Public Function ListaProvincia() As List(Of Provincia)
        Return New ProcesoDataAccess().ListaProvincia()
    End Function

    Public Function ListaSector() As List(Of ClienteSector)
        Return New ProcesoDataAccess().ListaSector()
    End Function

    Public Function ListaClienteTipo() As List(Of ClienteTipo)
        Return New ProcesoDataAccess().ListaClienteTipo()
    End Function

    Public Function ListaEmpleado() As List(Of Empleado)
        Return New ProcesoDataAccess().ListaEmpleado()
    End Function

    Public Function ListaEmpleadoSecundario() As List(Of Empleado)
        Return New ProcesoDataAccess().ListaEmpleadoSecundario()
    End Function


    Public Function ListaSucursal() As List(Of Sucursal)
        Return New ProcesoDataAccess().ListaSucursal()
    End Function

    Public Function ListaTipoDocumentoCliente() As List(Of TipoDocumento)
        Return New ProcesoDataAccess().ListaTipoDocumentoCliente()
    End Function


    Public Function RegistraClienteCartera(lstClienteCartera As List(Of ClienteCartera), log As Log) As Integer
        Dim result = New ProcesoDataAccess().RegistraClienteCartera(lstClienteCartera, log)
        Return result
    End Function


#End Region
End Class
