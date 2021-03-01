Imports Sodimac.VentaEmpresa.BusinessLogic
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts
Imports System.Transactions

Public Class LogBusinessLogic
    Function ActualizarLog(ByVal Log As Log) As Int32
        Using scope As New TransactionScope()
            Dim Valor = New LogDataAccess().Actualizar_Log(Log)
            scope.Complete()
            Return Valor
        End Using
    End Function

    Public Function OrigenAccion_Listar() As ListaOrigenAccion
        Return New LogDataAccess().OrigenAccion_Listar()
    End Function

    Public Function LogAccion_Listar() As ListaLogAccion
        Return New LogDataAccess().LogAccion_Listar()
    End Function
End Class
