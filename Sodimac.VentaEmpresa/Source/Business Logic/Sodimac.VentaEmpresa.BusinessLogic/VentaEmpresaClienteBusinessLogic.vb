Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.DataAccess

Public Class VentaEmpresaClienteBusinessLogic

    Function ReporteVentaEmpresaCliente(FechaInicio As String, FechaFin As String, Sucursal As String, Ruc As String) As List(Of VentaEmpresaCliente)
        Return New VentaEmpresaClienteDataAccess().ReporteVentaEmpresaCliente(FechaInicio, FechaFin, Sucursal, Ruc)
    End Function

End Class