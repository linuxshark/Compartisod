Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Transactions
Imports Sodimac.VentaEmpresa.BusinessEntities
Imports Sodimac.VentaEmpresa.DataAccess
Imports Sodimac.VentaEmpresa.DataContracts

Public Class ConfiguracionBusinessLogic

    Public Function ObtenerParametroPorCodigoParametro(ByVal CodigoParametro As String) As Parametro
        Return New ConfiguracionDataAccess().ObtenerParametroPorCodigoParametro(CodigoParametro)
    End Function

    Public Function ObtenerParametro(ByVal IdParametro As String) As Parametro
        Return New ConfiguracionDataAccess().ObtenerParametro(IdParametro)
    End Function

    Public Function Buscar_Parametros(ByVal Paginacion As Paginacion) As Paginacion
        Return New ConfiguracionDataAccess().Buscar_Parametros(Paginacion)
    End Function

    Public Function Actualizar_Parametro(ByVal Parametro As Parametro) As String
        Using scope As New TransactionScope()
            Dim Valor As Integer
            Valor = New ConfiguracionDataAccess().Actualizar_Parametro(Parametro)
            If (Valor = Constantes.ValorUno) Then
                scope.Complete()
            End If
            Return "Se actualizó correctamente"
        End Using
    End Function

End Class
