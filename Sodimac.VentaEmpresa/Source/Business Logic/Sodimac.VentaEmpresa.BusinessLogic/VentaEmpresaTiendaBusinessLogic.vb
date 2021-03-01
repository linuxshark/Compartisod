Imports Sodimac.VentaEmpresa.DataContracts
Imports Sodimac.VentaEmpresa.DataAccess

Public Class VentaEmpresaTiendaBusinessLogic

    Function ReporteVentaEmpresaTienda(FechaInicio As String, FechaFin As String, Empresa As String, Sucursal As String) As List(Of VentaEmpresaTienda)
        Return New VentaEmpresaTiendaDataAccess().ReporteVentaEmpresaTienda(FechaInicio, FechaFin, Empresa, Sucursal)
    End Function

End Class
