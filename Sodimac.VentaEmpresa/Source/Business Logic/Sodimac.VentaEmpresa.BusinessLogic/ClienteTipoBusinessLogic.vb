Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts
Public Class ClienteTipoBusinessLogic
    Function ConsultarClienteTipo() As ListaClienteTipo
        Return New ClienteTipoDataAccess().ConsultarClienteTipo()
    End Function
End Class
