Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Reflection
Public Class SucursalesBusinessLogic

    Public Function ListarSucursalHistorico(ByRef oPaginacion As Paginacion) As Paginacion
        Return New SucursalesDataAccess().ListarSucursalHistorico(oPaginacion)
    End Function
End Class
