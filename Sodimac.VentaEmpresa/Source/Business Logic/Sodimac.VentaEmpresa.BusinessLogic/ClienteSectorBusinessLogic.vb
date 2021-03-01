Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts
Public Class ClienteSectorBusinessLogic
    Function ConsultarClienteSector() As ListaClienteSector
        Return New ClienteSectorDataAccess().ConsultarClienteSector()
    End Function

    Function ConsultarEstado() As ListaProcesoEstado
        Return New ClienteSectorDataAccess().ConsultarEstado()
    End Function

End Class
