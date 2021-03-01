Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts

Public Class ClienteCategoriaBusinessLogic
    Function ConsultarClienteCategoria() As ListaClienteCategoria
        Return New ClienteCategoriaDataAccess().ConsultarClienteCategoria()
    End Function
End Class
