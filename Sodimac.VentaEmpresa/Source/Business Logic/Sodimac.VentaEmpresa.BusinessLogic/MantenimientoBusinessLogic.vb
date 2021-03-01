Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.DataAccess
Imports System.Transactions

Public Class MantenimientoBusinessLogic
    Private Log As Log = Nothing
    Private SiLog As Boolean = False

    Function ListarReporteCarteraClientes(ByVal RUC As String, ByVal CodigoSucursal As String, ByVal Anio As String, ByVal Mes As String) As ListaClienteCartera
        Return New MantenimientoDataAccess().ListarReporteCarteraClientes(RUC, CodigoSucursal, Anio, Mes)
    End Function

    Public Function RegistraClienteCartera(lstClienteCartera As List(Of ClienteCartera), log As Log) As Integer
        Dim result = New MantenimientoDataAccess().RegistraClienteCartera(lstClienteCartera, log)
        Return result
    End Function

    Public Sub New(Optional ByVal oSiLog As Boolean = False, Optional ByVal oLog As Log = Nothing)
        If (oSiLog) Then
            Me.Log = oLog
            Me.SiLog = oSiLog
        End If
    End Sub

    Function ListarPerfiles(Paginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            Paginacion = New MantenimientoDataAccess().ListarPerfiles(Paginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return Paginacion
    End Function

    Function ListarCarteraCliente(Paginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            Paginacion = New MantenimientoDataAccess().ListarCarteraCliente(Paginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return Paginacion
    End Function

    'Public Function ListarPerfil_Empleado(ByRef oPerfil As Perfil) As Perfil
    '    Try
    '        Return New MantenimientoDataAccess().ListarPerfil_Empleado(oPerfil)
    '    Catch ex As Exception

    '    End Try
    'End Function

    Function ListarPerfil_Combo() As ListaPerfil
        Return New MantenimientoDataAccess().ListarPerfil_Combo()
    End Function
    Function ListarEmpleadoPerfil_Combo() As ListaEmpleadoPerfil
        Return New MantenimientoDataAccess().ListarEmpleadoPerfil_Combo()
    End Function

    Function GestionarPerfil(oPerfil As Perfil) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().GestionarPerfil(oPerfil)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                Log.IdLogAccion = Valor
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function EliminarPerfil(IdPerfil As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().EliminarPerfil(IdPerfil)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function Sel_Perfil_PerfilMenor(IdPerfil As Integer) As Perfil
        Return New MantenimientoDataAccess().Sel_Perfil_PerfilMenor(IdPerfil)
    End Function

    Function Autocompletado_Perfil(NombrePerfil As String) As ListaPerfil
        Return New MantenimientoDataAccess().Autocompletado_Perfil(NombrePerfil)
    End Function

    Function ListarCargos(oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New MantenimientoDataAccess().ListarCargos(oPaginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function

    Function ListarCargoByPerfil_Combo(IdPerfil As Integer) As ListaCargo
        Return New MantenimientoDataAccess().ListarCargoByPerfil_Combo(IdPerfil)
    End Function

    Function ListaZonaMantenimiento() As ListaZonaMantenimiento
        Return New MantenimientoDataAccess().ListaZonaMantenimiento()
    End Function


    Function ListaZonaMantenimiento2(Usuario As Integer, FechaIni As String, FechaFin As String) As ListaZonaMantenimiento
        Return New MantenimientoDataAccess().ListaZonaMantenimiento2(Usuario, FechaIni, FechaFin)
    End Function

    Function GestionarCargo_(oCargo As Cargo) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().GestionarCargo_(oCargo)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                Log.IdLogAccion = Valor
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function EliminarCargo(IdCargo As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().EliminarCargo(IdCargo)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function Autocompletado_Cargo(NombreCargo As String) As ListaCargo
        Return New MantenimientoDataAccess().Autocompletado_Cargo(NombreCargo)
    End Function
    Function Seleccion_tipoPerfil(IdPerfil As Integer) As Integer
        Return New MantenimientoDataAccess().Seleccion_tipoPerfil(IdPerfil)
    End Function
    Function Seleccion_tipoPerfill(idcargose As Integer) As Integer
        Return New MantenimientoDataAccess().Seleccion_tipoPerfill(idcargose)
    End Function
    Function Seleccionar_PerfilMayor_Menor(idperfil As Integer) As String
        Return New MantenimientoDataAccess().Seleccionar_PerfilMayor_Menor(idperfil)
    End Function

    Function ListarZonas(paginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            paginacion = New MantenimientoDataAccess().ListarZonas(paginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return paginacion
    End Function

    Function EliminarZona(IdZona As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().EliminarZona(IdZona)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function Autocompletado_Zona(NombreZona As String) As ListaZonaMantenimiento
        Return New MantenimientoDataAccess().Autocompletado_Zona(NombreZona)
    End Function

    Function ListaSucursal_Multiselect(IdZona As Integer) As ListaSucursal
        Return New MantenimientoDataAccess().ListaSucursal_Multiselect(IdZona)
    End Function

    Function ListaSucursal_Multiselect(IdZona As Integer, Nacional As Integer) As ListaSucursal
        Return New MantenimientoDataAccess().ListaSucursal_Multiselect(IdZona, Nacional)
    End Function

    Function traerEstado_Zona(IdZona As Integer) As Boolean
        Return New MantenimientoDataAccess().traerEstado_Zona(IdZona)
    End Function

    Function GestionarZona_(Idzona As Integer, NombreZona As String, IsNacional As Boolean, IdSucursales As String) As Integer
        Dim oMantenimientoDataAccess As New MantenimientoDataAccess
        Dim oListaZonaSucursal As New ListaZonaSucursalMantenimiento
        Dim resultado As Integer = 0
        Dim total As Integer = 0
        Dim IdSucursales_Array() As String
        Dim oZonaSucursal As New ZonaSucursalMantenimiento
        IdSucursales_Array = Split(IdSucursales, ",")
        If IsNacional = False Or IsNacional = True Then
            For i As Integer = 0 To IdSucursales_Array.Length - 1
                oZonaSucursal = New ZonaSucursalMantenimiento()
                oZonaSucursal.IdSucursal = IdSucursales_Array(i)
                oZonaSucursal.IdZona = Idzona
                oZonaSucursal.ZonaMantenimiento = New ZonaMantenimiento()
                oZonaSucursal.ZonaMantenimiento.IdZona = Idzona
                oZonaSucursal.ZonaMantenimiento.NombreZona = NombreZona
                oZonaSucursal.ZonaMantenimiento.IsNacional = IsNacional
                oListaZonaSucursal.Add(oZonaSucursal)
            Next
            'Else
            '    oZonaSucursal = New ZonaSucursalMantenimiento()
            '    oZonaSucursal.IdSucursal = 0
            '    oZonaSucursal.IdZona = Idzona
            '    oZonaSucursal.ZonaMantenimiento = New ZonaMantenimiento()
            '    oZonaSucursal.ZonaMantenimiento.IdZona = Idzona
            '    oZonaSucursal.ZonaMantenimiento.NombreZona = NombreZona
            '    oZonaSucursal.ZonaMantenimiento.IsNacional = IsNacional
            '    oListaZonaSucursal.Add(oZonaSucursal)

        End If

        Using scope As New TransactionScope()
            Dim Valor = oMantenimientoDataAccess.GestionarZona_(oListaZonaSucursal)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                Log.IdLogAccion = Valor
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function GestionarGrupo_(IdGrupo As Integer, NombreGrupo As String, IdClientes As String) As Integer
        Dim oMantenimientoDataAccess As New MantenimientoDataAccess
        Dim oListaGrupoCliente As New ListaGrupoClienteMantenimiento
        Dim resultado As Integer = 0
        Dim total As Integer = 0
        Dim IdClientes_Array() As String
        Dim oGrupoCliente As New GrupoClienteMantenimiento
        IdClientes_Array = Split(IdClientes, ",")

        For i As Integer = 0 To IdClientes_Array.Length - 1
            oGrupoCliente = New GrupoClienteMantenimiento()
            oGrupoCliente.IdCliente = IdClientes_Array(i)
            oGrupoCliente.IdGrupo = IdGrupo
            oGrupoCliente.Grupo = New Grupo()
            oGrupoCliente.Grupo.IdGrupo = IdGrupo
            oGrupoCliente.Grupo.NombreGrupo = NombreGrupo

            oListaGrupoCliente.Add(oGrupoCliente)
        Next


        Using scope As New TransactionScope()
            Dim Valor = oMantenimientoDataAccess.GestionarGrupo_(oListaGrupoCliente)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                Log.IdLogAccion = Valor
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function ListarGrupos(oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New MantenimientoDataAccess().ListarGrupos(oPaginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function
    Function ListaClientes_Multiselect(IdGrupo As Integer) As ListaClienteVenta
        Return New MantenimientoDataAccess().ListaClientes_Multiselect(IdGrupo)
    End Function
    Function ListaClientesSeleccionados(IdGrupo As Integer) As ListaClientesSeleccionadas
        Return New MantenimientoDataAccess().ListaClientesSeleccionados(IdGrupo)
    End Function

    Function ListaSucursalesSeleccionadas(IdZona As Integer) As ListaSucursalSeleccionadas
        Return New MantenimientoDataAccess().ListaSucursalesSeleccionadas(IdZona)
    End Function
    Public Function ListarSucursales(ByRef oPaginacion As Paginacion) As Paginacion
        Return New MantenimientoDataAccess().ListarSucursales(oPaginacion)
    End Function
    Public Function Autocompletado_Sucursal(NombreSucursal As String) As ListaSucursalMantenimiento
        Return New MantenimientoDataAccess().Autocompletado_Sucursal(NombreSucursal)
    End Function
    Public Function ConsultarDepartamento() As ListaDepartamento
        Return New MantenimientoDataAccess().ConsultarDepartamento()
    End Function
    Public Function ConsultarProvinciaDepartamento(ByVal IdDepartamento As Integer) As ListaProvincia
        Return New MantenimientoDataAccess().ConsultarProvinciaDepartamento(IdDepartamento)
    End Function
    Public Function ConsultarDistritoProvincia(ByVal IdProvincia As Integer) As ListaDistrito
        Return New MantenimientoDataAccess().ConsultarDistritoProvincia(IdProvincia)
    End Function

    Public Function GestionarSucursal_(oSucursalMantenimiento As SucursalMantenimiento) As Integer
        Return New MantenimientoDataAccess().GestionarSucursal_(oSucursalMantenimiento)
    End Function
    Public Function EliminarSucursal(IdSucursal As Integer) As Integer
        Return New MantenimientoDataAccess().EliminarSucursal(IdSucursal)
    End Function

    Function NombreVendedor(IdCargo As Integer) As String
        Return New MantenimientoDataAccess().NombreVendedor(IdCargo)
    End Function

    Function Autocompletado_Grupo(NombreGrupo As String) As ListaGrupo
        Return New MantenimientoDataAccess().Autocompletado_Grupo(NombreGrupo)
    End Function

    Function EliminarGrupo(IdGrupo As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().EliminarGrupo(IdGrupo)
            If (SiLog And Valor = Constantes.ValorUno) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function ListaClientesGrupo(paginacion As Paginacion) As Paginacion
        Return New MantenimientoDataAccess().ListaClientesGrupo(paginacion)
    End Function

    'Function ValidarGrupoCliente(IdGrupo As Integer) As Integer
    '    Return New MantenimientoDataAccess().ValidarGrupoCliente(IdGrupo)
    'End Function

    Function BuscarProveedor(proveedor As Proveedor, paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Proveedor)
        Dim lista = New MantenimientoDataAccess().BuscarProveedor(proveedor, paginacion, rowCount)
        Return lista
    End Function

    Function InsertarProveedor(proveedor As Proveedor) As Integer
        Dim result = New MantenimientoDataAccess().InsertarProveedor(proveedor)
        Return result
    End Function

    Function ActualizarProveedor(proveedor As Proveedor) As Integer
        Dim result = New MantenimientoDataAccess().ActualizarProveedor(proveedor)
        Return result
    End Function

    Function GetProveedor(id As Integer) As Proveedor
        Dim obj = New MantenimientoDataAccess().GetProveedor(id)
        Return obj
    End Function

    Public Function ActualizarProveedorEstado(proveedor As Proveedor) As Object
        Select Case proveedor.Estado
            Case True
                proveedor.Estado = False
            Case False
                proveedor.Estado = True
        End Select
        Dim obj = New MantenimientoDataAccess().ActualizarProveedorEstado(proveedor)
        Return obj
    End Function

    Public Function ListarProductos(model As Proveedor, paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Producto)
        Dim ListaProductos = New MantenimientoDataAccess().BuscarSkuProveedor(model, paginacion, rowCount)
        Return ListaProductos
    End Function

    Function ActualizarSkuProveedorEstado(Sku As String, IdProv As Integer, Estado As Boolean) As Integer
        Select Case Estado
            Case True
                Estado = False
            Case False
                Estado = True
        End Select
        Dim result = New MantenimientoDataAccess().ActualizaEstadoSkuProv(Sku, IdProv, Estado)
        Return result
    End Function

    Function ListarProductosSeleccionar(producto As Producto, proveedor As Proveedor, paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Producto)
        Dim result = New MantenimientoDataAccess().ListarProductosSeleccionar(producto, proveedor, paginacion, rowCount)
        Dim prods = If(producto.Item Is Nothing, Nothing, producto.Item.Trim().Split(","))
        Dim newProd As New List(Of Producto)
        If prods Is Nothing Then
            newProd = result
        Else
            For Each objProd As Producto In result
                If (prods.Contains(objProd.Sku.Trim())) Then
                    objProd.Seleccion = True
                End If
                newProd.Add(objProd)
            Next
        End If
        Return newProd
    End Function

    Function InsertarProveedorSku(producto As Producto, proveedor As Proveedor) As Integer
        Dim ArrayPro = producto.Item.Split(",")
        Dim result As Integer
        For Each item In ArrayPro
            result = New MantenimientoDataAccess().InsertarProveedorSku(item, proveedor.IdProveedor)
        Next
        Return result
    End Function

    Public Function ListarMes() As List(Of Mes)
        Dim ListaMes As New List(Of Mes)
        ListaMes.Add(New Mes With {.IdMes = 1, .Mes = "ENERO"})
        ListaMes.Add(New Mes With {.IdMes = 2, .Mes = "FEBRERO"})
        ListaMes.Add(New Mes With {.IdMes = 3, .Mes = "MARZO"})
        ListaMes.Add(New Mes With {.IdMes = 4, .Mes = "ABRIL"})
        ListaMes.Add(New Mes With {.IdMes = 5, .Mes = "MAYO"})
        ListaMes.Add(New Mes With {.IdMes = 6, .Mes = "JUNIO"})
        ListaMes.Add(New Mes With {.IdMes = 7, .Mes = "JULIO"})
        ListaMes.Add(New Mes With {.IdMes = 8, .Mes = "AGOSTO"})
        ListaMes.Add(New Mes With {.IdMes = 9, .Mes = "SEPTIEMBRE"})
        ListaMes.Add(New Mes With {.IdMes = 10, .Mes = "OCTUBRE"})
        ListaMes.Add(New Mes With {.IdMes = 11, .Mes = "NOVIEMBRE"})
        ListaMes.Add(New Mes With {.IdMes = 12, .Mes = "DICIEMBRE"})
        Return ListaMes
    End Function

    Public Function ListarAño() As List(Of Año)
        Dim ListaAño As New List(Of Año)
        Dim AA As Integer = CInt(System.DateTime.Now.Year) - 1
        Dim AC As Integer = CInt(System.DateTime.Now.Year)
        Dim AC1 As Integer = CInt(System.DateTime.Now.Year) + 1
        Dim AC2 As Integer = CInt(System.DateTime.Now.Year) + 2
        ListaAño.Add(New Año With {.IdAño = AA, .Año = AA})
        ListaAño.Add(New Año With {.IdAño = AC, .Año = AC})
        ListaAño.Add(New Año With {.IdAño = AC1, .Año = AC1})
        ListaAño.Add(New Año With {.IdAño = AC2, .Año = AC2})
        Return ListaAño
    End Function

    Public Function ListarEstado() As List(Of Activo)
        Dim ListaActivo As New List(Of Activo)
        ListaActivo.Add(New Activo With {.IdActivo = "1", .Descripcion = "ACTIVO"})
        ListaActivo.Add(New Activo With {.IdActivo = "0", .Descripcion = "INACTIVO"})
        Return ListaActivo
    End Function

    Public Function ListarEstadoProveedor() As List(Of EstadoProveedor)
        Dim ListaAProveedor As New List(Of EstadoProveedor)
        ListaAProveedor.Add(New EstadoProveedor With {.IdEstado = 0, .Descripcion = "INACTIVO"})
        ListaAProveedor.Add(New EstadoProveedor With {.IdEstado = 1, .Descripcion = "ACTIVO"})

        Return ListaAProveedor
    End Function

    Function BuscarFeriados(feriados As Feriados, paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Feriados)
        Using scope As New TransactionScope
            Dim lista = New MantenimientoDataAccess().BuscarFeriados(feriados, paginacion, rowCount)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
            Return lista
        End Using
    End Function

    Function InsertarFeriados(feriados As Feriados) As Integer
        Using scope As New TransactionScope
            Dim result = New MantenimientoDataAccess().InsertarFeriados(feriados)
            If (SiLog And result > Constantes.ValorCero) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
            Return result
        End Using
    End Function

    Function GetFeriado(id As Integer) As Feriados
        Dim obj = New MantenimientoDataAccess().GetFeriado(id)
        Return obj
    End Function

    Function ActualizarFeriado(feriado As Feriados) As Integer
        Using scope As New TransactionScope
            Dim result = New MantenimientoDataAccess().ActualizarFeriado(feriado)
            If (SiLog And result > Constantes.ValorCero) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
            Return result
        End Using
    End Function

    Public Function ActualizarFeriadoEstado(feriado As Feriados) As Integer
        Using scope As New TransactionScope
            Select Case feriado.Activo
                Case True
                    feriado.Activo = False
                Case False
                    feriado.Activo = True
            End Select
            Dim obj = New MantenimientoDataAccess().ActualizarFeriadoEstado(feriado)
            If (SiLog And obj > Constantes.ValorCero) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
            Return obj
        End Using
    End Function

#Region "Mantenimiento Cierre"

    Function RegistrarCierre(cierre As Cierre) As Integer
        Using scope As New TransactionScope
            Dim result = New MantenimientoDataAccess().RegistrarCierre(cierre)
            If (SiLog And result > Constantes.ValorCero) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
            Return result
        End Using
    End Function

    Function BuscarCierre(cierre As Cierre, paginacion As Paginacion, ByRef rowCount As Integer) As List(Of Cierre)
        Using scope As New TransactionScope
            Dim lista = New MantenimientoDataAccess().BuscarCierre(cierre, paginacion, rowCount)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
            Return lista
        End Using
    End Function

    Function EliminarCierre(idCierre As Integer) As Cierre
        Using scope As New TransactionScope
            Dim result = New MantenimientoDataAccess().EliminarCierre(idCierre)
            If (SiLog) Then
                Log.DescripcionAccion = result.Msg
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
                scope.Complete()
            End If
            Return result
        End Using
    End Function
#End Region

#Region "Mantenimiento Cotizacion - DescuentoFamilia"
    Function ListarFamilia_Combo() As ListaFamilia
        Return New MantenimientoDataAccess().ListarFamilia_Combo()
    End Function

    Function ListarDescuentoFamilia(oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New MantenimientoDataAccess().ListarDescuentoFamilia(oPaginacion)
            If (SiLog) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function

    Function EliminarDescuentoFamilia(codigoFamilia As String) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().EliminarDescuentoFamilia(codigoFamilia)
            If (SiLog And valor = Constantes.ValorUno) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return valor
        End Using
    End Function

    Function GestionarDescuentoFamilia(oDescuentoFamilia As DescuentoFamilia) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().GestionarDescuentoFamilia(oDescuentoFamilia)
            If (SiLog And (valor = Constantes.ValorUno Or valor = Constantes.ValorDos)) Then
                Dim logDa As New LogDataAccess
                Log.IdLogAccion = valor
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return valor
        End Using
    End Function
#End Region

#Region "Mantenimiento Cotizacion - DescuentoSku"

    Function ListarDescuentoSku(oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New MantenimientoDataAccess().ListarDescuentoSku(oPaginacion)
            If (SiLog) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function

    Function EliminarDescuentoSku(codigoSku As Integer) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().EliminarDescuentoSku(codigoSku)
            If (SiLog And valor = Constantes.ValorUno) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return valor
        End Using
    End Function

    Function GestionarDescuentoSku(oDescuentoSku As DescuentoSku) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().GestionarDescuentoSku(oDescuentoSku)
            If (SiLog And (valor = Constantes.ValorUno)) Then
                Dim logDa As New LogDataAccess
                Log.IdLogAccion = valor
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return valor
        End Using
    End Function

    Function ValidaExiteSku(codigoSku As String) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().ValidaExiteSku(codigoSku)
            scope.Complete()
            Return valor
        End Using
    End Function
#End Region

#Region "Mantenimiento Cotizacion - Uxpos"
    Function ListarMarca_Combo() As ListaMarca
        Return New MantenimientoDataAccess().ListarMarca_Combo()
    End Function

    Function ListarEmpleadoxPerfil_Combo(perfil As String) As ListaEmpleado
        Return New MantenimientoDataAccess().ListarEmpleadoxPerfil_Combo(perfil)
    End Function

    Function ListaCotizacion(oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New MantenimientoDataAccess().ListaCotizacion(oPaginacion)
            If (SiLog) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function

    Function GestionarCotizacion(oCotizacion As Cotizacion) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().GestionarCotizacion(oCotizacion)
            If (SiLog And (valor = Constantes.ValorUno Or valor = Constantes.ValorDos)) Then
                Dim logDa As New LogDataAccess
                Log.IdLogAccion = valor
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return valor
        End Using
    End Function

    Function ListaDetalleCotizacion(oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New MantenimientoDataAccess().ListaDetalleCotizacion(oPaginacion)
            If (SiLog) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function

    Function ListarSucursalControl(idMarca As Integer) As ListaSucursal
        Return New MantenimientoDataAccess().ListarSucursalControl(idMarca)
    End Function

    Function ListaReporteCotizacion(oBusquedaCotizacion As BusquedaCotizacion) As List(Of ReporteCotizacion)
        Dim reporteCotizacions = New List(Of ReporteCotizacion)
        Using scope As New TransactionScope()
            reporteCotizacions = New MantenimientoDataAccess().ListaReporteCotizacion(oBusquedaCotizacion)
            If (SiLog) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return reporteCotizacions
    End Function
#End Region

#Region "Mantenimiento Cotizacion - Productos Bloqueados"
    Function ListarSkuBloqueados(oPaginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            oPaginacion = New MantenimientoDataAccess().ListarSkuBloqueados(oPaginacion)
            If (SiLog) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return oPaginacion
    End Function

    Function EliminarSkuBloqueado(codigoSku As String) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().EliminarSkuBloqueado(codigoSku)
            If (SiLog And valor = Constantes.ValorUno) Then
                Dim logDa As New LogDataAccess
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return valor
        End Using
    End Function

    Function GestionarSkuBloqueado(oProducto As Producto) As Integer
        Using scope As New TransactionScope()
            Dim valor = New MantenimientoDataAccess().GestionarSkuBloqueado(oProducto)
            If (SiLog And (valor = Constantes.ValorUno)) Then
                Dim logDa As New LogDataAccess
                Log.IdLogAccion = valor
                logDa.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return valor
        End Using
    End Function
#End Region

#Region "Plan Ventas Por Representante - SOD13068"

    Function ListarTipoRepresentanteVenta() As ListaTipoRepresentanteVenta
        Return New MantenimientoDataAccess().ListarTipoRepresentanteVenta()
    End Function

    Function ListarMesPlan() As ListaMesPlan
        Return New MantenimientoDataAccess().ListarMesPlan()
    End Function

    Function ListarPlanTipoRepresentanteVenta(paginacion As Paginacion) As Paginacion
        Using scope As New TransactionScope()
            paginacion = New MantenimientoDataAccess().ListarPlanTipoRepresentanteVenta(paginacion)
            If (SiLog) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
        End Using
        Return paginacion
    End Function

    Function ObtenerPlanTipoRepresentanteVenta(idPlanTipoRepVen As Integer) As PlanTipoRepresentanteVenta
        Return New MantenimientoDataAccess().ObtenerPlanTipoRepresentanteVenta(idPlanTipoRepVen)
    End Function

    Function GestionarPlanTipoRepresentanteVenta(planTipoRepresentanteVenta As PlanTipoRepresentanteVenta) As String
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().GestionarPlanTipoRepresentanteVenta(planTipoRepresentanteVenta)
            Dim resultado() As String = Split(Valor, ":")
            Dim resulInt = Convert.ToInt32(resultado(0))
            If (SiLog And (resulInt = Constantes.ValorUno Or resulInt = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                Log.IdLogAccion = resulInt
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

    Function EliminarPlanTipoRepresentanteVenta(idPlanTipoRepVen As Integer) As Integer
        Using scope As New TransactionScope()
            Dim Valor = New MantenimientoDataAccess().EliminarPlanTipoRepresentanteVenta(idPlanTipoRepVen)
            If (SiLog And (Valor = Constantes.ValorUno Or Valor = Constantes.ValorDos)) Then
                Dim LogDA As New LogDataAccess
                LogDA.Actualizar_Log(Log)
            End If
            scope.Complete()
            Return Valor
        End Using
    End Function

#End Region
End Class

