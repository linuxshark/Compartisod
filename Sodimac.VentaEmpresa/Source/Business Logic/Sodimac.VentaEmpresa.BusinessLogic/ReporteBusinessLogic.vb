Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts

Public Class ReporteBusinessLogic


    Public Function SelTransacVentaCreditoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Integer
        Return New ReporteDataAccess().SelTransacVentaCreditoPorTienda(fechaIni, fechaFin, codigoTienda)
    End Function

    Public Function SelTransacVentaContadoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Integer
        Return New ReporteDataAccess().SelTransacVentaContadoPorTienda(fechaIni, fechaFin, codigoTienda)
    End Function

    Public Function SelMargenNetoTotalPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Decimal
        Return New ReporteDataAccess().SelMargenNetoTotalPorTienda(fechaIni, fechaFin, codigoTienda)
    End Function

    Public Function SelMargenNetoTotalPorZona(fechaIni As Date, fechaFin As Date, codigoZona As Integer) As Decimal
        Return New ReporteDataAccess().SelMargenNetoTotalPorZona(fechaIni, fechaFin, codigoZona)
    End Function

    Public Function SelMargenNetoTotal(fechaIni As Date, fechaFin As Date) As Decimal
        Return New ReporteDataAccess().SelMargenNetoTotal(fechaIni, fechaFin)
    End Function

    Public Function SelMargenNetoCreditoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Decimal
        Return New ReporteDataAccess().SelMargenNetoCreditoPorTienda(fechaIni, fechaFin, codigoTienda)
    End Function

    Public Function SelMargenNetoContadoPorTienda(fechaIni As Date, fechaFin As Date, codigoTienda As String) As Decimal
        Return New ReporteDataAccess().SelMargenNetoContadoPorTienda(fechaIni, fechaFin, codigoTienda)
    End Function

    Public Function SelMargenNetoContadoPorZona(fechaIni As Date, fechaFin As Date, codigoZona As Integer) As Decimal
        Return New ReporteDataAccess().SelMargenNetoContadoPorZona(fechaIni, fechaFin, codigoZona)
    End Function

    Public Function SelMargenNetoCreditoPorZona(fechaIni As Date, fechaFin As Date, codigoZona As Integer) As Decimal
        Return New ReporteDataAccess().SelMargenNetoCreditoPorZona(fechaIni, fechaFin, codigoZona)
    End Function

    Public Function SelMargenTotalContado(fechaIni As Date, fechaFin As Date) As Decimal
        Return New ReporteDataAccess().SelMargenTotalContado(fechaIni, fechaFin)
    End Function


    Public Function SelMargenTotalCredito(fechaIni As Date, fechaFin As Date) As Decimal
        Return New ReporteDataAccess().SelMargenTotalCredito(fechaIni, fechaFin)
    End Function


    Public Function SelPlanMargenPorTienda(fecha As Date, codigoMarca As Integer) As Decimal
        Return New ReporteDataAccess().SelPlanMargenPorTienda(fecha, codigoMarca)
    End Function

    Public Sub SelPeriodosVentaInteranual(fecIni As Date, fecFin As Date, ByRef fecIniVI As Date, ByRef fecFinVI As Date)
        Dim dal As New ReporteDataAccess
        dal.SelPeriodosVentaInteranual(fecIni, fecFin, fecIniVI, fecFinVI)
    End Sub

    Public Function SelVentaInteranual(fecIni As Date, fecFin As Date, codigoTienda As String) As Decimal
        Return New ReporteDataAccess().SelVentaInteranual(fecIni, fecFin, codigoTienda)
    End Function

    Public Function SelVentaNetaCreditoPorTienda(fecIni As Date, fecFin As Date, codigoTienda As Integer) As Decimal
        Return New ReporteDataAccess().SelVentaNetaCreditoPorTienda(fecIni, fecFin, codigoTienda)
    End Function

    Public Function SelVentaNetaContadoPorTienda(fecIni As Date, fecFin As Date, codigoTienda As Integer) As Decimal
        Return New ReporteDataAccess().SelVentaNetaContadoPorTienda(fecIni, fecFin, codigoTienda)
    End Function

    Public Function SelDiasUtilesyDiasAvancePorMes(fecha As DateTime) As String
        Return New ReporteDataAccess().SelDiasUtilesyDiasAvancePorMes(fecha)
    End Function

    Public Function SelPlanVentaPorTienda(fecha As Date, codigoTienda As String) As Double
        Return New ReporteDataAccess().SelPlanVentaPorTienda(fecha, codigoTienda)
    End Function

    Public Function ListaSucursalesPorZona(idZona As Integer) As List(Of Sucursal)
        Return New ReporteDataAccess().ListaSucursalesPorZonaReporteVE(idZona)
    End Function

    Public Function ListaZonas() As List(Of Zona)
        Return New ReporteDataAccess().ListaZonasReporteVE()
    End Function

    Public Function BuscarSucursal(ZonaCadena As String, usuario As String, FechaIni As String, FechaFin As String) As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursal2(ZonaCadena, usuario, FechaIni, FechaFin)
    End Function

    Public Function BuscarSucursal2() As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursal()
    End Function

    Public Function BuscarSucursal3(usuario As String) As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursal3(usuario)
    End Function
    Public Function BuscarSucursalVentas(IdJefeRegional As Integer) As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursalVentas(IdJefeRegional)
    End Function

    Public Function BuscarSucursalVendedores() As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursalVendedores()
    End Function

    Public Function BuscarZonaJefeRegional() As ListaZona
        Return New ReporteDataAccess().BuscarZonaJefeRegional()
    End Function

    Public Function BuscarSucursalTiendas() As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursalTiendas()
    End Function

    Public Function BuscarSectorClientes() As ListaClienteSector
        Return New ReporteDataAccess().BuscarSectorClientes()
    End Function

    Public Function BuscarCategoriaClientes() As ListaClienteCategoria
        Return New ReporteDataAccess().BuscarCategoriaClientes()
    End Function

    Public Function BuscarFormaPagoClientes() As ListaClienteModoPagoCombo
        Return New ReporteDataAccess().BuscarFormaPagoClientes()
    End Function

    Public Function BuscarZonaTiendas() As ListaZona
        Return New ReporteDataAccess().BuscarZonaTiendas()
    End Function

    Public Function BuscarTipoClientes() As ListaClienteTipo
        Return New ReporteDataAccess().BuscarTipoClientes()
    End Function

    Public Function BuscarJefeRegionalVendedores() As ListaEmpleado
        Return New ReporteDataAccess().BuscarJefeRegionalVendedores()
    End Function

    Public Function BuscarVendedoresVentas(IdSucursal As Integer) As ListaEmpleado
        Return New ReporteDataAccess().BuscarVendedoresVentas(IdSucursal)
    End Function

    Public Function BuscarJefeRegionalVentas(ByVal usuario As String, FechaIni As String, FechaFin As String) As ListaEmpleado
        Return New ReporteDataAccess().BuscarJefeRegionalVentas(usuario, FechaIni, FechaFin)
    End Function

    Public Function BuscarJefeRegionalAvanceVenta(ByVal usuario As String, subGerente As String, idZona As String) As ListaEmpleado
        Return New ReporteDataAccess().BuscarJefeRegionalAvanceVenta(usuario, subGerente, idZona)
    End Function

    Public Function BuscarJefeRegionalVentas_Ventas(ByVal usuario As String, FechaIni As String, FechaFin As String) As ListaEmpleado
        Dim oListaEmpleado
        oListaEmpleado = New ReporteDataAccess().BuscarJefeRegionalVentas_Ventas(usuario, FechaIni, FechaFin)
        Return oListaEmpleado
    End Function

    Function BuscarSucursalByZona(IdZona As Integer) As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursalByZona(IdZona)
    End Function

    Function ListarVendedores(ByVal usuario As String, ByVal jefe As String, FechaIni As String, FechaFin As String) As ListaEmpleado
        Return New ReporteDataAccess().ListarVendedores(usuario, jefe, FechaIni, FechaFin)
    End Function

    Function ListarSubGerente() As ListaEmpleado
        Return New ReporteDataAccess().ListarSubGerente()
    End Function

    Function ListarVendedores_G(ByVal usuario As String, ByVal jefe As String, FechaIni As String, FechaFin As String) As ListaEmpleado
        Return New ReporteDataAccess().ListarVendedores_G(usuario, jefe, FechaIni, FechaFin)
    End Function

    Function ListarSucursales() As ListaSucursal
        Return New ReporteDataAccess().ListarSucursales()
    End Function

    Function ListarSucursales_CodigoSucursal() As ListaSucursal
        Return New ReporteDataAccess().ListarSucursales_CodigoSucursal()
    End Function

    Function ListarEstados() As ListaClienteEstadoLinea
        Return New ReporteDataAccess().ListarEstados()
    End Function

    Function ListarMarcas() As List(Of Marca)
        Return New ReporteDataAccess().ListarMarcas()
    End Function

    Function ListaZonaMantenimiento() As ListaZonaMantenimiento
        Return New ReporteDataAccess().ListaZonaMantenimiento()
    End Function

    Function ListaZonaMantenimiento2(Usuario As String, FechaIni As String, FechaFin As String) As ListaZonaMantenimiento
        Return New MantenimientoDataAccess().ListaZonaMantenimiento2(Usuario, FechaIni, FechaFin)
    End Function

    Function ListaZonaMantenimiento3(usuario As String) As ListaZonaMantenimiento
        Return New ReporteDataAccess().ListaZonaMantenimiento3(usuario)
    End Function

    Public Function ListarSucursalZona_Cliente(IdZona As String, Usuario As String) As ListaSucursal
        Return New ReporteDataAccess().ListarSucursalZona_Cliente(IdZona, Usuario)
    End Function

    Public Function ListarReporteVenta(
            fechainicio As String,
            fechafin As String,
            jeferegional As String,
            zona As String,
            sucursal As String,
            vendedor As String,
            ruc As String,
            razonsocial As String,
            tipocliente1 As String,
            idgrupo1 As String,
            usuarioUsu As String) As List(Of ReportVenta)

        Return New ReporteDataAccess().ListaReporteVenta(
            fechainicio,
            fechafin,
            jeferegional,
            zona,
            sucursal,
            vendedor,
            ruc,
            razonsocial,
            tipocliente1,
            idgrupo1,
            usuarioUsu)
    End Function

    Public Function ListarReporteClienteCartera(
            fechainicio As String,
            fechafin As String,
            jeferegional As String,
            zona As String,
            sucursal As String,
            vendedor As String,
            ruc As String,
            razonsocial As String,
            tipocliente1 As String,
            idgrupo1 As String,
            perfil As String) As List(Of ReporteClienteCartera)

        Return New ReporteDataAccess().ListarReporteClienteCartera(
            fechainicio,
            fechafin,
            jeferegional,
            zona,
            sucursal,
            vendedor,
            ruc,
            razonsocial,
            tipocliente1,
            idgrupo1,
            perfil)
    End Function

    Public Function ListarEmpresas() As ListaEmpresa
        Return New ReporteDataAccess().ListarEmpresas()
    End Function

    Function BuscarSucursal(Empresa As String) As ListaSucursal
        Return New ReporteDataAccess().BuscarSucursal(Empresa)
    End Function

    Function ListarSkuMargenFierro() As ListaProducto
        Dim oListaSku = New ListaProducto()
        oListaSku.Add(New Producto() With {
                                .Sku = "203848X"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038536"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038498"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038463"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038501"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "203851X"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038528"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038544"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038552"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2038471"
                               })
        oListaSku.Add(New Producto() With {
                                .Sku = "2040840"
                               })
        Return oListaSku
    End Function

    Function ListarTipoCaja() As ListaTipoCaja
        Dim oListaTipoCaja As ListaTipoCaja = New ListaTipoCaja()
        oListaTipoCaja.Add(New TipoCaja() With {
                            .IdTipoCaja = "1",
                            .Descripcion = "Caja Venta Empresa"
                           })
        oListaTipoCaja.Add(New TipoCaja() With {
                            .IdTipoCaja = "2",
                            .Descripcion = "Todas las Cajas"
                           })
        Return oListaTipoCaja
    End Function


    Function SelReporteDetalladoPorFamilia(ByVal fecIni As Date, ByVal fecFin As Date) As List(Of ReporteVentaEmpresa)
        Return New ReporteDataAccess().SelReporteDetalladoPorFamilia(fecIni, fecFin)
    End Function

    Public Function SelReporteTranssaccionPorFamilia(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String, ByVal CodigoFamilia As String) As Decimal
        Return New ReporteDataAccess().SelReporteTranssaccionPorFamilia(FechaIni, FechaFin, CodigoSucursal, CodigoFamilia)
    End Function


    Public Function SelReporteTranssaccionPorFamiliaTicket(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String, ByVal CodigoFamilia As String) As Decimal
        Return New ReporteDataAccess().SelReporteTranssaccionPorFamiliaTicket(FechaIni, FechaFin, CodigoSucursal, CodigoFamilia)
    End Function

    'Public Function SelReporteTranssaccionPorFamiliaTicket(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String, ByVal CodigoFamilia As String) As Decimal
    '    Return New ReporteDataAccess().SelReporteTranssaccionPorFamiliaTicket(FechaIni, FechaFin, CodigoSucursal, CodigoFamilia)
    'End Function
    'Usp_Sel_DetalladoPorFamiliaTotalTicket
    Public Function SelReporteTranssaccionPorFamiliaTotalTicket(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoFamilia As String) As Decimal
        Return New ReporteDataAccess().SelReporteTranssaccionPorFamiliaTotalTicket(FechaIni, FechaFin, CodigoFamilia)
    End Function


    Public Function SelReporteDetalladoPorFamiliaZonaContado(ByVal fecIni As Date, ByVal CodigoZona As String) As Decimal
        Return New ReporteDataAccess().SelReporteDetalladoPorFamiliaZonaContado(fecIni, CodigoZona)
    End Function

    Public Function SelReporteTranssaccionPorsucursal(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTranssaccionPorsucursal(fecIni, CodigoSucursal)
    End Function


    Public Function SelReporteTotalTicketSucursalContado(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTotalTicketSucursalContado(FechaIni, FechaFin, CodigoSucursal)
    End Function

    Public Function SelReporteTotalTicket(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTotalTicket(FechaIni, FechaFin, CodigoSucursal)
    End Function


    Public Function SelReporteTotalTicketSucursalCredito(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoSucursal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTotalTicketSucursalCredito(FechaIni, FechaFin, CodigoSucursal)
    End Function

    Public Function SelReporteTotalTicketZonaContado(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoZona As String) As Decimal
        Return New ReporteDataAccess().SelReporteTotalTicketZonaContado(FechaIni, FechaFin, CodigoZona)
    End Function

    Public Function SelReporteTotalTicketZonaCredito(ByVal FechaIni As Date, ByVal FechaFin As Date, ByVal CodigoZona As String) As Decimal
        Return New ReporteDataAccess().SelReporteTotalTicketZonaCredito(FechaIni, FechaFin, CodigoZona)
    End Function





    Public Function SelReporteTranssaccionPorsucursalCredito(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal

        Return New ReporteDataAccess().SelReporteTranssaccionPorsucursalCredito(fecIni, CodigoSucursal)
    End Function

    Public Function SelReporteTranssaccionTotal(ByVal fecIni As Date) As Decimal

        Return New ReporteDataAccess().SelReporteTranssaccionTotal(fecIni)
    End Function




    Public Function SelReporteDetalladoPorFamiliaTotalContado(ByVal fecIni As Date) As Decimal
        Return New ReporteDataAccess().SelReporteDetalladoPorFamiliaTotalContado(fecIni)
    End Function

    Public Function SelReporteDetalladoPorFamiliaZonaCredito(ByVal fecIni As Date, ByVal CodigoZona As String) As Decimal
        Return New ReporteDataAccess().SelReporteDetalladoPorFamiliaZonaCredito(fecIni, CodigoZona)
    End Function

    Public Function SelReporteDetalladoPorDia(ByVal fecIni As Date) As Decimal
        Return New ReporteDataAccess().SelReporteDetalladoPorDia(fecIni)
    End Function

    Public Function SelReporteDetalladoPorFamiliaTotalCredito(ByVal fecIni As Date) As Decimal
        Return New ReporteDataAccess().SelReporteDetalladoPorFamiliaTotalCredito(fecIni)
    End Function

    Function SelReporteComps(fechaIniRep As Date, fechaFinRep As Date, idMarca As Integer) As List(Of ReporteComparativoAAAC)
        Return New ReporteDataAccess().SelReporteComps(fechaIniRep, fechaFinRep, idMarca)
    End Function

    Function SelReporteDetalladoPorDia(ByVal fecIni As Date, ByVal fecFin As Date) As List(Of ReporteVentaEmpresa)
        Return New ReporteDataAccess().SelReporteDetalladoPorDia(fecIni, fecFin)
    End Function

    Public Function SelReporteTicketPorSucursal(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTicketPorSucursal(fecIni, CodigoSucursal)
    End Function

    Public Function SelReporteTicketPorSucursalCredito(ByVal fecIni As Date, ByVal CodigoSucursal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTicketPorSucursalCredito(fecIni, CodigoSucursal)
    End Function


    Public Function SelReporteTicketPorZonaCredito(ByVal fecIni As Date, ByVal CodigoZonal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTicketPorZonaCredito(fecIni, CodigoZonal)
    End Function

    Public Function SelReporteTotalContado(ByVal fecIni As Date, ByVal fecFin As Date) As Decimal
        Return New ReporteDataAccess().SelReporteTotalContado(fecIni, fecFin)
    End Function

    Public Function SelReporteTotalCredito(ByVal fecIni As Date, ByVal fecFin As Date) As Decimal
        Return New ReporteDataAccess().SelReporteTotalCredito(fecIni, fecFin)
    End Function

    Public Function SelReporteTicketPorZonaContado(ByVal fecIni As Date, ByVal CodigoZonal As String) As Decimal
        Return New ReporteDataAccess().SelReporteTicketPorZonaContado(fecIni, CodigoZonal)
    End Function


    Public Function SelReporteTicketPorTotalContado(ByVal fecIni As Date) As Decimal
        Return New ReporteDataAccess().SelReporteTicketPorTotalContado(fecIni)
    End Function

    Public Function SelReporteTicketPorTotalCredito(ByVal fecIni As Date) As Decimal
        Return New ReporteDataAccess().SelReporteTicketPorTotalCredito(fecIni)
    End Function


    Public Function SelReporteTicketPorTotal(ByVal fecIni As Date) As Decimal
        Return New ReporteDataAccess().SelReporteTicketPorTotal(fecIni)
    End Function

#Region "CONSULTA CLIENTES VENDEDORES ASOCIADOS"
    Public Function ListarClienteVendedorAsociado(ByVal _clienteVenta As ClienteVenta, paginacion As Paginacion, ByRef rowCount As Integer) As List(Of ClienteVenta)
        Return New ReporteDataAccess().ListarClienteVendedorAsociado(_clienteVenta, paginacion, rowCount)
    End Function
#End Region

#Region "REPORTE AVANCE VENTAS"
    Public Function ListarAvanceVentas(usuario As String, fechaIni As String, fechaFin As String, idZonaCadena As String, jefe As String) As ListaAvanceVentas
        Dim listaAvanceVentas = New ListaAvanceVentas()
        listaAvanceVentas.ListaZonaMantenimiento = ListaZonaMantenimiento2(usuario, fechaIni, fechaFin)
        listaAvanceVentas.ListaSucursal = BuscarSucursal(idZonaCadena, usuario, fechaIni, fechaFin)
        listaAvanceVentas.ListaSubGerente = ListarSubGerente()
        listaAvanceVentas.ListaJefeVenta = BuscarJefeRegionalVentas(usuario, fechaIni, fechaFin)
        listaAvanceVentas.ListaRrvv = ListarVendedores(usuario, jefe, fechaIni, fechaFin)
        Return listaAvanceVentas
    End Function
#End Region

#Region "Reporte Usuarios"

    Function ListarReporteUsuario(ByVal usuario As Usuario, ByVal idsRol As String, ByVal fechaIni As String, ByVal fechaFin As String) As ListaUsuario
        Return New ReporteDataAccess().ListarReporteUsuario(usuario, idsRol, fechaIni, fechaFin)
    End Function

#End Region

#Region "Reporte Roles y Páginas"

    Function ListarReporteRolPagina(ByVal idsRol As String, ByVal estadoPag As Integer, ByVal nombrePag As String) As ListaPaginaRol
        Return New ReporteDataAccess().ListarReporteRolPagina(idsRol, estadoPag, nombrePag)
    End Function

#End Region

End Class
