Imports Sodimac.VentaEmpresa.DataContracts

Public Class ReporteViewModel
    Public Marca As Marca
    Public ListaMarca As List(Of Marca)
    Public Sucursal As Sucursal
    Public Empresa As Empresa
    Public ListaSucursal As ListaSucursal
    Public FechaInicio As DateTime
    Public FechaFin As DateTime
    Public Zona As Zona
    Public ClienteVenta As ClienteVenta
    Public ListaZona As ListaZona
    Public ListaClienteSector As ListaClienteSector
    Public ClienteSector As ClienteSector
    Public ListaClienteCategoria As ListaClienteCategoria
    Public ClienteCategoria As ClienteCategoria
    Public ListaClienteModoPagoCombo As ListaClienteModoPagoCombo
    Public ClienteModoPagoCombo As ClienteModoPagoCombo
    Public Empleado As Empleado
    Public ListaEmpleado As ListaEmpleado
    Public ListaJefeRegional As ListaEmpleado
    Public ListaClienteTipo As ListaClienteTipo
    Public ListaTipoCaja As ListaTipoCaja
    Public ClienteTipo As ClienteTipo
    Public ZonaMantenimiento As ZonaMantenimiento
    Public ListaZonaMantenimiento As ListaZonaMantenimiento
    Public ListaEmpresa As ListaEmpresa
    Public Grupo As Grupo
    Public ListaGrupo As ListaGrupo
    Public Sku As String
    Public IdPerfilActual As Integer
    Public ListaProducto As ListaProducto



    Public ClienteEstadoLinea As Estado
    Public ListaClienteEstadoLinea As ListaClienteEstadoLinea
    Public OrigenAccion As OrigenAccion
    Public ListaOrigenAccion As ListaOrigenAccion
    Public LogAccion As LogAccion
    Public ListaLogAccion As ListaLogAccion

    Public ListaAvanceVentas As ListaAvanceVentas

    Public CadenaZona As String
    Public CadenaSucursal As String
    Public CadenaSubGerente As String
    Public CadenaJefeVenta As String
    Public CadenaRrvv As String
    Public JefeCadena As String

    Public TipoSubGerente As String
End Class
